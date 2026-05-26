Imports System.Windows.Forms
Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Imports AVPLib.DataManagerment
Imports AVPLib


Public Class StatusIGCGButton
    Inherits AVPControls.StatusObject

#Region "Class Constants & Variables"
    Private m_bigcgButton As ButtonIGCGControl
#End Region

#Region "Properties"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-04</date>
    ''' </author>
    ''' <summary>
    ''' Get or set the IgCgButton that will be manage by this object
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ManagedIgCgButton() As ButtonIGCGControl
        Get
            Return m_bigcgButton
        End Get
        Set(ByVal value As ButtonIGCGControl)
            m_bigcgButton = value
        End Set
    End Property
#End Region

#Region "Construtor and Destructor"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-04</date>
    ''' </author>
    ''' <summary>
    ''' Initalize with button igcg control that will be managed by this object
    ''' </summary>
    ''' <param name="bigcgButton"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal bigcgButton As ButtonIGCGControl)
        Try
            m_bigcgButton = bigcgButton
            Me.Name = m_bigcgButton.Name
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub
#End Region

#Region "Public Methods"
    ''' <author>
    '''    	<name> Dat Do </name>
    '''     <date> 2009-04-21</date>
    ''' </author>
    ''' <summary>
    ''' This procedure overrides to change satus of an object and update UI
    ''' </summary>
    ''' <param name="arg"></param>
    ''' <remarks></remarks>
    Private Sub ChangeStatusOfPM(ByVal chamberName As String, ByVal StatusString As String)
#If AVP_PLATFORM = "CX" Then
        Select Case chamberName
            Case AVPLib.ConstEnum.Equipments.Chamber1.ToString()
                ContainerForm.ProcessPanel.cbcChamber1.txtStatus.Text = StatusString
            Case AVPLib.ConstEnum.Equipments.Chamber2.ToString()
                ContainerForm.ProcessPanel.cbcChamber2.txtStatus.Text = StatusString
            Case AVPLib.ConstEnum.Equipments.Chamber3.ToString()
                ContainerForm.ProcessPanel.cbcChamber3.txtStatus.Text = StatusString
        End Select
#End If
    End Sub

    Private Sub ChangeShutterStatus(ByVal value As String)
        Dim objPvdpanel As PVDPanel = ContainerForm.ChamberPanel(Me.Parent.Parent.Name)
        If objPvdpanel Is Nothing OrElse objPvdpanel.ShutterVisible = False Then
            Exit Sub
        End If
        Select Case value
            Case STR_ON
                m_bigcgButton.Status = DisplayStatus.On
                objPvdpanel.ChuckControl.btnShutterStatus.Visible = False
            Case STR_OFF
                m_bigcgButton.Status = DisplayStatus.Off
                objPvdpanel.ChuckControl.btnShutterStatus.Visible = True
            Case Else
                m_bigcgButton.Status = DisplayStatus.Unknow
                objPvdpanel.ChuckControl.btnShutterStatus.Visible = False
        End Select
    End Sub

    Private Sub ChangeButtonHomeStatus(ByVal val As String)
        Try
            Dim objRobotCtler As AVPLib.Business.RobotController = _
                CType(AVPLib.Business.ControllerManager.GetController(AVPLib.ConstEnum.Equipments.Robot.ToString()), _
                                          AVPLib.Business.RobotController)
            If val = "READY" Then
                If objRobotCtler.ActionCMDSent = True And objRobotCtler.IsManualAction = True Then
                    If Not m_bigcgButton.Enabled Then
                        m_bigcgButton.Enabled = True
                        ContainerForm.CassettesPanel.atwAutoTransferWafer.Enable_Disable_AllButton(True)
                    End If
                    objRobotCtler.ActionCMDSent = False
                    objRobotCtler.IsManualAction = False
                ElseIf ContainerForm.CassettesPanel.atwAutoTransferWafer.IsRobotGoToStation OrElse _
                ContainerForm.CassettesPanel.atwAutoTransferWafer.IsRobotChangeStatus Then
                    ''happen when click gotostation
                    ContainerForm.CassettesPanel.atwAutoTransferWafer.Enable_Disable_AllButton(True)
                    ContainerForm.CassettesPanel.atwAutoTransferWafer.IsRobotChangeStatus = False
                    ContainerForm.CassettesPanel.atwAutoTransferWafer.IsRobotGoToStation = False
                ElseIf ContainerForm.CassettesPanel.atwAutoTransferWafer.IsRobotPickPlaceAction Then
                    ContainerForm.CassettesPanel.atwAutoTransferWafer.Enable_Disable_AllButton(True)
                    ContainerForm.CassettesPanel.atwAutoTransferWafer.IsRobotPickPlaceAction = False
                    ContainerForm.CassettesPanel.atwAutoTransferWafer.btnPick.Status = DisplayStatus.Off
                    ContainerForm.CassettesPanel.atwAutoTransferWafer.btnPlace.Status = DisplayStatus.Off
                End If
            ElseIf val = "ERROR" Then
                'happen when Robot is not connected
            Else
                AVPLib.Log.avpLogger.Error("Invalid Robot Status: " + val)
            End If

            Dim rRobot As AVPLib.DataManagerment.Robot = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Robot.ToString())
            If rRobot IsNot Nothing Then
                Dim homeStatus As DisplayStatus = DisplayStatus.Off
                If rRobot.CurrentPosition = Positions.LoadLockA OrElse rRobot.CurrentPosition = Positions.Arm_At_LLA_Extract Then
                    homeStatus = DisplayStatus.On
                End If
                If m_bigcgButton.Status <> homeStatus Then
                    m_bigcgButton.Status = homeStatus
                End If
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub UpdateRobotArmStatus(ByVal val As String)
        Try
            '[Khoi Ha 05-02-2013]Ext/Re/Up/Down should be in yellow state  when robot is not communicating.
            Dim objRobot As AVPLib.DataManagerment.Robot = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Robot.ToString())
            If (objRobot IsNot Nothing AndAlso objRobot.IsCommunicating) Then
                Select Case val
                    Case AVPLib.ConstEnum.RobotArmStatus.UP.ToString()
                        ContainerForm.CassettesPanel.atwAutoTransferWafer.btnUPStatus.Status = DisplayStatus.On
                        ContainerForm.CassettesPanel.atwAutoTransferWafer.btnDNStatus.Status = DisplayStatus.Off
                    Case AVPLib.ConstEnum.RobotArmStatus.DN.ToString()
                        ContainerForm.CassettesPanel.atwAutoTransferWafer.btnUPStatus.Status = DisplayStatus.Off
                        ContainerForm.CassettesPanel.atwAutoTransferWafer.btnDNStatus.Status = DisplayStatus.On
                    Case Else
                        ContainerForm.CassettesPanel.atwAutoTransferWafer.btnUPStatus.Status = DisplayStatus.Unknow
                        ContainerForm.CassettesPanel.atwAutoTransferWafer.btnDNStatus.Status = DisplayStatus.Unknow
                        AVPLib.Log.avpLogger.Debug("Invalid Robot Arm Status: " + val)
                End Select
            Else
                ContainerForm.CassettesPanel.atwAutoTransferWafer.btnUPStatus.Status = DisplayStatus.Unknow
                ContainerForm.CassettesPanel.atwAutoTransferWafer.btnDNStatus.Status = DisplayStatus.Unknow
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Protected Overrides Sub UpdateUI(ByVal arg As Object)
        Try
            Dim Value As String = CType(arg, String)
            Dim objChamber As ChamberPanel = AVP_Robot_Project.ContainerForm.ChamberPanel(Me.Parent.Name)
            If Me.Name = "btnShutter" Then
                ChangeShutterStatus(Value)
                Exit Try
            End If
            If Me.Name = "btnUPStatus" Then
                UpdateRobotArmStatus(Value)
                Exit Try
            End If
            If Me.Name = "bicWaferInside" Then
                Utils.ChangeWaferStatusColor(Value, Me.Parent.Parent.Name)
                Exit Try
            End If
            If Me.Name = "btnHome" And Me.Parent.Name = "atwAutoTransferWafer" Then
                ChangeButtonHomeStatus(Value)
                Exit Try
            ElseIf Me.Name = "LLAIgStatus" Then
                ContainerForm.ProcessPanel.lpcLoadLockA.Enable_Disable_StartButton()
                Exit Try
            End If
            If Me.Name = "btnComStatus" AndAlso Me.Parent.Name = ConstantAndEnum.LOCKCASSETTEA Then
                ContainerForm.CassettesPanel.lccLoadLockA.CommStateChangeHandler(Value = STR_ON)
            End If
            If Me.Name = "HivacOpenButton" Then
                ContainerForm.CassettesPanel.TMCtl.ChangeHivacValveStatusTo(Utils.ConvertToDisplayStatus(Value))
                Exit Try
            End If
            Select Case Value
                Case STR_ON, Boolean.TrueString
                    If Me.Name = "btnRegen" Then
                        objChamber = ContainerForm.ChamberPanel(Me.Parent.Parent.Name)
                        If objChamber IsNot Nothing AndAlso objChamber.ChamberType = SystemModule.ModuleType.PVD Then
                            Dim eqChamber As DataManagerment.PVDChamber = _
                                    DataManagerment.EquipmentManager.GetEquipment(Me.Parent.Parent.Name)
                            If eqChamber.MachineCryoOn = Equipment.WorkingStatuses.On Then
                                CType(objChamber, PVDPanel).Cryo.btnRegen.Text = ConstEnum.STR_ON
                            Else
                                CType(objChamber, PVDPanel).Cryo.btnRegen.Text = "Regen"
                            End If
                        End If
                    End If
                    If Me.Name = "btnRecall" Or Me.Name = "btnStore" Then
                        m_bigcgButton.Enabled = False
                        Exit Sub
                    ElseIf Me.Name = "btnStart" Or Me.Name = "btnPause" Or Me.Name = "btnAbort" Then 'for Run Recipe
                        'Enable button Start in Run Recipe
                        m_bigcgButton.Enabled = Utils.IsAllowEnable(False)
                        Exit Sub
                    ElseIf Me.Name = "btnReConnect" Then
                        m_bigcgButton.Status = DisplayStatus.On
                        If objChamber IsNot Nothing Then
                            ''IBE
                            If objChamber.ChamberType = SystemModule.ModuleType.IBE Then
                                CType(objChamber, IBEPanel).lblDisconnect.Visible = False
                                ChangeStatusOfPM(Me.Parent.Name, EnumChamberState.IDLE.ToString())
                                CType(objChamber, IBEPanel).txtStatus.Text = EnumChamberState.IDLE.ToString()
                                ''PVD
                            ElseIf objChamber.ChamberType = SystemModule.ModuleType.PVD Then
                                CType(objChamber, PVDPanel).lblDisconnect.Visible = False
                                ChangeStatusOfPM(Me.Parent.Name, EnumChamberState.IDLE.ToString())
                                CType(objChamber, PVDPanel).ProcessMonitor.txtStatus.Text = EnumChamberState.IDLE.ToString()
                                ''PVD4
                            ElseIf objChamber.ChamberType = SystemModule.ModuleType.PVD4 Then
                                CType(objChamber, CoronaPanel).lblDisconnect.Visible = False
                                ChangeStatusOfPM(Me.Parent.Name, EnumChamberState.IDLE.ToString())
                                CType(objChamber, CoronaPanel).ProcessMonitor.txtStatus.Text = EnumChamberState.IDLE.ToString()
                                ''pvd5t
                            ElseIf objChamber.ChamberType = SystemModule.ModuleType.PVD5T Then
                                CType(objChamber, PVD5TPanel).lblDisconnect.Visible = False
                                ChangeStatusOfPM(Me.Parent.Name, EnumChamberState.IDLE.ToString())
                                CType(objChamber, PVD5TPanel).ProcessMonitor.txtStatus.Text = EnumChamberState.IDLE.ToString()
                            End If
                            Update_Disconnect(False)
                        End If
                    ElseIf Me.Name = BTN_AUTO_BEAM Then
                        m_bigcgButton.Text = DISABLE_AUTO_BEAM
                        'ElseIf Me.Name = "HivacCloseButton" Then
                        '    m_bigcgButton.Text = "HIVAC OPEN"
                    End If
                    If m_bigcgButton.Status = DisplayStatus.On Then
                        GoTo ENDFUNC
                    End If
                    m_bigcgButton.Status = DisplayStatus.On

                Case STR_OFF, Boolean.FalseString
                    If Me.Name = "btnRefresh" AndAlso Me.Parent.Name = ContainerForm.WaferRun.Name Then
                        ContainerForm.WaferRun.RefreshWaferRunListCallWhenComplete()
                    End If
                    If Me.Name = "btnRegen" Then
                        objChamber = ContainerForm.ChamberPanel(Me.Parent.Parent.Name)
                        If objChamber IsNot Nothing AndAlso objChamber.ChamberType = SystemModule.ModuleType.PVD Then
                            Dim objEQ As DataManagerment.PVDChamber = DataManagerment.EquipmentManager.GetEquipment(objChamber.Name)
                            If Not (objEQ.MachineCryoOn = Equipment.WorkingStatuses.On) And _
                            Not (objEQ.MachineCryoRegn = Equipment.WorkingStatuses.On) Then
                                CType(objChamber, PVDPanel).Cryo.btnRegen.Text = STR_OFF
                                m_bigcgButton.Status = DisplayStatus.Off
                                Exit Sub
                            Else
                                Exit Sub
                            End If
                        End If
                    End If
                    If Me.Name = "btnRecall" Or Me.Name = "btnStore" Then
                        objChamber = ContainerForm.ChamberPanel(Me.Parent.Parent.Name)
                        If objChamber IsNot Nothing Then
                            If Not (objChamber.ChamberType = SystemModule.ModuleType.IBE) Then
                                If CType(objChamber, PVDPanel).IsMaintenanceMode Then
                                    m_bigcgButton.Enabled = True And AVPLib.ContainerData.Permission(PERMISSION_001) And objChamber.IsEditable_InMaintenanceMode
                                Else
                                    m_bigcgButton.Enabled = True And AVPLib.ContainerData.Permission(PERMISSION_001)
                                End If
                            End If
                        End If
                        Exit Sub
                    ElseIf Me.Name = "btnStart" Or Me.Name = "btnPause" Or Me.Name = "btnAbort" Then 'for Run Recipe
                        m_bigcgButton.Enabled = False
                        Exit Sub
                    ElseIf Me.Name = "btnReConnect" Then
                        m_bigcgButton.Enabled = True
                        m_bigcgButton.Status = DisplayStatus.Error
                        'for PVD Bias, Target Match Box, PVD Online -> set Offline
                        If objChamber IsNot Nothing Then
                            If (objChamber.ChamberType = SystemModule.ModuleType.PVD) Then
                                RaiseOfflinePVDPanel(objChamber)
                                CType(objChamber, PVDPanel).lblDisconnect.Visible = True
                                CType(objChamber, PVDPanel).ProcessMonitor.txtStatus.Text = EnumChamberState.UNKNOWN.ToString()
                                ChangeStatusOfPM(Me.Parent.Name, EnumChamberState.UNKNOWN.ToString())
                            ElseIf objChamber.ChamberType = SystemModule.ModuleType.PVD4 Then
                                CType(objChamber, CoronaPanel).lblDisconnect.Visible = True
                                ChangeStatusOfPM(Me.Parent.Name, EnumChamberState.UNKNOWN.ToString())
                            ElseIf objChamber.ChamberType = SystemModule.ModuleType.PVD5T Then
                                CType(objChamber, PVD5TPanel).lblDisconnect.Visible = True
                                ChangeStatusOfPM(Me.Parent.Name, EnumChamberState.UNKNOWN.ToString())
                            Else
                                CType(objChamber, IBEPanel).lblDisconnect.Visible = True
                            End If
                            Update_Disconnect(True)
                        End If

                    ElseIf Me.Name = BTN_AUTO_BEAM Then
                        m_bigcgButton.Text = ENABLE_AUTO_BEAM
                    End If

                    If m_bigcgButton.Status = DisplayStatus.Off Then
                        GoTo ENDFUNC
                    End If
                    m_bigcgButton.Status = DisplayStatus.Off

                Case Else
                    If Me.Name = "btnRegen" Then
                        objChamber = ContainerForm.ChamberPanel(Me.Parent.Parent.Name)
                        If objChamber IsNot Nothing AndAlso objChamber.ChamberType = SystemModule.ModuleType.PVD Then
                            Dim objEQ As DataManagerment.PVDChamber = DataManagerment.EquipmentManager.GetEquipment(objChamber.Name)
                            If Not (objEQ.MachineCryoOn = Equipment.WorkingStatuses.On) And _
                              Not (objEQ.MachineCryoRegn = Equipment.WorkingStatuses.On) Then
                                CType(objChamber, PVDPanel).Cryo.btnRegen.Text = String.Empty
                                m_bigcgButton.Status = DisplayStatus.Off
                                Exit Sub
                            End If
                        End If
                    ElseIf Me.Name = "bicTurboPump" Then
                        m_bigcgButton.Status = DisplayStatus.Unknow
                    ElseIf Me.Name = "HeaderStatus" AndAlso Me.Parent.Name.Contains("lpcLoadLock") Then
                        If Value = "Cycling" Then
                            m_bigcgButton.ForeColor = Color.Red
                            m_bigcgButton.Text = m_bigcgButton.Tag & Value
                        ElseIf Value = "UnCycling" Then
                            m_bigcgButton.ForeColor = Color.White
                            m_bigcgButton.Text = m_bigcgButton.Tag
                        End If
                    ElseIf Me.Name = "btnStart" Then
                        UpdateButton_BaseOn_ButtonStart(Value)
                    ElseIf Me.Name = "btnPause" Then
                        UpdateButton_BaseOn_ButtonPause(Value)
                    ElseIf Me.Name = "Header" Then
                        Select Case Value
                            Case "-1"
                                m_bigcgButton.Status = DisplayStatus.Error
                                'for case Chamber/LoadLock Online -> change status of Chamber/LoadLock in Process Screen
                            Case UCase(STRING_ONLINE)
                                m_bigcgButton.Status = DisplayStatus.On
                                If Me.Parent.Name.Contains("cbcChamber") Then
                                    m_bigcgButton.Text = GetTitleOfHeader() & "-" & STRING_ONLINE
                                End If
                            Case UCase(STRING_OFFLINE)
                                m_bigcgButton.Status = DisplayStatus.Off
                                If Me.Parent.Name.Contains("cbcChamber") Then
                                    m_bigcgButton.Text = GetTitleOfHeader() & "-" & STRING_OFFLINE
                                End If
                            Case UCase(STRING_MAINTENANCE)
                                m_bigcgButton.Status = DisplayStatus.Error
                                If Me.Parent.Name.Contains("cbcChamber") Then
                                    m_bigcgButton.Text = GetTitleOfHeader() & "-" & STRING_MAINTENANCE
                                End If
                        End Select
                    ElseIf Me.Name = "btnHivacValve" Then
                        Dim iRes As Double = 0
                        If (Double.TryParse(Value, iRes)) Then
                            If m_bigcgButton.Status = DisplayStatus.Unknow Then
                                m_bigcgButton.Text = Math.Round(iRes, 1) '.ToString("0.0")
                            End If
                        Else
                            m_bigcgButton.Status = DisplayStatus.Unknow
                        End If
                    ElseIf Me.Name = "btnRegen" Then
                        m_bigcgButton.Status = DisplayStatus.Unknow
                    ElseIf Me.Name = "btnShutter" Then
                        m_bigcgButton.Status = DisplayStatus.Unknow
                    End If
            End Select
ENDFUNC:
            If Me.Name = "bicPlasmaOn" Then
                Dim PlasmaOn As Boolean = IIf(Value = STR_ON, True, False)
                Dim panelObj As PVDPanel = ContainerForm.ChamberPanel(Me.Parent.Parent.Name)
                If panelObj IsNot Nothing AndAlso Not panelObj.ChuckControl.bicPlasmaOn.Tag.ToString() = PlasmaOn.ToString() Then
                    panelObj.ChuckControl.bicPlasmaOn.Tag = PlasmaOn.ToString()
                    panelObj.ChuckControl.bicPlasmaOn.Visible = PlasmaOn
                    Utils.ChangeBiasPlasmaControlStatus(Me.Parent.Parent.Name, PlasmaOn)
                End If
            End If
            If Me.Parent.Name = "usrStatusPanel" Then
                If Me.Name = "btnMotionInitialized" Then
                    If Value = "Other" Then
                        m_bigcgButton.Status = DisplayStatus.Off
                    End If
                End If
                If Value = UNKNOWN Then
                    m_bigcgButton.Status = DisplayStatus.Error
                End If
            End If

            'change textbox of IG base on IG status
            If Not IsNumeric(Value) Then
                If Me.Parent.Name = "TMCtl" Then
                    ' Update in IGCGStatusTextBox

                ElseIf (Me.Parent.Name = "Baratron" And Me.Name = "bigcgIG") Then 'update screen pvd chamber
                    Dim chamberObj As PVDPanel = ContainerForm.ChamberPanel(Me.Parent.Parent.Name)
                    If chamberObj IsNot Nothing AndAlso (UCase(Value) = UCase(STR_OFF)) Then
                        chamberObj.Baratron.txtIG.Text = UCase(STR_OFF)
                    End If
                End If
                Exit Sub
            End If

            If Value <> STR_ON And Value <> STR_OFF Then
                ' m_bigcgButton.Status = DisplayStatus.On
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub


#Region "Update Run Recipe Control"
    Private Sub UpdateButton_BaseOn_ButtonPause(ByVal value As String)
        Dim chamberObj As ChamberPanel = ContainerForm.ChamberPanel(Me.Parent.Parent.Name)
        If value = AVPLib.ConfigurationValues.DEVICE_STATUS_PAUSE Then
            m_bigcgButton.Text = "Pause"
            If chamberObj.RunRecipe.Real_Device_Enable Then
                chamberObj.RunRecipe.btnPauseRealDevice.Enabled = False
                chamberObj.RunRecipe.IsWaitResumeProcess = False
            End If
        ElseIf value = AVPLib.ConfigurationValues.DEVICE_STATUS_RESUMING Then
            m_bigcgButton.Text = "Resume"
            chamberObj.RunRecipe.btnStart.Text = "Stop"
            If chamberObj.RunRecipe.Real_Device_Enable Then
                If (chamberObj.IsOnline = False And AVPLib.ContainerData.Permission(PERMISSION_001)) Then 'not online and have permission
                    chamberObj.RunRecipe.btnPauseRealDevice.Enabled = IIf(chamberObj.IsMaintenanceMode, chamberObj.IsEditable_InMaintenanceMode And Utils.IsPauseResumeProcessActive(Me.Parent.Parent.Name), _
                                                                      True And Utils.IsPauseResumeProcessActive(Me.Parent.Parent.Name))
                End If
                chamberObj.RunRecipe.IsWaitResumeProcess = True
            End If
        End If
        If (chamberObj.IsOnline = False And AVPLib.ContainerData.Permission(PERMISSION_001)) Then 'not online and have permission
            m_bigcgButton.Enabled = IIf(chamberObj.IsMaintenanceMode, chamberObj.IsEditable_InMaintenanceMode, True)
            chamberObj.RunRecipe.btnStart.Enabled = IIf(chamberObj.IsMaintenanceMode, chamberObj.IsEditable_InMaintenanceMode, True)
            chamberObj.RunRecipe.btnAbort.Enabled = IIf(chamberObj.IsMaintenanceMode, chamberObj.IsEditable_InMaintenanceMode And Utils.IsEndCurrentStepActive(Me.Parent.Parent.Name), _
                                                    True And Utils.IsEndCurrentStepActive(Me.Parent.Parent.Name))
        End If
    End Sub

    Private Sub UpdateButton_BaseOn_ButtonStart(ByVal value As String)
        Dim chamberObj As ChamberPanel = ContainerForm.ChamberPanel(Me.Parent.Parent.Name)
        chamberObj.RunRecipe.btnPause.Text = "Pause"
        If value = AVPLib.ConfigurationValues.DEVICE_STATUS_OPEN Then
            '#04/28/2011 
            '#All SP flash when run schedular.
            '#Begin fix: just reset all SP text to empty at the first time when start schedular.
            If chamberObj.ChamberType = SystemModule.ModuleType.PVD Then
                If m_bigcgButton.Text <> "Stop" Then
                    CType(chamberObj, PVDPanel).OnStartProcessing() ''reset editbox to empty
                End If
            End If
            '2013-04-15 Tin Pham: Need to change to “Stopping” when process is stopping.
            If m_bigcgButton.Text <> "Stopping" Then
                m_bigcgButton.Text = "Stop"
            End If
            '---------------------------------------------------------------------------
            If (chamberObj.IsOnline = False And AVPLib.ContainerData.Permission(PERMISSION_001)) Then 'not online and have permission
                chamberObj.RunRecipe.btnPause.Enabled = IIf(chamberObj.IsMaintenanceMode, chamberObj.IsEditable_InMaintenanceMode And Utils.IsEndCurrentStepActive(Me.Parent.Parent.Name), _
                                                           True And Utils.IsPauseResumeProcessActive(Me.Parent.Parent.Name))
                chamberObj.RunRecipe.btnAbort.Enabled = IIf(chamberObj.IsMaintenanceMode, chamberObj.IsEditable_InMaintenanceMode And _
                                                            Utils.IsEndCurrentStepActive(Me.Parent.Parent.Name) And m_bigcgButton.Text <> "Stopping", _
                                                           True And Utils.IsEndCurrentStepActive(Me.Parent.Parent.Name) And m_bigcgButton.Text <> "Stopping")
            End If
            '#End fix.
        ElseIf value = AVPLib.ConfigurationValues.DEVICE_STATUS_CLOSED Then
            m_bigcgButton.Text = "Start"
            chamberObj.RunRecipe.btnPause.Enabled = False
            chamberObj.RunRecipe.btnAbort.Enabled = False
        End If
        If chamberObj.RunRecipe.Real_Device_Enable Then
            chamberObj.RunRecipe.btnPauseRealDevice.Enabled = False
            chamberObj.RunRecipe.IsWaitResumeProcess = False
        End If
        If (chamberObj.IsOnline = False And AVPLib.ContainerData.Permission(PERMISSION_001)) Then 'not online and have permission
            m_bigcgButton.Enabled = IIf(chamberObj.IsMaintenanceMode, chamberObj.IsEditable_InMaintenanceMode, True)
        End If
    End Sub
#End Region
  ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2008-09-09</date>
    ''' </author>
    ''' <summary>
    ''' Update Disconnect to Cassette
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Sub Update_Disconnect(ByVal blnDisconnect As Boolean)
#If AVP_PLATFORM = "CX" Then
        Dim strDisconnect As String = "Disconnected"
        If Me.Parent.Name.Contains(Equipments.Chamber1.ToString()) And blnDisconnect Then
            ContainerForm.CassettesPanel.CX_PM1.Show_Disconnected = True
            ContainerForm.CassettesPanel.CX_PM1.Refresh()
            ContainerForm.CassettesPanel.IgcgChamber1.HeaderStatus = DisplayStatus.Off
            ContainerForm.CassettesPanel.MesaValvePM1.Refresh() ''Update to refresh Disconnect
            AVPRobotMain.pnlPMConnection.btnConnectPM1.Status = DisplayStatus.Off
        ElseIf Me.Parent.Name.Contains(Equipments.Chamber1.ToString()) And blnDisconnect = False Then
            ContainerForm.CassettesPanel.CX_PM1.Show_Disconnected = False
            ContainerForm.CassettesPanel.IgcgChamber1.HeaderStatus = DisplayStatus.On
            AVPRobotMain.pnlPMConnection.btnConnectPM1.Status = DisplayStatus.On
            ContainerForm.CassettesPanel.CX_PM1.Refresh()
        End If

        If Me.Parent.Name.Contains(Equipments.Chamber2.ToString()) And blnDisconnect Then
            ContainerForm.CassettesPanel.CX_PM2.Show_Disconnected = True
            ContainerForm.CassettesPanel.IgcgChamber2.HeaderStatus = DisplayStatus.Off
            ContainerForm.CassettesPanel.MesaValvePM2.Refresh()
            AVPRobotMain.pnlPMConnection.btnConnectPM2.Status = DisplayStatus.Off
            ContainerForm.CassettesPanel.CX_PM2.Refresh()
        ElseIf Me.Parent.Name.Contains(Equipments.Chamber2.ToString()) And blnDisconnect = False Then
            ContainerForm.CassettesPanel.CX_PM2.Show_Disconnected = False
            ContainerForm.CassettesPanel.IgcgChamber2.HeaderStatus = DisplayStatus.On
            AVPRobotMain.pnlPMConnection.btnConnectPM2.Status = DisplayStatus.On
            ContainerForm.CassettesPanel.CX_PM2.Refresh()
        End If

        If Me.Parent.Name.Contains(Equipments.Chamber3.ToString()) And blnDisconnect Then
            ContainerForm.CassettesPanel.CX_PM3.Show_Disconnected = True
            ContainerForm.CassettesPanel.IgcgChamber3.HeaderStatus = DisplayStatus.Off
            'ContainerForm.CassettesPanel.picChamber3.Refresh()
            ContainerForm.CassettesPanel.MesaValvePM3.Refresh()
            AVPRobotMain.pnlPMConnection.btnConnectPM3.Status = DisplayStatus.Off
            ContainerForm.CassettesPanel.CX_PM3.Refresh()
        ElseIf Me.Parent.Name.Contains(Equipments.Chamber3.ToString()) And blnDisconnect = False Then
            ContainerForm.CassettesPanel.CX_PM3.Show_Disconnected = False
            ContainerForm.CassettesPanel.IgcgChamber3.HeaderStatus = DisplayStatus.On
            AVPRobotMain.pnlPMConnection.btnConnectPM3.Status = DisplayStatus.On
            ContainerForm.CassettesPanel.CX_PM3.Refresh()
        End If
#End If
    End Sub
    Private Function GetTitleOfHeader() As String
        Dim sTag As String = String.Empty
        Try
            Select Case Me.Parent.Name
                Case "cbcChamber1" 'get status button from CassettesPanel to display value
                    sTag = ContainerForm.ProcessPanel.cbcChamber1.Tag
                Case "cbcChamber2"
                    sTag = ContainerForm.ProcessPanel.cbcChamber2.Tag
                Case "cbcChamber3"
                    sTag = ContainerForm.ProcessPanel.cbcChamber3.Tag
            End Select
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return sTag
    End Function
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''     <date> 2009-01-11</date>
    ''' </author>
    ''' <summary>
    ''' Raise Bias Match Box, Target Power...in PVD Panel Offline when PVD is disconnnect
    ''' </summary>
    ''' <param name="Identification"></param>
    ''' <param name="Value"></param>
    ''' <remarks></remarks>
    Private Sub RaiseOfflinePVDPanel(ByVal objPanel As ChamberPanel)
        AVPLib.Log.guiLogger.Info("Enter RaiseOfflinePVDPanel")
        Try
            Dim arrPropertyNames As New ArrayList()
            Dim arrValues As New ArrayList()
            Dim objPvdPanel As PVDPanel = CType(objPanel, PVDPanel)
            If objPvdPanel.DCTargetPowerSupplyVisible Then
                arrPropertyNames.Add("DCTargetPowerSupply_CommunicationStatus")
                arrValues.Add(Equipment.WorkingStatuses.Off)
            ElseIf objPvdPanel.RFTargetPowerSupplyVisible Then
                arrPropertyNames.Add("RFTargetPowerSupply_CommunicationStatus")
                arrValues.Add(Equipment.WorkingStatuses.Off)
            End If
            arrPropertyNames.Add("VatValve_CommunicationStatus")
            arrPropertyNames.Add("BiasPowerSupply_CommunicationStatus")
            arrValues.Add(Equipment.WorkingStatuses.Off)
            arrValues.Add(Equipment.WorkingStatuses.Off)
            If objPvdPanel.CryoControlVisible Then
                arrPropertyNames.Add("Cryo_CommunicationStatus")
                arrValues.Add(Equipment.WorkingStatuses.Off)
            End If
            EquipmentManager.ChangeStatus(objPanel.Name, arrPropertyNames, arrValues)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave RaiseOfflinePVDPanel")
    End Sub

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''     <date> 2009-01-11</date>
    ''' </author>
    ''' <summary>
    ''' This procedure overrides to change satus of an object
    ''' </summary>
    ''' <param name="Identification"></param>
    ''' <param name="Value"></param>
    ''' <remarks></remarks>
    'Private Sub ChangeForeColor(ByVal colorbutton As Color)
    '    AVPLib.Log.guiLogger.Info("Enter ChangeForeColor")
    '    ' m_bigcgButton.ForeColor = colorbutton
    '    AVPLib.Log.guiLogger.Info("Leave ChangeForeColor")
    'End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''     <date> 2008-09-04</date>
    ''' </author>
    ''' <summary>
    ''' This procedure overrides to change satus of an object
    ''' </summary>
    ''' <param name="Identification"></param>
    ''' <param name="Value"></param>
    ''' <remarks></remarks>
    Public Overrides Sub ChangeStatus(ByVal Identification As String, ByVal Value As String)
        AVPLib.Log.guiLogger.Info("Enter ChangeStatus")
        AVPLib.Log.guiLogger.Debug("Identification=" + Identification)
        m_marshaller.Invoke(Of String)(New Threading.SendOrPostCallback(AddressOf UpdateUI), Value)
        AVPLib.Log.guiLogger.Info("Leave ChangeStatus")
    End Sub
    ''' <author>
    '''     	<name> Ngo Cao Dinh </name>
    '''     	<date> 2008-08-21</date>
    ''' </author>
    ''' <summary>
    ''' This procedure overrides to request status of an object
    ''' </summary>
    ''' <param name="Identification"></param>
    ''' <param name="Value"></param>
    ''' <remarks></remarks>
    Public Overrides Sub RequestStatus(ByVal Identification As String, ByVal Value As String)

    End Sub
#End Region
End Class