Namespace XMLResources
    Public Class SL_IBEServer
        Public Const XMLText As String = _
        "<IBEServer>" & _
        "  <Command CommandName=""ROUGH_PUMP_POWER"" CommandCode=""1,02,01,01,01,01"" PropertyName=""RoughPumpStatus"" Decoder=""WorkingStatuses""/> " & _
        "  <Command CommandName=""TURBO_PUMP_GATE_VALVE"" CommandCode=""1,02,01,02,01,03"" PropertyName=""HiVacValveStatus"" Decoder=""WorkingStatuses""/>" & _
        "   <Command CommandName=""TURBO_PUMP_POWER"" CommandCode=""1,02,01,02,01,01"" PropertyName=""TurboPowerStatus"" Decoder=""WorkingStatuses""/>" & _
        "  <Command CommandName=""SLAVE_TURBO"" CommandCode=""1,02,01,03,01,01"" PropertyName="""" Decoder=""""/>" & _
        "<!--new in sl-->" & _
        "	<Command CommandName=""WATER_PUMP_REGEN"" CommandCode=""1,0x,0x,0x,0x,67"" PropertyName=""WaterPumpRegen"" Decoder=""WorkingStatuses""/>" & _
        "	<Command CommandName=""WATER_PUMP"" CommandCode=""1,0x,0x,0x,0x,66"" PropertyName=""WaterPump"" Decoder=""WorkingStatuses""/>" & _
        "	" & _
        "  <Command CommandName=""CRYO_POWER"" CommandCode=""1,02,01,04,01,01"" PropertyName=""CryoPumpStatus"" Decoder=""WorkingStatuses""/>" & _
        "  <Command CommandName=""CRYO_PUMP_TEMPERTURE"" CommandCode=""1,02,01,04,01,02"" PropertyName=""Cryo_Pump_Temperture"" Decoder=""Double""/>" & _
        "  <Command CommandName=""CRYO_PUMP_TEMPERTURE_T2"" CommandCode=""1,0x,0x,0x,0x,64"" PropertyName=""Cryo_Pump_Temperture_T2"" Decoder=""Double""/>" & _
        "  <Command CommandName=""CRYO_PUMP_GATE_VALVE"" CommandCode=""1,02,01,04,01,03"" PropertyName=""ValveCryoPumpGateStatus"" Decoder=""WorkingStatuses""/>" & _
        "  <Command CommandName=""CRYO_REGEN_VALVE"" CommandCode=""1,02,01,04,01,04"" PropertyName=""CryoPumpRegenStatus"" Decoder=""WorkingStatuses""/>" & _
        "  <Command CommandName=""CRYO_PURGE_VALVE"" CommandCode=""1,02,01,04,01,05"" PropertyName=""CryoPumpPurgeStatus"" Decoder=""WorkingStatuses""/>" & _
        "  <Command CommandName=""CRYO_AUTO_REGEN"" CommandCode=""1,02,01,04,01,06"" PropertyName=""CryoAutoRegenStatus"" Decoder=""WorkingStatuses""/>" & _
        "  <Command CommandName=""CRYO_AUTO_POWER_DOWN"" CommandCode=""1,02,01,04,01,07"" PropertyName=""CryoAutoPowerDownStatus"" Decoder=""WorkingStatuses""/>" & _
        "" & _
        "  <Command CommandName=""ROUGH_VALVE"" CommandCode=""1,02,01,05,01,01"" PropertyName=""RoughValveStatus"" Decoder=""WorkingStatuses""/>" & _
        "  <Command CommandName=""VENT_VALVE"" CommandCode=""1,02,01,06,01,01"" PropertyName=""VentValveStatus"" Decoder=""WorkingStatuses""/>" & _
        "  <Command CommandName=""FORELINE_VALVE"" CommandCode=""1,02,01,07,01,01"" PropertyName=""ForelineValveStatus"" Decoder=""WorkingStatuses""/>" & _
        "  " & _
        "  <Command CommandName=""ION_GAUGE_EMISSION"" CommandCode= ""1,02,01,08,01,02"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""ION_GAUGE_DEGAS"" CommandCode=""1,02,01,08,01,03"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""AUTO_PUMP_DOWN"" CommandCode=""1,02,01,13,01,01"" PropertyName=""PumpDownStatus"" Decoder=""WorkingStatuses""/>" & _
        "  <Command CommandName=""AUTO_VENT"" CommandCode=""1,02,01,14,01,01"" PropertyName=""VentStatus"" Decoder=""WorkingStatuses""/>" & _
        "" & _
        "  <Command CommandName=""VACUUM_LOCK"" CommandCode=""1,02,01,15,01,01"" PropertyName="""" Decoder=""""/>" & _
        "" & _
        "  <Command CommandName=""CHAMBER_HEATER"" CommandCode=""1,02,01,16,01,01"" PropertyName="""" Decoder=""""/>" & _
        "" & _
        "  <Command CommandName=""PROCESS_START_PRESSURE"" CommandCode=""1,02,01,19,01,01"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""PUMPED_DOWN_PRESSURE"" CommandCode=""1,02,01,19,01,02"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""ATMOSPHERE_PRESSURE"" CommandCode=""1,02,01,19,01,03"" PropertyName="""" Decoder=""""/>" & _
        "" & _
        "  <Command CommandName=""ROUGH_TIMEOUT"" CommandCode=""1,02,01,19,01,04"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""VENT_TIMEOUT"" CommandCode=""1,02,01,19,01,05"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""TURBO_VENT_DELAY"" CommandCode=""1,02,01,19,01,06"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""RAISE_OF_RISE"" CommandCode=""1,02,01,20,01,01"" PropertyName=""RaiseOfRiseStatus"" Decoder=""WorkingStatuses""/>" & _
        "    " & _
        "  <!--Status Panel-->" & _
        "  <Command CommandName=""INITIALIZE_MOTION"" CommandCode=""1,03,01,14,01,01"" PropertyName=""Initialize_Motion_readback"" Decoder=""WorkingStatuses""/>" & _
        "  <Command CommandName=""GAS_OK"" CommandCode=""1,05,01,24,01,01"" PropertyName=""Process_Gas_Readback"" Decoder=""WorkingStatuses""/>" & _
        "  <Command CommandName=""BEAM_OK"" CommandCode=""1,05,01,25,01,01"" PropertyName=""Ion_Beam_Readback"" Decoder=""WorkingStatuses""/>" & _
        "  <Command CommandName=""PBN_OK"" CommandCode= ""1,05,01,26,01,01"" PropertyName=""PBN_OK_Readback"" Decoder=""WorkingStatuses""/>" & _
        "  <!--End status panel-->" & _
        "    <!--Fixture Control-->" & _
        "<Command CommandName=""FIXTURE_HOME_TILT_READBACK"" CommandCode=""1,0x,0x,0x,06,44"" PropertyName=""Fixture_Home_Tilt_Readback"" Decoder=""WorkingStatuses""/>" & _
        "<Command CommandName=""FIXTURE_START_ROTATION_AXIS"" CommandCode=""1,03,01,08,01,05"" PropertyName=""Fixture_Start_Rotation_Readback"" Decoder=""WorkingStatuses""/>" & _
        "       <!--Fixture Mode-->" & _
        "  <Command CommandName=""FIXTURE_ROTATION_MODE"" CommandCode=""1,03,01,08,01,04"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""FIXTURE_TILT_ANGLE"" CommandCode=""1,03,01,09,01,01"" PropertyName=""Fixture_TiltAngle_Program"" Decoder=""Double""/>" & _
        "  <Command CommandName=""FIXTURE_TILT_ANGLE_READBACK"" CommandCode=""1,03,01,09,01,05"" PropertyName=""Fixture_TiltAngle_Readback"" Decoder=""Double""/>" & _
        "  <Command CommandName=""FIXTURE_STATIC_ROTATION_ANGLE_READBACK"" CommandCode=""1,03,01,08,01,09"" PropertyName=""StaticFixture_Rotation_Readback"" Decoder=""Double""/>" & _
        "  <Command CommandName=""FIXTURE_STATIC_ROTATION_ANGLE"" CommandCode=""1,03,01,08,01,01"" PropertyName=""StaticFixture_Rotation_Program"" Decoder=""Double""/>" & _
        "  <Command CommandName=""FIXTURE_ROTATION_START_ANGLE_READBACK"" CommandCode=""1,03,01,08,02,06"" PropertyName=""SweepFixture_Rotation_Start_Readback"" Decoder=""Double""/>" & _
        "  <Command CommandName=""FIXTURE_ROTATION_START_ANGLE"" CommandCode=""1,03,01,08,01,06"" PropertyName=""SweepFixture_Rotation_Start_Program"" Decoder=""Double""/>" & _
        "  <Command CommandName=""FIXTURE_ROTATION_END_ANGLE"" CommandCode=""1,03,01,08,01,07"" PropertyName=""SweepFixture_Rotation_End_Program"" Decoder=""Double""/>" & _
        "  <Command CommandName=""FIXTURE_CONTINUOUS_ROTATION_RPM_READBACK"" CommandCode=""1,03,01,08,01,10"" PropertyName=""ContinuousFixture_Rotation_Readback"" Decoder=""Double""/>" & _
        "  <Command CommandName=""FIXTURE_CONTINUOUS_ROTATION_RPM"" CommandCode=""1,03,01,08,01,08"" PropertyName=""ContinuousFixture_Rotation_Program"" Decoder=""Double""/>" & _
        "        <!--End Fixture Mode-->" & _
        "  <Command CommandName=""FIXTURE_ROTATION_DWELL_TIME"" CommandCode=""03,01,08,01,13"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""FLOWCOOL_MFC_SHUTOFF_VALVE"" CommandCode=""1,03,01,10,01,01"" PropertyName=""FlowCoolHeValveStatus"" Decoder=""WorkingStatuses""/>" & _
        "  <Command CommandName=""FLOWCOOL_MFC_SUPPLY_VALVE"" CommandCode=""1,03,01,10,01,02"" PropertyName=""ValveSupplyFlowCoolHeStatus"" Decoder=""WorkingStatuses""/>" & _
        "  <Command CommandName=""FLOWCOOL_MFC_TARGET_FLOWRATE"" CommandCode=""1,03,01,10,01,03"" PropertyName=""GasController_FlowCoolHe_Program"" Decoder=""Double""/>" & _
        "  <Command CommandName=""FLOWCOOL_MFC_ACTUAL_FLOWRATE"" CommandCode=""1,03,01,10,01,04"" PropertyName=""GasController_FlowCoolHe_Readback"" Decoder=""Double""/>" & _
        "  <Command CommandName=""WAFER_IN_FIXTURE"" CommandCode=""1,03,01,12,01,01"" PropertyName=""Wafer_InFixture_Readback"" Decoder=""WorkingStatuses""/>" & _
        "         <!--Menu Fixture-->" & _
        "  <Command CommandName=""FIXTURE_HOME_ROTATION_AXIS"" CommandCode=""1,03,01,08,02,05"" PropertyName=""Fixture_Home_Rotation_Program"" Decoder=""WorkingStatuses""/>" & _
        "  <Command CommandName=""FIXTURE_UNPROTECTED"" CommandCode=""1,0x,0x,0x,0x,65"" PropertyName=""Fixture_Unprotected_Readback"" Decoder=""Double""/>" & _
        "  <!--Command CommandName=""FIXTURE_COOLING_WATER"" CommandCode=""1,0x,0x,0x,01,65"" PropertyName=""Fixture_Cooling_Water_Readback"" Decoder=""Double""/-->" & _
        "  <Command CommandName=""FIXTURE_WATER_VALVE"" CommandCode=""1,03,01,02,01,01"" PropertyName=""FixtureWaterValveStatus"" Decoder=""WorkingStatuses""/>" & _
        "  <Command CommandName=""FIXTURE_PUMP_POWER"" CommandCode=""1,0x,0x,0x,02,65"" PropertyName=""Fixture_Pump_Power_Readback"" Decoder=""Double""/>" & _
        "  <Command CommandName=""SHUTTER_POSITION"" CommandCode=""1,05,01,01,01,01"" PropertyName=""ShutterPositionStatus"" Decoder=""WorkingStatuses""/>" & _
        "<!--old command fixture -->" & _
        "  <Command CommandName=""FIXTURE_FLOWCOOL_PUMP_POWER"" CommandCode=""1,03,01,01,01,01"" PropertyName=""FixtureFlowCoolPumpStatus"" Decoder=""WorkingStatuses""/>" & _
        "  " & _
        "  <Command CommandName=""FIXTURE_LOCK"" CommandCode=""1,03,01,03,01,01"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""FIXTURE_CLAMP"" CommandCode=""1,03,01,07,01,01"" PropertyName=""FixtureClampStatus"" Decoder=""WorkingStatuses""/>" & _
        "  <Command CommandName=""FIXTURE_ROTATION_HOME"" CommandCode=""1,03,01,08,01,02"" PropertyName=""FixtureRotationHomeStatus"" Decoder=""DEVICE_STATUS""/>" & _
        "  <Command CommandName=""FIXTURE_ROTATION_MOVING"" CommandCode=""1,03,01,08,01,03"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""FIXTURE_ROTATION_ERROR"" CommandCode=""1,03,01,08,01,04,-1"" PropertyName=""FixtureErrorStatus"" Decoder=""DEVICE_STATUS""/>" & _
        "  <Command CommandName=""FIXTURE_TILT_HOME"" CommandCode=""1,03,01,09,01,02"" PropertyName=""FixtureTiltHomeStatus"" Decoder=""DEVICE_STATUS""/>" & _
        "  <Command CommandName=""FIXTURE_TILT_MOVING"" CommandCode=""1,03,01,09,01,03"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""FIXTURE_TILT_ERROR"" CommandCode=""1,03,01,09,01,04"" PropertyName=""FixtureErrorStatus"" Decoder=""DEVICE_STATUS""/>" & _
        "  <!--End Fixture Control-->" & _
        "  <Command CommandName=""MOTION_TO_SERVICE_POSITION"" CommandCode=""1,03,01,23,01,01"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""MAGNETIC_CHUCK_POWER"" CommandCode=""1,03,01,15,01,01"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""MAGNETIC_CHUCK_PHASE"" CommandCode=""1,03,01,15,01,02"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""MAGNETIC_CHUCK_AMPLITUDE"" CommandCode=""1,03,01,15,01,03"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""MAGNETIC_CHUCK_FREQUENCY"" CommandCode=""1,03,01,15,01,04"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""MAGNETIC_CHUCK_WAVE_TYPE"" CommandCode=""1,03,01,15,01,05"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""HOT_CHUCK_POWER"" CommandCode=""1,03,01,17,01,01"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""HOT_CHUCK_GET_TEMPERATURE"" CommandCode=""1,03,01,17,01,02"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""HOT_CHUCK_SET_TEMPERATURE"" CommandCode=""1,03,01,17,01,04"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""STATIC_COOLING_EXHAUST_VALVE"" CommandCode=""1,03,01,25,01,01"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""STATIC_COOLING_SUPPLY_VALVE"" CommandCode=""1,03,01,25,01,02"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""STATIC_COOLING_TARGET_FLOW"" CommandCode=""1,03,01,25,01,03"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""STATIC_COOLING_ACTUAL_FLOW"" CommandCode=""1,03,01,25,01,04"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""STATIC_COOLING_TARGET_PRESSURE"" CommandCode=""1,03,01,25,01,05"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""STATIC_COOLING_ACTUAL_PRESSURE"" CommandCode=""1,03,01,25,01,06"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""STATIC_COOLING_GAS_OK"" CommandCode=""1,03,01,25,01,08"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""STATIC_COOLING_START"" CommandCode=""1,03,01,25,01,09"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""STATIC_COOLING_STOP"" CommandCode=""1,03,01,25,01,10"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""TEC_POWER"" CommandCode=""1,03,01,26,01,07"" PropertyName="""" Decoder=""""/>" & _
        "  <!--Power Panel-->" & _
        "  <Command CommandName=""SOURCE_AC_POWER"" CommandCode=""1,05,01,02,01,01"" PropertyName=""ACPower_readback"" Decoder=""WorkingStatuses""/>" & _
        "  <Command CommandName=""SOURCE_RF_POWER"" CommandCode=""1,05,01,03,01,01"" PropertyName=""RFPower_readback"" Decoder=""WorkingStatuses""/>" & _
        "  <Command CommandName=""SOURCE_GRID_POWER"" CommandCode=""1,05,01,04,01,01"" PropertyName=""GridPower_readback"" Decoder=""WorkingStatuses""/>" & _
        "  <Command CommandName=""SOURCE_PBN_POWER"" CommandCode=""1,05,01,05,01,01"" PropertyName=""PBNPower_readback"" Decoder=""WorkingStatuses""/>" & _
        "  <Command CommandName=""SOURCE_NEUR_POWER"" CommandCode=""1,05,01,5x,1x,1x"" PropertyName=""NeurPower_readback"" Decoder=""WorkingStatuses""/>" & _
        "  	<!--new in sl-->" & _
        "  <Command CommandName=""SOURCE_MANUAL_AUTO_POWER"" CommandCode=""1,05,01,06,01,01"" PropertyName=""SourceManual_Auto_readback"" Decoder=""WorkingStatuses""/>" & _
        "    <!--Power Panel-->" & _
        "  <Command CommandName=""ELECTRONIC_SHUTTER"" CommandCode=""1,05,01,07,01,01"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""PBN_GAS_SHUTOFF_VALVE"" CommandCode=""1,05,01,09,01,01"" PropertyName=""PBNValveStatus"" Decoder=""WorkingStatuses""/>" & _
        "  <Command CommandName=""PBN_GAS_SUPPLY_VALVE"" CommandCode=""1,05,01,09,01,02"" PropertyName=""ValveSupplyPBNStatus"" Decoder=""WorkingStatuses""/>" & _
        "  <Command CommandName=""PBN_GAS_FLOWRATE_READBACK"" CommandCode=""1,05,01,09,01,04"" PropertyName=""GasController_PBN_Readback"" Decoder=""Double""/>" & _
        "  <Command CommandName=""PBN_GAS_FLOWRATE_PROGRAM"" CommandCode=""1,05,01,09,01,03"" PropertyName=""GasController_PBN_Program"" Decoder=""Double""/>" & _
        "  <Command CommandName=""PBN_GAS_FLOWRATE_ERROR_TOL"" CommandCode=""1,05,01,09,01,07"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""PBN_GAS_FLOWRATE_WARNING_TOL"" CommandCode=""1,05,01,09,01,08"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""PBN_GAS_FLOWRATE_ERROR_TIME"" CommandCode=""1,05,01,09,01,09"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""PBN_GAS_FLOWRATE_WARNING_TIME"" CommandCode=""1,05,01,09,01,10"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""N2_PURGE"" CommandCode=""1,05,01,10,01,01"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""DIVERTER_VALVE"" CommandCode=""1,05,01,11,01,01"" PropertyName="""" Decoder=""""/>" & _
        "  <!-- BeamPowerSupply-->" & _
        "  <Command CommandName=""AUTO_BEAM"" CommandCode=""1,05,01,16,01,01"" PropertyName=""BeamPowerSupply_AutoBeam"" Decoder=""WorkingStatuses""/>" & _
        "   <Command CommandName=""BEAM_VOLTAGE_PROGRAM"" CommandCode=""1,05,01,12,01,01"" PropertyName=""BeamPowerSupply_Voltage_Program"" Decoder=""Double""/>" & _
        "  <Command CommandName=""BEAM_VOLTAGE_READBACK"" CommandCode=""1,05,01,12,01,02"" PropertyName=""BeamPowerSupply_Voltage_Readback"" Decoder=""Double""/>" & _
        "  <Command CommandName=""BEAM_VOLTAGE_ERROR_TOL"" CommandCode=""1,05,01,12,01,07"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""BEAM_VOLTAGE_WARNING_TOL"" CommandCode=""1,05,01,12,01,08"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""BEAM_VOLTAGE_ERROR_TIME"" CommandCode=""1,05,01,12,01,09"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""BEAM_VOLTAGE_WARNING_TIME"" CommandCode=""1,05,01,12,01,10"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""BEAM_CURRENT_PROGRAM"" CommandCode=""1,05,01,13,01,01"" PropertyName=""BeamPowerSupply_Current_Program"" Decoder=""Double""/>" & _
        "  <Command CommandName=""BEAM_CURRENT_READBACK"" CommandCode=""1,05,01,13,01,02"" PropertyName=""BeamPowerSupply_Current_Readback"" Decoder=""Double""/>" & _
        "  <Command CommandName=""BEAM_CURRENT_ERROR_TOL"" CommandCode=""1,05,01,13,01,07"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""BEAM_CURRENT_WARNING_TOL"" CommandCode=""1,05,01,13,01,08"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""BEAM_CURRENT_ERROR_TIME"" CommandCode=""1,05,01,13,01,09"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""BEAM_CURRENT_WARNING_TIME"" CommandCode=""1,05,01,13,01,10"" PropertyName="""" Decoder=""""/>" & _
        "  <!-- SuppressorPowerSupply-->" & _
        "  <Command CommandName=""SUPP_VOLTAGE_PROGRAM"" CommandCode=""1,05,01,14,01,01"" PropertyName=""SuppressorPowerSupply_Voltage_Program"" Decoder=""Double""/>" & _
        "  <Command CommandName=""SUPP_VOLTAGE_READBACK"" CommandCode=""1,05,01,14,01,02"" PropertyName=""SuppressorPowerSupply_Voltage_Readback"" Decoder=""Double""/>" & _
        "  <Command CommandName=""SUPP_CURRENT_READBACK"" CommandCode=""1,05,01,15,01,02"" PropertyName=""SuppressorPowerSupply_Current_Readback"" Decoder=""Double""/>" & _
        "  <Command CommandName=""SUPP_CURRENT_PROGRAM"" CommandCode=""1,05,01,15,01,01"" PropertyName=""SuppressorPowerSupply_Current_Program"" Decoder=""Double""/>" & _
        "  <Command CommandName=""SUPP_VOLTAGE_ERROR_TOL"" CommandCode=""1,05,01,14,01,07"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""SUPP_VOLTAGE_WARNING_TOL"" CommandCode=""1,05,01,14,01,08"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""SUPP_VOLTAGE_ERROR_TIME"" CommandCode=""1,05,01,14,01,09"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""SUPP_VOLTAGE_WARNING_TIME"" CommandCode=""1,05,01,14,01,10"" PropertyName="""" Decoder=""""/>" & _
        "   <!-- Body- Discharge PowerSupply-->" & _
        "  <Command CommandName=""PBN_BODY_CURRENT_READBACK"" CommandCode=""1,05,01,17,01,02"" PropertyName=""BodyPowerSupply_Current_Readback"" Decoder=""Double""/>" & _
        "  <Command CommandName=""PBN_BODY_CURRENT_ERROR_TOL"" CommandCode=""1,05,01,17,01,07"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""PBN_BODY_CURRENT_WARNING_TOL"" CommandCode=""1,05,01,17,01,08"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""PBN_BODY_CURRENT_ERROR_TIME"" CommandCode=""1,05,01,17,01,09"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""PBN_BODY_CURRENT_WARNING_TIME"" CommandCode=""1,05,01,17,01,10"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""K_FACTOR_PROGRAM"" CommandCode=""1,05,01,19,01,01"" PropertyName=""BodyPowerSupply_KFactor_Program"" Decoder=""Double""/>" & _
        "  <Command CommandName=""K_FACTOR_READBACK"" CommandCode=""1,05,01,19,01,02"" PropertyName=""BodyPowerSupply_KFactor_Readback"" Decoder=""Double""/>" & _
        "  <Command CommandName=""PBN_FILAMENT_CURRENT_READBACK"" CommandCode=""1,05,01,18,01,02"" PropertyName=""DischargePowerSupply_Current_Readback"" Decoder=""Double""/>" & _
        "  <!-- RFPowerSupply-->" & _
        "  <Command CommandName=""INCIDENT_RF_PROGRAM"" CommandCode=""1,05,01,20,01,01"" PropertyName=""RFPowerSupply_ForwardPower_Program"" Decoder=""Double""/>" & _
        "  <Command CommandName=""FORWARD_RF_READBACK"" CommandCode=""1,05,01,20,01,02"" PropertyName=""RFPowerSupply_ForwardPower_Readback"" Decoder=""Double""/>" & _
        "  <Command CommandName=""REFLECTED_RF_PROGRAM"" CommandCode=""1,05,01,21,01,01"" PropertyName=""RFPowerSupply_ReflectedPower_Program"" Decoder=""Double""/>" & _
        "  <Command CommandName=""REFLECTED_RF_READBACK"" CommandCode=""1,05,01,21,01,02"" PropertyName=""RFPowerSupply_ReflectedPower"" Decoder=""Double""/>" & _
        "  <!-- ProcessMonitor-->" & _
        "  <Command CommandName=""PROCESS_CONTROL_NAME"" CommandCode=""1,05,01,22,01,02"" PropertyName=""Recipe"" Decoder=""String""/>" & _
        "  <Command CommandName=""PROCESS_ELAPSED_TIME"" CommandCode=""1,05,01,22,01,05"" PropertyName=""ElapsedTime"" Decoder=""String""/>" & _
        "  <Command CommandName=""PROCESS_CURRENT_STEP"" CommandCode=""1,05,01,22,01,03"" PropertyName=""ProcessMonitor_ProcessStep"" Decoder=""String""/>" & _
        "  <Command CommandName=""PROCESS_TOTAL_STEPS"" CommandCode=""1,05,01,22,01,04"" PropertyName=""ProcessMonitor_TotalStep"" Decoder=""String""/>" & _
        "  <Command CommandName=""PROCESS_REMAINING_TIME"" CommandCode=""1,05,01,22,01,06"" PropertyName=""RemainingTime"" Decoder=""String""/>" & _
        "  <Command CommandName=""PROCESS_ABORT_MESSAGE"" CommandCode=""1,05,01,22,01,07"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""PROCESS_LOT_ID"" CommandCode=""1,05,01,22,01,08"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""PROCESS_CASSETTE_ID"" CommandCode=""1,05,01,22,01,09"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""PROCESS_WAFER_ID"" CommandCode=""1,05,01,22,01,10"" PropertyName=""WaferID"" Decoder=""Integer""/>" & _
        "  <Command CommandName=""PROCESS_MODIFY_STEPTIME"" CommandCode=""1,05,01,22,01,14"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""PROCESS_STEPTIME_TIMEOUT"" CommandCode=""1,05,01,22,01,15"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""PROCESS_GEM_WAITFOR_STEPTIME"" CommandCode=""1,05,01,22,01,16"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""ELECTROSTATIC_SHUTTER_BYPASS"" CommandCode= ""1,05,01,28,01,01"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""ELECTROSTATIC_SHUTTER_TIMER"" CommandCode=""1,05,01,28,01,02"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""WAFER_ABORT_STATUS"" CommandCode=""1,05,01,30,01,01"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""MAX_SUPP_CURRENT"" CommandCode=""1,05,01,31,01,01"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""MAX_REF_RF"" CommandCode=""1,05,01,31,01,02"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""MIN_PBN_CURRENT"" CommandCode= ""1,05,01,31,01,03"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""MAX_PBN_CURRENT"" CommandCode=""1,05,01,31,01,04"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""SOURCE_USAGE_RESET"" CommandCode=""1,05,01,33,01,03"" PropertyName=""ResetSourceUsage"" Decoder=""String""/>" & _
        "  <Command CommandName=""SOURCE_GRID_ID"" CommandCode=""1,05,01,33,01,04"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""SOURCE_USAGE_TIMESET"" CommandCode=""1,05,01,33,01,01"" PropertyName=""SetSourceUsageTime"" Decoder=""String""/>" & _
        "  <Command CommandName=""SOURCE_MAGNET_MODE"" CommandCode=""1,05,01,34,01,05"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""SOURCE_MAGNET_SPEED"" CommandCode=""1,05,01,34,01,08"" PropertyName="""" Decoder=""""/>" & _
        "  " & _
        "  <Command CommandName=""BARATRON_VALVE"" CommandCode=""1,0x,0x,0x,0x,06"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""FIXTURE_HOME_ALL_AXIS"" CommandCode=""1,03,01,13,01,01,01"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""FIXTURE_STOP_ALL_AXIS"" CommandCode=""1,03,01,13,01,01,00"" PropertyName="""" Decoder=""""/>" & _
        "" & _
        "  <!--Pressure-->" & _
        "  <Command CommandName=""ION_GAUGE_STATUS"" CommandCode=""1,0x,0x,0x,01,17"" PropertyName=""IGStatus"" Decoder=""WorkingStatuses""/>" & _
        "  <Command CommandName=""ION_GAUGE_PRESSURE"" CommandCode=""1,02,01,08,01,01"" PropertyName=""IG"" Decoder=""Double""/> " & _
        "  <!--Body PowerSupply-->" & _
        "  <Command CommandName=""BODY_CURRENT_PROGRAM"" CommandCode=""1,0x,0x,0x,0x,21"" PropertyName=""BodyPowerSupply_Current_Program"" Decoder=""Double""/>" & _
        "   <!--Process Recipe -->  " & _
        "  <Command CommandName=""PROCESS_CONTROL_DEVICE_ERROR"" CommandCode=""1,05,01,22,01,01,-1"" PropertyName=""ProcessMonitor_DeviceError_Readback"" Decoder=""""/>" & _
        "  <Command CommandName=""PROCESS_CONTROL_DEVICE_STOP"" CommandCode=""1,05,01,22,01,01,00"" PropertyName=""ProcessMonitor_DeviceStop_Readback"" Decoder=""""/>" & _
        "  <Command CommandName=""PROCESS_CONTROL_DEVICE_START"" CommandCode=""1,05,01,22,01,01,01"" PropertyName=""ProcessMonitor_DeviceStart_Readback"" Decoder=""""/>" & _
        "  <Command CommandName=""PROCESS_CONTROL_DEVICE_PAUSE"" CommandCode=""1,05,01,22,01,01,02"" PropertyName=""ProcessMonitor_DevicePause_Readback"" Decoder=""""/>" & _
        "  <Command CommandName=""PROCESS_CONTROL_DEVICE_CONTINUE"" CommandCode=""1,05,01,22,01,01,03"" PropertyName=""ProcessMonitor_DeviceContinue_Readback"" Decoder=""""/>" & _
        "  <Command CommandName=""PROCESS_CONTROL_DEVICE_RESET_ERROR"" CommandCode=""1,05,01,22,01,01,04"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""PROCESS_CONTROL_DEVICE_END_STEP"" CommandCode=""1,05,01,22,01,01,05"" PropertyName="""" Decoder=""""/>" & _
        "  <!--Chamber Interlock-->" & _
        "   <Command CommandName=""VACUUM_PRESSURE_INTK"" CommandCode=""1,02,01,11,01,01"" PropertyName=""ChamberInterlocks_ChamberPress_Status"" Decoder=""WorkingStatuses""/>" & _
        "  <Command CommandName=""SOURCE_WATER_INTERLOCK"" CommandCode=""1,05,01,23,01,01"" PropertyName=""ChamberInterlocks_SourceWater_Status"" Decoder=""WorkingStatuses""/>" & _
        "  <Command CommandName=""FIXTURE_WATER_INTERLOCK"" CommandCode=""1,03,01,02,01,02"" PropertyName=""ChamberInterlocks_FixtureWater_Status"" Decoder=""WorkingStatuses""/>" & _
        "  <Command CommandName=""PANEL_INTERLOCK"" CommandCode=""1,01,01,09,01,01"" PropertyName=""ChamberInterlocks_PanelInterlock_Status"" Decoder=""WorkingStatuses""/>" & _
        "  <Command CommandName=""FORELINE_PRESSURE_INTK"" CommandCode=""1,02,01,12,01,01"" PropertyName=""ChamberInterlocks_Foreline_Status"" Decoder=""WorkingStatuses""/> " & _
        "  <Command CommandName=""TURBO_WATER_INTERLOCK"" CommandCode=""1,02,01,02,01,04"" PropertyName=""ChamberInterlocks_TurboWater_Status"" Decoder=""WorkingStatuses""/> " & _
        "  <Command CommandName=""AIR_PRESSURE_INTK"" CommandCode=""1,02,01,10,01,01"" PropertyName=""ChamberInterlocks_AirPressure_Status"" Decoder=""WorkingStatuses""/>" & _
        "  <Command CommandName=""FIXTURE_ROTATION"" CommandCode=""1,0x,0x,0x,0x,70"" PropertyName=""ChamberInterlocks_FixtureRotation_Status"" Decoder=""WorkingStatuses""/> " & _
        "	" & _
        "  <!--Convectron Gauge -->" & _
        "  <Command CommandName=""PIRANI_CHAMBER_ROUGH_PRESSURE"" CommandCode=""1,02,01,09,01,01"" PropertyName=""CG"" Decoder=""Double""/>" & _
        "  <!--Foreline CG -->" & _
        "  <Command CommandName=""PIRANI_FORELINE_PRESSURE"" CommandCode=""1,02,01,09,02,01"" PropertyName=""CGCFLCG_Information"" Decoder=""Double""/>" & _
        "  <!--Rough Pump CG -->" & _
        "  <Command CommandName=""PIRANI_ROUGH_PUMP_PRESSURE"" CommandCode=""1,02,01,09,03,01"" PropertyName=""CGCRLCG_Information"" Decoder=""Double""/>" & _
        "  <Command CommandName=""FLOWCOOL_PRESSURE"" CommandCode=""1,03,01,11,03,01"" PropertyName=""CGCMG_Information"" Decoder=""Double""/>" & _
        "  <!--Process Monitor -->" & _
        "  <Command CommandName=""PROCESS_STATUS_READBACK"" CommandCode=""1,0x,0x,0x,0x,57"" PropertyName=""ProcessStatus"" Decoder=""""/>" & _
        "  <Command CommandName=""PROCESS_STEP_TIME_READBACK"" CommandCode=""1,0x,0x,0x,0x,58"" PropertyName=""StepTime"" Decoder=""""/>" & _
        "  <!--Process Screen-->" & _
        "  <Command CommandName=""ETCH_POWER_READBACK"" CommandCode=""1,0x,0x,0x,0x,59"" PropertyName=""ProcessPanel_EtchPower"" Decoder=""Double""/>" & _
        "  <Command CommandName=""CHUCK_HEIGH_READBACK"" CommandCode=""1,0x,0x,0x,0x,60"" PropertyName=""ProcessPanel_ChuckHeigh"" Decoder=""Double""/>" & _
        "  <Command CommandName=""TARGET_POWER_READBACK"" CommandCode=""1,0x,0x,0x,0x,61"" PropertyName=""ProcessPanel_TargetPower"" Decoder=""Double""/>" & _
        "  <Command CommandName=""SOURCE_POWER_READBACK"" CommandCode=""1,0x,0x,0x,0x,62"" PropertyName=""ProcessPanel_SourePower"" Decoder=""Double""/>" & _
        "  <!--Wafer Processing Status -->" & _
        "  <Command CommandName=""WAFER_PROCESSING_STATUS_READBACK"" CommandCode=""1,03,01,21,01,01"" PropertyName=""WaferStatus"" Decoder=""Integer""/>" & _
        "  <Command CommandName=""EVENT_STATUS_READBACK"" CommandCode=""1,01,01,07,01,01"" PropertyName=""EventMessage"" Decoder=""""/>" & _
        "  <Command CommandName=""ALARM_STATUS_READBACK"" CommandCode=""1,01,01,08,01,01"" PropertyName=""StatusMessage"" Decoder=""""/>" & _
        "  " & _
        "  <!-- Gas Valve -->" & _
        "  <Command CommandName=""GAS1_SHUTOFF_VALVE"" CommandCode=""1,05,01,08,01,01"" PropertyName=""Gas1ShutOffValveStatus"" Decoder=""WorkingStatuses""/>" & _
        "  <Command CommandName=""GAS2_SHUTOFF_VALVE"" CommandCode=""1,05,01,08,02,01"" PropertyName=""Gas2ShutOffValveStatus"" Decoder=""WorkingStatuses""/>" & _
        "  <Command CommandName=""GAS3_SHUTOFF_VALVE"" CommandCode=""1,05,01,08,03,01"" PropertyName=""Gas3ShutOffValveStatus"" Decoder=""WorkingStatuses""/>" & _
        "  <Command CommandName=""GAS4_SHUTOFF_VALVE"" CommandCode=""1,05,01,08,04,01"" PropertyName=""Gas4ShutOffValveStatus"" Decoder=""WorkingStatuses""/>" & _
        "  <Command CommandName=""GAS5_SHUTOFF_VALVE"" CommandCode=""1,05,01,08,05,01"" PropertyName=""Gas5ShutOffValveStatus"" Decoder=""WorkingStatuses""/>" & _
        "  " & _
        "  <Command CommandName=""GAS1_SUPPLY_VALVE"" CommandCode=""1,05,01,08,01,02"" PropertyName=""Gas1SupplyValveStatus"" Decoder=""WorkingStatuses""/>" & _
        "  <Command CommandName=""GAS2_SUPPLY_VALVE"" CommandCode=""1,05,01,08,02,02"" PropertyName=""Gas2SupplyValveStatus"" Decoder=""WorkingStatuses""/>" & _
        "  <Command CommandName=""GAS3_SUPPLY_VALVE"" CommandCode=""1,05,01,08,03,02"" PropertyName=""Gas3SupplyValveStatus"" Decoder=""WorkingStatuses""/>" & _
        "  <Command CommandName=""GAS4_SUPPLY_VALVE"" CommandCode=""1,05,01,08,04,02"" PropertyName=""Gas4SupplyValveStatus"" Decoder=""WorkingStatuses""/>" & _
        "  <Command CommandName=""GAS5_SUPPLY_VALVE"" CommandCode=""1,05,01,08,05,02"" PropertyName=""Gas5SupplyValveStatus"" Decoder=""WorkingStatuses""/>" & _
        "" & _
        "  <Command CommandName=""GAS1_FLOWRATE_PROGRAM"" CommandCode=""1,05,01,08,01,03"" PropertyName=""Gas1FlowRateProgram"" Decoder=""Double""/>" & _
        "  <Command CommandName=""GAS2_FLOWRATE_PROGRAM"" CommandCode=""1,05,01,08,02,03"" PropertyName=""Gas2FlowRateProgram"" Decoder=""Double""/>" & _
        "  <Command CommandName=""GAS3_FLOWRATE_PROGRAM"" CommandCode=""1,05,01,08,03,03"" PropertyName=""Gas3FlowRateProgram"" Decoder=""Double""/>" & _
        "  <Command CommandName=""GAS4_FLOWRATE_PROGRAM"" CommandCode=""1,05,01,08,04,03"" PropertyName=""Gas4FlowRateProgram"" Decoder=""Double""/>" & _
        "  <Command CommandName=""GAS5_FLOWRATE_PROGRAM"" CommandCode=""1,05,01,08,05,03"" PropertyName=""Gas5FlowRateProgram"" Decoder=""Double""/>" & _
        "" & _
        "  <Command CommandName=""GAS1_FLOWRATE_READBACK"" CommandCode=""1,05,01,08,01,04"" PropertyName=""Gas1FlowRateReadback"" Decoder=""Double""/>" & _
        "  <Command CommandName=""GAS2_FLOWRATE_READBACK"" CommandCode=""1,05,01,08,02,04"" PropertyName=""Gas2FlowRateReadback"" Decoder=""Double""/>" & _
        "  <Command CommandName=""GAS3_FLOWRATE_READBACK"" CommandCode=""1,05,01,08,03,04"" PropertyName=""Gas3FlowRateReadback"" Decoder=""Double""/>" & _
        "  <Command CommandName=""GAS4_FLOWRATE_READBACK"" CommandCode=""1,05,01,08,04,04"" PropertyName=""Gas4FlowRateReadback"" Decoder=""Double""/>" & _
        "  <Command CommandName=""GAS5_FLOWRATE_READBACK"" CommandCode=""1,05,01,08,05,04"" PropertyName=""Gas5FlowRateReadback"" Decoder=""Double""/>" & _
        "" & _
        "  <Command CommandName=""GAS1_TYPE"" CommandCode=""1,05,01,08,01,05"" PropertyName=""Gas1Type"" Decoder=""""/>" & _
        "  <Command CommandName=""GAS2_TYPE"" CommandCode=""1,05,01,08,02,05"" PropertyName=""Gas2Type"" Decoder=""""/>" & _
        "  <Command CommandName=""GAS3_TYPE"" CommandCode=""1,05,01,08,03,05"" PropertyName=""Gas3Type"" Decoder=""""/>" & _
        "  <Command CommandName=""GAS4_TYPE"" CommandCode=""1,05,01,08,04,05"" PropertyName=""Gas4Type"" Decoder=""""/>" & _
        "  <Command CommandName=""GAS5_TYPE"" CommandCode=""1,05,01,08,05,05"" PropertyName=""Gas5Type"" Decoder=""""/>" & _
        "  " & _
        "  <Command CommandName=""GAS1_MAX_RANGE"" CommandCode=""1,05,01,08,01,06"" PropertyName=""Gas1MaxRange"" Decoder=""Double""/>" & _
        "  <Command CommandName=""GAS2_MAX_RANGE"" CommandCode=""1,05,01,08,02,06"" PropertyName=""Gas2MaxRange"" Decoder=""Double""/>" & _
        "  <Command CommandName=""GAS3_MAX_RANGE"" CommandCode=""1,05,01,08,03,06"" PropertyName=""Gas3MaxRange"" Decoder=""Double""/>" & _
        "  <Command CommandName=""GAS4_MAX_RANGE"" CommandCode=""1,05,01,08,04,06"" PropertyName=""Gas4MaxRange"" Decoder=""Double""/>" & _
        "  <Command CommandName=""GAS5_MAX_RANGE"" CommandCode=""1,05,01,08,05,06"" PropertyName=""Gas5MaxRange"" Decoder=""Double""/>" & _
        "" & _
        "  " & _
        "    <!--Gas Controller-->" & _
        "  <Command CommandName=""GAS_CONTROLLER_ARGON_PROGRAM"" CommandCode=""1,0x,0x,0x,0x,14"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""GAS_CONTROLLER_OXYGEN_PROGRAM"" CommandCode=""1,0x,0x,0x,0x,15"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""GAS_CONTROLLER_FLOW_COOL_HE_PROGRAM"" CommandCode=""1,0x,0x,0x,0x,16"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""GAS_CONTROLLER_ARGON_READBACK"" CommandCode=""1,0x,0x,0x,01,16"" PropertyName="""" Decoder=""Double""/>" & _
        "  <Command CommandName=""GAS_CONTROLLER_FLOWCOOLHE_READBACK"" CommandCode=""1,0x,0x,0x,02,16"" PropertyName="""" Decoder=""Double""/>" & _
        "  <Command CommandName=""GAS_CONTROLLER_OXYGEN_READBACK"" CommandCode=""1,0x,0x,0x,03,16"" PropertyName="""" Decoder=""""/>" & _
        "  " & _
        "  <!--Remove-->" & _
        "  <Command CommandName=""GAS_TARGET_FLOWRATE_A_PROGRAM"" CommandCode=""x,05,01,08,01,03"" PropertyName=""GasController_Argon_Program"" Decoder=""Double""/>" & _
        "  <Command CommandName=""GAS_ACTUAL_FLOWRATE_A_READBACK"" CommandCode=""x,05,01,08,01,04"" PropertyName=""GasController_Argon_Readback"" Decoder=""Double""/>" & _
        "  <Command CommandName=""GAS_ACTUAL_FLOWRATE_O_READBACK"" CommandCode=""x,05,01,08,02,04"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""GAS_TYPE"" CommandCode=""x,05,01,08,01,05"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""GAS_MFC_MAX_RANGE"" CommandCode=""x,05,01,08,01,06"" PropertyName="""" Decoder=""""/>" & _
        "  " & _
        "  <Command CommandName=""GAS_FLOWRATE_ERROR_TOL"" CommandCode=""1,05,01,08,01,07"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""GAS_FLOWRATE_WARNING_TOL"" CommandCode=""1,05,01,08,01,08"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""GAS_FLOWRATE_ERROR_TIME"" CommandCode=""1,05,01,08,01,09"" PropertyName="""" Decoder=""""/>" & _
        "  <Command CommandName=""GAS_FLOWRATE_WARNING_TIME"" CommandCode=""1,05,01,08,01,10"" PropertyName="""" Decoder=""""/>" & _
        "  " & _
        "  " & _
        "  " & _
        "</IBEServer>"
    End Class
End Namespace
