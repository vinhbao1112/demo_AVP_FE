Namespace XMLResources
Public Class ConfigurationServer.xml
Public Const XMLText as String = _
"<Servers>" & _
"  <KepServer Name=""KEPware.KEPServerEx.V4"" />" & _
"  <TerminalServer>" & _
"    <Server Name=""LLAElevator"" IsInstall=""True"" Type=""LoadLock"" EthernetIP=""192.168.1.222"" Port=""4001"" />" & _
"    <Server Name=""LLBElevator"" IsInstall=""True"" Type=""LoadLock"" EthernetIP=""192.168.1.222"" Port=""4002"" />" & _
"    <Server Name=""Robot"" IsInstall=""True"" Type=""Robot"" EthernetIP=""192.168.1.222"" Port=""4003"" />" & _
"    <Server Name=""LLACryo"" IsInstall=""True"" EthernetIP=""192.168.1.222"" Port=""4005"" />" & _
"    <Server Name=""LLBCryo"" IsInstall=""True"" EthernetIP=""192.168.1.222"" Port=""4004"" />" & _
"    <Server Name=""TMCryo"" IsInstall=""True"" EthernetIP=""192.168.1.222"" Port=""4006"" />" & _
"    <Server Name=""Aligner"" IsInstall=""True"" Type=""Aligner"" EthernetIP=""192.168.1.222"" Port=""4007"" />" & _
"  </TerminalServer>" & _
"  <Install_CX6>True</Install_CX6>" & _
"  <Install_CX7>False</Install_CX7>" & _
"  <Install_CX8>False</Install_CX8>  " & _
"  <Chamber1 Name=""Chamber1"" IsInstall=""True"" Type=""PVD"" EthernetIP=""127.0.0.1"" Port=""8008"" ConfigFolder=""D:\working\projects\Deployment\Config"" RecipeFolder=""D:\working\projects\Deployment\Recipe""/>" & _
"  <Chamber2 Name=""Chamber2"" IsInstall=""True"" Type=""IBE"" EthernetIP=""127.0.0.1"" Port=""8009"" ConfigFolder=""D:\working\projects\Deployment\Config"" RecipeFolder=""D:\working\projects\Deployment\Recipe""/>" & _
"  <Chamber3 Name=""Chamber3"" IsInstall=""True"" Type=""PVD"" EthernetIP=""127.0.0.1"" Port=""8010"" ConfigFolder=""D:\working\projects\Deployment\Config"" RecipeFolder=""D:\working\projects\Deployment\Recipe""/>" & _
"  <Chamber4 Name=""Chamber4"" IsInstall=""True"" Type=""PVD"" EthernetIP=""127.0.0.1"" Port=""8011"" ConfigFolder=""D:\working\projects\Deployment\Config"" RecipeFolder=""D:\working\projects\Deployment\Recipe""/>" & _
"  <Chamber5 Name=""Chamber5"" IsInstall=""True"" Type=""PVD"" EthernetIP=""127.0.0.1"" Port=""8012"" ConfigFolder=""D:\working\projects\Deployment\Config"" RecipeFolder=""D:\working\projects\Deployment\Recipe""/>" & _
"  <Chamber5 Name=""Chamber6"" IsInstall=""True"" Type=""PVD"" EthernetIP=""127.0.0.1"" Port=""8013"" ConfigFolder=""D:\working\projects\Deployment\Config"" RecipeFolder=""D:\working\projects\Deployment\Recipe""/>" & _
"</Servers>"
End Class
End Namespace
