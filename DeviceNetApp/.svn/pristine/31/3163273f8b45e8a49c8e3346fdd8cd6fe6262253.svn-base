using System;
using System.Collections.Generic;
using System.Text;
using DeviceNetApp.Lib;

namespace DeviceNetApp.DeviceNet
{
    public class DNSScanner
    {
        #region "Update Data Objects"
        protected PropertyObject m_objCommunicationStatusProp = new PropertyObject();
        #endregion

        /// <summary>
        /// The configuration for scanner
        /// </summary>
        private ScannerConfiguration m_ScannerConfiguration = null;

        /// <summary>
        /// Share memory pointer
        /// </summary>
        private UInt16 m_iSharedMemoryOffsetPointer = 0;

        /// <summary>
        /// Card name: The name assigned to the interface card during hardware installation (stored in registry).
        /// </summary>
        private String m_strCardName = String.Empty;
        public String CardName
        {
            set { m_strCardName = value; }
            get { return m_strCardName; }
        }

        /// <summary>
        /// Baud rate. [125 | 250 | 500]K 
        /// </summary>
        private Int32 m_nBaudRate = 125;
        public Int32 BaudRate
        {
            set { m_nBaudRate = value; }
            get { return m_nBaudRate; }
        }

        /// <summary>
        /// Card handle of scanner
        /// </summary>
        private Int32 m_hCardHandle = 0;
        public Int32 CardHandle
        {
            get { return m_hCardHandle; }
        }

        /// <summary>
        /// Is Already Scanning
        /// </summary>
        private Boolean m_bScanning = false;

        /// <summary>
        /// Previous Bus Status
        /// </summary>
        private Int32 m_iPrevBusStatus = 0;

        /// <summary>
        /// Create a sigleton object
        /// </summary>
        private DeviceStatus m_eInitialized = DeviceStatus.BETWEEN;

        private EquipmentStatus m_eBusStatus = EquipmentStatus.UNKNOWN;
        public EquipmentStatus BusStatus
        {
            get { return m_eBusStatus; }
        }
        /// <summary>
        /// Constructor
        /// </summary>
        protected DNSScanner()
        {
            // Init shared memory position
            m_iSharedMemoryOffsetPointer = 0x1000;

            // Init the configuration structure for Scanner
            m_ScannerConfiguration = new ScannerConfiguration();
        }

        /// <summary>
        /// Initilaize function
        /// </summary>
        /// <returns></returns>
        public virtual Boolean Initialize()
        {

            if (m_eInitialized != DeviceStatus.BETWEEN)
            {
                return (m_eInitialized == DeviceStatus.ACTIVE);
            }

            m_eInitialized = DeviceStatus.INACTIVE;

            Logger.LogHandler.Info("Enter Initialize");
            try
            {

                // Load DeviceNet driver
                if (!DeviceNetDriver.LoadDeviceNetDriver())
                {
                    Logger.LogHandler.Error("LoadDeviceNetDriver fail!");
                    return false;
                }

                // Init MacID
                m_ScannerConfiguration.MacId = 0;

                String cfgCardName = this.CardName;

                if (string.IsNullOrEmpty(this.CardName))
                {
                    Logger.LogHandler.Error("Scanner card name is empty.");
                    DeviceNetDriver.UnloadDeviceNetDriver();
                    return false;
                }

                // Open card
                if (!DeviceNetDriver.OpenCard(ref m_hCardHandle, this.CardName))
                {
                    Logger.LogHandler.Error("OpenCard fail!");
                    DeviceNetDriver.UnloadDeviceNetDriver();
                    return false;
                }

                Int32 cfgBaudRate = 0; 

                // this.BaudRate must be 125 or 250 or 500
                switch (this.BaudRate)
                {
                    case 125:
                    case 0:
                        cfgBaudRate = 0;
                        break;
                    case 250:
                    case 1:
                        cfgBaudRate = 1;
                        break;
                    case 500:
                    case 2:
                        cfgBaudRate = 2;
                        break;
                    default:
                        cfgBaudRate = 0;
                        break;
                }

                // Setup the configuration [0: 125K] - [1: 250K] - [2: 500K] 
                m_ScannerConfiguration.BaudRate = (ushort)cfgBaudRate;
                m_ScannerConfiguration.Io1Interval = 0;
                m_ScannerConfiguration.ScanInterval = 100; // As fast as possible
                m_ScannerConfiguration.Flags = 0;

                // Bring Scanner Online
                if (!DeviceNetDriver.Online(m_hCardHandle, m_ScannerConfiguration))
                {
                    Logger.LogHandler.Error("Online fail!");
                    CleanUp();
                    // Show inform message box
                    //TopMostMessageBox.Show("Failed To Bring DeviceNet Online.");
                    return false;
                }

                // Start Scanning
                if (!DeviceNetDriver.StartScan(m_hCardHandle))
                {
                    Logger.LogHandler.Error("StartScan fail!");
                    CleanUp();
                    return false;
                }

                // Mark that the scanner has scanned
                m_bScanning = true;

                // Mark start
                Int64 lStartTickCount = Environment.TickCount;

                // Wait for Bus Online
                Int32 iBusStatus = 0;
                do
                {
                    iBusStatus = DeviceNetDriver.GetBusStatus(m_hCardHandle);
                    if (iBusStatus == 0) // Has Error
                    {
                        CleanUp();
                        return false;
                    }

                    // Sleep 0.1s
                    System.Threading.Thread.Sleep(100);

                    if (Utils.GetTickCountDelta(lStartTickCount) > (2 * 60 * 1000)) // Over 2 minutes
                    {
                        CleanUp();
                        // Show inform message box
                        //TopMostMessageBox.Show("Failed To Bring DeviceNet Online.");
                        return false;
                    }

                }
                while ((iBusStatus & 0x0001) == 0);

                m_eInitialized = DeviceStatus.ACTIVE;

                Logger.LogHandler.Info("Leave Initialize");

                return true;

            }
            catch (Exception ex)
            {
                Logger.LogHandler.Error("DeviceNetController Initialize: " + ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Log the friendly bus status
        /// </summary>
        private void LogBusStatus(Int32 iBusStatus)
        {
            // Log
            Logger.LogHandler.Error("Bus Status = " + iBusStatus.ToString());

            // Detail the Bus Status
            if ((iBusStatus & 0x0001) != 0)
            {
                Logger.LogHandler.Debug("DNS Bus On-Line");
            }

            if ((iBusStatus & 0x0002) != 0)
            {
                Logger.LogHandler.Debug("DNS Bus Warning");
            }

            if ((iBusStatus & 0x0004) != 0)
            {
                Logger.LogHandler.Debug("DNS Bus Off");
            }

            if ((iBusStatus & 0x0008) != 0)
            {
                Logger.LogHandler.Debug("DNS Bus Network Activity Detected");
            }

            if ((iBusStatus & 0x0010) != 0)
            {
                Logger.LogHandler.Debug("DNS Bus Transmit failed due to ACK error");
            }

            if ((iBusStatus & 0x0020) != 0)
            {
                Logger.LogHandler.Debug("DNS Bus Transmit failed due to time-out");
            }

            if ((iBusStatus & 0x0040) != 0)
            {
                Logger.LogHandler.Debug("DNS Bus Receive overrun");
            }

            if ((iBusStatus & 0x0080) != 0)
            {
                Logger.LogHandler.Debug("DNS Bus Message lost");
            }

            if ((iBusStatus & 0x0100) != 0)
            {
                Logger.LogHandler.Debug("DNS Bus CAN Communication Error");
            }

            if ((iBusStatus & 0x0200) != 0)
            {
                Logger.LogHandler.Debug("DNS Bus Power Present");
            }

            if ((iBusStatus & 0x1000) != 0)
            {
                Logger.LogHandler.Debug("DNS Bus 125K");
            }

            if ((iBusStatus & 0x2000) != 0)
            {
                Logger.LogHandler.Debug("DNS Bus 250K");
            }

            if ((iBusStatus & 0x4000) != 0)
            {
                Logger.LogHandler.Debug("DNS Bus 500K");
            }

            if ((iBusStatus & 0x8000) != 0)
            {
                Logger.LogHandler.Debug("DNS Bus Scanner Active");
            }
        }

        /// <summary>
        /// Check Device Net Bus Status
        /// </summary>
        public void CheckDnetBusStatus()
        {
            // Check thus bus status before polling
            Int32 iBusStatus = DeviceNetDriver.GetBusStatus(m_hCardHandle);
            if (iBusStatus == 0) // Has Error
            {
                try
                {
                    int errorCode = DeviceNetDriver.GetLastError();
                    Logger.LogHandler.Error("Error when getting the bus status. Error code: " + errorCode.ToString());
                }
                catch (Exception ex)
                {
                    Logger.LogHandler.Error(ex.ToString());
                }
            }

            if (m_iPrevBusStatus != iBusStatus)
            {
                // Store
                m_iPrevBusStatus = iBusStatus;

                // Log the Bus Status
                LogBusStatus(iBusStatus);
            }

            m_eBusStatus = (iBusStatus & 0x0001) > 0 ? EquipmentStatus.OPENED : EquipmentStatus.CLOSED;
            //m_objCommunicationStatusProp.SetValue(m_eBusStatus);
        }

        /// <summary>
        /// Get Dnet Bus Status
        /// </summary>
        public void Poll()
        {
            CheckDnetBusStatus();
        }

        /// <summary>
        /// Alocate the memory
        /// </summary>
        /// <param name="nNumberOfBytes"></param>
        /// <returns></returns>
        public UInt16 GetMemoryOffset(UInt16 iNumberOfBytes)
        {
            UInt16 iOffset;

            iOffset = m_iSharedMemoryOffsetPointer;
            m_iSharedMemoryOffsetPointer += iNumberOfBytes;

            return iOffset;
        }

        /// <summary>
        /// Clean Up the scanner
        /// </summary>
        public void CleanUp()
        {
            // Stop scanning
            if (m_bScanning)
            {
                if (!DeviceNetDriver.StopScan(m_hCardHandle))
                {
                    Logger.LogHandler.Error("Can not stop scanning!");
                    return;
                }
            }

            // Sleep for a while
            System.Threading.Thread.Sleep(1000);

            // Offline card
            if (!DeviceNetDriver.Offline(m_hCardHandle))
            {
                Logger.LogHandler.Error("Can not offline!");
                return;
            }

            // Sleep for a while
            System.Threading.Thread.Sleep(1000);

            // Close card
            if (!DeviceNetDriver.CloseCard(m_hCardHandle))
            {
                Logger.LogHandler.Error("Can not close card!");
                return;
            }

            // Sleep for a while
            System.Threading.Thread.Sleep(1000);

            // Unload driver
            if (!DeviceNetDriver.UnloadDeviceNetDriver())
            {
                Logger.LogHandler.Error("Can not free DeviceNet driver!");
                return;
            }

            // Sleep for 4s for unloading driver
            System.Threading.Thread.Sleep(4000);
        }

        //protected void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        // Reset all IO of DeviceNet System
        //        m_objSolenoidBlock[0].ResetAllIO();
        //        m_objSolenoidBlock[1].ResetAllIO();
        //        m_objIonGaugeControl.CleanUp();

        //        // Sleep for a while for state updating completely
        //        System.Threading.Thread.Sleep(1000);

        //        // Clean Up the DeviceNet system
        //        CleanUp();

        //        ///////////////////////////////////////////////////////////////
        //        // TODO: Add more code here to clean up every thing before down
        //        ///////////////////////////////////////////////////////////////

        //    }
        //}
    }
}
