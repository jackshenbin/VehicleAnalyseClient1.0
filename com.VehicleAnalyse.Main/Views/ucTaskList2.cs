using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using com.VehicleAnalyse.Main.ViewModels;
using com.VehicleAnalyse.Main.Framework;
using AppUtil;
using com.VehicleAnalyse.DataModel;
using System.Linq;
namespace com.VehicleAnalyse.Main.Views
{
    public partial class ucTaskList2 : DevExpress.XtraEditors.XtraUserControl
    {
        #region Fields

        private TaskList2ViewModel m_ViewModel;

        #endregion

        public ucTaskList2()
        {
            InitializeComponent();
        }

        internal void Init()
        {
            m_ViewModel = new TaskList2ViewModel();
            gridControl1.DataSource = m_ViewModel.DTTasks;
            Framework.Container.Instance.EvtAggregator.GetEvent<UserLoginEvent>().Subscribe(OnUserLoggedin);

        }

        private void ucTaskList2_SizeChanged(object sender, EventArgs e)
        {
            gridControl1.Height = this.Height - panelControl1.Height;
            gridControl1.Width = this.Width;
            // gridControl1
        }

        private void OnUserLoggedin(LoginToken token)
        {
            m_ViewModel.FillupTasks();
            m_ViewModel.TaskAdded += new EventHandler(ViewModel_TaskAdded);
        }

        void ViewModel_TaskAdded(object sender, EventArgs e)
        {
            // treeList1.MoveLast();
        }

        private void barButtonItemAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            m_ViewModel.AddTask();
        }

        private void barButtonItemDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            m_ViewModel.DeleteTask();
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            m_ViewModel.AddTask();
        }

        private void btnEditTask_Click(object sender, EventArgs e)
        {
        }

        private void btnDelTask_Click(object sender, EventArgs e)
        {
            m_ViewModel.DeleteTask();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow row = gridView1.GetDataRow(e.FocusedRowHandle);
            if (row != null)
            {
                //if (gridView1.SelectedRowsCount == 0)
                //{
               gridView1.SelectRow(e.FocusedRowHandle);
                //}

                m_ViewModel.FocusedTask = (AnalyseTask)row["Task"];
                // btnDelTaskUnit.Enabled = btnEditTaskUnit.Enabled = true;
            }
        }
        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "Status" && e.RowHandle >= 0)
            {
                string AnalysingError = DataModel.Constant.TaskStatusInfos.FirstOrDefault(it => it.Type == TaskStatus.AnalysingError).Name;
                if (e.CellValue.ToString() == AnalysingError)
                    e.Appearance.ForeColor = Color.DarkRed;

                string Finished = DataModel.Constant.TaskStatusInfos.FirstOrDefault(it => it.Type == TaskStatus.Finished).Name;
                if (e.CellValue.ToString() == Finished)
                    e.Appearance.ForeColor = Color.LightSkyBlue;

            }

        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            List<AnalyseTask> tasks = null;
            if (gridView1.SelectedRowsCount > 0)
            {
                tasks = new List<AnalyseTask>();
                int[] ids = gridView1.GetSelectedRows();
                foreach (int id in ids)
                {
                    DataRow row = gridView1.GetDataRow(id);
                    if (row == null)
                        continue;
                    tasks.Add(row["Task"] as AnalyseTask);
                }
            }
            m_ViewModel.SelectedTasks = tasks;
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
        }

    }
}
