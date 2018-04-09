namespace Bocom.ImageAnalysisClient.App.Views
{
    partial class FormCarStyle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraBars.Ribbon.GalleryItemGroup galleryItemGroup1 = new DevExpress.XtraBars.Ribbon.GalleryItemGroup();
            DevExpress.XtraBars.Ribbon.GalleryItem galleryItem1 = new DevExpress.XtraBars.Ribbon.GalleryItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCarStyle));
            this.galleryControl1 = new DevExpress.XtraBars.Ribbon.GalleryControl();
            this.galleryControlClient1 = new DevExpress.XtraBars.Ribbon.GalleryControlClient();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.galleryControl1)).BeginInit();
            this.galleryControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // galleryControl1
            // 
            this.galleryControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.galleryControl1.Controls.Add(this.galleryControlClient1);
            this.galleryControl1.DesignGalleryGroupIndex = 0;
            this.galleryControl1.DesignGalleryItemIndex = 0;
            this.galleryControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // galleryControlGallery1
            // 
            this.galleryControl1.Gallery.Appearance.GroupCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.galleryControl1.Gallery.Appearance.GroupCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.galleryControl1.Gallery.Appearance.GroupCaption.Options.UseBackColor = true;
            this.galleryControl1.Gallery.Appearance.GroupCaption.Options.UseForeColor = true;
            this.galleryControl1.Gallery.Appearance.ItemCaptionAppearance.Hovered.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.galleryControl1.Gallery.Appearance.ItemCaptionAppearance.Hovered.Options.UseForeColor = true;
            this.galleryControl1.Gallery.Appearance.ItemCaptionAppearance.Normal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.galleryControl1.Gallery.Appearance.ItemCaptionAppearance.Normal.Options.UseForeColor = true;
            this.galleryControl1.Gallery.Appearance.ItemCaptionAppearance.Pressed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.galleryControl1.Gallery.Appearance.ItemCaptionAppearance.Pressed.Options.UseForeColor = true;
            this.galleryControl1.Gallery.Appearance.ItemDescriptionAppearance.Normal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.galleryControl1.Gallery.Appearance.ItemDescriptionAppearance.Normal.Options.UseForeColor = true;
            this.galleryControl1.Gallery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            galleryItemGroup1.Caption = "车标";
            galleryItem1.Caption = "不限";
            galleryItem1.Image = global::Bocom.ImageAnalysisClient.App.Properties.Resources._1565_QuestionMarkBlue;
            galleryItemGroup1.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[] {
            galleryItem1});
            this.galleryControl1.Gallery.Groups.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItemGroup[] {
            galleryItemGroup1});
            this.galleryControl1.Gallery.ImageSize = new System.Drawing.Size(48, 48);
            this.galleryControl1.Gallery.ItemCheckMode = DevExpress.XtraBars.Ribbon.Gallery.ItemCheckMode.SingleRadioInGroup;
            this.galleryControl1.Gallery.ItemImageLayout = DevExpress.Utils.Drawing.ImageLayoutMode.ZoomInside;
            this.galleryControl1.Gallery.ScrollSpeed = 3F;
            this.galleryControl1.Gallery.ShowItemText = true;
            this.galleryControl1.Gallery.ItemClick += new DevExpress.XtraBars.Ribbon.GalleryItemClickEventHandler(this.galleryControlGallery1_ItemClick);
            this.galleryControl1.Gallery.ItemDoubleClick += new DevExpress.XtraBars.Ribbon.GalleryItemClickEventHandler(this.galleryControl1_Gallery_ItemDoubleClick);
            this.galleryControl1.Location = new System.Drawing.Point(0, 0);
            this.galleryControl1.Name = "galleryControl1";
            this.galleryControl1.Size = new System.Drawing.Size(900, 500);
            this.galleryControl1.TabIndex = 0;
            this.galleryControl1.Text = "galleryControl1";
            this.galleryControl1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.XtraFormCarStyle_PreviewKeyDown);
            // 
            // galleryControlClient1
            // 
            this.galleryControlClient1.GalleryControl = this.galleryControl1;
            this.galleryControlClient1.Location = new System.Drawing.Point(1, 1);
            this.galleryControlClient1.Size = new System.Drawing.Size(881, 498);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(48, 48);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "GMC.png");
            this.imageCollection1.Images.SetKeyName(1, "JEEP.png");
            this.imageCollection1.Images.SetKeyName(2, "MG.png");
            this.imageCollection1.Images.SetKeyName(3, "MINI.png");
            this.imageCollection1.Images.SetKeyName(4, "TVR.png");
            this.imageCollection1.Images.SetKeyName(5, "阿尔法罗密欧.png");
            this.imageCollection1.Images.SetKeyName(6, "阿斯顿马丁.png");
            this.imageCollection1.Images.SetKeyName(7, "奥迪.png");
            this.imageCollection1.Images.SetKeyName(8, "宝马.png");
            this.imageCollection1.Images.SetKeyName(9, "保时捷.png");
            this.imageCollection1.Images.SetKeyName(10, "北奔.png");
            this.imageCollection1.Images.SetKeyName(11, "北汽.png");
            this.imageCollection1.Images.SetKeyName(12, "奔驰.png");
            this.imageCollection1.Images.SetKeyName(13, "奔腾.png");
            this.imageCollection1.Images.SetKeyName(14, "本田.png");
            this.imageCollection1.Images.SetKeyName(15, "比亚迪.png");
            this.imageCollection1.Images.SetKeyName(16, "标志.png");
            this.imageCollection1.Images.SetKeyName(17, "别克.png");
            this.imageCollection1.Images.SetKeyName(18, "宾利.png");
            this.imageCollection1.Images.SetKeyName(19, "昌河.png");
            this.imageCollection1.Images.SetKeyName(20, "楚风.png");
            this.imageCollection1.Images.SetKeyName(21, "春兰.png");
            this.imageCollection1.Images.SetKeyName(22, "大发.png");
            this.imageCollection1.Images.SetKeyName(23, "大宇.png");
            this.imageCollection1.Images.SetKeyName(24, "大运.png");
            this.imageCollection1.Images.SetKeyName(25, "大众.png");
            this.imageCollection1.Images.SetKeyName(26, "帝豪.png");
            this.imageCollection1.Images.SetKeyName(27, "东风.png");
            this.imageCollection1.Images.SetKeyName(28, "东风柳州.png");
            this.imageCollection1.Images.SetKeyName(29, "东南.png");
            this.imageCollection1.Images.SetKeyName(30, "法拉利.png");
            this.imageCollection1.Images.SetKeyName(31, "飞驰.png");
            this.imageCollection1.Images.SetKeyName(32, "菲亚特.png");
            this.imageCollection1.Images.SetKeyName(33, "丰田.png");
            this.imageCollection1.Images.SetKeyName(34, "福迪.png");
            this.imageCollection1.Images.SetKeyName(35, "福特.png");
            this.imageCollection1.Images.SetKeyName(36, "福田.png");
            this.imageCollection1.Images.SetKeyName(37, "广汽.png");
            this.imageCollection1.Images.SetKeyName(38, "哈飞.png");
            this.imageCollection1.Images.SetKeyName(39, "海马郑州.png");
            this.imageCollection1.Images.SetKeyName(40, "悍马.png");
            this.imageCollection1.Images.SetKeyName(41, "红旗.png");
            this.imageCollection1.Images.SetKeyName(42, "红岩.png");
            this.imageCollection1.Images.SetKeyName(43, "华德.png");
            this.imageCollection1.Images.SetKeyName(44, "华菱.png");
            this.imageCollection1.Images.SetKeyName(45, "华普.png");
            this.imageCollection1.Images.SetKeyName(46, "华泰.png");
            this.imageCollection1.Images.SetKeyName(47, "皇冠.png");
            this.imageCollection1.Images.SetKeyName(48, "汇众.png");
            this.imageCollection1.Images.SetKeyName(49, "吉奥.png");
            this.imageCollection1.Images.SetKeyName(50, "吉利.png");
            this.imageCollection1.Images.SetKeyName(51, "江淮.png");
            this.imageCollection1.Images.SetKeyName(52, "江铃.png");
            this.imageCollection1.Images.SetKeyName(53, "捷豹.png");
            this.imageCollection1.Images.SetKeyName(54, "解放.png");
            this.imageCollection1.Images.SetKeyName(55, "金杯.png");
            this.imageCollection1.Images.SetKeyName(56, "金龙.png");
            this.imageCollection1.Images.SetKeyName(57, "金旅.png");
            this.imageCollection1.Images.SetKeyName(58, "开瑞.png");
            this.imageCollection1.Images.SetKeyName(59, "凯迪拉克.png");
            this.imageCollection1.Images.SetKeyName(60, "克莱斯勒.png");
            this.imageCollection1.Images.SetKeyName(61, "兰博基尼.png");
            this.imageCollection1.Images.SetKeyName(62, "劳斯莱斯.png");
            this.imageCollection1.Images.SetKeyName(63, "雷克萨斯.png");
            this.imageCollection1.Images.SetKeyName(64, "雷诺.png");
            this.imageCollection1.Images.SetKeyName(65, "力帆.png");
            this.imageCollection1.Images.SetKeyName(66, "莲花.png");
            this.imageCollection1.Images.SetKeyName(67, "联合.png");
            this.imageCollection1.Images.SetKeyName(68, "林肯.png");
            this.imageCollection1.Images.SetKeyName(69, "铃木.png");
            this.imageCollection1.Images.SetKeyName(70, "陆风.png");
            this.imageCollection1.Images.SetKeyName(71, "路虎.png");
            this.imageCollection1.Images.SetKeyName(72, "罗孚.png");
            this.imageCollection1.Images.SetKeyName(73, "马自达.png");
            this.imageCollection1.Images.SetKeyName(74, "玛莎拉蒂.png");
            this.imageCollection1.Images.SetKeyName(75, "曼.png");
            this.imageCollection1.Images.SetKeyName(76, "南汽.png");
            this.imageCollection1.Images.SetKeyName(77, "讴歌.png");
            this.imageCollection1.Images.SetKeyName(78, "欧宝.png");
            this.imageCollection1.Images.SetKeyName(79, "奇瑞.png");
            this.imageCollection1.Images.SetKeyName(80, "起亚.png");
            this.imageCollection1.Images.SetKeyName(81, "青年.png");
            this.imageCollection1.Images.SetKeyName(82, "全球鹰.png");
            this.imageCollection1.Images.SetKeyName(83, "日产.png");
            this.imageCollection1.Images.SetKeyName(84, "日产柴.png");
            this.imageCollection1.Images.SetKeyName(85, "日野.png");
            this.imageCollection1.Images.SetKeyName(86, "荣威.png");
            this.imageCollection1.Images.SetKeyName(87, "瑞麟.png");
            this.imageCollection1.Images.SetKeyName(88, "瑞麒.png");
            this.imageCollection1.Images.SetKeyName(89, "萨博.png");
            this.imageCollection1.Images.SetKeyName(90, "三菱.png");
            this.imageCollection1.Images.SetKeyName(91, "陕汽.png");
            this.imageCollection1.Images.SetKeyName(92, "神野.png");
            this.imageCollection1.Images.SetKeyName(93, "世爵.png");
            this.imageCollection1.Images.SetKeyName(94, "曙光.png");
            this.imageCollection1.Images.SetKeyName(95, "双环.png");
            this.imageCollection1.Images.SetKeyName(96, "双龙.png");
            this.imageCollection1.Images.SetKeyName(97, "斯巴鲁.png");
            this.imageCollection1.Images.SetKeyName(98, "斯堪尼亚.png");
            this.imageCollection1.Images.SetKeyName(99, "斯柯达.png");
            this.imageCollection1.Images.SetKeyName(100, "王牌.png");
            this.imageCollection1.Images.SetKeyName(101, "威麟.png");
            this.imageCollection1.Images.SetKeyName(102, "威兹曼.png");
            this.imageCollection1.Images.SetKeyName(103, "沃尔沃.png");
            this.imageCollection1.Images.SetKeyName(104, "五铃.png");
            this.imageCollection1.Images.SetKeyName(105, "五十铃.png");
            this.imageCollection1.Images.SetKeyName(106, "五征.png");
            this.imageCollection1.Images.SetKeyName(107, "夏利.png");
            this.imageCollection1.Images.SetKeyName(108, "现代.png");
            this.imageCollection1.Images.SetKeyName(109, "徐工.png");
            this.imageCollection1.Images.SetKeyName(110, "雪佛兰.png");
            this.imageCollection1.Images.SetKeyName(111, "雪铁龙.png");
            this.imageCollection1.Images.SetKeyName(112, "羊城.png");
            this.imageCollection1.Images.SetKeyName(113, "野马.png");
            this.imageCollection1.Images.SetKeyName(114, "依维柯.png");
            this.imageCollection1.Images.SetKeyName(115, "英菲尼迪.png");
            this.imageCollection1.Images.SetKeyName(116, "宇通.png");
            this.imageCollection1.Images.SetKeyName(117, "跃进.png");
            this.imageCollection1.Images.SetKeyName(118, "长安.png");
            this.imageCollection1.Images.SetKeyName(119, "长城.png");
            this.imageCollection1.Images.SetKeyName(120, "长丰.png");
            this.imageCollection1.Images.SetKeyName(121, "中国重汽.png");
            this.imageCollection1.Images.SetKeyName(122, "中华.png");
            this.imageCollection1.Images.SetKeyName(123, "中顺.png");
            this.imageCollection1.Images.SetKeyName(124, "中通.png");
            this.imageCollection1.Images.SetKeyName(125, "中兴.png");
            this.imageCollection1.Images.SetKeyName(126, "众泰.png");
            this.imageCollection1.Images.SetKeyName(127, "一汽.png");
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel1.Controls.Add(this.simpleButton2);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 500);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(900, 43);
            this.panel1.TabIndex = 0;
            // 
            // simpleButton2
            // 
            this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.simpleButton2.Location = new System.Drawing.Point(822, 8);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(66, 23);
            this.simpleButton2.TabIndex = 7;
            this.simpleButton2.Text = "取 消";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(750, 8);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(66, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "确 定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FormCarStyle
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 543);
            this.Controls.Add(this.galleryControl1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FormCarStyle";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XtraFormCarStyle";
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.XtraFormCarStyle_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.galleryControl1)).EndInit();
            this.galleryControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.GalleryControl galleryControl1;
        private DevExpress.XtraBars.Ribbon.GalleryControlClient galleryControlClient1;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton btnOK;

    }
}