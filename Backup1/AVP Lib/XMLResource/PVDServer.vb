Namespace XMLResources
Public Class PVDServer
Public Const XMLText as String = _
"<PVDServer>	" & _
"<Command CommandName=""REQUEST_ALL_DATA"" CommandCode=""X,24,04,01,01,01"" PropertyName="""" Decoder=""""/>" & _
"<!--RF Target Power Supply -->" & _
"<Command CommandName=""RF_TARGET_FORWARD_POWER_READBACK"" CommandCode=""X,01,01,01,01,01"" PropertyName=""RFTargetPowerSupply_ForwardPower_Readback"" Decoder=""Double""/>" & _
"<Command CommandName=""RF_TARGET_FORWARD_POWER_PROGRAM"" CommandCode=""X,01,01,01,01,02"" PropertyName=""RFTargetPowerSupply_ForwardPower_Program"" Decoder=""Double""/>" & _
"<Command CommandName=""RF_TARGET_REFLECTED_POWER_READBACK"" CommandCode=""X,01,02,01,01,01"" PropertyName=""RFTargetPowerSupply_ReflectedPower_Readback"" Decoder=""Double""/>" & _
"<Command CommandName=""RF_TARGET_VOLTAGE_POWER_READBACK"" CommandCode=""X,01,03,01,01,01"" PropertyName=""RFTargetPowerSupply_Voltage_Readback"" Decoder=""Double""/>" & _
"<Command CommandName=""RF_TARGET_C1_READBACK"" CommandCode=""X,18,04,01,01,01"" PropertyName=""RFTargetPowerSupply_C1_Readback"" Decoder=""Double""/>" & _
"<Command CommandName=""RF_TARGET_C1_PROGRAM"" CommandCode=""X,18,04,01,01,02"" PropertyName=""RFTargetPowerSupply_C1_Program"" Decoder=""Double""/>" & _
"<Command CommandName=""RF_TARGET_C2_READBACK"" CommandCode=""X,18,05,01,01,01"" PropertyName=""RFTargetPowerSupply_C2_Readback"" Decoder=""Double""/>" & _
"<Command CommandName=""RF_TARGET_C2_PROGRAM"" CommandCode=""X,18,05,01,01,02"" PropertyName=""RFTargetPowerSupply_C2_Program"" Decoder=""Double""/>" & _
"<Command CommandName=""RF_TARGET_MATCH_READBACK"" CommandCode=""X,18,06,01,01,01"" PropertyName=""RFTargetPowerSupply_Match_Readback"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""RF_TARGET_AUTO"" CommandCode=""X,18,06,01,01,02"" PropertyName=""RFTargetPowerSupply_AutoStatus"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""RF_TARGET_PRESETS_READBACK"" CommandCode=""X,18,07,01,01,01"" PropertyName=""RFTargetPowerSupply_Presets_Readback"" Decoder=""Double""/>" & _
"<Command CommandName=""RF_TARGET_PRESETS_PROGRAM"" CommandCode=""X,18,07,01,01,02"" PropertyName=""RFTargetPowerSupply_Presets_Program"" Decoder=""Double""/>" & _
"<Command CommandName=""RF_TARGET_RECALL"" CommandCode=""X,18,08,01,01,02"" PropertyName=""RFTargetPowerSupply_RecallStatus"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""RF_TARGET_STORE"" CommandCode=""X,18,09,01,01,02"" PropertyName=""RFTargetPowerSupply_StoreStatus"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""RF_TARGET_KWH"" CommandCode=""X,01,04,01,01,01"" PropertyName=""RFTargetPowerSupply_KWH_Readback"" Decoder=""Double""/>" & _
"<Command CommandName=""RF_TARGET_COMMUNICATION_STATUS"" CommandCode=""X,18,10,01,01,01"" PropertyName=""RFTargetPowerSupply_CommunicationStatus"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""RF_TARGET_MAG"" CommandCode=""X,18,12,01,01,01"" PropertyName=""RFTargetPowerSupply_Mag"" Decoder=""Double""/>" & _
"<Command CommandName=""RF_TARGET_PHASE"" CommandCode=""X,18,13,01,01,01"" PropertyName=""RFTargetPowerSupply_Phase"" Decoder=""Double""/>" & _
"<Command CommandName=""RF_TARGET_ERROR_STATUS"" CommandCode=""X,18,14,01,01,01"" PropertyName=""RFTargetPowerSupply_ErrorStatus"" Decoder=""""/>" & _
"<!--DC Target Power Supply -->" & _
"<Command CommandName=""DC_TARGET_POWER_READBACK"" CommandCode=""X,19,11,01,01,01"" PropertyName=""DCTargetPowerSupply_Power_Readback"" Decoder=""Double""/>" & _
"<Command CommandName=""DC_TARGET_POWER_PROGRAM"" CommandCode=""X,19,11,01,01,02"" PropertyName=""DCTargetPowerSupply_Power_Program"" Decoder=""Double""/>" & _
"<Command CommandName=""DC_TARGET_VOLTAGE_READBACK"" CommandCode=""X,19,12,01,01,01"" PropertyName=""DCTargetPowerSupply_Voltage_Readback"" Decoder=""Double""/>" & _
"<Command CommandName=""DC_TARGET_VOLTAGE_PROGRAM"" CommandCode=""X,19,12,01,01,02"" PropertyName=""DCTargetPowerSupply_Voltage_Program"" Decoder=""Double""/>" & _
"<Command CommandName=""DC_TARGET_CURRENT_READBACK"" CommandCode=""X,19,13,01,01,01"" PropertyName=""DCTargetPowerSupply_Current_Readback"" Decoder=""Double""/>" & _
"<Command CommandName=""DC_TARGET_CURRENT_PROGRAM"" CommandCode=""X,19,13,01,01,02"" PropertyName=""DCTargetPowerSupply_Current_Program"" Decoder=""Double""/>" & _
"<Command CommandName=""DC_TARGET_MAGNETRON_PROGRAM"" CommandCode=""X,16,01,01,01,01"" PropertyName=""DCTargetPowerSupply_MagnetronRotationStatus"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""DC_TARGET_DCPULSE_READBACK"" CommandCode=""X,21,15,01,01,01"" PropertyName=""DCTargetPowerSupply_DCPulse_Readback"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""DC_TARGET_DCPULSE_PROGRAM"" CommandCode=""X,21,15,01,01,02"" PropertyName=""DCTargetPowerSupply_DCPulseStatus"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""DC_TARGET_RAMPTIME_READBACK"" CommandCode=""X,19,16,01,01,01"" PropertyName=""DCTargetPowerSupply_Ramptime_Readback"" Decoder=""Double""/>" & _
"<Command CommandName=""DC_TARGET_RAMPTIME_PROGRAM"" CommandCode=""X,19,16,01,01,02"" PropertyName=""DCTargetPowerSupply_Ramptime_Program"" Decoder=""Double""/>" & _
"<Command CommandName=""DC_TARGET_KWH"" CommandCode=""X,19,14,01,01,01"" PropertyName=""DCTargetPowerSupply_KWH_Readback"" Decoder=""Double""/>" & _
"<Command CommandName=""DC_TARGET_COMMUNICATION_STATUS"" CommandCode=""X,21,16,01,01,01"" PropertyName=""DCTargetPowerSupply_CommunicationStatus"" Decoder=""WorkingStatuses""/>" & _
"<!--Bias Forward Power Supply-->" & _
"<Command CommandName=""BIAS_FORWARD_POWER_READBACK"" CommandCode=""X,02,01,01,01,01"" PropertyName=""BiasPowerSupply_ForwardPower_Readback"" Decoder=""Double""/>" & _
"<Command CommandName=""BIAS_FORWARD_POWER_PROGRAM"" CommandCode=""X,02,01,01,01,02"" PropertyName=""BiasPowerSupply_ForwardPower_Program"" Decoder=""Double""/>" & _
"<Command CommandName=""BIAS_REFLECTED_POWER_READBACK"" CommandCode=""X,02,02,01,01,01"" PropertyName=""BiasPowerSupply_ReflectedPower_Readback"" Decoder=""Double""/>" & _
"<Command CommandName=""BIAS_VOLTAGE_POWER_READBACK"" CommandCode=""X,02,03,01,01,01"" PropertyName=""BiasPowerSupply_Voltage_Readback"" Decoder=""Double""/>" & _
"<Command CommandName=""BIAS_VOLTAGE_POWER_PROGRAM"" CommandCode=""X,15,15,01,01,02"" PropertyName=""BiasPowerSupply_Voltage_Program"" Decoder=""Double""/>" & _
"<Command CommandName=""BIAS_C1_READBACK"" CommandCode=""X,02,04,01,01,01"" PropertyName=""BiasPowerSupply_C1_Readback"" Decoder=""Double""/>" & _
"<Command CommandName=""BIAS_C1_PROGRAM"" CommandCode=""X,02,04,01,01,02"" PropertyName=""BiasPowerSupply_C1_Program"" Decoder=""Double""/>" & _
"<Command CommandName=""BIAS_C2_READBACK"" CommandCode=""X,02,05,01,01,01"" PropertyName=""BiasPowerSupply_C2_Readback"" Decoder=""Double""/>" & _
"<Command CommandName=""BIAS_C2_PROGRAM"" CommandCode=""X,02,05,01,01,02"" PropertyName=""BiasPowerSupply_C2_Program"" Decoder=""Double""/>" & _
"<Command CommandName=""BIAS_MATCH_READBACK"" CommandCode=""X,02,06,01,01,01"" PropertyName=""BiasPowerSupply_Match_Readback"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""BIAS_AUTO"" CommandCode=""X,02,06,01,01,02"" PropertyName=""BiasPowerSupply_AutoStatus"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""BIAS_PRESETS_READBACK"" CommandCode=""X,02,07,01,01,01"" PropertyName=""BiasPowerSupply_Presets_Readback"" Decoder=""Double""/>" & _
"<Command CommandName=""BIAS_PRESETS_PROGRAM"" CommandCode=""X,02,07,01,01,02"" PropertyName=""BiasPowerSupply_Presets_Program"" Decoder=""Double""/>" & _
"<Command CommandName=""BIAS_RECALL"" CommandCode=""X,02,08,01,01,02"" PropertyName=""BiasPowerSupply_RecallStatus"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""BIAS_STORE"" CommandCode=""X,02,09,01,01,02"" PropertyName=""BiasPowerSupply_StoreStatus"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""BIAS_COMMUNICATION_STATUS"" CommandCode=""X,02,10,01,01,01"" PropertyName=""BiasPowerSupply_CommunicationStatus"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""BIAS_TARGET_MAG"" CommandCode=""X,02,12,01,01,01"" PropertyName=""BiasTargetPowerSupply_Mag"" Decoder=""Double""/>" & _
"<Command CommandName=""BIAS_TARGET_PHASE"" CommandCode=""X,02,13,01,01,01"" PropertyName=""BiasTargetPowerSupply_Phase"" Decoder=""Double""/>" & _
"<Command CommandName=""BIAS_TARGET_ERROR_STATUS"" CommandCode=""X,02,14,01,01,01"" PropertyName=""BiasTargetPowerSupply_ErrorStatus"" Decoder=""""/>" & _
"<Command CommandName=""BIAS_POWER_KWH_READBACK"" CommandCode=""X,02,16,01,01,01"" PropertyName=""BiasPowerKWHReadback"" Decoder=""Double""/>" & _
"<Command CommandName=""BIAS_POWER_KWH_PROGRAM"" CommandCode=""X,02,16,01,01,02"" PropertyName=""BiasPowerKWHProgram"" Decoder=""Double""/>" & _
"<!--Parallel Magnet -->" & _
"<Command CommandName=""PARALLEL_CURRENT_PROGRAM"" CommandCode=""X,03,01,01,01,02"" PropertyName=""ParallelMagnet_Current_Program"" Decoder=""Double""/>" & _
"<Command CommandName=""PARALLEL_CURRENT_READBACK"" CommandCode=""X,03,01,01,01,01"" PropertyName=""ParallelMagnet_Current_Readback"" Decoder=""Double""/>" & _
"<Command CommandName=""PARALLEL_DUTY_PROGRAM"" CommandCode=""X,03,02,01,01,02"" PropertyName=""ParallelMagnet_Duty_Program"" Decoder=""Double""/>" & _
"<Command CommandName=""PARALLEL_FREQUENCY_PROGRAM"" CommandCode=""X,03,03,01,01,02"" PropertyName=""ParallelMagnet_Frequency_Program"" Decoder=""Double""/>" & _
"<Command CommandName=""PARALLEL_VOLTAGE_READBACK"" CommandCode=""X,03,04,01,01,01"" PropertyName=""ParallelMagnet_Voltage_Readback"" Decoder=""Double""/>" & _
"<Command CommandName=""PARALLEL_STATUS_READBACK"" CommandCode=""X,03,05,01,01,02"" PropertyName=""ParallelMagnet_Status"" Decoder=""WorkingStatuses""/>" & _
"<!--Gas Controller-->" & _
"<Command CommandName=""GASCONTROLLER_GAS1_PROGRAM"" CommandCode=""X,04,01,01,01,02"" PropertyName=""GasController_Gas1_Program"" Decoder=""Double""/>" & _
"<Command CommandName=""GASCONTROLLER_GAS1_READBACK"" CommandCode=""X,04,01,01,01,01"" PropertyName=""GasController_Gas1_Readback"" Decoder=""Double""/>" & _
"<Command CommandName=""GASCONTROLLER_GAS2_PROGRAM"" CommandCode=""X,04,02,01,01,02"" PropertyName=""GasController_Gas2_Program"" Decoder=""Double""/>" & _
"<Command CommandName=""GASCONTROLLER_GAS2_READBACK"" CommandCode=""X,04,02,01,01,01"" PropertyName=""GasController_Gas2_Readback"" Decoder=""Double""/>" & _
"<Command CommandName=""GASCONTROLLER_GAS3_PROGRAM"" CommandCode=""X,04,03,01,01,02"" PropertyName=""GasController_Gas3_Program"" Decoder=""Double""/>" & _
"<Command CommandName=""GASCONTROLLER_GAS3_READBACK"" CommandCode=""X,04,03,01,01,01"" PropertyName=""GasController_Gas3_Readback"" Decoder=""Double""/>" & _
"<Command CommandName=""GASCONTROLLER_GAS4_PROGRAM"" CommandCode=""X,04,04,01,01,02"" PropertyName=""GasController_Gas4_Program"" Decoder=""Double""/>" & _
"<Command CommandName=""GASCONTROLLER_GAS4_READBACK"" CommandCode=""X,04,04,01,01,01"" PropertyName=""GasController_Gas4_Readback"" Decoder=""Double""/>" & _
"<Command CommandName=""GASCONTROLLER_GAS5_PROGRAM"" CommandCode=""X,04,05,01,01,02"" PropertyName=""GasController_Gas5_Program"" Decoder=""Double""/>" & _
"<Command CommandName=""GASCONTROLLER_GAS5_READBACK"" CommandCode=""X,04,05,01,01,01"" PropertyName=""GasController_Gas5_Readback"" Decoder=""Double""/>" & _
"<!--Chamber Interlock -->" & _
"<Command CommandName=""CHAMBERINTERLOCK_CHUCKWATER_STATUS"" CommandCode=""X,05,01,01,01,01"" PropertyName=""ChamberInterlocks_ChuckWaterStatus"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""CHAMBERINTERLOCK_TARGETWATER_STATUS"" CommandCode=""X,05,02,01,01,01"" PropertyName=""ChamberInterlocks_TargetWaterStatus"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""CHAMBERINTERLOCK_LIDWATER_STATUS"" CommandCode=""X,05,03,01,01,01"" PropertyName=""ChamberInterlocks_LidWaterStatus"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""CHAMBERINTERLOCK_CHAMBERPRESSURE_STATUS"" CommandCode=""X,05,04,01,01,01"" PropertyName=""ChamberInterlocks_ChamPressStatus"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""CHAMBERINTERLOCK_CHAMBERWATER_STATUS"" CommandCode=""X,05,05,01,01,01"" PropertyName=""ChamberInterlocks_ChamWaterStatus"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""CHAMBERINTERLOCK_PSRELAY_STATUS"" CommandCode=""X,05,06,01,01,02"" PropertyName=""ChamberInterlocks_PSRelayStatus"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""CHAMBERINTERLOCK_TURBOWATER_STATUS"" CommandCode=""X,05,07,01,01,01"" PropertyName=""ChamberInterlocks_TurboWaterStatus"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""CHAMBERINTERLOCK_TURBOFORELINE_STATUS"" CommandCode=""X,05,08,01,01,01"" PropertyName=""ChamberInterlocks_TurboForelineStatus"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""CHAMBERINTERLOCK_CLAMPWATER_STATUS"" CommandCode=""X,05,09,01,01,01"" PropertyName=""ChamberInterlocks_ClampWaterStatus"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""CHAMBERINTERLOCK_LIDSENSOR_STATUS"" CommandCode=""X,05,10,01,01,01"" PropertyName=""ChamberInterlocks_LidSensorStatus"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""CHAMBERINTERLOCK_TARGETMBWATER_STATUS"" CommandCode=""X,05,11,01,01,01"" PropertyName=""ChamberInterlocks_TargetMBWaterStatus"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""CHAMBERINTERLOCK_SUBMBWATER_STATUS"" CommandCode=""X,05,14,01,01,01"" PropertyName=""ChamberInterlocks_SubMBWaterStatus"" Decoder=""WorkingStatuses""/>" & _
"<!--Process Monitor -->" & _
"<Command CommandName=""PROCESS_PROCESS_STEP"" CommandCode=""X,06,04,01,01,01"" PropertyName=""ProcessStep"" Decoder=""""/>" & _
"<Command CommandName=""PROCESS_PROCESS_TIME"" CommandCode=""X,06,03,01,01,01"" PropertyName=""ProcessMonitor_ProcessTime_Readback"" Decoder=""""/>" & _
"<Command CommandName=""PROCESS_RECIPE"" CommandCode=""X,06,01,01,01,01"" PropertyName=""Recipe"" Decoder=""""/>" & _
"<Command CommandName=""PROCESS_STEPTIME"" CommandCode=""X,06,05,01,01,01"" PropertyName=""StepTime"" Decoder=""""/>" & _
"<Command CommandName=""PROCESS_STATUS"" CommandCode=""X,06,07,01,01,01"" PropertyName=""ProcessMonitor_Status_Readback"" Decoder=""""/>" & _
"<!--Run Recipe -->" & _
"<Command CommandName=""PROCESS_CONTROL_DEVICE_RESET_ERROR"" CommandCode=""X,07,01,01,01,02,04"" PropertyName=""ProcessMonitor_ResetError_Readback"" Decoder=""""/>" & _
"<Command CommandName=""PROCESS_CONTROL_DEVICE_START"" CommandCode=""X,07,01,01,01,02,01"" PropertyName=""ProcessMonitor_DeviceStart_Readback"" Decoder=""""/>" & _
"<Command CommandName=""PROCESS_CONTROL_DEVICE_STOP"" CommandCode=""X,07,01,01,01,02,00"" PropertyName=""ProcessMonitor_DeviceStop_Readback"" Decoder=""""/>" & _
"<Command CommandName=""PROCESS_CONTROL_DEVICE_PAUSE"" CommandCode=""X,07,01,01,01,02,02"" PropertyName=""ProcessMonitor_DevicePause_Readback"" Decoder=""""/>" & _
"<Command CommandName=""PROCESS_CONTROL_DEVICE_CONTINUE"" CommandCode=""X,07,01,01,01,02,03"" PropertyName=""ProcessMonitor_DeviceResume_Readback"" Decoder=""""/>" & _
"<Command CommandName=""PROCESS_CONTROL_DEVICE_ABORT"" CommandCode=""X,07,01,01,01,02,05"" PropertyName="""" Decoder=""""/>" & _
"<Command CommandName=""PROCESS_CONTROL_SEND_RECIPE_NAME"" CommandCode=""X,07,02,01,01,02"" PropertyName=""ProcessMonitor_DeviceSendRecipeName_Readback"" Decoder=""""/>" & _
"<Command CommandName=""PROCESS_CONTROL_SEND_RUN_DATA_FILE_NAME"" CommandCode=""X,07,04,01,01,02"" PropertyName="""" Decoder=""""/>" & _
"<Command CommandName=""PROCESS_CONTROL_DEVICE_ERROR"" CommandCode=""X,07,01,01,01,02,-1"" PropertyName=""ProcessMonitor_DeviceError_Readback"" Decoder=""""/>" & _
"<Command CommandName=""PROCESS_CONTROL_GET_RUN_DATA_FILE_NAME"" CommandCode=""X,07,04,01,01,01"" PropertyName=""ProcessControl_GetRunDataFileName"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""WAFER_STATUS"" CommandCode=""X,07,03,01,01,02"" PropertyName=""WaferStatus"" Decoder=""Integer""/>" & _
"<Command CommandName=""CURRENT_AVP_TIME"" CommandCode=""X,07,05,01,01,01"" PropertyName=""Current_AVP_Time"" Decoder=""String""/>" & _
"<!--Valves -->" & _
"<Command CommandName=""SHUTOFF1_VALVE_STATUS"" CommandCode=""X,12,11,01,01,02"" PropertyName=""ShutOff1ValveStatus"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""SHUTOFF2_VALVE_STATUS"" CommandCode=""X,12,12,01,01,02"" PropertyName=""ShutOff2ValveStatus"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""SHUTOFF3_VALVE_STATUS"" CommandCode=""X,12,13,01,01,02"" PropertyName=""ShutOff3ValveStatus"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""SHUTOFF4_VALVE_STATUS"" CommandCode=""X,12,14,01,01,02"" PropertyName=""ShutOff4ValveStatus"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""SHUTOFF5_VALVE_STATUS"" CommandCode=""X,12,15,01,01,02"" PropertyName=""ShutOff5ValveStatus"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""SUPPLY1_VALVE_STATUS"" CommandCode=""X,12,16,01,01,02"" PropertyName=""Supply1ValveStatus"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""SUPPLY2_VALVE_STATUS"" CommandCode=""X,12,17,01,01,02"" PropertyName=""Supply2ValveStatus"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""SUPPLY3_VALVE_STATUS"" CommandCode=""X,12,18,01,01,02"" PropertyName=""Supply3ValveStatus"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""SUPPLY4_VALVE_STATUS"" CommandCode=""X,12,19,01,01,02"" PropertyName=""Supply4ValveStatus"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""SUPPLY5_VALVE_STATUS"" CommandCode=""X,12,20,01,01,02"" PropertyName=""Supply5ValveStatus"" Decoder=""WorkingStatuses""/>" & _
"<!--Others Valves-->" & _
"<Command CommandName=""AUTO_ZERO_VAT_VALVE_STATUS"" CommandCode=""X,12,02,01,01,02"" PropertyName=""HivacValveStatus"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""MAIN_GAS_VALVE_STATUS"" CommandCode=""X,12,28,01,01,02"" PropertyName=""MainGasValveStatus"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""HIVAC_VALVE_STATUS"" CommandCode=""X,12,01,01,01,02"" PropertyName=""HivacValveStatus"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""BARATRON_VALVE_STATUS"" CommandCode=""X,12,05,01,01,02"" PropertyName=""BaratronValveStatus"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""VENT_VALVE_STATUS"" CommandCode=""X,12,06,01,01,02"" PropertyName=""VentValveStatus"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""ROUGH_VALVE_STATUS"" CommandCode=""X,12,07,01,01,02"" PropertyName=""RoughValveStatus"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""PLASMA_IGNITER_VALVE_STATUS"" CommandCode=""X,12,08,01,01,02"" PropertyName=""PlasmaIgniterStatus"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""TURBO_ISOLATION_VALVE_STATUS"" CommandCode=""X,12,10,01,01,02"" PropertyName=""Turbo_IsolationValveStatus"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""SHUTTER_VALVE_STATUS"" CommandCode=""X,12,09,01,01,02"" PropertyName=""Shutter_ValveStatus"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""WATER_VALVE_STATUS"" CommandCode=""X,12,26,01,01,02"" PropertyName=""WaterValveStatus"" Decoder=""WorkingStatuses""/>" & _
"" & _
"<!--Vat Valve Controller -->" & _
"<Command CommandName=""VAT_VALVE_CONTROLLER_PRESSURE"" CommandCode=""X,08,02,01,01,02"" PropertyName=""VatValve_Pressure_Program"" Decoder=""Double""/>" & _
"<Command CommandName=""VAT_VALVE_CONTROLLER_PRESSURE_PERCENT"" CommandCode=""X,12,27,01,01,02"" PropertyName=""VatValve_PressurePercent_Program"" Decoder=""Double""/><!--xuong-->" & _
"<Command CommandName=""VAT_VALVE_CONTROLLER_TEACH"" CommandCode=""X,08,01,01,01,02"" PropertyName=""VatValve_Teach_Program"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""VAT_VALVE_COMMUNICATION_STATUS"" CommandCode=""X,08,03,01,01,01"" PropertyName=""VatValve_CommunicationStatus"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""VAT_VALVE_PERCENTAGE"" CommandCode=""X,08,04,01,01,01"" PropertyName=""VatValve_Percentage"" Decoder=""Double""/><!--len -->" & _
"<Command CommandName=""VAT_VALVE_CONTROLLER_SIZEADJUST"" CommandCode=""X,08,05,01,01,02"" PropertyName=""VatValve_SizeAdjust_Program"" Decoder=""WorkingStatuses""/>" & _
"<!--Cryo-->" & _
"<Command CommandName=""CRYO_T1_READBACK"" CommandCode=""X,09,01,01,01,01"" PropertyName=""Cryo_T1_Readback"" Decoder=""Double""/>" & _
"<Command CommandName=""CRYO_T2_READBACK"" CommandCode=""X,09,02,01,01,01"" PropertyName=""Cryo_T2_Readback"" Decoder=""Double""/>" & _
"<Command CommandName=""CRYO_COMMUNICATION_STATUS"" CommandCode=""X,09,03,01,01,01"" PropertyName=""Cryo_CommunicationStatus"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""CRYO_REGEN"" CommandCode=""X,09,05,01,01,02"" PropertyName=""MachineCryoRegn"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""CRYO_REGEN_STATUS_TEXT"" CommandCode=""X,09,08,01,01,01"" PropertyName=""CryoRegenStatusText"" Decoder=""String""/>" & _
"<Command CommandName=""CRYO_REGEN_HOUR_READBACK"" CommandCode=""X,09,06,01,01,01"" PropertyName=""Cryo_RegenHour_Readback"" Decoder=""Double""/>" & _
"<Command CommandName=""CRYO_LIFETIME_HOUR_READBACK"" CommandCode=""X,09,07,01,01,01"" PropertyName=""Cryo_LifeTimeHour_Readback"" Decoder=""Double""/>" & _
"<!--Chuck-->" & _
"<Command CommandName=""CHUCK_POS_READBACK"" CommandCode=""X,10,01,01,01,01"" PropertyName=""ChuckPos_Readback"" Decoder=""Double""/>" & _
"<Command CommandName=""CHUCK_POS_PROGRAM"" CommandCode=""X,10,01,01,01,02"" PropertyName=""ChuckPos_Program"" Decoder=""Double""/>" & _
"<Command CommandName=""CLAMP_STATUS_READBACK"" CommandCode=""X,10,02,01,01,01"" PropertyName=""ClampStatus_Readback"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""CLAMP_STATUS_PROGRAM"" CommandCode=""X,10,02,01,01,02"" PropertyName=""ClampStatus_Program"" Decoder=""WorkingStatuses""/>" & _
"<!--Baratron-->" & _
"<Command CommandName=""BARATRON_BA_READBACK"" CommandCode=""X,11,03,01,01,01"" PropertyName=""ProcessPressure"" Decoder=""Double""/>" & _
"<Command CommandName=""BARATRON_CG_PROGRAM"" CommandCode=""X,11,04,01,01,02"" PropertyName=""Baratron_CG_Program"" Decoder=""Double""/>" & _
"<Command CommandName=""BARATRON_CG_READBACK"" CommandCode=""X,11,04,01,01,01"" PropertyName=""CG"" Decoder=""Double""/>" & _
"<Command CommandName=""BARATRON_IG_READBACK"" CommandCode=""X,11,02,01,01,01"" PropertyName=""IG"" Decoder=""Double""/>" & _
"<Command CommandName=""BARATRON_IG_STATUS"" CommandCode=""X,11,01,01,01,02"" PropertyName=""IGStatus"" Decoder=""WorkingStatuses""/>" & _
"<!--Other-->" & _
"<Command CommandName=""MG_VALUE"" CommandCode=""X,13,01,01,01,01"" PropertyName=""MG_Information"" Decoder=""Double""/>" & _
"<Command CommandName=""CG_VALUE"" CommandCode=""X,13,02,01,01,01"" PropertyName=""CG_Information"" Decoder=""Double""/>" & _
"<Command CommandName=""OVERRIDEMODE_STATUS"" CommandCode=""X,24,01,01,01,01"" PropertyName=""OverrideMode_Status"" Decoder=""WorkingStatuses""/>" & _
"<!--KWH Warning Limit-->" & _
"<Command CommandName=""TARGET_KWH_WARNING_LIMIT"" CommandCode=""X,25,01,01,01,02"" PropertyName="""" Decoder=""""/>" & _
"<!--KWH Alarm Limit-->" & _
"<Command CommandName=""TARGET_KWH_ALARM_LIMIT"" CommandCode=""X,25,02,01,01,02"" PropertyName="""" Decoder=""""/>" & _
"<!--KWH Max-->" & _
"<Command CommandName=""MAX_USAGE_KWH"" CommandCode=""X,25,03,01,01,02"" PropertyName="""" Decoder=""""/>" & _
"" & _
"<Command CommandName=""SHIELD_KWH"" CommandCode=""X,01,05,01,01,01"" PropertyName=""Shields_Quart_KWH"" Decoder=""Double""/>" & _
"<!-- -->" & _
"<Command CommandName=""ROUGHLINE_CG_VALUE"" CommandCode=""X,14,03,01,01,01"" PropertyName=""RoughLineCG_Readback"" Decoder=""Double""/>" & _
"<Command CommandName=""FORELINE_CG_VALUE"" CommandCode=""X,14,02,01,01,01"" PropertyName=""ForeLineCG_Readback"" Decoder=""Double""/>" & _
"<!--Magnatron Panel -->" & _
"<Command CommandName=""MAGNATRON_ROTATION_START"" CommandCode=""X,16,02,01,01,02"" PropertyName=""Magnatron_RotationStartStatus"" Decoder=""WorkingStatuses""/>" & _
"<!--Turbo Pump & Water Pump-->" & _
"<Command CommandName=""WATER_PUMP_T_READBACK"" CommandCode=""X,17,01,01,01,01"" PropertyName=""TurboPump_T_Readback"" Decoder=""Double""/>" & _
"<Command CommandName=""WATER_PUMP_STATUS"" CommandCode=""X,17,02,01,01,01"" PropertyName=""WaterPump_Status"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""WATER_PUMP_REGEN_STATUS"" CommandCode=""X,17,03,01,01,02"" PropertyName=""WaterPumpRegen_Status"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""WATER_PUMP_STATE_STATUS"" CommandCode=""X,17,04,01,01,02"" PropertyName=""WaterPumpState_Status"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""WATER_PUMP_REGEN_HOUR_READBACK"" CommandCode=""X,17,05,01,01,01"" PropertyName=""WaterPump_RegenHour_Readback"" Decoder=""Double""/>" & _
"<Command CommandName=""WATER_PUMP_REGEN_LIFETIME_READBACK"" CommandCode=""X,17,06,01,01,01"" PropertyName=""WaterPump_LifeTimeHour_Readback"" Decoder=""Double""/>" & _
"<Command CommandName=""TURBO_PUMP_STATUS"" CommandCode=""X,14,01,01,01,02"" PropertyName=""TurboPump_Status"" Decoder=""WorkingStatuses""/>" & _
"<!--Message Alarm -->" & _
"<Command CommandName=""ALARM"" CommandCode=""X,20,01,01,01,01"" PropertyName=""StatusMessage"" Decoder=""""/>" & _
"<Command CommandName=""STATUS"" CommandCode=""X,20,02,01,01,01"" PropertyName=""EventMessage"" Decoder=""""/>" & _
"<!--Menu Machine -->" & _
"<Command CommandName=""MACHINE_PUMPDOWN"" CommandCode=""X,15,01,01,01,02"" PropertyName=""MachinePumpDown"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""MACHINE_CRYO_ON"" CommandCode=""X,09,04,01,01,02"" PropertyName=""MachineCryoOn"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""MACHINE_VENT"" CommandCode=""X,15,02,01,01,02"" PropertyName=""MachineVent"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""MACHINE_IGDEGAS"" CommandCode=""X,15,03,01,01,02"" PropertyName=""MachineIGDegas_Status"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""MACHINE_PUMPPURGE"" CommandCode=""X,15,04,01,01,02"" PropertyName=""MachinePumpPurge_Status"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""MACHINE_PUMPPURGE_CURRENT_CYCLE"" CommandCode=""X,15,04,01,01,04"" PropertyName=""MachinePumpPurge_Current_Cycle"" Decoder=""String""/>" & _
"<Command CommandName=""MACHINE_SHUTDOWN_POWER"" CommandCode=""X,15,05,01,01,02"" PropertyName=""MachineShutDownPower"" Decoder=""WorkingStatuses""/>" & _
"" & _
"<Command CommandName=""SPLITVALVE_STATUS"" CommandCode=""X,12,25,01,01,01"" PropertyName=""SlitValveStatus"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""ROUGH_LINE_IN_USE_QUERY"" CommandCode=""X,22,01,01,01,01"" PropertyName=""RoughLineInUseStatus"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""TM_ROUGH_LINE_CONVECTRON_GAUGE"" CommandCode=""X,22,01,01,01,02"" PropertyName="""" Decoder=""""/>" & _
"<Command CommandName=""PLASMA_STATUS"" CommandCode=""X,23,01,01,01,01"" PropertyName=""Plasma_Status_Readback"" Decoder=""WorkingStatuses""/>" & _
"  " & _
"<Command CommandName=""RATE_OF_RISE_STATUS"" CommandCode=""X,15,07,01,01,02"" PropertyName=""RateOfRise_Status"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""RATE_OF_RISE_SAMPLE"" CommandCode=""X,15,10,01,01,01"" PropertyName=""RateOfRise_Sample"" Decoder=""""/>" & _
"<Command CommandName=""RATE_OF_RISE_FILENAME"" CommandCode=""X,15,09,01,01,01"" PropertyName=""RateOfRise_FileName"" Decoder=""""/>" & _
"<Command CommandName=""RATE_OF_RISE_INTERVAL_RECORDING"" CommandCode=""X,15,08,01,01,02"" PropertyName=""RateOfRise_Interval"" Decoder=""""/>" & _
"" & _
"<Command CommandName=""PUMPDOWN_CURVE_STATUS"" CommandCode=""X,15,11,01,01,02"" PropertyName=""PumpDown_Curve_Status"" Decoder=""WorkingStatuses""/>" & _
"<Command CommandName=""PUMPDOWN_CURVE_SAMPLE"" CommandCode=""X,15,14,01,01,01"" PropertyName=""PumpDown_Curve_Sample"" Decoder=""""/>" & _
"<Command CommandName=""PUMPDOWN_CURVE_FILENAME"" CommandCode=""X,15,13,01,01,01"" PropertyName=""PumpDown_Curve_FileName"" Decoder=""""/>" & _
"<Command CommandName=""PUMPDOWN_CURVE_INTERVAL_RECORDING"" CommandCode=""X,15,12,01,01,02"" PropertyName=""PumpDown_Curve_Interval"" Decoder=""""/>" & _
"  " & _
"<Command CommandName=""KEEP_ALIVE"" CommandCode=""X,00,00,00,00,00,00"" PropertyName="""" Decoder=""""/>" & _
"<Command CommandName=""MAINTENAINCE_MODE"" CommandCode=""X,24,02,01,01,01"" PropertyName=""MaintenanceMode"" Decoder=""""/>" & _
"<Command CommandName=""COPYRECIPE_TO_PMFOLDER"" CommandCode=""X,24,03,01,01,01"" PropertyName=""StartCopyRecipeToPMFolder"" Decoder=""""/>" & _
"<!--Set ATM/VAC CG -->" & _
"  <Command CommandName=""PRESSURE_CG_ATM"" CommandCode=""X,27,01,01,01,01"" PropertyName="""" Decoder=""""/>" & _
"  <Command CommandName=""PRESSURE_CG_VAC"" CommandCode=""X,27,02,01,01,02"" PropertyName="""" Decoder=""""/>" & _
"  <Command CommandName=""FORELINE_CG_ATM"" CommandCode=""X,27,05,01,01,01"" PropertyName="""" Decoder=""""/>" & _
"  <Command CommandName=""FORELINE_CG_VAC"" CommandCode=""X,27,06,01,01,02"" PropertyName="""" Decoder=""""/>" & _
"  <Command CommandName=""ROUGHLINE_CG_ATM"" CommandCode=""X,27,03,01,01,01"" PropertyName="""" Decoder=""""/>" & _
"  <Command CommandName=""ROUGHLINE_CG_VAC"" CommandCode=""X,27,04,01,01,02"" PropertyName="""" Decoder=""""/>" & _
"" & _
"  <Command CommandName=""ENABLE_PM_CG_ATM"" CommandCode=""X,27,01,01,01,02"" PropertyName=""ATMChamberCGStatus"" Decoder=""WorkingStatuses""/>" & _
"  <Command CommandName=""ENABLE_PM_CG_VAC"" CommandCode=""X,27,02,01,01,01"" PropertyName=""VACChamberCGStatus"" Decoder=""WorkingStatuses""/>" & _
"  <Command CommandName=""ENABLE_ROUGHLINE_CG_ATM"" CommandCode=""X,27,03,01,01,02"" PropertyName=""ATMRoughLineCGStatus"" Decoder=""WorkingStatuses""/>" & _
"  <Command CommandName=""ENABLE_FORELINE_CG_ATM"" CommandCode=""X,27,05,01,01,02"" PropertyName=""ATMForelineCGStatus"" Decoder=""WorkingStatuses""/>" & _
"  <Command CommandName=""ENABLE_MECHANICAL_PUMP_CG_ATM"" CommandCode=""X,27,07,01,01,02"" PropertyName=""ATMMechanicalPumpCGStatus"" Decoder=""WorkingStatuses""/>" & _
"  <!--Step Complete-->" & _
"   <Command CommandName=""PROCESS_RECIPE_STEP_COMPLETE"" CommandCode=""X,07,01,01,01,02,20"" PropertyName=""StepCompleted"" Decoder=""Double""/>" & _
"  <!-- Clear All Alarm -->" & _
"  <Command CommandName=""CLEAR_ALL_ALARM_PROGRAM"" CommandCode=""X,33,26,01,01,01"" PropertyName="""" Decoder=""""/>" & _
"  " & _
"</PVDServer>" & _
""
End Class
End Namespace
