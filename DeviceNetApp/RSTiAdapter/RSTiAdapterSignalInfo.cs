using System;
using System.Collections.Generic;
using System.Text;

namespace RSTiApdater
{
    public class RSTiAdapterSignalInfo
    {
        public enum IO
        {
            Unknown = 0,
            Input = 1,
            Output = 2,
        }
        private UInt16 m_MacID = 0;
        public UInt16 MacID
        {
            set { m_MacID = value; }
            get { return m_MacID; }
        }

        private UInt16 m_SlotID = 0;
        public UInt16 SlotID
        {
            set { m_SlotID = value; }
            get { return m_SlotID; }
        }

        private IO m_eIOType = IO.Unknown;
        public IO IOType
        {
            set { m_eIOType = value; }
            get { return m_eIOType; }
        }

        private UInt16 m_ChannelID = 0;
        public UInt16 ChannelID
        {
            set { m_ChannelID = value; }
            get { return m_ChannelID; }
        }

        private String m_strModel = String.Empty;
        public String Model
        {
            set { m_strModel = value; }
            get { return m_strModel; }
        }

        private String m_strChannelType = String.Empty;
        public String ChannelType
        {
            set { m_strChannelType = value; }
            get { return m_strChannelType; }
        }

        private Double m_dMinRSTiScale;
        public Double MinRSTiScale
        {
            set { m_dMinRSTiScale = value; }
            get { return m_dMinRSTiScale; }
        }

        private Double m_dMaxRSTiScale;
        public Double MaxRSTiScale
        {
            set { m_dMaxRSTiScale = value; }
            get { return m_dMaxRSTiScale; }
        }

        private String m_strSignalName;
        public String SignalName
        {
            set { m_strSignalName = value; }
            get { return m_strSignalName; }
        }

        private Double m_dMinRealDeviceScale;
        public Double MinRealDeviceScale
        {
            set { m_dMinRealDeviceScale = value; }
            get { return m_dMinRealDeviceScale; }
        }

        private Double m_dMaxRealDeviceScale;
        public Double MaxRealDeviceScale
        {
            set { m_dMaxRealDeviceScale = value; }
            get { return m_dMaxRealDeviceScale; }
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

        public RSTiAdapterSignalInfo(UInt16 macID, UInt16 slotID, UInt16 channelID, String model, String channelType,
            Double minScale, Double maxScale, String name, Double minReal, Double maxReal)
        {
            m_MacID = macID;
            m_SlotID = slotID;
            m_ChannelID = channelID;
            m_strModel = model;
            m_strChannelType = channelType;
            m_dMinRSTiScale = minScale;
            m_dMaxRSTiScale = maxScale;
            m_strSignalName = name;
            m_dMinRealDeviceScale = minReal;
            m_dMaxRealDeviceScale = maxReal;
        }
    }
}
