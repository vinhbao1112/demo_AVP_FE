Namespace Driver
    Public Class VentValveDriver
        Inherits ProxyDriverObject
        Implements IValveDriver

        Public Sub New(ByVal sDriverName As String, _
                        ByVal eCommunicationType As CommType, _
                        ByVal eDeviceType As DeviceType, _
                        ByVal iMacID As String, _
                        ByVal bitIndex As String)
            MyBase.new(sDriverName, eCommunicationType, eDeviceType)
            Select Case eCommunicationType
                Case CommType.DeviceNet
                    If RobotConfigurationValues.DEVICENETAPP_VISIBLE Then
                        proxyObject = New DeviceNetAppVentDriver(sDriverName, Convert.ToUInt16(iMacID))
                    Else
                        proxyObject = New DeviceNetVentValveDriver(sDriverName, iMacID, Convert.ToUInt16(bitIndex) - 1)
                    End If
                Case Else
                    AVPLib.Log.avpLogger.Error("New wrong type")
            End Select
        End Sub
        Public Sub New(ByVal sDriverName As String, _
                        ByVal eCommunicationType As CommType, _
                        ByVal eDeviceType As DeviceType)
            MyBase.new(sDriverName, eCommunicationType, eDeviceType)
            Select Case eCommunicationType
                Case CommType.Kepware
                    proxyObject = New KepwareVentValveDriver(sDriverName)
                Case CommType.Serial
                    proxyObject = New SerialVentValveDriver(sDriverName)
                Case Else
                    AVPLib.Log.avpLogger.Error("New wrong type")
            End Select
        End Sub
        Public Function OpenVentValve() As Boolean Implements IValveDriver.Open
            AVPLib.Log.avpLogger.Info("Enter VentValveDriver.OpenVentValve")
            Dim blResult As Boolean = False
            Try
                If (proxyObject IsNot Nothing) Then
                    blResult = CType(proxyObject, IValveDriver).Open
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
            AVPLib.Log.avpLogger.Info("Leave VentValveDriver.OpenVentValve")
            Return blResult
        End Function
        Public Function CloseVentValve() As Boolean Implements IValveDriver.Close
            AVPLib.Log.avpLogger.Info("Enter VentValveDriver.OpenVentValve")
            Dim blResult As Boolean = False
            Try
                If (proxyObject IsNot Nothing) Then
                    blResult = CType(proxyObject, IValveDriver).Close
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
            AVPLib.Log.avpLogger.Info("Leave VentValveDriver.OpenVentValve")
            Return blResult
        End Function
        Public Function UnknownVentValve() As Boolean Implements IValveDriver.Unknown
            Return True
        End Function
    End Class
End Namespace
