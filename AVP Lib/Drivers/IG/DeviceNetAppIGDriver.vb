Namespace Driver
    Public Class DeviceNetAppIGDriver
        Inherits DeviceNetAppDriver
        Implements IIGDriver

        Private m_strCmdIGOnOff As String = "FilamentOnOff"
        Private m_strCmdIGDegasOnOff As String = "IGDegasOnOff"
        Private m_strCmdIGSelectFilament = "IGSelectFilament"

        ''' <summary>
        ''' New object IG device net
        ''' default IG device net type is GP 354
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

        ''' <summary>
        ''' Switch IG Filament 1
        ''' </summary>
        Public Overridable Function SwitchIGFilament1() As Boolean Implements IIGDriver.SwitchIGFilament1
            Dim sCommandCode As String = ContainerData.GetDeviceNetAppCmdCode(m_sDriverName & "." & m_strCmdIGSelectFilament)
            sCommandCode = sCommandCode & ",1"

            Return SendCommandToDeviceNetApp(sCommandCode)
        End Function

        ''' <summary>
        ''' Switch IG Filament 2
        ''' </summary>
        Public Overridable Function SwitchIGFilament2() As Boolean Implements IIGDriver.SwitchIGFilament2
            Dim sCommandCode As String = ContainerData.GetDeviceNetAppCmdCode(m_sDriverName & "." & m_strCmdIGSelectFilament)
            sCommandCode = sCommandCode & ",2"

            Return SendCommandToDeviceNetApp(sCommandCode)
        End Function

        ''' <summary>
        ''' Turn IG On
        ''' </summary>
        ''' <param name="bOn"></param>
        Public Overridable Function TurnIGOn() As Boolean Implements IIGDriver.TurnOnIG
            Dim sCommandCode As String = ContainerData.GetDeviceNetAppCmdCode(m_sDriverName & "." & m_strCmdIGOnOff)
            sCommandCode = sCommandCode & ",True"

            Return SendCommandToDeviceNetApp(sCommandCode)
        End Function
        ''' <summary>
        ''' Turn IG On
        ''' </summary>
        ''' <param name="bOn"></param>
        Public Overridable Function TurnIGOff() As Boolean Implements IIGDriver.TurnOffIG
            Dim sCommandCode As String = ContainerData.GetDeviceNetAppCmdCode(m_sDriverName & "." & m_strCmdIGOnOff)
            sCommandCode = sCommandCode & ",False"

            Return SendCommandToDeviceNetApp(sCommandCode)
        End Function
        ''' <summary>
        ''' Turn IG On
        ''' </summary>
        ''' <param name="bOn"></param>
        Public Overridable Function TurnIGDegasOn() As Boolean Implements IIGDriver.TurnOnIGDegas
            Dim sCommandCode As String = ContainerData.GetDeviceNetAppCmdCode(m_sDriverName & "." & m_strCmdIGDegasOnOff)
            sCommandCode = sCommandCode & ",True"

            Return SendCommandToDeviceNetApp(sCommandCode)
        End Function
        ''' <summary>
        ''' Turn IG On
        ''' </summary>
        ''' <param name="bOn"></param>
        Public Overridable Function TurnIGDegasOff() As Boolean Implements IIGDriver.TurnOffIGDegas
            Dim sCommandCode As String = ContainerData.GetDeviceNetAppCmdCode(m_sDriverName & "." & m_strCmdIGDegasOnOff)
            sCommandCode = sCommandCode & ",False"

            Return SendCommandToDeviceNetApp(sCommandCode)
        End Function

        Public ReadOnly Property IGPressure() As Single Implements IIGDriver.IGPressure
            Get

            End Get
        End Property
    End Class

End Namespace
