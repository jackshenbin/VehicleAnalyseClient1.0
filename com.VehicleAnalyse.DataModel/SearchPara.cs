using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using AppUtil.Controls;

namespace com.VehicleAnalyse.DataModel
{
    /*
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary> 分析标定设置，即图片检测区域，图片位置等参数 </summary>
    ///
    /// <remarks>   Administrator, 2014/11/13. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class Calibration
    {
        private int m_PlateRangeMin = 70;
        private int m_PlateRangeMax = 200;

        public DateTime TimeStamp { get; set; }			//时间戳
        public int SnapshotInterval { get; set; }				//间隔	

        public int PicWidth { get; set; }					//图像宽
        public int PicHeight { get; set; }				//图像高
        public int SceneType { get; set; }				//前牌尾牌

        public int PlateRangeMin
        {
            get { return m_PlateRangeMin; }
            set { m_PlateRangeMin = value; }
        }

        public int PlateRangeMax
        {
            get { return m_PlateRangeMax; }
            set { m_PlateRangeMax = value; }
        }

        /// <summary>
        /// 车牌检测区域
        /// </summary>
        public Rectangle PlateDetectionArea { get; set; }		
		
        /// <summary>
        /// 车牌区域
        /// </summary>
        public Rectangle PlateArea { get; set; }

        public override bool Equals(object obj)
        {
            bool bRet = false;

            Calibration cal = obj as Calibration;
            if (cal != null)
            {
                // TimeStamp == cal.TimeStamp &&
                if (SnapshotInterval == cal.SnapshotInterval &&
                    PicWidth == cal.PicWidth &&
                    PicHeight == cal.PicHeight &&
                    SceneType == cal.SceneType &&
                    PlateDetectionArea.Equals(cal.PlateDetectionArea) &&
                    PlateArea.Equals(cal.PlateArea) &&
                    PlateRangeMax == cal.PlateRangeMax && 
                    PlateRangeMin == cal.PlateRangeMin)
                {
                    bRet = true;
                }
            }
            return bRet;
        }

    }

    */

    public struct SearchPara
    {
        public List<string> CameraID { get; set; }
        public List<string> TaskID { get; set; }
        //public AnalyseTask Task { get; set; }
        public DateTime StartTime { get; set; }//>2016-04-01 00:00:00.000</StartTime ><!-- 检索开始时间 -->
        public DateTime EndTime { get; set; }//>2016-04-07 23:59:59.999</EndTime ><!-- 检索结束时间 -->
        public int Similar { get; set; }//>60.00</Similar>
        public int Weight { get; set; }

        public string PlateNumber { get; set; }

        public VehicleHelper.DataModel.VehiclePropertyInfo VehicleDetailType { get; set; }
        public VehicleHelper.DataModel.VehiclePropertyInfo VehicleType { get; set; }
        public VehicleHelper.DataModel.VehiclePropertyInfo PlateNumRows { get; set; }

        //public int BrandId { get; set; }//用作以图搜图 by shenbin 20160223

        //public int ParentBrandId { get; set; }//用作以图搜图 by shenbin 20160223
        public VehicleHelper.DataModel.VehiclePropertyInfo VehicleBrand { get; set; }

        public VehicleHelper.DataModel.VehiclePropertyInfo[] CheckedVehicleModels
        {
            get;
            set;
        }
        public bool SelectAllVehicleModels
        {
            get;
            set;
        }

        public VehicleHelper.DataModel.VehiclePropertyInfo VehicleColor { get; set; }
        public VehicleHelper.DataModel.VehiclePropertyInfo PlateColor { get; set; }
        //public ColorName VehicleColor { get; set; }

        //public ColorName PlateColor { get; set; }

        public VehicleHelper.DataModel.VehiclePropertyInfo DriverBelt
        {
            get;
            set;
        }

        public VehicleHelper.DataModel.VehiclePropertyInfo CoDriverBelt
        {
            get;
            set;
        }

        public VehicleHelper.DataModel.VehiclePropertyInfo DriverPhoneCall
        {
            get;
            set;
        }

        public VehicleHelper.DataModel.VehiclePropertyInfo DriverShielding
        {
            get;
            set;
        }

        public VehicleHelper.DataModel.VehiclePropertyInfo CoDriverShielding
        {
            get;
            set;
        }

        public Rectangle GlobRect { get; set; }
        public Rectangle PartRect { get; set; }


        public int ResultCount { get; set; }

        private string GetVehicleModels()
        {
            string sRet = "不限";

            if (VehicleBrand != null)
            {
                if (SelectAllVehicleModels)
                {
                    sRet = VehicleBrand.Name;
                }
                else
                {
                    if (CheckedVehicleModels != null && CheckedVehicleModels.Length > 0)
                    {
                        StringBuilder sb = new StringBuilder(VehicleBrand.Name);
                        sb.Append("    ");
                        foreach (var brand in CheckedVehicleModels)
                        {
                            sb.AppendFormat("{0},", brand.Name);
                        }
                        sRet = sb.ToString().Trim(new char[] { ',' });
                    }
                }
            }

            return sRet;
        }
        private string GetPlateNumber()
        {
            string plateNumber = this.PlateNumber;

            if (string.Compare(this.PlateNumber, "11111111", true) == 0)
            {
                plateNumber = "无牌车";
            }
            if (string.Compare(this.PlateNumber, "22222222", true) == 0)
            {
                plateNumber = "两轮车";
            }


            return plateNumber;
        }

        public Dictionary<string,string> GetSettings()
        {
            Dictionary<string,string> settings = new Dictionary<string,string>();

            StringBuilder sb = new StringBuilder();
            if (CameraID != null && CameraID.Count > 0)
                CameraID.ForEach(it => sb.Append(it + ","));

            string cam = sb.ToString().Trim(',');
            settings.Add("过车位置：", string.IsNullOrEmpty(cam) ? "不限" : cam);

            settings.Add("时间范围：",StartTime.ToString("yyyy-MM-dd HH:mm:ss") +"-"+EndTime.ToString("yyyy-MM-dd HH:mm:ss"));
            settings.Add("车牌：", string.IsNullOrEmpty(PlateNumber) ? "不限" : GetPlateNumber());
            settings.Add("车型：", VehicleType.Name );
            settings.Add("车型细分：", VehicleDetailType.Name );
            settings.Add("车身颜色：", VehicleColor.Name );
            settings.Add("车牌颜色：",PlateColor.Name );
            settings.Add("车牌类型：",PlateNumRows.Name );

            string item1 = string.Format("{0}", DriverBelt.Name);
            string item2 = string.Format("{0}", CoDriverBelt.Name);
            if (item1 == "不限" && item2 == "不限")
            {
                settings.Add("安全带：", "不限");
            }
            else
            {
                if (item1 != "不限" && item2 != "不限")
                {
                    settings.Add("安全带：主驾", item1 + "，副驾" + item2);
                }
                else
                {
                    settings.Add("安全带：", string.IsNullOrEmpty(item1) ? "副驾" + item2 : "主驾" + item1);
                }
            }



            settings.Add("打手机：", DriverPhoneCall.Name);

             item1 =string.Format("{0}",DriverShielding.Name);
             item2 =string.Format("{0}",CoDriverShielding.Name);
            if (item1 == "不限" && item2 == "不限")
            {
                settings.Add("遮阳板：", "不限");
            }
            else
            {
                if (item1 != "不限" && item2 != "不限")
                {
                    settings.Add("遮阳板：主驾", item1+"，副驾"+item2);
                }
                else
                {
                    settings.Add("遮阳板：", string.IsNullOrEmpty(item1) ? "副驾" + item2 : "主驾" + item1);
                }
            }



            string model = GetVehicleModels();
            settings.Add("品牌：", model);

            return settings;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in GetSettings())
            {
                if (item.Value == "不限")
                    continue;
                sb.Append(item.Key + item.Value + "；");
            }
            return sb.ToString();
        }
    }
    public struct CompareSearchPara
    {


        public override string ToString()
        {
            string sRet = string.Empty;


            return sRet;
        }
    }
}
