Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib
Imports System.Text.RegularExpressions
Imports AVPLib.ConstEnum
Imports AVP_Robot_Project.Utils
Imports AVPLib.DataManagerment
Imports AVPControls
Imports AVPControls.AVPDataLib

Public Enum ProtectedModStatus
    [On]
    [Off]
End Enum
Public Enum TranferWaferStatus
    [None]
    [Starting]
    [Error]
    [Finished]
End Enum

Public Class CassettesPanel

    Public Class TMProtectedMode
#Region "LocalVariable"
        Private m_status As ProtectedModStatus
        Private m_TMProtected_Time As Integer = 0
        Private m_TMProtected_Timer As Integer = 0
#End Region

#Region "Constructor"
        Public Sub New()
            m_status = ProtectedModStatus.Off
            m_TMProtected_Time = 0
            m_TMProtected_Timer = 0 ' get from file config here
        End Sub
        Public Sub New(ByVal IsOpen As Boolean, ByVal MaxTime As Integer)
            m_status = ProtectedModStatus.Off
            m_TMProtected_Time = MaxTime
            m_TMProtected_Timer = 0
        End Sub
#End Region
#Region "Properties"
        Public Property Status() As ProtectedModStatus
            Get
                Return m_status
            End Get
            Set(ByVal value As ProtectedModStatus)
                m_status = value
            End Set
        End Property
        Public Property MaxTime() As Integer
            Get
                Return m_TMProtected_Time
            End Get
            Set(ByVal value As Integer)
                m_TMProtected_Time = value
            End Set
        End Property
        Public Property CurrentTime() As Integer
            Get
                Return m_TMProtected_Timer
            End Get
            Set(ByVal value As Integer)
                m_TMProtected_Timer = value
            End Set
        End Property
#End Region
#Region "Function"
        Public Sub StartProtectedMode()
            m_status = ProtectedModStatus.On
        End Sub
        Public Sub StopProtectedMode()
            m_status = ProtectedModStatus.Off
            m_TMProtected_Timer = 0
        End Sub
#End Region
    End Class
#Region "Class Constants & Variables"
    Private Const DX As Integer = -140
    Private Const DY As Integer = -58
    Private Const CLICKEDNOWHERE As Integer = -1
    Private Const CLICKEDALIGNER As Integer = 0
    Private Const CLICKEDCHAMBER1 As Integer = 1
    Private Const CLICKEDCHAMBER2 As Integer = 2
    Private Const CLICKEDCHAMBER3 As Integer = 3
    Private Const CLICKEDROBOT As Integer = 7
    Private m_Robot As Robot
    Private Shared m_intClickedChamber As Integer
    Public ISLLA_ONLINE As Boolean = False
    Public ISTM_ONLINE As Boolean = False
    Private m_PanelStyle As CX_Style = CX_Style.CX4
    Private m_PopUpPanel As TMPopUpPanel = Nothing
    Private m_LLACryoPopUpPanel As CryoPopUpPanel = Nothing
    Private m_TMCryoPopUpPanel As CryoPopUpPanel = Nothing
    Private m_TM_Protected_Mode As TMProtectedMode
    Private m_ReturnWaferStatus As TranferWaferStatus = TranferWaferStatus.None
    Private m_ReturnStatusText As String = String.Empty

    Private m_CGGaugesFrm As CGGaugesFrm = Nothing
    Private m_LLACGGaugesFrm As CGGaugesFrm = Nothing
    Private m_Rough1CGGaugesFrm As CGGaugesFrm = Nothing
    Private m_Rough2CGGaugesFrm As CGGaugesFrm = Nothing
    Private m_TMFLCGGaugesFrm As CGGaugesFrm = Nothing
    Private m_LLAFLCGGaugesFrm As CGGaugesFrm = Nothing


    Private m_strMessageReleaseRoughPump1 As String = "ReleaseRoughPump1InUse"
    Private m_strMessageReleaseRoughPump2 As String = "ReleaseRoughPump2InUse"

    Private m_timerUpdateGasline As System.Timers.Timer = New System.Timers.Timer(300)
#End Region

#Region "Property"
    Private m_IsAllowActionOnTM As Boolean = False
    Public Property IsAllowActionOnTM() As Boolean
        Get
            Return m_IsAllowActionOnTM
        End Get
        Set(ByVal value As Boolean)
            m_IsAllowActionOnTM = value
        End Set
    End Property

    Private m_IsAllowActionOnLLA As Boolean = False
    Public Property IsAllowActionOnLLA() As Boolean
        Get
            Return m_IsAllowActionOnLLA
        End Get
        Set(ByVal value As Boolean)
            m_IsAllowActionOnLLA = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2011-01-19</date>
    ''' </author>
    ''' <summary>
    ''' Get an instance of SLPopUpPanel
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property PopUpPanel() As TMPopUpPanel
        Get
            Return m_PopUpPanel
        End Get
    End Property

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2011-01-19</date>
    ''' </author>
    ''' <summary>
    ''' Get an instance of SLPopUpPanel
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property LLACryoPopUpPanel() As CryoPopUpPanel
        Get
            Return m_LLACryoPopUpPanel
        End Get
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2011-01-19</date>
    ''' </author>
    ''' <summary>
    ''' Get an instance of SLPopUpPanel
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property TMCryoPopUpPanel() As CryoPopUpPanel
        Get
            Return m_TMCryoPopUpPanel
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

    Friend m_evtTMVentPumpdownInProgress As Threading.ManualResetEvent = New Threading.ManualResetEvent(False)
    Public ReadOnly Property EvtTMVentPumpdownInProgress() As Threading.ManualResetEvent
        Get
            Return m_evtTMVentPumpdownInProgress
        End Get
    End Property

    Friend m_evtLLAVentPumpdownInProgress As Threading.ManualResetEvent = New Threading.ManualResetEvent(False)
    Public ReadOnly Property EvtLLAVentPumpdownInProgress() As Threading.ManualResetEvent
        Get
            Return m_evtLLAVentPumpdownInProgress
        End Get
    End Property

    Public Property ReturnWaferStatus() As TranferWaferStatus
        Get
            Return m_ReturnWaferStatus
        End Get
        Set(ByVal value As TranferWaferStatus)
            m_ReturnWaferStatus = value
        End Set
    End Property
    'Dat Cao
    '31-03-2011
    Public ReadOnly Property TM_ProtectedMode() As TMProtectedMode
        Get
            If (m_TM_Protected_Mode Is Nothing) Then
                m_TM_Protected_Mode = New TMProtectedMode(False, 100)
            End If
            Return m_TM_Protected_Mode
        End Get
    End Property

    ''' <author>
    '''    	<name> Van Le </name>
    '''    	<date> 2014-08-29</date>
    ''' </author>
    ''' <summary>
    ''' Get an instance of CGGaugesFrm
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property TMCGGaugesFrm() As CGGaugesFrm
        Get
            Return m_CGGaugesFrm
        End Get
    End Property

    ''' <author>
    '''    	<name> Van Le </name>
    '''    	<date> 2014-08-25</date>
    ''' </author>
    ''' <summary>
    ''' Get an instance of CGGaugesFrm
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property LLACGGaugesFrm() As CGGaugesFrm
        Get
            Return m_LLACGGaugesFrm
        End Get
    End Property

    ''' <author>
    '''    	<name> Van Le </name>
    '''    	<date> 2014-08-25</date>
    ''' </author>
    ''' <summary>
    ''' Get an instance of CGGaugesFrm
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Rough1CGGaugesFrm() As CGGaugesFrm
        Get
            Return m_Rough1CGGaugesFrm
        End Get
    End Property

    Public ReadOnly Property Rough2CGGaugesFrm() As CGGaugesFrm
        Get
            Return m_Rough2CGGaugesFrm
        End Get
    End Property

    Public ReadOnly Property TMFLCGGaugesFrm() As CGGaugesFrm
        Get
            Return m_TMFLCGGaugesFrm
        End Get
    End Property

    Public ReadOnly Property LLAFLCGGaugesFrm() As CGGaugesFrm
        Get
            Return m_LLAFLCGGaugesFrm
        End Get
    End Property
#End Region

#Region "Constructors & Dispose"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-17</date>
    ''' </author>
    ''' <summary>
    ''' Initalize cassettes panel
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Try
            m_Robot = New Robot("CassetteRobot")
            m_Robot.Hands = RobotHand

            m_PopUpPanel = New TMPopUpPanel
            m_PopUpPanel.Name = "PopUpPanel"
            m_PopUpPanel.StartPosition = FormStartPosition.CenterScreen
            m_PopUpPanel.ShowInTaskbar = False
            m_PopUpPanel.ShowIcon = False
            m_PopUpPanel.Text = "TM Menu"
            m_PopUpPanel.Hide()
            AddHandler RoughPumpControl2.TextChange, AddressOf RoughPump2TextChange
            AddHandler RoughPumpControl.TextChange, AddressOf RoughPump1TextChange

            m_LLACryoPopUpPanel = New CryoPopUpPanel
            m_LLACryoPopUpPanel.Name = "LLACryoPopUpPanel"
            m_LLACryoPopUpPanel.StartPosition = FormStartPosition.CenterScreen
            m_LLACryoPopUpPanel.ShowInTaskbar = False
            m_LLACryoPopUpPanel.ShowIcon = False
            m_LLACryoPopUpPanel.Text = "LLA Cryo Menu"
            m_LLACryoPopUpPanel.Hide()
            m_LLACryoPopUpPanel.PanelHandle = ConstEnum.Equipments.LoadLockA.ToString()
            m_LLACryoPopUpPanel.txtExtendedPurgeTime.SourceOfMessageBox = "CryoPopUpPanel"
            m_LLACryoPopUpPanel.txtPumpRestartDelay.SourceOfMessageBox = "CryoPopUpPanel"
            m_LLACryoPopUpPanel.txtRateOfRise.SourceOfMessageBox = "CryoPopUpPanel"
            m_LLACryoPopUpPanel.txtRoughToPressure.SourceOfMessageBox = "CryoPopUpPanel"
            m_LLACryoPopUpPanel.txtStartUpTemp.SourceOfMessageBox = "CryoPopUpPanel"
            m_LLACryoPopUpPanel.txtRepurgeCycles.SourceOfMessageBox = "CryoPopUpPanel"

            m_TMCryoPopUpPanel = New CryoPopUpPanel
            m_TMCryoPopUpPanel.Name = "TMCryoPopUpPanel"
            m_TMCryoPopUpPanel.StartPosition = FormStartPosition.CenterScreen
            m_TMCryoPopUpPanel.ShowInTaskbar = False
            m_TMCryoPopUpPanel.ShowIcon = False
            m_TMCryoPopUpPanel.Text = "TM Cryo Menu"
            m_TMCryoPopUpPanel.Hide()
            m_TMCryoPopUpPanel.PanelHandle = CASSETTESPANEL_STR
            m_TMCryoPopUpPanel.txtExtendedPurgeTime.SourceOfMessageBox = "CryoPopUpPanel"
            m_TMCryoPopUpPanel.txtPumpRestartDelay.SourceOfMessageBox = "CryoPopUpPanel"
            m_TMCryoPopUpPanel.txtRateOfRise.SourceOfMessageBox = "CryoPopUpPanel"
            m_TMCryoPopUpPanel.txtRoughToPressure.SourceOfMessageBox = "CryoPopUpPanel"
            m_TMCryoPopUpPanel.txtStartUpTemp.SourceOfMessageBox = "CryoPopUpPanel"
            m_TMCryoPopUpPanel.txtRepurgeCycles.SourceOfMessageBox = "CryoPopUpPanel"

            NewConvectronGaugeFrm()
            NewLLAConvectronGaugeFrm()
            NewRough1ConvectronGaugeFrm()
            NewRough2ConvectronGaugeFrm()
            NewTMFLConvectronGaugeFrm()
            NewLLAFLConvectronGaugeFrm()

            Me.SetStyle(ControlStyles.AllPaintingInWmPaint Or
            ControlStyles.OptimizedDoubleBuffer Or
            ControlStyles.DoubleBuffer, True)

            Gasline_TM_FV_N2.Status = BinaryStatusControl.DisplayStatus.On
            Gasline_LL_FV_N2.Status = BinaryStatusControl.DisplayStatus.On
            Gasline_LL_SV_N2.Status = BinaryStatusControl.DisplayStatus.On

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub InitializeShutterForPM_CX4()
        If RobotConfigurationValues.CHAMBER1_VISIBLE Then
            With CX_PM1
                .CX_Supported = PMControl.Support_CX.Support_CX4
                .PM_IN_SCREEN = PMControl.Support_Screen.TM
                If .PM_Type = TypeOfAVPChamber.PVD Then
                    .bicShutter.Visible = False
                End If
            End With
        End If
        If RobotConfigurationValues.CHAMBER2_VISIBLE Then
            With CX_PM2
                .CX_Supported = PMControl.Support_CX.Support_CX4
                .PM_IN_SCREEN = PMControl.Support_Screen.TM
                If .PM_Type = TypeOfAVPChamber.PVD Then
                    .bicShutter.Visible = False
                End If
            End With
        End If
        If RobotConfigurationValues.CHAMBER3_VISIBLE Then
            With CX_PM3
                .CX_Supported = PMControl.Support_CX.Support_CX4
                .PM_IN_SCREEN = PMControl.Support_Screen.TM
                If .PM_Type = TypeOfAVPChamber.PVD Then
                    .bicShutter.Visible = False
                End If
            End With
        End If
    End Sub

    Private Sub Initialize_Mesa_Hivac_Valve_CX4()
        Try
            ''MesaValves config
            MesaValveLLA.CX_Supported = PMControl.Support_CX.Support_CX4
            MesaValveLLA.DockPosition = SlitValve.SlitValvePositions.LLA
            MesaValveLLA.Location = New Point(458, 379) '417

            MesaValvePM1.CX_Supported = PMControl.Support_CX.Support_CX4
            MesaValvePM1.DockPosition = SlitValve.SlitValvePositions.PM1
            MesaValvePM1.Location = New Point(365, 253)

            MesaValvePM2.CX_Supported = PMControl.Support_CX.Support_CX4
            MesaValvePM2.DockPosition = SlitValve.SlitValvePositions.PM2
            MesaValvePM2.Location = New Point(458, 161)

            MesaValvePM3.CX_Supported = PMControl.Support_CX.Support_CX4
            MesaValvePM3.DockPosition = SlitValve.SlitValvePositions.PM3
            MesaValvePM3.Location = New Point(550, 254)

            'LL Hivac Valve
            HivacValveLLA.CX_Supported = PMControl.Support_CX.Support_CX4
            HivacValveLLA.DockPosition = SlitValve.SlitValvePositions.HivacLLA
            HivacValveLLA.Location = New Point(523, 428)

            HivacValveTM.CX_Supported = PMControl.Support_CX.Support_CX4
            HivacValveTM.DockPosition = SlitValve.SlitValvePositions.HivacTM
            'HivacValveTM.Location = New Point(548, 343)

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-06-16 </date>
    ''' </author>
    ''' <summary>
    ''' Arrange Vent gasline
    ''' </summary>
    Private Sub SetLLVentVisible()
        If Not RobotConfigurationValues.LL_SLOW_VENT_INSTALLED Then
            ValveLLASlowVent.Dispose()
            lblLLASlowVent.Dispose()
            lblSlowVentLineLLA.Dispose()
            Gasline_LL_SV_N2.Dispose()
            Gasline_LL_SlowVent.Dispose()
        End If
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-06-16 </date>
    ''' </author>
    ''' <summary>
    ''' Arrange Rough gasline
    ''' </summary>
    Private Sub SetLLRoughVisible()
        If Not RobotConfigurationValues.LL_SLOW_ROUGH_INSTALLED Then
            Gasline_LL_SlowRough.Dispose()
            ValveLLASlowRough.Dispose()
            lblLLASlowRough.Dispose()
            Gasline_LL_SR_1.Dispose()
            Gasline_LL_SR_21.Dispose()
            Gasline_LL_SR_221.Dispose()
            Gasline_LL_SR_222.Dispose()
        End If
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-06-16 </date>
    ''' </author>
    ''' <summary>
    ''' Arrange TurboPump/Cryo
    ''' </summary>
    Private Sub SetLLPumpVisible()
        crcLLTurbo.Visible = False
        Dim bTurboSerial As Boolean = False
        If RobotConfigurationValues.LLA_TURBO_VISIBLE AndAlso (RobotConfigurationValues.IS_LLATURBO_SERIAL OrElse RobotConfigurationValues.IS_LLATURBO_RSTi_SERIAL) Then
            bTurboSerial = True
        End If

        ctrLLATurboCom.Visible = bTurboSerial
        lblturboRampingPercent.Visible = bTurboSerial
        If RobotConfigurationValues.LLA_TURBO_VISIBLE Then 'using turbo
            ValveLLATurbo.Location = New Point(689, 439)
            btnTurboLLA.BringToFront()
            crcLLACryo.Visible = False
            PumpLLA.PumpType = PumpChamber.PumpTypes.Turbo

        ElseIf RobotConfigurationValues.LLA_CRYO_VISIBLE Then 'using cryo
            PumpLLA.PumpType = PumpChamber.PumpTypes.Cryo

            btnTurboLLA.Dispose()
            btnTurboRelayIndicator_LLA.Dispose()
            lblComunicationLED_TurboLLA.Dispose()
            ctrLLATurboCom.Dispose()
            Gasline_LL_Foreline.Dispose()
            txtTurboIGLLA.Dispose()
            Gasline_PressureLL_FL.Dispose()
            lblTurboForlineLLA.Dispose()
            ValveLLATurbo.Dispose()
            Gasline_LL_FL_1.Dispose()
            Gasline_LL_FL_21.Dispose()
            Gasline_LL_FL_221.Dispose()
            Gasline_LL_FL_222.Dispose()

        Else 'only rough valve
            btnTurboLLA.Dispose()
            btnTurboRelayIndicator_LLA.Dispose()
            lblComunicationLED_TurboLLA.Dispose()
            ctrLLATurboCom.Dispose()
            Gasline_LL_Foreline.Dispose()
            txtTurboIGLLA.Dispose()
            Gasline_PressureLL_FL.Dispose()
            lblTurboForlineLLA.Dispose()
            ValveLLATurbo.Dispose()
            Gasline_LL_FL_1.Dispose()
            Gasline_LL_FL_21.Dispose()
            Gasline_LL_FL_221.Dispose()
            Gasline_LL_FL_222.Dispose()
            HivacValveLLA.Dispose()
            PumpLLA.Dispose()
            crcLLACryo.Dispose()

        End If
    End Sub

    Private Sub Initialize_LoadLockA()
        Try
            '''Load Lock A
            LLALeg.Leg_In_Screen = PMControl.Support_Screen.TM
            LLALeg.LoadLockType = LoadLockLeg.Load_Lock_Type.Type_2
            LLALeg.LegStatus = BinaryStatusControl.DisplayStatus.Off
            LLALeg.EQ_LoadLock = Equipments.LoadLockA
            LLALeg.Location = New Point(456, 430)
            LLALeg.QuestionMark_Visible = False

            lccLoadLockA.Left = LLALeg.Left - (lccLoadLockA.Width - LLALeg.Width) / 2
            crcLLACryo.Left = lccLoadLockA.Left - crcLLACryo.Width - 3
            crcLLTurbo.Left = lccLoadLockA.Right + 3
            '' Algner
            If (Not RobotConfigurationValues.ALINER_VISIBLE) Then
                tabGroup.Controls.Remove(tabAligner)
                tabGroup.Controls.Remove(tabSelfAligner)
            End If
            SetLLVentVisible()
            SetLLRoughVisible()
            SetLLPumpVisible()

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub Initialize_Chamber()
        Try
            If AVPLib.RobotConfigurationValues.CHAMBER1_VISIBLE Then
                CX_PM1.CX_Supported = PMControl.Support_CX.Support_CX4
                CX_PM1.PM_IN_SCREEN = PMControl.Support_Screen.TM
                CX_PM1.ShowWafer_Border_ToEdit = False

                If RobotConfigurationValues.CHAMBER1_TYPE = SystemModule.ModuleType.IBE Then
                    CX_PM1.PM_Type = TypeOfAVPChamber.IBE

                ElseIf RobotConfigurationValues.CHAMBER1_TYPE = SystemModule.ModuleType.PVD Then
                    CX_PM1.PM_Type = TypeOfAVPChamber.PVD
                    CX_PM1.Location = New Point(163, 365)
                    CX_PM1.LabelDisconnect_Location = New Point(40, 43)

                ElseIf RobotConfigurationValues.CHAMBER1_TYPE = SystemModule.ModuleType.PVD4 Then
                    Dim ChamberModule As AVPLib.SystemModule =
                                                   AVPLib.ContainerData.GetRobotConfig(AVPLib.Utils.chamberName2ChamberID(RobotConfigurationValues.CHAMBER1_NAME))

                    CX_PM1.PM_Type = TypeOfAVPChamber.PVD4
                    CX_PM1.NumberOfWafer = ChamberModule.MaxNumberOfSlot
                ElseIf RobotConfigurationValues.CHAMBER1_TYPE = SystemModule.ModuleType.PVD5T Then
                    Dim ChamberModule As AVPLib.SystemModule =
                                                   AVPLib.ContainerData.GetRobotConfig(AVPLib.Utils.chamberName2ChamberID(RobotConfigurationValues.CHAMBER1_NAME))

                    CX_PM1.ChamberType = AllChamberType.PVD5T
                    CX_PM1.PM_Type = TypeOfAVPChamber.PVD5T
                    CX_PM1.NumberOfWafer = ChamberModule.MaxNumberOfSlot
                End If

                SetLocationControl(CX_PM1, DX, DY)
            End If

            If AVPLib.RobotConfigurationValues.CHAMBER2_VISIBLE Then
                CX_PM2.CX_Supported = PMControl.Support_CX.Support_CX4
                CX_PM2.PM_IN_SCREEN = PMControl.Support_Screen.TM
                CX_PM2.ShowWafer_Border_ToEdit = False


                If RobotConfigurationValues.CHAMBER2_TYPE = SystemModule.ModuleType.IBE Then
                    CX_PM2.PM_Type = TypeOfAVPChamber.IBE

                ElseIf RobotConfigurationValues.CHAMBER2_TYPE = SystemModule.ModuleType.PVD Then
                    CX_PM2.PM_Type = TypeOfAVPChamber.PVD
                    CX_PM2.Location = New Point(380, 144)
                    CX_PM2.LabelDisconnect_Location = New Point(10, 70)

                ElseIf RobotConfigurationValues.CHAMBER2_TYPE = SystemModule.ModuleType.PVD4 Then
                    Dim ChamberModule As AVPLib.SystemModule =
                                                   AVPLib.ContainerData.GetRobotConfig(AVPLib.Utils.chamberName2ChamberID(RobotConfigurationValues.CHAMBER2_NAME))
                    CX_PM2.PM_Type = TypeOfAVPChamber.PVD4
                    CX_PM2.NumberOfWafer = ChamberModule.MaxNumberOfSlot
                ElseIf RobotConfigurationValues.CHAMBER2_TYPE = SystemModule.ModuleType.PVD5T Then
                    Dim ChamberModule As AVPLib.SystemModule =
                                                   AVPLib.ContainerData.GetRobotConfig(AVPLib.Utils.chamberName2ChamberID(RobotConfigurationValues.CHAMBER2_NAME))
                    CX_PM2.ChamberType = AllChamberType.PVD5T
                    CX_PM2.PM_Type = TypeOfAVPChamber.PVD5T
                    CX_PM2.NumberOfWafer = ChamberModule.MaxNumberOfSlot

                End If

                SetLocationControl(CX_PM2, DX, DY)
            End If

            If AVPLib.RobotConfigurationValues.CHAMBER3_VISIBLE Then
                CX_PM3.CX_Supported = PMControl.Support_CX.Support_CX4
                CX_PM3.PM_IN_SCREEN = PMControl.Support_Screen.TM
                CX_PM3.ShowWafer_Border_ToEdit = False

                If RobotConfigurationValues.CHAMBER3_TYPE = SystemModule.ModuleType.IBE Then
                    CX_PM3.PM_Type = TypeOfAVPChamber.IBE

                ElseIf RobotConfigurationValues.CHAMBER3_TYPE = SystemModule.ModuleType.PVD Then
                    CX_PM3.PM_Type = TypeOfAVPChamber.PVD
                    CX_PM3.Location = New Point(516, 362)
                    CX_PM3.LabelDisconnect_Location = New Point(51, 43)

                ElseIf RobotConfigurationValues.CHAMBER3_TYPE = SystemModule.ModuleType.PVD4 Then
                    Dim ChamberModule As AVPLib.SystemModule =
                                                   AVPLib.ContainerData.GetRobotConfig(AVPLib.Utils.chamberName2ChamberID(RobotConfigurationValues.CHAMBER3_NAME))
                    CX_PM3.NumberOfWafer = ChamberModule.MaxNumberOfSlot
                    CX_PM3.PM_Type = TypeOfAVPChamber.PVD4
                ElseIf RobotConfigurationValues.CHAMBER3_TYPE = SystemModule.ModuleType.PVD5T Then
                    Dim ChamberModule As AVPLib.SystemModule =
                                                   AVPLib.ContainerData.GetRobotConfig(AVPLib.Utils.chamberName2ChamberID(RobotConfigurationValues.CHAMBER3_NAME))
                    CX_PM3.NumberOfWafer = ChamberModule.MaxNumberOfSlot
                    CX_PM3.ChamberType = AllChamberType.PVD5T
                    CX_PM3.PM_Type = TypeOfAVPChamber.PVD5T

                End If

                SetLocationControl(CX_PM3, DX, DY)
            End If
            AVPLib.Log.avpLogger.Error("Missing Load CX4 PM 1 2 3")
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Dy Do </name>
    '''    	<date> 2017-02-22 </date>
    ''' </author>
    ''' <summary>
    ''' Set location for IGCG Chamber
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetLocationControl(ByVal cxPM As PMControl, Optional ByVal dx As Integer = 0, Optional ByVal dy As Integer = 0)
        Try
            Utils.SetLocationPM(cxPM, dx, dy)

            Select Case cxPM.PM_Type
                Case TypeOfAVPChamber.PVD4
                    SetLocationPMPVD4(cxPM)
                Case TypeOfAVPChamber.IBE
                    SetLocationPMIBE(cxPM)
            End Select
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Dy Do </name>
    '''    	<date> 2017-02-22 </date>
    ''' </author>
    ''' <summary>
    ''' Set location for IGCG Chamber
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetLocationPMPVD4(ByVal pmCtrl As PMControl)

        With pmCtrl
            Select Case .DockPosition
                Case PMControl.ChamberDockPositions.PM1

                    lblPM1MotionStatus.Location = New Point(211, 185)
                    IgcgChamber1.Location = New Point(214, 155)

                Case PMControl.ChamberDockPositions.PM2

                    lblPM2MotionStatus.Location = New Point(264, 38)
                    IgcgChamber2.Location = New Point(270, 8)

                Case PMControl.ChamberDockPositions.PM3

                    lblPM3MotionStatus.Location = New Point(651, 185)
                    IgcgChamber3.Location = New Point(662, 155)

            End Select
        End With

    End Sub
    ''' <author>
    '''    	<name> Tinh Le </name>
    '''    	<date> 2021-10-28 </date>
    ''' </author>
    ''' <summary>
    ''' Set location for IGCG Chamber
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetLocationPMIBE(ByVal pmCtrl As PMControl)

        With pmCtrl
            Select Case .DockPosition
                'chamber 1
                Case PMControl.ChamberDockPositions.PM1
                    IgcgChamber1.Location = New Point(247, 176)
                    lblPM1MotionInitialize.Text = STR_MOTION_INITIALIZING
                    lblPM1MotionInitialize.Location = New Point(256, 207)
                    CX_PM1.LabelDisconnect_Location = New Point(90, 60)
                    'chamber 2
                Case PMControl.ChamberDockPositions.PM2
                    IgcgChamber2.Location = New Point(316, 10)
                    lblPM2MotionInitialize.Text = STR_MOTION_INITIALIZING
                    lblPM2MotionInitialize.Location = New Point(317, 43)
                    CX_PM2.LabelDisconnect_Location = New Point(67, 80)
                    'chamber 3
                Case PMControl.ChamberDockPositions.PM3
                    IgcgChamber3.Location = New Point(670, 176)
                    lblPM3MotionInitialize.Text = STR_MOTION_INITIALIZING
                    lblPM3MotionInitialize.Location = New Point(643, 207)
                    CX_PM3.LabelDisconnect_Location = New Point(40, 62)
            End Select
        End With

    End Sub
    Private Sub Initialize_Robot()
        Try
            ''robot body config
            Robot_Body.AVPStyle = AVPStyles.CX4
            Robot_Body.InScreen = AVPScreens.MaintenanceScreen
            Robot_Body.Location = New Point(415, 211) '423
            Robot_Body.SensorsInstalled = AVPLib.RobotConfigurationValues.ROBOT_SENSOR_INSTALLED

            If AVPLib.RobotConfigurationValues.ALINER_VISIBLE Then
                awcAligner.Location = New Point(482, 376)

            Else
                lblAlignerEECM.Visible = False
                lblAlignerEECA.Visible = False
                awcAligner.Visible = False
                lblAlignAngle.Visible = False
                Robot_Body.AlignerAtStation = RobotArmStations.Original
            End If

            RobotHand.Visible = True
            RobotHand.Location = New Point(301, 98)
            tabGroup.Top = TMCtl.Top

            '0007049: [KhoiHa- 08/22/2014][VCO19]User confused the current location of robot. Make different between RB and SP. Clear SP when user cli
            atwAutoTransferWafer.cboStationList.Items.Add("Select station...")

            atwAutoTransferWafer.cboStationList.Items.Add(STATION & RobotConfigurationValues.PM1_STATION_NO.ToString() & "(PM1)")
            atwAutoTransferWafer.cboStationList.Items.Add(STATION & RobotConfigurationValues.PM2_STATION_NO.ToString() & "(PM2)")
            atwAutoTransferWafer.cboStationList.Items.Add(STATION & RobotConfigurationValues.PM3_STATION_NO.ToString() & "(PM3)")

            If (RobotConfigurationValues.ALINER_VISIBLE) Then
                atwAutoTransferWafer.cboStationList.Items.Add(STATION & RobotConfigurationValues.ALIGNER_STATION_NO.ToString() & "(ALIGNER)") '9
                atwAutoTransferWafer.cboStationList.Items.Add(STATION & RobotConfigurationValues.ALIGNER_DELTA_PICK_STATION_NO.ToString() & "(ADP)") '8
            End If

            atwAutoTransferWafer.cboStationList.Items.Add(STATION & RobotConfigurationValues.LLA_STATION_NO.ToString() & "(LLA)")
            saSelfAligner.cboListStation.Items.Add(ConstEnum.LLA_STR)

            For i As Integer = 0 To RobotConfigurationValues.CHAMBERX_VISIBLE.Count - 1
                If RobotConfigurationValues.CHAMBERX_VISIBLE(i) = Boolean.TrueString Then
                    ' Self-Aligner
                    saSelfAligner.cboListStation.Items.Add("PM" & (i + 1).ToString())
                End If
            Next

            If (RobotConfigurationValues.ALINER_VISIBLE) Then
                saSelfAligner.cboListStation.Items.Add(Equipments.Aligner.ToString().ToUpper())
            End If

            AVPLib.Log.avpLogger.Error("Missing Load CX4 ROBOT")
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-06-16 </date>
    ''' </author>
    ''' <summary>
    ''' Arrange pump location
    ''' </summary>
    Private Sub SetRoughPumpVisible()

        If AVPLib.RobotConfigurationValues.SHARED_MP_WITH_PM Then
            RoughPumpControl.Cursor = Cursors.Default
            RoughPumpControl2.Cursor = Cursors.Default
        End If

        ''Rough pump 1, 2 install
        If AVPLib.RobotConfigurationValues.ROUGH_PUMP2_INSTALLED AndAlso AVPLib.RobotConfigurationValues.ROUGH_PUMP1_INSTALLED Then

            Dim objRoughPumpTM As AVPLib.DataManagerment.RoughPumpMachine =
                            AVPLib.DataManagerment.EquipmentManager.GetRoughPumpMachine(AVPLib.ConstEnum.Equipments.CassettesModule.ToString)

            ''TM use rough pump 2, LL use rough pump 1
            If objRoughPumpTM IsNot Nothing AndAlso objRoughPumpTM.Name = "RoughPumpMachine2" Then
                RoughPumpControl2.Location = New Point(1000, 628)
                RoughPumpControl.Location = New Point(836, 628)
                btnRelayIndicatorPump2.Location = New Point(1006, 634)
                btnRelayIndicatorPump1.Location = New Point(842, 634)
                btnCommunicationMP2.Location = New Point(1090, 663)
                btnCommunicationMP1.Location = New Point(926, 663)
            Else
                RoughPumpControl.Location = New Point(1000, 628)
                RoughPumpControl2.Location = New Point(836, 628)
                btnRelayIndicatorPump1.Location = New Point(1006, 634)
                btnRelayIndicatorPump2.Location = New Point(842, 634)

                btnCommunicationMP1.Location = New Point(1090, 663)
                btnCommunicationMP2.Location = New Point(926, 663)
            End If

            RoughPumpControl.BringToFront()
            RoughPumpControl2.BringToFront()

            lblRoughLineTM.Text = "TM's Pump"

            Gasline_LL_Pump_PartEnd.Top = Gasline_LL_Pump_PartEnd.Top + Gasline_LL_Pump_Part4.Height
            Gasline_LL_Pump_Part4.Dispose()
            Gasline_LL_FL_21.Dispose()
            Gasline_LL_FL_221.Dispose()
            Gasline_LL_FL_222.Dispose()
            Gasline_LL_FR_221.Dispose()
            Gasline_LL_FR_222.Dispose()
            Gasline_LL_SR_221.Dispose()
            Gasline_LL_SR_222.Dispose()

            If Not RobotConfigurationValues.LLA_TURBO_VISIBLE Then
                Gasline_LL_Pump_PartEnd.Top = Gasline_LL_Pump_Part3.Bottom - Gasline_LL_Pump_PartEnd.Height - 1
                Gasline_LL_Pump_Part3.Dispose()
                Gasline_LL_FR_21.Dispose()
            End If

        ElseIf AVPLib.RobotConfigurationValues.ROUGH_PUMP2_INSTALLED = False AndAlso AVPLib.RobotConfigurationValues.ROUGH_PUMP1_INSTALLED Then
            RoughPumpControl.Location = New Point(1000, 628)
            RoughPumpControl.BringToFront()
            btnRelayIndicatorPump1.Location = New Point(1006, 634)
            lblRoughLineTM.Text = "TM's Pump"
            RoughPumpControl2.Visible = False
            btnRelayIndicatorPump2.Visible = False
            lblRoughPumpInUse_2.Visible = False
            lblPump2.Visible = False
            btnCommunicationMP2.Visible = False
            lblWaitingMPOnLL.Visible = False

            'btnCommunicationMP1.Location = New Point(926, 663)

            Gasline_LL_Pump_Part1.Dispose()
            Gasline_LL_Pump_Part2.Dispose()
            Gasline_LL_Pump_Part3.Dispose()
            Gasline_LL_Pump_Part4.Dispose()
            Gasline_LL_Pump_PartEnd.Dispose()
            Gasline_LL_FL_21.Dispose()
            Gasline_LL_FR_21.Dispose()
            Gasline_LL_SR_21.Dispose()

            If Not AVPLib.RobotConfigurationValues.LLA_TURBO_VISIBLE Then
                Gasline_LL_FL_1.Visible = False
                Gasline_LL_FL_221.Visible = False
            End If

        Else 'LL Pump Installed
            RoughPumpControl2.Location = New Point(836, 628)
            RoughPumpControl2.BringToFront()
            btnRelayIndicatorPump2.Location = New Point(842, 634)
            lblRoughLineTM.Text = "LL's Pump"
            RoughPumpControl.Visible = False
            btnRelayIndicatorPump1.Visible = False
            lblRoughPumpInUse.Visible = False
            lblPump1.Visible = False
            lblWaitingMPOnTM.Visible = False
            btnCommunicationMP1.Visible = False

            Gasline_TM_Pump_PartEnd.Dispose()
            Gasline_TM_Pump_Part4.Dispose()
            Gasline_TM_Pump_Part3.Dispose()
            Gasline_TM_Pump_Part2.Dispose()
            Gasline_TM_Pump_Part1.Dispose()

            Gasline_LL_FL_221.Dispose()
            Gasline_LL_FL_222.Dispose()
            Gasline_LL_FR_221.Dispose()
            Gasline_LL_FR_222.Dispose()
            Gasline_LL_SR_221.Dispose()
            Gasline_LL_SR_222.Dispose()
            Gasline_TM_FL_FR.Dispose()
        End If
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-06-16 </date>
    ''' </author>
    ''' <summary>
    ''' Arrange TurboPump/Cryo for TM
    ''' </summary>
    Private Sub SetTMPumpVisible()
        Dim bTurboSerial As Boolean = False
        If RobotConfigurationValues.TMTURBO_VISIBLE AndAlso (RobotConfigurationValues.IS_TMTURBO_SERIAL OrElse RobotConfigurationValues.IS_TMTURBO_RSTi_SERIAL) Then
            bTurboSerial = True
        End If

        ctrTMTurboCom.Visible = bTurboSerial
        lblTMturboRampingPercent.Visible = bTurboSerial

        If RobotConfigurationValues.TMTURBO_VISIBLE Then
            crcTMCryo.Visible = False
            PumpTM.PumpType = PumpChamber.PumpTypes.Turbo
            SetTMWaterPumpPosition()

        Else
            If RobotConfigurationValues.TMCRYO_VISIBLE Then
                PumpTM.PumpType = PumpChamber.PumpTypes.Cryo
                'crcTMTurbo.Visible = False
                btnTurboRelayIndicator_LLA.Location = New Point(595, 420)

            Else
                btnTurboRelayIndicator_LLA.Location = New Point(594, 420)

                'crcTMTurbo.Dispose()
                crcTMCryo.Dispose()

                PumpTM.Dispose()
                HivacValveTM.Dispose()
            End If
            lblTMturboRampingPercent.Visible = False
            btnTurboTM.Dispose()
            ValveTMTurbo.Dispose()
            lblTurboForlineTM.Dispose()
            txtTurboIGTM.Dispose()
            btnTurboRelayIndicator_TM.Dispose()
            lblComunicationLED_TurboTM.Dispose()
            ctrTMTurboCom.Dispose()
            Gasline_PressureTM_FL.Dispose()

            Gasline_TM_Foreline.Dispose()
            Gasline_TM_FL_1.Dispose()
            Gasline_TM_FL_2.Dispose()
            Gasline_TM_FL_3.Dispose()
            Gasline_TM_FL_4.Dispose()
            Gasline_TM_FL_End1.Dispose()
            Gasline_TM_FL_End2.Dispose()
        End If
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-01 </date>
    ''' </author>
    ''' <summary>
    ''' Arrange TM Roughline
    ''' </summary>
    Private Sub SetTMRoughLineVisible()
        If AVPLib.RobotConfigurationValues.TMTURBO_VISIBLE Then
            Gasline_TM_FL_End1.Location = Gasline_TM_FL_3.Location
            Gasline_TM_FL_3.Visible = False
            Gasline_TM_FL_4.Visible = False
            Gasline_TM_FL_End2.Visible = False
        Else
            If AVPLib.RobotConfigurationValues.ROUGH_PUMP2_INSTALLED AndAlso AVPLib.RobotConfigurationValues.ROUGH_PUMP1_INSTALLED Then
                Gasline_TM_FL_End1.Visible = False
                Gasline_TM_FL_3.Visible = False
                Gasline_TM_FL_4.Visible = False
            Else
                Gasline_TM_FL_End2.Visible = False
                If AVPLib.RobotConfigurationValues.LLA_TURBO_VISIBLE Then
                    Gasline_TM_FL_End1.Location = Gasline_TM_FL_4.Location
                    Gasline_TM_FL_4.Visible = False
                End If
            End If
        End If
        If Gasline_TM_FL_4.Visible OrElse Gasline_TM_FL_3.Visible = False Then
            Gasline_TM_FL_End1.OnImage0 = AVP_Robot_Project.My.Resources.Resources.CX4_TM_RoughLine_Out_PartEnd_On
            Gasline_TM_FL_End1.OnImage1 = AVP_Robot_Project.My.Resources.Resources.CX4_TM_RoughLine_Out_PartEnd_On_1
        Else
            Gasline_TM_FL_End1.OnImage0 = AVP_Robot_Project.My.Resources.Resources.CX4_TM_RoughLine_Out_PartEnd_On_1
            Gasline_TM_FL_End1.OnImage1 = AVP_Robot_Project.My.Resources.Resources.CX4_TM_RoughLine_Out_PartEnd_On
        End If
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2021-11-04 </date>
    ''' </author>
    ''' <summary>
    ''' Update TM WaterPump panel position
    ''' </summary>
    Private Sub SetTMWaterPumpPosition()
        Try
            Dim bottom As Integer = TMCtl.Bottom

            If crcTMCryo.Visible Then
                bottom = crcTMCryo.Bottom
            End If

            crcTMWaterPump.Top = bottom + 2
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub Initialize_CX4()
        AVPLib.Log.avpLogger.Error("Missing Load Component for CX4 Cassettes ")
        RobotHand.AVPStyle = AVPControls.AVPDataLib.AVPStyles.CX4
        lblPM1MotionInitialize.Visible = False
        lblPM2MotionInitialize.Visible = False
        lblPM3MotionInitialize.Visible = False

        lccLoadLockA.SemiautoTransferWaferPanel = stwSemiautoTransferWafer
        lccLoadLockA.LockName = "A"

        m_intClickedChamber = CLICKEDNOWHERE
        stwSemiautoTransferWafer.Width = 280
        atwAutoTransferWafer.Width = 280
        sccSerialCommand.Width = 280

        Me.SetVisibleMenuItemMechineTool(True, False, True, False, True, False)
        Me.SetVisibleMenuItemLeftTool(True, False, True, False, True, False)
        Me.SetVisibleMenuItemRightTool(True, False, True, False, True, False)
        Me.SetEnableMenuItemMechineTool(True, False, True, False, True, False)
        Me.SetEnableMenuItemLeftTool(True, False, True, False, True, False)
        Me.SetEnableMenuItemRightTool(True, False, True, False, True, False)

        Initialize_Mesa_Hivac_Valve_CX4()
        Initialize_Chamber()
        Initialize_Robot()

        '''Button tool
        btnLeftTool.Location = New Point(422, 430)
        btnRightTool.Location = New Point(548, 430)
        btnMechineTool.Location = New Point(426, 384)

        '''TM Valves
        ValveVent.Location = New Point(242, 414)
        lblFastVentValve.Location = New Point(ValveVent.Left - 10, ValveVent.Top - lblFastVentValve.Height)
        lblVentLineTM.Location = New Point(195, 421)

        ValveRough.Location = New Point(728, 392)
        lblFastRoughtValve.Location = New Point(ValveRough.Left - 10, ValveRough.Top - lblFastRoughtValve.Height)

        ValveTMTurbo.Location = New Point(718, 89)
        lblTurboForlineTM.Location = New Point(ValveTMTurbo.Left - 7, ValveTMTurbo.Top - lblTurboForlineTM.Height)

        ValveVent.BringToFront()

        SetRoughPumpVisible()
        SetTMPumpVisible()
        SetTMRoughLineVisible()

        Initialize_LoadLockA()

        lblLLANameOfSequenceRunning.Location = New Point(850, 354)
        lblTMNameOfSequenceRunning.Location = New Point(850, 316)
        lblFlashing.Location = New Point(850, 237)

        Dim objRoughPumpTM As AVPLib.DataManagerment.RoughPumpMachine =
                            AVPLib.DataManagerment.EquipmentManager.GetRoughPumpMachine(AVPLib.ConstEnum.Equipments.CassettesModule.ToString)

        ''TM use rough pump 2, LL use rough pump 1
        If objRoughPumpTM IsNot Nothing AndAlso objRoughPumpTM.Name = "RoughPumpMachine2" AndAlso
                                    AVPLib.RobotConfigurationValues.ROUGH_PUMP1_INSTALLED Then
            lblRoughPumpInUse_2.Location = New Point(1000, 701)
            lblRoughPumpInUse.Location = New Point(825, 701)
        Else
            lblRoughPumpInUse.Location = New Point(1000, 701)
            lblRoughPumpInUse_2.Location = New Point(825, 701)
        End If

        lblRoughPumpInUse.BringToFront()
        lblRoughPumpInUse_2.BringToFront()

        InitializeShutterForPM_CX4()
        HivacValveLLA.Refresh()

        If (TMCtl.HivacOpenButton.Status = ThirdStatusControl.DisplayStatus.Off) Then
            HivacValveTM.Status = BinaryStatusControl.DisplayStatus.Off
        ElseIf (TMCtl.HivacOpenButton.Status = ThirdStatusControl.DisplayStatus.On) Then
            HivacValveTM.Status = BinaryStatusControl.DisplayStatus.On
        Else
            HivacValveTM.Status = BinaryStatusControl.DisplayStatus.Unknown
        End If

        If RobotConfigurationValues.LLA_CRYO_VISIBLE Then
            lblLLAFastRough.Location = New Point(ValveLLAFastRough.Left - 11, ValveLLAFastRough.Top - lblLLAFastRough.Height)
        End If
    End Sub


#End Region

#Region "Public Methods"
    ''' <author>
    '''    	<name> Khiet Tran </name>
    '''    	<date> 20098-10-29</date>
    ''' </author>
    ''' <summary>
    ''' Get ClickedPosition
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Property ClickedInChamber() As Integer
        Get
            Return m_intClickedChamber
        End Get
        Set(ByVal value As Integer)
            m_intClickedChamber = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-11</date>
    ''' </author>
    ''' <summary>
    ''' Check Permission
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CheckPermission()
        If AVPLib.ContainerData.Permission(PERMISSION_001) Then
            ActiveForm()
        Else
            InactiveForm()
        End If
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-03-13</date>
    ''' </author>
    ''' <summary>
    ''' Set Enable button when LL is in online mode
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetTMOnline(ByVal mTMOnline As Boolean)
        AVPLib.Log.guiLogger.Info("Enter SetTMOnline")
        Try

            Me.ISTM_ONLINE = mTMOnline
            If AVPLib.ContainerData.Permission(PERMISSION_001) = False Then
                If mTMOnline = False Then
                    Exit Sub
                End If
            End If
            Me.crcTMCryo.IsOnline = mTMOnline
            Me.crcTMWaterPump.IsOnline = mTMOnline
            Me.TMCtl.IsOnline = mTMOnline
            Me.stwSemiautoTransferWafer.btnStart.Enabled = Not (mTMOnline)
            Me.atwAutoTransferWafer.IsOnline = mTMOnline
            Me.saSelfAligner.IsOnline = mTMOnline
            Me.ctwcCycleWafer.IsOnline = mTMOnline
            sccSerialCommand.IsOnline = mTMOnline
            cmsChamber.Enabled = Not (mTMOnline)
            HivacValveTM.Enabled = Not (mTMOnline)
            MesaValveLLA.Enabled = Not (mTMOnline)
            MesaValvePM1.Enabled = Not (mTMOnline)
            MesaValvePM2.Enabled = Not (mTMOnline)
            MesaValvePM3.Enabled = Not (mTMOnline)
            Me.btnCancelMove.Status = IIf(mTMOnline, SL_CustomButton.DisplayStatus.On, SL_CustomButton.DisplayStatus.Off)
            Me.btnCancelMove.Clickable = Not mTMOnline
            Me.btnTMProtectedMode.Status = IIf(mTMOnline, SL_CustomButton.DisplayStatus.Unknow, SL_CustomButton.DisplayStatus.Off)
            Me.btnTMProtectedMode.Clickable = Not mTMOnline
            m_TMCryoPopUpPanel.DeviceOnline = mTMOnline
            SetRoughPumpOnline()
            TMAlignerControl.usrOperations.IsOnline = mTMOnline
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave SetTMOnline")
    End Sub
    ''' <author>
    '''    	<name> Van Le </name>
    '''    	<date> 2012-06-5</date>
    ''' </author>
    ''' <summary>
    ''' Set RoughPump is in online mode
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetRoughPumpOnline()
        AVPLib.Log.guiLogger.Info("Enter SetRoughPumpOnline")
        Try
            Dim objRoughPump1 As DataManagerment.RoughPumpMachine =
                                DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.RoughPumpMachine1.ToString)
            Dim objRoughPump2 As DataManagerment.RoughPumpMachine =
                                DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.RoughPumpMachine2.ToString)
            If (objRoughPump1 IsNot Nothing) Then
                If (objRoughPump1.IsUsed(ConstEnum.Equipments.CassettesModule.ToString) AndAlso ISTM_ONLINE) OrElse
                                (objRoughPump1.IsUsed(ConstEnum.Equipments.LoadLockA.ToString) AndAlso ISLLA_ONLINE) Then
                    RoughPumpControl.Enabled = False
                Else
                    RoughPumpControl.Enabled = True
                End If
            End If
            If (objRoughPump2 IsNot Nothing) Then
                If (objRoughPump2.IsUsed(ConstEnum.Equipments.CassettesModule) AndAlso ISTM_ONLINE) OrElse
                                (objRoughPump2.IsUsed(ConstEnum.Equipments.LoadLockA.ToString) AndAlso ISLLA_ONLINE) Then
                    RoughPumpControl2.Enabled = False
                Else
                    RoughPumpControl2.Enabled = True
                End If
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave SetRoughPumpOnline")
    End Sub

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-03-13</date>
    ''' </author>
    ''' <summary>
    ''' Set Enable button when TM IG degas complete.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Enable_TMIGDegas()
        AVPLib.Log.guiLogger.Info("Enter Enable_TMIGDegas")
        Try
            m_PopUpPanel.btnTMIGDegas.Enabled = Utils.IsAllowEnable(ISTM_ONLINE)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave Enable_TMIGDegas")
    End Sub

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-03-13</date>
    ''' </author>
    ''' <summary>
    ''' Set Enable button when LLA IG degas complete.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Enable_LLAIGDegas()
        AVPLib.Log.guiLogger.Info("Enter Enable_LLAIGDegas")
        Try
            m_PopUpPanel.btnLLAIGDegas.Enabled = Utils.IsAllowEnable(ISLLA_ONLINE)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave Enable_LLAIGDegas")
    End Sub

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-03-13</date>
    ''' </author>
    ''' <summary>
    ''' Set Enable button when LL is in online mode
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetLLAOnline(ByVal mLLAOnline As Boolean)
        AVPLib.Log.guiLogger.Info("Enter SetLLAOnline")
        Try
            ISLLA_ONLINE = (mLLAOnline)
            If AVPLib.ContainerData.Permission(PERMISSION_001) = False Then
                If mLLAOnline = False Then
                    Exit Sub
                End If
            End If
            If lccLoadLockA.Is_Connected = False Then
                Exit Try
            End If
            Me.lccLoadLockA.IsLLOnline = mLLAOnline
            Me.crcLLACryo.IsOnline = mLLAOnline

            m_LLACryoPopUpPanel.DeviceOnline = mLLAOnline
            SetRoughPumpOnline()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave SetLLAOnline")
    End Sub

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-03-13</date>
    ''' </author>
    ''' <summary>
    ''' Set Enable/Disable button when LL is working 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetLLIsWorking(ByVal lccLoadLock As AVP_Robot_Project.LockCassetteControl, ByVal mIsWorking As Boolean)
        AVPLib.Log.guiLogger.Info("Enter SetLLIsWorking")
        Try
            If (ISLLA_ONLINE = False And lccLoadLock.Name = LOCKCASSETTEA) Then
                'if menu Online on LLA is Enable (not Online) and LoadLockA is clicked-> change it
                If lccLoadLock.btnHome.Enabled = (mIsWorking) Then
                    lccLoadLock.IsCassetteInUsed = mIsWorking

                    With ContainerForm.ProcessPanel.lpcLoadLockA
                        If .btnLoad.Enabled = (mIsWorking) AndAlso
                                .btnUnload.Enabled = (mIsWorking) AndAlso
                                         Me.btnUpdateManualTransfer.Tag <> "On" AndAlso
                                         (.btnStart.Text = "START") AndAlso
                                         AVPLib.ContainerData.Permission(PERMISSION_001) Then
                            .EnableForm(Not mIsWorking)
                        End If
                    End With

                    'lccLoadLock.btnReset.Enabled = Not (mIsWorking)
                End If

            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave SetLLIsWorking")
    End Sub
#End Region

#Region "Protected method"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-11</date>
    ''' </author>
    ''' <summary>
    ''' Create status tree to manage status of all objects inside
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub CreateStatusTree()
        Try
            Dim sbcAlignerWafer As New StatusWaferAlignerControl(awcAligner)
            Dim srrRoundRectangleStatus1 As New StatusSlitValveControl(MesaValveLLA)
            Dim srrRoundRectangleStatus2 As New StatusSlitValveControl(MesaValvePM1)
            Dim srrRoundRectangleStatus3 As New StatusSlitValveControl(MesaValvePM2)
            Dim srrRoundRectangleStatus4 As New StatusSlitValveControl(MesaValvePM3)

            Dim srrRoundRectangleStatus8 As New StatusSlitValveControl(HivacValveLLA)
            Dim srrRoundRectangleStatus11 As New StatusSlitValveControl(HivacValveTM)
            Dim srbRobot As New StatusRobot(m_Robot)
            Dim sbtLLAIgStatus As New StatusIGCGButton(LLAIgStatus)

            ''control from Transparent
            Dim sbcValveControl1 As New StatusBinaryStatusControl(ValveVent)
            Dim sbcValveControl2 As New StatusBinaryStatusControl(ValveLLASlowVent)
            Dim sbcValveControl3 As New StatusBinaryStatusControl(ValveLLAFastVent)

            Dim sbcValveControl6 As New StatusBinaryStatusControl(ValveRough)

            Dim sbcValveControl9 As New StatusBinaryStatusControl(ValveLLASlowRough)
            Dim sbcValveControl10 As New StatusBinaryStatusControl(ValveLLAFastRough)
            Dim sbcRoughPumpControl As New StatusBinaryStatusControl(RoughPumpControl)
            Dim sbcRoughPumpControl2 As New StatusBinaryStatusControl(RoughPumpControl2)
            Dim stmMechineOnline As New StatusToolStripMenuItem(mnuMechineOnline, cmsMechineTool)
            Dim stmMechineStopPumpDown As New StatusToolStripMenuItem(mnuMechineStopPumpDown, cmsMechineTool)
            Dim stmMechineStopVent As New StatusToolStripMenuItem(mnuMechineStopVent, cmsMechineTool)

            Dim stmLeftOnline As New StatusToolStripMenuItem(mnuLeftOnline, cmsLeftTool)
            Dim stmLeftStopPumpDown As New StatusToolStripMenuItem(mnuLeftStopPumpDown, cmsLeftTool)
            Dim stmLeftStopVent As New StatusToolStripMenuItem(mnuLeftStopVent, cmsLeftTool)

            Dim stmRightOnline As New StatusToolStripMenuItem(mnuRightOnline, cmsRightTool)
            Dim stmRightStopPumpDown As New StatusToolStripMenuItem(mnuRightStopPumpDown, cmsRightTool)
            Dim stmRightStopVent As New StatusToolStripMenuItem(mnuRightStopVent, cmsRightTool)

            Dim ctxMenuStripLLA As New StatusContextMenuStrip(cmsLeftTool)
            Dim ctxMenuStripTM As New StatusContextMenuStrip(cmsMechineTool)
            'Turbo button
            Dim stbTMTurbo As New TurboStatusButton(btnTurboTM)
            Dim stbLLATurbo As New TurboStatusButton(btnTurboLLA)
            Dim stbCompleteProcess As New StatusProcessCompleteChime(btnFakeProcessCompleteChime)
            'Turbo valve
            Dim sbcValveTurboTM As New StatusBinaryStatusControl(ValveTMTurbo)
            Dim sbcValveTurboLLA As New StatusBinaryStatusControl(ValveLLATurbo)

            'Turbo IG Pressure
            Dim stxTurboIGTMPress As New StatusTextBox(txtTurboIGTM)
            Dim stxTurboIGLLAPress As New StatusTextBox(txtTurboIGLLA)

            'Rough Pump pressure at device
            Dim stxRoughLineTM As New StatusTextBox(txtRoughLineTM)
            ' Status object for the Button Machine Tool.
            Dim stImgBtnMachineOnline As New StatusImageButton(btnMechineTool)
            Dim stbTMProtectedMode As New SL_StatusButton(btnTMProtectedMode)
            Dim stbCancelMove As New SL_StatusButton(btnCancelMove)

            stImgBtnMachineOnline.ImageToolOnline = AVP_Robot_Project.AVPRobotMain.ImgLisTooltipMachine.Images.Item(1)
            stImgBtnMachineOnline.ImageToolOffline = AVP_Robot_Project.AVPRobotMain.ImgLisTooltipMachine.Images.Item(0)

            Dim stImgBtnLeftTool As New StatusImageButton(btnLeftTool)
            stImgBtnLeftTool.ImageToolOnline = AVP_Robot_Project.AVPRobotMain.ImgLisTooltipMachine.Images.Item(1)
            stImgBtnLeftTool.ImageToolOffline = AVP_Robot_Project.AVPRobotMain.ImgLisTooltipMachine.Images.Item(0)

            Dim stImgBtnRightTool As New StatusImageButton(btnRightTool)
            stImgBtnRightTool.ImageToolOnline = AVP_Robot_Project.AVPRobotMain.ImgLisTooltipMachine.Images.Item(1)
            stImgBtnRightTool.ImageToolOffline = AVP_Robot_Project.AVPRobotMain.ImgLisTooltipMachine.Images.Item(0)

            Dim stErrorMessageBox As New ErrorMessageBox("MessageBox")
            Dim srbStatus As New StatusLabel(lblStatusText)
            Dim srbCoreMessageBoxStatus As New StatusLabel(lblCoreMessageBoxText)
            Dim stbUpdateManualTransfer As New StatusButton(btnUpdateManualTransfer)

            Dim stlAlignerEECA As New StatusLabel(lblAlignerEECA)
            Dim stlAlignerEECM As New StatusLabel(lblAlignerEECM)

            Dim slbRoughPump As New StatusLabel(lblRoughPumpInUse)
            Dim slbRoughPump2 As New StatusLabel(lblRoughPumpInUse_2)
            Dim sclComunicationLED_TurboPumpLLA As New StatusColorLabel(lblComunicationLED_TurboLLA)
            Dim sclComunicationLED_TurboPumpTM As New StatusColorLabel(lblComunicationLED_TurboTM)

            sclComunicationLED_TurboPumpLLA.CommStateChanged = New CommunicationState(AddressOf UpdateLLAComStatus)
            sclComunicationLED_TurboPumpTM.CommStateChanged = New CommunicationState(AddressOf UpdateTMComStatus)

            Dim sclComunicationLED_LLPumpSerial As New StatusColorLabel(lblComunicationLED_LLpump)
            Dim sclComunicationLED_TMpumpSerial As New StatusColorLabel(lblComunicationLED_TMPump)
            sclComunicationLED_LLPumpSerial.CommStateChanged = New CommunicationState(AddressOf UpdateLLPumpSerial)
            sclComunicationLED_TMpumpSerial.CommStateChanged = New CommunicationState(AddressOf UpdateTMPumpSerial)

            Dim stb_TurboRelayLLA As New StatusTurboRelayIndicator(btnTurboRelayIndicator_LLA)
            Dim stb_TurboRelayTM As New StatusTurboRelayIndicator(btnTurboRelayIndicator_TM)
            Dim stb_Pump1Relay As New StatusTurboRelayIndicator(btnRelayIndicatorPump1)
            Dim stb_Pump2Relay As New StatusTurboRelayIndicator(btnRelayIndicatorPump2)

            Dim stSystemSetupTestingSetup As New StatusButton(btnSystemSetupTestingSetup)
            Dim btnCycleATM As New StatusButtonProcessStartATM(Me.btnCycleATM)

            'Status sequence running
            Dim slbTMSequenceRunningStatusText As New SL_StatusLabel(lblTMNameOfSequenceRunning)
            Dim slbLLASequenceRunningStatusText As New SL_StatusLabel(lblLLANameOfSequenceRunning)
            Dim sfbFlashingLabel As New StatusFlashingLabel(lblFlashing)
            Dim slbPM1Motion As New StatusMotionLabel(lblPM1MotionStatus)
            Dim slbPM2Motion As New StatusMotionLabel(lblPM2MotionStatus)
            Dim slbPM3Motion As New StatusMotionLabel(lblPM3MotionStatus)

            'Switch filament
            Dim sbtLLASwitchIgFilament As New StatusTextBox(LLASwitchIGFilament)
            Dim sbtTMSwitchIgFilament As New StatusTextBox(TMSwitchIGFilament)

            Dim slbTurboRampingPercent As New StatusLabel(lblturboRampingPercent)
            Dim slbTurboRampingTM As New StatusLabel(lblTMturboRampingPercent)
            Dim slblWaitingMPOnLL As New StatusLabel(lblWaitingMPOnLL)
            Dim slblWaitingMPOnTM As New StatusLabel(lblWaitingMPOnTM)

            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(slbPM1Motion)
            m_stoStatusObject.AddChild(slbPM2Motion)
            m_stoStatusObject.AddChild(slbPM3Motion)
            m_stoStatusObject.AddChild(srrRoundRectangleStatus11)
            m_stoStatusObject.AddChild(sclComunicationLED_TurboPumpLLA)
            m_stoStatusObject.AddChild(sclComunicationLED_TurboPumpTM)

            m_stoStatusObject.AddChild(sclComunicationLED_LLPumpSerial)
            m_stoStatusObject.AddChild(sclComunicationLED_TMpumpSerial)
            m_stoStatusObject.AddChild(stb_TurboRelayLLA)
            m_stoStatusObject.AddChild(stb_TurboRelayTM)
            m_stoStatusObject.AddChild(stb_Pump1Relay)
            m_stoStatusObject.AddChild(stb_Pump2Relay)
            m_stoStatusObject.AddChild(slbTurboRampingPercent)
            m_stoStatusObject.AddChild(slbTurboRampingTM)

            m_stoStatusObject.AddChild(slblWaitingMPOnLL)
            m_stoStatusObject.AddChild(slblWaitingMPOnTM)

            m_stoStatusObject.AddChild(sbtLLASwitchIgFilament)
            m_stoStatusObject.AddChild(sbtTMSwitchIgFilament)

            m_stoStatusObject.AddChild(sbtLLAIgStatus)
            m_stoStatusObject.AddChild(m_PopUpPanel.Status)
            m_stoStatusObject.AddChild(m_LLACryoPopUpPanel.Status)
            m_stoStatusObject.AddChild(m_TMCryoPopUpPanel.Status)
            m_stoStatusObject.AddChild(TMAlignerControl.Status)

            ''import control from TransferPanel
            'm_stoStatusObject.AddChild(sbsHivacButton)
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
            ' m_stoStatusObject.AddChild(pnlRobotArmStatus.Status)
            m_stoStatusObject.AddChild(ctwcCycleWafer.Status)
            m_stoStatusObject.AddChild(LLALeg.Status)

            m_stoStatusObject.AddChild(sbcValveControl1)
            m_stoStatusObject.AddChild(sbcValveControl2)
            m_stoStatusObject.AddChild(sbcValveControl3)

            m_stoStatusObject.AddChild(sbcValveControl6)

            m_stoStatusObject.AddChild(sbcValveControl9)
            m_stoStatusObject.AddChild(sbcValveControl10)
            m_stoStatusObject.AddChild(sbcRoughPumpControl)
            m_stoStatusObject.AddChild(sbcRoughPumpControl2)
            m_stoStatusObject.AddChild(crcTMCryo.Status)
            'm_stoStatusObject.AddChild(crcTMTurbo.Status)
            m_stoStatusObject.AddChild(crcTMWaterPump.Status)
            m_stoStatusObject.AddChild(crcLLACryo.Status)
            m_stoStatusObject.AddChild(crcLLTurbo.Status)
            m_stoStatusObject.AddChild(TMCtl.Status)
            ''
            m_stoStatusObject.AddChild(ctxMenuStripLLA)
            m_stoStatusObject.AddChild(ctxMenuStripTM)
            m_stoStatusObject.AddChild(stmMechineOnline)
            m_stoStatusObject.AddChild(stmMechineStopPumpDown)
            m_stoStatusObject.AddChild(stmMechineStopVent)
            m_stoStatusObject.AddChild(stmLeftOnline)
            m_stoStatusObject.AddChild(stmLeftStopPumpDown)
            m_stoStatusObject.AddChild(stmLeftStopVent)
            m_stoStatusObject.AddChild(stmRightOnline)
            m_stoStatusObject.AddChild(stmRightStopPumpDown)
            m_stoStatusObject.AddChild(stmRightStopVent)
            m_stoStatusObject.AddChild(stImgBtnMachineOnline)
            m_stoStatusObject.AddChild(stImgBtnRightTool)
            m_stoStatusObject.AddChild(stImgBtnLeftTool)

            m_stoStatusObject.AddChild(stErrorMessageBox)
            m_stoStatusObject.AddChild(srbStatus)
            m_stoStatusObject.AddChild(srbCoreMessageBoxStatus)
            m_stoStatusObject.AddChild(stbUpdateManualTransfer)

            m_stoStatusObject.AddChild(stlAlignerEECA)
            m_stoStatusObject.AddChild(stlAlignerEECM)
            m_stoStatusObject.AddChild(btnCycleATM)

            ''end of import


            m_stoStatusObject.AddChild(CX_PM1.Status)
            m_stoStatusObject.AddChild(CX_PM2.Status)
            m_stoStatusObject.AddChild(CX_PM3.Status)


            m_stoStatusObject.AddChild(sbcAlignerWafer)
            m_stoStatusObject.AddChild(srrRoundRectangleStatus1)
            m_stoStatusObject.AddChild(srrRoundRectangleStatus2)
            m_stoStatusObject.AddChild(srrRoundRectangleStatus3)
            m_stoStatusObject.AddChild(srrRoundRectangleStatus4)


            m_stoStatusObject.AddChild(srrRoundRectangleStatus8)

            m_stoStatusObject.AddChild(IgcgChamber1.Status)
            m_stoStatusObject.AddChild(IgcgChamber2.Status)
            m_stoStatusObject.AddChild(IgcgChamber3.Status)

            m_stoStatusObject.AddChild(lccLoadLockA.Status)
            m_stoStatusObject.AddChild(stwSemiautoTransferWafer.Status)
            m_stoStatusObject.AddChild(sccSerialCommand.Status)
            m_stoStatusObject.AddChild(srbRobot)

            m_stoStatusObject.AddChild(slbRoughPump)
            m_stoStatusObject.AddChild(slbRoughPump2)
            m_stoStatusObject.AddChild(Me.atwAutoTransferWafer.Status)
            m_stoStatusObject.AddChild(Me.saSelfAligner.Status)
            'Turbo button
            m_stoStatusObject.AddChild(stbTMTurbo)
            m_stoStatusObject.AddChild(stbLLATurbo)

            If (AVPLib.ContainerDAO.ProcessChimeInstalled) Then
                m_stoStatusObject.AddChild(stbCompleteProcess)
            End If
            m_stoStatusObject.AddChild(sbcValveTurboTM)
            m_stoStatusObject.AddChild(sbcValveTurboLLA)

            m_stoStatusObject.AddChild(stxTurboIGTMPress)
            m_stoStatusObject.AddChild(stxTurboIGLLAPress)

            m_stoStatusObject.AddChild(stxRoughLineTM)
            m_stoStatusObject.AddChild(stbTMProtectedMode)
            m_stoStatusObject.AddChild(stbCancelMove)

            m_stoStatusObject.AddChild(slbTMSequenceRunningStatusText)
            m_stoStatusObject.AddChild(slbLLASequenceRunningStatusText)
            m_stoStatusObject.AddChild(sfbFlashingLabel)

            m_stoStatusObject.AddChild(m_CGGaugesFrm.Status)
            m_stoStatusObject.AddChild(m_LLACGGaugesFrm.Status)
            m_stoStatusObject.AddChild(m_Rough1CGGaugesFrm.Status)
            m_stoStatusObject.AddChild(m_Rough2CGGaugesFrm.Status)

            m_stoStatusObject.AddChild(m_LLAFLCGGaugesFrm.Status)
            m_stoStatusObject.AddChild(m_TMFLCGGaugesFrm.Status)

            m_stoStatusObject.AddChild(stSystemSetupTestingSetup)

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Private method"
    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2015-07-08 </date>
    ''' </author>
    ''' <summary>
    ''' Change mouse icon when active or inactive form
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetCursor()
        awcAligner.Cursor = IIf(awcAligner.Enabled, Cursors.Hand, Cursors.Default)

    End Sub

    ''' <author>
    '''    	<name> Kiet Tran </name>
    '''    	<date> 2018-12-20 </date>
    ''' </author>
    ''' <summary>
    ''' EnableChkDisableChekingSensor
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub EnableChkDisableChekingSensor()
        Try
            If RobotConfigurationValues.ROBOT_VERSION_CONFIG <= ROBOT_VERSION_7_1 Then
                Me.atwAutoTransferWafer.chkDisableChekingSensor.Visible = True
            Else
                Me.atwAutoTransferWafer.chkDisableChekingSensor.Visible = False
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-11</date>
    ''' </author>
    ''' <summary>
    ''' Active Form
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ActiveForm()
        Try
            Me.RobotHand.Enabled = True
            Me.awcAligner.Enabled = True
            Me.CX_PM1.Enabled = True
            Me.CX_PM2.Enabled = True
            Me.CX_PM3.Enabled = True

            Me.btnTool.Enabled = True
            Me.IgcgChamber1.ActiveForm(True)
            Me.IgcgChamber2.ActiveForm(True)
            Me.IgcgChamber3.ActiveForm(True)

            Me.lccLoadLockA.ActiveForm(True)
            Me.stwSemiautoTransferWafer.Enabled = True

            Me.atwAutoTransferWafer.Enabled = True
            Me.TMAlignerControl.Enabled = RobotConfigurationValues.ALINER_VISIBLE
            Me.saSelfAligner.Enabled = RobotConfigurationValues.ALINER_VISIBLE
            Me.ctwcCycleWafer.Enabled = True
            Me.sccSerialCommand.Enabled = True
            Me.LLALeg.Enabled = True

            Me.TMCtl.ActiveForm(True)
            Me.MesaValvePM1.Enabled = True
            Me.MesaValvePM2.Enabled = True
            Me.MesaValvePM3.Enabled = True

            Me.MesaValveLLA.Enabled = True
            Me.HivacValveLLA.Enabled = True
            Me.HivacValveTM.Enabled = True
            Me.ibsHivacButton.Enabled = True
            Me.ValveVent.Enabled = True
            Me.ValveLLASlowVent.Enabled = True
            Me.ValveLLAFastVent.Enabled = True

            Me.ValveRough.Enabled = True

            Me.ValveLLASlowRough.Enabled = True
            Me.ValveLLAFastRough.Enabled = True
            Me.btnMechineTool.Enabled = True
            Me.btnLeftTool.Enabled = True
            Me.btnRightTool.Enabled = True
            Me.crcTMCryo.ActiveForm(True)
            Me.crcTMWaterPump.ActiveForm(True)
            Me.crcLLACryo.ActiveForm(True)
            Me.crcLLTurbo.ActiveForm(True)
            'Me.crcTMTurbo.ActiveForm(True)
            'Me.btnTMProtectedMode.Enabled = True
            'Me.btnCancelMove.Enabled = True
            Me.ValveTMTurbo.Enabled = True

            Me.ValveLLATurbo.Enabled = True
            Me.btnTurboLLA.Enabled = True
            Me.btnTurboTM.Enabled = True
            'Me.btnCancelMove.Status = SL_CustomButton.DisplayStatus.Off

            MechineValveStatus(Not ISTM_ONLINE)
            LeftValveStatus(Not ISLLA_ONLINE)

            SetTMOnline(ISTM_ONLINE)
            SetLLAOnline(ISLLA_ONLINE)

            IsAllowActionOnTM = IsAllowEnable(ISTM_ONLINE)
            IsAllowActionOnLLA = IsAllowEnable(ISLLA_ONLINE)
            RoughPumpControl2.Enabled = True
            RoughPumpControl.Enabled = True
            SetCursor()
            txtTurboIGTM.Cursor = Cursors.Hand
            txtTurboIGLLA.Cursor = Cursors.Hand
            EnableChkDisableChekingSensor()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-11</date>
    ''' </author>
    ''' <summary>
    ''' Inactive Form
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InactiveForm()
        Try
            Me.RobotHand.Enabled = False
            Me.awcAligner.Enabled = False
            Me.CX_PM1.Enabled = False
            Me.CX_PM2.Enabled = False
            Me.CX_PM3.Enabled = False

            Me.btnTool.Enabled = False
            Me.IgcgChamber1.ActiveForm(False)
            Me.IgcgChamber2.ActiveForm(False)
            Me.IgcgChamber3.ActiveForm(False)

            Me.lccLoadLockA.ActiveForm(False)
            Me.stwSemiautoTransferWafer.Enabled = False
            Me.atwAutoTransferWafer.Enabled = False
            Me.saSelfAligner.Enabled = False
            Me.TMAlignerControl.Enabled = False
            Me.ctwcCycleWafer.Enabled = False
            Me.sccSerialCommand.Enabled = False
            Me.LLALeg.Enabled = False

            Me.TMCtl.ActiveForm(False)
            Me.MesaValvePM1.Enabled = False
            Me.MesaValvePM2.Enabled = False
            Me.MesaValvePM3.Enabled = False

            Me.MesaValveLLA.Enabled = False
            Me.HivacValveLLA.Enabled = False
            Me.HivacValveTM.Enabled = False
            Me.ibsHivacButton.Enabled = False
            Me.ValveVent.Enabled = False
            Me.ValveLLASlowVent.Enabled = False
            Me.ValveLLAFastVent.Enabled = False

            Me.ValveRough.Enabled = False

            Me.ValveLLASlowRough.Enabled = False
            Me.ValveLLAFastRough.Enabled = False
            Me.btnMechineTool.Enabled = False
            Me.btnLeftTool.Enabled = False
            Me.btnRightTool.Enabled = False
            Me.crcTMCryo.ActiveForm(False)
            Me.crcTMWaterPump.ActiveForm(False)
            Me.crcLLACryo.ActiveForm(False)
            Me.crcLLTurbo.ActiveForm(False)
            'Me.crcTMTurbo.ActiveForm(False)

            Me.btnCancelMove.Status = SL_CustomButton.DisplayStatus.On
            Me.btnCancelMove.Clickable = False
            Me.btnTMProtectedMode.Status = SL_CustomButton.DisplayStatus.Unknow
            Me.btnTMProtectedMode.Clickable = False
            Me.ValveTMTurbo.Enabled = False

            Me.ValveLLATurbo.Enabled = False
            Me.btnTurboLLA.Enabled = False
            Me.btnTurboTM.Enabled = False

            IsAllowActionOnTM = False
            IsAllowActionOnLLA = False
            RoughPumpControl2.Enabled = False
            RoughPumpControl.Enabled = False
            'Me.btnCancelMove.Status = SL_CustomButton.DisplayStatus.Off
            SetCursor()
            txtTurboIGTM.Cursor = Cursors.Default
            txtTurboIGLLA.Cursor = Cursors.Default
            btnRelayIndicatorPump1.Cursor = Cursors.Default
            btnRelayIndicatorPump2.Cursor = Cursors.Default
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-13</date>
    ''' </author>
    ''' <summary>
    ''' Display context menu when user click on circle plasma of Chamber
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShowContextMenuClickOnChamber(ByVal sender As Object)
        Try
            'Dim cpcTemp As CirclePlasmaControl
            'cpcTemp = CType(sender, CirclePlasmaControl)
            'Dim pos As New System.Drawing.Point(cpcTemp.Location)
            'pos.Y += cpcTemp.Height
            'pos = Me.PointToScreen(pos)
            'cmsChamber.Show(pos)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-24</date>
    ''' </author>
    ''' <summary>
    ''' Display context menu when user click on aligner
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShowContextMenuClickOnAligner()
        Try
            Dim pos As New System.Drawing.Point(awcAligner.Location)
            pos.Y += awcAligner.Height
            pos = Me.PointToScreen(pos)
            cmsChamber.Show(pos)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-24</date>
    ''' </author>
    ''' <summary>
    ''' Display context menu when user click on Robot
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShowContextMenuClickOnRobot()
        Try
            Dim pos As Point
            If Me.RobotHand.WaferStatus <> WaferStatuses.NONE Then
                pos = Me.RobotHand.WaferCenterLocation
                Dim d As Integer = CInt(WAFER_DIAMETER_CX4 / 2.0F - 2)
                pos.Offset(-d, d)
                pos.Offset(Me.RobotHand.Location)
                pos = Me.PointToScreen(pos)
            Else
                pos = Windows.Forms.Cursor.Position
            End If

            cmsChamber.Show(pos)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-13</date>
    ''' </author>
    ''' <summary>
    ''' Enable menu context item 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetChamberMenuContextEnable(ByVal blnCreateWafer As Boolean,
                                            ByVal blnDeleteWafer As Boolean,
                                            ByVal blnSrcForMove As Boolean,
                                            ByVal blnDstForMove As Boolean,
                                            ByVal blnUpdateWaferInfo As Boolean)
        Try
            Dim hasSelfAlign As Boolean = IIf(RobotConfigurationValues.ALINER_VISIBLE, ContainerForm.CassettesPanel.saSelfAligner.btnSelfAligner.Enabled, True)
            mnuCreateWafer.Enabled = IIf(ContainerForm.CassettesPanel.ISTM_ONLINE, False, blnCreateWafer)
            mnuDeleteWafer.Enabled = IIf(ContainerForm.CassettesPanel.ISTM_ONLINE, False, blnDeleteWafer)
            mnuSrcForMove.Enabled = IIf(ContainerForm.CassettesPanel.ISTM_ONLINE, False, (blnSrcForMove AndAlso hasSelfAlign))
            mnuDstForMove.Enabled = IIf(ContainerForm.CassettesPanel.ISTM_ONLINE, False, (blnDstForMove AndAlso hasSelfAlign))
            mnuUpdateWaferInfoToolStripMenuItem.Enabled = IIf(ContainerForm.CassettesPanel.ISTM_ONLINE, False, blnUpdateWaferInfo)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-13</date>
    ''' </author>
    ''' <summary>
    ''' Prepare context menu before showing
    ''' </summary>
    ''' <param name="ticWaferInside"></param>
    ''' <remarks></remarks>
    Private Sub PrepareChamberMenu(ByVal ticWaferInside As AVPWaferControl)
        Try
            If ticWaferInside.WaferStatus <> WaferStatuses.NONE Then
                SetChamberMenuContextEnable(False, True, True, False, True)
            Else
                SetChamberMenuContextEnable(True, False, False, True, False)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-13</date>
    ''' </author>
    ''' <summary>
    ''' Prepare context menu before showing
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub PrepareAlignerMenu()
        Try
            If (awcAligner.Status = BinaryStatusControl.DisplayStatus.On) Then
                SetChamberMenuContextEnable(False, True, True, False, True)
            ElseIf (awcAligner.Status = BinaryStatusControl.DisplayStatus.Off) Then
                SetChamberMenuContextEnable(True, False, False, True, False)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub

    Private Sub PrepareRobotMenu()
        Try
            ' Have to get the wafer status from equipment status
            ' Not only on GUI
            Dim Robot As AVPLib.DataManagerment.Robot = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Robot.ToString())

            'If (awcRobot.Status = BinaryStatusControl.DisplayStatus.On) Then
            If (Robot.WaferInside = AVPLib.DataManagerment.Equipment.WorkingStatuses.On) Then
                ' if not in home position, disable create and delte menu item
                ' if user wants to create/delete wafer --> must be home position
                'If (Robot.CurrentPosition <> AVPLib.ConstEnum.Positions.Original) Then
                '    SetChamberMenuContextEnable(False, True, True, False)
                'Else
                SetChamberMenuContextEnable(False, True, True, False, True)
                'End If
            Else
                SetChamberMenuContextEnable(True, False, False, True, False)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-13</date>
    ''' </author>
    ''' <summary>
    ''' Create string for source or destination text box of semi auto transfer
    ''' </summary>
    ''' <remarks></remarks>
    Public Function GenerateSrcOrDst(Optional ByVal ClickedChamber As Integer = 0) As String
        Dim strResult As String = ""
        Try
            If Not ClickedChamber = 0 Then
                m_intClickedChamber = ClickedChamber
            End If
            If (m_intClickedChamber = CLICKEDALIGNER) Then
                strResult = "Aligner"
            ElseIf (m_intClickedChamber = CLICKEDROBOT) Then
                strResult = "Robot Arm"
            Else
                strResult = "Chamber " + m_intClickedChamber.ToString()
                strResult = AVPLib.Utils.chamberID2ChamberName(strResult)
            End If
            'btnCancleMove_OnChange()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return strResult
    End Function

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-24</date>
    ''' </author>
    ''' <summary>
    ''' Set wafer inside
    ''' </summary>
    ''' <param name="blnWaferVisible"></param>
    ''' <param name="enmPlasmaStatus"></param>
    ''' <remarks></remarks>
    Public Sub SetWaferInside(ByVal strWaferStatusAction As String,
                               ByVal enmPlasmaStatus As BinaryStatusControl.DisplayStatus,
                               ByVal waferInfo As AVPWaferInfo, Optional ByVal Click_On_Chamber As Integer = 0,
                               Optional ByVal PMSlot As Integer = 1)
        Try
            Dim chamberObj As DataManagerment.Chamber = Nothing
            If Not (Click_On_Chamber = 0) Then
                m_intClickedChamber = Click_On_Chamber
            End If
            Dim strWaferID As String = String.Empty
            Dim waferStatus As enumWaferStatus = enumWaferStatus.eWaferNone
            If (waferInfo IsNot Nothing) Then
                waferStatus = waferInfo.WaferStatus
                strWaferID = waferInfo.WaferID.ToString()
            End If

            Select Case m_intClickedChamber
                Case CLICKEDCHAMBER1
                    chamberObj = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber1.ToString())
                    If Me.stwSemiautoTransferWafer.txtSource.Text.IndexOf(CHAMBER1) > -1 Then
                        Me.stwSemiautoTransferWafer.txtSource.Clear()
                    ElseIf Me.stwSemiautoTransferWafer.txtDestination.Text.IndexOf(CHAMBER1) > -1 Then
                        Me.stwSemiautoTransferWafer.txtDestination.Clear()
                    End If
                    If enmPlasmaStatus = BinaryStatusControl.DisplayStatus.On Then
                        chamberObj.SetWaferInfo(waferInfo, PMSlot)
                    ElseIf enmPlasmaStatus = BinaryStatusControl.DisplayStatus.Off Then
                        If Not CheckToDeleteWaferInChamber(chamberObj, PMSlot) Then
                            Exit Try
                        End If

                        Dim waferInfor As AVPLib.AVPWaferInfo = chamberObj.GetWaferInfo(PMSlot)
                        If Business.AVPCore.Instance().JobManager() IsNot Nothing AndAlso waferInfor IsNot Nothing Then
                            Dim proJob As Business.AVPProcessJob = Business.AVPCore.Instance().JobManager().GetProcessJob(waferInfor.WaferID)
                            If proJob IsNot Nothing AndAlso proJob.IsAutoTransfer Then
                                Utils.ShowAVPMessageBox("Can't delete wafer " & waferInfor.WaferID & ". Scheduler is running.", ConstEnum.STR_AVP, MessageBoxIcon.Error, MessageBoxButtons.OK)
                                Exit Try
                            End If
                            strWaferID = waferInfor.WaferID.ToString
                        End If

                        waferInfo = Nothing
                        chamberObj.SetWaferInfo(waferInfo, PMSlot)
                        If chamberObj.IsEquipmentFree Then
                            ' Update PM State to IDLE
                            AVPLib.Utils.SetPMStatus(EnumChamberState.IDLE.ToString(), ConstEnum.Equipments.Chamber1.ToString())
                        End If

                    End If
                    Me.m_stoStatusObject.RequestStatus(WAFER_INSIDE_CHAMBER1, enmPlasmaStatus.ToString() + " " + PMSlot.ToString)

                Case CLICKEDCHAMBER2
                    If Me.stwSemiautoTransferWafer.txtSource.Text.IndexOf(CHAMBER2) > -1 Then
                        Me.stwSemiautoTransferWafer.txtSource.Clear()
                    ElseIf Me.stwSemiautoTransferWafer.txtDestination.Text.IndexOf(CHAMBER2) > -1 Then
                        Me.stwSemiautoTransferWafer.txtDestination.Clear()
                    End If

                    chamberObj = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber2.ToString())
                    If enmPlasmaStatus = BinaryStatusControl.DisplayStatus.On Then
                        chamberObj.SetWaferInfo(waferInfo, PMSlot)
                    ElseIf enmPlasmaStatus = BinaryStatusControl.DisplayStatus.Off Then
                        If Not CheckToDeleteWaferInChamber(chamberObj, PMSlot) Then
                            Exit Try
                        End If

                        Dim waferInfor As AVPLib.AVPWaferInfo = chamberObj.GetWaferInfo(PMSlot)
                        If Business.AVPCore.Instance().JobManager() IsNot Nothing AndAlso waferInfor IsNot Nothing Then
                            Dim proJob As Business.AVPProcessJob = Business.AVPCore.Instance().JobManager().GetProcessJob(waferInfor.WaferID)
                            If proJob IsNot Nothing AndAlso proJob.IsAutoTransfer Then
                                Utils.ShowAVPMessageBox("Can't delete wafer " & waferInfor.WaferID & ". Scheduler is running.", ConstEnum.STR_AVP, MessageBoxIcon.Error, MessageBoxButtons.OK)
                                Exit Try
                            End If
                            strWaferID = waferInfor.WaferID.ToString
                        End If

                        waferInfo = Nothing
                        chamberObj.SetWaferInfo(waferInfo, PMSlot)
                        If chamberObj.IsEquipmentFree Then
                            ' Update PM State to IDLE
                            AVPLib.Utils.SetPMStatus(EnumChamberState.IDLE.ToString(), ConstEnum.Equipments.Chamber2.ToString())
                        End If
                    End If
                    Me.m_stoStatusObject.RequestStatus(WAFER_INSIDE_CHAMBER2, enmPlasmaStatus.ToString() + " " + PMSlot.ToString)

                Case CLICKEDCHAMBER3
                    If Me.stwSemiautoTransferWafer.txtSource.Text.IndexOf(CHAMBER3) > -1 Then
                        Me.stwSemiautoTransferWafer.txtSource.Clear()
                    ElseIf Me.stwSemiautoTransferWafer.txtDestination.Text.IndexOf(CHAMBER3) > -1 Then
                        Me.stwSemiautoTransferWafer.txtDestination.Clear()
                    End If

                    chamberObj = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber3.ToString())
                    If enmPlasmaStatus = BinaryStatusControl.DisplayStatus.On Then
                        chamberObj.SetWaferInfo(waferInfo, PMSlot)
                    ElseIf enmPlasmaStatus = BinaryStatusControl.DisplayStatus.Off Then
                        If Not CheckToDeleteWaferInChamber(chamberObj, PMSlot) Then
                            Exit Try
                        End If
                        Dim waferInfor As AVPLib.AVPWaferInfo = chamberObj.GetWaferInfo(PMSlot)
                        If Business.AVPCore.Instance().JobManager() IsNot Nothing AndAlso waferInfor IsNot Nothing Then
                            Dim proJob As Business.AVPProcessJob = Business.AVPCore.Instance().JobManager().GetProcessJob(waferInfor.WaferID)
                            If proJob IsNot Nothing AndAlso proJob.IsAutoTransfer Then
                                Utils.ShowAVPMessageBox("Can't delete wafer " & waferInfor.WaferID & ". Scheduler is running.", ConstEnum.STR_AVP, MessageBoxIcon.Error, MessageBoxButtons.OK)
                                Exit Try
                            End If
                            strWaferID = waferInfor.WaferID.ToString
                        End If

                        waferInfo = Nothing
                        chamberObj.SetWaferInfo(waferInfo, PMSlot)
                        If chamberObj.IsEquipmentFree Then
                            ' Update PM State to IDLE
                            AVPLib.Utils.SetPMStatus(EnumChamberState.IDLE.ToString(), ConstEnum.Equipments.Chamber3.ToString())
                        End If
                    End If
                    Me.m_stoStatusObject.RequestStatus(WAFER_INSIDE_CHAMBER3, enmPlasmaStatus.ToString() + " " + PMSlot.ToString)

            End Select
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                                   AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                   ConstantAndEnum.TM_SCREEN & " - " & strWaferStatusAction & " Wafer " & strWaferID & " inside PM" + m_intClickedChamber.ToString())
            'send status to equiment
            Dim equipment As AVPLib.DataManagerment.Equipment = Nothing
            equipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Chamber & Click_On_Chamber)
            If equipment Is Nothing Or equipment.GetWaferInfo(PMSlot) Is Nothing Then
                Exit Sub
            End If
            Dim chamberConfig As SystemModule = AVPLib.ContainerData.GetRobotConfig(equipment.Name)
            If (chamberConfig.Type = AVPLib.SystemModule.ModuleType.IBE) Then
                Business.IBEUtility.SetWaferStatusToIBE(equipment.Name, equipment.GetWaferInfo(PMSlot).WaferStatus)
            ElseIf (chamberConfig.Type = AVPLib.SystemModule.ModuleType.PVD) Then
                Business.PVDUtility.SetWaferStatusToPVD(equipment.Name, equipment.GetWaferInfo(PMSlot).WaferStatus)
            ElseIf (chamberConfig.Type = AVPLib.SystemModule.ModuleType.PVD4) Then
                Business.CoronaUtility.SetWaferStatusToCorona(equipment.Name, waferStatus)
            ElseIf (chamberConfig.Type = AVPLib.SystemModule.ModuleType.PVD5T) Then
                Business.PVD5TUtility.SetWaferStatusToCorona(equipment.Name, waferStatus)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Function CheckToDeleteWaferInChamber(ByVal chamberObj As DataManagerment.Chamber, ByVal PMSlot As Integer) As Boolean
        Dim bRes As Boolean = True
        Try
            Dim objLoadLockACtrl As Business.LoadLockController = Nothing
            objLoadLockACtrl = Business.ControllerManager.GetController(ConstEnum.Equipments.LoadLockA.ToString())

            Dim objCtrlJobA As Business.AVPControlJob = Nothing
            objCtrlJobA = Business.AVPCore.Instance().JobManager().GetControlJob(objLoadLockACtrl.CtrlJobId)
            If objCtrlJobA Is Nothing Then
                If chamberObj.IsEquipmentFreeExceptSpecificIndex(PMSlot) Then
                    chamberObj.OperationStatus = DataManagerment.Equipment.OperationStatuses.READY
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return bRes
    End Function

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-10-11</date>
    ''' </author>
    ''' <summary>
    ''' Show or visible chamber based on configuration file
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadRobotConfig()
        'lblRoughPumpInUse.Location = New Point(RoughPumpControl.Left - 10, RoughPumpControl.Top + RoughPumpControl.Height + 10)
        'btnTMProtectedMode.Location = New Point(tabGroup.Right - btnTMProtectedMode.Width, tabGroup.Top + tabGroup.Height + 10)
        'btnCancelMove.Location = New Point(btnTMProtectedMode.Location.X, btnTMProtectedMode.Location.Y + btnTMProtectedMode.Height + 6)
        lccLoadLockA.NumSlot = AVPLib.RobotConfigurationValues.LOADLOCKA_SLOTS

        ''base on Harmer button 
        'lccLoadLockA.Left = btnMechineTool.Left - lccLoadLockA.Width
        'crcLLACryo.Left = lccLoadLockA.Left - crcLLACryo.Width - 6 '(lccLoadLockA.NumSlot Mod 12) * 10 - 20
        'lccLoadLockB.Left = btnMechineTool.Left + btnMechineTool.Width + 20
        'crcLLBCryo.Left = lccLoadLockB.Left + lccLoadLockB.Width + 6
        ' pnlRobotArmStatus.Top = lblRoughPumpInUse.Top + lblRoughPumpInUse.Height + 10
        'pnlRobotArmStatus.Size = New Size(206, 32)

        Me.PanelStyle = CX_Style.CX4
        Initialize_CX4()


        If atwAutoTransferWafer.cboStationList.Items.Count > 1 Then
            atwAutoTransferWafer.cboStationList.Sorted = True
            atwAutoTransferWafer.cboStationList.SelectedIndex = 0
        End If

        If saSelfAligner.cboListStation.Items.Count > 0 Then
            saSelfAligner.cboListStation.Sorted = True
            saSelfAligner.cboListStation.SelectedIndex = 0
        End If

        IgcgChamber1.Text = AVPLib.RobotConfigurationValues.CHAMBER1_NAME
        IgcgChamber2.Text = AVPLib.RobotConfigurationValues.CHAMBER2_NAME
        IgcgChamber3.Text = AVPLib.RobotConfigurationValues.CHAMBER3_NAME


        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-03-22</date>
        crcTMWaterPump.Visible = AVPLib.RobotConfigurationValues.TMWATERPUM_VISIBLE
        btnCommunicationMP2.Visible = AVPLib.RobotConfigurationValues.MPUMP2_SERIAL_VISIBLE
        btnCommunicationMP1.Visible = AVPLib.RobotConfigurationValues.MPUMP1_SERIAL_VISIBLE

        btnCommunicationMP1.BringToFront()
        btnCommunicationMP2.BringToFront()
        'If (AVPLib.RobotConfigurationValues.LOADLOCKB_VISIBLE = False) Then
        btnRightTool.Visible = False
        ' End If

        '#07/26/2011 
        '#-AVP->TM.  LLB menu still available when not installed.
        '#Begin fix:
        PopUpPanel.ConfigShowGUI()
        '#End fix.

        If AVPLib.RobotConfigurationValues.CHAMBER1_VISIBLE = False Then
            CX_PM1.Visible = False
            Robot_Body.PM1Installed = False
            IgcgChamber1.Visible = False
            MesaValvePM1.Status = BinaryStatusControl.DisplayStatus.Off
        End If

        If AVPLib.RobotConfigurationValues.CHAMBER2_VISIBLE = False Then
            CX_PM2.Visible = False
            Robot_Body.PM2Installed = False
            IgcgChamber2.Visible = False
            MesaValvePM2.Status = BinaryStatusControl.DisplayStatus.Off
        End If

        If AVPLib.RobotConfigurationValues.CHAMBER3_VISIBLE = False Then
            CX_PM3.Visible = False
            Robot_Body.PM3Installed = False
            IgcgChamber3.Visible = False
            MesaValvePM3.Status = BinaryStatusControl.DisplayStatus.Off
        End If

        clearStatusTimer.Enabled = False

        Utils.SetConfigRobotStation(Me.RobotHand)
    End Sub

    Public Sub NewRough1ConvectronGaugeFrm()
        m_Rough1CGGaugesFrm = New CGGaugesFrm(False, True, False)
        m_Rough1CGGaugesFrm.Name = RoughPumpControl.Name & AVPLib.ConstEnum.CG_IG_FORM
        m_Rough1CGGaugesFrm.MessageTitle = AVPLib.ConstEnum.MECHANICAL_PUMP
        m_Rough1CGGaugesFrm.StartPosition = FormStartPosition.CenterScreen
        m_Rough1CGGaugesFrm.ShowInTaskbar = False
        m_Rough1CGGaugesFrm.ShowIcon = False
        m_Rough1CGGaugesFrm.Text = AVPLib.ConstEnum.ROUGH_PUMP
        m_Rough1CGGaugesFrm.PumpStatus = IIf(RoughPumpControl.Status = BinaryStatusControl.DisplayStatus.On, Equipment.WorkingStatuses.On, Equipment.WorkingStatuses.Off)
        m_Rough1CGGaugesFrm.MessageReleaseRoughPump = m_strMessageReleaseRoughPump1
        m_Rough1CGGaugesFrm.Hide()

    End Sub

    Public Sub NewRough2ConvectronGaugeFrm()
        m_Rough2CGGaugesFrm = New CGGaugesFrm(False, True, False)
        m_Rough2CGGaugesFrm.Name = RoughPumpControl2.Name & AVPLib.ConstEnum.CG_IG_FORM
        m_Rough2CGGaugesFrm.MessageTitle = AVPLib.ConstEnum.MECHANICAL_PUMP
        m_Rough2CGGaugesFrm.StartPosition = FormStartPosition.CenterScreen
        m_Rough2CGGaugesFrm.ShowInTaskbar = False
        m_Rough2CGGaugesFrm.ShowIcon = False
        m_Rough2CGGaugesFrm.Text = AVPLib.ConstEnum.ROUGH_PUMP
        m_Rough2CGGaugesFrm.PumpStatus = IIf(RoughPumpControl2.Status = BinaryStatusControl.DisplayStatus.On, Equipment.WorkingStatuses.On, Equipment.WorkingStatuses.Off)
        m_Rough2CGGaugesFrm.MessageReleaseRoughPump = m_strMessageReleaseRoughPump2
        m_Rough2CGGaugesFrm.Hide()

    End Sub

    Public Sub NewLLAConvectronGaugeFrm()
        Dim strEquipmentName As String = AVPLib.ConstEnum.Equipments.LoadLockA.ToString()
        Dim eqLL As LoadLock = AVPLib.DataManagerment.EquipmentManager.GetEquipment(strEquipmentName)
        Dim bIGInstalled As Boolean = False
        If eqLL IsNot Nothing Then
            bIGInstalled = eqLL.IsIGInstalled
        End If
        Dim bVacVisible As Boolean = RobotConfigurationValues.LLA_CRYO_VISIBLE Or RobotConfigurationValues.LLA_TURBO_VISIBLE
        m_LLACGGaugesFrm = New CGGaugesFrm(bIGInstalled, False, bVacVisible, bIGInstalled)
        m_LLACGGaugesFrm.Text = "LLA"
        m_LLACGGaugesFrm.MessageTitle = "LLA"
        m_LLACGGaugesFrm.Name = "LLA" & AVPLib.ConstEnum.CG_IG_FORM
        m_LLACGGaugesFrm.StartPosition = FormStartPosition.CenterScreen
        m_LLACGGaugesFrm.ShowInTaskbar = False
        m_LLACGGaugesFrm.ShowIcon = False
        m_LLACGGaugesFrm.Hide()

    End Sub

    Public Sub NewConvectronGaugeFrm()
        m_CGGaugesFrm = New CGGaugesFrm(True, False, True, True)
        m_CGGaugesFrm.Name = AVPLib.ConstEnum.TM_STR & AVPLib.ConstEnum.CG_IG_FORM
        m_CGGaugesFrm.StartPosition = FormStartPosition.CenterScreen
        m_CGGaugesFrm.ShowInTaskbar = False
        m_CGGaugesFrm.ShowIcon = False
        m_CGGaugesFrm.Hide()

    End Sub

    Private Sub NewTMFLConvectronGaugeFrm()
        m_TMFLCGGaugesFrm = New CGGaugesFrm(False, False, False)
        m_TMFLCGGaugesFrm.Name = "TM" & AVPLib.ConstEnum.FORELINE & AVPLib.ConstEnum.CG_IG_FORM
        m_TMFLCGGaugesFrm.StartPosition = FormStartPosition.CenterScreen
        m_TMFLCGGaugesFrm.ShowInTaskbar = False
        m_TMFLCGGaugesFrm.ShowIcon = False
        m_TMFLCGGaugesFrm.Text = "TM " & AVPLib.ConstEnum.FORELINE
        m_TMFLCGGaugesFrm.Hide()
    End Sub

    Private Sub NewLLAFLConvectronGaugeFrm()
        m_LLAFLCGGaugesFrm = New CGGaugesFrm(False, False, False)
        m_LLAFLCGGaugesFrm.Name = "LLA" & AVPLib.ConstEnum.FORELINE & AVPLib.ConstEnum.CG_IG_FORM
        m_LLAFLCGGaugesFrm.StartPosition = FormStartPosition.CenterScreen
        m_LLAFLCGGaugesFrm.ShowInTaskbar = False
        m_LLAFLCGGaugesFrm.ShowIcon = False
        m_LLAFLCGGaugesFrm.Text = "LLA " & AVPLib.ConstEnum.FORELINE
        m_LLAFLCGGaugesFrm.Hide()
    End Sub
#End Region

#Region "Events � Buttons � Forms�"
    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-11-25</date>
    ''' </author>
    ''' <summary>
    ''' Release timer.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CassettesPanel_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Me.m_timerUpdateGasline IsNot Nothing Then
            Me.m_timerUpdateGasline.Enabled = False
            Me.m_timerUpdateGasline.Dispose()
            Me.m_timerUpdateGasline = Nothing
        End If
    End Sub

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-13</date>
    ''' </author>
    ''' <summary>
    ''' Handle form load event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ProcessPanel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            LLALeg.CassettePresent = False

            ' TMCtl.Message = AVPLib.ContainerData.GetMessageText("IgcgTMMessage")
            '
            Dim strMessage As String = AVPLib.ContainerData.GetMessageText("IgcgChamberMessage")
            IgcgChamber1.Message = String.Format(strMessage, AVPLib.RobotConfigurationValues.CHAMBER1_NAME)
            IgcgChamber2.Message = String.Format(strMessage, AVPLib.RobotConfigurationValues.CHAMBER2_NAME)
            IgcgChamber3.Message = String.Format(strMessage, AVPLib.RobotConfigurationValues.CHAMBER3_NAME)


            IgcgChamber1.Text = AVPLib.RobotConfigurationValues.CHAMBER1_NAME
            IgcgChamber2.Text = AVPLib.RobotConfigurationValues.CHAMBER2_NAME
            IgcgChamber3.Text = AVPLib.RobotConfigurationValues.CHAMBER3_NAME

            '
            Me.LoadRobotConfig()
            m_Robot.Initiate()

            'Disable aligner tab, Self Aligner tab
            If Not RobotConfigurationValues.ALINER_VISIBLE Then
                TMAlignerControl.Enabled = False
                saSelfAligner.Enabled = False
            End If

            lblTMNameOfSequenceRunning.Text = ""
            lblLLANameOfSequenceRunning.Text = ""

            For Each gasline As Control In Me.Controls
                If TypeOf gasline Is AnimationControl Then
                    DirectCast(gasline, AnimationControl).ExternalTimer = m_timerUpdateGasline
                End If
            Next
            m_timerUpdateGasline.Enabled = True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-13</date>
    ''' </author>
    ''' <summary>
    ''' Handle click event on menu create wafer
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuCreateWafer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCreateWafer.Click
        AVPLib.Log.guiLogger.Info("Enter mnuCreateWafer_Click")
        Try
            ' Create wafer dialog
            Dim addwafer As WaferInfoDlg = New WaferInfoDlg()
            addwafer.ShowDialog()
            If addwafer.DialogResult = DialogResult.OK Then
                If (m_intClickedChamber = CLICKEDALIGNER) Then
                    If Me.stwSemiautoTransferWafer.txtSource.Text.IndexOf("Aligner") > -1 Then
                        Me.stwSemiautoTransferWafer.txtSource.Clear()
                    ElseIf Me.stwSemiautoTransferWafer.txtDestination.Text.IndexOf("Aligner") > -1 Then
                        Me.stwSemiautoTransferWafer.txtDestination.Clear()
                    End If
                    'awcAligner.Status = BinaryStatusControl.DisplayStatus.On
                    Me.m_stoStatusObject.RequestStatus("WaferInsideAligner", BinaryStatusControl.DisplayStatus.On.ToString())

                    Dim cb As DataManagerment.Aligner = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Aligner.ToString())
                    cb.SetWaferInfo(addwafer.WaferInfo)

                    Dim strSource As String = "CassettePanel.mnuCreateWafer"
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                                       AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                       ConstantAndEnum.TM_SCREEN & " - Create Wafer " & addwafer.WaferInfo.WaferID & " inside aligner")

                ElseIf (m_intClickedChamber = CLICKEDROBOT) Then
                    If Me.stwSemiautoTransferWafer.txtSource.Text.IndexOf("Robot Arm") > -1 Then
                        Me.stwSemiautoTransferWafer.txtSource.Clear()
                    ElseIf Me.stwSemiautoTransferWafer.txtDestination.Text.IndexOf("Robot Arm") > -1 Then
                        Me.stwSemiautoTransferWafer.txtDestination.Clear()
                    End If

                    Me.m_stoStatusObject.RequestStatus("WaferInsideRobot", BinaryStatusControl.DisplayStatus.On.ToString())

                    Dim cb As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())
                    cb.SetWaferInfo(addwafer.WaferInfo)

                    Dim strSource As String = "CassettePanel.mnuCreateWafer"
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                                       AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                       ConstantAndEnum.TM_SCREEN & " - Create Wafer " & addwafer.WaferInfo.WaferID & " inside Robot Arm")
                Else
                    'update the wafer infomation for the chamber

                    SetWaferInside(ConstEnum.STR_CREATE_WAFER, BinaryStatusControl.DisplayStatus.On, addwafer.WaferInfo)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave mnuCreateWafer_Click")
    End Sub

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-13</date>
    ''' </author>
    ''' <summary>
    ''' Handle click event on menu delete wafer
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuDeleteWafer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDeleteWafer.Click
        AVPLib.Log.guiLogger.Info("Enter mnuDeleteWafer_Click")
        Try
            If (m_intClickedChamber = CLICKEDALIGNER) Then
                stwSemiautoTransferWafer.chkUseAligner.Checked = False
                If Me.stwSemiautoTransferWafer.txtSource.Text.IndexOf("Aligner") > -1 Then
                    Me.stwSemiautoTransferWafer.txtSource.Clear()
                ElseIf Me.stwSemiautoTransferWafer.txtDestination.Text.IndexOf("Aligner") > -1 Then
                    Me.stwSemiautoTransferWafer.txtDestination.Clear()
                End If

                Dim cb As DataManagerment.Aligner = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Aligner.ToString())
                If Business.AVPCore.Instance().JobManager() IsNot Nothing AndAlso cb.GetWaferInfo() IsNot Nothing Then
                    Dim proJob As Business.AVPProcessJob = Business.AVPCore.Instance().JobManager().GetProcessJob(cb.GetWaferInfo().WaferID)
                    If proJob IsNot Nothing AndAlso proJob.IsAutoTransfer Then
                        Utils.ShowAVPMessageBox("Can't delete wafer " & cb.GetWaferInfo().WaferID & ". Scheduler is running.", ConstEnum.STR_AVP, MessageBoxIcon.Error, MessageBoxButtons.OK)
                        Exit Try
                    End If
                End If

                Me.m_stoStatusObject.RequestStatus("WaferInsideAligner", BinaryStatusControl.DisplayStatus.Off.ToString())
                cb.SetWaferInfo()

                Dim strSource As String = "CassettePanel.mnuDeleteWafer"
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                                   AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                   ConstantAndEnum.TM_SCREEN & " - Delete Wafer inside aligner")
            ElseIf (m_intClickedChamber = CLICKEDROBOT) Then
                If Me.stwSemiautoTransferWafer.txtSource.Text.IndexOf("Robot Arm") > -1 Then
                    Me.stwSemiautoTransferWafer.txtSource.Clear()
                ElseIf Me.stwSemiautoTransferWafer.txtDestination.Text.IndexOf("Robot Arm") > -1 Then
                    Me.stwSemiautoTransferWafer.txtDestination.Clear()
                End If

                Dim cb As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())
                If Business.AVPCore.Instance().JobManager() IsNot Nothing AndAlso cb.GetWaferInfo() IsNot Nothing Then
                    Dim proJob As Business.AVPProcessJob = Business.AVPCore.Instance().JobManager().GetProcessJob(cb.GetWaferInfo().WaferID)
                    If proJob IsNot Nothing AndAlso proJob.IsAutoTransfer Then
                        Utils.ShowAVPMessageBox("Can't delete wafer " & cb.GetWaferInfo().WaferID & ". Scheduler is running.", ConstEnum.STR_AVP, MessageBoxIcon.Error, MessageBoxButtons.OK)
                        Exit Try
                    End If
                End If

                cb.SetWaferInfo()

                Me.m_stoStatusObject.RequestStatus("WaferInsideRobot", BinaryStatusControl.DisplayStatus.Off.ToString())
                Dim strSource As String = "CassettePanel.mnuDeleteWafer"
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser,
                                                   AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                   ConstantAndEnum.TM_SCREEN & " - Delete Wafer inside Robot Arm")
            Else
                SetWaferInside(ConstEnum.STR_DELETE_WAFER, BinaryStatusControl.DisplayStatus.Off, Nothing)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave mnuDeleteWafer_Click")
    End Sub

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-13</date>
    ''' </author>
    ''' <summary>
    ''' Handle click event on menu source for move
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuSrcForMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSrcForMove.Click
        AVPLib.Log.guiLogger.Info("Enter mnuSrcForMove_Click")
        Try
            If CheckWaferIsPausingInRobotOrAligner() Then
                Exit Try
            End If

            'WHEN STARTING -> SHOW MESSAGE BOX
            If stwSemiautoTransferWafer.btnStart.Enabled = False AndAlso
              Not String.IsNullOrEmpty(stwSemiautoTransferWafer.txtSource.Text) AndAlso
                     Not String.IsNullOrEmpty(stwSemiautoTransferWafer.txtDestination.Text) Then ''transferring
                Utils.ShowAVPMessageBox("Please wait for other transfer to complete...", "Transfer Wafer", MessageBoxIcon.Error, MessageBoxButtons.OK)
            Else
                'SOURCE = NEW SOURCE
                stwSemiautoTransferWafer.txtSource.Text = GenerateSrcOrDst()
                'CHECK SOURCE AND DESTIANTION
                'IF ERROR CLEAR DESTINATION 
                If stwSemiautoTransferWafer.txtDestination.Text = stwSemiautoTransferWafer.txtSource.Text Then
                    Utils.ShowAVPMessageBox("Source and Destination for Transfer Wafer are the same, Destination will be clear." & Chr(13) & " Please select Destination for Transfer Wafer again", "Transfer Wafer", MessageBoxIcon.Warning, MessageBoxButtons.OK)
                    'KEEP DESTINATION BECAUSE IT'S NOT ERROR
                    stwSemiautoTransferWafer.txtDestination.Clear()
                End If
                'EVERYTHING OK -> SHOW STATUS MESSAGE ON BOTTON LEFT SCREEN
                AVPLib.Utils.ShowStatusMessage("Source for Transfer Wafer: " & stwSemiautoTransferWafer.txtSource.Text)
                'SHOW MESSAGE BOX TO CHOOSE ALIGNER
                ContainerForm.CassettesPanel.ShowTransferWaferDialog()
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, ConstantAndEnum.TM_SCREEN & " - Select Source For Move " + stwSemiautoTransferWafer.txtSource.Text)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave mnuSrcForMove_Click")
    End Sub

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-13</date>
    ''' </author>
    ''' <summary>
    ''' Handle click event on menu destination for move
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuDstForMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDstForMove.Click
        AVPLib.Log.guiLogger.Info("Enter mnuDstForMove_Click")
        Try
            If CheckWaferIsPausingInRobotOrAligner() Then
                Exit Try
            End If

            'WHEN STARTING -> SHOW MESSAGE BOX
            If stwSemiautoTransferWafer.btnStart.Enabled = False AndAlso
               Not String.IsNullOrEmpty(stwSemiautoTransferWafer.txtSource.Text) AndAlso
                      Not String.IsNullOrEmpty(stwSemiautoTransferWafer.txtDestination.Text) Then ''transferring
                Utils.ShowAVPMessageBox("Please wait for other transfer to complete...", "Transfer Wafer", MessageBoxIcon.Error, MessageBoxButtons.OK)
            Else
                'DESTINATION = NEW DESTINATION
                stwSemiautoTransferWafer.txtDestination.Text = GenerateSrcOrDst()

                'WHEN SELECT DESTINATION IS ALIGNER
                'NEED CHECK ALIGNER IS CURRENT IN USE
                If stwSemiautoTransferWafer.txtDestination.Text = STR_ALIGNER Then
                    'stwSemiautoTransferWafer.chkUseAligner.Checked = True
                    stwSemiautoTransferWafer.Dest_Is_Aligner = True
                Else
                    stwSemiautoTransferWafer.Dest_Is_Aligner = False
                End If

                'IF DESTINATION = SOURCE (ERROR)
                If stwSemiautoTransferWafer.txtSource.Text = stwSemiautoTransferWafer.txtDestination.Text Then
                    Utils.ShowAVPMessageBox("Source and Destination for Transfer Wafer are the same, Source will be clear. " & Chr(13) & "Please select Source for Transfer Wafer again", "Transfer Wafer", MessageBoxIcon.Warning, MessageBoxButtons.OK)
                    'NEW DESTIANTION IS WRONG SO CLEAR IT
                    stwSemiautoTransferWafer.txtSource.Clear()
                End If
                'WHEN EVERYTHING OK -> SHOW STATUS MESSAGE ON BOTTON LEFT SCREEN
                AVPLib.Utils.ShowStatusMessage("Destination for Transfer Wafer: " & stwSemiautoTransferWafer.txtDestination.Text)
                'SHOW DIALOG BOX TO SELECT ALIGNER
                ContainerForm.CassettesPanel.ShowTransferWaferDialog()
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, ConstantAndEnum.TM_SCREEN & " - Select Destination For Move " + stwSemiautoTransferWafer.txtDestination.Text)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave mnuDstForMove_Click")
    End Sub

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2015-09-29 </date>
    ''' </author>
    ''' <summary>
    ''' check if wafer is pausing in PM or Mechanical Aligner when transfer manual
    ''' </summary>
    Private Function CheckWaferIsPausingInRobotOrAligner() As Boolean
        Dim result As Boolean = False

        Try
            Dim waferID As String = String.Empty

            If (m_intClickedChamber = CLICKEDALIGNER) Then
                Dim objAligner As DataManagerment.Aligner = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Aligner.ToString())
                If objAligner IsNot Nothing AndAlso objAligner.GetWaferInfo() IsNot Nothing Then
                    waferID = objAligner.GetWaferInfo().WaferID
                End If

            ElseIf (m_intClickedChamber = CLICKEDROBOT) Then
                Dim objRobot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())
                If objRobot IsNot Nothing AndAlso objRobot.GetWaferInfo() IsNot Nothing Then
                    waferID = objRobot.GetWaferInfo().WaferID
                End If

            End If

            result = Utils.IsWaferPausing(waferID)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return result
    End Function

    Public Sub ShowTransferWaferDialog()
        Dim strMessageText As String = String.Empty
        If ContainerForm.CassettesPanel.ISTM_ONLINE Then
            Utils.ShowAVPMessageBox("Cannot transfer wafer when TM is online.", "Transfer Wafer", MessageBoxIcon.Error, MessageBoxButtons.OK)
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, ConstantAndEnum.TM_SCREEN & " - Cannot transfer wafer when TM is online.")
            Exit Sub
        End If
        If Not String.IsNullOrEmpty(stwSemiautoTransferWafer.txtSource.Text) AndAlso
               Not String.IsNullOrEmpty(stwSemiautoTransferWafer.txtDestination.Text) Then
            strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("StartSemiAutoRobotCassettes"), START_SEMIAUTOTRANFER)
            Dim result As Integer = Utils.ShowAVPUseAlignerMessageBox(stwSemiautoTransferWafer.txtSource.Text,
                                                                      stwSemiautoTransferWafer.txtDestination.Text,
                                                                      stwSemiautoTransferWafer.Dest_Is_Aligner,
                                                                      stwSemiautoTransferWafer.txtRecipe.Text)

            If result = System.Windows.Forms.DialogResult.OK Then
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, ConstantAndEnum.TM_SCREEN & " - Start Transfer Wafer")
                Dim blnUseAligner As Boolean = AVPUseAlignerDialogBox.IsUsingAligner
                Dim RecipeName As String = AVPUseAlignerDialogBox.RecipeName
                If blnUseAligner And String.IsNullOrEmpty(RecipeName) Then
                    Utils.ShowAVPMessageBox("Please select Recipe for Aligner",
                                             START_SEMIAUTOTRANFER, MessageBoxIcon.Error, MessageBoxButtons.OK)
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, ConstantAndEnum.TM_SCREEN & " - There is not recipe for Aligner.")
                    Exit Sub
                End If
                stwSemiautoTransferWafer.txtStatus.Clear()

                Dim strSrc As String = String.Empty
                If (stwSemiautoTransferWafer.txtSource.Text.Contains(",")) Then
                    Dim arrSourceParam As String() = stwSemiautoTransferWafer.txtSource.Text.Split(",")
                    If (arrSourceParam.Length = 2) Then
                        strSrc = AVPLib.Utils.chamberName2ChamberID(arrSourceParam(0)) & "," & arrSourceParam(1)
                    End If
                Else
                    strSrc = AVPLib.Utils.chamberName2ChamberID(stwSemiautoTransferWafer.txtSource.Text)
                End If
                strSrc = strSrc.Replace(" ", "") ' Remove blank space.

                Dim strDest As String = String.Empty
                If (stwSemiautoTransferWafer.txtDestination.Text.Contains(",")) Then
                    Dim arrDesParam As String() = stwSemiautoTransferWafer.txtDestination.Text.Split(",")
                    If (arrDesParam.Length = 2) Then
                        strDest = AVPLib.Utils.chamberName2ChamberID(arrDesParam(0)) & "," & arrDesParam(1)
                    End If
                Else
                    strDest = AVPLib.Utils.chamberName2ChamberID(stwSemiautoTransferWafer.txtDestination.Text)
                End If
                strDest = strDest.Replace(" ", "") ' Remove blank space.

                Dim strValue As String =
                      strSrc + "," +
                      strDest + "," +
                      AVPLib.ConstEnum.USEALIGNER + CStr(blnUseAligner) +
                      IIf(blnUseAligner, "," + RecipeName, String.Empty)
                stwSemiautoTransferWafer.txtRecipe.Text = RecipeName
                stwSemiautoTransferWafer.chkUseAligner.Checked = blnUseAligner
                ContainerForm.CassettesPanel.stwSemiautoTransferWafer.btnStart_Click()
                If blnUseAligner Then
                    ' Arrange_Control_Run_With_AlignerRecipe(True)
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                    ConstantAndEnum.TM_SCREEN & " - Start Transfer from " & AVPLib.Utils.chamberID2ChamberName(strSrc) & " to " & AVPLib.Utils.chamberID2ChamberName(strDest) & " with using Aligner: " & RecipeName)
                Else
                    'Arrange_Control_Run_With_AlignerRecipe(False)
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                    ConstantAndEnum.TM_SCREEN & " - Start Transfer from " & AVPLib.Utils.chamberID2ChamberName(strSrc) & " to " & AVPLib.Utils.chamberID2ChamberName(strDest) & " without using Aligner")
                End If
            Else
                stwSemiautoTransferWafer.txtSource.Clear()
                stwSemiautoTransferWafer.txtDestination.Clear()
            End If
        End If
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-13</date>
    ''' </author>
    ''' <summary>
    ''' Handle click event on circle Plasma of Chamber1
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cpcCirclePlasmaHand1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AVPLib.Log.guiLogger.Info("Enter cpcCirclePlasmaHand1_Click")
        Try
            ' PrepareChamberMenu(Me.cpcWaferChamber1)
            ShowContextMenuClickOnChamber(sender)
            m_intClickedChamber = CLICKEDCHAMBER1
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave cpcCirclePlasmaHand1_Click")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-04-21</date>
    ''' </author>
    ''' <summary>
    ''' Handle click event on circle Plasma of Chamber2
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cpcWaferChamber2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AVPLib.Log.guiLogger.Info("Enter cpcWaferChamber2_Click")
        Try
            'PrepareChamberMenu(Me.cpcWaferChamber2)
            ShowContextMenuClickOnChamber(sender)
            m_intClickedChamber = CLICKEDCHAMBER2
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave cpcWaferChamber2_Click")
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-13</date>
    ''' </author>
    ''' <summary>
    ''' Handle click event on circle Plasma of Chamber3
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cpcCirclePlasmaHand3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AVPLib.Log.guiLogger.Info("Enter cpcCirclePlasmaHand3_Click")
        Try
            ' PrepareChamberMenu(Me.cpcWaferChamber3)
            ShowContextMenuClickOnChamber(sender)
            m_intClickedChamber = CLICKEDCHAMBER3
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave cpcCirclePlasmaHand3_Click")
    End Sub

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-15</date>
    ''' </author>
    ''' <summary>
    ''' Handle click event on Tool button   
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnTool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTool.Click
        AVPLib.Log.guiLogger.Info("Enter btnTool_Click")
        Try
            Dim pos As New System.Drawing.Point(btnTool.Location)
            pos.Y += btnTool.Height
            pos = Me.PointToScreen(pos)
            cmsTool.Show(pos)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnTool_Click")
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-15</date>
    ''' </author>
    ''' <summary>
    ''' Handle click event on Home menu item
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuHome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuHome.Click
        AVPLib.Log.guiLogger.Info("Enter mnuHome_Click")
        Dim strMessageText As String = String.Empty
        Try
            strMessageText = AVPLib.ContainerData.GetMessageText("HomeMenuRobotCassettes")
            If (Utils.ShowAVPMessageBox(strMessageText, HOME_TM, MessageBoxIcon.Question) = DialogResult.OK) Then
                m_stoStatusObject.RequestStatus(mnuHome.Name, "Click")
                Utils.AlignerCMDAction(False, True)
                cmsTool.Enabled = False
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen,
                  ConstantAndEnum.TM_SCREEN & " - Click Home Robot")
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave mnuHome_Click")
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-15</date>
    ''' </author>
    ''' <summary>
    ''' Handle click event on Align menu item
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuAlign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAlign.Click
        AVPLib.Log.guiLogger.Info("Enter mnuAlign_Click")
        Dim strMessageText As String = String.Empty
        Try
            strMessageText = AVPLib.ContainerData.GetMessageText("AlignMenuRobotCassettes")
            If (Utils.ShowAVPMessageBox(strMessageText, ALIGN, MessageBoxIcon.Question) = DialogResult.OK) Then
                m_stoStatusObject.RequestStatus(mnuAlign.Name, "Click")
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen,
                ConstantAndEnum.TM_SCREEN & " - Click Align Robot")
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave mnuAlign_Click")
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-24</date>
    ''' </author>
    ''' <summary>
    ''' Handle click on aligner
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub awcAligner_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles awcAligner.Click
        AVPLib.Log.guiLogger.Info("Enter awcAligner_Click")
        Try
            PrepareAlignerMenu()
            ShowContextMenuClickOnAligner()
            m_intClickedChamber = CLICKEDALIGNER
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave awcAligner_Click")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-08-14</date>
    ''' </author>
    ''' <summary>
    ''' ticHandOriginal_Click
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Sub picRobotBody_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RobotHand.Click
        AVPLib.Log.guiLogger.Info("Enter picRobotBody_Click")
        Try
            PrepareRobotMenu()
            ShowContextMenuClickOnRobot()
            m_intClickedChamber = CLICKEDROBOT
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave picRobotBody_Click")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-01</date>
    ''' </author>
    ''' <summary>
    ''' Event for label Status Text (from Transfer Screen) 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lblStatusText_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblStatusText.TextChanged
        If ContainerForm.Chamber1Visible Then
            ContainerForm.ChamberPanel(Equipments.Chamber1.ToString()).StatusText = Me.lblStatusText.Text
        End If
        If ContainerForm.Chamber2Visible Then
            ContainerForm.ChamberPanel(Equipments.Chamber2.ToString()).StatusText = Me.lblStatusText.Text
        End If
        If ContainerForm.Chamber3Visible Then
            ContainerForm.ChamberPanel(Equipments.Chamber3.ToString()).StatusText = Me.lblStatusText.Text
        End If
        ContainerForm.ProcessPanel.lblStatusText.Text = Me.lblStatusText.Text
        ContainerForm.ProcessPanel.lblStatusText.ForeColor = Me.lblStatusText.ForeColor
        '#05/16/2011 
        '#All event messages coming from PVD/IBE should be logged.  All LL�s/TM event message should be logged
        '#Begin fix
        If Not String.IsNullOrEmpty(Me.lblStatusText.Text) Then
            Dim strSource = String.Empty
            Dim strRegularExp = "^\[.*?\] (PM\d):\s?(.*)"
            Try
                Dim FoundMatch As Boolean = Regex.IsMatch(Me.lblStatusText.Text, strRegularExp)
                If (FoundMatch) Then
                    strSource = Regex.Match(Me.lblStatusText.Text, strRegularExp).Groups(1).Value
                End If
                strSource = AVPLib.Utils.chamberID2ChamberName(strSource)
            Catch ex As Exception
                strSource = String.Empty
            End Try
            If Not String.IsNullOrEmpty(strSource) AndAlso AVPLib.Utils.CheckSourceLogIsAEquipment(AVPLib.Utils.chamberName2ChamberID(strSource)) = True Then
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeMessage, strSource, Regex.Match(Me.lblStatusText.Text, strRegularExp).Groups(2).Value)
            End If
        End If
        '#End fix.
        clearStatusTimer.Enabled = True
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-01</date>
    ''' </author>
    ''' <summary>
    ''' Event for clearStatusTimer_Tick (from Transfer Screen) 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    '''dat cao add a local variable to control status text
    Private m_ClearTimerCount As Integer = 0
    Private Sub clearStatusTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clearStatusTimer.Tick
        If (String.IsNullOrEmpty(ContainerForm.CassettesPanel.stwSemiautoTransferWafer.txtDestination.Text)) OrElse
           (String.IsNullOrEmpty(ContainerForm.CassettesPanel.stwSemiautoTransferWafer.txtSource.Text)) OrElse
         ContainerForm.CassettesPanel.stwSemiautoTransferWafer.btnStart.Enabled Then
            If (m_ClearTimerCount > 600) Then ' increase clear message status from 2 minutes to 10 minutes.
                'if not transfer wafer -> clear status text
                'if transfer wafer -> keep status text more
                ContainerForm.CassettesPanel.lblStatusText.Text = String.Empty
                clearStatusTimer.Enabled = False
                m_ClearTimerCount = 0
                m_ReturnWaferStatus = TranferWaferStatus.None
            Else
                m_ClearTimerCount += 1
            End If
        End If

        'if 
        If (m_ReturnWaferStatus = TranferWaferStatus.Starting And
        ContainerForm.CassettesPanel.lblStatusText.Text = "" And
        m_ReturnStatusText = "") Then
            ContainerForm.CassettesPanel.lblStatusText.Text = AVPLib.ConstEnum.Return_Wafer_Starting
            m_ClearTimerCount = 0
        ElseIf (m_ReturnWaferStatus = TranferWaferStatus.Starting And ContainerForm.CassettesPanel.lblStatusText.Text =
            AVPLib.ConstEnum.Return_Wafer_Starting) Then
            ContainerForm.CassettesPanel.lblStatusText.Text = ""
            m_ClearTimerCount = 0
        ElseIf (m_ReturnWaferStatus = TranferWaferStatus.Starting And
        ContainerForm.CassettesPanel.lblStatusText.Text.Contains("Start Transfer")) Then
            m_ReturnStatusText = ContainerForm.CassettesPanel.lblStatusText.Text
            ContainerForm.CassettesPanel.lblStatusText.Text = ""
            m_ClearTimerCount = 0
        ElseIf (m_ReturnWaferStatus = TranferWaferStatus.Starting And
        ContainerForm.CassettesPanel.lblStatusText.Text = "" And Not _
        m_ReturnStatusText = "") Then
            ContainerForm.CassettesPanel.lblStatusText.Text = m_ReturnStatusText
            m_ClearTimerCount = 0
        ElseIf (m_ReturnWaferStatus = TranferWaferStatus.Starting And ContainerForm.CassettesPanel.lblStatusText.Text.Contains("Failed")) Then
            m_ReturnWaferStatus = TranferWaferStatus.Error
            m_ReturnStatusText = ""
            m_ClearTimerCount = 0
        ElseIf (m_ReturnWaferStatus = TranferWaferStatus.Starting And ContainerForm.CassettesPanel.lblStatusText.Text.Contains("Completed")) Then
            m_ReturnWaferStatus = TranferWaferStatus.Finished
            m_ReturnStatusText = ""
            m_ClearTimerCount = 0
        Else
            m_ReturnWaferStatus = TranferWaferStatus.None
            m_ReturnStatusText = ""
        End If

    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-01</date>
    ''' </author>
    ''' <summary>
    ''' Event for update WaferInfo
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub UpdateWaferInfoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuUpdateWaferInfoToolStripMenuItem.Click
        AVPLib.Log.guiLogger.Info("Enter UpdateWaferInfoToolStripMenuItem_Click")
        Try
            Dim waferInfo As AVPLib.AVPWaferInfo = Nothing
            Dim equipment As AVPLib.DataManagerment.Equipment = Nothing
            If (m_intClickedChamber = CLICKEDALIGNER) Then
                ' Get information on Aligner
                equipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Aligner.ToString())
            ElseIf (m_intClickedChamber = CLICKEDROBOT) Then
                ' Get information on Robot
                equipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Robot.ToString())
            ElseIf (m_intClickedChamber = CLICKEDCHAMBER1) Then
                equipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Chamber1.ToString())
            ElseIf (m_intClickedChamber = CLICKEDCHAMBER2) Then
                equipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Chamber2.ToString())
            ElseIf (m_intClickedChamber = CLICKEDCHAMBER3) Then
                equipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Chamber3.ToString())
            End If

            If equipment IsNot Nothing Then
                waferInfo = equipment.GetWaferInfo()

                ' Create wafer dialog
                Dim updateWafer As WaferInfoDlg = New WaferInfoDlg(waferInfo)
                updateWafer.ShowDialog()

                'Refresh GUI
                If (m_intClickedChamber = CLICKEDALIGNER) Then
                    'awcAligner.Status = BinaryStatusControl.DisplayStatus.On
                    Me.m_stoStatusObject.RequestStatus("WaferInsideAligner", BinaryStatusControl.DisplayStatus.On.ToString())
                ElseIf (m_intClickedChamber = CLICKEDROBOT) Then
                    Me.m_stoStatusObject.RequestStatus("WaferInside", BinaryStatusControl.DisplayStatus.On.ToString())
                Else
                    'update the wafer infomation for the chamber
                    SetWaferInside(ConstEnum.STR_UPDATE_WAFER, BinaryStatusControl.DisplayStatus.On, waferInfo)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave UpdateWaferInfoToolStripMenuItem_Click")

    End Sub

#Region "Valve" '2 mode Unprotected and Protected
    ''Open - Close Slit valve
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-01</date>
    ''' </author>
    ''' <summary>
    ''' Event for Slit valve Click (from 1 to 7)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rrcMesaValve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MesaValvePM1.Click, MesaValvePM2.Click, MesaValvePM3.Click, MesaValveLLA.Click

        AVPLib.Log.guiLogger.Info("Enter rrcMesaValve_Click")
        Try
            Dim strMessageText As String
            'Dim strValue As String
            Dim blRet As Boolean = True
            Dim objTMController As AVPLib.Business.TMController = AVPLib.Business.ControllerManager.GetController(ConstEnum.Equipments.CassettesModule.ToString())
            Dim mesaValve As SlitValve = CType(sender, SlitValve)
            Dim strChamber As String = String.Empty
            Dim strChamberName As String = GetChamberName(mesaValve.Name, strChamber)
            If Not AVPLib.ContainerData.IsChamberVisible(strChamber) Then
                AVPLib.Utils.ThrowAlarm(strChamberName & " is not Available")
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen,
                ConstantAndEnum.TM_SCREEN & " - Try to click on Slit valve of " & strChamberName)
                Exit Sub
            End If
            If (mesaValve.Status = BinaryStatusControl.DisplayStatus.On) Then
                strMessageText = AVPLib.ContainerData.GetMessageText("MesaValvePM" & STRING_CLOSE)
                strMessageText = String.Format(strMessageText, strChamberName)
                If (Utils.ShowAVPMessageBox(strMessageText, strChamberName, MessageBoxIcon.Question) = DialogResult.OK) Then
                    GoTo CloseMesaValve
                End If
            ElseIf (mesaValve.Status = BinaryStatusControl.DisplayStatus.Off) Then
                strMessageText = AVPLib.ContainerData.GetMessageText("MesaValvePM" & STRING_OPEN)
                strMessageText = String.Format(strMessageText, strChamberName)
                If (Utils.ShowAVPMessageBox(strMessageText, strChamberName, MessageBoxIcon.Question) = DialogResult.OK) Then
                    GoTo OpenMesaValve
                End If
            ElseIf (mesaValve.Status = BinaryStatusControl.DisplayStatus.Unknown) Then
                strMessageText = AVPLib.ContainerData.GetMessageText("MesaValvePM" & UNKNOWN)
                strMessageText = String.Format(strMessageText, strChamberName)
                Dim dlgResult As DialogResult = Utils.ShowAVPMessageBox(strMessageText, strChamberName,
                    MessageBoxIcon.Question, AVPMessageBox.AVPMessageBoxButton.OpenCloseCancel)
                If dlgResult = DialogResult.OK Then 'Open
                    GoTo OpenMesaValve
                ElseIf dlgResult = DialogResult.No Then 'Close
                    GoTo CloseMesaValve
                End If
            End If
            Exit Sub
OpenMesaValve:
            'Not in Cycle ATM mode
            If strChamber.StartsWith(ConstEnum.Chamber) Then
                '#07/07/2011 
                '#-	AVP->TM.   Tm override mode does not allow user to open Slit valve when Pmx is disconnected.
                If (m_TM_Protected_Mode.Status = ProtectedModStatus.Off) Then 'Fix.
                    Dim objChamber As AVPLib.DataManagerment.Chamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(strChamber)
                    If (objChamber.ConnectionStatus <> AVPLib.DataManagerment.Equipment.WorkingStatuses.On) Then
                        Dim MsgText As String = String.Format(AVPLib.ContainerData.GetMessageText("EquipmentDisconnect"), strChamberName)
                        AVPLib.Utils.ThrowAlarm(MsgText)
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen,
                                  ConstantAndEnum.TM_SCREEN & " - Open Slit valve of " & strChamberName & ", this PM is disconnected")
                        Exit Sub
                    End If
                End If
            Else ''LL is disconnected then 
                If (m_TM_Protected_Mode.Status = ProtectedModStatus.Off) Then
                    Dim objElevator As AVPLib.DataManagerment.LLElevator = Nothing
                    If strChamber = LOAD_LOCK_A Then
                        objElevator = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.LLAElevator.ToString())
                    End If
                    If (objElevator.IsCommunicating = False) Then
                        Dim MsgText As String = String.Format(AVPLib.ContainerData.GetMessageText("EquipmentDisconnect"), strChamberName)
                        AVPLib.Utils.ThrowAlarm(MsgText)
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen,
                                  ConstantAndEnum.TM_SCREEN & " - Open Slit valve of " & strChamberName & ", this LL is disconnected")
                        Exit Sub
                    End If
                End If

            End If
            If (m_TM_Protected_Mode.Status = ProtectedModStatus.Off) Then
                Dim strErrorMsg As String = String.Empty
                blRet = objTMController.CheckCondition2OpenTMIsolationValve(strChamber, False, strErrorMsg)
                If blRet = True Then
                    If strChamber.StartsWith(ConstEnum.Chamber) Then
                        strErrorMsg = AVPLib.Utils.IsRobotStationOKToOpenCloseSlitValve(strChamber, strChamberName, True)
                        If Not String.IsNullOrEmpty(strErrorMsg) Then
                            AVPLib.Utils.ThrowAlarm(strErrorMsg)
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, ConstantAndEnum.TM_SCREEN & " - " & strErrorMsg)
                            Exit Sub
                        End If

                        If objTMController.IsOK_2OpenPMSlitValve(strChamber) Then
                            m_stoStatusObject.RequestStatus(mesaValve.Name, STR_ON)
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen,
                               ConstantAndEnum.TM_SCREEN & " - Open Slit valve of " & strChamberName)
                        Else
                            AVPLib.Utils.ThrowAlarm(strChamberName & " Is Running Process or Plasma Is On")
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen,
                              ConstantAndEnum.TM_SCREEN & " - Can not Open Slit valve of " & strChamberName & " when Process is running or Plasma Is On")
                        End If
                    Else
                        m_stoStatusObject.RequestStatus(mesaValve.Name, STR_ON)
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen,
                        ConstantAndEnum.TM_SCREEN & " - Open Slit valve of " & strChamberName)
                    End If
                Else

                    'Utils.ShowAVPMessageBox(String.Format(AVPLib.ContainerData.GetMessageText(AVPLib.ConstEnum.CG_OF_TM_AND_RELATED_EQUIPMENT_NO_DIFFER10), _
                    'strChamberName), strChamberName, MessageBoxIcon.Warning, MessageBoxButtons.OK)
                    'AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                    '                                                     ConstantAndEnum.TM_SCREEN & " - Check conditions to open Slit valve of " & strChamberName & " failed.")
                    AVPLib.Utils.ThrowAlarm(strErrorMsg)
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                                         ConstantAndEnum.TM_SCREEN & " - Check conditions to open Slit valve of " & strChamberName & " failed.")
                End If
            Else ' alway pass condition
                m_stoStatusObject.RequestStatus(mesaValve.Name, STR_ON)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen,
                ConstantAndEnum.TM_SCREEN & " - Open Slit valve of " & strChamberName)
            End If
            Exit Sub
CloseMesaValve:
            If strChamber.StartsWith(ConstEnum.Chamber) Then
                Dim strErrorMsg = AVPLib.Utils.IsRobotStationOKToOpenCloseSlitValve(strChamber, strChamberName, False)
                If Not String.IsNullOrEmpty(strErrorMsg) Then
                    AVPLib.Utils.ThrowAlarm(strErrorMsg)
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, ConstantAndEnum.TM_SCREEN & " - " & strErrorMsg)
                    Exit Sub
                End If
            End If

            m_stoStatusObject.RequestStatus(mesaValve.Name, STR_OFF)
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen,
                                 ConstantAndEnum.TM_SCREEN & " - Close Slit valve of " & strChamberName)

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave rrcMesaValve_Click")
    End Sub

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-01</date>
    ''' </author>
    ''' <summary>
    ''' Event for Valve Click (from Transfer Screen)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ValveControl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
     Handles ValveVent.Click, ValveLLASlowRough.Click, ValveRough.Click, ValveLLAFastVent.Click, ValveLLASlowVent.Click, ValveLLAFastRough.Click, ValveTMTurbo.Click, ValveLLATurbo.Click
        AVPLib.Log.guiLogger.Info("Enter ValveControl_Click")
        Try
            Dim Valve As AVP_Robot_Project.ValveControl = CType(sender, AVP_Robot_Project.ValveControl)
            Dim ValveName As String = Valve.Name
            Dim strMessageText As String = String.Empty
            Dim strValue As String = String.Empty
            If (Valve.Status = BinaryStatusControl.DisplayStatus.On) Then
                strMessageText = AVPLib.ContainerData.GetMessageText("Transfer" + ValveName + "Close")
                strValue = BinaryStatusControl.DisplayStatus.Off.ToString(STRING_G)
            ElseIf Valve.Status = BinaryStatusControl.DisplayStatus.Off Then
                strMessageText = AVPLib.ContainerData.GetMessageText("Transfer" + ValveName + "Open")
                strValue = BinaryStatusControl.DisplayStatus.On.ToString(STRING_G)
            End If

            If (Utils.ShowAVPMessageBox(strMessageText, TM_STR, MessageBoxIcon.Question) = DialogResult.OK) Then
                ' check the condition before open the valve
                Dim cassetteModule As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString())
                Dim loadlockA As DataManagerment.LoadLock = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.LoadLockA.ToString())
                Dim blRet As Boolean = False, strResult As String = String.Empty

                If m_TM_Protected_Mode.Status = ProtectedModStatus.Off Then
                    If Valve.Status = BinaryStatusControl.DisplayStatus.On Then
                        blRet = True
                    ElseIf Valve.Status = BinaryStatusControl.DisplayStatus.Off Then
                        Select Case ValveName '''we should raise detail error message at the end 
                            Case VALVE_LLA_SLOW_ROUGH, VALVE_LLA_FAST_ROUGH
                                strResult = loadlockA.CheckCondition2OpenLLRough()
                            Case VENT_VALVE
                                strResult = cassetteModule.checkCondition2OpenTMVent()
                            Case VALVE_LLA_SLOW_VENT, VALVE_LLA_FAST_VENT
                                strResult = loadlockA.CheckCondition2OpenLLVent()
                            Case ROUGH_VALVE
                                strResult = cassetteModule.checkCondition2OpenTMRough()
                            Case VALVE_LLA_TURBO
                                strResult = CheckCondition2OpenLLForeLine()
                            Case VALVE_TM_TURBO
                                strResult = CheckCondition2OpenTMForeLine()

                        End Select
                        If String.IsNullOrEmpty(strResult) Then
                            blRet = True ''no error message
                        End If
                    End If
                Else
                    blRet = True 'alway true, not need check condition
                End If
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen,
                                             ConstantAndEnum.TM_SCREEN & " - Clicked on " & ValveName)

                If blRet Then '''no error message
                    m_stoStatusObject.RequestStatus(ValveName, strValue)
                Else ''if strResult has error, we raise it
                    'MessageBox.Show(strResult, ValveName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    AVPLib.Utils.ThrowAlarm(strResult)
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen,
                             ConstantAndEnum.TM_SCREEN & " - Result of clicking on " & ValveName & " has error.")
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave ValveControl_Click")
    End Sub

    ''' <author>
    ''' <name>Tri Do</name>
    ''' <date>2014-01-17</date>
    ''' </author>
    ''' <summary>
    ''' Check the condition to open the LL ForeLine Valve
    ''' true if meet the condition 
    ''' </summary>
    ''' <remarks></remarks>
    Public Function CheckCondition2OpenLLForeLine() As String
        AVPLib.Log.coreLogger.Info("Enter CheckCondition2OpenLLForeLine")
        Dim strRet As String = String.Empty

        If (RobotConfigurationValues.DEBUGMODE) Then
            Return strRet
        End If

        If Me.crcTMCryo.Is_CryO_Regen_Status AndAlso Not Me.crcTMCryo.Is_CryO_On_Status Then
            strRet = AVPLib.ContainerData.GetMessageText(ConstEnum.LL_FORELINE_VALVE_OPEN_FAILED)
            GoTo ENDFUNC
        End If

        '' 0009760: Foreline/rough valve should not be allow to open when TM's pump is not on and pressure is not reach.
        Dim objTM As DataManagerment.CassettesModule = CType(EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString()), DataManagerment.CassettesModule)
        If objTM IsNot Nothing AndAlso objTM.OverideModeStatus = DataManagerment.Equipment.WorkingStatuses.On Then
            GoTo ENDFUNC
        End If

        Dim objRoughPump As DataManagerment.RoughPumpMachine = EquipmentManager.GetRoughPumpMachine(Equipments.LoadLockA.ToString())
        If (objRoughPump IsNot Nothing) Then
            Dim PumpStatus As Equipment.WorkingStatuses = IIf(objRoughPump.Name = ConstEnum.Equipments.RoughPumpMachine1.ToString, objTM.RoughPump1Status, objTM.RoughPump2Status)
            If Not PumpStatus = Equipment.WorkingStatuses.On Then
                strRet = MECHANICAL_PUMP_NOT_ON
                GoTo ENDFUNC
            End If

            If (Not objRoughPump.CG < ConstEnum.ExpectedMechanicalPumpPressureWhenPumpDown) Then
                strRet = String.Format(MECHANICAL_PUMP_PRESSURE_NOT_REACH, ConstEnum.ExpectedMechanicalPumpPressureWhenPumpDown)
                GoTo ENDFUNC
            End If
        End If

        strRet = String.Empty
ENDFUNC:
        AVPLib.Log.coreLogger.Info("Leave CheckCondition2OpenLLForeLine" + strRet)
        Return strRet
    End Function

    ''' <author>
    ''' <name> Hoai Ly </name>
    ''' <date>2016-07-21</date>
    ''' </author>
    ''' <summary>
    ''' Check the condition to open the TM ForeLine Valve
    ''' true if meet the condition 
    ''' </summary>
    ''' <remarks></remarks>
    Public Function CheckCondition2OpenTMForeLine() As String
        AVPLib.Log.coreLogger.Info("Enter CheckCondition2OpenTMForeLine")
        Dim strRet As String = String.Empty

        Try
            '' 0009760: Foreline/rough valve should not be allow to open when TM's pump is not on and pressure is not reach.
            Dim objTM As DataManagerment.CassettesModule = CType(EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString()), DataManagerment.CassettesModule)
            If objTM IsNot Nothing AndAlso objTM.OverideModeStatus = DataManagerment.Equipment.WorkingStatuses.On Then
                Exit Try
            End If

            Dim objRoughPump As DataManagerment.RoughPumpMachine = EquipmentManager.GetRoughPumpMachine(Equipments.CassettesModule.ToString())
            If (objRoughPump IsNot Nothing) Then
                Dim PumpStatus As Equipment.WorkingStatuses = IIf(objRoughPump.Name = ConstEnum.Equipments.RoughPumpMachine1.ToString, objTM.RoughPump1Status, objTM.RoughPump2Status)
                If Not PumpStatus = Equipment.WorkingStatuses.On Then
                    strRet = MECHANICAL_PUMP_NOT_ON
                    Exit Try
                End If

                If (Not objRoughPump.CG < ConstEnum.ExpectedMechanicalPumpPressureWhenPumpDown) Then
                    strRet = String.Format(MECHANICAL_PUMP_PRESSURE_NOT_REACH, ConstEnum.ExpectedMechanicalPumpPressureWhenPumpDown)
                    Exit Try
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        AVPLib.Log.coreLogger.Info("Leave CheckCondition2OpenTMForeLine" + strRet)
        Return strRet
    End Function

    'Private Sub TMHivacValve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HivacValveTM.Click
    '    Try
    '        If HivacValveTM.Status = RoundRectangleStatusControl.DisplayStatus.Closed Then
    '            Me.TMCtl.HivacOpenButton_Click(sender, e) 'Open Valve
    '        ElseIf HivacValveTM.Status = RoundRectangleStatusControl.DisplayStatus.Opened Then
    '            Me.TMCtl.ibsHivacButton_Click(sender, e) 'Close Valve
    '        Else
    '            Dim strMessageText As String = AVPLib.ContainerData.GetMessageText(HivacValveTM.Name & "Unknown")
    '            Dim dlgRes As DialogResult = Utils.ShowAVPMessageBox(strMessageText, Equipments.CassettesModule.ToString(), MessageBoxIcon.Question, AVPMessageBox.AVPMessageBoxButton.OpenCloseCancel) 'MessageBoxButtons.YesNoCancel)
    '            If dlgRes = DialogResult.Cancel Then
    '                Exit Sub
    '            ElseIf dlgRes = DialogResult.No Then 'close
    '                Me.TMCtl.ibsHivacButton_Click(sender, e)
    '            ElseIf dlgRes = DialogResult.OK Then ''open
    '                Me.TMCtl.HivacOpenButton_Click(sender, e) 'Open Valve
    '            End If
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-01</date>
    ''' </author>
    ''' <summary>
    ''' Event for Hivac Valve Click (from Transfer Screen) (LlA and LLB)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub HivacValve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HivacValveTM.Click, HivacValveLLA.Click

        AVPLib.Log.guiLogger.Info("Enter HivacValve_Click")
        Dim strValue As String = String.Empty
        Dim hivacValve As SlitValve = CType(sender, SlitValve)
        Try
            Dim dlgRes As DialogResult
            Dim strMessageText As String = String.Empty
            Dim strChamberName As String = GetChamberName(hivacValve.Name, strValue)
            ''get equipment to check condition
            Dim eq As DataManagerment.Equipment = DataManagerment.EquipmentManager.GetEquipment(strValue)

            'check status of Valve to get MessageText from config file
            If (hivacValve.Status = BinaryStatusControl.DisplayStatus.On) Then 'Opened
                strMessageText = AVPLib.ContainerData.GetMessageText(hivacValve.Name & STRING_CLOSE)

                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen,
                             ConstantAndEnum.TM_SCREEN & " - Close Hivac Valve of " & strChamberName)
                If Utils.ShowAVPMessageBox(strMessageText, strChamberName, MessageBoxIcon.Question, MessageBoxButtons.OKCancel) = DialogResult.OK Then
                    strValue = STR_OFF
                    Exit Try
                Else
                    Exit Sub
                End If
            ElseIf (hivacValve.Status = BinaryStatusControl.DisplayStatus.Unknown) Then 'unknown
                strMessageText = AVPLib.ContainerData.GetMessageText(hivacValve.Name & "Unknown")
            ElseIf (hivacValve.Status = BinaryStatusControl.DisplayStatus.Off) Then 'Closed
                strMessageText = AVPLib.ContainerData.GetMessageText(hivacValve.Name & STRING_OPEN)

                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen,
                             ConstantAndEnum.TM_SCREEN & " - Open Hivac Valve of " & strChamberName)
                If Utils.ShowAVPMessageBox(strMessageText, strChamberName, MessageBoxIcon.Question, MessageBoxButtons.YesNo) = DialogResult.OK Then
                    GoTo CheckCondition2Open
                Else
                    Exit Sub
                End If
            End If

            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen,
                                        ConstantAndEnum.TM_SCREEN & " - Clicked on Hivac Valve of " & strChamberName)

            dlgRes = Utils.ShowAVPMessageBox(strMessageText, strChamberName, MessageBoxIcon.Question, AVPMessageBox.AVPMessageBoxButton.OpenCloseCancel) 'MessageBoxButtons.YesNoCancel)
            If dlgRes = DialogResult.Cancel Then
                Exit Sub
            ElseIf dlgRes = DialogResult.No Then 'close
                strValue = STR_OFF
                Exit Try
            ElseIf dlgRes = DialogResult.OK Then ''open
                GoTo CheckCondition2Open
            End If

CheckCondition2Open:
            If eq.Name = Equipments.LoadLockA.ToString() Then
                If (m_TM_Protected_Mode.Status = ProtectedModStatus.Off) Then ' if not Protected mode then check condition
                    Dim loadlock As DataManagerment.LoadLock = CType(eq, DataManagerment.LoadLock)
                    Dim strResult As String = loadlock.CheckCondition2OpenLLHiVac()
                    ''button is off->check condition of TM Hivac
                    If strResult = String.Empty Then
                        ''if pass-->we have value for strValue
                        strValue = STR_ON
                    Else '''''''if has error message
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen,
                                    ConstantAndEnum.TM_SCREEN & " - Check conditions to open Hivac Valve of " & strChamberName & " has errors.")
                        AVPLib.Utils.ThrowAlarm(strResult)
                    End If
                Else
                    strValue = STR_ON
                End If
            ElseIf eq.Name = Equipments.CassettesModule.ToString() Then
                If (m_TM_Protected_Mode.Status = ProtectedModStatus.Off) Then
                    Dim cassette As DataManagerment.CassettesModule = CType(eq, DataManagerment.CassettesModule)
                    Dim strResult As String = cassette.checkCondition2OpenTMHiVac()
                    ''button is off->check condition of TM Hivac
                    If strResult = String.Empty Then
                        ''if pass-->we have value for strValue
                        strValue = STR_ON
                    Else '''''''if has error message
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen,
                                    ConstantAndEnum.TM_SCREEN & " - Check conditions to open Hivac Valve of " & strChamberName & " has errors.")
                        AVPLib.Utils.ThrowAlarm(strResult)
                    End If
                Else
                    strValue = STR_ON
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        If Not (String.IsNullOrEmpty(strValue)) Then
            m_stoStatusObject.RequestStatus(hivacValve.Name, strValue)
        End If
        AVPLib.Log.guiLogger.Info("Leave HivacValve_Click")
    End Sub

#End Region

#Region "button Hammer"
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-01</date>
    ''' </author>
    ''' <summary>
    ''' Event for btnMechineTool_Click (from Transfer Screen)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnMechineTool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMechineTool.Click
        AVPLib.Log.guiLogger.Info("Enter btnMechineTool_Click")
        Try
            'Dim pos As New System.Drawing.Point(btnMechineTool.Location)
            'pos.Y += btnMechineTool.Height
            'pos = Me.PointToScreen(pos)
            'cmsMechineTool.Show(pos)

            PopUpPanel.StartPosition = FormStartPosition.CenterScreen
            PopUpPanel.ShowDialog(AVPRobotMain)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnMechineTool_Click")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-01</date>
    ''' </author>
    ''' <summary>
    ''' Handle click on Left Tool button  (from Transfer Screen)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnLeftTool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeftTool.Click
        AVPLib.Log.guiLogger.Info("Enter btnLeftTool_Click")
        Try
            'Dim pos As New System.Drawing.Point(btnLeftTool.Location)
            'pos.Y += btnLeftTool.Height
            'pos = Me.PointToScreen(pos)
            'cmsLeftTool.Show(pos)
            '  Dim avpMainForm As AVPRobotMain = CType(AVP_Robot_Project.MainForm, AVPRobotMain)
            PopUpPanel.StartPosition = FormStartPosition.CenterScreen
            PopUpPanel.ShowDialog(AVPRobotMain)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnLeftTool_Click")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-01</date>
    ''' </author>
    ''' <summary>
    ''' Handle click on Right Tool button  (from Transfer Screen)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnRightTool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRightTool.Click
        AVPLib.Log.guiLogger.Info("Enter btnRightTool_Click")
        Try
            'Dim pos As New System.Drawing.Point(btnRightTool.Location)
            'pos.Y += btnRightTool.Height
            'pos = Me.PointToScreen(pos)
            'cmsRightTool.Show(pos)
            PopUpPanel.StartPosition = FormStartPosition.CenterScreen
            PopUpPanel.ShowDialog(AVPRobotMain)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnRightTool_Click")
    End Sub
#End Region

#Region "Tool Mechine, Left, Right Click"

    ''' <author>
    '''    	<name> Vo Tan Dat </name>
    '''    	<date> 2010-03-31</date>
    ''' </author>
    ''' <summary>
    ''' Go Online
    ''' </summary>
    ''' <param name=""></param>
    ''' <param name=""></param>
    ''' <remarks></remarks>
    Public Overridable Sub GoOnline()

        ' TM
        If ContainerForm.CassettesPanel.PopUpPanel.btnTMOnline.Status = SL_CustomButton.DisplayStatus.Off Then
            ContainerForm.CassettesPanel.SetTMOnline(True)
            ContainerForm.CassettesPanel.PopUpPanel.blnGoOnline = True
            ContainerForm.CassettesPanel.PopUpPanel.Make_Online(ContainerForm.CassettesPanel.PopUpPanel.btnTMOnline, False)
        End If

        ' Load Lock A
        If ContainerForm.CassettesPanel.PopUpPanel.btnLLAOnline.Status = SL_CustomButton.DisplayStatus.Off Then
            ContainerForm.CassettesPanel.SetLLAOnline(True)
            ContainerForm.CassettesPanel.PopUpPanel.blnGoOnline = True
            ContainerForm.CassettesPanel.PopUpPanel.Make_Online(ContainerForm.CassettesPanel.PopUpPanel.btnLLAOnline, False)
        End If

        ContainerForm.CassettesPanel.PopUpPanel.blnGoOnline = False
    End Sub

    '''' <author>
    ''''    	<name> Le Hieu Truc </name>
    ''''    	<date> 2010-02-01</date>
    '''' </author>
    '''' <summary>
    '''' Click on Online menu item of machine  (from Transfer Screen)
    '''' </summary>
    '''' <param name="sender"></param>
    '''' <param name="e"></param>
    '''' <remarks></remarks>
    'Private Sub mnuOnline_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMechineOnline.Click, mnuLeftOnline.Click, mnuRightOnline.Click
    '    AVPLib.Log.guiLogger.Info("Enter mnuOnline_Click")
    '    Dim strMessageText As String = String.Empty
    '    Try
    '        Dim ToolStripMenu As ToolStripMenuItem = CType(sender, System.Windows.Forms.ToolStripMenuItem)
    '        'Me.DisableOnline(ToolStripMenu)
    '        ' Disable relevant buttons in Cassette Control.
    '        If ToolStripMenu.Name = LEFTONLINE Then 'mnuLeftOnline
    '            strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuOnlineOfCassettesPanel"), ONLINELOADLOCKA)
    '            If (Utils.ShowAVPMessageBox(strMessageText, ONLINELOADLOCKA, MessageBoxIcon.Question) = DialogResult.OK) Then
    '                ContainerForm.CassettesPanel.SetLLAOnline(True)
    '                m_stoStatusObject.RequestStatus(ToolStripMenu.Name, AVP_Robot_Project.ConstantAndEnum.CLICK)
    '                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Robot & Cassette] Bring LLA online")
    '            End If
    '        ElseIf ToolStripMenu.Name = RIGHTONLINE Then 'mnuRightOnline
    '            strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuOnlineOfCassettesPanel"), ONLINELOADLOCKB)
    '            If (Utils.ShowAVPMessageBox(strMessageText, ONLINELOADLOCKB, MessageBoxIcon.Question) = DialogResult.OK) Then
    '                ContainerForm.CassettesPanel.SetLLBOnline(True)
    '                m_stoStatusObject.RequestStatus(ToolStripMenu.Name, AVP_Robot_Project.ConstantAndEnum.CLICK)
    '                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Robot & Cassette] Bring LLB online")
    '            End If
    '        ElseIf ToolStripMenu.Name = MECHINEONLINE Then
    '            strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuOnlineOfCassettesPanel"), ONLINETM)
    '            If (Utils.ShowAVPMessageBox(strMessageText, ONLINETM, MessageBoxIcon.Question) = DialogResult.OK) Then
    '                ContainerForm.CassettesPanel.SetTMOnline(True)
    '                m_stoStatusObject.RequestStatus(ToolStripMenu.Name, AVP_Robot_Project.ConstantAndEnum.CLICK)
    '                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Robot & Cassette] Bring TM online")
    '            End If
    '        End If
    '    Catch ex As Exception
    '        AVPLib.Log.avpLogger.Error(ex.ToString())
    '    End Try
    '    AVPLib.Log.guiLogger.Info("Leave mnuOnline_Click")
    'End Sub
    '''' <author>
    ''''    	<name> Le Hieu Truc </name>
    ''''    	<date> 2010-02-01</date>
    '''' </author>
    '''' <summary>
    '''' Click on Offline menu item of machine (from Transfer Screen)
    '''' </summary>
    '''' <param name="sender"></param>
    '''' <param name="e"></param>
    '''' <remarks></remarks>
    'Private Sub mnuOffline_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMechineOffline.Click, mnuLeftOffline.Click, mnuRightOffline.Click
    '    AVPLib.Log.guiLogger.Info("Enter mnuOffline_Click")
    '    Dim strMessageText As String = String.Empty
    '    Try
    '        Dim ToolStripMenu As ToolStripMenuItem = CType(sender, System.Windows.Forms.ToolStripMenuItem)
    '        '' Allow users to manipulate valves.
    '        Select Case ToolStripMenu.Name
    '            Case mnuMechineOffline.Name
    '                strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuOfflineOfCassettesPanel"), ONLINETM)
    '                If (Utils.ShowAVPMessageBox(strMessageText, ONLINETM, MessageBoxIcon.Question) = DialogResult.OK) Then
    '                    Me.MechineValveStatus(True)
    '                    ContainerForm.CassettesPanel.SetTMOnline(False)
    '                    m_stoStatusObject.RequestStatus(ToolStripMenu.Name, AVP_Robot_Project.ConstantAndEnum.CLICK)
    '                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Robot & Cassette] Bring TM offline")
    '                End If
    '            Case mnuLeftOffline.Name
    '                strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuOfflineOfCassettesPanel"), ONLINELOADLOCKA)
    '                If (Utils.ShowAVPMessageBox(strMessageText, ONLINELOADLOCKA, MessageBoxIcon.Question) = DialogResult.OK) Then
    '                    Me.LeftValveStatus(True)
    '                    ContainerForm.CassettesPanel.SetLLAOnline(False)
    '                    m_stoStatusObject.RequestStatus(ToolStripMenu.Name, AVP_Robot_Project.ConstantAndEnum.CLICK)
    '                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Robot & Cassette] Bring LLA offline")
    '                End If
    '            Case mnuRightOffline.Name
    '                strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuOfflineOfCassettesPanel"), ONLINELOADLOCKB)
    '                If (Utils.ShowAVPMessageBox(strMessageText, ONLINELOADLOCKB, MessageBoxIcon.Question) = DialogResult.OK) Then
    '                    Me.RightValveStatus(True)
    '                    ContainerForm.CassettesPanel.SetLLBOnline(False)
    '                    m_stoStatusObject.RequestStatus(ToolStripMenu.Name, AVP_Robot_Project.ConstantAndEnum.CLICK)
    '                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Robot & Cassette] Bring LLB offline")
    '                End If
    '        End Select
    '    Catch ex As Exception
    '        AVPLib.Log.avpLogger.Error(ex.ToString())
    '    End Try
    '    AVPLib.Log.guiLogger.Info("Leave mnuOffline_Click")
    'End Sub
    '''' <author>
    ''''    	<name> Le Hieu Truc </name>
    ''''    	<date> 2010-02-01</date>
    '''' </author>
    '''' <summary>
    '''' Click on Pumb down menu item of machine (from Transfer Screen)
    '''' </summary>
    '''' <param name="sender"></param>
    '''' <param name="e"></param>
    '''' <remarks></remarks>
    'Private Sub mnuPumpDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMechinePumpDown.Click, mnuLeftPumpDown.Click, mnuRightPumpDown.Click
    '    AVPLib.Log.guiLogger.Info("Enter mnuPumpDown_Click")
    '    Dim strMessageText As String = String.Empty
    '    Try
    '        Dim ToolStripMenu As ToolStripMenuItem = CType(sender, System.Windows.Forms.ToolStripMenuItem)
    '        ' Run pumpdown Process.
    '        ' Enable and disables Lock Process Control buttons.
    '        Select Case ToolStripMenu.Name
    '            Case mnuMechinePumpDown.Name
    '                strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuPumpDownOfCassettesPanel"), ONLINETM)
    '                If (Utils.ShowAVPMessageBox(strMessageText, ONLINETM, MessageBoxIcon.Question) = DialogResult.OK) Then
    '                    m_stoStatusObject.RequestStatus(ToolStripMenu.Name, AVP_Robot_Project.ConstantAndEnum.CLICK)
    '                    'Me.PumpDown(ToolStripMenu, STR_OFF)
    '                    ' Pulse Event
    '                    m_evtTMVentPumpdownInProgress.Set()
    '                    Me.LockLoadARobotCassettes(False)
    '                    Me.LockLoadBRobotCassettes(False)
    '                    ContainerForm.Diagnostic.tabDiag_TM.Enabled = False
    '                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Robot & Cassette] Start TM Pump down")
    '                End If
    '            Case mnuLeftPumpDown.Name
    '                strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuPumpDownOfCassettesPanel"), ONLINELOADLOCKA)
    '                If (Utils.ShowAVPMessageBox(strMessageText, ONLINELOADLOCKA, MessageBoxIcon.Question) = DialogResult.OK) Then
    '                    m_stoStatusObject.RequestStatus(ToolStripMenu.Name, AVP_Robot_Project.ConstantAndEnum.CLICK)
    '                    'Me.PumpDown(ToolStripMenu, STR_OFF)
    '                    ' Pulse Event
    '                    m_evtLLAVentPumpdownInProgress.Set()
    '                    Me.LockLoadARobotCassettes(False)
    '                    ContainerForm.Diagnostic.tabDiag_LLA.Enabled = False
    '                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Robot & Cassette] Start LLA Pump down")
    '                End If
    '            Case mnuRightPumpDown.Name
    '                strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuPumpDownOfCassettesPanel"), ONLINELOADLOCKB)
    '                If (Utils.ShowAVPMessageBox(strMessageText, ONLINELOADLOCKB, MessageBoxIcon.Question) = DialogResult.OK) Then
    '                    m_stoStatusObject.RequestStatus(ToolStripMenu.Name, AVP_Robot_Project.ConstantAndEnum.CLICK)
    '                    'Me.PumpDown(ToolStripMenu, STR_OFF)
    '                    ' Pulse Event
    '                    m_evtLLBVentPumpdownInProgress.Set()
    '                    Me.LockLoadBRobotCassettes(False)
    '                    ContainerForm.Diagnostic.tabDiag_LLB.Enabled = False
    '                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Robot & Cassette] Start LLB Pump down")
    '                End If
    '        End Select
    '    Catch ex As Exception
    '        AVPLib.Log.avpLogger.Error(ex.ToString())
    '    End Try
    '    AVPLib.Log.guiLogger.Info("Leave mnuPumpDown_Click")
    'End Sub
    '''' <author>
    ''''    	<name> Le Hieu Truc </name>
    ''''    	<date> 2010-02-01</date>
    '''' </author>
    '''' <summary>
    '''' Click on Stop pumb down menu item of machine (from Transfer Screen)
    '''' </summary>
    '''' <param name="sender"></param>
    '''' <param name="e"></param>
    '''' <remarks></remarks>
    'Private Sub mnuStopPumpDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMechineStopPumpDown.Click, mnuLeftStopPumpDown.Click, mnuRightStopPumpDown.Click
    '    AVPLib.Log.guiLogger.Info("Enter mnuStopPumpDown_Click")
    '    Dim strMessageText As String = String.Empty
    '    Try
    '        Dim ToolStripMenu As ToolStripMenuItem = CType(sender, System.Windows.Forms.ToolStripMenuItem)

    '        Select Case ToolStripMenu.Name
    '            Case mnuMechineStopPumpDown.Name
    '                strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuStopPumpDownOfCassettesPanel"), ONLINETM)
    '                If (Utils.ShowAVPMessageBox(strMessageText, ONLINETM, MessageBoxIcon.Question) = DialogResult.OK) Then
    '                    m_stoStatusObject.RequestStatus(ToolStripMenu.Name, AVP_Robot_Project.ConstantAndEnum.CLICK)
    '                    'Me.PumpDown(ToolStripMenu, STR_ON)
    '                    ' Reset Event
    '                    m_evtTMVentPumpdownInProgress.Reset()
    '                    Me.LockLoadARobotCassettes(True)
    '                    Me.LockLoadBRobotCassettes(True)
    '                    ContainerForm.Diagnostic.tabDiag_TM.Enabled = True
    '                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Robot & Cassette] Stop TM Pump down")
    '                End If
    '            Case mnuLeftStopPumpDown.Name
    '                strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuStopPumpDownOfCassettesPanel"), ONLINELOADLOCKA)
    '                If (Utils.ShowAVPMessageBox(strMessageText, ONLINELOADLOCKA, MessageBoxIcon.Question) = DialogResult.OK) Then
    '                    m_stoStatusObject.RequestStatus(ToolStripMenu.Name, AVP_Robot_Project.ConstantAndEnum.CLICK)
    '                    ' Me.PumpDown(ToolStripMenu, STR_ON)
    '                    ' Reset
    '                    m_evtLLAVentPumpdownInProgress.Reset()
    '                    Me.LockLoadARobotCassettes(True)
    '                    ContainerForm.Diagnostic.tabDiag_LLA.Enabled = True
    '                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Robot & Cassette] Stop LLA Pump down")
    '                End If
    '            Case mnuRightStopPumpDown.Name
    '                strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuStopPumpDownOfCassettesPanel"), ONLINELOADLOCKB)
    '                If (Utils.ShowAVPMessageBox(strMessageText, ONLINELOADLOCKB, MessageBoxIcon.Question) = DialogResult.OK) Then
    '                    m_stoStatusObject.RequestStatus(ToolStripMenu.Name, AVP_Robot_Project.ConstantAndEnum.CLICK)
    '                    '  Me.PumpDown(ToolStripMenu, STR_ON)
    '                    ' Reset Event
    '                    m_evtLLBVentPumpdownInProgress.Reset()
    '                    Me.LockLoadBRobotCassettes(True)
    '                    ContainerForm.Diagnostic.tabDiag_LLB.Enabled = True
    '                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Robot & Cassette] Stop LLB Pump down")
    '                End If
    '        End Select
    '    Catch ex As Exception
    '        AVPLib.Log.avpLogger.Error(ex.ToString())
    '    End Try
    '    AVPLib.Log.guiLogger.Info("Leave mnuStopPumpDown_Click")
    'End Sub
    '''' <author>
    ''''    	<name> Le Hieu Truc </name>
    ''''    	<date> 2010-02-01</date>
    '''' </author>
    '''' <summary>
    '''' Click on vent menu item of machine (from Transfer Screen)
    '''' </summary>
    '''' <param name="sender"></param>
    '''' <param name="e"></param>
    '''' <remarks></remarks>
    'Private Sub mnuVent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMechineVent.Click, mnuLeftVent.Click, mnuRightVent.Click
    '    AVPLib.Log.guiLogger.Info("Enter mnuVent_Click")
    '    Dim strMessageText As String = String.Empty
    '    Try
    '        Dim ToolStripMenu As ToolStripMenuItem = CType(sender, System.Windows.Forms.ToolStripMenuItem)
    '        Select Case ToolStripMenu.Name
    '            Case mnuMechineVent.Name
    '                strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuVentOfCassettesPanel"), ONLINETM)
    '                If (Utils.ShowAVPMessageBox(strMessageText, ONLINETM, MessageBoxIcon.Question) = DialogResult.OK) Then
    '                    m_stoStatusObject.RequestStatus(ToolStripMenu.Name, AVP_Robot_Project.ConstantAndEnum.CLICK)
    '                    'Me.Vent(ToolStripMenu, STR_OFF)
    '                    ' Pulse Event
    '                    m_evtTMVentPumpdownInProgress.Set()
    '                    Me.LockLoadARobotCassettes(False)
    '                    Me.LockLoadBRobotCassettes(False)
    '                    ContainerForm.Diagnostic.tabDiag_TM.Enabled = False
    '                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Robot & Cassette] Start TM Vent")
    '                End If
    '            Case mnuLeftVent.Name
    '                strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuVentOfCassettesPanel"), ONLINELOADLOCKA)
    '                If (Utils.ShowAVPMessageBox(strMessageText, ONLINELOADLOCKA, MessageBoxIcon.Question) = DialogResult.OK) Then
    '                    m_stoStatusObject.RequestStatus(ToolStripMenu.Name, AVP_Robot_Project.ConstantAndEnum.CLICK)
    '                    'Me.Vent(ToolStripMenu, STR_OFF)
    '                    ' Pulse Event
    '                    m_evtLLAVentPumpdownInProgress.Set()
    '                    Me.LockLoadARobotCassettes(False)
    '                    ContainerForm.Diagnostic.tabDiag_LLA.Enabled = False
    '                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Robot & Cassette] Start LLA Vent")

    '                End If
    '            Case mnuRightVent.Name
    '                strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuVentOfCassettesPanel"), ONLINELOADLOCKB)
    '                If (Utils.ShowAVPMessageBox(strMessageText, ONLINELOADLOCKB, MessageBoxIcon.Question) = DialogResult.OK) Then
    '                    m_stoStatusObject.RequestStatus(ToolStripMenu.Name, AVP_Robot_Project.ConstantAndEnum.CLICK)
    '                    'Me.Vent(ToolStripMenu, STR_OFF)
    '                    ' Pulse Event
    '                    m_evtLLBVentPumpdownInProgress.Set()
    '                    Me.LockLoadBRobotCassettes(False)
    '                    ContainerForm.Diagnostic.tabDiag_LLB.Enabled = False
    '                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Robot & Cassette] Start LLB Vent")

    '                End If
    '        End Select
    '    Catch ex As Exception
    '        AVPLib.Log.avpLogger.Error(ex.ToString())
    '    End Try
    '    AVPLib.Log.guiLogger.Info("Leave mnuVent_Click")
    'End Sub
    '''' <author>
    ''''    	<name> Le Hieu Truc </name>
    ''''    	<date> 2010-02-01</date>
    '''' </author>
    '''' <summary>
    '''' Click on stop vent menu item of machine (from Transfer Screen)
    '''' </summary>
    '''' <param name="sender"></param>
    '''' <param name="e"></param>
    '''' <remarks></remarks>
    'Private Sub mnuStopVent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMechineStopVent.Click, mnuLeftStopVent.Click, mnuRightStopVent.Click
    '    AVPLib.Log.guiLogger.Info("Enter mnuStopVent_Click")
    '    Dim strMessageText As String = String.Empty
    '    Try
    '        Dim ToolStripMenu As ToolStripMenuItem = CType(sender, System.Windows.Forms.ToolStripMenuItem)
    '        'm_stoStatusObject.RequestStatus(ToolStripMenu.Name, AVP_Robot_Project.ConstantAndEnum.CLICK)
    '        'Me.Vent(ToolStripMenu, AVP_Robot_Project.ConstantAndEnum.STR_ON)
    '        Select Case ToolStripMenu.Name
    '            Case mnuMechineStopVent.Name
    '                strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuStopVentOfCassettesPanel"), ONLINETM)
    '                If (Utils.ShowAVPMessageBox(strMessageText, ONLINETM, MessageBoxIcon.Question) = DialogResult.OK) Then
    '                    m_stoStatusObject.RequestStatus(ToolStripMenu.Name, AVP_Robot_Project.ConstantAndEnum.CLICK)
    '                    'Me.Vent(ToolStripMenu, STR_ON)
    '                    ' Pulse Event
    '                    m_evtTMVentPumpdownInProgress.Reset()
    '                    Me.LockLoadARobotCassettes(True)
    '                    Me.LockLoadBRobotCassettes(True)
    '                    ContainerForm.Diagnostic.tabDiag_TM.Enabled = True
    '                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Robot & Cassette] Stop TM Vent")

    '                End If
    '            Case mnuLeftStopVent.Name
    '                strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuStopVentOfCassettesPanel"), ONLINELOADLOCKA)
    '                If (Utils.ShowAVPMessageBox(strMessageText, ONLINELOADLOCKA, MessageBoxIcon.Question) = DialogResult.OK) Then
    '                    m_stoStatusObject.RequestStatus(ToolStripMenu.Name, AVP_Robot_Project.ConstantAndEnum.CLICK)
    '                    ' Me.Vent(ToolStripMenu, STR_ON)
    '                    ' Pulse Event
    '                    m_evtLLAVentPumpdownInProgress.Reset()
    '                    Me.LockLoadARobotCassettes(True)
    '                    ContainerForm.Diagnostic.tabDiag_LLA.Enabled = True
    '                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Robot & Cassette] Stop LLA Vent")

    '                End If
    '            Case mnuRightStopVent.Name
    '                ' Pulse Event
    '                strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("MenuStopVentOfCassettesPanel"), ONLINELOADLOCKB)
    '                If (Utils.ShowAVPMessageBox(strMessageText, ONLINELOADLOCKB, MessageBoxIcon.Question) = DialogResult.OK) Then
    '                    m_stoStatusObject.RequestStatus(ToolStripMenu.Name, AVP_Robot_Project.ConstantAndEnum.CLICK)
    '                    'Me.Vent(ToolStripMenu, STR_ON)
    '                    m_evtLLBVentPumpdownInProgress.Reset()
    '                    Me.LockLoadBRobotCassettes(True)
    '                    ContainerForm.Diagnostic.tabDiag_LLB.Enabled = True
    '                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Robot & Cassette] Stop LLB Vent")

    '                End If
    '        End Select
    '    Catch ex As Exception
    '        AVPLib.Log.avpLogger.Error(ex.ToString())
    '    End Try
    '    AVPLib.Log.guiLogger.Info("Leave mnuStopVent_Click")
    'End Sub
#End Region
#End Region

#Region "Function Support"
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-01</date>
    ''' </author>
    ''' <summary>
    ''' GetChamberName base on MesaValve  
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Function GetChamberName(ByVal MesaValveName As String, ByRef strChamber As String)
        Dim strChamberName As String = String.Empty
        Select Case MesaValveName
            Case MESA_VALVE_PM1
                strChamberName = AVPLib.RobotConfigurationValues.CHAMBER1_NAME
                strChamber = Equipments.Chamber1.ToString()
            Case MESA_VALVE_PM2
                strChamberName = AVPLib.RobotConfigurationValues.CHAMBER2_NAME
                strChamber = Equipments.Chamber2.ToString()
            Case MESA_VALVE_PM3
                strChamberName = AVPLib.RobotConfigurationValues.CHAMBER3_NAME
                strChamber = Equipments.Chamber3.ToString()
            Case MESA_VALVE_LLA, "HivacValveLLA"
                strChamberName = LLA_STR
                strChamber = Equipments.LoadLockA.ToString()
            Case "ibsHivacButton", "HivacValveTM"
                strChamberName = TM_STR
                strChamber = Equipments.CassettesModule.ToString()
        End Select
        Return strChamberName
    End Function
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-01</date>
    ''' </author>
    ''' <summary>
    ''' Set enable MesaValve (from Transfer Screen)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub MechineValveStatus(ByVal blnEnnable)
        Try
            ibsHivacButton.Enabled = IsAllowEnable(Not blnEnnable)
            MesaValvePM1.Enabled = IsAllowEnable(Not blnEnnable)
            MesaValvePM2.Enabled = IsAllowEnable(Not blnEnnable)
            MesaValvePM3.Enabled = IsAllowEnable(Not blnEnnable)
            ValveVent.Enabled = IsAllowEnable(Not blnEnnable)
            ValveRough.Enabled = IsAllowEnable(Not blnEnnable)
            ValveTMTurbo.Enabled = IsAllowEnable(Not blnEnnable)
            btnTurboTM.Enabled = IsAllowEnable(Not blnEnnable)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-01</date>
    ''' </author>
    ''' <summary>
    ''' Set enable MesaValve (from Transfer Screen)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub LeftValveStatus(ByVal blnEnnable)
        Try
            MesaValveLLA.Enabled = IsAllowEnable(Not blnEnnable)
            HivacValveLLA.Enabled = IsAllowEnable(Not blnEnnable)
            ValveLLASlowVent.Enabled = IsAllowEnable(Not blnEnnable)
            ValveLLAFastVent.Enabled = IsAllowEnable(Not blnEnnable)
            ValveLLASlowRough.Enabled = IsAllowEnable(Not blnEnnable)
            ValveLLAFastRough.Enabled = IsAllowEnable(Not blnEnnable)
            ValveLLATurbo.Enabled = IsAllowEnable(Not blnEnnable)
            btnTurboLLA.Enabled = IsAllowEnable(Not blnEnnable)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-01</date>
    ''' </author>
    ''' <summary>
    ''' Set enable MesaValve (from Transfer Screen)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub RightValveStatus(ByVal blnEnnable)
        Try
            'MesaValveLLB.Enabled = IsAllowEnable(Not blnEnnable)
            'HivacValveLLB.Enabled = IsAllowEnable(Not blnEnnable)
            'ValveLLBSlowRough.Enabled = IsAllowEnable(Not blnEnnable)
            'ValveLLBFastRough.Enabled = IsAllowEnable(Not blnEnnable)
            'ValveLLBSlowVent.Enabled = IsAllowEnable(Not blnEnnable)
            'ValveLLBFastVent.Enabled = IsAllowEnable(Not blnEnnable)
            'ValveLLBTurbo.Enabled = IsAllowEnable(Not blnEnnable)
            'btnTurboLLB.Enabled = IsAllowEnable(Not blnEnnable)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-01</date>
    ''' </author>
    ''' <summary>
    ''' PumpDown (from Transfer Screen)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Friend Sub PumpDown(ByVal isLLA As Boolean, ByVal isTM As Boolean, ByVal value As String)
        AVPLib.Log.guiLogger.Info("Enter PumpDown")
        Dim PropertyNames As New ArrayList()
        Dim ReplyValues As New ArrayList()

        PropertyNames.Add("PumpDownStatus")
        If value = STR_ON Then
            ReplyValues.Add(DataManagerment.Equipment.WorkingStatuses.On)
        Else
            ReplyValues.Add(DataManagerment.Equipment.WorkingStatuses.Off)
        End If
        If isLLA Then
            AVPLib.DataManagerment.EquipmentManager.ChangeStatus(ConstantAndEnum.LOAD_LOCK_A, PropertyNames, ReplyValues)
        ElseIf isTM Then
            AVPLib.DataManagerment.EquipmentManager.ChangeStatus("CassettesModule", PropertyNames, ReplyValues)
        End If

        AVPLib.Log.guiLogger.Info("Leave PumpDown")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-01</date>
    ''' </author>
    ''' <summary>
    ''' Set Disable menu and invisible menu (from Transfer Screen)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DisableOnline(ByVal ToolStripMenu As ToolStripMenuItem)
        AVPLib.Log.guiLogger.Info("Enter DisableOnline")
        If ToolStripMenu.Equals(mnuLeftOnline) Then
            Me.SetEnableMenuItemLeftTool(False, False, False, False, False, False)
            Me.SetVisibleMenuItemLeftTool(True, False, True, False, True, False)
        ElseIf ToolStripMenu.Equals(mnuMechineOnline) Then
            Me.SetVisibleMenuItemMechineTool(False, False, False, False, False, False)
            Me.SetVisibleMenuItemMechineTool(True, False, True, False, True, False)
        ElseIf ToolStripMenu.Equals(mnuRightOnline) Then
            Me.SetEnableMenuItemRightTool(False, False, False, False, False, False)
            Me.SetVisibleMenuItemRightTool(True, False, True, False, True, False)
        End If
        AVPLib.Log.guiLogger.Info("Leave DisableOnline")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-01</date>
    ''' </author>
    ''' <summary>
    ''' Vent (from Transfer Screen)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Friend Sub Vent(ByVal isLLA As Boolean, ByVal isTM As Boolean, ByVal value As String)
        AVPLib.Log.guiLogger.Info("Enter Vent")
        Dim PropertyNames As New ArrayList()
        Dim ReplyValues As New ArrayList()

        PropertyNames.Add("AutoVentStatus")
        If value = STR_ON Then
            ReplyValues.Add(DataManagerment.Equipment.WorkingStatuses.On)
        Else
            ReplyValues.Add(DataManagerment.Equipment.WorkingStatuses.Off)
        End If
        If isLLA Then
            AVPLib.DataManagerment.EquipmentManager.ChangeStatus(ConstantAndEnum.LOAD_LOCK_A, PropertyNames, ReplyValues)
        ElseIf isTM Then
            AVPLib.DataManagerment.EquipmentManager.ChangeStatus("CassettesModule", PropertyNames, ReplyValues)
        End If

        AVPLib.Log.guiLogger.Info("Leave Vent")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-01</date>
    ''' </author>
    ''' <summary>
    ''' LockLoadARobotCassettes
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LockLoadARobotCassettes(ByVal blnEnableDisable As Boolean)
        If (blnEnableDisable) Then
            If Not (Me.m_evtLLAVentPumpdownInProgress.WaitOne(0, False)) Then
                ContainerForm.ProcessPanel.lpcLoadLockA.EnableDisableForm(True)
            End If
        Else
            ContainerForm.ProcessPanel.lpcLoadLockA.EnableDisableForm(False)
        End If
    End Sub

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-01</date>
    ''' </author>
    ''' <summary>
    ''' SetVisibleMenuItemMechineTool(from Transfer Screen)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub SetVisibleMenuItemMechineTool(ByVal blnOnline As Boolean, ByVal blnOffline As Boolean, ByVal blnPumpDown As Boolean,
     ByVal blnStopPumpDown As Boolean, ByVal blnVent As Boolean, ByVal blnStopVent As Boolean)
        Try
            mnuMechineOnline.Visible = blnOnline
            mnuMechineOffline.Visible = blnOffline
            mnuMechineOffline.Tag = blnOffline
            mnuMechinePumpDown.Visible = blnPumpDown
            mnuMechineStopPumpDown.Visible = blnStopPumpDown
            mnuMechineVent.Visible = blnVent
            mnuMechineStopVent.Visible = blnStopVent
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-01</date>
    ''' </author>
    ''' <summary>
    ''' show or hide menu item of left tool menu (from Transfer Screen)
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetVisibleMenuItemLeftTool(ByVal blnOnline As Boolean, ByVal blnOffline As Boolean, ByVal blnPumpDown As Boolean,
      ByVal blnStopPumpDown As Boolean, ByVal blnVent As Boolean, ByVal blnStopVent As Boolean)
        Try
            mnuLeftOnline.Visible = blnOnline
            mnuLeftOffline.Visible = blnOffline
            mnuLeftOffline.Tag = blnOffline
            mnuLeftPumpDown.Visible = blnPumpDown
            mnuLeftStopPumpDown.Visible = blnStopPumpDown
            mnuLeftVent.Visible = blnVent
            mnuLeftStopVent.Visible = blnStopVent
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-01</date>
    ''' </author>
    ''' <summary>
    ''' show or hide menu item of right tool menu (from Transfer Screen)
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetVisibleMenuItemRightTool(ByVal blnOnline As Boolean, ByVal blnOffline As Boolean, ByVal blnPumpDown As Boolean,
      ByVal blnStopPumpDown As Boolean, ByVal blnVent As Boolean, ByVal blnStopVent As Boolean)
        Try
            mnuRightOnline.Visible = blnOnline
            mnuRightOffline.Visible = blnOffline
            mnuRightOffline.Tag = blnOffline
            mnuRightPumpDown.Visible = blnPumpDown
            mnuRightStopPumpDown.Visible = blnStopPumpDown
            mnuRightVent.Visible = blnVent
            mnuRightStopVent.Visible = blnStopVent
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-01</date>
    ''' </author>
    ''' <summary>
    ''' enable or disable menu item of mechine tool menu (from Transfer Screen)
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetEnableMenuItemMechineTool(ByVal blnOnline As Boolean, ByVal blnOffline As Boolean, ByVal blnPumpDown As Boolean,
      ByVal blnStopPumpDown As Boolean, ByVal blnVent As Boolean, ByVal blnStopVent As Boolean)
        Try
            mnuMechineOnline.Enabled = blnOnline
            mnuMechineOffline.Enabled = blnOffline
            mnuMechinePumpDown.Enabled = blnPumpDown
            mnuMechineStopPumpDown.Enabled = blnStopPumpDown
            mnuMechineVent.Enabled = blnVent
            mnuMechineStopVent.Enabled = blnStopVent
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-01</date>
    ''' </author>
    ''' <summary>
    ''' enable or disable menu item of left tool menu (from Transfer Screen)
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetEnableMenuItemLeftTool(ByVal blnOnline As Boolean, ByVal blnOffline As Boolean, ByVal blnPumpDown As Boolean,
      ByVal blnStopPumpDown As Boolean, ByVal blnVent As Boolean, ByVal blnStopVent As Boolean)
        Try
            mnuLeftOnline.Enabled = blnOnline
            mnuLeftOffline.Enabled = blnOffline
            mnuLeftPumpDown.Enabled = blnPumpDown
            mnuLeftStopPumpDown.Enabled = blnStopPumpDown
            mnuLeftVent.Enabled = blnVent
            mnuLeftStopVent.Enabled = blnStopVent
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-01</date>
    ''' </author>
    ''' <summary>
    ''' enable or disable menu item of right tool menu (from Transfer Screen)
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetEnableMenuItemRightTool(ByVal blnOnline As Boolean, ByVal blnOffline As Boolean, ByVal blnPumpDown As Boolean,
      ByVal blnStopPumpDown As Boolean, ByVal blnVent As Boolean, ByVal blnStopVent As Boolean)
        Try
            mnuRightOnline.Enabled = blnOnline
            mnuRightOffline.Enabled = blnOffline
            mnuRightPumpDown.Enabled = blnPumpDown
            mnuRightStopPumpDown.Enabled = blnStopPumpDown
            mnuRightVent.Enabled = blnVent
            mnuRightStopVent.Enabled = blnStopVent
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub RoughPumpControl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RoughPumpControl.Click
        'If lblRoughPumpInUse.Tag IsNot Nothing Then
        '    If Utils.ShowAVPMessageBox("Do you want to release Mechanical Pump 1 resource? ", _
        '                               "Release Rough Pump", MessageBoxIcon.Question, _
        '                               MessageBoxButtons.OKCancel) = DialogResult.OK Then
        '        m_stoStatusObject.RequestStatus("ReleaseRoughPump1InUse", lblRoughPumpInUse.Tag.ToString())
        '        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
        '                   "[Main Screen]" & " - Clicked on Rough Pump 1 control to release Mechanical Pump resource")
        '    End If
        'End If

        ''Use kepware to On/Off Mechanical Pump
        'If RoughPumpControl.Status = BinaryStatusControl.DisplayStatus.On Then
        '    If Utils.ShowAVPMessageBox("Do you want to turn off Mechanical Pump 1 ? ", _
        '                               "Mechanical Pump", MessageBoxIcon.Question, _
        '                               MessageBoxButtons.YesNo) = DialogResult.OK Then
        '        m_stoStatusObject.RequestStatus(RoughPumpControl.Name, STR_OFF)
        '        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
        '                   ConstantAndEnum.TM_SCREEN & " - Clicked on Rough Pump 1 control to turn off Mechanical Pump")
        '    End If
        'ElseIf RoughPumpControl.Status = BinaryStatusControl.DisplayStatus.Off Then
        '    If Utils.ShowAVPMessageBox("Do you want to turn on Mechanical Pump 1 ? ", _
        '                                           "Mechanical Pump", MessageBoxIcon.Question, _
        '                                           MessageBoxButtons.YesNo) = DialogResult.OK Then
        '        m_stoStatusObject.RequestStatus(RoughPumpControl.Name, STR_ON)
        '        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
        '                   ConstantAndEnum.TM_SCREEN & " - Clicked on Rough Pump 1 control to turn on Mechanical Pump")
        '    End If
        'End If

        If AVPLib.RobotConfigurationValues.SHARED_MP_WITH_PM Then
            Return
        End If


        If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
            Dim objRoughPumpMachine1 As DataManagerment.RoughPumpMachine =
                                    DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.RoughPumpMachine1.ToString)

            Dim bVisible As Boolean = True
            If objRoughPumpMachine1 IsNot Nothing Then

                If objRoughPumpMachine1.IsUsed(AVPLib.ConstEnum.Equipments.LoadLockA.ToString) Then
                    bVisible = IsAllowActionOnLLA
                ElseIf objRoughPumpMachine1.IsUsed(AVPLib.ConstEnum.Equipments.CassettesModule.ToString) Then
                    bVisible = bVisible Or IsAllowActionOnTM
                End If

                If Not bVisible Then
                    Return
                End If
                If m_Rough1CGGaugesFrm IsNot Nothing Then
                    m_Rough1CGGaugesFrm.IsSetATM = objRoughPumpMachine1.IsSafetySetATM

                    If lblRoughPumpInUse.Tag IsNot Nothing Then
                        m_Rough1CGGaugesFrm.RoughPumpInUse = lblRoughPumpInUse.Tag.ToString()
                    Else
                        m_Rough1CGGaugesFrm.RoughPumpInUse = Nothing
                    End If
                    m_Rough1CGGaugesFrm.ShowDialog(AVPRobotMain)
                End If
            End If

        End If
    End Sub
    Private Sub RoughPumpControl2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RoughPumpControl2.Click
        'If lblRoughPumpInUse_2.Tag IsNot Nothing Then
        '    If Utils.ShowAVPMessageBox("Do you want to release Mechanical Pump 2 resource? ", _
        '                               "Release Rough Pump", MessageBoxIcon.Question, _
        '                               MessageBoxButtons.OKCancel) = DialogResult.OK Then
        '        m_stoStatusObject.RequestStatus("ReleaseRoughPump2InUse", lblRoughPumpInUse_2.Tag.ToString())
        '        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
        '                   "[Main Screen]" & " - Clicked on Rough Pump 2 control to release Mechanical Pump resource")
        '    End If
        'End If

        ''Use kepware to On/Off Mechanical Pump
        'If RoughPumpControl2.Status = BinaryStatusControl.DisplayStatus.On Then
        '    If Utils.ShowAVPMessageBox("Do you want to turn off Mechanical Pump 2 ? ", _
        '                               "Mechanical Pump", MessageBoxIcon.Question, _
        '                               MessageBoxButtons.YesNo) = DialogResult.OK Then
        '        m_stoStatusObject.RequestStatus(RoughPumpControl2.Name, STR_OFF)
        '        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
        '                   ConstantAndEnum.TM_SCREEN & " - Clicked on Rough Pump 2 control to turn off Mechanical Pump")
        '    End If
        'ElseIf RoughPumpControl2.Status = BinaryStatusControl.DisplayStatus.Off Then
        '    If Utils.ShowAVPMessageBox("Do you want to turn on Mechanical Pump 2 ? ", _
        '                                           "Mechanical Pump", MessageBoxIcon.Question, _
        '                                           MessageBoxButtons.YesNo) = DialogResult.OK Then
        '        m_stoStatusObject.RequestStatus(RoughPumpControl2.Name, STR_ON)
        '        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
        '                   ConstantAndEnum.TM_SCREEN & " - Clicked on Rough Pump 2 control to turn on Mechanical Pump")
        '    End If
        'End If

        If AVPLib.RobotConfigurationValues.SHARED_MP_WITH_PM Then
            Return
        End If

        If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
            Dim objRoughPumpMachine2 As DataManagerment.RoughPumpMachine =
                                    DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.RoughPumpMachine2.ToString)

            Dim bVisible As Boolean = True
            If objRoughPumpMachine2 IsNot Nothing Then

                If objRoughPumpMachine2.IsUsed(AVPLib.ConstEnum.Equipments.LoadLockA.ToString) Then
                    bVisible = IsAllowActionOnLLA
                ElseIf objRoughPumpMachine2.IsUsed(AVPLib.ConstEnum.Equipments.CassettesModule.ToString) Then
                    bVisible = bVisible Or IsAllowActionOnTM
                End If

                If Not bVisible Then
                    Return
                End If

                If m_Rough2CGGaugesFrm IsNot Nothing Then
                    m_Rough2CGGaugesFrm.IsSetATM = objRoughPumpMachine2.IsSafetySetATM

                    If lblRoughPumpInUse_2.Tag IsNot Nothing Then
                        m_Rough2CGGaugesFrm.RoughPumpInUse = lblRoughPumpInUse_2.Tag.ToString()
                    Else
                        m_Rough2CGGaugesFrm.RoughPumpInUse = Nothing
                    End If
                    m_Rough2CGGaugesFrm.ShowDialog(AVPRobotMain)
                End If
            End If

        End If
    End Sub
    ''Notify to PVD Rough Pump is in used by ....
    Private Sub lblRoughPumpInUse_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRoughPumpInUse.TextChanged
        Dim objRoughPump1 As DataManagerment.RoughPumpMachine = DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.RoughPumpMachine1.ToString)
        UpdateRoughPumpStatusForPVDPanel(objRoughPump1, lblRoughPumpInUse.Text)
    End Sub
    Private Sub lblRoughPumpInUse_2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblRoughPumpInUse_2.TextChanged
        Dim objRoughPump2 As DataManagerment.RoughPumpMachine = DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.RoughPumpMachine2.ToString)
        UpdateRoughPumpStatusForPVDPanel(objRoughPump2, lblRoughPumpInUse_2.Text)
    End Sub
    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 2011-12-06</date>
    ''' </author>
    ''' <summary>
    ''' When Rough Valve on backend notify to this panel, notify to PVD panel too
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub UpdateRoughPumpStatusForPVDPanel(ByVal objRoughPump As DataManagerment.RoughPumpMachine, ByVal value As String)
        Try
            'check for PM1
            If (ContainerForm.Chamber1Visible AndAlso
            ContainerForm.Chamber1Panel.ChamberType = SystemModule.ModuleType.PVD AndAlso
            objRoughPump IsNot Nothing AndAlso
            objRoughPump.IsUsed(AVPLib.ConstEnum.Equipments.Chamber1.ToString())) Then
                CType(ContainerForm.Chamber1Panel, PVDPanel).lblRoughPumpInUse.Text = value
            End If

            'check for PM2
            If ContainerForm.Chamber2Visible AndAlso
            ContainerForm.Chamber2Panel.ChamberType = SystemModule.ModuleType.PVD AndAlso
            objRoughPump IsNot Nothing AndAlso
            objRoughPump.IsUsed(AVPLib.ConstEnum.Equipments.Chamber1.ToString()) Then
                CType(ContainerForm.Chamber2Panel, PVDPanel).lblRoughPumpInUse.Text = value
            End If

            'check for PM3
            If ContainerForm.Chamber3Visible AndAlso
            ContainerForm.Chamber3Panel.ChamberType = SystemModule.ModuleType.PVD AndAlso
            objRoughPump IsNot Nothing AndAlso
            objRoughPump.IsUsed(AVPLib.ConstEnum.Equipments.Chamber1.ToString) Then
                CType(ContainerForm.Chamber3Panel, PVDPanel).lblRoughPumpInUse.Text = value
            End If
        Catch ex As Exception
            AVPLib.Log.guiLogger.Error(ex.Message)
        End Try
    End Sub
#End Region

    Private Sub btnTMProtectedMode_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTMProtectedMode.Click
        If btnTMProtectedMode.Clickable = False Then
            Exit Sub
        End If
        Try
            Dim button As SL_CustomButton = CType(sender, SL_CustomButton)
            Dim strValue As String = String.Empty
            If button.Status = SL_CustomButton.DisplayStatus.Off Then
                strValue = STR_ON
            Else
                strValue = STR_OFF
            End If
            Dim Source As String = STR_IBE & "_" & STR_AVP & "." & "btnUnProtected" & "." & strValue
            Dim strMessageText As String = AVPLib.ContainerData.GetMessageText(Source)
            Utils.LogUserEvent(sender, "TM Screen")
            If Utils.ShowAVPMessageBox(strMessageText, "TM", MessageBoxIcon.Information, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.OK Then
                If (m_TM_Protected_Mode Is Nothing) Then
                    m_TM_Protected_Mode = New TMProtectedMode(False, 100)
                ElseIf (m_TM_Protected_Mode.Status = ProtectedModStatus.Off) Then
                    m_TM_Protected_Mode.Status = ProtectedModStatus.On
                    m_TM_Protected_Mode.CurrentTime = 0
                    btnTMProtectedMode.Status = SL_CustomButton.DisplayStatus.On
                ElseIf (m_TM_Protected_Mode.Status = ProtectedModStatus.On) Then
                    m_TM_Protected_Mode.Status = ProtectedModStatus.Off
                    m_TM_Protected_Mode.CurrentTime = 0
                    btnTMProtectedMode.Status = SL_CustomButton.DisplayStatus.Off
                End If

                ' Update SECS/GEM variables by Hoa Nguyen
                ' Var Name: OverideModeOnOff
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstEnum.TM_STR, EMSERVICELib.VarType.SV,
                                                    "OverideModeOnOff", VALUELib.ValueType.U1, btnTMProtectedMode.Status)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub btnCancleMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelMove.Click

        If btnCancelMove.Clickable = False Then
            Exit Sub
        End If

        Dim avpProcessJob As AVPLib.Business.AVPProcessJob = AVPLib.Business.AVPCore.Instance().JobManager().GetProcessJobRunning()
        Dim isSemiTransferRunning As Boolean = (avpProcessJob IsNot Nothing AndAlso Not avpProcessJob.IsAutoTransfer) _
            OrElse (Not String.IsNullOrEmpty(stwSemiautoTransferWafer.txtSource.Text) AndAlso Not String.IsNullOrEmpty(stwSemiautoTransferWafer.txtDestination.Text))
        If isSemiTransferRunning Then
            If Utils.ShowAVPMessageBox("Would you like to cancel current manual transfer?",
                                       "Cancel Move", MessageBoxIcon.Question, AVPMessageBox.AVPMessageBoxButton.YesNo) = DialogResult.OK Then
                ' Request to abort current transfer and send command "HALT" (<CRTL><C>) to robot.
                m_stoStatusObject.RequestStatus(btnCancelMove.Name, "")
                Utils.LogUserEvent(sender, "TM Screen")
                If Not String.IsNullOrEmpty(stwSemiautoTransferWafer.txtSource.Text) Then
                    stwSemiautoTransferWafer.txtSource.Text = String.Empty
                End If
                If Not String.IsNullOrEmpty(stwSemiautoTransferWafer.txtDestination.Text) Then
                    stwSemiautoTransferWafer.txtDestination.Text = String.Empty
                End If
            End If
        Else
            Utils.ShowAVPMessageBox("Nothing to cancel move.", "Cancel Move", MessageBoxIcon.Information, AVPMessageBox.AVPMessageBoxButton.OK)
        End If
    End Sub

    Public Sub RequestTurnOff_ProcessChime(Optional ByVal isShowMsg As Boolean = False)
        Try
            If (isShowMsg) Then
                Dim ProcessCompleteChimeMessage As AVPProcessChimeBox = New AVPProcessChimeBox("AVP", "Process Complete", MessageBoxIcon.Question, m_stoStatusObject)
                ProcessCompleteChimeMessage.Show()
            Else
                m_stoStatusObject.RequestStatus(btnFakeProcessCompleteChime.Name, STR_OFF)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    'Private Sub btnCancleMove_OnChange()
    '    If Me.ISTM_ONLINE Then
    '        btnCancelMove.Enabled = False
    '        'btnCancelMove.Status = SL_CustomButton.DisplayStatus.Off
    '    Else
    '        If Not String.IsNullOrEmpty(stwSemiautoTransferWafer.txtSource.Text) AndAlso _
    '                               Not String.IsNullOrEmpty(stwSemiautoTransferWafer.txtDestination.Text) Then
    '            btnCancelMove.Enabled = False
    '            btnCancelMove.ForeColor = Color.Gray
    '            'btnCancelMove.Status = SL_CustomButton.DisplayStatus.Off
    '        End If
    '        If String.IsNullOrEmpty(stwSemiautoTransferWafer.txtSource.Text) Or _
    '                                   String.IsNullOrEmpty(stwSemiautoTransferWafer.txtDestination.Text) Then
    '            btnCancelMove.Enabled = True
    '            btnCancelMove.ForeColor = Color.Black
    '            'btnCancelMove.Status = SL_CustomButton.DisplayStatus.On
    '        End If
    '    End If
    'End Sub

    Private Sub TurboOnOff(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTurboTM.Click, btnTurboLLA.Click
        AVPLib.Log.guiLogger.Info("Enter TurboOnOff")
        Try
            Dim button As AVP_Robot_Project.SL_CustomButton = CType(sender, AVP_Robot_Project.SL_CustomButton)
            Dim ButtonName As String = button.AccessibleName
            Dim strMessageText As String = String.Empty
            Dim strValue As String
            Dim ValveName As String = button.Name
            If (ValveName = "btnTurboLLA" OrElse ValveName = "btnTurboTM") Then
                Dim TurboName As String = String.Empty
                If (ValveName = "btnTurboTM") Then
                    TurboName = ConstEnum.Equipments.TMPumpPackage.ToString
                ElseIf (ValveName = "btnTurboLLA") Then
                    TurboName = ConstEnum.Equipments.LLAPumpPackage.ToString
                End If
                Dim objTurbo As DataManagerment.Turbo = DataManagerment.EquipmentManager.GetEquipment(TurboName)
                If (objTurbo.IsTurboCommunicating = False) Then
                    AVPLib.Utils.ThrowAlarm(ButtonName & " Communication is Off.")
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen,
                             ConstantAndEnum.TM_SCREEN & " - Result of clicking on " & ValveName & " has error.")
                    Exit Try
                End If
            End If

            If (button.Status = SL_CustomButton.DisplayStatus.Unknow) Then
                strMessageText = AVPLib.ContainerData.GetMessageText(ButtonName + "OnOff")
                Dim resDialg As DialogResult = Utils.ShowAVPMessageBox(strMessageText, TM_STR, MessageBoxIcon.Question,
                                    AVPMessageBox.AVPMessageBoxButton.TurnOnTurnOffCancel)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                 ConstantAndEnum.TM_SCREEN & " - Clicked on " & ButtonName)
                If resDialg = DialogResult.OK Then
                    m_stoStatusObject.RequestStatus(button.Name, STR_ON)
                ElseIf (resDialg = DialogResult.No) Then
                    m_stoStatusObject.RequestStatus(button.Name, STR_OFF)
                End If
            Else
                If (button.Status = SL_CustomButton.DisplayStatus.Off) Then
                    strMessageText = AVPLib.ContainerData.GetMessageText(ButtonName + "On")
                    strValue = BinaryStatusControl.DisplayStatus.Off.ToString(STRING_G)
                ElseIf (button.Status = SL_CustomButton.DisplayStatus.On) Then

                    strMessageText = AVPLib.ContainerData.GetMessageText(ButtonName + "Off")
                    strValue = BinaryStatusControl.DisplayStatus.On.ToString(STRING_G)

                End If

                If (Utils.ShowAVPMessageBox(strMessageText, TM_STR, MessageBoxIcon.Question) = DialogResult.OK) Then
                    ' check the condition before open the valve             
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                 ConstantAndEnum.TM_SCREEN & " - Clicked on " & ButtonName)
                    If button.Status = SL_CustomButton.DisplayStatus.Off Then
                        m_stoStatusObject.RequestStatus(button.Name, STR_ON)
                    Else
                        m_stoStatusObject.RequestStatus(button.Name, STR_OFF)
                    End If

                End If
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave TurboOnOff")
    End Sub

    Private Sub RoughPump1TextChange(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim objRoughPumpMachine As DataManagerment.RoughPumpMachine = DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.RoughPumpMachine1.ToString)
        If (objRoughPumpMachine IsNot Nothing) Then
            If (objRoughPumpMachine.IsUsed(AVPLib.ConstEnum.Equipments.CassettesModule.ToString)) Then
                txtRoughLineTM.Text = RoughPumpControl.TextValue
            End If
        End If
    End Sub

    Private Sub RoughPump2TextChange(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim objRoughPumpMachine As DataManagerment.RoughPumpMachine = DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.RoughPumpMachine2.ToString)
        If (objRoughPumpMachine IsNot Nothing) Then
            If (objRoughPumpMachine.IsUsed(AVPLib.ConstEnum.Equipments.CassettesModule.ToString)) Then
                txtRoughLineTM.Text = RoughPumpControl2.TextValue
            End If
        End If
    End Sub

    Private Sub btnTMProtectedMode_StatusChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTMProtectedMode.StatusChange
        'If DesignMode = True Then
        '    Exit Sub
        '        End If
        Try
            Dim button As SL_CustomButton = CType(sender, SL_CustomButton)
            Dim strValue As String = String.Empty
            If button.Status = SL_CustomButton.DisplayStatus.On Then
                strValue = STR_OFF
            Else
                strValue = STR_ON
            End If
            m_stoStatusObject.RequestStatus(button.Name, strValue)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub


    'Private Sub ValveLLASlowVent_StatusChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ValveLLASlowVent.StatusChange
    '    Try
    '        If ValveLLASlowVent.Status = BinaryStatusControl.DisplayStatus.On Then
    '            GasLineLL_Slow_Vent.Image = Global.AVP_Robot_Project.My.Resources.Resources.PM_Vent_Line_On
    '        Else
    '            GasLineLL_Slow_Vent.Image = Global.AVP_Robot_Project.My.Resources.Resources.PM_Vent_Line_Off
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Private Sub ValveLLAFastVent_StatusChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ValveLLAFastVent.StatusChange
    '    Try
    '        If ValveLLAFastVent.Status = BinaryStatusControl.DisplayStatus.On Then
    '            GasLineLL_Fast_Vent.Image = Global.AVP_Robot_Project.My.Resources.Resources.PM_Vent_Line_On
    '        Else
    '            GasLineLL_Fast_Vent.Image = Global.AVP_Robot_Project.My.Resources.Resources.PM_Vent_Line_Off
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Private Sub ValveLLASlowRough_StatusChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ValveLLASlowRough.StatusChange
    '    Try
    '        If ValveLLASlowRough.Status = BinaryStatusControl.DisplayStatus.On Then
    '            GasLineLL_Slow_Rough.Image = AVP_Robot_Project.My.Resources.CX4_Resources.Tube_LL_Slow_Rough_On
    '            GasLineLL_Rough_Head.Image = AVP_Robot_Project.My.Resources.CX4_Resources.Tube_LL_Rough_Head_On
    '            GasLineLL_Rough_Tail.Image = AVP_Robot_Project.My.Resources.CX4_Resources.Tube_LL_Rough_Tail_On
    '            GasLine_LL.Image = AVP_Robot_Project.My.Resources.CX4_Resources.Tube_LL_On
    '            GasLine_Machenical.Image = AVP_Robot_Project.My.Resources.CX4_Resources.Tube_Mechanical_On
    '        Else
    '            GasLineLL_Slow_Rough.Image = AVP_Robot_Project.My.Resources.CX4_Resources.Tube_LL_Slow_Rough
    '            If ValveLLAFastRough.Status = BinaryStatusControl.DisplayStatus.Off Then
    '                GasLineLL_Rough_Head.Image = AVP_Robot_Project.My.Resources.CX4_Resources.Tube_LL_Rough_Head
    '                GasLineLL_Rough_Tail.Image = AVP_Robot_Project.My.Resources.CX4_Resources.Tube_LL_Rough_Tail
    '                GasLine_LL.Image = AVP_Robot_Project.My.Resources.CX4_Resources.Tube_LL
    '                'If ValveRough.Status = BinaryStatusControl.DisplayStatus.Off Then
    '                GasLine_Machenical.Image = AVP_Robot_Project.My.Resources.CX4_Resources.Tube_Mechanical
    '                'End If
    '            End If
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Private Sub ValveLLAFastRough_StatusChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ValveLLAFastRough.StatusChange
    '    Try
    '        If ValveLLAFastRough.Status = BinaryStatusControl.DisplayStatus.On Then
    '            GasLineLL_Fast_Rough.Image = AVP_Robot_Project.My.Resources.CX4_Resources.Tube_LL_Fast_Rough_On
    '            GasLineLL_Rough_Head.Image = AVP_Robot_Project.My.Resources.CX4_Resources.Tube_LL_Rough_Head_On
    '            GasLineLL_Rough_Tail.Image = AVP_Robot_Project.My.Resources.CX4_Resources.Tube_LL_Rough_Tail_On
    '            GasLine_LL.Image = AVP_Robot_Project.My.Resources.CX4_Resources.Tube_LL_On
    '            GasLine_Machenical.Image = AVP_Robot_Project.My.Resources.CX4_Resources.Tube_Mechanical_On
    '        Else
    '            GasLineLL_Fast_Rough.Image = AVP_Robot_Project.My.Resources.CX4_Resources.Tube_LL_Fast_Rough
    '            If (RobotConfigurationValues.LL_SLOW_ROUGH_INSTALLED AndAlso ValveLLASlowRough.Status = BinaryStatusControl.DisplayStatus.Off) OrElse _
    '            Not RobotConfigurationValues.LL_SLOW_ROUGH_INSTALLED Then
    '                GasLineLL_Rough_Head.Image = AVP_Robot_Project.My.Resources.CX4_Resources.Tube_LL_Rough_Head
    '                GasLineLL_Rough_Tail.Image = AVP_Robot_Project.My.Resources.CX4_Resources.Tube_LL_Rough_Tail
    '                GasLine_LL.Image = AVP_Robot_Project.My.Resources.CX4_Resources.Tube_LL
    '                'If ValveRough.Status = BinaryStatusControl.DisplayStatus.Off Then
    '                GasLine_Machenical.Image = AVP_Robot_Project.My.Resources.CX4_Resources.Tube_Mechanical
    '                'End If
    '            End If
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Private Sub ValveLLATurbo_StatusChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ValveLLATurbo.StatusChange
    '    Try
    '        If ValveLLATurbo.Status = BinaryStatusControl.DisplayStatus.On Then
    '            GasLineTurboTM.Image = AVP_Robot_Project.My.Resources.CX4_Resources.Tube_PM_Foreline_On
    '            GasLine_LL.Image = AVP_Robot_Project.My.Resources.CX4_Resources.Tube_LL_On
    '            GasLine_Machenical.Image = AVP_Robot_Project.My.Resources.CX4_Resources.Tube_Mechanical_On
    '        Else
    '            GasLineTurboTM.Image = AVP_Robot_Project.My.Resources.CX4_Resources.Tube_PM_Foreline
    '            If ValveLLASlowRough.Status = BinaryStatusControl.DisplayStatus.Off AndAlso _
    '            ValveLLAFastRough.Status = BinaryStatusControl.DisplayStatus.Off Then
    '                GasLine_LL.Image = AVP_Robot_Project.My.Resources.CX4_Resources.Tube_LL
    '                'If ValveRough.Status = BinaryStatusControl.DisplayStatus.Off Then
    '                GasLine_Machenical.Image = AVP_Robot_Project.My.Resources.CX4_Resources.Tube_Mechanical
    '                'End If
    '            End If
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Private Sub ValveVent_StatusChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ValveVent.StatusChange
    '    Try
    '        If ValveVent.Status = BinaryStatusControl.DisplayStatus.On Then
    '            GasLineNitrogen.Image = AVP_Robot_Project.My.Resources.CX4_Resources.Tube_PM_Vent_On
    '        Else
    '            GasLineNitrogen.Image = AVP_Robot_Project.My.Resources.CX4_Resources.Tube_PM_Vent
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Private Sub ValveRough_StatusChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ValveRough.StatusChange
    '    Try
    '        If ValveRough.Status = BinaryStatusControl.DisplayStatus.On Then
    '            GasRoughLine.Image = AVP_Robot_Project.My.Resources.CX4_Resources.Tube_PM_Rough_On
    '            GasLine_Machenical.Image = AVP_Robot_Project.My.Resources.CX4_Resources.Tube_Mechanical_On
    '        Else
    '            GasRoughLine.Image = AVP_Robot_Project.My.Resources.CX4_Resources.Tube_PM_Rough
    '            If ValveLLATurbo.Status = BinaryStatusControl.DisplayStatus.Off AndAlso _
    '                ValveLLAFastRough.Status = BinaryStatusControl.DisplayStatus.Off AndAlso _
    '                 ValveLLASlowRough.Status = BinaryStatusControl.DisplayStatus.Off Then
    '                GasLine_Machenical.Image = AVP_Robot_Project.My.Resources.CX4_Resources.Tube_Mechanical
    '            End If
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub txtTurboIGTM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTurboIGTM.Click
        If AVPLib.System_Init_Indicator.IsMainFormInitialize AndAlso IsAllowActionOnTM Then
            Dim cassetteModule As DataManagerment.CassettesModule =
                               DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString())
            If m_TMFLCGGaugesFrm IsNot Nothing AndAlso cassetteModule IsNot Nothing Then
                m_TMFLCGGaugesFrm.IsSetATM = cassetteModule.IsSafetySetTurboForelineATM
                m_TMFLCGGaugesFrm.ShowDialog(AVPRobotMain)
            End If
        End If
    End Sub

    Private Sub txtTurboIGLLA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTurboIGLLA.Click
        If AVPLib.System_Init_Indicator.IsMainFormInitialize AndAlso IsAllowActionOnLLA Then
            Dim eqLL As LoadLock = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.LoadLockA.ToString())
            If m_LLAFLCGGaugesFrm IsNot Nothing AndAlso eqLL IsNot Nothing Then
                m_LLAFLCGGaugesFrm.IsSetATM = eqLL.IsSafetySetTurboForelineATM
                m_LLAFLCGGaugesFrm.ShowDialog(AVPRobotMain)
            End If
        End If
    End Sub

    Private Sub ChangeTMGaslineStatus(ByVal status As BinaryStatusControl.DisplayStatus)
        ' TM TurboPump lines
        If AVPLib.RobotConfigurationValues.TMTURBO_VISIBLE Then
            ChangeTMForelineGaslineStatus(status)

            If ValveTMTurbo.Status = BinaryStatusControl.DisplayStatus.On Then
                Gasline_TM_Foreline.Status = status
            End If

            Me.RestartTMForelineGasline()
        End If

        '' TM Rough lines
        Gasline_TM_FR_Out.Status = status
        Gasline_TM_FL_FR.Status = status

        If ValveRough.Status = BinaryStatusControl.DisplayStatus.On Then
            Gasline_TM_FastRough.Status = status
        End If

        ' Pump lines
        Gasline_TM_Pump_PartEnd.Status = status
        Gasline_TM_Pump_Part4.Status = status
        Gasline_TM_Pump_Part3.Status = status
        Gasline_TM_Pump_Part2.Status = status
        Gasline_TM_Pump_Part1.Status = status
    End Sub

    Private Sub ChangeLLGaslineStatus(ByVal status As BinaryStatusControl.DisplayStatus)
        ' LL TurboPump lines
        If AVPLib.RobotConfigurationValues.LLA_TURBO_VISIBLE Then
            Gasline_LL_FL_1.Status = status
            Gasline_LL_FL_21.Status = status

            If ValveLLATurbo.Status = BinaryStatusControl.DisplayStatus.On Then
                Gasline_LL_Foreline.Status = status
            End If
        End If

        ' LL FastRough lines
        Gasline_LL_FR_1.Status = status
        Gasline_LL_FR_21.Status = status

        If ValveLLAFastRough.Status = BinaryStatusControl.DisplayStatus.On Then
            Gasline_LL_FastRough.Status = status
            Gasline_LL_Rough.Status = status

        End If

        ' LL SlowRough lines
        If AVPLib.RobotConfigurationValues.LL_SLOW_ROUGH_INSTALLED Then
            Gasline_LL_SR_1.Status = status
            Gasline_LL_SR_21.Status = status

            If ValveLLASlowRough.Status = BinaryStatusControl.DisplayStatus.On Then
                Gasline_LL_SlowRough.Status = status
                Gasline_LL_Rough.Status = status

            End If
        End If

        ' Pump lines
        Gasline_LL_Pump_PartEnd.Status = status
        Gasline_LL_Pump_Part4.Status = status
        Gasline_LL_Pump_Part3.Status = status
        Gasline_LL_Pump_Part2.Status = status
        Gasline_LL_Pump_Part1.Status = status

        Me.RestartLLToValveGasline()
        Me.RestartLLPumpGasline()
    End Sub

    ''' <author> Hai Tran </author>
    ''' <date> 2021-11-04 </date>
    ''' <summary>
    ''' Change TM Foreline gasline status
    ''' </summary>
    Private Sub ChangeTMForelineGaslineStatus(ByVal status As BinaryStatusControl.DisplayStatus)
        Gasline_TM_FL_1.Status = status
        Gasline_TM_FL_2.Status = status
        Gasline_TM_FL_3.Status = status
        Gasline_TM_FL_4.Status = status
        Gasline_TM_FL_End1.Status = status
        Gasline_TM_FL_End2.Status = status
    End Sub

    Private Sub RoughPumpControl_StatusChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles RoughPumpControl.StatusChange
        Try
            If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
                If m_Rough1CGGaugesFrm IsNot Nothing Then
                    m_Rough1CGGaugesFrm.PumpStatus = IIf(RoughPumpControl.Status = BinaryStatusControl.DisplayStatus.On, Equipment.WorkingStatuses.On, Equipment.WorkingStatuses.Off)
                End If

                If Not AVPLib.RobotConfigurationValues.ROUGH_PUMP1_INSTALLED Then
                    Exit Try
                End If

                Dim objRoughPumpTM As AVPLib.DataManagerment.RoughPumpMachine =
                            AVPLib.DataManagerment.EquipmentManager.GetRoughPumpMachine(AVPLib.ConstEnum.Equipments.CassettesModule.ToString)

                Dim status As BinaryStatusControl.DisplayStatus = RoughPumpControl.Status

                ''Rough pump 1 use by TM
                If objRoughPumpTM IsNot Nothing AndAlso objRoughPumpTM.Name = "RoughPumpMachine1" Then
                    ChangeTMGaslineStatus(status)
                Else  ''Rough pump 1 use by LL
                    ChangeLLGaslineStatus(status)
                End If

                ' One pump installed
                If Not RobotConfigurationValues.ROUGH_PUMP2_INSTALLED Then
                    ' LL TurboPump lines
                    If AVPLib.RobotConfigurationValues.LLA_TURBO_VISIBLE Then
                        Gasline_LL_FL_1.Status = status
                        Gasline_LL_FL_221.Status = status
                        Gasline_LL_FL_222.Status = status

                        If ValveLLATurbo.Status = BinaryStatusControl.DisplayStatus.On Then
                            Gasline_LL_Foreline.Status = status
                        End If
                    End If

                    ' LL FastRough lines
                    Gasline_LL_FR_1.Status = status
                    Gasline_LL_FR_221.Status = status
                    Gasline_LL_FR_222.Status = status

                    If ValveLLAFastRough.Status = BinaryStatusControl.DisplayStatus.On Then
                        Gasline_LL_FastRough.Status = status
                        Gasline_LL_Rough.Status = status

                        Me.RestartLLToValveGasline()
                    End If

                    ' LL SlowRough lines
                    If AVPLib.RobotConfigurationValues.LL_SLOW_ROUGH_INSTALLED Then
                        Gasline_LL_SR_1.Status = status
                        Gasline_LL_SR_221.Status = status
                        Gasline_LL_SR_222.Status = status

                        If ValveLLASlowRough.Status = BinaryStatusControl.DisplayStatus.On Then
                            Gasline_LL_SlowRough.Status = status
                            Gasline_LL_Rough.Status = status

                            Me.RestartLLToValveGasline()
                        End If
                    End If
                End If

                If status = BinaryStatusControl.DisplayStatus.On Then
                    Me.RestartTMRoughGasline()
                    Me.RestartTMPumpGasline()
                End If
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub

    Private Sub RoughPumpControl2_StatusChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles RoughPumpControl2.StatusChange
        Try
            If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
                If m_Rough2CGGaugesFrm IsNot Nothing Then
                    m_Rough2CGGaugesFrm.PumpStatus = IIf(RoughPumpControl2.Status = BinaryStatusControl.DisplayStatus.On, Equipment.WorkingStatuses.On, Equipment.WorkingStatuses.Off)
                End If

                If Not AVPLib.RobotConfigurationValues.ROUGH_PUMP2_INSTALLED Then
                    Exit Try
                End If

                Dim objRoughPumpLL As AVPLib.DataManagerment.RoughPumpMachine =
                            AVPLib.DataManagerment.EquipmentManager.GetRoughPumpMachine(AVPLib.ConstEnum.Equipments.LoadLockA.ToString)

                Dim status As BinaryStatusControl.DisplayStatus = RoughPumpControl2.Status

                ''Rough pump 2 use by LL
                If objRoughPumpLL IsNot Nothing AndAlso objRoughPumpLL.Name = "RoughPumpMachine2" Then
                    ChangeLLGaslineStatus(status)
                Else      ''Rough pump 2 use by TM
                    ChangeTMGaslineStatus(status)
                End If

                ' TM Rough lines
                If Not RobotConfigurationValues.ROUGH_PUMP1_INSTALLED Then
                    ' TM TurboPump lines
                    If AVPLib.RobotConfigurationValues.TMTURBO_VISIBLE Then
                        ChangeTMForelineGaslineStatus(status)

                        If ValveTMTurbo.Status = BinaryStatusControl.DisplayStatus.On Then
                            Gasline_TM_Foreline.Status = status
                        End If

                        Me.RestartTMForelineGasline()
                    End If

                    ' TM Rough lines
                    Gasline_TM_FR_Out.Status = status

                    If ValveRough.Status = BinaryStatusControl.DisplayStatus.On Then
                        Gasline_TM_FastRough.Status = status
                    End If

                    If status = BinaryStatusControl.DisplayStatus.On Then
                        Me.RestartTMRoughGasline()
                    End If

                End If

                If status = BinaryStatusControl.DisplayStatus.On Then
                    Me.RestartTMPumpGasline()
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-06-17 </date>
    ''' </author>
    ''' <summary>
    ''' Update gaslines
    ''' </summary>
    Private Sub Valve_StatusChange(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ValveVent.StatusChange, ValveRough.StatusChange, ValveTMTurbo.StatusChange,
                ValveLLATurbo.StatusChange, ValveLLAFastRough.StatusChange, ValveLLASlowRough.StatusChange,
                ValveLLAFastVent.StatusChange, ValveLLASlowVent.StatusChange
        Try
            If System_Init_Indicator.IsMainFormInitialize Then
                If sender Is ValveVent Then
                    Gasline_TM_FastVent.Status = ValveVent.Status

                    If ValveVent.Status = BinaryStatusControl.DisplayStatus.On Then
                        Gasline_TM_FV_N2.Restart()
                    End If

                ElseIf sender Is ValveLLAFastVent Then
                    Gasline_LL_FastVent.Status = ValveLLAFastVent.Status

                    If Not AVPLib.RobotConfigurationValues.LL_SLOW_VENT_INSTALLED OrElse ValveLLASlowVent.Status = BinaryStatusControl.DisplayStatus.Off Then
                        Gasline_LL_Vent.Status = ValveLLAFastVent.Status
                    End If

                    If ValveLLAFastVent.Status = BinaryStatusControl.DisplayStatus.On Then
                        Gasline_LL_FV_N2.Restart()
                        Gasline_LL_Vent.Restart()
                        If ValveLLASlowVent.Status = BinaryStatusControl.DisplayStatus.On Then
                            Gasline_LL_SV_N2.Restart()
                            Gasline_LL_SlowVent.Restart()
                        End If
                    End If

                ElseIf sender Is ValveLLASlowVent Then
                    Gasline_LL_SlowVent.Status = ValveLLASlowVent.Status

                    If ValveLLAFastVent.Status = BinaryStatusControl.DisplayStatus.Off Then
                        Gasline_LL_Vent.Status = ValveLLASlowVent.Status
                    End If

                    If ValveLLASlowVent.Status = BinaryStatusControl.DisplayStatus.On Then
                        Gasline_LL_SV_N2.Restart()
                        Gasline_LL_SlowVent.Restart()
                        Gasline_LL_Vent.Restart()
                        If ValveLLAFastVent.Status = BinaryStatusControl.DisplayStatus.On Then
                            Gasline_LL_FastVent.Restart()
                            Gasline_LL_FV_N2.Restart()
                        End If
                    End If

                ElseIf sender Is ValveRough Then
                    If ValveRough.Status = BinaryStatusControl.DisplayStatus.On Then
                        Gasline_TM_FastRough.Status = Gasline_TM_FR_Out.Status
                    Else
                        Gasline_TM_FastRough.Status = BinaryStatusControl.DisplayStatus.Off
                    End If

                    If ValveRough.Status = BinaryStatusControl.DisplayStatus.On Then
                        Gasline_TM_FastRough.Restart()
                        Me.RestartTMRoughGasline()
                        If Me.RoughPumpControl.Visible Then
                            Me.RestartTMPumpGasline()
                        End If
                    End If

                ElseIf sender Is ValveTMTurbo Then
                    If ValveTMTurbo.Status = BinaryStatusControl.DisplayStatus.On Then
                        Gasline_TM_Foreline.Status = Gasline_TM_FL_1.Status
                    Else
                        Gasline_TM_Foreline.Status = BinaryStatusControl.DisplayStatus.Off
                    End If

                    If ValveTMTurbo.Status = BinaryStatusControl.DisplayStatus.On Then
                        Gasline_TM_Foreline.Restart()
                        Me.RestartTMForelineGasline()
                    End If

                ElseIf sender Is ValveLLATurbo Then
                    If ValveLLATurbo.Status = BinaryStatusControl.DisplayStatus.On Then
                        Gasline_LL_Foreline.Status = Gasline_LL_FL_1.Status
                    Else
                        Gasline_LL_Foreline.Status = BinaryStatusControl.DisplayStatus.Off
                    End If

                    If ValveLLATurbo.Status = BinaryStatusControl.DisplayStatus.On Then
                        Gasline_LL_Foreline.Restart()
                        Gasline_LL_FL_1.Restart()
                        Gasline_LL_FL_221.Restart()
                        Gasline_LL_FL_222.Restart()
                        Gasline_LL_FL_21.Restart()

                    End If

                ElseIf sender Is ValveLLAFastRough Then
                    If ValveLLAFastRough.Status = BinaryStatusControl.DisplayStatus.On Then
                        Gasline_LL_Rough.Status = Gasline_LL_FR_1.Status
                        Gasline_LL_FastRough.Status = Gasline_LL_FR_1.Status
                    Else
                        Gasline_LL_FastRough.Status = BinaryStatusControl.DisplayStatus.Off
                        If Not AVPLib.RobotConfigurationValues.LL_SLOW_ROUGH_INSTALLED OrElse ValveLLASlowRough.Status = BinaryStatusControl.DisplayStatus.Off Then
                            Gasline_LL_Rough.Status = BinaryStatusControl.DisplayStatus.Off
                        End If
                    End If

                    If ValveLLAFastRough.Status = BinaryStatusControl.DisplayStatus.On Then
                        Gasline_LL_Rough.Restart()
                        Gasline_LL_FastRough.Restart()
                        Gasline_LL_FR_1.Restart()
                        Gasline_LL_FR_221.Restart()
                        Gasline_LL_FR_222.Restart()
                        Gasline_LL_FR_21.Restart()

                        If ValveLLASlowRough.Status = BinaryStatusControl.DisplayStatus.On Then
                            Gasline_LL_SlowRough.Restart()
                            Gasline_LL_SR_1.Restart()
                            Gasline_LL_SR_221.Restart()
                            Gasline_LL_SR_222.Restart()
                            Gasline_LL_SR_21.Restart()
                        End If
                    End If

                    Me.RestartLLToValveGasline()
                ElseIf sender Is ValveLLASlowRough Then
                    If ValveLLASlowRough.Status = BinaryStatusControl.DisplayStatus.On Then
                        Gasline_LL_Rough.Status = Gasline_LL_SR_1.Status
                        Gasline_LL_SlowRough.Status = Gasline_LL_SR_1.Status
                    Else
                        Gasline_LL_SlowRough.Status = BinaryStatusControl.DisplayStatus.Off
                        If ValveLLAFastRough.Status = BinaryStatusControl.DisplayStatus.Off Then
                            Gasline_LL_Rough.Status = BinaryStatusControl.DisplayStatus.Off
                        End If
                    End If

                    If ValveLLASlowRough.Status = BinaryStatusControl.DisplayStatus.On Then
                        Gasline_LL_SlowRough.Restart()
                        Gasline_LL_SR_1.Restart()
                        Gasline_LL_SR_221.Restart()
                        Gasline_LL_SR_222.Restart()
                        Gasline_LL_SR_21.Restart()

                        If ValveLLAFastRough.Status = BinaryStatusControl.DisplayStatus.On Then
                            Gasline_LL_Rough.Restart()
                            Gasline_LL_FastRough.Restart()
                            Gasline_LL_FR_1.Restart()
                            Gasline_LL_FR_221.Restart()
                            Gasline_LL_FR_222.Restart()
                            Gasline_LL_FR_21.Restart()
                        End If
                    End If

                    Me.RestartLLToValveGasline()
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-06-22 </date>
    ''' </author>
    ''' <summary>
    ''' Restart animation of gaslines.
    ''' </summary>
    Private Sub RestartTMPumpGasline()
        Gasline_TM_Pump_PartEnd.Restart()
        Gasline_TM_Pump_Part4.Restart()
        Gasline_TM_Pump_Part3.Restart()
        Gasline_TM_Pump_Part2.Restart()
        Gasline_TM_Pump_Part1.Restart()
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-06-22 </date>
    ''' </author>
    ''' <summary>
    ''' Restart animation of gaslines.
    ''' </summary>
    Private Sub RestartLLPumpGasline()
        Gasline_LL_Pump_PartEnd.Restart()
        Gasline_LL_Pump_Part4.Restart()
        Gasline_LL_Pump_Part3.Restart()
        Gasline_LL_Pump_Part2.Restart()
        Gasline_LL_Pump_Part1.Restart()
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2021-11-04 </date>
    ''' </author>
    ''' <summary>
    ''' Restart animation of gaslines.
    ''' </summary>
    Private Sub RestartLLToValveGasline()
        Gasline_LL_Rough.Restart()
        Gasline_LL_FastRough.Restart()
        Gasline_LL_SlowRough.Restart()
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-06-22 </date>
    ''' </author>
    ''' <summary>
    ''' Restart animation of gaslines.
    ''' </summary>
    Private Sub RestartTMRoughGasline()
        Gasline_TM_FR_Out.Restart()
        Gasline_TM_FL_FR.Restart()
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2021-11-04 </date>
    ''' </author>
    ''' <summary>
    ''' Restart animation of gaslines.
    ''' </summary>
    Private Sub RestartTMForelineGasline()
        Gasline_TM_FL_1.Restart()
        Gasline_TM_FL_2.Restart()
        Gasline_TM_FL_3.Restart()
        Gasline_TM_FL_4.Restart()
        Gasline_TM_FL_End1.Restart()
        Gasline_TM_FL_End2.Restart()
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-06-22 </date>
    ''' </author>
    ''' <summary>
    ''' Update TurboControl status text
    ''' </summary>
    Private Sub TurboButton_StatusChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTurboLLA.StatusChange, btnTurboTM.StatusChange
        Try
            If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
                If sender Is btnTurboLLA Then
                    If btnTurboLLA.Status = SL_CustomButton.DisplayStatus.Unknow Then
                        crcLLTurbo.lblTurboStatus.Text = btnTurboLLA.Text
                    Else
                        crcLLTurbo.lblTurboStatus.Text = String.Empty
                    End If
                ElseIf sender Is btnTurboTM Then
                    'If btnTurboTM.Status = SL_CustomButton.DisplayStatus.Unknow Then
                    '    crcTMTurbo.lblTurboStatus.Text = btnTurboTM.Text
                    'Else
                    '    crcTMTurbo.lblTurboStatus.Text = String.Empty
                    'End If
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''     <date> 2017-07-05 </date>
    ''' </author>
    Private Sub TMSwitchIGFilament_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TMSwitchIGFilament.TextChanged
        Try
            If AVPLib.System_Init_Indicator.IsMainFormInitialize AndAlso TMCGGaugesFrm IsNot Nothing Then
                Dim numFilament As Integer
                Integer.TryParse(TMSwitchIGFilament.Text, numFilament)
                TMCGGaugesFrm.UpdateSwitchIGFilament(numFilament)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub LLASwitchIGFilament_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LLASwitchIGFilament.TextChanged
        Try
            If AVPLib.System_Init_Indicator.IsMainFormInitialize AndAlso LLACGGaugesFrm IsNot Nothing Then
                Dim numFilament As Integer
                Integer.TryParse(LLASwitchIGFilament.Text, numFilament)
                LLACGGaugesFrm.UpdateSwitchIGFilament(numFilament)
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

    ''' <author>Tinh Le</author>
    ''' <date>2023-18-04</date>
    ''' <summary>
    ''' Update MP2 communition status
    ''' </summary>
    Private Sub UpdateLLPumpSerial(ByVal state As Boolean)
        Try
            If RobotConfigurationValues.MPUMP2_SERIAL_VISIBLE Then
                If Me.InvokeRequired Then
                    Me.Invoke(New CommunicationState(AddressOf UpdateLLPumpSerial), state)
                    Return
                End If

                If state Then
                    btnCommunicationMP2.Status = AVPControls.AVPDataLib.DisplayStatus.On
                Else
                    btnCommunicationMP2.Status = AVPControls.AVPDataLib.DisplayStatus.Error
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>Tinh Le</author>
    ''' <date>2023-18-04</date>
    ''' <summary>
    ''' Update MP1 communition status
    ''' </summary>
    Private Sub UpdateTMPumpSerial(ByVal state As Boolean)
        Try
            If RobotConfigurationValues.MPUMP1_SERIAL_VISIBLE Then
                If Me.InvokeRequired Then
                    Me.Invoke(New CommunicationState(AddressOf UpdateTMPumpSerial), state)
                    Return
                End If

                If state Then
                    btnCommunicationMP1.Status = AVPControls.AVPDataLib.DisplayStatus.On
                Else
                    btnCommunicationMP1.Status = AVPControls.AVPDataLib.DisplayStatus.Error
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub txtTurboIGTM_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTurboIGTM.TextChanged, txtTurboIGLLA.TextChanged, txtRoughLineTM.TextChanged
        Try
            Dim control As System.Windows.Forms.TextBox = CType(sender, System.Windows.Forms.TextBox)
            control.ForeColor = IIf(control.Text = ConstEnum.STR_ERROR, Color.Red, Color.Lime)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
End Class
