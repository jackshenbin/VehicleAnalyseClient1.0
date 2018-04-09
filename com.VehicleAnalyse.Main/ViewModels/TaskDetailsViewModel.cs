using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WinFormAppUtil;
using Bocom.ImageAnalysisClient.App.Framework;
using Bocom.ImageAnalysisClient.DataModel;
using System.Data;
using Microsoft.Practices.Prism.Events;

namespace Bocom.ImageAnalysisClient.App.ViewModels
{
    class TaskDetailsViewModel : ViewModelBase
    {
        #region Fields
        
        private AnalyseTask m_SelectedTask;
        private DataTable m_DTSummary;

        private string m_Name;

        #endregion

        #region Properties
        
        public string Name
        {
            get
            {
                if (m_SelectedTask != null)
                {
                    return m_SelectedTask.TaskName;
                }
                return m_Name;
            }
            set
            {
              
            }
        }

        public DateTime CreateTime
        {
            get
            {
                if (m_SelectedTask != null &&m_SelectedTask.CreateTime.HasValue)
                {
                    return m_SelectedTask.CreateTime.Value;
                }
                return DateTime.MinValue;
            }
        }

        public TaskType TaskType
        {
            get
            {
                if (m_SelectedTask != null)
                {
                    return m_SelectedTask.TaskType;
                }
                return TaskType.History;
            }
            set
            {

            }
        }

        public string Path
        {
            get
            {
                if (m_SelectedTask != null &&m_SelectedTask.PictureSource != null)
                {
                    return m_SelectedTask.PictureSource;
                }
                return string.Empty;
            }
            set
            {

            }
        }

        public bool HasSelectedTask
        {
            get
            {
                return m_SelectedTask != null;
            }
            set
            {

            }
        }

        public DataTable DTSummary
        {
            get { return m_DTSummary; }
        }

        #endregion

        internal TaskDetailsViewModel()
        {
            InitDataTable();
            Framework.Container.Instance.EvtAggregator.GetEvent<SelectedTaskChangedEvent>().Subscribe(OnSelectedTaskChanged);
            Framework.Container.Instance.EvtAggregator.GetEvent<TaskStatusChangeEvent>().Subscribe(OnTaskStatusChanged, ThreadOption.WinFormUIThread);
            Framework.Container.Instance.EvtAggregator.GetEvent<TaskModifiedEvent>().Subscribe(OnTaskStatusChanged, ThreadOption.WinFormUIThread);
            Framework.Container.Instance.EvtAggregator.GetEvent<TaskAnalyseProgressUpdateEvent>().Subscribe(OnTaskAnalyseProgressUpdated, ThreadOption.WinFormUIThread);
        }

        private void InitDataTable()
        {
            m_DTSummary = new DataTable("TaskSummary");
            m_DTSummary.Columns.Add("Name");
            m_DTSummary.Columns.Add("Value");
        }

        private void UpdateSummaryTable()
        {
            m_DTSummary.Rows.Clear();
            if (m_SelectedTask != null)
            {
                m_DTSummary.Rows.Add(new object[] { "状态", DataModel.Constant.TaskStatusInfos[(int)m_SelectedTask.Status].Name });
                //m_DTSummary.Rows.Add(new object[] { "图片总数量", m_SelectedTask.PictureSource.Count });
                //m_DTSummary.Rows.Add(new object[] { "已识别图片数量", m_SelectedTask.PictureSource.RecognizedCount });
                //m_DTSummary.Rows.Add(new object[] { "未识别图片数量", m_SelectedTask.PictureSource.ImageErrorCount });
                m_DTSummary.Rows.Add(new object[] { "开始分析时间", m_SelectedTask.StartAnalyseTime.HasValue ? 
                m_SelectedTask.StartAnalyseTime.Value.ToString(Constant.DATETIME_FORMAT) : string.Empty });
                m_DTSummary.Rows.Add(new object[] { "完成分析时间", m_SelectedTask.FinishedTime.HasValue ? 
                m_SelectedTask.FinishedTime.Value.ToString(Constant.DATETIME_FORMAT) : string.Empty });

                string duration = string.Empty;
                if (m_SelectedTask.StartAnalyseTime.HasValue && m_SelectedTask.FinishedTime.HasValue)
                {
                    TimeSpan span = m_SelectedTask.FinishedTime.Value.Subtract(m_SelectedTask.StartAnalyseTime.Value);
                    StringBuilder sb = new StringBuilder();
                    if (span.Hours > 0)
                    {
                        sb.AppendFormat("{0}小时", span.Hours);
                    }
                    if (span.Hours > 0 || span.Minutes > 0)
                    {
                        sb.AppendFormat("{0}分", span.Minutes);
                    }
                    if (span.Minutes > 0 || span.Seconds > 0)
                    {
                        sb.AppendFormat("{0}秒", span.Seconds);
                    }

                    duration = sb.ToString();
                }
                m_DTSummary.Rows.Add(new object[] { "分析用时", duration });
            }
        }

        private void OnSelectedTaskChanged(AnalyseTask task)
        {
            m_SelectedTask = task;
            UpdateSummaryTable();

            if (m_SelectedTask != null)
            {
                // Name = m_SelectedTask.Name;
                RaisePropertyChangedEvent("Name");
                RaisePropertyChangedEvent("FileType");
                RaisePropertyChangedEvent("Path");
            }
            RaisePropertyChangedEvent("HasSelectedTask");
        }

        private void OnTaskStatusChanged(AnalyseTask task)
        {
            if (m_SelectedTask != null && m_SelectedTask.TaskId == task.TaskId)
            {
                m_SelectedTask = task;
               UpdateSummaryTable();    
                // Name = m_SelectedTask.Name;
                RaisePropertyChangedEvent("Name");
                RaisePropertyChangedEvent("FileType");
                RaisePropertyChangedEvent("Path");
            }
        }

        private void OnTaskAnalyseProgressUpdated(AnalyseTask task)
        {
            if (m_SelectedTask != null && m_SelectedTask.TaskId == task.TaskId)
            {
                m_SelectedTask = task;
                UpdateSummaryTable();
            }
        }
        
        internal void ViewResults()
        {
            if (m_SelectedTask != null)
            {
                Framework.Container.Instance.EvtAggregator.GetEvent<ViewResultsEvent>().Publish(m_SelectedTask);
            }
        }

        internal void ViewFailedResults()
        {
            if (m_SelectedTask != null)
            {
                Framework.Container.Instance.EvtAggregator.GetEvent<ViewFailedResultsEvent>().Publish(m_SelectedTask);
            }
        }
    }
}
