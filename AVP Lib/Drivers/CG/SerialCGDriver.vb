Namespace Driver
    Public Class SerialCGDriver
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