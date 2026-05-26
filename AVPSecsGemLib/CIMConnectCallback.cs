using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
namespace AVPSecsGemLib
{
    public class CIMConnectCallback : EMSERVICELib.ICxEMAppCallback
    {
#region Variables
        private AVPSecsGem m_AvpSecsGem;
#endregion
#region GetValueCallback
        // Handle GetValueToByteBuffer callback 
        public class GetValueCallbackArgs : EventArgs
        {
            public GetValueCallbackArgs(string variableName, int variableID, VALUELib.ICxValueDisp variableValue)
            {
                m_variableName = variableName;
                m_variableID = variableID;
                m_variableValue = variableValue;
            }
            private string m_variableName;
            public string VariableName
            {
                get { return m_variableName; }
            }
            private int m_variableID;
            public int VariableID
            {
                get { return m_variableID; }
            }
            private VALUELib.ICxValueDisp m_variableValue;
            public VALUELib.ICxValueDisp VariableValue
            {
                get { return m_variableValue; }
            }
        }
        public delegate void GetValueCallbackHandler(object sender, GetValueCallbackArgs e);
        public event GetValueCallbackHandler m_GetValueCallbackHandler;
        public void GetValueCallback(string variableName, int variableID, VALUELib.ICxValueDisp variableValue)
        {
            if (m_GetValueCallbackHandler != null)
            {
                GetValueCallbackArgs e = new GetValueCallbackArgs(variableName, variableID, variableValue);
                m_GetValueCallbackHandler(this, e);
            }
        }
        void EMSERVICELib.ICxEMAppCallback.GetValueToByteBuffer(int connectionID, int varid, string name, ref object pValueBuffer)
        {
            VALUELib.CxValueObject valueObject = new VALUELib.CxValueObject();
            GetValueCallback(name, varid, valueObject);
            valueObject.CopyToByteStream(0, 0, out pValueBuffer);
        }
#endregion
        public CIMConnectCallback(AVPSecsGem avpSecgem)
        {
            this.m_AvpSecsGem = avpSecgem;
        }
        void EMSERVICELib.ICxEMAppCallback.AlarmChanged(int alarmID, int state)
        {
            
        }

        void EMSERVICELib.ICxEMAppCallback.AsyncMsgError(int connectionID, int msgID, int TID, int ErrorID, int lExtra)
        {
            
        }

        void EMSERVICELib.ICxEMAppCallback.CallbackReplaced(int connectionID, EMSERVICELib.Callbacks callback, int itemID, string itemName)
        {
            
        }
        void EMSERVICELib.ICxEMAppCallback.CommandCalled(int connectionID, string command, VALUELib.CxValueObject paramNames, VALUELib.CxValueObject paramValues, ref EMSERVICELib.CommandResults cmdResult)
        {
            try
            {
                AVPSecsGemLog.avpSecsGemLogger.Error("CommandCalled " + connectionID.ToString() + " command: " + command);
                if (connectionID > AVPSecsGem.m_NumberOfConnections)
                {
                    AVPSecsGemLog.avpSecsGemLogger.Error("Remote Command " + command + " rejected because connection " + connectionID.ToString() + " does not support remote commands.");
                    return;
                }

                // Only allow remote commands while in the Remote Control State
                if (m_AvpSecsGem.m_ControlState[connectionID - 1] != 5)
                {
                    AVPSecsGemLog.avpSecsGemLogger.Error("Remote Command " + command + " rejected because the Control State is not remote");
                    cmdResult = EMSERVICELib.CommandResults.cmdRejected;
                    return;
                }

                // Check Parameters
                int argumentCount = 0;
                paramNames.ItemCount(0, out argumentCount);

                string[] parameterNames = new string[argumentCount];
                string[] parameterValues = new string[argumentCount];
                VALUELib.ValueType argumentValueType;

                
                AVPProcessState avpProcessstate; //= paraparameterNames LLA LLB

                string loadlocknane = "";
                // First make sure that the Process State is valid for the command. 
                if (argumentCount > 0)
                {
                    paramValues.GetValueAscii(0, 1, out loadlocknane);
                }
                
                if (loadlocknane == "A") //loadlock A
                {
                    avpProcessstate = m_AvpSecsGem.m_LLAProcessState;
                }
                else //robot, chamber
                {
                    goto label0001;
                }

                switch (avpProcessstate)
                {
                    case AVPProcessState.IDLE:
                        if ((command != "START") && (command != "PP-SELECT") && (command != "LOAD") && (command != "UNLOAD"))
                        {
                            AVPSecsGemLog.avpSecsGemLogger.Error("Remote Command " + command + " rejected because the Process State is IDLE");
                            cmdResult = EMSERVICELib.CommandResults.cmdCannotPerform;
                            return;
                        }
                        break;
                    case AVPProcessState.EXECUTING:
                        if ((command != "STOP") && (command != "ABORT") && (command != "RESUME") && (command !="PAUSE"))
                        {
                            AVPSecsGemLog.avpSecsGemLogger.Error("Remote Command " + command + " rejected because the Process State is EXECUTING");
                            cmdResult = EMSERVICELib.CommandResults.cmdCannotPerform;
                            return;
                        }
                        break;
                    case AVPProcessState.PAUSE:
                        if (command != "RESUME")
                        {
                            AVPSecsGemLog.avpSecsGemLogger.Error("Remote Command " + command + " rejected because the Process State is EXECUTING");
                            cmdResult = EMSERVICELib.CommandResults.cmdCannotPerform;
                            return;
                        }
                        break;

                    case AVPProcessState.SETUP:
                        {
                            AVPSecsGemLog.avpSecsGemLogger.Error("Remote Command " + command + " rejected because the Process State is SETUP");
                            cmdResult = EMSERVICELib.CommandResults.cmdCannotPerform;
                            return;
                        }
                        
                }

 label0001:               
                switch (command)
                {
                    case "STOP":
                    case "START":
                    case "ABORT":
                    case "PAUSE":
                    case "UNLOAD":
                    case "LOAD":
                    case "RESUME":
                        paramNames.GetValueAscii(0, 1, out parameterNames[0]);
                        if (argumentCount != 1)
                        {
                            AVPSecsGemLog.avpSecsGemLogger.Error("Remote Command " + command + " rejected because arguments were provided and none are allowed for this command.");
                            cmdResult = EMSERVICELib.CommandResults.cmdParamInvalid;
                            return;
                        }
                                                
                        paramValues.GetDataType(0, 1, out argumentValueType);
                        if (argumentValueType != VALUELib.ValueType.A)
                        {
                            AVPSecsGemLog.avpSecsGemLogger.Error("Remote Command " + command + " rejected because the value for PPID must be ASCII. ");
                            cmdResult = EMSERVICELib.CommandResults.cmdParamInvalid;
                            return;
                        }
                        paramValues.GetValueAscii(0, 1, out parameterValues[0]);
                        break;

                    case "PP-SELECT":
                        // Validate the number of requirements 
                        if (argumentCount != 4)
                        {
                            AVPSecsGemLog.avpSecsGemLogger.Error("Remote Command " + command + " rejected because it supports one and only one required argument, PPID. ");
                            cmdResult = EMSERVICELib.CommandResults.cmdParamInvalid;
                            return;
                        }

                        // Validate that the argument is PORTID
                        paramNames.GetValueAscii(0, 1, out parameterNames[0]);
                        if (parameterNames[0] != "PORTID")
                        {
                            AVPSecsGemLog.avpSecsGemLogger.Error("Remote Command " + command + " rejected because only PPID argument is allowed. ");
                            cmdResult = EMSERVICELib.CommandResults.cmdParamInvalid;
                            return;
                        }

                        // Validate the argument name value type ( must be ASCII) 
                        paramValues.GetDataType(0, 1, out argumentValueType);
                        if (argumentValueType != VALUELib.ValueType.A)
                        {
                            AVPSecsGemLog.avpSecsGemLogger.Error("Remote Command " + command + " rejected because the value for PPID must be ASCII. ");
                            cmdResult = EMSERVICELib.CommandResults.cmdParamInvalid;
                            return;
                        }
                        paramValues.GetValueAscii(0, 1, out parameterValues[0]);

                        // Validate that the argument is LOTID
                        paramNames.GetValueAscii(0, 2, out parameterNames[1]);
                        if (parameterNames[1] != "LOTID")
                        {
                            AVPSecsGemLog.avpSecsGemLogger.Error("Remote Command " + command + " rejected because only PPID argument is allowed. ");
                            cmdResult = EMSERVICELib.CommandResults.cmdParamInvalid;
                            return;
                        }

                        // Validate the argument name value type ( must be ASCII) 
                        paramValues.GetDataType(0, 2, out argumentValueType);
                        if (argumentValueType != VALUELib.ValueType.A)
                        {
                            AVPSecsGemLog.avpSecsGemLogger.Error("Remote Command " + command + " rejected because the value for PPID must be ASCII. ");
                            cmdResult = EMSERVICELib.CommandResults.cmdParamInvalid;
                            return;
                        }
                        paramValues.GetValueAscii(0, 2, out parameterValues[1]);

                        // Validate that the argument is RECIPE
                        paramNames.GetValueAscii(0, 3, out parameterNames[2]);
                        if (parameterNames[2] != "RECIPE")
                        {
                            AVPSecsGemLog.avpSecsGemLogger.Error("Remote Command " + command + " rejected because only PPID argument is allowed. ");
                            cmdResult = EMSERVICELib.CommandResults.cmdParamInvalid;
                            return;
                        }

                        // Validate the argument name value type ( must be ASCII) 
                        paramValues.GetDataType(0, 3, out argumentValueType);
                        if (argumentValueType != VALUELib.ValueType.A)
                        {
                            AVPSecsGemLog.avpSecsGemLogger.Error("Remote Command " + command + " rejected because the value for PPID must be ASCII. ");
                            cmdResult = EMSERVICELib.CommandResults.cmdParamInvalid;
                            return;
                        }
                        
                        paramValues.GetValueAscii(0, 3, out parameterValues[2]);

                        // Validate that the argument is WAFERID
                        paramNames.GetValueAscii(0, 4, out parameterNames[3]);
                        if (parameterNames[3] != "WAFERID")
                        {
                            AVPSecsGemLog.avpSecsGemLogger.Error("Remote Command " + command + " rejected because only PPID argument is allowed. ");
                            cmdResult = EMSERVICELib.CommandResults.cmdParamInvalid;
                            return;
                        }

                        // Validate the argument name value type ( must be ASCII) 
                        paramValues.GetDataType(0, 4, out argumentValueType);
                        if (argumentValueType != VALUELib.ValueType.A)
                        {
                            AVPSecsGemLog.avpSecsGemLogger.Error("Remote Command " + command + " rejected because the value for PPID must be ASCII. ");
                            cmdResult = EMSERVICELib.CommandResults.cmdParamInvalid;
                            return;
                        }

                        paramValues.GetValueAscii(0, 4, out parameterValues[3]);

                        break;
                    case "MARK_FOR_RETURN":
                        paramNames.GetValueAscii(0, 1, out parameterNames[0]);
                        if (argumentCount != 1)
                        {
                            AVPSecsGemLog.avpSecsGemLogger.Error("Remote Command " + command + " rejected because arguments were provided and none are allowed for this command.");
                            cmdResult = EMSERVICELib.CommandResults.cmdParamInvalid;
                            return;
                        }

                        paramValues.GetDataType(0, 1, out argumentValueType);
                        if (argumentValueType != VALUELib.ValueType.A)
                        {
                            AVPSecsGemLog.avpSecsGemLogger.Error("Remote Command " + command + " rejected because the value for PPID must be ASCII. ");
                            cmdResult = EMSERVICELib.CommandResults.cmdParamInvalid;
                            return;
                        }
                        paramValues.GetValueAscii(0, 1, out parameterValues[0]);
                        break;
                    case "MAKE_ALL_ONLINE":
                        break;
                }

                // By default, assume it will be rejected. 
                cmdResult = EMSERVICELib.CommandResults.cmdRejected;

                // Pass the command on to the Form for processing
                m_AvpSecsGem.RemoteCommand(connectionID, command, parameterNames, parameterValues, ref cmdResult);
                AVPSecsGemLog.avpSecsGemLogger.Error("Remote Command " + command + " result = " + cmdResult.ToString());
            }
            catch (Exception ex)
            {
                AVPSecsGemLog.avpSecsGemLogger.Error("Remote Command " + command + " rejected because an exception occurred: " + ex.Message);
                cmdResult = EMSERVICELib.CommandResults.cmdRejected;
            }
        }

        void EMSERVICELib.ICxEMAppCallback.EventTriggered(int connectionID, int eventID)
        {
            
        }

        void EMSERVICELib.ICxEMAppCallback.GetValue(int connectionID, int varid, string name, VALUELib.CxValueObject value)
        {
            
        }

        void EMSERVICELib.ICxEMAppCallback.GetValues(int connectionID, object ids, object names, object values)
        {
            
        }

        void EMSERVICELib.ICxEMAppCallback.GetValuesToByteBuffer(int connectionID, object varIDs, object names, ref object pValueBuffers)
        {
            
        }

        void EMSERVICELib.ICxEMAppCallback.HostPPLoadInqAck(int connectionID, EMSERVICELib.RecipeGrant result)
        {
            try
            {
                m_AvpSecsGem.PPLoadInquire(result);
            }
            catch (Exception ex)
            {
                AVPSecsGemLog.avpSecsGemLogger.Error("PPLoadInquire Fail, because an exception occurred: " + ex.Message);
            }
        }

        void EMSERVICELib.ICxEMAppCallback.HostPPSendAck(int connectionID, EMSERVICELib.RecipeAck result)
        {
            try
            {
                m_AvpSecsGem.HostPPSendAck(result);
            }
            catch (Exception ex)
            {
                AVPSecsGemLog.avpSecsGemLogger.Error("PPSend Fail, because an exception occurred: " + ex.Message);
            }
        }

        void EMSERVICELib.ICxEMAppCallback.HostTermMsgAck(int connectionID, EMSERVICELib.TerminalMsgResults result)
        {
            
        }
        [DllImport("Kernel32.dll")]
        internal static extern bool SetLocalTime([In, Out] SystemTime st);
        void EMSERVICELib.ICxEMAppCallback.MessageReceived(int connectionID, int msgID, VALUELib.CxValueObject msg, bool replyExpected, int TID, ref int replyMsgID, VALUELib.CxValueObject reply, ref EMSERVICELib.MessageResults result)
        {

            try
            {
                string str;
                switch (msgID)
                {
                    case 0x211:
                        if (replyExpected)
                        {
                            str = DateTime.Now.ToString("yyyyMMddHHmmssff");
                            reply.SetValueAscii(0, 0, str);
                            replyMsgID = 530;
                            result = EMSERVICELib.MessageResults.mReply;
                        }
                        return;

                    case 0x21f:
                        {
                            int num;
                            bool flag = false;
                            msg.ItemCount(0, out num);
                            if (num == 1)
                            {
                                VALUELib.ValueType type;
                                msg.GetDataType(0, 0, out type);
                                if (type == VALUELib.ValueType.A)
                                {
                                    msg.GetValueAscii(0, 0, out str);
                                    if (str.Length == 0x10)
                                    {
                                        try
                                        {
                                            SystemTime st = new SystemTime();
                                            st.year = ushort.Parse(str.Substring(0, 4));
                                            st.Month = ushort.Parse(str.Substring(4, 2));
                                            st.Day = ushort.Parse(str.Substring(6, 2));
                                            st.Hour = ushort.Parse(str.Substring(8, 2));
                                            st.Minute = ushort.Parse(str.Substring(10, 2));
                                            st.Second = ushort.Parse(str.Substring(12, 2));
                                            st.milliseconds = (ushort)(ushort.Parse(str.Substring(14, 2)) * 10);
                                            flag = SetLocalTime(st);
                                          }
                                        catch
                                        {
                                        }
                                    }
                                }
                            }
                            if (replyExpected)
                            {
                                if (flag)
                                {
                                    reply.SetValueBinary(0, 0, 0);
                                }
                                else
                                {
                                    reply.SetValueBinary(0, 0, 1);
                                }
                                replyMsgID = 0x220;
                                result = EMSERVICELib.MessageResults.mReply;
                            }
                            return;
                        }
                }
                replyMsgID = 0;
                result = EMSERVICELib.MessageResults.mNoReply;
            }
            catch (Exception exception)
            {
                replyMsgID = 0;
                result = EMSERVICELib.MessageResults.mNoReply;
                AVPSecsGemLog.avpSecsGemLogger.Error("MessageReceived: " + exception.Message);
            }
        }

        void EMSERVICELib.ICxEMAppCallback.PPDRequest(int connectionID, VALUELib.CxValueObject names)
        {
            
        }

        void EMSERVICELib.ICxEMAppCallback.PPData(int connectionID, VALUELib.CxValueObject recipe, int result)
        {
            
        }

        void EMSERVICELib.ICxEMAppCallback.PPDataFile(int connectionID, string filename, int result)
        {
            try
            {
                m_AvpSecsGem.PPSendData(filename, result);
            }
            catch (Exception ex)
            {
                AVPSecsGemLog.avpSecsGemLogger.Error("PPDataFile Fail, because an exception occurred: " + ex.Message);
            }
        }

        void EMSERVICELib.ICxEMAppCallback.PPDelete(int connectionID, VALUELib.CxValueObject names, ref EMSERVICELib.RecipeAck result)
        {
            if (m_AvpSecsGem.m_initialized == false)
            {
                result = EMSERVICELib.RecipeAck.raRejected;
                return;
            }

            int num;
            names.ItemCount(0, out num);
            string[] str =  new string[num];
            for (int i = 0; i < num; i++)
            {
                names.GetValueAscii(0, i + 1, out str[i]);
            }

            // Check if there is duplicated recipe name
            for (int i = 0; i < num; i++)
            {
                for (int j = i + 1; j < num; j++)
                {
                    if (str[i] == str[j])
                    {
                        result = (EMSERVICELib.RecipeAck)RecipeErrorAck.raDuplicatedID;
                        return;
                    }
                }
            }

            m_AvpSecsGem.HostPPDeleteFile(str, ref result);
        }

       
        void EMSERVICELib.ICxEMAppCallback.PPLoadInquire(int connectionID, string name, int length, ref EMSERVICELib.RecipeGrant result)
        {
            try
            {
                result = EMSERVICELib.RecipeGrant.rgOk;

            }
            catch (Exception ex)
            {
                AVPSecsGemLog.avpSecsGemLogger.Error("PPDataFile Fail, because an exception occurred: " + ex.Message);
            }   
        }

        void EMSERVICELib.ICxEMAppCallback.PPRequest(int connectionID, string name, VALUELib.CxValueObject recipe, ref EMSERVICELib.RecipeAck result)
        {
            try
            {
                result = EMSERVICELib.RecipeAck.raAccepted;
                
            }
            catch (Exception ex)
            {
                AVPSecsGemLog.avpSecsGemLogger.Error("PPDataFile Fail, because an exception occurred: " + ex.Message);
            }   
        }

        void EMSERVICELib.ICxEMAppCallback.PPSend(int connectionID, VALUELib.CxValueObject recipe, ref EMSERVICELib.RecipeAck result)
        {
            
        }

        void EMSERVICELib.ICxEMAppCallback.PPSendFile(int connectionID, string filename, ref EMSERVICELib.RecipeAck result)
        {
            try
            {
                m_AvpSecsGem.HostPPSendFile(filename, ref result);

            }
            catch (Exception ex)
            {
                AVPSecsGemLog.avpSecsGemLogger.Error("PPDataFile Fail, because an exception occurred: " + ex.Message);
            }   
        }

        void EMSERVICELib.ICxEMAppCallback.PPSendFileVerify(int connectionID, string filename, ref EMSERVICELib.RecipeAck result)
        {
            try
            {
                result = EMSERVICELib.RecipeAck.raAccepted;

            }
            catch (Exception ex)
            {
                AVPSecsGemLog.avpSecsGemLogger.Error("PPDataFile Fail, because an exception occurred: " + ex.Message);
            }   
            
        }

        void EMSERVICELib.ICxEMAppCallback.SetValue(int connectionID, int varid, string name, VALUELib.CxValueObject value)
        {
            
        }

        void EMSERVICELib.ICxEMAppCallback.SetValueFromByteBuffer(int connectionID, int varid, string name, object ValueBuffer)
        {
            
        }

        void EMSERVICELib.ICxEMAppCallback.SetValues(int connectionID, object ids, object names, object values)
        {
            
        }

        void EMSERVICELib.ICxEMAppCallback.SetValuesFromByteBuffer(int connectionID, object varIDs, object names, object ValueBuffers)
        {
            
        }

        void EMSERVICELib.ICxEMAppCallback.StateChange(int connectionID, EMSERVICELib.StateMachine machine, int state)
        {
            if (connectionID > AVPSecsGem.m_NumberOfConnections )
                return;

            switch (machine)
            {
                case EMSERVICELib.StateMachine.smCommunications:
                    m_AvpSecsGem.m_CommunicationState[connectionID - 1] = (ulong)state;
                    break;
                case EMSERVICELib.StateMachine.smControl:
                    m_AvpSecsGem.m_ControlState[connectionID - 1] = (ulong)state;
                    break;
            }
            m_AvpSecsGem.GEMStateChange(connectionID, machine, state);
        }

        void EMSERVICELib.ICxEMAppCallback.TerminalMsgRcvd(int connectionID, int terminalID, VALUELib.CxValueObject lines, ref EMSERVICELib.TerminalMsgResults result)
        {
            if (result.Equals(null))
                return;

            try
            {
                result = EMSERVICELib.TerminalMsgResults.tRejected;

                // Setup my string to display the terminal message
                string mymessage = ": ";
                string terminal = "";

                // Get the data type (expecting S10F3 or S10F5 format)
                VALUELib.ValueType datatype = VALUELib.ValueType.valueANY;
                lines.GetDataType(0, 0, out datatype);
                if (datatype == VALUELib.ValueType.valueANY)
                {
                    AVPSecsGemLog.avpSecsGemLogger.Error("ERROR: MyCIMConnect: TerminalMsgRcvd GetDataType failed.");
                    return;
                }
                switch (datatype)
                {
                    case VALUELib.ValueType.L:
                        {
                            int numberLines;
                            string tmpMessage = "";
                            lines.ItemCount(0, out numberLines);
                            for (int i = 0; i < numberLines; i++)
                            {
                                if (i > 0)
                                    tmpMessage += Environment.NewLine;
                                lines.GetValueAscii(0, i + 1, out terminal);
                                if (terminal != null)
                                {
                                    tmpMessage += terminal;
                                }
                            }
                            if (tmpMessage.Length == 0)
                                mymessage = ""; // empty text message from host. 
                            else
                                mymessage += tmpMessage;
                        }
                        break;
                    case VALUELib.ValueType.A:
                        {
                            lines.GetValueAscii(0, 0, out terminal);
                            if (terminal == null)
                            {
                                mymessage = ""; // empty text message from host 
                            }
                            else
                            {
                                mymessage += terminal;
                            }
                        }
                        break;
                    default:
                        {
                            AVPSecsGemLog.avpSecsGemLogger.Error("ERROR: MyCIMConnectCallbacks: TerminalMsgRcvd Unexpected data type " + datatype);
                            return;
                        }
                }
                mymessage += Environment.NewLine;
                // Display the Terminal Service message
                m_AvpSecsGem.TerminalService(mymessage);

                // Accept the Terminal Service message
                result = EMSERVICELib.TerminalMsgResults.tAccepted;
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                m_AvpSecsGem.HandleCOMException("Exception in callback ICxEMAppCallback.TerminalMsgRcvd", e);
                return;
            }
        }

        void EMSERVICELib.ICxEMAppCallback.ValueChanged(int connectionID, int varid, string name, VALUELib.CxValueObject value)
        {
            
        }

        void EMSERVICELib.ICxEMAppCallback.ValuesChanged(int connectionID, object ids, object names, object values)
        {
            
        }

        void EMSERVICELib.ICxEMAppCallback.VerifyValue(int connectionID, int varid, string name, VALUELib.CxValueObject value, ref EMSERVICELib.VerifyValueResults result)
        {
            
        }

        void EMSERVICELib.ICxEMAppCallback.VerifyValues(int connectionID, object ids, object names, object values, ref object results)
        {
            
        }
        [StructLayout(LayoutKind.Sequential)]
        internal class SystemTime
        {
            public ushort year;
            public ushort Month;
            public ushort DayOfWeek;
            public ushort Day;
            public ushort Hour;
            public ushort Minute;
            public ushort Second;
            public ushort milliseconds;
        }
    }
}
