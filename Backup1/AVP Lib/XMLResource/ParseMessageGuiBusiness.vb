Namespace XMLResources
Public Class ParseMessageGuiBusiness
Public Const XMLText as String = _
"<MessageNames>" & _
"	<Property Name=""DiagnosticDialog.dgsPumpDownTM.PumpdownCurve"" Code=""CassettesModule.PumpdownCurve""/>" & _
"    <Property Name=""DiagnosticDialog.dgsRateOfRiseTM.RateOfRise"" Code=""CassettesModule.RateOfRise""/>" & _
"    <Property Name=""DiagnosticDialog.dgsRecoverPressureTM.RecoverPressure"" Code=""CassettesModule.RecoverPressure""/>" & _
"    <Property Name=""DiagnosticDialog.dgsPumpDownTM.StopPumpdownCurve"" Code=""CassettesModule.StopPumpdownCurve""/>" & _
"    <Property Name=""DiagnosticDialog.dgsRateOfRiseTM.StopRateOfRise"" Code=""CassettesModule.StopRateOfRise""/>" & _
"    <Property Name=""DiagnosticDialog.dgsRecoverPressureTM.StopRecoverPressure"" Code=""CassettesModule.StopRecoverPressure""/>" & _
"   " & _
"    <Property Name=""DiagnosticDialog.dgsPumpDownLLA.PumpdownCurve"" Code=""LoadLockA.PumpdownCurve""/>" & _
"    <Property Name=""DiagnosticDialog.dgsRateOfRiseLLA.RateOfRise"" Code=""LoadLockA.RateOfRise""/>" & _
"    <Property Name=""DiagnosticDialog.dgsRecoverPressureLLA.RecoverPressure"" Code=""LoadLockA.RecoverPressure""/>" & _
"    <Property Name=""DiagnosticDialog.dgsPumpDownLLA.StopPumpdownCurve"" Code=""LoadLockA.StopPumpdownCurve""/>" & _
"    <Property Name=""DiagnosticDialog.dgsRateOfRiseLLA.StopRateOfRise"" Code=""LoadLockA.StopRateOfRise""/>" & _
"    <Property Name=""DiagnosticDialog.dgsRecoverPressureLLA.StopRecoverPressure"" Code=""LoadLockA.StopRecoverPressure""/>" & _
"	" & _
"	<Property Name=""DiagnosticDialog.dgsPumpDownPM1.PumpdownCurve"" Code=""Chamber1.PumpdownCurve""/>" & _
"	<Property Name=""DiagnosticDialog.dgsRateOfRisePM1.RateOfRise"" Code=""Chamber1.RateOfRise""/>" & _
"	<Property Name=""DiagnosticDialog.dgsRecoverPressurePM1.RecoverPressure"" Code=""Chamber1.RecoverPressure""/>" & _
"	<Property Name=""DiagnosticDialog.dgsPumpDownPM1.StopPumpdownCurve"" Code=""Chamber1.StopPumpdownCurve""/>" & _
"	<Property Name=""DiagnosticDialog.dgsRateOfRisePM1.StopRateOfRise"" Code=""Chamber1.StopRateOfRise""/>" & _
"	<Property Name=""DiagnosticDialog.dgsRecoverPressurePM1.StopRecoverPressure"" Code=""Chamber1.StopRecoverPressure""/>" & _
"	" & _
"	<Property Name=""DiagnosticDialog.dgsPumpDownPM2.PumpdownCurve"" Code=""Chamber2.PumpdownCurve""/>" & _
"	<Property Name=""DiagnosticDialog.dgsRateOfRisePM2.RateOfRise"" Code=""Chamber2.RateOfRise""/>" & _
"	<Property Name=""DiagnosticDialog.dgsRecoverPressurePM2.RecoverPressure"" Code=""Chamber2.RecoverPressure""/>" & _
"	<Property Name=""DiagnosticDialog.dgsPumpDownPM2.StopPumpdownCurve"" Code=""Chamber2.StopPumpdownCurve""/>" & _
"	<Property Name=""DiagnosticDialog.dgsRateOfRisePM2.StopRateOfRise"" Code=""Chamber2.StopRateOfRise""/>" & _
"	<Property Name=""DiagnosticDialog.dgsRecoverPressurePM2.StopRecoverPressure"" Code=""Chamber2.StopRecoverPressure""/>" & _
"	" & _
"	<Property Name=""DiagnosticDialog.dgsPumpDownPM3.PumpdownCurve"" Code=""Chamber3.PumpdownCurve""/>" & _
"	<Property Name=""DiagnosticDialog.dgsRateOfRisePM3.RateOfRise"" Code=""Chamber3.RateOfRise""/>" & _
"	<Property Name=""DiagnosticDialog.dgsRecoverPressurePM3.RecoverPressure"" Code=""Chamber3.RecoverPressure""/>" & _
"	<Property Name=""DiagnosticDialog.dgsPumpDownPM3.StopPumpdownCurve"" Code=""Chamber3.StopPumpdownCurve""/>" & _
"	<Property Name=""DiagnosticDialog.dgsRateOfRisePM3.StopRateOfRise"" Code=""Chamber3.StopRateOfRise""/>" & _
"	<Property Name=""DiagnosticDialog.dgsRecoverPressurePM3.StopRecoverPressure"" Code=""Chamber3.StopRecoverPressure""/>" & _
"	" & _
"  <!--Purpose: Mapping GUI element events to actions of Business Controllers -->" & _
"  <!--================================================CassettesPanel======================================================-->" & _
"  <Property Name=""CassettesPanel.atwAutoTransferWafer.btnREStatus"" Code=""Robot.ArmRetract"" />" & _
"  <Property Name=""CassettesPanel.atwAutoTransferWafer.btnEXStatus"" Code=""Robot.ArmExtend"" />" & _
"  <Property Name=""CassettesPanel.atwAutoTransferWafer.btnUPStatus"" Code=""Robot.ArmUp"" />" & _
"  <Property Name=""CassettesPanel.atwAutoTransferWafer.btnDNStatus"" Code=""Robot.ArmDown"" />" & _
"  <Property Name=""CassettesPanel.atwAutoTransferWafer.btnPick"" Code=""Robot.Pick"" />" & _
"  <Property Name=""CassettesPanel.atwAutoTransferWafer.btnPlace"" Code=""Robot.Place"" />" & _
"  <Property Name=""SystemSetup.btnRequestRobotInfo"" Code=""Robot.RequestInfo""/>" & _
"  <Property Name=""SystemSetup.SetConfigRobot"" Code=""Robot.SetConfigRobot""/>   " & _
"  <Property Name=""SystemSetup.txtTMCGTripPoint"" Code=""CassettesModule.SetTMCGTripPoint""/>  " & _
"  <Property Name=""SystemSetup.txtLLACGTripPoint"" Code=""LoadLockA.SetCGTripPoint""/>" & _
"  <Property Name=""SystemSetup.txtMPCGTripPoint"" Code=""CassettesModule.SetMPCGTripPoint""/>" & _
"  <Property Name=""SystemSetup.txtTMForelineCGTripPoint"" Code=""CassettesModule.SetTurboCGTripPoint""/>  " & _
"  <Property Name=""SystemSetup.txtLLAForelineCGTripPoint"" Code=""LoadLockA.SetTurboCGTripPoint""/> " & _
"  <!--System Setup-->" & _
"    <Property Name=""CassettesPanel.atwAutoTransferWafer.chkDisableChekingSensor TurnOnWaferSensorChecking"" Code=""Robot.TurnOnWaferSensorChecking""/>" & _
"    <Property Name=""CassettesPanel.atwAutoTransferWafer.chkDisableChekingSensor TurnOffWaferSensorChecking"" Code=""Robot.TurnOffWaferSensorChecking""/>" & _
"  <!--End System Setup-->" & _
"" & _
"  <Property Name=""CassettesPanel.TMCryoPopUpPanel.txtExtendedPurgeTime"" Code=""TMPumpPackage.Cryo.ExtendedPurgeTime"" />" & _
"  <Property Name=""CassettesPanel.TMCryoPopUpPanel.txtPumpRestartDelay"" Code=""TMPumpPackage.Cryo.PumpRestartDelay"" />" & _
"  <Property Name=""CassettesPanel.TMCryoPopUpPanel.txtRateOfRise"" Code=""TMPumpPackage.Cryo.RateOfRise"" />" & _
"  <Property Name=""CassettesPanel.TMCryoPopUpPanel.txtRoughToPressure"" Code=""TMPumpPackage.Cryo.RoughToPressure"" />" & _
"  <Property Name=""CassettesPanel.TMCryoPopUpPanel.txtStartUpTemp"" Code=""TMPumpPackage.Cryo.StartUpTemp"" />" & _
"  <Property Name=""CassettesPanel.TMCryoPopUpPanel.txtRepurgeCycles"" Code=""TMPumpPackage.Cryo.RepurgeCycles"" />" & _
"	" & _
"  <Property Name=""CassettesPanel.LLACryoPopUpPanel.txtExtendedPurgeTime"" Code=""LLAPumpPackage.Cryo.ExtendedPurgeTime"" />" & _
"  <Property Name=""CassettesPanel.LLACryoPopUpPanel.txtPumpRestartDelay"" Code=""LLAPumpPackage.Cryo.PumpRestartDelay"" />" & _
"  <Property Name=""CassettesPanel.LLACryoPopUpPanel.txtRateOfRise"" Code=""LLAPumpPackage.Cryo.RateOfRise"" />" & _
"  <Property Name=""CassettesPanel.LLACryoPopUpPanel.txtRoughToPressure"" Code=""LLAPumpPackage.Cryo.RoughToPressure"" />" & _
"  <Property Name=""CassettesPanel.LLACryoPopUpPanel.txtStartUpTemp"" Code=""LLAPumpPackage.Cryo.StartUpTemp"" />" & _
"  <Property Name=""CassettesPanel.LLACryoPopUpPanel.txtRepurgeCycles"" Code=""LLAPumpPackage.Cryo.RepurgeCycles"" />" & _
"" & _
"  <!--VentValve-->" & _
"  <Property Name=""CassettesPanel.ValveVent On"" Code=""CassettesModule.Vent On"" />" & _
"  <Property Name=""CassettesPanel.ValveVent Off"" Code=""CassettesModule.Vent Off"" />" & _
"  <!--RoughValve-->" & _
"  <Property Name=""CassettesPanel.ValveRough On"" Code=""CassettesModule.Rough On"" />" & _
"  <Property Name=""CassettesPanel.ValveRough Off"" Code=""CassettesModule.Rough Off"" />" & _
"  <!--LLA SlowVentValve-->" & _
"  <Property Name=""CassettesPanel.ValveLLASlowVent On"" Code=""LoadLockA.LLSlowVent On"" />" & _
"  <Property Name=""CassettesPanel.ValveLLASlowVent Off"" Code=""LoadLockA.LLSlowVent Off"" />" & _
"  <!--LLA FastVentValve-->" & _
"  <Property Name=""CassettesPanel.ValveLLAFastVent On"" Code=""LoadLockA.LLFastVent On"" />" & _
"  <Property Name=""CassettesPanel.ValveLLAFastVent Off"" Code=""LoadLockA.LLFastVent Off"" />" & _
"  <!--LLA SlowRoughValve-->" & _
"  <Property Name=""CassettesPanel.ValveLLASlowRough On"" Code=""LoadLockA.LLSlowRough On"" />" & _
"  <Property Name=""CassettesPanel.ValveLLASlowRough Off"" Code=""LoadLockA.LLSlowRough Off"" />" & _
"  <!--LLA FastRoughValve-->" & _
"  <Property Name=""CassettesPanel.ValveLLAFastRough On"" Code=""LoadLockA.LLFastRough On"" />" & _
"  <Property Name=""CassettesPanel.ValveLLAFastRough Off"" Code=""LoadLockA.LLFastRough Off"" />" & _
"  <!--TM Turbo Valve -->" & _
"  <Property Name=""CassettesPanel.ValveTMTurbo On"" Code=""CassettesModule.TurboForeLineValve On"" />" & _
"  <Property Name=""CassettesPanel.ValveTMTurbo Off"" Code=""CassettesModule.TurboForeLineValve Off"" />" & _
"  <!--TM Turbo Valve -->" & _
"  <Property Name=""CassettesPanel.crcTMTurbo.ForelineOpenClose On"" Code=""CassettesModule.TurboForeLineValve On"" />" & _
"  <Property Name=""CassettesPanel.crcTMTurbo.ForelineOpenClose Off"" Code=""CassettesModule.TurboForeLineValve Off"" />" & _
"  <!--LLA Turbo Valve-->" & _
"  <Property Name=""CassettesPanel.ValveLLATurbo On"" Code=""LoadLockA.TurboForeLineValve On"" />" & _
"  <Property Name=""CassettesPanel.ValveLLATurbo Off"" Code=""LoadLockA.TurboForeLineValve Off"" />" & _
"  <Property Name=""CassettesPanel.crcLLTurbo.ForelineOpenClose On"" Code=""LoadLockA.TurboForeLineValve On"" />" & _
"  <Property Name=""CassettesPanel.crcLLTurbo.ForelineOpenClose Off"" Code=""LoadLockA.TurboForeLineValve Off"" />" & _
"  <!--Chamber1MesaValve-->" & _
"  <Property Name=""CassettesPanel.MesaValvePM1"" Code=""CassettesModule.SplitValvePM1"" />" & _
"   <!--Chamber2MesaValve-->" & _
"  <Property Name=""CassettesPanel.MesaValvePM2"" Code=""CassettesModule.SplitValvePM2"" />" & _
"    <!--Chamber3MesaValve-->" & _
"  <Property Name=""CassettesPanel.MesaValvePM3"" Code=""CassettesModule.SplitValvePM3"" />" & _
"    <!--LLASlitValve-->" & _
"  <Property Name=""CassettesPanel.MesaValveLLA"" Code=""CassettesModule.SplitValveLLA"" />" & _
"    <!--LLA Hivac Valve-->" & _
"  <Property Name=""CassettesPanel.HivacValveLLA"" Code=""LoadLockA.LLHiVac"" />" & _
"  <!-- Turbo -->" & _
"  <Property Name=""CassettesPanel.btnTurboTM On"" Code=""CassettesModule.Turbo On"" />" & _
"  <Property Name=""CassettesPanel.btnTurboTM Off"" Code=""CassettesModule.Turbo Off"" />" & _
"  <Property Name=""CassettesPanel.btnTurboLLA On"" Code=""LoadLockA.Turbo On"" />" & _
"  <Property Name=""CassettesPanel.btnTurboLLA Off"" Code=""LoadLockA.Turbo Off"" />" & _
"  <Property Name=""CassettesPanel.crcLLTurbo.TurboOnOff On"" Code=""LoadLockB.Turbo On"" />" & _
"  <Property Name=""CassettesPanel.crcLLTurbo.TurboOnOff Off"" Code=""LoadLockB.Turbo Off"" /> " & _
"      <!--TMHivacValve-->" & _
"  <Property Name=""CassettesPanel.TMCtl.HivacCloseButton On"" Code=""CassettesModule.TMHiVac Off"" />" & _
"  <Property Name=""CassettesPanel.TMCtl.HivacCloseButton Off"" Code=""CassettesModule.TMHiVac On"" />" & _
"  <Property Name=""CassettesPanel.HivacValveTM Off"" Code=""CassettesModule.TMHiVac Off"" />" & _
"  <Property Name=""CassettesPanel.HivacValveTM On"" Code=""CassettesModule.TMHiVac On"" />" & _
"  <Property Name=""CassettesPanel.crcTMTurbo.TurboOnOff On"" Code=""TMPumpPackage.Turbo.Start"" />" & _
"  <Property Name=""CassettesPanel.crcTMTurbo.TurboOnOff Off"" Code=""TMPumpPackage.Turbo.Stop"" />   " & _
"  <Property Name=""CassettesPanel.IgcgTM.bigcgIG On"" Code=""CassettesModule.Ion On"" />" & _
"  <Property Name=""CassettesPanel.IgcgTM.bigcgIG Off"" Code=""CassettesModule.Ion Off"" />  " & _
"  <Property Name=""CassettesPanel.IgcgLLA.bigcgIG On"" Code=""LoadLockA.Ion On"" />" & _
"  <Property Name=""CassettesPanel.IgcgLLA.bigcgIG Off"" Code=""LoadLockA.Ion Off"" />" & _
"  <Property Name=""CassettesPanel.IgcgChamber1.bigcgIG On"" Code=""Chamber1.Ion On"" />" & _
"  <Property Name=""CassettesPanel.IgcgChamber1.bigcgIG Off"" Code=""Chamber1.Ion Off"" />    " & _
"  <Property Name=""CassettesPanel.IgcgChamber2.bigcgIG On"" Code=""Chamber2.Ion On"" />" & _
"  <Property Name=""CassettesPanel.IgcgChamber2.bigcgIG Off"" Code=""Chamber2.Ion Off"" />    " & _
"  <Property Name=""CassettesPanel.IgcgChamber3.bigcgIG On"" Code=""Chamber3.Ion On"" />" & _
"  <Property Name=""CassettesPanel.IgcgChamber3.bigcgIG Off"" Code=""Chamber3.Ion Off"" /> " & _
"  <Property Name=""CassettesPanel.PopUpPanel.btnTMOnline Click"" Code=""CassettesModule.Online"" />" & _
"  <Property Name=""CassettesPanel.PopUpPanel.btnTMOnline Click_False"" Code=""CassettesModule.Online_NoAlarm"" />" & _
"  <Property Name=""CassettesPanel.PopUpPanel.btnTMOffline Click"" Code=""CassettesModule.Offline"" />" & _
"  <Property Name=""CassettesPanel.PopUpPanel.btnLLAOnline Click"" Code=""LoadLockA.Online"" />" & _
"  <Property Name=""CassettesPanel.PopUpPanel.btnLLAOnline Click_False"" Code=""LoadLockA.Online_NoAlarm"" />" & _
"  <Property Name=""CassettesPanel.PopUpPanel.btnLLAOffline Click"" Code=""LoadLockA.Offline"" />" & _
"  " & _
"  <Property Name=""CassettesPanel.PopUpPanel.btnLLAIGDegas"" Code=""LoadLockA.IGDegas"" />" & _
"  <Property Name=""CassettesPanel.PopUpPanel.btnTMIGDegas"" Code=""CassettesModule.IGDegas"" />" & _
"  " & _
"  <Property Name=""CassettesPanel.PopUpPanel.btnTMAutoPumpDown On"" Code=""CassettesModule.PumpDown"" />" & _
"  <Property Name=""CassettesPanel.PopUpPanel.btnTMAutoPumpDown Off"" Code=""CassettesModule.StopPumpDown"" />    " & _
"  <Property Name=""CassettesPanel.PopUpPanel.btnLLAAutoPumpDown On"" Code=""LoadLockA.PumpDown"" />" & _
"  <Property Name=""CassettesPanel.PopUpPanel.btnLLAAutoPumpDown Off"" Code=""LoadLockA.StopPumpDown"" />" & _
"  " & _
"  <Property Name=""CassettesPanel.RoughPumpControlCGGaugesFrm.ReleaseRoughPump1InUse"" Code=""CassettesModule.ReleaseRoughPump1InUse"" />" & _
"  <Property Name=""CassettesPanel.RoughPumpControl2CGGaugesFrm.ReleaseRoughPump2InUse"" Code=""CassettesModule.ReleaseRoughPump2InUse"" />" & _
" " & _
"  <Property Name=""CassettesPanel.RoughPumpControl On"" Code=""CassettesModule.RoughPumpControl On"" />" & _
"  <Property Name=""CassettesPanel.RoughPumpControl Off"" Code=""CassettesModule.RoughPumpControl Off"" />" & _
"  <Property Name=""CassettesPanel.RoughPumpControl2 On"" Code=""CassettesModule.RoughPumpControl2 On"" />" & _
"  <Property Name=""CassettesPanel.RoughPumpControl2 Off"" Code=""CassettesModule.RoughPumpControl2 Off"" />" & _
"  " & _
"  <Property Name=""CassettesPanel.btnFakeProcessCompleteChime"" Code=""CassettesModule.Turn_Process_Complete_Chime"" />" & _
"    " & _
"  <Property Name=""CassettesPanel.PopUpPanel.btnTMAutoVent On"" Code=""CassettesModule.AutoVent"" />" & _
"  <Property Name=""CassettesPanel.PopUpPanel.btnTMAutoVent Off"" Code=""CassettesModule.StopAutoVent"" />" & _
"  <Property Name=""CassettesPanel.PopUpPanel.btnLLAAutoVent On"" Code=""LoadLockA.AutoVent"" />" & _
"  <Property Name=""CassettesPanel.PopUpPanel.btnLLAAutoVent Off"" Code=""LoadLockA.StopAutoVent"" />" & _
"  " & _
"  <Property Name=""CassettesPanel.crcTMCryo.btnOn Off"" Code=""TMPumpPackage.Cryo.TurnPumpOff"" />" & _
"  <Property Name=""CassettesPanel.crcTMCryo.btnOn On"" Code=""TMPumpPackage.Cryo.TurnPumpOn"" />" & _
"  <Property Name=""CassettesPanel.crcTMCryo.btnRegen Off"" Code=""TMPumpPackage.Cryo.StopRegen"" />" & _
"  <Property Name=""CassettesPanel.crcTMCryo.btnRegen On"" Code=""TMPumpPackage.Cryo.StartRegen"" />" & _
"  <Property Name=""CassettesPanel.crcLLACryo.btnOn Off"" Code=""LLAPumpPackage.Cryo.TurnPumpOff"" />" & _
"  <Property Name=""CassettesPanel.crcLLACryo.btnOn On"" Code=""LLAPumpPackage.Cryo.TurnPumpOn"" />" & _
"  <Property Name=""CassettesPanel.crcLLACryo.btnRegen Off"" Code=""LLAPumpPackage.Cryo.StopRegen"" />" & _
"  <Property Name=""CassettesPanel.crcLLACryo.btnRegen On"" Code=""LLAPumpPackage.Cryo.StartRegen"" />" & _
"  <Property Name=""CassettesPanel.crcTMCryo.btnFastRegen On"" Code=""TMPumpPackage.Cryo.StartFastRegen"" />" & _
"  <Property Name=""CassettesPanel.crcLLACryo.btnFastRegen On"" Code=""LLAPumpPackage.Cryo.StartFastRegen"" />" & _
"  " & _
"  <Property Name=""CassettesPanel.crcTMWaterPump.btnOn Off"" Code=""CassettesModule.WaterPump.TurnPumpOff"" />" & _
"  <Property Name=""CassettesPanel.crcTMWaterPump.btnOn On"" Code=""CassettesModule.WaterPump.TurnPumpOn"" />" & _
"  <Property Name=""CassettesPanel.crcTMWaterPump.btnRegen Off"" Code=""CassettesModule.WaterPump.StopRegen"" />" & _
"  <Property Name=""CassettesPanel.crcTMWaterPump.btnRegen On"" Code=""CassettesModule.WaterPump.StartRegen"" />" & _
"  <!--===================================================CassetesPanel=============================================================-->" & _
"  <Property Name=""CassettesPanel.TMAlignerControl.usrOperations.btnAlign"" Code=""Aligner.Align"" />   " & _
"  <Property Name=""CassettesPanel.TMAlignerControl.usrOperations.btnHome Click"" Code=""Aligner.Home"" />" & _
"  <Property Name=""CassettesPanel.TMAlignerControl.usrOperations.btnScan Click"" Code=""Aligner.Scan"" />" & _
"  <Property Name=""CassettesPanel.atwAutoTransferWafer.btnHome Click"" Code=""Robot.Home"" />" & _
"  <Property Name=""CassettesPanel.atwAutoTransferWafer.cboStationList Station1(LLA)"" Code=""Robot.GotoStation1"" />" & _
"  <Property Name=""CassettesPanel.atwAutoTransferWafer.cboStationList Station2(PM1)"" Code=""Robot.GotoStation2"" />" & _
"  <Property Name=""CassettesPanel.atwAutoTransferWafer.cboStationList Station3(PM2)"" Code=""Robot.GotoStation3"" />" & _
"  <Property Name=""CassettesPanel.atwAutoTransferWafer.cboStationList Station4(PM3)"" Code=""Robot.GotoStation4"" />" & _
"  <Property Name=""CassettesPanel.atwAutoTransferWafer.cboStationList Station8(ADP)"" Code=""Robot.GotoStation8"" />" & _
"  <Property Name=""CassettesPanel.atwAutoTransferWafer.cboStationList Station9(ALIGNER)"" Code=""Robot.GotoStation9"" />" & _
"  <Property Name=""CassettesPanel.mnuHome Click"" Code=""Aligner.Home"" />" & _
"  <Property Name=""CassettesPanel.mnuAlign Click"" Code=""Aligner.Align"" />" & _
"  <Property Name=""CassettesPanel.lccLoadLockA.btnGoToSlot"" Code=""LoadLockA.Elevator.GoToSlot"" />" & _
"  <Property Name=""CassettesPanel.lccLoadLockA.btnHome Click"" Code=""LoadLockA.Elevator.Home"" />" & _
"  <Property Name=""CassettesPanel.lccLoadLockA.btnMap Click"" Code=""LoadLockA.Elevator.Map"" />" & _
"  <Property Name=""CassettesPanel.lccLoadLockA.btnOpen Click Open"" Code=""LoadLockA.Elevator.Open"" />" & _
"  <Property Name=""CassettesPanel.lccLoadLockA.btnOpen Click Close"" Code=""LoadLockA.Elevator.Close"" />" & _
"  <Property Name=""CassettesPanel.lccLoadLockA.btnReset Click"" Code=""LoadLockA.Elevator.Reset"" />" & _
"  <Property Name=""CassettesPanel.btnTMProtectedMode On"" Code=""CassettesModule.OverideModeStatus Off"" />" & _
"  <Property Name=""CassettesPanel.btnTMProtectedMode Off"" Code=""CassettesModule.OverideModeStatus On"" />" & _
"  <Property Name=""CassettesPanel.btnCancelMove"" Code=""CassettesModule.CancelMove"" />" & _
"  " & _
"  <!-- CG/IG Control -->" & _
"  <Property Name=""CassettesPanel.TMCGGaugesFrm.btnATM On"" Code=""CassettesModule.SetATMConvertronGauge"" />" & _
"  <Property Name=""CassettesPanel.TMCGGaugesFrm.btnVAC On"" Code=""CassettesModule.SetVACConvertronGauge"" />" & _
"  <Property Name=""CassettesPanel.TMCGGaugesFrm.btnTurnIGOn On"" Code=""CassettesModule.Ion On"" />" & _
"  <Property Name=""CassettesPanel.TMCGGaugesFrm.btnTurnIGOff On"" Code=""CassettesModule.Ion Off"" />" & _
"  <Property Name=""CassettesPanel.TMCGGaugesFrm.btnIGFilament1 On"" Code=""CassettesModule.IGFilament1"" />" & _
"  <Property Name=""CassettesPanel.TMCGGaugesFrm.btnIGFilament2 On"" Code=""CassettesModule.IGFilament2"" />" & _
"  <Property Name=""CassettesPanel.LLACGGaugesFrm.btnATM On"" Code=""LoadLockA.SetATMConvertronGauge"" />" & _
"  <Property Name=""CassettesPanel.LLACGGaugesFrm.btnVAC On"" Code=""LoadLockA.SetVACConvertronGauge"" />" & _
"  <Property Name=""CassettesPanel.LLACGGaugesFrm.btnTurnIGOn On"" Code=""LoadLockA.Ion On"" />" & _
"  <Property Name=""CassettesPanel.LLACGGaugesFrm.btnTurnIGOff On"" Code=""LoadLockA.Ion Off"" />" & _
"  <Property Name=""CassettesPanel.LLACGGaugesFrm.btnIGFilament1 On"" Code=""LoadLockA.IGFilament1"" />" & _
"  <Property Name=""CassettesPanel.LLACGGaugesFrm.btnIGFilament2 On"" Code=""LoadLockA.IGFilament2"" />" & _
"" & _
"  <Property Name=""CassettesPanel.TMForelineCGGaugesFrm.btnATM On"" Code=""CassettesModule.SetATMForelineConvertronGauge"" />" & _
"  <Property Name=""CassettesPanel.LLAForelineCGGaugesFrm.btnATM On"" Code=""LoadLockA.SetATMForelineConvertronGauge"" />" & _
"" & _
"  <Property Name=""CassettesPanel.RoughPumpControl2CGGaugesFrm.btnATM On"" Code=""CassettesModule.SetATMMechanicalPump2CG"" />" & _
"  <Property Name=""CassettesPanel.RoughPumpControl2CGGaugesFrm.btnPumpOn On"" Code=""CassettesModule.RoughPumpControl2 On"" />" & _
"  <Property Name=""CassettesPanel.RoughPumpControl2CGGaugesFrm.btnPumpOff On"" Code=""CassettesModule.RoughPumpControl2 Off"" />" & _
"  <Property Name=""CassettesPanel.RoughPumpControlCGGaugesFrm.btnATM On"" Code=""CassettesModule.SetATMMechanicalPump1CG"" />" & _
"  <Property Name=""CassettesPanel.RoughPumpControlCGGaugesFrm.btnPumpOn On"" Code=""CassettesModule.RoughPumpControl On"" />" & _
"  <Property Name=""CassettesPanel.RoughPumpControlCGGaugesFrm.btnPumpOff On"" Code=""CassettesModule.RoughPumpControl Off"" />" & _
"  <!--===================================================ProcessPanel=============================================================-->" & _
"  <Property Name=""ProcessPanel.lpcLoadLockA.btnLoad Click"" Code=""LoadLockA.Load"" />" & _
"  <Property Name=""ProcessPanel.lpcLoadLockA.btnLoad StopLoad"" Code=""LoadLockA.StopLoad"" />" & _
"  <Property Name=""ProcessPanel.lpcLoadLockA.btnUnload Click"" Code=""LoadLockA.Unload"" />" & _
"  <Property Name=""ProcessPanel.lpcLoadLockA.btnUnload StopUnLoad"" Code=""LoadLockA.StopUnLoad"" />" & _
"  <Property Name=""ProcessPanel.lpcLoadLockA.btnAbort Click True"" Code=""LoadLockA.Abort True"" />" & _
"  <Property Name=""ProcessPanel.lpcLoadLockA.btnAbort Click False"" Code=""LoadLockA.Abort False"" />" & _
"  <Property Name=""ProcessPanel.lpcLoadLockA.btnStart Click Pause"" Code=""LoadLockA.Pause"" />" & _
"  <Property Name=""ProcessPanel.lpcLoadLockA.btnStart"" Code=""LoadLockA.StartScheduler"" />" & _
"  <Property Name=""ProcessPanel.lpcLoadLockA.btnStart Click Stop"" Code=""LoadLockA.Stop"" />" & _
"  <Property Name=""ProcessPanel.lpcLoadLockA.btnStart Click Resume"" Code=""LoadLockA.Resume"" />" & _
"  " & _
"  <Property Name=""CycleATMScreen.CycleATMPanel.btnStartATM_LLA"" Code=""LoadLockA.StartScheduler"" />" & _
"  <Property Name=""CycleATMScreen.CycleATMPanel.btnStartATM_LLA Click Abort"" Code=""LoadLockA.Abort False"" />" & _
"  " & _
"  <!-- Aligner-->" & _
"  <Property Name=""ProcessPanel.mnuReturn Click Aligner_MarkForReturn"" Code=""Aligner.MarkForReturn"" />" & _
"   <Property Name=""ProcessPanel.mnuPause Click Aligner_Pause"" Code=""Aligner.Pause"" />" & _
"   <Property Name=""ProcessPanel.mnuResume Click Aligner_Resume"" Code=""Aligner.Resume"" />" & _
"   <Property Name=""ProcessPanel.mnuAbort Click Aligner_Abort"" Code=""Aligner.Abort"" />" & _
"   <!-- End Aligner-->" & _
"   <!--Robot-->" & _
"   <Property Name=""ProcessPanel.mnuReturn Click Robot_MarkForReturn"" Code=""Robot.MarkForReturn"" />" & _
"   <Property Name=""ProcessPanel.mnuPause Click Robot_Pause"" Code=""Robot.Pause"" />" & _
"   <Property Name=""ProcessPanel.mnuResume Click Robot_Resume"" Code=""Robot.Resume"" />" & _
"   <Property Name=""ProcessPanel.mnuAbort Click Robot_Abort"" Code=""Robot.Abort"" />" & _
"   <!--End Robot-->" & _
"   <!--Chambers-->" & _
"     <Property Name=""ProcessPanel.mnuReturn Click Chamber1_MarkForReturn"" Code=""Chamber1.MarkForReturn"" />" & _
"   <Property Name=""ProcessPanel.mnuPause Click Chamber1_Pause"" Code=""Chamber1.Pause"" />" & _
"   <Property Name=""ProcessPanel.mnuResume Click Chamber1_Resume"" Code=""Chamber1.Resume"" />" & _
"   <Property Name=""ProcessPanel.mnuAbort Click Chamber1_Abort"" Code=""Chamber1.Abort"" />" & _
"   " & _
"    <Property Name=""ProcessPanel.mnuReturn Click Chamber2_MarkForReturn"" Code=""Chamber2.MarkForReturn"" />" & _
"   <Property Name=""ProcessPanel.mnuPause Click Chamber2_Pause"" Code=""Chamber2.Pause"" />" & _
"   <Property Name=""ProcessPanel.mnuResume Click Chamber2_Resume"" Code=""Chamber2.Resume"" />" & _
"   <Property Name=""ProcessPanel.mnuAbort Click Chamber2_Abort"" Code=""Chamber2.Abort"" />" & _
"   " & _
"   <Property Name=""ProcessPanel.mnuReturn Click Chamber3_MarkForReturn"" Code=""Chamber3.MarkForReturn"" />" & _
"   <Property Name=""ProcessPanel.mnuPause Click Chamber3_Pause"" Code=""Chamber3.Pause"" />" & _
"   <Property Name=""ProcessPanel.mnuResume Click Chamber3_Resume"" Code=""Chamber3.Resume"" />" & _
"   <Property Name=""ProcessPanel.mnuAbort Click Chamber3_Abort"" Code=""Chamber3.Abort"" />" & _
"   <!--End Chambers-->" & _
"  " & _
"  " & _
"  	<!-- ====================================Chamber1 Screen==============================================-->" & _
"  	<Property Name=""Chamber1.SL_PopUpPanel.btnOnline"" 												Code=""Chamber1.Online"" />" & _
"    <Property Name=""Chamber1.SL_PopUpPanel.btnOffline"" 												Code=""Chamber1.Offline"" />		" & _
"	<Property Name=""Chamber1.txtGridSerialNumber""   Code=""Chamber1.UpdateGridSerialNumber"" />" & _
"    <Property Name=""Chamber1.txtGridID""   Code=""Chamber1.UpdateGridID"" />" & _
"	<Property Name=""Chamber1.txtSourceMinutesMaint""		    Code=""Chamber1.SetSourceUsage"" />" & _
"	<Property Name=""Chamber1.txtPBNMinutes""		    Code=""Chamber1.SetPBNMinutes"" />		" & _
"     <!--Menu Cryo-->" & _
"   <Property Name=""Chamber1.SL_PopUpPanel.btnCryoOnOff"" Code=""Chamber1.CryoPower""/>" & _
"   <Property Name=""Chamber1.SL_PopUpPanel.btnCryoOff"" Code=""Chamber1.CryoPower""/>" & _
"   <Property Name=""Chamber1.SL_PopUpPanel.btnCryoRegenValve"" Code=""Chamber1.CryoRegenValve""/>" & _
"   <Property Name=""Chamber1.SL_PopUpPanel.btnCryoPurge"" Code=""Chamber1.CryoPurgeValve""/>" & _
"   <Property Name=""Chamber1.SL_PopUpPanel.btnCryoPurgeOff"" Code=""Chamber1.CryoPurgeValve""/>" & _
"   <Property Name=""Chamber1.SL_PopUpPanel.btnAutoRegen"" Code=""Chamber1.CryoAutoRegen""/>" & _
"   <Property Name=""Chamber1.SL_PopUpPanel.btnAutoRegenOff"" Code=""Chamber1.CryoAutoRegen""/>" & _
"   <Property Name=""Chamber1.SL_PopUpPanel.btnAutoPowerDown"" Code=""Chamber1.CryoAutoPowerDown""/>" & _
"   <Property Name=""Chamber1.SL_PopUpPanel.btnRoughValveOpen"" Code=""Chamber1.ValveRough""/>" & _
"   <Property Name=""Chamber1.SL_PopUpPanel.btnRoughValveClose"" Code=""Chamber1.ValveRough""/>" & _
"   <!--Menu Turbo-->" & _
"   <Property Name=""Chamber1.SL_PopUpPanel.btnWaterPumpOnOff"" Code=""Chamber1.WaterPump""/>" & _
"   <Property Name=""Chamber1.SL_PopUpPanel.btnWaterPumpOff"" Code=""Chamber1.WaterPump""/>" & _
"   <Property Name=""Chamber1.SL_PopUpPanel.btnWaterPumpRegen"" Code=""Chamber1.WaterPumpRegen""/>" & _
"   " & _
"   <!--Menu Others-->" & _
"   <Property Name=""Chamber1.SL_PopUpPanel.btnAutoVentGeneral"" 		Code=""Chamber1.AutoVent""/>" & _
"   <Property Name=""Chamber1.SL_PopUpPanel.btnAutoPumpDownGeneral"" 	Code=""Chamber1.AutoPumpDown""/>" & _
"   <Property Name=""Chamber1.SL_PopUpPanel.btnRateOfRise"" Code=""Chamber1.RaiseOfRise""/>" & _
"   <Property Name=""Chamber1.SL_PopUpPanel.btnPumpPurge"" Code=""Chamber1.PumpPurge""/>" & _
"   <Property Name=""Chamber1.SL_PopUpPanel.btnIGDegas"" Code=""Chamber1.IGDegas""/>" & _
"  <!--Shutter or Screen Machine-->" & _
"  <Property Name=""Chamber1.SLContainerBox.Shutter"" 						Code=""Chamber1.ScreenMachine""/>" & _
"  <Property Name=""Chamber1.SLContainerBox.ValveTurboHivac"" 		Code=""Chamber1.HiVacValve""/>" & _
"  <Property Name=""Chamber1.SLContainerBox.ValveCryoHivac"" 		Code=""Chamber1.ValveCryoPump""/>" & _
"  <Property Name=""Chamber1.SLContainerBox.btnWaterPumpOn"" 		Code=""Chamber1.OpenTurboPumpPower""/>" & _
"  <Property Name=""Chamber1.SLContainerBox.btnCryoOn"" 					Code=""Chamber1.CryoPower""/>" & _
"  <Property Name=""Chamber1.btnUnProtected"" 									Code=""Chamber1.FixtureUnProtected"" />" & _
"  <!--Status Panel-->" & _
"  <Property Name=""Chamber1.SLFixture.btnMotionInitialized"" 		Code=""Chamber1.MotionInitialize""/>" & _
"  <!--Source tab-->" & _
"  	<!-- BeamPowerSupply-->" & _
"  <Property Name=""Chamber1.txtBeamVoltageRight"" 					Code=""Chamber1.BeamPowerSupply.VoltageRight"" />" & _
"  <Property Name=""Chamber1.txtBeamCurrentRight"" 					Code=""Chamber1.BeamPowerSupply.CurrentRight"" />" & _
"  <Property Name=""Chamber1.btnAutoBeam"" 									Code=""Chamber1.BeamPowerSupply.AutoBeam"" />" & _
"  <Property Name=""Chamber1.btnSourceManual"" 							Code=""Chamber1.PowerStatusPanel.SourceManualPower""/>" & _
"  <Property Name=""Chamber1.btnSourceAuto"" 								Code=""Chamber1.PowerStatusPanel.SourceAutoPower""/>" & _
"  	<!--SuppressorPowerSupply-->" & _
"  <Property Name=""Chamber1.txtSuppressorVoltageRight"" 		Code=""Chamber1.SuppressorPowerSupply.VoltageRight"" />" & _
"  <Property Name=""Chamber1.txtSuppressorCurrentRight"" 		Code=""Chamber1.SuppressorPowerSupply.CurrentRight"" />" & _
"  	<!--RFPowerSupply-->" & _
"  <Property Name=""Chamber1.txtRFPowerRight"" 							Code=""Chamber1.PowerSupply.ForwardPowerRight"" />" & _
"  <Property Name=""Chamber1.txtRFReflectedRight"" 					Code=""Chamber1.PowerSupply.ReflectedPowerRight"" />" & _
"  	<!--BodyPowerSupply-->" & _
"  <Property Name=""Chamber1.txtKFactorRight"" 							Code=""Chamber1.BodyPowerSupply.KFactorRight"" />" & _
"  <Property Name=""Chamber1.txtPBNBodyRight"" 							Code="""" />" & _
"  <Property Name=""Chamber1.txtPBNDischRight"" 							Code="""" />" & _
"  	<!--Gas-->" & _
"  <Property Name=""Chamber1.txtPBNGasRight"" 								Code=""Chamber1.GasController.PBNGasRight"" />" & _
"  <Property Name=""Chamber1.txtPBNGasRight_SourceTab"" 			Code=""Chamber1.GasController.PBNGasRight_Source"" />  " & _
"  <Property Name=""Chamber1.txtGas1Right"" 									Code=""Chamber1.GasController.Gas1Right"" />" & _
"	<Property Name=""Chamber1.txtGas1Right_SourceTab"" 				Code=""Chamber1.GasController.Gas1Right_Source"" />" & _
"  <Property Name=""Chamber1.txtGas2Right"" 									Code=""Chamber1.GasController.Gas2Right"" />" & _
"  <Property Name=""Chamber1.txtGas2Right_SourceTab"" 				Code=""Chamber1.GasController.Gas2Right_Source"" />" & _
"  <Property Name=""Chamber1.txtGas3Right"" 									Code=""Chamber1.GasController.Gas3Right"" />" & _
"  <Property Name=""Chamber1.txtGas4Right"" 									Code=""Chamber1.GasController.Gas4Right"" />" & _
"  <Property Name=""Chamber1.txtGas5Right"" 									Code=""Chamber1.GasController.Gas5Right"" />" & _
"  	<!--GasValve-->" & _
"  <Property Name=""Chamber1.ValveSupplyPBNGas"" 							Code=""Chamber1.ValveSupplyPBN""/>" & _
"  <Property Name=""Chamber1.ValveShutoffPBNGas""							Code=""Chamber1.ValvePBN"" />  " & _
"  <Property Name=""Chamber1.ValveSupplyGas1"" 							Code=""Chamber1.Gas1SupplyValve""/>" & _
"  <Property Name=""Chamber1.ValveShutoffGas1""							Code=""Chamber1.Gas1ShutOffValve"" />" & _
"  <Property Name=""Chamber1.ValveSupplyGas2"" 							Code=""Chamber1.Gas2SupplyValve""/>" & _
"  <Property Name=""Chamber1.ValveShutoffGas2""							Code=""Chamber1.Gas2ShutOffValve"" />" & _
"  <Property Name=""Chamber1.ValveSupplyGas3"" 							Code=""Chamber1.Gas3SupplyValve"" />" & _
"  <Property Name=""Chamber1.ValveShutoffGas3""							Code=""Chamber1.Gas3ShutOffValve"" />" & _
"  <Property Name=""Chamber1.ValveSupplyGas4"" 							Code=""Chamber1.Gas4SupplyValve"" />" & _
"  <Property Name=""Chamber1.ValveShutoffGas4""							Code=""Chamber1.Gas4ShutOffValve"" /> 											" & _
"  <!--Fixture tab -->" & _
"  <Property Name=""Chamber1.SLFixture.txtFlowCoolGasRight"" 				Code=""Chamber1.GasController.FlowCoolHeRight"" />" & _
"  <Property Name=""Chamber1.SLFixture.ValveShutoffFlowCoolGas"" 		Code=""Chamber1.ValveFlowCoolHe"" />" & _
"  <Property Name=""Chamber1.SLFixture.ValveSupplyFlowCoolGas"" 			Code=""Chamber1.ValveSupplyFlowCool"" />" & _
"  <Property Name=""Chamber1.SLFixture.btnClampUp"" 									Code=""Chamber1.FixtureClampStatus ClampUp""/>" & _
"  <Property Name=""Chamber1.SLFixture.btnClampDown"" 								Code=""Chamber1.FixtureClampStatus ClampDown""/>" & _
"  <Property Name=""Chamber1.mnuShutterOpen"" 							Code=""Chamber1.FixtureOpenShutter""/>" & _
"  <Property Name=""Chamber1.mnuShutterClose"" 						Code=""Chamber1.FixtureOpenShutter""/>" & _
"  <Property Name=""Chamber1.SLFixture.btnRotate"" 				Code=""Chamber1.FixtureStartRotationAxis""/>" & _
"  <Property Name=""Chamber1.SLFixture.btnFlowCoolPump"" 	Code=""Chamber1.FixturePumpPower""/>" & _
"  <Property Name=""Chamber1.mnuCoolingWater"" 						Code=""Chamber1.FixtureCoolingWater""/>" & _
"  <Property Name=""Chamber1.mnuUnProtected"" 						Code=""Chamber1.FixtureUnProtected""/>" & _
"  <Property Name=""Chamber1.SLFixture.btnShutterOpen"" 	Code=""Chamber1.FixtureOpenShutter""/>" & _
"  <Property Name=""Chamber1.SLFixture.btnShutterClose"" Code=""Chamber1.FixtureOpenShutter""/>" & _
"   	<!--TiltAngleRightFixture-->" & _
"  <Property Name=""Chamber1.SLFixture.txtTiltAngleRight"" 	Code=""Chamber1.Fixture.TiltAngle""/>" & _
"  	<!--RotationFixture-->" & _
"  <Property Name=""Chamber1.SLFixture.txtRotationStaticRight"" 	Code=""Chamber1.Fixture.Rotation Static""/>" & _
"  <Property Name=""Chamber1.SLFixture.txtRotationSweepRight"" 	Code=""Chamber1.Fixture.Rotation Sweep""/>" & _
"  <Property Name=""Chamber1.SLFixture.txtRotationContinuousRight"" 	Code=""Chamber1.Fixture.Rotation Continuous""/>" & _
"  <Property Name=""Chamber1.SLFixture.txtRotationEnd"" 	Code=""Chamber1.Fixture.RotationEnd""/>" & _
"  <Property Name=""Chamber1.SLFixture.btnMode"" Code=""Chamber1.Fixture.RotationMode""/>" & _
"  <!--Valves-->" & _
"  <Property Name=""Chamber1.ValveForeline"" 										Code=""Chamber1.ValveForeline""/>" & _
"  <Property Name=""Chamber1.ValveVent"" 												Code=""Chamber1.ValveVent""/>" & _
"  <Property Name=""Chamber1.ValveRough"" 												Code=""Chamber1.ValveRough""/>" & _
"  <Property Name=""Chamber1.SLContainerBox.btnMesaValve"" 			Code=""Chamber1.IsolationValve""/>" & _
"  <Property Name=""Chamber1.RoughPump"" 												Code=""Chamber1.OpenRoughPumpPower""/>" & _
"  <Property Name=""Chamber1.ValveFixtureWater"" 								Code=""Chamber1.ValveFixtureWater""/>" & _
"  <!--Power Panel-->" & _
"   <Property Name=""Chamber1.SLPowerPanel.btnACPower"" 					Code=""Chamber1.PowerStatusPanel.ACPower""/>" & _
"   <Property Name=""Chamber1.SLPowerPanel.btnGrid"" 						Code=""Chamber1.PowerStatusPanel.GridPower""/>" & _
"   <Property Name=""Chamber1.SLPowerPanel.btnRFPower"" 					Code=""Chamber1.PowerStatusPanel.RFPower""/>" & _
"   <Property Name=""Chamber1.SLPowerPanel.btnPBN"" 							Code=""Chamber1.PowerStatusPanel.PBNPower""/>" & _
"   <Property Name=""Chamber1.SLPowerPanel.btnNeur"" 						Code=""Chamber1.PowerStatusPanel.NeurPower""/>" & _
"  <!--ProcessRecipe -->" & _
"  <Property Name=""Chamber1.RunRecipe.btnPause"" Code=""Chamber1.ProcessRecipe.Start""/>" & _
"  <Property Name=""Chamber1.RunRecipe.btnPause Stop"" Code=""Chamber1.ProcessRecipe.Stop""/>" & _
"  <Property Name=""Chamber1.RunRecipe.btnPause Pause"" Code=""Chamber1.ProcessRecipe.Pause""/>" & _
"  <Property Name=""Chamber1.RunRecipe.btnPause Resume"" Code=""Chamber1.ProcessRecipe.Resume""/>" & _
"  <Property Name=""Chamber1.RunRecipe.btnAbort Abort"" Code=""Chamber1.ProcessRecipe.Abort""/>" & _
"  <Property Name=""Chamber1.RunRecipe.btnAbort EndCurrentStep"" Code=""Chamber1.ProcessRecipe.EndCurrentStep""/>" & _
"  " & _
"  <Property Name=""Chamber1.ForelineCGGaugesFrm.btnATM On"" Code=""Chamber1.SetATMForelineCG"" />" & _
"  <Property Name=""Chamber1.ForelineCGGaugesFrm.btnVAC On"" Code=""Chamber1.SetVACForelineCG"" />" & _
"  <Property Name=""Chamber1.RoughPumpCGGaugesFrm.btnATM On"" Code=""Chamber1.SetATMRoughPumpCG"" />" & _
"  <Property Name=""Chamber1.RoughPumpCGGaugesFrm.btnVAC On"" Code=""Chamber1.SetVACRoughPumpCG"" />" & _
"  <Property Name=""Chamber1.RoughPumpCGGaugesFrm.btnPumpOn On"" Code=""Chamber1.OpenRoughPumpPower On"" />" & _
"  <Property Name=""Chamber1.RoughPumpCGGaugesFrm.btnPumpOff On"" Code=""Chamber1.OpenRoughPumpPower Off"" />" & _
"  <Property Name=""Chamber1.PressureCGGaugesFrm.btnATM On"" Code=""Chamber1.SetATMPressureCG"" />" & _
"  <Property Name=""Chamber1.PressureCGGaugesFrm.btnVAC On"" Code=""Chamber1.SetVACPressureCG"" />" & _
"  <Property Name=""Chamber1.PressureCGGaugesFrm.btnTurnIGOn On"" Code=""Chamber1.IGStatus On"" />" & _
"  <Property Name=""Chamber1.PressureCGGaugesFrm.btnTurnIGOff On"" Code=""Chamber1.IGStatus Off"" />" & _
"  <Property Name=""Chamber1.RoughlineCGGaugesFrm.btnATM On"" Code=""Chamber1.SetATMRoughlineCG"" />" & _
"  <Property Name=""Chamber1.RoughlineCGGaugesFrm.btnVAC On"" Code=""Chamber1.SetVACRoughlineCG"" />" & _
"   <!--ChillerTemp -->" & _
"   <Property Name=""Chamber1.ChillerControl.btnChillerOnOff"" Code=""Chamber1.ChillerOnOff""/>" & _
"   <Property Name=""Chamber1.ChillerControl.txtChillerTempSP"" Code=""Chamber1.ChillerTempSP""/>  " & _
"  <!-- ====================================End Chamber1 Screen==============================================-->" & _
" 	<!-- ====================================Chamber2 Screen==============================================-->" & _
" 	<Property Name=""Chamber2.SL_PopUpPanel.btnOnline"" 												Code=""Chamber2.Online"" />" & _
"    <Property Name=""Chamber2.SL_PopUpPanel.btnOffline"" 												Code=""Chamber2.Offline"" />" & _
"	<Property Name=""Chamber2.txtGridSerialNumber"" 							Code=""Chamber2.UpdateGridSerialNumber"" />" & _
"    <Property Name=""Chamber2.txtGridID""   Code=""Chamber2.UpdateGridID"" />" & _
"	<Property Name=""Chamber2.txtSourceMinutesMaint""		    Code=""Chamber2.SetSourceUsage"" />" & _
"	<Property Name=""Chamber2.txtPBNMinutes""		    Code=""Chamber2.SetPBNMinutes"" />" & _
"	<Property Name=""Chamber2.ChillerControl.btnChillerOnOff"" Code=""Chamber2.ChillerOnOff""/>" & _
" 	   <!--Menu Cryo-->" & _
"   <Property Name=""Chamber2.SL_PopUpPanel.btnCryoOnOff"" Code=""Chamber2.CryoPower""/>" & _
"   <Property Name=""Chamber2.SL_PopUpPanel.btnCryoOff"" Code=""Chamber2.CryoPower""/>" & _
"   <Property Name=""Chamber2.SL_PopUpPanel.btnCryoRegenValve"" Code=""Chamber2.CryoRegenValve""/>" & _
"   <Property Name=""Chamber2.SL_PopUpPanel.btnCryoPurge"" Code=""Chamber2.CryoPurgeValve""/>" & _
"   <Property Name=""Chamber2.SL_PopUpPanel.btnCryoPurgeOff"" Code=""Chamber2.CryoPurgeValve""/>" & _
"   <Property Name=""Chamber2.SL_PopUpPanel.btnAutoRegen"" Code=""Chamber2.CryoAutoRegen""/>" & _
"   <Property Name=""Chamber2.SL_PopUpPanel.btnAutoRegenOff"" Code=""Chamber2.CryoAutoRegen""/>" & _
"   <Property Name=""Chamber2.SL_PopUpPanel.btnAutoPowerDown"" Code=""Chamber2.CryoAutoPowerDown""/>" & _
"   <Property Name=""Chamber2.SL_PopUpPanel.btnRoughValveOpen"" Code=""Chamber2.ValveRough""/>" & _
"   <Property Name=""Chamber2.SL_PopUpPanel.btnRoughValveClose"" Code=""Chamber2.ValveRough""/>" & _
"   <!--Menu Turbo-->" & _
"   <Property Name=""Chamber2.SL_PopUpPanel.btnWaterPumpOnOff"" Code=""Chamber2.WaterPump""/>" & _
"   <Property Name=""Chamber2.SL_PopUpPanel.btnWaterPumpOff"" Code=""Chamber2.WaterPump""/>" & _
"   <Property Name=""Chamber2.SL_PopUpPanel.btnWaterPumpRegen"" Code=""Chamber2.WaterPumpRegen""/>" & _
"   " & _
"   <!--Menu Others-->" & _
"   <Property Name=""Chamber2.SL_PopUpPanel.btnAutoVentGeneral"" 		Code=""Chamber2.AutoVent""/>" & _
"   <Property Name=""Chamber2.SL_PopUpPanel.btnAutoPumpDownGeneral"" 	Code=""Chamber2.AutoPumpDown""/>" & _
"   <Property Name=""Chamber2.SL_PopUpPanel.btnRateOfRise"" Code=""Chamber2.RaiseOfRise""/>" & _
"   <Property Name=""Chamber2.SL_PopUpPanel.btnPumpPurge"" Code=""Chamber2.PumpPurge""/>" & _
"   <Property Name=""Chamber2.SL_PopUpPanel.btnIGDegas"" Code=""Chamber2.IGDegas""/>" & _
"  <!--Shutter or Screen Machine-->" & _
"  <Property Name=""Chamber2.SLContainerBox.Shutter"" 						Code=""Chamber2.ScreenMachine""/>" & _
"  <Property Name=""Chamber2.SLContainerBox.ValveTurboHivac"" 		Code=""Chamber2.HiVacValve""/>" & _
"  <Property Name=""Chamber2.SLContainerBox.ValveCryoHivac"" 		Code=""Chamber2.ValveCryoPump""/>" & _
"  <Property Name=""Chamber2.SLContainerBox.btnWaterPumpOn"" 		Code=""Chamber2.OpenTurboPumpPower""/>" & _
"  <Property Name=""Chamber2.SLContainerBox.btnCryoOn"" 					Code=""Chamber2.CryoPower""/>" & _
"  <Property Name=""Chamber2.btnUnProtected"" 									Code=""Chamber2.FixtureUnProtected"" />" & _
"  <!--Status Panel-->" & _
"  <Property Name=""Chamber2.SLFixture.btnMotionInitialized"" 		Code=""Chamber2.MotionInitialize""/>" & _
"  <!--Source tab-->" & _
"  	<!-- BeamPowerSupply-->" & _
"  <Property Name=""Chamber2.txtBeamVoltageRight"" 					Code=""Chamber2.BeamPowerSupply.VoltageRight"" />" & _
"  <Property Name=""Chamber2.txtBeamCurrentRight"" 					Code=""Chamber2.BeamPowerSupply.CurrentRight"" />" & _
"  <Property Name=""Chamber2.btnAutoBeam"" 									Code=""Chamber2.BeamPowerSupply.AutoBeam"" />" & _
"  <Property Name=""Chamber2.btnSourceManual"" 							Code=""Chamber2.PowerStatusPanel.SourceManualPower""/>" & _
"  <Property Name=""Chamber2.btnSourceAuto"" 								Code=""Chamber2.PowerStatusPanel.SourceAutoPower""/>" & _
"  	<!--SuppressorPowerSupply-->" & _
"  <Property Name=""Chamber2.txtSuppressorVoltageRight"" 		Code=""Chamber2.SuppressorPowerSupply.VoltageRight"" />" & _
"  <Property Name=""Chamber2.txtSuppressorCurrentRight"" 		Code=""Chamber2.SuppressorPowerSupply.CurrentRight"" />" & _
"  	<!--RFPowerSupply-->" & _
"  <Property Name=""Chamber2.txtRFPowerRight"" 							Code=""Chamber2.PowerSupply.ForwardPowerRight"" />" & _
"  <Property Name=""Chamber2.txtRFReflectedRight"" 					Code=""Chamber2.PowerSupply.ReflectedPowerRight"" />" & _
"  	<!--BodyPowerSupply-->" & _
"  <Property Name=""Chamber2.txtKFactorRight"" 							Code=""Chamber2.BodyPowerSupply.KFactorRight"" />" & _
"  <Property Name=""Chamber2.txtPBNBodyRight"" 							Code="""" />" & _
"  <Property Name=""Chamber2.txtPBNDischRight"" 							Code="""" />" & _
"  	<!--Gas-->" & _
"  <Property Name=""Chamber2.txtPBNGasRight"" 								Code=""Chamber2.GasController.PBNGasRight"" />" & _
"  <Property Name=""Chamber2.txtPBNGasRight_SourceTab"" 			Code=""Chamber2.GasController.PBNGasRight_Source"" />" & _
"  " & _
"  <Property Name=""Chamber2.txtGas1Right"" 									Code=""Chamber2.GasController.Gas1Right"" />" & _
"	<Property Name=""Chamber2.txtGas1Right_SourceTab"" 				Code=""Chamber2.GasController.Gas1Right_Source"" />" & _
"  <Property Name=""Chamber2.txtGas2Right"" 									Code=""Chamber2.GasController.Gas2Right"" />" & _
"  <Property Name=""Chamber2.txtGas2Right_SourceTab"" 				Code=""Chamber2.GasController.Gas2Right_Source"" />" & _
"  <Property Name=""Chamber2.txtGas3Right"" 									Code=""Chamber2.GasController.Gas3Right"" />" & _
"  <Property Name=""Chamber2.txtGas4Right"" 									Code=""Chamber2.GasController.Gas4Right"" />" & _
"  <Property Name=""Chamber2.txtGas5Right"" 									Code=""Chamber2.GasController.Gas5Right"" />" & _
"  	<!--GasValve-->" & _
"  <Property Name=""Chamber2.ValveSupplyPBNGas"" 							Code=""Chamber2.ValveSupplyPBN""/>" & _
"  <Property Name=""Chamber2.ValveShutoffPBNGas""							Code=""Chamber2.ValvePBN"" />  " & _
"  <Property Name=""Chamber2.ValveSupplyGas1"" 							Code=""Chamber2.Gas1SupplyValve""/>" & _
"  <Property Name=""Chamber2.ValveShutoffGas1""							Code=""Chamber2.Gas1ShutOffValve"" />" & _
"  <Property Name=""Chamber2.ValveSupplyGas2"" 							Code=""Chamber2.Gas2SupplyValve""/>" & _
"  <Property Name=""Chamber2.ValveShutoffGas2""							Code=""Chamber2.Gas2ShutOffValve"" />" & _
"  <Property Name=""Chamber2.ValveSupplyGas3"" 							Code=""Chamber2.Gas3SupplyValve"" />" & _
"  <Property Name=""Chamber2.ValveShutoffGas3""							Code=""Chamber2.Gas3ShutOffValve"" />" & _
"  <Property Name=""Chamber2.ValveSupplyGas4"" 							Code=""Chamber2.Gas4SupplyValve"" />" & _
"  <Property Name=""Chamber2.ValveShutoffGas4""							Code=""Chamber2.Gas4ShutOffValve"" /> 											" & _
"  <!--Fixture tab -->" & _
"  <Property Name=""Chamber2.SLFixture.txtFlowCoolGasRight"" 				Code=""Chamber2.GasController.FlowCoolHeRight"" />" & _
"  <Property Name=""Chamber2.SLFixture.ValveShutoffFlowCoolGas"" 		Code=""Chamber2.ValveFlowCoolHe"" />" & _
"  <Property Name=""Chamber2.SLFixture.ValveSupplyFlowCoolGas"" 			Code=""Chamber2.ValveSupplyFlowCool"" />" & _
"  <Property Name=""Chamber2.SLFixture.btnClampUp"" 									Code=""Chamber2.FixtureClampStatus ClampUp""/>" & _
"  <Property Name=""Chamber2.SLFixture.btnClampDown"" 								Code=""Chamber2.FixtureClampStatus ClampDown""/>" & _
"  <Property Name=""Chamber2.mnuShutterOpen"" 							Code=""Chamber2.FixtureOpenShutter""/>" & _
"  <Property Name=""Chamber2.mnuShutterClose"" 						Code=""Chamber2.FixtureOpenShutter""/>" & _
"  <Property Name=""Chamber2.SLFixture.btnRotate"" 				Code=""Chamber2.FixtureStartRotationAxis""/>" & _
"  <Property Name=""Chamber2.SLFixture.btnFlowCoolPump"" 	Code=""Chamber2.FixturePumpPower""/>" & _
"  <Property Name=""Chamber2.mnuCoolingWater"" 						Code=""Chamber2.FixtureCoolingWater""/>" & _
"  <Property Name=""Chamber2.mnuUnProtected"" 						Code=""Chamber2.FixtureUnProtected""/>" & _
"  <Property Name=""Chamber2.SLFixture.btnShutterOpen"" 	Code=""Chamber2.FixtureOpenShutter""/>" & _
"  <Property Name=""Chamber2.SLFixture.btnShutterClose"" Code=""Chamber2.FixtureOpenShutter""/>" & _
"   	<!--TiltAngleRightFixture-->" & _
"  <Property Name=""Chamber2.SLFixture.txtTiltAngleRight"" 	Code=""Chamber2.Fixture.TiltAngle""/>" & _
"  	<!--RotationFixture-->" & _
"  <Property Name=""Chamber2.SLFixture.txtRotationStaticRight"" 	Code=""Chamber2.Fixture.Rotation Static""/>" & _
"  <Property Name=""Chamber2.SLFixture.txtRotationSweepRight"" 	Code=""Chamber2.Fixture.Rotation Sweep""/>" & _
"  <Property Name=""Chamber2.SLFixture.txtRotationContinuousRight"" 	Code=""Chamber2.Fixture.Rotation Continuous""/>" & _
"  <Property Name=""Chamber2.SLFixture.txtRotationEnd"" 	Code=""Chamber2.Fixture.RotationEnd""/>" & _
"  <Property Name=""Chamber2.SLFixture.btnMode"" Code=""Chamber2.Fixture.RotationMode""/>" & _
"  <!--Valves-->" & _
"  <Property Name=""Chamber2.ValveForeline"" 										Code=""Chamber2.ValveForeline""/>" & _
"  <Property Name=""Chamber2.ValveVent"" 												Code=""Chamber2.ValveVent""/>" & _
"  <Property Name=""Chamber2.ValveRough"" 												Code=""Chamber2.ValveRough""/>" & _
"  <Property Name=""Chamber2.SLContainerBox.btnMesaValve"" 			Code=""Chamber2.IsolationValve""/>" & _
"  <Property Name=""Chamber2.RoughPump"" 												Code=""Chamber2.OpenRoughPumpPower""/>" & _
"  <Property Name=""Chamber2.ValveFixtureWater"" 								Code=""Chamber2.ValveFixtureWater""/>" & _
"  <!--Power Panel-->" & _
"   <Property Name=""Chamber2.SLPowerPanel.btnACPower"" 					Code=""Chamber2.PowerStatusPanel.ACPower""/>" & _
"   <Property Name=""Chamber2.SLPowerPanel.btnGrid"" 						Code=""Chamber2.PowerStatusPanel.GridPower""/>" & _
"   <Property Name=""Chamber2.SLPowerPanel.btnRFPower"" 					Code=""Chamber2.PowerStatusPanel.RFPower""/>" & _
"   <Property Name=""Chamber2.SLPowerPanel.btnPBN"" 							Code=""Chamber2.PowerStatusPanel.PBNPower""/>" & _
"   <Property Name=""Chamber2.SLPowerPanel.btnNeur"" 						Code=""Chamber2.PowerStatusPanel.NeurPower""/>" & _
"  <!--ProcessRecipe -->" & _
"  <Property Name=""Chamber2.RunRecipe.btnPause"" Code=""Chamber2.ProcessRecipe.Start""/>" & _
"  <Property Name=""Chamber2.RunRecipe.btnPause Stop"" Code=""Chamber2.ProcessRecipe.Stop""/>" & _
"  <Property Name=""Chamber2.RunRecipe.btnPause Pause"" Code=""Chamber2.ProcessRecipe.Pause""/>" & _
"  <Property Name=""Chamber2.RunRecipe.btnPause Resume"" Code=""Chamber2.ProcessRecipe.Resume""/>" & _
"  <Property Name=""Chamber2.RunRecipe.btnAbort Abort"" Code=""Chamber2.ProcessRecipe.Abort""/>" & _
"  <Property Name=""Chamber2.RunRecipe.btnAbort EndCurrentStep"" Code=""Chamber2.ProcessRecipe.EndCurrentStep""/>" & _
"  <!-- CG -IG Control-->" & _
"  <Property Name=""Chamber2.ForelineCGGaugesFrm.btnATM On"" Code=""Chamber2.SetATMForelineCG"" />" & _
"  <Property Name=""Chamber2.ForelineCGGaugesFrm.btnVAC On"" Code=""Chamber2.SetVACForelineCG"" />" & _
"  <Property Name=""Chamber2.RoughPumpCGGaugesFrm.btnATM On"" Code=""Chamber2.SetATMRoughPumpCG"" />" & _
"  <Property Name=""Chamber2.RoughPumpCGGaugesFrm.btnVAC On"" Code=""Chamber2.SetVACRoughPumpCG"" />" & _
"  <Property Name=""Chamber2.RoughPumpCGGaugesFrm.btnPumpOn On"" Code=""Chamber2.OpenRoughPumpPower On"" />" & _
"  <Property Name=""Chamber2.RoughPumpCGGaugesFrm.btnPumpOff On"" Code=""Chamber2.OpenRoughPumpPower Off"" />" & _
"  <Property Name=""Chamber2.PressureCGGaugesFrm.btnATM On"" Code=""Chamber2.SetATMPressureCG"" />" & _
"  <Property Name=""Chamber2.PressureCGGaugesFrm.btnVAC On"" Code=""Chamber2.SetVACPressureCG"" />" & _
"  <Property Name=""Chamber2.PressureCGGaugesFrm.btnTurnIGOn On"" Code=""Chamber2.IGStatus On"" />" & _
"  <Property Name=""Chamber2.PressureCGGaugesFrm.btnTurnIGOff On"" Code=""Chamber2.IGStatus Off"" />" & _
"  <Property Name=""Chamber2.RoughlineCGGaugesFrm.btnATM On"" Code=""Chamber2.SetATMRoughlineCG"" />" & _
"  <Property Name=""Chamber2.RoughlineCGGaugesFrm.btnVAC On"" Code=""Chamber2.SetVACRoughlineCG"" />" & _
"  <Property Name=""Chamber2.ChillerControl.txtChillerTempSP"" Code=""Chamber2.ChillerTempSP""/>  " & _
"  <!-- ====================================End Chamber2 Screen==============================================-->" & _
"  	<!-- ====================================Chamber3 Screen==============================================-->" & _
"  	<Property Name=""Chamber3.SL_PopUpPanel.btnOnline"" 												Code=""Chamber3.Online"" />" & _
"    <Property Name=""Chamber3.SL_PopUpPanel.btnOffline"" 												Code=""Chamber3.Offline"" />" & _
"  	<Property Name=""Chamber3.txtGridSerialNumber"" 							Code=""Chamber3.UpdateGridSerialNumber"" />" & _
"    <Property Name=""Chamber3.txtGridID""   Code=""Chamber3.UpdateGridID"" />" & _
"	<Property Name=""Chamber3.txtSourceMinutesMaint""		    Code=""Chamber3.SetSourceUsage"" />" & _
"	<Property Name=""Chamber3.txtPBNMinutes""		    Code=""Chamber3.SetPBNMinutes"" />" & _
"  	   <!--Menu Cryo-->" & _
"   <Property Name=""Chamber3.SL_PopUpPanel.btnCryoOnOff"" Code=""Chamber3.CryoPower""/>" & _
"   <Property Name=""Chamber3.SL_PopUpPanel.btnCryoOff"" Code=""Chamber3.CryoPower""/>" & _
"   <Property Name=""Chamber3.SL_PopUpPanel.btnCryoRegenValve"" Code=""Chamber3.CryoRegenValve""/>" & _
"   <Property Name=""Chamber3.SL_PopUpPanel.btnCryoPurge"" Code=""Chamber3.CryoPurgeValve""/>" & _
"   <Property Name=""Chamber3.SL_PopUpPanel.btnCryoPurgeOff"" Code=""Chamber3.CryoPurgeValve""/>" & _
"   <Property Name=""Chamber3.SL_PopUpPanel.btnAutoRegen"" Code=""Chamber3.CryoAutoRegen""/>" & _
"   <Property Name=""Chamber3.SL_PopUpPanel.btnAutoRegenOff"" Code=""Chamber3.CryoAutoRegen""/>" & _
"   <Property Name=""Chamber3.SL_PopUpPanel.btnAutoPowerDown"" Code=""Chamber3.CryoAutoPowerDown""/>" & _
"   <Property Name=""Chamber3.SL_PopUpPanel.btnRoughValveOpen"" Code=""Chamber3.ValveRough""/>" & _
"   <Property Name=""Chamber3.SL_PopUpPanel.btnRoughValveClose"" Code=""Chamber3.ValveRough""/>" & _
"   <!--Menu Turbo-->" & _
"   <Property Name=""Chamber3.SL_PopUpPanel.btnWaterPumpOnOff"" Code=""Chamber3.WaterPump""/>" & _
"   <Property Name=""Chamber3.SL_PopUpPanel.btnWaterPumpOff"" Code=""Chamber3.WaterPump""/>" & _
"   <Property Name=""Chamber3.SL_PopUpPanel.btnWaterPumpRegen"" Code=""Chamber3.WaterPumpRegen""/>" & _
"   " & _
"   <!--Menu Others-->" & _
"   <Property Name=""Chamber3.SL_PopUpPanel.btnAutoVentGeneral"" 		Code=""Chamber3.AutoVent""/>" & _
"   <Property Name=""Chamber3.SL_PopUpPanel.btnAutoPumpDownGeneral"" 	Code=""Chamber3.AutoPumpDown""/>" & _
"   <Property Name=""Chamber3.SL_PopUpPanel.btnRateOfRise"" Code=""Chamber3.RaiseOfRise""/>" & _
"   <Property Name=""Chamber3.SL_PopUpPanel.btnPumpPurge"" Code=""Chamber3.PumpPurge""/>" & _
"   <Property Name=""Chamber3.SL_PopUpPanel.btnIGDegas"" Code=""Chamber3.IGDegas""/>" & _
"  <!--Shutter or Screen Machine-->" & _
"  <Property Name=""Chamber3.SLContainerBox.Shutter"" 						Code=""Chamber3.ScreenMachine""/>" & _
"  <Property Name=""Chamber3.SLContainerBox.ValveTurboHivac"" 		Code=""Chamber3.HiVacValve""/>" & _
"  <Property Name=""Chamber3.SLContainerBox.ValveCryoHivac"" 		Code=""Chamber3.ValveCryoPump""/>" & _
"  <Property Name=""Chamber3.SLContainerBox.btnWaterPumpOn"" 		Code=""Chamber3.OpenTurboPumpPower""/>" & _
"  <Property Name=""Chamber3.SLContainerBox.btnCryoOn"" 					Code=""Chamber3.CryoPower""/>" & _
"  <Property Name=""Chamber3.btnUnProtected"" 									Code=""Chamber3.FixtureUnProtected"" />" & _
"  <!--Status Panel-->" & _
"  <Property Name=""Chamber3.SLFixture.btnMotionInitialized"" 		Code=""Chamber3.MotionInitialize""/>" & _
"    <!--ChillerTemp-->" & _
"   <Property Name=""Chamber3.ChillerControl.txtChillerTempSP"" Code=""Chamber3.ChillerTempSP""/>" & _
"   <Property Name=""Chamber3.ChillerControl.btnChillerOnOff"" Code=""Chamber3.ChillerOnOff""/>" & _
"  <!--Source tab-->" & _
"  	<!-- BeamPowerSupply-->" & _
"  <Property Name=""Chamber3.txtBeamVoltageRight"" 					Code=""Chamber3.BeamPowerSupply.VoltageRight"" />" & _
"  <Property Name=""Chamber3.txtBeamCurrentRight"" 					Code=""Chamber3.BeamPowerSupply.CurrentRight"" />" & _
"  <Property Name=""Chamber3.btnAutoBeam"" 									Code=""Chamber3.BeamPowerSupply.AutoBeam"" />" & _
"  <Property Name=""Chamber3.btnSourceManual"" 							Code=""Chamber3.PowerStatusPanel.SourceManualPower""/>" & _
"  <Property Name=""Chamber3.btnSourceAuto"" 								Code=""Chamber3.PowerStatusPanel.SourceAutoPower""/>" & _
"  	<!--SuppressorPowerSupply-->" & _
"  <Property Name=""Chamber3.txtSuppressorVoltageRight"" 		Code=""Chamber3.SuppressorPowerSupply.VoltageRight"" />" & _
"  <Property Name=""Chamber3.txtSuppressorCurrentRight"" 		Code=""Chamber3.SuppressorPowerSupply.CurrentRight"" />" & _
"  	<!--RFPowerSupply-->" & _
"  <Property Name=""Chamber3.txtRFPowerRight"" 							Code=""Chamber3.PowerSupply.ForwardPowerRight"" />" & _
"  <Property Name=""Chamber3.txtRFReflectedRight"" 					Code=""Chamber3.PowerSupply.ReflectedPowerRight"" />" & _
"  	<!--BodyPowerSupply-->" & _
"  <Property Name=""Chamber3.txtKFactorRight"" 							Code=""Chamber3.BodyPowerSupply.KFactorRight"" />" & _
"  <Property Name=""Chamber3.txtPBNBodyRight"" 							Code="""" />" & _
"  <Property Name=""Chamber3.txtPBNDischRight"" 							Code="""" />" & _
"  	<!--Gas-->" & _
"  <Property Name=""Chamber3.txtPBNGasRight"" 								Code=""Chamber3.GasController.PBNGasRight"" />" & _
"  <Property Name=""Chamber3.txtPBNGasRight_SourceTab"" 			Code=""Chamber3.GasController.PBNGasRight_Source"" />" & _
"  " & _
"  <Property Name=""Chamber3.txtGas1Right"" 									Code=""Chamber3.GasController.Gas1Right"" />" & _
"	<Property Name=""Chamber3.txtGas1Right_SourceTab"" 				Code=""Chamber3.GasController.Gas1Right_Source"" />" & _
"  <Property Name=""Chamber3.txtGas2Right"" 									Code=""Chamber3.GasController.Gas2Right"" />" & _
"  <Property Name=""Chamber3.txtGas2Right_SourceTab"" 				Code=""Chamber3.GasController.Gas2Right_Source"" />" & _
"  <Property Name=""Chamber3.txtGas3Right"" 									Code=""Chamber3.GasController.Gas3Right"" />" & _
"  <Property Name=""Chamber3.txtGas4Right"" 									Code=""Chamber3.GasController.Gas4Right"" />" & _
"  <Property Name=""Chamber3.txtGas5Right"" 									Code=""Chamber3.GasController.Gas5Right"" />" & _
"  	<!--GasValve-->" & _
"  <Property Name=""Chamber3.ValveSupplyPBNGas"" 							Code=""Chamber3.ValveSupplyPBN""/>" & _
"  <Property Name=""Chamber3.ValveShutoffPBNGas""							Code=""Chamber3.ValvePBN"" />  " & _
"  <Property Name=""Chamber3.ValveSupplyGas1"" 							Code=""Chamber3.Gas1SupplyValve""/>" & _
"  <Property Name=""Chamber3.ValveShutoffGas1""							Code=""Chamber3.Gas1ShutOffValve"" />" & _
"  <Property Name=""Chamber3.ValveSupplyGas2"" 							Code=""Chamber3.Gas2SupplyValve""/>" & _
"  <Property Name=""Chamber3.ValveShutoffGas2""							Code=""Chamber3.Gas2ShutOffValve"" />" & _
"  <Property Name=""Chamber3.ValveSupplyGas3"" 							Code=""Chamber3.Gas3SupplyValve"" />" & _
"  <Property Name=""Chamber3.ValveShutoffGas3""							Code=""Chamber3.Gas3ShutOffValve"" />" & _
"  <Property Name=""Chamber3.ValveSupplyGas4"" 							Code=""Chamber3.Gas4SupplyValve"" />" & _
"  <Property Name=""Chamber3.ValveShutoffGas4""							Code=""Chamber3.Gas4ShutOffValve"" /> 											" & _
"  <!--Fixture tab -->" & _
"  <Property Name=""Chamber3.SLFixture.txtFlowCoolGasRight"" 				Code=""Chamber3.GasController.FlowCoolHeRight"" />" & _
"  <Property Name=""Chamber3.SLFixture.ValveShutoffFlowCoolGas"" 		Code=""Chamber3.ValveFlowCoolHe"" />" & _
"  <Property Name=""Chamber3.SLFixture.ValveSupplyFlowCoolGas"" 			Code=""Chamber3.ValveSupplyFlowCool"" />" & _
"  <Property Name=""Chamber3.SLFixture.btnClampUp"" 									Code=""Chamber3.FixtureClampStatus ClampUp""/>" & _
"  <Property Name=""Chamber3.SLFixture.btnClampDown"" 								Code=""Chamber3.FixtureClampStatus ClampDown""/>" & _
"  <Property Name=""Chamber3.mnuShutterOpen"" 							Code=""Chamber3.FixtureOpenShutter""/>" & _
"  <Property Name=""Chamber3.mnuShutterClose"" 						Code=""Chamber3.FixtureOpenShutter""/>" & _
"  <Property Name=""Chamber3.SLFixture.btnRotate"" 				Code=""Chamber3.FixtureStartRotationAxis""/>" & _
"  <Property Name=""Chamber3.SLFixture.btnFlowCoolPump"" 	Code=""Chamber3.FixturePumpPower""/>" & _
"  <Property Name=""Chamber3.mnuCoolingWater"" 						Code=""Chamber3.FixtureCoolingWater""/>" & _
"  <Property Name=""Chamber3.mnuUnProtected"" 						Code=""Chamber3.FixtureUnProtected""/>" & _
"  <Property Name=""Chamber3.SLFixture.btnShutterOpen"" 	Code=""Chamber3.FixtureOpenShutter""/>" & _
"  <Property Name=""Chamber3.SLFixture.btnShutterClose"" Code=""Chamber3.FixtureOpenShutter""/>" & _
"   	<!--TiltAngleRightFixture-->" & _
"  <Property Name=""Chamber3.SLFixture.txtTiltAngleRight"" 	Code=""Chamber3.Fixture.TiltAngle""/>" & _
"  	<!--RotationFixture-->" & _
"  <Property Name=""Chamber3.SLFixture.txtRotationStaticRight"" 	Code=""Chamber3.Fixture.Rotation Static""/>" & _
"  <Property Name=""Chamber3.SLFixture.txtRotationSweepRight"" 	Code=""Chamber3.Fixture.Rotation Sweep""/>" & _
"  <Property Name=""Chamber3.SLFixture.txtRotationContinuousRight"" 	Code=""Chamber3.Fixture.Rotation Continuous""/>" & _
"  <Property Name=""Chamber3.SLFixture.txtRotationEnd"" 	Code=""Chamber3.Fixture.RotationEnd""/>" & _
"  <Property Name=""Chamber3.SLFixture.btnMode"" Code=""Chamber3.Fixture.RotationMode""/>" & _
"  <!--Valves-->" & _
"  <Property Name=""Chamber3.ValveForeline"" 										Code=""Chamber3.ValveForeline""/>" & _
"  <Property Name=""Chamber3.ValveVent"" 												Code=""Chamber3.ValveVent""/>" & _
"  <Property Name=""Chamber3.ValveRough"" 												Code=""Chamber3.ValveRough""/>" & _
"  <Property Name=""Chamber3.SLContainerBox.btnMesaValve"" 			Code=""Chamber3.IsolationValve""/>" & _
"  <Property Name=""Chamber3.RoughPump"" 												Code=""Chamber3.OpenRoughPumpPower""/>" & _
"  <Property Name=""Chamber3.ValveFixtureWater"" 								Code=""Chamber3.ValveFixtureWater""/>" & _
"  <!--Power Panel-->" & _
"   <Property Name=""Chamber3.SLPowerPanel.btnACPower"" 					Code=""Chamber3.PowerStatusPanel.ACPower""/>" & _
"   <Property Name=""Chamber3.SLPowerPanel.btnGrid"" 						Code=""Chamber3.PowerStatusPanel.GridPower""/>" & _
"   <Property Name=""Chamber3.SLPowerPanel.btnRFPower"" 					Code=""Chamber3.PowerStatusPanel.RFPower""/>" & _
"   <Property Name=""Chamber3.SLPowerPanel.btnPBN"" 							Code=""Chamber3.PowerStatusPanel.PBNPower""/>" & _
"   <Property Name=""Chamber3.SLPowerPanel.btnNeur"" 						Code=""Chamber3.PowerStatusPanel.NeurPower""/>" & _
"  <!--ProcessRecipe -->" & _
"  <Property Name=""Chamber3.RunRecipe.btnPause"" Code=""Chamber3.ProcessRecipe.Start""/>" & _
"  <Property Name=""Chamber3.RunRecipe.btnPause Stop"" Code=""Chamber3.ProcessRecipe.Stop""/>" & _
"  <Property Name=""Chamber3.RunRecipe.btnPause Pause"" Code=""Chamber3.ProcessRecipe.Pause""/>" & _
"  <Property Name=""Chamber3.RunRecipe.btnPause Resume"" Code=""Chamber3.ProcessRecipe.Resume""/>" & _
"  <Property Name=""Chamber3.RunRecipe.btnAbort Abort"" Code=""Chamber3.ProcessRecipe.Abort""/>" & _
"  <Property Name=""Chamber3.RunRecipe.btnAbort EndCurrentStep"" Code=""Chamber3.ProcessRecipe.EndCurrentStep""/>" & _
"  <!-- CG -IG Control-->" & _
"  <Property Name=""Chamber3.ForelineCGGaugesFrm.btnATM On"" Code=""Chamber3.SetATMForelineCG"" />" & _
"  <Property Name=""Chamber3.ForelineCGGaugesFrm.btnVAC On"" Code=""Chamber3.SetVACForelineCG"" />" & _
"  <Property Name=""Chamber3.RoughPumpCGGaugesFrm.btnATM On"" Code=""Chamber3.SetATMRoughPumpCG"" />" & _
"  <Property Name=""Chamber3.RoughPumpCGGaugesFrm.btnVAC On"" Code=""Chamber3.SetVACRoughPumpCG"" />" & _
"  <Property Name=""Chamber3.RoughPumpCGGaugesFrm.btnPumpOn On"" Code=""Chamber3.OpenRoughPumpPower On"" />" & _
"  <Property Name=""Chamber3.RoughPumpCGGaugesFrm.btnPumpOff On"" Code=""Chamber3.OpenRoughPumpPower Off"" />" & _
"  <Property Name=""Chamber3.PressureCGGaugesFrm.btnATM On"" Code=""Chamber3.SetATMPressureCG"" />" & _
"  <Property Name=""Chamber3.PressureCGGaugesFrm.btnVAC On"" Code=""Chamber3.SetVACPressureCG"" />" & _
"  <Property Name=""Chamber3.PressureCGGaugesFrm.btnTurnIGOn On"" Code=""Chamber3.IGStatus On"" />" & _
"  <Property Name=""Chamber3.PressureCGGaugesFrm.btnTurnIGOff On"" Code=""Chamber3.IGStatus Off"" />" & _
"  <Property Name=""Chamber3.RoughlineCGGaugesFrm.btnATM On"" Code=""Chamber3.SetATMRoughlineCG"" />" & _
"  <Property Name=""Chamber3.RoughlineCGGaugesFrm.btnVAC On"" Code=""Chamber3.SetVACRoughlineCG"" />" & _
"  <!-- ====================================End Chamber3 Screen==============================================-->" & _
"</MessageNames>"
End Class
End Namespace
