using System;
using System.Net;
using System.Net.Sockets;
using System.ComponentModel;
using System.Collections.Generic;

namespace AVP.Network
{
    // Copyright 2009 by Nito Programs.

    // There are two layers of classes defined in this file: the lower layer (ending in *Impl) provides a thin translation from IAsyncResult
    // notifications to event-based notifications, including thread synchronization. The second layer provides additional concurrency requirements,
    // especially concerning socket shutdown (e.g., preventing events from being raised on a socket after Close has been called).

    // Thanks so much to Nito.

    /// <summary>
    /// This is a special class that may be passed to some WriteAsync methods to indicate that WriteCompleted should not be called on success.
    /// </summary>
    public sealed class CallbackOnErrorsOnly { }

    /// <summary>
    /// Represents a connected data socket built on the asynchronous event-based model.
    /// </summary>
    /// <remarks>
    /// <para>No operations are ever cancelled. During a socket shutdown, some operations may not complete; see below for details.</para>
    /// <para>Only one read operation should be active on a data socket at any time.</para>
    /// <para>Multiple write operations may be active on a data socket; the data will be written to the socket in order.</para>
    /// <para>Disconnecting a socket may be done one of three ways: shutting down a socket, closing a socket, and abortively closing a socket.
    /// <para>Shutting down a socket performs a graceful disconnect. Once a socket starts shutting down, no read or write operations will complete; only the shutting down operation will complete.</para>
    /// <para>Closing a socket performs a graceful disconnect in the background. Once a socket is closed, no operations will complete.</para>
    /// <para>Abortively closing a socket performs an immediate hard close. This is not recommended in general practice, but is the fastest way to release system socket resources. Once a socket is abortively closed, no operations will complete.</para></para>
    /// <para>All operations must be initiated from a thread with a non-free-threaded synchronization context. This means that, e.g., GUI threads may call these methods, but free threads may not.</para>
    /// </remarks>
    public interface IAsyncTcpConnection : IDisposable
    {
        #region Connection properties

        /// <summary>
        /// Returns the IP address and port on this side of the connection.
        /// </summary>
        IPEndPoint LocalEndPoint { get; }

        /// <summary>
        /// Returns the IP address and port on the remote side of the connection.
        /// </summary>
        IPEndPoint RemoteEndPoint { get; }

        /// <summary>
        /// True if the Nagle algorithm has been disabled.
        /// </summary>
        /// <remarks>
        /// <para>The default is false. Generally, this should be left to its default value.</para>
        /// </remarks>
        bool NoDelay { get; set; }

        /// <summary>
        /// If and how long a graceful shutdown will be performed in the background.
        /// </summary>
        /// <remarks>
        /// <para>Setting LingerState to enabled with a 0 timeout will make all calls to <see cref="Close"/> act as though <see cref="AbortiveClose"/> was called. Generally, this should be left to its default value.</para>
        /// </remarks>
        LingerOption LingerState { get; set; }

        #endregion

        #region Read operation

        /// <summary>
        /// Initiates a read operation.
        /// </summary>
        /// <param name="buffer">The buffer to receive the data.</param>
        /// <param name="offset">The offset into <paramref name="buffer"/> to write the received data.</param>
        /// <param name="size">The maximum number of bytes that may be written into <paramref name="buffer"/> at <paramref name="offset"/>.</param>
        /// <remarks>
        /// <para>There may be only one active read operation at any time.</para>
        /// <para>The read operation will complete by invoking <see cref="ReadCompleted"/>, unless the socket is shut down (<see cref="ShutdownAsync"/>), closed (<see cref="Close"/>), or abortively closed (<see cref="AbortiveClose"/>).</para>
        /// <para>Read operations are never cancelled.</para>
        /// </remarks>
        void ReadAsync(byte[] buffer, int offset, int size);

        /// <summary>
        /// Indicates the completion of a read operation, either successfully or with error.
        /// </summary>
        /// <remarks>
        /// <para>Read operations are never cancelled.</para>
        /// <para>Read operations will not complete if the socket is shut down (<see cref="ShutdownAsync"/>), closed (<see cref="Close"/>), or abortively closed (<see cref="AbortiveClose"/>).</para>
        /// <para>Generally, a handler of this event will call <see cref="ReadAsync"/> to start another read operation immediately.</para>
        /// <para>If a read operation completes with error, the socket should be closed (<see cref="Close"/>) or abortively closed (<see cref="AbortiveClose"/>).</para>
        /// <para>The result of a read operation is the number of bytes read from the socket.</para>
        /// <para>Note that a successful read operation may complete even though it only read part of the buffer.</para>
        /// <para>A successful read operation may also complete with a 0-length read; this indicates the remote side has gracefully closed. The appropriate response to a 0-length read is to <see cref="Close"/> the socket.</para>
        /// </remarks>
        event Action<AsyncResultEventArgs<int>> ReadCompleted;

        #endregion

        #region Write operation
        /// <summary>
        /// Initiates a synchronous write operation.
        /// </summary>
        /// <param name="buffer">The data to write to the socket.</param>
        void WriteSync(Byte[] buffer);

        /// <overloads>
        /// <summary>
        /// Initiates a write operation.
        /// </summary>
        /// <remarks>
        /// <para>Multiple write operations may be active at the same time.</para>
        /// <para>The write operation will complete by invoking <see cref="WriteCompleted"/>, unless the socket is shut down (<see cref="ShutdownAsync"/>), closed (<see cref="Close"/>), or abortively closed (<see cref="AbortiveClose"/>).</para>
        /// <para>Write operations are never cancelled.</para>
        /// </remarks>
        /// </overloads>
        /// <summary>
        /// Initiates a write operation.
        /// </summary>
        /// <remarks>
        /// <para>Multiple write operations may be active at the same time.</para>
        /// <para>The write operation will complete by invoking <see cref="WriteCompleted"/>, unless the socket is shut down (<see cref="ShutdownAsync"/>), closed (<see cref="Close"/>), or abortively closed (<see cref="AbortiveClose"/>).</para>
        /// <para>Write operations are never cancelled.</para>
        /// </remarks>
        /// <param name="buffer">The data to write to the socket.</param>
        void WriteAsync(byte[] buffer);

        /// <inheritdoc cref="WriteAsync(byte[])" />
        /// <remarks>
        /// <inheritdoc cref="WriteAsync(byte[])" />
        /// <para>If <paramref name="state"/> is an instance of <see cref="CallbackOnErrorsOnly"/>, then <see cref="WriteCompleted"/> is only invoked in an error situation; it is not invoked if the write completes successfully.</para>
        /// </remarks>
        /// <param name="buffer">The data to write to the socket.</param>
        /// <param name="state">The context, which is passed to <see cref="WriteCompleted"/> as <c>e.UserState</c>.</param>
        void WriteAsync(byte[] buffer, object state);

        /// <inheritdoc cref="WriteAsync(byte[])" />
        /// <param name="buffer">The buffer containing the data to write to the socket.</param>
        /// <param name="offset">The offset of the data within <paramref name="buffer"/>.</param>
        /// <param name="size">The number of bytes of data, at <paramref name="offset"/> within <paramref name="buffer"/>.</param>
        void WriteAsync(byte[] buffer, int offset, int size);

        /// <inheritdoc cref="WriteAsync(byte[], object)" />
        /// <param name="buffer">The buffer containing the data to write to the socket.</param>
        /// <param name="offset">The offset of the data within <paramref name="buffer"/>.</param>
        /// <param name="size">The number of bytes of data, at <paramref name="offset"/> within <paramref name="buffer"/>.</param>
        /// <param name="state">The context, which is passed to <see cref="WriteCompleted"/> as <c>e.UserState</c>.</param>
        void WriteAsync(byte[] buffer, int offset, int size, object state);

        /// <summary>
        /// Indicates the completion of a write operation, either successfully or with error.
        /// </summary>
        /// <remarks>
        /// <para>Write operations are never cancelled.</para>
        /// <para>Write operations will not complete if the socket is shut down (<see cref="ShutdownAsync"/>), closed (<see cref="Close"/>), or abortively closed (<see cref="AbortiveClose"/>).</para>
        /// <para>Note that even though a write operation completes, the data may not have been received by the remote end. However, it is still important to handle <see cref="WriteCompleted"/>, because errors may be reported.</para>
        /// <para>If a write operation completes with error, the socket should be closed (<see cref="Close"/>) or abortively closed (<see cref="AbortiveClose"/>).</para>
        /// </remarks>
        event Action<AsyncCompletedEventArgs> WriteCompleted;

        #endregion

        #region Shutdown operation

        /// <summary>
        /// Initiates a shutdown operation. Once a shutdown operation is initiated, only the shutdown operation will complete.
        /// </summary>
        /// <remarks>
        /// <para>The shutdown operation will complete by invoking <see cref="ShutdownCompleted"/>.</para>
        /// <para>Shutdown operations are never cancelled.</para>
        /// </remarks>
        void ShutdownAsync();

        /// <summary>
        /// Indicates the completion of a shutdown operation, either successfully or with error.
        /// </summary>
        /// <remarks>
        /// <para>Shutdown operations are never cancelled.</para>
        /// <para>Generally, a shutdown completing with error is handled the same as a shutdown completing successfully: the normal response in both situations is to <see cref="Close"/> the socket.</para>
        /// </remarks>
        event Action<AsyncCompletedEventArgs> ShutdownCompleted;

        /// <summary>
        /// Gracefully or abortively closes the socket. Once this method is called, no operations will complete.
        /// </summary>
        /// <remarks>
        /// <para>This method performs a graceful shutdown of the underlying socket; however, this is performed in the background, so the application never receives notification of its completion. <see cref="ShutdownAsync"/> performs a graceful shutdown with completion.</para>
        /// <para>Note that exiting the process after calling this method but before the background shutdown completes will result in an abortive close.</para>
        /// <para><see cref="LingerState"/> will determine whether this method will perform a graceful or abortive close.</para>
        /// </remarks>
        void Close();

        /// <summary>
        /// Abortively closes the socket. Once this method is called, no operations will complete.
        /// </summary>
        /// <remarks>
        /// <para>This method provides the fastest way to reclaim socket resources; however, its use is not generally recommended; <see cref="Close"/> should usually be used instead of this method.</para>
        /// </remarks>
        void AbortiveClose();

        #endregion
    }

    // The standard way of translating an IAsyncResult-based notification to event-based notification is as follows:
    //   1) Define the end-user event to fire, e.g.:
    //      public Action<AsyncResultEventArgs<int>> ReadCompleted { get; set; }
    //   2) Define a (private) method that just invokes the end-user event, e.g.:
    //      // Always runs in User thread
    //      private void InvokeReadCompleted(object args)
    //      {
    //          if (ReadCompleted != null)
    //              ReadCompleted((AsyncResultEventArgs<int>)args);
    //      }
    //   3) Define a (private readonly) delegate that just wraps the Invoke method, e.g.:
    //      private readonly SendOrPostCallback InvokeReadCompleted_;
    //   4) Of course, set it during the contructor, e.g.:
    //          InvokeReadCompleted_ = new SendOrPostCallback(InvokeReadCompleted);
    //   5) Start the operation using AsyncOperation, e.g.:
    //      // Always runs in User thread
    //      public void ReadAsync(byte[] buffer, int offset, int size)
    //      {
    //          // Note: the user-defined "state" object *must* be unique!
    //          AsyncOperation oper = AsyncOperationManager.CreateOperation(state);
    //          Socket.BeginReceive(buffer, offset, size, SocketFlags.None, SocketReadComplete, oper);
    //      }
    //   6) Finally, define the completion method that captures the results of the operation and synchronizes it with the user thread, e.g.:
    //      // Always runs in ThreadPool thread
    //      private void SocketReadComplete(IAsyncResult asyncResult)
    //      {
    //          AsyncOperation oper = (AsyncOperation)asyncResult.AsyncState;
    //          try
    //          {
    //              int result = Socket.EndReceive(asyncResult);
    //              oper.PostOperationCompleted(InvokeReadCompleted_, new AsyncResultEventArgs<int>(result));
    //          }
    //          catch (Exception ex)
    //          {
    //              oper.PostOperationCompleted(InvokeReadCompleted_, new AsyncResultEventArgs<Exception>(ex));
    //          }
    //      }

    // However, this library makes it much easier:
    //   1) Define the end-user event to fire, e.g.:
    //      public Action<AsyncCompletedEventArgs> WriteCompleted { get; set; }
    //   2) Start the operation using Sync.SynchronizeAsyncCallback with Async.InvokeAndCallback, e.g.:
    //      // Always runs in User thread
    //      public void ReadAsync(byte[] buffer, int offset, int size)
    //      {
    //          Socket.BeginReceive(buffer, offset, size, SocketFlags.None, Sync.SynchronizeAsyncCallback((asyncResult) =>
    //              {
    //                  Async.InvokeAndCallback(() => Socket.EndReceive(asyncResult),
    //                      ReadCompleted, null);
    //              }), null);
    //      }
    // This approach has the advantage of a simpler implementation, especially considering that all code runs within a single thread context.

    /// <summary>
    /// Provides a wrapper around a <see cref="Socket"/>, translating the <see cref="IAsyncResult"/>-based notifications to event-based notifications,
    /// including thread synchronization. This is used for client sockets and children of server sockets.
    /// </summary>
    internal class TcpSocketImpl : IDisposable
    {
        /// <summary>
        /// The socket for this connection.
        /// </summary>
        protected Socket socket_;

        public  Socket Socket
        { 
           get { return socket_; }
        }

        /// <summary>
        /// Initializes a new socket wrapper for the given socket.
        /// </summary>
        /// <param name="socket">The socket to wrap.</param>
        // Always runs in User thread
        public TcpSocketImpl(Socket socket)
        {
            socket_ = socket;
        }

        /// <summary>
        /// Closes the underlying socket and frees the socket resources. Be sure to clear all events before calling this method!
        /// The socket will be gracefully closed in the background by the WinSock dll unless <see cref="SetAbortive"/> has been called,
        /// in which case the socket will be abortively closed and immediately freed. If the process exits shortly after calling this
        /// method, the socket will be abortively closed when the WinSock dll is unloaded.
        /// </summary>
        // Always runs in User thread
        public void Dispose()
        {
            // Do the actual close
            Socket.Close();
        }

        /// <summary>
        /// Sets a flag in the socket to indicate that the close (performed by <see cref="Dispose"/>) should be done abortively.
        /// </summary>
        // Always runs in User thread
        public void SetAbortive()
        {
            Socket.LingerState = new LingerOption(true, 0);
        }

        #region Connection properties

        /// <summary>
        /// Returns the IP address and port on this side of the connection.
        /// </summary>
        public IPEndPoint LocalEndPoint { get { return (IPEndPoint)Socket.LocalEndPoint; } }

        /// <summary>
        /// Returns the IP address and port on the remote side of the connection.
        /// </summary>
        public IPEndPoint RemoteEndPoint { get { return (IPEndPoint)Socket.RemoteEndPoint; } }

        /// <summary>
        /// True if the Nagle algorithm has been disabled. The default is false. Generally, this should be left to its default value.
        /// </summary>
        public bool NoDelay { get { return Socket.NoDelay; } set { Socket.NoDelay = value; } }

        /// <summary>
        /// If and how long the a graceful shutdown will be performed in the background. Setting LingerState to enabled with a 0 timeout will make all calls
        /// to Close act as though AbortiveClose was called. Generally, this should be left to its default value.
        /// </summary>
        public LingerOption LingerState { get { return Socket.LingerState; } set { Socket.LingerState = value; } }

        #endregion

        #region Write operation

        protected Action<AsyncCompletedEventArgs> writeCompleted_;
        /// <summary>
        /// Delegate to invoke when the write operation completes.
        /// </summary>
        public Action<AsyncCompletedEventArgs> WriteCompleted { get { return writeCompleted_; } set { writeCompleted_ = value; } }

        /// <summary>
        /// Calls <see cref="WriteCompleted"/> if necessary.
        /// </summary>
        /// <param name="args">The arguments to pass to <see cref="WriteCompleted"/>.</param>
        private void OnWriteCompleted(AsyncCompletedEventArgs args)
        {
            // If there's no error and the user state is CallbackOnErrorsOnly, then don't issue the callback
            if (args.Error == null && args.UserState is CallbackOnErrorsOnly)
                return;
            if (WriteCompleted != null)
                WriteCompleted(args);
        }

        /// <summary>
        /// Initiates a write operation on the socket. The operation will be completed via <see cref="WriteCompleted"/>.
        /// </summary>
        /// <param name="buffer">Buffer containing the data to write.</param>
        /// <param name="offset">Offset in <paramref name="buffer"/> where the data begins.</param>
        /// <param name="size">Size of the data.</param>
        /// <param name="state">User-defined state object. May be null.</param>
        // Always runs in User thread
        public void WriteAsync(byte[] buffer, int offset, int size, object state)
        {
           Socket.BeginSend(buffer, offset, size, SocketFlags.None, 
               Sync.SynchronizeAsyncCallback(delegate(IAsyncResult asyncResult){
                    Sync.InvokeAndCallback(delegate(){
                        Socket.EndSend(asyncResult);
                    }, OnWriteCompleted, asyncResult.AsyncState);
                }), state);
        }

        /// <summary>
        /// Initiates a synchronous write operation on the socket. The operation will be completed via <see cref="WriteCompleted"/>.
        /// </summary>
        /// <param name="buffer">Buffer containing the data to write.</param>
        /// <param name="size">Size of the data.</param
        // Always runs in User thread
        public void WriteSync(Byte[] buffer, Int32 offset, Int32 size)
        {
            try
            {
                Int32 bytesSent = Socket.Send(buffer, offset, size, SocketFlags.None);
                OnWriteCompleted(new AsyncResultEventArgs<Int32>(bytesSent, null, false, null));
            }
            catch (Exception ex)
            {
                OnWriteCompleted(new AsyncResultEventArgs<Exception>(ex, ex, false, null));
            }
        }

        #endregion

        #region Read operation

        protected Action<AsyncResultEventArgs<int>> readCompleted_;
        /// <summary>
        /// Delegate to invoke when the read operation completes.
        /// </summary>
        public Action<AsyncResultEventArgs<int>> ReadCompleted { get { return readCompleted_; } set { readCompleted_ = value; } }

        /// <summary>
        /// Initiates a read operation on the socket. The operation will be completed via <see cref="ReadCompleted"/>.
        /// </summary>
        /// <param name="buffer">Buffer to read the data into.</param>
        /// <param name="offset">Offset in <paramref name="buffer"/> to store the data.</param>
        /// <param name="size">Maximum amount of data to receive in this read operation.</param>
        // Always runs in User thread
        public void ReadAsync(byte[] buffer, int offset, int size)
        {
            Socket.BeginReceive(buffer, offset, size, SocketFlags.None, Sync.SynchronizeAsyncCallback(delegate(IAsyncResult asyncResult)
            {
                Sync.InvokeAndCallback(delegate()
                {
                    return Socket.EndReceive(asyncResult);
                }, ReadCompleted, null);
            }), null);
        }

        #endregion

        #region Shutdown operation

        protected  Action<AsyncCompletedEventArgs> shutdownCompleted_;
        /// <summary>
        /// Delegate to invoke when the shutdown operation completes.
        /// </summary>
        public Action<AsyncCompletedEventArgs> ShutdownCompleted { get { return shutdownCompleted_; } set { shutdownCompleted_ = value; } }

        /// <summary>
        /// Initiates a shutdown operation on the socket. The operation will be completed via <see cref="ShutdownCompleted"/>.
        /// </summary>
        // Always runs in User thread
        public void ShutdownAsync()
        {
            Socket.BeginDisconnect(false, Sync.SynchronizeAsyncCallback(delegate(IAsyncResult asyncResult)
            {
                Sync.InvokeAndCallback(delegate()
                {
                    Socket.EndDisconnect(asyncResult);
                }, ShutdownCompleted, null);
            }), null);
        }

        #endregion
    }

    /// <summary>
    /// Provides a wrapper around a <see cref="Socket"/>, translating the <see cref="IAsyncResult"/>-based notifications to event-based notifications,
    /// including thread synchronization. This is used for client sockets.
    /// </summary>
    internal sealed class ClientTcpSocketImpl : TcpSocketImpl
    {
        /// <summary>
        /// Initializes a new client socket wrapper.
        /// </summary>
        // Always runs in User thread
        public ClientTcpSocketImpl()
            : base(new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
        {
        }

        #region Socket methods

        /// <summary>
        /// Binds to a local endpoint. This method is not normally used.
        /// </summary>
        /// <param name="bindTo">The local endpoint.</param>
        public void Bind(IPEndPoint bindTo)
        {
            Socket.Bind(bindTo);
        }

        #endregion

        #region Connect operation

        private Action<AsyncCompletedEventArgs> connectCompleted_;
        /// <summary>
        /// Delegate to invoke when the connect operation completes.
        /// </summary>
        public Action<AsyncCompletedEventArgs> ConnectCompleted { get { return connectCompleted_; } set { connectCompleted_ = value; } }

        /// <summary>
        /// Initiates a connect operation on the socket. The operation will be completed via <see cref="ConnectCompleted"/>.
        /// </summary>
        // Always runs in User thread
        public void ConnectAsync(IPEndPoint server)
        {
            Socket.BeginConnect(server, Sync.SynchronizeAsyncCallback(delegate(IAsyncResult asyncResult)
            {
                Sync.InvokeAndCallback(delegate()
                {
                    Socket.EndConnect(asyncResult);
                }, ConnectCompleted, null);
            }), null);
        }

        #endregion
    }
}
