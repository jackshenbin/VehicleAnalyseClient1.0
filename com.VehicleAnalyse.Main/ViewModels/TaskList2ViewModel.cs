using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using com.VehicleAnalyse.DataModel;
using com.VehicleAnalyse.Main.Framework;
using com.VehicleAnalyse.Main.Views;
using System.Windows.Forms;
using Microsoft.Practices.Prism.Events;

namespace com.VehicleAnalyse.Main.ViewModels
{
    internal class TaskList2ViewModel
    {
        public event EventHandler TaskAdded;

        #region Fields
        
        private DataTable m_DTTasks;

        private AnalyseTask m_FocusedTask;

        private List<AnalyseTask> m_SelectedTasks;

        private Tuple<int, int> m_TaskStatistic;


        #endregion

        #region Properties
        
        internal DataTable DTTasks
        {
            get { return m_DTTasks; }
        }
        
        public List<AnalyseTask> SelectedTasks
        {
            get { return m_SelectedTasks; }
            set { m_SelectedTasks = value; }
        }

        public AnalyseTask FocusedTask
        {
            get { return m_FocusedTask; }
            set
            {
                if (m_FocusedTask != value)
                {
                    m_FocusedTask = value;
                    Framework.Container.Instance.EvtAggregator.GetEvent<SelectedTaskChangedEvent>().Publish(m_FocusedTask);
                }
            }
        }

        #endregion

        internal TaskList2ViewModel()
        {
            InitTable();
            m_SelectedTasks = new List<AnalyseTask>();
            m_TaskStatistic = new Tuple<int, int>(0,0);
            Framework.Container.Instance.EvtAggregator.GetEvent<TaskAddedEvent>().Subscribe(OnTaskAdded, ThreadOption.WinFormUIThread);
            //Framework.Container.Instance.EvtAggregator.GetEvent<TaskModifiedEvent>().Subscribe(OnTaskModified, ThreadOption.WinFormUIThread);
            Framework.Container.Instance.EvtAggregator.GetEvent<TaskStatusChangeEvent>().Subscribe(OnTaskStatusChanged, ThreadOption.WinFormUIThread);
        }

        #region Private helper functions

        private void InitTable()
        {
            m_DTTasks = new DataTable("Tasks");
            DataColumn columnId = m_DTTasks.Columns.Add("Id");
            m_DTTasks.PrimaryKey = new DataColumn[] { columnId };
            m_DTTasks.Columns.Add("Name");
            m_DTTasks.Columns.Add("Status");
            m_DTTasks.Columns.Add("PicCount");
            m_DTTasks.Columns.Add("StartTime");
            m_DTTasks.Columns.Add("TimeSpan");
            m_DTTasks.Columns.Add("FileType");
            m_DTTasks.Columns.Add("FilePath");
            m_DTTasks.Columns.Add("CreateTime");
            m_DTTasks.Columns.Add("FinishedTime");
            m_DTTasks.Columns.Add("Task", typeof(AnalyseTask));
        }

        private void AddRow(AnalyseTask task)
        {
            string status = Constant.TaskStatusInfos.FirstOrDefault(item => item.Type == task.Status).Name;
            string duration = GetTaskAnalyseDuration(task);

            m_DTTasks.Rows.Add(new object[] { task.TaskId, task.TaskName, status, 
                task.ProcessedFileCount,
                task.StartAnalyseTime,
                duration,
                DataModel.Constant.TaskTypeInfos.FirstOrDefault(item=>item.Type == task.TaskType).Name,
                task.PictureSource,
                (task.CreateTime != new DateTime())? task.CreateTime.ToString(DataModel.Constant.DATETIME_FORMAT) : string.Empty,
                (task.FinishedTime != new DateTime())? task.FinishedTime.ToString(DataModel.Constant.DATETIME_FORMAT) : string.Empty,
                task });
        }
            
        private string GetTaskAnalyseDuration(AnalyseTask task)
        {
            string duration = string.Empty;
            if (task.StartAnalyseTime!=new DateTime() && task.FinishedTime!=new DateTime())
            {
                TimeSpan span = task.FinishedTime.Subtract(task.StartAnalyseTime);
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
            return duration;
        }

        private string GetTaskStatusText(TaskProgressStatusInfo task)
        {
            string text = string.Empty;
            string status = Constant.TaskStatusInfos.FirstOrDefault(item=>item.Type == task.TaskStatus).Name;
            if (task.TaskStatus != TaskStatus.Analysing)
            {
                text = status;
            }
            else
            {
                int countProcessed = (int)task.Progress;
                text = string.Format("{0} ({1}%)", status, countProcessed);
            }
            return text;
        }

        private void RemoveRow(string id)
        {
            DataRow row = m_DTTasks.Rows.Find(id);
            if (row != null)
            {
                row.Delete();

                if (m_DTTasks.Rows.Count == 0)
                {
                    FocusedTask = null;
                }
            }
        }

        private void UpdateTaskStatus(TaskProgressStatusInfo task)
        {
            DataRow row = m_DTTasks.Rows.Find(task.TaskId);
            if (row != null)
            {
                string text = GetTaskStatusText(task);
                row["Status"] = text;
                //row["Task"] = task;
                row["PicCount"] = task.CommitCount;
                //row["RecognizedCount"] = task.PictureSource.RecognizedCount;
                //row["ImageErrorCount"] = task.PictureSource.ImageErrorCount;
                //row["NoPlateCount"] = task.PictureSource.NoPlateCount;
                //row["NotRecognizedCount"] = task.PictureSource.NotRecognizedCount;
                if (task.TaskStatus == TaskStatus.Analysing && string.IsNullOrEmpty(row["StartTime"].ToString()))
                    row["StartTime"] = DateTime.Now.ToString(Constant.DATETIME_FORMAT);
                if (task.TaskStatus == TaskStatus.Finished && string.IsNullOrEmpty(row["FinishedTime"].ToString()))
                    row["FinishedTime"] = DateTime.Now.ToString(Constant.DATETIME_FORMAT);

                DateTime StartAnalyseTime =string.IsNullOrEmpty( row["StartTime"].ToString())? new DateTime(): DateTime.Parse(row["StartTime"].ToString());
                DateTime FinishedTime = string.IsNullOrEmpty(row["FinishedTime"].ToString()) ? new DateTime() : DateTime.Parse(row["FinishedTime"].ToString());

                string duration = GetTaskAnalyseDuration(new AnalyseTask() { StartAnalyseTime = StartAnalyseTime, FinishedTime =FinishedTime });
                row["TimeSpan"] = duration;
            }
            UpdateTaskStatistic();
        }

        #endregion

        #region Internal helper functions
        
        internal void FillupTasks()
        {
            if (Framework.Environment.RealTimeVersion)
                return;

            List<AnalyseTask> tasks = Framework.Container.Instance.TaskManager.GetAllTasks();

            if (tasks != null && tasks.Count > 0)
            {
                foreach (AnalyseTask task in tasks)
                {
                    AddRow(task);
                }
                UpdateTaskStatistic();
            }
        }

        internal void AddTask()
        {
            using (FormAddTask dlg = new FormAddTask())
            {
                dlg.ShowDialog();
            }
        }

        internal void DeleteTask()
        {
            if (m_SelectedTasks != null && m_SelectedTasks.Count > 0)
            {
                string msg = string.Format("是否确定删除任务 '{0}'?", m_SelectedTasks[0].TaskName);

                if (m_SelectedTasks.Count > 1)
                {
                    msg = string.Format("是否确定删除 '{0}' 等 {1} 个任务?", m_SelectedTasks[0].TaskName, m_SelectedTasks.Count);
                }

                if (Framework.Container.Instance.InteractionService.ShowMessageBox(msg, "提示",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    AnalyseTask[] tasks = m_SelectedTasks.ToArray();

                    foreach (AnalyseTask task in tasks)
                    {
                        string taskId = task.TaskId;
                        Framework.Container.Instance.TaskManager.DeleteTask(task);
                        RemoveRow(taskId);
                        Framework.Container.Instance.EvtAggregator.GetEvent<TaskRemovedEvent>().Publish(task);
                    }
                    UpdateTaskStatistic();
                }
            }
        }

        private void UpdateTaskStatistic()
        {
            string Finished = DataModel.Constant.TaskStatusInfos.FirstOrDefault(it => it.Type == TaskStatus.Finished ).Name;
            string AnalysingError = DataModel.Constant.TaskStatusInfos.FirstOrDefault(it => it.Type == TaskStatus.AnalysingError).Name;

            DataRow[] rowsFinished = m_DTTasks.Select("Status='" + Finished + "' or Status='" + AnalysingError + "'");
            int countFinished = rowsFinished == null ? 0 : rowsFinished.Length;
            if (m_TaskStatistic.Item1 != countFinished ||
                m_TaskStatistic.Item2 != m_DTTasks.Rows.Count)
            {
                m_TaskStatistic = new Tuple<int, int>(countFinished, m_DTTasks.Rows.Count);
                Framework.Container.Instance.EvtAggregator.GetEvent<TaskStatisticUpdateEvent>().Publish(m_TaskStatistic);
            }
            // string s = string.Format("{0} (完成)/{1}", countFinished, m_DTTasks.Rows.Count);
        }


        #endregion

        #region Event handlers

        private void OnTaskAdded(AnalyseTask task)
        {
            AddRow(task);
            if (TaskAdded != null)
            {
                TaskAdded(task, EventArgs.Empty);
            }
            UpdateTaskStatistic();
        }

        //private void OnTaskModified(AnalyseTask task)
        //{
        //    DataRow row = m_DTTasks.Rows.Find(task.TaskId);

        //    if (row != null)
        //    {
        //        row["Name"] = task.TaskName;
        //        row["Task"] = task;
        //        m_FocusedTask = task;
        //    }
        //    UpdateTaskStatistic();
        //}

        private void OnTaskDeleted(AnalyseTask task)
        {
            RemoveRow(task.TaskId);
        }


        void OnTaskStatusChanged(TaskProgressStatusInfo task)
        {
            //if (Framework.Container.Instance.MainControl.InvokeRequired)
            //{
            //    Framework.Container.Instance.MainControl.BeginInvoke(new EventHandler(OnTaskStatusChanged), new object[] { sender, e });
            //    return;
            //}

            UpdateTaskStatus(task);
        }

        #endregion
    }
}
