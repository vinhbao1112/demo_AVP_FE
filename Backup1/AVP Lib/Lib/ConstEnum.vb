Public Delegate Function CheckCondition() As Boolean
Public Delegate Function CheckMultiCondition(<[ParamArray]()> ByVal Arg() As Object) As Boolean
Public Delegate Function CheckConditionOneParam(ByVal para1 As String) As Boolean

' Delegate to fire data
Public Delegate Sub DataCollectEvent(ByVal Type As ConstEnum.RoutineType, ByVal SecsNo As Integer, ByVal Value As Single)

Public Class ConstEnum

    ''' <author>
    '''    	<name> Nguyen Thanh Nam</name>
    '''    	<date> 2015-5-8</date>
    ''' </author>
    ''' <summary>    
    ''' </summary>
    ''' <remarks></remarks>
#Region "GUI Setup"

    Public Enum Support_Screen
        TM
        ProcessScreen
    End Enum

    Public Enum Support_CX
        Not_Support_Yet
        Support_CX4
    End Enum

    Public Enum PMPosition
        Original
        LLA
        PM1
        PM2
        PM3
        CX4
        HivacLLA
    End Enum

    Public Enum Support_PM
        IBE
        IBD
        PVD
        HRPVD
        PVD6S
        PVD6P
        RIE
    End Enum

    Public Enum DistanceToTMCenter
        ' number pixcel from TM Center image to slitvavle image in PM
        CX4_PM = 66
        ' number pixcel from TM Center image to slitvavle image in LL
        CX4_LL = 66

    End Enum

    Public Enum ArmStatus
        Extend
        Extend_Aligner
        Retract
        Extend_Pick
        Extend_Alinger_Pick
    End Enum

    Public Enum RunningState
        NotDefined = 0
        Running = 1
        Complete = 2
        [Error] = 3
    End Enum

    Public Const HEIGHT_PIVOT As Integer = 12
    Public Const HEIGHT_PIVOT_WAFER_ON_ARM_EXTEND = 160
    Public Const HEIGHT_PIVOT_WAFER_ON_ARM_EXTEND_ALIGNER = 110
    Public Const HEIGHT_PIVOT_WAFER_ON_ARM_RETRACT = 70

    Public Class ANGLE_AND_SCALE
        Public Angle As Integer
        Public Scale As Single
        Sub New(ByVal _angle As Integer, ByVal _scale As Single)
            Angle = _angle
            Scale = _scale
        End Sub
    End Class

    Enum ANGLE

        'CX4 with angle + scale
        Support_CX4_LLA = 0
        Support_CX4_PM1 = 90
        Support_CX4_PM2 = 180
        Support_CX4_PM3 = -90
        Support_CX4_Original = 0


        Support_CX4_HivacLLA = -61
    End Enum

    Enum ANGLE_ARM

        'CX8 with angle + scale
        Support_CX4_LLA = 0
        Support_CX4_PM1 = 90
        Support_CX4_PM2 = 180
        Support_CX4_PM3 = -90
        Support_CX4_Original = 0


        Support_CX4_HivacLLA = -61
    End Enum


#End Region
#Region "Cryo P Command Param" ''as a Dung suggest
    Public Const REGEN_PARAM_ID_PUMP_RESTART_DELAY As String = "0#"
    Public Const REGEN_PARAM_ID_EXTENDED_PURGE_TIME As String = "1#"
    Public Const REGEN_PARAM_ID_REPURGE_CYCLES As String = "2#"
    Public Const REGEN_PARAM_ID_ROUGH_TO_PRESSURE As String = "3#"
    Public Const REGEN_PARAM_ID_RATE_OF_RISE As String = "4#"
    Public Const REGEN_PARAM_ID_START_UP_TEMPERATURE As String = "6#"
#End Region
#Region "Update GEM Load Lock State"
    'State of LoadLock, possible values include 0=IDLE, 1=ERROR, 2=SETUP, 3=READY, 4=VENTING
    Public Enum LoadLockState
        IDLE = 0
        [ERROR] = 1
        [SETUP] = 2
        [READY] = 3
        VENTING = 4
    End Enum
#End Region
#Region "Constants"
    Public Const TWOLIGHTALARM As Integer = 2
    Public Const THREELIGHTALARM As Integer = 3
    Public Const FOURLIGHTALARM As Integer = 4

    Public Const MPCommunicationTimeOut As Int64 = 60 '60s
    Public Const DataRunFileNameSeparator As String = "~~~"

    Public Const SEPARATOR_CMD_DATA As String = ":"
    Public Const ROBOT_VERSION_7_1 As Double = 7.1
    Public Const ROOT_USER_NAME As String = "ROOT"
    Public Const CLICKEDNOWHERE As Integer = -1
    Public Const CLICKEDALIGNER As Integer = 0
    Public Const CLICKEDCHAMBER1 As Integer = 1
    Public Const CLICKEDCHAMBER2 As Integer = 2
    Public Const CLICKEDCHAMBER3 As Integer = 3
    Public Const CLICKEDROBOT As Integer = 7
    Public Const CLICKEDLOADLOCKA As Integer = 8
    Public Const ADMINISTRATOR As String = "Administrator"
    Public Const STR_OPERATOR As String = "Operator"
    Public Const TARGET_POWER_SUPPLY_STR As String = "TargetPowerSupply"
    Public Const RFTARGET_POWER_SUPPLY_STR As String = "RFTargetPowerSupply"
    Public Const BIAS_POWER_SUPPLY_STR As String = "BiasPowerSupply"
    Public Const IBE_SOURCE_STR As String = "IBESourceValue"
    Public Const PRESET_C1_STR As String = "C1"
    Public Const PRESET_C2_STR As String = "C2"
    Public Const PRESET_ID_STR As String = "id"
    Public Const MARK_FOR_RETURN As String = "MarkForReturn"
    Public Const RESUME_STR As String = "Resume"
    Public Const SCIENTIFIC_FORMAT As String = "0.00E+00"
    Public Const SCIENTIFIC_FORMAT_DECIMAL As String = "0.0E+00"
    Public Const TRANSFER_SET_POINT_WAIT_TIME_IN_SECONDS = "TransferSetPointWaitTimeInSeconds"
    Public Const OPEN_SHUTTER_WAIT_TIME_IN_SECONDS = "OpenShutterWaitTimeInSeconds"
    Public Const MOTION_INITIALZE_WAIT_TIME_IN_SECONDS = "MotionInitializeWaitTimeInSeconds"
    Public Const CLAMP_UP_WAIT_TIME_IN_SECONDS = "ClampUpWaitTimeInSeconds"
    Public Const MOVING_CHUCK_TO_ZERO_WAIT_TIME_IN_SECONDS = "MovingChuckToZeroWaitTimeInSeconds"
    Public Const PVD_UNCLAMP_WAIT_TIME_IN_SECONDS = "PvdUnClampWaitTimeInSeconds"
    Public Const CHUCK_AT_PUMP_DOWN_POSTION = "ChuckatPumpDownPostion"
    Public Const TRANSFER_SET_POINT = "TransferSetPoint"
    Public Const CHAMBER1VISIBLE As String = "Chamber1Visible"
    Public Const CHAMBER2VISIBLE As String = "Chamber2Visible"
    Public Const CHAMBER3VISIBLE As String = "Chamber3Visible"
    Public Const CHAMBER4VISIBLE As String = "Chamber4Visible"
    Public Const CHAMBER5VISIBLE As String = "Chamber5Visible"
    Public Const LOADLOCKAVISIBLE As String = "LoadLockAVisible"
    Public Const CHAMBER1NAME As String = "Chamber1Name"
    Public Const CHAMBER2NAME As String = "Chamber2Name"
    Public Const CHAMBER3NAME As String = "Chamber3Name"
    Public Const Return_Wafer_Starting = "Return Wafer Starting..."
    Public Const STR_WaitingMPOn = "Waiting MP On"
    Public Const IGCG_INITVALUE As String = "0.0E+00"
    Public Const TM_STR As String = "TM"
    Public Const LLA_STR As String = "LLA"
    Public Const Abort As String = "Abort"
    Public Const SPACE_STR As String = " "
    Public Const EMPTY_STR As String = ""
    Public Const LoadLockA_STR As String = "LoadLockA"
    Public Const CURRENTSLOT As String = "CurrentSlot"
    Public Const CHANGESLOT As String = "ChangeSlot"
    Public Const IG As String = "IG"
    Public Const CG As String = "CG"
    Public Const IGStatus As String = "IGStatus"
    Public Const STR_EX As String = "EX"
    Public Const STR_RE As String = "RE"
    Public Const MAX_DEFAULT_VALUE As Double = 50000
    Public Const MIN_DEFAULT_VALUE As Double = 0
    Public Const BOOLEAN_PARAM As Integer = 6
    Public Const SEQNO_DEFAULT_VALUE As Integer = 1
    Public Const MAX_DEFAULT_VALUE_OF_CHAMBER As Double = 50000
    Public Const MIN_DEFAULT_VALUE_OF_CHAMBER As Double = 0
    Public Const CHAMBER_VISIBLE_DEFAULT_VALUE As Double = 0

    Public Const LL_MESA_VALVE_OPEN_CLOSE_TIMEOUT As String = "LLMesaValveOpenCloseTimeOut"
    Public Const IG_ON_OFF_TIMEOUT As String = "IGOnOffTimeOut"
    Public Const LL_HIVAC_OPEN_CLOSE_TIMEOUT As String = "LLHivacOpenCloseTimeOut"
    Public Const LLA_SLOW_VENT_TIMEOUT As String = "LLASlowVentTimeOut"
    Public Const LLA_FAST_VENT_TIMEOUT As String = "LLAFastVentTimeOut"
    Public Const LL_VENT_VALVE_OPEN_CLOSE_TIMEOUT As String = "LLVentValveOpenCloseTimeOut"
    Public Const LL_VENT_DELAY_TIME As String = "LLVent_Delay_Time"

    Public Const LLA_SLOW_ROUGH_PRESSURE_TIMEOUT As String = "LLASlowRoughPressureTimeOut"
    Public Const LLA_FAST_ROUGH_PRESSURE_TIMEOUT As String = "LLAFastRoughPressureTimeOut"
    Public Const IG_ON_DELAY As String = "IGOnDelay"
    Public Const LL_ROUGH_VALVE_OPEN_CLOSE_TIMEOUT As String = "LLRoughValveOpenCloseTimeOut"
    Public Const LL_PUMPDOWN_DELAY_TIME As String = "LLPumpDown_Delay_Time"
    Public Const LL_MAKE_ROUGH_LINE_IN_USE_TIMEOUT As String = "LLMakeRoughLineInUseTimeOut"

    Public Const TM_MESA_VALVE_OPEN_CLOSE_TIMEOUT As String = "TMMesaValvesOpenCloseTimeOut"
    Public Const TM_HIVAC_OPEN_CLOSE_TIMEOUT As String = "TMHivacOpenCloseTimeOut"
    Public Const TM_VENT_TIMEOUT As String = "TMVentTimeOut"
    Public Const TM_VENT_VALVE_OPEN_CLOSE_TIMEOUT As String = "TMVentValveOpenCloseTimeOut"
    Public Const TM_VENT_DELAY_TIME As String = "TMVent_Delay_Time"

    Public Const TM_ROUGH_TIMEOUT As String = "TMRoughTimeOut"
    Public Const TM_PUMPDOWN_DELAY_TIME As String = "TMPumdown_Delay_Time"
    Public Const TM_MAKE_ROUGH_LINE_IN_USE_TIMEOUT As String = "TMMakeRoughLineInUseTimeOut"

    Public Const LLA_CG_ON_SLOW_VENT_VALVE_OPEN As String = "LLASlowVentPressure"
    Public Const LLA_CG_ON_FAST_VENT_VALVE_OPEN As String = "LLAVentPressure"

    Public Const LLA_CG_ON_SLOW_ROUGH_VALVE_OPEN As String = "LLASlowRoughPressure"
    Public Const LLA_CG_ON_FAST_ROUGH_VALVE_OPEN As String = "LLAFastRoughPressure"

    Public Const TM_CG_ON_FAST_ROUGH_VALVE_OPEN As String = "TMRoughPressure"
    Public Const TM_CG_ON_LL_FAST_VENT_VALVES_OPEN As String = "TMVentPressure"

    Public Const TM_CG_TRIP_POINT As String = "TMCGTripPoint"
    Public Const LLA_CG_TRIP_POINT As String = "LLACGTripPoint"
    Public Const MP_CG_TRIP_POINT As String = "MPCGTripPoint"
    Public Const TM_TURBO_CG_TRIP_POINT As String = "TMTurboCGTripPoint"
    Public Const LLA_TURBO_CG_TRIP_POINT As String = "LLATurboCGTripPoint"

    Public Const INTERLOCKSAFETY_LLA_CG As String = "InterlockSafetyLLACG"
    Public Const INTERLOCKSAFETY_TM_CG As String = "InterlockSafetyTMCG"

    Public Const TMCryo_T1Min As String = "TMCryo_T1Min"
    Public Const TMCryo_T1Max As String = "TMCryo_T1Max"
    Public Const TMCryo_T2Min As String = "TMCryo_T2Min"
    Public Const TMCryo_T2Max As String = "TMCryo_T2Max"

    Public Const LLACryo_T1Min As String = "LLACryo_T1Min"
    Public Const LLACryo_T1Max As String = "LLACryo_T1Max"
    Public Const LLACryo_T2Min As String = "LLACryo_T2Min"
    Public Const LLACryo_T2Max As String = "LLACryo_T2Max"

    Public Const TurboUptoSpeedThreshold As String = "_TurboUptoSpeedThreshold"

    Public Const LL_ROUGH As String = "LL_Rough"
    Public Const MESA_VALVES As String = "Mesa_Valves"
    Public Const MESA_VALVE As String = "Slit valve "
    Public Const HIVAC_VALVE_DID_NOT_CLOSE As String = "HivacValveDidNotClose"
    Public Const LL_IG_WAS_NOT_OFF As String = "LLIGWasNotOff"
    Public Const TM_IG_WAS_NOT_OFF As String = "TMIGWasNotOff"
    Public Const LL_ISOLATION_VALVE_WAS_NOT_CLOSE As String = "LLIsolationValveWasNotClose"
    Public Const LL_FORELINE_VALVE_OPEN_FAILED As String = "LLForelineValveOpenFailed"
    Public Const LL_FAST_VENT_WAS_NOT_CLOSE As String = "LLFastVentWasNotClose"
    Public Const TM_VENT_VALVES_WAS_NOT_CLOSE As String = "TMVentValvesWasNotClose"
    Public Const LL_SLOW_VENT_WAS_NOT_CLOSE As String = "LLSlowVentWasNotClose"
    Public Const TM_ROUGH_VAVLES_WAS_NOT_CLOSE As String = "TMRoughValvesWasNotClose"
    Public Const LL_FAST_ROUGH_WAS_NOT_CLOSE As String = "LLFastRoughWasNotClose"
    Public Const T2_LOADLOCK_CRYO_LESS_THAN_20K As String = "T2LoadLockCryoLessThan20K"
    Public Const CRYO_T1_TEMP_LESS_THAN As String = "CryoT1TempLessThan"
    Public Const CG_OF_TM_AND_RELATED_EQUIPMENT_NO_DIFFER10 As String = "CGOfTMAndRelatedEquipmentNoDiffer10"
    Public Const LOADLOCK_OFFLINE As String = " is offline"
    Public Const PUMPDOWN_ABORTED As String = " Pumpdown aborted by user."
    Public Const PUMPDOWN_FAILED As String = " Pumpdown failed."
    Public Const RATE_OF_RISE_FAILED As String = " Rate Of Rise Failed"
    Public Const RATE_OF_RISE_ABORTED As String = " Rate Of Rise Aborted by user"
    Public Const PUMPDOWN_CURVE_FAILED As String = " Pumpdown Curve Failed"
    Public Const PUMPDOWN_CURVE_ABORTED As String = " Pumpdown Curve Aborted by user."
    Public Const IG_DEGAS_FAILED As String = " IG Degas Failed."
    Public Const IG_DEGAS_ABORTED As String = " IG Degas Aborted by user."
    Public Const VENT_ABORTED As String = " Vent aborted by user."
    Public Const VENT_FAILED As String = " Vent failed."
    Public Const TM_OFFLINE As String = " Transfer Module is offline"
    Public Const TM_PUMPDOWN_ABORTED As String = " Transfer Module pumpdown aborted by user"
    Public Const TM_PUMPDOWN_FAILED As String = " Transfer Module pumpdown failed"
    Public Const TM_VENT_ABORTED As String = " Transfer Module vent aborted by user."
    Public Const TM_VENT_FAILED As String = " Transfer Module vent failed"
    Public Const ONLINELOADLOCKA As String = "LoadLockA"
    Public Const TRANSFERMODULE_STR As String = "Transfer Module"
    Public Const AUTO_PUMPDOWN_RUNNING As String = "Auto PumpDown Is Running"
    Public Const AUTO_VENT_RUNNING As String = "Auto Vent Is Running"
    Public Const MECHANICAL_PUMP_NOT_ON As String = "Mechanical Pump is not on"
    Public Const MECHANICAL_PUMP_PRESSURE_NOT_REACH As String = "Mechanical Pump CG Pressure is not less than {0}"
    Public Const STR_SEQUENCE_AUTO_PUMPDOWN As String = "[AUTO_PUMP_DOWN]"
    Public Const STR_SEQUENCE_AUTO_VENT As String = "[AUTO_VENT]"
    Public Const STR_SEQUENCE_LOAD As String = "[LOAD]"
    Public Const STR_SEQUENCE_UNLOAD As String = "[UNLOAD]"

    Public Const CG_DISCONNECTED = ": CG is disconnected."
    Public Const IG_DISCONNECTED = ": IG is disconnected."
    Public Const TURBOFORELINE_CG_DISCONNECTED = ": Turbo Foreline CG is disconnected."
    Public Const MECHANICAL_PUMP_CG_DISCONNECTED = ": Mechanical Pump CG is disconnected."
    Public Const CAN_NOT_RUN_ROR_DUE_TO_HIVAC_NOT_PRESENT = "Cannot run ROR due to Hivac valve not present."

    Public Const GO_ONLINE_FAILED As String = ". Go Online failed "
    Public Const CANNOT_TRANSFER_WAFER As String = "CannotTransferWafer"

    Public Const LLELEVATOR_TIMEOUT As String = "LLElevatorRequestStatus"

    Public Const DEVICE_VISIBLE As String = "1"
    Public Const DEVICE_INVISIBLE As String = "0"

    Public Const NUMBER_OF_SLOT As String = "NumberOfSlot"
    Public Const TRAVEL_LENGTH As String = "TravelLength"
    Public Const PITCH As String = "Pitch"
    Public Const BASE_OFFSET As String = "BaseOffset"
    Public Const FIND_BIAS As String = "FindBias"
    Public Const WAFER_THICKNESS_TYPE As String = "Wafer_Thickness_Type"

    Public Const CONFIG_NUMBER_OF_SLOT = "Elevator.ConfigNumberOfSlot"
    Public Const CONFIG_PITCH = "Elevator.ConfigPitch"
    Public Const CONFIG_BASE_OFFSET = "Elevator.ConfigBaseOffset"
    Public Const CONFIG_TRAVEL_LENGTH = "Elevator.ConfigTravelLength"
    Public Const CONFIG_FIND_BIAS = "Elevator.ConfigFindBias"
    Public Const CONFIG_WAFER_THICKNESS_TYPE = "Elevator.Wafer_Thickness_Type"
    Public Const LOG_INTERVAL_DEFAULT As String = "1"
    ''Public Const LOADER_REQUEST_STATUS As String = "LoaderRequestStatus"
    Public Const FAKE_TILT_ANGLE_ERROR_VALUE As String = "9999"
    'Public Const LOADER_STR As String = "LOADER"
    Public Const PM_STR As String = "CHAMBER1"

    Public Const PM_RECONNECT_TRY_TIME As Integer = 3 '3 times

    Public Const NUM_DAY_DELETE_OLD_FILE_LOG_ERROR As Integer = 7

    Public Const NUM_DAY_DELETE_OLD_FILE_LOG_DATA_LOT As Integer = 90
    Public Const STR_ROUGH_PUMP_IN_USE As String = "Rough Pump is in used by "
    Public Const ExpectedMechanicalPumpPressureWhenPumpDown As Double = 0.1 ' 0.1 Torr

    Public Const MAPPING_SUCCESS As String = "MAPPING_SUCCESS"
    Public Const MAPPING_FAIL As String = "MAPPING_FAIL"

    Public Const STR_CSV_EXT As String = ".csv"
    Public Const STR_XML_EXT As String = ".xml"
    Public Const STR_PUMP_DOWN_CURVE As String = "PumpdownCurve"
    Public Const STR_RATE_OF_RISE As String = "RateOfRise"
    Public Const STR_RECOVER_PRESSURE As String = "RecoverPressure"
    Public Const STR_STOP_PUMP_DOWN_CURVE As String = "StopPumpdownCurve"
    Public Const STR_STOP_RATE_OF_RISE As String = "StopRateOfRise"
    Public Const STR_STOP_RECOVER_PRESSURE As String = "StopRecoverPressure"
    Public Const STR_DISABLE As String = "Disable"
    Public Const STR_COMMA As String = ","
    Public Const STR_SEMICOLON As String = ";"
    Public Const STR_EQUAL As String = "="
    Public Const STR_OPEN_ANGLE_BRACKETS As String = "{"
    Public Const STR_CLOSE_ANGLE_BRACKETS As String = "}"

    Public Const SPLIT_VALVE_LLA As String = "SplitValveLLA"
    Public Const SPLIT_VALVE_PM1 As String = "SplitValvePM1"
    Public Const SPLIT_VALVE_PM2 As String = "SplitValvePM2"
    Public Const SPLIT_VALVE_PM3 As String = "SplitValvePM3"

    Public Const SETATMCONVERTRON As String = "SetATMConvertronGauge"
    Public Const SETVACCONVERTRON As String = "SetVACConvertronGauge"

    Public Const SETATMFORELINECG As String = "SetATMForelineConvertronGauge"

    Public Const CG_IG_FORM = "CGGaugesFrm"
    Public Const MECHANICAL_PUMP As String = "Mechanical Pump"
    Public Const ROUGH_PUMP As String = "Rough Pump"
    Public Const ATM_VALUE As Single = 760
    Public Const TOLERANCE As Single = 0.5
    Public Const DEVICENET_SET_ATM As String = "SetATM"
    Public Const DEVICENET_SET_VAC As String = "SetVAC"
    Public Const MP As String = "MP"
    Public Const FORELINE As String = "Foreline"
    Public Const ROUGHLINE As String = "Roughline"
    Public Const PRESSURE As String = "Pressure"
    Public Const ROUGHPUMP As String = "RoughPump"
    Public Const SET_ATM_FORELINE_CG As String = "SetATMForelineCG"
    Public Const SET_VAC_FORELINE_CG As String = "SetVACForelineCG"
    Public Const SET_ATM_ROUGHPUMP_CG As String = "SetATMRoughPumpCG"
    Public Const SET_VAC_ROUGHPUMP_CG As String = "SetVACRoughPumpCG"
    Public Const SET_ATM_PRESSURE_CG As String = "SetATMPressureCG"
    Public Const SET_VAC_PRESSURE_CG As String = "SetVACPressureCG"
    Public Const SET_ATM_ROUGHLINE_CG As String = "SetATMRoughlineCG"
    Public Const SET_VAC_ROUGHLINE_CG As String = "SetVACRoughlineCG"
    Public Const SET_TRIP_POINT As String = "SetTripPoint"
    Public Const TURN_IG_ON_OFF As String = "IGStatus"

    'Archive system config, data files
    Public Const STR_CTC As String = "CTC"
    Public Const STR_CONFIG_FILES As String = "ConfigFiles"
    Public Const STR_DATA_FILES As String = "DataFiles"
    Public Const STR_JOB_FILES As String = "JobFiles"
    Public Const STR_RECIPES As String = "Recipes"
    Public Const STR_WARER_FLOWS As String = "WaferFlows"
    Public Const STR_ARCHIVED As String = "Archived"
    Public Const STR_DATARUN As String = "DataRun"

    Public Const STR_ROBOT_ARM As String = "RobotArm"

    Public Const STR_AUTO_SEND_MAIL As String = "AutoSendMail"
    Public Const STR_SMTP_SERVER As String = "SMTPServer"
    Public Const STR_PORT_ID As String = "PortID"
    Public Const STR_USER_NAME As String = "UserName"
    Public Const STR_PASSWORD As String = "Password"
    Public Const STR_EMAIL_TO As String = "EmailTo"
    Public Const STR_ITEM As String = "Item"
    Public Const STR_NAME As String = "Name"
    Public Const STR_ACTIVE As String = "Active"
    Public Const STR_ALARM As String = "Alarm"
    Public Const STR_SCHEDULER As String = "Scheduler"
    Public Const STR_PRESSURE As String = "Pressure"
    Public Const STR_PRESSURE_INTERVAL As String = "PressureInterval"

    Public Const STR_PASSWORD_EXIT_DEVICENET_APP As String = "PasswordExitDeviceNetApp"

    Public Const STR_CREATE_WAFER As String = "Create"
    Public Const STR_DELETE_WAFER As String = "Delete"
    Public Const STR_UPDATE_WAFER As String = "Update"

    Public Const ELEVATOR_COMMAND_COMUNICTION_ALIVE As String = "00,R,ER"
    Public Const ROBOT_COMMAND_COMUNICTION_ALIVE As String = "HLLO"
    Public Const ALIGNER_COMMAND_COMUNICTION_ALIVE As String = "RVSN"

    Public Const NUM_1000 As Integer = 1000
    Public Const NUM_9999 As Integer = 9999

    Public Const STR_CHAMBER1 As String = "Chamber1"
    Public Const STR_CHAMBER2 As String = "Chamber2"
    Public Const STR_CHAMBER3 As String = "Chamber3"

    'Chiller Tolerance
    Public Const CHILLER_PROCESS_TEMPERATURE_MAX As String = "ChillerProcessTemperatureMax"
    Public Const CHILLER_VENT_TEMPERATURE_MAX As String = "ChillerVentTemperatureMax"
    Public Const CHILLER_VENT_TEMPERATURE_MIN As String = "ChillerVentTemperatureMin"
    Public Const CHILLER_PROCESS_TEMPERATURE_MIN As String = "ChillerProcessTemperatureMin"
    Public Const cmd_Data_On As String = "01"
    Public Const cmd_Data_Off As String = "00"
#Region "IBEController"
    Public Const Open As String = "Open"
    Public Const Close As String = "Close"
    Public Const IonOn As String = "Ion On"
    Public Const IonOff As String = "Ion Off"
    Public Const STR_ON As String = "On"
    Public Const STR_OFF As String = "Off"
    Public Const STR_UNKNOWN As String = "UNKNOWN"
    Public Const STR_UNCLAMP As String = "ClampDown"
    Public Const STR_ONCLAMP As String = "ClampUp"
    Public Const STR_OTHER As String = "Other"
    Public Const STR_ERROR As String = "Error"
    Public Const SL_WAFERID As String = "S01"
    Public Const SL_AUTO_LOAD_DELAY_TIME As Integer = 1000
#End Region

#Region "ConfigurationServer.xml"
    Public Const Name As String = "Name"
    Public Const EthernetIP As String = "EthernetIP"
    Public Const Port As String = "Port"
    Public Const TerminalServer As String = "TerminalServer"
    Public Const KepServerDevice As String = "KepServerDevice"
    Public Const ChamberInstall As String = "ChamberInstall"
    Public Const Chamber As String = "Chamber"
    Public Const PVD4 As String = "PVD4"
    Public Const PVD As String = "PVD"
    Public Const PVD5T As String = "PVD5T"
    Public Const STR_IBE As String = "IBE"
    Public Const STR_AVP As String = "AVP"
    'Public Const TitleOf_SingleLoader_MsgBox As String = "AVP - Single Loader"
    Public Const STR_REMOVE_FROM_TITLE As String = "Would you like to "
    Public Const TitleOf_IBE_MsgBox As String = "IBE"
    Public Const LoadLock As String = "LoadLock"
    Public Const Cryo As String = "Cryo"
    Public Const ISINSTALLED As String = "IsInstall"
    Public Const ISMANUALDOOR As String = "IsManualDoor"
    Public Const CONFIG_FOLDER As String = "ConfigFolder"
    Public Const RECIPE_FOLDER As String = "RecipeFolder"
    Public Const DATA_RUN_FOLDER As String = "DataRunFolder"
    Public Const DATA_RUN_OUTPUT_FOLDER As String = "DataRunOutputFolder"
    Public Const DATA_RUN_FILENAME As String = "DataRunFilename"
    Public Const ROR_FOLDER As String = "RateOfRiseFolder"
    Public Const ROR_FILENAME As String = "RateOfRiseFilename"
    Public Const PDC_FOLDER As String = "PumpdownCurveFolder"
    Public Const PDC_FILENAME As String = "PumpdownCurveFilename"
    Public Const TYPE_OF_PM As String = "Type"
    Public Const Version As String = "Version"
    Public Const IsSensorInstalled As String = "IsSensorInstall"
#End Region

#Region "ConfigurableVentPumpdown.xml"
    Public Const LLPUMPDOWN_CONFIG As String = "LLPumpdownConfig"
    Public Const TMPUMPDOWN_CONFIG As String = "TMPumpdownConfig"
    Public Const LLVENT_CONFIG As String = "LLVentConfig"
    Public Const TMVENT_CONFIG As String = "TMVentConfig"
    Public Const CG_CONFIG As String = "CGConfig"
#End Region

#Region "StoreGui.xml"
    Public Const WaferChamber1 As String = "WaferChamber1"
    Public Const WaferChamber2 As String = "WaferChamber2"
    Public Const WaferChamber3 As String = "WaferChamber3"

    Public Const HaveInsideWaferChamber1 As String = "HaveInsideWaferChamber1"
    Public Const HaveInsideWaferChamber2 As String = "HaveInsideWaferChamber2"
    Public Const HaveInsideWaferChamber3 As String = "HaveInsideWaferChamber3"

    Public Const HaveInsideWaferAligner As String = "HaveInsideWaferAligner"
    Public Const LastUsedAlignerRecipe As String = "LastUsedAlignerRecipe"
    Public Const HaveInsideWaferRobot As String = "HaveInsideWaferRobot"
    Public Const HaveInsideWaferLoader As String = "HaveInsideWaferLoader"
    Public Const WaferTotalOfLoadLockA As String = "WaferTotalOfLoadLockA"
    Public Const TotalWaferCount As String = "TotalWaferCount"
    Public Const WaferOfLoadLockA As String = "WaferOfLoadLockA"
    Public Const WaferTotalOfLoader As String = "WaferTotalOfLoader"
    Public Const UseLotSystemIDInfo As String = "UseLotSystemIDInfo"
    Public Const WaferOfChamber1 As String = "WaferOfChamber1"
    Public Const WaferOfChamber2 As String = "WaferOfChamber2"
    Public Const WaferOfChamber3 As String = "WaferOfChamber3"

    Public Const LotIDOfLoadLockA As String = "LotIDOfLoadLockA"
    Public Const SequenceIDOfLoadLockA As String = "SequenceIDOfLoadLockA"
    Public Const LifeTimeWafer As String = "LifeTimeWafer"

    Public Const PM1 As String = "PM1"
    Public Const PM2 As String = "PM2"
    Public Const PM3 As String = "PM3"

#End Region

#Region "ChamberController"

    Public Const Slit_Valve1 As Integer = 1
    Public Const Slit_Valve2 As Integer = 2
    Public Const Slit_Valve3 As Integer = 3
    Public Const Slit_Valve4 As Integer = 4
    Public Const Slit_Valve5 As Integer = 5
    Public Const Slit_Valve6 As Integer = 6
    Public Const Slit_Valve7 As Integer = 7

    Public Const ChangeSlitValvePM1On As String = "SplitValvePM1 On"
    Public Const ChangeSlitValvePM1Off As String = "SplitValvePM1 Off"

    Public Const ChangeSlitValvePM2On As String = "SplitValvePM2 On"
    Public Const ChangeSlitValvePM2Off As String = "SplitValvePM2 Off"

    Public Const ChangeSlitValvePM3On As String = "SplitValvePM3 On"
    Public Const ChangeSlitValvePM3Off As String = "SplitValvePM3 Off"

    Public Const ChangeSlitValveLLAOn As String = "SplitValveLLA On"
    Public Const ChangeSlitValveLLAOff As String = "SplitValveLLA Off"

    Public Const SendProcessWaferIDCmdMessage As String = "SendProcessWaferID"
    Public Const SendProcessLotIDCmdMessage As String = "SendProcessLotID"

#End Region

#Region "WaferProcesser"
    Public Const USEALIGNER As String = "UseAligner"
    Public Const USEALIGNER_TRUE As String = "UseAlignerTrue"
    Public Const SELFALIGNER As String = "SelfAligner"
#End Region
#End Region

#Region "Enums"
    Public Enum AllChamberType
        UNDEFINED
        VEECO_IBE
        AVP_IBE ''AVP
        PVD2R4
        PVD
        PVDA
        MECHANICAL_ALIGNER
        IBD
        PVD4
    End Enum

    Public Enum IBEType
        UNDEFINED
        VEECO_IBE
        AVP_IBE ''AVP
    End Enum

    Public Enum RoutineType
        RateOfRise = 0
        PumpdownCurve
        IGDegas
        RecoverPressure
    End Enum
    Public Enum PM_TAG_CONFIG
        NumberOfSlot 'Max_Number_Of_Slot of chamber, only used for Corona Chamber
        Grid_SerialNumber
        Grid_ID
        Grid_RebuildLevel
        Etch_Rate
        IBESourceValue ''for IBE
        IsDeviceNetSystem
        TargetKWHAlarmLimit
        TargetKWHAlarmLimit1
        TargetKWHAlarmLimit2
        TargetKWHAlarmLimit3
        TargetKWHAlarmLimit4
        TargetKWHWarningLimit
        TargetKWHWarningLimit1
        TargetKWHWarningLimit2
        TargetKWHWarningLimit3
        TargetKWHWarningLimit4
        SL_AutoLoad_Unload_DelayTime
        Real_Device_Enable
        PM_DeviceNet
        PVD_Chuck_At_PumpDown_Postion
        SL_ATM_Pressure
        SL_VAC_CG_Pressure
        SourceUsage
        SourceUsageWarning
        SourceUsageLimit
        Max_KWH_SourceUsage
        Max_KWH_SourceUsage1
        Max_KWH_SourceUsage2
        Max_KWH_SourceUsage3
        Max_KWH_SourceUsage4
        IdleThreshold
        WarmUpRecipe
        LastExecution
        UseLotSystemID
        LoggingInterval
        UseSystemWarmUp
        Target_Material
        Target_Material1
        Target_Material2
        Target_Material3
        Target_Material4
        ROR_Litter
        Clamp_Installed
        Main_Gas_ShutOff_Valve_Installed
        Water_Valve_Installed
        Shutter_Visible
        MG
        CG
        DCTargetPowerSupply
        RFTargetPowerSupply
        BiasPowerSupply
        ParallelMagnet
        Interlock_

        PumpingPackage
        TurboPump_Installed
        WaterPump_Installed ''this is AVP Config tag
        Cryo_Installed
        Turbo_Installed

        '2013-01-02 Tin Pham added: for CORONA
        Target1_Installed
        Target2_Installed
        Target3_Installed
        Target4_Installed
        Target5_Installed

        'Added fof CORONA
        Shutter1_Installed
        Shutter2_Installed
        Shutter3_Installed
        Shutter4_Installed
        Shutter5_Installed

        Heater_Zone1_Installed
        Heater_Zone2_Installed

        FilMetricDevice_Installed

        Wafer_Lift_Installed

        Chuck_Position_TSD_Ref
        '--------------------------------------

        ChamberInterlock
        VatValveController
        GasController
        Magnatron
        AutoZero
        FlowCool_Installed
        TurboWater_Installed
        TurboForeline_Installed
        ChamberLid_Installed
        TargetWater_Installed
        LidWater_Installed
        TargetMBWater_Installed
        ClampWater_Installed
        SubMBWater_Installed
        Parallel_Magnet_Installed
        Magnatron_Installed
        Vat_Valve_Installed
        Water_Pump_Installed

        Target_Matchbox_Water_Installed
        Bias_Matchbox_Water_Installed
        Target13Water_Installed
        Target24Water_Installed
        SubstrateTableWater_Installed
        AirPressure_Installed
        MPSerial_Installed

        Shutter_Installed
        FilamentType
        Target_Power_Supply_RF_Installed
        Target_Power_Supply_DC_Installed
        Bias_Power_Supply_Installed
        Bias_Matchbox_Unit_RF_Installed
        Target_Matchbox_Unit_RF_Installed
        Gas1MFCEnable
        Gas2MFCEnable
        Gas3MFCEnable
        Gas4MFCEnable
        Gas5MFCEnable
        Injection_Valve_Installed
        PBNGasEnable
        FlowCoolGasEnable
        SupportMainSecondDistributionValves

        PBNGas_Installed                    ''support min/max IBE
        PP_PumpDownAfterCycleComplete       ''support pump purge
        RF_Power_Supply_Installed           ''support min/max IBE
        MaxBeamVoltageSP                    ''support min/max IBE
        MaxSuppressorVoltageSP              ''support min/max IBE
        ShutterOpenClosedSafeAngleUpper     ''support min/max IBE
        ShutterOpenClosedSafeAngleLower     ''support min/max IBE

        ' Shields/Quartz
        Max_KWH_ShieldsQuartz
        ShieldsQuartzWarning
        ShieldsQuartzLimit
        Max_KWH_ShieldsQuartz1
        ShieldsQuartzWarning1
        ShieldsQuartzLimit1
        Max_KWH_ShieldsQuartz2
        ShieldsQuartzWarning2
        ShieldsQuartzLimit2
        Max_KWH_ShieldsQuartz3
        ShieldsQuartzWarning3
        ShieldsQuartzLimit3
        Max_KWH_ShieldsQuartz4
        ShieldsQuartzWarning4
        ShieldsQuartzLimit4

        IGIsoValveInstalled

        ''IBE
        ANC_Installed
        Internal_Shutter_Sensor_Installed
        DiverterGasValveInstalled
        Chiller_Installed
        Endpoint_Unit_Installed
        FixtureWaterBug_Installed
        FixtureWater_Installed
        ShutterOnFixture
        HasPBNBodyDischargeVoltage
        TiltAngleReferenceAsLegacy
        VerifyTiltSensorAtPosition
        SourceWater_Installed
        PanelInterlock_Installed
        AirPressure_Interlock_Installed
        ChamberPressure_Installed
        ForelinePressure_Installed
        SupportTiltSweepMode
        Fast_Tilt_Installed
        BackTilt_Installed
        Source_Magnet_Power_Supply_Installed
        IGType
        Shared_Mechanical_Pump
    End Enum
    Public Enum IDOfLoadLock
        LoadLockA = 1
        UnKnown = 3
    End Enum
    Public Enum Equipments
        LoadLockA = 1
        Chamber1 = 2
        Chamber2 = 3
        Chamber3 = 4
        Aligner = 8
        Robot = 9
        CassettesModule = 10
        TMPumpPackage = 11
        LLAPumpPackage = 12
        LLAElevator = 14
        RoughPumpMachine1 = 16
        RoughPumpMachine2 = 30
        Alarm = 17
        KepServer = 18
        TMWaterPump = 21

        IonGaugeControl = 22
        TurboForelineCGControl = 23
        RoughlineCGControl = 24
        MechanicalPumpCGControl = 25
        ManoGaugeControl = 26
        LLATurbo = 27
        TMTurbo = 29

        IBE = 31 ' AnyIBE
        PVD = 32 'AnyPVD
        LLACryo = 33
        TMCryo = 35
        DeviceNetApp = 36
        'Add more DeviceNet Here
    End Enum

    'X,07,03,01,01,02,00 => NONE
    'X,07,03,01,01,02,01 => UNPROCESS
    'X,07,03,01,01,02,02 => PARTIAL
    'X,07,03,01,01,02,03 => COMPLETED
    'X,07,03,01,01,02,04 => ERROR

    Public Enum enumWaferStatus
        eWaferNone = 0
        eWaferNew = 1
        eWaferExposed = 2
        eWaferComplete = 3
        eWaferError = 4
    End Enum

    Public Enum enumProcessStatus
        eError = -1
        eStop = 0
        eStart = 1
        ePause = 2
        eContinue = 3
        eResetError = 4
        eEndStep = 5
    End Enum

    Public Enum RobotArmStatus
        UP = 1 ''Up
        DN = 0 ''Down
        UNKNOWN = 2
    End Enum

    Public Enum RobotEXREStatus
        EX = 0 ''EXTERN
        RE = 1 ''RETRACT
        UNKNOWN = 2
    End Enum

    Public Enum RobotPickPlaceStatus
        PICK = 1
        PLACE = 0
    End Enum

    Public Enum Positions
        Unknown = -1
        Original = 0
        LoadLockA = 1
        Chamber1 = 2
        Chamber2 = 3
        Chamber3 = 4
        Aligner_Extract = 8 'Extract
        Aligner_Extract_DeltaPick = 81 'for DeltaPick
        Robot = 9
        ' Should have more position here
        'Arm_At_Aligner = 10
        Arm_At_Aligner_Wafer_Extract = 10 ''Extract
        Arm_At_Aligner_Retract = 47
        Arm_At_Aligner_Retract_with_Wafer = 48
        'pos for Aligner DeltaPick
        Arm_At_Aligner_Wafer_Extract_DeltaPick = 101 ''Extract
        Arm_At_Aligner_Retract_DeltaPick = 471
        Arm_At_Aligner_Retract_with_Wafer_DeltaPick = 481

        'Arm_At_LLA = 12
        Arm_At_LLA_Extract = 11
        Arm_At_LLA_Wafer = 12
        Arm_At_LLA_Wafer_Extract = 13

        'Arm_At_Chamber1 = 20
        Arm_At_Chamber1_Extract = 17
        Arm_At_Chamber1_Wafer = 18
        Arm_At_Chamber1_Wafer_Extract = 19

        'Arm_At_Chamber2 = 24
        Arm_At_Chamber2_Extract = 20
        Arm_At_Chamber2_Wafer = 21
        Arm_At_Chamber2_Wafer_Extract = 22

        'Arm_At_Chamber3 = 28
        Arm_At_Chamber3_Extract = 23
        Arm_At_Chamber3_Wafer = 24
        Arm_At_Chamber3_Wafer_Extract = 25

        Robot_Wafer = 32

        'for single Loader
        Arm_Retract = 37
        Arm_Extend = 38
        Arm_Extend_with_Wafer = 39
        Arm_Retract_with_Wafer = 40
        Arm_Extend_1 = 41
        Arm_Extend_2 = 42
        Arm_Extend_3 = 43
        Arm_Extend_Wafer_1 = 44
        Arm_Extend_Wafer_2 = 45
        Arm_Extend_Wafer_3 = 46

    End Enum

    Public Enum DiagnosticType
        PumpDown_Curve
        Rate_Of_Rise
    End Enum

    Public Enum TriggerType
        NONE
        ALARM
        PRESSURE
        TESTING
        SCHEDULER
    End Enum
#End Region

#Region "Error Message"
    Public Const ALIGNER_ERR_MSG As String = "_ERR"
    Public Const ALIGNER_MONITOR_ERR_MSG As String = "ERR"
    Public Const ROBOT_ERR_MSG As String = "_ERR"
    Public Const LL_ERR_MSG As String = "00,X,ER,"
    Public Const LL_NO_ERR_MSG As String = "00,X,ER,OK"
    ' This is a valid message response from equipment for the robot position
    Public Const LL_VALID_REQ_STATION_MSG_REGEXP As String = "POS\s+STN\s+--\s+00\s+0000\s+--" '"POS STN -- 00 0000 --"
    Public Const LL_ERROR_REPORT As String = "LLErrorReportMessage"
    Public Const GUI_ERROR_REPORT As String = "ErrorMessage"
    Public Const PRESSURE_ERROR As Double = -10000000000
#End Region

#Region "TimeoutLib.vb"
    Public Const TIMEOUT_DEFAULT_VAL As Integer = 500 ''Dat N change from 2000 to 500
#End Region

#Region "PRESSURECONFIG"
    Public Const PRESSURE_DEFAULT_VAL As Integer = 0
    Public Const PUMPDOWN_DEFAULT_VAL As Integer = 0
    Public Const ROUGH_PUMP_CG As String = "PVD.RoughPumpCG"
    Public Const TM_WATER_PUMP_T_CONFIG As Double = 280
#End Region

#Region "POLLINGLIB"
    Public Const POLLING_DEFAULT_VALUE As Integer = 200
    Public Const PVD_POLLING_STATUS_REPORT As String = "PVDStatusReport"
    Public Const IBE_POLLING_CMD As String = "IBEPollingCMD"
    Public Const PVD5T_POLLING_CMD As String = "PVD5TPollingCMD"
#End Region

#Region "IGfomular"
    Public Const CG_FORMULA As String = "CG_Formula"
    Public Const IG_FORMULA As String = "IG_Formula"
    Public Const MIN_STR As String = "min"
    Public Const MAX_STR As String = "max"
#End Region

#Region "DELTA PICK"
    Public Const DEFAULT_STATION_NO_FOR_ALIGNER As Integer = 9
    Public Const DELTA_PICK_STATION As String = "DeltaPickStation"
    Public Const DELTA_PICK_NEEDED As String = "DeltaPickNeeded"
    Public Const DELTA_PICK_MAX_ECCENTRICITY As String = "DeltaPickMaxEccentricity"
    Public Const DELTA_PICK_MAX_RETRY As String = "DeltaPickMaxRetry"
    Public Const ALIGNER_CDD_POSITION As String = "AlignerCDDPosition"
#End Region

#Region "XPATH SYSTEM CONFIG"
    Public Const XPATH_DATACHANGE As String = "/SystemConfiguration/RequestDataChanged"
    Public Const XPATH_MANUALDEFINE_GEMWAFERID As String = "/SystemConfiguration/ManualDefineGEMWaferID"
    Public Const XPATH_CHECK_WAFER_SLIDE_OUT As String = "/SystemConfiguration/CheckWaferSlideOut"
    Public Const XPATH_SYSTEMIDLE_TIME As String = "/SystemConfiguration/SystemIdle_Time"
    Public Const XPATH_LOGOUT_OPTION As String = "/SystemConfiguration/AutoLogoutOption"
    Public Const XPATH_SYSTEM_CLEANUP_TIME As String = "/SystemConfiguration/SystemCleanUpTimeInDays"
    Public Const XPATH_SYSTEM_CLEANUP_DATARUN_TIME As String = "/SystemConfiguration/SystemCleanUpDataRunTimeInDays"
    Public Const XPATH_TOOLID As String = "/SystemConfiguration/ToolID"
    Public Const XPATH_SYSTEM_WAIT_FOR_CHECK_SENSOR As String = "/SystemConfiguration/SystemWaitFor_Check_Sensor_Secs"
    Public Const XPATH_RUN_DATA_FOLDER As String = "/SystemConfiguration/RunDataFolder"
    Public Const XPATH_DEVICENET_CARDNAME As String = "/SystemConfiguration/DeviceNet/DeviceNetCardName"
    Public Const XPATH_DEVICENET_BAUDRATE As String = "/SystemConfiguration/DeviceNet/DeviceNetBaudRate"
    Public Const XPATH_ENABLE_ANYIBE_MODE As String = "/SystemConfiguration/Enable_ANYIBE_Mode"
    Public Const XPATH_ENABLE_PROCESS_CHIME As String = "/SystemConfiguration/Process_Complete_Chime_Installed"
    Public Const XPATH_DEFAULT_CONTROL_STATE As String = "/SystemConfiguration/DefaultOnlineCtrState"
    Public Const XPATH_ALLOW_POPUP_TERMINALMESSAGE As String = "/SystemConfiguration/AllowPopUpTerminalMessage"
    Public Const XPATH_AUTOVENT_WHENPROCESSINGCOMPLETED As String = "/SystemConfiguration/AutoVentWhenProcessingCompleted"
    Public Const XPATH_DELAYTIME_AFTERPROCESSCOMPLETE As String = "/SystemConfiguration/DelayTimeAfterProcessCompleteInMinutes"
    Public Const XPATH_AUTOEXPORT_DATALOG_TOCSV As String = "/SystemConfiguration/AutoExportDataLogToCSV"
    Public Const XPATH_ROUGHPUMP_CONFIG As String = "/SystemConfiguration/RoughPumpConfig"
    Public Const XPATH_LOTDATALOG_FOLDER As String = "/SystemConfiguration/LotDatalogFolder"
    Public Const XPATH_SYSTEMTIMEOUT As String = "/SystemConfiguration/SystemTimeout"
    Public Const XPATH_SYSTEMPOLLING As String = "/SystemConfiguration/SystemPolling"
    Public Const XPATH_NUMBER_LIGHT_ALARM As String = "/SystemConfiguration/NumberLightAlarm"
    Public Const XPATH_NUMBER_ACTIVE_LIGHT As String = "/SystemConfiguration/NumberActiveLight"
    Public Const XPATH_SLOW_VENT_CONFIG As String = "/SystemConfiguration/SlowVentInstalled"
    Public Const XPATH_SLOW_ROUGH_CONFIG As String = "/SystemConfiguration/SlowRoughInstalled"
    Public Const XPATH_ROBOT As String = "/SystemConfiguration/Modules"
    Public Const XPATH_SYSTEMPRESSURE As String = "/SystemConfiguration/SystemPressure"
    Public Const XPATH_TRANSFER_PRESSURE_SET_POINT As String = "/SystemConfiguration/TransferPressureSetpoint"
    Public Const XPATH_INITIALIZATION As String = "/SystemConfiguration/Initialization"
    Public Const XPATH_KEPSERVERTAGSSTATUS As String = "/SystemConfiguration/KepServerTagsStatus"
    Public Const XPATH_KEPSERVERTAGSDEF As String = "/SystemConfiguration/KepServerTagsDef"
    Public Const XPATH_SYSTEMMESSAGEERROR As String = "/SystemConfiguration/SystemMessageError"
    Public Const XPATH_USERMESSAGETEXTS As String = "/SystemConfiguration/UserMessageTexts"
    Public Const XPATH_VENTPUMPDOWNCONFIG As String = "/SystemConfiguration/VentPumpdownConfig"
    Public Const XPATH_CHAMBERSCONFIG As String = "/SystemConfiguration/ChambersConfiguration"
    Public Const XPATH_ROBOTANIMATION As String = "/SystemConfiguration/RobotAnimation"
    Public Const XPATH_DELAYTIME_KEEPALIVE As String = "/SystemConfiguration/DelayTimeForKeepAlive"
    Public Const XPATH_CONNECTION_TIMEOUT As String = "/SystemConfiguration/ConnectionTimeOut"
    Public Const XPATH_DEGAS_WAIT_TIME As String = "/SystemConfiguration/DegasWaitTime"
    Public Const XPATH_CRYO_REGEN_HOUR_LIMIT As String = "/SystemConfiguration/CryoRegenHourLimit"
    Public Const XPATH_SOUND_ON_DURING_ALARM As String = "/SystemConfiguration/SoundOnDuringAlarm"
    Public Const XPATH_LL_ELEVATOR_CONFIG As String = "/SystemConfiguration/LLElevatorConfig"
    Public Const SEQ_DESCRIPTION_TAG = "Description"
    Public Const XPATH_SUBSYSTEM_LIST_CONFIG As String = "/SystemConfiguration/Modules/Module/SubSystemList"
    Public Const XPATH_SYSTEM_DATE_RUN As String = "/SystemConfiguration/SystemDateRun"
    Public Const XPATH_ADMIN_AUTOLOG_OFF_TIME As String = "/SystemConfiguration/SystemIdle_Time"
    Public Const XPATH_ETCH_RATE_CONTROL As String = "/SystemConfiguration/Modules/Module"
    Public Const XPATH_SEQUENCE As String = "/ControlJob"
    Public Const XPATH_WAFERFLOW As String = "/WaferFlow"
    Public Const XPATH_RECIPE As String = "/Recipe"
    Public Const XPATH_SYSTEM_CONFIG_FOLDER As String = "/SystemConfiguration/SystemConfigFolder"
    Public Const XPATH_AUTO_ARCHIVE_SYSTEM_CONFIG_FILE = "/SystemConfiguration/AutoArchiveSystemConfigFile"
    Public Const XPATH_AUTO_ARCHIVE_DATE_TIME As String = "/SystemConfiguration/AutoArchiveDateTime"
    Public Const XPATH_AUTO_ARCHIVE_STATUS As String = "/SystemConfiguration/AutoArchiveStatus"
    Public Const XPATH_ALLOW_CHECKING_ECC_LIMIT = "/SystemConfiguration/AllowCheckingECCLimit"
    Public Const XPATH_ECC_M_LIMIT = "/SystemConfiguration/ECC_M_Limit"
    Public Const XPATH_MAILINFO As String = "/SystemConfiguration/MailInfo"
    Public Const XPATH_PASSWORD_EXIT_DEVICENET_APP As String = "/SystemConfiguration/PasswordExitDeviceNetApp"
    Public Const XPATH_MODULE_NAME_PM As String = "/SystemConfiguration/Modules/Module[Name='{0}']/GemModuleName"
    Public Const XPATH_MODULE_ROBOT As String = "/SystemConfiguration/Modules/Module[Name='Robot']"
    Public Const XPATH_LLA_FILAMENT As String = "/SystemConfiguration/Modules/Module[Name='LoadLockA']/Filament"
    Public Const XPATH_TM_FILAMENT As String = "/SystemConfiguration/Modules/Module[Name='Robot']/Filament"
    Public Const XPATH_ENABLED_REWORK_FEATURE = "/SystemConfiguration/EnableReworkFeature"
    Public Const XPATH_ENABLE_QUICK_SEQUECE_EDITOR = "/SystemConfiguration/EnableQuickSequenceEditor"
    Public Const XPATH_RESET_ROBOT_INTERLOCK_COMMAND As String = "/SystemConfiguration/Reset_Robot_Interlock_Command"
    Public Const XPATH_SHOW_REWORK_FILES = "/SystemConfiguration/ShowReworkFiles"
    Public Const XPATH_TOTAL_GAS_FLOW_LIMIT = "/SystemConfiguration/TotalGasFlowLimit"
    Public Const XPATH_ENABLE_RUN_NO = "/SystemConfiguration/EnableRunNo"
    Public Const XPATH_TM_TURBO_SP_FREQUENCY = "/SystemConfiguration/TMTurboSetPointFrequency"
    Public Const XPATH_LLA_TURBO_SP_FREQUENCY = "/SystemConfiguration/LLATurboSetPointFrequency"
    Public Const XPATH_ONE_MAIN_CRYO_CONTROLLER_INSTALLED As String = "/SystemConfiguration/OneMainCryoControllerInstalled"

    Public Const XPATH_SUPPORT_ISOVALVE_BETWEEN_TM_AND_PM As String = "/SystemConfiguration/SupportIsolationValveBetweenTMAndPM"
#End Region

#Region "IBE Constants"
    Public Const STR_IBE_DEVICE_STATUS_CLOSED As String = "IBE_DEVICE_STATUS_CLOSED"
    Public Const STR_IBE_DEVICE_STATUS_OPEN As String = "IBE_DEVICE_STATUS_OPEN"
    Public Const INT_ALARM_RANGE_MIN As Integer = 1
    Public Const INT_ALARM_RANGE_MAX As Integer = 305
    Public Const INT_EVENT_RANGE_MIN As Integer = 19901
    Public Const INT_EVENT_RANGE_MAX As Integer = 89912

    Public Const DOUBLE_CG_VACUUM As Double = 0.1
    Public Const DOUBLE_IG_VACUUM As Double = 0.001
    Public Const DOUBLE_CG_ATM As Double = 760
#End Region

#Region "Jobs"
    Public Const PROCESSING_ORDER_LIST As Integer = 0
    Public Const PROCESSING_ORDER_OPTIMIZATION As Integer = 1
    Public Const PJPROCESSING_ORDER As String = "PJprocessing_order"
    Public Const CJPROCESSING_ORDER As String = "CJprocessing_order"

    Public Enum CJ_CMDS
        CJ_CMD_START = 0
        CJ_CMD_STOP = 1
        CJ_CMD_ABORT = 2
        CJ_CMD_PAUSE = 3
        CJ_CMD_RESUME = 4
        CJ_CMD_FORCE_ABORT = 5
    End Enum
    Public Enum PJ_CMDS
        PJ_CMD_START = 0
        PJ_CMD_STOP = 1
        PJ_CMD_ABORT = 2
        PJ_CMD_PAUSE = 3
        PJ_CMD_RESUME = 4
        PJ_CMD_MARK_FOR_RETURN = 5
    End Enum
#End Region

    Public Enum SlotStatuses
        [Empty] = 0
        [Available] = 1
    End Enum

    Public Enum PVDType
        [DCPVD] = 0
        [RFPVD] = 1
        [UNKNOWN] = 2
    End Enum

#Region "STATE MACHINE"
    Public Const STATE_MACHINE_NO_STATE As String = "NoState"
    Public Enum CJSTATE_MACHINES
        NoState = 1
        Queued = 2
        Selected = 3
        WaitingForStart = 4
        Executing = 5
        Paused = 6
        Completed = 7
        WaitForCmdAnswer = 8
        WaitCompleteRpt = 9
    End Enum
    Public Enum PJSTATE_MACHINES
        NoState = 1
        Pooled = 2
        SettingUp = 3
        WaitingForStart = 4
        Processing = 5
        ProcessComplete = 6
        Stopping = 7
        Pausing = 8
        Paused = 9
        Aborting = 10
    End Enum
    Public Enum EQPSTATE_MACHINES
        BLOCKED = 1
        IDLE = 2
        BUSY = 3
    End Enum
    Public Enum STATE_MACHINE_TYPE
        ControlJob = 0
        ProcessJob = 1
        Equipment = 2
    End Enum
#End Region

#Region "Diagnostic"
    Public Const MASTER_FILE As String = "\Master.xml"
#End Region

#Region "PM Status"

    Public Enum EnumChamberState
        UNKNOWN = 0
        IDLE
        RUNNING
        ERRORS
        WAITING_UNLOAD
    End Enum
    Public Enum ProcessModuleProcessingState
        UNKNOWN = 0
        IDLE = 1
        PROCESSING = 2
        PAUSED = 3
    End Enum
#End Region
#Region "Install CX"
    Public Const INSTALL_CX6 As String = "/Servers/Install_CX6"
    Public Const INSTALL_CX7 As String = "/Servers/Install_CX7"
    Public Const INSTALL_CX8 As String = "/Servers/Install_CX8"
#End Region
#Region "Privileges"
    Public Const PERMISSION_001 As String = "001"  '' Maintaince screens : "Cassette & Robot Maintaince" & "PM1..PMx" & "Diagnostic" &  "Aligner Maintaince" & "I/O override"
    Public Const PERMISSION_002 As String = "002" ''  Recipe Editors : "Recipe Editor" & "Wafer flow editor" & "Sequence editor"
    Public Const PERMISSION_003 As String = "003" '' Return & Resume Wafer : "Return" & "Resume" & "Mark for Return"
    Public Const PERMISSION_004 As String = "004"  ''  System Setup
    Public Const PERMISSION_005 As String = "005"  '' User Account Setup
    Public Const PERMISSION_006 As String = "006"  ''Reset Wafers Count
    Public Const PERMISSION_007 As String = "007" ''Time only recipe access
    Public Const PERMISSION_008 As String = "008" ''Exit AVP Software
    Public Const PERMISSION_009 As String = "009"  ''Clear Alarm
    Public Const PERMISSION_013 As String = "013"  ''Make all online and Clear all wafer
    Public Const PERMISSION_014 As String = "014"  ''SecsGem.

    Public Const PERMISSION_010 As String = "010" ''Process Screen
    Public Const PERMISSION_011 As String = "011" ''Wafer Run Dialog
    Public Const PERMISSION_012 As String = "012"  ''Data Log
#End Region

#Region "SECS_GEM_ProcessingState"
    Public Enum WaferProcessingState
        NOT_IN_PROCESSING_SUB_STATE = 1
        NOT_ALIGNED = 2
        ALIGNING = 3
        ALIGNED = 4
        TRANSFERING_BETWEEN_MODULES = 5
        IN_CASSETTE_MODULE = 6
        ARRIVED_IN_PM1 = 7
        ARRIVED_IN_PM2 = 8
        ARRIVED_IN_PM3 = 9
        PROCESSING = 13
        READY_FOR_TRANSFER = 14
    End Enum

    Public Enum SL_WaferProcessingState
        NOT_IN_PROCESSING_SUB_STATE = 1
        IN_LOADER = 2
        ARRIVED_IN_PM = 3
        PROCESSING = 4
        READY_FOR_TRANSFER = 5
    End Enum
#End Region

#Region "GEM Alarm Names"
    Public Shared GemAlarmSeperatorString As String = "$$$"
    'Common
    Public Const GEM_ALARM_SYSTEM As String = "AVPSystemAlarm"

    Public Const GEM_ALARM_SUB_COMMON_ALARM As String = "CommonAlarm" ' LLx, TM, PMx
    Public Const GEM_ALARM_SUB_PUMPDOWN_FAILED As String = "PumpdownFailed" ' LLx, TM
    Public Const GEM_ALARM_SUB_VENT_FAILED As String = "VentFailed" ' LLx, TM
    'LL
    Public Const GEM_ALARM_SUB_LL_ELEVATOR_MAPPING_FAILED As String = "ElevatorMappingFailed"
    Public Const GEM_ALARM_SUB_LL_OPEN_CLOSE_DOOR_FAILED As String = "OpenCloseDoorFailed"
    'TM
    Public Const GEM_ALARM_SUB_TM_ROBOT_PICK_PLACE_FAILED As String = "RobotPickPlaceFailed"

#End Region


#Region "Auto Sequence Name"
    Public Const STR_SEQ_RUNNING_STATUS_PROPERTYNAME As String = "AutoSequenceRunningStatusText"
    Public Const RATE_OF_RISE_SEQ_NAME As String = "Rate Of Rise"
    Public Const AUTO_VENT_SEQ_NAME As String = "Auto Vent"
    Public Const AUTO_PUMPDOWN_SEQ_NAME As String = "Auto Pumpdown"
    Public Const IG_DEGAS_SEQ_NAME As String = "IG Degas"
    Public Const PUMPDOWN_CURVE_SEQ_NAME As String = "Pumpdown Curve"
    Public Const RECOVER_PRESSURE_SEQ_NAME As String = "Recover Pressure"
    Public Const RECIPE_PROCESS_SEQ_NAME As String = "Recipe Process"
    Public Const PUMP_PURGE_SEQ_NAME As String = "Pump Purge"
    Public Const SHUTDOWN_POWER_SEQ_NAME As String = "Shutdown Power"
#End Region

    'LLElevatorConfig
#Region "System Restore"
    Public Const MaxLLELEVATOR_CONFIG As Integer = 5
    Public Const MaxLLELEVATOR_VC_CONFIG As Integer = 5
    Public Const MaxLLVENT_CONFIG As Integer = 13
    Public Const MaxLLPUMPDOWN_CONFIG As Integer = 17
    Public Const MaxTMVENT_CONFIG As Integer = 7
    Public Const MaxCG_CONFIG As Integer = 5
    Public Const MaxTMPUMPDOWN_CONFIG As Integer = 9
    Public Const MaxTRANSFERSETPOINT_CONFIG As Integer = 10

    Public Const MaxVENT_PUMPDOWN_CONFIG As Integer = 4
    Public Const MaxELEVATOR_CONFIG = 2
    Public Const MaxELEVATOR_VC_CONFIG = 3

    Public Const SCFNS_VALUE As String = "SCFNS_Command"
    Public Const SCFPT_VALUE As String = "SCFPT_Command"
    Public Const SCFCT_VALUE As String = "SCFCT_Command"
    Public Const SCFLM_VALUE As String = "SCFLM_Command"
    Public Const SFB_VALUE As String = "SFB_Command"

    Public Const ROR_LITTER As String = "ROR_Litter"
    Public Const IonGaugeFirmwareModel = "IonGaugeFirmwareModel"
    Public Const IonGaugeEmissionCurrent = "IonGaugeEmissionCurrent"
    Public Const IonGaugeType = "IonGaugeType"
    Public Const Filament = "Filament"
    Public Const TARGET_KWH_WARNING_LIMIT As String = "TargetKWHWarningLimit"
    Public Const TARGET_KWH_ALARM_LIMIT As String = "TargetKWHAlarmLimit"
    Public Const TARGET_MATERIAL As String = "Target_Material"
    Public Const SOURCE_USAGE As String = "SourceUsage"
    Public Const SOURCE_USAGE_WARNING As String = "SourceUsageWarning"
    Public Const SOURCE_USAGE_LIMIT As String = "SourceUsageLimit"

    Public Const LLMESAVALVEOPENCLOSETIMEOUT As String = "LLMesaValveOpenCloseTimeOut"
    Public Const IGONOFFTIMEOUT As String = "IGOnOffTimeOut"
    Public Const LLHIVACOPENCLOSETIMEOUT As String = "LLHivacOpenCloseTimeOut"
    Public Const LLASLOWVENTTIMEOUT As String = "LLASlowVentTimeOut"
    Public Const LLASLOWVENTPRESSURE As String = "LLASlowVentPressure"
    Public Const LLAFASTVENTTIMEOUT As String = "LLAFastVentTimeOut"
    Public Const LLAVENTPRESSURE As String = "LLAVentPressure"
    Public Const LLVENTVALVEOPENCLOSETIMEOUT As String = "LLVentValveOpenCloseTimeOut"
    Public Const LLVENT_DELAY_TIME As String = "LLVent_Delay_Time"

    Public Const TMMECHANICALPUMPONPRESSURE As String = "TMMechanicalPumpOnPressure"
    Public Const LLASLOWROUGHPRESSURE As String = "LLASlowRoughPressure"
    Public Const LLASLOWROUGHPRESSURETIMEOUT As String = "LLASlowRoughPressureTimeOut"
    Public Const LLAFASTROUGHPRESSURE As String = "LLAFastRoughPressure"
    Public Const LLAFASTROUGHPRESSURETIMEOUT As String = "LLAFastRoughPressureTimeOut"
    Public Const LLACRYOCOLDTEMP As String = "LLACryoColdTemp"
    Public Const IGONDELAY As String = "IGOnDelay"
    Public Const LLROUGHVALVEOPENCLOSETIMEOUT As String = "LLRoughValveOpenCloseTimeOut"
    Public Const LLPUMPDOWN_DELAY_TIME As String = "LLPumpDown_Delay_Time"

    Public Const TMMESAVALVESOPENCLOSETIMEOUT As String = "TMMesaValvesOpenCloseTimeOut"
    Public Const IGONOFFWAITTIME As String = "IGOnOffWaitTime"
    Public Const TMHIVACOPENCLOSETIMEOUT As String = "TMHivacOpenCloseTimeOut"
    Public Const TMVENTPRESSURE As String = "TMVentPressure"
    Public Const TMVENTTIMEOUT As String = "TMVentTimeOut"
    Public Const TMVENTVALVEOPENCLOSETIMEOUT As String = "TMVentValveOpenCloseTimeOut"
    Public Const TMVENT_DELAY_TIME As String = "TMVent_Delay_Time"

    Public Const TMROUGHPRESSURE As String = "TMRoughPressure"
    Public Const TMROUGHTIMEOUT As String = "TMRoughTimeOut"
    Public Const TMCRYOCOLDTEMP As String = "TMCryoColdTemp"
    Public Const TMPUMDOWN_DELAY_TIME As String = "TMPumdown_Delay_Time"


    Public Const CASSETTESMODULETRANSFERSETPOINT As String = "CassettesModuleTransferSetPoint"
    Public Const CassettesModule_STR As String = "CassettesModule"
    Public Const LOADLOCKATRANSFERSETPOINT As String = "LoadLockATransferSetPoint"
    Public Const CHAMBER1TRANSFERSETPOINT As String = "Chamber1TransferSetPoint"
    Public Const CHAMBER2TRANSFERSETPOINT As String = "Chamber2TransferSetPoint"
    Public Const CHAMBER3TRANSFERSETPOINT As String = "Chamber3TransferSetPoint"
    Public Const PRESSUREDIFFERENTIALPERCENT As String = "PressureDifferentialPercent"

    'robot config
    Public Const STR_SPACE As String = " "
    Public Const R_STN1 As String = "R_STN1"
    Public Const T_STN1 As String = "T_STN1"
    Public Const Z_STN1 As String = "Z_STN1"
    Public Const LOWER_STN1 As String = "LOWER_STN1"
    Public Const PITCH_STN1 As String = "PITCH_STN1"

    Public Const R_STN2 As String = "R_STN2"
    Public Const T_STN2 As String = "T_STN2"
    Public Const Z_STN2 As String = "Z_STN2"
    Public Const LOWER_STN2 As String = "LOWER_STN2"
    Public Const PITCH_STN2 As String = "PITCH_STN2"

    Public Const R_STN3 As String = "R_STN3"
    Public Const T_STN3 As String = "T_STN3"
    Public Const Z_STN3 As String = "Z_STN3"
    Public Const LOWER_STN3 As String = "LOWER_STN3"
    Public Const PITCH_STN3 As String = "PITCH_STN3"

    Public Const R_STN4 As String = "R_STN4"
    Public Const T_STN4 As String = "T_STN4"
    Public Const Z_STN4 As String = "Z_STN4"
    Public Const LOWER_STN4 As String = "LOWER_STN4"
    Public Const PITCH_STN4 As String = "PITCH_STN4"

    Public Const R_STN5 As String = "R_STN5"
    Public Const T_STN5 As String = "T_STN5"
    Public Const Z_STN5 As String = "Z_STN5"
    Public Const LOWER_STN5 As String = "LOWER_STN5"
    Public Const PITCH_STN5 As String = "PITCH_STN5"

    Public Const R_STN6 As String = "R_STN6"
    Public Const T_STN6 As String = "T_STN6"
    Public Const Z_STN6 As String = "Z_STN6"
    Public Const LOWER_STN6 As String = "LOWER_STN6"
    Public Const PITCH_STN6 As String = "PITCH_STN6"

    Public Const R_STN7 As String = "R_STN7"
    Public Const T_STN7 As String = "T_STN7"
    Public Const Z_STN7 As String = "Z_STN7"
    Public Const LOWER_STN7 As String = "LOWER_STN7"
    Public Const PITCH_STN7 As String = "PITCH_STN7"

    Public Const R_STN8 As String = "R_STN8"
    Public Const T_STN8 As String = "T_STN8"
    Public Const Z_STN8 As String = "Z_STN8"
    Public Const LOWER_STN8 As String = "LOWER_STN8"
    Public Const PITCH_STN8 As String = "PITCH_STN8"

    Public Const R_STN9 As String = "R_STN9"
    Public Const T_STN9 As String = "T_STN9"
    Public Const Z_STN9 As String = "Z_STN9"
    Public Const LOWER_STN9 As String = "LOWER_STN9"
    Public Const PITCH_STN9 As String = "PITCH_STN9"

    Public Const R_STN10 As String = "R_STN10"
    Public Const T_STN10 As String = "T_STN10"
    Public Const Z_STN10 As String = "Z_STN10"
    Public Const LOWER_STN10 As String = "LOWER_STN10"
    Public Const PITCH_STN10 As String = "PITCH_STN10"

    Public Const HaveConfigHACC As String = "HaveConfigHACC"
    Public Const R_HACC As String = "R_HACC"
    Public Const T_HACC As String = "T_HACC"
    Public Const Z_HACC As String = "Z_HACC"
    Public Const STR_HACC As String = "HACC"

    Public Const HaveConfigPACC As String = "HaveConfigPACC"
    Public Const R_PACC As String = "R_PACC"
    Public Const T_PACC As String = "T_PACC"
    Public Const Z_PACC As String = "Z_PACC"
    Public Const STR_PACC As String = "PACC"

    Public Const HaveConfigWACC As String = "HaveConfigWACC"
    Public Const R_WACC As String = "R_WACC"
    Public Const T_WACC As String = "T_WACC"
    Public Const Z_WACC As String = "Z_WACC"
    Public Const STR_WACC As String = "WACC"

    Public Const HaveConfigHVEL As String = "HaveConfigHVEL"
    Public Const R_HVEL As String = "R_HVEL"
    Public Const T_HVEL As String = "T_HVEL"
    Public Const Z_HVEL As String = "Z_HVEL"
    Public Const STR_HVEL As String = "HVEL"

    Public Const HaveConfigPVEL As String = "HaveConfigPVEL"
    Public Const R_PVEL As String = "R_PVEL"
    Public Const T_PVEL As String = "T_PVEL"
    Public Const Z_PVEL As String = "Z_PVEL"
    Public Const STR_PVEL As String = "PVEL"

    Public Const HaveConfigWVEL As String = "HaveConfigWVEL"
    Public Const R_WVEL As String = "R_WVEL"
    Public Const T_WVEL As String = "T_WVEL"
    Public Const Z_WVEL As String = "Z_WVEL"
    Public Const STR_WVEL As String = "WVEL"
    Public Const STORE_STN_X_ALL As String = "STORE {0} ALL"

    Public Const STR_Edit As String = "Edit"
    Public Const STR_Apply As String = "Apply"

    Public Const LLELEVATORCONFIG_NumberOfSlot As Integer = 12
    Public Const LLELEVATORCONFIG_TravelLength As Integer = 9150
    Public Const LLELEVATORCONFIG_Pitch As Integer = 3850
    Public Const LLELEVATORCONFIG_BaseOffset As Integer = 9000
    Public Const LLELEVATORCONFIG_FindBias As Integer = 11151

    Public Const LLELEVATORVC_SCFNS_Value As Integer = 12
    Public Const LLELEVATORVC_SCFPT_Value As Integer = 3740
    Public Const LLELEVATORVC_SCFCT_Value As Integer = 9000
    Public Const LLELEVATORVC_SCFLM_Value As Integer = 9000
    Public Const LLELEVATORVC_SFB_Value As Integer = 11000

    Public Const PMPARAM_ROR_Litter As Integer = 0
    Public Const PMPARAM_TargetKWHWarningLimit As Integer = 10
    Public Const PMPARAM_TargetKWHAlarmLimit As Integer = 20
    Public Const PMPARAM_Target_Material As Integer = 0
    Public Const PMPARAM_SourceUsage As Integer = 0
    Public Const PMPARAM_SourceUsageWarning As Integer = 200

    Public Const LLVENTCONFIG_LLMesaValveOpenCloseTimeOut As Integer = 10000
    Public Const LLVENTCONFIG_IGOnOffTimeOut As Integer = 30000
    Public Const LLVENTCONFIG_LLHivacOpenCloseTimeOut As Integer = 10000
    Public Const LLVENTCONFIG_LLASlowVentTimeOut As Integer = 180000
    Public Const LLVENTCONFIG_LLASlowVentPressure As Integer = 150
    Public Const LLVENTCONFIG_LLAFastVentTimeOut As Integer = 300000
    Public Const LLVENTCONFIG_LLAVentPressure As Integer = 760
    Public Const LLVENTCONFIG_LLVentValveOpenCloseTimeOut As Integer = 2000
    Public Const LLVENTCONFIG_LLVent_Delay_Time As Integer = 10000

    Public Const LLPUMPDOWNCONFIG_LLMesaValveOpenCloseTimeOut As Integer = 10000
    Public Const LLPUMPDOWNCONFIG_IGOnOffTimeOut As Integer = 30000
    Public Const LLPUMPDOWNCONFIG_LLHivacOpenCloseTimeOut As Integer = 10000
    Public Const LLPUMPDOWNCONFIG_TMMechanicalPumpOnPressure As Double = 0.1
    Public Const LLPUMPDOWNCONFIG_LLASlowRoughPressure As Integer = 500
    Public Const LLPUMPDOWNCONFIG_LLASlowRoughPressureTimeOut As Integer = 600000
    Public Const LLPUMPDOWNCONFIG_LLAFastRoughPressure As Double = 0.08
    Public Const LLPUMPDOWNCONFIG_LLAFastRoughPressureTimeOut As Integer = 1500000
    Public Const LLPUMPDOWNCONFIG_LLACryoColdTemp As Integer = 20
    Public Const LLPUMPDOWNCONFIG_IGOnDelay As Integer = 10000
    Public Const LLPUMPDOWNCONFIG_LLRoughValveOpenCloseTimeOut As Integer = 2000
    Public Const LLPUMPDOWNCONFIG_LLPumpDown_Delay_Time As Integer = 10000

    Public Const TMVENTCONFIG_TMMesaValvesOpenCloseTimeOut As Integer = 5000
    Public Const TMVENTCONFIG_IGOnOffWaitTime As Integer = 30000
    Public Const TMVENTCONFIG_TMHivacOpenCloseTimeOut As Integer = 10000
    Public Const TMVENTCONFIG_TMVentPressure As Integer = 760
    Public Const TMVENTCONFIG_TMVentTimeOut As Integer = 300000
    Public Const TMVENTCONFIG_TMVentValveOpenCloseTimeOut As Integer = 2000
    Public Const TMVENTCONFIG_TMVent_Delay_Time As Integer = 10000

    Public Const TMPUMPDOWNCONFIG_TMMesaValvesOpenCloseTimeOut As Integer = 5000
    Public Const TMPUMPDOWNCONFIG_IGOnOffTimeOut As Integer = 30000
    Public Const TMPUMPDOWNCONFIG_TMHivacOpenCloseTimeOut As Integer = 30000
    Public Const TMPUMPDOWNCONFIG_TMMechanicalPumpOnPressure As Double = 0.1
    Public Const TMPUMPDOWNCONFIG_TMRoughPressure As Double = 0.08
    Public Const TMPUMPDOWNCONFIG_TMRoughTimeOut As Integer = 300000
    Public Const TMPUMPDOWNCONFIG_TMCryoColdTemp As Integer = 20
    Public Const TMPUMPDOWNCONFIG_IGOnDelay As Integer = 10000
    Public Const TMPUMPDOWNCONFIG_TMPumdown_Delay_Time As Integer = 10000

    Public Const TRANSFERSETPOINT_CassettesModuleTransferSetPoint As Double = 0.000005
    Public Const TRANSFERSETPOINT_LoadLockATransferSetPoint As Double = 0.001
    Public Const TRANSFERSETPOINT_ChamberTransferSetPoint As Double = 760
    Public Const TRANSFERSETPOINT_PressureDifferentialPercent As Double = 0.1
#End Region

#Region "PM config Tag"
    Public Const STR_MAX_SP_TAG As String = "MaxSP"
    Public Const STR_RANGEVALUE_TAG As String = "RangeValue"
#End Region

#Region "Remote commands result"
    Public Enum CustomRemoteCommandResult
        '1-6: CIM constant
        SEQUENCE_IS_NOT_EXISTED = 19
        WF_IS_NOT_EXISTED = 8
        RECIPE_IS_NOT_EXISTED = 9
        SEQUENCE_FILE_IS_CORRUPTED = 10
        LL_TM_IS_NOT_ONLINE = 11
        PM_IS_NOT_ONLINE = 12
        LOTID_IS_EMPTY = 13
        SEQUENCE_IS_EMPTY = 14
        HAS_WAFER_IN_PM = 15
        SOURCE_USAGE_KWH_REACH_LIMIT = 16
        ALL_WAFER_PROCESSING_ARE_STOPPED = 17
        ALL_WAFER_PROCESSING_ARE_ABORTED = 18
        SOURCE_USAGE_KWH_REACH_WARNING_LIMIT = 20
        SHIELDS_QUARTZ_REACH_LIMIT = 21
        SHIELDS_QUARTZ_REACH_WARNING_LIMIT = 22
    End Enum

    Public Enum CustomUploadDownloadResult
        '1-5: CIM constant
        INVALID_STRUCTURE_DATA = 7
        OTHER_ERROR = 8
    End Enum
#End Region

#Region "CRYO POLLING TIMEOUT"
    Public Const CRYO_POLLING_INTERVAL As Int32 = 1000
    Public Const CRYO_TRANSACTION_TIMEOUT_LIMIT As Int32 = 20
    Public Const CRYO_POLLING_SLEEP_TIME As Int32 = 300
#End Region

#Region "CycelATM"
    Public Const SEQUENCE_CYCLEATM As String = "Sequence_CycleATM"
    Public Const WAFER_CYCLEATM As String = "WaferFlow_CycleATM"
    Public Const IBE_CYCLEATM As String = "IBE_CycleATM"
    Public Const PVD_CYLEATM As String = "PVD_CycleATM"
    Public Const PVD4_CYLEATM As String = "PVD4_CycleATM"
    Public Const IBD_CYCLEATM As String = "IBD_CycleATM"
    Public Const HRPVD_CYLCEATM As String = "HRPVD_CycleATM"
    Public Const PVD2R4_CYCLEATM As String = "PVD2R4_CycleATM"
    Public Const PVD6P_CYCLEATM As String = "PVD6P_CycleATM"
    Public Const PVD6S_CYCLEATM As String = "PVD6S_CycleATM"
    Public Const PVDA_CYCLEATM As String = "PVDA_CycleATM"
    Public Const RIE_CYCLEATM As String = "RIE_CycleATM"
    Public Const STR_ALGINER As String = "Aligner"
    Public Const STR_NO_SELECT_ALIGNER As String = "No select aligner"
    Public Const STR_NO_SELECT_LOADLOCK As String = "No select Loadlock"
    Public Const STR_NO_WAFER As String = "Have no wafer in Loadlock"
    Public Const STR_CYCELATM_RECEPE_FILE_PATH = "DataFiles\RecieCycleATM"
    Public Const STR_PM As String = "PM"
    Public Const STR_PVD As String = "PVD"
    Public Const STR_PVD4 As String = "PVD4"
    Public Const ENABLE_CYCLEATM As String = "/SystemConfiguration/EnableCycleATM"
#End Region

#Region "TabIO"
    Public Const STR_TRANSFER_MODULE = "TransferModule"

    'format CG vakue tabIO
    Public Const STR_CassettesModule_IonGauge As String = "TransferModule.Ion"
    Public Const STR_CassettesModule_CG As String = "TransferModule.CG"
    Public Const STR_CassettesModule_TurboForelineCG As String = "TransferModule.TurboForelineCG"
    Public Const STR_Alarm_AlarmStatus As String = "Alarm.AlarmStatus"
#End Region

#Region "Other"
    Public Const ERROR_TEXT As String = "Error"
#End Region

#Region "process mode time"
    Public Const PROCESS_MODE_TIME As String = "Time"
    Public Const PROCESS_MODE_REVOLUTION As String = "Revolution"
    Public Const PROCESS_MODE_STATIC As String = "Static"
    Public Const PROCESS_MODE_THICHNESS As String = "Thickness"
#End Region
End Class
