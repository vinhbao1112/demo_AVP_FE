Imports AVPLib
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports AVP_Robot_Project.ConstantAndEnum
Public Class TMControl
#Region "Class Constants & Variables"
    Public Enum DisplayStyle
        [Left] = 0
        [Right] = 1
    End Enum

    Private m_intDisplayStyle As DisplayStyle
    Private m_blnButtonVisible As Boolean
    Private Const STRING_OFF As String = "Off"
    Private Const STRING_ON As String = "On"
    Private m_displayIn As AVPScreens = AVPScreens.TMPanel
    Private m_strHeaderOffline As String
    Private m_strHeaderOnline As String
    Private m_blnIsOnline As Boolean = False
    Private m_isActive As Boolean = True
#End Region

#Region "Public Properties"
    Public Enum AVPScreens
        ProcessPanel
        TMPanel
    End Enum

    Public Property Display_In() As AVPScreens
        Get
            Return m_displayIn
        End Get
        Set(ByVal value As AVPScreens)
            m_displayIn = value
            If m_displayIn = AVPScreens.ProcessPanel Then
                Me.Width = 160
                Me.Height = 57
                Me.HivacCloseButton.Visible = False
                Me.HivacOpenButton.Visible = False
                Me.Label1.Visible = False ''COM
                Me.lblOnline.Visible = False
                Me.lblComunicationLED.Visible = False
                Me.pnlCom.Visible = False
                Me.btnComStatus.Visible = False
                Me.lblHeader.Width = Me.Width
                Me.lblHeader.TextAlign = ContentAlignment.MiddleCenter
                Me.pnlHeader.BackgroundImage = AVP_Robot_Project.My.Resources.Resources.BgHeaderBlue
                pnlRelay.Visible = False
                Me.lblPressure.Cursor = Cursors.Arrow
                Me.Label3.Visible = False
                Me.lblPressure.AutoSize = False
                Me.lblPressure.Left = 4
                Me.lblPressure.Width = Me.Width - 8
                Me.lblPressure.TextAlign = ContentAlignment.MiddleCenter
            Else
                Me.lblPressure.Left = Me.lblPressure.Left + 5
                Me.Label3.Left = Me.Label3.Left + 5
                Me.lblPressure.Cursor = Cursors.Hand
                Me.Label3.Cursor = Cursors.Hand
            End If
        End Set
    End Property

    Public Property HeaderText_Online() As String
        Get
            Return m_strHeaderOnline
        End Get
        Set(ByVal value As String)
            m_strHeaderOnline = value
        End Set
    End Property

    Public Property HeaderText_Offline() As String
        Get
            Return m_strHeaderOffline
        End Get
        Set(ByVal value As String)
            m_strHeaderOffline = value
        End Set
    End Property

    Public Property IsOnline() As Boolean
        Get
            Return m_blnIsOnline
        End Get
        Set(ByVal value As Boolean)
            m_blnIsOnline = value
            'btnHome.Enabled = Not m_blnIsOnline
            HivacCloseButton.Enabled = Not m_blnIsOnline
            HivacOpenButton.Enabled = Not m_blnIsOnline

            If m_blnIsOnline Then
                Me.pnlHeader.BackgroundImage = My.Resources.Resources.BgHeaderGreen
                Me.lblHeader.ForeColor = Color.Black
                Me.lblOnline.ForeColor = Color.Black
                Me.lblOnline.Text = "(Online)"
            Else
                Me.pnlHeader.BackgroundImage = My.Resources.Resources.BgHeaderBlue
                Me.lblHeader.ForeColor = Color.White
                Me.lblOnline.ForeColor = Color.Yellow
                Me.lblOnline.Text = "(Offline)"
            End If

        End Set
    End Property

#End Region

#Region "Constructor & Destructor"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-17</date>
    ''' </author>
    ''' <summary>
    ''' Initiate cryo control
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        '  m_blnButtonVisible = btnOn.Visible
        ' m_intDisplayStyle = DisplayStyle.Left
        'Me.Header.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.HeaderPanel_Red

    End Sub
#End Region

#Region "Protected method"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-17</date>
    ''' </author>
    ''' <summary>
    ''' Create status tree to manage status of all objects inside
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub CreateStatusTree()
        Try
            Dim stbIG As New IGCGStatusTextBox(txtIG)
            Dim stbCG As New IGCGStatusTextBox(txtCG)
            Dim sibIG As New StatusIGCGButton(bigcgIG)
            Dim sibCG As New StatusIGCGButton(bigcgCG)
            Dim sbsCloseHivacButton As New StatusIGCGButton(HivacCloseButton)
            Dim sbsOpenHivacButton As New StatusIGCGButton(HivacOpenButton)
            Dim stb_Relay As New StatusTurboRelayIndicator(btnRelay)

            Dim sbtComStatus As New StatusIGCGButton(btnComStatus)


            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(stbIG)
            m_stoStatusObject.AddChild(stbCG)
            m_stoStatusObject.AddChild(sbtComStatus)
            m_stoStatusObject.AddChild(sibCG)
            m_stoStatusObject.AddChild(sibIG)
            m_stoStatusObject.AddChild(sbsCloseHivacButton)
            m_stoStatusObject.AddChild(sbsOpenHivacButton)
            m_stoStatusObject.AddChild(stb_Relay)

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Private Methods"
    Private Sub CommStateChangeHandler(ByVal state As Boolean)
        If (Me.InvokeRequired) Then
            Me.Invoke(New CommunicationState(AddressOf CommStateChangeHandler), state)
        Else
            Dim rRobot As AVPLib.DataManagerment.Robot = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Robot.ToString())
            If (rRobot.IsCommunicating = False) Then
                ContainerForm.CassettesPanel.atwAutoTransferWafer.btnEXStatus.Status = DisplayStatus.Unknow
                ContainerForm.CassettesPanel.atwAutoTransferWafer.btnREStatus.Status = DisplayStatus.Unknow
                ContainerForm.CassettesPanel.atwAutoTransferWafer.btnUPStatus.Status = DisplayStatus.Unknow
                ContainerForm.CassettesPanel.atwAutoTransferWafer.btnDNStatus.Status = DisplayStatus.Unknow
            Else
                If (rRobot.ExternRetractStatus = AVPLib.ConstEnum.RobotEXREStatus.UNKNOWN) Then
                    ContainerForm.CassettesPanel.atwAutoTransferWafer.btnEXStatus.Status = DisplayStatus.Unknow
                    ContainerForm.CassettesPanel.atwAutoTransferWafer.btnREStatus.Status = DisplayStatus.Unknow
                Else
                    If (rRobot.IsRetracted AndAlso rRobot.IsReallyRetracted) Then
                        'retracted
                        ContainerForm.CassettesPanel.atwAutoTransferWafer.btnEXStatus.Status = DisplayStatus.Off
                        ContainerForm.CassettesPanel.atwAutoTransferWafer.btnREStatus.Status = DisplayStatus.On
                    ElseIf (rRobot.IsRetracted And Not rRobot.IsReallyRetracted) Then
                        'unknown
                        ContainerForm.CassettesPanel.atwAutoTransferWafer.btnEXStatus.Status = DisplayStatus.Unknow
                        ContainerForm.CassettesPanel.atwAutoTransferWafer.btnREStatus.Status = DisplayStatus.Unknow
                    Else
                        'extend
                        ContainerForm.CassettesPanel.atwAutoTransferWafer.btnEXStatus.Status = DisplayStatus.On
                        ContainerForm.CassettesPanel.atwAutoTransferWafer.btnREStatus.Status = DisplayStatus.Off
                    End If
                End If
            End If
        End If
    End Sub
#End Region

#Region "Events – Buttons – Forms…"
    Private Sub TM_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.lblHeader.Text = Me.Text
            Utils.UpdateTMPressure()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-06-24 </date>
    ''' </author>
    ''' <summary>
    ''' Active/Inactive controls in form
    ''' </summary>
    Public Sub ActiveForm(ByVal isEnabled As Boolean)
        btnComStatus.Enabled = isEnabled
        btnRelay.Enabled = isEnabled
        HivacCloseButton.Enabled = isEnabled
        Me.pnlHeader.Enabled = isEnabled
        HivacOpenButton.Enabled = isEnabled
        lblPressure.Cursor = IIf(isEnabled, Cursors.Hand, Cursors.Default)
        Label3.Cursor = IIf(isEnabled, Cursors.Hand, Cursors.Default)
        Panel2.Cursor = IIf(isEnabled, Cursors.Hand, Cursors.Default)
        pnlRelay.Cursor = IIf(isEnabled, Cursors.Hand, Cursors.Default)
        btnRelay.Cursor = IIf(isEnabled, Cursors.Hand, Cursors.Default)
        m_isActive = isEnabled
    End Sub
#End Region

    Private Sub btnHomeRobot_Click(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles btnHome.Click
        AVPLib.Log.guiLogger.Info("Enter btnHome_Click")
        Dim strMessageText As String = String.Empty
        Try
            strMessageText = AVPLib.ContainerData.GetMessageText("HomeButtonCenterRobotCassettes")
            If Utils.ShowAVPMessageBox(strMessageText, HOME_TM, MessageBoxIcon.Question) = DialogResult.OK Then
                ' m_stoStatusObject.RequestStatus(btnHome.Name, "Click")
                Utils.RobotCMDAction(False, True)
                ' btnHome.Enabled = False
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                             "[Main Screen]" & " Home Click")
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnHome_Click")
    End Sub
    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 03 14 2011 </date>
    ''' </author>
    ''' <summary>
    ''' Click Close Hivac Valve
    ''' Pre Condition:
    '''     + button Open Hivac have Enable status = False
    '''
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ibsHivacButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles HivacCloseButton.Click
        AVPLib.Log.guiLogger.Info("Enter ibsHivacButton_Click")
        Dim strValue As String = String.Empty

        Try
            'if Close button is visible then Hivac Valve is Closed  
            If HivacCloseButton.Status = DisplayStatus.Off Or _
               HivacCloseButton.Status = DisplayStatus.Unknow Then
                Dim strMessageText As String = String.Empty
                Dim transferModule As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString())

                'get text
                strMessageText = AVPLib.ContainerData.GetMessageText(AVP_Robot_Project.ConstantAndEnum.HIVAC_BUTTON_CLOSE)
                'show message
                If Utils.ShowAVPMessageBox(strMessageText, "TM", _
                                                          MessageBoxIcon.Warning, MessageBoxButtons.YesNo) = DialogResult.OK Then
                    'not need check condition to close hivac valve
                    strValue = BinaryStatusControl.DisplayStatus.On.ToString(STRING_G)
                    Utils.LogUserEvent("Clicked on TM Close Hivac Valve", "TM Screen")
                    m_stoStatusObject.RequestStatus(HivacCloseButton.Name, strValue)
                Else
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave ibsHivacButton_Click")
    End Sub
    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 03 14 2011 </date>
    ''' </author>
    ''' <summary>
    ''' Click Open Hivac Valve
    ''' Pre Condition:
    '''     +  Open Hivac button have Enable status = False
    '''     + all Issolation Valve is Closed
    ''' action :
    '''     + send Command close Hivac Valve
    '''     + Set Close Hivac button is Enable = False
    '''     + Set button colour = ???
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub HivacOpenButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HivacOpenButton.Click
        AVPLib.Log.guiLogger.Info("Enter HivacOpenButton_Click")
        Dim strValue As String = String.Empty
        Try
            Dim strMessageText As String = String.Empty
            Dim transferModule As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString())

            If (HivacOpenButton.Status = DisplayStatus.Off Or _
                HivacOpenButton.Status = DisplayStatus.Unknow) Then
                strMessageText = AVPLib.ContainerData.GetMessageText(AVP_Robot_Project.ConstantAndEnum.HIVAC_BUTTON_OPEN)
                If Utils.ShowAVPMessageBox(strMessageText, "TM", _
                                                          MessageBoxIcon.Warning, MessageBoxButtons.YesNo) = DialogResult.OK Then
                    Utils.LogUserEvent("Clicked on TM Open Hivac Valve", "TM Screen")
                    GoTo SendOpenHivacCmd
                Else
                    Exit Try
                End If
            Else
                Exit Try
            End If
SendOpenHivacCmd:
            If (ContainerForm.CassettesPanel.TM_ProtectedMode Is Nothing Or _
                ContainerForm.CassettesPanel.TM_ProtectedMode.Status = ProtectedModStatus.Off) Then ' if not Protected mode then check condition
                'check condition open hivac valve
                Dim strCheckResult As String = transferModule.checkCondition2OpenTMHiVac()
                'if ok
                If (String.IsNullOrEmpty(strCheckResult)) Then
                    strValue = BinaryStatusControl.DisplayStatus.Off.ToString(STRING_G)
                    m_stoStatusObject.RequestStatus(HivacCloseButton.Name, strValue)
                Else 'false -> alam
                    AVPLib.Utils.ThrowAlarm(strCheckResult)                 
                End If
            Else
                'alway pass all condition
                strValue = BinaryStatusControl.DisplayStatus.Off.ToString(STRING_G)
                m_stoStatusObject.RequestStatus(HivacCloseButton.Name, strValue)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave ibsHivacButton_Click")
    End Sub

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-07-23 </date>
    ''' </author>
    ''' <summary>
    ''' Change display status of hivac buttons
    ''' </summary>
    Public Sub ChangeHivacValveStatusTo(ByVal status As DisplayStatus)
        Try
            Dim openButtonStatus As DisplayStatus = DisplayStatus.Unknow
            Dim closeButtonStatus As DisplayStatus = DisplayStatus.Unknow
            Select Case status
                Case DisplayStatus.On
                    closeButtonStatus = DisplayStatus.Off
                    openButtonStatus = DisplayStatus.On
                Case DisplayStatus.Off
                    closeButtonStatus = DisplayStatus.On
                    openButtonStatus = DisplayStatus.Off
            End Select

            ' Update only button has diff value
            If HivacOpenButton.Status <> openButtonStatus Then
                HivacOpenButton.Status = openButtonStatus
            End If
            If HivacCloseButton.Status <> closeButtonStatus Then
                HivacCloseButton.Status = closeButtonStatus
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub lblPressure_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblPressure.Click, Label3.Click, Panel2.Click, btnRelay.Click, pnlRelay.Click
        If Not m_isActive Then
            Return
        End If
        If AVPLib.RobotConfigurationValues.IS_KEPWARE_INSTALLED AndAlso AVPLib.RobotConfigurationValues.DEVICENET_INSTALLED = False Then
            Return
        End If
        If Not IsOnline AndAlso m_displayIn <> AVPScreens.ProcessPanel Then
            Dim cassetteModule As DataManagerment.CassettesModule = _
                                            DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString())
            If ContainerForm.CassettesPanel.TMCGGaugesFrm IsNot Nothing AndAlso cassetteModule IsNot Nothing Then
                ContainerForm.CassettesPanel.TMCGGaugesFrm.Text = AVPLib.ConstEnum.TM_STR
                ContainerForm.CassettesPanel.TMCGGaugesFrm.MessageTitle = AVPLib.ConstEnum.TM_STR
                ContainerForm.CassettesPanel.TMCGGaugesFrm.IsSetATM = cassetteModule.IsSafetySetATM
                ContainerForm.CassettesPanel.TMCGGaugesFrm.IsSetVAC = cassetteModule.IsSafetySetVAC
                ContainerForm.CassettesPanel.TMCGGaugesFrm.StartPosition = FormStartPosition.CenterScreen
                ContainerForm.CassettesPanel.TMCGGaugesFrm.ShowDialog(AVPRobotMain)
            End If
        End If
    End Sub

    ''' <author>
    '''    	<name> Dy Do </name>
    '''    	<date> 2015-06-05 </date>
    ''' </author>
    ''' <summary>
    ''' Paint Border for panel
    ''' </summary>
    Private Sub Panel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint
        Utils.PaintBorder(sender, e)
    End Sub

    Private Sub lblPressure_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblPressure.TextChanged
        Try
            lblPressure.ForeColor = IIf(lblPressure.Text = ConstEnum.STR_ERROR, Color.Red, Color.Lime)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Duc Dang </name>
    '''    	<date> 2025-12-08 </date>
    ''' </author>
    ''' <summary>
    ''' Hides the Hivac button specifically for the PVD5T
    ''' </summary>
    Public Sub HideHivacButton()
        Try
            HivacCloseButton.Visible = False
            HivacOpenButton.Visible = False
            Size = New Size(190, 57)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
End Class
