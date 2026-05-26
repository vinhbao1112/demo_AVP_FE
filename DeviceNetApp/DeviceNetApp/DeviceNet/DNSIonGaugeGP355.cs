using System;
using System.Collections.Generic;
using System.Text;
using DeviceNetApp.Lib;

namespace DeviceNetApp.DeviceNet
{
    public class DNSIonGaugeGP355 : DNSIonGaugeGP354
    {
        public DNSIonGaugeGP355(DNSScanner objMaster, UInt16 nMacId)
            : base(objMaster, nMacId, 24)
        {
        }

        public DNSIonGaugeGP355(DNSScanner objMaster, UInt16 nMacId, float emissionSensitive)
            : base(objMaster, nMacId, emissionSensitive)
        {
        }

        /// <summary>
        /// Expected Turn IG Degas On/Off
        /// </summary>
        private Boolean isExpectedTurnIGDegasOn = false;
        
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
                // Get device status
                this.GetDeviceStatus();

                if (m_ExplicitState == enExplicitState.explicitIdle)
                {
                    // Step to turn on/off IG
                    switch (m_iExplicitSendingMsgStep)
                    {
                        case 0:
                            // Get IG Pressure Readback
                            m_iExplicitMsgSize = 1;
                            m_ExplicitData[0] = 0x06;
                            SendExplicitMessage(0x0E, 0x31, 0x01);
                            break;
                        case 1:	// Reset IG Alarm for next action
                            // Only reset Alarm when turn on IG
                            if (m_isExpectedTurnIGOn)
                            {
                                m_iExplicitMsgSize = 0;
                                SendExplicitMessage(0x63, 0x31, 0x01);
                            }
                            m_iExplicitSendingMsgStep++;
                            break;
                        case 2:
                            if (m_isExpectedTurnIGOn)
                            {
                                System.Threading.Thread.Sleep(5000);
                            }
                            else
                            {
                                isTurningIGOff = true;
                            }

                            // Turn ON/OFF IG
                            m_iExplicitMsgSize = 2;
                            m_ExplicitData[0] = 0x5D;
                            m_ExplicitData[1] = (Byte)(m_isExpectedTurnIGOn ? 1 : 0); // Value to turn ON/OFF
                            SendExplicitMessage(0x10, 0x31, 0x01);

                            // Comeback to get pressure step
                            m_iExplicitSendingMsgStep = 0;
                            break;
                        case 3:                            
                            // Turn IG Degas On/Off
                            m_iExplicitMsgSize = 1;
                            m_ExplicitData[0] = (Byte)(isExpectedTurnIGDegasOn ? 1 : 0);
                            SendExplicitMessage(0x61, 0x31, 0x01);

                            // Comeback to get pressure step
                            m_iExplicitSendingMsgStep = 0;
                            break;
                        case 4: // Switch IG Filament 1
                            SetSensitivity(false);

                            // Comeback to get pressure step
                            m_iExplicitSendingMsgStep = 0;
                            break;
                        case 5: // Switch IG Filament 1
                            m_iExplicitMsgSize = 2;
                            m_ExplicitData[0] = 89;
                            m_ExplicitData[1] = 1;
                            SendExplicitMessage(0x10, 0x31, 0x01);
                            m_iExplicitSendingMsgStep = 7;
                            break;
                        case 6: // Switch IG Filament 2
                            m_iExplicitMsgSize = 2;
                            m_ExplicitData[0] = 89;
                            m_ExplicitData[1] = 2;
                            SendExplicitMessage(0x10, 0x31, 0x01);
                            m_iExplicitSendingMsgStep++;
                            break;
                        case 7: // Get Filament
                            m_iExplicitMsgSize = 2;
                            m_ExplicitData[0] = 89;
                            m_ExplicitData[1] = 0;
                            SendExplicitMessage(0x0E, 0x31, 0x01);
                            m_iExplicitSendingMsgStep++;
                            break;
                    }
                }

                // Wait for response message to know the IG status
                if (ReceiveExplicit())
                {
                    m_ExplicitState = enExplicitState.explicitIdle;
                }

                // update switch ig filament to GUI
                if (m_iExplicitSendingMsgStep == 8 && m_ExplicitDataReceive != null && m_ExplicitDataReceive.Length > 0 && m_ExplicitState == enExplicitState.explicitReceived)
                {
                    int numFilament = Convert.ToInt16(m_ExplicitDataReceive[0]);
                    m_iActiveFilament = numFilament;
                    m_iExplicitSendingMsgStep = 0;
                    m_isSettingUp = false;
                }
                else
                {
                    if (m_ExplicitState == enExplicitState.explicitReceived)
                    {
                        Wait4ExplicitReplyMsg();
                        if (m_ExplicitDataReceive != null && m_ExplicitDataReceive.Length >= 4)
                        {
                            m_fPressure = BitConverter.ToSingle(m_ExplicitDataReceive, 0);

                            if (m_fPressure > 1.0E+4)
                            {
                                m_fPressure = 0.0f;
                            }

                            m_bIsOn = (m_fPressure > 0);

                            lock (objLock)
                            {
                                if (m_iExplicitSendingMsgStep != 1 && m_iExplicitSendingMsgStep != 2)   // 1, 2 is step turn on iG
                                {
                                    m_isExpectedTurnIGOn = m_bIsOn;
                                }
                            }

                            if (isTurningIGOff && !m_bIsOn)
                            {
                                isTurningIGOff = false;

                                System.Threading.Thread.Sleep(1000);

                                SetCurrentEmission(GP355);

                                System.Threading.Thread.Sleep(500);

                                SetSensitivity(true);
                            }
                        }
                    }
                }
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
                lock (objLock)
                {
                    if (m_isExpectedTurnIGOn != bOn)
                    {
                        // Flag is used to detect data to send explicit message
                        m_isExpectedTurnIGOn = bOn;

                        // If turn on/off IG, go to step 1 at ReadValue function
                        // Stop poll pressure at step 0
                        // Step 1: Turn On/Off IG
                        m_iExplicitSendingMsgStep = 1;
                    }
                }
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

                // Go to step 3 at ReadValue function
                // Stop poll pressure at step 0
                // Do gegas at step 3
                m_iExplicitSendingMsgStep = 3;   
            }
            catch (System.Exception ex)
            {
                Logger.LogHandler.Error("TurnIGDegasOnOff:" + ex.Message);
            }
        }

        /// <summary>
        /// Switch IG Filament 1
        /// </summary>
        public override void SwitchIGFilament1()
        {
            m_iExplicitSendingMsgStep = 5;
        }

        /// <summary>
        /// Switch IG Filament 2
        /// </summary>
        public override void SwitchIGFilament2()
        {
            m_iExplicitSendingMsgStep = 6;
        }

        /// <summary>
        /// Config the current device
        /// </summary>
        public override void Setup()
        {
            m_isSettingUp = true;

            SetCurrentEmission(GP355);

            // Set sensitivity value
            SetSensitivity(true);

            UseIGFilament();

            m_iExplicitSendingMsgStep = 7;
            m_ExplicitState = enExplicitState.explicitIdle;
        }

        public override void SetSensitivityValue()
        {
            m_iExplicitSendingMsgStep = 4;
        }

        public void SetSensitivity(bool isWait)
        {
            float sValue = m_emissionSensitive;
            Byte[] byteVal = BitConverter.GetBytes(sValue);
            m_iExplicitMsgSize = 5;
            m_ExplicitData[0] = 90;
            m_ExplicitData[1] = byteVal[0];
            m_ExplicitData[2] = byteVal[1];
            m_ExplicitData[3] = byteVal[2];
            m_ExplicitData[4] = byteVal[3];
            SendExplicitMessage(0x10, 0x31, 0x01); // Set Service, Class Code = 49, Class Instance = 1 
            if (isWait)
            {
                Wait4ExplicitReplyMsg();
            }
        }
    }
}
