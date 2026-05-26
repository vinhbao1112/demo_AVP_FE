using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using RSTiApdater;
using DeviceNetApp.Lib;
using DeviceNetApp.Bussiness;

namespace DeviceNetApp.DeviceNet
{

    public class DNSRSTiAdapter: DNSEquipment
    {
        const int NUMBER_OF_INPUT_BYTE = 18;
        const int NUMBER_OF_OUTPUT_BYTE = 28;
        PropertyObject objProp = new PropertyObject();
        /// <summary>
        /// Byte array containing the byte array readback
        /// </summary>
        private Byte[] m_arrReadByteData = null;

        /// <summary>
        /// Byte array containing the byte array set point
        /// </summary>
        private Byte[] m_arrWriteByteData = null;            

        /// <summary>
        /// Unsigned Int value of write data
        /// </summary>
        private byte m_uWriteByteData = 0;    

        protected Byte[] m_arrTmpAnalogWriteBuffer = null;

        protected Byte[] m_arrTmpAnalogReadBuffer = null;

        //private Hashtable m_ReadBackProperties = new Hashtable();

        //private Hashtable m_SignalsInfo = new Hashtable();

        private Dictionary<Int32, SlotInfo> m_dtInputPosition = new Dictionary<Int32, SlotInfo>();
        private Dictionary<Int32, SlotInfo> m_dtOutputPosition = new Dictionary<Int32, SlotInfo>();
       

        private List<Slot> m_lstSlot = null;
        public List<Slot> Slots
        {
            set { m_lstSlot = value; }
        }

        public DNSRSTiAdapter(DNSScanner p_objMaster, UInt16 nMacId)
            : base(p_objMaster, nMacId)
        {
            // 2 X 8 bit = 16 bits = 16 I/O valves
            
        }

        /// <summary>
        /// Init the Solenoid Block devices Component
        /// </summary>
        /// <param name="CardHandle"></param>
        /// <param name="DeviceId"></param>
        /// <returns></returns>
        public override Boolean Intialize()
        {
            //need to calculate input/output size
            //build map for read write data            
            if (!PrepareInfo())
            {
                return false;
            }

            m_arrReadByteData = new Byte[m_uInputSize]; //need to allow user config
            m_arrInputBuffer = new Byte[m_uInputSize];
            m_arrWriteByteData = new Byte[m_uOutputSize];
            m_arrOutputBuffer = new byte[m_uOutputSize];
            return RegisterEquipment(m_objMaster.CardHandle, m_nMacId, m_uInputSize, m_uOutputSize, 64);
        }

        /// <summary>
        /// Set Value
        /// </summary>
        public override bool SetValue(string strCmd, params object[] arrParams)
        {
            bool bRes = false;
            try
            {
                Logger.LogHandler.Debug("SetValue " + strCmd + " Slot: " + arrParams[0].ToString() +
                    " Channel: " + arrParams[1].ToString() + " " + arrParams[2].ToString());
                int slot = (int)arrParams[0];
                int channel = (int)arrParams[1];

                if (!m_dtOutputPosition.ContainsKey(slot*100+channel))
                {
                    return false;
                }

                int bytePos = m_dtOutputPosition[slot*100+channel].BytePos;
                int bitPos = m_dtOutputPosition[slot * 100 + channel].BitPos;
                switch (strCmd)
                {
                    case Constants.DNET_CMD_RSTI_BIT_ONOFF:
                        {            
                            Boolean bOn = (bool)arrParams[2];
                            byte uBitMask = (byte)(1 << bitPos);
                            if (bOn)
                            {
                                this.On(bytePos, uBitMask);
                            }
                            else
                            {
                                this.Off(bytePos, uBitMask);
                            }
                            bRes = true;                           
                            
                        }
                        break;
                    case Constants.DNET_CMD_RSTI_ANALOG_VALUE:
                        {
                            ushort iValue = (ushort)arrParams[2];

                            m_arrTmpAnalogWriteBuffer = new byte[2];
                            m_arrTmpAnalogWriteBuffer = BitConverter.GetBytes(iValue);
                            m_arrWriteByteData[bytePos] = m_arrTmpAnalogWriteBuffer[0];
                            m_arrWriteByteData[bytePos + 1] = m_arrTmpAnalogWriteBuffer[1];
                            Write();
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
        public override bool SetPropertyChangedHandler(Object objReceiver, 
                                                    String strPropertyName,object objSignalInfo)
        {
            bool bRes = false;
            try
            {
                //RSTiAdapterSignalInfo SignalInfo = (RSTiAdapterSignalInfo)objSignalInfo;
                //if (m_ReadBackProperties.ContainsKey(SignalInfo.SignalName))
                //{
                //    PropertyObject objProp = (PropertyObject)m_ReadBackProperties[SignalInfo.SignalName];
                //    objProp.Init(objReceiver, strPropertyName);
                //}
                //else
                //{
                //    PropertyObject objProp = new PropertyObject();
                //    objProp.Init(objReceiver, strPropertyName);
                //    m_ReadBackProperties.Add(SignalInfo.SignalName, objProp);
                //    m_SignalsInfo.Add(SignalInfo.SignalName, SignalInfo);
                //}
               
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
            CollectInputOutputSlot(ref plstCollectedData, "Input");

            // Collect Output data for one time when initialize

            if (FirstRead)
            {
                CollectInputOutputSlot(ref plstCollectedData, "Output");
                FirstRead = false;
            }

            // Collect device status
            base.CollectData(ref plstCollectedData);

            return string.Empty;
        }

        public string CollectInputOutputSlot(ref List<string> lstCollectedData, String sDictionaryInfo)
        {
            Dictionary<int, SlotInfo> m_Position = new Dictionary<int, SlotInfo>();
            Byte[] m_arrByte = null;
            switch (sDictionaryInfo)
            {
                case "Input":
                    m_Position = m_dtInputPosition;
                    m_arrByte = m_arrReadByteData;
                    break;
                case "Output":
                    m_Position = m_dtOutputPosition;
                    m_arrByte = m_arrWriteByteData;
                    break;
            }

            foreach (KeyValuePair<Int32, SlotInfo> pair in m_Position)
            {
                string strResCmd = string.Empty;
                byte[] temp = new byte[2];

                SlotInfo inforSlot = pair.Value;
                String sSignalInfo = m_nMacId + "_Slot" + inforSlot.Slot + "_Channel" + inforSlot.Channel;

                if (inforSlot.SlotType == 0)
                {
                    temp[0] = m_arrByte[inforSlot.BytePos];
                    temp[1] = m_arrByte[inforSlot.BytePos + 1];
                    short fValue = BitConverter.ToInt16(temp, 0);

                    // Verify value is updated or not
                    if (IsChangedData(sSignalInfo, fValue))
                    {
                        strResCmd = sSignalInfo + "," + fValue.ToString();
                    }
                }
                else if (inforSlot.SlotType == 1)
                {
                    byte uBitMask = (byte)(1 << inforSlot.BitPos);
                    Boolean bState = GetState(m_arrByte[inforSlot.BytePos], uBitMask);

                    // Update value to string
                    string strValue = "false";
                    if (bState)
                    {
                        strValue = "true";
                    }

                    if (IsChangedData(sSignalInfo, bState))
                    {
                        strResCmd = sSignalInfo + "," + strValue;
                    }
                }

                // Collect data
                AddListOfParameter(ref lstCollectedData, strResCmd);
            }

            return string.Empty;
        }

        /// <summary>
        /// Read the bit array and store to array and unsigned in value
        /// </summary>
        public void Read()
        {
            if (this.ReadData())
            {
                //// Read data
                Array.Copy(m_arrInputBuffer, m_arrReadByteData,m_uInputSize);
                //byte[] temp = new byte[2];
                //foreach (DictionaryEntry pair in m_SignalsInfo)
                //{
                //    RSTiAdapterSignalInfo objSignal = (RSTiAdapterSignalInfo)pair.Value;

                //    if (objSignal.IOType == RSTiAdapterSignalInfo.IO.Input)
                //    {
                //        if (objSignal.ChannelType == "AI")
                //        {
                //            temp[0] = m_arrReadByteData[objSignal.BytePosition - 1];
                //            temp[1] = m_arrReadByteData[objSignal.BytePosition];
                //            short uRawValue = BitConverter.ToInt16(temp, 0);
                //            float fValue = (float)((uRawValue - objSignal.MinRSTiScale)
                //                * ((objSignal.MaxRealDeviceScale - objSignal.MinRealDeviceScale) /
                //                (objSignal.MaxRSTiScale - objSignal.MinRSTiScale)) +
                //                objSignal.MinRealDeviceScale);
                //            PropertyObject prop = (PropertyObject)m_ReadBackProperties[objSignal.SignalName];
                //            if ((float)prop.GetValue() != fValue)
                //            {
                //                prop.SetValue(fValue);
                //            }
                //        }
                //        else if (objSignal.ChannelType == "DI")
                //        {
                //            byte uBitMask = (byte)(1 << objSignal.BitPosition);
                //            Boolean bState = GetState(m_arrReadByteData[objSignal.BytePosition - 1], uBitMask);
                //            PropertyObject prop = (PropertyObject)m_ReadBackProperties[objSignal.SignalName];
                //            if (prop.PropDataType == PropertyObject.DataType.System_Boolean)
                //            {
                //                if ((Boolean)prop.GetValue() != bState)
                //                {
                //                    prop.SetValue(bState);
                //                }
                //            }
                //            else if (prop.PropDataType == PropertyObject.DataType.IOLib_Base_EquipmentStatus)
                //            {
                //                if (bState)
                //                {
                //                    prop.SetValue(EquipmentStatus.OPENED);
                //                }
                //                else if (!bState)
                //                {
                //                    prop.SetValue(EquipmentStatus.CLOSED);
                //                }
                //            }

                //        }
                //    }

                //}                
            }
            
        }

        /// <summary>
        /// Write the bit array to device
        /// </summary>
        public void Write()
        {
            if (DeviceNetDriver.IsDeviceActive(m_DeviceStatus.StatusCode))
            {                
                Array.Copy(m_arrWriteByteData, m_arrOutputBuffer, m_uOutputSize);                
                WriteData();
            }
        }

        /// <summary>
        /// Check if data of solenoid block is changed
        /// </summary>
        /// <returns></returns>
        private Boolean Changed(byte uByte1, byte uByte2)
        {
            return ((uByte1 ^ uByte2) != 0);            
        }

        /// <summary>
        /// Check if data of solenoid block is changed
        /// </summary>
        /// <returns></returns>
        private Boolean Changed(byte uLowByte1, byte uHighByte1, byte uLowByte2, byte uHighByte2)
        {
            return (((uLowByte1 ^ uLowByte2) != 0) | ((uHighByte1 ^ uHighByte2) != 0));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uBitMask"></param>
        /// <returns></returns>
        public Boolean GetState(byte bByte,UInt16 uBitMask)
        {
            return ((bByte & uBitMask) != 0);            
        }
                

        /// <summary>
        /// Turn On or Open the device
        /// </summary>
        /// <param name="uBitMask"></param>
        public void On(int iByteIndex, byte uBitMask)
        {
            m_uWriteByteData = m_arrWriteByteData[iByteIndex];
            m_uWriteByteData = (byte)(m_uWriteByteData | uBitMask);
            Logger.LogHandler.Debug("Write Data = " + m_uWriteByteData.ToString("X"));
            m_arrWriteByteData[iByteIndex] = m_uWriteByteData;
            SyncData();
        }

        /// <summary>
        /// Turn Off or Close the device
        /// </summary>
        /// <param name="uBitMask"></param>
        public void Off(int iByteIndex, byte uBitMask)
        {
            m_uWriteByteData = m_arrWriteByteData[iByteIndex];
            m_uWriteByteData = (byte)(m_uWriteByteData & (~uBitMask));
            Logger.LogHandler.Debug("Write Data = " + m_uWriteByteData.ToString("X"));
            m_arrWriteByteData[iByteIndex] = m_uWriteByteData;
            SyncData();
        }

        /// <summary>
        /// Read & write data
        /// </summary>
        public void SyncData()
        {
            GetDeviceStatus();
            ///Read();
            if (IsDeviceActive())
            {
                Write();
            }            
        }

        /// <summary>
        /// Poll bit value
        /// </summary>
        public override void Poll()
        {
            try
            {
                GetDeviceStatus();
                Read();
            }
            catch (System.Exception ex)
            {
                Logger.LogHandler.Error("Poll:"+ ex.Message);
            }
        }

        /// <summary>
        /// Reset all IO of Solenoid Block
        /// </summary>
        /// <returns></returns>
        public Boolean ResetAllIO()
        {
            // Reset all IO
            m_uWriteByteData = 0;
            Array.Clear(m_arrWriteByteData, 0, m_arrWriteByteData.Length);

            // Write to device
            Write();

            return true;
        }

        private Boolean PrepareInfo()
        {
            try
            {
                List<Slot> output = new List<Slot>();
                List<Slot> input = new List<Slot>();
                for (int i = 0; i < m_lstSlot.Count; i++)
                {
                    if (m_lstSlot[i].SlotType == "AI" || m_lstSlot[i].SlotType == "DI")
                    {
                        input.Add(m_lstSlot[i]);
                    }
                    else if (m_lstSlot[i].SlotType == "AO" || m_lstSlot[i].SlotType == "DO")
                    {
                        output.Add(m_lstSlot[i]);
                    }
                }

                m_uInputSize = (ushort)CalculateSize(input, m_dtInputPosition);
                m_uOutputSize = (ushort)CalculateSize(output, m_dtOutputPosition);
            }
            catch (System.Exception ex)
            {
                Logger.LogHandler.Error(ex.Message);
                return false;	
            }
            return true;
        }

        private Int32 CalculateSize(List<Slot> lstSlot,Dictionary<Int32,SlotInfo> dtMap)
        {
            //with unstatus,byte size is zero,if status,byte size is 1
            Int32 byteSize = 0;
            try
            {
                //arrange slot base on slot index
                int iSortedSize = 1;
                while (iSortedSize < lstSlot.Count)
                {
                    Inser(lstSlot, iSortedSize, lstSlot[iSortedSize]);
                    iSortedSize++;
                }

                for (int i = 0; i < lstSlot.Count; i++)
                {
                    if (lstSlot[i].SlotType == "AI" || lstSlot[i].SlotType == "AO")
                    {                        
                        for (int j = 1; j <= lstSlot[i].SlotSize; j++)
                        {
                            int key = lstSlot[i].Num * 100 + j;
                            SlotInfo info = new SlotInfo();
                            info.Slot = lstSlot[i].Num;
                            info.Channel = j;
                            info.SlotType = 0;
                            info.BytePos = byteSize;

                            dtMap.Add(key, info);
                            byteSize += 2;
                        }
                    }
                    else if (lstSlot[i].SlotType == "DI" || lstSlot[i].SlotType == "DO")
                    {
                        for (int j = 1; j <= lstSlot[i].SlotSize; j++)
                        {
                            int key = lstSlot[i].Num * 100 + j;
                            SlotInfo info = new SlotInfo();
                            info.Slot = lstSlot[i].Num;
                            info.Channel = j;
                            info.SlotType = 1;
                            info.BytePos = byteSize;
                            //is channel 1,bit position will be 0
                            info.BitPos = (7 + j - 8);                            
                            
                            dtMap.Add(key, info);
                        }
                        byteSize++;
                    }
                }
            }
            catch (System.Exception ex)
            {
                Logger.Error(ex.ToString());
            }
            
            return byteSize;
        }

        //function support only uncompress normal
        private void Inser(List<Slot> arrSlots, int position, Slot slot)
        {
            int i = position - 1;
            while (i >= 0 && IsGreater(arrSlots[i],slot) == -1)
            {
                arrSlots[i + 1] = arrSlots[i];
                i--;
            }
            arrSlots[i + 1] = slot;
        }
        
        //if slot1 > slot2:-1,equal:0,slot2 > slot1 1
        private Int32 IsGreater(Slot slot1, Slot slot2)
        {
            //only correct with normal,with compress mode,the rule must be updated
            return slot1.Num > slot2.Num ? -1 : 1;
            //if (slot1.SlotType == slot2.SlotType)
            //{
            //    return slot1.Num > slot2.Num ? -1 : 1;
            //}
            //else 
            //{
            //    if (slot1.SlotType == "AI")
            //    {
            //        return -1;
            //    }
            //    else
            //    {
            //        return 1;
            //    }
            //}
            //return -1;
        }
    }

    class SlotInfo
    {
        int m_iSlot = 0;
        int m_iChannel = 0;
        int m_iByte = 0;
        int m_iBit = 0;
        int m_iType = 0; //0 for analog,1 for digital

        public int Slot
        {
            get { return m_iSlot; }
            set { m_iSlot = value; }
        }

        public int Channel
        {
            get { return m_iChannel; }
            set { m_iChannel = value; }
        }
        public int BytePos
        {
            get { return m_iByte; }
            set { m_iByte = value; }
        }

        public int BitPos
        {
            get { return m_iBit; }
            set { m_iBit = value; }
        }

        public int SlotType
        {
            get { return m_iType; }
            set { m_iType = value; }
        }
    }
}
