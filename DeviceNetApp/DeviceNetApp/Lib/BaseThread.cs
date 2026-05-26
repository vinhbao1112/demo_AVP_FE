using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace DeviceNetApp.Lib
{

    public enum CondResult
    {
        Error = -1,
        False = 0,
        True = 1
    }

    public delegate CondResult Condition(params Object[] arguments);



    public delegate void RunningMethodDelegate();
    public class BaseThread : SuspendableThread, IDisposable
    {
        // Fields
        private String m_strWhoAmI;
        private Boolean m_blDisposed = false;
        private Boolean m_blStarted = false;
        private RunningMethodDelegate m_ExecMethod = null;

        // Methods
        public BaseThread(String pstrWhoAmI)
        {
            if (pstrWhoAmI != null)
            {
                m_strWhoAmI = pstrWhoAmI;
                if (m_strWhoAmI.Length == 0)
                {
                    m_strWhoAmI = "BaseThread";
                }
            }
        }

        // Methods
        public BaseThread(String pstrWhoAmI, RunningMethodDelegate p_ExecMethod)
        {
            if (pstrWhoAmI != null)
            {
                m_strWhoAmI = pstrWhoAmI;
                if (m_strWhoAmI.Length == 0)
                {
                    m_strWhoAmI = "BaseThread";
                }
            }
            m_ExecMethod = p_ExecMethod;
        }

        public void Dispose()
        {
            Logger.LogHandler.Debug(m_strWhoAmI + " is being disposed.");
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            const Int32 FirstJoinTime = 1000;
            const Int32 SecondJoinTime = 5000;
            if (!m_blDisposed)
            {
                Terminate();
                try
                {
                    if (!Join(FirstJoinTime))
                    {
                        String name = ThreadName;
                        // if (!HasTerminateRequest())
                        {
                            Logger.LogHandler.Error(" found the thread " + name + " alive, try Interrupt now");
                            Interrupt();
                        }
                        if (!Join(FirstJoinTime))
                        {
                            // if (!HasTerminateRequest())
                            {
                                Logger.LogHandler.Error(" failed to join the thread " + name + ", try Abort now");
                                Abort();
                            }
                            if (!Join(SecondJoinTime))
                            {
                                Logger.LogHandler.Error(" failed to join the thread " + name + " again, try Sleep till it dies");
                                Join();
                            }
                        }
                    }
                }
                catch (ObjectDisposedException ex) { 
                    Logger.LogHandler.Error(ex.Message); 
                }
                catch (Exception ex)
                {
                    Logger.LogHandler.Error(ex.Message);
                }

                m_blStarted = false;
                m_blDisposed = true;
            }
        }

        ~BaseThread()
        {
            Debug.Fail("You forgot to Dispose this instance: " + m_strWhoAmI);
            Dispose(false);
        }

        protected override void OnDoWork()
        {
            m_blStarted = true;
            String name = Thread.CurrentThread.Name;
            Logger.LogHandler.Debug("Starting the thread " + name + " for the component " + m_strWhoAmI);
            try
            {
                if (m_ExecMethod != null)
                {
                    m_ExecMethod();
                }
                else
                {
                    ThreadMainRoutine();
                }
            }
            finally
            {
                m_blStarted = false;
            }
            Logger.LogHandler.Debug("The thread " + name + " ended"); 
        }
      
        // Override these methods in derive classes.-----------------------------------------------------
        protected virtual void ThreadMainRoutine()
        {
            throw new Exception("The method or operation is not implemented.");

            //try
            //{
            //    while (false == HasTerminateRequest())
            //    {
            //        Boolean awokenByTerminate = SuspendIfNeeded();
            //        if (awokenByTerminate)
            //        {
            //            return;
            //        }
            //        // TODO: replace the following to lines
            //        Debug.WriteLine("doing some work...");
            //        Thread.Sleep(450);
            //    }
            //}
            //finally
            //{
            //    // TODO: Replace the following line with thread
            //    // exit processing.
            //    Debug.WriteLine("Exiting ThreadEntry()...");
            //}
        }
        //-----------------------------------------------------------------------------------------------

        // Call this function and wait for it stops completely.
        public Boolean Stop()
        {
            if (m_blStarted)
            {
                TerminateAndWait();
            }
            return true;
        }

        public Boolean Run()
        {
            if (!m_blStarted)
            {
                Start();
                return true;
            }
            return false;
        }

        public Boolean IsStoping()
        {
            return HasTerminateRequest();
        }

        public Boolean IsStoping(Int32 milliseconds)
        {
            return HasTerminateRequest(milliseconds);
        }

        /// <summary>
        /// Thread is stopped or not
        /// </summary>
        /// <returns></returns>
        public Boolean IsStopped()
        {
            return (false == m_blStarted);
        }
    }
}
