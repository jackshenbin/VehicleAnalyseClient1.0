using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyLog4Net;
using AppUtil;

namespace com.VehicleAnalyse.SearchService
{
    public class SearchService
    {
        //public event Action<DataModel.TaskInfoV3_1> TaskDeleted;
        //public event Action<DataModel.TaskInfoV3_1> TaskAdded;
        //public event Action<DataModel.TaskInfoV3_1> TaskMonified;
        //public event Action<DataModel.UploadTaskInfoV3_1> UpLoadLocalFile;

        public event Action<string> FireMessage;
        public event Action<string> UserDisConnected;
        #region Fields
        public bool IsConnected { get; set; }
        private SearchWebserviceClientProtocol CommProtocol = null;
        public string WebserviceUrl { get; set; }
        private string ServerIP { get; set; }

        //private List<TaskInfoV3_1> m_taskList = new List<TaskInfoV3_1>();
        private bool isTaskListInited = false;
        private bool isExit = false;

        private ulong Context = 0;

        private List<string> detailfileds = new List<string>(){  
            "WatchTime",
            "CameraCode",
            "PicId",
            "VehicleRectX",
            "VehicleRectY",
            "VehicleRectWidth",
            "VehicleRectHeight",
            "PlateRectX",
            "PlateRectY",
            "PlateRectWidth",
            "PlateRectHeight",
            "PlateNoConf",
            "PlateNo",
            "PlateNumRow",
            "PlateColorNo",
            "CarColorNo",
            "CarColorConf",
            "CarTypeNo",
            "CarTypeConf",
            "CarTypeDetailNo",
            "CarTypeDetailConf",
            "CarLabelNo",
            "CarLabeConf",
            "CarLabelDetailNo",
            "CarLabeDetailConf",
            "DriverIsPhoneing",
            "DriverIsPhoneingConf",
            "DriverIsSafebelt",
            "DriverIsSafebeltConf",
            "PassengerIsSafebelt",
            "PassengerIsSafebeltConf",
            "DriverIsSunVisor",
            "DriverIsSunVisorConf",
            "PassengerIsSunVisor",
            "PassengerIsSunVisorConf",
            "DriverRectX",
            "DriverRectY",
            "DriverRectWidth",
            "DriverRectHeight",
            "PassengerRectX",
            "PassengerRectY",
            "PassengerRectWidth",
            "PassengerRectHeight",
            "VehicleDirection",
            "ImageUrl",
            "RegionMatchX",
            "RegionMatchY",
            "RegionMatchWidth",
            "RegionMatchHeight",                                               
            "ConsoleIsSomething",
            "ConsoleIsSomethingConf",
            "IsPendant",
            "IsPendantConf",
            "AILabel",
         };

        #endregion

        #region Constructors

        public SearchService(string url)
        {
            IsConnected = false;
            WebserviceUrl = url;
            CommProtocol = new SearchWebserviceClientProtocol();
        }

        #endregion

        #region Public Functions
        public bool Init(string serverip, uint serverport)
        {
            isExit = false;
            isTaskListInited = false;
            //m_taskList = new List<TaskInfoV3_1>();
            CommProtocol.Init(string.Format(WebserviceUrl, serverip, serverport));

            IsConnected = true;
            ServerIP = serverip;
            if (FireMessage != null)
                FireMessage("服务器：【" + ServerIP + "】连接成功");

            return true;
        }

        public void UnInit()
        {
            isExit = true;
            isTaskListInited = false;
            //m_taskList = new List<TaskInfoV3_1>();
            IsConnected = false;
            CommProtocol.UnInit();
        }


        //public List<ObjSimpleInfo> Search(Parameters searchparam,out long totalcount,out long currcount)
        //{
        //    totalcount = 1000;
        //    currcount = 100;
        //    MyLog4Net.Container.Instance.Log.DebugWithDebugView("CommProtocol start Search");

        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\" ?>");
        //    sb.AppendLine("<root>");
        //    sb.AppendLine("<Version>1.0.0.1</Version>");//<!-- 版本号，用于版本号校验 -->
        //    sb.AppendLine("<DeviceID>" + searchparam.DeviceID + "</DeviceID>");
        //    sb.AppendLine("<StartTime>" + searchparam.StartTime.ToString("yyyy-MM-dd HH:mm:ss.fff") + "</StartTime>");//<!-- 检索开始时间 -->
        //    sb.AppendLine("<EndTime>" + searchparam.EndTime.ToString("yyyy-MM-dd HH:mm:ss.fff") + "</EndTime>");//<!-- 检索结束时间 -->
        //    sb.AppendLine("<Similar>" + searchparam.Similar.ToString() + "</Similar>");
        //    string ResultNumRange = "";
        //    searchparam.ResultNumRange.ForEach(item => ResultNumRange += item + ",");
        //    ResultNumRange = ResultNumRange.TrimEnd(',');
        //    sb.AppendLine("<ResultNumRange>" + ResultNumRange + "</ResultNumRange>");
        //    sb.AppendLine("<Devicetype>" + searchparam.Devicetype + "</Devicetype>");
        //    sb.AppendLine("<AlgorithmFilterType>" + searchparam.AlgorithmFilterType + "</AlgorithmFilterType>");
        //    sb.AppendLine("<ObjType>" + searchparam.ObjType + "</ObjType>");
        //    //string UpBodyColor = "";
        //    //searchparam.UpBodyColor.ForEach(item => { if (item >= 0) UpBodyColor += item + ","; });
        //    //UpBodyColor = UpBodyColor.TrimEnd(',');
        //    //sb.AppendLine("<UpBodyColor>" + UpBodyColor + "</UpBodyColor>");
        //    //string DownBodyColor = "";
        //    //searchparam.DownBodyColor.ForEach(item => { if (item >= 0)DownBodyColor += item + ","; });
        //    //DownBodyColor = DownBodyColor.TrimEnd(',');
        //    //sb.AppendLine("<DownBodyColor>" + DownBodyColor + "</DownBodyColor>");
        //    string GlobRect = string.Format("{0},{1},{2},{3}", searchparam.GlobRect.X, searchparam.GlobRect.Y, searchparam.GlobRect.Width, searchparam.GlobRect.Height);
        //    sb.AppendLine("<GlobRect>" + GlobRect + "</GlobRect>");
        //    string PartRect = string.Format("{0},{1},{2},{3}", searchparam.PartRect.X, searchparam.PartRect.Y, searchparam.PartRect.Width, searchparam.PartRect.Height);
        //    sb.AppendLine("<PartRect>" + PartRect + "</PartRect>");
        //    sb.AppendLine("<PlateNo>" + searchparam.PlateNo + "</PlateNo>");
        //    string CarColorNos = "";
        //    searchparam.CarColorNos.ForEach(item =>{ if (item >= 0) CarColorNos += item + ","; });
        //    CarColorNos = CarColorNos.TrimEnd(',');
        //    sb.AppendLine("<CarColorNos>" + CarColorNos + "</CarColorNos>");
        //    string PlateColorNos = "";
        //    searchparam.PlateColorNos.ForEach(item =>{ if (item >= 0) PlateColorNos += item + ","; });
        //    PlateColorNos = PlateColorNos.TrimEnd(',');
        //    sb.AppendLine("<PlateColorNos>" + PlateColorNos + "</PlateColorNos>");
        //    string CarTypeNos = "";
        //    searchparam.CarTypeNos.ForEach(item => { if (item >= 0)CarTypeNos += item + ","; });
        //    CarTypeNos = CarTypeNos.TrimEnd(',');
        //    sb.AppendLine("<CarTypeNos>" + CarTypeNos + "</CarTypeNos>");
        //    string CarTypeDetailNos = "";
        //    searchparam.CarTypeDetailNos.ForEach(item =>{ if (item >= 0) CarTypeDetailNos += item + ","; });
        //    CarTypeDetailNos = CarTypeDetailNos.TrimEnd(',');
        //    sb.AppendLine("<CarTypeDetailNos>" + CarTypeDetailNos + "</CarTypeDetailNos>");
        //    string CarLabelNos = "";
        //    searchparam.CarLabelNos.ForEach(item =>{ if (item >= 0) CarLabelNos += item + ","; });
        //    CarLabelNos = CarLabelNos.TrimEnd(',');
        //    sb.AppendLine("<CarLabelNos>" + CarLabelNos + "</CarLabelNos>");
        //    string CarLabelDetailNos = "";
        //    searchparam.CarLabelDetailNos.ForEach(item => { if (item >= 0)CarLabelDetailNos += item + ","; });
        //    CarLabelDetailNos = CarLabelDetailNos.TrimEnd(',');
        //    sb.AppendLine("<CarLabelDetailNos>" + CarLabelDetailNos + "</CarLabelDetailNos>");
        //    string PlateNumRows = "";
        //    searchparam.PlateNumRows.ForEach(item => { if (item >= 0)PlateNumRows += item + ","; });
        //    PlateNumRows = PlateNumRows.TrimEnd(',');
        //    sb.AppendLine("<PlateNumRows>" + PlateNumRows + "</PlateNumRows>");
        //    sb.AppendLine("<DriverIsPhoneing>"+(searchparam.DriverIsPhoneing>=0?searchparam.DriverIsPhoneing.ToString():"")+"</DriverIsPhoneing>");
        //    sb.AppendLine("<DriverIsSafebelt>" + (searchparam.DriverIsSafebelt >= 0 ? searchparam.DriverIsSafebelt.ToString() : "") + "</DriverIsSafebelt>");
        //    sb.AppendLine("<PassengerIsSafebelt>" + (searchparam.PassengerIsSafebelt >= 0 ? searchparam.PassengerIsSafebelt.ToString() : "") + "</PassengerIsSafebelt>");
        //    sb.AppendLine("<DriverIsSunVisor>" + (searchparam.DriverIsSunVisor >= 0 ? searchparam.DriverIsSunVisor.ToString() : "") + "</DriverIsSunVisor>");
        //    sb.AppendLine("<PassengerIsSunVisor>" + (searchparam.PassengerIsSunVisor >= 0 ? searchparam.PassengerIsSunVisor.ToString() : "") + "</PassengerIsSunVisor>");
        //    sb.AppendLine("<ResultFileds>WatchTime</ResultFileds>");//<!-- 目标详情字段 -->
        //    sb.AppendLine("<PictureData></PictureData>");
        //    sb.AppendLine("</root>");
        //    string message = sb.ToString();
        //    string rsp = Send("COMBINE_SEARCH_REQ", message);
        //    if (string.IsNullOrEmpty(rsp))
        //    {
        //        MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices Search ret IsNullOrEmpty"));
        //        return new List<ObjSimpleInfo>();
        //    }
        //    System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
        //    xdoc.LoadXml(rsp);

        //    var TotalObjNum = xdoc.SelectSingleNode("//root/Body/TotalObjNum");
        //    totalcount = Convert.ToInt64(TotalObjNum.InnerText);

        //    List<ObjSimpleInfo> retval = new List<ObjSimpleInfo>();
        //        var nodelist = xdoc.SelectNodes("//root/Body/ObjDetailInfoList/ObjDetailInfo");

        //        foreach (System.Xml.XmlNode node in nodelist)
        //        {
        //            string ObjKey = node.SelectSingleNode("ObjKey").InnerText;
        //            string WatchTime = node.SelectSingleNode("WatchTime").InnerText;
        //            retval.Add(new ObjSimpleInfo() { ObjKey = ObjKey, WatchTime = DateTime.ParseExact(WatchTime, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture) });
        //        }

        //        MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices Search retval Count:{0}", retval.Count));
        //    return retval;

        //}


        public List<ObjDetailInfo> Search(Parameters searchparam, out long totalcount, out long currcount)
        {
            totalcount = 1000;
            currcount = 100;
            MyLog4Net.Container.Instance.Log.DebugWithDebugView("CommProtocol start Search");

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\" ?>");
            sb.AppendLine("<root>");
            sb.AppendLine("<Version>1.0.0.1</Version>");//<!-- 版本号，用于版本号校验 -->
            sb.AppendLine("<DeviceID>" + searchparam.DeviceID + "</DeviceID>");
            sb.AppendLine("<StartTime>" + searchparam.StartTime.ToString("yyyy-MM-dd HH:mm:ss.fff") + "</StartTime>");//<!-- 检索开始时间 -->
            sb.AppendLine("<EndTime>" + searchparam.EndTime.ToString("yyyy-MM-dd HH:mm:ss.fff") + "</EndTime>");//<!-- 检索结束时间 -->
            sb.AppendLine("<Similar>" + searchparam.Similar.ToString() + "</Similar>");
            string ResultNumRange = "";
            searchparam.ResultNumRange.ForEach(item => ResultNumRange += item + ",");
            ResultNumRange = ResultNumRange.TrimEnd(',');
            sb.AppendLine("<ResultNumRange>" + ResultNumRange + "</ResultNumRange>");
            sb.AppendLine("<Devicetype>" + searchparam.Devicetype + "</Devicetype>");
            sb.AppendLine("<AlgorithmFilterType>" + searchparam.AlgorithmFilterType + "</AlgorithmFilterType>");
            sb.AppendLine("<ObjType>" + searchparam.ObjType + "</ObjType>");
            //string UpBodyColor = "";
            //searchparam.UpBodyColor.ForEach(item => { if (item >= 0) UpBodyColor += item + ","; });
            //UpBodyColor = UpBodyColor.TrimEnd(',');
            //sb.AppendLine("<UpBodyColor>" + UpBodyColor + "</UpBodyColor>");
            //string DownBodyColor = "";
            //searchparam.DownBodyColor.ForEach(item => { if (item >= 0)DownBodyColor += item + ","; });
            //DownBodyColor = DownBodyColor.TrimEnd(',');
            //sb.AppendLine("<DownBodyColor>" + DownBodyColor + "</DownBodyColor>");
            string GlobRect = string.Format("{0},{1},{2},{3}", searchparam.GlobRect.X, searchparam.GlobRect.Y, searchparam.GlobRect.Width, searchparam.GlobRect.Height);
            sb.AppendLine("<GlobRect>" + GlobRect + "</GlobRect>");
            string PartRect = string.Format("{0},{1},{2},{3}", searchparam.PartRect.X, searchparam.PartRect.Y, searchparam.PartRect.Width, searchparam.PartRect.Height);
            sb.AppendLine("<PartRect>" + PartRect + "</PartRect>");
            sb.AppendLine("<PlateNo>" + searchparam.PlateNo + "</PlateNo>");
            string CarColorNos = "";
            searchparam.CarColorNos.ForEach(item =>{ if (item >= 0) CarColorNos += item + ","; });
            CarColorNos = CarColorNos.TrimEnd(',');
            sb.AppendLine("<CarColorNos>" + CarColorNos + "</CarColorNos>");
            string PlateColorNos = "";
            searchparam.PlateColorNos.ForEach(item =>{ if (item >= 0) PlateColorNos += item + ","; });
            PlateColorNos = PlateColorNos.TrimEnd(',');
            sb.AppendLine("<PlateColorNos>" + PlateColorNos + "</PlateColorNos>");
            string CarTypeNos = "";
            searchparam.CarTypeNos.ForEach(item => { if (item >= 0)CarTypeNos += item + ","; });
            CarTypeNos = CarTypeNos.TrimEnd(',');
            sb.AppendLine("<CarTypeNos>" + CarTypeNos + "</CarTypeNos>");
            string CarTypeDetailNos = "";
            searchparam.CarTypeDetailNos.ForEach(item =>{ if (item >= 0) CarTypeDetailNos += item + ","; });
            CarTypeDetailNos = CarTypeDetailNos.TrimEnd(',');
            sb.AppendLine("<CarTypeDetailNos>" + CarTypeDetailNos + "</CarTypeDetailNos>");
            string CarLabelNos = "";
            searchparam.CarLabelNos.ForEach(item =>{ if (item >= 0) CarLabelNos += item + ","; });
            CarLabelNos = CarLabelNos.TrimEnd(',');
            sb.AppendLine("<CarLabelNos>" + CarLabelNos + "</CarLabelNos>");
            string CarLabelDetailNos = "";
            searchparam.CarLabelDetailNos.ForEach(item => { if (item >= 0)CarLabelDetailNos += item + ","; });
            CarLabelDetailNos = CarLabelDetailNos.TrimEnd(',');
            sb.AppendLine("<CarLabelDetailNos>" + CarLabelDetailNos + "</CarLabelDetailNos>");
            string PlateNumRows = "";
            searchparam.PlateNumRows.ForEach(item => { if (item >= 0)PlateNumRows += item + ","; });
            PlateNumRows = PlateNumRows.TrimEnd(',');
            sb.AppendLine("<PlateNumRows>" + PlateNumRows + "</PlateNumRows>");
            sb.AppendLine("<DriverIsPhoneing>"+(searchparam.DriverIsPhoneing>=0?searchparam.DriverIsPhoneing.ToString():"")+"</DriverIsPhoneing>");
            sb.AppendLine("<DriverIsSafebelt>" + (searchparam.DriverIsSafebelt >= 0 ? searchparam.DriverIsSafebelt.ToString() : "") + "</DriverIsSafebelt>");
            sb.AppendLine("<PassengerIsSafebelt>" + (searchparam.PassengerIsSafebelt >= 0 ? searchparam.PassengerIsSafebelt.ToString() : "") + "</PassengerIsSafebelt>");
            sb.AppendLine("<DriverIsSunVisor>" + (searchparam.DriverIsSunVisor >= 0 ? searchparam.DriverIsSunVisor.ToString() : "") + "</DriverIsSunVisor>");
            sb.AppendLine("<PassengerIsSunVisor>" + (searchparam.PassengerIsSunVisor >= 0 ? searchparam.PassengerIsSunVisor.ToString() : "") + "</PassengerIsSunVisor>");
            StringBuilder temp = new StringBuilder();
            foreach (var item in detailfileds)
            {
                temp.Append(item + ",");
            }
            sb.AppendLine("<ResultFileds>" + temp.ToString().TrimEnd(',') + "</ResultFileds>");//<!-- 目标详情字段 -->

            sb.AppendLine("<PictureData></PictureData>");
            sb.AppendLine("</root>");
            string message = sb.ToString();
            string rsp = Send("COMBINE_SEARCH_REQ", message);
            if (string.IsNullOrEmpty(rsp))
            {
                MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices Search ret IsNullOrEmpty"));
                return new List<ObjDetailInfo>();
            }
            System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
            xdoc.LoadXml(rsp);

            var TotalObjNum = xdoc.SelectSingleNode("//root/Body/TotalObjNum");
            totalcount = Convert.ToInt64(TotalObjNum.InnerText);

            List<ObjDetailInfo> retval = new List<ObjDetailInfo>();
            var nodelist = xdoc.SelectNodes("//root/Body/ObjDetailInfoList/ObjDetailInfo");

            foreach (System.Xml.XmlNode node in nodelist)
            {
                ObjDetailInfo de = AppUtil.Common.XMLSerilize.DeserilizeObject<ObjDetailInfo>(node.OuterXml);
                retval.Add(de);
            }

                MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices Search retval Count:{0}", retval.Count));
            return retval;

        }

        public List<ObjDetailInfo> CompareSearch(Parameters searchparam,out long TotalCount)
        {
            MyLog4Net.Container.Instance.Log.DebugWithDebugView("CommProtocol start CompareSearch");
            TotalCount = 0;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\" ?>");
            sb.AppendLine("<root>");
            sb.AppendLine("<Version>1.0.0.1</Version>");//<!-- 版本号，用于版本号校验 -->
            sb.AppendLine("<DeviceID>" + searchparam.DeviceID + "</DeviceID>");
            sb.AppendLine("<StartTime>" + searchparam.StartTime.ToString("yyyy-MM-dd HH:mm:ss.fff") + "</StartTime>");//<!-- 检索开始时间 -->
            sb.AppendLine("<EndTime>" + searchparam.EndTime.ToString("yyyy-MM-dd HH:mm:ss.fff") + "</EndTime>");//<!-- 检索结束时间 -->
            sb.AppendLine("<Similar>" + searchparam.Similar.ToString() + "</Similar>");
            string ResultNumRange = "";
            searchparam.ResultNumRange.ForEach(item => ResultNumRange += item + ",");
            ResultNumRange = ResultNumRange.TrimEnd(',');
            sb.AppendLine("<ResultNumRange>" + ResultNumRange + "</ResultNumRange>");
            sb.AppendLine("<Devicetype>" + searchparam.Devicetype + "</Devicetype>");
            sb.AppendLine("<AlgorithmFilterType>" + searchparam.AlgorithmFilterType + "</AlgorithmFilterType>");
            //sb.AppendLine("<ObjType>" + searchparam.ObjType + "</ObjType>");
            //string UpBodyColor = "";
            //searchparam.UpBodyColor.ForEach(item => { if (item > 0) UpBodyColor += item + ","; });
            //UpBodyColor = UpBodyColor.TrimEnd(',');
            //sb.AppendLine("<UpBodyColor>" + UpBodyColor + "</UpBodyColor>");
            //string DownBodyColor = "";
            //searchparam.DownBodyColor.ForEach(item => { if (item > 0)DownBodyColor += item + ","; });
            //DownBodyColor = DownBodyColor.TrimEnd(',');
            //sb.AppendLine("<DownBodyColor>" + DownBodyColor + "</DownBodyColor>");
            string GlobRect = string.Format("{0},{1},{2},{3}", searchparam.GlobRect.X, searchparam.GlobRect.Y, searchparam.GlobRect.Width, searchparam.GlobRect.Height);
            sb.AppendLine("<GlobRect>" + GlobRect + "</GlobRect>");
            string PartRect = string.Format("{0},{1},{2},{3}", searchparam.PartRect.X, searchparam.PartRect.Y, searchparam.PartRect.Width, searchparam.PartRect.Height);
            sb.AppendLine("<PartRect>" + PartRect + "</PartRect>");
            sb.AppendLine("<PlateNo>" + searchparam.PlateNo + "</PlateNo>");
            //string CarColorNos = "";
            //searchparam.CarColorNos.ForEach(item =>{ if (item > 0) CarColorNos += item + ","; });
            //CarColorNos = CarColorNos.TrimEnd(',');
            //sb.AppendLine("<CarColorNos>" + CarColorNos + "</CarColorNos>");
            //string PlateColorNos = "";
            //searchparam.PlateColorNos.ForEach(item =>{ if (item > 0) PlateColorNos += item + ","; });
            //PlateColorNos = PlateColorNos.TrimEnd(',');
            //sb.AppendLine("<PlateColorNos>" + PlateColorNos + "</PlateColorNos>");
            //string CarTypeNos = "";
            //searchparam.CarTypeNos.ForEach(item => { if (item > 0)CarTypeNos += item + ","; });
            //CarTypeNos = CarTypeNos.TrimEnd(',');
            //sb.AppendLine("<CarTypeNos>" + CarTypeNos + "</CarTypeNos>");
            //string CarTypeDetailNos = "";
            //searchparam.CarTypeDetailNos.ForEach(item =>{ if (item > 0) CarTypeDetailNos += item + ","; });
            //CarTypeDetailNos = CarTypeDetailNos.TrimEnd(',');
            //sb.AppendLine("<CarTypeDetailNos>" + CarTypeDetailNos + "</CarTypeDetailNos>");
            //string CarLabelNos = "";
            //searchparam.CarLabelNos.ForEach(item =>{ if (item > 0) CarLabelNos += item + ","; });
            //CarLabelNos = CarLabelNos.TrimEnd(',');
            //sb.AppendLine("<CarLabelNos>" + CarLabelNos + "</CarLabelNos>");
            //string CarLabelDetailNos = "";
            //searchparam.CarLabelDetailNos.ForEach(item => { if (item > 0)CarLabelDetailNos += item + ","; });
            //CarLabelDetailNos = CarLabelDetailNos.TrimEnd(',');
            //sb.AppendLine("<CarLabelDetailNos>" + CarLabelDetailNos + "</CarLabelDetailNos>");
            //string PlateNumRows = "";
            //searchparam.PlateNumRows.ForEach(item => { if (item > 0)PlateNumRows += item + ","; });
            //PlateNumRows = PlateNumRows.TrimEnd(',');
            //sb.AppendLine("<PlateNumRows>" + PlateNumRows + "</PlateNumRows>");
            //sb.AppendLine("<DriverIsPhoneing>"+(searchparam.DriverIsPhoneing>=0?searchparam.DriverIsPhoneing.ToString():"")+"</DriverIsPhoneing>");
            //sb.AppendLine("<DriverIsSafebelt>" + (searchparam.DriverIsSafebelt >= 0 ? searchparam.DriverIsSafebelt.ToString() : "") + "</DriverIsSafebelt>");
            //sb.AppendLine("<PassengerIsSafebelt>" + (searchparam.PassengerIsSafebelt >= 0 ? searchparam.PassengerIsSafebelt.ToString() : "") + "</PassengerIsSafebelt>");
            //sb.AppendLine("<DriverIsSunVisor>" + (searchparam.DriverIsSunVisor >= 0 ? searchparam.DriverIsSunVisor.ToString() : "") + "</DriverIsSunVisor>");
            //sb.AppendLine("<PassengerIsSunVisor>" + (searchparam.PassengerIsSunVisor >= 0 ? searchparam.PassengerIsSunVisor.ToString() : "") + "</PassengerIsSunVisor>");
            StringBuilder temp = new StringBuilder();
            foreach (var item in detailfileds)
            {
                temp.Append(item + ",");
            }
            sb.AppendLine("<ResultFileds>" + temp.ToString().TrimEnd(',') + "</ResultFileds>");//<!-- 目标详情字段 -->
            sb.AppendLine("<PictureData>" + searchparam.PictureData + "</PictureData>");
            sb.AppendLine("<PlateNoWeight>" + searchparam.PlateNoWeight + "</PlateNoWeight>");
            sb.AppendLine("</root>");
            string message = sb.ToString();
            string rsp = Send("COMBINE_SEARCH_REQ", message);
            if (string.IsNullOrEmpty(rsp))
            {
                MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices CompareSearch ret IsNullOrEmpty"));
                return new List<ObjDetailInfo>();
            }
            System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
            xdoc.LoadXml(rsp);
            var TotalObjNum = xdoc.SelectSingleNode("//root/Body/TotalObjNum");
            TotalCount = Convert.ToInt64(TotalObjNum.InnerText);
            List<ObjDetailInfo> retval = new List<ObjDetailInfo>();
            var nodelist = xdoc.SelectNodes("//root/Body/ObjDetailInfoList/ObjDetailInfo");

            foreach (System.Xml.XmlNode node in nodelist)
            {
                ObjDetailInfo de = AppUtil.Common.XMLSerilize.DeserilizeObject<ObjDetailInfo>(node.OuterXml);
                retval.Add(de);
            }

            MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices CompareSearch retval TotalMatch:{1}, Count:{0}", retval.Count, TotalCount));
            return retval;

        }
        private List<ObjDetailInfo> GetDetailResults(List<string> ids)
        {
            MyLog4Net.Container.Instance.Log.DebugWithDebugView("CommProtocol start GetDetailResults");
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\" ?>");
            sb.AppendLine("<root>");
            sb.AppendLine("<Version>1.0.0.1</Version>");//<!-- 版本号，用于版本号校验 -->
            sb.AppendLine("<ObjNum>" + ids.Count + "</ObjNum>");
            sb.AppendLine("<ObjKeyList>");
            foreach (var item in ids)
            {
                sb.AppendLine("<ObjKey>" + item + "</ObjKey>");
            }
            sb.AppendLine("</ObjKeyList>");
            StringBuilder temp = new StringBuilder();
            foreach (var item in detailfileds)
            {
                temp.Append(item + ",");
            }
            sb.AppendLine("<ResultFileds>"+temp.ToString().TrimEnd(',')+"</ResultFileds>");//<!-- 目标详情字段 -->
            sb.AppendLine("</root>");
            string message = sb.ToString();
            string rsp = Send("OBJ_DETAIL_INFO_GET_REQ", message);

            if (string.IsNullOrEmpty(rsp))
            {
                MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices GetDetailResults ret IsNullOrEmpty"));
                return new List<ObjDetailInfo>();
            }
            System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
            xdoc.LoadXml(rsp);
            List<ObjDetailInfo> retval = new List<ObjDetailInfo>();
            var nodelist = xdoc.SelectNodes("//root/Body/ObjDetailInfoList/ObjDetailInfo");

            foreach (System.Xml.XmlNode node in nodelist)
            {
                ObjDetailInfo de = AppUtil.Common.XMLSerilize.DeserilizeObject<ObjDetailInfo>(node.OuterXml);
                retval.Add(de);
            }

            MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices GetDetailResults retval Count:{0}", retval.Count));
            return retval;
        }

        public System.Drawing.Image GetThumbImg(string id)
        {
            MyLog4Net.Container.Instance.Log.DebugWithDebugView("CommProtocol start GetThumbImg");

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\" ?>");
            sb.AppendLine("<root>");
            sb.AppendLine("<Version>1.0.0.1</Version>");//<!-- 版本号，用于版本号校验 -->
            sb.AppendLine("<ObjNum>1</ObjNum>");
            sb.AppendLine("<ObjKeyList>");
            sb.AppendLine("<ObjKey>" + id + "</ObjKey>");
            sb.AppendLine("</ObjKeyList>");
            sb.AppendLine("<ResultFileds>WatchTime,ThumbImg</ResultFileds>");//<!-- 目标详情字段 -->
            sb.AppendLine("</root>");
            string message = sb.ToString();
            string rsp = Send("OBJ_DETAIL_INFO_GET_REQ", message);


            if (string.IsNullOrEmpty(rsp))
            {
                MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices GetThumbImg ret IsNullOrEmpty "));
                return new System.Drawing.Bitmap(1,1);
            }
            System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
            xdoc.LoadXml(rsp);
            System.Drawing.Image retval = new System.Drawing.Bitmap(1, 1);
            var nodelist = xdoc.SelectNodes("//root/Body/ObjDetailInfoList/ObjDetailInfo");

            foreach (System.Xml.XmlNode node in nodelist)
            {
                string ThumbImg = node.SelectSingleNode("ThumbImg").InnerText;
                byte[] byteimg = Convert.FromBase64String(ThumbImg);
                System.IO.MemoryStream streamimg = new System.IO.MemoryStream(byteimg);
                retval = System.Drawing.Image.FromStream(streamimg);

            }

            MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices GetThumbImg ret:OK"));
            return retval;
        }

        public List<Vehicle> GetImgFeature(string pictureData)
        {
            MyLog4Net.Container.Instance.Log.DebugWithDebugView("CommProtocol start GetImgFeature");

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\" ?>");
            sb.AppendLine("<root>");
            sb.AppendLine("<Version>1.0.0.1</Version>");//<!-- 版本号，用于版本号校验 -->
            sb.AppendLine("<PictureData>" + pictureData + "</PictureData>");
            sb.AppendLine("</root>");
            string message = sb.ToString();
            string rsp = Send("PIC_ALY_REQ", message);


            if (string.IsNullOrEmpty(rsp))
            {
                MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices GetImgFeature ret IsNullOrEmpty"));
                return new List<Vehicle>();
            }
            System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
            xdoc.LoadXml(rsp);

            List<Vehicle> retval = new List<Vehicle>();
            var nodelist = xdoc.SelectNodes("//root/Body/VehicleList/Vehicle");

            foreach (System.Xml.XmlNode node in nodelist)
            {
                Vehicle de = AppUtil.Common.XMLSerilize.DeserilizeObject<Vehicle>(node.OuterXml);
                retval.Add(de);
            }

            MyLog4Net.Container.Instance.Log.DebugWithDebugView(string.Format("CommServices GetImgFeature retval Count:{0}", retval.Count));
            return retval;
        }

        #endregion

        #region Private Functions


        private ErrorMsg GetErrorMsg(string rsp)
        {
            if (string.IsNullOrEmpty(rsp))
                return new ErrorMsg() { Result = 0, ResultDescription = "无此消息", };

            System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
            xdoc.LoadXml(rsp);
            ErrorMsg err = new ErrorMsg()
            {
                Result = Convert.ToUInt32(xdoc.SelectSingleNode("//root/Head/Code").InnerText),
                ResultDescription = xdoc.SelectSingleNode("//root/Head/Message").InnerText,
            };
            return err;
        }

        private string Send(string type, string msg, bool isConnTest = false)
        {
            string rsp;
            try
            {
                string starttime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                rsp = CommProtocol.SendProtocol(type, msg);
                string endtime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                AppUtil.Common.Utils.SaveDebugLog(type, string.Format("[{0}]{1}[{2}]{3}",starttime+Environment.NewLine, msg + Environment.NewLine ,endtime+Environment.NewLine, rsp+Environment.NewLine));
                if (FireMessage != null)
                    FireMessage("服务器：【" + ServerIP + "】连接成功");

            }
            catch (SDKCallException ex)
            {
                MyLog4Net.Container.Instance.Log.ErrorWithDebugView(ex.ToString());

                if (ex.ErrorCode == (uint)SDKCallExceptionCode.EndpointNotFound)
                {
                    if (FireMessage != null)
                        FireMessage("连接服务器异常");
                }
                else if (ex.ErrorCode == (uint)SDKCallExceptionCode.NetDispatcherFault)
                {
                    if (FireMessage != null)
                        FireMessage("数据解析异常，请重试");
                }
                else if (ex.ErrorCode == (uint)SDKCallExceptionCode.Other)
                {
                    if (FireMessage != null)
                        FireMessage("连接服务器异常，未知原因");
                }
                return "";
            }
            ErrorMsg err = GetErrorMsg(rsp);
            if (err.Result == (int)SDKCallExceptionCode.UserNotLogin && !isConnTest)
            {
                if (UserDisConnected != null)
                    UserDisConnected("");

            }
            else if (err.Result != 0)
            {
                throw new SDKCallException(err.Result, err.ResultDescription);
            }
            return rsp;
        }



        #endregion





    }
    public class ObjSimpleInfo
    {
        public string ObjKey { get; set; }//>obj_2</ObjKey>
        public DateTime WatchTime { get; set; }//>2016-04-07 15:12:00.123</WatchTime>
    }
    public class ObjDetailInfo
    {
        public string ObjKey { get; set; }//>obj_2</ObjKey>
        public string Similar { get; set; }//>90.05</Similar>
        public string Score { get; set; }
        public string PicId { get; set; }//>pic_2.jpg</PicId>
        public string WatchTime { get; set; }//>2016-04-07 15:12:00.123</WatchTime>
        public string CameraCode { get; set; }
        public string VehicleRectX { get; set; }
        public string VehicleRectY { get; set; }
        public string VehicleRectWidth { get; set; }
        public string VehicleRectHeight { get; set; }
        public string ThumbImgSize { get; set; }
        public string ThumbImg { get; set; }
        public string PlateRectX { get; set; }
        public string PlateRectY { get; set; }
        public string PlateRectWidth { get; set; }
        public string PlateRectHeight { get; set; }
        public string PlateImgSize { get; set; }
        public string PlateImg { get; set; }
        public string PlateNoConf { get; set; }
        public string PlateNo { get; set; }
        public string PlateNumRow { get; set; }
        public string PlateColorNo { get; set; }
        public string CarColorNo { get; set; }
        public string CarColorConf { get; set; }
        public string CarTypeNo { get; set; }
        public string CarTypeConf { get; set; }
        public string CarTypeDetailNo { get; set; }
        public string CarTypeDetailConf { get; set; }
        public string CarLabelNo { get; set; }
        public string CarLabeConf { get; set; }
        public string CarLabelDetailNo { get; set; }
        public string CarLabeDetailConf { get; set; }
        public string DriverIsPhoneing { get; set; }
        public string DriverIsPhoneingConf { get; set; }
        public string DriverIsSafebelt { get; set; }
        public string DriverIsSafebeltConf { get; set; }
        public string PassengerIsSafebelt { get; set; }
        public string PassengerIsSafebeltConf { get; set; }
        public string DriverIsSunVisor { get; set; }
        public string DriverIsSunVisorConf { get; set; }
        public string PassengerIsSunVisor { get; set; }
        public string PassengerIsSunVisorConf { get; set; }
        public string DriverRectX { get; set; }
        public string DriverRectY { get; set; }
        public string DriverRectWidth { get; set; }
        public string DriverRectHeight { get; set; }
        public string PassengerRectX { get; set; }
        public string PassengerRectY { get; set; }
        public string PassengerRectWidth { get; set; }
        public string PassengerRectHeight { get; set; }
        public string ImageUrl { get; set; }
        public string VehicleDirection { get; set; }
        public string RegionMatchX { get; set; }
        public string RegionMatchY { get; set; }
        public string RegionMatchWidth { get; set; }
        public string RegionMatchHeight { get; set; }
        public string ConsoleIsSomething { get; set; }              //中控台是否有杂物, 见E_IRAS_VEHICLE_WINDOW_STATE
        public string ConsoleIsSomethingConf { get; set; }     //中控台是否有杂物置信度
        public string IsPendant { get; set; }                                 //是否有挂饰物, 见E_IRAS_VEHICLE_WINDOW_STATE
        public string IsPendantConf { get; set; }                        //是否有挂饰物置信度
        public List<AILabel> AILabelList { get; set; }   
    }
    public class AILabel
    {
        public string AILabelRectX { get; set; }//	年检标志X坐标	<AILabel>子节点
        public string AILabelRectY { get; set; }//年检标志Y坐标	<AILabel>子节点
        public string AILabelRectW { get; set; }//年检标志宽度	<AILabel>子节点
        public string AILabelRectH { get; set; }//年检标志高度	<AILabel>子节点
        public string AILabelCof { get; set; }//	置信度			<AILabel>子节点
    }
    public class Parameters
    {
        public string Version { get; set; }//>1.0.0.1</Version ><!-- 版本号，用于版本号校验 -->
        public string DeviceID { get; set; }//>1231234</DeviceID>
        public DateTime StartTime { get; set; }//>2016-04-01 00:00:00.000</StartTime ><!-- 检索开始时间 -->
        public DateTime EndTime { get; set; }//>2016-04-07 23:59:59.999</EndTime ><!-- 检索结束时间 -->
        public int Similar { get; set; }//>60.00</Similar>
        public List<uint> ResultNumRange { get; set; }//>0,500</ResultNumRange>
        public uint Devicetype { get; set; }//>1</Devicetype>
        public uint ObjType { get; set; }//>1</ObjType>
        public uint AlgorithmFilterType { get; set; }//>2</AlgorithmFilterType>
        public List<int> UpBodyColor { get; set; }//>2,3</UpBodyColor>
        public List<int> DownBodyColor { get; set; }//>2,4</DownBodyColor>
        public System.Drawing.Rectangle GlobRect { get; set; }//>0,0,759,563</GlobRect>
        public System.Drawing.Rectangle PartRect { get; set; }//>125,267,146,76</PartRect>
        public string PlateNo { get; set; }//>沪A8154K</PlateNo>
        public List<int> CarColorNos { get; set; }//>1,2</CarColorNos>
        public List<int> PlateColorNos { get; set; }//>1,2</PlateColorNos>
        public List<int> CarTypeNos { get; set; }//>1,2</CarTypeNos>
        public List<int> CarTypeDetailNos { get; set; }//>2,3</CarTypeDetailNos>
        public List<int> CarLabelNos { get; set; }//>200,201</CarLabelNos>
        public List<int> CarLabelDetailNos { get; set; }//>1259,2256</CarLabelDetailNos>
        public List<int> PlateNumRows { get; set; }//>1,2</PlateNumRows>
        public int DriverIsPhoneing { get; set; }//>1</DriverIsPhoneing>
        public int DriverIsSafebelt { get; set; }//>1</DriverIsSafebelt>
        public int PassengerIsSafebelt { get; set; }//>2</PassengerIsSafebelt>
        public int DriverIsSunVisor { get; set; }//>2</DriverIsSunVisor>
        public int PassengerIsSunVisor { get; set; }//>2</PassengerIsSunVisor>
        public List<string> ResultFileds { get; set; }//>PicId,WatchTime</ResultFileds><!-- 目标详情字段 -->
        public string PictureData { get; set; }//>图片base64编码</PictureData>
        public uint CarColorWeight { get; set; }
        public uint PlateNoWeight { get; set; }
        public uint CarTypeWeight { get; set; }
        public uint CarLabelWeight { get; set; }
        public uint SimilarWeight { get; set; }

    }


    public class Vehicle
    {
        public string PlateNo { get; set; }//>沪123456</cphm>
        public string PlateConf { get; set; }//>30</cpztzxd>
        public string PlateColor { get; set; }//>1</cpys>
        public string PlateNumRows { get; set; }//>1</cpjg>
        public string CarLabel { get; set; }//>1</cbdllb>
        public string CarLabelDetail { get; set; }//>1</cbzllb>
        public string CarType { get; set; }//>1</cxcflb>
        public string CarTypeDetail { get; set; }//>1</cxxflb>
        public string CarColor { get; set; }//>1</csys>
        public string VehicleRectX { get; set; }
        public string VehicleRectY { get; set; }
        public string VehicleRectWidth { get; set; }
        public string VehicleRectHeight { get; set; }
    }
    public class ErrorMsg
    {
        public uint Result { get; set; }
        public string ResultDescription { get; set; }
    }
}
