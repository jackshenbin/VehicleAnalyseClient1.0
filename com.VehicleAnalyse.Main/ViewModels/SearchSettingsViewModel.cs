using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppUtil;
using System.ComponentModel;
using System.Data;
using com.VehicleAnalyse.DataModel;
using System.IO;
using System.Drawing;
using com.VehicleAnalyse.Main.Views;
using System.Windows.Forms;
using AppUtil.Controls;
using System.Data.Objects;
using DevExpress.XtraGrid;
using com.VehicleAnalyse.Main.Framework;
using Microsoft.Practices.Prism.Events;
using com.VehicleAnalyse.Service.DAO;
using VehicleHelper.DataModel;

namespace com.VehicleAnalyse.Main.ViewModels
{
    internal class SearchSettingsViewModel : ViewModelBase
    {
        public event EventHandler TasksChanged;

        #region Fields

        private AnalyseTask[] m_Tasks;

        private CameraInfo[] m_Cameras;

        private DateTime m_StartTime;

        private DateTime m_EndTime;
        private string m_PlateNumber;

        private int m_NVehicleDetailType;
        private int m_NVehicleType;

        private int m_NVehiclePlateType;

        private AnalyseRecord m_SelectedAnalyseRecord;

        private List<AnalyseRecord> m_Records;

        private string m_SQLQuery;

        private ObjectParameter[] m_SQLParas;

        private EditImageForm m_EditImageForm;

        private PageInfo m_ResultPageInfo;

        private bool m_HasResult = false;

        private FileAccessBase m_FileAccess;

        private VehiclePropertyInfo[] m_VehicleModels;

        private bool m_selectAllVehicleModels = true;

        //private List<ModelPropertyInfo> m_vehicleDetailTypes;
        //private List<ModelPropertyInfo> m_vehicleTypes;
        //private List<ModelPropertyInfo> m_plateTypes;

        private VehicleBrandInfo m_Brand;

        #endregion

        #region Properties
        public string ComparePicturePath
        {
            get;
            set;
        }
        public CameraInfo[] SelectedCameras
        {
            get { return m_Cameras; }
            set { m_Cameras = value; }
        }

        public AnalyseTask[] SelectedTasks
        {
            get;
            set;
        }

        public Rectangle GlobRect
        {
            get;
            set;
        }
        public DateTime StartTime
        {
            get { return m_StartTime; }
            set { m_StartTime = value; }
        }

        public DateTime EndTime
        {
            get { return m_EndTime; }
            set { m_EndTime = value; }
        }

        public int NVehicleDetailType
        {
            get
            {
                return m_NVehicleDetailType;
            }
            set
            {
                if (m_NVehicleDetailType != value)
                {
                    m_NVehicleDetailType = value;
                    // m_SearchPara[SDKConstant.dwVehicleDetailType] = value;
                    // RaisePropertyChangedEvent("NVehicleDetailType");
                }
            }
        }
        public int NVehicleType
        {
            get
            {
                return m_NVehicleType;
            }
            set
            {
                if (m_NVehicleType != value)
                {
                    m_NVehicleType = value;
                    // m_SearchPara[SDKConstant.dwVehicleDetailType] = value;
                    // RaisePropertyChangedEvent("NVehicleDetailType");
                }
            }
        }

        //public List<ModelPropertyInfo>VehicleDetailTypes
        //{
        //    get
        //    {
        //        if (m_vehicleDetailTypes == null)
        //        {
        //            m_vehicleDetailTypes = new List<ModelPropertyInfo>();
        //            m_vehicleDetailTypes.Add(DataModel.Constant.PropertyInfo_NOTSPECIFIED);
        //            m_vehicleDetailTypes.AddRange(DataModel.Constant.SDT_PropertyInfo_VehicleDetailType.Values);
        //        }
        //        return m_vehicleDetailTypes;
        //    }
        //}

        //public List<ModelPropertyInfo>PlateTypes
        //{
        //    get
        //    {
        //        if (m_plateTypes == null)
        //        {
        //            m_plateTypes = new List<ModelPropertyInfo>();
        //            m_plateTypes.Add(DataModel.Constant.PropertyInfo_NOTSPECIFIED);
        //            m_plateTypes.AddRange(DataModel.Constant.SDT_PropertyInfo_PlateType.Values);
        //        }
        //        return m_plateTypes;
        //    }
        //}

        //public List<ModelPropertyInfo>VehicleTypes
        //{
        //    get
        //    {
        //        if (m_vehicleTypes == null)
        //        {
        //            m_vehicleTypes = new List<ModelPropertyInfo>();
        //            m_vehicleTypes.Add(DataModel.Constant.PropertyInfo_NOTSPECIFIED);
        //            m_vehicleTypes.AddRange(DataModel.Constant.SDT_PropertyInfo_VehicleType.Values);
        //        }
        //        return m_vehicleTypes;
        //    }
        //}

        public int NVehiclePlateType
        {
            get
            {
                return m_NVehiclePlateType;
            }
            set
            {
                if (m_NVehiclePlateType != value)
                {
                    m_NVehiclePlateType = value;
                    //m_SearchPara[SDKConstant.dwVehiclePlateStruct] = value;
                    //RaisePropertyChangedEvent("NVehiclePlateType");
                }
            }
        }

        public string PlateNumber
        {
            get { return m_PlateNumber; }
            set
            {
                m_PlateNumber = value;
                // m_SearchPara[SDKConstant.szVehiclePlateName] = value;
            }
        }
        public int ResultCount
        {
            get;
            set;
        }

        public int Weight
        {
            get;
            set;
        }

        public VehicleHelper.DataModel.VehiclePropertyInfo PlateColor
        {
            get;
            set;
        }

        public VehicleHelper.DataModel.VehiclePropertyInfo VehicleColor
        {
            get;
            set;
        }
        public VehicleBrandInfo Brand
        {
            get { return m_Brand; }
            set
            {
                if (m_Brand != value)
                {
                    m_Brand = value;
                    UpdateVehilceModels();
                    // m_SearchPara[SDKConstant.dwVehicleLogo] = value;
                }
            }
        }

        //public int ResultType
        //{
        //    get { return m_ResultType; }
        //    set { m_ResultType = value; }
        //}

        public int DriverBelt
        {
            get;
            set;
        }

        public int CoDriverBelt
        {
            get;
            set;
        }

        public int DriverPhoneCall
        {
            get;
            set;
        }

        public int DriverShielding
        {
            get;
            set;
        }

        public int CoDriverShielding
        {
            get;
            set;
        }

        public AnalyseTask[] Tasks
        {
            get { return m_Tasks; }
            set { m_Tasks = value; }
        }

        public string FileName
        { get; set; }

        //public VehicleBrand[] VehicleModels
        //{
        //    get { return m_VehicleModels; }
        //    set { }
        //}

        public bool SelectAllVehicleModels
        {
            get { return m_selectAllVehicleModels; }
            set { m_selectAllVehicleModels = value; }
        }

        public VehiclePropertyInfo[] CheckedVehicleModels
        {
            get { return m_VehicleModels; }
            set { m_VehicleModels = value; }
        }

        #endregion

        #region Private helper functions

        private void InitTable()
        {

        }

        //private void AddResultRow(DataTable dt, AnalyseRecord record)
        //{
        //    dt.Rows.Add(new object[]{
        //        record.Id,
        //        m_FileAccess.GetFileName(record.PicPath),
        //        record.PicPath,
        //        record.PlateNumber,
        //        record.VehicleTypeInfo,
        //        record.DetailVehicleTypeInfo,
        //        record.Manufacturer,
        //        record.ParentBrandInfo,
        //        record.BrandInfo,
        //        record.VehicleColorInfo,
        //        record.PlateTypeInfo,
        //        record.PlateColorInfo,
        //        record
        //    });
        //}

        #endregion

        private void UpdateVehilceModels()
        {
            if (m_Brand != null)
            {
                m_VehicleModels = Constant.GetVehicleDetailBrand(m_Brand.ID).ToArray();
            }
            else
            {
                m_VehicleModels = null;
            }
        }

        internal SearchSettingsViewModel()
        {
            InitTable();
            List<AnalyseTask> tasks = Framework.Container.Instance.TaskManager.GetAllTasks();
            if (tasks != null)
            {
                m_Tasks = tasks.ToArray();
            }
            else
            {
                m_Tasks = new AnalyseTask[0];
            }
            PlateColor = Constant.PropertyInfo_NOTSPECIFIED;
            VehicleColor = Constant.PropertyInfo_NOTSPECIFIED;
            DriverBelt = -1;
            CoDriverBelt = -1;
            DriverPhoneCall = -1;
            DriverShielding = -1;
            CoDriverShielding = -1;
            m_NVehicleDetailType = -1;
            m_NVehiclePlateType = -1;
            m_NVehicleType = -1;

            m_PlateNumber = "";
            Weight = 100;
            ResultCount = 100;
            Framework.Container.Instance.EvtAggregator.GetEvent<TaskAddedEvent>().Subscribe(OnTaskChanged, ThreadOption.WinFormUIThread);
            Framework.Container.Instance.EvtAggregator.GetEvent<TaskRemovedEvent>().Subscribe(OnTaskChanged, ThreadOption.WinFormUIThread);
            Framework.Container.Instance.EvtAggregator.GetEvent<TaskModifiedEvent>().Subscribe(OnTaskModifyChanged, ThreadOption.WinFormUIThread);
        }
        public List<AnalyseRecord> GetFeature(Image img)
        {
            return Framework.Container.Instance.TaskManager.GetImageFeature(img);
        }

        //internal bool CommitCompare()
        //{
        //    //m_DTAnalyseResults.Rows.Clear();
        //    //HasResult = false;

        //    if (Task == null)
        //    {
        //        FileName = string.Empty;
        //        RaisePropertyChangedEvent("FileName");
        //        return false;
        //    }
        //    else
        //    {
        //        //System.IO.File.Copy(ComparePicturePath, System.IO.Path.GetTempPath() + "compare.jpg", true);
        //        ModelPropertyInfo vehicleDetailType = VehicleDetailTypes[m_NVehicleDetailType];

        //        if (m_NVehicleDetailType > -1)
        //        {
        //            vehicleDetailType = DataModel.Constant.SDT_PropertyInfo_VehicleDetailType[m_NVehicleDetailType];
        //        }

        //        int vehicleColor = Array.IndexOf(Constant.COLORNAMES_VEHICLEBODY, m_VehicleColor);
        //        int plateColor = Array.IndexOf(Constant.COLORNAMES_VEHICLEPLATE, m_PlateColor);
        //        vehicleColor = Math.Max(vehicleColor, 0);
        //        plateColor = Math.Max(plateColor, 0);

        //        SearchPara searchPara = new SearchPara()
        //        {
        //            Task = this.Task,
        //            PlateColor = m_PlateColor,
        //            PlateNumber = m_PlateNumber,
        //            // VehicleBrand = m_Brand,
        //            VehicleColor = m_VehicleColor,
        //            VehicleDetailType = vehicleDetailType,
        //            SelectAllVehicleModels = this.SelectAllVehicleModels,
        //            // CheckedVehicleModels = this.CheckedVehicleModels,
        //            DriverBelt = this.DriverBelt,
        //            CoDriverBelt = this.CoDriverBelt,
        //            DriverPhoneCall = this.DriverPhoneCall,
        //            DriverShielding = this.DriverShielding,
        //            CoDriverShielding = this.CoDriverShielding
        //        };


        //        Framework.Container.Instance.TaskManager.TaskCompareSearch(searchPara, Image.FromFile(ComparePicturePath));
                
        //        //SearchPara searchPara = new SearchPara()
        //        //    {
        //        //        Task = this.Task,
        //        //        PlateColor = (result.PlateNumber=="11111111")?Constant.COLORNAMES_VEHICLEPLATE[0]:Constant.COLORNAMES_VEHICLEPLATE[Convert.ToInt32(result.PlateColor)],
        //        //        PlateNumber = result.PlateNumber,
        //        //        ResultType = result.ErrorCode,
        //        //        // VehicleBrand = m_Brand,
        //        //        VehicleColor = vc,
        //        //        VehicleDetailType = new ModelPropertyInfo() { ID = Convert.ToInt32(result.DetailVehicleType), Name = "" },
        //        //        SelectAllVehicleModels = true,
        //        //        // CheckedVehicleModels = this.CheckedVehicleModels,
        //        //        DriverBelt = result.DriverWearingSafeBelt.ID,
        //        //        CoDriverBelt = result.CoDriverWearingSafeBelt.ID,
        //        //        DriverPhoneCall = result.DriverPhoneCalling.ID,
        //        //        DriverShielding = result.DriverSunlightShield.ID,
        //        //        CoDriverShielding = result.CoDriverSunlightShield.ID,
        //        //        BrandId = brandid,
        //        //        ParentBrandId = parentid,
        //        //    };

        //        //searchPara.ResultType = ResultType;

        //        //int count = Framework.Container.Instance.TaskManager.GetCompareQueryCount(
        //        //    searchPara, m_Brand, this.CheckedVehicleModels,
        //        //    out m_SQLQuery);

        //        //searchPara.SqlQuery = m_SQLQuery;
        //        //searchPara.ResultCount = count;

        //        Framework.Container.Instance.EvtAggregator.GetEvent<NewSearchEvent>().Publish(searchPara);
        //        return true;
        //    }
        //}
        internal void Commit(bool iscompare = false)
        {
            //m_DTAnalyseResults.Rows.Clear();
            //HasResult = false;

            //if (Tasks == null)
            //{
            //    FileName = string.Empty;
            //    RaisePropertyChangedEvent("FileName");
            //}
            //else
            //{
                //m_FileAccess = FileAccessFactory.GetFileAccess(Task.PictureSource);

            if (iscompare && string.IsNullOrEmpty(ComparePicturePath))
            {
                Framework.Container.Instance.InteractionService.ShowMessageBox("请先选择比对图片");
                return;
            }
                

            VehicleHelper.DataModel.VehiclePropertyInfo vehicleDetailType = Constant.PropertyInfo_VehicleDetailType.Find(it => it.ID == m_NVehicleDetailType);//[m_NVehicleDetailType];
            VehicleHelper.DataModel.VehiclePropertyInfo vehicleType = Constant.PropertyInfo_VehicleType.Find(it => it.ID == m_NVehicleType);
            VehicleHelper.DataModel.VehiclePropertyInfo plateType = Constant.PropertyInfo_PlateType.Find(it => it.ID == m_NVehiclePlateType);

             VehicleHelper.DataModel.VehiclePropertyInfo               driverBelt = Constant.PropertyInfo_SafeBeltWear.Find(it => it.ID == this.DriverBelt);
             VehicleHelper.DataModel.VehiclePropertyInfo  coDriverBelt = Constant.PropertyInfo_SafeBeltWear.Find(it => it.ID == this.CoDriverBelt);
             VehicleHelper.DataModel.VehiclePropertyInfo  driverPhoneCall = Constant.PropertyInfo_PhoneCalling.Find(it => it.ID == this.DriverPhoneCall);
             VehicleHelper.DataModel.VehiclePropertyInfo  driverShielding = Constant.PropertyInfo_SunlightShielding.Find(it => it.ID == this.DriverShielding);
             VehicleHelper.DataModel.VehiclePropertyInfo coDriverShielding = Constant.PropertyInfo_SunlightShielding.Find(it => it.ID == this.CoDriverShielding);

             if (m_StartTime < Constant.DATETIME_MIN)
                 m_StartTime = Constant.DATETIME_MIN;

             if (m_EndTime > Constant.DATETIME_MAX)
                 m_EndTime = Constant.DATETIME_MAX;

               List<string> tasks = new List<string>();
               if (SelectedTasks != null)
                {
                    foreach (AnalyseTask item in SelectedTasks)
                    {
                        tasks.Add(item.TaskId);
                    }
                }
                List<string> cams = new List<string>();
                if (SelectedCameras!=null) 
                {
                    foreach (CameraInfo item in SelectedCameras)
                    {
                        cams.Add(item.ID);
                    }
                }
            
                SearchPara searchPara = new SearchPara()
                    {
                        StartTime = m_StartTime,
                        EndTime = m_EndTime,
                        ResultCount = 999,

                        TaskID = tasks,
                        CameraID = cams,
                        PlateColor = PlateColor,
                        PlateNumber = m_PlateNumber,
                        VehicleBrand = m_Brand,
                        VehicleColor = VehicleColor,
                        VehicleDetailType = vehicleDetailType,
                        SelectAllVehicleModels = this.SelectAllVehicleModels,
                        CheckedVehicleModels = this.CheckedVehicleModels,
                        DriverBelt = driverBelt,
                        CoDriverBelt = coDriverBelt,
                        DriverPhoneCall = driverPhoneCall,
                        DriverShielding = driverShielding,
                        CoDriverShielding = coDriverShielding,
                        GlobRect = new Rectangle(),
                        PartRect = new Rectangle(),
                        PlateNumRows = plateType,
                         Similar = 0,
                        VehicleType = vehicleType,
                         
                    };

                if (iscompare)
                {
                    searchPara.GlobRect = GlobRect;
                    searchPara.PartRect = new Rectangle();
                    searchPara.ResultCount = ResultCount;
                    searchPara.Similar = 30;
                    searchPara.Weight = Weight;
                }


                if (iscompare)
                {
                    Framework.Container.Instance.TaskManager.TaskCompareSearch(searchPara, Image.FromFile(ComparePicturePath));
                    Framework.Container.Instance.EvtAggregator.GetEvent<NewCompareSearchEvent>().Publish(searchPara);
                }
                else
                {
                    Framework.Container.Instance.TaskManager.TaskCompareSearch(searchPara);
                    Framework.Container.Instance.EvtAggregator.GetEvent<NewSearchEvent>().Publish(searchPara);
                }
                //    searchPara, m_Brand, this.CheckedVehicleModels,
                //    out m_SQLQuery);

                //searchPara.SqlQuery = m_SQLQuery;
                //searchPara.ResultCount = count;

                
            //}
        }

        #region Event handlers

        private void OnTaskChanged(AnalyseTask task)
        {
            List<AnalyseTask> tasks = Framework.Container.Instance.TaskManager.GetAllTasks();
            if (tasks != null)
            {
                m_Tasks = tasks.ToArray();
            }
            else
            {
                m_Tasks = new AnalyseTask[0];
            }

            if (TasksChanged != null)
            {
                TasksChanged(this, EventArgs.Empty);
            }
        }

        private void OnTaskModifyChanged(List<AnalyseTask> task)
        {
            List<AnalyseTask> tasks = Framework.Container.Instance.TaskManager.GetAllTasks();
            if (tasks != null)
            {
                m_Tasks = tasks.ToArray();
            }
            else
            {
                m_Tasks = new AnalyseTask[0];
            }

            if (TasksChanged != null)
            {
                TasksChanged(this, EventArgs.Empty);
            }
        }

        #endregion


        //public static VehicleBrand GetVehicleBrand(this SearchPara searchPara)
        //{

        //}
    }

    #region Other classes

    //internal class VehicleModelInfo : ModelInfoBase
    //{
    //    private VehicleBrand m_Brand;

    //    public VehicleBrand Model
    //    {
    //        get { return m_Brand; }
    //    }

    //    public override string Name
    //    {
    //        get;
    //        set;
    //    }

    //    internal VehicleModelInfo(VehicleBrand brand)
    //    {
    //        m_Brand = brand;
    //    }
    //}

    

    #endregion

}
