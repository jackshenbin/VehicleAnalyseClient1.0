using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleHelper.DAO;
using VehicleHelper.DataModel;

namespace VehicleHelper.ViewModels
{
    class SelectVehicleModelViewModel : IDisposable
    {

        #region Fields

        private VehicleEnumService m_DAOService;

        private VehicleBrandInfo m_Brand;

        private VehicleBrandInfo[] m_VehicleModels;

        private bool m_selectAllVehicleModels = true;

        #endregion

        #region Properties

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

        public bool SelectAllVehicleModels
        {
            get { return m_selectAllVehicleModels; }
            set { m_selectAllVehicleModels = value; }
        }

        public VehicleBrandInfo[] CheckedVehicleModels
        {
            get;
            set;
        }

        public VehicleBrandInfo[] VehicleModels
        {
            get { return m_VehicleModels; }
            set { }
        }

        #endregion

        #region Private helper functions

        private void InitTable()
        {

        }


        #endregion

        private void UpdateVehilceModels()
        {
            if (m_Brand != null)
            {
                m_VehicleModels = m_DAOService.GetVehicleChildBrandInfos(m_Brand.ID).ToArray();
            }
            else
            {
                m_VehicleModels = null;
            }
        }

        internal SelectVehicleModelViewModel()
        {
            m_DAOService = new  VehicleEnumService();
        }

        #region Event handlers

        #endregion


        public void Dispose()
        {
            if (m_DAOService != null)
            {
                m_DAOService.Dispose();
                m_DAOService = null;
            }
        }
    }

    #region Other classes

    public class VehicleModelInfo// : ModelInfoBase
    {
        private VehicleBrandInfo m_Brand;

        public VehicleBrandInfo Model
        {
            get { return m_Brand; }
        }

        public string Name
        {
            get
            {
                return m_Brand.Name;
            }
            set
            {
                // base.Name = value;
            }
        }

        public override string ToString()
        {
            return Name;
        }

        internal VehicleModelInfo(VehicleBrandInfo brand)
        {
            m_Brand = brand;
        }
    }

    //public struct SearchPara
    //{
    //    public AnalyseTask Task { get; set; }

    //    public string PlateNumber { get; set; }

    //    public VehicleDetailTypeInfo VehicleDetailType { get; set; }

    //    public VehicleBrandInfo VehicleBrand { get; set; }

    //    public VehicleBrand[] CheckedVehicleModels
    //    {
    //        get;
    //        set;
    //    }
    //    public bool SelectAllVehicleModels
    //    {
    //        get;
    //        set;
    //    }

    //    public int ResultType { get; set; }

    //    public ColorName VehicleColor { get; set; }

    //    public ColorName PlateColor { get; set; }

    //    public int DriverBelt
    //    {
    //        get;
    //        set;
    //    }

    //    public int CoDriverBelt
    //    {
    //        get;
    //        set;
    //    }

    //    public string SqlQuery { get; set; }

    //    public int ResultCount { get; set; }

    //    private string GetVehicleModels()
    //    {
    //        string sRet = "不限";

    //        if (VehicleBrand != null)
    //        {
    //            if (SelectAllVehicleModels)
    //            {
    //                VehicleBrand parent = Framework.Container.Instance.TaskManager.GetBrand(VehicleBrand.ID);
    //                if (parent != null && parent.ParentId.HasValue)
    //                {
    //                    parent = Framework.Container.Instance.TaskManager.GetBrand((int)parent.ParentId.Value);
    //                }
    //                else
    //                {
    //                    parent = null;
    //                }

    //                if (parent != null)
    //                {
    //                    sRet = string.Format("{0} {1}", parent.Name, VehicleBrand.Name);
    //                }
    //                else
    //                {
    //                    sRet = VehicleBrand.Name;
    //                }
    //            }
    //            else
    //            {
    //                if (CheckedVehicleModels != null && CheckedVehicleModels.Length > 0)
    //                {
    //                    StringBuilder sb = new StringBuilder(VehicleBrand.Name);
    //                    sb.Append("    ");
    //                    foreach (VehicleBrand brand in CheckedVehicleModels)
    //                    {
    //                        sb.AppendFormat("{0},", brand.Name);
    //                    }
    //                    sRet = sb.ToString().Trim(new char[] { ',' });
    //                }
    //            }
    //        }

    //        return sRet;
    //    }

    //    public string[] GetSettings()
    //    {
    //        string[] settings = new string[8];

    //        settings[0] = Task.Name;

    //        string[] resultTypes = new string[]{"不限",
    //                                                                            "有牌",
    //                                                                            "无牌",
    //                                                                            "未识别",
    //                                                                            "图片错误"};

    //        settings[1] = resultTypes[ResultType];
    //        settings[2] = PlateNumber ?? "不限";
    //        settings[3] = VehicleDetailType.Name ?? "不限";
    //        settings[4] = VehicleColor.Name ?? "不限";
    //        settings[5] = PlateColor.Name ?? "不限";
    //        if (DriverBelt == 0 && CoDriverBelt == 0)
    //        {
    //            settings[6] = "不限";
    //        }
    //        else
    //        {
    //            if (DriverBelt != 0 && CoDriverBelt != 0)
    //            {
    //                settings[6] = string.Format("主驾{0},副驾{1}",
    //                    DataModel.Constant.SDT_PropertyInfo_SafeBeltWear[DriverBelt - 1].Name,
    //                    DataModel.Constant.SDT_PropertyInfo_SafeBeltWear[CoDriverBelt - 1].Name
    //                );
    //            }
    //            else
    //            {
    //                settings[6] = DriverBelt != 0 ? string.Format("主驾{0}", DataModel.Constant.SDT_PropertyInfo_SafeBeltWear[DriverBelt - 1].Name) :
    //                    string.Format("副驾{0}", DataModel.Constant.SDT_PropertyInfo_SafeBeltWear[CoDriverBelt - 1].Name);
    //            }
    //        }

    //        string model = GetVehicleModels();
    //        settings[7] = model;

    //        return settings;
    //    }

    //    public override string ToString()
    //    {
    //        string sRet = string.Empty;

    //        //StringBuilder sb = new StringBuilder();

    //        //sb.AppendFormat("任务: {0};    ", Task.Name);
    //        //sb.AppendFormat("结果类型: {0};    ", resultTypes[ResultType]);
    //        //sb.AppendFormat("车牌: {0};    ", PlateNumber ?? "不限");
    //        //sb.AppendFormat("车辆细分: {0};    ", VehicleDetailType.Name ?? "不限");
    //        //sb.AppendFormat("车身颜色: {0};    ", VehicleColor.Name ?? "不限");
    //        //sb.AppendFormat("车牌颜色: {0};    ", PlateColor.Name ?? "不限");

    //        //string model = GetVehicleModels() ;

    //        //sb.AppendFormat("车型: {0} ", model);
    //        //sRet = sb.ToString();

    //        return sRet;
    //    }
    //}

    #endregion

}
