using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Xml;
using VehicleHelper.DataModel;
using VehicleHelper.DAO;
using System.IO;
using System.Diagnostics;
using VehicleHelper;
// using com.VehicleAnalyse.DataModel;
// using BOCOM.DataModel;

namespace com.VehicleAnalyse.Main.Views
{
    public partial class FormCarStyle : DevExpress.XtraEditors.XtraForm
    {
        private Image image;
        private string ABC = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
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
            galleryControl1.Gallery.Groups[0].Items[0].Image = VehicleHelper.Properties.Resources._1565_questionmarkblue;
            galleryControl1.Gallery.Groups[0].Items[0].Image.Tag = null;
            foreach (char item in ABC.ToCharArray())
	        {
                DevExpress.XtraBars.Ribbon.GalleryItemGroup temp = new DevExpress.XtraBars.Ribbon.GalleryItemGroup();
                temp.Caption = item.ToString();
                
                galleryControl1.Gallery.Groups.Add(temp);


                LinkLabel linkLabel = new LinkLabel();
                linkLabel.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
                linkLabel.AutoSize = true;
                linkLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
                linkLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
                linkLabel.Location = new System.Drawing.Point(3, 3);
                linkLabel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
                linkLabel.Size = new System.Drawing.Size(16, 14);
                linkLabel.TabIndex = 0;
                linkLabel.TabStop = true;
                linkLabel.Text = item.ToString();
                linkLabel.Tag = item.ToString();
                
                linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);


                flowLayoutPanel1.Controls.Add(linkLabel);
	        }

        }

        //private void UpdatePics(VehicleBrandDAOService service, VehicleBrand brandInfo)
        //{
        //    if (!string.IsNullOrEmpty(brandInfo.BackPic))
        //    {
        //        if (brandInfo.Back == null)
        //        {
        //            string fileName = Path.Combine(System.Environment.CurrentDirectory, "车型", brandInfo.BackPic.Trim("\r\n\t".ToCharArray()));
        //            bool exist = File.Exists(fileName);
        //            // Debug.Assert(exist);
        //            if (exist)
        //            {
        //                Byte[] bytes = System.IO.File.ReadAllBytes(fileName);
        //                brandInfo.Back = bytes;
        //            }
        //            else
        //            {
        //                Debug.WriteLine(string.Format("Not exist image: {0}", brandInfo.BackPic));
        //            }
        //        }
        //    }
        //    if (!string.IsNullOrEmpty(brandInfo.FrontPic))
        //    {
        //        if (brandInfo.Front == null)
        //        {
        //            string fileName = Path.Combine(System.Environment.CurrentDirectory, "车型", brandInfo.FrontPic.Trim("\r\n\t".ToCharArray()));

        //            bool exist = File.Exists(fileName);
        //            // Debug.Assert(exist);
        //            if (exist)
        //            {
        //                Byte[] bytes = System.IO.File.ReadAllBytes(fileName);
        //                brandInfo.Front = bytes;
        //            }
        //            else
        //            {
        //                Debug.WriteLine(string.Format("Not exist image: {0}", brandInfo.FrontPic));
        //            }
        //        }
        //    }

        //    VehicleBrand[] childs = service.GetChildBrands((int)brandInfo.Id);
        //    if(childs != null && childs.Length > 0)
        //    {
        //        foreach(var child in childs)
        //        {
        //            UpdatePics(service, child);
        //        }
        //    }
        //}

        public void Init(bool showNoLogoBrand=false)
        {

            VehicleEnumService service = new VehicleEnumService();
            List<VehicleBrandInfo> brandInfos = service.VehicleBrandInfos;
            if (brandInfos != null)
            {
                brandInfos.Sort((it1, it2) => it1.Name.CompareTo(it2.Name));
                foreach (VehicleBrandInfo brandInfo in brandInfos)
                {
                    var py = AppUtil.Common.PinYinConverterHelp.GetTotalPingYin(brandInfo.Name).FirstPingYin;
                    int groupindex = 0;
                    if (py.Count > 0)
                    {
                        groupindex = ABC.IndexOf(py[0].Substring(0, 1).ToUpper()) + 1;
                        if (brandInfo.Name.StartsWith("广"))
                            groupindex = ABC.IndexOf("G") + 1;
                        if (brandInfo.Name.StartsWith("红"))
                            groupindex = ABC.IndexOf("H") + 1;
                        if (brandInfo.Name.StartsWith("奇"))
                            groupindex = ABC.IndexOf("Q") + 1;
                    }
                    // UpdatePics(service, brandInfo);

                    DevExpress.XtraBars.Ribbon.GalleryItem galleryItem2 = new DevExpress.XtraBars.Ribbon.GalleryItem();
                    galleryItem2.Caption = brandInfo.Name;
                    Image itemImage = null;
                    if(brandInfo.Logo != null)
                    {
                        itemImage = brandInfo.Logo;
                    }
                    else
                    {
                        //string fileName = string.Format(
                        //    @"I:\jim\Workingfolder\SVN(NEW)\VDA2.0\03src\VDAClient\VDA-Client(C#)发布\carstyle\{0}.png",
                        //    brandInfo.Name);
                        //if (File.Exists(fileName))
                        //{
                        //    Byte[] bytes = System.IO.File.ReadAllBytes(fileName);
                        //    brandInfo.Logo = bytes;
                            
                        //    System.IO.MemoryStream ms = new System.IO.MemoryStream(brandInfo.Logo);
                        //    itemImage = System.Drawing.Image.FromStream(ms);
                        //}
                        //else
                        //{
                        //    Debug.WriteLine(string.Format("### logo not exist: {0}", brandInfo.Name));
                        //}
                    }
                    if (itemImage != null)
                    {
                        galleryItem2.Image = itemImage;// Image.FromFile(f.FullName);
                    }
                    else
                    {
                        if (showNoLogoBrand)
                        {
                            galleryItem2.Image = new Bitmap(48, 48);
                        }
                        else
                        {
                            continue;
                        }
                    }
                    galleryItem2.Image.Tag = brandInfo;
                    galleryControl1.Gallery.Groups[groupindex].Items.Add(galleryItem2);
                }

            }

            //VehicleInfoService service = new VehicleInfoService();
            //VehicleBrandInfo[] brandInfos = service.GetAllBrandInfos();  
            //if (brandInfos != null)
            //{
            //    foreach (VehicleBrandInfo brandInfo in brandInfos)
            //    {
            //        DevExpress.XtraBars.Ribbon.GalleryItem galleryItem2 = new DevExpress.XtraBars.Ribbon.GalleryItem();
            //        galleryItem2.Caption = brandInfo.Name ;
            //        Image itemImage = imageCollection1.Images[brandInfo.ImageName];
            //        if (itemImage != null)
            //        {
            //            galleryItem2.Image = itemImage;// Image.FromFile(f.FullName);
            //        }
            //        else
            //        {
            //            galleryItem2.Image = new Bitmap(48, 48);
            //        }
            //        galleryItem2.Image.Tag = brandInfo;
            //        galleryControl1.Gallery.Groups[0].Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[] {
            //    galleryItem2});
            //    }
            //}
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel linkLabel = sender as LinkLabel;
            int groupindex = ABC.IndexOf(linkLabel.Text) + 1;
            galleryControl1.Gallery.ScrollTo(galleryControl1.Gallery.Groups[groupindex],false);
            
        }

        
    }
}