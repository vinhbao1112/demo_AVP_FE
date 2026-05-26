Namespace Driver
    Public Class SerialVentValveDriver
        Inherits DriverObject
        Implements IValveDriver
        Public Sub New(ByVal sDriverName As String)
            MyBase.new(sDriverName)
        End Sub
        Public Function OpenVentValve() As Boolean Implements IValveDriver.Open
            Return False
        End Function
        Public Function CloseVentValve() As Boolean Implements IValveDriver.Close
            Return False
        End Function
        Public Function UnknownVentValve() As Boolean Implements IValveDriver.Unknown
            Return False
        End Function
    End Class
End Namespace

