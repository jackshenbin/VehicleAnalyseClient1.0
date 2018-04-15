using com.VehicleAnalyse.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using AppUtil;
using DevExpress.LookAndFeel;
using System.Runtime.InteropServices;

namespace com.VehicleAnalyse.Main
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            MyLog4Net.Container.Instance.Log.Info("---------------------------------------------------");
            Application.ThreadException +=new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo("regsqlite.bat");
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                MyLog4Net.Container.Instance.Log.ErrorFormat("注册sqlite dll 失败", ex.Message);

                Debug.Assert(false);
                MessageBox.Show("注册sqlite dll 失败，程序无法启动！");

            }
            

            //MessageBox.Show("1.任务列表有的没有显示开始分析时间 " + Environment.NewLine +
            //                "5.车标按字母筛选 " + Environment.NewLine +
            //                "6.检索条件中设置的相机号和页面左上角显示的相机不是一个字段 " + Environment.NewLine +
            //                "7.车牌筛选条件缺少无牌车筛选");

            DevExpress.UserSkins.BonusSkins.Register();
            UserLookAndFeel.Default.SetSkinStyle("McSkin");
            DevExpress.Skins.SkinManager.EnableFormSkins();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new XtraForm1());
            // Application.Run(new RibbonForm1());

            //try
            //{
            MyLog4Net.Container.Instance.Log.Info("开始运行 ... ");
                // Application.Run(new MainForm());
                Application.Run(new XtraMainForm());
                MyLog4Net.Container.Instance.Log.Info("退出程序 ... ");
            //}
            //catch (Exception ex)
            //{
            //    LogService.GetLog("ClientApp").ErrorFormat("主程序异常", ex.Message);
            //}
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MyLog4Net.Container.Instance.Log.Error("Application_ThreadException:", e.Exception);

            MessageBox.Show(
                string.Format("系统出现未处理异常："
                + Environment.NewLine + "{0}"
                + Environment.NewLine + Environment.NewLine + "请重新启动程序，如仍旧出现此对话框请联系管理员！", e.Exception.Message)
                , "系统未处理异常"
                , MessageBoxButtons.OK
                , MessageBoxIcon.Information);

        }



        private static int m_productType = -1;
        public static com.VehicleAnalyse.Main.Framework.Environment.E_PRODUCT_TYPE PRODUCT_TYPE
        {
            get
            {
                if (m_productType < 0)
                {
                    System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();

                    string path = asm.Location;
                    path = System.IO.Path.GetDirectoryName(path);

                    int ntype = 0;
                    string producttypepath = path + "\\Resource.dll";
                    if (System.IO.File.Exists(producttypepath))
                    {
                        string strtype = System.IO.File.ReadAllText(producttypepath);
                        try
                        {
                            ntype = int.Parse(strtype);
                            if (ntype < 0)
                                ntype = 0;
                        }
                        catch { }
                    }
                    m_productType = ntype;
                }
                return (com.VehicleAnalyse.Main.Framework.Environment.E_PRODUCT_TYPE)m_productType;

            }
        }


    }
}
