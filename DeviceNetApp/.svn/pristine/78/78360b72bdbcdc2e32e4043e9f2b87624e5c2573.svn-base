using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DeviceNetApp.Lib;
using DeviceNetApp.Bussiness;

namespace DeviceNetApp
{
    public partial class TypePassConfirmFrm : Form
    {
        private Boolean m_blConfirmOK = false;
        public Boolean ConfirmOK
        {
            get { return m_blConfirmOK; }
            set { m_blConfirmOK = value; }
        }

        private String m_strPassword = String.Empty;
        public String Password
        {
            get { return m_strPassword; }
            set { m_strPassword = value; }
        }

        public TypePassConfirmFrm()
        {
            InitializeComponent();
            this.Icon = IconHelper.GetAppIcon();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                ConfigurationData objConfig = DeviceNetCore.Instance().ConfigData;
                string str_Pass = objConfig.PasswordExit.Password;
                if (str_Pass != txtPassword.Text.Trim())
                {
                    ConfirmOK = false;
                    lbErrorMassage.Text = "Wrong password! Please try again";
                    return;
                }

                // Log in successfully
                ConfirmOK = true;
                Password = txtPassword.Text;
                this.Hide();
            }
            catch (Exception ex)
            {
                
                //nothing
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ConfirmOK = false;
            this.Hide();
        }

        private void TypePassConfirmFrm_Load(object sender, EventArgs e)
        {
            lbErrorMassage.Text = "";
        }

        private void TypePassConfirmFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ConfirmOK = false;
            this.Hide();
        }

        private void TypePassConfirmFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnOk_Click(sender, e);
            }
            else if (e.KeyChar == (char)Keys.Escape)
            {
                btnCancel_Click(sender, e);
            }
        }
    }
}
