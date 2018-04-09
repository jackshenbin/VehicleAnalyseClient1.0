namespace Bocom.ImageAnalysisClient.App.Views
{
    partial class XtraUserControl1
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
            this.components = new System.ComponentModel.Container();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.ucTaskList1 = new Bocom.ImageAnalysisClient.App.Views.ucTaskList();
            this.dockPanel2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.ucOutputWindow1 = new Bocom.ImageAnalysisClient.App.Views.ucOutputWindow();
            this.ucTaskDetails1 = new Bocom.ImageAnalysisClient.App.Views.ucTaskDetails();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            this.dockPanel2.SuspendLayout();
            this.dockPanel2_Container.SuspendLayout();
            this.SuspendLayout();
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1,
            this.dockPanel2});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel1.ID = new System.Guid("5bd55ef7-b7e1-4fa3-b1fa-e361e84a101c");
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Options.AllowDockAsTabbedDocument = false;
            this.dockPanel1.Options.AllowDockBottom = false;
            this.dockPanel1.Options.AllowDockFill = false;
            this.dockPanel1.Options.AllowDockRight = false;
            this.dockPanel1.Options.AllowDockTop = false;
            this.dockPanel1.Options.AllowFloating = false;
            this.dockPanel1.Options.FloatOnDblClick = false;
            this.dockPanel1.Options.ShowAutoHideButton = false;
            this.dockPanel1.Options.ShowCloseButton = false;
            this.dockPanel1.Options.ShowMaximizeButton = false;
            this.dockPanel1.OriginalSize = new System.Drawing.Size(270, 200);
            this.dockPanel1.Size = new System.Drawing.Size(270, 611);
            this.dockPanel1.Text = "任务列表";
            this.dockPanel1.SizeChanged += new System.EventHandler(this.dockPanel1_SizeChanged);
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.ucTaskList1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(262, 584);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // ucTaskList1
            // 
            this.ucTaskList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTaskList1.Location = new System.Drawing.Point(0, 0);
            this.ucTaskList1.Name = "ucTaskList1";
            this.ucTaskList1.Size = new System.Drawing.Size(262, 584);
            this.ucTaskList1.TabIndex = 0;
            // 
            // dockPanel2
            // 
            this.dockPanel2.Controls.Add(this.dockPanel2_Container);
            this.dockPanel2.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dockPanel2.ID = new System.Guid("47c88d01-7fa9-4c26-bbb9-6344a08fb2bc");
            this.dockPanel2.Location = new System.Drawing.Point(270, 411);
            this.dockPanel2.Name = "dockPanel2";
            this.dockPanel2.Options.AllowDockAsTabbedDocument = false;
            this.dockPanel2.Options.AllowDockFill = false;
            this.dockPanel2.Options.AllowDockLeft = false;
            this.dockPanel2.Options.AllowDockRight = false;
            this.dockPanel2.Options.AllowDockTop = false;
            this.dockPanel2.Options.AllowFloating = false;
            this.dockPanel2.Options.FloatOnDblClick = false;
            this.dockPanel2.Options.ShowCloseButton = false;
            this.dockPanel2.Options.ShowMaximizeButton = false;
            this.dockPanel2.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel2.Size = new System.Drawing.Size(627, 200);
            this.dockPanel2.Text = "输出窗口";
            this.dockPanel2.SizeChanged += new System.EventHandler(this.dockPanel2_SizeChanged);
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Controls.Add(this.ucOutputWindow1);
            this.dockPanel2_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(619, 173);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // ucOutputWindow1
            // 
            this.ucOutputWindow1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucOutputWindow1.Location = new System.Drawing.Point(0, 0);
            this.ucOutputWindow1.Name = "ucOutputWindow1";
            this.ucOutputWindow1.Size = new System.Drawing.Size(619, 173);
            this.ucOutputWindow1.TabIndex = 0;
            // 
            // ucTaskDetails1
            // 
            this.ucTaskDetails1.BackColor = System.Drawing.SystemColors.Control;
            this.ucTaskDetails1.Location = new System.Drawing.Point(281, 24);
            this.ucTaskDetails1.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.ucTaskDetails1.Name = "ucTaskDetails1";
            this.ucTaskDetails1.Size = new System.Drawing.Size(601, 368);
            this.ucTaskDetails1.TabIndex = 2;
            // 
            // XtraUserControl1
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucTaskDetails1);
            this.Controls.Add(this.dockPanel2);
            this.Controls.Add(this.dockPanel1);
            this.Name = "XtraUserControl1";
            this.Size = new System.Drawing.Size(897, 611);
            this.Load += new System.EventHandler(this.XtraUserControl1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            this.dockPanel2.ResumeLayout(false);
            this.dockPanel2_Container.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private ucTaskDetails ucTaskDetails1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel2;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private ucOutputWindow ucOutputWindow1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private ucTaskList ucTaskList1;
    }
}
