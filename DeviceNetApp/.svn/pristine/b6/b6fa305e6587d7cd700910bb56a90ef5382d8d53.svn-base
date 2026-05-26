using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using DeviceNetApp.Lib;
using DeviceNetApp.DeviceNet;

namespace DeviceNetApp.Bussiness
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public class CommandProcessor
    {
        const String CMD_PATERN_EXP = @"^(\d+),(\d+),(-*\d+),(-*\d+),(\w+),(.*)";
        /// <author>
        /// <name>Do Xuan Dat</name>
        /// <date> 2009-12-14</date>
        /// </author>
        /// <summary>
        /// 
        /// </summary>
        /// <para></para>
        /// <returns></returns>       
        public bool ProcessCommand(string pstrRawCommand)
        {            
            if (string.IsNullOrEmpty(pstrRawCommand))
            {
                return false;
            }
            Logger.LogHandler.Debug("Received cmd: " + pstrRawCommand);
            Match mat = Regex.Match(pstrRawCommand, CMD_PATERN_EXP);
            if (mat.Success)
            {
                try
                {
                    Command cmd = new Command();
                    cmd.MacID = Int16.Parse(mat.Groups[1].Value);
                    cmd.DeviceType = (DNSDeviceType)Int32.Parse(mat.Groups[2].Value);
                    cmd.AdditionInfo1 = Int32.Parse(mat.Groups[3].Value);
                    cmd.AdditionInfo2 = Int32.Parse(mat.Groups[4].Value);
                    cmd.CommandID = mat.Groups[5].Value;
                    cmd.Value = mat.Groups[6].Value;

                    if (cmd.MacID == 0 && cmd.CommandID == "InitConfig")
                    {
                        Logger.LogHandler.Error("Received cmd: " + pstrRawCommand);
                        DeviceNetCore.Instance().ReInitialize(cmd.Value);
                    }
                    // Receive request data from AVP
                    else if (cmd.MacID == 0 && cmd.CommandID == "RequestData" && DeviceNetCore.Instance().IsDeviceNetInit)
                    {
                        DeviceNetCore.Instance().DeviceController.RequestData();
                    }
                    else if (cmd.MacID == 0 && cmd.CommandID == "ExitApp")
                    {
                        Logger.LogHandler.Error("Received cmd: " + pstrRawCommand);
                        DeviceNetCore.Instance().ReceiveExitCmd();
                    }
                    else if (cmd.MacID == 0 && cmd.CommandID == "AddConfig")
                    {
                        Logger.LogHandler.Error("Received cmd: " + pstrRawCommand);
                        DeviceNetCore.Instance().AddConfig(cmd.Value);
                    }
                    else if (DeviceNetCore.Instance().IsDeviceNetInit)
                    {
                        DeviceNetCore.Instance().DeviceController.DoCommand(cmd);
                    }
                }
                catch (System.Exception ex)
                {
                    Logger.LogHandler.Error("ProcessCommand: " + ex.Message);
                }
            }
            else
            {
                Logger.LogHandler.Error("Invalid command:" + pstrRawCommand);
            }
            return true;
        }                
    }

    public class Command
    {
        private Int16 m_iMacID = 0;
        private DNSDeviceType m_eType = DNSDeviceType.Undefined;
        private Int32 m_iAdditionInfo1 = -1;
        private Int32 m_iAdditionInfo2 = -1;
        private String m_strCommand = string.Empty;
        private String m_strValue = string.Empty;

        public Int16 MacID
        {
            get { return m_iMacID; }
            set { m_iMacID = value; }
        }

        public DNSDeviceType DeviceType
        {
            get { return m_eType; }
            set { m_eType = value; }
        }

        public Int32 AdditionInfo1
        {
            get { return m_iAdditionInfo1; }
            set { m_iAdditionInfo1 = value; }
        }

        public Int32 AdditionInfo2
        {
            get { return m_iAdditionInfo2; }
            set { m_iAdditionInfo2 = value; }
        }

        public String CommandID
        {
            get { return m_strCommand; }
            set { m_strCommand = value; }
        }

        public String Value
        {
            get { return m_strValue; }
            set { m_strValue = value; }
        }
    }
}
