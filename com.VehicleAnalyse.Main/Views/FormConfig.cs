using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using com.VehicleAnalyse.Main.ViewModels;
using AppUtil;
using log4net;

namespace com.VehicleAnalyse.Main.Views
{
    public partial class FormConfig : DevExpress.XtraEditors.XtraForm
    {
        public FormConfig()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(FormLogin_FormClosing);
        }

        void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void FormConfig_Load(object sender, EventArgs e)
        {
            this.checkedListBoxControl1.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] 
            {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Id", "Id")
            ,new DevExpress.XtraEditors.Controls.CheckedListBoxItem("WatchTime", "过车时间")
            ,new DevExpress.XtraEditors.Controls.CheckedListBoxItem( "PlateNumber"            ,    "车牌号"            )
            ,new DevExpress.XtraEditors.Controls.CheckedListBoxItem( "PlateNumberReliability" ,    "车牌置信度" )
            ,new DevExpress.XtraEditors.Controls.CheckedListBoxItem( "VehicleType"            ,    "车型"            )
            ,new DevExpress.XtraEditors.Controls.CheckedListBoxItem( "CarTypeConf"            ,    "车型置信度"            )
            ,new DevExpress.XtraEditors.Controls.CheckedListBoxItem( "DetailVehicleType"      ,    "车型细分"      )
            ,new DevExpress.XtraEditors.Controls.CheckedListBoxItem( "CarTypeDetailConf"      ,    "车型细分置信度"      )
            ,new DevExpress.XtraEditors.Controls.CheckedListBoxItem( "VehicleColor"           ,    "车身颜色"           )
            ,new DevExpress.XtraEditors.Controls.CheckedListBoxItem( "CarColorConf"           ,    "车身颜色置信度"           )
            ,new DevExpress.XtraEditors.Controls.CheckedListBoxItem( "Brand"                  ,    "品牌"                  )
            ,new DevExpress.XtraEditors.Controls.CheckedListBoxItem( "ManufacturerReliability",    "品牌置信度")
            ,new DevExpress.XtraEditors.Controls.CheckedListBoxItem( "Model"                  ,    "子品牌"                  )
            ,new DevExpress.XtraEditors.Controls.CheckedListBoxItem( "CarLabeDetailConf"      ,    "子品牌置信度"      )
            ,new DevExpress.XtraEditors.Controls.CheckedListBoxItem( "PlateType"              ,    "车牌类型"              )
            ,new DevExpress.XtraEditors.Controls.CheckedListBoxItem( "PlateColor"             ,    "车牌颜色"             )
            ,new DevExpress.XtraEditors.Controls.CheckedListBoxItem( "VehicleDirection"       ,    "车型方向"       )
            ,new DevExpress.XtraEditors.Controls.CheckedListBoxItem( "DriverBelt"             ,    "安全带(主)"             )
            ,new DevExpress.XtraEditors.Controls.CheckedListBoxItem( "DriverIsSafebeltConf"   ,    "安全带(主)置信度"   )
            ,new DevExpress.XtraEditors.Controls.CheckedListBoxItem( "CoDriverBelt"           ,    "安全带(副)"           )
            ,new DevExpress.XtraEditors.Controls.CheckedListBoxItem( "PassengerIsSafebeltCof" ,    "安全带(副)置信度" )
            ,new DevExpress.XtraEditors.Controls.CheckedListBoxItem( "DriverPhoneCall"        ,    "打手机(主)"        )
            ,new DevExpress.XtraEditors.Controls.CheckedListBoxItem( "DriverIsPhoneingConf"   ,    "打手机(主)置信度"   )
            ,new DevExpress.XtraEditors.Controls.CheckedListBoxItem( "DriverShielding"        ,    "遮阳板(主)"        )
            ,new DevExpress.XtraEditors.Controls.CheckedListBoxItem( "DriverIsSunVisorConf"   ,    "遮阳板(主)置信度"   )
            ,new DevExpress.XtraEditors.Controls.CheckedListBoxItem( "CoDriverShielding"      ,    "遮阳板(副)"      )
            ,new DevExpress.XtraEditors.Controls.CheckedListBoxItem( "PassengerIsSunVisorConf",    "遮阳板(副)置信度")
            ,new DevExpress.XtraEditors.Controls.CheckedListBoxItem( "ConsoleIsSomething"     ,    "中控台杂物"     )
            ,new DevExpress.XtraEditors.Controls.CheckedListBoxItem( "ConsoleIsSomethingCof"  ,    "中控台杂物置信度"  )
            ,new DevExpress.XtraEditors.Controls.CheckedListBoxItem( "IsPendant"              ,    "挂饰物"              )
            ,new DevExpress.XtraEditors.Controls.CheckedListBoxItem( "IsPendantCof"           ,    "挂饰物置信度"           )
            ,new DevExpress.XtraEditors.Controls.CheckedListBoxItem( "AILabel"           ,    "年检标"           )
            ,new DevExpress.XtraEditors.Controls.CheckedListBoxItem( "FileName"               ,    "文件名"               )
            ,new DevExpress.XtraEditors.Controls.CheckedListBoxItem( "FullName"               ,    "文件全路径"               )
            });

            string columns = Framework.Environment.CutomizeResultListColumns;
            for (int i = 0; i < columns.Length; i++)
            {
                checkedListBoxControl1.SetItemChecked(i, columns[i] == '1');
            }


            spinEditRealTimeTaskSendCount.Value = Framework.Environment.RealTimeTaskSendCount;
            textEditCutomizeTitle.Text = Framework.Environment.CustomTitle;
            checkEditShowPeopleImg.Checked = Framework.Environment.ShowPeopleImg;
            checkEditResultExportAsXls.Checked = Framework.Environment.ResultExportAsXls;
            checkEditDrawVehicleRect.Checked = Framework.Environment.DrawVehicleRect;
            checkEditDrawPlateRect.Checked = Framework.Environment.DrawPlateRect;
            checkEditDrawAILabelRect.Checked = Framework.Environment.DrawAILabelRect;
            switchButtonRealTimeVersion.Value = Framework.Environment.RealTimeVersion;

            checkEditURLEncodingType.Checked = Framework.Environment.URLEncodingType == AppUtil.Common.UrlEncodeUtil.EncodingType.UTF8;

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < checkedListBoxControl1.ItemCount; i++)
            {
                sb.Append(checkedListBoxControl1.GetItemChecked(i)?"1":"0");
            }
            Framework.Environment.CutomizeResultListColumns = sb.ToString();
            Framework.Environment.RealTimeTaskSendCount = (int)spinEditRealTimeTaskSendCount.Value;
            Framework.Environment.CustomTitle = textEditCutomizeTitle.Text;
            Framework.Environment.ShowPeopleImg = checkEditShowPeopleImg.Checked;
            Framework.Environment.ResultExportAsXls = checkEditResultExportAsXls.Checked ;
            Framework.Environment.DrawVehicleRect = checkEditDrawVehicleRect.Checked;
            Framework.Environment.DrawPlateRect = checkEditDrawPlateRect.Checked;
            Framework.Environment.DrawAILabelRect = checkEditDrawAILabelRect.Checked;
            Framework.Environment.RealTimeVersion = switchButtonRealTimeVersion.Value;
            Framework.Environment.URLEncodingType = checkEditURLEncodingType.Checked ? AppUtil.Common.UrlEncodeUtil.EncodingType.UTF8 : AppUtil.Common.UrlEncodeUtil.EncodingType.GBK;

            Framework.Environment.SaveConfig();
        }

        private void simpleButtonAllOn_Click(object sender, EventArgs e)
        {
            checkedListBoxControl1.CheckAll();
        }

        private void simpleButtonAllOff_Click(object sender, EventArgs e)
        {
            checkedListBoxControl1.UnCheckAll();
        }

        private void simpleButtonDefault_Click(object sender, EventArgs e)
        {
            string columns = "0110101010101011010001010001010100";
            for (int i = 0; i < columns.Length; i++)
            {
                checkedListBoxControl1.SetItemChecked(i, columns[i] == '1');
            }

        }

        private void simpleButtonAllDefault_Click(object sender, EventArgs e)
        {
            simpleButtonDefault_Click(sender, e);


            spinEditRealTimeTaskSendCount.Value = 10;
            textEditCutomizeTitle.Text = "二次识别标准版客户端 V3.0";
            checkEditShowPeopleImg.Checked = false;
            checkEditResultExportAsXls.Checked = false;
            checkEditDrawVehicleRect.Checked = true;
            checkEditDrawPlateRect.Checked = true;
            checkEditDrawAILabelRect.Checked = false;
            switchButtonRealTimeVersion.Value = false ;
            checkEditURLEncodingType.Checked = true;
        }



    }
}