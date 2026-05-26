using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Reflection;
using DeviceNetApp.Lib;
using DeviceNetApp.Bussiness;

namespace DeviceNetApp.DeviceNet
{
    public class DnetPollingObject
    {
        private Object _obj = null;
        public Object OBJ
        {
            get { return _obj; }
        }

        private MethodInfo _method = null;
        public DnetPollingObject(Object obj, MethodInfo method)
        {
            _obj = obj;
            _method = method;
        }

        public void Poll()
        {
            try
            {
                _method.Invoke(_obj, null);
            }
            catch (Exception ex)
            {
                Logger.LogHandler.Error(ex.Message);
            }
        }
    }

    public class DnetGroup : ArrayList
    {
        private BaseThread m_objPollingThread = null;
        private DnetPollingGroup m_eGroup = DnetPollingGroup.Undefined;

        public DnetGroup(DnetPollingGroup eGroup)
        {
            m_eGroup = eGroup;
        }

        public void Run()
        {
            if (m_objPollingThread == null)
            {
                m_objPollingThread = new BaseThread(m_eGroup.ToString(), PollingRoutine);
            }
            m_objPollingThread.Run();
        }

        public void Stop()
        {
            if (m_objPollingThread != null)
            {
                m_objPollingThread.Stop();
            }
        }

        private void PollingRoutine()
        {
            while (!m_objPollingThread.HasTerminateRequest())
            {
                PollData();
                System.Threading.Thread.Sleep(300);
            }
        }

        protected void PollData()
        {
            try
            {
                foreach (DnetPollingObject dpo in this)
                {
                    if (m_objPollingThread.HasTerminateRequest())
                    {
                        break;
                    }

                    if (dpo.OBJ is DNSEquipment && ((DNSEquipment)dpo.OBJ).MacId == DeviceNetCore.Instance().DeviceController.PausePollingDeviceMacID)
                    {
                        DeviceNetCore.Instance().DeviceController.IsPausePollingDeviceMacID = true;
                        continue;
                    }

                    dpo.Poll();
                }
            }
            catch (Exception ex)
            {
                Logger.LogHandler.Error(ex.Message);
            }
        }

        public void Dispose()
        {
            if (m_objPollingThread != null)
            {
                m_objPollingThread.TerminateAndWait();
                m_objPollingThread.Dispose();
            }
        }
    }
}
