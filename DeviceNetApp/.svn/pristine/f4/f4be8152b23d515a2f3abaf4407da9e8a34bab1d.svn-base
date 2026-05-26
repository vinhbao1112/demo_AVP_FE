using System;
using System.Collections.Generic;
using System.Text;
using DeviceNetApp.Lib;

namespace DeviceNetApp.DeviceNet
{
    class DNSIonGaugeMPT200 : DNSGenericIonGauge
    {
        public DNSIonGaugeMPT200(DNSScanner p_objMaster, UInt16 nMacId)
            : base(p_objMaster, nMacId)
        {
        }

        /// <summary>
        /// Is Turning IG Off
        /// </summary>
        private Boolean isTurningIGOff = false;

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
                    // Get IG Pressure Readback
                    m_iExplicitMsgSize = 1;
                    m_ExplicitData[0] = 0x06;
                    SendExplicitMessage(0x0E, 0x31, 0x01);
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

                        if (m_fPressure > 1.0E+4 || isTurningIGOff)
                        {
                            m_fPressure = 0.0f;
                        }

                        m_bIsOn = (m_fPressure > 0);
                    }
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
                isTurningIGOff = !bOn;
            }
            catch (System.Exception ex)
            {
                Logger.LogHandler.Error("TurnIGOnOff:" + ex.Message);
            }
        }

        /// <summary>
        /// Config the current device
        /// </summary>
        public override void Setup()
        {
            m_isSettingUp = true;

            // Set Data type to REAL(0xCA)
            m_iExplicitMsgSize = 2;
            m_ExplicitData[0] = 0x03;
            m_ExplicitData[1] = 0xCA;
            SendExplicitMessage(0x10, 0x31, 0x01);
            Wait4ExplicitReplyMsg();

            // Set Data units to Torr(0x1301)
            m_iExplicitMsgSize = 3;
            m_ExplicitData[0] = 0x04;
            m_ExplicitData[1] = 0x01;
            m_ExplicitData[2] = 0x13;
            SendExplicitMessage(0x10, 0x31, 0x01);
            Wait4ExplicitReplyMsg();

            m_ExplicitState = enExplicitState.explicitIdle;

            m_isSettingUp = false;
        }
    }
}
