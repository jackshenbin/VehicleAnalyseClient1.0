using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleHelper.DataModel;
using VehicleHelper.DAO;

namespace VehicleHelper
{
    public class VehicleEnumService
    {
        private List<VehicleBrandInfo> m_vehicleBrandInfos;
        private List<PlateColorInfo> m_plateColorInfos;
        private List<VehicleColorInfo> m_vehicleColorInfos;
        private List<PlateTypeInfo> m_plateTypeInfos;
        private List<VehicleTypeInfo> m_vehicleTypeInfos;
        private List<VehicleTypeInfo> m_vehicleDetailTypeInfos;
        private List<SafeBeltWearInfo> m_safeBeltWearInfos;
        private List<SunlightShieldingInfo> m_sunlightShieldingInfos;
        private List<PhoneCallingInfo> m_phoneCallingInfos;
        private VehicleBrandDAOService service = new VehicleBrandDAOService();

        public List<VehicleBrandInfo> VehicleBrandInfos
        {
            get 
            {
                if (m_vehicleBrandInfos == null)
                {
                    m_vehicleBrandInfos = new List<VehicleBrandInfo>();
                    VehicleBrand[] brandInfos = service.GetParentBrands();
                    if (brandInfos != null)
                    {
                        foreach (VehicleBrand brandInfo in brandInfos)
                        {
                            VehicleBrandInfo info = new VehicleBrandInfo()
                            {
                                ID = (int)brandInfo.Id,
                                ParentId = (int)(brandInfo.ParentId??0),
                                Name = brandInfo.Name,
                                Logo = null,
                                 Back = null,
                                  Front = null,
                            };
                            if (brandInfo.Logo != null)
                            {
                                System.IO.MemoryStream ms = new System.IO.MemoryStream(brandInfo.Logo);
                                try
                                {
                                    info.Logo = System.Drawing.Image.FromStream(ms);
                                }
                                catch (ArgumentException aex)
                                {
                                    info.Logo = null;
                                }
                            }

                            m_vehicleBrandInfos.Add(info);
                        }
                    }


                }

                m_vehicleBrandInfos.Sort((it1, it2) => it1.ID.CompareTo(it2.ID));
                return m_vehicleBrandInfos;
            }
        }

        public List<VehicleBrandInfo> GetVehicleChildBrandInfos(int id)
        {

            List<VehicleBrandInfo> childs = new List<VehicleBrandInfo>();
            VehicleBrand[] subbrandInfos = service.GetChildBrands(id);
            if (subbrandInfos != null)
            {
                foreach (var item in subbrandInfos)
                {
                    VehicleBrandInfo subinfo = new VehicleBrandInfo()
                    {
                        ID = (int)item.Id,
                        ParentId = (int)(item.ParentId ?? 0),
                        Name = item.Name,
                        Logo = null,
                        Back = item.Back,
                        Front = item.Front,
                    };

                    //if (item.Front != null)
                    //{
                    //    System.IO.MemoryStream ms = new System.IO.MemoryStream(item.Front);
                    //    try
                    //    {
                    //        subinfo.Front = System.Drawing.Image.FromStream(ms);
                    //    }
                    //    catch (ArgumentException aex)
                    //    {
                    //        subinfo.Front = null;
                    //    }
                    //}
                    //if (item.Back != null)
                    //{
                    //    System.IO.MemoryStream ms = new System.IO.MemoryStream(item.Back);
                    //    try
                    //    {
                    //        subinfo.Back = System.Drawing.Image.FromStream(ms);
                    //    }
                    //    catch (ArgumentException aex)
                    //    {
                    //        subinfo.Back = null;
                    //    }
                    //}

                    childs.Add(subinfo);

                }
            }


            childs.Sort((it1, it2) => it1.ID.CompareTo(it2.ID));

            return childs;

        }
        public VehicleBrandInfo GetVehicleBrandInfo(int id)
        {

            VehicleBrand brand = service.GetBrand(id);
            VehicleBrandInfo subinfo = new VehicleBrandInfo();
            if (brand != null)
            {
                    subinfo = new VehicleBrandInfo()
                    {
                        ID = (int)brand.Id,
                        ParentId = (int)(brand.ParentId ?? 0),
                        Name = brand.Name,
                        Logo = null,
                        Back = brand.Back,
                        Front = brand.Front,
                    };
                    //if (brand.Logo != null)
                    //{
                    //    System.IO.MemoryStream ms = new System.IO.MemoryStream(brand.Logo);
                    //    try
                    //    {
                    //        subinfo.Logo = System.Drawing.Image.FromStream(ms);
                    //    }
                    //    catch (ArgumentException aex)
                    //    {
                    //        subinfo.Logo = null;
                    //    }
                    //}

                    //if (brand.Front != null)
                    //{
                    //    System.IO.MemoryStream ms = new System.IO.MemoryStream(brand.Front);
                    //    try
                    //    {
                    //        subinfo.Front = System.Drawing.Image.FromStream(ms);
                    //    }
                    //    catch (ArgumentException aex)
                    //    {
                    //        subinfo.Front = null;
                    //    }
                    //}
                    //if (brand.Back != null)
                    //{
                    //    System.IO.MemoryStream ms = new System.IO.MemoryStream(brand.Back);
                    //    try
                    //    {
                    //        subinfo.Back = System.Drawing.Image.FromStream(ms);
                    //    }
                    //    catch (ArgumentException aex)
                    //    {
                    //        subinfo.Back = null;
                    //    }
                    //}


                }

            return subinfo;
        }

        public List<PlateColorInfo> PlateColorInfos
        {
            get 
            {
                if (m_plateColorInfos == null)
                {
                    m_plateColorInfos = new List<PlateColorInfo>();
                    PlateColor[] colors = service.GetPlateColors();
                    if (colors != null)
                    {
                        foreach (PlateColor item in colors)
                        {
                            PlateColorInfo info = new PlateColorInfo()
                            {
                                ID =  item.Id,
                                Name = item.Name,
                            };
                            m_plateColorInfos.Add(info);
                        }
                    }


                }
                m_plateColorInfos.Sort((it1, it2) => it1.ID.CompareTo(it2.ID));

                return m_plateColorInfos;
            }
        }

        public List<VehicleColorInfo> VehicleColorInfos
        {
            get 
            {
                if (m_vehicleColorInfos == null)
                {
                    m_vehicleColorInfos = new List<VehicleColorInfo>();
                    VehicleColor[] colors = service.GetVehicleColors();
                    if (colors != null)
                    {
                        foreach (VehicleColor item in colors)
                        {
                            VehicleColorInfo info = new VehicleColorInfo()
                            {
                                ID =  item.Id,
                                Name = item.Name,
                            };
                            m_vehicleColorInfos.Add(info);
                        }
                    }


                }
                m_vehicleColorInfos.Sort((it1, it2) => it1.ID.CompareTo(it2.ID));

                return m_vehicleColorInfos;
            }
        }

        public List<PlateTypeInfo> PlateTypeInfos
        {
            get 
            {
                if (m_plateTypeInfos == null)
                {
                    m_plateTypeInfos = new List<PlateTypeInfo>();
                    PlateStructure[] colors = service.GetPlateStructures();
                    if (colors != null)
                    {
                        foreach (PlateStructure item in colors)
                        {
                            PlateTypeInfo info = new PlateTypeInfo()
                            {
                                ID =  item.Id,
                                Name = item.Name,
                            };
                            m_plateTypeInfos.Add(info);
                        }
                    }


                }
                m_plateTypeInfos.Sort((it1, it2) => it1.ID.CompareTo(it2.ID));
                return m_plateTypeInfos;
            }
        }

        public List<VehicleTypeInfo> VehicleTypeInfos
        {
            get 
            {
                if (m_vehicleTypeInfos == null)
                {
                    m_vehicleTypeInfos = new List<VehicleTypeInfo>();
                    VehicleType[] colors = service.GetVehicleTypes();
                    if (colors != null)
                    {
                        foreach (VehicleType item in colors)
                        {
                            VehicleTypeInfo info = new VehicleTypeInfo()
                            {
                                ID =  item.Id,
                                Name = item.Name,
                                  ParentId = 0,

                            };
                            m_vehicleTypeInfos.Add(info);
                        }
                    }

                }
                m_vehicleTypeInfos.Sort((it1, it2) => it1.ID.CompareTo(it2.ID));

                return m_vehicleTypeInfos;
            }
        }

        public List<VehicleTypeInfo> VehicleDetailTypeInfos
        {
            get 
            {
                if (m_vehicleDetailTypeInfos == null)
                {
                    m_vehicleDetailTypeInfos = new List<VehicleTypeInfo>();
                    VehicleDetailType[] sub = service.GetVehicleDetailTypes();
                    if (sub != null)
                    {
                        foreach (VehicleDetailType item in sub)
                        {
                            VehicleTypeInfo info = new VehicleTypeInfo()
                            {
                                ID = item.Id,
                                Name = item.Name,
                                ParentId = item.ParentId,

                            };
                            m_vehicleDetailTypeInfos.Add(info);
                        }
                    }


                }
                m_vehicleDetailTypeInfos.Sort((it1, it2) => it1.ID.CompareTo(it2.ID));

                return m_vehicleDetailTypeInfos;
            }
        }

        public List<SafeBeltWearInfo> SafeBeltWearInfos
        {
            get 
            {
                if (m_safeBeltWearInfos == null)
                {
                    m_safeBeltWearInfos = new List<SafeBeltWearInfo>();
                    SafeBeltWear[] colors = service.GetSafeBeltWears();
                    if (colors != null)
                    {
                        foreach (SafeBeltWear item in colors)
                        {
                            SafeBeltWearInfo info = new SafeBeltWearInfo()
                            {
                                ID =  item.Id,
                                Name = item.Name,

                            };
                            m_safeBeltWearInfos.Add(info);
                        }
                    }

                    m_safeBeltWearInfos.Add(new SafeBeltWearInfo() { ID = -1, Name = "不限" });
                }
                m_safeBeltWearInfos.Sort((it1, it2) => it1.ID.CompareTo(it2.ID));

                return m_safeBeltWearInfos;
            }
        }

        public List<SunlightShieldingInfo> SunlightShieldingInfos
        {
            get 
            {
                if (m_sunlightShieldingInfos == null)
                {
                    m_sunlightShieldingInfos = new List<SunlightShieldingInfo>();
                    SunlightShielding[] colors = service.GetSunlightShieldings();
                    if (colors != null)
                    {
                        foreach (SunlightShielding item in colors)
                        {
                            SunlightShieldingInfo info = new SunlightShieldingInfo()
                            {
                                ID =  item.Id,
                                Name = item.Name,

                            };
                            m_sunlightShieldingInfos.Add(info);
                        }
                    }

                    m_sunlightShieldingInfos.Add(new SunlightShieldingInfo() { ID = -1, Name = "不限" });
                }
                m_sunlightShieldingInfos.Sort((it1, it2) => it1.ID.CompareTo(it2.ID));

                return m_sunlightShieldingInfos;
            }
        }

        public List<PhoneCallingInfo> PhoneCallingInfos
        {
            get 
            {
                if (m_phoneCallingInfos == null)
                {
                    m_phoneCallingInfos = new List<PhoneCallingInfo>();
                    PhoneCalling[] colors = service.GetPhoneCallings();
                    if (colors != null)
                    {
                        foreach (PhoneCalling item in colors)
                        {
                            PhoneCallingInfo info = new PhoneCallingInfo()
                            {
                                ID =  item.Id,
                                Name = item.Name,

                            };
                            m_phoneCallingInfos.Add(info);
                        }
                    }

                    m_phoneCallingInfos.Add(new PhoneCallingInfo() { ID = -1, Name = "不限" });
                }
                m_phoneCallingInfos.Sort((it1, it2) => it1.ID.CompareTo(it2.ID));

                return m_phoneCallingInfos;
            }
        }





        internal void Dispose()
        {
            if (m_vehicleBrandInfos != null && m_vehicleBrandInfos.Count > 0)
            {
                foreach (var item in m_vehicleBrandInfos)
                {
                    if(item.Logo!=null)item.Logo.Dispose();
                    //if (item.Front != null) item.Front.Dispose();
                    //if (item.Back != null) item.Back.Dispose();
                    item.Logo = null;
                    item.Front = null;
                    item.Back = null;
                }
            }
        }
    }
}
