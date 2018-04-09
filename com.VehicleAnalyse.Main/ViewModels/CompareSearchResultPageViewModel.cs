using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppUtil;
using com.VehicleAnalyse.Main.Framework;
using com.VehicleAnalyse.DataModel;
using com.VehicleAnalyse.Service.DAO;
using System.Data;
using System.Drawing;
using System.IO;
using DevExpress.XtraGrid;
using System.Windows.Forms;
using DevExpress.XtraPrinting;
using AppUtil.Controls;
using System.Drawing.Imaging;
using DevExpress.XtraGrid.Views.Grid;
using System.Diagnostics;
using VehicleHelper.DataModel;

namespace com.VehicleAnalyse.Main.ViewModels
{
    public class CpmpareSearchResultPageViewModel  : ViewModelBase
    {
        public event EventHandler SearchResult;
        public event Action<Dictionary<string, string>> PreNewSearch;

        #region Fields
        
        //private DataTable m_DTAnalyseResults;

        //private DataTable m_DTAnalyseResultsExport;

        //private DataTable m_DTSummary;

        //private AnalyseRecord m_SelectedRecord;

        private List<AnalyseRecord> m_Records;

        private DataModel.PageInfo m_ResultPageInfo;

        private bool m_HasResult = false;

        private FileAccessBase m_FileAccess;

        private SearchPara m_searchPara;

        private string m_Settings;

        ProgressFormStandalone m_StatusDlg;

        private DateTime SearchStartTime;
        #endregion

        #region Properties

        public List<AnalyseRecord> AnalyseResults { get { return m_Records; } }

        //public AnalyseRecord SelectedAnalyseRecord
        //{
        //    get
        //    {
        //        return m_SelectedRecord;
        //    }
        //    set
        //    {
        //        m_SelectedRecord = value;
        //        UpdateSummaryTable();
        //        if (m_SelectedRecord == null)
        //        {
        //            //SelectedRecordVehicleBrand = null;
        //        }
        //        else if(m_SelectedRecord.BrandInfo != null)
        //        {
        //            //SelectedRecordVehicleBrand = Framework.Container.Instance.TaskManager.GetBrand(m_SelectedRecord.BrandInfo.ID);
        //        }
        //    }
        //}

        /// <summary>
        /// 该属性本应该放在AnalyseRecord， 但是EntityFramework 生成的 model 在DataModel之上
        /// </summary>
        //public VehicleBrand SelectedRecordVehicleBrand { get; set; }

        public DataModel.PageInfo ResultPageInfo
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
        { get; set; }

        public string SearchSettings
        {
            get
            {
                return m_Settings;
            }
            set
            {
                m_Settings = value;
                RaisePropertyChangedEvent("SearchSettings");
            }
        }

        //public DataTable DTAnalyseResults
        //{
        //    get { return m_DTAnalyseResults; }
        //    set { m_DTAnalyseResults = value; }
        //}

        //public DataTable DTSummary
        //{
        //    get { return m_DTSummary; }
        //}


        #endregion

        #region Constructors

        public CpmpareSearchResultPageViewModel()
        {
            //InitTable();
            Framework.Container.Instance.EvtAggregator.GetEvent<NewCompareSearchEvent>().Subscribe(OnNewSearch, Microsoft.Practices.Prism.Events.ThreadOption.WinFormUIThread);
            //Framework.Container.Instance.EvtAggregator.GetEvent<NewCompareSearchEvent>().Subscribe(OnNewCompareSearch);
            Framework.Container.Instance.EvtAggregator.GetEvent<CompareSearchFinishedEvent>().Subscribe(OnSearchFinished,Microsoft.Practices.Prism.Events.ThreadOption.WinFormUIThread);
        }

        #endregion

        #region Public helper functions
        
        //public Image GetImage(AnalyseRecord record)
        //{
        //    Image imgRet = null;

        //    if (record != null)
        //    {
        //        if (record.Image != null)
        //        {
        //            // 不要与图片控件用同一个图片对象
        //            // 图片控件上的图片可以自己回收
        //            imgRet = record.Image.Clone() as Image;
        //        }
        //        else
        //        {
        //            // string fileName = m_FileAccess.GetFileName(record.PicId);
        //            try
        //            {
        //                //record.Image = m_FileAccess.GetImage(record.PicPath);
        //                record.Image = WinFormAppUtil.Common.Utils.GetImage(record.PicPath);
        //            }
        //            catch (Exception ex)
        //            {
        //                MyLog4Net.Container.Instance.Log.Error(string.Format("获取图片 {0} 出错", record.PicPath), ex);
        //            }
        //            if (record.Image != null)
        //            {
        //                imgRet = record.Image.Clone() as Image;
        //                Framework.Container.Instance.CacheManager.Register(record);
        //            }
        //        }
        //    }

        //    return imgRet;
        //}

        //public Image GetThumbImage(AnalyseRecord record)
        //{
        //    Image imgRet = null;

        //    if (record != null)
        //    {
        //        if (record.ThumbImg != null)
        //        {
        //            // 不要与图片控件用同一个图片对象
        //            // 图片控件上的图片可以自己回收
        //            imgRet = record.ThumbImg.Clone() as Image;
        //        }
        //        else
        //        {
        //            // string fileName = m_FileAccess.GetFileName(record.PicId);
        //            try
        //            {
        //                Image img = WinFormAppUtil.Common.Utils.GetImage(record.PicPath);
        //                record.ThumbImg = WinFormAppUtil.Common.Utils.CutImage(img, record.VehicleRegion);
        //                //record.ThumbImg = Framework.Container.Instance.TaskManager.GetThumbImg(record);
        //                //record.PlateImg = Framework.Container.Instance.TaskManager.GetPlateImg(record);
        //            }
        //            catch (Exception ex)
        //            {
        //                MyLog4Net.Container.Instance.Log.Error(string.Format("获取图片 {0} 出错", record.PicPath), ex);
        //            }
        //            if (record.ThumbImg != null)
        //            {
        //                imgRet = record.ThumbImg.Clone() as Image;
        //                Framework.Container.Instance.CacheManager.Register(record);
        //            }
        //        }
        //    }

        //    return imgRet;
        //}



        //public static Rectangle GetDecoRectangle(Image imgFull, Rectangle rectOri)
        //{
        //    Rectangle rect = Rectangle.Empty;

        //    if (rectOri != Rectangle.Empty)
        //    {
        //        int xOffset1 = 10, xOffset2 = 10, yOffset1 = 10, yOffset2 = 10;
        //        if (rectOri.X < 10)
        //        {
        //            xOffset1 = rectOri.X;
        //        }
        //        if (rectOri.Y < 10)
        //        {
        //            yOffset1 = rectOri.Y;
        //        }

        //        int temp = imgFull.Width - rectOri.X - rectOri.Width;
        //        if (temp < 10)
        //        {
        //            xOffset2 = temp;
        //        }

        //        temp = imgFull.Height - rectOri.Y - rectOri.Height;
        //        if (temp < 10)
        //        {
        //            yOffset2 = temp;
        //        }

        //        int Height = rectOri.Height + yOffset1 + yOffset2;
        //        int Width = rectOri.Width + xOffset1 + xOffset2;

        //        rect = new Rectangle(rectOri.X - xOffset1, rectOri.Y - yOffset1, Width, Height);
        //    }

        //    return rect;
        //}

        //public static Image DecorateFullImage(AnalyseRecord record)
        //{
        //    Image imgFull = new Bitmap(record.Image);
        //    Graphics g = Graphics.FromImage(imgFull);

        //    Rectangle rect;
            
        //    if (Framework.Environment.DrawPlateRect &&
        //        (rect = GetDecoRectangle(imgFull, record.PlateRegion)) != Rectangle.Empty)
        //    {
        //        g.DrawRectangle(new Pen(new SolidBrush(Color.Red), 3), rect);
        //    }

        //    if (Framework.Environment.DrawVehicleRect &&
        //        (rect = GetDecoRectangle(imgFull, record.VehicleRegion)) != Rectangle.Empty)
        //    {
        //        g.DrawRectangle(new Pen(new SolidBrush(Color.Purple), 4), rect);
        //    }

        //    g.Dispose();
        //    return imgFull;
        //}

        //public void TurnPrePage()
        //{
        //    m_DTAnalyseResults.Rows.Clear();
        //    HasResult = false;
        //    m_ResultPageInfo.TurnPrePage();
        //}

        //public void TurnNextPage()
        //{
        //    m_DTAnalyseResults.Rows.Clear();
        //    HasResult = false;
        //    m_ResultPageInfo.TurnNextPage();
        //}

        //private ImageFormat GetImageFormat(string fileName)
        //{
        //    ImageFormat format = ImageFormat.Jpeg;
            
        //    string extension = Path.GetExtension(fileName);

        //    if (string.Compare(extension, "bmp", true) == 0)
        //    {
        //        format = ImageFormat.Bmp;
        //    }
        //    else if (string.Compare(extension, "png", true) == 0)
        //    {
        //        format = ImageFormat.Png;
        //    }

        //    return format;
        //}

        //private void CopyImages(string fullPath)
        //{
        //    if (m_DTAnalyseResults != null && m_DTAnalyseResults.Rows != null)
        //    {
        //        string fileName;
        //        Image image;

        //        float progressPerFile = 0.8f / (float)m_DTAnalyseResults.Rows.Count;
        //        int i = 0;

        //        foreach (DataRow row in m_DTAnalyseResults.Rows)
        //        {
        //            i++;
        //            AnalyseRecord record = row["AnalyseRecord"] as AnalyseRecord;

        //            if (record != null)
        //            {
        //                m_StatusDlg.UpdateStatusText(string.Format("保存图片 {0} ...", record.PicPath));
        //                m_StatusDlg.UpdateProgress(0.2f + progressPerFile * i);
        //                try
        //                {
        //                    fileName = m_FileAccess.GetFileName(record.PicPath);
        //                    fileName = Path.Combine(fullPath, fileName);
                            
        //                    if (m_FileAccess is LocalFileAccess)
        //                    {
        //                        File.Copy(record.PicPath, fileName);
        //                    }
        //                    else
        //                    {
        //                        image = WinFormAppUtil.Common.Utils.GetImage(record.PicPath);
        //                        CopyImage(image, fileName);
        //                    }
        //                }
        //                catch (Exception ex)
        //                {
        //                    MyLog4Net.Container.Instance.Log.Error(string.Format("导出文件 {0} 出错", record.PicPath), ex);
        //                }
        //            }
        //        }
        //    }
        //}

        //private void CopyImages(List<AnalyseRecord> records, string fullPath)
        //{
        //    string fileName;
        //    Image image;

        //    float progressPerFile = 0.6f / (float)records.Count;
        //    int i = 0;
        //    foreach (AnalyseRecord record in records)
        //    {
        //        i++;
        //        if (record != null)
        //        {
        //            m_StatusDlg.UpdateStatusText(string.Format("保存图片 {0} ...", record.PicPath));
        //            m_StatusDlg.UpdateProgress(0.4f + progressPerFile * i);
        //            try
        //            {
        //                fileName = m_FileAccess.GetFileName(record.PicPath);
        //                fileName = Path.Combine(fullPath, fileName);
        //                image = WinFormAppUtil.Common.Utils.GetImage(record.PicPath);
                        
        //                if (m_FileAccess is LocalFileAccess)
        //                {
        //                    File.Copy(record.PicPath, fileName);
        //                }
        //                else
        //                {
        //                    image = WinFormAppUtil.Common.Utils.GetImage(record.PicPath);
        //                    CopyImage(image, fileName);
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                MyLog4Net.Container.Instance.Log.Error(string.Format("导出文件 {0} 出错", record.PicPath), ex);
        //            }
        //        }
        //    }
        //}

        //private void CopyImage(Image imgSrc, string fileNameDes)
        //{
        //    if (imgSrc != null)
        //    {
        //        Image imgDes = new Bitmap(imgSrc.Width, imgSrc.Height, imgSrc.PixelFormat);
        //        Graphics g = Graphics.FromImage(imgDes);
        //        g.DrawImage(imgSrc, new Point(0, 0));
        //        g.Dispose();
        //        ImageFormat format = GetImageFormat(fileNameDes);
        //        imgDes.Save(fileNameDes, format);
        //        imgSrc.Dispose();
        //        imgDes.Dispose();
        //    }
        //}

        //private void CustomizeExportResult(GridControl gridControl, DataTable dt)
        //{
        //    ((GridView)gridControl.DefaultView).Columns["ModelId"].Visible = Framework.Environment.ReviseMode;
        //    if(!Framework.Environment.ReviseMode)
        //    {
        //        return;
        //    }
        //    string fullName, fileName;
        //    foreach(DataRow row in dt.Rows)
        //    {

        //        fullName = row["FullName"] as string;
        //        if (!string.IsNullOrEmpty(fullName))
        //        {
        //                fileName = System.IO.Path.GetFileName(fullName);
        //            row["FileName"] = fileName;
        //        }
        //    }

        //    ((GridView)(gridControl.Views[0])).Columns[((GridView)(gridControl.Views[0])).Columns.Count - 2].Visible = false;
        //}

        //public void Delete(List<string > ids)
        //{
        //    //Framework.Container.Instance.TaskManager.DeleteAnalyseRecords(ids);

        //    foreach (string  id in ids)
        //    {
        //        DataRow row = m_DTAnalyseResults.Rows.Find(id);
        //        AnalyseRecord record = row["AnalyseRecord"] as AnalyseRecord;
        //        Debug.Assert(record != null);
        //        if (record != null && m_Records.Contains(record))
        //        {
        //            m_Records.Remove(record);
        //        }

        //        Debug.Assert(row != null);
        //        if (row != null)
        //        {
        //            row.Delete();
        //        }

        //    }

        //    ResultPageInfo.DecreaseCurrentPageCount(ids.Count);
        //}

        //public void ExportCurrentPage(GridControl gridControlResults, string fileName, bool diagram, bool pics)
        //{
        //    if (pics)
        //    {
        //        m_StatusDlg = new ProgressFormStandalone("导出本页记录", "导出 xls 文件 ...");
        //        m_StatusDlg.Show();
        //    }
        //    try
        //    {
        //        if (diagram)
        //        {
        //            // 改用导出全部的数据表， 因为人工修改时的导出与显示的不一样
        //            m_DTAnalyseResultsExport.Rows.Clear();

        //            foreach (AnalyseRecord record in m_Records)
        //            {
        //                AddResultRow(m_DTAnalyseResultsExport, record, true);
        //            }

        //            CustomizeExportResult(gridControlResults, m_DTAnalyseResultsExport);
        //            gridControlResults.DataSource = m_DTAnalyseResultsExport;

        //            if (Framework.Environment.ResultExportAsXls)
        //            {
        //                gridControlResults.ExportToXls(fileName);
        //            }
        //            else
        //            {
        //                gridControlResults.ExportToCsv(fileName);
        //            }
        //        }

        //        if (pics)
        //        {
        //            string fullPath = fileName;
        //            if (diagram)
        //            {
        //                string folder = Path.GetFileNameWithoutExtension(fileName);
        //                string path = Path.GetDirectoryName(fileName);
        //                folder = string.Concat(folder, "当前页导出图片");

        //                fullPath = Path.Combine(path, folder);
        //                if (!Directory.Exists(fullPath))
        //                {
        //                    Directory.CreateDirectory(fullPath);
        //                }
        //            }

        //            m_StatusDlg.UpdateProgress(0.2f);
        //            m_StatusDlg.UpdateStatusText("开始导出图片 ...");

        //            CopyImages(fullPath);
        //            m_StatusDlg.Close();
        //        }

        //        m_DTAnalyseResultsExport.Clear();
        //        Framework.Container.Instance.EvtAggregator.GetEvent<AnalyseMessageEvent>().Publish(
        //            new Tuple<uint, string>(10, string.Format("导出本页记录到 {0} 成功", fileName)));

        //        Framework.Container.Instance.InteractionService.ShowMessageBox("导出本页记录成功");
        //    }
        //    finally
        //    {
        //        if (pics)
        //        {
        //            m_StatusDlg.Close();
        //        }
        //    }

        //}

        //public void ExportAll(GridControl gridControl, string fileName, bool diagram, bool pics)
        //{
        //    m_StatusDlg = new ProgressFormStandalone("导出全部记录", "获取全部结果记录 ...");
        //    m_StatusDlg.Show();

        //    List<AnalyseRecord> records = this.m_Records;

        //    m_StatusDlg.UpdateProgress(0.3f);

        //    if (records != null && records.Count > 0)
        //    {
        //        m_DTAnalyseResultsExport.Clear();

        //        foreach (AnalyseRecord record in records)
        //        {
        //            AddResultRow(m_DTAnalyseResultsExport, record, true);
        //        }

        //        CustomizeExportResult(gridControl, m_DTAnalyseResultsExport);

        //        if (diagram)
        //        {
        //            m_StatusDlg.UpdateStatusText("导出 xls 文件 ...");
        //            gridControl.DataSource = m_DTAnalyseResultsExport;

        //            if (Framework.Environment.ResultExportAsXls)
        //            {
        //                gridControl.ExportToXls(fileName);
        //            }
        //            else
        //            {
        //                gridControl.ExportToCsv(fileName);
        //            }
        //        }

        //        if (pics)
        //        {
        //            string fullPath = fileName;
        //            if (diagram)
        //            {
        //                string folder = Path.GetFileNameWithoutExtension(fileName);
        //                string path = Path.GetDirectoryName(fileName);
        //                folder = string.Concat(folder, "全部结果导出图片");

        //                fullPath = Path.Combine(path, folder);
        //                if (!Directory.Exists(fullPath))
        //                {
        //                    Directory.CreateDirectory(fullPath);
        //                }
        //            }

        //            m_StatusDlg.UpdateProgress(0.4f);
        //            m_StatusDlg.UpdateStatusText("开始导出图片 ...");
        //            CopyImages(records, fullPath);
        //        }
        //        m_DTAnalyseResultsExport.Rows.Clear();
        //    }

        //    m_StatusDlg.Close();
        //}

        //public void Export(GridControl gridControl, string fileName, List<AnalyseRecord> records, bool diagram, bool pics)
        //{
        //    m_DTAnalyseResultsExport.Clear();

        //    if (records != null && records.Count > 0)
        //    {
        //        if (pics)
        //        {
        //            m_StatusDlg = new ProgressFormStandalone("导出选中记录", "开始导出 ...");
        //            m_StatusDlg.Show();

        //            if(diagram)
        //            {
        //                m_StatusDlg.UpdateStatusText("导出 xls 文件 ...");
        //            }
        //        }

        //        if (diagram)
        //        {
        //            foreach (AnalyseRecord record in records)
        //            {
        //                AddResultRow(m_DTAnalyseResultsExport, record, true);
        //            }

        //            CustomizeExportResult(gridControl, m_DTAnalyseResultsExport);
        //            gridControl.DataSource = m_DTAnalyseResultsExport;

        //            if (Framework.Environment.ResultExportAsXls)
        //            {
        //                gridControl.ExportToXls(fileName);
        //            }
        //            else
        //            {
        //                gridControl.ExportToCsv(fileName);
        //            }
        //        }

        //        if (pics)
        //        {
        //            string fullPath = fileName;
        //            if (diagram)
        //            {
        //                string folder = Path.GetFileNameWithoutExtension(fileName);
        //                string path = Path.GetDirectoryName(fileName);
        //                folder = string.Concat(folder, "选中记录导出图片");

        //                fullPath = Path.Combine(path, folder);
        //                if (!Directory.Exists(fullPath))
        //                {
        //                    Directory.CreateDirectory(fullPath);
        //                }
        //            }

        //            m_StatusDlg.UpdateProgress(0.2f);
        //            m_StatusDlg.UpdateStatusText("开始导出图片 ...");

        //            CopyImages(records, fullPath);
        //            m_StatusDlg.Close();
        //        }

        //        m_DTAnalyseResultsExport.Clear();
        //    }
        //}
        
        //public void Save()
        //{
        //    // 这里可以考虑从数据库重新load， 保证一致
        //    if (m_DTAnalyseResults.Rows != null && m_DTAnalyseResults.Rows.Count > 0)
        //    {
        //        AnalyseRecord record;
        //        foreach (DataRow row in m_DTAnalyseResults.Rows)
        //        {
        //            record = row["AnalyseRecord"] as AnalyseRecord;
        //            record.PlateNumber = row["PlateNumber"].ToString();
        //            record.ErrorCode = 0;
        //            record.VehicleTypeInfo = row["VehicleType"] as VehiclePropertyInfo;
        //            record.DetailVehicleTypeInfo = row["DetailVehicleType"] as VehiclePropertyInfo;
        //            // row["Brand"] as ModelPropertyInfo;
        //            VehiclePropertyInfo mpi = row["Model"] as VehiclePropertyInfo;
        //            if (mpi != null && mpi != Constant.PropertyInfo_UNKNOWN)
        //            {
        //                record.BrandInfo = mpi;
        //            }
        //            else
        //            {
        //                // 没有型号时， 直接使用车厂家
        //                record.BrandInfo = row["Brand"] as VehiclePropertyInfo;
        //            }
        //            record.ParentBrandInfo = row["Brand"] as VehiclePropertyInfo;
        //            record.VehicleColorInfo = row["VehicleColor"] as VehiclePropertyInfo;
        //            record.PlateTypeInfo = row["PlateType"] as VehiclePropertyInfo;
        //            record.PlateColorInfo = row["PlateColor"] as VehiclePropertyInfo;
        //            record.DriverWearingSafeBelt = row["DriverBeltWearing"] as VehiclePropertyInfo;
        //            record.CoDriverWearingSafeBelt = row["CoDriverBeltWearing"] as VehiclePropertyInfo;
        //            record.DriverPhoneCalling = row["DriverPhoneCall"] as VehiclePropertyInfo;
        //            record.DriverSunlightShield = row["DriverShielding"] as VehiclePropertyInfo;
        //            record.CoDriverSunlightShield = row["CoDriverShielding"] as VehiclePropertyInfo;
        //        }
        //        //Framework.Container.Instance.TaskManager.SaveAnalyseResults(m_Records);
        //    }
        //}


        internal AnalyseRecord GetVehicleByID(string vehicleid)
        {
            if (m_Records != null && m_Records.Count > 0)
            {
                return m_Records.Find(it => it.Id == vehicleid);
            }
            else
                return null;
        }

        //internal AnalyseRecord GetNextVehicleByID(string vehicleid)
        //{
        //    if (m_Records != null && m_Records.Count > 0)
        //    {
        //        int id = m_Records.FindIndex(it => it.Id == vehicleid);
        //        if (id + 1 < m_Records.Count)
        //            return m_Records[id + 1];
        //        else
        //            return null;
        //    }
        //    else
        //        return null;
        //}

        //internal AnalyseRecord GetPrivVehicleByID(string vehicleid)
        //{
        //    if (m_Records != null && m_Records.Count > 0)
        //    {
        //        int id = m_Records.FindIndex(it => it.Id == vehicleid);
        //        if (id > 0)
        //            return m_Records[id - 1];
        //        else
        //            return null;
        //    }
        //    else
        //        return null;
        //}

        //internal bool IsCanNext(string vehicleid)
        //{
        //    if (m_Records != null && m_Records.Count > 0)
        //    {
        //        int id = m_Records.FindIndex(it => it.Id == vehicleid);
        //        return (id + 1 < m_Records.Count);
        //    }
        //    else
        //        return false;
        //}

        //internal bool IsCanPriv(string vehicleid)
        //{
        //    if (m_Records != null && m_Records.Count > 0)
        //    {
        //        int id = m_Records.FindIndex(it => it.Id == vehicleid);
        //        return (id >= 0);
        //    }
        //    else
        //        return false;
        //}

        #endregion

        #region Private helper functions
        
        //private void InitTable()
        //{
        //    m_DTAnalyseResults = new DataTable("AnalyseRecords");
        //    DataColumn columnId = m_DTAnalyseResults.Columns.Add("Id");
        //    //m_DTAnalyseResults.PrimaryKey = new DataColumn[] { columnId };

        //    m_DTAnalyseResults.Columns.Add("WatchTime");
        //    m_DTAnalyseResults.Columns.Add("FileName");
        //    m_DTAnalyseResults.Columns.Add("FullName");
        //    m_DTAnalyseResults.Columns.Add("PlateNumber");
        //    m_DTAnalyseResults.Columns.Add("PlateNumberReliability");
        //    m_DTAnalyseResults.Columns.Add("VehicleType", typeof(VehiclePropertyInfo));
        //    m_DTAnalyseResults.Columns.Add("DetailVehicleType", typeof(VehiclePropertyInfo));
        //    m_DTAnalyseResults.Columns.Add("Manufacturer");
        //    m_DTAnalyseResults.Columns.Add("ManufacturerReliability");
        //    m_DTAnalyseResults.Columns.Add("Brand", typeof(VehiclePropertyInfo));
        //    m_DTAnalyseResults.Columns.Add("Model", typeof(VehiclePropertyInfo));
        //    m_DTAnalyseResults.Columns.Add("VehicleColor", typeof(VehiclePropertyInfo));
        //    m_DTAnalyseResults.Columns.Add("PlateType", typeof(VehiclePropertyInfo));
        //    m_DTAnalyseResults.Columns.Add("PlateColor", typeof(VehiclePropertyInfo));

        //    m_DTAnalyseResults.Columns.Add("DriverBeltWearing", typeof(VehiclePropertyInfo));
        //    m_DTAnalyseResults.Columns.Add("CoDriverBeltWearing", typeof(VehiclePropertyInfo));
        //    m_DTAnalyseResults.Columns.Add("DriverPhoneCall", typeof(VehiclePropertyInfo));

        //    m_DTAnalyseResults.Columns.Add("DriverShielding", typeof(VehiclePropertyInfo));
        //    m_DTAnalyseResults.Columns.Add("CoDriverShielding", typeof(VehiclePropertyInfo));
        //    m_DTAnalyseResults.Columns.Add("CompareSimilarity", typeof(uint));

        //    m_DTAnalyseResults.Columns.Add("AnalyseRecord", typeof(AnalyseRecord));

        //    m_DTSummary = new DataTable("AnalyseRecord");
        //    m_DTSummary.Columns.Add("Name");
        //    m_DTSummary.Columns.Add("Value");

        //    // this.m_DTAnalyseResultsExport
        //    m_DTAnalyseResultsExport = new DataTable("AnalyseRecords4Export");
        //    columnId = m_DTAnalyseResultsExport.Columns.Add("Id");
        //    //m_DTAnalyseResultsExport.PrimaryKey = new DataColumn[] { columnId };

        //    m_DTAnalyseResultsExport.Columns.Add("WatchTime");
        //    m_DTAnalyseResultsExport.Columns.Add("FileName");
        //    m_DTAnalyseResultsExport.Columns.Add("FullName");
        //    m_DTAnalyseResultsExport.Columns.Add("PlateNumber");
        //    m_DTAnalyseResultsExport.Columns.Add("PlateNumberReliability");
        //    m_DTAnalyseResultsExport.Columns.Add("VehicleType", typeof(VehiclePropertyInfo));
        //    m_DTAnalyseResultsExport.Columns.Add("DetailVehicleType", typeof(VehiclePropertyInfo));
        //    m_DTAnalyseResultsExport.Columns.Add("Manufacturer");
        //    m_DTAnalyseResultsExport.Columns.Add("ManufacturerReliability");
        //    m_DTAnalyseResultsExport.Columns.Add("Brand", typeof(VehiclePropertyInfo));
        //    m_DTAnalyseResultsExport.Columns.Add("Model", typeof(VehiclePropertyInfo));

        //    m_DTAnalyseResultsExport.Columns.Add("ModelId");

        //    m_DTAnalyseResultsExport.Columns.Add("VehicleColor", typeof(VehiclePropertyInfo));
        //    m_DTAnalyseResultsExport.Columns.Add("PlateType", typeof(VehiclePropertyInfo));
        //    m_DTAnalyseResultsExport.Columns.Add("PlateColor", typeof(VehiclePropertyInfo));

        //    m_DTAnalyseResultsExport.Columns.Add("DriverBeltWearing", typeof(VehiclePropertyInfo));
        //    m_DTAnalyseResultsExport.Columns.Add("CoDriverBeltWearing", typeof(VehiclePropertyInfo));
        //    m_DTAnalyseResultsExport.Columns.Add("DriverPhoneCall", typeof(VehiclePropertyInfo));
        //    m_DTAnalyseResultsExport.Columns.Add("DriverShielding", typeof(VehiclePropertyInfo));
        //    m_DTAnalyseResultsExport.Columns.Add("CoDriverShielding", typeof(VehiclePropertyInfo));

        //    m_DTAnalyseResultsExport.Columns.Add("CompareSimilarity", typeof(uint));
        //    m_DTAnalyseResultsExport.Columns.Add("AnalyseRecord", typeof(AnalyseRecord));
        //}

        //private void UpdateSummaryTable()
        //{
        //    m_DTSummary.Rows.Clear();
        //    if (m_SelectedRecord != null)
        //    {
        //        string plateNumber = GetPlateNumber(m_SelectedRecord);

        //        string vehicleColor = string.Empty, plateColor = string.Empty;
        //        GetVehicleColor(m_SelectedRecord, ref vehicleColor, ref plateColor);

        //        m_DTSummary.Rows.Add(new object[] { "编号", m_SelectedRecord.Id });
        //        m_DTSummary.Rows.Add(new object[] { "过车时间", m_SelectedRecord.WatchTime.ToString(Constant.DATETIME_FORMAT) });
        //        m_DTSummary.Rows.Add(new object[] { "车牌号", plateNumber });
        //        m_DTSummary.Rows.Add(new object[] { "车型", m_SelectedRecord.VehicleTypeInfo == null ? "未识别" : m_SelectedRecord.VehicleTypeInfo.Name });
        //        m_DTSummary.Rows.Add(new object[] { "细分车型", m_SelectedRecord.DetailVehicleTypeInfo == null ? "未识别" : m_SelectedRecord.DetailVehicleTypeInfo.Name });
        //        m_DTSummary.Rows.Add(new object[] { "车身颜色", vehicleColor });

        //        VehiclePropertyInfo brand, model;
        //        GetVehicleBrandName(m_SelectedRecord, out brand, out model);

        //        m_DTSummary.Rows.Add(new object[] { "车品牌", brand });
        //        m_DTSummary.Rows.Add(new object[] { "车型号", model });

        //        m_DTSummary.Rows.Add(new object[] { "车牌颜色", plateColor });
        //        m_DTSummary.Rows.Add(new object[] { "主驾驶是否系安全带", m_SelectedRecord.DriverWearingSafeBelt });
        //        m_DTSummary.Rows.Add(new object[] { "副驾驶是否系安全带", m_SelectedRecord.CoDriverWearingSafeBelt });
        //        if (Framework.Environment.PhoneCallFeature)
        //        {
        //            m_DTSummary.Rows.Add(new object[] { "主驾驶是否打手机", m_SelectedRecord.DriverPhoneCalling });
        //        }
        //        m_DTSummary.Rows.Add(new object[] { "主驾驶是否有遮阳板", m_SelectedRecord.DriverSunlightShield });
        //        m_DTSummary.Rows.Add(new object[] { "副驾驶是否有遮阳板", m_SelectedRecord.CoDriverSunlightShield });

        //        m_DTSummary.Rows.Add(new object[] { "文件名", Path.GetFileName(m_SelectedRecord.PicPath) });
        //        m_DTSummary.Rows.Add(new object[] { "文件路径", m_SelectedRecord.PicPath });
        //    }
        //}

        //private string GetDriverWearingSafeBelt(AnalyseRecord analyseRecord)
        //{
        //    string sRet = "未识别";
        //    if (analyseRecord != null && analyseRecord.DriverWearingSafeBelt != null)
        //    {
        //        if (analyseRecord.DriverWearingSafeBelt.ID != 3)
        //        {
        //            sRet = analyseRecord.DriverWearingSafeBelt.Name;
        //        }
        //    }

        //    return sRet;
        //}

        private string GetPlateNumber(AnalyseRecord analyseRecord)
        {
            string plateNumber = string.Empty;
            if (analyseRecord != null)
            {
                plateNumber = analyseRecord.PlateNumber;
                if (analyseRecord.ErrorCode == 0)
                {
                    if (string.Compare(analyseRecord.PlateNumber, "11111111", true) == 0)
                    {
                        plateNumber = "无牌车";
                    }
                    if (string.Compare(analyseRecord.PlateNumber, "22222222", true) == 0)
                    {
                        plateNumber = "两轮车";
                    }
                }
                else if (analyseRecord.ErrorCode == -2)
                {
                    plateNumber = "未识别";
                }
                else
                {
                    plateNumber = "图片错误";
                }
            }
            return plateNumber;
        }

        //private void GetVehicleBrandName(AnalyseRecord record, ref string brand, ref string model)
        //{
        //    brand =  "未识别" ;
        //    model =  "未识别" ;

        //    if (record.BrandInfo != null)
        //    {
        //        model = record.BrandInfo.Name;
        //        if (record.ParentBrandInfo != null)
        //        {
        //            brand = record.ParentBrandInfo.Name;
        //        }
        //        else
        //        {
        //            brand = string.Empty;
        //        }
        //    }
        //}

        private void GetVehicleBrandName(AnalyseRecord record, out VehiclePropertyInfo brand, out VehiclePropertyInfo model)
        {
            brand = Constant.PropertyInfo_UNKNOWN;
            model = Constant.PropertyInfo_UNKNOWN;

            if (record.BrandInfo != null)
            {
                if (record.ParentBrandInfo != null)
                {
                    if (record.ParentBrandInfo.ID == 999 )
                    {
                        // 被归到其它车厂商的车， 车厂家设置成与车型一样
                        brand = model = record.BrandInfo;
                    }
                    else
                    {
                        brand = record.ParentBrandInfo;
                        model = record.BrandInfo;
                    }
                }
                else
                {
                    // brand = Constant.PropertyInfo_UNKNOWN;
                    brand = model = record.BrandInfo;
                }
            }
        }

        private void GetVehicleColor(AnalyseRecord record, ref string vehicleColor, ref string plateColor)
        {
            vehicleColor = 
             record.VehicleColorInfo != null ? record.VehicleColorInfo.Name : record.VehicleColor;
            plateColor =
                record.PlateColorInfo != null ? record.PlateColorInfo.Name : record.PlateColor;

            if (string.IsNullOrEmpty(vehicleColor))
            {
                vehicleColor = "未识别";
            }
            if (string.IsNullOrEmpty(plateColor))
            {
                plateColor = "未识别";
            }
        }

        //private void AddResultRow(DataTable dt, AnalyseRecord record, bool forExport=false)
        //{
        //    string plateNumber = GetPlateNumber(record);
        //    // string brand = string.Empty, model = string.Empty;
        //    // GetVehicleBrandName(record, ref brand, ref model);
        //    VehiclePropertyInfo brand, model;
        //    GetVehicleBrandName(record, out brand, out model);

        //    string vehicleColor = string.Empty, plateColor = string.Empty;
        //    GetVehicleColor(record, ref vehicleColor, ref plateColor);

        //    if (forExport)
        //    {
        //        dt.Rows.Add(new object[]{
        //        record.Id,
        //        record.WatchTime.ToString(Constant.DATETIME_FORMAT),
        //        m_FileAccess.GetFileName(record.PicPath),
        //        record.PicPath,
        //        plateNumber,
        //        record.PlateNumberReliability,
        //        record.VehicleTypeInfo,
        //        record.DetailVehicleTypeInfo, 
        //        record.Manufacturer,
        //        record.ManufacturerReliability,
        //        brand,
        //        model, 
        //        record.BrandInfo.ID, // 导出时特别添加
        //        record.VehicleColorInfo, 
        //        record.PlateTypeInfo,
        //        record.PlateColorInfo, 
        //        record.DriverWearingSafeBelt, 
        //        record.CoDriverWearingSafeBelt, 
        //        record.DriverPhoneCalling,
        //        record.DriverSunlightShield,
        //        record.CoDriverSunlightShield,
        //        record.CompareSimilarity,
        //        record
        //    });
        //    }
        //    else
        //    {
        //        dt.Rows.Add(new object[]{
        //        record.Id,
        //        record.WatchTime.ToString(Constant.DATETIME_FORMAT),
        //        m_FileAccess.GetFileName(record.PicPath),
        //        record.PicPath,
        //        plateNumber,
        //        record.PlateNumberReliability,
        //        record.VehicleTypeInfo,
        //        record.DetailVehicleTypeInfo, 
        //        record.Manufacturer,
        //        record.ManufacturerReliability,
        //        brand,
        //        model, 
        //        record.VehicleColorInfo, 
        //        record.PlateTypeInfo,
        //        record.PlateColorInfo, 
        //        record.DriverWearingSafeBelt, 
        //        record.CoDriverWearingSafeBelt, 
        //        record.DriverPhoneCalling,
        //        record.DriverSunlightShield,
        //        record.CoDriverSunlightShield,
        //        record.CompareSimilarity,
        //        record
        //    });
        //    }
        //}


        private string GetPlateNumberFromOther(string other)
        {
            if ((Program.PRODUCT_TYPE & Framework.Environment.E_PRODUCT_TYPE.TianJin_PRODUCT) > 0)
            {
                try
                {
                    //HX031-1-2-20110413123654-津123456-0-00-000-000.jpg
                    string[] temp = other.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                    if (temp.Length == 9)
                        return temp[4];
                    else
                        return "";
                }
                catch 
                {
                return "";}
            }
            else
                return "";
        }
        
        private void OnNewSearch(SearchPara searchPara)
        {
            SearchStartTime = DateTime.Now;
            if (PreNewSearch != null)
            {
                Dictionary<string, string> settings = searchPara.GetSettings();
                PreNewSearch(settings);
            }

            if (m_ResultPageInfo != null)
            {
                m_ResultPageInfo.SelectedPageNumberChanged -= new EventHandler(ResultPageInfo_SelectedPageNumberChanged);
            }
            //m_DTAnalyseResults.Rows.Clear();

            m_searchPara = searchPara;
            // SearchSettings = searchPara.ToString();

            m_FileAccess = FileAccessFactory.GetFileAccess("ftp://");

            //if (Framework.Container.Instance.TaskManager.Revisor != null)
            //{
            //    if (Task.Status == TaskStatus.Finished)
            //    {
            //        m_Records = Framework.Container.Instance.TaskManager.Revisor.GetAllResults(Task);
            //        m_ResultPageInfo = new DataModel.PageInfo(m_Records.Count == 0? 100 : m_Records.Count, searchPara.ResultCount, 0);
            //    }
            //    else
            //    {
            //        m_Records = null;
            //        m_ResultPageInfo = new DataModel.PageInfo(100, 0, 0);
            //    }
            //}
            //else
            //{
            //    m_ResultPageInfo = new DataModel.PageInfo(100, searchPara.ResultCount, 0);
            //    m_ResultPageInfo.SelectedPageNumberChanged += new EventHandler(ResultPageInfo_SelectedPageNumberChanged);
            //    m_SQLQuery = m_searchPara.SqlQuery;
            //    //m_Records = Framework.Container.Instance.TaskManager.SwitchPage(m_SQLQuery, m_ResultPageInfo);
            //}

            //FileName = string.Format("检索耗时:{1} {0}: ", m_searchPara.ToString(), SearchCastTime);
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

            //if (SearchResult != null)
            //{
            //    SearchResult(this, EventArgs.Empty);
            //}
        }

        //private void OnNewCompareSearch(SearchPara searchPara)
        //{
        //    m_isCompareSearch = true;
        //    if (PreNewSearch != null)
        //    {
        //        string[] settings = new string[] { searchPara.Task.TaskName+ " 以图搜车" };
        //        PreNewSearch(settings);
        //    }

        //    if (m_ResultPageInfo != null)
        //    {
        //        m_ResultPageInfo.SelectedPageNumberChanged -= new EventHandler(ResultPageInfo_SelectedPageNumberChanged);
        //    }
        //    m_DTAnalyseResults.Rows.Clear();

        //    m_searchPara = searchPara;
        //    Task = m_searchPara.Task;
        //    // SearchSettings = searchPara.ToString();
         
        //    //m_FileAccess = FileAccessFactory.GetFileAccess(Task.PictureSource);

        //    if (Framework.Container.Instance.TaskManager.Revisor != null)
        //    {
        //        if (Task.Status == TaskStatus.Finished)
        //        {
        //            m_Records = Framework.Container.Instance.TaskManager.Revisor.GetAllResults(Task);
        //            m_ResultPageInfo = new DataModel.PageInfo(m_Records.Count == 0? 100 : m_Records.Count, searchPara.ResultCount, 0);
        //        }
        //        else
        //        {
        //            m_Records = null;
        //            m_ResultPageInfo = new DataModel.PageInfo(100, 0, 0);
        //        }
        //    }
        //    else
        //    {
        //        m_ResultPageInfo = new DataModel.PageInfo(100, searchPara.ResultCount, 0);
        //        m_ResultPageInfo.SelectedPageNumberChanged += new EventHandler(ResultPageInfo_SelectedPageNumberChanged);
        //        m_SQLQuery = m_searchPara.SqlQuery;
        //        //m_Records = Framework.Container.Instance.TaskManager.SwitchComparePage(m_SQLQuery, m_ResultPageInfo, m_searchPara);
        //    }

        //    FileName = string.Format("{0}: ", m_searchPara.Task.TaskName);
        //    RaisePropertyChangedEvent("FileName");
        //    if (m_Records != null && m_Records.Count > 0)
        //    {
        //        foreach (AnalyseRecord record in m_Records)
        //        {
        //            AddResultRow(m_DTAnalyseResults, record);
        //        }
        //        HasResult = true;
        //    }
        //    else
        //    {
        //        Framework.Container.Instance.InteractionService.ShowMessageBox("没有检索到结果");
        //    }

        //    if (SearchResult != null)
        //    {
        //        SearchResult(this, EventArgs.Empty);
        //    }
        //}
        private void OnSearchFinished(Tuple< List<AnalyseRecord>,long,string> records)
        {
            if (SearchStartTime == null)
                SearchStartTime = DateTime.Now.AddSeconds(-2);
            DateTime searchFinishTime = DateTime.Now;
            Trace.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss,fff") + " OnSearchFinished 1");
            if (records != null && records.Item1 != null && records.Item1.Count > 0)
            {
                m_Records = records.Item1;

                m_ResultPageInfo = new DataModel.PageInfo(24 , m_Records.Count,  0);
                m_ResultPageInfo.SelectedPageNumberChanged += new EventHandler(ResultPageInfo_SelectedPageNumberChanged);
                //foreach (AnalyseRecord record in m_Records.GetRange(0, Math.Min(12, m_Records.Count)))
                //{
                //    AddResultRow(m_DTAnalyseResults, record);
                //}
                HasResult = true;
            }
            else
            {
                m_Records = null;
                m_ResultPageInfo = new DataModel.PageInfo(24, 0, 0);
                Framework.Container.Instance.InteractionService.ShowMessageBox("没有检索到结果"+ (string.IsNullOrEmpty(records.Item3)?"":"，错误信息："+records.Item3));
            }
            Trace.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss,fff") + " OnSearchFinished 2");

            if (SearchResult != null)
            {
                SearchResult(true, EventArgs.Empty);
            }
            Trace.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss,fff") + " OnSearchFinished 3");
            string SearchCastTime1 = searchFinishTime.Subtract(SearchStartTime).TotalSeconds.ToString("0.#") + "秒";
            string SearchCastTime2 = DateTime.Now.Subtract(SearchStartTime).TotalSeconds.ToString("0.#") + "秒";

            FileName = string.Format("比对总数:{3}条，检索用时:{1} ", m_searchPara.ToString(), SearchCastTime1,SearchCastTime2,records.Item2);
            RaisePropertyChangedEvent("FileName");
        }
        #endregion

        #region Event handlers

        void ResultPageInfo_SelectedPageNumberChanged(object sender, EventArgs e)
        {
            //m_DTAnalyseResults.Clear();
            //if (m_isCompareSearch)
            //m_Records = Framework.Container.Instance.TaskManager.SwitchComparePage(m_SQLQuery, m_ResultPageInfo,new SearchPara());
            //else
            //m_Records = Framework.Container.Instance.TaskManager.SwitchPage(m_SQLQuery, m_ResultPageInfo);
            int startindex = Math.Min(m_Records.Count, m_ResultPageInfo.PageIndex * 24);
            int count = Math.Min(24, m_Records.Count - startindex);
            if (m_Records != null && m_Records.Count > 0)
            {
                //foreach (AnalyseRecord record in m_Records.GetRange(startindex, count))
                //{
                //    AddResultRow(m_DTAnalyseResults, record);
                //}
                HasResult = true;
            }

            if (SearchResult != null)
            {
                SearchResult(false, EventArgs.Empty);
            }

        }

        #endregion

    }
}
