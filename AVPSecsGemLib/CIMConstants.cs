using System;
using System.Collections.Generic;
using System.Text;

namespace AVPSecsGemLib
{
    public class AVPConstants
    {
        public static int iConnectionID = 1;
        public static int iConnectionCommonID = 0;
        public static int iGEMID_DBCOLUMN = 0;
        public static int iGEMTYPE_DBCOLUMN = 1;
        public static int iGEMFORMAT_DBCOLUMN = 2;
        public static int iGEMDEFAULTVAL_DBCOLUMN = 3;
        public static int iGEMUNITS_DBCOLUMN = 4;
        public static int iGEMNAME_DBCOLUMN = 5;
        public static int iGEMDESCRIPTION_DBCOLUMN = 6;
        public static int iGEMMIN_DBCOLUMN = 7;
        public static int iGEMMAX_DBCOLUMN = 8;
        public static int iGEMPRIVATE_DBCOLUMN = 9;
        public static int iGEMPERSISTENT_DBCOLUMN = 10;
        public static int iGEMEVENTID_DBCOLUMN = 11;

        
        public static int iALARMNAME_DBCOLUMN = 0;
        public static int iALARMTEXT_DBCOLUMN = 1;
        public static int iALARMDESC_DBCOLUMN = 2;
        public static int iALARMID_DBCOLUMN = 3;
        public static int iALARMSET_CEID_DBCOLUMN = 4;
        public static int iALARMCLEAR_CEID_DBCOLUMN = 5;

        public static int iEVENTNAME_DBCOLUMN = 0;
        public static int iEVENTDESC_DBCOLUMN = 1;
        public static int iEVENTID_DBCOLUMN = 2;

        public static int iGEM_generateID = 1000000;
        public static int iGEM_generateAlarmSetEventID = 2000;
        public static int iGEM_generateAlarmClearEventID = 4000;
        public static string sGemConfigPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "ConfigFiles\\SystemConfig\\private";
        public static string sGemConfigName = "AVPCIMConnectConfig.epj";
        public static int m_iUpload_ProcessingTimeout  = 300;
        public static int m_iDownload_ProcessingTimeout = 300;
    }

    public enum AVP_GEMTYPE
    {
        COMMON          = 0,
        IBE_CHAMBER     = 1,
        PVD_CHAMBER     = 2,
        LOADLOCK        = 3,
        TRANSFERMODULE  = 4,
        CORONA_CHAMBER  = 5,
        PVD5T_CHAMBER = 6
    };

    public enum AVPChamberID
    {
        SYSTEM = 0,
        PM1 = 1,
        PM2 = 2,
        PM3 = 3,
        LLA = 7,
        TM = 9
    }

    public enum SL_GEMTYPE
    {
        COMMON = 0,
        IBE_CHAMBER = 1,
        LOADER = 2
    };

    public enum SLToolID
    {
        SYSTEM = 0,
        PM = 1,
        LOADER = 2
    }

    public enum AVPProcessState
    {
        INIT=0, IDLE=1, SETUP=2, READY=3, EXECUTING=4, PAUSE=5
    }
    public enum AVPGemControlState
    {
        ONLINE  = 0,
        OFFLINE = 1,
        UNKNOWN = 2
    }
    public enum AVPGemControlStateRemote
    {
        LOCAL   = 0,
        REMOTE  = 1,
        UNKNOWN = 2
    }
    public enum AVPGEMCommState
    {
        COMM_ENABLE   = 0,
        COMM_DISABLE = 1,
        COMM_UNKNOWN = 2
    }
    public enum AVPStateMachine
    {
        smCommunications    = 0,       //local/remote
        smControl           = 1,       //online/offline
        smSpooling          = 2,
        smProcess           = 3,
        smProtocol          = 4,
    }

    public enum RecipeErrorAck
    {
        // 1-6: CIM constant
        // 7-8: Custom Upload/Download Error        
        raDuplicatedID = 9,
    }
}
