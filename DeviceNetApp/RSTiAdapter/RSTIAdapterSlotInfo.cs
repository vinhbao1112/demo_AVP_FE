using System;
using System.Collections.Generic;
using System.Text;

namespace RSTiApdater
{
    public class RSTIAdapterSlotInfo
    {
        public enum SlotType
        {
            Unknown = 0,
            Analog = 1,
            Discrete = 2,
        }

        private Int32 m_iPhysicPosition = 0;
        public Int32 PhysicPosition
        {
            set { m_iPhysicPosition = value; }
            get { return m_iPhysicPosition; }
        }

        private Int32 m_iBytePosition = 0;
        public Int32 BytePosition
        {
            set { m_iBytePosition = value; }
            get { return m_iBytePosition; }
        }

        private Int32 m_iBitPosition = 0;
        public Int32 BitPosition
        {
            set { m_iBitPosition = value; }
            get { return m_iBitPosition; }
        }

        private SlotType m_eType = SlotType.Unknown;
        public SlotType Type
        {
            set { m_eType = value; }
            get { return m_eType; }
        }

        private Int32 m_iSize = 0;
        public Int32 Size
        {
            set { m_iSize = value; }
            get { return m_iSize; }
        }       
    }
}
