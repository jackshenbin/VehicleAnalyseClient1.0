using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppUtil.Common;
using System.Windows.Forms;
using AppUtil;
using System.ComponentModel;
using com.VehicleAnalyse.Service;
using com.VehicleAnalyse.DataModel;
using com.VehicleAnalyse.Main.Framework;

namespace com.VehicleAnalyse.Main.ViewModels
{
    public class LoginViewModel : ViewModelBase, INotifyPropertyChanged
    {
        //public event PropertyChangedEventHandler PropertyChanged;

        #region Fields

        private string m_ServerIP;

        private string m_UserName;

        private string m_Password;

        private decimal m_ServerPort = 10005;

        private string m_PicIP;

        private decimal m_PicPort = 10009;

        private string m_SearchIP;

        private decimal m_SearchPort = 8090;

        #endregion

        #region Properties

        public string PicIP
        {
            get { return m_PicIP; }
            set { m_PicIP = value; }
        }

        public decimal PicPort
        {
            get { return m_PicPort; }
            set { m_PicPort = value; }
        }

        public string SearchIP
        {
            get { return m_SearchIP; }
            set { m_SearchIP = value; }
        }

        public decimal SearchPort
        {
            get { return m_SearchPort; }
            set { m_SearchPort = value; }
        }
        public string ServerIP
        {
            get { return m_ServerIP; }
            set { m_ServerIP = value; }
        }

        public string UserName
        {
            get { return m_UserName; }
            set { m_UserName = value; }
        }

        public string Password
        {
            get { return m_Password; }
            set { m_Password = value; }
        }
        
        public bool RememberPassword
        {
            get
            {
                return Framework.Environment.SavePassword;
            }
            set
            {
                Framework.Environment.SavePassword = value;
            }
        }

        public decimal ServerPort
        {
            get
            {
                return m_ServerPort;
            }
            set
            {
                m_ServerPort = value;
            }
        }



        #endregion

        #region Constructors

        public LoginViewModel()
        {
            ServerIP = Framework.Environment.ServerIP;
            UserName = Framework.Environment.UserName;
            Password = Framework.Environment.Password;
            ServerPort = (decimal)Framework.Environment.TaskPort;
            SearchIP = Framework.Environment.SearchIP;
            SearchPort = Framework.Environment.SearchPort;
            PicIP = Framework.Environment.PicIP;
            PicPort = Framework.Environment.PicPort;
            RememberPassword = Framework.Environment.SavePassword;
        }

        #endregion

        private bool Validate()
        {
            bool bRet = true;

            if (!TextUtil.ValidateIPAddress(ServerIP))
            {
                bRet = false;
                Framework.Container.Instance.InteractionService.ShowMessageBox("服务器地址不正确", Framework.Environment.PROGRAM_NAME,
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //else if (string.IsNullOrEmpty(UserName))
            //{
            //    bRet = false;
            //    Framework.Container.Instance.InteractionService.ShowMessageBox("用户名不能为空", Framework.Environment.PROGRAM_NAME,
            //           MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else if (string.IsNullOrEmpty(Password))
            //{
            //    bRet = false;
            //    Framework.Container.Instance.InteractionService.ShowMessageBox("密码不能为空", Framework.Environment.PROGRAM_NAME,
            //           MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}

            return bRet;
        }

        #region Public helper functions

        public bool Commit()
        {
            bool bRet = Validate();
            if (!bRet)
            {
                return bRet;
            }

            bRet = DoSql.TestConn(ServerIP, UserName, Password);
            if (bRet)
            {
                Framework.Container.Instance.EvtAggregator.GetEvent<AnalyseMessageEvent>().Publish(
    new Tuple<uint, string>(100, string.Format("连接服务器 {0}:{1} ...【检索服务{2}:{3}】【图片接入服务{4}:{5}】", m_ServerIP, m_ServerPort, m_SearchIP, m_SearchPort, m_PicIP, m_PicPort)));



                Framework.Environment.ServerIP = ServerIP;
                Framework.Environment.TaskPort = (int)ServerPort;
                Framework.Environment.PicIP = PicIP;
                Framework.Environment.PicPort = (int)PicPort;
                Framework.Environment.UserName = UserName;
                Framework.Environment.Password = Password;
                Framework.Environment.SearchPort = (int)SearchPort;
                Framework.Environment.SearchIP = SearchIP;
                Framework.Environment.SavePassword = RememberPassword;
                Framework.Environment.SaveConfig();
            }
            else
            {
                Framework.Container.Instance.InteractionService.ShowMessageBox("无法连接服务器", Framework.Environment.PROGRAM_NAME,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            
            return bRet;
        }

        #endregion

    }
}
