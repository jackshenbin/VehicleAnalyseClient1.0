using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppUtil;
using com.VehicleAnalyse.DataModel;
using com.VehicleAnalyse.Service.DAO;
using com.VehicleAnalyse.Main.Framework;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using AppUtil.Common;

namespace com.VehicleAnalyse.Main.ViewModels
{
    class AddEditTaskViewModel : ViewModelBase
    {
        #region Fields

        private AnalyseTask m_EditTask;

        private List<PictureItem> m_realtimepics;

        #endregion

        #region Properties
        
        public string Name
        {
            get
            {
                return m_EditTask.TaskName;
            }
            set
            {
                m_EditTask.TaskName = value;
            }
        }

        public TaskType TaskType
        {
            get
            {
                return m_EditTask.TaskType;
            }
            set
            {
                m_EditTask.TaskType = value;
            }
        }

        public bool IncludeChildFolder
        {
            get;
            set;
        }

        public string ErrorMsg
        {
            get;
            set;
        }


        public string Path
        {
            get
            {
                return m_EditTask.PictureSource;
            }
            set
            {
                m_EditTask.PictureSource = value;
            }
        }
        public string CameraId
        {
            get
            {
                return m_EditTask.CameraId;
            }
            set
            {
                m_EditTask.CameraId = value;
            }
        }
        public int TaskPriority
        {
            get
            {
                return m_EditTask.TaskPriority;
            }
            set
            {
                m_EditTask.TaskPriority = value;
            }
        }


        #endregion

        #region Constructors
        
        public AddEditTaskViewModel()
        {
            m_EditTask = new AnalyseTask();
            m_EditTask.TaskType = DataModel.TaskType.History;
            m_EditTask.PictureSource = "";
            m_EditTask.CameraId = "";
            m_EditTask.TaskPriority = 3;
            m_EditTask.TaskName = "任务_" + DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        #endregion

        private bool ValidateInputs()
        {
            bool bRet = false;
            string name = m_EditTask.TaskName;
            string msg;


            bRet = !Framework.Container.Instance.TaskManager.GetAllTasks().Exists(it => it.TaskName == name);
            if (!bRet)
            {
                //Framework.Container.Instance.InteractionService.ShowMessageBox(msg, "添加任务");
                ErrorMsg = "任务名称重复";
                return bRet;
            }


            bRet = AppUtil.Common.TextUtil.ValidateNameText(ref name, false, "任务_" + DateTime.Now.ToString("yyyyMMddHHmmss"), 1, 256, out msg);
            if (!bRet)
            {
                //Framework.Container.Instance.InteractionService.ShowMessageBox(msg, "添加任务");
                ErrorMsg = msg;
                return bRet;
            }

            m_EditTask.TaskName = name;

            if (m_EditTask.TaskType == DataModel.TaskType.Realtime)
            {

                FileAccessBase m_FileAccess = FileAccessFactory.GetFileAccess(m_EditTask.PictureSource);

                bRet = m_FileAccess.Validate(ref msg);
                if (!bRet)
                {
                    //Framework.Container.Instance.InteractionService.ShowMessageBox(msg, "添加任务");
                    ErrorMsg = msg;
                    return bRet;
                }

                bRet = true;

                List<PictureItem> pics = null;
                try
                {
                    pics = m_FileAccess.GetFiles();
                }
                catch (Exception ex)
                {
                    Debug.Assert(false, ex.Message);
                    pics = null;
                    MyLog4Net.Container.Instance.Log.Error("获取文件列表出错", ex);
                    //Framework.Container.Instance.InteractionService.ShowMessageBox(
                    //    string.Format("获取 {0} 文件列表出错", m_EditTask.PictureSource),
                    //    Framework.Environment.PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ErrorMsg = string.Format("获取 {0} 文件列表出错", m_EditTask.PictureSource);

                    bRet = false;
                    return bRet;
                }
                if (pics != null && pics.Count > 0)
                {
                    m_realtimepics = pics;
                }
                else
                {
                    bRet = false;
                    //Framework.Container.Instance.InteractionService.ShowMessageBox(
                    //    string.Format("目录 {0} 没有可以分析的图片", m_EditTask.PictureSource),
                    //    Framework.Environment.PROGRAM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ErrorMsg = string.Format("目录 {0} 没有可以分析的图片", m_EditTask.PictureSource);
                }

            }
            return bRet;
        }

        public bool Commit()
        {
            bool bRet = ValidateInputs();
            if (bRet)
            {

                m_EditTask.Status = TaskStatus.Init;
                AnalyseTask task = m_EditTask.Clone() as AnalyseTask;
                task.TaskName =  m_EditTask.TaskName;
                task.TaskId = "V_"+DateTime.Now.Ticks.ToString();
                task.StartAnalyseTime = DateTime.Now;
                task.CreateTime = DateTime.Now;
                try
                {
                    Framework.Container.Instance.TaskManager.AddTask(task, m_realtimepics);
                    Framework.Container.Instance.EvtAggregator.GetEvent<TaskAddedEvent>().Publish(task);
                }
                catch (SDKCallException ex)
                {
                    bRet = false;
                    ErrorMsg = "添加任务失败，错误信息" + ex.ToString();
                }
            }
            RaisePropertyChangedEvent("ErrorMsg");
            return bRet;
        }

    }
}
