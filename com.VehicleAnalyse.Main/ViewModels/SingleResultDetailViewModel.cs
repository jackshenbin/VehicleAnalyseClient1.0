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
    public class SingleResultDetailViewModel  : ViewModelBase
    {
        #region Fields
        private List<AnalyseRecord> m_Records;
        ProgressFormStandalone m_StatusDlg;
        #endregion

        #region Properties

        public List<AnalyseRecord> AnalyseResults { get { return m_Records; } set { m_Records = value; } }

        #endregion

        #region Constructors

        public SingleResultDetailViewModel()
        {
        }

        #endregion

        #region Public helper functions
        
        public Image GetImage(AnalyseRecord record)
        {
            Image imgRet = null;

            if (record != null)
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
                    try
                    {
                        //record.Image = m_FileAccess.GetImage(record.PicPath);
                        record.Image = AppUtil.Common.Utils.GetImage(record.PicPath,Framework.Environment.URLEncodingType);
                    }
                    catch (Exception ex)
                    {
                        MyLog4Net.Container.Instance.Log.Error(string.Format("获取图片 {0} 出错", record.PicPath), ex);
                    }
                    if (record.Image != null)
                    {
                        imgRet = record.Image.Clone() as Image;
                        Framework.Container.Instance.CacheManager.Register(record);
                    }
                }
            }

            return imgRet;
        }

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


        

        internal AnalyseRecord GetVehicleByID(string vehicleid)
        {
            if (m_Records != null && m_Records.Count > 0)
            {
                return m_Records.Find(it => it.Id == vehicleid);
            }
            else
                return null;
        }

        internal AnalyseRecord GetNextVehicleByID(string vehicleid)
        {
            if (m_Records != null && m_Records.Count > 0)
            {
                int id = m_Records.FindIndex(it => it.Id == vehicleid);
                if (id + 1 < m_Records.Count)
                    return m_Records[id + 1];
                else
                    return null;
            }
            else
                return null;
        }

        internal AnalyseRecord GetPrivVehicleByID(string vehicleid)
        {
            if (m_Records != null && m_Records.Count > 0)
            {
                int id = m_Records.FindIndex(it => it.Id == vehicleid);
                if (id > 0)
                    return m_Records[id - 1];
                else
                    return null;
            }
            else
                return null;
        }

        internal bool IsCanNext(string vehicleid)
        {
            if (m_Records != null && m_Records.Count > 0)
            {
                int id = m_Records.FindIndex(it => it.Id == vehicleid);
                return (id + 1 < m_Records.Count);
            }
            else
                return false;
        }

        internal bool IsCanPriv(string vehicleid)
        {
            if (m_Records != null && m_Records.Count > 0)
            {
                int id = m_Records.FindIndex(it => it.Id == vehicleid);
                return (id > 0);
            }
            else
                return false;
        }

        #endregion

        #region Private helper functions
        

        #endregion

        #region Event handlers


        #endregion

    }
}
