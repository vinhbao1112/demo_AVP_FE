Namespace XMLResources
Public Class ConfigurationServer
Public Const XMLText as String = _
"<Servers>" & _
"  <KepServer Name=""KEPware.KEPServerEx.V5"" />" & _
"  <DeviceNetAdapter Name=""RSTI"" IsInstall=""True"" />" & _
"  <TerminalServer>" & _
"    <Server Name=""LLAElevator"" IsManualDoor=""True"" IsInstall=""True"" Type=""LoadLock"" EthernetIP=""127.0.0.1"" Port=""4001"" Version=""VC4"" />" & _
"    <Server Name=""Robot"" IsInstall=""True"" IsSensorInstall=""False"" Type=""Robot"" EthernetIP=""127.0.0.1"" Port=""4003"" />" & _
"    <Server Name=""LLAPumpPackage"" IsInstall=""False"" Type=""Cryo"" EthernetIP=""127.0.0.1"" Port=""4005"" />" & _
"    <Server Name=""TMPumpPackage"" IsInstall=""True"" Type=""Cryo"" EthernetIP=""127.0.0.1"" Port=""4006"" />" & _
"    <Server Name=""Aligner"" IsInstall=""True"" Type=""Aligner"" EthernetIP=""127.0.0.1"" Port=""4007"" />" & _
"    <Server Name=""TMWaterPump"" IsInstall=""False"" Type=""TMWaterPump"" EthernetIP=""127.0.0.1"" Port=""4008"" />" & _
"    <Server Name=""RoughPumpMachine1"" IsInstall=""False"" Type=""MPSerial"" EthernetIP=""127.0.0.1"" Port=""4010"" />" & _
"    <Server Name=""RoughPumpMachine2"" IsInstall=""False"" Type=""MPSerial"" EthernetIP=""127.0.0.1"" Port=""4010"" />" & _
"    <Server Name=""LLAHeater"" IsInstall=""False"" Type=""Heater"" EthernetIP=""127.0.0.1"" Port=""4012"" />" & _
"    <Server Name=""DeviceNetApp"" IsInstall=""False"" Type=""DeviceNetApp"" EthernetIP=""127.0.0.1"" Port=""10001"" />" & _
"  </TerminalServer>" & _
"  <ChamberInstall>" & _
"    <Chamber1 Name=""Chamber1"" IsInstall=""False"" Type=""PVD4"" EthernetIP=""192.168.1.19"" Port=""8010"" ConfigFolder=""\\192.168.1.19\BackEnd\PVD4\PVD4_CCR_Source_latest\Config"" RecipeFolder=""\\192.168.1.19\BackEnd\PVD4\PVD4_CCR_Source_latest\Recipe"" />" & _
"    <Chamber2 Name=""Chamber2"" IsInstall=""False"" Type=""PVD4"" EthernetIP=""127.0.0.1"" Port=""8009"" ConfigFolder=""G:\My Drive\BackEnd\PVD4\PVD4_Deployment_Latest\Config"" RecipeFolder=""G:\My Drive\BackEnd\PVD4\PVD4_Deployment_Latest\Recipe"" />" & _
"    <Chamber3 Name=""Chamber3"" IsInstall=""True"" Type=""PVD5T"" EthernetIP=""127.0.0.1"" Port=""8024"" ConfigFolder=""d:\Working\AVP\avp_code\AVP_Phase VI\Source Code\AVP_PVD5T\Deployment\Config\"" RecipeFolder=""d:\Working\AVP\avp_code\AVP_Phase VI\Source Code\AVP_PVD5T\Deployment\Recipe\"" />" & _
"  </ChamberInstall>" & _
"</Servers>"
End Class
End Namespace
