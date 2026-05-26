using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using DeviceNetApp.Lib;

namespace DeviceNetApp.DeviceNet
{
    public class DNSSolenoidBlock: DNSEquipment
    {
        /// <summary>
        /// Byte array containing the bit array readback
        /// </summary>
        private Byte[] m_arrReadBitData = null;

        /// <summary>
        /// Convert to Unsigned Int the read back data
        /// </summary>
        private UInt16 m_uReadBackBitData = 0;

        /// <summary>
        /// Unsigned Int value of write data
        /// </summary>
        private UInt16 m_uWriteBitData = 0;

        /// <summary>
        /// Previous readback data
        /// </summary>
        private UInt16 m_uReadBackBitDataPrev = 0;

        /// <summary>
        /// Byte array containing the bit array set point
        /// </summary>
        private Byte[] m_arrWriteBitData = null;

        /// <summary>
        /// Indicate the first time polling
        /// </summary>
        private Boolean m_bFirstRead = true;

       private Hashtable m_ReadBackProperties = new Hashtable();

        public DNSSolenoidBlock(DNSScanner p_objMaster, UInt16 nMacId)
            : base(p_objMaster, nMacId)
        {
            // 2 X 8 bit = 16 bits = 16 I/O valves
            m_arrReadBitData = new Byte[2]; 
            m_arrWriteBitData = new Byte[2];
        }

        /// <summary>
        /// Init the Solenoid Block devices Component
        /// </summary>
        /// <param name="CardHandle"></param>
        /// <param name="DeviceId"></param>
        /// <returns></returns>
        public override Boolean Intialize()
        {
            return RegisterEquipment(m_objMaster.CardHandle, m_nMacId, 2, 2, 0);
        }

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
                            Int32 nBit = (Int32) arrParams[0];
                            bool bOn = (bool)arrParams[1];
                            ushort uBitMask = (ushort)(1 << nBit);
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

        /// <summary>
        /// Set Property Changed Receiver
        /// </summary>
        public override bool SetPropertyChangedHandler(String strDnetPropertyName, Object objReceiver, String strPropertyName)
        {
            bool bRes = false;
            try
            {
                int nBit;
                if (!int.TryParse(strDnetPropertyName,out nBit))
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

        /// <summary>
        /// Collect Data
        /// </summary>
        public override string CollectData(ref List<string> plstCollectedData)
        {
            // For 16 bit in m_arrReadBitData
            for (int iBitIndex = 0; iBitIndex < 16; iBitIndex++)
            {
                string strResCmd = string.Empty;

                ushort uBitMask = (ushort)(1 << iBitIndex);
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

        /// <summary>
        /// Read the bit array and store to array and unsigned in value
        /// </summary>
        public void Read()
        {
            if (this.ReadData())
            {
                if (m_DeviceConfig.Input1Size == 2)
                {
                    // Store the previous
                    m_uReadBackBitDataPrev = m_uReadBackBitData;

                    // Read data
                    m_arrReadBitData[0] = m_arrInputBuffer[0];
                    m_arrReadBitData[1] = m_arrInputBuffer[1];                    

                    // Convert
                    m_uReadBackBitData = BitConverter.ToUInt16(m_arrReadBitData, 0);

                    if (m_bFirstRead)
                    {
                        //Logger.LogHandler.Debug("Data Read back = " + m_uReadBackBitData.ToString("X"));
                        m_uReadBackBitDataPrev = m_uReadBackBitData;
                        m_uWriteBitData = m_uReadBackBitData;
                        m_bFirstRead = false;
                    }
                    else
                    {
                        if (Changed())
                        {
                            // Do something
                        }

                        // Log
                        //Logger.LogHandler.Debug("Data Read back = " + m_uReadBackBitData.ToString("X"));
                    }
                }
            }
        }

        /// <summary>
        /// Write the bit array to device
        /// </summary>
        public void Write()
        {
            if (DeviceNetDriver.IsDeviceActive(m_DeviceStatus.StatusCode))
            {
                m_arrOutputBuffer = new Byte[2];
                m_arrOutputBuffer[0] = m_arrWriteBitData[0];
                m_arrOutputBuffer[1] = m_arrWriteBitData[1];
                WriteData();
            }
        }

        /// <summary>
        /// Check if data of solenoid block is changed
        /// </summary>
        /// <returns></returns>
        private Boolean Changed()
        {
            return ((m_uReadBackBitDataPrev ^ m_uReadBackBitData) != 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uBitMask"></param>
        /// <returns></returns>
        public Boolean GetState(UInt16 uBitMask)
        {
            return ((m_uReadBackBitData & uBitMask) != 0);
        }

        /// <summary>
        /// Get all value of bit array
        /// </summary>
        /// <returns></returns>
        public UInt16 getWholeValue()
        {
            return m_uReadBackBitData;
        }

        /// <summary>
        /// Turn On or Open the device
        /// </summary>
        /// <param name="uBitMask"></param>
        public void On(UInt16 uBitMask)
        {
            m_uWriteBitData = (UInt16)(m_uWriteBitData | uBitMask);
            Logger.LogHandler.Debug("Write Data = " + m_uWriteBitData.ToString("X"));
            Byte[] arrVal = BitConverter.GetBytes(m_uWriteBitData);
            m_arrWriteBitData[0] = arrVal[0];
            m_arrWriteBitData[1] = arrVal[1];
            SyncData();
        }

        /// <summary>
        /// Turn Off or Close the device
        /// </summary>
        /// <param name="uBitMask"></param>
        public void Off(UInt16 uBitMask)
        {
            m_uWriteBitData = (UInt16)(m_uWriteBitData & (~uBitMask));
            Logger.LogHandler.Debug("Write Data = " + m_uWriteBitData.ToString("X"));
            Byte[] arrVal = BitConverter.GetBytes(m_uWriteBitData);
            m_arrWriteBitData[0] = arrVal[0];
            m_arrWriteBitData[1] = arrVal[1];
            SyncData();
        }

        /// <summary>
        /// Read & write data
        /// </summary>
        public void SyncData()
        {
            GetDeviceStatus();
            Read();
            Write();
        }

        /// <summary>
        /// Poll bit value
        /// </summary>
        public override void Poll()
        {
            GetDeviceStatus();
            Read();
            foreach (DictionaryEntry pair in m_ReadBackProperties)
            {
                ushort uBitMask = (ushort) (1 << (int)pair.Key);
                Boolean state = this.GetState(uBitMask);
                PropertyObject prop = (PropertyObject)pair.Value;
                prop.SetValue(state? EquipmentStatus.OPENED: EquipmentStatus.CLOSED);
            }
        }

        /// <summary>
        /// Reset all IO of Solenoid Block
        /// </summary>
        /// <returns></returns>
        public Boolean ResetAllIO()
        {
            // Reset all IO
            m_uWriteBitData = 0;
            m_arrWriteBitData[0] = 0;
            m_arrWriteBitData[1] = 0;

            // Write to device
            Write();

            return true;
        }
    }
}
