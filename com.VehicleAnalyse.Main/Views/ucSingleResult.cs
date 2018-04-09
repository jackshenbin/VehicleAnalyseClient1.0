using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace com.VehicleAnalyse.Main.Views
{
    public partial class ucSingleResult : UserControl
    {
        public event EventHandler VehicleClick;

        private string vehicleID = "";
        public ucSingleResult()
        {
            InitializeComponent();
        }
        
        internal void SetVehicle(DataModel.AnalyseRecord tmp)
        {
            if (tmp == null)
                Clear();
            else
                Init(tmp);
        }

        private void Clear()
        {
            labelControlCam.Text = "";
            labelControlPlate.Text = "";
            labelControlSimilar.Text = "";
            labelControlTime.Text = "";
            pictureEdit1.Image = null;
            vehicleID = "";
        }

        private void Init(DataModel.AnalyseRecord tmp)
        {
            vehicleID = tmp.Id;
            labelControlCam.Text = com.VehicleAnalyse.DataModel.AnalyseRecord.GCDD + "：" + Framework.Environment.GetDeviceName(tmp.DeviceId);
            labelControlPlate.Text = tmp.GetPlateNumber();; 
            labelControlSimilar.Text = tmp.CompareSimilarity.ToString()+"%";
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

            labelControlTime.Text = "过车时间："+tmp.WatchTime.ToString("yyyy-MM-dd HH:mm:ss");
            pictureEdit1.Image = tmp.ThumbImg;
        }

        private void labelControlSimilar_Click(object sender, EventArgs e)
        {
            if (VehicleClick != null)
                VehicleClick(vehicleID, e);
        }
    }
}
