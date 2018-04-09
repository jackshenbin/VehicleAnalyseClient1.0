using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Bocom.ImageAnalysisClient.App.Framework;
using WinFormAppUtil;
using Bocom.ImageAnalysisClient.App.ViewModels;
using Bocom.ImageAnalysisClient.DataModel;
using DevExpress.XtraTreeList.Nodes;

namespace Bocom.ImageAnalysisClient.App.Views
{
    public partial class ucTaskList : DevExpress.XtraEditors.XtraUserControl
    {
        #region Fields
        
        private TaskListViewModel m_ViewModel;

        #endregion

        #region Constructors
        
        public ucTaskList()
        {
            InitializeComponent();
            barManager1.SetPopupContextMenu(this.treeList1, this.popupMenu1);
        }

        #endregion

        internal void Init()
        {
            m_ViewModel = new TaskListViewModel();
            treeList1.DataSource = m_ViewModel.DTTasks;
            Framework.Container.Instance.EvtAggregator.GetEvent<UserLoginEvent>().Subscribe(OnUserLoggedin);
            m_ViewModel.FillupTasks();
            m_ViewModel.TaskAdded += new EventHandler(ViewModel_TaskAdded);
        }

        #region Event handlers
        
        private void ucTaskList_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                
            }
        }

        private void OnUserLoggedin(LoginToken token)
        {
            // m_ViewModel.FillupTasks();
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (e.Node != null)
            {
                object obj = e.Node.GetValue(this.columnTask);
                if (obj != null)
                {
                    m_ViewModel.FocusedTask = obj as AnalyseTask;
                }
            }
        }

        private void barButtonItemAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            m_ViewModel.AddTask();
        }

        private void barButtonItemDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            m_ViewModel.DeleteTask();
        }

        private void treeList1_SelectionChanged(object sender, EventArgs e)
        {
            List<AnalyseTask> tasks = null;
            if (treeList1.Selection != null && treeList1.Selection.Count > 0)
            {
                tasks = new List<AnalyseTask>();
                foreach (TreeListNode node in treeList1.Selection)
                {
                    tasks.Add(node.GetValue(this.columnTask) as AnalyseTask);
                }
            }

            m_ViewModel.SelectedTasks = tasks;
        }

        void ViewModel_TaskAdded(object sender, EventArgs e)
        {
            treeList1.MoveLast();
        }
        
        private void treeList1_CustomDrawNodeIndicator(object sender, DevExpress.XtraTreeList.CustomDrawNodeIndicatorEventArgs e)
        {
            
        }
      
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        #endregion

    }
}
