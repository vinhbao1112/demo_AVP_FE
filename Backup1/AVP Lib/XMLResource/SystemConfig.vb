Namespace XMLResources
Public Class SystemConfig
Public Const XMLText as String = _
"<SystemConfiguration>" & _
"  <ToolID>CX4 - 5T</ToolID>" & _
"  <SystemWaitFor_Check_Sensor_Secs>61</SystemWaitFor_Check_Sensor_Secs>" & _
"  <SystemIdle_Time>1800</SystemIdle_Time>" & _
"  <!-- Option 1. Admin logout only -->" & _
"  <!-- Option 2. Logout all user except operator -->" & _
"  <!-- Option 3. Logout all all user -->" & _
"  <AutoLogoutOption>1</AutoLogoutOption>" & _
"  <SystemCleanUpTimeInDays>90</SystemCleanUpTimeInDays>" & _
"  <SystemCleanUpDataRunTimeInDays>365</SystemCleanUpDataRunTimeInDays>" & _
"  <DelayTimeAfterProcessCompleteInMinutes>15</DelayTimeAfterProcessCompleteInMinutes>" & _
"  <RunDataFolder>.\DataFiles\DataRun</RunDataFolder>" & _
"  <SystemConfigFolder>.\DataFiles\ArchiveAllConfig</SystemConfigFolder>" & _
"  <AutoArchiveSystemConfigFile>True</AutoArchiveSystemConfigFile>" & _
"  <AutoArchiveDateTime>04/08/2026 0:10:14</AutoArchiveDateTime>" & _
"  <AutoArchiveStatus>True</AutoArchiveStatus>" & _
"  <Enable_ANYIBE_Mode>False</Enable_ANYIBE_Mode>" & _
"  <AutoVentWhenProcessingCompleted>False</AutoVentWhenProcessingCompleted>" & _
"  <AutoExportDataLogToCSV>True</AutoExportDataLogToCSV>" & _
"  <DefaultOnlineCtrState>True</DefaultOnlineCtrState>" & _
"  <AllowPopUpTerminalMessage>True</AllowPopUpTerminalMessage>" & _
"  <EnableQuickSequenceEditor>False</EnableQuickSequenceEditor>" & _
"  <NumberLightAlarm>3</NumberLightAlarm>" & _
"  <NumberActiveLight>3</NumberActiveLight>" & _
"  <SlowRoughInstalled>True</SlowRoughInstalled>" & _
"  <SlowVentInstalled>True</SlowVentInstalled>" & _
"  <Process_Complete_Chime_Installed>False</Process_Complete_Chime_Installed>" & _
"  <RequestDataChanged>True</RequestDataChanged>" & _
"  <ManualDefineGEMWaferID>False</ManualDefineGEMWaferID>" & _
"  <AllowCheckingECCLimit>True</AllowCheckingECCLimit>" & _
"  <ECC_M_Limit>30</ECC_M_Limit>" & _
"  <PasswordExitDeviceNetApp>Root</PasswordExitDeviceNetApp>" & _
"  <CheckWaferSlideOut>True</CheckWaferSlideOut>" & _
"  <EnableCycleATM>False</EnableCycleATM>" & _
"  <EnableReworkFeature>True</EnableReworkFeature>" & _
"  <Reset_Robot_Interlock_Command>True</Reset_Robot_Interlock_Command>" & _
"  <OneMainCryoControllerInstalled>False</OneMainCryoControllerInstalled>" & _
"  <ShowReworkFiles>False</ShowReworkFiles>" & _
"  <TotalGasFlowLimit>100</TotalGasFlowLimit>" & _
"  <EnableRunNo>False</EnableRunNo>" & _
"  <TMTurboSetPointFrequency>1000</TMTurboSetPointFrequency>" & _
"  <LLATurboSetPointFrequency>1000</LLATurboSetPointFrequency>" & _
"  <DeviceNet>" & _
"    <DeviceNetCardName>DN3-PCI-0000</DeviceNetCardName>" & _
"    <DeviceNetBaudRate>2</DeviceNetBaudRate>" & _
"  </DeviceNet>" & _
"  <SystemPolling>" & _
"    <Property Name=""LLAPumpPackage"" IsLog=""False"" />" & _
"    <Property Name=""TMPumpPackage"" IsLog=""False"" />" & _
"    <Property Name=""TMWaterPump"" IsLog=""False"" />" & _
"    <Property Name=""LLAElevator"" IsLog=""False"" />" & _
"    <Property Name=""Robot"" IsLog=""False"" />" & _
"    <Property Name=""Aligner"" IsLog=""False"" />" & _
"    <Property Name=""PVDStatusReport"" IsLog=""False"" />" & _
"    <Property Name=""IBEPollingCMD"" IsLog=""False"" />" & _
"    <Property Name=""PVD5TPollingCMD"" IsLog=""False"" />" & _
"  </SystemPolling>" & _
"  <LLElevatorConfig>" & _
"    <LLAElevator>" & _
"      <Item Name=""NumberOfSlot"" Value=""12"" />" & _
"      <Item Name=""TravelLength"" Value=""9151"" />" & _
"      <Item Name=""Pitch"" Value=""3851"" />" & _
"      <Item Name=""BaseOffset"" Value=""9001"" />" & _
"      <Item Name=""FindBias"" Value=""11150"" />" & _
"      <Item Name=""Wafer_Thickness_Type"" Value=""Thick"" />" & _
"    </LLAElevator>" & _
"    <StoredConfigs Name=""LLAElevator"">" & _
"      <Item SavedOn=""04/19/2023 11:32:26 AM"" Version="""">NumberOfSlots:25;TravelLength:9150;Pitch:3850;BaseOffset:9000;FindBias:11151</Item>" & _
"    </StoredConfigs>" & _
"  </LLElevatorConfig>" & _
"  <Initialization>" & _
"    <LLAElevator_VC2>" & _
"      <Property SCFNS_Command=""true"" />" & _
"      <Property SCFLM_Command=""true"" />" & _
"      <Property SCFPT_Command=""true"" />" & _
"      <Property SCFCT_Command=""true"" />" & _
"      <Property SFB_Command=""true"" />" & _
"    </LLAElevator_VC2>" & _
"    <LLAElevator_VC4>" & _
"      <Property SCFNS_Command=""true"" />" & _
"      <Property SCFLM_Command=""true"" />" & _
"      <Property SCFPT_Command=""true"" />" & _
"      <Property SCFCT_Command=""true"" />" & _
"      <Property SFB_Command=""true"" />" & _
"    </LLAElevator_VC4>" & _
"    <LLAElevator_VC6>" & _
"      <Property SCFNS_Command=""true"" />" & _
"      <Property SCFLM_Command=""true"" />" & _
"      <Property SCFPT_Command=""true"" />" & _
"      <Property SCFCT_Command=""true"" />" & _
"      <Property SFB_Command=""true"" />" & _
"    </LLAElevator_VC6>" & _
"  </Initialization>" & _
"  <MailInfo>" & _
"    <AutoSendMail>False</AutoSendMail>" & _
"    <SMTPServer>smtp.gmail.com</SMTPServer>" & _
"    <PortID>587</PortID>" & _
"    <UserName>avpemail24@gmail.com</UserName>" & _
"    <Password>fBppDBg9J02vdlpPDWhBoQ==</Password>" & _
"    <EmailTo>" & _
"      <Item Name=""ctc_guy2@gmail.com"" Alarm=""False"" Scheduler=""False"" Pressure=""False"" PressureInterval=""20"" />" & _
"      <Item Name=""ctc_guy1@gmail.com"" Alarm=""False"" Scheduler=""False"" Pressure=""False"" PressureInterval=""20"" />" & _
"    </EmailTo>" & _
"  </MailInfo>" & _
"  <Modules>" & _
"    <Module>" & _
"      <Name>LoadLockA</Name>" & _
"      <Description>LoadLockA</Description>" & _
"      <ShowModulesByDescription>0</ShowModulesByDescription>" & _
"      <IonGaugeFirmwareModel>1</IonGaugeFirmwareModel>" & _
"      <IonGaugeEmissionCurrent>1</IonGaugeEmissionCurrent>" & _
"      <!-- Fill IonGaugeType:GP354 for GP354, GP355 for GP355 -->" & _
"      <IonGaugeType>GP355</IonGaugeType>" & _
"      <Filament>1</Filament>" & _
"      <ROR_Litter>12</ROR_Litter>" & _
"    </Module>" & _
"    <Module>" & _
"      <Name>Chamber1</Name>" & _
"      <Description>PM1</Description>" & _
"      <GemModuleName>PM1</GemModuleName>" & _
"      <SubSystemList>" & _
"        <SubSystem>" & _
"          <Name>Grid_SerialNumber</Name>" & _
"          <Value>AVP_Grid_Number</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Grid_ID</Name>" & _
"          <Value>12/03/2013</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Grid_RebuildLevel</Name>" & _
"          <Value>1</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Etch_Rate</Name>" & _
"          <Value>1</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>WarmUpRecipe</Name>" & _
"          <Value>" & _
"          </Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>ROR_Litter</Name>" & _
"          <Value>178</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Max_KWH_SourceUsage</Name>" & _
"          <Value>10</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Max_KWH_SourceUsage1</Name>" & _
"          <Value>9</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Max_KWH_SourceUsage2</Name>" & _
"          <Value>8</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Max_KWH_SourceUsage3</Name>" & _
"          <Value>6</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>TargetKWHWarningLimit</Name>" & _
"          <Value>900</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>TargetKWHAlarmLimit</Name>" & _
"          <Value>1000</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Target_Material</Name>" & _
"          <Value>Al2O3</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>TargetKWHWarningLimit1</Name>" & _
"          <Value>900</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>TargetKWHAlarmLimit1</Name>" & _
"          <Value>1000</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Target_Material1</Name>" & _
"          <Value>Si</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>TargetKWHWarningLimit2</Name>" & _
"          <Value>900</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>TargetKWHAlarmLimit2</Name>" & _
"          <Value>1000</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Target_Material2</Name>" & _
"          <Value>Si</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>TargetKWHWarningLimit3</Name>" & _
"          <Value>900</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>TargetKWHAlarmLimit3</Name>" & _
"          <Value>1000</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Target_Material3</Name>" & _
"          <Value>Si</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>TargetKWHWarningLimit4</Name>" & _
"          <Value>189</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>TargetKWHAlarmLimit4</Name>" & _
"          <Value>1</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Target_Material4</Name>" & _
"          <Value>12</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>SourceUsage</Name>" & _
"          <Value>0</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>SourceUsageWarning</Name>" & _
"          <Value>200</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>SourceUsageLimit</Name>" & _
"          <Value>300</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Max_KWH_ShieldsQuartz</Name>" & _
"          <Value>0</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>ShieldsQuartzWarning</Name>" & _
"          <Value>250</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>ShieldsQuartzLimit</Name>" & _
"          <Value>300</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Max_KWH_ShieldsQuartz1</Name>" & _
"          <Value>0</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>ShieldsQuartzWarning1</Name>" & _
"          <Value>250</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>ShieldsQuartzLimit1</Name>" & _
"          <Value>300</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Max_KWH_ShieldsQuartz2</Name>" & _
"          <Value>0</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>ShieldsQuartzWarning2</Name>" & _
"          <Value>250</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>ShieldsQuartzLimit2</Name>" & _
"          <Value>300</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Max_KWH_ShieldsQuartz3</Name>" & _
"          <Value>0</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>ShieldsQuartzWarning3</Name>" & _
"          <Value>250</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>ShieldsQuartzLimit3</Name>" & _
"          <Value>300</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Max_KWH_ShieldsQuartz4</Name>" & _
"          <Value>0</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>ShieldsQuartzWarning4</Name>" & _
"          <Value>25000</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>ShieldsQuartzLimit4</Name>" & _
"          <Value>25000</Value>" & _
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
"          <Name>IBESourceValue</Name>" & _
"          <IsPresent>1</IsPresent>" & _
"          <SysVal>" & _
"            <SourceTag Name=""Beam_Voltage"" value=""1"" />" & _
"            <SourceTag Name=""Beam_Current"" value=""1"" />" & _
"            <SourceTag Name=""Suppressor_Voltage"" value=""1"" />" & _
"            <SourceTag Name=""Suppressor_Current"" value=""1"" />" & _
"            <SourceTag Name=""RF_Power"" value=""1"" />" & _
"            <SourceTag Name=""RF_Reflected"" value=""1"" />" & _
"            <SourceTag Name=""PBN_Gas"" value=""1"" />" & _
"            <SourceTag Name=""Gas1"" value=""1"" />" & _
"            <SourceTag Name=""Gas2"" value=""230"" />" & _
"            <SourceTag Name=""KFactor"" value=""1"" />" & _
"          </SysVal>" & _
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
"          <IsPresent>0</IsPresent>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>ChamberInterlock</Name>" & _
"          <TurboWater_Installed>1</TurboWater_Installed>" & _
"          <TurboForeline_Installed>0</TurboForeline_Installed>" & _
"          <TableWater_Installed>0</TableWater_Installed>" & _
"          <ChamberLid_Installed>0</ChamberLid_Installed>" & _
"          <MatchWater_Installed>0</MatchWater_Installed>" & _
"          <TargetWater_Installed>0</TargetWater_Installed>" & _
"          <LidWater_Installed>0</LidWater_Installed>" & _
"          <SubMBWater_Installed>0</SubMBWater_Installed>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>PumpingPackage</Name>" & _
"          <Cryo_Installed>0</Cryo_Installed>" & _
"          <TurboPump_Installed>1</TurboPump_Installed>" & _
"          <Water_Pump_Installed>0</Water_Pump_Installed>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>PVD_Chuck_At_PumpDown_Postion</Name>" & _
"          <Value>1.4</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>PM_DeviceNet</Name>" & _
"          <Value>0</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>VatValveController</Name>" & _
"          <IsPresent>1</IsPresent>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Clamp_Installed</Name>" & _
"          <IsPresent>0</IsPresent>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>GasController</Name>" & _
"          <IsPresent>1</IsPresent>" & _
"          <SysVar>" & _
"            <Gas1 Name=""Ar"" IsShutoffPresent=""1"" IsSupplyPresent=""0"" />" & _
"            <Gas2 Name=""O2"" IsShutoffPresent=""1"" IsSupplyPresent=""0"" />" & _
"            <Gas3 Name=""N2"" IsShutoffPresent=""1"" IsSupplyPresent=""0"" />" & _
"            <Gas4 Name=""O2"" IsShutoffPresent=""1"" IsSupplyPresent=""0"" />" & _
"            <Gas5 Name=""N2"" IsShutoffPresent=""1"" IsSupplyPresent=""0"" />" & _
"          </SysVar>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Magnatron</Name>" & _
"          <IsPresent>0</IsPresent>" & _
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
"      <GemModuleName>PM2</GemModuleName>" & _
"      <SubSystemList>" & _
"        <SubSystem>" & _
"          <Name>Grid_SerialNumber</Name>" & _
"          <Value>AVP_Grid_Number</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Grid_ID</Name>" & _
"          <Value>12/03/2013</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Grid_RebuildLevel</Name>" & _
"          <Value>1</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Etch_Rate</Name>" & _
"          <Value>1</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>ROR_Litter</Name>" & _
"          <Value>178</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Max_KWH_SourceUsage</Name>" & _
"          <Value>0</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Max_KWH_SourceUsage1</Name>" & _
"          <Value>0</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Max_KWH_SourceUsage2</Name>" & _
"          <Value>0</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Max_KWH_SourceUsage3</Name>" & _
"          <Value>0</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>TargetKWHWarningLimit</Name>" & _
"          <Value>800</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>TargetKWHAlarmLimit</Name>" & _
"          <Value>1000</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Target_Material</Name>" & _
"          <Value>33</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>TargetKWHWarningLimit1</Name>" & _
"          <Value>189</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>TargetKWHAlarmLimit1</Name>" & _
"          <Value>1000</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Target_Material1</Name>" & _
"          <Value>12</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>TargetKWHWarningLimit2</Name>" & _
"          <Value>189</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>TargetKWHAlarmLimit2</Name>" & _
"          <Value>1000</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Target_Material2</Name>" & _
"          <Value>12</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>TargetKWHWarningLimit3</Name>" & _
"          <Value>189</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>TargetKWHAlarmLimit3</Name>" & _
"          <Value>1000</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Target_Material3</Name>" & _
"          <Value>12</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>TargetKWHWarningLimit4</Name>" & _
"          <Value>189</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>TargetKWHAlarmLimit4</Name>" & _
"          <Value>1</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Target_Material4</Name>" & _
"          <Value>12</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>SourceUsage</Name>" & _
"          <Value>0</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>SourceUsageWarning</Name>" & _
"          <Value>900</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>SourceUsageLimit</Name>" & _
"          <Value>200</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Max_KWH_ShieldsQuartz</Name>" & _
"          <Value>0</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>ShieldsQuartzWarning</Name>" & _
"          <Value>25000</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>ShieldsQuartzLimit</Name>" & _
"          <Value>25000</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Max_KWH_ShieldsQuartz1</Name>" & _
"          <Value>0</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>ShieldsQuartzWarning1</Name>" & _
"          <Value>25000</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>ShieldsQuartzLimit1</Name>" & _
"          <Value>25000</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Max_KWH_ShieldsQuartz2</Name>" & _
"          <Value>0</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>ShieldsQuartzWarning2</Name>" & _
"          <Value>25000</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>ShieldsQuartzLimit2</Name>" & _
"          <Value>25000</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Max_KWH_ShieldsQuartz3</Name>" & _
"          <Value>0</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>ShieldsQuartzWarning3</Name>" & _
"          <Value>25000</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>ShieldsQuartzLimit3</Name>" & _
"          <Value>25000</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Max_KWH_ShieldsQuartz4</Name>" & _
"          <Value>0</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>ShieldsQuartzWarning4</Name>" & _
"          <Value>25000</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>ShieldsQuartzLimit4</Name>" & _
"          <Value>25000</Value>" & _
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
"          <IsPresent>1</IsPresent>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>IBESourceValue</Name>" & _
"          <IsPresent>1</IsPresent>" & _
"          <SysVal>" & _
"            <SourceTag Name=""Beam_Voltage"" value=""1"" />" & _
"            <SourceTag Name=""Beam_Current"" value=""1"" />" & _
"            <SourceTag Name=""Suppressor_Voltage"" value=""1"" />" & _
"            <SourceTag Name=""Suppressor_Current"" value=""1"" />" & _
"            <SourceTag Name=""RF_Power"" value=""1"" />" & _
"            <SourceTag Name=""RF_Reflected"" value=""1"" />" & _
"            <SourceTag Name=""PBN_Gas"" value=""1"" />" & _
"            <SourceTag Name=""Gas1"" value=""1"" />" & _
"            <SourceTag Name=""Gas2"" value=""1"" />" & _
"            <SourceTag Name=""KFactor"" value=""1"" />" & _
"          </SysVal>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>RFTargetPowerSupply</Name>" & _
"          <IsPresent>0</IsPresent>" & _
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
"          <IsPresent>0</IsPresent>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>ChamberInterlock</Name>" & _
"          <TurboWater_Installed>1</TurboWater_Installed>" & _
"          <TurboForeline_Installed>0</TurboForeline_Installed>" & _
"          <TableWater_Installed>0</TableWater_Installed>" & _
"          <ChamberLid_Installed>0</ChamberLid_Installed>" & _
"          <MatchWater_Installed>0</MatchWater_Installed>" & _
"          <TargetWater_Installed>0</TargetWater_Installed>" & _
"          <LidWater_Installed>0</LidWater_Installed>" & _
"          <SubMBWater_Installed>0</SubMBWater_Installed>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>PumpingPackage</Name>" & _
"          <Cryo_Installed>0</Cryo_Installed>" & _
"          <TurboPump_Installed>1</TurboPump_Installed>" & _
"          <Water_Pump_Installed>0</Water_Pump_Installed>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>PVD_Chuck_At_PumpDown_Postion</Name>" & _
"          <Value>1.4</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>PM_DeviceNet</Name>" & _
"          <Value>0</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>VatValveController</Name>" & _
"          <IsPresent>1</IsPresent>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Clamp_Installed</Name>" & _
"          <IsPresent>0</IsPresent>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>GasController</Name>" & _
"          <IsPresent>1</IsPresent>" & _
"          <SysVar>" & _
"            <Gas1 Name=""Argon"" IsShutoffPresent=""1"" IsSupplyPresent=""0"" />" & _
"            <Gas2 Name=""Oxygen"" IsShutoffPresent=""1"" IsSupplyPresent=""0"" />" & _
"            <Gas3 Name=""N2"" IsShutoffPresent=""1"" IsSupplyPresent=""0"" />" & _
"            <Gas4 Name=""Oxygen"" IsShutoffPresent=""1"" IsSupplyPresent=""0"" />" & _
"            <Gas5 Name=""N2"" IsShutoffPresent=""1"" IsSupplyPresent=""0"" />" & _
"          </SysVar>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Magnatron</Name>" & _
"          <IsPresent>0</IsPresent>" & _
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
"      <GemModuleName>PM3</GemModuleName>" & _
"      <SubSystemList>" & _
"        <SubSystem>" & _
"          <Name>Grid_SerialNumber</Name>" & _
"          <Value>AVP_Grid_Number</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Grid_ID</Name>" & _
"          <Value>12/03/2013</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Grid_RebuildLevel</Name>" & _
"          <Value>1</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Etch_Rate</Name>" & _
"          <Value>1</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>ROR_Litter</Name>" & _
"          <Value>178</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Max_KWH_SourceUsage</Name>" & _
"          <Value>0</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Max_KWH_SourceUsage1</Name>" & _
"          <Value>0</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Max_KWH_SourceUsage2</Name>" & _
"          <Value>0</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Max_KWH_SourceUsage3</Name>" & _
"          <Value>0</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>TargetKWHWarningLimit</Name>" & _
"          <Value>1900</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>TargetKWHAlarmLimit</Name>" & _
"          <Value>2000</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Target_Material</Name>" & _
"          <Value>Cu</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>TargetKWHWarningLimit1</Name>" & _
"          <Value>1900</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>TargetKWHAlarmLimit1</Name>" & _
"          <Value>2000</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Target_Material1</Name>" & _
"          <Value>Ag</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>TargetKWHWarningLimit2</Name>" & _
"          <Value>1900</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>TargetKWHAlarmLimit2</Name>" & _
"          <Value>2000</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Target_Material2</Name>" & _
"          <Value>Au</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>TargetKWHWarningLimit3</Name>" & _
"          <Value>1900</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>TargetKWHAlarmLimit3</Name>" & _
"          <Value>2000</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Target_Material3</Name>" & _
"          <Value>Cl</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>TargetKWHWarningLimit4</Name>" & _
"          <Value>1900</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>TargetKWHAlarmLimit4</Name>" & _
"          <Value>2000</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Target_Material4</Name>" & _
"          <Value>Na</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>SourceUsage</Name>" & _
"          <Value>0</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>SourceUsageWarning</Name>" & _
"          <Value>10000</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>SourceUsageLimit</Name>" & _
"          <Value>9000</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Shutter_Visible</Name>" & _
"          <Value>1</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Max_KWH_ShieldsQuartz</Name>" & _
"          <Value>0</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>ShieldsQuartzWarning</Name>" & _
"          <Value>20000</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>ShieldsQuartzLimit</Name>" & _
"          <Value>30000</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Max_KWH_ShieldsQuartz1</Name>" & _
"          <Value>0</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>ShieldsQuartzWarning1</Name>" & _
"          <Value>20000</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>ShieldsQuartzLimit1</Name>" & _
"          <Value>30000</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Max_KWH_ShieldsQuartz2</Name>" & _
"          <Value>0</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>ShieldsQuartzWarning2</Name>" & _
"          <Value>20000</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>ShieldsQuartzLimit2</Name>" & _
"          <Value>30000</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Max_KWH_ShieldsQuartz3</Name>" & _
"          <Value>0</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>ShieldsQuartzWarning3</Name>" & _
"          <Value>20000</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>ShieldsQuartzLimit3</Name>" & _
"          <Value>30000</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Max_KWH_ShieldsQuartz4</Name>" & _
"          <Value>0</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>ShieldsQuartzWarning4</Name>" & _
"          <Value>20000</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>ShieldsQuartzLimit4</Name>" & _
"          <Value>30000</Value>" & _
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
"          <IsPresent>1</IsPresent>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>IBESourceValue</Name>" & _
"          <IsPresent>1</IsPresent>" & _
"          <SysVal>" & _
"            <SourceTag Name=""Beam_Voltage"" value=""1"" />" & _
"            <SourceTag Name=""Beam_Current"" value=""1"" />" & _
"            <SourceTag Name=""Suppressor_Voltage"" value=""1"" />" & _
"            <SourceTag Name=""Suppressor_Current"" value=""1"" />" & _
"            <SourceTag Name=""RF_Power"" value=""1"" />" & _
"            <SourceTag Name=""RF_Reflected"" value=""1"" />" & _
"            <SourceTag Name=""PBN_Gas"" value=""1"" />" & _
"            <SourceTag Name=""Gas1"" value=""1"" />" & _
"            <SourceTag Name=""Gas2"" value=""1"" />" & _
"            <SourceTag Name=""KFactor"" value=""1"" />" & _
"          </SysVal>" & _
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
"          <IsPresent>0</IsPresent>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>ChamberInterlock</Name>" & _
"          <TurboWater_Installed>0</TurboWater_Installed>" & _
"          <TurboForeline_Installed>0</TurboForeline_Installed>" & _
"          <TableWater_Installed>0</TableWater_Installed>" & _
"          <ChamberLid_Installed>0</ChamberLid_Installed>" & _
"          <MatchWater_Installed>0</MatchWater_Installed>" & _
"          <TargetWater_Installed>0</TargetWater_Installed>" & _
"          <LidWater_Installed>0</LidWater_Installed>" & _
"          <SubMBWater_Installed>0</SubMBWater_Installed>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>PumpingPackage</Name>" & _
"          <Cryo_Installed>1</Cryo_Installed>" & _
"          <TurboPump_Installed>0</TurboPump_Installed>" & _
"          <Water_Pump_Installed>0</Water_Pump_Installed>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>PVD_Chuck_At_PumpDown_Postion</Name>" & _
"          <Value>1.4</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>PM_DeviceNet</Name>" & _
"          <Value>0</Value>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>VatValveController</Name>" & _
"          <IsPresent>1</IsPresent>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Clamp_Installed</Name>" & _
"          <IsPresent>0</IsPresent>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>GasController</Name>" & _
"          <IsPresent>1</IsPresent>" & _
"          <SysVar>" & _
"            <Gas1 Name=""Argon"" IsShutoffPresent=""1"" IsSupplyPresent=""0"" />" & _
"            <Gas2 Name=""Oxygen"" IsShutoffPresent=""1"" IsSupplyPresent=""0"" />" & _
"            <Gas3 Name="""" IsShutoffPresent=""0"" IsSupplyPresent=""0"" />" & _
"            <Gas4 Name="""" IsShutoffPresent=""0"" IsSupplyPresent=""0"" />" & _
"            <Gas5 Name="""" IsShutoffPresent=""0"" IsSupplyPresent=""0"" />" & _
"          </SysVar>" & _
"        </SubSystem>" & _
"        <SubSystem>" & _
"          <Name>Magnatron</Name>" & _
"          <IsPresent>0</IsPresent>" & _
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
"      <Aligner_At_Station>1</Aligner_At_Station>" & _
"      <ShowModulesByDescription>0</ShowModulesByDescription>" & _
"      <PacketMode>True</PacketMode>" & _
"      <SensorPositionAtDegree>90</SensorPositionAtDegree>" & _
"      <WaferSize>6</WaferSize>" & _
"      <ActiveCCD>1</ActiveCCD>" & _
"      <WaferType>NTCH</WaferType>" & _
"      <RunDataFileFormat>CSV</RunDataFileFormat>" & _
"    </Module>" & _
"    <Module>" & _
"      <Name>Robot</Name>" & _
"      <Description>Robot</Description>" & _
"      <ShowModulesByDescription>0</ShowModulesByDescription>" & _
"      <Robot_Version>7.2</Robot_Version>" & _
"      <IonGaugeFirmwareModel>1</IonGaugeFirmwareModel>" & _
"      <IonGaugeEmissionCurrent>1</IonGaugeEmissionCurrent>" & _
"      <!-- Fill IonGaugeType:GP354 for GP354, GP355 for GP355 -->" & _
"      <IonGaugeType>GP355</IonGaugeType>" & _
"      <Filament>1</Filament>" & _
"      <ROR_Litter>32</ROR_Litter>" & _
"      <StoredConfigs Name=""Robot"">32</StoredConfigs>" & _
"    </Module>" & _
"    <Configure>" & _
"      <Key>PVD.RoughPumpCG</Key>" & _
"      <Value>200</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>DeltaPickNeeded</Key>" & _
"      <Value>1</Value>" & _
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
"      <Value>7200</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>MotionInitializeWaitTimeInSeconds</Key>" & _
"      <Value>120</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>ClampUpWaitTimeInSeconds</Key>" & _
"      <Value>30</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>OpenShutterWaitTimeInSeconds</Key>" & _
"      <Value>30</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>MovingChuckToZeroWaitTimeInSeconds</Key>" & _
"      <Value>30</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>PvdUnClampWaitTimeInSeconds</Key>" & _
"      <Value>30</Value>" & _
"    </Configure>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtPort.Max</Key>" & _
"      <Value>10000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtPort.Min</Key>" & _
"      <Value>1</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtEveryMinutes.Max</Key>" & _
"      <Value>10000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtEveryMinutes.Min</Key>" & _
"      <Value>1</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CryoPopUpPanel.txtExtendedPurgeTimeMax</Key>" & _
"      <Value>9999</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CryoPopUpPanel.txtExtendedPurgeTimeMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CryoPopUpPanel.txtPumpRestartDelayMax</Key>" & _
"      <Value>59994</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CryoPopUpPanel.txtPumpRestartDelayMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CryoPopUpPanel.txtRateOfRiseMax</Key>" & _
"      <Value>100</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CryoPopUpPanel.txtRateOfRiseMin</Key>" & _
"      <Value>1</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CryoPopUpPanel.txtRoughToPressureMax</Key>" & _
"      <Value>200</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CryoPopUpPanel.txtRoughToPressureMin</Key>" & _
"      <Value>25</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CryoPopUpPanel.txtStartUpTempMax</Key>" & _
"      <Value>80</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CryoPopUpPanel.txtStartUpTempMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CryoPopUpPanel.txtRepurgeCyclesMax</Key>" & _
"      <Value>40</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CryoPopUpPanel.txtRepurgeCyclesMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>LLMaxCycleCount.txtLLAMaxCycleCountMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>LLMaxCycleCount.txtLLAMaxCycleCountMax</Key>" & _
"      <Value>5000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.RobotConfig.Max</Key>" & _
"      <Value>10000000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.RobotConfig.Min</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
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
"      <Key>SystemSetup.MaxUsage.Max</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.MaxUsage.Min</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtEtchRatePM1.Max</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtEtchRatePM1.Min</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtEtchRatePM2.Max</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtEtchRatePM2.Min</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtEtchRatePM3.Max</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtEtchRatePM3.Min</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtCryoPumpHour.Max</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtCryoPumpHour.Min</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtUsageKWH_PM1.Max</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtUsageKWH_PM1.Min</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtUsageKWH_PM2.Max</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtUsageKWH_PM2.Min</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtUsageKWH_PM3.Max</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtUsageKWH_PM3.Min</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtShieldPM1.Max</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtShieldPM1.Min</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtShieldsPM2.Max</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtShieldsPM2.Min</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtShieldsPM3.Max</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtShieldsPM3.Min</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.ShieldsQuartz.Max</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.ShieldsQuartz.Min</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.LimitShieldsQuartz.Max</Key>" & _
"      <Value>30000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.LimitShieldsQuartz.Min</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.WarningShieldsQuartz.Max</Key>" & _
"      <Value>30000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.WarningShieldsQuartz.Min</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.MaxShieldsQuartz.Max</Key>" & _
"      <Value>30000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.MaxShieldsQuartz.Min</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtRateOfRiseVolLLA.Max</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtRateOfRiseVolLLA.Min</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtRateOfRiseVolTM.Max</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtRateOfRiseVolTM.Min</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtDegasWaitTimeLLA.Max</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtDegasWaitTimeLLA.Min</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtDegasWaitTimeTM.Max</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtDegasWaitTimeTM.Min</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtDeltaPickECCLimits.Max</Key>" & _
"      <Value>5000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtDeltaPickECCLimits.Min</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtNumberOfSlotsLLA.Max</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtNumberOfSlotsLLA.Min</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtTravelLengthLLA.Max</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtTravelLengthLLA.Min</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtPitchLLA.Max</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtPitchLLA.Min</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtBaseOffsetLLA.Max</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtBaseOffsetLLA.Min</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtFindBiasLLA.Max</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtFindBiasLLA.Min</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtVentLLA.Max</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtVentLLA.Min</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtVentTM.Max</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtVentTM.Min</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtTransferLLA.Max</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtTransferLLA.Min</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtTransferTM.Max</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtTransferTM.Min</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtTransferPM1.Max</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtTransferPM1.Min</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtTransferPM2.Max</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtTransferPM2.Min</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtTransferPM3.Max</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtTransferPM3.Min</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtCrossOverLLA.Max</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtCrossOverLLA.Min</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtCrossOverTM.Max</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtCrossOverTM.Min</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtLLACGTripPoint.Max</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtLLACGTripPoint.Min</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtTMCGTripPoint.Max</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtTMCGTripPoint.Min</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtMPCGTripPoint.Max</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtMPCGTripPoint.Min</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtLLAForelineCGTripPoint.Max</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtLLAForelineCGTripPoint.Min</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtTMForelineCGTripPoint.Max</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtTMForelineCGTripPoint.Min</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtSlowRoughLLA.Max</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtSlowRoughLLA.Min</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtSlowVentLLA.Max</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtSlowVentLLA.Min</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtCGDifferentialPercent.Max</Key>" & _
"      <Value>100</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtCGDifferentialPercent.Min</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtTransferSetPointWaitTimeInSeconds.Max</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtTransferSetPointWaitTimeInSeconds.Min</Key>" & _
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
"      <Key>Chamber1.PVD.RFTargetPowerSupply.txtForwardPowerRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD.RFTargetPowerSupply.txtForwardPowerRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD.RFTargetPowerSupply.txtC1RightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD.RFTargetPowerSupply.txtC1RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD.RFTargetPowerSupply.txtC2RightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD.RFTargetPowerSupply.txtC2RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD.RFTargetPowerSupply.txtPresetsRightMax</Key>" & _
"      <Value>9</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD.RFTargetPowerSupply.txtPresetsRightMin</Key>" & _
"      <Value>1</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD.BiasPowerSupply.txtForwardPowerRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD.BiasPowerSupply.txtForwardPowerRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD.BiasPowerSupply.txtVoltageRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD.BiasPowerSupply.txtVoltageRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD.BiasPowerSupply.txtC1RightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD.BiasPowerSupply.txtC1RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD.BiasPowerSupply.txtC2RightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD.BiasPowerSupply.txtC2RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD.BiasPowerSupply.txtPresetsRightMax</Key>" & _
"      <Value>9</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD.BiasPowerSupply.txtPresetsRightMin</Key>" & _
"      <Value>1</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD.ParallelMagnet.txtCurrentRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD.ParallelMagnet.txtCurrentRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD.ParallelMagnet.txtDutyRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD.ParallelMagnet.txtDutyRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD.ParallelMagnet.txtFrequencyRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD.ParallelMagnet.txtFrequencyRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD.Baratron.txtCG2Max</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD.Baratron.txtCG2Min</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD.ChuckControl.txtPos2Max</Key>" & _
"      <Value>4</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD.ChuckControl.txtPos2Min</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD.VatValveController.txtTeachMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD.VatValveController.txtTeachMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD.VatValveController.txtPressureMax</Key>" & _
"      <Value>100</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD.VatValveController.txtPressureMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD.VatValveController.txtPressure_PercentMax</Key>" & _
"      <Value>100</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD.VatValveController.txtPressure_PercentMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD.GasController.txtGas1RightMax</Key>" & _
"      <Value>144</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD.GasController.txtGas1RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD.GasController.txtGas2RightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD.GasController.txtGas2RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD.GasController.txtGas3RightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD.GasController.txtGas3RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD.GasController.txtGas4RightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD.GasController.txtGas4RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD.GasController.txtGas5RightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD.GasController.txtGas5RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD.DCTargetPowerSupply.txtTargetPowerRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD.DCTargetPowerSupply.txtTargetPowerRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD.DCTargetPowerSupply.txtRampTimeRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD.DCTargetPowerSupply.txtRampTimeRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD.DCTargetPowerSupply.txtTargetVoltageRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD.DCTargetPowerSupply.txtTargetVoltageRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD.DCTargetPowerSupply.txtTargetCurrentRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD.DCTargetPowerSupply.txtTargetCurrentRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD.DiagnosticScreen.txtSampleTimeMin</Key>" & _
"      <Value>1</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD.DiagnosticScreen.txtSampleTimeMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD.DiagnosticScreen.txtTotalTimeMin</Key>" & _
"      <Value>1</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD.DiagnosticScreen.txtTotalTimeMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtMeasureMin</Key>" & _
"      <Value>1</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtMeasureMax</Key>" & _
"      <Value>5000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.RFTargetPowerSupply.txtForwardPowerRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.RFTargetPowerSupply.txtForwardPowerRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.RFTargetPowerSupply.txtC1RightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.RFTargetPowerSupply.txtC1RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.RFTargetPowerSupply.txtC2RightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.RFTargetPowerSupply.txtC2RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.RFTargetPowerSupply.txtPresetsRightMax</Key>" & _
"      <Value>9</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.RFTargetPowerSupply.txtPresetsRightMin</Key>" & _
"      <Value>1</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.BiasPowerSupply.txtForwardPowerRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.BiasPowerSupply.txtForwardPowerRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.BiasPowerSupply.txtVoltageRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.BiasPowerSupply.txtVoltageRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.BiasPowerSupply.txtC1RightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.BiasPowerSupply.txtC1RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.BiasPowerSupply.txtC2RightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.BiasPowerSupply.txtC2RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.BiasPowerSupply.txtPresetsRightMax</Key>" & _
"      <Value>9</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.BiasPowerSupply.txtPresetsRightMin</Key>" & _
"      <Value>1</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.ParallelMagnet.txtCurrentRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.ParallelMagnet.txtCurrentRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.ParallelMagnet.txtDutyRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.ParallelMagnet.txtDutyRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.ParallelMagnet.txtFrequencyRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.ParallelMagnet.txtFrequencyRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.Baratron.txtCG2Max</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.Baratron.txtCG2Min</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.ChuckControl.txtPos2Max</Key>" & _
"      <Value>4</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.ChuckControl.txtPos2Min</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.VatValveController.txtTeachMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.VatValveController.txtTeachMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.VatValveController.txtPressureMax</Key>" & _
"      <Value>100</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.VatValveController.txtPressureMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.VatValveController.txtPressure_PercentMax</Key>" & _
"      <Value>100</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.VatValveController.txtPressure_PercentMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.GasController.txtGas1RightMax</Key>" & _
"      <Value>144</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.GasController.txtGas1RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.GasController.txtGas2RightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.GasController.txtGas2RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.GasController.txtGas3RightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.GasController.txtGas3RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.GasController.txtGas4RightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.GasController.txtGas4RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.GasController.txtGas5RightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.GasController.txtGas5RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.DCTargetPowerSupply.txtTargetPowerRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.DCTargetPowerSupply.txtTargetPowerRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.DCTargetPowerSupply.txtRampTimeRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.DCTargetPowerSupply.txtRampTimeRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.DCTargetPowerSupply.txtTargetVoltageRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.DCTargetPowerSupply.txtTargetVoltageRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.DCTargetPowerSupply.txtTargetCurrentRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.DCTargetPowerSupply.txtTargetCurrentRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.DiagnosticScreen.txtSampleTimeMin</Key>" & _
"      <Value>1</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.DiagnosticScreen.txtSampleTimeMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.DiagnosticScreen.txtTotalTimeMin</Key>" & _
"      <Value>1</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD.DiagnosticScreen.txtTotalTimeMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtMeasureMin</Key>" & _
"      <Value>1</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtMeasureMax</Key>" & _
"      <Value>5000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.RFTargetPowerSupply.txtForwardPowerRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.RFTargetPowerSupply.txtForwardPowerRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.RFTargetPowerSupply.txtC1RightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.RFTargetPowerSupply.txtC1RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.RFTargetPowerSupply.txtC2RightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.RFTargetPowerSupply.txtC2RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.RFTargetPowerSupply.txtPresetsRightMax</Key>" & _
"      <Value>9</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.RFTargetPowerSupply.txtPresetsRightMin</Key>" & _
"      <Value>1</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.BiasPowerSupply.txtForwardPowerRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.BiasPowerSupply.txtForwardPowerRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.BiasPowerSupply.txtVoltageRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.BiasPowerSupply.txtVoltageRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.BiasPowerSupply.txtC1RightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.BiasPowerSupply.txtC1RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.BiasPowerSupply.txtC2RightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.BiasPowerSupply.txtC2RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.BiasPowerSupply.txtPresetsRightMax</Key>" & _
"      <Value>9</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.BiasPowerSupply.txtPresetsRightMin</Key>" & _
"      <Value>1</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.ParallelMagnet.txtCurrentRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.ParallelMagnet.txtCurrentRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.ParallelMagnet.txtDutyRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.ParallelMagnet.txtDutyRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.ParallelMagnet.txtFrequencyRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.ParallelMagnet.txtFrequencyRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.Baratron.txtCG2Max</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.Baratron.txtCG2Min</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.ChuckControl.txtPos2Max</Key>" & _
"      <Value>4</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.ChuckControl.txtPos2Min</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.VatValveController.txtTeachMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.VatValveController.txtTeachMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.VatValveController.txtPressureMax</Key>" & _
"      <Value>100</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.VatValveController.txtPressureMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.VatValveController.txtPressure_PercentMax</Key>" & _
"      <Value>100</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.VatValveController.txtPressure_PercentMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.GasController.txtGas1RightMax</Key>" & _
"      <Value>144</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.GasController.txtGas1RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.GasController.txtGas2RightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.GasController.txtGas2RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.GasController.txtGas3RightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.GasController.txtGas3RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.GasController.txtGas4RightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.GasController.txtGas4RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.GasController.txtGas5RightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.GasController.txtGas5RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.DCTargetPowerSupply.txtTargetPowerRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.DCTargetPowerSupply.txtTargetPowerRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.DCTargetPowerSupply.txtRampTimeRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.DCTargetPowerSupply.txtRampTimeRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.DCTargetPowerSupply.txtTargetVoltageRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.DCTargetPowerSupply.txtTargetVoltageRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.DCTargetPowerSupply.txtTargetCurrentRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.DCTargetPowerSupply.txtTargetCurrentRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.DiagnosticScreen.txtSampleTimeMin</Key>" & _
"      <Value>1</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.DiagnosticScreen.txtSampleTimeMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.DiagnosticScreen.txtTotalTimeMin</Key>" & _
"      <Value>1</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD.DiagnosticScreen.txtTotalTimeMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtMeasureMin</Key>" & _
"      <Value>1</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtMeasureMax</Key>" & _
"      <Value>5000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>LoadLockA.PVD.DiagnosticScreen.txtSampleTimeMin</Key>" & _
"      <Value>1</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>LoadLockA.PVD.DiagnosticScreen.txtSampleTimeMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>LoadLockA.PVD.DiagnosticScreen.txtTotalTimeMin</Key>" & _
"      <Value>1</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>LoadLockA.PVD.DiagnosticScreen.txtTotalTimeMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CassettesModule.PVD.DiagnosticScreen.txtSampleTimeMin</Key>" & _
"      <Value>1</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CassettesModule.PVD.DiagnosticScreen.txtSampleTimeMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CassettesModule.PVD.DiagnosticScreen.txtTotalTimeMin</Key>" & _
"      <Value>1</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CassettesModule.PVD.DiagnosticScreen.txtTotalTimeMax</Key>" & _
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
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtBeamVoltageRightMin</Key>" & _
"      <Value>-0.6</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtBeamVoltageRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtBeamCurrentRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtBeamCurrentRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtSuppressorVoltageRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtSuppressorVoltageRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtSuppressorCurrentRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtSuppressorCurrentRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtRFPowerRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtRFPowerRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtRFReflectedRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtRFReflectedRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtPBNGasRight_SourceTabMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtPBNGasRight_SourceTabMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtGas1Right_SourceTabMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtGas1Right_SourceTabMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtGas2Right_SourceTabMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtGas2Right_SourceTabMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtKFactorRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtKFactorRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtPBNBodyRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtPBNBodyRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtPBNDischRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtPBNDischRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtPBNGasRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtPBNGasRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtGas1RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtGas1RightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtGas2RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtGas2RightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtGas3RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtGas3RightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtFlowCoolGasRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtFlowCoolGasRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtRotationEndMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtRotationEndMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtTiltAngleRightMin</Key>" & _
"      <Value>-90</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtTiltAngleRightMax</Key>" & _
"      <Value>360</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtRotationStaticRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtRotationStaticRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtRotationSweepRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtRotationSweepRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtRotationContinuousRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtRotationContinuousRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtSourceUsageMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtSourceUsageMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.DiagnosticScreen.txtSampleTimeMin</Key>" & _
"      <Value>1</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.DiagnosticScreen.txtSampleTimeMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.DiagnosticScreen.txtTotalTimeMin</Key>" & _
"      <Value>1</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.DiagnosticScreen.txtTotalTimeMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtSourceEMCurrentRight_SourceTabMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtSourceEMCurrentRight_SourceTabMax</Key>" & _
"      <Value>500</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtSourceEMCurrentRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtSourceEMCurrentRightMax</Key>" & _
"      <Value>500</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtSourceMinutesMaintMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtSourceMinutesMaintMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtPBNMinutesMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtPBNMinutesMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtShieldQuartSPMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtShieldQuartSPMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtCoverFixtureShieldUsageSPMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtCoverFixtureShieldUsageSPMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtWaferClampUsageSPMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtWaferClampUsageSPMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtTopFixtureShieldUsageSPMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtTopFixtureShieldUsageSPMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtShutterUsageSPMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtShutterUsageSPMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtLinerSPMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtLinerSPMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtCryoUsageSPMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtCryoUsageSPMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtFixtureRotationMotorUsageSPMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtFixtureRotationMotorUsageSPMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtWaterJournalSPMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtWaterJournalSPMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtChillerTempSPMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.IBE.txtChillerTempSPMax</Key>" & _
"      <Value>50</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtChillerTempSPMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtChillerTempSPMax</Key>" & _
"      <Value>50</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtSourceEMCurrentRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtSourceEMCurrentRightMax</Key>" & _
"      <Value>500</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtSourceEMCurrentRight_SourceTabMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtSourceEMCurrentRight_SourceTabMax</Key>" & _
"      <Value>500</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtBeamVoltageRightMin</Key>" & _
"      <Value>-0.6</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtBeamVoltageRightMax</Key>" & _
"      <Value>1000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtBeamCurrentRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtBeamCurrentRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtSuppressorVoltageRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtSuppressorVoltageRightMax</Key>" & _
"      <Value>1000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtSuppressorCurrentRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtSuppressorCurrentRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtRFPowerRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtRFPowerRightMax</Key>" & _
"      <Value>1000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtRFReflectedRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtRFReflectedRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtPBNGasRight_SourceTabMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtPBNGasRight_SourceTabMax</Key>" & _
"      <Value>14.5</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtGas1Right_SourceTabMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtGas1Right_SourceTabMax</Key>" & _
"      <Value>145</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtGas2Right_SourceTabMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtGas2Right_SourceTabMax</Key>" & _
"      <Value>100</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtKFactorRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtKFactorRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtPBNBodyRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtPBNBodyRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtPBNDischRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtPBNDischRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtPBNGasRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtPBNGasRightMax</Key>" & _
"      <Value>14.5</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtGas1RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtGas1RightMax</Key>" & _
"      <Value>145</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtGas2RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtGas2RightMax</Key>" & _
"      <Value>100</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtGas3RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtGas3RightMax</Key>" & _
"      <Value>100</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtFlowCoolGasRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtFlowCoolGasRightMax</Key>" & _
"      <Value>164</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtRotationEndMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtRotationEndMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtTiltAngleRightMin</Key>" & _
"      <Value>-15</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtTiltAngleRightMax</Key>" & _
"      <Value>160</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtRotationStaticRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtRotationStaticRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtRotationSweepRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtRotationSweepRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtRotationContinuousRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtRotationContinuousRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtSourceUsageMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtSourceUsageMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtSourceMinutesMaintMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtSourceMinutesMaintMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtPBNMinutesMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtPBNMinutesMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtShieldQuartSPMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtShieldQuartSPMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtCoverFixtureShieldUsageSPMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtCoverFixtureShieldUsageSPMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtWaferClampUsageSPMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtWaferClampUsageSPMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtTopFixtureShieldUsageSPMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtTopFixtureShieldUsageSPMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtShutterUsageSPMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtShutterUsageSPMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtLinerSPMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtLinerSPMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtCryoUsageSPMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtCryoUsageSPMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtFixtureRotationMotorUsageSPMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtFixtureRotationMotorUsageSPMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtWaterJournalSPMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.txtWaterJournalSPMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.DiagnosticScreen.txtSampleTimeMin</Key>" & _
"      <Value>1</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.DiagnosticScreen.txtSampleTimeMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.DiagnosticScreen.txtTotalTimeMin</Key>" & _
"      <Value>1</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.IBE.DiagnosticScreen.txtTotalTimeMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtChillerTempSPMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtChillerTempSPMax</Key>" & _
"      <Value>50</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtBeamVoltageRightMin</Key>" & _
"      <Value>-0.6</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtBeamVoltageRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtBeamCurrentRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtBeamCurrentRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtSuppressorVoltageRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtSuppressorVoltageRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtSuppressorCurrentRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtSuppressorCurrentRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtRFPowerRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtRFPowerRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtRFReflectedRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtRFReflectedRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtPBNGasRight_SourceTabMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtPBNGasRight_SourceTabMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtGas1Right_SourceTabMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtGas1Right_SourceTabMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtGas2Right_SourceTabMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtGas2Right_SourceTabMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtKFactorRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtKFactorRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtPBNBodyRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtPBNBodyRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtPBNDischRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtPBNDischRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtPBNGasRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtPBNGasRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtGas1RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtGas1RightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtGas2RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtGas2RightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtGas3RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtGas3RightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtFlowCoolGasRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtFlowCoolGasRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtRotationEndMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtRotationEndMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtTiltAngleRightMin</Key>" & _
"      <Value>-90</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtTiltAngleRightMax</Key>" & _
"      <Value>360</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtRotationStaticRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtRotationStaticRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtRotationSweepRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtRotationSweepRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtRotationContinuousRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtRotationContinuousRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtSourceUsageMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtSourceUsageMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.DiagnosticScreen.txtSampleTimeMin</Key>" & _
"      <Value>1</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.DiagnosticScreen.txtSampleTimeMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.DiagnosticScreen.txtTotalTimeMin</Key>" & _
"      <Value>1</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.DiagnosticScreen.txtTotalTimeMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtSourceEMCurrentRight_SourceTabMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtSourceEMCurrentRight_SourceTabMax</Key>" & _
"      <Value>500</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtSourceEMCurrentRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtSourceEMCurrentRightMax</Key>" & _
"      <Value>500</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtSourceMinutesMaintMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtSourceMinutesMaintMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtPBNMinutesMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtPBNMinutesMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtShieldQuartSPMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtShieldQuartSPMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtCoverFixtureShieldUsageSPMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtCoverFixtureShieldUsageSPMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtWaferClampUsageSPMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtWaferClampUsageSPMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtTopFixtureShieldUsageSPMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtTopFixtureShieldUsageSPMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtShutterUsageSPMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtShutterUsageSPMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtLinerSPMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtLinerSPMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtCryoUsageSPMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtCryoUsageSPMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtFixtureRotationMotorUsageSPMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtFixtureRotationMotorUsageSPMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtWaterJournalSPMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.IBE.txtWaterJournalSPMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtGas1RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtGas1RightMax</Key>" & _
"      <Value>290</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtGas2RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtGas2RightMax</Key>" & _
"      <Value>100</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtGas3RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtGas3RightMax</Key>" & _
"      <Value>100</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtGas4RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtGas4RightMax</Key>" & _
"      <Value>100</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtGas5RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtGas5RightMax</Key>" & _
"      <Value>100</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.TargetPowerSupply.txtForwardPowerRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.TargetPowerSupply.txtForwardPowerRightMax</Key>" & _
"      <Value>10000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.BiasPowerSupply.txtForwardPowerRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.BiasPowerSupply.txtForwardPowerRightMax</Key>" & _
"      <Value>2000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.BiasPowerSupply.txtVoltageRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.BiasPowerSupply.txtVoltageRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.TargetPowerSupply.txtC1RightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.TargetPowerSupply.txtC1RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.TargetPowerSupply.txtC2RightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.TargetPowerSupply.txtC2RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.TargetPowerSupply.txtPresetsRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.TargetPowerSupply.txtPresetsRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.TargetPowerSupply.txtDCForwardPowerRightMax</Key>" & _
"      <Value>10000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.TargetPowerSupply.txtDCForwardPowerRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.TargetPowerSupply.txtPulseFrequencyRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.TargetPowerSupply.txtPulseFrequencyRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.TargetPowerSupply.txtPulseWidthRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.TargetPowerSupply.txtPulseWidthRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.TargetPowerSupply.txtRampTimeRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.TargetPowerSupply.txtRampTimeRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.BiasPowerSupply.txtC1RightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.BiasPowerSupply.txtC1RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.BiasPowerSupply.txtC2RightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.BiasPowerSupply.txtC2RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.BiasPowerSupply.txtPresetsRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.BiasPowerSupply.txtPresetsRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtRotateRightMax</Key>" & _
"      <Value>30</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtRotateRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtTablePosRightMax</Key>" & _
"      <Value>110</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtTablePosRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtPressureMax</Key>" & _
"      <Value>100</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtPressureMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtPressure_PercentMax</Key>" & _
"      <Value>100</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtPressure_PercentMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtT1LimitMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtT1LimitMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtT2LimitMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtT2LimitMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtT3LimitMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtT3LimitMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtT4LimitMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtT4LimitMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtT1UsageMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtT1UsageMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtT2UsageMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtT2UsageMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtT3UsageMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtT3UsageMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtT4UsageMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtT4UsageMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtT5UsageMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtT5UsageMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtT1WarningMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtT1WarningMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtT2WarningMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtT2WarningMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtT3WarningMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtT3WarningMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtT4WarningMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtT4WarningMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtT1ShieldsQuartzMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtT1ShieldsQuartzMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtT2ShieldsQuartzMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtT2ShieldsQuartzMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtT3ShieldsQuartzMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtT3ShieldsQuartzMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtT4ShieldsQuartzMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtT4ShieldsQuartzMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtT1TargetMaterialMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtT1TargetMaterialMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtT2TargetMaterialMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtT2TargetMaterialMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtT3TargetMaterialMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtT3TargetMaterialMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtT4TargetMaterialMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtT4TargetMaterialMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtHeaterZone1SPMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtHeaterZone2SPMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtHeaterZone1SPMax</Key>" & _
"      <Value>10000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.txtHeaterZone2SPMax</Key>" & _
"      <Value>10000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.StaticPostionMax</Key>" & _
"      <Value>8</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber1.PVD4.StaticPostionMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtGas1RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtGas1RightMax</Key>" & _
"      <Value>290</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtGas2RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtGas2RightMax</Key>" & _
"      <Value>100</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtGas3RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtGas3RightMax</Key>" & _
"      <Value>100</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtGas4RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtGas4RightMax</Key>" & _
"      <Value>100</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtGas5RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtGas5RightMax</Key>" & _
"      <Value>100</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.TargetPowerSupply.txtForwardPowerRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.TargetPowerSupply.txtForwardPowerRightMax</Key>" & _
"      <Value>10000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.BiasPowerSupply.txtForwardPowerRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.BiasPowerSupply.txtForwardPowerRightMax</Key>" & _
"      <Value>2000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.BiasPowerSupply.txtVoltageRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.BiasPowerSupply.txtVoltageRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.TargetPowerSupply.txtC1RightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.TargetPowerSupply.txtC1RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.TargetPowerSupply.txtC2RightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.TargetPowerSupply.txtC2RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.TargetPowerSupply.txtPresetsRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.TargetPowerSupply.txtPresetsRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.TargetPowerSupply.txtDCForwardPowerRightMax</Key>" & _
"      <Value>10000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.TargetPowerSupply.txtDCForwardPowerRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.TargetPowerSupply.txtPulseFrequencyRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.TargetPowerSupply.txtPulseFrequencyRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.TargetPowerSupply.txtPulseWidthRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.TargetPowerSupply.txtPulseWidthRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.TargetPowerSupply.txtRampTimeRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.TargetPowerSupply.txtRampTimeRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.BiasPowerSupply.txtC1RightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.BiasPowerSupply.txtC1RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.BiasPowerSupply.txtC2RightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.BiasPowerSupply.txtC2RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.BiasPowerSupply.txtPresetsRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.BiasPowerSupply.txtPresetsRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtRotateRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtRotateRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtTablePosRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtTablePosRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtPressureMax</Key>" & _
"      <Value>100</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtPressureMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtPressure_PercentMax</Key>" & _
"      <Value>100</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtPressure_PercentMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtT1LimitMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtT1LimitMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtT2LimitMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtT2LimitMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtT3LimitMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtT3LimitMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtT4LimitMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtT4LimitMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtT1UsageMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtT1UsageMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtT2UsageMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtT2UsageMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtT3UsageMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtT3UsageMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtT4UsageMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtT4UsageMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtT5UsageMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtT5UsageMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtT1WarningMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtT1WarningMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtT2WarningMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtT2WarningMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtT3WarningMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtT3WarningMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtT4WarningMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtT4WarningMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtT1ShieldsQuartzMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtT1ShieldsQuartzMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtT2ShieldsQuartzMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtT2ShieldsQuartzMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtT3ShieldsQuartzMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtT3ShieldsQuartzMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtT4ShieldsQuartzMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtT4ShieldsQuartzMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtT1TargetMaterialMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtT1TargetMaterialMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtT2TargetMaterialMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtT2TargetMaterialMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtT3TargetMaterialMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtT3TargetMaterialMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtT4TargetMaterialMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtT4TargetMaterialMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtHeaterZone1SPMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtHeaterZone2SPMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtHeaterZone1SPMax</Key>" & _
"      <Value>10000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.txtHeaterZone2SPMax</Key>" & _
"      <Value>10000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.StaticPostionMax</Key>" & _
"      <Value>8</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber2.PVD4.StaticPostionMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtGas1RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtGas1RightMax</Key>" & _
"      <Value>290</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtGas2RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtGas2RightMax</Key>" & _
"      <Value>100</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtGas3RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtGas3RightMax</Key>" & _
"      <Value>100</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtGas4RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtGas4RightMax</Key>" & _
"      <Value>100</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtGas5RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtGas5RightMax</Key>" & _
"      <Value>100</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.TargetPowerSupply.txtForwardPowerRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.TargetPowerSupply.txtForwardPowerRightMax</Key>" & _
"      <Value>10000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.BiasPowerSupply.txtForwardPowerRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.BiasPowerSupply.txtForwardPowerRightMax</Key>" & _
"      <Value>2000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.BiasPowerSupply.txtVoltageRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.BiasPowerSupply.txtVoltageRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.TargetPowerSupply.txtC1RightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.TargetPowerSupply.txtC1RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.TargetPowerSupply.txtC2RightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.TargetPowerSupply.txtC2RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.TargetPowerSupply.txtPresetsRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.TargetPowerSupply.txtPresetsRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.TargetPowerSupply.txtDCForwardPowerRightMax</Key>" & _
"      <Value>5000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.TargetPowerSupply.txtDCForwardPowerRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.TargetPowerSupply.txtPulseFrequencyRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.TargetPowerSupply.txtPulseFrequencyRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.TargetPowerSupply.txtPulseWidthRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.TargetPowerSupply.txtPulseWidthRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.TargetPowerSupply.txtRampTimeRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.TargetPowerSupply.txtRampTimeRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.BiasPowerSupply.txtC1RightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.BiasPowerSupply.txtC1RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.BiasPowerSupply.txtC2RightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.BiasPowerSupply.txtC2RightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.BiasPowerSupply.txtPresetsRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.BiasPowerSupply.txtPresetsRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtRotateRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtRotateRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtTablePosRightMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtTablePosRightMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtPressureMax</Key>" & _
"      <Value>100</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtPressureMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtPressure_PercentMax</Key>" & _
"      <Value>100</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtT1LimitMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtT1LimitMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtT2LimitMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtT2LimitMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtT3LimitMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtT3LimitMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtT4LimitMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtT4LimitMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtT1UsageMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtT1UsageMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtT2UsageMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtT2UsageMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtT3UsageMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtT3UsageMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtT4UsageMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtT4UsageMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtT5UsageMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtT5UsageMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtT1WarningMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtT1WarningMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtT2WarningMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtT2WarningMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtT3WarningMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtT3WarningMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtT4WarningMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtT4WarningMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtT1ShieldsQuartzMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtT1ShieldsQuartzMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtT2ShieldsQuartzMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtT2ShieldsQuartzMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtT3ShieldsQuartzMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtT3ShieldsQuartzMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtT4ShieldsQuartzMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtT4ShieldsQuartzMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtT1TargetMaterialMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtT1TargetMaterialMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtT2TargetMaterialMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtT2TargetMaterialMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtT3TargetMaterialMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtT3TargetMaterialMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtT4TargetMaterialMax</Key>" & _
"      <Value>50000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtT4TargetMaterialMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtPressure_PercentMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtHeaterZone1SPMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtHeaterZone2SPMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtHeaterZone1SPMax</Key>" & _
"      <Value>10000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.txtHeaterZone2SPMax</Key>" & _
"      <Value>10000</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.StaticPostionMax</Key>" & _
"      <Value>8</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Chamber3.PVD4.StaticPostionMin</Key>" & _
"      <Value>0</Value>" & _
"    </MessageText>" & _
"  </Modules>" & _
"  <RoughPumpConfig>" & _
"    <RoughPump Name=""RoughPumpMachine1"">" & _
"      <Item>CassettesModule</Item>" & _
"      <Item>LoadLockA</Item>" & _
"      <Item>Chamber3</Item>" & _
"    </RoughPump>" & _
"    <RoughPump Name=""RoughPumpMachine2"" />" & _
"    <RoughPump Name=""RoughPumpMachine3"" />" & _
"  </RoughPumpConfig>" & _
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
"      <Key>Chamber2</Key>" & _
"      <Value>200</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>Chamber3</Key>" & _
"      <Value>200</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>IBEMaintainance</Key>" & _
"      <Value>1.23</Value>" & _
"    </Configure>" & _
"    <!--IG_Formula=Type1 (10^({0} - 10)) or Type2 (10^({0} - 11))-->" & _
"    <Configure>" & _
"      <Key>IG_Formula</Key>" & _
"      <Formula>Type1</Formula>" & _
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
"      <Key>InterlockSafetyTMCG</Key>" & _
"      <Value>0.5</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>InterlockSafetyLLACG</Key>" & _
"      <Value>0.02</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>TMCryo_T1Min</Key>" & _
"      <Value>10</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>TMCryo_T1Max</Key>" & _
"      <Value>100</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>TMCryo_T2Min</Key>" & _
"      <Value>5</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>TMCryo_T2Max</Key>" & _
"      <Value>100</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>LLACryo_T1Min</Key>" & _
"      <Value>10</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>LLACryo_T1Max</Key>" & _
"      <Value>100</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>LLACryo_T2Min</Key>" & _
"      <Value>5</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>LLACryo_T2Max</Key>" & _
"      <Value>100</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>TMPumpPackage_TurboUptoSpeedThreshold</Key>" & _
"      <Value>50</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>LLAPumpPackage_TurboUptoSpeedThreshold</Key>" & _
"      <Value>50</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>Rotation_Tilt_Angle</Key>" & _
"      <Value>90</Value>" & _
"    </Configure>" & _
"  </SystemPressure>" & _
"  <KepServerTagsStatus>" & _
"    <!--LoadLockA.SlitValve-->" & _
"    <CassettesModule.SplitValveLLA>" & _
"      <Action Name=""CassettesModule.SplitValveLLA On"" Value=""TM.TMC.RO.Mesa1_Closed=False;TM.TMC.RO.Mesa1_Open=True"" />" & _
"      <Action Name=""CassettesModule.SplitValveLLA Off"" Value=""TM.TMC.RO.Mesa1_Closed=True;TM.TMC.RO.Mesa1_Open=False"" />" & _
"      <Action Name=""CassettesModule.SplitValveLLA Unknown"" Value=""TM.TMC.RO.Mesa1_Closed=False;TM.TMC.RO.Mesa1_Open=False"" />" & _
"    </CassettesModule.SplitValveLLA>" & _
"    <Status Name=""CassettesModule.SplitValve1OpenStatus"" Value=""TM.TMC.DI.Mesa1_Closed_FB=False;TM.TMC.DI.Mesa1_Open_FB=True"" />" & _
"    <Status Name=""CassettesModule.SplitValve1CloseStatus"" Value=""TM.TMC.DI.Mesa1_Closed_FB=True;TM.TMC.DI.Mesa1_Open_FB=False"" />" & _
"    <!--Chamber1.SlitValve-->" & _
"    <CassettesModule.SplitValvePM1>" & _
"      <Action Name=""CassettesModule.SplitValvePM1 On"" Value=""TM.TMC.RO.Mesa2_Closed=False;TM.TMC.RO.Mesa2_Open=True"" />" & _
"      <Action Name=""CassettesModule.SplitValvePM1 Off"" Value=""TM.TMC.RO.Mesa2_Closed=True;TM.TMC.RO.Mesa2_Open=False"" />" & _
"      <Action Name=""CassettesModule.SplitValvePM1 Unknown"" Value=""TM.TMC.RO.Mesa2_Closed=False;TM.TMC.RO.Mesa2_Open=False"" />" & _
"    </CassettesModule.SplitValvePM1>" & _
"    <Status Name=""CassettesModule.SplitValve2OpenStatus"" Value=""TM.TMC.DI.Mesa2_Closed_FB=False;TM.TMC.DI.Mesa2_Open_FB=True"" />" & _
"    <Status Name=""CassettesModule.SplitValve2CloseStatus"" Value=""TM.TMC.DI.Mesa2_Closed_FB=True;TM.TMC.DI.Mesa2_Open_FB=False"" />" & _
"    <!--Chamber2.SlitValve-->" & _
"    <CassettesModule.SplitValvePM2>" & _
"      <Action Name=""CassettesModule.SplitValvePM2 On"" Value=""TM.TMC.RO.Mesa3_Closed=False;TM.TMC.RO.Mesa3_Open=True"" />" & _
"      <Action Name=""CassettesModule.SplitValvePM2 Off"" Value=""TM.TMC.RO.Mesa3_Closed=True;TM.TMC.RO.Mesa3_Open=False"" />" & _
"      <Action Name=""CassettesModule.SplitValvePM2 Unknown"" Value=""TM.TMC.RO.Mesa3_Closed=False;TM.TMC.RO.Mesa3_Open=False"" />" & _
"    </CassettesModule.SplitValvePM2>" & _
"    <Status Name=""CassettesModule.SplitValve3OpenStatus"" Value=""TM.TMC.DI.Mesa3_Closed_FB=False;TM.TMC.DI.Mesa3_Open_FB=True"" />" & _
"    <Status Name=""CassettesModule.SplitValve3CloseStatus"" Value=""TM.TMC.DI.Mesa3_Closed_FB=True;TM.TMC.DI.Mesa3_Open_FB=False"" />" & _
"    <!--Chamber3.SlitValve-->" & _
"    <CassettesModule.SplitValvePM3>" & _
"      <Action Name=""CassettesModule.SplitValvePM3 On"" Value=""TM.TMC.RO.Mesa4_Closed=False;TM.TMC.RO.Mesa4_Open=True"" />" & _
"      <Action Name=""CassettesModule.SplitValvePM3 Off"" Value=""TM.TMC.RO.Mesa4_Closed=True;TM.TMC.RO.Mesa4_Open=False"" />" & _
"      <Action Name=""CassettesModule.SplitValvePM3 Unknown"" Value=""TM.TMC.RO.Mesa4_Closed=False;TM.TMC.RO.Mesa4_Open=False"" />" & _
"    </CassettesModule.SplitValvePM3>" & _
"    <Status Name=""CassettesModule.SplitValve4OpenStatus"" Value=""TM.TMC.DI.Mesa4_Closed_FB=False;TM.TMC.DI.Mesa4_Open_FB=True"" />" & _
"    <Status Name=""CassettesModule.SplitValve4CloseStatus"" Value=""TM.TMC.DI.Mesa4_Closed_FB=True;TM.TMC.DI.Mesa4_Open_FB=False"" />" & _
"    <Status Name=""CassettesModule.SplitValve8Status On"" Value=""TM.TMC.DI.Mesa8_Closed_FB=False;TM.TMC.DI.Mesa8_Open_FB=True"" />" & _
"    <Status Name=""CassettesModule.SplitValve8Status Off"" Value=""TM.TMC.DI.Mesa8_Closed_FB=True;TM.TMC.DI.Mesa8_Open_FB=False"" />" & _
"    <!--LoadLockA.SlowVentValve-->" & _
"    <LoadLockA.LLSlowVent>" & _
"      <Action Name=""LoadLockA.LLSlowVent On"" Value=""TM.TMC.RO.Cas1_Sl_V=True"" />" & _
"      <Action Name=""LoadLockA.LLSlowVent Off"" Value=""TM.TMC.RO.Cas1_Sl_V=False"" />" & _
"      <Status Name=""LoadLockA.SlowVentValveStatus On"" Value=""TM.TMC.RO.Cas1_Sl_V=True"" />" & _
"      <Status Name=""LoadLockA.SlowVentValveStatus Off"" Value=""TM.TMC.RO.Cas1_Sl_V=False"" />" & _
"    </LoadLockA.LLSlowVent>" & _
"    <!--LoadLockA.FastVentValve-->" & _
"    <LoadLockA.LLFastVent>" & _
"      <Action Name=""LoadLockA.LLFastVent On"" Value=""TM.TMC.RO.Cas1_Vent=True"" />" & _
"      <Action Name=""LoadLockA.LLFastVent Off"" Value=""TM.TMC.RO.Cas1_Vent=False"" />" & _
"      <Status Name=""LoadLockA.FastVentValveStatus On"" Value=""TM.TMC.RO.Cas1_Vent=True"" />" & _
"      <Status Name=""LoadLockA.FastVentValveStatus Off"" Value=""TM.TMC.RO.Cas1_Vent=False"" />" & _
"    </LoadLockA.LLFastVent>" & _
"    <!--LoadLockA.SlowRoughValve-->" & _
"    <LoadLockA.LLSlowRough>" & _
"      <Action Name=""LoadLockA.LLSlowRough On"" Value=""TM.TMC.RO.Cas1_Sl_R=True"" />" & _
"      <Action Name=""LoadLockA.LLSlowRough Off"" Value=""TM.TMC.RO.Cas1_Sl_R=False"" />" & _
"      <Status Name=""LoadLockA.SlowRoughValveStatus On"" Value=""TM.TMC.RO.Cas1_Sl_R=True"" />" & _
"      <Status Name=""LoadLockA.SlowRoughValveStatus Off"" Value=""TM.TMC.RO.Cas1_Sl_R=False"" />" & _
"    </LoadLockA.LLSlowRough>" & _
"    <!--LoadLockA.FastRoughValve-->" & _
"    <LoadLockA.LLFastRough>" & _
"      <Action Name=""LoadLockA.LLFastRough On"" Value=""TM.TMC.RO.Cas1_Rough=True"" />" & _
"      <Action Name=""LoadLockA.LLFastRough Off"" Value=""TM.TMC.RO.Cas1_Rough=False"" />" & _
"      <Status Name=""LoadLockA.FastRoughValveStatus On"" Value=""TM.TMC.RO.Cas1_Rough=True"" />" & _
"      <Status Name=""LoadLockA.FastRoughValveStatus Off"" Value=""TM.TMC.RO.Cas1_Rough=False"" />" & _
"    </LoadLockA.LLFastRough>" & _
"    <!--CassettesModule.VentValve-->" & _
"    <CassettesModule.Vent>" & _
"      <Action Name=""CassettesModule.Vent On"" Value=""TM.TMC.RO.WTM_Vent=True"" />" & _
"      <Action Name=""CassettesModule.Vent Off"" Value=""TM.TMC.RO.WTM_Vent=False"" />" & _
"      <Status Name=""CassettesModule.FastVentValveStatus On"" Value=""TM.TMC.RO.WTM_Vent=True"" />" & _
"      <Status Name=""CassettesModule.FastVentValveStatus Off"" Value=""TM.TMC.RO.WTM_Vent=False"" />" & _
"    </CassettesModule.Vent>" & _
"    <!--CassettesModule.RoughValve-->" & _
"    <CassettesModule.Rough>" & _
"      <Action Name=""CassettesModule.Rough On"" Value=""TM.TMC.RO.WTM_Rough=True"" />" & _
"      <Action Name=""CassettesModule.Rough Off"" Value=""TM.TMC.RO.WTM_Rough=False"" />" & _
"      <Status Name=""CassettesModule.FastRoughValveStatus On"" Value=""TM.TMC.RO.WTM_Rough=True"" />" & _
"      <Status Name=""CassettesModule.FastRoughValveStatus Off"" Value=""TM.TMC.RO.WTM_Rough=False"" />" & _
"    </CassettesModule.Rough>" & _
"    <!--LoadLockA.HiVacValve-->" & _
"    <LoadLockA.LLHiVac>" & _
"      <Action Name=""LoadLockA.LLHiVac On"" Value=""TM.TMC.RO.Cas1_HV=True"" />" & _
"      <Action Name=""LoadLockA.LLHiVac Off"" Value=""TM.TMC.RO.Cas1_HV=False"" />" & _
"    </LoadLockA.LLHiVac>" & _
"    <Status Name=""LoadLockA.HiVacValveOpenStatus"" Value=""TM.TMC.DI.Cas1HiVac_V_LSB_FB=False;TM.TMC.DI.Cas1HiVac_V_MSB_FB=True"" />" & _
"    <Status Name=""LoadLockA.HiVacValveCloseStatus"" Value=""TM.TMC.DI.Cas1HiVac_V_LSB_FB=True;TM.TMC.DI.Cas1HiVac_V_MSB_FB=False"" />" & _
"    <!--CassettesModule.HiVacValve-->" & _
"    <CassettesModule.TMHiVac>" & _
"      <Action Name=""CassettesModule.TMHiVac On"" Value=""TM.TMC.RO.WTM_HV=True"" />" & _
"      <Action Name=""CassettesModule.TMHiVac Off"" Value=""TM.TMC.RO.WTM_HV=False"" />" & _
"    </CassettesModule.TMHiVac>" & _
"    <Status Name=""CassettesModule.HiVacValveOpenStatus"" Value=""TM.TMC.DI.WTM_HiVac_V_LSB_FB=False;TM.TMC.DI.WTM_HiVac_V_MSB_FB=True"" />" & _
"    <Status Name=""CassettesModule.HiVacValveCloseStatus"" Value=""TM.TMC.DI.WTM_HiVac_V_LSB_FB=True;TM.TMC.DI.WTM_HiVac_V_MSB_FB=False"" />" & _
"    <!--Status Name=""CassettesModule.VacSwitchStatus On"" Value=""TM.TMC.DI.WTM_VacSwitch_FB=True"" /-->" & _
"    <!--Status Name=""CassettesModule.VacSwitchStatus Off"" Value=""TM.TMC.DI.WTM_VacSwitch_FB=False"" /-->" & _
"    <CassettesModule.IgDegas>" & _
"      <Action Name=""CassettesModule.IgDegas On"" Value=""TM.TMC.RO.WTM_IgDegas=True"" />" & _
"      <Action Name=""CassettesModule.IgDegas Off"" Value=""TM.TMC.RO.WTM_IgDegas=False"" />" & _
"    </CassettesModule.IgDegas>" & _
"    <!--LoadLockA.IGStatus-->" & _
"    <LoadLockA.Ion>" & _
"      <Action Name=""LoadLockA.Ion On"" Value=""TM.TMC.RO.Cas1Ion=True"" />" & _
"      <Action Name=""LoadLockA.Ion Off"" Value=""TM.TMC.RO.Cas1Ion=False"" />" & _
"    </LoadLockA.Ion>" & _
"    <LoadLockA.CG>" & _
"      <Status Name=""LoadLockA.IGStatus On"" Value=""TM.TMC.DI.CAS1IgStatus_FB=True"" />" & _
"      <Status Name=""LoadLockA.IGStatus Off"" Value=""TM.TMC.DI.CAS1IgStatus_FB=False"" />" & _
"    </LoadLockA.CG>" & _
"    <!--Status Name=""LoadLockA.VacSwitchStatus On"" Value=""TM.TMC.DI.Cas1VacSwitch_FB=True"" /-->" & _
"    <!--Status Name=""LoadLockA.VacSwitchStatus Off"" Value=""TM.TMC.DI.Cas1VacSwitch_FB=False"" /-->" & _
"    <LoadLockA.IgDegas>" & _
"      <Action Name=""LoadLockA.IgDegas On"" Value=""TM.TMC.RO.Cas1_IgDegas=True"" />" & _
"      <Action Name=""LoadLockA.IgDegas Off"" Value=""TM.TMC.RO.Cas1_IgDegas=False"" />" & _
"    </LoadLockA.IgDegas>" & _
"    <!--CassettesModule.IGStatus-->" & _
"    <CassettesModule.Ion>" & _
"      <Action Name=""CassettesModule.Ion On"" Value=""TM.TMC.RO.WTM_Ion_S=True"" />" & _
"      <Action Name=""CassettesModule.Ion Off"" Value=""TM.TMC.RO.WTM_Ion_S=False"" />" & _
"    </CassettesModule.Ion>" & _
"    <CassettesModule.CG>" & _
"      <Status Name=""CassettesModule.IGStatus On"" Value=""TM.TMC.DI.WTM_IgStatus_FB=True"" />" & _
"      <Status Name=""CassettesModule.IGStatus Off"" Value=""TM.TMC.DI.WTM_IgStatus_FB=False"" />" & _
"    </CassettesModule.CG>" & _
"    <!--Sensors-->" & _
"    <CassettesModule.SensorLLAStatus>" & _
"      <Status Name=""CassettesModule.SensorLLAStatus On"" Value=""TM.TMC.DI.WaferSensor1_FB=True"" />" & _
"      <Status Name=""CassettesModule.SensorLLAStatus Off"" Value=""TM.TMC.DI.WaferSensor1_FB=False"" />" & _
"    </CassettesModule.SensorLLAStatus>" & _
"    <CassettesModule.SensorPM1Status>" & _
"      <Status Name=""CassettesModule.SensorPM1Status On"" Value=""TM.TMC.DI.WaferSensor2_FB=True"" />" & _
"      <Status Name=""CassettesModule.SensorPM1Status Off"" Value=""TM.TMC.DI.WaferSensor2_FB=False"" />" & _
"    </CassettesModule.SensorPM1Status>" & _
"    <CassettesModule.SensorPM2Status>" & _
"      <Status Name=""CassettesModule.SensorPM2Status On"" Value=""TM.TMC.DI.WaferSensor3_FB=True"" />" & _
"      <Status Name=""CassettesModule.SensorPM2Status Off"" Value=""TM.TMC.DI.WaferSensor3_FB=False"" />" & _
"    </CassettesModule.SensorPM2Status>" & _
"    <CassettesModule.SensorPM3Status>" & _
"      <Status Name=""CassettesModule.SensorPM3Status On"" Value=""TM.TMC.DI.WaferSensor4_FB=True"" />" & _
"      <Status Name=""CassettesModule.SensorPM3Status Off"" Value=""TM.TMC.DI.WaferSensor4_FB=False"" />" & _
"    </CassettesModule.SensorPM3Status>" & _
"    <TMPumpPackage>" & _
"      <Status Name=""TMPumpPackage.TurboUptoSpeed True"" Value=""TM.TMC.DI.WTM_Turbo_Ready_FB=True"" />" & _
"      <Status Name=""TMPumpPackage.TurboUptoSpeed False"" Value=""TM.TMC.DI.WTM_Turbo_Ready_FB=False"" />" & _
"      <Status Name=""TMPumpPackage.TurboError True"" Value=""TM.TMC.DI.TM_Turbo_Error_FB=True"" />" & _
"      <Status Name=""TMPumpPackage.TurboError False"" Value=""TM.TMC.DI.TM_Turbo_Error_FB=False"" />" & _
"      <Action Name=""TMPumpPackage.TurboStatus On"" Value=""TM.TMC.RO.WTM_Turbo_OnOff=True"" />" & _
"      <Action Name=""TMPumpPackage.TurboStatus Off"" Value=""TM.TMC.RO.WTM_Turbo_OnOff=False"" />" & _
"      <Status Name=""TMPumpPackage.TurboStatus True"" Value=""TM.TMC.RO.WTM_Turbo_OnOff=True"" />" & _
"      <Status Name=""TMPumpPackage.TurboStatus False"" Value=""TM.TMC.RO.WTM_Turbo_OnOff=False"" />" & _
"    </TMPumpPackage>" & _
"    <LLAPumpPackage>" & _
"      <Status Name=""LLAPumpPackage.TurboUptoSpeed True"" Value=""TM.TMC.DI.Cas1_Turbo_Ready_FB=True"" />" & _
"      <Status Name=""LLAPumpPackage.TurboUptoSpeed False"" Value=""TM.TMC.DI.Cas1_Turbo_Ready_FB=False"" />" & _
"      <Status Name=""LLAPumpPackage.TurboError True"" Value=""TM.TMC.DI.LLA_Turbo_Error_FB=True"" />" & _
"      <Status Name=""LLAPumpPackage.TurboError False"" Value=""TM.TMC.DI.LLA_Turbo_Error_FB=False"" />" & _
"      <Action Name=""LLAPumpPackage.TurboStatus On"" Value=""TM.TMC.RO.Cas1_Turbo_OnOff=True"" />" & _
"      <Action Name=""LLAPumpPackage.TurboStatus Off"" Value=""TM.TMC.RO.Cas1_Turbo_OnOff=False"" />" & _
"      <Status Name=""LLAPumpPackage.TurboStatus True"" Value=""TM.TMC.RO.Cas1_Turbo_OnOff=True"" />" & _
"      <Status Name=""LLAPumpPackage.TurboStatus False"" Value=""TM.TMC.RO.Cas1_Turbo_OnOff=False"" />" & _
"    </LLAPumpPackage>" & _
"    <Status Name=""CassettesModule.RoughPump1Status On"" Value=""TM.TMC.RO.Mechanical_Pump1_OnOff=True"" />" & _
"    <Status Name=""CassettesModule.RoughPump1Status Off"" Value=""TM.TMC.RO.Mechanical_Pump1_OnOff=False"" />" & _
"    <Status Name=""CassettesModule.RoughPump2Status On"" Value=""TM.TMC.RO.Mechanical_Pump2_OnOff=True"" />" & _
"    <Status Name=""CassettesModule.RoughPump2Status Off"" Value=""TM.TMC.RO.Mechanical_Pump2_OnOff=False"" />" & _
"    <Action Name=""CassettesModule.RoughPump1Status On"" Value=""TM.TMC.RO.Mechanical_Pump1_OnOff=True"" />" & _
"    <Action Name=""CassettesModule.RoughPump1Status Off"" Value=""TM.TMC.RO.Mechanical_Pump1_OnOff=False"" />" & _
"    <Action Name=""CassettesModule.RoughPump2Status On"" Value=""TM.TMC.RO.Mechanical_Pump2_OnOff=True"" />" & _
"    <Action Name=""CassettesModule.RoughPump2Status Off"" Value=""TM.TMC.RO.Mechanical_Pump2_OnOff=False"" />" & _
"    <Action Name=""CassettesModule.Process_Complete_Chime Off"" Value=""TM.TMC.RO.Process_Complete_Chime=False"" />" & _
"    <Action Name=""CassettesModule.Process_Complete_Chime On"" Value=""TM.TMC.RO.Process_Complete_Chime=True"" />" & _
"    <Status Name=""CassettesModule.Process_Complete_Chime Off"" Value=""TM.TMC.RO.Process_Complete_Chime=False"" />" & _
"    <Status Name=""CassettesModule.Process_Complete_Chime On"" Value=""TM.TMC.RO.Process_Complete_Chime=True"" />" & _
"    <!--Alarms-->" & _
"    <Action Name=""Alarm.AlarmStatus On"" Value=""TM.TMC.RO.EMO_Alarm=True"" />" & _
"    <Action Name=""Alarm.AlarmStatus Off"" Value=""TM.TMC.RO.EMO_Alarm=False"" />" & _
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
"    <Action Name=""Alarm.BlueStatus On"" Value=""TM.TMC.RO.System_Warning=True"" />" & _
"    <Action Name=""Alarm.BlueStatus Off"" Value=""TM.TMC.RO.System_Warning=False"" />" & _
"    <Status Name=""Alarm.BlueStatus On"" Value=""TM.TMC.RO.System_Warning=True"" />" & _
"    <Status Name=""Alarm.BlueStatus Off"" Value=""TM.TMC.RO.System_Warning=False"" />" & _
"    <Status Name=""Alarm.ConnectStatus On"" Value=""TM.TMC._System._Error=True"" />" & _
"    <Status Name=""Alarm.ConnectStatus Off"" Value=""TM.TMC._System._Error=False"" />" & _
"  </KepServerTagsStatus>" & _
"  <KepServerTagsDef>" & _
"    <Group Name=""TM.TMC"" IsActive=""True"" DeadBand=""0"" UpdateRate=""100"">" & _
"      <Item DisplayGroup=""TM.TMC"" PropertyName=""CassettesModule.KepWareServerDisConnected"" KepServerName=""TM.TMC._System._Error"" DataType=""Boolean"" Desc=""KepWare Connection"" />" & _
"      <LoadLockA.CG>" & _
"        <Item DisplayGroup=""TM.TMC.AI"" PropertyName=""LoadLockA.CG"" KepServerName=""TM.TMC.AI.Cas1_GP275_FB"" DataType=""Double"" Desc=""Load Lock A - CG"" />" & _
"      </LoadLockA.CG>" & _
"      <LoadLockA.IG>" & _
"        <Item DisplayGroup=""TM.TMC.AI"" PropertyName=""LoadLockA.IG"" KepServerName=""TM.TMC.AI.Cas1_Ion_FB"" DataType=""Double"" Desc=""Load Lock A - IG"" />" & _
"      </LoadLockA.IG>" & _
"      <CassettesModule.CG>" & _
"        <Item DisplayGroup=""TM.TMC.AI"" PropertyName=""CassettesModule.CG"" KepServerName=""TM.TMC.AI.WTM_GP275_FB"" DataType=""Double"" Desc=""TM CG"" />" & _
"      </CassettesModule.CG>" & _
"      <CassettesModule.IG>" & _
"        <Item DisplayGroup=""TM.TMC.AI"" PropertyName=""CassettesModule.IG"" KepServerName=""TM.TMC.AI.WTM_Ion_V_FB"" DataType=""Double"" Desc=""TM IG"" />" & _
"      </CassettesModule.IG>" & _
"      <RoughPumpMachine1.CG>" & _
"        <Item DisplayGroup=""TM.TMC.AI"" PropertyName=""RoughPumpMachine1.CG"" KepServerName=""TM.TMC.AI.WTM_MP1_275_FB"" DataType=""Double"" Desc=""RoughPumpMachine1 CG"" />" & _
"      </RoughPumpMachine1.CG>" & _
"      <RoughPumpMachine2.CG>" & _
"        <Item DisplayGroup=""TM.TMC.AI"" PropertyName=""RoughPumpMachine2.CG"" KepServerName=""TM.TMC.AI.WTM_MP2_275_FB"" DataType=""Double"" Desc=""RoughPumpMachine2 CG"" />" & _
"      </RoughPumpMachine2.CG>" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""LoadLockA.HiVacValveStatus"" KepServerName=""TM.TMC.DI.Cas1HiVac_V_LSB_FB"" DataType=""Boolean"" Desc=""Load Lock A - Hivac Valve "" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""LoadLockA.HiVacValveStatus"" KepServerName=""TM.TMC.DI.Cas1HiVac_V_MSB_FB"" DataType=""Boolean"" Desc=""Load Lock A - Hivac Valve "" />" & _
"      <LoadLockA.IGStatus>" & _
"        <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""LoadLockA.IGStatus"" KepServerName=""TM.TMC.DI.CAS1IgStatus_FB"" DataType=""Boolean"" Desc=""Load Lock A - IGStatus"" />" & _
"      </LoadLockA.IGStatus>" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""CassettesModule.HiVacValveStatus"" KepServerName=""TM.TMC.DI.WTM_HiVac_V_LSB_FB"" DataType=""Boolean"" Desc=""TM - Hivac Valve "" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""CassettesModule.HiVacValveStatus"" KepServerName=""TM.TMC.DI.WTM_HiVac_V_MSB_FB"" DataType=""Boolean"" Desc=""TM - Hivac Valve "" />" & _
"      <CassettesModule.IGStatus>" & _
"        <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""CassettesModule.IGStatus"" KepServerName=""TM.TMC.DI.WTM_IgStatus_FB"" DataType=""Boolean"" Desc=""TM Ig Status"" />" & _
"      </CassettesModule.IGStatus>" & _
"      <!--Item DisplayGroup=""TM.TMC.DI"" PropertyName=""CassettesModule.VacSwitchStatus"" KepServerName=""TM.TMC.DI.WTM_VacSwitch_FB"" DataType=""Boolean"" Desc=""Vac Switch of TM"" /-->" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""CassettesModule.SplitValve1Status"" KepServerName=""TM.TMC.DI.Mesa1_Closed_FB"" DataType=""Boolean"" Desc=""Slit Valve 1 Status"" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""CassettesModule.SplitValve1Status"" KepServerName=""TM.TMC.DI.Mesa1_Open_FB"" DataType=""Boolean"" Desc=""Slit Valve 1 Status"" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""CassettesModule.SplitValve2Status"" KepServerName=""TM.TMC.DI.Mesa2_Closed_FB"" DataType=""Boolean"" Desc=""Slit Valve 2 Status"" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""CassettesModule.SplitValve2Status"" KepServerName=""TM.TMC.DI.Mesa2_Open_FB"" DataType=""Boolean"" Desc=""Slit Valve 2 Status"" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""CassettesModule.SplitValve3Status"" KepServerName=""TM.TMC.DI.Mesa3_Closed_FB"" DataType=""Boolean"" Desc=""Slit Valve 3 Status"" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""CassettesModule.SplitValve3Status"" KepServerName=""TM.TMC.DI.Mesa3_Open_FB"" DataType=""Boolean"" Desc=""Slit Valve 3 Status"" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""CassettesModule.SplitValve4Status"" KepServerName=""TM.TMC.DI.Mesa4_Closed_FB"" DataType=""Boolean"" Desc=""Slit Valve 4 Status"" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""CassettesModule.SplitValve4Status"" KepServerName=""TM.TMC.DI.Mesa4_Open_FB"" DataType=""Boolean"" Desc=""Slit Valve 4 Status"" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""CassettesModule.SplitValve5Status"" KepServerName=""TM.TMC.DI.Mesa5_Closed_FB"" DataType=""Boolean"" Desc=""Slit Valve 5 Status"" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""CassettesModule.SplitValve5Status"" KepServerName=""TM.TMC.DI.Mesa5_Open_FB"" DataType=""Boolean"" Desc=""Slit Valve 5 Status"" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""CassettesModule.SplitValve6Status"" KepServerName=""TM.TMC.DI.Mesa6_Closed_FB"" DataType=""Boolean"" Desc=""Slit Valve 6 Status"" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""CassettesModule.SplitValve6Status"" KepServerName=""TM.TMC.DI.Mesa6_Open_FB"" DataType=""Boolean"" Desc=""Slit Valve 6 Status"" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""CassettesModule.SplitValve7Status"" KepServerName=""TM.TMC.DI.Mesa7_Closed_FB"" DataType=""Boolean"" Desc=""Slit Valve 7 Status"" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""CassettesModule.SplitValve7Status"" KepServerName=""TM.TMC.DI.Mesa7_Open_FB"" DataType=""Boolean"" Desc=""Slit Valve 7 Status"" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""CassettesModule.SplitValve8Status"" KepServerName=""TM.TMC.DI.Mesa8_Closed_FB"" DataType=""Boolean"" Desc=""Slit Valve 10 Status"" />" & _
"      <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""CassettesModule.SplitValve8Status"" KepServerName=""TM.TMC.DI.Mesa8_Open_FB"" DataType=""Boolean"" Desc=""Slit Valve 10 Status"" />" & _
"      <CassettesModule.SensorLLAStatus>" & _
"        <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""CassettesModule.SensorLLAStatus"" KepServerName=""TM.TMC.DI.WaferSensor1_FB"" DataType=""Boolean"" Desc=""Sensor of Load Lock A"" />" & _
"      </CassettesModule.SensorLLAStatus>" & _
"      <CassettesModule.SensorPM1Status>" & _
"        <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""CassettesModule.SensorPM1Status"" KepServerName=""TM.TMC.DI.WaferSensor2_FB"" DataType=""Boolean"" Desc=""Sensor of PM1"" />" & _
"      </CassettesModule.SensorPM1Status>" & _
"      <CassettesModule.SensorPM2Status>" & _
"        <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""CassettesModule.SensorPM2Status"" KepServerName=""TM.TMC.DI.WaferSensor3_FB"" DataType=""Boolean"" Desc=""Sensor of PM2"" />" & _
"      </CassettesModule.SensorPM2Status>" & _
"      <CassettesModule.SensorPM3Status>" & _
"        <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""CassettesModule.SensorPM3Status"" KepServerName=""TM.TMC.DI.WaferSensor4_FB"" DataType=""Boolean"" Desc=""Sensor of PM3"" />" & _
"      </CassettesModule.SensorPM3Status>" & _
"      <LoadLockA.LLFastRough>" & _
"        <Item DisplayGroup=""TM.TMC.RO"" PropertyName=""LoadLockA.FastRoughValveStatus"" KepServerName=""TM.TMC.RO.Cas1_Rough"" DataType=""Boolean"" Desc=""Rough Valve LLA"" />" & _
"      </LoadLockA.LLFastRough>" & _
"      <LoadLockA.LLSlowRough>" & _
"        <Item DisplayGroup=""TM.TMC.RO"" PropertyName=""LoadLockA.SlowRoughValveStatus"" KepServerName=""TM.TMC.RO.Cas1_Sl_R"" DataType=""Boolean"" Desc=""Slow Rough LLA"" />" & _
"      </LoadLockA.LLSlowRough>" & _
"      <LoadLockA.LLFastVent>" & _
"        <Item DisplayGroup=""TM.TMC.RO"" PropertyName=""LoadLockA.FastVentValveStatus"" KepServerName=""TM.TMC.RO.Cas1_Vent"" DataType=""Boolean"" Desc=""Vent Valve LLA"" />" & _
"      </LoadLockA.LLFastVent>" & _
"      <LoadLockA.LLSlowVent>" & _
"        <Item DisplayGroup=""TM.TMC.RO"" PropertyName=""LoadLockA.SlowVentValveStatus"" KepServerName=""TM.TMC.RO.Cas1_Sl_V"" DataType=""Boolean"" Desc=""Slow Vent LLA"" />" & _
"      </LoadLockA.LLSlowVent>" & _
"      <CassettesModule.Rough>" & _
"        <Item DisplayGroup=""TM.TMC.RO"" PropertyName=""CassettesModule.FastRoughValveStatus"" KepServerName=""TM.TMC.RO.WTM_Rough"" DataType=""Boolean"" Desc=""TM Hivac Valve"" />" & _
"      </CassettesModule.Rough>" & _
"      <CassettesModule.Vent>" & _
"        <Item DisplayGroup=""TM.TMC.RO"" PropertyName=""CassettesModule.FastVentValveStatus"" KepServerName=""TM.TMC.RO.WTM_Vent"" DataType=""Boolean"" Desc=""TM Vent Valve"" />" & _
"      </CassettesModule.Vent>" & _
"      <Item DisplayGroup=""TM.TMC.RO"" PropertyName=""Alarm.AlarmStatus"" KepServerName=""TM.TMC.RO.EMO_Alarm"" DataType=""Boolean"" Desc=""Alarm"" />" & _
"      <Item DisplayGroup=""TM.TMC.RO"" PropertyName=""Alarm.RedStatus"" KepServerName=""TM.TMC.RO.System_Error"" DataType=""Boolean"" Desc=""System Error"" />" & _
"      <Item DisplayGroup=""TM.TMC.RO"" PropertyName=""Alarm.GreenStatus"" KepServerName=""TM.TMC.RO.System_Running"" DataType=""Boolean"" Desc=""System Running"" />" & _
"      <Item DisplayGroup=""TM.TMC.RO"" PropertyName=""Alarm.OrangeStatus"" KepServerName=""TM.TMC.RO.System_Idle"" DataType=""Boolean"" Desc=""System Idle"" />" & _
"      <Item DisplayGroup=""TM.TMC.RO"" PropertyName=""Alarm.BlueStatus"" KepServerName=""TM.TMC.RO.System_Warning"" DataType=""Boolean"" Desc=""Light Stack System Warning"" />" & _
"      <LoadLockA.LLHiVac>" & _
"        <Item DisplayGroup=""TM.TMC.RO"" PropertyName=""LoadLockA.LLHiVac"" KepServerName=""TM.TMC.RO.Cas1_HV"" DataType=""Boolean"" Desc=""Hivac LLA"" />" & _
"      </LoadLockA.LLHiVac>" & _
"      <CassettesModule.TMHiVac>" & _
"        <Item DisplayGroup=""TM.TMC.RO"" PropertyName=""CassettesModule.TMHiVac"" KepServerName=""TM.TMC.RO.WTM_HV"" DataType=""Boolean"" Desc=""TM Hivac Valve"" />" & _
"      </CassettesModule.TMHiVac>" & _
"      <CassettesModule.SplitValveLLA>" & _
"        <Item DisplayGroup=""TM.TMC.RO"" PropertyName=""CassettesModule.SplitValveLLA"" KepServerName=""TM.TMC.RO.Mesa1_Open"" DataType=""Boolean"" Desc=""Mesa Valve LoadLock A"" />" & _
"        <Item DisplayGroup=""TM.TMC.RO"" PropertyName=""CassettesModule.SplitValveLLA"" KepServerName=""TM.TMC.RO.Mesa1_Closed"" DataType=""Boolean"" Desc=""Mesa Valve LoadLock A"" />" & _
"      </CassettesModule.SplitValveLLA>" & _
"      <CassettesModule.SplitValvePM1>" & _
"        <Item DisplayGroup=""TM.TMC.RO"" PropertyName=""CassettesModule.SplitValvePM1"" KepServerName=""TM.TMC.RO.Mesa2_Open"" DataType=""Boolean"" Desc=""Mesa Valve PM1"" />" & _
"        <Item DisplayGroup=""TM.TMC.RO"" PropertyName=""CassettesModule.SplitValvePM1"" KepServerName=""TM.TMC.RO.Mesa2_Closed"" DataType=""Boolean"" Desc=""Mesa Valve PM1"" />" & _
"      </CassettesModule.SplitValvePM1>" & _
"      <CassettesModule.SplitValvePM2>" & _
"        <Item DisplayGroup=""TM.TMC.RO"" PropertyName=""CassettesModule.SplitValvePM2"" KepServerName=""TM.TMC.RO.Mesa3_Open"" DataType=""Boolean"" Desc=""Mesa Valve PM2"" />" & _
"        <Item DisplayGroup=""TM.TMC.RO"" PropertyName=""CassettesModule.SplitValvePM2"" KepServerName=""TM.TMC.RO.Mesa3_Closed"" DataType=""Boolean"" Desc=""Mesa Valve PM2"" />" & _
"      </CassettesModule.SplitValvePM2>" & _
"      <CassettesModule.SplitValvePM3>" & _
"        <Item DisplayGroup=""TM.TMC.RO"" PropertyName=""CassettesModule.SplitValvePM3"" KepServerName=""TM.TMC.RO.Mesa4_Open"" DataType=""Boolean"" Desc=""Mesa Valve PM3"" />" & _
"        <Item DisplayGroup=""TM.TMC.RO"" PropertyName=""CassettesModule.SplitValvePM3"" KepServerName=""TM.TMC.RO.Mesa4_Closed"" DataType=""Boolean"" Desc=""Mesa Valve PM3"" />" & _
"      </CassettesModule.SplitValvePM3>" & _
"      <CassettesModule.Ion>" & _
"        <Item DisplayGroup=""TM.TMC.RO"" PropertyName=""CassettesModule.Ion"" KepServerName=""TM.TMC.RO.WTM_Ion_S"" DataType=""Boolean"" Desc=""TM IG Status"" />" & _
"      </CassettesModule.Ion>" & _
"      <LoadLockA.Ion>" & _
"        <Item DisplayGroup=""TM.TMC.RO"" PropertyName=""LoadLockA.Ion"" KepServerName=""TM.TMC.RO.Cas1Ion"" DataType=""Boolean"" Desc=""IG Status LLA"" />" & _
"      </LoadLockA.Ion>" & _
"      <CassettesModule.IgDegas>" & _
"        <Item DisplayGroup=""TM.TMC.RO"" PropertyName=""CassettesModule.IgDegas"" KepServerName=""TM.TMC.RO.WTM_IgDegas"" DataType=""Boolean"" Desc=""TM IG Degas Status"" />" & _
"      </CassettesModule.IgDegas>" & _
"      <LoadLockA.IgDegas>" & _
"        <Item DisplayGroup=""TM.TMC.RO"" PropertyName=""LoadLockA.IgDegas"" KepServerName=""TM.TMC.RO.Cas1_IgDegas"" DataType=""Boolean"" Desc=""IG Degas LLA"" />" & _
"      </LoadLockA.IgDegas>" & _
"      <TMPumpPackage>" & _
"        <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""TMPumpPackage.TurboUptoSpeed"" KepServerName=""TM.TMC.DI.WTM_Turbo_Ready_FB"" DataType=""Boolean"" Desc="""" />" & _
"        <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""TMPumpPackage.TurboError"" KepServerName=""TM.TMC.DI.TM_Turbo_Error_FB"" DataType=""Boolean"" Desc="""" />" & _
"        <Item DisplayGroup=""TM.TMC.RO"" PropertyName=""TMPumpPackage.TurboStatus"" KepServerName=""TM.TMC.RO.WTM_Turbo_OnOff"" DataType=""Boolean"" Desc="""" />" & _
"      </TMPumpPackage>" & _
"      <LLAPumpPackage>" & _
"        <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""LLAPumpPackage.TurboUptoSpeed"" KepServerName=""TM.TMC.DI.Cas1_Turbo_Ready_FB"" DataType=""Boolean"" Desc="""" />" & _
"        <Item DisplayGroup=""TM.TMC.DI"" PropertyName=""LLAPumpPackage.TurboError"" KepServerName=""TM.TMC.DI.LLA_Turbo_Error_FB"" DataType=""Boolean"" Desc="""" />" & _
"        <Item DisplayGroup=""TM.TMC.RO"" PropertyName=""LLAPumpPackage.TurboStatus"" KepServerName=""TM.TMC.RO.Cas1_Turbo_OnOff"" DataType=""Boolean"" Desc="""" />" & _
"      </LLAPumpPackage>" & _
"      <Item DisplayGroup=""TM.TMC.RO"" PropertyName=""CassettesModule.RoughPump1Status"" KepServerName=""TM.TMC.RO.Mechanical_Pump1_OnOff"" DataType=""Boolean"" Desc="""" />" & _
"      <Item DisplayGroup=""TM.TMC.RO"" PropertyName=""CassettesModule.RoughPump2Status"" KepServerName=""TM.TMC.RO.Mechanical_Pump2_OnOff"" DataType=""Boolean"" Desc="""" />" & _
"      <Item DisplayGroup=""TM.TMC.RO"" PropertyName=""CassettesModule.Process_Complete_Chime"" KepServerName=""TM.TMC.RO.Process_Complete_Chime"" DataType=""Boolean"" Desc="""" />" & _
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
"    <Property Name=""ElevatorWaferSlideOut"" Code=""Wafer Slide Out Detected"" />" & _
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
"    <Property Name=""TMPumpPackage._ERR 0400"" Code=""0400: Encounter Error."" />" & _
"    <Property Name=""LLAPumpPackage._ERR 0400"" Code=""0400: Encounter Error."" />" & _
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
"    <Property Name=""Robot._ERR 101"" Code=""_Err 101 - EEPROM Check Sum Error"" />" & _
"    <Property Name=""Robot._ERR 102"" Code=""_Err 102 - EEPROM Read-Write Error"" />" & _
"    <Property Name=""Robot._ERR 103"" Code=""_Err 103 - RAM Read-Write Error"" />" & _
"    <Property Name=""Robot._ERR 104"" Code=""_Err 104 - Motion Error During Initialization"" />" & _
"    <Property Name=""Robot._ERR 105"" Code=""_Err 105 - Radial Motion Error During Initialiation"" />" & _
"    <Property Name=""Robot._ERR 106"" Code=""_Err 106 - Z Motion Error During Initialiation"" />" & _
"    <Property Name=""Robot._ERR 107"" Code=""_Err 107 - PROM Checksum Error"" />" & _
"    <Property Name=""Robot._ERR 201"" Code=""_Err 201 - T Rotational Axis is not refrenced"" />" & _
"    <Property Name=""Robot._ERR 202"" Code=""_Err 202 - R Rotational Axis is not refrenced"" />" & _
"    <Property Name=""Robot._ERR 203"" Code=""_Err 203 - Z Rotational Axis is not refrenced"" />" & _
"    <Property Name=""Robot._ERR 204"" Code=""_Err 204 - Theta motion has not followed the frescribed profile within the allowed tolerance"" />" & _
"    <Property Name=""Robot._ERR 205"" Code=""_Err 205 - Radial motion has not followed the frescribed profile within the allowed tolerance"" />" & _
"    <Property Name=""Robot._ERR 206"" Code=""_Err 206 - Z motion has not followed the frescribed profile within the allowed tolerance"" />" & _
"    <Property Name=""Robot._ERR 207"" Code=""_Err 207 - Theta Read-Write Error"" />" & _
"    <Property Name=""Robot._ERR 208"" Code=""_Err 208 - Radial Read-Write Error"" />" & _
"    <Property Name=""Robot._ERR 209"" Code=""_Err 209 - Z Read-Write Error"" />" & _
"    <Property Name=""Robot._ERR 210"" Code=""_Err 210 - Not At Station"" />" & _
"    <Property Name=""Robot._ERR 211"" Code=""_Err 211 - Theta Motion Timeout"" />" & _
"    <Property Name=""Robot._ERR 212"" Code=""_Err 212 - Radius Motion Timeout"" />" & _
"    <Property Name=""Robot._ERR 213"" Code=""_Err 213 - Z Motion Timeout"" />" & _
"    <Property Name=""Robot._ERR 214"" Code=""_Err 214 - Theta Calibration Error"" />" & _
"    <Property Name=""Robot._ERR 215"" Code=""_Err 215 - Too many T Encoder counts lost"" />" & _
"    <Property Name=""Robot._ERR 216"" Code=""_Err 216 - Too many R Encoder counts lost"" />" & _
"    <Property Name=""Robot._ERR 217"" Code=""_Err 217 - Too many Z Encoder counts lost"" />" & _
"    <Property Name=""Robot._ERR 218"" Code=""_Err 218 - Theta Encoder Failure"" />" & _
"    <Property Name=""Robot._ERR 219"" Code=""_Err 219 - Radius Encoder Failure"" />" & _
"    <Property Name=""Robot._ERR 220"" Code=""_Err 220 - Radial Axis Not At Retract Position"" />" & _
"    <Property Name=""Robot._ERR 221"" Code=""_Err 221 - Invalid Arm Selection"" />" & _
"    <Property Name=""Robot._ERR 233"" Code=""_Err 233 - Extend To Station Not Enabled"" />" & _
"    <Property Name=""Robot._ERR 234"" Code=""_Err 234 - Valve Not Closed"" />" & _
"    <Property Name=""Robot._ERR 301"" Code=""_Err 301 - Mnemonic Already Used"" />" & _
"    <Property Name=""Robot._ERR 302"" Code=""_Err 302 - Expecting Mnemonic"" />" & _
"    <Property Name=""Robot._ERR 303"" Code=""_Err 303 - No Command Available"" />" & _
"    <Property Name=""Robot._ERR 304"" Code=""_Err 304 - Could Not Find Mnemonic"" />" & _
"    <Property Name=""Robot._ERR 305"" Code=""_Err 305 - Unrecognized Command; Expecting A Mnemonic"" />" & _
"    <Property Name=""Robot._ERR 306"" Code=""_Err 306 - Value Out Of Range"" />" & _
"    <Property Name=""Robot._ERR 307"" Code=""_Err 307 - Argument Not Found"" />" & _
"    <Property Name=""Robot._ERR 308"" Code=""_Err 308 - Bad Argument Code"" />" & _
"    <Property Name=""Robot._ERR 309"" Code=""_Err 309 - Command Not Supported"" />" & _
"    <Property Name=""Robot._ERR 310"" Code=""_Err 310 - Argument Limit"" />" & _
"    <Property Name=""Robot._ERR 311"" Code=""_Err 311 - CMD Is On And In Control Of The Robot"" />" & _
"    <Property Name=""Robot._ERR 350"" Code=""_Err 350 - Parser Error, Bad Node In Parse Tree"" />" & _
"    <Property Name=""Robot._ERR 351"" Code=""_Err 351 - Parser Error, Stack Overflow"" />" & _
"    <Property Name=""Robot._ERR 352"" Code=""_Err 352 - Parse Error, No Memory Available"" />" & _
"    <Property Name=""Robot._ERR 353"" Code=""_Err 353 - Unexpected Mail To Uio Task"" />" & _
"    <Property Name=""Robot._ERR 390"" Code=""_Err 390 - Checksum Is Invalid"" />" & _
"    <Property Name=""Robot._ERR 401"" Code=""_Err 401 - Bad Extension Value"" />" & _
"    <Property Name=""Robot._ERR 402"" Code=""_Err 402 - Bad Slot Number"" />" & _
"    <Property Name=""Robot._ERR 403"" Code=""_Err 403 - Bad Max Z Travel Value"" />" & _
"    <Property Name=""Robot._ERR 404"" Code=""_Err 404 - Bad BTO Value"" />" & _
"    <Property Name=""Robot._ERR 405"" Code=""_Err 405 - Bad Lower Position"" />" & _
"    <Property Name=""Robot._ERR 406"" Code=""_Err 406 - Bad Pitch"" />" & _
"    <Property Name=""Robot._ERR 407"" Code=""_ERR 407 - Bad T Position"" />" & _
"    <Property Name=""Robot._ERR 408"" Code=""_Err 408 - Bad R Value"" />" & _
"    <Property Name=""Robot._ERR 409"" Code=""_Err 409 - Bad Z Value"" />" & _
"    <Property Name=""Robot._ERR 410"" Code=""_Err 410 - Bad ARM Size"" />" & _
"    <Property Name=""Robot._ERR 411"" Code=""_Err 411 - Bad Max Radial Angle"" />" & _
"    <Property Name=""Robot._ERR 412"" Code=""_Err 412 - Bad ARM Locate"" />" & _
"    <Property Name=""Robot._ERR 413"" Code=""_Err 413 - Bad Wafer Size"" />" & _
"    <Property Name=""Robot._ERR 414"" Code=""_Err 414 - Push Value Must Be Positive"" />" & _
"    <Property Name=""Robot._ERR 415"" Code=""_Err 415 - Station R+Push Value Is Invalid"" />" & _
"    <Property Name=""Robot._ERR 416"" Code=""_Err 416 - Station Not Initialized"" />" & _
"    <Property Name=""Robot._ERR 417"" Code=""_Err 417 - Offset Too Large"" />" & _
"    <Property Name=""Robot._ERR 418"" Code=""_Err 418 - Bad Retract Position"" />" & _
"    <Property Name=""Robot._ERR 501"" Code=""_Err 501 - Internal Error"" />" & _
"    <Property Name=""Robot._ERR 502"" Code=""_Err 502 - ESC CMD Error"" />" & _
"    <Property Name=""Robot._ERR 503"" Code=""_Err 503 - Void Error"" />" & _
"    <Property Name=""Robot._ERR 504"" Code=""_Err 504 - Output Over Run Error"" />" & _
"    <Property Name=""Robot._ERR 505"" Code=""_Err 505 - Undefined Error"" />" & _
"    <Property Name=""Robot._ERR 506"" Code=""_Err 506 - Capture Already Enable"" />" & _
"    <Property Name=""Robot._ERR 507"" Code=""_Err 507 - Capture Already Disable"" />" & _
"    <Property Name=""Robot._ERR 508"" Code=""_Err 508 - Wafer Sensor Not Defined"" />" & _
"    <Property Name=""Robot._ERR 509"" Code=""_Err 509 - No Z Axis On Robot"" />" & _
"    <Property Name=""Robot._ERR 550"" Code=""_Err 550 - Station Parameter Out Of Range"" />" & _
"    <Property Name=""Robot._ERR 551"" Code=""_Err 551 - Servo Parameter Out Of Range"" />" & _
"    <Property Name=""Robot._ERR 552"" Code=""_Err 552 - Sensor Out Of Range"" />" & _
"    <Property Name=""Robot._ERR 601"" Code=""_Err 601 - Input Over Run"" />" & _
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
"    <Property Name=""Robot._ERR 700"" Code=""_Err 700 - Wafer detected"" />" & _
"    <Property Name=""Robot._ERR 701"" Code=""_Err 701 - No Wafer detected."" />" & _
"    <Property Name=""Robot._ERR 702"" Code=""_Err 702 - Speed Index Value Exceeded."" />" & _
"    <Property Name=""Robot._ERR 703"" Code=""_Err 703 - Arm Index Value Exceeded."" />" & _
"    <Property Name=""Robot._ERR 704"" Code=""_Err 704 - Misc Index Value Exceeded."" />" & _
"    <Property Name=""Robot._ERR 705"" Code=""_Err 705 - Wafer missing."" />" & _
"    <Property Name=""Robot._ERR 706"" Code=""_Err 706 - Wafer sensed."" />" & _
"    <Property Name=""Robot._ERR 707"" Code=""_Err 707 - Pick Failed."" />" & _
"    <Property Name=""Robot._ERR 708"" Code=""_Err 708 - Place Failed."" />" & _
"    <Property Name=""Robot._ERR 709"" Code=""_Err 709 - Interlock Calc Overflow."" />" & _
"    <Property Name=""Robot._ERR 710"" Code=""_Err 710 - Slot valve closed prior PICK/PLACE/GOTO/XFER."" />" & _
"    <Property Name=""Robot._ERR 711"" Code=""_Err 711 - Slot Valve Not Open"" />" & _
"    <Property Name=""Robot._ERR 712"" Code=""_Err 712 - No Vaccum Grip Arm A"" />" & _
"    <Property Name=""Robot._ERR 713"" Code=""_Err 713 - No Vaccum Grip Arm B"" />" & _
"    <Property Name=""Robot._ERR 714"" Code=""_Err 714 - Slow Vaccum Grip Arm A"" />" & _
"    <Property Name=""Robot._ERR 715"" Code=""_Err 715 - Slow Vaccum Grip Arm B"" />" & _
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
"    <!--GEM Message-->" & _
"    <MessageText>" & _
"      <Key>AVP.txtGEMWaferID</Key>" & _
"      <Value>Enter your WaferID</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>btnUploadProcess.Click</Key>" & _
"      <Value>Would you like to Upload Process Program to host?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>btnDownloadProcess.Click</Key>" & _
"      <Value>Would you like to Download Process Program from host?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>btnGoOnlineLocal.Click</Key>" & _
"      <Value>Would you like to send Online - Local command to host?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>btnGoOnlineRemote.Click</Key>" & _
"      <Value>Would you like to send Online - Remote command to host?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>btnOffline.Click</Key>" & _
"      <Value>Would you like to send Offline command to host?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>btnEnable.Click</Key>" & _
"      <Value>Would you like to send Enable command to host?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>btnDisable.Click</Key>" & _
"      <Value>Would you like to send Disable command to host?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>btnClearTerminalMessage.Click</Key>" & _
"      <Value>Would you like to Clear Terminal Messages?</Value>" & _
"    </MessageText>" & _
"    <!--Begin IBE Message-->" & _
"    <MessageText>" & _
"      <Key>LLMaxCycleCount.txtLLAMaxCycleCount</Key>" & _
"      <Value>Would you like to set Stop Cycle LLA at?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CryoPopUpPanel.txtExtendedPurgeTime</Key>" & _
"      <Value>Would you like to set Extended Purge Time?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CryoPopUpPanel.txtPumpRestartDelay</Key>" & _
"      <Value>Would you like to set Pump Restart Delay?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CryoPopUpPanel.txtRateOfRise</Key>" & _
"      <Value>Would you like to set Rate Of Rise?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CryoPopUpPanel.txtRoughToPressure</Key>" & _
"      <Value>Would you like to set Rough To Pressure?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CryoPopUpPanel.txtStartUpTemp</Key>" & _
"      <Value>Would you like to set start Up Temp?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CryoPopUpPanel.txtRepurgeCycles</Key>" & _
"      <Value>Would you like to set Repurge Cycles?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.ChillerControl.btnChillerOnOff.Off</Key>" & _
"      <Value>Would you like to Turn Chiller on?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.ChillerControl.btnChillerOnOff.On</Key>" & _
"      <Value>Would you like to Turn Chiller off?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.ButtonClick.On</Key>" & _
"      <Value>Would you like to {0} {1} ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.ButtonClick.Off</Key>" & _
"      <Value>Would you like to {0} {1} ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.btnPause.Resume</Key>" & _
"      <Value>Would you like to Resume processing Recipe?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.btnPause.Pause</Key>" & _
"      <Value>Would you like to Pause processing Recipe?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.btnPause.Stop</Key>" & _
"      <Value>Would you like to Stop processing Recipe?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.Processing</Key>" & _
"      <Value>Still Processing Recipe</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.btnStart.Stop</Key>" & _
"      <Value>Would you like to Stop processing Recipe?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.btnStart.Start</Key>" & _
"      <Value>Would you like to start processing Recipe?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.btnStart.NoWafer</Key>" & _
"      <Value>Can not start processing without wafer</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.btnStart.WaferCompleted</Key>" & _
"      <Value>Can not start processing with wafer completed</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.btnAbort</Key>" & _
"      <Value>Would you like to Abort processing Recipe?</Value>" & _
"    </MessageText>" & _
"    <!--Container Box-->" & _
"    <MessageText>" & _
"      <Key>IBE.SLContainerBox.btnWaterPumpOn.On</Key>" & _
"      <Value>Would you like to Turn On Turbo?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SLContainerBox.btnWaterPumpOn.Off</Key>" & _
"      <Value>Would you like to Turn Off Turbo?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SLContainerBox.btnCryoOn.On</Key>" & _
"      <Value>Would you like to Turn On Cryo?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SLContainerBox.btnCryoOn.Off</Key>" & _
"      <Value>Would you like to Turn Off Cryo?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SLContainerBox.Shutter.On</Key>" & _
"      <Value>Would you like to Open Shutter?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SLContainerBox.Shutter.Off</Key>" & _
"      <Value>Would you like to Close Shutter?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SLFixture.btnShutterOpen</Key>" & _
"      <Value>Would you like to Open Shutter?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SLFixture.btnShutterClose</Key>" & _
"      <Value>Would you like to Close Shutter?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SLContainerBox.Shutter.Unknown</Key>" & _
"      <Value>Would you like to Open/Close Shutter?</Value>" & _
"    </MessageText>" & _
"    <!--Status panel-->" & _
"    <MessageText>" & _
"      <Key>IBE.SLFixture.btnMotionInitialized.On</Key>" & _
"      <Value>Would you like to Turn MotionInitialized On?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SLFixture.btnMotionInitialized.Off</Key>" & _
"      <Value>Would you like to Turn MotionInitialized Off?</Value>" & _
"    </MessageText>" & _
"    <!--Power panel-->" & _
"    <MessageText>" & _
"      <Key>IBE.SLPowerPanel.btnACPower.On</Key>" & _
"      <Value>Would you like to Turn On AC Power?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SLPowerPanel.btnACPower.Off</Key>" & _
"      <Value>Would you like to Turn Off AC Power?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SLPowerPanel.btnRFPower.On</Key>" & _
"      <Value>Would you like to Turn On RF Power?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SLPowerPanel.btnRFPower.Off</Key>" & _
"      <Value>Would you like to Turn Off RF Power?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SLPowerPanel.btnGrid.On</Key>" & _
"      <Value>Would you like to Turn On Grid Power?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SLPowerPanel.btnGrid.Off</Key>" & _
"      <Value>Would you like to Turn Off Grid Power?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SLPowerPanel.btnPBN.On</Key>" & _
"      <Value>Would you like to Turn On PBN Power?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SLPowerPanel.btnPBN.Off</Key>" & _
"      <Value>Would you like to Turn Off PBN Power?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.tabSource.btnSourceManual</Key>" & _
"      <Value>Would you like to Switch To Source Manual Mode?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.tabSource.btnSourceAuto</Key>" & _
"      <Value>Would you like to Switch To Source Auto Mode?</Value>" & _
"    </MessageText>" & _
"    <!--Source tab-->" & _
"    <MessageText>" & _
"      <Key>IBE.txtBeamVoltageRight</Key>" & _
"      <Value>Would you like to change Beam Voltage value to?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.txtBeamCurrentRight</Key>" & _
"      <Value>Would you like to change Beam Current value to?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.txtSuppressorVoltageRight</Key>" & _
"      <Value>Would you like to change Suppressor Voltage value to?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.txtSuppressorCurrentRight</Key>" & _
"      <Value>Would you like to change Suppressor Current value to?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.txtRFPowerRight</Key>" & _
"      <Value>Would you like to change RF Power value to?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.txtRFReflectedRight</Key>" & _
"      <Value>Would you like to change RF Reflected value to?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.txtPBNGasRight_SourceTab</Key>" & _
"      <Value>Would you like to change {0} value to?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.txtGas1Right_SourceTab</Key>" & _
"      <Value>Would you like to change {0} value to?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.txtGas2Right_SourceTab</Key>" & _
"      <Value>Would you like to change {0} value to?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.txtKFactorRight</Key>" & _
"      <Value>Would you like to change K Factor value to?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.txtPBNBodyRight</Key>" & _
"      <Value>Would you like to change PBN Body value to?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.txtPBNDischRight</Key>" & _
"      <Value>Would you like to change PBNDisch value to?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.btnAutoBeam.On</Key>" & _
"      <Value>Would you like to Run Auto Beam?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.btnAutoBeam.Off</Key>" & _
"      <Value>Would you like to Stop Auto Beam?</Value>" & _
"    </MessageText>" & _
"    <!--Gas tab-->" & _
"    <MessageText>" & _
"      <Key>IBE.txtPBNGasRight</Key>" & _
"      <Value>Would you like to change {0} value to?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.txtGas1Right</Key>" & _
"      <Value>Would you like to change {0} value to?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.txtGas2Right</Key>" & _
"      <Value>Would you like to change {0} value to?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.txtGas3Right</Key>" & _
"      <Value>Would you like to change {0} value to?</Value>" & _
"    </MessageText>" & _
"    <!--Fixture-->" & _
"    <MessageText>" & _
"      <Key>IBE.txtFlowCoolGasRight</Key>" & _
"      <Value>Would you like to change {0} value to?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.txtTiltAngleRight</Key>" & _
"      <Value>Would you like to change Tilt Angle value to?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.txtRotationContinuousRight</Key>" & _
"      <Value>Would you like to change Rotation Speed value to?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.txtRotationEnd</Key>" & _
"      <Value>Would you like to change Rotation End Angle to?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.txtRotationSweepRight</Key>" & _
"      <Value>Would you like to change Rotation start Angle to?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.txtRotationStaticRight</Key>" & _
"      <Value>Would you like to change Rotation Static Angle to?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SLFixture.mnuShutterOpen</Key>" & _
"      <Value>Would you like to Open Shutter?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SLFixture.mnuShutterClose</Key>" & _
"      <Value>Would you like to Close Shutter?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SLFixture.btnClampUp</Key>" & _
"      <Value>Would you like to Clamp Up?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SLFixture.btnClampDown</Key>" & _
"      <Value>Would you like to Clamp Down?</Value>" & _
"    </MessageText>" & _
"    <!--Valve click-->" & _
"    <MessageText>" & _
"      <Key>IBE.ValveVent.Open</Key>" & _
"      <Value>Would you like to Open Vent Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.ValveVent.Close</Key>" & _
"      <Value>Would you like to Close Vent Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.ValveRough.Open</Key>" & _
"      <Value>Would you like to Open Rough Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.ValveRough.Close</Key>" & _
"      <Value>Would you like to Close Rough Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.ValveForeline.Open</Key>" & _
"      <Value>Would you like to Open Foreline Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.ValveForeline.Close</Key>" & _
"      <Value>Would you like to Close Foreline Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.ValveShutoffGas1.Open</Key>" & _
"      <Value>Would you like to Open Gas1 Shutoff Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.ValveShutoffGas1.Close</Key>" & _
"      <Value>Would you like to Close Gas1 Shutoff Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.ValveShutoffGas2.Open</Key>" & _
"      <Value>Would you like to Open Gas2 Shutoff Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.ValveShutoffGas2.Close</Key>" & _
"      <Value>Would you like to Close Gas2 Shutoff Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.ValveShutoffGas3.Open</Key>" & _
"      <Value>Would you like to Open Gas3 Shutoff Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.ValveShutoffGas3.Close</Key>" & _
"      <Value>Would you like to Close Gas3 Shutoff Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.ValveShutoffPBNGas.Open</Key>" & _
"      <Value>Would you like to Open PBN Shutoff Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.ValveShutoffPBNGas.Close</Key>" & _
"      <Value>Would you like to Close PBN Shutoff Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.ValveShutoffFlowCoolGas.Open</Key>" & _
"      <Value>Would you like to Open FlowCool He Shutoff Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.ValveShutoffFlowCoolGas.Close</Key>" & _
"      <Value>Would you like to Close FlowCool He Shutoff Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.ValveDiverter.Open</Key>" & _
"      <Value>Diverter Valve RIBE?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.ValveDiverter.Close</Key>" & _
"      <Value>Diverter Valve CIBE?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.ValveSupplyGas1.Open</Key>" & _
"      <Value>Would you like to Open Gas1 Supply Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.ValveSupplyGas1.Close</Key>" & _
"      <Value>Would you like to Close Gas1 Supply Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.ValveSupplyGas2.Open</Key>" & _
"      <Value>Would you like to Open Gas2 Supply Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.ValveSupplyGas2.Close</Key>" & _
"      <Value>Would you like to Close Gas2 Supply Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.ValveSupplyGas3.Open</Key>" & _
"      <Value>Would you like to Open Gas3 Supply Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.ValveSupplyGas3.Close</Key>" & _
"      <Value>Would you like to Close Gas3 Supply Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.ValveSupplyPBNGas.Open</Key>" & _
"      <Value>Would you like to Open PBN Supply Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.ValveSupplyPBNGas.Close</Key>" & _
"      <Value>Would you like to Close PBN Supply Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.ValveSupplyFlowCoolGas.Open</Key>" & _
"      <Value>Would you like to Open FlowCool He Supply Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.ValveSupplyFlowCoolGas.Close</Key>" & _
"      <Value>Would you like to Close FlowCool He Supply Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.btnOpenClosePBNGas</Key>" & _
"      <Value>Would you like to Open/Close Supply and Shutoff PBN Gas Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.btnOpenCloseGas1</Key>" & _
"      <Value>Would you like to Open/Close Supply and Shutoff Gas1 Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.btnOpenCloseGas2</Key>" & _
"      <Value>Would you like to Open/Close Supply and Shutoff Gas2 Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.btnOpenCloseGas3</Key>" & _
"      <Value>Would you like to Open/Close Supply and Shutoff Gas3 Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.btnOpenCloseFlowCoolGas</Key>" & _
"      <Value>Would you like to Open/Close Supply and Shutoff FlowCool Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.RoughPump.Open</Key>" & _
"      <Value>Would you like to Turn On Rough Pump Power?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.RoughPump.Close</Key>" & _
"      <Value>Would you like to Turn Off Rough Pump Power?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.ValveFixtureWater.Open</Key>" & _
"      <Value>Would you like to Open Fixture Water Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.ValveFixtureWater.Close</Key>" & _
"      <Value>Would you like to Close Fixture Water Valve?</Value>" & _
"    </MessageText>" & _
"    <!--menu click-->" & _
"    <MessageText>" & _
"      <Key>IBE.SL_PopUpPanel.btnIGDegas.On</Key>" & _
"      <Value>Would you like to Run IG Degas?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SL_PopUpPanel.btnIGDegas.Off</Key>" & _
"      <Value>Would you like to Abort IG Degas?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SL_PopUpPanel.btnPumpPurge.On</Key>" & _
"      <Value>Would you like to Run Pump Purge?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SL_PopUpPanel.btnPumpPurge.Off</Key>" & _
"      <Value>Would you like to Abort Pump Purge?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SL_PopUpPanel.btnCryoPurge.On</Key>" & _
"      <Value>Would you like to Open Cryo Purge?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SL_PopUpPanel.btnCryoPurge.Off</Key>" & _
"      <Value>Would you like to Close Cryo Purge?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SL_PopUpPanel.btnCryoPurgeOff.On</Key>" & _
"      <Value>Would you like to Open Cryo Purge?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SL_PopUpPanel.btnCryoPurgeOff.Off</Key>" & _
"      <Value>Would you like to Close Cryo Purge?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SL_PopUpPanel.btnRoughValveOpen.On</Key>" & _
"      <Value>Would you like to Open Rough Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SL_PopUpPanel.btnRoughValveOpen.Off</Key>" & _
"      <Value>Would you like to Close Rough Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SL_PopUpPanel.btnRoughValveClose.On</Key>" & _
"      <Value>Would you like to Open Rough Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SL_PopUpPanel.btnRoughValveClose.Off</Key>" & _
"      <Value>Would you like to Close Rough Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SLContainerBox.ValveCryoHivac.On</Key>" & _
"      <Value>Would you like to Open Cryo Gate?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SLContainerBox.ValveCryoHivac.Off</Key>" & _
"      <Value>Would you like to Close Cryo Gate?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SLContainerBox.ValveCryoHivac.Unknown</Key>" & _
"      <Value>Would you like to Open/Close Cryo Gate?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SL_PopUpPanel.btnAutoRegen.On</Key>" & _
"      <Value>Would you like to Start Auto Cryo Regen?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SL_PopUpPanel.btnAutoRegen.Off</Key>" & _
"      <Value>Would you like to Abort Auto Cryo Regen?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SL_PopUpPanel.btnAutoRegenOff.On</Key>" & _
"      <Value>Would you like to Start Auto Cryo Regen?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SL_PopUpPanel.btnAutoRegenOff.Off</Key>" & _
"      <Value>Would you like to Abort Auto Cryo Regen?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SL_PopUpPanel.btnAutoPowerDown.On</Key>" & _
"      <Value>Would you like to Auto Cryo Power Down On?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SL_PopUpPanel.btnAutoPowerDown.Off</Key>" & _
"      <Value>Would you like to Auto Cryo Power Down Off?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SLContainerBox.ValveTurboHivac.On</Key>" & _
"      <Value>Would you like to Open Turbo Gate?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SLContainerBox.ValveTurboHivac.Off</Key>" & _
"      <Value>Would you like to Close Turbo Gate?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SLContainerBox.ValveTurboHivac.Unknown</Key>" & _
"      <Value>Would you like to Open/Close Turbo Gate?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SLFixture.btnFlowCoolPump.On</Key>" & _
"      <Value>Would you like to Turn Flowcool Pump Power On?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SLFixture.btnFlowCoolPump.Off</Key>" & _
"      <Value>Would you like to Turn Flowcool Pump Power Off?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TurnCoolingWaterOn</Key>" & _
"      <Value>Would you like to Turn Cooling Water On?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TurnCoolingWaterOff</Key>" & _
"      <Value>Would you like to Turn Cooling Water Off?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TurnUnprotectedOn</Key>" & _
"      <Value>Would you like to Turn Unprotected On?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TurnFlowCoolUnprotectedOff</Key>" & _
"      <Value>Would you like to Turn Unprotected Off?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SL_PopUpPanel.btnAutoVentGeneral.On</Key>" & _
"      <Value>Would you like to Start Vent?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SL_PopUpPanel.btnAutoVentGeneral.Off</Key>" & _
"      <Value>Would you like to Abort Vent?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SL_PopUpPanel.btnAutoPumpDownGeneral.On</Key>" & _
"      <Value>Would you like to Start Pump down?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SL_PopUpPanel.btnAutoPumpDownGeneral.Off</Key>" & _
"      <Value>Would you like to Abort Pump down?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SL_PopUpPanel.btnRateOfRise.On</Key>" & _
"      <Value>Would you like to Run Rate Of Rise?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SL_PopUpPanel.btnRateOfRise.Off</Key>" & _
"      <Value>Would you like to Abort Rate Of Rise?</Value>" & _
"    </MessageText>" & _
"    <!--SL Process screen -->" & _
"    <!--Process control-->" & _
"    <MessageText>" & _
"      <Key>IBE.SLProcessControl.btnSelect</Key>" & _
"      <Value>Would you like to Select recipe?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SLProcessControl.btnRun</Key>" & _
"      <Value>Would you like to Run recipe?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SLProcessControl.btnStop</Key>" & _
"      <Value>Would you like to Stop recipe?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SLProcessControl.btnAbort</Key>" & _
"      <Value>Would you like to Abort recipe?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SLProcessControl.btnContinue</Key>" & _
"      <Value>Would you like to Continue recipe?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SLProcessControl.btnEndCurrentStep</Key>" & _
"      <Value>Would you like to End Current Step?</Value>" & _
"    </MessageText>" & _
"    <!--System control -->" & _
"    <MessageText>" & _
"      <Key>IBE.SLSystemControl.btnOnline</Key>" & _
"      <Value>Would you like to Online?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SLSystemControl.btnOffline</Key>" & _
"      <Value>Would you like to Offline?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SLSystemPanel.btnOnline</Key>" & _
"      <Value>Would you like to Online?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SLSystemPanel.btnOffline</Key>" & _
"      <Value>Would you like to Offline?</Value>" & _
"    </MessageText>" & _
"    <!--Robot control-->" & _
"    <MessageText>" & _
"      <Key>IBE.SLRobotControl.btnArmUp</Key>" & _
"      <Value>Would you like to Arm Up?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SLRobotControl.btnArmDown</Key>" & _
"      <Value>Would you like to Arm Down?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SLRobotControl.btnExtendArm</Key>" & _
"      <Value>Would you like to Extend Arm?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SLRobotControl.btnRetractArm</Key>" & _
"      <Value>Would you like to Retract Arm?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SLProcessControl.btnCycle.On</Key>" & _
"      <Value>Would you like to Turn On Cycle Mode?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SLProcessControl.btnCycle.Off</Key>" & _
"      <Value>Would you like to Turn Off Cycle Mode?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.btnUnProtected.On</Key>" & _
"      <Value>Would you like to Turn On UnProtected?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.btnUnProtected.Off</Key>" & _
"      <Value>Would you like to Turn Off UnProtected?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE_AVP.btnUnProtected.On</Key>" & _
"      <Value>Would you like to set Override Mode to On?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE_AVP.btnUnProtected.Off</Key>" & _
"      <Value>Would you like to set Override Mode to Off?</Value>" & _
"    </MessageText>" & _
"    <!--Vacuum control-->" & _
"    <MessageText>" & _
"      <Key>IBE.SLVacuumControl.btnOpenRoughValve</Key>" & _
"      <Value>Would you like to Open Rough Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SLVacuumControl.btnCloseRoughValve</Key>" & _
"      <Value>Would you like to Close Rough Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SLVacuumControl.btnOpenVentValve</Key>" & _
"      <Value>Would you like to Open Vent Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SLVacuumControl.btnCloseVentValve</Key>" & _
"      <Value>Would you like to Close Vent Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SLVacuumControl.btnOpenIsolationValve</Key>" & _
"      <Value>Would you like to Open Slit valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SLVacuumControl.btnCloseIsolationValve</Key>" & _
"      <Value>Would you like to Close Slit valve?</Value>" & _
"    </MessageText>" & _
"    <!--Valve-->" & _
"    <MessageText>" & _
"      <Key>IBE.VentValve.Open</Key>" & _
"      <Value>Would you like to Open Vent Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.VentValve.Close</Key>" & _
"      <Value>Would you like to Close Vent Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.RoughValve.Open</Key>" & _
"      <Value>Would you like to Open Rough Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.RoughValve.Close</Key>" & _
"      <Value>Would you like to Close Rough Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.FlowCoolValve.Open</Key>" & _
"      <Value>Would you like to Open FlowCool Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.FlowCoolValve.Close</Key>" & _
"      <Value>Would you like to Close FlowCool Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.MesaValve.Open</Key>" & _
"      <Value>Would you like to Open Mesa Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.MesaValve.Close</Key>" & _
"      <Value>Would you like to Close Mesa Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.RoughPumpControl.Open</Key>" & _
"      <Value>Would you like to Turn On Mechanical Pump?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.RoughPumpControl.Close</Key>" & _
"      <Value>Would you like to Turn Off Mechanical Pump?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.ButtonClick</Key>" & _
"      <Value>Would you like to {0} {1} ?</Value>" & _
"    </MessageText>" & _
"    <!--End of Single Loader Message-->" & _
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
"    <MessageText>" & _
"      <Key>SystemSetup.ModuleName</Key>" & _
"      <Value>Enter your Module Name value</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.MaxUsage</Key>" & _
"      <Value>Enter your Max Usage value</Value>" & _
"    </MessageText>" & _
"    <!--DC Target Power Supply-->" & _
"    <MessageText>" & _
"      <Key>PVD.txtRampTimeRight</Key>" & _
"      <Value>Would you like to change Ramp Time to?</Value>" & _
"    </MessageText>" & _
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
"      <Key>PVD.txtVoltageRight</Key>" & _
"      <Value>Would you like to change Voltage to?</Value>" & _
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
"      <Value>Would you like to Recall location?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnRecall.Close</Key>" & _
"      <Value>Would you like to Recall location?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnStore.Open</Key>" & _
"      <Value>Would you like to Store location?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnStore.Close</Key>" & _
"      <Value>Would you like to Store location?</Value>" & _
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
"      <Value>Would you like to change?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.txtGas2Right</Key>" & _
"      <Value>Would you like to change?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.txtGas3Right</Key>" & _
"      <Value>Would you like to change?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.txtGas4Right</Key>" & _
"      <Value>Would you like to change?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.txtGas5Right</Key>" & _
"      <Value>Would you like to change?</Value>" & _
"    </MessageText>" & _
"    <!--Magnatron-->" & _
"    <MessageText>" & _
"      <Key>PVD.btnRotationStart.Open</Key>" & _
"      <Value>Would you like to Stop Rotation?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnRotationStart.Close</Key>" & _
"      <Value>Would you like to Start Rotation?</Value>" & _
"    </MessageText>" & _
"    <!--Process Monitor-->" & _
"    <!--Run Recipe-->" & _
"    <MessageText>" & _
"      <Key>PVD.btnStart.Start.NoWafer</Key>" & _
"      <Value>No wafer to run recipe</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnStart.Start.WaferCompleted</Key>" & _
"      <Value>Can not start processing with wafer completed</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnStart.Start</Key>" & _
"      <Value>Would you like to Start Recipe?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnStart.Stop</Key>" & _
"      <Value>Would you like to Stop Recipe?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnPause.Pause</Key>" & _
"      <Value>Would you like to Pause Recipe?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnPause.Resume</Key>" & _
"      <Value>Would you like to Resume Recipe?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.Processing</Key>" & _
"      <Value>Waiting for PVD processing, please wait...</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnAbort</Key>" & _
"      <Value>Would you like to End Current Step?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PM.Processing</Key>" & _
"      <Value>Waiting for PM processing, please wait...</Value>" & _
"    </MessageText>" & _
"    <!--Baratron-->" & _
"    <MessageText>" & _
"      <Key>PVD.bigcgIG.Open</Key>" & _
"      <Value>Would you like to Turn Off IG?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.bigcgIG.Close</Key>" & _
"      <Value>Would you like to Turn On IG?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.txtCG2</Key>" & _
"      <Value>Would you like to change IG value?</Value>" & _
"    </MessageText>" & _
"    <!--Vat Valve Controller-->" & _
"    <MessageText>" & _
"      <Key>PVD.txtTeach</Key>" & _
"      <Value>Would you like to change Teach value to?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.txtPressure</Key>" & _
"      <Value>Would you like to change Pressure value to?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.txtPressure_Percent</Key>" & _
"      <Value>Would you like to change Pressure value to?</Value>" & _
"    </MessageText>" & _
"    <!--Cryo, Water Pump, Turbo Pump-->" & _
"    <MessageText>" & _
"      <Key>PVD.txtT1</Key>" & _
"      <Value>Would you like to change T1 value to?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.txtT2</Key>" & _
"      <Value>Would you like to change T2 value to?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnRegen.Open</Key>" & _
"      <Value>Would you like to Abort Regen?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnRegen.Close</Key>" & _
"      <Value>Would you like to Start Regen?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.bicWaterPump.Open</Key>" & _
"      <Value>Would you like to Close WaterPump?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.bicWaterPump.Close</Key>" & _
"      <Value>Would you like to Open WaterPump?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.bicTurboPump.Open</Key>" & _
"      <Value>Would you like to Close Turbo Pump?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.bicTurboPump.Close</Key>" & _
"      <Value>Would you like to Open Turbo Pump?</Value>" & _
"    </MessageText>" & _
"    <!--Chuck-->" & _
"    <MessageText>" & _
"      <Key>PVD.txtPos2</Key>" & _
"      <Value>Would you like to change Position value to?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnShutter.Open</Key>" & _
"      <Value>Would you like to Close Shutter?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnShutter.Close</Key>" & _
"      <Value>Would you like to Open Shutter?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.bicPlasmaIgniter.Open</Key>" & _
"      <Value>Would you like to Turn On Plasma Igniter?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.bicPlasmaIgniter.Close</Key>" & _
"      <Value>Would you like to Turn Off Plasma Igniter?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnHivacValve.Unknown</Key>" & _
"      <Value>Would you like to Open/Close Hivac Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnShutter.Unknown</Key>" & _
"      <Value>Would you like to Open/Close Shutter?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnHivacValve.Close</Key>" & _
"      <Value>Would you like to Open Hivac Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnHivacValve.Open</Key>" & _
"      <Value>Would you like to Close Hivac Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnAutoZero.Open</Key>" & _
"      <Value>Would you like to Turn Off Auto Zero Vat Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnAutoZero.Close</Key>" & _
"      <Value>Would you like to Turn On Auto Zero Vat Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnClamp.Close</Key>" & _
"      <Value>Would you like to Clamp?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnClamp.Open</Key>" & _
"      <Value>Would you like to UnClamp?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnSizeAdjust.Open</Key>" & _
"      <Value>Would you like to Close Size Adjust?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnSizeAdjust.Close</Key>" & _
"      <Value>Would you like to Open Size Adjust?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnTeach.Open</Key>" & _
"      <Value>Would you like to Send Teach?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnTeach.Close</Key>" & _
"      <Value>Would you like to Send Teach?</Value>" & _
"    </MessageText>" & _
"    <!--Gas Valve-->" & _
"    <MessageText>" & _
"      <Key>PVD.ValveWater.Close</Key>" & _
"      <Value>Would you like to Open Water Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveWater.Open</Key>" & _
"      <Value>Would you like to Close Water Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveVent.Close</Key>" & _
"      <Value>Would you like to Open Valve Vent?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveVent.Open</Key>" & _
"      <Value>Would you like to Close Valve Vent?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveBaratron.Close</Key>" & _
"      <Value>Would you like to Open Valve Baratron?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveBaratron.Open</Key>" & _
"      <Value>Would you like to Close Valve Baratron?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveMainGas.Close</Key>" & _
"      <Value>Would you like to Open Main Gas Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveMainGas.Open</Key>" & _
"      <Value>Would you like to Close Main Gas Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveTurbo_Isolation.Close</Key>" & _
"      <Value>Would you like to Open Turbo Slit valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveTurbo_Isolation.Open</Key>" & _
"      <Value>Would you like to Close Turbo Slit valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveRough.Close</Key>" & _
"      <Value>Would you like to Open Rough Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveRough.Open</Key>" & _
"      <Value>Would you like to Close Rough Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveSupply1.Open</Key>" & _
"      <Value>Would you like to Close ValveSupply1?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveSupply1.Close</Key>" & _
"      <Value>Would you like to Open ValveSupply1?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveSupply2.Open</Key>" & _
"      <Value>Would you like to Close ValveSupply2?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveSupply2.Close</Key>" & _
"      <Value>Would you like to Open ValveSupply2?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveSupply3.Open</Key>" & _
"      <Value>Would you like to Close ValveSupply3?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveSupply3.Close</Key>" & _
"      <Value>Would you like to Open ValveSupply3?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveSupply4.Open</Key>" & _
"      <Value>Would you like to Close ValveSupply4?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveSupply4.Close</Key>" & _
"      <Value>Would you like to Open ValveSupply4?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveSupply5.Open</Key>" & _
"      <Value>Would you like to Close ValveSupply5?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveSupply5.Close</Key>" & _
"      <Value>Would you like to Open ValveSupply5?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveShutOff1.Open</Key>" & _
"      <Value>Would you like to Close ValveShutOff1?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveShutOff1.Close</Key>" & _
"      <Value>Would you like to Open ValveShutOff1?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveShutOff2.Open</Key>" & _
"      <Value>Would you like to Close ValveShutOff2?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveShutOff2.Close</Key>" & _
"      <Value>Would you like to Open ValveShutOff2?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveShutOff3.Open</Key>" & _
"      <Value>Would you like to Close ValveShutOff3?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveShutOff3.Close</Key>" & _
"      <Value>Would you like to Open ValveShutOff3?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveShutOff4.Open</Key>" & _
"      <Value>Would you like to Close ValveShutOff4?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveShutOff4.Close</Key>" & _
"      <Value>Would you like to Open ValveShutOff4?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveShutOff5.Open</Key>" & _
"      <Value>Would you like to Close ValveShutOff5?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.ValveShutOff5.Close</Key>" & _
"      <Value>Would you like to Open ValveShutOff5?</Value>" & _
"    </MessageText>" & _
"    <!--Auto Transfer Wafer-->" & _
"    <MessageText>" & _
"      <Key>TurnCycleWaferModeOnLoadLock</Key>" & _
"      <Value>You are turning Cycle Wafer Mode {0}!</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ExclamCycleWaferWrong</Key>" & _
"      <Value>Can't turn Cycle Wafer {0} with Cycle number = 0!</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ExclamCycleWaferNotMultipleNumberOfLot</Key>" & _
"      <Value>Cycle need to be in the multiple of {0}!</Value>" & _
"    </MessageText>" & _
"    <!--Others-->" & _
"    <MessageText>" & _
"      <Key>PVD.btnOverrideMode.Open</Key>" & _
"      <Value>Would you like to set Override Mode to On?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnOverrideMode.Close</Key>" & _
"      <Value>Would you like to set Override Mode to Off?</Value>" & _
"    </MessageText>" & _
"    <!--End PVD Message-->" & _
"    <!--Begin CORONA Message-->" & _
"    <!--Add for Corona-->" & _
"    <!--Vat Valve Controller-->" & _
"    <MessageText>" & _
"      <Key>PVD4.ValveClick.Off</Key>" & _
"      <Value>Would you like to Open {0} Valve ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.ValveClick.On</Key>" & _
"      <Value>Would you like to Close {0} Valve ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.ValveClick.Unknow</Key>" & _
"      <Value>Would you like to Open/Close {0} Valve ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.MechanicalPump.On</Key>" & _
"      <Value>Would you like to Turn Off {0} ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.MechanicalPump.Off</Key>" & _
"      <Value>Would you like to Turn On {0} ?</Value>" & _
"    </MessageText>" & _
"    <!-- Button click -->" & _
"    <MessageText>" & _
"      <Key>PVD4.ButtonClick</Key>" & _
"      <Value>Would you like to {0} {1} ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.Panel1.btnTarget1Switch</Key>" & _
"      <Value>Would you like to switch Power Contact to Target 1?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.Panel2.btnTarget2Switch</Key>" & _
"      <Value>Would you like to switch Power Contact to Target 2?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.Panel3.btnTarget3Switch</Key>" & _
"      <Value>Would you like to switch Power Contact to Target 3?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.Panel4.btnTarget4Switch</Key>" & _
"      <Value>Would you like to switch Power Contact to Target 4?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.Panel5.btnTarget5Switch</Key>" & _
"      <Value>Would you like to switch Power Contact to Target 5?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.VatValveController.btnTeach</Key>" & _
"      <Value>Would you like to send Teach?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.VatValveController.btnAutoZero.On</Key>" & _
"      <Value>Would you like to Turn Off Auto Zero Vat Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.VatValveController.btnAutoZero.Off</Key>" & _
"      <Value>Would you like to send Auto Zero Vat Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.VatValveController.btnSizeAdjust.On</Key>" & _
"      <Value>Would you like to Turn Off Size Adjust?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.VatValveController.btnSizeAdjust.Off</Key>" & _
"      <Value>Would you like to send Size Adjust?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.TextboxClick</Key>" & _
"      <Value>Would you like to change {0} value to?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.TableControl.cbxGoTo</Key>" & _
"      <Value>Would you like to Go To {0}?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.btnRecall</Key>" & _
"      <Value>Would you like to Recall location?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.btnStore</Key>" & _
"      <Value>Would you like to Store location?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.btnAuto.Off</Key>" & _
"      <Value>Would you like to change to Auto?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.btnAuto.On</Key>" & _
"      <Value>Would you like to change to Manual?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.btnAuto.Unknow</Key>" & _
"      <Value>Would you like to change to Auto/Manual?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.btnContact.Off</Key>" & _
"      <Value>Would you like to change to Ground?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.btnContact.On</Key>" & _
"      <Value>Would you like to change to Float?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.SystemPanel.btnOnline</Key>" & _
"      <Value>Would you like to Online?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.SystemPanel.btnOffline</Key>" & _
"      <Value>Would you like to Offline?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.PopUpPanel.btnAutoPumpDown.On</Key>" & _
"      <Value>Would you like to Abort Pump down?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.PopUpPanel.btnAutoPumpDown.Off</Key>" & _
"      <Value>Would you like to Start Pump down?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.PopUpPanel.btnAutoVent.On</Key>" & _
"      <Value>Would you like to Abort Vent?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.PopUpPanel.btnAutoVent.Off</Key>" & _
"      <Value>Would you like to Start Vent?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.PopUpPanel.btnPumpPurge.Off</Key>" & _
"      <Value>Would you like to Start Pump Purge?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.PopUpPanel.btnPumpPurge.On</Key>" & _
"      <Value>Would you like to Abort Pump Purge?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.PopUpPanel.btnIGDegas.Off</Key>" & _
"      <Value>Would you like to start IG Degas?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.PopUpPanel.btnIGDegas.On</Key>" & _
"      <Value>Would you like to Abort IG Degas?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.PopUpPanel.btnShutDownPower.Off</Key>" & _
"      <Value>Would you like to Shut Down Power?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.TableControl.btnUP.Off</Key>" & _
"      <Value>Would you like to Up?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.TableControl.btnDOWN.Off</Key>" & _
"      <Value>Would you like to Down?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.TableControl.btnUP.On</Key>" & _
"      <Value>Would you like to abort Up?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.TableControl.btnDOWN.On</Key>" & _
"      <Value>Would you like to abort Down?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.TableControl.btnHOME.Off</Key>" & _
"      <Value>Would you like to start Home All?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.TableControl.btnHOME.On</Key>" & _
"      <Value>Would you like to start Home All?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.TableControl.btnHOME.Unknow</Key>" & _
"      <Value>Would you like to stop Home All?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.crcTMTurbo.btnTurbo.Off</Key>" & _
"      <Value>Would you like turn on TM Turbo?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.crcTMTurbo.btnTurbo.On</Key>" & _
"      <Value>Would you like turn off TM Turbo?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.crcTMTurbo.btnForeline.Off</Key>" & _
"      <Value>Would you like Open TM Foreline Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.crcTMTurbo.btnForeline.On</Key>" & _
"      <Value>Would you like Close TM Foreline Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.crcLLTurbo.btnTurbo.Off</Key>" & _
"      <Value>Would you like turn on LoadLock Turbo?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.crcLLTurbo.btnTurbo.On</Key>" & _
"      <Value>Would you like turn off LoadLock Turbo?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.crcLLTurbo.btnForeline.Off</Key>" & _
"      <Value>Would you like Open LoadLock Foreline Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.crcLLTurbo.btnForeline.On</Key>" & _
"      <Value>Would you like Close LoadLock Foreline Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.btnOverrideMode.On</Key>" & _
"      <Value>Would you like to set Override Mode to On?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.btnOverrideMode.Off</Key>" & _
"      <Value>Would you like to set Override Mode to Off?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.CoronaChamber.Shutter1.On</Key>" & _
"      <Value>Would you like to Open Shutter1?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.CoronaChamber.Shutter1.Off</Key>" & _
"      <Value>Would you like to Close Shutter1?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.CoronaChamber.Shutter1.Unknown</Key>" & _
"      <Value>Would you like to Open/Close Shutter1?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.CoronaChamber.Shutter2.On</Key>" & _
"      <Value>Would you like to Open Shutter2?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.CoronaChamber.Shutter2.Off</Key>" & _
"      <Value>Would you like to Close Shutter2?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.CoronaChamber.Shutter2.Unknown</Key>" & _
"      <Value>Would you like to Open/Close Shutter2?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.CoronaChamber.Shutter3.On</Key>" & _
"      <Value>Would you like to Open Shutter3?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.CoronaChamber.Shutter3.Off</Key>" & _
"      <Value>Would you like to Close Shutter3?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.CoronaChamber.Shutter3.Unknown</Key>" & _
"      <Value>Would you like to Open/Close Shutter3?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.CoronaChamber.Shutter4.On</Key>" & _
"      <Value>Would you like to Open Shutter4?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.CoronaChamber.Shutter4.Off</Key>" & _
"      <Value>Would you like to Close Shutter4?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.CoronaChamber.Shutter4.Unknown</Key>" & _
"      <Value>Would you like to Open/Close Shutter4?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.CoronaChamber.Shutter5.On</Key>" & _
"      <Value>Would you like to Open Shutter5?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.CoronaChamber.Shutter5.Off</Key>" & _
"      <Value>Would you like to Close Shutter5?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.CoronaChamber.Shutter5.Unknown</Key>" & _
"      <Value>Would you like to Open/Close Shutter5?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.CoronaTargetSwitch.btnTarget1Switch.Off</Key>" & _
"      <Value>Would you like to switch Target1?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.CoronaTargetSwitch.btnTarget1Switch.On</Key>" & _
"      <Value>Would you like to Close Target1?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.CoronaTargetSwitch.btnTarget2Switch.Off</Key>" & _
"      <Value>Would you like to switch Target2?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.CoronaTargetSwitch.btnTarget2Switch.On</Key>" & _
"      <Value>Would you like to Close Target2?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.CoronaTargetSwitch.btnTarget3Switch.Off</Key>" & _
"      <Value>Would you like to switch Target3?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.CoronaTargetSwitch.btnTarget3Switch.On</Key>" & _
"      <Value>Would you like to Close Target3?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.CoronaTargetSwitch.btnTarget4Switch.Off</Key>" & _
"      <Value>Would you like to switch Target4?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.CoronaTargetSwitch.btnTarget4Switch.On</Key>" & _
"      <Value>Would you like to Close Target4?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.TableControl.btnRotate.Off</Key>" & _
"      <Value>Would you like to Start Rotate?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.TableControl.btnRotate.On</Key>" & _
"      <Value>Would you like to Stop Rotate?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.CoronaChamber.btnWaterPumpOn.On</Key>" & _
"      <Value>Would you like to Turn Off Turbo?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.CoronaChamber.btnWaterPumpOn.Off</Key>" & _
"      <Value>Would you like to Turn On Turbo?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.Chamber3.HivacValve.Off</Key>" & _
"      <Value>Would you like to Close Hivac Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.Chamber3.HivacValve.On</Key>" & _
"      <Value>Would you like to Open Hivac Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.Chamber3.HivacValve.Unknown</Key>" & _
"      <Value>Would you like to Open/Close Hivac Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.Chamber2.HivacValve.Off</Key>" & _
"      <Value>Would you like to Close Hivac Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.Chamber2.HivacValve.On</Key>" & _
"      <Value>Would you like to Open Hivac Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.Chamber2.HivacValve.Unknown</Key>" & _
"      <Value>Would you like to Open/Close Hivac Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.Chamber1.HivacValve.Off</Key>" & _
"      <Value>Would you like to Close Hivac Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.Chamber1.HivacValve.On</Key>" & _
"      <Value>Would you like to Open Hivac Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.Chamber1.HivacValve.Unknown</Key>" & _
"      <Value>Would you like to Open/Close Hivac Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.CoronaChamber.btnMesaValve.On</Key>" & _
"      <Value>Would you like to Open Isolation Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.CoronaChamber.btnMesaValve.Off</Key>" & _
"      <Value>Would you like to Close Isolation Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.CoronaChamber.btnMesaValve.Unknown</Key>" & _
"      <Value>Would you like to Open/Close Isolation Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.btnWaterPumpOff</Key>" & _
"      <Value>Would you like to turn WaterPump off?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.btnWaterPumpOn</Key>" & _
"      <Value>Would you like to turn WaterPump on?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.btnWPRegenOff</Key>" & _
"      <Value>Would you like to Abort WaterPump Regen?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.btnWPRegenOn</Key>" & _
"      <Value>Would you like to Start WaterPump Regen?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.TableControl.btnHomeTable</Key>" & _
"      <Value>Would you like to do Table Home ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.TableControl.btnUP</Key>" & _
"      <Value>Would you like to do Table Up ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.TableControl.btnDOWN</Key>" & _
"      <Value>Would you like to do Table Down ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.TableControl.btnLiftUp</Key>" & _
"      <Value>Would you like to do Lift Up ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.TableControl.btnLiftDown</Key>" & _
"      <Value>Would you like to do Lift Down ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.btnStart.Start</Key>" & _
"      <Value>Would you like to start processing Recipe?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.btnStart.Stop</Key>" & _
"      <Value>Would you like to Stop Recipe?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.btnPause.Pause</Key>" & _
"      <Value>Would you like to Pause Recipe?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.btnPause.Resume</Key>" & _
"      <Value>Would you like to Resume Recipe?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.Processing</Key>" & _
"      <Value>Waiting for CORONA processing, please wait...</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.btnAbort</Key>" & _
"      <Value>Would you like to End Current Step?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.pnPower.btnPulse.On</Key>" & _
"      <Value>Would you like to change to DC normal mode?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.pnPower.btnPulse.Off</Key>" & _
"      <Value>Would you like to change to DC pulse mode?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.FilMetricControl.btnGotoBaseLine</Key>" & _
"      <Value>Would you like to go to Base line?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.txtMeasure</Key>" & _
"      <Value>Would you like to change Measure value to?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.FilMetricControl.btnGotoThickness</Key>" & _
"      <Value>Would you like to go to Thickness?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.FilMetricControl.btnMeasure</Key>" & _
"      <Value>Would you like to Measure?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.btnCryoOn</Key>" & _
"      <Value>Would you like to Turn On Cryo?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.btnCryoOff</Key>" & _
"      <Value>Would you like to Turn Off Cryo?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.btnAutoRegenOff</Key>" & _
"      <Value>Would you like to Abort Cryo Auto Regen?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.btnAutoRegenOn</Key>" & _
"      <Value>Would you like to Start Cryo Auto Regen?</Value>" & _
"    </MessageText>" & _
"    <!--End Add-->" & _
"    <!--End CORONA Message-->" & _
"    <!--Vat Valve Controller-->" & _
"    <MessageText>" & _
"      <Key>PVD5T.btnStart.Start</Key>" & _
"      <Value>Would you like to start processing Recipe?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD5T.btnStart.Stop</Key>" & _
"      <Value>Would you like to Stop Recipe?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD5T.btnPause.Pause</Key>" & _
"      <Value>Would you like to Pause Recipe?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD5T.btnPause.Resume</Key>" & _
"      <Value>Would you like to Resume Recipe?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD5T.Processing</Key>" & _
"      <Value>Waiting for CORONA processing, please wait...</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD5T.btnAbort</Key>" & _
"      <Value>Would you like to End Current Step?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD5T.ValveClick.Off</Key>" & _
"      <Value>Would you like to Open {0} Valve ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD5T.ValveClick.On</Key>" & _
"      <Value>Would you like to Close {0} Valve ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD5T.ValveClick.Unknow</Key>" & _
"      <Value>Would you like to Open/Close {0} Valve ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD5T.MechanicalPump.On</Key>" & _
"      <Value>Would you like to Turn Off {0} ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD5T.MechanicalPump.Off</Key>" & _
"      <Value>Would you like to Turn On {0} ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD5T.TableControl.cbxShutterSP</Key>" & _
"      <Value>Would you like to Open Shutter {0}?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD5T.btnRotate.Off</Key>" & _
"      <Value>Would you like to Start Rotate?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD5T.btnRotate.On</Key>" & _
"      <Value>Would you like to Stop Rotate?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD5T.btnShutterHome</Key>" & _
"      <Value>Would you like to Home Shutter?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD5T.btnHomeTable</Key>" & _
"      <Value>Would you like to do Table Home ?</Value>" & _
"    </MessageText>" & _
"    <!--Hivac Valve-->" & _
"    <MessageText>" & _
"      <Key>PVD5T.Chamber3.HivacValve.Off</Key>" & _
"      <Value>Would you like to Close Hivac Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD5T.Chamber3.HivacValve.On</Key>" & _
"      <Value>Would you like to Open Hivac Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD5T.Chamber3.HivacValve.Unknown</Key>" & _
"      <Value>Would you like to Open/Close Hivac Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD5T.Chamber2.HivacValve.Off</Key>" & _
"      <Value>Would you like to Close Hivac Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD5T.Chamber2.HivacValve.On</Key>" & _
"      <Value>Would you like to Open Hivac Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD5T.Chamber2.HivacValve.Unknown</Key>" & _
"      <Value>Would you like to Open/Close Hivac Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD5T.Chamber1.HivacValve.Off</Key>" & _
"      <Value>Would you like to Close Hivac Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD5T.Chamber1.HivacValve.On</Key>" & _
"      <Value>Would you like to Open Hivac Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD5T.Chamber1.HivacValve.Unknown</Key>" & _
"      <Value>Would you like to Open/Close Hivac Valve?</Value>" & _
"    </MessageText>" & _
"    <!-- Button click -->" & _
"    <!--Begin IBE Message-->" & _
"    <MessageText>" & _
"      <Key>RFPowerOn</Key>" & _
"      <Value>Would you like to change RF Power to On?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>RFPowerOff</Key>" & _
"      <Value>Would you like to change RF Power to Off?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>GridPowerOn</Key>" & _
"      <Value>Would you like to change Grid Power to On?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>GridPowerOff</Key>" & _
"      <Value>Would you like to change Grid Power to Off?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PBNPowerOn</Key>" & _
"      <Value>Would you like to change PBN Power to On?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PBNPowerOff</Key>" & _
"      <Value>Would you like to change PBN Power to Off?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ACPowerOn</Key>" & _
"      <Value>Would you like to change AC Power to On?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ACPowerOff</Key>" & _
"      <Value>Would you like to change AC Power to Off?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>BeamPowerSupplyAutoBeamEnable</Key>" & _
"      <Value>Would you like to change Auto Beam to enable?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>BeamPowerSupplyAutoBeamDisable</Key>" & _
"      <Value>Would you like to change Auto Beam to disable?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IgcgTMMessage</Key>" & _
"      <Value>Change TM_TCM_RO_WTM_lon_S to </Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IgcgChamberMessage</Key>" & _
"      <Value>Change {0} IG to </Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IgcgLLAMessage</Key>" & _
"      <Value>Change TM_TCM_RO_Cas1lon to </Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>MesaValvePMOpen</Key>" & _
"      <Value>Would you like to open SlitValve for {0}? </Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>MesaValvePMClose</Key>" & _
"      <Value>Would you like to close SlitValve for {0}? </Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>MesaValvePMUnknown</Key>" & _
"      <Value>Would you like to open/close SlitValve for {0}? </Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>MesaValvePM2Failed</Key>" & _
"      <Value>Failed to Operate Slit-Valve in time </Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>MesaValveLLAOpen</Key>" & _
"      <Value>Would you like to open SlitValve for LLA? </Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>MesaValveLLAClose</Key>" & _
"      <Value>Would you like to close SlitValve for LLA? </Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>HivacValveLLAOpen</Key>" & _
"      <Value>Would you like to open Hivac Valve for LLA? </Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>HivacValveLLAClose</Key>" & _
"      <Value>Would you like to close Hivac Valve for LLA? </Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>HivacValveLLAUnknown</Key>" & _
"      <Value>Would you like to open/close Hivac Valve for LLA? </Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>HivacValveTMOpen</Key>" & _
"      <Value>Would you like to open Hivac Valve for TM?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>HivacValveTMClose</Key>" & _
"      <Value>Would you like to close Hivac Valve for TM?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>HivacValveTMUnknown</Key>" & _
"      <Value>Would you like to open/close Hivac Valve for TM?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ibsHivacButtonOpen</Key>" & _
"      <Value>Would you like to open Hivac Valve for TM?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ibsHivacButtonClose</Key>" & _
"      <Value>Would you like to close Hivac Valve for TM?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ibsHivacButtonUnknown</Key>" & _
"      <Value>Would you like to Open/Close Hivac Valve for TM?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TransferValveVentOpen</Key>" & _
"      <Value>Would you like to open TM Vent Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TransferValveVentClose</Key>" & _
"      <Value>Would you like to close TM Vent Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TransferValveLLASlowVentOpen</Key>" & _
"      <Value>Would you like to open LLA Slow Vent Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TransferValveLLASlowVentClose</Key>" & _
"      <Value>Would you like to close LLA Slow Vent Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TransferValveLLAFastVentOpen</Key>" & _
"      <Value>Would you like to open LLA Fast Vent Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TransferValveLLAFastVentClose</Key>" & _
"      <Value>Would you like to close LLA Fast Vent Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TransferValveRoughOpen</Key>" & _
"      <Value>Would you like to open TM Rough Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TransferValveRoughClose</Key>" & _
"      <Value>Would you like to close TM Rough Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TransferValveLLASlowRoughOpen</Key>" & _
"      <Value>Would you like to open LLA Slow Rough Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TransferValveLLASlowRoughClose</Key>" & _
"      <Value>Would you like to close LLA Slow Rough Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TransferValveLLAFastRoughOpen</Key>" & _
"      <Value>Would you like to open LLA Fast Rough Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TransferValveLLAFastRoughClose</Key>" & _
"      <Value>Would you like to close LLA Fast Rough Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TransferValveTMTurboOpen</Key>" & _
"      <Value>Would you like to open TM Turbo Foreline Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TransferValveTMTurboClose</Key>" & _
"      <Value>Would you like to close TM Turbo Foreline Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TransferValveLLATurboOpen</Key>" & _
"      <Value>Would you like to open LLA Turbo Foreline Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TransferValveLLATurboClose</Key>" & _
"      <Value>Would you like to close LLA Turbo Foreline Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CGSmallerThan</Key>" & _
"      <Value>{0} CG {1} torr.</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>LL_Rough</Key>" & _
"      <Value>{0} is not closed</Value>" & _
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
"      <Key>TurboForelineCGRelay_FB</Key>" & _
"      <Value>{0} Turbo Foreline CG Relay is not On</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>MechanicalPumpCGRelay_FB</Key>" & _
"      <Value>{0} MechanicalPump CG Relay is not On</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ValveControlForelineOpen</Key>" & _
"      <Value>Would you like to open Turbo Foreline Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ValveControlForelineClose</Key>" & _
"      <Value>Would you like to close Turbo Foreline Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ValveWaterPumpOpen</Key>" & _
"      <Value>Would you like to open Turbo Pump?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ValveWaterPumpClose</Key>" & _
"      <Value>Would you like to close Turbo Pump?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>WaterValveOpen</Key>" & _
"      <Value>Would you like to open Water Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>WaterValveClose</Key>" & _
"      <Value>Would you like to close Water Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>FlowCoolPumpOpen</Key>" & _
"      <Value>Would you like to Turn Off Flow Cool Pump?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>FlowCoolPumpClose</Key>" & _
"      <Value>Would you like to Turn On Flow Cool Pump?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>RoughPumpPowerOpen</Key>" & _
"      <Value>Would you like to Turn On Rough Pump Power?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>RoughPumpPowerClose</Key>" & _
"      <Value>Would you like to Turn Off Rough Pump Power?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TurboPumpPowerOpen</Key>" & _
"      <Value>Would you like to Turn On Turbo Pump Power?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TurboPumpPowerClose</Key>" & _
"      <Value>Would you like to Turn Off Turbo Pump Power?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CryoPumpRegen</Key>" & _
"      <Value>Would you like to Cryo Pump Regen?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CryoAutoRegen</Key>" & _
"      <Value>Would you like to Cryo Auto Regen?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ValveControlCryoPumpOpen</Key>" & _
"      <Value>Would you like to open Cryo Pump Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ValveControlCryoPumpClose</Key>" & _
"      <Value>Would you like to close Cryo Pump Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ValveSupplyArgonOpen</Key>" & _
"      <Value>Would you like to open Supply Argon Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ValveSupplyArgonClose</Key>" & _
"      <Value>Would you like to close Supply Argon Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ValveSupplyFlowCoolHeOpen</Key>" & _
"      <Value>Would you like to open Supply FlowCool He Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ValveSupplyFlowCoolHeClose</Key>" & _
"      <Value>Would you like to close Supply FlowCool He Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ValveSupplyPBNOpen</Key>" & _
"      <Value>Would you like to open Supply PBN Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ValveSupplyPBNClose</Key>" & _
"      <Value>Would you like to close Supply PBN Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ValveControlRoughOpen</Key>" & _
"      <Value>Would you like to open Rough Valve?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ticGasPumpOpen</Key>" & _
"      <Value>Would you like to open Rough Pump?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ticGasPumpClose</Key>" & _
"      <Value>Would you like to change Rough Pump?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ValveControlRoughClose</Key>" & _
"      <Value>Would you like to change Rough Valve to False?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ValveControlVentOpen</Key>" & _
"      <Value>Would you like to change Vent Valve to True?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ValveRingControlClose</Key>" & _
"      <Value>Would you like to change HiVacValve to False?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ValveRingControlOpen</Key>" & _
"      <Value>Would you like to change HivacValve to True?</Value>" & _
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
"      <Value>Would you like to change Vent Valve to False?</Value>" & _
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
"      <Value>Would you like to change Baratron Valve to True?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ValveControlBaratronClose</Key>" & _
"      <Value>Would you like to change Baratron Valve to False?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ValveControlFlowCoolHeOpen</Key>" & _
"      <Value>Would you like to change Gas, Flow Cool He Valve to True?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ValveControlFlowCoolHeClose</Key>" & _
"      <Value>Would you like to change Gas, Flow Cool He Valve to False?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ValveControlPBNOpen</Key>" & _
"      <Value>Would you like to change Gas, PBN Valve to True?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ValveControlPBNClose</Key>" & _
"      <Value>Would you like to change Gas, PBN Valve to False?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ValveControlArgonOpen</Key>" & _
"      <Value>Would you like to change Gas, Argon Valve to True?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ValveControlArgonClose</Key>" & _
"      <Value>Would you like to change Gas, Argon Valve to False?</Value>" & _
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
"      <Value>{0}: TM Mechanical Pump CG &gt;= {1} Torr</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TMMechanicalPumpGreater</Key>" & _
"      <Value>{0}: TM Mechanical Pump CG &gt; .1 Torr</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>MechanicalPumpNotOn</Key>" & _
"      <Value>{0}: Mechanical Pump Not On</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>LLCGSmaller</Key>" & _
"      <Value>{0}: LL CG {1} {2} Torr. Max wait {3} min</Value>" & _
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
"      <Key>TurboWasNotOn</Key>" & _
"      <Value>{0}: Can not turn on Turbo  </Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TurboWasNotUpToSpeed</Key>" & _
"      <Value>{0}: Turbo can not up to speed </Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>DidNotOpenValve</Key>" & _
"      <Value>{0}: can not be opened </Value>" & _
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
"      <Value>{0}: Vent Valve was not closed</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>FailedToWaitTMRoughValvesClose</Key>" & _
"      <Value>{0}: Failed to wait TM Rough Valves closed</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TMRoughValvesWasNotClose</Key>" & _
"      <Value>{0}: Rough Valve was not closed</Value>" & _
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
"      <Key>LLForelineWasNotOpen</Key>" & _
"      <Value>{0}: Foreline was not opened</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>LLForelineWasNotClose</Key>" & _
"      <Value>{0}: Foreline was not closed</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TMForelineWasNotOpen</Key>" & _
"      <Value>{0}: Foreline was not opened</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>FailedToWaitTMForelineOpen</Key>" & _
"      <Value>{0}: Failed to wait Foreline opened</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TMForelineWasNotClose</Key>" & _
"      <Value>{0}: Foreline was not closed</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>FailedToWaitTMForelineClose</Key>" & _
"      <Value>{0}: Failed to wait TM Foreline closed</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>LLIGWasNotOff</Key>" & _
"      <Value>{0}: IG was not Off</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>LLTurboWasNotOff</Key>" & _
"      <Value>{0}: Turbo was not Off</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>FailedToWaitLLIGOff</Key>" & _
"      <Value>{0}: Failed to wait LL IG off</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TMIGWasNotOff</Key>" & _
"      <Value>{0}: IG was not Off</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>FailedToWaitTMIGOff</Key>" & _
"      <Value>{0}: Failed to wait TM IG off</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>LLIsolationValveWasNotClose</Key>" & _
"      <Value>{0}: LL Slit valve was not Closed</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>FailedToWaitLLIsolationValveClose</Key>" & _
"      <Value>{0}: Failed to wait LL Slit valve close</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>VentValveWasNotClosed</Key>" & _
"      <Value>{0}: Vent Valve was not Closed</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>FailedToWaitVentValveClose</Key>" & _
"      <Value>{0}: Failed to wait Vent Valve close</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>RoughValveWasNotOpened</Key>" & _
"      <Value>{0}: Rough Valve was not Closed</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>FailedToWaitRoughValveClose</Key>" & _
"      <Value>{0}: Failed to wait Rough Valve close</Value>" & _
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
"      <Key>FailedGetRoughLinePumpDown</Key>" & _
"      <Value>{0}: Failed to get Rough Line for Pump-Down</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>WriteKepserverError</Key>" & _
"      <Value>Couldn't write to Kep Server with the tag {0}. (Actioning Valve: {1})</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>OpenCloseValveFailed</Key>" & _
"      <Value>{0} Failed.</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TurnIGCGFailed</Key>" & _
"      <Value>Turn {0} Failed.</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SwitchIGFilamentFailed</Key>" & _
"      <Value>Switch to Filament {0} Failed.</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>KepserverError</Key>" & _
"      <Value>Couldn't write to Kep Server (Actioning Valve: {0})</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>Process_Running</Key>" & _
"      <Value>{0}: Scheduler is running!</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>VentPumpDownRunning</Key>" & _
"      <Value>{0}: Sequence Vent/Pumpdown is running!</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>HivacValveDidNotOpen</Key>" & _
"      <Value>{0}: Hivac Valve did not Open</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>FailedToWaitHivacValveOpen</Key>" & _
"      <Value>{0}: Failed to wait Hivac Valve Opened</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>HivacValveDidNotClose</Key>" & _
"      <Value>{0}: Hivac Valve did not closed</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IGDidNotOn</Key>" & _
"      <Value>{0}: IG Is Not On</Value>" & _
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
"      <Key>LLForelineValveOpenFailed</Key>" & _
"      <Value>Can't Open LLA Foreline Valve While TM Is Only In Regen Mode</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemOnlineError</Key>" & _
"      <Value>All related equipments are not Online</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemOnlineLLAError</Key>" & _
"      <Value>LLA is not Online</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemOnlineTMError</Key>" & _
"      <Value>Transfer Module is not Online</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>RFPowerSupply.txtForwardPowerRight</Key>" & _
"      <Value>Forward Power Set Point for Power Supply</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>BeamPowerSupplyControl.txtCurrentRight</Key>" & _
"      <Value>Current Set Point for Beam Power Supply</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>BeamPowerSupplyControl.txtVoltageRight</Key>" & _
"      <Value>Voltage Set Point for Beam Voltage Supply</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>BeamPowerSupplyControl.txtPowerRight</Key>" & _
"      <Value>Power Set Point for Beam Power Supply</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>RFPowerSupply.txtReflectedPowerRight</Key>" & _
"      <Value>Reflected Power Set Point for RF Power Supply</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SuppressorPowerSupplyControl.txtCurrentRight</Key>" & _
"      <Value>Current Set Point for Supp Power Supply</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SuppressorPowerSupplyControl.txtVoltageRight</Key>" & _
"      <Value>Voltage Set Point for Supp Power Supply</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>BodyPowerSupply.txtKFactorRight</Key>" & _
"      <Value>K Factor Set Point for Body Power Supply</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>BACenterControl.txtCG2</Key>" & _
"      <Value>CG Set Point for BA Center Control</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>BaCenterControlbigcgIGOpen</Key>" & _
"      <Value>Would you like to open IG?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>BaCenterControlbigcgIGClose</Key>" & _
"      <Value>Would you like to close IG?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>GasControllerControl.txtArgonRight</Key>" & _
"      <Value>Argon Set Point for Gas Controller</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>GasControllerControl.txtPBNRight</Key>" & _
"      <Value>PBN Set Point for Gas Controller</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>GasControllerControl.txtFlowCoolHeRight</Key>" & _
"      <Value>FlowCoolHe Set Point for Gas Controller</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>FixtureControl.txtTiltAngleRight</Key>" & _
"      <Value>Tilt Angle Set for Fixture Control</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>FixtureControl.txtRotationRight</Key>" & _
"      <Value>Rotation {0} Set for Fixture Control</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>FixtureControl.txtRotationLastRight</Key>" & _
"      <Value>Rotation End Set for Fixture Control</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SetMaxKWHPM</Key>" & _
"      <Value>Would you like to Set Max Usage?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CheckMaxUsagePM</Key>" & _
"      <Value>Would you like to {0} ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>DisableSensorChecking</Key>" & _
"      <Value>Would you like to {0} wafer sensors checking ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ResetWaferCounter</Key>" & _
"      <Value>Would you like to reset Wafer Counter?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ResetShieldQuartz</Key>" & _
"      <Value>Would you like to reset Shield/Quartz value?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ResetTargetSource</Key>" & _
"      <Value>Would you like to reset Target KWH/Source Usage value?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CheckOnlineLLA_Error</Key>" & _
"      <Value>LLA is not online</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CheckOnlineTM_Error</Key>" & _
"      <Value>Transfer Module is not online</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CheckOnlineChamber_Error</Key>" & _
"      <Value>{0} Is Not Online</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CannotTransferWafer</Key>" & _
"      <Value>{0} is not online. Cannot transfer wafer</Value>" & _
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
"      <Key>TMWaterPumpStatusOn</Key>" & _
"      <Value>Would you like to Turn On {0} Status?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TMWaterPumpStatusOff</Key>" & _
"      <Value>Would you like to Turn Off {0} Status?</Value>" & _
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
"      <Key>TransferAbortFastRegen</Key>" & _
"      <Value>Would you like to abort fast regen for {0}?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TransferStartFastRegen</Key>" & _
"      <Value>Would you like to start fast regen again for {0}?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TransferStartRegen</Key>" & _
"      <Value>Would you like to abort regen for {0}?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TransferAbortRegen</Key>" & _
"      <Value>Would you like to start regen for {0}?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>MenuOnlineOfCassettesPanel</Key>" & _
"      <Value>Would you like to Online for {0}?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>MenuOfflineOfCassettesPanel</Key>" & _
"      <Value>Would you like to Offline for {0}?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>MenuPumpDownOfCassettesPanel</Key>" & _
"      <Value>Would you like to start Pump Down for {0}?</Value>" & _
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
"      <Key>MenuIGDegasOfCassettesPanel</Key>" & _
"      <Value>Would you like to start IG Degas for {0}?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>StartSemiAutoRobotCassettes</Key>" & _
"      <Value>Would you like to start the semi auto transferring?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SendSerialCommandRobotCassettes</Key>" & _
"      <Value>Would you like to send the serial command to {0}?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>CheckMesaValveBeforeAction</Key>" & _
"      <Value>Please close Slit valve of {0}</Value>" & _
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
"      <Value>Would you like to home Robot?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>GotoStationRobot</Key>" & _
"      <Value>Do you want to goto {0}?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>GotoChamberSelfAligner</Key>" & _
"      <Value>Would you like start self align at {0}?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>RobotStatus</Key>" & _
"      <Value>Would you like to {0} Robot?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PickPlaceWafer</Key>" & _
"      <Value>Would you like to {0} Wafer?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>HomeMenuRobotCassettes</Key>" & _
"      <Value>Would you like to send command home?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ScanOperationsAligner</Key>" & _
"      <Value>Would you like to send command scan?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>AlignMenuRobotCassettes</Key>" & _
"      <Value>Would you like to send command Align?</Value>" & _
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
"      <Key>CycleATM</Key>" & _
"      <Value>Would you like to {0} sequence [{1}] in {2} with Cycle ATM Mode?</Value>" & _
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
"      <Key>IBE.SLFixture.btnRotate.Off</Key>" & _
"      <Value>Would you like to Stop Rotation Axis?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SLFixture.btnRotate.Sweep</Key>" & _
"      <Value>Would you like to Start Rotation Sweep?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SLFixture.btnRotate.Continuous</Key>" & _
"      <Value>Would you like to Start Rotation Continuous?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SLFixture.btnRotate.Static</Key>" & _
"      <Value>Would you like to Start Rotation Static?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SLFixture.btnRotate.Other</Key>" & _
"      <Value>Would you like to Start Rotation Axis?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SLFixture.btnRotate.Home</Key>" & _
"      <Value>Would you like to rotate fixture home?</Value>" & _
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
"      <Key>PVD.btnAutoPumpDown.On</Key>" & _
"      <Value>Would you like to Abort Pump down?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnAutoPumpDown.Off</Key>" & _
"      <Value>Would you like to Start Pump down?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>StopVentChamberPanel</Key>" & _
"      <Value>Would you like to stop Vent?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnAutoVent.On</Key>" & _
"      <Value>Would you like to Abort Vent?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnAutoVent.Off</Key>" & _
"      <Value>Would you like to Start Vent?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SL_PopUpPanel.btnCryoOnOff.Off</Key>" & _
"      <Value>Would you like to Turn Cryo off?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SL_PopUpPanel.btnCryoOnOff.On</Key>" & _
"      <Value>Would you like to Turn Cryo on?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SL_PopUpPanel.btnCryoOff.Off</Key>" & _
"      <Value>Would you like to Turn Cryo off?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SL_PopUpPanel.btnCryoOff.On</Key>" & _
"      <Value>Would you like to Turn Cryo on?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SL_PopUpPanel.btnWaterPumpOnOff.Off</Key>" & _
"      <Value>Would you like to Turn WaterPump Off?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SL_PopUpPanel.btnWaterPumpOnOff.On</Key>" & _
"      <Value>Would you like to Turn WaterPump On?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SL_PopUpPanel.btnWaterPumpOff.Off</Key>" & _
"      <Value>Would you like to Turn WaterPump Off?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>IBE.SL_PopUpPanel.btnWaterPumpOff.On</Key>" & _
"      <Value>Would you like to Turn WaterPump On?</Value>" & _
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
"      <Key>PVD.btnWaterPumpOff</Key>" & _
"      <Value>Would you like to turn WaterPump off?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnWaterPumpOn</Key>" & _
"      <Value>Would you like to turn WaterPump on?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnWaterPumpOnOff.Open</Key>" & _
"      <Value>Would you like to turn WaterPump off?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnWaterPumpOnOff.Close</Key>" & _
"      <Value>Would you like to turn WaterPump on?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnShutDownPower.Off</Key>" & _
"      <Value>Would you like to Shut Down Power?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnIGDegas.Off</Key>" & _
"      <Value>Would you like to start IG Degas?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnIGDegas.On</Key>" & _
"      <Value>Would you like to Abort IG Degas?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnFastRegen.Off</Key>" & _
"      <Value>Would you like to start Fast Regen?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnFastRegen.On</Key>" & _
"      <Value>Would you like to abort Fast Regen?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnPumpPurge.Off</Key>" & _
"      <Value>Would you like to start Pump Purge?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnPumpPurge.On</Key>" & _
"      <Value>Would you like to Abort Pump Purge?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnCryoOff</Key>" & _
"      <Value>Would you like to turn Cryo off?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnCryoOn</Key>" & _
"      <Value>Would you like to turn Cryo on?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnAutoRegenOff</Key>" & _
"      <Value>Would you like to Abort Cryo Auto Regen?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnAutoRegenOn</Key>" & _
"      <Value>Would you like to Start Cryo Auto Regen?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnWPRegenOff</Key>" & _
"      <Value>Would you like to Abort WaterPump Regen?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.btnWPRegenOn</Key>" & _
"      <Value>Would you like to Start WaterPump Regen?</Value>" & _
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
"      <Value>Do you want to start {0}?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD.DiagnosticScreen.btnStart.Stop</Key>" & _
"      <Value>Do you want to stop {0}?</Value>" & _
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
"      <Key>EquipmentCouldNotCopyRecipe</Key>" & _
"      <Value>Could not copy recipe: {0} to {1}</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>EquipmentRecipeDoesNotExist</Key>" & _
"      <Value>Recipe {0} does not exist.</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>EquipmentRecipeTemplateDoesNotExist</Key>" & _
"      <Value>Recipe template {0} does not exist.</Value>" & _
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
"      <Value>{0}: All Interlocks are not made {1}. Go Online failed </Value>" & _
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
"    <MessageText>" & _
"      <Key>TMWPIsLessThanTConfig</Key>" & _
"      <Value>TM Water Pump T1 is less than {0}K </Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TMWPIsOn</Key>" & _
"      <Value>TM Water Pump is on </Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TurboLLAOn</Key>" & _
"      <Value>Would you like to turn on Turbo of LLA ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TurboLLAOff</Key>" & _
"      <Value>Would you like to turn off Turbo of LLA ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TurboLLAOnOff</Key>" & _
"      <Value>Would you like to turn on/off Turbo of LLA ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TurboTMOn</Key>" & _
"      <Value>Would you like to turn on Turbo of Transfer Module ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TurboTMOff</Key>" & _
"      <Value>Would you like to turn off Turbo of Transfer Module ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>TurboTMOnOff</Key>" & _
"      <Value>Would you like to turn on/off Turbo of Transfer Module ?</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>UNABLE_RUN_AUTO_BEAM_HIVAC_CLOSED</Key>" & _
"      <Value>Can Not Start AutoBeam Because Hivac Valves Are Closed</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>UNABLE_RUN_AUTO_BEAM_IG_OFF</Key>" & _
"      <Value>Can Not Start AutoBeam Because IG Is OFF</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>INVALID_AUTO_BEAM_DATA_PBN_GAS_ZERO</Key>" & _
"      <Value>Auto Beam Condition Is Invalid Due To PBN Gas Zero</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ALL_INTERLOCKS_ARE_NOT_MADE</Key>" & _
"      <Value>Can Not Start AutoBeam Because All Interlocks Are Not Made</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>UNABLE_RUN_AUTO_BEAM_PROCESS_RUNNING</Key>" & _
"      <Value>Can Not Start AutoBeam Because IBE Is Busy Running Recipe Process Sequence</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>FIXTURE_CLAMP_IS_NOT_UP</Key>" & _
"      <Value>Fixture Clamp Is Not Up</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>NO_WAFER_IN_PM</Key>" & _
"      <Value>There Is No Wafer In {0}</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>VentValveIsNotClosed</Key>" & _
"      <Value>Vent valve is not closed</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>RoughValveIsNotClosed</Key>" & _
"      <Value>Rough valve is not closed</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>ForelineValveIsNotClosed</Key>" & _
"      <Value>Foreline valve is not closed</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtPort</Key>" & _
"      <Value>Enter Port Server Number</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>SystemSetup.txtEveryMinutes</Key>" & _
"      <Value>Enter Minutes Number Of Report Pressure</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.txtHeaterZone1SP</Key>" & _
"      <Value>Heater Zone1 Set Point</Value>" & _
"    </MessageText>" & _
"    <MessageText>" & _
"      <Key>PVD4.txtHeaterZone2SP</Key>" & _
"      <Value>Heater Zone2 Set Point</Value>" & _
"    </MessageText>" & _
"  </UserMessageTexts>" & _
"  <VentPumpdownConfig>" & _
"    <LLVentConfig>" & _
"      <Item Name=""LLMesaValveOpenCloseTimeOut"" Value=""10"" />" & _
"      <Item Name=""IGOnOffTimeOut"" Value=""30"" />" & _
"      <Item Name=""LLHivacOpenCloseTimeOut"" Value=""10"" />" & _
"      <Item Name=""LLASlowVentTimeOut"" Value=""180"" />" & _
"      <Item Name=""LLASlowVentPressure"" Value=""150"" />" & _
"      <Item Name=""LLAFastVentTimeOut"" Value=""300"" />" & _
"      <Item Name=""LLAVentPressure"" Value=""760"" />" & _
"      <Item Name=""LLVentValveOpenCloseTimeOut"" Value=""5"" />" & _
"      <Item Name=""LLVent_Delay_Time"" Value=""5"" />" & _
"    </LLVentConfig>" & _
"    <LLPumpdownConfig>" & _
"      <Item Name=""LLMesaValveOpenCloseTimeOut"" Value=""10"" />" & _
"      <Item Name=""IGOnOffTimeOut"" Value=""30"" />" & _
"      <Item Name=""LLHivacOpenCloseTimeOut"" Value=""10"" />" & _
"      <Item Name=""TMMechanicalPumpOnPressure"" Value=""0.1"" />" & _
"      <Item Name=""LLASlowRoughPressure"" Value=""500"" />" & _
"      <Item Name=""LLASlowRoughPressureTimeOut"" Value=""600"" />" & _
"      <Item Name=""LLAFastRoughPressure"" Value=""0.08"" />" & _
"      <Item Name=""LLAFastRoughPressureTimeOut"" Value=""1500"" />" & _
"      <Item Name=""LLACryoColdTemp"" Value=""20"" />" & _
"      <Item Name=""IGOnDelay"" Value=""10"" />" & _
"      <Item Name=""LLRoughValveOpenCloseTimeOut"" Value=""5"" />" & _
"      <Item Name=""LLPumpDown_Delay_Time"" Value=""45"" />" & _
"      <Item Name=""LLMakeRoughLineInUseTimeOut"" Value=""600"" />" & _
"    </LLPumpdownConfig>" & _
"    <TMVentConfig>" & _
"      <Item Name=""TMMesaValvesOpenCloseTimeOut"" Value=""5"" />" & _
"      <Item Name=""IGOnOffTimeOut"" Value=""30"" />" & _
"      <Item Name=""TMHivacOpenCloseTimeOut"" Value=""10"" />" & _
"      <Item Name=""TMVentPressure"" Value=""760"" />" & _
"      <Item Name=""TMVentTimeOut"" Value=""300"" />" & _
"      <Item Name=""TMVentValveOpenCloseTimeOut"" Value=""5"" />" & _
"      <Item Name=""TMVent_Delay_Time"" Value=""5"" />" & _
"    </TMVentConfig>" & _
"    <TMPumpdownConfig>" & _
"      <Item Name=""TMMesaValvesOpenCloseTimeOut"" Value=""5"" />" & _
"      <Item Name=""IGOnOffTimeOut"" Value=""30"" />" & _
"      <Item Name=""TMHivacOpenCloseTimeOut"" Value=""30"" />" & _
"      <Item Name=""TMMechanicalPumpOnPressure"" Value=""0.1"" />" & _
"      <Item Name=""TMRoughPressure"" Value=""0.08"" />" & _
"      <Item Name=""TMRoughTimeOut"" Value=""300"" />" & _
"      <Item Name=""TMCryoColdTemp"" Value=""20"" />" & _
"      <Item Name=""IGOnDelay"" Value=""10"" />" & _
"      <Item Name=""TMPumdown_Delay_Time"" Value=""30"" />" & _
"      <Item Name=""TMMakeRoughLineInUseTimeOut"" Value=""600"" />" & _
"    </TMPumpdownConfig>" & _
"    <CGConfig>" & _
"      <Item Name=""TMCGTripPoint"" Value=""0.5"" />" & _
"      <Item Name=""LLACGTripPoint"" Value=""0.5"" />" & _
"      <Item Name=""MPCGTripPoint"" Value=""0.5"" />" & _
"      <Item Name=""TMTurboCGTripPoint"" Value=""0.5"" />" & _
"      <Item Name=""LLATurboCGTripPoint"" Value=""0.5"" />" & _
"    </CGConfig>" & _
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
"      <Value>0.008</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>LoadLockATransferSetPoint</Key>" & _
"      <Value>0.008</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>Chamber1TransferSetPoint</Key>" & _
"      <Value>1E-05</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>Chamber2TransferSetPoint</Key>" & _
"      <Value>0.1</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>Chamber3TransferSetPoint</Key>" & _
"      <Value>1E-05</Value>" & _
"    </Configure>" & _
"    <Configure>" & _
"      <Key>PressureDifferentialPercent</Key>" & _
"      <Value>10</Value>" & _
"    </Configure>" & _
"  </TransferPressureSetpoint>" & _
"  <DegasWaitTime>" & _
"    <LLA>30</LLA>" & _
"    <TM>30</TM>" & _
"  </DegasWaitTime>" & _
"  <SoundOnDuringAlarm>True</SoundOnDuringAlarm>" & _
"  <CryoRegenHourLimit>2500</CryoRegenHourLimit>" & _
"  <ConnectionTimeOut>0</ConnectionTimeOut>" & _
"</SystemConfiguration>"
End Class
End Namespace
