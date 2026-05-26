using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Data.OleDb;


namespace AVPSecsGemLib
{
    public class AVPSecsGemConfiguration
    {
        //Truc Le 
        public  static string GEMID_File = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "ConfigFiles\\SystemConfig\\private\\GEMControl.mdb";
        private  static System.Data.OleDb.OleDbConnection m_GemDataConnection = null;
        private static string sDatabase = GEMID_File;
        private static string sUsername = "";
        private static string sPwd = "";

        private static string connStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + sDatabase + ";User Id=" + sUsername + ";Password=" + sPwd + ";";
        #region "PVD5T GEM"
        public static System.Data.DataTable Load_PVD5T_GEM_Alarm()
        {
            if ((m_GemDataConnection != null))
            {
                m_GemDataConnection.Close();
                m_GemDataConnection = null;
            }
            m_GemDataConnection = new System.Data.OleDb.OleDbConnection(connStr);
            try
            {
                if (m_GemDataConnection.State == ConnectionState.Closed)
                {
                    m_GemDataConnection.Open();
                }
                string sSQLQuery = "SELECT * FROM GEM_PVD5T_Alarms";

                System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter(sSQLQuery, m_GemDataConnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                da.Dispose();
                return dt;
            }
            catch (Exception ex)
            {
                AVPSecsGemLog.avpSecsGemLogger.Error(ex.ToString());
            }
            finally
            {
                m_GemDataConnection.Close();
            }
            return null;
        }
        public static System.Data.DataTable Load_PVD5T_GEM_Variable()
        {
            if ((m_GemDataConnection != null))
            {
                m_GemDataConnection.Close();
                m_GemDataConnection = null;
            }
            m_GemDataConnection = new System.Data.OleDb.OleDbConnection(connStr);
            try
            {
                if (m_GemDataConnection.State == ConnectionState.Closed)
                {
                    m_GemDataConnection.Open();
                }
                string sSQLQuery = "SELECT * FROM GEM_PVD5T_Variables";

                System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter(sSQLQuery, m_GemDataConnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                da.Dispose();
                return dt;
            }
            catch (Exception ex)
            {
                AVPSecsGemLog.avpSecsGemLogger.Error(ex.ToString());
            }
            finally
            {
                m_GemDataConnection.Close();
            }
            return null;
        }
        public static System.Data.DataTable Load_PVD5T_GEM_Event()
        {
            if ((m_GemDataConnection != null))
            {
                m_GemDataConnection.Close();
                m_GemDataConnection = null;
            }
            m_GemDataConnection = new System.Data.OleDb.OleDbConnection(connStr);
            try
            {
                if (m_GemDataConnection.State == ConnectionState.Closed)
                {
                    m_GemDataConnection.Open();
                }
                string sSQLQuery = "SELECT * FROM GEM_PVD5T_Events";

                System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter(sSQLQuery, m_GemDataConnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                da.Dispose();
                return dt;
            }
            catch (Exception ex)
            {
                AVPSecsGemLog.avpSecsGemLogger.Error(ex.ToString());
            }
            finally
            {
                m_GemDataConnection.Close();
            }
            return null;
        }
        #endregion

        #region "CORONA GEM"
        public static System.Data.DataTable Load_CORONA_GEM_Alarm()
        {
            if ((m_GemDataConnection != null))
            {
                m_GemDataConnection.Close();
                m_GemDataConnection = null;
            }
            m_GemDataConnection = new System.Data.OleDb.OleDbConnection(connStr);
            try
            {
                if (m_GemDataConnection.State == ConnectionState.Closed)
                {
                    m_GemDataConnection.Open();
                }
                string sSQLQuery = "SELECT * FROM GEM_CORONA_Alarms";

                System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter(sSQLQuery, m_GemDataConnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                da.Dispose();
                return dt;
            }
            catch (Exception ex)
            {
                AVPSecsGemLog.avpSecsGemLogger.Error(ex.ToString());
            }
            finally
            {
                m_GemDataConnection.Close();
            }
            return null;
        }
        public static System.Data.DataTable Load_CORONA_GEM_Variable()
        {
            if ((m_GemDataConnection != null))
            {
                m_GemDataConnection.Close();
                m_GemDataConnection = null;
            }
            m_GemDataConnection = new System.Data.OleDb.OleDbConnection(connStr);
            try
            {
                if (m_GemDataConnection.State == ConnectionState.Closed)
                {
                    m_GemDataConnection.Open();
                }
                string sSQLQuery = "SELECT * FROM GEM_CORONA_Variables";

                System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter(sSQLQuery, m_GemDataConnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                da.Dispose();
                return dt;
            }
            catch (Exception ex)
            {
                AVPSecsGemLog.avpSecsGemLogger.Error(ex.ToString());
            }
            finally
            {
                m_GemDataConnection.Close();
            }
            return null;
        }
        public static System.Data.DataTable Load_CORONA_GEM_Event()
        {
            if ((m_GemDataConnection != null))
            {
                m_GemDataConnection.Close();
                m_GemDataConnection = null;
            }
            m_GemDataConnection = new System.Data.OleDb.OleDbConnection(connStr);
            try
            {
                if (m_GemDataConnection.State == ConnectionState.Closed)
                {
                    m_GemDataConnection.Open();
                }
                string sSQLQuery = "SELECT * FROM GEM_CORONA_Events";

                System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter(sSQLQuery, m_GemDataConnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                da.Dispose();
                return dt;
            }
            catch (Exception ex)
            {
                AVPSecsGemLog.avpSecsGemLogger.Error(ex.ToString());
            }
            finally
            {
                m_GemDataConnection.Close();
            }
            return null;
        }
#endregion

#region "PVD GEM"
        public static System.Data.DataTable Load_PVDGEM_Alarm()
        {
            if ((m_GemDataConnection != null))
            {
                m_GemDataConnection.Close();
                m_GemDataConnection = null;
            }
            m_GemDataConnection = new System.Data.OleDb.OleDbConnection(connStr);
            try
            {
                if (m_GemDataConnection.State == ConnectionState.Closed)
                {
                    m_GemDataConnection.Open();
                }
                string sSQLQuery = "SELECT * FROM GEM_PVD_Alarms";

                System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter(sSQLQuery, m_GemDataConnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                da.Dispose();
                return dt;
            }
            catch (Exception ex)
            {
                AVPSecsGemLog.avpSecsGemLogger.Error(ex.ToString());
            }
            finally
            {
                m_GemDataConnection.Close();
            }
            return null;
        }
        public static System.Data.DataTable Load_PVDGEM_Variable()
        {
            if ((m_GemDataConnection != null))
            {
                m_GemDataConnection.Close();
                m_GemDataConnection = null;
            }
            m_GemDataConnection = new System.Data.OleDb.OleDbConnection(connStr);
            try
            {
                if (m_GemDataConnection.State == ConnectionState.Closed)
                {
                    m_GemDataConnection.Open();
                }
                string sSQLQuery = "SELECT * FROM GEM_PVD_Variables";

                System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter(sSQLQuery, m_GemDataConnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                da.Dispose();
                return dt;
            }
            catch (Exception ex)
            {
                AVPSecsGemLog.avpSecsGemLogger.Error(ex.ToString());
            }
            finally
            {
                m_GemDataConnection.Close();
            }
            return null;
        }
        public static System.Data.DataTable Load_PVDGEM_Event()
        {
            if ((m_GemDataConnection != null))
            {
                m_GemDataConnection.Close();
                m_GemDataConnection = null;
            }
            m_GemDataConnection = new System.Data.OleDb.OleDbConnection(connStr);
            try
            {
                if (m_GemDataConnection.State == ConnectionState.Closed)
                {
                    m_GemDataConnection.Open();
                }
                string sSQLQuery = "SELECT * FROM GEM_PVD_Events";

                System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter(sSQLQuery, m_GemDataConnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                da.Dispose();
                return dt;
            }
            catch (Exception ex)
            {
                AVPSecsGemLog.avpSecsGemLogger.Error(ex.ToString());
            }
            finally
            {
                m_GemDataConnection.Close();
            }
            return null;
        }
#endregion

#region "IBE GEM"
        public static System.Data.DataTable Load_IBEGEM_Alarm()
        {
            if ((m_GemDataConnection != null))
            {
                m_GemDataConnection.Close();
                m_GemDataConnection = null;
            }
            m_GemDataConnection = new System.Data.OleDb.OleDbConnection(connStr);
            try
            {
                if (m_GemDataConnection.State == ConnectionState.Closed)
                {
                    m_GemDataConnection.Open();
                }
                string sSQLQuery = "SELECT * FROM GEM_IBE_Alarms";

                System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter(sSQLQuery, m_GemDataConnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                da.Dispose();
                return dt;
            }
            catch (Exception ex)
            {
                AVPSecsGemLog.avpSecsGemLogger.Error(ex.ToString());
            }
            finally
            {
                m_GemDataConnection.Close();
            }
            return null;
        }
        public static System.Data.DataTable Load_IBEGEM_Variable()
        {
            if ((m_GemDataConnection != null))
            {
                m_GemDataConnection.Close();
                m_GemDataConnection = null;
            }
            m_GemDataConnection = new System.Data.OleDb.OleDbConnection(connStr);
            try
            {
                if (m_GemDataConnection.State == ConnectionState.Closed)
                {
                    m_GemDataConnection.Open();
                }
                string sSQLQuery = "SELECT * FROM GEM_IBE_Variables";

                System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter(sSQLQuery, m_GemDataConnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                da.Dispose();
                return dt;
            }
            catch (Exception ex)
            {
                AVPSecsGemLog.avpSecsGemLogger.Error(ex.ToString());
            }
            finally
            {
                m_GemDataConnection.Close();
            }
            return null;
        }
        public static System.Data.DataTable Load_IBEGEM_Event()
        {
            if ((m_GemDataConnection != null))
            {
                m_GemDataConnection.Close();
                m_GemDataConnection = null;
            }
            m_GemDataConnection = new System.Data.OleDb.OleDbConnection(connStr);
            try
            {
                if (m_GemDataConnection.State == ConnectionState.Closed)
                {
                    m_GemDataConnection.Open();
                }
                string sSQLQuery = "SELECT * FROM GEM_IBE_Events";

                System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter(sSQLQuery, m_GemDataConnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                da.Dispose();
                return dt;
            }
            catch (Exception ex)
            {
                AVPSecsGemLog.avpSecsGemLogger.Error(ex.ToString());
            }
            finally
            {
                m_GemDataConnection.Close();
            }
            return null;
        }
#endregion

#region "LOADLOCK-TM GEM"
        public static System.Data.DataTable Load_LoadLockGEM_Alarm()
        {
            if ((m_GemDataConnection != null))
            {
                m_GemDataConnection.Close();
                m_GemDataConnection = null;
            }
            m_GemDataConnection = new System.Data.OleDb.OleDbConnection(connStr);
            try
            {
                if (m_GemDataConnection.State == ConnectionState.Closed)
                {
                    m_GemDataConnection.Open();
                }
                string sSQLQuery = "SELECT * FROM GEM_LoadLock_Alarms";

                System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter(sSQLQuery, m_GemDataConnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                da.Dispose();
                return dt;
            }
            catch (Exception ex)
            {
                AVPSecsGemLog.avpSecsGemLogger.Error(ex.ToString());
            }
            finally
            {
                m_GemDataConnection.Close();
            }
            return null;
        }
        public static System.Data.DataTable Load_LoadLockGEM_Variable()
        {
            if ((m_GemDataConnection != null))
            {
                m_GemDataConnection.Close();
                m_GemDataConnection = null;
            }
            m_GemDataConnection = new System.Data.OleDb.OleDbConnection(connStr);
            try
            {
                if (m_GemDataConnection.State == ConnectionState.Closed)
                {
                    m_GemDataConnection.Open();
                }
                string sSQLQuery = "SELECT * FROM GEM_LoadLock_Variables";

                System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter(sSQLQuery, m_GemDataConnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                da.Dispose();
                return dt;
            }
            catch (Exception ex)
            {
                AVPSecsGemLog.avpSecsGemLogger.Error(ex.ToString());
            }
            finally
            {
                m_GemDataConnection.Close();
            }
            return null;
        }
        public static System.Data.DataTable Load_LoadLockGEM_Event()
        {
            if ((m_GemDataConnection != null))
            {
                m_GemDataConnection.Close();
                m_GemDataConnection = null;
            }
            m_GemDataConnection = new System.Data.OleDb.OleDbConnection(connStr);
            try
            {
                if (m_GemDataConnection.State == ConnectionState.Closed)
                {
                    m_GemDataConnection.Open();
                }
                string sSQLQuery = "SELECT * FROM GEM_LoadLock_Events";

                System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter(sSQLQuery, m_GemDataConnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                da.Dispose();
                return dt;
            }
            catch (Exception ex)
            {
                AVPSecsGemLog.avpSecsGemLogger.Error(ex.ToString());
            }
            finally
            {
                m_GemDataConnection.Close();
            }
            return null;
        }

        public static System.Data.DataTable Load_TMGEM_Alarm()
        {
            if ((m_GemDataConnection != null))
            {
                m_GemDataConnection.Close();
                m_GemDataConnection = null;
            }
            m_GemDataConnection = new System.Data.OleDb.OleDbConnection(connStr);
            try
            {
                if (m_GemDataConnection.State == ConnectionState.Closed)
                {
                    m_GemDataConnection.Open();
                }
                string sSQLQuery = "SELECT * FROM GEM_TM_Alarms";

                System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter(sSQLQuery, m_GemDataConnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                da.Dispose();
                return dt;
            }
            catch (Exception ex)
            {
                AVPSecsGemLog.avpSecsGemLogger.Error(ex.ToString());
            }
            finally
            {
                m_GemDataConnection.Close();
            }
            return null;
        }
        public static System.Data.DataTable Load_TMGEM_Variable()
        {
            if ((m_GemDataConnection != null))
            {
                m_GemDataConnection.Close();
                m_GemDataConnection = null;
            }
            m_GemDataConnection = new System.Data.OleDb.OleDbConnection(connStr);
            try
            {
                if (m_GemDataConnection.State == ConnectionState.Closed)
                {
                    m_GemDataConnection.Open();
                }
                string sSQLQuery = "SELECT * FROM GEM_TM_Variables";

                System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter(sSQLQuery, m_GemDataConnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                da.Dispose();
                return dt;
            }
            catch (Exception ex)
            {
                AVPSecsGemLog.avpSecsGemLogger.Error(ex.ToString());
            }
            finally
            {
                m_GemDataConnection.Close();
            }
            return null;
        }
        public static System.Data.DataTable Load_TMGEM_Event()
        {
            if ((m_GemDataConnection != null))
            {
                m_GemDataConnection.Close();
                m_GemDataConnection = null;
            }
            m_GemDataConnection = new System.Data.OleDb.OleDbConnection(connStr);
            try
            {
                if (m_GemDataConnection.State == ConnectionState.Closed)
                {
                    m_GemDataConnection.Open();
                }
                string sSQLQuery = "SELECT * FROM GEM_TM_Events";

                System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter(sSQLQuery, m_GemDataConnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                da.Dispose();
                return dt;
            }
            catch (Exception ex)
            {
                AVPSecsGemLog.avpSecsGemLogger.Error(ex.ToString());
            }
            finally
            {
                m_GemDataConnection.Close();
            }
            return null;
        }
#endregion
        
//#region "Loader GEM"
//        public static System.Data.DataTable Load_Loader_Alarms()
//        {
//            if (m_GemDataConnection != null)
//            {
//                m_GemDataConnection.Close();
//                m_GemDataConnection = null;
//            }
//            m_GemDataConnection = new System.Data.OleDb.OleDbConnection(connStr);
//            try
//            {
//                if (m_GemDataConnection.State == ConnectionState.Closed)
//                {
//                    m_GemDataConnection.Open();
//                }
//                string sSQLQuery = "SELECT * FROM GEM_Loader_Alarms";
//                System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter(sSQLQuery, m_GemDataConnection);
//                DataTable dt = new DataTable();
//                da.Fill(dt);
//                da.Dispose();
//                return dt;
//            }
//            catch (Exception ex)
//            {
//                AVPSecsGemLog.avpSecsGemLogger.Error(ex.ToString());
//            }
//            finally
//            {
//                m_GemDataConnection.Close();
//            }
//            return null;
//        }

//        public static System.Data.DataTable Load_Loader_Events()
//        {
//            if (m_GemDataConnection != null)
//            {
//                m_GemDataConnection.Close();
//                m_GemDataConnection = null;
//            }
//            m_GemDataConnection = new System.Data.OleDb.OleDbConnection(connStr);
//            try
//            {
//                if (m_GemDataConnection.State == ConnectionState.Closed)
//                {
//                    m_GemDataConnection.Open();
//                }
//                string sSQLQuery = "SELECT * FROM GEM_Loader_Events";
//                System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter(sSQLQuery, m_GemDataConnection);
//                DataTable dt = new DataTable();
//                da.Fill(dt);
//                da.Dispose();
//                return dt;
//            }
//            catch (Exception ex)
//            {
//                AVPSecsGemLog.avpSecsGemLogger.Error(ex.ToString());
//            }
//            finally
//            {
//                m_GemDataConnection.Close();
//            }
//            return null;
//        }

//        public static System.Data.DataTable Load_Loader_Variables()
//        {
//            if (m_GemDataConnection != null)
//            {
//                m_GemDataConnection.Close();
//                m_GemDataConnection = null;
//            }
//            m_GemDataConnection = new System.Data.OleDb.OleDbConnection(connStr);
//            try
//            {
//                if (m_GemDataConnection.State == ConnectionState.Closed)
//                {
//                    m_GemDataConnection.Open();
//                }
//                string sSQLQuery = "SELECT * FROM GEM_Loader_Variables";
//                System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter(sSQLQuery, m_GemDataConnection);
//                DataTable dt = new DataTable();
//                da.Fill(dt);
//                da.Dispose();
//                return dt;
//            }
//            catch (Exception ex)
//            {
//                AVPSecsGemLog.avpSecsGemLogger.Error(ex.ToString());
//            }
//            finally
//            {
//                m_GemDataConnection.Close();
//            }
//            return null;
//        }
//#endregion
       
        public static System.Data.DataTable Load_Common_Alarm()
        {
            return null;
        }
        public static System.Data.DataTable Load_Common_Variable()
        {
            return null;
        }
        public static System.Data.DataTable Load_Common_Event()
        {
            return null;
        }
    }
}