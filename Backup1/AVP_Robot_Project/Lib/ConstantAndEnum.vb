Public Enum ProcessStatuses
    [PAUSE] = 0
    [RUNNING] = 1
    [ABORT] = 2
    [STOP] = 3
End Enum
Public Enum MenuIndex
    Online = 0
    Offline = 1
    PumpDown = 2
    StopPumpDown = 3
    Vent = 4
    StopVent = 5
End Enum
Public Enum CX_Style
    CX4
    CX5
    CX6
    CX7
    CX8
End Enum

Public Enum DigitsNumber
    Normal = 0
    One_Digit = 1
    Two_Digits = 2
    Three_Digits = 3
    None_Digit = 4
End Enum

Public Enum TypeOfAVPChamber
    AVP = -1
    IBE = 0
    PVD = 1
    RIE = 2
    PQL = 3
    PVD4 = 4
    PVD2R4 = 5
    IBD = 6
    PVDA = 7
    PVD5T = 8
End Enum

Public Enum AllChamberType
    UNDEFINED
    VEECO_IBE
    AVP_IBE ''AVP
    PQL
    PVD
    PVDA
    MECHANICAL_ALIGNER
    PVD4
    PVD5T
End Enum

Public Enum DisplayStatus
    [Off] = 0
    [On] = 1
    [Error] = 2
    [Unknow] = 3
    [None] = 4
End Enum

Public Enum ButtonStyle
    [Vertical]
    [Horizontal]
End Enum

Public Class ConstantAndEnum
    Public Const PROCESS_MODE_TIME As String = "Time"
    Public Const PROCESS_MODE_REVOLUTION As String = "Revolution"
    Public Const PROCESS_MODE_STATIC As String = "Static"
    Public Const STR_CLICK_FOR_DETAIL As String = "Click for detail..."
    Public Const STR_MOTION_INITIALIZING As String = "Motion Initializing"
    Public Const STR_LOCAL As String = "Local"
    Public Const STR_REMOTE As String = "Remote"
    Public Const STATION As String = "Station "
    Public Const OFFLINE_PM As String = " (Offline)"
    Public Const ONLINE_PM As String = " (Online)"
    Public Const TIC_WAFER_INSIDE_CHAMBER1 As String = "ticWaferInsideChamber1"
    Public Const TIC_WAFER_INSIDE_CHAMBER2 As String = "ticWaferInsideChamber2"
    Public Const TIC_WAFER_INSIDE_CHAMBER3 As String = "ticWaferInsideChamber3"
    Public Const TIC_WAFER_INSIDE_CHAMBER4 As String = "ticWaferInsideChamber4"
    Public Const TIC_WAFER_INSIDE_CHAMBER5 As String = "ticWaferInsideChamber5"
    'Public Const IGCGTM_STR As String = "IgcgTM"
    Public Const IGCGLLA_STR As String = "IgcgLLA"
    Public Const IGCGCHAMBER1_STR As String = "IgcgChamber1"
    Public Const IGCGCHAMBER2_STR As String = "IgcgChamber2"
    Public Const IGCGCHAMBER3_STR As String = "IgcgChamber3"
    Public Const IGCGC_INITVALUE As String = "0.0E+0"
    Public Const CASSETTESPANEL_STR As String = "CassettesPanel"
    Public Const ALIGNERPANEL_STR As String = "usrAligner"
    Public Const PROCESSPANEL_STR As String = "ProcessPanel"
    Public Const BTNRFPOWER As String = "btnRFPower"
    Public Const VALVESUPPLYPBN As String = "ValveSupplyPBN"
    Public Const VALVECONTROLPBN As String = "ValveControlPBN"
    Public Const FORWARDPOWER As String = "txtForwardPower1"
    Public Const REFLECTEDPOWER As String = "txtReflectedPower"
    Public Const REGEN As String = "btnRegen"
    Public Const STATUSPANEL_STR As String = "usrStatusPanel"
    Public Const POWERSTATUSPANEL_STR As String = "PowerStatusPanel"
    Public Const WIDTH_EQP As Integer = 400
    Public Const HEIGHT_EQP As Integer = 47
    Public Const PARAGRAPH As Integer = 20
    Public Const SPACE As Integer = 10
    Public Const MAXDEFAULT As Integer = 50000
    Public Const MINDEFAULT As Integer = 0
    'TABLE_MAX_HEIGHT. should be equal TABLE_MAX_POSITION in PVD4ChamberControl
    Public Const TABLE_MAX_HEIGHT As Integer = 30
    Public Const NEW_WAFER_FLOW As String = "New Wafer Flow"
    Public Const TXTT1 As String = "txtT1"
    Public Const TXTT2 As String = "txtT2"
    Public Const BTN_AUTO_BEAM As String = "btnAutoBeam"
    Public Const DISABLE_AUTO_BEAM As String = "Disable Auto Beam"
    Public Const ENABLE_AUTO_BEAM As String = "Enable Auto Beam"
    Public Const REGENBUTTON_COLOR_ONLINE As String = "RegenButton_Color_Online"
    Public Const REGENBUTTON_COLOR_OFFLINE As String = "RegenButton_Color_Offline"
    Public Const BUTTON_IBE_COLOR_OFF As String = "Button_IBE_Color_Off"
    Public Const COLOR_ERROR As String = "Color_Error"
    Public Const COLOR_FINISHED As String = "Color_Completed"
    Public Const COLOR_PARTIAL As String = "Color_Partial"
    Public Const COLOR_UNPROCESS As String = "Color_UnProcess"
    Public Const COLOR_EMPTY As String = "Color_Empty"
    Public Const CHAMBER_COLOR_ONLINE As String = "Chamber_Color_Online"
    Public Const CHAMBER_COLOR_OFFLINE As String = "Chamber_Color_Offline"
    Public Const COMMUNICATION_COLOR_ONLINE As String = "Communication_Color_Online"
    Public Const COMMUNICATION_COLOR_OFFLINE As String = "Communication_Color_Offline"
    Public Const CHANGE_SLIT_VALE_OF_CHAMBER1 As String = "ChangeSlitValeOfChamber1"
    Public Const CHANGE_SLIT_VALE_OF_CHAMBER2 As String = "ChangeSlitValeOfChamber2"
    Public Const CHANGE_SLIT_VALE_OF_CHAMBER3 As String = "ChangeSlitValeOfChamber3"
    Public Const CHANGE_SLIT_VALE_OF_CHAMBER4 As String = "ChangeSlitValeOfChamber4"
    Public Const CHANGE_SLIT_VALE_OF_CHAMBER5 As String = "ChangeSlitValeOfChamber5"
    Public Const UNKNOWN As String = "Unknown"
    Public Const OPENED As String = "Opened"
    Public Const CLOSED As String = "Closed"
    Public Const GREEN_OPENED As String = "GreenOpened"
    Public Const RED_COLOSED As String = "RedClosed"
    Public Const STR_ROTATING As String = "Rotating"
    Public Const CANNOT_TRANSFER_WAFER = "Cannot transfer wafer"

    Public Const TAILFILENAME As String = "\Tail.exe"
    Public Const LOGERROR_ROBOT_PATH As String = "\DataFiles\Archived\LogError\AVP.TerminalServer.Robot.log.txt"
    Public Const LOGERROR_CHAMBER_PATH As String = "\DataFiles\Archived\LogError\AVP.TerminalServer.Chamber.log.txt"
    Public Const LOGERROR_CRYO_PATH As String = "\DataFiles\Archived\LogError\AVP.TerminalServer.Cryo.log.txt"


    Public Const CHAMBER As String = "Chamber"
    Public Const TM_SCREEN As String = "[TM Screen]"
    Public Const STRING_TURN_ON As String = "Turn On"
    Public Const STRING_TURN_OFF As String = "Turn Off"
    Public Const STRING_TURN_ON_OFF As String = "Turn On/Off"
    Public Const STRING_OPEN_CLOSE As String = "Open/Close"
    Public Const SPACE_STRING As String = " "

    Public Const STRING_START_ACTION As String = "Start"
    Public Const STRING_STOP_ACTION As String = "Stop"
    Public Const STRING_UP_ACTION As String = "Up"
    Public Const STRING_DOWN_ACTION As String = "Down"
    Public Const STRING_START_STOP_ACTION As String = "Start/Stop"
    Public Const STRING_UP_DOWN_ACTION As String = "Up/Down"

    '#03/07/2011 
    '#[Sl_Build 12_Feb 16, 2011]User account should be similar to avp/pvd request
    '#Begin fix:

    'Public Const PERMISSION_001 As String = "001"  ''Cassette and Robot Maintenance
    ''Public Const PERMISSION_002 As String = "002" '''Operation
    'Public Const PERMISSION_003 As String = "003" '' Dianostic
    'Public Const PERMISSION_004 As String = "004"  ''Recipe Editor
    'Public Const PERMISSION_005 As String = "005"  ''I/O override
    'Public Const PERMISSION_0051 As String = "0051"  ''I/O override -> Write Tag RO
    ''Public Const PERMISSION_006 As String = "006" ''IBE:Chamber
    'Public Const PERMISSION_007 As String = "007" ''WaferRun Dialog
    'Public Const PERMISSION_008 As String = "008"  ''System Setup
    'Public Const PERMISSION_009 As String = "009" ''Sequence Editor
    'Public Const PERMISSION_010 As String = "010" ''Process Screen
    'Public Const PERMISSION_011 As String = "011" ''DataLog
    'Public Const PERMISSION_012 As String = "012" ''User Setup
    'Public Const PERMISSION_013 As String = "013" ''Alarm
    'Public Const PERMISSION_014 As String = "014" ''Waferflow Editor
    'Public Const PERMISSION_015 As String = "015" ''Aligner

    'Public Const PERMISSION_016 As String = "016" ''Chamber1
    'Public Const PERMISSION_017 As String = "017" ''Chamber2
    'Public Const PERMISSION_018 As String = "018" ''Chamber3
    'Public Const PERMISSION_021 As String = "021" ''Exit AVP Application
    'Public Const PERMISSION_022 As String = "022" ''Mark for Return
    'Public Const PERMISSION_023 As String = "023" ''Resume
    'Public Const PERMISSION_024 As String = "024" ''Return

    'Public Const PERMISSION_0101 As String = "0101" ''Reset All Wafer Count
    'Public Const PERMISSION_0102 As String = "0102" ''Click Other Buttons



    '#End fix.

    Public Const CLICK As String = "Click"
    Public Const SEMI_TRANSFER_FINISH As String = "SEMI_TRANSFER_FINISH"
    Public Const START As String = "START"
    Public Const [STOP] As String = "STOP"
    Public Const REZUME As String = "RESUME"
    Public Const PAUSE As String = "PAUSE"
    Public Const MACHINEONLINE As String = "mnuMechineOnline"
    Public Const LEFTONLINE As String = "mnuLeftOnline"
    Public Const RIGHTONLINE As String = "mnuRightOnline"
    Public Const MECHINEONLINE As String = "mnuMechineOnline"
    Public Const LEFTSTOPPUMPDOWN As String = "mnuLeftStopPumpDown"
    Public Const RIGHTSTOPPUMPDOWN As String = "mnuRightStopPumpDown"
    Public Const MACHINESTOPPUMPDOWN As String = "mnuMechineStopPumpDown"
    Public Const LEFTSTOPVENT As String = "mnuLeftStopVent"
    Public Const RIGHTSTOPVENT As String = "mnuRightStopVent"
    Public Const MACHINESTOPVENT As String = "mnuMechineStopVent"
    Public Const LEFT_VALVE As String = "0"
    Public Const MACHINE_VALVE As String = "1"
    Public Const RIGHT_VALVE As String = "2"
    Public Const STRING_OPEN As String = "Open"
    Public Const STRING_CLOSE As String = "Close"
    Public Const STRING_OFF As String = "Off"
    Public Const STRING_ON As String = "On"
    Public Const STRING_G As String = "G"
    Public Const STRING_MIN As String = "Min"
    Public Const STRING_MAX As String = "Max"
    Public Const LOADLOCKA As String = "lpcLoadLockA"
    Public Const LOCKCASSETTEA As String = "lccLoadLockA"
    Public Const ONLINETM As String = "Transfer Module"
    Public Const WAFER_PROCESSING As String = "Wafer Processing"
    Public Const START_SEMIAUTOTRANFER As String = "Semi Auto TM"
    Public Const SEND_SERIALCOMMAND As String = "Serial Command"
    Public Const HOME_TM As String = "Home"
    Public Const ALIGN As String = "Align"
    Public Const ROBOT_STR As String = "Robot"
    Public Const CHAMBER_STR As String = "Chamber"
    Public Const CLAMP As String = "Clamp"
    Public Const UNCLAMP As String = "UnClamp"
    Public Const CURRENT_PURGE_CYCLE As String = "Purge Current Cycle : "
    Public Const GAS_UNIT As String = "(sccm)"
    Public Const TAB_INDEX_NO_FOCUS As Int32 = 1000

#Region "Chamber1Panel"
    Public Const STRING_STOP_PUMP_DOWN As String = "Stop Pump Down"
    Public Const STRING_ABORT_PUMP_DOWN As String = "Abort Pump Down"
    Public Const STRING_START_PUMP_DOWN As String = "Start Pump Down"
    Public Const STRING_OFFLINE As String = "Offline"
    Public Const STRING_ONLINE As String = "Online"
    Public Const STRING_MAINTENANCE As String = "Maintenance"

    Public Const STRING_ABORT_VENT As String = "Abort Vent"
    Public Const STRING_STOP_VENT As String = "Stop Vent"
    Public Const STRING_START_VENT As String = "Start Vent"
    Public Const STRING_CRYO_ON As String = "Cryo On"
    Public Const STRING_CRYO_OFF As String = "Cryo Off"
    Public Const STRING_CRYO_REGEN As String = "Cryo Regen"
    Public Const STRING_WATERPUMP_ON As String = "WaterPump On"
    Public Const STRING_WATERPUMP_OFF As String = "WaterPump Off"

    Public Const STRING_ABORT_CRYO_REGEN As String = "Abort Cryo Regen"
    Public Const STRING_CRYO_PUMP_REGEN As String = "Cryo Pump Regen"
    Public Const STRING_ABORT_WATERPUMP_REGEN As String = "Abort WaterPump Regen"
    Public Const STRING_WATERPUMP_REGEN As String = "WaterPump Regen"

    Public Const STRING_CLOSE_HIVAC As String = "Close HiVac"
    Public Const STRING_OPEN_HIVAC As String = "Open HiVac"
    ''use in ValveControl_Click
    Public Const STR_PANEL As String = "Panel"
    ''use in mnuTooltipFixture_Click                    
    Public Const MNU_FIXTURE_HOME_ALL_AXIS As String = "mnuFixtureHomeAllAxis"
    Public Const MNU_FIXTURE_ON_CLAMP As String = "mnuFixtureOnClamp"
    Public Const MNU_FIXTURE_UN_CLAMP As String = "mnuFixtureUnClamp"
    Public Const MNU_FIXTURE_STOP_ALL_AXIS As String = "mnuFixtureStopAllAxis"
    Public Const MNU_FIXTURE_HOME_TILT_AXIS As String = "mnuFixtureHomeTiltAxis"
    Public Const MNU_FIXTURE_HOME_ROTATION_AXIS As String = "mnuFixtureHomeRotationAxis"
    Public Const MNU_FIXTURE_START_ROTATION_AXIS As String = "mnuFixtureStartRotationAxis"
    Public Const MNU_FIXTURE_OPEN_WATER_VALVE As String = "mnuFixtureOpenWaterValve"
    Public Const MNU_FIXTURE_OPEN_FLOW_COOL As String = "mnuFixtureOpenFlowCool"

    ''use in tmWaitingForHivacValveChange_Tick
    Public Const HIVAC_VALVE_CONTROL_OPEN_FAIL As String = "HivacValveControlOpenFail"
    Public Const HIVAC_VALVE_CONTROL_CLOSE_FAIL As String = "HivacValveControlCloseFail"
    Public Const HIVAC_VALVE As String = "HiVacValve"
    ''USE IN ChangeStatusTooltipFixture
    Public Const OPEN_SHUTTER As String = "Open Shutter"
    Public Const CLOSE_SHUTTER As String = "Close Shutter"
    Public Const CLAMP_DOWN As String = "Clamp Down"
    Public Const CLAMP_UP As String = "Clamp Up"
    Public Const HOME_ALL_AXIS As String = "Home All Axis"
    Public Const STOP_ALL_AXIS As String = "Stop ALl Axis"
    Public Const HOME_TILT_AXIS As String = "Home Tilt Axis"
    Public Const HOME_ROTATION_AXIS As String = "Home Rotation Axis"
    Public Const START_ROTATION_AXIS As String = "Start Rotation Axis"
    Public Const STOP_ROTATION_AXIS As String = "Stop Rotation Axis"
    Public Const FIXTURE_WATER_VALVE As String = "Fixture Water Valve"
    Public Const FIXTURE_FLOWCOOL_PUMP_POWER As String = "Fixture FlowCool Pump Power"
    Public Const OPEN_WATER_VALVE As String = "Open Water Valve"
    Public Const CLOSE_WATER_VALVE As String = "Close Water Valve"
    Public Const OPEN_FLOW_COOL As String = "Open Flow Cool Pump Power"
    Public Const CLOSE_FLOW_COOL As String = "Close Flow Cool Pump Power"
    Public Const TURBO_PUMP_POWER_ON As String = "Turn Turbo Pump On"
    Public Const TURBO_PUMP_POWER_OFF As String = "Turn Turbo Pump Off"
    Public Const ROUGH_PUMP_POWER_ON As String = "Turn Rough Pump On"
    Public Const ROUGH_PUMP_POWER_OFF As String = "Turn Rough Pump Off"
    Public Const CRYO_AUTO_PUMP_REGEN As String = "Cryo Auto Pump Regen"
    Public Const CRYO_REGEN As String = "Cryo Regen"
    Public Const SHUT_DOWN_POWER As String = "Shut Down Power"
    ''use in mnuMachineOnline_TextChanged
    Public Const PUMP_DOWN As String = "Pump Down"
    Public Const PUMP_PURGE As String = "Pump Purge"
    Public Const IG_DEGAS As String = "IG Degas"
    Public Const FAST_REGEN As String = "Fast Regen"
    Public Const VENT As String = "Vent"
    Public Const STR_ALIGNER As String = "Aligner"
    Public Const CHAMBER1 As String = "Chamber 1"
    Public Const CHAMBER2 As String = "Chamber 2"
    Public Const CHAMBER3 As String = "Chamber 3"
    Public Const LOAD_LOCK_A As String = "LoadLockA"
    Public Const WAFER_INSIDE_CHAMBER1 As String = "WaferInsideChamber1"
    Public Const WAFER_INSIDE_CHAMBER2 As String = "WaferInsideChamber2"
    Public Const WAFER_INSIDE_CHAMBER3 As String = "WaferInsideChamber3"
    Public Const WAFER_INSIDE_LOADER As String = "WaferInsideLoader"
#End Region

#Region "TransferChamberPanel"
    ''use in rrcRoundRectangleStatus9_Click
    Public Const MESA_VALVE As String = "rrcMesaValve"
    ''use in rrcRoundRectangleStatus7_Click
    Public Const MESA_VALVE_PM1 As String = "MesaValvePM1"
    ''use in rrcRoundRectangleStatus1_Click
    Public Const MESA_VALVE_PM2 As String = "MesaValvePM2"
    ''use in rrcRoundRectangleStatus2_Click
    Public Const MESA_VALVE_PM3 As String = "MesaValvePM3"
    ''use in rrcRoundRectangleStatus3_Click
    Public Const MESA_VALVE_LLA As String = "MesaValveLLA"
    ''use in rrcRoundRectangleStatus6_Click
    ''use in ibsHivacButton_Click
    Public Const HIVAC_BUTTON_OPEN As String = "ibsHivacButtonOpen"
    Public Const HIVAC_BUTTON_CLOSE As String = "ibsHivacButtonClose"
    Public Const HIVAC_BUTTON_UNKNOWN As String = "ibsHivacButtonUnknown"
    Public Const ROUGH_VALVE As String = "ValveRough"
    Public Const VENT_VALVE As String = "ValveVent"
    Public Const VALVE_VENT As String = "VentValve"
    Public Const VALVE_ROUGH As String = "RoughValve"
    Public Const VALVE_LLA_SLOW_VENT As String = "ValveLLASlowVent"
    Public Const VALVE_LLA_FAST_VENT As String = "ValveLLAFastVent"
    Public Const VALVE_LLA_SLOW_ROUGH As String = "ValveLLASlowRough"
    Public Const VALVE_LLA_FAST_ROUGH As String = "ValveLLAFastRough"
    Public Const VALVE_LLA_TURBO As String = "ValveLLATurbo"
    Public Const VALVE_TM_TURBO As String = "ValveTMTurbo"
#End Region

#Region "StatusContextMenuStrip"

    Public Const CMSMACHINETOOL As String = "cmsMechineTool"

#End Region

#Region "Sequence Dialog"
    Public Const WAFER_FLOW As String = "WaferFlow"
    Public Const SLOT As String = "Slot"
    Public Const SELECTED As String = "Selected"
    Public Const GRID_HEIGHT_STYLE As Integer = 35
    Public Const GRID_HEIGHT_DEFAULT As Integer = 40
    Public Const SEQUENCE As String = "Sequence"
    Public Const STR_SEQUENCE_EMPTY As String = "Sequence is empty"
#End Region

#Region "Wafer Flow"
    Public Const STR_DELETE As String = "Delete"
    Public Const STR_CANCEL As String = "Cancel"
    Public Const STR_RECIPE_EMPTY_WARNING As String = "Invalid wafer flow. Recipe name is empty."
    Public Const STR_DUPLICATE_STEP_WARNING As String = "Invalid wafer flow. Steps are duplicated"
    Public Const STR_WAFERFLOW_NOFLOW As String = "WaferFlow has no flow to work"
#End Region

#Region "Single Loader"
    Public Const STR_CRYO_REGEN_VALVE_OPEN As String = "Open Cryo Regen Valve"
    Public Const STR_CRYO_REGEN_VALVE_CLOSE As String = "Close Cryo Regen Valve"
    Public Const STR_PROCESS_MODULE As String = "Process Module"
    Public Const STR_WATERPUMP_REGEN_ON As String = "Start WaterPump Regen"
    Public Const STR_WATERPUMP_REGEN_OFF As String = "Abort WaterPump Regen"
    Public Const STR_CRYO_PURGE_OPEN As String = "Open Cryo Purge"
    Public Const STR_CRYO_PURGE_CLOSE As String = "Close Cryo Purge"
    Public Const STR_CRYO_GATE_OPEN As String = "Open Cryo Gate"
    Public Const STR_CRYO_GATE_CLOSE As String = "Close Cryo Gate"
    Public Const STR_WP_GATE_OPEN As String = "Open WaterPump Gate"
    Public Const STR_WP_GATE_CLOSE As String = "Close WaterPump Gate"
    Public Const STR_AUTO_REGEN_ON As String = "Start Auto Regen"
    Public Const STR_AUTO_REGEN_OFF As String = "Abort Auto Regen"
    Public Const STR_AUTO_POWER_DOWN_ON As String = "Auto Power Down On"
    Public Const STR_AUTO_POWER_DOWN_OFF As String = "Auto Power Down Off"
    Public Const STR_AUTO_PUMPDOWN_ON As String = "Auto Pump Down"
    Public Const STR_AUTO_PUMPDOWN_OFF As String = "Abort Auto Pump Down"
    Public Const STR_AUTO_VENT_ON As String = "Auto Vent"
    Public Const STR_AUTO_VENT_OFF As String = "Abort Auto Vent"
    Public Const STR_RUN_RATE_OF_RISE As String = "Rate Of Rise"
    Public Const STR_ABORT_RATE_OF_RISE As String = "Abort Rate Of Rise"
    'Fixture
    Public Const STR_FLOWCOOL_PUMP_POWER_ON As String = "Pump Power On"
    Public Const STR_FLOWCOOL_PUMP_POWER_OFF As String = "Pump Power Off"
    Public Const STR_FLOWCOOL_COOLING_WATER_ON As String = "Cooling Water On"
    Public Const STR_FLOWCOOL_COOLING_WATER_OFF As String = "Cooling Water Off"
    Public Const STR_FLOWCOOL_UNPROTECTED_ON As String = "Unprotected On"
    Public Const STR_FLOWCOOL_UNPROTECTED_OFF As String = "Unprotected Off"

    Public Enum FixtureMode
        [Static]
        [Sweep]
        [Continuous]
        [Home]
    End Enum

#End Region

#Region "LoadLockProcess"
    Public Const COMPLETED_PROCESSING As String = "Complete Processing..."
    Public Const RUNNING As String = "Running..."
    Public Const IDLE As String = "IDLE...  "
    Public Const STOPPING As String = "Stopping..."
    Public Const LOADING As String = "LOADING..."
    Public Const UNLOADING As String = "UNLOADING..."
    Public Const ABORT_AND_RETURN_WAFER As String = "Abort and Return Wafer..."
    Public Const SCHEDULER As String = "Scheduler "

    Public Const STR_RUNNING As String = "running"
    Public Const STR_STOP As String = "stop"
    Public Const STR_ABORT As String = "abort"
    Public Const STR_ABORT_AND_RETURN As String = "abort and return"
    Public Const STR_COMPLETED As String = "completed"

    Public Const STR_FORMAT_DATE_DOT As String = "yyyy.MM.dd"
    Public Const STR_FORMAT_DATE_DASH As String = "yyyy-MM-dd"
    Public Const STR_FORMAT_DATE_UNDERLINED As String = "yyyy_MM_dd"
    Public Const STR_FORMAT_DATE_UNDERLINED2 As String = "MM_dd_yyyy"
    Public Const PATTERN_DATE_UNDERLINED As String = "\d{4}_\d{2}_\d{2}"
#End Region
End Class
