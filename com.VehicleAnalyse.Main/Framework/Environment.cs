using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppUtil;
using System.Configuration;
using System.Reflection;
using AppUtil.Common;
using System.Xml;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using com.VehicleAnalyse.DataModel;

namespace com.VehicleAnalyse.Main.Framework
{
    public class Environment
    {
        [Flags]
        public enum E_PRODUCT_TYPE
        {
            RELEASE = 0,
            NO_LOG = 0x01,
            ONLY_BRIEF = 0x02,
            WITH_BIG_DATA = 0x04,
            TianJin_PRODUCT = 0x08,
            NO_CHECK_VERTION = 0x10,
            NO_EXPORT_VIDEO = 0x20,
        }

        private static bool s_RememberPassword = false;
        private static LoginToken s_Token;

        private static Configuration s_Config;

        private static string s_configFileName;

        private static string s_Version;

        public static string PROGRAM_NAME = "博康慧眼—车侦系统客户端";

        public static bool IsStarted { get; set; }
        public static string ServerIP
        {
            get
            {
                return s_Token.ServerIP;
            }
            set
            {
                s_Token.ServerIP = value;
            }
        }

        public static string UserName
        {
            get
            {
                return s_Token.UserName;
            }
            set
            {
                s_Token.UserName = value;
            }
        }

        public static string Password
        {
            get
            {
                return s_Token.Password;
            }
            set
            {
                s_Token.Password = value;
            }
        }

        public static int TaskPort
        {
            get
            {
                return s_Token.ServerPort;
            }
            set
            {
                s_Token.ServerPort = value;
            }
        }
        public static string PicIP
        {
            get
            {
                return s_Token.UploadIP;
            }
            set
            {
                s_Token.UploadIP = value;
            }
        }

        public static int PicPort
        {
            get
            {
                return s_Token.UploadPort;
            }
            set
            {
                s_Token.UploadPort = value;
            }
        }
        public static string SearchIP
        {
            get
            {
                return s_Token.SearchIP;
            }
            set
            {
                s_Token.SearchIP = value;
            }
        }

        public static int SearchPort
        {
            get
            {
                return s_Token.SearchPort;
            }
            set
            {
                s_Token.SearchPort = value;
            }
        }

        public static int RealTimeTaskSendCount { get; set; }
        public static bool UseCustomTitle{get;set;}

        public static string CustomTitle{get;set;}

        public static System.Drawing.Image CustomLogo {get;set;}

        public static string CutomizeResultListColumns { get; set; }

        public static string SearchFeatureSettings { get; set; }


        public static bool ShowPeopleImg
        {
            get;
            set;
        }

        public static bool ResultExportAsXls
        {
            get;
            set;
        }

        public static bool SavePassword
        {
            get
            {
                return s_RememberPassword;
            }
            set
            {
                if (s_RememberPassword != value)
                {
                    s_RememberPassword = value;
                    if (!s_RememberPassword)
                    {
                        Password = string.Empty;
                    }
                }
            }
        }

        public static string Version
        {
            get
            {
                if (String.IsNullOrEmpty(s_Version))
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    Version v = assembly.GetName().Version;
                    string fileVersion = FileVersionInfo.GetVersionInfo(assembly.Location).FileVersion;
                    //string dateTime = (new DateTime(2000, 1, 1)).AddDays(v.Build).AddSeconds(v.Revision * 2).ToString("yyyyMMddHHmmss");
                    //////dllimport加载dll非常耗时，启动时显示sdk版本，触发加载dll
                    ////string sdkver = Protocol.IVXProtocol.GetSdkVersion();
                    //s_Version = string.Format("Ver:{0} ({1})", fileVersion, dateTime);
                    s_Version = string.Format("v{0}", v.ToString());
                }
                return s_Version;


            }
        }

        public static LoginToken LoggedinToken
        {
            get
            {
                return s_Token;
            }
            set
            {
                s_Token = value;
            }
        }

        private static string AssemblyDirectory
        {
            get;
            set;
        }

        public static bool ShowNoLogoBrand
        {
            get;set;
        }

        public static bool DrawVehicleRect
        {
            get;
            set;
        }

        public static bool DrawPlateRect
        {
            get;
            set;
        }

        public static bool DrawAILabelRect
        {
            get;
            set;
        }
        public static bool RealTimeVersion
        {
            get;
            set;
        }
        static string uRLEncodingType;

        public static AppUtil.Common.UrlEncodeUtil.EncodingType URLEncodingType
        {
            get 
            {
                switch (uRLEncodingType.ToLower())
                {
                    case "gbk":
                    case "g":
                    case "gb2312":
                        return AppUtil.Common.UrlEncodeUtil.EncodingType.GBK;
                    case "utf8":
                    case "u":
                    case "utf-8":
                    default:
                        return  AppUtil.Common.UrlEncodeUtil.EncodingType.UTF8;
                }
            }
            set { uRLEncodingType = value == UrlEncodeUtil.EncodingType.GBK?"gbk":"utf8"; }
        }

        static Environment()
        {
            try
            {
                Assembly asm = Assembly.GetExecutingAssembly();

                string logpath = asm.Location + ".config";
                Trace.WriteLine("ReadConfig:" + logpath);
             
                string path = asm.Location;
                path = Path.GetDirectoryName(path);
                AssemblyDirectory = path;
                s_configFileName = logpath;

                Trace.WriteLine("set AssemblyDirectory:" + path);

                s_Config = ConfigurationManager.OpenExeConfiguration(asm.Location);
                Framework.Environment.ReadConfig();

            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
                MyLog4Net.Container.Instance.Log.Error("OpenExeConfiguration error in Environment: ", ex);
            }

        }

        public static bool SaveConfig()
        {
            try
            {
                s_Config.AppSettings.Settings["ServerIP"].Value = s_Token.ServerIP;
                s_Config.AppSettings.Settings["ServerPort"].Value = s_Token.ServerPort.ToString();

                s_Config.AppSettings.Settings["SearchIP"].Value = s_Token.SearchIP;
                s_Config.AppSettings.Settings["SearchPort"].Value = s_Token.SearchPort.ToString();

                s_Config.AppSettings.Settings["UploadIP"].Value = s_Token.UploadIP;
                s_Config.AppSettings.Settings["UploadPort"].Value = s_Token.UploadPort.ToString();


                s_Config.AppSettings.Settings["UserName"].Value = s_Token.UserName;

                if (s_RememberPassword)
                {
                    s_Config.AppSettings.Settings["Password"].Value = Encryption.Encrypt(s_Token.Password);
                }
                s_Config.AppSettings.Settings["RememberPassword"].Value = s_RememberPassword.ToString();

                s_Config.AppSettings.Settings["CutomizeResultListColumns"].Value = CutomizeResultListColumns;
                s_Config.AppSettings.Settings["RealTimeTaskSendCount"].Value = RealTimeTaskSendCount.ToString();
                s_Config.AppSettings.Settings["CutomizeTitle"].Value = CustomTitle;
                s_Config.AppSettings.Settings["ShowPeopleImg"].Value = ShowPeopleImg.ToString();
                s_Config.AppSettings.Settings["ResultExportAsXls"].Value = ResultExportAsXls.ToString();
                s_Config.AppSettings.Settings["DrawVehicleRect"].Value = DrawVehicleRect.ToString();
                s_Config.AppSettings.Settings["DrawPlateRect"].Value = DrawPlateRect.ToString();
                s_Config.AppSettings.Settings["DrawAILabelRect"].Value = DrawAILabelRect.ToString();
                s_Config.AppSettings.Settings["RealTimeVersion"].Value = RealTimeVersion.ToString();
                s_Config.AppSettings.Settings["URLEncodingType"].Value = uRLEncodingType.ToString();

                try
                {
                    s_Config.Save();// s_configFileName);
                }
                catch (Exception ex)
                {
                    MyLog4Net.Container.Instance.Log.Error("OpenExeConfiguration error in Environment: ", ex);
                }

                return true;
            }
            catch
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("配置文件损坏，系统参数可能无法保存。", 
                    Framework.Environment.PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        public static void ReadConfig()
        {
            if (s_Config != null)
            {
                string userName = s_Config.AppSettings.Settings["UserName"].Value;
                string password = s_Config.AppSettings.Settings["Password"].Value;
                bool bVal;
                if (!string.IsNullOrEmpty(password))
                {
                    password = Encryption.Decrypt(password);
                }

                string serverIP = s_Config.AppSettings.Settings["ServerIP"].Value;
                string temp = s_Config.AppSettings.Settings["ServerPort"].Value;
                int serverPort = 10007;
                if (!string.IsNullOrEmpty(temp))
                {
                    if (!int.TryParse(temp, out serverPort))
                    {
                        serverPort = 10007;
                    }
                }

                string searchIP = s_Config.AppSettings.Settings["SearchIP"].Value;
                temp = s_Config.AppSettings.Settings["SearchPort"].Value;
                int searchPort = 9012;
                if (!string.IsNullOrEmpty(temp))
                {
                    if (!int.TryParse(temp, out searchPort))
                    {
                        searchPort = 9012;
                    }
                }

                string uploadIP = s_Config.AppSettings.Settings["UploadIP"].Value;
                temp = s_Config.AppSettings.Settings["UploadPort"].Value;
                int uploadPort = 10005;
                if (!string.IsNullOrEmpty(temp))
                {
                    if (!int.TryParse(temp, out uploadPort))
                    {
                        uploadPort = 10005;
                    }
                }


                temp = s_Config.AppSettings.Settings["RememberPassword"].Value;
                bool rememberPassword = false;
                if (!string.IsNullOrEmpty(temp))
                {
                    if (!Boolean.TryParse(temp, out rememberPassword))
                    {
                        rememberPassword = false;
                    }
                }
                s_Token = new LoginToken(serverIP, userName, password, serverPort, uploadIP, uploadPort, searchIP, searchPort);
                SavePassword = rememberPassword;
                if (!SavePassword)
                {
                    s_Token.Password = string.Empty;
                }

                temp = s_Config.AppSettings.Settings["RealTimeTaskSendCount"].Value;
                int realTimeTaskSendCount = 10;
                if (!string.IsNullOrEmpty(temp))
                {
                    if (!int.TryParse(temp, out realTimeTaskSendCount))
                    {
                        realTimeTaskSendCount = 10;
                    }
                } 
                RealTimeTaskSendCount = realTimeTaskSendCount;

                temp = s_Config.AppSettings.Settings["UseCutomizeTitle"].Value;
                UseCustomTitle = false;
                if (!string.IsNullOrEmpty(temp))
                {
                    bool bTmp = false;
                    if (!Boolean.TryParse(temp, out bTmp))
                    {
                        bTmp = false;
                    }
                    UseCustomTitle = bTmp;
                }

                if (UseCustomTitle)
                {
                    CustomTitle = s_Config.AppSettings.Settings["CutomizeTitle"].Value;
                    if (CustomTitle == null)
                    {
                        CustomTitle = string.Empty;
                    }
                    string customLogo = s_Config.AppSettings.Settings["CutomizeLogo"].Value;
                    if (System.IO.File.Exists(customLogo))
                        CustomLogo = System.Drawing.Image.FromFile(customLogo);
                    else
                        CustomLogo = new System.Drawing.Bitmap(200, 100);
                    PROGRAM_NAME = CustomTitle;
                }

                CutomizeResultListColumns = s_Config.AppSettings.Settings["CutomizeResultListColumns"].Value;
                if (!string.IsNullOrEmpty(CutomizeResultListColumns))
                {
                    CutomizeResultListColumns = CutomizeResultListColumns.Trim();
                }

                SearchFeatureSettings = s_Config.AppSettings.Settings["SearchFeatureSettings"].Value;
                if (!string.IsNullOrEmpty(SearchFeatureSettings))
                {
                    SearchFeatureSettings = SearchFeatureSettings.Trim();
                }

                temp = s_Config.AppSettings.Settings["ShowPeopleImg"].Value;
                ParseBoolVal(temp, out bVal, false);
                ShowPeopleImg = bVal;

                temp = s_Config.AppSettings.Settings["ResultExportAsXls"].Value;
                ParseBoolVal(temp, out bVal, true);
                ResultExportAsXls = bVal;

                temp = s_Config.AppSettings.Settings["ShowNoLogoBrand"].Value;
                ParseBoolVal(temp, out bVal, true);
                ShowNoLogoBrand = bVal;

                temp = s_Config.AppSettings.Settings["DrawVehicleRect"].Value;
                ParseBoolVal(temp, out bVal, true);
                DrawVehicleRect = bVal;

                temp = s_Config.AppSettings.Settings["DrawPlateRect"].Value;
                ParseBoolVal(temp, out bVal, true);
                DrawPlateRect = bVal;

                temp = s_Config.AppSettings.Settings["DrawAILabelRect"].Value;
                ParseBoolVal(temp, out bVal, true);
                DrawAILabelRect = bVal;

                temp = s_Config.AppSettings.Settings["RealTimeVersion"].Value;
                ParseBoolVal(temp, out bVal, true);
                RealTimeVersion = bVal;

                uRLEncodingType = s_Config.AppSettings.Settings["URLEncodingType"].Value;
                if (string.IsNullOrEmpty(uRLEncodingType))
                    uRLEncodingType = "utf8";

                GetServerList();
            }
            else
            {
                s_Token = new LoginToken(string.Empty, string.Empty, string.Empty, 8001, string.Empty, 8001, string.Empty, 8001);
            }
        }
        static void GetServerList()
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            IPList = new IpList();
            string configFile = Path.Combine(Directory.GetParent(asm.Location).FullName, "OCXLogin.xml");
            if (System.IO.File.Exists(configFile))
            {                         
                XmlDocument doc = new XmlDocument();
                doc.Load(configFile);
                foreach (XmlNode item in doc.SelectNodes("//Login"))
                {
                    string ip = item.SelectSingleNode("IP").InnerText;
                    uint port = Convert.ToUInt32(item.SelectSingleNode("Port").InnerText);
                    string user = item.SelectSingleNode("User").InnerText;
                    string pass = item.SelectSingleNode("Pass").InnerText;
                    IPList.AddIp(new ConnectionParam() { IPAddress = ip, Port = (int)port, DeviceNo = user });

                }

            }
        }

        public static void Reset()
        {
            GetServerList();
        }
        public static IpList IPList ;
        private static void ParseBoolVal(string sVal, out bool val, bool defaultVal)
        {
            val = defaultVal;
            if (!string.IsNullOrEmpty(sVal))
            {
                bool bTmp = defaultVal;
                if (!Boolean.TryParse(sVal, out bTmp))
                {
                    bTmp = defaultVal;
                }
                val = bTmp;
            }
        }


        public static List<CameraInfo> CameraList
        {
            get
            {
                Assembly asm = Assembly.GetExecutingAssembly();
                string configFile = Path.Combine(Directory.GetParent(asm.Location).FullName, "Camera.list");
                List<CameraInfo> ret = new List<CameraInfo>();
                if (System.IO.File.Exists(configFile))
                {
                    ret = AppUtil.Common.XMLSerilize.DeserilizeObject<List<CameraInfo>>(System.IO.File.ReadAllText(configFile));
                }

                return ret;
            }
            set
            {
                Assembly asm = Assembly.GetExecutingAssembly();
                string configFile = Path.Combine(Directory.GetParent(asm.Location).FullName, "Camera.list");
                string temp = AppUtil.Common.XMLSerilize.SerilizeObject<List<CameraInfo>>(value);
                System.IO.File.WriteAllText(configFile, temp);
            }
        }
        public static List<FilePathInfo> FilePathList
        {
            get
            {
                Assembly asm = Assembly.GetExecutingAssembly();
                IPList = new IpList();
                string configFile = Path.Combine(Directory.GetParent(asm.Location).FullName, "FilePath.list");
                List<FilePathInfo> ret = new List<FilePathInfo>();
                if (System.IO.File.Exists(configFile))
                {
                    ret = AppUtil.Common.XMLSerilize.DeserilizeObject<List<FilePathInfo>>(System.IO.File.ReadAllText(configFile));
                }

                return ret;
            }
            set
            {
                Assembly asm = Assembly.GetExecutingAssembly();
                string configFile = Path.Combine(Directory.GetParent(asm.Location).FullName, "FilePath.list");
                string temp = AppUtil.Common.XMLSerilize.SerilizeObject<List<FilePathInfo>>(value);
                System.IO.File.WriteAllText(configFile, temp);

            }
        }

        internal static string GetDeviceName(string p)
        {
            string name =p;
            var task = Framework.Container.Instance.TaskManager.GetAllTasks().Find(it => it.TaskId == p);
            if (task == null)
            {
                var cam = CameraList.Find(it => it.ID == p);
                if (cam != null)
                    name = cam.FullName;
            }
            else
                name = task.TaskName;

            return name;
        }


    }
}
