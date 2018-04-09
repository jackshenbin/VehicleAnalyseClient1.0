using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using com.VehicleAnalyse.Main.ViewModels;
using AppUtil;
using log4net;

namespace com.VehicleAnalyse.Main.Views
{
    public partial class FormLogin : DevExpress.XtraEditors.XtraForm
    {

        private LoginViewModel m_ViewModel;

        public FormLogin()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(FormLogin_FormClosing);

            m_ViewModel = new LoginViewModel();

            textEditServerIP.DataBindings.Add(new Binding("Value", m_ViewModel, "ServerIP"));
            textEditSearchIP.DataBindings.Add(new Binding("Value", m_ViewModel, "SearchIP"));
            textEditUploadIP.DataBindings.Add(new Binding("Value", m_ViewModel, "PicIP"));
            textEditUser.DataBindings.Add(new Binding("Text", m_ViewModel, "UserName"));
            textEditPass.DataBindings.Add(new Binding("Text", m_ViewModel, "Password"));

            Framework.Container.Instance.VVMDataBindings.AddBinding(checkEdit1, "Checked", m_ViewModel, "RememberPassword");

            Framework.Container.Instance.VVMDataBindings.AddBinding(spinEditServerPort, "Value", m_ViewModel, "ServerPort");
            Framework.Container.Instance.VVMDataBindings.AddBinding(spinEditSearchPort, "Value", m_ViewModel, "SearchPort");
            Framework.Container.Instance.VVMDataBindings.AddBinding(spinEditUploadPort, "Value", m_ViewModel, "PicPort");
            
            //if(Framework.Environment.UseCustomTitle)
            //    this.BackgroundImage = Framework.Environment.CustomLogo;

        }

        void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            //ILog log = LogService.GetLog("klasjdfksad");
            //log.Fatal("kajwoqaweriwq");
            //log.Info("Info");
            //log.Debug("Debug");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (m_ViewModel.Commit())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

    }
}