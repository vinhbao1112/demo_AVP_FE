Imports AVPLib.ConstEnum
Imports AVPLib.Driver.DriverConst
Namespace Driver
    Public Class MPumpCGDriver
        Inherits ProxyDriverObject
        Implements ICGDriver

        Public Sub New(ByVal sDriverName As String, _
                        ByVal eCommunicationType As CommType, _
                        ByVal eDeviceType As DeviceType, Optional ByVal sMacID As String = "")
            MyBase.new(sDriverName, eCommunicationType, eDeviceType)
            Select Case eCommunicationType
                Case CommType.DeviceNet
                    If RobotConfigurationValues.DEVICENETAPP_VISIBLE Then
                        proxyObject = New DeviceNetAppMPumpCGDriver(sDriverName, Convert.ToUInt16(sMacID))
                    Else
                        proxyObject = New DeviceNetMPumpCGDriver(sDriverName, sMacID)
                        If sDriverName = RoughPumpMachine1_CG OrElse sDriverName = RoughPumpMachine2_CG Then
                            CType(proxyObject, DeviceNetMPumpCGDriver).TripPointValue = (AVPLib.ContainerData.GetCGConfig(MP_CG_TRIP_POINT).ToString())
                        End If
                    End If
                Case CommType.Kepware
                    proxyObject = New KepwareMPumpCGDriver(sDriverName)
                Case CommType.Serial
                    proxyObject = New SerialMPumpCGDriver(sDriverName)
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
