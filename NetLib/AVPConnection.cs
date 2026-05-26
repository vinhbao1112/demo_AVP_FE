using System;
using System.Net;
using System.Text;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AVP.Network
{
    public class AVPConnection : IDisposable
    {
        protected  static CustomThreadPool OurThreadPool = new CustomThreadPool("Our Thread Pool for AVP Connections.");

        public event Action<SocketState> OnConnectionStateChanged = null;
        
        public event Action<String> OnMessageArrived;

        private void Fire_ConnectionStateChange(SocketState conState)
        {
            m_ConnectionStatus = conState;
            Action<SocketState> connectionStateChangedEvent = OnConnectionStateChanged;
            if (connectionStateChangedEvent != null)
            {
                foreach (Action<SocketState> pAction in connectionStateChangedEvent.GetInvocationList())
                {
                    try
                    {
                        pAction(m_ConnectionStatus);
                    }
                    catch (Exception){ }
                }
            }
        }

        public void Fire_MessageArrivedEvent(String messageArrived)
        {
            /*
            Action<String> messageArrivedEvent = OnMessageArrived;
            if (messageArrivedEvent != null)
            {
               // Never calls EndInvoke *really* cause a memory leak ?
               IAsyncResult iar = messageArrivedEvent.BeginInvoke(messageArrived, null, null);
               // Explicitly discards (by setting the hard reference to null), the AsyncResult object.
               iar = null;                
            }
             */
            // ThreadPool.QueueUserWorkItem(new WaitCallback(PVDMessageHandler), messageArrived);
            OurThreadPool.AddWorkItem(new Action<String>(PVDMessageHandler), messageArrived );
        }

        private void PVDMessageHandler(Object objState)
        {
            String messageArrived = objState as String;
            Action<String> messageArrivedEvent = OnMessageArrived;
            if (messageArrivedEvent != null)
            {
                try
                {
                    messageArrivedEvent(messageArrived);
                }
                catch { }
            }
        }

        /// <summary>
        /// The connected state of the socket.
        /// </summary>
        public enum SocketState
        {
            /// <summary>
            /// The socket is closed; we are not trying to connect.
            /// </summary>
            Closed,

            /// <summary>
            /// The socket is attempting to connect.
            /// </summary>
            Connecting,

            /// <summary>
            /// The socket is connected.
            /// </summary>
            Connected,

            /// <summary>
            /// The socket is attempting to disconnect.
            /// </summary>
            Disconnecting
        }

        /// <summary>
        /// The buffer for the data.
        /// </summary>
        private Byte[] m_DataBuffer;
        private const Int32 BufferSize = 1024*2;
        private StringBuilder m_sbBuffer;
        private SocketState m_ConnectionStatus = SocketState.Closed;
        private ClientTcpSocket m_connection;
        private String m_strDeviceIp;
        private Int32 m_iPort;
        
        public String[] ResponseTerminators = new String[]{"\r"};

        // Resart connection automatically or not.
        public Boolean RestartAutomatically = true;
       
        // Keep separator or not
        public Boolean KeepSeparator = false;

        private Object m_objQueueLock = new Object();
        // Support multi-producer, single consumer.
        private Queue<String> m_messageQueue;

        private Object m_objSendCmdToDeviceLock = new Object();

        public Boolean UseSendAsync = true;

        /// <author>
        /// <name>Do Xuan Dat</name>
        /// <date> 2009-12-14</date>
        /// </author>
        /// <summary>
        /// 
        /// </summary>
        /// <para></para>
        /// <returns></returns>
        public AVPConnection(String pIpConnectTo, Int32 pPort, Boolean bAutoStart)
        {
            UseSendAsync = true;
            m_strDeviceIp = pIpConnectTo;
            m_iPort = pPort;
            //
            m_DataBuffer = new Byte[BufferSize];
            m_messageQueue = new Queue<String>();
            if (bAutoStart)
            {
                // Make connection to device first time.
                RestartConnection();
            }
        }

        ~AVPConnection()
        {
            Dispose(false);
        }

        public Boolean RestartConnection()
        {
            // Read the IP address
            IPAddress deviceIPAddress;
            if (IPAddress.TryParse(m_strDeviceIp, out deviceIPAddress))
            {
                m_connection = new ClientTcpSocket();
                m_connection.ConnectCompleted += new Action<System.ComponentModel.AsyncCompletedEventArgs>(DeviceConnection_ConnectCompleted);
                m_connection.ReadCompleted += new Action<AsyncResultEventArgs<Int32>>(DeviceConnection_ReadCompleted);
                m_connection.WriteCompleted += new Action<System.ComponentModel.AsyncCompletedEventArgs>(DeviceConnection_WriteCompleted);
                m_connection.ShutdownCompleted += new Action<System.ComponentModel.AsyncCompletedEventArgs>(DeviceConnection_ShutdownCompleted);

                m_connection.ConnectAsync(deviceIPAddress, m_iPort);
                Fire_ConnectionStateChange(SocketState.Connecting);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Closes and clears the socket, without causing exceptions.
        /// </summary>
        public void ResetConnection()
        {
            if (m_connection != null)
            {
                // Close the socket
                Fire_ConnectionStateChange(SocketState.Disconnecting);
                m_connection.ConnectCompleted -= new Action<System.ComponentModel.AsyncCompletedEventArgs>(DeviceConnection_ConnectCompleted);
                m_connection.ReadCompleted -= new Action<AsyncResultEventArgs<Int32>>(DeviceConnection_ReadCompleted);
                m_connection.WriteCompleted -= new Action<System.ComponentModel.AsyncCompletedEventArgs>(DeviceConnection_WriteCompleted);
                m_connection.ShutdownCompleted -= new Action<System.ComponentModel.AsyncCompletedEventArgs>(DeviceConnection_ShutdownCompleted);
                m_connection.Close();
                m_connection = null;
                // Indicate there is no socket connection
                Fire_ConnectionStateChange(SocketState.Closed);
            }
        }

        private void DeviceConnection_ShutdownCompleted(System.ComponentModel.AsyncCompletedEventArgs e)
        {
            // Check for errors
            if (e.Error != null)
            {
                ResetConnection();
            }
        }

        private void DeviceConnection_WriteCompleted(System.ComponentModel.AsyncCompletedEventArgs e)
        {
            // Check for errors
            if (e.Error != null)
            {
                // WriteCompleted will never be invoked if the write was successful; it will only invoke WriteCompleted if
                // a loss of connection happens.
                ResetConnection();
                //
                if (RestartAutomatically)
                {
                    // Restart connection.
                    RestartConnection();
                }
            }
        }

        private void DeviceConnection_ReadCompleted(AsyncResultEventArgs<Int32> e)
        {
            if (e.Error != null)
            {
                // 
                ResetConnection();
                //
                if (RestartAutomatically)
                {
                    // Restart Connection.
                    RestartConnection();
                }
                return;
            }
            // If we get a zero-length read, then that indicates the remote side graciously closed the connection
            if (e.Result == 0)
            {
                //
                ResetConnection();
                //
                if (RestartAutomatically)
                {
                    // Restart Connection.
                    RestartConnection();
                }
                return;
            }

            m_sbBuffer.Append(Encoding.ASCII.GetString(m_DataBuffer, 0, e.Result));

            // parse messages and put them in queue.
            ParseMessages(ref m_sbBuffer);

            ContinueReading();
        }

        protected virtual Boolean IsResponseOfControlOrQueryCommand(String response)
        {
            const String ACK  = "ACK";
            if (response.ToUpper().StartsWith(ACK))
            {
                return true;
            }
            const String QUERY_CMD_TYPE = "03";
            const Int32 NO_OF_GROUPS = 7;
            const String CMD_PATERN_EXP = "^(.*),(\\d+),(\\d+),(\\d+),(\\d+),(\\d+),(.*)";
            if (Regex.IsMatch(response, CMD_PATERN_EXP))
            {
                Match match = Regex.Match(response, CMD_PATERN_EXP);
                if (match.Groups.Count >= NO_OF_GROUPS)
                {
                    String cmdType = match.Groups[NO_OF_GROUPS - 1].Value;
                    if (cmdType.Equals(QUERY_CMD_TYPE))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        protected virtual void ParseMessages(ref StringBuilder sbBuffer)
        {
            String strBuffer = sbBuffer.ToString();
            String[] messages = strBuffer.Split(ResponseTerminators, StringSplitOptions.None);
            if (messages.Length >= 2) // Terminators found.
            {
                foreach (String message in messages)
                {
                    if ( (!KeepSeparator && (message.Length > 0)) || KeepSeparator )
                    {
                        foreach (String terminator in ResponseTerminators)
                        {
                            String messageArrived  = String.Empty;
                            if (strBuffer.IndexOf(message + terminator) >= 0)
                            {
                                if (KeepSeparator)
                                {
                                    messageArrived = message + terminator;
                                }
                                else
                                {
                                    messageArrived = message;
                                }
#if (AVP_PLATFORM_SL)
                                Fire_MessageArrivedEvent(messageArrived);
#else
                                // 
                                if (IsResponseOfControlOrQueryCommand(messageArrived))
                                {
                                    PutMessage(message);   
                                }
                                else
                                {
                                    Fire_MessageArrivedEvent(messageArrived);
                                }
                                //
#endif
                                sbBuffer.Remove(0, message.Length + terminator.Length);
                                strBuffer = sbBuffer.ToString();
                                break;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Requests a read directly into the correct buffer.
        /// </summary>
        private void ContinueReading()
        {
            m_connection.ReadAsync(this.m_DataBuffer, 0, BufferSize);
        }

        private void DeviceConnection_ConnectCompleted(System.ComponentModel.AsyncCompletedEventArgs e)
        {
            try
            {
                // Check for errors
                if (e.Error != null)
                {
                    ResetConnection();
                    //
                    if (RestartAutomatically)
                    {
                        // Restart connection.
                        RestartConnection();
                    }
                    return;
                }
                m_sbBuffer = new StringBuilder();
                // Adjust state
                Fire_ConnectionStateChange(SocketState.Connected);
                // Start reading data from the connection
                ContinueReading();
            }
            catch (Exception)
            {
                ResetConnection();
            }
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
        protected void PutMessage(String pstrRawMessageData)
        {
            lock (m_objQueueLock)
            {
                m_messageQueue.Enqueue(pstrRawMessageData);
                Monitor.Pulse(m_objQueueLock);
            }
        }

        private void ClearMessageQueue()
        {
            lock (m_objQueueLock)
            {
                m_messageQueue.Clear();
            }
        }

        public Boolean SendMessage(String strMessage, ref String strResponse, Int32 maxTimeWait)
        {
            try
            {
                lock (m_objSendCmdToDeviceLock)
                {
                    ClearMessageQueue();

                    if (SocketState.Connected == m_ConnectionStatus)
                    {
                        if (UseSendAsync)
                        {
                            m_connection.WriteAsync(Encoding.ASCII.GetBytes(strMessage));
                        }
                        else
                        {
                            m_connection.WriteSync(Encoding.ASCII.GetBytes(strMessage));
                        }
                        if (maxTimeWait <= 0)
                        {
                            return true;
                        }
                        strResponse = GetMessage(maxTimeWait);
                        if (!String.IsNullOrEmpty(strResponse))
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception) { }
            return false;
        }

        /// <summary>
        /// Retrieve a message from the queue.
        /// </summary>
        /// <param name="maxWait">Number of milliseconds to block if nothing is available. Timeout.Infinite means "block indefinitely"</param>
        /// <returns>The next item in the queue, or String.Empty if queue is empty</returns>
        protected String GetMessage(Int32 maxWait)
        {
            lock (m_objQueueLock)
            {
                if (m_messageQueue.Count == 0)
                {
                    if (maxWait == 0)
                        return String.Empty;
                    Monitor.Wait(m_objQueueLock, maxWait);
                    if (m_messageQueue.Count == 0)
                        return String.Empty;
                }
                return m_messageQueue.Dequeue();
            }
        }

        protected void Dispose(Boolean disposing)
        {
            if (disposing)
            {
                // Wake up the thread if it's in wait state.
                lock (m_objQueueLock)
                {
                    Monitor.Pulse(m_objQueueLock);
                }
                ResetConnection();
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
