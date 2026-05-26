Namespace Driver
    Public Interface IIGDriver
        ReadOnly Property IGPressure() As Single
        Function SwitchIGFilament1() As Boolean
        Function SwitchIGFilament2() As Boolean
        Function TurnOnIG() As Boolean
        Function TurnOffIG() As Boolean
        Function TurnOnIGDegas() As Boolean
        Function TurnOffIGDegas() As Boolean
    End Interface
End Namespace