using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using log4net;
using System.Globalization;

// Configure log4net using the .config file
[assembly: log4net.Config.XmlConfigurator(Watch = false)]

namespace AVPSecsGemLib
{
    // Handle general application logging messages. 
    public class AVPSecsGemLog
    {
        #region "Logger Constant"
        private const string LOGGER_AVPSECSGEM = "AVP.AVPSECSGEM";

        public static ILog avpSecsGemLogger = null;

        #endregion

        #region "Logger"
        /// <author>
        ///    	<name> Dat Do Xuan </name>
        ///    	<date> 2009-3-17</date>
        /// </author>
        /// <summary>
        /// init logger variables
        /// </summary>
        /// <remarks></remarks>
        public static void initialize()
        {
            try
            {
                // Logger name is AVP
                avpSecsGemLogger = LogManager.GetLogger(LOGGER_AVPSECSGEM);
            }
            catch
            {
                // need to debug if the system crash in the logger side
            }
        }
        /// <author>
        ///    	<name> Dat Do Xuan </name>
        ///    	<date> 2009-3-17</date>
        /// </author>
        /// <summary>
        /// init logger variables
        /// </summary>
        /// <remarks></remarks>
        public static void shutdown()
        {
            try
            {
                LogManager.Shutdown();
            }
            catch 
            {
                // need to debug if the system crash in the logger side
            }
        }
        #endregion
    }
       
}
