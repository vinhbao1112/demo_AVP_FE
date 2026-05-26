Namespace Driver
    Public Class SerialTurboForeLineValveDriver
        Inherits DriverObject
        Implements IValveDriver
        Public Sub New(ByVal sDriverName As String)
            MyBase.new(sDriverName)
        End Sub

        Public Function OpenValve() As Boolean Implements IValveDriver.Open

        End Function
        Public Function CloseValve() As Boolean Implements IValveDriver.Close

        End Function
        Public Function UnknownValve() As Boolean Implements IValveDriver.Unknown

        End Function
    End Class
    Public Class SerialTurboForeLineDriver
        Inherits DriverObject
        Implements ICGDriver
        Public Sub New(ByVal sDriverName As String)
            MyBase.new(sDriverName)
        End Sub

        Public ReadOnly Property CGPressure() As Single Implements ICGDriver.CGPressure
            Get

            End Get
        End Property
        Public ReadOnly Property CGRelay() As DataManagerment.Equipment.WorkingStatuses Implements ICGDriver.CGRelay
            Get

            End Get
        End Property
        Public Function SetValue(ByVal strCmd As String) As Boolean Implements ICGDriver.SetValue

        End Function
    End Class
End Namespace

