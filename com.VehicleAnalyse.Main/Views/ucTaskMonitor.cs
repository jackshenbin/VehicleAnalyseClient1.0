using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bocom.ImageAnalysisClient.App.Framework;
using WinFormAppUtil;

namespace Bocom.ImageAnalysisClient.App.Views
{
    public partial class ucTaskMonitor : UserControl
    {
        public ucTaskMonitor()
        {
            InitializeComponent();
        }

        private void ucTaskMonitor_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                Framework.Container.Instance.EvtAggregator.GetEvent<UserLoginEvent>().Subscribe(OnUserLoggedin);
                ucTaskDetails1.Init();
                ucTaskList1.Init();
                ucOutputWindow1.Init();
            }
        }

        private void OnUserLoggedin(LoginToken token)
        {
            ucTaskList1.Enabled = true;
        }
    }
}
