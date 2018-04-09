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
    public partial class ucSearchSettingsContainer : DevExpress.XtraEditors.XtraUserControl
    {
        #region Events
        
        public event EventHandler SearchClicked;
        public event EventHandler CancelClicked;

        public event EventHandler ToShowPopup;
        public event EventHandler ToHidePopup;

        public event Action<long, bool, long[]> SelectedBrandChanged;
        public event Action<long, bool, long[]> VehilceModelDropdownClosed;
        public event Action<long,long> FocusedModelChanged;

        #endregion

        #region Fields
        
        private CheckedListBoxControl m_listBoxVehicleModel;

        private SearchSettingsViewModel m_ViewModel;

        private ucSearchPara[] m_ucSearchParas;

        #endregion

        internal SearchSettingsViewModel ViewModel
        {
            get { return m_ViewModel; }
            set
            {
                if (m_ViewModel != value)
                {
                    if (m_ViewModel != null)
                    {
                        m_ViewModel.TasksChanged -= new EventHandler(ViewModel_TasksChanged);
                    }
                    m_ViewModel = value;

                    if (m_ViewModel != null)
                    {
                        m_ViewModel.TasksChanged += new EventHandler(ViewModel_TasksChanged);
                    }
                }
            }
        }

        public ucSearchSettingsContainer()
        {
            InitializeComponent();
            m_ucSearchParas = new ucSearchPara[]{
                this.ucSearchPara_Camera1,
                this.ucSearchPara_StartTime1,
                this.ucSearchPara_EndTime1,
                this.ucSearchPara_VehiclePlate1,
                this.ucSearchPara_VehicleColor1,
                this.ucSearchPara_PlateColor1,
                this.ucSearchPara_PlateType1,
                this.ucSearchPara_VehicleType1,
                this.ucSearchPara_VehicleDetailType1,
                this.ucSearchPara_Brand1,
                this.ucSearchPara_Behavior_DriverBeltWearing,
                this.ucSearchPara_Behavior_CoDriverBeltWearing,
                this.ucSearchPara_Behavior_PhoneCall,
                this.ucSearchPara_Behavior_DriverShielding,
                this.ucSearchPara_Behavior_CoDriverShielding
            };
        }

        #region Private helper functions
        
        //private void UpdateVehiclePic(VehicleModelInfo modelInfo)
        //{
        //    Image image = null;

        //    if (modelInfo != null && modelInfo.Model != null)
        //    {
        //        try
        //        {
        //            image = Framework.Container.Instance.VehicleInfoService.GetVehicleImage(
        //                modelInfo.Model, (byte)this.radioGroup1.EditValue == 0);

        //            pictureEdit2.ToolTip = string.Format("车型编号: {2}, 前视图: {0} \r\n 后视图: {1}",
        //           modelInfo.Model.FrontPic, modelInfo.Model.BackPic, modelInfo.Model.Id);
        //        }
        //        catch (Exception ex)
        //        {
        //            Debug.Assert(false, ex.Message);
        //        }
        //    }
        //    else
        //    {
        //        pictureEdit2.ToolTip = string.Empty;
        //    }

        //    pictureEdit2.Image = image;
        //    pictureEdit2.Properties.SizeMode = PictureSizeMode.Zoom;
        //}

        private void FillupVehicleModels()
        {
            //bool hasModel = m_ViewModel.VehicleModels != null && m_ViewModel.VehicleModels.Length > 0;
            //checkedComboBoxEdit1.Enabled = hasModel;
            //if (hasModel)
            //{
            //    foreach (VehicleBrand model in m_ViewModel.VehicleModels)
            //    {
            //        checkedComboBoxEdit1.Properties.Items.Add(new VehicleModelInfo(model), CheckState.Checked);
            //    }
            //}
        }

        private void CustomizeSearchSettings()
        {
            ucSearchPara lastVisibleCtrl = m_ucSearchParas[m_ucSearchParas.Length - 1];
            if (!string.IsNullOrEmpty(Framework.Environment.SearchFeatureSettings))
            {
                for (int i = 0; i < Framework.Environment.SearchFeatureSettings.Length; i++)
                {
                    if (i > m_ucSearchParas.Length - 1)
                    {
                        break;
                    }

                    m_ucSearchParas[i].Visible = Framework.Environment.SearchFeatureSettings[i] == '1';
                }
            }
            for (int i = 1; i <= m_ucSearchParas.Length; i++)
            {
                if (m_ucSearchParas[m_ucSearchParas.Length - i].Visible)
                {
                    this.flowLayoutPanel1.Height = m_ucSearchParas[m_ucSearchParas.Length - i].Bottom + 4;
                    break;
                }
            }
            this.Height = flowLayoutPanel1.Height + 6;
        }

        #endregion

        public void Init()
        {
            ResetAll();

            Framework.Container.Instance.VVMDataBindings.AddBinding(this.ucSearchPara_VehicleDetailType1, "SelectedIndex", m_ViewModel, "NVehicleDetailType");
            Framework.Container.Instance.VVMDataBindings.AddBinding(this.ucSearchPara_VehicleType1, "SelectedIndex", m_ViewModel, "NVehicleType");
            Framework.Container.Instance.VVMDataBindings.AddBinding(this.ucSearchPara_PlateType1, "SelectedIndex", m_ViewModel, "NVehiclePlateType");

            Framework.Container.Instance.VVMDataBindings.AddBinding(this.ucSearchPara_VehiclePlate1, "VehicleNumber", m_ViewModel, "PlateNumber");

            Framework.Container.Instance.VVMDataBindings.AddBinding(this.ucSearchPara_Behavior_DriverBeltWearing, "SelectedIndex", m_ViewModel, "DriverBelt");
            Framework.Container.Instance.VVMDataBindings.AddBinding(this.ucSearchPara_Behavior_CoDriverBeltWearing, "SelectedIndex", m_ViewModel, "CoDriverBelt");
            Framework.Container.Instance.VVMDataBindings.AddBinding(this.ucSearchPara_Behavior_PhoneCall, "SelectedIndex", m_ViewModel, "DriverPhoneCall");

            Framework.Container.Instance.VVMDataBindings.AddBinding(this.ucSearchPara_Behavior_DriverShielding, "SelectedIndex", m_ViewModel, "DriverShielding");
            Framework.Container.Instance.VVMDataBindings.AddBinding(this.ucSearchPara_Behavior_CoDriverShielding, "SelectedIndex", m_ViewModel, "CoDriverShielding");


            ucSearchPara_VehicleColor1.PropertyChanged += new PropertyChangedEventHandler(ucSearchPara_VehicleColor1_PropertyChanged);
            ucSearchPara_PlateColor1.PropertyChanged += new PropertyChangedEventHandler(ucSearchPara_VehicleColor1_PropertyChanged);
            ucSearchPara_VehicleType1.PropertyChanged+=ucSearchPara_VehicleType1_PropertyChanged;
            ucSearchPara_Brand1.SelectedBrandChanged += new Action<long, bool, long[]>(ucSearchPara_Brand1_SelectedBrandChanged);
            ucSearchPara_Brand1.FocusedModelChanged += new Action<long,long>(ucSearchPara_Brand1_FocusedModelChanged);
            ucSearchPara_Brand1.VehilceModelDropdownClosed += new Action<long, bool, long[]>(ucSearchPara_Brand1_VehilceModelDropdownClosed);

            ucSearchPara_Camera1.PropertyChanged += ucSearchPara_Camera1_PropertyChanged;
            m_ViewModel.SelectedCameras = ucSearchPara_Camera1.SelectedValue as CameraInfo[];

            ucSearchPara_StartTime1.PropertyChanged += ucSearchPara_StartTime1_PropertyChanged;
            m_ViewModel.StartTime = (DateTime)ucSearchPara_StartTime1.SelectedValue;

            ucSearchPara_EndTime1.PropertyChanged += ucSearchPara_EndTime1_PropertyChanged;
            m_ViewModel.EndTime = (DateTime)ucSearchPara_EndTime1.SelectedValue;
        }

        void ucSearchPara_VehicleType1_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            ucSearchPara_VehicleDetailType1.Init(DataModel.Constant.GetVehicleDetailType(ucSearchPara_VehicleType1.SelectedIndex));
            ucSearchPara_VehicleDetailType1.Select();
        }

        void ucSearchPara_EndTime1_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            m_ViewModel.EndTime = (DateTime)ucSearchPara_EndTime1.SelectedValue;
        }

        void ucSearchPara_StartTime1_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            m_ViewModel.StartTime = (DateTime)ucSearchPara_StartTime1.SelectedValue;
        }

        void ucSearchPara_Camera1_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            m_ViewModel.SelectedCameras = ucSearchPara_Camera1.SelectedValue as CameraInfo[];
            if (!Framework.Environment.RealTimeVersion)
            {
                DateTime st = DateTime.MaxValue;
                DateTime et = DateTime.MinValue;

                var tasklist = Framework.Container.Instance.TaskManager.GetAllTasks();
                List<CameraInfo> conparelist = new List<CameraInfo>(m_ViewModel.SelectedCameras);
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
                        if (new List<CameraInfo>(m_ViewModel.SelectedCameras).Exists(it => it.ID == item.TaskId))
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
                m_ViewModel.StartTime = st;
                ucSearchPara_EndTime1.SelectedValue = et;
                m_ViewModel.EndTime = et;

            }
        }


        #region Event handlers

        void ucSearchPara_Brand1_VehilceModelDropdownClosed(long arg1, bool arg2, long[] arg3)
        {
            if(VehilceModelDropdownClosed != null)
            {
                VehilceModelDropdownClosed(arg1, arg2, arg3);
            }
        }

        void ucSearchPara_Brand1_FocusedModelChanged(long arg1,long arg2)
        {
            if (FocusedModelChanged != null)
            {
                FocusedModelChanged(arg1,arg2);
            }
        }

        void ucSearchPara_Brand1_SelectedBrandChanged(long arg1, bool arg2, long[] arg3)
        {
            if (SelectedBrandChanged != null)
            {
                SelectedBrandChanged(arg1, arg2, arg3);
            }
        }

        void ucSearchPara_VehicleColor1_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender == ucSearchPara_PlateColor1)
            {
                m_ViewModel.PlateColor = (VehicleHelper.DataModel.VehiclePropertyInfo)ucSearchPara_PlateColor1.SelectedValue;
            }
            else if (sender == ucSearchPara_VehicleColor1)
            {
                m_ViewModel.VehicleColor = (VehicleHelper.DataModel.VehiclePropertyInfo)ucSearchPara_VehicleColor1.SelectedValue;
            }
        }

        private void ucSearchSettingsContainer_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }
            CustomizeSearchSettings();
        }
      
        void ViewModel_TasksChanged(object sender, EventArgs e)
        {
            //ucSearchPara_Task1.Update(m_ViewModel.Tasks);
            //ucSearchPara_Camera1.Update(Framework.Environment.CameraList.ToArray());
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
        


        #endregion

        internal void ResetAll()
        {
            ucSearchPara_Behavior_PhoneCall.Init(Constant.PropertyInfo_PhoneCalling);
            ucSearchPara_Behavior_DriverShielding.Init(Constant.PropertyInfo_SunlightShielding);
            ucSearchPara_Behavior_CoDriverShielding.Init(Constant.PropertyInfo_SunlightShielding);
            ucSearchPara_Behavior_DriverBeltWearing.Init(Constant.PropertyInfo_SafeBeltWear);
            ucSearchPara_Behavior_CoDriverBeltWearing.Init(Constant.PropertyInfo_SafeBeltWear);

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

            ucSearchPara_VehicleDetailType1.Init(Constant.GetVehicleDetailType(-1));
            ucSearchPara_VehicleType1.Init(Constant.PropertyInfo_VehicleType);
            ucSearchPara_PlateType1.Init(Constant.PropertyInfo_PlateType);
            ucSearchPara_Brand1.Init(null);
            ucSearchPara_PlateColor1.Init(Constant.PropertyInfo_PlateColor);
            ucSearchPara_VehicleColor1.Init(Constant.PropertyInfo_VehicleColor);
            ucSearchPara_VehiclePlate1.Init(null);


            ucSearchPara_Behavior_PhoneCall.SelectedIndex = -1;
            ucSearchPara_Behavior_DriverShielding.SelectedIndex = -1;
            ucSearchPara_Behavior_CoDriverShielding.SelectedIndex = -1;
            ucSearchPara_Behavior_DriverBeltWearing.SelectedIndex = -1;
            ucSearchPara_Behavior_CoDriverBeltWearing.SelectedIndex = -1;
            //ucSearchPara_Camera1.SelectedValue = null;
            //ucSearchPara_Task1.SelectedValue = null;
            ucSearchPara_VehicleDetailType1.SelectedIndex = -1;
            ucSearchPara_VehicleType1.SelectedIndex = -1;
            ucSearchPara_PlateType1.SelectedIndex = -1;
            ucSearchPara_Brand1.SelectedIndex = 0;
            ucSearchPara_PlateColor1.SelectedIndex = -1;
            ucSearchPara_VehicleColor1.SelectedIndex = -1;
            ucSearchPara_VehiclePlate1.SelectedIndex = -1;

            if (Framework.Environment.RealTimeVersion)
            {
                ucSearchPara_StartTime1.Visible = true;
                ucSearchPara_EndTime1.Visible = true;
            ucSearchPara_StartTime1.Init(DateTime.Today);
            ucSearchPara_EndTime1.Init(DateTime.Today.AddDays(1).AddSeconds(-1));
            ucSearchPara_StartTime1.SelectedIndex = 0;
            ucSearchPara_EndTime1.SelectedIndex = 0;
            }
            else
            {
                ucSearchPara_StartTime1.Visible = false;
                ucSearchPara_EndTime1.Visible = false;
            ucSearchPara_StartTime1.Init(DateTime.MinValue);
            ucSearchPara_EndTime1.Init(DateTime.MaxValue);
            ucSearchPara_StartTime1.SelectedIndex = 0;
            ucSearchPara_EndTime1.SelectedIndex = 0;
            }
        }
    }
}
