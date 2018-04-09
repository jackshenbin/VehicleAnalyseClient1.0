using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using AppUtil;
using System.Reflection;
using System.Configuration;
using VehicleHelper.DataModel;

namespace VehicleHelper.DAO
{
    public class VehicleBrandDAOService : IDisposable
    {
        private ImageAnalyseDBEntities m_Entities;

        private object m_SyncObj = new object();

        private string m_dbConnString;

        private List<VehicleBrand> VehicleBrands;
        
        private static string connectionString=@"metadata=res://*/DAO.Model1.csdl|res://*/DAO.Model1.ssdl|res://*/DAO.Model1.msl;provider=System.Data.SQLite;provider connection string='data source=E:\ImageAnalyseDB_V3.s3db'";
        
        public VehicleBrandDAOService()
        {
            //Assembly asm = Assembly.GetExecutingAssembly();

            //string configFile = Path.Combine(Directory.GetParent(asm.Location).FullName, "IVXBaseLib.dll.config");
            //ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
            //configFileMap.ExeConfigFilename = configFile;
            //Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
            //LogService.GetLog("Service").DebugFormat("Configuration path:{0}", config.FilePath);

            
            m_Entities = new ImageAnalyseDBEntities(connectionString);
            System.Data.EntityClient.EntityConnection conn = m_Entities.Connection as System.Data.EntityClient.EntityConnection;
            if (string.IsNullOrEmpty(m_dbConnString))
            {
                string ss = conn.StoreConnection.ConnectionString;
                m_dbConnString = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), Path.GetFileName(ss));
                MyLog4Net.Container.Instance.Log.DebugFormat("IVXBaseLib Database file location: {0}", m_dbConnString);
                m_dbConnString = string.Format("data source={0}", m_dbConnString);
            }
            conn.StoreConnection.ConnectionString = m_dbConnString;
            VehicleBrands = new List<VehicleBrand>();
            VehicleBrands.AddRange(this.m_Entities.VehicleBrands);
        }

        internal ImageAnalyseDBEntities GetImageAnalyseEntities()
        {
            ImageAnalyseDBEntities entities = new ImageAnalyseDBEntities(connectionString);
            System.Data.EntityClient.EntityConnection conn = entities.Connection as System.Data.EntityClient.EntityConnection;
            if (string.IsNullOrEmpty(m_dbConnString))
            {
                string ss = conn.StoreConnection.ConnectionString;
                m_dbConnString = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), Path.GetFileName(ss));
                MyLog4Net.Container.Instance.Log.DebugFormat("IVXBaseLib Database file location: {0}", m_dbConnString);
                m_dbConnString = string.Format("data source={0}", m_dbConnString);
            }
            conn.StoreConnection.ConnectionString = m_dbConnString;
            return entities;
        }

        internal VehicleBrand GetBrand(int id)
        {
            VehicleBrand brand = GetBrand(id, this.m_Entities);

            return brand;
        }

        internal VehicleBrand GetBrand(int id, ImageAnalyseDBEntities m_Entities)
        {
            VehicleBrand brand = null;
            brand = VehicleBrands.Where(t => t.Id == id).SingleOrDefault();

            return brand;
        }

        internal VehicleBrand[] GetParentBrands()
        {
            VehicleBrand[] brands = null;

            try
            {
                var result = VehicleBrands.Where(t => t.ParentId == null);
                if (result.Any())
                {
                    brands = result.ToArray();
                    Array.Sort(brands, new VehicleBrandComparerById());
                }
            }
            finally
            {
                // Monitor.Exit(m_SyncObj);
            }
            return brands;
        }


        internal VehicleBrand[] GetChildBrands(int id)
        {
            VehicleBrand[] brands = null;

            try
            {
                var result = VehicleBrands.Where(t => t.ParentId == id);
                if (result.Any())
                {
                    brands = result.ToArray();
                    Array.Sort(brands, new VehicleBrandComparer());
                }

            }
            finally
            {
                // Monitor.Exit(m_SyncObj);
            }
            return brands;
        }


        internal PlateColor[] GetPlateColors()
        {
            PlateColor[] brands = null;

            try
            {
                var result = m_Entities.PlateColors;
                if (result.Any())
                {
                    brands = result.ToArray();
                }
            }
            finally
            {
                // Monitor.Exit(m_SyncObj);
            }
            return brands;

        }
        internal VehicleColor[] GetVehicleColors()
        {
            VehicleColor[] brands = null;

            try
            {
                var result = m_Entities.VehicleColors;
                if (result.Any())
                {
                    brands = result.ToArray();
                }
            }
            finally
            {
                // Monitor.Exit(m_SyncObj);
            }
            return brands;

        }

        internal PlateStructure[] GetPlateStructures()
        {
            PlateStructure[] brands = null;

            try
            {
                var result = m_Entities.PlateStructures;
                if (result.Any())
                {
                    brands = result.ToArray();
                }
            }
            finally
            {
                // Monitor.Exit(m_SyncObj);
            }
            return brands;

        }

        internal VehicleType[] GetVehicleTypes()
        {
            VehicleType[] brands = null;

            try
            {
                var result = m_Entities.VehicleTypes;
                if (result.Any())
                {
                    brands = result.ToArray();
                }
            }
            finally
            {
                // Monitor.Exit(m_SyncObj);
            }
            return brands;

        }
        internal VehicleDetailType[] GetVehicleDetailTypes()
        {
            VehicleDetailType[] brands = null;

            try
            {
                var result = m_Entities.VehicleDetailTypes;
                if (result.Any())
                {
                    brands = result.ToArray();
                }
            }
            finally
            {
                // Monitor.Exit(m_SyncObj);
            }
            return brands;

        }

        internal SafeBeltWear[] GetSafeBeltWears()
        {
            SafeBeltWear[] brands = null;

            try
            {
                var result = m_Entities.SafeBeltWears;
                if (result.Any())
                {
                    brands = result.ToArray();
                }
            }
            finally
            {
                // Monitor.Exit(m_SyncObj);
            }
            return brands;

        }

        internal SunlightShielding[] GetSunlightShieldings()
        {
            SunlightShielding[] brands = null;

            try
            {
                var result = m_Entities.SunlightShieldings;
                if (result.Any())
                {
                    brands = result.ToArray();
                }
            }
            finally
            {
                // Monitor.Exit(m_SyncObj);
            }
            return brands;

        }

        internal PhoneCalling[] GetPhoneCallings()
        {
            PhoneCalling[] brands = null;

            try
            {
                var result = m_Entities.PhoneCallings;
                if (result.Any())
                {
                    brands = result.ToArray();
                }
            }
            finally
            {
                // Monitor.Exit(m_SyncObj);
            }
            return brands;

        }
        public void Dispose()
        {
            m_Entities.Dispose();
        }

        public bool SaveChanges(ImageAnalyseDBEntities entities=null)
        {
            bool result = false;

            ImageAnalyseDBEntities dbEntities = entities == null ? m_Entities : entities;
            if(dbEntities != null)
            {
                dbEntities.SaveChanges();
            }

            return result;
        }
    }

    internal class VehicleBrandComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            int nRet = 0;
            VehicleBrand b1 = x as VehicleBrand;
            VehicleBrand b2 = y as VehicleBrand;

            if (b1 != null && b2 != null)
            {
                nRet = string.CompareOrdinal(b1.Name, b2.Name);
            }
            return nRet;
        }
    }

    internal class VehicleBrandComparerById : IComparer
    {
        public int Compare(object x, object y)
        {
            int nRet = 0;
            VehicleBrand b1 = x as VehicleBrand;
            VehicleBrand b2 = y as VehicleBrand;

            if (b1 != null && b2 != null)
            {
                nRet = (int)(b1.Id - b2.Id);
            }
            return nRet;
        }
    }
}
