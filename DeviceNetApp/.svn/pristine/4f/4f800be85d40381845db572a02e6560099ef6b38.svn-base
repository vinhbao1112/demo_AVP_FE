using System;
using System.Collections.Generic;
using System.Text;
using DeviceNetApp.DeviceNet;
using DeviceNetApp.Lib;
using System.Xml;
using System.Text.RegularExpressions;
using System.Timers;
using System.Threading;
using System.IO;

namespace DeviceNetApp.Bussiness
{
    class DeviceNetCore
    {
        public event deleExitApp evtExitApp;
        private static DeviceNetCore m_instance = null;
        private DeviceNetController m_objDeviceController = null;
        private AVPDeviceNetConnection m_objConnection = null;
        private ConfigurationData m_objConfigData = null;
        private DataCollector m_objDataCollector = null;
        private Boolean m_bDeviceNetInit = false;
        public static DeviceNetCore Instance()
        {
            if (m_instance == null)
            {
                m_instance = new DeviceNetCore();
            }
            return m_instance;
        }

        public ConfigurationData ConfigData
        {
            get { return m_objConfigData; }
        }

        public DeviceNetController DeviceController
        {
            get { return m_objDeviceController; }
        }

        public Boolean IsDeviceNetInit
        {
            get { return m_bDeviceNetInit; }
        }

        public AVPDeviceNetConnection DeviceConnection
        {
            get { return m_objConnection; }
        }

        public DataCollector DataCollector
        {
            get { return m_objDataCollector; }
        }

        public Boolean IsConnectToAVP
        {
            get
            {
                if (m_objConnection != null)
                {
                    return m_objConnection.IsConnectedWithAVP;
                }
                return false;
            }
        }

        public Boolean DeviceNetActive
        {
            get
            {
                if (m_objDeviceController != null)
                {
                    return m_objDeviceController.BusStatus == EquipmentStatus.OPENED ? true : false;
                }
                return false;
            }
        }

        public Boolean Initialize()
        {
            Logger.StaticInitialize();

            m_objConnection = new AVPDeviceNetConnection();
            if (!m_objConnection.Initialize())
            {
                Logger.LogHandler.Error("Init connection fail!");
                return false;
            } 
            //check file is exists,continue to initialize 
            if (System.IO.File.Exists(Constants.CONFIG_PATH + Constants.CONFIG_FILE) ||
                System.IO.File.Exists(Constants.CXX_CONFIG_PATH + Constants.CONFIG_FILE) || System.IO.File.Exists(Constants.DEVICENETAPP_CONFIG_PATH + Constants.CONFIG_FILE))
            {               
                if (LoadConfig())
                {
                    //initialize device net and command processor
                    if (!InitializeDeviceNet())
                    {
                        return false;
                    }
                }
            }
                //file does not exists,just continue
            else
            {

            }
            return true;
        }

        private Boolean InitializeDeviceNet()
        {
            m_objDeviceController = new DeviceNetController();

            m_objDataCollector = new DataCollector();

            m_objDeviceController.CardName = m_objConfigData.CardName;
            m_objDeviceController.BaudRate = m_objConfigData.BaudRate;

            if (!m_objDeviceController.Initialize())
            {
                Logger.LogHandler.Error("Init DeviceNet fail!");
                return false;
            }
            //Wait for a while before collect data
            System.Threading.Thread.Sleep(5000);

            if (!m_objDataCollector.Initialize())
            {
                Logger.Error("Init Data Collector fail!");
                return false;
            }

            m_bDeviceNetInit = true;
            
            return true;
        }

        public Boolean Uninitialize()
        {
            if (m_objConnection != null)
            {
                m_objConnection.Dispose();
            }
            Logger.Uninitialize();

            UninitializeDeviceNet();

            return true;
        }

        private Boolean UninitializeDeviceNet()
        {
            if (m_objDeviceController != null)
            {
                m_objDeviceController.Dispose();
            }

            if (m_objDataCollector != null && m_objDataCollector.CollectDataTimer != null)
            {
                // Stop collect data
                m_objDataCollector.CollectDataTimer.Stop();
            }
                        
            return true;
        }

        private Boolean LoadConfig()
        {
            try
            {
                if (!System.IO.File.Exists(Constants.CONFIG_PATH + Constants.CONFIG_FILE) &&
                    !System.IO.File.Exists(Constants.CXX_CONFIG_PATH + Constants.CONFIG_FILE) && !System.IO.File.Exists(Constants.DEVICENETAPP_CONFIG_PATH + Constants.CONFIG_FILE))
                {
                    return false;
                }

                if (System.IO.File.Exists(Constants.CONFIG_PATH + Constants.CONFIG_FILE))
                {
                    m_objConfigData = (ConfigurationData)Serializeable.DeSerialize(Constants.CONFIG_PATH + Constants.CONFIG_FILE, typeof(ConfigurationData));
                }
                else if (System.IO.File.Exists(Constants.CXX_CONFIG_PATH + Constants.CONFIG_FILE))
                {
                    m_objConfigData = (ConfigurationData)Serializeable.DeSerialize(Constants.CXX_CONFIG_PATH + Constants.CONFIG_FILE, typeof(ConfigurationData));
                }
                else if (System.IO.File.Exists(Constants.DEVICENETAPP_CONFIG_PATH + Constants.CONFIG_FILE))
                {
                    m_objConfigData = (ConfigurationData)Serializeable.DeSerialize(Constants.DEVICENETAPP_CONFIG_PATH + Constants.CONFIG_FILE, typeof(ConfigurationData));
                }
                
                if (m_objConfigData == null)
                {
                    return false;
                }
            }
            catch (System.Exception ex)
            {
                Logger.LogHandler.Error(ex.Message);
                return false;
            }
            return true;
        }

        private Boolean SaveConfig(String strConfig)
        {
            try
            {
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(strConfig);
                // Check exit folder
                if (Directory.Exists(Constants.CONFIG_PATH))
                {
                    xml.Save(Constants.CONFIG_PATH + Constants.CONFIG_FILE);
                }
                else
                {
                    if (Directory.Exists(Constants.CXX_CONFIG_PATH))
                    {
                        xml.Save(Constants.CXX_CONFIG_PATH + Constants.CONFIG_FILE);
                    }
                    else
                    {
                        if (!Directory.Exists(Constants.DEVICENETAPP_CONFIG_PATH))
                        {
                            Directory.CreateDirectory(Constants.DEVICENETAPP_CONFIG_PATH);
                        }

                        xml.Save(Constants.DEVICENETAPP_CONFIG_PATH + Constants.CONFIG_FILE);
                    }
                }
                
            }
            catch (System.Exception ex)
            {
                Logger.LogHandler.Error(ex.Message);
                return false;
            }
            return true;
        }

        private Boolean CompareConfig(String strConfig)
        {
            try
            {
                XmlDocument xmlCur = new XmlDocument();
                if (Directory.Exists(Constants.CONFIG_PATH))
                {
                    xmlCur.Load(Constants.CONFIG_PATH + Constants.CONFIG_FILE);
                }
                else if (Directory.Exists(Constants.CXX_CONFIG_PATH))
                {
                    xmlCur.Load(Constants.CXX_CONFIG_PATH + Constants.CONFIG_FILE);
                }
                else if (Directory.Exists(Constants.DEVICENETAPP_CONFIG_PATH))
                {
                    xmlCur.Load(Constants.DEVICENETAPP_CONFIG_PATH + Constants.CONFIG_FILE);
                }

                String strCurrent = xmlCur.InnerXml;

                int res = String.Compare(Regex.Replace(strCurrent, @"\s+", ""), Regex.Replace(strConfig, @"\s+", ""));
                if (res != 0)
                {
                    return false;
                }
            }
            catch (System.Exception ex)
            {
                Logger.LogHandler.Error(ex.Message);
                return false;
            }
            return true;
        }

        public Boolean ReInitialize(String strConfig)
        {
            try
            {
                //deviceNet is not initialized
                if (!m_bDeviceNetInit)
                {
                    SaveConfig(strConfig);
                    LoadConfig();
                    InitializeDeviceNet();
                }
                else //deviceNet is online
                {
                    //file does not change
                    if (CompareConfig(strConfig))
                    {
                        return true;
                    }

                    // Stop collect data
                    m_objDataCollector.CollectDataTimer.Stop();

                    //Down current deviceNET
                    UninitializeDeviceNet();

                    System.Threading.Thread.Sleep(1000);
                    //save new config
                    SaveConfig(strConfig);
                    if (LoadConfig())
                    {
                        InitializeDeviceNet();
                    }
                }            
            }
            catch (System.Exception ex)
            {
                Logger.LogHandler.Error(ex.Message);
                return false;
            }
            
            return true;
        }

        public Boolean AddConfig(String strConfig)
        {
            try
            {
                if (m_bDeviceNetInit)
                {
                    m_objDeviceController.AddConfig(strConfig);
                }
            }
            catch (System.Exception ex)
            {
                Logger.LogHandler.Error(ex.Message);
                return false;
            }

            return true;
        }

        private DeviceNetCore()
        {

        }

        public void TurnOffAllIG()
        {
            if (m_objDeviceController != null)
            {
                m_objDeviceController.TurnOffAllIG();
            }
        }

        public void ReceiveExitCmd()
        {
            if (evtExitApp != null)
            {
                evtExitApp();
            }
        }
    }
}
