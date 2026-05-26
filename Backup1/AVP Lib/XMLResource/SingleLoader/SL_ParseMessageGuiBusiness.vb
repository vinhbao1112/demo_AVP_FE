Namespace XMLResources
    Public Class SL_ParseMessageGuiBusiness
        Public Const XMLText As String = _
        "<MessageNames>" & _
        "  <!--Purpose: Mapping GUI element events to actions of Business Controllers -->" & _
        "  <!--=+=============================================Single Loader - Loader ==============================================-->" & _
        "  " & _
        "  <!--==============================Process Screen====================================-->" & _
        "	<!--Process control-->" & _
        "	<Property Name=""SL_ProcessPanel.SLProcessControl.btnRun"" 							Code=""Loader.Run"" />" & _
        "	<Property Name=""SL_ProcessPanel.SLProcessControl.btnStop"" 						Code=""Loader.Stop"" />" & _
        "	<Property Name=""SL_ProcessPanel.SLProcessControl.btnAbort"" 						Code=""Chamber1.ProcessRecipe.Stop"" />" & _
        "	<Property Name=""SL_ProcessPanel.SLProcessControl.btnContinue"" 				Code=""Chamber1.ProcessRecipe.Resume"" />" & _
        "	<Property Name=""SL_ProcessPanel.SLProcessControl.btnEndCurrentStep"" 	Code=""Chamber1.ProcessRecipe.EndCurrentStep"" />" & _
        "	<!--Robot-->" & _
        "	<Property Name=""SL_ProcessPanel.btnArmUp"" 									Code=""Loader.ArmUp"" />" & _
        "	<Property Name=""SL_ProcessPanel.btnArmDown"" 								Code=""Loader.ArmDown"" />" & _
        "	<Property Name=""SL_ProcessPanel.btnExtendArm"" 							Code=""Loader.ArmExtend"" />" & _
        "	<Property Name=""SL_ProcessPanel.btnRetractArm"" 							Code=""Loader.ArmRetract"" />" & _
        "	<Property Name=""SL_ProcessPanel.btnAutoLoad"" 								Code=""Loader.AutoLoad"" />" & _
        "	<Property Name=""SL_ProcessPanel.btnAutoUnload"" 							Code=""Loader.AutoUnload"" />" & _
        "	<!--Vacuum-->" & _
        "	<Property Name=""SL_ProcessPanel.btnOpenRoughValve"" 					Code=""Loader.RoughValve"" />" & _
        "	<Property Name=""SL_ProcessPanel.btnCloseRoughValve"" 				Code=""Loader.RoughValve"" />" & _
        "	<Property Name=""SL_ProcessPanel.btnOpenVentValve"" 					Code=""Loader.VentValve"" />" & _
        "	<Property Name=""SL_ProcessPanel.btnCloseVentValve"" 					Code=""Loader.VentValve"" />" & _
        "	<Property Name=""SL_ProcessPanel.btnOpenIsolationValve"" 			Code=""Loader.IsolationValve"" />" & _
        "	<Property Name=""SL_ProcessPanel.btnCloseIsolationValve"" 		Code=""Loader.IsolationValve"" />" & _
        "	<Property Name=""SL_ProcessPanel.btnAutoPumpDown"" 						Code=""Loader.AutoPumpDown"" />" & _
        "	<Property Name=""SL_ProcessPanel.btnAutoVent"" 								Code=""Loader.AutoVent"" />" & _
        "	<!--All valve-->" & _
        "	<Property Name=""SL_ProcessPanel.VentValve"" 									Code=""Loader.VentValve"" />" & _
        "	<Property Name=""SL_ProcessPanel.RoughValve"" 								Code=""Loader.RoughValve"" />" & _
        "	<Property Name=""SL_ProcessPanel.FlowCoolValve"" 							Code=""Loader.FlowCoolValve"" />" & _
        "	<Property Name=""SL_ProcessPanel.MesaValve"" 									Code=""Loader.IsolationValve"" />" & _
        "	<!--System control-->" & _
        "	 <Property Name=""SL_ProcessPanel.SLSystemControl.btnOnline"" 			Code=""Chamber1.Online"" />" & _
        "  <Property Name=""SL_ProcessPanel.SLSystemControl.btnOffline"" 			Code=""Chamber1.Offline"" />" & _
        "  <!--Others-->" & _
        "	<Property Name=""SL_ProcessPanel.SLProcessControl.btnCycle"" 				Code=""Loader.Cycle"" />" & _
        "	<Property Name=""SL_ProcessPanel.btnUnProtected"" 									Code="""" />" & _
        "	<Property Name=""GUI13"" 																						Code=""Loader.MechanicalPumpOn"" />" & _
        "  <Property Name=""GUI14"" 																						Code=""Loader.MechanicalPumpOff"" />" & _
        "" & _
        "  <Property Name=""SL_ProcessPanel.btnLoad"" 													Code=""Loader.Load"" />" & _
        "  <Property Name=""GUI.ProcessView.btnGeneralAbort"" 									Code=""System.GeneralAbort"" />" & _
        "  <Property Name=""SL_ProcessPanel.btnReConnect"" 										Code=""Chamber1.btnReConnect"" />" & _
        "  <Property Name=""SL_ProcessPanel.wccWaferCount.txtTotal reset"" 		Code=""Loader.ResetWaferCount"" />" & _
        " " & _
        "		" & _
        "		<!-- ====================================PM Screen==============================================-->" & _
        "  <!--Shutter or Screen Machine-->" & _
        "  <Property Name=""SL_ProcessModule.SLContainerBox.Shutter"" 						Code=""Chamber1.ScreenMachine""/>" & _
        "  <Property Name=""SL_ProcessModule.SLContainerBox.ValveTurboHivac"" 		Code=""Chamber1.HiVacValve""/>" & _
        "  <Property Name=""SL_ProcessModule.SLContainerBox.ValveCryoHivac"" 		Code=""Chamber1.ValveCryoPump""/>" & _
        "  <Property Name=""SL_ProcessModule.SLContainerBox.btnWaterPumpOn"" 		Code=""Chamber1.OpenTurboPumpPower""/>" & _
        "  <Property Name=""SL_ProcessModule.SLContainerBox.btnCryoOn"" 					Code=""Chamber1.CryoPower""/>" & _
        "  <!--Status Panel-->" & _
        "  <Property Name=""SL_ProcessModule.SLFixture.btnMotionInitialized"" 		Code=""Chamber1.MotionInitialize""/>" & _
        "  <!--Source tab-->" & _
        "  	<!-- BeamPowerSupply-->" & _
        "  <Property Name=""SL_ProcessModule.txtBeamVoltageRight"" 					Code=""Chamber1.BeamPowerSupply.VoltageRight"" />" & _
        "  <Property Name=""SL_ProcessModule.txtBeamCurrentRight"" 					Code=""Chamber1.BeamPowerSupply.CurrentRight"" />" & _
        "  <Property Name=""SL_ProcessModule.btnAutoBeam"" 									Code=""Chamber1.BeamPowerSupply.AutoBeam"" />" & _
        "  <Property Name=""SL_ProcessModule.btnSourceManual"" 							Code=""Chamber1.PowerStatusPanel.SourceManualPower""/>" & _
        "  <Property Name=""SL_ProcessModule.btnSourceAuto"" 								Code=""Chamber1.PowerStatusPanel.SourceAutoPower""/>" & _
        "  	<!--SuppressorPowerSupply-->" & _
        "  <Property Name=""SL_ProcessModule.txtSuppressorVoltageRight"" 		Code=""Chamber1.SuppressorPowerSupply.VoltageRight"" />" & _
        "  <Property Name=""SL_ProcessModule.txtSuppressorCurrentRight"" 		Code=""Chamber1.SuppressorPowerSupply.CurrentRight"" />" & _
        "  	<!--RFPowerSupply-->" & _
        "  <Property Name=""SL_ProcessModule.txtRFPowerRight"" 							Code=""Chamber1.PowerSupply.ForwardPowerRight"" />" & _
        "  <Property Name=""SL_ProcessModule.txtRFReflectedRight"" 					Code=""Chamber1.PowerSupply.ReflectedPowerRight"" />" & _
        "  	<!--BodyPowerSupply-->" & _
        "  <Property Name=""SL_ProcessModule.txtKFactorRight"" 							Code=""Chamber1.BodyPowerSupply.KFactorRight"" />" & _
        "  <Property Name=""SL_ProcessModule.txtPBNBodyRight"" 							Code="""" />" & _
        "  <Property Name=""SL_ProcessModule.txtPBNDischRight"" 							Code="""" />" & _
        "  	<!--Gas-->" & _
        "  <Property Name=""SL_ProcessModule.txtPBNGasRight"" 								Code=""Chamber1.GasController.PBNGasRight"" />" & _
        "  <Property Name=""SL_ProcessModule.txtPBNGasRight_SourceTab"" 			Code=""Chamber1.GasController.PBNGasRight"" />" & _
        "  " & _
        "  <Property Name=""SL_ProcessModule.txtGas1Right"" 									Code=""Chamber1.GasController.Gas1Right"" />" & _
        "	<Property Name=""SL_ProcessModule.txtGas1Right_SourceTab"" 				Code=""Chamber1.GasController.Gas1Right"" />" & _
        "  <Property Name=""SL_ProcessModule.txtGas2Right"" 									Code=""Chamber1.GasController.Gas2Right"" />" & _
        "  <Property Name=""SL_ProcessModule.txtGas2Right_SourceTab"" 				Code=""Chamber1.GasController.Gas2Right"" />" & _
        "  <Property Name=""SL_ProcessModule.txtGas3Right"" 									Code=""Chamber1.GasController.Gas3Right"" />" & _
        "  <Property Name=""SL_ProcessModule.txtGas4Right"" 									Code=""Chamber1.GasController.Gas4Right"" />" & _
        "  <Property Name=""SL_ProcessModule.txtGas5Right"" 									Code=""Chamber1.GasController.Gas5Right"" />" & _
        "  	<!--GasValve-->" & _
        "  <Property Name=""SL_ProcessModule.ValveSupplyPBNGas"" 							Code=""Chamber1.ValveSupplyPBN""/>" & _
        "  <Property Name=""SL_ProcessModule.ValveShutoffPBNGas""							Code=""Chamber1.ValvePBN"" />" & _
        "  " & _
        "  <Property Name=""SL_ProcessModule.ValveSupplyGas1"" 							Code=""Chamber1.Gas1SupplyValve""/>" & _
        "  <Property Name=""SL_ProcessModule.ValveShutoffGas1""							Code=""Chamber1.Gas1ShutOffValve"" />" & _
        "  <Property Name=""SL_ProcessModule.ValveSupplyGas2"" 							Code=""Chamber1.Gas2SupplyValve""/>" & _
        "  <Property Name=""SL_ProcessModule.ValveShutoffGas2""							Code=""Chamber1.Gas2ShutOffValve"" />" & _
        "  <Property Name=""SL_ProcessModule.ValveSupplyGas3"" 							Code=""Chamber1.Gas3SupplyValve"" />" & _
        "  <Property Name=""SL_ProcessModule.ValveShutoffGas3""							Code=""Chamber1.Gas3ShutOffValve"" />" & _
        "  <Property Name=""SL_ProcessModule.ValveSupplyGas4"" 							Code=""Chamber1.Gas4SupplyValve"" />" & _
        "  <Property Name=""SL_ProcessModule.ValveShutoffGas4""							Code=""Chamber1.Gas4ShutOffValve"" /> 											" & _
        "  <!--Fixture tab -->" & _
        "  <Property Name=""SL_ProcessModule.SLFixture.txtFlowCoolGasRight"" 				Code=""Chamber1.GasController.FlowCoolHeRight"" />" & _
        "  <Property Name=""SL_ProcessModule.SLFixture.ValveShutoffFlowCoolGas"" 		Code=""Chamber1.ValveFlowCoolHe"" />" & _
        "  <Property Name=""SL_ProcessModule.SLFixture.ValveSupplyFlowCoolGas"" 			Code=""Chamber1.ValveSupplyFlowCool"" />" & _
        "  <Property Name=""SL_ProcessModule.SLFixture.btnClampUp"" 									Code=""Chamber1.FixtureClampStatus ClampUp""/>" & _
        "  <Property Name=""SL_ProcessModule.SLFixture.btnClampDown"" 								Code=""Chamber1.FixtureClampStatus ClampDown""/>" & _
        "  <Property Name=""SL_ProcessModule.mnuShutterOpen"" 							Code=""Chamber1.FixtureOpenShutter""/>" & _
        "  <Property Name=""SL_ProcessModule.mnuShutterClose"" 						Code=""Chamber1.FixtureOpenShutter""/>" & _
        "  <Property Name=""SL_ProcessModule.SLFixture.btnRotate"" 				Code=""Chamber1.FixtureStartRotationAxis""/>" & _
        "  <Property Name=""SL_ProcessModule.SLFixture.btnFlowCoolPump"" 	Code=""Chamber1.FixturePumpPower""/>" & _
        "  <Property Name=""SL_ProcessModule.mnuCoolingWater"" 						Code=""Chamber1.FixtureCoolingWater""/>" & _
        "  <Property Name=""SL_ProcessModule.mnuUnProtected"" 						Code=""Chamber1.FixtureUnProtected""/>" & _
        "  <Property Name=""SL_ProcessModule.SLFixture.btnShutterOpen"" 	Code=""Chamber1.FixtureOpenShutter""/>" & _
        "  <Property Name=""SL_ProcessModule.SLFixture.btnShutterClose"" Code=""Chamber1.FixtureOpenShutter""/>" & _
        "   	<!--TiltAngleRightFixture-->" & _
        "  <Property Name=""SL_ProcessModule.SLFixture.txtTiltAngleRight"" 	Code=""Chamber1.Fixture.TiltAngle""/>" & _
        "  	<!--RotationFixture-->" & _
        "  <Property Name=""SL_ProcessModule.SLFixture.txtRotationStaticRight"" 	Code=""Chamber1.Fixture.Rotation Static""/>" & _
        "  <Property Name=""SL_ProcessModule.SLFixture.txtRotationSweepRight"" 	Code=""Chamber1.Fixture.Rotation Sweep""/>" & _
        "  <Property Name=""SL_ProcessModule.SLFixture.txtRotationContinuousRight"" 	Code=""Chamber1.Fixture.Rotation Continuous""/>" & _
        "  <Property Name=""SL_ProcessModule.SLFixture.txtRotationEnd"" 	Code=""Chamber1.Fixture.RotationEnd""/>" & _
        "  <Property Name=""SL_ProcessModule.SLFixture.btnMode"" Code=""Chamber1.Fixture.RotationMode""/>" & _
        "  <!--Valves-->" & _
        "  <Property Name=""SL_ProcessModule.ValveForeline"" 										Code=""Chamber1.ValveForeline""/>" & _
        "  <Property Name=""SL_ProcessModule.ValveVent"" 												Code=""Chamber1.ValveVent""/>" & _
        "  <Property Name=""SL_ProcessModule.ValveRough"" 												Code=""Chamber1.ValveRough""/>" & _
        "  <Property Name=""SL_ProcessModule.SLContainerBox.btnMesaValve"" 			Code=""Loader.IsolationValve""/>" & _
        "  <Property Name=""SL_ProcessModule.RoughPump"" 												Code=""Chamber1.OpenRoughPumpPower""/>" & _
        "  <Property Name=""SL_ProcessModule.ValveFixtureWater"" 								Code=""Chamber1.ValveFixtureWater""/>" & _
        "  <!--Power Panel-->" & _
        "   <Property Name=""SL_ProcessModule.SLPowerPanel.btnACPower"" 					Code=""Chamber1.PowerStatusPanel.ACPower""/>" & _
        "   <Property Name=""SL_ProcessModule.SLPowerPanel.btnGrid"" 						Code=""Chamber1.PowerStatusPanel.GridPower""/>" & _
        "   <Property Name=""SL_ProcessModule.SLPowerPanel.btnRFPower"" 					Code=""Chamber1.PowerStatusPanel.RFPower""/>" & _
        "   <Property Name=""SL_ProcessModule.SLPowerPanel.btnPBN"" 							Code=""Chamber1.PowerStatusPanel.PBNPower""/>" & _
        "   <Property Name=""SL_ProcessModule.SLPowerPanel.btnNeur"" 						Code=""Chamber1.PowerStatusPanel.NeurPower""/>" & _
        "   " & _
        "   <!--Menu Cryo-->" & _
        "   <Property Name=""SL_PopUpPanel.btnCryoOnOff"" Code=""Chamber1.CryoPower""/>" & _
        "   <Property Name=""SL_PopUpPanel.btnCryoRegenValve"" Code=""Chamber1.CryoRegenValve""/>" & _
        "   <Property Name=""SL_PopUpPanel.btnCryoPurge"" Code=""Chamber1.CryoPurgeValve""/>" & _
        "   <Property Name=""SL_PopUpPanel.btnAutoRegen"" Code=""Chamber1.CryoAutoRegen""/>" & _
        "   <Property Name=""SL_PopUpPanel.btnAutoPowerDown"" Code=""Chamber1.CryoAutoPowerDown""/>" & _
        "   " & _
        "   <!--Menu Turbo-->" & _
        "   <Property Name=""SL_PopUpPanel.btnWaterPumpOnOff"" Code=""Chamber1.WaterPump""/>" & _
        "   <Property Name=""SL_PopUpPanel.btnWaterPumpRegen"" Code=""Chamber1.WaterPumpRegen""/>" & _
        "   " & _
        "   <!--Menu Others-->" & _
        "   <Property Name=""SL_PopUpPanel.btnAutoVentGeneral"" 		Code=""Chamber1.AutoVent""/>" & _
        "   <Property Name=""SL_PopUpPanel.btnAutoPumpDownGeneral"" 	Code=""Chamber1.AutoPumpDown""/>" & _
        "   <Property Name=""SL_PopUpPanel.btnRateOfRise"" Code=""Chamber1.RaiseOfRise""/>" & _
        "   " & _
        "   <!--ProcessRecipe -->" & _
        "  <Property Name=""SL_ProcessModule.SLRunRecipe.btnPause"" Code=""Chamber1.ProcessRecipe.Start""/>" & _
        "  <Property Name=""SL_ProcessModule.SLRunRecipe.btnPause Stop"" Code=""Chamber1.ProcessRecipe.Stop""/>" & _
        "  <Property Name=""SL_ProcessModule.SLRunRecipe.btnPause Pause"" Code=""Chamber1.ProcessRecipe.Pause""/>" & _
        "  <Property Name=""SL_ProcessModule.SLRunRecipe.btnPause Resume"" Code=""Chamber1.ProcessRecipe.Resume""/>" & _
        "  <Property Name=""SL_ProcessModule.SLRunRecipe.btnAbort Abort"" Code=""Chamber1.ProcessRecipe.Abort""/>" & _
        "  <Property Name=""SL_ProcessModule.SLRunRecipe.btnAbort EndCurrentStep"" Code=""Chamber1.ProcessRecipe.EndCurrentStep""/>" & _
        "  <!--end PM Screen -->" & _
        "  <!--System Setup Screen-->" & _
        "  <Property Name=""SL_SystemSetup.btnResetSourceUsage"" Code=""Chamber1.ResetSourceUsage""/>" & _
        "  <!--end hoa nguyen add-->" & _
        " " & _
        " " & _
        "  <!--===================================================Chamber1=============================================================-->" & _
        "  <!--PowerSupply-->" & _
        "  <Property Name=""Chamber1.rfpwRFPowerSupply.txtForwardPowerRight"" Code=""Chamber1.PowerSupply.ForwardPowerRight""/>     <!--r-->" & _
        "  <Property Name=""Chamber1.rfpwRFPowerSupply.txtReflectedPowerRight"" Code=""Chamber1.PowerSupply.ReflectedPowerRight""/> <!--r-->" & _
        "  <!--BeamPowerSupply-->" & _
        "  <Property Name=""Chamber1.spsBeamPowerSupply.txtVoltageRight"" Code=""Chamber1.BeamPowerSupply.VoltageRight""/> <!--r-->" & _
        "  <Property Name=""Chamber1.spsBeamPowerSupply.txtCurrentRight"" Code=""Chamber1.BeamPowerSupply.CurrentRight""/>  <!--r-->" & _
        "   <Property Name=""Chamber1.spsBeamPowerSupply.btnAutoBeam"" Code=""Chamber1.BeamPowerSupply.AutoBeam""/>         <!--r-->" & _
        "  <Property Name=""Chamber1.spsBeamPowerSupply.btnAutoBeam On"" Code=""Chamber1.BeamPowerSupply.AutoBeam On""/>    <!--r-->" & _
        "  <!--SuppressorPowerSupply-->" & _
        "  <Property Name=""Chamber1.spsSuppressorPowerSupply.txtVoltageRight"" Code=""Chamber1.SuppressorPowerSupply.VoltageRight""/> <!--r-->" & _
        "  <Property Name=""Chamber1.spsSuppressorPowerSupply.txtCurrentRight"" Code=""Chamber1.SuppressorPowerSupply.CurrentRight""/> <!--r-->" & _
        "    <!--BodyPowerSupply-->" & _
        "    <Property Name=""Chamber1.dpsBodyPowerSupply.txtKFactorRight"" Code=""Chamber1.BodyPowerSupply.KFactorRight""/> <!--r-->" & _
        "" & _
        "   <!--Wafer In Fixture x-->" & _
        "  <Property Name=""Chamber1.FixtureControl On"" Code=""Chamber1.FixtureControl On""/>        <!--r-->" & _
        "  <Property Name=""Chamber1.FixtureControl Off"" Code=""Chamber1.FixtureControl Off""/>      <!--r-->" & _
        "  <!--ValveWaterPump x-->" & _
        "  <Property Name=""Chamber1.ValveWaterPump On"" Code=""Chamber1.ValveWaterPump On""/>				<!--r-->" & _
        "  <Property Name=""Chamber1.ValveWaterPump Off"" Code=""Chamber1.ValveWaterPump Off""/>			<!--r-->" & _
        "  <!--ValveSupplyArgon-->" & _
        "  <Property Name=""Chamber1.ValveSupplyArgon On"" Code=""Chamber1.ValveSupplyArgon On""/>       <!--r-->" & _
        "  <Property Name=""Chamber1.ValveSupplyArgon Off"" Code=""Chamber1.ValveSupplyArgon Off""/>    <!--r-->" & _
        "  <!--ValveSupplyPBN-->" & _
        "  <Property Name=""Chamber1.ValveSupplyPBN On"" Code=""Chamber1.ValveSupplyPBN On""/>        <!--r-->" & _
        "  <Property Name=""Chamber1.ValveSupplyPBN Off"" Code=""Chamber1.ValveSupplyPBN Off""/>      <!--r-->" & _
        "  <!--ValveSupplyFlowCoolHe-->" & _
        "  <Property Name=""Chamber1.ValveSupplyFlowCoolHe On"" Code=""Chamber1.ValveSupplyFlowCool On""/>          <!--r-->" & _
        "  <Property Name=""Chamber1.ValveSupplyFlowCoolHe Off"" Code=""Chamber1.ValveSupplyFlowCool Off""/>        <!--r-->" & _
        "  <!--ValveCryoPump-->" & _
        "  <Property Name=""Chamber1.ValveControlCryoPump On"" Code=""Chamber1.ValveCryoPump On""/>" & _
        "  <Property Name=""Chamber1.ValveControlCryoPump Off"" Code=""Chamber1.ValveCryoPump Off""/>" & _
        "    <!--Shutter or Screen Machine-->" & _
        "  <Property Name=""Chamber1.ScreenMachine On"" Code=""Chamber1.ScreenMachine On""/>					<!--r-->" & _
        "  <Property Name=""Chamber1.ScreenMachine Off"" Code=""Chamber1.ScreenMachine Off""/>				<!--r-->" & _
        "  <Property Name=""Chamber1.ScreenMachine Others"" Code=""Chamber1.ScreenMachine Others""/>	<!--r-->" & _
        "  <!--ForelineValve-->" & _
        "  <Property Name=""Chamber1.ValveControlForeline On"" Code=""Chamber1.ValveForeline On""/>		<!--r-->" & _
        "  <Property Name=""Chamber1.ValveControlForeline Off"" Code=""Chamber1.ValveForeline Off""/>		<!--r-->" & _
        "  <!--HivacValve-->" & _
        "  <Property Name=""Chamber1.ValveRingControl On"" Code=""Chamber1.HiVacValve On""/>						<!--r-->" & _
        "  <Property Name=""Chamber1.ValveRingControl Off"" Code=""Chamber1.HiVacValve Off""/>					<!--r-->" & _
        "  <!--RoughValve-->" & _
        "  <Property Name=""Chamber1.ValveControlRough On"" Code=""Chamber1.ValveRough On""/>					<!--r-->" & _
        "  <Property Name=""Chamber1.ValveControlRough Off"" Code=""Chamber1.ValveRough Off""/>				<!--r-->" & _
        "   <!--RoughPumpValve-->" & _
        "  <Property Name=""Chamber1.ticGasPump On"" Code=""Chamber1.OpenRoughPumpPower On""/>         <!--r-->" & _
        "  <Property Name=""Chamber1.ticGasPump Off"" Code=""Chamber1.OpenRoughPumpPower Off""/>       <!--r-->" & _
        "  <!-- Baratron -->" & _
        "  <Property Name=""Chamber1.BaCenterControl.txtCG2"" Code=""Chamber1.BACenterControl.CG2""/>" & _
        "  <Property Name=""Chamber1.BaCenterControl.bigcgIG On"" Code=""Chamber1.BACenterControl.OpenIG""/>" & _
        "  <Property Name=""Chamber1.BaCenterControl.bigcgIG Off"" Code=""Chamber1.BACenterControl.CloseIG""/>" & _
        "  <!--TiltAngleRightFixture-->" & _
        "  <Property Name=""Chamber1.ftcFixtureControlContinuous.txtTiltAngleRight"" Code=""Chamber1.Fixture.ContinuousTiltAngle""/> <!--r-->" & _
        "  <Property Name=""Chamber1.ftcFixtureControlStatic.txtTiltAngleRight"" Code=""Chamber1.Fixture.StaticTiltAngle""/>         <!--r-->" & _
        "  <Property Name=""Chamber1.ftcFixtureControlSweep.txtTiltAngleRight"" Code=""Chamber1.Fixture.SweepTiltAngle""/>				<!--r-->" & _
        "  <!--RotationFixture-->" & _
        "  <Property Name=""Chamber1.ftcFixtureControlContinuous.txtRotationRight"" Code=""Chamber1.Fixture.ContinuousRotation""/> <!--r-->" & _
        "  <Property Name=""Chamber1.ftcFixtureControlStatic.txtRotationRight"" Code=""Chamber1.Fixture.StaticRotation""/>						<!--r-->" & _
        "  <Property Name=""Chamber1.ftcFixtureControlSweep.txtRotationRight"" Code=""Chamber1.Fixture.SweepRotation""/>							<!--r-->" & _
        "  <!--RotationLastRightFixture-->" & _
        "  <Property Name=""Chamber1.ftcFixtureControlContinuous.txtRotationLastRight"" Code=""Chamber1.Fixture.ContinuousRotationLast""/> <!--r-->" & _
        "  <Property Name=""Chamber1.ftcFixtureControlStatic.txtRotationLastRight"" Code=""Chamber1.Fixture.StaticRotationLast""/>         <!--r-->" & _
        "  <Property Name=""Chamber1.ftcFixtureControlSweep.txtRotationLastRight"" Code=""Chamber1.Fixture.SweepRotationLast""/>           <!--r-->" & _
        "  " & _
        "  <!--FixtureMenu-->" & _
        "  <Property Name=""Chamber1.mnuFixtureOnClamp ClampUp"" Code=""Chamber1.FixtureClampStatus ClampUp""/>      <!--r-->" & _
        "  <Property Name=""Chamber1.mnuFixtureOnClamp ClampDown"" Code=""Chamber1.FixtureClampStatus ClampDown""/>  <!--r-->" & _
        "  <Property Name=""Chamber1.mnuFixtureHomeTiltAxis"" Code=""Chamber1.FixtureHomeTiltAxis""/>" & _
        "  <Property Name=""Chamber1.mnuFixtureHomeRotationAxis"" Code=""Chamber1.FixtureHomeRotationAxis""/>" & _
        "  <Property Name=""Chamber1.mnuFixtureStartRotationAxis"" Code=""Chamber1.Fixture.RotationMode""/>" & _
        "  <Property Name=""Chamber1.mnuFixtureHomeAllAxis On"" Code=""Chamber1.FixtureHomeAllAxis""/>" & _
        "  <Property Name=""Chamber1.mnuFixtureStopAllAxis On"" Code=""Chamber1.FixtureStopAllAxis""/>" & _
        "  <Property Name=""Chamber1.mnuFixtureOpenShutter On"" Code=""Chamber1.FixtureOpenShutter On""/>        <!--r-->" & _
        "  <Property Name=""Chamber1.mnuFixtureOpenShutter Off"" Code=""Chamber1.FixtureOpenShutter Off""/>      <!--r-->" & _
        "  " & _
        "  <Property Name=""Chamber1.mnuFixtureOpenWaterValve On"" Code=""Chamber1.FixtureWaterValveStatus On""/>" & _
        "  <Property Name=""Chamber1.mnuFixtureOpenWaterValve Off"" Code=""Chamber1.FixtureWaterValveStatus Off""/>" & _
        "  <Property Name=""Chamber1.mnuFixtureOpenFlowCool On"" Code=""Chamber1.FixtureFlowCoolPumpStatus On""/>" & _
        "  <Property Name=""Chamber1.mnuFixtureOpenFlowCool Off"" Code=""Chamber1.FixtureFlowCoolPumpStatus Off""/>" & _
        "  " & _
        "  <Property Name=""Chamber1.btnReConnect On"" Code=""Chamber1.btnReConnect On""/><!--r-->" & _
        "  <Property Name=""Chamber1.btnReConnect Off"" Code=""Chamber1.btnReConnect Off""/><!--r-->" & _
        "  <!--MesaValve-->" & _
        "  <Property Name=""Chamber1.ValveControlMesa On"" Code=""Chamber1.ValveControlMesa On""/>    <!--r-->" & _
        "  <Property Name=""Chamber1.ValveControlMesa Off"" Code=""Chamber1.ValveControlMesa Off""/>	 <!--r-->" & _
        "  <!--VentValve-->" & _
        "  <Property Name=""Chamber1.ValveControlVent On"" Code=""Chamber1.ValveVent On""/>			<!--r-->" & _
        "  <Property Name=""Chamber1.ValveControlVent Off"" Code=""Chamber1.ValveVent Off""/>		<!--r-->" & _
        "  <!--BaratronValve-->" & _
        "  <Property Name=""Chamber1.ValveControlBaratron On"" Code=""Chamber1.ValveBaratron On""/>" & _
        "  <Property Name=""Chamber1.ValveControlBaratron Off"" Code=""Chamber1.ValveBaratron Off""/>" & _
        "  <!--FlowCoolHeValve-->" & _
        "  <Property Name=""Chamber1.ValveControlFlowCoolHe On"" Code=""Chamber1.ValveFlowCoolHe On""/>		<!--r-->" & _
        "  <Property Name=""Chamber1.ValveControlFlowCoolHe Off"" Code=""Chamber1.ValveFlowCoolHe Off""/><!--r-->" & _
        "  <!--PBNValve-->" & _
        "  <Property Name=""Chamber1.ValveControlPBN On"" Code=""Chamber1.ValvePBN On""/><!--r-->" & _
        "  <Property Name=""Chamber1.ValveControlPBN Off"" Code=""Chamber1.ValvePBN Off""/><!--r-->" & _
        "  <!--ArgonValve-->" & _
        "  <Property Name=""Chamber1.ValveControlArgon On"" Code=""Chamber1.ValveArgon On""/><!--r-->" & _
        "  <Property Name=""Chamber1.ValveControlArgon Off"" Code=""Chamber1.ValveArgon Off""/><!--r-->" & _
        "  <!--GasController -->" & _
        "  <Property Name=""Chamber1.gccGasController.txtArgonRight"" Code=""Chamber1.GasController.ArgonRight""/>         <!--r-->" & _
        "  <Property Name=""Chamber1.gccGasController.txtPBNRight"" Code=""Chamber1.GasController.PBNRight""/>               <!--r-->" & _
        "  <Property Name=""Chamber1.gccGasController.txtFlowCoolHeRight"" Code=""Chamber1.GasController.FlowCoolHeRight""/> <!--r-->" & _
        "  " & _
        "  " & _
        "  " & _
        "  <!--MachineMenu-->" & _
        "  <Property Name=""Chamber1.mnuMachineOnline On"" Code=""Chamber1.Online""/><!--r-->" & _
        "  <Property Name=""Chamber1.mnuMachineOnline Off"" Code=""Chamber1.Offline""/><!--r-->" & _
        "  <Property Name=""Chamber1.mnuMachinePumpDown On"" Code=""Chamber1.PumpDown""/><!--r-->" & _
        "  <Property Name=""Chamber1.mnuMachinePumpDown Off"" Code=""Chamber1.StopPumpDown""/><!--r-->" & _
        "  <Property Name=""Chamber1.mnuMachineVent On"" Code=""Chamber1.Vent""/><!--r-->" & _
        "  <Property Name=""Chamber1.mnuMachineVent Off"" Code=""Chamber1.StopVent""/><!--r-->" & _
        "  <Property Name=""Chamber1.mnuMachineCryoOn On"" Code=""Chamber1.TurnCryo On""/>" & _
        "  <Property Name=""Chamber1.mnuMachineCryoOn Off"" Code=""Chamber1.TurnCryo Off""/>" & _
        "  <Property Name=""Chamber1.mnuMachineCryoPumpRegen On"" Code=""Chamber1.CryoPumpRegen""/>" & _
        "  <Property Name=""Chamber1.mnuMachineCryoPumpRegen Off"" Code=""Chamber1.CryoPumpRegen""/>" & _
        "  <Property Name=""Chamber1.mnuMachineCryoAutoRegen On"" Code=""Chamber1.CryoAutoRegen""/>" & _
        "  <Property Name=""Chamber1.mnuMachineCryoAutoRegen Off"" Code=""Chamber1.CryoAutoRegen""/>" & _
        "  " & _
        "  <!--Power Status Panel-->" & _
        "  <Property Name=""Chamber1.PowerStatusPanel.btnACPower Off"" Code=""Chamber1.PowerStatusPanel.ACPower Off""/><!--r-->" & _
        "  <Property Name=""Chamber1.PowerStatusPanel.btnACPower On"" Code=""Chamber1.PowerStatusPanel.ACPower On""/><!--r-->" & _
        "  <Property Name=""Chamber1.PowerStatusPanel.btnGrid Off"" Code=""Chamber1.PowerStatusPanel.GridPower Off""/><!--r-->" & _
        "  <Property Name=""Chamber1.PowerStatusPanel.btnGrid On"" Code=""Chamber1.PowerStatusPanel.GridPower On""/><!--r-->" & _
        "  <Property Name=""Chamber1.PowerStatusPanel.btnRFPower Off"" Code=""Chamber1.PowerStatusPanel.RFPower Off""/><!--r-->" & _
        "  <Property Name=""Chamber1.PowerStatusPanel.btnRFPower On"" Code=""Chamber1.PowerStatusPanel.RFPower On""/><!--r-->" & _
        "  <Property Name=""Chamber1.PowerStatusPanel.btnPBNPower Off"" Code=""Chamber1.PowerStatusPanel.PBNPower Off""/><!--r-->" & _
        "  <Property Name=""Chamber1.PowerStatusPanel.btnPBNPower On"" Code=""Chamber1.PowerStatusPanel.PBNPower On""/><!--r-->" & _
        "</MessageNames>"
    End Class
End Namespace
