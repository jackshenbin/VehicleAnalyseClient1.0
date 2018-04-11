namespace com.VehicleAnalyse.Main.Views
{
    partial class ucResultImage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.picEditOriginal = new DevExpress.XtraEditors.PictureEdit();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.picEditDriver = new DevExpress.XtraEditors.PictureEdit();
            this.picEditCoDriver = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEditOriginal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEditDriver.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEditCoDriver.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel2;
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.picEditOriginal);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.splitContainerControl2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1033, 591);
            this.splitContainerControl1.SplitterPosition = 781;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // picEditOriginal
            // 
            this.picEditOriginal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picEditOriginal.Location = new System.Drawing.Point(0, 0);
            this.picEditOriginal.Name = "picEditOriginal";
            this.picEditOriginal.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.picEditOriginal.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.picEditOriginal.Properties.Appearance.Options.UseBackColor = true;
            this.picEditOriginal.Properties.Appearance.Options.UseForeColor = true;
            this.picEditOriginal.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picEditOriginal.Properties.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.picEditOriginal.Properties.LookAndFeel.UseDefaultLookAndFeel = true;
            this.picEditOriginal.Properties.NullText = "没有图片";
            this.picEditOriginal.Properties.PictureInterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            this.picEditOriginal.Properties.ShowMenu = false;
            this.picEditOriginal.Properties.ShowScrollBars = true;
            this.picEditOriginal.Size = new System.Drawing.Size(781, 591);
            this.picEditOriginal.TabIndex = 24;
            this.picEditOriginal.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.picEditOriginal_MouseWheel);
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Horizontal = false;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.picEditDriver);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.picEditCoDriver);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(247, 591);
            this.splitContainerControl2.SplitterPosition = 275;
            this.splitContainerControl2.TabIndex = 0;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // picEditDriver
            // 
            this.picEditDriver.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picEditDriver.Location = new System.Drawing.Point(0, 0);
            this.picEditDriver.Name = "picEditDriver";
            this.picEditDriver.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.picEditDriver.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.picEditDriver.Properties.Appearance.Options.UseBackColor = true;
            this.picEditDriver.Properties.Appearance.Options.UseForeColor = true;
            this.picEditDriver.Properties.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.picEditDriver.Properties.LookAndFeel.UseDefaultLookAndFeel = true;
            this.picEditDriver.Properties.ShowMenu = false;
            this.picEditDriver.Size = new System.Drawing.Size(247, 275);
            this.picEditDriver.TabIndex = 15;
            // 
            // picEditCoDriver
            // 
            this.picEditCoDriver.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picEditCoDriver.Location = new System.Drawing.Point(0, 0);
            this.picEditCoDriver.Name = "picEditCoDriver";
            this.picEditCoDriver.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.picEditCoDriver.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.picEditCoDriver.Properties.Appearance.Options.UseBackColor = true;
            this.picEditCoDriver.Properties.Appearance.Options.UseForeColor = true;
            this.picEditCoDriver.Properties.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.picEditCoDriver.Properties.LookAndFeel.UseDefaultLookAndFeel = true;
            this.picEditCoDriver.Properties.ShowMenu = false;
            this.picEditCoDriver.Size = new System.Drawing.Size(247, 311);
            this.picEditCoDriver.TabIndex = 15;
            // 
            // ucResultImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "ucResultImage";
            this.Size = new System.Drawing.Size(1033, 591);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picEditOriginal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picEditDriver.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEditCoDriver.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraEditors.PictureEdit picEditOriginal;
        private DevExpress.XtraEditors.PictureEdit picEditDriver;
        private DevExpress.XtraEditors.PictureEdit picEditCoDriver;
    }
}
