Namespace Driver
    Public Class SerialIsolationValveDriver
        Inherits DriverObject
        Implements IValveDriver
        Public Sub New(ByVal sDriverName As String)
            MyBase.new(sDriverName)
        End Sub
        Public Function OpenIsolationValve() As Boolean Implements IValveDriver.Open
            Return False
        End Function
        Public Function CloseIsolationValve() As Boolean Implements IValveDriver.Close
            Return False
        End Function
        Public Function UnknownIsolationValve() As Boolean Implements IValveDriver.Unknown
            Return False
        End Function
    End Class
End Namespace

