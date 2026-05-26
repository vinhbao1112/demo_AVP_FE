using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace DeviceNetApp.Lib
{
    [XmlRootAttribute("DeviceNetConfig")]
    public class ConfigurationData : Serializeable
    {
        String m_strCardName = String.Empty;
        [XmlAttribute("ScannnerCardName")]
        public String CardName
        {
            get { return m_strCardName; }
            set { m_strCardName = value; }
        }

        int m_iBaudRate = -1;
        [XmlAttribute("BaudRate")]
        public Int32 BaudRate
        {
            get { return m_iBaudRate; }
            set { m_iBaudRate = value; }
        }

        List<IG> m_lstIG = new List<IG>();
        [XmlElement("IG")]
        public List<IG> IGDevices
        {
            get { return m_lstIG; }
            set { m_lstIG = value; }
        }

        List<CG> m_lstCG = new List<CG>();
        [XmlElement("CG")]
        public List<CG> CGDevices
        {
            get { return m_lstCG; }
            set { m_lstCG = value; }
        }

        List<Solenoid> m_lstSolenoid = new List<Solenoid>();
        [XmlElement("Solenoid")]
        public List<Solenoid> SolenoidDevices
        {
            get { return m_lstSolenoid; }
            set { m_lstSolenoid = value; }
        }

        List<Gas> m_lstGas = new List<Gas>();
        [XmlElement("Gas")]
        public List<Gas> GasDevices
        {
            get { return m_lstGas; }
            set { m_lstGas = value; }
        }

        List<FlowCool> m_lstFlowCool = new List<FlowCool>();
        [XmlElement("FlowCool")]
        public List<FlowCool> FlowCoolDevices
        {
            get { return m_lstFlowCool; }
            set { m_lstFlowCool = value; }
        }

        List<VAT> m_lstVAT = new List<VAT>();
        [XmlElement("VAT")]
        public List<VAT> VATDevices
        {
            get { return m_lstVAT; }
            set { m_lstVAT = value; }
        }

        PasswordExitDeviceNetApp m_PasswordExit = new PasswordExitDeviceNetApp();
        [XmlElement("PasswordExitDeviceNetApp")]
        public PasswordExitDeviceNetApp PasswordExit
        {
            get { return m_PasswordExit; }
            set { m_PasswordExit = value; }
        }

        List<RSTi> m_lstRSTi = new List<RSTi>();
        [XmlElement("RSTi")]
        public List<RSTi> RSTiDevices
        {
            get { return m_lstRSTi; }
            set { m_lstRSTi = value; }
        }
    }

    public class IG
    {
        short m_iMacID = -1;
        [XmlAttribute("MacID")]
        public Int16 MacID
        {
            get { return m_iMacID; }
            set { m_iMacID = value; }
        }

        int m_iFilamentType = 1;
        [XmlAttribute("FilamentType")]
        public Int32 FilamentType
        {
            get { return m_iFilamentType; }
            set { m_iFilamentType = value; }
        }

        int m_iAutoCurrentEmission = 1;
        [XmlAttribute("AutoCurrentEmission")]
        public Int32 AutoCurrentEmission
        {
            get { return m_iAutoCurrentEmission; }
            set { m_iAutoCurrentEmission = value; }
        }

        int m_iIGType = 1;
        [XmlAttribute("IGType")]
        public Int32 IGType
        {
            get { return m_iIGType; }
            set { m_iIGType = value; }
        }

        int m_iIGSensitivityValue = 24;
        [XmlAttribute("IonGaugeSensitivityValue")]
        public Int32 IonGaugeSensitivityValue
        {
            get { return m_iIGSensitivityValue; }
            set { m_iIGSensitivityValue = value; }
        }
    }

    public class CG
    {
        short m_iMacID = -1;
        [XmlAttribute("MacID")]
        public Int16 MacID
        {
            get { return m_iMacID; }
            set { m_iMacID = value; }
        }

        Single m_iCGTripPoint = 0.5f;
        [XmlAttribute("CGTripPoint")]
        public Single CGTripPoint
        {
            get { return m_iCGTripPoint; }
            set { m_iCGTripPoint = value; }
        }
    }

    public class Solenoid
    {
        short m_iMacID = -1;
        [XmlAttribute("MacID")]
        public Int16 MacID
        {
            get { return m_iMacID; }
            set { m_iMacID = value; }
        }

        /// <author>Hoa Nguyen</author>
        /// <date>2017-07-17</date>
        /// <summary>
        /// Type of Solenoid Valve.
        /// EX260 for new valve type
        /// Anything remaining values for old type EX12x
        /// </summary>
        string m_strType = "";
        [XmlAttribute("Type")]
        public string Type
        {
            get { return m_strType; }
            set { m_strType = value; }
        }
    }
    
    public class Gas
    {
        short m_iMacID = -1;
        [XmlAttribute("MacID")]
        public Int16 MacID
        {
            get { return m_iMacID; }
            set { m_iMacID = value; }
        }

        Single m_iCalibrationFactor = -1;
        [XmlAttribute("CalibrationFactor")]
        public Single CalibrationFactor
        {
            get { return m_iCalibrationFactor; }
            set { m_iCalibrationFactor = value; }
        }

        Single m_iRangeValue = -1;
        [XmlAttribute("RangeValue")]
        public Single RangeValue
        {
            get { return m_iRangeValue; }
            set { m_iRangeValue = value; }
        }
        String m_strModel = String.Empty;
        [XmlAttribute("Model")]
        public String Model
        {
            get { return m_strModel; }
            set { m_strModel = value; }
        }
    }

    public class FlowCool 
    {
        short m_iMacID = -1;
        [XmlAttribute("MacID")]
        public Int16 MacID
        {
            get { return m_iMacID; }
            set { m_iMacID = value; }
        }

        String m_strPressureType = String.Empty;
        [XmlAttribute("PressureType")]
        public String PressureType
        {
            get { return m_strPressureType; }
            set { m_strPressureType = value; }
        }
    }

    public class VAT
    {
        short m_iMacID = -1;
        [XmlAttribute("MacID")]
        public Int16 MacID
        {
            get { return m_iMacID; }
            set { m_iMacID = value; }
        }
    }
    public class RSTi
    {
        short m_iMacID = -1;
        [XmlAttribute("MacID")]
        public Int16 MacID
        {
            get { return m_iMacID; }
            set { m_iMacID = value; }
        }
        List<Slot> m_lstSlot = new List<Slot>();
        [XmlElement("Slot")]
        public List<Slot> Slot 
        { 
            get { return m_lstSlot; }  
            set { m_lstSlot=value; }
        }
    }

    public class Slot
    {
        int m_iNum = -1;
        [XmlAttribute("Num")]
        public Int32 Num
        {
            get { return m_iNum; }
            set { m_iNum = value; }
        }

        String m_strType = string.Empty;
        [XmlAttribute("Type")]
        public String SlotType
        {
            get { return m_strType; }
            set { m_strType = value; }
        }

        Int32 m_iSize = -1;
        [XmlAttribute("Size")]
        public Int32 SlotSize
        {
            get { return m_iSize; }
            set { m_iSize = value; }
        } 
    }

    public class PasswordExitDeviceNetApp
    {
        string m_Password = string.Empty;
        [XmlAttribute("Value")]
        public string Password
        {
            get { return m_Password; }
            set { m_Password = value; }
        }
    }
}
