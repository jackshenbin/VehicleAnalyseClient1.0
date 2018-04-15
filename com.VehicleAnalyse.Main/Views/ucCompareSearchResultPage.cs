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
    public partial class ucCompareSearchResultPage : DevExpress.XtraEditors.XtraUserControl
    {
        #region Fields
        private CpmpareSearchResultPageViewModel m_compareViewModel;
        private SearchSettingsViewModel m_searchViewModel;
        private List<AnalyseRecord> m_featureList;
        #endregion

        public ucCompareSearchResultPage()
        {

            InitializeComponent();

            this.HandleDestroyed += new EventHandler(ucResultPage_HandleDestroyed);
        }

        void ucResultPage_HandleDestroyed(object sender, EventArgs e)
        {
            if (m_compareViewModel != null)
            {
                m_compareViewModel.PreNewSearch -= ViewModel_PreNewSearch;
                m_compareViewModel.SearchResult -= new EventHandler(ViewModel_SearchResult);
            }

        }

        #region Private 
        


        #endregion

        #region Event handlers


        private void ucResultPage_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {

                m_compareViewModel = new CpmpareSearchResultPageViewModel();
                m_searchViewModel = new SearchSettingsViewModel();
                m_searchViewModel.TasksChanged += m_searchViewModel_TasksChanged;
                m_compareViewModel.PreNewSearch += ViewModel_PreNewSearch;
                m_compareViewModel.SearchResult += new EventHandler(ViewModel_SearchResult);

                Framework.Container.Instance.VVMDataBindings.AddBinding(this.lblCtrlFileName, "Text", m_compareViewModel, "FileName");


                this.ucSearchSettings1 = new com.VehicleAnalyse.Main.Views.ucCompareSearchSettingsContainer();
                // ucSearchSettings1
                // 
                this.ucSearchSettings1.Location = new System.Drawing.Point(3, 3);
                this.ucSearchSettings1.Name = "ucSearchSettings1";
                this.ucSearchSettings1.Size = new System.Drawing.Size(316, 164);
                this.ucSearchSettings1.TabIndex = 0;
                this.ucSearchSettings1.Dock = System.Windows.Forms.DockStyle.Fill;
                this.ucSearchSettings1.OKClicked += ucSearchSettings1_OKClicked;
                this.ucSearchSettings1.CancelClicked += ucSearchSettings1_CancelClicked;
                this.popupControlContainer1.Controls.Add(this.ucSearchSettings1);


                Init();

                //ucSingleResult1.VehicleClick += new EventHandler(ucSingleResult1_VehicleClick);
                //ucSingleResult2.VehicleClick += new EventHandler(ucSingleResult1_VehicleClick);
                //ucSingleResult3.VehicleClick += new EventHandler(ucSingleResult1_VehicleClick);
                //ucSingleResult4.VehicleClick += new EventHandler(ucSingleResult1_VehicleClick);
                //ucSingleResult5.VehicleClick += new EventHandler(ucSingleResult1_VehicleClick);
                //ucSingleResult6.VehicleClick += new EventHandler(ucSingleResult1_VehicleClick);
                //ucSingleResult7.VehicleClick += new EventHandler(ucSingleResult1_VehicleClick);
                //ucSingleResult8.VehicleClick += new EventHandler(ucSingleResult1_VehicleClick);
                //ucSingleResult9.VehicleClick += new EventHandler(ucSingleResult1_VehicleClick);
                //ucSingleResult10.VehicleClick += new EventHandler(ucSingleResult1_VehicleClick);
                //ucSingleResult11.VehicleClick += new EventHandler(ucSingleResult1_VehicleClick);
                //ucSingleResult12.VehicleClick += new EventHandler(ucSingleResult1_VehicleClick);


                ucPlateGroupSubResultPage1.ResultDetailInfoClick += new EventHandler(ucPlateGroupSubResultPage1_ResultDetailInfoClick);
                ucNoGroupSubResultPage1.ResultDetailInfoClick += new EventHandler(ucNoGroupSubResultPage1_ResultDetailInfoClick);
                ucNoGroupSubResultPage1.ShowBackwordLink = false;


            }
        }

        void m_searchViewModel_TasksChanged(object sender, EventArgs e)
        {
            //List<CameraInfo> alllist = Framework.Container.Instance.TaskManager.GetAllTasks().ConvertAll<CameraInfo>(it => new CameraInfo() { ID = it.TaskId, FullName = it.TaskName });
            //alllist.AddRange(Framework.Environment.CameraList);
            //ucSearchPara_Camera1.Update(alllist.ToArray());

            if (Framework.Environment.RealTimeVersion)
            {
                List<CameraInfo> alllist = new List<CameraInfo>();
                alllist.AddRange(Framework.Environment.CameraList);
                ucSearchPara_Camera1.Update(alllist.ToArray());
            }
            else
            {
                List<CameraInfo> alllist = Framework.Container.Instance.TaskManager.GetAllTasks().ConvertAll<CameraInfo>(it => new CameraInfo() { ID = it.TaskId, FullName = it.TaskName });
                ucSearchPara_Camera1.Update(alllist.ToArray());
            }

        }

        void ucPlateGroupSubResultPage1_ResultDetailInfoClick(object sender, EventArgs e)
        {
            string vehicleid = (string)sender;
            if (!string.IsNullOrEmpty(vehicleid))
            {
                var tmp = m_compareViewModel.GetVehicleByID(vehicleid);
                ucSingleResultDetailInfo1.SetAnalyseResults(ucPlateGroupSubResultPage1.CurrPageRecords);
                ucSingleResultDetailInfo1.SetVehicle(tmp);
                ucSingleResultDetailInfo1.Visible = true;
            }
        }



        void ucNoGroupSubResultPage1_ResultDetailInfoClick(object sender, EventArgs e)
        {
            string vehicleid = (string)sender;
            if (!string.IsNullOrEmpty(vehicleid))
            {
                var tmp = m_compareViewModel.GetVehicleByID(vehicleid);
                ucSingleResultDetailInfo1.SetAnalyseResults(m_compareViewModel.AnalyseResults);
                ucSingleResultDetailInfo1.SetVehicle(tmp);
                ucSingleResultDetailInfo1.Visible = true;
            }
        }
        void simpleButtonPlateGroup_Click(object sender, System.EventArgs e)
        {
            ucPlateGroupSubResultPage1.BringToFront();
        }

        void simpleButtonNoGroup_Click(object sender, System.EventArgs e)
        {
            ucNoGroupSubResultPage1.BringToFront();
        }


        //void ucSingleResult1_VehicleClick(object sender, EventArgs e)
        //{
        //    string vehicleid = (string)sender;
        //    if (!string.IsNullOrEmpty(vehicleid))
        //    {
        //        var tmp = m_compareViewModel.GetVehicleByID(vehicleid);
        //        ucSingleResultDetailInfo1.SetAnalyseResults(m_compareViewModel.AnalyseResults);
        //        ucSingleResultDetailInfo1.SetVehicle(tmp);
        //        ucSingleResultDetailInfo1.Visible = true;
        //    }
        //}

        void ucSearchSettings1_OKClicked(object sender, EventArgs e)
        {
            popupControlContainer1.Hide();
            m_searchViewModel.Weight = ucSearchSettings1.Weight;
            m_searchViewModel.PlateNumber = ucSearchSettings1.PlateNo;
            m_searchViewModel.ResultCount = ucSearchSettings1.ResultCount;
            if (m_searchViewModel.Weight  > 0)
            {
                labelControlAdvString.Text = ucSearchSettings1.ToString(); //"车牌[" + m_searchViewModel.PlateNumber + "]优先，权重" + m_searchViewModel.Weight + "%";
            }
            else
            {
                labelControlAdvString.Text = ucSearchSettings1.ToString(); //"无";
            }

        }
        void ucSearchSettings1_CancelClicked(object sender, EventArgs e)
        {
            popupControlContainer1.Hide();
            ucSearchSettings1.Weight = m_searchViewModel.Weight ;
           ucSearchSettings1.PlateNo = m_searchViewModel.PlateNumber ;
           ucSearchSettings1.ResultCount = m_searchViewModel.ResultCount;
        }



        private void popupControlContainer1_Leave(object sender, EventArgs e)
        {
            popupControlContainer1.Hide();
        }

        private void btnShowSettings_Click(object sender, EventArgs e)
        {
            popupControlContainer1.BringToFront();
            popupControlContainer1.Show();
            ucSearchSettings1.Focus();
        }

        #endregion

        private void simpleButtonSelectPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "图片文件|*.jpg; *.bmp; *.png";
            Image srcImg1 = null;
            Image srcImg2 = null;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                m_searchViewModel.ComparePicturePath = dlg.FileName;
                Image srcImg = Image.FromFile(dlg.FileName);
                List<AnalyseRecord> ret = null;
                try
                {
                    ret = m_searchViewModel.GetFeature(srcImg);
                    ret.Sort((it1, it2) => (0-(it1.VehicleRegion.Width * it1.VehicleRegion.Height).CompareTo(it2.VehicleRegion.Width * it2.VehicleRegion.Height)));
                }
                catch (SDKCallException ex)
                {
                    Framework.Container.Instance.InteractionService.ShowMessageBox("无法获取到图片目标，错误信息"+ex.ToString());

                }
                m_featureList = ret;
                if (ret != null && ret.Count > 0)
                {
                    //AnalyseRecord item = ret[0];

                    //srcImg2 = WinFormAppUtil.Common.Utils.CutImage(srcImg, item.VehicleRegion);
                    ////srcImg1 = WinFormAppUtil.Common.Utils.Overlay(srcImg, item.VehicleRegion);
                    srcImg1 = srcImg;
                    //m_searchViewModel.GlobRect = item.VehicleRegion;
                    //if (item.PlateNumber != "11111111" && item.PlateNumber != "22222222")
                    //{
                    //    m_searchViewModel.PlateNumber = item.PlateNumber;
                    //    m_searchViewModel.Weight = 100;
                    //    labelControlAdvString.Text = "车牌[" + item.PlateNumber + "]优先，权重100%";
                    //}
                    //else
                    //{ 
                    //    m_searchViewModel.PlateNumber = "";
                    //    m_searchViewModel.Weight = 0;
                    //    labelControlAdvString.Text = "无";
                    //}
                    ucPictureBoxShowRegion1.Image = srcImg1;
                    ucPictureBoxShowRegion1.initGlobRect(ret.ConvertAll<Rectangle>(item => item.VehicleRegion));
                    pictureEdit2.Image = srcImg2;
                    labelControlVehicle.Text = "当前目标：无";
                    ucPictureBoxRegion1.Visible = false;


                    if (ucPictureBoxShowRegion1.GlobRect != new Rectangle())
                    {
                        Image srcImgT2 = AppUtil.Common.Utils.CutImage(srcImg, ucPictureBoxShowRegion1.GlobRect);
                        m_searchViewModel.GlobRect = ucPictureBoxShowRegion1.GlobRect;
                        pictureEdit2.Image = srcImgT2;
                        labelControlVehicle.Text = "当前目标：无";
                        foreach (AnalyseRecord item in m_featureList)
                        {
                            if (item.VehicleRegion.Equals(m_searchViewModel.GlobRect))
                            {
                                labelControlVehicle.Text = "当前目标：" + item.ToShortString();
                                m_searchViewModel.PlateNumber = item.PlateNumber;
                                //m_searchViewModel.Weight = 100;
                                //m_searchViewModel.ResultCount = 100;
                                //ucSearchSettings1.Weight = m_searchViewModel.Weight;
                                ucSearchSettings1.PlateNo = m_searchViewModel.PlateNumber;
                                //ucSearchSettings1.ResultCount = m_searchViewModel.ResultCount;
                                labelControlAdvString.Text = ucSearchSettings1.ToString(); //"车牌[" + item.PlateNumber + "]优先，权重100%";
                                break;
                            }
                        }


                    }

                }
                else
                {
                    ucPictureBoxShowRegion1.Image = null;
                    ucPictureBoxShowRegion1.initGlobRect(new List<Rectangle>());

                    labelControlVehicle.Text = "当前目标：无";
                    m_searchViewModel.PlateNumber = "";
                    m_searchViewModel.Weight = 0;
                    //m_searchViewModel.ResultCount = 100;
                    ucSearchSettings1.Weight = m_searchViewModel.Weight;
                    ucSearchSettings1.PlateNo = m_searchViewModel.PlateNumber;
                    //ucSearchSettings1.ResultCount = m_searchViewModel.ResultCount;
                    labelControlAdvString.Text = ucSearchSettings1.ToString(); //"无";
                    ucPictureBoxRegion1.Image = srcImg;
                    ucPictureBoxRegion1.GlobRect = m_searchViewModel.GlobRect;
                    ucPictureBoxRegion1.Visible = true;
                }
            }
        }
        private void ucPictureBoxRegion1_GlobRectChanged(object sender, EventArgs e)
        {
            Image srcImg = Image.FromFile(m_searchViewModel.ComparePicturePath);
            Image srcImg2 = AppUtil.Common.Utils.CutImage(srcImg, ucPictureBoxRegion1.GlobRect);
            m_searchViewModel.GlobRect = ucPictureBoxRegion1.GlobRect;
            pictureEdit2.Image = srcImg2;
            labelControlVehicle.Text = "当前目标：无";

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(m_searchViewModel.ComparePicturePath))
                return;

            if (ucPictureBoxRegion1.Visible)
            {
                ucPictureBoxRegion1.Visible = false;
            }
            else
            { 
                Image srcImg = Image.FromFile(m_searchViewModel.ComparePicturePath);
                ucPictureBoxRegion1.Image = srcImg;
                ucPictureBoxRegion1.GlobRect = m_searchViewModel.GlobRect;
                ucPictureBoxRegion1.Visible = true;
            } 
            ucPictureBoxRegion1.Invalidate();
        }
        private void ucPictureBoxShowRegion1_GlobRectChanged(object sender, EventArgs e)
        {
            Image srcImg = Image.FromFile(m_searchViewModel.ComparePicturePath);
            Image srcImg2 = AppUtil.Common.Utils.CutImage(srcImg, ucPictureBoxShowRegion1.GlobRect);
            m_searchViewModel.GlobRect = ucPictureBoxShowRegion1.GlobRect;
            pictureEdit2.Image = srcImg2;
            labelControlVehicle.Text = "当前目标：无";
            foreach (AnalyseRecord item in m_featureList)
            {
                 if (item.VehicleRegion.Equals(m_searchViewModel.GlobRect)) 
                 {
                     labelControlVehicle.Text = "当前目标："+item.ToShortString();
                     m_searchViewModel.PlateNumber = item.PlateNumber;
                     //m_searchViewModel.Weight = 100;
                     //m_searchViewModel.ResultCount = 100;
                     //ucSearchSettings1.Weight = m_searchViewModel.Weight;
                     ucSearchSettings1.PlateNo = m_searchViewModel.PlateNumber;
                     //ucSearchSettings1.ResultCount = m_searchViewModel.ResultCount;
                     labelControlAdvString.Text = ucSearchSettings1.ToString();// "车牌[" + item.PlateNumber + "]优先，权重100%";
                     break;
                 } 
            }
            //m_featureList.ForEach(item => { if (item.VehicleRegion.Equals(m_searchViewModel.GlobRect)) { labelControlVehicle.Text = "当前目标：" + item.GetPlateNumber() + " " + item.ParentBrandInfo.Name; } });
        }

        private void simpleButtonComit_Click(object sender, EventArgs e)
        {
            m_searchViewModel.Commit(true);

        }


        public void Init()
        {
            ResetAll();

            Framework.Container.Instance.VVMDataBindings.AddBinding(this.ucSearchSettings1, "PlateNo", m_searchViewModel, "PlateNumber");
            Framework.Container.Instance.VVMDataBindings.AddBinding(this.ucSearchSettings1, "Weight", m_searchViewModel, "Weight");
            Framework.Container.Instance.VVMDataBindings.AddBinding(this.ucSearchSettings1, "ResultCount", m_searchViewModel, "ResultCount");


            ucSearchPara_Camera1.PropertyChanged += ucSearchPara_Camera1_PropertyChanged;
            m_searchViewModel.SelectedCameras = ucSearchPara_Camera1.SelectedValue as CameraInfo[];

            ucSearchPara_StartTime1.PropertyChanged += ucSearchPara_StartTime1_PropertyChanged;
            m_searchViewModel.StartTime = (DateTime)ucSearchPara_StartTime1.SelectedValue;

            ucSearchPara_EndTime1.PropertyChanged += ucSearchPara_EndTime1_PropertyChanged;
            m_searchViewModel.EndTime = (DateTime)ucSearchPara_EndTime1.SelectedValue;
            //ShowVehicle();

            ucPlateGroupSubResultPage1.Init();
            ucNoGroupSubResultPage1.Init();
        }

        internal void ResetAll()
        {

            if (Framework.Environment.RealTimeVersion)
            {
                List<CameraInfo> alllist = new List<CameraInfo>();
                alllist.AddRange(Framework.Environment.CameraList);
                ucSearchPara_Camera1.Init(alllist.ToArray());
            }
            else
            {
                List<CameraInfo> alllist = Framework.Container.Instance.TaskManager.GetAllTasks().ConvertAll<CameraInfo>(it => new CameraInfo() { ID = it.TaskId, FullName = it.TaskName });
                ucSearchPara_Camera1.Init(alllist.ToArray());
            }

            ucSearchSettings1.Init();

            if (Framework.Environment.RealTimeVersion)
            {
                labelControl2.Visible = true;
                ucSearchPara_StartTime1.Visible = true;
                ucSearchPara_EndTime1.Visible = true;
                checkButtonToday.Visible = true;
                checkButtonYesterday.Visible = true;
                checkButtonWeek.Visible = true;
                checkButtonMonth.Visible = true;
                checkButtonOther.Visible = true;
            ucSearchPara_StartTime1.Init(DateTime.Today);
            ucSearchPara_EndTime1.Init(DateTime.Today.AddDays(1).AddSeconds(-1));
            ucSearchPara_EndTime1.SelectedIndex = 0;
            ucSearchPara_StartTime1.SelectedIndex = 0;
            }
            else
            {
                labelControl2.Visible = false;
                ucSearchPara_StartTime1.Visible = false;
                ucSearchPara_EndTime1.Visible = false;
                checkButtonToday.Visible = false;
                checkButtonYesterday.Visible = false;
                checkButtonWeek.Visible = false;
                checkButtonMonth.Visible = false;
                checkButtonOther.Visible = false;
            ucSearchPara_StartTime1.Init(DateTime.MinValue);
            ucSearchPara_EndTime1.Init(DateTime.MaxValue);
            ucSearchPara_EndTime1.SelectedIndex = 0;
            ucSearchPara_StartTime1.SelectedIndex = 0;
            }

        }

        void ucSearchPara_EndTime1_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            m_searchViewModel.EndTime = (DateTime)ucSearchPara_EndTime1.SelectedValue;
        }

        void ucSearchPara_StartTime1_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            m_searchViewModel.StartTime = (DateTime)ucSearchPara_StartTime1.SelectedValue;
        }

        void ucSearchPara_Camera1_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            m_searchViewModel.SelectedCameras = ucSearchPara_Camera1.SelectedValue as CameraInfo[];
            if (!Framework.Environment.RealTimeVersion)
            {
                DateTime st = DateTime.MaxValue;
                DateTime et = DateTime.MinValue;

                var tasklist = Framework.Container.Instance.TaskManager.GetAllTasks();
                List<CameraInfo> conparelist = new List<CameraInfo>(m_searchViewModel.SelectedCameras);
                if (conparelist.Count == 0)
                {
                    foreach (var item in tasklist)
                    {
                        if (item.StartAnalyseTime != new DateTime() && item.StartAnalyseTime < st)
                            st = item.StartAnalyseTime;

                        if (item.FinishedTime != new DateTime() && item.FinishedTime > et)
                            et = item.FinishedTime;
                    }
                }
                else
                {
                    foreach (var item in tasklist)
                    {
                        if (new List<CameraInfo>(m_searchViewModel.SelectedCameras).Exists(it => it.ID == item.TaskId))
                        {
                            if (item.StartAnalyseTime != new DateTime() && item.StartAnalyseTime < st)
                                st = item.StartAnalyseTime;

                            if (item.FinishedTime != new DateTime() && item.FinishedTime > et)
                                et = item.FinishedTime;
                        }
                    }
                }


                if (st == DateTime.MaxValue)
                    st = DateTime.MinValue;
                if (et == DateTime.MinValue)
                    et = DateTime.Now;

                ucSearchPara_StartTime1.SelectedValue = st;
                m_searchViewModel.StartTime = st;
                ucSearchPara_EndTime1.SelectedValue = et;
                m_searchViewModel.EndTime = et;

            }
        }


        void ViewModel_PreNewSearch(Dictionary<string, string> settings)
        {
            if (m_compareViewModel.ResultPageInfo != null)
            {
                //Framework.Container.Instance.VVMDataBindings.RemoveBinding(m_compareViewModel.ResultPageInfo, "PageIndex", this.comboBoxPage);

                //Framework.Container.Instance.VVMDataBindings.RemoveBinding(m_compareViewModel.ResultPageInfo, "TotalRecords", this.lblCount);

                //Framework.Container.Instance.VVMDataBindings.RemoveBinding(m_compareViewModel.ResultPageInfo, "PageCount", this.lblControlPageCount);

                //Framework.Container.Instance.VVMDataBindings.RemoveBinding(m_compareViewModel.ResultPageInfo, "CurrentPageCount", this.lblCtrlCurrentPageCount);

                //Framework.Container.Instance.VVMDataBindings.RemoveBinding(m_compareViewModel.ResultPageInfo, "CanNextPage", this.btnNextPage);

                //Framework.Container.Instance.VVMDataBindings.RemoveBinding(m_compareViewModel.ResultPageInfo, "CanPrePage", this.btnPrePage);

                //this.comboBoxPage.Properties.Items.Clear();
            }
            //ShowVehicle();
            //ucPlateGroupSubResultPage1.SetVehicleData(null);
            checkButtonAll.Checked = true;
            lblCtrlFileName.Text = "";
            ucPlateGroupSubResultPage1.SetVehicleData(null);//.Init();
            ucNoGroupSubResultPage1.SetVehicleData(null);//.Init();
            ucNoGroupSubResultPage1.BringToFront();
            pictureBoxLoading.Visible = true;
            simpleButtonComit.Enabled = false; 
            pictureBoxLoading.Refresh();
        }

        void ViewModel_SearchResult(object sender, EventArgs e)
        {
            bool isfirst = (bool)sender;
            if (isfirst)
            {
                Debug.Assert(m_compareViewModel.ResultPageInfo != null);

               // this.comboBoxPage.Properties.Items.AddRange(m_compareViewModel.ResultPageInfo.GetPageIds());

               // Framework.Container.Instance.VVMDataBindings.AddBinding(this.comboBoxPage,
               //"SelectedIndex", m_compareViewModel.ResultPageInfo, "PageIndex");

                //Framework.Container.Instance.VVMDataBindings.AddBinding(this.lblCount,
             //"Text", m_compareViewModel.ResultPageInfo, "TotalRecords");

              //  Framework.Container.Instance.VVMDataBindings.AddBinding(this.lblControlPageCount,
              //"Text", m_compareViewModel.ResultPageInfo, "PageCount");

               // Framework.Container.Instance.VVMDataBindings.AddBinding(this.lblCtrlCurrentPageCount,
                //"Text", m_compareViewModel.ResultPageInfo, "CurrentPageCount");

              //  Framework.Container.Instance.VVMDataBindings.AddBinding(this.btnNextPage,
              // "Enabled", m_compareViewModel.ResultPageInfo, "CanNextPage");

              //  Framework.Container.Instance.VVMDataBindings.AddBinding(this.btnPrePage,
              //"Enabled", m_compareViewModel.ResultPageInfo, "CanPrePage");

                ucPlateGroupSubResultPage1.SetVehicleData(m_compareViewModel.AnalyseResults);
                ucNoGroupSubResultPage1.SetVehicleData(m_compareViewModel.AnalyseResults);
                pictureBoxLoading.Visible = false;
                simpleButtonComit.Enabled = true;
                pictureBoxLoading.Refresh();
            }
            //ShowVehicle();
        }


        private void checkButtonToday_CheckedChanged(object sender, EventArgs e)
        {
            checkButtonToday.ForeColor = Color.Silver;
            checkButtonYesterday.ForeColor = Color.Silver;
            checkButtonWeek.ForeColor = Color.Silver;
            checkButtonMonth.ForeColor = Color.Silver;
            checkButtonOther.ForeColor = Color.Silver;
            if (checkButtonToday.Checked)
            {
                checkButtonToday.ForeColor = Color.Black;
                ucSearchPara_StartTime1.Init( DateTime.Today);
                ucSearchPara_EndTime1.Init( DateTime.Today.AddDays(1).AddSeconds(-1));
            }

        }

        private void checkButtonYesterday_CheckedChanged(object sender, EventArgs e)
        {
            checkButtonToday.ForeColor = Color.Silver;
            checkButtonYesterday.ForeColor = Color.Silver;
            checkButtonWeek.ForeColor = Color.Silver;
            checkButtonMonth.ForeColor = Color.Silver;
            checkButtonOther.ForeColor = Color.Silver;

            if (checkButtonYesterday.Checked)
            {
                checkButtonYesterday.ForeColor = Color.Black;
                ucSearchPara_StartTime1.Init( DateTime.Today.AddDays(-1));
                ucSearchPara_EndTime1.Init( DateTime.Today.AddSeconds(-1));
            }

        }

        private void checkButtonWeek_CheckedChanged(object sender, EventArgs e)
        {
            checkButtonToday.ForeColor = Color.Silver;
            checkButtonYesterday.ForeColor = Color.Silver;
            checkButtonWeek.ForeColor = Color.Silver;
            checkButtonMonth.ForeColor = Color.Silver;
            checkButtonOther.ForeColor = Color.Silver;

            if (checkButtonWeek.Checked)
            {
                checkButtonWeek.ForeColor = Color.Black;
                ucSearchPara_StartTime1.Init( DateTime.Today.AddDays(-7));
                ucSearchPara_EndTime1.Init(DateTime.Today.AddDays(1).AddSeconds(-1));
            }
        }

        private void checkButtonMonth_CheckedChanged(object sender, EventArgs e)
        {
            checkButtonToday.ForeColor = Color.Silver;
            checkButtonYesterday.ForeColor = Color.Silver;
            checkButtonWeek.ForeColor = Color.Silver;
            checkButtonMonth.ForeColor = Color.Silver;
            checkButtonOther.ForeColor = Color.Silver;

            if (checkButtonMonth.Checked)
            {
                checkButtonMonth.ForeColor = Color.Black;
                ucSearchPara_StartTime1.Init(DateTime.Today.AddDays(-30));
                ucSearchPara_EndTime1.Init(DateTime.Today.AddDays(1).AddSeconds(-1));
            }



        }

        private void checkButtonOther_CheckedChanged(object sender, EventArgs e)
        {
            checkButtonToday.ForeColor = Color.Silver;
            checkButtonYesterday.ForeColor = Color.Silver;
            checkButtonWeek.ForeColor = Color.Silver;
            checkButtonMonth.ForeColor = Color.Silver;
            checkButtonOther.ForeColor = Color.Silver;

            if (checkButtonOther.Checked)
            {
                checkButtonOther.ForeColor = Color.Black;
                ucSearchPara_StartTime1.Init( DateTime.Now.AddHours(-1));
                ucSearchPara_EndTime1.Init( DateTime.Now.AddMinutes(5));
            }



        }

        private void checkButton1_CheckedChanged(object sender, EventArgs e)
        {
            checkButtonAll.ForeColor = Color.Silver;
            checkButtonPlateGroup.ForeColor = Color.Silver;

            if (checkButtonAll.Checked)
            {
                checkButtonAll.ForeColor = Color.Black;
            }

        }

        private void checkButtonPlateGroup_CheckedChanged(object sender, EventArgs e)
        {
            checkButtonAll.ForeColor = Color.Silver;
            checkButtonPlateGroup.ForeColor = Color.Silver;

            if (checkButtonPlateGroup.Checked)
            {
                checkButtonPlateGroup.ForeColor = Color.Black;
            }

        }


        //private string GetExportPath(bool includeDiagram, bool includePic)
        //{
        //    string path = string.Empty;
        //    if (includeDiagram)
        //    {
        //        using (SaveFileDialog dlg = new SaveFileDialog())
        //        {
        //            dlg.Filter = Framework.Environment.ResultExportAsXls ? "*.xls|*.xls" : "*.csv|*.csv";
        //            if (DialogResult.OK == dlg.ShowDialog())
        //            {
        //                path = dlg.FileName;
        //            }
        //        }
        //    }
        //    else if (includePic)
        //    {
        //        using (FolderBrowserDialog dlg = new FolderBrowserDialog())
        //        {
        //            if (DialogResult.OK == dlg.ShowDialog())
        //            {
        //                path = dlg.SelectedPath;
        //            }
        //        }
        //    }
        //    return path;
        //}


        //private void simpleButtonExport_Click(object sender, EventArgs e)
        //{
        //    bool includeDiagram = false, includePic = true;
        //    string path = GetExportPath(includeDiagram, includePic);

        //    if (string.IsNullOrEmpty(path))
        //    {
        //        return;
        //    }

        //    try
        //    {
        //        m_compareViewModel.ExportAll(gridControlForExportAll, path, includeDiagram, includePic);

        //        Framework.Container.Instance.EvtAggregator.GetEvent<AnalyseMessageEvent>().Publish(
        //            new Tuple<uint, string>(10, string.Format("导出全部记录到 {0} 成功", path)));
        //        Framework.Container.Instance.InteractionService.ShowMessageBox("导出全部记录成功");
        //    }
        //    catch (Exception ex)
        //    {
        //        Framework.Container.Instance.EvtAggregator.GetEvent<AnalyseMessageEvent>().Publish(
        //             new Tuple<uint, string>(10, string.Format("导出全部记录到 {0} 失败", path)));
        //        Framework.Container.Instance.InteractionService.ShowMessageBox("导出全部记录失败");

        //        MyLog4Net.Container.Instance.Log.Error("导出全部结果出错", ex);
        //    }
        //}



    }
}
