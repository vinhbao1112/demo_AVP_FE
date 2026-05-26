Imports AVPLib
Imports AVPLib.ConstEnum
Imports AVP_Robot_Project.ConstantAndEnum

Public Class AutoTransferWaferControl
    Const CYCLE_WAFER As String = "Cycle Wafer"
    Public IsRobotGoToStation As Boolean = False
    Public IsRobotChangeStatus As Boolean = False
    Public IsRobotPickPlaceAction As Boolean = False
    Private m_blnIsOnline As Boolean = False

#Region "Properties"
    Public Property IsOnline() As Boolean
        Get
            Return m_blnIsOnline
        End Get
        Set(ByVal value As Boolean)
            m_blnIsOnline = value
            txtCurrentPos.Enabled = Not m_blnIsOnline
            cboStationList.Enabled = Not m_blnIsOnline
            Enable_Disable_AllButton(Not m_blnIsOnline)
            
        End Set
    End Property
#End Region
#Region "Protected method"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-19</date>
    ''' </author>
    ''' <summary>
    ''' Create status tree to manage status of all objects inside
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub CreateStatusTree()
        Try
            m_stoStatusObject.Name = Me.Name
            Dim sbcEXStatus As New StatusIGCGButton(btnEXStatus)
            Dim sbcREStatus As New StatusIGCGButton(btnREStatus)
            Dim sbcUPStatus As New StatusIGCGButton(btnUPStatus)
            Dim sbcDNStatus As New StatusIGCGButton(btnDNStatus)
            Dim stRobotHome As New StatusIGCGButton(btnHome)
            Dim stRobotPosition As New StatusTextRobotPosition(txtCurrentPos)
            Dim stPickStatus As New StatusPickPlaceRobotHand(btnPick)
            Dim stPlaceStatus As New StatusPickPlaceRobotHand(btnPlace)

            m_stoStatusObject.AddChild(New StatusCheckbox(Me.chkRunWithRecipeA))
            m_stoStatusObject.AddChild(New StatusCheckbox(Me.chkRunWithRecipeB))
            m_stoStatusObject.AddChild(stRobotHome)
            m_stoStatusObject.AddChild(stRobotPosition)
            m_stoStatusObject.AddChild(sbcEXStatus)
            m_stoStatusObject.AddChild(sbcREStatus)
            m_stoStatusObject.AddChild(sbcDNStatus)
            m_stoStatusObject.AddChild(sbcUPStatus)
            m_stoStatusObject.AddChild(stPickStatus)
            m_stoStatusObject.AddChild(stPlaceStatus)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Private methods"
    ''' Click on btn HOME: Panel Robot Control of TM Screen
    Private Sub btnHome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHome.Click
        AVPLib.Log.guiLogger.Info("Enter btnHome_Click")
        Dim strMessageText As String = String.Empty
        Try
            strMessageText = AVPLib.ContainerData.GetMessageText("HomeButtonCenterRobotCassettes")
            If Utils.ShowAVPMessageBox(strMessageText, HOME_TM, MessageBoxIcon.Question) = DialogResult.OK Then
                m_stoStatusObject.RequestStatus(btnHome.Name, "Click")
                Utils.RobotCMDAction(False, True)
                '                btnHome.Enabled = False
                Enable_Disable_AllButton(False)
                Utils.LogUserEvent(sender, "TM Screen", "Robot Control")
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnHome_Click")
    End Sub

    Private Sub btnEXStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEXStatus.Click, btnDNStatus.Click, btnREStatus.Click, btnUPStatus.Click
        AVPLib.Log.guiLogger.Info("Enter btnEXStatus_Click")
        Try
            Dim btn As ButtonIGCGControl = CType(sender, ButtonIGCGControl)
            Utils.LogUserEvent(sender, "TM Screen", "Robot Control")
            Dim strMessageText As String = String.Empty
            Dim strDirection As String = txtCurrentPos.Text.Replace(STATION, "")
            Dim SlitValveStatus As AVPLib.DataManagerment.Equipment.WorkingStatuses = DataManagerment.Equipment.WorkingStatuses.On
            Select Case btn.Name
                Case btnEXStatus.Name
                    strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("RobotStatus"), "Extend")
                    ConvertPosition_2_EQ(strDirection, SlitValveStatus)
                Case btnDNStatus.Name
                    strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("RobotStatus"), "Down")
                Case btnREStatus.Name
                    strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("RobotStatus"), "Retract")
                Case btnUPStatus.Name
                    strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("RobotStatus"), "Up")
            End Select

            If Utils.ShowAVPMessageBox(strMessageText, "Robot Status", MessageBoxIcon.Question) = DialogResult.OK Then
                If SlitValveStatus <> DataManagerment.Equipment.WorkingStatuses.On Then
                    'Utils.ShowAVPMessageBox("Slit valve is not open", "Extend Arm Failed", MessageBoxIcon.Exclamation, AVPMessageBox.AVPMessageBoxButton.OK)
                    AVPLib.Utils.ThrowAlarm("Slit valve is not open. Robot Arm extended Failed")
                    Exit Sub
                End If
                IsRobotChangeStatus = True
                Enable_Disable_AllButton(False)
                m_stoStatusObject.RequestStatus(btn.Name, String.Empty)
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnEXStatus_Click")
    End Sub
    ''' Click on btn PICK, PLACE: Panel Robot Control of TM Screen
    Private Sub btnPick_Place_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPick.Click, btnPlace.Click
        AVPLib.Log.guiLogger.Info("Enter btnPick_Place_Click")
        Try
            Dim btn As ButtonIGCGControl = CType(sender, ButtonIGCGControl)
            Utils.LogUserEvent(sender, "TM Screen", "Robot Control")
            Dim strMessageText As String = String.Empty
            Dim strDirection As String = String.Empty
            Dim blnPickAction As Boolean = False
            Dim SlitValveStatus As AVPLib.DataManagerment.Equipment.WorkingStatuses = DataManagerment.Equipment.WorkingStatuses.Off
            Select Case btn.Name
                Case btnPick.Name
                    strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("PickPlaceWafer"), "Pick")
                    blnPickAction = True
                Case btnPlace.Name
                    strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("PickPlaceWafer"), "Place")
                    blnPickAction = False
            End Select
            strDirection = txtCurrentPos.Text.Replace(STATION, "")
            ''get EQ         
            ConvertPosition_2_EQ(strDirection, SlitValveStatus)
            If String.IsNullOrEmpty(strDirection) Then
                Utils.ShowAVPMessageBox("Current Robot Position is empty, can not Pick/Place", "Pick/Place Failed", MessageBoxIcon.Warning, AVPMessageBox.AVPMessageBoxButton.OK)
            ElseIf Utils.ShowAVPMessageBox(strMessageText, "Robot Status", MessageBoxIcon.Question) = DialogResult.OK Then
                If SlitValveStatus <> DataManagerment.Equipment.WorkingStatuses.On Then
                    'Utils.ShowAVPMessageBox("Slit valve is not open", "Robot Pick/Place Failed", MessageBoxIcon.Exclamation, AVPMessageBox.AVPMessageBoxButton.OK)
                    AVPLib.Utils.ThrowAlarm("Slit valve is not open. Robot Pick/Place Failed")
                    Exit Sub
                End If
                IsRobotPickPlaceAction = True
                Enable_Disable_AllButton(False)
                m_stoStatusObject.RequestStatus(btn.Name, strDirection)
                If blnPickAction Then
                    btnPick.Status = DisplayStatus.On
                    btnPlace.Status = DisplayStatus.Off
                Else
                    btnPick.Status = DisplayStatus.Off
                    btnPlace.Status = DisplayStatus.On
                End If
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnPick_Place_Click")
    End Sub
#End Region
    Private Sub ConvertPosition_2_EQ(ByRef currentPos As String, ByRef SlitValveStatus As AVPLib.DataManagerment.Equipment.WorkingStatuses)
        Dim objTM As AVPLib.DataManagerment.CassettesModule = _
                      AVPLib.DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString())
        Select Case currentPos
            Case RobotConfigurationValues.PM1_STATION_NO.ToString()
                SlitValveStatus = (objTM.SplitValve2Status)
            Case RobotConfigurationValues.PM2_STATION_NO.ToString()
                SlitValveStatus = objTM.SplitValve3Status
            Case RobotConfigurationValues.PM3_STATION_NO.ToString()
                SlitValveStatus = objTM.SplitValve4Status
            Case RobotConfigurationValues.ALIGNER_STATION_NO.ToString()
                SlitValveStatus = DataManagerment.Equipment.WorkingStatuses.On
            Case RobotConfigurationValues.ALIGNER_DELTA_PICK_STATION_NO.ToString()
                SlitValveStatus = DataManagerment.Equipment.WorkingStatuses.On
            Case RobotConfigurationValues.LLA_STATION_NO.ToString()
                SlitValveStatus = objTM.SplitValve1Status
        End Select
    End Sub

    Public Sub Enable_Disable_AllButton(ByVal blnEnable As Boolean)
        btnEXStatus.Enabled = blnEnable
        btnREStatus.Enabled = blnEnable
        btnUPStatus.Enabled = blnEnable
        btnDNStatus.Enabled = blnEnable
        btnHome.Enabled = blnEnable
        btnPick.Enabled = blnEnable
        btnPlace.Enabled = blnEnable
        chkDisableChekingSensor.Enabled = blnEnable
        cboStationList.Enabled = blnEnable
    End Sub

    Private Sub chkDisableChekingSensor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDisableChekingSensor.Click
        Try
            Dim strMessageText As String = AVPLib.ContainerData.GetMessageText("DisableSensorChecking")
            Dim blnChange As Boolean = RobotConfigurationValues.DISABLE_SENSOR_CHECKING

            If chkDisableChekingSensor.Checked Then
                strMessageText = String.Format(strMessageText, "Disable")
                If Utils.ShowAVPMessageBox(strMessageText, "Disable wafer sensor checking", MessageBoxIcon.Question, MessageBoxButtons.YesNo) = DialogResult.OK Then
                    RobotConfigurationValues.DISABLE_SENSOR_CHECKING = chkDisableChekingSensor.Checked
                    AddLotDatalog("Disable wafer sensor checking")
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                            AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                            "[System Setup] Disable wafer sensor checking")
                Else
                    RobotConfigurationValues.DISABLE_SENSOR_CHECKING = False
                    chkDisableChekingSensor.Checked = False
                End If
            Else
                strMessageText = String.Format(strMessageText, "Enable")
                If Utils.ShowAVPMessageBox(strMessageText, "Enable wafer sensor checking", MessageBoxIcon.Question, MessageBoxButtons.YesNo) = DialogResult.OK Then
                    RobotConfigurationValues.DISABLE_SENSOR_CHECKING = False
                    AddLotDatalog("Enable wafer sensor checking")
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                            AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                            "[System Setup] Enable wafer sensor checking")
                Else
                    RobotConfigurationValues.DISABLE_SENSOR_CHECKING = True
                    chkDisableChekingSensor.Checked = True
                End If
            End If
            '''compare with previous value
            If blnChange <> chkDisableChekingSensor.Checked Then
                SendCMD2Robot()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Sub SendCMD2Robot()
        Dim objRobotController As AVPLib.Business.RobotController = _
                                                 CType(AVPLib.Business.ControllerManager.GetController(ConstEnum.Equipments.Robot.ToString()), _
                                                 AVPLib.Business.RobotController)

        If RobotConfigurationValues.DISABLE_SENSOR_CHECKING Then ''turn off
            m_stoStatusObject.RequestStatus(chkDisableChekingSensor.Name, "TurnOffWaferSensorChecking")
            'objRobotController.DoTask("TurnOffWaferSensorChecking")
        Else
            m_stoStatusObject.RequestStatus(chkDisableChekingSensor.Name, "TurnOnWaferSensorChecking")
            'objRobotController.DoTask("TurnOnWaferSensorChecking")
        End If
    End Sub

    Private Sub AddLotDatalog(ByVal Info As String)
        Try
            If (AVPLib.Business.AVPCore.Instance() IsNot Nothing) Then

                Dim objLoadLockACtrl As AVPLib.Business.LoadLockController = Nothing

                Dim objCtrlJobA As AVPLib.Business.AVPControlJob = Nothing


                objLoadLockACtrl = AVPLib.Business.ControllerManager.GetController(AVPLib.ConstEnum.Equipments.LoadLockA.ToString())

                If (objLoadLockACtrl IsNot Nothing AndAlso objLoadLockACtrl.CtrlJobId <> String.Empty) Then
                    objCtrlJobA = AVPLib.Business.AVPCore.Instance().JobManager().GetControlJob(objLoadLockACtrl.CtrlJobId)
                    If (objCtrlJobA IsNot Nothing) Then
                        AVPLib.Business.AVPLotDatalog.AddLotDatalog(AVPLib.ConstEnum.LoadLockA_STR, _
                        LogType.Info, Info, objCtrlJobA.IsAutoTransferJob)
                    End If
                End If
            End If
        Catch ex As Exception
            ContainerForm.SystemSetup.TransferSetPointTextChanged = 0
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        If (RobotConfigurationValues.ROBOT_VERSION_CONFIG = 7.2) Then
            chkDisableChekingSensor.Visible = False
        End If
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub AutoTransferWaferControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If AVPLib.RobotConfigurationValues.ROBOT_SENSOR_INSTALLED = False Then
                chkDisableChekingSensor.Enabled = False
                AVPLib.RobotConfigurationValues.DISABLE_SENSOR_CHECKING = True
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Dung Pham </name>
    '''    	<date> 2019-03-26</date>
    ''' </author>
    ''' <summary>
    ''' Event SelectedIndexChanged of cboStationList
    ''' </summary>
    Private Sub cboStationList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboStationList.SelectedIndexChanged
        AVPLib.Log.guiLogger.Info("Enter cboStationList_SelectedIndexChanged")
        Dim strMessageText As String = String.Empty

        Try
            If cboStationList.SelectedIndex <> 0 Then
                strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("GotoStationRobot"), cboStationList.SelectedItem.ToString())

                If Utils.ShowAVPMessageBox(strMessageText, "Goto Station", MessageBoxIcon.Question) = DialogResult.OK Then
                    m_stoStatusObject.RequestStatus(cboStationList.Name, cboStationList.SelectedItem.ToString().Replace(" ", ""))
                    Enable_Disable_AllButton(False)
                    IsRobotGoToStation = True

                    Utils.LogUserEvent(sender, "TM Screen", "Robot Control")
                End If

                '0007049: [KhoiHa- 08/22/2014][VCO19]User confused the current location of robot. Make different between RB and SP. Clear SP when user cli
                cboStationList.SelectedIndex = 0
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave cboStationList_SelectedIndexChanged")
    End Sub
End Class

