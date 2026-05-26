using System;
using System.Collections.Generic;
using System.Text;
using log4net;

[assembly: log4net.Config.XmlConfigurator(Watch = false)]
namespace DeviceNetApp.Lib
{
    public class Logger
    {
        static ILog _log = null;


        public static Boolean StaticInitialize()
        {
            _log = LogManager.GetLogger(Constants.DEVICENET_LOG);          

            return true;
        }

        static public ILog LogHandler
        {
            get { return _log; }
            set { _log = value; }
        }

        static public void Debug(string strMsg)
        {
            if (_log != null)
            {
                _log.Debug(strMsg);
            }
        }

        static public void Info(string strMsg)
        {
            if (_log != null)
            {
                _log.Info(strMsg);
            }
        }

        static public void Error(string strMsg)
        {
            if (_log != null)
            {
                _log.Error(strMsg);
            }
        }

        static public void ErrorFormat(string strMsg, params object[] args)
        {
            if (_log != null)
            {
                _log.ErrorFormat(strMsg, args);
            }
        }

        public static void Uninitialize()
        {
            LogManager.Shutdown();
        }
    }
}
