using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using com.VehicleAnalyse.Main.ViewModels;
using System.Diagnostics;
using com.VehicleAnalyse.DataModel;
using com.VehicleAnalyse.Service.DAO;
using com.VehicleAnalyse.Main.Framework;
using AppUtil;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraBars;
using VehicleHelper.DataModel;


namespace com.VehicleAnalyse.Main.Views
{
    public partial class ucResultPage : DevExpress.XtraEditors.XtraUserControl
    {
        #region Fields

        private ResultPageViewModel m_ViewModel;

        private bool m_popupClosed = true;

        private LabelControl[] m_labelCtrlsSetting;
        private LabelControl[] m_labelCtrlsSettingValue;


        #endregion

        public ucResultPage()
        {
            InitializeComponent();

            CustomizeColumns();
            this.HandleDestroyed += new EventHandler(ucResultPage_HandleDestroyed);
        }

        void ucResultPage_HandleDestroyed(object sender, EventArgs e)
        {
            //if (ucSearchSettings1 != null)
            //{
            //    this.ucSearchSettings1.SearchClicked -= new EventHandler(ucSearchSettings1_SearchClicked);
            //    this.ucSearchSettings1.CancelClicked -= new EventHandler(ucSearchSettings1_CancelClicked);
            //    this.ucSearchSettings1.ToShowPopup -= new EventHandler(ucSearchSettings1_OnToShow);
            //    this.ucSearchSettings1.ToHidePopup -= new EventHandler(ucSearchSettings1_OnToHide);
            //}
            if (m_ViewModel != null)
            {
                m_ViewModel.PreNewSearch -= ViewModel_PreNewSearch;
                m_ViewModel.SearchResult -= new EventHandler(ViewModel_SearchResult);
            }
        }

        #region Private 
        
        private void CustomizeColumns()
        {
            if (!string.IsNullOrEmpty(Framework.Environment.CutomizeResultListColumns))
            {
                for (int i = 0; i < Framework.Environment.CutomizeResultListColumns.Length; i++)
                {
                    if (i > this.gridViewResults.Columns.Count -1)
                    {
                        break;
                    }
                    if (Framework.Environment.CutomizeResultListColumns[i] == '1')
                    {
                        this.gridViewResults.Columns[i].Visible = true;
                        this.gridView1.Columns[i].Visible = true;
                    }
                    else
                    {
                        this.gridViewResults.Columns[i].Visible = false;
                        this.gridView1.Columns[i].Visible = false;
                        MyLog4Net.Container.Instance.Log.InfoFormat("Result list column '{0}' hide", this.gridViewResults.Columns[i].Caption);
                    }
                }
            }



        }

        private Image CutVehicleImage(AnalyseRecord record)
        {
            Image image = m_ViewModel.GetImage(record); // Image.FromFile(record.PicId);

            Rectangle cutRect = new Rectangle();
            if (image != null && record.PlateRegion != Rectangle.Empty)
                cutRect = record.PlateRegion;
            else if (image != null && record.VehicleRegion != Rectangle.Empty)
                cutRect = record.VehicleRegion;

            if (image != null && cutRect != Rectangle.Empty)
            {
                int xOffset1 = 10, xOffset2 = 10, yOffset1 = 10, yOffset2 = 10;
                if (cutRect.X < 10)
                {
                    xOffset1 = cutRect.X;
                }
                if (cutRect.Y < 10)
                {
                    yOffset1 = cutRect.Y;
                }

                int temp = image.Width - cutRect.X - cutRect.Width;
                if (temp < 10)
                {
                    xOffset2 = temp;
                }

                temp = image.Height - cutRect.Y - cutRect.Height;
                if (temp < 10)
                {
                    yOffset2 = temp;
                }

                int Height = cutRect.Height + yOffset1 + yOffset2;
                int Width = cutRect.Width + xOffset1 + xOffset2;

                Rectangle rect = new Rectangle(cutRect.X - xOffset1, cutRect.Y - yOffset1, Width, Height);

                Bitmap imgPlate = new Bitmap(Width, Height);
                Graphics g = Graphics.FromImage(imgPlate);
                g.DrawImage(image, new Rectangle(0, 0, Width, Height), rect, GraphicsUnit.Pixel);
                g.Dispose();

                image = imgPlate;
            }

            return image;
        }

        private void UpdateUI()
        {
            AnalyseRecord record = m_ViewModel.SelectedAnalyseRecord;
            if (record != null)
            {
                new System.Threading.Thread(thDoUpdateImage).Start(record);
            }
            gridControl2.DataSource = m_ViewModel.DTSummary;
        }

        void thDoUpdateImage(object o)
        {
            if (o is AnalyseRecord)
                UpdateImage(o as AnalyseRecord);
        }

        void UpdateImage(AnalyseRecord record)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<AnalyseRecord>(UpdateImage), record);
            }
            else
            {
                Application.DoEvents();
                
                Trace.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss,fff") + " UpdateImage 1");
                ShowPlateImage(record);
                ShowFullImage(record);
                ShowVehicleStandardImage(record);
                Trace.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss,fff") + " UpdateImage 2");
            }
        }

        private void ShowFullImage(AnalyseRecord record)
        {
            //Image imgFull = null;
            //if( record != null && record.Image != null)
            //{
            //    // 不要与图片控件用同一个图片对象
            //    // 图片控件上的图片可以自己回收
            //    imgFull = ResultPageViewModel.DecorateFullImage(record);
            //}
            //picEditOriginal.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            //picEditOriginal.Image = imgFull;
            ucResultImage1.ShowImage(record);
        }

        private void ShowPlateImage(AnalyseRecord record)
        {
            Image image = null;
            if (record != null)
            {
                try
                {
                    image = CutVehicleImage(record);  //Image.FromFile(record.PicId);
                }catch(ArgumentException ex)
                {

                }
            }
            this.picEditThumb.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            picEditThumb.Image = image;
        }

        private void ShowVehicleStandardImage(AnalyseRecord record)
        {

                VehicleBrandInfo brand = record.BrandInfo  as VehicleBrandInfo;
                VehicleBrandInfo parbrand = record.ParentBrandInfo  as VehicleBrandInfo;
            if (brand != null)
            {
                if(parbrand!=null)
                    lblCtrlVehicleModel.Text = string.Format("{0} {1}", parbrand.Name, brand.Name);
                else
                    lblCtrlVehicleModel.Text = string.Format("{0}",  brand.Name);

                Image imgTmp = picEditStandard.Image;
                picEditStandard.Image = null;
                if (imgTmp != null)
                {
                    imgTmp.Dispose();
                }
                picEditStandard.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
                Image temp = null;
                if ((byte)this.radioGroup1.EditValue == 0)
                {
                    if (brand.Front != null)
                    {
                        System.IO.MemoryStream ms = new System.IO.MemoryStream(brand.Front);
                        try
                        {
                            temp = System.Drawing.Image.FromStream(ms);
                        }
                        catch (ArgumentException aex)
                        {
                            temp = null;
                        }
                    }
                }
                else
                {
                    if (brand.Back != null)
                    {
                        System.IO.MemoryStream ms = new System.IO.MemoryStream(brand.Back);
                        try
                        {
                            temp = System.Drawing.Image.FromStream(ms);
                        }
                        catch (ArgumentException aex)
                        {
                            temp = null;
                        }
                    }
                }
                //Image temp =((byte)radioGroup1.EditValue == 0)?brand.Front:brand.Back;

                picEditStandard.Image = temp == null?null:(Image)temp.Clone();

                picEditStandard.ToolTip = string.Format("车型编号: {1}, 名称: {0}",
                    brand.Name, brand.ID);
            }
            else
            {
                lblCtrlVehicleModel.Text = string.Empty;
                picEditStandard.Image = null;

                picEditStandard.ToolTip = string.Empty;
            }
        }

        private void DisplayVehicleModelSettings(string text)
        {
            // lblCtrlModel.ToolTip = text;
            int width = this.flowLayoutPanel3.Width - labelControl车型号.Right - 15;
            if (width > 0)
            {
                lblCtrlModelValue.Width = width;
            }
            else
            {
                lblCtrlModelValue.Width = 0;
            }
        }

        private void DisplaySearchSetting(int index, string[] settings)
        {
            if (settings == null || index >= settings.Length)
            {
                m_labelCtrlsSetting[index].Hide();
                m_labelCtrlsSettingValue[index].Hide();
            }
            else
            {
                if (!string.IsNullOrEmpty(settings[index]) &&
                    string.CompareOrdinal("不限", settings[index]) != 0)
                {
                    m_labelCtrlsSettingValue[index].Text = settings[index];
                    m_labelCtrlsSetting[index].Show();
                    m_labelCtrlsSettingValue[index].Show();
                    if (index == m_labelCtrlsSettingValue.Length - 1)
                    {
                        m_labelCtrlsSettingValue[index].ToolTip = settings[index];
                        DisplayVehicleModelSettings(settings[index]);
                        //string text = settings[index];
                        //Font font = m_labelCtrlsSettingValue[index].Font;
                        //Size size;
                        //size = TextRenderer.MeasureText(text, font);
                        //if (size.Width > width)
                        //{
                        //    while (true)
                        //    {
                        //        text = text.Substring(0, text.Length - 5);
                        //        size = TextRenderer.MeasureText(string.Format("{0} ...", text), font);
                        //        if (size.Width <= width)
                        //        {
                        //            m_labelCtrlsSettingValue[index].Text = string.Format("{0} ...", text);
                        //            break;
                        //        }
                        //    }
                        //}
                    }
                }
                else
                {
                    m_labelCtrlsSetting[index].Hide();
                    m_labelCtrlsSettingValue[index].Hide();
                }
            }
        }

        //internal void ZoomIn()
        //{
        //    picEditOriginal.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Clip;
        //    // ZoomRate = Math.Min((int)(picEditOriginal.Properties.ZoomPercent * 1.2), 1000);
        //    picEditOriginal.Properties.ZoomPercent = Math.Min((int)(picEditOriginal.Properties.ZoomPercent * 1.2), 1000); ;
        //}

        //internal void ZoomOut()
        //{
        //    picEditOriginal.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Clip;
        //    // ZoomRate = Math.Max((int)(picEditOriginal.Properties.ZoomPercent / 1.2), 5);
        //    picEditOriginal.Properties.ZoomPercent = Math.Max((int)(picEditOriginal.Properties.ZoomPercent / 1.2), 5); 
        //}

        private void EnableEdit(bool enable)
        {
            gridViewResults.OptionsBehavior.Editable = enable;
            foreach (GridColumn gridColumn in gridViewResults.Columns)
            {
                if(gridColumn != columnFileName && 
                    gridColumn != columnFullName)
                {
                    // 文件名不允许编辑
                    gridColumn.OptionsColumn.AllowEdit = enable;
                    gridColumn.OptionsColumn.ReadOnly = !enable;
                }
                else
                {
                    gridColumn.OptionsColumn.AllowEdit = false;
                    gridColumn.OptionsColumn.ReadOnly = true;
                }
            }
        }

        private void InitRepositoryItemCtrls()
        {
            rptItemCmbBoxVehicleType.Items.AddRange(Constant.PropertyInfo_VehicleType);
            rptItemCmbBoxVehicleDetailType.Items.AddRange(Constant.PropertyInfo_VehicleType);
            rptItemCmbBoxVehicleColor.Items.AddRange(Constant.PropertyInfo_VehicleColor);
            rptItemCmbBoxPlateColor.Items.AddRange(Constant.PropertyInfo_PlateColor);
            rptItemCmbBoxVehicleDirection.Items.AddRange(Constant.PropertyInfo_VehicleDirection);
            rptItemCmbBoxConsoleIsSomething.Items.AddRange(Constant.PropertyInfo_SunlightShielding);
            rptItemCmbBoxIsPendant.Items.AddRange(Constant.PropertyInfo_SunlightShielding);
            rptItemCmbBoxDriverBelt.Items.AddRange(Constant.PropertyInfo_SafeBeltWear);

            rptItemCmbBoxCoDrvierBelt.Items.AddRange(Constant.PropertyInfo_SafeBeltWear);

            rptItemCmbBoxDriverPhonecall.Items.AddRange(Constant.PropertyInfo_PhoneCalling);

            rptItemCmbboxShielding.Items.AddRange(Constant.PropertyInfo_SunlightShielding);

            rptItemCmbBoxBrand.Items.Add(Constant.PropertyInfo_UNKNOWN);
            //List<ModelPropertyInfo> brandInfos = Framework.Container.Instance.TaskManager.GetAllRootBrandModelInfos();
            //if(brandInfos != null)
            //{
            //    foreach(ModelPropertyInfo mpi in brandInfos)
            //    {
            //        rptItemCmbBoxBrand.Items.Add(mpi);
            //    }
            //}

            List<VehiclePropertyInfo> modelInfos = new List<VehiclePropertyInfo>();
            modelInfos.Add(Constant.PropertyInfo_UNKNOWN);
            repositoryItemLookUpEdit1.DataSource = modelInfos;
            rptItemCmbBoxVehicleModel.Items.Add(Constant.PropertyInfo_UNKNOWN);
            
            rptItemCmbBoxBrand.SelectedIndexChanged += rptItemCmbBoxBrand_SelectedIndexChanged;
            rptItemCmbBoxVehicleModel.SelectedIndexChanged += rptItemCmbBoxVehicleType_SelectedIndexChanged;
            rptItemCmbBoxVehicleDetailType.SelectedIndexChanged += rptItemCmbBoxVehicleType_SelectedIndexChanged;
            rptItemCmbBoxVehicleType.SelectedIndexChanged += rptItemCmbBoxVehicleType_SelectedIndexChanged;
            
            rptItemCmbBoxVehicleColor.SelectedIndexChanged += rptItemCmbBoxVehicleType_SelectedIndexChanged;
            rptItemCmbBoxPlateColor.SelectedIndexChanged += rptItemCmbBoxVehicleType_SelectedIndexChanged;
            rptItemCmbBoxDriverBelt.SelectedIndexChanged += rptItemCmbBoxVehicleType_SelectedIndexChanged;
            rptItemCmbBoxDriverPhonecall.SelectedIndexChanged += rptItemCmbBoxVehicleType_SelectedIndexChanged;
            rptItemCmbBoxCoDrvierBelt.SelectedIndexChanged += rptItemCmbBoxVehicleType_SelectedIndexChanged;
            rptItemCmbboxShielding.SelectedIndexChanged += new EventHandler(rptItemCmbboxShielding_SelectedIndexChanged);
            repositoryItemTextEdit1.EditValueChanged += repositoryItemTextEdit1_EditValueChanged;
            
        }

        void rptItemCmbboxShielding_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btnSave.Enabled = true;
        }

        void repositoryItemTextEdit1_EditValueChanged(object sender, EventArgs e)
        {
            this.btnSave.Enabled = true;
        }

        void rptItemCmbBoxVehicleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btnSave.Enabled = true;
        }

        private void FillupVehicleModels()
        {
            DataRow row = this.gridViewResults.GetFocusedDataRow();
            if (row != null)
            {
                //ModelPropertyInfo brand = row["Brand"] as ModelPropertyInfo;
                //VehicleBrand[] models = Framework.Container.Instance.TaskManager.GetChildBrands(brand.ID);
                //rptItemCmbBoxVehicleModel.Items.Clear();
                
                //if (models != null)
                //{
                //    rptItemCmbBoxVehicleModel.Items.Add(Constant.PropertyInfo_UNKNOWN);
                //    ModelPropertyInfo mpi;
                //    foreach (VehicleBrand model in models)
                //    {
                //        mpi = new ModelPropertyInfo() { ID = (int)model.Id, Name = model.Name };
                //        rptItemCmbBoxVehicleModel.Items.Add(mpi);
                //    }
                //}
                //else
                //{
                //    // 子品牌与父品牌使用同一个
                //    rptItemCmbBoxVehicleModel.Items.Add(brand);
                //}
            }
        }

        void rptItemCmbBoxBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxEdit comboCtrl = ((ComboBoxEdit)sender);
            if (comboCtrl.SelectedIndex > -1)
            {
                this.btnSave.Enabled = true;
                this.gridViewResults.GetFocusedDataRow()["Brand"] = ((ComboBoxEdit)sender).SelectedItem;
                FillupVehicleModels();
                if (rptItemCmbBoxVehicleModel.Items != null && rptItemCmbBoxVehicleModel.Items.Count > 0)
                {
                    this.gridViewResults.GetFocusedDataRow()["Model"] = rptItemCmbBoxVehicleModel.Items[0];
                    gridViewResults.SetFocusedRowCellValue(this.columnModel, rptItemCmbBoxVehicleModel.Items[0]);
                }
            }
        }


        #endregion

        #region Event handlers

        void ucSearchSettings1_CancelClicked(object sender, EventArgs e)
        {
            this.popupControlContainer1.Hide();
        }

        void ucSearchSettings1_OnToHide(object sender, EventArgs e)
        {
            // this.popupControlContainer1.HidePopup();
            //this.popupControlContainer1.Manager = null;
            //this.popupControlContainer1.CloseOnLostFocus = false;
            //this.popupControlContainer1.CloseOnOuterMouseClick = false;
            //this.popupControlContainer1.Show();
        }

        void ucSearchSettings1_OnToShow(object sender, EventArgs e)
        {
            //if (m_popupClosed)
            //{
            //    Point p = new Point(btnShowSettings.Left, btnShowSettings.Bottom);
            //    p = this.PointToScreen(p);
            //    this.popupControlContainer1.ShowPopup(this.barManager1, p);
            //    popupControlContainer1.Show();
            //    m_popupClosed = false;
            //}
            //this.popupControlContainer1.Manager = this.barManager1;
            //this.popupControlContainer1.CloseOnLostFocus = true;
            //this.popupControlContainer1.CloseOnOuterMouseClick = true;
            //this.Focus();

        }

        void ucSearchSettings1_SearchClicked(object sender, EventArgs e)
        {
            this.popupControlContainer1.Hide();
        }

        private void btnShowSettings_Click(object sender, EventArgs e)
        {
            //if (m_popupClosed)
            //{
            //    Point p = new Point(btnShowSettings.Left, btnShowSettings.Bottom);
            //    p = this.PointToScreen(p);
            //    this.popupControlContainer1.ShowPopup(this.barManager1, p);
            //    popupControlContainer1.Show();
            //    m_popupClosed = false;
            //}
            popupControlContainer1.BringToFront();
            popupControlContainer1.Show();
            ucSearchSettings1.Focus();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.popupControlContainer1.Hide();
        }

        private void ucResultPage_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                m_ViewModel = new ResultPageViewModel();
                m_ViewModel.PreNewSearch += ViewModel_PreNewSearch;
                m_ViewModel.SearchResult += new EventHandler(ViewModel_SearchResult);

                Framework.Container.Instance.VVMDataBindings.AddBinding(this.lblCtrlFileName, "Text", m_ViewModel, "FileName");

                Framework.Container.Instance.VVMDataBindings.AddBinding(this.chkBoxEdit, "Visible", m_ViewModel, "CanRevise");
                Framework.Container.Instance.VVMDataBindings.AddBinding(this.btnSave, "Visible", m_ViewModel, "CanRevise");

                gridControlResults.DataSource = m_ViewModel.DTAnalyseResults;

                m_labelCtrlsSetting = new LabelControl[]{
                    this.labelControl检索范围, 
                    this.labelControl时间范围, 
                    this.labelControl车牌, 
                    this.labelControl车辆细分, 
                    this.labelControl车身颜色, 
                    this.labelControl车牌颜色, 
                    this.labelControl安全带, 
                    this.labelControl车型号
                };

                m_labelCtrlsSettingValue = new LabelControl[]{
                    this.labelControl3,
                    this.labelControl10,
                    this.labelControl13,
                    this.labelControl15,
                    this.labelControl21,
                    this.labelControl23,
                    this.labelControl25,
                    this.lblCtrlModelValue
                };
                this.ucSearchSettings1 = new com.VehicleAnalyse.Main.Views.ucSearchSettings();
                // ucSearchSettings1
                // 
                this.ucSearchSettings1.Location = new System.Drawing.Point(3, 3);
                this.ucSearchSettings1.Name = "ucSearchSettings1";
                this.ucSearchSettings1.Size = new System.Drawing.Size(222, 470);
                this.ucSearchSettings1.TabIndex = 0;
                this.ucSearchSettings1.Dock = System.Windows.Forms.DockStyle.Fill;
                // 
                this.ucSearchSettings1.SearchClicked += new EventHandler(ucSearchSettings1_SearchClicked);
                this.ucSearchSettings1.CancelClicked += new EventHandler(ucSearchSettings1_CancelClicked);
                this.ucSearchSettings1.ToShowPopup += new EventHandler(ucSearchSettings1_OnToShow);
                this.ucSearchSettings1.ToHidePopup += new EventHandler(ucSearchSettings1_OnToHide);

                this.popupControlContainer1.Controls.Add(this.ucSearchSettings1);
                if (!Framework.Environment.RealTimeVersion)
                {
                    this.popupControlContainer1.Height -= 50;
                    this.ucSearchSettings1.Height -= 50;
                }
            }
            // columnDriverPhoneCall.Visible = Framework.Environment.PhoneCallFeature;
            // this.gridView1.Columns[columnDriverPhoneCall.AbsoluteIndex].Visible = Framework.Environment.PhoneCallFeature;
            ucResultImage1.Reset();
            InitRepositoryItemCtrls();
        }

        void ViewModel_PreNewSearch(Dictionary<string, string> settings)
        {
            if (m_ViewModel.ResultPageInfo != null)
            {
                Framework.Container.Instance.VVMDataBindings.RemoveBinding(m_ViewModel.ResultPageInfo, "PageIndex", this.comboBoxPage);

                Framework.Container.Instance.VVMDataBindings.RemoveBinding(m_ViewModel.ResultPageInfo, "TotalRecords", this.lblCount);

                Framework.Container.Instance.VVMDataBindings.RemoveBinding(m_ViewModel.ResultPageInfo, "PageCount", this.lblControlPageCount);

                Framework.Container.Instance.VVMDataBindings.RemoveBinding(m_ViewModel.ResultPageInfo, "CurrentPageCount", this.lblCtrlCurrentPageCount);

                Framework.Container.Instance.VVMDataBindings.RemoveBinding(m_ViewModel.ResultPageInfo, "CanNextPage", this.btnNextPage);

                Framework.Container.Instance.VVMDataBindings.RemoveBinding(m_ViewModel.ResultPageInfo, "CanPrePage", this.btnPrePage);

                this.comboBoxPage.Properties.Items.Clear();
            }
            // this.picEditOriginal.Image = null;
            this.ucResultImage1.Reset();

            this.picEditThumb.Image = null;
            this.picEditStandard.Image = null;

            //for (int i = 0; i < m_labelCtrlsSetting.Length; i++ )
            //{
            //    DisplaySearchSetting(i, settings);
            //}

            StringBuilder sb = new StringBuilder();
            foreach (var item in settings)
	        {
		        if(item.Value == "不限")
                    continue;
                if (item.Key.Contains("过车位置"))
                {
                    string cams = "";
                    foreach (string cam in item.Value.Split(','))
                    {
                        cams +=Framework.Environment.GetDeviceName(cam)+",";
                    }
                    sb.Append(item.Key + cams.TrimEnd(',') + "；");
                }
                else
                    sb.Append(item.Key+item.Value+"；");
	        }
            lblCtrlSettings.Text = sb.ToString();

        }

        void ViewModel_SearchResult(object sender, EventArgs e)
        {
            Debug.Assert(m_ViewModel.ResultPageInfo != null);
            Trace.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss,fff") + " ViewModel_SearchResult 1");
            this.comboBoxPage.Properties.Items.AddRange(m_ViewModel.ResultPageInfo.GetPageIds());

            Framework.Container.Instance.VVMDataBindings.AddBinding(this.comboBoxPage,
           "SelectedIndex", m_ViewModel.ResultPageInfo, "PageIndex");

            Framework.Container.Instance.VVMDataBindings.AddBinding(this.lblCount,
         "Text", m_ViewModel.ResultPageInfo, "TotalRecords"); 

            Framework.Container.Instance.VVMDataBindings.AddBinding(this.lblControlPageCount,
          "Text", m_ViewModel.ResultPageInfo, "PageCount");

            Framework.Container.Instance.VVMDataBindings.AddBinding(this.lblCtrlCurrentPageCount,
            "Text", m_ViewModel.ResultPageInfo, "CurrentPageCount");

            Framework.Container.Instance.VVMDataBindings.AddBinding(this.btnNextPage,
           "Enabled", m_ViewModel.ResultPageInfo, "CanNextPage");

            Framework.Container.Instance.VVMDataBindings.AddBinding(this.btnPrePage,
          "Enabled", m_ViewModel.ResultPageInfo, "CanPrePage");

            this.btnSave.Enabled = false;
            Trace.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss,fff") + " ViewModel_SearchResult 2");
            AdjustIndicatorColumnWidth();
            panelControl2_SizeChanged(null, EventArgs.Empty);
            Trace.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss,fff") + " ViewModel_SearchResult 3");
        }

        private void AdjustIndicatorColumnWidth()
        {
            int lastNO = m_ViewModel.ResultPageInfo.StartRecordIndex + m_ViewModel.ResultPageInfo.CurrentPageCount + 1;
            int length = lastNO.ToString().Length;
            // 用相同位数， 全是 8 计算显示宽度
            string s = new string('8', length);
            Size size = TextRenderer.MeasureText(s, gridViewResults.Appearance.GroupPanel.Font);
            gridViewResults.IndicatorWidth = size.Width + 17;
        }

        private void gridViewResults_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRowView rowView = gridViewResults.GetRow(e.FocusedRowHandle) as DataRowView;
            AnalyseRecord record = null;
            if (rowView != null)
            {
                record = rowView["AnalyseRecord"] as AnalyseRecord;
            }
            m_ViewModel.SelectedAnalyseRecord = record;

            UpdateUI();
            FillupVehicleModels();
        }
        
        private void btnPrePage_Click(object sender, EventArgs e)
        {
            m_ViewModel.TurnPrePage();
            AdjustIndicatorColumnWidth();
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            m_ViewModel.TurnNextPage();
            AdjustIndicatorColumnWidth();
        }

        private void comboBoxPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_ViewModel.ResultPageInfo != null)
            {
                m_ViewModel.ResultPageInfo.PageIndex = comboBoxPage.SelectedIndex;
                AdjustIndicatorColumnWidth();
            }
            // m_FirstTimeZeroPageIndexSelected = false;    
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0 && m_ViewModel != null && m_ViewModel.ResultPageInfo != null)
            {
                int index = m_ViewModel.ResultPageInfo.StartRecordIndex + e.RowHandle + 1;
                e.Info.DisplayText = index.ToString();
            }
        }
        
        private void btnShowSettings_MouseEnter(object sender, EventArgs e)
        {
            //popupControlContainer1.Visible = true;
            //popupControlContainer1.ShowPopup(new Point(btnShowSettings.Left, btnShowSettings.Bottom));
        }

        private void btnShowSettings_MouseLeave(object sender, EventArgs e)
        {
            // popupControlContainer1.Hide();
        }

        private void popupControlContainer1_CloseUp(object sender, EventArgs e)
        {
            this.m_popupClosed = true;
        }

        //void picEditOriginal_MouseWheel(object sender, MouseEventArgs e)
        //{
        //    if (e.Delta > 0)
        //        ZoomIn();
        //    else
        //        ZoomOut();
        //}
        
        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowVehicleStandardImage(m_ViewModel.SelectedAnalyseRecord);
        }

        private void popupControlContainer1_Leave(object sender, EventArgs e)
        {
            popupControlContainer1.Hide();
        }

        private void panelControl2_SizeChanged(object sender, EventArgs e)
        {
            this.flowLayoutPanel2.Width = chkBoxEdit.Left - 40;
            //if(labelControl7.Right < flowLayoutPanel2.Width)
            //{
            //    btnSort.Left = labelControl7.Right + 10;
            //}
            //else
            //{
            //    btnSort.Left = flowLayoutPanel2.Right + 5;
            //}
            //if(btnSort.Left > chkBoxEdit.Left - 20)
            //{
            //    btnSort.Hide();
            //}
            //else
            //{
            //    btnSort.Show();
            //}
        }

        private void flowLayoutPanel3_SizeChanged(object sender, EventArgs e)
        {
            if (labelControl车型号.Visible)
            {
                DisplayVehicleModelSettings(lblCtrlModelValue.ToolTip);
            }
        }

        private void checkEditBatch_CheckedChanged(object sender, EventArgs e)
        {
            // btnSave.Enabled = chkBoxEdit.Checked;
            EnableEdit(chkBoxEdit.Checked);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                m_ViewModel.Save();
                Framework.Container.Instance.InteractionService.ShowMessageBox("保存记录成功");
                this.btnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                MyLog4Net.Container.Instance.Log.Error("保存记录出错", ex);
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            popupMenu1.ShowPopup(Control.MousePosition);
        }

        private void groupControl3_SizeChanged(object sender, EventArgs e)
        {
            this.picEditStandard.Location = new Point(2, panelControl3.Bottom + 1);
            this.picEditStandard.Width = groupControl3.Width - 4;
            this.picEditStandard.Height = groupControl3.Height - panelControl3.Bottom - 2;
        }

        private void rptItemCmbBoxBrand_Validating(object sender, CancelEventArgs e)
        {
            ComboBoxEdit comboCtrl = (ComboBoxEdit)sender;
            if (comboCtrl.SelectedIndex < 0 && comboCtrl.Properties.Items != null && comboCtrl.Properties.Items.Count > 0)
            {
                string text = comboCtrl.Text;
                if (text != null)
                {
                    text = text.Trim();
                }

                if (string.IsNullOrEmpty(text))
                {
                    comboCtrl.SelectedItem = comboCtrl.Properties.Items[0];
                    return;
                }
                else
                {
                    foreach (object item in comboCtrl.Properties.Items)
                    {
                        if (string.Compare(text, item.ToString(), true) == 0)
                        {
                            comboCtrl.SelectedItem = item;
                            return;
                        }
                    }
                }

                Framework.Container.Instance.InteractionService.ShowMessageBox("输入的车品牌无效");
                e.Cancel = true;
            }
        }

        private void rptItemCmbBoxVehicleModel_Validating(object sender, CancelEventArgs e)
        {
            ComboBoxEdit comboCtrl = (ComboBoxEdit)sender;
            if (comboCtrl.SelectedIndex < 0 && comboCtrl.Properties.Items != null && comboCtrl.Properties.Items.Count > 0)
            {
                string text = comboCtrl.Text;
                if (text != null)
                {
                    text = text.Trim();
                }

                if (string.IsNullOrEmpty(text))
                {
                    comboCtrl.SelectedItem = comboCtrl.Properties.Items[0];
                    return;
                }
                else
                {
                    foreach (object item in comboCtrl.Properties.Items)
                    {
                        if (string.Compare(text, item.ToString(), true) == 0)
                        {
                            comboCtrl.SelectedItem = item;
                            return;
                        }
                    }
                }

                Framework.Container.Instance.InteractionService.ShowMessageBox("输入的车型号无效");
                e.Cancel = true;
            }
        }
       
        private void gridControlResults_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && m_ViewModel.HasResult)
            {
                popupMenuGrid.ShowPopup(Cursor.Position);
            }
        }

        private void GetExportMode(out bool includeDiagram, out bool includePic)
        {
            short nVal = (short)checkEditExportIncludePics.EditValue;
            includeDiagram = (nVal == 1 || nVal == 2);
            includePic = (nVal == 1 || nVal == 3);
        }

        private string GetExportPath(bool includeDiagram, bool includePic)
        {
            string path = string.Empty;
            if (includeDiagram)
            {
                using (SaveFileDialog dlg = new SaveFileDialog())
                {
                    dlg.Filter = Framework.Environment.ResultExportAsXls ? "*.xls|*.xls" : "*.csv|*.csv";
                    if (DialogResult.OK == dlg.ShowDialog())
                    {
                        path = dlg.FileName;
                    }
                }
            }
            else if(includePic)
            {
                using (FolderBrowserDialog dlg = new FolderBrowserDialog())
                {
                    if (DialogResult.OK == dlg.ShowDialog())
                    {
                        path = dlg.SelectedPath;
                    }
                }
            }
            return path;
        }

        private void barBtnItemExportSelectedItems_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int[] ids = gridViewResults.GetSelectedRows();
            if (ids == null || ids.Length < 1)
            {
                return;
            }

            bool includeDiagram = true, includePic = true;
            GetExportMode(out includeDiagram, out includePic);
            string path = GetExportPath(includeDiagram, includePic);

            if(string.IsNullOrEmpty(path))
            {
                return;
            }

            List<AnalyseRecord> records = new List<AnalyseRecord>();
            foreach (int id in ids)
            {
                DataRow row = gridViewResults.GetDataRow(id);
                records.Add(row["AnalyseRecord"] as AnalyseRecord);
            }
            
            try
            {
                m_ViewModel.Export(gridControlForExportAll, path, records, includeDiagram, includePic);

                Framework.Container.Instance.EvtAggregator.GetEvent<AnalyseMessageEvent>().Publish(
                    new Tuple<uint, string>(10, string.Format("导出选中记录到 {0} 成功", path)));
                Framework.Container.Instance.InteractionService.ShowMessageBox("导出选中记录成功");
            }
            catch (Exception ex)
            {
                Framework.Container.Instance.EvtAggregator.GetEvent<AnalyseMessageEvent>().Publish(
                     new Tuple<uint, string>(10, string.Format("导出选中记录到 {0} 失败", path)));
                Framework.Container.Instance.InteractionService.ShowMessageBox("导出选中记录失败");

                MyLog4Net.Container.Instance.Log.Error("导出选中结果出错", ex);
            }
        }


        private void barBtnItemExportAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool includeDiagram = true, includePic = true;
            GetExportMode(out includeDiagram, out includePic);
            string path = GetExportPath(includeDiagram, includePic);

            if (string.IsNullOrEmpty(path))
            {
                return;
            }

            try
            {
                m_ViewModel.ExportAll(gridControlForExportAll, path, includeDiagram, includePic);

                Framework.Container.Instance.EvtAggregator.GetEvent<AnalyseMessageEvent>().Publish(
                    new Tuple<uint, string>(10, string.Format("导出全部记录到 {0} 成功", path)));
                Framework.Container.Instance.InteractionService.ShowMessageBox("导出全部记录成功");
            }
            catch (Exception ex)
            {
                Framework.Container.Instance.EvtAggregator.GetEvent<AnalyseMessageEvent>().Publish(
                     new Tuple<uint, string>(10, string.Format("导出全部记录到 {0} 失败", path)));
                Framework.Container.Instance.InteractionService.ShowMessageBox("导出全部记录失败");

                MyLog4Net.Container.Instance.Log.Error("导出全部结果出错", ex);
            }
        }

        private void barBtnItemExportCurrentPage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //bool includeDiagram = true, includePic = true;
            //GetExportMode(out includeDiagram, out includePic);
            //string path = GetExportPath(includeDiagram, includePic);
            //if (string.IsNullOrEmpty(path))
            //{
            //    return;
            //}

            //try
            //{
            //    m_ViewModel.ExportCurrentPage(gridControlForExportAll, path, includeDiagram, includePic);
            //}
            //catch (Exception ex)
            //{
            //    Framework.Container.Instance.EvtAggregator.GetEvent<AnalyseMessageEvent>().Publish(
            //         new Tuple<uint, string>(10, string.Format("导出本页记录到 {0} 失败", path)));

            //    Framework.Container.Instance.InteractionService.ShowMessageBox("导出本页记录失败");
            //    MyLog4Net.Container.Instance.Log.Error("导出本页结果出错", ex);
            //}


            System.Data.DataView ids = gridViewResults.DataSource as System.Data.DataView;
            if (ids == null || ids.Count < 1)
            {
                return;
            }

            bool includeDiagram = true, includePic = true;
            GetExportMode(out includeDiagram, out includePic);
            string path = GetExportPath(includeDiagram, includePic);

            if (string.IsNullOrEmpty(path))
            {
                return;
            }

            List<AnalyseRecord> records = new List<AnalyseRecord>();
            foreach (DataRowView row in ids)
            {
                records.Add(row["AnalyseRecord"] as AnalyseRecord);
            }

            try
            {
                m_ViewModel.Export(gridControlForExportAll, path, records, includeDiagram, includePic);

                Framework.Container.Instance.EvtAggregator.GetEvent<AnalyseMessageEvent>().Publish(
                    new Tuple<uint, string>(10, string.Format("导出本页记录到 {0} 成功", path)));
                Framework.Container.Instance.InteractionService.ShowMessageBox("导出本页记录成功");
            }
            catch (Exception ex)
            {
                Framework.Container.Instance.EvtAggregator.GetEvent<AnalyseMessageEvent>().Publish(
                     new Tuple<uint, string>(10, string.Format("导出本页记录到 {0} 失败", path)));
                Framework.Container.Instance.InteractionService.ShowMessageBox("导出本页记录失败");

                MyLog4Net.Container.Instance.Log.Error("导出本页结果出错", ex);
            }

        }


        #endregion
    }
}
