using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using com.VehicleAnalyse.Main.Framework;
using AppUtil;
using Microsoft.Practices.Prism.Events;
using System.Reflection;

namespace com.VehicleAnalyse.Main
{
    public partial class XtraMainForm : DevExpress.XtraEditors.XtraForm
    {
        public XtraMainForm()
        {
            InitializeComponent();

            if (!DesignMode)
            {
                if (Framework.Environment.UseCustomTitle)
                {
                    this.Text = Framework.Environment.CustomTitle;
                    this.pictureEdit1.Image = Framework.Environment.CustomLogo;
                }
                else
                {
                    this.Text = string.Format("{0} ({1})", this.Text, Framework.Environment.Version);
                }
            }
        }

        private void XtraMainForm_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                //this.Hide();
                //this.WindowState = FormWindowState.Maximized;
                //this.Show();
                this.ucTaskPage1 = new com.VehicleAnalyse.Main.Views.ucTaskPage();
                this.ucResultPage1 = new com.VehicleAnalyse.Main.Views.ucResultPage();
                this.ucCompareSearchResultPage1 = new com.VehicleAnalyse.Main.Views.ucCompareSearchResultPage();
                // ucTaskPage1
                // 
                this.ucTaskPage1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
                this.ucTaskPage1.Appearance.Options.UseBackColor = true;
                this.ucTaskPage1.Dock = System.Windows.Forms.DockStyle.Fill;
                this.ucTaskPage1.Location = new System.Drawing.Point(0, 0);
                this.ucTaskPage1.Name = "ucTaskPage1";
                this.ucTaskPage1.Size = new System.Drawing.Size(820, 456);
                this.ucTaskPage1.TabIndex = 0;
                // 
                // ucResultPage1
                // 
                this.ucResultPage1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
                this.ucResultPage1.Appearance.Options.UseBackColor = true;
                this.ucResultPage1.Dock = System.Windows.Forms.DockStyle.Fill;
                this.ucResultPage1.Location = new System.Drawing.Point(0, 0);
                this.ucResultPage1.Name = "ucResultPage1";
                this.ucResultPage1.Size = new System.Drawing.Size(820, 456);
                this.ucResultPage1.TabIndex = 0;
                // 
                // ucCompareSearchResultPage1
                // 
                this.ucCompareSearchResultPage1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
                this.ucCompareSearchResultPage1.Appearance.Options.UseBackColor = true;
                this.ucCompareSearchResultPage1.Dock = System.Windows.Forms.DockStyle.Fill;
                this.ucCompareSearchResultPage1.Location = new System.Drawing.Point(0, 0);
                this.ucCompareSearchResultPage1.Name = "ucCompareSearchResultPage1";
                this.ucCompareSearchResultPage1.Size = new System.Drawing.Size(820, 456);
                this.ucCompareSearchResultPage1.TabIndex = 0;
                // 

                this.xtraTabPage1.Controls.Add(this.ucTaskPage1);
                this.xtraTabPage2.Controls.Add(this.ucResultPage1);
                this.xtraTabPage3.Controls.Add(this.ucCompareSearchResultPage1);

                Framework.Container.Instance.MainControl  = this;
                Framework.Container.Instance.EvtAggregator.GetEvent<UserLoginEvent>().Subscribe(OnUserLoggedin);
            }
        }
        
        private void OnUserLoggedin(LoginToken token)
        {
            if (token == null)
                this.Close();
            else
                barItemStatus.Caption = string.Format("登录服务器: {0}", Framework.Environment.LoggedinToken.ServerIP);
        }




        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            //binaryPowerTabStrip1.SelectedTabPage = binaryPowerTabStrip1.TabPages[xtraTabControl1.SelectedTabPageIndex];
        }


        private void XtraMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Framework.Environment.LoggedinToken != null)
            {
                if (DialogResult.No == Framework.Container.Instance.InteractionService.ShowMessageBox("是否确定退出?", Framework.Environment.PROGRAM_NAME,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    e.Cancel = true;
                }
                else
                {
                    Framework.Container.Instance.TaskManager.Close();
                    AppUtil.Common.Utils.Clear();
                }
            }
            else
                AppUtil.Common.Utils.Clear();
        }

        private void simpleButtonConfig_Click(object sender, EventArgs e)
        {
            com.VehicleAnalyse.Main.Views.FormConfig f = new com.VehicleAnalyse.Main.Views.FormConfig();
            f.ShowDialog();
        }

        private void bubbleButton1_Click(object sender, DevComponents.DotNetBar.ClickEventArgs e)
        {
            xtraTabControl1.SelectedTabPageIndex = 0;
        }

        private void bubbleButton2_Click(object sender, DevComponents.DotNetBar.ClickEventArgs e)
        {
            xtraTabControl1.SelectedTabPageIndex = 1;

        }
    }
}