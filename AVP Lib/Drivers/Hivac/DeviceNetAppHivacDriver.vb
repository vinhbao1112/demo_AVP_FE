Namespace Driver
    Public Class DeviceNetAppHivacDriver
        Inherits DeviceNetAppDriver
        Implements IValveDriver

        Public Sub New(ByVal sDriverName As String, _
                    ByVal iMacID As UShort)
            MyBase.new(sDriverName)
            m_sMacID = iMacID
            m_strComName = "SolenoidBlock" & iMacID & "Com"
        End Sub

        Public Sub New(ByVal sDriverName As String)
            MyBase.new(sDriverName)
        End Sub

        Public Function Close() As Boolean Implements IValveDriver.Close
            Dim sCommandCode As String = ContainerData.GetDeviceNetAppCmdCode(m_sDriverName)
            sCommandCode = sCommandCode & ",False"

            Return SendCommandToDeviceNetApp(sCommandCode)
        End Function

        Public Function Open() As Boolean Implements IValveDriver.Open
            Dim sCommandCode As String = ContainerData.GetDeviceNetAppCmdCode(m_sDriverName)
            sCommandCode = sCommandCode & ",True"

            Return SendCommandToDeviceNetApp(sCommandCode)
        End Function

        Public Function Unknown() As Boolean Implements IValveDriver.Unknown

        End Function
    End Class
End Namespace