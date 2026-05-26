using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Globalization;
using EMSERVICELib;
using VALUELib;
using Microsoft.Win32;

namespace AVPSecsGemLib
{
    public class AVPSecsGem
    {
#region Delegates
#region TerminalService
        // Handle incoming Terminal Service messages. 
        public class TerminalServiceArgs : EventArgs
        {
            public TerminalServiceArgs(string textMessage)
            {
                m_textMessage = textMessage;
            }
            private string m_textMessage;
            public string TextMessage
            {
                get { return m_textMessage; }
            }
        }
        public delegate void TerminalServiceHandler(object sender, TerminalServiceArgs e);
        public event TerminalServiceHandler m_TerminalServiceHandler;
        public void TerminalService(string textMessage)
        {
            if (m_TerminalServiceHandler != null)
            {
                TerminalServiceArgs e = new TerminalServiceArgs(textMessage);
                m_TerminalServiceHandler(this, e);
            }
        }
#endregion
       
#region GEMStateChange
        // Handle reporting GEM state changes 
        public class GEMStateChangeArgs : EventArgs
        {
            public GEMStateChangeArgs(int connection, EMSERVICELib.StateMachine statemachine, int state)
            {
                m_connection = connection;
                m_statemachine = statemachine;
                m_AvpStateMachine = (AVPStateMachine)statemachine;
                m_state = state;
            }
            private int m_connection;
            public int Connection
            {
                get { return m_connection; }
            }
            private EMSERVICELib.StateMachine m_statemachine;
            private AVPStateMachine m_AvpStateMachine;
            public EMSERVICELib.StateMachine StateMachine
            {
                get { return m_statemachine; }
            }
            public AVPStateMachine AVP_StateMachine
            {
                get { return m_AvpStateMachine; }
            }
            private int m_state;
            public int State
            {
                get { return m_state; }
            }
        }
        public delegate void GEMStateChangeHandler(object sender, GEMStateChangeArgs e);
        public event GEMStateChangeHandler m_GEMStateChangeHandler;
        public void GEMStateChange(int connection, EMSERVICELib.StateMachine statemachine, int state)
        {
            if (m_GEMStateChangeHandler != null)
            {
                GEMStateChangeArgs e = new GEMStateChangeArgs(connection, statemachine, state);
                m_GEMStateChangeHandler(this, e);
            }
        }
#endregion

        #region SetSystemTime
        // Handle Remote Commands 
        public class SystemTimeArgs : EventArgs
        {
            public SystemTimeArgs(int connection, string systemtime)
            {
                m_connection = connection;
                m_systemTime = systemtime;
            }
            private string m_systemTime;
            private int m_connection;
            public string systemTime
            {
                get { return m_systemTime; }
            }
            public int Connection
            {
                get { return m_connection; }
            }
        }
        public delegate void SystemTimeHandler(object sender, SystemTimeArgs e);
        public event SystemTimeHandler m_systemTimeHandler;
        public void SystemTimeEvent(int connection, string systemType)
        {
            if (m_systemTimeHandler != null)
            {
                SystemTimeArgs e = new SystemTimeArgs(connection, systemType);
                m_systemTimeHandler(this, e);
            }
        }
        #endregion

        #region RemoteCommand
        // Handle Remote Commands 
        public class RemoteCommandArgs : EventArgs
        {
            public RemoteCommandArgs(int connection, string command, string[] argumentNames, string[] argumentValues, ref EMSERVICELib.CommandResults commandResult)
            {
                m_connection = connection;
                m_command = command;
                m_argumentNames = argumentNames;
                m_argumentValues = argumentValues;
                m_commandResult = commandResult;
            }
            private int m_connection;
            public int Connection
            {
                get { return m_connection; }
            }
            private string m_command;
            public string Command
            {
                get { return m_command; }
            }
            private string[] m_argumentNames;
            public string[] ArgumentNames
            {
                get { return m_argumentNames; }
            }
            private string[] m_argumentValues;
            public string[] ArgumentValues
            {
                get { return m_argumentValues; }
            }
            private EMSERVICELib.CommandResults m_commandResult;
            public EMSERVICELib.CommandResults CommandResult
            {
                get { return m_commandResult; }
                set { m_commandResult = value; }
            }
        }
        public delegate void RemoteCommandHandler(object sender, RemoteCommandArgs e);
        public event RemoteCommandHandler m_RemoteCommandHandler;
        public void RemoteCommand(int connection, string command, string[] argumentNames, string[] argumentValues, ref EMSERVICELib.CommandResults commandResult)
        {
            if (m_RemoteCommandHandler != null)
            {
                RemoteCommandArgs e = new RemoteCommandArgs(connection, command, argumentNames, argumentValues, ref commandResult);
                m_RemoteCommandHandler(this, e);
                commandResult = e.CommandResult;
            }
        }
        #endregion
        //E->H
        #region PPLoadInquire
        public class PPLoadInquireArgs : EventArgs
        {
            public PPLoadInquireArgs(ref EMSERVICELib.RecipeGrant result)
            {
                m_result = result;
            }
            private EMSERVICELib.RecipeGrant m_result;
            public EMSERVICELib.RecipeGrant RecipeGrant
            {
                get { return m_result; }
                set { m_result = value; }
            }
        }
        public delegate void PPLoadInquireHandler(object sender, PPLoadInquireArgs e);
        public event PPLoadInquireHandler m_PPLoadInquireHandler;
        public void PPLoadInquire(EMSERVICELib.RecipeGrant result)
        {
            if (m_PPLoadInquireHandler != null)
            {
                PPLoadInquireArgs e = new PPLoadInquireArgs(ref result);
                m_PPLoadInquireHandler(this, e);
                result = e.RecipeGrant;
                     }
        }
#endregion
        //H->E
        #region HostPPSendAck
        public class HostPPSendAckArgs : EventArgs
        {
            public HostPPSendAckArgs(EMSERVICELib.RecipeAck result)
            {
                m_result = result;
            }
            private EMSERVICELib.RecipeAck m_result;
            public EMSERVICELib.RecipeAck RecipeAck
            {
                get { return m_result; }
            }
        }
        public delegate void HostPPSendAckHandler(object sender, HostPPSendAckArgs e);
        public event HostPPSendAckHandler m_HostPPSendAckHandler;
        public void HostPPSendAck(EMSERVICELib.RecipeAck result)
        {
            if (m_HostPPSendAckHandler != null)
            {
                HostPPSendAckArgs e = new HostPPSendAckArgs(result);
                m_HostPPSendAckHandler(this, e);
            }
        }
        #endregion
        //E->H
        #region PPSendData
        public class PPSendDataArgs : EventArgs
        {
            public PPSendDataArgs(string sFileName, int Result)
            {
                m_Result = Result;
                m_sFileName = sFileName;
            }
            private int m_Result;
            private string m_sFileName;
            public string sFileName
            {
                get { return m_sFileName; }
            }
            public int Result
            {
                get { return m_Result; }
            }
        }
        public delegate void PPSendDataHandler(object sender, PPSendDataArgs e);
        public event PPSendDataHandler m_PPSendDataHandler;
        public void PPSendData(string sFileName, int Result)
        {
            if (m_PPSendDataHandler != null)
            {
                PPSendDataArgs e = new PPSendDataArgs(sFileName,Result);
                m_PPSendDataHandler(this, e);
            }
        }
        #endregion
        //H->E
        #region HostPPSendFile
        public class HostPPSendFileArgs : EventArgs
        {
            public HostPPSendFileArgs(string sFileName, EMSERVICELib.RecipeAck Result)
            {
                m_Result = Result;
                m_sFileName = sFileName;
            }
            private EMSERVICELib.RecipeAck m_Result;
            private string m_sFileName;
            public string sFileName
            {
                get { return m_sFileName; }
            }
            public EMSERVICELib.RecipeAck Result
            {
                get { return m_Result; }
                set { m_Result = value; }
            }

        }
        public delegate void HostPPSendFileHandler(object sender, HostPPSendFileArgs e);
        public event HostPPSendFileHandler m_HostPPSendFileHandler;
        public void HostPPSendFile(string sFileName, ref EMSERVICELib.RecipeAck Result)
        {
            if (m_HostPPSendFileHandler != null)
            {
                HostPPSendFileArgs e = new HostPPSendFileArgs(sFileName,  Result);
                m_HostPPSendFileHandler(this, e);
                Result = e.Result;
            }
        }
        #endregion
        #region HostPPDelete
        public class HostPPDeleteFileArgs : EventArgs
        {
            public HostPPDeleteFileArgs(string[] sFileName, EMSERVICELib.RecipeAck Result)
            {
                m_Result = Result;
                m_sFileName = sFileName;
            }
            private EMSERVICELib.RecipeAck m_Result;
            private string[] m_sFileName;
            public string[] sFileName
            {
                get { return m_sFileName; }
            }
            public EMSERVICELib.RecipeAck Result
            {
                get { return m_Result; }
                set { m_Result = value; }
            }

        }
        public delegate void HostPPDeleteFileHandler(object sender, HostPPDeleteFileArgs e);
        public event HostPPDeleteFileHandler m_HostPPDeleteFileHandler;
        public void HostPPDeleteFile(string[] sFileName, ref EMSERVICELib.RecipeAck Result)
        {
            if (m_HostPPDeleteFileHandler != null)
            {
                HostPPDeleteFileArgs e = new HostPPDeleteFileArgs(sFileName, Result);
                m_HostPPDeleteFileHandler(this, e);
                Result = e.Result;
            }
        }
        #endregion
#endregion // Delegates
        #region Member Variables
            public EMSERVICELib.CxEMService m_CxEMService;
            public bool m_initialized = false;
            public EMSERVICELib.CxClientClerk m_CxClientClerk;
            public EMSERVICELib.ICxClientTool m_ICxClientTool;

            public AVPProcessState m_LLAProcessState;
            public CIMConnectCallback m_CIMConnectCallback;
            private AVPSecsGemLog m_AvpSecsGemLog;
            private ulong m_TransactionTimeOut = 0;
            private ArrayList m_setAlarmList = new ArrayList(); // This list contains alarm name that is set

            private Hashtable m_CacheVariables;
            public const long m_NumberOfConnections = 1;
            public ulong[] m_CommunicationState = new ulong[m_NumberOfConnections];
            public ulong[] m_ControlState = new ulong[m_NumberOfConnections];
            private Boolean  m_IsProcessReallyCompleted = true ;

            public CIMConnectCallback SecsGemConnectCallback
            {
                get { return m_CIMConnectCallback; }
            }
        public ulong GetTransactionTimeOut()
        {
            return m_TransactionTimeOut;
        }
        public Boolean IsProcessReallyCompleted

        {
            get {return m_IsProcessReallyCompleted;}
            set { m_IsProcessReallyCompleted = value; }
        }
        #endregion Member Variables


        /// <summary>
        /// Constructor for AVPSecsGem
        /// Establish communication with CIMConnect EMService
        /// </summary>
        /// <param name="form"></param>
        public AVPSecsGem()
        {
            try
            {
                SetCIMConnectProjectPath();
                //create service
                m_CxEMService = new EMSERVICELib.CxEMServiceClass ();
                m_CxClientClerk = new EMSERVICELib.CxClientClerkClass ();
                //create callback
                m_AvpSecsGemLog = new AVPSecsGemLog();
                m_CIMConnectCallback = new CIMConnectCallback(this);
                
                m_LLAProcessState = AVPProcessState.INIT;
                m_CacheVariables = new Hashtable();

                // Wait for the service to be in a RUNNING state (15 s in this sample) 
                System.ServiceProcess.ServiceController myServiceController = new System.ServiceProcess.ServiceController();
                myServiceController.ServiceName = "EMService";
                TimeSpan myTimeSpan = new TimeSpan(0, 0, 0, 15);
                myServiceController.WaitForStatus(System.ServiceProcess.ServiceControllerStatus.Running, myTimeSpan);
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                HandleCOMException("Exception initializing EMSERVICELib.CxEMService", e);
            }
        }

        /// <summary>
        /// Generic exception handling function to demonstrate how to get the COM HRESULT from
        /// a COM exception. 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        public void HandleCOMException(string message, System.Runtime.InteropServices.COMException e)
        {
            AVPSecsGemLog.avpSecsGemLogger.Error(message + " HRESULT: 0x" + e.ErrorCode.ToString("X"));
        }
        /// <summary>
        /// Initialize the interfaces and CIMConnect
        /// </summary>
        public void Initialize(string EPJFile, bool reload, bool bIsSupportGEM)
        {
            
            try
            {
                if (!bIsSupportGEM)
                {
                    return;
                }

                // Wait for EMService (in case it just started up)
                int result;
                AVPSecsGemLog.avpSecsGemLogger.Debug("CxEMService.WaitOnEquipmentReady");
                m_CxEMService.WaitOnEquipmentReady(0, 15000, out result);

                // Establish a connection to CIMConnect (EMService)
                int AppID = 0;
                AVPSecsGemLog.avpSecsGemLogger.Debug("CxEMService.Connect");
                m_CxEMService.Connect(0, out m_CxClientClerk, out AppID);

                // Get the Client Tool interface
                m_ICxClientTool = (EMSERVICELib.ICxClientTool)m_CxClientClerk;

                // Make sure that the correct EPJ file is loaded. 
                string currentProject;
                AVPSecsGemLog.avpSecsGemLogger.Debug("ICxClientTool.GetCurrentProject");
                m_ICxClientTool.GetCurrentProject(out currentProject);

                // Get the default project directory from the currentProject
                string desiredProject = AVPConstants.sGemConfigPath + "\\" + EPJFile;

                // Make sure that the default EPJ file is correct.
                // This makes startup faster next time. 
                string defaultProject;
                AVPSecsGemLog.avpSecsGemLogger.Debug("ICxClientTool.GetDefaultProjectFile");
                m_ICxClientTool.GetDefaultProjectFile(out defaultProject);
                if (defaultProject != desiredProject)
                {
                    AVPSecsGemLog.avpSecsGemLogger.Debug("ICxClientTool.SetDefaultProjectFile");
                    m_ICxClientTool.SetDefaultProjectFile(desiredProject);
                }

                //if (currentProject != desiredProject)
                //{
                    AVPSecsGemLog.avpSecsGemLogger.Debug("ICxClientTool.LoadProject " + EPJFile);
                    m_ICxClientTool.LoadProject(EPJFile);

                    // Wait for the project load to completely. 
                    AVPSecsGemLog.avpSecsGemLogger.Debug("CxEMService.WaitOnEquipmentReady");
                    m_CxEMService.WaitOnEquipmentReady(0, 15000, out result);
                //}
                
                // Give CIMConnect your application's name.
                m_CxClientClerk.appName = "AVP SECSGEM Application";

                // Register to receive Terminal Services
                AVPSecsGemLog.avpSecsGemLogger.Debug("CxClientClerk.RegisterTerminalMsgHandler");
                m_CxClientClerk.RegisterTerminalMsgHandler(this.m_CIMConnectCallback);
               
                // Setup for each connection
                for (int i = 1; i <= m_NumberOfConnections; i++)
                {
                    // Register to receive State Machine changes
                    AVPSecsGemLog.avpSecsGemLogger.Debug("CxClientClerk.RegisterStateMachineHandler " + i.ToString());
                    m_CxClientClerk.RegisterStateMachineHandler(i, this.m_CIMConnectCallback);

                    // Get the communication state
                    ulong currentValue = 0;
                    GetVariableValue(i, "CommState", ref currentValue);
                    m_CommunicationState[i - 1] = currentValue;
                    GEMStateChange(i, StateMachine.smCommunications, (Int32)currentValue);

                    // Get the control state
                    GetVariableValue(i, "CONTROLSTATE", ref currentValue);
                    m_ControlState[i - 1] = currentValue;
                    GEMStateChange(i, StateMachine.smControl, (Int32)currentValue);
                }

                //get transaction time out on EPJ file
                try
                {
                    GetVariableValue(AVPConstants.iConnectionID, "EstablishCommunicationsTimeout", ref m_TransactionTimeOut);
                }
                catch (System.Runtime.InteropServices.COMException ex)
                {
                    HandleCOMException("Exception initializing communication to CIMConnect", ex);
                }

                // m_initialized = true;
                //////////////////////////////////////////////////////////////////////////
                //////////////////////////////////////////////////////////////////////////
                //<<TODO>> ADD REGISTER CALLBACK HERE...
                m_CxClientClerk.RegisterMsgHandler (AVPConstants.iConnectionID ,0x211, this.m_CIMConnectCallback);
                m_CxClientClerk.RegisterMsgHandler(AVPConstants.iConnectionID, 0x21f, this.m_CIMConnectCallback);
                //////////////////////////////////////////////////////////////////////////
                //////////////////////////////////////////////////////////////////////////
                string commandDescription;
                commandDescription = "Sequence select.";
                m_CxClientClerk.RegisterCommandHandler("PP-SELECT", ref commandDescription, this.m_CIMConnectCallback);
                commandDescription = "Start processing";
                m_CxClientClerk.RegisterCommandHandler("START", ref commandDescription , this.m_CIMConnectCallback);
                commandDescription = "Stop processing";
                m_CxClientClerk.RegisterCommandHandler("STOP", ref commandDescription, this.m_CIMConnectCallback);
                commandDescription = "Abort processing";
                m_CxClientClerk.RegisterCommandHandler("ABORT", ref commandDescription, this.m_CIMConnectCallback);
                commandDescription = "Resume processing";
                m_CxClientClerk.RegisterCommandHandler("RESUME", ref commandDescription, this.m_CIMConnectCallback);
                commandDescription = "Mark For Return Wafer";
                m_CxClientClerk.RegisterCommandHandler("PAUSE", ref commandDescription, this.m_CIMConnectCallback);
                commandDescription = "Pause AVP scheduler ";
                m_CxClientClerk.RegisterCommandHandler("MARK_FOR_RETURN", ref commandDescription, this.m_CIMConnectCallback);
                commandDescription = "Make All Online";
                m_CxClientClerk.RegisterCommandHandler("MAKE_ALL_ONLINE", ref commandDescription, this.m_CIMConnectCallback);
                m_CxClientClerk.RegisterCommandHandler("LOAD", ref commandDescription, this.m_CIMConnectCallback);
                commandDescription = "Load Wafer for LoadLock";
                m_CxClientClerk.RegisterCommandHandler("UNLOAD", ref commandDescription, this.m_CIMConnectCallback);
                commandDescription = "UnLoad Wafer for LoadLock";
                commandDescription = "Make All Online";
                m_CxClientClerk.RegisterRecipeHandler(this.m_CIMConnectCallback);
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                HandleCOMException("Exception initializing communication to CIMConnect", e);
            }
        }

        /// <author>
        /// <name>Dat Cao</name>
        /// <date> 2011-06-20</date>
        /// </author>
        /// <summary>
        /// Load config file with all variable and default variable
        /// Use AVPSecsGemConfig ojb
        /// add variable to cache has
        /// </summary>
        /// <para></para>
        /// <returns></returns>
        protected void CreateVariable(DataTable dt,AVPChamberID chamberID)
        {
            try
            {
                if (dt != null)
                {
                    string chamberName = chamberID.ToString();
                    foreach (DataRow row in dt.Rows)
                    {
                        //0 = ID, 2 = Type, 5 = Name 
                        if (row[1] != null)
                        {
                            string sError = string.Empty;
                            //variable from database
                            int varID = Convert.ToInt32(row[AVPConstants.iGEMID_DBCOLUMN].ToString().Trim());    //integer
                            varID = (int)chamberID * AVPConstants.iGEM_generateID + varID;
                            string sVarType = row[AVPConstants.iGEMTYPE_DBCOLUMN].ToString().Trim();                 //EC, SV, DV
                            VALUELib.ValueType valueType = this.GetValueTypeFromString(row[AVPConstants.iGEMFORMAT_DBCOLUMN].ToString().Trim());
                            string valName = row[AVPConstants.iGEMNAME_DBCOLUMN].ToString().Trim();
                            valName = chamberName + "." + valName;
                            string cx_min = row[AVPConstants.iGEMMIN_DBCOLUMN].ToString().Trim();
                            string cx_max = row[AVPConstants.iGEMMAX_DBCOLUMN].ToString().Trim();
                            string cx_default = row[AVPConstants.iGEMDEFAULTVAL_DBCOLUMN].ToString().Trim();
                            string description = row[AVPConstants.iGEMDESCRIPTION_DBCOLUMN].ToString().Trim(); ;
                            string units = row[AVPConstants.iGEMUNITS_DBCOLUMN].ToString().Trim();
                            string sEventID = row[AVPConstants.iGEMEVENTID_DBCOLUMN].ToString().Trim();

                            //map variable to obj
                            CxValueObject cx_minObj = new CxValueObject();
                            if (cx_min.Length > 0)
                            {
                                SetNumericValue(valueType, cx_min, ref cx_minObj);
                            }

                            CxValueObject cx_maxObj = new CxValueObject();
                            if (cx_max.Length > 0)
                            {
                                SetNumericValue(valueType, cx_max, ref cx_maxObj);
                            }

                            CxValueObject cx_defaultValObj = new CxValueObject();
                            if (cx_default.Length > 0)
                            {
                                SetNumericValue(valueType, cx_default, ref cx_defaultValObj);
                            }

                            VarType varType = VarType.varANY;
                            bool isPrivate = false;
                            bool isPersistent = false;
                            int eventID = -1;

                            switch (sVarType)
                            {
                                case "EC":
                                    varType = VarType.EC;
                                    //////////////////////////////////////////////////////////////////////////
                                    //Try Create EC
                                    try
                                    {
                                        this.m_ICxClientTool.CreateVariable(AVPConstants.iConnectionID, varID, varType, valueType, -1, valName,
                                    ref description, ref units, cx_minObj, cx_maxObj, cx_defaultValObj, ref isPrivate, ref isPersistent);
                                        m_CxClientClerk.RegisterSetValueHandler(0, varID, this.m_CIMConnectCallback);
                                    }
                                    catch 
                                    {
                                        sError = varType.ToString() + varID + ": existed";
                                    }
                                    //Add Variable Name to Hast table
                                    m_CacheVariables.Add(valName, cx_default);
                                    break;
                                case "SV":

                                    if (sEventID.Length > 0)
                                    {
                                        eventID = Convert.ToInt32(sEventID);
                                        try
                                        {
                                            this.m_ICxClientTool.CreateEvent(AVPConstants.iConnectionID, eventID, valName + " LimitCEID", ref description);
                                        }
                                        catch 
                                        {
                                            sError = valName + "," + eventID + ": existed";
                                        }

                                    }
                                    varType = VarType.SV;
                                    try
                                    {
                                        this.m_ICxClientTool.CreateVariable(AVPConstants.iConnectionID, varID, varType, valueType,
                                eventID, valName, ref description, ref units, cx_maxObj, cx_minObj, cx_defaultValObj, ref isPrivate, ref isPersistent);
                                    }
                                    catch 
                                    {
                                        sError = varType + "," + varID + ": existed";
                                    }
                                    //Add Variable Name to Hast table
                                    if (m_CacheVariables.ContainsKey(valName) == false)
                                    {
                                        m_CacheVariables.Add(valName, cx_default);
                                    }
                                    break;
                                case "DV":
                                    varType = VarType.DV;
                                    try
                                    {
                                        this.m_ICxClientTool.CreateVariable(AVPConstants.iConnectionID, varID, varType, valueType,
                                   eventID, valName, ref description, ref units, cx_maxObj, cx_minObj, cx_defaultValObj, ref isPrivate, ref isPersistent);
                                    }
                                    catch 
                                    {
                                        sError = varType + "," + varID + ": existed";
                                    }
                                    //Add Variable Name to Hast table
                                    m_CacheVariables.Add(valName, cx_default);
                                    break;
                                default:
                                    //do nothing
                                    break;
                            }
                            
                            if (sError != string.Empty)
                            {
                                AVPSecsGemLog.avpSecsGemLogger.Error(sError);
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                AVPSecsGemLog.avpSecsGemLogger.Error(ex.Message);
            }
            
        }
        protected void CreateEvents(DataTable dt, AVPChamberID chamberID)
        {
            try
            {
                if (dt != null)
                {
                    string ChamberName = chamberID.ToString();
                    foreach (DataRow row in dt.Rows)
                    {
                        string sError = "";
                        //0 = ID, 2 = Type, 5 = Name 
                        if (row[AVPConstants.iEVENTID_DBCOLUMN] != null)
                        {
                            string sID = row[AVPConstants.iEVENTID_DBCOLUMN].ToString().Trim();
                            string sName = row[AVPConstants.iEVENTNAME_DBCOLUMN].ToString().Trim();
                            string sDesc = row[AVPConstants.iEVENTDESC_DBCOLUMN].ToString().Trim();
                            
                            if (sID.Length > 0)
                            {
                                int ID = Convert.ToInt32(sID);
                                ID = (int)chamberID * AVPConstants.iGEM_generateID + ID;

                                if (ChamberName.Length > 0)
                                {
                                    sName = ChamberName + "." + sName;
                                }
                                else
                                {
                                    sError = ChamberName + " , " + sID + ": EVETNNAME column is Empty";
                                }

                                //try to Create Event
                                try
                                {
                                    this.m_ICxClientTool.CreateEvent(AVPConstants.iConnectionID, ID, sName, ref sDesc);
                                }
                                catch 
                                {
                                    sError = ChamberName + " , " + sID + ": EVETID is existed";
                                }
                            }
                            else
                            {
                                sError = ChamberName + " , " + sID + ": EVETID column is Empty";
                            }
                        }

                        if (sError.Length > 0)
                        {
                            AVPSecsGemLog.avpSecsGemLogger.Error(sError);
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                AVPSecsGemLog.avpSecsGemLogger.Error(ex.Message);
            }
        }
        protected void CreateAlarm(DataTable dt, AVPChamberID chamberID)
        {
            try
            {
                string ChamberName = chamberID.ToString();
                if (chamberID == AVPChamberID.SYSTEM)
                {
                    return;
                }

                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row[AVPConstants.iALARMID_DBCOLUMN] != null)
                        {
                            string sID = row[AVPConstants.iALARMID_DBCOLUMN].ToString().Trim();
                            string sName = row[AVPConstants.iALARMNAME_DBCOLUMN].ToString().Trim();
                            string sText = row[AVPConstants.iALARMTEXT_DBCOLUMN].ToString().Trim();
                            string sDesc = row[AVPConstants.iALARMDESC_DBCOLUMN].ToString().Trim();
                            string sSetCECollectionID = row[AVPConstants.iALARMSET_CEID_DBCOLUMN].ToString().Trim();
                            string sClearCECollectionID = row[AVPConstants.iALARMCLEAR_CEID_DBCOLUMN].ToString().Trim();

                            string sError = "";
                            if (sID.Length > 0)
                            {
                                int iAlarmID = Convert.ToInt32(sID);
                                iAlarmID = (int)chamberID * AVPConstants.iGEM_generateID + iAlarmID;

                                if (ChamberName.Length > 0)
                                {
                                    sName = ChamberName + "." + sName;
                                }
                                else
                                {
                                    sError = ChamberName + " , " + sID + ": EVETNNAME column is Empty";
                                }

                                int iSetCEColID = -1;
                                int iClearCEColID = -1;
                                //////////////////////////////////////////////////////////////////////////
                                //READ DATABASE
                                //IF DATABASE IS NOT EMPTY 
                                //GENETATE SETCECOLID = CHAMBERID * 1.000.000 + SETCECOLID
                                //
                                //IF DATABASE FIELD IS EMPTY
                                // SETCECOLID = ALARMID + 2000
                                // CLEARCECOLID IS THE SAME, ADD 4000 IF DATABASE FIELD IS EMPTY
                                //////////////////////////////////////////////////////////////////////////
                                if(sSetCECollectionID.Length > 0)
                                {
                                    iSetCEColID = Convert.ToInt32(sSetCECollectionID);
                                    iSetCEColID = (int)chamberID * AVPConstants.iGEM_generateID + iSetCEColID;
                                }
                                else
                                {
                                    iSetCEColID = iAlarmID + AVPConstants.iGEM_generateAlarmSetEventID;
                                }

                                if (sClearCECollectionID.Length > 0)
                                {
                                    iClearCEColID = Convert.ToInt32(sClearCECollectionID);
                                    iClearCEColID = (int)chamberID * AVPConstants.iGEM_generateID + iClearCEColID;
                                }
                                else
                                {
                                    iClearCEColID = iAlarmID + AVPConstants.iGEM_generateAlarmClearEventID;
                                }

                                //if everything ok
                                if (sError.Length == 0)
                                {
                                    string result="";
                                    //////////////////////////////////////////////////////////////////////////
                                    //try create Set CE ID for Alarm
                                    try
                                    {
                                        this.m_ICxClientTool.CreateEvent(AVPConstants.iConnectionCommonID, iSetCEColID, sName + "SET", ref result);
                                    }
                                    catch 
                                    {
                                        sError = "Can Not Create: +" + iSetCEColID + ", This ID is existed";	
                                    }

                                    //try create Clear CE ID for Alarm
                                    try
                                    {
                                        this.m_ICxClientTool.CreateEvent(AVPConstants.iConnectionCommonID, iClearCEColID, sName + "CLEAR", ref result);
                                    }
                                    catch 
                                    {
                                        sError = "Can Not Create: +" + iClearCEColID + ", This ID is existed";
                                    }

                                    //try create Alarm ID
                                    try
                                    {
                                        this.m_ICxClientTool.CreateAlarm(iAlarmID, sText, ref sName, ref sDesc, iSetCEColID, iClearCEColID);
                                    }
                                    catch 
                                    {
                                        sError = "Can Not Create: +" + iClearCEColID + ", This ID is existed";
                                    }
                                    m_CacheVariables.Add(sName, sText);
                                }
                            }
                            else
                            {
                                sError = ChamberName + " , " + sID + ": ID Column is empty";
                            }

                            if(sError.Length > 0)
                            {
                                AVPSecsGemLog.avpSecsGemLogger.Error(sError);
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                AVPSecsGemLog.avpSecsGemLogger.Error(ex.Message);
            }
        }
        private AVPChamberID convertChamberName_To_GemID(string ChamberName)
        {
            if(ChamberName.ToUpper() == "LOADLOCKA")
            {
            return AVPChamberID.LLA ;
            }
            else if(ChamberName.ToUpper() == "CHAMBER1")
            {
                return AVPChamberID.PM1 ;
            }
            else if(ChamberName.ToUpper() == "CHAMBER2")
            {
                return AVPChamberID.PM2 ;
            }
            else if(ChamberName.ToUpper() == "CHAMBER3")
            {
                return AVPChamberID.PM3;
            }
            else if (ChamberName.ToUpper() == "TM")
            {
             return AVPChamberID.TM;
            }
            return AVPChamberID.SYSTEM;
                        
        }

        public void Create_Alarms(string chamberName, AVP_GEMTYPE gem_type)
        {
            try
            {
                AVPChamberID ChamberID = convertChamberName_To_GemID(chamberName);

                DataTable dt = null;
                switch (gem_type)
                {
                    case AVP_GEMTYPE.COMMON:
                        //////////////////////////////////////////////////////////////////////////
                        //At this time, this function never in use
                        //alway chamberID = SYSTEM
                        //function CreateAlarm will be exit when chamberID = SYSTEM
                        //////////////////////////////////////////////////////////////////////////
                        dt = AVPSecsGemConfiguration.Load_Common_Alarm();
                        CreateAlarm(dt, ChamberID);
                        break;
                    case AVP_GEMTYPE.IBE_CHAMBER:
                        dt = AVPSecsGemConfiguration.Load_IBEGEM_Alarm();
                        CreateAlarm(dt,ChamberID);
                        break;
                    case AVP_GEMTYPE.PVD_CHAMBER:
                        dt = AVPSecsGemConfiguration.Load_PVDGEM_Alarm();
                        CreateAlarm(dt,ChamberID);
                        break;
                    case AVP_GEMTYPE.CORONA_CHAMBER:
                        dt = AVPSecsGemConfiguration.Load_CORONA_GEM_Alarm();
                        CreateAlarm(dt, ChamberID);
                        break;
                    case AVP_GEMTYPE.PVD5T_CHAMBER:
                        dt = AVPSecsGemConfiguration.Load_PVD5T_GEM_Alarm();
                        CreateAlarm(dt, ChamberID);
                        break;
                    case AVP_GEMTYPE.LOADLOCK:
                        dt = AVPSecsGemConfiguration.Load_LoadLockGEM_Alarm();
                        CreateAlarm(dt,ChamberID);
                        break;
                    case AVP_GEMTYPE.TRANSFERMODULE: //TRUCLE MISSING LOAD TM ALARM
                        dt = AVPSecsGemConfiguration.Load_TMGEM_Alarm();
                        CreateAlarm(dt,ChamberID);
                        break;
                }
            }
            catch (System.Exception ex)
            {
                AVPSecsGemLog.avpSecsGemLogger.Error(ex.Message);
            }
        }

        public void Create_Events(string chamberName, AVP_GEMTYPE gem_type)
        {
            try
            {
                AVPChamberID ChamberID = convertChamberName_To_GemID(chamberName);

                DataTable dt = null;
                switch (gem_type)
                {
                    case AVP_GEMTYPE.COMMON:
                        //////////////////////////////////////////////////////////////////////////
                        //At this time, this function never in use
                        //alway chamberID = SYSTEM
                        //function CreateAlarm will be exit when chamberID = SYSTEM
                        //////////////////////////////////////////////////////////////////////////
                        dt = AVPSecsGemConfiguration.Load_Common_Event();
                        CreateEvents(dt,ChamberID);
                        break;
                    case AVP_GEMTYPE.IBE_CHAMBER:
                        dt = AVPSecsGemConfiguration.Load_IBEGEM_Event();
                        CreateEvents(dt,ChamberID);
                        break;
                    case AVP_GEMTYPE.PVD_CHAMBER:
                        dt = AVPSecsGemConfiguration.Load_PVDGEM_Event();
                        CreateEvents(dt,ChamberID);
                        break;
                    case AVP_GEMTYPE.CORONA_CHAMBER:
                        dt = AVPSecsGemConfiguration.Load_CORONA_GEM_Event();
                        CreateEvents(dt, ChamberID);
                        break;
                    case AVP_GEMTYPE.PVD5T_CHAMBER:
                        dt = AVPSecsGemConfiguration.Load_PVD5T_GEM_Event();
                        CreateEvents(dt, ChamberID);
                        break;
                    case AVP_GEMTYPE.LOADLOCK:
                        dt = AVPSecsGemConfiguration.Load_LoadLockGEM_Event();
                        CreateEvents(dt,ChamberID);
                        break;
                    case AVP_GEMTYPE.TRANSFERMODULE: //TRUCLE MISSING LOAD TM ALARM
                        dt = AVPSecsGemConfiguration.Load_TMGEM_Event();
                        CreateEvents(dt,ChamberID);
                        break;
                }
            }
            catch (System.Exception ex)
            {
                AVPSecsGemLog.avpSecsGemLogger.Error(ex.Message);
            }
        }

        public void CreateVariables(string chamberName, AVP_GEMTYPE gem_type)
        {
            try
            {
                AVPChamberID ChamberID = convertChamberName_To_GemID(chamberName);

                DataTable dt = null;
                switch (gem_type)
                {
                    case AVP_GEMTYPE.COMMON:
                        //////////////////////////////////////////////////////////////////////////
                        //At this time, this function never in use
                        //alway chamberID = SYSTEM
                        //function CreateAlarm will be exit when chamberID = SYSTEM
                        //////////////////////////////////////////////////////////////////////////
                        dt = AVPSecsGemConfiguration.Load_Common_Variable();
                        CreateVariable(dt, ChamberID);
                        break;
                    case AVP_GEMTYPE.IBE_CHAMBER:
                        dt = AVPSecsGemConfiguration.Load_IBEGEM_Variable();
                        CreateVariable(dt, ChamberID);
                        break;
                    case AVP_GEMTYPE.PVD_CHAMBER:
                        dt = AVPSecsGemConfiguration.Load_PVDGEM_Variable();
                        CreateVariable(dt, ChamberID);
                        break;
                    case AVP_GEMTYPE.CORONA_CHAMBER:
                        dt = AVPSecsGemConfiguration.Load_CORONA_GEM_Variable();
                        CreateVariable(dt, ChamberID);
                        break;
                    case AVP_GEMTYPE.PVD5T_CHAMBER:
                        dt = AVPSecsGemConfiguration.Load_PVD5T_GEM_Variable();
                        CreateVariable(dt, ChamberID);
                        break;
                    case AVP_GEMTYPE.LOADLOCK:
                         dt = AVPSecsGemConfiguration.Load_LoadLockGEM_Variable();
                        CreateVariable(dt, ChamberID);
                        break;
                    case AVP_GEMTYPE.TRANSFERMODULE: //TRUCLE MISSING LOAD TM ALARM
                        dt = AVPSecsGemConfiguration.Load_TMGEM_Variable();
                        CreateVariable(dt, ChamberID);
                        break;
                }
            }
            catch (System.Exception ex)
            {
                AVPSecsGemLog.avpSecsGemLogger.Error(ex.Message);
            }
        }

        protected void CreateAlarm(DataTable dt, SLToolID chamberID)
        {
            try
            {
                string ChamberName = chamberID.ToString();
                if (chamberID == SLToolID.SYSTEM)
                {
                    return;
                }

                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row[AVPConstants.iALARMID_DBCOLUMN] != null)
                        {
                            string sID = row[AVPConstants.iALARMID_DBCOLUMN].ToString().Trim();
                            string sName = row[AVPConstants.iALARMNAME_DBCOLUMN].ToString().Trim();
                            string sText = row[AVPConstants.iALARMTEXT_DBCOLUMN].ToString().Trim();
                            string sDesc = row[AVPConstants.iALARMDESC_DBCOLUMN].ToString().Trim();
                            string sSetCECollectionID = row[AVPConstants.iALARMSET_CEID_DBCOLUMN].ToString().Trim();
                            string sClearCECollectionID = row[AVPConstants.iALARMCLEAR_CEID_DBCOLUMN].ToString().Trim();

                            string sError = "";
                            if (sID.Length > 0)
                            {
                                int iAlarmID = Convert.ToInt32(sID);
                                iAlarmID = (int)chamberID * AVPConstants.iGEM_generateID + iAlarmID;

                                if (ChamberName.Length > 0)
                                {
                                    sName = ChamberName + "." + sName;
                                }
                                else
                                {
                                    sError = ChamberName + " , " + sID + ": EVETNNAME column is Empty";
                                }

                                int iSetCEColID = -1;
                                int iClearCEColID = -1;
                                //////////////////////////////////////////////////////////////////////////
                                //READ DATABASE
                                //IF DATABASE IS NOT EMPTY 
                                //GENETATE SETCECOLID = CHAMBERID * 1.000.000 + SETCECOLID
                                //
                                //IF DATABASE FIELD IS EMPTY
                                // SETCECOLID = ALARMID + 2000
                                // CLEARCECOLID IS THE SAME, ADD 4000 IF DATABASE FIELD IS EMPTY
                                //////////////////////////////////////////////////////////////////////////
                                if (sSetCECollectionID.Length > 0)
                                {
                                    iSetCEColID = Convert.ToInt32(sSetCECollectionID);
                                    iSetCEColID = (int)chamberID * AVPConstants.iGEM_generateID + iSetCEColID;
                                }
                                else
                                {
                                    iSetCEColID = iAlarmID + AVPConstants.iGEM_generateAlarmSetEventID;
                                }

                                if (sClearCECollectionID.Length > 0)
                                {
                                    iClearCEColID = Convert.ToInt32(sClearCECollectionID);
                                    iClearCEColID = (int)chamberID * AVPConstants.iGEM_generateID + iClearCEColID;
                                }
                                else
                                {
                                    iClearCEColID = iAlarmID + AVPConstants.iGEM_generateAlarmClearEventID;
                                }

                                //if everything ok
                                if (sError.Length == 0)
                                {
                                    string result = "";
                                    //////////////////////////////////////////////////////////////////////////
                                    //try create Set CE ID for Alarm
                                    try
                                    {
                                        this.m_ICxClientTool.CreateEvent(AVPConstants.iConnectionCommonID, iSetCEColID, sName + "SET", ref result);
                                    }
                                    catch
                                    {
                                        sError = "Can Not Create: +" + iSetCEColID + ", This ID is existed";
                                    }

                                    //try create Clear CE ID for Alarm
                                    try
                                    {
                                        this.m_ICxClientTool.CreateEvent(AVPConstants.iConnectionCommonID, iClearCEColID, sName + "CLEAR", ref result);
                                    }
                                    catch
                                    {
                                        sError = "Can Not Create: +" + iClearCEColID + ", This ID is existed";
                                    }

                                    //try create Alarm ID
                                    try
                                    {
                                        this.m_ICxClientTool.CreateAlarm(iAlarmID, sText, ref sName, ref sDesc, iSetCEColID, iClearCEColID);
                                    }
                                    catch
                                    {
                                        sError = "Can Not Create: +" + iClearCEColID + ", This ID is existed";
                                    }
                                    m_CacheVariables.Add(sName, sText);
                                }
                            }
                            else
                            {
                                sError = ChamberName + " , " + sID + ": ID Column is empty";
                            }

                            if (sError.Length > 0)
                            {
                                AVPSecsGemLog.avpSecsGemLogger.Error(sError);
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                AVPSecsGemLog.avpSecsGemLogger.Error(ex.Message);
            }
        }

        protected void CreateEvents(DataTable dt, SLToolID chamberID)
        {
            try
            {
                if (dt != null)
                {
                    string ChamberName = chamberID.ToString();
                    foreach (DataRow row in dt.Rows)
                    {
                        string sError = "";
                        //0 = ID, 2 = Type, 5 = Name 
                        if (row[AVPConstants.iEVENTID_DBCOLUMN] != null)
                        {
                            string sID = row[AVPConstants.iEVENTID_DBCOLUMN].ToString().Trim();
                            string sName = row[AVPConstants.iEVENTNAME_DBCOLUMN].ToString().Trim();
                            string sDesc = row[AVPConstants.iEVENTDESC_DBCOLUMN].ToString().Trim();

                            if (sID.Length > 0)
                            {
                                int ID = Convert.ToInt32(sID);
                                ID = (int)chamberID * AVPConstants.iGEM_generateID + ID;

                                if (ChamberName.Length > 0)
                                {
                                    sName = ChamberName + "." + sName;
                                }
                                else
                                {
                                    sError = ChamberName + " , " + sID + ": EVETNNAME column is Empty";
                                }

                                //try to Create Event
                                try
                                {
                                    this.m_ICxClientTool.CreateEvent(AVPConstants.iConnectionID, ID, sName, ref sDesc);
                                }
                                catch
                                {
                                    sError = ChamberName + " , " + sID + ": EVETID is existed";
                                }
                            }
                            else
                            {
                                sError = ChamberName + " , " + sID + ": EVETID column is Empty";
                            }
                        }

                        if (sError.Length > 0)
                        {
                            AVPSecsGemLog.avpSecsGemLogger.Error(sError);
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                AVPSecsGemLog.avpSecsGemLogger.Error(ex.Message);
            } 
        }

        protected void CreateVariable(DataTable dt, SLToolID chamberID)
        {
            try
            {
                if (dt != null)
                {
                    string chamberName = chamberID.ToString();
                    foreach (DataRow row in dt.Rows)
                    {
                        //0 = ID, 2 = Type, 5 = Name 
                        if (row[1] != null)
                        {
                            string sError = string.Empty;
                            //variable from database
                            int varID = Convert.ToInt32(row[AVPConstants.iGEMID_DBCOLUMN].ToString().Trim());    //integer
                            varID = (int)chamberID * AVPConstants.iGEM_generateID + varID;
                            string sVarType = row[AVPConstants.iGEMTYPE_DBCOLUMN].ToString().Trim();                 //EC, SV, DV
                            VALUELib.ValueType valueType = this.GetValueTypeFromString(row[AVPConstants.iGEMFORMAT_DBCOLUMN].ToString());
                            string valName = row[AVPConstants.iGEMNAME_DBCOLUMN].ToString().Trim();
                            valName = chamberName + "." + valName;
                            string cx_min = row[AVPConstants.iGEMMIN_DBCOLUMN].ToString().Trim();
                            string cx_max = row[AVPConstants.iGEMMAX_DBCOLUMN].ToString().Trim();
                            string cx_default = row[AVPConstants.iGEMDEFAULTVAL_DBCOLUMN].ToString().Trim();
                            string description = row[AVPConstants.iGEMDESCRIPTION_DBCOLUMN].ToString().Trim(); ;
                            string units = row[AVPConstants.iGEMUNITS_DBCOLUMN].ToString().Trim();
                            string sEventID = row[AVPConstants.iGEMEVENTID_DBCOLUMN].ToString().Trim();

                            //map variable to obj
                            CxValueObject cx_minObj = new CxValueObject();
                            if (cx_min.Length > 0)
                            {
                                SetNumericValue(valueType, cx_min, ref cx_minObj);
                            }

                            CxValueObject cx_maxObj = new CxValueObject();
                            if (cx_max.Length > 0)
                            {
                                SetNumericValue(valueType, cx_max, ref cx_maxObj);
                            }

                            CxValueObject cx_defaultValObj = new CxValueObject();
                            if (cx_default.Length > 0)
                            {
                                SetNumericValue(valueType, cx_default, ref cx_defaultValObj);
                            }

                            VarType varType = VarType.varANY;
                            bool isPrivate = false;
                            bool isPersistent = false;
                            int eventID = -1;

                            switch (sVarType)
                            {
                                case "EC":
                                    varType = VarType.EC;
                                    //////////////////////////////////////////////////////////////////////////
                                    //Try Create EC
                                    try
                                    {
                                        this.m_ICxClientTool.CreateVariable(AVPConstants.iConnectionID, varID, varType, valueType, -1, valName,
                                    ref description, ref units, cx_minObj, cx_maxObj, cx_defaultValObj, ref isPrivate, ref isPersistent);
                                        m_CxClientClerk.RegisterSetValueHandler(0, varID, this.m_CIMConnectCallback);
                                    }
                                    catch
                                    {
                                        sError = varType.ToString() + varID + ": existed";
                                    }
                                    //Add Variable Name to Hast table
                                    m_CacheVariables.Add(valName, cx_default);
                                    break;
                                case "SV":

                                    if (sEventID.Length > 0)
                                    {
                                        eventID = Convert.ToInt32(sEventID);
                                        try
                                        {
                                            this.m_ICxClientTool.CreateEvent(AVPConstants.iConnectionID, eventID, valName + " LimitCEID", ref description);
                                        }
                                        catch
                                        {
                                            sError = valName + "," + eventID + ": existed";
                                        }

                                    }
                                    varType = VarType.SV;
                                    try
                                    {
                                        this.m_ICxClientTool.CreateVariable(AVPConstants.iConnectionID, varID, varType, valueType,
                                eventID, valName, ref description, ref units, cx_maxObj, cx_minObj, cx_defaultValObj, ref isPrivate, ref isPersistent);
                                    }
                                    catch
                                    {
                                        sError = varType + "," + varID + ": existed";
                                    }
                                    //Add Variable Name to Hast table
                                    if (m_CacheVariables.ContainsKey(valName) == false)
                                    {
                                        m_CacheVariables.Add(valName, cx_default);
                                    }
                                    break;
                                case "DV":
                                    varType = VarType.DV;
                                    try
                                    {
                                        this.m_ICxClientTool.CreateVariable(AVPConstants.iConnectionID, varID, varType, valueType,
                                   eventID, valName, ref description, ref units, cx_maxObj, cx_minObj, cx_defaultValObj, ref isPrivate, ref isPersistent);
                                    }
                                    catch
                                    {
                                        sError = varType + "," + varID + ": existed";
                                    }
                                    //Add Variable Name to Hast table
                                    m_CacheVariables.Add(valName, cx_default);
                                    break;
                                default:
                                    //do nothing
                                    break;
                            }

                            if (sError != string.Empty)
                            {
                                AVPSecsGemLog.avpSecsGemLogger.Error(sError);
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                AVPSecsGemLog.avpSecsGemLogger.Error(ex.Message);
            }
        }
        
        //private SLToolID converToolName_To_GemID(string ToolName)
        //{
        //    if (ToolName.ToUpper() == "LOADER")
        //        return SLToolID.LOADER;
        //    else if (ToolName.ToUpper() == "CHAMBER1")
        //        return SLToolID.PM;
        //    return SLToolID.SYSTEM;
        //}

        //public void Create_Alarms(string chamberName, SL_GEMTYPE gem_type)
        //{
        //    try
        //    {
        //        SLToolID ToolID = converToolName_To_GemID(chamberName);
        //        DataTable dt = null;
        //        switch (gem_type)
        //        {
        //            case SL_GEMTYPE.COMMON:
        //                dt = AVPSecsGemConfiguration.Load_Common_Alarm();
        //                CreateAlarm(dt, ToolID);
        //                break;
        //            case SL_GEMTYPE.IBE_CHAMBER:
        //                dt = AVPSecsGemConfiguration.Load_IBEGEM_Alarm();
        //                CreateAlarm(dt, ToolID);
        //                break;
        //            //case SL_GEMTYPE.LOADER:
        //            //    dt = AVPSecsGemConfiguration.Load_Loader_Alarms();
        //            //    CreateAlarm(dt, ToolID);
        //            //     break;
        //        }
        //    }
        //    catch (System.Exception ex)
        //    {
        //        AVPSecsGemLog.avpSecsGemLogger.Error(ex.Message);
        //    }
        //}

        //public void Create_Events(string chamberName, SL_GEMTYPE gem_type)
        //{
        //    try
        //    {
        //        SLToolID ToolID = converToolName_To_GemID(chamberName);
        //        DataTable dt = null;
        //        switch (gem_type)
        //        {
        //            case SL_GEMTYPE.COMMON:
        //                dt = AVPSecsGemConfiguration.Load_Common_Event();
        //                CreateEvents(dt, ToolID);
        //                break;
        //            case SL_GEMTYPE.IBE_CHAMBER:
        //                dt = AVPSecsGemConfiguration.Load_IBEGEM_Event();
        //                CreateEvents(dt, ToolID);
        //                break;
        //            //case SL_GEMTYPE.LOADER:
        //            //    dt = AVPSecsGemConfiguration.Load_Loader_Events();
        //            //    CreateEvents(dt, ToolID);
        //            //    break;
        //        }

        //    }
        //    catch (System.Exception ex)
        //    {
        //        AVPSecsGemLog.avpSecsGemLogger.Error(ex.Message);
        //    }
        //}

        //public void Create_Variables(string chamberName, SL_GEMTYPE gem_type)
        //{
        //    try
        //    {
        //        SLToolID ToolID = converToolName_To_GemID(chamberName);
        //        DataTable dt = null;
        //        switch (gem_type)
        //        {
        //            case SL_GEMTYPE.COMMON:
        //                dt = AVPSecsGemConfiguration.Load_Common_Variable();
        //                CreateVariable(dt, ToolID);
        //                break;
        //            case SL_GEMTYPE.IBE_CHAMBER:
        //                dt = AVPSecsGemConfiguration.Load_IBEGEM_Variable();
        //                CreateVariable(dt, ToolID);
        //                break;
        //            case SL_GEMTYPE.LOADER:
        //                dt = AVPSecsGemConfiguration.Load_Loader_Variables();
        //                CreateVariable(dt, ToolID);
        //                break;
        //        }

        //    }
        //    catch (System.Exception ex)
        //    {
        //        AVPSecsGemLog.avpSecsGemLogger.Error(ex.Message);
        //    }
        //}

        internal bool SetValueByType(out string sVal, CxValueObject cxValObj)
        {
            sVal = "";
            try
            {
                if (cxValObj != null)
                {
                    short num3;
                    int num4;
                    byte num5;
                    VALUELib.ValueType type;
                    cxValObj.GetDataType(0, 0, out type);
                    switch (type)
                    {
                        case VALUELib.ValueType.I1:
                            cxValObj.GetValueI1(0, 0, out num3);
                            sVal = num3.ToString();
                            goto Label_01DA;

                        case VALUELib.ValueType.I2:
                            cxValObj.GetValueI2(0, 0, out num3);
                            sVal = num3.ToString();
                            goto Label_01DA;

                        case VALUELib.ValueType.I4:
                            cxValObj.GetValueI4(0, 0, out num4);
                            sVal = num4.ToString();
                            goto Label_01DA;

                        case VALUELib.ValueType.I8:
                            cxValObj.GetValueI8(0, 0, out num4);
                            sVal = num4.ToString();
                            goto Label_01DA;

                        case VALUELib.ValueType.U1:
                            cxValObj.GetValueU1(0, 0, out num5);
                            sVal = num5.ToString();
                            goto Label_01DA;

                        case VALUELib.ValueType.U2:
                            cxValObj.GetValueU2(0, 0, out num4);
                            sVal = num4.ToString();
                            goto Label_01DA;

                        case VALUELib.ValueType.U4:
                            cxValObj.GetValueU4(0, 0, out num4);
                            sVal = num4.ToString();
                            goto Label_01DA;

                        case VALUELib.ValueType.U8:
                            cxValObj.GetValueU8(0, 0, out num4);
                            sVal = num4.ToString();
                            goto Label_01DA;

                        case VALUELib.ValueType.F4:
                            float num;
                            cxValObj.GetValueF4(0, 0, out num);
                            sVal = num.ToString();
                            goto Label_01DA;

                        case VALUELib.ValueType.F8:
                            double num2;
                            cxValObj.GetValueF8(0, 0, out num2);
                            sVal = num2.ToString();
                            goto Label_01DA;

                        case VALUELib.ValueType.A:
                            cxValObj.GetValueAscii(0, 0, out sVal);
                            goto Label_01DA;

                        case VALUELib.ValueType.Bo:
                            bool flag;
                            cxValObj.GetValueBoolean(0, 0, out flag);
                            sVal = flag.ToString();
                            goto Label_01DA;

                        case VALUELib.ValueType.Bi:
                            cxValObj.GetValueBinary(0, 0, out num5);
                            sVal = num5.ToString();
                            goto Label_01DA;

                        case VALUELib.ValueType.L:
                            cxValObj.CopyToString(0, 0, out sVal);
                            goto Label_01DA;
                    }
                }
                return false;
            }
            catch (Exception exception)
            {
                AVPSecsGemLog.avpSecsGemLogger.Error("SetValueByType: CxValueObject.GetValue__() error " + exception.Message);
                return false;
            }
        Label_01DA:
            return true;
        }
        protected bool SetValueByType(VALUELib.ValueType valType, string sVal, ref CxValueObject cxValObj)
        {
            Exception exception;
            bool boolFromString = false;
            try
            {
                switch (valType)
                {
                    case VALUELib.ValueType.I1:
                    case VALUELib.ValueType.I2:
                    case VALUELib.ValueType.I4:
                    case VALUELib.ValueType.I8:
                    case VALUELib.ValueType.U1:
                    case VALUELib.ValueType.U2:
                    case VALUELib.ValueType.U4:
                    case VALUELib.ValueType.U8:
                    case VALUELib.ValueType.F4:
                    case VALUELib.ValueType.F8:
                    case VALUELib.ValueType.Bi:
                        return this.SetNumericValue(valType, sVal, ref cxValObj);

                    case VALUELib.ValueType.A:
                    case VALUELib.ValueType.L:
                        goto Label_00AF;

                    case VALUELib.ValueType.Bo:
                        boolFromString = GetBoolFromString(sVal, false);
                        goto Label_00AF;
                }
                return true;
            }
            catch (Exception exception1)
            {
                exception = exception1;
                AVPSecsGemLog.avpSecsGemLogger.Error("SetValueByType: parse error on value " + exception.Message);
                return false;
            }
        Label_00AF: ;
            try
            {
                switch (valType)
                {
                    case VALUELib.ValueType.A:
                        cxValObj.SetValueAscii(0, 0, sVal);
                        goto Label_0120;

                    case VALUELib.ValueType.W:
                    case VALUELib.ValueType.Bi:
                        goto Label_0120;

                    case VALUELib.ValueType.Bo:
                        cxValObj.SetValueBoolean(0, 0, boolFromString);
                        goto Label_0120;

                    case VALUELib.ValueType.L:
                        cxValObj.RestoreFromString(0, 0, sVal);
                        goto Label_0120;
                }
            }
            catch (Exception exception2)
            {
                exception = exception2;
                AVPSecsGemLog.avpSecsGemLogger.Error("SetValueByType: set value error on CxValueObject " + exception.Message);
                return false;
            }
        Label_0120:
            return true;
        }
        public static long GetLongFromString(string numStr, long defVal)
        {
            CultureInfo MyCultureInfo = new CultureInfo("en-US");
            long result = defVal;
            float num2;
            try
            {
                if (numStr == null)
                {
                    result = defVal;
                }
                if (long.TryParse(numStr, NumberStyles.Number, MyCultureInfo, out result))
                {
                    return result;
                }

                num2 = defVal;
                if (!float.TryParse(numStr, NumberStyles.Float, MyCultureInfo, out num2))
                {
                    return result;
                }
                return Convert.ToInt64(num2);
            }
            catch
            {
                long num3;
                try
                {
                    num2 = defVal;
                    if (!float.TryParse(numStr, NumberStyles.Float, MyCultureInfo, out num2))
                    {
                        return result;
                    }
                    num3 = Convert.ToInt64(num2);
                    return num3;
                }
                catch
                {
                }
                return result;
            }
        }
        protected bool GetBoolFromString(string numStr, bool defVal)
        {
            if (numStr == null)
            {
                return defVal;
            }
            numStr = numStr.Trim();
            if (numStr.Length == 0)
            {
                return defVal;
            }
            long longFromString = GetLongFromString(numStr, -1L);
            if ((longFromString != -1L) && (longFromString > 0L))
            {
                return true;
            }
            numStr = numStr.Substring(0, 1);
            return ((((numStr.CompareTo("t") == 0) || (numStr.CompareTo("T") == 0)) || ((numStr.CompareTo("1") == 0) || (numStr.CompareTo("y") == 0))) || (numStr.CompareTo("Y") == 0));
        }
        protected bool SetNumericValue(VALUELib.ValueType valType, string sVal, ref CxValueObject cxValObj)
        {
            Exception exception;
            float num = 0f;
            double num2 = 0.0;
            short num3 = 0;
            int num4 = 0;
            byte num5 = 0;
            try
            {
                if (sVal.Length != 0)
                {
                    switch (valType)
                    {
                        case VALUELib.ValueType.I1:
                        case VALUELib.ValueType.I2:
                            num3 = short.Parse(sVal);
                            goto Label_00FF;

                        case VALUELib.ValueType.I4:
                        case VALUELib.ValueType.I8:
                            num4 = int.Parse(sVal);
                            goto Label_00FF;

                        case VALUELib.ValueType.U1:
                        case VALUELib.ValueType.Bi:
                            num5 = byte.Parse(sVal);
                            goto Label_00FF;

                        case VALUELib.ValueType.U2:
                        case VALUELib.ValueType.U4:
                        case VALUELib.ValueType.U8:
                            num4 = int.Parse(sVal);
                            if (num4 >= 0)
                            {
                                goto Label_00FF;
                            }
                            return false;

                        case VALUELib.ValueType.F4:
                            num = float.Parse(sVal);
                            goto Label_00FF;

                        case VALUELib.ValueType.F8:
                            num2 = double.Parse(sVal);
                            goto Label_00FF;
                    }
                }
                return false;
            }
            catch (Exception exception1)
            {
                exception = exception1;
                AVPSecsGemLog.avpSecsGemLogger.Error("SetNumericValue: parse error on value " + sVal + " " + exception.Message);
                return false;
            }
        Label_00FF: ;
            try
            {
                switch (valType)
                {
                    case VALUELib.ValueType.I1:
                        cxValObj.SetValueI1(0, 0, num3);
                        goto Label_0206;

                    case VALUELib.ValueType.I2:
                        cxValObj.SetValueI2(0, 0, num3);
                        goto Label_0206;

                    case VALUELib.ValueType.I4:
                        cxValObj.SetValueI4(0, 0, num4);
                        goto Label_0206;

                    case VALUELib.ValueType.I8:
                        cxValObj.SetValueI8(0, 0, num4);
                        goto Label_0206;

                    case VALUELib.ValueType.U1:
                        cxValObj.SetValueU1(0, 0, num5);
                        goto Label_0206;

                    case VALUELib.ValueType.U2:
                        cxValObj.SetValueU2(0, 0, num4);
                        goto Label_0206;

                    case VALUELib.ValueType.U4:
                        cxValObj.SetValueU4(0, 0, num4);
                        goto Label_0206;

                    case VALUELib.ValueType.U8:
                        cxValObj.SetValueU8(0, 0, num4);
                        goto Label_0206;

                    case VALUELib.ValueType.F4:
                        cxValObj.SetValueF4(0, 0, num);
                        goto Label_0206;

                    case VALUELib.ValueType.F8:
                        cxValObj.SetValueF8(0, 0, num2);
                        goto Label_0206;

                    case VALUELib.ValueType.A:
                    case VALUELib.ValueType.W:
                    case VALUELib.ValueType.Bo:
                        goto Label_0206;

                    case VALUELib.ValueType.Bi:
                        cxValObj.SetValueBinary(0, 0, num5);
                        goto Label_0206;
                }
            }
            catch (Exception exception2)
            {
                exception = exception2;
                AVPSecsGemLog.avpSecsGemLogger.Error("SetNumericValue: CxValueObject.SetValue__() error  " + exception.Message);
                return false;
            }
        Label_0206:
            return true;
        }
        protected VALUELib.ValueType GetValueTypeFromString(string sValueType)
        {
            switch (sValueType)
            {
                case "A":
                    return VALUELib.ValueType.A;

                case "Bi":
                    return VALUELib.ValueType.Bi;

                case "Bo":
                    return VALUELib.ValueType.Bo;

                case "F4":
                    return VALUELib.ValueType.F4;

                case "F8":
                    return VALUELib.ValueType.F8;

                case "I1":
                    return VALUELib.ValueType.I1;

                case "I2":
                    return VALUELib.ValueType.I2;

                case "I4":
                    return VALUELib.ValueType.I4;

                case "I8":
                    return VALUELib.ValueType.I8;

                case "J":
                    return VALUELib.ValueType.J;

                case "L":
                    return VALUELib.ValueType.L;

                case "U1":
                    return VALUELib.ValueType.U1;

                case "U2":
                    return VALUELib.ValueType.U2;

                case "U4":
                    return VALUELib.ValueType.U4;

                case "U8":
                    return VALUELib.ValueType.U8;

                case "ANY":
                    return VALUELib.ValueType.valueANY;

                case "ARRAY":
                    return VALUELib.ValueType.valueARRAY;

                case "W":
                    return VALUELib.ValueType.W;
            }
            return VALUELib.ValueType.valueANY;
        }
        /// <summary>
        /// Final initialization of the GEM interface. Until this is called, communication
        /// with the GEM Host is not permitted. This allows for equipment initialization to
        /// be completed as well as initialization of CIMConnect and this application. 
        /// </summary>
        public void InitializeFinal()
        {
            try
            {
                ulong defaultCommState = 0;
                for (int i = 1; i <= m_NumberOfConnections; i++)
                {
                    GetVariableValue( i, "DefaultCommState", ref defaultCommState );
                    if (256 == defaultCommState)
                    {
                        m_CxClientClerk.EnableComm(i); 
                    }
                }
                m_initialized = true;
                
                // Update recipe path
                string sRecipePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "DataFiles\\GEMData";

                CacheVariable("RecipePath", sRecipePath);
                CacheVariable("RecipeExtension", "xml");
                CacheVariable("MDLN", "CX4");//Model

                System.Reflection.Assembly AVPVersion = System.Reflection.Assembly.GetExecutingAssembly();//System.Reflection.Assembly.GetExecutingAssembly;
                String strVer = AVPVersion.GetName().Version.Major.ToString() + "." + AVPVersion.GetName().Version.Minor.ToString() + "." + AVPVersion.GetName().Version.Build.ToString();//'arrSection[0] + "." + arrSection [2];
                CacheVariable("SOFTREV", strVer);
                
                // Restore NVS
                if (null != m_CxClientClerk)
                {
                    m_CxClientClerk.RestoreNVS(); 
                }
                
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                HandleCOMException("Exception in the final initialization of CIMConnect", e);
            }
        }

        public void Shutdown()
        {
            try
            {
                m_initialized = false; 
                if (null != m_CxClientClerk)
                {
                    for (int i = 1; i <= m_NumberOfConnections; i++)
                    {
                        try
                        {
                            AVPSecsGemLog.avpSecsGemLogger.Debug("CxClientClerk.UnregisterStateMachineHandler " + i.ToString());
                            m_CxClientClerk.UnregisterStateMachineHandler(i, m_CIMConnectCallback);
                            AVPSecsGemLog.avpSecsGemLogger.Debug("CxClientClerk.UnregisterStateMachineHandler " + i.ToString());
                        }
                        catch
                        {
                            if (null != m_CxEMService)
                            {
                                AVPSecsGemLog.avpSecsGemLogger.Error("CxEMService.StopService");
                                m_CxEMService.StopService();
                            }
                        }
                    }

                    try
                    {
                        AVPSecsGemLog.avpSecsGemLogger.Debug("CxClientClerk.UnregisterTerminalMsgHandler");
                        m_CxClientClerk.UnregisterTerminalMsgHandler(m_CIMConnectCallback);

                        AVPSecsGemLog.avpSecsGemLogger.Debug("CxClientClerk.UnregisterCommandHandler");
                        m_CxClientClerk.UnregisterCommandHandler("PP-SELECT");
                        m_CxClientClerk.UnregisterCommandHandler("START");
                        m_CxClientClerk.UnregisterCommandHandler("STOP");
                        m_CxClientClerk.UnregisterCommandHandler("ABORT");
                        m_CxClientClerk.UnregisterCommandHandler("RESUME");
                        m_CxClientClerk.UnregisterCommandHandler("PAUSE");
                        m_CxClientClerk.UnregisterCommandHandler("MARK_FOR_RETURN");
                        m_CxClientClerk.UnregisterCommandHandler("MAKE_ALL_ONLINE");
                        m_CxClientClerk.UnregisterCommandHandler("LOAD");
                        m_CxClientClerk.UnregisterCommandHandler("UNLOAD");
                    }
                    catch
                    {
                        AVPSecsGemLog.avpSecsGemLogger.Error("Can not unregister");
                        if (null != m_CxEMService)
                        {
                            AVPSecsGemLog.avpSecsGemLogger.Error("CxEMService.StopService");
                            m_CxEMService.StopService();
                        }
                    }
                    //////////////////////////////////////////////////////////////////////////
                    //////////////////////////////////////////////////////////////////////////
                    //<<TODO>> UNREGISTER CALLBACK HERE...
                    //////////////////////////////////////////////////////////////////////////
                    //////////////////////////////////////////////////////////////////////////
                }
                if ( null != m_CxEMService )
                {
                    AVPSecsGemLog.avpSecsGemLogger.Error( "CxEMService.StopService" ); 
                    m_CxEMService.StopService(); 
                }
                m_setAlarmList = null;
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                HandleCOMException("Exception shutting down CMyCIMConnect", e);
                if (null != m_CxEMService)
                {
                    AVPSecsGemLog.avpSecsGemLogger.Error("CxEMService.StopService");
                    m_CxEMService.StopService();
                }
            }
        }

        /// <author>
        /// <name>Dat Cao</name>
        /// <date> 2011-06-20</date>
        /// </author>
        /// <summary>
        /// Load config file with all variable and default variable
        /// Use AVPSecsGemConfig ojb
        /// add variable to cache has
        /// </summary>
        /// <para></para>
        /// <returns></returns>
        private bool CheckVariableChange(string key, string value)
        {
            bool result = false;
            try
            {
                if (m_CacheVariables.Contains(key))
                {
                    string newval = (string)m_CacheVariables[key];
                    if (newval != value)
                    {
                        result = true;
                        m_CacheVariables[key] = value;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            catch (System.Exception ex)
            {
                AVPSecsGemLog.avpSecsGemLogger.Error(ex.Message);
                result = false;
            }
            return result;
        }
        /// <summary>
        /// Convert a SECS-II message ID into the stream number and function number. 
        /// </summary>
        /// <param name="messageID">SECS-II message ID</param>
        /// <param name="s">stream number</param>
        /// <param name="f">function number</param>
        public void MsgIDtoSF(int messageID, out int s, out int f)
        {
            s = (messageID >> 8) & 0xff;
            f = messageID & 0xff;
        }

        /// <summary>
        /// Convert a stream number and function number into a SECS-II message ID; 
        /// </summary>
        /// <param name="s">stream </param>
        /// <param name="f">function</param>
        /// <returns>SECS-II message ID</returns>
        public int SFtoMsgID(int s, int f)
        {
            return (s << 8) | f;
        }

        /// <summary>
        /// Send a terminal service text message to the host.
        /// </summary>
        /// <param name="message">The text message</param>
        public void SendTerminalMessage(string message)
        {
            try
            {
                AVPSecsGemLog.avpSecsGemLogger.Error("CxClientClerk.SendTerminalMsg");
                m_CxClientClerk.SendTerminalMsg(AVPConstants.iConnectionID, 0, message);
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                HandleCOMException("Exception calling ::SendTerminalMsg", e);
            }
        }

        /// <summary>
        /// Send a terminal service acknowledge event to the
        /// host. Send to host 1 by default.
        /// </summary>
        public void SendTerminalAcknowledge()
        {
            try
            {
                string name = "MessageRecognition";
                AVPSecsGemLog.avpSecsGemLogger.Debug("CxClientClerk.TriggerWellKnownEvent " + name);
                m_CxClientClerk.TriggerWellKnownEvent(AVPConstants.iConnectionID, name);
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                HandleCOMException("Exception calling ::TriggerWellKnownEvent", e);
            }
        }

        /// <summary>
        /// Send a collection event to all host connections
        /// </summary>
        /// <param name="eventName">Collection Event name</param>
        public void SendCollectionEvent(string eventName)
        {
            try
            {
                int eventID = -1;
                AVPSecsGemLog.avpSecsGemLogger.Debug("CxClientClerk.TriggerEvent " + eventName);
                m_CxClientClerk.TriggerEvent(0, ref eventID, ref eventName);
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                HandleCOMException("Exception SendCollectionEvent " + eventName, e);
            }
        }

        /// <summary>
        /// Trigger a collection event while updating the values for variables. This is
        /// ideal for updating data variables associated with the event. 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="variableNames"></param>
        /// <param name="variableValues"></param>
        /// <param name="eventName"></param>
        public void SendCollectionEventWithData( int connection, string[] variableNames, VALUELib.CxValueObject[] variableValues, string eventName )
        {
            try
            {
                int eventID = -1;
                object varIDs = null; 
                object varNames = variableNames;
                object[] varValues = new object[variableValues.Length];
                int i = 0; 
                foreach (VALUELib.CxValueObject value in variableValues)
                {
                    variableValues[i].CopyToByteStream(0, 0, out varValues[i]);
                    i++; 
                }
                object results = null; 

                AVPSecsGemLog.avpSecsGemLogger.Debug("CxClientClerk.SetValuesTriggerEvent " + eventName);
                m_CxClientClerk.SetValuesTriggerEvent(connection, EMSERVICELib.VarType.varANY, ref varIDs, ref varNames, varValues, ref eventID, ref eventName, out results);
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                HandleCOMException("Exception in SendCollectionEventWithData " + eventName, e);
            }
        }

        /// <summary>
        /// Change an alarm to the SET state. 
        /// </summary>
        /// <param name="name">Alarm name</param>
        /// <param name="text">Text about the alarm.</param>
        /// /// <param name="text">Text = Empty.</param>
        public void AlarmSET(string sChamberName, string sAlarmName, string sAlarmText)
        {
            try
            {
                int id = -1;
                if (!m_initialized)
                {
                    return;
                }
                sAlarmName = convertChamberName_To_GemID(sChamberName).ToString() + "." + sAlarmName;

                string strOldAlarmText = string.Empty;
                int iEventiD = 0;
                int iClearEventID = 0;
                string strDes = string.Empty;
                m_ICxClientTool.GetAlarmInfo(ref id, ref sAlarmName, out strOldAlarmText, out iEventiD, out iClearEventID, out strDes);
                if (strOldAlarmText != sAlarmText)
                {
                    int istate = 0;
                    m_CxClientClerk.GetAlarmState(ref id, ref sAlarmName, out istate);
                    if (istate >= 1)
                    {
                        m_CxClientClerk.ClearAlarm(ref id, ref sAlarmName);
                    }
                }

                if (sAlarmText.Length == 0)
                {
                    m_CxClientClerk.SetAlarm(ref id, ref sAlarmName); 
                }
                else
                {
                    m_CxClientClerk.SetAlarmAndText(id, sAlarmName, sAlarmText);
                }

                if (m_setAlarmList.IndexOf(sAlarmName) < 0)
                {
                    m_setAlarmList.Add(sAlarmName);
                }
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                HandleCOMException("Exception AlarmSET " + sAlarmName, e);
            }
        }
        /// <summary>
        /// Change an alarm to the SET state. 
        /// </summary>
        /// <param name="name">Alarm name</param>
        /// <param name="text">Text about the alarm.</param>
        /// /// <param name="text">Text = Empty.</param>
        public void CommonAlarmSET( string sAlarmName, string sAlarmText)
        {
            try
            {
                int id = -1;
                if (!m_initialized)
                {
                    return;
                }

                string strOldAlarmText = string.Empty;
                int iEventiD = 0;
                int iClearEventID = 0;
                string strDes = string.Empty;
                m_ICxClientTool.GetAlarmInfo(ref id, ref sAlarmName, out strOldAlarmText, out iEventiD, out iClearEventID, out strDes);
                if (strOldAlarmText != sAlarmText)
                {
                    int istate = 0;
                    m_CxClientClerk.GetAlarmState(ref id, ref sAlarmName, out istate);
                    if (istate >= 1)
                    {
                        m_CxClientClerk.ClearAlarm(ref id, ref sAlarmName);
                    }
                }
   
                if (sAlarmText.Length == 0)
                {
                    m_CxClientClerk.SetAlarm(ref id, ref sAlarmName);
                }
                else
                {
                    m_CxClientClerk.SetAlarmAndText(id, sAlarmName, sAlarmText);
                }

                if (m_setAlarmList.IndexOf(sAlarmName) < 0)
                {
                    m_setAlarmList.Add(sAlarmName);
                }
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                HandleCOMException("Exception AlarmSET " + sAlarmName, e);
            }
        }

        /// <summary>
        /// Change the state of an alarm to CLEAR
        /// </summary>
        /// <param name="name">Alarm name</param>
        public void CommonAlarmCLEAR(string sAlarmName)
        {
            int id = -1;
            if (!m_initialized)
            {
                return;
            }
            try
            {
                                m_CxClientClerk.ClearAlarm(ref id, ref sAlarmName);
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                HandleCOMException("Exception AlarmCLEAR " + sAlarmName, e);
            }
        }
        public void AlarmCLEAR(string sChamberName, string sAlarmName)
        {
            int id = -1;
            if (!m_initialized)
            {
                return;
            }
            sAlarmName = convertChamberName_To_GemID(sChamberName).ToString() + "." + sAlarmName;
            try
            {
                m_CxClientClerk.ClearAlarm(ref id, ref sAlarmName);
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                HandleCOMException("Exception AlarmCLEAR " + sAlarmName, e);
            }
        }

        public void AlarmClearAll()
        {
            try
            {
                if (m_setAlarmList != null)
                {
                    foreach (string strAlarmName in m_setAlarmList)
                    {
                        CommonAlarmCLEAR(strAlarmName);
                    }
                    m_setAlarmList.Clear();
                }
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                HandleCOMException("Exception AlarmClearAll", e);
            }
        }

        public void TriggerEvent(string sChamberName, string sEventName)
        {
            try
            {
                if (!m_initialized)
                { 
                    return;
                }
                int iEventID = -1;
                sEventName = convertChamberName_To_GemID(sChamberName).ToString() + "." + sEventName;
                this.m_CxClientClerk.TriggerEvent(AVPConstants.iConnectionID, ref iEventID, ref sEventName);
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                HandleCOMException("Exception TriggerEvent " + sChamberName + "." + sEventName, e);
            } 
        }

        public void TriggerEventSystem(string sEventName)
        {
            if (!m_initialized)
            {
                return;
            }
            try
            {
                int iEventID = -1;
                this.m_CxClientClerk.TriggerEvent(AVPConstants.iConnectionCommonID, ref iEventID, ref sEventName);
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                HandleCOMException("Exception TriggerEvent " + sEventName, e);
            }
        }

        public void UpdateVariable(string sChamberName, EMSERVICELib.VarType varType, string sName,
            VALUELib.ValueType valueType, string sNewValue)
        {
            try
            {
                if (!m_initialized)
                {
                    return;
                }
                AVPChamberID ChamberID = convertChamberName_To_GemID(sChamberName);
                sName = ChamberID + "." + sName;
                if (CheckVariableChange(sName, sNewValue))
                {
                    CxValueObject varBuffer = new CxValueObject();
                    EMSERVICELib.VariableResults varResult;
                    int varID = 0;
                    try
                    {
                        this.m_ICxClientTool.GetVarID(AVPConstants.iConnectionID, sName, out varID);
                        SetValueByType(valueType, sNewValue, ref varBuffer);
                    }
                    catch
                    {
                        AVPSecsGemLog.avpSecsGemLogger.Error(varID.ToString() + "Can not unregister value changed");
                        return;
                    }
                    //////////////////////////////////////////////////////////////////////////
                    //UNREGISTER VARIABLE CHANGE
                    //////////////////////////////////////////////////////////////////////////
                    try
                    {
                        this.m_CxClientClerk.UnregisterValueChangedHandler(AVPConstants.iConnectionID, varID);
                    }
                    catch
                    {
                        AVPSecsGemLog.avpSecsGemLogger.Error(varID.ToString() + "Can not unregister value changed");
                        return;
                    }
                    //////////////////////////////////////////////////////////////////////////
                    //SET NEW VARIABLE
                    //////////////////////////////////////////////////////////////////////////
                    try
                    {
                        m_CxClientClerk.SetValue(AVPConstants.iConnectionID, varType, ref varID, ref sName, varBuffer, out varResult);
                    }
                    catch
                    {
                        AVPSecsGemLog.avpSecsGemLogger.Error("Can not Update value:" + sNewValue + "in:" + sChamberName + "," + sName);
                        return;
                    }

                    //////////////////////////////////////////////////////////////////////////
                    //REGISTER NEW VARIABLE
                    //////////////////////////////////////////////////////////////////////////
                    try
                    {
                        this.m_CxClientClerk.UnregisterValueChangedHandler(AVPConstants.iConnectionID, varID);
                    }
                    catch
                    {
                        AVPSecsGemLog.avpSecsGemLogger.Error(varID.ToString() + "Can not register value changed");
                        return;
                    }

                    switch (varType)
                    {
                        case EMSERVICELib.VarType.DV:
                            //DO something
                            break;
                        case EMSERVICELib.VarType.EC:
                            //DO something
                            break;
                        case EMSERVICELib.VarType.SV:
                            //DO something
                            break;
                        case EMSERVICELib.VarType.varANY:
                            //DO something
                            break;
                    }
                }
            }
            catch (System.Exception ex)
            {
                AVPSecsGemLog.avpSecsGemLogger.Error(ex.Message);
            }
            
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sID">ID in database</param>
        /// <param name="ChamberName"></param>
        /// <returns>ID in secs/gem</returns>
        protected int ConvertID2GemID(string sID, string sChamberName)
        {
            int result = 0;
            try
            {
                AVPChamberID ChamberID = convertChamberName_To_GemID(sChamberName);
                result = (int)ChamberID * AVPConstants.iConnectionID + Convert.ToInt32(sID);
            }
            catch
            {
                AVPSecsGemLog.avpSecsGemLogger.Error("Can not convert to GemID:" + sID + "in: " + sChamberName);
            }
            return result;
        }
        /// <summary>
        /// Update the GEM processing state. 
        /// </summary>
        /// <param name="state">The new state.</param>
        public void UpdateProcessState(AVPProcessState state, string sToolName)
        {
            try
            {
                if (!m_initialized)
                {
                    return;
                }
                //get chamber ID
                //update process state only used for LLA
                AVPChamberID ChamberID = convertChamberName_To_GemID(sToolName);
                if (ChamberID == AVPChamberID.LLA)
                {
                    if(m_LLAProcessState != state)
                    {
                        m_LLAProcessState = state;
                    }
                    else
                    {
                        //do not update
                        return;
                    }
                    
                }
                else
                {
                    //do not update 
                    return;
                }

                EMSERVICELib.VarType varType = VarType.SV;
                VALUELib.ValueType valueType = VALUELib.ValueType.U1;

                string sVarName = "PROCESSSTATE";
                string sVarPreviousName = "PREVIOUSPROCESSSTATE";
                string sName = ChamberID + "." + sVarName;
                
                string sNewValue = ((Int32)state).ToString();
                string sCurrentValue = string.Empty;

                if (state == AVPProcessState.INIT)
                {
                    //update for this state
                    UpdateVariable(sToolName, varType, sVarName, valueType, sNewValue);
                    //update to Previous Status variable
                    UpdateVariable(sToolName, varType, sVarPreviousName, valueType, sNewValue);
                    return;
                }
                ulong value = 0;
                GetVariableValue(AVPConstants.iConnectionID, sName, ref value);
                //INIT=0, IDLE=1, SETUP=2, READY=3, EXECUTING=4, PAUSE=5
                switch (value)
                {
                    case 0:
                        sCurrentValue = ((Int32)AVPProcessState.INIT).ToString();
                        break;
                    case 1:
                        sCurrentValue = ((Int32)AVPProcessState.IDLE).ToString();
                        break;
                    case 2:
                        sCurrentValue = ((Int32)AVPProcessState.SETUP).ToString();
                        break;
                    case 3:
                        sCurrentValue = ((Int32)AVPProcessState.READY).ToString();
                        break;
                    case 4:
                        sCurrentValue = ((Int32)AVPProcessState.EXECUTING).ToString();
                        break;
                    case 5:
                        sCurrentValue = ((Int32)AVPProcessState.PAUSE).ToString();
                        break;
                }
                if (sCurrentValue == state.ToString())
                {
                    //do not change anything
                    return;
                }
                
                //update for this state
                UpdateVariable(sToolName, varType, sVarName, valueType, sNewValue);
                //update to Previous Status variable
                UpdateVariable(sToolName, varType, sVarPreviousName, valueType, sCurrentValue);
                //Update event process state change 
                TriggerEvent(sToolName, "ProcessingStateChange");

                //Trigger Event
                //DO NOT TRIGGER EVENT AT HERE, ONLY TRIGGER EVENT ON AVPCODE MANUAL
                //USE TriggerEvent() FUNCTION TO TRIGGER EVENT
                switch (state)
                {
                    case AVPProcessState.INIT:
                        //nothing
                        break;
                    case AVPProcessState.IDLE:
                        if (sCurrentValue == ((Int32)AVPProcessState.INIT).ToString())
                        {
                            //trigger Equipment initialization complete
                        }
                        else if (sCurrentValue == ((Int32)AVPProcessState.EXECUTING).ToString())
                        {
                            if (IsProcessReallyCompleted)
                            {
                            TriggerEvent(sToolName, "ProcessingCompleted");
                        }
                        }
                        else if (sCurrentValue == ((Int32)AVPProcessState.READY).ToString())
                        {
                            /*NOTHING*/
                        }
                        else if (sCurrentValue == ((Int32)AVPProcessState.SETUP).ToString())
                        {
                            /*NOTHING*/
                        }
                        else if (sCurrentValue == ((Int32)AVPProcessState.PAUSE).ToString())
                        {
                            /*NOTHING*/
                        }
                        break;
                    case AVPProcessState.SETUP:
                        if (sCurrentValue == ((Int32)AVPProcessState.IDLE).ToString())
                        {
                            /*NOTHING*/
                        }
                        break;
                    case AVPProcessState.READY:
                        if (sCurrentValue == ((Int32)AVPProcessState.SETUP).ToString())
                        {
                            /*NOTHING*/
                        }
                        break;
                    case AVPProcessState.EXECUTING:
                        if (sCurrentValue == ((Int32)AVPProcessState.READY).ToString())
                        {
                            TriggerEvent(sToolName, "ProcessingStarted");
                        }
                        else if (sCurrentValue == ((Int32)AVPProcessState.PAUSE).ToString())
                        {
                            TriggerEvent(sToolName, "ProcessingResumed");
                        }
                        break;
                    case AVPProcessState.PAUSE:
                        if (sCurrentValue == ((Int32)AVPProcessState.EXECUTING).ToString())
                        {
                            TriggerEvent(sToolName, "ProcessingPaused");
                        }
                        break;
                    default:
                        return;
                }
                
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                HandleCOMException("Exception calling ::ProcessingStateChange " + state.ToString(), e);
            }
        }
        
        /// <summary>
        /// Cache the value of a variable, any type, in CIMConnect.  
        /// </summary>
        /// <param name="connection">CIMConnect connection number. 0 if a common variable.</param>
        /// <param name="name">variable name</param>
        /// <param name="myCxValueObject">The variable's new value. </param>
        /// <returns></returns>
        public void CacheVariable(int connection, string name, VALUELib.CxValueObject myCxValueObject)
        {
            try
            {
                EMSERVICELib.VariableResults results;
                object byteBuffer;
                AVPSecsGemLog.avpSecsGemLogger.Debug("CxValueObject.CopyToByteStream");
                myCxValueObject.CopyToByteStream(0, 0, out byteBuffer);
                int id = -1;
                AVPSecsGemLog.avpSecsGemLogger.Debug("CxClientClerk.SetValueFromByteBuffer " + name );
                m_CxClientClerk.SetValueFromByteBuffer(connection, EMSERVICELib.VarType.varANY,
                    ref id, ref name, byteBuffer, out results);
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                string sValue = string.Empty;
                if ( myCxValueObject != null )
                    myCxValueObject.CopyToString(0, 0, out sValue); 
                HandleCOMException("Exception calling ::SetValueFromByteBuffer " + name + ": " + sValue, e);
            }
        }

        /// <summary>
        /// Cache the value of a variable of type Unsigned 4 Byte Integer
        /// The ICxValue interface is used to allow setting the value object
        /// directly as an unsigned integer since the CxValueObject::SetValueU4 
        /// function requires the value to be specified as a signed integer. 
        /// </summary>
        /// <param name="name">variable name</param>
        /// <param name="value">variable value</param>
        /// <returns></returns>
        public void CacheVariable(string name, uint value)
        {
            try
            {
                VALUELib.CxValueObject myCxValueObject = new VALUELib.CxValueObject();
                AVPSecsGemLog.avpSecsGemLogger.Debug("CxValueObject.SetValueU4");
                myCxValueObject.SetValueU4(0, 0, (int)value); 
                CacheVariable(0, name, myCxValueObject); 
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                HandleCOMException("Exception CacheVariable " + name + ": " + value.ToString(), e);
            }
        }

        /// <summary>
        /// Cache the value of a variable of type 8 byte floating point
        /// </summary>
        /// <param name="name">variable name</param>
        /// <param name="value">variable value</param>
        /// <returns></returns>
        public void CacheVariable(string name, double value)
        {
            try
            {
                VALUELib.CxValueObject myCxValueObject = new VALUELib.CxValueObject();
                AVPSecsGemLog.avpSecsGemLogger.Debug("CxValueObject.SetValueF8");
                myCxValueObject.SetValueF8(0, 0, value);
                CacheVariable(0, name, myCxValueObject);
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                HandleCOMException("Exception calling CacheVariable " + name + ": " + value.ToString(), e);
            }
        }

        /// <summary>
        /// Cache the value of a variable of type ASCII
        /// </summary>
        /// <param name="name">variable name</param>
        /// <param name="value">variable value</param>
        /// <returns></returns>
        public void CacheVariable(string name, string value)
        {
            try
            {
                VALUELib.CxValueObject myCxValueObject = new VALUELib.CxValueObject();
                AVPSecsGemLog.avpSecsGemLogger.Debug("CxValueObject.SetValueAscii");
                myCxValueObject.SetValueAscii(0, 0, value);
                CacheVariable(0, name, myCxValueObject);
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                HandleCOMException("Exception calling CacheVariable " + name + ": " + value.ToString(), e);
            }
        }

        /// <summary>
        /// Cache the value of multiple variables, any type, in CIMConnect.  
        /// </summary>
        /// <param name="connection">CIMConnect connection number. 0 if a common variable.</param>
        /// <param name="variableNames"></param>
        /// <param name="variableValues"></param>
        /// <param name="eventName"></param>
        public void CacheVariables(int connection, string[] variableNames, VALUELib.CxValueObject[] variableValues)
        {
            try
            {
                object varIDs = null;
                object varNames = variableNames;
                object[] varValues = new object[variableValues.Length];
                int i = 0;
                foreach (VALUELib.CxValueObject value in variableValues)
                {
                    variableValues[i].CopyToByteStream(0, 0, out varValues[i]);
                    i++; 
                }
                object results = null;

                AVPSecsGemLog.avpSecsGemLogger.Debug("CxClientClerk.SetValuesFromByteBuffer " );
                m_CxClientClerk.SetValuesFromByteBuffer(connection, EMSERVICELib.VarType.varANY, ref varIDs, ref varNames, varValues, out results);
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                HandleCOMException("Exception in SendCollectionEventWithData ", e);
            }
        }

        /// <summary>
        /// Get the value of a Status Variable, Data Variable or Equipment Constant from CIMConnect. The value
        /// must be type integer (I1, I2, I4, U1, U2, U4, Binary), and not be of type array for this function
        /// to work. 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public bool GetVariableValue(int connection, string name, ref ulong value)
        {
            try
            {
                EMSERVICELib.VariableResults result; 
                int id = -1;
                object oValue = null;

                AVPSecsGemLog.avpSecsGemLogger.Debug("CxClientClerk.GetValueToByteBuffer " + name);
                m_CxClientClerk.GetValueToByteBuffer(connection, ref id, ref name, out oValue, out result);
               
                VALUELib.CxValueObject myCxValueObject = new VALUELib.CxValueObject();
                myCxValueObject.RestoreFromByteStream(0, 0, oValue);
                VALUELib.ValueType myValueType;
                myCxValueObject.GetDataType(0, 0, out myValueType);
                VALUELib.ICxValue myICxValue = (VALUELib.ICxValue) myCxValueObject; 
                switch (myValueType)
                {
                    case VALUELib.ValueType.Bi:
                        {
                            byte bValue;
                            myICxValue.GetValueBinary(0, 0, out bValue);
                            value = bValue;
                        }
                        break;
                    case VALUELib.ValueType.Bo:
                        {
                            byte bValue;
                            myICxValue.GetValueBoolean(0, 0, out bValue);
                            value = bValue; 
                        }
                        break;
                    case VALUELib.ValueType.I1:
                        {
                            sbyte sValue;
                            myICxValue.GetValueI1(0, 0, out sValue);
                            value = (ulong)sValue;
                        }
                        break;
                    case VALUELib.ValueType.I2:
                        {
                            short sValue;
                            myICxValue.GetValueI2(0, 0, out sValue);
                            value = (ulong)sValue;
                        }
                        break;
                    case VALUELib.ValueType.I4:
                        {
                            int iValue;
                            myICxValue.GetValueI4(0, 0, out iValue);
                        }
                        break;
                    case VALUELib.ValueType.U1:
                        {
                            byte bValue;
                            myICxValue.GetValueU1(0, 0, out bValue);
                            value = bValue; 
                        }
                        break;
                    case VALUELib.ValueType.U2:
                        {
                            ushort usValue;
                            myICxValue.GetValueU2(0, 0, out usValue);
                            value = usValue;
                        }
                        break;
                    case VALUELib.ValueType.U4:
                        {
                            uint uiValue;
                            myICxValue.GetValueU4(0, 0, out uiValue);
                            value = uiValue;
                        }
                        break; 
                    case VALUELib.ValueType.U8:
                        myICxValue.GetValueU8(0, 0, out value); 
                        break; 
                    default:
                        AVPSecsGemLog.avpSecsGemLogger.Debug("Unsupported type returned: " + myValueType.ToString()); 
                        return false; 
                }

            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                HandleCOMException("Exception in GetVariableValue " + name, e);
            }
            return true; 
        }

        /// <summary>
        /// Change the GEM Control state to ONLINE or OFFLINE
        /// </summary>
        /// <param name="connection">Connection #</param>
        /// <param name="state">if true, go ONLINE. if false, go OFFLINE</param>
        public void GEMStateControlStateOnline(AVPGemControlState state)
        {
            try
            {
                if (state == AVPGemControlState.ONLINE)
                {
                    m_CxClientClerk.GoOnline(AVPConstants.iConnectionID);
                }
                else if (state == AVPGemControlState.OFFLINE)
                {
                    m_CxClientClerk.GoOffline(AVPConstants.iConnectionID);
                }
            }
            catch (System.Exception ex)
            {
                AVPSecsGemLog.avpSecsGemLogger.Error(ex.Message);
            }
        }

        /// <summary>
        /// Change the GEM Control State to REMOTE or LOCAL
        /// </summary>
        /// <param name="state"></param>
        public void GEMStateControlStateRemote(AVPGemControlStateRemote state)
        {
            try
            {
                if (state == AVPGemControlStateRemote.REMOTE)
                {
                    m_CxClientClerk.GoRemote(AVPConstants.iConnectionID);
                }
                else if (state == AVPGemControlStateRemote.LOCAL)
                {
                    m_CxClientClerk.GoLocal(AVPConstants.iConnectionID);
                }
            }
            catch (System.Exception ex)
            {
                AVPSecsGemLog.avpSecsGemLogger.Error(ex.Message);
            }
        }

        /// <summary>
        /// Change the GEM Communication State to ENABLE or DISABLE communication
        /// </summary>
        /// <param name="state"></param>
        public void GEMStateCommunicationStateEnable(AVPGEMCommState state)
        {
            try
            {
                if (state == AVPGEMCommState.COMM_ENABLE)
                {
                    m_CxClientClerk.EnableComm(AVPConstants.iConnectionID);
                }
                else if (state == AVPGEMCommState.COMM_DISABLE)
                {
                    m_CxClientClerk.DisableComm(AVPConstants.iConnectionID);
                }
            }
            catch (System.Exception ex)
            {
                AVPSecsGemLog.avpSecsGemLogger.Error(ex.Message);
            }
        }

        /// <summary>
        /// Change the GEM Project path
        /// write to registry 
        /// software/cimetrix/cimconnect/equipment/0/ProjectRootPath
        /// 
        /// maybe other project will be crash
        /// </summary>
        /// <param name="state"></param>
        public void SetCIMConnectProjectPath()
        {
            string path = "SOFTWARE\\Cimetrix\\CIMConnect\\Equipment\\0";
            RegistryKey rk = Registry.LocalMachine;
            try
            {
                RegistryKey sk1 = rk.OpenSubKey(path, true);
                sk1.SetValue("Project", AVPConstants.sGemConfigName);
                sk1.SetValue("ProjectRootPath", AVPConstants.sGemConfigPath);
            }
            catch (System.Exception ex)
            {
                AVPSecsGemLog.avpSecsGemLogger.Error(ex.Message);
            }
        }

        /// <summary>
        /// Equipment Request Send Sequence/WaferFlow/Recipe File
        /// </summary>
        /// <param name="state"></param>
        public void PPLoadInquire(string sFileName, int FileLength)
        {
            try
            {
                m_CxClientClerk.PPLoadInquire(AVPConstants.iConnectionID, sFileName, FileLength);
            }
            catch (System.Exception ex)
            {
                AVPSecsGemLog.avpSecsGemLogger.Error(ex.Message);
            }
        }

        /// <summary>
        /// Send Sequence/WaferFlow/Recipe File
        /// </summary>
        /// <param name="state"></param>
        public void PPSend(string sFileName, string FileContent)
        {
            try
            {
                CxValueObject objFileContent = new CxValueObject();
                objFileContent.SetValueAscii(0, 0, FileContent);
                m_CxClientClerk.PPSend(AVPConstants.iConnectionID, sFileName, objFileContent);
            }
            catch (System.Exception ex)
            {
                AVPSecsGemLog.avpSecsGemLogger.Error(ex.Message);
            }
        }
        /// <summary>
        /// Send Sequence/WaferFlow/Recipe File
        /// </summary>
        /// <param name="state"></param>
        public void PPRequest(string sFileName)
        {
            try
            {
                m_CxClientClerk.PPRequest(AVPConstants.iConnectionID, sFileName);
            }
            catch (System.Exception ex)
            {
                AVPSecsGemLog.avpSecsGemLogger.Error(ex.Message);
            }
        }
    }
}
