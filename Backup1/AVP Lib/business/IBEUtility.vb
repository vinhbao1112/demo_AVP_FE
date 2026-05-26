Imports AVPLib.Communication.TerminalDriver
Imports System.Text.RegularExpressions
Namespace Business

    Public Enum IBECommands
        REQUEST_ALL_DATA
        COPYRECIPE_TEMPLATE
        CHECK_RECIPE_TEMPLATE_VERSION
        ROUGH_PUMP_POWER ' = 0
        TURBO_PUMP_POWER
        TURBO_PUMP_GATE_VALVE
        TURBO_PUMP_WATER_VALVE
        SLAVE_TURBO
        CRYO_POWER
        CRYO_PUMP_TEMPERTURE
        CRYO_PUMP_GATE_VALVE
        CRYO_REGEN_VALVE
        CRYO_PURGE_VALVE
        CRYO_AUTO_REGEN
        CRYO_AUTO_POWER_DOWN
        CRYO_P_COMMANDS
        'CRYO_P_COMMAND_READBACK
        WATER_PUMP
        WATER_PUMP_REGEN
        IGISOLATION_VALVE
        GASDIVERTER_VALVE
        DIVERTER_VALVE
        ROUGH_VALVE
        VENT_VALVE
        ISOLATION_VALVE
        FORELINE_VALVE
        ION_GAUGE_PRESSURE
        ION_GAUGE_EMISSION
        ION_GAUGE_DEGAS
        PIRANI_CHAMBER_ROUGH_PRESSURE
        PIRANI_FORELINE_PRESSURE
        PIRANI_ROUGH_PUMP_PRESSURE
        MP_COMMUNICATING
        TURBO_FORELINE_COMMUNICATING
        AIR_PRESSURE_INTK
        VACUUM_PRESSURE_INTK
        FORELINE_PRESSURE_INTK
        AUTO_PUMP_DOWN
        AUTO_VENT
        VACUUM_LOCK
        CHAMBER_HEATER
        PROCESS_START_PRESSURE
        PUMPED_DOWN_PRESSURE
        ATMOSPHERE_PRESSURE
        ROUGH_TIMEOUT
        VENT_TIMEOUT
        TURBO_VENT_DELAY

        SPLITVALVE_STATUS

        RATE_OF_RISE_STATUS
        RATE_OF_RISE_SAMPLE
        RATE_OF_RISE_FILENAME
        RATE_OF_RISE_INTERVAL_RECORDING
        PUMPDOWN_CURVE_STATUS
        PUMPDOWN_CURVE_SAMPLE
        PUMPDOWN_CURVE_FILENAME
        PUMPDOWN_CURVE_INTERVAL_RECORDING

        PUMP_PURGE
        'Fixture
        FIXTURE_FLOWCOOL_PUMP_POWER
        FIXTURE_WATER_VALVE
        FIXTURE_WATER_INTERLOCK
        FIXTURE_WATER_BUG_INTERLOCK
        FIXTURE_LOCK
        FIXTURE_CLAMP
        'FIXTURE_STATIC_ANGLE
        FIXTURE_ROTATION_MOVING
        FIXTURE_ROTATION_ERROR
        FIXTURE_ROTATION_MODE
        FIXTURE_ROTATION_DWELL_TIME

        FLOWCOOL_GAS_ON_STATUS
        FLOWCOOL_MFC_SHUTOFF_VALVE
        FLOWCOOL_MFC_SUPPLY_VALVE
        FLOWCOOL_MFC_TARGET_FLOWRATE
        FLOWCOOL_MFC_ACTUAL_FLOWRATE
        FLOWCOOL_PRESSURE
        WAFER_IN_FIXTURE
        INITIALIZE_MOTION
        INITIALIZING_MOTION
        MOTION_TO_SERVICE_POSITION
        MAGNETIC_CHUCK_POWER
        MAGNETIC_CHUCK_PHASE
        MAGNETIC_CHUCK_AMPLITUDE
        MAGNETIC_CHUCK_FREQUENCY
        MAGNETIC_CHUCK_WAVE_TYPE
        HOT_CHUCK_POWER
        HOT_CHUCK_GET_TEMPERATURE
        HOT_CHUCK_SET_TEMPERATURE
        STATIC_COOLING_EXHAUST_VALVE
        STATIC_COOLING_SUPPLY_VALVE
        STATIC_COOLING_TARGET_FLOW
        STATIC_COOLING_ACTUAL_FLOW
        STATIC_COOLING_TARGET_PRESSURE
        STATIC_COOLING_ACTUAL_PRESSURE
        STATIC_COOLING_GAS_OK
        STATIC_COOLING_START
        STATIC_COOLING_STOP
        TEC_POWER
        '5,X,1,1,1 - Replace with 5,1,1,1,1
        SHUTTER_POSITION
        SOURCE_AC_POWER
        SOURCE_RF_POWER
        SOURCE_GRID_POWER
        SOURCE_PBN_POWER
        SOURCE_NEUR_POWER
        SOURCE_MANUAL_AUTO_POWER
        AUTO_MANUAL
        ELECTRONIC_SHUTTER
        PBN_GAS_SHUTOFF_VALVE
        PBN_GAS_SUPPLY_VALVE
        PBN_GAS_FLOWRATE_PROGRAM
        AUTOBEAM_PBN_GAS_FLOWRATE_PROGRAM
        PBN_GAS_FLOWRATE_READBACK
        PBN_GAS_FLOWRATE_ERROR_TOL
        PBN_GAS_FLOWRATE_WARNING_TOL
        PBN_GAS_FLOWRATE_ERROR_TIME
        PBN_GAS_FLOWRATE_WARNING_TIME
        N2_PURGE
        BEAM_VOLTAGE_PROGRAM
        BEAM_VOLTAGE_READBACK
        BEAM_VOLTAGE_ERROR_TOL
        BEAM_VOLTAGE_WARNING_TOL
        BEAM_VOLTAGE_ERROR_TIME
        BEAM_VOLTAGE_WARNING_TIME
        BEAM_CURRENT_PROGRAM
        SUPP_CURRENT_PROGRAM
        BEAM_CURRENT_READBACK
        BEAM_CURRENT_ERROR_TOL
        BEAM_CURRENT_WARNING_TOL
        BEAM_CURRENT_ERROR_TIME
        BEAM_CURRENT_WARNING_TIME
        SUPP_VOLTAGE_PROGRAM
        SUPP_VOLTAGE_READBACK
        SUPP_VOLTAGE_ERROR_TOL
        SUPP_VOLTAGE_WARNING_TOL
        SUPP_VOLTAGE_ERROR_TIME
        SUPP_VOLTAGE_WARNING_TIME
        AUTO_BEAM
        PBN_BODY_CURRENT_READBACK
        PBN_BODY_CURRENT_ERROR_TOL
        PBN_BODY_CURRENT_WARNING_TOL
        PBN_BODY_CURRENT_ERROR_TIME
        PBN_BODY_CURRENT_WARNING_TIME
        PBN_FILAMENT_CURRENT_READBACK
        K_FACTOR_PROGRAM
        K_FACTOR_READBACK
        INCIDENT_RF_PROGRAM
        FORWARD_RF_READBACK
        REFLECTED_RF_PROGRAM
        REFLECTED_RF_READBACK
        'Process control
        PROCESS_CONTROL
        PROCESS_CONTROL_NAME
        PROCESS_CURRENT_STEP
        PROCESS_TOTAL_STEPS
        PROCESS_ELAPSED_TIME
        PROCESS_REMAINING_TIME
        PROCESS_ABORT_MESSAGE
        PROCESS_LOT_ID
        PROCESS_CASSETTE_ID
        PROCESS_WAFER_ID
        PROCESS_MODIFY_STEPTIME
        PROCESS_STEPTIME_TIMEOUT
        PROCESS_GEM_WAITFOR_STEPTIME
        GAS_OK
        BEAM_OK
        PBN_OK
        ELECTROSTATIC_SHUTTER_BYPASS
        ELECTROSTATIC_SHUTTER_TIMER
        WAFER_ABORT_STATUS
        MAX_SUPP_CURRENT
        MAX_REF_RF
        MIN_PBN_CURRENT
        MAX_PBN_CURRENT
        SOURCE_USAGE_RESET
        SOURCE_GRID_ID
        SOURCE_USAGE_TIMESET
        SOURCE_USAGE_WARNING
        SOURCE_USAGE_LIMIT
        MAX_SOURCE_USAGE
        SOURCE_MAGNET_MODE
        SOURCE_MAGNET_SPEED
        QUART_KWH
        PBN_TIMESET


        ' Start our command definitions
        BARATRON_VALVE
        FIXTURE_HOME_TILT_AXIS
        FIXTURE_HOME_ROTATION_AXIS
        FIXTURE_START_ROTATION_AXIS
        FIXTURE_HOME_ALL_AXIS
        FIXTURE_STOP_ALL_AXIS
        FIXTURE_UNPROTECTED
        FIXTURE_COOLING_WATER
        ''Gas Controller
        GAS_CONTROLLER_ARGON_PROGRAM
        GAS_CONTROLLER_OXYGEN_PROGRAM
        GAS_CONTROLLER_FLOW_COOL_HE_PROGRAM
        GAS_CONTROLLER_OXYGEN_READBACK
        GAS_CONTROLLER_FLOWCOOLHE_READBACK
        GAS_CONTROLLER_ARGON_READBACK
        ''BA Control
        ION_GAUGE_STATUS
        BARATRON_READBACK
        CONVECTION_GAUGE_READBACK
        ION_GAUGE_PRESSURE_READBACK
        ''Power Supply
        SUPPLY_FORWARD_POWER_PROGRAM
        ''Beam Power Supply
        BEAM_POWER_PROGRAM
        BEAM_POWER_READBACK
        ''Suppressor Power Supply
        SUPP_POWER_PROGRAM
        SUPP_POWER_READBACK
        SUPP_CURRENT_READBACK
        ''Body PowerSupply
        BODY_CURRENT_PROGRAM
        BODY_VOLTAGE_PROGRAM
        BODY_VOLTAGE_READBACK
        ''Discharge Power
        DISC_CURRENT_PROGRAM
        DISC_VOLTAGE_PROGRAM
        DISC_VOLTAGE_READBACK
        DISC_CURRENT_READBACK
        ''Process Recipe
        PROCESS_CONTROL_DEVICE_START
        PROCESS_CONTROL_DEVICE_STOP
        PROCESS_CONTROL_DEVICE_PAUSE
        PROCESS_CONTROL_DEVICE_CONTINUE
        PROCESS_CONTROL_DEVICE_RESET_ERROR
        PROCESS_CONTROL_DEVICE_END_STEP
        PROCESS_CONTROL_SEND_RUN_DATA_FILE_NAME
        CURRENT_AVP_TIME
        ''Chamber Interlock
        CHAMBER_INTER_CHAMBER_PRESS_READBACK
        CHAMBER_INTER_FIXTURE_WATER_READBACK
        CHAMBER_INTER_SOURCE_WATER_READBACK
        CHAMBER_INTER_TARGET_WATER_READBACK
        CHAMBER_INTER_PRESS_READBACK
        CHAMBER_INTER_FORELINE_READBACK
        CHAMBER_INTER_MAGNET_WATER_READBACK
        CHAMBER_INTER_TURBO_WATER_READBACK
        ''FIXTURE
        FIXTURE_TILT_ANGLE
        FIXTURE_TILT_ANGLE_READBACK
        FIXTURE_SWEEP_TILT_ANGLE
        FIXTURE_SWEEP_TILT_START_ANGLE
        FIXTURE_SWEEP_TILT_END_ANGEL
        FIXTURE_SWEEP_TILT_MODE
        FIXTURE_TILT_SWEEPING
        'fixture static mode
        FIXTURE_STATIC_ROTATION_ANGLE_READBACK
        FIXTURE_STATIC_ROTATION_ANGLE
        'fixture static mode
        FIXTURE_ROTATION_START_ANGLE_READBACK
        FIXTURE_ROTATION_START_ANGLE
        FIXTURE_ROTATION_END_ANGLE
        'fixture continuous mode
        FIXTURE_CONTINUOUS_ROTATION_RPM_READBACK
        FIXTURE_CONTINUOUS_ROTATION_RPM
        'end fixture
        FIXTURE_STATUS_READBACK
        FIXTURE_ROTATION_STATUS_READBACK

        ''FLCG Information
        FLCG_READBACK
        ''RLCG Information
        RLCG_READBACK
        ''MG Information
        MG_READBACK
        ''PROCESS MONITOR
        PROCESS_FIXTURE_ANGLE_READBACK
        PROCESS_FIXTURE_ROTATION_READBACK
        PROCESS_STEP_READBACK
        PROCESS_TIME_READBACK
        PROCESS_RECIPE_READBACK
        PROCESS_STATUS_READBACK
        PROCESS_STEP_TIME_READBACK

        'Gases supply valve
        GAS1_SUPPLY_VALVE
        GAS2_SUPPLY_VALVE
        GAS3_SUPPLY_VALVE
        GAS4_SUPPLY_VALVE
        GAS5_SUPPLY_VALVE

        ' Gases shutoff
        GAS1_SHUTOFF_VALVE
        GAS2_SHUTOFF_VALVE
        GAS3_SHUTOFF_VALVE
        GAS4_SHUTOFF_VALVE
        GAS5_SHUTOFF_VALVE

        'Gas program
        GAS1_FLOWRATE_PROGRAM
        GAS2_FLOWRATE_PROGRAM
        AUTOBEAM_GAS1_FLOWRATE_PROGRAM
        AUTOBEAM_GAS2_FLOWRATE_PROGRAM
        AUTOBEAM_GAS3_FLOWRATE_PROGRAM
        AUTOBEAM_GAS4_FLOWRATE_PROGRAM
        GAS3_FLOWRATE_PROGRAM
        GAS4_FLOWRATE_PROGRAM
        GAS5_FLOWRATE_PROGRAM

        'remove
        GAS_TARGET_FLOWRATE_A_PROGRAM
        GAS_TARGET_FLOWRATE_O_PROGRAM
        GAS_ACTUAL_FLOWRATE_A_READBACK
        GAS_ACTUAL_FLOWRATE_O_READBACK
        GAS_SUPPLY_VALVE_A
        GAS_SUPPLY_VALVE_O
        GAS_SHUTOFF_VALVE_A

        GAS_TYPE
        GAS_MFC_MAX_RANGE
        GAS_FLOWRATE_ERROR_TOL
        GAS_FLOWRATE_WARNING_TOL
        GAS_FLOWRATE_ERROR_TIME
        GAS_FLOWRATE_WARNING_TIME

        ALARM_STATUS_READBACK
        EVENT_STATUS_READBACK

        'Wafer Status
        WAFER_PROCESSING_STATUS_READBACK
        KEEP_ALIVE
        'Shield Usage
        COVER_FIXTURE_SHIELD_USAGE
        TOP_FIXTURE_SHIELD_USAGE
        WAFER_CLAMP_USAGE
        SHUTTER_USAGE
        FIXTURE_ROTATION_MOTOR_USAGE
        LINER_SOURCE_USAGE_READBACK
        CRYO_USAGE_READBACK
        WATER_JOURNAL

        COPYRECIPE_TO_PMFOLDER

        PRESSURE_CG_ATM
        PRESSURE_CG_VAC
        FORELINE_CG_ATM
        FORELINE_CG_VAC
        ROUGH_PUMP_CG_ATM
        ROUGH_PUMP_CG_VAC
        TURN_IG_ON_OFF
        SWITCH_IG_FILAMENT_PROGRAM
        SWITCH_IG_FILAMENT_READBACK
        ENABLE_IG_FILAMENT_READBACK

        ' Chiller
        CHILLER_ON_OFF
        CHILLER_STATE
        CHILLER_TEMP_RB
        CHILLER_TEMP_SP
        CHILLER_PROCESS_TEMPERATURE_MAX
        CHILLER_VENT_TEMPERATURE_MAX
        CHILLER_VENT_TEMPERATURE_MIN
        CHILLER_PROCESS_TEMPERATURE_MIN

        'CycleATM
        PROCESS_CYCLEATM_START

        ' Source EM PS
        SOURCE_EM_CURRENT_PROGRAM
        SOURCE_EM_CURRENT_READBACK
        SOURCE_EM_VOLTAGE_READBACK
        SOURCE_EM_CURRENT_AUTO_BEAM_PROGRAM
        SOURCE_EM_COMMUNIACTION_STATUS

        'hidden
        HIDDEN_NAME
        HIDDEN_DATA
        HIDDEN_PARAMS
        HIDDEN_ENVIRONMENT

        'Clear All Alarm
        CLEAR_ALL_ALARM_PROGRAM
    End Enum

    Public Class IBEUtility
#Region "Public methods"
        Public Shared Function Check_Recipe_Template_Version(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Check_Recipe_Template_Version")
            Return IBEUtility.SendCommandWithDataToIBE(chamberName, IBECommands.CHECK_RECIPE_TEMPLATE_VERSION.ToString(), data)
        End Function
        Public Shared Function Process_Control_Run_Data_File_Name(ByVal chamberName As String, ByVal data As String) As Boolean
            Return IBEUtility.SendCommandWithDataToIBE(chamberName, IBECommands.PROCESS_CONTROL_SEND_RUN_DATA_FILE_NAME.ToString(), data)
        End Function
        'TURBO_PUMP_POWER
        Public Shared Function Rough_Pump_Power(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Rough_Pump_Power")
            AVPLib.Log.coreLogger.Info("Leave Rough_Pump_Power")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.ROUGH_PUMP_POWER.ToString(), data)
        End Function
        'TURBO_PUMP_GATE_VALVE
        Public Shared Function Turbo_Pump_Gate_Valve(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Turbo_Pump_Gate_Valve")
            AVPLib.Log.coreLogger.Info("Leave Turbo_Pump_Gate_Valve")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.TURBO_PUMP_GATE_VALVE.ToString(), data)
        End Function
        'TURBO_PUMP_WATER_VALVE
        Public Shared Function Turbo_Pump_Water_Valve(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Turbo_Pump_Water_Valve")
            AVPLib.Log.coreLogger.Info("Leave Turbo_Pump_Water_Valve")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.TURBO_PUMP_POWER.ToString(), data)
        End Function
        'SLAVE_TURBO
        Public Shared Function Slave_Turbo(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Slave_Turbo")
            AVPLib.Log.coreLogger.Info("Leave Slave_Turbo")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.SLAVE_TURBO.ToString(), data)
        End Function
        'CRYO_PUMP_POWER
        Public Shared Function Cryo_Power(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Cryo_Power")
            AVPLib.Log.coreLogger.Info("Leave Cryo_Power")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.CRYO_POWER.ToString(), data)
        End Function
        'CRYO_PUMP_TEMPERTURE
        Public Shared Function Cryo_Pump_Temperture(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Cryo_Pump_Temperture")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.CRYO_PUMP_TEMPERTURE.ToString(), data)
            AVPLib.Log.coreLogger.Info("Leave Cryo_Pump_Temperture")
        End Function
        'CRYO_PUMP_GATE_VALVE
        Public Shared Function Cryo_Pump_Gate_Valve(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Cryo_Pump_Gate_Valve")
            AVPLib.Log.coreLogger.Info("Leave Cryo_Pump_Gate_Valve")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.CRYO_PUMP_GATE_VALVE.ToString(), data)
        End Function
        'CRYO_PUMP_REGEN
        Public Shared Function Cryo_Regen_Valve(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Cryo_Regen_Valve")
            AVPLib.Log.coreLogger.Info("Leave Cryo_Regen_Valve")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.CRYO_REGEN_VALVE.ToString(), data)
        End Function
        'CRYO_PUMP_PURGE
        Public Shared Function Cryo_Purge_Valve(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Cryo_Purge_Valve")
            AVPLib.Log.coreLogger.Info("Leave Cryo_Purge_Valve")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.CRYO_PURGE_VALVE.ToString(), data)
        End Function
        'CRYO_AUTO_REGEN
        Public Shared Function Cryo_Auto_Gegen(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Cryo_Auto_Gegen")
            AVPLib.Log.coreLogger.Info("Leave Cryo_Auto_Gegen")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.CRYO_AUTO_REGEN.ToString(), data)
        End Function
        'CRYO_AUTO_POWER_DOWN
        Public Shared Function Cryo_Auto_Power_Down(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Cryo_Auto_Power_Down")
            AVPLib.Log.coreLogger.Info("Leave Cryo_Auto_Power_Down")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.CRYO_AUTO_POWER_DOWN.ToString(), data)
        End Function
        'ROUGH_VALVE
        Public Shared Function Rough_Valve(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Rough_Valve")
            AVPLib.Log.coreLogger.Info("Leave Rough_Valve")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.ROUGH_VALVE.ToString(), data)
        End Function
        'VENT_VALVE
        Public Shared Function Vent_Valve(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Vent_Valve")
            AVPLib.Log.coreLogger.Info("Leave Vent_Valve")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.VENT_VALVE.ToString(), data)
        End Function
        'GAS_SUPPLY_VALVE_A
        Public Shared Function Gas_Supply_Argon_Valve(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter GasShutOff_Valve")
            AVPLib.Log.coreLogger.Info("Leave GasShutOff_Valve")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.GAS_SUPPLY_VALVE_A.ToString(), data)
        End Function
        'GAS_SHUTOFF_VALVE
        Public Shared Function Gas_ShutOff_Argon_Valve(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter GasShutOff_Valve")
            AVPLib.Log.coreLogger.Info("Leave GasShutOff_Valve")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.GAS_SHUTOFF_VALVE_A.ToString(), data)
        End Function
        'FORELINE_VALVE
        Public Shared Function Foreline_Valve(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Foreline_Valve")
            AVPLib.Log.coreLogger.Info("Leave Foreline_Valve")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.FORELINE_VALVE.ToString(), data)
        End Function
        'ION_GAUGE_PRESSURE
        Public Shared Function Ion_Gauge_Pressure(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Ion_Gauge_Pressure")
            AVPLib.Log.coreLogger.Info("Leave Ion_Gauge_Pressure")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.ION_GAUGE_PRESSURE.ToString(), data)
        End Function
        'ION_GAUGE_EMISSION
        Public Shared Function Ion_Gauge_Emission(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Ion_Gauge_Emission")
            AVPLib.Log.coreLogger.Info("Leave Ion_Gauge_Emission")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.ION_GAUGE_EMISSION.ToString(), data)
        End Function
        'ION_GAUGE_DEGAS
        Public Shared Function Ion_Gauge_Degas(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Ion_Gauge_Degas")
            AVPLib.Log.coreLogger.Info("Leave Ion_Gauge_Degas")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.ION_GAUGE_DEGAS.ToString(), data)
        End Function
        'PIRANI_CHAMBER_ROUGH_PRESSURE
        Public Shared Function Pirani_Chamber_Rough_Pressure(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Pirani_Chamber_Rough_Pressure")
            AVPLib.Log.coreLogger.Info("Leave Pirani_Chamber_Rough_Pressure")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.PIRANI_CHAMBER_ROUGH_PRESSURE.ToString(), data)
        End Function
        'PIRANI_FORELINE_PRESSURE
        Public Shared Function Pirani_Foreline_Pressure(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Pirani_Foreline_Pressure")
            AVPLib.Log.coreLogger.Info("Leave Pirani_Foreline_Pressure")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.PIRANI_FORELINE_PRESSURE.ToString(), data)
        End Function
        'PIRANI_ROUGH_PUMP_PRESSURE
        Public Shared Function Pirani_Rough_Pump_Pressure(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Pirani_Rough_Pump_Pressure")
            AVPLib.Log.coreLogger.Info("Leave Pirani_Rough_Pump_Pressure")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.PIRANI_ROUGH_PUMP_PRESSURE.ToString(), data)
        End Function
        'AIR_PRESSURE_INTK
        Public Shared Function Air_Pressure_Intk(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Air_Pressure_Intk")
            AVPLib.Log.coreLogger.Info("Leave Air_Pressure_Intk")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.AIR_PRESSURE_INTK.ToString(), data)
        End Function
        'VACUUM_PRESSURE_INTK
        Public Shared Function Vacuum_Pressure_Intk(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Vacuum_Pressure_Intk")
            AVPLib.Log.coreLogger.Info("Leave Vacuum_Pressure_Intk")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.VACUUM_PRESSURE_INTK.ToString(), data)
        End Function
        'FORELINE_PRESSURE_INTK
        Public Shared Function Foreline_Pressure_Intk(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Foreline_Pressure_Intk")
            AVPLib.Log.coreLogger.Info("Leave Foreline_Pressure_Intk")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.FORELINE_PRESSURE_INTK.ToString(), data)
        End Function
        'AUTO_PUMP_DOWN
        Public Shared Function Auto_Pump_Down(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Auto_Pump_Down")
            AVPLib.Log.coreLogger.Info("Leave Auto_Pump_Down")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.AUTO_PUMP_DOWN.ToString(), data)
        End Function
        'AUTO_VENT
        Public Shared Function Auto_Vent(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Auto_Vent")
            AVPLib.Log.coreLogger.Info("Leave Auto_Vent")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.AUTO_VENT.ToString(), data)
        End Function
        'VACUUM_LOCK
        Public Shared Function Vacuum_Lock(ByVal chamberName As String, ByVal data As String) As Boolean
            Return SendCommandWithDataToIBE(chamberName, IBECommands.VACUUM_LOCK.ToString(), data)
        End Function
        'CHAMBER_HEATER
        Public Shared Function Chamber_Heater(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Chamber_Heater")
            AVPLib.Log.coreLogger.Info("Leave Chamber_Heater")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.CHAMBER_HEATER.ToString(), data)
        End Function
        'PROCESS_START_PRESSURE
        Public Shared Function Process_Start_Pressure(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Process_Start_Pressure")
            AVPLib.Log.coreLogger.Info("Leave Process_Start_Pressure")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.PROCESS_START_PRESSURE.ToString(), data)
        End Function
        'PUMPED_DOWN_PRESSURE
        Public Shared Function Pumped_Down_Pressure(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Pumped_Down_Pressure")
            AVPLib.Log.coreLogger.Info("Leave Pumped_Down_Pressure")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.PUMPED_DOWN_PRESSURE.ToString(), data)
        End Function
        'ATMOSPHERE_PRESSURE
        Public Shared Function Atmosphere_Pressure(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Atmosphere_Pressure")
            AVPLib.Log.coreLogger.Info("Leave Atmosphere_Pressure")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.ATMOSPHERE_PRESSURE.ToString(), data)
        End Function
        'ROUGH_TIMEOUT
        Public Shared Function Rough_Timeout(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Rough_Timeout")
            AVPLib.Log.coreLogger.Info("Leave Rough_Timeout")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.ROUGH_TIMEOUT.ToString(), data)
        End Function
        'VENT_TIMEOUT
        Public Shared Function Vent_Timeout(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Vent_Timeout")
            AVPLib.Log.coreLogger.Info("Leave Vent_Timeout")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.VENT_TIMEOUT.ToString(), data)
        End Function
        'TURBO_VENT_DELAY
        Public Shared Function Turbo_Vent_Delay(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Turbo_Vent_Delay")
            AVPLib.Log.coreLogger.Info("Leave Turbo_Vent_Delay")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.TURBO_VENT_DELAY.ToString(), data)
        End Function
        ''Fixture
        'FIXTURE_FLOWCOOL_PUMP_POWER
        Public Shared Function Fixture_Flowcool_Pump_Power(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Fixture_Flowcool_Pump_Power")
            AVPLib.Log.coreLogger.Info("Leave Fixture_Flowcool_Pump_Power")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.FIXTURE_FLOWCOOL_PUMP_POWER.ToString(), data)
        End Function
        'FIXTURE_WATER_VALVE
        Public Shared Function Fixture_Water_Valve(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Fixture_Water_Valve")
            AVPLib.Log.coreLogger.Info("Leave Fixture_Water_Valve")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.FIXTURE_WATER_VALVE.ToString(), data)
        End Function
        'FIXTURE_WATER_INTERLOCK
        Public Shared Function Fixture_Water_Interlock(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Fixture_Water_Interlock")
            AVPLib.Log.coreLogger.Info("Leave Fixture_Water_Interlock")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.FIXTURE_WATER_INTERLOCK.ToString(), data)
        End Function
        'FIXTURE_WATER_BUG_INTERLOCK
        Public Shared Function Fixture_Water_Bug_Interlock(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Fixture_Water_Bug_Interlock")
            AVPLib.Log.coreLogger.Info("Leave Fixture_Water_Bug_Interlock")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.FIXTURE_WATER_BUG_INTERLOCK.ToString(), data)
        End Function
        'FIXTURE_LOCK
        Public Shared Function Fixture_Lock(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Fixture_Lock")
            AVPLib.Log.coreLogger.Info("Leave Fixture_Lock")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.FIXTURE_LOCK.ToString(), data)
        End Function
        'FIXTURE_CLAMP
        Public Shared Function Fixture_Clamp(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Fixture_Clamp")
            AVPLib.Log.coreLogger.Info("Leave Fixture_Clamp")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.FIXTURE_CLAMP.ToString(), data)
        End Function
        'FIXTURE_STATIC_ANGLE
        Public Shared Function Fixture_Static_Rotation_Angle(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Fixture_Static_Rotation_Angle")
            AVPLib.Log.coreLogger.Info("Leave Fixture_Static_Rotation_Angle")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.FIXTURE_STATIC_ROTATION_ANGLE.ToString(), data)
        End Function
        'FIXTURE_ROTATION_MOVING
        Public Shared Function Fixure_Rotation_Moving(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Fixure_Rotation_Moving")
            AVPLib.Log.coreLogger.Info("Leave Fixure_Rotation_Moving")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.FIXTURE_ROTATION_MOVING.ToString(), data)
        End Function
        'FIXTURE_ROTATION_ERROR
        Public Shared Function Fixure_Rotation_Error(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Fixure_Rotation_Error")
            AVPLib.Log.coreLogger.Info("Leave Fixure_Rotation_Error")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.FIXTURE_ROTATION_ERROR.ToString(), data)
        End Function
        'FIXTURE_ROTATION_MODE
        Public Shared Function Fixture_Rotation_Mode(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Fixture_Rotation_Mode")
            AVPLib.Log.coreLogger.Info("Leave Fixture_Rotation_Mode")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.FIXTURE_ROTATION_MODE.ToString(), data)
        End Function
        'FIXTURE_ROTATION_START_ANGLE
        Public Shared Function Fixture_Rotation_Start_Angle(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Fixture_Rotation_Start_Angle")
            AVPLib.Log.coreLogger.Info("Leave Fixture_Rotation_Start_Angle")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.FIXTURE_ROTATION_START_ANGLE.ToString(), data)
        End Function
        'FIXTURE_ROTATION_END_ANGLE
        Public Shared Function Fixture_Rotation_End_Angle(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Fixture_Rotation_End_Angle")
            AVPLib.Log.coreLogger.Info("Leave Fixture_Rotation_End_Angle")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.FIXTURE_ROTATION_END_ANGLE.ToString(), data)
        End Function
        'FIXTURE_ROTATION_DWELL_TIME
        Public Shared Function Fixture_Rotation_Dwell_Time(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Fixture_Rotation_Dwell_Time")
            AVPLib.Log.coreLogger.Info("Leave Fixture_Rotation_Dwell_Time")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.FIXTURE_ROTATION_DWELL_TIME.ToString(), data)
        End Function
        'FIXTURE_TILT_ANGLE
        Public Shared Function Fixture_Tilt_Angle(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Fixture_Tilt_Angle")
            AVPLib.Log.coreLogger.Info("Leave Fixture_Tilt_Angle")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.FIXTURE_TILT_ANGLE.ToString(), data)
        End Function
        'FLOWCOOL_MFC_SHUTOFF_VALVE
        Public Shared Function Flowcool_Mfc_Shutoff_Valve(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Flowcool_Mfc_Shutoff_Valve")
            AVPLib.Log.coreLogger.Info("Leave Flowcool_Mfc_Shutoff_Valve")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.FLOWCOOL_MFC_SHUTOFF_VALVE.ToString(), data)
        End Function
        'FLOWCOOL_MFC_SUPPLY_VALVE
        Public Shared Function Flowcool_Mfc_Supply_Valve(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Flowcool_Mfc_Supply_Valve")
            AVPLib.Log.coreLogger.Info("Leave Flowcool_Mfc_Supply_Valve")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.FLOWCOOL_MFC_SUPPLY_VALVE.ToString(), data)
        End Function
        'FLOWCOOL_MFC_TARGET_FLOWRATE
        Public Shared Function Flowcool_Mfc_Target_Flowrate(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Flowcool_Mfc_Target_Flowrate")
            AVPLib.Log.coreLogger.Info("Leave Flowcool_Mfc_Target_Flowrate")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.FLOWCOOL_MFC_TARGET_FLOWRATE.ToString(), data)
        End Function
        'FLOWCOOL_MFC_ACTUAL_FLOWRATE
        Public Shared Function Flowcool_Mfc_Actual_Flowrate(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Flowcool_Mfc_Actual_Flowrate")
            AVPLib.Log.coreLogger.Info("Leave Flowcool_Mfc_Actual_Flowrate")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.FLOWCOOL_MFC_ACTUAL_FLOWRATE.ToString(), data)
        End Function
        'FLOWCOOL_PRESSURE
        Public Shared Function Flowcool_Pressure(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Flowcool_Pressure")
            AVPLib.Log.coreLogger.Info("Leave Flowcool_Pressure")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.FLOWCOOL_PRESSURE.ToString(), data)
        End Function
        'WAFER_IN_FIXTURE
        Public Shared Function Wafer_In_Fixture(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Wafer_In_Fixture")
            AVPLib.Log.coreLogger.Info("Leave Wafer_In_Fixture")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.WAFER_IN_FIXTURE.ToString(), data)
        End Function
        'INITIALIZE_MOTION
        Public Shared Function Initialize_Motion(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Initialize_Motion")
            AVPLib.Log.coreLogger.Info("Leave Initialize_Motion")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.INITIALIZING_MOTION.ToString(), data)
        End Function
        'MOTION_TO_SERVICE_POSITION
        Public Shared Function Motion_To_Service_Position(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Motion_To_Service_Position")
            AVPLib.Log.coreLogger.Info("Leave Motion_To_Service_Position")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.MOTION_TO_SERVICE_POSITION.ToString(), data)
        End Function
        'MAGNETIC_CHUCK_POWER
        Public Shared Function Magnetic_Chuck_Power(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Magnetic_Chuck_Power")
            AVPLib.Log.coreLogger.Info("Leave Magnetic_Chuck_Power")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.MAGNETIC_CHUCK_POWER.ToString(), data)
        End Function
        'MAGNETIC_CHUCK_PHASE
        Public Shared Function Magnetic_Chuck_Phase(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Magnetic_Chuck_Phase")
            AVPLib.Log.coreLogger.Info("Leave Magnetic_Chuck_Phase")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.MAGNETIC_CHUCK_PHASE.ToString(), data)
        End Function
        'MAGNETIC_CHUCK_AMPLITUDE
        Public Shared Function Magnetic_Chuck_Amplitude(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Magnetic_Chuck_Amplitude")
            AVPLib.Log.coreLogger.Info("Leave Magnetic_Chuck_Amplitude")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.MAGNETIC_CHUCK_AMPLITUDE.ToString(), data)
        End Function
        'MAGNETIC_CHUCK_FREQUENCY
        Public Shared Function Magnetic_Chuck_Frequency(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Magnetic_Chuck_Frequency")
            AVPLib.Log.coreLogger.Info("Leave Magnetic_Chuck_Frequency")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.MAGNETIC_CHUCK_FREQUENCY.ToString(), data)
        End Function
        'MAGNETIC_CHUCK_WAVE_TYPE
        Public Shared Function Magnetic_Chuck_Wave_Type(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Magnetic_Chuck_Wave_Type")
            AVPLib.Log.coreLogger.Info("Leave Magnetic_Chuck_Wave_Type")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.MAGNETIC_CHUCK_WAVE_TYPE.ToString(), data)
        End Function
        'HOT_CHUCK_POWER
        Public Shared Function Hot_Chuck_Power(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Hot_Chuck_Power")
            AVPLib.Log.coreLogger.Info("Leave Hot_Chuck_Power")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.HOT_CHUCK_POWER.ToString(), data)
        End Function
        'HOT_CHUCK_GET_TEMPERATURE
        Public Shared Function Hot_Chuck_Get_Temperature(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Hot_Chuck_Get_Temperature")
            AVPLib.Log.coreLogger.Info("Leave Hot_Chuck_Get_Temperature")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.HOT_CHUCK_GET_TEMPERATURE.ToString(), data)
        End Function
        'HOT_CHUCK_SET_TEMPERATURE
        Public Shared Function Hot_Chuck_Set_Temperature(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Hot_Chuck_Set_Temperature")
            AVPLib.Log.coreLogger.Info("Leave Hot_Chuck_Set_Temperature")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.HOT_CHUCK_SET_TEMPERATURE.ToString(), data)
        End Function
        'STATIC_COOLING_EXHAUST_VALVE
        Public Shared Function Static_Cooling_Exhaust_Valve(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Static_Cooling_Exhaust_Valve")
            AVPLib.Log.coreLogger.Info("Leave Static_Cooling_Exhaust_Valve")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.STATIC_COOLING_EXHAUST_VALVE.ToString(), data)
        End Function
        'STATIC_COOLING_SUPPLY_VALVE
        Public Shared Function Static_Cooling_Supply_Valve(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Static_Cooling_Supply_Valve")
            AVPLib.Log.coreLogger.Info("Leave Static_Cooling_Supply_Valve")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.STATIC_COOLING_SUPPLY_VALVE.ToString(), data)
        End Function
        'STATIC_COOLING_TARGET_FLOW
        Public Shared Function Static_Cooling_Target_Flow(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Static_Cooling_Target_Flow")
            AVPLib.Log.coreLogger.Info("Leave Static_Cooling_Target_Flow")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.STATIC_COOLING_TARGET_FLOW.ToString(), data)
        End Function
        'STATIC_COOLING_ACTUAL_FLOW
        Public Shared Function Static_Cooling_Actual_Flow(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Static_Cooling_Actual_Flow")
            AVPLib.Log.coreLogger.Info("Leave Static_Cooling_Actual_Flow")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.STATIC_COOLING_ACTUAL_FLOW.ToString(), data)
        End Function
        'STATIC_COOLING_TARGET_PRESSURE
        Public Shared Function Static_Cooling_Target_Pressure(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Static_Cooling_Target_Pressure")
            AVPLib.Log.coreLogger.Info("Leave Static_Cooling_Target_Pressure")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.STATIC_COOLING_TARGET_PRESSURE.ToString(), data)
        End Function
        'STATIC_COOLING_ACTUAL_PRESSURE
        Public Shared Function Static_Cooling_Actual_Pressure(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Static_Cooling_Actual_Pressure")
            AVPLib.Log.coreLogger.Info("Leave Static_Cooling_Actual_Pressure")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.STATIC_COOLING_ACTUAL_PRESSURE.ToString(), data)
        End Function
        'STATIC_COOLING_GAS_OK
        Public Shared Function Static_Cooling_Gas_Ok(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Static_Cooling_Gas_Ok")
            AVPLib.Log.coreLogger.Info("Leave Static_Cooling_Gas_Ok")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.STATIC_COOLING_GAS_OK.ToString(), data)
        End Function
        'STATIC_COOLING_START
        Public Shared Function Static_Cooling_Start(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Static_Cooling_Start")
            AVPLib.Log.coreLogger.Info("Leave Static_Cooling_Start")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.STATIC_COOLING_START.ToString(), data)
        End Function
        'STATIC_COOLING_STOP
        Public Shared Function Static_Cooling_Stop(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Static_Cooling_Stop")
            AVPLib.Log.coreLogger.Info("Leave Static_Cooling_Stop")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.STATIC_COOLING_STOP.ToString(), data)
        End Function
        'TEC_POWER
        Public Shared Function Tec_Power(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Tec_Power")
            AVPLib.Log.coreLogger.Info("Leave Tec_Power")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.TEC_POWER.ToString(), data)
        End Function
        ''5,X,1,1,1 - Replace with 5,1,1,1,1
        'SHUTTER_POSITION
        Public Shared Function Shutter_Position(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Shutter_Position")
            AVPLib.Log.coreLogger.Info("Leave Shutter_Position")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.SHUTTER_POSITION.ToString(), data)
        End Function
        'SOURCE_AC_POWER
        Public Shared Function Source_Ac_Power(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Source_Ac_Power")
            AVPLib.Log.coreLogger.Info("Leave Source_Ac_Power")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.SOURCE_AC_POWER.ToString(), data)
        End Function
        'SOURCE_RF_POWER
        Public Shared Function Source_Rf_Power(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Source_Rf_Power")
            AVPLib.Log.coreLogger.Info("Leave Source_Rf_Power")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.SOURCE_RF_POWER.ToString(), data)
        End Function
        'SOURCE_GRID_POWER
        Public Shared Function Source_Grid_Power(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Source_Grid_Power")
            AVPLib.Log.coreLogger.Info("Leave Source_Grid_Power")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.SOURCE_GRID_POWER.ToString(), data)
        End Function
        'SOURCE_PBN_POWER
        Public Shared Function Source_Pbn_Power(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Source_Pbn_Power")
            AVPLib.Log.coreLogger.Info("Leave Source_Pbn_Power")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.SOURCE_PBN_POWER.ToString(), data)
        End Function
        'SOURCE_NEUR_POWER
        Public Shared Function Source_Neur_Power(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Source_Pbn_Power")
            AVPLib.Log.coreLogger.Info("Leave Source_Pbn_Power")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.SOURCE_NEUR_POWER.ToString(), data)
        End Function
        'AUTO_MANUAL
        Public Shared Function Auto_Manual(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Auto_Manual")
            AVPLib.Log.coreLogger.Info("Leave Auto_Manual")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.AUTO_MANUAL.ToString(), data)
        End Function
        'ELECTRONIC_SHUTTER
        Public Shared Function Electronic_Shutter(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Electronic_Shutter")
            AVPLib.Log.coreLogger.Info("Leave Electronic_Shutter")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.ELECTRONIC_SHUTTER.ToString(), data)
        End Function
        'PBN_GAS_SHUTOFF_VALVE
        Public Shared Function Pbn_Gas_Shutoff_Valve(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Pbn_Gas_Shutoff_Valve")
            AVPLib.Log.coreLogger.Info("Leave Pbn_Gas_Shutoff_Valve")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.PBN_GAS_SHUTOFF_VALVE.ToString(), data)
        End Function
        'PBN_GAS_SUPPLY_VALVE
        Public Shared Function Pbn_Gas_Supply_Valve(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Pbn_Gas_Supply_Valve")
            AVPLib.Log.coreLogger.Info("Leave Pbn_Gas_Supply_Valve")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.PBN_GAS_SUPPLY_VALVE.ToString(), data)
        End Function
        'PBN_GAS_FLOWRATE
        'Public Shared Function Pbn_Gas_Flowrate(ByVal chamberName As String, ByVal data As String) As Boolean
        '    AVPLib.Log.coreLogger.Info("Enter Pbn_Gas_Flowrate")
        '    AVPLib.Log.coreLogger.Info("Leave Pbn_Gas_Flowrate")
        '    Return SendCommandWithDataToIBE(chamberName, IBECommands.PBN_GAS_FLOWRATE.ToString(), data)
        'End Function
        'PBN_GAS_FLOWRATE_ERROR_TOL
        Public Shared Function Pbn_Gas_Flowrate_Error_Tol(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Pbn_Gas_Flowrate_Error_Tol")
            AVPLib.Log.coreLogger.Info("Leave Pbn_Gas_Flowrate_Error_Tol")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.PBN_GAS_FLOWRATE_ERROR_TOL.ToString(), data)
        End Function
        'PBN_GAS_FLOWRATE_WARNING_TOL
        Public Shared Function Pbn_Gas_Flowrate_Warning_Tol(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Pbn_Gas_Flowrate_Warning_Tol")
            AVPLib.Log.coreLogger.Info("Leave Pbn_Gas_Flowrate_Warning_Tol")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.PBN_GAS_FLOWRATE_WARNING_TOL.ToString(), data)
        End Function
        'PBN_GAS_FLOWRATE_ERROR_TIME
        Public Shared Function Pbn_Gas_Flowrate_Error_Time(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Pbn_Gas_Flowrate_Error_Time")
            AVPLib.Log.coreLogger.Info("Leave Pbn_Gas_Flowrate_Error_Time")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.PBN_GAS_FLOWRATE_ERROR_TIME.ToString(), data)
        End Function
        'PBN_GAS_FLOWRATE_WARNING_TIME
        Public Shared Function Pbn_Gas_Flowrate_Warning_Time(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Pbn_Gas_Flowrate_Warning_Time")
            AVPLib.Log.coreLogger.Info("Leave Pbn_Gas_Flowrate_Warning_Time")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.PBN_GAS_FLOWRATE_WARNING_TIME.ToString(), data)
        End Function
        'N2_PURGE
        Public Shared Function N2_Purge(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter N2_Purge")
            AVPLib.Log.coreLogger.Info("Leave N2_Purge")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.N2_PURGE.ToString(), data)
        End Function
        'DIVERTER_VALVE
        Public Shared Function Diverter_Valve(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Diverter_Valve")
            AVPLib.Log.coreLogger.Info("Leave Diverter_Valve")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.DIVERTER_VALVE.ToString(), data)
        End Function
        'BEAM_VOLTAGE_PROGRAM
        Public Shared Function Beam_Voltage_Program(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Beam_Voltage_Program")
            AVPLib.Log.coreLogger.Info("Leave Beam_Voltage_Program")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.BEAM_VOLTAGE_PROGRAM.ToString(), data)
        End Function
        'BEAM_VOLTAGE_READBACK
        Public Shared Function Beam_Voltage_Readback(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Beam_Voltage_Readback")
            AVPLib.Log.coreLogger.Info("Leave Beam_Voltage_Readback")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.BEAM_VOLTAGE_READBACK.ToString(), data)
        End Function
        'BEAM_VOLTAGE_ERROR_TOL
        Public Shared Function Beam_Voltage_Error_Tol(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Beam_Voltage_Error_Tol")
            AVPLib.Log.coreLogger.Info("Leave Beam_Voltage_Error_Tol")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.BEAM_VOLTAGE_ERROR_TOL.ToString(), data)
        End Function
        'BEAM_VOLTAGE_WARNING_TOL
        Public Shared Function Beam_Voltage_Warning_Tol(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Beam_Voltage_Warning_Tol")
            AVPLib.Log.coreLogger.Info("Leave Beam_Voltage_Warning_Tol")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.BEAM_VOLTAGE_WARNING_TOL.ToString(), data)
        End Function
        'BEAM_VOLTAGE_ERROR_TIME
        Public Shared Function Beam_Voltage_Error_Time(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Beam_Voltage_Error_Time")
            AVPLib.Log.coreLogger.Info("Leave Beam_Voltage_Error_Time")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.BEAM_VOLTAGE_ERROR_TIME.ToString(), data)
        End Function
        'BEAM_VOLTAGE_WARNING_TIME
        Public Shared Function Beam_Voltage_Warning_Time(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Beam_Voltage_Warning_Time")
            AVPLib.Log.coreLogger.Info("Leave Beam_Voltage_Warning_Time")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.BEAM_VOLTAGE_WARNING_TIME.ToString(), data)
        End Function
        'BEAM_CURRENT_PROGRAM
        Public Shared Function Beam_Current_Program(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Beam_Current_Program")
            AVPLib.Log.coreLogger.Info("Leave Beam_Current_Program")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.BEAM_CURRENT_PROGRAM.ToString(), data)
        End Function
        'BEAM_CURRENT_READBACK
        Public Shared Function Beam_Current_Readback(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Beam_Current_Readback")
            AVPLib.Log.coreLogger.Info("Leave Beam_Current_Readback")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.BEAM_CURRENT_READBACK.ToString(), data)
        End Function
        'BEAM_CURRENT_ERROR_TOL
        Public Shared Function Beam_Current_Error_Tol(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Beam_Current_Error_Tol")
            AVPLib.Log.coreLogger.Info("Leave Beam_Current_Error_Tol")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.BEAM_CURRENT_ERROR_TOL.ToString(), data)
        End Function
        'BEAM_CURRENT_WARNING_TOL
        Public Shared Function Beam_Current_Warning_Tol(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Beam_Current_Warning_Tol")
            AVPLib.Log.coreLogger.Info("Leave Beam_Current_Warning_Tol")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.BEAM_CURRENT_WARNING_TOL.ToString(), data)
        End Function
        'BEAM_CURRENT_ERROR_TIME
        Public Shared Function Beam_Current_Error_Time(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Beam_Current_Error_Time")
            AVPLib.Log.coreLogger.Info("Leave Beam_Current_Error_Time")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.BEAM_CURRENT_ERROR_TIME.ToString(), data)
        End Function
        'BEAM_CURRENT_WARNING_TIME
        Public Shared Function Beam_Current_Warning_Time(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Beam_Current_Warning_Time")
            AVPLib.Log.coreLogger.Info("Leave Beam_Current_Warning_Time")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.BEAM_CURRENT_WARNING_TIME.ToString(), data)
        End Function
        'SUPP_VOLTAGE_PROGRAM
        Public Shared Function Supp_Voltage_Program(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Supp_Voltage_Program")
            AVPLib.Log.coreLogger.Info("Leave Supp_Voltage_Program")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.SUPP_VOLTAGE_PROGRAM.ToString(), data)
        End Function
        'SUPP_CURRENT_PROGRAM
        Public Shared Function Supp_Current_Program(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Supp_Current_Program")
            AVPLib.Log.coreLogger.Info("Leave Supp_Current_Program")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.SUPP_CURRENT_PROGRAM.ToString(), data)
        End Function
        'SUPP_VOLTAGE_READBACK
        Public Shared Function Supp_Voltage_Readback(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Supp_Voltage_Readback")
            AVPLib.Log.coreLogger.Info("Leave Supp_Voltage_Readback")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.SUPP_VOLTAGE_READBACK.ToString(), data)
        End Function
        'SUPP_CURRENT_READBACK
        Public Shared Function Supp_Current_Readback(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Supp_Current_Readback")
            AVPLib.Log.coreLogger.Info("Leave Supp_Current_Readback")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.SUPP_CURRENT_READBACK.ToString(), data)
        End Function
        'SUPP_VOLTAGE_ERROR_TOL
        Public Shared Function Supp_Voltage_Error_Tol(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Supp_Voltage_Error_Tol")
            AVPLib.Log.coreLogger.Info("Leave Supp_Voltage_Error_Tol")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.SUPP_VOLTAGE_ERROR_TOL.ToString(), data)
        End Function
        'SUPP_VOLTAGE_WARNING_TOL
        Public Shared Function Supp_Voltage_Warning_Tol(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Supp_Voltage_Warning_Tol")
            AVPLib.Log.coreLogger.Info("Leave Supp_Voltage_Warning_Tol")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.SUPP_VOLTAGE_WARNING_TOL.ToString(), data)
        End Function
        'SUPP_VOLTAGE_ERROR_TIME
        Public Shared Function Supp_Voltage_Error_Time(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Supp_Voltage_Error_Time")
            AVPLib.Log.coreLogger.Info("Leave Supp_Voltage_Error_Time")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.SUPP_VOLTAGE_ERROR_TIME.ToString(), data)
        End Function
        'SUPP_VOLTAGE_WARNING_TIME
        Public Shared Function Supp_Voltage_Warning_Time(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Supp_Voltage_Warning_Time")
            AVPLib.Log.coreLogger.Info("Leave Supp_Voltage_Warning_Time")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.SUPP_VOLTAGE_WARNING_TIME.ToString(), data)
        End Function
        'AUTO_BEAM
        Public Shared Function Auto_Beam(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Auto_Beam")
            AVPLib.Log.coreLogger.Info("Leave Auto_Beam")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.AUTO_BEAM.ToString(), data)
        End Function
        'PBN_BODY_CURRENT_READBACK
        Public Shared Function Pbn_Body_Current_Readback(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Pbn_Body_Current_Readback")
            AVPLib.Log.coreLogger.Info("Leave Pbn_Body_Current_Readback")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.PBN_BODY_CURRENT_READBACK.ToString(), data)
        End Function
        'PBN_BODY_CURRENT_ERROR_TOL
        Public Shared Function Pbn_Body_Current_Error_Tol(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Pbn_Body_Current_Error_Tol")
            AVPLib.Log.coreLogger.Info("Leave Pbn_Body_Current_Error_Tol")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.PBN_BODY_CURRENT_ERROR_TOL.ToString(), data)
        End Function
        'PBN_BODY_CURRENT_WARNING_TOL
        Public Shared Function Pbn_Body_Current_Warning_Tol(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Pbn_Body_Current_Warning_Tol")
            AVPLib.Log.coreLogger.Info("Leave Pbn_Body_Current_Warning_Tol")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.PBN_BODY_CURRENT_WARNING_TOL.ToString(), data)
        End Function
        'PBN_BODY_CURRENT_ERROR_TIME
        Public Shared Function Pbn_Body_Current_Error_Time(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Pbn_Body_Current_Error_Time")
            AVPLib.Log.coreLogger.Info("Leave Pbn_Body_Current_Error_Time")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.PBN_BODY_CURRENT_ERROR_TIME.ToString(), data)
        End Function
        'PBN_BODY_CURRENT_WARNING_TIME
        Public Shared Function Pbn_Body_Current_Warning_Time(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Pbn_Body_Current_Warning_Time")
            AVPLib.Log.coreLogger.Info("Leave Pbn_Body_Current_Warning_Time")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.PBN_BODY_CURRENT_WARNING_TIME.ToString(), data)
        End Function
        'PBN_FILAMENT_CURRENT_READBACK
        Public Shared Function Pbn_Filament_Current_Readback(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Pbn_Filament_Current_Readback")
            AVPLib.Log.coreLogger.Info("Leave Pbn_Filament_Current_Readback")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.PBN_FILAMENT_CURRENT_READBACK.ToString(), data)
        End Function
        'K_FACTOR_PROGRAM
        Public Shared Function K_Factor_Program(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter K_Factor_Program")
            AVPLib.Log.coreLogger.Info("Leave K_Factor_Program")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.K_FACTOR_PROGRAM.ToString(), data)
        End Function
        'K_FACTOR_READBACK
        Public Shared Function K_Factor_Readback(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter K_Factor_Readback")
            AVPLib.Log.coreLogger.Info("Leave K_Factor_Readback")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.K_FACTOR_READBACK.ToString(), data)
        End Function
        'INCIDENT_RF_PROGRAM
        Public Shared Function Incident_Rf_Program(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Incident_Rf_Program")
            AVPLib.Log.coreLogger.Info("Leave Incident_Rf_Program")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.INCIDENT_RF_PROGRAM.ToString(), data)
        End Function
        'FORWARD_RF_READBACK
        Public Shared Function Forward_Rf_Readback(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Forward_Rf_Readback")
            AVPLib.Log.coreLogger.Info("Leave Forward_Rf_Readback")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.FORWARD_RF_READBACK.ToString(), data)
        End Function
        'REFLECTED_RF_PROGRAM
        Public Shared Function Reflected_Rf_Program(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Reflected_Rf_Program")
            AVPLib.Log.coreLogger.Info("Leave Reflected_Rf_Program")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.REFLECTED_RF_PROGRAM.ToString(), data)
        End Function
        'REFLECTED_RF_READBACK
        Public Shared Function Reflected_Rf_Readback(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Reflected_Rf_Readback")
            AVPLib.Log.coreLogger.Info("Leave Reflected_Rf_Readback")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.REFLECTED_RF_READBACK.ToString(), data)
        End Function
        ''Process control
        'PROCESS_CONTROL
        Public Shared Function Process_Control(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Process_Control")
            AVPLib.Log.coreLogger.Info("Leave Process_Control")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.PROCESS_CONTROL.ToString(), data)
        End Function
        'PROCESS_CONTROL_NAME
        Public Shared Function Process_Control_Name(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Process_Control_Name")
            AVPLib.Log.coreLogger.Info("Leave Process_Control_Name")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.PROCESS_CONTROL_NAME.ToString(), data)
        End Function
        'PROCESS_CURRENT_STEP
        Public Shared Function Process_Current_Step(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Process_Current_Step")
            AVPLib.Log.coreLogger.Info("Leave Process_Current_Step")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.PROCESS_CURRENT_STEP.ToString(), data)
        End Function
        'PROCESS_TOTAL_STEPS
        Public Shared Function Process_Total_Steps(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Process_Total_Steps")
            AVPLib.Log.coreLogger.Info("Leave Process_Total_Steps")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.PROCESS_TOTAL_STEPS.ToString(), data)
        End Function
        'PROCESS_ELAPSED_TIME
        Public Shared Function Process_Elapsed_Time(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Process_Elapsed_Time")
            AVPLib.Log.coreLogger.Info("Leave Process_Elapsed_Time")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.PROCESS_ELAPSED_TIME.ToString(), data)
        End Function
        'PROCESS_REMAINING_TIME
        Public Shared Function Process_Remaining_Time(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Process_Remaining_Time")
            AVPLib.Log.coreLogger.Info("Leave Process_Remaining_Time")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.PROCESS_REMAINING_TIME.ToString(), data)
        End Function
        'PROCESS_ABORT_MESSAGE
        Public Shared Function Process_Abort_Message(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Process_Abort_Message")
            AVPLib.Log.coreLogger.Info("Leave Process_Abort_Message")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.PROCESS_ABORT_MESSAGE.ToString(), data)
        End Function
        'PROCESS_LOT_ID
        Public Shared Function Process_Lot_ID(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Process_Lot_ID")
            AVPLib.Log.coreLogger.Info("Leave Process_Lot_ID")
            Return SendCommandWithDataToIBEWithEmptyData(chamberName, IBECommands.PROCESS_LOT_ID.ToString(), data)
        End Function
        'PROCESS_CASSETTE_ID
        Public Shared Function Process_Cassette_ID(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Process_Cassette_ID")
            AVPLib.Log.coreLogger.Info("Leave Process_Cassette_ID")
            Return SendCommandWithDataToIBEWithEmptyData(chamberName, IBECommands.PROCESS_CASSETTE_ID.ToString(), data)
        End Function
        'PROCESS_WAFER_ID
        Public Shared Function Process_Wafer_ID(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Process_Wafer_ID")
            AVPLib.Log.coreLogger.Info("Leave Process_Wafer_ID")
            Return SendCommandWithDataToIBEWithEmptyData(chamberName, IBECommands.PROCESS_WAFER_ID.ToString(), data)
        End Function
        'PROCESS_MODIFY_STEPTIME
        Public Shared Function Process_Modify_Steptime(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Process_Modify_Steptime")
            AVPLib.Log.coreLogger.Info("Leave Process_Modify_Steptime")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.PROCESS_MODIFY_STEPTIME.ToString(), data)
        End Function
        'PROCESS_STEPTIME_TIMEOUT
        Public Shared Function Process_Steptime_Timeout(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Process_Steptime_Timeout")
            AVPLib.Log.coreLogger.Info("Leave Process_Steptime_Timeout")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.PROCESS_STEPTIME_TIMEOUT.ToString(), data)
        End Function
        'PROCESS_GEM_WAITFOR_STEPTIME
        Public Shared Function Process_Gem_Waitfor_Steptime(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Process_Gem_Waitfor_Steptime")
            AVPLib.Log.coreLogger.Info("Leave Process_Gem_Waitfor_Steptime")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.PROCESS_GEM_WAITFOR_STEPTIME.ToString(), data)
        End Function
        'GAS_OK
        Public Shared Function Gas_Ok(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Gas_Ok")
            AVPLib.Log.coreLogger.Info("Leave Gas_Ok")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.GAS_OK.ToString(), data)
        End Function
        'BEAM_OK
        Public Shared Function Beam_Ok(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Beam_Ok")
            AVPLib.Log.coreLogger.Info("Leave Beam_Ok")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.BEAM_OK.ToString(), data)
        End Function
        'PBN_OK
        Public Shared Function Pbn_Ok(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Pbn_Ok")
            AVPLib.Log.coreLogger.Info("Leave Pbn_Ok")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.PBN_OK.ToString(), data)
        End Function
        'ELECTROSTATIC_SHUTTER_BYPASS
        Public Shared Function Electrostatic_Shutter_Bypass(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Electrostatic_Shutter_Bypass")
            AVPLib.Log.coreLogger.Info("Leave Electrostatic_Shutter_Bypass")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.ELECTROSTATIC_SHUTTER_BYPASS.ToString(), data)
        End Function
        'ELECTROSTATIC_SHUTTER_TIMER
        Public Shared Function Electrostatic_Shutter_Timer(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Electrostatic_Shutter_Timer")
            AVPLib.Log.coreLogger.Info("Leave Electrostatic_Shutter_Timer")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.ELECTROSTATIC_SHUTTER_TIMER.ToString(), data)
        End Function
        'WAFER_ABORT_STATUS
        Public Shared Function Wafer_Abort_Status(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Wafer_Abort_Status")
            AVPLib.Log.coreLogger.Info("Leave Wafer_Abort_Status")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.WAFER_ABORT_STATUS.ToString(), data)
        End Function
        'MAX_SUPP_CURRENT
        Public Shared Function Max_Supp_Current(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Max_Supp_Current")
            AVPLib.Log.coreLogger.Info("Leave Max_Supp_Current")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.MAX_SUPP_CURRENT.ToString(), data)
        End Function
        'MAX_REF_RF
        Public Shared Function Max_Ref_Rf(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Max_Ref_Rf")
            AVPLib.Log.coreLogger.Info("Leave Max_Ref_Rf")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.MAX_REF_RF.ToString(), data)
        End Function
        'MIN_PBN_CURRENT
        Public Shared Function Min_Pbn_Current(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Min_Pbn_Current")
            AVPLib.Log.coreLogger.Info("Leave Min_Pbn_Current")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.MIN_PBN_CURRENT.ToString(), data)
        End Function
        'MAX_PBN_CURRENT
        Public Shared Function Max_Pbn_Current(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Max_Pbn_Current")
            AVPLib.Log.coreLogger.Info("Leave Max_Pbn_Current")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.MAX_PBN_CURRENT.ToString(), data)
        End Function
        'SOURCE_USAGE_RESET
        Public Shared Function Source_Usage_Reset(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Source_Usage_Reset")
            AVPLib.Log.coreLogger.Info("Leave Source_Usage_Reset")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.SOURCE_USAGE_RESET.ToString(), data)
        End Function
        'SOURCE_GRID_ID
        Public Shared Function Source_Grid_ID(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Source_Grid_ID")
            AVPLib.Log.coreLogger.Info("Leave Source_Grid_ID")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.SOURCE_GRID_ID.ToString(), data)
        End Function
        'SOURCE_USAGE_TIMESET
        Public Shared Function Source_Usage_Timeset(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Source_Usage_Timeset")
            AVPLib.Log.coreLogger.Info("Leave Source_Usage_Timeset")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.SOURCE_USAGE_TIMESET.ToString(), data)
        End Function
        'SOURCE_MAGNET_MODE
        Public Shared Function Source_Magnet_Mode(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Source_Magnet_Mode")
            AVPLib.Log.coreLogger.Info("Leave Source_Magnet_Mode")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.SOURCE_MAGNET_MODE.ToString(), data)
        End Function
        'SOURCE_MAGNET_SPEED
        Public Shared Function Source_Magnet_Speed(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Source_Magnet_Speed")
            AVPLib.Log.coreLogger.Info("Leave Source_Magnet_Speed")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.SOURCE_MAGNET_SPEED.ToString(), data)
        End Function
        'GAS_SUPPLY_VALVE_O
        Public Shared Function Gas_Supply_PBN_Valve(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Gas_Supply_Oxygen_Valve")
            AVPLib.Log.coreLogger.Info("Leave Gas_Supply_Oxygen_Valve")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.PBN_GAS_SUPPLY_VALVE.ToString(), data)
        End Function
        'GAS_SHUTOFF_VALVE
        Public Shared Function Gas_Shutoff_PBN_Valve(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Gas_Shutoff_Valve")
            AVPLib.Log.coreLogger.Info("Leave Gas_Shutoff_Valve")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.PBN_GAS_SHUTOFF_VALVE.ToString(), data)
        End Function
        'GAS_TARGET_FLOWRATE
        Public Shared Function Gas_Target_PBN_Flowrate(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Gas_Target_Flowrate")
            AVPLib.Log.coreLogger.Info("Leave Gas_Target_Flowrate")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.PBN_GAS_FLOWRATE_PROGRAM.ToString(), data)
        End Function
        'GAS_TARGET_FLOWRATE
        Public Shared Function Gas_Target_Argon_Flowrate(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Gas_Target_Flowrate")
            AVPLib.Log.coreLogger.Info("Leave Gas_Target_Flowrate")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.GAS_TARGET_FLOWRATE_A_PROGRAM.ToString(), data)
        End Function
        'GAS_ACTUAL_FLOWRATE
        Public Shared Function Gas_Actual_PBN_Flowrate(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Gas_Actual_Flowrate")
            AVPLib.Log.coreLogger.Info("Leave Gas_Actual_Flowrate")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.PBN_GAS_FLOWRATE_READBACK.ToString(), data)
        End Function
        Public Shared Function Gas_Actual_Argon_Flowrate(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Gas_Actual_Flowrate")
            AVPLib.Log.coreLogger.Info("Leave Gas_Actual_Flowrate")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.GAS_ACTUAL_FLOWRATE_A_READBACK.ToString(), data)
        End Function
        'GAS_TYPE
        Public Shared Function Gas_Type(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Gas_Type")
            AVPLib.Log.coreLogger.Info("Leave Gas_Type")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.GAS_TYPE.ToString(), data)
        End Function
        'GAS_MFC_MAX_RANGE
        Public Shared Function Gas_Mfc_Max_Range(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Gas_Mfc_Max_Range")
            AVPLib.Log.coreLogger.Info("Leave Gas_Mfc_Max_Range")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.GAS_MFC_MAX_RANGE.ToString(), data)
        End Function
        'GAS_FLOWRATE_ERROR_TOL
        Public Shared Function Gas_Flowrate_Error_Tol(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Gas_Flowrate_Error_Tol")
            AVPLib.Log.coreLogger.Info("Leave Gas_Flowrate_Error_Tol")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.GAS_FLOWRATE_ERROR_TOL.ToString(), data)
        End Function
        'GAS_FLOWRATE_WARNING_TOL
        Public Shared Function Gas_Flowrate_Warning_Tol(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Gas_Flowrate_Warning_Tol")
            AVPLib.Log.coreLogger.Info("Leave Gas_Flowrate_Warning_Tol")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.GAS_FLOWRATE_WARNING_TOL.ToString(), data)
        End Function
        'GAS_FLOWRATE_ERROR_TIME
        Public Shared Function Gas_Flowrate_Error_Time(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Gas_Flowrate_Error_Time")
            AVPLib.Log.coreLogger.Info("Leave Gas_Flowrate_Error_Time")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.GAS_FLOWRATE_ERROR_TIME.ToString(), data)
        End Function
        'GAS_FLOWRATE_WARNING_TIME
        Public Shared Function Gas_Flowrate_Warning_Time(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Gas_Flowrate_Warning_Time")
            AVPLib.Log.coreLogger.Info("Leave Gas_Flowrate_Warning_Time")
            Return SendCommandWithDataToIBE(chamberName, IBECommands.GAS_FLOWRATE_WARNING_TIME.ToString(), data)
        End Function

#Region "Diagnostic Dialog"
        Public Shared Function Stop_PumpDown_Curve(ByVal strChamber As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Stop_PumpDown_Curve")
            AVPLib.Log.coreLogger.Info("Leave Stop_PumpDown_Curve")
            Return AVPLib.Business.IBEUtility.SendCommandWithDataToIBE _
                   (strChamber, AVPLib.Business.IBECommands.PUMPDOWN_CURVE_STATUS.ToString(), _
                     AVPLib.ConfigurationValues.DEVICE_STATUS_CLOSED)
        End Function

        Public Shared Function Start_PumpDown_Curve(ByVal strChamber As String, ByVal strSampleTime As String, ByVal strTotalTime As String, ByVal strDescription As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Start_PumpDown_Curve")
            Dim IsPMIsoValveClose As Boolean = Utils.IsChamberSlitValveClose(strChamber)
            If IBEUtility.SendCommandWithDataToIBE(strChamber, _
                                                    IBECommands.SPLITVALVE_STATUS.ToString(), _
                                                    IIf(IsPMIsoValveClose, ConfigurationValues.DEVICE_STATUS_CLOSED, _
                                                        ConfigurationValues.DEVICE_STATUS_OPEN)) Then
                If AVPLib.Business.IBEUtility.SendCommandWithDataToIBE _
                  (strChamber, AVPLib.Business.IBECommands.PUMPDOWN_CURVE_INTERVAL_RECORDING.ToString(), _
                   "Interval=" & strSampleTime & "#Period=" & strTotalTime & _
                   "#Desc=" & strDescription & "#") Then
                    Return AVPLib.Business.IBEUtility.SendCommandWithDataToIBE _
                        (strChamber, AVPLib.Business.IBECommands.PUMPDOWN_CURVE_STATUS.ToString(), _
                         AVPLib.ConfigurationValues.DEVICE_STATUS_OPEN)
                End If
            End If
            AVPLib.Log.coreLogger.Info("Leave Start_PumpDown_Curve")
            Return False
        End Function

        Public Shared Function Start_Rate_Of_Rise(ByVal strChamber As String, ByVal strSampleTime As String, ByVal strTotalTime As String, ByVal strDescription As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Start_Rate_Of_Rise")
            Dim IsPMIsoValveClose As Boolean = Utils.IsChamberSlitValveClose(strChamber)
            If IBEUtility.SendCommandWithDataToIBE(strChamber, _
                                                    IBECommands.SPLITVALVE_STATUS.ToString(), _
                                                    IIf(IsPMIsoValveClose, ConfigurationValues.DEVICE_STATUS_CLOSED, _
                                                        ConfigurationValues.DEVICE_STATUS_OPEN)) Then
                If AVPLib.Business.IBEUtility.SendCommandWithDataToIBE _
                      (strChamber, AVPLib.Business.IBECommands.RATE_OF_RISE_INTERVAL_RECORDING.ToString(), _
                       "Interval=" & strSampleTime & "#Period=" & strTotalTime & _
                       "#Desc=" & strDescription & "#") Then
                    Return AVPLib.Business.IBEUtility.SendCommandWithDataToIBE _
                        (strChamber, AVPLib.Business.IBECommands.RATE_OF_RISE_STATUS.ToString(), _
                         AVPLib.ConfigurationValues.DEVICE_STATUS_OPEN)
                End If
            End If
            AVPLib.Log.coreLogger.Info("Leave Start_Rate_Of_Rise")
            Return False
        End Function

        Public Shared Function Stop_Rate_Of_Rise(ByVal strChamber As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Stop_Rate_Of_Rise")
            AVPLib.Log.coreLogger.Info("Leave Stop_Rate_Of_Rise")
            Return AVPLib.Business.IBEUtility.SendCommandWithDataToIBE _
                    (strChamber, AVPLib.Business.IBECommands.RATE_OF_RISE_STATUS.ToString(), _
                     AVPLib.ConfigurationValues.DEVICE_STATUS_CLOSED)
        End Function

#End Region

        Public Shared Function SendCommandWithDataToIBE(ByVal chamberName As String, ByVal commandName As String, ByVal commandData As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter SendCommandWithDataToIBE")
            Try
                Dim commandCode As String = ContainerData.GetIBECmdCode(commandName)
                Dim strChannel As String = "1" '''we will get channel in config file
                If Not String.IsNullOrEmpty(commandCode) Then
                    If Not String.IsNullOrEmpty(commandData) Then
                        commandCode = ConvertDataToIBE(strChannel, commandCode, commandData, commandName)
                    End If
                    AVPLib.Log.coreLogger.Info("Leave SendCommandWithDataToIBE")
                    'Begin Remove the channel from the command
                    Dim FoundMatch As Boolean = Regex.IsMatch(commandCode, ".*?,(.*)")
                    If (FoundMatch) Then
                        Dim mtcMatch As Match = Regex.Match(commandCode, ".*?,(.*)")
                        If mtcMatch.Groups.Count > 1 Then
                            commandCode = mtcMatch.Groups(1).Value
                        End If
                    End If
                    'End Remove the channel from the command
                    Return Utils.SendCommandPMServer(chamberName, commandCode)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave SendCommandWithDataToIBE")
            Return False
        End Function

        ''' <author>
        '''    	<name> Hoa Nguyen </name>
        '''    	<date> 2011-03-24</date>
        ''' </author>
        ''' <summary>
        ''' Send data to IBE, allow empty data. Use for Send LotID, CasstteID and Wafer ID
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function SendCommandWithDataToIBEWithEmptyData(ByVal chamberName As String, ByVal commandName As String, ByVal commandData As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter SendCommandWithDataToIBE")
            Try
                Dim commandCode As String = ContainerData.GetIBECmdCode(commandName)
                Dim strChannel As String = "1" '''we will get channel in config file
                If Not String.IsNullOrEmpty(commandCode) Then
                    commandCode = ConvertDataToIBE(strChannel, commandCode, commandData, commandName)
                    AVPLib.Log.coreLogger.Info("Leave SendCommandWithDataToIBE")
                    'Begin Remove the channel from the command
                    Dim FoundMatch As Boolean = Regex.IsMatch(commandCode, ".*?,(.*)")
                    If (FoundMatch) Then
                        Dim mtcMatch As Match = Regex.Match(commandCode, ".*?,(.*)")
                        If mtcMatch.Groups.Count > 1 Then
                            commandCode = mtcMatch.Groups(1).Value
                        End If
                    End If
                    'End Remove the channel from the command
                    Return Utils.SendCommandPMServer(chamberName, commandCode)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave SendCommandWithDataToIBE")
            Return False
        End Function

        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-09-04</date>
        ''' </author>
        ''' <summary>
        ''' Convert data to IBE pattern" 1,05,01,12,01,01,0.000E+000
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function ConvertDataToIBE(ByVal Channel As String, ByVal commandCode As String, ByVal commandData As String, ByVal commandName As String) As String
            AVPLib.Log.coreLogger.Info("Enter ConvertDataToIBE")
            Dim strResult As String = String.Empty
            Try
                strResult = commandCode
                If ContainerData.GetIBEDecoder(commandName) = "Double" Then
                    If commandName = IBECommands.FIXTURE_STATIC_ROTATION_ANGLE.ToString() Or commandName = IBECommands.FIXTURE_ROTATION_START_ANGLE.ToString() Or _
                        commandName = IBECommands.FIXTURE_ROTATION_END_ANGLE.ToString() Or commandName = IBECommands.FIXTURE_COOLING_WATER.ToString() _
                        Or commandName = IBECommands.FIXTURE_UNPROTECTED.ToString() Or commandName = IBECommands.PBN_TIMESET.ToString() _
                        Or commandName = IBECommands.COVER_FIXTURE_SHIELD_USAGE.ToString() Or commandName = IBECommands.WAFER_CLAMP_USAGE.ToString() _
                        Or commandName = IBECommands.TOP_FIXTURE_SHIELD_USAGE.ToString() Or commandName = IBECommands.SHUTTER_USAGE.ToString() _
                        Or commandName = IBECommands.LINER_SOURCE_USAGE_READBACK.ToString() Or commandName = IBECommands.CRYO_USAGE_READBACK.ToString() _
                        Or commandName = IBECommands.FIXTURE_ROTATION_MOTOR_USAGE.ToString() Or commandName = IBECommands.WATER_JOURNAL.ToString() _
                        Or commandName = IBECommands.QUART_KWH.ToString() Or commandName = IBECommands.SOURCE_USAGE_RESET.ToString() Then
                        strResult = strResult & "," & commandData
                    Else
                        strResult = strResult & "," & Format(Double.Parse(commandData), "0.000E+000")
                    End If
                Else
                    strResult = strResult & "," & commandData
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave ConvertDataToIBE")
            Return strResult
        End Function
        ''' <author>
        '''    	<name> Nguyen Tan Dung </name>
        '''    	<date> 2009-09-04</date>
        ''' </author>
        ''' <summary>
        ''' CopyDataFromIBE
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function CopyDataFromIBE(ByVal Channel As String, ByVal strTo As String, ByVal strFrom As String) As String
            AVPLib.Log.coreLogger.Info("Enter CopyDataFromIBE")
            Dim strResult As String = String.Empty
            Try
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave CopyDataFromIBE")
            Return strResult
        End Function

        ''' <author>
        '''    	<name> Hoa Nguyen </name>
        '''    	<date> 2011-03-11</date>
        ''' </author>
        ''' <summary>
        ''' CopyDataFromIBE
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        'GAS_FLOWRATE_WARNING_TIME
        Public Shared Function SetWaferStatusToIBE(ByVal chamberName As String, ByVal data As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Set_Wafer_Status_To_IBE")
            AVPLib.Log.coreLogger.Info("Leave Set_Wafer_Status_To_IBE")
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
            Return SendCommandWithDataToIBE(chamberName, IBECommands.WAFER_PROCESSING_STATUS_READBACK.ToString(), data)
        End Function

        Public Shared Function IsPumpdownNotRunning() As Boolean
            Try
                Dim objIBE As DataManagerment.IBEChamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber1.ToString())
                Return Not objIBE.IsAutoPumpdownRunning
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Function
#End Region
    End Class
End Namespace

