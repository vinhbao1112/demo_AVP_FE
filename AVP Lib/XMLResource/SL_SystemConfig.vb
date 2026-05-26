Namespace XMLResources
    Public Class SL_SystemConfig
Public Const XMLText as String = _
"<SystemConfiguration>" & _
"  <ToolID>ABC</ToolID>" & _
"  <SystemTimeout>" & _
"    <Property Name=""Loader"" Timeout=""30000"" />" & _
"    <Property Name=""LoaderRequestStatus"" Timeout=""5000"" />" & _
"  </SystemTimeout>" & _
"  <SystemPolling>" & _
"    <Property Name=""Loader"" Timeout=""200"" IsLog=""False"" />" & _
"    <Property Name=""PVDStatusReport"" Timeout=""200"" IsLog=""False"" />" & _
"  </SystemPolling>  " & _
"  <Robot>" & _
"    <Module>" & _
"      <Name>Chamber1</Name>" & _
"      <Description>PM1</Description>" & _
"      <StationLocation>2</StationLocation>" & _
"      <SubSystemList>" & _
"        <SubSystem>" & _
"          <Name>Real_Device_Enable</Name>" & _
"          <Value>0</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>TargetKWHWarningLimit</Name>" & _
"          <Value>10</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>SourceUsage</Name>" & _
"          <Value>170</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>TargetKWHAlarmLimit</Name>" & _
"          <Value>20</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Target_Material</Name>" & _
"          <Value>12</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Shutter_Visible</Name>" & _
"          <Value>1</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>MG</Name>" & _
"          <IsPresent>1</IsPresent>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>CG</Name>" & _
"          <IsPresent>1</IsPresent>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>DCTargetPowerSupply</Name>" & _
"          <IsPresent>0</IsPresent>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>RFTargetPowerSupply</Name>" & _
"          <IsPresent>1</IsPresent>" & _
"          <SysVal>" & _
"            <Preset id=""1"" C1=""10.1"" C2=""10.6"" />" & _
"            <Preset id=""2"" C1=""10.2"" C2=""10.6"" />" & _
"            <Preset id=""3"" C1=""10.3"" C2=""10.6"" />" & _
"            <Preset id=""4"" C1=""10.4"" C2=""10.6"" />" & _
"            <Preset id=""5"" C1=""10.5"" C2=""10.6"" />" & _
"            <Preset id=""6"" C1=""10.6"" C2=""10.6"" />" & _
"            <Preset id=""7"" C1=""10.7"" C2=""10.6"" />" & _
"            <Preset id=""8"" C1=""10.8"" C2=""10.6"" />" & _
"            <Preset id=""9"" C1=""10.9"" C2=""10.6"" />" & _
"          </SysVal>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>BiasPowerSupply</Name>" & _
"          <IsPresent>1</IsPresent>" & _
"          <SysVal>" & _
"            <Preset id=""1"" C1=""10.1"" C2=""10.6"" />" & _
"            <Preset id=""2"" C1=""10.2"" C2=""10.6"" />" & _
"            <Preset id=""3"" C1=""10.3"" C2=""10.6"" />" & _
"            <Preset id=""4"" C1=""10.4"" C2=""10.6"" />" & _
"            <Preset id=""5"" C1=""10.5"" C2=""10.6"" />" & _
"            <Preset id=""6"" C1=""10.6"" C2=""10.6"" />" & _
"            <Preset id=""7"" C1=""10.7"" C2=""10.6"" />" & _
"            <Preset id=""8"" C1=""10.8"" C2=""10.6"" />" & _
"            <Preset id=""9"" C1=""10.9"" C2=""10.6"" />" & _
"          </SysVal>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>ParallelMagnet</Name>" & _
"          <IsPresent>1</IsPresent>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>ChamberInterlock</Name>" & _
"          <TurboWater_Installed>0</TurboWater_Installed>" & _
"          <TurboForeline_Installed>1</TurboForeline_Installed>" & _
"          <TableWater_Installed>0</TableWater_Installed>" & _
"          <ChamberLid_Installed>1</ChamberLid_Installed>" & _
"          <MatchWater_Installed>0</MatchWater_Installed>" & _
"          <TargetWater_Installed>1</TargetWater_Installed>" & _
"          <LidWater_Installed>1</LidWater_Installed>" & _
"          <SubMBWater_Installed>1</SubMBWater_Installed>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>PumpingPackage</Name>" & _
"          <CryoIsPresent>0</CryoIsPresent>" & _
"          <TurboPumpIsPresent>1</TurboPumpIsPresent>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>VatValveController</Name>" & _
"          <IsPresent>0</IsPresent>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Clamp_Installed</Name>" & _
"          <IsPresent>1</IsPresent>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>GasController</Name>" & _
"          <IsPresent>1</IsPresent>" & _
"          <SysVar>" & _
"            <Gas1 Name=""Argon"" IsShutoffPresent=""0"" IsSupplyPresent=""1"" />" & _
"            <Gas2 Name=""He"" IsShutoffPresent=""0"" IsSupplyPresent=""1"" />" & _
"            <Gas3 Name=""Oxygen"" IsShutoffPresent=""0"" IsSupplyPresent=""1"" />" & _
"            <Gas4 Name=""Nitrogen"" IsShutoffPresent=""0"" IsSupplyPresent=""1"" />" & _
"            <Gas5 Name=""Back Side"" IsShutoffPresent=""0"" IsSupplyPresent=""1"" />" & _
"          </SysVar>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Magnatron</Name>" & _
"          <IsPresent>1</IsPresent>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>AutoZero</Name>" & _
"          <IsPresent>1</IsPresent>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>ProcessMonitor</Name>" & _
"          <IsPresent>1</IsPresent>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>RunRecipe</Name>" & _
"          <IsPresent>1</IsPresent>" & _
"        </SubSystem>" & _
"      </SubSystemList>" & _
"    </Module>" & _
"    <Configure>" & _
"      <Key>PVD.RoughPumpCG</Key>" & _
"      <Value>200</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>DeltaPickNeeded</Key>" & _
"      <Value>0</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>DeltaPickStation</Key>" & _
"      <Value>8</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>DeltaPickMaxEccentricity</Key>" & _
"      <Value>1250</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>DeltaPickMaxRetry</Key>" & _
"      <Value>3</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>CJprocessing_order</Key>" & _
"      <Value>1</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>PJprocessing_order</Key>" & _
"      <Value>1</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>AlignerCDDPosition</Key>" & _
"      <Value>900</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>TransferSetPointWaitTimeInSeconds</Key>" & _
"      <Value>3600</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>OpenShutterWaitTimeInSeconds</Key>" & _
"      <Value>30</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>MovingChuckToZeroWaitTimeInSeconds</Key>" & _
"      <Value>30</Value>" & _
"    </Configure>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.WarningKWH.Max</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.WarningKWH.Min</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.LimitKWH.Max</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.LimitKWH.Min</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CheckSensorBeforePick</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <Configure>" & _
"      <Key>Robot_Retracted_Lower_Bound</Key>" & _
"      <Value>250000</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>Robot_Retracted_Upper_Bound</Key>" & _
"      <Value>664000</Value>" & _
"    </Configure>" & _
"    <MessageText>" & _
"      <Key>LogLowLevelMessages</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtBeamVoltageRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtBeamVoltageRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtBeamCurrentRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtBeamCurrentRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtSuppressorVoltageRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtSuppressorVoltageRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtSuppressorCurrentRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtSuppressorCurrentRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtRFPowerRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtRFPowerRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtRFReflectedRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtRFReflectedRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtPBNGasRight_SourceTabMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtPBNGasRight_SourceTabMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtGas1Right_SourceTabMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtGas1Right_SourceTabMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtGas2Right_SourceTabMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtGas2Right_SourceTabMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtKFactorRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtKFactorRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtPBNBodyRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtPBNBodyRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtPBNDischRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtPBNDischRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtPBNGasRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtPBNGasRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtGas1RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtGas1RightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtGas2RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtGas2RightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtGas3RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtGas3RightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtFlowCoolGasRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtFlowCoolGasRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtRotationEndMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtRotationEndMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtTiltAngleRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtTiltAngleRightMax</Key>" & _
"      <Value>360</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtRotationStaticRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtRotationStaticRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtRotationSweepRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtRotationSweepRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtRotationContinuousRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtRotationContinuousRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtSourceUsageMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtSourceUsageMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"  </Robot>" & _
"  <SystemPressure>" & _
"    <Configure>" & _
"      <Key>CassettesModule</Key>" & _
"      <Value>2</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>LoadLockA</Key>" & _
"      <Value>2</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>Chamber1</Key>" & _
"      <Value>200</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>IBEMaintainance</Key>" & _
"      <Value>1.23</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>CG_Formula</Key>" & _
"      <Formula>" & _
"        <segment min=""0.375"" max=""2.842"">-0.02585 + (0.03767*{0}) + (0.04563*({0}^2)) + (0.1151*({0}^3)) + (-0.04158*({0}^4)) + (0.008737*({0}^5))</segment>" & _
"        <segment min=""2.842"" max=""4.945"">(0.1031 + (-0.02322*{0}) + (0.07229*({0}^2))) / (1 + (-0.3986*{0}) + 0.07438*({0}^2) + (-0.006866*({0}^3)))</segment>" & _
"        <segment min=""4.94"" max=""5.659"">(100.624 + (-20.5623*{0}))/(1 + (-0.37679*{0}) + 0.0348656*({0}^2))</segment>" & _
"      </Formula>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>IG_Formula</Key>" & _
"      <Formula>10^({0} - 10)</Formula>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>RoughPump_Max_Value</Key>" & _
"      <Value>150</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>Chamber1_RoughPump_Max_Value</Key>" & _
"      <Value>150</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>InterlockSafetyTMCG</Key>" & _
"      <Value>0.5</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>InterlockSafetyLLACG</Key>" & _
"      <Value>0.02</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>InterlockSafetyLLBCG</Key>" & _
"      <Value>0.02</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>TMCryo_T2Min</Key>" & _
"      <Value>5</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>LLACryo_T2Min</Key>" & _
"      <Value>5</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>TMCryo_T1Min</Key>" & _
"      <Value>10</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>LLACryo_T1Min</Key>" & _
"      <Value>10</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>Rotation_Tilt_Angle</Key>" & _
"      <Value>90</Value>" & _
"    </Configure>" & _
"  </SystemPressure>" & _
"  <KepServerTagsStatus>" & _
"    <!--Alarms-->" & _
"    <Action Name=""Alarm.RedStatus On"" Value=""TM.TMC.RO.System_Error=True"" />" & _
"    <Action Name=""Alarm.RedStatus Off"" Value=""TM.TMC.RO.System_Error=False"" />" & _
"    <Status Name=""Alarm.RedStatus On"" Value=""TM.TMC.RO.System_Error=True"" />" & _
"    <Status Name=""Alarm.RedStatus Off"" Value=""TM.TMC.RO.System_Error=False"" />" & _
"    <Action Name=""Alarm.OrangeStatus On"" Value=""TM.TMC.RO.System_Idle=True"" />" & _
"    <Action Name=""Alarm.OrangeStatus Off"" Value=""TM.TMC.RO.System_Idle=False"" />" & _
"    <Status Name=""Alarm.OrangeStatus On"" Value=""TM.TMC.RO.System_Idle=True"" />" & _
"    <Status Name=""Alarm.OrangeStatus Off"" Value=""TM.TMC.RO.System_Idle=False"" />" & _
"    <Action Name=""Alarm.GreenStatus On"" Value=""TM.TMC.RO.System_Running=True"" />" & _
"    <Action Name=""Alarm.GreenStatus Off"" Value=""TM.TMC.RO.System_Running=False"" />" & _
"    <Status Name=""Alarm.GreenStatus On"" Value=""TM.TMC.RO.System_Running=True"" />" & _
"    <Status Name=""Alarm.GreenStatus Off"" Value=""TM.TMC.RO.System_Running=False"" />" & _
"    <Status Name=""Alarm.ConnectStatus On"" Value=""TM.TMC._System._Error=True"" />" & _
"    <Status Name=""Alarm.ConnectStatus Off"" Value=""TM.TMC._System._Error=False"" />" & _
"    <!--Isolation valve-->" & _
"    <Action Name=""Loader.IsolationValve On"" Value=""TM.TMC.RO.Pm_Iso_Valve_Open=True;TM.TMC.RO.Pm_Iso_Valve_Closed=False"" />" & _
"    <Action Name=""Loader.IsolationValve Off"" Value=""TM.TMC.RO.Pm_Iso_Valve_Open=False;TM.TMC.RO.Pm_Iso_Valve_Closed=True"" />" & _
"    <Status Name=""Loader.IsolationValveStatus On"" Value=""TM.TMC.DI.Pm_Iso_Valve_Open_FB=True;TM.TMC.DI.Pm_Iso_Valve_Closed_FB=False"" />" & _
"    <Status Name=""Loader.IsolationValveStatus Off"" Value=""TM.TMC.DI.Pm_Iso_Valve_Open_FB=False;TM.TMC.DI.Pm_Iso_Valve_Closed_FB=True"" />" & _
"    <!--Robot up down-->" & _
"    <Action Name=""Loader.RobotUpDown On"" Value=""TM.TMC.RO.Robot_Up_Down=True"" />" & _
"    <Action Name=""Loader.RobotUpDown Off"" Value=""TM.TMC.RO.Robot_Up_Down=False"" />" & _
"    <Action Name=""Loader.RobotUpDownMotor On"" Value=""TM.TMC.RO.Robot_Up_Down_Motor_OnOff=True"" />" & _
"    <Action Name=""Loader.RobotUpDownMotor Off"" Value=""TM.TMC.RO.Robot_Up_Down_Motor_OnOff=False"" />" & _
"    <Status Name=""Loader.ArmUpDownStatus On"" Value=""TM.TMC.DI.Robot_Up_FB=True;TM.TMC.DI.Robot_Down_FB=False"" />" & _
"    <Status Name=""Loader.ArmUpDownStatus Off"" Value=""TM.TMC.DI.Robot_Up_FB=False;TM.TMC.DI.Robot_Down_FB=True"" />" & _
"    <Status Name=""Loader.RobotUpDownMotorStatus On"" Value=""TM.TMC.RO.Robot_Up_Down_Motor_OnOff=True"" />" & _
"    <Status Name=""Loader.RobotUpDownMotorStatus Off"" Value=""TM.TMC.RO.Robot_Up_Down_Motor_OnOff=False"" />" & _
"    <!--Robot extend retract-->" & _
"    <Action Name=""Loader.RobotExtendRetract On"" Value=""TM.TMC.RO.Robot_Extend_Retracted=True"" />" & _
"    <Action Name=""Loader.RobotExtendRetract Off"" Value=""TM.TMC.RO.Robot_Extend_Retracted=False"" />" & _
"    <Action Name=""Loader.RobotExtendRetractedMotor On"" Value=""TM.TMC.RO.Robot_Extend_Retracted_Motor_OnOff=True"" />" & _
"    <Action Name=""Loader.RobotExtendRetractedMotor Off"" Value=""TM.TMC.RO.Robot_Extend_Retracted_Motor_OnOff=False"" />" & _
"    <Status Name=""Loader.ArmExtendRetractStatus On"" Value=""TM.TMC.DI.Robot_Extended_FB=True;TM.TMC.DI.Robot_Retracted_FB=False"" />" & _
"    <Status Name=""Loader.ArmExtendRetractStatus Off"" Value=""TM.TMC.DI.Robot_Extended_FB=False;TM.TMC.DI.Robot_Retracted_FB=True"" />" & _
"    <Status Name=""Loader.RobotExtendRetractedMotorStatus On"" Value=""TM.TMC.RO.Robot_Extend_Retracted_Motor_OnOff=True"" />" & _
"    <Status Name=""Loader.RobotExtendRetractedMotorStatus Off"" Value=""TM.TMC.RO.Robot_Extend_Retracted_Motor_OnOff=False"" />" & _
"    <!--Rough valve-->" & _
"    <Action Name=""Loader.RoughValve On"" Value=""TM.TMC.RO.Rough_Valve=True"" />" & _
"    <Action Name=""Loader.RoughValve Off"" Value=""TM.TMC.RO.Rough_Valve=False"" />" & _
"    <Status Name=""Loader.RoughValve On"" Value=""TM.TMC.RO.Rough_Valve=True"" />" & _
"    <Status Name=""Loader.RoughValve Off"" Value=""TM.TMC.RO.Rough_Valve=False"" />" & _
"    <!--Vent valve-->" & _
"    <Action Name=""Loader.VentValve On"" Value=""TM.TMC.RO.Vent_Valve=True"" />" & _
"    <Action Name=""Loader.VentValve Off"" Value=""TM.TMC.RO.Vent_Valve=False"" />" & _
"    <Status Name=""Loader.VentValve On"" Value=""TM.TMC.RO.Vent_Valve=True"" />" & _
"    <Status Name=""Loader.VentValve Off"" Value=""TM.TMC.RO.Vent_Valve=False"" />" & _
"	<!--Door sensor-->" & _
"    <Status Name=""Loader.DoorSensorStatus On"" Value=""TM.TMC.DI.Door_Sensor_FB=True"" />" & _
"    <Status Name=""Loader.DoorSensorStatus Off"" Value=""TM.TMC.DI.Door_Sensor_FB=False"" />" & _
"	<!--Pressure-->" & _
"    <Status Name=""Loader.MidVacuumSwitch On"" Value=""TM.TMC.DI.Rough_Vacuum_Switch_FB=True"" />" & _
"    <Status Name=""Loader.MidVacuumSwitch Off"" Value=""TM.TMC.DI.Rough_Vacuum_Switch_FB=False"" />" & _
"    <Status Name=""Loader.AtmVacuumSwitch On"" Value=""TM.TMC.DI.Atm_Vacuum_Switch_FB=True"" />" & _
"    <Status Name=""Loader.AtmVacuumSwitch Off"" Value=""TM.TMC.DI.Atm_Vacuum_Switch_FB=False"" />" & _
"  </KepServerTagsStatus>" & _
"  <KepServerTagsDef>" & _
"    <Group Name=""TM.TMC"" IsActive=""True"" DeadBand=""0"" UpdateRate=""100"">" & _
"      <Item DisplayGroup=""TM.TMC"" PropertyName=""CassettesModule.KepWareServerDisConnected"" KepServerName=""TM.TMC._System._Error"" DataType=""Boolean"" Desc=""KepWare Connection"" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""Loader.DoorSensorStatus"" KepServerName=""TM.TMC.DI.Door_Sensor_FB"" DataType=""Boolean"" Desc="""" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""Loader.MidVacuumSwitch"" KepServerName=""TM.TMC.DI.Rough_Vacuum_Switch_FB"" DataType=""Boolean"" Desc="""" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""Loader.AtmVacuumSwitch"" KepServerName=""TM.TMC.DI.Atm_Vacuum_Switch_FB"" DataType=""Boolean"" Desc="""" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""Loader.IsolationValveStatus"" KepServerName=""TM.TMC.DI.Pm_Iso_Valve_Closed_FB"" DataType=""Boolean"" Desc="""" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""Loader.IsolationValveStatus"" KepServerName=""TM.TMC.DI.Pm_Iso_Valve_Open_FB"" DataType=""Boolean"" Desc="""" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""Loader.ArmUpDownStatus"" KepServerName=""TM.TMC.DI.Robot_Down_FB"" DataType=""Boolean"" Desc="""" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""Loader.ArmExtendRetractStatus"" KepServerName=""TM.TMC.DI.Robot_Extended_FB"" DataType=""Boolean"" Desc="""" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""Loader.ArmExtendRetractStatus"" KepServerName=""TM.TMC.DI.Robot_Retracted_FB"" DataType=""Boolean"" Desc="""" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""Loader.ArmUpDownStatus"" KepServerName=""TM.TMC.DI.Robot_Up_FB"" DataType=""Boolean"" Desc="""" />" & _
"      <Item DisplayGroup=""TM.TMC.RO"" PropertyName="""" KepServerName=""TM.TMC.RO.Pm_Iso_Valve_Closed"" DataType=""Boolean"" Desc="""" />" & _
"      <Item DisplayGroup=""TM.TMC.RO"" PropertyName="""" KepServerName=""TM.TMC.RO.Pm_Iso_Valve_Open"" DataType=""Boolean"" Desc="""" />" & _
"      <Item DisplayGroup=""TM.TMC.RO"" PropertyName="""" KepServerName=""TM.TMC.RO.Robot_Up_Down"" DataType=""Boolean"" Desc="""" />" & _
"      <Item DisplayGroup=""TM.TMC.RO"" PropertyName=""Loader.RobotUpDownMotorStatus"" KepServerName=""TM.TMC.RO.Robot_Up_Down_Motor_OnOff"" DataType=""Boolean"" Desc="""" />" & _
"      <Item DisplayGroup=""TM.TMC.RO"" PropertyName="""" KepServerName=""TM.TMC.RO.Robot_Extend_Retracted"" DataType=""Boolean"" Desc="""" />" & _
"      <Item DisplayGroup=""TM.TMC.RO"" PropertyName=""Loader.RobotExtendRetractedMotorStatus"" KepServerName=""TM.TMC.RO.Robot_Extend_Retracted_Motor_OnOff"" DataType=""Boolean"" Desc="""" />" & _
"      <Item DisplayGroup=""TM.TMC.RO"" PropertyName="""" KepServerName=""TM.TMC.RO.System_Error"" DataType=""Boolean"" Desc="""" />" & _
"      <Item DisplayGroup=""TM.TMC.RO"" PropertyName="""" KepServerName=""TM.TMC.RO.System_Idle"" DataType=""Boolean"" Desc="""" />" & _
"      <Item DisplayGroup=""TM.TMC.RO"" PropertyName="""" KepServerName=""TM.TMC.RO.System_Running"" DataType=""Boolean"" Desc="""" />" & _
"      <Item DisplayGroup=""TM.TMC.RO"" PropertyName=""Loader.RoughValveStatus"" KepServerName=""TM.TMC.RO.Rough_Valve"" DataType=""Boolean"" Desc="""" />" & _
"      <Item DisplayGroup=""TM.TMC.RO"" PropertyName=""Loader.VentValveStatus"" KepServerName=""TM.TMC.RO.Vent_Valve"" DataType=""Boolean"" Desc="""" />" & _
"    </Group>" & _
"  </KepServerTagsDef>" & _
"  <SystemMessageError>" & _
"    <Property Name=""_ERR140"" Code=""Encounter Error 140"" />" & _
"    <Property Name=""ErrRequestCasPresent"" Code=""Request Cassette Present Error"" />" & _
"    <Property Name=""ErrRequestPumpStatus"" Code=""Request Pumb Status Error"" />" & _
"    <Property Name=""ErrChecksumFailed"" Code=""Checksum Is Incorrect"" />" & _
"    <Property Name=""ErrInvalidResponseFormat"" Code=""Invalid Response Format"" />" & _
"    <Property Name=""ErrElevatorOperationalStatus"" Code=""Request Operational Status Error"" />" & _
"    <Property Name=""ErrElevator"" Code=""Encounter Error In Reply Syntax"" />" & _
"    <Property Name=""CheckError"" Code=""Is Error"" />" & _
"    <Property Name=""ErrTimeout"" Code=""Is Timeout"" />" & _
"    <Property Name=""ErrMappedInfor"" Code=""Can Not Get Mapped Information Because Of Error In Reply Syntax"" />" & _
"    <Property Name=""ErrReply"" Code=""Encounter Error By Reply : "" />" & _
"    <Property Name=""ErrRequestRetractedStatus"" Code=""Encounter Error In Reply Syntax"" />" & _
"    <Property Name=""ErrInit"" Code=""Encounter Error In Initialization"" />" & _
"    <Property Name=""ErrRequestRegen"" Code=""Encounter Error In Reply Syntax"" />" & _
"    <Property Name=""ErrPurgeGas"" Code=""Get Purge Gas Failure"" />" & _
"    <Property Name=""ErrPower"" Code=""Get Power Failure"" />" & _
"  </SystemMessageError>" & _
"  <UserMessageTexts>" & _
"    <!--Begin Single Loader Message-->" & _
"    <MessageText>" & _
"      <Key>SL.btnPause.Resume</Key>" & _
"      <Value>Would you like to Resume processing Recipe?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.btnPause.Pause</Key>" & _
"      <Value>Would you like to Pause processing Recipe?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.btnPause.Stop</Key>" & _
"      <Value>Would you like to Stop processing Recipe?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.Processing</Key>" & _
"      <Value>Still Processing Recipe</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.btnStart.Stop</Key>" & _
"      <Value>Would you like to Stop processing Recipe?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.btnStart.Start</Key>" & _
"      <Value>Would you like to start processing Recipe?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.btnStart.NoWafer</Key>" & _
"      <Value>Can not start processing without wafer</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.btnAbort</Key>" & _
"      <Value>Would you like to Abort processing Recipe?</Value>" & _
"    </MessageText>" & _
"    <!--Container Box-->" & _
"    <MessageText>" & _
"      <Key>SL.SLContainerBox.btnWaterPumpOn.On</Key>" & _
"      <Value>Would you like to Turn On Turbo Pump ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SLContainerBox.btnWaterPumpOn.Off</Key>" & _
"      <Value>Would you like to Turn Off Turbo Pump ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SLContainerBox.btnCryoOn.On</Key>" & _
"      <Value>Would you like to Turn On Cryo Pump ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SLContainerBox.btnCryoOn.Off</Key>" & _
"      <Value>Would you like to Turn Off Cryo Pump ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SLContainerBox.Shutter.On</Key>" & _
"      <Value>Would you like to Open Shutter ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SLContainerBox.Shutter.Off</Key>" & _
"      <Value>Would you like to Close Shutter ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SLContainerBox.Shutter.Unknown</Key>" & _
"      <Value>Would you like to Open/Close Shutter ?</Value>" & _
"    </MessageText>" & _
"    <!--Status panel-->" & _
"    <MessageText>" & _
"      <Key>SL.SLStatusPanel.btnMotionInitialized.On</Key>" & _
"      <Value>Would you like to Turn MotionInitialized On ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SLStatusPanel.btnMotionInitialized.Off</Key>" & _
"      <Value>Would you like to Turn MotionInitialized Off ?</Value>" & _
"    </MessageText>" & _
"    <!--Power panel-->" & _
"    <MessageText>" & _
"      <Key>SL.SLPowerPanel.btnACPower.On</Key>" & _
"      <Value>Would you like to Turn On AC Power ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SLPowerPanel.btnACPower.Off</Key>" & _
"      <Value>Would you like to Turn Off AC Power ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SLPowerPanel.btnRFPower.On</Key>" & _
"      <Value>Would you like to Turn On RF Power ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SLPowerPanel.btnRFPower.Off</Key>" & _
"      <Value>Would you like to Turn Off RF Power ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SLPowerPanel.btnGrid.On</Key>" & _
"      <Value>Would you like to Turn On Grid Power ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SLPowerPanel.btnGrid.Off</Key>" & _
"      <Value>Would you like to Turn Off Grid Power ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SLPowerPanel.btnPBN.On</Key>" & _
"      <Value>Would you like to Turn On PBN Power ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SLPowerPanel.btnPBN.Off</Key>" & _
"      <Value>Would you like to Turn Off PBN Power ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SLPowerPanel.btnNeur.On</Key>" & _
"      <Value>Would you like to Turn On Neutralizer Power ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SLPowerPanel.btnNeur.Off</Key>" & _
"      <Value>Would you like to Turn Off Neutralizer Power ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SLPowerPanel.btnSourceManual.On</Key>" & _
"      <Value>Would you like to Turn On Source Manual ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SLPowerPanel.btnSourceManual.Off</Key>" & _
"      <Value>Would you like to Turn Off Source Manual ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SLPowerPanel.btnSourceAuto.On</Key>" & _
"      <Value>Would you like to Turn On Source Auto ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SLPowerPanel.btnSourceAuto.Off</Key>" & _
"      <Value>Would you like to Turn Off Source Auto ?</Value>" & _
"    </MessageText>" & _
"    <!--Source tab-->" & _
"    <MessageText>" & _
"      <Key>SL.txtBeamVoltageRight</Key>" & _
"      <Value>Would you like to change Beam Voltage value to ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtBeamCurrentRight</Key>" & _
"      <Value>Would you like to change Beam Current value to ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtSuppressorVoltageRight</Key>" & _
"      <Value>Would you like to change Suppressor Voltage value to ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtSuppressorCurrentRight</Key>" & _
"      <Value>Would you like to change Suppressor Current value to ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtRFPowerRight</Key>" & _
"      <Value>Would you like to change RF Power value to ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtRFReflectedRight</Key>" & _
"      <Value>Would you like to change RF Reflected value to ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtPBNGasRight_SourceTab</Key>" & _
"      <Value>Would you like to change {0} value to ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtGas1Right_SourceTab</Key>" & _
"      <Value>Would you like to change {0} value to ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtGas2Right_SourceTab</Key>" & _
"      <Value>Would you like to change {0} value to ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtKFactorRight</Key>" & _
"      <Value>Would you like to change K Factor value to ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtPBNBodyRight</Key>" & _
"      <Value>Would you like to change PBN Body value to ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtPBNDischRight</Key>" & _
"      <Value>Would you like to change PBNDisch value to ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SL_ProcessModule.btnAutoBeam.On</Key>" & _
"      <Value>Would you like to Enable Auto Beam ?</Value>" & _
"    </MessageText>" & _
"     <MessageText>" & _
"      <Key>SL.SL_ProcessModule.btnAutoBeam.Off</Key>" & _
"      <Value>Would you like to Disable Auto Beam ?</Value>" & _
"    </MessageText>" & _
"    <!--Gas tab-->" & _
"    <MessageText>" & _
"      <Key>SL.txtPBNGasRight</Key>" & _
"      <Value>Would you like to change {0} value to ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtGas1Right</Key>" & _
"      <Value>Would you like to change {0} value to ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtGas2Right</Key>" & _
"      <Value>Would you like to change {0} value to ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtGas3Right</Key>" & _
"      <Value>Would you like to change {0} value to ?</Value>" & _
"    </MessageText>" & _
"    <!--Fixture-->" & _
"    <MessageText>" & _
"      <Key>SL.txtFlowCoolGasRight</Key>" & _
"      <Value>Would you like to change {0} value to ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtTiltAngleRight</Key>" & _
"      <Value>Would you like to change Tilt Angle value to ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtRotationContinuousRight</Key>" & _
"      <Value>Would you like to change Rotation value to ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtRotationEnd</Key>" & _
"      <Value>Would you like to change Rotation End value to ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtRotationSweepRight</Key>" & _
"      <Value>Would you like to change Rotation value to ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.txtRotationStaticRight</Key>" & _
"      <Value>Would you like to change Rotation value to ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SLFixture.mnuShutterOpen</Key>" & _
"      <Value>Would you like to Open Shutter ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SLFixture.mnuShutterClose</Key>" & _
"      <Value>Would you like to Close Shutter ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SLFixture.btnClampUp</Key>" & _
"      <Value>Would you like to Clamp Up ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SLFixture.btnClampDown</Key>" & _
"      <Value>Would you like to Clamp Down ?</Value>" & _
"    </MessageText>" & _
"    <!--Valve click-->" & _
"    <MessageText>" & _
"      <Key>SL.ValveVent.Open</Key>" & _
"      <Value>Would you like to Open Vent Valve ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.ValveVent.Close</Key>" & _
"      <Value>Would you like to Close Vent Valve ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.ValveRough.Open</Key>" & _
"      <Value>Would you like to Open Rough Valve ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.ValveRough.Close</Key>" & _
"      <Value>Would you like to Close Rough Valve ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.ValveForeline.Open</Key>" & _
"      <Value>Would you like to Open Foreline Valve ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.ValveForeline.Close</Key>" & _
"      <Value>Would you like to Close Foreline Valve ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.ValveShutoffGas1.Open</Key>" & _
"      <Value>Would you like to Open ValveShutoffGas1 Valve ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.ValveShutoffGas1.Close</Key>" & _
"      <Value>Would you like to Close ValveShutoffGas1 Valve ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.ValveShutoffGas2.Open</Key>" & _
"      <Value>Would you like to Open ValveShutoffGas2 Valve ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.ValveShutoffGas2.Close</Key>" & _
"      <Value>Would you like to Close ValveShutoffGas2 Valve ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.ValveShutoffGas3.Open</Key>" & _
"      <Value>Would you like to Open ValveShutoffGas3 Valve ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.ValveShutoffGas3.Close</Key>" & _
"      <Value>Would you like to Close ValveShutoffGas3 Valve ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.ValveShutoffPBNGas.Open</Key>" & _
"      <Value>Would you like to Open Shutoff PBN Valve ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.ValveShutoffPBNGas.Close</Key>" & _
"      <Value>Would you like to Close Shutoff PBN Valve ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.ValveShutoffFlowCoolGas.Open</Key>" & _
"      <Value>Would you like to Open Shutoff FlowCool He Valve ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.ValveShutoffFlowCoolGas.Close</Key>" & _
"      <Value>Would you like to Close Shutoff FlowCool He Valve ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.ValveSupplyGas1.Open</Key>" & _
"      <Value>Would you like to Open ValveSupplyGas1 Valve ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.ValveSupplyGas1.Close</Key>" & _
"      <Value>Would you like to Close ValveSupplyGas1 Valve ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.ValveSupplyGas2.Open</Key>" & _
"      <Value>Would you like to Open ValveSupplyGas2 Valve ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.ValveSupplyGas2.Close</Key>" & _
"      <Value>Would you like to Close ValveSupplyGas2 Valve ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.ValveSupplyGas3.Open</Key>" & _
"      <Value>Would you like to Open ValveSupplyGas3 Valve ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.ValveSupplyGas3.Close</Key>" & _
"      <Value>Would you like to Close ValveSupplyGas3 Valve ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.ValveSupplyPBNGas.Open</Key>" & _
"      <Value>Would you like to Open Supply PBN Valve ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.ValveSupplyPBNGas.Close</Key>" & _
"      <Value>Would you like to Close Supply PBN Valve ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.ValveSupplyFlowCoolGas.Open</Key>" & _
"      <Value>Would you like to Open Supply FlowCool He Valve ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.ValveSupplyFlowCoolGas.Close</Key>" & _
"      <Value>Would you like to Close Supply FlowCool He Valve ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.RoughPump.Open</Key>" & _
"      <Value>Would you like to Open Rough Pupm Power ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.RoughPump.Close</Key>" & _
"      <Value>Would you like to Close Rough Pump Power ?</Value>" & _
"    </MessageText>" & _
"    <!--menu click-->" & _
"    <MessageText>" & _
"      <Key>OpenCryoPurgeValve</Key>" & _
"      <Value>Would you like to Open Cryo Purge ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CloseCryoPurgeValve</Key>" & _
"      <Value>Would you like to Close Cryo Purge ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SLContainerBox.ValveCryoHivac.On</Key>" & _
"      <Value>Would you like to Open Cryo Gate ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SLContainerBox.ValveCryoHivac.Off</Key>" & _
"      <Value>Would you like to Close Cryo Gate ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SLContainerBox.ValveCryoHivac.Unknown</Key>" & _
"      <Value>Would you like to Open/Close Cryo Gate ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>AutoCryoRegenOn</Key>" & _
"      <Value>Would you like to Start Auto Cryo Regen ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>AutoCryoRegenOff</Key>" & _
"      <Value>Would you like to Abort Auto Cryo Regen ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>AutoCryoPowerDownOn</Key>" & _
"      <Value>Would you like to Auto Cryo Power Down On ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>AutoCryoPowerDownOff</Key>" & _
"      <Value>Would you like to Auto Cryo Power Down Off ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SLContainerBox.ValveTurboHivac.On</Key>" & _
"      <Value>Would you like to Open WaterPump Gate ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SLContainerBox.ValveTurboHivac.Off</Key>" & _
"      <Value>Would you like to Close WaterPump Gate ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SLContainerBox.ValveTurboHivac.Unknown</Key>" & _
"      <Value>Would you like to Open/Close WaterPump Gate ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TurnPumpPowerOn</Key>" & _
"      <Value>Would you like to Turn Pump Power On ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TurnFlowCoolPumpPowerOff</Key>" & _
"      <Value>Would you like to Turn Pump Power Off ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TurnCoolingWaterOn</Key>" & _
"      <Value>Would you like to Turn Cooling Water On ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TurnCoolingWaterOff</Key>" & _
"      <Value>Would you like to Turn Cooling Water Off ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TurnUnprotectedOn</Key>" & _
"      <Value>Would you like to Turn Unprotected On ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TurnFlowCoolUnprotectedOff</Key>" & _
"      <Value>Would you like to Turn Unprotected Off ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>AutoVentOn</Key>" & _
"      <Value>Would you like to Auto Vent ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>AutoVentOff</Key>" & _
"      <Value>Would you like to Abort Auto Vent ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>AutoPumpDownOn</Key>" & _
"      <Value>Would you like to Auto Pump Down ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>AutoPumpDownOff</Key>" & _
"      <Value>Would you like to Abort Auto Pump Down ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>RunRateOfRise</Key>" & _
"      <Value>Would you like to Run Rate Of Rise ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>AbortRateOfRise</Key>" & _
"      <Value>Would you like to Abort Rate Of Rise ?</Value>" & _
"    </MessageText>" & _
"    <!--SL Process screen -->" & _
"    <!--Process control-->" & _
"    <MessageText>" & _
"      <Key>SL.SLProcessControl.btnSelect</Key>" & _
"      <Value>Would you like to Select recipe ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SLProcessControl.btnRun</Key>" & _
"      <Value>Would you like to Run recipe ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SLProcessControl.btnStop</Key>" & _
"      <Value>Would you like to Stop recipe ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SLProcessControl.btnAbort</Key>" & _
"      <Value>Would you like to Abort recipe ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SLProcessControl.btnContinue</Key>" & _
"      <Value>Would you like to Continue recipe ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SLProcessControl.btnEndCurrentStep</Key>" & _
"      <Value>Would you like to End Current Step ?</Value>" & _
"    </MessageText>" & _
"    <!--System control -->" & _
"    <MessageText>" & _
"      <Key>SL.SLSystemControl.btnOnline</Key>" & _
"      <Value>Would you like to Online ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SLSystemControl.btnOffline</Key>" & _
"      <Value>Would you like to Offline ?</Value>" & _
"    </MessageText>" & _
"    <!--Robot control-->" & _
"    <MessageText>" & _
"      <Key>SL.SLRobotControl.btnArmUp</Key>" & _
"      <Value>Would you like to Arm Up ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SLRobotControl.btnArmDown</Key>" & _
"      <Value>Would you like to Arm Down ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SLRobotControl.btnExtendArm</Key>" & _
"      <Value>Would you like to Extend Arm ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SLRobotControl.btnRetractArm</Key>" & _
"      <Value>Would you like to Retract Arm ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SLRobotControl.btnAutoLoad</Key>" & _
"      <Value>Would you like to Auto Load ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SLRobotControl.btnAutoUnload</Key>" & _
"      <Value>Would you like to Auto Unload ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SL_ProcessPanel.btnCycle.On</Key>" & _
"      <Value>Would you like to Turn On Cycle Mode ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SL_ProcessPanel.btnCycle.Off</Key>" & _
"      <Value>Would you like to Turn Off Cycle Mode ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SL_ProcessPanel.btnUnProtected.On</Key>" & _
"      <Value>Would you like to Turn On UnProtected ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SL_ProcessPanel.btnUnProtected.Off</Key>" & _
"      <Value>Would you like to Turn Off UnProtected ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SL_ProcessPanel.btnReConnect</Key>" & _
"      <Value>Would you like to Connect PM ?</Value>" & _
"    </MessageText>" & _
"    <!--Vacuum control-->" & _
"    <MessageText>" & _
"      <Key>SL.SLVacuumControl.btnOpenRoughValve</Key>" & _
"      <Value>Would you like to Open Rough Valve ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SLVacuumControl.btnCloseRoughValve</Key>" & _
"      <Value>Would you like to Close Rough Valve ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SLVacuumControl.btnOpenVentValve</Key>" & _
"      <Value>Would you like to Open Vent Valve ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SLVacuumControl.btnCloseVentValve</Key>" & _
"      <Value>Would you like to Close Vent Valve ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SLVacuumControl.btnOpenIsolationValve</Key>" & _
"      <Value>Would you like to Open Isolation Valve ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SLVacuumControl.btnCloseIsolationValve</Key>" & _
"      <Value>Would you like to Close Isolation Valve ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SL_ProcessPanel.btnAutoPumpDown.On</Key>" & _
"      <Value>Would you like to Start Auto Pump Down ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SL_ProcessPanel.btnAutoPumpDown.Off</Key>" & _
"      <Value>Would you like to Abort Auto Pump Down ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SL_ProcessPanel.btnAutoVent.On</Key>" & _
"      <Value>Would you like to Start Auto Vent ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.SL_ProcessPanel.btnAutoVent.Off</Key>" & _
"      <Value>Would you like to Abort Auto Vent ?</Value>" & _
"    </MessageText>" & _
"    <!--Load control-->" & _
"    <MessageText>" & _
"      <Key>SL.SL_ProcessPanel.btnLoad</Key>" & _
"      <Value>Would you like to Load System ?</Value>" & _
"    </MessageText>" & _
"    <!--Valve-->" & _
"    <MessageText>" & _
"      <Key>SL.VentValve.Open</Key>" & _
"      <Value>Would you like to Open Vent Valve ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.VentValve.Close</Key>" & _
"      <Value>Would you like to Close Vent Valve ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.RoughValve.Open</Key>" & _
"      <Value>Would you like to Open Rough Valve ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.RoughValve.Close</Key>" & _
"      <Value>Would you like to Close Rough Valve ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.FlowCoolValve.Open</Key>" & _
"      <Value>Would you like to Open FlowCool Valve ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.FlowCoolValve.Close</Key>" & _
"      <Value>Would you like to Close FlowCool Valve ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.MesaValve.Open</Key>" & _
"      <Value>Would you like to Open Mesa Valve ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SL.MesaValve.Close</Key>" & _
"      <Value>Would you like to Close Mesa Valve ?</Value>" & _
"    </MessageText>" & _
"    <!--System Set Up-->" & _
"    <MessageText>" & _
"      <Key>SL.SL_SystemSetup.btnResetSourceUsage</Key>" & _
"      <Value>Would you like to Reset Source Usage ?</Value>" & _
"    </MessageText>" & _
"    <!--Begin IBE Message-->" & _
"    <MessageText>" & _
"      <Key>RFPowerOn</Key>" & _
"      <Value>Would you like to change 'RF Power' to On?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>RFPowerOff</Key>" & _
"      <Value>Would you like to change 'RF Power' to Off?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>GridPowerOn</Key>" & _
"      <Value>Would you like to change 'Grid Power' to On?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>GridPowerOff</Key>" & _
"      <Value>Would you like to change 'Grid Power' to Off?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PBNPowerOn</Key>" & _
"      <Value>Would you like to change 'PBN Power' to On?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PBNPowerOff</Key>" & _
"      <Value>Would you like to change 'PBN Power' to Off?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ACPowerOn</Key>" & _
"      <Value>Would you like to change 'AC Power' to On?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ACPowerOff</Key>" & _
"      <Value>Would you like to change 'AC Power' to Off?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>BeamPowerSupplyAutoBeamEnable</Key>" & _
"      <Value>Would you like to change 'Auto Beam' to enable?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>BeamPowerSupplyAutoBeamDisable</Key>" & _
"      <Value>Would you like to change 'Auto Beam' to disable?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IgcgTMMessage</Key>" & _
"      <Value>Change 'TM_TCM_RO_WTM_lon_S' to </Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IgcgChamberMessage</Key>" & _
"      <Value>Change {0} IG to </Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IgcgLLAMessage</Key>" & _
"      <Value>Change 'TM_TCM_RO_Cas1lon' to </Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IgcgLLBMessage</Key>" & _
"      <Value>Change 'TM_TCM_RO_Cas2lon' to </Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>rrcMesaValve2Open</Key>" & _
"      <Value>Would you like to open SlitValve for {0}? </Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>rrcMesaValve2Close</Key>" & _
"      <Value>Would you like to close SlitValve for {0}? </Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>rrcMesaValve4Open</Key>" & _
"      <Value>Would you like to open SlitValve for {0}? </Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>rrcMesaValve4Close</Key>" & _
"      <Value>Would you like to close SlitValve for {0}? </Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>rrcMesaValve6Open</Key>" & _
"      <Value>Would you like to open SlitValve for {0}? </Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>rrcMesaValve6Close</Key>" & _
"      <Value>Would you like to close SlitValve for {0}? </Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>rrcMesaValve3Open</Key>" & _
"      <Value>Would you like to open SlitValve for {0}? </Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>rrcMesaValve3Close</Key>" & _
"      <Value>Would you like to close SlitValve for {0}? </Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>rrcMesaValve3Failed</Key>" & _
"      <Value>Failed to Operate Slit-Valve in time </Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>rrcMesaValve5Open</Key>" & _
"      <Value>Would you like to open SlitValve for {0}? </Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>rrcMesaValve5Close</Key>" & _
"      <Value>Would you like to close SlitValve for {0}? </Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>rrcMesaValve5Failed</Key>" & _
"      <Value>Failed to Operate Slit-Valve in time </Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>rrcMesaValve7Open</Key>" & _
"      <Value>Would you like to open SlitValve for ""Load Lock B""? </Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>rrcMesaValve7Close</Key>" & _
"      <Value>Would you like to close SlitValve for ""Load Lock B""? </Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>rrcMesaValve1Open</Key>" & _
"      <Value>Would you like to open SlitValve for ""Load Lock A""? </Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>rrcMesaValve1Close</Key>" & _
"      <Value>Would you like to close SlitValve for ""Load Lock A""? </Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>rrcHivacValveLLAOpen</Key>" & _
"      <Value>Would you like to open HiVacValve for ""Load Lock A""? </Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>rrcHivacValveLLAClose</Key>" & _
"      <Value>Would you like to close HiVacValve for ""Load Lock A""? </Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>rrcHivacValveLLAUnknown</Key>" & _
"      <Value>Would you like to open/close HiVacValve for ""Load Lock A""? </Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>rrcHivacValveLLBOpen</Key>" & _
"      <Value>Would you like to open HiVacValve for ""Load Lock B""? </Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>rrcHivacValveLLBClose</Key>" & _
"      <Value>Would you like to close HiVacValve for ""Load Lock B""? </Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>rrcHivacValveLLBUnknown</Key>" & _
"      <Value>Would you like to open/close HiVacValve for ""Load Lock B""? </Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ibsHivacButtonOpen</Key>" & _
"      <Value>Would you like to open HiVacValve for ""Transfer Wafer""?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ibsHivacButtonClose</Key>" & _
"      <Value>Would you like to close HiVacValve for ""Transfer Wafer""?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ibsHivacButtonUnknown</Key>" & _
"      <Value>Would you like to Open/Close HiVacValve for ""Transfer Wafer""?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TransferValveVentOpen</Key>" & _
"      <Value>Would you like to open 'TM Vent Valve'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TransferValveVentClose</Key>" & _
"      <Value>Would you like to close 'TM Vent Valve'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TransferValveLLASlowVentOpen</Key>" & _
"      <Value>Would you like to open 'LLA Slow Vent Valve'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TransferValveLLASlowVentClose</Key>" & _
"      <Value>Would you like to close 'LLA Slow Vent Valve'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TransferValveLLAFastVentOpen</Key>" & _
"      <Value>Would you like to open 'LLA Fast Vent Valve'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TransferValveLLAFastVentClose</Key>" & _
"      <Value>Would you like to close 'LLA Fast Vent Valve'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TransferValveLLBSlowVentOpen</Key>" & _
"      <Value>Would you like to open 'LLB Slow Vent Valve'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TransferValveLLBSlowVentClose</Key>" & _
"      <Value>Would you like to close 'LLB Slow Vent Valve'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TransferValveLLBFastVentOpen</Key>" & _
"      <Value>Would you like to open 'LLB Fast Vent Valve'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TransferValveLLBFastVentClose</Key>" & _
"      <Value>Would you like to close 'LLB Fast Vent Valve'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TransferValveRoughOpen</Key>" & _
"      <Value>Would you like to open 'TM Rough Valve'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TransferValveRoughClose</Key>" & _
"      <Value>Would you like to close 'TM Rough Valve'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TransferValveLLBSlowRoughOpen</Key>" & _
"      <Value>Would you like to open 'LLB Slow Rough Valve'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TransferValveLLBSlowRoughClose</Key>" & _
"      <Value>Would you like close 'LLB Slow Rough Valve'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TransferValveLLBFastRoughOpen</Key>" & _
"      <Value>Would you like to open 'LLB Fast Rough Valve'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TransferValveLLBFastRoughClose</Key>" & _
"      <Value>Would you like to close 'LLB Fast Rough Valve'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TransferValveLLASlowRoughOpen</Key>" & _
"      <Value>Would you like to open 'LLA Slow Rough Valve'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TransferValveLLASlowRoughClose</Key>" & _
"      <Value>Would you like to close 'LLA Slow Rough Valve'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TransferValveLLAFastRoughOpen</Key>" & _
"      <Value>Would you like to open 'LLA Fast Rough Valve'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TransferValveLLAFastRoughClose</Key>" & _
"      <Value>Would you like to close 'LLA Fast Rough Valve'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CGSmallerThan</Key>" & _
"      <Value>{0} CG {1} torr.</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>LL_Rough</Key>" & _
"      <Value>{0} is not Off</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Mesa_Valves</Key>" & _
"      <Value>{0} was not closed</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>HivacValveLL</Key>" & _
"      <Value>Hivac valve of {0} is not Open</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>VacSwitch_FB</Key>" & _
"      <Value>{0} CG Relay Switch is not On</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ValveControlForelineOpen</Key>" & _
"      <Value>Would you like to open 'Turbo Foreline Valve'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ValveControlForelineClose</Key>" & _
"      <Value>Would you like to close 'Turbo Foreline Valve'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ValveWaterPumpOpen</Key>" & _
"      <Value>Would you like to open 'Turbo Pump'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ValveWaterPumpClose</Key>" & _
"      <Value>Would you like to close 'Turbo Pump'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>WaterValveOpen</Key>" & _
"      <Value>Would you like to open 'Water Valve'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>WaterValveClose</Key>" & _
"      <Value>Would you like to close 'Water Valve'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>FlowCoolPumpOpen</Key>" & _
"      <Value>Would you like to open 'Flow Cool Pump'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>FlowCoolPumpClose</Key>" & _
"      <Value>Would you like to open 'Flow Cool Pump'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>RoughPumpPowerOpen</Key>" & _
"      <Value>Would you like to open 'Rough Pump Power'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>RoughPumpPowerClose</Key>" & _
"      <Value>Would you like to close 'Rough Pump Power'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TurboPumpPowerOpen</Key>" & _
"      <Value>Would you like to open 'Turbo Pump Power'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TurboPumpPowerClose</Key>" & _
"      <Value>Would you like to close 'Turbo Pump Power'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CryoPumpRegen</Key>" & _
"      <Value>Would you like to 'Cryo Pump Regen'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CryoAutoRegen</Key>" & _
"      <Value>Would you like to 'Cryo Auto Regen'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ValveControlCryoPumpOpen</Key>" & _
"      <Value>Would you like to open 'Cryo Pump Valve'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ValveControlCryoPumpClose</Key>" & _
"      <Value>Would you like to close 'Cryo Pump Valve'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ValveSupplyArgonOpen</Key>" & _
"      <Value>Would you like to open 'Supply Argon Valve'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ValveSupplyArgonClose</Key>" & _
"      <Value>Would you like to close 'Supply Argon Valve'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ValveSupplyFlowCoolHeOpen</Key>" & _
"      <Value>Would you like to open 'Supply FlowCool He Valve'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ValveSupplyFlowCoolHeClose</Key>" & _
"      <Value>Would you like to close 'Supply FlowCool He Valve'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ValveSupplyPBNOpen</Key>" & _
"      <Value>Would you like to open 'Supply PBN Valve'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ValveSupplyPBNClose</Key>" & _
"      <Value>Would you like to close 'Supply PBN Valve'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ValveControlRoughOpen</Key>" & _
"      <Value>Would you like to open 'Rough Valve'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ticGasPumpOpen</Key>" & _
"      <Value>Would you like to open 'Rough Pump'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ticGasPumpClose</Key>" & _
"      <Value>Would you like to change 'Rough Pump'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ValveControlRoughClose</Key>" & _
"      <Value>Would you like to change 'Rough Valve' to 'False'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ValveControlVentOpen</Key>" & _
"      <Value>Would you like to change 'Vent Valve' to 'True'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ValveRingControlClose</Key>" & _
"      <Value>Would you like to change 'HiVacValve' to 'False'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ValveRingControlOpen</Key>" & _
"      <Value>Would you like to change 'HivacValve' to 'True'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>HivacValveControlCloseFail</Key>" & _
"      <Value>Failed, Foreline RF is Off</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>HivacValveControlOpenFail</Key>" & _
"      <Value>Failed, Foreline RF is On</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ValveControlVentClose</Key>" & _
"      <Value>Would you like to change 'Vent Valve' to 'False'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ScreenMachineOpen</Key>" & _
"      <Value>Would you like to open Shutter?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ScreenMachineClose</Key>" & _
"      <Value>Would you like to close Shutter?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ValveControlBaratronOpen</Key>" & _
"      <Value>Would you like to change 'Baratron Valve' to 'True'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ValveControlBaratronClose</Key>" & _
"      <Value>Would you like to change 'Baratron Valve' to 'False'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ValveControlFlowCoolHeOpen</Key>" & _
"      <Value>Would you like to change 'Gas, Flow Cool He Valve' to 'True'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ValveControlFlowCoolHeClose</Key>" & _
"      <Value>Would you like to change 'Gas, Flow Cool He Valve' to 'False'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ValveControlPBNOpen</Key>" & _
"      <Value>Would you like to change 'Gas, PBN Valve' to 'True'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ValveControlPBNClose</Key>" & _
"      <Value>Would you like to change 'Gas, PBN Valve' to 'False'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ValveControlArgonOpen</Key>" & _
"      <Value>Would you like to change 'Gas, Argon Valve' to 'True'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ValveControlArgonClose</Key>" & _
"      <Value>Would you like to change 'Gas, Argon Valve' to 'False'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ErrorMessageRecipe</Key>" & _
"      <Value>{0} lt {1} lteq {2}</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>EquipmentWaitLLCGSmaller</Key>" & _
"      <Value>{0}: Wait until LL CG {1}= {2} torr. Max wait {3} min</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TMMechanicalPumpGreaterEqual</Key>" & _
"      <Value>{0}: TM Mechanical Pump CG &gt;= {1} torr</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TMMechanicalPumpGreater</Key>" & _
"      <Value>{0}: TM Mechanical Pump CG &gt; .1 torr</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>LLCGSmaller</Key>" & _
"      <Value>{0}: LL CG {1} {2} torr. Max wait {3} min</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>T2LoadLockCryoLessThan15K</Key>" & _
"      <Value>{0}: T2 of Load Lock Cryo not permit {1} {2}K  </Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>T2LoadLockCryoLessThan20K</Key>" & _
"      <Value>T2 of {0} Cryo {1} {2}K  </Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>T2TMCryoLessThan15K</Key>" & _
"      <Value>T2 of {0} Cryo {1} {2}K  </Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CryoT1TempLessThan</Key>" & _
"      <Value>T1 of {0} Cryo less than {1}K  </Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>DidNotOpenValve</Key>" & _
"      <Value>{0}: did not open valve</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IGWasNotOn</Key>" & _
"      <Value>{0}: IG was not on</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>LLHiVacWasNotClose</Key>" & _
"      <Value>{0}: LL HiVac was not closed</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>LLFastRoughWasNotClose</Key>" & _
"      <Value>{0}: Fast Rough was not closed</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>LLFastVentWasNotClose</Key>" & _
"      <Value>{0}: Fast Vent was not closed</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TMVentValvesWasNotClose</Key>" & _
"      <Value>{0}: Vent valves were not closed</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TMRoughValvesWasNotClose</Key>" & _
"      <Value>{0}: Rough Valves were not closed</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>LLSlowRoughWasNotClose</Key>" & _
"      <Value>{0}: Slow Rough was not closed</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>LLSlowVentWasNotClose</Key>" & _
"      <Value>{0}: Slow Vent was not closed</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>LLSlowRoughWasNotOpen</Key>" & _
"      <Value>{0}: Slow Rough was not Opened</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>LLFastRoughWasNotOpen</Key>" & _
"      <Value>{0}: Fast Rough was not Opened</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>LLSlowVentWasNotOpen</Key>" & _
"      <Value>{0}: Slow Vent was not Opened</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>LLFastVentWasNotOpen</Key>" & _
"      <Value>{0}: Fast Vent was not Opened</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>LLIGWasNotOff</Key>" & _
"      <Value>{0}: IG was not Off</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TMIGWasNotOff</Key>" & _
"      <Value>{0}: IG was not Off</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>LLIsolationValveWasNotClose</Key>" & _
"      <Value>{0}: LL Isolation Valve was not Closed</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>DoorWasNotClose</Key>" & _
"      <Value>{0}: Door was not Closed</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>RobotWasNotRetract</Key>" & _
"      <Value>{0}: Robot was not Retracted</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>RobotLLASlitValveMustBeClosed</Key>" & _
"      <Value>{0}: LLA.SlitValveStatus must not be opened</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>RobotLLBSlitValveMustBeClosed</Key>" & _
"      <Value>{0}: LLB.SlitValveStatus must not be opened</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>FailedGetRoughLinePumpDown</Key>" & _
"      <Value>{0}: Failed to get Rough Line for Pump-Down</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>WriteKepserverError</Key>" & _
"      <Value>Couldn't write to Kep Server with the tag {0}. (Actioning Valve: {1})</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>KepserverError</Key>" & _
"      <Value>Couldn't write to Kep Server (Actioning Valve: {0})</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>HivacValveDidNotOpen</Key>" & _
"      <Value>{0}: Hivac Valve did not Open</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>HivacValveDidNotClose</Key>" & _
"      <Value>{0}: Hivac Valve did not closed</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IGDidNotOn</Key>" & _
"      <Value>{0}: IG did not On</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>BasePressureDidNotReach</Key>" & _
"      <Value>{0}: Base Pressure did not Reach</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBERecipeFileCopyError</Key>" & _
"      <Value>Copy file Recipe Error</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemOnlineError</Key>" & _
"      <Value>All related equipments are not Online</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemOnlineLLAError</Key>" & _
"      <Value>Load Lock A is not Online</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemOnlineLLBError</Key>" & _
"      <Value>Load Lock B is not Online</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemOnlineTMError</Key>" & _
"      <Value>Transfer Module is not Online</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>RFPowerSupply.txtForwardPowerRight</Key>" & _
"      <Value>Forward Power Set Point for 'Power Supply'</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>BeamPowerSupplyControl.txtCurrentRight</Key>" & _
"      <Value>Current Set Point for 'Beam Power Supply'</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>BeamPowerSupplyControl.txtVoltageRight</Key>" & _
"      <Value>Voltage Set Point for 'Beam Voltage Supply'</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>BeamPowerSupplyControl.txtPowerRight</Key>" & _
"      <Value>Power Set Point for 'Beam Power Supply'</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>RFPowerSupply.txtReflectedPowerRight</Key>" & _
"      <Value>Reflected Power Set Point for 'RF Power Supply'</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SuppressorPowerSupplyControl.txtCurrentRight</Key>" & _
"      <Value>Current Set Point for 'Supp Power Supply'</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SuppressorPowerSupplyControl.txtVoltageRight</Key>" & _
"      <Value>Voltage Set Point for 'Supp Power Supply'</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>BodyPowerSupply.txtKFactorRight</Key>" & _
"      <Value>K Factor Set Point for 'Body Power Supply'</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>BACenterControl.txtCG2</Key>" & _
"      <Value>CG Set Point for 'BA Center Control'</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>BaCenterControlbigcgIGOpen</Key>" & _
"      <Value>Would you like to open 'IG'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>BaCenterControlbigcgIGClose</Key>" & _
"      <Value>Would you like to close 'IG'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>GasControllerControl.txtArgonRight</Key>" & _
"      <Value>Argon Set Point for 'Gas Controller'</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>GasControllerControl.txtPBNRight</Key>" & _
"      <Value>PBN Set Point for 'Gas Controller'</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>GasControllerControl.txtFlowCoolHeRight</Key>" & _
"      <Value>FlowCoolHe Set Point for 'Gas Controller'</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>FixtureControl.txtTiltAngleRight</Key>" & _
"      <Value>Tilt Angle Set for 'Fixture Control'</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>FixtureControl.txtRotationRight</Key>" & _
"      <Value>Rotation {0} Set for 'Fixture Control'</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>FixtureControl.txtRotationLastRight</Key>" & _
"      <Value>Rotation End Set for 'Fixture Control'</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ResetWaferCounter</Key>" & _
"      <Value>Would you like to reset Wafer Counter ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CheckOnlineLLA_Error</Key>" & _
"      <Value>Load lock A is not online</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CheckOnlineLLB_Error</Key>" & _
"      <Value>Load lock B is not online</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CheckOnlineTM_Error</Key>" & _
"      <Value>Transfer Module is not online</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CheckOnlineChamber1_Error</Key>" & _
"      <Value>Chamber 1 is not online</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CheckOnlineChamber2_Error</Key>" & _
"      <Value>Chamber 2 is not online</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CheckOnlineChamber3_Error</Key>" & _
"      <Value>Chamber 3 is not online</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CheckOnlineChamber4_Error</Key>" & _
"      <Value>Chamber 4 is not online</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CheckOnlineChamber5_Error</Key>" & _
"      <Value>Chamber 5 is not online</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>LogoutMessage</Key>" & _
"      <Value>The current user will be logged out now.</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>LogoutSuccessfully</Key>" & _
"      <Value>User logged out successfully</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TransferPumpStatusOn</Key>" & _
"      <Value>Would you like to change {0} Pump Status to On?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TransferPumpStatusOff</Key>" & _
"      <Value>Would you like to change {0} Pump Status to Off?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TransferStartRegen</Key>" & _
"      <Value>Would you like to start regen again for {0}?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TransferAbortRegen</Key>" & _
"      <Value>Would you like to start regen for {0}?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TransferRunningRegen</Key>" & _
"      <Value>Would you like to abort regen for {0}?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>MenuOnlineOfCassettesPanel</Key>" & _
"      <Value>Would you like to online for {0}?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>MenuOfflineOfCassettesPanel</Key>" & _
"      <Value>Would you like to Offline for {0}?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>MenuPumpDownOfCassettesPanel</Key>" & _
"      <Value>Would you like to pump down for {0}?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>MenuStopPumpDownOfCassettesPanel</Key>" & _
"      <Value>Would you like to stop pump down for {0}?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>MenuVentOfCassettesPanel</Key>" & _
"      <Value>Would you like to vent for {0}?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>MenuStopVentOfCassettesPanel</Key>" & _
"      <Value>Would you like to stop vent for {0}?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>StartSemiAutoRobotCassettes</Key>" & _
"      <Value>Would you like to start the semi auto transferring ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SendSerialCommandRobotCassettes</Key>" & _
"      <Value>Would you like to send the serial command to {0}?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CheckMesaValveBeforeAction</Key>" & _
"      <Value>Please close isolation valve of {0}</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>GotoSlotRobotCassettes</Key>" & _
"      <Value>Would you like go to slot {0} of {1}?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>HomeRobotCassettes</Key>" & _
"      <Value>Would you like to home {0}?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>MapRobotCassettes</Key>" & _
"      <Value>Would you like to map {0}?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>OpenRobotCassettes</Key>" & _
"      <Value>Would you like to open {0}?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CloseRobotCassettes</Key>" & _
"      <Value>Would you like to close {0}?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ResetRobotCassettes</Key>" & _
"      <Value>Would you like to reset {0}?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>HomeButtonCenterRobotCassettes</Key>" & _
"      <Value>Would you like to home Robot Cassettes?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>HomeMenuRobotCassettes</Key>" & _
"      <Value>Would you like to sent command home?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ScanOperationsAligner</Key>" & _
"      <Value>Would you like to sent command scan?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>AlignMenuRobotCassettes</Key>" & _
"      <Value>Would you like to sent command Align?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>MarkForReturnWafer</Key>" & _
"      <Value>Would you like to mark for return this wafer?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PauseWafer</Key>" & _
"      <Value>Would you like to pause this wafer?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ResumeWafer</Key>" & _
"      <Value>Would you like to resume this wafer?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>AbortWafer</Key>" & _
"      <Value>Would you like to abort this wafer?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>StartProcessPanel</Key>" & _
"      <Value>Would you like to {0} sequence [{1}] in {2}?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>AbortLoadProcessPanel</Key>" & _
"      <Value>Would you like to Abort Load in {0}?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>LoadProcessPanel</Key>" & _
"      <Value>Would you like to Load in {0}?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>AbortUnLoadProcessPanel</Key>" & _
"      <Value>Would you like to Abort Unload in {0}?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>UnLoadProcessPanel</Key>" & _
"      <Value>Would you like to Unload in {0}?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>AbortProcessPanel</Key>" & _
"      <Value>Would you like to abort in {0}?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>OnClampChamberPanel</Key>" & _
"      <Value>Would you like to Clamp Up?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>UnClampChamberPanel</Key>" & _
"      <Value>Would you like to Clamp Down?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>FixtureWaterChamberPanel</Key>" & _
"      <Value>Would you like to Fixture Water?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>FixtureFlowCoolChamberPanel</Key>" & _
"      <Value>Would you like to Fixture Flow Cool?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>HomeAllAxisChamberPanel</Key>" & _
"      <Value>Would you like to home all axis?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>OpenShutterChamberPanel</Key>" & _
"      <Value>Would you like to open shutter?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CloseShutterChamberPanel</Key>" & _
"      <Value>Would you like to close shutter?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>StopAllAxisChamberPanel</Key>" & _
"      <Value>Would you like to stop all axis?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>HomeTiltAxisChamberPanel</Key>" & _
"      <Value>Would you like to home tilt axis?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>HomeRotationAxisChamberPanel</Key>" & _
"      <Value>Would you like to home rotation axis?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>StartRotationAxisChamberPanel</Key>" & _
"      <Value>Would you like to Start rotation axis?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>OfflineChamberPanel</Key>" & _
"      <Value>Would you like to Offline?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>OnlineChamberPanel</Key>" & _
"      <Value>Would you like to Online?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>StopPumpDownChamberPanel</Key>" & _
"      <Value>Would you like to stop Pump down?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>AbortPumpDownChamberPanel</Key>" & _
"      <Value>Would you like to abort Pump down?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>StartPumpDownChamberPanel</Key>" & _
"      <Value>Would you like to Start Pump down?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>StopVentChamberPanel</Key>" & _
"      <Value>Would you like to stop Vent?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>AbortVentChamberPanel</Key>" & _
"      <Value>Would you like to abort Vent?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>StartVentChamberPanel</Key>" & _
"      <Value>Would you like to Start Vent?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CryoOffChamberPanel</Key>" & _
"      <Value>Would you like to Cryo off?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CryoOnChamberPanel</Key>" & _
"      <Value>Would you like to Cryo on?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>WaterPumpOffChamberPanel</Key>" & _
"      <Value>Would you like to turn WaterPump off?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>WaterPumpOnChamberPanel</Key>" & _
"      <Value>Would you like to turn WaterPump on?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ShutDownPowerChamberPanel</Key>" & _
"      <Value>Would you like to Shut Down Power?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IGDegasChamberPanel</Key>" & _
"      <Value>Would you like to set IG Degas?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>AbortIGDegasChamberPanel</Key>" & _
"      <Value>Would you like to set Abort IG Degas?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PumpPurgeChamberPanel</Key>" & _
"      <Value>Would you like to set Pump Purge?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>AbortPumpPurgeChamberPanel</Key>" & _
"      <Value>Would you like to set Abort Pump Purge?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CryoRegenOnChamberPanel</Key>" & _
"      <Value>Would you like to Close Cryo Regen Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CryoRegenOffChamberPanel</Key>" & _
"      <Value>Would you like to Open Cryo Regen Valve ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>WaterPumpRegenOnChamberPanel</Key>" & _
"      <Value>Would you like to Abort WaterPump Regen ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>WaterPumpRegenOffChamberPanel</Key>" & _
"      <Value>Would you like to Start WaterPump Regen ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>OpenHivacChamberPanel</Key>" & _
"      <Value>Would you like to open hivac?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CloseHivacChamberPanel</Key>" & _
"      <Value>Would you like to close hivac?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CGOfTMAndRelatedEquipmentNoDiffer10</Key>" & _
"      <Value>Pressure of TM differ 10% with pressure of {0}</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>KepServerDisconnect</Key>" & _
"      <Value>KepServer is disconnected or error when connecting</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>LOTID_LL_ERR</Key>" & _
"      <Value>Please input a Slot ID for {0}</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SEQID_LL_ERR</Key>" & _
"      <Value>Please input a Sequence ID for {0}</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>LOTID_SEQID_LL_ERR</Key>" & _
"      <Value>Please input a Sequence ID and a Slot ID for {0}</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Wafer_Flow_New</Key>" & _
"      <Value>Would you like to save the current wafer flow?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>WaferProcessingError</Key>" & _
"      <Value>{0}: Wafer processing Error</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CommunicationError</Key>" & _
"      <Value>{0}: Communication Error</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.DiagnosticScreen.txtSampleTime</Key>" & _
"      <Value>Enter your Sample Time</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.DiagnosticScreen.txtTotalTime</Key>" & _
"      <Value>Enter your Total Time</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.DiagnosticScreen.btnStart.Start</Key>" & _
"      <Value>Do you want to start {0} ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.DiagnosticScreen.btnStart.Stop</Key>" & _
"      <Value>Do you want to stop {0} ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>EquipmentOffline</Key>" & _
"      <Value>{0} is Offline</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>EquipmentHasWafer</Key>" & _
"      <Value>{0} already has a wafer</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>EquipmentNotWorkProperly</Key>" & _
"      <Value>{0} is not working properly, its status is {1} </Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>EquipmentCouldNotFindRecipe</Key>" & _
"      <Value>{0} Couldn't find the recipe: {1} </Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>EquipmentCouldNotCopyFile</Key>" & _
"      <Value>Can not copy files to this path: {0} </Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>EquipmentCouldNotSendRunDatFile</Key>" & _
"      <Value>{0}: Couldn't send the Run Dat File Name: {1} </Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>EquipmentAllInterlocksAreNotMade</Key>" & _
"      <Value>{0}: All Interlocks are not made {1} </Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>EquipmentSlitValveStatusClosed</Key>" & _
"      <Value>{0}: SlitValveStatus must not be opened </Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>EquipmentDisconnect</Key>" & _
"      <Value>{0}: is disconnected. </Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>EquipmentCanNotWriteFileToPath</Key>" & _
"      <Value>{0}: Can not write to files with path: {1} </Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>EquipmentIsNotReady</Key>" & _
"      <Value>{0}: is not ready, its status: {1} </Value>" & _
"    </MessageText>" & _
"    <!--Loader-->" & _
"    <MessageText>" & _
"      <Key>LoaderDoorWasNotClosed</Key>" & _
"      <Value>Loader Door is not closed</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>LoaderArmWasNotRetracted</Key>" & _
"      <Value>Arm is not retracted</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>LoaderIsolationValveWasNotClosed</Key>" & _
"      <Value>Loader Isolation Valve is not closed</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>LoaderRoughValveWasNotClosed</Key>" & _
"      <Value>Loader Rough Valve is not closed</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>LoaderRoughValveWasNotOpen</Key>" & _
"      <Value>Loader rough valve is not open</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>LoaderVentValveWasNotClosed</Key>" & _
"      <Value>Loader vent valve is not closed</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ChamberHasWafer</Key>" & _
"      <Value>Chamber has wafer</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>FixtureMotionCannotInitialize</Key>" & _
"      <Value>Fixture motion cannot initialize</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>LoaderIsolationValveWasNotOpen</Key>" & _
"      <Value>Isolation valve is not open</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>LoaderArmUpTimeOut</Key>" & _
"      <Value>Robot Arm up timeout</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>LoaderArmExtendTimeOut</Key>" & _
"      <Value>Robot Arm extend timeout</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>LoaderArmRetractTimeOut</Key>" & _
"      <Value>Robot Arm retract timeout</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>LoaderArmDownTimeOut</Key>" & _
"      <Value>Robot Arm down timeout</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>RobotArmHasWafer</Key>" & _
"      <Value>Robot Arm has wafer</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IsolationValveIsNotClosed</Key>" & _
"      <Value>Isolation valve is not closed</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IsolationValveIsNotOpen</Key>" & _
"      <Value>Isolation valve is not open</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PressureIsNotEqualized</Key>" & _
"      <Value>Pressure is not equalized</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>RobotArmIsNotRetracted</Key>" & _
"      <Value>Robot arm is not retracted</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>LoaderVentTimeOut</Key>" & _
"      <Value>Pressure cannot reach ATM</Value>" & _
"    </MessageText>	" & _
"    <MessageText>" & _
"      <Key>LoaderPumpdownTimeOut</Key>" & _
"      <Value>Pressure cannot reach Vacuum</Value>" & _
"    </MessageText>	" & _
"	" & _
"	" & _
"  </UserMessageTexts>" & _
"  <VentPumpdownConfig>" & _
"    <LoaderConfig>" & _
"      <Item Name=""ArmUpDownTimeOut"" Value=""15000"" />" & _
"      <Item Name=""ArmExtendRetractTimeOut"" Value=""15000"" />" & _
"      <Item Name=""RobotUpDownMotorWaitTime"" Value=""2000"" />" & _
"      <Item Name=""RobotExtenRetractMotorWaitTime"" Value=""2000"" />" & _
"      <Item Name=""IsolationValveOpenCloseTimeOut"" Value=""2000"" />" & _
"      <Item Name=""RoughValveOpenCloseTimeOut"" Value=""2000"" />" & _
"      <Item Name=""VentValveOpenCloseTimeOut"" Value=""2000"" />" & _
"      <Item Name=""RoughTimeOut"" Value=""180000"" />" & _
"      <Item Name=""VentTimeOut"" Value=""180000"" />" & _
"      <Item Name=""IBEFixtureMotionInitializeTimeOut"" Value=""30000"" />" & _
"    </LoaderConfig>" & _
"  </VentPumpdownConfig>" & _
"  <ChambersConfiguration>" & _
"    <Configure>" & _
"      <Key>IBE_DEVICE_STATUS_CLOSED</Key>" & _
"      <Value>00</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>IBE_DEVICE_STATUS_OPEN</Key>" & _
"      <Value>01</Value>" & _
"    </Configure>" & _
"  </ChambersConfiguration>" & _
"  <TransferPressureSetpoint>" & _
"    <Configure>" & _
"      <Key>CassettesModuleTransferSetPoint</Key>" & _
"      <Value>44</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>LoadLockATransferSetPoint</Key>" & _
"      <Value>0.1</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>Chamber1TransferSetPoint</Key>" & _
"      <Value>6954</Value>" & _
"    </Configure>" & _
"  </TransferPressureSetpoint>" & _
"  <RobotAnimation>400</RobotAnimation>" & _
"  <DelayTimeForKeepAlive>40000</DelayTimeForKeepAlive>" & _
"</SystemConfiguration>"
    End Class
End Namespace
