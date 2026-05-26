Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Imports AVPLib
Imports AVPControls
Imports AVPLib.Driver
Imports AVPLib.Driver.DriverConst

Public Class SystemSetup
    Private Const REQUEST_TIMEOUT As Integer = 15
    Private Const MAX_INPUT As Integer = 50000
    Const N_A As String = "(N/A)"
    Const n_a_ As String = "n/a"
    Const IBEType As String = "(IBE)"
    Const min As String = "(min)"
    Const PVDType As String = "(PVD)"
    Const kwh As String = "(kwh)"
    Const CORONAType As String = "(PVD4)"
    Const PVD5TType As String = "(PVD5T)"
    Const STR_LLA_ELEVATOR As String = "LLA Elevator"
    Private m_iTransferSetPointTextChanged As Integer = 0
    Private m_iVentSetPointTextChanged As Integer = 0
    Private m_iCrossOverSetPointTextChanged As Integer = 0
    Private m_iSlowRoughSetPointTextChanged As Integer = 0
    Private m_iSlowVentSetPointTextChanged As Integer = 0
    Private m_PM1TargetPSConfigPopUpPanel As SystemSetupPopUpPanel
    Private m_PM2TargetPSConfigPopUpPanel As SystemSetupPopUpPanel
    Private m_PM3TargetPSConfigPopUpPanel As SystemSetupPopUpPanel
    Private m_PM1ShieldsQuartzPopUpPanel As SystemSetupShieldQuartz
    Private m_PM2ShieldsQuartzPopUpPanel As SystemSetupShieldQuartz
    Private m_PM3ShieldsQuartzPopUpPanel As SystemSetupShieldQuartz
    Private m_PM1ChamberType As AVPLib.SystemModule.ModuleType = SystemModule.ModuleType.IBE
    Private m_PM2ChamberType As AVPLib.SystemModule.ModuleType = SystemModule.ModuleType.IBE
    Private m_PM3ChamberType As AVPLib.SystemModule.ModuleType = SystemModule.ModuleType.IBE

    'Email function
    Const COL_CHECKED_EMAIL As String = "CheckedEmail"
    Const COL_EMAILNAME As String = "Emails"
    Const COL_ALARM As String = "Alarm"
    Const COL_PRESSURE As String = "Pressure"
    Const COL_SCHEDULER As String = "Scheduler"
    Const COL_EDITNAME As String = "Edit"
    Const COL_REMOVENAME As String = "Remove"
    Const MAX_COLUMN_CHECKBOX As Integer = 2
    Const COL_EDIT_POSITION As Integer = 5
    Const COL_REMOVE_POSITION As Integer = 6

    Private m_dtEmailData As DataTable
    Private m_IsStartTestingSetup As Boolean = False

    ' Varible use for log, store text of textbox before changed in form
    Private m_mapValueChanged As New Hashtable

    ' Elevator/Robot Setting
    Private m_storedConfigLLA As New List(Of StoredConfigData)
    Private m_storedConfigRobot As New List(Of StoredConfigData)
    Private m_timerRequestData As System.Timers.Timer
    Private m_requestTime As Integer
    Private Delegate Sub UpdateGUIDelegate()

#Region "Properties"
    Public ReadOnly Property PM1TargetPSConfigPopUpPanel() As SystemSetupPopUpPanel
        Get
            If m_PM1TargetPSConfigPopUpPanel Is Nothing Then
                m_PM1TargetPSConfigPopUpPanel = New SystemSetupPopUpPanel
                m_PM1TargetPSConfigPopUpPanel.Name = "SystemSetupPopUpPanel"
                m_PM1TargetPSConfigPopUpPanel.StartPosition = FormStartPosition.CenterScreen
                m_PM1TargetPSConfigPopUpPanel.ShowInTaskbar = False
                m_PM1TargetPSConfigPopUpPanel.ShowIcon = False
                m_PM1TargetPSConfigPopUpPanel.Text = "System Setup for Target Power PM1"
                m_PM1TargetPSConfigPopUpPanel.Hide()
                m_PM1TargetPSConfigPopUpPanel.ChamberName = ConstEnum.Equipments.Chamber1.ToString()
            End If
            Return m_PM1TargetPSConfigPopUpPanel
        End Get
    End Property

    Public ReadOnly Property PM2TargetPSConfigPopUpPanel() As SystemSetupPopUpPanel
        Get
            If m_PM2TargetPSConfigPopUpPanel Is Nothing Then
                m_PM2TargetPSConfigPopUpPanel = New SystemSetupPopUpPanel
                m_PM2TargetPSConfigPopUpPanel.Name = "SystemSetupPopUpPanel"
                m_PM2TargetPSConfigPopUpPanel.StartPosition = FormStartPosition.CenterScreen
                m_PM2TargetPSConfigPopUpPanel.ShowInTaskbar = False
                m_PM2TargetPSConfigPopUpPanel.ShowIcon = False
                m_PM2TargetPSConfigPopUpPanel.Text = "System Setup for Target Power PM2"
                m_PM2TargetPSConfigPopUpPanel.Hide()
                m_PM2TargetPSConfigPopUpPanel.ChamberName = ConstEnum.Equipments.Chamber2.ToString()
            End If
            Return m_PM2TargetPSConfigPopUpPanel
        End Get
    End Property

    Public ReadOnly Property PM3TargetPSConfigPopUpPanel() As SystemSetupPopUpPanel
        Get
            If m_PM3TargetPSConfigPopUpPanel Is Nothing Then
                m_PM3TargetPSConfigPopUpPanel = New SystemSetupPopUpPanel
                m_PM3TargetPSConfigPopUpPanel.Name = "SystemSetupPopUpPanel"
                m_PM3TargetPSConfigPopUpPanel.StartPosition = FormStartPosition.CenterScreen
                m_PM3TargetPSConfigPopUpPanel.ShowInTaskbar = False
                m_PM3TargetPSConfigPopUpPanel.ShowIcon = False
                m_PM3TargetPSConfigPopUpPanel.Text = "System Setup for Target Power PM3"
                m_PM3TargetPSConfigPopUpPanel.Hide()
                m_PM3TargetPSConfigPopUpPanel.ChamberName = ConstEnum.Equipments.Chamber3.ToString()
            End If
            Return m_PM3TargetPSConfigPopUpPanel
        End Get
    End Property

    Public ReadOnly Property PM1ShieldsQuartzPopUpPanel() As SystemSetupShieldQuartz
        Get
            CreateShieldsQuartzPopUpPanel(m_PM1ShieldsQuartzPopUpPanel, 1, m_PM1ChamberType)
            Return m_PM1ShieldsQuartzPopUpPanel
        End Get
    End Property

    Public ReadOnly Property PM2ShieldsQuartzPopUpPanel() As SystemSetupShieldQuartz
        Get
            CreateShieldsQuartzPopUpPanel(m_PM2ShieldsQuartzPopUpPanel, 2, m_PM2ChamberType)
            Return m_PM2ShieldsQuartzPopUpPanel
        End Get
    End Property

    Public ReadOnly Property PM3ShieldsQuartzPopUpPanel() As SystemSetupShieldQuartz
        Get
            CreateShieldsQuartzPopUpPanel(m_PM3ShieldsQuartzPopUpPanel, 3, m_PM3ChamberType)
            Return m_PM3ShieldsQuartzPopUpPanel
        End Get
    End Property

    Public Property PM1ChamberType() As AVPLib.SystemModule.ModuleType
        Get
            Return m_PM1ChamberType
        End Get
        Set(ByVal value As AVPLib.SystemModule.ModuleType)
            m_PM1ChamberType = value
        End Set
    End Property

    Public Property PM2ChamberType() As AVPLib.SystemModule.ModuleType
        Get
            Return m_PM2ChamberType
        End Get
        Set(ByVal value As AVPLib.SystemModule.ModuleType)
            m_PM2ChamberType = value
        End Set
    End Property

    Public Property PM3ChamberType() As AVPLib.SystemModule.ModuleType
        Get
            Return m_PM3ChamberType
        End Get
        Set(ByVal value As AVPLib.SystemModule.ModuleType)
            m_PM3ChamberType = value
        End Set
    End Property

    Public Property TransferSetPointTextChanged() As Integer
        Get
            Return m_iTransferSetPointTextChanged
        End Get
        Set(ByVal value As Integer)
            m_iTransferSetPointTextChanged = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2015-08-19 </date>
    ''' </author>
    Public Property IsStartTestingSetup() As Boolean
        Get
            Return m_IsStartTestingSetup
        End Get
        Set(ByVal value As Boolean)
            m_IsStartTestingSetup = value
        End Set
    End Property
#End Region

#Region "Load Form"
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
            m_stoStatusObject.Name = Me.Name
            Dim stRobotVersion As StatusTextBox = New StatusTextBox(txtRobotVersion)

            m_stoStatusObject.AddChild(stRobotVersion)

            Dim stRobotstatus As StatusTextBox = New StatusTextBox(txtApplyStatus)
            m_stoStatusObject.AddChild(stRobotstatus)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Sub New()
        m_iTransferSetPointTextChanged = 0
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        'default for CX4
        If (RobotConfigurationValues.LLA_CRYO_VISIBLE = False AndAlso _
        RobotConfigurationValues.TMCRYO_VISIBLE = False) Then
            gbxRegenHourLimit.Visible = False
        End If

        'Disable when no aligner installed
        If RobotConfigurationValues.ALINER_VISIBLE = False Then
            cbxAllowCheckingECCLimit.Enabled = False
            txtDeltaPickECCLimits.Enabled = False
        End If

        SetSlowVentAndRoughVisible()
        RobotConfig.EnableEdit(True)
        RobotConfig.SetBackColor()


        ' Add any initialization after the InitializeComponent() call.
        m_timerRequestData = New System.Timers.Timer(1000)
        m_timerRequestData.Enabled = False
        AddHandler m_timerRequestData.Elapsed, AddressOf TimerRequestData_Tick
        AddHandler RobotConfig.ConfigRobot_Click, AddressOf ConfigRobot_Click
    End Sub

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-12-10</date>
    ''' </author>
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SystemSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.ClearForm()
            Me.LoadPolling()
            '
            Me.LoadPressureSetpoint()
            Me.LoadTimeOut()
            Me.LoadLLElevatorConfig()
            Me.LoadMailSetting()
            Me.SetElevatorSettingEnable(False)

            LoadWaferCount()
            LoadLifeTimeWafer()
            LoadGeneralSystemSetting()
            LoadAutoArchiveConfig()
            LoadModuleName()

            If AVPLib.RobotConfigurationValues.ROBOT_SENSOR_INSTALLED = False Then
                AVPLib.RobotConfigurationValues.DISABLE_SENSOR_CHECKING = True
            End If

            If rbUseAbsoluteKWH.Checked Then
                DisableAllMaxLimits()
                rbUseMaxKWH.Visible = False
            Else
                EnableAllMaxLimits()
                rbUseAbsoluteKWH.Visible = False
            End If
            cbAutoVentWhenProcessCompleted.Checked = AVPLib.ContainerDAO.AutoVentWhenProcessingConpleted()
            txtDelayTimeAfterProcessComplete.Text = AVPLib.ContainerDAO.DelayTimeAfterProcessComplete()

            Me.UpdateRobotConfigPanel()
            Me.LoadStoredConfig()

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub LoadWaferCount()
        Try
            Dim objChamber As AVPLib.DataManagerment.Chamber = Nothing
            objChamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(Equipments.Chamber1.ToString())
            If objChamber IsNot Nothing Then
                txtWaferCountPM1.Text = IIf(objChamber Is Nothing, 0, objChamber.PM_WaferCount)
            End If

            objChamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(Equipments.Chamber2.ToString())
            If objChamber IsNot Nothing Then
                txtWaferCountPM2.Text = IIf(objChamber Is Nothing, 0, objChamber.PM_WaferCount)
            End If

            objChamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(Equipments.Chamber3.ToString())
            If objChamber IsNot Nothing Then
                txtWaferCountPM3.Text = IIf(objChamber Is Nothing, 0, objChamber.PM_WaferCount)
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub LoadGeneralSystemSetting()
        Try
            cbxManualDefineGEMWaferID.Checked = AVPLib.RobotConfigurationValues.SUPPORT_MANUAL_DEFINE_GEM_WAFERID
            cbxAllowCheckingECCLimit.Checked = AVPLib.RobotConfigurationValues.ALLOW_CHECKING_ECC_LIMIT
            txtDeltaPickECCLimits.Text = AVPLib.RobotConfigurationValues.ECC_M_LIMIT.ToString()
            cbxEnableQuickSequenceEditor.Checked = AVPLib.ContainerDAO.ReadEnableQuickSequenceEditor()
            txtInfoName.Text = AVPLib.ContainerData.ToolID
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Hoai Ly </name>
    '''    	<date> 2015-06-11</date>
    ''' </author>
    ''' <summary>
    ''' Load Module Name
    ''' </summary>
    Private Sub LoadModuleName()
        Try
            Me.grboxModuleName.Controls.Clear()

            Me.grboxModuleName.Controls.Add(Me.txtModuleNamePM1)
            Me.grboxModuleName.Controls.Add(Me.txtModuleNamePM2)
            Me.grboxModuleName.Controls.Add(Me.txtModuleNamePM3)

            For i As Integer = 1 To AVPRobotMain.MaxChamber2Install
                Dim strChamber As String = ConstEnum.Chamber & i.ToString()
                Dim objChamber As AVPLib.DataManagerment.Chamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(strChamber)
                If objChamber IsNot Nothing Then
                    CType(grboxModuleName.Controls(i - 1), TextBox).Text = objChamber.GEMModuleName
                Else
                    CType(grboxModuleName.Controls(i - 1), TextBox).Enabled = False
                End If
            Next

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error("LoadModuleName" & ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Hoai Ly </name>
    '''    	<date> 2015-06-11</date>
    ''' </author>
    ''' <summary>
    ''' LoadAutoArchiveConfig
    ''' </summary>
    Private Sub LoadAutoArchiveConfig()
        Try
            cbAutoArchiveSystemConfigFile.Checked = AVPLib.ContainerDAO.AutoArchiveSystemConfigFile()
            txtArchiveConfigFile.Text = AVPLib.ContainerDAO.GetFolderSystemConfig()
            txtSystemCleanUpDataRunTimeInDays.Text = AVPLib.ContainerData.SystemCleanUpDataRunTime()

            Dim strDateTime As String = AVPLib.ContainerDAO.GetAutoArchiveStatusValue(ConstEnum.XPATH_AUTO_ARCHIVE_DATE_TIME)
            If Not String.IsNullOrEmpty(strDateTime) Then
                Dim strStatus As String = IIf(AVPLib.ContainerDAO.GetAutoArchiveStatusValue(ConstEnum.XPATH_AUTO_ARCHIVE_STATUS) = "True", "successful", "failed")
                Dim strResult As String = "The latest bakup was "
                lblAutoArchiveStatus.Text = strResult + strStatus + " on " + strDateTime
            Else
                lblAutoArchiveStatus.Text = String.Empty
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error("LoadAutoArchiveConfig" & ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-12-10</date>
    ''' </author>
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadPolling()
        Try
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub LoadTimeOut()
        Try
            Dim objConfig As AVPLib.SystemModule = Nothing
            objConfig = AVPLib.ContainerData.GetRobotConfig(LoadLockA_STR)

            If objConfig IsNot Nothing Then
                txtDegasWaitTimeLLA.Text = AVPLib.RobotConfigurationValues.LLA_IGDEGAS_WAIT_TIME_IN_SECONDS
            End If

            txtDegasWaitTimeTM.Text = AVPLib.RobotConfigurationValues.TM_IGDEGAS_WAIT_TIME_IN_SECONDS
            txtMesaValveTO.Text = (AVPLib.ContainerData.GetPumpdownLL(LL_MESA_VALVE_OPEN_CLOSE_TIMEOUT)).ToString()
            txtIGOnOffTO.Text = (AVPLib.ContainerData.GetPumpdownLL(IG_ON_OFF_TIMEOUT)).ToString()
            txtHivacTO.Text = (AVPLib.ContainerData.GetPumpdownLL(LL_HIVAC_OPEN_CLOSE_TIMEOUT)).ToString()
            txtSystemCheckSensor.Text = (AVPLib.ContainerDAO.GetSystemWaitForCheckSensor()).ToString()
            txtLLASlowRoughTO.Text = (AVPLib.ContainerData.GetPumpdownLL(LLA_SLOW_ROUGH_PRESSURE_TIMEOUT)).ToString()
            txtLLAFastRoughTO.Text = (AVPLib.ContainerData.GetPumpdownLL(LLA_FAST_ROUGH_PRESSURE_TIMEOUT)).ToString()
            txtLLRoughValveTO.Text = (AVPLib.ContainerData.GetPumpdownLL(LL_ROUGH_VALVE_OPEN_CLOSE_TIMEOUT)).ToString()
            txtLLContinuePumpDown.Text = (AVPLib.ContainerData.GetPumpdownLL(LL_PUMPDOWN_DELAY_TIME)).ToString()
            txtLLDelayTimeTurnOnIG.Text = (AVPLib.ContainerData.GetPumpdownLL(IG_ON_DELAY)).ToString()
            txtLLASlowVentTO.Text = (AVPLib.ContainerData.GetVentLL(LLA_SLOW_VENT_TIMEOUT)).ToString()
            txtLLAFastVentTO.Text = (AVPLib.ContainerData.GetVentLL(LLA_FAST_VENT_TIMEOUT)).ToString()
            txtLLVentValveTO.Text = (AVPLib.ContainerData.GetVentLL(LL_VENT_VALVE_OPEN_CLOSE_TIMEOUT)).ToString()
            txtLLContinueVent.Text = (AVPLib.ContainerData.GetVentLL(LL_VENT_DELAY_TIME)).ToString()
            txtTMRoughTO.Text = (AVPLib.ContainerData.GetPumpdownTM(TM_ROUGH_TIMEOUT)).ToString()
            txtTMContinuePumpDown.Text = (AVPLib.ContainerData.GetPumpdownTM(TM_PUMPDOWN_DELAY_TIME)).ToString()
            txtTMDelayTimeTurnOnIG.Text = (AVPLib.ContainerData.GetPumpdownTM(IG_ON_DELAY)).ToString()
            txtTMVentTO.Text = (AVPLib.ContainerData.GetVentTM(TM_VENT_TIMEOUT)).ToString()
            txtTMContinueVent.Text = (AVPLib.ContainerData.GetVentTM(TM_VENT_DELAY_TIME)).ToString()
            txtTMVentValveTO.Text = (AVPLib.ContainerData.GetVentTM(TM_VENT_VALVE_OPEN_CLOSE_TIMEOUT)).ToString()
            txtAutoLog.Text = (AVPLib.ContainerDAO.GetSystemIDLE_Time()).ToString()
            txtTransferSetPointWaitTimeInSeconds.Text = Format(AVPLib.ContainerData.GetIntegerFromKeyValueInRobotConfig( _
                 ConstEnum.TRANSFER_SET_POINT_WAIT_TIME_IN_SECONDS, 60 * 60) / 60, "0.0")
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub LoadMailSetting()
        Try
            chkAutoSendEmail.Checked = AVPLib.SendEmail.Instance.AutoSendMail
            txtSMTPServer.Text = AVPLib.SendEmail.Instance.SMTPServer.ToString()
            txtPort.Text = AVPLib.SendEmail.Instance.PortID.ToString
            txtUserName.Text = AVPLib.SendEmail.Instance.UserName.ToString()
            txtPassword.Text = AVPLib.SendEmail.Instance.Password.ToString()
            ShowDataToEmailGrid(AVPLib.SendEmail.Instance.HashTriggers)

            ' enable and disable Email Gui when Auto send mail checked
            If (chkAutoSendEmail.Checked) Then
                gbAccountInfomation.Enabled = True
                btnApplyEmailSetting.Enabled = True
            Else
                gbAccountInfomation.Enabled = False
                btnApplyEmailSetting.Enabled = False
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub LoadPressureSetpoint()
        Dim objConfig As AVPLib.SystemModule = Nothing

        ' LoadLock A
        ' Fast Vent Press SetPoint.
        Dim objEQ As AVPLib.DataManagerment.Equipment = Nothing
        txtVentLLA.Text = (AVPLib.ContainerData.GetVentLL(LLA_CG_ON_FAST_VENT_VALVE_OPEN)).ToString()

        ' LLA Transfer Press SetPoint.
        txtTransferLLA.Text = Utils.ConvertDoubleToScientificFormat(AVPLib.ContainerData.GetTransferSetPointPressureForStation(AVPLib.ConstEnum.Equipments.LoadLockA.ToString(), 0.1))
        objEQ = AVPLib.DataManagerment.EquipmentManager.GetEquipment(ConstEnum.LoadLockA_STR)
        If objEQ IsNot Nothing Then
            Double.TryParse(txtTransferLLA.Text, objEQ.TransferSetPoint)
        End If

        objConfig = AVPLib.ContainerData.GetRobotConfig(LoadLockA_STR)
        If objConfig IsNot Nothing Then
            txtRateOfRiseVolLLA.Text = objConfig.Litter_Value
        End If

        ' LLA CrossOver Press SePoint.
        txtCrossOverLLA.Text = (AVPLib.ContainerData.GetPumpdownLL(LLA_CG_ON_FAST_ROUGH_VALVE_OPEN)).ToString()
        txtLLACGTripPoint.Text = (AVPLib.ContainerData.GetCGConfig(LLA_CG_TRIP_POINT).ToString())
        txtLLAForelineCGTripPoint.Text = (AVPLib.ContainerData.GetCGConfig(LLA_TURBO_CG_TRIP_POINT)).ToString()

        ' Slow Vent Press SetPoint. 
        txtSlowVentLLA.Text = (AVPLib.ContainerData.GetVentLL(LLA_CG_ON_SLOW_VENT_VALVE_OPEN)).ToString()
        ' Slow Rough Press SetPoint. 
        txtSlowRoughLLA.Text = (AVPLib.ContainerData.GetPumpdownLL(LLA_CG_ON_SLOW_ROUGH_VALVE_OPEN)).ToString()

        ' Transfer Module.
        objConfig = AVPLib.ContainerData.GetRobotConfig(ROBOT_STR)
        If objConfig IsNot Nothing Then
            txtRateOfRiseVolTM.Text = objConfig.Litter_Value
        End If

        txtVentTM.Text = (AVPLib.ContainerData.GetVentTM(TM_CG_ON_LL_FAST_VENT_VALVES_OPEN)).ToString()
        txtTransferTM.Text = Utils.ConvertDoubleToScientificFormat(AVPLib.ContainerData.GetTransferSetPointPressureForStation(AVPLib.ConstEnum.Equipments.CassettesModule.ToString(), 0.1))
        '''Load CG Pressure Differential Percent
        objEQ = AVPLib.DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString())
        If objEQ IsNot Nothing Then
            Dim objTransferModule As DataManagerment.CassettesModule = AVPLib.DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString())
            objTransferModule.PressureDifferentialPercent = AVPLib.ContainerData.GetTransferPressureSetpointConfig(PRESSUREDIFFERENTIALPERCENT)
            txtCGDifferentialPercent.Text = objTransferModule.PressureDifferentialPercent
        End If
        txtCrossOverTM.Text = (AVPLib.ContainerData.GetPumpdownTM(TM_CG_ON_FAST_ROUGH_VALVE_OPEN)).ToString()
        txtTMCGTripPoint.Text = (AVPLib.ContainerData.GetCGConfig(TM_CG_TRIP_POINT)).ToString()
        txtTMForelineCGTripPoint.Text = (AVPLib.ContainerData.GetCGConfig(TM_TURBO_CG_TRIP_POINT)).ToString()
        txtMPCGTripPoint.Text = (AVPLib.ContainerData.GetCGConfig(MP_CG_TRIP_POINT)).ToString()

        '0007261: [MotPham - 06-05-2015]Please see picture below. Should remove them. confirmed by TrucLe
        SetEtchRateControlVisible()

        If RobotConfigurationValues.DEVICENET_INSTALLED Then
            ''Rough Pump Machine
            Dim isAnyVisible As Boolean = False
            Dim objRoughPumpMachineCGDrive1 As MPumpCGDriver = AVPLib.Driver.DriverManager.GetDriver(RoughPumpMachine1_CG)
            Dim objRoughPumpMachineCGDrive2 As MPumpCGDriver = AVPLib.Driver.DriverManager.GetDriver(RoughPumpMachine2_CG)
            If (objRoughPumpMachineCGDrive1 Is Nothing OrElse objRoughPumpMachineCGDrive1.eCommunicationType <> CommType.DeviceNet) _
                AndAlso (objRoughPumpMachineCGDrive2 Is Nothing OrElse objRoughPumpMachineCGDrive2.eCommunicationType <> CommType.DeviceNet) Then
                txtMPCGTripPoint.Enabled = False
            Else
                isAnyVisible = True
            End If

            ''TM
            Dim objCassettesModuleCGDrive As CGDriver = AVPLib.Driver.DriverManager.GetDriver(CassettesModule_CG)
            If objCassettesModuleCGDrive Is Nothing OrElse objCassettesModuleCGDrive.eCommunicationType <> CommType.DeviceNet Then
                txtTMCGTripPoint.Enabled = False
            Else
                isAnyVisible = True
            End If
            '' TM Turbo Foreline
            Dim objCassettesModuleForelineCGDrive As TurboForeLineDriver = AVPLib.Driver.DriverManager.GetDriver(CassettesModule_TurboForelineCG)
            If objCassettesModuleForelineCGDrive Is Nothing OrElse objCassettesModuleForelineCGDrive.eCommunicationType <> CommType.DeviceNet Then
                txtTMForelineCGTripPoint.Enabled = False
            Else
                isAnyVisible = True
            End If

            ''LLA
            Dim objLoadLockACGDrive As CGDriver = AVPLib.Driver.DriverManager.GetDriver(LoadLockA_CG)
            If objLoadLockACGDrive Is Nothing OrElse objLoadLockACGDrive.eCommunicationType <> CommType.DeviceNet Then
                txtLLACGTripPoint.Enabled = False
            Else
                isAnyVisible = True
            End If
            '' LLA Turbo Foreline
            Dim objLLAForelineCGDrive As TurboForeLineDriver = AVPLib.Driver.DriverManager.GetDriver(LoadLockA_TurboForelineCG)
            If objLLAForelineCGDrive Is Nothing OrElse objLLAForelineCGDrive.eCommunicationType <> CommType.DeviceNet Then
                txtLLAForelineCGTripPoint.Enabled = False
            Else
                isAnyVisible = True
            End If
        Else
            txtLLACGTripPoint.Enabled = False
            txtTMCGTripPoint.Enabled = False
            txtMPCGTripPoint.Enabled = False
            txtLLAForelineCGTripPoint.Enabled = False
            txtTMForelineCGTripPoint.Enabled = False
        End If
        ' PM1
        txtTransferPM1.Text = Utils.ConvertDoubleToScientificFormat(AVPLib.ContainerData.GetTransferSetPointPressureForStation(AVPLib.ConstEnum.Equipments.Chamber1.ToString(), 0.1))
        objEQ = AVPLib.DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber1.ToString())
        If objEQ IsNot Nothing Then
            Double.TryParse(txtTransferPM1.Text, objEQ.TransferSetPoint)
        End If
        ' PM2
        txtTransferPM2.Text = Utils.ConvertDoubleToScientificFormat(AVPLib.ContainerData.GetTransferSetPointPressureForStation(AVPLib.ConstEnum.Equipments.Chamber2.ToString(), 0.1))
        objEQ = AVPLib.DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber2.ToString())
        If objEQ IsNot Nothing Then
            Double.TryParse(txtTransferPM2.Text, objEQ.TransferSetPoint)
        End If
        ' PM3
        txtTransferPM3.Text = Utils.ConvertDoubleToScientificFormat(AVPLib.ContainerData.GetTransferSetPointPressureForStation(AVPLib.ConstEnum.Equipments.Chamber3.ToString(), 0.1))
        objEQ = AVPLib.DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber3.ToString())
        If objEQ IsNot Nothing Then
            Double.TryParse(txtTransferPM3.Text, objEQ.TransferSetPoint)
        End If
        m_iTransferSetPointTextChanged = 0
        m_iVentSetPointTextChanged = 0
        m_iCrossOverSetPointTextChanged = 0
        m_iSlowRoughSetPointTextChanged = 0
        m_iSlowVentSetPointTextChanged = 0
        ''Cryo Pump Hour
        txtCryoPumpHour.Text = AVPLib.RobotConfigurationValues.CRYO_REGEN_HOURS_LIMIT
    End Sub

    Private Sub LoadLLElevatorConfig()
        ' LLA Elevator
        txtNumberOfSlotsLLA.Text = AVPLib.ContainerData.GetLLElevatorConfig(NUMBER_OF_SLOT)
        txtTravelLengthLLA.Text = AVPLib.ContainerData.GetLLElevatorConfig(TRAVEL_LENGTH)
        txtPitchLLA.Text = AVPLib.ContainerData.GetLLElevatorConfig(PITCH)
        txtBaseOffsetLLA.Text = AVPLib.ContainerData.GetLLElevatorConfig(BASE_OFFSET)
        txtFindBiasLLA.Text = AVPLib.ContainerData.GetLLElevatorConfig(FIND_BIAS)
    End Sub

    Private Sub LoadLifeTimeWafer()
        txtLifeTimeWafer.Text = AVPLib.ContainerData.LifeTimeWafer
    End Sub

#End Region

#Region "KeyPress"
    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-06-15</date>
    ''' </author>
    ''' <summary>
    ''' Textbox keyPress event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtNumber_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                     Handles txtVentLLA.KeyPress, txtVentTM.KeyPress, txtTransferTM.KeyPress, _
                       txtTransferPM3.KeyPress, txtTransferPM2.KeyPress, _
                     txtTransferPM1.KeyPress, txtTransferLLA.KeyPress, _
                     txtSlowRoughLLA.KeyPress, txtCrossOverTM.KeyPress, txtCrossOverLLA.KeyPress, _
                      txtSlowVentLLA.KeyPress, txtTravelLengthLLA.KeyPress, _
                      txtPitchLLA.KeyPress, txtNumberOfSlotsLLA.KeyPress, _
                      txtFindBiasLLA.KeyPress, txtBaseOffsetLLA.KeyPress, _
                     txtCGDifferentialPercent.KeyPress, txtCryoPumpHour.KeyPress, txtMesaValveTO.KeyPress, txtIGOnOffTO.KeyPress, _
                     txtHivacTO.KeyPress, txtSystemCheckSensor.KeyPress, txtLLASlowRoughTO.KeyPress, _
                     txtLLAFastRoughTO.KeyPress, txtLLRoughValveTO.KeyPress, txtLLContinuePumpDown.KeyPress, _
                     txtLLDelayTimeTurnOnIG.KeyPress, txtLLASlowVentTO.KeyPress, txtLLAFastVentTO.KeyPress, _
                     txtLLVentValveTO.KeyPress, txtLLContinueVent.KeyPress, txtTMRoughTO.KeyPress, _
                     txtTMContinuePumpDown.KeyPress, txtTMDelayTimeTurnOnIG.KeyPress, txtTMVentTO.KeyPress, txtTMContinueVent.KeyPress, _
                     txtTMVentValveTO.KeyPress, txtAutoLog.KeyPress
        If (Char.IsNumber(e.KeyChar) Or e.KeyChar = "-" Or e.KeyChar = "." Or e.KeyChar = "") Then ' back spase
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
#End Region

#Region "Support Functions"
    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2013-06-19 </date>
    ''' </author>
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CreateTargetPSConfigPopUpPanel(ByRef PMXTargetPSConfigPopUpPanel As SystemSetupPopUpPanel, ByVal NumberTarget As Integer)
        Try
            If PMXTargetPSConfigPopUpPanel Is Nothing Then
                PMXTargetPSConfigPopUpPanel = New SystemSetupPopUpPanel
                PMXTargetPSConfigPopUpPanel.Name = "SystemSetupPopUpPanel"
                PMXTargetPSConfigPopUpPanel.StartPosition = FormStartPosition.CenterScreen
                PMXTargetPSConfigPopUpPanel.ShowInTaskbar = False
                PMXTargetPSConfigPopUpPanel.ShowIcon = False
                PMXTargetPSConfigPopUpPanel.Hide()
                'PMXTargetPSConfigPopUpPanel.Title = "System Setup for Target Power PM" & NumberTarget.ToString()
                PMXTargetPSConfigPopUpPanel.ChamberName = ConstantAndEnum.CHAMBER.ToString() & NumberTarget.ToString()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Function GetUserInput(ByVal TargetControl As System.Object, ByVal AllowDecimal As Boolean, Optional ByVal IsScientificFormat As Boolean = False) As MsgBoxResult
        Dim UserResponse As MsgBoxResult = MsgBoxResult.Cancel
        Try
            Dim needToCheckMaxMin As Boolean = True
            'If Me.tabPolling.Contains(TargetControl) Then
            '    needToCheckMaxMin = True
            'End If
            Dim Source As String = String.Empty
            Dim Min As Single = 0
            Dim Max As Single = MAX_INPUT
            Dim logName As String = Utils.GetLogName(TargetControl)

            Dim f As New NumPad()
            Dim Value As String = String.Empty
            If TypeOf (TargetControl) Is TextBox Then
                Value = CType(TargetControl, TextBox).Text
                Source = "SystemSetup" & "." & CType(TargetControl, TextBox).Name & "."
                Dim minObj As Object = AVPLib.ContainerData.GetRobotConfig(Source + STRING_MIN)
                Dim maxObj As Object = AVPLib.ContainerData.GetRobotConfig(Source + STRING_MAX)

                If minObj IsNot Nothing Then
                    Min = minObj
                End If

                If maxObj IsNot Nothing Then
                    Max = maxObj
                End If
            Else
                Exit Function
            End If

            If CType(TargetControl, TextBox).Parent IsNot Nothing AndAlso CType(TargetControl, TextBox).Parent.Parent IsNot Nothing Then
                If CType(TargetControl, TextBox).Parent.Parent.Name IsNot Nothing AndAlso
                        CType(TargetControl, TextBox).Parent.Parent.Name = "pnlTimeOut" AndAlso
                        Not CType(TargetControl, TextBox).Name.Contains("txtDegasWaitTime") Then
                    Max = MAX_INPUT
                End If
            End If

            UserResponse = f.GetUserInput(Value, -1, -1, Min, Max, "Enter your " & logName & " value", 0,
                                needToCheckMaxMin, AllowDecimal)
            If UserResponse = MsgBoxResult.Ok Then
                If TypeOf (TargetControl) Is TextBox Then
                    StoreValueBeforeChanged(CType(TargetControl, TextBox))
                    CType(TargetControl, TextBox).Text = IIf(IsScientificFormat, ConvertDoubleToScientificFormat(Value), Value)
                End If
            End If

            If f.IsMaxMinModified Then
                AVPLib.ContainerData.SetRobotConfig(Source + STRING_MIN, f.NewMin)
                AVPLib.ContainerData.SetRobotConfig(Source + STRING_MAX, f.NewMax)

                If Min <> f.NewMin Then
                    Utils.LogUserEvent(Nothing, "System Setup", "", "MIN of " & logName, Min, f.NewMin)
                End If

                If Max <> f.NewMax Then
                    Utils.LogUserEvent(Nothing, "System Setup", "", "MAX of " & logName, Max, f.NewMax)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return UserResponse
    End Function

    Private Function ConvertDoubleToScientificFormat(ByVal Value As Double) As String
        Return Format(Double.Parse(Value), AVPLib.ConstEnum.SCIENTIFIC_FORMAT)
    End Function
    ''Truc Le add
    ''This function support Enable-Disable TextBox base on PVD Type
    Public Sub Enable_Disable_TxtBox_BaseOnPVDType(ByVal chamberName As String, ByVal blnTargetVisible As Boolean)
        Try
            Select Case chamberName
                Case ConstEnum.Equipments.Chamber1.ToString()
                    txtTarMaterialPM1.Enabled = blnTargetVisible
                    txtWaferCountPM1.Enabled = True

                Case ConstEnum.Equipments.Chamber2.ToString()
                    txtTarMaterialPM2.Enabled = blnTargetVisible
                    txtWaferCountPM2.Enabled = True

                Case ConstEnum.Equipments.Chamber3.ToString()
                    txtTarMaterialPM3.Enabled = blnTargetVisible
                    txtWaferCountPM3.Enabled = True
            End Select
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-06-19 </date>
    ''' </author>
    ''' <summary>
    ''' Show/Hide Slow Vent and Rought Vent in Pressure setting tab
    ''' </summary>
    Private Sub SetSlowVentAndRoughVisible()
        Try
            If Not RobotConfigurationValues.LL_SLOW_ROUGH_INSTALLED AndAlso Not RobotConfigurationValues.LL_SLOW_VENT_INSTALLED Then
                txtSlowVentLLA.Enabled = False
                txtSlowRoughLLA.Enabled = False
                'lblSlowRough.Enabled = False
                'lblSlowVent.Enabled = False

                ' Update size and center groupbox
                'Dim widthLost As Int32 = gbxPressure.Size.Width - txtSlowRoughLLA.Location.X
                'gbxPressure.Size = New Size(gbxPressure.Size.Width - widthLost, gbxPressure.Size.Height)
                'gbxPressure.Location = New Point(gbxPressure.Location.X + widthLost / 2, gbxPressure.Location.Y)
                'gbxCGTransferDiff.Location = New Point(gbxCGTransferDiff.Location.X + widthLost / 2, gbxCGTransferDiff.Location.Y)
                'gbxRegenHourLimit.Location = New Point(gbxRegenHourLimit.Location.X + widthLost / 2, gbxRegenHourLimit.Location.Y)

            Else
                'Dim widthLost As Int32
                If Not RobotConfigurationValues.LL_SLOW_ROUGH_INSTALLED Then
                    txtSlowRoughLLA.Enabled = False
                    'lblSlowRough.Enabled = False
                    'widthLost = gbxPressure.Size.Width - txtSlowVentLLA.Left

                    'txtSlowVentLLA.Location = txtSlowRoughLLA.Location
                    'lblSlowVent.Location = lblSlowRough.Location
                End If

                If Not RobotConfigurationValues.LL_SLOW_VENT_INSTALLED Then
                    txtSlowVentLLA.Enabled = False
                    'lblSlowVent.Enabled = False
                    'If widthLost <> 0 Then
                    '    widthLost = gbxPressure.Size.Width - txtSlowRoughLLA.Left
                    'Else
                    '    widthLost = gbxPressure.Size.Width - txtSlowVentLLA.Left
                    'End If
                End If

                ' Update size and center groupbox
                'gbxPressure.Size = New Size(gbxPressure.Size.Width - widthLost, gbxPressure.Size.Height)
                'gbxPressure.Location = New Point(gbxPressure.Location.X + widthLost / 2, gbxPressure.Location.Y)
                'gbxCGTransferDiff.Location = New Point(gbxCGTransferDiff.Location.X + widthLost / 2, gbxCGTransferDiff.Location.Y)
                'gbxRegenHourLimit.Location = New Point(gbxRegenHourLimit.Location.X + widthLost / 2, gbxRegenHourLimit.Location.Y)

            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-06-19 </date>
    ''' </author>
    ''' <summary>
    ''' Set and show/hide PM type
    ''' </summary>
    Private Sub SetPM1Type(ByVal type As String, Optional ByVal isVisible As Boolean = True)
        Try
            lblPM1Type1.Text = type
            lblPM1Type2.Text = type

            lblPM1Type1.Visible = isVisible
            lblPM1Type2.Visible = isVisible
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-06-19 </date>
    ''' </author>
    ''' <summary>
    ''' Set and show/hide PM type
    ''' </summary>
    Private Sub SetPM2Type(ByVal type As String, Optional ByVal isVisible As Boolean = True)
        Try
            lblPM2Type1.Text = type
            lblPM2Type2.Text = type

            lblPM2Type1.Visible = isVisible
            lblPM2Type2.Visible = isVisible
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-06-19 </date>
    ''' </author>
    ''' <summary>
    ''' Set and show/hide PM type
    ''' </summary>
    Private Sub SetPM3Type(ByVal type As String, Optional ByVal isVisible As Boolean = True)
        Try
            lblPM3Type1.Text = type
            lblPM3Type2.Text = type

            lblPM3Type1.Visible = isVisible
            lblPM3Type2.Visible = isVisible
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-06-19 </date>
    ''' </author>
    ''' <summary>
    ''' Enable/Disable control when LLA installed or not
    ''' </summary>
    Public Sub SetLLAEnable(ByVal isEnabled As Boolean)
        Try
            ContainerForm.SystemSetup.txtVentLLA.Enabled = isEnabled
            ContainerForm.SystemSetup.txtTransferLLA.Enabled = isEnabled
            ContainerForm.SystemSetup.txtCrossOverLLA.Enabled = isEnabled
            ContainerForm.SystemSetup.txtNumberOfSlotsLLA.Enabled = isEnabled
            ContainerForm.SystemSetup.txtPitchLLA.Enabled = isEnabled
            ContainerForm.SystemSetup.txtTravelLengthLLA.Enabled = isEnabled
            ContainerForm.SystemSetup.txtBaseOffsetLLA.Enabled = isEnabled
            ContainerForm.SystemSetup.txtFindBiasLLA.Enabled = isEnabled
            ContainerForm.SystemSetup.txtSlowRoughLLA.Enabled = isEnabled
            ContainerForm.SystemSetup.txtSlowVentLLA.Enabled = isEnabled
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-06-19 </date>
    ''' </author>
    ''' <summary>
    ''' Enable/Disable control when Chamber1 visible or not
    ''' </summary>
    Public Sub SetPM1Enable(ByVal isEnabled As Boolean)
        txtUsageKWH_PM1.Enabled = isEnabled
        txtLimitsKWH_PM1.Enabled = isEnabled
        txtWarningKWH_PM1.Enabled = isEnabled
        txtMaxKWHPM1.Enabled = isEnabled
        txtTarMaterialPM1.Enabled = isEnabled
        txtShieldPM1.Enabled = isEnabled
        txtLimitShieldsPM1.Enabled = isEnabled
        txtWarningShieldsPM1.Enabled = isEnabled
        txtMaxShieldsPM1.Enabled = isEnabled
        txtWaferCountPM1.Enabled = isEnabled
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-06-19 </date>
    ''' </author>
    ''' <summary>
    ''' Enable/Disable control when Chamber2 visible or not
    ''' </summary>
    Public Sub SetPM2Enable(ByVal isEnabled As Boolean)
        txtUsageKWH_PM2.Enabled = isEnabled
        txtLimitsKWH_PM2.Enabled = isEnabled
        txtWarningKWH_PM2.Enabled = isEnabled
        txtMaxKWHPM2.Enabled = isEnabled
        txtTarMaterialPM2.Enabled = isEnabled
        txtShieldsPM2.Enabled = isEnabled
        txtLimitShieldsPM2.Enabled = isEnabled
        txtWarningShieldsPM2.Enabled = isEnabled
        txtMaxShieldsPM2.Enabled = isEnabled
        txtWaferCountPM2.Enabled = isEnabled
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-06-19 </date>
    ''' </author>
    ''' <summary>
    ''' Enable/Disable control when Chamber3 visible or not
    ''' </summary>
    Public Sub SetPM3Enable(ByVal isEnabled As Boolean)
        txtUsageKWH_PM3.Enabled = isEnabled
        txtLimitsKWH_PM3.Enabled = isEnabled
        txtWarningKWH_PM3.Enabled = isEnabled
        txtMaxKWHPM3.Enabled = isEnabled
        txtTarMaterialPM3.Enabled = isEnabled
        txtShieldsPM3.Enabled = isEnabled
        txtLimitShieldsPM3.Enabled = isEnabled
        txtWarningShieldsPM3.Enabled = isEnabled
        txtMaxShieldsPM3.Enabled = isEnabled
        txtWaferCountPM3.Enabled = isEnabled
    End Sub

    Public Sub SystemSetupForPM1()
        If RobotConfigurationValues.CHAMBER1_VISIBLE = False Then
            SetPM1Type(N_A)
            lblPM1_UsageUnit.Text = n_a_
            lblPM1_ShQuUnit.Text = n_a_
        Else
            If RobotConfigurationValues.CHAMBER1_TYPE = SystemModule.ModuleType.IBE Then
                SetPM1Type(IBEType)
                lblPM1_UsageUnit.Text = min
                lblPM1_ShQuUnit.Text = min
            ElseIf RobotConfigurationValues.CHAMBER1_TYPE = SystemModule.ModuleType.PVD Then
                SetPM1Type(PVDType)
                lblPM1_UsageUnit.Text = kwh
                lblPM1_ShQuUnit.Text = kwh
            ElseIf RobotConfigurationValues.CHAMBER1_TYPE = SystemModule.ModuleType.PVD4 Then
                SetPM1Type(CORONAType)
                lblPM1_UsageUnit.Text = kwh
                lblPM1_ShQuUnit.Text = kwh
            ElseIf RobotConfigurationValues.CHAMBER1_TYPE = SystemModule.ModuleType.PVD5T Then
                SetPM1Type(PVD5TType)
                lblPM1_UsageUnit.Text = kwh
                lblPM1_ShQuUnit.Text = kwh
            End If
        End If
    End Sub

    Public Sub SystemSetupForPM2()
        If RobotConfigurationValues.CHAMBER2_VISIBLE = False Then
            SetPM2Type(N_A)
            lblPM2_UsageUnit.Text = n_a_
            lblPM2_ShQuUnit.Text = n_a_
        Else
            If RobotConfigurationValues.CHAMBER2_TYPE = SystemModule.ModuleType.IBE Then
                SetPM2Type(IBEType)
                lblPM2_UsageUnit.Text = min
                lblPM2_ShQuUnit.Text = min
            ElseIf RobotConfigurationValues.CHAMBER2_TYPE = SystemModule.ModuleType.PVD Then
                SetPM2Type(PVDType)
                lblPM2_UsageUnit.Text = kwh
                lblPM2_ShQuUnit.Text = kwh
            ElseIf RobotConfigurationValues.CHAMBER2_TYPE = SystemModule.ModuleType.PVD4 Then
                SetPM2Type(CORONAType)
                lblPM2_UsageUnit.Text = kwh
                lblPM2_ShQuUnit.Text = kwh
            ElseIf RobotConfigurationValues.CHAMBER2_TYPE = SystemModule.ModuleType.PVD5T Then
                SetPM1Type(PVD5TType)
                lblPM2_UsageUnit.Text = kwh
                lblPM2_ShQuUnit.Text = kwh
            End If
        End If
    End Sub

    Public Sub SystemSetupForPM3()
        If RobotConfigurationValues.CHAMBER3_VISIBLE = False Then
            SetPM3Type(N_A)
            lblPM3_UsageUnit.Text = n_a_
            lblPM3_ShQuUnit.Text = n_a_
        Else
            If RobotConfigurationValues.CHAMBER3_TYPE = SystemModule.ModuleType.IBE Then
                SetPM3Type(IBEType)
                lblPM3_UsageUnit.Text = min
                lblPM3_ShQuUnit.Text = min
            ElseIf RobotConfigurationValues.CHAMBER3_TYPE = SystemModule.ModuleType.PVD Then
                SetPM3Type(PVDType)
                lblPM3_UsageUnit.Text = kwh
                lblPM3_ShQuUnit.Text = kwh
            ElseIf RobotConfigurationValues.CHAMBER3_TYPE = SystemModule.ModuleType.PVD4 Then
                SetPM3Type(CORONAType)
                lblPM3_UsageUnit.Text = kwh
                lblPM3_ShQuUnit.Text = kwh
            ElseIf RobotConfigurationValues.CHAMBER3_TYPE = SystemModule.ModuleType.PVD5T Then
                SetPM3Type(PVD5TType)
                lblPM3_UsageUnit.Text = kwh
                lblPM3_ShQuUnit.Text = kwh
            End If
        End If
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-06-19 </date>
    ''' </author>
    ''' <summary>
    ''' Visible Etch Rate Control which only use for IBE
    ''' </summary>
    Private Sub SetEtchRateControlVisible()
        Dim isShowed As Boolean = False
        If RobotConfigurationValues.CHAMBER1_VISIBLE AndAlso RobotConfigurationValues.CHAMBER1_TYPE = SystemModule.ModuleType.IBE Then
            isShowed = True
            txtEtchRatePM1.Enabled = True
        End If

        If RobotConfigurationValues.CHAMBER2_VISIBLE AndAlso RobotConfigurationValues.CHAMBER2_TYPE = SystemModule.ModuleType.IBE Then
            isShowed = True
            txtEtchRatePM2.Enabled = True
        End If

        If RobotConfigurationValues.CHAMBER3_VISIBLE AndAlso RobotConfigurationValues.CHAMBER3_TYPE = SystemModule.ModuleType.IBE Then
            isShowed = True
            txtEtchRatePM3.Enabled = True
        End If
    End Sub

    Private Sub HideTabPage(ByVal tp As TabPage)
        If tabSystem.TabPages.Contains(tp) Then tabSystem.TabPages.Remove(tp)
    End Sub

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-12-10</date>
    ''' </author>
    ''' <summary>
    ''' First Load
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearForm()
        Try
            'Begin Polling

            'End Polling
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-12-10</date>
    ''' </author>
    ''' <summary>
    ''' Check Permission
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CheckPermission()
        Try
            If AVPLib.ContainerData.Permission(PERMISSION_004) Then
                ActiveForm()
            Else
                InactiveForm()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-12-10</date>
    ''' </author>
    ''' <summary>
    ''' Active Form
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ActiveForm()
        Try
            Me.pnlGeneralSetting.Enabled = True
            Me.pnlPressureSetPoint.Enabled = True
            Me.pnlElevatorSetting.Enabled = True
            Me.pnlKWH.Enabled = True
            Me.pnlTimeOut.Enabled = True
            'If rbUseMaxKWH.Checked Then
            '    rbUseMaxKWH_Click(rbUseMaxKWH, Nothing)
            'Else
            '    rbUseMaxKWH_Click(rbUseAbsoluteKWH, Nothing)
            'End If
            Me.pnlEmailAlert.Enabled = True
            EnableDisableButton(True)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-12-10</date>
    ''' </author>
    ''' <summary>
    ''' Inactive Form
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InactiveForm()
        Try
            Me.pnlGeneralSetting.Enabled = False
            Me.pnlPressureSetPoint.Enabled = False
            Me.pnlElevatorSetting.Enabled = False
            Me.pnlKWH.Enabled = False
            Me.pnlTimeOut.Enabled = False
            Me.pnlEmailAlert.Enabled = False
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "General Setting Tab"
    Private Sub txtGeneralBox_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
                                      txtDeltaPickECCLimits.Click, txtDegasWaitTimeTM.Click, txtDegasWaitTimeLLA.Click, txtRateOfRiseVolTM.Click, txtRateOfRiseVolLLA.Click, txtEtchRatePM3.Click, txtEtchRatePM2.Click, txtEtchRatePM1.Click, txtTransferSetPointWaitTimeInSeconds.Click, txtSystemCleanUpDataRunTimeInDays.Click
        GetUserInput(sender, True)
    End Sub

    Private Sub btnApplyGeneralSetting_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApplyGeneralSetting.Click
        Try
            Dim subSource As String = "General"
            Dim bResult As Boolean = False

            LogUserEvent("Apply Button Clicked", subSource)

            AVPRobotMain.AVPInfoPanel.ToolID = txtInfoName.Text
            AVPLib.ContainerDAO.SaveToolID(txtInfoName.Text)

            LogUserEvent(cbAutoVentWhenProcessCompleted, subSource)
            LogUserEvent(cbAutoArchiveSystemConfigFile, subSource)
            LogUserEvent(txtArchiveConfigFile, subSource)
            LogUserEvent(cbxEnableQuickSequenceEditor, subSource)
            LogUserEvent(txtSystemCleanUpDataRunTimeInDays, subSource)

            SaveAutoVentWhenProcessingConpleted(cbAutoVentWhenProcessCompleted.Checked)
            SaveAutoArchiveSystemConfigFile(cbAutoArchiveSystemConfigFile.Checked, txtSystemCleanUpDataRunTimeInDays.Text)
            SaveEnableQuickSequenceEditor(cbxEnableQuickSequenceEditor.Checked)
            SaveAutoArchiveSystemConfigFilePath(txtArchiveConfigFile.Text)
            SaveDelayTimeAfterProcessComplete(txtDelayTimeAfterProcessComplete.Text)

            SaveECCLimits()
            SaveSupportManualDefineGEMWaferID()

            LogUserEvent(cbxAllowCheckingECCLimit, subSource)
            LogUserEvent(txtDeltaPickECCLimits, subSource)
            LogUserEvent(cbxManualDefineGEMWaferID, subSource)

            Utils.ShowAVPMessageBox("General Settings saved successfully.", "General Setting", MessageBoxIcon.Information, MessageBoxButtons.OK)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub

    ''' <author>
    '''     <name> Hoai Ly </name>
    '''     <date> 2015-06-03 </date>
    ''' </author>
    ''' <summary>
    ''' Add value before change, use for log
    ''' </summary>
    Private Sub StoreValueBeforeChanged(ByVal control As Object)
        If (m_mapValueChanged Is Nothing) Then
            m_mapValueChanged = New Hashtable()
        End If

        If TypeOf control Is SL_Textbox Then
            Dim sltbx As SL_Textbox = CType(control, SL_Textbox)

            If Not (m_mapValueChanged.ContainsKey(sltbx.Name)) Then
                m_mapValueChanged.Add(sltbx.Name, sltbx.Text)
            End If
        ElseIf TypeOf control Is TextBox Then
            Dim tbx As TextBox = CType(control, TextBox)

            If Not (m_mapValueChanged.ContainsKey(tbx.Name)) Then
                m_mapValueChanged.Add(tbx.Name, tbx.Text)
            End If
        ElseIf TypeOf control Is CheckBox Then
            Dim cbx As CheckBox = CType(control, CheckBox)

            If Not (m_mapValueChanged.ContainsKey(cbx.Name)) Then
                m_mapValueChanged.Add(cbx.Name, Not cbx.Checked)
            End If
        End If

    End Sub

    ''' <author>
    '''     <name> Hoai Ly </name>
    '''     <date> 2015-06-03 </date>
    ''' </author>
    ''' <summary>
    ''' Get original value of setting in control before changed, use for log
    ''' </summary>
    Private Function GetStoredValue(ByVal key As String) As Object
        Try
            Dim value As Object

            If m_mapValueChanged.ContainsKey(key) Then
                value = m_mapValueChanged(key)
                ' Remove after get, use for update new value changed
                m_mapValueChanged.Remove(key)
                Return value
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return Nothing
    End Function

    ''' <author>
    '''     <name> Hoai Ly </name>
    '''     <date> 2015-06-03 </date>
    ''' </author>
    ''' <summary>
    ''' Log change of setting
    ''' </summary>
    Private Sub LogUserEvent(ByVal control As Object, Optional ByVal subLogSource As String = "", Optional ByVal subLogSheild As String = "")
        Dim logSource As String = "[System Setup]"

        If subLogSource.Trim() <> "" Then
            subLogSource = subLogSource + ": "
        End If

        Dim logMessage As String = String.Empty
        Try
            If TypeOf control Is SL_Textbox Then
                Dim slTbx As SL_Textbox = CType(control, SL_Textbox)
                Dim logName As String = Utils.GetLogName(slTbx)
                Dim oldValue As String = GetStoredValue(slTbx.Name)

                If Not slTbx.Text.Equals(oldValue) Then
                    If oldValue = "" Then
                        logMessage = String.Format("{0} {1}Set {2} value to {3}", logSource, subLogSource, logName, slTbx.Text)
                    Else
                        logMessage = String.Format("{0} {1}Changed {2} from {3} to {4}", logSource, subLogSource, logName, oldValue, slTbx.Text)
                    End If
                    If subLogSheild.Trim() <> "" Then
                        Utils.CheckChangeValue(subLogSheild & "_" & logName, oldValue, slTbx.Text.ToString())
                    Else
                        Utils.CheckChangeValue(logName, oldValue, slTbx.Text.ToString())
                    End If

                End If

            ElseIf TypeOf control Is TextBox Then
                Dim tbx As TextBox = CType(control, TextBox)
                Dim preValue As Object = GetStoredValue(tbx.Name)

                ' Only log when value is different
                If preValue IsNot Nothing AndAlso (Not tbx.Text.Equals(preValue.ToString)) Then
                    Dim logName As String = tbx.AccessibleDescription

                    If String.IsNullOrEmpty(logName) Then
                        If tbx.Name.StartsWith("txt") OrElse tbx.Name.StartsWith("tbx") Then
                            logName = tbx.Name.Substring(3)
                        Else
                            logName = tbx.Name
                        End If
                    End If
                    If subLogSheild.Trim() <> "" Then
                        Utils.CheckChangeValue(subLogSheild & "_" & logName, preValue, tbx.Text)
                    Else
                        Utils.CheckChangeValue(logName, preValue, tbx.Text)
                    End If
                    If String.IsNullOrEmpty(preValue) Then
                        logMessage = String.Format("{0} {1}Set {2} value to {3}", logSource, subLogSource, logName, tbx.Text)
                    Else
                        logMessage = String.Format("{0} {1}Changed {2} from {3} to {4}", logSource, subLogSource, logName, preValue, tbx.Text)
                    End If
                End If

            ElseIf TypeOf control Is CheckBox Then
                Dim cbx As CheckBox = CType(control, CheckBox)
                Dim preValue As Boolean = False

                Dim preObj As Object = GetStoredValue(cbx.Name)
                If preObj IsNot Nothing Then
                    preValue = CType(preObj, Boolean)

                    ' Only log when value is different
                    If preValue <> cbx.Checked Then
                        Dim logName As String = cbx.AccessibleDescription
                        If String.IsNullOrEmpty(logName) Then
                            If (cbx.Name.StartsWith("cbx")) Then
                                logName = cbx.Name.Substring(3)
                            ElseIf cbx.Name.StartsWith("cb") Then
                                logName = cbx.Name.Substring(2)
                            Else
                                logName = cbx.Name
                            End If
                        End If

                        If cbx.Checked Then
                            logMessage = String.Format("{0} {1}Checked on {2}", logSource, subLogSource, logName)
                            Utils.CheckChangeValue(logName, "UnChecked", "Checked")
                        Else
                            logMessage = String.Format("{0} {1}Unchecked on {2}", logSource, subLogSource, logName)
                            Utils.CheckChangeValue(logName, "Checked", "UnChecked")
                        End If

                    End If
                End If

            ElseIf TypeOf control Is String Then
                logMessage = String.Format("{0} {1}{2}", logSource, subLogSource, control.ToString())
            End If

            ' Log when message is not empty
            If Not String.IsNullOrEmpty(logMessage) Then
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                        AVPLib.ContainerData.LogSource.AVPMainScreen, logMessage)
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hoai Ly </name>
    '''     <date> 2015-06-03 </date>
    ''' </author>
    ''' <summary>
    ''' Store pre-value of check box
    ''' </summary>
    Private Sub HandleCheckBoxChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbAutoVentWhenProcessCompleted.Click, cbAutoArchiveSystemConfigFile.Click, txtArchiveConfigFile.TextChanged, cbxManualDefineGEMWaferID.Click, cbxAllowCheckingECCLimit.Click, cbxEnableQuickSequenceEditor.Click
        StoreValueBeforeChanged(sender)
    End Sub

    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 2011-11-28</date>
    ''' </author>
    ''' <summary>
    ''' read config file
    ''' apply for Autovent when processing complete
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Sub SaveAutoVentWhenProcessingConpleted(ByVal isEnable As Boolean)
        Try
            ' path of device net config
            Dim xmldoc As System.Xml.XmlDocument = AVPLib.ContainerDAO.SystemConfigDoc
            Dim root As System.Xml.XmlNode = xmldoc.SelectSingleNode(ConstEnum.XPATH_AUTOVENT_WHENPROCESSINGCOMPLETED)
            If (root IsNot Nothing) Then
                root.InnerText = isEnable.ToString
                BinarySerialize.SaveTo_DatFileConfig(AVPLib.ContainerDAO.FPath_SystemConfig, xmldoc)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Hoai Ly </name>
    '''    	<date> 2015-04-22 </date>
    ''' </author>
    ''' <summary>
    ''' read config file
    ''' apply for Auto Archive SystemConfig File Daily
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Sub SaveAutoArchiveSystemConfigFile(ByVal isEnable As Boolean, ByVal valueDay As String)
        Try
            AVPLib.ContainerDAO.SaveAutoPurgeDayConfig(isEnable, valueDay)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Hoai Ly </name>
    '''    	<date> 2015-05-26 </date>
    ''' </author>
    ''' <summary>
    ''' read config file
    ''' apply for Auto Archive SystemConfig File Daily
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Sub SaveAutoArchiveSystemConfigFilePath(ByVal strPath As String)
        Try
            ' path of device net config
            Dim xmldoc As System.Xml.XmlDocument = AVPLib.ContainerDAO.SystemConfigDoc
            Dim root As System.Xml.XmlNode = xmldoc.SelectSingleNode(ConstEnum.XPATH_SYSTEM_CONFIG_FOLDER)
            If (root IsNot Nothing) Then
                root.InnerText = strPath.ToString
                BinarySerialize.SaveTo_DatFileConfig(AVPLib.ContainerDAO.FPath_SystemConfig, xmldoc)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-007-08 </date>
    ''' </author>
    ''' <summary>
    ''' Save ECC_M_Limit and AllowCheckingECCLimit config
    ''' </summary>
    Private Function SaveECCLimits() As Boolean
        Dim result As Boolean = False
        Try
            Dim allowCheckingECCLimit As Boolean = cbxAllowCheckingECCLimit.Checked
            result = AVPLib.ContainerDAO.SaveAllowCheckingECCLimit(allowCheckingECCLimit)

            If result Then
                AVPLib.RobotConfigurationValues.ALLOW_CHECKING_ECC_LIMIT = allowCheckingECCLimit

                Dim eccLimits As Integer
                If Integer.TryParse(txtDeltaPickECCLimits.Text, eccLimits) Then
                    result = AVPLib.ContainerDAO.SaveECC_M_Limit(eccLimits)
                    AVPLib.RobotConfigurationValues.ECC_M_LIMIT = eccLimits
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return result
    End Function

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-007-08 </date>
    ''' </author>
    ''' <summary>
    ''' Save ManualDefineGEMWaferID config
    ''' </summary>
    Private Function SaveSupportManualDefineGEMWaferID() As Boolean
        Dim result As Boolean = False
        Try
            Dim supportManualDefineGEMWaferID As Boolean = cbxManualDefineGEMWaferID.Checked
            result = AVPLib.ContainerDAO.SaveSupportManualDefineGEMWaferID(supportManualDefineGEMWaferID)
            If result Then
                AVPLib.RobotConfigurationValues.SUPPORT_MANUAL_DEFINE_GEM_WAFERID = supportManualDefineGEMWaferID
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return result
    End Function

    ''' <author>
    '''    	<name> Duc Pham </name>
    '''    	<date> 2018-11-22 </date>
    ''' </author>
    ''' <summary>
    ''' read config file
    ''' apply for Auto Save Enable QuickS equence Editor
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Sub SaveEnableQuickSequenceEditor(ByVal isEnable As Boolean)
        Try
            ' path of device net config
            Dim xmldoc As System.Xml.XmlDocument = AVPLib.ContainerDAO.SystemConfigDoc
            Dim root As System.Xml.XmlNode = xmldoc.SelectSingleNode(ConstEnum.XPATH_ENABLE_QUICK_SEQUECE_EDITOR)
            If (root IsNot Nothing) Then
                root.InnerText = isEnable.ToString
                BinarySerialize.SaveTo_DatFileConfig(AVPLib.ContainerDAO.FPath_SystemConfig, xmldoc)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

#End Region

#Region "Pressure Setting"
    Private Sub TransferSetpoint_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTransferTM.TextChanged, txtTransferPM3.TextChanged, txtTransferPM2.TextChanged, txtTransferPM1.TextChanged, txtTransferLLA.TextChanged
        Try
            Dim ctrl As TextBox = CType(sender, TextBox)
            Select Case ctrl.Name
                Case txtTransferLLA.Name
                    m_iTransferSetPointTextChanged = m_iTransferSetPointTextChanged Or 1
                Case txtTransferTM.Name
                    m_iTransferSetPointTextChanged = m_iTransferSetPointTextChanged Or 4
                Case txtTransferPM1.Name
                    m_iTransferSetPointTextChanged = m_iTransferSetPointTextChanged Or 8
                Case txtTransferPM2.Name
                    m_iTransferSetPointTextChanged = m_iTransferSetPointTextChanged Or 16
                Case txtTransferPM3.Name
                    m_iTransferSetPointTextChanged = m_iTransferSetPointTextChanged Or 32

            End Select
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub btnApplyPressureSetpoint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApplyPressureSetpoint.Click
        Try
            Dim bResult As Boolean = False
            Dim subSource As String = "Pressure"
            Dim objConfig As AVPLib.SystemModule = Nothing

            LogUserEvent("Apply Button Clicked", subSource)

            ' Vent Setting.
            Dim LLVentPressure As Hashtable = New Hashtable()
            LLVentPressure.Add(LLA_CG_ON_FAST_VENT_VALVE_OPEN, txtVentLLA.Text.Trim())
            LLVentPressure.Add(LLA_CG_ON_SLOW_VENT_VALVE_OPEN, txtSlowVentLLA.Text.Trim())

            bResult = AVPLib.ContainerData.SaveVent(LLVentPressure, AVPLib.ConstEnum.LLVENT_CONFIG)
            bResult = bResult AndAlso AVPLib.ContainerDAO.SaveRORLitterValue(txtRateOfRiseVolLLA.Text, txtRateOfRiseVolTM.Text)

            If (Not bResult) Then
                Utils.ShowAVPMessageBox("Failed to LL Vent Settings.", "LoadLock Vent Setting", MessageBoxIcon.Error, MessageBoxButtons.OK)
                LogUserEvent("Failed to LL Vent Settings when apply pressure set point.", subSource)
                Return
            End If

            '<!-- Log
            LogUserEvent(txtVentLLA, subSource)
            LogUserEvent(txtSlowVentLLA, subSource)

            objConfig = AVPLib.ContainerData.GetRobotConfig(LoadLockA_STR)
            If objConfig IsNot Nothing Then
                LogUserEvent(txtRateOfRiseVolLLA, subSource)
            End If

            objConfig = AVPLib.ContainerData.GetRobotConfig(ROBOT_STR)
            If objConfig IsNot Nothing Then
                LogUserEvent(txtRateOfRiseVolTM, subSource)
            End If
            '-->

            Dim TMVentPressure As Hashtable = New Hashtable()
            TMVentPressure.Add(TM_CG_ON_LL_FAST_VENT_VALVES_OPEN, txtVentTM.Text.Trim())
            bResult = AVPLib.ContainerData.SaveVent(TMVentPressure, AVPLib.ConstEnum.TMVENT_CONFIG)
            If (Not bResult) Then
                Utils.ShowAVPMessageBox("Failed to TM Vent Settings.", "TM Vent Setting", MessageBoxIcon.Error, MessageBoxButtons.OK)
                LogUserEvent("Failed to TM Vent Settings when apply pressure set point.", subSource)
                Return
            End If

            '<!-- Log
            LogUserEvent(txtVentTM, subSource)
            '-->

            '#08/22/2011 
            '#-	From customer notes:  �No logging data for change in configureation/setup data (target limit/warning,�.)  
            '# User want to log when user changes any limits relating to target kwh page
            '#Begin fix:
            VentSettings_LogData()
            '#End fix.

            ' PumpDown Setting.
            Dim LLPumpdownPressure As Hashtable = New Hashtable()
            LLPumpdownPressure.Add(LLA_CG_ON_FAST_ROUGH_VALVE_OPEN, txtCrossOverLLA.Text.Trim())
            LLPumpdownPressure.Add(LLA_CG_ON_SLOW_ROUGH_VALVE_OPEN, txtSlowRoughLLA.Text.Trim())
            bResult = AVPLib.ContainerData.SavePumpDown(LLPumpdownPressure, AVPLib.ConstEnum.LLPUMPDOWN_CONFIG)
            If (Not bResult) Then
                Utils.ShowAVPMessageBox("Failed to save LoadLock Pumpdown Settings.", "LoadLock Pumpdown Setting", MessageBoxIcon.Error, MessageBoxButtons.OK)
                LogUserEvent("Failed to save LoadLock Pumpdown Settings when apply pressure set point.", subSource)
                Return
            End If

            '<!-- Log
            LogUserEvent(txtCrossOverLLA, subSource)
            LogUserEvent(txtSlowRoughLLA, subSource)
            '-->

            Dim TMPumpdownPressure As Hashtable = New Hashtable()
            TMPumpdownPressure.Add(TM_CG_ON_FAST_ROUGH_VALVE_OPEN, txtCrossOverTM.Text.Trim())
            bResult = AVPLib.ContainerData.SavePumpDown(TMPumpdownPressure, AVPLib.ConstEnum.TMPUMPDOWN_CONFIG)
            If (Not bResult) Then
                Utils.ShowAVPMessageBox("Failed to save TM Pumpdown Settings.", "TM Pumpdown Setting", MessageBoxIcon.Error, MessageBoxButtons.OK)
                LogUserEvent("Failed to save TM Pumpdown Settings when apply pressure set point.", subSource)
                Return
            End If

            '<!-- Log
            LogUserEvent(txtCrossOverTM, subSource)
            '-->
            Dim CGConfig As Hashtable = New Hashtable()
            CGConfig.Add(TM_CG_TRIP_POINT, txtTMCGTripPoint.Text.Trim())
            CGConfig.Add(LLA_CG_TRIP_POINT, txtLLACGTripPoint.Text.Trim())
            CGConfig.Add(MP_CG_TRIP_POINT, txtMPCGTripPoint.Text.Trim())
            CGConfig.Add(LLA_TURBO_CG_TRIP_POINT, txtLLAForelineCGTripPoint.Text.Trim())
            CGConfig.Add(TM_TURBO_CG_TRIP_POINT, txtTMForelineCGTripPoint.Text.Trim())
            bResult = AVPLib.ContainerData.SaveCGConfig(CGConfig, AVPLib.ConstEnum.CG_CONFIG)

            If (Not bResult) Then
                Utils.ShowAVPMessageBox("Failed to save CG Config Settings", "CGConfig Setting", MessageBoxIcon.Error, MessageBoxButtons.OK)
                LogUserEvent("Failed to save CG Config Settings when apply pressure set point.", subSource)
                Return
            End If
            '#08/22/2011 
            '#-	From customer notes:  �No logging data for change in configureation/setup data (target limit/warning,�.)  
            '# User want to log when user changes any limits relating to target kwh page
            '#Begin fix:
            PumpdownSettings_LogData()
            '#End fix.

            ' Transfer Pressure Setting.
            Dim TransferPressureSetpoint As Hashtable = New Hashtable()
            Dim objEQ As AVPLib.DataManagerment.Equipment = Nothing
            Dim objEQType As AVPLib.SystemModule = Nothing

            TransferPressureSetpoint.Add(Equipments.LoadLockA.ToString() & TRANSFER_SET_POINT, txtTransferLLA.Text.Trim())
            objEQ = AVPLib.DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.LoadLockA.ToString())
            If objEQ IsNot Nothing Then
                Double.TryParse(txtTransferLLA.Text, objEQ.TransferSetPoint)
            End If

            TransferPressureSetpoint.Add(Equipments.CassettesModule.ToString() & TRANSFER_SET_POINT, txtTransferTM.Text.Trim())
            objEQ = AVPLib.DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString())
            If objEQ IsNot Nothing Then
                Double.TryParse(txtTransferTM.Text, objEQ.TransferSetPoint)
                Dim objTM As DataManagerment.CassettesModule = CType(objEQ, DataManagerment.CassettesModule)
                Double.TryParse(txtCGDifferentialPercent.Text, objTM.PressureDifferentialPercent)
                TransferPressureSetpoint.Add(ConstEnum.PRESSUREDIFFERENTIALPERCENT, txtCGDifferentialPercent.Text.Trim())
            End If

            TransferPressureSetpoint.Add(Equipments.Chamber1.ToString() & TRANSFER_SET_POINT, txtTransferPM1.Text.Trim())
            objEQ = AVPLib.DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber1.ToString())
            If objEQ IsNot Nothing Then
                Double.TryParse(txtTransferPM1.Text, objEQ.TransferSetPoint)
                objEQType = AVPLib.ContainerData.GetRobotConfig(objEQ.Name)

                If objEQType IsNot Nothing AndAlso objEQType.Type = SystemModule.ModuleType.IBE Then
                    If objEQ IsNot Nothing Then

                        'Save Etch Rate Control
                        bResult = AVPLib.Utils.SaveEtchRate(txtEtchRatePM1.Text.Trim(), ConstEnum.Equipments.Chamber1.ToString())
                        If (Not bResult) Then
                            Utils.ShowAVPMessageBox("Failed to save Etch Rate for PM1.", "General Setting", MessageBoxIcon.Error, MessageBoxButtons.OK)
                            Exit Sub
                        End If

                        LogUserEvent(txtEtchRatePM1, subSource)
                        Double.TryParse(txtEtchRatePM1.Text.Trim(), CType(objEQ, DataManagerment.IBEChamber).Etch_Rate)
                    End If
                End If
            End If

            TransferPressureSetpoint.Add(Equipments.Chamber2.ToString() & TRANSFER_SET_POINT, txtTransferPM2.Text.Trim())
            objEQ = AVPLib.DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber2.ToString())
            If objEQ IsNot Nothing Then
                Double.TryParse(txtTransferPM2.Text, objEQ.TransferSetPoint)
                objEQType = AVPLib.ContainerData.GetRobotConfig(objEQ.Name)

                If objEQType IsNot Nothing AndAlso objEQType.Type = SystemModule.ModuleType.IBE Then
                    If objEQ IsNot Nothing Then

                        'Save Etch Rate Control
                        bResult = AVPLib.Utils.SaveEtchRate(txtEtchRatePM2.Text.Trim(), ConstEnum.Equipments.Chamber2.ToString())
                        If (Not bResult) Then
                            Utils.ShowAVPMessageBox("Failed to save Etch Rate for PM2.", "General Setting", MessageBoxIcon.Error, MessageBoxButtons.OK)
                            Exit Sub
                        End If

                        LogUserEvent(txtEtchRatePM2, subSource)
                        Double.TryParse(txtEtchRatePM2.Text.Trim(), CType(objEQ, DataManagerment.IBEChamber).Etch_Rate)
                    End If
                End If
            End If

            TransferPressureSetpoint.Add(Equipments.Chamber3.ToString() & TRANSFER_SET_POINT, txtTransferPM3.Text.Trim())
            objEQ = AVPLib.DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber3.ToString())
            If objEQ IsNot Nothing Then
                Double.TryParse(txtTransferPM3.Text, objEQ.TransferSetPoint)
                objEQType = AVPLib.ContainerData.GetRobotConfig(objEQ.Name)

                If objEQType IsNot Nothing AndAlso objEQType.Type = SystemModule.ModuleType.IBE Then
                    If objEQ IsNot Nothing Then

                        'Save Etch Rate Control
                        bResult = AVPLib.Utils.SaveEtchRate(txtEtchRatePM3.Text.Trim(), ConstEnum.Equipments.Chamber3.ToString())
                        If (Not bResult) Then
                            Utils.ShowAVPMessageBox("Failed to save Etch Rate for PM3.", "General Setting", MessageBoxIcon.Error, MessageBoxButtons.OK)
                            Exit Sub
                        End If

                        LogUserEvent(txtEtchRatePM3, subSource)
                        Double.TryParse(txtEtchRatePM3.Text.Trim(), CType(objEQ, DataManagerment.IBEChamber).Etch_Rate)
                    End If
                End If
            End If

            Integer.TryParse(txtCryoPumpHour.Text, AVPLib.RobotConfigurationValues.CRYO_REGEN_HOURS_LIMIT)

            bResult = AVPLib.ContainerData.SaveCryoRegenHourLimit()
            bResult = bResult And AVPLib.ContainerData.SaveTransferPressureSetpoint(TransferPressureSetpoint)

            If (Not bResult) Then
                Utils.ShowAVPMessageBox("Failed to save Transfer Pressure SetPoint Settings.", "Transfer Pressure Setting", MessageBoxIcon.Error, MessageBoxButtons.OK)
                LogUserEvent("Failed to save Transfer Pressure SetPoint Settings.", subSource)
            Else
                Utils.ShowAVPMessageBox("Pressure SetPoint Settings saved successfully.", "Pressure SetPoint Setting", MessageBoxIcon.Information, MessageBoxButtons.OK)
                '#08/22/2011 
                '#-	From customer notes:  �No logging data for change in configureation/setup data (target limit/warning,�.)  
                '# User want to log when user changes any limits relating to target kwh page
                '#Begin fix:
                TransferSetPoint_LogData()
                '#End fix.

                '<!-- Log
                LogUserEvent(txtTransferLLA, subSource)
                LogUserEvent(txtTransferTM, subSource)
                LogUserEvent(txtCGDifferentialPercent, subSource)
                LogUserEvent(txtTransferPM1, subSource)
                LogUserEvent(txtTransferPM2, subSource)
                LogUserEvent(txtTransferPM3, subSource)
                LogUserEvent(txtCryoPumpHour, subSource)
                '-->                
                LogUserEvent(txtTMCGTripPoint, subSource)
                LogUserEvent(txtLLACGTripPoint, subSource)
                LogUserEvent(txtMPCGTripPoint, subSource)

                LogUserEvent(txtLLAForelineCGTripPoint, subSource)
                LogUserEvent(txtTMForelineCGTripPoint, subSource)
                '-->
                With m_stoStatusObject
                    .RequestStatus("txtTMCGTripPoint", txtTMCGTripPoint.Text)
                    .RequestStatus("txtLLACGTripPoint", txtLLACGTripPoint.Text)
                    .RequestStatus("txtMPCGTripPoint", txtMPCGTripPoint.Text)

                    If RobotConfigurationValues.LLA_TURBO_VISIBLE Then
                        .RequestStatus("txtLLAForelineCGTripPoint", txtLLAForelineCGTripPoint.Text)
                    End If

                    If RobotConfigurationValues.TMTURBO_VISIBLE Then
                        .RequestStatus("txtTMForelineCGTripPoint", txtTMForelineCGTripPoint.Text)
                    End If
                End With
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub txtAllowDecimalControl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                           Handles txtVentTM.Click, txtVentLLA.Click,
                                   txtSlowVentLLA.Click, txtSlowRoughLLA.Click, txtCrossOverTM.Click,
                                    txtCrossOverLLA.Click, tabPressureSetpoint.Click,
                                   txtCGDifferentialPercent.Click, txtCryoPumpHour.Click,
                                   txtTMForelineCGTripPoint.Click, txtTMCGTripPoint.Click,
                                   txtMPCGTripPoint.Click, txtLLAForelineCGTripPoint.Click, txtLLACGTripPoint.Click, txtDelayTimeAfterProcessComplete.Click
        GetUserInput(sender, True)
    End Sub
    Private Sub txtAllowDecimalControl_Click2(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                               Handles txtTransferTM.Click, txtTransferPM3.Click, txtTransferPM2.Click,
                                       txtTransferPM1.Click, txtTransferLLA.Click
        GetUserInput(sender, True, True)
    End Sub
    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-08-22</date>
    ''' </author>
    ''' <summary>
    '''  
    ''' </summary>
    Private Sub VentSetPointTextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVentLLA.TextChanged, txtVentTM.TextChanged
        Try
            Dim ctrl As TextBox = CType(sender, TextBox)
            Select Case ctrl.Name
                Case txtVentLLA.Name
                    m_iVentSetPointTextChanged = m_iVentSetPointTextChanged Or 1
                Case txtVentTM.Name
                    m_iVentSetPointTextChanged = m_iVentSetPointTextChanged Or 4
                Case Else

            End Select
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-08-22</date>
    ''' </author>
    ''' <summary>
    '''  
    ''' </summary>
    Private Sub CrossOverSetPointTextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCrossOverTM.TextChanged, txtCrossOverLLA.TextChanged
        Try
            Dim ctrl As TextBox = CType(sender, TextBox)
            Select Case ctrl.Name
                Case txtCrossOverLLA.Name
                    m_iCrossOverSetPointTextChanged = m_iCrossOverSetPointTextChanged Or 1
                Case txtCrossOverTM.Name
                    m_iCrossOverSetPointTextChanged = m_iCrossOverSetPointTextChanged Or 4
                Case Else

            End Select
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-08-22</date>
    ''' </author>
    ''' <summary>
    '''  
    ''' </summary>
    Private Sub SlowRoughSetPointTextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSlowRoughLLA.TextChanged
        Try
            Dim ctrl As TextBox = CType(sender, TextBox)
            Select Case ctrl.Name
                Case txtSlowRoughLLA.Name
                    m_iSlowRoughSetPointTextChanged = m_iSlowRoughSetPointTextChanged Or 1
                Case Else

            End Select
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-08-22</date>
    ''' </author>
    ''' <summary>
    '''  
    ''' </summary>
    Private Sub SlowVentSetPointTextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSlowVentLLA.TextChanged
        Try
            Dim ctrl As TextBox = CType(sender, TextBox)
            Select Case ctrl.Name
                Case txtSlowVentLLA.Name
                    m_iSlowVentSetPointTextChanged = m_iSlowVentSetPointTextChanged Or 1
                Case Else

            End Select
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

#End Region

#Region "Elevator Setting"
    Private Sub btnApplyElevatorSetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                                                                Handles btnApplyElevatorSetting.Click
        Try
            Dim bResult As Boolean = False
            Dim subSource As String = "Elevator"

            If btnApplyElevatorSetting.Text.Trim() = STR_Edit Then
                SetElevatorSettingEnable(True)
                Return
            End If

            LogUserEvent("Apply Button Clicked", subSource)

            Dim objLLAElevatorController As AVPLib.Business.LLElevatorController = CType(CType(AVPLib.Business.ControllerManager.GetController(AVPLib.ConstEnum.Equipments.LoadLockA.ToString()), AVPLib.Business.LoadLockController).ChildController.Item("LLElevator"), AVPLib.Business.LLElevatorController)
            ' LLAElevator.
            Dim LLAElevatorSettings As Hashtable = New Hashtable()

            Dim strNumberOfSlotsLLA_Old As String = AVPLib.ContainerData.GetLLElevatorConfig(NUMBER_OF_SLOT)
            Dim strNumberOfSlotsLLA_New As String = txtNumberOfSlotsLLA.Text.Trim()
            If (strNumberOfSlotsLLA_Old <> strNumberOfSlotsLLA_New) Then
                objLLAElevatorController.DoTask(CONFIG_NUMBER_OF_SLOT & " " & strNumberOfSlotsLLA_New)
            End If
            LLAElevatorSettings.Add(NUMBER_OF_SLOT, strNumberOfSlotsLLA_New)

            Dim strTravelLengthLLA_Old As String = AVPLib.ContainerData.GetLLElevatorConfig(TRAVEL_LENGTH)
            Dim strTravelLengthLLA_New As String = txtTravelLengthLLA.Text.Trim()
            If (strTravelLengthLLA_Old <> strTravelLengthLLA_New) Then
                objLLAElevatorController.DoTask(CONFIG_TRAVEL_LENGTH & " " & strTravelLengthLLA_New)
            End If
            LLAElevatorSettings.Add(TRAVEL_LENGTH, strTravelLengthLLA_New)

            Dim strPitchLLA_Old As String = AVPLib.ContainerData.GetLLElevatorConfig(PITCH)
            Dim strPitchLLA_New As String = txtPitchLLA.Text.Trim()
            If (strPitchLLA_Old <> strPitchLLA_New) Then
                objLLAElevatorController.DoTask(CONFIG_PITCH & " " & strPitchLLA_New)
            End If
            LLAElevatorSettings.Add(PITCH, strPitchLLA_New)

            Dim strBaseOffsetLLA_Old As String = AVPLib.ContainerData.GetLLElevatorConfig(BASE_OFFSET)
            Dim strBaseOffsetLLA_New As String = txtBaseOffsetLLA.Text.Trim()
            If (strBaseOffsetLLA_Old <> strBaseOffsetLLA_New) Then
                objLLAElevatorController.DoTask(CONFIG_BASE_OFFSET & " " & strBaseOffsetLLA_New)
            End If
            LLAElevatorSettings.Add(BASE_OFFSET, strBaseOffsetLLA_New)

            Dim strFindBiasLLA_Old As String = AVPLib.ContainerData.GetLLElevatorConfig(FIND_BIAS)
            Dim strFindBiasLLA_New As String = txtFindBiasLLA.Text.Trim()
            If (strFindBiasLLA_Old <> strFindBiasLLA_New) Then
                objLLAElevatorController.DoTask(CONFIG_FIND_BIAS & " " & strFindBiasLLA_New)
            End If
            LLAElevatorSettings.Add(FIND_BIAS, strFindBiasLLA_New)

            bResult = AVPLib.ContainerData.SaveLLElevatorConfig(LLAElevatorSettings, Equipments.LLAElevator.ToString())

            If (Not bResult) Then
                Utils.ShowAVPMessageBox("Failed to save LLA Elevator Settings.", Me.tabElevatorSetting.Text, MessageBoxIcon.Error, MessageBoxButtons.OK)
                LogUserEvent("Failed to save LLA Elevator Settings.", subSource)
                Return
            End If

            '<!-- Log
            LogUserEvent(txtNumberOfSlotsLLA, subSource)
            LogUserEvent(txtTravelLengthLLA, subSource)
            LogUserEvent(txtPitchLLA, subSource)
            LogUserEvent(txtBaseOffsetLLA, subSource)
            LogUserEvent(txtFindBiasLLA, subSource)
            '-->

            'set config
            bResult = SetConfigToDevice()
            If (bResult) Then
                SetElevatorSettingEnable(False)
            End If

            If bResult Then
                Utils.ShowAVPMessageBox("LL Elevator Settings saved successfully.", Me.tabElevatorSetting.Text, MessageBoxIcon.Information, MessageBoxButtons.OK)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name>Tinh Le</name>
    '''     <date> 2020-11-10 </date>
    ''' </author>
    ''' <summary>
    '''  SetElevatorSettingEnable
    ''' </summary>
    Private Sub SetElevatorSettingEnable(ByVal enable As Boolean)
        If enable Then
            btnApplyElevatorSetting.Text = STR_Apply
        Else
            btnApplyElevatorSetting.Text = STR_Edit
            RobotConfig.SetForeColor()
        End If

        btnCancelElevatorSetting.Visible = enable
        gbxLLASetting.Enabled = enable
        gbxRobot.Enabled = enable
    End Sub

    ''' <author>
    '''    	<name>Tinh Le</name>
    '''    	<date>2020-11-10</date>
    ''' </author>
    ''' <summary>
    ''' set config to device
    ''' </summary>
    Private Function SetConfigToDevice() As Boolean
        ''sent config robot to device
        Dim robotDataNew As StoredConfigData = RobotConfig.GetData()
        Dim dataRobotChange As New Dictionary(Of String, String)
        Dim bResult As Boolean = True

        Dim robotDataOld As AVPLib.DataManagerment.Robot = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Robot.ToString())
        Dim ctlRobot As Business.RobotController = CType(AVPLib.Business.ControllerManager.GetController(ConstEnum.Equipments.Robot.ToString()), AVPLib.Business.RobotController)
        If robotDataOld IsNot Nothing Then
            Dim strCmd As String = String.Empty
            robotDataOld.RobotSystemSetup = dataRobotChange

            For Each key As String In robotDataOld.RobotConfigValues.Keys
                If robotDataOld.RobotConfigValues(key) <> robotDataNew.Data(key) Then
                    Select Case key
                        'cmd: SET STN 1 ALL R T Z Lo slot P
                        Case R_STN1, T_STN1, Z_STN1, LOWER_STN1, PITCH_STN1
                            If Not dataRobotChange.ContainsKey("STN1") Then
                                strCmd = SetStationParameters(1, robotDataNew.Data(R_STN1), robotDataNew.Data(T_STN1),
                                robotDataNew.Data(Z_STN1), robotDataNew.Data(LOWER_STN1), 0, robotDataNew.Data(PITCH_STN1))

                                dataRobotChange.Add("STN1", strCmd)
                                dataRobotChange.Add("STORE_STN1", String.Format(STORE_STN_X_ALL, "STN 1"))
                            End If

                            'cmd: SET STN 2 ALL R T Z Lo slot P
                        Case R_STN2, T_STN2, Z_STN2, LOWER_STN2, PITCH_STN2
                            If Not dataRobotChange.ContainsKey("STN2") Then
                                strCmd = SetStationParameters(2, robotDataNew.Data(R_STN2), robotDataNew.Data(T_STN2),
                                robotDataNew.Data(Z_STN2), robotDataNew.Data(LOWER_STN2), 0, robotDataNew.Data(PITCH_STN2))

                                dataRobotChange.Add("STN2", strCmd)
                                dataRobotChange.Add("STORE_STN2", String.Format(STORE_STN_X_ALL, "STN 2"))
                            End If

                            'cmd: SET STN 3 ALL R T Z Lo slot P
                        Case R_STN3, T_STN3, Z_STN3, LOWER_STN3, PITCH_STN3
                            If Not dataRobotChange.ContainsKey("STN3") Then
                                strCmd = SetStationParameters(3, robotDataNew.Data(R_STN3), robotDataNew.Data(T_STN3),
                                robotDataNew.Data(Z_STN3), robotDataNew.Data(LOWER_STN3), 0, robotDataNew.Data(PITCH_STN3))

                                dataRobotChange.Add("STN3", strCmd)
                                dataRobotChange.Add("STORE_STN3", String.Format(STORE_STN_X_ALL, "STN 3"))
                            End If

                            'cmd: SET STN 4 ALL R T Z Lo slot P
                        Case R_STN4, T_STN4, Z_STN4, LOWER_STN4, PITCH_STN4
                            If Not dataRobotChange.ContainsKey("STN4") Then
                                strCmd = SetStationParameters(4, robotDataNew.Data(R_STN4), robotDataNew.Data(T_STN4),
                                robotDataNew.Data(Z_STN4), robotDataNew.Data(LOWER_STN4), 0, robotDataNew.Data(PITCH_STN4))

                                dataRobotChange.Add("STN4", strCmd)
                                dataRobotChange.Add("STORE_STN4", String.Format(STORE_STN_X_ALL, "STN 4"))
                            End If

                            'cmd: SET STN 5 ALL R T Z Lo slot P
                        Case R_STN5, T_STN5, Z_STN5, LOWER_STN5, PITCH_STN5
                            If Not dataRobotChange.ContainsKey("STN5") Then
                                strCmd = SetStationParameters(5, robotDataNew.Data(R_STN5), robotDataNew.Data(T_STN5),
                                robotDataNew.Data(Z_STN5), robotDataNew.Data(LOWER_STN5), 0, robotDataNew.Data(PITCH_STN5))

                                dataRobotChange.Add("STN5", strCmd)
                                dataRobotChange.Add("STORE_STN5", String.Format(STORE_STN_X_ALL, "STN 5"))
                            End If

                            'cmd: SET STN 6 ALL R T Z Lo slot P
                        Case R_STN6, T_STN6, Z_STN6, LOWER_STN6, PITCH_STN6
                            If Not dataRobotChange.ContainsKey("STN6") Then
                                strCmd = SetStationParameters(6, robotDataNew.Data(R_STN6), robotDataNew.Data(T_STN6),
                                robotDataNew.Data(Z_STN6), robotDataNew.Data(LOWER_STN6), 0, robotDataNew.Data(PITCH_STN6))

                                dataRobotChange.Add("STN6", strCmd)
                                dataRobotChange.Add("STORE_STN6", String.Format(STORE_STN_X_ALL, "STN 6"))
                            End If

                            'cmd: SET STN 7 ALL R T Z Lo slot P
                        Case R_STN7, T_STN7, Z_STN7, LOWER_STN7, PITCH_STN6
                            If Not dataRobotChange.ContainsKey("STN7") Then
                                strCmd = SetStationParameters(7, robotDataNew.Data(R_STN7), robotDataNew.Data(T_STN7),
                                robotDataNew.Data(Z_STN7), robotDataNew.Data(LOWER_STN7), 0, robotDataNew.Data(PITCH_STN7))

                                dataRobotChange.Add("STN7", strCmd)
                                dataRobotChange.Add("STORE_STN7", String.Format(STORE_STN_X_ALL, "STN 7"))
                            End If

                            'cmd: SET STN 8 ALL R T Z Lo slot P
                        Case R_STN8, T_STN8, Z_STN8, LOWER_STN8, PITCH_STN8
                            If Not dataRobotChange.ContainsKey("STN8") Then
                                strCmd = SetStationParameters(8, robotDataNew.Data(R_STN8), robotDataNew.Data(T_STN8),
                                robotDataNew.Data(Z_STN8), robotDataNew.Data(LOWER_STN8), 0, robotDataNew.Data(PITCH_STN8))

                                dataRobotChange.Add("STN8", strCmd)
                                dataRobotChange.Add("STORE_STN8", String.Format(STORE_STN_X_ALL, "STN 8"))
                            End If

                            'cmd: SET STN 1 ALL R T Z Lo slot P
                        Case R_STN9, T_STN9, Z_STN9, LOWER_STN9, PITCH_STN9
                            If Not dataRobotChange.ContainsKey("STN9") Then
                                strCmd = SetStationParameters(9, robotDataNew.Data(R_STN9), robotDataNew.Data(T_STN9),
                                robotDataNew.Data(Z_STN9), robotDataNew.Data(LOWER_STN9), 0, robotDataNew.Data(PITCH_STN9))
                                dataRobotChange.Add("STN9", strCmd)
                                dataRobotChange.Add("STORE_STN9", String.Format(STORE_STN_X_ALL, "STN 9"))
                            End If

                            'cmd: SET STN 10 ALL R T Z Lo slot P
                        Case R_STN10, T_STN10, Z_STN10, LOWER_STN10, PITCH_STN10
                            If Not dataRobotChange.ContainsKey("STN10") Then
                                strCmd = SetStationParameters(10, robotDataNew.Data(R_STN10), robotDataNew.Data(T_STN10),
                                robotDataNew.Data(Z_STN10), robotDataNew.Data(LOWER_STN10), 0, robotDataNew.Data(PITCH_STN10))

                                dataRobotChange.Add("STN10", strCmd)
                                dataRobotChange.Add("STORE_STN10", String.Format(STORE_STN_X_ALL, "STN 10"))
                            End If

                            'cmd: SET HACC ALL R T Z
                        Case R_HACC, T_HACC, Z_HACC
                            If Not dataRobotChange.ContainsKey(STR_HACC) Then
                                strCmd = ctlRobot.SetACCandVELParameters(STR_HACC, robotDataNew.Data(R_HACC).ToString(), robotDataNew.Data(T_HACC).ToString(), robotDataNew.Data(Z_HACC).ToString())

                                dataRobotChange.Add(STR_HACC, strCmd)

                                'store gui
                                robotDataOld.R_HACC = robotDataNew.Data(R_HACC).ToString()
                                robotDataOld.T_HACC = robotDataNew.Data(T_HACC).ToString()
                                robotDataOld.Z_HACC = robotDataNew.Data(Z_HACC).ToString()
                            End If

                            'cmd: SET PACC ALL R T Z
                        Case R_PACC, T_PACC, Z_PACC
                            If Not dataRobotChange.ContainsKey(STR_PACC) Then
                                strCmd = ctlRobot.SetACCandVELParameters(STR_PACC, robotDataNew.Data(R_PACC).ToString(), robotDataNew.Data(T_PACC).ToString(), robotDataNew.Data(Z_PACC).ToString())

                                dataRobotChange.Add(STR_PACC, strCmd)

                                'store gui
                                robotDataOld.R_PACC = robotDataNew.Data(R_PACC).ToString()
                                robotDataOld.T_PACC = robotDataNew.Data(T_PACC).ToString()
                                robotDataOld.Z_PACC = robotDataNew.Data(Z_PACC).ToString()
                            End If

                            'cmd: SET WACC ALL R T Z
                        Case R_WACC, T_WACC, Z_WACC
                            If Not dataRobotChange.ContainsKey(STR_WACC) Then
                                strCmd = ctlRobot.SetACCandVELParameters(STR_WACC, robotDataNew.Data(R_WACC).ToString(), robotDataNew.Data(T_WACC).ToString(), robotDataNew.Data(Z_WACC).ToString())

                                dataRobotChange.Add(STR_WACC, strCmd)

                                'store gui
                                robotDataOld.R_WACC = robotDataNew.Data(R_WACC).ToString()
                                robotDataOld.T_WACC = robotDataNew.Data(T_WACC).ToString()
                                robotDataOld.Z_WACC = robotDataNew.Data(Z_WACC).ToString()
                            End If

                            'cmd: SET HVEL ALL R T Z
                        Case R_HVEL, T_HVEL, Z_HVEL
                            If Not dataRobotChange.ContainsKey(STR_HVEL) Then
                                strCmd = ctlRobot.SetACCandVELParameters(STR_HVEL, robotDataNew.Data(R_HVEL).ToString(), robotDataNew.Data(T_HVEL).ToString(), robotDataNew.Data(Z_HVEL).ToString())

                                dataRobotChange.Add(STR_HVEL, strCmd)

                                'store gui
                                robotDataOld.R_HVEL = robotDataNew.Data(R_HVEL).ToString()
                                robotDataOld.T_HVEL = robotDataNew.Data(T_HVEL).ToString()
                                robotDataOld.Z_HVEL = robotDataNew.Data(Z_HVEL).ToString()
                            End If

                            'cmd: SET PVEL ALL R T Z
                        Case R_PVEL, T_PVEL, Z_PVEL
                            If Not dataRobotChange.ContainsKey(STR_PVEL) Then
                                strCmd = ctlRobot.SetACCandVELParameters(STR_PVEL, robotDataNew.Data(R_PVEL).ToString(), robotDataNew.Data(T_PVEL).ToString(), robotDataNew.Data(Z_PVEL).ToString())

                                dataRobotChange.Add(STR_PVEL, strCmd)

                                'store gui
                                robotDataOld.R_PVEL = robotDataNew.Data(R_PVEL).ToString()
                                robotDataOld.T_PVEL = robotDataNew.Data(T_PVEL).ToString()
                                robotDataOld.Z_PVEL = robotDataNew.Data(Z_PVEL).ToString()
                            End If

                            'cmd: SET WVEL ALL R T Z
                        Case R_WVEL, T_WVEL, Z_WVEL
                            If Not dataRobotChange.ContainsKey(STR_WVEL) Then
                                strCmd = ctlRobot.SetACCandVELParameters(STR_WVEL, robotDataNew.Data(R_WVEL).ToString(), robotDataNew.Data(T_WVEL).ToString(), robotDataNew.Data(Z_WVEL).ToString())

                                dataRobotChange.Add(STR_WVEL, strCmd)

                                'store gui
                                robotDataOld.R_WVEL = robotDataNew.Data(R_WVEL).ToString()
                                robotDataOld.T_WVEL = robotDataNew.Data(T_WVEL).ToString()
                                robotDataOld.Z_WVEL = robotDataNew.Data(Z_WVEL).ToString()
                            End If
                    End Select
                End If
            Next

            If (dataRobotChange.Count > 0) Then

                robotDataOld.RobotSystemSetup = dataRobotChange
                Me.m_stoStatusObject.RequestStatus("SetConfigRobot", String.Empty)

                'save config robot
                AVPLib.Business.ControllerManager.SaveStoreGui()

                'update GUI
                btnApplyElevatorSetting.Text = "Applying"
                btnApplyElevatorSetting.Enabled = False
                btnCancelElevatorSetting.Visible = False
                gbxLLASetting.Enabled = False
                gbxRobot.Enabled = False
                bResult = False
            End If
        End If
        Return bResult
    End Function

    ''' <author>
    '''    	<name>Tinh Le</name>
    '''    	<date> 2020-06-01 </date>
    ''' </author>
    ''' <summary>
    ''' Set Station Parameters
    ''' </summary>
    Private Function SetStationParameters(ByVal StationCode As String, ByVal Wafer_Rstation As String, ByVal Wafer_Tstation As String, ByVal AlStn_Z As String, ByVal LOWER As String, ByVal NSLOTS As String, ByVal PITCH As String) As String
        AVPLib.Log.coreLogger.Info("Enter SetStationParameters")
        Dim objRobot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())
        Dim strCommand As String = String.Concat(New String() {"SET STN ", StationCode, " R ", Wafer_Rstation, " T ", Wafer_Tstation, " Z ", AlStn_Z, " LOWER ", LOWER, " NSLOTS ", NSLOTS, " PITCH ", PITCH})
        Return strCommand
    End Function

    Private Sub txtNotAllowDecimalControl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                            Handles txtTravelLengthLLA.Click, _
                                    txtNumberOfSlotsLLA.Click, txtPitchLLA.Click, _
                                    txtFindBiasLLA.Click, txtBaseOffsetLLA.Click, txtMesaValveTO.Click, _
                                  txtHivacTO.Click, txtSystemCheckSensor.Click, txtLLASlowRoughTO.Click, _
                                  txtLLAFastRoughTO.Click, txtLLRoughValveTO.Click, txtLLContinuePumpDown.Click, _
                                  txtLLDelayTimeTurnOnIG.Click, txtLLASlowVentTO.Click, txtLLAFastVentTO.Click, _
                                  txtLLVentValveTO.Click, txtLLContinueVent.Click, txtTMRoughTO.Click, _
                                  txtTMContinuePumpDown.Click, txtTMDelayTimeTurnOnIG.Click, txtTMVentTO.Click, txtTMContinueVent.Click, _
                                  txtTMVentValveTO.Click, txtIGOnOffTO.Click, txtAutoLog.Click
        GetUserInput(sender, False)
    End Sub
#End Region

#Region "Shield - KWH Setting"
    Private Sub txtTarMaterialPM1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                              Handles txtTarMaterialPM1.TextChanged, txtTarMaterialPM2.TextChanged, _
                                                      txtTarMaterialPM3.TextChanged
        Try
            Dim objPanel As PVDPanel = Nothing

            Select Case CType(sender, TextBox).Name
                Case txtTarMaterialPM1.Name
                    If ContainerForm.ChamberPanel(Equipments.Chamber1.ToString()).ChamberType = SystemModule.ModuleType.PVD Then
                        objPanel = ContainerForm.ChamberPanel(Equipments.Chamber1.ToString())
                    End If
                Case txtTarMaterialPM2.Name
                    If ContainerForm.ChamberPanel(Equipments.Chamber2.ToString()).ChamberType = SystemModule.ModuleType.PVD Then
                        objPanel = ContainerForm.ChamberPanel(Equipments.Chamber2.ToString())
                    End If
                Case txtTarMaterialPM3.Name
                    If ContainerForm.ChamberPanel(Equipments.Chamber3.ToString()).ChamberType = SystemModule.ModuleType.PVD Then
                        objPanel = ContainerForm.ChamberPanel(Equipments.Chamber3.ToString())
                    End If
            End Select
            If objPanel IsNot Nothing Then
                objPanel.TarControl.lblTargetMaterial.Text = "< " & CType(sender, TextBox).Text & " >"
                Dim objEQ As AVPLib.DataManagerment.PVDChamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(objPanel.Name)
                If objEQ IsNot Nothing Then
                    objEQ.TargetMaterial = CType(sender, TextBox).Text
                    TargetMaterials_LogData(AVPLib.Utils.chamberID2ChamberName(objPanel.Name), objEQ.TargetMaterial)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-08-22</date>
    ''' </author>
    ''' <summary>
    '''  Log TargetMaterials changed to LotDataLog and LogAlarmAndEvent
    ''' </summary>
    Private Sub TargetMaterials_LogData(ByVal strChamberName As String, ByVal strValue As String)
        AddLotDatalog(strChamberName, "Target Material Changed To: " & strValue)
        LogUserEvent(strChamberName & ": Target Material Changed To: " & strValue)
    End Sub

    Private Sub txtTarMaterialPM1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                        Handles txtTarMaterialPM3.Click, _
                                        txtTarMaterialPM2.Click, txtTarMaterialPM1.Click
        Try
            'start Popup Panel
            Dim strShieldsQuartz As String = String.Empty
            If CType(sender, TextBox).Name.Contains("PM1") Then
                If PM1ChamberType = SystemModule.ModuleType.PVD4 OrElse PM1ChamberType = SystemModule.ModuleType.PVD5T Then
                    Me.PM1TargetPSConfigPopUpPanel.ShowDialog(AVPRobotMain)
                    Exit Try
                End If
                strShieldsQuartz = "PM1_" & PM1ChamberType.ToString()
            ElseIf CType(sender, TextBox).Name.Contains("PM2") Then
                If PM2ChamberType = SystemModule.ModuleType.PVD4 OrElse PM2ChamberType = SystemModule.ModuleType.PVD5T Then
                    Me.PM2TargetPSConfigPopUpPanel.ShowDialog(AVPRobotMain)
                    Exit Try
                End If
                strShieldsQuartz = "PM2_" & PM2ChamberType.ToString()
            ElseIf CType(sender, TextBox).Name.Contains("PM3") Then
                If PM3ChamberType = SystemModule.ModuleType.PVD4 OrElse PM3ChamberType = SystemModule.ModuleType.PVD5T Then
                    Me.PM3TargetPSConfigPopUpPanel.ShowDialog(AVPRobotMain)
                    Exit Try
                End If
                strShieldsQuartz = "PM3_" & PM3ChamberType.ToString()
            End If
            '''
            Dim Source As String = "SystemSetup.TarMaterial"
            Dim frm As New KeyPad
            Dim Title As String = AVPLib.ContainerData.GetMessageText(Source)
            Dim value As String = CType(sender, TextBox).Text
            Dim oldValue As String = value

            StoreValueBeforeChanged(sender)
            If frm.DisplayKeypad(value, Title, False) = MsgBoxResult.Ok Then
                If value.Length > 12 Then
                    CType(sender, TextBox).Text = oldValue
                    Utils.ShowAVPMessageBox("Your input value is not valid", _
                                            "Target Material Input Error", _
                                             MessageBoxIcon.Exclamation, _
                                             MessageBoxButtons.OK)
                Else
                    CType(sender, TextBox).Text = value
                    SaveDataToAVPConfig(sender, value)
                    LogUserEvent(sender, "", strShieldsQuartz)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub SaveDataToAVPConfig(ByVal sender As System.Object, ByVal value As String)
        Try
            Dim objPanel As AVPLib.SystemModule = Nothing
            Dim objChamber As SystemModule = Nothing
            Select Case CType(sender, TextBox).Name
                Case txtTarMaterialPM1.Name
                    AVPLib.Utils.SaveTarXMaterial(sender, value, Equipments.Chamber1.ToString())
                Case txtTarMaterialPM2.Name
                    AVPLib.Utils.SaveTarXMaterial(sender, value, Equipments.Chamber2.ToString())
                Case txtTarMaterialPM3.Name
                    AVPLib.Utils.SaveTarXMaterial(sender, value, Equipments.Chamber3.ToString())
                    ''
                Case txtWarningKWH_PM1.Name
                    AVPLib.Utils.SavePMWarningLimitX(sender, value, Equipments.Chamber1.ToString())
                Case txtWarningKWH_PM2.Name
                    AVPLib.Utils.SavePMWarningLimitX(sender, value, Equipments.Chamber2.ToString())
                Case txtWarningKWH_PM3.Name
                    AVPLib.Utils.SavePMWarningLimitX(sender, value, Equipments.Chamber3.ToString())
                    ''
                Case txtLimitsKWH_PM1.Name
                    AVPLib.Utils.SavePMAlarmLimitX(sender, value, Equipments.Chamber1.ToString())
                Case txtLimitsKWH_PM2.Name
                    AVPLib.Utils.SavePMAlarmLimitX(sender, value, Equipments.Chamber2.ToString())
                Case txtLimitsKWH_PM3.Name
                    AVPLib.Utils.SavePMAlarmLimitX(sender, value, Equipments.Chamber3.ToString())

                Case txtLimitShieldsPM1.Name
                    AVPLib.Utils.SaveConfigItem(ConstEnum.PM_TAG_CONFIG.ShieldsQuartzLimit.ToString(), value, Equipments.Chamber1.ToString())
                Case txtLimitShieldsPM2.Name
                    AVPLib.Utils.SaveConfigItem(ConstEnum.PM_TAG_CONFIG.ShieldsQuartzLimit.ToString(), value, Equipments.Chamber2.ToString())
                Case txtLimitShieldsPM3.Name
                    AVPLib.Utils.SaveConfigItem(ConstEnum.PM_TAG_CONFIG.ShieldsQuartzLimit.ToString(), value, Equipments.Chamber3.ToString())

                Case txtWarningShieldsPM1.Name
                    AVPLib.Utils.SaveConfigItem(ConstEnum.PM_TAG_CONFIG.ShieldsQuartzWarning.ToString(), value, Equipments.Chamber1.ToString())
                Case txtWarningShieldsPM2.Name
                    AVPLib.Utils.SaveConfigItem(ConstEnum.PM_TAG_CONFIG.ShieldsQuartzWarning.ToString(), value, Equipments.Chamber2.ToString())
                Case txtWarningShieldsPM3.Name
                    AVPLib.Utils.SaveConfigItem(ConstEnum.PM_TAG_CONFIG.ShieldsQuartzWarning.ToString(), value, Equipments.Chamber3.ToString())

                Case txtMaxShieldsPM1.Name
                    AVPLib.Utils.SaveConfigItem(ConstEnum.PM_TAG_CONFIG.Max_KWH_ShieldsQuartz.ToString(), value, Equipments.Chamber1.ToString())
                Case txtMaxShieldsPM2.Name
                    AVPLib.Utils.SaveConfigItem(ConstEnum.PM_TAG_CONFIG.Max_KWH_ShieldsQuartz.ToString(), value, Equipments.Chamber2.ToString())
                Case txtMaxShieldsPM3.Name
                    AVPLib.Utils.SaveConfigItem(ConstEnum.PM_TAG_CONFIG.Max_KWH_ShieldsQuartz.ToString(), value, Equipments.Chamber3.ToString())

            End Select
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub txtWarningKWH_PM1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim objChamber As SystemModule = Nothing

            Select Case CType(sender, TextBox).Name
                Case txtWarningKWH_PM1.Name
                    objChamber = AVPLib.ContainerData.GetRobotConfig(ConstEnum.Equipments.Chamber1.ToString())
                    If objChamber.Type = SystemModule.ModuleType.IBE Then
                        objChamber.SourceUsageTimeWarning = CDbl(txtWarningKWH_PM1.Text)
                        AddLotDatalog(ConstEnum.PM1, "Warning Source Usage Changed To: " & txtWarningKWH_PM1.Text)
                        'LogUserEvent(ConstEnum.PM1 & ": Warning Source Usage Changed To: " & txtWarningKWH_PM1.Text)
                    ElseIf objChamber.Type = SystemModule.ModuleType.PVD Then
                        objChamber.Warning_KWH = CDbl(txtWarningKWH_PM1.Text)
                        AddLotDatalog(ConstEnum.PM1, "Warning KWH Changed To: " & txtWarningKWH_PM1.Text)
                        'LogUserEvent(ConstEnum.PM1 & ": Warning KWH Changed To: " & txtWarningKWH_PM1.Text)
                    End If

                Case txtWarningKWH_PM2.Name
                    objChamber = AVPLib.ContainerData.GetRobotConfig(ConstEnum.Equipments.Chamber2.ToString())
                    If objChamber.Type = SystemModule.ModuleType.IBE Then
                        objChamber.SourceUsageTimeWarning = CDbl(txtWarningKWH_PM2.Text)
                        AddLotDatalog(ConstEnum.PM2, "Warning Source Usage Changed To: " & txtWarningKWH_PM2.Text)
                        'LogUserEvent(ConstEnum.PM2 & ": Warning Source Usage Changed To: " & txtWarningKWH_PM2.Text)
                    ElseIf objChamber.Type = SystemModule.ModuleType.PVD Then
                        objChamber.Warning_KWH = CDbl(txtWarningKWH_PM2.Text)
                        AddLotDatalog(ConstEnum.PM2, "Warning KWH Changed To: " & txtWarningKWH_PM2.Text)
                        'LogUserEvent(ConstEnum.PM2 & ": Warning KWH Changed To: " & txtWarningKWH_PM2.Text)
                    End If

                Case txtWarningKWH_PM3.Name
                    objChamber = AVPLib.ContainerData.GetRobotConfig(ConstEnum.Equipments.Chamber3.ToString())
                    If objChamber.Type = SystemModule.ModuleType.IBE Then
                        objChamber.SourceUsageTimeWarning = CDbl(txtWarningKWH_PM3.Text)
                        AddLotDatalog(ConstEnum.PM3, "Warning Source Usage Changed To: " & txtWarningKWH_PM3.Text)
                        'LogUserEvent(ConstEnum.PM3 & ": Warning Source Usage Changed To: " & txtWarningKWH_PM3.Text)
                    ElseIf objChamber.Type = SystemModule.ModuleType.PVD Then
                        objChamber.Warning_KWH = CDbl(txtWarningKWH_PM3.Text)
                        AddLotDatalog(ConstEnum.PM3, "Warning KWH Changed To: " & txtWarningKWH_PM3.Text)
                        'LogUserEvent(ConstEnum.PM3 & ": Warning KWH Changed To: " & txtWarningKWH_PM3.Text)
                    End If

            End Select

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub txtLimitsKWH_PM1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim objChamber As SystemModule = Nothing
            Select Case CType(sender, TextBox).Name
                Case txtLimitsKWH_PM1.Name
                    objChamber = AVPLib.ContainerData.GetRobotConfig(ConstEnum.Equipments.Chamber1.ToString())
                    If objChamber.Type = SystemModule.ModuleType.PVD Then
                        objChamber.Alarm_KWH = CDbl(txtLimitsKWH_PM1.Text)
                        AddLotDatalog(ConstEnum.PM1, "Limit KWH Changed To: " & txtLimitsKWH_PM1.Text)
                        'LogUserEvent(ConstEnum.PM1 & ": Limit KWH Changed To: " & txtLimitsKWH_PM1.Text)
                    ElseIf objChamber.Type = SystemModule.ModuleType.IBE Then
                        objChamber.SourceUsageTimeLimit = CDbl(txtLimitsKWH_PM1.Text)
                        AddLotDatalog(ConstEnum.PM1, "Limit Source Usage Changed To: " & txtLimitsKWH_PM1.Text)
                        'LogUserEvent(ConstEnum.PM1 & ": Limit Source Usage Changed To: " & txtLimitsKWH_PM1.Text)
                    End If

                Case txtLimitsKWH_PM2.Name
                    objChamber = AVPLib.ContainerData.GetRobotConfig(ConstEnum.Equipments.Chamber2.ToString())
                    If objChamber.Type = SystemModule.ModuleType.PVD Then
                        objChamber.Alarm_KWH = CDbl(txtLimitsKWH_PM2.Text)
                        AddLotDatalog(ConstEnum.PM2, "Limit KWH Changed To: " & txtLimitsKWH_PM2.Text)
                        'LogUserEvent(ConstEnum.PM2 & ": Limit KWH Changed To: " & txtLimitsKWH_PM2.Text)
                    ElseIf objChamber.Type = SystemModule.ModuleType.IBE Then
                        objChamber.SourceUsageTimeLimit = CDbl(txtLimitsKWH_PM2.Text)
                        AddLotDatalog(ConstEnum.PM2, "Limit Source Usage Changed To: " & txtLimitsKWH_PM2.Text)
                        'LogUserEvent(ConstEnum.PM2 & ": Limit Source Usage Changed To: " & txtLimitsKWH_PM2.Text)
                    End If

                Case txtLimitsKWH_PM3.Name
                    objChamber = AVPLib.ContainerData.GetRobotConfig(ConstEnum.Equipments.Chamber3.ToString())
                    If objChamber.Type = SystemModule.ModuleType.PVD Then
                        objChamber.Alarm_KWH = CDbl(txtLimitsKWH_PM3.Text)
                        AddLotDatalog(ConstEnum.PM3, "Limit KWH Changed To: " & txtLimitsKWH_PM3.Text)
                        'LogUserEvent(ConstEnum.PM3 & ": Limit KWH Changed To: " & txtLimitsKWH_PM3.Text)
                    ElseIf objChamber.Type = SystemModule.ModuleType.IBE Then
                        objChamber.SourceUsageTimeLimit = CDbl(txtLimitsKWH_PM3.Text)
                        AddLotDatalog(ConstEnum.PM3, "Limit Source Usage Changed To: " & txtLimitsKWH_PM3.Text)
                        'LogUserEvent(ConstEnum.PM3 & ": Limit Source Usage Changed To: " & txtLimitsKWH_PM3.Text)
                    End If
            End Select
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub txtWarningKWH_PM1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                              Handles txtWarningKWH_PM1.Click, txtWarningKWH_PM2.Click, txtWarningKWH_PM3.Click
        Try
            Dim LogSource As String = String.Empty
            If CType(sender, TextBox).Name.Contains("PM1") Then
                If PM1ChamberType = SystemModule.ModuleType.PVD4 OrElse PM1ChamberType = SystemModule.ModuleType.PVD5T Then
                    Me.PM1TargetPSConfigPopUpPanel.ShowDialog(AVPRobotMain)
                    Exit Try
                End If
                LogSource = "PM1_" & PM1ChamberType.ToString()
            ElseIf CType(sender, TextBox).Name.Contains("PM2") Then
                If PM2ChamberType = SystemModule.ModuleType.PVD4 OrElse PM2ChamberType = SystemModule.ModuleType.PVD5T Then
                    Me.PM2TargetPSConfigPopUpPanel.ShowDialog(AVPRobotMain)
                    Exit Try
                End If
                LogSource = "PM2_" & PM2ChamberType.ToString()
            ElseIf CType(sender, TextBox).Name.Contains("PM3") Then
                If PM3ChamberType = SystemModule.ModuleType.PVD4 OrElse PM3ChamberType = SystemModule.ModuleType.PVD5T Then
                    Me.PM3TargetPSConfigPopUpPanel.ShowDialog(AVPRobotMain)
                    Exit Try
                End If
                LogSource = "PM3_" & PM3ChamberType.ToString()
            End If
            Dim Source As String = "SystemSetup.WarningKWH"
            ChangeLimit_WarningKWH(Source, sender, LogSource)
            txtWarningKWH_PM1_TextChanged(sender, e)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub txtLimitKWH_PM1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                             Handles txtLimitsKWH_PM1.Click, txtLimitsKWH_PM2.Click, txtLimitsKWH_PM3.Click
        Try
            ''Only Admin can reset Limit
            Dim LogSource As String = String.Empty
            If AVPLib.ContainerData.UserLogin.Group.Name = "Administrator" Then
                If CType(sender, TextBox).Name.Contains("PM1") Then
                    If PM1ChamberType = SystemModule.ModuleType.PVD4 OrElse PM1ChamberType = SystemModule.ModuleType.PVD5T Then
                        Me.PM1TargetPSConfigPopUpPanel.ShowDialog(AVPRobotMain)
                        Exit Try
                    End If
                    LogSource = "PM1_" & PM1ChamberType.ToString()
                ElseIf CType(sender, TextBox).Name.Contains("PM2") Then
                    If PM2ChamberType = SystemModule.ModuleType.PVD4 OrElse PM2ChamberType = SystemModule.ModuleType.PVD5T Then
                        Me.PM2TargetPSConfigPopUpPanel.ShowDialog(AVPRobotMain)
                        Exit Try
                    End If
                    LogSource = "PM2_" & PM2ChamberType.ToString()
                ElseIf CType(sender, TextBox).Name.Contains("PM3") Then
                    If PM3ChamberType = SystemModule.ModuleType.PVD4 OrElse PM3ChamberType = SystemModule.ModuleType.PVD5T Then
                        Me.PM3TargetPSConfigPopUpPanel.ShowDialog(AVPRobotMain)
                        Exit Try
                    End If
                    LogSource = "PM3_" & PM3ChamberType.ToString()
                End If
                '''
                Dim Source As String = "SystemSetup.LimitKWH"
                ChangeLimit_WarningKWH(Source, sender, LogSource)
                txtLimitsKWH_PM1_TextChanged(sender, e)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-06-19 </date>
    ''' </author>
    ''' <summary>
    ''' Click event for Limit Shields/Quartz textbox
    ''' </summary>
    Private Sub LimitShieldsQuartz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLimitShieldsPM3.Click, txtLimitShieldsPM2.Click, txtLimitShieldsPM1.Click
        Try
            ''Only Admin can reset Limit
            Dim LogShielsd As String = String.Empty
            If AVPLib.ContainerData.UserLogin.Group.Name = "Administrator" Then
                If CType(sender, TextBox).Name.Contains("PM1") Then
                    If PM1ChamberType = SystemModule.ModuleType.PVD4 OrElse PM1ChamberType = SystemModule.ModuleType.PVD5T Then
                        Me.PM1ShieldsQuartzPopUpPanel.ShowDialog(AVPRobotMain)
                        Exit Try
                    End If
                    LogShielsd = "PM1_" & PM1ChamberType.ToString()
                ElseIf CType(sender, TextBox).Name.Contains("PM2") Then
                    If PM2ChamberType = SystemModule.ModuleType.PVD4 OrElse PM2ChamberType = SystemModule.ModuleType.PVD5T Then
                        Me.PM2ShieldsQuartzPopUpPanel.ShowDialog(AVPRobotMain)
                        Exit Try
                    End If
                    LogShielsd = "PM2_" & PM2ChamberType.ToString()
                ElseIf CType(sender, TextBox).Name.Contains("PM3") Then
                    If PM3ChamberType = SystemModule.ModuleType.PVD4 OrElse PM3ChamberType = SystemModule.ModuleType.PVD5T Then
                        Me.PM3ShieldsQuartzPopUpPanel.ShowDialog(AVPRobotMain)
                        Exit Try
                    End If
                    LogShielsd = "PM3_" & PM3ChamberType.ToString()
                End If
                '''

                Dim Source As String = "SystemSetup.LimitShieldsQuartz"
                If ChangeLimit_WarningKWH(Source, sender, LogShielsd) Then
                    LimitShieldsQuartz_TextChanged(sender, e)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-06-19 </date>
    ''' </author>
    ''' <summary>
    ''' Log when Limit Shields/Quartz changed
    ''' </summary>
    Private Sub LimitShieldsQuartz_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim value As Double = Convert.ToSingle(CType(sender, TextBox).Text)
            Dim objChamber As SystemModule = Nothing
            Select Case CType(sender, TextBox).Name
                Case txtLimitShieldsPM1.Name
                    objChamber = AVPLib.ContainerData.GetRobotConfig(ConstEnum.Equipments.Chamber1.ToString())
                    objChamber.ShieldsQuartzLimit = value
                    AddLotDatalog(ConstEnum.PM1, "Limit Shields/Quartz Changed To: " & value.ToString())

                Case txtLimitShieldsPM2.Name
                    objChamber = AVPLib.ContainerData.GetRobotConfig(ConstEnum.Equipments.Chamber2.ToString())
                    objChamber.ShieldsQuartzLimit = value
                    AddLotDatalog(ConstEnum.PM2, "Limit Shields/Quartz Changed To: " & value.ToString())

                Case txtLimitShieldsPM3.Name
                    objChamber = AVPLib.ContainerData.GetRobotConfig(ConstEnum.Equipments.Chamber3.ToString())
                    objChamber.ShieldsQuartzLimit = value
                    AddLotDatalog(ConstEnum.PM3, "Limit Shields/Quartz Changed To: " & value.ToString())

            End Select
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-06-19 </date>
    ''' </author>
    ''' <summary>
    ''' Click event for Warning Shields/Quartz textbox
    ''' </summary>
    Private Sub WarningShieldsQuartz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWarningShieldsPM3.Click, txtWarningShieldsPM2.Click, txtWarningShieldsPM1.Click
        Try
            ''Only Admin can reset Limit
            Dim LogShields As String = String.Empty
            If AVPLib.ContainerData.UserLogin.Group.Name = "Administrator" Then
                If CType(sender, TextBox).Name.Contains("PM1") Then
                    If PM1ChamberType = SystemModule.ModuleType.PVD4 OrElse PM1ChamberType = SystemModule.ModuleType.PVD5T Then
                        Me.PM1ShieldsQuartzPopUpPanel.ShowDialog(AVPRobotMain)
                        Exit Try
                    End If
                    LogShields = "PM1_" & PM1ChamberType.ToString()
                ElseIf CType(sender, TextBox).Name.Contains("PM2") Then
                    If PM2ChamberType = SystemModule.ModuleType.PVD4 OrElse PM2ChamberType = SystemModule.ModuleType.PVD5T Then
                        Me.PM2ShieldsQuartzPopUpPanel.ShowDialog(AVPRobotMain)
                        Exit Try
                    End If
                    LogShields = "PM2_" & PM2ChamberType.ToString()
                ElseIf CType(sender, TextBox).Name.Contains("PM3") Then
                    If PM3ChamberType = SystemModule.ModuleType.PVD4 OrElse PM3ChamberType = SystemModule.ModuleType.PVD5T Then
                        Me.PM3ShieldsQuartzPopUpPanel.ShowDialog(AVPRobotMain)
                        Exit Try
                    End If
                    LogShields = "PM3_" & PM3ChamberType.ToString()
                End If
                '''

                Dim Source As String = "SystemSetup.WarningShieldsQuartz"
                If ChangeLimit_WarningKWH(Source, sender, LogShields) Then
                    WarningShieldsQuartz_TextChanged(sender, e)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-06-19 </date>
    ''' </author>
    ''' <summary>
    ''' Log when Warning Shields/Quartz changed
    ''' </summary>
    Private Sub WarningShieldsQuartz_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim value As Double = Convert.ToSingle(CType(sender, TextBox).Text)
            Dim objChamber As SystemModule = Nothing
            Select Case CType(sender, TextBox).Name
                Case txtWarningShieldsPM1.Name
                    objChamber = AVPLib.ContainerData.GetRobotConfig(ConstEnum.Equipments.Chamber1.ToString())
                    objChamber.ShieldsQuartzWarning = value
                    AddLotDatalog(ConstEnum.PM1, "Warning Shields/Quartz Changed To: " & value.ToString())

                Case txtWarningShieldsPM2.Name
                    objChamber = AVPLib.ContainerData.GetRobotConfig(ConstEnum.Equipments.Chamber2.ToString())
                    objChamber.ShieldsQuartzWarning = value
                    AddLotDatalog(ConstEnum.PM2, "Warning Shields/Quartz Changed To: " & value.ToString())

                Case txtWarningShieldsPM3.Name
                    objChamber = AVPLib.ContainerData.GetRobotConfig(ConstEnum.Equipments.Chamber3.ToString())
                    objChamber.ShieldsQuartzWarning = value
                    AddLotDatalog(ConstEnum.PM3, "Warning Shields/Quartz Changed To: " & value.ToString())

            End Select
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub


    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-06-19 </date>
    ''' </author>
    ''' <summary>
    ''' Click event for Max Shields/Quartz textbox
    ''' </summary>
    Private Sub MaxShieldsQuartz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMaxShieldsPM3.Click, txtMaxShieldsPM2.Click, txtMaxShieldsPM1.Click
        Try
            ''Only Admin can reset Limit
            Dim LogShields As String = String.Empty
            If AVPLib.ContainerData.UserLogin.Group.Name = "Administrator" Then
                If CType(sender, TextBox).Name.Contains("PM1") Then
                    If PM1ChamberType = SystemModule.ModuleType.PVD4 OrElse PM1ChamberType = SystemModule.ModuleType.PVD5T Then
                        Me.PM1ShieldsQuartzPopUpPanel.ShowDialog(AVPRobotMain)
                        Exit Try
                    End If
                    LogShields = "PM1_" & PM1ChamberType.ToString()
                ElseIf CType(sender, TextBox).Name.Contains("PM2") Then
                    If PM2ChamberType = SystemModule.ModuleType.PVD4 OrElse PM2ChamberType = SystemModule.ModuleType.PVD5T Then
                        Me.PM2ShieldsQuartzPopUpPanel.ShowDialog(AVPRobotMain)
                        Exit Try
                    End If
                    LogShields = "PM2_" & PM2ChamberType.ToString()
                ElseIf CType(sender, TextBox).Name.Contains("PM3") Then
                    If PM3ChamberType = SystemModule.ModuleType.PVD4 OrElse PM3ChamberType = SystemModule.ModuleType.PVD5T Then
                        Me.PM3ShieldsQuartzPopUpPanel.ShowDialog(AVPRobotMain)
                        Exit Try
                    End If
                    LogShields = "PM3_" & PM3ChamberType.ToString()
                End If
                '''

                Dim Source As String = "SystemSetup.MaxShieldsQuartz"
                If ChangeLimit_WarningKWH(Source, sender, LogShields) Then
                    MaxShieldsQuartz_TextChanged(sender, e)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-06-19 </date>
    ''' </author>
    ''' <summary>
    ''' Log when Max Shields/Quartz changed
    ''' </summary>
    Private Sub MaxShieldsQuartz_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim value As Double = Convert.ToSingle(CType(sender, TextBox).Text)
            Dim objChamber As SystemModule = Nothing
            Select Case CType(sender, TextBox).Name
                Case txtMaxShieldsPM1.Name
                    objChamber = AVPLib.ContainerData.GetRobotConfig(ConstEnum.Equipments.Chamber1.ToString())
                    objChamber.Max_KWH_ShieldsQuartz = value
                    AddLotDatalog(ConstEnum.PM1, "Max Shields/Quartz Changed To: " & value.ToString())

                Case txtMaxShieldsPM2.Name
                    objChamber = AVPLib.ContainerData.GetRobotConfig(ConstEnum.Equipments.Chamber2.ToString())
                    objChamber.Max_KWH_ShieldsQuartz = value
                    AddLotDatalog(ConstEnum.PM2, "Max Shields/Quartz Changed To: " & value.ToString())

                Case txtMaxShieldsPM3.Name
                    objChamber = AVPLib.ContainerData.GetRobotConfig(ConstEnum.Equipments.Chamber3.ToString())
                    objChamber.Max_KWH_ShieldsQuartz = value
                    AddLotDatalog(ConstEnum.PM3, "Max Shields/Quartz Changed To: " & value.ToString())

            End Select
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Function ChangeLimit_WarningKWH(ByVal Source As String, ByVal sender As Object, Optional ByVal subLogSheild As String = "") As Boolean
        Dim frm As New NumPad
        Dim Title As String = AVPLib.ContainerData.GetMessageText(Source)
        Dim value As String = CType(sender, TextBox).Text
        Dim oldValue As String = value
        Dim Min As Single = AVPLib.ContainerData.GetRobotConfig(Source + "." + STRING_MIN)
        Dim Max As Single = AVPLib.ContainerData.GetRobotConfig(Source + "." + STRING_MAX)

        StoreValueBeforeChanged(sender)
        Dim InputRes As MsgBoxResult = frm.GetUserInput(value, -1, -1, Min, Max, Title)

        If frm.IsMaxMinModified Then
            AVPLib.ContainerData.SetRobotConfig(Source + STRING_MIN, frm.NewMin)
            AVPLib.ContainerData.SetRobotConfig(Source + STRING_MAX, frm.NewMax)
            If Min <> frm.NewMin Then
                LogUserEvent(String.Format("Changed MIN of {0} from {1} to {2}", Utils.GetLogName(sender), Min, frm.NewMin))
            End If
            If Max <> frm.NewMax Then
                LogUserEvent(String.Format("Changed MAX of {0} from {1} to {2}", Utils.GetLogName(sender), Max, frm.NewMax))
            End If
        End If

        If InputRes = MsgBoxResult.Ok Then
            CType(sender, TextBox).Text = value
            SaveDataToAVPConfig(sender, value)
            LogUserEvent(sender, "", subLogSheild)
            Return True
        End If

        Return False
    End Function

    Private Sub txtMaxKWHPM_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim objChamber As SystemModule = Nothing
        Try
            If (sender Is txtMaxKWHPM3) Then
                objChamber = AVPLib.ContainerData.GetRobotConfig(ConstEnum.Equipments.Chamber3.ToString())
                If (objChamber IsNot Nothing) Then
                    objChamber.Max_KWH_Source = CDbl(txtMaxKWHPM3.Text)
                    MaxKWHPM_LogData(ConstEnum.PM3, txtMaxKWHPM3.Text)
                End If
                AVPLib.Utils.SaveMax_KWH_SourceUsageX(sender, objChamber.Max_KWH_Source, ConstEnum.Equipments.Chamber3.ToString())
            ElseIf (sender Is txtMaxKWHPM2) Then
                objChamber = AVPLib.ContainerData.GetRobotConfig(ConstEnum.Equipments.Chamber2.ToString())
                If (objChamber IsNot Nothing) Then
                    objChamber.Max_KWH_Source = CDbl(txtMaxKWHPM2.Text)
                    MaxKWHPM_LogData(ConstEnum.PM2, txtMaxKWHPM2.Text)
                End If
                AVPLib.Utils.SaveMax_KWH_SourceUsageX(sender, objChamber.Max_KWH_Source, ConstEnum.Equipments.Chamber2.ToString())
            ElseIf (sender Is txtMaxKWHPM1) Then
                objChamber = AVPLib.ContainerData.GetRobotConfig(ConstEnum.Equipments.Chamber1.ToString())
                If (objChamber IsNot Nothing) Then
                    objChamber.Max_KWH_Source = CDbl(txtMaxKWHPM1.Text)
                    MaxKWHPM_LogData(ConstEnum.PM1, txtMaxKWHPM1.Text)
                End If
                AVPLib.Utils.SaveMax_KWH_SourceUsageX(sender, objChamber.Max_KWH_Source, ConstEnum.Equipments.Chamber1.ToString())
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-08-22</date>
    ''' </author>
    ''' <summary>
    '''  Log MaxKWHPM changed to LotDataLog and LogAlarmAndEvent
    ''' </summary>
    Private Sub MaxKWHPM_LogData(ByVal strChamberName As String, ByVal strValue As String)
        AddLotDatalog(strChamberName, "Max Limit Changed To: " & strValue)
        'LogUserEvent(strChamberName & ": Max Limit Changed To: " & strValue)
    End Sub

    Private Sub txtMaxKWHPM1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMaxKWHPM1.Click, txtMaxKWHPM2.Click, txtMaxKWHPM3.Click
        Try
            Dim LogShields As String = String.Empty
            If CType(sender, TextBox).Name.Contains("PM1") Then
                If PM1ChamberType = SystemModule.ModuleType.PVD4 OrElse PM1ChamberType = SystemModule.ModuleType.PVD5T Then
                    Me.PM1TargetPSConfigPopUpPanel.ShowDialog(AVPRobotMain)
                    Exit Try
                End If
                LogShields = "PM1_" & PM1ChamberType.ToString()
            ElseIf CType(sender, TextBox).Name.Contains("PM2") Then
                If PM2ChamberType = SystemModule.ModuleType.PVD4 OrElse PM2ChamberType = SystemModule.ModuleType.PVD5T Then
                    Me.PM2TargetPSConfigPopUpPanel.ShowDialog(AVPRobotMain)
                    Exit Try
                End If
                LogShields = "PM2_" & PM2ChamberType.ToString()
            ElseIf CType(sender, TextBox).Name.Contains("PM3") Then
                If PM3ChamberType = SystemModule.ModuleType.PVD4 OrElse PM3ChamberType = SystemModule.ModuleType.PVD5T Then
                    Me.PM3TargetPSConfigPopUpPanel.ShowDialog(AVPRobotMain)
                    Exit Try
                End If
                LogShields = "PM3_" & PM3ChamberType.ToString()
            End If

            Dim Source As String = "SystemSetup.MaxUsage"
            ChangeLimit_WarningKWH(Source, sender, LogShields)
            txtMaxKWHPM_TextChanged(sender, e)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    'Private Sub rbUseMaxKWH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbUseMaxKWH.Click, rbUseAbsoluteKWH.Click
    '    Try
    '        Dim strMessageText As String = AVPLib.ContainerData.GetMessageText("CheckMaxUsagePM")
    '        Dim strAbsoluteText As String = String.Format(strMessageText, "Set Absolute Limits")
    '        Dim strMaxLimitText As String = String.Format(strMessageText, "Set Max Limits")

    '        Dim objChamber As SystemModule = Nothing
    '        If (sender Is rbUseMaxKWH) Then
    '            If Not (Utils.ShowAVPMessageBox(strMaxLimitText, "Use Max Limits", MessageBoxIcon.Question, MessageBoxButtons.YesNo) = DialogResult.OK) Then
    '                rbUseMaxKWH.Checked = Not (rbUseMaxKWH.Checked)
    '            End If
    '            If rbUseMaxKWH.Checked Then
    '                EnableAllMaxLimits()
    '            Else
    '                DisableAllMaxLimits()
    '            End If
    '            rbUseAbsoluteKWH.Checked = Not (rbUseMaxKWH.Checked)

    '            AddLotDatalog("", "Changed to use Max Limits")
    '            LogUserEvent("Changed to use Max Limits")
    '            Utils.CheckChangeValue("Calculation type use", "Absolute Limits", "Max Limits")
    '        ElseIf (sender Is rbUseAbsoluteKWH) Then
    '            If Not (Utils.ShowAVPMessageBox(strAbsoluteText, "Use Absolute Limits", MessageBoxIcon.Question, MessageBoxButtons.YesNo) = DialogResult.OK) Then
    '                rbUseAbsoluteKWH.Checked = Not (rbUseAbsoluteKWH.Checked)
    '            End If
    '            If rbUseAbsoluteKWH.Checked Then
    '                DisableAllMaxLimits()
    '                rbUseMaxKWH.Visible = False
    '            Else
    '                EnableAllMaxLimits()
    '                rbUseAbsoluteKWH.Visible = False
    '            End If
    '            rbUseMaxKWH.Checked = Not (rbUseAbsoluteKWH.Checked)

    '            AddLotDatalog("", "Changed to use Absolute Limits")
    '            LogUserEvent("Changed to use Absolute Limits")
    '            Utils.CheckChangeValue("Calculation type use", "Max Limits", "Absolute Limits")
    '        End If
    '    Catch ex As Exception
    '        AVPLib.Log.avpLogger.Error(ex.ToString())
    '    End Try
    'End Sub

    Public Sub EnableAllMaxLimits()
        Dim objChamber As SystemModule = Nothing
        Dim ObjPM As DataManagerment.Chamber = Nothing
        For i As Integer = 1 To AVPRobotMain.MaxChamber2Install
            objChamber = AVPLib.ContainerData.GetRobotConfig(ConstEnum.Chamber & i.ToString())
            ObjPM = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Chamber & i.ToString())
            If (objChamber Is Nothing) OrElse objChamber.IsVisible = False Then
                Continue For
            End If
            If ObjPM IsNot Nothing Then
                ObjPM.IsUseMaxLimit = True
            End If
            If i = 1 Then
                txtMaxKWHPM1.Enabled = True
                txtMaxShieldsPM1.Enabled = True
                If Not (objChamber.Type = SystemModule.ModuleType.PVD4) AndAlso Not (objChamber.Type = SystemModule.ModuleType.PVD5T) Then
                    txtMaxKWHPM1.Text = IIf(String.IsNullOrEmpty(txtMaxKWHPM1.Text), 0, txtMaxKWHPM1.Text)
                    objChamber.Max_KWH_Source = IIf(String.IsNullOrEmpty(txtMaxKWHPM1.Text), 0, CDbl(txtMaxKWHPM1.Text))
                    txtMaxShieldsPM1.Text = IIf(String.IsNullOrEmpty(txtMaxShieldsPM1.Text), 0, txtMaxShieldsPM1.Text)
                    objChamber.Max_KWH_ShieldsQuartz = IIf(String.IsNullOrEmpty(txtMaxShieldsPM1.Text), 0, CDbl(txtMaxShieldsPM1.Text))
                End If
            ElseIf i = 2 Then
                txtMaxKWHPM2.Enabled = True
                txtMaxShieldsPM2.Enabled = True
                If Not (objChamber.Type = SystemModule.ModuleType.PVD4) AndAlso Not (objChamber.Type = SystemModule.ModuleType.PVD5T) Then
                    txtMaxKWHPM2.Text = IIf(String.IsNullOrEmpty(txtMaxKWHPM2.Text), 0, txtMaxKWHPM2.Text)
                    objChamber.Max_KWH_Source = IIf(String.IsNullOrEmpty(txtMaxKWHPM2.Text), 0, CDbl(txtMaxKWHPM2.Text))
                    txtMaxShieldsPM2.Text = IIf(String.IsNullOrEmpty(txtMaxShieldsPM2.Text), 0, txtMaxShieldsPM2.Text)
                    objChamber.Max_KWH_ShieldsQuartz = IIf(String.IsNullOrEmpty(txtMaxShieldsPM2.Text), 0, CDbl(txtMaxShieldsPM2.Text))
                End If
            ElseIf i = 3 Then
                txtMaxKWHPM3.Enabled = True
                txtMaxShieldsPM3.Enabled = True
                If Not (objChamber.Type = SystemModule.ModuleType.PVD4) AndAlso Not (objChamber.Type = SystemModule.ModuleType.PVD5T) Then
                    txtMaxKWHPM3.Text = IIf(String.IsNullOrEmpty(txtMaxKWHPM3.Text), 0, txtMaxKWHPM3.Text)
                    objChamber.Max_KWH_Source = IIf(String.IsNullOrEmpty(txtMaxKWHPM3.Text), 0, CDbl(txtMaxKWHPM3.Text))
                    txtMaxShieldsPM3.Text = IIf(String.IsNullOrEmpty(txtMaxShieldsPM3.Text), 0, txtMaxShieldsPM3.Text)
                    objChamber.Max_KWH_ShieldsQuartz = IIf(String.IsNullOrEmpty(txtMaxShieldsPM3.Text), 0, CDbl(txtMaxShieldsPM3.Text))
                End If
            End If
        Next

    End Sub

    Public Sub DisableAllMaxLimits()
        Dim objChamber As SystemModule = Nothing
        Dim ObjPM As DataManagerment.Chamber = Nothing
        For i As Integer = 1 To AVPRobotMain.MaxChamber2Install
            objChamber = AVPLib.ContainerData.GetRobotConfig(ConstEnum.Chamber & i.ToString())
            ObjPM = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Chamber & i.ToString())
            If (objChamber Is Nothing) OrElse objChamber.IsVisible = False Then
                Continue For
            End If
            If ObjPM IsNot Nothing Then
                ObjPM.IsUseMaxLimit = False
            End If
            If i = 1 Then
                txtMaxKWHPM1.Enabled = False
                txtMaxShieldsPM1.Enabled = False
                If Not (objChamber.Type = SystemModule.ModuleType.PVD4) AndAlso Not (objChamber.Type = SystemModule.ModuleType.PVD5T) Then
                    txtMaxKWHPM1.Text = IIf(String.IsNullOrEmpty(txtMaxKWHPM1.Text), 0, txtMaxKWHPM1.Text)
                    objChamber.Max_KWH_Source = -1
                    txtMaxShieldsPM1.Text = IIf(String.IsNullOrEmpty(txtMaxShieldsPM1.Text), 0, txtMaxShieldsPM1.Text)
                    objChamber.Max_KWH_ShieldsQuartz = IIf(String.IsNullOrEmpty(txtMaxShieldsPM1.Text), 0, CDbl(txtMaxShieldsPM1.Text))
                End If

            ElseIf i = 2 Then
                txtMaxKWHPM2.Enabled = False
                txtMaxShieldsPM2.Enabled = False
                If Not (objChamber.Type = SystemModule.ModuleType.PVD4) AndAlso Not (objChamber.Type = SystemModule.ModuleType.PVD5T) Then
                    txtMaxKWHPM2.Text = IIf(String.IsNullOrEmpty(txtMaxKWHPM2.Text), 0, txtMaxKWHPM2.Text)
                    objChamber.Max_KWH_Source = -1
                    txtMaxShieldsPM2.Text = IIf(String.IsNullOrEmpty(txtMaxShieldsPM2.Text), 0, txtMaxShieldsPM2.Text)
                    objChamber.Max_KWH_ShieldsQuartz = IIf(String.IsNullOrEmpty(txtMaxShieldsPM2.Text), 0, CDbl(txtMaxShieldsPM2.Text))
                End If

            ElseIf i = 3 Then
                txtMaxKWHPM3.Enabled = False
                txtMaxShieldsPM3.Enabled = False
                If Not (objChamber.Type = SystemModule.ModuleType.PVD4) AndAlso Not (objChamber.Type = SystemModule.ModuleType.PVD5T) Then
                    txtMaxKWHPM3.Text = IIf(String.IsNullOrEmpty(txtMaxKWHPM3.Text), 0, txtMaxKWHPM3.Text)
                    objChamber.Max_KWH_Source = -1
                    txtMaxShieldsPM3.Text = IIf(String.IsNullOrEmpty(txtMaxShieldsPM3.Text), 0, txtMaxShieldsPM3.Text)
                    objChamber.Max_KWH_ShieldsQuartz = IIf(String.IsNullOrEmpty(txtMaxShieldsPM3.Text), 0, CDbl(txtMaxShieldsPM3.Text))
                End If

            End If
        Next

    End Sub

#End Region

#Region "Lot Data Log"
    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 2011-08-22</date>
    ''' </author>
    ''' <summary>
    '''  Log Transfer SP changed to LotDataLog
    ''' </summary>
    Private Sub TransferSetPoint_LotDatalog()
        Try
            If (AVPLib.Business.AVPCore.Instance() IsNot Nothing) Then
                Dim temp As Integer = 0

                If (m_iTransferSetPointTextChanged > 0) Then

                    Dim objLoadLockACtrl As AVPLib.Business.LoadLockController = Nothing

                    Dim objCtrlJobA As AVPLib.Business.AVPControlJob = Nothing

                    objLoadLockACtrl = AVPLib.Business.ControllerManager.GetController(AVPLib.ConstEnum.Equipments.LoadLockA.ToString())

                    If (objLoadLockACtrl IsNot Nothing AndAlso objLoadLockACtrl.CtrlJobId <> String.Empty) Then
                        objCtrlJobA = AVPLib.Business.AVPCore.Instance().JobManager().GetControlJob(objLoadLockACtrl.CtrlJobId)
                    End If

                    If (objCtrlJobA IsNot Nothing AndAlso _
                        objCtrlJobA.LoadlockName = AVPLib.ConstEnum.LoadLockA_STR) Then

                        temp = m_iTransferSetPointTextChanged And 1
                        If temp > 0 Then
                            AVPLib.Business.AVPLotDatalog.AddLotDatalog(AVPLib.ConstEnum.LoadLockA_STR, _
                                                    LogType.Info, "LLA Transfer Point Changed To: " & txtTransferLLA.Text, _
                                                    objCtrlJobA.IsAutoTransferJob)
                        End If

                        temp = m_iTransferSetPointTextChanged And 4
                        If temp > 0 Then
                            AVPLib.Business.AVPLotDatalog.AddLotDatalog(AVPLib.ConstEnum.LoadLockA_STR, _
                                                    LogType.Info, "TM Transfer Point Changed To: " & txtTransferTM.Text, _
                                                    objCtrlJobA.IsAutoTransferJob)
                        End If

                        temp = m_iTransferSetPointTextChanged And 8
                        If temp > 0 Then
                            AVPLib.Business.AVPLotDatalog.AddLotDatalog(AVPLib.ConstEnum.LoadLockA_STR, _
                                                    LogType.Info, "PM1 Transfer Point Changed To: " & txtTransferPM1.Text, _
                                                    objCtrlJobA.IsAutoTransferJob)
                        End If

                        temp = m_iTransferSetPointTextChanged And 16
                        If temp > 0 Then
                            AVPLib.Business.AVPLotDatalog.AddLotDatalog(AVPLib.ConstEnum.LoadLockA_STR, _
                                                    LogType.Info, "PM2 Transfer Point Changed To: " & txtTransferPM2.Text, _
                                                    objCtrlJobA.IsAutoTransferJob)
                        End If

                        temp = m_iTransferSetPointTextChanged And 32
                        If temp > 0 Then
                            AVPLib.Business.AVPLotDatalog.AddLotDatalog(AVPLib.ConstEnum.LoadLockA_STR, _
                                                    LogType.Info, "PM3 Transfer Point Changed To: " & txtTransferPM3.Text, _
                                                    objCtrlJobA.IsAutoTransferJob)
                        End If

                    End If
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-08-22</date>
    ''' </author>
    ''' <summary>
    '''  Log Vent SP changed to LotDataLog
    ''' </summary>
    Private Sub VentSetPoint_LotDatalog()
        Try
            If (AVPLib.Business.AVPCore.Instance() IsNot Nothing) Then
                Dim temp As Integer = 0

                If (m_iVentSetPointTextChanged > 0) Then


                    Dim objLoadLockACtrl As AVPLib.Business.LoadLockController = Nothing

                    Dim objCtrlJobA As AVPLib.Business.AVPControlJob = Nothing


                    objLoadLockACtrl = AVPLib.Business.ControllerManager.GetController(AVPLib.ConstEnum.Equipments.LoadLockA.ToString())

                    If (objLoadLockACtrl IsNot Nothing AndAlso objLoadLockACtrl.CtrlJobId <> String.Empty) Then
                        objCtrlJobA = AVPLib.Business.AVPCore.Instance().JobManager().GetControlJob(objLoadLockACtrl.CtrlJobId)
                    End If

                    If (objCtrlJobA IsNot Nothing AndAlso _
                        objCtrlJobA.LoadlockName = AVPLib.ConstEnum.LoadLockA_STR) Then

                        temp = m_iVentSetPointTextChanged And 1
                        If temp > 0 Then
                            AVPLib.Business.AVPLotDatalog.AddLotDatalog(AVPLib.ConstEnum.LoadLockA_STR, _
                                                    LogType.Info, "LLA Vent Pressure SetPoint Changed To: " & txtVentLLA.Text, _
                                                    objCtrlJobA.IsAutoTransferJob)
                        End If

                        temp = m_iVentSetPointTextChanged And 4
                        If temp > 0 Then
                            AVPLib.Business.AVPLotDatalog.AddLotDatalog(AVPLib.ConstEnum.LoadLockA_STR, _
                                                    LogType.Info, "TM Vent Pressure SetPoint Changed To: " & txtVentTM.Text, _
                                                    objCtrlJobA.IsAutoTransferJob)
                        End If
                    End If

                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-08-22</date>
    ''' </author>
    ''' <summary>
    '''  Log CrossOver SP changed to LotDataLog
    ''' </summary>
    Private Sub CrossOverSetPoint_LotDatalog()
        Try
            If (AVPLib.Business.AVPCore.Instance() IsNot Nothing) Then
                Dim temp As Integer = 0

                If (m_iCrossOverSetPointTextChanged > 0) Then


                    Dim objLoadLockACtrl As AVPLib.Business.LoadLockController = Nothing

                    Dim objCtrlJobA As AVPLib.Business.AVPControlJob = Nothing

                    objLoadLockACtrl = AVPLib.Business.ControllerManager.GetController(AVPLib.ConstEnum.Equipments.LoadLockA.ToString())

                    If (objLoadLockACtrl IsNot Nothing AndAlso objLoadLockACtrl.CtrlJobId <> String.Empty) Then
                        objCtrlJobA = AVPLib.Business.AVPCore.Instance().JobManager().GetControlJob(objLoadLockACtrl.CtrlJobId)
                    End If

                    If (objCtrlJobA IsNot Nothing AndAlso _
                        objCtrlJobA.LoadlockName = AVPLib.ConstEnum.LoadLockA_STR) Then

                        temp = m_iCrossOverSetPointTextChanged And 1
                        If temp > 0 Then
                            AVPLib.Business.AVPLotDatalog.AddLotDatalog(AVPLib.ConstEnum.LoadLockA_STR, _
                                                    LogType.Info, "LLA CrossOver Pressure SetPoint Changed To: " & txtCrossOverLLA.Text, _
                                                    objCtrlJobA.IsAutoTransferJob)
                        End If

                        temp = m_iCrossOverSetPointTextChanged And 4
                        If temp > 0 Then
                            AVPLib.Business.AVPLotDatalog.AddLotDatalog(AVPLib.ConstEnum.LoadLockA_STR, _
                                                    LogType.Info, "TM CrossOver Pressure SetPoint Changed To: " & txtCrossOverTM.Text, _
                                                    objCtrlJobA.IsAutoTransferJob)
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-08-22</date>
    ''' </author>
    ''' <summary>
    '''  Log SlowRough SP changed to LotDataLog
    ''' </summary>
    Private Sub SlowRoughSetPoint_LotDatalog()
        Try
            If (AVPLib.Business.AVPCore.Instance() IsNot Nothing) Then
                Dim temp As Integer = 0

                If (m_iSlowRoughSetPointTextChanged > 0) Then


                    Dim objLoadLockACtrl As AVPLib.Business.LoadLockController = Nothing
                    Dim objCtrlJobA As AVPLib.Business.AVPControlJob = Nothing

                    objLoadLockACtrl = AVPLib.Business.ControllerManager.GetController(AVPLib.ConstEnum.Equipments.LoadLockA.ToString())

                    If (objLoadLockACtrl IsNot Nothing AndAlso objLoadLockACtrl.CtrlJobId <> String.Empty) Then
                        objCtrlJobA = AVPLib.Business.AVPCore.Instance().JobManager().GetControlJob(objLoadLockACtrl.CtrlJobId)
                    End If

                    If (objCtrlJobA IsNot Nothing AndAlso _
                        objCtrlJobA.LoadlockName = AVPLib.ConstEnum.LoadLockA_STR) Then

                        temp = m_iSlowRoughSetPointTextChanged And 1
                        If temp > 0 Then
                            AVPLib.Business.AVPLotDatalog.AddLotDatalog(AVPLib.ConstEnum.LoadLockA_STR, _
                                                    LogType.Info, "LLA SlowRough Pressure SetPoint Changed To: " & txtSlowRoughLLA.Text, _
                                                    objCtrlJobA.IsAutoTransferJob)
                        End If
                    End If

                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-08-22</date>
    ''' </author>
    ''' <summary>
    '''  Log SlowVent SP changed to LotDataLog
    ''' </summary>
    Private Sub SlowVentSetPoint_LotDatalog()
        Try
            If (AVPLib.Business.AVPCore.Instance() IsNot Nothing) Then
                Dim temp As Integer = 0

                If (m_iSlowVentSetPointTextChanged > 0) Then


                    Dim objLoadLockACtrl As AVPLib.Business.LoadLockController = Nothing
                    Dim objCtrlJobA As AVPLib.Business.AVPControlJob = Nothing

                    objLoadLockACtrl = AVPLib.Business.ControllerManager.GetController(AVPLib.ConstEnum.Equipments.LoadLockA.ToString())

                    If (objLoadLockACtrl IsNot Nothing AndAlso objLoadLockACtrl.CtrlJobId <> String.Empty) Then
                        objCtrlJobA = AVPLib.Business.AVPCore.Instance().JobManager().GetControlJob(objLoadLockACtrl.CtrlJobId)
                    End If

                    If (objCtrlJobA IsNot Nothing AndAlso _
                        objCtrlJobA.LoadlockName = AVPLib.ConstEnum.LoadLockA_STR) Then

                        temp = m_iSlowVentSetPointTextChanged And 1
                        If temp > 0 Then
                            AVPLib.Business.AVPLotDatalog.AddLotDatalog(AVPLib.ConstEnum.LoadLockA_STR, _
                                                    LogType.Info, "LLA SlowVent Pressure SetPoint Changed To: " & txtSlowVentLLA.Text, _
                                                    objCtrlJobA.IsAutoTransferJob)
                        End If
                    End If

                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-08-22</date>
    ''' </author>
    ''' <summary>
    '''  Log Pumpdown Setting changed to LotDataLog
    ''' </summary>
    Private Sub PumpdownSettings_LotDatalog()
        CrossOverSetPoint_LotDatalog()
        SlowRoughSetPoint_LotDatalog()
    End Sub

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-08-22</date>
    ''' </author>
    ''' <summary>
    '''  Log Vent Setting changed to LotDataLog
    ''' </summary>
    Private Sub VentSettings_LotDatalog()
        VentSetPoint_LotDatalog()
        SlowVentSetPoint_LotDatalog()
    End Sub

    Private Sub AddLotDatalog(ByVal ChamberName As String, ByVal Info As String)
        Try
            If (AVPLib.Business.AVPCore.Instance() IsNot Nothing) Then

                Dim objLoadLockACtrl As AVPLib.Business.LoadLockController = Nothing

                Dim objCtrlJobA As AVPLib.Business.AVPControlJob = Nothing

                objLoadLockACtrl = AVPLib.Business.ControllerManager.GetController(AVPLib.ConstEnum.Equipments.LoadLockA.ToString())

                If (objLoadLockACtrl IsNot Nothing AndAlso objLoadLockACtrl.CtrlJobId <> String.Empty) Then
                    objCtrlJobA = AVPLib.Business.AVPCore.Instance().JobManager().GetControlJob(objLoadLockACtrl.CtrlJobId)
                    If (objCtrlJobA IsNot Nothing) Then
                        AVPLib.Business.AVPLotDatalog.AddLotDatalog(AVPLib.ConstEnum.LoadLockA_STR, _
                        LogType.Info, AVPLib.Utils.chamberID2ChamberName(ChamberName) & " " & Info, objCtrlJobA.IsAutoTransferJob)
                    End If
                End If
            End If
        Catch ex As Exception
            m_iTransferSetPointTextChanged = 0
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Log Alarm And Event"
    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-08-22</date>
    ''' </author>
    ''' <summary>
    '''  Log Transfer SP changed to LogAlarmAndEvent
    ''' </summary>
    Private Sub TransferSetPoint_LogAlarmAndEvent()
        Try
            Dim temp As Integer = 0

            If (m_iTransferSetPointTextChanged > 0) Then

                temp = m_iTransferSetPointTextChanged And 1
                If temp > 0 Then
                    LogUserEvent("LLA Transfer Point Changed To: " & txtTransferLLA.Text)
                End If

                temp = m_iTransferSetPointTextChanged And 4
                If temp > 0 Then
                    LogUserEvent("TM Transfer Point Changed To: " & txtTransferTM.Text)
                End If

                temp = m_iTransferSetPointTextChanged And 8
                If temp > 0 Then
                    LogUserEvent("PM1 Transfer Point Changed To: " & txtTransferPM1.Text)
                End If

                temp = m_iTransferSetPointTextChanged And 16
                If temp > 0 Then
                    LogUserEvent("PM2 Transfer Point Changed To: " & txtTransferPM2.Text)
                End If

                temp = m_iTransferSetPointTextChanged And 32
                If temp > 0 Then
                    LogUserEvent("PM3 Transfer Point Changed To: " & txtTransferPM3.Text)
                End If

            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-08-22</date>
    ''' </author>
    ''' <summary>
    '''  Log Vent SP changed to LogAlarmAndEvent
    ''' </summary>
    Private Sub VentSetPoint_LogAlarmAndEvent()
        Try
            Dim temp As Integer = 0

            If (m_iVentSetPointTextChanged > 0) Then

                temp = m_iVentSetPointTextChanged And 1
                If temp > 0 Then
                    LogUserEvent("LLA Vent Pressure SetPoint Changed To: " & txtVentLLA.Text)
                End If

                temp = m_iVentSetPointTextChanged And 4
                If temp > 0 Then
                    LogUserEvent("TM Vent Pressure SetPoint Changed To: " & txtVentTM.Text)
                End If

            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-08-22</date>
    ''' </author>
    ''' <summary>
    '''  Log CrossOver SP changed to LogAlarmAndEvent
    ''' </summary>
    Private Sub CrossOverSetPoint_LogAlarmAndEvent()
        Try
            Dim temp As Integer = 0

            If (m_iCrossOverSetPointTextChanged > 0) Then

                temp = m_iCrossOverSetPointTextChanged And 1
                If temp > 0 Then
                    LogUserEvent("LLA CrossOver Pressure SetPoint Changed To: " & txtCrossOverLLA.Text)
                End If

                temp = m_iCrossOverSetPointTextChanged And 4
                If temp > 0 Then
                    LogUserEvent("TM CrossOver Pressure SetPoint Changed To: " & txtCrossOverTM.Text)
                End If

            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-08-22</date>
    ''' </author>
    ''' <summary>
    '''  Log SlowRough SP changed to LogAlarmAndEvent
    ''' </summary>
    Private Sub SlowRoughSetPoint_LogAlarmAndEvent()
        Try
            Dim temp As Integer = 0

            If (m_iSlowRoughSetPointTextChanged > 0) Then

                temp = m_iSlowRoughSetPointTextChanged And 1
                If temp > 0 Then
                    LogUserEvent("LLA SlowRough Pressure SetPoint Changed To: " & txtSlowRoughLLA.Text)
                End If

            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-08-22</date>
    ''' </author>
    ''' <summary>
    '''  Log SlowVent SP changed to LogAlarmAndEvent
    ''' </summary>
    Private Sub SlowVentSetPoint_LogAlarmAndEvent()
        Try
            Dim temp As Integer = 0

            If (m_iSlowVentSetPointTextChanged > 0) Then

                temp = m_iSlowVentSetPointTextChanged And 1
                If temp > 0 Then
                    LogUserEvent("LLA SlowVent Pressure SetPoint Changed To: " & txtSlowVentLLA.Text)
                End If

            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-08-22</date>
    ''' </author>
    ''' <summary>
    '''  Log pumpdown setting changed to LogAlarmAndEvent
    ''' </summary>
    Private Sub PumpdownSettings_LogAlarmAndEvent()
        CrossOverSetPoint_LogAlarmAndEvent()
        SlowRoughSetPoint_LogAlarmAndEvent()
    End Sub

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-08-22</date>
    ''' </author>
    ''' <summary>
    '''  Log Vent setting changed to LogAlarmAndEvent Screen
    ''' </summary>
    Private Sub VentSettings_LogAlarmAndEvent()
        VentSetPoint_LogAlarmAndEvent()
        SlowVentSetPoint_LogAlarmAndEvent()
    End Sub

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-08-22</date>
    ''' </author>
    ''' <summary>
    '''  Log Transfer SP changed to LotDataLog and LogAlarmAndEvent
    ''' </summary>
    Private Sub TransferSetPoint_LogData()
        TransferSetPoint_LotDatalog()
        'TransferSetPoint_LogAlarmAndEvent()
        m_iTransferSetPointTextChanged = 0
    End Sub

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-08-22</date>
    ''' </author>
    ''' <summary>
    '''  Log Vent setting changed to LotDataLog and LogAlarmAndEvent
    ''' </summary>
    Private Sub VentSettings_LogData()
        VentSettings_LotDatalog()
        'VentSettings_LogAlarmAndEvent()
        m_iVentSetPointTextChanged = 0
        m_iSlowVentSetPointTextChanged = 0
    End Sub

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-08-22</date>
    ''' </author>
    ''' <summary>
    '''  Log pumpdown setting changed to LotDataLog and LogAlarmAndEvent
    ''' </summary>
    Private Sub PumpdownSettings_LogData()
        PumpdownSettings_LotDatalog()
        'PumpdownSettings_LogAlarmAndEvent()
        m_iCrossOverSetPointTextChanged = 0
        m_iSlowRoughSetPointTextChanged = 0
    End Sub
#End Region

#Region "Reset Value"
    Private Sub ResetWaferCount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWaferCountPM1.Click, _
    txtWaferCountPM2.Click, txtWaferCountPM3.Click
        Dim strMessageText As String = AVPLib.ContainerData.GetMessageText("ResetWaferCounter")
        Dim ChamberType As String = String.Empty
        If (sender Is txtWaferCountPM3) Then
            If (Utils.ShowAVPMessageBox(strMessageText, "PM3", MessageBoxIcon.Question, MessageBoxButtons.YesNo) = DialogResult.OK) Then
                Dim objChamber3 As DataManagerment.Chamber = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber3.ToString())
                If (objChamber3 IsNot Nothing) Then
                    objChamber3.ResetWaferCount()
                    txtWaferCountPM3.Text = "0"
                    AddLotDatalog(ConstEnum.PM3, "Reset Wafer Count")
                    LogUserEvent(ConstEnum.PM3 + " Reset Wafer Count")
                    ChamberType = AVPLib.Utils.GetChamberType(ConstEnum.Equipments.Chamber3.ToString())
                    Utils.CheckChangeValue(ConstEnum.PM3 & "_" & ChamberType & "_" & "WaferCount ", txtWaferCountPM3.Text, 0)
                End If

            End If
        ElseIf (sender Is txtWaferCountPM2) Then
            If (Utils.ShowAVPMessageBox(strMessageText, "PM2", MessageBoxIcon.Question, MessageBoxButtons.YesNo) = DialogResult.OK) Then
                Dim objChamber2 As DataManagerment.Chamber = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber2.ToString())
                If (objChamber2 IsNot Nothing) Then
                    objChamber2.ResetWaferCount()
                    txtWaferCountPM2.Text = "0"
                    AddLotDatalog(ConstEnum.PM2, "Reset Wafer Count")
                    LogUserEvent(ConstEnum.PM2 + " Reset Wafer Count")
                    ChamberType = AVPLib.Utils.GetChamberType(ConstEnum.Equipments.Chamber2.ToString())
                    Utils.CheckChangeValue(ConstEnum.PM2 & "_" & ChamberType & "_" & "WaferCount ", txtWaferCountPM2.Text, 0)
                End If

            End If
        ElseIf (sender Is txtWaferCountPM1) Then
            If (Utils.ShowAVPMessageBox(strMessageText, "PM1", MessageBoxIcon.Question, MessageBoxButtons.YesNo) = DialogResult.OK) Then
                Dim objChamber1 As DataManagerment.Chamber = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber1.ToString())
                If (objChamber1 IsNot Nothing) Then
                    objChamber1.ResetWaferCount()
                    txtWaferCountPM1.Text = "0"
                    AddLotDatalog(ConstEnum.PM1, "Reset Wafer Count")
                    LogUserEvent(ConstEnum.PM1 + " Reset Wafer Count")
                    ChamberType = AVPLib.Utils.GetChamberType(ConstEnum.Equipments.Chamber1.ToString())
                    Utils.CheckChangeValue(ConstEnum.PM1 & "_" & ChamberType & "_" & "WaferCount ", txtWaferCountPM1.Text, 0)
                End If

            End If
        End If
    End Sub

    Private Sub ResetShield_Quartz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                                 txtShieldPM1.Click, txtShieldsPM2.Click, txtShieldsPM3.Click
        Try
            If CType(sender, TextBox).Name.Contains("PM1") Then
                If PM1ChamberType = SystemModule.ModuleType.PVD4 OrElse PM1ChamberType = SystemModule.ModuleType.PVD5T Then
                    Me.PM1ShieldsQuartzPopUpPanel.ShowDialog(AVPRobotMain)
                    Exit Try
                End If
            ElseIf CType(sender, TextBox).Name.Contains("PM2") Then
                If PM2ChamberType = SystemModule.ModuleType.PVD4 OrElse PM2ChamberType = SystemModule.ModuleType.PVD5T Then
                    Me.PM2ShieldsQuartzPopUpPanel.ShowDialog(AVPRobotMain)
                    Exit Try
                End If
            ElseIf CType(sender, TextBox).Name.Contains("PM3") Then
                If PM3ChamberType = SystemModule.ModuleType.PVD4 OrElse PM3ChamberType = SystemModule.ModuleType.PVD5T Then
                    Me.PM3ShieldsQuartzPopUpPanel.ShowDialog(AVPRobotMain)
                    Exit Try
                End If
            End If

            If Not (Utils.GetUserInput(sender, True) = MsgBoxResult.Ok) Then
                Exit Try
            End If
            Dim objChamber As DataManagerment.Chamber = Nothing
            Dim objController As Business.ChamberController = Nothing
            Dim txt As TextBox = CType(sender, TextBox)
            Dim strPM As String = String.Empty
            Dim strShieldSource As String = String.Empty
            Select Case txt.Name
                Case txtShieldPM1.Name
                    objChamber = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber1.ToString())
                    objController = Business.ControllerManager.GetController(ConstEnum.Equipments.Chamber1.ToString())
                    strPM = RobotConfigurationValues.CHAMBER1_NAME
                    strShieldSource = strPM & "_" & PM1ChamberType & "_ShieldsQuartz"
                Case txtShieldsPM2.Name
                    objChamber = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber2.ToString())
                    objController = Business.ControllerManager.GetController(ConstEnum.Equipments.Chamber2.ToString())
                    strPM = RobotConfigurationValues.CHAMBER2_NAME
                    strShieldSource = strPM & "_" & PM2ChamberType & "_ShieldsQuartz"
                Case txtShieldsPM3.Name
                    objChamber = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber3.ToString())
                    objController = Business.ControllerManager.GetController(ConstEnum.Equipments.Chamber3.ToString())
                    strPM = RobotConfigurationValues.CHAMBER3_NAME
                    strShieldSource = strPM & "_" & PM3ChamberType & "_ShieldsQuartz"
            End Select
            ''check obj exist
            If objChamber Is Nothing OrElse objController Is Nothing Then
                Exit Try
            End If
            'confirm user
            'Dim strMessageText As String = AVPLib.ContainerData.GetMessageText("ResetShieldQuartz")
            'If (Utils.ShowAVPMessageBox(strMessageText, strPM, MessageBoxIcon.Question, MessageBoxButtons.YesNo) = DialogResult.OK) Then
            'log action
            Dim oldValue As String = GetStoredValue(txt.Name)
            Utils.CheckChangeValue(strShieldSource, oldValue, txt.Text)
            LogUserEvent(String.Format("Reset Shield/Quartz {0}{1} to {2}", strPM, IIf(String.IsNullOrEmpty(oldValue), "", " from " & oldValue), txt.Text))
            'check connection befor reset
            If objChamber.ConnectionStatus = DataManagerment.Equipment.WorkingStatuses.Off Then
                AVPLib.Utils.ThrowAlarm("Failed to reset value when " & strPM & " is disconnected", AVPLib.ConstEnum.GEM_ALARM_SYSTEM)
                txt.Text = oldValue
                Exit Try
            End If
            'if obj is really exist
            If ContainerForm.ChamberPanel(objChamber.Name).ChamberType = SystemModule.ModuleType.IBE Then
                CType(objController.Myself, Business.IBEController).DoResetQuartz(txt.Text)
            ElseIf ContainerForm.ChamberPanel(objChamber.Name).ChamberType = SystemModule.ModuleType.PVD Then
                CType(objController.Myself, Business.PVDController).DoResetShieldKWH(txt.Text)
            End If
            'End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''Truc Le add
    Private Sub txtUsageKWH_PM1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                       txtUsageKWH_PM1.Click, txtUsageKWH_PM2.Click, txtUsageKWH_PM3.Click
        Try
            If CType(sender, TextBox).Name.Contains("PM1") Then
                If PM1ChamberType = SystemModule.ModuleType.PVD4 OrElse PM1ChamberType = SystemModule.ModuleType.PVD5T Then
                    Me.PM1TargetPSConfigPopUpPanel.ShowDialog(AVPRobotMain)
                    Exit Try
                End If
            ElseIf CType(sender, TextBox).Name.Contains("PM2") Then
                If PM2ChamberType = SystemModule.ModuleType.PVD4 OrElse PM2ChamberType = SystemModule.ModuleType.PVD5T Then
                    Me.PM2TargetPSConfigPopUpPanel.ShowDialog(AVPRobotMain)
                    Exit Try
                End If
            ElseIf CType(sender, TextBox).Name.Contains("PM3") Then
                If PM3ChamberType = SystemModule.ModuleType.PVD4 OrElse PM3ChamberType = SystemModule.ModuleType.PVD5T Then
                    Me.PM3TargetPSConfigPopUpPanel.ShowDialog(AVPRobotMain)
                    Exit Try
                End If
            End If

            If Not (Utils.GetUserInput(sender, True) = MsgBoxResult.Ok) Then
                Exit Try
            End If
            Dim objChamber As DataManagerment.Chamber = Nothing
            Dim objController As Business.ChamberController = Nothing
            Dim txt As TextBox = CType(sender, TextBox)
            Dim strPM As String = String.Empty
            Dim strShieldSource As String = String.Empty
            Select Case txt.Name
                Case txtUsageKWH_PM1.Name
                    objChamber = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber1.ToString())
                    objController = Business.ControllerManager.GetController(ConstEnum.Equipments.Chamber1.ToString())
                    strPM = RobotConfigurationValues.CHAMBER1_NAME
                    strShieldSource = strPM & "_" & PM1ChamberType.ToString()
                Case txtUsageKWH_PM2.Name
                    objChamber = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber2.ToString())
                    objController = Business.ControllerManager.GetController(ConstEnum.Equipments.Chamber2.ToString())
                    strPM = RobotConfigurationValues.CHAMBER2_NAME
                    strShieldSource = strPM & "_" & PM2ChamberType.ToString()
                Case txtUsageKWH_PM3.Name
                    objChamber = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber3.ToString())
                    objController = Business.ControllerManager.GetController(ConstEnum.Equipments.Chamber3.ToString())
                    strPM = RobotConfigurationValues.CHAMBER3_NAME
                    strShieldSource = strPM & "_" & PM3ChamberType.ToString()
            End Select
            ''check obj exist
            If objChamber Is Nothing OrElse objController Is Nothing Then
                Exit Try
            End If
            '''confirm user
            'Dim strMessageText As String = AVPLib.ContainerData.GetMessageText("ResetTargetSource")
            'If (Utils.ShowAVPMessageBox(strMessageText, strPM, MessageBoxIcon.Question, MessageBoxButtons.YesNo) = DialogResult.OK) Then
            'log action
            Dim oldValue As String = GetStoredValue(txt.Name)
            Utils.CheckChangeValue(strShieldSource & "_" & "UsageKWH", oldValue, txt.Text)
            LogUserEvent(String.Format("Set/Reset Target KWH/Source Usage {0}{1} to {2}", strPM, IIf(String.IsNullOrEmpty(oldValue), "", " from " & oldValue), txt.Text))
            'check connection befor reset
            If objChamber.ConnectionStatus = DataManagerment.Equipment.WorkingStatuses.Off Then
                AVPLib.Utils.ThrowAlarm("Failed to set/reset value when " & strPM & " is disconnected", AVPLib.ConstEnum.GEM_ALARM_SYSTEM)
                txt.Text = oldValue
                Exit Try
            End If
            'if obj is really exist-->send command
            If ContainerForm.ChamberPanel(objChamber.Name).ChamberType = SystemModule.ModuleType.IBE Then
                CType(objController.Myself, Business.IBEController).DoResetSourceUsage(txt.Text)
            ElseIf ContainerForm.ChamberPanel(objChamber.Name).ChamberType = SystemModule.ModuleType.PVD Then
                CType(objController.Myself, Business.PVDController).DoResetTargetKWH(txt.Text)
            End If
            'End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

#End Region

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2013-11-29</date>
    ''' </author>
    ''' <summary>
    ''' read config file
    ''' apply for Delay time after process complete
    ''' </summary>
    Private Sub SaveDelayTimeAfterProcessComplete(ByVal minutes As String)
        Try
            ' path of device net config
            Dim xmldoc As System.Xml.XmlDocument = AVPLib.ContainerDAO.SystemConfigDoc
            Dim root As System.Xml.XmlNode = xmldoc.SelectSingleNode(ConstEnum.XPATH_DELAYTIME_AFTERPROCESSCOMPLETE)
            If (root IsNot Nothing) Then
                root.InnerText = minutes.ToString
                BinarySerialize.SaveTo_DatFileConfig(AVPLib.ContainerDAO.FPath_SystemConfig, xmldoc)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub btnApplyTimeOut_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApplyTimeOut.Click
        Try
            Dim bResult As Boolean = False
            Dim subSource As String = "TimeOut"

            LogUserEvent("Apply Button Clicked", subSource)

            Dim LLVentTimeOut As Hashtable = New Hashtable()
            LLVentTimeOut.Add(LL_MESA_VALVE_OPEN_CLOSE_TIMEOUT, txtMesaValveTO.Text.Trim())
            LLVentTimeOut.Add(IG_ON_OFF_TIMEOUT, txtIGOnOffTO.Text.Trim())
            LLVentTimeOut.Add(LL_HIVAC_OPEN_CLOSE_TIMEOUT, txtHivacTO.Text.Trim())
            LLVentTimeOut.Add(LLA_SLOW_VENT_TIMEOUT, txtLLASlowVentTO.Text.Trim())
            LLVentTimeOut.Add(LLA_FAST_VENT_TIMEOUT, txtLLAFastVentTO.Text.Trim())
            LLVentTimeOut.Add(LL_VENT_VALVE_OPEN_CLOSE_TIMEOUT, txtLLVentValveTO.Text.Trim())
            LLVentTimeOut.Add(LL_VENT_DELAY_TIME, txtLLContinueVent.Text.Trim())

            bResult = AVPLib.ContainerData.SaveVent(LLVentTimeOut, AVPLib.ConstEnum.LLVENT_CONFIG)
            bResult = bResult AndAlso AVPLib.ContainerDAO.SaveDegasWaitTime(txtDegasWaitTimeLLA.Text, txtDegasWaitTimeTM.Text)

            If (Not bResult) Then
                Utils.ShowAVPMessageBox("Failed to Save LL Vent Settings", "LoadLock Vent Setting", MessageBoxIcon.Error, MessageBoxButtons.OK)
                LogUserEvent("Failed to Save LL Vent Settings when apply time out.", subSource)
                Return
            End If

            Integer.TryParse(txtDegasWaitTimeLLA.Text, AVPLib.RobotConfigurationValues.LLA_IGDEGAS_WAIT_TIME_IN_SECONDS)
            Integer.TryParse(txtDegasWaitTimeTM.Text, AVPLib.RobotConfigurationValues.TM_IGDEGAS_WAIT_TIME_IN_SECONDS)

            '<!-- Log
            LogUserEvent(txtMesaValveTO)
            LogUserEvent(txtIGOnOffTO)
            LogUserEvent(txtHivacTO)
            LogUserEvent(txtLLASlowVentTO)
            LogUserEvent(txtLLAFastVentTO)
            LogUserEvent(txtLLVentValveTO)
            LogUserEvent(txtLLContinueVent)
            LogUserEvent(txtDegasWaitTimeLLA, subSource)
            LogUserEvent(txtDegasWaitTimeTM, subSource)
            '-->

            Dim TMVentTimeOut As Hashtable = New Hashtable()
            TMVentTimeOut.Add(TM_MESA_VALVE_OPEN_CLOSE_TIMEOUT, txtMesaValveTO.Text.Trim())
            TMVentTimeOut.Add(IG_ON_OFF_TIMEOUT, txtIGOnOffTO.Text.Trim())
            TMVentTimeOut.Add(TM_HIVAC_OPEN_CLOSE_TIMEOUT, txtHivacTO.Text.Trim())
            TMVentTimeOut.Add(TM_VENT_TIMEOUT, txtTMVentTO.Text.Trim())
            TMVentTimeOut.Add(TM_VENT_VALVE_OPEN_CLOSE_TIMEOUT, txtTMVentValveTO.Text.Trim())
            TMVentTimeOut.Add(TM_VENT_DELAY_TIME, txtTMContinueVent.Text.Trim())
            bResult = AVPLib.ContainerData.SaveVent(TMVentTimeOut, AVPLib.ConstEnum.TMVENT_CONFIG)
            If (Not bResult) Then
                Utils.ShowAVPMessageBox("Failed to Save TM Vent Settings", "TM Vent Setting", MessageBoxIcon.Error, MessageBoxButtons.OK)
                LogUserEvent("Failed to Save TM Vent Settings when apply time out.", subSource)
                Return
            End If

            '<!-- Log
            LogUserEvent(txtMesaValveTO)
            LogUserEvent(txtIGOnOffTO)
            LogUserEvent(txtHivacTO)
            LogUserEvent(txtTMVentTO)
            LogUserEvent(txtTMVentValveTO)
            LogUserEvent(txtTMContinueVent)
            '-->

            Dim LLPumpdownTimeOut As Hashtable = New Hashtable()
            LLPumpdownTimeOut.Add(LL_MESA_VALVE_OPEN_CLOSE_TIMEOUT, txtMesaValveTO.Text.Trim())
            LLPumpdownTimeOut.Add(IG_ON_OFF_TIMEOUT, txtIGOnOffTO.Text.Trim())
            LLPumpdownTimeOut.Add(LL_HIVAC_OPEN_CLOSE_TIMEOUT, txtHivacTO.Text.Trim())
            LLPumpdownTimeOut.Add(LLA_SLOW_ROUGH_PRESSURE_TIMEOUT, txtLLASlowRoughTO.Text.Trim())
            LLPumpdownTimeOut.Add(LLA_FAST_ROUGH_PRESSURE_TIMEOUT, txtLLAFastRoughTO.Text.Trim())
            LLPumpdownTimeOut.Add(IG_ON_DELAY, txtLLDelayTimeTurnOnIG.Text.Trim())
            LLPumpdownTimeOut.Add(LL_ROUGH_VALVE_OPEN_CLOSE_TIMEOUT, txtLLRoughValveTO.Text.Trim())
            LLPumpdownTimeOut.Add(LL_PUMPDOWN_DELAY_TIME, txtLLContinuePumpDown.Text.Trim())
            bResult = AVPLib.ContainerData.SavePumpDown(LLPumpdownTimeOut, AVPLib.ConstEnum.LLPUMPDOWN_CONFIG)
            If (Not bResult) Then
                Utils.ShowAVPMessageBox("Failed to Save LoadLock Pumpdown Settings", "LoadLock Pumpdown Setting", MessageBoxIcon.Error, MessageBoxButtons.OK)
                LogUserEvent("Failed to Save LoadLock Pumpdown Settings when apply time out.", subSource)
                Return
            End If

            '<!-- Log
            LogUserEvent(txtMesaValveTO)
            LogUserEvent(txtIGOnOffTO)
            LogUserEvent(txtHivacTO)
            LogUserEvent(txtLLASlowRoughTO)
            LogUserEvent(txtLLAFastRoughTO)
            LogUserEvent(txtLLDelayTimeTurnOnIG)
            LogUserEvent(txtLLRoughValveTO)
            LogUserEvent(txtLLContinuePumpDown)
            '-->

            Dim TMPumpdownTimeOut As Hashtable = New Hashtable()
            TMPumpdownTimeOut.Add(TM_MESA_VALVE_OPEN_CLOSE_TIMEOUT, txtMesaValveTO.Text.Trim())
            TMPumpdownTimeOut.Add(IG_ON_OFF_TIMEOUT, txtIGOnOffTO.Text.Trim())
            TMPumpdownTimeOut.Add(TM_HIVAC_OPEN_CLOSE_TIMEOUT, txtHivacTO.Text.Trim())
            TMPumpdownTimeOut.Add(TM_ROUGH_TIMEOUT, txtTMRoughTO.Text.Trim())
            TMPumpdownTimeOut.Add(TM_PUMPDOWN_DELAY_TIME, txtTMContinuePumpDown.Text.Trim())
            TMPumpdownTimeOut.Add(IG_ON_DELAY, txtTMDelayTimeTurnOnIG.Text.Trim())
            bResult = AVPLib.ContainerData.SavePumpDown(TMPumpdownTimeOut, AVPLib.ConstEnum.TMPUMPDOWN_CONFIG)
            If (Not bResult) Then
                Utils.ShowAVPMessageBox("Failed to Save TM Pumpdown Settings", "TM Pumpdown Setting", MessageBoxIcon.Error, MessageBoxButtons.OK)
                LogUserEvent("Failed to Save TM Pumpdown Settings when apply time out.", subSource)
                Return
            End If

            '<!-- Log
            LogUserEvent(txtMesaValveTO)
            LogUserEvent(txtIGOnOffTO)
            LogUserEvent(txtHivacTO)
            LogUserEvent(txtTMRoughTO)
            LogUserEvent(txtTMContinuePumpDown)
            LogUserEvent(txtTMDelayTimeTurnOnIG)
            '-->

            bResult = AVPLib.ContainerData.SaveSystemWaitForCheckSensor(txtSystemCheckSensor.Text.Trim())
            If (Not bResult) Then
                Utils.ShowAVPMessageBox("Failed to Save System Wait For Check Sensor Setting", "TM Setting", MessageBoxIcon.Error, MessageBoxButtons.OK)
                LogUserEvent("Failed to Save System Wait For Check Sensor Setting.", subSource)
                Return
            End If

            '<!-- Log
            LogUserEvent(txtSystemCheckSensor)
            '-->

            bResult = AVPLib.ContainerData.SaveSystemIDLE_Time(txtAutoLog.Text.Trim())
            If (Not bResult) Then
                Utils.ShowAVPMessageBox("Failed to Save Auto LogOut TimeOut", "TM Setting", MessageBoxIcon.Error, MessageBoxButtons.OK)
                LogUserEvent("Failed to Save Auto LogOut TimeOut.", subSource)
                Return
            End If
            Double.TryParse(txtAutoLog.Text.Trim(), AVPRobotMain.AdminAutologOffTime)

            '<!-- Log
            LogUserEvent(txtAutoLog)
            '-->

            Dim transferSetPointWaitTimeInSeconds = 0.0
            Double.TryParse(txtTransferSetPointWaitTimeInSeconds.Text, transferSetPointWaitTimeInSeconds)
            transferSetPointWaitTimeInSeconds = transferSetPointWaitTimeInSeconds * 60
            AVPLib.ContainerData.SetRobotConfig(ConstEnum.TRANSFER_SET_POINT_WAIT_TIME_IN_SECONDS, transferSetPointWaitTimeInSeconds.ToString())

            '<!-- Log
            LogUserEvent(txtTransferSetPointWaitTimeInSeconds)
            '-->

            If (bResult) Then
                Utils.ShowAVPMessageBox("Time Out saved successfully", "TimeOut Setting", MessageBoxIcon.Information, MessageBoxButtons.OK)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub btnResetLLScheduler_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnResetLLAScheduler.Click
        Try
            Dim LLName As String = String.Empty
            If CType(sender, Button).Name = btnResetLLAScheduler.Name Then
                LLName = ConstEnum.Equipments.LoadLockA.ToString()
            End If

            If (Utils.ShowAVPWarningBox("Are You Sure You Want To\nReset Scheduler " & LLA_STR & " ?", "Confirmation") = DialogResult.OK) Then
                Dim objLLController As Business.LoadLockController = Business.ControllerManager.GetController(LLName)
                Dim objCJ As AVPLib.Business.AVPControlJob = AVPLib.Business.AVPCore.Instance().JobManager().GetControlJob(objLLController.CtrlJobId)
                If objCJ Is Nothing Then
                    Dim lpcLoadLock As LockProcessControl = Nothing
                    lpcLoadLock = ContainerForm.ProcessPanel.lpcLoadLockA
                    lpcLoadLock.ResetProcessStatus()
                    Return
                End If

                Dim newThread As New System.Threading.Thread(AddressOf objLLController.ForceAbort)
                newThread.Start()
                LogUserEvent("Click on button reset " + LLName + " Scheduler.")
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hoai Ly </name>
    '''     <date> 2015-05-27 </date>
    ''' </author>
    ''' <summary>
    ''' Open Folder Browser Dialog when user click btnArchiveConfigFile or txtArchiveConfigFile
    ''' </summary>
    Private Sub btnArchiveConfigFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArchiveConfigFile.Click, txtArchiveConfigFile.Click
        Dim dialog = New FolderBrowserDialog()
        dialog.SelectedPath = Application.StartupPath
        If DialogResult.OK = dialog.ShowDialog() Then
            StoreValueBeforeChanged(txtArchiveConfigFile)
            txtArchiveConfigFile.Text = dialog.SelectedPath.ToString
        End If
    End Sub

    ''' <author>
    '''     <name> Hoai Ly </name>
    '''     <date> 2015-09-10 </date>
    ''' </author>
    ''' <summary>
    ''' btnArchiveNow_Click
    ''' </summary>
    Private Sub btnArchiveNow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArchiveNow.Click
        Try
            Me.btnArchiveNow.Enabled = False
            SaveAutoArchiveSystemConfigFilePath(txtArchiveConfigFile.Text)
            Threading.ThreadPool.QueueUserWorkItem(AddressOf AVPRobotMain.AutoArchiveConfigFile, True)
        Catch ex As Exception
            Me.btnArchiveNow.Enabled = True
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-06-19 </date>
    ''' </author>
    ''' <summary>
    ''' Create Shields Quartz Setting Pop Up for PM
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CreateShieldsQuartzPopUpPanel(ByRef PMxShieldsQuartzPopUpPanel As SystemSetupShieldQuartz, ByVal chamberNumber As Integer, chamberType As SystemModule.ModuleType)
        Try
            If PMxShieldsQuartzPopUpPanel Is Nothing Then
                PMxShieldsQuartzPopUpPanel = New SystemSetupShieldQuartz
                PMxShieldsQuartzPopUpPanel.StartPosition = FormStartPosition.CenterScreen
                PMxShieldsQuartzPopUpPanel.ShowInTaskbar = False
                PMxShieldsQuartzPopUpPanel.ShowIcon = False
                PMxShieldsQuartzPopUpPanel.ParentStatusObject = Me.m_stoStatusObject
                PMxShieldsQuartzPopUpPanel.Text = "System Setup for Shields/Quartz PM" & chamberNumber.ToString()
                PMxShieldsQuartzPopUpPanel.ChamberName = ConstantAndEnum.CHAMBER.ToString() & chamberNumber.ToString()
                PMxShieldsQuartzPopUpPanel.SetupTargetShieldQuartz(chamberType)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub


    ''' <author>
    '''     <name> Tin Vu </name>
    '''     <date> 2015-06-11 </date>
    ''' </author>
    ''' <summary>
    ''' dgvEmailUser_CellClick Cell rid Click event EmailTo rid
    ''' </summary>
    Private Sub dgvEmailUser_CellClick_CheckBox(ByVal COL_NAME As String, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        Try
            If Me.dgvEmailUser.Columns(e.ColumnIndex).Name = COL_NAME Then

                If Me.dgvEmailUser.Rows(e.RowIndex).Cells(COL_NAME).Value = True Then
                    Me.dgvEmailUser.Rows(e.RowIndex).Cells(COL_NAME).Value = False
                Else
                    Me.dgvEmailUser.Rows(e.RowIndex).Cells(COL_NAME).Value = True
                End If

                Dim objEmail As TriggerEmail = AVPLib.SendEmail.Instance.GetTrigger(Me.dgvEmailUser.Rows(e.RowIndex).Cells(COL_EMAILNAME).Value)
                If objEmail IsNot Nothing Then
                    Dim blnIsCName As Boolean = False
                    Boolean.TryParse(Me.dgvEmailUser.Rows(e.RowIndex).Cells(COL_NAME).Value, blnIsCName)

                    Select Case COL_NAME
                        Case COL_ALARM
                            objEmail.IsAlarm = blnIsCName
                        Case COL_PRESSURE
                            objEmail.IsPressure = blnIsCName
                        Case COL_SCHEDULER
                            objEmail.IsScheduler = blnIsCName
                    End Select

                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Tin Vu </name>
    '''     <date> 2015-06-11 </date>
    ''' </author>
    ''' <summary>
    ''' dgvEmailUser_CellClick Cell rid Click event EmailTo rid
    ''' </summary>
    Private Sub dgvEmailUser_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEmailUser.CellClick
        Try
            If e.RowIndex < 0 Then
                AVPLib.Log.guiLogger.Info("Leave dgvData_CellClick")
                Exit Sub
            End If

            ' Edit Cell
            If e.ColumnIndex = COL_EDIT_POSITION Then
                ' MessageBox.Show(" Edit")
                Dim editmail As New TriggerEmail_Popup()

                Dim objEmail As TriggerEmail = AVPLib.SendEmail.Instance.GetTrigger(Me.dgvEmailUser.Rows(e.RowIndex).Cells(COL_EMAILNAME).Value)
                If objEmail IsNot Nothing Then
                    editmail.TrigerEmail = objEmail
                End If

                editmail.ShowDialog(AVPRobotMain)

                If editmail.DialogResult = DialogResult.OK Then
                    If editmail.IsModifiedValue Then
                        Dim objNewEmail As TriggerEmail = editmail.TrigerEmail
                        AVPLib.SendEmail.Instance.RemoveTrigger(Me.dgvEmailUser.Rows(e.RowIndex).Cells(COL_EMAILNAME).Value)
                        AVPLib.SendEmail.Instance.AddTrigger(objNewEmail.Name, objNewEmail)

                        ''''''''''''''''''''''''
                        AddRowEmailGrid()
                        ''''''''''''''''''''''''

                        Me.dgvEmailUser.DataSource = m_dtEmailData
                        Me.dgvEmailUser.Refresh()
                    End If
                End If

                'Remove Cell
            ElseIf e.ColumnIndex = COL_REMOVE_POSITION Then
                Dim objEmail As TriggerEmail = AVPLib.SendEmail.Instance.GetTrigger(Me.dgvEmailUser.Rows(e.RowIndex).Cells(COL_EMAILNAME).Value)

                If objEmail IsNot Nothing Then
                    'pop up message confirm before remove action 
                    If Utils.ShowAVPMessageBox("Delete This Email" & Chr(10) & Chr(13) & objEmail.Name, "Confirm", _
                      MessageBoxIcon.Exclamation, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.OK Then

                        AVPLib.SendEmail.Instance.RemoveTrigger(Me.dgvEmailUser.Rows(e.RowIndex).Cells(COL_EMAILNAME).Value)
                        AddRowEmailGrid()
                    End If
                End If

            Else
                ' Checked email Cell
                dgvEmailUser_CellClick_CheckBox("", e)
                ' Alarm Cell
                dgvEmailUser_CellClick_CheckBox(COL_ALARM, e)
                'Pressure Cell
                dgvEmailUser_CellClick_CheckBox(COL_PRESSURE, e)
                'Scheduler Cell
                dgvEmailUser_CellClick_CheckBox(COL_SCHEDULER, e)

            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Tin Vu </name>
    '''     <date> 2015-06-11 </date>
    ''' </author>
    ''' <summary>
    ''' AddRowEmailGrid() use to add rows to email rid table
    ''' </summary>
    Private Sub AddRowEmailGrid()
        Try
            Dim ListKeys As System.Collections.IEnumerator = AVPLib.SendEmail.Instance.HashTriggers.Keys().GetEnumerator()

            m_dtEmailData.Rows.Clear()

            While (ListKeys.MoveNext)

                Dim EmailInfo As String = ListKeys.Current.ToString()
                Dim dtRow As DataRow = m_dtEmailData.NewRow
                Dim trigerEmail As TriggerEmail = AVPLib.SendEmail.Instance.GetTrigger(EmailInfo)

                dtRow(COL_EMAILNAME) = EmailInfo
                dtRow(COL_ALARM) = trigerEmail.IsAlarm
                dtRow(COL_SCHEDULER) = trigerEmail.IsScheduler
                dtRow(COL_PRESSURE) = trigerEmail.IsPressure

                m_dtEmailData.Rows.Add(dtRow)

            End While
            If (dgvEmailUser.Columns(COL_EMAILNAME)) IsNot Nothing Then
                Dim col As DataGridViewColumn = dgvEmailUser.Columns(COL_EMAILNAME)
                If dgvEmailUser.RowCount > 11 Then
                    col.Width = 396
                Else
                    col.Width = 413
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Tin Vu </name>
    '''     <date> 2015-06-11 </date>
    ''' </author>
    ''' <summary>
    ''' </summary>
    Private Sub AddCheckBoxColumn(ByVal nameCol As String, Optional ByVal iDefaultWidth As Integer = 100)
        Try
            'add Checkbox column
            Dim COL_CheckBox As DataGridViewColumn = New DataGridViewCheckBoxColumn()
            With COL_CheckBox
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DataPropertyName = nameCol
                .Name = nameCol
                .Width = iDefaultWidth
            End With
            dgvEmailUser.Columns.Add(COL_CheckBox)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Tin Vu </name>
    '''     <date> 2015-06-11 </date>
    ''' </author>
    ''' <summary>
    ''' </summary>
    Private Sub AddButtonColumn(ByVal nameCol As String)
        Try
            'add Button column
            Dim COL_Button As DataGridViewColumn = New DataGridViewButtonColumn()
            With COL_Button
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 50
                .DataPropertyName = nameCol
            End With
            dgvEmailUser.Columns.Add(COL_Button)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Tin Pham </name>
    '''     <date> 2015-08-07 </date>
    ''' </author>
    ''' <summary>
    ''' </summary>
    Private Sub AddTextBoxColumn(ByVal nameCol As String)
        Try
            'add TextBox column
            Dim columnEmailName As DataGridViewColumn = New DataGridViewTextBoxColumn()

            With columnEmailName
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                If dgvEmailUser.RowCount > 11 Then
                    .Width = 396
                Else
                    .Width = 413
                End If
                .DataPropertyName = nameCol
                .Name = nameCol
            End With
            dgvEmailUser.Columns.Add(columnEmailName)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Tin Pham </name>
    '''     <date> 2015-08-07 </date>
    ''' </author>
    ''' <summary>
    ''' </summary>
    Private Sub AddCheckBoxOnHeader()
        Try
            Dim header As DataGridViewHeaderCell = Me.dgvEmailUser.Columns(0).HeaderCell
            Dim checkAll As CheckBox = New CheckBox()
            checkAll.Size = New Size(14, 14)
            checkAll.Location = New Point((header.Size.Width / 2) - (checkAll.Size.Width / 2) + 1, _
                                          (header.ContentBounds.Top + (header.ContentBounds.Bottom - header.ContentBounds.Top + checkAll.Size.Height) / 2) + 2)

            AddHandler checkAll.CheckedChanged, AddressOf checkAll_CheckedChanged
            Me.dgvEmailUser.Controls.Add(checkAll)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Tin Pham </name>
    '''     <date> 2015-08-07 </date>
    ''' </author>
    ''' <summary>
    ''' checkAll_CheckedChanged (check/uncheck all email)
    ''' </summary>
    Private Sub checkAll_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            For i As Integer = 0 To Me.dgvEmailUser.RowCount - 1
                Me.dgvEmailUser(0, i).Value = CType(sender, CheckBox).Checked
            Next

            Me.dgvEmailUser.EndEdit()

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Tin Vu </name>
    '''     <date> 2015-06-11 </date>
    ''' </author>
    ''' <summary>
    ''' ShowDataToEmailGrid()_ show emailto table by loading from hashtable from send email class
    ''' </summary>
    Protected Sub ShowDataToEmailGrid(ByVal hstEmailData As Hashtable)
        Try
            If hstEmailData IsNot Nothing Then
                'create datatable here
                dgvEmailUser.EnableHeadersVisualStyles = True

                m_dtEmailData = New DataTable("Emailto List Table")
                m_dtEmailData.Columns.Add(COL_EMAILNAME, GetType([String]))
                m_dtEmailData.Columns.Add(COL_ALARM, GetType([String]))
                m_dtEmailData.Columns.Add(COL_PRESSURE, GetType([String]))
                m_dtEmailData.Columns.Add(COL_SCHEDULER, GetType([String]))

                ''add new row to the rid
                AddRowEmailGrid()

                dgvEmailUser.AutoGenerateColumns = False
                Me.dgvEmailUser.DataSource = m_dtEmailData

                'add check box column
                AddCheckBoxColumn("", 60)

                'add Email column
                AddTextBoxColumn(COL_EMAILNAME)

                'add Alarm column
                AddCheckBoxColumn(COL_ALARM)

                'add scheduler column
                AddCheckBoxColumn(COL_SCHEDULER)

                'add pressure column
                AddCheckBoxColumn(COL_PRESSURE)

                'add button Edit
                AddButtonColumn(COL_EDITNAME)

                'add button Remove
                AddButtonColumn(COL_REMOVENAME)

                'add checkbox check/uncheck all
                AddCheckBoxOnHeader()

                'modifize size 
                dgvEmailUser.DefaultCellStyle.Font = New Font("Times new Roman", 12, FontStyle.Regular)
                dgvEmailUser.ColumnHeadersDefaultCellStyle.Font = New Font("Times new Roman", 14, FontStyle.Bold)
                dgvEmailUser.ColumnHeadersHeight = 30
                dgvEmailUser.RowTemplate.Height = 30
                dgvEmailUser.RowHeadersVisible = False

                'refresh to get effected
                Me.dgvEmailUser.Refresh()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Tin Vu </name>
    '''     <date> 2015-06-11 </date>
    ''' </author>
    ''' <summary>
    ''' btnApplyEmailSetting_Click Apply button click (change value data and save to file config)
    ''' </summary>
    Private Sub btnApplyEmailSetting_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApplyEmailSetting.Click
        Try
            'save email config to file config
            AVPLib.ContainerData.SaveConfigMail()
            Utils.LogUserEvent("Apply Email Alert Settings", "System Setup")
            Utils.ShowAVPMessageBox("Email Alert Saved Successfully", "Apply Email Alert", MessageBoxIcon.Information, MessageBoxButtons.OK)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Tin Vu </name>
    '''     <date> 2015-06-11 </date>
    ''' </author>
    ''' <summary>
    ''' dgvEmailUser_CellPainting repaint the buttom to remove and edit icon
    ''' </summary>
    Private Sub dgvEmailUser_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgvEmailUser.CellPainting
        Try
            If (e.ColumnIndex = COL_EDIT_POSITION Or e.ColumnIndex = COL_REMOVE_POSITION) AndAlso e.RowIndex >= 0 Then
                e.Paint(e.CellBounds, DataGridViewPaintParts.All)

                Dim img As Image = Global.AVP_Robot_Project.My.Resources.Resources.edit
                If (e.ColumnIndex = COL_REMOVE_POSITION) Then
                    img = Global.AVP_Robot_Project.My.Resources.Resources.removeimage
                End If

                e.Graphics.DrawImage(img, e.CellBounds.Left + 15, e.CellBounds.Top + 5, 20, 20)
                e.Handled = True
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Tin Vu </name>
    '''     <date> 2015-06-11 </date>
    ''' </author>
    ''' <summary>
    '''  ShowKeyPad use for all key pop up in emamil form
    ''' </summary>
    Private Sub ShowKeyPad(ByVal sender As Object, ByVal title As String, ByVal valueDefault As String, ByVal hidekey As Boolean)
        Try
            Dim textBox As TextBox = CType(sender, TextBox)
            Dim pad As New KeyPad
            Dim Value As String = valueDefault
            pad.Enable_DisableBtnAt = True
            If pad.DisplayKeypad(Value, title, hidekey) = Windows.Forms.DialogResult.OK Then
                If Not String.IsNullOrEmpty(Value) Then
                    textBox.Text = Value
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Tin Vu </name>
    '''     <date> 2015-06-11 </date>
    ''' </author>
    ''' <summary>
    '''  txtSMTPServer_Click pop up keyboard for user input SMTP server
    ''' </summary>
    Private Sub txtSMTPServer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSMTPServer.Click
        Try
            ShowKeyPad(sender, "Please Input SMTP Server", txtSMTPServer.Text, False)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Tin Vu </name>
    '''     <date> 2015-06-11 </date>
    ''' </author>
    ''' <summary>
    '''  txtUserName_Click pop up Keyboard for user input email address
    ''' </summary>
    Private Sub txtUserName_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUserName.Click
        Try
            ShowKeyPad(sender, "Please Input UserName Email Address", txtUserName.Text, False)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Tin Vu </name>
    '''     <date> 2015-06-11 </date>
    ''' </author>
    ''' <summary>
    '''  txtPassword_Click pop up keyboard with encrype true option to hide password
    ''' </summary>
    Private Sub txtPassword_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPassword.Click
        Try
            ShowKeyPad(sender, "Please Input Password Email Address", "", True)
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
    Private Sub ChangeMinMaxtxtPort(ByVal Source As String, ByVal sender As Object)
        Try
            Dim frm As New NumPad
            Dim Title As String = AVPLib.ContainerData.GetMessageText(Source)
            Dim value As String = CType(sender, TextBox).Text
            Dim txtPortLimit As String = Source & "."
            Dim oldValue As String = value
            Dim Min As Double = Double.Parse(AVPLib.ContainerData.GetRobotConfig(txtPortLimit + STRING_MIN).ToString())
            Dim Max As Double = Double.Parse(AVPLib.ContainerData.GetRobotConfig(txtPortLimit + STRING_MAX).ToString())

            Dim InputRes As MsgBoxResult = frm.GetUserInput(value, -1, -1, Min, Max, Title)

            If frm.IsMaxMinModified Then
                AVPLib.ContainerData.SetRobotConfig(txtPortLimit + STRING_MIN, frm.NewMin)
                AVPLib.ContainerData.SetRobotConfig(txtPortLimit + STRING_MAX, frm.NewMax)
            End If

            If InputRes = MsgBoxResult.Ok Then
                If Not String.IsNullOrEmpty(value) Then
                    CType(sender, TextBox).Text = value
                    txtPort.Text = value
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''     <name> Tin Vu </name>
    '''     <date> 2015-06-11 </date>
    ''' </author>
    ''' <summary>
    '''  txtPort_Click pop up numpad for user to input Port Server number
    ''' </summary>
    Private Sub txtPort_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPort.Click
        Try
            ChangeMinMaxtxtPort("SystemSetup." & txtPort.Name, sender)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Tin Vu </name>
    '''     <date> 2015-06-11 </date>
    ''' </author>
    ''' <summary>
    '''  btnAddNewEmail_Click to add emailto to the emailto list Hashtable
    ''' </summary>
    Private Sub btnAddNewEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNewEmail.Click
        Try
            Dim editmail As New TriggerEmail_Popup()
            Dim objEmail As New TriggerEmail
            objEmail.PressureInterval = 20 'default 20 minutes

            editmail.TrigerEmail = objEmail
            editmail.ShowDialog(AVPRobotMain)

            If Not String.IsNullOrEmpty(editmail.TrigerEmail.Name) Then
                If editmail.DialogResult = DialogResult.OK Then
                    Dim objNewEmail As TriggerEmail = editmail.TrigerEmail
                    AVPLib.SendEmail.Instance.AddTrigger(objNewEmail.Name, objNewEmail)

                    '''''''''''''''''''''''''''''''
                    AddRowEmailGrid()
                    ''''''''''''''''''''''''
                    Me.dgvEmailUser.DataSource = m_dtEmailData
                    Me.dgvEmailUser.Refresh()
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Tin Vu </name>
    '''     <date> 2015-06-11 </date>
    ''' </author>
    ''' <summary>
    '''  chkAutoSendEmail_Click enable and disable GUI and autoSend mail feature
    ''' </summary>
    Private Sub chkAutoSendEmail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAutoSendEmail.Click
        Try

            ' enable and disable Email Gui when Auto send mail checked
            If (chkAutoSendEmail.Checked) Then
                gbAccountInfomation.Enabled = True
                EnableDisableButton(True)
            Else
                gbAccountInfomation.Enabled = False
            End If

            AVPLib.SendEmail.Instance.ResetTimerPressure(chkAutoSendEmail.Checked)

            Utils.LogUserEvent(sender, "System Setup")
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Tin Vu </name>
    '''     <date> 2015-06-11 </date>
    ''' </author>
    ''' <summary>
    '''  chkAutoSendEmail_Click enable and disable GUI and autoSend mail feature
    ''' </summary>
    Private Sub btnTestingSetup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTestingSetup.Click
        Try
            IsStartTestingSetup = True
            EnableDisableButton(False)

            AVPLib.SendEmail.Instance.Send("", TriggerType.TESTING)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())

            IsStartTestingSetup = False
            EnableDisableButton(True)
        End Try
    End Sub

    ''' <author>
    '''     <name> Tin Pham </name>
    '''     <date> 2015-08-19 </date>
    ''' </author>
    ''' <summary>
    '''  Testing Setup button is enable/disable
    ''' </summary>
    Public Sub EnableDisableButton(ByVal isEnable As Boolean)
        Try
            btnTestingSetup.Enabled = isEnable And (Not IsStartTestingSetup) And AVPLib.ContainerData.Permission(PERMISSION_004)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Tin Vu </name>
    '''     <date> 2015-06-11 </date>
    ''' </author>
    ''' <summary>
    ''' </summary>
    Private Sub txtUserName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUserName.TextChanged, ErrorProvider.RightToLeftChanged
        Try
            If (AVPLib.SendEmail.Instance.ValidateEmail(txtUserName.Text.ToString)) Then
                AVPLib.SendEmail.Instance.UserName = txtUserName.Text.ToString
                ErrorProvider.SetError(txtUserName, "")
            Else
                ErrorProvider.SetError(txtUserName, "invalid email address")
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Tin Vu </name>
    '''     <date> 2015-06-11 </date>
    ''' </author>
    ''' <summary>
    ''' set SMTPSever to Email object
    ''' </summary>
    Private Sub txtSMTPServer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSMTPServer.TextChanged
        Try
            If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
                AVPLib.SendEmail.Instance.SMTPServer = txtSMTPServer.Text.ToString
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub txtPort_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPort.TextChanged
        Try
            If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
                AVPLib.SendEmail.Instance.PortID = txtPort.Text.ToString
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub txtPassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPassword.TextChanged
        Try
            If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
                AVPLib.SendEmail.Instance.Password = txtPassword.Text.ToString
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hoai Ly </name>
    '''     <date> 2015-06-12 </date>
    ''' </author>
    ''' <summary>
    ''' Save ModuleName Value
    ''' </summary>
    Private Sub txtModuleNamePM1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtModuleNamePM1.Click, _
                txtModuleNamePM2.Click, txtModuleNamePM3.Click
        Try
            Dim Source As String = "SystemSetup.ModuleName"
            Dim frm As New KeyPad
            Dim Title As String = AVPLib.ContainerData.GetMessageText(Source)
            Dim value As String = CType(sender, TextBox).Text
            Dim oldValue As String = value
            frm.IsRemoveSpaceStr = True
            frm.Enable_DisableBtnColon(True)
            frm.Refresh()

            If frm.DisplayKeypad(value, Title, False) = MsgBoxResult.Ok Then
                If value.Length > 40 Then
                    CType(sender, TextBox).Text = oldValue
                    Utils.ShowAVPMessageBox("Your input value must be less than 40 characters!", _
                                            "Module Name Input Error", _
                                             MessageBoxIcon.Exclamation, _
                                             MessageBoxButtons.OK)
                Else
                    StoreValueBeforeChanged(sender)
                    CType(sender, TextBox).Text = value
                    SaveModuleNameValue(sender, value)
                    LogUserEvent(sender)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error("txtModuleNamePM1_Click" & ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hoai Ly </name>
    '''     <date> 2015-06-12 </date>
    ''' </author>
    ''' <summary>
    ''' Save ModuleName Value
    ''' </summary>
    Public Sub SaveModuleNameValue(ByVal sender As System.Object, ByVal strValue As String)
        Try
            Dim bxmlDocChanged As Boolean = False
            Dim ModuleNode As Xml.XmlNode = Nothing
            Dim srcChamber As DataManagerment.Chamber = Nothing

            Dim strChamber As String = CType(sender, TextBox).AccessibleName
            If strChamber <> String.Empty Then
                srcChamber = DataManagerment.EquipmentManager.GetEquipment(strChamber)
                strChamber = String.Format((ConstEnum.XPATH_MODULE_NAME_PM), strChamber)
                ModuleNode = AVPLib.ContainerDAO.SystemConfigDoc.SelectSingleNode(strChamber)
            End If

            If ModuleNode IsNot Nothing AndAlso srcChamber IsNot Nothing Then
                ModuleNode.InnerText = strValue
                bxmlDocChanged = True
                srcChamber.GEMModuleName = strValue
            End If

            If bxmlDocChanged Then
                BinarySerialize.SaveTo_DatFileConfig(AVPLib.ContainerDAO.FPath_SystemConfig, AVPLib.ContainerDAO.SystemConfigDoc)
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error("SaveModuleNameValue" & ex.ToString())
        End Try
    End Sub

    Private Sub btnCustomEmailMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustomEmailMessage.Click
        Try

            Dim objCustomEmailMessage As CustomEmailMessage_Popup = New CustomEmailMessage_Popup

            objCustomEmailMessage.ListEmail.Clear()

            For i As Integer = 0 To Me.dgvEmailUser.RowCount - 1
                If Me.dgvEmailUser(0, i).Value Then
                    objCustomEmailMessage.ListEmail.Add(Me.dgvEmailUser(COL_EMAILNAME, i).Value)
                End If
            Next

            objCustomEmailMessage.ShowDialog(AVPRobotMain)

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-11-05</date>
    ''' </author>
    ''' <summary>
    ''' Store config button event.
    ''' </summary>
    Private Sub btnStoreConfigLLA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStoreConfigLLA.Click
        Try
            Dim msg As String = String.Format(StoredConfigData.MESSAGE_CONFIRM_STORE, STR_LLA_ELEVATOR)
            If Utils.ShowAVPMessageBox(msg, Me.tabElevatorSetting.Text, MessageBoxIcon.Question, AVPMessageBox.AVPMessageBoxButton.YesNo) = DialogResult.Cancel Then
                Return
            End If

            Dim configs As New StoredConfigData
            Dim objLLElevator As AVPLib.DataManagerment.LLElevator = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.LLAElevator.ToString())
            If objLLElevator IsNot Nothing Then
                configs.Version = objLLElevator.Version
            End If
            configs.Data.Add(LLConfigPanel.STR_NUMBER_OF_SLOTS, Me.txtNumberOfSlotsLLA.Text)
            configs.Data.Add(LLConfigPanel.STR_TRAVEL_LENGTH, Me.txtTravelLengthLLA.Text)
            configs.Data.Add(LLConfigPanel.STR_PITCH, Me.txtPitchLLA.Text)
            configs.Data.Add(LLConfigPanel.STR_BASE_OFFSET, Me.txtBaseOffsetLLA.Text)
            configs.Data.Add(LLConfigPanel.STR_FIND_BIAS, Me.txtFindBiasLLA.Text)

            If StoreConfig(Me.m_storedConfigLLA, configs) Then
                If Not SaveLLAConfig() Then
                    msg = String.Format(StoredConfigData.MESSAGE_STORE_UNSUCCESSFULLY, STR_LLA_ELEVATOR)
                    Utils.ShowAVPMessageBox(msg, "Error", MessageBoxIcon.Error, AVPMessageBox.AVPMessageBoxButton.OK)
                End If
            Else
                configs.Data.Clear()
            End If

            configs = Nothing

            If Me.m_storedConfigLLA.Count > 0 Then
                Me.btnLoadConfigLLA.Enabled = True
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-11-05</date>
    ''' </author>
    ''' <summary>
    ''' Recall config button event.
    ''' </summary>
    Private Sub btnLoadConfigLLA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadConfigLLA.Click
        Try
            Dim loadConfigPopup As New ViewSavedDataPopup(m_storedConfigLLA)
            loadConfigPopup.ConfigOf = ViewSavedDataPopup.ConfigDevice.LoadLock
            loadConfigPopup.ConfigName = STR_LLA_ELEVATOR
            If loadConfigPopup.ShowDialog(AVPRobotMain) = DialogResult.OK Then
                m_storedConfigLLA = loadConfigPopup.ViewData
                If loadConfigPopup.Result IsNot Nothing Then
                    Dim configs As Dictionary(Of String, String) = loadConfigPopup.Result.Data
                    Me.txtNumberOfSlotsLLA.Text = configs(LLConfigPanel.STR_NUMBER_OF_SLOTS)
                    Me.txtTravelLengthLLA.Text = configs(LLConfigPanel.STR_TRAVEL_LENGTH)
                    Me.txtPitchLLA.Text = configs(LLConfigPanel.STR_PITCH)
                    Me.txtBaseOffsetLLA.Text = configs(LLConfigPanel.STR_BASE_OFFSET)
                    Me.txtFindBiasLLA.Text = configs(LLConfigPanel.STR_FIND_BIAS)
                End If
            End If
            If loadConfigPopup.HasDataChanged Then
                SaveLLAConfig()
                If Me.m_storedConfigLLA.Count = 0 Then
                    Me.btnLoadConfigLLA.Enabled = False
                End If
            End If
            loadConfigPopup.Dispose()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-11-05</date>
    ''' </author>
    ''' <summary>
    ''' Store config button event.
    ''' </summary>
    Private Sub btnStoreConfigRobot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStoreConfigRobot.Click
        Try
            Dim msg As String = String.Format(StoredConfigData.MESSAGE_CONFIRM_STORE, "Robot")
            If Utils.ShowAVPMessageBox(msg, Me.tabElevatorSetting.Text, MessageBoxIcon.Question, AVPMessageBox.AVPMessageBoxButton.YesNo) = DialogResult.Cancel Then
                Return
            End If

            Dim configs As StoredConfigData
            Dim rRobot As AVPLib.DataManagerment.Robot = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Robot.ToString())
            If rRobot IsNot Nothing Then
                configs = New StoredConfigData()
                configs.Version = rRobot.Version
                configs.Data = New Dictionary(Of String, String)(rRobot.RobotConfigValues)
            Else
                configs = Me.RobotConfig.GetData()
            End If

            If StoreConfig(Me.m_storedConfigRobot, configs) Then
                If Not SaveRobotConfig() Then
                    msg = String.Format(StoredConfigData.MESSAGE_STORE_UNSUCCESSFULLY, "Robot")
                    Utils.ShowAVPMessageBox(msg, "Error", MessageBoxIcon.Error, AVPMessageBox.AVPMessageBoxButton.OK)
                End If
            Else
                configs.Data.Clear()
            End If

            configs = Nothing

            If Me.m_storedConfigRobot.Count > 0 Then
                Me.btnLoadConfigRobot.Enabled = True
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-11-05</date>
    ''' </author>
    ''' <summary>
    ''' Recall config button event.
    ''' </summary>
    Private Sub btnLoadConfigRobot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadConfigRobot.Click
        Try
            Dim loadConfigPopup As New ViewSavedDataPopup(Me.m_storedConfigRobot)
            loadConfigPopup.ConfigOf = ViewSavedDataPopup.ConfigDevice.Robot
            loadConfigPopup.ConfigName = AVPLib.ConstEnum.Equipments.Robot.ToString()
            loadConfigPopup.ShowDialog(AVPRobotMain)
            If loadConfigPopup.HasDataChanged Then
                Me.SaveRobotConfig()
                If Me.m_storedConfigRobot.Count = 0 Then
                    Me.btnLoadConfigRobot.Enabled = False
                End If
            End If
            loadConfigPopup.Dispose()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-11-05</date>
    ''' </author>
    ''' <summary>
    ''' Update robot config panel
    ''' </summary>
    Private Sub UpdateRobotConfigPanel()
        Try
            Dim rRobot As AVPLib.DataManagerment.Robot = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Robot.ToString())
            If rRobot IsNot Nothing Then
                Me.RobotConfig.SetData(rRobot.RobotConfigValues)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-11-05</date>
    ''' </author>
    ''' <summary>
    ''' Store config.
    ''' </summary>
    Private Function StoreConfig(ByRef data As List(Of StoredConfigData), ByVal configs As StoredConfigData) As Boolean
        Try
            configs.SavedOn = DateTime.Now.ToString()
            data.Add(configs)
            If data.Count > StoredConfigData.STORED_QUEUE_COUNT Then
                data(0).Data.Clear()
                data.RemoveAt(0)
            End If
            Return True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return False
    End Function

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-11-05</date>
    ''' </author>
    ''' <summary>
    ''' Save config.
    ''' </summary>
    Private Function SaveConfig(ByVal xPath As String, ByVal configName As String, ByVal data As List(Of StoredConfigData)) As Boolean
        Try
            Dim xmldoc As System.Xml.XmlDocument = AVPLib.ContainerDAO.SystemConfigDoc
            Dim root As System.Xml.XmlNode = xmldoc.SelectSingleNode(xPath)
            If root Is Nothing Then
                Return False
            End If

            ' Remove old node.
            For index As Integer = 0 To root.ChildNodes.Count - 1
                Dim node As Xml.XmlNode = root.ChildNodes(index)
                If node.Name = StoredConfigData.STORE_ITEMS_TAG_NAME Then
                    If node.Attributes("Name") IsNot Nothing Then
                        If node.Attributes("Name").Value = configName Then
                            root.RemoveChild(node)
                            Exit For
                        End If
                    End If
                End If
            Next

            ' Add new node.
            If data.Count > 0 Then
                root.InnerXml += StoredConfigData.ExportToXmlString(data, configName)
            End If

            BinarySerialize.SaveTo_DatFileConfig(AVPLib.ContainerDAO.FPath_SystemConfig, xmldoc)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return True
    End Function

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-11-05</date>
    ''' </author>
    ''' <summary>
    ''' Save config.
    ''' </summary>
    Private Function SaveLLAConfig() As Boolean
        Return SaveConfig(ConstEnum.XPATH_LL_ELEVATOR_CONFIG, AVPLib.ConstEnum.Equipments.LLAElevator.ToString(), Me.m_storedConfigLLA)
    End Function

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-11-05</date>
    ''' </author>
    ''' <summary>
    ''' Save config.
    ''' </summary>
    Private Function SaveRobotConfig() As Boolean
        Return SaveConfig(ConstEnum.XPATH_MODULE_ROBOT, AVPLib.ConstEnum.Equipments.Robot.ToString(), Me.m_storedConfigRobot)
    End Function

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-11-05</date>
    ''' </author>
    ''' <summary>
    ''' Load stored config.
    ''' </summary>
    Private Sub LoadStoredConfig()
        Try
            Dim xmldoc As System.Xml.XmlDocument = AVPLib.ContainerDAO.SystemConfigDoc
            Dim rootElevator As System.Xml.XmlNode = xmldoc.SelectSingleNode(ConstEnum.XPATH_LL_ELEVATOR_CONFIG)
            If rootElevator IsNot Nothing Then
                For Each node As Xml.XmlNode In rootElevator.ChildNodes
                    If node.Name = StoredConfigData.STORE_ITEMS_TAG_NAME Then
                        If node.Attributes("Name") IsNot Nothing Then
                            If node.Attributes("Name").Value = AVPLib.ConstEnum.Equipments.LLAElevator.ToString() Then
                                StoredConfigData.ImportFromXMLNode(node, Me.m_storedConfigLLA)
                                Exit For
                            End If
                        End If
                    End If
                Next
            End If

            Dim rootRobot As System.Xml.XmlNode = xmldoc.SelectSingleNode(ConstEnum.XPATH_MODULE_ROBOT)
            If rootRobot IsNot Nothing Then
                For Each node As Xml.XmlNode In rootRobot.ChildNodes
                    If node.Name = StoredConfigData.STORE_ITEMS_TAG_NAME Then
                        If node.Attributes("Name") IsNot Nothing Then
                            If node.Attributes("Name").Value = AVPLib.ConstEnum.Equipments.Robot.ToString() Then
                                StoredConfigData.ImportFromXMLNode(node, Me.m_storedConfigRobot)
                                Exit For
                            End If
                        End If
                    End If
                Next
            End If

            If Me.m_storedConfigLLA.Count = 0 Then
                Me.btnLoadConfigLLA.Enabled = False
            End If
            If Me.m_storedConfigRobot.Count = 0 Then
                Me.btnLoadConfigRobot.Enabled = False
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-11-06</date>
    ''' </author>
    ''' <summary>
    ''' Refresh robot configs.
    ''' </summary>
    Private Sub btnRequestRobotInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRequestRobotInfo.Click
        If ContainerForm.CassettesPanel.ISTM_ONLINE Then
            Utils.ShowAVPMessageBox("Can not action when TM is online.", Me.tabElevatorSetting.Text, MessageBoxIcon.Error, AVPMessageBox.AVPMessageBoxButton.OK)
            Return
        End If
        Me.btnRequestRobotInfo.Enabled = False
        Me.RobotConfig.ClearData()
        Me.m_stoStatusObject.RequestStatus(btnRequestRobotInfo.Name, String.Empty)
        Me.m_timerRequestData.Enabled = True
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-11-06</date>
    ''' </author>
    ''' <summary>
    ''' Refresh robot configs.
    ''' </summary>
    Private Sub txtRobotVersion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRobotVersion.TextChanged, txtApplyStatus.TextChanged
        If String.IsNullOrEmpty(txtRobotVersion.Text) Then
            Return
        End If
        Me.UpdateOnRequestFinished()
        Me.txtRobotVersion.Text = String.Empty
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-11-13</date>
    ''' </author>
    ''' <summary>
    ''' Refresh robot configs.
    ''' </summary>
    Private Sub UpdateOnRequestFinished()
        Me.btnRequestRobotInfo.Enabled = True
        Me.UpdateRobotConfigPanel()

        Me.m_timerRequestData.Enabled = False
        Me.m_requestTime = 0
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-11-13</date>
    ''' </author>
    ''' <summary>
    ''' Update GUI when request time out.
    ''' </summary>
    Private Sub TimerRequestData_Tick(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs)
        Try
            Me.m_requestTime += 1
            If Me.m_requestTime >= REQUEST_TIMEOUT Then
                Me.m_timerRequestData.Enabled = False
                Me.m_requestTime = 0
                If Me.InvokeRequired Then
                    Dim updateGui As New UpdateGUIDelegate(AddressOf UpdateOnRequestFinished)
                    Me.BeginInvoke(updateGui)
                Else
                    Me.UpdateOnRequestFinished()
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Kiet Tran </name>
    '''     <date> 2019-01-4 </date>
    ''' </author>
    ''' <summary>
    '''  txtInfoName_Click pop up keyboard for user input SMTP server
    ''' </summary>
    Private Sub txtInfoName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInfoName.Click
        Try
            ShowKeyPad(sender, "Please Input Info Name", txtInfoName.Text, False)
            AVPRobotMain.AVPInfoPanel.ToolID = txtInfoName.Text
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name>Tinh Le</name>
    '''     <date> 2020-11-10 </date>
    ''' </author>
    ''' <summary>
    '''  txtApplyStatus_TextChanged
    ''' </summary>
    Private Sub txtApplyStatus_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtApplyStatus.TextChanged
        Dim status As String = txtApplyStatus.Text.ToString()
        If Not String.IsNullOrEmpty(status) Then
            SetElevatorSettingEnable(False)
            btnApplyElevatorSetting.Enabled = True
            txtApplyStatus.Text = ""
            Utils.ShowAVPMessageBox("LL Elevator Settings saved successfully.", Me.tabElevatorSetting.Text, MessageBoxIcon.Information, MessageBoxButtons.OK)
        End If
    End Sub

    ''' <author>
    '''     <name>Tinh Le</name>
    '''     <date> 2020-11-10 </date>
    ''' </author>
    ''' <summary>
    '''  ConfigRobot_Click
    ''' </summary>
    Private Sub ConfigRobot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim UserResponse As MsgBoxResult = MsgBoxResult.Cancel
        Try
            Dim needToCheckMaxMin As Boolean = True
            Dim Source As String = String.Empty
            Dim Min As Single = 0
            Dim Max As Single = 0

            Dim f As New NumPad()
            Dim Value As String = String.Empty
            If TypeOf (sender) Is TextBox Then
                Value = CType(sender, TextBox).Text
                Source = "SystemSetup.RobotConfig."
                Dim minObj As Object = AVPLib.ContainerData.GetRobotConfig(Source + STRING_MIN)
                Dim maxObj As Object = AVPLib.ContainerData.GetRobotConfig(Source + STRING_MAX)
                Min = minObj
                Max = maxObj
            Else
                Exit Sub
            End If

            UserResponse = f.GetUserInput(Value, -1, -1, Min, Max, "Please input the number", 0, _
                                needToCheckMaxMin)
            If UserResponse = MsgBoxResult.Ok Then
                If TypeOf (sender) Is TextBox Then
                    StoreValueBeforeChanged(CType(sender, TextBox))
                    CType(sender, TextBox).Text = Value
                End If
            End If

            If f.IsMaxMinModified Then
                AVPLib.ContainerData.SetRobotConfig(Source + STRING_MIN, f.NewMin)
                AVPLib.ContainerData.SetRobotConfig(Source + STRING_MAX, f.NewMax)
                Dim logName As String = Utils.GetLogName(sender)

                If Min <> f.NewMin Then
                    LogUserEvent(String.Format("Changed MIN of {0} from {1} to {2}", logName, Min, f.NewMin))
                    Utils.CheckChangeValue("Changed Min of " & logName, Min, f.NewMin)
                End If

                If Max <> f.NewMax Then
                    LogUserEvent(String.Format("Changed MAX of {0} from {1} to {2}", logName, Max, f.NewMax))
                    Utils.CheckChangeValue("Changed Max of " & logName, Max, f.NewMax)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub btnCancelElevatorSetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelElevatorSetting.Click
        Try
            SetElevatorSettingEnable(False)
            Dim strOldValue As String = String.Empty
            Dim strNewValue As String = String.Empty
            With m_stoStatusObject
                'LLA visible
                'If AVPLib.RobotConfigurationValues.LOADLOCKA_VISIBLE Then
                'Number Of Slots LLA
                strOldValue = AVPLib.ContainerData.GetLLElevatorConfig(NUMBER_OF_SLOT)
                strNewValue = txtNumberOfSlotsLLA.Text.Trim()
                If (strOldValue <> strNewValue) Then
                    txtNumberOfSlotsLLA.Text = strOldValue
                End If

                'Travel Length LLA
                strOldValue = AVPLib.ContainerData.GetLLElevatorConfig(TRAVEL_LENGTH)
                strNewValue = txtTravelLengthLLA.Text.Trim()
                If (strOldValue <> strNewValue) Then
                    txtTravelLengthLLA.Text = strOldValue
                End If

                'Pitch LLA
                strOldValue = AVPLib.ContainerData.GetLLElevatorConfig(PITCH)
                strNewValue = txtPitchLLA.Text.Trim()
                If (strOldValue <> strNewValue) Then
                    txtPitchLLA.Text = strOldValue
                End If

                'Base Offset LLA
                strOldValue = AVPLib.ContainerData.GetLLElevatorConfig(BASE_OFFSET)
                strNewValue = txtBaseOffsetLLA.Text.Trim()
                If (strOldValue <> strNewValue) Then
                    txtBaseOffsetLLA.Text = strOldValue
                End If

                'Find Bias LLA
                strOldValue = AVPLib.ContainerData.GetLLElevatorConfig(FIND_BIAS)
                strNewValue = txtFindBiasLLA.Text.Trim()
                If (strOldValue <> strNewValue) Then
                    txtFindBiasLLA.Text = strOldValue
                End If
                'End If
            End With
            'reset data robot
            Me.m_stoStatusObject.RequestStatus("RequestInfo", String.Empty)
        Catch ex As Exception

        End Try
    End Sub
End Class

Public Class TargetPowerSupplyCoronaConfig
    Private m_strT1Usage As String
    Private m_strT2Usage As String
    Private m_strT3Usage As String
    Private m_strT4Usage As String
    Private m_strT5Usage As String
    Private m_strT1Limit As String
    Private m_strT2Limit As String
    Private m_strT3Limit As String
    Private m_strT4Limit As String
    Private m_strT5Limit As String
    Private m_strT1Warning As String
    Private m_strT2Warning As String
    Private m_strT3Warning As String
    Private m_strT4Warning As String
    Private m_strT5Warning As String
    Private m_strT1Material As String
    Private m_strT2Material As String
    Private m_strT3Material As String
    Private m_strT4Material As String
    Private m_strT5Material As String
    Private m_strT1ShieldsQuartz As String
    Private m_strT2ShieldsQuartz As String
    Private m_strT3ShieldsQuartz As String
    Private m_strT4ShieldsQuartz As String
    Private m_strT5ShieldsQuartz As String
    Private m_strT1Max As String
    Private m_strT2Max As String
    Private m_strT3Max As String
    Private m_strT4Max As String
    Private m_strT5Max As String

    Public Property T1_Usage() As String
        Get
            Return m_strT1Usage
        End Get
        Set(ByVal value As String)
            m_strT1Usage = value
        End Set
    End Property
    Public Property T2_Usage() As String
        Get
            Return m_strT2Usage
        End Get
        Set(ByVal value As String)
            m_strT2Usage = value
        End Set
    End Property
    Public Property T3_Usage() As String
        Get
            Return m_strT3Usage
        End Get
        Set(ByVal value As String)
            m_strT3Usage = value
        End Set
    End Property
    Public Property T4_Usage() As String
        Get
            Return m_strT4Usage
        End Get
        Set(ByVal value As String)
            m_strT4Usage = value
        End Set
    End Property
    Public Property T5_Usage() As String
        Get
            Return m_strT5Usage
        End Get
        Set(ByVal value As String)
            m_strT5Usage = value
        End Set
    End Property

    Public Property T1_Limit() As String
        Get
            Return m_strT1Limit
        End Get
        Set(ByVal value As String)
            m_strT1Limit = value
        End Set
    End Property
    Public Property T2_Limit() As String
        Get
            Return m_strT2Limit
        End Get
        Set(ByVal value As String)
            m_strT2Limit = value
        End Set
    End Property
    Public Property T3_Limit() As String
        Get
            Return m_strT3Limit
        End Get
        Set(ByVal value As String)
            m_strT3Limit = value
        End Set
    End Property
    Public Property T4_Limit() As String
        Get
            Return m_strT4Limit
        End Get
        Set(ByVal value As String)
            m_strT4Limit = value
        End Set
    End Property
    Public Property T5_Limit() As String
        Get
            Return m_strT5Limit
        End Get
        Set(ByVal value As String)
            m_strT5Limit = value
        End Set
    End Property

    Public Property T1_Warning() As String
        Get
            Return m_strT1Warning
        End Get
        Set(ByVal value As String)
            m_strT1Warning = value
        End Set
    End Property
    Public Property T2_Warning() As String
        Get
            Return m_strT2Warning
        End Get
        Set(ByVal value As String)
            m_strT2Warning = value
        End Set
    End Property
    Public Property T3_Warning() As String
        Get
            Return m_strT3Warning
        End Get
        Set(ByVal value As String)
            m_strT3Warning = value
        End Set
    End Property
    Public Property T4_Warning() As String
        Get
            Return m_strT4Warning
        End Get
        Set(ByVal value As String)
            m_strT4Warning = value
        End Set
    End Property
    Public Property T5_Warning() As String
        Get
            Return m_strT5Warning
        End Get
        Set(ByVal value As String)
            m_strT5Warning = value
        End Set
    End Property

    Public Property T1_Material() As String
        Get
            Return m_strT1Material
        End Get
        Set(ByVal value As String)
            m_strT1Material = value
        End Set
    End Property
    Public Property T2_Material() As String
        Get
            Return m_strT2Material
        End Get
        Set(ByVal value As String)
            m_strT2Material = value
        End Set
    End Property
    Public Property T3_Material() As String
        Get
            Return m_strT3Material
        End Get
        Set(ByVal value As String)
            m_strT3Material = value
        End Set
    End Property
    Public Property T4_Material() As String
        Get
            Return m_strT4Material
        End Get
        Set(ByVal value As String)
            m_strT4Material = value
        End Set
    End Property
    Public Property T5_Material() As String
        Get
            Return m_strT5Material
        End Get
        Set(ByVal value As String)
            m_strT5Material = value
        End Set
    End Property

    Public Property T1_ShieldsQuartz() As String
        Get
            Return m_strT1ShieldsQuartz
        End Get
        Set(ByVal value As String)
            m_strT1ShieldsQuartz = value
        End Set
    End Property
    Public Property T2_ShieldsQuartz() As String
        Get
            Return m_strT2ShieldsQuartz
        End Get
        Set(ByVal value As String)
            m_strT2ShieldsQuartz = value
        End Set
    End Property
    Public Property T3_ShieldsQuartz() As String
        Get
            Return m_strT3ShieldsQuartz
        End Get
        Set(ByVal value As String)
            m_strT3ShieldsQuartz = value
        End Set
    End Property
    Public Property T4_ShieldsQuartz() As String
        Get
            Return m_strT4ShieldsQuartz
        End Get
        Set(ByVal value As String)
            m_strT4ShieldsQuartz = value
        End Set
    End Property
    Public Property T5_ShieldsQuartz() As String
        Get
            Return m_strT5ShieldsQuartz
        End Get
        Set(ByVal value As String)
            m_strT5ShieldsQuartz = value
        End Set
    End Property

    Public Property T1_Max() As String
        Get
            Return m_strT1Max
        End Get
        Set(ByVal value As String)
            m_strT1Max = value
        End Set
    End Property
    Public Property T2_Max() As String
        Get
            Return m_strT2Max
        End Get
        Set(ByVal value As String)
            m_strT2Max = value
        End Set
    End Property
    Public Property T3_Max() As String
        Get
            Return m_strT3Max
        End Get
        Set(ByVal value As String)
            m_strT3Max = value
        End Set
    End Property
    Public Property T4_Max() As String
        Get
            Return m_strT4Max
        End Get
        Set(ByVal value As String)
            m_strT4Max = value
        End Set
    End Property
    Public Property T5_Max() As String
        Get
            Return m_strT5Max
        End Get
        Set(ByVal value As String)
            m_strT5Max = value
        End Set
    End Property
End Class
