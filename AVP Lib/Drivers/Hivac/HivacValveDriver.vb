Namespace Driver
    Public Class HivacValveDriver
        Inherits ProxyDriverObject
        Implements IValveDriver
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' New DeviceNet Driver and add to hash table
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
                        proxyObject = New DeviceNetAppHivacDriver(sDriverName, Convert.ToUInt16(iMacID))
                    Else
                        proxyObject = New DeviceNetHivacDriver(sDriverName, iMacID, Convert.ToUInt16(bitIndex) - 1)
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
        ''' New for Serial and kepware
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New(ByVal sDriverName As String, _
                        ByVal eCommunicationType As CommType, _
                        ByVal eDeviceType As DeviceType)
            MyBase.new(sDriverName, eCommunicationType, eDeviceType)
            Select Case eCommunicationType
                Case CommType.Kepware
                    proxyObject = New KepwareHivacDriver(sDriverName)
                Case CommType.Serial
                    proxyObject = New SerialHivacDriver(sDriverName)
                Case Else
                    AVPLib.Log.avpLogger.Error("New wrong type")
            End Select
        End Sub
        Public Function OpenHivacValve() As Boolean Implements IValveDriver.Open
            AVPLib.Log.avpLogger.Info("Enter HivacValveDriver.OpenHivacValve")
            Dim blResult As Boolean = False
            Try
                If (proxyObject IsNot Nothing) Then
                    blResult = CType(proxyObject, IValveDriver).Open
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
            AVPLib.Log.avpLogger.Info("Leave HivacValveDriver.OpenHivacValve")
            Return blResult
        End Function
        Public Function CloseHivacValve() As Boolean Implements IValveDriver.Close
            AVPLib.Log.avpLogger.Info("Enter HivacValveDriver.CloseHivacValve")
            Dim blResult As Boolean = False
            Try
                If (proxyObject IsNot Nothing) Then
                    blResult = CType(proxyObject, IValveDriver).Close
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
            AVPLib.Log.avpLogger.Info("Leave HivacValveDriver.CloseHivacValve")
            Return blResult
        End Function
        Public Function UnknownHivacValve() As Boolean Implements IValveDriver.Unknown
            Return True
        End Function
    End Class
End Namespace
