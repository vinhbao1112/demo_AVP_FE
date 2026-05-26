using System;
using System.Collections.Generic;
using System.Text;
using DeviceNetApp.Lib;

namespace DeviceNetApp.DeviceNet
{
    public class DNSMKSConvectionGauge : DNSEquipment
    {

        #region "Update Data Objects"
        protected PropertyObject m_objPressureProp = new PropertyObject();
        protected PropertyObject m_objRelayProp = new PropertyObject();
        #endregion

        /// <summary>
        /// Byte array containing the pressure value
        /// </summary>
        private Byte[] m_arrPressVal = null;

        /// <summary>
        /// Pressure value read from device
        /// </summary>
        private Single m_fPressure = 0;

        private Boolean m_IsCalibrating = true;

        /// <summary>
        /// CG Relay Status
        /// </summary>
        private EquipmentStatus m_CGRelay = EquipmentStatus.UNKNOWN;

        /// <author>Tinh Le</author>
        /// <date>2018-05-21</date>
        /// <summary>
        /// Trip Point Valuve
        /// </summary>
        private Single m_TripPointValue = 0f;
        public Single TripPointValue
        {
            get { return m_TripPointValue; }
            set
            {
                m_TripPointValue = value;
            }
        }

        public DNSMKSConvectionGauge(DNSScanner p_objMaster, UInt16 nMacId)
            : base(p_objMaster, nMacId)
        {
            m_arrPressVal = new Byte[4];
        }

        /// <summary>
        /// Init Convectron Gauge Component
        /// </summary>
        /// <param name="CardHandle"></param>
        /// <param name="DeviceId"></param>
        /// <returns></returns>
        public override Boolean Intialize()
        {
            return RegisterEquipment(m_objMaster.CardHandle, m_nMacId, 5, 0, 64);
        }

        /// <summary>
        /// Set Property Changed Receiver
        /// </summary>
        public override bool SetPropertyChangedHandler(String strDnetPropertyName, Object objReceiver, String strPropertyName)
        {
            bool bRes = false;
            try
            {
                switch (strDnetPropertyName)
                {
                    case Constants.DNET_PROP_PRESSURE:
                        {
                            m_objPressureProp.Init(objReceiver, strPropertyName);
                        }
                        break;
                    case Constants.DNET_PROP_CG_RELAY:
                        {
                            m_objRelayProp.Init(objReceiver, strPropertyName);
                        }
                        break;
                    default:
                        bRes = false;
                        break;
                }
            }
            catch (Exception ex)
            {
                Logger.LogHandler.Error(ex.Message);
            }
            return bRes;
        }

        /// <summary>
        /// Get the pressure from the real device
        /// </summary>
        public override void Poll()
        {
            this.GetDeviceStatus();
            if (this.ReadData())
            {
                if (m_DeviceConfig.Input1Size == 5)
                {
                    m_arrPressVal[0] = m_arrInputBuffer[1];
                    m_arrPressVal[1] = m_arrInputBuffer[2];
                    m_arrPressVal[2] = m_arrInputBuffer[3];
                    m_arrPressVal[3] = m_arrInputBuffer[4];
                    m_fPressure = BitConverter.ToSingle(m_arrPressVal, 0);

                    // Log
                    // Logger.LogHandler.Debug("CG Pressure = " + m_fPressure.ToString());

                    if (m_fPressure < 1.0E-3f)
                    {
                        m_fPressure = 1.0E-3f;
                    }

                    //m_objPressureProp.SetValue(m_fPressure);
                }
            }
            else if (!DeviceNetDriver.IsDeviceActive(m_DeviceStatus.StatusCode))
            {
                m_fPressure = Constants.DNET_ERROR_VALUE;
            }
        }

        /// <summary>
        /// Collect Data
        /// </summary>
        public override string CollectData(ref List<string> plstCollectedData)
        {
            AddListOfParameter(ref plstCollectedData, CollectCGPressure());
            AddListOfParameter(ref plstCollectedData, CollectCGRelayStatus());

            // Collect device status
            base.CollectData(ref plstCollectedData);
            
            return string.Empty;
        }

        /// <summary>
        /// Collect CG Pressure
        /// </summary>
        public string CollectCGPressure()
        {
            string strResCmd = string.Empty;
            string sCGInfo = m_nMacId + "_Pressure";
            if (IsChangedData(sCGInfo, m_fPressure))
            {
                strResCmd = sCGInfo + "," + m_fPressure.ToString();
            }

            return strResCmd;
        }

        /// <summary>
        /// Collect CG Relay Status
        /// </summary>
        public string CollectCGRelayStatus()
        {
            string strResCmd = string.Empty;
            string sCGInfo = m_nMacId + "_CGRelay";
            string sValue = "false";
            if (m_CGRelay == EquipmentStatus.CLOSED)
            {
                sValue = "false";
            }
            else if (m_CGRelay == EquipmentStatus.OPENED)
            {
                sValue = "true";
            }

            if (IsChangedData(sCGInfo, (int)m_CGRelay))
            {
                strResCmd = sCGInfo + "," + sValue;
            }

            return strResCmd;
        }

        /// <summary>
        /// Poll CG Relay Status
        /// </summary>
        public void PollCGRelay()
        {
            GetCGRelayStatus();
            //m_objRelayProp.SetValue(m_CGRelay);
        }

        /// <summary>
        /// Get CG Relay Status
        /// </summary>
        protected EquipmentStatus GetCGRelayStatus()
        {
            if (!m_IsCalibrating)
            {
                if (DeviceNetDriver.IsDeviceActive(m_DeviceStatus.StatusCode))
                {
                    m_iExplicitMsgSize = 1;
                    m_ExplicitData[0] = 13;
                    if (SendExplicitMessage(0x0E, 0x35, 0x01))
                    {
                        Int32 iTimeout = 10000; //10s
                        Wait4ExplicitReplyMsg(iTimeout);
                        if (m_ExplicitDataReceive != null && m_ExplicitDataReceive.Length > 0)
                        {
                            int iResult = m_ExplicitDataReceive[0];
                            if (iResult == 0)
                            {
                                m_CGRelay = EquipmentStatus.CLOSED;
                            }
                            else
                            {
                                m_CGRelay = EquipmentStatus.OPENED;
                            }
                        }
                    }
                }
                else
                {
                    m_CGRelay = EquipmentStatus.CLOSED;
                }
            }
            return m_CGRelay;
        }


        /// <summary>
        /// CG Pressure
        /// </summary>
        public Single Pressure
        {
            get
            {
                return m_fPressure;
            }
        }

        /// <summary>
        /// CG Set ATM/VAC
        /// </summary>
        public override bool SetValue(String sCmdType, params object[] arrParams)
        {
            Boolean bResult = false;
            try
            {
                // Suspend polling CG Relay
                m_IsCalibrating = true;

                // Sleep a while to make sure polling paused
                System.Threading.Thread.Sleep(2000);

                Logger.Error(sCmdType);
                switch (sCmdType)
                {
                    case "SetATM":
                        m_iExplicitMsgSize = 4;
                        m_ExplicitData[0] = 0;
                        m_ExplicitData[1] = 0;
                        m_ExplicitData[2] = 62;
                        m_ExplicitData[3] = 68;
                        bResult = SendExplicitMessage(0x4C, 0x31, 0x01);
                        break;
                    case "SetVAC":
                        m_iExplicitMsgSize = 4;
                        m_ExplicitData[0] = 111;
                        m_ExplicitData[1] = 18;
                        m_ExplicitData[2] = 131;
                        m_ExplicitData[3] = 58;
                        bResult = SendExplicitMessage(0x4B, 0x31, 0x01);
                        break;
                    case "SetCGChamberTripPoint":
                    case "SetCGForelineTripPoint":
                    case "SetMPTripPoint":
                    case "SetTurboMPTripPoint":
                        {
                            Single value = 0f;
                            if (Single.TryParse(arrParams[0].ToString(), out value))
                            {
                                bResult = SetCGTripPoint(value);
                            }
                        }
                        break;
                }

                // Wait reply message if sending OK
                if (bResult)
                {
                    Wait4ExplicitReplyMsg(10000);
                }

                // Resume polling CG relay
                m_IsCalibrating = false;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }

            return bResult;
        }

        /// <author>Tinh Le</author>
        /// <date>2018-05-21</date>
        /// <summary>
        /// CG Setup
        /// </summary>
        public override void  Setup()
        {
            try
            {
                // To Set Trip Points Type
                SetCGTripPoint(TripPointValue);
                Wait4ExplicitReplyMsg();

                //To Enable Trip Point Type
                m_iExplicitMsgSize = 2;
                m_ExplicitData[0] = 6;
                m_ExplicitData[1] = 1;
                SendExplicitMessage(0x10, 0x35, 0x01); // Set Service, Class Code = 53 , Class Instance = 1 
                Wait4ExplicitReplyMsg();
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
            m_IsCalibrating = false;
        }

        /// <author>Tinh Le</author>
        /// <date>2018-05-22</date>
        /// <summary>
        /// SetTripPoint
        /// </summary>
        private Boolean SetCGTripPoint(Single value)
        {
            Boolean result = false;
            try
            {
                Byte[] byteSetvalue = BitConverter.GetBytes(value);
                m_iExplicitMsgSize = 5;
                m_ExplicitData[0] = 5;
                m_ExplicitData[1] = byteSetvalue[0];
                m_ExplicitData[2] = byteSetvalue[1];
                m_ExplicitData[3] = byteSetvalue[2];
                m_ExplicitData[4] = byteSetvalue[3];
                result = SendExplicitMessage(0x10, 0x35, 0x01); // Set Service, Class Code = 53 , Class Instance = 1 
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
            return result;
        }
    }
}
