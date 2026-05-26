Namespace XMLResources
Public Class DriverConfig
Public Const XMLText as String = _
"<DriverConfiguration>" & _
"  <Project Name=""CX4"">" & _
"    <!-- DeviceNet Region-->" & _
"    <Driver Name=""RoughPumpMachine1.CG"" IsInstalled=""True"" CommType=""DeviceNet"" DeviceType=""MPumpCG"" MacID=""4"" />" & _
"    <Driver Name=""RoughPumpMachine2.CG"" IsInstalled=""False"" CommType=""DeviceNet"" DeviceType=""MPumpCG"" MacID=""5"" />" & _
"    <Driver Name=""LoadLockA.Ion"" IsInstalled=""False"" CommType=""DeviceNet"" DeviceType=""IG"" MacID=""9"" />" & _
"    <Driver Name=""LoadLockA.CG"" IsInstalled=""True"" CommType=""DeviceNet"" DeviceType=""CG"" MacID=""10"" />" & _
"    <Driver Name=""CassettesModule.Ion"" IsInstalled=""True"" CommType=""DeviceNet"" DeviceType=""IG"" MacID=""6"" />" & _
"    <Driver Name=""CassettesModule.CG"" IsInstalled=""True"" CommType=""DeviceNet"" DeviceType=""CG"" MacID=""7"" />" & _
"    <Driver Name=""LoadLockA.TurboForelineCG"" IsInstalled=""False"" CommType=""DeviceNet"" DeviceType=""TurboForeLine"" MacID=""11"" />" & _
"    <Driver Name=""CassettesModule.TurboForelineCG"" IsInstalled=""False"" CommType=""DeviceNet"" DeviceType=""TurboForeLine"" MacID=""8"" />" & _
"    <Driver Name=""CassettesModule.TurboForelineValve"" IsInstalled=""False"" CommType=""DeviceNet"" DeviceType=""TurboForeLineValve"" MacID=""2"" BitIndex=""11"" />" & _
"    <Driver Name=""LoadLockA.TurboForelineValve"" IsInstalled=""False"" CommType=""DeviceNet"" DeviceType=""TurboForeLineValve"" MacID=""2"" BitIndex=""5"" />" & _
"    <Driver Name=""LoadLockA.LLFastRough"" IsInstalled=""True"" CommType=""DeviceNet"" DeviceType=""RoughValve"" MacID=""2"" BitIndex=""3"" />" & _
"    <Driver Name=""CassettesModule.Rough"" IsInstalled=""True"" CommType=""DeviceNet"" DeviceType=""RoughValve"" MacID=""2"" BitIndex=""9"" />" & _
"    <Driver Name=""LoadLockA.LLSlowRough"" IsInstalled=""True"" CommType=""DeviceNet"" DeviceType=""RoughValve"" MacID=""2"" BitIndex=""4"" />" & _
"    <Driver Name=""LoadLockA.LLFastVent"" IsInstalled=""True"" CommType=""DeviceNet"" DeviceType=""VentValve"" MacID=""2"" BitIndex=""1"" />" & _
"    <Driver Name=""CassettesModule.Vent"" IsInstalled=""True"" CommType=""DeviceNet"" DeviceType=""VentValve"" MacID=""2"" BitIndex=""10"" />" & _
"    <Driver Name=""LoadLockA.LLSlowVent"" IsInstalled=""True"" CommType=""DeviceNet"" DeviceType=""VentValve"" MacID=""2"" BitIndex=""2"" />" & _
"    <Driver Name=""LoadLockA.LLHiVac"" IsInstalled=""False"" CommType=""DeviceNet"" DeviceType=""HivacValve"" MacID=""1"" BitIndex=""9"" />" & _
"    <Driver Name=""CassettesModule.TMHiVac"" IsInstalled=""True"" CommType=""DeviceNet"" DeviceType=""HivacValve"" MacID=""1"" BitIndex=""11"" />" & _
"    <Driver Name=""CassettesModule.SplitValveLLA"" IsInstalled=""True"" CommType=""DeviceNet"" DeviceType=""IsolationValve"" MacID=""1"" OpenBitIndex=""7"" CloseBitIndex=""8"" />" & _
"    <Driver Name=""CassettesModule.SplitValvePM1"" IsInstalled=""False"" CommType=""DeviceNet"" DeviceType=""IsolationValve"" MacID=""1"" OpenBitIndex=""1"" CloseBitIndex=""2"" />" & _
"    <Driver Name=""CassettesModule.SplitValvePM2"" IsInstalled=""True"" CommType=""DeviceNet"" DeviceType=""IsolationValve"" MacID=""1"" OpenBitIndex=""3"" CloseBitIndex=""4"" />" & _
"    <Driver Name=""CassettesModule.SplitValvePM3"" IsInstalled=""True"" CommType=""DeviceNet"" DeviceType=""IsolationValve"" MacID=""1"" OpenBitIndex=""5"" CloseBitIndex=""6"" />" & _
"    <!-- Kepware Region-->" & _
"    <Driver Name=""CassettesModule.SensorLLAStatus"" IsInstalled=""True"" CommType=""Kepware"" DeviceType=""Sensor"" MacID="""" />" & _
"    <Driver Name=""CassettesModule.SensorPM1Status"" IsInstalled=""False"" CommType=""Kepware"" DeviceType=""Sensor"" MacID="""" />" & _
"    <Driver Name=""CassettesModule.SensorPM2Status"" IsInstalled=""True"" CommType=""Kepware"" DeviceType=""Sensor"" MacID="""" />" & _
"    <Driver Name=""CassettesModule.SensorPM3Status"" IsInstalled=""True"" CommType=""Kepware"" DeviceType=""Sensor"" MacID="""" />" & _
"    <!-- Serial Region Model=Lebold-->" & _
"    <Driver Name=""LLAPumpPackage"" IsInstalled=""False"" CommType=""Serial"" DeviceType=""Cryo"" MacID="""" Model="""" />" & _
"    <Driver Name=""TMPumpPackage"" IsInstalled=""True"" CommType=""Serial"" DeviceType=""Cryo"" MacID="""" Model="""" />" & _
"    <BlockDevice MacID=""30"">" & _
"      <Driver Name=""TMPumpPackage.TurboStatus"" DeviceType=""Turbo"" ModelID=""ST-2328"" SlotID=""1"" ChannelID=""1"" />" & _
"      <Driver Name=""CassettesModule.RoughPump2Status"" DeviceType=""MPumpCG"" ModelID=""ST-2328"" SlotID=""1"" ChannelID=""2"" />" & _
"      <Driver Name=""CassettesModule.RoughPump1Status"" DeviceType=""MPumpCG"" ModelID=""ST-2328"" SlotID=""1"" ChannelID=""3"" />" & _
"      <Driver Name=""LLAPumpPackage.TurboStatus"" DeviceType=""Turbo"" ModelID=""ST-2328"" SlotID=""1"" ChannelID=""4"" />" & _
"      <Driver Name=""CassettesModule.Process_Complete_Chime"" DeviceType=""Alarm"" ModelID=""ST-2328"" SlotID=""2"" ChannelID=""3"" />" & _
"      <Driver Name=""Alarm.AlarmStatus"" DeviceType=""Alarm"" ModelID=""ST-2328"" SlotID=""2"" ChannelID=""4"" />" & _
"      <Driver Name=""Alarm.RedStatus"" DeviceType=""Alarm"" ModelID=""ST-2328"" SlotID=""2"" ChannelID=""5"" />" & _
"      <Driver Name=""Alarm.BlueStatus"" DeviceType=""Alarm"" ModelID=""ST-2328"" SlotID=""2"" ChannelID=""6"" />" & _
"      <Driver Name=""Alarm.GreenStatus"" DeviceType=""Alarm"" ModelID=""ST-2328"" SlotID=""2"" ChannelID=""7"" />" & _
"      <Driver Name=""Alarm.OrangeStatus"" DeviceType=""Alarm"" ModelID=""ST-2328"" SlotID=""2"" ChannelID=""8"" />" & _
"      <Driver Name=""CassettesModule.HiVacValveCloseStatus"" DeviceType=""HivacValve"" ModelID=""ST-1228"" SlotID=""3"" ChannelID=""1"" />" & _
"      <Driver Name=""CassettesModule.HiVacValveOpenStatus"" DeviceType=""HivacValve"" ModelID=""ST-1228"" SlotID=""3"" ChannelID=""2"" />" & _
"      <Driver Name=""LoadLockA.HiVacValveCloseStatus"" DeviceType=""HivacValve"" ModelID=""ST-1228"" SlotID=""3"" ChannelID=""3"" />" & _
"      <Driver Name=""LoadLockA.HiVacValveOpenStatus"" DeviceType=""HivacValve"" ModelID=""ST-1228"" SlotID=""3"" ChannelID=""4"" />" & _
"      <Driver Name=""CassettesModule.SplitValve2CloseStatus"" DeviceType=""IsolationValve"" ModelID=""ST-1228"" SlotID=""3"" ChannelID=""7"" />" & _
"      <Driver Name=""CassettesModule.SplitValve2OpenStatus"" DeviceType=""IsolationValve"" ModelID=""ST-1228"" SlotID=""3"" ChannelID=""8"" />" & _
"      <Driver Name=""CassettesModule.SplitValve3CloseStatus"" DeviceType=""IsolationValve"" ModelID=""ST-1228"" SlotID=""4"" ChannelID=""1"" />" & _
"      <Driver Name=""CassettesModule.SplitValve3OpenStatus"" DeviceType=""IsolationValve"" ModelID=""ST-1228"" SlotID=""4"" ChannelID=""2"" />" & _
"      <Driver Name=""CassettesModule.SplitValve4CloseStatus"" DeviceType=""IsolationValve"" ModelID=""ST-1228"" SlotID=""4"" ChannelID=""3"" />" & _
"      <Driver Name=""CassettesModule.SplitValve4OpenStatus"" DeviceType=""IsolationValve"" ModelID=""ST-1228"" SlotID=""4"" ChannelID=""4"" />" & _
"      <Driver Name=""CassettesModule.SplitValve1CloseStatus"" DeviceType=""IsolationValve"" ModelID=""ST-1228"" SlotID=""4"" ChannelID=""7"" />" & _
"      <Driver Name=""CassettesModule.SplitValve1OpenStatus"" DeviceType=""IsolationValve"" ModelID=""ST-1228"" SlotID=""4"" ChannelID=""8"" />" & _
"      <Driver Name=""TMPumpPackage.TurboUptoSpeed"" DeviceType=""Turbo"" ModelID=""ST-1228"" SlotID=""5"" ChannelID=""8"" />" & _
"      <Driver Name=""CassettesModule.SensorLLAStatus"" DeviceType=""Sensor"" ModelID=""ST-1228"" SlotID=""6"" ChannelID=""1"" />" & _
"      <Driver Name=""LLAPumpPackage.TurboUptoSpeed"" DeviceType=""Turbo"" ModelID=""ST-1228"" SlotID=""6"" ChannelID=""2"" />" & _
"      <Driver Name=""CassettesModule.SensorPM1Status"" DeviceType=""Sensor"" ModelID=""ST-1228"" SlotID=""6"" ChannelID=""3"" />" & _
"      <Driver Name=""CassettesModule.SensorPM2Status"" DeviceType=""Sensor"" ModelID=""ST-1228"" SlotID=""6"" ChannelID=""4"" />" & _
"      <Driver Name=""CassettesModule.SensorPM3Status"" DeviceType=""Sensor"" ModelID=""ST-1228"" SlotID=""6"" ChannelID=""5"" />" & _
"      <Driver Name=""Alarm.ToBeDefine11"" DeviceType=""Alarm"" ModelID=""ST-1228"" SlotID=""7"" ChannelID=""4"" />" & _
"    </BlockDevice>" & _
"    <!--Type DI= Digital Input, DO=Digital Output, AI=Analog Input, AO=Analog Output /-->" & _
"    <RSTiModel>" & _
"      <Model Type=""DI"" Size=""8"" MaxRawValue=""1"" MinRawValue=""0"">ST-1228</Model>" & _
"      <Model Type=""DO"" Size=""8"" MaxRawValue=""1"" MinRawValue=""0"">ST-2328</Model>" & _
"    </RSTiModel>" & _
"    <ChannelScale>" & _
"      <Scale MaxScale=""1"" MinScale=""0"">Alarm.AlarmStatus</Scale>" & _
"    </ChannelScale>" & _
"  </Project>" & _
"</DriverConfiguration>" & _
"<!--	Pease Read Comment before Add item -->" & _
"<!--	Name = Name of Instace -->" & _
"<!--	CommType = DeviceNet|Serial|Kepware -->" & _
"<!--	DeviceType used for mapping object -->" & _
"<!--		+ DeviceNet need 4 field {Name,CommType,DeviceType,MacID} -->" & _
"<!--		+ Kepware   need 3 field {Name,CommType,DeviceType,Empty} -->" & _
"<!--		+ Serial    need 3 field {Name,CommType,DeviceType,Empty} -->" & _
"<!--		Serial will be refer to ConfigurationServer.xml -->"
End Class
End Namespace
