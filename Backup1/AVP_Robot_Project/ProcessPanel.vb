Imports AVP_Robot_Project.ConstantAndEnum
Imports AVP_Robot_Project.AVPRobotMain
Imports AVPLib.ConstEnum
Imports AVPLib
Imports AVPControls.AVPDataLib
Imports AVPControls

Public Class ProcessPanel

#Region "Class Constants & Variables"
    Private m_Robot As Robot
    Private m_blnIsLLAProcessing As Boolean
    Private Shared m_intClickedPosition As Integer
    Private Shared m_intClickedSlot As Integer
    Private m_PanelStyle As CX_Style = CX_Style.CX5
    Private m_blnIsButtonClearAllWaferClicked As Boolean = False
    Private frmPM1_PopUpStatusPanel As Object = Nothing
    Private frmPM2_PopUpStatusPanel As Object = Nothing
    Private frmPM3_PopUpStatusPanel As Object = Nothing
    Private m_blShowPopupNoWafer As Boolean = True
#End Region
    Public ReadOnly Property PM1_PopUpStatusPanel() As Object
        Get
            Return frmPM1_PopUpStatusPanel
        End Get
    End Property

    Public ReadOnly Property PM2_PopUpStatusPanel() As Object
        Get
            Return frmPM2_PopUpStatusPanel
        End Get
    End Property

    Public ReadOnly Property PM3_PopUpStatusPanel() As Object
        Get
            Return frmPM3_PopUpStatusPanel
        End Get
    End Property

    ''' <author>
    '''    	<name> Khiet Tran </name>
    '''    	<date> 20098-10-29</date>
    ''' </author>
    ''' <summary>
    ''' Get ClickedPosition
    ''' </summary>
    ''' <remarks></remarks>
    Public Property PanelStyle() As CX_Style
        Get
            Return m_PanelStyle
        End Get
        Set(ByVal value As CX_Style)
            m_PanelStyle = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Khiet Tran </name>
    '''    	<date> 20098-10-29</date>
    ''' </author>
    ''' <summary>
    ''' Get ClickedPosition
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Property ClickedPosition() As Integer
        Get
            Return m_intClickedPosition
        End Get
        Set(ByVal value As Integer)
            m_intClickedPosition = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Khiet Tran </name>
    '''    	<date> 20098-10-29</date>
    ''' </author>
    ''' <summary>
    ''' Get ClickedPosition
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Property ClickedSlot() As Integer
        Get
            Return m_intClickedSlot
        End Get
        Set(ByVal value As Integer)
            m_intClickedSlot = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-08-29</date>
    ''' </author>
    ''' <summary>
    ''' Get/Set IsButtonClearAllWaferClicked
    ''' </summary>
    ''' <remarks></remarks>
    Public Property IsButtonClearAllWaferClicked() As Boolean
        Get
            Return m_blnIsButtonClearAllWaferClicked
        End Get
        Set(ByVal value As Boolean)
            m_blnIsButtonClearAllWaferClicked = value
        End Set
    End Property


#Region "Constructors & Dispose"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-05</date>
    ''' </author>
    ''' <summary>
    ''' Initiate process panel
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Try
            m_Robot = New Robot("ProcessRobot")

            'ticHandOriginal.Location = New System.Drawing.Point(450, 200) '(350, 120) '524, 334
            ''
            m_Robot.Hands = RobotHand
            m_blnIsLLAProcessing = False

            MesaValvePM1.CX_Supported = PMControl.Support_CX.Support_CX4
            MesaValvePM1.DockPosition = SlitValve.SlitValvePositions.PM1

            MesaValvePM2.CX_Supported = PMControl.Support_CX.Support_CX4
            MesaValvePM2.DockPosition = SlitValve.SlitValvePositions.PM2

            MesaValvePM3.CX_Supported = PMControl.Support_CX.Support_CX4
            MesaValvePM3.DockPosition = SlitValve.SlitValvePositions.PM3
            'chamber 1
            If AVPLib.RobotConfigurationValues.CHAMBER1_VISIBLE Then
                ''IBE
                If AVPLib.RobotConfigurationValues.CHAMBER1_TYPE = SystemModule.ModuleType.IBE Then
                    frmPM1_PopUpStatusPanel = New PMProcessStatusPopUpPanel
                    Dim Chamber1Config As SystemModule = AVPLib.ContainerData.GetRobotConfig("Chamber1")
                    ''PVD
                ElseIf AVPLib.RobotConfigurationValues.CHAMBER1_TYPE = SystemModule.ModuleType.PVD Then
                    frmPM1_PopUpStatusPanel = New PVDProcessStatusPopUpPanel
                    Dim Chamber1Config As SystemModule = AVPLib.ContainerData.GetRobotConfig("Chamber1")
                    CType(frmPM1_PopUpStatusPanel, PVDProcessStatusPopUpPanel).IsTarget_DC(Chamber1Config.DCTargetPowerVisible)
                    'CType(frmPM1_PopUpStatusPanel, PVDProcessStatusPopUpPanel).IsTarget_DC(Chamber1Config.DCTargetPowerVisible, Chamber1Config.BiasPowerVisible, IIf(Chamber1Config.DCTargetPowerVisible Or Chamber1Config.RFTargetPowerVisible, False, True))
                    'CType(frmPM1_PopUpStatusPanel, PVDProcessStatusPopUpPanel).IsClampInstall = Chamber1Config.ClampInstalled()
                    ''PVD4
                ElseIf AVPLib.RobotConfigurationValues.CHAMBER1_TYPE = SystemModule.ModuleType.PVD4 Then
                    frmPM1_PopUpStatusPanel = New PVD4ProcessStatusPopUpPanel
                    Dim Chamber1Config As SystemModule = AVPLib.ContainerData.GetRobotConfig("Chamber1")
                    If Chamber1Config IsNot Nothing Then
                        With CType(frmPM1_PopUpStatusPanel, PVD4ProcessStatusPopUpPanel)
                            .IsTarget_DC = Chamber1Config.DCTargetPowerVisible()
                        End With
                    End If
                    CType(frmPM1_PopUpStatusPanel, PVD4ProcessStatusPopUpPanel).TargetInstall(Chamber1Config.TargetVisible, Chamber1Config.Target2Visible, Chamber1Config.Target3Visible, Chamber1Config.Target4Visible)
                    ''PVD5T
                ElseIf AVPLib.RobotConfigurationValues.CHAMBER1_TYPE = SystemModule.ModuleType.PVD5T Then
                    frmPM1_PopUpStatusPanel = New PVD5TProcessStatusPopUpPanel
                    Dim Chamber1Config As SystemModule = AVPLib.ContainerData.GetRobotConfig("Chamber1")
                    If Chamber1Config IsNot Nothing Then
                        With CType(frmPM1_PopUpStatusPanel, PVD5TProcessStatusPopUpPanel)
                            .IsTarget_DC = Chamber1Config.DCTargetPowerVisible()
                        End With
                    End If
                    CType(frmPM1_PopUpStatusPanel, PVD5TProcessStatusPopUpPanel).TargetInstall(Chamber1Config.TargetVisible, Chamber1Config.Target2Visible, Chamber1Config.Target3Visible, Chamber1Config.Target4Visible, Chamber1Config.Target5Visible)

                End If
                frmPM1_PopUpStatusPanel.Name = "Chamber1PopUpStatusPanel"
                frmPM1_PopUpStatusPanel.PopUpTitle = ConstEnum.Equipments.Chamber1.ToString()
                ChangeLabelPBN_Filement(ConstEnum.Equipments.Chamber1.ToString(), frmPM1_PopUpStatusPanel)
            End If

            'chamber 2
            If AVPLib.RobotConfigurationValues.CHAMBER2_VISIBLE Then
                If AVPLib.RobotConfigurationValues.CHAMBER2_TYPE = SystemModule.ModuleType.IBE Then
                    frmPM2_PopUpStatusPanel = New PMProcessStatusPopUpPanel
                    Dim Chamber2Config As SystemModule = AVPLib.ContainerData.GetRobotConfig("Chamber2")
                ElseIf AVPLib.RobotConfigurationValues.CHAMBER2_TYPE = SystemModule.ModuleType.PVD Then
                    frmPM2_PopUpStatusPanel = New PVDProcessStatusPopUpPanel
                    Dim Chamber2Config As SystemModule = AVPLib.ContainerData.GetRobotConfig("Chamber2")
                    CType(frmPM2_PopUpStatusPanel, PVDProcessStatusPopUpPanel).IsTarget_DC(Chamber2Config.DCTargetPowerVisible)
                    'CType(frmPM1_PopUpStatusPanel, PVDProcessStatusPopUpPanel).IsTarget_DC(Chamber1Config.DCTargetPowerVisible, Chamber1Config.BiasPowerVisible, IIf(Chamber1Config.DCTargetPowerVisible Or Chamber1Config.RFTargetPowerVisible, False, True))
                    'CType(frmPM1_PopUpStatusPanel, PVDProcessStatusPopUpPanel).IsClampInstall = Chamber1Config.ClampInstalled()
                ElseIf AVPLib.RobotConfigurationValues.CHAMBER2_TYPE = SystemModule.ModuleType.PVD4 Then
                    frmPM2_PopUpStatusPanel = New PVD4ProcessStatusPopUpPanel
                    Dim Chamber2Config As SystemModule = AVPLib.ContainerData.GetRobotConfig("Chamber2")
                    If Chamber2Config IsNot Nothing Then
                        With CType(frmPM2_PopUpStatusPanel, PVD4ProcessStatusPopUpPanel)
                            .IsTarget_DC = Chamber2Config.DCTargetPowerVisible()
                        End With
                    End If
                    CType(frmPM2_PopUpStatusPanel, PVD4ProcessStatusPopUpPanel).TargetInstall(Chamber2Config.TargetVisible, Chamber2Config.Target2Visible, Chamber2Config.Target3Visible, Chamber2Config.Target4Visible)
                    ''PVD5T
                ElseIf AVPLib.RobotConfigurationValues.CHAMBER2_TYPE = SystemModule.ModuleType.PVD5T Then
                    frmPM2_PopUpStatusPanel = New PVD5TProcessStatusPopUpPanel
                    Dim Chamber2Config As SystemModule = AVPLib.ContainerData.GetRobotConfig("Chamber2")
                    If Chamber2Config IsNot Nothing Then
                        With CType(frmPM2_PopUpStatusPanel, PVD5TProcessStatusPopUpPanel)
                            .IsTarget_DC = Chamber2Config.DCTargetPowerVisible()
                        End With
                    End If
                    CType(frmPM2_PopUpStatusPanel, PVD5TProcessStatusPopUpPanel).TargetInstall(Chamber2Config.TargetVisible, Chamber2Config.Target2Visible, Chamber2Config.Target3Visible, Chamber2Config.Target4Visible, Chamber2Config.Target5Visible)

                End If
                frmPM2_PopUpStatusPanel.Name = "Chamber2PopUpStatusPanel"
                frmPM2_PopUpStatusPanel.PopUpTitle = ConstEnum.Equipments.Chamber2.ToString()
                ChangeLabelPBN_Filement(ConstEnum.Equipments.Chamber2.ToString(), frmPM2_PopUpStatusPanel)
            End If
            'chamber 3
            If AVPLib.RobotConfigurationValues.CHAMBER3_VISIBLE Then
                If AVPLib.RobotConfigurationValues.CHAMBER3_TYPE = SystemModule.ModuleType.IBE Then
                    frmPM3_PopUpStatusPanel = New PMProcessStatusPopUpPanel
                    Dim Chamber3Config As SystemModule = AVPLib.ContainerData.GetRobotConfig("Chamber3")
                ElseIf AVPLib.RobotConfigurationValues.CHAMBER3_TYPE = SystemModule.ModuleType.PVD Then
                    frmPM3_PopUpStatusPanel = New PVDProcessStatusPopUpPanel
                    Dim Chamber3Config As SystemModule = AVPLib.ContainerData.GetRobotConfig("Chamber3")
                    CType(frmPM3_PopUpStatusPanel, PVDProcessStatusPopUpPanel).IsTarget_DC(Chamber3Config.DCTargetPowerVisible)
                    'CType(frmPM1_PopUpStatusPanel, PVDProcessStatusPopUpPanel).IsTarget_DC(Chamber1Config.DCTargetPowerVisible, Chamber1Config.BiasPowerVisible, IIf(Chamber1Config.DCTargetPowerVisible Or Chamber1Config.RFTargetPowerVisible, False, True))
                    'CType(frmPM1_PopUpStatusPanel, PVDProcessStatusPopUpPanel).IsClampInstall = Chamber1Config.ClampInstalled()
                ElseIf AVPLib.RobotConfigurationValues.CHAMBER3_TYPE = SystemModule.ModuleType.PVD4 Then
                    frmPM3_PopUpStatusPanel = New PVD4ProcessStatusPopUpPanel
                    Dim Chamber3Config As SystemModule = AVPLib.ContainerData.GetRobotConfig("Chamber3")
                    If Chamber3Config IsNot Nothing Then
                        With CType(frmPM3_PopUpStatusPanel, PVD4ProcessStatusPopUpPanel)
                            .IsTarget_DC = Chamber3Config.DCTargetPowerVisible()
                        End With
                    End If
                    CType(frmPM3_PopUpStatusPanel, PVD4ProcessStatusPopUpPanel).TargetInstall(Chamber3Config.TargetVisible, Chamber3Config.Target2Visible, Chamber3Config.Target3Visible, Chamber3Config.Target4Visible)
                    ''PVD5T
                ElseIf AVPLib.RobotConfigurationValues.CHAMBER3_TYPE = SystemModule.ModuleType.PVD5T Then
                    frmPM3_PopUpStatusPanel = New PVD5TProcessStatusPopUpPanel
                    Dim Chamber3Config As SystemModule = AVPLib.ContainerData.GetRobotConfig("Chamber3")
                    If Chamber3Config IsNot Nothing Then
                        With CType(frmPM3_PopUpStatusPanel, PVD5TProcessStatusPopUpPanel)
                            .IsTarget_DC = Chamber3Config.DCTargetPowerVisible()
                        End With
                    End If
                    CType(frmPM3_PopUpStatusPanel, PVD5TProcessStatusPopUpPanel).TargetInstall(Chamber3Config.TargetVisible, Chamber3Config.Target2Visible, Chamber3Config.Target3Visible, Chamber3Config.Target4Visible, Chamber3Config.Target5Visible)

                End If
                frmPM3_PopUpStatusPanel.Name = "Chamber3PopUpStatusPanel"
                frmPM3_PopUpStatusPanel.PopUpTitle = ConstEnum.Equipments.Chamber3.ToString()
                ChangeLabelPBN_Filement(ConstEnum.Equipments.Chamber3.ToString(), frmPM3_PopUpStatusPanel)
            End If

            Me.SetStyle(ControlStyles.AllPaintingInWmPaint Or
            ControlStyles.OptimizedDoubleBuffer Or
            ControlStyles.DoubleBuffer, True)

            If Not AVPLib.ContainerDAO.EnableRunNo Then
                runNoControl.Visible = False
                wccWaferCount.Location = New Point(581, 611)
                wccWaferCount.Visible = True
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub
#End Region

    Private Sub ChangeLabelPBN_Filement(ByVal chanberName As String, ByRef popupPanel As Object)
        Dim chamber As AVPLib.SystemModule = AVPLib.ContainerData.GetRobotConfig(chanberName)
        If (chamber IsNot Nothing AndAlso chamber.Filament_Installed) Then
            CType(popupPanel, PMProcessStatusPopUpPanel).lblPBNDischarge.Text = "PBN Fila.(A)"
            'popupPanel.lblPBNDischarge.Text = "PBN Fila.(A)"
        End If
    End Sub

#Region "Public Methods"
    '''This function is update Shutter for IBE
    Private Sub InitializeShutterForPM_CX5()
        If RobotConfigurationValues.CHAMBER1_VISIBLE Then
            With CX_PM1
                .CX_Supported = PMControl.Support_CX.Support_CX5
                .PM_IN_SCREEN = PMControl.Support_Screen.ProcessScreen
                If .PM_Type = TypeOfAVPChamber.PVD Then
                    .bicShutter.Visible = False
                End If
            End With
        End If
        If RobotConfigurationValues.CHAMBER2_VISIBLE Then
            With CX_PM2
                .CX_Supported = PMControl.Support_CX.Support_CX5
                .PM_IN_SCREEN = PMControl.Support_Screen.ProcessScreen
                If .PM_Type = TypeOfAVPChamber.PVD Then
                    .bicShutter.Visible = False
                End If
            End With
        End If
        If RobotConfigurationValues.CHAMBER3_VISIBLE Then
            With CX_PM3
                .CX_Supported = PMControl.Support_CX.Support_CX5
                .PM_IN_SCREEN = PMControl.Support_Screen.ProcessScreen
                If .PM_Type = TypeOfAVPChamber.PVD Then
                    .bicShutter.Visible = False
                End If
            End With
        End If
    End Sub
    Public Sub InitializeComponent_CX5()
        lblPM1MotionInitialize.Visible = False
        lblPM2MotionInitialize.Visible = False
        lblPM3MotionInitialize.Visible = False
        ''robot body config
        LLALeg.LoadLockType = LoadLockLeg.Load_Lock_Type.Type_2
        'ticHandOriginal.CX_Supported = RobotHand.CX_Style.CX4

        Robot_Body.AVPStyle = AVPStyles.CX5
        Robot_Body.InScreen = AVPScreens.ProcessScreen
        Robot_Body.Location = New Point(487, 225)
        Robot_Body.SensorsInstalled = AVPLib.RobotConfigurationValues.ROBOT_SENSOR_INSTALLED

        'Config aligner at LLA
        If AVPLib.RobotConfigurationValues.ALINER_VISIBLE Then
            If AVPLib.RobotConfigurationValues.ALINER_VISIBLE Then
                If RobotConfigurationValues.ALIGNER_AT_STATION = 1 Then
                    awcAligner.Location = New Point(531, 407)
                    TransparentImageAligner.Location = New Point(534, 409)
                End If
            End If
        Else
            awcAligner.Visible = False
            Robot_Body.AlignerAtStation = RobotArmStations.Original
        End If

        ''MesaValves config

        MesaValveLLA.CX_Supported = PMControl.Support_CX.Support_CX5
        MesaValveLLA.DockPosition = SlitValve.SlitValvePositions.LLA
        MesaValveLLA.Location = New Point(488, 423)
        MesaValveLLA.Size = New Size(91, 63)

        MesaValvePM1.CX_Supported = PMControl.Support_CX.Support_CX5
        MesaValvePM1.DockPosition = SlitValve.SlitValvePositions.PM1
        MesaValvePM1.Location = New Point(505, 270)
        MesaValvePM1.Size = New Size(16, 110)

        MesaValvePM2.CX_Supported = PMControl.Support_CX.Support_CX5
        MesaValvePM2.DockPosition = SlitValve.SlitValvePositions.PM2
        MesaValvePM2.Location = New Point(560, 216)
        MesaValvePM2.Size = New Size(110, 16)

        MesaValvePM3.CX_Supported = PMControl.Support_CX.Support_CX5
        MesaValvePM3.DockPosition = SlitValve.SlitValvePositions.PM3
        MesaValvePM3.Location = New Point(706, 270)
        MesaValvePM3.Size = New Size(16, 110)

        '===========
        'load lock A config
        LLALeg.Location = New Point(452, 374)
        LLALeg.QuestionMark_Visible = False
        LLALeg.Leg_In_Screen = PMControl.Support_Screen.ProcessScreen
        LLALeg.LegStatus = BinaryStatusControl.DisplayStatus.Off
        LLALeg.EQ_LoadLock = Equipments.LoadLockA

        '===
        'PM1 config
        If RobotConfigurationValues.CHAMBER1_VISIBLE Then
            CX_PM1.CX_Supported = PMControl.Support_CX.Support_CX5
            CX_PM1.PM_IN_SCREEN = PMControl.Support_Screen.ProcessScreen
            CX_PM1.ShowWafer_Border_ToEdit = False
            CX_PM1.Show_Disconnected = False
            CX_PM1.DockPosition = PMControl.ChamberDockPositions.PM1

            If RobotConfigurationValues.CHAMBER1_TYPE = SystemModule.ModuleType.IBE Then
                CX_PM1.PM_Type = TypeOfAVPChamber.IBE
                CX_PM1.Location = New Point(340, 271)
                lblPM1MotionInitialize.Text = STR_MOTION_INITIALIZING
                lblPM1MotionInitialize.Location = New Point(CX_PM1.Left, CX_PM1.Top + CX_PM1.Height + 5)
            ElseIf RobotConfigurationValues.CHAMBER1_TYPE = SystemModule.ModuleType.PVD Then
                CX_PM1.PM_Type = TypeOfAVPChamber.PVD
                CX_PM1.Location = New Point(336, 270)
            End If
        End If

        'PM2 config
        If RobotConfigurationValues.CHAMBER2_VISIBLE Then
            CX_PM2.CX_Supported = PMControl.Support_CX.Support_CX5
            CX_PM2.PM_IN_SCREEN = PMControl.Support_Screen.ProcessScreen
            CX_PM2.ShowWafer_Border_ToEdit = False
            CX_PM2.Show_Disconnected = False
            CX_PM2.DockPosition = PMControl.ChamberDockPositions.PM2

            If RobotConfigurationValues.CHAMBER2_TYPE = SystemModule.ModuleType.IBE Then
                CX_PM2.PM_Type = TypeOfAVPChamber.IBE
                CX_PM2.Location = New Point(561, 52)
                lblPM2MotionInitialize.Text = STR_MOTION_INITIALIZING
                lblPM2MotionInitialize.Location = New Point(CX_PM2.Left + CX_PM2.Width + 5, CX_PM2.Top + CX_PM2.Height / 3)
            ElseIf RobotConfigurationValues.CHAMBER2_TYPE = SystemModule.ModuleType.PVD Then
                CX_PM2.PM_Type = TypeOfAVPChamber.PVD
                CX_PM2.Location = New Point(560, 64)
            End If
        End If

        'PM3
        If RobotConfigurationValues.CHAMBER3_VISIBLE Then
            CX_PM3.CX_Supported = PMControl.Support_CX.Support_CX5
            CX_PM3.PM_IN_SCREEN = PMControl.Support_Screen.ProcessScreen
            CX_PM3.ShowWafer_Border_ToEdit = False
            CX_PM3.Show_Disconnected = False
            CX_PM3.DockPosition = PMControl.ChamberDockPositions.PM3

            If RobotConfigurationValues.CHAMBER3_TYPE = SystemModule.ModuleType.IBE Then
                CX_PM3.PM_Type = TypeOfAVPChamber.IBE
                CX_PM3.Location = New Point(703, 271)
                lblPM3MotionInitialize.Text = STR_MOTION_INITIALIZING
                lblPM3MotionInitialize.Location = New Point(CX_PM3.Left + CX_PM3.Width / 2 - 5, CX_PM3.Top + CX_PM3.Height + 5)
            ElseIf RobotConfigurationValues.CHAMBER3_TYPE = SystemModule.ModuleType.PVD Then
                CX_PM3.PM_Type = TypeOfAVPChamber.PVD
                CX_PM3.Location = New Point(707, 270)
            End If
        End If
        InitializeShutterForPM_CX5()
    End Sub

    Public Sub InitializeComponent_CX4()
        RobotHand.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX4
        lblPM1MotionInitialize.Visible = False
        lblPM2MotionInitialize.Visible = False
        lblPM3MotionInitialize.Visible = False

        lpcLoadLockA.Left = TMCtl.Left - lpcLoadLockA.Width - 3

        ''robot body config
        LLALeg.LoadLockType = LoadLockLeg.Load_Lock_Type.Type_2

        Robot_Body.AVPStyle = AVPStyles.CX4
        Robot_Body.InScreen = AVPScreens.ProcessScreen
        Robot_Body.Location = New Point(555, 269)
        RobotHand.Location = New Point(442, 157)
        Robot_Body.SensorsInstalled = AVPLib.RobotConfigurationValues.ROBOT_SENSOR_INSTALLED

        'Config aligner at LLA
        If AVPLib.RobotConfigurationValues.ALINER_VISIBLE Then
            If AVPLib.RobotConfigurationValues.ALINER_VISIBLE Then
                awcAligner.Location = New Point(622, 434)
                TransparentImageAligner.Location = New Point(623, 435)
            End If
        Else
            awcAligner.Visible = False
            Robot_Body.AlignerAtStation = RobotArmStations.Original
        End If
        SetTMPumpVisible()
        SetLLPumpVisible()
        ''MesaValves config

        MesaValveLLA.CX_Supported = PMControl.Support_CX.Support_CX4
        MesaValveLLA.DockPosition = SlitValve.SlitValvePositions.LLA
        MesaValveLLA.Location = New Point(598, 437)

        MesaValvePM1.CX_Supported = PMControl.Support_CX.Support_CX4
        MesaValvePM1.DockPosition = SlitValve.SlitValvePositions.PM1
        MesaValvePM1.Location = New Point(505, 311)

        MesaValvePM2.CX_Supported = PMControl.Support_CX.Support_CX4
        MesaValvePM2.DockPosition = SlitValve.SlitValvePositions.PM2
        MesaValvePM2.Location = New Point(598, 219)

        MesaValvePM3.CX_Supported = PMControl.Support_CX.Support_CX4
        MesaValvePM3.DockPosition = SlitValve.SlitValvePositions.PM3
        MesaValvePM3.Location = New Point(690, 312)

        '===========
        'load lock A config
        LLALeg.Location = New Point(597, 488)
        LLALeg.QuestionMark_Visible = False
        LLALeg.Leg_In_Screen = PMControl.Support_Screen.ProcessScreen
        LLALeg.LegStatus = BinaryStatusControl.DisplayStatus.Off
        LLALeg.EQ_LoadLock = Equipments.LoadLockA
        lblLoadLockADoor.Location = New Point(507, 528)

        '===
        'PM1 config
        If RobotConfigurationValues.CHAMBER1_VISIBLE Then
            CX_PM1.CX_Supported = PMControl.Support_CX.Support_CX4
            CX_PM1.PM_IN_SCREEN = PMControl.Support_Screen.ProcessScreen
            CX_PM1.ShowWafer_Border_ToEdit = False
            CX_PM1.Show_Disconnected = False
            CX_PM1.ShutterStatus = DataManagerment.Equipment.WorkingStatuses.Off
            CX_PM1.DockPosition = PMControl.ChamberDockPositions.PM1

            If RobotConfigurationValues.CHAMBER1_TYPE = SystemModule.ModuleType.IBE Then
                CX_PM1.PM_Type = TypeOfAVPChamber.IBE
                CX_PM1.Location = New Point(388, 382)
                lblPM1MotionInitialize.Text = STR_MOTION_INITIALIZING
                lblPM1MotionInitialize.Location = New Point(399, 270)
            ElseIf RobotConfigurationValues.CHAMBER1_TYPE = SystemModule.ModuleType.PVD Then
                CX_PM1.PM_Type = TypeOfAVPChamber.PVD
                CX_PM1.Location = New Point(384, 382)
            ElseIf RobotConfigurationValues.CHAMBER1_TYPE = SystemModule.ModuleType.PVD4 Then
                Dim ChamberModule As AVPLib.SystemModule =
                                                   AVPLib.ContainerData.GetRobotConfig(AVPLib.Utils.chamberName2ChamberID(RobotConfigurationValues.CHAMBER1_NAME))
                CX_PM1.NumberOfWafer = ChamberModule.MaxNumberOfSlot
                CX_PM1.PM_Type = TypeOfAVPChamber.PVD4
                lblPM1MotionStatus.Top = CX_PM1.Top - lblPM1MotionStatus.Height - 3
                lblPM1MotionStatus.Left = CX_PM1.Left
            ElseIf RobotConfigurationValues.CHAMBER1_TYPE = SystemModule.ModuleType.PVD5T Then
                Dim ChamberModule As AVPLib.SystemModule =
                                                   AVPLib.ContainerData.GetRobotConfig(AVPLib.Utils.chamberName2ChamberID(RobotConfigurationValues.CHAMBER1_NAME))
                CX_PM1.NumberOfWafer = ChamberModule.MaxNumberOfSlot
                CX_PM1.ChamberType = AllChamberType.PVD5T
                CX_PM1.PM_Type = TypeOfAVPChamber.PVD5T
                lblPM1MotionStatus.Top = CX_PM1.Top - lblPM1MotionStatus.Height - 3
                lblPM1MotionStatus.Left = CX_PM1.Left
            End If
            Utils.SetLocationPM(CX_PM1)
        End If

        'PM2 config
        If RobotConfigurationValues.CHAMBER2_VISIBLE Then
            CX_PM2.CX_Supported = PMControl.Support_CX.Support_CX4
            CX_PM2.PM_IN_SCREEN = PMControl.Support_Screen.ProcessScreen

            CX_PM2.ShowWafer_Border_ToEdit = False
            CX_PM2.Show_Disconnected = False
            CX_PM2.bicShutter.Visible = False
            CX_PM2.DockPosition = PMControl.ChamberDockPositions.PM2

            If RobotConfigurationValues.CHAMBER2_TYPE = SystemModule.ModuleType.IBE Then
                CX_PM2.PM_Type = TypeOfAVPChamber.IBE
                CX_PM2.Location = New Point(596, 176)
                lblPM2MotionInitialize.Text = STR_MOTION_INITIALIZING
                lblPM2MotionInitialize.Location = New Point(591, 52)
            ElseIf RobotConfigurationValues.CHAMBER2_TYPE = SystemModule.ModuleType.PVD Then
                CX_PM2.PM_Type = TypeOfAVPChamber.PVD
                CX_PM2.Location = New Point(593, 172)
            ElseIf RobotConfigurationValues.CHAMBER2_TYPE = SystemModule.ModuleType.PVD4 Then
                Dim ChamberModule As AVPLib.SystemModule =
                                                   AVPLib.ContainerData.GetRobotConfig(AVPLib.Utils.chamberName2ChamberID(RobotConfigurationValues.CHAMBER2_NAME))
                CX_PM2.NumberOfWafer = ChamberModule.MaxNumberOfSlot
                CX_PM2.PM_Type = TypeOfAVPChamber.PVD4
                lblPM2MotionStatus.Top = CX_PM2.Top - lblPM2MotionStatus.Height - 3
                lblPM2MotionStatus.Left = CX_PM2.Left + CX_PM2.Width - lblPM2MotionStatus.Width
            ElseIf RobotConfigurationValues.CHAMBER2_TYPE = SystemModule.ModuleType.PVD5T Then
                Dim ChamberModule As AVPLib.SystemModule =
                                                   AVPLib.ContainerData.GetRobotConfig(AVPLib.Utils.chamberName2ChamberID(RobotConfigurationValues.CHAMBER2_NAME))
                CX_PM2.NumberOfWafer = ChamberModule.MaxNumberOfSlot
                CX_PM2.ChamberType = AllChamberType.PVD5T
                CX_PM2.PM_Type = TypeOfAVPChamber.PVD5T
                lblPM2MotionStatus.Top = CX_PM2.Top - lblPM2MotionStatus.Height - 3
                lblPM2MotionStatus.Left = CX_PM2.Left + CX_PM2.Width - lblPM2MotionStatus.Width
            End If
            Utils.SetLocationPM(CX_PM2)
        End If

        'PM3
        If RobotConfigurationValues.CHAMBER3_VISIBLE Then
            CX_PM3.CX_Supported = PMControl.Support_CX.Support_CX4
            CX_PM3.PM_IN_SCREEN = PMControl.Support_Screen.ProcessScreen

            CX_PM3.ShowWafer_Border_ToEdit = False
            CX_PM3.Show_Disconnected = False
            CX_PM3.bicShutter.Visible = False
            CX_PM3.DockPosition = PMControl.ChamberDockPositions.PM3

            If RobotConfigurationValues.CHAMBER3_TYPE = SystemModule.ModuleType.IBE Then
                CX_PM3.PM_Type = TypeOfAVPChamber.IBE
                CX_PM3.Location = New Point(728, 382)
                lblPM3MotionInitialize.Text = STR_MOTION_INITIALIZING
                lblPM3MotionInitialize.Location = New Point(760, 267)
            ElseIf RobotConfigurationValues.CHAMBER3_TYPE = SystemModule.ModuleType.PVD Then
                CX_PM3.PM_Type = TypeOfAVPChamber.PVD
                CX_PM3.Location = New Point(729, 380)
            ElseIf RobotConfigurationValues.CHAMBER3_TYPE = SystemModule.ModuleType.PVD4 Then
                Dim ChamberModule As AVPLib.SystemModule =
                                                   AVPLib.ContainerData.GetRobotConfig(AVPLib.Utils.chamberName2ChamberID(RobotConfigurationValues.CHAMBER3_NAME))
                CX_PM3.NumberOfWafer = ChamberModule.MaxNumberOfSlot
                CX_PM3.PM_Type = TypeOfAVPChamber.PVD4
                lblPM3MotionStatus.Top = CX_PM3.Top - lblPM3MotionStatus.Height - 3
                lblPM3MotionStatus.Left = CX_PM3.Left + CX_PM3.Width - lblPM3MotionStatus.Width
            ElseIf RobotConfigurationValues.CHAMBER3_TYPE = SystemModule.ModuleType.PVD5T Then
                Dim ChamberModule As AVPLib.SystemModule =
                                                   AVPLib.ContainerData.GetRobotConfig(AVPLib.Utils.chamberName2ChamberID(RobotConfigurationValues.CHAMBER3_NAME))
                CX_PM3.NumberOfWafer = ChamberModule.MaxNumberOfSlot
                CX_PM3.ChamberType = AllChamberType.PVD5T
                CX_PM3.PM_Type = TypeOfAVPChamber.PVD5T
                lblPM3MotionStatus.Top = CX_PM3.Top - lblPM3MotionStatus.Height - 3
                lblPM3MotionStatus.Left = CX_PM3.Left + CX_PM3.Width - lblPM3MotionStatus.Width
            End If
            Utils.SetLocationPM(CX_PM3)
        End If
    End Sub
    ''' <author>
    '''     <name> Dy Do </name>
    '''     <date> 2019-01-28 </date>
    ''' </author>
    ''' <summary>
    ''' Arrange TurboPump/Cryo for TM
    ''' </summary>
    Private Sub SetTMPumpVisible()
        ctrTMTurboCom.Visible = RobotConfigurationValues.TMTURBO_VISIBLE _
                                                       AndAlso RobotConfigurationValues.IS_TMTURBO_SERIAL
        If RobotConfigurationValues.TMTURBO_VISIBLE Then
            PumpTM.PumpType = PumpChamber.PumpTypes.Turbo
            btnTurboTM.Location = New Point(716, 250)

        ElseIf RobotConfigurationValues.TMCRYO_VISIBLE Then
            PumpTM.PumpType = PumpChamber.PumpTypes.Cryo
            btnTurboTM.Dispose()
            lblComunicationLED_TurboTM.Dispose()
            ctrTMTurboCom.Dispose()

        Else
            btnTurboTM.Dispose()
            lblComunicationLED_TurboTM.Dispose()
            ctrTMTurboCom.Dispose()
            PumpTM.Dispose()
            HivacValveTM.Dispose()
        End If
    End Sub

    ''' <author>
    '''     <name> Dy Do </name>
    '''     <date> 2019-01-28 </date>
    ''' </author>
    ''' <summary>
    ''' Arrange LLPump/Cryo for TM
    ''' </summary>
    Private Sub SetLLPumpVisible()
        ctrLLATurboCom.Visible = RobotConfigurationValues.LLA_TURBO_VISIBLE _
                                                       AndAlso RobotConfigurationValues.IS_LLATURBO_SERIAL

        If RobotConfigurationValues.LLA_TURBO_VISIBLE Then 'using turbo
            btnTurboLLA.BringToFront()
            PumpLLA.PumpType = PumpChamber.PumpTypes.Turbo

        ElseIf RobotConfigurationValues.LLA_CRYO_VISIBLE Then 'using cryo
            PumpLLA.PumpType = PumpChamber.PumpTypes.Cryo

            btnTurboLLA.Dispose()
            lblComunicationLED_TurboLLA.Dispose()
            ctrLLATurboCom.Dispose()
        Else 'only rough valve
            btnTurboLLA.Dispose()
            HivacValveLLA.Dispose()
            PumpLLA.Dispose()

        End If
    End Sub

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-05</date>
    ''' </author>
    ''' <summary>
    ''' Check Permission
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CheckPermission()
        AVPLib.Log.guiLogger.Info("Enter CheckPermission")
        Try
            '#03/07/2011 
            '#[Sl_Build 12_Feb 16, 2011]User account should be similar to avp/pvd request
            '#Begin fix:
            If AVPLib.ContainerData.Permission(PERMISSION_010) Then
                ActiveForm()
            Else
                InactiveForm()
            End If
            '#End fix.
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave CheckPermission")
    End Sub

#End Region

#Region "Protected method"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-03</date>
    ''' </author>
    ''' <summary>
    ''' Create status tree to manage status of all objects inside
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub CreateStatusTree()
        Try
            Dim sbcAlignerWafer As New StatusWaferAlignerControl(awcAligner)

            Dim srrRoundRectangleStatusLLA As New StatusSlitValveControl(MesaValveLLA)
            Dim srrRoundRectangleStatus1 As New StatusSlitValveControl(MesaValvePM1)
            Dim srrRoundRectangleStatus2 As New StatusSlitValveControl(MesaValvePM2)
            Dim srrRoundRectangleStatus3 As New StatusSlitValveControl(MesaValvePM3)
            Dim srrRoundRectangleStatus4 As New StatusSlitValveControl(HivacValveLLA)
            Dim srrRoundRectangleStatus5 As New StatusSlitValveControl(HivacValveTM)
            
            Dim ClearAllWafer As New StatusClearAllWaferControl(btnClearAllWafer)
            Dim sfbFlashingLabel As New StatusFlashingLabel(lblFlashing)
            Dim slbPM1Motion As New StatusMotionLabel(lblPM1MotionStatus)
            Dim slbPM2Motion As New StatusMotionLabel(lblPM2MotionStatus)
            Dim slbPM3Motion As New StatusMotionLabel(lblPM3MotionStatus)
            Dim slbLoadLockADoor As New StatusLabel(lblLoadLockADoor)

            Dim stbTMTurbo As New TurboStatusButton(btnTurboTM)
            Dim stbLLATurbo As New TurboStatusButton(btnTurboLLA)
            Dim sclComunicationLED_TurboPumpLLA As New StatusColorLabel(lblComunicationLED_TurboLLA)
            Dim sclComunicationLED_TurboPumpTM As New StatusColorLabel(lblComunicationLED_TurboTM)

            sclComunicationLED_TurboPumpLLA.CommStateChanged = New CommunicationState(AddressOf UpdateLLAComStatus)
            sclComunicationLED_TurboPumpTM.CommStateChanged = New CommunicationState(AddressOf UpdateTMComStatus)

            Dim srbRobot As New StatusRobot(m_Robot)

            Dim stlAlignerEECA As New StatusLabel(lblAlignerEECA)
            Dim stlAlignerEECM As New StatusLabel(lblAlignerEECM)

            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(sfbFlashingLabel)
            m_stoStatusObject.AddChild(CX_PM1.Status)
            m_stoStatusObject.AddChild(CX_PM2.Status)
            m_stoStatusObject.AddChild(CX_PM3.Status)

            m_stoStatusObject.AddChild(slbPM1Motion)
            m_stoStatusObject.AddChild(slbPM2Motion)
            m_stoStatusObject.AddChild(slbPM3Motion)
            m_stoStatusObject.AddChild(slbLoadLockADoor)
            m_stoStatusObject.AddChild(LLALeg.Status)
            m_stoStatusObject.AddChild(sbcAlignerWafer)

            Dim robotBodyStatusObj As New StatusObject(Me.Robot_Body.Name)
            Dim sbcCircleStatus1 As New StatusAVPStatusControl(Robot_Body.SensorLLA)
            Dim sbcCircleStatus3 As New StatusAVPStatusControl(Robot_Body.SensorPM1)
            Dim sbcCircleStatus4 As New StatusAVPStatusControl(Robot_Body.SensorPM2)
            Dim sbcCircleStatus5 As New StatusAVPStatusControl(Robot_Body.SensorPM3)

            robotBodyStatusObj.AddChild(sbcCircleStatus1)
            robotBodyStatusObj.AddChild(sbcCircleStatus3)
            robotBodyStatusObj.AddChild(sbcCircleStatus4)
            robotBodyStatusObj.AddChild(sbcCircleStatus5)

            m_stoStatusObject.AddChild(robotBodyStatusObj)

                m_stoStatusObject.AddChild(srrRoundRectangleStatus1)
                m_stoStatusObject.AddChild(srrRoundRectangleStatus2)
                m_stoStatusObject.AddChild(srrRoundRectangleStatus3)
            m_stoStatusObject.AddChild(srrRoundRectangleStatus4)
            m_stoStatusObject.AddChild(srrRoundRectangleStatus5)

            m_stoStatusObject.AddChild(stbTMTurbo)
            m_stoStatusObject.AddChild(stbLLATurbo)
            m_stoStatusObject.AddChild(sclComunicationLED_TurboPumpLLA)
            m_stoStatusObject.AddChild(sclComunicationLED_TurboPumpTM)

            m_stoStatusObject.AddChild(srrRoundRectangleStatusLLA)
            m_stoStatusObject.AddChild(ClearAllWafer)

            m_stoStatusObject.AddChild(srbRobot)
            m_stoStatusObject.AddChild(cbcChamber1.Status)
            m_stoStatusObject.AddChild(cbcChamber2.Status)
            m_stoStatusObject.AddChild(cbcChamber3.Status)

            'm_stoStatusObject.AddChild(wccWaferCount.Status)
            m_stoStatusObject.AddChild(lpcLoadLockA.Status)
            m_stoStatusObject.AddChild(TMCtl.Status)

            If frmPM1_PopUpStatusPanel IsNot Nothing Then
                m_stoStatusObject.AddChild(frmPM1_PopUpStatusPanel.Status)
            End If

            If frmPM2_PopUpStatusPanel IsNot Nothing Then
                m_stoStatusObject.AddChild(frmPM2_PopUpStatusPanel.Status)
            End If

            If frmPM3_PopUpStatusPanel IsNot Nothing Then
                m_stoStatusObject.AddChild(frmPM3_PopUpStatusPanel.Status)
            End If

            m_stoStatusObject.AddChild(stlAlignerEECA)
            m_stoStatusObject.AddChild(stlAlignerEECM)

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub
#End Region

#Region "Private method"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-05</date>
    ''' </author>
    ''' <summary>
    ''' Active Form
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ActiveForm()
        Try
            Me.lpcLoadLockA.CheckingPermission = True

            TMCtl.lblHeader.Enabled = True
            Me.lpcLoadLockA.EnableDisableForm(True)

            Me.cbcChamber1.EnableDisableForm(True)
            Me.cbcChamber2.EnableDisableForm(True)
            Me.cbcChamber3.EnableDisableForm(True)

            Me.wccWaferCount.Enabled = True

            Enable_DisableWFControl(True)

            Me.TransparentImageAligner.Enabled = True

            Me.btnMakeAllOnline.Enabled = AVPLib.ContainerData.Permission(PERMISSION_013)
            Me.btnClearAllWafer.Enabled = AVPLib.ContainerData.Permission(PERMISSION_013)

            mnuResume.Visible = AVPLib.ContainerData.Permission(PERMISSION_003)
            mnuReturn.Visible = AVPLib.ContainerData.Permission(PERMISSION_003)
            mnuReturnNow.Visible = AVPLib.ContainerData.Permission(PERMISSION_003)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-07-09 </date>
    ''' </author>
    ''' <summary>
    ''' Enable/Disable Clear All Wafer button
    ''' </summary>
    Public Sub EnableClearAllWaferButton(ByVal enable As Boolean)
        Me.btnClearAllWafer.Enabled = enable AndAlso AVPLib.ContainerData.Permission(PERMISSION_013)
    End Sub

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-05</date>
    ''' </author>
    ''' <summary>
    ''' Inactive Form
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InactiveForm()
        Try
            Me.lpcLoadLockA.CheckingPermission = False

            TMCtl.lblHeader.Enabled = False
            Me.lpcLoadLockA.EnableDisableForm(False)

            Me.cbcChamber1.EnableDisableForm(False)
            Me.cbcChamber2.EnableDisableForm(False)
            Me.cbcChamber3.EnableDisableForm(False)

            Me.wccWaferCount.Enabled = False

            Enable_DisableWFControl(False)

            Me.TransparentImageAligner.Enabled = False

            Me.btnMakeAllOnline.Enabled = False
            Me.btnClearAllWafer.Enabled = False

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name>Hoai Ly</name>
    '''    	<date> 2015-07-02</date>
    ''' </author>
    ''' <summary>
    ''' Enable Disable WFControl
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Enable_DisableWFControl(ByVal b_Isenable As Boolean)
        Try
            For Each wfControl As AVPWaferControl In Me.CX_PM1.m_lstWaferControl
                wfControl.Enabled = b_Isenable
            Next

            For Each wfControl As AVPWaferControl In Me.CX_PM2.m_lstWaferControl
                wfControl.Enabled = b_Isenable
            Next

            For Each wfControl As AVPWaferControl In Me.CX_PM3.m_lstWaferControl
                wfControl.Enabled = b_Isenable
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error("Enable_DisableWFControl" & ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-10-13</date>
    ''' </author>
    ''' <summary>
    ''' Show or visible chamber based on configuration file
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadRobotConfig()
        Me.cbcChamber1.Text = AVPLib.RobotConfigurationValues.CHAMBER1_NAME & "-" & UCase(STRING_OFFLINE)
        Me.cbcChamber1.Tag = AVPLib.RobotConfigurationValues.CHAMBER1_NAME
        Me.cbcChamber2.Text = AVPLib.RobotConfigurationValues.CHAMBER2_NAME & "-" & UCase(STRING_OFFLINE)
        Me.cbcChamber2.Tag = AVPLib.RobotConfigurationValues.CHAMBER2_NAME
        Me.cbcChamber3.Text = AVPLib.RobotConfigurationValues.CHAMBER3_NAME & "-" & UCase(STRING_OFFLINE)
        Me.cbcChamber3.Tag = AVPLib.RobotConfigurationValues.CHAMBER3_NAME
        lpcLoadLockA.NumSlot = AVPLib.RobotConfigurationValues.LOADLOCKA_SLOTS

        'default for CX4
        InitializeComponent_CX4()

        If (AVPLib.RobotConfigurationValues.CHAMBER1_VISIBLE = False) Then
            CX_PM1.Dispose()
            Robot_Body.PM1Installed = False
            cbcChamber1.Visible = False
            MesaValvePM1.Status = SlitValve.SlitValveDisplayStatus.Off
        End If

        If (AVPLib.RobotConfigurationValues.CHAMBER2_VISIBLE = False) Then
            CX_PM2.Dispose()
            Robot_Body.PM2Installed = False
            cbcChamber2.Visible = False
            MesaValvePM2.Status = SlitValve.SlitValveDisplayStatus.Off
        End If

        If (AVPLib.RobotConfigurationValues.CHAMBER3_VISIBLE = False) Then
            CX_PM3.Dispose()
            Robot_Body.PM3Installed = False
            cbcChamber3.Visible = False
            MesaValvePM3.Status = SlitValve.SlitValveDisplayStatus.Off
        End If

        lblFlashing.Top = Label1.Bottom - 2 ''Flashing Text

        Utils.SetConfigRobotStation(Me.RobotHand)
    End Sub
#End Region

#Region "Events � Buttons � Forms�"
    ''' <author>Hai Tran</author>
    ''' <date>2021-11-04</date>
    ''' <summary>
    ''' Update LLA communition status
    ''' </summary>
    Private Sub UpdateLLAComStatus(ByVal state As Boolean)
        Try
            If Me.InvokeRequired Then
                Me.Invoke(New CommunicationState(AddressOf UpdateLLAComStatus), state)
                Return
            End If

            If state Then
                ctrLLATurboCom.Status = AVPControls.AVPDataLib.DisplayStatus.On
            Else
                ctrLLATurboCom.Status = AVPControls.AVPDataLib.DisplayStatus.Error
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2021-11-04</date>
    ''' <summary>
    ''' Update LLA communition status
    ''' </summary>
    Private Sub UpdateTMComStatus(ByVal state As Boolean)
        Try
            If Me.InvokeRequired Then
                Me.Invoke(New CommunicationState(AddressOf UpdateTMComStatus), state)
                Return
            End If

            If state Then
                ctrTMTurboCom.Status = AVPControls.AVPDataLib.DisplayStatus.On
            Else
                ctrTMTurboCom.Status = AVPControls.AVPDataLib.DisplayStatus.Error
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-05</date>
    ''' </author>
    ''' <summary>
    ''' Handle load event of process pannel
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ProcessPanel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            LLALeg.CassettePresent = False
            Me.LoadRobotConfig()
            m_Robot.Initiate()
            lpcLoadLockA.lblFinishLoadUnload.Visible = False
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-12-15</date>
    ''' </author>
    ''' <summary>
    ''' Handle load event of Load Lock A
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lpcLoadLockA_LoadProcess(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lpcLoadLockA.LoadProcess
        AVPLib.Log.guiLogger.Info("Enter lpcLoadLockA_LoadProcess")
        Try
            'ContainerForm.CassettesPanel.cmsLeftTool.Enabled = False
            'ContainerForm.CassettesPanel.PopUpPanel.btnLLAOnline.Enabled = False
            'ContainerForm.CassettesPanel.PopUpPanel.btnLLAOffline.Enabled = False
            ContainerForm.CassettesPanel.PopUpPanel.btnLLAAutoPumpDown.Enabled = False
            ContainerForm.CassettesPanel.PopUpPanel.btnLLAAutoVent.Enabled = False
            m_blnIsLLAProcessing = True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave lpcLoadLockA_LoadProcess")
    End Sub

    Private Sub lpcLoadLockA_StopLoadProcess(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lpcLoadLockA.StopLoadProcess
        AVPLib.Log.guiLogger.Info("Enter lpcLoadLockA_StopLoadProcess")
        Try
            'ContainerForm.CassettesPanel.cmsLeftTool.Enabled = True
            ContainerForm.CassettesPanel.PopUpPanel.btnLLAOnline.Enabled = True
            ContainerForm.CassettesPanel.PopUpPanel.btnLLAOffline.Enabled = True
            If ContainerForm.CassettesPanel.PopUpPanel.btnLLAOnline.Status = SL_CustomButton.DisplayStatus.Off Then
                ContainerForm.CassettesPanel.PopUpPanel.btnLLAAutoPumpDown.Enabled = True
                ContainerForm.CassettesPanel.PopUpPanel.btnLLAAutoVent.Enabled = True
            End If
            m_blnIsLLAProcessing = False
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Enter lpcLoadLockA_StopLoadProcess")
    End Sub

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-12-15</date>
    ''' </author>
    ''' <summary>
    ''' Handle unload event of Load Lock A
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lpcLoadLockA_UnLoadProcess(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lpcLoadLockA.UnLoadProcess
        AVPLib.Log.guiLogger.Info("Enter lpcLoadLockA_UnLoadProcess")
        Try
            'ContainerForm.CassettesPanel.cmsLeftTool.Enabled = False
            'ContainerForm.CassettesPanel.PopUpPanel.btnLLAOnline.Enabled = False
            'ContainerForm.CassettesPanel.PopUpPanel.btnLLAOffline.Enabled = False
            ContainerForm.CassettesPanel.PopUpPanel.btnLLAAutoPumpDown.Enabled = False
            ContainerForm.CassettesPanel.PopUpPanel.btnLLAAutoVent.Enabled = False
            m_blnIsLLAProcessing = True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave lpcLoadLockA_UnLoadProcess")
    End Sub

    Private Sub lpcLoadLockA_StopUnLoadProcess(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                                                      Handles lpcLoadLockA.StopUnLoadProcess
        AVPLib.Log.guiLogger.Info("Enter lpcLoadLockA_StopUnLoadProcess")
        Try
            'ContainerForm.CassettesPanel.cmsLeftTool.Enabled = True
            ContainerForm.CassettesPanel.PopUpPanel.btnLLAOnline.Enabled = True
            ContainerForm.CassettesPanel.PopUpPanel.btnLLAOffline.Enabled = True
            If ContainerForm.CassettesPanel.PopUpPanel.btnLLAOnline.Status = SL_CustomButton.DisplayStatus.Off Then
                ContainerForm.CassettesPanel.PopUpPanel.btnLLAAutoPumpDown.Enabled = True
                ContainerForm.CassettesPanel.PopUpPanel.btnLLAAutoVent.Enabled = True
            End If
            m_blnIsLLAProcessing = False
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave lpcLoadLockA_StopUnLoadProcess")
    End Sub

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-12-15</date>
    ''' </author>
    ''' <summary>
    ''' Handle finish load event of Load Lock A
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lpcLoadLockA_FinishedLoadProcess(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lpcLoadLockA.FinishedLoadProcess
        AVPLib.Log.guiLogger.Info("Enter lpcLoadLockA_FinishedLoadProcess")
        Try
            ContainerForm.CassettesPanel.PopUpPanel.btnLLAOnline.Enabled = True
            ContainerForm.CassettesPanel.PopUpPanel.btnLLAOffline.Enabled = True
            If ContainerForm.CassettesPanel.PopUpPanel.btnLLAOnline.Status = SL_CustomButton.DisplayStatus.Off Then
                ContainerForm.CassettesPanel.PopUpPanel.btnLLAAutoPumpDown.Enabled = True
                ContainerForm.CassettesPanel.PopUpPanel.btnLLAAutoVent.Enabled = True
            End If
            If Me.lpcLoadLockA.btnLoad.Tag = "On" Or Me.lpcLoadLockA.btnUnload.Tag = Nothing Then
                LLALeg.CassettePresent = True
                ContainerForm.CassettesPanel.LLALeg.CassettePresent = True
            End If
            m_blnIsLLAProcessing = False
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave lpcLoadLockA_FinishedLoadProcess")
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-12-15</date>
    ''' </author>
    ''' <summary>
    ''' Handle finish unload event of Load Lock A
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lpcLoadLockA_FinishedUnLoadProcess(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lpcLoadLockA.FinishedUnLoadProcess
        AVPLib.Log.guiLogger.Info("Enter lpcLoadLockA_FinishedUnLoadProcess")
        Try
            'ContainerForm.CassettesPanel.cmsLeftTool.Enabled = True
            ContainerForm.CassettesPanel.PopUpPanel.btnLLAOnline.Enabled = True
            ContainerForm.CassettesPanel.PopUpPanel.btnLLAOffline.Enabled = True
            If ContainerForm.CassettesPanel.PopUpPanel.btnLLAOnline.Status = SL_CustomButton.DisplayStatus.Off Then
                ContainerForm.CassettesPanel.PopUpPanel.btnLLAAutoPumpDown.Enabled = True
                ContainerForm.CassettesPanel.PopUpPanel.btnLLAAutoVent.Enabled = True
            End If
            '#05/04/2011 
            '#AVP( process screen).  When Unload, all lotid/sequence is cleared and user click load again.   
            '#If user click on lotid or sequence,  AVP will display lotid sequence name again.
            '#Begin fix:
            ContainerForm.ProcessPanel.lpcLoadLockA.txtSeqID.Text = String.Empty ''Clear Seq ID after Finish Unload
            'ContainerForm.ProcessPanel.lpcLoadLockA.txtLotID.Text = String.Empty ''Clear Lot ID after Finish Unload
            'ContainerForm.ProcessPanel.lpcLoadLockA.LotID = String.Empty ''Clear Lot ID after Finish Unload
            ContainerForm.ProcessPanel.lpcLoadLockA.SeqID = String.Empty ''Clear Seq ID after Finish Unload
            '#End fix
            If Me.lpcLoadLockA.btnUnload.Tag = "On" Or Me.lpcLoadLockA.btnUnload.Tag = Nothing Then
                LLALeg.CassettePresent = False
                ContainerForm.CassettesPanel.LLALeg.CassettePresent = False
            End If
            m_blnIsLLAProcessing = False
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave lpcLoadLockA_FinishedUnLoadProcess")
    End Sub
#End Region
    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-05-25</date>
    ''' </author>
    ''' <summary>
    ''' When click Chamber 1 in GUI-Process then show details chamber 1
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cbcChamber1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbcChamber1.Click, cbcChamber2.Click, cbcChamber3.Click
        Try
            If Not CType(sender, ChamberControl).Header.Enabled Then
                Return
            End If
            Select Case CType(sender, ChamberControl).Name
                Case cbcChamber1.Name
                    Me.PM1_PopUpStatusPanel.ShowDialog()
                Case cbcChamber2.Name
                    Me.PM2_PopUpStatusPanel.ShowDialog()
                Case cbcChamber3.Name
                    Me.PM3_PopUpStatusPanel.ShowDialog()
            End Select
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-08-18</date>
    ''' </author>
    ''' <summary>
    ''' Show actions in the GUI
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lblStatusText_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblStatusText.TextChanged
        ContainerForm.CassettesPanel.lblStatusText.Text = Me.lblStatusText.Text
    End Sub
    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-08-18</date>
    ''' </author>
    ''' <summary>
    ''' Handle click event on transferImageControl at wafer in Aligner and Robot
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TransparentImageAligner_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransparentImageAligner.Click
        AVPLib.Log.guiLogger.Info("Enter TransparentImageAligner_Click")
        Try
            Dim equipment As AVPLib.DataManagerment.Equipment = Nothing
            Dim blResumed As Boolean = False

            If CType(sender, Control).Name = "TransparentImageAligner" Then
                m_intClickedPosition = CLICKEDALIGNER
                equipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Aligner.ToString())
            ElseIf sender Is Me.RobotHand Then
                m_intClickedPosition = CLICKEDROBOT
                equipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Robot.ToString())
            End If
            Dim bShowReturnNow As Boolean = False
            If equipment IsNot Nothing AndAlso equipment.GetWaferInfo() IsNot Nothing Then
                Dim avpProcessJob As AVPLib.Business.AVPProcessJob = Nothing
                avpProcessJob = AVPLib.Business.AVPCore.Instance().JobManager().GetProcessJob(equipment.GetWaferInfo().WaferID)
                If avpProcessJob IsNot Nothing Then
                    blResumed = avpProcessJob.IsPaused()
                    bShowReturnNow = avpProcessJob.IsJobOver()
                Else
                    bShowReturnNow = True
                End If
            End If
            ShowContextMenuClickOnAlignerAndRobot(sender, blResumed, bShowReturnNow)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave TransparentImageAligner_Click")
    End Sub

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-11-13 </date>
    ''' </author>
    ''' <summary>
    ''' Handle click event on RobotHand
    ''' </summary>
    Private Sub RobotHand_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RobotHand.Click
        Try
            Dim robot As AVPLib.DataManagerment.Robot = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Robot.ToString())
            ''check it is robot first, then check robot has wafer or not (AndAlso different than And)
            If robot IsNot Nothing AndAlso robot.GetWaferInfo() IsNot Nothing Then
                Dim strID As String = robot.GetWaferInfo().WaferID
                Dim blResumed As Boolean = False
                ProcessPanel.ClickedPosition = CLICKEDROBOT
                Dim avpProcessJob As AVPLib.Business.AVPProcessJob = Nothing
                avpProcessJob = AVPLib.Business.AVPCore.Instance().JobManager().GetProcessJob(strID)
                Dim bShowReturnNow As Boolean = False
                If avpProcessJob IsNot Nothing Then
                    blResumed = avpProcessJob.IsPaused() ''PJ is paused
                    bShowReturnNow = avpProcessJob.IsJobOver()
                Else
                    If (Utils.isAlignerInUse()) Then
                        If (AVPLib.RobotConfigurationValues.ALIGNER_AT_STATION = AVPLib.RobotConfigurationValues.LLA_STATION_NO AndAlso
                        robot.GetWaferInfo().WaferID.ToString().Contains("A")) Then
                            bShowReturnNow = False
                        Else
                            bShowReturnNow = True
                        End If
                    Else
                        bShowReturnNow = True
                    End If
                End If
                ShowContextMenuClickOnAlignerAndRobot(sender, blResumed, bShowReturnNow)
            Else
                AVPRobotMain.GotoScreen(SystemScreens.TMScreen)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    '''' <author>
    ''''    	<name> Khiet Tran </name>
    ''''    	<date> 20098-10-29</date>
    '''' </author>
    '''' <summary>
    '''' Display context menu when user click on transparent image control of Aligner and Robot
    '''' </summary>
    '''' <remarks></remarks>
    Private Sub ShowContextMenuClickOnAlignerAndRobot(ByVal sender As Object, ByVal blshowResume As Boolean, ByVal bShowReturnNow As Boolean)
        Try
            Dim pos As Point

            If sender Is Me.RobotHand Then
                If Me.RobotHand.WaferStatus <> WaferStatuses.NONE Then
                    pos = Me.RobotHand.WaferCenterLocation
                    Dim d As Integer = CInt(WAFER_DIAMETER_CX4 / 2.0F - 2)
                    pos.Offset(-d, d)
                    pos.Offset(Me.RobotHand.Location)
                    pos = Me.PointToScreen(pos)
                Else
                    AVPRobotMain.GotoScreen(SystemScreens.TMScreen)
                    Return
                End If
            Else
                Dim cpcTemp As Control = CType(sender, Control)
                pos = cpcTemp.Location
                pos.Y += cpcTemp.Height
                pos = Me.PointToScreen(pos)
            End If

            mnuResume.Enabled = blshowResume
            mnuReturn.Enabled = blshowResume
            mnuReturnNow.Enabled = bShowReturnNow And (Not IsButtonClearAllWaferClicked)
            cmsChamber.Show(pos)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Sub ShowContextMenuClickOn_LLQuestionMark(ByVal LLName As String)
        Try
            Dim pos As New System.Drawing.Point()
            If LLName = Equipments.LoadLockA.ToString() Then
                pos = New System.Drawing.Point(Me.LLALeg.Location)
                pos.X = pos.X + Me.LLALeg.LLQuestionMark.Location.X
                pos.Y += Me.LLALeg.LLQuestionMark.Location.Y + Me.LLALeg.LLQuestionMark.Height
                m_intClickedPosition = CLICKEDLOADLOCKA

            End If
            pos = Me.PointToScreen(pos)
            mnuResume.Enabled = True
            mnuReturn.Enabled = False
            mnuReturnNow.Enabled = False
            cmsChamber.Show(pos)

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    '''' <author>
    ''''    	<name> Khiet Tran </name>
    ''''    	<date> 20098-10-29</date>
    '''' </author>
    '''' <summary>
    '''' hande click menu Return for mark for return
    '''' </summary>
    '''' <remarks></remarks>
    Private Sub mnuReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReturn.Click
        AVPLib.Log.guiLogger.Info("Enter mnuReturn_Click")
        Dim strMessageText As String = String.Empty
        strMessageText = AVPLib.ContainerData.GetMessageText("MarkForReturnWafer")
        Dim objEquipment As AVPLib.DataManagerment.Equipment = Nothing
        Dim iSlot As Int16 = 1
        Try
            If (m_intClickedPosition = CLICKEDALIGNER) Then
                If (Utils.ShowAVPMessageBox(strMessageText, ALIGN, MessageBoxIcon.Question) = DialogResult.OK) Then
                    ' Update the wafer info
                    objEquipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Aligner.ToString())
                    objEquipment.GetWaferInfo().WaferStatus = enumWaferStatus.eWaferError
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                                  AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                  "[Main Screen] " + "Click menu Return for mark for return on Aligner.")
                End If
            ElseIf (m_intClickedPosition = CLICKEDROBOT) Then
                If (Utils.ShowAVPMessageBox(strMessageText, ROBOT_STR, MessageBoxIcon.Question) = DialogResult.OK) Then
                    ' Update the wafer Info
                    objEquipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Robot.ToString())
                    objEquipment.GetWaferInfo().WaferStatus = enumWaferStatus.eWaferError
                    'ContainerForm.ProcessPanel.ticHandOriginal.ticWafer.Refresh()
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                                  AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                  "[Main Screen] " + "Click menu Return for mark for return on Robot hand.")
                End If
            ElseIf (m_intClickedPosition = CLICKEDCHAMBER1) Then
                If (Utils.ShowAVPMessageBox(strMessageText, CHAMBER_STR, MessageBoxIcon.Question) = DialogResult.OK) Then
                    ' Get information on Chambers
                    objEquipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Chamber1.ToString())
                    iSlot = ClickedSlot
                    ContainerForm.ProcessPanel.CX_PM1.Refresh()
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                                  AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                  "[Main Screen] " + "Click menu Return for mark for return on PM1.")
                End If
            ElseIf (m_intClickedPosition = CLICKEDCHAMBER2) Then
                If (Utils.ShowAVPMessageBox(strMessageText, CHAMBER_STR, MessageBoxIcon.Question) = DialogResult.OK) Then
                    objEquipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Chamber2.ToString())
                    iSlot = ClickedSlot
                    ContainerForm.ProcessPanel.CX_PM2.Refresh()
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                                   AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                   "[Main Screen] " + "Click menu Return for mark for return on PM2.")
                End If
            ElseIf (m_intClickedPosition = CLICKEDCHAMBER3) Then
                If (Utils.ShowAVPMessageBox(strMessageText, CHAMBER_STR, MessageBoxIcon.Question) = DialogResult.OK) Then
                    objEquipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Chamber3.ToString())
                    iSlot = ClickedSlot
                    ContainerForm.ProcessPanel.CX_PM3.Refresh()
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                                  AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                  "[Main Screen] " + "Click menu Return for mark for return on PM3.")
                End If
            End If
            If objEquipment IsNot Nothing Then
                For index As Integer = 1 To objEquipment.WaferCapacity
                    If (objEquipment.GetWaferInfo(index) IsNot Nothing) Then
                        objEquipment.GetWaferInfo(index).WaferStatus = enumWaferStatus.eWaferError
                        objEquipment.SetMarkForReturnFlag(index)
                        Me.m_stoStatusObject.RequestStatus("PJMarkForReturn", objEquipment.GetWaferInfo(index).WaferID)
                    End If
                Next
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave mnuReturn_Click")
    End Sub

    '''' <author>
    ''''    	<name> Dat Cao </name>
    ''''    	<date> 2011-07-12</date>
    '''' </author>
    '''' <summary>
    '''' hande click menu Return for mark for return
    '''' </summary>
    '''' <remarks></remarks>
    Public Function SECSGEM_MarkForReturn(ByVal ChamberName As String) As Boolean
        AVPLib.Log.guiLogger.Info("Enter mnuReturn_Click")
        Try
            'Moi Nguoi Choi Cha Le Minh Cam Dau Lam
            Dim strMessageText As String = String.Empty
            strMessageText = AVPLib.ContainerData.GetMessageText("MarkForReturnWafer")
            Dim objChamber As DataManagerment.Equipment = DataManagerment.EquipmentManager.GetEquipment(ChamberName)
            Dim iSlot As Int16 = 1
            If ChamberName.Contains("Chamber") Then
                iSlot = ClickedSlot
            End If

            If objChamber IsNot Nothing AndAlso objChamber.GetWaferInfo(iSlot) IsNot Nothing Then
                Dim strID As String = objChamber.GetWaferInfo(iSlot).WaferID
                Dim blResumed As Boolean = False
                Dim avpProcessJob As AVPLib.Business.AVPProcessJob = Nothing
                avpProcessJob = AVPLib.Business.AVPCore.Instance().JobManager().GetProcessJob(strID)
                If avpProcessJob IsNot Nothing Then
                    blResumed = avpProcessJob.IsPaused() ''PJ is paused
                Else
                    Return False
                End If

                If blResumed = False Then
                    Return False
                End If

                objChamber.GetWaferInfo(iSlot).WaferStatus = enumWaferStatus.eWaferError
                Select Case ChamberName
                    Case AVPLib.ConstEnum.Equipments.Aligner.ToString()
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                                                          AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                                          "[Main Screen] " + "Click menu Return for mark for return on Aligner.")
                    Case AVPLib.ConstEnum.Equipments.Robot.ToString()
                        'ContainerForm.ProcessPanel.ticHandOriginal.ticWafer.Refresh()

                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                                      AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                      "[Main Screen] " + "Click menu Return for mark for return on Robot hand.")
                    Case AVPLib.ConstEnum.Equipments.Chamber1.ToString()
                        ContainerForm.ProcessPanel.CX_PM1.Repaint()
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                                      AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                      "[Main Screen] " + "Click menu Return for mark for return on PM1.")
                    Case AVPLib.ConstEnum.Equipments.Chamber2.ToString()
                        ContainerForm.ProcessPanel.CX_PM1.Repaint()
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                                      AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                      "[Main Screen] " + "Click menu Return for mark for return on PM2.")
                    Case AVPLib.ConstEnum.Equipments.Chamber3.ToString()
                        ContainerForm.ProcessPanel.CX_PM1.Repaint()
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                                      AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                      "[Main Screen] " + "Click menu Return for mark for return on PM3.")
                End Select


                objChamber.SetMarkForReturnFlag(iSlot)
                Me.m_stoStatusObject.RequestStatus("PJMarkForReturn", objChamber.GetWaferInfo(iSlot).WaferID)

                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
            Return False
        End Try
        AVPLib.Log.guiLogger.Info("Leave mnuReturn_Click")
    End Function
    '''' <author>
    ''''    	<name> Khiet Tran </name>
    ''''    	<date> 20098-10-29</date>
    '''' </author>
    '''' <summary>
    '''' hande click menu resume wafer
    '''' </summary>
    '''' <remarks></remarks>
    Private Sub mnuResume_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuResume.Click
        AVPLib.Log.guiLogger.Info("Enter mnuResume_Click")
        Dim strMessageText As String = String.Empty
        strMessageText = AVPLib.ContainerData.GetMessageText("ResumeWafer")
        Dim waferInfo As AVPLib.AVPWaferInfo = Nothing
        Dim equipment As AVPLib.DataManagerment.Equipment = Nothing
        Dim iSlot As Int16 = 1
        Try
            If (m_intClickedPosition = CLICKEDALIGNER) Then
                If (Utils.ShowAVPMessageBox(strMessageText, ALIGN, MessageBoxIcon.Question) = DialogResult.OK) Then
                    ' Update the wafer info
                    equipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Aligner.ToString())

                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                                   AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                   "[Main Screen] " + "Click menu Resume wafer on Aligner.")

                End If
            ElseIf (m_intClickedPosition = CLICKEDROBOT) Then
                If (Utils.ShowAVPMessageBox(strMessageText, ROBOT_STR, MessageBoxIcon.Question) = DialogResult.OK) Then
                    ' Update the wafer Info
                    equipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Robot.ToString())

                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                                  AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                  "[Main Screen] " + "Click menu Resume wafer on Robot Hand.")
                End If
            ElseIf (m_intClickedPosition = CLICKEDCHAMBER1) Then
                If (Utils.ShowAVPMessageBox(strMessageText, RobotConfigurationValues.CHAMBER1_NAME, MessageBoxIcon.Question) = DialogResult.OK) Then
                    ' Get information on Chambers
                    equipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Chamber1.ToString())
                    iSlot = m_intClickedSlot
                    If (equipment Is Nothing OrElse Utils.IsChamberOnline(equipment.Name) = False) Then
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                                 AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                 "[Main Screen] " + "Click menu Resume wafer on PM1. PM1 is offline")
                        Utils.ShowAVPMessageBox("PM1 is Offline", "Resume Failed", MessageBoxIcon.Warning, AVPMessageBox.AVPMessageBoxButton.OK)
                        Exit Sub
                    End If
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                                 AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                 "[Main Screen] " + "Click menu Resume wafer on PM1.")
                End If
            ElseIf (m_intClickedPosition = CLICKEDCHAMBER2) Then
                If (Utils.ShowAVPMessageBox(strMessageText, RobotConfigurationValues.CHAMBER2_NAME, MessageBoxIcon.Question) = DialogResult.OK) Then
                    equipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Chamber2.ToString())
                    iSlot = m_intClickedSlot
                    If (equipment Is Nothing OrElse Utils.IsChamberOnline(equipment.Name) = False) Then
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                                 AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                 "[Main Screen] " + "Click menu Resume wafer on PM2. PM2 is offline")
                        Utils.ShowAVPMessageBox("PM2 is Offline", "Resume Failed", MessageBoxIcon.Warning, AVPMessageBox.AVPMessageBoxButton.OK)
                        Exit Sub
                    End If
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                                 AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                 "[Main Screen] " + "Click menu Resume wafer on PM2.")
                End If
            ElseIf (m_intClickedPosition = CLICKEDCHAMBER3) Then
                If (Utils.ShowAVPMessageBox(strMessageText, RobotConfigurationValues.CHAMBER3_NAME, MessageBoxIcon.Question) = DialogResult.OK) Then
                    equipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Chamber3.ToString())
                    iSlot = m_intClickedSlot
                    If (equipment Is Nothing OrElse Utils.IsChamberOnline(equipment.Name) = False) Then
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                                 AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                 "[Main Screen] " + "Click menu Resume wafer on PM3. PM3 is offline")
                        Utils.ShowAVPMessageBox("PM3 is Offline", "Resume Failed", MessageBoxIcon.Warning, AVPMessageBox.AVPMessageBoxButton.OK)
                        Exit Sub
                    End If
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                                 AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                 "[Main Screen] " + "Click menu Resume wafer on PM3.")
                End If
            ElseIf (m_intClickedPosition = CLICKEDLOADLOCKA) Then
                If (Utils.ShowAVPMessageBox(strMessageText, Equipments.LoadLockA.ToString(), MessageBoxIcon.Question) = DialogResult.OK) Then
                    If (Utils.checkOnlineLLA() = False) Then
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                                  AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                  "[Main Screen] " + "Click menu Resume wafer on LLA. LLA is offline")
                        Utils.ShowAVPMessageBox("LLA is Offline", "Resume Failed", MessageBoxIcon.Warning, AVPMessageBox.AVPMessageBoxButton.OK)
                        Exit Sub
                    End If
                    Me.m_stoStatusObject.RequestStatus("PJResume", LLALeg.LLQuestionMark.PausedJobID)
                    'LLALeg.LLQuestionMark.Enabled = False
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                                  AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                  "[Main Screen] " + "Click menu Resume wafer on LLA.")
                    Return
                End If

            End If

            If equipment IsNot Nothing Then
                For index As Integer = 1 To equipment.WaferCapacity
                    If equipment.GetWaferInfo(index) IsNot Nothing Then
                        Me.m_stoStatusObject.RequestStatus("PJResume", equipment.GetWaferInfo(index).WaferID)
                    End If
                Next
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave mnuResume_Click")
    End Sub
    '''' <author>
    ''''    	<name> Dat Cao </name>
    ''''    	<date> 2011-06-30</date>
    '''' </author>
    '''' <summary>
    '''' Only Used for AVP Secs Gem, 
    '''' </summary>
    '''' <remarks></remarks>
    Public Function ResumeAllEquipment(ByVal sLLName As String) As Boolean
        AVPLib.Log.guiLogger.Info("Enter All Resume")
        Dim blResult As Boolean = True
        Try
            Dim strMessageText As String = String.Empty
            strMessageText = AVPLib.ContainerData.GetMessageText("ResumeWafer")
            Dim waferInfo As AVPLib.AVPWaferInfo = Nothing
            Dim equipment As AVPLib.DataManagerment.Equipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Aligner.ToString())

            Dim avpProcessJob As AVPLib.Business.AVPProcessJob = Nothing

            'Check Aligner, if Aligner status is Paused, and wafer in LLA -> resume aligner
            If equipment.GetWaferInfo() IsNot Nothing Then
                avpProcessJob = AVPLib.Business.AVPCore.Instance().JobManager().GetProcessJob(equipment.GetWaferInfo().WaferID)
                If (avpProcessJob IsNot Nothing AndAlso avpProcessJob.AVPParentControlJob.LoadlockName = sLLName AndAlso avpProcessJob.IsPaused()) Then
                    Me.m_stoStatusObject.RequestStatus("PJResume", equipment.GetWaferInfo().WaferID)
                    'add Log here--------------------------------------------------------------------------------------------------
                End If
            End If

            If sLLName = AVPLib.ConstEnum.Equipments.LoadLockA.ToString() Then
                If (Utils.checkOnlineLLA() = False) Then
                    'add Log here--------------------------------------------------------------------------------------------------
                    blResult = blResult And False
                ElseIf (LLALeg.LLQuestionMark.PausedJobID = String.Empty) Then
                    'add Log here--------------------------------------------------------------------------------------------------
                    blResult = blResult And True
                Else
                    Me.m_stoStatusObject.RequestStatus("PJResume", LLALeg.LLQuestionMark.PausedJobID)
                    ' LLALeg.LLQuestionMark.Enabled = False
                    'add Log here--------------------------------------------------------------------------------------------------
                    blResult = blResult And True
                End If
            End If

            'for ROBOT
            blResult = blResult And RequestResume(AVPLib.ConstEnum.Equipments.Robot.ToString(), sLLName)
            'for Chamber
            For i As Integer = 1 To AVPRobotMain.MaxChamber2Install
                blResult = blResult And RequestResume(AVPLib.ConstEnum.Chamber & i, sLLName)
            Next

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave All Resume")
        Return blResult
    End Function
    '''' <author>
    ''''    	<name> Dat Cao </name>
    ''''    	<date> 2011-06-30</date>
    '''' </author>
    '''' <summary>
    '''' Only Used for AVP Secs Gem, 
    '''' </summary>
    '''' <remarks></remarks>
    Public Function RequestResume(ByVal ChamberName As String, ByVal sLLName As String) As Boolean
        Dim equipment As AVPLib.DataManagerment.Equipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(ChamberName)
        If equipment IsNot Nothing AndAlso equipment.GetWaferInfo() IsNot Nothing Then
            Dim avpProcessJob As AVPLib.Business.AVPProcessJob = Nothing
            avpProcessJob = AVPLib.Business.AVPCore.Instance().JobManager().GetProcessJob(equipment.GetWaferInfo().WaferID)
            If (avpProcessJob IsNot Nothing AndAlso avpProcessJob.AVPParentControlJob.LoadlockName = sLLName AndAlso avpProcessJob.IsPaused()) Then
                If (ChamberName.Contains(AVPLib.ConstEnum.Equipments.Robot.ToString()) AndAlso Utils.checkOnlineTM() = False) Then
                    'add Log here--------------------------------------------------------------------------------------------------
                    Return False
                ElseIf (ChamberName.Contains(AVPLib.ConstEnum.Chamber) AndAlso Utils.IsChamberOnline(equipment.Name) = False) Then
                    'add Log here--------------------------------------------------------------------------------------------------
                    Return False
                Else
                    For index As Integer = 1 To equipment.WaferCapacity
                        If equipment.GetWaferInfo(index) IsNot Nothing Then
                            Me.m_stoStatusObject.RequestStatus("PJResume", equipment.GetWaferInfo(index).WaferID)
                        End If
                    Next
                    'add Log here--------------------------------------------------------------------------------------------------
                    Return True
                End If
            End If
        End If
        Return True
    End Function
    '''' <author>
    ''''    	<name> Khiet Tran </name>
    ''''    	<date> 20098-10-29</date>
    '''' </author>
    '''' <summary>
    '''' set wafer inside chambers
    '''' </summary>
    '''' <remarks></remarks>
    Private Sub UpdateWaferInfoInChamber(ByVal strMenuName As String)
        Try
            Select Case strMenuName
                Case "mnuReturn"
                    Select Case m_intClickedPosition
                        Case CLICKEDCHAMBER1
                        Case CLICKEDCHAMBER2
                        Case CLICKEDCHAMBER3
                    End Select
                Case "mnuResume"
                    Select Case m_intClickedPosition
                        Case CLICKEDCHAMBER1
                            Me.m_stoStatusObject.RequestStatus(mnuResume.Name, "Click Chamber1_Resume")
                        Case CLICKEDCHAMBER2
                            Me.m_stoStatusObject.RequestStatus(mnuResume.Name, "Click Chamber2_Resume")
                        Case CLICKEDCHAMBER3
                            Me.m_stoStatusObject.RequestStatus(mnuResume.Name, "Click Chamber3_Resume")
                    End Select
            End Select
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    '''' <author>
    ''''    	<name> Dat Vo </name>
    ''''    	<date> 2010-04-07</date>
    '''' </author>
    '''' <summary>
    '''' Handle the all online button click
    '''' </summary>
    '''' <remarks></remarks>
    Private Sub btnMakeAllOnline_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMakeAllOnline.Click
        '#05/18/2011 
        '#-	Operator privilege should not allow to use �Make all Online� button.   Safety.    Maintiance can be working
        '# on the back while operator click on this button and run a wafer through a PMx that maintaince is working on
        '#Begin fix
        If AVPLib.ContainerData.Permission(PERMISSION_013) = False Then
            Exit Sub
        End If
        '#end fix

        If (Utils.ShowAVPMessageBox("Would you like to make all PMs, Load Lock and TM Online?", "Confirmation", MessageBoxIcon.Question) = DialogResult.OK) Then

            MakeAllOnline()
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                                             AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                             "[Main Screen] " + "Click on button Make All Online.")
        End If
    End Sub

    Public Sub MakeAllOnline(Optional ByVal blnShowPopUp As Boolean = False)
        Try
            If AVPLib.AVPDataLib.Verify() <> 0 OrElse Not AVPLib.AVPDataLib.IsSecureDllLoaded() Then
                If blnShowPopUp Then
                    Utils.ShowAVPMessageBox("Cannot make all PMs, Load Lock and TM Online.", "AVP", MessageBoxIcon.Error)
                End If
                Return
            End If

            ' Make online for Load Lock A, B and TM        
            ContainerForm.CassettesPanel.GoOnline()

            ' Make online for all chambers
            ' Chamber 1
            If ContainerForm.Chamber1Visible AndAlso Not ContainerForm.Chamber1Panel.IsOnline Then
                ContainerForm.Chamber1Panel.GoOnline(False)
            End If

            ' Chamber 2
            If ContainerForm.Chamber2Visible AndAlso Not ContainerForm.Chamber2Panel.IsOnline Then
                ContainerForm.Chamber2Panel.GoOnline(False)
            End If

            ' Chamber 3
            If ContainerForm.Chamber3Visible AndAlso Not ContainerForm.Chamber3Panel.IsOnline Then
                ContainerForm.Chamber3Panel.GoOnline(False)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    '''' <author>
    ''''    	<name> Dat Vo </name>
    ''''    	<date> 2010-04-07</date>
    '''' </author>
    '''' <summary>
    '''' Handle Load Lock and Aligner click
    '''' </summary>
    '''' <remarks></remarks>
    Private Sub tcLoadLockAndAligner_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles awcAligner.Click
        If sender Is awcAligner Then
            If awcAligner.Status = DisplayStatus.Off OrElse awcAligner.WaferStatus = WaferStatuses.NONE Then
                AVPRobotMain.GotoScreen(SystemScreens.AlignerScreen)
            Else
                Try
                    Dim equipment As AVPLib.DataManagerment.Equipment = Nothing
                    Dim blResumed As Boolean = False

                    m_intClickedPosition = CLICKEDALIGNER
                    equipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Aligner.ToString())

                    Dim bShowReturnNow As Boolean = False
                    If equipment IsNot Nothing AndAlso equipment.GetWaferInfo IsNot Nothing Then
                        Dim avpProcessJob As AVPLib.Business.AVPProcessJob = Nothing
                        avpProcessJob = AVPLib.Business.AVPCore.Instance().JobManager().GetProcessJob(equipment.GetWaferInfo().WaferID)
                        If avpProcessJob IsNot Nothing Then
                            blResumed = avpProcessJob.IsPaused()
                            bShowReturnNow = avpProcessJob.IsJobOver()
                        Else
                            bShowReturnNow = True
                        End If
                    End If
                    ShowContextMenuClickOnAlignerAndRobot(sender, blResumed, bShowReturnNow)
                Catch ex As Exception
                    AVPLib.Log.avpLogger.Error(ex.ToString())
                End Try
            End If
        Else
            AVPRobotMain.GotoScreen(SystemScreens.TMScreen)
        End If
    End Sub

    Private Sub mnuReturnNow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReturnNow.Click
        Dim strMessageText As String = "Would you like to return wafer to {0}?"
        Dim waferInfo As AVPLib.AVPWaferInfo = Nothing
        Dim objEquipment As AVPLib.DataManagerment.Equipment = Nothing
        Dim strSrcDestPath As String = String.Empty
        Dim iSlotID As Integer = 1
        '#05/04/2011 
        '#-	Change message to �Would you like to return wafer to LLx?�  x=a,b
        '#Begin fix
        Select Case m_intClickedPosition
            Case CLICKEDALIGNER
                objEquipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Aligner.ToString())
            Case CLICKEDROBOT
                objEquipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Robot.ToString())
            Case CLICKEDCHAMBER1
                objEquipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Chamber1.ToString())
                iSlotID = m_intClickedSlot
            Case CLICKEDCHAMBER2
                objEquipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Chamber2.ToString())
                iSlotID = m_intClickedSlot
            Case CLICKEDCHAMBER3
                objEquipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Chamber3.ToString())
                iSlotID = m_intClickedSlot
        End Select
        If objEquipment IsNot Nothing Then
            If objEquipment.GetWaferInfo(iSlotID) IsNot Nothing Then
                Dim strLoadLockAndSlot As String = GetLoadLockNameAndSlot(objEquipment.GetWaferInfo(iSlotID).WaferID)
                If strLoadLockAndSlot.StartsWith(LOAD_LOCK_A) Then
                    strMessageText = String.Format(strMessageText, "LLA")
                End If
            End If
        End If
        '#End fix.
        Try
            If (m_intClickedPosition = CLICKEDALIGNER) Then
                If (Utils.ShowAVPMessageBox(strMessageText, ALIGN, MessageBoxIcon.Question) = DialogResult.OK) Then
                    ' Update the wafer info
                    objEquipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Aligner.ToString())
                    strSrcDestPath = objEquipment.Name
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                  AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                  "[Main Screen] " + "Click menu Return wafer on Aligner.")
                End If
            ElseIf (m_intClickedPosition = CLICKEDROBOT) Then
                If (Utils.ShowAVPMessageBox(strMessageText, ROBOT_STR, MessageBoxIcon.Question) = DialogResult.OK) Then
                    ' Update the wafer Info
                    objEquipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Robot.ToString())
                    strSrcDestPath = "RobotArm"
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                  AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                  "[Main Screen] " + "Click menu Return wafer on Robot Hand.")
                End If
            ElseIf (m_intClickedPosition = CLICKEDCHAMBER1) Then
                If (Utils.ShowAVPMessageBox(strMessageText, AVPLib.RobotConfigurationValues.CHAMBER1_NAME, MessageBoxIcon.Question) = DialogResult.OK) Then
                    ' Get information on Chambers
                    objEquipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Chamber1.ToString())
                    strSrcDestPath = objEquipment.Name & ",Slot" & iSlotID
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                 AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                 "[Main Screen] " + "Click menu Return wafer on PM1.")
                End If
            ElseIf (m_intClickedPosition = CLICKEDCHAMBER2) Then
                If (Utils.ShowAVPMessageBox(strMessageText, AVPLib.RobotConfigurationValues.CHAMBER2_NAME, MessageBoxIcon.Question) = DialogResult.OK) Then
                    objEquipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Chamber2.ToString())
                    strSrcDestPath = objEquipment.Name & ",Slot" & iSlotID
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                 AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                 "[Main Screen] " + "Click menu Return wafer on PM2.")
                End If
            ElseIf (m_intClickedPosition = CLICKEDCHAMBER3) Then
                If (Utils.ShowAVPMessageBox(strMessageText, AVPLib.RobotConfigurationValues.CHAMBER3_NAME, MessageBoxIcon.Question) = DialogResult.OK) Then
                    objEquipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Chamber3.ToString())
                    strSrcDestPath = objEquipment.Name & ",Slot" & iSlotID
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                 AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                 "[Main Screen] " + "Click menu Return wafer on PM3.")
                End If
            End If

            If objEquipment IsNot Nothing Then
                If objEquipment.GetWaferInfo(iSlotID) IsNot Nothing Then
                    Dim strLoadLockAndSlot As String = GetLoadLockNameAndSlot(objEquipment.GetWaferInfo(iSlotID).WaferID)
                    If strLoadLockAndSlot.StartsWith(LOAD_LOCK_A) Then
                        If lpcLoadLockA.btnStart.Text = "START" Then
                            lpcLoadLockA.btnStart.Enabled = False
                            lpcLoadLockA.btnLoad.Enabled = False
                            lpcLoadLockA.btnUnload.Enabled = False
                        End If
                    End If
                    strSrcDestPath = strSrcDestPath & "," & strLoadLockAndSlot
                    m_stoStatusObject.RequestStatus("CJReturn", strSrcDestPath)
                    AVPLib.Utils.ShowStatusMessage(AVPLib.ConstEnum.Return_Wafer_Starting)
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeMessage, AVPLib.ContainerData.LogSource.AVPMainScreen, AVPLib.ConstEnum.Return_Wafer_Starting)
                    ContainerForm.CassettesPanel.ReturnWaferStatus = TranferWaferStatus.Starting
                Else
                    Utils.ShowAVPMessageBox("Wafer information is lost, please return wafer manually", "Return Wafer", MessageBoxIcon.Exclamation, MessageBoxButtons.OK)
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                  AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                  "[Main Screen] " + "Warning return wafer manually")
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Function GetLoadLockNameAndSlot(ByVal waferId As String) As String
        Dim kA As String = "A"
        Dim strResult As String = String.Empty
        If waferId.Contains(kA) Then
            strResult = "LoadLockA,Slot" & waferId.Replace(kA, "")
        End If
        Return strResult
    End Function

    Private Sub LLAQuestionMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If sender Is LLALeg.LLQuestionMark Then
            ShowContextMenuClickOn_LLQuestionMark(Equipments.LoadLockA.ToString())
        End If

    End Sub

    Private Sub ReturnWafer(ByVal objEquipment As AVPLib.DataManagerment.Equipment, ByRef ReturnFreeJobCount As Integer)
        Dim waferInfo As AVPLib.AVPWaferInfo = Nothing
        Dim strSrcDestPath As String = String.Empty
        Try
            If (objEquipment IsNot Nothing) Then
                For i As Integer = 1 To objEquipment.WaferCapacity

                    If (objEquipment.Name = "Robot") Then
                        strSrcDestPath = "RobotArm"
                    Else
                        strSrcDestPath = objEquipment.Name
                    End If

                    If objEquipment.GetWaferInfo(i) IsNot Nothing Then
                        Dim strLoadLockAndSlot As String = GetLoadLockNameAndSlot(objEquipment.GetWaferInfo(i).WaferID)
                        'DISABLE START/LOAD/UNLOAD BUTTON ON LLA
                        If (Me.Robot_Body.LLAInstalled()) Then
                            lpcLoadLockA.btnStart.Enabled = False
                            lpcLoadLockA.btnLoad.Enabled = False
                            lpcLoadLockA.btnUnload.Enabled = False
                        End If

                        If (objEquipment.Name.Contains("Chamber")) Then
                            strSrcDestPath = strSrcDestPath & ",Slot" & i & "," & strLoadLockAndSlot
                        Else
                            strSrcDestPath = strSrcDestPath & "," & strLoadLockAndSlot
                        End If
                        m_stoStatusObject.RequestStatus("CJClearFreeJob", strSrcDestPath)
                        ReturnFreeJobCount += 1
                    End If
                Next
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    Private Sub ReturnCoronaWafer(ByVal objEquipment As AVPLib.DataManagerment.CoronaChamber, ByRef ReturnFreeJobCount As Integer, _
                                                                ByRef strPMSubtrateRotating As String, ByRef isSubtrateInPosition As Boolean)
        Dim waferInfo As AVPLib.AVPWaferInfo = Nothing
        Dim strSrcDestPath As String = String.Empty
        Try

            If (objEquipment IsNot Nothing) Then

                Dim iCurrentStation As Integer = objEquipment.Substrate_Current_Station

                'log for detect clear wafer at corona chamber but show no wafer to clear
                'if iCurrentStation = 0 -> wrong current station from back-end
                AVPLib.Log.avpLogger.Error("ReturnCoronaWafer: " & objEquipment.Name & " at Current Station:" & iCurrentStation.ToString)


                If iCurrentStation = -1 Then 'detect moving
                    'really move
                    If objEquipment.Substrate_Table_Rotate_Status = DataManagerment.Equipment.WorkingStatuses.On Then
                        strPMSubtrateRotating = strPMSubtrateRotating & " " & AVPLib.Utils.chamberID2ChamberName(objEquipment.Name)
                        Exit Sub
                    ElseIf objEquipment.Round_Substrate_Current_Station = -1 Then
                        strPMSubtrateRotating = strPMSubtrateRotating & " " & AVPLib.Utils.chamberID2ChamberName(objEquipment.Name)
                        'moving complete but not in position
                        isSubtrateInPosition = False
                        Exit Sub
                    Else
                        iCurrentStation = objEquipment.Round_Substrate_Current_Station
                    End If

                End If

                If (iCurrentStation > 0) Then
                    For i As Integer = iCurrentStation To objEquipment.WaferCapacity

                        strSrcDestPath = objEquipment.Name

                        If objEquipment.GetWaferInfo(i) IsNot Nothing Then
                            If Not CheckSlitValveClosed(strSrcDestPath) Then
                                Exit Sub
                            End If
                            Dim strLoadLockAndSlot As String = GetLoadLockNameAndSlot(objEquipment.GetWaferInfo(i).WaferID)
                            strSrcDestPath = strSrcDestPath & ",Slot" & i & "," & strLoadLockAndSlot
                            m_stoStatusObject.RequestStatus("CJClearFreeJob", strSrcDestPath)
                            ReturnFreeJobCount += 1
                        End If

                    Next

                    If (iCurrentStation > 1) Then
                        For i As Integer = 1 To iCurrentStation - 1

                            strSrcDestPath = objEquipment.Name

                            If objEquipment.GetWaferInfo(i) IsNot Nothing Then
                                If Not CheckSlitValveClosed(strSrcDestPath) Then
                                    Exit Sub
                                End If
                                Dim strLoadLockAndSlot As String = GetLoadLockNameAndSlot(objEquipment.GetWaferInfo(i).WaferID)
                                strSrcDestPath = strSrcDestPath & ",Slot" & i & "," & strLoadLockAndSlot
                                m_stoStatusObject.RequestStatus("CJClearFreeJob", strSrcDestPath)
                                ReturnFreeJobCount += 1
                            End If

                        Next
                    End If
                End If

            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Function CheckSlitValveClosed(ByVal strChamber As String) As Boolean
        Try
            If Not AVPLib.Utils.IsChamberSlitValveClose(strChamber) Then
                AVPLib.Utils.ThrowAlarm("PM Isovalve Is Not Closed, Can Not Return Wafers")
                m_blShowPopupNoWafer = False
                Return False
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return True
    End Function

    Private Sub btnClearAllWafer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearAllWafer.Click
        '#08/15/2011 
        '#-	User privileges.  Clear all wafer need to have access right.  We can group "Clear all wafer" 
        '#and "Make All Online" into one privilege
        '#Begin fix
        If AVPLib.ContainerData.Permission(PERMISSION_013) = False Then
            Exit Sub
        End If
        '#end fix

        If (Utils.ShowAVPMessageBox("Would you like to return all wafers?", "Return All Wafers", MessageBoxIcon.Question) <> DialogResult.OK) Then
            Exit Sub
        Else
            m_blShowPopupNoWafer = True
            btnClearAllWafer.Enabled = False
            IsButtonClearAllWaferClicked = True
            lpcLoadLockA.ClearAllWaferStatus()
            Utils.LogUserEvent(sender, "Main Screen")
        End If
        Try
            ''BEGIN CHECK CHAMBER IS PROCESSING
            Dim strPMProcessing As String = String.Empty
            For index As Integer = 1 To AVPRobotMain.MaxChamber2Install
                Dim chamberId As String = ConstEnum.Chamber + index.ToString()

                If AVPLib.ContainerData.IsChamberVisible(chamberId) AndAlso Utils.IsProcessingAtChamber(chamberId) Then
                    Dim chamberName As String = AVPLib.Utils.chamberID2ChamberName(chamberId)
                    strPMProcessing = IIf(strPMProcessing = String.Empty, chamberName, strPMProcessing & "," & chamberName)
                End If
            Next

            If (strPMProcessing <> String.Empty) Then
                Utils.ShowAVPMessageBox("Return all wafers failed, " & strPMProcessing & " is processing", "Return All Wafers", MessageBoxIcon.Error, AVPMessageBox.AVPMessageBoxButton.OK)
                btnClearAllWafer.Enabled = True
                IsButtonClearAllWaferClicked = False
                Exit Try
            End If
            ''END CHECK CHAMBER IS PROCESSING

            Dim objLoadLockA As AVPLib.DataManagerment.LoadLock = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.LoadLockA.ToString())
            If objLoadLockA IsNot Nothing Then
                objLoadLockA.IsCycleInATM_Mode = False
            End If

            Dim objEquipment As AVPLib.DataManagerment.Equipment = Nothing
            Dim ReturnFreeJobCount As Integer = 0
            Dim strPMSubtrateRotating As String = String.Empty
            'check Robot
            objEquipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Robot.ToString())
            If (objEquipment IsNot Nothing AndAlso objEquipment.GetWaferInfo() IsNot Nothing AndAlso _
            CheckWaferFree(objEquipment.GetWaferInfo().WaferID) = True) Then
                ReturnWafer(objEquipment, ReturnFreeJobCount)
            End If
            'check Aligner
            objEquipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Aligner.ToString())
            If (objEquipment IsNot Nothing AndAlso objEquipment.GetWaferInfo() IsNot Nothing AndAlso _
            CheckWaferFree(objEquipment.GetWaferInfo().WaferID) = True) Then
                ReturnWafer(objEquipment, ReturnFreeJobCount)
            End If

            Dim isSubtrateInPosition As Boolean = True
            If (AVPLib.RobotConfigurationValues.CHAMBER1_VISIBLE) Then
                objEquipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Chamber1.ToString())
                If (objEquipment IsNot Nothing AndAlso CheckWaferFree(objEquipment) = True) Then
                    Dim objChamber As AVPLib.DataManagerment.Chamber = CType(objEquipment, AVPLib.DataManagerment.Chamber)
                    If (objChamber.EquipmentType = AVPLib.SystemModule.ModuleType.PVD4) Then
                        ReturnCoronaWafer(objChamber, ReturnFreeJobCount, strPMSubtrateRotating, isSubtrateInPosition)
                    Else
                        ReturnWafer(objEquipment, ReturnFreeJobCount)
                    End If

                End If
            End If
            If (AVPLib.RobotConfigurationValues.CHAMBER2_VISIBLE) Then
                objEquipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Chamber2.ToString())
                If (objEquipment IsNot Nothing AndAlso CheckWaferFree(objEquipment) = True) Then
                    Dim objChamber As AVPLib.DataManagerment.Chamber = CType(objEquipment, AVPLib.DataManagerment.Chamber)
                    If (objChamber.EquipmentType = AVPLib.SystemModule.ModuleType.PVD4) Then
                        ReturnCoronaWafer(objChamber, ReturnFreeJobCount, strPMSubtrateRotating, isSubtrateInPosition)
                    Else
                        ReturnWafer(objEquipment, ReturnFreeJobCount)
                    End If
                End If
            End If
            If (AVPLib.RobotConfigurationValues.CHAMBER3_VISIBLE) Then
                objEquipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Chamber3.ToString())
                If (objEquipment IsNot Nothing AndAlso CheckWaferFree(objEquipment) = True) Then
                    Dim objChamber As AVPLib.DataManagerment.Chamber = CType(objEquipment, AVPLib.DataManagerment.Chamber)
                    If (objChamber.EquipmentType = AVPLib.SystemModule.ModuleType.PVD4) Then
                        ReturnCoronaWafer(objChamber, ReturnFreeJobCount, strPMSubtrateRotating, isSubtrateInPosition)
                    Else
                        ReturnWafer(objEquipment, ReturnFreeJobCount)
                    End If
                End If
            End If
            Dim haveError As Boolean = False

            If strPMSubtrateRotating <> String.Empty And isSubtrateInPosition Then
                haveError = True
                Utils.ShowAVPMessageBox("Subtrate is rotating at" & strPMSubtrateRotating & "." & vbCrLf & "Can't return all wafers", "Return All Wafers", MessageBoxIcon.Exclamation, AVPMessageBox.AVPMessageBoxButton.OK)
            ElseIf isSubtrateInPosition = False Then
                haveError = True
                Utils.ShowAVPMessageBox("Subtrate is not at Slot Position in" & strPMSubtrateRotating & "." & vbCrLf & "Can't return all wafers", "Return All Wafers", MessageBoxIcon.Exclamation, AVPMessageBox.AVPMessageBoxButton.OK)
            ElseIf (ReturnFreeJobCount = 0) Then
                haveError = True
                If m_blShowPopupNoWafer Then
                    Utils.ShowAVPMessageBox("No wafer to return", "Return All Wafers", MessageBoxIcon.Exclamation, AVPMessageBox.AVPMessageBoxButton.OK)
                End If
            End If

            If (haveError) Then
                ContainerForm.ProcessPanel.EnableClearAllWaferButton(True)
                IsButtonClearAllWaferClicked = False
                lpcLoadLockA.ClearAllWaferStatus()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Function CheckWaferFree(ByVal objEquipment As DataManagerment.Equipment) As Boolean
        Try
            If (objEquipment IsNot Nothing AndAlso objEquipment.WaferCapacity > 0) Then
                For i As Integer = 1 To objEquipment.WaferCapacity
                    If (objEquipment.GetWaferInfo(i) IsNot Nothing AndAlso CheckWaferFree(objEquipment.GetWaferInfo(i).WaferID)) Then
                        Return True
                    End If
                Next
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
            Return False
        End Try
        Return False
    End Function
    Private Function CheckWaferFree(ByVal WaferID As String) As Boolean
        Try
            Dim avpProcessJob As AVPLib.Business.AVPProcessJob = Nothing
            If (AVPLib.Business.AVPCore.Instance() IsNot Nothing AndAlso _
            AVPLib.Business.AVPCore.Instance().JobManager() IsNot Nothing) Then
                avpProcessJob = AVPLib.Business.AVPCore.Instance().JobManager().GetProcessJob(WaferID)
                If (avpProcessJob IsNot Nothing) Then
                    Return False
                Else
                    Return True
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
            Return False
        End Try
    End Function

    Private Sub Robot_Body_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Robot_Body.Click
        AVPRobotMain.GotoScreen(SystemScreens.TMScreen)
    End Sub
End Class