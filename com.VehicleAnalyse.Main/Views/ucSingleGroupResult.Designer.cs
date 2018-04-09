namespace com.VehicleAnalyse.Main.Views
{
    partial class ucSingleGroupResult
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
            this.labelControlGroup = new DevExpress.XtraEditors.LabelControl();
            this.labelControlCount = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButtonView = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonExport = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureEdit1.Location = new System.Drawing.Point(0, 19);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.AllowFocused = false;
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pictureEdit1.Properties.ShowMenu = false;
            this.pictureEdit1.Size = new System.Drawing.Size(218, 147);
            this.pictureEdit1.TabIndex = 4;
            this.pictureEdit1.Click += new System.EventHandler(this.labelControlSimilar_Click);
            // 
            // labelControlGroup
            // 
            this.labelControlGroup.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControlGroup.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.labelControlGroup.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControlGroup.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControlGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControlGroup.Location = new System.Drawing.Point(0, 0);
            this.labelControlGroup.Name = "labelControlGroup";
            this.labelControlGroup.Size = new System.Drawing.Size(218, 19);
            this.labelControlGroup.TabIndex = 5;
            this.labelControlGroup.Text = "沪A12345";
            this.labelControlGroup.Click += new System.EventHandler(this.labelControlSimilar_Click);
            // 
            // labelControlCount
            // 
            this.labelControlCount.Location = new System.Drawing.Point(5, 6);
            this.labelControlCount.Name = "labelControlCount";
            this.labelControlCount.Size = new System.Drawing.Size(43, 14);
            this.labelControlCount.TabIndex = 6;
            this.labelControlCount.Text = "0条过车";
            this.labelControlCount.Click += new System.EventHandler(this.labelControlSimilar_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.simpleButtonView);
            this.panelControl1.Controls.Add(this.simpleButtonExport);
            this.panelControl1.Controls.Add(this.labelControlCount);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 166);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(218, 30);
            this.panelControl1.TabIndex = 8;
            this.panelControl1.Click += new System.EventHandler(this.labelControlSimilar_Click);
            // 
            // simpleButtonView
            // 
            this.simpleButtonView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonView.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.simpleButtonView.Appearance.ForeColor = System.Drawing.SystemColors.Info;
            this.simpleButtonView.Appearance.Options.UseBackColor = true;
            this.simpleButtonView.Appearance.Options.UseForeColor = true;
            this.simpleButtonView.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.simpleButtonView.Location = new System.Drawing.Point(174, 5);
            this.simpleButtonView.Name = "simpleButtonView";
            this.simpleButtonView.Size = new System.Drawing.Size(40, 20);
            this.simpleButtonView.TabIndex = 7;
            this.simpleButtonView.Text = "查看";
            this.simpleButtonView.Click += new System.EventHandler(this.simpleButtonView_Click);
            // 
            // simpleButtonExport
            // 
            this.simpleButtonExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonExport.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.simpleButtonExport.Appearance.ForeColor = System.Drawing.SystemColors.Info;
            this.simpleButtonExport.Appearance.Options.UseBackColor = true;
            this.simpleButtonExport.Appearance.Options.UseForeColor = true;
            this.simpleButtonExport.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.simpleButtonExport.Location = new System.Drawing.Point(134, 5);
            this.simpleButtonExport.Name = "simpleButtonExport";
            this.simpleButtonExport.Size = new System.Drawing.Size(40, 20);
            this.simpleButtonExport.TabIndex = 7;
            this.simpleButtonExport.Text = "导出";
            this.simpleButtonExport.Click += new System.EventHandler(this.simpleButtonExport_Click);
            // 
            // ucSingleGroupResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.labelControlGroup);
            this.Name = "ucSingleGroupResult";
            this.Size = new System.Drawing.Size(218, 196);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.LabelControl labelControlGroup;
        private DevExpress.XtraEditors.LabelControl labelControlCount;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonView;
        private DevExpress.XtraEditors.SimpleButton simpleButtonExport;
    }
}
