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
    public partial class ucPlateGroupSubResultPage : DevExpress.XtraEditors.XtraUserControl
    {
        public event EventHandler ResultDetailInfoClick;
 
        #region Fields
        private PlateGroupSubResultPageViewModel m_plateGroupViewModel;
        #endregion

        public List<AnalyseRecord> CurrPageRecords { get; set; }

        public ucPlateGroupSubResultPage()
        {
            InitializeComponent();

            this.HandleDestroyed += new EventHandler(ucResultPage_HandleDestroyed);
        }

        void ucResultPage_HandleDestroyed(object sender, EventArgs e)
        {
            if (m_plateGroupViewModel != null)
            {
                m_plateGroupViewModel.PreNewSearch -= ViewModel_PreNewSearch;
                m_plateGroupViewModel.SearchResult -= new EventHandler(ViewModel_SearchResult);

            }

        }

        #region Private 
        


        #endregion

        #region Event handlers


        private void ucResultPage_Load(object sender, EventArgs e)
        {
        }

        void ucSingleGroupResult1_VehicleClick(object sender, EventArgs e)
        {
            ucSingleGroupResult group = sender as ucSingleGroupResult;
            if (group != null)
            {
                ucNoGroupSubResultPage1.BringToFront();
                CurrPageRecords = group.AnalyseResults;
                ucNoGroupSubResultPage1.SetVehicleData(CurrPageRecords);
                
            }
        }
        void ucSingleGroupResult1_ExportClick(object sender, EventArgs e)
        {
            ucSingleGroupResult group = sender as ucSingleGroupResult;
            if (group != null)
            {
                bool includeDiagram = false, includePic = true;
                string path = GetExportPath(includeDiagram, includePic);

                if (string.IsNullOrEmpty(path))
                {
                    return;
                }

                try
                {
                    m_plateGroupViewModel.ExportCurrentGroup(group.AnalyseResults, path);

                    Framework.Container.Instance.EvtAggregator.GetEvent<AnalyseMessageEvent>().Publish(
                        new Tuple<uint, string>(10, string.Format("导出本组记录到 {0} 成功", path)));
                    Framework.Container.Instance.InteractionService.ShowMessageBox("导出本组记录成功");
                }
                catch (Exception ex)
                {
                    Framework.Container.Instance.EvtAggregator.GetEvent<AnalyseMessageEvent>().Publish(
                         new Tuple<uint, string>(10, string.Format("导出本组记录到 {0} 失败", path)));
                    Framework.Container.Instance.InteractionService.ShowMessageBox("导出本组记录失败");

                    MyLog4Net.Container.Instance.Log.Error("导出本组结果出错", ex);
                }

            }
        }


        #endregion


        public void Init()
        {
            CurrPageRecords = new List<AnalyseRecord>();
            m_plateGroupViewModel = new PlateGroupSubResultPageViewModel();
            m_plateGroupViewModel.PreNewSearch += ViewModel_PreNewSearch;
            m_plateGroupViewModel.SearchResult += new EventHandler(ViewModel_SearchResult);

            ShowVehicleGroup();

            ucSingleGroupResult1.VehicleClick += ucSingleGroupResult1_VehicleClick; ucSingleGroupResult1.VehicleGroupType = VehicleGroupType.E_PLATE_GROUP;
            ucSingleGroupResult2.VehicleClick += ucSingleGroupResult1_VehicleClick; ucSingleGroupResult2.VehicleGroupType = VehicleGroupType.E_PLATE_GROUP;
            ucSingleGroupResult3.VehicleClick += ucSingleGroupResult1_VehicleClick; ucSingleGroupResult3.VehicleGroupType = VehicleGroupType.E_PLATE_GROUP;
            ucSingleGroupResult4.VehicleClick += ucSingleGroupResult1_VehicleClick; ucSingleGroupResult4.VehicleGroupType = VehicleGroupType.E_PLATE_GROUP;
            ucSingleGroupResult5.VehicleClick += ucSingleGroupResult1_VehicleClick; ucSingleGroupResult5.VehicleGroupType = VehicleGroupType.E_PLATE_GROUP;
            ucSingleGroupResult6.VehicleClick += ucSingleGroupResult1_VehicleClick; ucSingleGroupResult6.VehicleGroupType = VehicleGroupType.E_PLATE_GROUP;
            ucSingleGroupResult7.VehicleClick += ucSingleGroupResult1_VehicleClick; ucSingleGroupResult7.VehicleGroupType = VehicleGroupType.E_PLATE_GROUP;
            ucSingleGroupResult8.VehicleClick += ucSingleGroupResult1_VehicleClick; ucSingleGroupResult8.VehicleGroupType = VehicleGroupType.E_PLATE_GROUP;
            ucSingleGroupResult9.VehicleClick += ucSingleGroupResult1_VehicleClick; ucSingleGroupResult9.VehicleGroupType = VehicleGroupType.E_PLATE_GROUP;
            ucSingleGroupResult10.VehicleClick += ucSingleGroupResult1_VehicleClick; ucSingleGroupResult10.VehicleGroupType = VehicleGroupType.E_PLATE_GROUP;
            ucSingleGroupResult11.VehicleClick += ucSingleGroupResult1_VehicleClick; ucSingleGroupResult11.VehicleGroupType = VehicleGroupType.E_PLATE_GROUP;
            ucSingleGroupResult12.VehicleClick += ucSingleGroupResult1_VehicleClick; ucSingleGroupResult12.VehicleGroupType = VehicleGroupType.E_PLATE_GROUP;
            ucSingleGroupResult13.VehicleClick += ucSingleGroupResult1_VehicleClick; ucSingleGroupResult13.VehicleGroupType = VehicleGroupType.E_PLATE_GROUP;
            ucSingleGroupResult14.VehicleClick += ucSingleGroupResult1_VehicleClick; ucSingleGroupResult14.VehicleGroupType = VehicleGroupType.E_PLATE_GROUP;
            ucSingleGroupResult15.VehicleClick += ucSingleGroupResult1_VehicleClick; ucSingleGroupResult15.VehicleGroupType = VehicleGroupType.E_PLATE_GROUP;
            ucSingleGroupResult16.VehicleClick += ucSingleGroupResult1_VehicleClick; ucSingleGroupResult16.VehicleGroupType = VehicleGroupType.E_PLATE_GROUP;
            ucSingleGroupResult17.VehicleClick += ucSingleGroupResult1_VehicleClick; ucSingleGroupResult17.VehicleGroupType = VehicleGroupType.E_PLATE_GROUP;
            ucSingleGroupResult18.VehicleClick += ucSingleGroupResult1_VehicleClick; ucSingleGroupResult18.VehicleGroupType = VehicleGroupType.E_PLATE_GROUP;
            ucSingleGroupResult19.VehicleClick += ucSingleGroupResult1_VehicleClick; ucSingleGroupResult19.VehicleGroupType = VehicleGroupType.E_PLATE_GROUP;
            ucSingleGroupResult20.VehicleClick += ucSingleGroupResult1_VehicleClick; ucSingleGroupResult20.VehicleGroupType = VehicleGroupType.E_PLATE_GROUP;
            ucSingleGroupResult21.VehicleClick += ucSingleGroupResult1_VehicleClick; ucSingleGroupResult21.VehicleGroupType = VehicleGroupType.E_PLATE_GROUP;
            ucSingleGroupResult22.VehicleClick += ucSingleGroupResult1_VehicleClick; ucSingleGroupResult22.VehicleGroupType = VehicleGroupType.E_PLATE_GROUP;
            ucSingleGroupResult23.VehicleClick += ucSingleGroupResult1_VehicleClick; ucSingleGroupResult23.VehicleGroupType = VehicleGroupType.E_PLATE_GROUP;
            ucSingleGroupResult24.VehicleClick += ucSingleGroupResult1_VehicleClick; ucSingleGroupResult24.VehicleGroupType = VehicleGroupType.E_PLATE_GROUP;

            ucSingleGroupResult1.ExportClick += ucSingleGroupResult1_ExportClick;
            ucSingleGroupResult2.ExportClick += ucSingleGroupResult1_ExportClick;
            ucSingleGroupResult3.ExportClick += ucSingleGroupResult1_ExportClick;
            ucSingleGroupResult4.ExportClick += ucSingleGroupResult1_ExportClick;
            ucSingleGroupResult5.ExportClick += ucSingleGroupResult1_ExportClick;
            ucSingleGroupResult6.ExportClick += ucSingleGroupResult1_ExportClick;
            ucSingleGroupResult7.ExportClick += ucSingleGroupResult1_ExportClick;
            ucSingleGroupResult8.ExportClick += ucSingleGroupResult1_ExportClick;
            ucSingleGroupResult9.ExportClick += ucSingleGroupResult1_ExportClick;
            ucSingleGroupResult10.ExportClick += ucSingleGroupResult1_ExportClick;
            ucSingleGroupResult11.ExportClick += ucSingleGroupResult1_ExportClick;
            ucSingleGroupResult12.ExportClick += ucSingleGroupResult1_ExportClick;
            ucSingleGroupResult13.ExportClick += ucSingleGroupResult1_ExportClick;
            ucSingleGroupResult14.ExportClick += ucSingleGroupResult1_ExportClick;
            ucSingleGroupResult15.ExportClick += ucSingleGroupResult1_ExportClick;
            ucSingleGroupResult16.ExportClick += ucSingleGroupResult1_ExportClick;
            ucSingleGroupResult17.ExportClick += ucSingleGroupResult1_ExportClick;
            ucSingleGroupResult18.ExportClick += ucSingleGroupResult1_ExportClick;
            ucSingleGroupResult19.ExportClick += ucSingleGroupResult1_ExportClick;
            ucSingleGroupResult20.ExportClick += ucSingleGroupResult1_ExportClick;
            ucSingleGroupResult21.ExportClick += ucSingleGroupResult1_ExportClick;
            ucSingleGroupResult22.ExportClick += ucSingleGroupResult1_ExportClick;
            ucSingleGroupResult23.ExportClick += ucSingleGroupResult1_ExportClick;
            ucSingleGroupResult24.ExportClick += ucSingleGroupResult1_ExportClick;




            ucNoGroupSubResultPage1.Init();
        }


        void ViewModel_PreNewSearch(object sender, EventArgs e)
        {
            if (m_plateGroupViewModel.ResultPageInfo != null)
            {
                Framework.Container.Instance.VVMDataBindings.RemoveBinding(m_plateGroupViewModel.ResultPageInfo, "PageIndex", this.comboBoxPage);

                Framework.Container.Instance.VVMDataBindings.RemoveBinding(m_plateGroupViewModel.ResultPageInfo, "TotalRecords", this.lblCount);
                
                Framework.Container.Instance.VVMDataBindings.RemoveBinding(m_plateGroupViewModel.ResultPageInfo, "PageCount", this.lblControlPageCount);

                Framework.Container.Instance.VVMDataBindings.RemoveBinding(m_plateGroupViewModel.ResultPageInfo, "CurrentPageCount", this.lblCtrlCurrentPageCount);
                
                Framework.Container.Instance.VVMDataBindings.RemoveBinding(m_plateGroupViewModel.ResultPageInfo, "CanNextPage", this.btnNextPage);

                Framework.Container.Instance.VVMDataBindings.RemoveBinding(m_plateGroupViewModel.ResultPageInfo, "CanPrePage", this.btnPrePage);

                this.comboBoxPage.Properties.Items.Clear();
            }
            ShowVehicleGroup();
                
        }

        void ViewModel_SearchResult(object sender, EventArgs e)
        {
            bool isfirst = (bool)sender;
            if (isfirst)
            {
                Debug.Assert(m_plateGroupViewModel.ResultPageInfo != null);

                this.comboBoxPage.Properties.Items.AddRange(m_plateGroupViewModel.ResultPageInfo.GetPageIds());

                Framework.Container.Instance.VVMDataBindings.AddBinding(this.comboBoxPage,
               "SelectedIndex", m_plateGroupViewModel.ResultPageInfo, "PageIndex");

                Framework.Container.Instance.VVMDataBindings.AddBinding(this.lblCount,
                "Text", m_plateGroupViewModel.ResultPageInfo, "TotalRecords");
                
                Framework.Container.Instance.VVMDataBindings.AddBinding(this.lblControlPageCount,
              "Text", m_plateGroupViewModel.ResultPageInfo, "PageCount");

                Framework.Container.Instance.VVMDataBindings.AddBinding(this.lblCtrlCurrentPageCount,
               "Text", m_plateGroupViewModel.ResultPageInfo, "CurrentPageCount");
                
                Framework.Container.Instance.VVMDataBindings.AddBinding(this.btnNextPage,
               "Enabled", m_plateGroupViewModel.ResultPageInfo, "CanNextPage");

                Framework.Container.Instance.VVMDataBindings.AddBinding(this.btnPrePage,
              "Enabled", m_plateGroupViewModel.ResultPageInfo, "CanPrePage");

            }
            ShowVehicleGroup();
        }

        private void ShowVehicleGroup()
        {
            int i = 0;
            for (i = 0; i < Math.Min(24,m_plateGroupViewModel.DTAnalyseResults.Count); i++)
			{
                ucSingleGroupResult r = tableLayoutPanel1.Controls[i] as ucSingleGroupResult;
                r.Visible = true;
                List<AnalyseRecord> tmp = m_plateGroupViewModel.DTAnalyseResults[i];
                m_plateGroupViewModel.GetThumbImage(tmp[0]);
                r.SetVehicle(tmp);
			 
			}

            for (int j = i; j < 24; j++)
            {
                ucSingleGroupResult r = tableLayoutPanel1.Controls[j] as ucSingleGroupResult;
                r.SetVehicle(null);
                r.Visible = false;
            }
        }


        private void btnPrePage_Click(object sender, EventArgs e)
        {
            m_plateGroupViewModel.TurnPrePage();
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            m_plateGroupViewModel.TurnNextPage();
        }
        private void comboBoxPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_plateGroupViewModel.ResultPageInfo != null)
            {
                m_plateGroupViewModel.ResultPageInfo.PageIndex = comboBoxPage.SelectedIndex;
            }
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
            else if (includePic)
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


        private void simpleButtonExport_Click(object sender, EventArgs e)
        {
            bool includeDiagram = false, includePic = true;
            string path = GetExportPath(includeDiagram, includePic);

            if (string.IsNullOrEmpty(path))
            {
                return;
            }

            try
            {
                m_plateGroupViewModel.ExportAll(path);

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


        internal void SetVehicleData(List<AnalyseRecord> list)
        {
            m_plateGroupViewModel.OnSearchFinished(list);
        }

        private void ucNoGroupSubResultPage1_ResultDetailInfoClick(object sender, EventArgs e)
        {
            if (ResultDetailInfoClick != null)
                ResultDetailInfoClick(sender, e);
        }

        private void ucNoGroupSubResultPage1_BackwordClick(object sender, EventArgs e)
        {
            panelControl3.BringToFront();

        }
    }
}
