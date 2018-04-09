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
    public partial class ucNoGroupSubResultPage : DevExpress.XtraEditors.XtraUserControl
    {
        public event EventHandler BackwordClick;
        public event EventHandler ResultDetailInfoClick;
        #region Fields
        private NoGroupSubResultPageViewModel m_noGroupViewModel;
        #endregion

        [DefaultValue(true)]
        public bool ShowExport
        {
            get { return simpleButtonExport.Visible; }
            set
            {
                if (simpleButtonExport.Visible == value)
                    return;

                simpleButtonExport.Visible = value;
                if (!value)
                {
                    tableLayoutPanel2.Location = new Point(0,28);
                    tableLayoutPanel2.Height -= 28;
                }
                else
                {
                    tableLayoutPanel2.Location = new Point();
                    tableLayoutPanel2.Height += 28;
                }
            }
        }

        [DefaultValue(false)]
        public bool ShowBackwordLink { get { return linkLabel1.Visible; } set { linkLabel1.Visible = value; } }

        public ucNoGroupSubResultPage()
        {
            InitializeComponent();

            this.HandleDestroyed += new EventHandler(ucResultPage_HandleDestroyed);
        }

        void ucResultPage_HandleDestroyed(object sender, EventArgs e)
        {
            if (m_noGroupViewModel != null)
            {
                m_noGroupViewModel.PreNewSearch -= ViewModel_PreNewSearch;
                m_noGroupViewModel.SearchResult -= new EventHandler(ViewModel_SearchResult);

            }

        }

        #region Private



        #endregion

        #region Event handlers


        private void ucResultPage_Load(object sender, EventArgs e)
        {
        }


        void ucSingleResult1_VehicleClick(object sender, EventArgs e)
        {
            string vehicleid = (string)sender;
            if (!string.IsNullOrEmpty(vehicleid))
            {
                if (ResultDetailInfoClick != null)
                    ResultDetailInfoClick(vehicleid, e);

            }

        }

        #endregion


        public void Init()
        {

            m_noGroupViewModel = new NoGroupSubResultPageViewModel();
            m_noGroupViewModel.PreNewSearch += ViewModel_PreNewSearch;
            m_noGroupViewModel.SearchResult += new EventHandler(ViewModel_SearchResult);

            ShowVehicle();

            ucSingleResult1.VehicleClick += new EventHandler(ucSingleResult1_VehicleClick);
            ucSingleResult2.VehicleClick += new EventHandler(ucSingleResult1_VehicleClick);
            ucSingleResult3.VehicleClick += new EventHandler(ucSingleResult1_VehicleClick);
            ucSingleResult4.VehicleClick += new EventHandler(ucSingleResult1_VehicleClick);
            ucSingleResult5.VehicleClick += new EventHandler(ucSingleResult1_VehicleClick);
            ucSingleResult6.VehicleClick += new EventHandler(ucSingleResult1_VehicleClick);
            ucSingleResult7.VehicleClick += new EventHandler(ucSingleResult1_VehicleClick);
            ucSingleResult8.VehicleClick += new EventHandler(ucSingleResult1_VehicleClick);
            ucSingleResult9.VehicleClick += new EventHandler(ucSingleResult1_VehicleClick);
            ucSingleResult10.VehicleClick += new EventHandler(ucSingleResult1_VehicleClick);
            ucSingleResult11.VehicleClick += new EventHandler(ucSingleResult1_VehicleClick);
            ucSingleResult12.VehicleClick += new EventHandler(ucSingleResult1_VehicleClick);
            ucSingleResult13.VehicleClick += new EventHandler(ucSingleResult1_VehicleClick);
            ucSingleResult14.VehicleClick += new EventHandler(ucSingleResult1_VehicleClick);
            ucSingleResult15.VehicleClick += new EventHandler(ucSingleResult1_VehicleClick);
            ucSingleResult16.VehicleClick += new EventHandler(ucSingleResult1_VehicleClick);
            ucSingleResult17.VehicleClick += new EventHandler(ucSingleResult1_VehicleClick);
            ucSingleResult18.VehicleClick += new EventHandler(ucSingleResult1_VehicleClick);
            ucSingleResult19.VehicleClick += new EventHandler(ucSingleResult1_VehicleClick);
            ucSingleResult20.VehicleClick += new EventHandler(ucSingleResult1_VehicleClick);
            ucSingleResult21.VehicleClick += new EventHandler(ucSingleResult1_VehicleClick);
            ucSingleResult22.VehicleClick += new EventHandler(ucSingleResult1_VehicleClick);
            ucSingleResult23.VehicleClick += new EventHandler(ucSingleResult1_VehicleClick);
            ucSingleResult24.VehicleClick += new EventHandler(ucSingleResult1_VehicleClick);


        }

        void ViewModel_PreNewSearch(object sender, EventArgs e)
        {
            if (m_noGroupViewModel.ResultPageInfo != null)
            {
                Framework.Container.Instance.VVMDataBindings.RemoveBinding(m_noGroupViewModel.ResultPageInfo, "PageIndex", this.comboBoxPage);

                Framework.Container.Instance.VVMDataBindings.RemoveBinding(m_noGroupViewModel.ResultPageInfo, "TotalRecords", this.lblCount);
                
                Framework.Container.Instance.VVMDataBindings.RemoveBinding(m_noGroupViewModel.ResultPageInfo, "PageCount", this.lblControlPageCount);

                Framework.Container.Instance.VVMDataBindings.RemoveBinding(m_noGroupViewModel.ResultPageInfo, "CurrentPageCount", this.lblCtrlCurrentPageCount);
                
                Framework.Container.Instance.VVMDataBindings.RemoveBinding(m_noGroupViewModel.ResultPageInfo, "CanNextPage", this.btnNextPage);

                Framework.Container.Instance.VVMDataBindings.RemoveBinding(m_noGroupViewModel.ResultPageInfo, "CanPrePage", this.btnPrePage);

                this.comboBoxPage.Properties.Items.Clear();
            }
            ShowVehicle();

        }

        void ViewModel_SearchResult(object sender, EventArgs e)
        {
            bool isfirst = (bool)sender;
            if (isfirst)
            {
                Debug.Assert(m_noGroupViewModel.ResultPageInfo != null);

                this.comboBoxPage.Properties.Items.AddRange(m_noGroupViewModel.ResultPageInfo.GetPageIds());

                Framework.Container.Instance.VVMDataBindings.AddBinding(this.comboBoxPage,
               "SelectedIndex", m_noGroupViewModel.ResultPageInfo, "PageIndex");

                Framework.Container.Instance.VVMDataBindings.AddBinding(this.lblCount,
                "Text", m_noGroupViewModel.ResultPageInfo, "TotalRecords");
                
                Framework.Container.Instance.VVMDataBindings.AddBinding(this.lblControlPageCount,
              "Text", m_noGroupViewModel.ResultPageInfo, "PageCount");

                Framework.Container.Instance.VVMDataBindings.AddBinding(this.lblCtrlCurrentPageCount,
                 "Text", m_noGroupViewModel.ResultPageInfo, "CurrentPageCount");
                
                Framework.Container.Instance.VVMDataBindings.AddBinding(this.btnNextPage,
               "Enabled", m_noGroupViewModel.ResultPageInfo, "CanNextPage");

                Framework.Container.Instance.VVMDataBindings.AddBinding(this.btnPrePage,
              "Enabled", m_noGroupViewModel.ResultPageInfo, "CanPrePage");

            }
            ShowVehicle();
        }

        private void ShowVehicle()
        {
            int i = 0;
            for (i = 0; i < Math.Min(24, m_noGroupViewModel.CurrPageRecords.Count); i++)
            {
                ucSingleResult r = tableLayoutPanel2.Controls[i] as ucSingleResult;
                r.Visible = true;
                AnalyseRecord tmp = m_noGroupViewModel.CurrPageRecords[i];
                m_noGroupViewModel.GetThumbImage(tmp);
                r.SetVehicle(tmp);

            }

            for (int j = i; j < 24; j++)
            {
                ucSingleResult r = tableLayoutPanel2.Controls[j] as ucSingleResult;
                r.SetVehicle(null);
                r.Visible = false;
            }
        }


        private void btnPrePage_Click(object sender, EventArgs e)
        {
            m_noGroupViewModel.TurnPrePage();
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            m_noGroupViewModel.TurnNextPage();
        }
        private void comboBoxPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_noGroupViewModel.ResultPageInfo != null)
            {
                m_noGroupViewModel.ResultPageInfo.PageIndex = comboBoxPage.SelectedIndex;
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
                m_noGroupViewModel.ExportAll(path);

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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (BackwordClick != null)
                BackwordClick(this, null);
        }



        internal void SetVehicleData(List<AnalyseRecord> list)
        {
            m_noGroupViewModel.OnSearchFinished(list);
        }
    }
}
