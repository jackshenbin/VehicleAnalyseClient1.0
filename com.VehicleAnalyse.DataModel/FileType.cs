using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace com.VehicleAnalyse.DataModel
{
    #region enums
    
    public enum FileType
    {
        Http = 1,
        Ftp,
        LocalFile
    }
    
    public enum VehicleType
    {
        // 1:不限；
        None = 0,
        // 1:小车；
        Small = 1,
        // 2:中车；
        Middle = 2,
        // 3:大车；
        Big = 3,
        // 4:其它车型
        Other
    }


    public enum VehicleDetailType
    {
        // 不限
        None = 0,
        // 大型货车
        Truck = 1,
        // 大型客车
        Big = 2,
        // 中性客车
        Middle,
        // 小型客车
        Small,
         // 小型货车
        SmallTruck,
        // 两轮车
        Bicyle, // 
        // 其它
        Other
    }

    public enum VehiclePlateType
    {
        // 1:不限；
        None = 0,
        // 1:单行；
        SingleRow = 1,
        // 2：双行；
        DoubleRow = 2,
        // 3其他
        Other = 3
    }

    public enum SearchResultObjectType
    {
        None = 0,
        CAR,
        PEOPLE,
        Unknown,
        FACE,
    }

    public enum CarType
    {
        All,
        Big,
        Middle,
        Small
    }

    #endregion

    //public class ModelInfoBase
    //{
    //    public virtual string Name { get; set; }

    //    public override string ToString()
    //    {
    //        return Name;
    //    }
    //}

    // public class ModelPropertyInfo : ModelInfoBase
    //{
    //    public int ID { get;set; }

    //}

    //public class ModelPropertyInfoComparerByName : IComparer<ModelPropertyInfo>
    //{
    //    public int Compare(ModelPropertyInfo x, ModelPropertyInfo y)
    //    {
    //        int n = 0;
    //        if (x != null && y != null)
    //        {
    //            n = string.Compare(x.Name, y.Name);
    //        }
    //        return n;
    //    }
    //}

    //public class VehicleTypeInfo : ModelInfoBase
    //{
    //    public VehicleType Type { get; set; }

    //}

    //public class SearchResultObjectTypeInfo : ModelInfoBase
    //{
    //    public SearchResultObjectType Type { get; set; }
    //}

    //public class VehicleDetailTypeInfo : ModelInfoBase
    //{
    //    public VehicleDetailType Type { get; set; }
    //}

    //public class VehiclePlateTypeInfo : ModelInfoBase
    //{
    //    public VehiclePlateType Type { get; set; }
    //}

    //public class VehicleBrandInfo : ModelInfoBase
    //{
    //    public int ID { get; set; }

    //    public string ImageName { get; set; }
    //}

    public class FileTypeInfo
    {
        public FileType Type { get;set; }

        public string Name{get;set;}

        public uint NType
        {
            get
            {
                return (uint)Type;
            }
        }

        public FileTypeInfo(FileType fileType, string name)
        {
            Type = fileType;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class TaskStatusInfo
    {
        public TaskStatus Status { get; set; }

        public string Name { get; set; }

        public uint NStatus
        {
            get
            {
                return (uint)Status;
            }
        }

        public TaskStatusInfo(TaskStatus status, string name)
        {
            Status = status;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
