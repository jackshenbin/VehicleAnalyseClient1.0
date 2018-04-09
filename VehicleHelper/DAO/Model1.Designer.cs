﻿//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[assembly: EdmSchemaAttribute()]
namespace VehicleHelper.DAO
{
    #region 上下文
    
    /// <summary>
    /// 没有元数据文档可用。
    /// </summary>
    public partial class ImageAnalyseDBEntities : ObjectContext
    {
        #region 构造函数
    
        /// <summary>
        /// 请使用应用程序配置文件的“ImageAnalyseDBEntities”部分中的连接字符串初始化新 ImageAnalyseDBEntities 对象。
        /// </summary>
        public ImageAnalyseDBEntities() : base("name=ImageAnalyseDBEntities", "ImageAnalyseDBEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// 初始化新的 ImageAnalyseDBEntities 对象。
        /// </summary>
        public ImageAnalyseDBEntities(string connectionString) : base(connectionString, "ImageAnalyseDBEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// 初始化新的 ImageAnalyseDBEntities 对象。
        /// </summary>
        public ImageAnalyseDBEntities(EntityConnection connection) : base(connection, "ImageAnalyseDBEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region 分部方法
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet 属性
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        internal ObjectSet<PhoneCalling> PhoneCallings
        {
            get
            {
                if ((_PhoneCallings == null))
                {
                    _PhoneCallings = base.CreateObjectSet<PhoneCalling>("PhoneCallings");
                }
                return _PhoneCallings;
            }
        }
        private ObjectSet<PhoneCalling> _PhoneCallings;
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        internal ObjectSet<PlateColor> PlateColors
        {
            get
            {
                if ((_PlateColors == null))
                {
                    _PlateColors = base.CreateObjectSet<PlateColor>("PlateColors");
                }
                return _PlateColors;
            }
        }
        private ObjectSet<PlateColor> _PlateColors;
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        internal ObjectSet<PlateStructure> PlateStructures
        {
            get
            {
                if ((_PlateStructures == null))
                {
                    _PlateStructures = base.CreateObjectSet<PlateStructure>("PlateStructures");
                }
                return _PlateStructures;
            }
        }
        private ObjectSet<PlateStructure> _PlateStructures;
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        internal ObjectSet<SafeBeltWear> SafeBeltWears
        {
            get
            {
                if ((_SafeBeltWears == null))
                {
                    _SafeBeltWears = base.CreateObjectSet<SafeBeltWear>("SafeBeltWears");
                }
                return _SafeBeltWears;
            }
        }
        private ObjectSet<SafeBeltWear> _SafeBeltWears;
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        internal ObjectSet<SunlightShielding> SunlightShieldings
        {
            get
            {
                if ((_SunlightShieldings == null))
                {
                    _SunlightShieldings = base.CreateObjectSet<SunlightShielding>("SunlightShieldings");
                }
                return _SunlightShieldings;
            }
        }
        private ObjectSet<SunlightShielding> _SunlightShieldings;
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        internal ObjectSet<VehicleBrand> VehicleBrands
        {
            get
            {
                if ((_VehicleBrands == null))
                {
                    _VehicleBrands = base.CreateObjectSet<VehicleBrand>("VehicleBrands");
                }
                return _VehicleBrands;
            }
        }
        private ObjectSet<VehicleBrand> _VehicleBrands;
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        internal ObjectSet<VehicleColor> VehicleColors
        {
            get
            {
                if ((_VehicleColors == null))
                {
                    _VehicleColors = base.CreateObjectSet<VehicleColor>("VehicleColors");
                }
                return _VehicleColors;
            }
        }
        private ObjectSet<VehicleColor> _VehicleColors;
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        internal ObjectSet<VehicleDetailType> VehicleDetailTypes
        {
            get
            {
                if ((_VehicleDetailTypes == null))
                {
                    _VehicleDetailTypes = base.CreateObjectSet<VehicleDetailType>("VehicleDetailTypes");
                }
                return _VehicleDetailTypes;
            }
        }
        private ObjectSet<VehicleDetailType> _VehicleDetailTypes;
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        internal ObjectSet<VehicleType> VehicleTypes
        {
            get
            {
                if ((_VehicleTypes == null))
                {
                    _VehicleTypes = base.CreateObjectSet<VehicleType>("VehicleTypes");
                }
                return _VehicleTypes;
            }
        }
        private ObjectSet<VehicleType> _VehicleTypes;

        #endregion

        #region AddTo 方法
    
        /// <summary>
        /// 用于向 PhoneCallings EntitySet 添加新对象的方法，已弃用。请考虑改用关联的 ObjectSet&lt;T&gt; 属性的 .Add 方法。
        /// </summary>
        internal void AddToPhoneCallings(PhoneCalling phoneCalling)
        {
            base.AddObject("PhoneCallings", phoneCalling);
        }
    
        /// <summary>
        /// 用于向 PlateColors EntitySet 添加新对象的方法，已弃用。请考虑改用关联的 ObjectSet&lt;T&gt; 属性的 .Add 方法。
        /// </summary>
        internal void AddToPlateColors(PlateColor plateColor)
        {
            base.AddObject("PlateColors", plateColor);
        }
    
        /// <summary>
        /// 用于向 PlateStructures EntitySet 添加新对象的方法，已弃用。请考虑改用关联的 ObjectSet&lt;T&gt; 属性的 .Add 方法。
        /// </summary>
        internal void AddToPlateStructures(PlateStructure plateStructure)
        {
            base.AddObject("PlateStructures", plateStructure);
        }
    
        /// <summary>
        /// 用于向 SafeBeltWears EntitySet 添加新对象的方法，已弃用。请考虑改用关联的 ObjectSet&lt;T&gt; 属性的 .Add 方法。
        /// </summary>
        internal void AddToSafeBeltWears(SafeBeltWear safeBeltWear)
        {
            base.AddObject("SafeBeltWears", safeBeltWear);
        }
    
        /// <summary>
        /// 用于向 SunlightShieldings EntitySet 添加新对象的方法，已弃用。请考虑改用关联的 ObjectSet&lt;T&gt; 属性的 .Add 方法。
        /// </summary>
        internal void AddToSunlightShieldings(SunlightShielding sunlightShielding)
        {
            base.AddObject("SunlightShieldings", sunlightShielding);
        }
    
        /// <summary>
        /// 用于向 VehicleBrands EntitySet 添加新对象的方法，已弃用。请考虑改用关联的 ObjectSet&lt;T&gt; 属性的 .Add 方法。
        /// </summary>
        internal void AddToVehicleBrands(VehicleBrand vehicleBrand)
        {
            base.AddObject("VehicleBrands", vehicleBrand);
        }
    
        /// <summary>
        /// 用于向 VehicleColors EntitySet 添加新对象的方法，已弃用。请考虑改用关联的 ObjectSet&lt;T&gt; 属性的 .Add 方法。
        /// </summary>
        internal void AddToVehicleColors(VehicleColor vehicleColor)
        {
            base.AddObject("VehicleColors", vehicleColor);
        }
    
        /// <summary>
        /// 用于向 VehicleDetailTypes EntitySet 添加新对象的方法，已弃用。请考虑改用关联的 ObjectSet&lt;T&gt; 属性的 .Add 方法。
        /// </summary>
        internal void AddToVehicleDetailTypes(VehicleDetailType vehicleDetailType)
        {
            base.AddObject("VehicleDetailTypes", vehicleDetailType);
        }
    
        /// <summary>
        /// 用于向 VehicleTypes EntitySet 添加新对象的方法，已弃用。请考虑改用关联的 ObjectSet&lt;T&gt; 属性的 .Add 方法。
        /// </summary>
        internal void AddToVehicleTypes(VehicleType vehicleType)
        {
            base.AddObject("VehicleTypes", vehicleType);
        }

        #endregion

    }

    #endregion

    #region 实体
    
    /// <summary>
    /// 没有元数据文档可用。
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="ImageAnalyseDBModel", Name="PhoneCalling")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    internal partial class PhoneCalling : EntityObject
    {
        #region 工厂方法
    
        /// <summary>
        /// 创建新的 PhoneCalling 对象。
        /// </summary>
        /// <param name="id">Id 属性的初始值。</param>
        /// <param name="name">Name 属性的初始值。</param>
        public static PhoneCalling CreatePhoneCalling(global::System.Int32 id, global::System.String name)
        {
            PhoneCalling phoneCalling = new PhoneCalling();
            phoneCalling.Id = id;
            phoneCalling.Name = name;
            return phoneCalling;
        }

        #endregion

        #region 基元属性
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                if (_Name != value)
                {
                    OnNameChanging(value);
                    ReportPropertyChanging("Name");
                    _Name = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("Name");
                    OnNameChanged();
                }
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();

        #endregion

    
    }
    
    /// <summary>
    /// 没有元数据文档可用。
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="ImageAnalyseDBModel", Name="PlateColor")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    internal partial class PlateColor : EntityObject
    {
        #region 工厂方法
    
        /// <summary>
        /// 创建新的 PlateColor 对象。
        /// </summary>
        /// <param name="id">Id 属性的初始值。</param>
        /// <param name="name">Name 属性的初始值。</param>
        public static PlateColor CreatePlateColor(global::System.Int32 id, global::System.String name)
        {
            PlateColor plateColor = new PlateColor();
            plateColor.Id = id;
            plateColor.Name = name;
            return plateColor;
        }

        #endregion

        #region 基元属性
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                OnNameChanging(value);
                ReportPropertyChanging("Name");
                _Name = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Name");
                OnNameChanged();
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();

        #endregion

    
    }
    
    /// <summary>
    /// 没有元数据文档可用。
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="ImageAnalyseDBModel", Name="PlateStructure")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    internal partial class PlateStructure : EntityObject
    {
        #region 工厂方法
    
        /// <summary>
        /// 创建新的 PlateStructure 对象。
        /// </summary>
        /// <param name="id">Id 属性的初始值。</param>
        /// <param name="name">Name 属性的初始值。</param>
        public static PlateStructure CreatePlateStructure(global::System.Int32 id, global::System.String name)
        {
            PlateStructure plateStructure = new PlateStructure();
            plateStructure.Id = id;
            plateStructure.Name = name;
            return plateStructure;
        }

        #endregion

        #region 基元属性
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                OnNameChanging(value);
                ReportPropertyChanging("Name");
                _Name = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Name");
                OnNameChanged();
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();

        #endregion

    
    }
    
    /// <summary>
    /// 没有元数据文档可用。
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="ImageAnalyseDBModel", Name="SafeBeltWear")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    internal partial class SafeBeltWear : EntityObject
    {
        #region 工厂方法
    
        /// <summary>
        /// 创建新的 SafeBeltWear 对象。
        /// </summary>
        /// <param name="id">Id 属性的初始值。</param>
        /// <param name="name">Name 属性的初始值。</param>
        public static SafeBeltWear CreateSafeBeltWear(global::System.Int32 id, global::System.String name)
        {
            SafeBeltWear safeBeltWear = new SafeBeltWear();
            safeBeltWear.Id = id;
            safeBeltWear.Name = name;
            return safeBeltWear;
        }

        #endregion

        #region 基元属性
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                if (_Name != value)
                {
                    OnNameChanging(value);
                    ReportPropertyChanging("Name");
                    _Name = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("Name");
                    OnNameChanged();
                }
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();

        #endregion

    
    }
    
    /// <summary>
    /// 没有元数据文档可用。
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="ImageAnalyseDBModel", Name="SunlightShielding")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    internal partial class SunlightShielding : EntityObject
    {
        #region 工厂方法
    
        /// <summary>
        /// 创建新的 SunlightShielding 对象。
        /// </summary>
        /// <param name="id">Id 属性的初始值。</param>
        /// <param name="name">Name 属性的初始值。</param>
        public static SunlightShielding CreateSunlightShielding(global::System.Int32 id, global::System.String name)
        {
            SunlightShielding sunlightShielding = new SunlightShielding();
            sunlightShielding.Id = id;
            sunlightShielding.Name = name;
            return sunlightShielding;
        }

        #endregion

        #region 基元属性
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                if (_Name != value)
                {
                    OnNameChanging(value);
                    ReportPropertyChanging("Name");
                    _Name = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("Name");
                    OnNameChanged();
                }
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();

        #endregion

    
    }
    
    /// <summary>
    /// 没有元数据文档可用。
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="ImageAnalyseDBModel", Name="VehicleBrand")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    internal partial class VehicleBrand : EntityObject
    {
        #region 工厂方法
    
        /// <summary>
        /// 创建新的 VehicleBrand 对象。
        /// </summary>
        /// <param name="id">Id 属性的初始值。</param>
        /// <param name="name">Name 属性的初始值。</param>
        public static VehicleBrand CreateVehicleBrand(global::System.Int64 id, global::System.String name)
        {
            VehicleBrand vehicleBrand = new VehicleBrand();
            vehicleBrand.Id = id;
            vehicleBrand.Name = name;
            return vehicleBrand;
        }

        #endregion

        #region 基元属性
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int64 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int64 _Id;
        partial void OnIdChanging(global::System.Int64 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int64> ParentId
        {
            get
            {
                return _ParentId;
            }
            set
            {
                OnParentIdChanging(value);
                ReportPropertyChanging("ParentId");
                _ParentId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ParentId");
                OnParentIdChanged();
            }
        }
        private Nullable<global::System.Int64> _ParentId;
        partial void OnParentIdChanging(Nullable<global::System.Int64> value);
        partial void OnParentIdChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                if (_Name != value)
                {
                    OnNameChanging(value);
                    ReportPropertyChanging("Name");
                    _Name = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("Name");
                    OnNameChanged();
                }
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.Byte[] Logo
        {
            get
            {
                return StructuralObject.GetValidValue(_Logo);
            }
            set
            {
                OnLogoChanging(value);
                ReportPropertyChanging("Logo");
                _Logo = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Logo");
                OnLogoChanged();
            }
        }
        private global::System.Byte[] _Logo;
        partial void OnLogoChanging(global::System.Byte[] value);
        partial void OnLogoChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.Byte[] Front
        {
            get
            {
                return StructuralObject.GetValidValue(_Front);
            }
            set
            {
                OnFrontChanging(value);
                ReportPropertyChanging("Front");
                _Front = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Front");
                OnFrontChanged();
            }
        }
        private global::System.Byte[] _Front;
        partial void OnFrontChanging(global::System.Byte[] value);
        partial void OnFrontChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.Byte[] Back
        {
            get
            {
                return StructuralObject.GetValidValue(_Back);
            }
            set
            {
                OnBackChanging(value);
                ReportPropertyChanging("Back");
                _Back = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Back");
                OnBackChanged();
            }
        }
        private global::System.Byte[] _Back;
        partial void OnBackChanging(global::System.Byte[] value);
        partial void OnBackChanged();

        #endregion

    
    }
    
    /// <summary>
    /// 没有元数据文档可用。
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="ImageAnalyseDBModel", Name="VehicleColor")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    internal partial class VehicleColor : EntityObject
    {
        #region 工厂方法
    
        /// <summary>
        /// 创建新的 VehicleColor 对象。
        /// </summary>
        /// <param name="id">Id 属性的初始值。</param>
        /// <param name="name">Name 属性的初始值。</param>
        public static VehicleColor CreateVehicleColor(global::System.Int32 id, global::System.String name)
        {
            VehicleColor vehicleColor = new VehicleColor();
            vehicleColor.Id = id;
            vehicleColor.Name = name;
            return vehicleColor;
        }

        #endregion

        #region 基元属性
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                OnNameChanging(value);
                ReportPropertyChanging("Name");
                _Name = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Name");
                OnNameChanged();
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();

        #endregion

    
    }
    
    /// <summary>
    /// 没有元数据文档可用。
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="ImageAnalyseDBModel", Name="VehicleDetailType")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    internal partial class VehicleDetailType : EntityObject
    {
        #region 工厂方法
    
        /// <summary>
        /// 创建新的 VehicleDetailType 对象。
        /// </summary>
        /// <param name="id">Id 属性的初始值。</param>
        /// <param name="name">Name 属性的初始值。</param>
        /// <param name="parentId">ParentId 属性的初始值。</param>
        public static VehicleDetailType CreateVehicleDetailType(global::System.Int32 id, global::System.String name, global::System.Int32 parentId)
        {
            VehicleDetailType vehicleDetailType = new VehicleDetailType();
            vehicleDetailType.Id = id;
            vehicleDetailType.Name = name;
            vehicleDetailType.ParentId = parentId;
            return vehicleDetailType;
        }

        #endregion

        #region 基元属性
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                OnNameChanging(value);
                ReportPropertyChanging("Name");
                _Name = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Name");
                OnNameChanged();
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 ParentId
        {
            get
            {
                return _ParentId;
            }
            set
            {
                OnParentIdChanging(value);
                ReportPropertyChanging("ParentId");
                _ParentId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ParentId");
                OnParentIdChanged();
            }
        }
        private global::System.Int32 _ParentId;
        partial void OnParentIdChanging(global::System.Int32 value);
        partial void OnParentIdChanged();

        #endregion

    
    }
    
    /// <summary>
    /// 没有元数据文档可用。
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="ImageAnalyseDBModel", Name="VehicleType")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    internal partial class VehicleType : EntityObject
    {
        #region 工厂方法
    
        /// <summary>
        /// 创建新的 VehicleType 对象。
        /// </summary>
        /// <param name="id">Id 属性的初始值。</param>
        /// <param name="name">Name 属性的初始值。</param>
        public static VehicleType CreateVehicleType(global::System.Int32 id, global::System.String name)
        {
            VehicleType vehicleType = new VehicleType();
            vehicleType.Id = id;
            vehicleType.Name = name;
            return vehicleType;
        }

        #endregion

        #region 基元属性
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                OnNameChanging(value);
                ReportPropertyChanging("Name");
                _Name = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Name");
                OnNameChanged();
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();

        #endregion

    
    }

    #endregion

    
}
