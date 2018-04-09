using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bocom.ImageAnalysisClient.DataModel;
using System.Data.Objects;
using System.Drawing;
using System.Linq.Expressions;
using System.Threading;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Data.EntityClient;
using System.IO;
using WinFormAppUtil;
using System.Collections;
// using System.Data.Entity.Core.EntityClient;

namespace Bocom.ImageAnalysisClient.Service.DAO
{
    class DAOService
    {
        #region Fileds

        // private ImageAnalyseEntities m_Entities;

        private object m_SyncObj = new object();

        private string m_dbConnString;

        private readonly static int TIMEOUT = 10 * 1000;

        /// <summary>
        /// 行为映射表，整数每位表示一种行为， 如 "101" 对映到 Behavior 表记录一个Id
        /// </summary>
        private Dictionary<string, int> m_DTBehaviorComposeText2Id;

        /// <summary>
        /// 与上面的区别在于： 单个行为Id 还包含-1， 表示不限；对应的 value是一个字符串， 
        /// 表示多个记录Id； 用于缓存，减少查询时
        /// </summary>
        private Dictionary<string, string> m_DTBebaviorComposeText2Ids;

        private static string connectionString = @"metadata=res://*/DAO.ImageAnalyseModel.csdl|res://*/DAO.ImageAnalyseModel.ssdl|res://*/DAO.ImageAnalyseModel.msl;provider=System.Data.SQLite;provider connection string='data source=F:\ImageAnalyseDB.s3db'";

        #endregion

        #region Constructors

        internal DAOService()
        {
            //// EntityConnection conn = new EntityConnection()
            //// string conn = "metadata=res://*/DAO.ImageAnalyseModel.csdl|res://*/DAO.ImageAnalyseModel.ssdl|res://*/DAO.ImageAnalyseModel.msl;provider=System.Data.SQLite;provider connection string=&quot;data source=F:\jim\ImageAnalyseDB2.s3db&quot;" providerName="System.Data.EntityClient";
            //m_Entities = new ImageAnalyseEntities();
            //System.Data.EntityClient.EntityConnection conn = m_Entities.Connection as System.Data.EntityClient.EntityConnection;
            //string ss = conn.StoreConnection.ConnectionString;
            //string dbFileName = Path.Combine(System.Environment.CurrentDirectory, Path.GetFileName(ss));
            //conn.StoreConnection.ConnectionString = string.Format("data source={0}", dbFileName);

            //// SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder(((EntityConnection)m_Entities.Connection).ConnectionString);
            m_DTBehaviorComposeText2Id = new Dictionary<string, int>();
            BuildIllegalBehaviorTable();
            BuildPlateColorTable();
            BuildPlateStructureTable();
            BuildVehicleColorTable();
            BuildVehicleDetailTypeTable();
            BuildVehicleTypeTable();

            m_DTBebaviorComposeText2Ids = new Dictionary<string, string>();
        }


        #endregion

        internal ImageAnalyseEntities GetImageAnalyseEntities()
        {
            try
            {
                Trace.WriteLine("GetImageAnalyseEntities connectionString:" + connectionString);
                MyLog4Net.Container.Instance.Log.Debug("GetImageAnalyseEntities connectionString:" + connectionString);

                ImageAnalyseEntities entities = new ImageAnalyseEntities(connectionString);
                System.Data.EntityClient.EntityConnection conn = entities.Connection as System.Data.EntityClient.EntityConnection;
                Trace.WriteLine("GetImageAnalyseEntities m_dbConnString:" + m_dbConnString);
                MyLog4Net.Container.Instance.Log.Debug("GetImageAnalyseEntities m_dbConnString:" + m_dbConnString);
                if (string.IsNullOrEmpty(m_dbConnString))
                {
                    string ss = conn.StoreConnection.ConnectionString;
                    m_dbConnString = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), Path.GetFileName(ss));
                    MyLog4Net.Container.Instance.Log.DebugFormat("Database file location: {0}", m_dbConnString);
                    m_dbConnString = string.Format("data source={0}", m_dbConnString);
                }
                conn.StoreConnection.ConnectionString = m_dbConnString;
                return entities;
            }
            catch(Exception ex)
            {
                Trace.WriteLine("GetImageAnalyseEntities:" + ex);
                MyLog4Net.Container.Instance.Log.Error("GetImageAnalyseEntities:"+ex);
                return null;
            }
        }

        #region Private helper functions

        private void BuildIllegalBehaviorTable()
        {
            ImageAnalyseEntities entities;
            if (LocknGetDBContext(m_SyncObj, "BuildIllegalBehaviorTable", out entities))
            {
                try
                {
                    IllegalBehavior[] behaviors = entities.IllegalBehaviors.ToArray();

                    if (behaviors != null && behaviors.Length > 0)
                    {
                        string key;
                        foreach (IllegalBehavior behavior in behaviors)
                        {
                            key = string.Format("{0}#{1}#{2}", behavior.NotWearSafeBelt, behavior.SunShielding, behavior.PhoneCalling);
                            if (!m_DTBehaviorComposeText2Id.ContainsKey(key))
                            {
                                m_DTBehaviorComposeText2Id.Add(key, (int)behavior.Id);
                            }
                            else
                            {
                                Debug.Assert(false);
                            }
                        }
                    }
                }
                finally
                {
                    UnlocknDisposeDBContext(m_SyncObj, "BuildIllegalBehaviorTable", entities);
                }
            }

            Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_SafeBeltWear, -1, "不限");
            Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_SafeBeltWear, 0, "未识别");
            Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_SafeBeltWear, 1, "未系");
            Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_SafeBeltWear, 2, "已系");
            Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_SafeBeltWear, 3, "无人");

            Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_SunlightShielding, -1, "不限");
            Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_SunlightShielding, 0, "未识别");
            Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_SunlightShielding, 1, "无");
            Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_SunlightShielding, 2, "有");

            Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_PhoneCalling, -1, "不限");
            Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_PhoneCalling, 0, "未识别");
            Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_PhoneCalling, 1, "否");
            Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_PhoneCalling, 2, "是");

        }

        private void BuildVehicleTypeTable()
        {
            ImageAnalyseEntities entities;

            if (LocknGetDBContext(m_SyncObj, "BuildVehicleTypeTable", out entities))
            {
                try
                {
                    List<VehicleType> vehicleTypes = entities.VehicleTypes.ToList();

                    if (vehicleTypes != null && vehicleTypes.Count > 0)
                    {
                        foreach (VehicleType vt in vehicleTypes)
                        {
                            Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_VehicleType, vt.Id, vt.Name);
                        }
                    }
                }
                finally
                {
                    UnlocknDisposeDBContext(m_SyncObj, "BuildVehicleTypeTable", entities);
                }
            }
        }

        private void BuildVehicleDetailTypeTable()
        {
            ImageAnalyseEntities entities;

            if (LocknGetDBContext(m_SyncObj, "BuildVehicleDetailTypeTable", out entities))
            {
                try
                {
                    List<VehicleDetailType> detailTypes = entities.VehicleDetailTypes.ToList();
                    
                    detailTypes.Sort(new VehicleDetailTypeComparer());
                    Constant.SDT_PropertyInfo_VehicleDetailType = new Dictionary<int, ModelPropertyInfo>();
                    if (detailTypes != null && detailTypes.Count > 0)
                    {
                        foreach (VehicleDetailType vt in detailTypes)
                        {
                            Constant.UpdatenGetProperty(Constant.SDT_PropertyInfo_VehicleDetailType, vt.Id, vt.Name);
                        }
                    }
                }
                finally
                {
                    UnlocknDisposeDBContext(m_SyncObj, "BuildVehicleDetailTypeTable", entities);
                }
            }
        }

        private void BuildVehicleColorTable()
        {
            ImageAnalyseEntities entities;

            if (LocknGetDBContext(m_SyncObj, "BuildVehicleColorTable", out entities))
            {
                try
                {
                    List<VehicleColor> colors = entities.VehicleColors.ToList();

                    if (colors != null && colors.Count > 0)
                    {
                        foreach (VehicleColor vt in colors)
                        {
                            Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_VehicleColor, vt.Id, vt.Name);
                        }
                    }
                }
                finally
                {
                    UnlocknDisposeDBContext(m_SyncObj, "BuildVehicleColorTable", entities);
                }
            }
        }

        private void BuildPlateColorTable()
        {
            ImageAnalyseEntities entities;

            if (LocknGetDBContext(m_SyncObj, "BuildPlateColorTable", out entities))
            {
                try
                {
                    List<PlateColor> colors = entities.PlateColors.ToList();

                    if (colors != null && colors.Count > 0)
                    {
                        foreach (PlateColor vt in colors)
                        {
                            Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_PlateColor, vt.Id, vt.Name);
                        }
                    }
                }
                finally
                {
                    UnlocknDisposeDBContext(m_SyncObj, "BuildPlateColorTable", entities);
                }
            }
        }

        private void BuildPlateStructureTable()
        {
            ImageAnalyseEntities entities;

            if (LocknGetDBContext(m_SyncObj, "BuildPlateStructureTable", out entities))
            {
                try
                {
                    List<PlateStructure> plateStructures = entities.PlateStructures.ToList();

                    if (plateStructures != null && plateStructures.Count > 0)
                    {
                        foreach (PlateStructure vt in plateStructures)
                        {
                            Constant.UpdatenGetProperty(ref Constant.SDT_PropertyInfo_PlateType, vt.Id, vt.Name);
                        }
                    }
                }
                finally
                {
                    UnlocknDisposeDBContext(m_SyncObj, "BuildPlateStructureTable", entities);
                }
            }
        }

        private bool LocknGetDBContext(object syncObj, string functionName, out ImageAnalyseEntities entities)
        {
            bool bRet = false;
            entities = null;
            MyLog4Net.Container.Instance.Log.DebugFormat("{0}, Entering using entities  ...", functionName);
            bRet = Monitor.TryEnter(m_SyncObj, TIMEOUT);
            if(bRet)
            {
                entities = GetImageAnalyseEntities();
            }
            else
            {
                string msg = string.Format("{0}, Timeout access database", functionName);
                Debug.Assert(false, msg);
                MyLog4Net.Container.Instance.Log.Error(msg);
            }

            return bRet;
        }

        private void UnlocknDisposeDBContext(object syncObj, string functionName, ImageAnalyseEntities entities)
        {
            Monitor.Exit(syncObj);
            entities.Dispose();
            MyLog4Net.Container.Instance.Log.DebugFormat("{0}, Leave using entities  ...", functionName);
        }

        #endregion

        #region Task functions

        private AnalyseTask Parse(Task task)
        {
            AnalyseTask analyseTask = new AnalyseTask()
            {
                TaskId = (uint)task.Id,
                Name = task.Name,
                CameraId = task.CameraId.HasValue ? (int)task.CameraId.Value : -1,
                CreateTime = task.CreateTime,
                FinishedTime = task.FinishedTime,
                FileType = (FileType)task.FileType,
                StartAnalyseTime = task.StartAnalyseTime,
                Status = (TaskStatus)(int)task.Status,
                IncludeChildFolder = task.IncludeChildFolder
            };

            PictureSource picSource = new PictureSource()
            {
                Path = task.URL,
                UserName = task.FileAccessUserName,
                Password = task.FileAccessPassword,
                FileType = (FileType)task.FileType,
                Count = (int)task.FileCount,
                ImageErrorCount = (int)(task.ImageErrorCount.HasValue ? task.ImageErrorCount.Value : 0),
                RecognizedCount = (int)(task.RecognizedCount.HasValue ? task.RecognizedCount.Value : 0),
                NoPlateCount = (int)(task.NoPlateCount.HasValue ? task.NoPlateCount.Value : 0),
                NotRecognizedCount = (int)(task.NotRecognizedCount.HasValue ? task.NotRecognizedCount.Value : 0),
                IncludeSubFolder = task.IncludeChildFolder
            };
            analyseTask.PictureSource = picSource;

            Calibration calibration = new Calibration()
            {
                PicHeight = task.Calibration_PicH,
                PicWidth = task.Calibration_PicW,
                SceneType = (int)task.Calibration_PlateLocationType,
                SnapshotInterval = task.Calibration_SnapshotInterval,
                TimeStamp = task.Calibration_DateTime,

                PlateDetectionArea = new Rectangle(
                    task.Calibration_DetectionAreaX,
                    task.Calibration_DetectionAreaY,
                    task.Calibration_DetectionAreaW,
                    task.Calibration_DetectionAreaH),

                PlateArea = new Rectangle(
                   task.Calibration_PlateAreaX,
                   task.Calibration_PlateAreaY,
                   task.Calibration_PlateAreaW,
                   task.Calibration_PlateAreaH),

                PlateRangeMin = task.Calibration_PlateRangeMin,
                PlateRangeMax = task.Calibration_PlateRangeMax
            };

            analyseTask.Calibration = calibration;

            return analyseTask;
        }

        internal List<AnalyseTask> GetAllTasks()
        {
            List<AnalyseTask> analyseTasks = null;
            ImageAnalyseEntities entities;

            if (LocknGetDBContext(m_SyncObj, "GetAllTasks", out entities))
            {
                try
                {
                    List<Task> tasks = entities.Tasks.ToList();

                    AnalyseTask analyseTask;
                    if (tasks != null && tasks.Count > 0)
                    {
                        analyseTasks = new List<AnalyseTask>();
                        foreach (Task task in tasks)
                        {
                            analyseTask = Parse(task);
                            analyseTasks.Add(analyseTask);
                        }
                    }
                }
                finally
                {
                    UnlocknDisposeDBContext(m_SyncObj, "GetAllTasks", entities);
                }
            }

            return analyseTasks;
        }

        internal void AddTask(AnalyseTask analyseTask)
        {
            Task task = new Task()
            {
                // Id = analyseTask.I
                CreateTime = analyseTask.CreateTime,
                NotRecognizedCount = 0,
                RecognizedCount = 0,
                NoPlateCount = 0,
                ImageErrorCount = 0,
                FileCount = analyseTask.PictureSource.Count,
                Name = analyseTask.Name,
                CameraId = analyseTask.CameraId,
                Status = (byte)analyseTask.Status,
                URL = analyseTask.PictureSource.Path,
                FileType = (byte)analyseTask.FileType,
                FileAccessUserName = analyseTask.PictureSource.UserName,
                FileAccessPassword = analyseTask.PictureSource.Password,
                IncludeChildFolder = analyseTask.IncludeChildFolder
            };

            if (analyseTask.Calibration != null)
            {
                task.Calibration_PicW = analyseTask.Calibration.PicWidth;
                task.Calibration_PicH = analyseTask.Calibration.PicHeight;

                task.Calibration_PlateLocationType = (byte)analyseTask.Calibration.SceneType;
                task.Calibration_SnapshotInterval = (short)analyseTask.Calibration.SnapshotInterval;
                task.Calibration_DateTime = analyseTask.Calibration.TimeStamp;

                task.Calibration_DetectionAreaX = analyseTask.Calibration.PlateDetectionArea.X;
                task.Calibration_DetectionAreaY = analyseTask.Calibration.PlateDetectionArea.Y;
                task.Calibration_DetectionAreaW = analyseTask.Calibration.PlateDetectionArea.Width;
                task.Calibration_DetectionAreaH = analyseTask.Calibration.PlateDetectionArea.Height;

                task.Calibration_PlateAreaX = analyseTask.Calibration.PlateArea.X;
                task.Calibration_PlateAreaY = analyseTask.Calibration.PlateArea.Y;
                task.Calibration_PlateAreaW = analyseTask.Calibration.PlateArea.Width;
                task.Calibration_PlateAreaH = analyseTask.Calibration.PlateArea.Height;

                task.Calibration_PlateRangeMax = analyseTask.Calibration.PlateRangeMax;
                task.Calibration_PlateRangeMin = analyseTask.Calibration.PlateRangeMin;
            }

            MyLog4Net.Container.Instance.Log.DebugFormat("Entering AddTask {0} ...", analyseTask.Name);

            if (task.Id != 0)
            {
                MyLog4Net.Container.Instance.Log.DebugFormat("AddTask: added result: {0}", task.Id);
                analyseTask.TaskId = (uint)task.Id;
            }
            else
            {
                ImageAnalyseEntities entities;
                if (LocknGetDBContext(m_SyncObj, "AddTasks", out entities))
                {
                    try
                    {
                        entities.AddToTasks(task);
                        CommitChanges(entities);
                        // 需要更新Id
                        Task temp = entities.Tasks.Where(t => t.Name == task.Name && t.CreateTime.Value == task.CreateTime.Value).Single();
                        analyseTask.TaskId = (uint)temp.Id;
                    }
                    finally
                    {
                        UnlocknDisposeDBContext(m_SyncObj, "AddTasks", entities);
                    }
                }
            }
            MyLog4Net.Container.Instance.Log.DebugFormat("Leave AddTask {0}", analyseTask.Name);
        }

        internal void DeleteTask(AnalyseTask analyseTask)
        {
            ImageAnalyseEntities entities;
            if (LocknGetDBContext(m_SyncObj, "DeleteTasks", out entities))
            {
                try
                {
                    Task task = GetTask((int)analyseTask.TaskId, entities);

                    if (task != null)
                    {
                        if (task.AnalyseResults != null)
                        {
                            if (task.ImageErrorCount != 0 || task.RecognizedCount != 0 || task.NotRecognizedCount != 0 || task.NoPlateCount != 0)
                            {
                                DeleteAnalyseRecordsByTask(new List<int> { (int)task.Id }, entities);
                            }
                        }
                        entities.Tasks.DeleteObject(task);
                        CommitChanges(entities);
                    }
                }
                finally
                {
                    UnlocknDisposeDBContext(m_SyncObj, "DeleteTasks", entities);
                }
            }
        }

        internal void SaveTask(AnalyseTask analyseTask)
        {
            ImageAnalyseEntities entities;
            if (LocknGetDBContext(m_SyncObj, "SaveTask", out entities))
            {
                try
                {
                    SaveTask(analyseTask, entities);
                }
                finally
                {
                    UnlocknDisposeDBContext(m_SyncObj, "SaveTask", entities);
                }
            }
        }

        internal void SaveTask(AnalyseTask analyseTask, ImageAnalyseEntities m_Entities, bool commit = true)
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("Entering SaveTask {0} ...", analyseTask.Name);

            Task task = GetTask((int)analyseTask.TaskId, m_Entities);

            if (task != null)
            {
                task.Name = analyseTask.Name;
                task.Status = (decimal)(int)analyseTask.Status;
                if (analyseTask.PictureSource != null)
                {
                    task.FileCount = analyseTask.PictureSource.Count;
                    task.RecognizedCount = analyseTask.PictureSource.RecognizedCount;
                    task.NoPlateCount = analyseTask.PictureSource.NoPlateCount;
                    task.ImageErrorCount = analyseTask.PictureSource.ImageErrorCount;
                    task.NotRecognizedCount = analyseTask.PictureSource.NotRecognizedCount;
                    task.StartAnalyseTime = analyseTask.StartAnalyseTime;
                    task.FinishedTime = analyseTask.FinishedTime;
                    task.IncludeChildFolder = analyseTask.IncludeChildFolder;
                }

                if (analyseTask.Calibration != null)
                {
                    task.Calibration_PicW = analyseTask.Calibration.PicWidth;
                    task.Calibration_PicH = analyseTask.Calibration.PicHeight;

                    task.Calibration_PlateLocationType = (byte)analyseTask.Calibration.SceneType;
                    task.Calibration_SnapshotInterval = (short)analyseTask.Calibration.SnapshotInterval;
                    task.Calibration_DateTime = analyseTask.Calibration.TimeStamp;

                    task.Calibration_DetectionAreaX = analyseTask.Calibration.PlateDetectionArea.X;
                    task.Calibration_DetectionAreaY = analyseTask.Calibration.PlateDetectionArea.Y;
                    task.Calibration_DetectionAreaW = analyseTask.Calibration.PlateDetectionArea.Width;
                    task.Calibration_DetectionAreaH = analyseTask.Calibration.PlateDetectionArea.Height;

                    task.Calibration_PlateAreaX = analyseTask.Calibration.PlateArea.X;
                    task.Calibration_PlateAreaY = analyseTask.Calibration.PlateArea.Y;
                    task.Calibration_PlateAreaW = analyseTask.Calibration.PlateArea.Width;
                    task.Calibration_PlateAreaH = analyseTask.Calibration.PlateArea.Height;

                    task.Calibration_PlateRangeMax = analyseTask.Calibration.PlateRangeMax;
                    task.Calibration_PlateRangeMin = analyseTask.Calibration.PlateRangeMin;
                }

                if (commit)
                {
                    CommitChanges(m_Entities);
                }
                MyLog4Net.Container.Instance.Log.DebugFormat("Leave SaveTask {0}", analyseTask.Name);
            }
        }

        internal Task GetTask(int id)
        {
            Task task = null;
            ImageAnalyseEntities entities;
            if (LocknGetDBContext(m_SyncObj, "GetTask", out entities))
            {
                try
                {
                    task = GetTask(id, entities);
                }
                finally
                {
                    UnlocknDisposeDBContext(m_SyncObj, "GetTask", entities);
                }
            }

            return task;
        }

        internal Task GetTask(int id, ImageAnalyseEntities m_Entities)
        {
            Task task = null;

            MyLog4Net.Container.Instance.Log.DebugFormat("GetTask {0}: got lock", id);
            task = m_Entities.Tasks.Where(t => t.Id == id).SingleOrDefault();
           
            return task;
        }

        internal AnalyseTask GetTaskByName(string name)
        {
            AnalyseTask analyseTask = null;
            ImageAnalyseEntities entities;
            if (LocknGetDBContext(m_SyncObj, "GetTaskByName", out entities))
            {
                try
                {
                    analyseTask = GetTaskByName(name, entities);
                }
                finally
                {
                    UnlocknDisposeDBContext(m_SyncObj, "GetTaskByName", entities);
                }
            }

            return analyseTask;
        }

        private AnalyseTask GetTaskByName(string name, ImageAnalyseEntities m_Entities)
        {
            Task task = null;

            if (!string.IsNullOrEmpty(name))
            {
                task = m_Entities.Tasks.Where(t => string.Compare(t.Name, name, true) == 0).SingleOrDefault();
            }

            AnalyseTask analyseTask = null;
            if (task != null)
            {
                analyseTask = Parse(task);
            }

            return analyseTask;
        }

        internal bool IsTaskExist(string name)
        {
            bool bRet = false;
            if (!string.IsNullOrEmpty(name))
            {
                ImageAnalyseEntities entities;
                if (LocknGetDBContext(m_SyncObj, "IsTaskExist", out entities))
                {
                    try
                    {
                        bRet = entities.Tasks.Where(t => string.Compare(t.Name, name, true) == 0).Any();
                    }
                    finally
                    {
                        UnlocknDisposeDBContext(m_SyncObj, "IsTaskExist", entities);
                    }
                }
            }

            return bRet;
        }

        #endregion

        #region Analyse result functions

        private AnalyseRecord Parse(AnalyseResult result, ImageAnalyseEntities m_Entities)
        {
            result.VehicleBrand = GetBrand((int)result.Manufacturer, m_Entities);
            result.PlateColor1 = GetPlateColor(result.PlateColor, m_Entities);
            result.VehicleColor1 = GetVehicleColor(result.VehicleColor, m_Entities);
            result.VehicleType1 = GetVehicleType(result.VehicleType, m_Entities);
            result.VehicleDetailType = GetVehicleDetailType(result.DetailVehicleType, m_Entities);
            result.PlateStructure = GetPlateStructure(result.PlateType, m_Entities);

            AnalyseRecord record = new AnalyseRecord();

            record.Id = (int)result.Id;
            record.DetailVehicleTypeInfo = result.VehicleDetailType == null ? Constant.PropertyInfo_UNKNOWN :
                Constant.SDT_PropertyInfo_VehicleDetailType[result.VehicleDetailType.Id];
            //Constant.UpdatenGetProperty(ref 
            //    Constant.SDT_PropertyInfo_VehicleDetailType, result.VehicleDetailType.Id, result.VehicleDetailType.Name);

            record.ErrorCode = result.ErrorCode;

            record.BrandInfo = result.VehicleBrand == null ? 
                 new ModelPropertyInfo(){ ID=(int)result.Manufacturer,Name = "{"+result.Manufacturer+"}"} :
            Constant.UpdatenGetProperty(ref 
                Constant.SDT_PropertyInfo_VehicleBrand, (int)result.VehicleBrand.Id, result.VehicleBrand.Name);

            record.PicId = result.FileName;

            record.PlateColorInfo = result.PlateColor1 == null ? Constant.SDT_PropertyInfo_PlateColor[0] :
            Constant.UpdatenGetProperty(ref 
                Constant.SDT_PropertyInfo_PlateColor, result.PlateColor1.Id, result.PlateColor1.Name);

            record.PlateNumber = result.PlateNumber;
            record.PlateNumberReliability = result.PlateReliability.HasValue ? result.PlateReliability.Value : 0;

            record.PlateTypeInfo = result.PlateStructure == null ? Constant.PropertyInfo_UNKNOWN :
            Constant.UpdatenGetProperty(ref 
                Constant.SDT_PropertyInfo_PlateType, result.PlateStructure.Id, result.PlateStructure.Name);

            record.VehicleColorInfo = result.VehicleColor1 == null ? Constant.SDT_PropertyInfo_VehicleColor[0] :
            Constant.UpdatenGetProperty(ref 
                Constant.SDT_PropertyInfo_VehicleColor, result.VehicleColor1.Id, result.VehicleColor1.Name);

            record.VehicleTypeInfo = result.VehicleType1 == null ? Constant.PropertyInfo_UNKNOWN :
            Constant.UpdatenGetProperty(ref 
                Constant.SDT_PropertyInfo_VehicleType, result.VehicleType1.Id, result.VehicleType1.Name);


            if (result.VehicleBrand != null && result.VehicleBrand.VehicleBrand2 != null)
            {
                // 父品牌
                record.ParentBrandInfo = DataModel.Constant.UpdatenGetProperty(ref 
                Constant.SDT_PropertyInfo_VehicleBrand, (int)result.VehicleBrand.VehicleBrand2.Id, result.VehicleBrand.VehicleBrand2.Name);
            }
            else
            {
                // result.VehicleBrand = Constant.PropertyInfo_UNKNOWN;
            }

            record.ManufacturerReliability = (result.Manufacturer == -1 ?
                0 : (result.ManufactureReliability.HasValue ?
                    result.ManufactureReliability.Value : 0));

            record.PlateNumberReliability = result.ErrorCode != 0 ?
                0 : record.PlateNumberReliability;
            
            if (result.DriverIllegalBehavior.HasValue)
            {
                record.DriverWearingSafeBelt = Constant.UpdatenGetProperty(ref 
                Constant.SDT_PropertyInfo_SafeBeltWear, (int)result.IllegalBehavior1Reference.Value.NotWearSafeBelt, "非法");

                record.DriverSunlightShield = Constant.UpdatenGetProperty(ref 
            Constant.SDT_PropertyInfo_SunlightShielding, (int)result.IllegalBehavior1Reference.Value.SunShielding, "非法");

                record.DriverPhoneCalling = Constant.UpdatenGetProperty(ref 
            Constant.SDT_PropertyInfo_PhoneCalling, (int)result.IllegalBehavior1Reference.Value.PhoneCalling, "非法");
            }
            else
            {
                record.DriverWearingSafeBelt = Constant.PropertyInfo_UNKNOWN;
                record.DriverSunlightShield = Constant.PropertyInfo_UNKNOWN;
                record.DriverPhoneCalling = Constant.PropertyInfo_UNKNOWN;
            }
            if (result.CoDriverIllegalBehavior.HasValue)
            {
                record.CoDriverWearingSafeBelt = Constant.UpdatenGetProperty(ref 
                Constant.SDT_PropertyInfo_SafeBeltWear, (int)result.IllegalBehaviorReference.Value.NotWearSafeBelt, "非法");

                record.CoDriverSunlightShield = Constant.UpdatenGetProperty(ref 
            Constant.SDT_PropertyInfo_SunlightShielding, (int)result.IllegalBehaviorReference.Value.SunShielding, "非法");

                record.CoDriverPhoneCalling = Constant.UpdatenGetProperty(ref 
            Constant.SDT_PropertyInfo_PhoneCalling, (int)result.IllegalBehaviorReference.Value.PhoneCalling, "非法");
            }
            else
            {
                record.CoDriverWearingSafeBelt = Constant.PropertyInfo_UNKNOWN;
                record.CoDriverSunlightShield = Constant.PropertyInfo_UNKNOWN;
                record.CoDriverPhoneCalling = Constant.PropertyInfo_UNKNOWN;
            }
            record.VehicleRegion = GetRectRegion(result.VehicleRegion);
            record.PlateRegion = GetRectRegion(result.PlateRegion);
            record.DriverRegion = GetRectRegion(result.DriverRegion);
            record.CoDriverRegion = GetRectRegion(result.CoDriverRegion);

            return record;
        }

        private Rectangle GetRectRegion(string text)
        {
            Rectangle rect = Rectangle.Empty;

            if (!string.IsNullOrEmpty(text))
            {
                string[] segs = text.Split(",".ToCharArray());
                if (segs != null && segs.Length == 4)
                {
                    int x, y, w, h;
                    if (int.TryParse(segs[0], out x) &&
                        int.TryParse(segs[1], out y) &&
                        int.TryParse(segs[2], out w) &&
                        int.TryParse(segs[3], out h))
                    {
                        rect = new Rectangle(x, y, w, h);
                    }
                }
            }

            return rect;
        }

        private string ComposeQuerySql(List<ObjectParameter> paras, AnalyseTask task, string plateNumber, string vehicleDetailType, VehicleBrandInfo brand,
             int resultType, int vehicleColor, int plateColor)
        {
            paras.Add(new ObjectParameter("taskId", (int)task.TaskId));

            StringBuilder sb = new StringBuilder("SELECT VALUE temp FROM ImageAnalyseEntities.AnalyseResults as temp WHERE temp.TaskId=@taskId");
            if (!string.IsNullOrEmpty(plateNumber))
            {
                sb.Append(" AND temp.PlateNumber LIKE '%'+@plateNumber+'%'");
                paras.Add(new ObjectParameter("plateNumber", plateNumber));
            }

            if (brand != null)
            {
                sb.Append(" AND temp.Manufacturer LIKE '%'+@Manufacturer+'%'");
                paras.Add(new ObjectParameter("Manufacturer", brand.Name));
            }

            if (!string.IsNullOrEmpty(vehicleDetailType))
            {
                sb.Append(" AND temp.DetailVehicleType LIKE '%'+@DetailVehicleType+'%'");
                paras.Add(new ObjectParameter("DetailVehicleType", vehicleDetailType));
            }

            if (resultType == 1)
            {
                sb.Append(" AND temp.ErrorCode=0");
            }
            else if (resultType == 2)
            {
                sb.Append(" AND temp.ErrorCode!=0");
            }

            if (vehicleColor != 0)
            {
                // sb.Append(" AND temp.VehicleColor LIKE '%'+@VehicleColor+'%'");
                sb.Append(" AND temp.VehicleColor=VehicleColor");
                paras.Add(new ObjectParameter("VehicleColor", vehicleColor));
            }

            if (plateColor != 0)
            {
                sb.Append(" AND temp.PlateColor=PlateColor");
                paras.Add(new ObjectParameter("PlateColor", plateColor));
            }

            return sb.ToString();
        }


        private string ComposeQuerySql2(SearchPara searchPara, VehicleBrand brand, VehicleBrand[] models)
        {
            // paras.Add(new ObjectParameter("taskId", (int)task.TaskId));
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("SELECT * from AnalyseResult where TaskId={0}", searchPara.Task.TaskId);

            // 不限
            //有牌
            //无牌
            //未识别
            //图片错误
            int resultType = searchPara.ResultType;
            //if (resultType == 2)
            //{
            //    sb.AppendFormat(" AND (ErrorCode=0 And PlateNumber='11111111')");
            //}
            if (resultType == 3)
            {
                sb.AppendFormat(" AND ErrorCode=-2");
            }
            else if (resultType == 4)
            {
                sb.AppendFormat(" AND (ErrorCode=-3 Or ErrorCode=-4)");
            }
            else
            {
                if (resultType == 1)
                {
                    sb.AppendFormat(" AND ErrorCode=0  And PlateNumber!='11111111'");
                }
                else if (resultType == 2)
                {
                    sb.AppendFormat(" AND (ErrorCode=0 And PlateNumber='11111111')");
                }

                if (!string.IsNullOrEmpty(searchPara.PlateNumber))
                {
                    sb.AppendFormat(" AND PlateNumber LIKE '%{0}%'", searchPara.PlateNumber);
                }

                if (brand != null)
                {
                    if (searchPara.SelectAllVehicleModels)
                    {
                        sb.AppendFormat(" AND (Manufacturer={0} or Manufacturer in (SELECT Id from VehicleBrand WHERE ParentId={0}))", brand.Id);
                    }
                    else
                    {
                        if (models != null && models.Length > 0)
                        {
                            StringBuilder sbTmp = new StringBuilder();
                            foreach (VehicleBrand b in models)
                            {
                                sbTmp.AppendFormat("{0},", b.Id);
                            }
                            string ids = sbTmp.ToString().Trim(new char[] { ',' });
                            sb.AppendFormat(" AND Manufacturer in ({0})", ids);
                        }
                    }
                }

                if (searchPara.VehicleDetailType.ID != -1)
                {
                    sb.AppendFormat(" AND DetailVehicleType={0}", (int)searchPara.VehicleDetailType.ID);
                }

                int vehicleColor = Array.IndexOf(Constant.COLORNAMES_VEHICLEBODY, searchPara.VehicleColor);
                int plateColor = Array.IndexOf(Constant.COLORNAMES_VEHICLEPLATE, searchPara.PlateColor);
                vehicleColor = Math.Max(vehicleColor, 0);
                plateColor = Math.Max(plateColor, 0);

                if (vehicleColor != 0)
                {
                    sb.AppendFormat(" AND VehicleColor={0}", vehicleColor);
                    // paras.Add(new ObjectParameter("VehicleColor", vehicleColor));
                }

                if (plateColor != 0)
                {
                    sb.AppendFormat(" AND PlateColor='{0}'", plateColor);
                }

                int driverBelt = searchPara.DriverBelt - 1;
                int coDriverBelt = searchPara.CoDriverBelt - 1;
                int driverPhoneCall = searchPara.DriverPhoneCall - 1;
                int driverShielding = searchPara.DriverShielding - 1;
                int coDriverShielding = searchPara.CoDriverShielding - 1;

                if (driverBelt > -1 || driverPhoneCall > -1 || driverShielding > -1 || 
                    coDriverBelt > -1 || coDriverShielding > -1)
                {
                    ImageAnalyseEntities entities;
                    if (LocknGetDBContext(m_SyncObj, "ComposeQuerySql2", out entities))
                    {
                        try
                        {
                            string driverBehaviorIds = GetBehaviorIds(driverBelt, driverPhoneCall, driverShielding, entities);
                            string coDriverHaviorIds = GetBehaviorIds(coDriverBelt, -1, coDriverShielding, entities);

                            if (string.IsNullOrEmpty(coDriverHaviorIds))
                            {
                                sb.AppendFormat(" AND DriverIllegalBehavior in ({0})", driverBehaviorIds);
                            }
                            else if (string.IsNullOrEmpty(driverBehaviorIds))
                            {
                                sb.AppendFormat(" AND CoDriverIllegalBehavior in ({0})", coDriverHaviorIds);
                            }
                            else
                            {
                                sb.AppendFormat(" AND DriverIllegalBehavior in ({0}) AND CoDriverIllegalBehavior in ({1})",
                                    driverBehaviorIds, coDriverHaviorIds);
                            }
                        }
                        finally
                        {
                            UnlocknDisposeDBContext(m_SyncObj, "ComposeQuerySql2", entities);
                        }
                    }
                }
            }
            return sb.ToString();
        }
        
        private string ComposeQuerySql3(uint taskId)
        {
            // paras.Add(new ObjectParameter("taskId", (int)task.TaskId));
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("SELECT * from AnalyseResult where TaskId={0}", taskId);

            return sb.ToString();
        }

        private string GetBehaviorIds(int driverBelt, int driverPhoneCall, int driverShielding, ImageAnalyseEntities m_Entities)
        {
            string ids = string.Empty;

            if (driverBelt == -1 && driverPhoneCall == -1 && driverShielding == -1)
            {
                return ids;
            }
            string key = string.Format("{0}#{1}#{2}", driverBelt, driverShielding, driverPhoneCall);
            if(m_DTBebaviorComposeText2Ids.ContainsKey(key))
            {
                ids = m_DTBebaviorComposeText2Ids[key];
                return ids;
            }

            IQueryable<IllegalBehavior> result = null;

            if (driverBelt != -1 && driverPhoneCall != -1 && driverShielding != -1)
            {
                result = m_Entities.IllegalBehaviors.Where(b =>
                    b.PhoneCalling == driverPhoneCall &&
                    b.NotWearSafeBelt == driverBelt &&
                    b.SunShielding == driverShielding);
            }
            else if (driverBelt != -1 && driverPhoneCall != -1)
            {
                result = m_Entities.IllegalBehaviors.Where(b =>
                    b.NotWearSafeBelt == driverBelt &&
                    b.PhoneCalling == driverPhoneCall);
            }
            else if (driverPhoneCall != -1 && driverShielding != -1)
            {
                result = m_Entities.IllegalBehaviors.Where(b =>
                    b.PhoneCalling == driverPhoneCall &&
                    b.SunShielding == driverShielding);
            }
            else if (driverBelt != -1 && driverShielding != -1)
            {
                result = m_Entities.IllegalBehaviors.Where(b =>
                    b.NotWearSafeBelt == driverBelt &&
                    b.SunShielding == driverShielding);
            }
            else if (driverBelt != -1)
            {
                result = m_Entities.IllegalBehaviors.Where(b => b.NotWearSafeBelt == driverBelt);
            }
            else if (driverPhoneCall != -1)
            {
                result = m_Entities.IllegalBehaviors.Where(b => b.PhoneCalling == driverPhoneCall);
            }
            else if (driverShielding != -1)
            {
                result = m_Entities.IllegalBehaviors.Where(b => b.SunShielding == driverShielding);
            }
            else
            {
                Debug.Assert(false);
            }

            var items = result.ToList();
            StringBuilder sb = new StringBuilder();
            foreach (IllegalBehavior b in items)
            {
                sb.AppendFormat("{0},", b.Id);
            }
            ids = sb.ToString().Trim(new char[] { ',' });

            m_DTBebaviorComposeText2Ids.Add(key, ids);
            return ids;
        }

        private string GetBehaviorIds(int driverBelt, int phoneCall, ImageAnalyseEntities m_Entities)
        {
            string ids = string.Empty;

            if (driverBelt != -1 || phoneCall != -1)
            {
                IQueryable<IllegalBehavior> result = null;
                if (driverBelt == -1)
                {
                    result = m_Entities.IllegalBehaviors.Where(b => b.PhoneCalling == phoneCall);
                }
                else if (phoneCall == -1)
                {
                    result = m_Entities.IllegalBehaviors.Where(b => b.NotWearSafeBelt == driverBelt);
                }
                else
                {
                    result = m_Entities.IllegalBehaviors.Where(b => b.NotWearSafeBelt == driverBelt && b.PhoneCalling == phoneCall);
                }
                var items = result.ToList();
                StringBuilder sb = new StringBuilder();
                foreach (IllegalBehavior b in items)
                {
                    sb.AppendFormat("{0},", b.Id);
                }
                ids = sb.ToString().Trim(new char[] { ',' });
            }
           
            return ids;
        }

        private string GetBehaviorIds(int driverBelt, ImageAnalyseEntities m_Entities)
        {
            string ids = string.Empty;

            if (driverBelt != -1)
            {
                var result = m_Entities.IllegalBehaviors.Where(b => b.NotWearSafeBelt == driverBelt);
                var items = result.ToList();
                StringBuilder sb = new StringBuilder();
                foreach (IllegalBehavior b in items)
                {
                    sb.AppendFormat("{0},", b.Id);
                }
                ids = sb.ToString().Trim(new char[] { ',' });
            }

            return ids;
        }

        internal void AddAnalyseResults(int taskId, List<AnalyseRecord> records)
        {
            if (records != null && records.Count > 0)
            {
                ImageAnalyseEntities entities;
                if (LocknGetDBContext(m_SyncObj, "AddAnalyseResults", out entities))
                {
                    try
                    {
                        foreach (AnalyseRecord record in records)
                        {
                            AddAnalyseResult(taskId, record, entities);
                        }
                        CommitChanges(entities);
                    }
                    catch (Exception ex)
                    {
                        MyLog4Net.Container.Instance.Log.Error("AddRecord error", ex);
                        Debug.Assert(false);
                    }
                    finally
                    {
                        UnlocknDisposeDBContext(m_SyncObj, "AddAnalyseResults", entities);
                    }
                }
            }
        }

        private void AddAnalyseResult(int taskId, AnalyseRecord record, ImageAnalyseEntities entities)
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("Entering AddAnalyseResult {0} ...", record.PicId);

            Task task = GetTask(taskId, entities);
            byte bVal;
            int nVal;

            AnalyseResult result = new AnalyseResult()
            {
                CameraId = task.CameraId.HasValue ? task.CameraId.Value : 0,
                DetailVehicleType = byte.TryParse(record.DetailVehicleType, out bVal) ? bVal : (byte)0,
                FileName = record.PicPath,
                Manufacturer = int.TryParse(record.Manufacturer, out nVal) ? nVal : -1,
                ManufactureReliability = (byte)record.ManufacturerReliability,
                PlateColor = byte.TryParse(record.PlateColor, out bVal) ? bVal : (byte)0,
                PlateNumber = record.PlateNumber,
                PlateReliability = (byte)record.PlateNumberReliability,
                VehicleRegion = string.Format("{0},{1},{2},{3}", record.VehicleRegion.X, record.VehicleRegion.Y, record.VehicleRegion.Width, record.VehicleRegion.Height),
                PlateRegion = string.Format("{0},{1},{2},{3}", record.PlateRegion.X, record.PlateRegion.Y, record.PlateRegion.Width, record.PlateRegion.Height),
                DriverRegion = string.Format("{0},{1},{2},{3}", record.DriverRegion.X, record.DriverRegion.Y, record.DriverRegion.Width, record.DriverRegion.Height),
                CoDriverRegion = string.Format("{0},{1},{2},{3}", record.CoDriverRegion.X, record.CoDriverRegion.Y, record.CoDriverRegion.Width, record.CoDriverRegion.Height),
                PlateType = byte.TryParse(record.PlateType, out bVal) ? bVal : (byte)0,
                // Task = task,
                TaskId = task.Id,
                VehicleColor = byte.TryParse(record.VehicleColor, out bVal) ? bVal : (byte)0,
                VehicleType = byte.TryParse(record.VehicleType, out bVal) ? bVal : (byte)0,
                ErrorCode = (Int16)record.ErrorCode
            };

            //// 20150924， 按李帅要求
            //// 去掉银色（2）， 褐色改为棕色
            //if (result.VehicleColor == 2)
            //{
            //    result.VehicleColor = 10;
            //}
            //else if (result.VehicleColor > 2)
            //{
            //    result.VehicleColor--;
            //}

            MyLog4Net.Container.Instance.Log.DebugFormat("##DetailVehicleType:{0}", record.DetailVehicleType);
            if (result.ErrorCode == 0)
            {
                string behaviorKey = string.Format("{0}#{1}#{2}", record.DriverWearingSafeBelt.ID, record.DriverSunlightShield.ID, record.DriverPhoneCalling.ID);
                if (m_DTBehaviorComposeText2Id.ContainsKey(behaviorKey))
                {
                    result.DriverIllegalBehavior = m_DTBehaviorComposeText2Id[behaviorKey];
                }
                else
                {
                    // Debug.Assert(false);
                    result.DriverIllegalBehavior = m_DTBehaviorComposeText2Id["0#0#0"];
                }

                behaviorKey = string.Format("{0}#{1}#{2}", record.CoDriverWearingSafeBelt.ID, record.CoDriverSunlightShield.ID, record.CoDriverPhoneCalling.ID);
                if (m_DTBehaviorComposeText2Id.ContainsKey(behaviorKey))
                {
                    result.CoDriverIllegalBehavior = m_DTBehaviorComposeText2Id[behaviorKey];
                }
                else
                {
                    // Debug.Assert(false);
                    result.CoDriverIllegalBehavior = m_DTBehaviorComposeText2Id["0#0#0"];
                }
            }
            else
            {
                result.DriverIllegalBehavior = m_DTBehaviorComposeText2Id["0#0#0"];
                result.CoDriverIllegalBehavior = m_DTBehaviorComposeText2Id["0#0#0"];
            }

            try
            {
                if (result.Id != 0)
                {
                    MyLog4Net.Container.Instance.Log.DebugFormat("AddAnalyseResult: added result: {0}", result.Id);
                }
                else
                {
                    entities.AnalyseResults.AddObject(result);
                    MyLog4Net.Container.Instance.Log.DebugFormat("XX AddAnalyseResult: added result: {0}", result.Id);
                }
            }
            catch (InvalidOperationException ex)
            {
                AnalyseResult entity = entities.AnalyseResults.Single(r => r.Id == result.Id);
                // Do noting
                MyLog4Net.Container.Instance.Log.DebugFormat("AddAnalyseResult: add failed, Id: {0}", result.Id);
                Debug.Assert(string.Compare(entity.PlateNumber, result.PlateNumber, true) == 0);
            }
            MyLog4Net.Container.Instance.Log.DebugFormat("Leave AddAnalyseResult {0}", record.PicId);
        }

        /// <summary>
        /// 保存修改过后的分析结果
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="records"></param>
        internal void SaveAnalyseResults(List<AnalyseRecord> records)
        {
            if (records != null && records.Count > 0)
            {
                ImageAnalyseEntities entities;
                if (LocknGetDBContext(m_SyncObj, "AddAnalyseResults", out entities))
                {
                    try
                    {
                        foreach (AnalyseRecord record in records)
                        {
                            SaveAnalyseResult(record, entities);
                        }
                        // entities.AcceptAllChanges();
                        CommitChanges(entities);
                    }
                    finally
                    {
                        UnlocknDisposeDBContext(m_SyncObj, "AddAnalyseResults", entities);
                    }
                }
            }
        }
        
        private void SaveAnalyseResult(AnalyseRecord record, ImageAnalyseEntities entities)
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("Entering SaveAnalyseResult {0} ...", record.PicId);

            AnalyseResult result = GetAnalyseResult(record.Id, entities);
            byte bVal;
            int nVal;

            result.VehicleType = (byte)record.VehicleTypeInfo.ID;
            result.DetailVehicleType = (byte)record.DetailVehicleTypeInfo.ID;
            result.Manufacturer = record.BrandInfo.ID;
            result.PlateColor = (byte)record.PlateColorInfo.ID;
            result.PlateNumber = record.PlateNumber;

            result.PlateType = (byte)record.PlateTypeInfo.ID;
            result.VehicleColor = (byte)record.VehicleColorInfo.ID;
            result.ErrorCode = 0;
            //if (result.ErrorCode == 0)
            //{
            string behaviorKey = string.Format("{0}#{1}#{2}", record.DriverWearingSafeBelt.ID, record.DriverSunlightShield.ID, record.DriverPhoneCalling.ID);
            
            if (m_DTBehaviorComposeText2Id.ContainsKey(behaviorKey))
            {
                result.DriverIllegalBehavior = m_DTBehaviorComposeText2Id[behaviorKey];
            }
            else
            {
                // Debug.Assert(false);
                result.DriverIllegalBehavior = m_DTBehaviorComposeText2Id["0#0#0"];
            }

            behaviorKey = string.Format("{0}#{1}#{2}", record.CoDriverWearingSafeBelt.ID, record.CoDriverSunlightShield.ID, record.CoDriverPhoneCalling.ID);
            if (m_DTBehaviorComposeText2Id.ContainsKey(behaviorKey))
            {
                result.CoDriverIllegalBehavior = m_DTBehaviorComposeText2Id[behaviorKey];
            }
            else
            {
                // Debug.Assert(false);
                result.CoDriverIllegalBehavior = m_DTBehaviorComposeText2Id["0#0#0"];
            }
            //}
            //else
            //{
            //    result.DriverIllegalBehavior = m_DTBehaviorComposeText2Id["0#0#0"];
            //    result.CoDriverIllegalBehavior = m_DTBehaviorComposeText2Id["0#0#0"];
            //}

            try
            {
                // entities.AnalyseResults.(result);
                MyLog4Net.Container.Instance.Log.DebugFormat("XX AddAnalyseResult: added result: {0}", result.Id);
            }
            catch (InvalidOperationException ex)
            {
                AnalyseResult entity = entities.AnalyseResults.Single(r => r.Id == result.Id);
                // Do noting
                MyLog4Net.Container.Instance.Log.DebugFormat("AddAnalyseResult: add failed, Id: {0}", result.Id);
                Debug.Assert(string.Compare(entity.PlateNumber, result.PlateNumber, true) == 0);
            }
            MyLog4Net.Container.Instance.Log.DebugFormat("Leave AddAnalyseResult {0}", record.PicId);
        }


        public int GetQueryCount(SearchPara searchPara, VehicleBrand brand, VehicleBrand[] models, out string sql)
        {
            MyLog4Net.Container.Instance.Log.Debug("Entering GetQueryCount ...");

            int total = 0;

            // sql = ComposeQuerySql(paraList, task, plateNumber, vehicleDetailType.Name, brand, resultType, vehicleColor, plateColor);        

            sql = ComposeQuerySql2(searchPara, brand, models);
            string sqlCount = sql.Replace("SELECT * ", "SELECT count(0) ");

            ImageAnalyseEntities entities;
            if (LocknGetDBContext(m_SyncObj, "GetQueryCount", out entities))
            {
                try
                {
                    var queryCount = entities.ExecuteStoreQuery<int>(sqlCount, null);
                    total = queryCount.SingleOrDefault();
                }
                finally
                {
                    UnlocknDisposeDBContext(m_SyncObj, "GetQueryCount", entities);
                }
            }

            MyLog4Net.Container.Instance.Log.Debug("Leave GetQueryCount");

            return total;
        }
        
        public int GetCompareQueryCount(SearchPara searchPara, VehicleBrand brand, VehicleBrand[] models, out string sql)
        {
            MyLog4Net.Container.Instance.Log.Debug("Entering GetCompareQueryCount ...");

            int total = 0;

            // sql = ComposeQuerySql(paraList, task, plateNumber, vehicleDetailType.Name, brand, resultType, vehicleColor, plateColor);        

            sql = ComposeQuerySql3(searchPara.Task.TaskId);
            string sqlCount = sql.Replace("SELECT * ", "SELECT count(0) ");

            ImageAnalyseEntities entities;
            if (LocknGetDBContext(m_SyncObj, "GetCompareQueryCount", out entities))
            {
                try
                {
                    var queryCount = entities.ExecuteStoreQuery<int>(sqlCount, null);
                    total = queryCount.SingleOrDefault();
                }
                finally
                {
                    UnlocknDisposeDBContext(m_SyncObj, "GetCompareQueryCount", entities);
                }
            }

            MyLog4Net.Container.Instance.Log.Debug("Leave GetCompareQueryCount");

            return total;
        }

        public List<AnalyseRecord> SwitchPage(string sql, PageInfo page)
        {
            MyLog4Net.Container.Instance.Log.Debug("Entering SwitchPage ...");

            // m_Entities.AnalyseResults.Include("VehicleBrand");
            List<AnalyseRecord> records = null;
            int skip = page.StartRecordIndex;
            int limit = page.CurrentPageCount;

            string temp = string.Format("{0} order by Id limit {1} offset {2}", sql, limit, skip);
            AnalyseResult[] results = null;
            ImageAnalyseEntities entities;
            if (LocknGetDBContext(m_SyncObj, "SwitchPage", out entities))
            {
                try
                {
                    ObjectResult<AnalyseResult> results2 = entities.ExecuteStoreQuery<AnalyseResult>(temp, null);

                    results = results2.ToArray();

                    if (results != null)
                    {
                        records = new List<AnalyseRecord>();
                        AnalyseRecord record;
                        foreach (AnalyseResult result in results)
                        {
                            record = Parse(result, entities);
                            records.Add(record);
                            entities.Detach(result);
                        }
                    }
                }
                finally
                {
                    UnlocknDisposeDBContext(m_SyncObj, "SwitchPage", entities);
                }
            }

            return records;
        }

        /// <summary>
        /// 用于在检索结果中导出全部记录，即确定查询条件 sql 的情况下， 获取符合条件的全部结果
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public List<AnalyseRecord> GetAllResults(string sql)
        {
            List<AnalyseRecord> records = null;

            string temp = string.Format("{0} order by Id", sql);
            AnalyseResult[] results = null;
            ImageAnalyseEntities entities;

            if (LocknGetDBContext(m_SyncObj, "GetAllResults", out entities))
            {
                try
                {
                    ObjectResult<AnalyseResult> results2 = entities.ExecuteStoreQuery<AnalyseResult>(temp, null);
                    results = results2.ToArray();

                    if (results != null)
                    {
                        records = new List<AnalyseRecord>();
                        AnalyseRecord record;
                        foreach (AnalyseResult result in results)
                        {
                            record = Parse(result, entities);
                            records.Add(record);
                            entities.Detach(result);
                        }
                    }
                }
                finally
                {
                    UnlocknDisposeDBContext(m_SyncObj, "GetAllResults", entities);
                }
            }
            return records;
        }
        
        public void DeleteAnalyseRecords(List<int> ids)
        {
            ImageAnalyseEntities entities;
            if (LocknGetDBContext(m_SyncObj, "DeleteAnalyseRecords", out entities))
            {
                try
                {
                    DeleteAnalyseRecords(ids, entities);
                }
                finally
                {
                    UnlocknDisposeDBContext(m_SyncObj, "DeleteAnalyseRecords", entities);
                }
            }
        }

        public void DeleteAnalyseRecords(List<int> analyseRecordIds, ImageAnalyseEntities m_Entities)
        {
            if (analyseRecordIds == null || analyseRecordIds.Count == 0)
            {
                return;
            }

            StringBuilder sb = new StringBuilder("'");
            foreach (int id in analyseRecordIds)
            {
                sb.AppendFormat("{0}','", id);
            }
            string ids = sb.ToString().Substring(0, sb.Length - 2);
            string sql = string.Format("DELETE FROM [AnalyseResult] WHERE Id in ({0})", ids);
            var query = m_Entities.ExecuteStoreCommand(sql, null);
        }

        public void DeleteAnalyseRecordsByTask(List<int> nIds, ImageAnalyseEntities m_Entities)
        {
            if (nIds == null || nIds.Count == 0)
            {
                return;
            }

            foreach (int id in nIds)
            {
                string sql = "DELETE FROM [AnalyseResult] WHERE TaskId=" + id;
                var query = m_Entities.ExecuteStoreCommand(sql, null);
            }
            CommitChanges(m_Entities);
        }

        public AnalyseResult GetAnalyseResult(int id)
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("Entering GetAnalyseResult {0} ...", id);

            AnalyseResult result = null;
            ImageAnalyseEntities entities;
            if (LocknGetDBContext(m_SyncObj, "GetAnalyseResult", out entities))
            {
                try
                {
                    result = GetAnalyseResult(id, entities);
                }
                finally
                {
                    UnlocknDisposeDBContext(m_SyncObj, "GetAnalyseResult", entities);
                }
            }

            return result;
        }

        public AnalyseResult GetAnalyseResult(int id, ImageAnalyseEntities entities)
        {
            return entities.AnalyseResults.Where(t => t.Id == id).SingleOrDefault();
        }

        #endregion

        #region Brand functions

        /// <summary>
        /// 获取全部父品牌
        /// </summary>
        /// <returns></returns>
        public List<VehicleBrand> GetAllBrands()
        {
            List<VehicleBrand> brands = null;

            ImageAnalyseEntities entities;
            if (LocknGetDBContext(m_SyncObj, "GetAllBrands", out entities))
            {
                try
                {
                    brands = entities.VehicleBrands.Where(b => !b.ParentId.HasValue).ToList();
                }
                finally
                {
                    UnlocknDisposeDBContext(m_SyncObj, "GetAllBrands", entities);
                }
            }

            return brands;
        }

        public List<ModelPropertyInfo> GetAllBrandModelInfos()
        {
            List<ModelPropertyInfo> brandInfos = null;
            List<VehicleBrand> brands = null;

            ImageAnalyseEntities entities;
            if (LocknGetDBContext(m_SyncObj, "GetAllBrands", out entities))
            {
                try
                {
                    brands = entities.VehicleBrands.Where(b => !b.ParentId.HasValue || b.ParentId.Value == 999).ToList();
                }
                finally
                {
                    UnlocknDisposeDBContext(m_SyncObj, "GetAllBrands", entities);
                }
                if(brands != null && brands.Count > 0)
                {
                    brandInfos = new List<ModelPropertyInfo>();
                    foreach(VehicleBrand brand in brands)
                    {
                        brandInfos.Add(new ModelPropertyInfo(){ID=(int)brand.Id, Name=brand.Name});
                    }
                }
            }

            return brandInfos;
        }

        public VehicleBrand GetBrand(int id)
        {
            VehicleBrand brand = null;
            ImageAnalyseEntities entities;
            if (LocknGetDBContext(m_SyncObj, "GetBrand", out entities))
            {
                try
                {
                    brand = GetBrand(id, entities);
                }
                finally
                {
                    UnlocknDisposeDBContext(m_SyncObj, "GetBrand", entities);
                }
            }

            return brand;
        }

        private VehicleBrand GetBrand(int id, ImageAnalyseEntities m_Entities)
        {
            VehicleBrand brand = m_Entities.VehicleBrands.Where(t => t.Id == id).SingleOrDefault();
            
            return brand;
        }

        public VehicleBrand[] GetChildBrands(int id)
        {
            VehicleBrand[] brands = null;
            ImageAnalyseEntities entities;
            if (LocknGetDBContext(m_SyncObj, "GetChildBrands", out entities))
            {
                try
                {
                    var result = entities.VehicleBrands.Where(t => t.ParentId == id);
                    if (result.Any())
                    {
                        brands = result.ToArray();
                        Array.Sort(brands, new VehicleBrandComparer());
                    }
                }
                finally
                {
                    UnlocknDisposeDBContext(m_SyncObj, "GetChildBrands", entities);
                }
            }

            return brands;
        }

        #endregion

        #region Vehicle & plate color functions

        public PlateColor GetPlateColor(int id)
        {
            PlateColor plateColor = null;
            ImageAnalyseEntities entities;
            if (LocknGetDBContext(m_SyncObj, "GetPlateColor", out entities))
            {
                try
                {
                    plateColor = GetPlateColor(id, entities);
                }
                finally
                {
                    UnlocknDisposeDBContext(m_SyncObj, "GetPlateColor", entities);
                }
            }

            return plateColor;
        }

        private PlateColor GetPlateColor(int id, ImageAnalyseEntities m_Entities)
        {
            PlateColor plateColor = m_Entities.PlateColors.Where(t => t.Id == id).SingleOrDefault();
            return plateColor;
        }

        public VehicleColor GetVehicleColor(int id)
        {
            VehicleColor vehicleColor = null;
            ImageAnalyseEntities entities;
            if (LocknGetDBContext(m_SyncObj, "GetVehicleColor", out entities))
            {
                try
                {
                    vehicleColor = GetVehicleColor(id, entities);
                }
                finally
                {
                    UnlocknDisposeDBContext(m_SyncObj, "GetVehicleColor", entities);
                }
            }

            return vehicleColor;
        }

        public VehicleColor GetVehicleColor(int id, ImageAnalyseEntities m_Entities)
        {
            VehicleColor vehicleColor = m_Entities.VehicleColors.Where(t => t.Id == id).SingleOrDefault();
            return vehicleColor;
        }

        #endregion

        #region Vehicle type & Detail type functions
        
        public VehicleType GetVehicleType(int id)
        {
            VehicleType vehicleType = null;
            ImageAnalyseEntities entities;

            if (LocknGetDBContext(m_SyncObj, "GetVehicleType", out entities))
            {
                try
                {
                    vehicleType = GetVehicleType(id, entities);
                }
                finally
                {
                    UnlocknDisposeDBContext(m_SyncObj, "GetVehicleType", entities);
                }
            }
          
            return vehicleType;
        }

        private VehicleType GetVehicleType(int id, ImageAnalyseEntities m_Entities)
        {
            VehicleType vehicleType = null;

            vehicleType = m_Entities.VehicleTypes.Where(t => t.Id == id).SingleOrDefault();

            return vehicleType;
        }

        public VehicleDetailType GetVehicleDetailType(int id)
        {
            VehicleDetailType detailVehicleType = null;
            ImageAnalyseEntities entities;

            if (LocknGetDBContext(m_SyncObj, "GetVehicleDetailType", out entities))
            {
                try
                {
                    detailVehicleType = GetVehicleDetailType(id, entities);
                }
                finally
                {
                    UnlocknDisposeDBContext(m_SyncObj, "GetVehicleDetailType", entities);
                }
            }

            return detailVehicleType;
        }

        private VehicleDetailType GetVehicleDetailType(int id, ImageAnalyseEntities entities)
        {
            VehicleDetailType detailVehicleType = null;

            detailVehicleType = entities.VehicleDetailTypes.Where(t => t.Id == id).SingleOrDefault();

            return detailVehicleType;
        }

        #endregion

        #region Plate structure & Brand functions

        public PlateStructure GetPlateStructure(int id)
        {
            PlateStructure structure = null;
            ImageAnalyseEntities entities;
            if (LocknGetDBContext(m_SyncObj, "GetPlateStructure", out entities))
            {
                try
                {
                    structure = GetPlateStructure(id, entities);
                }
                finally
                {
                    UnlocknDisposeDBContext(m_SyncObj, "GetPlateStructure", entities);
                }
            }

            return structure;
        }

        private PlateStructure GetPlateStructure(int id, ImageAnalyseEntities m_Entities)
        {
            PlateStructure structure = m_Entities.PlateStructures.Where(t => t.Id == id).SingleOrDefault();

            return structure;
        }

        public VehicleBrand GetBrand(string name)
        {
            VehicleBrand brand = null;
            ImageAnalyseEntities entities;
            if (LocknGetDBContext(m_SyncObj, "GetBrand", out entities))
            {
                try
                {
                    brand = GetBrand(name, entities);
                }
                finally
                {
                    UnlocknDisposeDBContext(m_SyncObj, "GetBrand", entities);
                }
            }

            return brand;
        }

        public VehicleBrand GetBrand(string name, ImageAnalyseEntities entities)
        {
            VehicleBrand brand = null;
          
            IQueryable<VehicleBrand> query = entities.VehicleBrands.Where(t => t.Name == name);
            if (query.Any())
            {
                List<VehicleBrand> list = query.ToList();
                brand = list[0];
            }
            
            return brand;
        }

        internal void AddVehicleBrand(string name, int id, int parentId)
        {
            MyLog4Net.Container.Instance.Log.DebugFormat("Entering AddVehicleBrand {0} ...", name);

            VehicleBrand brand = GetBrand(id);
            if (brand == null)
            {
                brand = new VehicleBrand() { Id = id, Name = name };

                VehicleBrand parentBrand = GetBrand(parentId);
                if (parentBrand != null)
                {
                    brand.ParentId = parentId;
                }
                ImageAnalyseEntities entities;
                if (LocknGetDBContext(m_SyncObj, "AddVehicleBrand", out entities))
                {
                    try
                    {
                        entities.AddToVehicleBrands(brand);
                        CommitChanges(entities);
                    }
                    finally
                    {
                        UnlocknDisposeDBContext(m_SyncObj, "AddVehicleBrand", entities);
                    }
                }
            }

            MyLog4Net.Container.Instance.Log.DebugFormat("Leave AddVehicleBrand {0}", name);
        }

        public void AddVehicleBrand(string parentName, int parentId, string name, int id)
        {
            AddVehicleBrand(parentName, parentId, -1);
            AddVehicleBrand(name, id, parentId);
        }

        public void UpdateVehicleBrand(string parentName, int parentId, string name, int id)
        {
            VehicleBrand brand = GetBrand(parentName);
            VehicleBrand childBrand = GetBrand(id);
            if (brand != null && childBrand != null)
            {
                childBrand.ParentId = brand.Id;
            }
        }

        #endregion

        internal void CommitChanges(ImageAnalyseEntities m_Entities)
        {
            MyLog4Net.Container.Instance.Log.Debug("Entering CommitChanges ...");
            
            m_Entities.SaveChanges();// SaveOptions.AcceptAllChangesAfterSave);

            MyLog4Net.Container.Instance.Log.Debug("Leave CommitChanges");
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

    internal class VehicleDetailTypeComparer : IComparer<VehicleDetailType>
    {
        public int Compare(object x, object y)
        {
            int nRet = 0;
            VehicleDetailType b1 = x as VehicleDetailType;
            VehicleDetailType b2 = y as VehicleDetailType;

            if (b1 != null && b2 != null)
            {
                nRet = b1.DisplayIndex - b2.DisplayIndex;
            }
            return nRet;
        }

        public int Compare(VehicleDetailType x, VehicleDetailType y)
        {
            return x.DisplayIndex - y.DisplayIndex;
        }
    }

}
