using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;

namespace AVP.Network
{
    public delegate void Action();

    public delegate void Action<TArg1, TArg2>(TArg1 arg1, TArg2 arg2);

    public delegate void Action<TArg1, TArg2, TArg3>(TArg1 arg1, TArg2 arg2, TArg3 arg3);

    public delegate void Action<TArg1, TArg2, TArg3, TArg4>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4);

    public delegate T Func<T>();

    public delegate TReturn Func<TArg1, TReturn>(TArg1 arg1);

    public delegate TReturn Func<TArg1, TArg2, TReturn>(TArg1 arg1, TArg2 arg2);

    public delegate TReturn Func<TArg1, TArg2, TArg3, TReturn>(TArg1 arg1, TArg2 arg2, TArg3 arg3);

    /// <summary>
    /// Provides data for the asynchronous event handlers that have one result.
    /// </summary>
    /// <typeparam name="T">The type of the result of the asynchronous operation.</typeparam>
    public class AsyncResultEventArgs<T> : AsyncCompletedEventArgs
    {
        /// <summary>
        /// The result of the asynchronous operation.
        /// </summary>
        private T result;

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncResultEventArgs{T}"/> class.
        /// </summary>
        /// <param name="result">The result of the asynchronous operation.</param>
        /// <param name="error">Any error that occurred. Null if no error.</param>
        /// <param name="cancelled">Whether the operation was cancelled.</param>
        /// <param name="userState">The optional user-defined state object.</param>
        public AsyncResultEventArgs(T result, Exception error, bool cancelled, object userState)
            : base(error, cancelled, userState)
        {
            this.result = result;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncResultEventArgs{T}"/> class indicating a successful completion.
        /// </summary>
        /// <param name="result">The result of the asynchronous operation.</param>
        public AsyncResultEventArgs(T result)
            : this(result, null, false, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncResultEventArgs{T}"/> class indicating an unsuccessful operation.
        /// </summary>
        /// <param name="error">The error that occurred.</param>
        public AsyncResultEventArgs(Exception error)
            : this(default(T), error, false, null)
        {
        }

        /// <summary>
        /// Gets the result of the asynchronous operation. This property may only be read if <see cref="AsyncCompletedEventArgs.Error"/> is null.
        /// </summary>
        public T Result
        {
            get
            {
                RaiseExceptionIfNecessary();
                return this.result;
            }
        }
    }

    /// <summary>
    /// Flags that identify differences in behavior in various <see cref="SynchronizationContext"/> implementations.
    /// </summary>
    [Flags]
    public enum SynchronizationContextProperties
    {
        /// <summary>
        /// The <see cref="SynchronizationContext"/> makes no guarantees about any of the properties in <see cref="SynchronizationContextProperties"/>.
        /// </summary>
        None = 0x0,

        /// <summary>
        /// <see cref="SynchronizationContext.Post"/> is guaranteed to be non-reentrant (if called from a thread that is not the <see cref="SynchronizationContext"/>'s specific associated thread, if any).
        /// </summary>
        NonReentrantPost = 0x1,

        /// <summary>
        /// <see cref="SynchronizationContext.Send"/> is guaranteed to be non-reentrant (if called from a thread that is not the <see cref="SynchronizationContext"/>'s specific associated thread, if any).
        /// </summary>
        NonReentrantSend = 0x2,

        /// <summary>
        /// Delegates queued to the <see cref="SynchronizationContext"/> are guaranteed to execute one at a time.
        /// </summary>
        Synchronized = 0x4,

        /// <summary>
        /// Delegates queued to the <see cref="SynchronizationContext"/> are guaranteed to execute in order. Any <see cref="SynchronizationContext"/> claiming to be <see cref="Sequential"/> should also claim to be <see cref="Synchronized"/>.
        /// </summary>
        Sequential = 0x8,

        /// <summary>
        /// The <see cref="SynchronizationContext"/> has exactly one managed thread associated with it. Any <see cref="SynchronizationContext"/> specifying <see cref="SpecificAssociatedThread"/> should also specify <see cref="Synchronized"/>.
        /// </summary>
        SpecificAssociatedThread = 0x10,

        /// <summary>
        /// The <see cref="SynchronizationContext"/> makes the standard guarantees (<see cref="NonReentrantPost"/>, <see cref="NonReentrantSend"/>, <see cref="Synchronized"/>, <see cref="Sequential"/>, and <see cref="SpecificAssociatedThread"/>). This is defined as a constant because most custom synchronization contexts do make these guarantees.
        /// </summary>
        Standard = NonReentrantPost | NonReentrantSend | Synchronized | Sequential | SpecificAssociatedThread,
    }

    /// <summary>
    /// A global register of <see cref="SynchronizationContextProperties"/> flags for <see cref="SynchronizationContext"/> types.
    /// </summary>
    public static class SynchronizationContextRegister
    {
        /// <summary>
        /// A mapping from synchronization context type names to their properties. We map from type names instead of actual types to avoid dependencies on unnecessary assemblies.
        /// </summary>
        private static Dictionary<string, SynchronizationContextProperties> synchronizationContextProperties = PredefinedSynchronizationContextProperties();

        /// <summary>
        /// Registers a <see cref="SynchronizationContext"/> type claiming to provide certain guarantees.
        /// </summary>
        /// <param name="synchronizationContextType">The type derived from <see cref="SynchronizationContext"/>.</param>
        /// <param name="properties">The guarantees provided by this type.</param>
        /// <remarks>
        /// <para>This method should be called once for each type of <see cref="SynchronizationContext"/>. It is not necessary to call this method for .NET <see cref="SynchronizationContext"/> types or <see cref="ActionDispatcherSynchronizationContext"/>.</para>
        /// <para>If this method is called more than once for a type, the new value of <paramref name="properties"/> replaces the old value. The flags are not merged.</para>
        /// </remarks>
        public static void Register(Type synchronizationContextType, SynchronizationContextProperties properties)
        {
            lock (synchronizationContextProperties)
            {
                if (synchronizationContextProperties.ContainsKey(synchronizationContextType.FullName))
                {
                    synchronizationContextProperties[synchronizationContextType.FullName] = properties;
                }
                else
                {
                    synchronizationContextProperties.Add(synchronizationContextType.FullName, properties);
                }
            }
        }

        /// <summary>
        /// Looks up the guarantees for a <see cref="SynchronizationContext"/> type.
        /// </summary>
        /// <param name="synchronizationContextType">The type derived from <see cref="SynchronizationContext"/> to test.</param>
        /// <returns>The properties guaranteed by <paramref name="synchronizationContextType"/>.</returns>
        public static SynchronizationContextProperties Lookup(Type synchronizationContextType)
        {
            lock (synchronizationContextProperties)
            {
                SynchronizationContextProperties supported = SynchronizationContextProperties.None;
                if (synchronizationContextProperties.ContainsKey(synchronizationContextType.FullName))
                {
                    supported = synchronizationContextProperties[synchronizationContextType.FullName];
                }

                return supported;
            }
        }

        /// <summary>
        /// Verifies that a <see cref="SynchronizationContext"/> satisfies the guarantees required by the calling code.
        /// </summary>
        /// <param name="synchronizationContextType">The type derived from <see cref="SynchronizationContext"/> to test.</param>
        /// <param name="properties">The guarantees required by the calling code.</param>
        public static void Verify(Type synchronizationContextType, SynchronizationContextProperties properties)
        {
            SynchronizationContextProperties supported = Lookup(synchronizationContextType);
            if ((supported & properties) != properties)
            {
                throw new InvalidOperationException("This asynchronous object cannot be used with this SynchronizationContext");
            }
        }

        /// <summary>
        /// Verifies that <see cref="SynchronizationContext.Current"/> satisfies the guarantees required by the calling code.
        /// </summary>
        /// <param name="properties">The guarantees required by the calling code.</param>
        public static void Verify(SynchronizationContextProperties properties)
        {
            if (SynchronizationContext.Current == null)
            {
                Verify(typeof(SynchronizationContext), properties);
            }
            else
            {
                Verify(SynchronizationContext.Current.GetType(), properties);
            }
        }

        /// <summary>
        /// Returns the mapping for all predefined (.NET) <see cref="SynchronizationContext"/> types.
        /// </summary>
        /// <returns>The mapping for all predefined (.NET) <see cref="SynchronizationContext"/> types.</returns>
        private static Dictionary<string, SynchronizationContextProperties> PredefinedSynchronizationContextProperties()
        {
            Dictionary<string, SynchronizationContextProperties> ret = new Dictionary<string, SynchronizationContextProperties>();
            ret.Add("System.Threading.SynchronizationContext", SynchronizationContextProperties.NonReentrantPost);
            ret.Add("System.Windows.Forms.WindowsFormsSynchronizationContext", SynchronizationContextProperties.Standard);
            ret.Add("System.Windows.Threading.DispatcherSynchronizationContext", SynchronizationContextProperties.Standard);

            // AspNetSynchronizationContext does not provide any guarantees at all, so it is not added here
            return ret;
        }
    }

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

    /// <summary>
    /// Delegate for handling exceptions.
    /// </summary>
    public delegate void ExceptionHandler(object sender, Exception e);

    #region Delegates from CustomThreadPool
    /// <summary>
    /// Delegate for handling exceptions thrown by work items executing
    /// in a custom thread pool.
    /// </summary>
    /// <param name="pool">The pool which created the worker thread</param>
    /// <param name="workItem">The work item which threw the exception</param>
    /// <param name="e">The exception thrown</param>
    /// <param name="handled">
    /// Whether or not the exception has been handled by this delegate. The value
    /// of this parameter will be false on entry, and changing it to true will
    /// prevent any further delegates in the event from being executed.
    /// </param>
    public delegate void ThreadPoolExceptionHandler(CustomThreadPool pool,
                                                     ThreadPoolWorkItem workItem,
                                                     Exception e,
                                                     ref bool handled);

    /// <summary>
    /// Delegate for handling the event that a thread is about to execute
    /// a work item.
    /// </summary>
    /// <param name="pool">The pool which created the worker thread</param>
    /// <param name="workItem">The work item which is about to execute</param>
    /// <param name="cancel">
    /// Whether or not the work item should be cancelled. The value
    /// of this parameter will be false on entry, and changing it to true will
    /// prevent any further delegates in the event from being executed, and
    /// prevent the work item itself from being executed.
    /// </param>
    public delegate void BeforeWorkItemHandler(CustomThreadPool pool,
                                                ThreadPoolWorkItem workItem,
                                                ref bool cancel);

    /// <summary>
    /// Delegate for handling the event that a thread has executed a work item.
    /// </summary>
    /// <param name="pool">The pool which created the worker thread</param>
    /// <param name="workItem">The work item which has executed</param>
    public delegate void AfterWorkItemHandler(CustomThreadPool pool,
                                               ThreadPoolWorkItem workItem);
    #endregion

    /// <summary>
    /// Delegate for handling the event that a thread has changed state
    /// (e.g. it's about to execute a work item, it's just executed one, etc).
    /// Also used for requests for a thread to change state (e.g. if a stop
    /// request has been received).
    /// </summary>
    public delegate void ThreadProgress(object sender);

    /// <summary>
    /// Utility to build an IComparer implementation from a Comparison delegate,
    /// and a static method to do the reverse.
    /// </summary>
    public sealed class ComparisonComparer<T> : IComparer<T>
    {
        readonly Comparison<T> comparison;

        /// <summary>
        /// Creates a new instance which will proxy to the given Comparison
        /// delegate when called.
        /// </summary>
        /// <param name="comparison">Comparison delegate to proxy to. Must not be null.</param>
        public ComparisonComparer(Comparison<T> comparison)
        {
            if (comparison == null)
            {
                throw new ArgumentNullException("comparison");
            }
            this.comparison = comparison;
        }

        /// <summary>
        /// Implementation of IComparer.Compare which simply proxies
        /// to the originally specified Comparison delegate.
        /// </summary>
        public int Compare(T x, T y)
        {
            return comparison(x, y);
        }

        /// <summary>
        /// Creates a Comparison delegate from the given Comparer.
        /// </summary>
        /// <param name="comparer">Comparer to use when the returned delegate is called. Must not be null.</param>
        /// <returns>A Comparison delegate which proxies to the given Comparer.</returns>
        public static Comparison<T> CreateComparison(IComparer<T> comparer)
        {
            if (comparer == null)
            {
                throw new ArgumentNullException("comparer");
            }
            return delegate(T x, T y) { return comparer.Compare(x, y); };
        }
    }
}
