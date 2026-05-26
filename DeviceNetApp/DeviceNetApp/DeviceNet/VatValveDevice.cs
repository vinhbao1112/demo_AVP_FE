using System;
using System.Collections.Generic;
using System.Text;
using DeviceNetApp.Lib;

namespace DeviceNetApp.DeviceNet
{
    public class VatValveDevice : DNSEquipment
    {
        #region "Update Data Objects"
        protected PropertyObject m_objPressureProp = new PropertyObject();
        protected PropertyObject m_objPositionProp = new PropertyObject();
        protected PropertyObject m_objPositionStatusProp = new PropertyObject();
        #endregion


        #region "Constants"
        const Single POSITION_SCALE = 100f;
        const Single PRESSURE_SCALE = 100f;
        #endregion


        /// <summary>
        /// Valve Postition
        /// </summary>
        private Int32 m_nPositionVal = 0;

        /// <summary>
        /// Valve Pressure
        /// </summary>
        private Int32 m_nPressureVal = 0;

        /// <summary>
        /// Valve Position Status: open/close/mid
        /// </summary>
        private EquipmentStatus m_ePositionStatus = EquipmentStatus.UNKNOWN;

        /// <summary>
        /// Pressure Data Array returned by Device
        /// </summary>
        private Byte[] m_arrPressureVal = null;

        /// <summary>
        /// Position Data Array returned by Device
        /// </summary>
        private Byte[] m_arrPositionVal = null;

        public VatValveDevice(DNSScanner p_objMaster, UInt16 nMacId)
            : base(p_objMaster, nMacId)
        {
            m_arrPressureVal = new Byte[2];
            m_arrPositionVal = new Byte[2];
        }

        /// <summary>
        /// Init MFC device
        /// </summary>
        /// <param name="CardHandle"></param>
        /// <param name="DeviceId"></param>
        /// <returns></returns>
        public override Boolean Intialize()
        {
            bool bResult = RegisterEquipment(m_objMaster.CardHandle, m_nMacId, 6, 4, 64);
            OpenCloseValve(false);
            return bResult;
        }

        /// <summary>
        /// Set Value
        /// </summary>
        public override bool SetValue(string strCmd, params object[] arrParams)
        {
            bool bRes = false;
            try
            {
                if (arrParams.Length > 0)
                    Logger.LogHandler.Debug("SetValue " + strCmd + " " + arrParams[0].ToString());
                else
                    Logger.LogHandler.Debug("SetValue " + strCmd);
                switch (strCmd)
                {
                    case Constants.DNET_CMD_VAT_SET_POSITION:
                        {
                            float fValue = (float)arrParams[0];
                            bRes = PositionSetPoint(fValue);
                        }
                        break;
                    case Constants.DNET_CMD_VAT_SET_PRESSURE:
                        {
                            float fValue = (float)arrParams[0];
                            bRes = PressureSetPoint(fValue);
                        }
                        break;
                    case Constants.DNET_CMD_VAT_OPEN_CLOSE:
                        {
                            bool bOpen = (bool)arrParams[0];
                            bRes = OpenCloseValve(bOpen);
                        }
                        break;
                    case Constants.DNET_CMD_VAT_HOLD:
                        {
                            bRes = HoldValve();
                        }
                        break;
                    case Constants.DNET_CMD_VAT_LEARN:
                        {
                            OpenCloseValve(true);
                            SetLearnPressureLimit(10000);
                            System.Threading.Thread.Sleep(10000);
                            bRes = LearnPressure();
                        }
                        break;
                    case Constants.DNET_CMD_VAT_AUTO_ZERO:
                        {
                            bRes = AutoZero();
                        }
                        break;
                    case Constants.DNET_CMD_VAT_GAIN_FACTOR:
                        {
                            Int32 nValue = (Int32)arrParams[0];
                            if (nValue >= 0)
                            {
                                bRes = SetGainFactor(nValue);
                            }
                        }
                        break;
                    case Constants.DNET_CMD_VAT_ZERO_CONTROL:
                        {
                            Boolean bValue = (Boolean)arrParams[0];
                            bRes = SetZeroControl(bValue);                            
                        }
                        break;
                    case Constants.DNET_CMD_VAT_SET_ACCESS_MODE:
                        {
                            Int32 nValue = (Int32)arrParams[0];
                            bRes = SetAccessMode(nValue);
                        }
                        break;
                    case Constants.DNET_CMD_VAT_SEND_EXPLICIT:
                        {
                            String strValue = (String)arrParams[0];
                            ManualSendExplicit(strValue);
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
        /// Set Property Changed Receiver
        /// </summary>
        public override bool SetPropertyChangedHandler(String strDnetPropertyName, Object objReceiver, String strPropertyName)
        {
            bool bRes = false;
            try
            {
                switch (strDnetPropertyName)
                {
                    case Constants.DNET_PROP_VAT_PRESSURE:
                        {
                            m_objPressureProp.Init(objReceiver, strPropertyName);
                        }
                        break;
                    case Constants.DNET_PROP_VAT_POSITION:
                        {
                            m_objPositionProp.Init(objReceiver, strPropertyName);
                        }
                        break;
                    case Constants.DNET_PROP_VAT_POSITION_STATUS:
                        {
                            m_objPositionStatusProp.Init(objReceiver, strPropertyName);
                        }
                        break;
                    case Constants.DNET_PROP_COMMUNICATION_STATUS:
                        {
                            m_objCommunicationStatusProp.Init(objReceiver, strPropertyName);
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
        /// Get the flow rate from the real device
        /// </summary>
        public override void Poll()
        {
            this.GetDeviceStatus();
            if (this.ReadData())
            {
                //Exception status = m_arrInputBuffer[0]
                m_arrPressureVal[0] = m_arrInputBuffer[1];
                m_arrPressureVal[1] = m_arrInputBuffer[2];

                m_arrPositionVal[0] = m_arrInputBuffer[3];
                m_arrPositionVal[1] = m_arrInputBuffer[4];

                byte nValveStatus = m_arrInputBuffer[5];
                if ((nValveStatus & 0x03) == 1)
                {
                    // closed
                    m_ePositionStatus = EquipmentStatus.CLOSED;
                }
                else if ((nValveStatus & 0x03) == 2)
                {
                    // opened
                    m_ePositionStatus = EquipmentStatus.OPENED;
                }
                else
                {
                    // middle
                    m_ePositionStatus = EquipmentStatus.UNKNOWN;
                }


                m_nPositionVal = BitConverter.ToUInt16(m_arrPositionVal, 0);
                m_nPressureVal = BitConverter.ToUInt16(m_arrPressureVal, 0);

                Single fPosition = m_nPositionVal / POSITION_SCALE;
                Single fPressureVal = m_nPressureVal / PRESSURE_SCALE;

                m_objPositionProp.SetValue(fPosition);
                m_objPressureProp.SetValue(fPressureVal);
                m_objPositionStatusProp.SetValue(m_ePositionStatus);
            }
        }

        /// <summary>
        /// Collect Data
        /// </summary>
        public override string CollectData(ref List<string> plstCollectedData)
        {
            AddListOfParameter(ref plstCollectedData, CollectVATPressure());
            AddListOfParameter(ref plstCollectedData, CollectVATPosition());
            AddListOfParameter(ref plstCollectedData, CollectVATOpenClose());

            // For collect device status
            base.CollectData(ref plstCollectedData);

            return string.Empty;
        }

        /// <summary>
        /// Collect VAT Pressure
        /// </summary>
        public string CollectVATPressure()
        {
            string strResCmd = string.Empty;
            if (IsChangedData("VATPressure", m_nPressureVal))
            {
                strResCmd = m_nMacId + "_VATPressure" + "," + m_nPressureVal.ToString();
            }

            return strResCmd;
        }

        /// <summary>
        /// Collect VAT Position
        /// </summary>
        public string CollectVATPosition()
        {
            string strResCmd = string.Empty;
            if (IsChangedData("VATPosition", m_nPositionVal))
            {
                strResCmd = m_nMacId + "_VATPosition" + "," + m_nPositionVal.ToString();
            }

            return strResCmd;
        }

        /// <summary>
        /// Collect VAT OpenClose
        /// </summary>
        public string CollectVATOpenClose()
        {
            string strResCmd = string.Empty;
            string strValue = String.Format("{0:00}", (int)m_ePositionStatus);
            if (IsChangedData("VATOpenClose", (int)m_ePositionStatus))
            {
                strResCmd = m_nMacId + "_VATOpenClose" + "," + strValue;
            }

            return strResCmd;
        }

        /// <summary>
        /// Set Pressure Setpoint
        /// </summary>
        /// <param name="newSetPoint"></param>
        /// <returns></returns>
        public Boolean PressureSetPoint(Single newSetPoint)
        {
            if (DeviceNetDriver.IsDeviceActive(m_DeviceStatus.StatusCode))
            {
                //appSetPoint range is 1-100, dnetSetPoint range is 0 - 10000
                float fDnetSetPoint = newSetPoint * PRESSURE_SCALE;
                if (fDnetSetPoint > 10000f)
                {
                    fDnetSetPoint = 10000f;
                }

                if (fDnetSetPoint < 0.0f)
                {
                    fDnetSetPoint = 0.0f;
                }

                UInt16 PressureSP = (UInt16)fDnetSetPoint; 

                // Convert SP to byte array
                Byte[] arrPressureSP = BitConverter.GetBytes(PressureSP);

                // Construct write array
                m_arrOutputBuffer = new Byte[4];

                // Set Value
                m_arrOutputBuffer[0] = 0; // Mode "Control Valve"
                m_arrOutputBuffer[1] = arrPressureSP[0];
                m_arrOutputBuffer[2] = arrPressureSP[1];
                m_arrOutputBuffer[3] = 0; // Pressure control mode

                // Write
                return WriteData();
            }

            return false;
        }

        /// <summary>
        /// Set Position Setpoint
        /// </summary>
        /// <param name="newSetPoint"></param>
        /// <returns></returns>
        public Boolean PositionSetPoint(Single newSetPoint)
        {
            if (DeviceNetDriver.IsDeviceActive(m_DeviceStatus.StatusCode))
            {
                //appSetPoint range is 1-100, dnetSetPoint range is 0 - 10000
                float fDnetSetPoint = newSetPoint * POSITION_SCALE;
                if (fDnetSetPoint > 10000f)
                {
                    fDnetSetPoint = 10000f;
                }

                if (fDnetSetPoint < 0.0f)
                {
                    fDnetSetPoint = 0.0f;
                }

                UInt16 nPositionSP = (UInt16)fDnetSetPoint;

                // Convert SP to byte array
                Byte[] arrPosSP = BitConverter.GetBytes(nPositionSP);

                // Construct write array
                m_arrOutputBuffer = new Byte[4];

                // Set Value
                m_arrOutputBuffer[0] = 0; // Mode "Control Valve"
                m_arrOutputBuffer[1] = arrPosSP[0];
                m_arrOutputBuffer[2] = arrPosSP[1];
                m_arrOutputBuffer[3] = 1; // Position control mode

                // Write
                return WriteData();
            }

            return false;
        }

        public Boolean OpenCloseValve(Boolean bOpen)
        {
            Boolean bRes = false;
            try
            {
                Byte nControlMode;

                if (bOpen)
                {
                    nControlMode = 2;
                }
                else
                {
                    nControlMode = 1;
                }

                // Construct write array
                m_arrOutputBuffer = new Byte[4];

                // Set Value
                m_arrOutputBuffer[0] = nControlMode; // Mode "Control Valve"
                m_arrOutputBuffer[1] = 0;
                m_arrOutputBuffer[2] = 0;
                m_arrOutputBuffer[3] = 1;

                // Write
                bRes = WriteData();
            }
            catch (Exception ex)
            {
                Logger.LogHandler.Error(ex.Message);
            }
            return bRes;
        }

        public Boolean HoldValve()
        {
            if (DeviceNetDriver.IsDeviceActive(m_DeviceStatus.StatusCode))
            {
                Byte nControlMode = 3; // Hold

                // Construct write array
                m_arrOutputBuffer = new Byte[4];

                // Set Value
                m_arrOutputBuffer[0] = nControlMode; // Mode "Control Valve"
                m_arrOutputBuffer[1] = 0;
                m_arrOutputBuffer[2] = 0;
                m_arrOutputBuffer[3] = 1; 

                // Write
                return WriteData();
            }

            return false;
        }


        public Boolean LearnPressure()
        {
            Boolean bRes = false;
            try
            {
                m_iExplicitMsgSize = 1;
                m_ExplicitData[0] = 0;
                bRes = SendExplicitMessage(100, 51, 1); // Set Service = 100, Class Code = 51, Class Instance = 1
                if (bRes)
                {
                    Wait4ExplicitReplyMsg(2000);
                }
            }
            catch (Exception ex)
            {
                Logger.LogHandler.Error(ex.Message);
            }
            return bRes;
        }

        // nLimit: 0 - 10000
        public Boolean SetLearnPressureLimit(Int32 nLimit)
        {
            Boolean bRes = false;
            try
            {

                UInt16 uLimit = (UInt16)nLimit;

                // Convert SP to byte array
                Byte[] arrLimit = BitConverter.GetBytes(uLimit);

                m_iExplicitMsgSize = 3;
                m_ExplicitData[0] = 100;
                m_ExplicitData[1] = arrLimit[0];
                m_ExplicitData[2] = arrLimit[1];

                bRes = SendExplicitMessage(16, 51, 1); // Set Service = 100, Class Code = 51, Class Instance = 1
                if (bRes)
                {
                    Wait4ExplicitReplyMsg(2000);
                }
            }
            catch (Exception ex)
            {
                Logger.LogHandler.Error(ex.Message);
            }
            return bRes;
        }

        public Boolean AutoZero()
        {
            Boolean bRes = false;
            try
            {
                m_iExplicitMsgSize = 0;
                bRes = SendExplicitMessage(75, 49, 1); // Set Service = 75, Class Code = 49, Class Instance = 1
                if (bRes)
                {
                    Wait4ExplicitReplyMsg(2000);
                }
            }
            catch (Exception ex)
            {
                Logger.LogHandler.Error(ex.Message);
            }
            return bRes;
        }

        public Boolean SetGainFactor(Int32 nValue)
        {
            Boolean bRes = false;
            try
            {
                m_iExplicitMsgSize = 2;
                m_ExplicitData[0] = 105; // Attribute ID
                m_ExplicitData[1] = (byte)nValue;
                bRes = SendExplicitMessage(16, 51, 1); // Set Service = 16, Class Code = 51, Class Instance = 1
                if (bRes)
                {
                    Wait4ExplicitReplyMsg(2000);
                }
            }
            catch (Exception ex)
            {
                Logger.LogHandler.Error(ex.Message);
            }
            return bRes;
        }

        public Boolean SetZeroControl(Boolean bEnable)
        {
            Boolean bRes = false;
            try
            {
                m_iExplicitMsgSize = 2;
                m_ExplicitData[0] = 102; // Attribute ID
                m_ExplicitData[1] = bEnable ? (byte)1 : (byte)0;
                bRes = SendExplicitMessage(16, 49, 1); // Set Service = 16, Class Code = 49, Class Instance = 1
                if (bRes)
                {
                    Wait4ExplicitReplyMsg(2000);
                }
            }
            catch (Exception ex)
            {
                Logger.LogHandler.Error(ex.Message);
            }
            return bRes;
        }

        // AccessMode: Local, Remote, Locked
        public Boolean SetAccessMode(Int32 nAccessMode)
        {
            Boolean bRes = false;
            try
            {
                m_iExplicitMsgSize = 2;
                m_ExplicitData[0] = 107; // Attribute ID
                m_ExplicitData[1] = (byte)nAccessMode;
                bRes = SendExplicitMessage(16, 100, 1);
                if (bRes)
                {
                    Wait4ExplicitReplyMsg(2000);
                }

            }
            catch (Exception ex)
            {
                Logger.LogHandler.Error(ex.Message);
            }
            return bRes;
        }

        public Boolean ManualSendExplicit(String strMsg)
        {
            Boolean bRes = false;
            try
            {
                char[] delimiters = new char[1] { ',' };
                string[] ss = strMsg.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                if (ss.Length < 3)
                {
                    return false;
                }

                Int16 ServiceID = Int16.Parse(ss[0]);
                Int16 ClassID = Int16.Parse(ss[1]);
                Int16 InstanceID = Int16.Parse(ss[2]);

                m_iExplicitMsgSize = 0;
                ushort index = 0;
                for (int i = 3; i < ss.Length; i++)
                {
                    m_ExplicitData[index] = Convert.ToByte(ss[i]);
                    index++;
                }
                m_iExplicitMsgSize = index;
                if (SendExplicitMessage(ServiceID, ClassID, InstanceID))
                {
                    Wait4ExplicitReplyMsg(2000);
                }
            }
            catch (Exception ex)
            {
                Logger.LogHandler.Error(ex.Message);
            }
            return bRes;
        }
    }
}
