Imports RSTiApdater
Namespace Driver
    Public Class AdapterDriver
        Inherits ProxyDriverObject
        Implements IDeviceAdapter
        ''' <author>
        '''    	<name> Truc Le </name>
        '''    	<date> 2013-12-23</date>
        ''' </author>
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New(ByVal eCommunicationType As CommType, ByVal objRSTiObject As RSTiObject)
            MyBase.new(objRSTiObject.DriverName, eCommunicationType, objRSTiObject.DeviceNetType)
            Select Case eCommunicationType
                Case CommType.Kepware
                    proxyObject = New Kepware4RSTiDriver(objRSTiObject.DriverName)
                Case CommType.DeviceNet
                    If RobotConfigurationValues.DEVICENETAPP_VISIBLE Then
                        proxyObject = New DeviceNetAppRSTiDriver(objRSTiObject.DriverName, Convert.ToUInt16(objRSTiObject.MacID))
                    Else
                        proxyObject = New DeviceRSTiDriver(objRSTiObject.DriverName)
                    End If
                Case Else
                    AVPLib.Log.avpLogger.Error("New wrong type")
            End Select
        End Sub
#Region "Sub and function"
        ''' <author>
        '''    	<name> Truc Le </name>
        '''    	<date> 2013-12-23</date>
        ''' </author>
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Public Function TurnBitOff(ByVal strDriverName As String) As Boolean Implements IDeviceAdapter.TurnBitOff
            If (proxyObject IsNot Nothing) Then
                Return CType(proxyObject, IDeviceAdapter).TurnBitOff(strDriverName)
            End If
        End Function
        ''' <author>
        '''    	<name> Truc Le </name>
        '''    	<date> 2013-12-23</date>
        ''' </author>
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Public Function TurnBitOn(ByVal strDriverName As String) As Boolean Implements IDeviceAdapter.TurnBitOn
            If (proxyObject IsNot Nothing) Then
                Return CType(proxyObject, IDeviceAdapter).TurnBitOn(strDriverName)
            End If
        End Function
        ''' <author>
        '''    	<name> Truc Le </name>
        '''    	<date> 2013-12-23</date>
        ''' </author>
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub AddChannelRSTi(ByVal objRSTi As RSTiObject) Implements IDeviceAdapter.AddChannelRSTi
            If (proxyObject IsNot Nothing) Then
                CType(proxyObject, IDeviceAdapter).AddChannelRSTi(objRSTi)
            End If
        End Sub
        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2013-12-27</date>
        ''' </author>
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub AddAdapterInfoRSTi(ByVal objRSTiAdapterInfo As RSTIAdapterInfo, ByVal objPumpPackageList As Hashtable) Implements IDeviceAdapter.AddAdapterInfoRSTi
            If (proxyObject IsNot Nothing) Then
                CType(proxyObject, IDeviceAdapter).AddAdapterInfoRSTi(objRSTiAdapterInfo, objPumpPackageList)
            End If
        End Sub
        ''' <author>
        '''    	<name> Truc Le </name>
        '''    	<date> 2013-12-23</date>
        ''' </author>
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Public Function SetValue(ByVal value As Double, ByVal sDriverName As String) As Boolean Implements IDeviceAdapter.SetValue
            If (proxyObject IsNot Nothing) Then
                Return CType(proxyObject, IDeviceAdapter).SetValue(value, sDriverName)
            End If
        End Function
#End Region
    End Class
End Namespace
