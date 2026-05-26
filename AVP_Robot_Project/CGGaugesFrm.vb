Imports AVPLib.DataManagerment.Equipment
Imports AVP_Robot_Project.ConstantAndEnum
Public Class CGGaugesFrm
#Region "Class Constants & Variables"
    Private m_isTurnOnOffMP As Boolean = False
    Private m_strMessageTitle As String = String.Empty
    Private m_isEnableIGOnOff As Boolean = False
    Private m_IsSetATM As Boolean = False
    Private m_IsSetVAC As Boolean = False
    Private m_PumpStatus As WorkingStatuses = WorkingStatuses.Unknown
    Private m_IGStatus As WorkingStatuses = WorkingStatuses.Unknown
    Private m_RoughPumpInUse As String = String.Empty
    Private m_strMessageReleaseRoughPump As String = String.Empty
#End Region

#Region "Properties"

    Public Property IsSetATM() As Boolean
        Get
            Return m_IsSetATM
        End Get
        Set(ByVal value As Boolean)
            m_IsSetATM = value
            btnATM.Enabled = m_IsSetATM
        End Set
    End Property

    Public Property IsSetVAC() As Boolean
        Get
            Return m_IsSetVAC
        End Get
        Set(ByVal value As Boolean)
            m_IsSetVAC = value
            btnVAC.Enabled = m_IsSetVAC
        End Set
    End Property

    Public Property MessageTitle() As String
        Get
            Return m_strMessageTitle
        End Get
        Set(ByVal value As String)
            m_strMessageTitle = value
            btnATM.MessageTitle = m_strMessageTitle
            btnVAC.MessageTitle = m_strMessageTitle
            btnPumpOn.MessageTitle = m_strMessageTitle
            btnPumpOff.MessageTitle = m_strMessageTitle
            btnTurnIGOn.MessageTitle = m_strMessageTitle
            btnTurnIGOff.MessageTitle = m_strMessageTitle
            btnIGFilament1.MessageTitle = m_strMessageTitle
            btnIGFilament2.MessageTitle = m_strMessageTitle
        End Set
    End Property

    Public Property PumpStatus() As WorkingStatuses
        Get
            Return m_PumpStatus
        End Get
        Set(ByVal value As WorkingStatuses)
            m_PumpStatus = value
            If m_PumpStatus = WorkingStatuses.On Then
                btnPumpOn.Status = SL_CustomButton.DisplayStatus.On
            Else

                btnPumpOn.Status = SL_CustomButton.DisplayStatus.Off
            End If
        End Set
    End Property

    Public Property IGStatus() As WorkingStatuses
        Get
            Return m_IGStatus
        End Get
        Set(ByVal value As WorkingStatuses)
            m_IGStatus = value
            If m_IGStatus = WorkingStatuses.On Then
                btnTurnIGOn.Status = SL_CustomButton.DisplayStatus.On
            Else
                btnTurnIGOn.Status = SL_CustomButton.DisplayStatus.Off
            End If

        End Set
    End Property

    Public Property RoughPumpInUse() As String
        Get
            Return m_RoughPumpInUse
        End Get
        Set(ByVal value As String)
            m_RoughPumpInUse = value

            If m_RoughPumpInUse IsNot Nothing Then
                btnRelease.Visible = True
                btnRelease.Top = grbCG.Top - 32
            Else
                btnRelease.Visible = False
            End If
        End Set
    End Property


    Public Property MessageReleaseRoughPump() As String
        Get
            Return m_strMessageReleaseRoughPump
        End Get
        Set(ByVal value As String)
            m_strMessageReleaseRoughPump = value
        End Set
    End Property
#End Region

#Region "Protected method"

    Protected Overrides Sub CreateStatusTree()
        Try
            Dim stbATM As New StatusButton(btnATM)
            Dim stbVAC As New StatusButton(btnVAC)
            Dim stbTurnOn As New StatusIGCGPopUpForm(btnPumpOn)
            Dim stbTurnOff As New StatusIGCGPopUpForm(btnPumpOff)
            Dim stbTurnIGOn As New StatusIGCGPopUpForm(btnTurnIGOn)
            Dim stbTurnIGOff As New StatusIGCGPopUpForm(btnTurnIGOff)
            Dim stbCG As New StatusStandardTextBox(txtCGPress)
            Dim stbRelease As New StatusButton(btnRelease)
            Dim stbIGFilament1 As New StatusButton(btnIGFilament1)
            Dim stbIGFilament2 As New StatusButton(btnIGFilament2)

            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(stbATM)
            m_stoStatusObject.AddChild(stbVAC)
            m_stoStatusObject.AddChild(stbTurnOn)
            m_stoStatusObject.AddChild(stbTurnOff)
            m_stoStatusObject.AddChild(stbTurnIGOn)
            m_stoStatusObject.AddChild(stbTurnIGOff)
            m_stoStatusObject.AddChild(stbCG)
            m_stoStatusObject.AddChild(stbRelease)
            m_stoStatusObject.AddChild(stbIGFilament1)
            m_stoStatusObject.AddChild(stbIGFilament2)

            btnATM.ParentStatusObj = m_stoStatusObject
            btnVAC.ParentStatusObj = m_stoStatusObject
            btnPumpOn.ParentStatusObj = m_stoStatusObject
            btnPumpOff.ParentStatusObj = m_stoStatusObject
            btnTurnIGOn.ParentStatusObj = m_stoStatusObject
            btnTurnIGOff.ParentStatusObj = m_stoStatusObject
            btnRelease.ParentStatusObj = m_stoStatusObject
            btnIGFilament1.ParentStatusObj = m_stoStatusObject
            btnIGFilament2.ParentStatusObj = m_stoStatusObject

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

#End Region

    Public Sub New(ByVal bEnableIGOnOff As Boolean, ByVal bEnablePumpOnOff As Boolean, ByVal bEnableVAC As Boolean, Optional ByVal isSwitchFilament As Boolean = False)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        btnTurnIGOff.Visible = bEnableIGOnOff
        btnTurnIGOn.Visible = bEnableIGOnOff
        btnIGFilament1.Visible = bEnableIGOnOff AndAlso isSwitchFilament
        btnIGFilament2.Visible = bEnableIGOnOff AndAlso isSwitchFilament
        btnPumpOn.Visible = bEnablePumpOnOff
        btnPumpOff.Visible = bEnablePumpOnOff
        btnVAC.Visible = bEnableVAC

        If bEnableIGOnOff = False AndAlso bEnablePumpOnOff = False Then

            btnVAC.Location = btnIGFilament1.Location
            btnATM.Location = btnIGFilament2.Location

            If bEnableVAC = False Then
                btnATM.Location = New Point(116, 10)
            End If

            Me.Size = New Point(341, 141)

        ElseIf bEnableIGOnOff AndAlso bEnablePumpOnOff = False Then

            If isSwitchFilament Then
                Me.Size = New Point(341, 243)
            Else
                btnATM.Location = btnTurnIGOn.Location
                btnVAC.Location = btnTurnIGOff.Location
                btnTurnIGOn.Location = btnIGFilament1.Location
                btnTurnIGOff.Location = btnIGFilament2.Location

                Me.Size = New Point(341, 195)
            End If

        ElseIf bEnableIGOnOff = False AndAlso bEnablePumpOnOff Then

            btnPumpOn.Location = btnIGFilament1.Location
            btnPumpOff.Location = btnIGFilament2.Location
            btnATM.Location = btnTurnIGOn.Location
            btnVAC.Location = btnTurnIGOff.Location

            Me.Size = New Point(341, 195)

        End If
    End Sub

    Public Sub UpdatePumpStatus(ByVal isPumpOn As Boolean)
        Try
            Dim statusBtnOn As SL_CustomButton.DisplayStatus = IIf(isPumpOn, SL_CustomButton.DisplayStatus.On, SL_CustomButton.DisplayStatus.Off)
            Dim statusBtnOff As SL_CustomButton.DisplayStatus = IIf(isPumpOn, SL_CustomButton.DisplayStatus.Off, SL_CustomButton.DisplayStatus.On)
            If btnPumpOn.Status <> statusBtnOn Then
                btnPumpOn.Status = statusBtnOn
            End If
            If btnPumpOff.Status <> statusBtnOff Then
                btnPumpOff.Status = statusBtnOff
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub btnTurnIGOn_StatusChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTurnIGOn.StatusChange
        If btnTurnIGOn.Status = SL_CustomButton.DisplayStatus.On Then
            btnTurnIGOff.Status = SL_CustomButton.DisplayStatus.Off
        Else
            btnTurnIGOff.Status = SL_CustomButton.DisplayStatus.On
        End If
    End Sub

    Private Sub btnPumpOn_StatusChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPumpOn.StatusChange
        If btnPumpOn.Status = SL_CustomButton.DisplayStatus.On Then
            btnPumpOff.Status = SL_CustomButton.DisplayStatus.Off
        Else
            btnPumpOff.Status = SL_CustomButton.DisplayStatus.On
        End If
    End Sub

    Public Sub UpdateSwitchIGFilament(ByVal numFilament As Integer)
        Try
            Select Case numFilament
                Case 1
                    btnIGFilament1.Status = SL_CustomButton.DisplayStatus.On
                    btnIGFilament2.Status = SL_CustomButton.DisplayStatus.Off

                Case 2
                    btnIGFilament1.Status = SL_CustomButton.DisplayStatus.Off
                    btnIGFilament2.Status = SL_CustomButton.DisplayStatus.On

            End Select
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Dung Pham </name>
    '''    	<date> 2018-12-04</date>
    ''' </author>
    ''' <summary>
    ''' Update IG Status.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UpdateIGStatus(ByVal isIGOn As Boolean)
        Try
            Dim statusBtnOn As DisplayStatus = IIf(isIGOn, DisplayStatus.On, DisplayStatus.Off)
            Dim statusBtnOff As DisplayStatus = IIf(isIGOn, DisplayStatus.Off, DisplayStatus.On)
            If btnTurnIGOn.Status <> statusBtnOn Then
                btnTurnIGOn.Status = statusBtnOn
            End If
            If btnTurnIGOff.Status <> statusBtnOff Then
                btnTurnIGOff.Status = statusBtnOff
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Dung Pham </name>
    '''    	<date> 2018-12-04</date>
    ''' </author>
    ''' <summary>
    ''' Update Enable IG Filament.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UpdateEnableIGFilament(ByVal isEnable As Boolean)
        Try
            If isEnable Then
                btnIGFilament1.Enabled = True
                btnIGFilament2.Enabled = True
            Else
                btnIGFilament1.Enabled = False
                btnIGFilament2.Enabled = False
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub btnRelease_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRelease.Click
        If Utils.ShowAVPMessageBox("Do you want to release Mechanical Pump resource? ", _
                                           "Release Rough Pump", MessageBoxIcon.Question, _
                                               MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.OK Then
            m_stoStatusObject.RequestStatus(m_strMessageReleaseRoughPump, RoughPumpInUse)
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                       "[Main Screen]" & " - Clicked on Rough Pump control to release Mechanical Pump resource")
        End If
    End Sub

    ''' <author>Dua Tran</author>
    ''' <date>2018-07-05</date>
    ''' <summary>
    ''' EnableButtonIGOnOff
    ''' </summary>
    Public Sub EnableButtonIGOnOff(ByVal isEnable As Boolean)
        Me.btnTurnIGOn.Enabled = isEnable
        Me.btnTurnIGOff.Enabled = isEnable
    End Sub
End Class