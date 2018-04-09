using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Bocom.ImageAnalysisClient.App.Framework;
using WinFormAppUtil;

namespace Bocom.ImageAnalysisClient.App.Views
{
    public partial class XtraUserControl1 : DevExpress.XtraEditors.XtraUserControl
    {
        private int m_Blank = 0;
        public XtraUserControl1()
        {
            InitializeComponent();
        }

        internal void Init()
        {
            dockPanel2.Height = this.Height - 400;
            dockPanel2.Hide();
        }

        private void XtraUserControl1_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                Framework.Container.Instance.EvtAggregator.GetEvent<UserLoginEvent>().Subscribe(OnUserLoggedin);
                Framework.Container.Instance.EvtAggregator.GetEvent<OutputWindowSwitch>().Subscribe(OnOutputWindowSwitch);
                ucTaskDetails1.Init();
                ucTaskList1.Init();
                ucOutputWindow1.Init();

                m_Blank = this.Height - dockPanel2.Height - ucTaskDetails1.Bottom;
            }
        }

        private void OnUserLoggedin(LoginToken token)
        {
            ucTaskList1.Enabled = true;
        }

        private void OnOutputWindowSwitch(bool isOn)
        {
            if (isOn)
            {
                dockPanel2.Show();
            }
            else
            {
                dockPanel2.Hide();
            }
            ucOutputWindow1.SwitchOn = isOn;
        }

        private void dockPanel1_SizeChanged(object sender, EventArgs e)
        {
            ucTaskDetails1.Left = dockPanel1.Width + 20;
        }

        private void dockPanel2_SizeChanged(object sender, EventArgs e)
        {
            int temp = this.Height - dockPanel2.Height - 32;

            //if (ucTaskDetails1.Height > temp)
            //{
                ucTaskDetails1.Height = temp;
            // }
        }
    }
}
