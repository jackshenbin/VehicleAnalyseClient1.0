using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using com.VehicleAnalyse.DataModel;
using AppUtil;
using VehicleHelper.DataModel;

namespace com.VehicleAnalyse.Service
{
    public class AnalyseResultReviseFromTxtFile : IAnalyseResultRevise
    {
        #region Fields

        private string m_FileName;
        private Dictionary<string, Tuple<int, int, int>> m_DTResult2DriverBeltWear;

        private Dictionary<string, List<AnalyseRecord>> m_DTFile2Results;
        private List<AnalyseRecord> m_Records;

        private readonly char[] CHARS_SPLIT = new char[] { ',' };

        private List<AnalyseTask> m_Tasks;

        #endregion

        #region Properties
        
        public bool ReviseByFile { get; set; }

        #endregion

        #region Constructors
        
        public AnalyseResultReviseFromTxtFile(string fileName)
        {
            m_FileName = fileName;
            
            m_Tasks = new List<AnalyseTask>();
            m_DTFile2Results = new Dictionary<string, List<AnalyseRecord>>();
            m_Records = new List<AnalyseRecord>();
            RetrieveSettings();
        }

        #endregion

        #region Private helper functions
        
        private void RetrieveSettings()
        {
            m_DTResult2DriverBeltWear = new Dictionary<string, Tuple<int, int, int>>();
            if (File.Exists(m_FileName))
            {
                StreamReader sr = File.OpenText(m_FileName);
                string line = sr.ReadLine();

                string msg = string.Empty;
                List<string> files = new List<string>();
                string[] segs;
                string fileName;
                int driverSaftBeltWearing;
                int coDriverSaftBeltWearing;
                int driverPhoneCalling;
                AnalyseRecord record;
                List<AnalyseRecord> records;
                int i = 0;
                while (line != null)
                {
                    line = line.Trim();
                    if (!line.StartsWith("'") && !line.StartsWith("--"))
                    {
                        segs = line.Split(CHARS_SPLIT, StringSplitOptions.RemoveEmptyEntries);
                        if (segs != null && segs.Length == 11)
                        {
                            fileName = segs[10].ToLower().Trim();
                            if (!m_DTFile2Results.ContainsKey(fileName))
                            {
                                records = new List<AnalyseRecord>();
                                m_DTFile2Results.Add(fileName, records);
                            }
                            else
                            {
                                records = m_DTFile2Results[fileName];
                            }
                            record = new AnalyseRecord();
                            record.PlateNumber = segs[0].Trim();
                            record.VehicleType = segs[1].Trim();
                            record.DetailVehicleType = segs[2].Trim();
                            record.VehicleColor = segs[3].Trim();
                            record.ParentBrandInfo = new VehiclePropertyInfo() { ID = -1, Name = segs[4].Trim() };
                            record.BrandInfo = new VehiclePropertyInfo() { ID = -1, Name = segs[5].Trim() };
                            record.PlateColor = segs[6].Trim();
                            record.DriverWearingSafeBelt = new VehiclePropertyInfo { ID = -1, Name = segs[7].Trim() };
                            record.CoDriverWearingSafeBelt = new VehiclePropertyInfo { ID = -1, Name = segs[8].Trim() };
                            record.DriverPhoneCalling = new VehiclePropertyInfo { ID = -1, Name = segs[9].Trim() };
                            record.PicPath = fileName;
                            record.Id = (i++).ToString();
                            records.Add(record);
                            m_Records.Add(record);
                        }
                    }
                    line = sr.ReadLine();
                }
                sr.Close();
                sr.Dispose();
            }
        }

        #endregion

        #region Public helper functions
        
        public void Execute(DataModel.AnalyseRecord record, string fileName)
        {
            string key = fileName;
            if (!this.ReviseByFile)
            {
                key = record.PlateNumber;
            }

            if (record != null && record.ErrorCode == 0 && !string.IsNullOrEmpty(key))
            {
                string plateNumber = key.ToLower();
                if (m_DTResult2DriverBeltWear.ContainsKey(plateNumber))
                {
                    string msg = string.Format("车牌(文件) {0} 主副驾驶修正： 从 {1}, {2}, {3} 修正为 ", 
                        key, record.DriverWearingSafeBelt.ID, record.CoDriverWearingSafeBelt.ID, record.DriverPhoneCalling.ID);

                //    record.DriverWearingSafeBelt = Constant.UpdatenGetProperty(ref 
                //Constant.SDT_PropertyInfo_SafeBeltWear, m_DTResult2DriverBeltWear[plateNumber].Item1, "非法");

                //    record.CoDriverWearingSafeBelt = Constant.UpdatenGetProperty(ref 
                //Constant.SDT_PropertyInfo_SafeBeltWear, m_DTResult2DriverBeltWear[plateNumber].Item2, "非法");
                    
                //    record.DriverPhoneCalling = Constant.UpdatenGetProperty(ref 
                //Constant.SDT_PropertyInfo_PhoneCalling, m_DTResult2DriverBeltWear[plateNumber].Item3, "非法");

                    msg = string.Format("{0} {1}({2}) {3}({4}) {5}({6})", msg, record.DriverWearingSafeBelt.Name, record.DriverWearingSafeBelt.ID,
                        record.CoDriverWearingSafeBelt.Name, record.CoDriverWearingSafeBelt.ID,
                        record.DriverPhoneCalling.Name, record.DriverPhoneCalling.ID);

                    MyLog4Net.Container.Instance.Log.Info(msg);
                }
            }
        }
        
        public void RegisterTask(AnalyseTask task)
        {
            if (!m_Tasks.Contains(task))
            {
                m_Tasks.Add(task);
            }
        }

        public bool Contains(AnalyseTask task)
        {
            bool bRet = false;
            if (task != null)
            {
                bRet = m_Tasks.Contains(task);
            }
            return bRet;
        }

        public List<AnalyseRecord> GetAllResults(AnalyseTask task)
        {
            return m_Records;
        }

        #endregion
    }
}
