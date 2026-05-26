Namespace Driver
    Public Class IsolationValveDriver
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
                        ByVal bitIndex As String, _
                        Optional ByVal CloseBitIndex As String = "")
            MyBase.new(sDriverName, eCommunicationType, eDeviceType)
            Select Case eCommunicationType
                Case CommType.DeviceNet
                    If RobotConfigurationValues.DEVICENETAPP_VISIBLE Then
                        proxyObject = New DeviceNetAppIsolationValveDriver(sDriverName, Convert.ToUInt16(iMacID))
                    Else
                        proxyObject = New DeviceNetIsolationValveDriver(sDriverName, iMacID, Convert.ToUInt16(bitIndex) - 1, Convert.ToUInt16(CloseBitIndex) - 1)
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
                    proxyObject = New KepwareIsolationValveDriver(sDriverName)
                Case CommType.Serial
                    proxyObject = New SerialIsolationValveDriver(sDriverName)
                Case Else
                    AVPLib.Log.avpLogger.Error("New wrong type")
            End Select
        End Sub
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' New DeviceNet Driver and add to hash table
        ''' </summary>
        ''' <remarks></remarks>
        Public Function OpenIsolationValve() As Boolean Implements IValveDriver.Open
            AVPLib.Log.avpLogger.Info("Enter IsolationValveDriver.OpenRoughValve")
            Dim blResult As Boolean = False
            Try
                If (proxyObject IsNot Nothing) Then
                    blResult = CType(proxyObject, IValveDriver).Open
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
            AVPLib.Log.avpLogger.Info("Leave IsolationValveDriver.OpenRoughValve")
            Return blResult
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' New DeviceNet Driver and add to hash table
        ''' </summary>
        ''' <remarks></remarks>
        Public Function CloseIsolationValve() As Boolean Implements IValveDriver.Close
            AVPLib.Log.avpLogger.Info("Enter IsolationValveDriver.CloseIsolationValve")
            Dim blResult As Boolean = False
            Try
                If (proxyObject IsNot Nothing) Then
                    blResult = CType(proxyObject, IValveDriver).Close
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
            AVPLib.Log.avpLogger.Info("Leave IsolationValveDriver.CloseIsolationValve")
            Return blResult
        End Function
        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2014-05-21</date>
        ''' </author>
        ''' <summary>
        ''' New DeviceNet Driver and add to hash table
        ''' </summary>
        ''' <remarks></remarks>
        Public Function UnknownIsolationValve() As Boolean Implements IValveDriver.Unknown
            AVPLib.Log.avpLogger.Info("Enter IsolationValveDriver.UnknownIsolationValve")
            Dim blResult As Boolean = False
            Try
                If (proxyObject IsNot Nothing) Then
                    blResult = CType(proxyObject, IValveDriver).Unknown
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
            AVPLib.Log.avpLogger.Info("Leave IsolationValveDriver.UnknownIsolationValve")
            Return blResult
        End Function
    End Class
End Namespace
