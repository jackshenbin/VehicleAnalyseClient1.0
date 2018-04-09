using com.VehicleAnalyse.Service;
using Microsoft.Practices.Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppUtil;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Windows.Forms;
using com.VehicleAnalyse.DataModel;

namespace com.VehicleAnalyse.Main.Framework
{
    public class Container
    {
        #region Fields

        private static Container s_Instance = null;

        private EventAggregator m_evtAggregator = null;
        
        //private ImageAnalysisService m_ImageAnalysisService;

        //private VehicleInfoService m_VehicleInfoService;

        private TaskManager m_TaskManager;

        private VVMDataBindings m_vvmDataBindings = null;

        private CompositionContainer m_MEFContainer = null;

        private CacheManager m_cacheMgr;

        #endregion

        #region Properties

        public Control MainControl
        {
            get;
            set;
        }

        public EventAggregator EvtAggregator
        {
            get { return m_evtAggregator; }
        }

        //public ImageAnalysisService ImageAnalysisService
        //{
        //    get
        //    {
        //        if (m_ImageAnalysisService == null)
        //        {
        //            m_ImageAnalysisService = new ImageAnalysisService();
        //            m_ImageAnalysisService.AnalyseResult += new Action<DataModel.AnalyseRecord>(ImageAnalysisService_AnalyseResult);
        //            m_ImageAnalysisService.Message += new Action<uint, string>(ImageAnalysisService_Message);
        //        }
        //        return m_ImageAnalysisService;
        //    }
        //}

        //public VehicleInfoService VehicleInfoService
        //{
        //    get
        //    {
        //        if (m_VehicleInfoService == null)
        //        {
        //            m_VehicleInfoService = new VehicleInfoService();
        //        }
        //        return m_VehicleInfoService;
        //    }
        //}

        public TaskManager TaskManager
        {
            get
            {
                if(m_TaskManager == null)
                {
                    m_TaskManager = new TaskManager();
                    m_TaskManager.Message += new Action<string>(TaskManager_Message);
                    m_TaskManager.StatusChanged += new EventHandler(TaskManager_StatusChanged);
                    m_TaskManager.TaskSearchFinished += m_TaskManager_TaskSearchFinished;
                    m_TaskManager.TaskSwitchFinished += m_TaskManager_TaskSwitchFinished;
                    m_TaskManager.TaskCompareSearchFinished += m_TaskManager_TaskCompareSearchFinished;
                }
                return m_TaskManager;
            }
        }

        public VVMDataBindings VVMDataBindings
        {
            get
            {
                if (m_vvmDataBindings == null)
                {
                    m_vvmDataBindings = new VVMDataBindings();
                }
                return m_vvmDataBindings;
            }
        }

        [Import(typeof(IInteractionService))]
        public IInteractionService InteractionService { get; set; }
        
        public CacheManager CacheManager
        {
            get
            {
                if (m_cacheMgr == null)
                {
                    m_cacheMgr = new CacheManager();
                }
                return m_cacheMgr;
            }
        }


        #endregion

        #region Constructors

        private Container()
        {
            this.m_evtAggregator = new EventAggregator();

            var cataLog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            m_MEFContainer = new CompositionContainer(cataLog);

            try
            {
                m_MEFContainer.ComposeParts(this);
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.ToString());
            }

            DataModel.Constant.Init();
            AppUtil.InteractionService.DEFAULT_CAPTION = Environment.PROGRAM_NAME;
        }

        public static Container Instance
        {
            get
            {
                if (s_Instance == null)
                {
                    s_Instance = new Container();
                }
                return s_Instance;
            }
        }
        public void Cleanup()
        {
            try
            {

        //m_evtAggregator = null;
        if (m_TaskManager != null)
            m_TaskManager.Close();

        //if (m_ImageAnalysisService != null)
        //    m_ImageAnalysisService.Stop();

        //m_ImageAnalysisService = null;

        //m_VehicleInfoService = null;

        //m_TaskManager = null;

        if (m_vvmDataBindings != null)
            m_vvmDataBindings.RemoveBindings();

        //m_MEFContainer = null;

       m_cacheMgr = null;
       Framework.Environment.Reset();
            }
            catch (SDKCallException ex)
            {
                Console.WriteLine(ex.ToString());

            }
        }

        #endregion

        #region Event handlers

        void AuthenticationService_Closed(object sender, EventArgs e)
        {
            // TaskManager.Running = false;
            TaskManager.Connected = false;
            m_evtAggregator.GetEvent<AnalyseMessageEvent>().Publish(new Tuple<uint, string>(11, "与服务器连接断开"));
        }

        void AuthenticationService_ServerInUse(object sender, EventArgs e)
        {
            TaskManager.Close();
            m_evtAggregator.GetEvent<AnalyseMessageEvent>().Publish(new Tuple<uint, string>(11, "服务器正忙"));
        }


        void ImageAnalysisService_Message(uint arg1, string arg2)
        {
            m_evtAggregator.GetEvent<AnalyseMessageEvent>().Publish(new Tuple<uint, string>(arg1, arg2));
        }
        
        void TaskManager_Message(string obj)
        {
            m_evtAggregator.GetEvent<AnalyseMessageEvent>().Publish(new Tuple<uint, string>(888, obj));
        }



        void ImageAnalysisService_AnalyseResult(DataModel.AnalyseRecord obj)
        {
            m_evtAggregator.GetEvent<AnalyseRecordEvent>().Publish(obj);
        }

        //void ImageAnalysisService_AnalyseResultsByFile(string arg1, AnalyseRecord[] arg2)
        //{
        //    m_evtAggregator.GetEvent<AnalyseRecordsByFileEvent>().Publish(new Tuple<string, AnalyseRecord[]>(arg1, arg2));
        //}

        void TaskManager_StatusChanged(object sender, EventArgs e)
        {
            m_evtAggregator.GetEvent<TaskStatusChangeEvent>().Publish(sender as TaskProgressStatusInfo);
        }
        void m_TaskManager_TaskSearchFinished(List<AnalyseRecord> obj, long arg2,string arg3)
        {
            m_evtAggregator.GetEvent<SearchFinishedEvent>().Publish(new Tuple<List<AnalyseRecord>, long, string>(obj, arg2, arg3));
        }

        void m_TaskManager_TaskCompareSearchFinished(List<AnalyseRecord> obj, long arg2, string arg3)
        {
            m_evtAggregator.GetEvent<CompareSearchFinishedEvent>().Publish(new Tuple<List<AnalyseRecord>, long, string>(obj, arg2, arg3));
        }
        void m_TaskManager_TaskSwitchFinished(List<AnalyseRecord> arg1, long arg2, string arg3)
        {
            m_evtAggregator.GetEvent<SearchSwitchFinishedEvent>().Publish(new Tuple<List<AnalyseRecord>, long, string>(arg1, arg2, arg3));
        }




        #endregion

    }
}
