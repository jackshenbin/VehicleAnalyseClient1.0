namespace Bocom.ImageAnalysisClient.App.Views
{
    partial class ucTaskMonitor
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.ucTaskList1 = new Bocom.ImageAnalysisClient.App.Views.ucTaskList();
            this.ucTaskDetails1 = new Bocom.ImageAnalysisClient.App.Views.ucTaskDetails();
            this.ucOutputWindow1 = new Bocom.ImageAnalysisClient.App.Views.ucOutputWindow();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Appearance.BackColor = System.Drawing.Color.Gray;
            this.splitContainerControl1.Appearance.BackColor2 = System.Drawing.Color.Black;
            this.splitContainerControl1.Appearance.Options.UseBackColor = true;
            this.splitContainerControl1.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel1;
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.LookAndFeel.SkinName = "Office 2010 Black";
            this.splitContainerControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Appearance.BackColor = System.Drawing.Color.Silver;
            this.splitContainerControl1.Panel1.Appearance.Options.UseBackColor = true;
            this.splitContainerControl1.Panel1.Controls.Add(this.ucTaskList1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Appearance.BackColor = System.Drawing.Color.Gray;
            this.splitContainerControl1.Panel2.Appearance.BackColor2 = System.Drawing.Color.Gray;
            this.splitContainerControl1.Panel2.Appearance.Options.UseBackColor = true;
            this.splitContainerControl1.Panel2.Controls.Add(this.splitContainerControl2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(899, 489);
            this.splitContainerControl1.SplitterPosition = 271;
            this.splitContainerControl1.TabIndex = 5;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Appearance.BackColor = System.Drawing.Color.Gray;
            this.splitContainerControl2.Appearance.BackColor2 = System.Drawing.Color.Gray;
            this.splitContainerControl2.Appearance.Options.UseBackColor = true;
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Horizontal = false;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.splitContainerControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Appearance.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.splitContainerControl2.Panel1.Appearance.Options.UseBackColor = true;
            this.splitContainerControl2.Panel1.Controls.Add(this.ucTaskDetails1);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.Appearance.BackColor = System.Drawing.Color.Gray;
            this.splitContainerControl2.Panel2.Appearance.BackColor2 = System.Drawing.Color.Gray;
            this.splitContainerControl2.Panel2.Appearance.Options.UseBackColor = true;
            this.splitContainerControl2.Panel2.Controls.Add(this.ucOutputWindow1);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(622, 489);
            this.splitContainerControl2.SplitterPosition = 378;
            this.splitContainerControl2.TabIndex = 0;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // ucTaskList1
            // 
            this.ucTaskList1.Location = new System.Drawing.Point(0, 0);
            this.ucTaskList1.Name = "ucTaskList1";
            this.ucTaskList1.Size = new System.Drawing.Size(271, 489);
            this.ucTaskList1.TabIndex = 0;
            // 
            // ucTaskDetails1
            // 
            this.ucTaskDetails1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ucTaskDetails1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTaskDetails1.Location = new System.Drawing.Point(0, 0);
            this.ucTaskDetails1.Name = "ucTaskDetails1";
            this.ucTaskDetails1.Size = new System.Drawing.Size(622, 378);
            this.ucTaskDetails1.TabIndex = 0;
            // 
            // ucOutputWindow1
            // 
            this.ucOutputWindow1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucOutputWindow1.Location = new System.Drawing.Point(0, 0);
            this.ucOutputWindow1.Name = "ucOutputWindow1";
            this.ucOutputWindow1.Padding = new System.Windows.Forms.Padding(0, 2, 2, 2);
            this.ucOutputWindow1.Size = new System.Drawing.Size(622, 106);
            this.ucOutputWindow1.TabIndex = 0;
            // 
            // ucTaskMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "ucTaskMonitor";
            this.Size = new System.Drawing.Size(899, 489);
            this.Load += new System.EventHandler(this.ucTaskMonitor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private ucTaskList ucTaskList1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private ucTaskDetails ucTaskDetails1;
        private ucOutputWindow ucOutputWindow1;
    }
}
