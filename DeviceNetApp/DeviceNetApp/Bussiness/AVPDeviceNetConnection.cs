using System;
using System.Text;
using System.Collections.Generic;
using System.Collections;
using System.Net;
using System.Threading;
using DeviceNetApp.Lib;

namespace DeviceNetApp.Bussiness
{
   using System.ComponentModel;

    public class AVPDeviceNetConnection : BaseThread
    {
        private ArrayList m_arrChildSockets = new ArrayList();
        private SimpleServerTcpSocket m_ServerConnection;      
        private Int32 m_iPort;
        private string m_strSendSeparator = "\r";

        // AVP Message queue
        private Queue<String> m_messageQueue;
        private Object m_objQueueLock = new Object();
        private ManualResetEvent m_wakeUpEvent = new ManualResetEvent(false);

        // Used for sending and waitting for the result
        private Queue<String> m_messageSendAndWaitQueue;
        private Object m_objSendAndWaitQueueLock = new Object();

        // Connected with PVD6S or not
        private Boolean m_blIsConnectedWithAVP = false;
        public Boolean IsConnectedWithAVP
        {
            get { return m_blIsConnectedWithAVP; }
        }

        private Object m_objSendCmdToDeviceLock = new Object();
        private CommandProcessor m_objCommandProcessor = null;
        /// <author>
        /// <name>Vo Tan Dat</name>
        /// <date> 2009-12-16</date>
        /// </author>
        /// <summary>
        /// 
        /// </summary>
        /// <para></para>
        /// <returns></returns>
        public AVPDeviceNetConnection(): base("AVPMessageController")
        {

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
        public bool Initialize()
        {
            Logger.LogHandler.Info("Enter: Initialize");
            bool blRes = true;
            try
            {
                // Initialize the Message Controller
                int iPort = Constants.SYSTEM_PORT;

                m_objCommandProcessor = new CommandProcessor();
                m_iPort = iPort;
                m_messageQueue = new Queue<String>();

                // For sending and waiting
                m_messageSendAndWaitQueue = new Queue<String>();

                // Make connection to device first time.
                StartServerCommunication();

                // Start the processing message thread
                this.Run();
            }
            catch (Exception ex)
            {
                blRes = false;
                Logger.LogHandler.Error(ex.Message);
            }
            Logger.LogHandler.Info("Leave: Initialize");
            return blRes;
        }

        ~AVPDeviceNetConnection()
        {
            Dispose(false);
        }

        public void StartServerCommunication()
        {
            Logger.LogHandler.Info("Enter StartServerCommunication");
            // Define the socket, bind to the port, and start accepting connections
            m_ServerConnection = new SimpleServerTcpSocket();
            m_ServerConnection.ConnectionArrived += new Action<AsyncResultEventArgs<SimpleServerChildTcpSocket>>(ServerConnection_ConnectionArrived);
            m_ServerConnection.Listen(m_iPort);
            Logger.LogHandler.Info("Leave StartServerCommunication");           
        }

        /// <summary>
        /// Closes and clears the socket, without causing exceptions.
        /// </summary>
        public void StopServerCommunication()
        {
            Logger.LogHandler.Info("Enter StopServerCommunication"); 
            // Close all child sockets
            foreach (SimpleServerChildTcpSocket socket in m_arrChildSockets)
                socket.Close();
            m_arrChildSockets.Clear();
            if (m_ServerConnection != null)
            {
                // Close the listening socket
                m_ServerConnection.Close();
                m_ServerConnection = null;
            }

            
            Logger.LogHandler.Info("Leave StopServerCommunication");
        }

        private void ResetChildSocket(SimpleServerChildTcpSocket childSocket)
        {
            Logger.LogHandler.Info("Enter ResetChildSocket");
            // Close the child socket if possible
            if (childSocket != null)
                childSocket.Close();

            // Remove it from the list of child sockets
            m_arrChildSockets.Remove(childSocket);
            Logger.LogHandler.Info("Leave ResetChildSocket");
        }

        void ServerConnection_ConnectionArrived(AsyncResultEventArgs<SimpleServerChildTcpSocket> e)
        {
            Logger.LogHandler.Info("Enter ServerConnection_ConnectionArrived");
            // Check for errors
            if (e.Error != null)
            {
                StopServerCommunication();
                Logger.LogHandler.Error("Socket error during Accept: [" + e.Error.GetType().Name + "] " + e.Error.Message);
                return;
            }

            SimpleServerChildTcpSocket socket = e.Result;

            try
            {
                // Save the new child socket connection
                m_arrChildSockets.Add(socket);                
                socket.PacketArrived += delegate(AsyncResultEventArgs<byte[]> args) { ChildSocket_PacketArrived(socket, args); };
                socket.WriteCompleted += delegate(AsyncCompletedEventArgs args) { ChildSocket_WriteCompleted(socket, args); };
                socket.ShutdownCompleted += delegate(AsyncCompletedEventArgs args) { ChildSocket_ShutdownCompleted(socket, args); };

                // Display the connection information
                Logger.LogHandler.Info("Connection established to " + socket.RemoteEndPoint.ToString());
            }
            catch (Exception ex)
            {
                ResetChildSocket(socket);
                Logger.LogHandler.Error(ex.Message);
            }
            Logger.LogHandler.Info("Leave ServerConnection_ConnectionArrived");
        }

        private void ChildSocket_PacketArrived(SimpleServerChildTcpSocket socket, AsyncResultEventArgs<byte[]> e)
        {
            // Logger.LogHandler.Info("Enter ChildSocket_PacketArrived");
            try
            {
                // Check for errors
                if (e.Error != null)
                {
                    Logger.LogHandler.Error("Client socket error during Read from " + socket.RemoteEndPoint.ToString() + ": [" + e.Error.GetType().Name + "] " + e.Error.Message);
                    ResetChildSocket(socket);
                }
                else if (e.Result == null)
                {
                    // PacketArrived completes with a null packet when the other side gracefully closes the connection
                    Logger.LogHandler.Debug("Socket graceful close detected from " + socket.RemoteEndPoint.ToString());

                    // Close the socket and remove it from the list
                    ResetChildSocket(socket);
                }
                else
                {
                    // At this point, we know we actually got a message.
                    // Handle the message                    
                    string strMessage = Encoding.ASCII.GetString(e.Result);
                    if (strMessage != null)
                    {
                        //Logger.LogHandler.Debug("Socket read got a string message from " + socket.RemoteEndPoint.ToString() + ": " + strMessage);
                        
                        // There are 2 cases
                        // 1. The reply message back to PVD6S
                        // 2. The control message                        

                        if (IsReplyMessage(strMessage))
                        {
                            // Put into the reply and waiting queue
                            PutReplyMessage(strMessage);
                        }
                        else
                        {
                            // Put into the command queue
                            PutMessage(strMessage);                            
                        }
                        return;
                    }

                    Logger.LogHandler.Debug("Socket read got an unknown message from " + socket.RemoteEndPoint.ToString() + " of type " + strMessage.GetType().Name);
                }
            }
            catch (Exception ex)
            {
                Logger.LogHandler.Error("Error reading from socket " + socket.RemoteEndPoint.ToString() + ": [" + ex.GetType().Name + "] " + ex.Message);
                ResetChildSocket(socket);
            }
            Logger.LogHandler.Info("Leave ChildSocket_PacketArrived");
        }

        private void ChildSocket_ShutdownCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Logger.LogHandler.Info("Enter ChildSocket_ShutdownCompleted");
            
            SimpleServerChildTcpSocket socket = (SimpleServerChildTcpSocket)sender;

            // Check for errors
            if (e.Error != null)
            {
                Logger.LogHandler.Error("Socket error during Shutdown of " + socket.RemoteEndPoint.ToString() + ": [" + e.Error.GetType().Name + "] " + e.Error.Message);
                ResetChildSocket(socket);
            }
            else
            {
                Logger.LogHandler.Debug("Socket shutdown completed on " + socket.RemoteEndPoint.ToString());

                // Close the socket and remove it from the list
                ResetChildSocket(socket);
            }
            Logger.LogHandler.Info("Leave ChildSocket_ShutdownCompleted");
        }

        private void ChildSocket_WriteCompleted(SimpleServerChildTcpSocket socket, AsyncCompletedEventArgs e)
        {
            // Logger.LogHandler.Info("Enter ChildSocket_WriteCompleted");
            // Check for errors
            if (e.Error != null)
            {
                // Note: WriteCompleted may be called as the result of a normal write (SocketPacketizer.WritePacketAsync),
                //  or as the result of a call to SocketPacketizer.WriteKeepaliveAsync. However, WriteKeepaliveAsync
                //  will never invoke WriteCompleted if the write was successful; it will only invoke WriteCompleted if
                //  the keepalive packet failed (indicating a loss of connection).

                // If you want to get fancy, you can tell if the error is the result of a write failure or a keepalive
                //  failure by testing e.UserState, which is set by normal writes.
                if (e.UserState is string)
                    Logger.LogHandler.Error("Socket error during Write to " + socket.RemoteEndPoint.ToString() + ": [" + e.Error.GetType().Name + "] " + e.Error.Message);
                else
                    Logger.LogHandler.Error("Socket error detected by keepalive to " + socket.RemoteEndPoint.ToString() + ": [" + e.Error.GetType().Name + "] " + e.Error.Message);

                ResetChildSocket(socket);
            }
            else
            {
                string description = (string)e.UserState;
                // Logger.LogHandler.Debug("Socket write completed to " + socket.RemoteEndPoint.ToString() + " for message " + description);
            }
            // Logger.LogHandler.Info("Leave ChildSocket_WriteCompleted");
        }
        
        /// <author>
        /// <name>Vo Tan Dat</name>
        /// <date> 2009-12-14</date>
        /// </author>
        /// <summary>
        /// 
        /// </summary>
        /// <para></para>
        /// <returns></returns>
        public void PutMessage(String pstrRawMessageData)
        {
            // Logger.LogHandler.Info("Enter PutMessage");
            lock (m_objQueueLock)
            {
                m_messageQueue.Enqueue(pstrRawMessageData);
                // Logger.LogHandler.Debug("Put message into queue: " + pstrRawMessageData);
                m_wakeUpEvent.Set();
            }
            // Logger.LogHandler.Info("Leave PutMessage");
        }

        /// <author>
        /// <name>Vo Tan Dat</name>
        /// <date> 2010-05-11</date>
        /// </author>
        /// <summary>
        /// Put the message to the waiting queue
        /// </summary>
        /// <para></para>
        /// <returns></returns>
        private void PutReplyMessage(String pstrReplyMessageData)
        {            
            lock (m_objSendAndWaitQueueLock)
            {
                m_messageSendAndWaitQueue.Enqueue(pstrReplyMessageData);
                Monitor.Pulse(m_objSendAndWaitQueueLock);
            }            
        }

        /// <author>
        /// <name>Vo Tan Dat</name>
        /// <date> 2010-05-11</date>
        /// </author>
        /// <summary>
        /// Get the reply message from the waiting queue
        /// </summary>
        /// <para></para>
        /// <returns></returns>
        public String GetReplyMessage(Int32 maxWait)
        {
            lock (m_objSendAndWaitQueueLock)
            {
                if (m_messageSendAndWaitQueue.Count == 0)
                {
                    if (maxWait == 0)
                        return String.Empty;
                    Monitor.Wait(m_objSendAndWaitQueueLock, maxWait);
                    if (m_messageSendAndWaitQueue.Count == 0)
                        return String.Empty;
                }
                return m_messageSendAndWaitQueue.Dequeue();
            }
        }

        /// <author>
        /// <name>Vo Tan Dat</name>
        /// <date> 2013-02-01</date>
        /// </author>
        /// <summary>
        /// Check if having reply message
        /// </summary>
        /// <para></para>
        /// <returns></returns>
        public Boolean HasReplyMessage()
        {
            return (m_messageSendAndWaitQueue.Count > 0);
        }
        /// <author>
        /// <name>Vo Tan Dat</name>
        /// <date> 2010-05-11</date>
        /// </author>
        /// <summary>
        /// Sending message to AVP and waiting the reply message
        /// </summary>
        /// <para></para>
        /// <returns></returns>
        public Boolean SendRequestMessage(String pstrRawMessageData)
        {
            lock (m_objSendAndWaitQueueLock)
            {
                // Clear waiting queue
                m_messageSendAndWaitQueue.Clear();

                if (SendMessage(pstrRawMessageData))
                {
                     return true;
                }
            }            
            return false;
        }

        /// <author>
        /// <name>Vo Tan Dat</name>
        /// <date> 2009-12-14</date>
        /// </author>
        /// <summary>
        /// 
        /// </summary>
        /// <para></para>
        /// <returns></returns>
        public Boolean SendMessage(String pstrRawMessageData)
        {
            try
            {

                // Logger.LogHandler.Info("Enter SendMessage");    

                lock (m_objSendCmdToDeviceLock)
                {
                    if (m_arrChildSockets.Count == 0)
                    {
                        // Logger.LogHandler.Debug("No client connected");
                        // Logger.LogHandler.Debug("Leave SendMessage: False");
                        m_blIsConnectedWithAVP = false;
                        return false;
                    }

                    if (m_arrChildSockets.Count > 0)
                    {
                        SimpleServerChildTcpSocket socket = (SimpleServerChildTcpSocket)m_arrChildSockets[0];
                        if (socket != null)
                        {
                            socket.WriteAsync(Encoding.ASCII.GetBytes(pstrRawMessageData + m_strSendSeparator));
                            //Logger.LogHandler.Debug("Send message to AVP: " + pstrRawMessageData);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogHandler.Error(ex.Message);
                if (m_arrChildSockets.Count > 0)
                {
                    ResetChildSocket((SimpleServerChildTcpSocket)m_arrChildSockets[0]); // Remove the child socket if the current is error
                }
                Logger.LogHandler.Error("Leave SendMessage: False");
                return false;
            }

            // Logger.LogHandler.Info("Leave SendMessage");
            m_blIsConnectedWithAVP = true;
            return true;
        }

        /// <summary>
        /// Pick an message from the queue and process
        /// </summary>
        /// <param name="maxWait"></param>
        /// <returns></returns>
        protected void ProcessMessage()
        {
            // Logger.LogHandler.Info("Enter ProcessMessage");
            String msg = String.Empty;
            if (m_messageQueue.Count == 0)
            {
                // Logger.LogHandler.Debug("m_messagequeue is empty and wait");
                m_wakeUpEvent.WaitOne(Timeout.Infinite, false);
            }
            if (m_messageQueue.Count == 0)
            {
                return;
            }
            else
            {
                m_wakeUpEvent.Reset();
                lock (m_objQueueLock)
                {
                    msg = m_messageQueue.Dequeue();
                }
                // Logger.LogHandler.Debug("dequeue message and process: " + msg);
            }
            if (!String.IsNullOrEmpty(msg))
            {
                // route message to right destination
                RouteMessage(msg);
                
            }
            // Logger.LogHandler.Info("Leave ProcessMessage");
        }

        protected void RouteMessage(String p_strMessage)
        {
            // Call command processor here to dispatch this message
            // Logger.LogHandler.Debug("Route message: " + p_strMessage);
            m_objCommandProcessor.ProcessCommand(p_strMessage);
        }

        // Thread for processing message
        protected override void ThreadMainRoutine()
        {
            try
            {
                while (false == HasTerminateRequest())
                {
                    Boolean awokenByTerminate = SuspendIfNeeded();
                    if (awokenByTerminate)
                    {
                        return;
                    }

                    // Pick message from queue and process this message
                    ProcessMessage();
                }
            }
            finally
            {

            }
        }

        protected override void Dispose(bool disposing)
        {
            Logger.LogHandler.Info("Enter Dispose");
            if (disposing)
            {
                this.Terminate();
                m_wakeUpEvent.Set();
                
                // Wake up the thread if it's in wait state.
                lock (m_objSendAndWaitQueueLock)
                {
                    Monitor.Pulse(m_objSendAndWaitQueueLock);
                } 

                StopServerCommunication();
            }
            base.Dispose(disposing);
            Logger.LogHandler.Info("Leave Dispose");
        }
        private Boolean IsReplyMessage(String p_strMsg)
        {
            //if (p_strMsg.StartsWith(ConfigurationManager.CommandDef.ROUGH_PUMP_USEAGE_REQUEST_REPLY)) // Add more message if needed
            //{
                //return true;
            //}
            //else
            //{
                return false;
            //}
        }
    }
}
