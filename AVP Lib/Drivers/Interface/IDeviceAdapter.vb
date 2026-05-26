Imports RSTiApdater
Namespace Driver
    Public Interface IDeviceAdapter
        Function TurnBitOn(ByVal strDriverName As String) As Boolean
        Function TurnBitOff(ByVal strDriverName As String) As Boolean
        Function SetValue(ByVal value As Double, ByVal sDriverName As String) As Boolean
        Sub AddChannelRSTi(ByVal objRSTi As RSTiObject)
        Sub AddAdapterInfoRSTi(ByVal objRSTiAdapterInfo As RSTIAdapterInfo, ByVal objPumpPackageList As Hashtable)
    End Interface
End Namespace