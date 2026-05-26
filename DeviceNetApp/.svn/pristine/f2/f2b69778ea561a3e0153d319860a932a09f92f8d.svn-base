using System;
using System.Collections.Generic;
using System.Text;
using DeviceNetApp.Lib;

namespace DeviceNetApp.DeviceNet
{
    class DNSIonGaugeITR100D : DNSGenericIonGauge
    {
        public DNSIonGaugeITR100D(DNSScanner objMaster, UInt16 nMacId)
            : base(objMaster, nMacId)
        {
            m_arrPressVal = new Byte[6];
        }

        /// <summary>
        /// The current step to process sending explicit message
        /// </summary>   
        private Int32 explicitSendingMessageStep = 0;

        /// <summary>
        /// Expected Turn IG On/Off
        /// </summary>
        private Boolean isExpectedTurnIGOn = false;

        /// <summary>
        /// Expected Turn IG Degas On/Off
        /// </summary>
        private Boolean isExpectedTurnIGDegasOn = false;

        /// <summary>
        /// Init Ion Gauge Component
        /// </summary>
        /// <param name="CardHandle"></param>
        /// <param name="DeviceId"></param>
        /// <returns></returns>
        public override Boolean Intialize()
        {
            // InputSize and OutputSize are not allow IO polling 
            // and only doing action with explicit message
            return RegisterEquipment(m_objMaster.CardHandle, m_nMacId, 0, 0, 64);
        }

        /// <summary>
        /// Read Pressure Value
        /// </summary>
        public override void ReadValue()
        {
            try
            {
                if (m_ExplicitState == enExplicitState.explicitIdle)
                {
                    // Step to turn on/off IG
                    switch (explicitSendingMessageStep)
                    {
                        case 0:
                            // Get IG Pressure Readback
                            m_iExplicitMsgSize = 2;
                            m_ExplicitData[0] = 1; // Attribute ID 1 (0x01)
                            m_ExplicitData[1] = 0;
                            SendExplicitMessage(0x0E, 0x68, 0x01); // Set Service 14(0x0E), Class Code = 103(0x68), Class Instance = 0x01
                            break;
                        case 1:
                            // Turn ON/OFF IG
                            m_iExplicitMsgSize = 2;
                            m_ExplicitData[0] = 100; // Attribute 100 (0x64)
                            m_ExplicitData[1] = (Byte)(isExpectedTurnIGOn ? 1 : 0); // Value to turn ON/OFF
                            SendExplicitMessage(0x10, 0x67, 0x01); // Set Service 16(0x10), Class Code = 103(0x67), Class Instance = 0x01

                            // Comeback to get pressure step
                            explicitSendingMessageStep = 0;
                            break;
                        case 2:
                            // Turn IG Degas On/Off
                            m_iExplicitMsgSize = 2;
                            m_ExplicitData[0] = 6; // Attribute ID 6 (0x06)
                            m_ExplicitData[1] = (Byte)(isExpectedTurnIGDegasOn ? 1 : 0);
                            SendExplicitMessage(0x10, 0x67, 0x01); // Set Service 16(0x10), Class Code = 103(0x67), Class Instance = 0x01

                            // Comeback to get pressure step
                            explicitSendingMessageStep = 0;
                            break;
                    }
                }

                // Wait for response message to know the IG status
                if (ReceiveExplicit())
                {
                    m_ExplicitState = enExplicitState.explicitIdle;
                }

                if (m_ExplicitState == enExplicitState.explicitReceived)
                {
                    Wait4ExplicitReplyMsg();
                    if (m_ExplicitDataReceive != null && m_ExplicitDataReceive.Length >= 4)
                    {
                        m_fPressure = BitConverter.ToSingle(m_ExplicitDataReceive, 0);
                    }

                    if (m_fPressure > 1.0E+4)
                    {
                        m_fPressure = 0.0f;
                    }

                    m_bIsOn = (m_fPressure > 0);
                }

                // Get device status
                this.GetDeviceStatus();
            }
            catch (System.Exception ex)
            {
                Logger.LogHandler.Error("ReadValue:" + ex.Message);
            }
        }

        /// <summary>
        /// Turn IG On/Off
        /// </summary>
        /// <param name="bOn"></param>
        public override void TurnIGOnOff(Boolean bOn)
        {
            try
            {
                // Flag is used to detect data to send explicit message
                isExpectedTurnIGOn = bOn;

                // If turn on/off IG, go to step 1 at ReadValue function
                // Stop poll pressure at step 0
                // Step 1: Turn On/Off IG
                explicitSendingMessageStep = 1;
            }
            catch (System.Exception ex)
            {
                Logger.LogHandler.Error("TurnIGOnOff:" + ex.Message);
            }
        }

        /// <summary>
        /// Turn Degas On/Off
        /// </summary>
        /// <param name="bOn"></param>
        public override void TurnIGDegasOnOff(Boolean bOn)
        {
            try
            {
                // Flag is used to detect data to send explicit message
                isExpectedTurnIGDegasOn = bOn;

                // Go to step 2 at ReadValue function
                // Stop poll pressure at step 0
                // Do gegas at step 2
                explicitSendingMessageStep = 2;   
            }
            catch (System.Exception ex)
            {
                Logger.LogHandler.Error("TurnIGDegasOnOff:" + ex.Message);
            }
        }
    }
}
