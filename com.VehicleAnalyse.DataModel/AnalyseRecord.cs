using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using AppUtil;
using VehicleHelper.DataModel;

namespace com.VehicleAnalyse.DataModel
{
    public class AnalyseRecord : ICacheItem
    {
        public static string GCDD = "过车地点";
        public string Id {get;set;}
        public DateTime WatchTime {get;set;}

        public uint PlatformId { get; set; }

        public string DeviceId { get; set; }

        public string PicId { get; set; }

        public string PicPath { get; set; }

        public int ErrorCode { get; set; }

        public string PlateNumber { get; set; }

        public int PlateNumberReliability { get; set; }

        public string PlateColor { get; set; }

        /// <summary>
        /// 车牌颜色信息
        /// </summary>
        public VehiclePropertyInfo PlateColorInfo { get; set; }

        public string VehicleType { get; set; }

        /// <summary>
        /// 车型信息
        /// </summary>
        public VehiclePropertyInfo VehicleTypeInfo { get; set; }
        public int CarTypeConf { get; set; }

        public string DetailVehicleType { get; set; }

        /// <summary>
        /// 细分车型信息
        /// </summary>
        public VehiclePropertyInfo DetailVehicleTypeInfo { get; set; }
        public int CarTypeDetailConf { get; set; }

        public Rectangle VehicleRegion { get; set; }

        public Rectangle PlateRegion { get; set; }

        public Rectangle DriverRegion { get; set; }

        public Rectangle CoDriverRegion { get; set; }
        public VehiclePropertyInfo VehicleDirection { get; set; }
        public string PlateType { get; set; }

        /// <summary>
        /// 车牌类型信息
        /// </summary>
        public VehiclePropertyInfo PlateTypeInfo { get; set; }

        public string VehicleColor { get; set; }

        /// <summary>
        /// 车身颜色信息
        /// </summary>
        public VehiclePropertyInfo VehicleColorInfo { get; set; }
        public int CarColorConf { get; set; }

        //public string Manufacturer { get; set; }

        public int ManufacturerReliability { get; set; }

        /// <summary>
        /// 子品牌
        /// </summary>
        public VehiclePropertyInfo BrandInfo { get; set; }
        public int CarLabeDetailConf { get; set; }

        /// <summary>
        /// 父品牌
        /// </summary>
        public VehiclePropertyInfo ParentBrandInfo { get; set; }

        public VehiclePropertyInfo DriverWearingSafeBelt { get; set; }
        public int DriverIsSafebeltConf { get; set; }

        public VehiclePropertyInfo DriverSunlightShield { get; set; }
        public int DriverIsSunVisorConf { get; set; }

        public VehiclePropertyInfo DriverPhoneCalling { get; set; }
        public int DriverIsPhoneingConf { get; set; }

        public VehiclePropertyInfo CoDriverWearingSafeBelt { get; set; }
        public int PassengerIsSafebeltCof { get; set; }

        public VehiclePropertyInfo CoDriverSunlightShield { get; set; }
        public int PassengerIsSunVisorConf { get; set; }

        //public VehiclePropertyInfo CoDriverPhoneCalling { get; set; }



        public VehiclePropertyInfo ConsoleIsSomething { get; set; }              //中控台是否有杂物, 见E_IRAS_VEHICLE_WINDOW_STATE
        public int ConsoleIsSomethingCof { get; set; }     //中控台是否有杂物置信度

        public VehiclePropertyInfo IsPendant { get; set; }                                 //是否有挂饰物, 见E_IRAS_VEHICLE_WINDOW_STATE
        public int IsPendantCof { get; set; }                        //是否有挂饰物置信度

        public List<VehicleAnnualInspectionLabel> AILabel { get; set; }         //检测到底年检标签信息，可有多个，最多不超过ALG_AILABEL_NO_MAX定义的数量
        public uint Type { get; set; }

        public Image Image { get; set; }
        public Image ThumbImg { get; set; }
        public Image PlateImg { get; set; }

        public int CompareSimilarity { get; set; }

        public int Score { get; set; }

        public void Clear()
        {
            if (Image != null)
            {
                Image.Dispose();
                Image = null;
            }
        }
        public string ToShortString()
        {
            return GetPlateNumber() + " " + VehicleColor + " " + ParentBrandInfo.Name;
        }
        public List<string> GetSettings()
        {
            List<string> ret = new List<string>();
            ret.Add("过车编号："+Id);
            ret.Add("过车时间："+WatchTime);
            ret.Add(GCDD + "：" + DeviceId);
            ret.Add("原始图片："+PicPath );
            ret.Add("车牌号码：" + GetPlateNumber() + " [置信度：" + PlateNumberReliability + "%]");
            //ret.Add("车牌置信度："+PlateNumberReliability +"%");
            ret.Add("车牌颜色："+PlateColor );
            //ret.Add("车牌颜色："+PlateColorInfo );
            ret.Add("车型方向：" + VehicleDirection );
            ret.Add("车型粗分：" + VehicleType + " [置信度：" + CarTypeConf + "%]");
            //ret.Add("过车编号："+VehicleTypeInfo );
            ret.Add("车型细分：" + DetailVehicleType + " [置信度：" + CarTypeDetailConf + "%]");
            //ret.Add("过车编号："+DetailVehicleTypeInfo );
            //ret.Add("过车编号："+VehicleRegion );
            //ret.Add("过车编号："+ PlateRegion );
            //ret.Add("过车编号："+DriverRegion );
            //ret.Add("过车编号："+CoDriverRegion );
            ret.Add("车牌单双行："+PlateType );
            //ret.Add("过车编号："+PlateTypeInfo );
            ret.Add("车身颜色：" + VehicleColor + " [置信度：" + CarColorConf + "%]");
            //ret.Add("过车编号："+VehicleColorInfo );
            //ret.Add("厂商："+Manufacturer );
            ret.Add("品牌：" + ParentBrandInfo + " [置信度：" + ManufacturerReliability + "%]");
            //ret.Add("车标置信度：" + ManufacturerReliability + "%");
            ret.Add("子品牌：" + BrandInfo + " [置信度：" + CarLabeDetailConf + "%]");
            ret.Add("安全带(主)：" + DriverWearingSafeBelt + " [置信度：" + DriverIsSafebeltConf + "%]");
            ret.Add("遮阳板(主)：" + DriverSunlightShield + " [置信度：" + DriverIsSunVisorConf + "%]");
            ret.Add("打手机(主)：" + DriverPhoneCalling + " [置信度：" + DriverIsPhoneingConf + "%]");
            ret.Add("安全带(副)：" + CoDriverWearingSafeBelt + " [置信度：" + PassengerIsSafebeltCof + "%]");
            ret.Add("遮阳板(副)：" + CoDriverSunlightShield + " [置信度：" + PassengerIsSunVisorConf + "%]");
            ret.Add("中控台杂物：" + ConsoleIsSomething + " [置信度：" + ConsoleIsSomethingCof + "%]");
            ret.Add("挂饰物：" + IsPendant + " [置信度：" + IsPendantCof + "%]");
            //ret.Add("过车编号："+ CoDriverPhoneCalling );
            //ret.Add("过车编号："+ Type );
            ret.Add("年检标签：" + AILabel.Count + "个");
            //ret.Add("相似度：" + CompareSimilarity + "%");

            return ret;
        }


        public string GetPlateNumber()
        {
            string plateNumber = string.Empty;
            if (this != null)
            {
                plateNumber = this.PlateNumber;
                if (this.ErrorCode == 0)
                {
                    if (string.Compare(this.PlateNumber, "11111111", true) == 0)
                    {
                        plateNumber = "无牌车";
                    }
                    if (string.Compare(this.PlateNumber, "22222222", true) == 0)
                    {
                        plateNumber = "两轮车";
                    }
                }
                else if (this.ErrorCode == -2)
                {
                    plateNumber = "未识别";
                }
                else
                {
                    plateNumber = "图片错误";
                }
            }
            return plateNumber;
        }

        public void GetVehicleBrandName( out VehiclePropertyInfo brand, out VehiclePropertyInfo model)
        {
            brand = Constant.PropertyInfo_UNKNOWN;
            model = Constant.PropertyInfo_UNKNOWN;

            if (this.BrandInfo != null)
            {
                if (this.ParentBrandInfo != null)
                {
                    if (this.ParentBrandInfo.ID == 999)
                    {
                        // 被归到其它车厂商的车， 车厂家设置成与车型一样
                        brand = model = this.BrandInfo;
                    }
                    else
                    {
                        brand = this.ParentBrandInfo;
                        model = this.BrandInfo;
                    }
                }
                else
                {
                    // brand = Constant.PropertyInfo_UNKNOWN;
                    brand = model = this.BrandInfo;
                }
            }
        }

        public void GetVehicleColor( out string vehicleColor, out string plateColor)
        {
            vehicleColor =
             this.VehicleColorInfo != null ? this.VehicleColorInfo.Name : this.VehicleColor;
            plateColor =
                this.PlateColorInfo != null ? this.PlateColorInfo.Name : this.PlateColor;

            if (string.IsNullOrEmpty(vehicleColor))
            {
                vehicleColor = "未识别";
            }
            if (string.IsNullOrEmpty(plateColor))
            {
                plateColor = "未识别";
            }
        }




    }

    public class VehicleAnnualInspectionLabel
    { 	                            
        public Rectangle AILabelRect { get; set; }   //各个年检标签的位置坐标信息 
        public int AILabelCof { get; set; }       //各个年检标签的置信度
    }

}
