Namespace Driver
    Public Class SerialRoughValveDriver
        Inherits DriverObject
        Implements IValveDriver
        Public Sub New(ByVal sDriverName As String)
            MyBase.new(sDriverName)
        End Sub
        Public Function OpenRoughValve() As Boolean Implements IValveDriver.Open
            Return False
        End Function
        Public Function CloseRoughValve() As Boolean Implements IValveDriver.Close
            Return False
        End Function
        Public Function UnknownRoughValve() As Boolean Implements IValveDriver.Unknown
            Return False
        End Function
    End Class
End Namespace

