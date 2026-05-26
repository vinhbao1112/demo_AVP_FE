using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using DeviceNetApp.Lib;
using System.Collections;
using DeviceNetApp.DeviceNet;

namespace DeviceNetApp.Bussiness
{
    public class DataCollector
    {
        private Timer m_tmrCollectDataTimer = null;
        public Timer CollectDataTimer
        {
            get { return m_tmrCollectDataTimer; }
            set { m_tmrCollectDataTimer = value; }
        }

        private Int32 m_iDataCollectorInterval = 200;
        public Int32 DataCollectorInterval
        {
            get { return m_iDataCollectorInterval; }
            set { m_iDataCollectorInterval = value; }
        }

        // For collect data
        private Dictionary<String, FiredDataInfo> m_hshFiredData = new Dictionary<String, FiredDataInfo>();
        private Object m_objsyncLockFiredData = new Object();

        /// <author>
        /// <name>Do Xuan Dat</name>
        /// <date> 2009-12-14</date>
        /// </author>
        /// <summary>
        /// 
        /// </summary>
        /// <para></para>
        /// <returns></returns>       
        public double CollectDataInterval
        {
            get { return m_tmrCollectDataTimer.Interval; }
            set 
            {
                bool blIsEnabled = m_tmrCollectDataTimer.Enabled;
                m_tmrCollectDataTimer.Enabled = false;
                m_tmrCollectDataTimer.Interval = value;
                if (blIsEnabled) 
                {
                    m_tmrCollectDataTimer.Enabled = blIsEnabled;
                }
            }
        }

        /// <author>
        /// <name>Do Xuan Dat</name>
        /// <date> 2009-12-14</date>
        /// </author>
        /// <summary>
        /// 
        /// </summary>
        /// <para></para>
        /// <returns></returns>
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            m_tmrCollectDataTimer.Enabled = false;
            
            // Get data collected
            DeviceNetController DeviceController = DeviceNetCore.Instance().DeviceController;
            List<string> collectedDataLst = DeviceController.CollectData();
            
            foreach (string strData in collectedDataLst)
            {
                if (!string.IsNullOrEmpty(strData))
                {
                    AVPDeviceNetConnection DeviceNetConnection = DeviceNetCore.Instance().DeviceConnection;
                    DeviceNetConnection.SendMessage(strData);
                }
            }
            m_tmrCollectDataTimer.Enabled = true;
        }

        /// <author>
        /// <name>Do Xuan Dat</name>
        /// <date> 2009-12-14</date>
        /// </author>
        /// <summary>
        /// 
        /// </summary>
        /// <para></para>
        /// <returns></returns>       
        public bool Initialize()
        {
            Logger.Info("Enter: Initialize");
            CreateTimer();
            Logger.Info("Leave: Initialize");
            return true;
        }

        /// <author>
        /// <name>Do Xuan Dat</name>
        /// <date> 2009-12-14</date>
        /// </author>
        /// <summary>
        /// 
        /// </summary>
        /// <para></para>
        /// <returns></returns>       
        public bool Uninitialize()
        {
            return true;
        }
        /// <author>
        /// <name>Do Xuan Dat</name>
        /// <date> 2009-12-14</date>
        /// </author>
        /// <summary>
        /// 
        /// </summary>
        /// <para></para>
        /// <returns></returns>       
        public bool CreateTimer()
        {
            m_tmrCollectDataTimer = new Timer(DataCollectorInterval);
            // Hook up the Elapsed event for the timer.
            m_tmrCollectDataTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);

            // Set the Interval to 2 seconds (2000 milliseconds).
            m_tmrCollectDataTimer.Enabled = true;
            return true;
        }

        /// <author>
        /// <name>Van Le</name>
        /// <date> 2013-11-04</date>
        /// </author>
        /// Check value is changed
        /// </summary>
        /// <param name="PropertyName"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        public Boolean IsChangedData(String strPropertyName, float fValue)
        {
            try
            {

                if (false == m_hshFiredData.ContainsKey(strPropertyName))
                {
                    FiredDataInfo objDataFireInfo = new FiredDataInfo(strPropertyName, 6000, 800, fValue);
                    lock (m_objsyncLockFiredData)
                    {
                        m_hshFiredData.Add(strPropertyName, objDataFireInfo);
                    }

                    return true;
                }
                else
                {
                    FiredDataInfo objDataInfo = (FiredDataInfo)m_hshFiredData[strPropertyName];

                    if ((float)objDataInfo.Value != fValue)
                    {
                        objDataInfo.Value = fValue;
                        objDataInfo.iFirstFired = Environment.TickCount;
                        objDataInfo.iLastFired = Environment.TickCount;
                        return true;
                    }
                    else
                    {
                        return IsNeedRetry(objDataInfo);

                    }
                }

            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
            return false;
        }

        public Boolean IsChangedData(String strPropertyName, int iValue)
        {
            try
            {
                if (false == m_hshFiredData.ContainsKey(strPropertyName))
                {
                    FiredDataInfo objDataFireInfo = new FiredDataInfo(strPropertyName, 6000, 800, iValue);
                    lock (m_objsyncLockFiredData)
                    {
                        m_hshFiredData.Add(strPropertyName, objDataFireInfo);
                    }

                    return true;
                }
                else
                {
                    FiredDataInfo objDataInfo = (FiredDataInfo)m_hshFiredData[strPropertyName];

                    if ((int)objDataInfo.Value != iValue)
                    {
                        objDataInfo.Value = iValue;
                        objDataInfo.iFirstFired = Environment.TickCount;
                        objDataInfo.iLastFired = Environment.TickCount;
                        return true;
                    }
                    else
                    {
                        return IsNeedRetry(objDataInfo);

                    }
                }

            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
            return false;
        }

        public Boolean IsChangedData(String strPropertyName, Boolean iValue)
        {
            try
            {
                if (false == m_hshFiredData.ContainsKey(strPropertyName))
                {
                    FiredDataInfo objDataFireInfo = new FiredDataInfo(strPropertyName, 6000, 800, iValue);
                    lock (m_objsyncLockFiredData)
                    {
                        m_hshFiredData.Add(strPropertyName, objDataFireInfo);
                    }

                    return true;
                }
                else
                {
                    FiredDataInfo objDataInfo = (FiredDataInfo)m_hshFiredData[strPropertyName];

                    if ((Boolean)objDataInfo.Value != iValue)
                    {
                        objDataInfo.Value = iValue;
                        objDataInfo.iFirstFired = Environment.TickCount;
                        objDataInfo.iLastFired = Environment.TickCount;
                        return true;
                    }
                    else
                    {
                        return IsNeedRetry(objDataInfo);

                    }
                }

            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
            return false;
        }

        public Boolean IsNeedRetry(FiredDataInfo p_objFiredData)
        {
            try
            {
                if ((Utils.GetTickCountDelta(p_objFiredData.iFirstFired) <= p_objFiredData.iRetryDuration)
                    && (Utils.GetTickCountDelta(p_objFiredData.iLastFired) >= p_objFiredData.iRetryInterval))
                {
                    p_objFiredData.iLastFired = Environment.TickCount;
                    Logger.Debug("Retry sending data " + p_objFiredData.DataName + " value " + p_objFiredData.Value);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
            return false;
        }

        public void SendDataToAVPAgain()
        {
            try
            {
                m_tmrCollectDataTimer.Enabled = false;
                lock (m_objsyncLockFiredData)
                {
                    if (m_hshFiredData != null)
                    {
                        m_hshFiredData.Clear();
                    }
                }
                m_tmrCollectDataTimer.Enabled = true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
        }
    }
}
