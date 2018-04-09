using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using DevExpress.LookAndFeel;
using AppUtil;
using com.VehicleAnalyse.Main.Views;
using com.VehicleAnalyse.Main;
using com.VehicleAnalyse.Main.Framework;
using Microsoft.Practices.Prism.Events;


namespace com.VehicleAnalyse.ActiveX
{
    [Guid("094500B1-62FC-46B6-BA44-7634CD712A00"),
    ProgId("IRASVDASDK"),
    ClassInterface(ClassInterfaceType.None),
    ComDefaultInterface(typeof(iIRASInterface)),
    ComSourceInterfaces(typeof(IRASEvents)),
    ComVisible(true)]
    public partial class OcxLoader : DevExpress.XtraEditors.XtraUserControl, iIRASInterface, IObjectSafety
    {
        #region Fields

        private ucResultPage OcxResult;
        private ucTaskPage OcxTask;

        private const int USERMANAGER = 1;
        private const int OTHERUSER = 2;
        private const string REGEXPATTERN_USERNAME = "[a-zA-Z0-9_]{1,20}$";
        private const string REGEXPATTERN_PASSWORD = @"[a-zA-Z0-9`~!@#$%^&*()_+-={}|\[\]:"";'<>?,.]{1,20}$";
        private bool m_isInited = false;

        private System.Threading.ManualResetEventSlim mesStart = new ManualResetEventSlim(false);

        #endregion

        #region Constructors

        Process p = null;
        private void EnvInit()
        {
            string configname = Application.ExecutablePath + ".config";
            Assembly asm = Assembly.GetExecutingAssembly();
            string filepath = System.IO.Path.Combine(System.IO.Directory.GetParent(asm.Location).FullName, "Runas.exe");
            if (System.IO.File.Exists(filepath))
            {
                //创建启动对象
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                //设置运行文件
                startInfo.FileName = filepath;
                //设置启动参数
                startInfo.Arguments = "\""+configname+"\"";
                //设置启动动作,确保以管理员身份运行
                startInfo.Verb = "runas";
                //如果不是管理员，则启动UAC
                System.Diagnostics.Process.Start(startInfo).WaitForExit();
            }
        }
        public OcxLoader()
        {

            EnvInit();

            MyLog4Net.Container.Instance.Log.Debug("COMLibrary begin OcxLoader");

            Assembly asm = Assembly.GetExecutingAssembly();
            string filepath = System.IO.Path.Combine(System.IO.Directory.GetParent(asm.Location).FullName, "IVXLoading.exe");
            if (System.IO.File.Exists(filepath))
            {
                ProcessStartInfo info = new ProcessStartInfo() { FileName = filepath, };
                p = Process.Start(info);
            }

            DevExpress.Skins.SkinManager.Default.RegisterAssembly(typeof(DevExpress.UserSkins.IVXDarkSkin2).Assembly); //Register!
            UserLookAndFeel.Default.SetSkinStyle("MySkin_IVXDarkSkin1");
            DevExpress.Skins.SkinManager.EnableFormSkins();


            AppDomain.CurrentDomain.SetData("OCXContainer", this);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

            InitializeComponent();
            DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;

            MyLog4Net.Container.Instance.Log.Debug("COMLibrary finish OcxLoader");
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception)
            {
                MyLog4Net.Container.Instance.Log.Error("Application_ThreadException:" + (Exception)e.ExceptionObject);

                MessageBox.Show(
                    string.Format("系统出现未处理异常："
                    + System.Environment.NewLine + "{0}"
                    + System.Environment.NewLine + System.Environment.NewLine + "请重新启动程序，如仍旧出现此对话框请联系管理员！", ((Exception)e.ExceptionObject).Message)
                    , "系统未处理异常"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Information);
            }
            else
            {
                MyLog4Net.Container.Instance.Log.Error("Application_ThreadException:无描述");

                MessageBox.Show(
                    string.Format("系统出现未处理异常："
                    + System.Environment.NewLine + "{0}"
                    + System.Environment.NewLine + System.Environment.NewLine + "请重新启动程序，如仍旧出现此对话框请联系管理员！", "无描述")
                    , "系统未处理异常"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Information);

            }
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MyLog4Net.Container.Instance.Log.Error("Application_ThreadException:" + e.Exception);

            MessageBox.Show(
                string.Format("系统出现未处理异常："
                + System.Environment.NewLine + "{0}"
                + System.Environment.NewLine + System.Environment.NewLine + "请重新启动程序，如仍旧出现此对话框请联系管理员！", e.Exception.Message)
                , "系统未处理异常"
                , MessageBoxButtons.OK
                , MessageBoxIcon.Information);

        }

        #endregion

        #region Events,Handles

        #endregion

        #region Implementation



        #endregion

        #region IObjectSafety implementations
        private const string _IID_IDispatch = "{00020400-0000-0000-C000-000000000046}";
        private const string _IID_IDispatchEx = "{a6ef9860-c720-11d0-9337-00a0c90dcaa9}";
        private const string _IID_IPersistStorage = "{0000010A-0000-0000-C000-000000000046}";
        private const string _IID_IPersistStream = "{00000109-0000-0000-C000-000000000046}";
        private const string _IID_IPersistPropertyBag = "{37D84F60-42CB-11CE-8135-00AA004BB851}";

        private const int INTERFACESAFE_FOR_UNTRUSTED_CALLER = 0x00000001;
        private const int INTERFACESAFE_FOR_UNTRUSTED_DATA = 0x00000002;
        private const int S_OK = 0;
        private const int E_FAIL = unchecked((int)0x80004005);
        private const int E_NOINTERFACE = unchecked((int)0x80004002);

        private bool _fSafeForScripting = true;
        private bool _fSafeForInitializing = true;
        //void IObjectSafety.GetInterfaceSafetyOptions(int riid, out int supportedOptions, out int enabledOptions)
        //{
        //    supportedOptions = 1;
        //    enabledOptions = 2;
        //}

        //void IObjectSafety.SetInterfaceSafetyOptions(int riid, int optionsSetMask, int enabledOptions)
        //{
        //    //throw new NotImplementedException();
        //}
        int IObjectSafety.GetInterfaceSafetyOptions(ref Guid riid, ref int pdwSupportedOptions, ref int pdwEnabledOptions)
        {
            int Rslt = E_FAIL;

            string strGUID = riid.ToString("B");
            pdwSupportedOptions = INTERFACESAFE_FOR_UNTRUSTED_CALLER | INTERFACESAFE_FOR_UNTRUSTED_DATA;
            switch (strGUID)
            {
                case _IID_IDispatch:
                case _IID_IDispatchEx:
                    Rslt = S_OK;
                    pdwEnabledOptions = 0;
                    if (_fSafeForScripting == true)
                        pdwEnabledOptions = INTERFACESAFE_FOR_UNTRUSTED_CALLER;
                    break;
                case _IID_IPersistStorage:
                case _IID_IPersistStream:
                case _IID_IPersistPropertyBag:
                    Rslt = S_OK;
                    pdwEnabledOptions = 0;
                    if (_fSafeForInitializing == true)
                        pdwEnabledOptions = INTERFACESAFE_FOR_UNTRUSTED_DATA;
                    break;
                default:
                    Rslt = E_NOINTERFACE;
                    break;
            }

            return Rslt;
        }

        int IObjectSafety.SetInterfaceSafetyOptions(ref Guid riid, int dwOptionSetMask, int dwEnabledOptions)
        {
            int Rslt = E_FAIL;
            string strGUID = riid.ToString("B");
            switch (strGUID)
            {
                case _IID_IDispatch:
                case _IID_IDispatchEx:
                    if (((dwEnabledOptions & dwOptionSetMask) == INTERFACESAFE_FOR_UNTRUSTED_CALLER) && (_fSafeForScripting == true))
                        Rslt = S_OK;
                    break;
                case _IID_IPersistStorage:
                case _IID_IPersistStream:
                case _IID_IPersistPropertyBag:
                    if (((dwEnabledOptions & dwOptionSetMask) == INTERFACESAFE_FOR_UNTRUSTED_DATA) && (_fSafeForInitializing == true))
                        Rslt = S_OK;
                    break;
                default:
                    Rslt = E_NOINTERFACE;

                    break;
            }

            return Rslt;
        }
        #endregion

        #region Event handlers


        private void OnUserLoggedin(LoginToken token)
        {
            StatusChange( string.Format("登录服务器: {0}", com.VehicleAnalyse.Main.Framework.Environment.LoggedinToken.ServerIP));
            MyLog4Net.Container.Instance.Log.DebugFormat("登录服务器: {0}", com.VehicleAnalyse.Main.Framework.Environment.LoggedinToken.ServerIP);
        }

        private void OnReConnectFinished(bool result)
        {
            if (result)
            {
                StatusChange( string.Format("登录服务器: {0}", com.VehicleAnalyse.Main.Framework.Environment.LoggedinToken.ServerIP));
                MyLog4Net.Container.Instance.Log.DebugFormat("登录服务器: {0}", com.VehicleAnalyse.Main.Framework.Environment.LoggedinToken.ServerIP);
            }
            else
            {
                StatusChange( string.Format("与服务器 {0}连接断开", com.VehicleAnalyse.Main.Framework.Environment.LoggedinToken.ServerIP));
                MyLog4Net.Container.Instance.Log.DebugFormat("与服务器 {0}连接断开", com.VehicleAnalyse.Main.Framework.Environment.LoggedinToken.ServerIP);
            }
        }

        private void OnReConnectStart(string obj)
        {
            StatusChange( string.Format("开始重连服务器: {0} ...", com.VehicleAnalyse.Main.Framework.Environment.LoggedinToken.ServerIP));
            MyLog4Net.Container.Instance.Log.DebugFormat("开始重连服务器: {0} ...", com.VehicleAnalyse.Main.Framework.Environment.LoggedinToken.ServerIP);
        }

        private void OnDisconnect(string para)
        {
            StatusChange( string.Format("与服务器 {0}连接断开", com.VehicleAnalyse.Main.Framework.Environment.LoggedinToken.ServerIP));
            MyLog4Net.Container.Instance.Log.DebugFormat("与服务器 {0}连接断开", com.VehicleAnalyse.Main.Framework.Environment.LoggedinToken.ServerIP);
        }
        private void StatusChange(string msg)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(StatusChange), msg);
            }
            else
            {
                labelControl1.Text = msg;

            }
        }
        #endregion

        #region Private helper functions

        private bool ValidateUserName(string username)
        {
            bool bRet = true;

            if (string.IsNullOrEmpty(username))
            {
                //XtraMessageBox.Show("用户名不能为空", Framework.Environment.PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //txtBoxUserName.Focus();
                return false;
            }

            if (!Regex.IsMatch(username, REGEXPATTERN_USERNAME))
            {
                //XtraMessageBox.Show("用户名由字母开头，由1-10位的字母、数字、下划线组成", Framework.Environment.PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //txtBoxUserName.Focus();
                return false;
            }

            //if (!m_IsModifyMode)
            //{
            //    DataRow[] rows = m_DTUser.Select(string.Format("Name='{0}'", m_UserName));
            //    if (rows != null && rows.Length > 0)
            //    {
            //        XtraMessageBox.Show(string.Format("用户名称'{0}'已经被占用", m_UserName), Framework.Environment.PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        txtBoxUserName.Focus();
            //        return false;
            //    }
            //}
            return bRet;
        }

        private bool ValidatePassword(string password)
        {
            bool bRet = true;


            if (string.IsNullOrEmpty(password))
            {
                //XtraMessageBox.Show("密码不能为空", Framework.Environment.PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //txtEditPassword.Focus();
                return false;
            }

            if (!Regex.IsMatch(password, REGEXPATTERN_PASSWORD))
            {
                //XtraMessageBox.Show(string.Format("密码1-10位的字母、数字、和{0}组成",
                //                    @"`~!@#$%^&*()_+-={}|\[\]:"";'<>?,."), Framework.Environment.PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //txtEditPassword.Focus();
                return false;
            }

            return bRet;
        }

        private string MakeRetMsg(int errCode, string errDiscription, string retInfo = "")
        {
            string ret = string.Format("<Ret>"
                + "<RetMsg><ErrorCode>{0}</ErrorCode><Description>{1}</Description></RetMsg>"
                + "<RetInfo>{2}</RetInfo>"
                + "</Ret>"
                , errCode
                , errDiscription
                , retInfo);
            return ret;
        }


        #endregion

        #region iIVXInterface implementations
        Mutex run = null;
        public string IRASInitialization()
        {
            bool outrun = false;
            run =  new Mutex(true, "IRAS", out outrun);
            if (!outrun)
                return MakeRetMsg(1, "已经运行一个实例");

            if (m_isInited)
                return MakeRetMsg(1, "已经初始化");

            m_isInited = false;

            try
            {
                if (OcxTask!=null)
                {
                    OcxTask.Visible =true;
                    OcxResult.Visible = true;
                    if (xtraTabPage1.Controls.Count==0)
                    xtraTabPage1.Controls.Add(OcxTask);
                    if (xtraTabPage2.Controls.Count==0)
                    xtraTabPage2.Controls.Add(OcxResult);

                }
                else
                {
                    OcxTask = new ucTaskPage();
                    OcxResult = new ucResultPage();
                    OcxTask.Dock = DockStyle.Fill;
                    OcxResult.Dock = DockStyle.Fill;
                    xtraTabPage1.Controls.Add(OcxTask);
                    xtraTabPage2.Controls.Add(OcxResult);
                    com.VehicleAnalyse.Main.Framework.Container.Instance.MainControl = this;
                    com.VehicleAnalyse.Main.Framework.Container.Instance.EvtAggregator.GetEvent<UserLoginEvent>().Subscribe(OnUserLoggedin, ThreadOption.WinFormUIThread);
                }

                m_isInited = true;
                com.VehicleAnalyse.Main.Framework.Environment.IsStarted = true;
                return MakeRetMsg(0, "");
            }
            catch (Exception ex)
            {
                return MakeRetMsg(1, ex.Message);
            }
            finally
            {
                if (p != null && !p.HasExited)
                {
                    p.Kill(); p = null;
                }
            }
        }

        public string IRASUninitialization()
        {
            run.Close();

            if (!m_isInited)
                return MakeRetMsg(1, "未初始化");
            try
            {
                //if (com.VehicleAnalyse.Main.Framework.Environment.LoggedinToken != null)
                //{
                //    com.VehicleAnalyse.Main.Framework.Container.Instance.TaskManager.Close();
                //    com.VehicleAnalyse.Main.Framework.Container.Instance.ImageAnalysisService.Stop();
                //}

                //com.VehicleAnalyse.Main.Framework.Container.Instance.TaskManager.SaveChanges();
                //com.VehicleAnalyse.Main.Framework.Container.Instance.Cleanup();

                OcxTask.Dispose();
                OcxResult.Dispose();
                xtraTabPage1.Controls.Clear();
                xtraTabPage2.Controls.Clear();
                com.VehicleAnalyse.Main.Framework.Container.Instance.Cleanup();
                m_isInited = false;
                return MakeRetMsg(0, "");
            }
            catch (Exception ex)
            {
                return MakeRetMsg(1, ex.Message);

            }
        }


        public string IRASGetVersion()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string fileVersion = FileVersionInfo.GetVersionInfo(assembly.Location).FileVersion;
            return MakeRetMsg(0, "", fileVersion);
        }


        #endregion




    }

}

