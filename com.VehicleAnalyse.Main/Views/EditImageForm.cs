using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading;
using System.Reflection;

using AForge.Imaging.Filters;
using System.Diagnostics;

using System.IO;
using com.VehicleAnalyse.DataModel;
using com.VehicleAnalyse.Main.ViewModels;
using com.VehicleAnalyse.Service.DAO;


namespace com.VehicleAnalyse.Main.Views
{
    public partial class EditImageForm : DevExpress.XtraEditors.XtraForm
    {
        #region Fields

        private List<AnalyseRecord> m_Records;

        private int m_GammaValue = 0;
        private int m_ContrastValue = 0;

        // 当前的图片
        private Image m_CurImage = null;

        private ViewResultImageViewModel m_VM;

        private FileAccessBase m_FileAccess;

        //private SearchResultSingleViewModel m_VM;

        //private SearchResultSingleSummary m_resultSummary;

        #endregion

        #region Properties

        public AnalyseRecord CurrentRecord
        {
            get
            {
                return null;
            }
        }

        #endregion

        #region Constructors

        public EditImageForm()
        {
            InitializeComponent();
        }

        public EditImageForm(FileAccessBase fileAccess, List<AnalyseRecord> vm, int index)
            : this()
        {
            m_FileAccess = fileAccess;
            m_Records = vm;

            m_VM = new ViewResultImageViewModel(m_Records, index);

            this.ucEditImageCtrl.Init(m_VM);

            this.ucEditImageCtrl.ZoomRateChanged += new EventHandler(ucEditImageCtrl_ZoomRateChanged);
            this.m_VM.PageInfo.SelectedPageNumberChanged += new EventHandler(DetailViewPageInfo_SelectedPageNumberChanged);

            //  暂时注释掉, 因为现在的机制需要换掉  SearchResultSingleViewModel
            Framework.Container.Instance.VVMDataBindings.AddBinding(this.btnNext,
             "Enabled", m_VM.PageInfo, "CanNextPage");

            Framework.Container.Instance.VVMDataBindings.AddBinding(this.btnPrevious,
             "Enabled", m_VM.PageInfo, "CanPrePage");

            //Framework.Container.Instance.VVMDataBindings.AddBinding(this.btnNext,
            // "Enabled", m_VM.DetailViewPageInfo, "CanNextPage");

            //Framework.Container.Instance.VVMDataBindings.AddBinding(this.btnPrevious,
            // "Enabled", m_VM.DetailViewPageInfo, "CanPrePage");

            Framework.Container.Instance.VVMDataBindings.AddBinding(this.lblCtrlPageNumber,
             "Text", m_VM.PageInfo, "DisplayIndex");

            Framework.Container.Instance.VVMDataBindings.AddBinding(this.lblCtrlPageCount,
             "Text", m_VM.PageInfo, "PageCount");

            ucEditImageCtrl.SplitPositionChanged += new Action<int>(ucEditImageCtrl_SplitPositionChanged);
        }


        #endregion

        #region Private & internal helper functions

        internal void ClearImage()
        {
            this.ucEditImageCtrl.ClearImage();
            this.btnNext.Enabled = this.btnNextPage.Enabled = this.btnPrePage.Enabled = this.btnPrevious.Enabled = false;
            this.btnAutoFit.Enabled = this.btnZoomIn.Enabled = this.btnZoomOut.Enabled = this.btnOriginal.Enabled 
                = this.dropDownButton1.Enabled = this.btnSave.Enabled = false;
        }

        internal void Reset()
        {
            //ucEditImageCtrl.ClearThumbImage(true);
            //ucEditImageCtrl.ClearOriginalImage(true);

            //if (m_resultSummary != summary)
            //{
            //    //  UnRegisterSearchEventHandler(m_resultSummary);
            //    m_resultSummary = summary;
            //    // RegisterSearchEventHandler(m_resultSummary);
            //}
            //m_Records = summary.SearchResultList;
        }

        private void UpdateCtrlStatus(bool enabled)
        {
            this.btnPrevious.Enabled = this.btnNext.Enabled = true;

            this.btnAutoFit.Enabled = this.btnZoomIn.Enabled = this.btnZoomOut.Enabled = this.btnOriginal.Enabled
                = this.dropDownButton1.Enabled = this.btnSave.Enabled = enabled;

            //this.btnPrePage.Enabled = this.m_resultSummary.CurrentPageInfo.nPageNumber > 1;
            //this.btnNextPage.Enabled = this.m_resultSummary.CurrentPageInfo.nPageNumber < this.m_resultSummary.CurrentPageInfo.nPageCount;
        }

        private void UnRegisterSearchEventHandler()
        {
            //summary.ResultRecordsUpdated -= new EventHandler(m_resultSummary_ResultRecordsUpdated);
            //summary.SearchPara.Disposing -= new EventHandler(SearchPara_Disposing);
            //if (summary.SearchPara.IsMixed)
            //{
            //    summary.ImageUpdated -= new EventHandler(m_resultSummary_ImageUpdated);
            //}
        }

        //private List<Tuple<PropertyInfo, string>> GetProperties()
        //{
        //    List<Tuple<PropertyInfo, string>> psRet = new List<Tuple<PropertyInfo, string>>();

        //    PropertyInfo[] properties = record.GetType().GetProperties();

        //    if (properties != null && properties.Length > 0)
        //    {
        //        string description;
        //        foreach (PropertyInfo p in properties)
        //        {
        //            object[] objs = p.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
        //            if (objs != null && objs.Length > 0)
        //            {
        //                description = ((DescriptionAttribute)objs[0]).Description;
        //                //if (string.CompareOrdinal(description, "相似度") == 0 && !m_resultSummary.SearchPara.IsSupportSimilarRate)
        //                //{
        //                //    continue;
        //                //}
        //                psRet.Add(new Tuple<PropertyInfo, string>(p, description));
        //            }
        //        }
        //    }
        //    return psRet;
        //}

        //private void RetrieveAndShowImage()
        //{
        //    try
        //    {
        //        SearchResultRecord record = m_Records[m_VM.DetailViewPageInfo.Index];
        //        this.ucEditImageCtrl.SwitchRecord(m_resultSummary, record);

        //        bool hasOriginalImage = (record.OriginalPic != null);
        //        UpdateCtrlStatus(hasOriginalImage);
        //        if (hasOriginalImage)
        //        {
        //            this.ucEditImageCtrl.ShowOriginalImage();
        //        }
        //        else
        //        {
        //            m_VM.StartRequestImage(record, true);
        //        }
        //    }
        //    catch (IndexOutOfRangeException ex)
        //    {
        //        SDKCallExceptionHandler.Handle(ex, "大图编辑对话框切换记录", false);
        //    }
        //    catch (ArgumentOutOfRangeException ex)
        //    {

        //    }
        //}

        //private void UpdateCircularPosition(CircularProgress circular)
        //{
        //    int x = circular.Parent.Width / 2;
        //    int y = circular.Parent.Height / 2;
        //    circular.Location = new System.Drawing.Point(x - circular.Width / 2, y - circular.Height / 2);
        //}

        //private void ShowCirularProgress(CircularProgress circular, PictureEdit picEdit, bool show)
        //{
        //    UpdateCircularPosition(circular);
        //    circular.Visible = show;
        //    circular.IsRunning = show;
        //    picEdit.Visible = !show;
        //    if (show)
        //    {
        //        circular.Parent.BackColor = picEdit.BackColor;
        //        circular.BringToFront();
        //    }
        //}

        //private SearchResultRecord RetrieveImage(SearchResultRecord record)
        //{
        //    // record.RetrieveImage();
        //    return record;
        //}

        #endregion

        #region 图片处理

        /// <summary>
        /// 图像明暗调整
        /// </summary>
        /// <param name="b">原始图</param>
        /// <param name="degree">亮度[-255, 255]</param>
        /// <returns></returns>
        public static Bitmap KiLighten(Bitmap b, int degree)
        {
            if (b == null)
            {
                return null;
            }

            if (degree < -255) degree = -255;
            if (degree > 255) degree = 255;

            try
            {

                int width = b.Width;
                int height = b.Height;

                int pix = 0;

                BitmapData data = b.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

                unsafe
                {
                    byte* p = (byte*)data.Scan0;
                    int offset = data.Stride - width * 3;
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            // 处理指定位置像素的亮度
                            for (int i = 0; i < 3; i++)
                            {
                                pix = p[i] + degree;

                                if (degree < 0) p[i] = (byte)Math.Max(0, pix);
                                if (degree > 0) p[i] = (byte)Math.Min(255, pix);

                            } // i
                            p += 3;
                        } // x
                        p += offset;
                    } // y
                }

                b.UnlockBits(data);

                return b;
            }
            catch
            {
                return null;
            }

        } // end of Lighten

        /// <summary>
        /// 图像对比度调整
        /// </summary>
        /// <param name="b">原始图</param>
        /// <param name="degree">对比度[-100, 100]</param>
        /// <returns></returns>
        public static Bitmap KiContrast(Bitmap b, int degree)
        {
            if (b == null)
            {
                return null;
            }

            if (degree < -100) degree = -100;
            if (degree > 100) degree = 100;

            try
            {

                double pixel = 0;
                double contrast = (100.0 + degree) / 100.0;
                contrast *= contrast;
                int width = b.Width;
                int height = b.Height;
                BitmapData data = b.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                unsafe
                {
                    byte* p = (byte*)data.Scan0;
                    int offset = data.Stride - width * 3;
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            // 处理指定位置像素的对比度
                            for (int i = 0; i < 3; i++)
                            {
                                pixel = ((p[i] / 255.0 - 0.5) * contrast + 0.5) * 255;
                                if (pixel < 0) pixel = 0;
                                if (pixel > 255) pixel = 255;
                                p[i] = (byte)pixel;
                            } // i
                            p += 3;
                        } // x
                        p += offset;
                    } // y
                }
                b.UnlockBits(data);
                return b;
            }
            catch
            {
                return null;
            }
        }

        public static void ThreadMethodSharpenning(object parObj)
        {
            //EditImageForm form = (EditImageForm)parObj;
            //int Height = form.pictureEdit1.Image.Height;
            //int Width = form.pictureEdit1.Image.Width;
            //Bitmap newBitmap = new Bitmap(Width, Height);
            //Bitmap oldBitmap = (Bitmap)form.pictureEdit1.Image;
            //Color pixel;
            ////拉普拉斯模板
            //int[] Laplacian = { -1, -1, -1, -1, 9, -1, -1, -1, -1 };
            //for (int x = 1; x < Width - 1; x++)
            //    for (int y = 1; y < Height - 1; y++)
            //    {
            //        int r = 0, g = 0, b = 0;
            //        int Index = 0;
            //        for (int col = -1; col <= 1; col++)
            //            for (int row = -1; row <= 1; row++)
            //            {
            //                pixel = oldBitmap.GetPixel(x + row, y + col); r += pixel.R * Laplacian[Index];
            //                g += pixel.G * Laplacian[Index];
            //                b += pixel.B * Laplacian[Index];
            //                Index++;
            //            }
            //        //处理颜色值溢出
            //        r = r > 255 ? 255 : r;
            //        r = r < 0 ? 0 : r;
            //        g = g > 255 ? 255 : g;
            //        g = g < 0 ? 0 : g;
            //        b = b > 255 ? 255 : b;
            //        b = b < 0 ? 0 : b;
            //        newBitmap.SetPixel(x - 1, y - 1, Color.FromArgb(r, g, b));
            //    }

            //form.FlushFuction(newBitmap);
        }

        private void FlushFuction(Image oj)
        {
            //if (this.InvokeRequired)
            //{
            //    FlushClient fc = new FlushClient(FlushFuction);
            //    object[] paras = { oj };
            //    try
            //    {
            //        this.Invoke(fc, paras);
            //    }
            //    catch (Exception ex)
            //    {
            //        Framework.Container.Instance.Log.Error("Invoke or BeginInvoke error: ", ex);
            //        Debug.Assert(false, ex.Message);
            //    }
            //}
            //else
            //{
            //    this.pictureEdit1.Image = oj;
            //    if (dlg != null)
            //    {
            //        dlg.Close();
            //    }
            //}
        }

        private delegate void FlushClient(Image oj);

        ParameterizedThreadStart parStartSharpenning = new ParameterizedThreadStart(ThreadMethodSharpenning);
        // ProgressDialog dlg = null;

        private void Sharpen()
        {
            IFilter filter = new Sharpen();
            Bitmap imgOri = this.ucEditImageCtrl.OriginalImage as Bitmap;
            if (imgOri != null)
            {
                try
                {
                    Image img = filter.Apply(imgOri);
                    this.ucEditImageCtrl.OriginalImage = m_CurImage = img;
                }
                catch (Exception ex)
                {
                    // MyLog4Net.Container.Instance.Log.Error("Sharpen error: ", ex);
                    //XtraMessageBox.Show("锐化出错!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.ucEditImageCtrl.OriginalImage = imgOri;
                }
            }
        }

        #endregion

        #region Event handlers

        void ucEditImageCtrl_SplitPositionChanged(int obj)
        {
            this.flowLayoutPanel1.Anchor = AnchorStyles.None;
            this.flowLayoutPanel1.Left = obj;
            this.flowLayoutPanel1.Anchor = AnchorStyles.Left | AnchorStyles.Top;
        }

        void DetailViewPageInfo_SelectedPageNumberChanged(object sender, EventArgs e)
        {
            // Image img = Image.FromFile(m_Records[m_VM.PageInfo.Index].PicId);
            ucEditImageCtrl.ShowImage( m_Records[m_VM.PageInfo.PageIndex]);
        }

        private void EditImageForm_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                ucEditImageCtrl.ShowImage( m_Records[m_VM.PageInfo.PageIndex]);
            }
        }

        //void VM_OriginalImageRetrieved(SearchResultRecord obj)
        //{
        //    if (CurrentRecord == obj)
        //    {
        //        UpdateCtrlStatus(CurrentRecord.OriginalPic != null);
        //        ucEditImageCtrl.ShowOriginalImage();
        //        ucEditImageCtrl.ShowImage();
        //    }
        //}

        //private void VM_ThumbNailImageRetrieved(SearchResultRecord obj)
        //{
        //    if (CurrentRecord == obj)
        //    {
        //        ucEditImageCtrl.ShowThumbImage(false);
        //    }
        //}

        private void EditImageForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.ucEditImageCtrl.ThumbImage = null;
            //this.ucEditImageCtrl.OriginalImage = null;

            // m_taskRunnerRetrieveImage.Stop();
            // UnRegisterSearchEventHandler(this.m_resultSummary);
        }

        private void EditImageForm_Shown(object sender, EventArgs e)
        {

        }
        #endregion

        #region 翻页事件处理

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            ucEditImageCtrl.ClearImage();
            m_VM.PageInfo.TurnPrePage();
            m_ContrastValue = m_GammaValue = 0;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            ucEditImageCtrl.ClearImage();
            m_VM.PageInfo.TurnNextPage();
            m_ContrastValue = m_GammaValue = 0;
        }

        private void btnPrePage_Click(object sender, EventArgs e)
        {
            this.ucEditImageCtrl.ClearImage();
            // m_VM.ResultPageInfo.TurnPrePage();
            m_ContrastValue = m_GammaValue = 0;
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            this.ucEditImageCtrl.ClearImage();
            // m_VM.ResultPageInfo.TurnNextPage();
            m_ContrastValue = m_GammaValue = 0;
        }

        #endregion

        #region 图片操作事件处理

        private void btnOriginal_Click(object sender, EventArgs e)
        {
            this.ucEditImageCtrl.Original();

        }

        private void btnAutoFit_Click(object sender, EventArgs e)
        {
            this.ucEditImageCtrl.AutoFit();
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            this.ucEditImageCtrl.ZoomIn();
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            this.ucEditImageCtrl.ZoomOut();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AnalyseRecord record = CurrentRecord;

            //if (record == null || record.OriginalPic == null)
            //{
            //    return;
            //}

            string resourcename = "";
            string time = "";
            foreach (Tuple<PropertyInfo, string> p in this.ucEditImageCtrl.Properties)
            {
                object obj = p.Item1.GetValue(record, null);

                if (p.Item2 == "所属源")
                    resourcename = obj.ToString();

                if (p.Item2 == "目标时间")
                    time = obj.ToString();
            }
            string FileName = resourcename.Replace(".", "_") + "结果" + time.Replace(":", "_").Replace(".", "_").Replace("/", "_") + ".jpg";
            //if ((Program.PRODUCT_TYPE & Framework.Environment.E_PRODUCT_TYPE.SH_PRODUCT) > 0)
            //{
            //    //#if SHANGHAIPRODUCT
            //    FileName = BOCOM.IVX.Framework.Environment.PictureSavePath + @"\" + FileName;
            //    //#else
            //}
            //else
            //{
            //    SaveFileDialog sfd = new SaveFileDialog();
            //    sfd.RestoreDirectory = true;

            //    sfd.Filter = "JPG文件|*.jpg";
            //    sfd.FileName = FileName;
            //    sfd.InitialDirectory = BOCOM.IVX.Framework.Environment.PictureSavePath;
            //    if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //    {
            //        FileName = sfd.FileName;
            //    }
            //    else
            //    {
            //        return;
            //    }
            //    //#endif
            //}

            // 保存文件
            Trace.WriteLine("btnSave_Click, FileName:" + FileName);
            Bitmap pic = new Bitmap(this.ucEditImageCtrl.OriginalImage.Width, this.ucEditImageCtrl.OriginalImage.Height);
            Graphics g = Graphics.FromImage(pic);
            g.DrawImage(this.ucEditImageCtrl.OriginalImage, 0, 0,
                ucEditImageCtrl.OriginalImage.Width, ucEditImageCtrl.OriginalImage.Height);

            pic.Save(FileName, ImageFormat.Jpeg);
            pic.Dispose();

            System.IO.FileInfo temp = new System.IO.FileInfo(FileName);
            int hrItem = (int)DateTime.Now.Ticks;
            //BOCOM.IVX.Framework.Container.Instance.DownloadItemViewModel.UpdateProgress(new DownloadItemInfo
            //{
            //    hrItem = hrItem,
            //    srcVideoName = resourcename,
            //    dstName = temp.Name,
            //    progress = 0,
            //    downloadPath = temp.DirectoryName,
            //    type = DownloadType.结果图片
            //});
            // BOCOM.IVX.Framework.Container.Instance.DownloadItemViewModel.UpdateProgress(hrItem, 100);
        }

        void barBtnItemSharpen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Sharpen();
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //using (XtraFormGamma form = new XtraFormGamma(m_GammaValue, m_ContrastValue))
            //{
            //    form.ValueChanged += new XtraFormGamma.DelegateValueChanged(form_ValueChanged);
            //    if (DialogResult.OK == form.ShowDialog())
            //    {
            //        m_GammaValue = form.GammaValue;
            //        m_ContrastValue = form.ContrastValue;

            //        form.ValueChanged -= new XtraFormGamma.DelegateValueChanged(form_ValueChanged);
            //        if (form.Preview)
            //        {
            //            form_ValueChanged(m_GammaValue, m_ContrastValue);
            //        }
            //    }
            //}
        }

        void form_ValueChanged(int Gamma, int Contrast)
        {
            if (this.ucEditImageCtrl.OriginalImage == null)
            {
                return;
            }
            if (m_CurImage == null)
            {
                m_CurImage = (Image)this.ucEditImageCtrl.OriginalImage.Clone();
                return;
            }
            this.ucEditImageCtrl.OriginalImage = (Image)m_CurImage.Clone();

            Bitmap bt = (Bitmap)this.ucEditImageCtrl.OriginalImage;
            // 按比例计算

            KiContrast(bt, Contrast);
            KiLighten(bt, Gamma);

            // this.pictureEdit1.Refresh();
        }

        void ucEditImageCtrl_ZoomRateChanged(object sender, EventArgs e)
        {
            this.txtBoxZoomRate.Text = this.ucEditImageCtrl.ZoomRate.ToString();
        }

        private void btnPlayVideo_Click(object sender, EventArgs e)
        {
            //SearchResultRecord record = CurrentRecord;
            //if (record != null)
            //{
            //    Framework.Container.Instance.EvtAggregator.GetEvent<SearchResoultPlaybackRequestEvent>().Publish(
            //        new Tuple<SearchResultRecord, SearchType>(record, m_VM.SearchSession.SearchPara.SearchType));
            //}
        }

        #endregion

        private void btnGotoCompareSearch_Click(object sender, EventArgs e)
        {
            //SearchResultRecord record = CurrentRecord;
            //if (record != null && record.OriginalPic != null && record.ThumbNailPic != null)
            //{
            //    DataModel.ImageType it = ImageType.Common;
            //    if (record.ObjectType == SearchResultObjectType.CAR)
            //        it = ImageType.Car;
            //    else if (record.ObjectType == SearchResultObjectType.FACE)
            //        it = ImageType.Face;
            //    else
            //        it = ImageType.Object;

            //    Framework.Container.Instance.EvtAggregator.GetEvent<GotoCompareSearchEvent>().Publish("");
            //    CompareImageInfo info = new CompareImageInfo
            //    {
            //        Image = new Bitmap(this.ucEditImageCtrl.OriginalImage), // record.OriginalPic),
            //        RegionImage = new Bitmap(record.ThumbNailPic),
            //        ImageRectangle = record.ObjectRect,
            //        ImageType = it,
            //    };

            //    if (!Framework.Container.Instance.CacheMgr.HasItem(record))
            //    {
            //        record.Clear();
            //    }
            //    Framework.Container.Instance.EvtAggregator.GetEvent<SetCompareImageInfoEvent>().Publish(info);

            this.Close();
        }
    }
}
