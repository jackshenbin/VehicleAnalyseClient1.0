using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using com.VehicleAnalyse.Main.ViewModels;
using AppUtil.Controls;
using com.VehicleAnalyse.DataModel;

namespace com.VehicleAnalyse.Main.Views
{
    public partial class ucCompareSearchSettingsContainer : DevExpress.XtraEditors.XtraUserControl
    {
        #region Events
        
        public event EventHandler OKClicked;
        public event EventHandler CancelClicked;

        public event EventHandler ToShowPopup;
        public event EventHandler ToHidePopup;

        #endregion

        #region Fields
        

        #endregion

        #region Properties
        public string PlateNo
        {
            get { return comboBoxEditPlateNo.Text + textEditPlateNo.Text; }
            set { if (value.Length >= 7) { comboBoxEditPlateNo.EditValue = value[0]; textEditPlateNo.Text = value.Substring(1); } }
        }
        public int Weight
        {
            get { return sliderWeight.Value; }
            set { sliderWeight.Value  = value;}
        }


        public int ResultCount
        {
            get { return (int)spinEditCount.Value; }
            set { spinEditCount.Value = value; }
        }
        #endregion
        public ucCompareSearchSettingsContainer()
        {
            InitializeComponent();
        }

        #region Private helper functions
        


        private void CustomizeSearchSettings()
        {
        }

        #endregion

        public void Init()
        {
            ResetAll();

        }


        #region Event handlers

        private void ucSearchSettingsContainer_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }
            CustomizeSearchSettings();
        }
      

        #endregion

        internal void ResetAll()
        {

        }

        private void simpleButtonOK_Click(object sender, EventArgs e)
        {
            if (OKClicked != null)
                OKClicked(sender, e);
        }

        private void checkEditVehicle_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkEditVehicle.EditValue != checkEditVehicle.OldEditValue)
            sliderWeight.Value = checkEditVehicle.Checked ? 100 : 0;

            comboBoxEditPlateNo.Enabled = textEditPlateNo.Enabled = checkEditVehicle.Checked;
        }

        private void sliderWeight_ValueChanged(object sender, EventArgs e)
        {
            checkEditVehicle.Checked = (sliderWeight.Value > 0);
            labelControlWeight.Text = sliderWeight.Value.ToString();
        }


        public override string ToString()
        {
            string val="";
            if(checkEditVehicle.Checked)
                val = string.Format("车牌[{0}]优先，权重{1}%，返回{2}条", PlateNo, Weight,ResultCount);
            else
                val = string.Format("返回{2}条", PlateNo, Weight, ResultCount);
            return val;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (CancelClicked != null)
                CancelClicked(sender, e);
        }


        /*
京
沪
津
渝
黑
吉
辽
蒙
冀
新
甘
青
陕
宁
豫
鲁
晋
皖
鄂
湘
苏
川
贵
云
桂
藏
浙
赣
粤
闽
台
琼
澳
港
         */
    }
}
