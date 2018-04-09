using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WinFormAppUtil;
using System.ComponentModel;
using System.Data;
using Bocom.ImageAnalysisClient.DataModel;
using System.IO;
using System.Drawing;
using Bocom.ImageAnalysisClient.App.Views;
using System.Windows.Forms;
using WinFormAppUtil.Controls;
using System.Data.Objects;
using DevExpress.XtraGrid;
using Bocom.ImageAnalysisClient.App.Framework;
using Microsoft.Practices.Prism.Events;
using Bocom.ImageAnalysisClient.Service.DAO;

namespace Bocom.ImageAnalysisClient.App.ViewModels
{
    internal class SearchAnalyseResultViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public event EventHandler TasksChanged;

        #region Fields
        
        private DataTable m_DTAnalyseResults;

        private DataTable m_DTAnalyseResultsAll;

        private AnalyseTask[] m_Tasks;

        private string m_PlateNumber;

        private VehicleBrandInfo m_Brand;

        private int m_NVehicleDetailType;

        private int m_NVehiclePlateType;

        private int m_ResultType;

        private ColorName m_VehicleColor;

        private ColorName m_PlateColor;

        private AnalyseRecord m_SelectedAnalyseRecord;

        private List<AnalyseRecord> m_Records;

        private string m_SQLQuery;

        private EditImageForm m_EditImageForm;

        private PageInfo m_ResultPageInfo;

        private bool m_HasResult = false;

        private FileAccessBase m_FileAccess;

        #endregion

        #region Properties
        
        public int NVehicleDetailType
        {
            get
            {
                return m_NVehicleDetailType;
            }
            set
            {
                if (m_NVehicleDetailType != value)
                {
                    m_NVehicleDetailType = value;
                    // m_SearchPara[SDKConstant.dwVehicleDetailType] = value;
                    // RaisePropertyChangedEvent("NVehicleDetailType");
                }
            }
        }

        public int NVehiclePlateType
        {
            get
            {
                return m_NVehiclePlateType;
            }
            set
            {
                if (m_NVehiclePlateType != value)
                {
                    m_NVehiclePlateType = value;
                    //m_SearchPara[SDKConstant.dwVehiclePlateStruct] = value;
                    //RaisePropertyChangedEvent("NVehiclePlateType");
                }
            }
        }

        public string PlateNumber
        {
            get { return m_PlateNumber; }
            set
            {
                m_PlateNumber = value;
                // m_SearchPara[SDKConstant.szVehiclePlateName] = value;
            }
        }

        public ColorName PlateColor
        {
            get { return m_PlateColor; }
            set
            {
                m_PlateColor = value;
                // m_SearchPara[SDKConstant.dwVehiclePlateColor] = Framework.Container.Instance.ColorService.GetPlateColorIndex(value);

            }
        }

        public ColorName VehicleColor
        {
            get { return m_VehicleColor; }
            set
            {
                m_VehicleColor = value;
                // m_SearchPara[SDKConstant.dwVehicleColor] = Framework.Container.Instance.ColorService.GetVehicleColorIndex(value);
            }
        }

        public VehicleBrandInfo Brand
        {
            get { return m_Brand; }
            set
            {
                m_Brand = value;
                // m_SearchPara[SDKConstant.dwVehicleLogo] = value;
            }
        }
        
        public int ResultType
        {
            get { return m_ResultType; }
            set { m_ResultType = value; }
        }
        
        public uint TaskId { get; set; }

        public AnalyseTask Task { get;set; }

        public AnalyseTask[] Tasks
        {
            get { return m_Tasks; }
            set { m_Tasks = value; }
        }
        
        public DataTable DTAnalyseResults
        {
            get { return m_DTAnalyseResults; }
            set { m_DTAnalyseResults = value; }
        }

        public AnalyseRecord SelectedAnalyseRecord
        {
            get
            {
                return m_SelectedAnalyseRecord;
            }
            set
            {
                m_SelectedAnalyseRecord = value;
            }
        }
        
        public PageInfo ResultPageInfo
        {
            get { return m_ResultPageInfo; }
            
        }

        public bool HasResult
        {
            get { return m_HasResult; }
            set
            {
                if (m_HasResult != value)
                {
                    m_HasResult = value;
                    RaisePropertyChangedEvent("HasResult");
                }
            }
        }

        public string FileName
        { get;set; }

        #endregion

        #region Private helper functions
        
        private void InitTable()
        {
            m_DTAnalyseResults = new DataTable("AnalyseRecords");
            DataColumn columnId = m_DTAnalyseResults.Columns.Add("Id", typeof(uint));
            m_DTAnalyseResults.PrimaryKey = new DataColumn[] { columnId };

            m_DTAnalyseResults.Columns.Add("FileName");
            m_DTAnalyseResults.Columns.Add("FullName");
            m_DTAnalyseResults.Columns.Add("PlateNumber");
            m_DTAnalyseResults.Columns.Add("PlateNumberFromOther");
            m_DTAnalyseResults.Columns.Add("VehicleType");
            m_DTAnalyseResults.Columns.Add("DetailVehicleType");
            m_DTAnalyseResults.Columns.Add("Manufacturer");
            m_DTAnalyseResults.Columns.Add("Brand");
            m_DTAnalyseResults.Columns.Add("Model");
            m_DTAnalyseResults.Columns.Add("VehicleColor");
            m_DTAnalyseResults.Columns.Add("PlateType");
            m_DTAnalyseResults.Columns.Add("PlateColor");
            
            m_DTAnalyseResults.Columns.Add("AnalyseRecord", typeof(AnalyseRecord));
        }

        private void AddResultRow(DataTable dt, AnalyseRecord record)
        {
            dt.Rows.Add(new object[]{
                record.Id,
                m_FileAccess.GetFileName(record.PicId),
                record.PicId,
                record.PlateNumber,
                GetPlateNumberFromOther(m_FileAccess.GetFileName(record.PicId)),
                record.VehicleTypeInfo,
                record.DetailVehicleTypeInfo,
                record.Manufacturer,
                record.ParentBrandInfo,
                record.BrandInfo,
                record.VehicleColorInfo,
                record.PlateTypeInfo,
                record.PlateColorInfo,
                record
            });
        }


        private string GetPlateNumberFromOther(string other)
        {
            return "沪a11111";
        }
        #endregion

        #region Public helper functions
        
        internal SearchAnalyseResultViewModel()
        {
            InitTable();
            List<AnalyseTask> tasks = Framework.Container.Instance.TaskManager.GetAllTasks();
            if (tasks != null)
            {
                m_Tasks = tasks.ToArray();
            }
            else
            {
                m_Tasks = new AnalyseTask[0];
            }

            Framework.Container.Instance.EvtAggregator.GetEvent<TaskAddedEvent>().Subscribe(OnTaskChanged, ThreadOption.WinFormUIThread);
            Framework.Container.Instance.EvtAggregator.GetEvent<TaskRemovedEvent>().Subscribe(OnTaskChanged, ThreadOption.WinFormUIThread);
            Framework.Container.Instance.EvtAggregator.GetEvent<ViewResultsEvent>().Subscribe(OnViewResults);
            Framework.Container.Instance.EvtAggregator.GetEvent<ViewFailedResultsEvent>().Subscribe(OnViewFailedResults);
        }
        
        public void TurnPrePage()
        {
            m_DTAnalyseResults.Rows.Clear();
            HasResult = false;
            m_ResultPageInfo.TurnPrePage();
        }

        public void TurnNextPage()
        {
            m_DTAnalyseResults.Rows.Clear();
            HasResult = false;
            m_ResultPageInfo.TurnNextPage();
        }

        internal void ShowDetails()
        {
            int index = 0;
            AnalyseRecord record = SelectedAnalyseRecord;
            if (record != null)
            {
                index = m_Records.IndexOf(record);
            }

            PageInfo pageInfo = new PageInfo(1, m_Records.Count, index);

            //DetailViewPageInfo.Index = index;

            //// 用using 在Clear的时候m_EditImageForm 为null
            m_EditImageForm = new EditImageForm(m_FileAccess, m_Records, index);
            m_EditImageForm.FormClosed += new FormClosedEventHandler(EditImageForm_FormClosed);
            m_EditImageForm.ShowDialog();
        }

        public void Search()
        {
            m_DTAnalyseResults.Rows.Clear();
            HasResult = false;

            if (Task == null)
            {
                FileName = string.Empty;
                RaisePropertyChangedEvent("FileName");
            }
            else
            {
                //m_FileAccess = FileAccessFactory.GetFileAccess(Task.PictureSource);

                ModelPropertyInfo vehicleDetailType = DataModel.Constant.SDT_PropertyInfo_VehicleDetailType[0];

                if(m_NVehicleDetailType > -1)
                {
                    vehicleDetailType = DataModel.Constant.SDT_PropertyInfo_VehicleDetailType[m_NVehicleDetailType];
                }

                int vehicleColor = Array.IndexOf(Constant.COLORNAMES_VEHICLEBODY, m_VehicleColor);
                int plateColor = Array.IndexOf(Constant.COLORNAMES_VEHICLEPLATE, m_PlateColor);
                vehicleColor = Math.Max(vehicleColor, 0);
                plateColor = Math.Max(plateColor, 0);

                //int count = Framework.Container.Instance.TaskManager.GetQueryCount(
                //    Task, m_PlateNumber, vehicleDetailType, m_Brand, m_ResultType,
                //    vehicleColor, plateColor, out m_SQLQuery);

                //m_ResultPageInfo = new PageInfo(100, count, 0);
                //m_ResultPageInfo.SelectedPageNumberChanged += new EventHandler(ResultPageInfo_SelectedPageNumberChanged);
                //m_Records = Framework.Container.Instance.TaskManager.SwitchPage(m_SQLQuery, m_ResultPageInfo);

                //FileName = string.Format("{0}: ", Task.Name);
                //RaisePropertyChangedEvent("FileName");

                //if (m_Records != null && m_Records.Count > 0)
                //{
                //    foreach (AnalyseRecord record in m_Records)
                //    {
                //        AddResultRow(m_DTAnalyseResults, record);
                //    }
                //    HasResult = true;
                //}
                //else
                //{
                //    Framework.Container.Instance.InteractionService.ShowMessageBox("没有检索到结果");
                //}
            }
        }

        public void ExportCurrentPage()
        {
            
        }

        public void ExportAll(GridControl gridControl, string fileName)
        {
            List<AnalyseRecord> records =  Framework.Container.Instance.TaskManager.GetAllResults(Task, m_SQLQuery);

            if (records != null && records.Count > 0)
            {
                if(m_DTAnalyseResultsAll == null)
                {
                    m_DTAnalyseResultsAll = m_DTAnalyseResults.Clone();
                }
                
                foreach (AnalyseRecord record in records)
                {
                    AddResultRow(m_DTAnalyseResultsAll, record);
                }

                gridControl.DataSource = m_DTAnalyseResultsAll;
                gridControl.ExportToCsv(fileName);
                m_DTAnalyseResultsAll.Rows.Clear();
            }
        }

        public Image GetImage(AnalyseRecord record)
        {
            Image imgRet = null;

            if (Task != null && record != null)
            {
                if (record.Image != null)
                {
                    // 不要与图片控件用同一个图片对象
                    // 图片控件上的图片可以自己回收
                    imgRet = record.Image.Clone() as Image;
                }
                else
                {
                    // string fileName = m_FileAccess.GetFileName(record.PicId);
                    record.Image = m_FileAccess.GetImage(record.PicId);
                    if (record.Image != null)
                    {
                        imgRet = record.Image.Clone() as Image;
                        Framework.Container.Instance.CacheManager.Register(record);
                    }
                }
            }

            return imgRet;
        }

        #endregion

        #region Event handlers

        private void OnTaskChanged(AnalyseTask task)
        {
            List<AnalyseTask> tasks = Framework.Container.Instance.TaskManager.GetAllTasks();
            if (tasks != null)
            {
                m_Tasks = tasks.ToArray();
            }
            else
            {
                m_Tasks = new AnalyseTask[0];
            }

            if (TasksChanged != null)
            {
                TasksChanged(this, EventArgs.Empty);
            }
        }



        void EditImageForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_EditImageForm.Dispose();
            m_EditImageForm = null;
        }

        private void OnViewResults(AnalyseTask task)
        {
            Task = task;
            RaisePropertyChangedEvent("Task");
            ResultType = 0;
            RaisePropertyChangedEvent("ResultType");
        }
        
        private void OnViewFailedResults(AnalyseTask task)
        {
            Task = task;
            RaisePropertyChangedEvent("Task");
            ResultType = 2;
            RaisePropertyChangedEvent("ResultType");
        }

        #endregion

    }

}
