using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyLog4Net;
using AppUtil;

namespace com.VehicleAnalyse.SrcService
{
	public class PicService {
        //public event Action<DataModel.TaskInfoV3_1> TaskDeleted;
        //public event Action<DataModel.TaskInfoV3_1> TaskAdded;
        //public event Action<DataModel.TaskInfoV3_1> TaskMonified;
        //public event Action<DataModel.UploadTaskInfoV3_1> UpLoadLocalFile;

		public event Action<string> FireMessage;
		public event Action<string> UserDisConnected;
		#region Fields
		public bool IsConnected { get; set; }
		private PicWebserviceClientProtocol CommProtocol = null;
		public string WebserviceUrl { get; set; }
		private string ServerIP { get; set; }

        //private List<TaskInfoV3_1> m_taskList = new List<TaskInfoV3_1>();
		private bool isTaskListInited = false;
		private bool isExit = false;

        private ulong Context = 0;
        #endregion

		#region Constructors

        public PicService(string url)
        {
			IsConnected = false;
			WebserviceUrl = url;
			CommProtocol = new PicWebserviceClientProtocol();
		}

		#endregion

		#region Public Functions
		public bool Init(string serverip, uint serverport) {
			isExit = false;
			isTaskListInited = false;
			//m_taskList = new List<TaskInfoV3_1>();
			CommProtocol.Init(string.Format(WebserviceUrl, serverip, serverport));
            bool ret = true;
			return ret;
		}

		public void UnInit() {
			isExit = true;
			isTaskListInited = false;
			//m_taskList = new List<TaskInfoV3_1>();
			IsConnected = false;
			CommProtocol.UnInit();
		}


        

		public bool SendPic(List<pic> piclist) {
            MyLog4Net.Container.Instance.Log.DebugWithDebugView("CommProtocol start SendPic");
            bool ret = false;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\" ?>");
            sb.AppendLine("<root>");
            foreach (var item in piclist)
            {
                sb.AppendLine("<pic>");
                sb.AppendLine("<tpbz>"+item.tpbz+"</tpbz>");
                sb.AppendLine("<tpurl>" + item.tpurl + "</tpurl>");
                sb.AppendLine("<xjbz>" + item.xjbz + "</xjbz>");
                sb.AppendLine("<rwlx>" + item.rwlx + "</rwlx>");
                sb.AppendLine("<rwyxj>" + item.rwyxj + "</rwyxj>");
                sb.AppendLine("<tpzpsjc>" + item.tpzpsjc + "</tpzpsjc>");
                sb.AppendLine("<cpwz>" + item.cpwz + "</cpwz>");
                sb.AppendLine("<cljcqyx>" + item.cljcqyx + "</cljcqyx>");
                sb.AppendLine("<cljcqyy>" + item.cljcqyy + "</cljcqyy>");
                sb.AppendLine("<cljcqyw>" + item.cljcqyw + "</cljcqyw>");
                sb.AppendLine("<cljcqyh>" + item.cljcqyh + "</cljcqyh>");
                sb.AppendLine("<yhsj>" + item.yhsj + "</yhsj>");
                sb.AppendLine("</pic>");
            }
            sb.AppendLine("</root>");
            string message = sb.ToString();

			string rsp = Send("W10",message);

            if (string.IsNullOrEmpty(rsp))
            {
                MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices SendPic ret IsNullOrEmpty ret:{0}", ret));
                return false;
            }
			System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
			xdoc.LoadXml(rsp);
            UInt32 retVal = Convert.ToUInt32(xdoc.SelectSingleNode("//root/head/code").InnerText);
			ret = retVal == 1 ? true : false;
            MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices SendPic ret:{0}", ret));
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
				Result = Convert.ToUInt32(xdoc.SelectSingleNode("//root/head/value").InnerText),
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
			else if (err.Result != 0) {
				throw new SDKCallException(err.Result, err.ResultDescription);
			}
			return rsp;
		}



		#endregion




	}


    public class pic
    {
        public string tpbz { get; set; }
        public string tpurl { get; set; }
        public string xjbz { get; set; }
        public string rwlx { get; set; }
        public string rwyxj { get; set; }
        public string tpzpsjc { get; set; }
        public string cpwz { get; set; }
        public string cljcqyx { get; set; }
        public string cljcqyy { get; set; }
        public string cljcqyw { get; set; }
        public string cljcqyh { get; set; }
        public string yhsj { get; set; }

    }

    public class historytaskstatus
    {
        public string rwid { get; set; }
    }

    public class ErrorMsg
    {
        public uint Result { get; set; }
        public string ResultDescription { get; set; }
    }
}
