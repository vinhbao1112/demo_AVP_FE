using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Threading;
using System.Reflection;
using DeviceNetApp.Lib;
using DeviceNetApp.Bussiness;
using System.Xml.Serialization;
using System.IO;

namespace DeviceNetApp.DeviceNet
{
    public class DeviceNetController: DNSScanner
    {
        private Dictionary<UInt16, DNSEquipment> m_objDeviceList = new Dictionary<UInt16, DNSEquipment>();
        private Hashtable m_DevicePollingGroup = new Hashtable();

        private ConfigurationData objConfig = DeviceNetCore.Instance().ConfigData;

        public UInt16 PausePollingDeviceMacID = 0;
        public bool IsPausePollingDeviceMacID = false;

        public Boolean DoCommand(Command cmd)
        {
            try
            {
                switch (cmd.DeviceType)
                {
                    case DNSDeviceType.ION_GAUGE:
                        {
                            //Boolean bOn = Boolean.Parse(cmd.Value);
                            Logger.LogHandler.Debug("DoCommand " + cmd.CommandID + " " + cmd.Value.ToString());
                            SetValue((ushort)cmd.MacID, cmd.CommandID, cmd.Value);
                        }
                        break;
                    case DNSDeviceType.CONVECTRON_GAUGE:
                        {
                            Logger.LogHandler.Debug("DoCommand " + cmd.CommandID);
                            SetValue((ushort)cmd.MacID, cmd.CommandID, cmd.Value);
                        }
                        break;
                    case DNSDeviceType.SOLENOID_BLOCK:
                    case DNSDeviceType.SOLENOID_BLOCK_EX260:
                        {
                            Boolean bOn = Boolean.Parse(cmd.Value);
                            Logger.LogHandler.Debug("DoCommand " + cmd.CommandID + " " + bOn.ToString());
                            SetValue((ushort)cmd.MacID, cmd.CommandID, cmd.AdditionInfo2, bOn);
                        }
                        break;
                    case DNSDeviceType.VAT_VALVE:
                        {
                            //open close valve
                            if (cmd.CommandID == Constants.DNET_CMD_VAT_SET_POSITION ||
                                cmd.CommandID == Constants.DNET_CMD_VAT_SET_PRESSURE)
                            {
                                float fValue = Single.Parse(cmd.Value);
                                Logger.LogHandler.Debug("DoCommand " + cmd.CommandID + " " + fValue.ToString());
                                SetValue((ushort)cmd.MacID, cmd.CommandID, fValue);
                            }
                            else
                            {
                                Boolean bOn = Boolean.Parse(cmd.Value);
                                Logger.LogHandler.Debug("DoCommand " + cmd.CommandID + " " + bOn.ToString());
                                SetValue((ushort)cmd.MacID, cmd.CommandID, bOn);
                            }
                        }
                        break;
                    case DNSDeviceType.RSTi_ADAPTER:
                        {
                            if (cmd.CommandID == Constants.DNET_CMD_RSTI_ANALOG_VALUE)
                            {
                                ushort fValue = (ushort)Int16.Parse(cmd.Value);
                                Logger.LogHandler.Debug("DoCommand " + cmd.CommandID + " " + fValue.ToString());
                                SetValue((ushort)cmd.MacID, cmd.CommandID,cmd.AdditionInfo1,cmd.AdditionInfo2, fValue);
                            }
                            else if (cmd.CommandID == Constants.DNET_CMD_RSTI_BIT_ONOFF)
                            {
                                Boolean bOn = Boolean.Parse(cmd.Value);
                                Logger.LogHandler.Debug("DoCommand " + cmd.CommandID + " " + bOn.ToString());
                                SetValue((ushort)cmd.MacID, cmd.CommandID, cmd.AdditionInfo1, cmd.AdditionInfo2, bOn);
                            }
                        }
                        break;
                    case DNSDeviceType.MKS_MFC:
                        {
                            if (cmd.CommandID == Constants.DNET_CMD_CFG_ZERO_ADJUST)
                            {
                                Logger.LogHandler.Debug("DoCommand " + cmd.CommandID);
                                SetValue((ushort)cmd.MacID, cmd.CommandID);
                            }
                            else
                            {
                                float fValue = Single.Parse(cmd.Value);
                                Logger.LogHandler.Debug("DoCommand " + cmd.CommandID + " " + fValue.ToString());
                                SetValue((ushort)cmd.MacID, cmd.CommandID, fValue);
                            }
                        }
                        break;
                    default:
                        {

                        }
                        break;
                }
            }
            catch (System.Exception ex)
            {
                Logger.LogHandler.Error(ex.Message);
                return false;
            }
            return true;
        }

        public Boolean AddConfig(string strConfig)
        {
            try
            {
                if (!string.IsNullOrEmpty(strConfig))
                {
                    StopPolling();

                    XmlSerializer serializer = new XmlSerializer(typeof(ConfigurationData));
                    ConfigurationData objConfigData;

                    using (TextReader reader = new StringReader(strConfig))
                    {
                        objConfigData = (ConfigurationData)serializer.Deserialize(reader);
                    }

                    //CG
                    foreach (CG objCGConfig in objConfigData.CGDevices)
                    {
                        if (objCGConfig.MacID < 1)
                        {
                            Logger.LogHandler.Error("MacID Invalid:" + objCGConfig.MacID);
                            continue;
                        }
                        this.RegisterEquipment((ushort)objCGConfig.MacID, DNSDeviceType.CONVECTRON_GAUGE, DnetPollingGroup.Group2);
                        this.AddPolling((ushort)objCGConfig.MacID, DnetPollingGroup.GroupCGRelay, DnetPollingType.PollCGRelay);
                    }

                    StartPolling();
                }
            }
            catch (System.Exception ex)
            {
                Logger.LogHandler.Error(ex.Message);
                return false;
            }

            return true;
        }

        public override Boolean Initialize()
        {
            try
            {
                if (!base.Initialize())
                {
                    Logger.LogHandler.Error("Init card Fail!");
                    return false;
                }

                this.StopPolling();
                //register equipment
                //Solenoid
                foreach (Solenoid objSolenoidConfig in objConfig.SolenoidDevices)
                {
                    if (objSolenoidConfig.MacID < 1)
                    {
                        Logger.LogHandler.Error("MacID Invalid:" + objSolenoidConfig.MacID);
                        continue;
                    }

                    if (objSolenoidConfig.Type.ToUpper() == DeviceNetConstant.SOLENOID_BLOCK_EX260_TYPE)
                    {
                        this.RegisterEquipment((ushort)objSolenoidConfig.MacID, DNSDeviceType.SOLENOID_BLOCK_EX260, DnetPollingGroup.GroupSolenoid);
                    }
                    else // Default
                    {
                        this.RegisterEquipment((ushort)objSolenoidConfig.MacID, DNSDeviceType.SOLENOID_BLOCK, DnetPollingGroup.GroupSolenoid);
                    }
                }
                //IG
                foreach (IG objIGConfig in objConfig.IGDevices)
                {
                    if (objIGConfig.MacID < 1)
                    {
                        Logger.LogHandler.Error("MacID Invalid:" + objIGConfig.MacID);
                        continue;
                    }
                    this.RegisterEquipment((ushort)objIGConfig.MacID, DNSDeviceType.ION_GAUGE, DnetPollingGroup.Group2, objIGConfig.IGType, objIGConfig.IonGaugeSensitivityValue);
                    this.SetValue((ushort)objIGConfig.MacID, Constants.DNET_CMD_CFG_IG_SELECT_FILAMENT, objIGConfig.FilamentType);
                    this.SetValue((ushort)objIGConfig.MacID, Constants.DNET_CMD_CFG_IG_SELECT_EMISSION_CURRENT, objIGConfig.AutoCurrentEmission);
                }
                //CG
                foreach (CG objCGConfig in objConfig.CGDevices)
                {
                    if (objCGConfig.MacID < 1)
                    {
                        Logger.LogHandler.Error("MacID Invalid:" + objCGConfig.MacID);
                        continue;
                    }
                    this.RegisterEquipment((ushort)objCGConfig.MacID, DNSDeviceType.CONVECTRON_GAUGE, DnetPollingGroup.Group2, objCGConfig.CGTripPoint);
                    this.AddPolling((ushort)objCGConfig.MacID, DnetPollingGroup.GroupCGRelay, DnetPollingType.PollCGRelay);
                }
                //Gas
                foreach (Gas objGasConfig in objConfig.GasDevices)
                {
                    if (objGasConfig.MacID < 1)
                    {
                        Logger.LogHandler.Error("MacID Invalid:" + objGasConfig.MacID);
                        continue;
                    }
                    MKSModel eModel = GetMKSGasModel(objGasConfig.Model);
                    if (eModel == MKSModel.Undefined)
                    {
                        continue;
                    }
                    this.RegisterGas((ushort)objGasConfig.MacID, eModel, DnetPollingGroup.Group3);
                    this.SetValue((ushort)objGasConfig.MacID, Constants.DNET_CMD_CFG_RANGE, objGasConfig.RangeValue);
                    this.SetValue((ushort)objGasConfig.MacID, Constants.DNET_CMD_CFG_CALIBRATION_FACTOR, objGasConfig.CalibrationFactor);
                }
                //Flow cool
                foreach (FlowCool objFlowCoolConfig in objConfig.FlowCoolDevices)
                {
                    if (objFlowCoolConfig.MacID < 1)
                    {
                        Logger.LogHandler.Error("MacID Invalid:" + objFlowCoolConfig.MacID);
                        continue;
                    }
                    this.RegisterEquipment((ushort)objFlowCoolConfig.MacID, DNSDeviceType.FLOWCOOL, DnetPollingGroup.Group3, objFlowCoolConfig.PressureType);
                }
                //Flow cool
                foreach (VAT objVATConfig in objConfig.VATDevices)
                {
                    if (objVATConfig.MacID < 1)
                    {
                        Logger.LogHandler.Error("MacID Invalid:" + objVATConfig.MacID);
                        continue;
                    }
                    this.RegisterEquipment((ushort)objVATConfig.MacID, DNSDeviceType.VAT_VALVE, DnetPollingGroup.Group2);
                }
                //RSTi
                foreach (RSTi objRSTiConfig in objConfig.RSTiDevices)
                {
                    if (objRSTiConfig.MacID < 1)
                    {
                        Logger.LogHandler.Error("MacID Invalid:" + objRSTiConfig.MacID);
                        continue;
                    }

                    this.RegisterEquipment((ushort)objRSTiConfig.MacID, DNSDeviceType.RSTi_ADAPTER, DnetPollingGroup.Group4, objRSTiConfig.Slot);
                }

                //start polling 
                this.StartPolling();
            }
            catch (System.Exception ex)
            {
                Logger.LogHandler.Error(ex.Message);
                return false;
            }            

            return true;
        }

        public Boolean RegisterEquipment(UInt16 nMacId, DNSDeviceType eType, DnetPollingGroup eGroup, params object[] arrParams)
        {
            Boolean bRes = false;
            bRes = RegisterEquipment(nMacId, eType,arrParams);
            AddPolling(nMacId, eGroup, DnetPollingType.Poll);
            return bRes;
        }

        public Boolean RegisterEquipment(UInt16 nMacId, DNSDeviceType eType, params object[] arrParams)
        {
            DNSEquipment dns = null;

            if (IsRegistered(nMacId))
            {
                if (GetDevice(nMacId).DeviceType == eType)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            switch (eType)
            {
                case DNSDeviceType.SOLENOID_BLOCK:
                    dns = new DNSSolenoidBlock(this, nMacId);
                    break;
                case DNSDeviceType.SOLENOID_BLOCK_EX260:
                    dns = new DNSSolenoidEX260(this, nMacId);
                    break;
                case DNSDeviceType.CONVECTRON_GAUGE:
                    dns = new DNSMKSConvectionGauge(this, nMacId);
                    DNSMKSConvectionGauge cg = (DNSMKSConvectionGauge)dns;
                    cg.TripPointValue = (Single)arrParams[0];
                    break;
                case DNSDeviceType.ION_GAUGE:
                    float emissionSensitiveValue;

                    switch ((int)arrParams[0])
                    {
                        case 1:
                            dns = new DNSIonGaugeGP354(this, nMacId);
                            break;
                        case 2:
                            dns = new DNSIonGaugeITR100D(this, nMacId);
                            break;
                        case 3:
                            if (arrParams.Length >= 2 && arrParams[1] != null && float.TryParse(arrParams[1].ToString(), out emissionSensitiveValue))
                            {
                                dns = new DNSIonGaugeGP355(this, nMacId, emissionSensitiveValue);
                            }
                            else
                            {
                                dns = new DNSIonGaugeGP355(this, nMacId);
                            }
                            break;
                        case 4:
                            dns = new DNSIonGaugeMPT200(this, nMacId);
                            break;
                    }
                    break;
                case DNSDeviceType.MKS_BARATRON:
                    dns = new DNSMKSFlowcool(this, nMacId);
                    break;
                case DNSDeviceType.MKS_MFC:
                    dns = new DNSMKSGasFlow(this, nMacId);
                    break;
                case DNSDeviceType.VAT_VALVE:
                    dns = new VatValveDevice(this, nMacId);
                    break;
                case DNSDeviceType.FLOWCOOL:
                    dns = new DNSMKSFlowcool(this, nMacId);
                    ((DNSMKSFlowcool)dns).ControlType = (String)arrParams[0];
                    break;
                case DNSDeviceType.RSTi_ADAPTER:
                    dns = new DNSRSTiAdapter(this, nMacId);
                    ((DNSRSTiAdapter)dns).Slots = (List<Slot>)arrParams[0];                    
                    break;
            }
            if (dns == null)
            {
                return false;
            }

            if (!dns.Intialize())
            {
                return false;
            }

            dns.DeviceType = eType;

            m_objDeviceList.Add(nMacId, dns);
            return true;
        }

        public Boolean RegisterGas(UInt16 nMacId, MKSModel eGasModel, DnetPollingGroup eGroup)
        {
            Boolean bRes = false;
            bRes = RegisterGas(nMacId, eGasModel);
            AddPolling(nMacId, eGroup, DnetPollingType.Poll);
            return bRes;
        }

        private Boolean RegisterGas(UInt16 nMacId, MKSModel eGasModel)
        {
            DNSEquipment dns = null;

            if (IsRegistered(nMacId))
            {
                if (GetDevice(nMacId).DeviceType == DNSDeviceType.MKS_MFC)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            dns = new DNSMKSGasFlow(this, nMacId, eGasModel);

            if (dns == null)
            {
                return false;
            }

            if (!dns.Intialize())
            {
                return false;
            }

            dns.DeviceType = DNSDeviceType.MKS_MFC;

            m_objDeviceList.Add(nMacId, dns);
            return true;
        }
        public Boolean AddPolling(UInt16 nMacId, DnetPollingGroup eGroup, DnetPollingType eType)
        {
            DNSEquipment dnsd = GetDevice(nMacId);
            if (dnsd != null)
            {
                MethodInfo method = dnsd.GetType().GetMethod(eType.ToString());
                if (method == null)
                {
                    return false;
                }

                DnetPollingObject dpo = new DnetPollingObject(dnsd, method);
                if (m_DevicePollingGroup.ContainsKey(eGroup))
                {
                    DnetGroup deviceList = (DnetGroup)m_DevicePollingGroup[eGroup];
                    deviceList.Add(dpo);
                }
                else
                {
                    DnetGroup deviceList = new DnetGroup(eGroup);
                    if (m_DevicePollingGroup.Count == 0)
                    {
                        // Add CheckDnetBusStatus
                        AddPollingBusStatus(ref deviceList);
                    }
                    deviceList.Add(dpo);
                    m_DevicePollingGroup.Add(eGroup, deviceList);
                }
                return true;
            }
            return false;
        }

        protected Boolean AddPollingBusStatus(ref DnetGroup deviceList)
        {
            MethodInfo method = this.GetType().GetMethod(DnetPollingType.Poll.ToString());
            if (method == null)
            {
                return false;
            }
            DnetPollingObject dpo = new DnetPollingObject(this, method);
            deviceList.Add(dpo);
            return true;
        }

        public Boolean IsRegistered(UInt16 nMacId)
        {
            if (m_objDeviceList.ContainsKey(nMacId))
            {
                return true;
            }
            return false;
        }

        public DNSEquipment GetDevice(UInt16 nMacId)
        {
            if (IsRegistered(nMacId))
            {
                return m_objDeviceList[nMacId];
            }
            return null;
        }

        public Boolean SetPropertyChangedHandler(UInt16 nMacId, string strDnetProp, Object objReceiver, string strPropName)
        {
            if (nMacId == 0)
            {
                this.SetPropertyChangedHandler(strDnetProp, objReceiver, strPropName);
            }
            else if (IsRegistered(nMacId))
            {
                return m_objDeviceList[nMacId].SetPropertyChangedHandler(strDnetProp, objReceiver, strPropName);
            }

            return false;
        }

        public Boolean SetPropertyChangedHandler(UInt16 nMacId, Object objReceiver, string strPropName, object objSignalInfo)
        {
            if (IsRegistered(nMacId))
            {
                return m_objDeviceList[nMacId].SetPropertyChangedHandler(objReceiver, strPropName, objSignalInfo);
            }

            return false;
        }

        public Boolean SetValue(UInt16 nMacId, string strParamId, params object[] arrParams)
        {
            if (IsRegistered(nMacId))
            {
                return m_objDeviceList[nMacId].SetValue(strParamId, arrParams);
            }
            return false;
        }

        public Boolean SendMessage(UInt16 nMacId, params object[] arrParams)
        {
            if (IsRegistered(nMacId))
            {
                return m_objDeviceList[nMacId].SendMessage(arrParams);
            }
            return false;
        }

        /// <summary>
        /// Set Property Changed Receiver
        /// </summary>
        public bool SetPropertyChangedHandler(String strDnetPropertyName, Object objReceiver, String strPropertyName)
        {
            Boolean bRes = false;
            switch (strDnetPropertyName)
            {
                case Constants.DNET_PROP_COMMUNICATION_STATUS:
                    {
                        bRes = m_objCommunicationStatusProp.Init(objReceiver, strPropertyName);
                    }
                    break;
            }
            return bRes;
        }

        public void StartPolling()
        {
            foreach (DnetGroup group in m_DevicePollingGroup.Values)
            {
                group.Run();
            }
        }

        public void StopPolling()
        {
            foreach (DnetGroup group in m_DevicePollingGroup.Values)
            {
                group.Stop();
            }
        }

        public void Dispose()
        {
            // clean up devices
            //
            foreach (DNSEquipment dns in m_objDeviceList.Values)
            {
                dns.CleanUp();
            } 
            
            foreach (DnetGroup group in m_DevicePollingGroup.Values)
            {
                group.Dispose();
            }

            //clear data
            m_objDeviceList.Clear();
            m_DevicePollingGroup.Clear();

            // Sleep for a while for state updating completely
            System.Threading.Thread.Sleep(1000);

            // Clean Up the DeviceNet system
            CleanUp();
        }

        private MKSModel GetMKSGasModel(String strModel)
        {
            MKSModel eModel = MKSModel.Undefined;
            try
            {
                eModel = (MKSModel)Enum.Parse(typeof(MKSModel), strModel);
            }
            catch (System.Exception ex)
            {
                eModel = MKSModel.Undefined;
                Logger.LogHandler.Error("Gas Type is not valid:" + strModel);
                Logger.LogHandler.Error(ex.Message);
            }
            return eModel;
        }

        #region Collect Data
        /// <author>
        /// <name>Do Xuan Dat</name>
        /// <date> 2009-12-14</date>
        /// </author>
        /// <summary>
        /// 
        /// </summary>
        /// <para></para>
        /// <returns></returns>       
        public List<string> CollectData()
        {
            List<String> lstCollectedData = new List<String>();
            // Get device to collect
            
            foreach (KeyValuePair<UInt16, DNSEquipment> pair in m_objDeviceList)
            {
                pair.Value.CollectData(ref lstCollectedData);
                //Indicate the first time polling
                //pair.Value.FirstRead = m_bFirstRead;
            }

            String strDeviceNetBus = CollectDnetBusStatus();
            if (!String.IsNullOrEmpty(strDeviceNetBus))
            {
                lstCollectedData.Add(strDeviceNetBus);
            }

            return lstCollectedData;
        }

        public string CollectDnetBusStatus()
        {
            string strResCmd = string.Empty;
            string sValue = "unknown";
            if (BusStatus == EquipmentStatus.CLOSED)
            {
                sValue = "false";
            }
            else if (BusStatus == EquipmentStatus.OPENED)
            {
                sValue = "true";
            }

            if (DeviceNetCore.Instance().DataCollector.IsChangedData("DnetBusStatus", (int)BusStatus))
            {
                strResCmd = "0_DeviceStatus" + "," + sValue;
            }

            return strResCmd;
        }

        /// <author>
        /// <name>Do Xuan Dat</name>
        /// <date> 2009-12-14</date>
        /// </author>
        /// <summary>
        /// 
        /// </summary>
        /// <para></para>
        /// <returns></returns>
        public Boolean RequestData()
        {
            DeviceNetCore.Instance().DataCollector.SendDataToAVPAgain();
            //Indicate the first time polling
            foreach (KeyValuePair<UInt16, DNSEquipment> pair in m_objDeviceList)
            {
                pair.Value.FirstRead = true;
            }
            return true;
        }        
        #endregion

        public void TurnOffAllIG()
        {
            foreach (DNSEquipment equip in m_objDeviceList.Values)
            {
                if (equip is DNSGenericIonGauge)
                {
                    equip.SetValue(Constants.DNET_CMD_FILAMENT_ON_OFF, false);
                }
            }
        }
    }
}
