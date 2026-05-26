using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Sockets;
using System.Net;

namespace DeviceNetApp.Lib
{
    /// <summary>
    /// Represents a child connection of a listening server socket, built on the asynchronous event-based model (see <see cref="IAsyncTcpConnection"/>).
    /// </summary>
    public sealed class ServerChildTcpSocket : IAsyncTcpConnection
    {
        /// <summary>
        /// The actual socket connection.
        /// </summary>
        private readonly TcpSocketImpl Socket;

        /// <summary>
        /// Creates a <see cref="ServerChildTcpSocket"/> from a <see cref="Socket"/>.
        /// </summary>
        /// <param name="socket">The new socket connection to use.</param>
        internal ServerChildTcpSocket(Socket socket)
        {
            Socket = new TcpSocketImpl(socket);
            Socket.ReadCompleted = delegate(AsyncResultEventArgs<int> e) { if (ReadCompleted != null) ReadCompleted(e); };
            Socket.WriteCompleted = delegate(AsyncCompletedEventArgs e) { if (WriteCompleted != null) WriteCompleted(e); };
            Socket.ShutdownCompleted = delegate(AsyncCompletedEventArgs e) { if (ShutdownCompleted != null) ShutdownCompleted(e); };
        }

        /// <summary>
        /// Disconnects all events for the underlying socket, except the shutdown event.
        /// </summary>
        private void DisconnectSocketEventsExceptShutdown()
        {
            Socket.ReadCompleted = null;
            Socket.WriteCompleted = null;
        }

        /// <summary>
        /// Disconnects all events for the underlying socket.
        /// </summary>
        private void DisconnectSocketEvents()
        {
            DisconnectSocketEventsExceptShutdown();
            Socket.ShutdownCompleted = null;
        }

        /// <summary>
        /// Gracefully or abortively closes the socket connection. See <see cref="Close"/>.
        /// </summary>
        public void Dispose()
        {
            Close();
        }

        #region Connection properties

        /// <inheritdoc />
        public IPEndPoint LocalEndPoint
        {
            get
            {
                return Socket.LocalEndPoint;
            }
        }

        /// <inheritdoc />
        public IPEndPoint RemoteEndPoint
        {
            get
            {
                return Socket.RemoteEndPoint;
            }
        }

        /// <inheritdoc />
        public bool NoDelay
        {
            get
            {
                return Socket.NoDelay;
            }
            set
            {
                Socket.NoDelay = value;
            }
        }

        /// <inheritdoc />
        public LingerOption LingerState
        {
            get
            {
                return Socket.LingerState;
            }
            set
            {
                Socket.LingerState = value;
            }
        }

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
            Socket.WriteAsync(buffer, 0, buffer.Length, null);
        }

        /// <inheritdoc />
        public void WriteAsync(byte[] buffer, object state)
        {
            Socket.WriteAsync(buffer, 0, buffer.Length, state);
        }

        /// <inheritdoc />
        public void WriteAsync(byte[] buffer, int offset, int size)
        {
            Socket.WriteAsync(buffer, offset, size, null);
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
            DisconnectSocketEventsExceptShutdown();
            Socket.ShutdownAsync();
        }

        /// <inheritdoc />
        public event Action<AsyncCompletedEventArgs> ShutdownCompleted;

        /// <inheritdoc />
        public void Close()
        {
            // Disconnect all socket events
            DisconnectSocketEvents();

            // By default, closing the socket handle will cause the socket to linger
            Socket.Dispose();
        }

        /// <inheritdoc />
        public void AbortiveClose()
        {
            // Disconnect all socket events
            DisconnectSocketEvents();

            // Set up the socket for an abortive close.
            Socket.SetAbortive();

            // Close the socket connection
            Socket.Dispose();
        }

        #endregion
    }
    /// <summary>
    /// Provides a wrapper around a <see cref="Socket"/>, translating the <see cref="IAsyncResult"/>-based notifications to event-based notifications,
    /// including thread synchronization. This is used for server (listening) sockets.
    /// </summary>
    internal sealed class ServerTcpSocketImpl : IDisposable
    {
        /// <summary>
        /// The socket for this connection.
        /// </summary>
        private Socket Socket_;

        /// <summary>
        /// Initializes a new server socket wrapper.
        /// </summary>
        // Always runs in User thread
        public ServerTcpSocketImpl()
        {
            Socket_ = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        /// <summary>
        /// Binds the socket to a local endpoint and begins listening. Note: does not start accepting.
        /// </summary>
        /// <param name="bindTo">The local endpoint to bind to.</param>
        /// <param name="backlog">The backlog for listening.</param>
        // Always runs in User thread
        public void Bind(IPEndPoint bindTo, int backlog)
        {
            Socket_.Bind(bindTo);
            Socket_.Listen(backlog);
        }

        /// <summary>
        /// Returns the IP address and port on this side of the connection.
        /// </summary>
        public IPEndPoint LocalEndPoint { get { return (IPEndPoint)Socket_.LocalEndPoint; } }

        /// <summary>
        /// Closes the underlying socket and frees the socket resources. Be sure to clear all events before calling this method!
        /// </summary>
        // Always runs in User thread
        public void Dispose()
        {
            // Do the actual close
            Socket_.Close();
        }

        #region Accept operation

        private Action<AsyncResultEventArgs<ServerChildTcpSocket>> acceptCompleted_;
        /// <summary>
        /// Delegate to invoke when the accept operation completes.
        /// </summary>
        public Action<AsyncResultEventArgs<ServerChildTcpSocket>> AcceptCompleted { get { return acceptCompleted_; } set { acceptCompleted_ = value; } }

        /// <summary>
        /// Initiates an accept operation on the socket. The operation will be completed via <see cref="AcceptCompleted"/>.
        /// </summary>
        // Always runs in User thread
        public void AcceptAsync()
        {
            Socket_.BeginAccept(Sync.SynchronizeAsyncCallback(delegate(IAsyncResult asyncResult)
            {
                Sync.InvokeAndCallback(delegate()
                {
                    return new ServerChildTcpSocket(Socket_.EndAccept(asyncResult));
                }, AcceptCompleted, null);
            }), null);
        }

        #endregion
    }
    /// <summary>
    /// Represents a listening server socket built on the asynchronous event-based model.
    /// </summary>
    /// <remarks>
    /// <para>No operations are ever cancelled. When the socket is closed, active operations do not complete.</para>
    /// <para>Only one accept operation may be active on a listening socket at any time.</para>
    /// <para>All operations must be initiated from a thread with a non-free-threaded synchronization context. This means that, e.g., GUI threads may call these methods, but free threads may not.</para>
    /// </remarks>
    public sealed class ServerTcpSocket : IDisposable
    {
        /// <summary>
        /// The traditional maximum value was 5, according to Stevens' TCP/IP vol 1; the current default is several hundred, but this is rarely
        /// necessary, so we use a value of 2.
        /// </summary>
        private const int DefaultBacklog = 2;

        /// <summary>
        /// The actual listening socket, which may be disconnected (null).
        /// </summary>
        private ServerTcpSocketImpl Socket_;

        /// <summary>
        /// The listening socket, created on demand.
        /// </summary>
        private ServerTcpSocketImpl Socket
        {
            get
            {
                if (Socket_ != null)
                    return Socket_;

                // Create a new socket connection and subscribe to its events
                Socket_ = new ServerTcpSocketImpl();
                Socket_.AcceptCompleted = delegate(AsyncResultEventArgs<ServerChildTcpSocket> e){ if (AcceptCompleted != null) AcceptCompleted(e); };

                return Socket_;
            }
        }

            /// <summary>
            /// Initializes a new instance of the <see cref="ServerTcpSocket"/> class.
            /// </summary>
            public ServerTcpSocket()
            {
                SynchronizationContextRegister.Verify(SynchronizationContextProperties.NonReentrantPost | SynchronizationContextProperties.NonReentrantSend | SynchronizationContextProperties.Sequential | SynchronizationContextProperties.Synchronized);
            }

            /// <summary>
            /// Closes the listening socket. See <see cref="Close"/>.
            /// </summary>
            public void Dispose()
            {
                Close();
            }

            /// <summary>
            /// Closes the listening socket immediately and frees all resources.
            /// </summary>
            /// <remarks>
            /// <para>No events will be raised once this method is called.</para>
            /// </remarks>
            public void Close()
            {
                // Do nothing if the underlying socket isn't there.
                if (Socket_ == null)
                    return;

                // Disconnect all socket events
                Socket_.AcceptCompleted = null;

                // Close the socket
                Socket_.Dispose();
                Socket_ = null;
            }

            #region Socket methods

            /// <overloads>
            /// <summary>
            /// Binds to a local endpoint and begins listening.
            /// </summary>
            /// <remarks>
            /// <para>Note that this does not begin accepting.</para>
            /// </remarks>
            /// </overloads>
            /// <summary>
            /// Binds to a local endpoint and begins listening.
            /// </summary>
            /// <remarks>
            /// <para>Note that this does not begin accepting.</para>
            /// </remarks>
            /// <param name="bindTo">The local endpoint.</param>
            /// <param name="backlog">The number of backlog connections for listening.</param>
            public void Bind(IPEndPoint bindTo, int backlog)
            {
                Socket.Bind(bindTo, backlog);
            }

            /// <inheritdoc cref="Bind(IPEndPoint, int)" />
            /// <param name="address">The address of the local endpoint.</param>
            /// <param name="port">The port of the local endpoint.</param>
            /// <param name="backlog">The number of backlog connections for listening.</param>
            public void Bind(IPAddress address, int port, int backlog)
            {
                Bind(new IPEndPoint(address, port), backlog);
            }

            /// <inheritdoc cref="Bind(IPEndPoint, int)" />
            /// <param name="bindTo">The local endpoint.</param>
            public void Bind(IPEndPoint bindTo)
            {
                Bind(bindTo, DefaultBacklog);
            }

            /// <inheritdoc cref="Bind(IPEndPoint, int)" />
            /// <param name="address">The address of the local endpoint.</param>
            /// <param name="port">The port of the local endpoint.</param>
            public void Bind(IPAddress address, int port)
            {
                Bind(new IPEndPoint(address, port), DefaultBacklog);
            }

            /// <inheritdoc cref="Bind(IPEndPoint, int)" />
            /// <param name="port">The port of the local endpoint.</param>
            /// <param name="backlog">The number of backlog connections for listening.</param>
            public void Bind(int port, int backlog)
            {
                Bind(new IPEndPoint(IPAddress.Any, port), backlog);
            }

            /// <inheritdoc cref="Bind(IPEndPoint, int)" />
            /// <param name="port">The port of the local endpoint.</param>
            public void Bind(int port)
            {
                Bind(new IPEndPoint(IPAddress.Any, port), DefaultBacklog);
            }

            #endregion

            #region Socket properties

            /// <summary>
            /// Returns the IP address and port of the listening socket.
            /// </summary>
            public IPEndPoint LocalEndPoint
            {
                get
                {
                    return Socket.LocalEndPoint;
                }
            }

            #endregion

            #region Accept operation

            /// <summary>
            /// Initiates an accept operation.
            /// </summary>
            /// <remarks>
            /// <para>There may be only one accept operation at a time for a listening socket.</para>
            /// <para>The accept operation will complete by invoking <see cref="AcceptCompleted"/> unless the socket is closed (<see cref="Close"/>).</para>
            /// <para>Accept operations are never cancelled.</para>
            /// </remarks>
            public void AcceptAsync()
            {
                Socket.AcceptAsync();
            }

            /// <summary>
            /// Indicates the completion of an accept operation, either successfully or with error.
            /// </summary>
            /// <remarks>
            /// <para>Accept operations are never cancelled.</para>
            /// <para>Accept operations will not complete if the socket is closed (<see cref="Close"/>).</para>
            /// <para>The result of the accept operation is a new socket connection.</para>
            /// <para>Generally, a handler of this event will call <see cref="AcceptAsync"/> to continue accepting other connections.</para>
            /// <para>If an accept operation completes with error, no action is necessary other than continuing to accept other connections.</para>
            /// </remarks>
            public event Action<AsyncResultEventArgs<ServerChildTcpSocket>> AcceptCompleted;

            #endregion
        }
    }