using System;
using System.Collections.Generic;
using System.Text;
using DeviceNetApp.Lib;

namespace DeviceNetApp.DeviceNet
{
    public class DNSMKSFlowcool : DNSEquipment
    {
        #region "Public Configuration Properties"
        private String m_strControlType = String.Empty;

        public String ControlType
        {
            set { m_strControlType = value; }
            get { return m_strControlType; }
        }

        #endregion

        #region "Update Data Objects"
        protected PropertyObject m_objPressureProp = new PropertyObject();
        #endregion


        /// <summary>
        /// Byte array containing the pressure value
        /// </summary>
        private Byte[] m_arrPressVal = null;

        /// <summary>
        /// Pressure value read from device
        /// </summary>
        private Single m_fPressure = 0;

        public DNSMKSFlowcool(DNSScanner p_objMaster, UInt16 nMacId)
            : base(p_objMaster, nMacId)
        {
            m_arrPressVal = new Byte[2];
        }

        /// <summary>
        /// Init the Baratron Component
        /// </summary>
        /// <param name="CardHandle"></param>
        /// <param name="DeviceId"></param>
        /// <returns></returns>
        public override Boolean Intialize()
        {
            // Get Flowcool Pressure Control Type
            UInt16 inputSize = 3;
            String strType = this.ControlType;
            if (strType.ToUpper() == "TYPE1")
            {
                inputSize = 8;
            }
            else if (strType.ToUpper() == "TYPE2")
            {
                inputSize = 3;
            }

            return RegisterEquipment(m_objMaster.CardHandle, m_nMacId, inputSize, 0, 0);
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
        /// Get the pressure from the real device
        /// </summary>
        public override void Poll()
        {
            this.GetDeviceStatus();
            if (this.ReadData())
            {
                if (m_DeviceConfig.Input1Size == 3 || m_DeviceConfig.Input1Size == 8)
                {
                    m_arrPressVal[0] = m_arrInputBuffer[1];
                    m_arrPressVal[1] = m_arrInputBuffer[2];
                    m_fPressure = BitConverter.ToInt16(m_arrPressVal, 0);
                    m_fRawValue = m_fPressure;
                    // Log
                    Logger.LogHandler.Debug("Baratron Pressure byte[0] = " + m_arrInputBuffer[0].ToString());
                    Logger.LogHandler.Debug("Baratron Pressure byte[1] = " + m_arrInputBuffer[1].ToString());
                    Logger.LogHandler.Debug("Baratron Pressure byte[2] = " + m_arrInputBuffer[2].ToString());

                    if (m_fPressure < 0)
                    {
                        m_fPressure = 0;
                    }

                    m_objPressureProp.SetValue(m_fPressure);

                    Logger.LogHandler.Debug("Baratron Pressure Converted Value = " + m_fPressure.ToString());
                }
            }
        }

        /// <summary>
        /// Collect Data
        /// </summary>
        public override string CollectData(ref List<string> plstCollectedData)
        {
            string strResCmd = string.Empty;
            string strResCmdRaw = string.Empty;
            string sFlowcoolInfo = m_nMacId + "_Pressure";
            string sFlowcoolInfoRaw = m_nMacId + "_PressureRaw";
            if (IsChangedData(sFlowcoolInfo, Pressure))
            {
                strResCmd = sFlowcoolInfo + "," + Pressure.ToString();
                strResCmdRaw = sFlowcoolInfoRaw + "," + m_fRawValue.ToString();
                plstCollectedData.Add(strResCmdRaw);
                plstCollectedData.Add(strResCmd);
            }

            // For collect device status
            base.CollectData(ref plstCollectedData);

            return strResCmd;
        }

        /// <summary>
        /// Real Baratron Pressure
        /// </summary>
        public Single Pressure
        {
            get
            {
                if (m_fPressure > 0)
                {
                    return (m_fPressure / 0x8000) * 100f;
                }
                else
                {
                    return 0.001f;
                }
            }
        }
    }
}
