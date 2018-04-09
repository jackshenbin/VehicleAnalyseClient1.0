using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Docking;
using com.VehicleAnalyse.Main.Framework;
using Microsoft.Practices.Prism.Events;
using System.IO;
using com.VehicleAnalyse.Service;
using System.Reflection;
using System.Xml;

namespace com.VehicleAnalyse.Main.Views
{
    public partial class ucTaskPage : DevExpress.XtraEditors.XtraUserControl
    {
        #region Fields
        
        private bool m_Loaded = false;

        #endregion

        #region Constructors
        
        public ucTaskPage()
        {
            InitializeComponent();
            this.HandleDestroyed += new EventHandler(ucTaskPage_HandleDestroyed);
            Framework.Container.Instance.EvtAggregator.GetEvent<TaskStatisticUpdateEvent>().Subscribe(OnTaskStatisticUpdated);

        }

        void ucTaskPage_HandleDestroyed(object sender, EventArgs e)
        {
            Framework.Container.Instance.EvtAggregator.GetEvent<TaskStatisticUpdateEvent>().Unsubscribe(OnTaskStatisticUpdated);
        }

        #endregion

        #region Event handlers
        
        //private void dockPanel1_SizeChanged(object sender, EventArgs e)
        //{
        //    if (!m_Loaded)
        //    {
        //        return;
        //    }

        //    if (dockPanel1.Visibility == DockVisibility.Visible)
        //    {
        //        this.ucTaskList21.Height = this.Height - ucTaskList21.Top - dockPanel1.Height - 10;
        //        this.ucTaskList21.Width = this.Width - 12;
        //    }
        //}

        private void dockPanel1_ClosingPanel(object sender, DevExpress.XtraBars.Docking.DockPanelCancelEventArgs e)
        {

        }

        //private void dockPanel1_VisibilityChanged(object sender, DevExpress.XtraBars.Docking.VisibilityChangedEventArgs e)
        //{

        //    if (!m_Loaded)
        //    {
        //        return;
        //    }

        //    if (e.Visibility == DockVisibility.AutoHide ||
        //        e.Visibility == DockVisibility.Hidden)
        //    {
        //        this.ucTaskList21.Height = this.Height - ucTaskList21.Top - 25;
        //        this.ucTaskList21.Width = this.Width - 12;
        //    }
        //    else
        //    {
        //        this.ucTaskList21.Height = this.Height - ucTaskList21.Top - dockPanel1.Height - 10;
        //        this.ucTaskList21.Width = this.Width - 12;
        //    }
        //}

        private void ucTaskPage_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                m_Loaded = true;
                ucTaskList21.Init();
                ucOutputWindow1.Init();
                ucOutputWindow1.SwitchOn = true;
                //this.ucTaskList21.Height = this.Height - ucTaskList21.Top - dockPanel1.Height - 10;
                //this.ucTaskList21.Width = this.Width - 12;
                //object o = AppDomain.CurrentDomain.GetData("OCXContainer");
                //if (o != null)
                //{

                //    groupControl1.Visible = false;
                new System.Threading.Thread(DoAutoLogin).Start();
                //}
            }
        }

        private void DoAutoLogin()
        {
            if (InvokeRequired)
            {
                this.Invoke(new ErrorEventHandler(btnLogin_Click), null, null);
            }
            else
            {
                btnLogin_Click(null, null);
            }
        }
        //private void DoAutoLogin()
        //{
        //    Framework.Container.Instance.EvtAggregator.GetEvent<AnalyseMessageEvent>().Publish(new Tuple<uint, string>(11, "开始自动连接服务器请等待...."));

        //    System.Threading.Thread.Sleep(5000);
        //    lock (this)
        //    {
        //        while (true)
        //        {
        //            DataModel.ConnectionParam ip = Framework.Environment.IPList.GetNext();
        //            if (ip == null)
        //            {
        //                Framework.Container.Instance.EvtAggregator.GetEvent<AnalyseMessageEvent>().Publish(new Tuple<uint, string>(11, "无可用服务器资源."));
        //                break;
        //            }
        //            int ret = AutoLogin(ip);
        //            if (ret == 1 || ret == 2)
        //                break;
        //            else
        //                System.Threading.Thread.Sleep(5000);
        //        }
        //    }
        //}

        ///// <summary>
        ///// modify by shenbin 20160217,change return bool to int
        ///// </summary>
        ///// <param name="connparam">1 ok,2 server in use, 3 anlyse error ,4 other error</param>
        ///// <returns></returns>
        //private int  AutoLogin(DataModel.ConnectionParam connparam)
        //{
        //    //if (InvokeRequired)
        //    //{
        //    //    return Convert.ToBoolean(this.Invoke(new Func<DataModel.ConnectionParam, bool>(AutoLogin),connparam));
        //    //}
        //    //else
        //    {
        //        int ret = 0;
        //        Assembly asm = Assembly.GetExecutingAssembly();

        //        //string configFile = Path.Combine(Directory.GetParent(asm.Location).FullName, "OCXLogin.xml");
        //        //if (System.IO.File.Exists(configFile))
        //        {
        //            /*
        //            <Login>
        //            <IP>192.168.42.209</IP>
        //            <Port>8002</Port>
        //            <LocalPort>4096</LocalPort>
        //            <User>root</User>
        //            <Pass>123456</Pass>
        //            </Login>
        //             */
        //            try
        //            {

        //                //XmlDocument doc = new XmlDocument();
        //                //doc.Load(configFile);
        //                //string ip = doc.SelectSingleNode("//IP").InnerText;
        //                //uint port = Convert.ToUInt32(doc.SelectSingleNode("//Port").InnerText);
        //                //uint localport = Convert.ToUInt32(doc.SelectSingleNode("//LocalPort").InnerText);
        //                //string user = doc.SelectSingleNode("//User").InnerText;
        //                //string pass = doc.SelectSingleNode("//Pass").InnerText;
        //                string ip = connparam.IPAddress;
        //                uint port = (uint)connparam.Port;
        //                //uint localport = (uint)connparam.LocalServerPort;
        //                string user = connparam.DeviceNo;
        //                string pass = connparam.DeviceNo;
        //                ViewModels.LoginViewModel vm = new ViewModels.LoginViewModel();
        //                vm.ServerIP = ip;
        //                vm.ServerPort = port;
        //                //vm.LocalPort = localport;
        //                vm.UserName = user;
        //                vm.Password = pass;
        //                vm.RememberPassword = false;
        //                vm.CustomPortSettings = true;

        //                Framework.Container.Instance.TaskManager.Init();
        //                if (vm.Commit())
        //                {

        //                    System.Threading.Thread.Sleep(1000);
        //                    if (!Framework.Container.Instance.TaskManager.Initialized)
        //                        return 2;

        //                    if (Framework.Environment.LoggedinToken != null)
        //                    {
        //                        SetButtonEnable(btnLogin, false);
        //                        //barStatusLogin.Caption = string.Format("登录服务器: {0}", Framework.Environment.LoggedinToken.ServerIP);
        //                        //barStatusAnalyse.Caption = string.Format("");
        //                        if (Framework.Environment.ManualRevise && File.Exists(Framework.Environment.ManualReviseFile))
        //                        {
        //                            Framework.Container.Instance.TaskManager.Revisor = new AnalyseResultReviseFromTxtFile(Framework.Environment.ManualReviseFile);
        //                            Framework.Container.Instance.TaskManager.Revisor.ReviseByFile = Framework.Environment.ManualReviseByFile;
        //                        }

        //                        Framework.Container.Instance.EvtAggregator.GetEvent<UserLoginEvent>().Publish(Framework.Environment.LoggedinToken);
        //                    }


        //                    //if (!Framework.Container.Instance.ImageAnalysisService.Running)
        //                    //{
        //                    //    if (Framework.Container.Instance.ImageAnalysisService.Start())
        //                    //    {
        //                    //        Framework.Container.Instance.TaskManager.Connected = true;
        //                    //        Framework.Container.Instance.TaskManager.Running = true;
        //                    //    }
        //                    //    else
        //                    //    {
        //                    //        Framework.Container.Instance.InteractionService.ShowMessageBox("开始分析失败",
        //                    //            Framework.Environment.PROGRAM_NAME,
        //                    //            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //                    //        Framework.Container.Instance.EvtAggregator.GetEvent<AnalyseMessageEvent>().Publish(new Tuple<uint, string>(11, "开始分析失败"));
        //                    //        return 3;
        //                    //    }
        //                    //}
        //                    //else
        //                    //{
        //                    //    Framework.Container.Instance.TaskManager.Running = true;
        //                    //}

        //                    Framework.Container.Instance.EvtAggregator.GetEvent<AnalyseMessageEvent>().Publish(new Tuple<uint, string>(11, "开始分析 ..."));

        //                    ret = 1;
        //                }
        //            }
        //            catch
        //            {
        //                return 4;
        //            }

        //        }
        //        return ret;
        //    }
        //}


        private void SetButtonEnable(SimpleButton bt, bool enable)
        {
            if (bt.InvokeRequired)
            {
                bt.Invoke(new Action<SimpleButton, bool>(SetButtonEnable), bt, enable);
            }
            else
            {
                bt.Enabled = enable;
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //if (AutoLogin())
            //    return;

            using (FormLogin dlg = new FormLogin())
            {
                dlg.StartPosition = FormStartPosition.CenterParent;
                if (DialogResult.OK == dlg.ShowDialog())
                {
                    //System.Threading.Thread.Sleep(1000);

                    if (Framework.Environment.LoggedinToken != null)
                    {
                        btnLogin.Enabled = false;
                        ucTaskList21.Enabled = true;
                        //barStatusLogin.Caption = string.Format("登录服务器: {0}", Framework.Environment.LoggedinToken.ServerIP);
                        //barStatusAnalyse.Caption = string.Format("");
                        Framework.Container.Instance.TaskManager.RealTimeTaskSendCount = Framework.Environment.RealTimeTaskSendCount;

                        Framework.Container.Instance.TaskManager.EncodingType = Framework.Environment.URLEncodingType;

                        Framework.Container.Instance.TaskManager.Init(
                            Framework.Environment.ServerIP, (uint)Framework.Environment.TaskPort,
                            Framework.Environment.PicIP, (uint)Framework.Environment.PicPort,
                            Framework.Environment.SearchIP, (uint)Framework.Environment.SearchPort);
                        //if (Framework.Environment.ManualRevise && File.Exists(Framework.Environment.ManualReviseFile))
                        //{
                        //    Framework.Container.Instance.TaskManager.Revisor = new AnalyseResultReviseFromTxtFile(Framework.Environment.ManualReviseFile);
                        //    Framework.Container.Instance.TaskManager.Revisor.ReviseByFile = Framework.Environment.ManualReviseByFile;
                        //}

                        Framework.Container.Instance.EvtAggregator.GetEvent<UserLoginEvent>().Publish(Framework.Environment.LoggedinToken);
                        Framework.Container.Instance.EvtAggregator.GetEvent<TaskModifiedEvent>().Publish(Framework.Container.Instance.TaskManager.GetAllTasks());
                    }
                }
                else
                {
                    Framework.Environment.LoggedinToken = null;
                    Framework.Container.Instance.EvtAggregator.GetEvent<UserLoginEvent>().Publish(Framework.Environment.LoggedinToken);
                }
            }
            
        }



        private void OnTaskStatisticUpdated(Tuple<int, int> tuple)
        {
            this.labelControl1.Text = string.Format("任务列表: {0} (完成)/{1}", tuple.Item1, tuple.Item2);
        }


        #endregion

    }
}
