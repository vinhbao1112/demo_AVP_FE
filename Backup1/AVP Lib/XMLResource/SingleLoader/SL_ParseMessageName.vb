Namespace XMLResources
    Public Class SL_ParseMessageName
        Public Const XMLText As String = _
        "<MessageNames>" & _
        "  <!--Kep Server-->" & _
        "  <Property Name=""Loader.ArmUpDownStatus"" Code=""ChangeArmUpDownStatusInSLProcessScreenTo"" />" & _
        "  <Property Name=""Loader.ArmExtendRetractStatus"" Code=""LoaderSetArmExtendRetractStatusInProcessScreenTo"" />" & _
        "  <Property Name=""Loader.IsolationValveStatus"" Code=""LoaderSetIsolationValveStatusInProcessScreenTo"" />" & _
        "  <Property Name=""Loader.DoorSensorStatus"" Code=""LoaderSetDoorStatusInProcessScreenTo"" />" & _
        "  <Property Name=""Loader.HighVacuumSwitch"" Code=""LoaderSetVacuumStatusInProcessScreenTo"" />" & _
        "  <Property Name=""Loader.MidVacuumSwitch"" Code=""LoaderSetVacuumStatusInProcessScreenTo"" />" & _
        "  <Property Name=""Loader.MechanicalPump"" Code=""LoaderSetMechanicalPumpStatusInProcessScreenTo"" />" & _
        "  <Property Name=""Loader.VentValveStatus"" Code=""LoaderSetVentValveStatusInProcessScreenTo"" />" & _
        "  <Property Name=""Loader.RoughValveStatus"" Code=""LoaderSetRoughValveStatusInProcessScreenTo"" />" & _
        "  <Property Name=""Loader.AutoPumpDownStatus"" Code=""SetLoaderAutoPumpDownStatusTo""/>" & _
        "  <Property Name=""Loader.AutoVentStatus"" Code=""SetLoaderAutoVentStatusTo""/>" & _
        "  <Property Name=""Loader.AutoLoadStatus"" Code=""SetLoaderAutoLoadStatusTo,ChangeAutoLoadStatusInSLProcessScreenTo""/>" & _
        "  <Property Name=""Loader.AutoUnloadStatus"" Code=""SetLoaderAutoUnloadStatusTo,ChangeAutoUnloadStatusInSLProcessScreenTo""/>" & _
        "  <Property Name=""Loader.LoadStatus"" Code=""SetLoaderLoadStatusTo""/>" & _
        "  <Property Name=""Loader.ArmPressureStatus"" Code=""SetLoaderArmPressureStatusTo""/>" & _
        "  <Property Name=""Loader.StatusMessage"" Code=""ShowStatusMessage,ShowStatusMessageInSLProcessScreen"" />  " & _
        "  <Property Name=""Loader.DataOutputStatus"" Code=""SetDataOutputStatusTo""/>  " & _
        "  <Property Name=""Loader.WaferInsideLoader"" Code=""SetAnimateRobotInSLProcessScreen""/>" & _
        "  " & _
        "   <Property Name=""Loader.RunStatus"" Code=""SetRunStatusInProcessScreen""/>" & _
        "   <Property Name=""Loader.StopStatus"" Code=""SetStopStatusInProcessScreen""/>" & _
        "   <Property Name=""Loader.AbortStatus"" Code=""SetAbortStatusInProcessScreen""/>" & _
        "   <Property Name=""Loader.PauseStatus"" Code=""SetPauseStatusInProcessScreen""/>" & _
        "   " & _
        "   <Property Name=""Loader.WaferCount"" Code=""TotalWaferCountOfLoader""/>" & _
        "  <!--End Kep Server-->" & _
        "  <!--Single loader -->" & _
        "  	<!--IBE Server-->" & _
        " 	<Property Name=""IBE.WaferStatus"" Code=""SetIBE_WaferStatusInSLProcessScreenTo""/>" & _
        "  <Property Name=""IBE.WaferInside"" Code=""SetWaferInsideChamberInSLProcessScreenTo""/>" & _
        "  	<!--Alarm status-->" & _
        "  <Property Name=""IBE.ConnectionStatus"" Code=""SetIBE_ConnectionStatusTo,SetIBE_ConnectionStatusInProcessModuleTo""/>" & _
        "  <!--Power Panel-->" & _
        "  <Property Name=""IBE.ACPower_readback"" Code=""SetACPowerIBETo""/>" & _
        "  <Property Name=""IBE.GridPower_readback"" Code=""SetGridPowerIBETo""/>" & _
        "  <Property Name=""IBE.RFPower_readback"" Code=""SetRFPowerIBETo""/>" & _
        "  <Property Name=""IBE.PBNPower_readback"" Code=""SetPBNPowerIBETo""/>" & _
        "  <Property Name=""IBE.SourceManual_Auto_readback"" Code=""SetSourceManualIBETo""/>" & _
        "    <!--Status panel-->" & _
        "  <Property Name=""IBE.Initialize_Motion_readback"" Code=""SetInitializeMotionIBEInProcessPanelTo,SetInitializeMotionIBEInProcessModuleTo,SetIBEFixture_InitializeMotionStatusTo""/>" & _
        "  <Property Name=""IBE.Flowcool_Gas_readback"" Code=""SetFlowcoolGasIBEInProcessPanelTo,SetFlowcoolGasIBEInProcessModuleTo""/>" & _
        "  <Property Name=""IBE.Process_Gas_Readback"" Code=""SetProcessGasIBEInProcessPanelTo,SetProcessGasIBEInProcessModuleTo""/>" & _
        "  <Property Name=""IBE.Ion_Beam_Readback"" Code=""SetIonBeamIBEInProcessPanelTo,SetIonBeamIBEInProcessModuleTo,SetPlasmaInProcessModuleTo""/>" & _
        "  <Property Name=""IBE.PBN_OK_Readback"" Code=""SetPBNOKIBEInProcessPanelTo,SetPBNOKIBEInProcessModuleTo""/>" & _
        "  <!-- RFPowerSupply-->" & _
        "  <Property Name=""IBE.RFPowerSupply_ForwardPower_Readback"" Code=""SetIBERFPowerSupply_SetForwardPowerInProcessPanelTo,SetIBERFPowerSupply_SetForwardPowerInProcessModuleTo""/>" & _
        "  <Property Name=""IBE.RFPowerSupply_ReflectedPower"" Code=""SetIBERFPowerSupply_SetReflectedPowerInProcessModuleTo""/>" & _
        "  <Property Name=""IBE.RFPowerSupply_ReflectedPower_Program"" Code=""SetIBERFPowerSupply_SetReflectedPowerRightTo""/>" & _
        "  <Property Name=""IBE.RFPowerSupply_ForwardPower_Program"" Code=""SetIBERFPowerSupply_ForwardPowerRight""/>" & _
        "  <!-- BeamPowerSupply-->" & _
        "  <Property Name=""IBE.BeamPowerSupply_Current_Readback"" Code=""SetIBEBeamPowerSupply_SetCurrentInProcessPanelTo,SetIBEBeamPowerSupply_SetCurrentInProcessModuleTo""/>" & _
        "  <Property Name=""IBE.BeamPowerSupply_Current_Program"" Code=""SetIBEBeamPowerSupply_SetCurrentRightTo""/>" & _
        "  <Property Name=""IBE.BeamPowerSupply_Voltage_Readback"" Code=""SetIBEBeamPowerSupply_SetVoltageInProcessPanelTo,SetIBEBeamPowerSupply_SetVoltageInProcessModuleTo""/>" & _
        "  <Property Name=""IBE.BeamPowerSupply_Voltage_Program"" Code=""SetIBEBeamPowerSupply_VoltageRight""/>" & _
        "  <Property Name=""IBE.BeamPowerSupply_AutoBeam"" Code=""SetIBEBeamPowerSupply_AutoBeam""/>" & _
        "  <!-- SuppressorPowerSupply-->" & _
        "  <Property Name=""IBE.SuppressorPowerSupply_Voltage_Readback"" Code=""SetIBESuppressorPowerSupply_SetVoltageInProcessPanelTo,SetIBESuppressorPowerSupply_SetVoltageInProcessModuleTo""/>" & _
        "  <Property Name=""IBE.SuppressorPowerSupply_Voltage_Program"" Code=""SetIBESuppressorPowerSupply_VoltageRight""/>" & _
        "  <Property Name=""IBE.SuppressorPowerSupply_Current_Readback"" Code=""SetIBESuppressorPowerSupply_SetCurrentInProcessModuleTo""/>" & _
        "  <Property Name=""IBE.SuppressorPowerSupply_Current_Program"" Code=""SetIBESuppressorPowerSupply_SetCurrentRightTo""/>" & _
        "  <!-- BodyPowerSupply-->" & _
        "  <Property Name=""IBE.BodyPowerSupply_Current_Readback"" Code=""SetIBEBodyPowerSupply_SetCurrentInProcessPanelTo,SetIBEBodyPowerSupply_SetCurrentInProcessModuleTo""/>" & _
        "  <Property Name=""IBE.BodyPowerSupply_Current_Program"" Code=""SetIBEBodyPowerSupply_CurrentRight""/>" & _
        "  <Property Name=""IBE.DischargePowerSupply_Current_Readback"" Code=""SetIBEDischargePowerSupply_SetCurrentInProcessPanelTo,SetIBEDischargePowerSupply_SetCurrentInProcessModuleTo""/>" & _
        "  <Property Name=""IBE.BodyPowerSupply_KFactor_Readback"" Code=""SetIBEBodyPowerSupply_SetKFactorTo""/>" & _
        "  <Property Name=""IBE.BodyPowerSupply_KFactor_Program"" Code=""SetIBEBodyPowerSupply_SetKFactorRightTo""/>" & _
        "  <!-- Temperture-->" & _
        "  <Property Name=""IBE.Cryo_Pump_Temperture"" Code=""SetIBETempertureInProcessPanelTo,SetIBETempertureInProcessModuleTo""/>" & _
        "  <Property Name=""IBE.Cryo_Pump_Temperture_T2"" Code=""SetIBETempertureT2To""/>" & _
        "   <!-- CGCFLCG-->" & _
        "  <Property Name=""IBE.CGCFLCG_Information"" Code=""SetIBECGCFLCG_SetInformationTo""/>" & _
        "  <!-- CGCRLCG-->" & _
        "  <Property Name=""IBE.CGCRLCG_Information"" Code=""SetIBECGCRLCG_SetInformationTo""/>" & _
        "  <!-- CGCMG-->" & _
        "  <Property Name=""IBE.CGCMG_Information"" Code=""SetIBECGCMG_SetInformationTo""/>" & _
        "  <!-- FixtureControl-->" & _
        "  <Property Name=""IBE.Fixture_TiltAngle_Program"" Code=""SetIBEFixtureControl_TiltAngleRight""/>" & _
        "  <Property Name=""IBE.Fixture_TiltAngle_Readback"" Code=""SetIBEFixtureControl_SetTiltAngleTo,SetProcessPanel_FixtureControl_SetTiltAngleTo""/>" & _
        "  <Property Name=""IBE.SweepFixture_Rotation_Start_Readback"" Code=""SetIBEFixtureControlSweep_SetRotationStartTo""/>" & _
        "  <Property Name=""IBE.SweepFixture_Rotation_Start_Program"" Code=""SetIBEFixtureControlSweep_RotationRight""/>" & _
        "  <Property Name=""IBE.SweepFixture_Rotation_End_Program"" Code=""SetIBEFixtureControlSweep_RotationEndRight""/>  " & _
        "  <!-- FixtureControlStatic-->" & _
        "  <Property Name=""IBE.StaticFixture_Rotation_Readback"" Code=""SetIBEFixtureControlStatic_SetRotationTo""/>  " & _
        "  <Property Name=""IBE.StaticFixture_Rotation_Program"" Code=""SetIBEFixtureControlStatic_RotationRight""/>" & _
        "  <!-- FixtureControlContinuous-->" & _
        "  <Property Name=""IBE.ContinuousFixture_Rotation_Readback"" Code=""SetIBEFixtureControlContinuous_SetRotationTo""/>" & _
        "  <Property Name=""IBE.ContinuousFixture_Rotation_Program"" Code=""SetIBEFixtureControlContinuous_RotationRight""/>" & _
        "  <!--Fixture Status-->" & _
        "  <Property Name=""IBE.Fixture_Home_Tilt_Readback"" Code=""SetIBEFixture_HomeTiltStatusTo""/>" & _
        "  <Property Name=""IBE.Fixture_Start_Rotation_Readback"" Code=""SetIBEFixture_StartRotationStatusTo,SetIBE_FixtureStartRotationForMenuTo""/>" & _
        "     <!-- GasController-->" & _
        "  <Property Name=""IBE.GasController_Argon_Readback"" Code=""SetIBEGasController_SetArgonTo,SetIBEGasController_SetArgonTo_SourceTab""/>" & _
        "  <Property Name=""IBE.GasController_FlowCoolHe_Readback"" Code=""SetIBEGasController_SetFlowCoolHeTo""/>" & _
        "  <Property Name=""IBE.GasController_PBN_Readback"" Code=""SetIBEGasController_SetPBNTo,SetIBEGasController_SetPBNTo_SourceTab,SetProcessScreen_SetPBNTo""/>" & _
        "  <Property Name=""IBE.GasController_PBN_Program"" Code=""SetIBEGasController_PBNRight,SetIBEGasController_PBNRight_SourceTab""/>" & _
        "  <Property Name=""IBE.GasController_Argon_Program"" Code=""SetIBEGasController_ArgonRight,SetIBEGasController_ArgonRight_SourceTab""/>" & _
        "  <Property Name=""IBE.GasController_FlowCoolHe_Program"" Code=""SetIBEGasController_FlowCoolHeRight""/>" & _
        "  <!-- Valve-->" & _
        "  <Property Name=""IBE.Gas1ShutOffValveStatus"" Code=""SetIBEGas1ShutOffValveStatus""/>" & _
        "  <Property Name=""IBE.Gas1SupplyValveStatus""  Code=""SetIBEGas1SupplyValveStatus""/>" & _
        "  <Property Name=""IBE.Gas2ShutOffValveStatus"" Code=""SetIBEGas2ShutOffValveStatus""/>" & _
        "  <Property Name=""IBE.Gas2SupplyValveStatus""  Code=""SetIBEGas2SupplyValveStatus""/>" & _
        "  <Property Name=""IBE.Gas3ShutOffValveStatus"" Code=""SetIBEGas3ShutOffValveStatus""/>" & _
        "  <Property Name=""IBE.Gas3SupplyValveStatus""  Code=""SetIBEGas3SupplyValveStatus""/>" & _
        "  <Property Name=""IBE.Gas4ShutOffValveStatus"" Code=""SetIBEGas4ShutOffValveStatus""/>" & _
        "  <Property Name=""IBE.Gas4SupplyValveStatus"" Code=""SetIBEGas4SupplyValveStatus""/>" & _
        "  <Property Name=""IBE.Gas5ShutOffValveStatus"" Code=""SetIBEGas5ShutOffValveStatus""/>" & _
        "  <Property Name=""IBE.Gas5SupplyValveStatus""  Code=""SetIBEGas5SupplyValveStatus""/>" & _
        "" & _
        "  <Property Name=""IBE.FlowCoolHeValveStatus"" Code=""SetIBEFlowCoolHeValveStatus""/>" & _
        "  <Property Name=""IBE.ValveSupplyFlowCoolHeStatus"" Code=""SetIBEValveSupplyFlowCoolHe""/>" & _
        "  <Property Name=""IBE.PBNValveStatus"" Code=""SetIBEPBNValveStatus""/>" & _
        "  <Property Name=""IBE.ValveSupplyPBNStatus"" Code=""SetIBEValveSupplyPBN""/>" & _
        "  " & _
        "  <Property Name=""IBE.BaratronValveStatus"" Code=""SetIBEBaratronValveStatus""/>" & _
        "  <Property Name=""IBE.ForelineValveStatus"" Code=""SetIBEForelineValveStatus""/>" & _
        "  <Property Name=""IBE.RoughValveStatus"" Code=""SetIBERoughValveStatus""/>" & _
        "  <Property Name=""IBE.VentValveStatus"" Code=""SetIBEVentValveStatus""/>" & _
        "  <Property Name=""IBE.HiVacValveStatus"" Code=""SetIBEHiVacValveStatus""/>" & _
        "  <!--Gas-->" & _
        "  <Property Name=""IBE.Gas1FlowRateReadback"" Code=""SetIBEGas1ReadbackTo,SetIBEGas1ReadbackSourceTabTo,SetProcessPanel_Gas1ReadbackSourceTabTo""/>" & _
        "  <Property Name=""IBE.Gas2FlowRateReadback"" Code=""SetIBEGas2ReadbackTo,SetIBEGas2ReadbackSourceTabTo,SetProcessPanel_Gas2ReadbackSourceTabTo""/>" & _
        "  <Property Name=""IBE.Gas3FlowRateReadback"" Code=""SetIBEGas3ReadbackTo,SetIBEGas3ReadbackSourceTabTo""/>" & _
        "  <Property Name=""IBE.Gas1FlowRateProgram"" Code=""SetIBEGas1ProgramTo,SetIBEGas1ProgramSourceTabTo""/>" & _
        "  <Property Name=""IBE.Gas2FlowRateProgram"" Code=""SetIBEGas2ProgramTo,SetIBEGas2ProgramSourceTabTo""/>" & _
        "  <Property Name=""IBE.Gas3FlowRateProgram"" Code=""SetIBEGas3ProgramTo,SetIBEGas3ProgramSourceTabTo""/>" & _
        "  " & _
        "  <Property Name=""IBE.ShutterPositionStatus"" Code=""SetIBEShutterPositionInProcessPanel,SetIBEShutterPositionInProcessModule,SetIBEShutterInFixture""/>" & _
        "  <Property Name=""IBE.TurboPowerStatus"" Code=""SetIBEValveWaterPump,SetIBEMenuValveWaterPump""/>" & _
        "  <Property Name=""IBE.ValveCryoPumpGateStatus"" Code=""SetIBEValveCryoPump,SetIBEMenuValveCryoPump""/>" & _
        "  <Property Name=""IBE.TurboPumpRegen"" Code=""SetIBEWaterPumpRegen""/>" & _
        "  " & _
        "  <!-- ChamberInterlocks-->" & _
        "  <Property Name=""IBE.ChamberInterlocks_PanelInterlock_Status"" Code=""SetIBEChangeInterlocksPanelInProcessPanelTo,SetIBEChangeInterlocksPanelInProcessModuleTo""/>" & _
        "  <Property Name=""IBE.ChamberInterlocks_ChamberPress_Status"" Code=""SetIBEChangeInterlocksChamberPressInProcessPanelTo,SetIBEChangeInterlocksChamberPressInProcessModuleTo""/>" & _
        "  <Property Name=""IBE.ChamberInterlocks_FixtureWater_Status"" Code=""SetIBEChangeInterlocksFixureWaterInProcessPanelTo,SetIBEChangeInterlocksFixureWaterInProcessModuleTo""/>" & _
        "  <Property Name=""IBE.ChamberInterlocks_Foreline_Status"" Code=""SetIBEChangeInterlocksForelineInProcessPanelTo,SetIBEChangeInterlocksForelineInProcessModuleTo""/>" & _
        "  <Property Name=""IBE.ChamberInterlocks_SourceWater_Status"" Code=""SetIBEChangeInterlocksSourceWaterInProcessPanelTo,SetIBEChangeInterlocksSourceWaterInProcessModuleTo""/>" & _
        "  <Property Name=""IBE.ChamberInterlocks_TurboWater_Status"" Code=""SetIBEChangeInterlocksTurboWaterInProcessPanelTo,SetIBEChangeInterlocksTurboWaterInProcessModuleTo""/>" & _
        "  <Property Name=""IBE.ChamberInterlocks_AirPressure_Status"" Code=""SetIBEChangeInterlocksAirPressureInProcessPanelTo,SetIBEChangeInterlocksAirPressureInProcessModuleTo""/>" & _
        "  <Property Name=""IBE.ChamberInterlocks_FixtureRotation_Status"" Code=""SetIBEChangeInterlocksFixtureRotationInProcessPanelTo,SetIBEChangeInterlocksFixtureRotationInProcessModuleTo""/>" & _
        "  <!--Process Status-->" & _
        "  <Property Name=""IBE.WaferID"" Code=""SetIBEProcessMonitor_WaferID""/>" & _
        "  <Property Name=""IBE.Recipe"" Code=""SetIBEProcessMonitorInProcessPanel_RecipeTo,SetIBEProcessMonitorInProcessModule_RecipeTo""/>" & _
        "  <Property Name=""IBE.RunProcessStatus"" Code=""SetStatusOfIBEInProcessScreenTo,SetIBEProcessMonitor_StatusTo""/>" & _
        "  <Property Name=""IBE.RemainingTime"" Code=""SetIBERemainingTimeTo,SetProcessScreen_RemainingTimeTo""/>" & _
        "  <Property Name=""IBE.ProcessMonitor_ProcessStep"" Code=""SetIBEProcessMonitor_ProcessStepInProcessPanelTo,SetIBEProcessMonitor_ProcessStepInProcessModuleTo""/>" & _
        "  <Property Name=""IBE.ElapsedTime"" Code=""SetIBEProcessMonitor_ElapsedTimeTo,SetProcessScreen_ElapsedTimeTo""/>" & _
        "  <Property Name=""IBE.ProcessMonitor_TotalStep"" Code=""SetIBEProcessMonitor_TotalStepTo""/>" & _
        "  <Property Name=""IBE.IG"" Code=""SetIGOfIBETo,SetIGInProcessModuleTo,SetIGInProcessPanelTo""/>" & _
        "  <Property Name=""IBE.CG"" Code=""SetCGOfIBETo,SetCGInProcessModuleTo""/>" & _
        "  <!--Run Recipe-->" & _
        "  <Property Name=""IBE.ProcessMonitor_DeviceStart_Readback"" Code=""SetIBEChamber_ProcessMonitor_SetDeviceStartTo""/>" & _
        "  <Property Name=""IBE.ProcessMonitor_DeviceStop_Readback"" Code=""SetIBEChamber_ProcessMonitor_SetDeviceStopTo,SetStatusOfIBEInProcessScreenTo""/>" & _
        "  <Property Name=""IBE.ProcessMonitor_DevicePause_Readback"" Code=""SetIBEChamber_ProcessMonitor_SetDevicePauseTo""/>" & _
        "  <Property Name=""IBE.ProcessMonitor_DeviceContinue_Readback"" Code=""SetIBEChamber_ProcessMonitor_SetDeviceContinueTo""/>" & _
        "  <!--Menu-->" & _
        "  <Property Name=""IBE.PumpDownStatus"" Code=""SetMnuPumpDownIBETo""/>" & _
        "  <Property Name=""IBE.VentStatus"" Code=""SetMnuVentIBETo""/>" & _
        "  <Property Name=""IBE.CryoPumpStatus"" Code=""SetButtonCryoIBETo,SetMnuCryoIBETo""/>" & _
        "  <Property Name=""IBE.RoughPumpStatus"" Code=""SetMnuRoughPumpIBEInProcessModuleTo""/>" & _
        "  <Property Name=""IBE.CryoPumpRegenStatus"" Code=""SetMnuCryoPumpRegenIBETo""/>" & _
        "  <Property Name=""IBE.CryoAutoRegenStatus"" Code=""SetMnuCryoAutoRegenIBETo""/>" & _
        "  <Property Name=""IBE.CryoAutoPowerDownStatus"" Code=""SetMnuCryoAutoPowerDownIBETo""/>" & _
        "  <Property Name=""IBE.CryoPumpPurgeStatus"" Code=""SetMnuCryoPumpPurgeIBETo""/>" & _
        "  <Property Name=""IBE.RaiseOfRiseStatus"" Code=""SetMnuCryoRateOfRiseIBETo""/>" & _
        "  <Property Name=""IBE.WaterPump"" Code=""SetMnuWaterPumpTo""/>" & _
        "  <Property Name=""IBE.WaterPumpRegen"" Code=""SetMnuWaterPumpRegenTo""/>" & _
        " " & _
        " 	<Property Name=""IBE.FixtureWaterValveStatus"" Code=""SetIBEMenuFixtureOpenWaterValve,SetIBEFixtureOpenWaterValve""/>" & _
        "  <Property Name=""IBE.FixtureFlowCoolPumpStatus"" Code=""SetIBEFixtureOpenFlowCool,SetMnuRoughPumpIBEInProcessPanelTo""/>" & _
        " 	<Property Name=""IBE.Fixture_Unprotected_Readback"" Code=""SetIBEFixtureUnProtected""/>" & _
        " " & _
        "  <Property Name=""IBE.ControlStatus"" Code=""ChangeMachineOnlineInIBETo"" /> " & _
        "   <!--System Setup-->" & _
        "  <Property Name=""IBE.SetSourceUsageTime"" Code=""SetSourceUsageTimeIBETo""/>" & _
        "  <!--End Single loader -->" & _
        "  " & _
        "  <!--IBE Server-->" & _
        "  <Property Name=""IBE.OnlineStatus"" Code=""SetIBE_OnlineStatusTo""/>" & _
        "  <Property Name=""IBE.AutoPumpDownStatus"" Code=""SetIBE_AutoPumpDownStatusTo""/>" & _
        "  <Property Name=""IBE.AutoVentStatus"" Code=""SetIBE_AutoVentStatusTo""/>" & _
        "  <!--Alarm status from chamber 5-->" & _
        "  <Property Name=""Alarm.AlarmStatus"" Code=""StartAlarm""/>" & _
        "  <Property Name=""Alarm.RedStatus"" Code=""FlashRedLight""/>" & _
        "  <Property Name=""Alarm.GreenStatus"" Code=""FlashGreenLight""/>" & _
        "  <Property Name=""Alarm.OrangeStatus"" Code=""FlashOrangeLight""/>" & _
        "  <!--Power Panel-->" & _
        "  <Property Name=""IBE.PowerStatusPanel.ACPower"" Code=""ChangeButtonACPowerIBETo""/>" & _
        "  <Property Name=""IBE.PowerStatusPanel.RFPower"" Code=""ChangeButtonRFPowerIBETo""/>" & _
        "  <Property Name=""IBE.PowerStatusPanel.GridPower"" Code=""ChangeButtonGridPowerIBETo""/>" & _
        "  <Property Name=""IBE.PowerStatusPanel.PBNPower"" Code=""ChangeButtonPBNPowerIBETo""/>" & _
        "  <!--Fixture-->" & _
        "  <Property Name=""IBE.FixtureTiltHomeStatus"" Code=""SetIBEFixtureControlSweep_ChangeSmallCricleControlTiltAngleTo,SetIBEFixtureControlStatic_ChangeSmallCricleControlTiltAngleTo,SetIBEFixtureControlContinuous_ChangeSmallCricleControlTiltAngleTo""/>" & _
        "  <Property Name=""IBE.FixtureRotationHomeStatus"" Code=""SetIBEFixtureControlSweep_ChangeSmallCricleControlTiltRotationTo,SetIBEFixtureControlStatic_ChangeSmallCricleControlTiltRotationTo,SetIBEFixtureControlContinuous_ChangeSmallCricleControlTiltRotationTo""/>" & _
        "  <Property Name=""IBE.FixtureErrorStatus"" Code=""SetIBEFixtureControlSweep_ChangeSmallCricleControlErrorTo,SetIBEFixtureControlStatic_ChangeSmallCricleControlErrorTo,SetIBEFixtureControlContinuous_ChangeSmallCricleControlErrorTo""/>" & _
        "  <Property Name=""IBE.Wafer_InFixture_Readback"" Code=""SetIBEWaferInFixtureTo""/>" & _
        "	 <!-- FixtureControlStatic-->" & _
        "  <Property Name=""IBE.StaticFixture_RotationLast_Program"" Code=""SetIBEFixtureControlStatic_RotationLastRight""/>" & _
        "  <!-- FixtureControlContinuous-->" & _
        "  <Property Name=""IBE.ContinuousFixture_RotationLast_Program"" Code=""SetIBEFixtureControlContinuous_RotationLastRight""/>" & _
        "  <!-- Process Recipe -->" & _
        "  <Property Name=""IBE.RecipeProcessingFinished"" Code=""SetIBEProcessRecipe_FinishProcessing""/>" & _
        "	<!--Remove-->" & _
        "  <Property Name=""IBE.ArgonValveStatus"" Code=""SetIBEArgonValveStatus""/>" & _
        "  <Property Name=""IBE.ValveSupplyArgonStatus"" Code=""SetIBEValveSupplyArgon""/>" & _
        "  <Property Name=""IBE.PBNShutOffValveStatus""  Code=""SetIBEPBNShutOffValveStatus""/>" & _
        "  <Property Name=""IBE.PBNSupplyValveStatus""   Code=""SetIBEPBNSupplyValveStatus""/>" & _
        "  <Property Name=""IBE.FlowCoolShutOffValveStatus"" Code=""SetIBEFlowCoolShutOffValveStatus""/>" & _
        "  <Property Name=""IBE.FlowCoolSupplyValveStatus"" Code=""SetIBEFlowCoolSupplyValveStatus""/>" & _
        "	<!--End Remove-->" & _
        "  <!-- Fixture tool-->" & _
        "  <Property Name=""IBE.FixtureClampStatus"" Code=""SetIBEFixtureOnClamp""/>" & _
        "  <Property Name=""IBE.FixtureHomeAllAxis"" Code=""SetIBEFixtureHomeAllAxis""/>" & _
        "  <Property Name=""IBE.FixtureHomeRotationAxis"" Code=""SetIBEFixtureHomeRotationAxis""/>" & _
        "  <Property Name=""IBE.FixtureHomeTiltAxis"" Code=""SetIBEFixtureHomeTiltAxis""/>" & _
        "  <Property Name=""IBE.FixtureStopAllAxis"" Code=""SetIBEFixtureStopAllAxis""/>" & _
        "  <Property Name=""IBE.FixtureUnClamp"" Code=""SetIBEFixtureUnClamp""/>" & _
        "  <Property Name=""IBE.CryoPumpRegen"" Code=""SetIBECryoPumpRegen""/>" & _
        "  <Property Name=""IBE.CryoAutoRegen"" Code=""SetIBECryoAutoRegen""/>" & _
        "  <!-- Machine tool,  old system have not 3 items such as: Cryo On, Cryo Regen, Cryo Hivac-->" & _
        "  <Property Name=""IBE.MachinePumbDown"" Code=""SetIBEMachinePumbDown""/>" & _
        "  <Property Name=""IBE.MachineVent"" Code=""SetIBEMachineVent""/>" & _
        "  " & _
        "  <!-- ChamberProcess Chamber 5-->" & _
        "  <Property Name=""IBE.StepTime"" Code=""SetStepTimeOfIBEInProcessScreenTo,SetIBEProcessMonitor_StepTimeTo""/>" & _
        "  <Property Name=""IBE.PressureMode"" Code=""SetEtchPressureOfIBEInProcessScreenTo""/>" & _
        "  <!-- ChamberProcess Chamber 5 IG, CG, Button IG-->" & _
        "</MessageNames>                                                              "
    End Class
End Namespace
