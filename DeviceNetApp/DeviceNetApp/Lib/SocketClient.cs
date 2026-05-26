using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace DeviceNetApp.Lib
{

    /// <summary>
    /// Represents a client socket built on the asynchronous event-based model (see <see cref="IAsyncTcpConnection"/>).
    /// </summary>
    /// <remarks>
    /// <para>Client sockets must be connected before they can be used for any other operations.</para>
    /// </remarks>
    public sealed class ClientTcpSocket : IAsyncTcpConnection
    {
        /// <summary>
        /// The actual socket connection, which may be disconnected (null).
        /// </summary>
        private ClientTcpSocketImpl Socket_;

        /// <summary>
        /// The socket connection, created on demand.
        /// </summary>
        private ClientTcpSocketImpl Socket
        {
            get
            {
                if (Socket_ != null)
                    return Socket_;

                // Create a new socket connection and subscribe to its events
                Socket_ = new ClientTcpSocketImpl();
                Socket_.ConnectCompleted = delegate(AsyncCompletedEventArgs e) { if (ConnectCompleted != null) ConnectCompleted(e); };
                Socket_.ReadCompleted = delegate(AsyncResultEventArgs<int> e) { if (ReadCompleted != null) ReadCompleted(e); };
                Socket_.WriteCompleted = delegate(AsyncCompletedEventArgs e) { if (WriteCompleted != null) WriteCompleted(e); };
                Socket_.ShutdownCompleted = delegate(AsyncCompletedEventArgs e) { if (ShutdownCompleted != null) ShutdownCompleted(e); };

                return Socket_;
            }
        }

        /// <summary>
        /// Throws an exception if the socket has not yet been created.
        /// </summary>
        private void EnsureOpen()
        {
            if (Socket_ == null)
                throw new InvalidOperationException("Socket is not open.");
        }

        /// <summary>
        /// Disconnects all events for the underlying socket, except the shutdown event.
        /// </summary>
        private void DisconnectSocketEventsExceptShutdown()
        {
            Socket_.ConnectCompleted = null;
            Socket_.ReadCompleted = null;
            Socket_.WriteCompleted = null;
        }

        /// <summary>
        /// Disconnects all events for the underlying socket.
        /// </summary>
        private void DisconnectSocketEvents()
        {
            DisconnectSocketEventsExceptShutdown();
            Socket_.ShutdownCompleted = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientTcpSocket"/> class.
        /// </summary>
        public ClientTcpSocket()
        {
            // If we are running UNIT_TEST, uncomment this line of code.
            // SynchronizationContextRegister.Verify(SynchronizationContextProperties.None);
            SynchronizationContextRegister.Verify(SynchronizationContextProperties.NonReentrantPost | SynchronizationContextProperties.NonReentrantSend | SynchronizationContextProperties.Sequential | SynchronizationContextProperties.Synchronized);
        }

        /// <summary>
        /// Gracefully or abortively closes the socket connection. See <see cref="Close"/>.
        /// </summary>
        public void Dispose()
        {
            Close();
        }

        #region Socket methods

        /// <summary>
        /// Binds to a local endpoint. This method is not normally used.
        /// </summary>
        /// <remarks>
        /// <para>This method may not be called after <see cref="O:Nito.Async.Sockets.ClientTcpSocket.ConnectAsync"/>.</para>
        /// </remarks>
        /// <param name="bindTo">The local endpoint.</param>
        public void Bind(IPEndPoint bindTo)
        {
            Socket.Bind(bindTo);
        }

        #endregion

        #region Connection properties

        /// <inheritdoc />
        /// <summary>
        /// <inheritdoc />
        /// Only valid once the socket is connected.
        /// </summary>
        public IPEndPoint LocalEndPoint
        {
            get
            {
                EnsureOpen();
                return Socket.LocalEndPoint;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// <inheritdoc />
        /// Only valid once the socket is connected.
        /// </summary>
        public IPEndPoint RemoteEndPoint
        {
            get
            {
                EnsureOpen();
                return Socket.RemoteEndPoint;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// <inheritdoc />
        /// Only valid once the socket is connected.
        /// </summary>
        public bool NoDelay
        {
            get
            {
                EnsureOpen();
                return Socket.NoDelay;
            }
            set
            {
                EnsureOpen();
                Socket.NoDelay = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// <inheritdoc />
        /// Only valid once the socket is connected.
        /// </summary>
        public LingerOption LingerState
        {
            get
            {
                EnsureOpen();
                return Socket.LingerState;
            }
            set
            {
                EnsureOpen();
                Socket.LingerState = value;
            }
        }

        #endregion

        #region Connect operation

        /// <overloads>
        /// <summary>
        /// Initiates a connect operation.
        /// </summary>
        /// <remarks>
        /// <para>There may be only one connect operation for a client socket, and it must be the first operation performed.</para>
        /// <para>The connect operation will complete by invoking <see cref="ConnectCompleted"/>, unless the socket is closed (<see cref="Close"/>) or abortively closed (<see cref="AbortiveClose"/>).</para>
        /// <para>Connect operations are never cancelled.</para>
        /// </remarks>
        /// </overloads>
        /// <summary>
        /// Initiates a connect operation.
        /// </summary>
        /// <remarks>
        /// <para>There may be only one connect operation for a client socket, and it must be the first operation performed.</para>
        /// <para>The connect operation will complete by invoking <see cref="ConnectCompleted"/>, unless the socket is closed (<see cref="Close"/>) or abortively closed (<see cref="AbortiveClose"/>).</para>
        /// <para>Connect operations are never cancelled.</para>
        /// </remarks>
        /// <param name="server">The address and port of the server to connect to.</param>
        public void ConnectAsync(IPEndPoint server)
        {
            Socket.ConnectAsync(server);
        }

        /// <inheritdoc cref="ConnectAsync(IPEndPoint)" />
        /// <param name="address">The address of the server to connect to.</param>
        /// <param name="port">The port of the server to connect to.</param>
        public void ConnectAsync(IPAddress address, int port)
        {
            ConnectAsync(new IPEndPoint(address, port));
        }

        /// <summary>
        /// Indicates the completion of a connect operation, either successfully or with error.
        /// </summary>
        /// <remarks>
        /// <para>Connect operations are never cancelled.</para>
        /// <para>Connect operations will not complete if the socket is closed (<see cref="Close"/>) or abortively closed (<see cref="AbortiveClose"/>).</para>
        /// <para>Generally, a handler of this event will call <see cref="ReadAsync"/> to start a read operation immediately.</para>
        /// <para>If a connect operation completes with error, the socket should be closed (<see cref="Close"/>) or abortively closed (<see cref="AbortiveClose"/>).</para>
        /// </remarks>
        public event Action<AsyncCompletedEventArgs> ConnectCompleted;

        #endregion

        #region Read operation

        /// <inheritdoc />
        public void ReadAsync(byte[] buffer, int offset, int size)
        {
            Socket.ReadAsync(buffer, offset, size);
        }

        /// <inheritdoc />
        public event Action<AsyncResultEventArgs<int>> ReadCompleted;

        #endregion

        #region Write operation

        /// <inheritdoc />
        public void WriteSync(Byte[] buffer)
        {
            Socket.WriteSync(buffer, 0, buffer.Length);
        }

        /// <inheritdoc />
        public void WriteAsync(byte[] buffer)
        {
            WriteAsync(buffer, 0, buffer.Length, null);
        }

        /// <inheritdoc />
        public void WriteAsync(byte[] buffer, object state)
        {
            WriteAsync(buffer, 0, buffer.Length, state);
        }

        /// <inheritdoc />
        public void WriteAsync(byte[] buffer, int offset, int size)
        {
            WriteAsync(buffer, offset, size, null);
        }

        /// <inheritdoc />
        public void WriteAsync(byte[] buffer, int offset, int size, object state)
        {
            Socket.WriteAsync(buffer, offset, size, state);
        }

        /// <inheritdoc />
        public event Action<AsyncCompletedEventArgs> WriteCompleted;

        #endregion

        #region Shutdown operation

        /// <inheritdoc />
        public void ShutdownAsync()
        {
            EnsureOpen();

            // Disconnect all events except the shutdown event
            DisconnectSocketEventsExceptShutdown();

            // Initiate the shutdown
            Socket.ShutdownAsync();
        }

        /// <inheritdoc />
        public event Action<AsyncCompletedEventArgs> ShutdownCompleted;

        /// <inheritdoc />
        /// <remarks>
        /// <inheritdoc />
        /// <para>This method is a noop if the socket was never connected.</para>
        /// </remarks>
        public void Close()
        {
            // Do nothing if the underlying socket isn't there.
            if (Socket_ == null)
                return;

            // Disconnect all socket events
            DisconnectSocketEvents();

            // By default, closing the socket handle will cause the socket to linger
            Socket_.Dispose();

            // GC won't abort the graceful closure, because the WinSock API will keep it alive for a time
            Socket_ = null;
        }

        /// <inheritdoc />
        /// <remarks>
        /// <inheritdoc />
        /// <para>This method is a noop if the socket was never connected.</para>
        /// </remarks>
        public void AbortiveClose()
        {
            // Do nothing if the underlying socket isn't there.
            if (Socket_ == null)
                return;

            // Disconnect all socket events
            DisconnectSocketEvents();

            // Set up the socket for an abortive close.
            Socket_.SetAbortive();

            // Close the socket connection
            Socket_.Dispose();
            Socket_ = null;
        }

        #endregion
    }
}
