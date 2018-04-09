using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bocom.ImageAnalysisClient.App.ViewModels;

namespace Bocom.ImageAnalysisClient.App.Views
{
    public partial class ucTaskDetails : UserControl
    {

        private TaskDetailsViewModel m_ViewModel;
        
        public ucTaskDetails()
        {
            InitializeComponent();
        }

        internal void Init()
        {
            m_ViewModel = new TaskDetailsViewModel();

            cmbBoxFileType.Properties.DataSource = DataModel.Constant.FileTypeInfos;
            cmbBoxFileType.Properties.DisplayMember = "Name";
            cmbBoxFileType.Properties.ValueMember = "Id";
            Framework.Container.Instance.VVMDataBindings.AddBinding(cmbBoxFileType, "EditValue", m_ViewModel, "FileType");

            Framework.Container.Instance.VVMDataBindings.AddBinding(this, "Visible", m_ViewModel, "HasSelectedTask");
            Framework.Container.Instance.VVMDataBindings.AddBinding(txtBoxName, "Text", m_ViewModel, "Name");
            // Framework.Container.Instance.VVMDataBindings.AddBinding(cmbBoxFileType, "SelectedIndex", m_ViewModel, "FileType");
            Framework.Container.Instance.VVMDataBindings.AddBinding(txtBoxURL, "Text", m_ViewModel, "Path");

            Framework.Container.Instance.VVMDataBindings.AddBinding(timeEditCreate, "EditValue", m_ViewModel, "CreateTime");
            gridControl1.DataSource = m_ViewModel.DTSummary;
            //Framework.Container.Instance.VVMDataBindings.AddBinding(txtBoxUserName, "Text", m_ViewModel, "UserName");
            //Framework.Container.Instance.VVMDataBindings.AddBinding(txtBoxPassword, "Text", m_ViewModel, "Password");
            //Framework.Container.Instance.VVMDataBindings.AddBinding(spinEdit1, "Value", m_ViewModel, "PictureCount");
        }

        private void ucTaskDetails_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                
            }
        }

        private void btnViewResults_Click(object sender, EventArgs e)
        {
            m_ViewModel.ViewResults();
        }

        private void btnViewFailedResults_Click(object sender, EventArgs e)
        {
            m_ViewModel.ViewFailedResults();
        }
    }
}
