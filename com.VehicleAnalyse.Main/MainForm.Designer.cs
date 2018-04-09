namespace Bocom.ImageAnalysisClient.App
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.barBtnItemLogin = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnItemStartAnalyse = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnItemExit = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItemView = new DevExpress.XtraBars.BarSubItem();
            this.barBtnItemTaskMonitor = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnItemResultView = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barCheckItemShowOutputWindow = new DevExpress.XtraBars.BarCheckItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barStatusLogin = new DevExpress.XtraBars.BarStaticItem();
            this.barStatusAnalyse = new DevExpress.XtraBars.BarStaticItem();
            this.barAndDockingController1 = new DevExpress.XtraBars.BarAndDockingController(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.applicationMenu1 = new DevExpress.XtraBars.Ribbon.ApplicationMenu(this.components);
            this.ucTaskMonitor1 = new Bocom.ImageAnalysisClient.App.Views.XtraUserControl1();
            this.barBtnItemStopAnalyse = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.AllowCustomization = false;
            this.barManager1.AllowItemAnimatedHighlighting = false;
            this.barManager1.AllowMoveBarOnToolbar = false;
            this.barManager1.AllowQuickCustomization = false;
            this.barManager1.AllowShowToolbarsPopup = false;
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar3});
            this.barManager1.Controller = this.barAndDockingController1;
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.DockWindowTabFont = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barSubItem1,
            this.barSubItemView,
            this.barBtnItemLogin,
            this.barBtnItemExit,
            this.barBtnItemStartAnalyse,
            this.barBtnItemTaskMonitor,
            this.barBtnItemResultView,
            this.barButtonItem1,
            this.barStatusLogin,
            this.barStatusAnalyse,
            this.barCheckItemShowOutputWindow,
            this.barBtnItemStopAnalyse});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 16;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar2
            // 
            this.bar2.BarAppearance.Disabled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.bar2.BarAppearance.Disabled.BackColor2 = System.Drawing.Color.Yellow;
            this.bar2.BarAppearance.Disabled.Options.UseBackColor = true;
            this.bar2.BarAppearance.Hovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.bar2.BarAppearance.Hovered.BackColor2 = System.Drawing.Color.Red;
            this.bar2.BarAppearance.Hovered.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.bar2.BarAppearance.Hovered.Options.UseBackColor = true;
            this.bar2.BarAppearance.Hovered.Options.UseFont = true;
            this.bar2.BarAppearance.Normal.BackColor = System.Drawing.Color.DimGray;
            this.bar2.BarAppearance.Normal.BackColor2 = System.Drawing.Color.DimGray;
            this.bar2.BarAppearance.Normal.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.bar2.BarAppearance.Normal.Image = global::Bocom.ImageAnalysisClient.App.Properties.Resources.bocom;
            this.bar2.BarAppearance.Normal.Options.UseBackColor = true;
            this.bar2.BarAppearance.Normal.Options.UseBorderColor = true;
            this.bar2.BarAppearance.Normal.Options.UseFont = true;
            this.bar2.BarAppearance.Normal.Options.UseForeColor = true;
            this.bar2.BarAppearance.Normal.Options.UseImage = true;
            this.bar2.BarAppearance.Normal.Options.UseTextOptions = true;
            this.bar2.BarAppearance.Pressed.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.bar2.BarAppearance.Pressed.Options.UseFont = true;
            this.bar2.BarItemHorzIndent = 20;
            this.bar2.BarItemVertIndent = 4;
            this.bar2.BarName = "Main menu";
            this.bar2.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.FloatSize = new System.Drawing.Size(0, 40);
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItemView)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "文件";
            this.barSubItem1.Id = 0;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnItemLogin),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnItemStartAnalyse),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnItemStopAnalyse),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnItemExit)});
            this.barSubItem1.Name = "barSubItem1";
            this.barSubItem1.PaintMenuBar += new DevExpress.XtraBars.BarCustomDrawEventHandler(this.BarSubItem1_PaintMenuBar);
            // 
            // barBtnItemLogin
            // 
            this.barBtnItemLogin.Caption = "登录";
            this.barBtnItemLogin.Id = 6;
            this.barBtnItemLogin.ItemAppearance.Hovered.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.barBtnItemLogin.ItemAppearance.Hovered.Options.UseFont = true;
            this.barBtnItemLogin.ItemAppearance.Normal.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.barBtnItemLogin.ItemAppearance.Normal.Options.UseFont = true;
            this.barBtnItemLogin.ItemAppearance.Pressed.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.barBtnItemLogin.ItemAppearance.Pressed.Options.UseFont = true;
            this.barBtnItemLogin.Name = "barBtnItemLogin";
            this.barBtnItemLogin.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnItemLogin_ItemClick);
            // 
            // barBtnItemStartAnalyse
            // 
            this.barBtnItemStartAnalyse.Caption = "开始分析";
            this.barBtnItemStartAnalyse.Enabled = false;
            this.barBtnItemStartAnalyse.Id = 8;
            this.barBtnItemStartAnalyse.ItemAppearance.Hovered.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.barBtnItemStartAnalyse.ItemAppearance.Hovered.Options.UseFont = true;
            this.barBtnItemStartAnalyse.ItemAppearance.Normal.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.barBtnItemStartAnalyse.ItemAppearance.Normal.Options.UseFont = true;
            this.barBtnItemStartAnalyse.ItemAppearance.Pressed.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.barBtnItemStartAnalyse.ItemAppearance.Pressed.Options.UseFont = true;
            this.barBtnItemStartAnalyse.Name = "barBtnItemStartAnalyse";
            this.barBtnItemStartAnalyse.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnItemStartAnalyse_ItemClick);
            // 
            // barBtnItemExit
            // 
            this.barBtnItemExit.Caption = "退出";
            this.barBtnItemExit.Id = 7;
            this.barBtnItemExit.ItemAppearance.Hovered.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.barBtnItemExit.ItemAppearance.Hovered.Options.UseFont = true;
            this.barBtnItemExit.ItemAppearance.Normal.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.barBtnItemExit.ItemAppearance.Normal.Options.UseFont = true;
            this.barBtnItemExit.ItemAppearance.Pressed.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.barBtnItemExit.ItemAppearance.Pressed.Options.UseFont = true;
            this.barBtnItemExit.Name = "barBtnItemExit";
            this.barBtnItemExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnItemExit_ItemClick);
            // 
            // barSubItemView
            // 
            this.barSubItemView.Caption = "视图";
            this.barSubItemView.Id = 1;
            this.barSubItemView.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnItemTaskMonitor),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnItemResultView),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barCheckItemShowOutputWindow)});
            this.barSubItemView.Name = "barSubItemView";
            this.barSubItemView.PaintMenuBar += new DevExpress.XtraBars.BarCustomDrawEventHandler(this.BarSubItem1_PaintMenuBar);
            // 
            // barBtnItemTaskMonitor
            // 
            this.barBtnItemTaskMonitor.Caption = "任务";
            this.barBtnItemTaskMonitor.Id = 9;
            this.barBtnItemTaskMonitor.ItemAppearance.Hovered.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.barBtnItemTaskMonitor.ItemAppearance.Hovered.Options.UseFont = true;
            this.barBtnItemTaskMonitor.ItemAppearance.Normal.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.barBtnItemTaskMonitor.ItemAppearance.Normal.Options.UseFont = true;
            this.barBtnItemTaskMonitor.ItemAppearance.Pressed.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.barBtnItemTaskMonitor.ItemAppearance.Pressed.Options.UseFont = true;
            this.barBtnItemTaskMonitor.Name = "barBtnItemTaskMonitor";
            this.barBtnItemTaskMonitor.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnItemTaskMonitor_ItemClick);
            // 
            // barBtnItemResultView
            // 
            this.barBtnItemResultView.Caption = "查看分析结果";
            this.barBtnItemResultView.Id = 10;
            this.barBtnItemResultView.ItemAppearance.Hovered.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.barBtnItemResultView.ItemAppearance.Hovered.Options.UseFont = true;
            this.barBtnItemResultView.ItemAppearance.Normal.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.barBtnItemResultView.ItemAppearance.Normal.Options.UseFont = true;
            this.barBtnItemResultView.ItemAppearance.Pressed.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.barBtnItemResultView.ItemAppearance.Pressed.Options.UseFont = true;
            this.barBtnItemResultView.Name = "barBtnItemResultView";
            this.barBtnItemResultView.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnItemResultView_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "车品牌管理";
            this.barButtonItem1.Id = 11;
            this.barButtonItem1.ItemAppearance.Hovered.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.barButtonItem1.ItemAppearance.Hovered.Options.UseFont = true;
            this.barButtonItem1.ItemAppearance.Normal.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.barButtonItem1.ItemAppearance.Normal.Options.UseFont = true;
            this.barButtonItem1.ItemAppearance.Pressed.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.barButtonItem1.ItemAppearance.Pressed.Options.UseFont = true;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barCheckItemShowOutputWindow
            // 
            this.barCheckItemShowOutputWindow.Caption = "显示输出窗口";
            this.barCheckItemShowOutputWindow.Id = 14;
            this.barCheckItemShowOutputWindow.ItemAppearance.Disabled.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.barCheckItemShowOutputWindow.ItemAppearance.Disabled.Options.UseFont = true;
            this.barCheckItemShowOutputWindow.ItemAppearance.Hovered.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.barCheckItemShowOutputWindow.ItemAppearance.Hovered.Options.UseFont = true;
            this.barCheckItemShowOutputWindow.ItemAppearance.Normal.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.barCheckItemShowOutputWindow.ItemAppearance.Normal.Options.UseFont = true;
            this.barCheckItemShowOutputWindow.ItemAppearance.Pressed.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.barCheckItemShowOutputWindow.ItemAppearance.Pressed.Options.UseFont = true;
            this.barCheckItemShowOutputWindow.Name = "barCheckItemShowOutputWindow";
            this.barCheckItemShowOutputWindow.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barCheckItemShowOutputWindow_CheckedChanged);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barStatusLogin),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStatusAnalyse)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barStatusLogin
            // 
            this.barStatusLogin.Caption = "未登录";
            this.barStatusLogin.Id = 12;
            this.barStatusLogin.Name = "barStatusLogin";
            this.barStatusLogin.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStatusAnalyse
            // 
            this.barStatusAnalyse.Id = 13;
            this.barStatusAnalyse.Name = "barStatusAnalyse";
            this.barStatusAnalyse.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.PaintStyleName = "WindowsXP";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlTop.Size = new System.Drawing.Size(797, 33);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 495);
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlBottom.Size = new System.Drawing.Size(797, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 33);
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 462);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(797, 33);
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 462);
            // 
            // applicationMenu1
            // 
            this.applicationMenu1.Manager = this.barManager1;
            this.applicationMenu1.MenuAppearance.MenuBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.applicationMenu1.MenuAppearance.MenuBar.BackColor2 = System.Drawing.Color.Gray;
            this.applicationMenu1.MenuAppearance.MenuBar.Options.UseBackColor = true;
            this.applicationMenu1.MenuAppearance.SideStrip.BackColor = System.Drawing.Color.Red;
            this.applicationMenu1.MenuAppearance.SideStrip.BackColor2 = System.Drawing.Color.Red;
            this.applicationMenu1.MenuAppearance.SideStrip.Options.UseBackColor = true;
            this.applicationMenu1.Name = "applicationMenu1";
            this.applicationMenu1.PaintMenuBar += new DevExpress.XtraBars.BarCustomDrawEventHandler(this.popupMenu1_PaintMenuBar);
            // 
            // ucTaskMonitor1
            // 
            this.ucTaskMonitor1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.ucTaskMonitor1.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucTaskMonitor1.Appearance.Options.UseBackColor = true;
            this.ucTaskMonitor1.Appearance.Options.UseFont = true;
            this.ucTaskMonitor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTaskMonitor1.Location = new System.Drawing.Point(0, 33);
            this.ucTaskMonitor1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.ucTaskMonitor1.Name = "ucTaskMonitor1";
            this.ucTaskMonitor1.Padding = new System.Windows.Forms.Padding(4, 0, 4, 4);
            this.ucTaskMonitor1.Size = new System.Drawing.Size(797, 462);
            this.ucTaskMonitor1.TabIndex = 4;
            // 
            // barBtnItemStopAnalyse
            // 
            this.barBtnItemStopAnalyse.Caption = "停止分析";
            this.barBtnItemStopAnalyse.Enabled = false;
            this.barBtnItemStopAnalyse.Id = 15;
            this.barBtnItemStopAnalyse.ItemAppearance.Disabled.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.barBtnItemStopAnalyse.ItemAppearance.Disabled.Options.UseFont = true;
            this.barBtnItemStopAnalyse.ItemAppearance.Hovered.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.barBtnItemStopAnalyse.ItemAppearance.Hovered.Options.UseFont = true;
            this.barBtnItemStopAnalyse.ItemAppearance.Normal.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.barBtnItemStopAnalyse.ItemAppearance.Normal.Options.UseFont = true;
            this.barBtnItemStopAnalyse.ItemAppearance.Pressed.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.barBtnItemStopAnalyse.ItemAppearance.Pressed.Options.UseFont = true;
            this.barBtnItemStopAnalyse.Name = "barBtnItemStopAnalyse";
            this.barBtnItemStopAnalyse.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnItemStopAnalyse_ItemClick);
            // 
            // MainForm
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Appearance.ForeColor = System.Drawing.Color.Black;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 518);
            this.Controls.Add(this.ucTaskMonitor1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "博康二次识别客户端";
            // this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarSubItem barSubItemView;
        private DevExpress.XtraBars.Ribbon.ApplicationMenu applicationMenu1;
        private DevExpress.XtraBars.BarButtonItem barBtnItemLogin;
        private DevExpress.XtraBars.BarButtonItem barBtnItemExit;
        private DevExpress.XtraBars.BarButtonItem barBtnItemStartAnalyse;
        private Views.XtraUserControl1 ucTaskMonitor1;
        private DevExpress.XtraBars.BarButtonItem barBtnItemTaskMonitor;
        private DevExpress.XtraBars.BarButtonItem barBtnItemResultView;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarAndDockingController barAndDockingController1;
        private DevExpress.XtraBars.BarStaticItem barStatusLogin;
        private DevExpress.XtraBars.BarStaticItem barStatusAnalyse;
        private DevExpress.XtraBars.BarCheckItem barCheckItemShowOutputWindow;
        private DevExpress.XtraBars.BarButtonItem barBtnItemStopAnalyse;
    }
}