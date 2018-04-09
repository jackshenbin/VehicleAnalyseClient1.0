using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Bocom.ImageAnalysisClient.App.ViewModels;

namespace Bocom.ImageAnalysisClient.App.Views
{
    public partial class ucAnalyseResults : DevExpress.XtraEditors.XtraUserControl
    {

        private AnalyseResultsViewModel m_VM;

        public ucAnalyseResults()
        {
            InitializeComponent();
        }

        private void ucAnalyseResults_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                m_VM = new AnalyseResultsViewModel();
                gridControl1.DataSource = m_VM.DataView;
            }
        }
        
        void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = e.RowHandle.ToString();
                //if (m_VM != null && m_VM.ResultPageInfo != null)
                //{
                //    int index = e.RowHandle + m_StartRecordIndex;
                //    e.Info.DisplayText = index.ToString();
                //}
            }
        }
    }
}
