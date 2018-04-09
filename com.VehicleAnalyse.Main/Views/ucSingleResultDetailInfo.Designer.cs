namespace com.VehicleAnalyse.Main.Views
{
    partial class ucSingleResultDetailInfo
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.labelControlSimilar = new DevExpress.XtraEditors.LabelControl();
            this.labelControlPlate = new DevExpress.XtraEditors.LabelControl();
            this.labelControlCam = new DevExpress.XtraEditors.LabelControl();
            this.labelControlTime = new DevExpress.XtraEditors.LabelControl();
            this.simpleButtonPriv = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonNext = new DevExpress.XtraEditors.SimpleButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.simpleButtonClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureEdit1.Location = new System.Drawing.Point(5, 5);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.AllowFocused = false;
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.pictureEdit1.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pictureEdit1.Properties.NullText = "没有图片";
            this.pictureEdit1.Properties.PictureInterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            this.pictureEdit1.Properties.ShowMenu = false;
            this.pictureEdit1.Properties.ShowScrollBars = true;
            this.pictureEdit1.Properties.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.picEditOriginal_MouseWheel);
            this.pictureEdit1.Size = new System.Drawing.Size(542, 506);
            this.pictureEdit1.TabIndex = 0;
            // 
            // labelControlSimilar
            // 
            this.labelControlSimilar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControlSimilar.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.labelControlSimilar.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControlSimilar.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControlSimilar.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControlSimilar.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControlSimilar.Location = new System.Drawing.Point(462, 33);
            this.labelControlSimilar.Name = "labelControlSimilar";
            this.labelControlSimilar.Size = new System.Drawing.Size(123, 22);
            this.labelControlSimilar.TabIndex = 4;
            this.labelControlSimilar.Text = "相似度:0%";
            // 
            // labelControlPlate
            // 
            this.labelControlPlate.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControlPlate.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.labelControlPlate.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControlPlate.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControlPlate.Location = new System.Drawing.Point(38, 33);
            this.labelControlPlate.Name = "labelControlPlate";
            this.labelControlPlate.Size = new System.Drawing.Size(96, 22);
            this.labelControlPlate.TabIndex = 1;
            this.labelControlPlate.Text = "沪A12345";
            // 
            // labelControlCam
            // 
            this.labelControlCam.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControlCam.Location = new System.Drawing.Point(3, 3);
            this.labelControlCam.Name = "labelControlCam";
            this.labelControlCam.Size = new System.Drawing.Size(187, 14);
            this.labelControlCam.TabIndex = 2;
            this.labelControlCam.Text = "位置：22";
            // 
            // labelControlTime
            // 
            this.labelControlTime.Location = new System.Drawing.Point(3, 23);
            this.labelControlTime.Name = "labelControlTime";
            this.labelControlTime.Size = new System.Drawing.Size(258, 14);
            this.labelControlTime.TabIndex = 3;
            this.labelControlTime.Text = "过车时间：2017-ssssssssssssssss11-11 11:11:11";
            // 
            // simpleButtonPriv
            // 
            this.simpleButtonPriv.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.simpleButtonPriv.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.simpleButtonPriv.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.simpleButtonPriv.Appearance.ForeColor = System.Drawing.Color.Silver;
            this.simpleButtonPriv.Appearance.Options.UseBackColor = true;
            this.simpleButtonPriv.Appearance.Options.UseForeColor = true;
            this.simpleButtonPriv.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.simpleButtonPriv.Enabled = false;
            this.simpleButtonPriv.Location = new System.Drawing.Point(5, 243);
            this.simpleButtonPriv.Name = "simpleButtonPriv";
            this.simpleButtonPriv.Size = new System.Drawing.Size(27, 68);
            this.simpleButtonPriv.TabIndex = 5;
            this.simpleButtonPriv.Text = "<";
            this.simpleButtonPriv.Click += new System.EventHandler(this.simpleButtonPriv_Click);
            // 
            // simpleButtonNext
            // 
            this.simpleButtonNext.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.simpleButtonNext.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.simpleButtonNext.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.simpleButtonNext.Appearance.ForeColor = System.Drawing.Color.Silver;
            this.simpleButtonNext.Appearance.Options.UseBackColor = true;
            this.simpleButtonNext.Appearance.Options.UseForeColor = true;
            this.simpleButtonNext.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.simpleButtonNext.Enabled = false;
            this.simpleButtonNext.Location = new System.Drawing.Point(845, 243);
            this.simpleButtonNext.Name = "simpleButtonNext";
            this.simpleButtonNext.Size = new System.Drawing.Size(27, 68);
            this.simpleButtonNext.TabIndex = 5;
            this.simpleButtonNext.Text = ">";
            this.simpleButtonNext.Click += new System.EventHandler(this.simpleButtonNext_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.labelControlCam);
            this.flowLayoutPanel1.Controls.Add(this.labelControlTime);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(553, 5);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(242, 506);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.flowLayoutPanel1);
            this.panelControl1.Controls.Add(this.pictureEdit1);
            this.panelControl1.Location = new System.Drawing.Point(38, 58);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(801, 516);
            this.panelControl1.TabIndex = 7;
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.simpleButtonClose);
            this.groupControl1.Controls.Add(this.panelControl1);
            this.groupControl1.Controls.Add(this.labelControlPlate);
            this.groupControl1.Controls.Add(this.labelControlSimilar);
            this.groupControl1.Controls.Add(this.simpleButtonPriv);
            this.groupControl1.Controls.Add(this.simpleButtonNext);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(877, 579);
            this.groupControl1.TabIndex = 8;
            this.groupControl1.Text = "车辆详情";
            // 
            // simpleButtonClose
            // 
            this.simpleButtonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonClose.Location = new System.Drawing.Point(843, 3);
            this.simpleButtonClose.Name = "simpleButtonClose";
            this.simpleButtonClose.Size = new System.Drawing.Size(27, 23);
            this.simpleButtonClose.TabIndex = 8;
            this.simpleButtonClose.Text = "X";
            this.simpleButtonClose.Click += new System.EventHandler(this.simpleButtonClose_Click);
            // 
            // ucSingleResultDetailInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Name = "ucSingleResultDetailInfo";
            this.Size = new System.Drawing.Size(877, 579);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.LabelControl labelControlPlate;
        private DevExpress.XtraEditors.LabelControl labelControlCam;
        private DevExpress.XtraEditors.LabelControl labelControlTime;
        private DevExpress.XtraEditors.LabelControl labelControlSimilar;
        private DevExpress.XtraEditors.SimpleButton simpleButtonPriv;
        private DevExpress.XtraEditors.SimpleButton simpleButtonNext;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonClose;
    }
}
