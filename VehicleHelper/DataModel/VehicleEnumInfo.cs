using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVXBaseLib.DataModel
{
    public class PropertyInfo
    { 
        public int ID { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
    public class VehicleBrandInfo : PropertyInfo
    {
        public int ParentId { get; set; }
        public System.Drawing.Image Logo { get; set; }
        public System.Drawing.Image Front { get; set; }
        public System.Drawing.Image Back { get; set; }

        public string ImageName { get; set; }
    }
    public class PlateColorInfo : PropertyInfo
    {

    }
    public class VehicleColorInfo : PropertyInfo
    {

    }
    public class PlateTypeInfo : PropertyInfo
    {

    }
    public class VehicleTypeInfo : PropertyInfo
    {

        public int ParentId { get; set; }

    }
    public class SafeBeltWearInfo : PropertyInfo
    {

    }
    public class SunlightShieldingInfo : PropertyInfo
    {

    }
    public class PhoneCallingInfo : PropertyInfo
    {
    }
}
