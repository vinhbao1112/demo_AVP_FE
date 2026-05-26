Namespace Driver
    Public Class DeviceNetAppIsolationValveDriver
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
            Dim sCommandCode As String = ContainerData.GetDeviceNetAppCmdCode(m_sDriverName & ".Close")
            Dim sCommandCode2 As String = ContainerData.GetDeviceNetAppCmdCode(m_sDriverName & ".Open")

            sCommandCode = sCommandCode & ",True"
            sCommandCode2 = sCommandCode2 & ",False"

            Return SendCommandToDeviceNetApp(sCommandCode) And SendCommandToDeviceNetApp(sCommandCode2)
        End Function

        Public Function Open() As Boolean Implements IValveDriver.Open
            Dim sCommandCode As String = ContainerData.GetDeviceNetAppCmdCode(m_sDriverName & ".Open")
            Dim sCommandCode2 As String = ContainerData.GetDeviceNetAppCmdCode(m_sDriverName & ".Close")

            sCommandCode = sCommandCode & ",True"
            sCommandCode2 = sCommandCode2 & ",False"

            Return SendCommandToDeviceNetApp(sCommandCode) And SendCommandToDeviceNetApp(sCommandCode2)
        End Function

        Public Function Unknown() As Boolean Implements IValveDriver.Unknown
            Dim sCommandCode As String = ContainerData.GetDeviceNetAppCmdCode(m_sDriverName & ".Open")
            Dim sCommandCode2 As String = ContainerData.GetDeviceNetAppCmdCode(m_sDriverName & ".Close")

            sCommandCode = sCommandCode & ",False"
            sCommandCode2 = sCommandCode & ",False"

            Return SendCommandToDeviceNetApp(sCommandCode) And SendCommandToDeviceNetApp(sCommandCode2)
        End Function
    End Class
End Namespace