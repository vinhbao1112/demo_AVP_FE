using System;
using System.Net;
using System.Text;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AVP.Network
{
    public class AVPIBEConnection: AVPConnection       
    {
        public AVPIBEConnection(String pIpConnectTo, Int32 pPort, Boolean bAutoStart)
            : base(pIpConnectTo, pPort, bAutoStart)
        {
            OurThreadPool.MinThreads = 1;
            OurThreadPool.MaxThreads = 1;
        }

        protected override Boolean IsResponseOfControlOrQueryCommand(String response)
        {
            const String ACK = "ACK";
            if (response.ToUpper().StartsWith(ACK))
            {
                return true;
            }
            return false;
        }

        protected override void ParseMessages(ref StringBuilder sbBuffer)
        {
            try
            {
                String strBuffer = sbBuffer.ToString();
                String[] messages = strBuffer.Split(ResponseTerminators, StringSplitOptions.None);
                if (messages.Length >= 2) // Terminators found.
                {
                    foreach (String message in messages)
                    {
                        if ((!KeepSeparator && (message.Length > 0)) || KeepSeparator)
                        {
                            foreach (String terminator in ResponseTerminators)
                            {
                                String messageArrived = String.Empty;
                                if (strBuffer.IndexOf(message + terminator) >= 0)
                                {
                                    if (KeepSeparator)
                                    {
                                        messageArrived = message + terminator;
                                    }
                                    else
                                    {
                                        messageArrived = message;
                                    }

                                    if (IsResponseOfControlOrQueryCommand(messageArrived))
                                    {
                                        PutMessage(message);
                                    }
                                    else
                                    {
                                        Fire_MessageArrivedEvent(messageArrived);
                                    }

                                    //fix parse message wrong when message is empty
                                    if(sbBuffer.ToString() != string.Empty)
                                    {
                                        if (sbBuffer.ToString().Length >= message.Length + terminator.Length)
                                        {
                                            sbBuffer.Remove(0, message.Length + terminator.Length);
                                        }
                                        else
                                        {
                                            sbBuffer.Remove(0, sbBuffer.Length);
                                        }
                                    }
                                    
                                    strBuffer = sbBuffer.ToString();
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch 
            {}
        }
    }
}
