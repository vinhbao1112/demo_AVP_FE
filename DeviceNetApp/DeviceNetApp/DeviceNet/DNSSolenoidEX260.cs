using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using DeviceNetApp.Lib;

namespace DeviceNetApp.DeviceNet
{
    /// <author>Hoa Nguyen</author>
    /// <date>2017-07-17</date>
    /// <summary>
    /// SolenoidEX260 class
    /// </summary>
    public class DNSSolenoidEX260 : DNSEquipment
    {
        /// <summary>
        /// Unsigned Int value of write data
        /// </summary>
        private UInt32 m_uWriteBitData = 0;

        /// <summary>
        /// Byte array containing the bit array set point
        /// </summary>
        private Byte[] m_arrWriteBitData = null;

        private Hashtable m_ReadBackProperties = new Hashtable();

        /// <author>Hoa Nguyen</author>
        /// <date>2017-07-17</date>
        /// <summary>
        /// Constructor. Init array data with 4 bytes
        /// </summary>
        public DNSSolenoidEX260(DNSScanner p_objMaster, UInt16 nMacId)
            : base(p_objMaster, nMacId)
        {
            // 4 X 8 bit = 32 bits = 32 I/O valves
            m_arrWriteBitData = new Byte[4];
        }

        /// <summary>
        /// Init the Solenoid Block devices Component
        /// Device with zero input size and 4 bytes output size
        /// </summary>
        public override Boolean Intialize()
        {
            return RegisterEquipment(m_objMaster.CardHandle, m_nMacId, 0, 4, 0);
        }

        /// <author>Hoa Nguyen</author>
        /// <date>2017-07-17</date>
        /// <summary>
        /// Set Value
        /// </summary>
        public override bool SetValue(string strCmd, params object[] arrParams)
        {
            bool bRes = false;
            try
            {
                Logger.LogHandler.Debug("SetValue " + strCmd + " Bit: " + arrParams[0].ToString() + " " + arrParams[1].ToString());
                switch (strCmd)
                {
                    case Constants.DNET_CMD_SOLENOID_BIT_ON_OFF:
                        {
                            Int32 nBit = (Int32)arrParams[0];
                            bool bOn = (bool)arrParams[1];

                            UInt32 uBitMask = (UInt32)(1 << nBit);
                            if (bOn)
                            {
                                this.On(uBitMask);
                            }
                            else
                            {
                                this.Off(uBitMask);
                            }
                            bRes = true;
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

        /// <author>Hoa Nguyen</author>
        /// <date>2017-07-17</date>
        /// <summary>
        /// Set Property Changed Receiver
        /// </summary>
        public override bool SetPropertyChangedHandler(String strDnetPropertyName, Object objReceiver, String strPropertyName)
        {
            bool bRes = false;
            try
            {
                int nBit;
                if (!int.TryParse(strDnetPropertyName, out nBit))
                {
                    return false;
                }

                if (m_ReadBackProperties.ContainsKey(nBit))
                {
                    PropertyObject objProp = (PropertyObject)m_ReadBackProperties[nBit];
                    objProp.Init(objReceiver, strPropertyName);
                }
                else
                {
                    PropertyObject objProp = new PropertyObject();
                    objProp.Init(objReceiver, strPropertyName);
                    m_ReadBackProperties.Add(nBit, objProp);
                }
            }
            catch (Exception ex)
            {
                Logger.LogHandler.Error(ex.Message);
            }
            return bRes;
        }

        /// <author>Hoa Nguyen</author>
        /// <date>2017-07-17</date>
        /// <summary>
        /// Collect Data
        /// </summary>
        public override string CollectData(ref List<string> plstCollectedData)
        {
            // For 16 bit in m_arrReadBitData
            for (int iBitIndex = 0; iBitIndex < 32; iBitIndex++)
            {
                string strResCmd = string.Empty;

                int uBitMask = (int)(1 << iBitIndex);
                Boolean state = this.GetState(uBitMask);

                //For building command
                string sSolenoidBitInfo = m_nMacId + "_BitStatus" + iBitIndex;

                if (IsChangedData(sSolenoidBitInfo, state))
                {
                    strResCmd = sSolenoidBitInfo + "," + state.ToString();
                }
                // Collect data
                AddListOfParameter(ref plstCollectedData, strResCmd);
            }

            // For collect device status
            base.CollectData(ref plstCollectedData);

            return string.Empty;
        }

        /// <author>Hoa Nguyen</author>
        /// <date>2017-07-17</date>
        /// <summary>
        /// Write the bit array to device
        /// </summary>
        public void Write()
        {
            if (DeviceNetDriver.IsDeviceActive(m_DeviceStatus.StatusCode))
            {
                m_arrOutputBuffer = new Byte[4];
                m_arrOutputBuffer[0] = m_arrWriteBitData[0];
                m_arrOutputBuffer[1] = m_arrWriteBitData[1];
                m_arrOutputBuffer[2] = m_arrWriteBitData[2];
                m_arrOutputBuffer[3] = m_arrWriteBitData[3];
                WriteData();
            }
        }

        /// <author>Hoa Nguyen</author>
        /// <date>2017-07-17</date>
        /// <summary>
        /// Get status of a bit value (true: on, false: off)
        /// </summary>
        public Boolean GetState(int uBitMask)
        {
            return ((m_uWriteBitData & uBitMask) != 0);
        }

        /// <author>Hoa Nguyen</author>
        /// <date>2017-07-17</date>
        /// <summary>
        /// Turn On or Open the device
        /// </summary>
        /// <param name="uBitMask"></param>
        public void On(UInt32 uBitMask)
        {
            m_uWriteBitData = (UInt32)(m_uWriteBitData | uBitMask);
            Logger.Debug("Write Data = " + m_uWriteBitData.ToString("X"));
            Byte[] arrVal = BitConverter.GetBytes(m_uWriteBitData);
            m_arrWriteBitData[0] = arrVal[0];
            m_arrWriteBitData[1] = arrVal[1];
            m_arrWriteBitData[2] = arrVal[2];
            m_arrWriteBitData[3] = arrVal[3];
            SyncData();
        }

        /// <author>Hoa Nguyen</author>
        /// <date>2017-07-17</date>
        /// <summary>
        /// Turn Off or Close the device
        /// </summary>
        /// <param name="uBitMask"></param>
        public void Off(UInt32 uBitMask)
        {
            m_uWriteBitData = (UInt32)(m_uWriteBitData & (~uBitMask));
            Logger.LogHandler.Debug("Write Data = " + m_uWriteBitData.ToString("X"));
            Byte[] arrVal = BitConverter.GetBytes(m_uWriteBitData);
            m_arrWriteBitData[0] = arrVal[0];
            m_arrWriteBitData[1] = arrVal[1];
            m_arrWriteBitData[2] = arrVal[2];
            m_arrWriteBitData[3] = arrVal[3];
            SyncData();
        }

        /// <author>Hoa Nguyen</author>
        /// <date>2017-07-17</date>
        /// <summary>
        /// Read & write data
        /// </summary>
        public void SyncData()
        {
            GetDeviceStatus();
            Write();
        }

        /// <author>Hoa Nguyen</author>
        /// <date>2017-07-17</date>
        /// <summary>
        /// Poll bit value
        /// </summary>
        public override void Poll()
        {
            GetDeviceStatus();

            foreach (DictionaryEntry pair in m_ReadBackProperties)
            {
                int uBitMask = (int)(1 << (int)pair.Key);
                Boolean state = this.GetState(uBitMask);
                PropertyObject prop = (PropertyObject)pair.Value;
                prop.SetValue(state ? EquipmentStatus.OPENED : EquipmentStatus.CLOSED);
            }
        }
    }
}
