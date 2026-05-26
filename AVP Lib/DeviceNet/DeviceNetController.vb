Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Runtime.InteropServices

Namespace DeviceNet
#Region "STRUCT DEFINE"
    <StructLayout(LayoutKind.Sequential)> _
    Public Class DeviceConfiguration
        Public MacId As UShort = 0
        Public VendorId As UShort = 0
        Public DeviceType As UShort = 0
        Public ProductCode As UShort = 0
        Public ProductionInhibitTime As UShort = 0
        Public Reserved2 As UShort = 0
        Public Reserved3 As UShort = 0
        Public Flags As UShort = 0
        Public ExplicitSize As UShort = 0
        Public ExplicitOffset As UShort = 0
        Public Io1Interval As UShort = 0
        Public Output1Size As UShort = 0
        Public Output1Offset As UShort = 0
        Public Output1LocalPathOffset As UShort = 0
        Public Output1RemotePathOffset As UShort = 0
        Public Input1Size As UShort = 0
        Public Input1Offset As UShort = 0
        Public Input1LocalPathOffset As UShort = 0
        Public Input1RemotePathOffset As UShort = 0
        Public Io2Interval As UShort = 0
        Public Output2Size As UShort = 0
        Public Output2Offset As UShort = 0
        Public Output2LocalPathOffset As UShort = 0
        Public Output2RemotePathOffset As UShort = 0
        Public Input2Size As UShort = 0
        Public Input2Offset As UShort = 0
        Public Input2LocalPathOffset As UShort = 0
        Public Input2RemotePathOffset As UShort = 0
        Public Sub New()
        End Sub
    End Class

    <StructLayout(LayoutKind.Sequential)> _
    Public Class ScannerConfiguration
        Public MacId As UShort = 0
        Public BaudRate As UShort = 0
        Public ScanInterval As UShort = 0
        Public ReconnectTime As UShort = 0
        Public Flags As UShort = 0
        Public ExplicitRequestSize As UShort = 0
        Public ExplicitRequestOffset As UShort = 0
        Public ExplicitResponseSize As UShort = 0
        Public ExplicitResponseOffset As UShort = 0
        Public Io1Interval As UShort = 0
        Public Output1Size As UShort = 0
        Public Output1Offset As UShort = 0
        Public Output1LocalPathOffset As UShort = 0
        Public Input1Size As UShort = 0
        Public Input1Offset As UShort = 0
        Public Input1LocalPathOffset As UShort = 0
        Public Io2Interval As UShort = 0
        Public Output2Size As UShort = 0
        Public Output2Offset As UShort = 0
        Public Output2LocalPathOffset As UShort = 0
        Public Input2Size As UShort = 0
        Public Input2Offset As UShort = 0
        Public Input2LocalPathOffset As UShort = 0
        Public Sub New()
        End Sub
    End Class
    <StructLayout(LayoutKind.Sequential)> _
    Public Class DeviceNetStatus
        Public StatusCode As Byte = 0
        Public StatusFlags As Byte = 0
        Public Sub New()
        End Sub
    End Class
#End Region

    Public Class DeviceNetController
#Region "API FUNCTION IMPORT"
        <DllImport("dnscan32.dll", SetLastError:=True)> _
        Private Shared Function DNS_AddDevice(ByVal CardHandle As Integer, <[In](), MarshalAs(UnmanagedType.LPStruct)> ByVal DeviceCfg As DeviceConfiguration) As Integer
        End Function

        <DllImport("dnscan32.dll", SetLastError:=True)> _
        Private Shared Function DNS_CloseCard(ByVal CardHandle As Integer) As Integer
        End Function

        <DllImport("dnscan32.dll", SetLastError:=True)> _
        Private Shared Function DNS_DeleteDevice(ByVal CardHandle As Integer, ByVal DeviceId As UShort) As Integer
        End Function

        <DllImport("dnscan32.dll", SetLastError:=True)> _
        Private Shared Function DNS_FreeDriver() As Integer
        End Function

        <DllImport("dnscan32.dll", SetLastError:=True)> _
        Private Shared Function DNS_GetBusStatus(ByVal CardHandle As Integer, ByRef BusStatus As UShort) As Integer
        End Function

        <DllImport("dnscan32.dll", SetLastError:=True)> _
        Private Shared Function DNS_GetDeviceEvent(ByVal CardHandle As Integer, ByVal DeviceId As UShort, ByVal EventId As Byte, ByRef DeviceEvent As Byte) As Integer
        End Function

        <DllImport("dnscan32.dll", SetLastError:=True)> _
        Private Shared Function DNS_GetDeviceStatus(ByVal CardHandle As Integer, ByVal DeviceId As UShort, <Out(), MarshalAs(UnmanagedType.LPStruct)> ByVal DeviceStatus As DeviceNetStatus) As Integer
        End Function

        <DllImport("dnscan32.dll", SetLastError:=True)> _
        Private Shared Function DNS_IoActive(ByVal CardHandle As Integer, ByVal Timeout As UShort) As Integer
        End Function

        <DllImport("dnscan32.dll", SetLastError:=True)> _
        Private Shared Function DNS_LoadDriver(<MarshalAs(UnmanagedType.LPStr)> ByVal DriverName As String) As Integer
        End Function

        <DllImport("dnscan32.dll", SetLastError:=True)> _
        Private Shared Function DNS_Offline(ByVal CardHandle As Integer) As Integer
        End Function

        <DllImport("dnscan32.dll", SetLastError:=True)> _
        Private Shared Function DNS_Online(ByVal CardHandle As Integer, <[In](), MarshalAs(UnmanagedType.LPStruct)> ByVal ScannerCfg As ScannerConfiguration) As Integer
        End Function

        <DllImport("dnscan32.dll", SetLastError:=True)> _
        Private Shared Function DNS_OpenCard(ByRef CardHandle As Integer, <MarshalAs(UnmanagedType.LPStr)> ByVal CardName As String, ByVal [Module] As Integer, ByVal Flags As Integer) As Integer
        End Function

        <DllImport("dnscan32.dll", SetLastError:=True)> _
        Private Shared Function DNS_ReadDeviceIo(ByVal CardHandle As Integer, ByVal DeviceId As UShort, ByVal IoArea As Byte, ByVal Buffer As IntPtr, ByVal Size As UShort) As Integer
        End Function

        <DllImport("dnscan32.dll", SetLastError:=True)> _
        Private Shared Function DNS_ReceiveDeviceExplicit(ByVal CardHandle As Integer, ByVal DeviceId As UShort, ByRef Service As Byte, ByVal ServiceData As IntPtr, ByRef Size As UShort) As Integer
        End Function

        <DllImport("dnscan32.dll", SetLastError:=True)> _
        Private Shared Function DNS_SendDeviceExplicit(ByVal CardHandle As Integer, ByVal DeviceId As UShort, ByVal Service As Byte, ByVal ClassId As UShort, ByVal InstanceId As UShort, ByVal Buffer As IntPtr, _
        ByVal Size As UShort) As Integer
        End Function

        <DllImport("dnscan32.dll", SetLastError:=True)> _
        Private Shared Function DNS_StartScan(ByVal CardHandle As Integer) As Integer
        End Function

        <DllImport("dnscan32.dll", SetLastError:=True)> _
        Private Shared Function DNS_StopScan(ByVal CardHandle As Integer) As Integer
        End Function

        <DllImport("dnscan32.dll", SetLastError:=True)> _
        Private Shared Function DNS_WriteDeviceIo(ByVal CardHandle As Integer, ByVal DeviceId As UShort, ByVal IoArea As Byte, ByVal Buffer As IntPtr, ByVal Size As UShort) As Integer
        End Function

        <DllImport("dnerr32.dll", SetLastError:=True)> _
        Private Shared Function DNE_CommandError(ByVal ErrorCode As Integer, <MarshalAs(UnmanagedType.LPStr)> ByVal Buffer As String, ByVal size As Integer) As Integer
        End Function
#End Region

        'DLL name
        Private m_DeviceNetDriverName As String = String.Empty
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-01</date>
        ''' </author>
        ''' <summary>
        ''' New object
        ''' </summary>
        ''' <param name=""></param>
        ''' <param name=""></param>
        ''' <remarks></remarks>
        Public Sub New()
            m_DeviceNetDriverName = String.Empty
        End Sub

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-01</date>
        ''' </author>
        ''' <summary>
        ''' Connect to device
        ''' </summary>
        ''' <param name=""></param>
        ''' <param name=""></param>
        ''' <remarks></remarks>
        Public Function LoadDeviceNetDriver(Optional ByVal DeviceNetDriverName As String = "ssdn32.dll") As [Boolean]
            AVPLib.Log.coreLogger.Info("Enter LoadDeviceNetDriver")
            Dim blResult As Boolean = False
            Try
                m_DeviceNetDriverName = DeviceNetDriverName
                Dim loadRes As Integer = DNS_LoadDriver(m_DeviceNetDriverName)
                blResult = IIf(loadRes = 0, False, True)
            Catch exception As Exception
                AVPLib.Log.coreLogger.Error(exception.Message.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave LoadDeviceNetDriver")
            Return blResult
        End Function

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-01</date>
        ''' </author>
        ''' <summary>
        ''' Unload driver
        ''' </summary>
        ''' <param name=""></param>
        ''' <param name=""></param>
        ''' <remarks></remarks>
        Public Function UnloadDeviceNetDriver() As [Boolean]
            AVPLib.Log.coreLogger.Info("Enter UnloadDeviceNetDriver")
            Dim blResult As Boolean = False
            Try
                Dim loadRes As Integer = DNS_FreeDriver()
                If (loadRes = 0) Then
                    blResult = False
                    log("UnloadDeviceNetDriver", loadRes.ToString() + " = DNS_FreeDriver() and GetLastWin32Error()=" + Marshal.GetLastWin32Error().ToString("X"))
                Else
                    blResult = True
                    log("UnloadDeviceNetDriver", loadRes.ToString() + " = DNS_FreeDriver()" )
                End If
            Catch exception As Exception
                AVPLib.Log.coreLogger.Error(exception.Message.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave UnloadDeviceNetDriver")
            Return blResult
        End Function

        ''' <summary>
        ''' Log function
        ''' </summary>
        ''' <param name="strfuncName"></param>
        ''' <param name="strMsg"></param>
        Private Shared Sub log(ByVal strfuncName As String, ByVal strMsg As String)
            AVPLib.Log.coreLogger.Error(strfuncName & ": " & strMsg)
        End Sub

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-01</date>
        ''' </author>
        ''' <summary>
        ''' Add driver
        ''' </summary>
        ''' <param name=""></param>
        ''' <param name=""></param>
        ''' <remarks></remarks>
        Public Function AddDevice(ByVal CardHandle As Integer, ByVal dc As DeviceConfiguration) As Boolean
            AVPLib.Log.coreLogger.Info("Enter AddDevice")
            Dim blResult As Boolean = False
            Try
                Dim addRes As Integer = DNS_AddDevice(CardHandle, dc)
                If addRes = 0 Then
                    Dim iLastErr As Integer = Marshal.GetLastWin32Error()
                    If iLastErr = 536871437 Then
                        log("AddDevice", addRes.ToString() & " = DNS_AddDevice(" & _
                        dc.MacId.ToString() & ") and GetLastWin32Error()=" & iLastErr.ToString("X"))

                        log("AddDevice", addRes.ToString() & " = DNS_AddDevice(" & _
                        dc.MacId.ToString() & ") and ExplicitOffset=" & dc.ExplicitOffset.ToString("X"))

                    Else
                        log("AddDevice", addRes.ToString() & " = DNS_AddDevice(" & _
                        dc.MacId.ToString() & ") and GetLastWin32Error()=" & iLastErr.ToString("X") & " CardHandle=" & CardHandle)

                    End If
                    blResult = False
                Else
                    log("AddDevice", addRes.ToString() & " = DNS_AddDevice(" & dc.MacId.ToString() & ")" & " CardHandle=" & CardHandle)
                    blResult = True
                End If
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error(ex.Message.ToString)
            End Try
            AVPLib.Log.coreLogger.Info("Leave AddDevice")
            Return blResult
        End Function

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-01</date>
        ''' </author>
        ''' <summary>
        ''' Delete Card
        ''' </summary>
        ''' <param name=""></param>
        ''' <param name=""></param>
        ''' <remarks></remarks>
        Public Function DeleteDevice(ByVal CardHandle As Integer, ByVal DeviceId As Integer) As Boolean
            AVPLib.Log.coreLogger.Info("Enter DeleteDevice")
            Dim blResult As Boolean = False
            Try
                Dim UIdeviceId As UShort = Convert.ToUInt16(DeviceId)
                Dim delRes As Integer = DNS_DeleteDevice(CardHandle, UIdeviceId)
                If delRes = 0 Then
                    log("DeleteDevice", delRes.ToString() & " = DNS_DeleteDevice(" & _
                    DeviceId.ToString() & ") and GetLastWin32Error()=" & Marshal.GetLastWin32Error().ToString("X"))
                    blResult = False
                Else
                    log("DeleteDevice", delRes.ToString() & " = DNS_DeleteDevice(" & DeviceId.ToString() & ")")
                    blResult = True
                End If
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error(ex.Message.ToString)
            End Try
            AVPLib.Log.coreLogger.Info("Leave DeleteDevice")
            Return blResult
        End Function

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-01</date>
        ''' </author>
        ''' <summary>
        ''' Open Card
        ''' </summary>
        ''' <param name=""></param>
        ''' <param name=""></param>
        ''' <remarks></remarks>
        Public Function OpenCard(ByRef CardHandle As Integer, ByVal CardName As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter OpenCard")
            Dim blResult As Boolean = False
            Try
                Dim res As Integer = DNS_OpenCard(CardHandle, CardName, 0, 0)
                If res = 0 Then
                    log("OpenCard", res.ToString() & " = DNS_OpenCard(" & _
                    CardName & ") and GetLastWin32Error()=" & Marshal.GetLastWin32Error().ToString("X") & " CardHandle=" & CardHandle)
                    blResult = False
                Else
                    log("OpenCard", res.ToString() & " = DNS_OpenCard(" & CardName & ")" & " CardHandle=" & CardHandle)
                    blResult = True
                End If
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error(ex.Message.ToString)
            End Try
            AVPLib.Log.coreLogger.Info("Leave OpenCard")
            Return blResult
        End Function

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-01</date>
        ''' </author>
        ''' <summary>
        ''' Close Card
        ''' </summary>
        ''' <param name=""></param>
        ''' <param name=""></param>
        ''' <remarks></remarks>
        Public Function CloseCard(ByVal CardHandle As Integer) As Boolean
            AVPLib.Log.coreLogger.Info("Enter CloseCard")
            Dim blResult As Boolean = False
            Try

                If CardHandle <> 0 Then
                    Dim res As Integer = DNS_CloseCard(CardHandle)
                    If res = 0 Then
                        log("CloseCard", res.ToString() & _
                        " = DNS_CloseCard() and GetLastWin32Error()=" & Marshal.GetLastWin32Error().ToString("X") & " CardHandle=" & CardHandle)
                        blResult = False
                    Else
                        log("CloseCard", res.ToString() & " = DNS_CloseCard()" & " CardHandle=" & CardHandle)
                        blResult = True
                    End If
                Else
                    log("CloseCard", "Card handle is not valid" & " CardHandle=" & CardHandle)
                    blResult = False
                End If
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error(ex.Message.ToString)
            End Try
            AVPLib.Log.coreLogger.Info("Leave CloseCard")
            Return blResult
        End Function

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-01</date>
        ''' </author>
        ''' <summary>
        ''' Start scan
        ''' </summary>
        ''' <param name=""></param>
        ''' <param name=""></param>
        ''' <remarks></remarks>
        Public Function StartScan(ByVal CardHandle As Integer) As Boolean
            AVPLib.Log.coreLogger.Info("Enter StartScan")
            Dim blResult As Boolean = False
            Try
                Dim res As Integer = DNS_StartScan(CardHandle)
                If res = 0 Then
                    log("StartScan", res.ToString() & _
                    " = DNS_StartScan() and GetLastWin32Error()=" & Marshal.GetLastWin32Error().ToString("X") & " CardHandle=" & CardHandle)
                    blResult = False
                Else
                    log("StartScan", res.ToString() & " = DNS_StartScan()" & " CardHandle=" & CardHandle)
                    blResult = True
                End If
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error(ex.Message.ToString)
            End Try
            AVPLib.Log.coreLogger.Info("Leave StartScan")
            Return blResult
        End Function

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-01</date>
        ''' </author>
        ''' <summary>
        ''' Stop scan
        ''' </summary>
        ''' <param name=""></param>
        ''' <param name=""></param>
        ''' <remarks></remarks>
        Public Function StopScan(ByVal CardHandle As Integer) As Boolean
            AVPLib.Log.coreLogger.Info("Enter StopScan")
            Dim blResult As Boolean = False
            Try
                Dim res As Integer = DNS_StopScan(CardHandle)
                If res = 0 Then
                    log("StopScan", res.ToString() & " = DNS_StopScan() and GetLastWin32Error()=" & _
                    Marshal.GetLastWin32Error().ToString("X") & " CardHandle=" & CardHandle)
                    blResult = False
                Else
                    log("StopScan", res.ToString() & " = DNS_StopScan()" & " CardHandle=" & CardHandle)
                    blResult = True
                End If
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error(ex.Message.ToString)
            End Try
            AVPLib.Log.coreLogger.Info("Leave StopScan")
            Return blResult
        End Function

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-01</date>
        ''' </author>
        ''' <summary>
        ''' Make current online
        ''' </summary>
        ''' <param name=""></param>
        ''' <param name=""></param>
        ''' <remarks></remarks>
        Public Function Online(ByVal CardHandle As Integer, ByVal sc As ScannerConfiguration) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Online")
            Dim blResult As Boolean = False
            Try
                Dim res As Integer = DNS_Online(CardHandle, sc)
                If res = 0 Then
                    log("Online", res.ToString() & " = DNS_Online() and GetLastWin32Error()=" & _
                    Marshal.GetLastWin32Error().ToString("X") & " CardHandle=" & CardHandle)
                    blResult = False
                Else
                    log("Online", res.ToString() & " = DNS_Online()" & " CardHandle=" & CardHandle)
                    blResult = True
                End If
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error(ex.Message.ToString)
            End Try
            AVPLib.Log.coreLogger.Info("Leave Online")
            Return blResult
        End Function

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-01</date>
        ''' </author>
        ''' <summary>
        ''' make current offline
        ''' </summary>
        ''' <param name=""></param>
        ''' <param name=""></param>
        ''' <remarks></remarks>
        Public Function Offline(ByVal CardHandle As Integer) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Offline")
            Dim blResult As Boolean = False
            Try
                Dim res As Integer = DNS_Offline(CardHandle)
                If res = 0 Then
                    log("Offline", res.ToString() & " = DNS_Offline() and GetLastWin32Error()=" & _
                    Marshal.GetLastWin32Error().ToString("X") & " CardHandle=" & CardHandle)
                    blResult = False
                Else
                    log("Offline", res.ToString() & " = DNS_Offline()" & " CardHandle=" & CardHandle)
                    blResult = True
                End If
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error(ex.Message.ToString)
            End Try
            AVPLib.Log.coreLogger.Info("Leave Offline")
            Return blResult
        End Function

        ''' <summary>
        ''' Active the scanner
        ''' </summary>
        ''' <param name="timeout"></param>
        ''' <returns></returns>
        Public Function SetScannerActive(ByVal CardHandle As Integer, ByVal timeout As Integer) As Boolean
            AVPLib.Log.coreLogger.Info("Enter SetScannerActive")
            Dim blResult As Boolean = False
            Try
                Dim res As Integer = DNS_IoActive(CardHandle, Convert.ToUInt16(timeout))
                If res = 0 Then
                    log("SetScannerActive", res.ToString() & " = DNS_IoActive() and GetLastWin32Error()=" & _
                    Marshal.GetLastWin32Error().ToString("X"))
                    blResult = False
                End If
                log("SetScannerActive", res.ToString() & " = DNS_IoActive()")
                blResult = True
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error(ex.Message.ToString)
            End Try
            AVPLib.Log.coreLogger.Info("Leave SetScannerActive")
            Return blResult
        End Function

        ''' <summary>
        ''' Read IO data (the data packet is configured in eds file)
        ''' </summary>
        ''' <param name="DeviceId"></param>
        ''' <param name="byteCount"></param>
        ''' <returns></returns>
        Public Function ReadDeviceIo(ByVal CardHandle As Integer, ByVal DeviceId__1 As Integer, ByVal byteCount As Integer) As Byte()
            Dim source As Byte() = New Byte(byteCount - 1) {}
            If byteCount = 0 Then
                log("ReadDeviceIo", "Req for zero data len")
                Return source
            End If
            For i As Integer = 0 To byteCount - 1
                source(i) = 0
            Next
            Dim cb As Integer = Marshal.SizeOf(source(0)) * source.Length
            Dim destination As IntPtr = Marshal.AllocCoTaskMem(cb)
            Try
                Marshal.Copy(source, 0, destination, source.Length)
                Dim deviceId__2 As UShort = Convert.ToUInt16(DeviceId__1)
                Dim size As UShort = Convert.ToUInt16(byteCount)
                Dim res As Integer = DNS_ReadDeviceIo(CardHandle, deviceId__2, 0, destination, size)
                If res = 0 Then
                    log("ReadDeviceIo", res.ToString() & " = DNS_ReadDeviceIo() and GetLastWin32Error()=" & Marshal.GetLastWin32Error().ToString("X"))
                    Return Nothing
                End If
                Marshal.Copy(destination, source, 0, source.Length)
            Catch exception As Exception
                log("ReadDeviceIo", ("Exception=" + exception.Message & vbLf & "StackTrace=") + exception.StackTrace)
                Return Nothing
            Finally
                Marshal.FreeCoTaskMem(destination)
            End Try
            Return source
        End Function

        ''' <summary>
        ''' Write IO data (the data packet is configured in eds file)
        ''' </summary>
        ''' <param name="DeviceId"></param>
        ''' <param name="Data"></param>
        ''' <returns></returns>
        Public Function WriteDeviceIo(ByVal CardHandle As Integer, ByVal DeviceId__1 As Integer, ByVal Data As Byte()) As Boolean
            If Data Is Nothing Then
                log("WriteDeviceIo", "null data found!")
                Return False
            End If
            Dim length As Integer = Data.Length
            If length = 0 Then
                log("WriteDeviceIo", "zero data count found!")
                Return True
            End If
            Dim cb As Integer = Marshal.SizeOf(Data(0)) * Data.Length
            Dim destination As IntPtr = Marshal.AllocCoTaskMem(cb)
            Try
                Marshal.Copy(Data, 0, destination, Data.Length)
                Dim deviceId__2 As UShort = Convert.ToUInt16(DeviceId__1)
                Dim size As UShort = Convert.ToUInt16(length)
                Dim res As Integer = DNS_WriteDeviceIo(CardHandle, deviceId__2, 1, destination, size)
                If res = 0 Then
                    log("WriteDeviceIo", res.ToString() & " = DNS_WriteDeviceIo() and GetLastWin32Error()=" & Marshal.GetLastWin32Error().ToString("X"))
                    Return False
                End If
            Catch exception As Exception
                log("WriteDeviceIo", "Exception=" + exception.Message)
                Return False
            Finally
                Marshal.FreeCoTaskMem(destination)
            End Try
            Return True
        End Function

        ''' <summary>
        ''' Receive Explicit from a service
        ''' </summary>
        ''' <param name="DeviceId"></param>
        ''' <param name="service"></param>
        ''' <returns></returns>
        Public Function ReceiveExplicit(ByVal CardHandle As Integer, ByVal DeviceId__1 As Integer, ByRef service As Integer) As Byte()
            Dim index As Integer
            Dim iSize As Integer = 512
            Dim ReturnBuffer As Byte()
            Dim source As Byte() = New Byte(iSize - 1) {}
            For index = 0 To 511
                source(index) = 0
            Next
            Dim cb As Integer = Marshal.SizeOf(source(0)) * source.Length
            Dim destination As IntPtr = Marshal.AllocCoTaskMem(cb)
            Try
                Marshal.Copy(source, 0, destination, source.Length)
                Dim deviceId__2 As UShort = Convert.ToUInt16(DeviceId__1)
                Dim size As UShort = Convert.ToUInt16(iSize)
                Dim rcvService As Byte = 0
                Dim res As Integer = DNS_ReceiveDeviceExplicit(CardHandle, deviceId__2, rcvService, destination, size)
                If res = 0 Then
                    log("ReceiveExplicit", res.ToString() & " = DNS_ReceiveDeviceExplicit(" & DeviceId__1.ToString() & ") and GetLastWin32Error()=" & Marshal.GetLastWin32Error().ToString("X"))
                    Return Nothing
                End If
                Marshal.Copy(destination, source, 0, source.Length)
                iSize = size
                Dim TempBuffer As Byte() = New Byte(iSize - 1) {}
                For index = 0 To iSize - 1
                    TempBuffer(index) = source(index)
                Next
                ReturnBuffer = TempBuffer
            Catch exception As Exception
                log("ReceiveExplicit", "Exception=" + exception.Message)
                ReturnBuffer = Nothing
            Finally
                If destination <> IntPtr.Zero Then
                    Marshal.FreeCoTaskMem(destination)
                End If
            End Try
            Return ReturnBuffer
        End Function

        ''' <summary>
        ''' Send Explicit
        ''' </summary>
        ''' <param name="DeviceId"></param>
        ''' <param name="Service"></param>
        ''' <param name="classId"></param>
        ''' <param name="instanceId"></param>
        ''' <param name="Data"></param>
        ''' <returns></returns>
        Public Function SendExplicitMessage(ByVal CardHandle As Integer, ByVal DeviceId__1 As Integer, ByVal Service__2 As Integer, ByVal classId As Integer, ByVal instanceId As Integer, ByVal Data As Byte()) As Boolean
            Dim zero As IntPtr = IntPtr.Zero
            If Data Is Nothing Then
                Return False
            End If
            Dim length As Integer = Data.Length
            Try
                If length <> 0 Then
                    Dim cb As Integer = Marshal.SizeOf(Data(0)) * Data.Length
                    zero = Marshal.AllocCoTaskMem(cb)
                    Marshal.Copy(Data, 0, zero, Data.Length)
                End If
                Dim deviceId__3 As UShort = Convert.ToUInt16(DeviceId__1)
                Dim size As UShort = Convert.ToUInt16(length)
                Dim service__4 As Byte = Convert.ToByte(Service__2)
                Dim bInstanceID As Byte = Convert.ToByte(instanceId)
                Dim bClassID As Byte = Convert.ToByte(classId)
                Dim res As Integer = DNS_SendDeviceExplicit(CardHandle, deviceId__3, service__4, bClassID, bInstanceID, zero, _
                 size)
                If res = 0 Then
                    log("SendExplicitMessage", res.ToString() & " = DNS_SendDeviceExplicit() and GetLastWin32Error()=" & Marshal.GetLastWin32Error().ToString("X") & " DeviceID=" & deviceId__3 & " Service=" & service__4 & " ClassID=" & classId & " InstanceID=" & instanceId)
                    Return False
                End If
            Catch exception As Exception
                log("SendExplicit", "Exception=" + exception.Message)
                Return False
            Finally
                If length <> 0 Then
                    Marshal.FreeCoTaskMem(zero)
                End If
            End Try
            Return True
        End Function

        Public Function SendExplicitMessage(ByVal CardHandle As Integer, ByVal DeviceId__1 As Integer, ByVal Service__2 As Integer, ByVal classId As Integer, ByVal instanceId As Integer, ByVal Data As Byte(), ByVal usSizeOfData As UShort) As Boolean
            Dim zero As IntPtr = IntPtr.Zero
            If Data Is Nothing Then
                Return False
            End If
            Dim length As Integer = Data.Length
            Try
                If length <> 0 Then
                    Dim cb As Integer = Marshal.SizeOf(Data(0)) * Data.Length
                    zero = Marshal.AllocCoTaskMem(cb)
                    Marshal.Copy(Data, 0, zero, Data.Length)
                End If
                Dim deviceId__3 As UShort = Convert.ToUInt16(DeviceId__1)
                Dim service__4 As Byte = Convert.ToByte(Service__2)
                Dim bInstanceID As Byte = Convert.ToByte(instanceId)
                Dim bClassID As Byte = Convert.ToByte(classId)
                Dim res As Integer = DNS_SendDeviceExplicit(CardHandle, deviceId__3, service__4, bClassID, bInstanceID, zero, _
                 usSizeOfData)
                If res = 0 Then
                    log("SendExplicitMessage", res.ToString() & " = DNS_SendDeviceExplicit() and GetLastWin32Error()=" & Marshal.GetLastWin32Error().ToString("X") & " DeviceID=" & deviceId__3 & " Service=" & service__4 & " ClassID=" & classId & " InstanceID=" & instanceId)
                    Return False
                End If
            Catch exception As Exception
                log("SendExplicit", "Exception=" + exception.Message)
                Return False
            Finally
                If length <> 0 Then
                    Marshal.FreeCoTaskMem(zero)
                End If
            End Try
            Return True
        End Function

        ''' <summary>
        ''' Get Bus Status
        ''' </summary>
        ''' <returns></returns>
        Public Function GetBusStatus(ByVal CardHandle As Integer) As Integer
            Dim busStatus As UShort = 0
            Dim res As Integer = DNS_GetBusStatus(CardHandle, busStatus)
            If res = 0 Then
                log("GetBusStatus", res.ToString() & " = DNS_GetBusStatus() and GetLastWin32Error()=" & Marshal.GetLastWin32Error().ToString("X"))
                Return 0
            End If
            Return busStatus
        End Function

        ''' <summary>
        ''' Get Device Event
        ''' </summary>
        ''' <param name="DeviceId"></param>
        ''' <param name="evtId"></param>
        ''' <returns></returns>
        Public Function GetDeviceEvent(ByVal CardHandle As Integer, ByVal DeviceId__1 As Integer, ByVal evtId As Integer) As Integer

            Dim deviceId__2 As UShort = Convert.ToUInt16(DeviceId__1)
            Dim eventId As Byte = Convert.ToByte(evtId)
            Dim deviceEvent As Byte = 0
            Try
                Dim res As Integer = DNS_GetDeviceEvent(CardHandle, deviceId__2, eventId, deviceEvent)
                If res = 0 Then
                    log("GetDeviceEvent", res.ToString() & " = DNS_GetDeviceEvent() and GetLastWin32Error()=" & Marshal.GetLastWin32Error().ToString("X"))
                    Return -1
                End If
            Catch ex As Exception
                log("GetDeviceEvent", ex.Message)
                Return -1
            End Try

            Return Convert.ToInt32(deviceEvent)
        End Function

        ''' <summary>
        ''' Get Device Status
        ''' </summary>
        ''' <param name="DeviceId"></param>
        ''' <returns></returns>
        Public Function GetDeviceStatus(ByVal CardHandle As Integer, ByVal DeviceId As Integer) As DeviceNetStatus
            AVPLib.Log.coreLogger.Info("Enter GetDeviceStatus")
            Dim devStatus As New DeviceNetStatus()
            Try
                Dim UIdeviceId As UShort = Convert.ToUInt16(DeviceId)
                Dim res As Integer = DNS_GetDeviceStatus(CardHandle, UIdeviceId, devStatus)
                If res = 0 Then
                    log("GetDeviceStatus", res.ToString() & " = DNS_GetDeviceStatus() and GetLastWin32Error()=" & _
                    Marshal.GetLastWin32Error().ToString("X"))
                    devStatus = Nothing
                End If
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error(ex.Message.ToString)
            End Try
            AVPLib.Log.coreLogger.Info("Leave GetDeviceStatus")
            Return devStatus
        End Function

        ''' <summary>
        ''' Is Device active
        ''' </summary>
        ''' <param name="statCode"></param>
        ''' <returns></returns>
        Public Function IsDeviceActive(ByVal statCode As Integer) As Boolean
            Return (statCode = 2)
        End Function
    End Class
End Namespace
