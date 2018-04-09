using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using com.VehicleAnalyse.DataModel;
using com.VehicleAnalyse.Main.ViewModels;

namespace com.VehicleAnalyse.Main.Views
{
    public partial class ucResultImage : DevExpress.XtraEditors.XtraUserControl
    {
        private AnalyseRecord m_Record;

        public ucResultImage()
        {
            InitializeComponent();
        }

        public void ShowImage(AnalyseRecord record)
        {
            m_Record = record;
            ShowFullImage(m_Record);
            ShowDriverImages(m_Record);
        }

        public void Reset()
        {
            if (!Framework.Environment.ShowPeopleImg &&
                !this.Controls.Contains(picEditOriginal))
            {
                this.splitContainerControl1.Panel1.Controls.Clear();
                this.Controls.Clear();
                this.Controls.Add(picEditOriginal);
                // this.splitContainerControl1.Panel2.Visible = false;
            }
            picEditOriginal.Image = picEditDriver.Image = picEditCoDriver.Image = null;
        }

        private void ShowDriverImages(AnalyseRecord record)
        {
            if (Framework.Environment.ShowPeopleImg)
            {
                ShowDriverImage(picEditDriver, record, record.DriverRegion);
                ShowDriverImage(picEditCoDriver, record, record.CoDriverRegion);
            }
        }

        private void ShowDriverImage(PictureEdit picEdit, AnalyseRecord record, Rectangle region)
        {
            Image image = null;

            if (picEdit.Image != null)
            {
                Image imageTmp = picEdit.Image;
                picEdit.Image = null;
                imageTmp.Dispose();
            }

            if (record != null && record.Image != null)
            {
                if (record.ErrorCode == 0 && !region.Equals(Rectangle.Empty))
                {
                    image = ClipImage(record.Image, region);
                }
            }

            picEdit.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            picEdit.Image = image;
        }

        private Image ClipImage(Image image, Rectangle region)
        {

            int xOffset1 = 10, xOffset2 = 10, yOffset1 = 10, yOffset2 = 10;
            if (region.X < 10)
            {
                xOffset1 = region.X;
            }
            if (region.Y < 10)
            {
                yOffset1 = region.Y;
            }

            int temp = image.Width - region.X - region.Width;
            if (temp < 10)
            {
                xOffset2 = temp;
            }

            temp = image.Height - region.Y - region.Height;
            if (temp < 10)
            {
                yOffset2 = temp;
            }

            int Height = region.Height + yOffset1 + yOffset2;
            int Width = region.Width + xOffset1 + xOffset2;
            if (Height <= 0 || Width <= 0)
                return new Bitmap(1, 1);

            Rectangle rect = new Rectangle(region.X - xOffset1, region.Y - yOffset1, Width, Height);

            Bitmap imgClip = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(imgClip);
            g.DrawImage(image, new Rectangle(0, 0, Width, Height), rect, GraphicsUnit.Pixel);
            g.Dispose();

            return imgClip;
        }

        private void ShowFullImage(AnalyseRecord record)
        {
            Image imgFull = null;
            if (picEditOriginal.Image != null)
            {
                Image image = picEditOriginal.Image;
                picEditOriginal.Image = null;
                image.Dispose();
            }
            if (record != null && record.Image != null)
            {
                // 不要与图片控件用同一个图片对象
                // 图片控件上的图片可以自己回收
                imgFull = ResultPageViewModel.DecorateFullImage(record);
            }
            picEditOriginal.Image = imgFull;
            picEditOriginal.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Clip;
            if (imgFull != null)
            {
                int x_rate = picEditOriginal.Width * 100 / imgFull.Width;
                int y_rate = picEditOriginal.Height * 100 / imgFull.Height;
                picEditOriginal.Properties.ZoomPercent = Math.Min(x_rate, y_rate);
            }
        }
        
        internal void ZoomIn()
        {
            picEditOriginal.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Clip;
            // ZoomRate = Math.Min((int)(picEditOriginal.Properties.ZoomPercent * 1.2), 1000);
            picEditOriginal.Properties.ZoomPercent = Math.Min((int)(picEditOriginal.Properties.ZoomPercent * 1.2), 1000); ;
        }

        internal void ZoomOut()
        {
            picEditOriginal.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Clip;
            // ZoomRate = Math.Max((int)(picEditOriginal.Properties.ZoomPercent / 1.2), 5);
            picEditOriginal.Properties.ZoomPercent = Math.Max((int)(picEditOriginal.Properties.ZoomPercent / 1.2), 5);
        }

        void picEditOriginal_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
                ZoomIn();
            else
                ZoomOut();
        }
        
    }
}
