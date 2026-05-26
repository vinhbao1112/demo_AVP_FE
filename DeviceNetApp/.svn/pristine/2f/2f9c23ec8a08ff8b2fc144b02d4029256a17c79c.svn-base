using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace RSTiApdater
{
    public class RSTIAdapterInfo
    {
        public enum ProcessImageType
        {
            Unknown = 0,
            StatusNormal = 1,
            UnstatusNormal = 2,
            StatusCompress = 3,
            UnstatusCompress = 4,
        }
        private Int32 m_iMacID = 0;
        private List<RSTIAdapterSlotInfo> m_lInputSlots = new List<RSTIAdapterSlotInfo>(32);
        private List<RSTIAdapterSlotInfo> m_lOutputSlots = new List<RSTIAdapterSlotInfo>(32);
        private ProcessImageType m_eImageType = ProcessImageType.UnstatusNormal;//default
        private ushort m_uInputSize = 0;
        /// <summary>
        /// size of output data
        /// </summary>
        private ushort m_uOutputSize = 0;

        public Int32 MacID
        {
            set { m_iMacID = value; }
            get { return m_iMacID; }
        }


        public ProcessImageType ImageType
        {
            set { m_eImageType = value; }
            get { return m_eImageType; }
        }

        public List<RSTIAdapterSlotInfo> InputSlots
        {
            set { m_lInputSlots = value; }
            get { return m_lInputSlots; }
        }

        public List<RSTIAdapterSlotInfo> OutputSlots
        {
            set { m_lOutputSlots = value; }
            get { return m_lOutputSlots; }
        }        

        public ushort InputSize
        {
            get { return m_uInputSize; }
            set { m_uInputSize = value; }
        }

        public ushort OutputSize
        {
            get { return m_uOutputSize; }
            set { m_uOutputSize = value; }
        }

        public void AddSlotToAdapter(RSTIAdapterSlotInfo slot, bool isInput)
        {
            if (isInput)
            {
                m_lInputSlots.Add(slot);
            }
            else
            {
                m_lOutputSlots.Add(slot);
            }
        }

        public void CalculateSignalSize()
        {
            try
            {
                int iTotalBits = 0;

                //if have status byte,it is always the first byte
                if (m_eImageType == ProcessImageType.StatusCompress ||
                    m_eImageType == ProcessImageType.StatusNormal)
                {
                    iTotalBits = 8;
                }
                for (int i = 0; i < m_lInputSlots.Count; i++)
                {
                    //each analog channel is 2 bytes
                    if (m_lInputSlots[i].Type == RSTIAdapterSlotInfo.SlotType.Analog)
                    {
                        iTotalBits += m_lInputSlots[i].Size * 16;
                    }
                    //each signal of discrete is 1 bit
                    else if (m_lInputSlots[i].Type == RSTIAdapterSlotInfo.SlotType.Discrete)
                    {
                        if (m_lInputSlots[i].Size <= 8 &&
                            m_eImageType == ProcessImageType.UnstatusNormal ||
                            m_eImageType == ProcessImageType.StatusNormal)
                        {
                            iTotalBits += 8;
                        }
                        else
                        {
                            iTotalBits += m_lInputSlots[i].Size * 1;
                        }

                    }
                }

                m_uInputSize = (ushort)(iTotalBits / 8);

                if (iTotalBits % 8 != 0)
                {
                    m_uInputSize += 1;
                }

                //reset to calculate output size
                iTotalBits = 0;
                //if have status byte,it is always the first byte
                if (m_eImageType == ProcessImageType.StatusCompress ||
                    m_eImageType == ProcessImageType.StatusNormal)
                {
                    iTotalBits = 8;
                }
                for (int i = 0; i < m_lOutputSlots.Count; i++)
                {
                    //each analog channel is 2 bytes
                    if (m_lOutputSlots[i].Type == RSTIAdapterSlotInfo.SlotType.Analog)
                    {
                        iTotalBits += m_lOutputSlots[i].Size * 16;
                    }
                    //each signal of discrete is 1 bit
                    else if (m_lOutputSlots[i].Type == RSTIAdapterSlotInfo.SlotType.Discrete)
                    {
                        iTotalBits += m_lOutputSlots[i].Size * 1;
                    }
                }

                m_uOutputSize = (ushort)(iTotalBits / 8);

                if (iTotalBits % 8 != 0)
                {
                    m_uOutputSize += 1;
                }
            }
            catch (System.Exception ex)
            {

            }
        }

        public void ArrangePacket()
        {
            ArrangePacket(m_lInputSlots);
            ArrangePacket(m_lOutputSlots);
        }


        public void GetBytePosition(Int32 iSlotNum, Int32 iChannelNum, Boolean IsOutput,Boolean IsAnalog, ref Int32 iBytePos, ref Int32 iBitPos)
        {
            List<RSTIAdapterSlotInfo> lstSlot = null;
            iBytePos = 0;
            iBitPos = 0;

            if (IsOutput)
            {
                lstSlot = m_lOutputSlots;
            }
            else
            {
                lstSlot = m_lInputSlots;
            }

            for (int i = 0; i < lstSlot.Count;i++ )
            {
                if (iSlotNum != lstSlot[i].PhysicPosition)
                {
                    continue;
                }

                if (IsAnalog)
                {
                    iBytePos = lstSlot[i].BytePosition + (iChannelNum - 1) * 2;
                }
                else
                {
                    iBytePos = lstSlot[i].BytePosition;
                    iBitPos = lstSlot[i].BitPosition + iChannelNum - 1;
                }
            }

        }

        public void AssignBitForChannel(Hashtable htbSignalMap)
        {
            foreach (DictionaryEntry pair in htbSignalMap)
            {
                RSTiAdapterSignalInfo objSignal = (RSTiAdapterSignalInfo)pair.Value;
                AssignBitForSignal(objSignal);
            }
        }

        public void AssignBitForChannel(Dictionary<String, RSTiAdapterSignalInfo> htbSignalMap)
        {
            foreach (KeyValuePair<String, RSTiAdapterSignalInfo> pair in htbSignalMap)
            {
                RSTiAdapterSignalInfo objSignal =pair.Value;
                AssignBitForSignal(objSignal);
            }
        }

        private void AssignBitForSignal(RSTiAdapterSignalInfo objSignal)
        {
            if (objSignal.MacID != this.m_iMacID)
            {
                return;
            }

            for (int i = 0; i < this.m_lOutputSlots.Count; i++)
            {
                //if signal is on other adapter or slot
                if (objSignal.MacID != this.m_iMacID || objSignal.SlotID != this.m_lOutputSlots[i].PhysicPosition)
                {
                    continue;
                }
                objSignal.IOType = RSTiAdapterSignalInfo.IO.Output;
                if (this.m_lOutputSlots[i].Type == RSTIAdapterSlotInfo.SlotType.Discrete)
                {
                    objSignal.BytePosition = this.m_lOutputSlots[i].BytePosition;
                    objSignal.BitPosition = this.m_lOutputSlots[i].BitPosition + objSignal.ChannelID - 1;
                }
                else if (this.m_lOutputSlots[i].Type == RSTIAdapterSlotInfo.SlotType.Analog)
                {
                    objSignal.BytePosition = this.m_lOutputSlots[i].BytePosition + (objSignal.ChannelID - 1) * 2;
                }
                break;
            }

            for (int i = 0; i < this.m_lInputSlots.Count; i++)
            {
                //if signal is on other adapter or slot
                if (objSignal.MacID != this.m_iMacID || objSignal.SlotID != this.m_lInputSlots[i].PhysicPosition)
                {
                    continue;
                }
                objSignal.IOType = RSTiAdapterSignalInfo.IO.Input;
                if (this.m_lInputSlots[i].Type == RSTIAdapterSlotInfo.SlotType.Discrete)
                {
                    objSignal.BytePosition = this.m_lInputSlots[i].BytePosition;
                    objSignal.BitPosition = this.m_lInputSlots[i].BitPosition + objSignal.ChannelID - 1;
                }
                else if (this.m_lInputSlots[i].Type == RSTIAdapterSlotInfo.SlotType.Analog)
                {
                    objSignal.BytePosition = this.m_lInputSlots[i].BytePosition + (objSignal.ChannelID - 1) * 2;
                }
                break;
            }
        }

        private void Inser(List<RSTIAdapterSlotInfo> arrSlots, int position, RSTIAdapterSlotInfo slot)
        {
            int i = position - 1;
            while (i >= 0 && IsGreaterSize(arrSlots[i], slot) == -1)
            {
                arrSlots[i + 1] = arrSlots[i];
                i--;
            }
            arrSlots[i + 1] = slot;
        }

        /// <summary>
        /// arrange slot signal in packet depend on image type
        /// </summary>
        private void ArrangePacket(List<RSTIAdapterSlotInfo> arrSlots)
        {
            int iSortedSize = 1;

            while (iSortedSize < arrSlots.Count)
            {
                Inser(arrSlots, iSortedSize, arrSlots[iSortedSize]);
                iSortedSize++;
            }

            Int32 iByteIndex = 0;
            if (m_eImageType == ProcessImageType.StatusCompress || m_eImageType == ProcessImageType.StatusNormal)
            {
                iByteIndex = 1;
            }

            int iByteRemain = 8;
            for (int i = 0; i < arrSlots.Count; i++)
            {
                arrSlots[i].BytePosition = iByteIndex + 1;
                if (arrSlots[i].Type == RSTIAdapterSlotInfo.SlotType.Analog)
                {
                    iByteIndex += arrSlots[i].Size * 2;
                }
                else if (arrSlots[i].Type == RSTIAdapterSlotInfo.SlotType.Discrete)
                {
                    if (arrSlots[i].Size >= 8)
                    {
                        iByteIndex += arrSlots[i].Size / 8;
                    }
                    else
                    {
                        if (m_eImageType == ProcessImageType.UnstatusNormal || m_eImageType == ProcessImageType.StatusNormal)
                        {
                            iByteIndex += 1;
                        }
                        else if (m_eImageType == ProcessImageType.UnstatusCompress || m_eImageType == ProcessImageType.StatusCompress)
                        {
                            iByteRemain -= arrSlots[i].Size;
                            arrSlots[i].BitPosition = iByteRemain;
                            if (iByteRemain == 0)
                            {
                                iByteIndex += 1;
                                iByteRemain = 8;
                            }
                        }
                    }


                }

            }
        }

        /// <summary>
        /// Compare two slot for arrange in packet
        /// </summary>
        /// <param name="objSlot1"></param>
        /// <param name="objSlot2"></param>
        /// <returns>0 if equal,1 if 1 greater,-1 if 2 greater</returns>
        private int IsGreaterSize(RSTIAdapterSlotInfo objSlot1, RSTIAdapterSlotInfo objSlot2)
        {
            //if uncompress,each slot has its own byte
            if (m_eImageType == ProcessImageType.StatusNormal || m_eImageType == ProcessImageType.UnstatusNormal)
            {
                if (objSlot1.PhysicPosition > objSlot2.PhysicPosition)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
            //compress mode
            else if (m_eImageType == ProcessImageType.StatusCompress || m_eImageType == ProcessImageType.UnstatusCompress)
            {
                //if both analog,slot is arrange depend on physic position
                if (objSlot1.Type == RSTIAdapterSlotInfo.SlotType.Analog &&
                    objSlot2.Type == RSTIAdapterSlotInfo.SlotType.Analog)
                {
                    if (objSlot1.PhysicPosition > objSlot2.PhysicPosition)
                    {
                        return -1;
                    }
                    else
                    {
                        return 1;
                    }
                }
                else if (objSlot1.Type == RSTIAdapterSlotInfo.SlotType.Analog)
                {
                    return 1;
                }
                else if (objSlot2.Type == RSTIAdapterSlotInfo.SlotType.Analog)
                {
                    return -1;
                }
                //if discrete,the order is  size order:8/16,4 and 2
                else if (objSlot1.Type == RSTIAdapterSlotInfo.SlotType.Discrete &&
                    objSlot2.Type == RSTIAdapterSlotInfo.SlotType.Discrete)
                {
                    //if size equal and greater than 1byte,base on physic position
                    if (objSlot1.Size == objSlot2.Size && objSlot1.Size >= 8)
                    {
                        if (objSlot1.PhysicPosition > objSlot2.PhysicPosition)
                        {
                            return -1;
                        }
                        else
                        {
                            return 1;
                        }
                    }
                    //size equal and less than 1byte,their size is 4/2 bit
                    else if (objSlot1.Size == objSlot2.Size)
                    {
                        return 0;
                    }
                    else if (objSlot1.Size > objSlot2.Size)
                    {
                        if (objSlot1.Size >= 8)
                        {
                            return 1;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                    else if (objSlot2.Size > objSlot1.Size)
                    {
                        if (objSlot2.Size >= 8)
                        {
                            return -1;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
            }
            return 0;
        }
    }
}
