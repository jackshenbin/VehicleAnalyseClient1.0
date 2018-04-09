using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.VehicleAnalyse.Main.ViewModels;
using com.VehicleAnalyse.DataModel;

namespace com.VehicleAnalyse.Main.Views
{
    public partial class ucSingleResultDetailInfo : UserControl
    {

        private SingleResultDetailViewModel m_viewModel;
        private List<AnalyseRecord> m_analyseResults = null;

        private string vehicleID = "";
        public ucSingleResultDetailInfo()
        {
            InitializeComponent();
        }

        public void SetAnalyseResults(List<AnalyseRecord> results)
        {
            m_viewModel = new SingleResultDetailViewModel();
            m_viewModel.AnalyseResults = m_analyseResults = results;
        }
        internal void SetVehicle(DataModel.AnalyseRecord tmp)
        {
            if (m_viewModel == null)
                m_viewModel = new SingleResultDetailViewModel();
            if (tmp == null)
                Clear();
            else
                Init(tmp);
            simpleButtonPriv.Enabled = m_viewModel.IsCanPriv(vehicleID);
            simpleButtonNext.Enabled = m_viewModel.IsCanNext(vehicleID);
        }

        private void Clear()
        {
            labelControlPlate.Text = "";
            labelControlSimilar.Text = "";
            pictureEdit1.Image = null;
            vehicleID = "";
            flowLayoutPanel1.Controls.Clear();
        }

        private void Init(DataModel.AnalyseRecord tmp)
        {
            labelControlPlate.Text = tmp.GetPlateNumber(); 
            labelControlSimilar.Text = "相似度:" + tmp.CompareSimilarity.ToString() + "%";
            //红95橙85黄60蓝
            if (tmp.CompareSimilarity >= 95)
                labelControlSimilar.ForeColor = Color.Red;
            else if (tmp.CompareSimilarity >= 85)
                labelControlSimilar.ForeColor = Color.OrangeRed;
            else if (tmp.CompareSimilarity >= 50)
                labelControlSimilar.ForeColor = Color.Yellow;
            else
                labelControlSimilar.ForeColor = Color.LightSkyBlue;

            if (tmp.CompareSimilarity > 99)
                labelControlSimilar.Appearance.Image = com.VehicleAnalyse.Main.Properties.Resources.Crown_18_468571428571px_1194754_easyicon_net;
            else
                labelControlSimilar.Appearance.Image = null;

            m_viewModel.GetImage(tmp);
            //pictureEdit1.Image = tmp.Image;
            ShowFullImage(tmp);
            vehicleID = tmp.Id;

            flowLayoutPanel1.Controls.Clear();


            foreach (string item in tmp.GetSettings())
            {
                DevExpress.XtraEditors.LabelControl labelControl1 = new DevExpress.XtraEditors.LabelControl();
                labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Default;
                labelControl1.Text = item; 
                labelControl1.ToolTip = item;
                if (labelControl1.Text.Contains(AnalyseRecord.GCDD))
                    labelControl1.Text = AnalyseRecord.GCDD + "：" + Framework.Environment.GetDeviceName(tmp.DeviceId);

                    
                flowLayoutPanel1.Controls.Add(labelControl1);
                
            }

        }

        private void ShowFullImage(AnalyseRecord record)
        {
            Image imgFull = null;
            if (pictureEdit1.Image != null)
            {
                Image image = pictureEdit1.Image;
                pictureEdit1.Image = null;
                image.Dispose();
            }
            if (record != null && record.Image != null)
            {
                // 不要与图片控件用同一个图片对象
                // 图片控件上的图片可以自己回收
                imgFull = ResultPageViewModel.DecorateFullImage(record);
            }
            pictureEdit1.Image = imgFull;
            pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Clip;
            if (imgFull != null)
            {
                int x_rate = pictureEdit1.Width * 100 / imgFull.Width;
                int y_rate = pictureEdit1.Height * 100 / imgFull.Height;
                pictureEdit1.Properties.ZoomPercent = Math.Min(x_rate, y_rate);
            }
        }

        internal void ZoomIn()
        {
            pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Clip;
            // ZoomRate = Math.Min((int)(picEditOriginal.Properties.ZoomPercent * 1.2), 1000);
            pictureEdit1.Properties.ZoomPercent = Math.Min((int)(pictureEdit1.Properties.ZoomPercent * 1.2), 1000); ;
        }

        internal void ZoomOut()
        {
            pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Clip;
            // ZoomRate = Math.Max((int)(picEditOriginal.Properties.ZoomPercent / 1.2), 5);
            pictureEdit1.Properties.ZoomPercent = Math.Max((int)(pictureEdit1.Properties.ZoomPercent / 1.2), 5);
        }

        void picEditOriginal_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
                ZoomIn();
            else
                ZoomOut();
        }
        private void simpleButtonPriv_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(vehicleID))
            {
                var tmp = m_viewModel.GetPrivVehicleByID(vehicleID);
                SetVehicle(tmp);
            }
        }

        private void simpleButtonNext_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(vehicleID))
            {
                var tmp = m_viewModel.GetNextVehicleByID(vehicleID);
                SetVehicle(tmp);
            }

        }

        private void simpleButtonClose_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        protected override bool ProcessKeyPreview(ref Message m)
        {
            switch (m.WParam.ToInt32())
            {
                case 37://left
                    simpleButtonPriv.PerformClick();
                    break;
                case 39://right
                    simpleButtonNext.PerformClick();
                    break;
                default:
                    break;
            }
            return base.ProcessKeyPreview(ref m);
        }
    }
}
