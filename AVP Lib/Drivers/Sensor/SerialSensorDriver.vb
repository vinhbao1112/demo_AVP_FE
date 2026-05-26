Namespace Driver
    Public Class SerialSensorDriver
        Inherits DriverObject
        Implements IValveDriver
        Public Sub New(ByVal sDriverName As String)
            MyBase.new(sDriverName)
        End Sub
        Public Function OpenSensor() As Boolean Implements IValveDriver.Open
            Return False
        End Function
        Public Function CloseSensor() As Boolean Implements IValveDriver.Close
            Return False
        End Function
        Public Function UnknownSensor() As Boolean Implements IValveDriver.Unknown
            Return False
        End Function
    End Class
End Namespace

