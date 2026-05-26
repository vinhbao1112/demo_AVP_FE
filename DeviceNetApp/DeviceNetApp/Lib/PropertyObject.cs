using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace DeviceNetApp.Lib
{
    public class PropertyObject
    {
        public enum DataType
        {
            Undefined = 0,
            IOLib_Base_EquipmentStatus,
            System_Single,
            System_Boolean,
        }

        String m_strPropertyName = String.Empty;
        Object m_obj = null;
        PropertyInfo m_prop = null;
        Boolean m_bIsOk = false;
        DataType m_eDataType = DataType.Undefined;              

        public DataType PropDataType
        {
            get { return m_eDataType; }
        }

        public PropertyObject()
        {

        }

        public Boolean Init(Object obj, String name)
        {
            PropertyInfo prop = obj.GetType().GetProperty(name);
            if (prop == null)
            {
                m_bIsOk = false;
                return false;
            }
            if (!prop.CanWrite)
            {
                m_bIsOk = false;
                return false;
            }
            m_strPropertyName = name;
            m_prop = prop;
            m_obj = obj;
            m_bIsOk = true;
            m_eDataType = GetDataType(m_prop.PropertyType.FullName);

            return true;
        }

        public void SetValue(Object objValue)
        {
            try
            {
                if (m_bIsOk)
                {
                    m_prop.SetValue(m_obj, objValue, null);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Fail("PropertyObject::SetValue error");
                Logger.LogHandler.Error(ex.Message);
            }
        }

        public object GetValue()
        {
            try
            {
                if (m_prop != null)
                {
                    return m_prop.GetValue(m_obj, null);
                }
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.Fail("PropertyObject::GetValue error");
                Logger.LogHandler.Error(ex.Message);
            }
            return null;
        }

        public void SetValueByString(String strValue)
        {
            try
            {
                if (m_bIsOk)
                {
                    Object objValue = null;

                    switch (m_eDataType)
                    {
                        case DataType.IOLib_Base_EquipmentStatus:
                            {
                                objValue = (Boolean)true;
                                Boolean bValue = false;
                                if (Boolean.TryParse(strValue, out bValue))
                                {
                                    objValue = bValue ? EquipmentStatus.OPENED : EquipmentStatus.CLOSED;
                                }
                                else
                                {
                                    objValue = EquipmentStatus.UNKNOWN;
                                }
                            }
                            break;
                        case DataType.System_Single:
                            {
                                Single fValue = 0.0f;
                                if (Single.TryParse(strValue, out fValue))
                                {
                                    objValue = fValue;
                                }
                            }
                            break;
                        case DataType.System_Boolean:
                            {
                                Boolean bValue = false;
                                if (Boolean.TryParse(strValue, out bValue))
                                {
                                    objValue = bValue;
                                }
                            }
                            break;
                    }

                    if (objValue != null)
                    {
                        m_prop.SetValue(m_obj, objValue, null);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Fail("PropertyObject::SetValueByString error");
                Logger.LogHandler.Error(ex.Message);
            }
        }

        private DataType GetDataType(String strDataType)
        {
            DataType eDataType = DataType.Undefined;
            if (strDataType == "IOLib.Base.EquipmentStatus")
            {
                eDataType = DataType.IOLib_Base_EquipmentStatus;
            }
            else if (strDataType == "System.Single")
            {
                eDataType = DataType.System_Single;
            }
            else if (strDataType == "System.Boolean")
            {
                eDataType = DataType.System_Boolean;
            }
            else
            {
                eDataType = DataType.Undefined;
                System.Diagnostics.Debug.Fail("Not support data type:" + m_prop.PropertyType.FullName);
            }
            return eDataType;
        }
    }
}
