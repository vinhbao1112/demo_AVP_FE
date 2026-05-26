using System;
using System.Threading;

namespace DeviceNetApp.Lib
{
    public abstract class SuspendableThread
    {
        #region Data
        public const String INVALID_NAME = "Unknown";
        private ManualResetEvent _suspendChangedEvent = new ManualResetEvent(false);
        protected ManualResetEvent _terminateEvent = new ManualResetEvent(false);
        private Int64 _suspended;
        private Thread _thread;
        private System.Threading.ThreadState _failsafeThreadState = System.Threading.ThreadState.Unstarted;
        private String _failsafeThreadName = INVALID_NAME;

        #endregion Data

        private void Initialize()
        {
            _failsafeThreadState = System.Threading.ThreadState.Stopped;
            _suspended = 0;
            _terminateEvent.Reset();
            _suspendChangedEvent.Reset();
        }

        private void ThreadEntry()
        {
            OnDoWork();
        }

        protected abstract void OnDoWork();

        #region Protected methods

        // This thread sleeps in millisecondsSleepTime, and return true if there is a terminate request.
        protected Boolean SleepButAlertabletoTerminateRequest(Int32 millisecondsSleepTime) 
        {
            return (0 == WaitHandle.WaitAny(new WaitHandle[] { _terminateEvent }, millisecondsSleepTime, false));
        }

        public Boolean SuspendIfNeeded()
        {
            Boolean suspendEventChanged = _suspendChangedEvent.WaitOne(0, true);
            if (suspendEventChanged)
            {
                _suspendChangedEvent.Reset();
                Boolean needToSuspend = Interlocked.Read(ref _suspended) != 0;
                if (needToSuspend)
                {
                    /// Suspending...
                    if (1 == WaitHandle.WaitAny(new WaitHandle[] { _suspendChangedEvent, _terminateEvent }))
                    {
                        return true;
                    }
                    /// ...Waking
                }
            }
            return false;
        }

        public Boolean HasSuspendRequest()
        {
           return Interlocked.Read(ref _suspended) != 0;
        }

        public Boolean IsActuallyPaused()
        {
            return (Interlocked.Read(ref _suspended) != 0) && (ThreadState.WaitSleepJoin == ThreadState);
        }

        public Boolean HasTerminateRequest()
        {
            bool bRes = true;
            try
            {
                bRes = _terminateEvent.WaitOne(0, true);
            }
            catch (Exception ex)
            {
                Logger.LogHandler.Error(ex.Message);
            }
            return bRes;
        }

        public void ResetTerminateEvent()
        {
            _terminateEvent.Reset();
        }

        protected Boolean HasTerminateRequest(Int32 milliseconds)
        {
            bool bRes = true;
            try
            {
                bRes = _terminateEvent.WaitOne(milliseconds, true);
            }
            catch (Exception ex)
            {
                Logger.LogHandler.Error(ex.Message);
            }
            return bRes;
        }

        #endregion Protected methods

        public void Start()
        {
            Initialize();
            _thread = new Thread(new ThreadStart(ThreadEntry));
            // make sure this thread won't be automaticaly
            // terminated by the runtime when the
            // application exits
            _thread.IsBackground = false;
            _thread.Start();
        }

        public void Join()
        {
            if (_thread != null)
            {
                _thread.Join();
            }
        }

        // Something wrong happens when resorting to using this method.
        protected void Abort()
        {
            if (_thread != null)
            {
                _thread.Abort();
            }
        }

        protected void Interrupt()
        {
            if (_thread != null)
            {
                _thread.Interrupt();
            }
        }

        public Boolean Join(Int32 milliseconds)
        {
            if (_thread != null)
            {
                return _thread.Join(milliseconds);
            }
            return true;
        }

        public Boolean Join(TimeSpan timeSpan)
        {
            if (_thread != null)
            {
                return _thread.Join(timeSpan);
            }
            return true;
        }

        public void Terminate()
        {
            _terminateEvent.Set();
        }

        public void TerminateAndWait()
        {
            _terminateEvent.Set();
            _thread.Join();
        }

        public void Suspend()
        {
            while (1 != Interlocked.Exchange(ref _suspended, 1))
            {
            }
            _suspendChangedEvent.Set();
        }

        public void Resume()
        {
            while (0 != Interlocked.Exchange(ref _suspended, 0))
            {
            }
            _suspendChangedEvent.Set();
        }

        public System.Threading.ThreadState ThreadState
        {
            get
            {
                if (null != _thread)
                {
                    return _thread.ThreadState;
                }
                return _failsafeThreadState;
            }
        }

        public String ThreadName
        {
            get
            {
                if (null != _thread)
                {
                    return _thread.Name;
                }
                return _failsafeThreadName;
            }
        }
    }
}
