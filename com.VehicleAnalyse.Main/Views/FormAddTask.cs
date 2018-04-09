using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using com.VehicleAnalyse.DataModel;
using com.VehicleAnalyse.Main.ViewModels;
using System.Linq;

namespace com.VehicleAnalyse.Main.Views
{
    public partial class FormAddTask : DevExpress.XtraEditors.XtraForm
    {
        #region Fields


        private static string s_LastSelectedFolder;

        private AddEditTaskViewModel m_ViewModel;
        
        #endregion

        #region Constructors
        
        public FormAddTask()
        {
            InitializeComponent();
            m_ViewModel = new AddEditTaskViewModel();
        }


        #endregion


        #region Event handlers
        

        private void FormAddTask_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                cmbBoxTaskType.Properties.DataSource = DataModel.Constant.TaskTypeInfos;
                cmbBoxTaskType.Properties.DisplayMember = "Name";
                cmbBoxTaskType.Properties.ValueMember = "Type";
                comboBoxEditCamera.Properties.Items.AddRange(Framework.Environment.CameraList.ToArray());
                comboBoxEditFilePath.Properties.Items.AddRange(Framework.Environment.FilePathList.ToArray());
                Framework.Container.Instance.VVMDataBindings.AddBinding(cmbBoxTaskType, "EditValue", m_ViewModel, "TaskType");

                Framework.Container.Instance.VVMDataBindings.AddBinding(txtBoxName, "Text", m_ViewModel, "Name");
                Framework.Container.Instance.VVMDataBindings.AddBinding(comboBoxEditFilePath, "Text", m_ViewModel, "Path");
                Framework.Container.Instance.VVMDataBindings.AddBinding(comboBoxEditCamera, "Text", m_ViewModel, "CameraId");
                Framework.Container.Instance.VVMDataBindings.AddBinding(ratingStar1, "Rating", m_ViewModel, "TaskPriority");
                Framework.Container.Instance.VVMDataBindings.AddBinding(this.checkBox1, "Checked", m_ViewModel, "IncludeChildFolder");
                //Framework.Container.Instance.VVMDataBindings.AddBinding(labelControlMsg, "Text", m_ViewModel, "ErrorMsg");
                m_ViewModel.PropertyChanged += new PropertyChangedEventHandler(m_ViewModel_PropertyChanged);
                cmbBoxTaskType.EditValue = m_ViewModel.TaskType = (Framework.Environment.RealTimeVersion ? TaskType.Realtime : TaskType.History);
                cmbBoxTaskType.Enabled = false;
            }
        }

        void m_ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ErrorMsg")
                labelControlMsg.Text = m_ViewModel.ErrorMsg;
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            List<CameraInfo> cams = Framework.Environment.CameraList;
            if (!string.IsNullOrEmpty(m_ViewModel.CameraId) && cams.Find(item=>item.FullName== m_ViewModel.CameraId)==null)
            {
                cams.Add(new CameraInfo() { FullName = m_ViewModel.CameraId, ID = m_ViewModel.CameraId });
                Framework.Environment.CameraList = cams;
            }
            List<FilePathInfo> files = Framework.Environment.FilePathList;
            if (!string.IsNullOrEmpty(m_ViewModel.Path) && files.Find(item => item.FullName == m_ViewModel.Path) == null)
            {
                files.Add(new FilePathInfo() { FullName = m_ViewModel.Path, ID = m_ViewModel.Path });
                Framework.Environment.FilePathList = files;
            }
            if (m_ViewModel.Commit())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                this.DialogResult = DialogResult.None;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }



        private void cmbBoxFileType_EditValueChanged(object sender, EventArgs e)
        {
            labelControl3.Visible = comboBoxEditCamera.Visible = ((TaskType)cmbBoxTaskType.EditValue == TaskType.Realtime);
        }


        #endregion


    }
}