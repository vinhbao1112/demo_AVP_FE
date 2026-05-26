Namespace Driver

    ''' <summary>
    ''' IPumpPackageDriver is interface for controlling Cryo and Turbo
    ''' </summary>
    Public Interface IPumpPackageDriver
        Function TurnOn() As Boolean
        Function TurnOff() As Boolean
#Region "Cryo functions"
        Function StartRegen() As Boolean
        Function StartFastRegen() As Boolean
        Function StopRegen() As Boolean
        Function CryoSetPumpRestartDelay(ByVal strVal As String) As Boolean
        Function CryoSetExtendedPurgeTime(ByVal strVal As String) As Boolean
        Function CryoSetRepurgeCycles(ByVal strVal As String) As Boolean
        Function CryoSetRoughToPressure(ByVal strVal As String) As Boolean
        Function CryoSetRateOfRise(ByVal strVal As String) As Boolean
        Function CryoSetStartUpTemp(ByVal strVal As String) As Boolean
#End Region
    End Interface
End Namespace
