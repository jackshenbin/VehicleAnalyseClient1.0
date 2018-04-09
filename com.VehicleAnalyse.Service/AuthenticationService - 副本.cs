using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bocom.ImageAnalysisClient.DataModel;
using Bocom.ImageAnalysisClient.Service.Interop;
using WinFormAppUtil;
using System.Threading.Tasks;
using System.Threading;

namespace Bocom.ImageAnalysisClient.Service
{
    public class AuthenticationService
    {
        public IpList IPList;

        private static readonly int INTERVAL_RECONNECT = 10; // seconds

        #region Events & fields

        public event EventHandler Connected;
        public event EventHandler Closed;
        public event EventHandler ReConnectStart;

        public event Action<string> Message;

        public event Action<bool> ReConnectFinished;
   
        private TFuncStartNtfCB m_funcOnStarted;
        private TFuncStopNtfCB m_funcOnStopped;
       
        private bool m_IsConnected;
        private bool m_Running = true;
        private bool m_Connected;
        private object m_SyncObjReconnect = new object();

        private TaskFactory m_taskFactory;


        private CancellationTokenSource m_TokenSource;

        private System.Threading.Tasks.Task m_LoopReconnectTask;

        private ManualResetEvent m_MREReconnect;
        #endregion

        public bool Connect(ConnectionParam param)
        {
            bool bRet = false;

            if(param != null)
            {
                MyLog4Net.Container.Instance.Log.InfoFormat("登录站点 {0} ... ", param.IPAddress);
                m_funcOnStarted = OnStarted;
                m_funcOnStopped = OnStopped;
               
                NETSDK_LOGIN_PARAM loginParam = param.ToLoginParam();
                bRet = InteropService.Connect(loginParam, m_funcOnStarted, m_funcOnStopped);
                m_IsConnected = bRet;
                MyLog4Net.Container.Instance.Log.InfoFormat("登录站点 {0}, {1}", param.IPAddress, bRet ? "成功" : "失败");
            }

            return bRet;
        }

        public bool Close()
        {
            bool bRet = false;
            
            if(m_IsConnected)
            {
                MyLog4Net.Container.Instance.Log.InfoFormat("断开服务连接 ... ");
                bRet = InteropService.Close();
            }

            return bRet;
        }

        #region Event handlers

        private void OnStarted()
        {
            // 登录成功
        }

        private void OnStopped()
        {
            if (Closed != null)
            {
                Closed(this, EventArgs.Empty);
            }
        }
        public bool RunningServer
        {
            get { return m_Running; }
            set
            {
                m_Running = value;
                if (m_Running)
                {
                    if (!m_Connected)
                    {
                        // 触发重连
                        ConnectedServer = false;
                    }
                }
            }
        }

        public bool ConnectedServer
        {
            get
            {
                return m_Connected;
            }
            set
            {
                lock (m_SyncObjReconnect)
                {
                    if (m_Connected != value)
                    {
                        m_Connected = value;
                    }
                    if (!m_IsConnected && !m_Connected)
                    {
                        if (m_taskFactory == null)
                        {
                            m_MREReconnect = new ManualResetEvent(true);
                            m_taskFactory = new TaskFactory();
                            m_TokenSource = new CancellationTokenSource();
                            m_LoopReconnectTask = m_taskFactory.StartNew(new Action(LoopReconnect), m_TokenSource.Token);
                        }
                        else
                        {
                            m_MREReconnect.Set();
                        }
                    }
                }
            }
        }

        private void LoopReconnect()
        {
            while (!m_IsConnected)
            {
                if (m_MREReconnect.WaitOne())
                {
                    while (!m_IsConnected)
                    {
                        if (m_Connected)
                        {
                            break;
                        }
                        if (m_IsConnected)
                        {
                            break;
                        }
                        if (!m_Connected)
                        {
                            Thread.Sleep(INTERVAL_RECONNECT * 1000);
                        }

                        if (Message != null)
                        {
                            Message("开始重连 ...");
                        }
                        if (ReConnectStart != null)
                        {
                            ReConnectStart(this, EventArgs.Empty);
                        }
                        ConnectionParam ip = IPList.GetNext();
                        if (ip != null)
                            if(Connect(ip))
                            {
                                ConnectedServer = true; //  m_ImageAnalysisService.Start(true);
                            }
                        if (ConnectedServer)
                        {
                            if (Message != null)
                            {
                                Message("重连成功");
                            }
                            if (ReConnectFinished != null)
                            {
                                ReConnectFinished(true);
                            }
                        }
                        else
                        {
                            if (Message != null)
                            {
                                Message("重连失败");
                            }
                            if (ReConnectFinished != null)
                            {
                                ReConnectFinished(false);
                            }
                        }
                    }
                    m_MREReconnect.Reset();
                }
            }
        }

        #endregion
    }
}
