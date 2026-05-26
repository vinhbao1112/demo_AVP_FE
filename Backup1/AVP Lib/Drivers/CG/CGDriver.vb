Imports AVPLib.ConstEnum
Imports AVPLib.Driver.DriverConst
Namespace Driver
    Public Class CGDriver
        Inherits ProxyDriverObject
        Implements ICGDriver

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' Initialize All Driver
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New(ByVal sDriverName As String, _
                        ByVal eCommunicationType As CommType, _
                        ByVal eDeviceType As DeviceType)
            MyBase.new(sDriverName, eCommunicationType, eDeviceType)
            Select Case eCommunicationType
                Case CommType.Serial
                    proxyObject = New SerialCGDriver(sDriverName)
                Case CommType.Kepware
                    proxyObject = New KepwareCGDriver(sDriverName)
                Case Else
                    AVPLib.Log.avpLogger.Error("New Wrong Object Type")
            End Select
        End Sub
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
                        ByVal eDeviceType As DeviceType, _
                        ByVal sMacID As String)
            MyBase.new(sDriverName, eCommunicationType, eDeviceType)
            Select Case eCommunicationType
                Case CommType.DeviceNet
                    If RobotConfigurationValues.DEVICENETAPP_VISIBLE Then
                        proxyObject = New DeviceNetAppCGDriver(sDriverName, Convert.ToUInt16(sMacID))
                    Else
                        proxyObject = New DNSGP275ConvectionGauge(sDriverName, Convert.ToUInt16(sMacID))
                        If sDriverName = CassettesModule_CG Then
                            CType(proxyObject, DNSGP275ConvectionGauge).TripPointValue = (AVPLib.ContainerData.GetCGConfig(TM_CG_TRIP_POINT).ToString())
                        ElseIf (sDriverName = LoadLockA_CG) Then
                            CType(proxyObject, DNSGP275ConvectionGauge).TripPointValue = (AVPLib.ContainerData.GetCGConfig(LLA_CG_TRIP_POINT).ToString())
                        End If

                    End If
                Case Else
                    AVPLib.Log.avpLogger.Error("New Wrong Object Type")
            End Select
        End Sub

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
                        ByVal eDeviceType As DeviceType, ByVal sMacID As String, _
                        ByVal eDeviceNetIGType As DeviceNetIGCGType)
            MyBase.new(sDriverName, eCommunicationType, eDeviceType)
            Select Case eCommunicationType
                Case CommType.DeviceNet
                    If (eDeviceNetIGType = DeviceNetIGCGType.GP275) Then
                        proxyObject = New DNSGP275ConvectionGauge(sDriverName, Convert.ToUInt16(sMacID))
                    Else
                        AVPLib.Log.avpLogger.Error("Not Implement yet")
                    End If

                Case Else
                    AVPLib.Log.avpLogger.Error("New Wrong Object Type")
            End Select
        End Sub

        Public ReadOnly Property CGPressure() As Single Implements ICGDriver.CGPressure
            Get
                Return CType(proxyObject, ICGDriver).CGPressure
            End Get
        End Property

        Public ReadOnly Property CGRelay() As DataManagerment.Equipment.WorkingStatuses Implements ICGDriver.CGRelay
            Get
                Return CType(proxyObject, ICGDriver).CGRelay
            End Get
        End Property

        Public Function SetValue(ByVal strCmd As String) As Boolean Implements ICGDriver.SetValue
            Return CType(proxyObject, ICGDriver).SetValue(strCmd)
        End Function
    End Class
End Namespace
