using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.VehicleAnalyse.DataModel;

namespace com.VehicleAnalyse.Main.Views
{
    public partial class ucSingleGroupResult : UserControl
    {
        public event EventHandler VehicleClick;
        public event EventHandler ExportClick;

        public List<AnalyseRecord> AnalyseResults { get; set; }

        public VehicleGroupType VehicleGroupType { get; set; }

        private string vehicleGroupID = "";

        public ucSingleGroupResult()
        {
            InitializeComponent();
        }

        internal void SetVehicle(List<AnalyseRecord> tmp)
        {
            if (tmp == null || tmp.Count ==0 )
                Clear();
            else
                Init(tmp);
        }

        private void Clear()
        {
            pictureEdit1.Image = null;
            vehicleGroupID = "";
            labelControlCount.Text =  "0条过车";
        }

        private void Init(List<AnalyseRecord> tmp)
        {
            switch (VehicleGroupType)
            {
                case VehicleGroupType.E_NO_GROUP:
                    break;
                case VehicleGroupType.E_PLATE_GROUP:
                    vehicleGroupID = tmp[0].PlateNumber;
                    break;
                case VehicleGroupType.E_DEVICE_GROUP:
                    break;
                default:
                    break;
            }
            labelControlGroup.Text = vehicleGroupID ;
            pictureEdit1.Image = tmp[0].ThumbImg;
            labelControlCount.Text = tmp.Count + "条过车";
            AnalyseResults = tmp;
        }

        private void labelControlSimilar_Click(object sender, EventArgs e)
        {
            if (VehicleClick != null)
                VehicleClick(this, e);
        }

        private void simpleButtonView_Click(object sender, EventArgs e)
        {
            if (VehicleClick != null)
                VehicleClick(this, e);

        }

        private void simpleButtonExport_Click(object sender, EventArgs e)
        {
            if (ExportClick != null)
                ExportClick(this, e);

        }

    }


}
