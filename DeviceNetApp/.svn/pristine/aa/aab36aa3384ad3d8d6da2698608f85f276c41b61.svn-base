using System;
using System.Collections.Generic;
using System.Text;
using DeviceNetApp.Lib;
using System.Collections;
using DeviceNetApp.Bussiness;

namespace DeviceNetApp.DeviceNet
{
    // For collect data
    public class FiredDataInfo
    {
        public String DataName;
        public Int64 iRetryDuration; ////milisecond
        public Int64 iRetryInterval; ////milisecond
        public Int64 iFirstFired;
        public Int64 iLastFired;
        public Object Value;

        public FiredDataInfo(String p_DataName, Int64 p_iRetryTimeFire, Int64 p_iTimeInterval, Object p_Value)
        {
            DataName = p_DataName;
            iRetryDuration = p_iRetryTimeFire;
            iRetryInterval = p_iTimeInterval;
            iLastFired = Environment.TickCount;
            iFirstFired = Environment.TickCount;
            Value = p_Value;
        }
    }

    public class DNSEquipment
    {
        #region "Update Data Objects"
        protected PropertyObject m_objCommunicationStatusProp = new PropertyObject();
        #endregion

        protected Object objLockSendMessage = new Object();
        public delegate void UpdateMessageLogDelegate(string strMessage);
        public event UpdateMessageLogDelegate UpdateMessageLogEvent;

        /// <summary>
        /// Device configuration structure
        /// </summary>
        protected DeviceConfiguration m_DeviceConfig = null;

        /// <summary>
        /// Card handle of master device
        /// </summary>
        protected Int32 m_hCardHandle = 0;

        /// <summary>
        /// Mac ID
        /// </summary>
        protected UInt16 m_nMacId  = 0;
        public UInt16 MacId
        {
            get {return m_nMacId;}
        }

        /// <summary>
        /// Device Type
        /// </summary>
        protected DNSDeviceType m_eDeviceType = DNSDeviceType.Undefined;
        public DNSDeviceType DeviceType
        {
            get { return m_eDeviceType; }
            set { m_eDeviceType = value; }
        }

        /// <summary>
        /// Device Net Scanner is used to manage all Dnet Device
        /// </summary>
        protected DNSScanner m_objMaster = null;

        /// <summary>
        /// size of input data
        /// </summary>
        protected ushort m_uInputSize = 0;

        public ushort InputSize
        {
            get { return m_uInputSize; }
            set { m_uInputSize = value; }
        }

        /// <summary>
        /// size of output data
        /// </summary>
        protected ushort m_uOutputSize = 0;

        public ushort OutputSize
        {
            get { return m_uOutputSize; }
            set { m_uOutputSize = value; }
        }

        /// <author>
        ///     <name> Dung Pham </name>
        ///     <date> 2019-09-24</date>
        /// </author>
        /// <summary>
        /// Indicate the first time polling
        /// </summary>
        private Boolean m_bFirstRead = false;
        public Boolean FirstRead
        {
            get { return m_bFirstRead; }
            set { m_bFirstRead = value; }
        }

        /// <summary>
        /// Explicit Data Message
        /// </summary>
        protected byte[] m_ExplicitData = null;

        /// <summary>
        /// Explicit Data Message
        /// </summary>
        protected byte[] m_ExplicitDataReceive = null;

        /// <summary>
        /// Explicit Data Message Size
        /// </summary>
        protected UInt16 m_iExplicitMsgSize = 64;

        /// <summary>
        /// Device Status
        /// </summary>
        protected DeviceNetStatus m_DeviceStatus = new DeviceNetStatus();

        /// <summary>
        /// Previous status
        /// </summary>
        private byte m_PrevStatus = 0;

        /// <summary>
        /// Need to config for the first time
        /// </summary>
        private Boolean m_RequiredConfigure = true;

        /// <summary>
        /// Store the current device event
        /// </summary>
        private Int32 m_iDeviceEvent;

        /// <summary>
        /// pointer to input data
        /// </summary>
	    protected byte[] m_arrInputBuffer = null;

        /// <summary>
        /// pointer to output data
        /// </summary>
        protected byte[] m_arrOutputBuffer = null;

        /// <summary>
        /// Is Object is clean up
        /// </summary>
        protected Boolean m_bIsDisposing = false;

        /// <summary>
        /// Explicit state
        /// </summary>
        protected enExplicitState m_ExplicitState = enExplicitState.explicitIdle;
        public enExplicitState ExplicitState
        {
            get { return m_ExplicitState; }
        }

        /// <summary>
        /// List of Mac Id is not active
        /// </summary>
        private List<UInt16> listMacIdNotActive = new List<UInt16>();

        /// <summary>
        /// Real FlowRate
        /// </summary>
        protected Single m_fRawValue = 0.0f;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="p_objMaster"></param>
        public DNSEquipment(DNSScanner p_objMaster, UInt16 nMacId)
        {
            m_objMaster = p_objMaster;
            m_nMacId = nMacId;

            // Init Device Configuration data
            m_DeviceConfig = new DeviceConfiguration();
        }

        /// <summary>
        /// Init device
        /// </summary>
        public virtual Boolean Intialize()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Set Property Changed Receiver
        /// </summary>
        public virtual bool SetPropertyChangedHandler(String strDnetPropertyName,Object objReceiver, String strPropertyName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Set Property Changed Receiver
        /// </summary>
        public virtual bool SetPropertyChangedHandler(Object objReceiver, String strPropertyName, Object objSignalInfo)
        {
            return true;
        }

        /// <summary>
        /// Set Value
        /// </summary>
        public virtual bool SetValue(string strCmd, params object[] arrParams)
        {
            throw new NotImplementedException();
        }

        /// <author>
        /// <name>Hoai Ly</name>
        /// <date>2019-02-15</date>
        /// </author>
        /// <summary>
        /// SendMessage
        /// </summary>
        public bool SendMessage(params object[] arrParams)
        {
            bool result = false;
            string strMessage = string.Empty;

            try
            {
                Int16 iService = (Int16)arrParams[0];
                Int16 iClass = (Int16)arrParams[1];
                Int16 iInstance = (Int16)arrParams[2];
                byte[] explicitData = (byte[])arrParams[3];
                Int16 iReceiveMessageSize = (Int16)arrParams[4];

                result = SendExplicitMessage(iService, iClass, iInstance, explicitData, (UInt16)explicitData.Length);

                if (result)
                {
                    Wait4ExplicitReplyMsg();

                    if (iReceiveMessageSize > 0 && m_ExplicitDataReceive != null)
                    {
                        if (m_ExplicitDataReceive.Length >= iReceiveMessageSize)
                        {
                            byte[] data = new byte[iReceiveMessageSize];

                            for (int i = 0; i < iReceiveMessageSize; i++)
                            {
                                data[i] = m_ExplicitDataReceive[i];
                            }

                            strMessage = ByteArrayToHexString(data);
                        }
                        else
                        {
                            strMessage = "Wrong Receive Message Size";
                        }
                    }
                    else
                    {
                        strMessage = "Done!";
                    }
                }
                else
                {
                    strMessage = "Send message failed!";
                }
            }
            catch (Exception ex)
            {
                Logger.LogHandler.Error(ex.ToString());
                strMessage = "See exception in log file";
            }
            finally
            {
                DeviceNetCore.Instance().DeviceController.PausePollingDeviceMacID = 0;
                DeviceNetCore.Instance().DeviceController.IsPausePollingDeviceMacID = false;

                if (UpdateMessageLogEvent != null && !string.IsNullOrEmpty(strMessage))
                {
                    UpdateMessageLogEvent(strMessage.Trim());
                }
            }
            return result;
        }

        /// <author>
        /// <name>Hoai Ly</name>
        /// <date>2019-02-15</date>
        /// </author>
        /// <summary>
        /// Convert Byte Array To Hex String
        /// </summary>
        private string ByteArrayToHexString(byte[] data)
        {
            try
            {
                StringBuilder sb = new StringBuilder(data.Length * 3);
                foreach (byte b in data)
                    sb.Append(Convert.ToString(b, 16).PadLeft(2, '0').PadRight(3, ' '));
                return sb.ToString().ToUpper();
            }
            catch (Exception ex)
            {
                Logger.LogHandler.Error(ex.ToString());
            }
            return string.Empty;
        }

        /// <summary>
        /// Set Value
        /// </summary>
        public virtual string CollectData(ref List<string> plstCollectedData)
        {
            // Collect device status
            string strResCmd = string.Empty;
            string sDeviceInfo = m_nMacId + "_DeviceStatus";
            Boolean active = IsDeviceActive();

            if (!active)
            {
                if (!listMacIdNotActive.Contains(m_nMacId))
                {
                    Logger.LogHandler.Error("Device is not active.MacID" + m_nMacId);
                }
            }

            if (IsChangedData(sDeviceInfo, active))
            {
                strResCmd = sDeviceInfo + "," + active.ToString();
            }

            // Add to collected string
            AddListOfParameter(ref plstCollectedData, strResCmd);

            return string.Empty;
        }

        /// <summary>
        /// Clean Up
        /// </summary>
        public virtual void CleanUp()
        {
            m_bIsDisposing = true;
        }

        /// <summary>
        /// Polling data
        /// </summary>
        public virtual void Poll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Add device to scan list
        /// </summary>
        /// <param name="CardHandle"></param>
        /// <param name="DeviceId"></param>
        /// <param name="inputSize"></param>
        /// <param name="outputSize"></param>
        /// <param name="explicitSize"></param>
        /// <returns></returns>
        public Boolean RegisterEquipment(Int32 CardHandle, UInt16 DeviceId, UInt16 inputSize, UInt16 outputSize, UInt16 explicitSize)
        {
            m_hCardHandle = CardHandle;

            // Config this device and add this to scanner list
            m_DeviceConfig.MacId = DeviceId;
            
	        m_DeviceConfig.Input1Size = inputSize;
	        if (inputSize > 0)
	        {
		        m_DeviceConfig.Flags |= Constants.SS_P;
                m_DeviceConfig.Input1Offset = m_objMaster.GetMemoryOffset(inputSize);
	        }
        	
	        m_DeviceConfig.Output1Size = outputSize;
	        if (outputSize > 0)
	        {
                m_DeviceConfig.Flags |= Constants.SS_P;
                m_DeviceConfig.Output1Offset = m_objMaster.GetMemoryOffset(outputSize);
	        }

	        if (explicitSize > 0)
	        {
                m_ExplicitData = new byte[explicitSize];
                m_DeviceConfig.Flags |= Constants.SS_EX;
		        m_DeviceConfig.ExplicitSize = explicitSize;
		        m_DeviceConfig.ExplicitOffset = m_objMaster.GetMemoryOffset( m_DeviceConfig.ExplicitSize );
	        }

            Boolean res = DeviceNetDriver.RegisterEquipment(m_hCardHandle, m_DeviceConfig);
            if (res == false)
            {
                Logger.LogHandler.Error("Error when adding the device.");
            }
        	
	        return res;
        }

        /// <summary>
        /// Check if the current device is OK or not
        /// </summary>
        /// <returns></returns>
        public Boolean IsDeviceActive()
        {
            if (m_DeviceStatus != null)
            {
                return DeviceNetDriver.IsDeviceActive(m_DeviceStatus.StatusCode);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Poll the status of current equipment
        /// </summary>
        public void GetDeviceStatus()
        {
            try
            {
                m_DeviceStatus = DeviceNetDriver.GetDeviceStatus(m_hCardHandle, m_DeviceConfig.MacId);
                if (m_DeviceStatus == null)
                {
                    try
                    {
                        int errorCode = DeviceNetDriver.GetLastError();
                        Logger.LogHandler.Error("Error when getting the device status. Error code: " + errorCode.ToString());
                    }
                    catch (Exception ex)
                    {
                        Logger.LogHandler.Error(ex.ToString());
                    }
                    return;
                }

                if (m_PrevStatus != m_DeviceStatus.StatusCode)
                {
                    if (DeviceNetDriver.IsDeviceActive(m_PrevStatus))
                    {
                        Logger.LogHandler.Error("Device is not active.Mac ID=" + m_DeviceConfig.MacId);
                    }
                    m_PrevStatus = m_DeviceStatus.StatusCode;
                }

                if (DeviceNetDriver.IsDeviceActive(m_PrevStatus) && m_RequiredConfigure && IsExplicitIdle())
                {
                    Setup();
                    m_RequiredConfigure = false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogHandler.Error(ex.Message);
            }

            //bool bIsDeviceActive = DeviceNetDriver.IsDeviceActive(m_DeviceStatus.StatusCode);
            //m_objCommunicationStatusProp.SetValue(bIsDeviceActive? EquipmentStatus.OPENED: EquipmentStatus.CLOSED);
        }

        /// <summary>
        /// Get Data from device and update to a buffer
        /// </summary>
        /// <returns></returns>
        public Boolean ReadData()
        {
	        bool retVal = false;
            if ((m_DeviceStatus == null) || (!DeviceNetDriver.IsDeviceActive(m_DeviceStatus.StatusCode)))
            {
                if (!listMacIdNotActive.Contains(m_DeviceConfig.MacId))
                {
                    Logger.LogHandler.Error("Device is not active.Mac ID=" + m_DeviceConfig.MacId);
                    listMacIdNotActive.Add(m_DeviceConfig.MacId);
                }
                return false;
            }
            else
            {
                if (listMacIdNotActive.Contains(m_DeviceConfig.MacId))
                {
                    listMacIdNotActive.Remove(m_DeviceConfig.MacId);
                }

                // If having IO data
                m_iDeviceEvent = DeviceNetDriver.GetDeviceEvent(m_hCardHandle, m_DeviceConfig.MacId, Constants.DNS_IO1_EVENT);
                if (m_iDeviceEvent == -1)
                {
                    Logger.LogHandler.Error("No data from " + m_DeviceConfig.MacId);
                    return false;
                }
                else
                {
                    // Having data
                    if ((m_iDeviceEvent & Constants.DNS_INPUT_DATA_UPDATE) != 0)
                    {
                        // Read IO data from this device
                        m_arrInputBuffer = DeviceNetDriver.ReadDeviceIo(m_hCardHandle, m_DeviceConfig.MacId, m_DeviceConfig.Input1Size);
                        if (m_arrInputBuffer != null)
                        {
                            //Logger.LogHandler.Debug("MacID = [" + m_DeviceConfig.MacId.ToString() + "]");
                            retVal = true;
                        }
                        else
                        {
                            Logger.LogHandler.Error("Error when getting data from the device.");
                        }
                    }
                    // Process empty message
                    else if ((m_iDeviceEvent & Constants.DNS_RECEIVE_IDLE) != 0)
                    {
                        m_arrInputBuffer = DeviceNetDriver.ReadDeviceIo(m_hCardHandle, m_DeviceConfig.MacId, m_DeviceConfig.Input1Size);
                        Logger.LogHandler.Debug("Mac Id: " + m_DeviceConfig.MacId.ToString() + " receive zero-length message.");
                        retVal = false;
                    }
                    else
                    {
                        // Logger.LogHandler.Error("Error when getting data from the device.");
                    }
                }
            }

            // return
	        return retVal;
        }

        /// <summary>
        /// Write data to IO device
        /// </summary>
        /// <returns></returns>
        public Boolean WriteData()
        {
            // Please construct m_arrBuffer array before call this function (size = m_DeviceConfig.Output1Size)
            bool retVal = DeviceNetDriver.WriteDeviceIo(m_hCardHandle, m_DeviceConfig.MacId, m_arrOutputBuffer);
            if (!retVal)
            {
                Logger.LogHandler.Error("Error when writting data to the device.");
            }		   
		    return retVal;
        }

        /// <summary>
        /// Send Explicit Message
        /// </summary>
        /// <param name="DNservice"></param>
        /// <param name="DNclass"></param>
        /// <param name="DNinstance"></param>
        /// <param name="?"></param>
        /// <returns></returns>
        public Boolean SendExplicitMessage(Int16 ServiceID, Int16 ClassID, Int16 InstanceID)
        {
            lock (objLockSendMessage)
            {
                bool retVal = DeviceNetDriver.SendExplicitMessage(m_hCardHandle, m_DeviceConfig.MacId, ServiceID, ClassID, InstanceID, m_ExplicitData, m_iExplicitMsgSize);
                if (!retVal)
                {
                    String strInfo = String.Format("MacId = {0}, ServiceID = {1}, ClasID= {2}, Instance ID = {3}", m_DeviceConfig.MacId, ServiceID, ClassID, InstanceID);
                    Logger.LogHandler.Error(strInfo);
                    Logger.LogHandler.Error("Send Explicit Messsage Error retVal = " + retVal.ToString());
                    return false;
                }
                else
                {
                    m_ExplicitState = enExplicitState.explicitSent;
                }

                return retVal;
            }
        }

        /// <author>
        /// <name>Hoai Ly</name>
        /// <date>2019-02-15</date>
        /// </author>
        /// <summary>
        /// Send Explicit Message
        /// </summary>
        /// <param name="DNservice"></param>
        /// <param name="DNclass"></param>
        /// <param name="DNinstance"></param>
        /// <param name="DNexplicitData"></param>
        /// <param name="DNexplicitMsgSize"></param>
        /// <returns></returns>
        public Boolean SendExplicitMessage(Int16 ServiceID, Int16 ClassID, Int16 InstanceID, byte[] explicitData, UInt16 explicitMsgSize)
        {
            lock (objLockSendMessage)
            {
                bool retVal = DeviceNetDriver.SendExplicitMessage(m_hCardHandle, m_DeviceConfig.MacId, ServiceID, ClassID, InstanceID, explicitData, explicitMsgSize);
                if (!retVal)
                {
                    String strInfo = String.Format("MacId = {0}, ServiceID = {1}, ClasID= {2}, Instance ID = {3}", m_DeviceConfig.MacId, ServiceID, ClassID, InstanceID);
                    Logger.LogHandler.Error(strInfo);
                    Logger.LogHandler.Error("Send Explicit Messsage Error retVal = " + retVal.ToString());
                    return false;
                }
                else
                {
                    Logger.LogHandler.Error(m_DeviceConfig.MacId.ToString() + "To Sent");
                    m_ExplicitState = enExplicitState.explicitSent;
                }

                return retVal;
            }
        }

        /// <summary>
        /// Config the current device
        /// </summary>
        public virtual void Setup()
        {
            // Will be implement in sub-class
        }

        /// <summary>
        /// Is Explicit Idle
        /// </summary>
        /// <returns></returns>
        public Boolean IsExplicitIdle()
        {
            return (m_ExplicitState == enExplicitState.explicitIdle);
        }

        /// <summary>
        /// Wait for explicit message reply
        /// </summary>
        /// <returns></returns>
        public Boolean ReceiveExplicit()
        {
	        Boolean retVal = false;
	        Int32 explicitEventFlag;
            Int32 ServiceID = 0;

            if (m_ExplicitState == enExplicitState.explicitIdle)
            {
                retVal = false;
            }
            else if (m_ExplicitState == enExplicitState.explicitSent)
            {
                explicitEventFlag = DeviceNetDriver.GetDeviceEvent(m_hCardHandle, m_DeviceConfig.MacId, 3);
                if (explicitEventFlag == -1)
                {
                    Logger.LogHandler.Error("Get Device Event Error.");
                    return false;
                }
                if (explicitEventFlag != 0)
                {
                    m_ExplicitState = enExplicitState.explicitReady;
                }
                retVal = false;
            }
            else if (m_ExplicitState == enExplicitState.explicitReady)
            {
                m_ExplicitDataReceive = DeviceNetDriver.ReceiveExplicit(m_hCardHandle, m_DeviceConfig.MacId, ref ServiceID);
                if (m_ExplicitDataReceive == null)
                {
                    Logger.LogHandler.Error("No Data Receive Explicit On MacID: " + m_DeviceConfig.MacId.ToString());
                    m_ExplicitState = enExplicitState.explicitIdle;
                    return true;
                }
                m_ExplicitState = enExplicitState.explicitReceived;
                retVal = false;
            }
            else if (m_ExplicitState == enExplicitState.explicitReceived)
            {
                m_ExplicitState = enExplicitState.explicitIdle;
                retVal = true;
            }

            // If not receiving message, result will be always false
	        return retVal;
        }

        /// <summary>
        /// Wait for explicit message reply
        /// </summary>
        public void Wait4ExplicitReplyMsg()
        {
            while (!ReceiveExplicit())
            {
                if (m_bIsDisposing)
                {
                    break;
                }
                System.Threading.Thread.Sleep(200);
            }
        }

        /// <summary>
        /// Wait for explicit message reply
        /// </summary>
        public void Wait4ExplicitReplyMsg(int iTimeout)
        {
            Int64 iStartTickCount = Environment.TickCount;
            TimeSpan span = new TimeSpan(0, 0, iTimeout / 1000);

            while (!ReceiveExplicit())
            {
                if (TimeSpan.FromMilliseconds(Environment.TickCount - iStartTickCount) > span)
                {
                    break;
                }

                if (m_bIsDisposing)
                {
                    break;
                }
                System.Threading.Thread.Sleep(200);
            }
        }

        #region Collect Data
        /// <author>
        /// <name>Van Le</name>
        /// <date> 2013-11-04</date>
        /// </author>
        /// Check value is changed
        /// </summary>
        /// <param name="PropertyName"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        public Boolean IsChangedData(String strPropertyName, Boolean iValue)
        {
            return DeviceNetCore.Instance().DataCollector.IsChangedData(strPropertyName, iValue);
        }

        /// <author>
        /// <name>Van Le</name>
        /// <date> 2013-11-04</date>
        /// </author>
        /// Check value is changed
        /// </summary>
        /// <param name="PropertyName"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        public Boolean IsChangedData(String strPropertyName, int iValue)
        {
            return DeviceNetCore.Instance().DataCollector.IsChangedData(strPropertyName, iValue);
        }

        /// <author>
        /// <name>Van Le</name>
        /// <date> 2013-11-04</date>
        /// </author>
        /// Check value is changed
        /// </summary>
        /// <param name="PropertyName"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        public Boolean IsChangedData(String strPropertyName, float fValue)
        {
            return DeviceNetCore.Instance().DataCollector.IsChangedData(strPropertyName, fValue);
        }

        /// <author>
        /// <name>Do Xuan Dat</name>
        /// <date> 2009-12-14</date>
        /// </author>
        /// <summary>
        /// 
        /// </summary>
        /// <para></para>
        /// <returns></returns>  
        public void AddListOfParameter(ref List<String> objlstCollectedData, String objCmd)
        {
            try
            {
                if (!string.IsNullOrEmpty(objCmd))
                {
                    objlstCollectedData.Add(objCmd);
                }
            }
            catch (Exception ex)
            {
                Logger.LogHandler.Error(ex.Message);
            }
        }

        #endregion
    }
}
