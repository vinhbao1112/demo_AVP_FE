Imports AVPLib.Communication.TerminalDriver
Imports System.Text.RegularExpressions
Imports AVPLib.ConstEnum
Imports AVPSecsGemLib
Namespace Business

    Public Enum PVDCommands
        REQUEST_ALL_DATA
        SHIELD_KWH_PROGRAM
        ''DC TARGET POWER SUPPLY
        DC_TARGET_POWER_READBACK '=0
        DC_TARGET_POWER_PROGRAM
        DC_TARGET_VOLTAGE_READBACK
        DC_TARGET_VOLTAGE_PROGRAM
        DC_TARGET_CURRENT_READBACK
        DC_TARGET_CURRENT_PROGRAM
        DC_TARGET_RAMPTIME_PROGRAM
        DC_TARGET_MAGNATRON_ROTATION_STATUS
        DC_TARGET_DCPULSE_READBACK
        DC_TARGET_DCPULSE_PROGRAM
        RESET_DC_TARGET_KWH
        DC_TARGET_COMMUNICATION_STATUS
        ''RF TARGET POWER SUPPLY
        RF_TARGET_FORWARD_POWER_READBACK
        RF_TARGET_FORWARD_POWER_PROGRAM
        RF_TARGET_REFLECTED_POWER_READBACK
        RF_TARGET_VOLTAGE_READBACK
        RF_TARGET_C1_READBACK
        RF_TARGET_C1_PROGRAM
        RF_TARGET_C2_READBACK
        RF_TARGET_C2_PROGRAM
        RF_TARGET_MATCH_READBACK
        RF_TARGET_AUTO
        RF_TARGET_PRESETS_READBACK
        RF_TARGET_PRESETS_PROGRAM
        RF_TARGET_RECALL
        RF_TARGET_STORE
        RESET_RF_TARGET_KWH
        RF_TARGET_COMMUNICATION_STATUS
        ''BIAS POWER SUPPLY
        BIAS_FORWARD_POWER_PROGRAM
        BIAS_FORWARD_POWER_READBACK
        BIAS_REFLECTED_POWER_READBACK
        BIAS_VOLTAGE_POWER_READBACK
        BIAS_VOLTAGE_POWER_PROGRAM
        BIAS_C1_READBACK
        BIAS_C1_PROGRAM
        BIAS_C2_READBACK
        BIAS_C2_PROGRAM
        BIAS_MATCH_READBACK
        BIAS_AUTO
        BIAS_PRESETS_READBACK
        BIAS_PRESETS_PROGRAM
        BIAS_RECALL
        BIAS_STORE
        BIAS_COMMUNICATION_STATUS
        BIAS_POWER_KWH_READBACK
        BIAS_POWER_KWH_PROGRAM
        ''PARALLEL MAGNET
        PARALLEL_CURRENT_READBACK
        PARALLEL_CURRENT_PROGRAM
        PARALLEL_DUTY_PROGRAM
        PARALLEL_FREQUENCY_PROGRAM
        PARALLEL_VOLTAGE_READBACK
        PARALLEL_STATUS_READBACK
        ''CHAMBER INTERLOCK
        CHAMBERINTERLOCK_CHAMBERPRESSURE_STATUS
        CHAMBERINTERLOCK_CHAMBERWATER_STATUS
        CHAMBERINTERLOCK_CHUCKWATER_STATUS
        CHAMBERINTERLOCK_LIDWATER_STATUS
        CHAMBERINTERLOCK_PSWATER_STATUS
        CHAMBERINTERLOCK_PSRELAY_STATUS
        ''VAT VALVE CONTROLLER
        VAT_VALVE_CONTROLLER_TEACH
        VAT_VALVE_CONTROLLER_PRESSURE
        VAT_VALVE_CONTROLLER_PRESSURE_PERCENT
        VAT_VALVE_COMMUNICATION_STATUS
        VAT_VALVE_CONTROLLER_SIZEADJUST
        ''MAGNATRON
        MAGNATRON_ROTATING_STATUS
        MAGNATRON_ROTATION_START
        ''PROCESS MONITOR
        PROCESS_RECIPE
        PROCESS_WAFER_ID
        PROCESS_PROCESS_TIME
        PROCESS_PROCESS_STEP
        PROCESS_STEP_TIME
        PROCESS_USERLEVEL
        PROCESS_STATUS
        ''CHUCK POS
        CHUCK_POS_READBACK
        CHUCK_POS_PROGRAM
        CLAMP_STATUS_PROGRAM
        CLAMP_STATUS_READBACK
        ''OVERRIDEMODE_STATUS
        OVERRIDEMODE_STATUS
        TARGET_KWH_WARNING_LIMIT
        TARGET_KWH_ALARM_LIMIT
        MAX_USAGE_KWH
        ''CRYO
        CRYO_T1_READBACK
        CRYO_T2_READBACK
        CRYO_REGEN_HOUR_READBACK
        CRYO_LIFETIME_HOUR_READBACK
        CRYO_COMMUNICATION_STATUS
        CRYO_REGEN
        CRYO_P_COMMANDS
        CRYO_P_COMMAND_READBACK
        ''WATER PUMP
        WATER_PUMP_T_READBACK
        WATER_PUMP_STATUS
        ''TURBO PUMP
        TURBO_PUMP_STATUS
        ''IG
        IG_READBACK
        ''CG
        CG_READBACK
        ''Valve
        AUTO_ZERO_VAT_VALVE_STATUS
        HIVAC_VALVE_STATUS
        BARATRON_VALVE_STATUS
        ROUGH_VALVE_STATUS
        WATER_VALVE_STATUS
        VENT_VALVE_STATUS
        TURBO_ISOLATION_VALVE_STATUS
        PLASMA_IGNITER_VALVE_STATUS
        MAIN_GAS_VALVE_STATUS
        SHUTTER_VALVE_STATUS
        SHUTOFF1_VALVE_STATUS
        SHUTOFF2_VALVE_STATUS
        SHUTOFF3_VALVE_STATUS
        SHUTOFF4_VALVE_STATUS
        SHUTOFF5_VALVE_STATUS
        SUPPLY5_VALVE_STATUS
        SUPPLY4_VALVE_STATUS
        SUPPLY3_VALVE_STATUS
        SUPPLY2_VALVE_STATUS
        SUPPLY1_VALVE_STATUS
        ''Gas Controller
        GASCONTROLLER_GAS1_PROGRAM
        GASCONTROLLER_GAS2_PROGRAM
        GASCONTROLLER_GAS3_PROGRAM
        GASCONTROLLER_GAS4_PROGRAM
        GASCONTROLLER_GAS5_PROGRAM
        ''BA Control
        BARATRON_IG_STATUS
        BARATRON_IG_READBACK
        BARATRON_BA_READBACK
        BARATRON_CG_READBACK
        BARATRON_CG_PROGRAM
        ''Process Recipe
        PROCESS_CONTROL_DEVICE_START
        PROCESS_CONTROL_DEVICE_STOP
        PROCESS_CONTROL_DEVICE_PAUSE
        PROCESS_CONTROL_DEVICE_CONTINUE
        PROCESS_CONTROL_DEVICE_ABORT
        PROCESS_CONTROL_DEVICE_RESET_ERROR
        PROCESS_CONTROL_SEND_RECIPE_NAME
        PROCESS_CONTROL_SEND_RUN_DATA_FILE_NAME
        PROCESS_CONTROL_DEVICE_ERROR
        CURRENT_AVP_TIME
        ''menu
        MACHINE_PUMPDOWN
        MACHINE_ABORT_PUMPDOWN
        MACHINE_VENT
        MACHINE_IGDEGAS
        MACHINE_PUMPPURGE
        MACHINE_PUMPPURGE_CURRENT_CYCLE
        MACHINE_ABORT_VENT
        MACHINE_CRYO_ON
        MACHINE_CRYO_OFF
        MACHINE_CRYO_REGEN
        MACHINE_FAST_REGEN
        MACHINE_ABORT_CRYO_REGEN
        WATER_PUMP_REGEN_STATUS
        WATER_PUMP_STATE_STATUS
        WATER_PUMP_REGEN_HOUR_READBACK
        WATER_PUMP_REGEN_LIFETIME_READBACK
        MACHINE_SHUTDOWN_POWER
        ''
        WAFER_STATUS
        '''
        ALARM_STATUS_READBACK
        EVENT_STATUS_READBACK
        ''
        ROUGH_LINE_IN_USE_QUERY
        TM_ROUGH_LINE_CONVECTRON_GAUGE
        SPLITVALVE_STATUS
        ''
        RATE_OF_RISE_STATUS
        RATE_OF_RISE_SAMPLE
        RATE_OF_RISE_FILENAME
        RATE_OF_RISE_INTERVAL_RECORDING
        ''
        PUMPDOWN_CURVE_STATUS
        PUMPDOWN_CURVE_SAMPLE
        PUMPDOWN_CURVE_FILENAME
        PUMPDOWN_CURVE_INTERVAL_RECORDING
        ''
        KEEP_ALIVE
        ''CG control
        FORELINE_CG_ATM
        FORELINE_CG_VAC
        ROUGHLINE_CG_ATM
        ROUGHLINE_CG_VAC
        PRESSURE_CG_ATM
        PRESSURE_CG_VAC


        COPYRECIPE_TO_PMFOLDER
        PROCESS_CYCLEATM_START

        CLEAR_ALL_ALARM_PROGRAM
    End Enum

    Public Class PVDUtility
#Region "Public methods"
        Public Shared Function SetOverrideMode(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter SetOverrideMode")
            AVPLib.Log.coreLogger.Info("Leave SetOverrideMode")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.OVERRIDEMODE_STATUS.ToString(), data)
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-04-21</date>
        ''' </author>
        Public Shared Function SetWaferStatusToPVD(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Set_Wafer_Status_To_PVD")
            Select Case data
                Case ConstEnum.enumWaferStatus.eWaferNew
                    data = ConfigurationValues.DEVICE_STATUS_OPEN   '01'
                Case ConstEnum.enumWaferStatus.eWaferExposed
                    data = ConfigurationValues.DEVICE_STATUS_STOPPED   '02'
                Case ConstEnum.enumWaferStatus.eWaferComplete
                    data = ConfigurationValues.DEVICE_STATUS_ABORT      '03'
                Case ConstEnum.enumWaferStatus.eWaferError
                    data = ConfigurationValues.DEVICE_STATUS_OTHER    '04'
            End Select
            AVPLib.Log.coreLogger.Info("Leave Set_Wafer_Status_To_PVD")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.WAFER_STATUS.ToString(), data)

        End Function

#Region "DC TARGET POWER SUPPLY"
        ''DC_RampTime_PROGRAM
        Public Shared Function DC_RampTime_Program(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter DC_RampTime_Program")
            AVPLib.Log.coreLogger.Info("Leave DC_RampTime_Program")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.DC_TARGET_RAMPTIME_PROGRAM.ToString(), data)
        End Function
        ''DC_TARGET_POWER_PROGRAM
        Public Shared Function DC_Target_Power_Program(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter DC_Target_Power_Program")
            AVPLib.Log.coreLogger.Info("Leave DC_Target_Power_Program")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.DC_TARGET_POWER_PROGRAM.ToString(), data)
        End Function
        ''DC_TARGET_VOLTAGE_PROGRAM
        Public Shared Function DC_Target_Voltage_Program(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter DC_Target_Voltage_Program")
            AVPLib.Log.coreLogger.Info("Leave DC_Target_Voltage_Program")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.DC_TARGET_VOLTAGE_PROGRAM.ToString(), data)
        End Function
        ''DC_TARGET_CURRENT_PROGRAM
        Public Shared Function DC_Target_Current_Program(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter DC_Target_Current_Program")
            AVPLib.Log.coreLogger.Info("Leave DC_Target_Current_Program")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.DC_TARGET_CURRENT_PROGRAM.ToString(), data)
        End Function
        ''DC_TARGET_MAGNATRON_ROTATION_STATUS
        Public Shared Function DC_TARGET_Magnatron_Rotation_Status(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter DC_TARGET_Magnatron_Rotation_Status")
            AVPLib.Log.coreLogger.Info("Leave DC_TARGET_Magnatron_Rotation_Status")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.DC_TARGET_MAGNATRON_ROTATION_STATUS.ToString(), data)
        End Function
        ''DC_TARGET_DCPULSE_STATUS
        Public Shared Function DC_Target_DCPulse_Program(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter DC_Target_DCPulse_Status")
            AVPLib.Log.coreLogger.Info("Leave DC_Target_DCPulse_Status")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.DC_TARGET_DCPULSE_PROGRAM.ToString(), data)
        End Function
        ''DC_TARGET_COMMUNICATION_STATUS
        Public Shared Function DC_Target_Communication_Status(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter DC_Target_Communication_Status")
            AVPLib.Log.coreLogger.Info("Leave DC_Target_Communication_Status")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.DC_TARGET_COMMUNICATION_STATUS.ToString(), data)
        End Function
#End Region

#Region "RF TARGET POWER SUPPLY"
        '       RF_TARGET_FORWARD_POWER_PROGRAM
        Public Shared Function RF_Target_Forward_Power_Program(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter RF_Target_Forward_Power_Program")
            AVPLib.Log.coreLogger.Info("Leave RF_Target_Forward_Power_Program")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.RF_TARGET_FORWARD_POWER_PROGRAM.ToString(), data)
        End Function
        '       RF_TARGET_C1_PROGRAM
        Public Shared Function RF_Target_C1_Program(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter RF_Target_C1_Program")
            AVPLib.Log.coreLogger.Info("Leave RF_Target_C1_Program")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.RF_TARGET_C1_PROGRAM.ToString(), data)
        End Function
        '       RF_TARGET_C2_PROGRAM
        Public Shared Function RF_Target_C2_Program(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter RF_Target_C2_Program")
            AVPLib.Log.coreLogger.Info("Leave RF_Target_C2_Program")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.RF_TARGET_C2_PROGRAM.ToString(), data)
        End Function
        '       RF_TARGET_AUTO
        Public Shared Function RF_Target_Auto(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter RF_Target_Auto")
            AVPLib.Log.coreLogger.Info("Leave RF_Target_Auto")
            Select Case data
                Case STR_ON
                    Return SendCommandWithDataToPVD(chamberName, PVDCommands.RF_TARGET_AUTO.ToString(), ConfigurationValues.DEVICE_STATUS_OPEN)
                Case STR_OFF
                    Return SendCommandWithDataToPVD(chamberName, PVDCommands.RF_TARGET_AUTO.ToString(), ConfigurationValues.DEVICE_STATUS_CLOSED)
            End Select
        End Function
        '       RF_TARGET_PRESETS_PROGRAM
        Public Shared Function RF_Target_Presets_Program(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter RF_Target_Presets_Program")
            AVPLib.Log.coreLogger.Info("Leave RF_Target_Presets_Program")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.RF_TARGET_PRESETS_PROGRAM.ToString(), data)
        End Function
        '       RF_TARGET_RECALL
        Public Shared Function RF_Target_Recall(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter RF_Target_Recall")
            AVPLib.Log.coreLogger.Info("Leave RF_Target_Recall")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.RF_TARGET_RECALL.ToString(), data)
        End Function
        '       RF_TARGET_STORE
        Public Shared Function RF_Target_Store(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter RF_Target_Store")
            AVPLib.Log.coreLogger.Info("Leave RF_Target_Store")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.RF_TARGET_STORE.ToString(), data)
        End Function
        '       RF_TARGET_COMMUNICATION_STATUS
        Public Shared Function RF_Target_Communication_Status(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter RF_Target_Communication_Status")
            AVPLib.Log.coreLogger.Info("Leave RF_Target_Communication_Status")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.RF_TARGET_COMMUNICATION_STATUS.ToString(), data)
        End Function
#End Region

#Region "BIAS TARGET POWER SUPPLY"

        Public Shared Function Bias_Voltage_Program(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Bias_Voltage_Program")
            AVPLib.Log.coreLogger.Info("Leave Bias_Voltage_Program")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.BIAS_VOLTAGE_POWER_PROGRAM.ToString(), data)
        End Function
        '       BIAS_FORWARD_POWER_PROGRAM
        Public Shared Function Bias_Target_Forward_Power_Program(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Bias_Target_Forward_Power_Program")
            AVPLib.Log.coreLogger.Info("Leave Bias_Target_Forward_Power_Program")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.BIAS_FORWARD_POWER_PROGRAM.ToString(), data)
        End Function
        '       BIAS_C1_PROGRAM
        Public Shared Function Bias_Target_C1_Program(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Bias_Target_C1_Program")
            AVPLib.Log.coreLogger.Info("Leave Bias_Target_C1_Program")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.BIAS_C1_PROGRAM.ToString(), data)
        End Function
        '       BIAS_C2_PROGRAM
        Public Shared Function Bias_Target_C2_Program(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Bias_Target_C2_Program")
            AVPLib.Log.coreLogger.Info("Leave Bias_Target_C2_Program")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.BIAS_C2_PROGRAM.ToString(), data)
        End Function
        '       BIAS_AUTO
        Public Shared Function Bias_Target_Auto(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Bias_Target_Auto")
            AVPLib.Log.coreLogger.Info("Leave Bias_Target_Auto")
            Select Case data
                Case STR_ON
                    Return SendCommandWithDataToPVD(chamberName, PVDCommands.BIAS_AUTO.ToString(), ConfigurationValues.DEVICE_STATUS_OPEN)
                Case STR_OFF
                    Return SendCommandWithDataToPVD(chamberName, PVDCommands.BIAS_AUTO.ToString(), ConfigurationValues.DEVICE_STATUS_CLOSED)
            End Select

        End Function
        '       BIAS_PRESETS_PROGRAM
        Public Shared Function Bias_Target_Presets_Program(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Bias_Target_Presets_Program")
            AVPLib.Log.coreLogger.Info("Leave Bias_Target_Presets_Program")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.BIAS_PRESETS_PROGRAM.ToString(), data)
        End Function
        '       BIAS_RECALL
        Public Shared Function Bias_Target_Recall(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Bias_Target_Recall")
            AVPLib.Log.coreLogger.Info("Leave Bias_Target_Recall")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.BIAS_RECALL.ToString(), data)
        End Function
        '       BIAS_STORE
        Public Shared Function Bias_Target_Store(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Bias_Target_Store")
            AVPLib.Log.coreLogger.Info("Leave Bias_Target_Store")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.BIAS_STORE.ToString(), data)
        End Function
        '       BIAS_COMMUNICATION_STATUS
        Public Shared Function Bias_Target_Communication_Status(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Bias_Target_Communication_Status")
            AVPLib.Log.coreLogger.Info("Leave Bias_Target_Communication_Status")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.BIAS_COMMUNICATION_STATUS.ToString(), data)
        End Function
#End Region

#Region "PARALLEL MAGNET"
        'PARALLEL_CURRENT_PROGRAM
        Public Shared Function Parallel_Current_Program(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Parallel_Current_Program")
            AVPLib.Log.coreLogger.Info("Leave Parallel_Current_Program")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.PARALLEL_CURRENT_PROGRAM.ToString(), data)
        End Function
        'PARALLEL_DUTY_PROGRAM
        Public Shared Function Parallel_Duty_Program(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Parallel_Duty_Program")
            AVPLib.Log.coreLogger.Info("Leave Parallel_Duty_Program")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.PARALLEL_DUTY_PROGRAM.ToString(), data)
        End Function
        'PARALLEL_FREQUENCY_PROGRAM
        Public Shared Function Parallel_Frequency_Program(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Parallel_Frequency_Program")
            AVPLib.Log.coreLogger.Info("Leave Parallel_Frequency_Program")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.PARALLEL_FREQUENCY_PROGRAM.ToString(), data)
        End Function
        'PARALLEL_FREQUENCY_PROGRAM
        Public Shared Function Parallel_Status_Program(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Parallel_Status_Program")
            AVPLib.Log.coreLogger.Info("Leave Parallel_Status_Program")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.PARALLEL_STATUS_READBACK.ToString(), data)
        End Function
#End Region

#Region "CHAMBER INTERLOCK"
        Public Shared Function Chamber_Interlock_PSRelay(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Chamber_Interlock_PSRelay")
            AVPLib.Log.coreLogger.Info("Leave Chamber_Interlock_PSRelay")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.CHAMBERINTERLOCK_PSRELAY_STATUS.ToString(), data)
        End Function
#End Region

#Region "VAT VALVE CONTROLLER"
        'VAT_VALVE_CONTROLLER_TEACH
        Public Shared Function Vat_Valve_Controller_Teach(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Vat_Valve_Controller_Teach")
            AVPLib.Log.coreLogger.Info("Leave Vat_Valve_Controller_Teach")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.VAT_VALVE_CONTROLLER_TEACH.ToString(), data)
        End Function
        'VAT_VALVE_CONTROLLER_PRESSURE
        Public Shared Function Vat_Valve_Controller_Pressure(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Vat_Valve_Controller_Pressure")
            AVPLib.Log.coreLogger.Info("Leave Vat_Valve_Controller_Pressure")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.VAT_VALVE_CONTROLLER_PRESSURE.ToString(), data)
        End Function
        Public Shared Function Vat_Valve_Controller_Pressure_Percent(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Vat_Valve_Controller_Pressure_Percent")
            AVPLib.Log.coreLogger.Info("Leave Vat_Valve_Controller_Pressure_Percent")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.VAT_VALVE_CONTROLLER_PRESSURE_PERCENT.ToString(), data)
        End Function
        'VAT_VALVE_CONTROLLER_COMMUNICATION
        Public Shared Function Vat_Valve_Controller_Communication_Status(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Vat_Valve_Controller_Communication_Status")
            AVPLib.Log.coreLogger.Info("Leave Vat_Valve_Controller_Communication_Status")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.VAT_VALVE_COMMUNICATION_STATUS.ToString(), data)
        End Function
        'VAT_VALVE_CONTROLLER_ADJUST SIZE
        Public Shared Function Vat_Valve_Controller_SizeAdjust(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Vat_Valve_Controller_SizeAdjust")
            AVPLib.Log.coreLogger.Info("Leave Vat_Valve_Controller_SizeAdjust")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.VAT_VALVE_CONTROLLER_SIZEADJUST.ToString(), data)
        End Function
#End Region

#Region "MAGNATRON"
        'MAGNATRON_ROTATING_STATUS
        Public Shared Function Magnatron_Rotating_Status(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Magnatron_Rotating_Status")
            AVPLib.Log.coreLogger.Info("Leave Magnatron_Rotating_Status")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.MAGNATRON_ROTATING_STATUS.ToString(), data)
        End Function
        'MAGNATRON_ROTATION_START
        Public Shared Function Magnatron_Rotation_Start(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Magnatron_Rotation_Start")
            AVPLib.Log.coreLogger.Info("Leave Magnatron_Rotation_Start")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.MAGNATRON_ROTATION_START.ToString(), data)
        End Function
#End Region

#Region "PROCESS MONITOR"
        'PROCESS_RECIPE
        Public Shared Function Process_Recipe(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Process_Recipe")
            AVPLib.Log.coreLogger.Info("Leave Process_Recipe")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.PROCESS_RECIPE.ToString(), data)
        End Function
        'PROCESS_WAFER_ID
        Public Shared Function Process_WaferID(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Process_WaferID")
            AVPLib.Log.coreLogger.Info("Leave Process_WaferID")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.PROCESS_WAFER_ID.ToString(), data)
        End Function
        'PROCESS_PROCESS_TIME
        Public Shared Function Process_ProcessTime(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Process_ProcessTime")
            AVPLib.Log.coreLogger.Info("Leave Process_ProcessTime")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.PROCESS_PROCESS_TIME.ToString(), data)
        End Function
        'PROCESS_PROCESS_STEP
        Public Shared Function Process_ProcessStep(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Process_ProcessStep")
            AVPLib.Log.coreLogger.Info("Leave Process_ProcessStep")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.PROCESS_PROCESS_STEP.ToString(), data)
        End Function
        'PROCESS_STEP_TIME
        Public Shared Function Process_StepTime(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Process_StepTime")
            AVPLib.Log.coreLogger.Info("Leave Process_StepTime")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.PROCESS_STEP_TIME.ToString(), data)
        End Function
        'PROCESS_USERLEVEL
        Public Shared Function Process_UserLevel(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Process_UserLevel")
            AVPLib.Log.coreLogger.Info("Leave Process_UserLevel")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.PROCESS_USERLEVEL.ToString(), data)
        End Function
        'PROCESS_STATUS
        Public Shared Function Process_Status(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Process_Status")
            AVPLib.Log.coreLogger.Info("Leave Process_Status")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.PROCESS_STATUS.ToString(), data)
        End Function
        Public Shared Function Process_Control_Name(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Process_Control_Name")
            AVPLib.Log.coreLogger.Info("Leave Process_Control_Name")
            Return PVDUtility.SendCommandWithDataToPVD(chamberName, PVDCommands.PROCESS_CONTROL_SEND_RECIPE_NAME.ToString(), data)
        End Function
        Public Shared Function Process_Control_Run_Data_File_Name(ByVal chamberName As String, ByVal data As String) As Boolean
            Return PVDUtility.SendCommandWithDataToPVD(chamberName, PVDCommands.PROCESS_CONTROL_SEND_RUN_DATA_FILE_NAME.ToString(), data)
        End Function
#End Region

#Region "CHUCK POS"
        'CHUCK_POS1
        Public Shared Function Chuck_Pos1(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Chuck_Pos1")
            AVPLib.Log.coreLogger.Info("Leave Chuck_Pos1")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.CHUCK_POS_READBACK.ToString(), data)
        End Function
        'CHUCK_POS2
        Public Shared Function Chuck_Pos2(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Chuck_Pos2")
            AVPLib.Log.coreLogger.Info("Leave Chuck_Pos2")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.CHUCK_POS_PROGRAM.ToString(), data)
        End Function
        'WATER_PUMP_T_READBACK
        Public Shared Function Clamp_UnClamp_Status(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Clamp_UnClamp_Status")
            AVPLib.Log.coreLogger.Info("Leave Clamp_UnClamp_Status")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.CLAMP_STATUS_PROGRAM.ToString(), data)
        End Function

#End Region

#Region "CRYO"
        'CRYO_T1_READBACK
        Public Shared Function Cryo_T1_Readback(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Cryo_T1_Readback")
            AVPLib.Log.coreLogger.Info("Leave Cryo_T1_Readback")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.CRYO_T1_READBACK.ToString(), data)
        End Function
        'CRYO_T2_READBACK
        Public Shared Function Cryo_T2_Readback(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Cryo_T2_Readback")
            AVPLib.Log.coreLogger.Info("Leave Cryo_T2_Readback")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.CRYO_T2_READBACK.ToString(), data)
        End Function
        'CRYO_STATUS
        Public Shared Function Cryo_Status(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Cryo_Status")
            AVPLib.Log.coreLogger.Info("Leave Cryo_Status")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.CRYO_COMMUNICATION_STATUS.ToString(), data)
        End Function
#End Region

#Region "WATER PUMP"
        'WATER_PUMP_T_READBACK
        Public Shared Function Water_Pump_T_Readback(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Water_Pump_T_Readback")
            AVPLib.Log.coreLogger.Info("Leave Water_Pump_T_Readback")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.WATER_PUMP_T_READBACK.ToString(), data)
        End Function
        'WATER_PUMP_STATUS
        Public Shared Function Water_Pump_Status(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Water_Pump_Status")
            AVPLib.Log.coreLogger.Info("Leave Water_Pump_Status")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.WATER_PUMP_STATUS.ToString(), data)
        End Function
#End Region

#Region "TURBO PUMP"
        'TURBO_PUMP_STATUS
        Public Shared Function Turbo_Pump_Status(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Turbo_Pump_Status")
            AVPLib.Log.coreLogger.Info("Leave Turbo_Pump_Status")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.TURBO_PUMP_STATUS.ToString(), data)
        End Function
#End Region

#Region "IG INFOR"
        'IG_READBACK
        Public Shared Function IG_Information_Readback(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter IG_Information_Readback")
            AVPLib.Log.coreLogger.Info("Leave IG_Information_Readback")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.IG_READBACK.ToString(), data)
        End Function
#End Region

#Region "CG INFOR"
        'CB_READBACK
        Public Shared Function CG_Information_Readback(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter CG_Information_Readback")
            AVPLib.Log.coreLogger.Info("Leave CG_Information_Readback")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.CG_READBACK.ToString(), data)
        End Function
#End Region

#Region "Valves"
        'Hivac_VALVE
        Public Shared Function Hivac_Valve(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Hivac_Valve")
            AVPLib.Log.coreLogger.Info("Leave Hivac_Valve")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.HIVAC_VALVE_STATUS.ToString(), data)
        End Function
        'BARATRON_VALVE
        Public Shared Function Baratron_Valve(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Baratron_Valve")
            AVPLib.Log.coreLogger.Info("Leave Baratron_Valve")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.BARATRON_VALVE_STATUS.ToString(), data)
        End Function
        'WATER_VALVE
        Public Shared Function Water_Valve(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Water_Valve")
            AVPLib.Log.coreLogger.Info("Leave Water_Valve")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.WATER_VALVE_STATUS.ToString(), data)
        End Function
        'ROUGH_VALVE
        Public Shared Function Rough_Valve(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Rough_Valve")
            AVPLib.Log.coreLogger.Info("Leave Rough_Valve")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.ROUGH_VALVE_STATUS.ToString(), data)
        End Function
        'VENT_VALVE
        Public Shared Function Vent_Valve(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Vent_Valve")
            AVPLib.Log.coreLogger.Info("Leave Vent_Valve")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.VENT_VALVE_STATUS.ToString(), data)
        End Function

        'TURBO_ISOLATION_VALVE
        Public Shared Function Turbo_Isolation_Valve(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter TURBO_ISOLATION_VALVE")
            AVPLib.Log.coreLogger.Info("Leave TURBO_ISOLATION_VALVE")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.TURBO_ISOLATION_VALVE_STATUS.ToString(), data)
        End Function
        'SHUTTER_VALVE_STATUS
        Public Shared Function Shutter_Valve(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Shutter_Valve")
            AVPLib.Log.coreLogger.Info("Leave Shutter_Valve")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.SHUTTER_VALVE_STATUS.ToString(), data)
        End Function
        'PLASMA_IGNITER_VALVE
        Public Shared Function Plasma_Igniter_Valve(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Plasma_Igniter_Valve")
            AVPLib.Log.coreLogger.Info("Leave Plasma_Igniter_Valve")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.PLASMA_IGNITER_VALVE_STATUS.ToString(), data)
        End Function
        'SHUTOFF1_VALVE
        Public Shared Function ShutOff1_Valve(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter ShutOff1_Valve")
            AVPLib.Log.coreLogger.Info("Leave ShutOff1_Valve")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.SHUTOFF1_VALVE_STATUS.ToString(), data)
        End Function
        'SHUTOFF2_VALVE
        Public Shared Function ShutOff2_Valve(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter ShutOff2_Valve")
            AVPLib.Log.coreLogger.Info("Leave ShutOff2_Valve")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.SHUTOFF2_VALVE_STATUS.ToString(), data)
        End Function
        'SHUTOFF3_VALVE
        Public Shared Function ShutOff3_Valve(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter ShutOff3_Valve")
            AVPLib.Log.coreLogger.Info("Leave ShutOff3_Valve")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.SHUTOFF3_VALVE_STATUS.ToString(), data)
        End Function
        'SHUTOFF4_VALVE
        Public Shared Function ShutOff4_Valve(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter ShutOff4_Valve")
            AVPLib.Log.coreLogger.Info("Leave ShutOff4_Valve")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.SHUTOFF4_VALVE_STATUS.ToString(), data)
        End Function
        'SHUTOFF5_VALVE
        Public Shared Function ShutOff5_Valve(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter ShutOff5_Valve")
            AVPLib.Log.coreLogger.Info("Leave ShutOff5_Valve")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.SHUTOFF5_VALVE_STATUS.ToString(), data)
        End Function
        'SUPPLY5_VALVE
        Public Shared Function Supply5_Valve(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Supply5_Valve")
            AVPLib.Log.coreLogger.Info("Leave Supply5_Valve")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.SUPPLY5_VALVE_STATUS.ToString(), data)
        End Function
        'SUPPLY4_VALVE
        Public Shared Function Supply4_Valve(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Supply4_Valve")
            AVPLib.Log.coreLogger.Info("Leave Supply4_Valve")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.SUPPLY4_VALVE_STATUS.ToString(), data)
        End Function
        'SUPPLY3_VALVE
        Public Shared Function Supply3_Valve(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Supply3_Valve")
            AVPLib.Log.coreLogger.Info("Leave Supply3_Valve")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.SUPPLY3_VALVE_STATUS.ToString(), data)
        End Function
        'SUPPLY2_VALVE
        Public Shared Function Supply2_Valve(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Supply2_Valve")
            AVPLib.Log.coreLogger.Info("Leave Supply2_Valve")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.SUPPLY2_VALVE_STATUS.ToString(), data)
        End Function
        'SUPPLY1_VALVE
        Public Shared Function Supply1_Valve(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Supply1_Valve")
            AVPLib.Log.coreLogger.Info("Leave Supply1_Valve")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.SUPPLY1_VALVE_STATUS.ToString(), data)
        End Function

#End Region

#Region "Gas Controller"
        'GAS_CONTROLLER_GAS1_PROGRAM
        Public Shared Function Gas_Controller_Gas1_Program(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Gas_Controller_Gas1_Program")
            AVPLib.Log.coreLogger.Info("Leave Gas_Controller_Gas1_Program")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.GASCONTROLLER_GAS1_PROGRAM.ToString(), data)
        End Function
        'GAS_CONTROLLER_GAS2_PROGRAM
        Public Shared Function Gas_Controller_Gas2_Program(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Gas_Controller_Gas2_Program")
            AVPLib.Log.coreLogger.Info("Leave Gas_Controller_Gas2_Program")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.GASCONTROLLER_GAS2_PROGRAM.ToString(), data)
        End Function
        'GAS_CONTROLLER_GAS3_PROGRAM
        Public Shared Function Gas_Controller_Gas3_Program(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Gas_Controller_Gas3_Program")
            AVPLib.Log.coreLogger.Info("Leave Gas_Controller_Gas3_Program")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.GASCONTROLLER_GAS3_PROGRAM.ToString(), data)
        End Function
        'GAS_CONTROLLER_GAS4_PROGRAM
        Public Shared Function Gas_Controller_Gas4_Program(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Gas_Controller_Gas4_Program")
            AVPLib.Log.coreLogger.Info("Leave Gas_Controller_Gas4_Program")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.GASCONTROLLER_GAS4_PROGRAM.ToString(), data)
        End Function
        'GAS_CONTROLLER_GAS5_PROGRAM
        Public Shared Function Gas_Controller_Gas5_Program(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Gas_Controller_Gas5_Program")
            AVPLib.Log.coreLogger.Info("Leave Gas_Controller_Gas5_Program")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.GASCONTROLLER_GAS5_PROGRAM.ToString(), data)
        End Function
#End Region

#Region " BA Control"
        'BARATRON_IG_STATUS
        Public Shared Function Baratron_IG_Status(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Baratron_IG_Status")
            AVPLib.Log.coreLogger.Info("Leave Baratron_IG_Status")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.BARATRON_IG_STATUS.ToString(), data)
        End Function
        'BARATRON_CG_PROGRAM
        Public Shared Function Baratron_CG_Program(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Baratron_CG_Program")
            AVPLib.Log.coreLogger.Info("Leave Baratron_CG_Program")
            Return SendCommandWithDataToPVD(chamberName, PVDCommands.BARATRON_CG_PROGRAM.ToString(), data)
        End Function
#End Region
#Region "Diagnostic Dialog"
        Public Shared Function Stop_PumpDown_Curve(ByVal strChamber As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Stop_PumpDown_Curve")
            AVPLib.Log.coreLogger.Info("Leave Stop_PumpDown_Curve")
            Return AVPLib.Business.PVDUtility.SendCommandWithDataToPVD _
                   (strChamber, AVPLib.Business.PVDCommands.PUMPDOWN_CURVE_STATUS.ToString(), _
                     AVPLib.ConfigurationValues.DEVICE_STATUS_CLOSED)
        End Function

        Public Shared Function Start_PumpDown_Curve(ByVal strChamber As String, ByVal strSampleTime As String, ByVal strTotalTime As String, ByVal strDescription As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Start_PumpDown_Curve")
            Dim IsPMIsoValveClose As Boolean = Utils.IsChamberSlitValveClose(strChamber)
            If PVDUtility.SendCommandWithDataToPVD(strChamber, _
                                                    PVDCommands.SPLITVALVE_STATUS.ToString(), _
                                                    IIf(IsPMIsoValveClose, ConfigurationValues.DEVICE_STATUS_CLOSED, _
                                                        ConfigurationValues.DEVICE_STATUS_OPEN), False) Then
                If AVPLib.Business.PVDUtility.SendCommandWithDataToPVD _
                  (strChamber, AVPLib.Business.PVDCommands.PUMPDOWN_CURVE_INTERVAL_RECORDING.ToString(), _
                   "Interval=" & strSampleTime & "#Period=" & strTotalTime & _
                   "#Desc=" & strDescription & "#") Then
                    Return AVPLib.Business.PVDUtility.SendCommandWithDataToPVD _
                        (strChamber, AVPLib.Business.PVDCommands.PUMPDOWN_CURVE_STATUS.ToString(), _
                         AVPLib.ConfigurationValues.DEVICE_STATUS_OPEN)
                End If
            End If
            AVPLib.Log.coreLogger.Info("Leave Start_PumpDown_Curve")
            Return False
        End Function

        Public Shared Function Start_Rate_Of_Rise(ByVal strChamber As String, ByVal strSampleTime As String, ByVal strTotalTime As String, ByVal strDescription As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Start_Rate_Of_Rise")
            Dim IsPMIsoValveClose As Boolean = Utils.IsChamberSlitValveClose(strChamber)
            If PVDUtility.SendCommandWithDataToPVD(strChamber, _
                                                    PVDCommands.SPLITVALVE_STATUS.ToString(), _
                                                    IIf(IsPMIsoValveClose, ConfigurationValues.DEVICE_STATUS_CLOSED, _
                                                        ConfigurationValues.DEVICE_STATUS_OPEN), False) Then
                If AVPLib.Business.PVDUtility.SendCommandWithDataToPVD _
                      (strChamber, AVPLib.Business.PVDCommands.RATE_OF_RISE_INTERVAL_RECORDING.ToString(), _
                       "Interval=" & strSampleTime & "#Period=" & strTotalTime & _
                       "#Desc=" & strDescription & "#") Then
                    Return AVPLib.Business.PVDUtility.SendCommandWithDataToPVD _
                        (strChamber, AVPLib.Business.PVDCommands.RATE_OF_RISE_STATUS.ToString(), _
                         AVPLib.ConfigurationValues.DEVICE_STATUS_OPEN)
                End If
            End If
            AVPLib.Log.coreLogger.Info("Leave Start_Rate_Of_Rise")
            Return False
        End Function

        Public Shared Function Stop_Rate_Of_Rise(ByVal strChamber As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Stop_Rate_Of_Rise")
            AVPLib.Log.coreLogger.Info("Leave Stop_Rate_Of_Rise")
            Return AVPLib.Business.PVDUtility.SendCommandWithDataToPVD _
                    (strChamber, AVPLib.Business.PVDCommands.RATE_OF_RISE_STATUS.ToString(), _
                     AVPLib.ConfigurationValues.DEVICE_STATUS_CLOSED)
        End Function

#End Region
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Send Command With Data To PVD
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function SendCommandWithDataToPVD(ByVal chamberName As String, _
                                                        ByVal commandName As String, _
                                                        ByVal commandData As String, _
                                                        Optional ByVal blLog As Boolean = True) As Boolean
            AVPLib.Log.coreLogger.Info("Enter SendCommandWithDataToPVD")
            Try
                Dim commandCode As String = ContainerData.GetPVDCmdCode(commandName)
                Dim strChannel As String = "1" '''we will get channel in config file
                If Not String.IsNullOrEmpty(commandCode) Then
                    If Not String.IsNullOrEmpty(commandData) Then
                        commandCode = ConvertDataToPVD(strChannel, commandCode, commandData, commandName)
                    End If
                    AVPLib.Log.coreLogger.Info("Leave SendCommandWithDataToPVD")
                    'Begin Remove the channel from the command
                    'Dim FoundMatch As Boolean = Regex.IsMatch(commandCode, ".*?,(.*)")
                    'If (FoundMatch) Then
                    '    Dim mtcMatch As Match = Regex.Match(commandCode, ".*?,(.*)")
                    '    If mtcMatch.Groups.Count > 1 Then
                    '        commandCode = mtcMatch.Groups(1).Value
                    '    End If
                    'End If
                    'End Remove the channel from the command
                    Return Utils.SendCommandPMServer(chamberName, commandCode, blLog)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave SendCommandWithDataToPVD")
            Return False
        End Function
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-09-04</date>
        ''' </author>
        ''' <summary>
        ''' Convert data to IBE pattern" 1,05,01,12,01,01,0.00E+000
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function ConvertDataToPVD(ByVal Channel As String, ByVal commandCode As String, ByVal commandData As String, ByVal commandName As String) As String
            AVPLib.Log.coreLogger.Info("Enter ConvertDataToPVD")
            Dim strResult As String = String.Empty
            Try
                strResult = commandCode
                If ContainerData.GetPVDDecoder(commandName) = "Double" Then
                    'If commandName = pvdcommands..FIXTURE_STATIC_ANGLE.ToString() Or commandName = IBECommands.FIXTURE_ROTATION_START_ANGLE.ToString() Or _
                    'commandName = IBECommands.FIXTURE_ROTATION_END_ANGLE.ToString() Then
                    '    strResult = strResult & "," & commandData
                    'Else
                    strResult = strResult & "," & Format(Double.Parse(commandData), "0.00E+000")
                Else
                    strResult = strResult & "," & commandData
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave ConvertDataToPVD")
            Return strResult
        End Function
#End Region
    End Class
End Namespace

