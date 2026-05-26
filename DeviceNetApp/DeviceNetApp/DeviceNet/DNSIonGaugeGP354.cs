using System;
using System.Collections.Generic;
using System.Text;
using DeviceNetApp.Lib;

namespace DeviceNetApp.DeviceNet
{
    public class DNSIonGaugeGP354 : DNSGenericIonGauge
    {
        protected const string GP354 = "GP354";
        protected const string GP355 = "GP355";

        /// <summary>
        /// The current step to process sending explicit message
        /// </summary>   
        protected Int32 m_iExplicitSendingMsgStep = 0;

        /// <summary>
        /// The current step to process sending explicit message
        /// </summary>   
        private Boolean m_isCheckFilamentFailed = false;

        /// <summary>
        /// Expected Turn IG On/Off
        /// </summary>
        protected Boolean m_isExpectedTurnIGOn = false;
        protected Object objLock = new Object();

        private Single m_EmissionCurrentType2 = 1.0e-4f;    //0.1mA for IG 355

        public DNSIonGaugeGP354(DNSScanner p_objMaster, UInt16 nMacId)
            : base(p_objMaster, nMacId, 20)
        {
            m_arrPressVal = new Byte[4];
        }

        public DNSIonGaugeGP354(DNSScanner p_objMaster, UInt16 nMacId, float emissionSensitive)
            : base(p_objMaster, nMacId, emissionSensitive)
        {
            m_arrPressVal = new Byte[4];
        }

        /// <summary>
        /// Init Ion Gauge Component
        /// </summary>
        /// <param name="CardHandle"></param>
        /// <param name="DeviceId"></param>
        /// <returns></returns>
        public override Boolean Intialize()
        {
            m_EmissionCurrentType2 = 1.0e-3f;   //1mA
            return RegisterEquipment(m_objMaster.CardHandle, m_nMacId, 5, 1, 64);
        }

        /// <summary>
        /// Read Pressure Value
        /// </summary>
        public override void ReadValue()
        {
            if (m_ExplicitState == enExplicitState.explicitIdle)
            {
                switch (m_iExplicitSendingMsgStep)
                {
                    case 0:
                        break;
                    case 1:	// Reset IG Alarm for next action
                        Logger.LogHandler.Debug("ReadValue: m_iExplicitSendingMsgStep " + m_iExplicitSendingMsgStep.ToString());
                        // Only reset Alarm when turn on IG
                        if (m_isExpectedTurnIGOn)
                        {
                            m_iExplicitMsgSize = 0;
                            SendExplicitMessage(0x63, 0x31, 0x01);
                        }
                        m_iExplicitSendingMsgStep++;
                        break;
                    case 2:
                        Logger.LogHandler.Debug("ReadValue: m_iExplicitSendingMsgStep " + m_iExplicitSendingMsgStep.ToString());
                        if (AutoSwitchFilamentOnFailed)
                        {
                            m_iExplicitMsgSize = 2;
                            m_ExplicitData[0] = 95;
                            m_ExplicitData[1] = 0;
                            SendExplicitMessage(0x0E, 0x31, 0x01);
                            m_isCheckFilamentFailed = true;
                        }
                        m_iExplicitSendingMsgStep++;
                        break;
                    case 3:	// Really turn IG On/Off
                        Logger.LogHandler.Debug("ReadValue: m_iExplicitSendingMsgStep " + m_iExplicitSendingMsgStep.ToString() + " " + m_isExpectedTurnIGOn.ToString());
                        m_iExplicitMsgSize = 2;
                        m_ExplicitData[0] = 93;
                        m_ExplicitData[1] = (Byte)(m_isExpectedTurnIGOn ? 1 : 0);
                        SendExplicitMessage(0x10, 0x31, 0x01);
                        m_iExplicitSendingMsgStep ++;
                        break;
                    case 4: // Check if any error
                        Logger.LogHandler.Debug("ReadValue: m_iExplicitSendingMsgStep " + m_iExplicitSendingMsgStep.ToString());
                        m_iExplicitMsgSize = 2;
                        m_ExplicitData[0] = 5;
                        m_ExplicitData[1] = 0;
                        SendExplicitMessage(0x0E, 0x31, 0x01);
                        m_iExplicitSendingMsgStep++;
                        break;
                    case 6: // Switch IG Filament 1
                        SetCurrentEmission(GP354);
                        SetSensitivityValue();
                        Logger.LogHandler.Debug("ReadValue: m_iExplicitSendingMsgStep " + m_iExplicitSendingMsgStep.ToString());
                        m_iExplicitMsgSize = 2;
                        m_ExplicitData[0] = 89;
                        m_ExplicitData[1] = 1;
                        SendExplicitMessage(0x10, 0x31, 0x01);
                        m_iExplicitSendingMsgStep = 9;
                        break;
                    case 8: // Switch IG Filament 2
                        SetCurrentEmission(GP354);
                        SetSensitivityValue();
                        Logger.LogHandler.Debug("ReadValue: m_iExplicitSendingMsgStep " + m_iExplicitSendingMsgStep.ToString());
                        m_iExplicitMsgSize = 2;
                        m_ExplicitData[0] = 89;
                        m_ExplicitData[1] = 2;
                        SendExplicitMessage(0x10, 0x31, 0x01);
                        m_iExplicitSendingMsgStep++;
                        break;
                    case 9: // Get Filament
                        Logger.LogHandler.Debug("ReadValue: m_iExplicitSendingMsgStep " + m_iExplicitSendingMsgStep.ToString());
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

            if (m_isCheckFilamentFailed && m_ExplicitState == enExplicitState.explicitReceived)
            {
                // Check if has filament 1 or 2 failed
                if (m_ExplicitDataReceive != null && m_ExplicitDataReceive.Length > 0)
                {
                    Int16 iFilamentFailed = Convert.ToInt16(m_ExplicitDataReceive[0]);
                    Int16 iSwitchToFilament = 0;
                    if (iFilamentFailed == 1 && iFilamentFailed == m_iActiveFilament)
                    {
                        iSwitchToFilament = 2;
                    }
                    else if (iFilamentFailed == 2 && iFilamentFailed == m_iActiveFilament)
                    {
                        iSwitchToFilament = 1;
                    }

                    if (iSwitchToFilament != 0)
                    {
                        Logger.LogHandler.Debug("Switch filament from " + m_iActiveFilament.ToString() + " to " + iSwitchToFilament.ToString());
                        if (m_bIsOn)
                        {
                            // Turn IG off before switching filament
                            m_iExplicitMsgSize = 2;
                            m_ExplicitData[0] = 93;
                            m_ExplicitData[1] = 0;
                            SendExplicitMessage(0x10, 0x31, 0x01);
                        }

                        // Switch to another filament
                        m_iExplicitMsgSize = 2;
                        m_ExplicitData[0] = 89;
                        m_ExplicitData[1] = Convert.ToByte(iSwitchToFilament);
                        if (SendExplicitMessage(0x10, 0x31, 0x01))
                        {
                            m_iExplicitSendingMsgStep = 9;
                        }
                    }
                }
                m_isCheckFilamentFailed = false;
            }

            // update switch ig filament to GUI
            if (m_iExplicitSendingMsgStep == 10 && m_ExplicitDataReceive != null && m_ExplicitDataReceive.Length > 0 && m_ExplicitState == enExplicitState.explicitReceived)
            {
                int numFilament = Convert.ToInt16(m_ExplicitDataReceive[0]);
                m_iActiveFilament = numFilament;
                m_isSettingUp = false;
            }

            this.GetDeviceStatus();
            if (this.ReadData())
            {
                if (m_DeviceConfig.Input1Size == 5)
                {
                    m_arrPressVal[0] = m_arrInputBuffer[1];
                    m_arrPressVal[1] = m_arrInputBuffer[2];
                    m_arrPressVal[2] = m_arrInputBuffer[3];
                    m_arrPressVal[3] = m_arrInputBuffer[4];
                    m_fPressure = BitConverter.ToSingle(m_arrPressVal, 0);

                    // Log
                    // Logger.LogHandler.Debug("IG Pressure Readback = " + m_fPressure.ToString());

                    if (m_fPressure > 1.0E+4)
                    {
                        m_fPressure = 0.0f;
                        
                    }

                    m_bIsOn = (m_fPressure > 0);

                    lock (objLock)
                    {
                        if (m_iExplicitSendingMsgStep > 3)  // 3 is step turn on IG
                        {
                            Logger.LogHandler.Debug("ReadValue: New IsIGOn " + m_bIsOn.ToString());
                            m_isExpectedTurnIGOn = m_bIsOn;
                        }
                    }

                    m_objPressureProp.SetValue(m_fPressure);
                    m_objIsOnProp.SetValue(m_bIsOn? EquipmentStatus.OPENED: EquipmentStatus.CLOSED);
                }
            }
            else if ((m_DeviceStatus != null) && !DeviceNetDriver.IsDeviceActive(m_DeviceStatus.StatusCode))
            {
                m_objPressureProp.SetValue(Constants.DNET_ERROR_VALUE);
                m_objIsOnProp.SetValue(EquipmentStatus.UNKNOWN);
            }
        }

        /// <summary>
        /// Turn Filament On/Off
        /// </summary>
        /// <param name="bOn"></param>
        public override void TurnIGOnOff(Boolean bOn)
        {
            lock (objLock)
            {
                if (m_isExpectedTurnIGOn != bOn)
                {
                    m_isExpectedTurnIGOn = bOn;
                    m_iExplicitSendingMsgStep = 1;
                }
            }
        }

        /// <summary>
        /// Turn Filament On/Off
        /// </summary>
        /// <param name="bOn"></param>
        public override void TurnIGDegasOnOff(Boolean bOn)
        {
            m_iExplicitMsgSize = 2;
            m_ExplicitData[0] = 88;
            m_ExplicitData[1] = (Byte)(bOn? 1 : 0);
            // Do it like IG
            SendExplicitMessage(0x10, 0x31, 0x01); // Set Service(0x10), Class Code = 49(0x31), Class Instance = 0x01
        }
        /// <summary>
        /// Switch IG Filament 1
        /// </summary>
        public override void SwitchIGFilament1()
        {
            m_iExplicitSendingMsgStep = 6;
        }

        /// <summary>
        /// Switch IG Filament 2
        /// </summary>
        public override void SwitchIGFilament2()
        {
            m_iExplicitSendingMsgStep = 8;
        }

        /// <summary>
        /// Config the current device
        /// </summary>
        public override void Setup()
        {
            try
            {
                m_isSettingUp = true;

                SetCurrentEmission(GP354);

                // Set sensitivity value
                SetSensitivityValue();

                // Use ion gauge filament 1 or filament 2
                UseIGFilament();

                m_iExplicitSendingMsgStep = 9;

                m_ExplicitState = enExplicitState.explicitIdle;
            }
            catch (Exception ex)
            {
                Logger.LogHandler.Error(ex.Message);
            }
        }
        
        //<author>
        //  	<name> Duc Pham </name>
        //  	<date> 2018-10-26</date>
        // </author>
        // <summary>
        // Use IG Filament
        //</summary>
        public void UseIGFilament()
        {
            try
            {
                m_iExplicitMsgSize = 2;
                m_ExplicitData[0] = 89;
                if (this.WhichFilament == 2)
                {
                    m_ExplicitData[1] = 2;
                }
                else if (this.WhichFilament == 3)
                {
                    m_ExplicitData[1] = 3;
                }
                else if (this.WhichFilament != 4)
                {
                    m_ExplicitData[1] = 1;
                }

                if (this.WhichFilament != 4)
                {
                    SendExplicitMessage(0x10, 0x31, 0x01); // Set Service(0x10), Class Code = 49(0x31), Class Instance = 0x01
                    Wait4ExplicitReplyMsg();
                }
            }
            catch (Exception ex)
            {
                Logger.LogHandler.Error(ex.Message);
            }
        }

        //<author>
        //  	<name> Duc Pham </name>
        //  	<date> 2018-10-26</date>
        // </author>
        // <summary>
        // Set Current Emission
        //</summary>
        public void SetCurrentEmission(string strIGType)
        {
            try
            {
                // Determine Current Emission Mode and Level
                Boolean bAutoCurrentEmission = false;
                Single InitialCurrent = 20.0e-6f; // 20uA
                if (this.IonGaugeEmissionCurrent == 1)
                {
                    bAutoCurrentEmission = false;
                    InitialCurrent = 20.0e-6f; // 20uA
                }
                else if (this.IonGaugeEmissionCurrent == 2)
                {
                    bAutoCurrentEmission = false;
                    InitialCurrent = m_EmissionCurrentType2; // 1mA
                }
                else if (this.IonGaugeEmissionCurrent == 3)
                {
                    bAutoCurrentEmission = false;
                    InitialCurrent = 4.0e-3f; // 4mA
                }
                else if (this.IonGaugeEmissionCurrent == 4)
                {
                    bAutoCurrentEmission = true;
                }
                else
                {
                    bAutoCurrentEmission = true;
                }

                m_iExplicitMsgSize = 2;
                if (strIGType == GP355)
                {
                    // Set Mode Emission Selection
                    m_ExplicitData[0] = 103;
                    if (bAutoCurrentEmission)
                    {
                        m_ExplicitData[1] = 0;
                    }
                    else
                    {
                        m_ExplicitData[1] = 1;
                    }
                    SendExplicitMessage(0x10, 0x31, 0x01); // Set Service, Class Code = 49, Class Instance = 1
                }
                else
                {
                    // Turn on/off auto current
                    m_ExplicitData[0] = 6;
                    if (bAutoCurrentEmission)
                    {
                        m_ExplicitData[1] = 1;
                    }
                    else
                    {
                        m_ExplicitData[1] = 0;
                    }
                    SendExplicitMessage(0x10, 0x35, 0x01); // Set Service, Class Code = 53, Class Instance = 1
                }
                Wait4ExplicitReplyMsg();

                // Only Set when Emission Current Mode is Manual
                if (false == bAutoCurrentEmission)
                {
                    // Set Emission Current Attribute
                    Byte[] byteVal = BitConverter.GetBytes(InitialCurrent);
                    m_iExplicitMsgSize = 5;
                    m_ExplicitData[0] = 91; // Emission Current Attribute
                    m_ExplicitData[1] = byteVal[0];
                    m_ExplicitData[2] = byteVal[1];
                    m_ExplicitData[3] = byteVal[2];
                    m_ExplicitData[4] = byteVal[3];
                    SendExplicitMessage(0x10, 0x31, 0x01); // Set Service, Class Code = 49, Class Instance = 1 
                    Wait4ExplicitReplyMsg();
                }
            }
            catch (Exception ex)
            {
                Logger.LogHandler.Error(ex.Message);
            }
        }

        public override void SetSensitivityValue()
        {
            float sValue = m_emissionSensitive;
            Byte[] byteVals = BitConverter.GetBytes(sValue);
            m_iExplicitMsgSize = 5;
            m_ExplicitData[0] = 90;
            m_ExplicitData[1] = byteVals[0];
            m_ExplicitData[2] = byteVals[1];
            m_ExplicitData[3] = byteVals[2];
            m_ExplicitData[4] = byteVals[3];
            SendExplicitMessage(0x10, 0x31, 0x01); // Set Service, Class Code = 49, Class Instance = 1 
            Wait4ExplicitReplyMsg();
        }
    }
}
