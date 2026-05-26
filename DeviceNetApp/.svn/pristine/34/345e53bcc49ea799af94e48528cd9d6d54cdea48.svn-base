using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DeviceNetApp.Bussiness;
using DeviceNetApp.Lib;
using Microsoft.Win32;
using System.Threading;

namespace DeviceNetApp
{
    public delegate void deleExitApp();
    public partial class DeviceNetApp : Form
    {
        private delegate void SetExitCallBack(object sender, EventArgs e);
        DeviceNetCore m_objDeviceCore = null;

        SendMessage _formSendMessage = null;

        public DeviceNetApp()
        {
            InitializeComponent();
            this.Icon = IconHelper.GetAppIcon();
            notifyIcon1.Icon = IconHelper.GetAppIcon();
        }

        private void DeviceNetApp_Load(object sender, EventArgs e)
        {
            SystemEvents.SessionEnding += new SessionEndingEventHandler(SystemEvents_SessionEnding);
            Initialize();
        }

        Boolean Initialize()
        {
            try
            {
                m_objDeviceCore = DeviceNetCore.Instance();
                if (!m_objDeviceCore.Initialize())
                {
                    m_objDeviceCore.evtExitApp += new deleExitApp(m_objDeviceCore_evtExitApp);
                    return false;
                }
                m_objDeviceCore.evtExitApp += new deleExitApp(m_objDeviceCore_evtExitApp);

                //Default start Device-net app show at task-bar position.
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(5000);
                notifyIcon1.BalloonTipTitle = "DeviceNetApp:" + lblDeviceNetActive.Text;
                notifyIcon1.BalloonTipText = GetConnectStatus();
                
            }
            catch (System.Exception ex)
            {
                Logger.Error(ex.ToString());
            }
            return true;
        }

        void m_objDeviceCore_evtExitApp()
        {
            if (this.InvokeRequired)
            {
                SetExitCallBack d = new SetExitCallBack(Exit_Click);
                this.BeginInvoke(d, new object[] { null, null });
            }
            else
            {
                Exit_Click(null, null);
            }
        }

        private void DeviceNetApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (m_objDeviceCore != null && !m_objDeviceCore.DeviceConnection.IsConnectedWithAVP)
                {
                    m_objDeviceCore.Uninitialize();
                }
                else if (m_objDeviceCore.DeviceConnection.IsConnectedWithAVP)
                {
                    String strMsg = "Still connected with AVP. Will be in notification task bar";
                    MessageBox.Show(strMsg, "PVD6S - Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Minimizee app
                    this.WindowState = FormWindowState.Minimized;
                    notifyIcon1.Visible = true;
                    notifyIcon1.ShowBalloonTip(5000);
                    notifyIcon1.BalloonTipTitle = "DeviceNetApp:" + lblDeviceNetActive.Text;
                    notifyIcon1.BalloonTipText = GetConnectStatus();
                    this.Hide();
                    e.Cancel = true;
                }
            }
            catch (System.Exception ex)
            {
                Logger.Error(ex.ToString());
            }
        }
        /// <summary>
        /// GUI Update Timer
        /// </summary>
        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            UpdateTimer.Enabled = false;

            try
            {
                UpdateGUI();
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString());
            }
            
            UpdateTimer.Enabled = true;
        }


        private void UpdateGUI()
        {
            try
            {
                if (m_objDeviceCore != null)
                {
                    if (m_objDeviceCore.IsConnectToAVP)
                    {
                        lbAVPConnectStatus.Text = "Connected";
                        lbAVPConnectStatus.ForeColor = System.Drawing.Color.Blue;
                    }
                    else
                    {
                        lbAVPConnectStatus.Text = "Disconnected";
                        lbAVPConnectStatus.ForeColor = System.Drawing.Color.Red;
                    }

                    if (m_objDeviceCore.DeviceNetActive)
                    {
                        lblDeviceNetActive.Text = "Scanning";
                        lblDeviceNetActive.ForeColor = System.Drawing.Color.Blue;
                    }
                    else
                    {
                        lblDeviceNetActive.Text = "Stop Scan";
                        lblDeviceNetActive.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
            catch (System.Exception ex)
            {
                Logger.Error(ex.ToString());
            }
        }

        private void DeviceNetApp_Resize(object sender, EventArgs e)
        {
            ResizeWindow();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                notifyIcon1.Visible = false;

                // For main from
                this.Show();
                this.ShowInTaskbar = true;
                this.WindowState = FormWindowState.Normal;
            }   
            catch (System.Exception ex)
            {
                Logger.Error(ex.ToString());
            }
        }

        private void ResizeWindow()
        {
            try
            {
                if (FormWindowState.Minimized == this.WindowState && this.Visible == true)
                {
                    notifyIcon1.Visible = true;
                    notifyIcon1.ShowBalloonTip(5000);
                    notifyIcon1.BalloonTipTitle = "DeviceNetApp:" + lblDeviceNetActive.Text;
                    notifyIcon1.BalloonTipText = GetConnectStatus();
                    this.Hide();
                }
                else if (FormWindowState.Normal == this.WindowState)
                {
                    notifyIcon1.Visible = false;
                }
            }
            catch (System.Exception ex)
            {
                Logger.Error(ex.ToString());
            }
        }

        private void Restore_Click(object sender, EventArgs e)
        {
            try
            {
                notifyIcon1.Visible = false;

                // For main from
                this.Show();
                this.ShowInTaskbar = true;
                this.WindowState = FormWindowState.Normal;
            }
            catch (System.Exception ex)
            {
                Logger.Error(ex.ToString());
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            try
            {
                ConfigurationData objConfig = DeviceNetCore.Instance().ConfigData;
                string str_Pass = objConfig.PasswordExit.Password;

                //Don't show pop-up confirm when receive cmd exitApp
                if (sender != null && e != null && objConfig.PasswordExit.Password != string.Empty)
                {
                    TypePassConfirmFrm frm = new TypePassConfirmFrm();
                    frm.ShowDialog();
                    if (!frm.ConfirmOK)
                    {
                        return;
                    }
                }

                try
                {
                    if (_formSendMessage != null)
                    {
                        _formSendMessage.Close();
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error(ex.ToString());
                }

                if (m_objDeviceCore != null)
                {
                    m_objDeviceCore.TurnOffAllIG();
                }
                
                if (m_objDeviceCore != null)
                {
                    m_objDeviceCore.Uninitialize();
                }
                this.Dispose();
                Application.Exit();
            }
            catch (System.Exception ex)
            {
                Logger.Error(ex.ToString());
            }
        }

        private string GetConnectStatus()
        {
            string sConnectStatus = string.Empty;
            if (m_objDeviceCore != null)
            {
                if (m_objDeviceCore.IsConnectToAVP)
                {
                    sConnectStatus = "Connected";
                }
                else
                {
                    sConnectStatus = "Disconnected";
                }
            }

            return sConnectStatus;
        }

        private void SystemEvents_SessionEnding(object sender, SessionEndingEventArgs e)
        {
            try
            {
                if (m_objDeviceCore != null && m_objDeviceCore.DeviceController != null)
                {
                    m_objDeviceCore.DeviceController.CleanUp();
                }
                SystemEvents.SessionEnding -= new SessionEndingEventHandler(SystemEvents_SessionEnding);
            }
            catch (System.Exception ex)
            {
                Logger.Error(ex.ToString());
            }
        }

        private void DeviceNetApp_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Control && e.Alt && e.KeyValue == (int)Keys.Space)
                {
                    SendMessage formSendMessage = new SendMessage();

                    _formSendMessage = formSendMessage;

                    formSendMessage.Show();
                }
            }
            catch (System.Exception ex)
            {
                Logger.Error(ex.ToString());
            }
        }
    }
}