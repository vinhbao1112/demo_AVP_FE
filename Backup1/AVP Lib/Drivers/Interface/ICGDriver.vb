Namespace Driver
    Public Interface ICGDriver
        ReadOnly Property CGPressure() As Single
        ReadOnly Property CGRelay() As DataManagerment.Equipment.WorkingStatuses
        Function SetValue(ByVal strCmd As String) As Boolean
    End Interface
End Namespace
