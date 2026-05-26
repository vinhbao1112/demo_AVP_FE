using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceNetApp.Lib
{
    public enum EquipmentStatus
    {
        OPENED = DeviceStatus.ACTIVE,
        CLOSED = DeviceStatus.INACTIVE,
        UNKNOWN = DeviceStatus.BETWEEN,
    }
    public enum DeviceStatus
    {
        INACTIVE = 0,
        ACTIVE = 1,
        BETWEEN = 2,
        ERROR = 3
    }

    public enum ProcessImageType
    {
        Unknown = 0,
        StatusNormal = 1,
        UnstatusNormal = 2,
        StatusCompress = 3,
        UnstatusCompress = 4,
    }

    public static class Constants
    {
        #region System Constants
        public const Int32 SYSTEM_PORT = 10001;
        public const String DEVICENET_LOG = "DeviceAppLogger";
        public const String CONFIG_FILE = "DeviceNetConfig.xml";
        public const String CONFIG_PATH = @".\Config\";
        public const String CXX_CONFIG_PATH = @".\ConfigFiles\SystemConfig\private\";
        public const String INIT_FILE_COMMAND = "InitFile";
        public const String DEVICENETAPP_CONFIG_PATH = @".\DeviceNetApp_Config\";
        #endregion

        #region LIBRARY CONSTANTS

        //--------------------------
        // connection flags
        //--------------------------
        public const int SS_EX = 0x01;
        public const int SS_P = 0x02;
        public const int SS_ST = 0x04;
        public const int SS_COS = 0x08;
        public const int SS_CYC = 0x10;
        public const int SS_AKS = 0x20;

        //--------------------------
        // I/O data areas
        //--------------------------
        //public const int DNS_INPUT1 = 0;
        public const int DNS_OUTPUT1 = 1;
        public const int DNS_INPUT2 = 2;
        public const int DNS_OUTPUT2 = 3;

        public const int DNS_SCAN_EVENT = 1;
        public const int DNS_STATUS_EVENT = 0;
        public const int DNS_IO1_EVENT = 1;
        public const int DNS_IO2_EVENT = 2;
        public const int DNS_EXP_EVENT = 3;
        public const int DNS_EXP_REQ_EVENT = 3;
        public const int DNS_EXP_RES_EVENT = 4;

        //--------------------------
        // status flags
        //--------------------------
        public const int DNS_EXP_MSG_RECEIVED = 0x01;
        public const int DNS_EXP_MSG_TRUNCATED = 0x02;
        public const int DNS_INPUT_DATA_UPDATE = 0x01;
        public const int DNS_RECEIVE_IDLE = 0x02;
        public const int DNS_SERVER_EXPLICIT_RECEIVED = 0x01;

        //--------------------------
        // Device Net Commands
        //--------------------------
        //Gas
        public const string DNET_CMD_GAS_FLOW_RATE = "GasFlowRate";
        public const string DNET_CMD_CFG_RANGE = "GasRange";
        public const string DNET_CMD_CFG_CALIBRATION_FACTOR = "CalibrationFactor";
        public const string DNET_CMD_CFG_ZERO_ADJUST = "GasZeroAdjust";
        //IG
        public const string DNET_CMD_FILAMENT_ON_OFF = "FilamentOnOff";
        public const string DNET_CMD_IG_DEGAS_ON_OFF = "IGDegasOnOff";
        public const string DNET_CMD_CFG_IG_SELECT_EMISSION_CURRENT = "IGEmissionCurrent";
        public const string DNET_CMD_CFG_IG_SELECT_FILAMENT = "IGSelectFilament";
        public const string DNET_CMD_CFG_IG_SELECT_EMISSION_SENSITIVE = "SetEmissionSensitive";

        // CG
        public const string DNET_CMD_CG_TRIP_POINT = "CGTripPoint";

        //Solenoid
        public const string DNET_CMD_SOLENOID_BIT_ON_OFF = "SolenoidBitOnOff";
        //VAT
        public const string DNET_CMD_VAT_SET_PRESSURE = "PressureSetPoint";
        public const string DNET_CMD_VAT_SET_POSITION = "PositionSetPoint";
        public const string DNET_CMD_VAT_OPEN_CLOSE = "VatOpenClose";
        public const string DNET_CMD_VAT_HOLD = "VatHold";
        public const string DNET_CMD_VAT_LEARN = "VatLearn";
        public const string DNET_CMD_VAT_AUTO_ZERO = "VatAutoZero";
        public const string DNET_CMD_VAT_GAIN_FACTOR = "VatGainFactor";
        public const string DNET_CMD_VAT_ZERO_CONTROL = "VatZeroControl";
        public const string DNET_CMD_VAT_SET_ACCESS_MODE = "VatSetAccessMode"; //Int32
        public const string DNET_CMD_VAT_SET_CONTROL_MODE_PRESSURE = "VatSetControlModePressure";
        public const string DNET_CMD_VAT_SET_CONTROL_MODE_POSITION = "VatSetControlModePosition";
        public const string DNET_CMD_VAT_SEND_EXPLICIT = "VatSendExplicit";

        //--------------------------
        // Device Net Properties
        //--------------------------
        public const string DNET_PROP_FLOW_RATE = "FlowRate"; // Float
        public const string DNET_PROP_PRESSURE = "Pressure"; // Float
        public const string DNET_PROP_STATUS = "Status"; // Boolean
        public const string DNET_PROP_CG_RELAY = "CGRelay"; // Boolean
        public const string DNET_PROP_SOLENOID_BIT1 = "0"; // Boolean
        public const string DNET_PROP_SOLENOID_BIT2 = "1"; // Boolean
        public const string DNET_PROP_SOLENOID_BIT3 = "2"; // Boolean
        public const string DNET_PROP_SOLENOID_BIT4 = "3"; // Boolean
        public const string DNET_PROP_SOLENOID_BIT5 = "4"; // Boolean
        public const string DNET_PROP_SOLENOID_BIT6 = "5"; // Boolean
        public const string DNET_PROP_SOLENOID_BIT7 = "6"; // Boolean
        public const string DNET_PROP_SOLENOID_BIT8 = "7"; // Boolean
        public const string DNET_PROP_SOLENOID_BIT9 = "8"; // Boolean
        public const string DNET_PROP_SOLENOID_BIT10 = "9"; // Boolean
        public const string DNET_PROP_SOLENOID_BIT11 = "10"; // Boolean
        public const string DNET_PROP_SOLENOID_BIT12 = "11"; // Boolean
        public const string DNET_PROP_SOLENOID_BIT13 = "12"; // Boolean
        public const string DNET_PROP_SOLENOID_BIT14 = "13"; // Boolean
        public const string DNET_PROP_SOLENOID_BIT15 = "14"; // Boolean
        public const string DNET_PROP_SOLENOID_BIT17 = "15"; // Boolean
        public const string DNET_PROP_VAT_POSITION = "VatPosition"; // Boolean
        public const string DNET_PROP_VAT_PRESSURE = "VatPressure"; // Boolean
        public const string DNET_PROP_VAT_POSITION_STATUS = "VatPosStatus"; // Boolean
        public const string DNET_PROP_COMMUNICATION_STATUS = "CommunicationStatus"; // Boolean

        public const Single DNET_ERROR_VALUE = -1.0f;


        public const string DNET_CMD_RSTI_BIT_ONOFF = "RSTiBitOnOff";
        public const string DNET_CMD_RSTI_ANALOG_VALUE = "RSTiAnalogValue";

        public const string DNET_PROP_RSTI_ADAPTER_OUTPUT_DISCRETE_CHANNEL = "DO";
        public const string DNET_PROP_RSTI_ADAPTER_INPUT_DISCRETE_CHANNEL = "DI";
        public const string DNET_PROP_RSTI_ADAPTER_INPUT_ANALOG_CHANNEL = "AI";
        public const string DNET_PROP_RSTI_ADAPTER_OUTPUT_ANALOG_CHANNEL = "AO";
        #endregion

        
    }
}
