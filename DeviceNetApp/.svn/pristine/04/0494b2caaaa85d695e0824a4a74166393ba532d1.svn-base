using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceNetApp.Lib
{
    class AVPProtocol
    {
        /// <summary>
        /// The buffer for the data.
        /// </summary>
        private Byte[] m_DataBuffer;
        private const Int32 BufferSize = 1024;
        private StringBuilder m_sbBuffer;

        public String[] ResponseTerminators = new String[] { "\r" };

        /// <summary>
        /// Initializes a new instance of the <see cref="SocketPacketProtocol"/> class bound to a given socket connection.
        /// </summary>
        /// <param name="socket">The socket used for communication.</param>
        public AVPProtocol(IAsyncTcpConnection socket)
        {
            socket_ = socket;
            m_DataBuffer = new Byte[BufferSize];
            m_sbBuffer = new StringBuilder();
        }

        /// <summary>
        /// Indicates the completion of a packet read from the socket.
        /// </summary>
        /// <remarks>
        /// <para>This may be called with a null packet, indicating that the other end graciously closed the connection.</para>
        /// </remarks>
        public event Action<AsyncResultEventArgs<Byte[]>> PacketArrived;

        private IAsyncTcpConnection socket_;
        /// <summary>
        /// Gets the socket used for communication.
        /// </summary>
        public IAsyncTcpConnection Socket { get { return socket_; } }

        /// <overloads>
        /// <summary>Sends a packet to a socket.</summary>
        /// <remarks>
        /// <para>Generates a length prefix for the packet and writes the length prefix and packet to the socket.</para>
        /// </remarks>
        /// </overloads>
        /// <summary>Sends a packet to a socket.</summary>
        /// <remarks>
        /// <para>Generates a length prefix for the packet and writes the length prefix and packet to the socket.</para>
        /// </remarks>
        /// <param name="socket">The socket used for communication.</param>
        /// <param name="packet">The packet to send.</param>
        /// <param name="state">The user-defined state that is passed to WriteCompleted. May be null.</param>
        public static void WritePacketAsync(IAsyncTcpConnection socket, Byte[] packet, Object state)
        {
            // Get the length prefix for the message
            //byte[] lengthPrefix = BitConverter.GetBytes(packet.Length);

            // We use the special CallbackOnErrorsOnly object to tell the socket we don't want
            //  WriteCompleted to be invoked (it would confuse socket users if they see WriteCompleted
            //  events for writes they never started).
            //socket.WriteAsync(lengthPrefix, new CallbackOnErrorsOnly());

            // Send the actual message, this time enabling the normal callback.
            socket.WriteAsync(packet, state);
        }

        /// <inheritdoc cref="WritePacketAsync(IAsyncTcpConnection, byte[], object)" />
        /// <param name="socket">The socket used for communication.</param>
        /// <param name="packet">The packet to send.</param>
        public static void WritePacketAsync(IAsyncTcpConnection socket, Byte[] packet)
        {
            WritePacketAsync(socket, packet, null);
        }

        /// <summary>
        /// Begins reading from the socket.
        /// </summary>
        public void Start()
        {
            this.Socket.ReadCompleted += this.SocketReadCompleted;
            this.ContinueReading();
        }

        /// <summary>
        /// Requests a read directly into the correct buffer.
        /// </summary>
        private void ContinueReading()
        {
            Socket.ReadAsync(this.m_DataBuffer, 0, BufferSize);
        }

        /// <summary>
        /// Called when a socket read completes. Parses the received data and calls <see cref="PacketArrived"/> if necessary.
        /// </summary>
        /// <param name="e">Argument object containing the number of bytes read.</param>
        /// <exception cref="System.IO.InvalidDataException">If the data received is not a packet.</exception>
        private void SocketReadCompleted(AsyncResultEventArgs<Int32> e)
        {
            // Pass along read errors verbatim
            if (e.Error != null)
            {
                if (this.PacketArrived != null)
                {
                    this.PacketArrived(new AsyncResultEventArgs<Byte[]>(e.Error));
                }

                return;
            }
            // If we get a zero-length read, then that indicates the remote side graciously closed the connection
            if (e.Result == 0)
            {
                return;
            }

            m_sbBuffer.Append(Encoding.ASCII.GetString(m_DataBuffer, 0, e.Result));

            // parse messages and put them in queue.
            ParseMessages(ref m_sbBuffer);

            ContinueReading();
        }

        protected virtual void ParseMessages(ref StringBuilder sbBuffer)
        {
            String strBuffer = sbBuffer.ToString();
            String[] messages = strBuffer.Split(ResponseTerminators, StringSplitOptions.None);
            if (messages.Length >= 2) // Terminators found.
            {
                foreach (String message in messages)
                {
                    if (message.Length > 0)
                    {
                        foreach (String terminator in ResponseTerminators)
                        {
                            if (strBuffer.IndexOf(message + terminator) >= 0)
                            {
                                // Fire event.
                                if (this.PacketArrived != null)
                                {
                                    this.PacketArrived(new AsyncResultEventArgs<Byte[]>(Encoding.ASCII.GetBytes(message)));
                                }
                                // Remove it.
                                sbBuffer.Remove(0, message.Length + terminator.Length);
                                
                                strBuffer = sbBuffer.ToString();
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
