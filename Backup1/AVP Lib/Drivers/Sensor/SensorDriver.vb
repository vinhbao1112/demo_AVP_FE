Namespace Driver
    Public Class SensorDriver
        Inherits ProxyDriverObject
        Implements IValveDriver
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' Only used for new device net object
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New(ByVal sDriverName As String, _
                        ByVal eCommunicationType As CommType, _
                        ByVal eDeviceType As DeviceType, ByVal sMacID As String)
            MyBase.new(sDriverName, eCommunicationType, eDeviceType)
            Select Case eCommunicationType
                Case CommType.DeviceNet
                    proxyObject = New DeviceNetSensorDriver(sDriverName, sMacID)
                Case Else
                    AVPLib.Log.avpLogger.Info("Init wrong object type")
            End Select
        End Sub
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' Only used for new serial and kepware object
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New(ByVal sDriverName As String, _
                                ByVal eCommunicationType As CommType, _
                                ByVal eDeviceType As DeviceType)
            MyBase.new(sDriverName, eCommunicationType, eDeviceType)
            Select Case eCommunicationType
                Case CommType.DeviceNet
                    AVPLib.Log.avpLogger.Info("Init wrong object type")
                Case CommType.Kepware
                    proxyObject = New KepwareSensorDriver(sDriverName)
                Case CommType.Serial
                    proxyObject = New SerialSensorDriver(sDriverName)
            End Select
        End Sub

        Public Function OpenSensor() As Boolean Implements IValveDriver.Open
            Return CType(proxyObject, IValveDriver).Open
        End Function
        Public Function CloseSensor() As Boolean Implements IValveDriver.Close
            Return CType(proxyObject, IValveDriver).Close
        End Function
        Public Function UnknownSensor() As Boolean Implements IValveDriver.Unknown
            Return CType(proxyObject, IValveDriver).Unknown
        End Function
    End Class
End Namespace
