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
    public class PlateGroupSubResultPageViewModel  : ViewModelBase
    {
        public event EventHandler SearchResult;
        public event EventHandler PreNewSearch;

        #region Fields

        private List<List<AnalyseRecord>> m_DTAnalyseResults;

        private List<AnalyseRecord> m_Records;

        private Dictionary <string,List<AnalyseRecord>> m_GroupRecords;

        private DataModel.PageInfo m_ResultPageInfo;

        ProgressFormStandalone m_StatusDlg;

        public bool m_HasResult;

        #endregion

        #region Properties


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


        public List<List<AnalyseRecord>> DTAnalyseResults
        {
            get { return m_DTAnalyseResults; }
            set { m_DTAnalyseResults = value; }
        }

        #endregion

        #region Constructors

        public PlateGroupSubResultPageViewModel()
        {
            InitTable();
        }

        #endregion

        #region Public helper functions
        
        public Image GetThumbImage(AnalyseRecord record)
        {
            Image imgRet = null;

            if (record != null)
            {
                if (record.ThumbImg != null)
                {
                    // 不要与图片控件用同一个图片对象
                    // 图片控件上的图片可以自己回收
                    imgRet = record.ThumbImg.Clone() as Image;
                }
                else
                {
                    // string fileName = m_FileAccess.GetFileName(record.PicId);
                    try
                    {
                        //Image img = WinFormAppUtil.Common.Utils.GetImage(record.PicPath);
                        //record.ThumbImg = WinFormAppUtil.Common.Utils.CutImage(img, record.VehicleRegion);
                        record.ThumbImg = Framework.Container.Instance.TaskManager.GetThumbImg(record);
                        //record.PlateImg = Framework.Container.Instance.TaskManager.GetPlateImg(record);
                    }
                    catch (Exception ex)
                    {
                        MyLog4Net.Container.Instance.Log.Error(string.Format("获取图片 {0} 出错", record.PicPath), ex);
                    }
                    if (record.ThumbImg != null)
                    {
                        imgRet = record.ThumbImg.Clone() as Image;
                        Framework.Container.Instance.CacheManager.Register(record);
                    }
                }
            }

            return imgRet;
        }


        public void TurnPrePage()
        {
            m_DTAnalyseResults.Clear();
            HasResult = false;
            m_ResultPageInfo.TurnPrePage();
        }

        public void TurnNextPage()
        {
            m_DTAnalyseResults.Clear();
            HasResult = false;
            m_ResultPageInfo.TurnNextPage();
        }

        private ImageFormat GetImageFormat(string fileName)
        {
            ImageFormat format = ImageFormat.Jpeg;
            
            string extension = Path.GetExtension(fileName);

            if (string.Compare(extension, "bmp", true) == 0)
            {
                format = ImageFormat.Bmp;
            }
            else if (string.Compare(extension, "png", true) == 0)
            {
                format = ImageFormat.Png;
            }

            return format;
        }

        private void CopyImages(List<AnalyseRecord> records, string fullPath)
        {
            string fileName;
            Image image;

            float progressPerFile = 0.6f / (float)records.Count;
            int i = 0;
            foreach (AnalyseRecord record in records)
            {
                i++;
                if (record != null)
                {
                    m_StatusDlg.UpdateStatusText(string.Format("保存图片 {0} ...", record.PicPath));
                    m_StatusDlg.UpdateProgress(0.4f + progressPerFile * i);
                    try
                    {
                        fileName = Path.GetFileName(record.PicPath);
                        fileName = Path.Combine(fullPath, fileName);

                        image = AppUtil.Common.Utils.GetImage(record.PicPath, Framework.Environment.URLEncodingType);
                        CopyImage(image, fileName);
                    }
                    catch (Exception ex)
                    {
                        MyLog4Net.Container.Instance.Log.Error(string.Format("导出文件 {0} 出错", record.PicPath), ex);
                    }
                }
            }
        }

        private void CopyImage(Image imgSrc, string fileNameDes)
        {
            if (imgSrc != null)
            {
                Image imgDes = new Bitmap(imgSrc.Width, imgSrc.Height, imgSrc.PixelFormat);
                Graphics g = Graphics.FromImage(imgDes);
                g.DrawImage(imgSrc, new Point(0, 0));
                g.Dispose();
                ImageFormat format = GetImageFormat(fileNameDes);
                imgDes.Save(fileNameDes, format);
                imgSrc.Dispose();
                imgDes.Dispose();
            }
        }

        public void ExportCurrentGroup(List<AnalyseRecord> records ,string fileName)
        {
            m_StatusDlg = new ProgressFormStandalone("导出本组记录", "获取本组结果记录 ...");
                m_StatusDlg.Show();
            try
            {

                    string fullPath = fileName;

                    m_StatusDlg.UpdateProgress(0.2f);
                    m_StatusDlg.UpdateStatusText("开始导出图片 ...");

                    CopyImages(records, fullPath);
                    m_StatusDlg.Close();

                Framework.Container.Instance.EvtAggregator.GetEvent<AnalyseMessageEvent>().Publish(
                    new Tuple<uint, string>(10, string.Format("导出本组记录到 {0} 成功", fileName)));

                Framework.Container.Instance.InteractionService.ShowMessageBox("导出本组记录成功");
            }
            finally
            {
                    m_StatusDlg.Close();
            }

        }

        public void ExportAll(string fileName)
        {
            m_StatusDlg = new ProgressFormStandalone("导出全部记录", "获取全部结果记录 ...");
            m_StatusDlg.Show();

            List<AnalyseRecord> records = this.m_Records;

            m_StatusDlg.UpdateProgress(0.3f);

            if (records != null && records.Count > 0)
            {
                string fullPath = fileName;

                m_StatusDlg.UpdateProgress(0.4f);
                m_StatusDlg.UpdateStatusText("开始导出图片 ...");
                CopyImages(records, fullPath);
            }

            m_StatusDlg.Close();
        }

        #endregion

        #region Private helper functions
        
        private void InitTable()
        {
            m_DTAnalyseResults = new  List<List<AnalyseRecord>>();
            m_DTAnalyseResults.Sort((it1, it2) => it1.Count.CompareTo(it2.Count));

        }

        public void OnSearchFinished(List<AnalyseRecord> records)
        {
            if (PreNewSearch != null)
            {
                PreNewSearch(null, null);
            }

            if (m_ResultPageInfo != null)
            {
                m_ResultPageInfo.SelectedPageNumberChanged -= new EventHandler(ResultPageInfo_SelectedPageNumberChanged);
            }
            m_DTAnalyseResults.Clear();

            if (records != null && records.Count > 0)
            {
                m_Records = records;
                m_GroupRecords = records.GroupBy(id => id.PlateNumber).ToDictionary(group => group.Key,group=>group.ToList());
                m_GroupRecords = m_GroupRecords.OrderByDescending(o1=> o1.Value.Max(it1 => it1.Score)).ThenByDescending(o2=>o2.Value.Max(it2=>it2.CompareSimilarity)).ToDictionary(r => r.Key, v => v.Value);
                m_ResultPageInfo = new DataModel.PageInfo(24, m_GroupRecords.Count, 0);
                
                m_ResultPageInfo.SelectedPageNumberChanged += new EventHandler(ResultPageInfo_SelectedPageNumberChanged);
                foreach (List<AnalyseRecord> record in m_GroupRecords.Values.ToList().GetRange(0, Math.Min(24, m_GroupRecords.Count)))
                {
                    m_DTAnalyseResults.Add( record);
                }
                HasResult = true;
            }
            else
            {
                m_Records = null;
                m_ResultPageInfo = new DataModel.PageInfo(24, 0, 0);
            }

            if (SearchResult != null)
            {
                SearchResult(true, EventArgs.Empty);
            }

        }
        #endregion

        #region Event handlers

        void ResultPageInfo_SelectedPageNumberChanged(object sender, EventArgs e)
        {
            m_DTAnalyseResults.Clear();
            //if (m_isCompareSearch)
            //m_Records = Framework.Container.Instance.TaskManager.SwitchComparePage(m_SQLQuery, m_ResultPageInfo,new SearchPara());
            //else
            //m_Records = Framework.Container.Instance.TaskManager.SwitchPage(m_SQLQuery, m_ResultPageInfo);
            int startindex = Math.Min(m_GroupRecords.Count, m_ResultPageInfo.PageIndex * 24);
            int count = Math.Min(24, m_GroupRecords.Count - startindex);
            if (m_GroupRecords != null && m_GroupRecords.Count > 0)
            {
                foreach (List<AnalyseRecord> record in m_GroupRecords.Values.ToList().GetRange(startindex, count))
                {
                    m_DTAnalyseResults.Add( record);
                }
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
