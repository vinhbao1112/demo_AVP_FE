Imports System.Text.RegularExpressions
Imports AVPLib
Imports AVPLib.DataManagerment
Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPControls

Public Class TriggerEmail_Popup
    Private m_Email As AVPLib.TriggerEmail
    Private m_isModified As Boolean = False

    Public Property TrigerEmail() As AVPLib.TriggerEmail
        Get
            Return m_Email
        End Get
        Set(ByVal value As AVPLib.TriggerEmail)
            m_Email = value
        End Set
    End Property

    Public ReadOnly Property IsModifiedValue() As Boolean
        Get
            Return m_isModified
        End Get
    End Property

    ''' <author>
    '''    	<name> Tin Vu</name>
    '''    	<date> 2015-06-11 </date>
    ''' </author>
    ''' <summary>
    ''' </summary>
    Private Sub txtEmailTo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEmailTo.Click
        Try
            Dim pad As New KeyPad
            pad.Enable_DisableBtnAt = True
            Dim Value As String = Me.txtEmailTo.Text
            If pad.DisplayKeypad(Value, "Please input the Email", False) = Windows.Forms.DialogResult.OK Then
                If Not String.IsNullOrEmpty(Value) Then
                    Confirm.Enabled = False
                    If m_Email IsNot Nothing Then
                        If (AVPLib.SendEmail.Instance.ValidateEmail(Value)) Then
                            Confirm.Enabled = True
                            m_Email.Name = Value
                            m_isModified = True
                        Else
                            Confirm.Enabled = False
                        End If
                    End If
                    txtEmailTo.Text = Value
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub Confirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Confirm.Click
        Try
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub chkAlarm_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAlarm.CheckedChanged
        Try
            m_Email.IsAlarm = Me.chkAlarm.Checked
            m_isModified = True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Sub New()
        Try
            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Tin Vu</name>
    '''    	<date> 2015-06-11 </date>
    ''' </author>
    ''' <summary>
    ''' </summary>
    Private Sub TriggerEmail_Popup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If m_Email IsNot Nothing Then
                Me.txtEmailTo.Text = m_Email.Name.ToString
                Me.chkAlarm.Checked = m_Email.IsAlarm
                Me.chkScheduler.Checked = m_Email.IsScheduler
                Me.chkReport.Checked = m_Email.IsPressure
                Me.txtEveryMinutes.Text = m_Email.PressureInterval
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub chkReport_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkReport.CheckedChanged
        Try
            m_Email.IsPressure = Me.chkReport.Checked
            m_isModified = True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Tin Vu</name>
    '''    	<date> 2015-06-11 </date>
    ''' </author>
    ''' <summary>
    ''' txtEveryMinutes_Click click minute text action
    ''' </summary>
    Private Sub txtEveryMinutes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEveryMinutes.Click
        Try
            ChangeMinMaxMinutes("SystemSetup." & txtEveryMinutes.Name, sender)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Tin Vu</name>
    '''    	<date> 2015-06-11 </date>
    ''' </author>
    ''' <summary>
    ''' </summary>
    Private Sub ChangeMinMaxMinutes(ByVal Source As String, ByVal sender As Object)
        Try
            Dim frm As New NumPad
            Dim Title As String = AVPLib.ContainerData.GetMessageText(Source)
            Dim value As String = CType(sender, TextBox).Text
            Dim txtEveryMinutesLimit As String = Source & "."
            Dim oldValue As String = value
            Dim Min As Double = Double.Parse(AVPLib.ContainerData.GetRobotConfig(txtEveryMinutesLimit + STRING_MIN).ToString())
            Dim Max As Double = Double.Parse(AVPLib.ContainerData.GetRobotConfig(txtEveryMinutesLimit + STRING_MAX).ToString())

            Dim InputRes As MsgBoxResult = frm.GetUserInput(value, -1, -1, Min, Max, Title)

            If frm.IsMaxMinModified Then
                AVPLib.ContainerData.SetRobotConfig(txtEveryMinutesLimit + STRING_MIN, frm.NewMin)
                AVPLib.ContainerData.SetRobotConfig(txtEveryMinutesLimit + STRING_MAX, frm.NewMax)
            End If

            If InputRes = MsgBoxResult.Ok Then
                If Not String.IsNullOrEmpty(value) Then
                    CType(sender, TextBox).Text = value
                    m_Email.PressureInterval = value
                    m_isModified = True
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Try
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try    
    End Sub

    ''' <author>
    '''    	<name> Tin Vu</name>
    '''    	<date> 2015-06-11 </date>
    ''' </author>
    ''' <summary>
    ''' </summary>
    Private Sub txtEmailTo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEmailTo.TextChanged, errValidateEmailTo.RightToLeftChanged
        Try
            If (AVPLib.SendEmail.Instance.ValidateEmail(txtEmailTo.Text)) Then
                Confirm.Enabled = True
                m_Email.Name = txtEmailTo.Text
                m_isModified = True
                errValidateEmailTo.SetError(txtEmailTo, "")
            Else
                Confirm.Enabled = False
                errValidateEmailTo.SetError(txtEmailTo, "invalid email address")
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Tin Vu</name>
    '''    	<date> 2015-06-11 </date>
    ''' </author>
    ''' <summary>
    ''' </summary>
    Private Sub chkScheduler_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkScheduler.CheckedChanged
        Try
            m_Email.IsScheduler = Me.chkScheduler.Checked
            m_isModified = True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try  
    End Sub
End Class