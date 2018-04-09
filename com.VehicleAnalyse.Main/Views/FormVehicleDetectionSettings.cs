using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Bocom.ImageAnalysisClient.DataModel;

namespace Bocom.ImageAnalysisClient.App.Views
{
    public partial class FormVehicleDetectionSettings : DevExpress.XtraEditors.XtraForm
    {
        private AnalyseTask m_Task;
        private int m_Offset;

        public FormVehicleDetectionSettings(AnalyseTask task)
        {
            m_Task = task;
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int diff = (int)(this.spinEditPlateRangeMax.Value - this.spinEditPlateRangeMin.Value);
            if (diff < 0 || diff > 100)
            {
                Framework.Container.Instance.InteractionService.ShowMessageBox("车牌像素范围最小值必须小于等于最大值, 并且差值小于100",
                    Framework.Environment.PROGRAM_NAME,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = System.Windows.Forms.DialogResult.None;
                return;
            }

            //m_Task.CameraId = (int)this.spinEditCameraId.Value;


            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormVehicleDetectionSettings_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                //this.spinEditCameraId.Value =  m_Task.CameraId;
            }
        }
    }
}