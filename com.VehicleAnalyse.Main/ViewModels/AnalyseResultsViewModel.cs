using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Events;
using Bocom.ImageAnalysisClient.App.Framework;
using System.Data;
using Bocom.ImageAnalysisClient.DataModel;

namespace Bocom.ImageAnalysisClient.App.ViewModels
{
    class AnalyseResultsViewModel
    {
        private List<DataModel.AnalyseRecord> m_Results;

        private DataTable m_DT;


        public List<DataModel.AnalyseRecord> Results
        {
            get { return m_Results; }
        }

        public DataView DataView
        {
            get
            {
                return m_DT.DefaultView;
            }
        }

        internal AnalyseResultsViewModel()
        {
            m_Results = new List<DataModel.AnalyseRecord>();
            InitDataTable();
            Framework.Container.Instance.EvtAggregator.GetEvent<AnalyseRecordEvent>().Subscribe(
              OnAnalyseResult, ThreadOption.WinFormUIThread);
        }

        private void InitDataTable()
        {
            m_DT = new DataTable("AnalyseResults");
            //DataColumn columnId = m_DT.Columns.Add("Id", typeof(UInt32));
            //m_DT.PrimaryKey = new DataColumn[] { columnId };
            m_DT.Columns.Add("PlatformId");
            m_DT.Columns.Add("TaskId");
            m_DT.Columns.Add("AnalyseType");
            m_DT.Columns.Add("PicId");
            m_DT.Columns.Add("PicPath");
            m_DT.Columns.Add("ErrorCode");
            m_DT.Columns.Add("PlateNumber");
            m_DT.Columns.Add("PlateColor");
            m_DT.Columns.Add("VehicleType");
            m_DT.Columns.Add("DetailVehicleType");
            m_DT.Columns.Add("VehicleColor");
            m_DT.Columns.Add("Manufacturer");
            m_DT.Columns.Add("Type");

            m_DT.Columns.Add("AnalysisPlanInfo", typeof(AnalyseRecord));
        }

        private void AddRow(AnalyseRecord record)
        {
            m_DT.Rows.Add(new object[]{
                record.PlatformId,
                 record.TaskId,
                 record.AnalyseType,
                 record.PicId,
                 record.PicPath,
                 record.ErrorCode,
                 record.PlateNumber,
                 record.PlateColor,
                 record.VehicleType,
                 record.DetailVehicleType,
                 record.VehicleColor,
                 record.Manufacturer,
                 record.Type,
                 record
            });

        }

        void OnAnalyseResult(DataModel.AnalyseRecord obj)
        {
            m_Results.Add(obj);
            AddRow(obj);
        }
    }
}
