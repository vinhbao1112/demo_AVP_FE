Namespace XMLResources
Public Class SystemConfig.xml
Public Const XMLText as String = _
"<SystemConfiguration>" & _
"  <ToolID>ABC</ToolID>" & _
"  <SystemTimeout>" & _
"    <Property Name=""LLACryo"" Timeout=""2500"" />" & _
"    <Property Name=""LLBCryo"" Timeout=""2500"" />" & _
"    <Property Name=""TMCryo"" Timeout=""2500"" />" & _
"    <Property Name=""LLAElevator"" Timeout=""2000"" />" & _
"    <Property Name=""LLBElevator"" Timeout=""2000"" />" & _
"    <Property Name=""Robot"" Timeout=""30000"" />" & _
"    <Property Name=""Aligner"" Timeout=""30000"" />" & _
"    <Property Name=""LLElevatorRequestStatus"" Timeout=""5000"" />" & _
"  </SystemTimeout>" & _
"  <SystemPolling>" & _
"    <Property Name=""LLACryo"" Timeout=""350"" IsLog=""False"" />" & _
"    <Property Name=""LLBCryo"" Timeout=""350"" IsLog=""False"" />" & _
"    <Property Name=""TMCryo"" Timeout=""350"" IsLog=""False"" />" & _
"    <Property Name=""LLAElevator"" Timeout=""200"" IsLog=""False"" />" & _
"    <Property Name=""LLBElevator"" Timeout=""200"" IsLog=""False"" />" & _
"    <Property Name=""Robot"" Timeout=""200"" IsLog=""False"" />" & _
"    <Property Name=""Aligner"" Timeout=""350"" IsLog=""False"" />" & _
"    <Property Name=""PVDStatusReport"" Timeout=""200"" IsLog=""False"" />" & _
"  </SystemPolling>" & _
"  <LLElevatorConfig>" & _
"    <LLAElevator>" & _
"      <Item Name=""NumberOfSlot"" Value=""12"" />" & _
"      <Item Name=""TravelLength"" Value=""9000"" />" & _
"      <Item Name=""Pitch"" Value=""3740"" />" & _
"      <Item Name=""BaseOffset"" Value=""9000"" />" & _
"      <Item Name=""FindBias"" Value=""9000"" />" & _
"    </LLAElevator>" & _
"    <LLBElevator>" & _
"      <Item Name=""NumberOfSlot"" Value=""12"" />" & _
"      <Item Name=""TravelLength"" Value=""9000"" />" & _
"      <Item Name=""Pitch"" Value=""3740"" />" & _
"      <Item Name=""BaseOffset"" Value=""9000"" />" & _
"      <Item Name=""FindBias"" Value=""9000"" />" & _
"    </LLBElevator>" & _
"  </LLElevatorConfig>" & _
"  <Initialization>" & _
"    <LLAElevator>" & _
"      <Property Name=""00,S,ER"" />" & _
"      <Property Name=""00,S,EC,N"" />" & _
"      <Property Name=""00,S,CF,NS,12"" />" & _
"      <Property Name=""00,S,CF,PT,3740"" />" & _
"      <Property Name=""00,S,CF,CT,9000"" />" & _
"      <Property Name=""00,S,CF,LM,9000"" />" & _
"      <Property Name=""00,S,FB,11000"" />" & _
"      <Property Name=""00,A,HM"" />" & _
"    </LLAElevator>" & _
"    <LLBElevator>" & _
"      <Property Name=""00,S,ER"" />" & _
"      <Property Name=""00,S,EC,N"" />" & _
"      <Property Name=""00,S,CF,NS,12"" />" & _
"      <Property Name=""00,S,CF,PT,3740"" />" & _
"      <Property Name=""00,S,CF,CT,9000"" />" & _
"      <Property Name=""00,S,CF,LM,9000"" />" & _
"      <Property Name=""00,S,FB,11000"" />" & _
"      <Property Name=""00,A,HM"" />" & _
"    </LLBElevator>" & _
"    <Robot>" & _
"      <Property Name=""SET COMM ALL PKT SEQ AUT"" />" & _
"      <Property Name=""SET IO ECHO N"" />" & _
"      <Property Name=""STORE COMM ALL"" />" & _
"      <Property Name=""HOME ALL"" />" & _
"      <Property Name=""GOTO N 1"" />" & _
"    </Robot>" & _
"    <Aligner>" & _
"      <Property Name=""SLIO M/B PKT BAUD 4 ECHO N"" />" & _
"      <Property Name=""LDCCDPOS 1 2700"" />" & _
"      <Property Name=""SLWF SIZE 5 CCD 1 FDCL NTCH"" />" & _
"      <Property Name=""HOME"" />" & _
"    </Aligner>" & _
"  </Initialization>" & _
"  <Robot>" & _
"    <Module>" & _
"      <Name>LoadLockA</Name>" & _
"      <Description>LoadLockA</Description>" & _
"      <StationLocation>1</StationLocation>" & _
"      <ShowModulesByDescription>0</ShowModulesByDescription>" & _
"    </Module>" & _
"    <Module>" & _
"      <Name>LoadLockB</Name>" & _
"      <Description>LoadLockB</Description>" & _
"      <StationLocation>7</StationLocation>" & _
"      <ShowModulesByDescription>0</ShowModulesByDescription>" & _
"    </Module>" & _
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
"          <IsPresent>0</IsPresent>" & _
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
"          <ChamberLid_Installed>0</ChamberLid_Installed>" & _
"          <MatchWater_Installed>0</MatchWater_Installed>" & _
"          <TargetWater_Installed>0</TargetWater_Installed>" & _
"          <LidWater_Installed>0</LidWater_Installed>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>PumpingPackage</Name>" & _
"          <CryoIsPresent>1</CryoIsPresent>" & _
"          <TurboPumpIsPresent>0</TurboPumpIsPresent>" & _
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
"    <Module>" & _
"      <Name>Chamber2</Name>" & _
"      <Description>PM2</Description>" & _
"      <StationLocation>3</StationLocation>" & _
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
"          <IsPresent>0</IsPresent>" & _
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
"          <ChamberLid_Installed>0</ChamberLid_Installed>" & _
"          <MatchWater_Installed>0</MatchWater_Installed>" & _
"          <TargetWater_Installed>0</TargetWater_Installed>" & _
"          <LidWater_Installed>0</LidWater_Installed>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>PumpingPackage</Name>" & _
"          <CryoIsPresent>1</CryoIsPresent>" & _
"          <TurboPumpIsPresent>0</TurboPumpIsPresent>" & _
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
"    <Module>" & _
"      <Name>Chamber3</Name>" & _
"      <Description>PM3</Description>" & _
"      <StationLocation>4</StationLocation>" & _
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
"          <IsPresent>0</IsPresent>" & _
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
"          <ChamberLid_Installed>0</ChamberLid_Installed>" & _
"          <MatchWater_Installed>0</MatchWater_Installed>" & _
"          <TargetWater_Installed>0</TargetWater_Installed>" & _
"          <LidWater_Installed>0</LidWater_Installed>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>PumpingPackage</Name>" & _
"          <CryoIsPresent>1</CryoIsPresent>" & _
"          <TurboPumpIsPresent>0</TurboPumpIsPresent>" & _
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
"    <Module>" & _
"      <Name>Chamber4</Name>" & _
"      <Description>PM4</Description>" & _
"      <StationLocation>5</StationLocation>" & _
"      <SubSystemList>" & _
"        <SubSystem>" & _
"          <Name>Real_Device_Enable</Name>" & _
"          <Value>0</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Target_Material</Name>" & _
"          <Value>12</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>TargetKWHWarningLimit</Name>" & _
"          <Value>10</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>TargetKWHAlarmLimit</Name>" & _
"          <Value>20</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Shutter_Visible</Name>" & _
"          <Value>1</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>MG</Name>" & _
"          <IsPresent>0</IsPresent>" & _
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
"          <ChamberLid_Installed>0</ChamberLid_Installed>" & _
"          <MatchWater_Installed>0</MatchWater_Installed>" & _
"          <TargetWater_Installed>0</TargetWater_Installed>" & _
"          <LidWater_Installed>0</LidWater_Installed>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>PumpingPackage</Name>" & _
"          <CryoIsPresent>1</CryoIsPresent>" & _
"          <TurboPumpIsPresent>0</TurboPumpIsPresent>" & _
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
"    <Module>" & _
"      <Name>Chamber5</Name>" & _
"      <Description>PM5</Description>" & _
"      <StationLocation>6</StationLocation>" & _
"      <SubSystemList>" & _
"        <SubSystem>" & _
"          <Name>Real_Device_Enable</Name>" & _
"          <Value>0</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Target_Material</Name>" & _
"          <Value>12</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>TargetKWHWarningLimit</Name>" & _
"          <Value>10</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>TargetKWHAlarmLimit</Name>" & _
"          <Value>20</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Shutter_Visible</Name>" & _
"          <Value>1</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>MG</Name>" & _
"          <IsPresent>0</IsPresent>" & _
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
"            <Preset id=""1"" C1=""1.01E+01"" C2=""6.00E+00"" />" & _
"            <Preset id=""2"" C1=""1.02E+01"" C2=""6.40E+01"" />" & _
"            <Preset id=""3"" C1=""4"" C2=""10.6"" />" & _
"            <Preset id=""4"" C1=""1.04E+01"" C2=""7.40E+01"" />" & _
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
"          <ChamberLid_Installed>0</ChamberLid_Installed>" & _
"          <MatchWater_Installed>0</MatchWater_Installed>" & _
"          <TargetWater_Installed>0</TargetWater_Installed>" & _
"          <LidWater_Installed>0</LidWater_Installed>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>PumpingPackage</Name>" & _
"          <CryoIsPresent>1</CryoIsPresent>" & _
"          <TurboPumpIsPresent>0</TurboPumpIsPresent>" & _
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
"    <Module>" & _
"      <Name>Aligner</Name>" & _
"      <Description>Aligner</Description>" & _
"      <StationLocation>9</StationLocation>" & _
"      <ShowModulesByDescription>0</ShowModulesByDescription>" & _
"    </Module>" & _
"    <Module>" & _
"      <Name>Robot</Name>" & _
"      <Description>Robot</Description>" & _
"      <StationLocation>9</StationLocation>" & _
"      <ShowModulesByDescription>0</ShowModulesByDescription>" & _
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
"      <Key>PVD.RFTargetPowerSupply.txtForwardPowerRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.RFTargetPowerSupply.txtForwardPowerRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.RFTargetPowerSupply.txtC1RightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.RFTargetPowerSupply.txtC1RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.RFTargetPowerSupply.txtC2RightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.RFTargetPowerSupply.txtC2RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.RFTargetPowerSupply.txtPresetsRightMax</Key>" & _
"      <Value>9</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.RFTargetPowerSupply.txtPresetsRightMin</Key>" & _
"      <Value>1</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.BiasPowerSupply.txtForwardPowerRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.BiasPowerSupply.txtForwardPowerRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.BiasPowerSupply.txtC1RightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.BiasPowerSupply.txtC1RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.BiasPowerSupply.txtC2RightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.BiasPowerSupply.txtC2RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.BiasPowerSupply.txtPresetsRightMax</Key>" & _
"      <Value>9</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.BiasPowerSupply.txtPresetsRightMin</Key>" & _
"      <Value>1</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ParallelMagnet.txtCurrentRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ParallelMagnet.txtCurrentRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ParallelMagnet.txtDutyRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ParallelMagnet.txtDutyRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ParallelMagnet.txtFrequencyRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ParallelMagnet.txtFrequencyRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.Baratron.txtCG2Max</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.Baratron.txtCG2Min</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ChuckControl.txtPos2Max</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ChuckControl.txtPos2Min</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.VatValveController.txtTeachMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.VatValveController.txtTeachMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.VatValveController.txtPressureMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.VatValveController.txtPressureMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.GasController.txtGas1RightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.GasController.txtGas1RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.GasController.txtGas2RightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.GasController.txtGas2RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.GasController.txtGas3RightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.GasController.txtGas3RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.GasController.txtGas4RightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.GasController.txtGas4RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.GasController.txtGas5RightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.GasController.txtGas5RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.DCTargetPowerSupply.txtTargetPowerRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.DCTargetPowerSupply.txtTargetPowerRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.DCTargetPowerSupply.txtTargetVoltageRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.DCTargetPowerSupply.txtTargetVoltageRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.DCTargetPowerSupply.txtTargetCurrentRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.DCTargetPowerSupply.txtTargetCurrentRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>RFPowerSupply.txtForwardPowerRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>RFPowerSupply.txtForwardPowerRightMax</Key>" & _
"      <Value>500000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>RFPowerSupply.txtReflectedPowerRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>RFPowerSupply.txtReflectedPowerRightMax</Key>" & _
"      <Value>500000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SuppressorPowerSupplyControl.txtCurrentRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SuppressorPowerSupplyControl.txtCurrentRightMax</Key>" & _
"      <Value>500000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SuppressorPowerSupplyControl.txtVoltageRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SuppressorPowerSupplyControl.txtVoltageRightMax</Key>" & _
"      <Value>500000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>BeamPowerSupplyControl.txtCurrentRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>BeamPowerSupplyControl.txtCurrentRightMax</Key>" & _
"      <Value>500000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>BeamPowerSupplyControl.txtVoltageRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>BeamPowerSupplyControl.txtVoltageRightMax</Key>" & _
"      <Value>500000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>BeamPowerSupplyControl.txtPowerRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>BeamPowerSupplyControl.txtPowerRightMax</Key>" & _
"      <Value>500000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>FixtureControl.txtTiltAngleRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>FixtureControl.txtTiltAngleRightMax</Key>" & _
"      <Value>500000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>FixtureControl.txtRotationRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>FixtureControl.txtRotationRightMax</Key>" & _
"      <Value>500000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>FixtureControl.txtRotationLastRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>FixtureControl.txtRotationLastRightMax</Key>" & _
"      <Value>500000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>GasControllerControl.txtArgonRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>GasControllerControl.txtArgonRightMax</Key>" & _
"      <Value>500000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>GasControllerControl.txtPBNRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>GasControllerControl.txtPBNRightMax</Key>" & _
"      <Value>500000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>GasControllerControl.txtFlowCoolHeRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>GasControllerControl.txtFlowCoolHeRightMax</Key>" & _
"      <Value>500000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>BodyPowerSupply.txtKFactorRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>BodyPowerSupply.txtKFactorRightMax</Key>" & _
"      <Value>500000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>BACenterControl.txtCG2Min</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>BACenterControl.txtCG2Max</Key>" & _
"      <Value>500000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.DiagnosticScreen.txtSampleTimeMin</Key>" & _
"      <Value>1</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.DiagnosticScreen.txtSampleTimeMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.DiagnosticScreen.txtTotalTimeMin</Key>" & _
"      <Value>1</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.DiagnosticScreen.txtTotalTimeMax</Key>" & _
"      <Value>50000</Value>" & _
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
"      <Key>LoadLockB</Key>" & _
"      <Value>2</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>Chamber1</Key>" & _
"      <Value>200</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>Chamber2</Key>" & _
"      <Value>200</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>Chamber3</Key>" & _
"      <Value>200</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>Chamber4</Key>" & _
"      <Value>200</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>Chamber5</Key>" & _
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
"      <Key>Chamber2_RoughPump_Max_Value</Key>" & _
"      <Value>150</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>Chamber3_RoughPump_Max_Value</Key>" & _
"      <Value>150</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>Chamber4_RoughPump_Max_Value</Key>" & _
"      <Value>150</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>Chamber5_RoughPump_Max_Value</Key>" & _
"      <Value>900</Value>" & _
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
"      <Key>LLBCryo_T2Min</Key>" & _
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
"      <Key>LLBCryo_T1Min</Key>" & _
"      <Value>10</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>Rotation_Tilt_Angle</Key>" & _
"      <Value>90</Value>" & _
"    </Configure>" & _
"  </SystemPressure>" & _
"  <KepServerTagsStatus>" & _
"    <!--LoadLockA.SlitValve-->" & _
"    <Action Name=""CassettesModule.SplitValve1 On"" Value=""TM.TMC.RO.Mesa1_Closed=False;TM.TMC.RO.Mesa1_Open=True"" />" & _
"    <Action Name=""CassettesModule.SplitValve1 Off"" Value=""TM.TMC.RO.Mesa1_Closed=True;TM.TMC.RO.Mesa1_Open=False"" />" & _
"    <Status Name=""CassettesModule.SlitValve1Status On"" Value=""TM.TMC.DI.Mesa1_Closed_FB=False;TM.TMC.DI.Mesa1_Open_FB=True"" />" & _
"    <Status Name=""CassettesModule.SlitValve1Status Off"" Value=""TM.TMC.DI.Mesa1_Closed_FB=True;TM.TMC.DI.Mesa1_Open_FB=False"" />" & _
"    <!--Chamber1.SlitValve-->" & _
"    <Action Name=""CassettesModule.SplitValve2 On"" Value=""TM.TMC.RO.Mesa2_Closed=False;TM.TMC.RO.Mesa2_Open=True"" />" & _
"    <Action Name=""CassettesModule.SplitValve2 Off"" Value=""TM.TMC.RO.Mesa2_Closed=True;TM.TMC.RO.Mesa2_Open=False"" />" & _
"    <Status Name=""CassettesModule.SlitValve2Status On"" Value=""TM.TMC.DI.Mesa2_Closed_FB=False;TM.TMC.DI.Mesa2_Open_FB=True"" />" & _
"    <Status Name=""CassettesModule.SlitValve2Status Off"" Value=""TM.TMC.DI.Mesa2_Closed_FB=True;TM.TMC.DI.Mesa2_Open_FB=False"" />" & _
"    <!--Chamber2.SlitValve-->" & _
"    <Action Name=""CassettesModule.SplitValve3 On"" Value=""TM.TMC.RO.Mesa3_Closed=False;TM.TMC.RO.Mesa3_Open=True"" />" & _
"    <Action Name=""CassettesModule.SplitValve3 Off"" Value=""TM.TMC.RO.Mesa3_Closed=True;TM.TMC.RO.Mesa3_Open=False"" />" & _
"    <Status Name=""CassettesModule.SlitValve3Status On"" Value=""TM.TMC.DI.Mesa3_Closed_FB=False;TM.TMC.DI.Mesa3_Open_FB=True"" />" & _
"    <Status Name=""CassettesModule.SlitValve3Status Off"" Value=""TM.TMC.DI.Mesa3_Closed_FB=True;TM.TMC.DI.Mesa3_Open_FB=False"" />" & _
"    <!--Chamber3.SlitValve-->" & _
"    <Action Name=""CassettesModule.SplitValve4 On"" Value=""TM.TMC.RO.Mesa4_Closed=False;TM.TMC.RO.Mesa4_Open=True"" />" & _
"    <Action Name=""CassettesModule.SplitValve4 Off"" Value=""TM.TMC.RO.Mesa4_Closed=True;TM.TMC.RO.Mesa4_Open=False"" />" & _
"    <Status Name=""CassettesModule.SlitValve4Status On"" Value=""TM.TMC.DI.Mesa4_Closed_FB=False;TM.TMC.DI.Mesa4_Open_FB=True"" />" & _
"    <Status Name=""CassettesModule.SlitValve4Status Off"" Value=""TM.TMC.DI.Mesa4_Closed_FB=True;TM.TMC.DI.Mesa4_Open_FB=False"" />" & _
"    <!--Chamber4.SlitValve-->" & _
"    <Action Name=""CassettesModule.SplitValve5 On"" Value=""TM.TMC.RO.Mesa5_Closed=False;TM.TMC.RO.Mesa5_Open=True"" />" & _
"    <Action Name=""CassettesModule.SplitValve5 Off"" Value=""TM.TMC.RO.Mesa5_Closed=True;TM.TMC.RO.Mesa5_Open=False"" />" & _
"    <Status Name=""CassettesModule.SlitValve5Status On"" Value=""TM.TMC.DI.Mesa5_Closed_FB=False;TM.TMC.DI.Mesa5_Open_FB=True"" />" & _
"    <Status Name=""CassettesModule.SlitValve5Status Off"" Value=""TM.TMC.DI.Mesa5_Closed_FB=True;TM.TMC.DI.Mesa5_Open_FB=False"" />" & _
"    <!--Chamber5.SlitValve-->" & _
"    <Action Name=""CassettesModule.SplitValve6 On"" Value=""TM.TMC.RO.Mesa6_Closed=False;TM.TMC.RO.Mesa6_Open=True"" />" & _
"    <Action Name=""CassettesModule.SplitValve6 Off"" Value=""TM.TMC.RO.Mesa6_Closed=True;TM.TMC.RO.Mesa6_Open=False"" />" & _
"    <Status Name=""CassettesModule.SlitValve6Status On"" Value=""TM.TMC.DI.Mesa6_Closed_FB=False;TM.TMC.DI.Mesa6_Open_FB=True"" />" & _
"    <Status Name=""CassettesModule.SlitValve6Status Off"" Value=""TM.TMC.DI.Mesa6_Closed_FB=True;TM.TMC.DI.Mesa6_Open_FB=False"" />" & _
"    <!--LoadLockB.SlitValve-->" & _
"    <Action Name=""CassettesModule.SplitValve7 On"" Value=""TM.TMC.RO.Mesa7_Closed=False;TM.TMC.RO.Mesa7_Open=True"" />" & _
"    <Action Name=""CassettesModule.SplitValve7 Off"" Value=""TM.TMC.RO.Mesa7_Closed=True;TM.TMC.RO.Mesa7_Open=False"" />" & _
"    <Status Name=""CassettesModule.SlitValve7Status On"" Value=""TM.TMC.DI.Mesa7_Closed_FB=False;TM.TMC.DI.Mesa7_Open_FB=True"" />" & _
"    <Status Name=""CassettesModule.SlitValve7Status Off"" Value=""TM.TMC.DI.Mesa7_Closed_FB=True;TM.TMC.DI.Mesa7_Open_FB=False"" />" & _
"    <!--LoadLockA.SlowVentValve-->" & _
"    <Action Name=""LoadLockA.LLSlowVent On"" Value=""TM.TMC.RO.Cas1_Sl_V=True"" />" & _
"    <Action Name=""LoadLockA.LLSlowVent Off"" Value=""TM.TMC.RO.Cas1_Sl_V=False"" />" & _
"    <Status Name=""LoadLockA.SlowVentValveStatus On"" Value=""TM.TMC.RO.Cas1_Sl_V=True"" />" & _
"    <Status Name=""LoadLockA.SlowVentValveStatus Off"" Value=""TM.TMC.RO.Cas1_Sl_V=False"" />" & _
"    <!--LoadLockA.FastVentValve-->" & _
"    <Action Name=""LoadLockA.LLFastVent On"" Value=""TM.TMC.RO.Cas1_Vent=True"" />" & _
"    <Action Name=""LoadLockA.LLFastVent Off"" Value=""TM.TMC.RO.Cas1_Vent=False"" />" & _
"    <Status Name=""LoadLockA.FastVentValveStatus On"" Value=""TM.TMC.RO.Cas1_Vent=True"" />" & _
"    <Status Name=""LoadLockA.FastVentValveStatus Off"" Value=""TM.TMC.RO.Cas1_Vent=False"" />" & _
"    <!--LoadLockA.SlowRoughValve-->" & _
"    <Action Name=""LoadLockA.LLSlowRough On"" Value=""TM.TMC.RO.Cas1_Sl_R=True"" />" & _
"    <Action Name=""LoadLockA.LLSlowRough Off"" Value=""TM.TMC.RO.Cas1_Sl_R=False"" />" & _
"    <Status Name=""LoadLockA.SlowRoughValveStatus On"" Value=""TM.TMC.RO.Cas1_Sl_R=True"" />" & _
"    <Status Name=""LoadLockA.SlowRoughValveStatus Off"" Value=""TM.TMC.RO.Cas1_Sl_R=False"" />" & _
"    <!--LoadLockA.FastRoughValve-->" & _
"    <Action Name=""LoadLockA.LLFastRough On"" Value=""TM.TMC.RO.Cas1_Rough=True"" />" & _
"    <Action Name=""LoadLockA.LLFastRough Off"" Value=""TM.TMC.RO.Cas1_Rough=False"" />" & _
"    <Status Name=""LoadLockA.FastRoughValveStatus On"" Value=""TM.TMC.RO.Cas1_Rough=True"" />" & _
"    <Status Name=""LoadLockA.FastRoughValveStatus Off"" Value=""TM.TMC.RO.Cas1_Rough=False"" />" & _
"    <!--LoadLockB.SlowVentValve-->" & _
"    <Action Name=""LoadLockB.LLSlowVent On"" Value=""TM.TMC.RO.Cas2_Sl_V=True"" />" & _
"    <Action Name=""LoadLockB.LLSlowVent Off"" Value=""TM.TMC.RO.Cas2_Sl_V=False"" />" & _
"    <Status Name=""LoadLockB.SlowVentValveStatus On"" Value=""TM.TMC.RO.Cas2_Sl_V=True"" />" & _
"    <Status Name=""LoadLockB.SlowVentValveStatus Off"" Value=""TM.TMC.RO.Cas2_Sl_V=False"" />" & _
"    <!--LoadLockB.FastVentValve-->" & _
"    <Action Name=""LoadLockB.LLFastVent On"" Value=""TM.TMC.RO.Cas2_Vent=True"" />" & _
"    <Action Name=""LoadLockB.LLFastVent Off"" Value=""TM.TMC.RO.Cas2_Vent=False"" />" & _
"    <Status Name=""LoadLockB.FastVentValveStatus On"" Value=""TM.TMC.RO.Cas2_Vent=True"" />" & _
"    <Status Name=""LoadLockB.FastVentValveStatus Off"" Value=""TM.TMC.RO.Cas2_Vent=False"" />" & _
"    <!--LoadLockB.SlowRoughValve-->" & _
"    <Action Name=""LoadLockB.LLSlowRough On"" Value=""TM.TMC.RO.Cas2_Sl_R=True"" />" & _
"    <Action Name=""LoadLockB.LLSlowRough Off"" Value=""TM.TMC.RO.Cas2_Sl_R=False"" />" & _
"    <Status Name=""LoadLockB.SlowRoughValveStatus On"" Value=""TM.TMC.RO.Cas2_Sl_R=True"" />" & _
"    <Status Name=""LoadLockB.SlowRoughValveStatus Off"" Value=""TM.TMC.RO.Cas2_Sl_R=False"" />" & _
"    <!--LoadLockB.FastRoughValve-->" & _
"    <Action Name=""LoadLockB.LLFastRough On"" Value=""TM.TMC.RO.Cas2_Rough=True"" />" & _
"    <Action Name=""LoadLockB.LLFastRough Off"" Value=""TM.TMC.RO.Cas2_Rough=False"" />" & _
"    <Status Name=""LoadLockB.FastRoughValveStatus On"" Value=""TM.TMC.RO.Cas2_Rough=True"" />" & _
"    <Status Name=""LoadLockB.FastRoughValveStatus Off"" Value=""TM.TMC.RO.Cas2_Rough=False"" />" & _
"    <!--CassettesModule.VentValve-->" & _
"    <Action Name=""CassettesModule.Vent On"" Value=""TM.TMC.RO.WTM_Vent=True"" />" & _
"    <Action Name=""CassettesModule.Vent Off"" Value=""TM.TMC.RO.WTM_Vent=False"" />" & _
"    <Status Name=""CassettesModule.FastVentValveStatus On"" Value=""TM.TMC.RO.WTM_Vent=True"" />" & _
"    <Status Name=""CassettesModule.FastVentValveStatus Off"" Value=""TM.TMC.RO.WTM_Vent=False"" />" & _
"    <!--CassettesModule.RoughValve-->" & _
"    <Action Name=""CassettesModule.Rough On"" Value=""TM.TMC.RO.WTM_Rough=True"" />" & _
"    <Action Name=""CassettesModule.Rough Off"" Value=""TM.TMC.RO.WTM_Rough=False"" />" & _
"    <Status Name=""CassettesModule.FastRoughValveStatus On"" Value=""TM.TMC.RO.WTM_Rough=True"" />" & _
"    <Status Name=""CassettesModule.FastRoughValveStatus Off"" Value=""TM.TMC.RO.WTM_Rough=False"" />" & _
"    <!--LoadLockA.HiVacValve-->" & _
"    <Action Name=""LoadLockA.LLHiVac On"" Value=""TM.TMC.RO.Cas1_HV=True"" />" & _
"    <Action Name=""LoadLockA.LLHiVac Off"" Value=""TM.TMC.RO.Cas1_HV=False"" />" & _
"    <Status Name=""LoadLockA.HiVacValveStatus On"" Value=""TM.TMC.DI.Cas1HiVac_V_LSB_FB=False;TM.TMC.DI.Cas1HiVac_V_MSB_FB=True"" />" & _
"    <Status Name=""LoadLockA.HiVacValveStatus Off"" Value=""TM.TMC.DI.Cas1HiVac_V_LSB_FB=True;TM.TMC.DI.Cas1HiVac_V_MSB_FB=False"" />" & _
"    <!--LoadLockB.HiVacValve-->" & _
"    <Action Name=""LoadLockB.LLHiVac On"" Value=""TM.TMC.RO.Cas2_HV=True"" />" & _
"    <Action Name=""LoadLockB.LLHiVac Off"" Value=""TM.TMC.RO.Cas2_HV=False"" />" & _
"    <Status Name=""LoadLockB.HiVacValveStatus On"" Value=""TM.TMC.DI.Cas2HiVac_V_LSB_FB=False;TM.TMC.DI.Cas2HiVac_V_MSB_FB=True"" />" & _
"    <Status Name=""LoadLockB.HiVacValveStatus Off"" Value=""TM.TMC.DI.Cas2HiVac_V_LSB_FB=True;TM.TMC.DI.Cas2HiVac_V_MSB_FB=False"" />" & _
"    <!--CassettesModule.HiVacValve-->" & _
"    <Action Name=""CassettesModule.TMHiVac On"" Value=""TM.TMC.RO.WTM_HV=True"" />" & _
"    <Action Name=""CassettesModule.TMHiVac Off"" Value=""TM.TMC.RO.WTM_HV=False"" />" & _
"    <Status Name=""CassettesModule.HiVacValveStatus On"" Value=""TM.TMC.DI.WTM_HiVac_V_LSB_FB=False;TM.TMC.DI.WTM_HiVac_V_MSB_FB=True"" />" & _
"    <Status Name=""CassettesModule.HiVacValveStatus Off"" Value=""TM.TMC.DI.WTM_HiVac_V_LSB_FB=True;TM.TMC.DI.WTM_HiVac_V_MSB_FB=False"" />" & _
"    <Status Name=""CassettesModule.VacSwitchStatus On"" Value=""TM.TMC.DI.WTM_VacSwitch_FB=True"" />" & _
"    <Status Name=""CassettesModule.VacSwitchStatus Off"" Value=""TM.TMC.DI.WTM_VacSwitch_FB=False"" />" & _
"    <!--LoadLockA.IGStatus-->" & _
"    <Action Name=""LoadLockA.Ion On"" Value=""TM.TMC.RO.Cas1Ion=True"" />" & _
"    <Action Name=""LoadLockA.Ion Off"" Value=""TM.TMC.RO.Cas1Ion=False"" />" & _
"    <Status Name=""LoadLockA.IGStatus On"" Value=""TM.TMC.DI.CAS1IgStatus_FB=True"" />" & _
"    <Status Name=""LoadLockA.IGStatus Off"" Value=""TM.TMC.DI.CAS1IgStatus_FB=False"" />" & _
"    <Status Name=""LoadLockA.VacSwitchStatus On"" Value=""TM.TMC.DI.Cas1VacSwitch_FB=True"" />" & _
"    <Status Name=""LoadLockA.VacSwitchStatus Off"" Value=""TM.TMC.DI.Cas1VacSwitch_FB=False"" />" & _
"    <!--LoadLockB.IGStatus-->" & _
"    <Action Name=""LoadLockB.Ion On"" Value=""TM.TMC.RO.Cas2Ion=True"" />" & _
"    <Action Name=""LoadLockB.Ion Off"" Value=""TM.TMC.RO.Cas2Ion=False"" />" & _
"    <Status Name=""LoadLockB.IGStatus On"" Value=""TM.TMC.DI.CAS2IgStatus_FB=True"" />" & _
"    <Status Name=""LoadLockB.IGStatus Off"" Value=""TM.TMC.DI.CAS2IgStatus_FB=False"" />" & _
"    <Status Name=""CassettesModule.VacSwitchStatus On"" Value=""TM.TMC.DI.Cas2VacSwitch_FB=True"" />" & _
"    <Status Name=""CassettesModule.VacSwitchStatus Off"" Value=""TM.TMC.DI.Cas2VacSwitch_FB=False"" />" & _
"    <!--CassettesModule.IGStatus-->" & _
"    <Action Name=""CassettesModule.Ion On"" Value=""TM.TMC.RO.WTM_Ion_S=True"" />" & _
"    <Action Name=""CassettesModule.Ion Off"" Value=""TM.TMC.RO.WTM_Ion_S=False"" />" & _
"    <Status Name=""CassettesModule.IGStatus On"" Value=""TM.TMC.DI.WTM_IgStatus_FB=True"" />" & _
"    <Status Name=""CassettesModule.IGStatus Off"" Value=""TM.TMC.DI.WTM_IgStatus_FB=False"" />" & _
"    <!--Sensors-->" & _
"    <Status Name=""CassettesModule.Sensor1Status On"" Value=""TM.TMC.DI.WaferSensor1_FB=True"" />" & _
"    <Status Name=""CassettesModule.Sensor1Status Off"" Value=""TM.TMC.DI.WaferSensor1_FB=False"" />" & _
"    <Status Name=""CassettesModule.Sensor2Status On"" Value=""TM.TMC.DI.WaferSensor2_FB=True"" />" & _
"    <Status Name=""CassettesModule.Sensor2Status Off"" Value=""TM.TMC.DI.WaferSensor2_FB=False"" />" & _
"    <Status Name=""CassettesModule.Sensor3Status On"" Value=""TM.TMC.DI.WaferSensor3_FB=True"" />" & _
"    <Status Name=""CassettesModule.Sensor3Status Off"" Value=""TM.TMC.DI.WaferSensor3_FB=False"" />" & _
"    <Status Name=""CassettesModule.Sensor4Status On"" Value=""TM.TMC.DI.WaferSensor4_FB=True"" />" & _
"    <Status Name=""CassettesModule.Sensor4Status Off"" Value=""TM.TMC.DI.WaferSensor4_FB=False"" />" & _
"    <Status Name=""CassettesModule.Sensor5Status On"" Value=""TM.TMC.DI.WaferSensor5_FB=True"" />" & _
"    <Status Name=""CassettesModule.Sensor5Status Off"" Value=""TM.TMC.DI.WaferSensor5_FB=False"" />" & _
"    <Status Name=""CassettesModule.Sensor6Status On"" Value=""TM.TMC.DI.WaferSensor6_FB=True"" />" & _
"    <Status Name=""CassettesModule.Sensor6Status Off"" Value=""TM.TMC.DI.WaferSensor6_FB=False"" />" & _
"    <Status Name=""CassettesModule.Sensor7Status On"" Value=""TM.TMC.DI.WaferSensor7_FB=True"" />" & _
"    <Status Name=""CassettesModule.Sensor7Status Off"" Value=""TM.TMC.DI.WaferSensor7_FB=False"" />" & _
"    <!--Alarms-->" & _
"    <Status Name=""Alarm.AlarmStatus On"" Value=""TM.TMC.RO.EMO_Alarm=True"" />" & _
"    <Status Name=""Alarm.AlarmStatus Off"" Value=""TM.TMC.RO.EMO_Alarm=False"" />" & _
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
"  </KepServerTagsStatus>" & _
"  <KepServerTagsDef>" & _
"    <Group Name=""TM.TMC"" IsActive=""True"" DeadBand=""0"" UpdateRate=""100"">" & _
"      <Item DisplayGroup=""TM.TMC"" PropertyName=""CassettesModule.KepWareServerDisConnected"" KepServerName=""TM.TMC._System._Error"" DataType=""Boolean"" Desc=""KepWare Connection"" />" & _
"      <Item DisplayGroup=""TM.TMC.AI"" PropertyName=""LoadLockA.CG"" KepServerName=""TM.TMC.AI.Cas1_GP275_FB"" DataType=""Double"" Desc=""Load Lock A - CG"" />" & _
"      <Item DisplayGroup=""TM.TMC.AI"" PropertyName=""LoadLockA.IG"" KepServerName=""TM.TMC.AI.Cas1_Ion_FB"" DataType=""Double"" Desc=""Load Lock A - IG"" />" & _
"      <Item DisplayGroup=""TM.TMC.AI"" PropertyName=""LoadLockB.CG"" KepServerName=""TM.TMC.AI.Cas2_GP275_FB"" DataType=""Double"" Desc=""Load Lock B - CG"" />" & _
"      <Item DisplayGroup=""TM.TMC.AI"" PropertyName=""LoadLockB.IG"" KepServerName=""TM.TMC.AI.Cas2_Ion_FB"" DataType=""Value"" Desc=""Load Lock B - IG"" />" & _
"      <Item DisplayGroup=""TM.TMC.AI"" PropertyName=""CassettesModule.CG"" KepServerName=""TM.TMC.AI.WTM_GP275_FB"" DataType=""Double"" Desc=""TM CG"" />" & _
"      <Item DisplayGroup=""TM.TMC.AI"" PropertyName=""CassettesModule.IG"" KepServerName=""TM.TMC.AI.WTM_Ion_V_FB"" DataType=""Double"" Desc=""TM IG"" />" & _
"      <Item DisplayGroup=""TM.TMC.AI"" PropertyName=""RoughPumpMachine.CG"" KepServerName=""TM.TMC.AI.WTM_MP275_FB"" DataType=""Double"" Desc=""RoughPumpMachine CG"" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""LoadLockA.HiVacValveStatus"" KepServerName=""TM.TMC.DI.Cas1HiVac_V_LSB_FB"" DataType=""Boolean"" Desc=""Load Lock A - Hivac Valve "" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""LoadLockA.HiVacValveStatus"" KepServerName=""TM.TMC.DI.Cas1HiVac_V_MSB_FB"" DataType=""Boolean"" Desc=""Load Lock A - Hivac Valve "" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""LoadLockA.IGStatus"" KepServerName=""TM.TMC.DI.CAS1IgStatus_FB"" DataType=""Boolean"" Desc=""Load Lock A - IGStatus"" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""LoadLockA.VacSwitchStatus"" KepServerName=""TM.TMC.DI.Cas1VacSwitch_FB"" DataType=""Boolean"" Desc=""Load Lock A - VacSwitch"" />" & _
"      <item DisplayGroup=""TM.TMC.DI"" PropertyName=""LoadLockB.HiVacValveStatus"" KepServerName=""TM.TMC.DI.Cas2HiVac_V_LSB_FB"" DataType=""Boolean"" Desc=""Load Lock B - Hivac Valve "" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""LoadLockB.HiVacValveStatus"" KepServerName=""TM.TMC.DI.Cas2HiVac_V_MSB_FB"" DataType=""Boolean"" Desc=""Load Lock B - Hivac Valve "" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""LoadLockB.IGStatus"" KepServerName=""TM.TMC.DI.CAS2IgStatus_FB"" DataType=""Boolean"" Desc=""Load Lock B - IGStatus"" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""LoadLockB.VacSwitchStatus"" KepServerName=""TM.TMC.DI.Cas2VacSwitch_FB"" DataType=""Boolean"" Desc=""Load Lock B - VacSwitch"" />" & _
"      <item DisplayGroup=""TM.TMC.DI"" PropertyName=""CassettesModule.HiVacValveStatus"" KepServerName=""TM.TMC.DI.WTM_HiVac_V_LSB_FB"" DataType=""Boolean"" Desc=""TM - Hivac Valve "" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""CassettesModule.HiVacValveStatus"" KepServerName=""TM.TMC.DI.WTM_HiVac_V_MSB_FB"" DataType=""Boolean"" Desc=""TM - Hivac Valve "" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""CassettesModule.IGStatus"" KepServerName=""TM.TMC.DI.WTM_IgStatus_FB"" DataType=""Boolean"" Desc=""TM Ig Status"" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""CassettesModule.VacSwitchStatus"" KepServerName=""TM.TMC.DI.WTM_VacSwitch_FB"" DataType=""Boolean"" Desc=""Vac Switch of TM"" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""CassettesModule.SlitValve1Status"" KepServerName=""TM.TMC.DI.Mesa1_Closed_FB"" DataType=""Boolean"" Desc=""Split Valve 1 Status"" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""CassettesModule.SlitValve1Status"" KepServerName=""TM.TMC.DI.Mesa1_Open_FB"" DataType=""Boolean"" Desc=""Split Valve 1 Status"" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""CassettesModule.SlitValve2Status"" KepServerName=""TM.TMC.DI.Mesa2_Closed_FB"" DataType=""Boolean"" Desc=""Split Valve 2 Status"" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""CassettesModule.SlitValve2Status"" KepServerName=""TM.TMC.DI.Mesa2_Open_FB"" DataType=""Boolean"" Desc=""Split Valve 2 Status"" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""CassettesModule.SlitValve3Status"" KepServerName=""TM.TMC.DI.Mesa3_Closed_FB"" DataType=""Boolean"" Desc=""Split Valve 3 Status"" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""CassettesModule.SlitValve3Status"" KepServerName=""TM.TMC.DI.Mesa3_Open_FB"" DataType=""Boolean"" Desc=""Split Valve 3 Status"" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""CassettesModule.SlitValve4Status"" KepServerName=""TM.TMC.DI.Mesa4_Closed_FB"" DataType=""Boolean"" Desc=""Split Valve 4 Status"" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""CassettesModule.SlitValve4Status"" KepServerName=""TM.TMC.DI.Mesa4_Open_FB"" DataType=""Boolean"" Desc=""Split Valve 4 Status"" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""CassettesModule.SlitValve5Status"" KepServerName=""TM.TMC.DI.Mesa5_Closed_FB"" DataType=""Boolean"" Desc=""Split Valve 5 Status"" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""CassettesModule.SlitValve5Status"" KepServerName=""TM.TMC.DI.Mesa5_Open_FB"" DataType=""Boolean"" Desc=""Split Valve 5 Status"" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""CassettesModule.SlitValve6Status"" KepServerName=""TM.TMC.DI.Mesa6_Closed_FB"" DataType=""Boolean"" Desc=""Split Valve 6 Status"" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""CassettesModule.SlitValve6Status"" KepServerName=""TM.TMC.DI.Mesa6_Open_FB"" DataType=""Boolean"" Desc=""Split Valve 6 Status"" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""CassettesModule.SlitValve7Status"" KepServerName=""TM.TMC.DI.Mesa7_Closed_FB"" DataType=""Boolean"" Desc=""Split Valve 7 Status"" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""CassettesModule.SlitValve7Status"" KepServerName=""TM.TMC.DI.Mesa7_Open_FB"" DataType=""Boolean"" Desc=""Split Valve 7 Status"" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""CassettesModule.Sensor1Status"" KepServerName=""TM.TMC.DI.WaferSensor1_FB"" DataType=""Boolean"" Desc=""Sensor of Load Lock A"" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""CassettesModule.Sensor2Status"" KepServerName=""TM.TMC.DI.WaferSensor2_FB"" DataType=""Boolean"" Desc=""Sensor of PM1"" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""CassettesModule.Sensor3Status"" KepServerName=""TM.TMC.DI.WaferSensor3_FB"" DataType=""Boolean"" Desc=""Sensor of PM2"" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""CassettesModule.Sensor4Status"" KepServerName=""TM.TMC.DI.WaferSensor4_FB"" DataType=""Boolean"" Desc=""Sensor of PM3"" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""CassettesModule.Sensor5Status"" KepServerName=""TM.TMC.DI.WaferSensor5_FB"" DataType=""Boolean"" Desc=""Sensor of PM4"" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""CassettesModule.Sensor6Status"" KepServerName=""TM.TMC.DI.WaferSensor6_FB"" DataType=""Boolean"" Desc=""Sensor of PM5"" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""CassettesModule.Sensor7Status"" KepServerName=""TM.TMC.DI.WaferSensor7_FB"" DataType=""Boolean"" Desc=""Sensor of Load Lock B"" />" & _
"      <Item DisplayGroup=""TM.TMC.RO"" PropertyName=""LoadLockA.FastRoughValveStatus"" KepServerName=""TM.TMC.RO.Cas1_Rough"" DataType=""Boolean"" Desc=""Rough Valve LLA"" />" & _
"      <Item DisplayGroup=""TM.TMC.RO"" PropertyName=""LoadLockA.SlowRoughValveStatus"" KepServerName=""TM.TMC.RO.Cas1_Sl_R"" DataType=""Boolean"" Desc=""Slow Rough LLA"" />" & _
"      <Item DisplayGroup=""TM.TMC.RO"" PropertyName=""LoadLockA.FastVentValveStatus"" KepServerName=""TM.TMC.RO.Cas1_Vent"" DataType=""Boolean"" Desc=""Vent Valve LLA"" />" & _
"      <Item DisplayGroup=""TM.TMC.RO"" PropertyName=""LoadLockA.SlowVentValveStatus"" KepServerName=""TM.TMC.RO.Cas1_Sl_V"" DataType=""Boolean"" Desc=""Slow Vent LLA"" />" & _
"      <Item DisplayGroup=""TM.TMC.RO"" PropertyName=""LoadLockB.FastRoughValveStatus"" KepServerName=""TM.TMC.RO.Cas2_Rough"" DataType=""Boolean"" Desc=""Rough Valve LLB"" />" & _
"      <Item DisplayGroup=""TM.TMC.RO"" PropertyName=""LoadLockB.SlowRoughValveStatus"" KepServerName=""TM.TMC.RO.Cas2_Sl_R"" DataType=""Boolean"" Desc=""Slow Rough LLB"" />" & _
"      <Item DisplayGroup=""TM.TMC.RO"" PropertyName=""LoadLockB.SlowVentValveStatus"" KepServerName=""TM.TMC.RO.Cas2_Sl_V"" DataType=""Boolean"" Desc=""Slow Vent LLB"" />" & _
"      <Item DisplayGroup=""TM.TMC.RO"" PropertyName=""LoadLockB.FastVentValveStatus"" KepServerName=""TM.TMC.RO.Cas2_Vent"" DataType=""Boolean"" Desc=""Vent Valve LLB"" />" & _
"      <Item DisplayGroup=""TM.TMC.RO"" PropertyName=""CassettesModule.FastRoughValveStatus"" KepServerName=""TM.TMC.RO.WTM_Rough"" DataType=""Boolean"" Desc=""TM Hivac Valve"" />" & _
"      <Item DisplayGroup=""TM.TMC.RO"" PropertyName=""CassettesModule.FastVentValveStatus"" KepServerName=""TM.TMC.RO.WTM_Vent"" DataType=""Boolean"" Desc=""TM Vent Valve"" />" & _
"      <Item DisplayGroup=""TM.TMC.RO"" PropertyName=""Alarm.AlarmStatus"" KepServerName=""TM.TMC.RO.EMO_Alarm"" DataType=""Boolean"" Desc=""Alarm"" />" & _
"      <Item DisplayGroup=""TM.TMC.RO"" PropertyName=""Alarm.RedStatus"" KepServerName=""TM.TMC.RO.System_Error"" DataType=""Boolean"" Desc=""System Error"" />" & _
"      <Item DisplayGroup=""TM.TMC.RO"" PropertyName=""Alarm.GreenStatus"" KepServerName=""TM.TMC.RO.System_Running"" DataType=""Boolean"" Desc=""System Running"" />" & _
"      <Item DisplayGroup=""TM.TMC.RO"" PropertyName=""Alarm.OrangeStatus"" KepServerName=""TM.TMC.RO.System_Idle"" DataType=""Boolean"" Desc=""System Idle"" />" & _
"      <Item DisplayGroup=""TM.TMC.RO"" PropertyName="""" KepServerName=""TM.TMC.RO.Cas1_HV"" DataType=""Boolean"" Desc=""Hivac LLA"" />" & _
"      <Item DisplayGroup=""TM.TMC.RO"" PropertyName="""" KepServerName=""TM.TMC.RO.Cas2_HV"" DataType=""Boolean"" Desc=""Hivac LLB"" />" & _
"      <Item DisplayGroup=""TM.TMC.RO"" PropertyName="""" KepServerName=""TM.TMC.RO.WTM_HV"" DataType=""Boolean"" Desc=""TM Hivac Valve"" />" & _
"      <Item DisplayGroup=""TM.TMC.RO"" PropertyName="""" KepServerName=""TM.TMC.RO.Mesa1_Open"" DataType=""Boolean"" Desc=""Mesa Valve LoadLock A"" />" & _
"      <Item DisplayGroup=""TM.TMC.RO"" PropertyName="""" KepServerName=""TM.TMC.RO.Mesa1_Closed"" DataType=""Boolean"" Desc=""Mesa Valve LoadLock A"" />" & _
"      <Item DisplayGroup=""TM.TMC.RO"" PropertyName="""" KepServerName=""TM.TMC.RO.Mesa2_Open"" DataType=""Boolean"" Desc=""Mesa Valve PM1"" />" & _
"      <Item DisplayGroup=""TM.TMC.RO"" PropertyName="""" KepServerName=""TM.TMC.RO.Mesa2_Closed"" DataType=""Boolean"" Desc=""Mesa Valve PM1"" />" & _
"      <Item DisplayGroup=""TM.TMC.RO"" PropertyName="""" KepServerName=""TM.TMC.RO.Mesa3_Open"" DataType=""Boolean"" Desc=""Mesa Valve PM2"" />" & _
"      <Item DisplayGroup=""TM.TMC.RO"" PropertyName="""" KepServerName=""TM.TMC.RO.Mesa3_Closed"" DataType=""Boolean"" Desc=""Mesa Valve PM2"" />" & _
"      <Item DisplayGroup=""TM.TMC.RO"" PropertyName="""" KepServerName=""TM.TMC.RO.Mesa4_Open"" DataType=""Boolean"" Desc=""Mesa Valve PM3"" />" & _
"      <Item DisplayGroup=""TM.TMC.RO"" PropertyName="""" KepServerName=""TM.TMC.RO.Mesa4_Closed"" DataType=""Boolean"" Desc=""Mesa Valve PM3"" />" & _
"      <Item DisplayGroup=""TM.TMC.RO"" PropertyName="""" KepServerName=""TM.TMC.RO.Mesa5_Open"" DataType=""Boolean"" Desc=""Mesa Valve PM4"" />" & _
"      <Item DisplayGroup=""TM.TMC.RO"" PropertyName="""" KepServerName=""TM.TMC.RO.Mesa5_Closed"" DataType=""Boolean"" Desc=""Mesa Valve PM4"" />" & _
"      <Item DisplayGroup=""TM.TMC.RO"" PropertyName="""" KepServerName=""TM.TMC.RO.Mesa6_Open"" DataType=""Boolean"" Desc=""Mesa Valve PM5"" />" & _
"      <Item DisplayGroup=""TM.TMC.RO"" PropertyName="""" KepServerName=""TM.TMC.RO.Mesa6_Closed"" DataType=""Boolean"" Desc=""Mesa Valve PM5"" />" & _
"      <Item DisplayGroup=""TM.TMC.RO"" PropertyName="""" KepServerName=""TM.TMC.RO.Mesa7_Open"" DataType=""Boolean"" Desc=""Mesa Valve LoadLock B"" />" & _
"      <Item DisplayGroup=""TM.TMC.RO"" PropertyName="""" KepServerName=""TM.TMC.RO.Mesa7_Closed"" DataType=""Boolean"" Desc=""Mesa Valve LoadLock B"" />" & _
"      <Item DisplayGroup=""TM.TMC.RO"" PropertyName="""" KepServerName=""TM.TMC.RO.WTM_Ion_S"" DataType=""Boolean"" Desc=""TM IG Status"" />" & _
"      <Item DisplayGroup=""TM.TMC.RO"" PropertyName="""" KepServerName=""TM.TMC.RO.Cas1Ion"" DataType=""Boolean"" Desc=""IG Status LLA"" />" & _
"      <Item DisplayGroup=""TM.TMC.RO"" PropertyName="""" KepServerName=""TM.TMC.RO.Cas2Ion"" DataType=""Boolean"" Desc=""IG Status LLB"" />" & _
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
"    <Property Name=""Aligner._ERR 0400"" Code=""0400: Encounter Error."" />" & _
"    <Property Name=""Robot._ERR 0400"" Code=""0400: Encounter Error."" />" & _
"    <Property Name=""LLAElevator._ERR 0400"" Code=""0400: Encounter Error."" />" & _
"    <Property Name=""LLBElevator._ERR 0400"" Code=""0400: Encounter Error."" />" & _
"    <Property Name=""TMCryo._ERR 0400"" Code=""0400: Encounter Error."" />" & _
"    <Property Name=""LLACryo._ERR 0400"" Code=""0400: Encounter Error."" />" & _
"    <Property Name=""LLBCryo._ERR 0400"" Code=""0400: Encounter Error."" />" & _
"    <Property Name=""Elevator.S0"" Code="": S0 - Character Input Overrun."" />" & _
"    <Property Name=""Elevator.S1"" Code="": S1 - Illegal SC Interrupt."" />" & _
"    <Property Name=""Elevator.S2"" Code="": S2 - Parity Error."" />" & _
"    <Property Name=""Elevator.S3"" Code="": S3 - Input Buffer Overflow."" />" & _
"    <Property Name=""Elevator.S4"" Code="": S4 - Illegal Record Type Or Incomplete Command Or Illegal Category Or Illegal Data."" />" & _
"    <Property Name=""Elevator.C0"" Code="": C0 - Illegal Slot Command."" />" & _
"    <Property Name=""Elevator.C1"" Code="": C1 - Illegal Action Command."" />" & _
"    <Property Name=""Elevator.C2"" Code="": C2 - Illegal Pitch Command."" />" & _
"    <Property Name=""Elevator.C3"" Code="": C3 - Illegal Cassette Type Offset Specified."" />" & _
"    <Property Name=""Elevator.C4"" Code="": C4 - Illegal Number Of Slots Specified."" />" & _
"    <Property Name=""Elevator.C5"" Code="": C5 - Illegal Partial Step Size Specified."" />" & _
"    <Property Name=""Elevator.C6"" Code="": C6 - Illegal Length Of Travel."" />" & _
"    <Property Name=""Elevator.C7"" Code="": C7 - Illegal Find Bias."" />" & _
"    <Property Name=""Elevator.C8"" Code="": C8 - Command Overrun."" />" & _
"    <Property Name=""Elevator.C9"" Code="": C9 - Illegal Command For Current Configuration."" />" & _
"    <Property Name=""Elevator.C10"" Code="": C10 - Set, Store, Or Action Command Received While Previous Action Still In Progress."" />" & _
"    <Property Name=""Elevator.A0"" Code="": A0 - Bottom Limit Encountered."" />" & _
"    <Property Name=""Elevator.A1"" Code="": A1 - Time Out Of Action Watchdog Timer."" />" & _
"    <Property Name=""Elevator.A2"" Code="": A2 - Undefined Instruction Trap."" />" & _
"    <Property Name=""Elevator.A3"" Code="": A3 - Bad Checksum (Not Resettable)."" />" & _
"    <Property Name=""Elevator.A4"" Code="": A4 - Open Door Prevented Motion, Or Door Opened During Motion."" />" & _
"    <Property Name=""Elevator.A5"" Code="": A5 - Platform Action Timeout."" />" & _
"    <Property Name=""Elevator.A6"" Code="": A6 - Door Action Timeout."" />" & _
"    <Property Name=""Elevator.A7"" Code="": A7 - Action Interlock."" />" & _
"    <Property Name=""Elevator.A8"" Code="": A8 - Wafer Slide Out Detected."" />" & _
"    <Property Name=""Elevator.A9"" Code="": A9 - Door Safety Switch Was Engaged During Door Close Action."" />" & _
"    <Property Name=""Elevator.A11"" Code="": A11 - Cassette Not Present."" />" & _
"    <Property Name=""Elevator.A12"" Code="": A12 - Cassette Is Present Prior To Pick."" />" & _
"    <Property Name=""Elevator.A13"" Code="": A13 - Cassette Is Not Present During Pick Command."" />" & _
"    <Property Name=""Elevator.A14"" Code="": A14 - Cassette Is Not Present Prior To Place."" />" & _
"    <Property Name=""Elevator.A15"" Code="": A15 - Cassette Is Present After A Place Command."" />" & _
"    <Property Name=""Elevator.A16"" Code="": A16 - Cassette Present On The Vce Platform (Servo Arm)."" />" & _
"    <Property Name=""Elevator.A17"" Code="": A17 - No New Cassette At Station After Load."" />" & _
"    <Property Name=""Elevator.A18"" Code="": A18 - Proximity Sensor A Is Blocked But Cassette Is Not Present."" />" & _
"    <Property Name=""Elevator.A19"" Code="": A19 - Cassette Is Present At Station A."" />" & _
"    <Property Name=""Elevator.A20"" Code="": A20 - Proximity Sensor A Is Blocked (Fixed Buffer)."" />" & _
"    <Property Name=""Elevator.M0"" Code="": M0 - A Move Was Issued Without Prior Referencing."" />" & _
"    <Property Name=""Elevator.M1"" Code="": M1 - Parameter Information For The Current Command Is Invalid."" />" & _
"    <Property Name=""Elevator.M2"" Code="": M2 - Loss Of Air."" />" & _
"    <Property Name=""Elevator.M3"" Code="": M3 - Platform Overspeed Error."" />" & _
"    <Property Name=""Elevator.M4"" Code="": M4 - Door Overspeed Error."" />" & _
"    <Property Name=""Elevator.M5"" Code="": M5 - Platform Sensor Fail."" />" & _
"    <Property Name=""Elevator.M6"" Code="": M6 - Door Sensor Fail."" />" & _
"    <Property Name=""Elevator.M7"" Code="": M7 - Lost Counts Detected."" />" & _
"    <Property Name=""Elevator.M8"" Code="": M8 - Maps Don'T Match During Auto Life Test."" />" & _
"    <Property Name=""Elevator.M9"" Code="": M9 - Not Used."" />" & _
"    <Property Name=""Elevator.M10"" Code="": M10 - Action Halted In Progress By Abort Command."" />" & _
"    <Property Name=""Elevator.M11"" Code="": M11 - Motor Drive Electronics Overtemperature."" />" & _
"    <Property Name=""Elevator.M12"" Code="": M12 - Motor Drive Electronics Overcurrent."" />" & _
"    <Property Name=""Elevator.M13"" Code="": M13 - Torque Limit Exceeded."" />" & _
"    <Property Name=""Elevator.M14"" Code="": M14 - Hard Tracking Error. Usually Caused By An Obstruction During Motion."" />" & _
"    <Property Name=""Elevator.R1"" Code="": R1 - R-Axis Is Unreferenced. R-Axis Must Be Homed."" />" & _
"    <Property Name=""Elevator.R2"" Code="": R2 - R-Axis Extension Position Is Undefined."" />" & _
"    <Property Name=""Elevator.R3"" Code="": R3 - Door Is Not Open. Platform Motion Other Than A,Hm,R Is Not Allowed Unless The Door Is Open."" />" & _
"    <Property Name=""Elevator.R4"" Code="": R4 - Z-Axis Not In The Correct Position For R-Axis Motion.Platform Must Be At The Load/Unload Position."" />" & _
"    <Property Name=""Elevator.R5"" Code="": R5 - R-Axis Travel Limit Exceeded."" />" & _
"    <Property Name=""Elevator.R6"" Code="": R6 - R-Axis Must Be Homed Before This Operation."" />" & _
"    <Property Name=""Elevator.R7"" Code="": R7 - R-Axis Orientation Not Set. Vce Does Not Know Whether It Is A Left Or Right Hand Unit."" />" & _
"    <Property Name=""Elevator.R8"" Code="": R8 - R-Axis Action Interlock."" />" & _
"    <Property Name=""Elevator.P1"" Code="": P1 - SPS Map Error."" />" & _
"    <Property Name=""Elevator.P2"" Code="": P2 - SPS Map Is Not Available."" />" & _
"    <Property Name=""Robot._ERR 1"" Code=""_Err 1 - Command Failed"" />" & _
"    <Property Name=""Robot._ERR 210"" Code=""_Err 210 - Not At Station"" />" & _
"    <Property Name=""Robot._ERR 220"" Code=""_Err 220 - Radial Axis Not At Retract Position"" />" & _
"    <Property Name=""Robot._ERR 221"" Code=""_Err 221 - Invalid Arm Selection"" />" & _
"    <Property Name=""Robot._ERR 233"" Code=""_Err 233 - Extend To Station Not Enabled"" />" & _
"    <Property Name=""Robot._ERR 234"" Code=""_Err 234 - Valve Not Closed"" />" & _
"    <Property Name=""Robot._ERR 301"" Code=""_Err 301 - Mnemonic Already Used"" />" & _
"    <Property Name=""Robot._ERR 305"" Code=""_Err 305 - Unrecognized Command; Expecting A Mnemonic"" />" & _
"    <Property Name=""Robot._ERR 309"" Code=""_Err 309 - Command Not Supported"" />" & _
"    <Property Name=""Robot._ERR 350"" Code=""_Err 350 - Parser Error, Bad Node In Parse Tree"" />" & _
"    <Property Name=""Robot._ERR 351"" Code=""_Err 351 - Parser Error, Stack Overflow"" />" & _
"    <Property Name=""Robot._ERR 352"" Code=""_Err 352 - Parse Error, No Memory Available"" />" & _
"    <Property Name=""Robot._ERR 353"" Code=""_Err 353 - Unexpected Mail To Uio Task"" />" & _
"    <Property Name=""Robot._ERR 390"" Code=""_Err 390 - Checksum Is Invalid"" />" & _
"    <Property Name=""Robot._ERR 402"" Code=""_Err 402 - Bad Slot Number"" />" & _
"    <Property Name=""Robot._ERR 405"" Code=""_Err 405 - Bad Lower Position"" />" & _
"    <Property Name=""Robot._ERR 406"" Code=""_Err 406 - Bad Pitch"" />" & _
"    <Property Name=""Robot._ERR 407"" Code=""_ERR 407 - Bad T Position"" />" & _
"    <Property Name=""Robot._ERR 408"" Code=""_Err 408 - Bad R Value"" />" & _
"    <Property Name=""Robot._ERR 409"" Code=""_Err 409 - Bad Z Value"" />" & _
"    <Property Name=""Robot._ERR 414"" Code=""_Err 414 - Push Value Must Be Positive"" />" & _
"    <Property Name=""Robot._ERR 415"" Code=""_Err 415 - Station R+Push Value Is Invalid"" />" & _
"    <Property Name=""Robot._ERR 416"" Code=""_Err 416 - Station Not Initialized"" />" & _
"    <Property Name=""Robot._ERR 417"" Code=""_Err 417 - Offset Too Large"" />" & _
"    <Property Name=""Robot._ERR 418"" Code=""_Err 418 - Bad Retract Position"" />" & _
"    <Property Name=""Robot._ERR 508"" Code=""_Err 508 - Wafer Sensor Not Defined"" />" & _
"    <Property Name=""Robot._ERR 509"" Code=""_Err 509 - No Z Axis On Robot"" />" & _
"    <Property Name=""Robot._ERR 550"" Code=""_Err 550 - Station Parameter Out Of Range"" />" & _
"    <Property Name=""Robot._ERR 551"" Code=""_Err 551 - Servo Parameter Out Of Range"" />" & _
"    <Property Name=""Robot._ERR 552"" Code=""_Err 552 - Sensor Out Of Range"" />" & _
"    <Property Name=""Robot._ERR 602"" Code=""_Err 602 - Command Sequencer Busy"" />" & _
"    <Property Name=""Robot._ERR 603"" Code=""_Err 603 - Command Halted"" />" & _
"    <Property Name=""Robot._ERR 604"" Code=""_Err 604 - CDM In Control Of The Robot"" />" & _
"    <Property Name=""Robot._ERR 605"" Code=""_Err 605 - Digital I/O In Control Of Robot"" />" & _
"    <Property Name=""Robot._ERR 606"" Code=""_Err 606 - Serial I/O In Control Of Robot"" />" & _
"    <Property Name=""Robot._ERR 607"" Code=""_Err 607 - MCC Processor Not Alive"" />" & _
"    <Property Name=""Robot._ERR 608"" Code=""_Err 608 - Robot Halting"" />" & _
"    <Property Name=""Robot._ERR 610"" Code=""_Err 610 - Emergency Stop On"" />" & _
"    <Property Name=""Robot._ERR 611"" Code=""_Err 611 - Warning, CDM Has Been Turned On"" />" & _
"    <Property Name=""Robot._ERR 612"" Code=""_Err 612 - Warning, CDM Has Been Turned Off"" />" & _
"    <Property Name=""Robot._ERR 613"" Code=""_Err 613 - UPS Battery Is Low"" />" & _
"    <Property Name=""Robot._ERR 652"" Code=""_Err 652 - Unable To Create Command Dispatcher"" />" & _
"    <Property Name=""Robot._ERR 653"" Code=""_Err 653 - Unexpected Mail Received By Dispatcher"" />" & _
"    <Property Name=""Robot._ERR 654"" Code=""_Err 654 - Unknown Command"" />" & _
"    <Property Name=""Robot._ERR 655"" Code=""_Err 655 - Bad Parameter Passed To Dispatcher"" />" & _
"    <Property Name=""Robot._ERR 656"" Code=""_Err 656 - Command Processing Has Finished"" />" & _
"    <Property Name=""Robot._ERR 711"" Code=""_Err 711 - Slot Valve Not Open"" />" & _
"    <Property Name=""Robot._ERR 721"" Code=""_Err 721 - Pick Failed"" />" & _
"    <Property Name=""Robot._ERR 722"" Code=""_Err 722 - Placed Failed"" />" & _
"    <Property Name=""Robot._ERR 730"" Code=""_Err 730 - RE Wafer Sensor Error Prior To Place: No Wafer Sensed"" />" & _
"    <Property Name=""Robot._ERR 731"" Code=""_Err 731 - RE Wafer Sensor Error After A Place: Wafer Sensed"" />" & _
"    <Property Name=""Robot._ERR 732"" Code=""_Err 732 - EX Wafer Sensor Error Prior To A Place: Wafer Sensed"" />" & _
"    <Property Name=""Robot._ERR 733"" Code=""_Err 733 - EX Wafer Sensor Error After A Place: No Wafer Sensed"" />" & _
"    <Property Name=""Robot._ERR 734"" Code=""_Err 734 - R_MT Wafer Sensor Error On A Place: No Wafer Sensed During Extend"" />" & _
"    <Property Name=""Robot._ERR 735"" Code=""_Err 735 - R_MT Wafer Sensor Failure"" />" & _
"    <Property Name=""Robot._ERR 736"" Code=""_Err 736 - R_MT Wafer Sensor Error On A Place: Wafer Sensed During Retract"" />" & _
"    <Property Name=""Robot._ERR 738"" Code=""_Err 738 - Active Option In Goto Supported For R_Mt Wafer Sensor Only"" />" & _
"    <Property Name=""Robot._ERR 739"" Code=""_Err 739 - R_Mt Wafer Sensor Error: Wafer Sensed On Mat_Off Move"" />" & _
"    <Property Name=""Robot._ERR 740"" Code=""_Err 740 - RE Wafer Sensor Error Prior To A Pick: Wafer Sensed"" />" & _
"    <Property Name=""Robot._ERR 741"" Code=""_Err 741 - RE Wafer Sensor Error After A Pick: No Wafer Sensed"" />" & _
"    <Property Name=""Robot._ERR 742"" Code=""_Err 742 - EX Wafer Sensor Error Prior To A Pick: No Wafer Sensed"" />" & _
"    <Property Name=""Robot._ERR 743"" Code=""_Err 743 - EX Wafer Sensor Error After A Pick: Wafer Sensed"" />" & _
"    <Property Name=""Robot._ERR 744"" Code=""_Err 744 - R_MT Wafer Sensor Error On A Pick: Wafer Sensed During Extend"" />" & _
"    <Property Name=""Robot._ERR 745"" Code=""_Err 745 - R_MT Wafer Sensor Error On A Pick: No Wafer Sensed During Retract"" />" & _
"    <Property Name=""Robot._ERR 749"" Code=""_Err 749 - R_MT Wafer Sensor Error: No Wafer Sensed On Mat_On Move"" />" & _
"    <Property Name=""Robot._ERR 750"" Code=""_Err 750 - No Station With R_MT Wafer Sensor Found For Arm A"" />" & _
"    <Property Name=""Robot._ERR 751"" Code=""_Err 751 - No Station With R_MT Wafer Sensor Found For Arm B"" />" & _
"    <Property Name=""Robot._ERR 800"" Code=""_ERR 800 - Bad configuration name"" />" & _
"    <Property Name=""Robot._ERR 801"" Code=""_Err 801 - Database Checksum Error"" />" & _
"    <Property Name=""Robot._ERR 802"" Code=""_Err 802 - Arm Not Configured"" />" & _
"    <Property Name=""Robot._ERR 803"" Code=""_Err 803 - Servo Not Configured"" />" & _
"    <Property Name=""Robot._ERR 804"" Code=""_Err 804 - Motor Not Configured"" />" & _
"    <Property Name=""Robot._ERR 805"" Code=""_Err 805 - Illegal Configuration For This Command"" />" & _
"    <Property Name=""Robot._ERR 810"" Code=""_Err 810 - Cannot Open Master Configuration File"" />" & _
"    <Property Name=""Robot._ERR 811"" Code=""_Err 811 - Cannot Read From Master Configuration File"" />" & _
"    <Property Name=""Robot._ERR 812"" Code=""_Err 812 - Cannot Open Object Data File"" />" & _
"    <Property Name=""Robot._ERR 813"" Code=""_Err 813 - Cannot Read Object Data File"" />" & _
"    <Property Name=""Robot._ERR 814"" Code=""_Err 814 - Cannot Open Object Data File"" />" & _
"    <Property Name=""Robot._ERR 815"" Code=""_Err 815 - Cannot Read Object Master File"" />" & _
"    <Property Name=""Robot._ERR 816"" Code=""_Err 816 - Cannot Open Current Configuration File"" />" & _
"    <Property Name=""Robot._ERR 817"" Code=""_Err 817 - Cannot Read From Current Configuration File"" />" & _
"    <Property Name=""Robot._ERR 818"" Code=""_Err 818 - Cannot Write To Current Configuration File"" />" & _
"    <Property Name=""Robot._ERR 819"" Code=""_Err 819 - Object Checksum Error"" />" & _
"    <Property Name=""Robot._ERR 820"" Code=""_Err 820 - Could Not Send Generic Object To Mcc"" />" & _
"    <Property Name=""Robot._ERR 821"" Code=""_Err 821 - Object Not Found"" />" & _
"    <Property Name=""Robot._ERR 822"" Code=""_Err 822 - Object Not Valid For Current Configuration"" />" & _
"    <Property Name=""Robot._ERR 823"" Code=""_Err 823 - Bad Group Type"" />" & _
"    <Property Name=""Robot._ERR 824"" Code=""_Err 824 - Bad Group Name"" />" & _
"    <Property Name=""Robot._ERR 825"" Code=""_Err 825 - Group Not Found"" />" & _
"    <Property Name=""Robot._ERR 826"" Code=""_Err 826 - Group Not Valid For Current Configuration"" />" & _
"    <Property Name=""Robot._ERR 827"" Code=""_Err 827 - Configuration Message To Mcc Timed Out"" />" & _
"    <Property Name=""Robot._ERR 850"" Code=""_Err 850 - End of database found"" />" & _
"    <Property Name=""Robot._ERR 851"" Code=""_Err 851 - Unable To Read From Database"" />" & _
"    <Property Name=""Robot._ERR 852"" Code=""_Err 852 - Unable To Write To Database"" />" & _
"    <Property Name=""Robot._ERR 853"" Code=""_Err 853 - Bad Database Handle Found"" />" & _
"    <Property Name=""Robot._ERR 854"" Code=""_Err 854 - Database Full"" />" & _
"    <Property Name=""Robot._ERR 855"" Code=""_Err 855 - Database Not Initialized"" />" & _
"    <Property Name=""Robot._ERR 857"" Code=""_Err 857 - Configuration Files Have Different Stamps"" />" & _
"    <Property Name=""Robot._ERR 860"" Code=""_Err 860 - Bad Parameter Passes To Memory System"" />" & _
"    <Property Name=""Robot._ERR 861"" Code=""_Err 861 - No Memory Available For Memory System"" />" & _
"    <Property Name=""Robot._ERR 862"" Code=""_Err 862 - Partition currently in use"" />" & _
"    <Property Name=""Robot._ERR 950"" Code=""_Err 950 - Unexpected Mail Received By Monitor"" />" & _
"    <Property Name=""Robot._ERR 951"" Code=""_Err 951 - No Monitor Resources Available"" />" & _
"    <Property Name=""Robot._ERR 952"" Code=""_Err 952 - Unknown Monitor Event Type"" />" & _
"    <Property Name=""Robot._ERR 953"" Code=""_Err 953 - Monitor Event Canceled"" />" & _
"    <Property Name=""Robot._ERR 954"" Code=""_Err 954 - Event Time-Out Occurred"" />" & _
"    <Property Name=""Robot._ERR 955"" Code=""_Err 955 - Monitored Event Occurred"" />" & _
"    <Property Name=""Robot._ERR 956"" Code=""_Err 956 - Bad Monitor Function Received"" />" & _
"    <Property Name=""Robot._ERR 1001"" Code=""_Err 1001 - Unknown I/O State Type"" />" & _
"    <Property Name=""Robot._ERR 1002"" Code=""_Err 1002 - Unknown I/O Name"" />" & _
"    <Property Name=""Robot._ERR 1003"" Code=""_Err 1003 - I/O Name Already In Use"" />" & _
"    <Property Name=""Robot._ERR 1004"" Code=""_Err 1004 - I/O System Out Of Memory"" />" & _
"    <Property Name=""Robot._ERR 1005"" Code=""_Err 1005 - Name Reserved By I/O System"" />" & _
"    <Property Name=""Robot._ERR 1006"" Code=""_Err 1006 - Illegal Number Of Bits For I/O Type"" />" & _
"    <Property Name=""Robot._ERR 1007"" Code=""_Err 1007 - Unknown I/O Block Name"" />" & _
"    <Property Name=""Robot._ERR 1008"" Code=""_Err 1008 - Bad I/O Bitmask"" />" & _
"    <Property Name=""Robot._ERR 1009"" Code=""_Err 1009 - Unknown I/O Type"" />" & _
"    <Property Name=""Robot._ERR 1010"" Code=""_Err 1010 - I/O Type Mismatch"" />" & _
"    <Property Name=""Robot._ERR 1011"" Code=""_Err 1011 - Incorrect I/O Channel Specified"" />" & _
"    <Property Name=""Robot._ERR 1012"" Code=""_Err 1012 - Bad I/O Handle"" />" & _
"    <Property Name=""Robot._ERR 1013"" Code=""_Err 1013 - Unknown I/O State"" />" & _
"    <Property Name=""Robot._ERR 1014"" Code=""_Err 1014 - I/O Is Write Only"" />" & _
"    <Property Name=""Robot._ERR 1015"" Code=""_Err 1015 - I/O Is Read Only"" />" & _
"    <Property Name=""Robot._ERR 1100"" Code=""_Err 1100 - Current Position Not Within Work Space"" />" & _
"    <Property Name=""Robot._ERR 1101"" Code=""_Err 1101 - Destination Position Not Within Work Space"" />" & _
"    <Property Name=""Robot._ERR 1102"" Code=""_Err 1102 - Work Spaces Do Not Overlap"" />" & _
"    <Property Name=""Robot._ERR 1103"" Code=""_Err 1103 - Work Space Interlock Occurred"" />" & _
"    <Property Name=""Robot._ERR 1104"" Code=""_Err 1104 - No More Work Spaces Available"" />" & _
"    <Property Name=""Robot._ERR 1105"" Code=""_Err 1105 - The Work Space Volume Must Be Specified"" />" & _
"    <Property Name=""Robot._ERR 1106"" Code=""_Err 1106 - Radial Maximum Is Less Than Radial Minimum"" />" & _
"    <Property Name=""Robot._ERR 1108"" Code=""_Err 1108 - Z Maximum Is Less Than Z Minimum"" />" & _
"    <Property Name=""Robot._ERR 1109"" Code=""_Err 1109 - Radial Minimum Is Greater Than Stored Radial Max"" />" & _
"    <Property Name=""Robot._ERR 1110"" Code=""_Err 1110 - Radial Maximum Is Less Than Stored Radial Min"" />" & _
"    <Property Name=""Robot._ERR 1113"" Code=""_Err 1113 - Z Minimum Is Greater Than Stored Z Maximum"" />" & _
"    <Property Name=""Robot._ERR 1114"" Code=""_Err 1114 - Z Maximum Is Less Than Stored Z Minimum"" />" & _
"    <Property Name=""Robot._ERR 1115"" Code=""_Err 1115 - Work Space Name Does Not Exist"" />" & _
"    <Property Name=""Robot._ERR 1118"" Code=""_Err 1118 - Invalid Station Number"" />" & _
"    <Property Name=""Robot._ERR 1119"" Code=""_Err 1119 - Reserved Work Space Name Used"" />" & _
"    <Property Name=""Robot._ERR 1300"" Code=""_Err 1300 - Bad Mail Message Received By Mcc"" />" & _
"    <Property Name=""Robot._ERR 1302"" Code=""_Err 1302 - Command Halted"" />" & _
"    <Property Name=""Robot._ERR 1307"" Code=""_Err 1307 - Mcc Queue Full"" />" & _
"    <Property Name=""Robot._ERR 1308"" Code=""_Err 1308 - Could Not Calculate MCC Command Id"" />" & _
"    <Property Name=""Robot._ERR 1309"" Code=""_Err 1309 - Dual Ported Ram Lock Fail"" />" & _
"    <Property Name=""Robot._ERR 1310"" Code=""_Err 1310 - Unable To Send To Mcc"" />" & _
"    <Property Name=""Robot._ERR 1311"" Code=""_Err 1311 - Error Opening MCC Code"" />" & _
"    <Property Name=""Robot._ERR 1312"" Code=""_Err 1312 - Error Reading MCC Code"" />" & _
"    <Property Name=""Robot._ERR 1313"" Code=""_Err 1313 - Mcc Task Can'T Access Dp Ram"" />" & _
"    <Property Name=""Robot._ERR 1314"" Code=""_Err 1314 - Mcc Dp Ram Memory Size Is Too Small"" />" & _
"    <Property Name=""Robot._ERR 1600"" Code=""_Err 1600 - Bad Date Format"" />" & _
"    <Property Name=""Robot._ERR 1602"" Code=""_Err 1602 - Year Out Of Range"" />" & _
"    <Property Name=""Robot._ERR 1603"" Code=""_Err 1603 - Month Out Of Range"" />" & _
"    <Property Name=""Robot._ERR 1604"" Code=""_Err 1604 - Day Out Of Range"" />" & _
"    <Property Name=""Robot._ERR 1605"" Code=""_Err 1605 - Hour Out Of Range"" />" & _
"    <Property Name=""Robot._ERR 1606"" Code=""_Err 1606 - Minute Out Of Range"" />" & _
"    <Property Name=""Robot._ERR 1607"" Code=""_Err 1607 - Second Out Of Range"" />" & _
"    <Property Name=""Robot._ERR 1800"" Code=""_Err 1800 - CDM Already Initialized"" />" & _
"    <Property Name=""Robot._ERR 1801"" Code=""_Err 1801 - CDM Escape Key Entered"" />" & _
"    <Property Name=""Robot._ERR 1802"" Code=""_Err 1802 - CDM Quit Key Entered"" />" & _
"    <Property Name=""Robot._ERR 1803"" Code=""_Err 1803 - CDM Bad Parameter"" />" & _
"    <Property Name=""Robot._ERR 1804"" Code=""_Err 1804 - CDM Move Aborted"" />" & _
"    <Property Name=""Robot._ERR 1805"" Code=""_Err 1805 - CDM Has Control Of Robot"" />" & _
"    <Property Name=""Robot._ERR 1900"" Code=""_Err 1900 - Unknown Serial Port"" />" & _
"    <Property Name=""Robot._ERR 1903"" Code=""_Err 1903 - Can'T Allocate Serial Port Semaphore"" />" & _
"    <Property Name=""Robot._ERR 1910"" Code=""_Err 1910 - Ssecondary Serial Port Mode"" />" & _
"    <Property Name=""Robot._ERR 2000"" Code=""_Err 2000 - No Memory Available For Multi-Tasker"" />" & _
"    <Property Name=""Robot._ERR 2001"" Code=""_Err 2001 - Multi-Tasking Kernel Error"" />" & _
"    <Property Name=""Robot._ERR 2002"" Code=""_Err 2002 - Bad Parameter Passed To Multi-Tasker"" />" & _
"    <Property Name=""Robot._ERR 2003"" Code=""_Err 2003 - Timeout Occurred"" />" & _
"    <Property Name=""Robot._ERR 2004"" Code=""_Err 2004 - Illegal Task Block Reequested"" />" & _
"    <Property Name=""Robot._ERR 2005"" Code=""_Err 2005 - No Resources Available"" />" & _
"    <Property Name=""Robot._ERR 2100"" Code=""_Err 2100 - Unable To Read From Nonvolatile Ram"" />" & _
"    <Property Name=""Robot._ERR 2101"" Code=""_Err 2101 - Unable To Write To Nonvolatile Ram"" />" & _
"    <Property Name=""Robot._ERR 2102"" Code=""_Err 2102 - Nonvolatile Ram Overflow"" />" & _
"    <Property Name=""Robot._ERR 2200"" Code=""_Err 2200 - No Memory Available For Mail System"" />" & _
"    <Property Name=""Robot._ERR 2202"" Code=""_Err 2202 - Error Initializing Mail System"" />" & _
"    <Property Name=""Robot._ERR 2203"" Code=""_Err 2203 - Unknown Task Id Passed To Mail System"" />" & _
"    <Property Name=""Robot._ERR 3000"" Code=""_Err 3000 - Trace Currently Running"" />" & _
"    <Property Name=""Robot._ERR 3001"" Code=""_Err 3001 - Trace Variable Already Set"" />" & _
"    <Property Name=""Robot._ERR 3002"" Code=""_Err 3002 - Trace Variable Not Set"" />" & _
"    <Property Name=""Robot._ERR 3003"" Code=""_Err 3003 - Bad Trace Variable Name"" />" & _
"    <Property Name=""Robot._ERR 3004"" Code=""_Err 3004 - Bad Trace Trigger Name"" />" & _
"    <Property Name=""Robot._ERR 3005"" Code=""_Err 3005 - No Trace Variables Set"" />" & _
"    <Property Name=""Robot._ERR 3011"" Code=""_Err 3011 - Bad Trad Period"" />" & _
"    <Property Name=""Robot._ERR 4001"" Code=""_Err 4001 - Serial Number Not Set"" />" & _
"    <Property Name=""Robot._ERR 4002"" Code=""_Err 4002 - System Not Configured"" />" & _
"    <Property Name=""Robot._ERR 4003"" Code=""_Err 4003 - System Already Born"" />" & _
"    <Property Name=""Robot._ERR 4004"" Code=""_Err 4004 - Operator Name Not Set"" />" & _
"    <Property Name=""Robot._ERR 4005"" Code=""_Err 4005 - Message Log Bad Record"" />" & _
"    <Property Name=""Robot._ERR 4006"" Code=""_Err 4006 - Message Log Not Found"" />" & _
"    <Property Name=""Robot._ERR 4007"" Code=""_Err 4007 - Message Log Write Error"" />" & _
"    <Property Name=""Robot._ERR 4008"" Code=""_Err 4008 - Message Log Seek Error"" />" & _
"    <Property Name=""Robot._ERR 4009"" Code=""_Err 4009 - Message Log Read Error"" />" & _
"    <Property Name=""Robot._ERR 4010"" Code=""_Err 4010 - Checksum Error In Message Log"" />" & _
"    <Property Name=""Robot._ERR 4011"" Code=""_Err 4011 - Beginning Of Message Log Encountered"" />" & _
"    <Property Name=""Robot._ERR 4012"" Code=""_Err 4012 - Error Log Not Initialized"" />" & _
"    <Property Name=""Robot._ERR 10000"" Code=""_Err 10000 - Default Debug Message From The Mcc"" />" & _
"    <Property Name=""Robot._ERR 10001"" Code=""_Err 10001 - Sync Error, Motor Moving Or Encoder Noisy"" />" & _
"    <Property Name=""Robot._ERR 10002"" Code=""_Err 10002 - MCC Board Memory Allocation Error"" />" & _
"    <Property Name=""Robot._ERR 10003"" Code=""_Err 10003 - MCC Board Unexpected Event Error"" />" & _
"    <Property Name=""Robot._ERR 10004"" Code=""_Err 10004 - MCC Board, Bad Command State"" />" & _
"    <Property Name=""Robot._ERR 10005"" Code=""_Err 10005 - MCC Board Sync Error, Can'T Move Motor"" />" & _
"    <Property Name=""Robot._ERR 10006"" Code=""_Err 10006 - MCC Encoder Vabs Adjusted (Small)"" />" & _
"    <Property Name=""Robot._ERR 10007"" Code=""_Err 10007 - Warning, Unable To Obtain Position"" />" & _
"    <Property Name=""Robot._ERR 10008"" Code=""_Err 10008 - MCC Unable To Hold Position"" />" & _
"    <Property Name=""Robot._ERR 10009"" Code=""_Err 10009 - MCC Hard Tracking Error"" />" & _
"    <Property Name=""Robot._ERR 10010"" Code=""_Err 10010 - MCC Soft Tracking Error"" />" & _
"    <Property Name=""Robot._ERR 10011"" Code=""_Err 10011 - Error, Motor Is Already Moving"" />" & _
"    <Property Name=""Robot._ERR 10012"" Code=""_Err 10012 - Error, Motor Is Not Configured"" />" & _
"    <Property Name=""Robot._ERR 10013"" Code=""_Err 10013 - Error, Motor Is Not Referenced"" />" & _
"    <Property Name=""Robot._ERR 10014"" Code=""_Err 10014 - Error, Motor Is Already Referencing"" />" & _
"    <Property Name=""Robot._ERR 10015"" Code=""_Err 10015 - Error, Motor Is Currently Moving"" />" & _
"    <Property Name=""Robot._ERR 10016"" Code=""_Err 10016 - Error, Unable To Calculate Trajectory"" />" & _
"    <Property Name=""Robot._ERR 10017"" Code=""_Err 10017 - Illegal Number Of Polls Calculated"" />" & _
"    <Property Name=""Robot._ERR 10018"" Code=""_Err 10018 - Unable To Calculate Absolute Position"" />" & _
"    <Property Name=""Robot._ERR 10019"" Code=""_Err 10019 - Error, Encoder Off By Many Sectors"" />" & _
"    <Property Name=""Robot._ERR 10020"" Code=""_Err 10020 - Error, Encoder Failed Multiple Times"" />" & _
"    <Property Name=""Robot._ERR 10021"" Code=""_Err 10021 - Error, Board Power Failure"" />" & _
"    <Property Name=""Robot._ERR 10022"" Code=""_Err 10022 - Error, Z Axis Overtravel Limit Reached"" />" & _
"    <Property Name=""Robot._ERR 10023"" Code=""_Err 10023 - Arm Actual Position Impossible, Check Sync Zero"" />" & _
"    <Property Name=""Robot._ERR 10024"" Code=""_Err 10024 - Error, Mcc Watchdog Timed Out"" />" & _
"    <Property Name=""Robot._ERR 10025"" Code=""_Err 10025 - Error, Defective R_Mt Type Wafer Sensor"" />" & _
"    <Property Name=""Robot._ERR 10026"" Code=""_Err 10026 - Error, Arm Load Not What Expected"" />" & _
"    <Property Name=""Robot._ERR 10028"" Code=""_Err 10028 - Error, Obstruction Encounter For Axis. If Condition Continues, Request Tsb-259 From Brooks Automation Technical Support"" />" & _
"    <Property Name=""Robot._ERR 10029"" Code=""_Err 10029 - Error, Emergency Stop Circuit Is Active"" />" & _
"    <Property Name=""Robot._ERR 10030"" Code=""_Err 10030 - Error, Excessive Current Detected"" />" & _
"    <Property Name=""Robot._ERR 10031"" Code=""_Err 10031 - Warning: Z Home Sensor Position Moved"" />" & _
"    <Property Name=""Robot._ERR 10032"" Code=""_Err 10032 - MCC Map Failed"" />" & _
"    <Property Name=""Robot._ERR 10034"" Code=""_Err 10034 - Error, Encoder Min/Max Value Out Of Range"" />" & _
"    <Property Name=""Robot._ERR 10035"" Code=""_Err 10035 - Error, Bad Sync Phase Offset Value"" />" & _
"    <Property Name=""Robot._ERR 10036"" Code=""_Err 10036 - Error, Robot Links Are Not Yet Defined"" />" & _
"    <Property Name=""Aligner._ERR 1"" Code=""._ERR 1 - Packet Error: Invalid Mnemonic"" />" & _
"    <Property Name=""Aligner._ERR 2"" Code=""._ERR 2 - Packet Error: Invalid Number Of Arguments"" />" & _
"    <Property Name=""Aligner._ERR 3"" Code=""._ERR 3 - Packet Error: Invalid Arguments"" />" & _
"    <Property Name=""Aligner._ERR 4"" Code=""._ERR 4 - Packet Error: Data Value Out Of Range"" />" & _
"    <Property Name=""Aligner._ERR 5"" Code=""._ERR 5 - Packet Error: Packet Syntax Incorrect"" />" & _
"    <Property Name=""Aligner._ERR 7"" Code=""._ERR 7  - Packet Error: Specified Command Not Available In Packet Mode"" />" & _
"    <Property Name=""Aligner._ERR 10"" Code=""._ERR 10 - Motor Move Error: Requested Move Out Of Bounds"" />" & _
"    <Property Name=""Aligner._ERR 11"" Code=""._ERR 11 - Homming Error: Optical End Stop Time Out"" />" & _
"    <Property Name=""Aligner._ERR 12"" Code=""._ERR 12 - Motor Move Error: Receive Location Out Of Travel Range"" />" & _
"    <Property Name=""Aligner._ERR 13"" Code=""._ERR 13 - Motor Move Error: Internal Motion Error"" />" & _
"    <Property Name=""Aligner._ERR 15"" Code=""._ERR 15 - Wafer Align Error: Align Retry Count Overflow"" />" & _
"    <Property Name=""Aligner._ERR 16"" Code=""._ERR 16 - Wafer Align Error: Wafer Characterization Error"" />" & _
"    <Property Name=""Aligner._ERR 17"" Code=""._ERR 17 - Wafer Align Error: No Wafer Detected"" />" & _
"    <Property Name=""Aligner._ERR 25"" Code=""._ERR 25 - Video Error: Video Data Bad"" />" & _
"    <Property Name=""Aligner._ERR 37"" Code=""._ERR 37 - EEPROM Checksum Error"" />" & _
"    <Property Name=""Aligner._ERR 40"" Code=""._ERR 40 - Analysis Result Error: No Result Available"" />" & _
"    <Property Name=""Aligner._ERR 41"" Code=""._ERR 41 - Motor Move Error: Out Of CCD Range"" />" & _
"    <Property Name=""Aligner._ERR 45"" Code=""._ERR 45 - Fatal Error: External RAM Failure"" />" & _
"    <Property Name=""Aligner._ERR 47"" Code=""._ERR 47 - EPROM Checksum Error"" />" & _
"    <Property Name=""Aligner._ERR 50"" Code=""._ERR 50 - Undefined Error"" />" & _
"    <Property Name=""Aligner._ERR 800"" Code=""._ERR 800 - Abnormal Notch Size"" />" & _
"    <Property Name=""Aligner._ERR 801"" Code=""._ERR 801 - Abnormal Flat Size"" />" & _
"    <Property Name=""Aligner._ERR 802"" Code=""._ERR 802 - Average Too Large"" />" & _
"    <Property Name=""Aligner._ERR 803"" Code=""._ERR 803 - Average Too Small"" />" & _
"    <Property Name=""Aligner._ERR 804"" Code=""._ERR 804 - No Distinct Fiducial Mark Detected"" />" & _
"    <Property Name=""Aligner._ERR 805"" Code=""._ERR 805 - Fiducial Too Large"" />" & _
"    <Property Name=""Aligner._ERR 806"" Code=""._ERR 806 - Wafer Too Small"" />" & _
"    <Property Name=""Aligner._ERR 807"" Code=""._ERR 807 - Wafer Too Large"" />" & _
"    <Property Name=""Aligner._ERR 821"" Code=""._ERR 821 - Noisy Data; Difference Between Successive Flashes Too Large"" />" & _
"    <Property Name=""Aligner._ERR 822"" Code=""._ERR 822 - Peak At Notch Too High; May Be Caused By Noisy Data"" />" & _
"    <Property Name=""Aligner._ERR 823"" Code=""._ERR 823 - Not Possible To Differentiate Between The Two Flats; May Be Caused By Noisy Data"" />" & _
"    <Property Name=""Aligner._ERR 824"" Code=""._ERR 824 - Start And/Or End Of Fiducial Mark Indistinct Due To Noisy Data"" />" & _
"    <Property Name=""Aligner._ERR 825"" Code=""._ERR 825 - Bad Fit Of Data With Fiducial(S)"" />" & _
"    <Property Name=""Aligner._ERR 850"" Code=""._ERR 850 - Video Time Out"" />" & _
"    <Property Name=""Aligner._ERR 851"" Code=""._ERR 851 - Video Read Error (During A Flash)"" />" & _
"    <Property Name=""Aligner._ERR 900"" Code=""._ERR 902 - Align Failure"" />" & _
"    <Property Name=""Aligner._ERR 901"" Code=""._ERR 901 - No Result Available"" />" & _
"  </SystemMessageError>" & _
"  <UserMessageTexts>" & _
"    <!--Begin PVD Message-->" & _
"    <!--System Setup-->" & _
"    <MessageText>" & _
"      <Key>SystemSetup.WarningKWH</Key>" & _
"      <Value>Enter your Warning KWH value</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.LimitKWH</Key>" & _
"      <Value>Enter your Limit KWH value</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.TarMaterial</Key>" & _
"      <Value>Enter your Tar Material value</Value>" & _
"    </MessageText>" & _
"    <!--DC Target Power Supply-->" & _
"    <MessageText>" & _
"      <Key>PVD.txtTargetPowerRight</Key>" & _
"      <Value>Would you like to change Power to?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.txtTargetVoltageRight</Key>" & _
"      <Value>Would you like to change Voltage to?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.txtTargetCurrentRight</Key>" & _
"      <Value>Would you like to change Current to?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.bicDCPulse.Open</Key>" & _
"      <Value>Would you like to change DC Pulse?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.bicDCPulse.Close</Key>" & _
"      <Value>Would you like to change DC Pulse?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.bicMagnetronRotation.Open</Key>" & _
"      <Value>Would you like to change Start Magnetron Rotation?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.bicMagnetronRotation.Close</Key>" & _
"      <Value>Would you like to change Stop Magnetron Rotation?</Value>" & _
"    </MessageText>" & _
"    <!--Bias + RF Target Power Supply-->" & _
"    <MessageText>" & _
"      <Key>PVD.txtForwardPowerRight</Key>" & _
"      <Value>Would you like to change Forward Power to?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.txtC1Right</Key>" & _
"      <Value>Would you like to change C1 to?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.txtC2Right</Key>" & _
"      <Value>Would you like to change C2 to?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.txtPresetsRight</Key>" & _
"      <Value>Would you like to change Presets to?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnAuto.Open</Key>" & _
"      <Value>Would you like to change to Manual?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnAuto.Close</Key>" & _
"      <Value>Would you like to change to Auto?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnRecall.Open</Key>" & _
"      <Value>Would you like to Recall location ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnRecall.Close</Key>" & _
"      <Value>Would you like to Recall location ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnStore.Open</Key>" & _
"      <Value>Would you like to Store location ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnStore.Close</Key>" & _
"      <Value>Would you like to Store location ?</Value>" & _
"    </MessageText>" & _
"    <!--Parallel Magnet-->" & _
"    <MessageText>" & _
"      <Key>PVD.btnStatus.Open</Key>" & _
"      <Value>Would you like to Turn Off Parallel Magnet?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnStatus.Close</Key>" & _
"      <Value>Would you like to Turn On Parallel Magnet?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.txtCurrentRight</Key>" & _
"      <Value>Would you like to change Current to?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.txtDutyRight</Key>" & _
"      <Value>Would you like to change Duty to?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.txtFrequencyRight</Key>" & _
"      <Value>Would you like to change Frequency to?</Value>" & _
"    </MessageText>" & _
"    <!--Chamber Interlock-->" & _
"    <MessageText>" & _
"      <Key>PVD.btnPSRelay.Open</Key>" & _
"      <Value>Would you like to Close PS Relay?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnPSRelay.Close</Key>" & _
"      <Value>Would you like to Open PS Relay?</Value>" & _
"    </MessageText>" & _
"    <!--Gas Controller -->" & _
"    <MessageText>" & _
"      <Key>PVD.txtGas1Right</Key>" & _
"      <Value>Would you like to change ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.txtGas2Right</Key>" & _
"      <Value>Would you like to change ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.txtGas3Right</Key>" & _
"      <Value>Would you like to change ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.txtGas4Right</Key>" & _
"      <Value>Would you like to change ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.txtGas5Right</Key>" & _
"      <Value>Would you like to change ?</Value>" & _
"    </MessageText>" & _
"    <!--Magnatron-->" & _
"    <MessageText>" & _
"      <Key>PVD.btnRotationStart.Open</Key>" & _
"      <Value>Would you like to Stop Rotation ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnRotationStart.Close</Key>" & _
"      <Value>Would you like to Start Rotation ?</Value>" & _
"    </MessageText>" & _
"    <!--Process Monitor-->" & _
"    <!--Run Recipe-->" & _
"    <MessageText>" & _
"      <Key>PVD.btnStart.Start.NoWafer</Key>" & _
"      <Value>No wafer to run recipe</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnStart.Start</Key>" & _
"      <Value>Would you like to Start Recipe ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnStart.Stop</Key>" & _
"      <Value>Would you like to Stop Recipe ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnPause.Pause</Key>" & _
"      <Value>Would you like to Pause Recipe ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnPause.Resume</Key>" & _
"      <Value>Would you like to Resume Recipe ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.Processing</Key>" & _
"      <Value>Waiting for PVD processing, please wait...</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnAbort</Key>" & _
"      <Value>Would you like to Abort current Step ?</Value>" & _
"    </MessageText>" & _
"    <!--Baratron-->" & _
"    <MessageText>" & _
"      <Key>PVD.bigcgIG.Open</Key>" & _
"      <Value>Would you like to Close IG?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.bigcgIG.Close</Key>" & _
"      <Value>Would you like to Open IG?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.txtCG2</Key>" & _
"      <Value>Would you like to change IG value ?</Value>" & _
"    </MessageText>" & _
"    <!--Vat Valve Controller-->" & _
"    <MessageText>" & _
"      <Key>PVD.txtTeach</Key>" & _
"      <Value>Would you like to change Teach value to?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.txtPressure</Key>" & _
"      <Value>Would you like to change Pressure value to ?</Value>" & _
"    </MessageText>" & _
"    <!--Cryo, Water Pump, Turbo Pump-->" & _
"    <MessageText>" & _
"      <Key>PVD.txtT1</Key>" & _
"      <Value>Would you like to change T1 value to ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.txtT2</Key>" & _
"      <Value>Would you like to change T2 value to ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnRegen.Open</Key>" & _
"      <Value>Would you like to Abort Regen ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnRegen.Close</Key>" & _
"      <Value>Would you like to Start Regen ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.bicWaterPump.Open</Key>" & _
"      <Value>Would you like to Close WaterPump ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.bicWaterPump.Close</Key>" & _
"      <Value>Would you like to Open WaterPump ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.bicTurboPump.Open</Key>" & _
"      <Value>Would you like to Close Turbo Pump ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.bicTurboPump.Close</Key>" & _
"      <Value>Would you like to Open Turbo Pump ?</Value>" & _
"    </MessageText>" & _
"    <!--Chuck-->" & _
"    <MessageText>" & _
"      <Key>PVD.txtPos2</Key>" & _
"      <Value>Would you like to change Position value to ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnShutter.Open</Key>" & _
"      <Value>Would you like to Close Shutter ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnShutter.Close</Key>" & _
"      <Value>Would you like to Open Shutter ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.bicPlasmaIgniter.Open</Key>" & _
"      <Value>Would you like to Close Plasma Igniter ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.bicPlasmaIgniter.Close</Key>" & _
"      <Value>Would you like to Open Plasma Igniter ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnHivacValve.Unknown</Key>" & _
"      <Value>Would you like to Open/Close Hivac Valve ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnShutter.Unknown</Key>" & _
"      <Value>Would you like to Open/Close Shutter ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnHivacValve.Close</Key>" & _
"      <Value>Would you like to Open Hivac Valve ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnHivacValve.Open</Key>" & _
"      <Value>Would you like to Close Hivac Valve ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnAutoZero.Open</Key>" & _
"      <Value>Would you like to Close Auto Zero Vat Valve ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnAutoZero.Close</Key>" & _
"      <Value>Would you like to Open Auto Zero Vat Valve ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnClamp.Close</Key>" & _
"      <Value>Would you like to Clamp ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnClamp.Open</Key>" & _
"      <Value>Would you like to UnClamp?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnSizeAdjust.Open</Key>" & _
"      <Value>Would you like to Close Size Adjust ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnSizeAdjust.Close</Key>" & _
"      <Value>Would you like to Open Size Adjust ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnTeach.Open</Key>" & _
"      <Value>Would you like to Send Teach ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnTeach.Close</Key>" & _
"      <Value>Would you like to Send Teach ?</Value>" & _
"    </MessageText>" & _
"    <!--Gas Valve-->" & _
"    <MessageText>" & _
"      <Key>PVD.ValveVent.Close</Key>" & _
"      <Value>Would you like to Open Valve Vent ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveVent.Open</Key>" & _
"      <Value>Would you like to Close Valve Vent ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveBaratron.Close</Key>" & _
"      <Value>Would you like to Open Valve Baratron ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveBaratron.Open</Key>" & _
"      <Value>Would you like to Close Valve Baratron ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveTurbo_Isolation.Close</Key>" & _
"      <Value>Would you like to Open Turbo Isolation Valve ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveTurbo_Isolation.Open</Key>" & _
"      <Value>Would you like to Close Turbo Isolation Valve ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveRough.Close</Key>" & _
"      <Value>Would you like to Open Rough Valve ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveRough.Open</Key>" & _
"      <Value>Would you like to Close Rough Valve ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveSupply1.Open</Key>" & _
"      <Value>Would you like to Close 'ValveSupply1'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveSupply1.Close</Key>" & _
"      <Value>Would you like to Open 'ValveSupply1'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveSupply2.Open</Key>" & _
"      <Value>Would you like to Close 'ValveSupply2'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveSupply2.Close</Key>" & _
"      <Value>Would you like to Open 'ValveSupply2'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveSupply3.Open</Key>" & _
"      <Value>Would you like to Close 'ValveSupply3'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveSupply3.Close</Key>" & _
"      <Value>Would you like to Open 'ValveSupply3'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveSupply4.Open</Key>" & _
"      <Value>Would you like to Close 'ValveSupply4' ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveSupply4.Close</Key>" & _
"      <Value>Would you like to Open 'ValveSupply4' ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveSupply5.Open</Key>" & _
"      <Value>Would you like to Close 'ValveSupply5'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveSupply5.Close</Key>" & _
"      <Value>Would you like to Open 'ValveSupply5' ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveShutOff1.Open</Key>" & _
"      <Value>Would you like to Close 'ValveShutOff1'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveShutOff1.Close</Key>" & _
"      <Value>Would you like to Open 'ValveShutOff1'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveShutOff2.Open</Key>" & _
"      <Value>Would you like to Close 'ValveShutOff2'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveShutOff2.Close</Key>" & _
"      <Value>Would you like to Open 'ValveShutOff2'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveShutOff3.Open</Key>" & _
"      <Value>Would you like to Close 'ValveShutOff3'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveShutOff3.Close</Key>" & _
"      <Value>Would you like to Open 'ValveShutOff3'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveShutOff4.Open</Key>" & _
"      <Value>Would you like to Close 'ValveShutOff4'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveShutOff4.Close</Key>" & _
"      <Value>Would you like to Open 'ValveShutOff4'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveShutOff5.Open</Key>" & _
"      <Value>Would you like to Close 'ValveShutOff5'?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveShutOff5.Close</Key>" & _
"      <Value>Would you like to Open 'ValveShutOff5'?</Value>" & _
"    </MessageText>" & _
"    <!--Auto Transfer Wafer-->" & _
"    <MessageText>" & _
"      <Key>TurnCycleWaferModeOnLoadLock</Key>" & _
"      <Value>You are turning Cycle Wafer Mode {0}!</Value>" & _
"    </MessageText>" & _
"    <!--Others-->" & _
"    <MessageText>" & _
"      <Key>PVD.btnOverrideMode.Open</Key>" & _
"      <Value>Would you like to set Override Mode to On ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnOverrideMode.Close</Key>" & _
"      <Value>Would you like to set Override Mode to Off ?</Value>" & _
"    </MessageText>" & _
"    <!--End PVD Message-->" & _
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
"      <Key>rrcHivacValveLLBOpen</Key>" & _
"      <Value>Would you like to open HiVacValve for ""Load Lock B""? </Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>rrcHivacValveLLBClose</Key>" & _
"      <Value>Would you like to close HiVacValve for ""Load Lock B""? </Value>" & _
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
"      <Value>Would you like to Abort Cryo Regen ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CryoRegenOffChamberPanel</Key>" & _
"      <Value>Would you like to Start Cryo Regen ?</Value>" & _
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
"  </UserMessageTexts>" & _
"  <VentPumpdownConfig>" & _
"    <LLVentConfig>" & _
"      <Item Name=""LLMesaValveOpenCloseTimeOut"" Value=""10000"" />" & _
"      <Item Name=""IGOnOffTimeOut"" Value=""30000"" />" & _
"      <Item Name=""LLHivacOpenCloseTimeOut"" Value=""2000"" />" & _
"      <Item Name=""LLASlowVentTimeOut"" Value=""180000"" />" & _
"      <Item Name=""LLBSlowVentTimeOut"" Value=""180000"" />" & _
"      <Item Name=""LLASlowVentPressure"" Value=""150"" />" & _
"      <Item Name=""LLBSlowVentPressure"" Value=""150"" />" & _
"      <Item Name=""LLAFastVentTimeOut"" Value=""300000"" />" & _
"      <Item Name=""LLBFastVentTimeOut"" Value=""300000"" />" & _
"      <Item Name=""LLAVentPressure"" Value=""760"" />" & _
"      <Item Name=""LLBVentPressure"" Value=""760"" />" & _
"      <Item Name=""LLVentValveOpenCloseTimeOut"" Value=""2000"" />" & _
"    </LLVentConfig>" & _
"    <LLPumpdownConfig>" & _
"      <Item Name=""LLMesaValveOpenCloseTimeOut"" Value=""10000"" />" & _
"      <Item Name=""IGOnOffTimeOut"" Value=""30000"" />" & _
"      <Item Name=""LLHivacOpenCloseTimeOut"" Value=""10000"" />" & _
"      <Item Name=""TMMechanicalPumpOnPressure"" Value=""0.1"" />" & _
"      <Item Name=""LLASlowRoughPressure"" Value=""500"" />" & _
"      <Item Name=""LLBSlowRoughPressure"" Value=""500"" />" & _
"      <Item Name=""LLASlowRoughPressureTimeOut"" Value=""600000"" />" & _
"      <Item Name=""LLBSlowRoughPressureTimeOut"" Value=""600000"" />" & _
"      <Item Name=""LLAFastRoughPressure"" Value=""0.15"" />" & _
"      <Item Name=""LLBFastRoughPressure"" Value=""0.15"" />" & _
"      <Item Name=""LLAFastRoughPressureTimeOut"" Value=""1500000"" />" & _
"      <Item Name=""LLBFastRoughPressureTimeOut"" Value=""1500000"" />" & _
"      <Item Name=""LLACryoColdTemp"" Value=""20"" />" & _
"      <Item Name=""LLBCryoColdTemp"" Value=""20"" />" & _
"      <Item Name=""IGOnDelay"" Value=""10000"" />" & _
"      <Item Name=""LLRoughValveOpenCloseTimeOut"" Value=""2000"" />" & _
"    </LLPumpdownConfig>" & _
"    <TMVentConfig>" & _
"      <Item Name=""TMMesaValvesOpenCloseTimeOut"" Value=""5000"" />" & _
"      <Item Name=""IGOnOffWaitTime"" Value=""30000"" />" & _
"      <Item Name=""TMHivacOpenCloseTimeOut"" Value=""5000"" />" & _
"      <Item Name=""TMVentPressure"" Value=""760"" />" & _
"      <Item Name=""TMVentTimeOut"" Value=""300000"" />" & _
"      <Item Name=""TMVentValveOpenCloseTimeOut"" Value=""2000"" />" & _
"    </TMVentConfig>" & _
"    <TMPumpdownConfig>" & _
"      <Item Name=""TMMesaValvesOpenCloseTimeOut"" Value=""5000"" />" & _
"      <Item Name=""IGOnOffTimeOut"" Value=""30000"" />" & _
"      <Item Name=""TMHivacOpenCloseTimeOut"" Value=""30000"" />" & _
"      <Item Name=""TMMechanicalPumpOnPressure"" Value=""0.1"" />" & _
"      <Item Name=""TMRoughPressure"" Value=""0.15"" />" & _
"      <Item Name=""TMRoughTimeOut"" Value=""300000"" />" & _
"      <Item Name=""TMCryoColdTemp"" Value=""20"" />" & _
"      <Item Name=""IGOnDelay"" Value=""10000"" />" & _
"    </TMPumpdownConfig>" & _
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
"      <Value>0.1</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>LoadLockATransferSetPoint</Key>" & _
"      <Value>0.1</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>Chamber1TransferSetPoint</Key>" & _
"      <Value>0.1</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>Chamber2TransferSetPoint</Key>" & _
"      <Value>0.12</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>Chamber3TransferSetPoint</Key>" & _
"      <Value>0.1</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>Chamber4TransferSetPoint</Key>" & _
"      <Value>0.1</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>Chamber5TransferSetPoint</Key>" & _
"      <Value>0.1</Value>" & _
"    </Configure>" & _
"  </TransferPressureSetpoint>" & _
"  <RobotAnimation>400</RobotAnimation>" & _
"  <DelayTimeForKeepAlive>40000</DelayTimeForKeepAlive>" & _
"</SystemConfiguration>"
End Class
End Namespace
