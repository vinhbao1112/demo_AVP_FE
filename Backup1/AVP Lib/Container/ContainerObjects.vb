''' <author>
'''    	<name>Do Xuan Dat</name>
'''    	<date> 2009-11-12</date>
''' </author>
''' <summary>
''' These class contains all configure data. 
''' Just to save time if we access to much time to a hash table
''' </summary>
''' <remarks></remarks>
Public Class ConfigurationValues
    Public Shared DEVICE_STATUS_CLOSED As String = "00"
    Public Shared DEVICE_STATUS_OPEN As String = "01"
    Public Shared DEVICE_STATUS_ERROR As String = "-01"
    Public Shared DEVICE_STATUS_OTHER As String = "04"
    Public Shared DEVICE_STATUS_STOPPED As String = "02"
    Public Shared DEVICE_STATUS_ABORT As String = "03"
    Public Shared DEVICE_STATUS_NONE As String = "05"

    'For DeviceNetApp
    Public Shared DEVICE_SIGNAL_CLOSED As String = "false"
    Public Shared DEVICE_SIGNAL_OPEN As String = "true"

    'Hoa Nguyen add
    Public Shared DEVICE_STATUS_ERROR_DIF_TYPE As String = "-1"

    Public Shared DEVICE_TEACH_VALUE As String = "100"
    Public Shared DEVICE_STATUS_RESUMING As String = "02"
    Public Shared DEVICE_STATUS_PAUSE As String = "03"
    Public Shared DEVICE_CLAMP_UP As String = "01"
    Public Shared DEVICE_CLAMP_DOWN As String = "00"
    Public Shared DEVICE_CONTINUOUS As String = "1"
    Public Shared DEVICE_HOME As String = "2"
    Public Shared DEVICE_STATIC As String = "3"
    Public Shared DEVICE_SWEEP As String = "4"
    ' Special case for Turbo Pump Power.
    Public Shared TURBO_PUMP_POWER_ON As String = "02"
End Class

' We will follow a discipline of status color as follow.
' This will apply to all cases ( we only overide the color for specific cases )
Public Enum DEVICE_STATUS
    ' its color: GRAY ( IG Button controls ...) Or BLUE ( valve controls ...) or BLACK ( sensor controls ...)
    STATUS_INACTIVE = 0
    ' its color: GREEN ( valve controls, Home Sensor control ...) Or RED ( Fixture Error Sensor control )
    STATUS_ACTIVE = 1
    ' its color: YELLOW ( Moving ...)
    STATUS_BETWEEN = 2
    ' its color: RED ( for Alarm, error happens )
    STATUS_ERROR = 3
End Enum

Public Class RobotConfigurationValues
    Public Shared IS_KEPWARE_INSTALLED As Boolean = True
    Public Shared ROBOT_VERSION_CONFIG As Double = 7.0 'DEFAULT NORMAL -> WILL BE LOAD FROM CONFIG FILE
    Public Shared CHAMBER1_VISIBLE As Boolean = True
    Public Shared CHAMBER1_TYPE As SystemModule.ModuleType = SystemModule.ModuleType.IBE
    Public Shared CHAMBER2_VISIBLE As Boolean = True
    Public Shared CHAMBER2_TYPE As SystemModule.ModuleType = SystemModule.ModuleType.IBE
    Public Shared CHAMBER3_VISIBLE As Boolean = True
    Public Shared CHAMBER3_TYPE As SystemModule.ModuleType = SystemModule.ModuleType.IBE

    Public Shared CHAMBERX_VISIBLE As List(Of String) = Nothing
    Public Shared CHAMBERX_TYPE As List(Of String) = Nothing

    Public Shared LOADLOCKA_SLOTS As Integer = 12

    Public Shared TMWATERPUM_VISIBLE As Boolean = True

    Public Shared MPUMP1_SERIAL_VISIBLE As Boolean = True
    Public Shared MPUMP2_SERIAL_VISIBLE As Boolean = True

    Public Shared SLOT_NUM_LLA As Integer = 12

    ' For DeviceNetApp
    Public Shared DEVICENETAPP_VISIBLE As Boolean = False
    Public Shared PASSWORD_EXIT_DEVICENETAPP As String = String.Empty

    Public Shared SUPPORT_PVD_UPDATE_WHEN_DATA_CHANGED As Boolean = False
    Public Shared SUPPORT_CORONA_UPDATE_WHEN_DATA_CHANGED As Boolean = True
    Public Shared SUPPORT_IBE_UPDATE_WHEN_DATA_CHANGED As Boolean = True

    '#05/13/2011
    '#Fix bug: AVP.  There are a few datalog messages still refer to chamberx instead of pmx.  Just to name a few.
    '# Change default CHAMBER_NAME from Chamberx to PMx
    '#Reason: when chamber is not installed, default name is "Chamber". So, if log exist Chamber, log still show Chamber regardless using ChamberID2ChamberName function.
    Public Shared CHAMBER1_NAME As String = "PM1" '"Chamber1"
    Public Shared CHAMBER2_NAME As String = "PM2" '"Chamber2"
    Public Shared CHAMBER3_NAME As String = "PM3" '"Chamber3"
    Public Shared ANY_IBE_CHAMBER As String = "IBE"
    Public Shared ANY_PVD_CHAMBER As String = "PVD"
    '#End fix
    Public Shared CASSETTEDMODULE_NAME As String = "TM"
    Public Shared SYSTEM_WAIT_FOR_CHECK_SENSOR_IN_SECONDS As Integer = 0
    Public Shared SYSTEM_WAIT_FOR_SENSOR_STABLE_IN_SECONDS As Integer = 3 'default wait 3s
    Public Shared CHECKSENSOR_BEFOREPICK As Boolean = True
    Public Shared DISABLE_SENSOR_CHECKING As Boolean = False
    Public Shared DELAY_ROBOT_ANIMATION As Integer = 500
    Public Shared DELAY_TIME_KEEPALIVE As Integer = 40000
    Public Shared CONNECTION_TIMEOUT As Integer = 10000
    Public Shared REAL_DEVICE_INSTALLED As Boolean = True
    Public Shared LLA_IGDEGAS_WAIT_TIME_IN_SECONDS As Integer = 30 ''Default Value
    Public Shared TM_IGDEGAS_WAIT_TIME_IN_SECONDS As Integer = 30 ''Default Value
    Public Shared PVD_UNCLAMP_WAIT_TIME As Integer = 30
    Public Shared CRYO_REGEN_HOURS_LIMIT As Integer = 720

    Public Shared LLA_STATION_NO As Integer = 1 ''default value

    Public Shared PM1_STATION_NO As Integer = 2
    Public Shared PM2_STATION_NO As Integer = 3
    Public Shared PM3_STATION_NO As Integer = 4

    Public Shared ALIGNER_AT_STATION As Integer = 1 ''Aligner at Station 1 or 10 (LLA or LLB)
    Public Shared ALIGNER_STATION_NO As Integer = 9
    Public Shared ALIGNER_AT_PACKET_MODE As Boolean = True
    Public Shared ALIGNER_SENSOR_POSITION_AT_DEGREE As Integer = 90
    Public Shared WAFER_SIZE As Integer = 6
    Public Shared ACTIVE_CCD As Integer = 1
    Public Shared WAFER_TYPE As String = "NTCH"
    Public Shared RUN_DATA_FILE_FORMAT As String = "CSV"

    Public Shared ALIGNER_DELTA_PICK_STATION_NO As Integer = 8
    Public Shared ROBOT_STATION_NO As Integer = 0
    Public Shared ALINER_VISIBLE As Boolean = True
    Public Shared ROBOT_SENSOR_INSTALLED As Boolean = True
    Public Shared TMTURBO_VISIBLE As Boolean = False
    Public Shared IS_TMTURBO_SERIAL As Boolean = False
    Public Shared IS_LLATURBO_SERIAL As Boolean = False
    Public Shared IS_TMTURBO_RSTi_SERIAL As Boolean = False
    Public Shared IS_LLATURBO_RSTi_SERIAL As Boolean = False

    Public Shared TMCRYO_VISIBLE As Boolean = True
    Public Shared LLA_TURBO_VISIBLE As Boolean = False
    Public Shared LLA_CRYO_VISIBLE As Boolean = True
    Public Shared DEVICENET_INSTALLED As Boolean = True
    Public Shared LLA_HIVAC_INSTALLED As Boolean = True
    Public Shared TM_HIVAC_INSTALLED As Boolean = True

    Public Shared LL_SLOW_ROUGH_INSTALLED As Boolean = True
    Public Shared LL_SLOW_VENT_INSTALLED As Boolean = True
    Public Shared NUMBER_LIGHT_ALARM As Integer = 3
    Public Shared NUMBER_ACTIVE_LIGHT As Integer = 3

    Public Shared ROUGH_PUMP1_INSTALLED As Boolean = True
    Public Shared ROUGH_PUMP2_INSTALLED As Boolean = False

    Public Shared SHARED_MP_WITH_PM As Boolean = False

    'Public Shared ROUGH_1_INSTALLED As Boolean = True
    'Public Shared ROUGH_2_INSTALLED As Boolean = False
    'THIS VARIABLE USED TO TEST, TO IGNORE THE CHECK SENSOR STEP, SET IT TO FALSE
    Public Shared DEBUGMODE As Boolean = False
    ' This Flag used to set whether we should log low level messages.
    Public Shared LOG_LOW_LEVEL_MESSAGES As Boolean = False
    Public Shared AUTO_EXPORT_DATALOG_TOCSV As Boolean = False
    Public Shared SUPPORT_REQUEST_ALL_DATA_CHANGED As Boolean = False 'DEFAULT
    Public Shared SUPPORT_MANUAL_DEFINE_GEM_WAFERID As Boolean = False
    Public Shared ALLOW_CHECKING_ECC_LIMIT As Boolean = False
    Public Shared ECC_M_LIMIT As Integer = 0
    Public Shared CHECK_WAFER_SLIDE_OUT As Boolean = True
    Public Shared AnyIBE_DiverterValve_Installed As Boolean = False
    Public Shared AnyIBE_EP_Installed As Boolean = False
    Public Shared RUN_SCHEDULER_NO As Integer = 999

End Class

Public Class LLElevatorConfigurationValues
    Friend Shared LLELEVATOR_TIMEOUT As Integer = 3000 ''DEFAULT VALUE
End Class

Public Class System_Init_Indicator
    Public Shared IsMainFormInitialize As Boolean = False
    Public Shared IsLoadStoreGuiFinish As Boolean = False
End Class
Public Class System_Shutdown_Indicator
    Public Shared IsMainFormClosing As Boolean = False
End Class

#Region "Move sytem config value to code"
Public Class SYSTEM_CONFIG_TIMEOUT_VALUES
    Public Shared LLA_CRYO_TIMEOUT As Integer = 4000
    Public Shared TM_CRYO_TIMEOUT As Integer = 4000
    Public Shared TM_WATER_PUMP_TIMEOUT As Integer = 4000
    Public Shared LLA_ELEVATOR_TIMEOUT As Integer = 5000
    Public Shared ROBOT_TIMEOUT As Integer = 30000
    Public Shared ROBOT_GOHOME_TIMEOUT As Integer = 90000 '60s
    Public Shared ALIGNER_TIMEOUT As Integer = 30000
    Public Shared LL_ELEVATOR_REQUEST_STATUS_TIMEOUT As Integer = 5000
    'Public Shared LOADER_TIMEOUT As Integer = 30000
    'Public Shared LOADER_REQUEST_STATUS_TIMEOUT As Integer = 5000

End Class

Public Class SYSTEM_CONFIG_POLLING_VALUES
    Public Shared LLA_CRYO_POLLING As Integer = 500
    Public Shared TM_CRYO_POLLING As Integer = 500
    Public Shared TM_WATER_PUMP_POLLING As Integer = 500
    Public Shared LLA_ELEVATOR_POLLING As Integer = 600
    Public Shared ROBOT_POLLING As Integer = 200
    Public Shared ALIGNER_POLLING As Integer = 350
    Public Shared PVD_STATUS_REPORT_POLLING As Integer = 200
    Public Shared IBE_POLLING_CMD_POLLING As Integer = 2000
    Public Shared PVD5T_POLLING_CMD_POLLING As Integer = 200
    'Public Shared LOADER_POLLING As Integer = 200
End Class

Public Class SYSTEM_CONFIG_INIT_VALUES
    'IBE command pulling
    Public Shared IBE_PULLING_COMMAND_ARRAY As ArrayList = New ArrayList(New String() { _
        "05,01,06,01,01,?", _
        "05,01,09,01,01,?", _
        "05,01,09,01,02,?", _
        "05,01,08,01,01,?", _
        "05,01,08,01,02,?", _
        "05,01,08,02,01,?", _
        "05,01,08,02,02,?", _
        "05,01,08,03,01,?", _
        "05,01,08,03,02,?", _
        "03,01,10,01,01,?", _
        "03,01,10,01,02,?", _
        "05,01,09,01,04,?", _
        "05,01,08,01,04,?", _
        "05,01,08,02,04,?", _
        "05,01,08,03,04,?", _
        "03,01,10,01,04,?", _
        "05,01,02,01,01,?", _
        "05,01,19,01,02,?", _
        "05,01,17,01,02,?", _
        "05,01,18,01,02,?", _
        "05,01,22,01,06,?", _
        "05,01,22,01,05,?", _
        "05,01,22,01,03,?", _
        "03,01,21,01,01,?", _
        "03,01,02,01,02,?", _
        "05,01,33,01,01,?", _
        "03,01,08,01,05,?", _
        "01,01,05,01,01,00", _
        "02,01,04,01,03,?"})

    Public Shared ROBOT_COMMAND_ARRAY As ArrayList = New ArrayList(New String() { _
        "SET COMM ALL PKT SEQ AUT", _
        "SET IO ECHO N", _
        "STORE COMM ALL", _
        "HOME ALL", _
        "GOTO N 1"})

    Public Shared ALIGNER_COMMAND_ARRAY As ArrayList = New ArrayList(New String() { _
        "SLIO M/B PKT BAUD 4 ECHO N", _
        "LDCCDPOS 1 {0}", _
        "HOME", _
        "SLWF SIZE {0} CCD {1} FDCL {2}", _
        "SVCCDPOS", _
        "SVWS", _
        "SVBD"})

    Public Shared ALIGNER_MONITOR_COMMAND_ARRAY As ArrayList = New ArrayList(New String() { _
        "SLIO M/B MON BAUD 4 ECHO N", _
        "LDCCDPOS 1 {0}", _
        "HOME", _
        "SLWF SIZE {0} CCD {1} FDCL {2}", _
        "SVCCDPOS", _
        "SVWS", _
        "SVBD"})

    'LL ELEVATOR
    Public Shared LL_ELEVATOR_00_S_ER_INIT As String = "00,S,ER"
    Public Shared LL_ELEVATOR_00_S_EC_N_INIT As String = "00,S,EC,N"
    Public Shared LL_ELEVATOR_00_S_INTLCK_CASS_PRESENT_DIS_INIT As String = "00,S,INTLCK,CASS,PRESENT,DIS"
    Public Shared LL_ELEVATOR_00_S_CF_NS_INIT As String = "00,S,CF,NS,"
    Public Shared LL_ELEVATOR_00_S_CF_PT_INIT As String = "00,S,CF,PT,"
    Public Shared LL_ELEVATOR_00_S_CF_CT_INIT As String = "00,S,CF,CT,"
    Public Shared LL_ELEVATOR_00_S_CF_LM_INIT As String = "00,S,CF,LM,"
    Public Shared LL_ELEVATOR_00_S_FB_INIT As String = "00,S,FB,"
    Public Shared LL_ELEVATOR_00_A_HM_INIT As String = "00,A,HM"
    Public Shared LL_ELEVATOR_00_S_SPS_MODE As String = "00,S,SPS,MODE"

    'Special for VC2
    Public Shared LL_ELEVATOR_VC2_00_S_CF_NS_INIT As String = "00,S,CF,NS"
    Public Shared LL_ELEVATOR_VC2_00_S_CF_PT_INIT As String = "00,S,CF,PT"
    Public Shared LL_ELEVATOR_VC2_00_S_CF_LM_INIT As String = "00,S,CF,LM"
    Public Shared LL_ELEVATOR_VC2_00_S_CF_CT_INIT As String = "00,S,CF,CT"
    Public Shared LL_ELEVATOR_VC2_00_S_FB_INIT As String = "00,S,FB"

End Class

Public Class SYSTEM_CONFIG_STATION_LOCATION_VALUES
    'Module
    Public Shared LLA_STATION_LOCATION_INIT As Integer = 1
    Public Shared PM1_STATION_LOCATION_INIT As Integer = 2
    Public Shared PM2_STATION_LOCATION_INIT As Integer = 3
    Public Shared PM3_STATION_LOCATION_INIT As Integer = 4
    Public Shared ALIGNER_STATION_LOCATION_INIT As Integer = 9
    Public Shared ROBOT_STATION_LOCATION_INIT As Integer = 0
    'Delta Pick Stattion
    Public Shared DELTA_PICK_STATION_LOCATION_INIT As Integer = 8
End Class

Public Class SYSTEM_CONFIG_ROBOT_ANIMATION
    Public Shared ROBOT_ANIMATION_VALUE As Integer = 400
End Class

Public Class SYSTEM_DELAY_TIME_FOR_KEEP_ALIVE
    Public Shared DELAY_TIME_FOR_KEEP_ALIVE_VALUE As Integer = 60000
End Class

Public Class CRYO_REGEN_STATUS_TEXT
    Public Shared CRYOPUMP_OFF As String = "CRYOPUMP OFF"
    Public Shared WARM_UP As String = "WARM-UP"
    Public Shared PURGE_GAS_FAILURE As String = "PURGE GAS FAILURE"
    Public Shared EXTENDED_PURGE_OR_REPURGE_CYCLE As String = "EXTENDED PURGE/REPURGE CYCLE"
    Public Shared ROUGH_TO_BASE As String = "ROUGH TO BASE"
    Public Shared RATE_OF_RISE As String = "RATE OF RISE"
    Public Shared COOLDOWN As String = "COOLDOWN"
    Public Shared COMPLETE As String = "COMPLETE"
    Public Shared BEGIN_FAST_REGEN As String = "BEGIN FAST REGEN"
    Public Shared ABORTED As String = "ABORTED"
    Public Shared DELAY_RESTART As String = "DELAY RESTART"
    Public Shared POWER_FAILURE As String = "POWER FAILURE"
    Public Shared DELAY_START As String = "DELAY START"
    Public Shared ZEROING_TC_GAUSE As String = "ZEROING TC GAUSE"
    Public Shared SHARE_REGEN_WAIT As String = "SHARE REGEN WAIT"
    Public Shared REPURGE As String = "REPURGE"
    Public Shared PURGE_COORD_WAIT As String = "PURGE COORD WAIT"
    Public Shared ROUGH_COORD_WAIT As String = "ROUGH COORD WAIT"
    Public Shared PURGE_GAS_FAIL As String = "PURGE GAS FAIL,RECOVERING"
    Public Shared WARMUP As String = "WARMUP"
End Class

Public Class PM_MIN_MAX_NAME_ITEM
    'PVD
    Public Shared PVD_RF_POWER_MAX_SP As String = "PVD.RFTargetPowerSupply.txtForwardPowerRightMax"
    Public Shared PVD_BIAS_POWER_MAX_SP As String = "PVD.BiasPowerSupply.txtForwardPowerRightMax"
    Public Shared PVD_DC_POWER_MAX_SP As String = "PVD.DCTargetPowerSupply.txtTargetPowerRightMax"
    Public Shared PVD_GAS1_MAX_SP As String = "PVD.GasController.txtGas1RightMax"
    Public Shared PVD_GAS2_MAX_SP As String = "PVD.GasController.txtGas2RightMax"
    Public Shared PVD_GAS3_MAX_SP As String = "PVD.GasController.txtGas3RightMax"
    Public Shared PVD_GAS4_MAX_SP As String = "PVD.GasController.txtGas4RightMax"
    Public Shared PVD_GAS5_MAX_SP As String = "PVD.GasController.txtGas5RightMax"
    Public Shared PVD_PARALLEL_MAGNET_MAX_SP As String = "PVD.ParallelMagnet.txtCurrentRightMax"
    'IBE
    Public Shared IBE_RF_POWER_MAX_SP As String = "IBE.txtRFPowerRightMax"
    Public Shared IBE_BEAM_VOLTAGE_MAX_SP As String = "IBE.txtBeamVoltageRightMax"
    Public Shared IBE_SUPPRESSOR_VOLTAGE_MAX_SP As String = "IBE.txtSuppressorVoltageRightMax"
    Public Shared IBE_GAS1_MAX_SP As String = "IBE.txtGas1Right_SourceTabMax,IBE.txtGas1RightMax"
    Public Shared IBE_GAS2_MAX_SP As String = "IBE.txtGas2Right_SourceTabMax,IBE.txtGas2RightMax"
    Public Shared IBE_GAS3_MAX_SP As String = "IBE.txtGas3RightMax"
    Public Shared IBE_GAS4_MAX_SP As String = "IBE.txtGas4RightMax"
    Public Shared IBE_GAS5_MAX_SP As String = "IBE.txtGas5RightMax"
    Public Shared IBE_PBN_GAS_MAX_SP As String = "IBE.txtPBNGasRight_SourceTabMax,IBE.txtPBNGasRightMax"
    Public Shared IBE_FLOWCOOL_GAS_MAX_SP As String = "IBE.txtFlowCoolGasRightMax"
    Public Shared IBE_TILE_ANGLE_MIN_SP As String = "IBE.txtTiltAngleRightMin"
    Public Shared IBE_TILE_ANGLE_MAX_SP As String = "IBE.txtTiltAngleRightMax"

    Public Shared IBE_BEAM_CURRENT_SP As String = "IBE.txtBeamCurrentRight"                     'Just synch local. Not get from PM
    Public Shared IBE_K_FACTOR_SP As String = "IBE.txtKFactorRight"                             'Just synch local. Not get from PM
    Public Shared IBE_SWEEP_START_SP As String = "IBE.txtRotationSweepRight"          'Just synch local. Not get from PM
    Public Shared IBE_SWEEP_END_SP As String = "IBE.txtRotationEnd"                   'Just synch local. Not get from PM
    Public Shared IBE_STATIC_ANGLE_SP As String = "IBE.txtRotationStaticRight"        'Just synch local. Not get from PM
    Public Shared IBE_ROTATION_SPEED_SP As String = "IBE.txtRotationContinuousRight"  'Just synch local. Not get from PM
    Public Shared IBE_TILE_SWEEP_START_ANGLE_MAX_SP As String = "IBE.txtTiltSweepRightMax"
    Public Shared IBE_TILE_SWEEP_END_ANGLE_MAX_SP As String = "IBE.txtTiltEndMax"
    Public Shared IBE_TILE_SWEEP_START_ANGLE_MIN_SP As String = "IBE.txtTiltSweepRightMin"
    Public Shared IBE_TILE_SWEEP_END_ANGLE_MIN_SP As String = "IBE.txtTiltEndMin"
    'CORONA
    Public Shared CORONA_TARGET_POWER_MAX_SP As String = "PVD4.TargetPowerSupply.txtForwardPowerRightMax"
    Public Shared CORONA_TARGET_DC_POWER_MAX_SP As String = "PVD4.TargetPowerSupply.txtDCForwardPowerRightMax"
    Public Shared CORONA_BIAS_POWER_MAX_SP As String = "PVD4.BiasPowerSupply.txtForwardPowerRightMax"
    Public Shared CORONA_GAS1_MAX_SP As String = "PVD4.txtGas1RightMax"
    Public Shared CORONA_GAS2_MAX_SP As String = "PVD4.txtGas2RightMax"
    Public Shared CORONA_GAS3_MAX_SP As String = "PVD4.txtGas3RightMax"
    Public Shared CORONA_GAS4_MAX_SP As String = "PVD4.txtGas4RightMax"
    Public Shared CORONA_GAS5_MAX_SP As String = "PVD4.txtGas5RightMax"
    Public Shared CORONA_STATIC_POSITION_SP As String = "PVD4.StaticPostionMax"
    Public Shared CORONA_TABLE_POS_RIGHT_MIN As String = "PVD4.txtTablePosRightMin"
    Public Shared CORONA_TABLE_POS_RIGHT_MAX As String = "PVD4.txtTablePosRightMax"
    'PVD5T
    Public Shared PVD5T_RF_TARGET_POWER_MAX_SP As String = "PVD4.TargetPowerSupply.txtForwardPowerRightMax"
    Public Shared PVD5T_TARGET_DC_POWER_MAX_SP As String = "PVD4.TargetPowerSupply.txtDCForwardPowerRightMax"
    Public Shared PVD5T_BIAS_POWER_MAX_SP As String = "PVD4.BiasPowerSupply.txtForwardPowerRightMax"
    Public Shared PVD5T_GAS1_MAX_SP As String = "PVD4.txtGas1RightMax"
    Public Shared PVD5T_GAS2_MAX_SP As String = "PVD4.txtGas2RightMax"
    Public Shared PVD5T_GAS3_MAX_SP As String = "PVD4.txtGas3RightMax"
    Public Shared PVD5T_GAS4_MAX_SP As String = "PVD4.txtGas4RightMax"
    Public Shared PVD5T_GAS5_MAX_SP As String = "PVD4.txtGas5RightMax"
    Public Shared PVD5T_STATIC_POSITION_SP As String = "PVD4.StaticPostionMax"
    Public Shared PVD5T_TABLE_POS_RIGHT_MIN As String = "PVD4.txtTablePosRightMin"
    Public Shared PVD5T_TABLE_POS_RIGHT_MAX As String = "PVD4.txtTablePosRightMax"
End Class

#End Region
    

