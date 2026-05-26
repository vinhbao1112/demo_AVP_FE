Namespace XMLResources
Public Class ParseMessageName
Public Const XMLText as String = _
"<MessageNames>" & _
"  <!--Kep Server-->" & _
"  <Property Name=""CassettesModule.Process_Complete_Chime"" Code=""ChangeProcessCompleteChime"" />" & _
"  <Property Name=""CassettesModule.SensorLLAStatus"" Code=""ChangeSensorLLAInProcessScreenTo,ChangeSensorLLAInCassettesScreenTo"" />" & _
"  <Property Name=""CassettesModule.SensorPM1Status"" Code=""ChangeSensorPM1InProcessScreenTo,ChangeSensorPM1InCassettesScreenTo"" />" & _
"  <Property Name=""CassettesModule.SensorPM2Status"" Code=""ChangeSensorPM2InProcessScreenTo,ChangeSensorPM2InCassettesScreenTo"" />" & _
"  <Property Name=""CassettesModule.SensorPM3Status"" Code=""ChangeSensorPM3InProcessScreenTo,ChangeSensorPM3InCassettesScreenTo"" />" & _
"  <Property Name=""LoadLockA.HiVacValveStatus"" Code=""ChangeHiVacOfLLAInCassettesScreenTo,ChangeHiVacOfLLAInProcessPanelTo"" />" & _
"  <Property Name=""CassettesModule.HiVacValveStatus"" Code=""ChangeHiVacOfMachineInCassettesScreenTo,ChangeHiVacValveOfMachineInProcessScreenTo,ChangeHiVacValveOfMachineInCassettesScreenTo"" />" & _
"  <Property Name=""CassettesModule.FastVentValveStatus"" Code=""ChangeValve1InCassettesScreenTo"" />" & _
"  <Property Name=""CassettesModule.FastRoughValveStatus"" Code=""ChangeValve6InCassettesScreenTo"" />" & _
"  <Property Name=""CassettesModule.MessageBox"" Code=""ShowMessageBox"" />" & _
"  <Property Name=""CassettesModule.StatusMessage"" Code=""ShowStatusMessage"" />" & _
"  <Property Name=""CassettesModule.FlashingTextInCassetteScreen"" Code=""ShowFlashingTextInCassetteScreenTo"" />" & _
"  <Property Name=""CassettesModule.FlashingTextInProcessScreen"" Code=""ShowFlashingTextInProcessScreenTo"" />" & _
"  <Property Name=""CassettesModule.ClearAllWaferStatus"" Code=""ClearAllWaferStatus"" />" & _
"  <Property Name=""CassettesModule.RefreshLotDatalog"" Code=""RefreshLotDatalog"" />" & _
"  <Property Name=""CassettesModule.LastUsedAlignerRecipe"" Code=""SetLastUsedAlignerRecipe"" />" & _
"  <Property Name=""CassettesModule.SplitValve1Status"" Code=""ChangeSlitValeOfLLAInProcessScreenTo,ChangeSlitValeOfLLAInCassettesScreenTo"" />" & _
"  <Property Name=""CassettesModule.SplitValve2Status"" Code=""ChangeSlitValeOfChamber1InProcessScreenTo,ChangeSlitValeOfChamber1InCassettesScreenTo,ChangeSlitValveOfChamber1To"" />" & _
"  <Property Name=""CassettesModule.SplitValve3Status"" Code=""ChangeSlitValeOfChamber2InProcessScreenTo,ChangeSlitValeOfChamber2InCassettesScreenTo,ChangeSlitValveOfChamber2To"" />" & _
"  <Property Name=""CassettesModule.SplitValve4Status"" Code=""ChangeSlitValeOfChamber3InProcessScreenTo,ChangeSlitValeOfChamber3InCassettesScreenTo,ChangeSlitValveOfChamber3To"" />" & _
"  <Property Name=""LoadLockA.SlowVentValveStatus"" Code=""ChangeValve2InCassettesScreenTo"" />" & _
"  <Property Name=""LoadLockA.FastVentValveStatus"" Code=""ChangeValve3InCassettesScreenTo"" />" & _
"  <Property Name=""LoadLockA.SlowRoughValveStatus"" Code=""ChangeValve9InCassettesScreenTo"" />" & _
"  <Property Name=""LoadLockA.FastRoughValveStatus"" Code=""ChangeValve10InCassettesScreenTo"" />" & _
"  <Property Name=""CassettesModule.IG"" Code=""SetIGOfCassettesModuleInCassettesScreenTo"" />" & _
"  <Property Name=""CassettesModule.IGPressureError"" Code=""SetIGOfCassettesModuleInCassettesScreenTo"" />" & _
"  <Property Name=""CassettesModule.CG"" Code=""SetCGOfCassettesModuleInCassettesScreenTo,UpdateTMCGPressOnCGForm"" />" & _
"  <Property Name=""CassettesModule.CGPressureError"" Code=""SetCGOfCassettesModuleInCassettesScreenTo"" />" & _
"  <Property Name=""CassettesModule.RoughPump1Status"" Code=""ChangeRoughPump1InCassettesScreenTo"" />" & _
"  <Property Name=""CassettesModule.RoughPump2Status"" Code=""ChangeRoughPump2InCassettesScreenTo"" />" & _
"  <Property Name=""CassettesModule.CoreMessageBox"" Code=""ChangeCoreMessageBoxInCassettesScreenTo"" />" & _
"  <Property Name=""CassettesModule.RoughPumpMachine1InUse"" Code=""ChangeRoughPump1InUseInCassettesScreenTo"" />" & _
"  <Property Name=""CassettesModule.RoughPumpMachine2InUse"" Code=""ChangeRoughPump2InUseInCassettesScreenTo"" />" & _
"  <Property Name=""CassettesModule.IG_Degas_Status"" Code=""ChangeTMIGDegasStatusInCassettesScreenTo"" />" & _
"  <Property Name=""LoadLockA.IG_Degas_Status"" Code=""ChangeLLAIGDegasStatusInCassettesScreenTo"" />" & _
"  <Property Name=""LoadLockA.CG"" Code=""SetCG6InCassettesScreenTo,UpdateLLACGPressOnCGForm"" />" & _
"  <Property Name=""LoadLockA.LotID"" Code=""SetLotIDOfLoadLockAInProcessScreenTo"" />" & _
"  <Property Name=""LoadLockA.SequenceID"" Code=""SetSequenceIDOfLoadLockAInProcessScreenTo"" />  " & _
"  <Property Name=""LoadLockA.PressureMode"" Code=""SetPressureOfLoadLockAInProcessScreenTo,SetPressureOfLoadLockAInCassettesScreenTo"" />" & _
"  <Property Name=""LoadLockA.PressureError"" Code=""SetPressureOfLoadLockAInProcessScreenTo,SetPressureOfLoadLockAInCassettesScreenTo"" />" & _
"  <Property Name=""CassettesModule.IGStatus"" Code=""ChangeButtonIGOfCassettesModuleInCassettesScreenTo,ChangeButtonIGOfCassettesModuleInProcessScreenTo,UpdateTMIGStatusOnCGForm"" />" & _
"  <Property Name=""LoadLockA.IGStatus"" Code=""ChangeButtonIG6InCassettesScreenTo,SetIG6InCassettesScreenTo,UpdateLLAIGStatusOnCGForm"" />" & _
"  <Property Name=""LoadLockA.VacSwitchStatus"" Code=""ChangeLLACGRelayInCassettesScreenTo""/>" & _
"  <Property Name=""CassettesModule.VacSwitchStatus"" Code=""ChangeTMCGRelayInCassettesScreenTo""/>" & _
"  <Property Name=""CassettesModule.SwitchIGFilament"" Code=""ChangeButtonSwitchIGFilamentOfTMInCassettesScreenTo"" />" & _
"  <Property Name=""LoadLockA.SwitchIGFilament"" Code=""ChangeButtonSwitchIGFilamentOfLLAInCassettesScreenTo"" />" & _
"" & _
"   <Property Name=""CassettesModule.TurboForelineCGRelay"" Code=""ChangeTMTurboForelineCGRelay,ChangeTMTurboForelineCGRelayInControlOfCaseetePanel""/>" & _
"   <Property Name=""LoadLockA.TurboForelineCGRelay"" Code=""ChangeLLATurboForelineCGRelay,ChangeLLATurboForelineCGRelayInControlOfCaseetePanel""/>" & _
"   <Property Name=""RoughPumpMachine1.VacSwitchStatus"" Code=""ChangeMP1CGRelay""/>" & _
"   <Property Name=""RoughPumpMachine2.VacSwitchStatus"" Code=""ChangeMP2CGRelay""/>" & _
"   <Property Name=""RoughPumpMachine1.IsCommunicating"" Code=""ChangeCommunicationMP1""/>" & _
"   <Property Name=""RoughPumpMachine2.IsCommunicating"" Code=""ChangeCommunicationMP2""/>  " & _
"   <Property Name=""RoughPumpMachine1.WaitingMPOnMessager"" Code=""ChangeMP1WaitingMPOn""/>" & _
"   <Property Name=""RoughPumpMachine2.WaitingMPOnMessager"" Code=""ChangeMP2WaitingMPOn""/> " & _
"  " & _
"  <Property Name=""RoughPumpMachine1.CG"" Code=""ChangeRoughPump1InCassettesScreenTo,SetCGRoughPumpControl1InCassettesScreenTo,UpdateLRoughPump1CGPressOnCGForm""/>" & _
"  <Property Name=""RoughPumpMachine2.CG"" Code=""ChangeRoughPump2InCassettesScreenTo,SetCGRoughPumpControl2InCassettesScreenTo,UpdateLRoughPump2CGPressOnCGForm""/>" & _
"  <Property Name=""RoughPumpMachine1.CGPressureError"" Code=""ChangeRoughPump1InCassettesScreenTo,SetCGRoughPumpControl1InCassettesScreenTo""/>" & _
"  <Property Name=""RoughPumpMachine2.CGPressureError"" Code=""ChangeRoughPump2InCassettesScreenTo,SetCGRoughPumpControl2InCassettesScreenTo""/>" & _
"  <Property Name=""Alarm.AlarmStatus"" Code=""StartAlarm""/>" & _
"  <Property Name=""Alarm.RedStatus"" Code=""FlashRedLight""/>" & _
"  <Property Name=""Alarm.GreenStatus"" Code=""FlashGreenLight""/>" & _
"  <Property Name=""Alarm.OrangeStatus"" Code=""FlashOrangeLight""/>" & _
"  <Property Name=""Alarm.BlueStatus"" Code=""FlashBlueLight""/>" & _
"  " & _
"  <Property Name=""LLAPumpPackage.IsTurboCommunicating"" Code=""ChangeLLATurboCommunication,ChangeLLATurboCommunicationProcessPanel,ChangeLLATurboCommunicationInControl""/>" & _
"  <Property Name=""TMPumpPackage.IsTurboCommunicating"" Code=""ChangeTMTurboCommunication,ChangeTMTurboCommunicationProcessPanel,ChangeTMTurboCommunicationInControl""/>" & _
"   " & _
"  <!--End Kep Server-->" & _
"   <!--Alignment Information-->" & _
"  <Property Name=""Aligner.RSLTEccentricityAngleDeg"" Code=""SetAlignmentInformationEccentricityAngleTo,SetAlignmentInformationEccentricityAngleInTMScreenTo,SetAlignmentInformationEccentricityAngleInProcessScreenTo""/>" & _
"  <Property Name=""Aligner.RSLTAngularLocationDeg"" Code=""SetAlignmentInformationFiducialAngleTo""/>" & _
"  <Property Name=""Aligner.RSLTReScanNeed"" Code=""SetAlignmentInformationRescanNeededTo""/>" & _
"  <Property Name=""Aligner.RSLTMaxEccentricityMils"" Code=""SetAlignmentInformationEccentricityMagnitudeTo,SetAlignmentInformationEccentricityMagnitudeInTMScreenTo,SetAlignmentInformationEccentricityMagnitudeInProcessScreenTo""/>" & _
"  <Property Name=""Aligner.Wafer_Rstation"" Code=""SetAlignmentInformationWafer_RstationTo""/>" & _
"  <Property Name=""Aligner.Wafer_Tstation"" Code=""SetAlignmentInformationWafer_TstationTo""/>" & _
"  <Property Name=""Aligner.RecipeNameWaferInfo"" Code=""SetWaferInformationRecipeNameTo""/>" & _
"  <Property Name=""Aligner.WaferID"" Code=""SetWaferInformationWaferIDTo""/>" & _
"  <Property Name=""Aligner.WaferInsideAligner"" Code=""SetWaferInsideAlignerInCassettesScreenTo,SetWaferInsideAlignerInProcessScreenTo,SetWaferInformationWaferIDTo""/>" & _
"  <Property Name=""Aligner.ResponseMessage"" Code=""SetStatusOfSerialCommandInCassettesScreenTo""/>" & _
"  <Property Name=""Aligner.IsCommunicating"" Code=""SetToolLEDInCassettesScreenTo""/>" & _
"  <Property Name=""Aligner.ErrorMessage"" Code=""StartAlarm Aligner""/>" & _
"  <Property Name=""Aligner.OperationStatus"" Code=""ChangeAlignerOperatingStatusTo""/>" & _
"  <Property Name=""Aligner.ProcessControl_GetRunDataFileName"" Code=""SetAligner_ProcessControl_GetRunDataFileNameTo""/>" & _
"  <Property Name=""Aligner.WaferAlignAngle"" Code=""SetWaferInformationAngleTo""/>" & _
"" & _
"  <!--End Aligner-->" & _
"  <Property Name=""LLAElevator.HasWaferPresent"" Code=""SetWaferPresentOfLoadLockAInCassettesScreenTo""/>" & _
"  <Property Name=""Robot.WaferInsideRobot"" Code=""SetRotateRobotInCassettesScreenTo,SetRotateRobotInProcessScreenTo""/>" & _
"  <Property Name=""Robot.IsCommunicating"" Code=""SetRobotLEDInCassettesScreenTo""/>" & _
"  <Property Name=""Robot.IsRetracted"" Code=""""/>" & _
"  <Property Name=""Robot.OperationStatus"" Code=""ChangeRobotOperatingStatusTo""/>" & _
"  <Property Name=""Robot.ErrorMessage"" Code=""StartAlarm Robot""/>" & _
"  <Property Name=""Robot.Version"" Code=""SetRobotVersionValueTo""/>" & _
"  <Property Name=""Robot.ApplyRobotStatus"" Code=""SetRobotApplyStatus""/>    " & _
"  <Property Name=""LLAElevator.IsCommunicating"" Code=""SetComunicationLEDOfLoadLockAInCassettesScreenTo""/>" & _
"  <Property Name=""LLAElevator.ErrorMessage"" Code=""StartAlarm LLAElevator""/>" & _
"  <Property Name=""LLAElevator.CPStatus"" Code=""SetCPLEDOfLoadLockAInCassettesScreenTo,ChangeLoadedStatusOfCassetteLLAInProcessScreenTo,ChangeLoadedStatusOfCassetteLLAInCassettesScreenTo""/>" & _
"  <Property Name=""LLAElevator.CLStatus"" Code=""SetCLLEDOfLoadLockAInCassettesScreenTo,SetClampLEDDOfLoadLockAInProcessScreenTo""/>" & _
"  <Property Name=""TMPumpPackage.PumpStatus"" Code=""ChangeButtonOnOfTMCryoInCassettesScreenTo,ChangeButtonOnOfTMCryoInPopUpInCassettesScreenTo""/>" & _
"  <Property Name=""TMWaterPump.PumpStatus"" Code=""ChangeButtonOnOfTMWaterPumpInCassettesScreenTo""/>" & _
"  <Property Name=""LLAPumpPackage.PumpStatus"" Code=""ChangeButtonOnOfLLACryoInCassettesScreenTo,ChangeButtonOnOfLLACryoInPopUpInCassettesScreenTo""/>" & _
"  <Property Name=""TMPumpPackage.ErrorMessage"" Code=""StartAlarm TMCryo""/>" & _
"  <Property Name=""TMWaterPump.ErrorMessage"" Code=""StartAlarm TMWaterPump""/>" & _
"  <Property Name=""LLAPumpPackage.ErrorMessage"" Code=""StartAlarm LLACryo""/>" & _
"  <Property Name=""TMPumpPackage.RegenStatus"" Code=""ChangeButtonRegenOfTMCryoInCassettesScreenTo,ChangeButtonRegenOfTMCryoInPopUpInCassettesScreenTo""/>" & _
"  <Property Name=""TMPumpPackage.RegenStatusText"" Code=""ChangeStatusRegenOfTMCryoInPopUpInCassettesScreenTo""/>" & _
"  <Property Name=""TMWaterPump.RegenStatus"" Code=""ChangeButtonRegenOfTMWaterPumpInCassettesScreenTo""/>" & _
"  <Property Name=""LLAPumpPackage.RegenStatus"" Code=""ChangeButtonRegenOfLLACryoInCassettesScreenTo,ChangeButtonRegenOfLLACryoInPopUpInCassettesScreenTo""/>" & _
"  <Property Name=""LLAPumpPackage.RegenStatusText"" Code=""ChangeStatusRegenOfLLACryoInPopUpInCassettesScreenTo""/>" & _
"  " & _
"  <Property Name=""LLAPumpPackage.RegenHour"" Code=""SetRegenHourOfLLACryoInCassettesScreenTo""/>" & _
"  <Property Name=""TMPumpPackage.RegenHour"" Code=""SetRegenHourOfTMCryoInCassettesScreenTo""/>" & _
"  <Property Name=""LLAPumpPackage.RegenLifeTime"" Code=""SetRegenLifeTimeOfLLACryoInCassettesScreenTo""/>" & _
"  <Property Name=""TMPumpPackage.RegenLifeTime"" Code=""SetRegenLifeTimeOfTMCryoInCassettesScreenTo""/>" & _
"  <Property Name=""LLAPumpPackage.PumpRestartDelay"" Code=""SetPumpRestartDelayOfLLACryoInCassettesScreenTo""/>" & _
"  <Property Name=""TMPumpPackage.PumpRestartDelay"" Code=""SetPumpRestartDelayOfTMCryoInCassettesScreenTo""/>" & _
"  " & _
"  <Property Name=""LLAPumpPackage.ExtendedPurgeTime"" Code=""SetExtendedPurgeTimeOfLLACryoInCassettesScreenTo""/>" & _
"  <Property Name=""TMPumpPackage.ExtendedPurgeTime"" Code=""SetExtendedPurgeTimeOfTMCryoInCassettesScreenTo""/>" & _
"" & _
"  <Property Name=""LLAPumpPackage.RepurgeCycles"" Code=""SetRepurgeCyclesOfLLACryoInCassettesScreenTo""/>" & _
"  <Property Name=""TMPumpPackage.RepurgeCycles"" Code=""SetRepurgeCyclesOfTMCryoInCassettesScreenTo""/>" & _
"" & _
"  <Property Name=""LLAPumpPackage.RoughToPressure"" Code=""SetRoughToPressureOfLLACryoInCassettesScreenTo""/>" & _
"  <Property Name=""TMPumpPackage.RoughToPressure"" Code=""SetRoughToPressureOfTMCryoInCassettesScreenTo""/>" & _
"  " & _
"  <Property Name=""LLAPumpPackage.RateOfRise"" Code=""SetRateOfRiseOfLLACryoInCassettesScreenTo""/>" & _
"  <Property Name=""TMPumpPackage.RateOfRise"" Code=""SetRateOfRiseOfTMCryoInCassettesScreenTo""/>" & _
"  " & _
"  <Property Name=""LLAPumpPackage.StartUpTemp"" Code=""SetStartUpTimeOfLLACryoInCassettesScreenTo""/>" & _
"  <Property Name=""TMPumpPackage.StartUpTemp"" Code=""SetStartUpTimeOfTMCryoInCassettesScreenTo""/>" & _
"  <Property Name=""LLAPumpPackage.T1"" Code=""SetT1OfLLACryoInCassettesScreenTo""/>" & _
"  <Property Name=""LLAPumpPackage.T2"" Code=""SetT2OfLLACryoInCassettesScreenTo""/>" & _
"  <Property Name=""TMPumpPackage.T1"" Code=""SetT1OfTMCryoInCassettesScreenTo""/>" & _
"  <Property Name=""TMPumpPackage.T2"" Code=""SetT2OfTMCryoInCassettesScreenTo""/>" & _
"  <Property Name=""TMWaterPump.T1"" Code=""SetTOfTMWaterPumpInCassettesScreenTo""/>" & _
"  <Property Name=""LLAPumpPackage.IsCommunicating"" Code=""SetComunicationCryoOfLLAInCassettesPanelTo""/>" & _
"  <Property Name=""TMPumpPackage.IsCommunicating"" Code=""SetComunicationCryoOfTMInCassettesPanelTo""/>" & _
"" & _
"  <Property Name=""TMPumpPackage.TurboUptoSpeed"" Code=""SetTurboUptoSpeedOfTMInCassettesScreenTo,SetTurboUptoSpeedOfTMInProcessPanelTo,SetTurboUptoSpeedOfTMInControlOfCassettesScreenTo""/>" & _
"  <Property Name=""TMPumpPackage.TurboStatus"" Code=""SetTurboStatusOfTMInCassettesScreenTo,SetTurboStatusOfTMInProcessPanelTo,SetTurboStatusOfTMInControlOfCassettesScreenTo""/>" & _
"  <Property Name=""TMPumpPackage.RampingPercent"" Code=""SetTurboRampingPercentOfTMInCassettesScreenTo,SetTurboRampingPercentOfTMInProcessPanelTo,SetTurboRampingPercentOfTMInControlOfCassettesScreenTo,SetTurboRampingPercentOfTMInControlLabelOfCassettesScreenTo""/>" & _
"  <Property Name=""LLAPumpPackage.RampingPercent"" Code=""SetTurboRampingPercentOfLLAInCassettesScreenTo,SetTurboRampingPercentOfLLAInProcessPanelTo,SetTurboRampingPercentOfLLAInControlOfCassettesScreenTo,SetTurboRampingPercentOfLLAInControlLabelOfCassettesScreenTo""/>" & _
"  <Property Name=""LLAPumpPackage.TurboUptoSpeed"" Code=""SetTurboUptoSpeedOfLLAInCassettesScreenTo,SetTurboUptoSpeedOfLLAInProcessPanelTo,SetTurboUptoSpeedOfLLAInControlOfCassettesScreenTo""/>" & _
"  <Property Name=""LLAPumpPackage.TurboStatus"" Code=""SetTurboStatusOfLLAInCassettesScreenTo,SetTurboStatusOfLLAInProcessPanelTo,SetTurboStatusOfLLAInControlOfCassettesScreenTo""/>" & _
"" & _
"  <Property Name=""TMWaterPump.IsCommunicating"" Code=""SetComunicationWaterPumpOfTMInCassettesPanelTo""/>" & _
"  <Property Name=""LLAElevator.OperationStatus"" Code=""ChangeLLAOperatingStatusTo""/>" & _
"  <Property Name=""LLAElevator.CurrentSlot"" Code=""ChangeSlotElevatorOfLoadLockAInProcessScreenTo,ChangeSlotElevatorOfLoadLockAInCassettesScreenTo""/>" & _
"  <Property Name=""LLAElevator.MapWaferSuccess"" Code=""CheckMapWaferLoadLockASuccess""/>" & _
"  <Property Name=""LLAElevator.DCStatus"" Code=""SetDCLEDOfLoadLockAInCassettesScreenTo,ChangeBottomLEDofLeftFootInProcessScreenTo,ChangeBottomLEDofLeftFootInCassettesScreenTo,ChangeLLADoorStatusTo""/>" & _
"  <Property Name=""CassettesModule.ControlStatus"" Code=""ChangeMechineOnlineInCassettesScreenTo"" />" & _
"  <Property Name=""LoadLockA.ControlStatus"" Code=""ChangeLeftOnlineInCassettesScreenTo,SetOnlineLoadLockAInProcessScreenTo"" />" & _
"  <Property Name=""CassettesModule.AutoVentStatus"" Code=""ChangeMechineStopVentInCassettesScreenTo,EnableDisableVentTransfer"" />" & _
"  <Property Name=""LoadLockA.AutoVentStatus"" Code=""ChangeLeftStopVentInCassettesScreenTo,EnableDisableVentA"" />" & _
"  <Property Name=""CassettesModule.PumpDownStatus"" Code=""ChangeMechineStopPumpDownInCassettesScreenTo"" />" & _
"  <Property Name=""LoadLockA.PumpDownStatus"" Code=""ChangeLeftStopPumpDownInCassettesScreenTo"" />" & _
"  <Property Name=""LLAElevator.SlotStatus"" Code=""ChangeWaferOfLoadLockAInProcessScreenTo,ChangeWaferOfLoadLockAInCassettesScreenTo""/>" & _
"  <Property Name=""Robot.ResponseMessage"" Code=""SetStatusOfSerialCommandInCassettesScreenTo""/>" & _
"  <Property Name=""LLAElevator.ResponseMessage"" Code=""SetStatusOfSerialCommandInCassettesScreenTo""/>" & _
"  <Property Name=""Alarm.SemiAutoMessage"" Code=""SetStatusOfSemiautoTransferWaferInCassettesScreenTo""/>" & _
"  <Property Name=""LoadLockA.SumWaferCount"" Code=""SetWaferCountInProcessScreenToLLA""/>" & _
"  <Property Name=""Robot.CurrentPosition"" Code=""RotateRobotHandInProcessScreenTo,RotateRobotHandInCassettesScreenTo,UpdateRobotPositionInCassettesScreenTo""/>" & _
"  <Property Name=""Robot.CurrentArmStatus"" Code=""UpdateRobotArmStatusInCassettesScreenTo""/>" & _
"  <Property Name=""LoadLockA.LoadStatus"" Code=""LoadLockALoadStatusInProcessScreenTo""/>" & _
"  <Property Name=""LoadLockA.UnloadStatus"" Code=""LoadLockAUnloadStatusInProcessScreenTo""/>" & _
"  <Property Name=""LoadLockA.AutoVentButtonLoadStatus"" Code=""LoadLockALoadStatusInProcessScreenTo""/>" & _
"  <Property Name=""LoadLockA.AutoVentButtonUnloadStatus"" Code=""LoadLockAUnloadStatusInProcessScreenTo""/>" & _
"  <Property Name=""LoadLockA.AbortStatus"" Code=""LoadLockAAbortStatusInProcessScreenTo""/>" & _
"  <Property Name=""LoadLockA.StartStatus"" Code=""LoadLockAStartStatusInProcessScreenTo,EnableDisableMachineToolAMenuItemsCassettesPanel,EnableDisableMachineToolTMMenuItemsCassettesPanel""/>" & _
"  <Property Name=""LoadLockA.SemiTransferStatus"" Code=""LoadLockAStartStatusInProcessScreenTo""/>" & _
"  <Property Name=""LLAElevator.StatusGraph"" Code=""ChangeWaferOfLoadLockAInProcessScreenTo,ChangeWaferOfLoadLockAInCassettesScreenTo""/>" & _
"  <Property Name=""CassettesModule.SelfAlignerStatus"" Code=""SelfAlignerStatusInCassettesScreenTo""/>" & _
"  <Property Name=""CassettesModule.RTBefore"" Code=""SelfAlignerRTBeforeInCassettesScreenTo""/>" & _
"  <Property Name=""CassettesModule.RTAfter"" Code=""SelfAlignerRTAfterInCassettesScreenTo""/>" & _
"  <Property Name=""CassettesModule.TestSetupStatus"" Code=""TestSetupStatusInSystemSetup""/>" & _
"  <Property Name=""CassettesModule.StartATMStatus"" Code=""CassettesModuleCycleATMStatus""/>" & _
"  " & _
"  <Property Name=""CassettesModule.AutoSequenceRunningStatusText"" Code=""SetNameOfTMAutoSequenceRunning""/>" & _
"  <Property Name=""LoadLockA.AutoSequenceRunningStatusText"" Code=""SetNameOfLLAAutoSequenceRunning""/>" & _
"  <Property Name=""LoadLockA.CycleUntilStatus"" Code=""LLATurnOnOffCycleUntilMode""/>" & _
"  <Property Name=""LoadLockA.CompletedCycleWafer"" Code=""LLACompletedCycleWaferAtInProcessScreentTo""/>" & _
"  <!--PVD-->" & _
"  <Property Name=""PVD.ConnectionStatus"" Code=""SetPVDChamber_ConnectionStatusTo,SetPVDChamber_ProcessMonitor_SetDeviceEnableDisableStartTo,SetPVDChamber_ProcessMonitor_SetDeviceEnableDisablePauseTo,SetPVDChamber_ProcessMonitor_SetDeviceEnableDisableAbortTo,SetPVD_ConnectionStatusInCassettesScreenTo""/>" & _
"  <!--Status panel-->" & _
"  <Property Name=""PVD.Initialize_Motion_readback"" Code=""SetPVDChamber_InitializeMotionPVDChamberTo""/>" & _
"  <Property Name=""PVD.EventMessage"" Code=""ShowPVDStatusMessage""/>" & _
"  <!--RF Target Power Supply -->" & _
"  <Property Name=""PVD.RFTargetPowerSupply_ForwardPower_Readback"" Code=""SetPVDChamber_RFTargetPowerSupply_SetForwardPowerTo,SetPVDChamber_TargetForwardPowerRB_InStatusProcess_To""/>" & _
"  <Property Name=""PVD.RFTargetPowerSupply_ForwardPower_Program"" Code=""SetPVDChamber_RFTargetPowerSupply_ForwardPowerRightTo,SetPVDChamber_TargetForwardPowerSP_InStatusProcess_To""/>" & _
"  <Property Name=""PVD.RFTargetPowerSupply_ReflectedPower_Readback"" Code=""SetPVDChamber_RFTargetPowerSupply_SetReflectedPowerTo,SetPVDChamber_TargetReflectivePowerRB_InStatusProcess_To""/>" & _
"  <Property Name=""PVD.RFTargetPowerSupply_Voltage_Readback"" Code=""SetPVDChamber_RFTargetPowerSupply_SetVoltageTo,SetPVDChamber_TargetReflectiveVoltageRB_InStatusProcess_To""/>" & _
"  <Property Name=""PVD.RFTargetPowerSupply_C1_Readback"" Code=""SetPVDChamber_RFTargetPowerSupply_SetC1To""/>" & _
"  <Property Name=""PVD.RFTargetPowerSupply_C1_Program"" Code=""SetPVDChamber_RFTargetPowerSupply_C1RightTo""/>" & _
"  <Property Name=""PVD.RFTargetPowerSupply_C2_Readback"" Code=""SetPVDChamber_RFTargetPowerSupply_SetC2To""/>" & _
"  <Property Name=""PVD.RFTargetPowerSupply_C2_Program"" Code=""SetPVDChamber_RFTargetPowerSupply_C2RightTo""/>" & _
"  <Property Name=""PVD.RFTargetPowerSupply_Match_Readback"" Code=""SetPVDChamber_RFTargetPowerSupply_SetMatchTo,SetPVDChamber_RFTargetPowerSupply_ChangeButtonAutoTo,SetPVDChamber_RFTargetPowerSupply_ChangeButtonRecallTo,SetPVDChamber_RFTargetPowerSupply_ChangeButtonStoreTo""/>" & _
"  <Property Name=""PVD.RFTargetPowerSupply_AutoStatus"" Code=""SetPVDChamber_RFTargetPowerSupply_ChangeButtonAutoTo""/>" & _
"  <Property Name=""PVD.RFTargetPowerSupply_Presets_Readback"" Code=""SetPVDChamber_RFTargetPowerSupply_SetPresetsTo""/>" & _
"  <Property Name=""PVD.RFTargetPowerSupply_Presets_Program"" Code=""SetPVDChamber_RFTargetPowerSupply_PresetsRightTo""/>" & _
"  <Property Name=""PVD.RFTargetPowerSupply_RecallStatus"" Code=""SetPVDChamber_RFTargetPowerSupply_ChangeButtonRecallTo""/>" & _
"  <Property Name=""PVD.RFTargetPowerSupply_StoreStatus"" Code=""SetPVDChamber_RFTargetPowerSupply_ChangeButtonStoreTo""/>" & _
"  <Property Name=""PVD.RFTargetPowerSupply_KWH_Readback"" Code=""SetPVDChamber_RFTargetPowerSupply_SetKWHTo""/>  " & _
"  <Property Name=""PVD.RFTargetPowerSupply_CommunicationStatus"" Code=""SetPVDChamber_RFTargetPowerSupply_SetCommunicationTo""/>" & _
"  <!--DC Target Power Supply -->" & _
"  <Property Name=""PVD.DCTargetPowerSupply_Power_Readback"" Code=""SetPVDChamber_DCTargetPowerSupply_SetPowerTo,SetPVDChamber_TargetForwardPowerRB_InStatusProcess_To""/>" & _
"  <Property Name=""PVD.DCTargetPowerSupply_Power_Program"" Code=""SetPVDChamber_DCTargetPowerSupply_PowerRightTo,SetPVDChamber_TargetForwardPowerSP_InStatusProcess_To""/>" & _
"  <Property Name=""PVD.DCTargetPowerSupply_Voltage_Readback"" Code=""SetPVDChamber_DCTargetPowerSupply_SetVoltageTo,SetPVDChamber_VoltageRB_InStatusProcess_To""/>" & _
"  <Property Name=""PVD.DCTargetPowerSupply_Voltage_Program"" Code=""SetPVDChamber_DCTargetPowerSupply_VoltageRightTo,SetPVDChamber_VoltageSP_InStatusProcess_To""/>" & _
"  <Property Name=""PVD.DCTargetPowerSupply_Current_Readback"" Code=""SetPVDChamber_DCTargetPowerSupply_SetCurrentTo,SetPVDChamber_CurrentRB_InStatusProcess_To""/>" & _
"  <Property Name=""PVD.DCTargetPowerSupply_Current_Program"" Code=""SetPVDChamber_DCTargetPowerSupply_CurrentRightTo,SetPVDChamber_CurrentSP_InStatusProcess_To""/>  " & _
"  <Property Name=""PVD.DCTargetPowerSupply_Ramptime_Program"" Code=""SetPVDChamber_DCTargetPowerSupply_RampTimeTo""/>" & _
"  <Property Name=""PVD.DCTargetPowerSupply_Ramptime_Readback"" Code=""SetPVDChamber_DCTargetPowerSupply_SetRampTimeTo""/>  " & _
"  <Property Name=""PVD.DCTargetPowerSupply_MagnetronRotationStatus"" Code=""SetPVDChamber_DCTargetPowerSupply_SetMagnetronRotationTo,SetPVDChamber_SetMagnatron_RotatingTo""/>" & _
"  <Property Name=""PVD.DCTargetPowerSupply_DCPulse_Readback"" Code=""SetPVDChamber_DCTargetPowerSupply_SetDCPulseTo,SetPVDChamber_DCTargetPowerSupply_SetDCPulseStatusTo,SetPVDChamber_PulseRB_InStatusProcess_To""/>" & _
"  <Property Name=""PVD.DCTargetPowerSupply_DCPulseStatus"" Code=""SetPVDChamber_DCTargetPowerSupply_SetDCPulseStatusTo,SetPVDChamber_PulseSP_InStatusProcess_To""/>" & _
"  <Property Name=""PVD.DCTargetPowerSupply_KWH_Readback"" Code=""SetPVDChamber_DCTargetPowerSupply_SetKWHTo""/>  " & _
"  <Property Name=""PVD.DCTargetPowerSupply_CommunicationStatus"" Code=""SetPVDChamber_DCTargetPowerSupply_SetCommunicationTo""/>" & _
"  <!--BIAS Target Power Supply -->" & _
"  <Property Name=""PVD.BiasPowerSupply_ForwardPower_Readback"" Code=""SetPVDChamber_BiasPowerSupply_SetForwardPowerTo,SetPVDChamber_BiasPowerSupply_ForwardPower_InStatusProcess_To""/>" & _
"  <Property Name=""PVD.BiasPowerSupply_ForwardPower_Program"" Code=""SetPVDChamber_BiasPowerSupply_ForwardPowerRightTo,SetPVDChamber_BiasPowerSupply_ForwardPowerRight_InStatusProcess_To""/>" & _
"  <Property Name=""PVD.BiasPowerSupply_ReflectedPower_Readback"" Code=""SetPVDChamber_BiasPowerSupply_SetReflectedPowerTo,SetPVDChamber_BiasReflectedPowerRB_InStatusProcess_To""/>" & _
"  <Property Name=""PVD.BiasPowerSupply_Voltage_Readback"" Code=""SetPVDChamber_BiasPowerSupply_SetVoltageTo""/>" & _
"  <Property Name=""PVD.BiasPowerSupply_Voltage_Program"" Code=""SetPVDChamber_BiasPowerSupply_SetVoltageRightTo""/>" & _
"  <Property Name=""PVD.BiasPowerSupply_C1_Readback"" Code=""SetPVDChamber_BiasPowerSupply_SetC1To""/>" & _
"  <Property Name=""PVD.BiasPowerSupply_C1_Program"" Code=""SetPVDChamber_BiasPowerSupply_C1RightTo""/>" & _
"  <Property Name=""PVD.BiasPowerSupply_C2_Readback"" Code=""SetPVDChamber_BiasPowerSupply_SetC2To""/>" & _
"  <Property Name=""PVD.BiasPowerSupply_C2_Program"" Code=""SetPVDChamber_BiasPowerSupply_C2RightTo""/>" & _
"  <Property Name=""PVD.BiasPowerSupply_Match_Readback"" Code=""SetPVDChamber_BiasPowerSupply_SetMatchTo,SetPVDChamber_BiasPowerSupply_ChangeButtonAutoTo,SetPVDChamber_BiasPowerSupply_ChangeButtonRecallTo,SetPVDChamber_BiasPowerSupply_ChangeButtonStoreTo""/>" & _
"  <Property Name=""PVD.BiasPowerSupply_AutoStatus"" Code=""SetPVDChamber_BiasPowerSupply_ChangeButtonAutoTo""/>" & _
"  <Property Name=""PVD.BiasPowerSupply_Presets_Readback"" Code=""SetPVDChamber_BiasPowerSupply_SetPresetsTo""/>" & _
"  <Property Name=""PVD.BiasPowerSupply_Presets_Program"" Code=""SetPVDChamber_BiasPowerSupply_PresetsRightTo""/>" & _
"  <Property Name=""PVD.BiasPowerSupply_RecallStatus"" Code=""SetPVDChamber_BiasPowerSupply_ChangeButtonRecallTo""/>" & _
"  <Property Name=""PVD.BiasPowerSupply_StoreStatus"" Code=""SetPVDChamber_BiasPowerSupply_ChangeButtonStoreTo""/>" & _
"  <Property Name=""PVD.BiasPowerSupply_CommunicationStatus"" Code=""SetPVDChamber_BiasPowerSupply_SetCommunicationTo""/>" & _
"  <Property Name=""PVD.BiasTargetPowerSupply_Mag"" Code=""SetPVDChamber_BiasTargetPowerSupply_SetMagTo""/>" & _
"  <Property Name=""PVD.BiasTargetPowerSupply_Phase"" Code=""SetPVDChamber_BiasTargetPowerSupply_SetPhaseTo""/>" & _
"  <Property Name=""PVD.BiasTargetPowerSupply_ErrorStatus"" Code=""SetPVDChamber_BiasTargetPowerSupply_SetErrorStatusTo""/>" & _
"  <!--Parallel -->" & _
"  <Property Name=""PVD.ParallelMagnet_Current_Program"" Code=""SetPVDChamber_ParallelMagnet_CurrentRightTo""/>" & _
"  <Property Name=""PVD.ParallelMagnet_Current_Readback"" Code=""SetPVDChamber_ParallelMagnet_SetCurrentTo""/>" & _
"  <Property Name=""PVD.ParallelMagnet_Duty_Program"" Code=""SetPVDChamber_ParallelMagnet_DutyRightTo""/>" & _
"  <Property Name=""PVD.ParallelMagnet_Frequency_Program"" Code=""SetPVDChamber_ParallelMagnet_FrequencyRightTo""/>" & _
"  <Property Name=""PVD.ParallelMagnet_Voltage_Readback"" Code=""SetPVDChamber_ParallelMagnet_SetVoltageTo""/>" & _
"  <Property Name=""PVD.ParallelMagnet_Status"" Code=""SetPVDChamber_ParallelMagnet_SetStatusTo""/>" & _
"  <!--GasController-->" & _
"  <Property Name=""PVD.GasController_Gas1_Program"" Code=""SetPVDChamber_GasController_Gas1RightTo,SetPVDChamber_Gas1SP_InStatusProcess_To""/>" & _
"  <Property Name=""PVD.GasController_Gas1_Readback"" Code=""SetPVDChamber_GasController_SetGas1To,SetPVDChamber_Gas1RB_InStatusProcess_To""/>" & _
"  <Property Name=""PVD.GasController_Gas2_Program"" Code=""SetPVDChamber_GasController_Gas2RightTo,SetPVDChamber_Gas2SP_InStatusProcess_To""/>" & _
"  <Property Name=""PVD.GasController_Gas2_Readback"" Code=""SetPVDChamber_GasController_SetGas2To,SetPVDChamber_Gas2RB_InStatusProcess_To""/>" & _
"  <Property Name=""PVD.GasController_Gas3_Program"" Code=""SetPVDChamber_GasController_Gas3RightTo,SetPVDChamber_Gas3SP_InStatusProcess_To""/>" & _
"  <Property Name=""PVD.GasController_Gas3_Readback"" Code=""SetPVDChamber_GasController_SetGas3To,SetPVDChamber_Gas3RB_InStatusProcess_To""/>" & _
"  <Property Name=""PVD.GasController_Gas4_Program"" Code=""SetPVDChamber_GasController_Gas4RightTo,SetPVDChamber_Gas4SP_InStatusProcess_To""/>" & _
"  <Property Name=""PVD.GasController_Gas4_Readback"" Code=""SetPVDChamber_GasController_SetGas4To,SetPVDChamber_Gas4RB_InStatusProcess_To""/>" & _
"  <Property Name=""PVD.GasController_Gas5_Program"" Code=""SetPVDChamber_GasController_Gas5RightTo""/>" & _
"  <Property Name=""PVD.GasController_Gas5_Readback"" Code=""SetPVDChamber_GasController_SetGas5To""/>" & _
"  <!--ChamberInterlock - 4 basic-->" & _
"  <Property Name=""PVD.ChamberInterlocks_ChuckWaterStatus"" Code=""SetPVDChamber_ChamberInterlock_SetChuckWaterTo""/>" & _
"  <Property Name=""PVD.ChamberInterlocks_PSRelayStatus"" Code=""SetPVDChamber_ChamberInterlock_ChangeButtonPSRelayTo""/>" & _
"  <Property Name=""PVD.ChamberInterlocks_ChamWaterStatus"" Code=""SetPVDChamber_ChamberInterlock_SetChamWaterTo""/>" & _
"  <Property Name=""PVD.ChamberInterlocks_ChamPressStatus"" Code=""SetPVDChamber_ChamberInterlock_SetChamPressTo""/>" & _
"  <!--ChamberInterlock - 7 configurable-->" & _
"  <Property Name=""PVD.ChamberInterlocks_TurboWaterStatus"" Code=""SetPVDChamber_ChamberInterlock_SetTurboWaterTo""/>" & _
"  <Property Name=""PVD.ChamberInterlocks_TurboForelineStatus"" Code=""SetPVDChamber_ChamberInterlock_SetTurboForelineTo""/>" & _
"  <Property Name=""PVD.ChamberInterlocks_TableWaterStatus"" Code=""SetPVDChamber_ChamberInterlock_SetTableWaterTo""/>" & _
"  <Property Name=""PVD.ChamberInterlocks_LidSensorStatus"" Code=""SetPVDChamber_ChamberInterlock_SetLidSensorTo""/>" & _
"  <Property Name=""PVD.ChamberInterlocks_MatchWaterStatus"" Code=""SetPVDChamber_ChamberInterlock_SetMatchWaterTo""/>  " & _
"  <Property Name=""PVD.ChamberInterlocks_LidWaterStatus"" Code=""SetPVDChamber_ChamberInterlock_SetLidWaterTo""/>" & _
"  <Property Name=""PVD.ChamberInterlocks_TargetWaterStatus"" Code=""SetPVDChamber_ChamberInterlock_SetTargetWaterTo""/>" & _
"  <Property Name=""PVD.ChamberInterlocks_AirPressureStatus"" Code=""SetPVDChamber_ChamberInterlock_SetAirPressureTo""/>" & _
"  <Property Name=""PVD.ChamberInterlocks_TargetMBWaterStatus"" Code=""SetPVDChamber_ChamberInterlock_SetTargetMBWaterTo""/>" & _
"  <Property Name=""PVD.ChamberInterlocks_SubMBWaterStatus"" Code=""SetPVDChamber_ChamberInterlock_SetSubMBWaterTo""/>" & _
"  <Property Name=""PVD.ChamberInterlocks_ClampWaterStatus"" Code=""SetPVDChamber_ChamberInterlock_SetClampWaterTo""/>" & _
"  <!-- ProcessMonitor-->" & _
"  <Property Name=""PVD.ProcessMonitor_ProcessTime_Readback"" Code=""SetPVDChamber_ProcessMonitor_SetProcessTimeTo""/>" & _
"  <Property Name=""PVD.WaferID"" Code=""SetPVDChamber_ProcessMonitor_WaferID""/>" & _
"  <Property Name=""PVD.Recipe"" Code=""SetRecipeOfChamberInProcessScreenTo,SetPVDChamber_ProcessMonitor_SetRecipeTo,SetRecipeOfChamberDetailsInProcessScreenTo,SetPVDChamber_ProcessMonitor_SetRecipeNameTo""/>" & _
"  <Property Name=""PVD.ProcessStep"" Code=""SetPVDChamber_ProcessMonitor_SetProcessStepTo,SetStepNumberOfChamberInProcessScreenTo""/>" & _
"  <Property Name=""PVD.StepTime"" Code=""SetStepTimeOfChamberInProcessScreenTo,SetPVDChamber_ProcessMonitor_SetStepTimeTo,SetStepTimeOfChamberDetailsInProcessScreenTo""/>" & _
"  <Property Name=""PVD.ProcessMonitor_Status_Readback"" Code=""SetStatusOfChamberInProcessScreenTo,SetPVDChamber_ProcessMonitor_SetStatusTo,SetStatusOfChamberDetailsInProcessScreenTo""/>" & _
"" & _
"  <Property Name=""PVD.ProcessMonitor_DeviceStart_Readback"" Code=""SetPVDChamber_ProcessMonitor_SetDeviceStartTo""/>" & _
"  <Property Name=""PVD.ProcessMonitor_DeviceStop_Readback"" Code=""SetPVDChamber_ProcessMonitor_SetDeviceStopTo""/>" & _
"  <Property Name=""PVD.ProcessMonitor_DevicePause_Readback"" Code=""SetPVDChamber_ProcessMonitor_SetDevicePauseTo""/>" & _
"  <Property Name=""PVD.ProcessMonitor_DeviceResume_Readback"" Code=""SetPVDChamber_ProcessMonitor_SetDeviceResumeTo""/>" & _
"  <Property Name=""PVD.ProcessMonitor_DeviceError_Readback"" Code=""SetPVDChamber_ProcessMonitor_SetDeviceErrorTo""/>" & _
"  <Property Name=""PVD.ProcessMonitor_ResetError_Readback"" Code=""SetPVDChamber_ProcessMonitor_SetDeviceResetErrorTo""/>" & _
"  <Property Name=""PVD.ProcessControl_GetRunDataFileName"" Code=""SetPVDChamber_ProcessControl_GetRunDataFileNameTo""/>" & _
"  " & _
"  <!--Valves-->" & _
"  <Property Name=""PVD.ShutOff1ValveStatus"" Code=""SetPVDChamber_SetShutOff1ValveStatus,SetPVDChamber_SetShutOff1GasLineStatus""/>" & _
"  <Property Name=""PVD.ShutOff2ValveStatus"" Code=""SetPVDChamber_SetShutOff2ValveStatus,SetPVDChamber_SetShutOff2GasLineStatus""/>" & _
"  <Property Name=""PVD.ShutOff3ValveStatus"" Code=""SetPVDChamber_SetShutOff3ValveStatus,SetPVDChamber_SetShutOff3GasLineStatus""/>" & _
"  <Property Name=""PVD.ShutOff4ValveStatus"" Code=""SetPVDChamber_SetShutOff4ValveStatus,SetPVDChamber_SetShutOff4GasLineStatus""/>" & _
"  <Property Name=""PVD.ShutOff5ValveStatus"" Code=""SetPVDChamber_SetShutOff5ValveStatus,SetPVDChamber_SetShutOff5GasLineStatus""/>" & _
"" & _
"  <Property Name=""PVD.Supply1ValveStatus"" Code=""SetPVDChamber_SetSupply1ValveStatus,SetPVDChamber_SetSupply1GasLineStatus""/>" & _
"  <Property Name=""PVD.Supply2ValveStatus"" Code=""SetPVDChamber_SetSupply2ValveStatus,SetPVDChamber_SetSupply2GasLineStatus""/>" & _
"  <Property Name=""PVD.Supply3ValveStatus"" Code=""SetPVDChamber_SetSupply3ValveStatus,SetPVDChamber_SetSupply3GasLineStatus""/>" & _
"  <Property Name=""PVD.Supply4ValveStatus"" Code=""SetPVDChamber_SetSupply4ValveStatus,SetPVDChamber_SetSupply4GasLineStatus""/>" & _
"  <Property Name=""PVD.Supply5ValveStatus"" Code=""SetPVDChamber_SetSupply5ValveStatus,SetPVDChamber_SetSupply5GasLineStatus""/>" & _
"" & _
"  <Property Name=""PVD.MainGasValveStatus"" Code=""SetPVDChamber_SetMainGasValve_Status,SetPVDChamber_SetMainGasLineValve_Status""/>" & _
"  <Property Name=""PVD.HivacValveStatus"" Code=""SetPVDChamber_SetHivacValve_Status,SetPVDChamber_HivacRB_InStatusProcess_To""/>" & _
"  <Property Name=""PVD.OverrideMode_Status"" Code=""SetPVDChamber_SetOverrideMode_Status""/>" & _
"  <Property Name=""PVD.BaratronValveStatus"" Code=""SetPVDChamber_SetBaratronValveStatus,SetPVDChamber_SetBaratronValveGasLineStatus""/>" & _
"  <Property Name=""PVD.VentValveStatus"" Code=""SetPVDChamber_SetVentValveStatus,SetPVDChamber_SetVentValveGasLineStatus""/>" & _
"  <Property Name=""PVD.RoughValveStatus"" Code=""SetPVDChamber_SetRoughValveStatus,SetPVDChamber_SetRoughValveGasLineStatus""/>" & _
"  <Property Name=""PVD.WaterValveStatus"" Code=""SetPVDChamber_SetWaterValveStatus""/>" & _
"  <Property Name=""PVD.PlasmaIgniterStatus"" Code=""SetPVDChamber_SetPlasmaIgniterStatus""/>" & _
"  <Property Name=""PVD.Turbo_IsolationValveStatus"" Code=""SetPVDChamber_SetTurbo_IsolationValveStatus,SetPVDChamber_SetTurbo_IsolationValveGasLineStatus""/>" & _
"  <Property Name=""PVD.Shutter_ValveStatus"" Code=""SetPVDChamber_SetShutter_ValveStatus""/>" & _
"  <!--Vat Valve Controller-->" & _
"  <Property Name=""PVD.VatValve_Pressure_Program"" Code=""SetPVDChamber_PressureRightTo""/>" & _
"  <Property Name=""PVD.VatValve_PressurePercent_Program"" Code=""SetPVDChamber_PressurePercentRightTo""/>" & _
"  <Property Name=""PVD.VatValve_Teach_Program"" Code=""SetPVDChamber_TeachTo""/>" & _
"  <Property Name=""PVD.VatValve_SizeAdjust_Program"" Code=""SetPVDChamber_SizeAdjustTo""/>" & _
"  <Property Name=""PVD.VatValve_AutoZero_Program"" Code=""SetPVDChamber_AutoZeroTo""/>" & _
"  <Property Name=""PVD.VatValve_CommunicationStatus"" Code=""SetPVDChamber_SetVatValveCommunicationTo,SetPVDChamber_SetVatValveGasLineStatus""/>" & _
"  <Property Name=""PVD.VatValve_Percentage"" Code=""SetPVDChamber_SetHivacValve_Status""/>" & _
"  <!--Cryo-->" & _
"  <Property Name=""PVD.Cryo_T1_Readback"" Code=""SetPVDChamber_SetCryoT1To""/>" & _
"  <Property Name=""PVD.Cryo_T2_Readback"" Code=""SetPVDChamber_SetCryoT2To""/>" & _
"  <Property Name=""PVD.Cryo_RegenHour_Readback"" Code=""SetPVDChamber_SetCryoRegenHourToPopUpPanel""/>" & _
"  <Property Name=""PVD.Cryo_LifeTimeHour_Readback"" Code=""SetPVDChamber_SetCryoLifeTimeHourToPopUpPanel""/>" & _
"  <Property Name=""PVD.Cryo_CommunicationStatus"" Code=""SetPVDChamber_SetCryoCommunicationTo""/>" & _
"  <Property Name=""PVD.MachineCryoRegn"" Code=""SetPVDChamber_SetMnuCryoRegenTo,SetPVDChamber_SetCryoRegenButtonTo,SetTMChamber_SetCryoRegenSTatusTo""/>" & _
"  <Property Name=""PVD.CryoRegenStatusText"" Code=""SetPVDChamber_SetCryoRegenStatusTextTo""/>" & _
"   <!--Baratron-->" & _
"  <Property Name=""PVD.ProcessPressure"" Code=""SetPVDChamber_SetBaratronBATo,SetProcessPressureOfChamberInProcessScreenTo,SetPVDChamber_BARB_InStatusProcess_To""/>" & _
"  <Property Name=""PVD.Baratron_CG_Program"" Code=""SetPVDChamber_BaratronCGRightTo""/>" & _
"  <Property Name=""PVD.CG"" Code=""SetPVDChamber_SetBaratronCGTo,SetPVDChamber_ProcessPressureRB_InStatusProcess_T,UpdatePVDCGPressureInCGPopUp""/>" & _
"  <Property Name=""PVD.IG"" Code=""SetPVDChamber_SetBaratronIGTo,SetPVDChamber_ProcessPressureRB_InStatusProcess_To""/>" & _
"  <Property Name=""PVD.IGStatus"" Code=""SetPVDChamber_SetBaratronIGStatusTo""/>" & _
"  <Property Name=""PVD.WaferInside"" Code=""SetWaferInsideChamberInProcessScreenTo,SetPVDChamber_ProcessMonitor_WaferID""/>" & _
"  <!--Other-->" & _
"  <Property Name=""PVD.PM_WaferCount"" Code=""SetPVDChamber_SetIncreaseWaferCount""/>" & _
"  <Property Name=""PVD.MG_Information"" Code=""SetPVDChamber_SetMGInformationTo,SetPVDChamber_MGRB_InStatusProcess_To""/>" & _
"  <Property Name=""PVD.CG_Information"" Code=""SetPVDChamber_SetCGInformationTo,SetPVDChamber_SetPVDRoughPumpStatusTo""/>" & _
"" & _
"  <Property Name=""PVD.PVDRoughPumpStatus"" Code=""SetPVDChamber_SetPVDRoughPumpStatusTo,UpdatePVDRoughlineCGPressureInCGPopUp""/>" & _
"  <Property Name=""PVD.WaferStatus"" Code=""SetPVDChamber_SetWaferStatusTo""/>" & _
"" & _
"  <Property Name=""PVD.RoughLineCG_Readback"" Code=""SetPVDChamber_SetRoughLineCGTo""/>" & _
"  <Property Name=""PVD.ForeLineCG_Readback"" Code=""SetPVDChamber_SetForeLineCGTo,UpdatePVDForelineCGPressureInCGPopUp""/>" & _
"" & _
"  <Property Name=""PVD.ChuckPos_Readback"" Code=""SetPVDChamber_SetChuckPosTo,SetPVDChamber_ChuckRB_InStatusProcess_To""/>" & _
"  <Property Name=""PVD.ChuckPos_Program"" Code=""SetPVDChamber_ChuckPosRightTo,SetPVDChamber_ChuckSP_InStatusProcess_To""/>" & _
"  <Property Name=""PVD.ClampStatus_Readback"" Code=""SetPVDChamber_ClampTo,SetPVDChamber_ClampRB_InStatusProcess_To""/>" & _
"  <Property Name=""PVD.Plasma_Status_Readback"" Code=""SetPVDChamber_PlasmaStatusTo""/>" & _
"  " & _
"  <Property Name=""PVD.Shields_Quart_KWH"" Code=""SetPVDChamber_ShieldQuartTo""/>  " & _
"  <!--Magnatron-->" & _
"  <Property Name=""PVD.Magnatron_RotatingStatus"" Code=""SetPVDChamber_SetMagnatron_RotatingTo""/>" & _
"  <Property Name=""PVD.Magnatron_RotationStartStatus"" Code=""SetPVDChamber_ChangeButtonMagnatron_RotationStartTo,SetPVDChamber_MagnatronRB_InStatusProcess_To""/>" & _
"  <!--Turbo Pump-->" & _
"  <Property Name=""PVD.TurboPump_T_Readback"" Code=""SetPVDChamber_SetTurboPumpTo""/>" & _
"  <Property Name=""PVD.WaterPump_Status"" Code=""SetPVDChamber_SetWaterPumpStatusTo""/>" & _
"  <Property Name=""PVD.WaterPump_RegenHour_Readback"" Code=""SetPVDChamber_SetWaterPumpRegenHourToPopUpPanel""/>" & _
"  <Property Name=""PVD.WaterPump_LifeTimeHour_Readback"" Code=""SetPVDChamber_SetWaterPumpLifeTimeHourToPopUpPanel""/>" & _
"  <Property Name=""PVD.TurboPump_Status"" Code=""SetPVDChamber_SetTurboPumpStatusTo""/>" & _
"  <Property Name=""PVD.WaterPumpRegen_Status"" Code=""SetPVDChamber_SetWaterPumpRegenStatusTo""/>" & _
"  <Property Name=""PVD.WaterPumpState_Status"" Code=""SetPVDChamber_SetWaterPumpStateStatusTo,SetPVDChamber_SetWaterPumpOnOffStatusTo""/>" & _
"  <Property Name=""PVD.MachineIGDegas_Status"" Code=""SetPVDChamber_SetIGDegasStatusTo""/>" & _
"  <Property Name=""PVD.MachinePumpPurge_Status"" Code=""SetPVDChamber_SetPumpPurgeStatusTo""/>" & _
"  <Property Name=""PVD.Cryo_P_Command"" Code=""SetPVDChamber_SetP_ParameterTo""/>" & _
"  <!--Machine Menu-->" & _
"  <Property Name=""PVD.MachinePumpDown"" Code=""SetPVDChamber_SetMnuPumpDownTo""/>" & _
"  <Property Name=""PVD.MachineCryoOn"" Code=""SetPVDChamber_SetMnuCryoOnTo,SetPVDChamber_SetCryoRegenButtonTo""/>" & _
"  <Property Name=""PVD.MachineVent"" Code=""SetPVDChamber_SetMnuVentTo""/>" & _
"  <Property Name=""PVD.MachineFastRegen_Status"" Code=""SetPVDChamber_SetMnuFastRegenTo""/>" & _
"  <Property Name=""PVD.MachineShutDownPower"" Code=""SetPVDChamber_SetMnuShutDownPowerTo""/>" & _
"  <Property Name=""PVD.ControlStatus"" Code=""ChangeMachineOnlineInPVDChamberTo,SetOnlinePVDInProcessScreenTo,SetOnlinePVDDetailsInProcessScreenTo"" />" & _
"  <Property Name=""PVD.AutoSequenceRunningStatusText"" Code=""SetNameOfAutoSequenceRunning""/>" & _
"  <!-- Turbo -->" & _
"  <Property Name=""TMTurbo.ActualStatus"" Code=""SetTMTurboStatus,SetTMTurboStatusProcessPanel,SetTMTurboStatusInCassetteScreenTo""/>" & _
"  <Property Name=""LLATurbo.ActualStatus"" Code=""SetLLATurboStatus,SetLLATurboStatusProcessPanel,SetLLATurboStatusInCassetteScreenTo""/>" & _
"  <Property Name=""CassettesModule.TurboForeLineValveStatus"" Code=""SetTMTurboValveStatus,SetTMTurboValveStatusInControl""/>" & _
"  <Property Name=""LoadLockA.TurboForeLineValveStatus"" Code=""SetLLATurboValveStatus,SetLLATurboValveStatusInControl""/>" & _
"  <Property Name=""CassettesModule.TurboForelineCG"" Code=""SetTMTurboIGStatus,SetTMTurboIGStatusInControl,UpdateTMForelineCGPressOnCGForm""/>" & _
"  <Property Name=""LoadLockA.TurboForelineCG"" Code=""SetLLATurboIGStatus,UpdateLLAForelineCGPressOnCGForm,SetLLATurboIGStatusInControl""/>" & _
"   <Property Name=""CassettesModule.TurboForelineCGError"" Code=""SetTMTurboIGStatus""/>" & _
"  <Property Name=""LoadLockA.TurboForelineCGError"" Code=""SetLLATurboIGStatus""/>" & _
"  <Property Name=""PVD.MachinePumpPurge_Current_Cycle"" Code=""SetPVDChamber_SetPumpPurgeCurentCycleTo""/>" & _
"  <Property Name=""CassettesModule.ManualTransferStatus"" Code=""ChangeManualTransferStatus"" /><!--  System # 1 -->" & _
"<Property Name=""PVD4.ControlStatus"" Code=""ChangeMachineOnlineInCORONAChamberTo,SetOnlineCORONAInProcessScreenTo"" />" & _
"<Property Name=""PVD4.ConnectionStatus"" Code=""SetCORONA_ConnectionStatusInProcessModuleTo""/>" & _
"<Property Name=""PVD4.Override_Mode"" Code=""SetOverride_Mode""/>" & _
"<Property Name=""PVD4.Alarm_Status_Readback"" Code=""SetAlarm_Status_Readback""/>" & _
"<Property Name=""PVD4.Event_Status_Readback"" Code=""SetEvent_Status_Readback""/>" & _
"<Property Name=""PVD4.Maintenaince_Mode"" Code=""SetMaintenaince_Mode""/>" & _
"<Property Name=""PVD4.Target1_Kwh_Usage"" Code=""SetTarget1_Kwh_Usage,SetCORONAT1RBInProcessPopUpTo""/>" & _
"<Property Name=""PVD4.Target2_Kwh_Usage"" Code=""SetTarget2_Kwh_Usage,SetCORONAT2RBInProcessPopUpTo""/>" & _
"<Property Name=""PVD4.Target3_Kwh_Usage"" Code=""SetTarget3_Kwh_Usage,SetCORONAT3RBInProcessPopUpTo""/>" & _
"<Property Name=""PVD4.Target4_Kwh_Usage"" Code=""SetTarget4_Kwh_Usage,SetCORONAT4RBInProcessPopUpTo""/>" & _
"<Property Name=""PVD4.Target1_Shield_Quart"" Code=""SetTarget1_Shield_Quart""/>" & _
"<Property Name=""PVD4.Target2_Shield_Quart"" Code=""SetTarget2_Shield_Quart""/>" & _
"<Property Name=""PVD4.Target3_Shield_Quart"" Code=""SetTarget3_Shield_Quart""/>" & _
"<Property Name=""PVD4.Target4_Shield_Quart"" Code=""SetTarget4_Shield_Quart""/>" & _
"<!--  Recipe_Processing #2 -->" & _
"<Property Name=""PVD4.Process_Wafer_ID"" Code=""SetProcess_Wafer_ID""/>" & _
"<Property Name=""PVD4.Process_Recipe_Name"" Code=""SetProcess_Recipe_Name,SetProcess_Control_SetRecipeNameTo,SetRecipeOfChamberDetailsInProcessScreenTo,SetRecipeOfChamberInProcessScreenTo""/>" & _
"<Property Name=""PVD4.Process_Remaining_Time"" Code=""SetProcess_Remaining_Time""/>" & _
"<Property Name=""PVD4.Process_Elapsed_Time"" Code=""SetProcess_Elapsed_Time,SetStepTimeOfChamberInProcessScreenTo""/>" & _
"<Property Name=""PVD4.Process_Current_Step"" Code=""SetProcess_Current_Step,SetStepNumberOfChamberInProcessScreenTo,SetStepNumberOfChamberDetailsInProcessScreenTo""/>" & _
"<Property Name=""PVD4.Wafer_Processing_Status_Readback"" Code=""SetWafer_Processing_Status_Readback,SetStatusOfChamberDetailsInProcessScreenTo""/>" & _
"<Property Name=""PVD4.Process_Pressure"" Code=""SetProcessPressureOfChamberInProcessScreenTo""/>" & _
"" & _
"<Property Name=""PVD4.ProcessMonitor_Status_Readback"" Code=""SetProcessStatusInProcessPanel,SetProcessStatusInProcessModule,SetStatusOfChamberInProcessScreenTo""/>" & _
"<Property Name=""PVD4.Process_Mode"" Code=""SetProcess_ModeTo,SetCORONARotatingModeSPInProcessPopUpTo""/>" & _
"<Property Name=""PVD4.Process_Revolution_Count"" Code=""SetProcess_Revolution_CountTo""/>" & _
"" & _
"<Property Name=""PVD4.Process_Total_Steps"" Code=""SetProcess_Total_Steps""/>" & _
"<Property Name=""PVD4.Process_Total_Time"" Code=""SetProcess_Total_Time""/>" & _
"<Property Name=""PVD4.Process_Control_Device_Start"" Code=""SetProcess_Control_Device_Start""/>" & _
"<Property Name=""PVD4.Process_Control_Device_Stop"" Code=""SetProcess_Control_Device_Stop""/>" & _
"<Property Name=""PVD4.Process_Control_Device_Pause"" Code=""SetProcess_Control_Device_Pause""/>" & _
"<Property Name=""PVD4.Process_Control_Device_Continue"" Code=""SetProcess_Control_Device_Continue""/>" & _
"<Property Name=""PVD4.Process_Control_Device_End_Step"" Code=""SetProcess_Control_Device_End_Step""/>" & _
"<Property Name=""PVD4.Process_Control_Device_Error"" Code=""SetProcess_Control_Device_Error""/>" & _
"<Property Name=""PVD4.Process_Control_Device_Reset_Error"" Code=""SetProcess_Control_Device_Reset_Error""/>" & _
"<Property Name=""PVD4.Process_Control_Get_Run_Data_File_Name"" Code=""SetProcess_Control_Get_Run_Data_File_Name""/>" & _
"<Property Name=""PVD4.Copyrecipe_To_Pmfolder"" Code=""SetCopyrecipe_To_Pmfolder""/>" & _
"" & _
"<!--  Sequences # 3 -->" & _
"<Property Name=""PVD4.Auto_Pumpdown_Seq_Status"" Code=""SetAuto_Pumpdown_Seq""/>" & _
"<Property Name=""PVD4.Auto_Vent_Seq_Status"" Code=""SetAuto_Vent_Seq""/>" & _
"<Property Name=""PVD4.Pump_Purge_Seq_Status"" Code=""SetPump_Purge_Seq""/>" & _
"<Property Name=""PVD4.IG_Degas_Seq_Status"" Code=""SetIG_Degas_Seq""/>" & _
"<Property Name=""PVD4.Shutdown_Power_Seq_Status"" Code=""SetShutdown_Power_Seq""/>" & _
"" & _
"<Property Name=""PVD4.RateOfRise_Status"" Code=""SetRate_Of_Rise_Seq""/>" & _
"<Property Name=""PVD4.RateOfRise_Interval"" Code=""SetRate_Of_Rise_Interval_Recording""/>" & _
"<Property Name=""PVD4.RateOfRise_Sample"" Code=""SetRate_Of_Rise_Sample""/>" & _
"<Property Name=""PVD4.RateOfRise_FileName"" Code=""SetRate_Of_Rise_Filename""/>" & _
"" & _
"<Property Name=""PVD4.PumpDown_Curve_Status"" Code=""SetPumpdown_Curve_Seq""/>" & _
"<Property Name=""PVD4.PumpDown_Curve_Interval"" Code=""SetPumpdown_Curve_Interval_Recording""/>" & _
"<Property Name=""PVD4.PumpDown_Curve_Sample"" Code=""SetPumpdown_Curve_Sample""/>" & _
"<Property Name=""PVD4.PumpDown_Curve_FileName"" Code=""SetPumpdown_Curve_Filename""/>" & _
"" & _
"<Property Name=""PVD4.Initialized_Motion"" Code=""SetInitialized_Motion,SetInitialized_Motion_OfChamber_In_ProcessScreen,SetInitialized_Motion_OfChamber_In_MaintenanceScreen""/>" & _
"<Property Name=""PVD4.Auto_Power_Seq"" Code=""SetAuto_Power_Seq""/>" & _
"<Property Name=""PVD4.AutoSequenceRunningStatusText"" Code=""SetNameOfAutoSequenceRunning""/>" & _
"" & _
"<!--  Gasses # 4 -->" & _
"<Property Name=""PVD4.Gas1_Shutoff_Valve"" Code=""SetGas1_Shutoff_Valve""/>" & _
"<Property Name=""PVD4.Gas2_Shutoff_Valve"" Code=""SetGas2_Shutoff_Valve""/>" & _
"<Property Name=""PVD4.Gas3_Shutoff_Valve"" Code=""SetGas3_Shutoff_Valve""/>" & _
"<Property Name=""PVD4.Gas4_Shutoff_Valve"" Code=""SetGas4_Shutoff_Valve""/>" & _
"<Property Name=""PVD4.Gas5_Shutoff_Valve"" Code=""SetGas5_Shutoff_Valve""/>" & _
"" & _
"<Property Name=""PVD4.Gas1_Flowrate_Readback"" Code=""SetGas1_Flowrate_Readback,SetPVD4Gas1RBInProcessPopUpTo""/>" & _
"<Property Name=""PVD4.Gas2_Flowrate_Readback"" Code=""SetGas2_Flowrate_Readback,SetPVD4Gas2RBInProcessPopUpTo""/>" & _
"<Property Name=""PVD4.Gas3_Flowrate_Readback"" Code=""SetGas3_Flowrate_Readback,SetPVD4Gas3RBInProcessPopUpTo""/>" & _
"<Property Name=""PVD4.Gas4_Flowrate_Readback"" Code=""SetGas4_Flowrate_Readback,SetPVD4Gas4RBInProcessPopUpTo""/>" & _
"<Property Name=""PVD4.Gas5_Flowrate_Readback"" Code=""SetGas5_Flowrate_Readback,SetPVD4Gas5RBInProcessPopUpTo""/>" & _
"" & _
"<Property Name=""PVD4.Gas1_Flowrate_Program"" Code=""SetGas1_Flowrate_Program,SetPVD4Gas1SPInProcessPopUpTo""/>" & _
"<Property Name=""PVD4.Gas2_Flowrate_Program"" Code=""SetGas2_Flowrate_Program,SetPVD4Gas2SPInProcessPopUpTo""/>" & _
"<Property Name=""PVD4.Gas3_Flowrate_Program"" Code=""SetGas3_Flowrate_Program,SetPVD4Gas3SPInProcessPopUpTo""/>" & _
"<Property Name=""PVD4.Gas4_Flowrate_Program"" Code=""SetGas4_Flowrate_Program,SetPVD4Gas4SPInProcessPopUpTo""/>" & _
"<Property Name=""PVD4.Gas5_Flowrate_Program"" Code=""SetGas5_Flowrate_Program,SetPVD4Gas5SPInProcessPopUpTo""/>" & _
"" & _
"<Property Name=""PVD4.Gas1MFCDevinetStatus"" Code=""SetPVD4Gas1StatusTo"" />" & _
"<Property Name=""PVD4.Gas2MFCDevinetStatus"" Code=""SetPVD4Gas2StatusTo"" />" & _
"<Property Name=""PVD4.Gas3MFCDevinetStatus"" Code=""SetPVD4Gas3StatusTo"" />" & _
"<Property Name=""PVD4.Gas4MFCDevinetStatus"" Code=""SetPVD4Gas4StatusTo"" />" & _
"<Property Name=""PVD4.Gas5MFCDevinetStatus"" Code=""SetPVD4Gas5StatusTo"" />" & _
"" & _
"<Property Name=""PVD4.Main_Dist_Valve"" Code=""SetMain_Dist_Valve""/>" & _
"<Property Name=""PVD4.Sec_Dist_Valve"" Code=""SetSec_Dist_Valve""/>" & _
"<Property Name=""PVD4.IG_Isolation_ValveStatus"" Code=""SetIG_Isolation_Valve""/>" & _
"" & _
"<!--  Valves  # 5 -->" & _
"<Property Name=""PVD4.RoughValveStatus"" Code=""SetRough_Valve_Status""/>" & _
"<Property Name=""PVD4.VentValveStatus"" Code=""SetVent_Valve_Status""/>" & _
"<Property Name=""PVD4.Isolation_Valve_Status"" Code=""SetIsolation_Valve_Status""/>" & _
"<Property Name=""PVD4.Hivac_Valve_Status"" Code=""SetHivac_Valve_Status""/>" & _
"<Property Name=""PVD4.ForelineValveStatus"" Code=""SetForeline_Valve_Status""/>" & _
"<Property Name=""PVD4.Baratron_Valve_Status"" Code=""SetBaratron_Valve_Status""/>" & _
"" & _
"<!--  Pressure # 6 -->" & _
"<Property Name=""PVD4.IG"" Code=""SetIG_Pressure""/>" & _
"<Property Name=""PVD4.IGStatus"" Code=""SetIG_Status""/>" & _
"<Property Name=""PVD4.CG"" Code=""SetCG_Pressure,UpdatePVD4CGPressureInCGPopUp""/>" & _
"<Property Name=""PVD4.CG_Relay_Status"" Code=""SetChamberinterlock_Chamber_Pressure_Status""/>" & _
"<Property Name=""PVD4.SwitchIGFilament"" Code=""SetSwicthIGFilamentTo"" />" & _
"<Property Name=""PVD4.EnableIGFilament"" Code=""SetEnableIGFilamentTo"" />" & _
"" & _
"<Property Name=""PVD4.Foreline_CG_Pressure"" Code=""SetForeline_CG_Pressure,UpdatePVD4ForelineCGPressureInCGPopUp""/>" & _
"<Property Name=""PVD4.Foreline_CG_Relay_Status"" Code=""SetForeline_CG_Relay_Status,SetChamberinterlock_Turbo_Foreline_Status""/>" & _
"" & _
"<Property Name=""PVD4.Baratron_Pressure"" Code=""SetBaratron_Pressure,SetBaratronPressureOfPopUpScreenTo,SetProcessPressureOfChamberInProcessScreenTo""/>" & _
"" & _
"<Property Name=""PVD4.Mechanical_Pump_CG_Pressure"" Code=""SetMechanical_Pump_CG_Pressure,UpdatePVD4RoughlineCGPressureInCGPopUp""/>" & _
"<Property Name=""PVD4.Mechanical_Pump_CG_Relay_Status"" Code=""SetMechanical_Pump_CG_Relay_Status""/>" & _
"<Property Name=""PVD4.Mechanical_Pump_Status"" Code=""SetMechanical_Pump_Status""/>" & _
"<Property Name=""PVD4.MPump_Serial_Communication_Status"" Code=""SetMechanical_Pump_Com_Status""/>" & _
"<Property Name=""PVD4.WaitingMPON"" Code=""SetMechanical_Pump_Waiting_ON""/>" & _
"" & _
"<!--  Interlocks # 7 -->" & _
"<Property Name=""PVD4.Chamberinterlock_Substrate_Table_Water_Status"" Code=""SetChamberinterlock_Substrate_Table_Water_Status""/>" & _
"<Property Name=""PVD4.Chamberinterlock_Air_Pressure_Status"" Code=""SetChamberinterlock_Air_Pressure_Status""/>" & _
"" & _
"<Property Name=""PVD4.Chamberinterlock_Door_Closed_Status"" Code=""SetChamberinterlock_Door_Closed_Status""/>" & _
"<Property Name=""PVD4.Chamberinterlock_Lid_Closed_Status"" Code=""SetChamberinterlock_Lid_Closed_Status""/>" & _
"" & _
"<Property Name=""PVD4.Chamberinterlock_Target1_3_Water_Status"" Code=""SetChamberinterlock_Target1_Water_Status""/>" & _
"<Property Name=""PVD4.Chamberinterlock_Target2_4_Water_Status"" Code=""SetChamberinterlock_Target2_Water_Status""/>" & _
"" & _
"<Property Name=""PVD4.Chamberinterlock_Target_MB_Water_Status"" Code=""SetChamberinterlock_Target_MB_Water_Status""/>" & _
"<Property Name=""PVD4.Chamberinterlock_Bias_MB_Water_Status"" Code=""SetChamberinterlock_Bias_MB_Water_Status""/>" & _
"<Property Name=""PVD4.Chamberinterlock_Turbo_Water_Status"" Code=""SetChamberinterlock_Turbo_Water_Status""/>" & _
"<Property Name=""PVD4.Chamberinterlock_PS_Interlock_Status"" Code=""SetChamberinterlock_Ps_Interlock_Status""/>" & _
"<Property Name=""PVD4.Chamberinterlock_Devicenet_Comm"" Code=""SetChamberinterlock_Devicenet_Comm""/>" & _
"<Property Name=""PVD4.Chamberinterlock_Target_Panels"" Code=""SetChamberinterlock_Target_Panels""/>" & _
"" & _
"<!--  Motion # 8 -->" & _
"<Property Name=""PVD4.Motion_Communication_Status"" Code=""Set_Motion_Communication_InTableControl""/>" & _
"<Property Name=""PVD4.Substrate_Goto_Slot"" Code=""SetSubstrate_Goto_Slot""/>" & _
"<Property Name=""PVD4.Substrate_Table_Rotate_Home"" Code=""SetSubstrate_Goto_Home""/>" & _
"<Property Name=""PVD4.Substrate_Table_Lift_Home"" Code=""SetSubstrate_Table_Lift_Home""/>" & _
"<Property Name=""PVD4.Substrate_Current_Station"" Code=""SetSubstrate_Current_Station,SetSubstrate_Current_Station_InTableControl,SetCurrentWaferPosChamberInProcessScreenTo,SetCurrentWaferPosChamberInCassettesPanelTo,SetCORONAChamber_ProcessMonitor_WaferID""/>" & _
"" & _
"<Property Name=""PVD4.Substrate_Table_Up_Down_Status"" Code=""SetSubstrate_Table_Up_Down_Status""/>" & _
"<Property Name=""PVD4.Substrate_Lift_Up_Down_Status"" Code=""SetSubstrate_Lift_Up_Down_Status""/>" & _
"<Property Name=""PVD4.Substrate_Table_Rotate_Status"" Code=""SetSubstrate_Table_Rotate_Status""/>" & _
"<Property Name=""PVD4.Substrate_Table_Rotate_Speed"" Code=""SetSubstrate_Table_Rotate_Speed,SetSubstrate_Table_Rotate_Status,SetSubstrate_Table_Rotate_SpeedInProcessPopUpTo""/>" & _
"<Property Name=""PVD4.Substrate_Table_Rotate_Speed_Readback"" Code=""SetSubstrate_Table_Rotate_Speed_Readback,SetSubstrate_Table_Rotate_Speed_ReadbackInProcessPopUpTo""/>" & _
"<Property Name=""PVD4.Substrate_Table_Rotate_Pos_In_Unit_Readback"" Code=""SetSubstrate_Table_Rotate_Pos_In_Unit_Readback""/>" & _
"<Property Name=""PVD4.Number_Of_Unit_Per_Revolution_Readback"" Code=""SetNumber_Of_Unit_Per_Revolution_Readback""/>" & _
"<Property Name=""PVD4.Substrate_Table_Current_Position_Readback"" Code=""SetSubstrate_Table_Current_Position_Readback,SetCORONATableCurrentPosotionRBInProcessPopUpTo""/>" & _
"<Property Name=""PVD4.Substrate_Table_Current_Position_Program"" Code=""SetSubstrate_Table_Current_Position_Program,SetCORONATableCurrentPosotionSPInProcessPopUpTo""/>" & _
"<Property Name=""PVD4.Target1_Shutter_Status"" Code=""SetTarget1_Shutter_Status""/>" & _
"<Property Name=""PVD4.Target2_Shutter_Status"" Code=""SetTarget2_Shutter_Status""/>" & _
"<Property Name=""PVD4.Target3_Shutter_Status"" Code=""SetTarget3_Shutter_Status""/>" & _
"<Property Name=""PVD4.Target4_Shutter_Status"" Code=""SetTarget4_Shutter_Status""/>" & _
"<Property Name=""PVD4.Substrate_Table_Up_Down_Moving"" Code=""SetSubstrate_Table_Up_Down_Moving""/>" & _
"" & _
"<!--  Turbo_Waterpump # 9 -->" & _
"<Property Name=""PVD4.Water_Pump_T_Readback"" Code=""SetWater_Pump_T_Readback""/>" & _
"<Property Name=""PVD4.Water_Pump_Status"" Code=""SetWater_Pump_Status""/>" & _
"<Property Name=""PVD4.Water_Pump_Regen_Status"" Code=""SetWater_Pump_Regen_Status""/>" & _
"<Property Name=""PVD4.Water_Pump_State_Status"" Code=""SetWater_Pump_State_Status""/>" & _
"<Property Name=""PVD4.Water_Pump_Regen_Hour_Readback"" Code=""SetWater_Pump_Regen_Hour_Readback""/>" & _
"<Property Name=""PVD4.Water_Pump_Regen_Lifetime_Readback"" Code=""SetWater_Pump_Regen_Lifetime_Readback""/>" & _
"<Property Name=""PVD4.Water_Pump_P_Commands"" Code=""SetWater_Pump_P_Commands""/>" & _
"<Property Name=""PVD4.Water_Pump_P_Command_Readback"" Code=""SetWater_Pump_P_Command_Readback""/>" & _
"<Property Name=""PVD4.Water_Pump_Is_Communicating"" Code=""SetWater_Pump_Is_Communicating""/>" & _
"<Property Name=""PVD4.Turbo_Pump_On_Off"" Code=""SetTurbo_Pump_On_Off""/>" & _
"<Property Name=""PVD4.Turbo_Pump_On_Off_Rb"" Code=""SetTurbo_Pump_On_Off_Rb""/>" & _
"<Property Name=""PVD4.Turbo_Pump_Ramping_Percent_Rb"" Code=""SetTurbo_Ramping_Percent_RBTo"" />" & _
"<Property Name=""PVD4.Turbo_Pump_Uptospeed_Rb"" Code=""SetTurbo_Pump_Uptospeed_Rb""/>" & _
"" & _
"<!-- Vat_Valve #10 -->" & _
"<Property Name=""PVD4.Vat_Valve_Communication_Status"" Code=""SetVat_Valve_Communication_Status""/>" & _
"<Property Name=""PVD4.Vat_Valve_Percentage_Program"" Code=""SetVat_Valve_Percentage_Program""/>" & _
"<Property Name=""PVD4.Vat_Valve_Percentage_Readback"" Code=""SetHivac_Valve_Status""/>" & _
"<Property Name=""PVD4.Vat_Valve_Controller_Pressure_Program"" Code=""SetVat_Valve_Controller_Pressure_Program""/>" & _
"<Property Name=""PVD4.Vat_Valve_Controller_Auto_Zero"" Code=""SetVat_Valve_Controller_Auto_Zero""/>" & _
"<Property Name=""PVD4.Vat_Valve_Controller_Teach"" Code=""SetVat_Valve_Controller_Teach""/>" & _
"<Property Name=""PVD4.Vat_Valve_Controller_Sizeadjust"" Code=""SetVat_Valve_Controller_Sizeadjust""/>" & _
"" & _
"<!--  Magnatron # 11 -->" & _
"<Property Name=""PVD4.Target1_Magnatron_Rotate_Status"" Code=""SetTarget1_Magnatron_Rotate_Status""/>" & _
"<Property Name=""PVD4.Target2_Magnatron_Rotate_Status"" Code=""SetTarget2_Magnatron_Rotate_Status""/>" & _
"<Property Name=""PVD4.Target3_Magnatron_Rotate_Status"" Code=""SetTarget3_Magnatron_Rotate_Status""/>" & _
"<Property Name=""PVD4.Target4_Magnatron_Rotate_Status"" Code=""SetTarget4_Magnatron_Rotate_Status""/>" & _
"" & _
"<!--  RF_Target_Ps # 12 -->" & _
"<Property Name=""PVD4.RF_Target_Communication_Status"" Code=""SetRF_Target_Communication_Status""/>" & _
"<Property Name=""PVD4.RF_Target_Power_Readback"" Code=""SetRF_Target_Power_Readback,SetRF_Target_Power_Readback_Seren,SetCORONAPSForwardPowerRBInProcessPopUpTo""/>" & _
"<Property Name=""PVD4.RF_Target_Reflected_Power_Readback"" Code=""SetRF_Target_Reflected_Power_Readback,SetRF_Target_Reflected_Power_Readback_Seren,SetCORONAPSReflectPowerRBInProcessPopUpTo""/>" & _
"<Property Name=""PVD4.RF_Target_MB_Voltage_Readback"" Code=""SetRF_Target_MB_Voltage_Readback,SetRF_Target_MB_Voltage_Readback_Seren""/>" & _
"<Property Name=""PVD4.RF_Target_MB_C1_Readback"" Code=""SetRF_Target_MB_C1_Readback,SetRF_Target_MB_C1_Readback_Seren""/>" & _
"<Property Name=""PVD4.RF_Target_MB_C2_Readback"" Code=""SetRF_Target_MB_C2_Readback,SetRF_Target_MB_C2_Readback_Seren""/>" & _
"<Property Name=""PVD4.RF_Target_Power_Program"" Code=""SetRF_Target_Power_Program,SetRF_Target_Power_Program_Seren,SetCORONAPSForwardPowerSPInProcessPopUpTo""/>" & _
"<Property Name=""PVD4.RF_Target_Reflected_Power_Program"" Code=""SetRF_Target_Reflected_Power_Program,SetRF_Target_Reflected_Power_Program_Seren""/>" & _
"<Property Name=""PVD4.RF_Target_MB_Voltage_Program"" Code=""SetRF_Target_MB_Voltage_Program,SetRF_Target_MB_Voltage_Program_Seren""/>" & _
"<Property Name=""PVD4.RF_Target_MB_C1_Program"" Code=""SetRF_Target_MB_C1_Program,SetRF_Target_MB_C1_Program_Seren""/>" & _
"<Property Name=""PVD4.RF_Target_MB_C2_Program"" Code=""SetRF_Target_MB_C2_Program,SetRF_Target_MB_C2_Program_Seren""/>" & _
"<Property Name=""PVD4.RF_Target_MB_Match_Mode_Readback"" Code=""SetRF_Target_MB_Match_Mode_Readback,SetRF_Target_MB_Match_Mode_Readback_Seren,SetRF_Target_MB_Match_Mode_Program,SetRF_Target_MB_Match_Mode_Program_Seren""/>" & _
"<Property Name=""PVD4.RF_Target_MB_Match_Mode_Program"" Code=""SetRF_Target_MB_Match_Mode_Program,SetRF_Target_MB_Match_Mode_Program_Seren""/>" & _
"<Property Name=""PVD4.RF_Target_MB_Preset_Program"" Code=""SetRF_Target_MB_Preset_Program,SetRF_Target_MB_Preset_Program_Seren""/>" & _
"<Property Name=""PVD4.RF_Target_MB_Preset_Readback"" Code=""SetRF_Target_MB_Preset_Readback,SetRF_Target_MB_Preset_Readback_Seren""/>" & _
"<Property Name=""PVD4.RF_Target_Error_Readback"" Code=""SetRF_Target_Error_Readback""/>" & _
"<Property Name=""PVD4.RF_Target_MB_Mag_Error_Readback"" Code=""SetRF_Target_MB_Mag_Error_Readback""/>" & _
"<Property Name=""PVD4.RF_Target_MB_Phase_Error_Readback"" Code=""SetRF_Target_MB_Phase_Error_Readback""/>" & _
"<Property Name=""PVD4.RF_Target_Voltage_SP"" Code=""SetRF_Target_Voltage_SP""/>" & _
"" & _
"" & _
"<!--  Bias_Ps # 13 -->" & _
"<Property Name=""PVD4.Bias_Communication_Status"" Code=""SetBias_Communication_Status""/>" & _
"<Property Name=""PVD4.Bias_Power_Readback"" Code=""SetBias_Power_Readback,SetBias_Power_Readback_Seren,SetCORONABiasForwardPowerRBInProcessPopUpTo""/>" & _
"<Property Name=""PVD4.Bias_Reflected_Power_Readback"" Code=""SetBias_Reflected_Power_Readback,SetBias_Reflected_Power_Readback_Seren,SetCORONABiasReflectPowerRBInProcessPopUpTo""/>" & _
"<Property Name=""PVD4.Bias_MB_Voltage_Readback"" Code=""SetBias_MB_Voltage_Readback,SetBias_MB_Voltage_Readback_Seren""/>" & _
"<Property Name=""PVD4.Bias_MB_C1_Readback"" Code=""SetBias_MB_C1_Readback,SetBias_MB_C1_Readback_Seren""/>" & _
"<Property Name=""PVD4.Bias_MB_C2_Readback"" Code=""SetBias_MB_C2_Readback,SetBias_MB_C2_Readback_Seren""/>" & _
"<Property Name=""PVD4.Bias_Power_Program"" Code=""SetBias_Power_Program,SetBias_Power_Program_Seren,SetCORONABiasForwardPowerSPInProcessPopUpTo""/>" & _
"<Property Name=""PVD4.Bias_Reflected_Power_Program"" Code=""SetBias_Reflected_Power_Program,SetBias_Reflected_Power_Program_Seren""/>" & _
"<Property Name=""PVD4.Bias_MB_Voltage_Program"" Code=""SetBias_MB_Voltage_Program,SetBias_MB_Voltage_Program_Seren""/>" & _
"<Property Name=""PVD4.Bias_MB_C1_Program"" Code=""SetBias_MB_C1_Program,SetBias_MB_C1_Program_Seren""/>" & _
"<Property Name=""PVD4.Bias_MB_C2_Program"" Code=""SetBias_MB_C2_Program,SetBias_MB_C2_Program_Seren""/>" & _
"<Property Name=""PVD4.Bias_MB_Match_Mode_Readback"" Code=""SetBias_MB_Match_Mode_Readback,SetBias_MB_Match_Mode_Readback_Seren,SetBias_MB_Match_Mode_Program,SetBias_MB_Match_Mode_Program_Seren""/>" & _
"<Property Name=""PVD4.Bias_MB_Match_Mode_Program"" Code=""SetBias_MB_Match_Mode_Program,SetBias_MB_Match_Mode_Program_Seren""/>" & _
"<Property Name=""PVD4.Bias_MB_Preset_Program"" Code=""SetBias_MB_Preset_Program,SetBias_MB_Preset_Program_Seren""/>" & _
"<Property Name=""PVD4.Bias_MB_Preset_Readback"" Code=""SetBias_MB_Preset_Readback,SetBias_MB_Preset_Readback_Seren""/>" & _
"" & _
"<Property Name=""PVD4.Bias_Error_Readback"" Code=""SetBias_Error_Readback""/>" & _
"<Property Name=""PVD4.Bias_MB_Mag_Error_Readback"" Code=""SetBias_MB_Mag_Error_Readback""/>" & _
"<Property Name=""PVD4.Bias_MB_Phase_Error_Readback"" Code=""SetBias_MB_Phase_Error_Readback""/>" & _
"<Property Name=""PVD4.Bias_Power_Contact_On_Off"" Code=""SetBias_Power_Contact_On_Off""/>" & _
"<Property Name=""PVD4.Bias_Plasma_Status"" Code=""SetBias_Plasma_Status""/>" & _
"<!--  DC_Target_Ps # 14 -->" & _
"<Property Name=""PVD4.DC_Target_Communication_Status"" Code=""SetDC_Target_Communication_Status""/>" & _
"<Property Name=""PVD4.DC_Target_Power_Readback"" Code=""SetDC_Target_Power_Readback,SetCORONAPSForwardPowerRBInProcessPopUpTo""/>" & _
"<Property Name=""PVD4.DC_Target_Power_Program"" Code=""SetDC_Target_Power_Program,SetCORONAPSForwardPowerSPInProcessPopUpTo""/>" & _
"<Property Name=""PVD4.DC_Target_Voltage_Readback"" Code=""SetDC_Target_Voltage_Readback""/>" & _
"<Property Name=""PVD4.DC_Target_Current_Readback"" Code=""SetDC_Target_Current_Readback,SetCORONAPSReflectPowerRBInProcessPopUpTo""/>" & _
"<Property Name=""PVD4.DC_Target_Pluse_Mode_Status"" Code=""SetDC_Target_Pluse_Mode_Status""/>" & _
"<Property Name=""PVD4.DC_Target_Pulse_Frequency_Program"" Code=""SetDC_Target_Pulse_Frequency_Program""/>" & _
"<Property Name=""PVD4.DC_Target_Pulse_Frequency_Readback"" Code=""SetDC_Target_Pulse_Frequency_Readback""/>" & _
"<Property Name=""PVD4.DC_Target_Pulse_Width_Program"" Code=""SetDC_Target_Pulse_Width_Program""/>" & _
"<Property Name=""PVD4.DC_Target_Pulse_Width_Readback"" Code=""SetDC_Target_Pulse_Width_Readback""/>" & _
"<Property Name=""PVD4.DC_Target_Ramp_Time_Program"" Code=""SetDC_Target_Ramp_Time_Program""/>" & _
"<Property Name=""PVD4.DC_Target_Ramp_Time_Readback"" Code=""SetDC_Target_Ramp_Time_Readback""/>" & _
"<Property Name=""PVD4.DC_Target_Arc_Counter_Readback"" Code=""SetDC_Target_Arc_Counter_Readback""/>" & _
"<Property Name=""PVD4.DC_Target_Voltage_SP"" Code=""SetDC_Target_Voltage_SP""/>" & _
"" & _
"<!--  Heater # 15 -->" & _
"<Property Name=""PVD4.HeaterZone1_Communication_Status"" Code=""SetHeaterZone1_Communication_Status""/>" & _
"<Property Name=""PVD4.HeaterZone2_Communication_Status"" Code=""SetHeaterZone2_Communication_Status""/>" & _
"<Property Name=""PVD4.Heater1_OnOff_RB"" Code=""Set_HeaterZone1_Status""/>" & _
"<Property Name=""PVD4.Heater2_OnOff_RB"" Code=""Set_HeaterZone2_Status""/>" & _
"<Property Name=""PVD4.Heater_Zone1_RB"" Code=""Set_HeaterZone1_RB""/>" & _
"<Property Name=""PVD4.Heater_Zone2_RB"" Code=""Set_HeaterZone2_RB""/>" & _
"" & _
"<!--  WaferInside -->" & _
"<Property Name=""PVD4.WaferInside"" Code=""SetWaferInsideChamberInProcessScreenTo,SetCORONAChamber_ProcessMonitor_WaferID""/>" & _
"" & _
"<Property Name=""PVD4.Target_Select_Readback"" Code=""SetTarget_Select_Readback""/>" & _
"<Property Name=""PVD4.Plasma_Status"" Code=""SetPlasma_Status""/>" & _
"<Property Name=""PVD4.MachinePumpPurge_Current_Cycle"" Code=""SetCORONAChamber_SetPumpPurgeCurentCycleTo""/>" & _
"<Property Name=""PVD4.Target1_Injection_ValveStatus"" Code=""SetCORONAChamber_SetInjectionValve1""/>" & _
"<Property Name=""PVD4.Target2_Injection_ValveStatus"" Code=""SetCORONAChamber_SetInjectionValve2""/>" & _
"<Property Name=""PVD4.Target3_Injection_ValveStatus"" Code=""SetCORONAChamber_SetInjectionValve3""/>" & _
"<Property Name=""PVD4.Target4_Injection_ValveStatus"" Code=""SetCORONAChamber_SetInjectionValve4""/>" & _
"" & _
"<!--Filmetric-->" & _
"<Property Name=""PVD4.Filmetric_ListRecipe_RB"" Code=""Update_ListRecipe_Readback""/>" & _
"<Property Name=""PVD4.Filmetric_Thickness"" Code=""Set_Filmetric_Thickness""/>" & _
"<Property Name=""PVD4.Filmetric_Recipe_SP"" Code=""Set_Recipe_Thickness""/>" & _
"<Property Name=""PVD4.Goodness_Of_Fit"" Code=""Set_Goodness_Of_Fit""/>" & _
"" & _
"<Property Name=""PVD4.PM_WaferCount"" Code=""SetPVD4Chamber_SetIncreaseWaferCount""/>" & _
"<!--  System # 1 -->" & _
"<Property Name=""PVD5T.ControlStatus"" Code=""PVD5T_ChangeMachineOnlineInChamberTo,PVD5T_SetOnlineInProcessScreenTo"" />" & _
"<Property Name=""PVD5T.ConnectionStatus"" Code=""PVD5T_SetConnectionStatusInProcessModuleTo""/>" & _
"<Property Name=""PVD5T.Override_Mode"" Code=""PVD5T_SetOverride_Mode""/>" & _
"<Property Name=""PVD5T.Alarm_Status_Readback"" Code=""PVD5T_SetAlarm_Status_Readback""/>" & _
"<Property Name=""PVD5T.Event_Status_Readback"" Code=""PVD5T_SetEvent_Status_Readback""/>" & _
"<Property Name=""PVD5T.Maintenaince_Mode"" Code=""PVD5T_SetMaintenaince_Mode""/>" & _
"<Property Name=""PVD5T.Target1_Kwh_Usage"" Code=""PVD5T_SetTarget1_Kwh_Usage,PVD5T_SetT1RBInProcessPopUpTo""/>" & _
"<Property Name=""PVD5T.Target2_Kwh_Usage"" Code=""PVD5T_SetTarget2_Kwh_Usage,PVD5T_SetT2RBInProcessPopUpTo""/>" & _
"<Property Name=""PVD5T.Target3_Kwh_Usage"" Code=""PVD5T_SetTarget3_Kwh_Usage,PVD5T_SetT3RBInProcessPopUpTo""/>" & _
"<Property Name=""PVD5T.Target4_Kwh_Usage"" Code=""PVD5T_SetTarget4_Kwh_Usage,PVD5T_SetT4RBInProcessPopUpTo""/>" & _
"<Property Name=""PVD5T.Target5_Kwh_Usage"" Code=""PVD5T_SetTarget5_Kwh_Usage,PVD5T_SetT5RBInProcessPopUpTo""/>" & _
"<Property Name=""PVD5T.Target1_Shield_Quart"" Code=""PVD5T_SetTarget1_Shield_Quart""/>" & _
"<Property Name=""PVD5T.Target2_Shield_Quart"" Code=""PVD5T_SetTarget2_Shield_Quart""/>" & _
"<Property Name=""PVD5T.Target3_Shield_Quart"" Code=""PVD5T_SetTarget3_Shield_Quart""/>" & _
"<Property Name=""PVD5T.Target4_Shield_Quart"" Code=""PVD5T_SetTarget4_Shield_Quart""/>" & _
"<Property Name=""PVD5T.Target5_Shield_Quart"" Code=""PVD5T_SetTarget5_Shield_Quart""/>" & _
"<!--  Recipe_Processing #2 -->" & _
"<Property Name=""PVD5T.Process_Wafer_ID"" Code=""PVD5T_SetProcess_Wafer_ID""/>" & _
"<Property Name=""PVD5T.Process_Recipe_Name"" Code=""PVD5T_SetProcess_Recipe_Name,PVD5T_SetProcess_Control_SetRecipeNameTo,SetRecipeOfChamberDetailsInProcessScreenTo,SetRecipeOfChamberInProcessScreenTo""/>" & _
"<Property Name=""PVD5T.Process_Remaining_Time"" Code=""PVD5T_SetProcess_Remaining_Time""/>" & _
"<Property Name=""PVD5T.Process_Elapsed_Time"" Code=""PVD5T_SetProcess_Elapsed_Time,SetStepTimeOfChamberInProcessScreenTo""/>" & _
"<Property Name=""PVD5T.Process_Current_Step"" Code=""PVD5T_SetProcess_Current_Step,SetStepNumberOfChamberInProcessScreenTo,SetStepNumberOfChamberDetailsInProcessScreenTo""/>" & _
"<Property Name=""PVD5T.Wafer_Processing_Status_Readback"" Code=""PVD5T_SetWafer_Processing_Status_Readback,PVD5T_SetStatusOfChamberDetailsInProcessScreenTo""/>" & _
"<Property Name=""PVD5T.Process_Pressure"" Code=""SetProcessPressureOfChamberInProcessScreenTo""/>" & _
"" & _
"<Property Name=""PVD5T.ProcessMonitor_Status_Readback"" Code=""PVD5T_SetProcessStatusInProcessPanel,PVD5T_SetProcessStatusInProcessModule,SetStatusOfChamberInProcessScreenTo""/>" & _
"<Property Name=""PVD5T.Process_Mode"" Code=""PVD5T_SetProcess_ModeTo,PVD5T_SetRotatingModeSPInProcessPopUpTo""/>" & _
"<Property Name=""PVD5T.Process_Revolution_Count"" Code=""PVD5T_SetProcess_Revolution_CountTo""/>" & _
"" & _
"<Property Name=""PVD5T.Process_Total_Steps"" Code=""PVD5T_SetProcess_Total_Steps""/>" & _
"<Property Name=""PVD5T.Process_Total_Time"" Code=""PVD5T_SetProcess_Total_Time""/>" & _
"<Property Name=""PVD5T.Process_Control_Device_Start"" Code=""PVD5T_SetProcess_Control_Device_Start""/>" & _
"<Property Name=""PVD5T.Process_Control_Device_Stop"" Code=""PVD5T_SetProcess_Control_Device_Stop""/>" & _
"<Property Name=""PVD5T.Process_Control_Device_Pause"" Code=""PVD5T_SetProcess_Control_Device_Pause""/>" & _
"<Property Name=""PVD5T.Process_Control_Device_Continue"" Code=""PVD5T_SetProcess_Control_Device_Continue""/>" & _
"<Property Name=""PVD5T.Process_Control_Device_End_Step"" Code=""PVD5T_SetProcess_Control_Device_End_Step""/>" & _
"<Property Name=""PVD5T.Process_Control_Device_Error"" Code=""PVD5T_SetProcess_Control_Device_Error""/>" & _
"<Property Name=""PVD5T.Process_Control_Device_Reset_Error"" Code=""PVD5T_SetProcess_Control_Device_Reset_Error""/>" & _
"<Property Name=""PVD5T.Process_Control_Get_Run_Data_File_Name"" Code=""PVD5T_SetProcess_Control_Get_Run_Data_File_Name""/>" & _
"<Property Name=""PVD5T.Copyrecipe_To_Pmfolder"" Code=""PVD5T_SetCopyrecipe_To_Pmfolder""/>" & _
"<Property Name=""PVD5T.Target_Mode"" Code=""PVD5T_Set_Target_Mode""/>" & _
"" & _
"<!--  Sequences # 3 -->" & _
"<Property Name=""PVD5T.Auto_Pumpdown_Seq_Status"" Code=""PVD5T_SetAuto_Pumpdown_Seq""/>" & _
"<Property Name=""PVD5T.Auto_Vent_Seq_Status"" Code=""PVD5T_SetAuto_Vent_Seq""/>" & _
"<Property Name=""PVD5T.Pump_Purge_Seq_Status"" Code=""PVD5T_SetPump_Purge_Seq""/>" & _
"<Property Name=""PVD5T.IG_Degas_Seq_Status"" Code=""PVD5T_SetIG_Degas_Seq""/>" & _
"<Property Name=""PVD5T.Shutdown_Power_Seq_Status"" Code=""PVD5T_SetShutdown_Power_Seq""/>" & _
"" & _
"<Property Name=""PVD5T.RateOfRise_Status"" Code=""PVD5T_SetRate_Of_Rise_Seq""/>" & _
"<Property Name=""PVD5T.RateOfRise_Interval"" Code=""PVD5T_SetRate_Of_Rise_Interval_Recording""/>" & _
"<Property Name=""PVD5T.RateOfRise_Sample"" Code=""PVD5T_SetRate_Of_Rise_Sample""/>" & _
"<Property Name=""PVD5T.RateOfRise_FileName"" Code=""PVD5T_SetRate_Of_Rise_Filename""/>" & _
"" & _
"<Property Name=""PVD5T.PumpDown_Curve_Status"" Code=""PVD5T_SetPumpdown_Curve_Seq""/>" & _
"<Property Name=""PVD5T.PumpDown_Curve_Interval"" Code=""PVD5T_SetPumpdown_Curve_Interval_Recording""/>" & _
"<Property Name=""PVD5T.PumpDown_Curve_Sample"" Code=""PVD5T_SetPumpdown_Curve_Sample""/>" & _
"<Property Name=""PVD5T.PumpDown_Curve_FileName"" Code=""PVD5T_SetPumpdown_Curve_Filename""/>" & _
"" & _
"<Property Name=""PVD5T.Initialized_Motion"" Code=""PVD5T_SetInitialized_Motion,PVD5T_SetInitialized_Motion_OfChamber_In_ProcessScreen,PVD5T_SetInitialized_Motion_OfChamber_In_MaintenanceScreen""/>" & _
"<Property Name=""PVD5T.Auto_Power_Seq"" Code=""PVD5T_SetAuto_Power_Seq""/>" & _
"<Property Name=""PVD5T.AutoSequenceRunningStatusText"" Code=""PVD5T_SetNameOfAutoSequenceRunning""/>" & _
"" & _
"<!--  Gasses # 4 -->" & _
"<Property Name=""PVD5T.Gas1_Shutoff_Valve"" Code=""PVD5T_SetGas1_Shutoff_Valve""/>" & _
"<Property Name=""PVD5T.Gas2_Shutoff_Valve"" Code=""PVD5T_SetGas2_Shutoff_Valve""/>" & _
"<Property Name=""PVD5T.Gas3_Shutoff_Valve"" Code=""PVD5T_SetGas3_Shutoff_Valve""/>" & _
"<Property Name=""PVD5T.Gas4_Shutoff_Valve"" Code=""PVD5T_SetGas4_Shutoff_Valve""/>" & _
"<Property Name=""PVD5T.Gas5_Shutoff_Valve"" Code=""PVD5T_SetGas5_Shutoff_Valve""/>" & _
"" & _
"<Property Name=""PVD5T.Gas1_Flowrate_Readback"" Code=""PVD5T_SetGas1_Flowrate_Readback,SetPVD5TGas1RBInProcessPopUpTo""/>" & _
"<Property Name=""PVD5T.Gas2_Flowrate_Readback"" Code=""PVD5T_SetGas2_Flowrate_Readback,SetPVD5TGas2RBInProcessPopUpTo""/>" & _
"<Property Name=""PVD5T.Gas3_Flowrate_Readback"" Code=""PVD5T_SetGas3_Flowrate_Readback,SetPVD5TGas3RBInProcessPopUpTo""/>" & _
"<Property Name=""PVD5T.Gas4_Flowrate_Readback"" Code=""PVD5T_SetGas4_Flowrate_Readback,SetPVD5TGas4RBInProcessPopUpTo""/>" & _
"<Property Name=""PVD5T.Gas5_Flowrate_Readback"" Code=""PVD5T_SetGas5_Flowrate_Readback,SetPVD5TGas5RBInProcessPopUpTo""/>" & _
"" & _
"<Property Name=""PVD5T.Gas1_Flowrate_Program"" Code=""PVD5T_SetGas1_Flowrate_Program,SetPVD5TGas1SPInProcessPopUpTo""/>" & _
"<Property Name=""PVD5T.Gas2_Flowrate_Program"" Code=""PVD5T_SetGas2_Flowrate_Program,SetPVD5TGas2SPInProcessPopUpTo""/>" & _
"<Property Name=""PVD5T.Gas3_Flowrate_Program"" Code=""PVD5T_SetGas3_Flowrate_Program,SetPVD5TGas3SPInProcessPopUpTo""/>" & _
"<Property Name=""PVD5T.Gas4_Flowrate_Program"" Code=""PVD5T_SetGas4_Flowrate_Program,SetPVD5TGas4SPInProcessPopUpTo""/>" & _
"<Property Name=""PVD5T.Gas5_Flowrate_Program"" Code=""PVD5T_SetGas5_Flowrate_Program,SetPVD5TGas5SPInProcessPopUpTo""/>" & _
"" & _
"<Property Name=""PVD5T.Gas1MFCDevinetStatus"" Code=""PVD5T_SetPVD5TGas1StatusTo"" />" & _
"<Property Name=""PVD5T.Gas2MFCDevinetStatus"" Code=""PVD5T_SetPVD5TGas2StatusTo"" />" & _
"<Property Name=""PVD5T.Gas3MFCDevinetStatus"" Code=""PVD5T_SetPVD5TGas3StatusTo"" />" & _
"<Property Name=""PVD5T.Gas4MFCDevinetStatus"" Code=""PVD5T_SetPVD5TGas4StatusTo"" />" & _
"<Property Name=""PVD5T.Gas5MFCDevinetStatus"" Code=""PVD5T_SetPVD5TGas5StatusTo"" />" & _
"" & _
"<Property Name=""PVD5T.Main_Dist_Valve"" Code=""PVD5T_SetMain_Dist_Valve""/>" & _
"<Property Name=""PVD5T.Sec_Dist_Valve"" Code=""PVD5T_SetSec_Dist_Valve""/>" & _
"<Property Name=""PVD5T.IG_Isolation_ValveStatus"" Code=""PVD5T_SetIG_Isolation_Valve""/>" & _
"" & _
"<!--  Valves  # 5 -->" & _
"<Property Name=""PVD5T.RoughValveStatus"" Code=""PVD5T_SetRough_Valve_Status""/>" & _
"<Property Name=""PVD5T.VentValveStatus"" Code=""PVD5T_SetVent_Valve_Status""/>" & _
"<Property Name=""PVD5T.Isolation_Valve_Status"" Code=""PVD5T_SetIsolation_Valve_Status""/>" & _
"<Property Name=""PVD5T.Hivac_Valve_Status"" Code=""PVD5T_SetHivac_Valve_Status""/>" & _
"<Property Name=""PVD5T.ForelineValveStatus"" Code=""PVD5T_SetForeline_Valve_Status""/>" & _
"<Property Name=""PVD5T.Baratron_Valve_Status"" Code=""PVD5T_SetBaratron_Valve_Status""/>" & _
"" & _
"<!--  Pressure # 6 -->" & _
"<Property Name=""PVD5T.IG"" Code=""PVD5T_SetIG_Pressure""/>" & _
"<Property Name=""PVD5T.IGStatus"" Code=""PVD5T_SetIG_Status""/>" & _
"<Property Name=""PVD5T.CG"" Code=""PVD5T_SetCG_Pressure,UpdatePVD5TCGPressureInCGPopUp""/>" & _
"<Property Name=""PVD5T.CG_Relay_Status"" Code=""PVD5T_SetChamberinterlock_Chamber_Pressure_Status""/>" & _
"<Property Name=""PVD5T.SwitchIGFilament"" Code=""PVD5T_SetSwicthIGFilamentTo"" />" & _
"<Property Name=""PVD5T.EnableIGFilament"" Code=""PVD5T_SetEnableIGFilamentTo"" />" & _
"" & _
"<Property Name=""PVD5T.Foreline_CG_Pressure"" Code=""PVD5T_SetForeline_CG_Pressure,PVD5T_UpdatePVD5TForelineCGPressureInCGPopUp""/>" & _
"<Property Name=""PVD5T.Foreline_CG_Relay_Status"" Code=""PVD5T_SetForeline_CG_Relay_Status,PVD5T_SetChamberinterlock_Turbo_Foreline_Status""/>" & _
"" & _
"<Property Name=""PVD5T.Baratron_Pressure"" Code=""PVD5T_SetBaratron_Pressure,PVD5T_SetBaratronPressureOfPopUpScreenTo,SetProcessPressureOfChamberInProcessScreenTo""/>" & _
"" & _
"<Property Name=""PVD5T.Mechanical_Pump_CG_Pressure"" Code=""PVD5T_SetMechanical_Pump_CG_Pressure,UpdatePVD5TRoughlineCGPressureInCGPopUp""/>" & _
"<Property Name=""PVD5T.Mechanical_Pump_CG_Relay_Status"" Code=""PVD5T_SetMechanical_Pump_CG_Relay_Status""/>" & _
"<Property Name=""PVD5T.Mechanical_Pump_Status"" Code=""PVD5T_SetMechanical_Pump_Status""/>" & _
"<Property Name=""PVD5T.MPump_Serial_Communication_Status"" Code=""PVD5T_SetMechanical_Pump_Com_Status""/>" & _
"<Property Name=""PVD5T.WaitingMPON"" Code=""PVD5T_SetMechanical_Pump_Waiting_ON""/>" & _
"" & _
"<!--  Interlocks # 7 -->" & _
"<Property Name=""PVD5T.Chamberinterlock_Substrate_Table_Water_Status"" Code=""PVD5T_SetChamberinterlock_Substrate_Table_Water_Status""/>" & _
"<Property Name=""PVD5T.Chamberinterlock_Air_Pressure_Status"" Code=""PVD5T_SetChamberinterlock_Air_Pressure_Status""/>" & _
"" & _
"<Property Name=""PVD5T.Chamberinterlock_Door_Closed_Status"" Code=""PVD5T_SetChamberinterlock_Door_Closed_Status""/>" & _
"<Property Name=""PVD5T.Chamberinterlock_Lid_Closed_Status"" Code=""PVD5T_SetChamberinterlock_Lid_Closed_Status""/>" & _
"" & _
"<Property Name=""PVD5T.Chamberinterlock_Target1_Water_Status"" Code=""PVD5T_SetChamberinterlock_Target1_Water_Status""/>" & _
"<Property Name=""PVD5T.Chamberinterlock_Target2_Water_Status"" Code=""PVD5T_SetChamberinterlock_Target2_Water_Status""/>" & _
"<Property Name=""PVD5T.Chamberinterlock_Target3_Water_Status"" Code=""PVD5T_SetChamberinterlock_Target3_Water_Status""/>" & _
"<Property Name=""PVD5T.Chamberinterlock_Target4_Water_Status"" Code=""PVD5T_SetChamberinterlock_Target4_Water_Status""/>" & _
"<Property Name=""PVD5T.Chamberinterlock_Target5_Water_Status"" Code=""PVD5T_SetChamberinterlock_Target5_Water_Status""/>" & _
"" & _
"<Property Name=""PVD5T.Chamberinterlock_Target_MB_Water_Status"" Code=""PVD5T_SetChamberinterlock_Target_MB_Water_Status""/>" & _
"<Property Name=""PVD5T.Chamberinterlock_Bias_MB_Water_Status"" Code=""PVD5T_SetChamberinterlock_Bias_MB_Water_Status""/>" & _
"<Property Name=""PVD5T.Chamberinterlock_Turbo_Water_Status"" Code=""PVD5T_SetChamberinterlock_Turbo_Water_Status""/>" & _
"<Property Name=""PVD5T.Chamberinterlock_PS_Interlock_Status"" Code=""PVD5T_SetChamberinterlock_Ps_Interlock_Status""/>" & _
"<Property Name=""PVD5T.Chamberinterlock_Devicenet_Comm"" Code=""PVD5T_SetChamberinterlock_Devicenet_Comm""/>" & _
"<Property Name=""PVD5T.Chamberinterlock_Target_Panels"" Code=""PVD5T_SetChamberinterlock_Target_Panels""/>" & _
"" & _
"<!--  Motion # 8 -->" & _
"<Property Name=""PVD5T.Motion_Communication_Status"" Code=""PVD5T_Set_Motion_Communication_InTableControl""/>" & _
"<Property Name=""PVD5T.Substrate_Goto_Slot"" Code=""PVD5T_SetSubstrate_Goto_Slot""/>" & _
"<Property Name=""PVD5T.Substrate_Table_Rotate_Home"" Code=""PVD5T_SetSubstrate_Goto_Home""/>" & _
"<Property Name=""PVD5T.Substrate_Table_Lift_Home"" Code=""PVD5T_SetSubstrate_Table_Lift_Home""/>" & _
"<Property Name=""PVD5T.Substrate_Current_Station"" Code=""PVD5T_SetSubstrate_Current_Station,PVD5T_SetSubstrate_Current_Station_InTableControl,SetCurrentWaferPosChamberInProcessScreenTo,SetCurrentWaferPosChamberInCassettesPanelTo,PVD5T_SetChamber_ProcessMonitor_WaferID""/>" & _
"" & _
"<Property Name=""PVD5T.Substrate_Table_Up_Down_Status"" Code=""PVD5T_SetSubstrate_Table_Up_Down_Status""/>" & _
"<Property Name=""PVD5T.Substrate_Lift_Up_Down_Status"" Code=""PVD5T_SetSubstrate_Lift_Up_Down_Status""/>" & _
"<Property Name=""PVD5T.Substrate_Table_Rotate_Status"" Code=""PVD5T_SetSubstrate_Table_Rotate_Status""/>" & _
"<Property Name=""PVD5T.Substrate_Table_Rotate_Speed"" Code=""PVD5T_SetSubstrate_Table_Rotate_Speed,PVD5T_SetSubstrate_Table_Rotate_Status,PVD5T_SetSubstrate_Table_Rotate_SpeedInProcessPopUpTo""/>" & _
"<Property Name=""PVD5T.Substrate_Table_Rotate_Speed_Readback"" Code=""PVD5T_SetSubstrate_Table_Rotate_Speed_Readback,PVD5T_SetSubstrate_Table_Rotate_Speed_ReadbackInProcessPopUpTo""/>" & _
"<Property Name=""PVD5T.Substrate_Table_Rotate_Pos_In_Unit_Readback"" Code=""PVD5T_SetSubstrate_Table_Rotate_Pos_In_Unit_Readback""/>" & _
"<Property Name=""PVD5T.Number_Of_Unit_Per_Revolution_Readback"" Code=""PVD5T_SetNumber_Of_Unit_Per_Revolution_Readback""/>" & _
"<Property Name=""PVD5T.Substrate_Table_Current_Position_Readback"" Code=""PVD5T_SetSubstrate_Table_Current_Position_Readback,PVD5T_SetTableCurrentPosotionRBInProcessPopUpTo""/>" & _
"<Property Name=""PVD5T.Substrate_Table_Current_Position_Program"" Code=""PVD5T_SetSubstrate_Table_Current_Position_Program,PVD5T_SetTableCurrentPosotionSPInProcessPopUpTo""/>" & _
"<Property Name=""PVD5T.Target1_Shutter_Status"" Code=""PVD5T_SetTarget1_Shutter_Status""/>" & _
"<Property Name=""PVD5T.Target2_Shutter_Status"" Code=""PVD5T_SetTarget2_Shutter_Status""/>" & _
"<Property Name=""PVD5T.Target3_Shutter_Status"" Code=""PVD5T_SetTarget3_Shutter_Status""/>" & _
"<Property Name=""PVD5T.Target4_Shutter_Status"" Code=""PVD5T_SetTarget4_Shutter_Status""/>" & _
"<Property Name=""PVD5T.Target5_Shutter_Status"" Code=""PVD5T_SetTarget5_Shutter_Status""/>" & _
"<Property Name=""PVD5T.Substrate_Table_Up_Down_Moving"" Code=""PVD5T_SetSubstrate_Table_Up_Down_Moving""/>" & _
"<Property Name=""PVD5T.Home_Shutter_Status"" Code=""PVD5T_SetShutterHome""/>" & _
"<Property Name=""PVD5T.Current_Shutter_ReadBack"" Code=""PVD5T_SetShutterStatusReadback""/>" & _
"<Property Name=""PVD5T.Substrate_Goto_Shutter"" Code=""PVD5T_SetShutterSP""/>" & _
"" & _
"<!--  Turbo_Waterpump # 9 -->" & _
"<Property Name=""PVD5T.Water_Pump_T_Readback"" Code=""PVD5T_SetWater_Pump_T_Readback""/>" & _
"<Property Name=""PVD5T.Water_Pump_Status"" Code=""PVD5T_SetWater_Pump_Status""/>" & _
"<Property Name=""PVD5T.Water_Pump_Regen_Status"" Code=""PVD5T_SetWater_Pump_Regen_Status""/>" & _
"<Property Name=""PVD5T.Water_Pump_State_Status"" Code=""PVD5T_SetWater_Pump_State_Status""/>" & _
"<Property Name=""PVD5T.Water_Pump_Regen_Hour_Readback"" Code=""PVD5T_SetWater_Pump_Regen_Hour_Readback""/>" & _
"<Property Name=""PVD5T.Water_Pump_Regen_Lifetime_Readback"" Code=""PVD5T_SetWater_Pump_Regen_Lifetime_Readback""/>" & _
"<Property Name=""PVD5T.Water_Pump_P_Commands"" Code=""PVD5T_SetWater_Pump_P_Commands""/>" & _
"<Property Name=""PVD5T.Water_Pump_P_Command_Readback"" Code=""PVD5T_SetWater_Pump_P_Command_Readback""/>" & _
"<Property Name=""PVD5T.Water_Pump_Is_Communicating"" Code=""PVD5T_SetWater_Pump_Is_Communicating""/>" & _
"<Property Name=""PVD5T.Turbo_Pump_On_Off"" Code=""PVD5T_SetTurbo_Pump_On_Off""/>" & _
"<Property Name=""PVD5T.Turbo_Pump_On_Off_Rb"" Code=""PVD5T_SetTurbo_Pump_On_Off_Rb""/>" & _
"<Property Name=""PVD5T.Turbo_Pump_Ramping_Percent_Rb"" Code=""PVD5T_SetTurbo_Ramping_Percent_RBTo"" />" & _
"<Property Name=""PVD5T.Turbo_Pump_Uptospeed_Rb"" Code=""PVD5T_SetTurbo_Pump_Uptospeed_Rb""/>" & _
"" & _
"<!-- Vat_Valve #10 -->" & _
"<Property Name=""PVD5T.Vat_Valve_Communication_Status"" Code=""PVD5T_SetVat_Valve_Communication_Status""/>" & _
"<Property Name=""PVD5T.Vat_Valve_Percentage_Program"" Code=""PVD5T_SetVat_Valve_Percentage_Program""/>" & _
"<Property Name=""PVD5T.Vat_Valve_Percentage_Readback"" Code=""PVD5T_SetHivac_Valve_Status""/>" & _
"<Property Name=""PVD5T.Vat_Valve_Controller_Pressure_Program"" Code=""PVD5T_SetVat_Valve_Controller_Pressure_Program""/>" & _
"<Property Name=""PVD5T.Vat_Valve_Controller_Auto_Zero"" Code=""PVD5T_SetVat_Valve_Controller_Auto_Zero""/>" & _
"<Property Name=""PVD5T.Vat_Valve_Controller_Teach"" Code=""PVD5T_SetVat_Valve_Controller_Teach""/>" & _
"<Property Name=""PVD5T.Vat_Valve_Controller_Sizeadjust"" Code=""PVD5T_SetVat_Valve_Controller_Sizeadjust""/>" & _
"" & _
"<!--  Magnatron # 11 -->" & _
"<Property Name=""PVD5T.Target1_Magnatron_Rotate_Status"" Code=""PVD5T_SetTarget1_Magnatron_Rotate_Status""/>" & _
"<Property Name=""PVD5T.Target2_Magnatron_Rotate_Status"" Code=""PVD5T_SetTarget2_Magnatron_Rotate_Status""/>" & _
"<Property Name=""PVD5T.Target3_Magnatron_Rotate_Status"" Code=""PVD5T_SetTarget3_Magnatron_Rotate_Status""/>" & _
"<Property Name=""PVD5T.Target4_Magnatron_Rotate_Status"" Code=""PVD5T_SetTarget4_Magnatron_Rotate_Status""/>" & _
"<Property Name=""PVD5T.Target5_Magnatron_Rotate_Status"" Code=""PVD5T_SetTarget5_Magnatron_Rotate_Status""/>" & _
"" & _
"<!--  RF_Target_Ps # 12 -->" & _
"<Property Name=""PVD5T.RF_Target_Communication_Status"" Code=""PVD5T_SetRF_Target_Communication_Status""/>" & _
"<Property Name=""PVD5T.RF_Target_Power_Readback"" Code=""PVD5T_SetRF_Target_Power_Readback,PVD5T_SetRF_Target_Power_Readback_Seren,PVD5T_SetRFPSForwardPowerRBInProcessPopUpTo""/>" & _
"<Property Name=""PVD5T.RF_Target_Reflected_Power_Readback"" Code=""PVD5T_SetRF_Target_Reflected_Power_Readback,PVD5T_SetRF_Target_Reflected_Power_Readback_Seren,PVD5T_SetRFPSReflectPowerRBInProcessPopUpTo""/>" & _
"<Property Name=""PVD5T.RF_Target_MB_Voltage_Readback"" Code=""PVD5T_SetRF_Target_MB_Voltage_Readback,PVD5T_SetRF_Target_MB_Voltage_Readback_Seren""/>" & _
"<Property Name=""PVD5T.RF_Target_MB_C1_Readback"" Code=""PVD5T_SetRF_Target_MB_C1_Readback,PVD5T_SetRF_Target_MB_C1_Readback_Seren""/>" & _
"<Property Name=""PVD5T.RF_Target_MB_C2_Readback"" Code=""PVD5T_SetRF_Target_MB_C2_Readback,PVD5T_SetRF_Target_MB_C2_Readback_Seren""/>" & _
"<Property Name=""PVD5T.RF_Target_Power_Program"" Code=""PVD5T_SetRF_Target_Power_Program,PVD5T_SetRF_Target_Power_Program_Seren,PVD5T_SetRFPSForwardPowerSPInProcessPopUpTo""/>" & _
"<Property Name=""PVD5T.RF_Target_Reflected_Power_Program"" Code=""PVD5T_SetRF_Target_Reflected_Power_Program,PVD5T_SetRF_Target_Reflected_Power_Program_Seren""/>" & _
"<Property Name=""PVD5T.RF_Target_MB_Voltage_Program"" Code=""PVD5T_SetRF_Target_MB_Voltage_Program,PVD5T_SetRF_Target_MB_Voltage_Program_Seren""/>" & _
"<Property Name=""PVD5T.RF_Target_MB_C1_Program"" Code=""PVD5T_SetRF_Target_MB_C1_Program,PVD5T_SetRF_Target_MB_C1_Program_Seren""/>" & _
"<Property Name=""PVD5T.RF_Target_MB_C2_Program"" Code=""PVD5T_SetRF_Target_MB_C2_Program,PVD5T_SetRF_Target_MB_C2_Program_Seren""/>" & _
"<Property Name=""PVD5T.RF_Target_MB_Match_Mode_Readback"" Code=""PVD5T_SetRF_Target_MB_Match_Mode_Readback,PVD5T_SetRF_Target_MB_Match_Mode_Readback_Seren,PVD5T_SetRF_Target_MB_Match_Mode_Program,PVD5T_SetRF_Target_MB_Match_Mode_Program_Seren""/>" & _
"<Property Name=""PVD5T.RF_Target_MB_Match_Mode_Program"" Code=""PVD5T_SetRF_Target_MB_Match_Mode_Program,PVD5T_SetRF_Target_MB_Match_Mode_Program_Seren""/>" & _
"<Property Name=""PVD5T.RF_Target_MB_Preset_Program"" Code=""PVD5T_SetRF_Target_MB_Preset_Program,PVD5T_SetRF_Target_MB_Preset_Program_Seren""/>" & _
"<Property Name=""PVD5T.RF_Target_MB_Preset_Readback"" Code=""PVD5T_SetRF_Target_MB_Preset_Readback,PVD5T_SetRF_Target_MB_Preset_Readback_Seren""/>" & _
"<Property Name=""PVD5T.RF_Target_Error_Readback"" Code=""PVD5T_SetRF_Target_Error_Readback""/>" & _
"<Property Name=""PVD5T.RF_Target_MB_Mag_Error_Readback"" Code=""PVD5T_SetRF_Target_MB_Mag_Error_Readback""/>" & _
"<Property Name=""PVD5T.RF_Target_MB_Phase_Error_Readback"" Code=""PVD5T_SetRF_Target_MB_Phase_Error_Readback""/>" & _
"<Property Name=""PVD5T.RF_Target_Voltage_SP"" Code=""PVD5T_SetRF_Target_Voltage_SP""/>" & _
"" & _
"" & _
"<!--  Bias_Ps # 13 -->" & _
"<Property Name=""PVD5T.Bias_Communication_Status"" Code=""PVD5T_SetBias_Communication_Status""/>" & _
"<Property Name=""PVD5T.Bias_Power_Readback"" Code=""PVD5T_SetBias_Power_Readback,PVD5T_SetBias_Power_Readback_Seren,PVD5T_SetBiasForwardPowerRBInProcessPopUpTo""/>" & _
"<Property Name=""PVD5T.Bias_Reflected_Power_Readback"" Code=""PVD5T_SetBias_Reflected_Power_Readback,PVD5T_SetBias_Reflected_Power_Readback_Seren,PVD5T_SetBiasReflectPowerRBInProcessPopUpTo""/>" & _
"<Property Name=""PVD5T.Bias_MB_Voltage_Readback"" Code=""PVD5T_SetBias_MB_Voltage_Readback,PVD5T_SetBias_MB_Voltage_Readback_Seren""/>" & _
"<Property Name=""PVD5T.Bias_MB_C1_Readback"" Code=""PVD5T_SetBias_MB_C1_Readback,PVD5T_SetBias_MB_C1_Readback_Seren""/>" & _
"<Property Name=""PVD5T.Bias_MB_C2_Readback"" Code=""PVD5T_SetBias_MB_C2_Readback,PVD5T_SetBias_MB_C2_Readback_Seren""/>" & _
"<Property Name=""PVD5T.Bias_Power_Program"" Code=""PVD5T_SetBias_Power_Program,PVD5T_SetBias_Power_Program_Seren,PVD5T_SetBiasForwardPowerSPInProcessPopUpTo""/>" & _
"<Property Name=""PVD5T.Bias_Reflected_Power_Program"" Code=""PVD5T_SetBias_Reflected_Power_Program,PVD5T_SetBias_Reflected_Power_Program_Seren""/>" & _
"<Property Name=""PVD5T.Bias_MB_Voltage_Program"" Code=""PVD5T_SetBias_MB_Voltage_Program,PVD5T_SetBias_MB_Voltage_Program_Seren""/>" & _
"<Property Name=""PVD5T.Bias_MB_C1_Program"" Code=""PVD5T_SetBias_MB_C1_Program,PVD5T_SetBias_MB_C1_Program_Seren""/>" & _
"<Property Name=""PVD5T.Bias_MB_C2_Program"" Code=""PVD5T_SetBias_MB_C2_Program,PVD5T_SetBias_MB_C2_Program_Seren""/>" & _
"<Property Name=""PVD5T.Bias_MB_Match_Mode_Readback"" Code=""PVD5T_SetBias_MB_Match_Mode_Readback,PVD5T_SetBias_MB_Match_Mode_Readback_Seren,PVD5T_SetBias_MB_Match_Mode_Program,PVD5T_SetBias_MB_Match_Mode_Program_Seren""/>" & _
"<Property Name=""PVD5T.Bias_MB_Match_Mode_Program"" Code=""PVD5T_SetBias_MB_Match_Mode_Program,PVD5T_SetBias_MB_Match_Mode_Program_Seren""/>" & _
"<Property Name=""PVD5T.Bias_MB_Preset_Program"" Code=""PVD5T_SetBias_MB_Preset_Program,PVD5T_SetBias_MB_Preset_Program_Seren""/>" & _
"<Property Name=""PVD5T.Bias_MB_Preset_Readback"" Code=""PVD5T_SetBias_MB_Preset_Readback,PVD5T_SetBias_MB_Preset_Readback_Seren""/>" & _
"" & _
"<Property Name=""PVD5T.Bias_Error_Readback"" Code=""PVD5T_SetBias_Error_Readback""/>" & _
"<Property Name=""PVD5T.Bias_MB_Mag_Error_Readback"" Code=""PVD5T_SetBias_MB_Mag_Error_Readback""/>" & _
"<Property Name=""PVD5T.Bias_MB_Phase_Error_Readback"" Code=""PVD5T_SetBias_MB_Phase_Error_Readback""/>" & _
"<Property Name=""PVD5T.Bias_Power_Contact_On_Off"" Code=""PVD5T_SetBias_Power_Contact_On_Off""/>" & _
"<Property Name=""PVD5T.Bias_Plasma_Status"" Code=""PVD5T_SetBias_Plasma_Status""/>" & _
"<!--  DC_Target_Ps # 14 -->" & _
"<Property Name=""PVD5T.DC_Target_Communication_Status"" Code=""PVD5T_SetDC_Target_Communication_Status""/>" & _
"<Property Name=""PVD5T.DC_Target_Power_Readback"" Code=""PVD5T_SetDC_Target_Power_Readback,PVD5T_SetDCPSForwardPowerRBInProcessPopUpTo""/>" & _
"<Property Name=""PVD5T.DC_Target_Power_Program"" Code=""PVD5T_SetDC_Target_Power_Program,PVD5T_SetDCPSForwardPowerSPInProcessPopUpTo""/>" & _
"<Property Name=""PVD5T.DC_Target_Voltage_Readback"" Code=""PVD5T_SetDC_Target_Voltage_Readback""/>" & _
"<Property Name=""PVD5T.DC_Target_Current_Readback"" Code=""PVD5T_SetDC_Target_Current_Readback,PVD5T_SetDCPSReflectPowerRBInProcessPopUpTo""/>" & _
"<Property Name=""PVD5T.DC_Target_Pluse_Mode_Status"" Code=""PVD5T_SetDC_Target_Pluse_Mode_Status""/>" & _
"<Property Name=""PVD5T.DC_Target_Pulse_Frequency_Program"" Code=""PVD5T_SetDC_Target_Pulse_Frequency_Program""/>" & _
"<Property Name=""PVD5T.DC_Target_Pulse_Frequency_Readback"" Code=""PVD5T_SetDC_Target_Pulse_Frequency_Readback""/>" & _
"<Property Name=""PVD5T.DC_Target_Pulse_Width_Program"" Code=""PVD5T_SetDC_Target_Pulse_Width_Program""/>" & _
"<Property Name=""PVD5T.DC_Target_Pulse_Width_Readback"" Code=""PVD5T_SetDC_Target_Pulse_Width_Readback""/>" & _
"<Property Name=""PVD5T.DC_Target_Ramp_Time_Program"" Code=""PVD5T_SetDC_Target_Ramp_Time_Program""/>" & _
"<Property Name=""PVD5T.DC_Target_Ramp_Time_Readback"" Code=""PVD5T_SetDC_Target_Ramp_Time_Readback""/>" & _
"<Property Name=""PVD5T.DC_Target_Arc_Counter_Readback"" Code=""PVD5T_SetDC_Target_Arc_Counter_Readback""/>" & _
"<Property Name=""PVD5T.DC_Target_Voltage_SP"" Code=""PVD5T_SetDC_Target_Voltage_SP""/>" & _
"" & _
"<!--  Heater # 15 -->" & _
"<Property Name=""PVD5T.HeaterZone1_Communication_Status"" Code=""PVD5T_SetHeaterZone1_Communication_Status""/>" & _
"<Property Name=""PVD5T.HeaterZone2_Communication_Status"" Code=""PVD5T_SetHeaterZone2_Communication_Status""/>" & _
"<Property Name=""PVD5T.Heater1_OnOff_RB"" Code=""PVD5T_Set_HeaterZone1_Status""/>" & _
"<Property Name=""PVD5T.Heater2_OnOff_RB"" Code=""PVD5T_Set_HeaterZone2_Status""/>" & _
"<Property Name=""PVD5T.Heater_Zone1_RB"" Code=""PVD5T_Set_HeaterZone1_RB""/>" & _
"<Property Name=""PVD5T.Heater_Zone2_RB"" Code=""PVD5T_Set_HeaterZone2_RB""/>" & _
"" & _
"<!--  WaferInside -->" & _
"<Property Name=""PVD5T.WaferInside"" Code=""SetWaferInsideChamberInProcessScreenTo,PVD5T_SetChamber_ProcessMonitor_WaferID""/>" & _
"" & _
"<Property Name=""PVD5T.Target_Select_Readback"" Code=""PVD5T_SetTarget_Select_Readback""/>" & _
"<Property Name=""PVD5T.Plasma_Status"" Code=""PVD5T_SetPlasma_Status""/>" & _
"<Property Name=""PVD5T.MachinePumpPurge_Current_Cycle"" Code=""PVD5T_SetChamber_SetPumpPurgeCurentCycleTo""/>" & _
"<Property Name=""PVD5T.Target1_Injection_ValveStatus"" Code=""PVD5T_SetChamber_SetInjectionValve1""/>" & _
"<Property Name=""PVD5T.Target2_Injection_ValveStatus"" Code=""PVD5T_SetChamber_SetInjectionValve2""/>" & _
"<Property Name=""PVD5T.Target3_Injection_ValveStatus"" Code=""PVD5T_SetChamber_SetInjectionValve3""/>" & _
"<Property Name=""PVD5T.Target4_Injection_ValveStatus"" Code=""PVD5T_SetChamber_SetInjectionValve4""/>" & _
"<Property Name=""PVD5T.Target5_Injection_ValveStatus"" Code=""PVD5T_SetChamber_SetInjectionValve5""/>" & _
"" & _
"<!--Filmetric-->" & _
"<Property Name=""PVD5T.Filmetric_ListRecipe_RB"" Code=""PVD5T_Update_ListRecipe_Readback""/>" & _
"<Property Name=""PVD5T.Filmetric_Thickness"" Code=""PVD5T_Set_Filmetric_Thickness""/>" & _
"<Property Name=""PVD5T.Filmetric_Recipe_SP"" Code=""PVD5T_Set_Recipe_Thickness""/>" & _
"<Property Name=""PVD5T.Goodness_Of_Fit"" Code=""PVD5T_Set_Goodness_Of_Fit""/>" & _
"" & _
"<Property Name=""PVD5T.PM_WaferCount"" Code=""SetPVD5TChamber_SetIncreaseWaferCount""/>" & _
"<!--Cryo #19 -->" & _
"<Property Name=""PVD5T.Cryo_T1_Readback"" Code=""SetPVD5TChamber_SetCryoT1To""/>" & _
"<Property Name=""PVD5T.Cryo_T2_Readback"" Code=""SetPVD5TChamber_SetCryoT2To""/>" & _
"<Property Name=""PVD5T.Cryo_RegenHour_Readback"" Code=""SetPVD5TChamber_SetCryoRegenHourToPopUpPanel""/>" & _
"<Property Name=""PVD5T.Cryo_LifeTimeHour_Readback"" Code=""SetPVD5TChamber_SetCryoLifeTimeHourToPopUpPanel""/>" & _
"<Property Name=""PVD5T.Cryo_CommunicationStatus"" Code=""SetPVD5TChamber_SetCryoCommunicationTo""/>" & _
"<Property Name=""PVD5T.CryoRegenStatus"" Code=""SetPVD5TChamber_SetMnuCryoRegenTo,SetPVD5TChamber_SetCryoRegenButtonTo""/>" & _
"<Property Name=""PVD5T.CryoRegenStatusText"" Code=""SetPVD5TChamber_SetCryoRegenStatusTextTo""/>" & _
"<Property Name=""PVD5T.Cryo_P_Command"" Code=""SetPVD5TChamber_SetP_ParameterTo""/>" & _
"<Property Name=""PVD5T.CryoPowerOnOff"" Code=""SetPVD5TChamber_SetMnuCryoOnTo""/>" & _
"<Property Name=""PVD5T.CryoFastRegenStatus"" Code=""SetPVD5TChamber_SetMnuFastRegenTo""/>" & _
"	<!--IBE Server-->" & _
" 	<Property Name=""IBE.WaferStatus"" Code=""SetIBE_WaferStatusInSLProcessScreenTo,SetIBEChamber_SetWaferStatusTo""/>" & _
"  <Property Name=""IBE.WaferInside"" Code=""SetWaferInsideSLProcessScreenTo,SetWaferInsideIBEInProcessScreenTo,SetIBEProcessMonitor_WaferID""/>" & _
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
"  <Property Name=""IBE.Initializing_Motion_readback"" Code=""SetIBEFixture_InitializingMotionStatusTo""/>" & _
"  <Property Name=""IBE.FlowCoolGasOnStatus"" Code=""SetFlowcoolGasIBEInProcessModuleTo""/>" & _
"  <Property Name=""IBE.Flowcool_Gas_readback"" Code=""SetFlowcoolGasIBEInProcessPanelTo""/>" & _
"  <Property Name=""IBE.Process_Gas_Readback"" Code=""SetProcessGasIBEInProcessPanelTo,SetProcessGasIBEInProcessModuleTo""/>" & _
"  <Property Name=""IBE.Ion_Beam_Readback"" Code=""SetIonBeamIBEInProcessPanelTo,SetSourceBeamInProcessPanelTo,SetIonBeamIBEInProcessModuleTo,SetPlasmaInProcessModuleTo""/>" & _
"  <Property Name=""IBE.PBN_OK_Readback"" Code=""SetPBNOKIBEInProcessPanelTo,SetPBNOKIBEInProcessModuleTo""/>" & _
"  <!-- RFPowerSupply-->" & _
"  <Property Name=""IBE.RFPowerSupply_ForwardPower_Readback"" Code=""SetIBERFPowerSupply_SetForwardPowerInProcessPanelTo,SetIBERFPowerSupply_SetForwardPowerInProcessModuleTo,SetIBEBeamPowerSupply_SetRFPowerRBInProcessPanelTo""/>" & _
"  <Property Name=""IBE.RFPowerSupply_ReflectedPower"" Code=""SetIBERFPowerSupply_SetReflectedPowerInProcessPanelTo,SetIBERFPowerSupply_SetReflectedPowerInProcessModuleTo,SetIBEBeamPowerSupply_SetRFReflectedRBInProcessPanelTo""/>" & _
"  <Property Name=""IBE.RFPowerSupply_ReflectedPower_Program"" Code=""SetIBERFPowerSupply_SetReflectedPowerRightTo""/>" & _
"  <Property Name=""IBE.RFPowerSupply_ForwardPower_Program"" Code=""SetIBERFPowerSupply_ForwardPowerRight,SetIBEBeamPowerSupply_SetRFPowerSPInProcessPanelTo""/>" & _
"  <!-- BeamPowerSupply-->" & _
"  <Property Name=""IBE.BeamPowerSupply_Current_Readback"" Code=""SetIBEBeamPowerSupply_SetCurrentInProcessPanelTo,SetIBEBeamPowerSupply_SetCurrentInProcessModuleTo,SetIBEBeamPowerSupply_SetCurrentRBInProcessPanelTo""/>" & _
"  <Property Name=""IBE.BeamPowerSupply_Current_Program"" Code=""SetIBEBeamPowerSupply_SetCurrentRightTo,SetIBEBeamPowerSupply_SetCurrentSPInProcessPanelTo""/>" & _
"  <Property Name=""IBE.BeamPowerSupply_Voltage_Readback"" Code=""SetIBEBeamPowerSupply_SetVoltageInProcessPanelTo,SetIBEBeamPowerSupply_SetVoltageInProcessModuleTo,SetIBEBeamPowerSupply_SetVoltageRBInProcessPanelTo""/>" & _
"  <Property Name=""IBE.BeamPowerSupply_Voltage_Program"" Code=""SetIBEBeamPowerSupply_VoltageRight,SetIBEBeamPowerSupply_SetVoltageSPInProcessPanelTo""/>" & _
"  <Property Name=""IBE.BeamPowerSupply_AutoBeam"" Code=""SetIBEBeamPowerSupply_AutoBeam""/>" & _
"  <!-- SuppressorPowerSupply-->" & _
"  <Property Name=""IBE.SuppressorPowerSupply_Voltage_Readback"" Code=""SetIBESuppressorPowerSupply_SetVoltageInProcessPanelTo,SetIBESuppressorPowerSupply_SetVoltageInProcessModuleTo,SetIBEBeamPowerSupply_SetSuppressorVoltageRBInProcessPanelTo""/>" & _
"  <Property Name=""IBE.SuppressorPowerSupply_Voltage_Program"" Code=""SetIBESuppressorPowerSupply_VoltageRight,SetIBEBeamPowerSupply_SetSuppressorVoltageSPInProcessPanelTo""/>" & _
"  <Property Name=""IBE.SuppressorPowerSupply_Current_Readback"" Code=""SetIBESuppressorPowerSupply_SetCurrentInProcessModuleTo,SetIBESuppressorPowerSupply_SetCurrentInProcessPanelTo,SetIBEBeamPowerSupply_SetSuppressorCurrentRBInProcessPanelTo""/>" & _
"  <Property Name=""IBE.SuppressorPowerSupply_Current_Program"" Code=""SetIBESuppressorPowerSupply_SetCurrentRightTo""/>" & _
"  <!-- BodyPowerSupply-->" & _
"  <Property Name=""IBE.DischargePowerSupply_Voltage_Readback"" Code=""SetIBEDischargePowerSupplyVoltageRBPanel,SetIBEDischargePowerSupplyVoltageRBProcessPanel""/>" & _
"  <Property Name=""IBE.BodyPowerSupply_Voltage_Readback"" Code=""SetIBEBeamPowerSupplyVoltageRBPanel,SetIBEBeamPowerSupplyVoltageRBProcessPanel""/>" & _
"  <Property Name=""IBE.BodyPowerSupply_Current_Readback"" Code=""SetIBEBodyPowerSupply_SetCurrentInProcessPanelTo,SetIBEBodyPowerSupply_SetCurrentInProcessModuleTo,SetIBEBeamPowerSupply_SetPBNBodyRBInProcessPanelTo""/>" & _
"  <Property Name=""IBE.BodyPowerSupply_Current_Program"" Code=""SetIBEBodyPowerSupply_CurrentRight,SetIBEBeamPowerSupply_SetPBNBodySPInProcessPanelTo""/>" & _
"  <Property Name=""IBE.DischargePowerSupply_Current_Readback"" Code=""SetIBEDischargePowerSupply_SetCurrentInProcessPanelTo,SetIBEDischargePowerSupply_SetCurrentInProcessModuleTo,SetIBEBeamPowerSupply_SetPBNDischargeRBInProcessPanelTo""/>" & _
"  <Property Name=""IBE.BodyPowerSupply_KFactor_Readback"" Code=""SetIBEBodyPowerSupply_SetKFactorInProcessPanelTo,SetIBEBodyPowerSupply_SetKFactorTo,SetIBEBeamPowerSupply_SetKFactorRBInProcessPanelTo""/>" & _
"  <Property Name=""IBE.BodyPowerSupply_KFactor_Program"" Code=""SetIBEBodyPowerSupply_SetKFactorRightTo,SetIBEBeamPowerSupply_SetKFactorSPInProcessPanelTo""/>" & _
"  <Property Name=""IBE.ANC_Probe_Voltage_Readback"" Code=""SetIBEANC_Probe_Voltage_ReadbackTo,SetANC_Probe_Voltage_ReadbackInProcessPanelTo""/>" & _
"  <!-- Temperture-->" & _
"  <!--Property Name=""IBE.Cryo_Pump_Temperture"" Code=""SetIBETempertureInProcessPanelTo""/-->" & _
"  <Property Name=""IBE.Cryo_Pump_Temperture_T2"" Code=""SetIBETempertureT2To,SetIBETempertureT2WPTo,SetIBETempertureInProcessPanelTo,SetIBETempCryoInPopUpPanelTo,SetIBETempWPInPopUpPanelTo""/>" & _
"  <Property Name=""IBE.Cryo_Pump_Temperture_T1"" Code=""SetIBETempertureT1To""/>" & _
"  <Property Name=""IBE.RampingPercentTurbo"" Code=""SetIBERampingPercentTurboTo""/>" & _
"   <!-- CGCFLCG-->" & _
"  <Property Name=""IBE.CGCFLCG_Information"" Code=""SetIBECGCFLCG_SetInformationTo,UpdateIBEForelineCGPressureInCGPopUp""/>" & _
"  <!-- CGCRLCG-->" & _
"  <Property Name=""IBE.CGCRLCG_Information"" Code=""SetIBECGCRLCG_SetInformationTo,UpdateIBERoughPumpCGPressureInCGPopUp""/>" & _
"  <!-- CGCMG-->" & _
"  <Property Name=""IBE.CGCMG_Information"" Code=""SetIBECGCMG_SetInformationTo""/>" & _
"  <Property Name=""IBE.MPCG_RelayIndicatorStatus"" Code=""SetIBERelayIndicatorPump""/>" & _
"  <!-- FixtureControl-->" & _
"  <Property Name=""IBE.Fixture_TiltAngle_Program"" Code=""SetIBEFixtureControl_SetTiltAngleTo,SetProcessPanel_FixtureControl_SetTiltAngleTo,SetIBEFixtureControl_TiltAngleRight,SetIBEBeamPowerSupply_SetTiltAngleRBInProcessPanelTo,SetIBEBeamPowerSupply_SetTiltAngleSPInProcessPanelTo""/>" & _
"  <!--Property Name=""IBE.Fixture_TiltAngle_Readback"" Code=""SetIBEFixtureControl_SetTiltAngleTo,SetProcessPanel_FixtureControl_SetTiltAngleTo,SetIBEFixtureControl_TiltAngleRight""/-->" & _
"  <Property Name=""IBE.SweepFixture_Rotation_Start_Readback"" Code=""SetIBEFixtureControlSweep_SetRotationStartTo""/>" & _
"  <Property Name=""IBE.SweepFixture_Rotation_Start_Program"" Code=""SetIBEFixtureControlSweep_RotationRight""/>" & _
"  <Property Name=""IBE.SweepFixture_Rotation_End_Program"" Code=""SetIBEFixtureControlSweep_RotationEndRight""/>  " & _
"  <Property Name=""IBE.Fixture_TiltStartAngle_Program"" Code=""SetIBEFixtureControlSweep_TiltStartAngle""/>" & _
"  <Property Name=""IBE.Fixture_TiltEndAngle_Program"" Code=""SetIBEFixtureControlSweep_TiltEndAngle""/>    " & _
"  <!-- FixtureControlStatic-->" & _
"  <Property Name=""IBE.StaticFixture_Rotation_Readback"" Code=""SetIBEFixtureControlStatic_SetRotationTo,SetIBEFixtureControlSweep_SetRotationTo""/>  " & _
"  <Property Name=""IBE.StaticFixture_Rotation_Program"" Code=""SetIBEFixtureControlStatic_RotationRight""/>" & _
"  <!-- FixtureControlContinuous-->" & _
"  <Property Name=""IBE.ContinuousFixture_Rotation_Readback"" Code=""SetIBEFixtureControlContinuous_SetRotationTo""/>" & _
"  <Property Name=""IBE.ContinuousFixture_Rotation_Program"" Code=""SetIBEFixtureControlContinuous_RotationRight""/>" & _
"  <!--Fixture Status-->" & _
"  <!--Property Name=""IBE.Fixture_Home_Tilt_Readback"" Code=""SetIBEFixture_HomeTiltStatusTo""/-->" & _
"  <Property Name=""IBE.Fixture_Start_Rotation_Readback"" Code=""SetIBE_FixtureStartRotationForMenuTo""/>" & _
"   <Property Name=""IBE.FixtureTiltHomeStatus"" Code=""SetIBEFixture_HomeTiltStatusTo""/>" & _
"   <Property Name=""IBE.FixtureRotationMovingStatus"" Code=""SetIBEFixture_RotationMovingStatus,SetIBEFixture_RotationMovingToButtonRotateStatus,SetIBEFixture_RotationMovingToProcessPanel""/>" & _
"   <Property Name=""IBE.Fixture_Rotation_Mode_Readback"" Code=""SetIBEFixture_RotationModeTo""/>" & _
"   <Property Name=""IBE.TiltAtAngleSensor"" Code=""SetIBETiltAtAngleSensorTo""/>   " & _
"     <!-- GasController-->" & _
"  <Property Name=""IBE.GasController_Argon_Readback"" Code=""SetIBEGasController_SetArgonTo,SetIBEGasController_SetArgonTo_SourceTab""/>" & _
"  <Property Name=""IBE.GasController_FlowCoolHe_Readback"" Code=""SetIBEGasController_SetFlowCoolHeTo,SetIBEBeamPowerSupply_SetFlowCoolRBTo""/>" & _
"  <Property Name=""IBE.GasController_PBN_Readback"" Code=""SetIBEGasController_SetPBNTo,SetIBEGasController_SetPBNTo_SourceTab,SetProcessScreen_SetPBNTo,SetIBEBeamPowerSupply_SetPBNGasRBInProcessPanelTo""/>" & _
"  <Property Name=""IBE.GasController_PBN_Program"" Code=""SetIBEGasController_PBNRight,SetIBEGasController_PBNRight_SourceTab,SetIBEBeamPowerSupply_SetPBNGasSPInProcessPanelTo""/>" & _
"  <Property Name=""IBE.GasController_Argon_Program"" Code=""SetIBEGasController_ArgonRight,SetIBEGasController_ArgonRight_SourceTab""/>" & _
"  <Property Name=""IBE.GasController_FlowCoolHe_Program"" Code=""SetIBEGasController_FlowCoolHeRight,SetIBEBeamPowerSupply_SetFlowCoolSPTo""/>" & _
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
"  <Property Name=""IBE.RoughValveStatus"" Code=""SetIBERoughValveStatus,SetIBERoughValveGeneralStatus""/>" & _
"  <Property Name=""IBE.VentValveStatus"" Code=""SetIBEVentValveStatus""/>" & _
"  <Property Name=""IBE.IGIsolationValveStatus"" Code=""SetIBEIGIsolationValveStatus""/>" & _
"  <Property Name=""IBE.DiverterValveStatus"" Code=""SetIBEDiverterValveStatus""/>" & _
"  <Property Name=""IBE.HiVacValveStatus"" Code=""SetIBEHiVacValveStatus""/>" & _
"  <!--Gas-->" & _
"  <Property Name=""IBE.GasController_Gas1_Readback"" Code=""SetIBEGas1ReadbackTo,SetIBEGas1ReadbackSourceTabTo,SetProcessPanel_Gas1ReadbackSourceTabTo,SetIBEBeamPowerSupply_SetGas1RBInProcessPanelTo""/>" & _
"  <Property Name=""IBE.GasController_Gas2_Readback"" Code=""SetIBEGas2ReadbackTo,SetIBEGas2ReadbackSourceTabTo,SetProcessPanel_Gas2ReadbackSourceTabTo,SetIBEBeamPowerSupply_SetGas2RBInProcessPanelTo""/>" & _
"  <Property Name=""IBE.GasController_Gas3_Readback"" Code=""SetIBEGas3ReadbackTo,SetIBEGas3ReadbackSourceTabTo,SetIBEBeamPowerSupply_SetGas3RBInProcessPanelTo""/>" & _
"  <Property Name=""IBE.GasController_Gas4_Readback"" Code=""SetIBEGas4ReadbackTo,SetIBEGas4ReadbackSourceTabTo,SetIBEBeamPowerSupply_SetGas4RBInProcessPanelTo""/>" & _
"  <Property Name=""IBE.GasController_Gas1_Program"" Code=""SetIBEGas1ProgramTo,SetIBEGas1ProgramSourceTabTo,SetIBEBeamPowerSupply_SetGas1SPInProcessPanelTo""/>" & _
"  <Property Name=""IBE.GasController_Gas2_Program"" Code=""SetIBEGas2ProgramTo,SetIBEGas2ProgramSourceTabTo,SetIBEBeamPowerSupply_SetGas2SPInProcessPanelTo""/>" & _
"  <Property Name=""IBE.GasController_Gas3_Program"" Code=""SetIBEGas3ProgramTo,SetIBEGas3ProgramSourceTabTo,SetIBEBeamPowerSupply_SetGas3SPInProcessPanelTo""/>" & _
"  <Property Name=""IBE.GasController_Gas4_Program"" Code=""SetIBEGas4ProgramTo,SetIBEGas4ProgramSourceTabTo,SetIBEBeamPowerSupply_SetGas4SPInProcessPanelTo""/>" & _
"  " & _
"  <Property Name=""IBE.ShutterPositionStatus"" Code=""SetIBEShutterPositionInProcessPanel,SetIBEShutterPositionInProcessModule,SetIBEShutterInFixture""/>" & _
"  <Property Name=""IBE.InternalShutterStatus"" Code=""SetIBEInternalShutter""/>" & _
"  <Property Name=""IBE.InternalShutterOffStatus"" Code=""SetIBEInternalShutterOff""/>" & _
"  <Property Name=""IBE.TurboPowerStatus"" Code=""SetIBEValveWaterPump""/>" & _
"  <Property Name=""IBE.ValveCryoPumpGateStatus"" Code=""SetIBEValveCryoPump,SetIBEMenuValveCryoPump""/>" & _
"  <Property Name=""IBE.TurboPumpRegen"" Code=""SetIBEWaterPumpRegen""/>" & _
"  " & _
"  <!--Shield Usage-->" & _
"   <Property Name=""IBE.CoverFixtureShieldUsageReadback"" Code=""SetIBECoverFixtureShieldUsageReadbackTo""/>" & _
"   <Property Name=""IBE.TopFixtureShieldUsageReadback"" Code=""SetIBETopFixtureShieldUsageReadbackTo""/>" & _
"   <Property Name=""IBE.WaferClampUsageReadback"" Code=""SetIBEWaferClampUsageReadbackTo""/>" & _
"   <Property Name=""IBE.ShutterUsageReadback"" Code=""SetIBEShutterUsageReadbackTo""/>" & _
"   <Property Name=""IBE.FixtureRotationMotorUsageReadback"" Code=""SetIBEFixtureRotationMotorUsageReadbackTo""/>" & _
"   <Property Name=""IBE.LinerSourceUsageReadback"" Code=""SetIBELinerSourceUsageReadbackTo""/>" & _
"   <Property Name=""IBE.CryoUsageReadback"" Code=""SetIBECryoUsageReadbackTo""/>" & _
"   <Property Name=""IBE.WaterJournalReadback"" Code=""SetIBEWaterJournalReadbackTo""/>" & _
"   " & _
"  <!-- ChamberInterlocks-->" & _
"  <Property Name=""IBE.ChamberInterlocks_PanelInterlock_Status"" Code=""SetIBEChangeInterlocksPanelInProcessPanelTo,SetIBEChangeInterlocksPanelInProcessModuleTo""/>" & _
"  <Property Name=""IBE.ChamberInterlocks_ChamberPress_Status"" Code=""SetIBEChangeInterlocksChamberPressInProcessPanelTo,SetIBEChangeInterlocksChamberPressInProcessModuleTo""/>" & _
"  <Property Name=""IBE.ChamberInterlocks_FixtureWater_Status"" Code=""SetIBEChangeInterlocksFixureWaterInProcessPanelTo,SetIBEChangeInterlocksFixureWaterInProcessModuleTo""/>" & _
"  <Property Name=""IBE.ChamberInterlocks_FixtureWaterBug_Status"" Code=""SetIBEChangeInterlocksFixureWaterBugInProcessPanelTo,SetIBEChangeInterlocksFixureWaterBugInProcessModuleTo""/>" & _
"  <Property Name=""IBE.ChamberInterlocks_Foreline_Status"" Code=""SetIBEChangeInterlocksForelineInProcessPanelTo,SetIBEChangeInterlocksForelineInProcessModuleTo""/>" & _
"  <Property Name=""IBE.ChamberInterlocks_SourceWater_Status"" Code=""SetIBEChangeInterlocksSourceWaterInProcessPanelTo,SetIBEChangeInterlocksSourceWaterInProcessModuleTo""/>" & _
"  <Property Name=""IBE.ChamberInterlocks_TurboWater_Status"" Code=""SetIBEChangeInterlocksTurboWaterInProcessPanelTo,SetIBEChangeInterlocksTurboWaterInProcessModuleTo""/>" & _
"  <Property Name=""IBE.ChamberInterlocks_AirPressure_Status"" Code=""SetIBEChangeInterlocksAirPressureInProcessPanelTo,SetIBEChangeInterlocksAirPressureInProcessModuleTo""/>" & _
"  <Property Name=""IBE.ChamberInterlocks_FixtureRotation_Status"" Code=""SetIBEChangeInterlocksFixtureRotationInProcessPanelTo,SetIBEChangeInterlocksFixtureRotationInProcessModuleTo""/>" & _
"  <!--Process Status-->" & _
"  <Property Name=""IBE.WaferID"" Code=""SetIBEProcessMonitor_WaferID""/>" & _
"  <Property Name=""IBE.EPDRecipe"" Code=""SetIBEProcessMonitor_EPDRecipe""/>" & _
"  <Property Name=""IBE.Recipe"" Code=""SetIBEProcessMonitorInProcessPanel_RecipeTo,SetIBEProcessMonitorInProcessModule_RecipeTo,SetRecipeOfChamberInProcessScreenTo,SetIBEChamber_ProcessMonitor_SetRunRecipeNameTo""/>" & _
"  <Property Name=""IBE.RunProcessStatus"" Code=""SetStatusOfIBEInProcessScreenTo,SetIBEProcessMonitor_StatusTo,SetStatusOfChamberInProcessScreenTo""/>" & _
"  <Property Name=""IBE.RemainingTime"" Code=""SetIBERemainingTimeTo,SetProcessScreen_RemainingTimeTo,SetProcessScreen_RemainingTimeInStatusPanelTo,SetIBEProcessMonitor_RemainingTimeInStatusPanelTo""/>" & _
"  <Property Name=""IBE.ProcessMonitor_ProcessStep"" Code=""SetStepNumberOfChamberInProcessScreenTo,SetIBEProcessMonitor_ProcessStepInStatusPanelInProcessPanelTo,SetIBEProcessMonitor_ProcessStepInProcessModuleTo,SetIBEProcessMonitor_ProcessStepInStatusPanelInProcessModuleTo""/>" & _
"  <Property Name=""IBE.ProcessMonitor_Status_Readback"" Code=""SetProcessStatusInProcessPanel,SetIBEProcessMonitor_StatusTo,SetStatusOfChamberInProcessScreenTo""/>" & _
"  <Property Name=""IBE.ElapsedTime"" Code=""SetIBEProcessMonitor_ElapsedTimeTo,SetProcessScreen_ElapsedTimeTo,SetProcessScreen_ElapsedTimeInStatusPanelTo,SetIBEProcessMonitor_ElapsedTimeInStatusPanelTo,SetStepTimeOfChamberInProcessScreenTo""/>" & _
"  <Property Name=""IBE.ProcessMonitor_TotalStep"" Code=""SetIBEProcessMonitor_TotalStepTo""/>" & _
"  <Property Name=""IBE.IG"" Code=""SetIGOfIBETo""/>" & _
"  <Property Name=""IBE.CG"" Code=""SetCGOfIBETo,UpdateIBEPMCGPressureInCGPopUp""/>" & _
"  <Property Name=""IBE.IGStatus"" Code=""SetIGStatusOnCGGaufesFrm""/>" & _
"  <Property Name=""IBE.SwitchIGFilament"" Code=""SwitchIGFilamentIBE""/>" & _
"  <Property Name=""IBE.EnableIGFilament"" Code=""EnableIGFilamentIBE""/>" & _
"  <!--Run Recipe-->" & _
"  <Property Name=""IBE.ProcessMonitor_DeviceStart_Readback"" Code=""SetIBEChamber_ProcessMonitor_SetDeviceStartTo""/>" & _
"  <Property Name=""IBE.ProcessMonitor_DeviceStop_Readback"" Code=""SetIBEChamber_ProcessMonitor_SetDeviceStopTo,SetStatusOfIBEInProcessScreenTo""/>" & _
"  <Property Name=""IBE.ProcessMonitor_DevicePause_Readback"" Code=""SetIBEChamber_ProcessMonitor_SetDevicePauseTo""/>" & _
"  <Property Name=""IBE.ProcessMonitor_DeviceContinue_Readback"" Code=""SetIBEChamber_ProcessMonitor_SetDeviceContinueTo""/>" & _
"  <Property Name=""IBE.ProcessControl_GetRunDataFileName"" Code=""SetIBEChamber_ProcessControl_GetRunDataFileNameTo""/>" & _
"  <!--Menu-->" & _
"  <Property Name=""IBE.PumpDownStatus"" Code=""SetMnuPumpDownIBETo""/>" & _
"  <Property Name=""IBE.VentStatus"" Code=""SetMnuVentIBETo""/>" & _
"  <Property Name=""IBE.CryoPumpStatus"" Code=""SetButtonCryoIBETo,SetMnuCryoIBETo,SetMnuWaterPumpTo,SetMnuCryoIBE_InCryoPopupPanelTo""/>" & _
"  <Property Name=""IBE.RoughPumpStatus"" Code=""SetMnuRoughPumpIBEInProcessModuleTo""/>" & _
"  <Property Name=""IBE.CryoPumpRegenStatus"" Code=""SetMnuCryoPumpRegenIBETo""/>" & _
"  <Property Name=""IBE.CryoAutoRegenStatus"" Code=""SetMnuCryoAutoRegenIBETo,SetMnuCryoAutoRegenIBE_InCryoPopUpPanelTo""/>" & _
"  <Property Name=""IBE.CryoAutoRegenStatusText"" Code=""SetCryoAutoRegenStatusTextIBETo,SetCryoAutoRegenStatusTextIBE_InCryoPopUpPanelTo""/>" & _
"  <Property Name=""IBE.CryoAutoPowerDownStatus"" Code=""SetMnuCryoAutoPowerDownIBETo""/>" & _
"  <Property Name=""IBE.CryoPumpPurgeStatus"" Code=""SetMnuCryoPumpPurgeIBETo""/>" & _
"  <Property Name=""IBE.RateOfRise_Status"" Code=""SetMnuCryoRateOfRiseIBETo""/>" & _
"  <Property Name=""IBE.PumpDown_Curve_Status"" Code=""SetPumpdownCurveStatusIBETo""/>" & _
"  <Property Name=""IBE.PumpPurgeStatus"" Code=""SetMnuPumpPurgeIBETo""/>" & _
"  <Property Name=""IBE.IGDegasStatus"" Code=""SetMnuIGDegasIBETo""/>  " & _
"  <Property Name=""IBE.AutoSequenceRunningStatusText"" Code=""SetNameOfAutoSequenceRunning""/>" & _
"  <Property Name=""IBE.PBNGasFlowingStatusText"" Code=""SetPBNGasFlowingStatusText""/>" & _
"  <Property Name=""IBE.ChannelsGasFlowingStatusText"" Code=""SetChannelsGasFlowingStatusText""/>" & _
"  <Property Name=""IBE.CryoLastFullRegenReadBack"" Code=""SetCryoRegenHourIBE_InCryoPopUpPanelTo""/>" & _
"  <Property Name=""IBE.CryoElapsedTimeReadBack"" Code=""SetCryoLifeTimeHourIBE_InCryoPopUpPanelTo""/>" & _
"  " & _
"  <!--Property Name=""IBE.WaterPump"" Code=""SetMnuWaterPumpTo""/>" & _
"  <Property Name=""IBE.WaterPumpRegen"" Code=""SetMnuWaterPumpRegenTo""/-->" & _
" " & _
" 	<Property Name=""IBE.FixtureWaterValveStatus"" Code=""SetIBEMenuFixtureOpenWaterValve,SetIBEFixtureOpenWaterValve""/>" & _
"  <Property Name=""IBE.FixtureFlowCoolPumpStatus"" Code=""SetIBEFixtureOpenFlowCool,SetMnuRoughPumpIBEInProcessPanelTo""/>" & _
" 	<Property Name=""IBE.OverridesModeStatus"" Code=""SetIBEFixtureUnProtected""/>" & _
" " & _
"  <Property Name=""IBE.ControlStatus"" Code=""ChangeMachineOnlineInIBETo,ChangeMachineOnlineIBEInProcessModuleTo,SetOnlineIBEInProcessScreenTo"" /> " & _
"   <!--System Setup-->" & _
"  <Property Name=""IBE.SourceUsageTimeCurrent"" Code=""SetSourceUsageTimeIBETo,SetSourceUsageTimeIBEInProcessPanelTo,SetSourceUsageTimeIBEInProcessModuleTo,SetSourceUsageTimeIBEInProcessPanel2To,SetSourceUsageTimeIBEInProcessModule2To,SetSourceUsageTimeIBEInProcessModuleUsageTabTo,SetSourceMinutesMaintIBETo""/>" & _
"  <Property Name=""IBE.PBNTimeCurrent"" Code=""SetPBNMinutesMaintIBETo""/>" & _
"  <!--End Single loader -->" & _
"  " & _
"  <!--IBE Server-->" & _
"  <Property Name=""IBE.OnlineStatus"" Code=""SetIBE_OnlineStatusTo""/>" & _
"  <Property Name=""IBE.AutoPumpDownStatus"" Code=""SetIBE_AutoPumpDownStatusTo""/>" & _
"  <Property Name=""IBE.AutoVentStatus"" Code=""SetIBE_AutoVentStatusTo""/>" & _
"  <!--Power Panel-->" & _
"  <Property Name=""IBE.PowerStatusPanel.ACPower"" Code=""ChangeButtonACPowerIBETo""/>" & _
"  <Property Name=""IBE.PowerStatusPanel.RFPower"" Code=""ChangeButtonRFPowerIBETo""/>" & _
"  <Property Name=""IBE.PowerStatusPanel.GridPower"" Code=""ChangeButtonGridPowerIBETo""/>" & _
"  <Property Name=""IBE.PowerStatusPanel.PBNPower"" Code=""ChangeButtonPBNPowerIBETo""/>" & _
"  <!--Fixture-->" & _
"  <Property Name=""IBE.FixtureRotationHomeStatus"" Code=""SetIBEFixture_HomeRotationStatusTo""/>" & _
"  <Property Name=""IBE.FixtureTiltMovingStatus"" Code=""SetIBEFixture_TiltMovingStatusTo""/>" & _
"  <Property Name=""IBE.Fixture_Tilt_Sweeping"" Code=""SetIBEFixture_TiltMovingStatusTobtnTilt""/>" & _
"  <Property Name=""IBE.FixtureErrorStatus"" Code=""SetIBETiltFixtureError""/>" & _
"  <Property Name=""IBE.FixtureRotationErrorStatus"" Code=""SetIBERotationFixtureError""/>" & _
"  <Property Name=""IBE.Wafer_InFixture_Readback"" Code=""SetIBEWaferInFixtureTo""/>" & _
"  <Property Name=""IBE.Fixture_Tilt_Mode"" Code=""SetIBEFixture_TileMode""/>" & _
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
"  <Property Name=""IBE.Cryo_P_Command"" Code=""SetIBEChamber_SetP_ParameterTo""/>" & _
"  " & _
"  <!-- Machine tool,  old system have not 3 items such as: Cryo On, Cryo Regen, Cryo Hivac-->" & _
"  <Property Name=""IBE.MachinePumbDown"" Code=""SetIBEMachinePumbDown""/>" & _
"  <Property Name=""IBE.MachineVent"" Code=""SetIBEMachineVent""/>" & _
"  <!-- CryoCommmunicateStateReadBack -->" & _
"  <Property Name=""IBE.CryoCommmunicateStateReadBackStatus"" Code=""SetIBECryoCommmunicateStateReadBack""/>" & _
"  <!-- ChamberProcess Chamber 5-->" & _
"  <Property Name=""IBE.StepTime"" Code=""SetStepTimeOfIBEInProcessScreenTo,SetIBEProcessMonitor_StepTimeTo""/>" & _
"  <Property Name=""IBE.PressureMode"" Code=""SetEtchPressureOfIBEInProcessScreenTo""/>" & _
"  <Property Name=""IBE.PM_WaferCount"" Code=""SetIBEChamber_SetIncreaseWaferCount""/>" & _
"  <Property Name=""IBE.Shields_Quart_KWH"" Code=""SetIBEChamber_ShieldQuartTo,SetIBEChamber_ShieldQuartReadBackTo""/>" & _
"  <Property Name=""IBE.MachinePumpPurge_Current_Cycle"" Code=""SetIBEChamber_SetPumpPurgeCurentCycleTo""/>" & _
"  <Property Name=""IBE.ChamberLoopInfo"" Code=""SetIBELoopInfoChamberInProcessScreenTo""/>" & _
"  " & _
"  <!--Chiller-->" & _
"  <Property Name=""IBE.ChillerCommunication"" Code=""SetIBEChillerCommunicationTo""/>" & _
"  <Property Name=""IBE.ChillerTemperatureReadback"" Code=""SetIBEChillerTemperatureRBTo""/>" & _
"  <Property Name=""IBE.ChillerTemperatureSP"" Code=""SetIBEChillerTemperatureSPTo""/>" & _
"  <Property Name=""IBE.ChillerFlowRateReadBack"" Code=""SetIBEChillerFlowRateRB""/>" & _
"  <Property Name=""IBE.ChillerStateReadback"" Code=""SetIBEChillerStateTo""/>" & _
"  <Property Name=""IBE.ChillerProcessTemperatureMax"" Code=""SetIBEChillerProcessTemperatureMaxTo""/>" & _
"  <Property Name=""IBE.ChillerVentTemperatureMax"" Code=""SetIBEChillerVentTemperatureMaxTo""/>" & _
"  <Property Name=""IBE.ChillerVentTemperatureMin"" Code=""SetIBEChillerVentTemperatureMinTo""/>" & _
"  <Property Name=""IBE.ChillerProcessTemperatureMin"" Code=""SetIBEChillerProcessTemperatureMinTo""/>" & _
"  <!--SourceEM-->" & _
"  <Property Name=""IBE.SourceEMCurrentRB"" Code=""SetIBESourceEMCurrentRB,SetProcessScreen_SetSourceEMCurrentTo,SetIBESourceEMCurrentRBSourceTabTo,SetIBESourceEMPowerSupply_SetEMCurrentInProcessPanelTo""/>" & _
"  <Property Name=""IBE.SourceEMCurrentSP"" Code=""SetIBESourceEMCurrentSP,SetIBESourceEMCurrentSPSourceTabTo""/>" & _
"  <Property Name=""IBE.SourceEMVoltageRB"" Code=""SetIBESourceEMVoltageRB""/>" & _
"  <Property Name=""IBE.SourceEMCommunicationStatus"" Code=""SetIBESourceEMCommunicationStatus""/>" & _
"  </MessageNames>                "
End Class
End Namespace
