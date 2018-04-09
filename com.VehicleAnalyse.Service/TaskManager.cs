using com.VehicleAnalyse.DataModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using com.VehicleAnalyse.Service.DAO;
using System.Diagnostics;
using System.Data.Objects;
using AppUtil;
using System.Threading;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.Xml;
using VehicleHelper.DataModel;
using MyLog4Net;
using System.Data;


namespace com.VehicleAnalyse.Service
{
    public class TaskManager
    {
        #region Events
        
        public event EventHandler StatusChanged;

        public event Action<List<AnalyseRecord>, long, string> TaskSearchFinished;

        public event Action<List<AnalyseRecord>, long, string> TaskSwitchFinished;

        public event Action<List<AnalyseRecord>,long,string> TaskCompareSearchFinished;

        public event Action<string> Message;

        #endregion

        #region Fields

        private bool m_isrunsearch = false;

        private readonly static int TIMEOUT = 10 * 1000;

        private static readonly int MAXPICCOUNT_ONCE = 500;

        private static readonly int INTERVAL_RECONNECT = 10; // seconds

        private static readonly TimeSpan MAXSPAN_NORESULT_RESEND = new TimeSpan(0, 0, 10);

        /// <summary>
        /// 最大允许等待插入分析结果队列的数量， 超过这个数量时， 不再发送图片
        /// </summary>
        private static readonly int MAXCOUNT_PENDINGANALYSERESULT = 5;

        /// <summary>
        /// 最大允许发送过图片但还没有收完结果的分析任务数量，大于这个数时将重发最老的任务图片
        /// </summary>
        private static readonly int MAXCOUNT_PENDINGRECEIVERESULTTASK = 2;

        //private ImageAnalysisService m_ImageAnalysisService;

        //private Queue<AnalyseTask> m_TaskQueue;

        private static List<AnalyseTask> m_TaskList;

        private static Dictionary<string, TaskProgressStatusInfo> m_RealTaskStatus;

        private string m_serverIP;

        private SearchService.Parameters m_lastCommitSearchParam;

        private int m_lastCommitSearchTotalCount;

        //private object m_SyncObj = new object();

        //private object m_SyncObjPendingResult = new object();

        //private DAOService m_DAOService;

        //private AnalyseTask m_CurrentTask;

        //private List<AnalyseTask> m_ProcessingTasks = new List<AnalyseTask>();

        //private Dictionary<AnalyseTask, List<string>> m_DTProcessingTask2Files;

        //private Tuple<AnalyseTask, PictureItem[]> m_FailedSendItems;

        //private Dictionary<AnalyseTask, ImageAnalyseEntities> m_DTTask2Entities;

        //private Tuple<AnalyseTask, List<AnalyseRecord>> m_PendingResults;

        //private TaskRunner<int, int> m_taskRunnerSendPics;

        //private TaskRunner<Tuple<string, Analyse_Result[]>, int> m_taskRunnerProcessResult;

        private bool m_Initialized = false;

        private Dictionary<string,bool> m_IsRealtimeRunning = new Dictionary<string,bool>();

        private bool m_Running = true;

        private bool m_Closed = false;

        private bool m_Connected;

        private object m_SyncObjReconnect = new object();

        //private TaskFactory m_taskFactory;

        //private CancellationToken m_CancellationToken;
        
        //private CancellationTokenSource m_TokenSource;
        
        private System.Threading.Tasks.Task m_LoopGetTaskStatus;

        //private ManualResetEvent m_MREReconnect;

        /// <summary>
        /// 存在队列还没有入库处理的分析结果数量， 太大时将减慢发送分析图片的速度
        /// </summary>
        private int m_CountPendingResult = 0;

        private string m_ResendPicId;

        private int m_WaitResendResult = 0;

        //private DateTime m_LatestTimeReceivedResult = DateTime.MinValue;

        //private List<AnalyseRecord> m_MemSearchAllResult;

        //private SemaphoreSlim sem = new SemaphoreSlim(0, 1);

        //private AnalyseRecord m_compareResult;


        private TaskService.TaskService m_taskService;

        private SrcService.PicService m_picService;

        private SearchService.SearchService m_searchService;

        #endregion

        #region Properties
        public bool Initialized
        {
            get
            {
                Trace.WriteLine("m_Initialized get:" + m_Initialized);
                return m_Initialized; 
            }
        }


        private AnalyseTask ProcessingTask
        {
            get;
            set;
            //get
            //{
            //    return m_CurrentTask;
            //}
            //set
            //{
            //    if (m_CurrentTask != value)
            //    {
            //        m_CurrentTask = value;
            //        if (m_CurrentTask != null)
            //        {
            //            // m_CurrentTask.StartAnalyseTime = DateTime.Now;
            //            UpdateStatus(m_CurrentTask, DataModel.TaskStatus.Analysing);
            //            if (Revisor != null)
            //            {
            //                Revisor.RegisterTask(m_CurrentTask);
            //            }
            //        }
            //    }
            //}
        }

        public bool Running
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
                        Connected = false;
                    }
                }
            }
        }

        public bool Connected
        {
            get;
            set;
            //get
            //{
            //    return m_Connected;
            //}
            //set
            //{
            //    lock (m_SyncObjReconnect)
            //    {
            //        if (m_Connected != value)
            //        {
            //            m_Connected = value;
            //        }
            //        if (!m_Closed && !m_Connected)
            //        {
            //            if (m_taskFactory == null)
            //            {
            //                m_MREReconnect = new ManualResetEvent(true);
            //                m_taskFactory = new TaskFactory();
            //                m_TokenSource = new CancellationTokenSource();
            //                m_LoopReconnectTask = m_taskFactory.StartNew(new Action(LoopReconnect), m_TokenSource.Token);
            //            }
            //            else
            //            {
            //                m_MREReconnect.Set();
            //            }

            //            //if (ReConnectStart != null)
            //            //{
            //            //    ReConnectStart(this, EventArgs.Empty);
            //            //}

            //        }
            //    }
            //}
        }


        #endregion

        #region Constructors

        public TaskManager()
        {
            m_taskService = new TaskService.TaskService("http://{0}:{1}/?IraWebservice.wsdl");
            m_picService = new SrcService.PicService("http://{0}:{1}/?IraWebservice.wsdl");
            m_searchService = new SearchService.SearchService("http://{0}:{1}/?matchservice.wsdl");

            //m_TaskQueue = new Queue<AnalyseTask>();
            m_TaskList = new List<AnalyseTask>();
            m_RealTaskStatus = new Dictionary<string, TaskProgressStatusInfo>();
            //m_ImageAnalysisService = imageAnalyseService;
            //m_ImageAnalysisService.PicturesRequest += ImageAnalysisService_PicturesRequest;
            // m_ImageAnalysisService.AnalyseResult += new Action<AnalyseRecord>(ImageAnalysisService_AnalyseResult);
            //m_ImageAnalysisService.AnalyseResultsByFile += new Action<Analyse_ResultByFile, IntPtr>(ImageAnalysisService_AnalyseResultsByFile);
            //m_ImageAnalysisService.AnalyseCompareResult += new Action<Analyse_ResultByFile, IntPtr>(ImageAnalysisService_AnalyseCompareResult);
            //m_DAOService = new DAOService();

            //m_DTProcessingTask2Files = new Dictionary<AnalyseTask, List<string>>();
            //m_DTTask2Entities = new Dictionary<AnalyseTask, ImageAnalyseEntities>();
            //m_taskRunnerSendPics = new TaskRunner<int, int>("SendPicsTaskRunner", ApplyInsertRequestPicTaskItemPolicy);
            //m_taskRunnerProcessResult = new TaskRunner<Tuple<string, Analyse_Result[]>, int>("ProcessResultTaskRunner", ApplyInsertProcessResultTaskItemPolicy);
        }

        #endregion

        #region Public helper functions

        private void thGetTaskStatus()
        {
            while (true)
            {
                if (!m_Initialized)
                    break;

                var list =  m_TaskList.FindAll(it => (it.Status != DataModel.TaskStatus.Finished && it.Status != DataModel.TaskStatus.AnalysingError)).ToArray();
                foreach (var item in list)
                {
                    var status =  QueryTaskSatus(item);
                    if (StatusChanged != null)
                        StatusChanged(status, null);
                }

                for (int i = 0; i < 100; i++)
                {
                    System.Threading.Thread.Sleep(100);
                    if (!m_Initialized)
                        break;

                }
            }
        }

        public void Init(string serverIP, uint taskPort, string picIP, uint picPort, string searchIP, uint searchPort)
        {
            if (m_Initialized)
            {
                return;
            }
            MyLog4Net.Container.Instance.Log.Debug("[TaskManager_Init] Entering using entities  ...");
            m_taskService.Init(serverIP, taskPort);
            m_picService.Init(picIP, picPort);
            m_searchService.Init(searchIP, searchPort);
            //m_Closed = false;
            m_Initialized = true;
            Trace.WriteLine("m_Initialized Init:" + m_Initialized);
            //List<AnalyseTask> tasks = m_DAOService.GetAllTasks();
            m_serverIP = serverIP;
            InitTaskList(serverIP);
            new System.Threading.Thread(thGetTaskStatus).Start();
            //if (tasks != null && tasks.Count > 0)
            //{
            //    StringBuilder sb = new StringBuilder("(");
            //    List<int> ids = new List<int>();
            //    lock (m_SyncObj)
            //    {
            //        using (ImageAnalyseEntities entities = m_DAOService.GetImageAnalyseEntities())
            //        {
            //            foreach (AnalyseTask task in tasks)
            //            {
            //                if (!m_DTId2Task.ContainsKey(task.TaskId))
            //                {
            //                    m_DTId2Task.Add(task.TaskId, task);
            //                    if (task.Status != DataModel.TaskStatus.Finished)
            //                    {
            //                        if (task.Status != DataModel.TaskStatus.Init)
            //                        {
            //                            if (task.Status == DataModel.TaskStatus.Analysing)
            //                            {
            //                                sb.AppendFormat("{0},", task.TaskId);
            //                                ids.Add((int)task.TaskId);
            //                            }

            //                            task.PictureSource.ImageErrorCount = 0;
            //                            task.PictureSource.RecognizedCount = 0;
            //                            task.PictureSource.NoPlateCount = 0;
            //                            task.PictureSource.NotRecognizedCount = 0;
            //                            UpdateStatus(task, DataModel.TaskStatus.Init);

            //                            m_DAOService.SaveTask(task, entities, false);
            //                        }
            //                        task.StartAnalyseTime = null;
            //                        m_TaskQueue.Enqueue(task);
            //                    }
            //                }
            //            }
            //            if (sb.Length > 1)
            //            {
            //                // 对于之前没有分析完成的任务，都将重新分析
            //                // 清除掉之前的分析结果
            //                // string ids = string.Concat(sb.ToString().Trim(",".ToCharArray()), ")");
            //                m_DAOService.DeleteAnalyseRecords(ids, entities);
            //            }
            //            m_DAOService.CommitChanges(entities);
            //        }
            MyLog4Net.Container.Instance.Log.Debug("[TaskManager_Init] leave using entities ");
            //    }
            //}
        }

        private void InitTaskList(string ip)
        {
                if (m_TaskList == null)
                    m_TaskList = new List<AnalyseTask>();     
            
            DataTable tasktb = DoSql.GetData("select * from irat_historytask");
            foreach (DataRow item in tasktb.Rows)
            {
                object createTime = item["starttime"];
                object  finishedTime = item["endtime"];
                
                int error = Convert.ToInt32(item["errcode"].ToString());
                Encoding ec = Encoding.UTF8;
                if (EncodingType == AppUtil.Common.UrlEncodeUtil.EncodingType.GBK)
                    ec = Encoding.GetEncoding("gbk");
                m_TaskList.Add(new AnalyseTask()
                    {
                        CameraId = "",
                        CreateTime = (createTime == System.DBNull.Value)?new DateTime():(DateTime)createTime,
                        FinishedTime = (finishedTime == System.DBNull.Value) ? new DateTime() : (DateTime)finishedTime,
                        PictureSource = System.Web.HttpUtility.UrlDecode(item["catalogue"].ToString(), ec),
                        ProcessedFileCount = Convert.ToInt32(item["picnum"].ToString()),
                        StartAnalyseTime = (createTime == System.DBNull.Value) ? new DateTime() : (DateTime)createTime,
                        Status = (error > 0 )? DataModel.TaskStatus.AnalysingError: (DataModel.TaskStatus)Convert.ToInt32(item["status"].ToString()),
                        TaskId = item["taskid"].ToString(),
                        TaskName = item["taskname"].ToString(),
                        TaskPriority = Convert.ToInt32(item["rwyxj"].ToString()),
                        TaskType = TaskType.History,
                    });
            }
            //if (System.IO.File.Exists(ip + ".list"))
            //{
            //    string temp = System.IO.File.ReadAllText(ip + ".list", Encoding.UTF8);
            //    m_TaskList = WinFormAppUtil.Common.XMLSerilize.DeserilizeObject<List<AnalyseTask>>(temp);
            //    if (m_TaskList == null)
            //        m_TaskList = new List<AnalyseTask>();
            //    m_TaskList.RemoveAll(item => item.TaskType == TaskType.Realtime);
            //}
            //else
            //{
            //    m_TaskList = new List<AnalyseTask>();
            //}

        }

        public void AddTask(AnalyseTask task,List<PictureItem> pics)
        {
            if (task.TaskType == TaskType.History)
            {
                m_taskService.StartHistoryTask(task.TaskId, new List<string>() { task.PictureSource }, task.TaskPriority, task.TaskName, EncodingType);
            }
            else
            {
                m_IsRealtimeRunning[task.TaskId] = true;
                m_taskService.AddCamera(new List<string>() { task.CameraId });
                new System.Threading.Thread(thSendRealtimeFile).Start(new Tuple<AnalyseTask, List<PictureItem>>(task, pics));
            }

            m_TaskList.Add(task);
        }

        private void thSendRealtimeFile(object obj)
        {
            Tuple<AnalyseTask, List<PictureItem>> taskinfo = obj as Tuple<AnalyseTask, List<PictureItem>>;
            //List<PictureItem> pics = taskinfo.Item2;
            Queue<PictureItem> pics = new Queue<PictureItem>();
            taskinfo.Item2.ForEach(it => pics.Enqueue(it));
            AnalyseTask task = taskinfo.Item1;
            List<SrcService.pic> temppiclist = new List<SrcService.pic>();
            if (!m_RealTaskStatus.ContainsKey(task.TaskId))
                m_RealTaskStatus[task.TaskId] = new TaskProgressStatusInfo() { CommitCount = 0, ErrorCode = 0, ErrorMessage = "", TaskId = task.TaskId, TaskStatus = DataModel.TaskStatus.Init, Progress = 0, };
            uint sendcount = 0;
            int totalcount = pics.Count;
            try
            {
                while(pics.Count > 0)
                {
                    if (!m_Initialized)
                        break;

                    if (!m_IsRealtimeRunning.ContainsKey(task.TaskId) || !m_IsRealtimeRunning[task.TaskId])
                        break;

                    PictureItem item = pics.Dequeue();
                    SrcService.pic p = new SrcService.pic()
                    {
                        cljcqyh = "0",
                        cljcqyw = "0",
                        cljcqyx = "0",
                        cljcqyy = "0",
                        cpwz = "0",
                        rwlx = "1",
                        rwyxj = task.TaskPriority.ToString(),
                        tpbz = Guid.NewGuid().ToString("N"),
                        tpurl = AppUtil.Common.UrlEncodeUtil.UrlPathEncode(item.FullName, EncodingType),
                        tpzpsjc = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        xjbz = task.CameraId,
                        yhsj = "",
                    };
                    temppiclist.Add(p);
                    sendcount++;
                    if (temppiclist.Count >= 10)
                    {
                        try
                        {
                            m_picService.SendPic(temppiclist);
                            temppiclist.Clear();
                        }
                        catch (SDKCallException ex)
                        {
                            temppiclist.ForEach(tempit => pics.Enqueue(new PictureItem() {  FullName = tempit.tpurl,}));

                        }
                        System.Threading.Thread.Sleep(1000);
                    }
                    m_RealTaskStatus[task.TaskId].CommitCount = (uint)totalcount;
                    m_RealTaskStatus[task.TaskId].Progress = (uint)(sendcount * 100 / totalcount);
                    m_RealTaskStatus[task.TaskId].TaskStatus = DataModel.TaskStatus.Analysing;
                }
                if (temppiclist.Count > 0)
                {
                    try
                    {
                        m_picService.SendPic(temppiclist);
                        temppiclist.Clear();
                    }
                    catch (SDKCallException ex)
                    {
                        //temppiclist.ForEach(tempit => pics.Enqueue(new PictureItem() { FullName = tempit.tpurl, }));

                    }
                }
                m_RealTaskStatus[task.TaskId].CommitCount = (uint)totalcount;
                m_RealTaskStatus[task.TaskId].Progress = 100;
                m_RealTaskStatus[task.TaskId].TaskStatus = DataModel.TaskStatus.Finished;

                m_IsRealtimeRunning[task.TaskId] = false;
            }
            catch (SDKCallException ex)
            {
                if (m_RealTaskStatus.ContainsKey(task.TaskId))
                {
                    m_RealTaskStatus[task.TaskId].CommitCount = (uint)totalcount;
                    m_RealTaskStatus[task.TaskId].ErrorMessage = ex.Message;
                    m_RealTaskStatus[task.TaskId].ErrorCode = ex.ErrorCode;
                    m_RealTaskStatus[task.TaskId].TaskStatus = DataModel.TaskStatus.AnalysingError;
                }
                if (m_IsRealtimeRunning.ContainsKey(task.TaskId))
                    m_IsRealtimeRunning[task.TaskId] = false;

            }
        }

        public void DeleteTask(AnalyseTask task)
        {
            if (m_IsRealtimeRunning.ContainsKey(task.TaskId))
                m_IsRealtimeRunning[task.TaskId] = false;
            else
            {
                try
                {
                    m_taskService.StopHistoryTask(task.TaskId);
                }
                catch (SDKCallException ex)
                { 
                }
            }
            m_TaskList.Remove(m_TaskList.Find(item => item.TaskId == task.TaskId));
            //lock (m_SyncObj)
            //{
            //    if (m_DTId2Task.ContainsKey(task.TaskId))
            //    {
            //        m_DTId2Task.Remove(task.TaskId);
            //    }

            //    if (m_DTProcessingTask2Files.ContainsKey(task))
            //    {
            //        m_DTProcessingTask2Files.Remove(task);
            //    }

            //    if (m_ProcessingTasks.Contains(task))
            //    {
            //        m_ProcessingTasks.Remove(task);
            //    }

            //    if (ProcessingTask == task)
            //    {
            //        ProcessingTask = null;
            //    }
            //    if (m_PendingResults != null && m_PendingResults.Item1 == task)
            //    {
            //        m_PendingResults.Item2.Clear();
            //        m_PendingResults = null;
            //    }
            //    if (m_FailedSendItems != null && m_FailedSendItems.Item1.TaskId == task.TaskId)
            //    {
            //        m_FailedSendItems = null;
            //    }

            //    m_DAOService.DeleteTask(task);
            //}
        }

        public TaskProgressStatusInfo QueryTaskSatus(AnalyseTask task)
        {
            TaskService.historytaskstatus stat = new TaskService.historytaskstatus();
            if (task.TaskType == TaskType.History)
            {
                m_taskService.GetHistoryTaskStat(task.TaskId, out stat);
                TaskProgressStatusInfo info = new TaskProgressStatusInfo();
                info.TaskId = task.TaskId;
                switch (stat.status)
                {
                    case "0":
                        info.TaskStatus = DataModel.TaskStatus.AnalysingError;
                        info.ErrorCode = Convert.ToUInt32(stat.errorcode);
                        info.ErrorMessage = stat.errormessage;
                        break;
                    case "1":
                        info.TaskStatus = DataModel.TaskStatus.Init;
                        info.Progress = 0;
                        info.CommitCount = 0;
                        break;
                    case "2":
                        info.TaskStatus = DataModel.TaskStatus.Analysing;
                        info.Progress = Convert.ToUInt32(stat.progress);
                        info.CommitCount = Convert.ToUInt32(stat.loadpicnum);
                        break;
                    case "3":
                        info.TaskStatus = DataModel.TaskStatus.Finished;
                        info.Progress = 100;
                        info.CommitCount = Convert.ToUInt32(stat.loadpicnum);
                        break;
                    default:
                        break;
                }

                return info;
            }
            else
            {
                if (m_RealTaskStatus.ContainsKey(task.TaskId))
                    return m_RealTaskStatus[task.TaskId];
                else
                    return new TaskProgressStatusInfo() { CommitCount = 0, ErrorCode = 0, ErrorMessage = "", TaskId = task.TaskId, Progress = 0, TaskStatus = DataModel.TaskStatus.Init };
            }
            //lock (m_SyncObj)
            //{
            //    if (m_DTId2Task.ContainsKey(task.TaskId))
            //    {
            //        m_DTId2Task.Remove(task.TaskId);
            //    }

            //    if (m_DTProcessingTask2Files.ContainsKey(task))
            //    {
            //        m_DTProcessingTask2Files.Remove(task);
            //    }

            //    if (m_ProcessingTasks.Contains(task))
            //    {
            //        m_ProcessingTasks.Remove(task);
            //    }

            //    if (ProcessingTask == task)
            //    {
            //        ProcessingTask = null;
            //    }
            //    if (m_PendingResults != null && m_PendingResults.Item1 == task)
            //    {
            //        m_PendingResults.Item2.Clear();
            //        m_PendingResults = null;
            //    }
            //    if (m_FailedSendItems != null && m_FailedSendItems.Item1.TaskId == task.TaskId)
            //    {
            //        m_FailedSendItems = null;
            //    }

            //    m_DAOService.DeleteTask(task);
            //}
        }
        private void thDoTaskSearch(object obj)
        {
            SearchService.Parameters searchparam = obj as SearchService.Parameters;
            if (searchparam != null)
            {
                long total=0;
                long curr=0;
                List<AnalyseRecord> ret = new List<AnalyseRecord>();
                string errmsg = "";
                try
                {
                    if (searchparam.AlgorithmFilterType == 99)
                    {
                        uint startindex = 0; uint percount = 100;
                        searchparam.ResultNumRange = new List<uint>() { startindex, percount };
                        var list = m_searchService.Search(searchparam, out total, out curr);
                        //list.ForEach(item => ret.Add(new AnalyseRecord() { Id = item.ObjKey, WatchTime = item.WatchTime, }));

                        foreach (SearchService.ObjDetailInfo dinfo in list)
                        {
                            try
                            {
                                AnalyseRecord newanalyse = CreateAnalyseRecord(dinfo);
                                ret.Add(newanalyse);
                            }
                            catch (Exception ex)
                            { MyLog4Net.Container.Instance.Log.ErrorWithDebugView("CreateAnalyseRecord id=" + dinfo.PicId + "error" + ex); }
                        }
                    }
                }
                catch (SDKCallException ex)
                {
                    errmsg = ex.ToString();
                }
                m_lastCommitSearchTotalCount = (int)total;
                if (TaskSearchFinished != null)
                {
                    TaskSearchFinished(ret, total,errmsg);
                }
            }               
            m_isrunsearch = false;
        }

        private void thDoSwitchSearch(object obj)
        {
            SearchService.Parameters searchparam = obj as SearchService.Parameters;
            if (searchparam != null)
            {
                long total=0;
                long curr=0;
                List<AnalyseRecord> ret = new List<AnalyseRecord>();
                string errmsg = "";
                try
                {
                    if (searchparam.AlgorithmFilterType == 99)
                    {
                        var list = m_searchService.Search(searchparam, out total, out curr);
                        //    list.ForEach(item => ret.Add(new AnalyseRecord() { Id = item.ObjKey, WatchTime = item.WatchTime, }));

                        foreach (SearchService.ObjDetailInfo dinfo in list)
                        {
                            try
                            {
                                AnalyseRecord newanalyse = CreateAnalyseRecord(dinfo);
                                ret.Add(newanalyse);
                            }
                            catch (Exception ex)
                            { MyLog4Net.Container.Instance.Log.ErrorWithDebugView("CreateAnalyseRecord id=" + dinfo.PicId + "error" + ex); }
                        }
                    }
                }
                catch (SDKCallException ex)
                {
                    errmsg = ex.ToString();
                }

                if (TaskSwitchFinished != null)
                {
                    TaskSwitchFinished(ret, total,errmsg);
                }
            }               
            m_isrunsearch = false;
        }


        private void thDoTaskCompareSearch(object obj)
        {
            MyLog4Net.Container.Instance.Log.DebugWithDebugView("thDoTaskCompareSearch start Search");

            SearchService.Parameters searchparam = obj as SearchService.Parameters;
            if (searchparam != null)
            {
                long total = 0;
                List<AnalyseRecord> ret = new List<AnalyseRecord>();
                string errmsg = "";
                try
                {
                    var list = m_searchService.CompareSearch(searchparam, out total);


                    foreach (SearchService.ObjDetailInfo dinfo in list)
                    {
                        try
                        {
                            AnalyseRecord newanalyse = CreateAnalyseRecord(dinfo);
                            ret.Add(newanalyse);
                        }
                        catch (Exception ex)
                        { MyLog4Net.Container.Instance.Log.ErrorWithDebugView("CreateAnalyseRecord id="+dinfo.PicId+"error"+ex); }
                    }
                }
                catch (SDKCallException ex)
                {
                    errmsg = ex.ToString();
                }

                if (TaskCompareSearchFinished != null)
                {
                    TaskCompareSearchFinished(ret, total, errmsg);
                }
            }
            m_isrunsearch = false;
            MyLog4Net.Container.Instance.Log.DebugWithDebugView("thDoTaskCompareSearch end Search");

        }

        private AnalyseRecord CreateAnalyseRecord(SearchService.ObjDetailInfo dinfo)
        {
            VehiclePropertyInfo driverPhoneCalling = Constant.PropertyInfo_UNKNOWN;
            VehicleBrandInfo parentBrandInfo = new VehicleBrandInfo() { ID = -1, Name = "未知" };
            VehicleBrandInfo brandInfo = new VehicleBrandInfo() { ID = -1, Name = "未知" };
            VehiclePropertyInfo driverSunlightShield = Constant.PropertyInfo_UNKNOWN;
            VehiclePropertyInfo driverWearingSafeBelt = Constant.PropertyInfo_UNKNOWN;
            VehiclePropertyInfo vehicleType = Constant.PropertyInfo_UNKNOWN;
            VehiclePropertyInfo detailVehicleType = Constant.PropertyInfo_UNKNOWN;
            VehiclePropertyInfo coDriverSunlightShield = Constant.PropertyInfo_UNKNOWN;
            VehiclePropertyInfo coDriverWearingSafeBelt = Constant.PropertyInfo_UNKNOWN;
            VehiclePropertyInfo plateColor = Constant.PropertyInfo_UNKNOWN;
            VehiclePropertyInfo plateType = Constant.PropertyInfo_UNKNOWN;
            VehiclePropertyInfo vehicleColor = Constant.PropertyInfo_UNKNOWN;
            VehiclePropertyInfo consoleIsSomething = Constant.PropertyInfo_UNKNOWN;
            VehiclePropertyInfo isPendant = Constant.PropertyInfo_UNKNOWN;
            VehiclePropertyInfo vehicleDirection = Constant.PropertyInfo_UNKNOWN;

            DateTime wt = new DateTime();
            Rectangle drect = new Rectangle();
            Rectangle codrect = new Rectangle();
            Rectangle prect = new Rectangle();
            Rectangle vrect = new Rectangle();

            List<VehicleAnnualInspectionLabel>  ailabel = new List<VehicleAnnualInspectionLabel>();
            try
            {
                 driverPhoneCalling = Constant.PropertyInfo_PhoneCalling.Find(it => it.ID == Convert.ToInt32(dinfo.DriverIsPhoneing));
                 if (driverPhoneCalling == null) driverPhoneCalling = Constant.PropertyInfo_UNKNOWN;
                 
                parentBrandInfo = Constant.GetVehicleBrand(Convert.ToInt32(dinfo.CarLabelNo));
                if (parentBrandInfo.ID == 1000)//特殊处理，当夫品牌为1000时表示为两轮车，解决与1000子品牌冲突问题
                    parentBrandInfo = new VehicleBrandInfo() { ID = 0, Name = "" };
                if (parentBrandInfo == null) parentBrandInfo = new VehicleBrandInfo() { ID = -1, Name = "未知" };
                 brandInfo = Constant.GetVehicleBrand(Convert.ToInt32(dinfo.CarLabelDetailNo));
                 if (brandInfo == null) brandInfo = new VehicleBrandInfo() { ID = -1, Name = "未知" };
                 driverSunlightShield = Constant.PropertyInfo_SunlightShielding.Find(it => it.ID == Convert.ToInt32(dinfo.DriverIsSunVisor));
                 if (driverSunlightShield == null) driverSunlightShield = Constant.PropertyInfo_UNKNOWN;
                 driverWearingSafeBelt = Constant.PropertyInfo_SafeBeltWear.Find(it => it.ID == Convert.ToInt32(dinfo.DriverIsSafebelt));
                 if (driverWearingSafeBelt == null) driverWearingSafeBelt = Constant.PropertyInfo_UNKNOWN;
                 vehicleType = Constant.PropertyInfo_VehicleType.Find(it => it.ID == Convert.ToInt32(dinfo.CarTypeNo));
                 if (vehicleType == null) vehicleType = Constant.PropertyInfo_UNKNOWN;
                 detailVehicleType = Constant.GetVehicleDetailTypeInfo(Convert.ToInt32(dinfo.CarTypeDetailNo));
                 if (detailVehicleType == null) detailVehicleType = Constant.PropertyInfo_UNKNOWN;
                 coDriverSunlightShield = Constant.PropertyInfo_SunlightShielding.Find(it => it.ID == Convert.ToInt32(dinfo.PassengerIsSunVisor));
                 if (coDriverSunlightShield == null) coDriverSunlightShield = Constant.PropertyInfo_UNKNOWN;
                 coDriverWearingSafeBelt = Constant.PropertyInfo_SafeBeltWear.Find(it => it.ID == Convert.ToInt32(dinfo.PassengerIsSafebelt));
                 if (coDriverWearingSafeBelt == null) coDriverWearingSafeBelt = Constant.PropertyInfo_UNKNOWN;
                 plateColor = Constant.PropertyInfo_PlateColor.Find(it => it.ID == Convert.ToInt32(dinfo.PlateColorNo));
                 if (plateColor == null) plateColor = Constant.PropertyInfo_UNKNOWN;
                 plateType = Constant.PropertyInfo_PlateType.Find(it => it.ID == Convert.ToInt32(dinfo.PlateNumRow));
                 if (plateType == null) plateType = Constant.PropertyInfo_UNKNOWN;
                 vehicleColor = Constant.PropertyInfo_VehicleColor.Find(it => it.ID == Convert.ToInt32(dinfo.CarColorNo));
                 if (vehicleColor == null) vehicleColor = Constant.PropertyInfo_UNKNOWN;
                 consoleIsSomething = Constant.PropertyInfo_SunlightShielding.Find(it => it.ID == Convert.ToInt32(dinfo.ConsoleIsSomething));
                 if (consoleIsSomething == null) consoleIsSomething = Constant.PropertyInfo_UNKNOWN;
                 isPendant = Constant.PropertyInfo_SunlightShielding.Find(it => it.ID == Convert.ToInt32(dinfo.IsPendant));
                 if (isPendant == null) isPendant = Constant.PropertyInfo_UNKNOWN;
                 vehicleDirection = Constant.PropertyInfo_VehicleDirection.Find(it => it.ID == Convert.ToInt32(dinfo.VehicleDirection));
                 if (vehicleDirection == null) vehicleDirection = Constant.PropertyInfo_UNKNOWN;

                 wt = DateTime.ParseExact(dinfo.WatchTime, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                drect = new Rectangle(Convert.ToInt32(dinfo.DriverRectX), Convert.ToInt32(dinfo.DriverRectY), Convert.ToInt32(dinfo.DriverRectWidth), Convert.ToInt32(dinfo.DriverRectHeight));
                codrect = new Rectangle(Convert.ToInt32(dinfo.PassengerRectX), Convert.ToInt32(dinfo.PassengerRectY), Convert.ToInt32(dinfo.PassengerRectWidth), Convert.ToInt32(dinfo.PassengerRectHeight));
                prect = new Rectangle(Convert.ToInt32(dinfo.PlateRectX), Convert.ToInt32(dinfo.PlateRectY), Convert.ToInt32(dinfo.PlateRectWidth), Convert.ToInt32(dinfo.PlateRectHeight));
                vrect = new Rectangle(Convert.ToInt32(dinfo.VehicleRectX), Convert.ToInt32(dinfo.VehicleRectY), Convert.ToInt32(dinfo.VehicleRectWidth), Convert.ToInt32(dinfo.VehicleRectHeight));

                dinfo.AILabelList.ForEach(it => ailabel.Add(new VehicleAnnualInspectionLabel() { AILabelCof = (int)Convert.ToSingle(it.AILabelCof), AILabelRect = new Rectangle(Convert.ToInt32(it.AILabelRectX), Convert.ToInt32(it.AILabelRectY), Convert.ToInt32(it.AILabelRectW), Convert.ToInt32(it.AILabelRectH)) }));

            }
            catch (Exception ex)
            {
                MyLog4Net.Container.Instance.Log.ErrorWithDebugView("CreateAnalyseRecord id=" + dinfo.PicId + "error" + ex);
            }
            AnalyseRecord newanalyse = new AnalyseRecord()
            {
                PlateImg = null,
                ThumbImg = null,

                Id = dinfo.ObjKey,
                //不在此处做 System.Web.HttpUtility.UrlDecode(dinfo.ImageUrl)，到实际请求图片的地方转
                PicPath = dinfo.ImageUrl,
                WatchTime = wt,
                DeviceId = dinfo.CameraCode,
                DriverPhoneCalling = driverPhoneCalling,
                BrandInfo = brandInfo,
                DriverRegion = drect,
                DriverSunlightShield = driverSunlightShield,
                DriverWearingSafeBelt = driverWearingSafeBelt,
                CompareSimilarity = (int)(Convert.ToSingle(dinfo.Similar) * 100),
                DetailVehicleTypeInfo = detailVehicleType,

                DetailVehicleType = detailVehicleType.Name,
                //CoDriverPhoneCalling = Constant.PropertyInfo_UNKNOWN,
                CoDriverRegion = codrect,
                CoDriverSunlightShield = coDriverSunlightShield,
                CoDriverWearingSafeBelt = coDriverWearingSafeBelt,
                ErrorCode = 0,
                Image = null,
                //Manufacturer = parentBrandInfo.Name,
                ManufacturerReliability = (int)Convert.ToSingle(dinfo.CarLabeConf),
                ParentBrandInfo = parentBrandInfo,
                PicId = dinfo.PicId,
                PlateColor = plateColor.Name,//多个颜色值
                PlateColorInfo = plateColor,
                PlateNumber = dinfo.PlateNo,
                PlateNumberReliability = (int)Convert.ToSingle(dinfo.PlateNoConf),
                PlateRegion = prect,
                PlateType = plateType.Name,
                PlateTypeInfo = plateType,
                PlatformId = 0,
                Type = 0,
                VehicleColor = vehicleColor.Name,//多个颜色值
                VehicleColorInfo = vehicleColor,
                VehicleRegion = vrect,
                VehicleType = vehicleType.Name,
                VehicleTypeInfo = vehicleType,
                CarColorConf = (int)Convert.ToSingle(dinfo.CarColorConf),
                CarLabeDetailConf = (int)Convert.ToSingle(dinfo.CarLabeDetailConf),
                CarTypeConf = (int)Convert.ToSingle(dinfo.CarTypeConf),
                CarTypeDetailConf = (int)Convert.ToSingle(dinfo.CarTypeDetailConf),
                ConsoleIsSomething = consoleIsSomething,
                ConsoleIsSomethingCof = (int)Convert.ToSingle(dinfo.ConsoleIsSomethingConf),
                DriverIsPhoneingConf = (int)Convert.ToSingle(dinfo.DriverIsPhoneingConf),
                DriverIsSafebeltConf = (int)Convert.ToSingle(dinfo.DriverIsSafebeltConf),
                DriverIsSunVisorConf = (int)Convert.ToSingle(dinfo.DriverIsSunVisorConf),
                IsPendant = isPendant,
                IsPendantCof = (int)Convert.ToSingle(dinfo.IsPendantConf),
                PassengerIsSafebeltCof = (int)Convert.ToSingle(dinfo.PassengerIsSafebeltConf),
                PassengerIsSunVisorConf = (int)Convert.ToSingle(dinfo.PassengerIsSunVisorConf),
                VehicleDirection = vehicleDirection,
                AILabel = ailabel,
                Score = (int)Convert.ToSingle(dinfo.Score),
            };
            return newanalyse;

        }


       
        //public void TaskCompareSearch(SearchPara param)
        //{
        //    //lock (m_SyncObj)
        //    //{
        //    //    if (m_DTId2Task.ContainsKey(task.TaskId))
        //    //    {
        //    //        m_DTId2Task.Remove(task.TaskId);
        //    //    }

        //    //    if (m_DTProcessingTask2Files.ContainsKey(task))
        //    //    {
        //    //        m_DTProcessingTask2Files.Remove(task);
        //    //    }

        //    //    if (m_ProcessingTasks.Contains(task))
        //    //    {
        //    //        m_ProcessingTasks.Remove(task);
        //    //    }

        //    //    if (ProcessingTask == task)
        //    //    {
        //    //        ProcessingTask = null;
        //    //    }
        //    //    if (m_PendingResults != null && m_PendingResults.Item1 == task)
        //    //    {
        //    //        m_PendingResults.Item2.Clear();
        //    //        m_PendingResults = null;
        //    //    }
        //    //    if (m_FailedSendItems != null && m_FailedSendItems.Item1.TaskId == task.TaskId)
        //    //    {
        //    //        m_FailedSendItems = null;
        //    //    }

        //    //    m_DAOService.DeleteTask(task);
        //    //}
        //}
        public void TaskCompareSearch(SearchPara param, Image img = null)
        {
            if (m_isrunsearch)
                return;

            string PictureData = "";
            uint AlgorithmFilterType = 99;
            Rectangle GlobRect = new Rectangle();
            Rectangle PartRect = new Rectangle();
            if(img!=null)
            {
                PictureData = Convert.ToBase64String(DataModel.Constant.ImageToJpegBytes(img));
                AlgorithmFilterType = 0;
                GlobRect = param.GlobRect;
                PartRect = param.PartRect;
                
            }
            string deviceid = "";
            if (param.TaskID.Count > 0)
            {
                foreach (string item in param.TaskID)
                {
                    deviceid += item + ",";
                }
                deviceid = deviceid.TrimEnd(',');
            }
            else
            { 
                foreach (string item in param.CameraID)
                {
                    deviceid += item + ",";
                }
                deviceid = deviceid.TrimEnd(',');
            }
            com.VehicleAnalyse.SearchService.Parameters searchparam = new SearchService.Parameters()
            {
                PictureData = PictureData,
                PlateNo = param.PlateNumber,
                ObjType = 1,
                AlgorithmFilterType = AlgorithmFilterType,
                Devicetype = (uint)((param.TaskID.Count > 0) ? 1 : 0),
                Similar = param.Similar,
                ResultNumRange = new List<uint>() { 0, (uint)param.ResultCount },
                StartTime = param.StartTime,
                EndTime = param.EndTime,
                DeviceID = deviceid,
                CarColorNos = new List<int>() { param.VehicleColor.ID },
                CarLabelDetailNos = param.SelectAllVehicleModels?new List<int>():param.CheckedVehicleModels.ToList().ConvertAll<int>(it => it.ID).ToList(),
                CarLabelNos = (param.VehicleBrand!=null)?new List<int>() { param.VehicleBrand.ID }:new List<int>(),
                CarTypeDetailNos = new List<int>() { param.VehicleDetailType.ID },
                CarTypeNos = new List<int>() { param.VehicleType.ID },
                DownBodyColor = new List<int>(),
                GlobRect = GlobRect,
                PartRect = PartRect,
                PlateColorNos = new List<int>() { param.PlateColor.ID },
                PlateNumRows = new List<int>() { param.PlateNumRows.ID },
                ResultFileds = new List<string>(),
                UpBodyColor = new List<int>(),
                Version = "1.0.0.1",
                DriverIsPhoneing = param.DriverPhoneCall.ID,
                DriverIsSafebelt = param.DriverBelt.ID,
                DriverIsSunVisor = param.DriverShielding.ID,
                PassengerIsSafebelt = param.CoDriverBelt.ID,
                PassengerIsSunVisor = param.CoDriverShielding.ID,
                 CarColorWeight = 0,
                  CarLabelWeight = 0,
                   CarTypeWeight = 0,
                    PlateNoWeight = (uint)param.Weight,
                     SimilarWeight = 0,
            };

            m_isrunsearch = true;
            if (img != null)
                new Thread(thDoTaskCompareSearch).Start(searchparam);
            else
            {

                new Thread(thDoTaskSearch).Start(searchparam);
                m_lastCommitSearchParam = searchparam;
            }

            //lock (m_SyncObj)
            //{
            //    if (m_DTId2Task.ContainsKey(task.TaskId))
            //    {
            //        m_DTId2Task.Remove(task.TaskId);
            //    }

            //    if (m_DTProcessingTask2Files.ContainsKey(task))
            //    {
            //        m_DTProcessingTask2Files.Remove(task);
            //    }

            //    if (m_ProcessingTasks.Contains(task))
            //    {
            //        m_ProcessingTasks.Remove(task);
            //    }

            //    if (ProcessingTask == task)
            //    {
            //        ProcessingTask = null;
            //    }
            //    if (m_PendingResults != null && m_PendingResults.Item1 == task)
            //    {
            //        m_PendingResults.Item2.Clear();
            //        m_PendingResults = null;
            //    }
            //    if (m_FailedSendItems != null && m_FailedSendItems.Item1.TaskId == task.TaskId)
            //    {
            //        m_FailedSendItems = null;
            //    }

            //    m_DAOService.DeleteTask(task);
            //}
        }

        public void TaskSwitchSearch(PageInfo page)
        {
            if (m_isrunsearch)
                return;
            int startindex = Math.Min(m_lastCommitSearchTotalCount, page.PageIndex * 100);
            int count = Math.Min(100, m_lastCommitSearchTotalCount - startindex);

            m_lastCommitSearchParam.ResultNumRange = new List<uint>(){(uint)startindex, (uint)count};
            m_isrunsearch = true;

            new Thread(thDoSwitchSearch).Start(m_lastCommitSearchParam);

        }

        public List<AnalyseTask> GetAllTasks()
        {
            return m_TaskList;
        }

        public List<AnalyseRecord> GetDetailResults(List<AnalyseRecord> ids)
        {
            Trace.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss,fff") + " GetDetailResults 1");


            return ids;
            //List<AnalyseRecord> ret = new List<AnalyseRecord>();
            
            //var list =  m_searchService.GetDetailResults(ids.ConvertAll<string>(item=>item.Id));
            //Trace.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss,fff") + " GetDetailResults 2");
            //foreach (SearchService.ObjDetailInfo dinfo in list)
            //{
            //    var find = ids.Find(it=>it.Id == dinfo.ObjKey);
            //    if(find !=null && find.Id!="")
            //    {
            //        try
            //        {
            //            AnalyseRecord newanalyse = CreateAnalyseRecord(dinfo);
            //            newanalyse.CompareSimilarity = find.CompareSimilarity;
            //            ret.Add(newanalyse);


            //        }
            //        catch(Exception ex)
            //        {
            //            MyLog4Net.Container.Instance.Log.DebugWithDebugView("CreateAnalyseRecord id=" + dinfo .PicId+ " error " + ex);
            //        }



            //    }
            //}
            //Trace.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss,fff") + " GetDetailResults 3");

            //return ret;
        }


        public void Close()
        {
            //Running = false;
            m_Initialized = false;
            //Trace.WriteLine("m_Initialized Close:" + m_Initialized);

            //m_Closed = true;
            //if (m_TokenSource != null)
            //{
            //    m_TokenSource.Cancel();
            //}
            //m_taskRunnerSendPics.StopAndClear();
            //m_taskRunnerProcessResult.StopAndClear();
        }

        /*
        public List<AnalyseRecord> SearchAnalyseResults(AnalyseTask task, string plateNumber, string vehicleDetailType, VehicleBrandInfo brand, 
            int resultType, string vehicleColor, string plateColor)
        {
            return m_DAOService.SearchAnalyseResults(task, plateNumber, vehicleDetailType, brand, resultType, vehicleColor, plateColor);
        }
        */


        public List<AnalyseRecord> GetImageFeature(Image img)
        {
            //AnalyseRecord r = new AnalyseRecord()
            //{
            //    PlateNumber = "沪A11111",
            //    Manufacturer = "大众",
            //    VehicleRegion = new Rectangle(300, 300, 500, 600),
            //};
            //return new List<AnalyseRecord>() { r };


            List<com.VehicleAnalyse.SearchService.Vehicle> list = m_searchService.GetImgFeature(Convert.ToBase64String(DataModel.Constant.ImageToJpegBytes(img)));

            var ret =  list.ConvertAll<AnalyseRecord>(dinfo =>
                {
                    VehicleBrandInfo parentBrandInfo = new VehicleBrandInfo() { ID = -1, Name = "未知" };
                    VehicleBrandInfo brandInfo = new VehicleBrandInfo() { ID = -1, Name = "未知" };
                    VehiclePropertyInfo vehicleType = Constant.PropertyInfo_UNKNOWN;
                    VehiclePropertyInfo detailVehicleType =  Constant.PropertyInfo_UNKNOWN;
                    VehiclePropertyInfo plateColor =  Constant.PropertyInfo_UNKNOWN;
                    VehiclePropertyInfo plateType =  Constant.PropertyInfo_UNKNOWN;
                    VehiclePropertyInfo vehicleColor =  Constant.PropertyInfo_UNKNOWN;

                    Rectangle rect =  new Rectangle(0, 0, img.Width, img.Height);
                        
                    float Reliability = 100;

                    try
                    {
                    parentBrandInfo = Constant.GetVehicleBrand(Convert.ToInt32(dinfo.CarLabel));
                    if (parentBrandInfo == null) parentBrandInfo = new VehicleBrandInfo() { ID = -1, Name = "未知" };
                    brandInfo = Constant.GetVehicleBrand(Convert.ToInt32(dinfo.CarLabelDetail));
                    if (brandInfo == null) brandInfo = new VehicleBrandInfo() { ID = -1, Name = "未知" };
                    vehicleType = Constant.PropertyInfo_VehicleType.Find(it => it.ID == Convert.ToInt32(dinfo.CarType));
                    if (vehicleType == null) vehicleType = Constant.PropertyInfo_UNKNOWN;
                    detailVehicleType = Constant.GetVehicleDetailTypeInfo(Convert.ToInt32(dinfo.CarTypeDetail));
                    if (detailVehicleType == null) detailVehicleType = Constant.PropertyInfo_UNKNOWN;
                    plateColor = Constant.PropertyInfo_PlateColor.Find(it => it.ID == Convert.ToInt32(dinfo.PlateColor));
                    if (plateColor == null) plateColor = Constant.PropertyInfo_UNKNOWN;
                    plateType = Constant.PropertyInfo_PlateType.Find(it => it.ID == Convert.ToInt32(dinfo.PlateNumRows));
                    if (plateType == null) plateType = Constant.PropertyInfo_UNKNOWN;
                    vehicleColor = Constant.PropertyInfo_VehicleColor.Find(it => it.ID == Convert.ToInt32(dinfo.CarColor));
                    if (vehicleColor == null) vehicleColor = Constant.PropertyInfo_UNKNOWN;

                    rect =  new Rectangle(Convert.ToInt32(dinfo.VehicleRectX), Convert.ToInt32(dinfo.VehicleRectY), Convert.ToInt32(dinfo.VehicleRectWidth), Convert.ToInt32(dinfo.VehicleRectHeight));
                    if(!new Rectangle(0,0,img.Width,img.Height).Contains(rect))
                        rect = new Rectangle(0,0,img.Width,img.Height);

                    Reliability = Convert.ToSingle(dinfo.PlateConf) * 100;
                    if (Reliability > int.MaxValue)
                        Reliability = 100;

                    }
                    catch (Exception ex)
                    {
                        MyLog4Net.Container.Instance.Log.DebugWithDebugView("m_searchService.GetImgFeature error =" + ex);

                    }

                    
                    return  new AnalyseRecord()
                    {
                        BrandInfo = brandInfo,
                        DetailVehicleTypeInfo = detailVehicleType,

                        DetailVehicleType = detailVehicleType.Name,
                        //Manufacturer = parentBrandInfo.Name,
                        //ManufacturerReliability = 100,
                        ParentBrandInfo = parentBrandInfo,
                        PlateColor = plateColor.Name,//多个颜色值
                        PlateColorInfo = plateColor,
                        PlateNumber = dinfo.PlateNo,
                        PlateNumberReliability = Convert.ToInt32( Reliability),
                        PlateType = plateType.Name,
                        PlateTypeInfo = plateType,
                        VehicleColor = vehicleColor.Name,//多个颜色值
                        VehicleColorInfo = vehicleColor,
                        VehicleRegion =rect,
                        VehicleType = vehicleType.Name,
                        VehicleTypeInfo = vehicleType,

                    };

                });

            ret.RemoveAll(it => it.PlateNumber == "22222222");
            return ret;
        }

        public Image GetThumbImg(AnalyseRecord record)
        {
            return m_searchService.GetThumbImg(record.Id);
        }

        #endregion


        //private Image GetImage(byte[] bytes)
        //{
        //    Image img = null;
        //    System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
        //    try
        //    {
        //        img = System.Drawing.Image.FromStream(ms);
        //        ms.Dispose();
        //    }
        //    catch (ArgumentException aex)
        //    {
        //        img = null;
        //    }
        //    return img;
        //}

        //public Image GetVehicleImage(VehicleBrand model, bool isFront = true)
        //{
        //    Image image = null;
        //    if (model == null)
        //    {
        //        return image;
        //    }

        //    if (isFront && model.Front != null)
        //    {
        //        image = GetImage(model.Front);
        //    }
        //    else if (!isFront && model.Back != null)
        //    {
        //        image = GetImage(model.Back);
        //    }

        //    if (image == null)
        //    {
        //        // 取车标图
        //        if (model.Logo != null)
        //        {
        //            image = GetImage(model.Logo);
        //        }
        //        // 如果没有车标图，取父品牌车标图
        //        else
        //        {
        //            //VehicleBrand brand;
        //            //if (model.ParentId.HasValue &&
        //            //    (brand = GetBrand((int)model.ParentId.Value)) != null && brand.Logo != null)
        //            //{
        //            //    image = GetImage(brand.Logo);
        //            //}
        //        }
        //    }
        //    return image;
        //}


        #region Private helper functions


        //private void RetrievingFiles(AnalyseTask task)
        //{
        //    UpdateStatus(task, DataModel.TaskStatus.RetrievingFiles);

        //    FileAccessBase fileAccessor = FileAccessFactory.GetFileAccess(task.PictureSource);
        //    if (task.PictureSource.Path.EndsWith(".txt"))
        //    {
        //        fileAccessor.URLsinTxtFile = true;
        //    }

        //    try
        //    {
        //        task.PictureSource.ProcessedIndex = 0;
        //        task.PictureSource.PictureItems = fileAccessor.GetFiles();
        //        task.PictureSource.Count = task.PictureSource.PictureItems.Count;
        //        task.PictureSource.ImageErrorCount = 0;
        //        task.PictureSource.RecognizedCount = 0;
        //        UpdateStatus(task, DataModel.TaskStatus.WaitforAnalyse);
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.Assert(false, ex.Message);
        //        MyLog4Net.Container.Instance.Log.Error("获取文件列表出错", ex);
        //        UpdateStatus(task, DataModel.TaskStatus.RetrievingFileError);
        //    }
            
        //}

        private void UpdateStatus(AnalyseTask task, DataModel.TaskStatus status)
        {
            task.Status = status;
            if (StatusChanged != null)
            {
                StatusChanged(task, EventArgs.Empty);
            }
        }


        private bool GetResendPicItems(int count, bool hasNewTask, out AnalyseTask task, out PictureItem[] items)
        {
            task = null; items = null;
            return false;
            //task = null;
            //items = null;

            //if(m_LatestTimeReceivedResult == DateTime.MinValue)
            //{
            //    return false;
            //}

            //if (DateTime.Now.Subtract(LatestTimeReceivedResult) < MAXSPAN_NORESULT_RESEND)
            //{
            //    return false;
            //}

            //// 都发送完了， 重发没有收齐结果的任务图片
            //// 没全部发送完， 但没有收齐结果的任务队列超过一定数量
            //if ((!hasNewTask && m_ProcessingTasks.Count > 0)|| m_DTProcessingTask2Files.Count >= MAXCOUNT_PENDINGRECEIVERESULTTASK)
            //{
            //    if (!string.IsNullOrEmpty(m_ResendPicId))
            //    {
            //        if (m_WaitResendResult <= 10)
            //        {
            //            task = null;
            //            items = null;
            //            m_WaitResendResult++;
            //            MyLog4Net.Container.Instance.Log.WarnFormat("等待'{0}' 分析结果", m_ResendPicId);
            //            return true;
            //        }
            //        else
            //        {
            //            m_WaitResendResult = 0;
            //            m_ResendPicId = null;
            //            MyLog4Net.Container.Instance.Log.WarnFormat("等待'{0}' 分析结果超时，重发", m_ResendPicId);
            //        }
            //    }

            //    MyLog4Net.Container.Instance.Log.WarnFormat("等待分析结果任务队列已经有 '{0}' 个任务, 将重新发送这些任务中的图片",
            //        m_DTProcessingTask2Files.Count);
            //    AnalyseTask taskTmp = m_ProcessingTasks[0];
            //    List<string> files = m_DTProcessingTask2Files[taskTmp].ToList();

            //    if (files != null && files.Count > 0)
            //    {
            //        int countFile = Math.Min(files.Count, MAXPICCOUNT_ONCE);
            //        items = new PictureItem[countFile];
            //        int i = 0;
            //        foreach (string file in files)
            //        {
            //            items[i++] = new PictureItem() { FullName = file };
            //            if (i >= countFile)
            //            {
            //                break;
            //            }
            //        }
            //        task = taskTmp;
            //        m_ResendPicId = string.Format("{0}##{1}", items[0].FullName, task.TaskId);
            //        MyLog4Net.Container.Instance.Log.WarnFormat("重新分析任务 '{0}' 未收到结果的 {1}/{2} 图片, Pic file name: {3}", 
            //            task.Name, countFile, files.Count, m_ResendPicId);
            //        return true;
            //    }
            //    return false;
            //}
            //return false;
        }

        private bool GetPictureItems(int count, out AnalyseTask task, out PictureItem[] items)
        {
            task = null; items = null;
            return false ;
            //bool bRet = false;

            //lock (m_SyncObj)
            //{
            //    items = null;
            //    task = null;

            //    if (m_FailedSendItems != null)
            //    {
            //        task = m_FailedSendItems.Item1;
            //        items = m_FailedSendItems.Item2;
            //        count = m_FailedSendItems.Item2.Length;
            //        m_FailedSendItems = null;
            //        return true;
            //    }

            //    if (ProcessingTask != null)
            //    {
            //        task = ProcessingTask;
            //    }
            //    else
            //    {
            //        task = GetNextTaskFromQueue();
            //        AnalyseTask tmpTask;
            //        bool hasNewTask = (task != null);
            //        if (GetResendPicItems(count, hasNewTask, out tmpTask, out items))
            //        {
            //            task =  tmpTask;
            //            return items != null && items.Length > 0;
            //        }
                                        
            //        if (hasNewTask)
            //        {
            //            Debug.Assert(task.PictureSource != null && task.PictureSource.PictureItems != null
            //            && task.PictureSource.PictureItems.Count > 0);
            //            if (task.PictureSource.PictureItems == null || task.PictureSource.PictureItems.Count == 0)
            //            {
            //                MyLog4Net.Container.Instance.Log.Warn("重新获取文件列表");
            //                RetrievingFiles(task);
            //            }

            //            ProcessingTask = task;
            //        }
            //        else
            //        {

            //        }
            //    }

            //    if (task != null)
            //    {
            //        int realCount = task.PictureSource.Count - task.PictureSource.ProcessedIndex;
            //        realCount = Math.Min(count, realCount); // realCount > count ? count : realCount;
            //        realCount = Math.Min(realCount, MAXPICCOUNT_ONCE);
            //        items = new PictureItem[realCount];
            //        task.PictureSource.PictureItems.CopyTo(task.PictureSource.ProcessedIndex, items, 0, realCount);
            //        task.PictureSource.ProcessedIndex += realCount;

            //        if (task.PictureSource.ProcessedIndex >= task.PictureSource.Count)
            //        {
            //            m_TaskQueue.Dequeue();
            //            ProcessingTask = null;
            //        }
            //        else
            //        {
            //            ProcessingTask = task;
            //        }

            //        List<string> files = null;
            //        if (m_DTProcessingTask2Files.ContainsKey(task))
            //        {
            //            files = m_DTProcessingTask2Files[task];
            //            foreach (PictureItem item in items)
            //            {
            //                files.Add(item.FullName);
            //            }
            //        }
            //        else
            //        {
            //            files = new List<string>();
            //            foreach (PictureItem item in items)
            //            {
            //                files.Add(item.FullName);
            //            }
            //            m_ProcessingTasks.Add(task);
            //            m_DTProcessingTask2Files.Add(task, files);
            //        }

            //        bRet = true;
            //    }
            //}

            //// ProcessingTask = task;

            //return bRet;
        }

        private AnalyseTask GetTask(int taskId, string fileName)
        {
            return null;
            //AnalyseTask task = null;

            //lock (m_SyncObj)
            //{
            //    // AnalyseTask taskTmp = null;

            //    if (m_DTProcessingTask2Files.Count > 0)
            //    {
            //        foreach (KeyValuePair<AnalyseTask, List<string>> kv in m_DTProcessingTask2Files)
            //        {
            //            if (kv.Key.TaskId == taskId)
            //            {
            //                if (kv.Value.Contains(fileName))
            //                {
            //                    task = kv.Key;
            //                }
            //                else
            //                {
            //                    // Debug.Assert(false);
            //                    MyLog4Net.Container.Instance.Log.WarnFormat("GetTask: Task with Id '{0}', filename '{1}' not found !", taskId, fileName);
            //                }
            //                break;
            //            }
            //        }
            //    }
            //}

            //return task;
        }

        private void RaiseMessageEvent(string msg)
        {
            if (Message != null)
            {
                Message(msg);
            }
        }

        private int SendPics(int count)
        {
            return 0;
            //if (!m_Running || !m_Connected)
            //{
            //    return 0;
            //}

            //AnalyseTask task;
            //PictureItem[] items;

            //RaiseMessageEvent("收到分析服务器图片请求 ...");
            //string msg;
            //bool result;
            //try
            //{
            //    if (GetPictureItems(count, out task, out items))
            //    {
            //        msg = string.Format("发送任务 '{0}' {1} 张图片 ...", task.Name, items.Length);
            //        RaiseMessageEvent(msg);
            //        MyLog4Net.Container.Instance.Log.Info(msg);
            //        // m_CurrentTask = task;
            //        result = m_ImageAnalysisService.SendPictureItems(task, items);
            //        if (!result)
            //        {
            //            Connected = false;
            //            m_FailedSendItems = new Tuple<AnalyseTask,PictureItem[]>(task, items);
            //            msg = string.Format("发送任务 '{0}' {1} 张图片失败", task.Name, items.Length);
            //            RaiseMessageEvent(msg);
            //            MyLog4Net.Container.Instance.Log.Info(msg);
            //            return 0;
            //        }

            //        msg = string.Format("发送任务 '{0}' {1} 张图片完成", task.Name, items.Length);
            //        if(items.Length < Math.Min(count, MAXPICCOUNT_ONCE))
            //        {
            //            msg = string.Format("{0}, 本任务图片发送完成", msg);
            //        }
            //        items = null;
            //        RaiseMessageEvent(msg);
            //        MyLog4Net.Container.Instance.Log.Info(msg);
            //    }
            //    else
            //    {
            //        RaiseMessageEvent("任务队列没有需要分析的图片");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Debug.Assert(false, "SendPictureItems error");
            //    MyLog4Net.Container.Instance.Log.Error("SendPictureItems error", ex);
            //}
            //return 0;
        }
        

        #endregion



        public int RealTimeTaskSendCount { get; set; }

        public AppUtil.Common.UrlEncodeUtil.EncodingType EncodingType { get; set; }
    }
}
