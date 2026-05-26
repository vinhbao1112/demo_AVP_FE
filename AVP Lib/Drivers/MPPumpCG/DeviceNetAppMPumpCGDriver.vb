Namespace Driver
    Public Class DeviceNetAppMPumpCGDriver
        Inherits DeviceNetAppCGDriver

        ''' <summary>
        ''' New object CG device net
        ''' </summary>
        Public Sub New(ByVal sDriverName As String, _
                    ByVal iMacID As UShort)
            MyBase.new(sDriverName)
            m_sMacID = iMacID
            m_strComName = sDriverName.Replace("."c, "") & "Com"
        End Sub

        Public Sub New(ByVal sDriverName As String)
            MyBase.new(sDriverName)
        End Sub

    End Class
End Namespace