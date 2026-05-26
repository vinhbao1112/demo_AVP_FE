Imports AVPLib.ConstEnum
Imports AVPLib.Driver.DriverConst
Namespace Driver
    Public Class TurboForeLineValveDriver
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
                        ByVal eDeviceType As DeviceType, _
                        ByVal iMacID As String, _
                        ByVal bitIndex As String)
            MyBase.new(sDriverName, eCommunicationType, eDeviceType)
            Select Case eCommunicationType
                Case CommType.DeviceNet
                    If RobotConfigurationValues.DEVICENETAPP_VISIBLE Then
                        proxyObject = New DeviceNetAppTurboForeLineValveDriver(sDriverName, Convert.ToUInt16(iMacID))
                    Else
                        proxyObject = New DeviceNetTurboForeLineValveDriver(sDriverName, iMacID, Convert.ToUInt16(bitIndex) - 1)
                    End If
                Case Else
                    AVPLib.Log.avpLogger.Error("New wrong type")
            End Select
        End Sub
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' Only used for new serial and kepware
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New(ByVal sDriverName As String, _
                        ByVal eCommunicationType As CommType, _
                        ByVal eDeviceType As DeviceType)
            MyBase.new(sDriverName, eCommunicationType, eDeviceType)
            Select Case eCommunicationType
                Case CommType.Kepware
                    proxyObject = New KepwareTurboForeLineValveDriver(sDriverName)
                Case CommType.Serial
                    proxyObject = New SerialTurboForeLineValveDriver(sDriverName)
                Case Else
                    AVPLib.Log.avpLogger.Error("New wrong type")
            End Select
        End Sub
        Public Function OpenTurboForeLineValve() As Boolean Implements IValveDriver.Open
            AVPLib.Log.avpLogger.Info("Enter TurboForeLineDriver.OpenTurboForeLineValve")
            Dim blResult As Boolean = False
            Try
                If (proxyObject IsNot Nothing) Then
                    blResult = CType(proxyObject, IValveDriver).Open
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
            AVPLib.Log.avpLogger.Info("Leave TurboForeLineDriver.OpenTurboForeLineValve")
            Return blResult
        End Function
        Public Function CloseTurboForeLineValve() As Boolean Implements IValveDriver.Close
            AVPLib.Log.avpLogger.Info("Enter TurboForeLineDriver.OpenTurboForeLineValve")
            Dim blResult As Boolean = False
            Try
                If (proxyObject IsNot Nothing) Then
                    blResult = CType(proxyObject, IValveDriver).Close
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
            AVPLib.Log.avpLogger.Info("Leave TurboForeLineDriver.OpenTurboForeLineValve")
            Return blResult
        End Function
        Public Function UnknownTurboForeLineValve() As Boolean Implements IValveDriver.Unknown
            Return True
        End Function
    End Class
    Public Class TurboForeLineDriver
        Inherits ProxyDriverObject
        Implements ICGDriver

        Protected m_MacID As Single = 0
        Public Sub New(ByVal sDriverName As String, _
                        ByVal eCommunicationType As CommType, _
                        ByVal eDeviceType As DeviceType)
            MyBase.new(sDriverName, eCommunicationType, eDeviceType)
            Select Case eCommunicationType

                Case CommType.Serial
                    proxyObject = New SerialTurboForeLineDriver(sDriverName)
                Case CommType.Kepware
                    proxyObject = New KepwareTurboForeLineDriver(sDriverName)
                Case Else
                    'Error
            End Select
        End Sub
        Public Sub New(ByVal sDriverName As String, _
                        ByVal eCommunicationType As CommType, _
                        ByVal eDeviceType As DeviceType, ByVal sMacID As String)
            MyBase.new(sDriverName, eCommunicationType, eDeviceType)
            Select Case eCommunicationType
                Case CommType.DeviceNet
                    If RobotConfigurationValues.DEVICENETAPP_VISIBLE Then
                        proxyObject = New DeviceNetAppTurboForeLineDriver(sDriverName, sMacID)
                    Else
                        proxyObject = New DeviceNetTurboForeLineDriver(sDriverName, sMacID)
                        If (sDriverName = CassettesModule_TurboForelineCG) Then
                            CType(proxyObject, DeviceNetTurboForeLineDriver).TripPointValue = (AVPLib.ContainerData.GetCGConfig(TM_TURBO_CG_TRIP_POINT).ToString())
                        ElseIf (sDriverName = LoadLockA_TurboForelineCG) Then
                            CType(proxyObject, DeviceNetTurboForeLineDriver).TripPointValue = (AVPLib.ContainerData.GetCGConfig(LLA_TURBO_CG_TRIP_POINT).ToString())
                        End If
                    End If
                Case Else
                    'Error
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
