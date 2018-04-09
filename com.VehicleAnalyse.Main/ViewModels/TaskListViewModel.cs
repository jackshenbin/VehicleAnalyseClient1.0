using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Bocom.ImageAnalysisClient.DataModel;
using Bocom.ImageAnalysisClient.App.Framework;
using Bocom.ImageAnalysisClient.App.Views;
using System.Windows.Forms;
using Microsoft.Practices.Prism.Events;

namespace Bocom.ImageAnalysisClient.App.ViewModels
{
    internal class TaskListViewModel
    {
        public event EventHandler TaskAdded;

        #region Fields
        
        private DataTable m_DTTasks;

        private AnalyseTask m_FocusedTask;

        private List<AnalyseTask> m_SelectedTasks;

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

        internal TaskListViewModel()
        {
            InitTable();
            m_SelectedTasks = new List<AnalyseTask>();
            Framework.Container.Instance.EvtAggregator.GetEvent<TaskAddedEvent>().Subscribe(OnTaskAdded, ThreadOption.WinFormUIThread);
            Framework.Container.Instance.EvtAggregator.GetEvent<TaskModifiedEvent>().Subscribe(OnTaskModified, ThreadOption.WinFormUIThread);
            Framework.Container.Instance.EvtAggregator.GetEvent<TaskStatusChangeEvent>().Subscribe(OnTaskStatusChanged, ThreadOption.WinFormUIThread);
            Framework.Container.Instance.EvtAggregator.GetEvent<TaskAnalyseProgressUpdateEvent>().Subscribe(OnTaskAnalyseProgressUpdated, ThreadOption.WinFormUIThread);
        }

        #region Private helper functions

        private void InitTable()
        {
            m_DTTasks = new DataTable("Tasks");
            DataColumn columnId = m_DTTasks.Columns.Add("Id", typeof(uint));
            m_DTTasks.PrimaryKey = new DataColumn[] { columnId };
            m_DTTasks.Columns.Add("Name");
            m_DTTasks.Columns.Add("Status");
            m_DTTasks.Columns.Add("Task", typeof(AnalyseTask));
        }

        private string GetTaskStatusText(AnalyseTask task)
        {
            string text = string.Empty;
            TaskStatusInfo statusInfo = Constant.TaskStatusInfos[(int)task.Status];
            if (task.Status != TaskStatus.Analysing)
            {
                text = statusInfo.Name;
            }
            else
            {
                //int countProcessed = task.PictureSource.RecognizedCount + task.PictureSource.ImageErrorCount;
                //if (countProcessed == 0)
                //{
                //    text = string.Format("{0} (0%)", statusInfo.Name);
                //}
                //else
                //{
                //    float percent = ((float)countProcessed) / ((float)task.PictureSource.Count);
                //    string tmp = (percent * 100).ToString("F1");
                //    text = string.Format("{0} ({1}%)", statusInfo.Name, tmp);
                //}
            }
            return text;
        }

        private void AddRow(AnalyseTask task)
        {
            string text = GetTaskStatusText(task);
            m_DTTasks.Rows.Add(new object[] { task.TaskId, task.TaskName, text, task });
        }

        private void RemoveRow(uint id)
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

        private void UpdateTaskStatus(AnalyseTask task)
        {
            DataRow row = m_DTTasks.Rows.Find(task.TaskId);
            if (row != null)
             {
                 string text = GetTaskStatusText(task);
                 row["Status"] = text;
             }
        }

        #endregion

        #region Internal helper functions
        
        internal void FillupTasks()
        {
            List<AnalyseTask> tasks = Framework.Container.Instance.TaskManager.GetAllTasks();

            if (tasks != null && tasks.Count > 0)
            {
                foreach (AnalyseTask task in tasks)
                {
                    AddRow(task);
                }
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
                string msg = string.Format("是否确定删除 '{0}' 等任务?", m_SelectedTasks[0].TaskName);
                if (Framework.Container.Instance.InteractionService.ShowMessageBox(msg, "提示",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    AnalyseTask[] tasks = m_SelectedTasks.ToArray();

                    foreach (AnalyseTask task in tasks)
                    {
                        uint taskId = task.TaskId;
                        Framework.Container.Instance.TaskManager.DeleteTask(task);
                        RemoveRow(taskId);
                        Framework.Container.Instance.EvtAggregator.GetEvent<TaskRemovedEvent>().Publish(task);
                    }
                }
            }
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
        }

        private void OnTaskModified(AnalyseTask task)
        {
            DataRow row = m_DTTasks.Rows.Find(task.TaskId);

            if (row != null)
            {
                row["Name"] = task.TaskName;
                row["Task"] = task;
            }
        }

        private void OnTaskDeleted(AnalyseTask task)
        {
            RemoveRow(task.TaskId);
        }

        void OnTaskAnalyseProgressUpdated(AnalyseTask task)
        {
            //if (Framework.Container.Instance.MainControl.InvokeRequired)
            //{
            //    Framework.Container.Instance.MainControl.BeginInvoke(new EventHandler(OnTaskAnalyseProgressUpdated), new object[] { sender, e });
            //    return;
            //}

            UpdateTaskStatus(task);
        }

        void OnTaskStatusChanged(AnalyseTask task)
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
