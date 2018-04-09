using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppUtil.Controls;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using VehicleHelper;
using VehicleHelper.DataModel;

namespace com.VehicleAnalyse.DataModel
{
    public class Constant
    {
        public readonly static ColorName COLOR_TRANSPARENT = new ColorName(Color.Transparent, "不限");
        public readonly static ColorName COLOR_WHITE = new ColorName(Color.White, "白色");
        public readonly static ColorName COLOR_SILVER = new ColorName(Color.Silver, "银色");
        public readonly static ColorName COLOR_BLACK = new ColorName(Color.Black, "黑色");
        public readonly static ColorName COLOR_RED = new ColorName(Color.Red, "红色");
        public readonly static ColorName COLOR_PURPL = new ColorName(Color.Purple, "紫色");
        public readonly static ColorName COLOR_BLUE = new ColorName(Color.Blue, "蓝色");
        public readonly static ColorName COLOR_ORANGE = new ColorName(Color.Orange, "橘黄");
        public readonly static ColorName COLOR_YELLOW = new ColorName(Color.Yellow, "黄色");
        public readonly static ColorName COLOR_GREEN = new ColorName(Color.Green, "绿色");
        public readonly static ColorName COLOR_BROWN = new ColorName(Color.Brown, "褐色"); //"棕色");
        public readonly static ColorName COLOR_PINK = new ColorName(Color.Pink, "粉色");
        public readonly static ColorName COLOR_GRAY = new ColorName(Color.Gray, "灰色");
        public readonly static ColorName COLOR_TWOWHEEL = new ColorName(Color.Transparent, "--");
        public readonly static ColorName COLOR_7 = new ColorName(Color.Transparent, "7");
        public readonly static ColorName COLOR_11 = new ColorName(Color.Transparent, "11");
        public readonly static ColorName COLOR_OTHER = new ColorName(SystemColors.Info, "其他");
        public readonly static ColorName COLOR_GRADIENTGREEN = new ColorName(Color.LawnGreen, "渐变绿");
        public readonly static ColorName COLOR_YELLOWGREEN = new ColorName(Color.YellowGreen, "黄绿色");

        public static readonly string DATETIME_FORMAT = "yyyy-MM-dd HH:mm:ss";

        public static readonly DateTime DATETIME_MIN = new DateTime(1970, 1, 1).ToLocalTime();
        public static readonly DateTime DATETIME_MAX = new DateTime(1970, 1, 1).ToLocalTime().AddSeconds(int.MaxValue);

        public static readonly string[] PICFILE_EXTENSIONS = new string[] { ".jpg", ".jpeg", ".png", ".bmp" };

        public static readonly string NONEPLATE = "11111111";

       // public static VehicleTypeInfo[] s_VehicleTypeInfos;

        //public static SearchResultObjectTypeInfo[] s_SearchResultObjectTypeInfos;

        //public static VehicleDetailTypeInfo[] s_VehicleDetailTypeInfos;

        //public static VehiclePlateTypeInfo[] s_VehiclePlateTypeInfos;

        /// <summary>
        /// 对于像车辆类型、子类型、车身颜色，没有值的都使用 PropertyInfo_UNKNOWN
        /// </summary>
        public readonly static VehiclePropertyInfo PropertyInfo_UNKNOWN = new VehiclePropertyInfo() { ID = -1, Name = "未识别" };
        public readonly static VehiclePropertyInfo PropertyInfo_NOTSPECIFIED = new VehiclePropertyInfo() { ID = -1, Name = "不限" };

        //private static SortedDictionary<int, ModelPropertyInfo> SDT_PropertyInfo_PlateColor;
        //private static SortedDictionary<int, ModelPropertyInfo> SDT_PropertyInfo_VehicleColor;
        //private static SortedDictionary<int, ModelPropertyInfo> SDT_PropertyInfo_VehicleType;
        //private static SortedDictionary<int, ModelPropertyInfo> SDT_PropertyInfo_VehicleDetailType;
        //private static SortedDictionary<int, ModelPropertyInfo> SDT_PropertyInfo_PlateType;
        //private static SortedDictionary<int, ModelPropertyInfo> SDT_PropertyInfo_VehicleBrand;
        //private static SortedDictionary<int, ModelPropertyInfo> SDT_PropertyInfo_SafeBeltWear;
        //private static SortedDictionary<int, ModelPropertyInfo> SDT_PropertyInfo_SunlightShielding;
        //private static SortedDictionary<int, ModelPropertyInfo> SDT_PropertyInfo_PhoneCalling;

        public readonly static ColorName[] COLORNAMES_VEHICLEBODY = new ColorName[]{
           COLOR_TRANSPARENT,
           COLOR_WHITE,
           COLOR_SILVER,
           COLOR_BLACK,
           COLOR_RED,    
           COLOR_PURPL,
           COLOR_BLUE,  
           COLOR_YELLOW,
           COLOR_GREEN,
           COLOR_BROWN,
           COLOR_PINK ,  
           COLOR_GRAY,  // 10
           COLOR_TWOWHEEL,
        };

        public readonly static ColorName[] COLORNAMES_VEHICLEPLATE = new ColorName[]{
           COLOR_TRANSPARENT,
           COLOR_BLUE,  
           COLOR_BLACK,
           COLOR_YELLOW,
           COLOR_WHITE,
           COLOR_GREEN,
           COLOR_OTHER,
           COLOR_7,
           COLOR_TWOWHEEL,
        };
        public static AppUtil.Controls.ColorName ConvertPlateColor(VehicleHelper.DataModel.VehiclePropertyInfo info)
        {
            switch (info.ID)
            {
                case 1:
                    return DataModel.Constant.COLOR_BLUE;
                case 2:
                    return DataModel.Constant.COLOR_BLACK;
                case 3:
                    return DataModel.Constant.COLOR_YELLOW;
                case 4:
                    return DataModel.Constant.COLOR_WHITE;
                case 5:
                    return DataModel.Constant.COLOR_GREEN;
                 case 7:
                    return DataModel.Constant.COLOR_GRADIENTGREEN;
                 case 8:
                    return DataModel.Constant.COLOR_YELLOWGREEN;
                 case 6:
                    return DataModel.Constant.COLOR_OTHER;
               default:
                    return DataModel.Constant.COLOR_TRANSPARENT;
            }
        }

        public static VehicleHelper.DataModel.VehiclePropertyInfo ConvertPlateColor(AppUtil.Controls.ColorName color)
        {
            int id = -1;
            if (color.Color.ToArgb() == DataModel.Constant.COLOR_BLUE.Color.ToArgb())
            { id = 1; }
            else if (color.Color.ToArgb() == DataModel.Constant.COLOR_BLACK.Color.ToArgb())
            { id = 2; }
            else if (color.Color.ToArgb() == DataModel.Constant.COLOR_YELLOW.Color.ToArgb())
            { id = 3; }
            else if (color.Color.ToArgb() == DataModel.Constant.COLOR_WHITE.Color.ToArgb())
            { id = 4; }
            else if (color.Color.ToArgb() == DataModel.Constant.COLOR_GREEN.Color.ToArgb())
            { id = 5; }
            else if (color.Color.ToArgb() == DataModel.Constant.COLOR_GRADIENTGREEN.Color.ToArgb())
            { id =7; }
            else if (color.Color.ToArgb() == DataModel.Constant.COLOR_YELLOWGREEN.Color.ToArgb())
            { id = 8; }
            else if (color.Color.ToArgb() == DataModel.Constant.COLOR_OTHER.Color.ToArgb())
            { id = 6; }
            var info = DataModel.Constant.PropertyInfo_PlateColor.Find(item => item.ID == id);
            if (info != null)
                return info;
            else
                return new VehiclePropertyInfo() { ID = -1, Name = "不限", };
        }

        public static AppUtil.Controls.ColorName ConvertVehicleColor(VehicleHelper.DataModel.VehiclePropertyInfo info)
        {
            switch (info.ID)
            {
                case 1:
                    return DataModel.Constant.COLOR_WHITE;
                case 2:
                    return DataModel.Constant.COLOR_SILVER;
                case 3:
                    return DataModel.Constant.COLOR_BLACK;
                case 4:
                    return DataModel.Constant.COLOR_RED;
                case 5:
                    return DataModel.Constant.COLOR_PURPL;
                 case 6:
                    return DataModel.Constant.COLOR_BLUE;
                 case 7:
                    return DataModel.Constant.COLOR_YELLOW;
                 case 8:
                    return DataModel.Constant.COLOR_GREEN;
                 case 9:
                    return DataModel.Constant.COLOR_BROWN;
                 case 10:
                    return DataModel.Constant.COLOR_PINK;
                 case 11:
                    return DataModel.Constant.COLOR_GRAY;
                 case 12: 
                    return DataModel.Constant.COLOR_OTHER;
               default:
                    return DataModel.Constant.COLOR_TRANSPARENT;
            }
        }

        public static VehicleHelper.DataModel.VehiclePropertyInfo ConvertVehicleColor(AppUtil.Controls.ColorName color)
        {
            int id = -1;
            if (color.Color.ToArgb() == DataModel.Constant.COLOR_WHITE.Color.ToArgb())
            { id = 1; }
            else if (color.Color.ToArgb() == DataModel.Constant.COLOR_SILVER.Color.ToArgb())
            { id = 2; }
            else if (color.Color.ToArgb() == DataModel.Constant.COLOR_BLACK.Color.ToArgb())
            { id = 3; }
            else if (color.Color.ToArgb() == DataModel.Constant.COLOR_RED.Color.ToArgb())
            { id = 4; }
            else if (color.Color.ToArgb() == DataModel.Constant.COLOR_PURPL.Color.ToArgb())
            { id = 5; }
            else if (color.Color.ToArgb() == DataModel.Constant.COLOR_BLUE.Color.ToArgb())
            { id = 6; }
            else if (color.Color.ToArgb() == DataModel.Constant.COLOR_YELLOW.Color.ToArgb())
            { id = 7; }
            else if (color.Color.ToArgb() == DataModel.Constant.COLOR_GREEN.Color.ToArgb())
            { id = 8; }
            else if (color.Color.ToArgb() == DataModel.Constant.COLOR_BROWN.Color.ToArgb())
            { id = 9; }
            else if (color.Color.ToArgb() == DataModel.Constant.COLOR_PINK.Color.ToArgb())
            { id = 10; }
            else if (color.Color.ToArgb() == DataModel.Constant.COLOR_GRAY.Color.ToArgb())
            { id = 11; }
            else if (color.Color.ToArgb() == DataModel.Constant.COLOR_OTHER.Color.ToArgb())
            { id = 12; }
            var info = DataModel.Constant.PropertyInfo_VehicleColor.Find(item => item.ID == id);
            if (info != null)
                return info;
            else
                return new VehiclePropertyInfo() { ID = -1, Name = "不限", };
        }







        //public static VehicleDetailTypeInfo[] VehicleDetailTypeInfos
        //{
        //    get
        //    {
        //        if (s_VehicleDetailTypeInfos == null)
        //        {
        //            s_VehicleDetailTypeInfos = new VehicleDetailTypeInfo[]
        //            {
        //                new VehicleDetailTypeInfo() { Type = VehicleDetailType.None, Name = "不限" },
        //                new VehicleDetailTypeInfo() { Type = VehicleDetailType.Truck, Name = "大型货车" },
        //                new VehicleDetailTypeInfo() { Type = VehicleDetailType.Big, Name = "大型客车" },
        //                new VehicleDetailTypeInfo() { Type = VehicleDetailType.Middle, Name = "中型客车" },
        //                new VehicleDetailTypeInfo() { Type = VehicleDetailType.Small, Name = "小型客车" },
        //                new VehicleDetailTypeInfo() { Type = VehicleDetailType.SmallTruck, Name = "小型货车"},
        //                new VehicleDetailTypeInfo() { Type = VehicleDetailType.Bicyle, Name = "两轮车" },
        //                new VehicleDetailTypeInfo() { Type = VehicleDetailType.Other, Name = "其它" }
        //            };
        //        }
        //        return s_VehicleDetailTypeInfos;
        //    }
        //}
        public static TypeInfo<TaskType>[] TaskTypeInfos
        {
            get
            {
                return new TypeInfo<TaskType>[]
                {
                    new TypeInfo<TaskType>(TaskType.Realtime, "实时任务"),
                    new TypeInfo<TaskType>(TaskType.History, "历史任务"),
                };
            }
        }
        //public static VehiclePlateTypeInfo[] VehiclePlateTypeInfos
        //{
        //    get
        //    {
        //        if (s_VehiclePlateTypeInfos == null)
        //        {
        //            s_VehiclePlateTypeInfos = new VehiclePlateTypeInfo[]
        //            {
        //                new VehiclePlateTypeInfo() { Type = VehiclePlateType.None, Name = "不限" },
        //                new VehiclePlateTypeInfo() { Type = VehiclePlateType.SingleRow, Name = "单排" },
        //                new VehiclePlateTypeInfo() { Type = VehiclePlateType.DoubleRow, Name = "双排" },
        //                new VehiclePlateTypeInfo() { Type = VehiclePlateType.Other, Name = "其它" },
        //            };
        //        }
        //        return s_VehiclePlateTypeInfos;
        //    }
        //}

        //private static FileTypeInfo[] s_FileTypeInfos;

        //private static TaskStatusInfo[] s_TaskStatusInfos;

        //public static FileTypeInfo[] FileTypeInfos
        //{
        //    get
        //    {
        //        if (s_FileTypeInfos == null)
        //        {
        //            s_FileTypeInfos = new FileTypeInfo[]
        //            {
        //                new FileTypeInfo(FileType.LocalFile, "本地文件"),
        //                new FileTypeInfo(FileType.Ftp, "Ftp文件"),
        //                new FileTypeInfo(FileType.Http, "Http 文件")
        //            };
        //        }
        //        return s_FileTypeInfos;
        //    }
        //}

        public static TypeInfo<TaskStatus>[] TaskStatusInfos
        {
            get
            {
                return new TypeInfo<TaskStatus>[]
                {
                        new TypeInfo<TaskStatus>(TaskStatus.AnalysingError, "任务分析失败"),
                        new TypeInfo<TaskStatus>(TaskStatus.Init, "初始化"),
                        new TypeInfo<TaskStatus>(TaskStatus.Analysing, "任务分析中"),
                        new TypeInfo<TaskStatus>(TaskStatus.Finished, "任务分析完成"),
                        new TypeInfo<TaskStatus>(TaskStatus.Loading, "分析数据加载中"),
                };

            }
        }
        static VehicleEnumService service;
        public static void Init()
        {
            //BuildIllegalBehaviorTable();
            //BuildPlateColorTable();
            //BuildPlateStructureTable();
            //BuildVehicleColorTable();
            //BuildVehicleDetailTypeTable();
            //BuildVehicleTypeTable();
            if (service == null)
                service = new VehicleEnumService();
        }

        public static List<VehiclePropertyInfo> PropertyInfo_PlateType
        {
            get { return service.PlateTypeInfos.ConvertAll<VehiclePropertyInfo>(item => { return (VehiclePropertyInfo)item; }); ; }
        }
        public static List<VehiclePropertyInfo> PropertyInfo_PlateColor
        {
            get { return service.PlateColorInfos.ConvertAll<VehiclePropertyInfo>(item => { return (VehiclePropertyInfo)item; }); ; }
        }
        public static List<VehiclePropertyInfo> PropertyInfo_PhoneCalling
        {
            get { return service.PhoneCallingInfos.ConvertAll<VehiclePropertyInfo>(item => { return (VehiclePropertyInfo)item; }); ; }
        }
        public static List<VehiclePropertyInfo> PropertyInfo_SafeBeltWear
        {
            get { return service.SafeBeltWearInfos.ConvertAll<VehiclePropertyInfo>(item => { return (VehiclePropertyInfo)item; }); ; }
        }
        public static List<VehiclePropertyInfo> PropertyInfo_SunlightShielding
        {
            get { return service.SunlightShieldingInfos.ConvertAll<VehiclePropertyInfo>(item => { return (VehiclePropertyInfo)item; }); }
        }
        public static List<VehiclePropertyInfo> PropertyInfo_VehicleBrand
        {
            get { return service.VehicleBrandInfos.ConvertAll<VehiclePropertyInfo>(item => { return (VehiclePropertyInfo)item; }); ; }
        }
        public static List<VehiclePropertyInfo> PropertyInfo_VehicleColor
        {
            get { return service.VehicleColorInfos.ConvertAll<VehiclePropertyInfo>(item => { return (VehiclePropertyInfo)item; }); ; }
        }
        public static List<VehiclePropertyInfo> PropertyInfo_VehicleDirection
        {

            get
            {
                List<VehiclePropertyInfo> ret = new List<VehiclePropertyInfo>();
                ret.Add(new VehiclePropertyInfo() { ID = 0, Name = "其他" });
                ret.Add(new VehiclePropertyInfo() { ID = 1, Name = "车头" });
                ret.Add(new VehiclePropertyInfo() { ID = 2, Name = "车尾" });
                return ret;
            }
        }
        public static List<VehiclePropertyInfo> PropertyInfo_VehicleType
        {
            get { return service.VehicleTypeInfos.ConvertAll<VehiclePropertyInfo>(item => { return (VehiclePropertyInfo)item; }); ; }
        }

        public static List<VehiclePropertyInfo> PropertyInfo_VehicleDetailType
        {
            get { return service.VehicleDetailTypeInfos.ConvertAll<VehiclePropertyInfo>(item => { return (VehiclePropertyInfo)item; }); ; }
        }

        public static List<VehiclePropertyInfo> GetVehicleDetailType(int id)
        {
            return service.VehicleDetailTypeInfos.Where(it=>it.ParentId == id || it.ParentId==-1).ToList().ConvertAll<VehiclePropertyInfo>(item => { return (VehiclePropertyInfo)item; }); 
 
        }

        public static List<VehiclePropertyInfo> GetVehicleDetailBrand(int id)
        {
            return service.GetVehicleChildBrandInfos(id).ConvertAll<VehiclePropertyInfo>(item => { return (VehiclePropertyInfo)item; }); 
 
        }
        public static VehicleBrandInfo GetVehicleBrand(int id)
        {
            return service.GetVehicleBrandInfo(id); 
 
        }
        public static VehiclePropertyInfo GetVehicleDetailTypeInfo(int id)
        {
            return service.VehicleDetailTypeInfos.Find(it => it.ID == id); 
 
        }

        //private static void BuildIllegalBehaviorTable()
        //{
        //    Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_SafeBeltWear, -1, "不限");
        //    Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_SafeBeltWear, 0, "未识别");
        //    Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_SafeBeltWear, 1, "未系");
        //    Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_SafeBeltWear, 2, "已系");
        //    Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_SafeBeltWear, 3, "无人");

        //    Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_SunlightShielding, -1, "不限");
        //    Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_SunlightShielding, 0, "未识别");
        //    Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_SunlightShielding, 1, "无");
        //    Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_SunlightShielding, 2, "有");

        //    Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_PhoneCalling, -1, "不限");
        //    Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_PhoneCalling, 0, "未识别");
        //    Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_PhoneCalling, 1, "否");
        //    Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_PhoneCalling, 2, "是");

        //}

        //private static void BuildVehicleTypeTable()
        //{
        //    Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_VehicleType, -1, "不限");
        //    Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_VehicleType, 0, "未识别");
        //    Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_VehicleType, 1, "大型客车");
        //    Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_VehicleType, 2, "大型货车");
        //    Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_VehicleType, 3, "中型客车");
        //    Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_VehicleType, 4, "小型客车");
        //    Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_VehicleType, 5, "小型货车");
        //}

        //private static void BuildVehicleDetailTypeTable()
        //{
        //    Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_VehicleDetailType, -1, "不限");
        //    Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_VehicleDetailType, 0, "未识别");
        //    Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_VehicleDetailType, 101, "大型客车的其他子类型");
        //    Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_VehicleDetailType, 201, "集装箱货车");
        //    Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_VehicleDetailType, 202, "油罐车");
        //    Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_VehicleDetailType, 203, "卡车");
        //    Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_VehicleDetailType, 204, "吊车");
        //    Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_VehicleDetailType, 205, "拖车");
        //    Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_VehicleDetailType, 206, "水泥车");
        //    Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_VehicleDetailType, 207, "大型货车的其他子类型");
        //    Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_VehicleDetailType, 301, "面包车");
        //    Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_VehicleDetailType, 302, "MPV");
        //    Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_VehicleDetailType, 303, "中型客车的其他子类型");
        //    Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_VehicleDetailType, 401, "SUV");
        //    Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_VehicleDetailType, 402, "小型客车的其他子类型");
        //    Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_VehicleDetailType, 501, "依维柯");
        //    Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_VehicleDetailType, 502, "皮卡");
        //    Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_VehicleDetailType, 503, "小型货车的其他子类型");
        //}
        //private static void BuildVehicleColorTable()
        //{

        //        Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_VehicleColor,-1,"不限");
        //        Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_VehicleColor, 1, "白色");
        //        Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_VehicleColor, 2, "银色");
        //        Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_VehicleColor, 3, "黑色");
        //        Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_VehicleColor, 4, "红色");
        //        Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_VehicleColor, 5, "紫色");
        //        Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_VehicleColor, 6, "蓝色");
        //        Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_VehicleColor, 7, "黄色");
        //        Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_VehicleColor, 8, "绿色");
        //        Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_VehicleColor, 9, "褐色");
        //        Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_VehicleColor, 10, "粉红色");
        //        Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_VehicleColor, 11, "灰色");
        //        Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_VehicleColor, 12, "其他");
        //}

        //private static void BuildPlateColorTable()
        //{

        //    Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_PlateColor, -1, "不限");
        //    Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_PlateColor, 1, "蓝色");
        //    Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_PlateColor, 2, "黑色");
        //    Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_PlateColor, 3, "黄色");
        //    Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_PlateColor, 4, "白色");
        //    Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_PlateColor, 5, "绿色");
        //    Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_PlateColor, 6, "其他");
        //    Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_PlateColor, 7, "其他");
        //    Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_PlateColor, 8, "其他");
        //}

        //private static void BuildPlateStructureTable()
        //{     
        //    Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_PlateType, -1, "不限");
        //    Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_PlateType, 1, "单行");
        //    Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_PlateType, 2, "双行");
        //    Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_PlateType, 3, "其他");
        //}
        //public static ModelPropertyInfo UpdatenGetProperty(ref SortedDictionary<int, ModelPropertyInfo> dt, int id, string name)
        //{
        //    if(dt == null)
        //    {
        //        dt = new SortedDictionary<int, ModelPropertyInfo>();
        //    }

        //    return UpdatenGetProperty(dt, id, name);
        //}

        //public static ModelPropertyInfo UpdatenGetProperty(IDictionary<int, ModelPropertyInfo> dt, int id, string name)
        //{
        //    ModelPropertyInfo mpInfo = null;
            
        //    if (!dt.ContainsKey(id))
        //    {
        //        dt.Add(id, new ModelPropertyInfo() { ID = id, Name = name });
        //    }
        //    mpInfo = dt[id];
        //    return mpInfo;
        //}

        public static byte[] ImageToJpegBytes(Image img)
        {
            byte[] bytes = null;

            ImageFormat format = img.RawFormat;

            using (MemoryStream ms = new MemoryStream())
            {
                //if(format.Equals(ImageFormat.Jpeg) ||
                //    format.Equals(ImageFormat.Bmp) ||
                //    format.Equals(ImageFormat.Gif) ||
                //    format.Equals(ImageFormat.Icon))
                {
                    img.Save(ms, ImageFormat.Jpeg);
                    bytes = new byte[ms.Length];

                    ms.Seek(0, SeekOrigin.Begin);
                    ms.Read(bytes, 0, bytes.Length);
                }
            }

            return bytes;
        }

    }

    public class TypeInfo<T>
    {
        public T Type { get; set; }

        public uint NType
        {
            get
            {
                return Convert.ToUInt32(Type);
            }
        }

        public string Name { get; set; }

        public TypeInfo(T type, string name)
        {
            Type = type;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }

}
