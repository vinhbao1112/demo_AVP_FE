using System;
using System.Collections.Generic;
using System.Text;
using DeviceNetApp.Lib;

namespace DeviceNetApp.DeviceNet
{
    public enum MKSModel
    {
        Undefined = 0,
        Legacy = 1,
        G_Series = 2,
        ALTA_Series = 3,
    }
    public class DNSMKSGasFlow : DNSEquipment
    {
        #region "Update Data Objects"
        protected PropertyObject m_objFlowRateProp = new PropertyObject();
        #endregion


        /// <summary>
        /// Range of value
        /// </summary>
        private Single m_fRange = 50.0f;
        public Single Range
        {
            get { return m_fRange; }
            set { m_fRange = value; }
        }

        /// <summary>
        /// Calibration Factor
        /// </summary>
        private Single m_fCalibrationFactor = 1f;
        public Single CalibrationFactor
        {
            get { return m_fCalibrationFactor; }
            set { m_fCalibrationFactor = value; }
        }

        /// <summary>
        /// Real FlowRate
        /// </summary>
	    private Single m_fFlowRate = 0.0f;

        /// <summary>
        /// FlowRate Set Point
        /// </summary>
        private Single m_fFlowRateSP = 0.0f;

        /// <summary>
        /// Data Array returned by Device
        /// </summary>
        private Byte[] m_arrFlowVal = null;
        private MKSModel m_eModel = MKSModel.Undefined;

        public DNSMKSGasFlow(DNSScanner p_objMaster, UInt16 nMacId, MKSModel eModel)
            : base(p_objMaster, nMacId)
        {
            m_arrFlowVal = new Byte[2];
            m_eModel = eModel;
        }

        public DNSMKSGasFlow(DNSScanner p_objMaster, UInt16 nMacId)
            : base(p_objMaster, nMacId)
        {
            m_arrFlowVal = new Byte[2];
        }

        /// <summary>
        /// Init MFC device
        /// </summary>
        /// <param name="CardHandle"></param>
        /// <param name="DeviceId"></param>
        /// <returns></returns>
        public override Boolean Intialize()
        {
            Boolean bResult = false;
            switch (m_eModel)
            {
                case MKSModel.G_Series:
                case MKSModel.ALTA_Series:
                    bResult = RegisterEquipment(m_objMaster.CardHandle, m_nMacId, 3, 2, 0);
                    break;
                case MKSModel.Legacy:
                    bResult = RegisterEquipment(m_objMaster.CardHandle, m_nMacId, 8, 8, 0);
                    break;
                case MKSModel.Undefined:
                    Logger.LogHandler.Error("Initialize with MKS Gas Model = MKSModel.Undefined");
                    break;
                default:
                    break;
            }
            return bResult;
        }

        /// <summary>
        /// Set Value
        /// </summary>
        public override bool SetValue(string strCmd, params object[] arrParams)
        {
            bool bRes = false;
            try
            {
                switch (strCmd)
                {
                    case Constants.DNET_CMD_GAS_FLOW_RATE:
                        {
                            Logger.LogHandler.Debug("SetValue " + strCmd + " " + arrParams[0].ToString());
                            float fValue = (float)arrParams[0];
                            bRes = GasFlowSetPoint(fValue);
                        }
                        break;
                    case Constants.DNET_CMD_CFG_RANGE:
                        {
                            Logger.LogHandler.Debug("SetValue " + strCmd + " " + arrParams[0].ToString());
                            float fValue = (float)arrParams[0];
                            Range = fValue;
                            bRes = true;
                        }
                        break;
                    case Constants.DNET_CMD_CFG_CALIBRATION_FACTOR:
                        {
                            Logger.LogHandler.Debug("SetValue " + strCmd + " " + arrParams[0].ToString());
                            float fValue = (float)arrParams[0];
                            CalibrationFactor = fValue;
                            bRes = true;
                        }
                        break;
                    case Constants.DNET_CMD_CFG_ZERO_ADJUST:
                        Logger.LogHandler.Debug("SetValue " + strCmd);
                        bRes = ZeroAdjust();
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
                    case Constants.DNET_PROP_FLOW_RATE:
                        {
                            m_objFlowRateProp.Init(objReceiver, strPropertyName);
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
        /// Get the flow rate from the real device
        /// </summary>
        public override void Poll()
        {
            this.GetDeviceStatus();
            if (this.ReadData())
            {
                m_arrFlowVal[0] = m_arrInputBuffer[1];
                m_arrFlowVal[1] = m_arrInputBuffer[2];
                m_fFlowRate = BitConverter.ToInt16(m_arrFlowVal, 0);
                m_fRawValue = m_fFlowRate;
                switch (m_eModel)
                {
                    case MKSModel.G_Series:
                    case MKSModel.ALTA_Series:
                        m_fFlowRate = (m_fFlowRate / 0x6000) * Range * CalibrationFactor;
                        break;
                    case MKSModel.Legacy:
                        m_fFlowRate = (m_fFlowRate / 0x8000) * Range * CalibrationFactor;
                        break;
                    case MKSModel.Undefined:
                        Logger.LogHandler.Error("Poll with Gas Model = MKSModel.Undefined");
                        break;
                    default:
                        break;
                }
                m_objFlowRateProp.SetValue(m_fFlowRate);
            }
        }

        /// <summary>
        /// Collect Data
        /// </summary>
        public override string CollectData(ref List<string> plstCollectedData)
        {
            string strResCmd = string.Empty;
            string strResCmdRaw = string.Empty;
            string sGasInfo = m_nMacId + "_Flowrate";
            string sGasInfoRaw = m_nMacId + "_FlowrateRaw";
            if (IsChangedData(sGasInfo, m_fFlowRate))
            {
                strResCmdRaw = sGasInfoRaw + "," + m_fRawValue.ToString();
                plstCollectedData.Add(strResCmdRaw);
                strResCmd = sGasInfo + "," + m_fFlowRate.ToString();
                plstCollectedData.Add(strResCmd);
            }

            // For collect device status
            base.CollectData(ref plstCollectedData);

            return strResCmd;
        }

        /// <summary>
        /// Gas Flow
        /// </summary>
        public Single GasFlow
        {
            get
            {
                return m_fFlowRate;
            }
        }

        /// <summary>
        /// Gas Flow Set Point
        /// </summary>
        public Single GasFlowSP
        {
            get
            {
                return m_fFlowRateSP;
            }
        }

        /// <summary>
        /// Set Point function for Gas Flow
        /// </summary>
        /// <param name="newSetPoint"></param>
        /// <returns></returns>
        public Boolean GasFlowSetPoint(Single newSetPoint)
        {
            if (DeviceNetDriver.IsDeviceActive(m_DeviceStatus.StatusCode))
            {
                m_fFlowRateSP = newSetPoint;

                newSetPoint /= CalibrationFactor;

                // Limit max
                if (newSetPoint > m_fRange)
                {
                    newSetPoint = m_fRange;
                }

                // Limit min
                if (newSetPoint < 0.0f)
                {
                    newSetPoint = 0.0f;
                }

                // Convert
                switch (m_eModel)
                {
                    case MKSModel.G_Series:
                    case MKSModel.ALTA_Series:
                        {
                            newSetPoint = (newSetPoint / m_fRange) * 0x6000;
                        }
                        break;
                    case MKSModel.Legacy:
                        {
                            newSetPoint = (newSetPoint / m_fRange) * 0x8000;
                        }
                        break;
                    case MKSModel.Undefined:
                        {
                            Logger.LogHandler.Error("Set gas value with Gas Model = MKSModel.Undefined");
                        }
                        break;
                    default:
                        break;
                }


                if (newSetPoint > 0x7FFF)
                {
                    newSetPoint = 0x7FFF;
                }

                if (newSetPoint < 0.0f)
                {
                    newSetPoint = 0.0f;
                }

                switch (m_eModel)
                {
                    case MKSModel.G_Series:
                    case MKSModel.ALTA_Series:
                        {
                            UInt16 GasSP = (UInt16)newSetPoint;

                            // Convert SP to byte array
                            Byte[] arrGasSP = BitConverter.GetBytes(GasSP);

                            // Construct write array
                            m_arrOutputBuffer = new Byte[2];

                            // Set Value
                            m_arrOutputBuffer[0] = arrGasSP[0];
                            m_arrOutputBuffer[1] = arrGasSP[1];
                        }
                        break;
                    case MKSModel.Legacy:
                        {
                            UInt16 GasSP = (UInt16)newSetPoint; 

                            // Convert SP to byte array
                            Byte[] arrGasSP = BitConverter.GetBytes(GasSP);

                            // Construct write array
                            m_arrOutputBuffer = new Byte[8];

                            // Set Value
                            m_arrOutputBuffer[0] = arrGasSP[0];
                            m_arrOutputBuffer[1] = arrGasSP[1];
                            m_arrOutputBuffer[2] = 0; // Normal Override Mode
                        }
                        break;
                    case MKSModel.Undefined:
                        return false;
                }

                // Write
                return WriteData();
            }

            return false;
        }

        /// <summary>
        /// Zero Adjust
        /// </summary>
        /// <returns></returns>
        public Boolean ZeroAdjust()
        {
            m_iExplicitMsgSize = 0;
            return SendExplicitMessage(0x4B, 0x31, 0x01);
        }
    }
}
