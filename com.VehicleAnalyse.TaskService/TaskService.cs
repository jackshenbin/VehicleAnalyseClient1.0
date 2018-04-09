using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyLog4Net;
using AppUtil;

namespace com.VehicleAnalyse.TaskService
{
	public class TaskService {
        //public event Action<DataModel.TaskInfoV3_1> TaskDeleted;
        //public event Action<DataModel.TaskInfoV3_1> TaskAdded;
        //public event Action<DataModel.TaskInfoV3_1> TaskMonified;
        //public event Action<DataModel.UploadTaskInfoV3_1> UpLoadLocalFile;

		public event Action<string> FireMessage;
		public event Action<string> UserDisConnected;
		#region Fields
		public bool IsConnected { get; set; }
		private TaskWebserviceClientProtocol CommProtocol = null;
		public string WebserviceUrl { get; set; }
		private string ServerIP { get; set; }

		private bool isTaskListInited = false;
		private bool isExit = false;

        private ulong Context = 0;
        #endregion

		#region Constructors

        public TaskService(string url)
        {
			IsConnected = false;
			WebserviceUrl = url;
			CommProtocol = new TaskWebserviceClientProtocol();
		}

		#endregion

		#region Public Functions
		public bool Init(string serverip, uint serverport) {
			isExit = false;
			isTaskListInited = false;
			//m_taskList = new List<TaskInfoV3_1>();
            string url = string.Format(WebserviceUrl, serverip, serverport);
			CommProtocol.Init(url);
            MyLog4Net.Container.Instance.Log.DebugWithDebugView("TaskService CommProtocol Init url:"+url);
            bool ret = true;// TestConn();
			if (ret) {
				IsConnected = true;
				ServerIP = serverip;
				if (FireMessage != null)
					FireMessage("服务器：【" + ServerIP + "】连接成功");
				//m_taskList = new List<TaskInfoV3_1>();
			}
			else {
				IsConnected = false;
				if (FireMessage != null)
					FireMessage("正在连接服务器...");
			}
			return ret;
		}

		public void UnInit() {
			isExit = true;
			isTaskListInited = false;
			//m_taskList = new List<TaskInfoV3_1>();
			IsConnected = false;
			CommProtocol.UnInit();
		}

		public bool TestConn() {
            
			MyLog4Net.Container.Instance.Log.DebugWithDebugView("TestConn");
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\" ?>");
            sb.AppendLine("<root>");
            sb.AppendLine("<historytaskstatus>");
            sb.AppendLine("<rwid>0</rwid>");
            sb.AppendLine("</historytaskstatus>");
            sb.AppendLine("</root>");


            string message = sb.ToString();
			try {
				string rsp = Send("Q13",message, true);
				if (string.IsNullOrEmpty(rsp))
					return false;

				return true;
			}
			catch (SDKCallException sdkex) {
				return (sdkex.ErrorCode == (uint)SDKCallExceptionCode.UserNotLogin || 66240 == sdkex.ErrorCode);
			}
			finally {
				MyLog4Net.Container.Instance.Log.DebugWithDebugView("TestConn ret");
			}
		}

        public bool AddCamera(List<string> cameraids)
        {
            MyLog4Net.Container.Instance.Log.DebugWithDebugView("CommProtocol start AddCamera");
            bool ret = false;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\" ?>");
            sb.AppendLine("<root>");
            foreach (var item in cameraids)
            {
                sb.AppendLine("<realtask>");
                sb.AppendLine("<xjbz>" + item + "</xjbz>");
                sb.AppendLine("</realtask>");
            }
            sb.AppendLine("</root>");
            string message =sb.ToString();
            string rsp = Send("W11", message);

            if (string.IsNullOrEmpty(rsp))
            {
                MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices AddCamera ret IsNullOrEmpty ret:{0}", ret));
                return false;
            }
            System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
            xdoc.LoadXml(rsp);
            UInt32 retVal = Convert.ToUInt32(xdoc.SelectSingleNode("//root/head/code").InnerText);
            ret = retVal == 1 ? true : false;
            MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices AddCamera ret:{0}", ret));
            return ret;

        }


		public bool StartHistoryTask(string taskid,List<string> paths,int priority,string taskname ,AppUtil.Common.UrlEncodeUtil.EncodingType encoding) {
            MyLog4Net.Container.Instance.Log.DebugWithDebugView("CommProtocol start StartHistoryTask");
            bool ret = false;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\" ?>");
            sb.AppendLine("<root>");
            sb.AppendLine("<historytask>");
            sb.AppendLine("<rwid>"+taskid+"</rwid>");
            foreach (var item in paths)
            {
                sb.AppendLine("<tpmu>" + AppUtil.Common.UrlEncodeUtil.UrlPathEncode(item, encoding) + "</tpmu>");
            }
            sb.AppendLine("<rwyxj>" + priority + "</rwyxj>");
            sb.AppendLine("<rwmz>" + taskname + "</rwmz>");
            sb.AppendLine("<pzsj>" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "</pzsj>");
            sb.AppendLine("</historytask>");
            sb.AppendLine("</root>");


            string message = sb.ToString();
            string time = DateTime.Now.ToString("yyyyMMddHHmmss");
            if (!System.IO.Directory.Exists("log\\StartHistoryTask\\"))
                System.IO.Directory.CreateDirectory("log\\StartHistoryTask\\");
            System.IO.File.WriteAllText("log\\StartHistoryTask\\" + time + "_req.xml", message);

			string rsp = Send("W12",message);

            if (string.IsNullOrEmpty(rsp))
            {
                MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices StartHistoryTask ret IsNullOrEmpty ret:{0}", ret));
                return false;
            }
			System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
			xdoc.LoadXml(rsp);
            UInt32 retVal = Convert.ToUInt32(xdoc.SelectSingleNode("//root/head/code").InnerText);
			ret = retVal == 1 ? true : false;
            MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices StartHistoryTask ret:{0}", ret));
            return ret;
		}

		public bool GetHistoryTaskStat(string taskid,out historytaskstatus stat) {
            MyLog4Net.Container.Instance.Log.DebugWithDebugView("CommProtocol start GetHistoryTaskStat");
            bool ret = false;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\" ?>");
            sb.AppendLine("<root>");
            sb.AppendLine("<historytaskstatus>");
            sb.AppendLine("<rwid>"+taskid+"</rwid>");
            sb.AppendLine("</historytaskstatus>");
            sb.AppendLine("</root>");


            string message = sb.ToString();
			string rsp = Send("Q13",message);

            if (string.IsNullOrEmpty(rsp))
            {
                MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices GetHistoryTaskStat ret IsNullOrEmpty ret:{0}", ret));
                stat = new historytaskstatus(){ status ="0", errorcode = "0", errormessage = "return IsNullOrEmpty"};
                return false;
            }
			System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
			xdoc.LoadXml(rsp);
            UInt32 retVal = Convert.ToUInt32(xdoc.SelectSingleNode("//root/head/code").InnerText);
			ret = retVal == 1 ? true : false;

            string body = xdoc.SelectSingleNode("//root/body").InnerXml;
            stat = (historytaskstatus)AppUtil.Common.XMLSerilize.DeserilizeObject<historytaskstatus>(body);

            MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices GetHistoryTaskStat ret:{0}", ret));
            return ret;
		}

		public bool StopHistoryTask(string taskid) {
            MyLog4Net.Container.Instance.Log.DebugWithDebugView("CommProtocol start StopHistoryTask");
            bool ret = false;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\" ?>");
            sb.AppendLine("<root>");
            sb.AppendLine("<deletehistorytask>");
            sb.AppendLine("<rwid>"+taskid+"</rwid>");
            sb.AppendLine("</deletehistorytask>");
            sb.AppendLine("</root>");


            string message = sb.ToString();
			string rsp = Send("W14",message);

            if (string.IsNullOrEmpty(rsp))
            {
                MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices StopHistoryTask ret IsNullOrEmpty ret:{0}", ret));
                return false;
            }
			System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
			xdoc.LoadXml(rsp);
            UInt32 retVal = Convert.ToUInt32(xdoc.SelectSingleNode("//root/head/code").InnerText);
			ret = retVal == 1 ? true : false;
            MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices StopHistoryTask ret:{0}", ret));
            return ret;
		}
            


		#endregion

		#region Private Functions

		private ErrorMsg GetErrorMsg(string rsp) {
			if (string.IsNullOrEmpty(rsp))
				return new ErrorMsg() { Result = 1, ResultDescription = "无此消息", };

			System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
			xdoc.LoadXml(rsp);
			ErrorMsg err = new ErrorMsg() {
                Result = Convert.ToUInt32(xdoc.SelectSingleNode("//root/head/code").InnerText),
                ResultDescription = xdoc.SelectSingleNode("//root/head/message").InnerText,
			};
			return err;
		}

		private string Send(string type, string msg, bool isConnTest = false) {
			string rsp;
			try {
                string starttime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                rsp = CommProtocol.SendProtocol(type, msg);
                string endtime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                AppUtil.Common.Utils.SaveDebugLog(type, string.Format("[{0}]{1}[{2}]{3}",starttime+Environment.NewLine, msg + Environment.NewLine ,endtime+Environment.NewLine, rsp+Environment.NewLine));
				if (FireMessage != null)
					FireMessage("服务器：【" + ServerIP + "】连接成功");

			}
			catch (SDKCallException ex) {
				MyLog4Net.Container.Instance.Log.ErrorWithDebugView(ex.ToString());

				if (ex.ErrorCode == (uint)SDKCallExceptionCode.EndpointNotFound) {
					if (FireMessage != null)
						FireMessage("连接服务器异常");
				}
				else if (ex.ErrorCode == (uint)SDKCallExceptionCode.NetDispatcherFault) {
					if (FireMessage != null)
						FireMessage("数据解析异常，请重试");
				}
				else if (ex.ErrorCode == (uint)SDKCallExceptionCode.Other) {
					if (FireMessage != null)
						FireMessage("连接服务器异常，未知原因");
				}
				return "";
			}
			ErrorMsg err = GetErrorMsg(rsp);
			if (err.Result == (int)SDKCallExceptionCode.UserNotLogin && !isConnTest) {
				if (UserDisConnected != null)
					UserDisConnected("");

			}
			else if (err.Result != 1) {
				throw new SDKCallException(err.Result, err.ResultDescription);
			}
			return rsp;
		}



		#endregion




	}

    public class historytaskstatus
    {
        public string status { get; set; }
        public string progress { get; set; }
        public string errorcode { get; set; }
        public string loadpicnum { get; set; }
        public string errormessage { get; set; }
    }

    public class ErrorMsg
    {
        public uint Result { get; set; }
        public string ResultDescription { get; set; }
    }
}
