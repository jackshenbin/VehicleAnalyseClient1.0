using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Xml;
using Bocom.ImageAnalysisClient.DataModel;
// using BOCOM.DataModel;

namespace Bocom.ImageAnalysisClient.App.Views
{
    public partial class FormCarStyle : DevExpress.XtraEditors.XtraForm
    {
        private Image image;
        
        public Image SelectImage
        {
            set 
            {
                if (value != null && value.Tag != null && value.Tag.ToString() == "-1")
                {
                    galleryControl1.Gallery.Groups[0].Items[0].Checked = true;
                    image = galleryControl1.Gallery.Groups[0].Items[0].Image;
                }
                else
                {
                    if (value == null || value.Tag == null)
                    {
                        galleryControl1.Gallery.Groups[0].Items[0].Checked = true;
                        image = galleryControl1.Gallery.Groups[0].Items[0].Image;
                        return;
                    }

                    foreach (DevExpress.XtraBars.Ribbon.GalleryItem Item in galleryControl1.Gallery.Groups[0].Items)
                    {
                        if (Item.Image != null && Item.Image.Tag !=null && value != null && value.Tag != null)
                        {
                            if (Item.Image.Tag.ToString() == value.Tag.ToString())
                            {
                                Item.Checked = true;
                                image = Item.Image;
                            }
                        }
                    }
                }
            }
            get { return image; }
        }
        
        public FormCarStyle()
        {
            InitializeComponent();
            galleryControl1.Gallery.Groups[0].Items[0].Image = Properties.Resources._1565_QuestionMarkBlue;
            galleryControl1.Gallery.Groups[0].Items[0].Image.Tag = null;

        }

        public void Init()
        {
            VehicleBrandInfo[] brandInfos = Framework.Container.Instance.VehicleInfoService.GetAllBrandInfos();
            if (brandInfos != null)
            {
                foreach (VehicleBrandInfo brandInfo in brandInfos)
                {
                    DevExpress.XtraBars.Ribbon.GalleryItem galleryItem2 = new DevExpress.XtraBars.Ribbon.GalleryItem();
                    galleryItem2.Caption = brandInfo.Name ;
                    Image itemImage = imageCollection1.Images[brandInfo.ImageName];
                    if (itemImage != null)
                    {
                        galleryItem2.Image = itemImage;// Image.FromFile(f.FullName);
                    }
                    else
                    {
                        galleryItem2.Image = new Bitmap(48, 48);
                    }
                    galleryItem2.Image.Tag = brandInfo;
                    galleryControl1.Gallery.Groups[0].Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[] {
                galleryItem2});
                }
            }
        }

        private void galleryControlGallery1_ItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            e.Item.Checked = true;
            image = e.Item.Image;
        }
        
        private void XtraFormCarStyle_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;

        }

        private void galleryControl1_Gallery_ItemDoubleClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            e.Item.Checked = true;

            image = e.Item.Image;
            DialogResult = System.Windows.Forms.DialogResult.OK;

        }
    }
}