using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using DeviceNetApp.Lib;

namespace DeviceNetApp.DeviceNet
{
    #region STRUCT DEFINE
    [StructLayout(LayoutKind.Sequential)]
    public class DeviceConfiguration
    {
        public ushort MacId;
        public ushort VendorId;
        public ushort DeviceType;
        public ushort ProductCode;
        public ushort ProductionInhibitTime;
        public ushort Reserved2;
        public ushort Reserved3;
        public ushort Flags;
        public ushort ExplicitSize;
        public ushort ExplicitOffset;
        public ushort Io1Interval;
        public ushort Output1Size;
        public ushort Output1Offset;
        public ushort Output1LocalPathOffset;
        public ushort Output1RemotePathOffset;
        public ushort Input1Size;
        public ushort Input1Offset;
        public ushort Input1LocalPathOffset;
        public ushort Input1RemotePathOffset;
        public ushort Io2Interval;
        public ushort Output2Size;
        public ushort Output2Offset;
        public ushort Output2LocalPathOffset;
        public ushort Output2RemotePathOffset;
        public ushort Input2Size;
        public ushort Input2Offset;
        public ushort Input2LocalPathOffset;
        public ushort Input2RemotePathOffset;
        public DeviceConfiguration()
        {
            this.MacId = 0;
            this.VendorId = 0;
            this.DeviceType = 0;
            this.ProductCode = 0;
            this.ProductionInhibitTime = 0;
            this.Reserved2 = 0;
            this.Reserved3 = 0;
            this.Flags = 0;
            this.ExplicitSize = 0;
            this.ExplicitOffset = 0;
            this.Io1Interval = 0;
            this.Output1Size = 0;
            this.Output1Offset = 0;
            this.Output1LocalPathOffset = 0;
            this.Output1RemotePathOffset = 0;
            this.Input1Size = 0;
            this.Input1Offset = 0;
            this.Input1LocalPathOffset = 0;
            this.Input1RemotePathOffset = 0;
            this.Io2Interval = 0;
            this.Output2Size = 0;
            this.Output2Offset = 0;
            this.Output2LocalPathOffset = 0;
            this.Output2RemotePathOffset = 0;
            this.Input2Size = 0;
            this.Input2Offset = 0;
            this.Input2LocalPathOffset = 0;
            this.Input2RemotePathOffset = 0;
        }
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public class ScannerConfiguration
    {
        public ushort MacId;
        public ushort BaudRate;
        public ushort ScanInterval;
        public ushort ReconnectTime;
        public ushort Flags;
        public ushort ExplicitRequestSize;
        public ushort ExplicitRequestOffset;
        public ushort ExplicitResponseSize;
        public ushort ExplicitResponseOffset;
        public ushort Io1Interval;
        public ushort Output1Size;
        public ushort Output1Offset;
        public ushort Output1LocalPathOffset;
        public ushort Input1Size;
        public ushort Input1Offset;
        public ushort Input1LocalPathOffset;
        public ushort Io2Interval;
        public ushort Output2Size;
        public ushort Output2Offset;
        public ushort Output2LocalPathOffset;
        public ushort Input2Size;
        public ushort Input2Offset;
        public ushort Input2LocalPathOffset;
        public ScannerConfiguration()
        {
            this.MacId = 0;
            this.BaudRate = 0;
            this.ScanInterval = 100;
            this.ReconnectTime = 0;
            this.Flags = 0;
            this.ExplicitRequestSize = 0;
            this.ExplicitRequestOffset = 0;
            this.ExplicitResponseSize = 0;
            this.ExplicitResponseOffset = 0;
            this.Io1Interval = 0;
            this.Output1Size = 0;
            this.Output1Offset = 0;
            this.Output1LocalPathOffset = 0;
            this.Input1Size = 0;
            this.Input1Offset = 0;
            this.Input1LocalPathOffset = 0;
            this.Io2Interval = 0;
            this.Output2Size = 0;
            this.Output2Offset = 0;
            this.Output2LocalPathOffset = 0;
            this.Input2Size = 0;
            this.Input2Offset = 0;
            this.Input2LocalPathOffset = 0;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public class DeviceNetStatus
    {
        public byte StatusCode;
        public byte StatusFlags;
        public DeviceNetStatus()
        {
            StatusCode = 0;
            StatusFlags = 0;
        }
    }

    #endregion

    public class DeviceNetDriver
    {
        #region API FUNCTION IMPORT

        [DllImport("dnscan32.dll", SetLastError = true)]
        private static extern int DNS_AddDevice(int CardHandle, [In, MarshalAs(UnmanagedType.LPStruct)] DeviceConfiguration DeviceCfg);

        [DllImport("dnscan32.dll", SetLastError = true)]
        private static extern int DNS_CloseCard(int CardHandle);

        [DllImport("dnscan32.dll", SetLastError = true)]
        private static extern int DNS_DeleteDevice(int CardHandle, ushort DeviceId);

        [DllImport("dnscan32.dll", SetLastError = true)]
        private static extern int DNS_FreeDriver();

        [DllImport("dnscan32.dll", SetLastError = true)]
        private static extern int DNS_GetBusStatus(int CardHandle, ref ushort BusStatus);

        [DllImport("dnscan32.dll", SetLastError = true)]
        private static extern int DNS_GetDeviceEvent(int CardHandle, ushort DeviceId, byte EventId, ref byte DeviceEvent);

        [DllImport("dnscan32.dll", SetLastError = true)]
        private static extern int DNS_GetDeviceStatus(int CardHandle, ushort DeviceId, [Out, MarshalAs(UnmanagedType.LPStruct)] DeviceNetStatus DeviceStatus);

        [DllImport("dnscan32.dll", SetLastError = true)]
        private static extern int DNS_IoActive(int CardHandle, ushort Timeout);

        [DllImport("dnscan32.dll", SetLastError = true)]
        private static extern int DNS_LoadDriver([MarshalAs(UnmanagedType.LPStr)] string DriverName);

        [DllImport("dnscan32.dll", SetLastError = true)]
        private static extern int DNS_Offline(int CardHandle);

        [DllImport("dnscan32.dll", SetLastError = true)]
        private static extern int DNS_Online(int CardHandle, [In, MarshalAs(UnmanagedType.LPStruct)] ScannerConfiguration ScannerCfg);

        [DllImport("dnscan32.dll", SetLastError = true)]
        private static extern int DNS_OpenCard(ref int CardHandle, [MarshalAs(UnmanagedType.LPStr)] string CardName, int Module, int Flags);

        [DllImport("dnscan32.dll", SetLastError = true)]
        private static extern int DNS_ReadDeviceIo(int CardHandle, ushort DeviceId, byte IoArea, IntPtr Buffer, ushort Size);

        [DllImport("dnscan32.dll", SetLastError = true)]
        private static extern int DNS_ReceiveDeviceExplicit(int CardHandle, ushort DeviceId, ref byte Service, IntPtr ServiceData, ref ushort Size);

        [DllImport("dnscan32.dll", SetLastError = true)]
        private static extern int DNS_SendDeviceExplicit(int CardHandle, ushort DeviceId, byte Service, ushort ClassId, ushort InstanceId, IntPtr Buffer, ushort Size);

        [DllImport("dnscan32.dll", SetLastError = true)]
        private static extern int DNS_StartScan(int CardHandle);

        [DllImport("dnscan32.dll", SetLastError = true)]
        private static extern int DNS_StopScan(int CardHandle);

        [DllImport("dnscan32.dll", SetLastError = true)]
        private static extern int DNS_WriteDeviceIo(int CardHandle, ushort DeviceId, byte IoArea, IntPtr Buffer, ushort Size);

        [DllImport("dnerr32.dll", SetLastError = true)]
        private static extern int DNE_CommandError(int ErrorCode, [MarshalAs(UnmanagedType.LPStr)] string Buffer, int size);

        [DllImport("dnscan32.dll", SetLastError = true)]
        public static extern int GetLastError();
        
        #endregion

        /// <summary>
        /// Load Driver function
        /// </summary>
        public static Boolean LoadDeviceNetDriver()
        {
            try
            {
                int loadRes = DNS_LoadDriver("ssdn32.dll");
                if (loadRes == 0)
                {
                    log("LoadDeviceNetDriver", loadRes.ToString() + " = DNS_LoadDriver() and GetLastWin32Error()=" + Marshal.GetLastWin32Error().ToString("X"));
                }
                else
                {
                    log("LoadDeviceNetDriver", loadRes.ToString() + " = DNS_LoadDriver()");
                    return true;
                }

                
            }
            catch (Exception exception)
            {
                log("LoadDeviceNetDriver", exception.Message.ToString());
            }
            return false;
        }

        /// <summary>
        /// User contructor
        /// </summary>
        public DeviceNetDriver()
        {
        }

        /// <summary>
        /// Unload the driver
        /// </summary>
        public static Boolean UnloadDeviceNetDriver()
        {
            try
            {
                int res = 0;
                res = DNS_FreeDriver();
                if (res == 0)
                {
                    log("UnloadDeviceNetDriver", res.ToString() + " = DNS_FreeDriver() and GetLastWin32Error()=" + Marshal.GetLastWin32Error().ToString("X"));
                }
                else
                {
                    log("UnloadDeviceNetDriver", res.ToString() + " = DNS_FreeDriver()");
                    return true;
                }
            }
            finally
            {
            }
            return false;
        }

        /// <summary>
        /// Log function
        /// </summary>
        /// <param name="strfuncName"></param>
        /// <param name="strMsg"></param>
        private static void log(string strfuncName, string strMsg)
        {
            Logger.LogHandler.Debug(strfuncName + ": " + strMsg);
        }

        /// <summary>
        /// Add a Device Net card
        /// </summary>
        /// <param name="dc"></param>
        /// <returns></returns>
        public static bool RegisterEquipment(int CardHandle, DeviceConfiguration dc)
        {
            int addRes = DNS_AddDevice(CardHandle, dc);
            if (addRes == 0)
            {
                int iLastErr = Marshal.GetLastWin32Error();
                if (iLastErr == 536871437)
                {
                    log("AddDevice", addRes.ToString() + " = DNS_AddDevice(" + dc.MacId.ToString() + ") and GetLastWin32Error()=" + iLastErr.ToString("X"));
                    log("AddDevice", addRes.ToString() + " = DNS_AddDevice(" + dc.MacId.ToString() + ") and ExplicitOffset=" + dc.ExplicitOffset.ToString("X"));
                }
                else
                {
                    log("AddDevice", addRes.ToString() + " = DNS_AddDevice(" + dc.MacId.ToString() + ") and GetLastWin32Error()=" + iLastErr.ToString("X"));
                }
                return false;
            }
            log("AddDevice", addRes.ToString() + " = DNS_AddDevice(" + dc.MacId.ToString() + ")");
            return true;
        }

        /// <summary>
        /// Delete card
        /// </summary>
        /// <param name="DeviceId"></param>
        /// <returns></returns>
        public static bool DeleteDevice(int CardHandle, int DeviceId)
        {
            ushort deviceId = Convert.ToUInt16(DeviceId);
            int delRes = DNS_DeleteDevice(CardHandle, deviceId);
            if (delRes == 0)
            {
                log("DeleteDevice", delRes.ToString() + " = DNS_DeleteDevice(" + DeviceId.ToString() + ") and GetLastWin32Error()=" + Marshal.GetLastWin32Error().ToString("X"));
                return false;
            }
            log("DeleteDevice", delRes.ToString() + " = DNS_DeleteDevice(" + DeviceId.ToString() + ")");
            return true;
        }

        /// <summary>
        /// Open Card
        /// </summary>
        /// <param name="CardName"></param>
        /// <returns></returns>
        public static bool OpenCard(ref int CardHandle, string CardName)
        {
            int res = DNS_OpenCard(ref CardHandle, CardName, 0, 0);
            if (res == 0)
            {
                log("OpenCard", res.ToString() + " = DNS_OpenCard(" + CardName + ") and GetLastWin32Error()=" + Marshal.GetLastWin32Error().ToString("X"));
                return false;
            }
            log("OpenCard", res.ToString() + " = DNS_OpenCard(" + CardName + ")");
            return true;
        }

        /// <summary>
        /// Close Card
        /// </summary>
        /// <returns></returns>
        public static bool CloseCard(int CardHandle)
        {
            if (CardHandle != 0)
            {                
                int res = DNS_CloseCard(CardHandle);
                if (res == 0)
                {
                    log("CloseCard", res.ToString() + " = DNS_CloseCard() and GetLastWin32Error()=" + Marshal.GetLastWin32Error().ToString("X"));
                    return false;
                }
                log("CloseCard", res.ToString() + " = DNS_CloseCard()");
            }
            return true;
        }

        /// <summary>
        /// Start Scan for this card
        /// </summary>
        /// <returns></returns>
        public static bool StartScan(int CardHandle)
        {
            int res = DNS_StartScan(CardHandle);
            if (res == 0)
            {
                log("StartScan", res.ToString() + " = DNS_StartScan() and GetLastWin32Error()=" + Marshal.GetLastWin32Error().ToString("X"));
                return false;
            }
            log("StartScan", res.ToString() + " = DNS_StartScan()");
            return true;
        }

        /// <summary>
        /// Stop Scan
        /// </summary>
        /// <returns></returns>
        public static bool StopScan(int CardHandle)
        {
            int res = DNS_StopScan(CardHandle);
            if (res == 0)
            {
                log("StopScan", res.ToString() + " = DNS_StopScan() and GetLastWin32Error()=" + Marshal.GetLastWin32Error().ToString("X"));
                return false;
            }
            log("StopScan", res.ToString() + " = DNS_StopScan()");
            return true;
        }

        /// <summary>
        /// Make the current Online
        /// </summary>
        /// <param name="sc"></param>
        /// <returns></returns>
        public static bool Online(int CardHandle, ScannerConfiguration sc)
        {
            int res = DNS_Online(CardHandle, sc);
            if (res == 0)
            {
                log("Online", res.ToString() + " = DNS_Online() and GetLastWin32Error()=" + Marshal.GetLastWin32Error().ToString("X"));
                return false;
            }
            log("Online", res.ToString() + " = DNS_Online()");
            return true;
        }

        /// <summary>
        /// Offline
        /// </summary>
        /// <returns></returns>
        public static bool Offline(int CardHandle)
        {
            int res = DNS_Offline(CardHandle);
            if (res == 0)
            {
                log("Offline", res.ToString() + " = DNS_Offline() and GetLastWin32Error()=" + Marshal.GetLastWin32Error().ToString("X"));
                return false;
            }
            log("Offline", res.ToString() + " = DNS_Offline()");
            return true;
        }

        /// <summary>
        /// Active the scanner
        /// </summary>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static bool SetScannerActive(int CardHandle, int timeout)
        {
            int res = DNS_IoActive(CardHandle, Convert.ToUInt16(timeout));
            if (res == 0)
            {
                log("SetScannerActive", res.ToString() + " = DNS_IoActive() and GetLastWin32Error()=" + Marshal.GetLastWin32Error().ToString("X"));
                return false;
            }
            log("SetScannerActive", res.ToString() + " = DNS_IoActive()");
            return true;
        }

        /// <summary>
        /// Read IO data (the data packet is configured in eds file)
        /// </summary>
        /// <param name="DeviceId"></param>
        /// <param name="byteCount"></param>
        /// <returns></returns>
        public static byte[] ReadDeviceIo(int CardHandle, int DeviceId, int byteCount)
        {
            byte[] source = new byte[byteCount];
            if (byteCount == 0)
            {
                log("ReadDeviceIo", "Req for zero data len");
                return source;
            }
            for (int i = 0; i < byteCount; i++)
            {
                source[i] = 0;
            }
            int cb = Marshal.SizeOf(source[0]) * source.Length;
            IntPtr destination = Marshal.AllocCoTaskMem(cb);
            try
            {
                Marshal.Copy(source, 0, destination, source.Length);
                ushort deviceId = Convert.ToUInt16(DeviceId);
                ushort size = Convert.ToUInt16(byteCount);
                int res = DNS_ReadDeviceIo(CardHandle, deviceId, 0, destination, size);
                if (res == 0)
                {
                    log("ReadDeviceIo", res.ToString() + " = DNS_ReadDeviceIo() and GetLastWin32Error()=" + Marshal.GetLastWin32Error().ToString("X"));
                    return null;
                }
                Marshal.Copy(destination, source, 0, source.Length);
            }
            catch (Exception exception)
            {
                log("ReadDeviceIo", "Exception=" + exception.Message + "\nStackTrace=" + exception.StackTrace);
                return null;
            }
            finally
            {
                Marshal.FreeCoTaskMem(destination);
            }
            return source;
        }

        /// <summary>
        /// Write IO data (the data packet is configured in eds file)
        /// </summary>
        /// <param name="DeviceId"></param>
        /// <param name="Data"></param>
        /// <returns></returns>
        public static bool WriteDeviceIo(int CardHandle, int DeviceId, byte[] Data)
        {
            if (Data == null)
            {
                log("WriteDeviceIo", "null data found!");
                return false;
            }
            int length = Data.Length;
            if (length == 0)
            {
                log("WriteDeviceIo", "zero data count found!");
                return true;
            }
            int cb = Marshal.SizeOf(Data[0]) * Data.Length;
            IntPtr destination = Marshal.AllocCoTaskMem(cb);
            try
            {
                Marshal.Copy(Data, 0, destination, Data.Length);
                ushort deviceId = Convert.ToUInt16(DeviceId);
                ushort size = Convert.ToUInt16(length);
                int res = DNS_WriteDeviceIo(CardHandle, deviceId, 1, destination, size);
                if (res == 0)
                {
                    log("WriteDeviceIo", res.ToString() + " = DNS_WriteDeviceIo() and GetLastWin32Error()=" + Marshal.GetLastWin32Error().ToString("X"));
                    return false;
                }
            }
            catch (Exception exception)
            {
                log("WriteDeviceIo", "Exception=" + exception.Message);
                return false;
            }
            finally
            {
                Marshal.FreeCoTaskMem(destination);
            }
            return true;
        }

        /// <summary>
        /// Receive Explicit from a service
        /// </summary>
        /// <param name="DeviceId"></param>
        /// <param name="service"></param>
        /// <returns></returns>
        public static byte[] ReceiveExplicit(int CardHandle, int DeviceId, ref int service)
        {
            int index;
            int iSize = 512;
            byte[] ReturnBuffer;
            byte[] source = new byte[iSize];
            for (index = 0; index < 512; index++)
            {
                source[index] = 0;
            }
            int cb = Marshal.SizeOf(source[0]) * source.Length;
            IntPtr destination = Marshal.AllocCoTaskMem(cb);
            try
            {
                Marshal.Copy(source, 0, destination, source.Length);
                ushort deviceId = Convert.ToUInt16(DeviceId);
                ushort size = Convert.ToUInt16(iSize);
                byte rcvService = 0;
                int res = DNS_ReceiveDeviceExplicit(CardHandle, deviceId, ref rcvService, destination, ref size);
                if (res == 0)
                {
                    log("ReceiveExplicit", res.ToString() + " = DNS_ReceiveDeviceExplicit(" + DeviceId.ToString() + ") and GetLastWin32Error()=" + Marshal.GetLastWin32Error().ToString("X"));
                    return null;
                }
                Marshal.Copy(destination, source, 0, source.Length);
                iSize = size;
                byte[] TempBuffer = new byte[iSize];
                for (index = 0; index < iSize; index++)
                {
                    TempBuffer[index] = source[index];
                }
                ReturnBuffer = TempBuffer;
            }
            catch (Exception exception)
            {
                log("ReceiveExplicit", "Exception=" + exception.Message);
                ReturnBuffer = null;
            }
            finally
            {
                if (destination != IntPtr.Zero)
                {
                    Marshal.FreeCoTaskMem(destination);
                }
            }
            return ReturnBuffer;
        }

        /// <summary>
        /// Send Explicit
        /// </summary>
        /// <param name="DeviceId"></param>
        /// <param name="Service"></param>
        /// <param name="classId"></param>
        /// <param name="instanceId"></param>
        /// <param name="Data"></param>
        /// <returns></returns>
        public static bool SendExplicitMessage(int CardHandle, int DeviceId, int Service, int classId, int instanceId, byte[] Data, ushort Size)
        {
            IntPtr zero = IntPtr.Zero;
            int length = 0;
            if (Data != null)
            {
                length = Data.Length;
            }
            try
            {
                if (length != 0)
                {
                    int cb = Marshal.SizeOf(Data[0]) * Data.Length;
                    zero = Marshal.AllocCoTaskMem(cb);
                    Marshal.Copy(Data, 0, zero, Data.Length);
                }
                ushort deviceId = Convert.ToUInt16(DeviceId);
                byte service = Convert.ToByte(Service);
                byte bInstanceID = Convert.ToByte(instanceId);
                byte bClassID = Convert.ToByte(classId);
                int res = DNS_SendDeviceExplicit(CardHandle, deviceId, service, bClassID, bInstanceID, zero, Size);
                if (res == 0)
                {
                    log("SendExplicit", res.ToString() + " = DNS_SendDeviceExplicit() and GetLastWin32Error()=" + Marshal.GetLastWin32Error().ToString("X"));
                    return false;
                }
            }
            catch (Exception exception)
            {
                log("SendExplicit", "Exception=" + exception.Message);
                return false;
            }
            finally
            {
                if (length != 0)
                {
                    Marshal.FreeCoTaskMem(zero);
                }
            }
            return true;
        }

        /// <summary>
        /// Get Bus Status
        /// </summary>
        /// <returns></returns>
        public static int GetBusStatus(int CardHandle)
        {
            ushort busStatus = 0;
            int res = DNS_GetBusStatus(CardHandle, ref busStatus);
            if (res == 0)
            {
                log("GetBusStatus", res.ToString() + " = DNS_GetBusStatus() and GetLastWin32Error()=" + Marshal.GetLastWin32Error().ToString("X"));
                return 0;
            }
            return busStatus;
        }

        /// <summary>
        /// Get Device Event
        /// </summary>
        /// <param name="DeviceId"></param>
        /// <param name="evtId"></param>
        /// <returns></returns>
        public static int GetDeviceEvent(int CardHandle, int DeviceId, int evtId)
        {
            ushort deviceId = Convert.ToUInt16(DeviceId);
            byte eventId = Convert.ToByte(evtId);
            byte deviceEvent = 0;
            int res = DNS_GetDeviceEvent(CardHandle, deviceId, eventId, ref deviceEvent);
            if (res == 0)
            {
                log("GetDeviceEvent", res.ToString() + " = DNS_GetDeviceEvent() and GetLastWin32Error()=" + Marshal.GetLastWin32Error().ToString("X"));
                return -1;
            }
            return Convert.ToInt32(deviceEvent);
        }

        /// <summary>
        /// Get Device Status
        /// </summary>
        /// <param name="DeviceId"></param>
        /// <returns></returns>
        public static DeviceNetStatus GetDeviceStatus(int CardHandle, int DeviceId)
        {
            DeviceNetStatus devStatus = new DeviceNetStatus();
            ushort deviceId = Convert.ToUInt16(DeviceId);
            int res = DNS_GetDeviceStatus(CardHandle, deviceId, devStatus);
            if (res == 0)
            {
                log("GetDeviceStatus", res.ToString() + " = DNS_GetDeviceStatus() and GetLastWin32Error()=" + Marshal.GetLastWin32Error().ToString("X"));
                return null;
            }
            return devStatus;
        }

        /// <summary>
        /// Is Device active
        /// </summary>
        /// <param name="statCode"></param>
        /// <returns></returns>
        public static bool IsDeviceActive(int statCode)
        {
            return (statCode == 2);
        }
    }
}
