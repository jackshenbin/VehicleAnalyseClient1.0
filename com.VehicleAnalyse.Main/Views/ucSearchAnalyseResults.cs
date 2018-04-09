using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bocom.ImageAnalysisClient.App.ViewModels;
using Bocom.ImageAnalysisClient.DataModel;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.Office.Utils;
using DevExpress.XtraEditors;
using Bocom.ImageAnalysisClient.App.Framework;

namespace Bocom.ImageAnalysisClient.App.Views
{
    public partial class ucSearchAnalyseResults : XtraUserControl
    {

        private SearchAnalyseResultViewModel m_ViewModel;

        public ucSearchAnalyseResults()
        {
            InitializeComponent();
        }

        #region Event handlers
        
        private void ucSearchAnalyseResults_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                m_ViewModel = new SearchAnalyseResultViewModel();
                
                pictureCarStyle.Image.Tag = "-1";

                Framework.Container.Instance.VVMDataBindings.AddBinding(cmbBoxTasks, "EditValue", m_ViewModel, "Task");
                Framework.Container.Instance.VVMDataBindings.AddBinding(this.comboBoxEditPlateNo, "Text", m_ViewModel, "PlateNumber");

                Framework.Container.Instance.VVMDataBindings.AddBinding(this.cmbBoxVehicleDetailType, "SelectedIndex", m_ViewModel, "NVehicleDetailType");
                Framework.Container.Instance.VVMDataBindings.AddBinding(this.cmbBoxVehiclePlateType, "SelectedIndex", m_ViewModel, "NVehiclePlateType");
                Framework.Container.Instance.VVMDataBindings.AddBinding(this.cmbBoxEditResultType, "SelectedIndex", m_ViewModel, "ResultType");

                Framework.Container.Instance.VVMDataBindings.AddBinding(this.btnExportCurrentPage, "Enabled", m_ViewModel, "HasResult");
                Framework.Container.Instance.VVMDataBindings.AddBinding(this.btnExportAll, "Enabled", m_ViewModel, "HasResult");

                Framework.Container.Instance.VVMDataBindings.AddBinding(this.lblCtrlFileName, "Text", m_ViewModel, "FileName");

                cmbBoxTasks.Properties.Items.AddRange(m_ViewModel.Tasks);
                if (m_ViewModel.Tasks != null && m_ViewModel.Tasks.Length > 0)
                {
                    cmbBoxTasks.SelectedIndex = 0;
                }

                gridControl1.DataSource = m_ViewModel.DTAnalyseResults;

                cmbBoxVehicleDetailType.Properties.Items.Clear();
                cmbBoxVehicleDetailType.Properties.Items.AddRange(DataModel.Constant.SDT_PropertyInfo_VehicleDetailType);

                cmbBoxVehiclePlateType.Properties.Items.Clear();
                cmbBoxVehiclePlateType.Properties.Items.AddRange(DataModel.Constant.VehiclePlateTypeInfos);
                cmbBoxVehicleDetailType.SelectedIndex = 0;

                colorCmbBoxVehicle.SetColors(DataModel.Constant.COLORNAMES_VEHICLEBODY);
                colorCmbBoxVehicle.PropertyChanged += new PropertyChangedEventHandler(colorCmbBoxVehicle_PropertyChanged);

                colorCmbBoxPlate.SetColors(DataModel.Constant.COLORNAMES_VEHICLEPLATE);
                colorCmbBoxPlate.PropertyChanged += new PropertyChangedEventHandler(colorCmbBoxPlate_PropertyChanged);

                m_ViewModel.TasksChanged += new EventHandler(ViewModel_TasksChanged);

                this.splitContainerControl1.SplitterPosition = 296;
            }
        }

        void ViewModel_TasksChanged(object sender, EventArgs e)
        {
            cmbBoxTasks.Properties.Items.Clear();
            if (m_ViewModel.Tasks != null && m_ViewModel.Tasks.Length > 0)
            {
                cmbBoxTasks.Properties.Items.AddRange(m_ViewModel.Tasks);
                {
                    cmbBoxTasks.SelectedIndex = 0;
                }
            }
            else
            {

            }
        }

        private void cmbBoxTasks_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Framework.Container.Instance.VVMDataBindings.RemoveBinding(m_ViewModel.ResultPageInfo, "PageIndex", this.comboBoxPage);

            Framework.Container.Instance.VVMDataBindings.RemoveBinding(m_ViewModel.ResultPageInfo, "TotalRecords", this.lblCount);

            Framework.Container.Instance.VVMDataBindings.RemoveBinding(m_ViewModel.ResultPageInfo, "PageCount", this.lblControlPageCount);

            Framework.Container.Instance.VVMDataBindings.RemoveBinding(m_ViewModel.ResultPageInfo, "CurrentPageCount", this.lblCtrlCurrentPageCount);

            Framework.Container.Instance.VVMDataBindings.RemoveBinding(m_ViewModel.ResultPageInfo, "CanNextPage", this.btnNextPage);

            Framework.Container.Instance.VVMDataBindings.RemoveBinding(m_ViewModel.ResultPageInfo, "CanPrePage", this.btnPrePage);

            m_ViewModel.Search();

            this.comboBoxPage.Properties.Items.Clear();

            Debug.Assert(m_ViewModel.ResultPageInfo != null);

            if (m_ViewModel.Task == null)
            {
                return;
            }

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
        }

        private void btnPrePage_Click(object sender, EventArgs e)
        {
            m_ViewModel.TurnPrePage();
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            m_ViewModel.TurnNextPage();
        }

        private void comboBoxPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_ViewModel.ResultPageInfo != null)
            {
                m_ViewModel.ResultPageInfo.PageIndex = comboBoxPage.SelectedIndex;
            }
            // m_FirstTimeZeroPageIndexSelected = false;
        }

        private void pictureCarStyle_Click(object sender, EventArgs e)
        {
            using (FormCarStyle dlg = new FormCarStyle())
            {
                dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.Init();
                dlg.SelectImage = pictureCarStyle.Image;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    pictureCarStyle.Image = dlg.SelectImage;
                    if (dlg.SelectImage != null && dlg.SelectImage.Tag != null)
                    {
                        m_ViewModel.Brand = dlg.SelectImage.Tag as VehicleBrandInfo;
                    }
                    else
                    {
                        m_ViewModel.Brand = null;
                    }
                }
            }
        }

        void colorCmbBoxVehicle_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (string.Compare(e.PropertyName, "SelectedColor", true) == 0)
            {
                m_ViewModel.VehicleColor = colorCmbBoxVehicle.SelectedColorName;
            }
        }

        void colorCmbBoxPlate_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (string.Compare(e.PropertyName, "SelectedColor", true) == 0)
            {
                m_ViewModel.PlateColor = colorCmbBoxPlate.SelectedColorName;
            }
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0 && m_ViewModel != null && m_ViewModel.ResultPageInfo != null)
            {
                int index = m_ViewModel.ResultPageInfo.StartRecordIndex + e.RowHandle + 1;
                e.Info.DisplayText = index.ToString();
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {

        }

        private Image CutVehicleImage(AnalyseRecord record)
        {
            Image image = m_ViewModel.GetImage(record); // Image.FromFile(record.PicId);
            if (image != null && record.PlateRegion != Rectangle.Empty)
            {
                int width = record.PlateRegion.Width;
                int height = record.PlateRegion.Height;

                int x = record.PlateRegion.Left - 4 * width;
                int y = record.PlateRegion.Bottom - 10 * height;

                int xOffset1 = 3 * width, xOffset2 = 2 * width, yOffset1 = 4 * height, yOffset2 = 25 * height;

                if (record.VehicleTypeInfo != null)
                {
                    if (record.VehicleTypeInfo.ID == 2)
                    {
                        // 中车
                        yOffset2 = 40 * height;
                    }
                    if (record.VehicleTypeInfo.ID == 3)
                    {
                        yOffset2 = 60 * height;
                        xOffset2 = (int)(4 * width);
                        xOffset1 = 4 * width;
                    }
                }

                if (record.PlateRegion.X < xOffset1)
                {
                    // left
                    xOffset1 = record.PlateRegion.X;
                }
                if (record.PlateRegion.Y < yOffset2)
                {
                    // top
                    yOffset2 = record.PlateRegion.Y;
                }

                int temp = image.Width - record.PlateRegion.X - record.PlateRegion.Width;
                if (temp < xOffset2)
                {
                    xOffset2 = temp;
                }

                temp = image.Height - record.PlateRegion.Y - record.PlateRegion.Height;
                if (temp < yOffset1)
                {
                    yOffset1 = temp;
                }

                int Height = record.PlateRegion.Height + yOffset1 + yOffset2;
                int Width = record.PlateRegion.Width + xOffset1 + xOffset2;
                Rectangle rect = new Rectangle(record.PlateRegion.X - xOffset1, record.PlateRegion.Y - yOffset2, Width, Height);

                Bitmap imgVehicle = new Bitmap(Width, Height);

                Graphics g = Graphics.FromImage(imgVehicle);

                g.DrawImage(image, new Rectangle(0, 0, Width, Height), rect, GraphicsUnit.Pixel);
                g.Dispose();

                image = imgVehicle;
            }
            
            return image;
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRowView rowView = gridView1.GetRow(e.FocusedRowHandle) as DataRowView;
            if (rowView != null)
            {
                AnalyseRecord record = rowView["AnalyseRecord"] as AnalyseRecord;
                Image image = null;
                if (record != null)
                {
                    image = CutVehicleImage(record);  //Image.FromFile(record.PicId);
                }
                this.picEditThumb.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
                picEditThumb.Image = image;
                m_ViewModel.SelectedAnalyseRecord = record;
            }
            else
            {
                picEditThumb.Image = null;
            }
        }

        private void gridControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            GridHitInfo info = gridView1.CalcHitInfo(e.Location);
            if (info.InRow)
            {
                m_ViewModel.ShowDetails();
            }
        }

        #endregion

        private void btnExport_Click(object sender, EventArgs e)
        {
            // m_ViewModel.ExportCurrentPage();

            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "*.csv|*.csv";
                if (DialogResult.OK == dlg.ShowDialog())
                {
                    try
                    {
                        this.gridControl1.ExportToCsv(dlg.FileName);
                        Framework.Container.Instance.EvtAggregator.GetEvent<AnalyseMessageEvent>().Publish(
                            new Tuple<uint, string>(10, string.Format("导出本页记录到 {0} 成功", dlg.FileName)));
                        Framework.Container.Instance.InteractionService.ShowMessageBox("导出本页记录成功");
                    }
                    catch (Exception ex)
                    {
                        Framework.Container.Instance.EvtAggregator.GetEvent<AnalyseMessageEvent>().Publish(
                             new Tuple<uint, string>(10, string.Format("导出本页记录到 {0} 失败", dlg.FileName)));
                        Framework.Container.Instance.InteractionService.ShowMessageBox("导出本页记录失败");
                    }
                }
            }
        }

        private void btnExportAll_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "*.csv|*.csv";
                if (DialogResult.OK == dlg.ShowDialog())
                {
                    try
                    {
                        m_ViewModel.ExportAll(gridControl2, dlg.FileName);

                        Framework.Container.Instance.EvtAggregator.GetEvent<AnalyseMessageEvent>().Publish(
                            new Tuple<uint, string>(10, string.Format("导出全部记录到 {0} 成功", dlg.FileName)));
                        Framework.Container.Instance.InteractionService.ShowMessageBox("导出全部记录成功");
                    }
                    catch (Exception ex)
                    {
                        Framework.Container.Instance.EvtAggregator.GetEvent<AnalyseMessageEvent>().Publish(
                             new Tuple<uint, string>(10, string.Format("导出全部记录到 {0} 失败", dlg.FileName)));
                        Framework.Container.Instance.InteractionService.ShowMessageBox("导出全部记录失败");
                    }
                }
            }
        }

    }
}
