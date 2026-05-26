using System;
using System.Collections.Generic;
using System.Text;
using DeviceNetApp.Lib;

namespace DeviceNetApp.DeviceNet
{
    public class DNSGenericIonGauge: DNSEquipment
    {

        #region "Update Data Objects"
        protected PropertyObject m_objPressureProp = new PropertyObject();
        protected PropertyObject m_objIsOnProp = new PropertyObject();
        #endregion

        #region "Public Configuration Properties"
        private int m_iIonGaugeFirmwareModel = -1;
        private int m_iIonGaugeEmissionCurrent = -1;
        protected float m_emissionSensitive = 24;

        private int m_iWhichFilament = -1;
        protected int m_iActiveFilament = 0;
        private bool m_bIsSetWhichFilament = false;
        private bool m_bAutoSwitchFilamentOnFailed = false;

        public int IonGaugeFirmwareModel
        {
            get { return m_iIonGaugeFirmwareModel; }
        }
        public int IonGaugeEmissionCurrent
        {
            get { return m_iIonGaugeEmissionCurrent; }
        }
        public int WhichFilament
        {
            get { return m_iWhichFilament; }
        }
        public int ActiveFilament
        {
            get
            {
                return m_iActiveFilament;
            }
        }
        public bool AutoSwitchFilamentOnFailed
        {
            get { return m_bAutoSwitchFilamentOnFailed; }
        }

        public float EmissionSensitive
        {
            get { return m_emissionSensitive; }
        }

        #endregion

        /// <summary>
        /// Byte array containing the pressure value
        /// </summary>
        protected Byte[] m_arrPressVal = null;

        /// <summary>
        /// Pressure value read from device
        /// </summary>
        protected Single m_fPressure = 0;

        /// <summary>
        /// Show that it is OK to use pressure read back
        /// </summary>
        protected Boolean m_bIsOn = false;

        protected bool m_isSettingUp = false;

        public DNSGenericIonGauge(DNSScanner p_objMaster, UInt16 nMacId)
            : base(p_objMaster, nMacId)
        {
        }

        public DNSGenericIonGauge(DNSScanner p_objMaster, UInt16 nMacId, float emissionSensitive)
            : base(p_objMaster, nMacId)
        {
            m_emissionSensitive = emissionSensitive;
        }

        /// <summary>
        /// Set Value
        /// </summary>
        public override bool SetValue(string strCmd, params object[] arrParams)
        {
            bool bRes = false;

            // Do not allow action cmd when device is setting up
            if (m_isSettingUp)
            {
                return false;
            }

            try
            {
                Logger.LogHandler.Debug("SetValue " + strCmd + " " + arrParams[0].ToString());
                switch (strCmd)
                {
                    case Constants.DNET_CMD_FILAMENT_ON_OFF:
                        {
                            bool bOn = bool.Parse(arrParams[0].ToString());
                            TurnIGOnOff(bOn);
                            bRes = true;
                        }
                        break;
                    case Constants.DNET_CMD_IG_DEGAS_ON_OFF:
                        {
                            bool bOn = false;
                            if (bool.TryParse(arrParams[0].ToString(), out bOn))
                            {
                                TurnIGDegasOnOff(bOn);
                                bRes = true;
                            }
                        }
                        break;
                    case Constants.DNET_CMD_CFG_IG_SELECT_EMISSION_CURRENT:
                        {
                            m_iIonGaugeEmissionCurrent = (Int32)arrParams[0];
                            bRes = true;
                        }
                        break;
                    case Constants.DNET_CMD_CFG_IG_SELECT_FILAMENT:
                        {
                            Int32 filament;
                            if (Int32.TryParse(arrParams[0].ToString(), out filament))
                            {
                                if (!m_bIsSetWhichFilament)
                                {
                                    m_iWhichFilament = filament;
                                    m_bAutoSwitchFilamentOnFailed = (m_iWhichFilament == 4);

                                    m_bIsSetWhichFilament = true;
                                }

                                if (filament == 1)
                                {
                                    SwitchIGFilament1();
                                }
                                else if (filament == 2)
                                {
                                    SwitchIGFilament2();
                                }
                                bRes = true;
                            }
                        }
                        break;
                    case Constants.DNET_CMD_CFG_IG_SELECT_EMISSION_SENSITIVE:
                        {
                            float emissionSensitive;
                            if (float.TryParse(arrParams[0].ToString(), out emissionSensitive))
                            {
                                SetEmissionSensitive(emissionSensitive);

                                bRes = true;
                            }
                        }
                        break;
                    default:
                        bRes = false;
                        break;
                }
            }
            catch (Exception ex)
            {
                Logger.LogHandler.Error(ex.Message);
            }
            return bRes;
        }

        /// <summary>
        /// Set Property Changed Receiver
        /// </summary>
        public override bool SetPropertyChangedHandler(String strDnetPropertyName, Object objReceiver, String strPropertyName)
        {
            bool bRes = false;
            try
            {
                switch (strDnetPropertyName)
                {
                    case Constants.DNET_PROP_PRESSURE:
                        {
                            m_objPressureProp.Init(objReceiver, strPropertyName);
                        }
                        break;
                    case Constants.DNET_PROP_STATUS:
                        {
                            m_objIsOnProp.Init(objReceiver, strPropertyName);
                        }
                        break;
                    default:
                        bRes = false;
                        break;
                }
            }
            catch (Exception ex)
            {
                Logger.LogHandler.Error(ex.Message);
            }
            return bRes;  
        }

        /// <summary>
        /// Get the IG Pressure from the real device
        /// </summary>
        public override void Poll()
        {
            // Get the pressure value
            ReadValue();
            if (m_bIsOn)
            {
                //Logger.LogHandler.Debug("IG Pressure = " + m_fPressure.ToString());
            }
            else
            {
                m_fPressure = 0.0f;
                //Logger.LogHandler.Debug("IG is OFF");
            }
        }

        /// <summary>
        /// Collect Data
        /// </summary>
        public override string CollectData(ref List<string> plstCollectedData)
        {
            AddListOfParameter(ref plstCollectedData, CollectIGPressure());
            AddListOfParameter(ref plstCollectedData, CollectIGStatus());
            AddListOfParameter(ref plstCollectedData, CollectIGFilament());

            // Collect device status
            base.CollectData(ref plstCollectedData);

            return string.Empty;
        }

        /// <summary>
        /// Collect IG Pressure
        /// </summary>
        public string CollectIGPressure()
        {
            string strResCmd = string.Empty;
            string sIGInfo = m_nMacId + "_Pressure";
            if (IsChangedData(sIGInfo, m_fPressure))
            {
                strResCmd = sIGInfo + "," + m_fPressure.ToString();
            }

            return strResCmd;
        }

        /// <summary>
        /// Collect IG Status
        /// </summary>
        public string CollectIGStatus()
        {
            string strResCmd = string.Empty;
            string sIGInfo = m_nMacId + "_Status";
            string strValue = m_bIsOn.ToString();
            if (IsChangedData(sIGInfo, m_bIsOn))
            {
                strResCmd = sIGInfo + "," + strValue.ToLower();
            }

            return strResCmd;
        }
        /// <summary>
        /// Collect IG Filament
        /// </summary>
        public string CollectIGFilament()
        {
            string strResCmd = string.Empty;
            string sIGInfo = m_nMacId + "_Filament";
            string strValue = m_iActiveFilament.ToString();
            if (IsChangedData(sIGInfo, m_iActiveFilament))
            {
                strResCmd = sIGInfo + "," + strValue.ToLower();
            }

            return strResCmd;
        }

        /// <summary>
        /// Read Pressure Value
        /// </summary>
        public virtual void ReadValue()
        {
            // will be implemented in subclass
        }

        /// <summary>
        /// CG Pressure
        /// </summary>
        public Single Pressure
        {
            get
            {
                return m_fPressure;
            }
        }

        /// <summary>
        /// Is On
        /// </summary>
        public Boolean IsOn
        {
            get
            {
                return m_bIsOn;
            }
        }

        /// <summary>
        /// Turn Filament On/Off
        /// </summary>
        /// <param name="bOn"></param>
        public virtual void TurnIGOnOff(Boolean bOn)
        {
            // Will be implemented in sub-class
        }

        /// <summary>
        /// Turn IG Degas On/Off
        /// </summary>
        /// <param name="bOn"></param>
        public virtual void TurnIGDegasOnOff(Boolean bOn)
        {
            // Will be implemented in sub-class
        }

        /// <summary>
        /// Clean Up
        /// </summary>
        public override void CleanUp()
        {
            m_bIsDisposing = true;
        }

        /// <summary>
        /// Switch IG Filament 1
        /// </summary>
        public virtual void SwitchIGFilament1()
        {
            // Will be implemented in sub-class
        }

        /// <summary>
        /// Switch IG Filament 2
        /// </summary>
        public virtual void SwitchIGFilament2()
        {
            // Will be implemented in sub-class
        }

        public virtual void SetSensitivityValue()
        {
            // Will be implemented in sub-class
        }

        public void SetEmissionSensitive(float emissionSensitive)
        {
            m_emissionSensitive = emissionSensitive;
            SetSensitivityValue();
        }
    }
}
