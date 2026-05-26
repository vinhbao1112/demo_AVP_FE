Namespace Driver
    Public Class SerialIGDriver
        Inherits DriverObject
        Implements IIGDriver
        Public Sub New(ByVal sDriverName As String)
            MyBase.new(sDriverName)
        End Sub
        Public ReadOnly Property IGPressure() As Single Implements IIGDriver.IGPressure
            Get
                Return -1
            End Get
        End Property
        Public Function SwitchIGFilament1() As Boolean Implements IIGDriver.SwitchIGFilament1
            Return True
        End Function
        Public Function SwitchIGFilament2() As Boolean Implements IIGDriver.SwitchIGFilament2
            Return True
        End Function
        Public Function TurnOnIG() As Boolean Implements IIGDriver.TurnOnIG
            Return True
        End Function
        Public Function TurnOffIG() As Boolean Implements IIGDriver.TurnOffIG
            Return True
        End Function
        Public Function TurnOnIGDegas() As Boolean Implements IIGDriver.TurnOnIGDegas
            Return True
        End Function
        Public Function TurnOffIGDegas() As Boolean Implements IIGDriver.TurnOffIGDegas
            Return True
        End Function
    End Class
End Namespace