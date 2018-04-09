using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VehicleHelper.DataModel
{
    public class VehiclePropertyInfo
    { 
        public int ID { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
    public class VehicleBrandInfo : VehiclePropertyInfo
    {
        public int ParentId { get; set; }
        public System.Drawing.Image Logo { get; set; }
        public byte[] Front { get; set; }
        public byte[] Back { get; set; }

        public string ImageName { get; set; }
    }
    public class PlateColorInfo : VehiclePropertyInfo
    {

    }
    public class VehicleColorInfo : VehiclePropertyInfo
    {

    }
    public class PlateTypeInfo : VehiclePropertyInfo
    {

    }
    public class VehicleTypeInfo : VehiclePropertyInfo
    {

        public int ParentId { get; set; }

    }
    public class SafeBeltWearInfo : VehiclePropertyInfo
    {

    }
    public class SunlightShieldingInfo : VehiclePropertyInfo
    {

    }
    public class PhoneCallingInfo : VehiclePropertyInfo
    {
    }
}
