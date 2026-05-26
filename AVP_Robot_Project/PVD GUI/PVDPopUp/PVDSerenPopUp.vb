Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Imports AVPControls

Public Class PVDSerenPopUp
    Public Enum PowerSupplyType
        BiasPowerSupply
        RFTargetPowerSupply
    End Enum
    Private m_blnIsOnline As Boolean = False
    Private m_blnIsBiasPowerSupply As Boolean = True
    Private m_lstSpecialType_PowerSupply As List(Of String) = Nothing
    Private m_strParentName As String = String.Empty
    Private m_ParentPower As BiasPowerSupply = Nothing
    Public Event TextboxClick(ByVal sender As Object, ByVal e As EventArgs)
    Public Event AutoButtonClick(ByVal sender As Object, ByVal e As EventArgs)
#Region "Properties"
    Public Overrides Property IsOnline() As Boolean
        Get
            Return m_blnIsOnline
        End Get
        Set(ByVal value As Boolean)
            m_blnIsOnline = value
            txtForwardPowerRight.Enabled = (Not m_blnIsOnline)
            txtC1Right.Enabled = Not m_blnIsOnline
            txtC2Right.Enabled = Not m_blnIsOnline
            txtPresetsRight.Enabled = Not m_blnIsOnline
            btnAuto.Enabled = Not m_blnIsOnline
            txtVoltageRight.Enabled = (Not m_blnIsOnline)

            If Not m_blnIsOnline Then ''if not online->set enable/disable rule
                If String.IsNullOrEmpty(txtVoltageRight.Text) Then
                    txtForwardPowerRight.Enabled = True
                Else
                    txtForwardPowerRight.Enabled = IIf(CDbl(txtVoltageRight.Text) <= 0, True, False)
                End If
                If String.IsNullOrEmpty(txtForwardPowerRight.Text) Then
                    txtVoltageRight.Enabled = True
                Else
                    txtVoltageRight.Enabled = IIf(CDbl(txtForwardPowerRight.Text) <= 0, True, False)
                End If
            End If
        End Set
    End Property

    Public Property IsBiasPowerSupply() As Boolean
        Get
            Return m_blnIsBiasPowerSupply
        End Get
        Set(ByVal value As Boolean)
            m_blnIsBiasPowerSupply = value
            If m_blnIsBiasPowerSupply Then
                txtVoltageRight.Visible = True
                Me.Text = "Bias Power Supply"
            Else
                txtVoltageRight.Visible = False
                Me.Text = "Target Power Supply"
            End If
        End Set
    End Property

    Public Property ParentName() As String
        Get
            Return m_strParentName
        End Get
        Set(ByVal value As String)
            m_strParentName = value
        End Set
    End Property

#End Region

#Region "Protected method"
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-19</date>
    ''' </author>
    ''' <summary>
    ''' Create status tree to manage status of all objects inside
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub CreateStatusTree()
        Try
            Dim stbForwardPower As New StatusTextBox(Me.txtForwardPower)
            Dim stbForwardPowerRight As New StatusTextBox(Me.txtForwardPowerRight)

            Dim stbReflectedPower As New StatusTextBox(Me.txtReflectedPower)
            Dim stbVoltage As New StatusTextBox(Me.txtVoltage)
            Dim stbMag As New StatusTextBox(Me.txtMag)
            Dim stbPhase As New StatusTextBox(Me.txtPhase)

            Dim stbC1 As New StatusTextBox(Me.txtC1)
            Dim stbC1Right As New StatusTextBox(Me.txtC1Right)

            Dim stbC2 As New StatusTextBox(Me.txtC2)
            Dim stbC2Right As New StatusTextBox(Me.txtC2Right)

            Dim stbMatch As New StatusTextBox(Me.txtMatch)
            Dim stbPresets As New StatusTextBox(Me.txtPresets)
            Dim stbPresetsRight As New StatusTextBox(Me.txtPresetsRight)
            Dim sbcAuto As New StatusIGCGButton(Me.btnAuto)

            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(sbcAuto)
            m_stoStatusObject.AddChild(stbForwardPower)
            m_stoStatusObject.AddChild(stbForwardPowerRight)
            m_stoStatusObject.AddChild(stbReflectedPower)
            m_stoStatusObject.AddChild(stbVoltage)
            m_stoStatusObject.AddChild(stbC1)
            m_stoStatusObject.AddChild(stbC1Right)
            m_stoStatusObject.AddChild(stbC2)
            m_stoStatusObject.AddChild(stbC2Right)
            m_stoStatusObject.AddChild(stbMatch)
            m_stoStatusObject.AddChild(stbPresets)
            m_stoStatusObject.AddChild(stbPresetsRight)
            m_stoStatusObject.AddChild(stbMag)
            m_stoStatusObject.AddChild(stbPhase)
            If IsBiasPowerSupply Then
                Dim stbVoltageRight As New StatusTextBox(Me.txtVoltageRight)
                m_stoStatusObject.AddChild(stbVoltageRight)
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub
#End Region

#Region "Events – Buttons – Forms…"
    Private Sub txtTargetPowerRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtForwardPowerRight.Click, _
                                                                  txtC1Right.Click, txtC2Right.Click, txtPresetsRight.Click, txtVoltageRight.Click
        Try
            RaiseEvent TextboxClick(sender, e)
            Dim TextBox As System.Windows.Forms.TextBox = CType(sender, System.Windows.Forms.TextBox)
            Dim ctrol As Control() = m_ParentPower.Controls.Find(TextBox.Name.ToString(), True)
            If ctrol IsNot Nothing AndAlso ctrol.Length = 1 Then
                Dim textbox1 As System.Windows.Forms.TextBox = CType(ctrol(0), System.Windows.Forms.TextBox)
                textbox1.Text = TextBox.Text
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub

    Private Sub btnAuto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAuto.Click
        Try
            RaiseEvent AutoButtonClick(sender, e)
            'Dim strMessageText As String = String.Empty
            'Dim strChamberName As String = String.Empty

            '    strChamberName = AVPLib.Utils.chamberID2ChamberName(Me.ParentName)
            '    PVDSupport.ReadMessageText(sender, Me.Parent, strMessageText)
            '    Try
            '    If Utils.ShowAVPMessageBox(strMessageText, strChamberName, MessageBoxIcon.Information) = DialogResult.OK Then
            '        Dim strLogMessage As String = String.Empty
            '        Dim strSourceLogMessage As String = String.Empty
            '        strSourceLogMessage = "[" + strChamberName + "-" + Me.Text + "]"

            '        If CType(sender, ButtonIGCGControl).Status = DisplayStatus.On Then
            '            strLogMessage = "Turn Match to Manual"
            '            m_stoStatusObject.RequestStatus(btnAuto.Name, STR_OFF)

            '        Else
            '            strLogMessage = "Turn Match to Auto"
            '            m_stoStatusObject.RequestStatus(btnAuto.Name, STR_ON)
            '        End If
            '        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
            '                                           strSourceLogMessage + " " + strLogMessage)

            '    End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Sub StartProcessing() ''reset editbox to empty
        Me.txtForwardPowerRight.Text = String.Empty
        Me.txtC1Right.Text = String.Empty
        Me.txtC2Right.Text = String.Empty
        Me.txtPresetsRight.Text = String.Empty
    End Sub

    Private Sub txtMatch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If txtMatch.Text = "Auto" Then
            Me.txtC2Right.Enabled = False
            Me.txtC1Right.Enabled = False
        Else
            Me.txtC2Right.Enabled = True
            Me.txtC1Right.Enabled = True
        End If
    End Sub
#End Region


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        m_stoStatusObject = New StatusObject()

        ' Add any initialization after the InitializeComponent() call.
        m_lstSpecialType_PowerSupply = New List(Of String)
        m_lstSpecialType_PowerSupply.Add(AVPLib.SystemModule.Power_Supply_Model.ENI_1250)
        m_lstSpecialType_PowerSupply.Add(AVPLib.SystemModule.Power_Supply_Model.ENI_2000)
        m_lstSpecialType_PowerSupply.Add(AVPLib.SystemModule.Power_Supply_Model.MKS_3513)
    End Sub

    Public Sub New(ByVal Parent As BiasPowerSupply)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        m_stoStatusObject = New StatusObject()
        m_ParentPower = Parent

        ' Add any initialization after the InitializeComponent() call.
        m_lstSpecialType_PowerSupply = New List(Of String)
        m_lstSpecialType_PowerSupply.Add(AVPLib.SystemModule.Power_Supply_Model.ENI_1250)
        m_lstSpecialType_PowerSupply.Add(AVPLib.SystemModule.Power_Supply_Model.ENI_2000)
        m_lstSpecialType_PowerSupply.Add(AVPLib.SystemModule.Power_Supply_Model.MKS_3513)
    End Sub

End Class
