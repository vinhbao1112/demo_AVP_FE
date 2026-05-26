Namespace Driver
    Public Class DeviceNetAppTurboForeLineValveDriver
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

    Public Class DeviceNetAppTurboForeLineDriver
        Inherits DeviceNetAppDriver
        Implements ICGDriver

        ''' <summary>
        ''' New object TurboForeLine device net
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

        Public Overridable Function SetValue(ByVal strCmd As String) As Boolean Implements ICGDriver.SetValue
            Dim bResult As Boolean = False
            Try
                Dim sCommandCode As String = ContainerData.GetDeviceNetAppCmdCode(m_sDriverName)
                sCommandCode = sCommandCode & strCmd & ",true"

                bResult = SendCommandToDeviceNetApp(sCommandCode)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
            Return bResult
        End Function

        Public ReadOnly Property CGPressure() As Single Implements ICGDriver.CGPressure
            Get

            End Get
        End Property

        Public ReadOnly Property CGRelay() As DataManagerment.Equipment.WorkingStatuses Implements ICGDriver.CGRelay
            Get

            End Get
        End Property
    End Class
End Namespace