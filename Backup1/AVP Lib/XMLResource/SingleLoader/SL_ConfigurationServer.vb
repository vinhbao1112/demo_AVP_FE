Namespace XMLResources
    Public Class SL_ConfigurationServer
        Public Const XMLText As String = _
        "<Servers>" & _
        "  <KepServer Name=""KEPware.KEPServerEx.V5"" />" & _
        "  <TerminalServer>" & _
        "    <Server Name=""Loader"" IsInstall=""True"" Type=""Loader"" EthernetIP=""192.168.1.222"" Port=""4007"" />" & _
        "  </TerminalServer>" & _
        "  <Install_CX>SL</Install_CX>" & _
        "  <Chamber1 Name=""Chamber1"" IsInstall=""True"" Type=""IBE"" EthernetIP=""127.0.0.1"" Port=""8008"" " & _
        "	ConfigFolder=""D:\SingleLoaderData"" " & _
        "	RecipeFolder=""D:\SingleLoaderData""" & _
        "    RaiseOfRiseFolder=""D:\SingleLoaderData"" RaiseOfRiseFilename=""ror.txt""" & _
        "	DataRunFolder=""D:\SingleLoaderData"" DataRunFilename=""datarun.txt""" & _
        "  />" & _
        "  </Servers>"
    End Class
End Namespace
