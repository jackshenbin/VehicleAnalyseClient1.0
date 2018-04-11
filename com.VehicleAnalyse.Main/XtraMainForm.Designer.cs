namespace com.VehicleAnalyse.Main
{
    partial class XtraMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XtraMainForm));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barItemStatus = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barStatusLogin = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.checkButtonTask = new DevExpress.XtraEditors.CheckButton();
            this.checkButtonCompare = new DevExpress.XtraEditors.CheckButton();
            this.checkButtonSearch = new DevExpress.XtraEditors.CheckButton();
            this.simpleButtonconfig = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barItemStatus});
            this.barManager1.MaxItemId = 1;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemStatus)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barItemStatus
            // 
            this.barItemStatus.Caption = "未登录";
            this.barItemStatus.Id = 0;
            this.barItemStatus.Name = "barItemStatus";
            this.barItemStatus.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(823, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 682);
            this.barDockControlBottom.Size = new System.Drawing.Size(823, 27);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 682);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(823, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 682);
            // 
            // barStatusLogin
            // 
            this.barStatusLogin.Caption = "未登录";
            this.barStatusLogin.Id = 12;
            this.barStatusLogin.Name = "barStatusLogin";
            this.barStatusLogin.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "未登录";
            this.barStaticItem1.Id = 12;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xtraTabControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.xtraTabControl1.Location = new System.Drawing.Point(1, 47);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            this.xtraTabControl1.Size = new System.Drawing.Size(821, 638);
            this.xtraTabControl1.TabIndex = 6;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3});
            this.xtraTabControl1.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtraTabControl1_SelectedPageChanged);
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(813, 630);
            this.xtraTabPage1.Text = "xtraTabPage1";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(813, 630);
            this.xtraTabPage2.Text = "xtraTabPage2";
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(813, 630);
            this.xtraTabPage3.Text = "xtraTabPage3";
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureEdit1.EditValue = global::com.VehicleAnalyse.Main.Properties.Resources.bocom;
            this.pictureEdit1.Location = new System.Drawing.Point(739, 0);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.AllowFocused = false;
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.ShowMenu = false;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pictureEdit1.Size = new System.Drawing.Size(83, 38);
            this.pictureEdit1.TabIndex = 29;
            // 
            // checkButtonTask
            // 
            this.checkButtonTask.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.checkButtonTask.Checked = true;
            this.checkButtonTask.GroupIndex = 1;
            this.checkButtonTask.Image = global::com.VehicleAnalyse.Main.Properties.Resources.task_37_088042049934px_1202886_easyicon_net;
            this.checkButtonTask.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.checkButtonTask.Location = new System.Drawing.Point(305, 2);
            this.checkButtonTask.LookAndFeel.SkinName = "McSkin";
            this.checkButtonTask.Name = "checkButtonTask";
            this.checkButtonTask.Size = new System.Drawing.Size(45, 45);
            this.checkButtonTask.TabIndex = 49;
            this.checkButtonTask.CheckedChanged += new System.EventHandler(this.checkButtonTask_CheckedChanged);
            // 
            // checkButtonCompare
            // 
            this.checkButtonCompare.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.checkButtonCompare.GroupIndex = 1;
            this.checkButtonCompare.Image = global::com.VehicleAnalyse.Main.Properties.Resources.Detective_31_305719921105px_1180787_easyicon_net;
            this.checkButtonCompare.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.checkButtonCompare.Location = new System.Drawing.Point(407, 1);
            this.checkButtonCompare.LookAndFeel.SkinName = "McSkin";
            this.checkButtonCompare.Name = "checkButtonCompare";
            this.checkButtonCompare.Size = new System.Drawing.Size(45, 45);
            this.checkButtonCompare.TabIndex = 54;
            this.checkButtonCompare.TabStop = false;
            this.checkButtonCompare.CheckedChanged += new System.EventHandler(this.checkButtonCompare_CheckedChanged);
            // 
            // checkButtonSearch
            // 
            this.checkButtonSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.checkButtonSearch.GroupIndex = 1;
            this.checkButtonSearch.Image = global::com.VehicleAnalyse.Main.Properties.Resources.target_32px_1202885_easyicon_net;
            this.checkButtonSearch.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.checkButtonSearch.Location = new System.Drawing.Point(356, 1);
            this.checkButtonSearch.LookAndFeel.SkinName = "McSkin";
            this.checkButtonSearch.Name = "checkButtonSearch";
            this.checkButtonSearch.Size = new System.Drawing.Size(45, 45);
            this.checkButtonSearch.TabIndex = 55;
            this.checkButtonSearch.TabStop = false;
            this.checkButtonSearch.CheckedChanged += new System.EventHandler(this.checkButtonSearch_CheckedChanged);
            // 
            // simpleButtonconfig
            // 
            this.simpleButtonconfig.AllowFocus = false;
            this.simpleButtonconfig.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.simpleButtonconfig.Image = global::com.VehicleAnalyse.Main.Properties.Resources.Administrative_Tools_32px_1180764_easyicon_net;
            this.simpleButtonconfig.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButtonconfig.Location = new System.Drawing.Point(458, 0);
            this.simpleButtonconfig.Name = "simpleButtonconfig";
            this.simpleButtonconfig.Size = new System.Drawing.Size(45, 45);
            this.simpleButtonconfig.TabIndex = 61;
            this.simpleButtonconfig.TabStop = false;
            this.simpleButtonconfig.Click += new System.EventHandler(this.simpleButtonconfig_Click_1);
            // 
            // XtraMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 709);
            this.Controls.Add(this.simpleButtonconfig);
            this.Controls.Add(this.checkButtonSearch);
            this.Controls.Add(this.checkButtonCompare);
            this.Controls.Add(this.checkButtonTask);
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.SkinName = "McSkin";
            this.LookAndFeel.UseDefaultLookAndFeel = true;
            this.Name = "XtraMainForm";
            this.Text = "车辆识别客户端";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.XtraMainForm_FormClosing);
            this.Load += new System.EventHandler(this.XtraMainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Views.ucResultPage ucResultPage1;
        private Views.ucTaskPage ucTaskPage1;
        private Views.ucCompareSearchResultPage ucCompareSearchResultPage1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarStaticItem barStatusLogin;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarStaticItem barItemStatus;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private DevExpress.XtraEditors.CheckButton checkButtonTask;
        private DevExpress.XtraEditors.CheckButton checkButtonSearch;
        private DevExpress.XtraEditors.CheckButton checkButtonCompare;
        private DevExpress.XtraEditors.SimpleButton simpleButtonconfig;

    }
}