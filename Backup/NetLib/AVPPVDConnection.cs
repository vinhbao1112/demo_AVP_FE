using System;
using System.Net;
using System.Text;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AVP.Network
{
    public class AVPPVDConnection : AVPConnection
    {
        public AVPPVDConnection(String pIpConnectTo, Int32 pPort, Boolean bAutoStart)
            : base(pIpConnectTo, pPort, bAutoStart)
           {     
               }
        protected override void ParseMessages(ref StringBuilder sbBuffer)
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

                                sbBuffer.Remove(0, message.Length + terminator.Length);
                                strBuffer = sbBuffer.ToString();
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
