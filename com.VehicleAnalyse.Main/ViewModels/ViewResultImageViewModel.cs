using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.VehicleAnalyse.DataModel;
using System.Data;
using System.IO;

namespace com.VehicleAnalyse.Main.ViewModels
{
    class ViewResultImageViewModel
    {
        private List<AnalyseRecord> m_Records;

        private AnalyseRecord m_SelectedRecord;

        private DataTable m_DTSummary;

        private PageInfo m_PageInfo;

        public DataTable DTSummary
        {
            get { return m_DTSummary; }
        }
        
        public PageInfo PageInfo
        {
            get { return m_PageInfo; }
        }

        internal ViewResultImageViewModel(List<AnalyseRecord> records, int index)
        {
            m_Records = records;
            m_PageInfo = new PageInfo(1, records.Count, index);
            m_PageInfo.SelectedPageNumberChanged += new EventHandler(PageInfo_SelectedPageNumberChanged);
            InitDataTable();
            m_SelectedRecord = m_Records[m_PageInfo.PageIndex];
            UpdateSummaryTable();
        }

        void PageInfo_SelectedPageNumberChanged(object sender, EventArgs e)
        {
            m_SelectedRecord = m_Records[m_PageInfo.PageIndex];
            UpdateSummaryTable();
        }

        private void InitDataTable()
        {
            m_DTSummary = new DataTable("AnalyseRecord");
            m_DTSummary.Columns.Add("Name");
            m_DTSummary.Columns.Add("Value");
        }

        private void UpdateSummaryTable()
        {
            m_DTSummary.Rows.Clear();

            m_DTSummary.Rows.Add(new object[] { "编号", m_SelectedRecord.Id });
            m_DTSummary.Rows.Add(new object[] { "文件名", Path.GetFileName(m_SelectedRecord.PicPath) });
            m_DTSummary.Rows.Add(new object[] { "车牌号", m_SelectedRecord.PlateNumber});
            m_DTSummary.Rows.Add(new object[] { "车型", m_SelectedRecord.VehicleTypeInfo == null ? string.Empty : m_SelectedRecord.VehicleTypeInfo.Name});
            m_DTSummary.Rows.Add(new object[] { "细分车型", m_SelectedRecord.DetailVehicleTypeInfo  == null ? string.Empty : m_SelectedRecord.DetailVehicleTypeInfo.Name});
            
            if(m_SelectedRecord.BrandInfo == null)
            {
                m_DTSummary.Rows.Add(new object[] { "车型号", "未知"});
            }
            else
            {
                if(m_SelectedRecord.ParentBrandInfo != null)
                {
                    m_DTSummary.Rows.Add(new object[] { "车厂家", m_SelectedRecord.ParentBrandInfo.Name});
                }
                
                m_DTSummary.Rows.Add(new object[] { "车型号", m_SelectedRecord.BrandInfo.Name});
            }

            m_DTSummary.Rows.Add(new object[] { "车身颜色", m_SelectedRecord.VehicleColorInfo == null ? string.Empty : m_SelectedRecord.VehicleColorInfo.Name });
            
            m_DTSummary.Rows.Add(new object[] { "车牌颜色", m_SelectedRecord.PlateColorInfo == null ? string.Empty : m_SelectedRecord.PlateColorInfo.Name});
            
        }
    }
}
