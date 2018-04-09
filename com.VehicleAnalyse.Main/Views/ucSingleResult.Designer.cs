namespace com.VehicleAnalyse.Main.Views
{
    partial class ucSingleResult
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.pictureEdit1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Controls.Add(this.labelControlSimilar);
            this.pictureEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureEdit1.Location = new System.Drawing.Point(0, 0);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.AllowFocused = false;
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.ShowMenu = false;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pictureEdit1.Size = new System.Drawing.Size(182, 108);
            this.pictureEdit1.TabIndex = 0;
            this.pictureEdit1.Click += new System.EventHandler(this.labelControlSimilar_Click);
            // 
            // labelControlSimilar
            // 
            this.labelControlSimilar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControlSimilar.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.labelControlSimilar.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControlSimilar.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControlSimilar.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControlSimilar.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControlSimilar.Location = new System.Drawing.Point(108, 5);
            this.labelControlSimilar.Name = "labelControlSimilar";
            this.labelControlSimilar.Size = new System.Drawing.Size(70, 22);
            this.labelControlSimilar.TabIndex = 4;
            this.labelControlSimilar.Text = "99%";
            this.labelControlSimilar.Click += new System.EventHandler(this.labelControlSimilar_Click);
            // 
            // labelControlPlate
            // 
            this.labelControlPlate.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.labelControlPlate.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControlPlate.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControlPlate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelControlPlate.Location = new System.Drawing.Point(0, 108);
            this.labelControlPlate.Name = "labelControlPlate";
            this.labelControlPlate.Size = new System.Drawing.Size(182, 19);
            this.labelControlPlate.TabIndex = 1;
            this.labelControlPlate.Text = "沪A12345";
            this.labelControlPlate.Click += new System.EventHandler(this.labelControlSimilar_Click);
            // 
            // labelControlCam
            // 
            this.labelControlCam.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.labelControlCam.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelControlCam.Location = new System.Drawing.Point(0, 127);
            this.labelControlCam.Name = "labelControlCam";
            this.labelControlCam.Size = new System.Drawing.Size(50, 14);
            this.labelControlCam.TabIndex = 2;
            this.labelControlCam.Text = "位置：22";
            this.labelControlCam.Click += new System.EventHandler(this.labelControlSimilar_Click);
            // 
            // labelControlTime
            // 
            this.labelControlTime.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.labelControlTime.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelControlTime.Location = new System.Drawing.Point(0, 141);
            this.labelControlTime.Name = "labelControlTime";
            this.labelControlTime.Size = new System.Drawing.Size(178, 14);
            this.labelControlTime.TabIndex = 3;
            this.labelControlTime.Text = "过车时间：2017-11-11 11:11:11";
            this.labelControlTime.Click += new System.EventHandler(this.labelControlSimilar_Click);
            // 
            // ucSingleResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.labelControlPlate);
            this.Controls.Add(this.labelControlCam);
            this.Controls.Add(this.labelControlTime);
            this.Name = "ucSingleResult";
            this.Size = new System.Drawing.Size(182, 155);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.pictureEdit1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.LabelControl labelControlPlate;
        private DevExpress.XtraEditors.LabelControl labelControlCam;
        private DevExpress.XtraEditors.LabelControl labelControlTime;
        private DevExpress.XtraEditors.LabelControl labelControlSimilar;
    }
}
