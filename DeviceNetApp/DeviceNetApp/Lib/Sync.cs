using System;
using System.ComponentModel;
using System.Threading;

namespace DeviceNetApp.Lib
{
    /// <summary>
    /// Provides utility methods for implementing asynchronous operations.
    /// </summary>
    public static partial class Sync
    {
        /// <summary>
        /// Returns an <see cref="Action"/> that asynchronously executes in the <see cref="SynchronizationContext"/> of the thread that called this method.
        /// </summary>
        /// <param name="callback">The callback to wrap.</param>
        /// <returns>A synchronized callback.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
        public static Action SynchronizeAction(Action callback)
        {
            // Create the operation, capturing the current thread's synchronization context
            AsyncOperation operation = AsyncOperationManager.CreateOperation(new object());

            // This delegate will be executed on another thread, probably a ThreadPool thread
            return delegate
            {
                // Synchronize the operation back to the originating thread's SynchronizationContext
                operation.PostOperationCompleted(delegate(object unusedState) { callback(); }, null);
            };
        }

        /// <summary>
        /// Returns an <see cref="Action{T}"/> that asynchronously executes in the <see cref="SynchronizationContext"/> of the thread that called this method.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to the callback.</typeparam>
        /// <param name="callback">The callback to wrap.</param>
        /// <returns>A synchronized callback.</returns>
        public static Action<T> SynchronizeAction<T>(Action<T> callback)
        {
            // Create the operation, capturing the current thread's synchronization context
            AsyncOperation operation = AsyncOperationManager.CreateOperation(new object());

            // This delegate will be executed on another thread, probably a ThreadPool thread
            return delegate(T arg)
            {
                // Synchronize the operation back to the originating thread's SynchronizationContext
                operation.PostOperationCompleted(delegate(object unusedState) { callback(arg); }, null);
            };
        }

        /// <summary>
        /// Returns an <see cref="Action{T1, T2}"/> that asynchronously executes in the <see cref="SynchronizationContext"/> of the thread that called this method.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter to the callback.</typeparam>
        /// <typeparam name="T2">The type of the second parameter to the callback.</typeparam>
        /// <param name="callback">The callback to wrap.</param>
        /// <returns>A synchronized callback.</returns>
        public static Action<T1, T2> SynchronizeAction<T1, T2>(Action<T1, T2> callback)
        {
            // Create the operation, capturing the current thread's synchronization context
            AsyncOperation operation = AsyncOperationManager.CreateOperation(new object());

            // This delegate will be executed on another thread, probably a ThreadPool thread
            return delegate(T1 arg1, T2 arg2)
            {
                // Synchronize the operation back to the originating thread's SynchronizationContext
                operation.PostOperationCompleted(delegate(object unusedState) { callback(arg1, arg2); }, null);
            };
        }

        /// <summary>
        /// Returns an <see cref="Action{T1, T2, T3}"/> that asynchronously executes in the <see cref="SynchronizationContext"/> of the thread that called this method.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter to the callback.</typeparam>
        /// <typeparam name="T2">The type of the second parameter to the callback.</typeparam>
        /// <typeparam name="T3">The type of the third parameter to the callback.</typeparam>
        /// <param name="callback">The callback to wrap.</param>
        /// <returns>A synchronized callback.</returns>
        public static Action<T1, T2, T3> SynchronizeAction<T1, T2, T3>(Action<T1, T2, T3> callback)
        {
            // Create the operation, capturing the current thread's synchronization context
            AsyncOperation operation = AsyncOperationManager.CreateOperation(new object());

            // This delegate will be executed on another thread, probably a ThreadPool thread
            return delegate(T1 arg1, T2 arg2, T3 arg3)
            {
                // Synchronize the operation back to the originating thread's SynchronizationContext
                operation.PostOperationCompleted(delegate(object unusedState) { callback(arg1, arg2, arg3); }, null);
            };
        }

        /// <summary>
        /// Returns an <see cref="Action{T1, T2, T3, T4}"/> that asynchronously executes in the <see cref="SynchronizationContext"/> of the thread that called this method.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter to the callback.</typeparam>
        /// <typeparam name="T2">The type of the second parameter to the callback.</typeparam>
        /// <typeparam name="T3">The type of the third parameter to the callback.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter to the callback.</typeparam>
        /// <param name="callback">The callback to wrap.</param>
        /// <returns>A synchronized callback.</returns>
        public static Action<T1, T2, T3, T4> SynchronizeAction<T1, T2, T3, T4>(Action<T1, T2, T3, T4> callback)
        {
            // Create the operation, capturing the current thread's synchronization context
            AsyncOperation operation = AsyncOperationManager.CreateOperation(new object());

            // This delegate will be executed on another thread, probably a ThreadPool thread
            return delegate(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
            {
                // Synchronize the operation back to the originating thread's SynchronizationContext
                operation.PostOperationCompleted(delegate(object unusedState) { callback(arg1, arg2, arg3, arg4); }, null);
            };
        }

        /// <summary>
        /// Returns an <see cref="AsyncCallback"/> that asynchronously executes in the <see cref="SynchronizationContext"/> of the thread that called this method.
        /// </summary>
        /// <param name="callback">The callback to wrap.</param>
        /// <returns>A synchronized callback.</returns>
        /// <remarks>
        /// <para>This is intended for use within a call to BeginXXX methods, e.g., <code>socket.BeginConnect(remoteEP, Sync.SynchronizeAsyncCallback(callback), state);</code></para>
        /// </remarks>
        public static AsyncCallback SynchronizeAsyncCallback(AsyncCallback callback)
        {
            // Create the operation, capturing the current thread's synchronization context
            AsyncOperation operation = AsyncOperationManager.CreateOperation(new object());

            // This delegate will be executed on another thread, probably a ThreadPool thread
            return delegate(IAsyncResult asyncResult)
            {
                // Synchronize the operation back to the originating thread's SynchronizationContext
                operation.PostOperationCompleted(delegate(object unusedState) { callback(asyncResult); }, null);
            };
        }

        /// <summary>
        /// Returns an <see cref="TimerCallback"/> that asynchronously executes in the <see cref="SynchronizationContext"/> of the thread that called this method.
        /// </summary>
        /// <param name="callback">The callback to wrap.</param>
        /// <returns>A synchronized callback.</returns>
        /// <remarks>
        /// <para>This is intended for use within a call to the <see cref="System.Threading.Timer"/> constructor, e.g., <code>new Timer(Sync.Synchronize(callback));</code></para>
        /// </remarks>
        public static TimerCallback SynchronizeTimerCallback(TimerCallback callback)
        {
            // Create the operation, capturing the current thread's synchronization context
            AsyncOperation operation = AsyncOperationManager.CreateOperation(new object());

            // This delegate will be executed on a ThreadPool thread
            return delegate(object state)
            {
                // Synchronize the operation back to the originating thread's SynchronizationContext
                operation.PostOperationCompleted(delegate(object unusedState) { callback(state); }, null);
            };
        }

        /// <summary>
        /// Returns an <see cref="WaitCallback"/> that asynchronously executes in the <see cref="SynchronizationContext"/> of the thread that called this method.
        /// </summary>
        /// <param name="callback">The callback to wrap.</param>
        /// <returns>A synchronized callback.</returns>
        public static WaitCallback SynchronizeWaitCallback(WaitCallback callback)
        {
            // Create the operation, capturing the current thread's synchronization context
            AsyncOperation operation = AsyncOperationManager.CreateOperation(new object());

            // This delegate will be executed on a ThreadPool thread
            return delegate(object state)
            {
                // Synchronize the operation back to the originating thread's SynchronizationContext
                operation.PostOperationCompleted(delegate(object unusedState) { callback(state); }, null);
            };
        }

        /// <summary>
        /// Returns an <see cref="WaitOrTimerCallback"/> that asynchronously executes in the <see cref="SynchronizationContext"/> of the thread that called this method.
        /// </summary>
        /// <param name="callback">The callback to wrap.</param>
        /// <returns>A synchronized callback.</returns>
        /// <remarks>
        /// <para>This is intended for use within a call to <see cref="ThreadPool"/>'s RegisterWaitForSingleObject methods, e.g., <code>ThreadPool.RegisterWaitForSingleObject(waitObject, Sync.SynchronizeWaitOrTimerCallback(callback), state, ...);</code></para>
        /// </remarks>
        public static WaitOrTimerCallback SynchronizeWaitOrTimerCallback(WaitOrTimerCallback callback)
        {
            // Create the operation, capturing the current thread's synchronization context
            AsyncOperation operation = AsyncOperationManager.CreateOperation(new object());

            // This delegate will be executed on a ThreadPool thread
            return delegate(object state, bool timedOut)
            {
                // Synchronize the operation back to the originating thread's SynchronizationContext
                operation.PostOperationCompleted(delegate(object unusedState) { callback(state, timedOut); }, null);
            };
        }

        /// <summary>
        /// Runs <paramref name="action"/> followed by <paramref name="callback"/> with arguments indicating success. If <paramref name="action"/>
        /// raises an exception, <paramref name="callback"/> is invoked with arguments indicating the error.
        /// </summary>
        /// <param name="action">The action to perform.</param>
        /// <param name="callback">The callback to indicate success or error.</param>
        /// <param name="state">The user state to include in the arguments to the callback. May be null.</param>
        /// <remarks>
        /// <para>This method does not support argments indicating cancellation.</para>
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static void InvokeAndCallback(Action action, Action<AsyncCompletedEventArgs> callback, object state)
        {
            try
            {
                action();
                if (callback != null)
                {
                    callback(new AsyncCompletedEventArgs(null, false, state));
                }
            }
            catch (Exception ex)
            {
                if (callback != null)
                {
                    callback(new AsyncCompletedEventArgs(ex, false, state));
                }
            }
        }


        /// <summary>
        /// Runs <paramref name="action"/> followed by <paramref name="callback"/> with arguments indicating success,
        /// including its return value. If <paramref name="action"/> raises an exception, <paramref name="callback"/>
        /// is invoked with arguments indicating the error.
        /// </summary>
        /// <typeparam name="T">The type of the result of the action.</typeparam>
        /// <param name="action">The action to perform.</param>
        /// <param name="callback">The callback to indicate success or error.</param>
        /// <param name="state">The user state to include in the arguments to the callback. May be null.</param>
        /// <remarks>
        /// <para>This method does not support argments indicating cancellation.</para>
        /// </remarks>
        public static void InvokeAndCallback<T>(Func<T> func, Action<AsyncResultEventArgs<T>> callback, object state)
        {
            try
            {
                T result = func();
                if (callback != null)
                {
                    callback(new AsyncResultEventArgs<T>(result, null, false, state));
                }
            }
            catch (Exception ex)
            {
                if (callback != null)
                {
                    callback(new AsyncResultEventArgs<T>(default(T), ex, false, state));
                }
            }
        }
    }
}
