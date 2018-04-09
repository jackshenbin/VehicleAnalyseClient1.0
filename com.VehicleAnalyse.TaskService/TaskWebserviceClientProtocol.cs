using System;
using System.Collections.Generic;
using System.Text;
using AppUtil;

namespace com.VehicleAnalyse.TaskService
{
    public enum SDKCallExceptionCode
    {
        EndpointNotFound = 1,
        NetDispatcherFault = 2,
        NoSuchResult = 29,
        UserNotLogin = 65592,
        Other = 0xff,
    }
    public class TaskWebserviceClientProtocol
    {
        private ulong Sequence = 0;

        //private ulong Context = 0;

        private WebReferenceTask.IraWebservice m_server = null;

        public WebReferenceTask.IraWebservice Server
        {
            get
            {
                if (m_server == null)
                    throw new NullReferenceException();
                return m_server;
            }
            set { m_server = value; }
        }

        public void Init(string url)
        {
            try
            {
                //url = "http://192.168.42.31:10001/?matchService.wsdl";
                m_server = new WebReferenceTask.IraWebservice();//webservice设置回档，使用配置文件方式，代码配置方式存在问题，在有的机器上接收8k以上数据
                m_server.Url = url;

            }
            catch (Exception ex)
            {
                throw new SDKCallException(1, ex.ToString());
            }

        }

        public void UnInit()
        {
            m_server = null;
            Sequence = 0;
            //Context  = 0;
        }


        //public string BuildProtocolBody<T>(T args)
        //{
        //    string h = "<?xml version=\"1.0\" ?><Root>";// encoding=\"gbk\"
        //    string t = "</Root>";

        //    string body = WinFormAppUtil.Common.XMLSerilize.SerilizeObject<T>(args);

        //    return string.Format("{0}{1}{2}", h, body, t);
        //}

        //public string BuildProtocolBody( string body)
        //{
        //    string h = "<?xml version=\"1.0\" ?><Root>";// encoding=\"gbk\"
        //    string t = "</Root>";


        //    return string.Format("{0}{1}{2}", h, body, t);
        //}


        public string SendProtocol(string reqtype,string request)
        {
            try
            {
                string retVal = Server.IraWebserviceReq(reqtype, request);

                return retVal;

            }
            catch (Exception ex)
            {
                if (ex.GetType().Name == "NetDispatcherFaultException")
                    throw new SDKCallException((uint)SDKCallExceptionCode.NetDispatcherFault, ex.ToString());
                else
                    throw new SDKCallException((uint)SDKCallExceptionCode.Other, ex.ToString());
            }


        }
    }

}
