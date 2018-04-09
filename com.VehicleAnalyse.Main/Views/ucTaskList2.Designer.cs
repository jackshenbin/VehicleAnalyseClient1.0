namespace com.VehicleAnalyse.Main.Views
{
    partial class ucTaskList2
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.columnId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnPicCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnStartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnTimeSpent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnTaskType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnFilePath = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnCreateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnFinishedTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAddTask = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelTask = new DevExpress.XtraEditors.SimpleButton();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barButtonItemAdd = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemDel = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Padding = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.gridControl1.Size = new System.Drawing.Size(877, 205);
            this.gridControl1.TabIndex = 11;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // gridView1
            // 
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.columnId,
            this.columnName,
            this.columnStatus,
            this.columnPicCount,
            this.columnTimeSpent,
            this.columnTaskType,
            this.columnFilePath,
            this.columnCreateTime,
            this.columnStartTime,
            this.columnFinishedTime});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 38;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsFilter.AllowFilterEditor = false;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsMenu.EnableFooterMenu = false;
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gridView1_SelectionChanged);
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);

            this.gridView1.CustomDrawCell += gridView1_CustomDrawCell;
            // 
            // columnId
            // 
            this.columnId.Caption = "编号";
            this.columnId.FieldName = "Id";
            this.columnId.Name = "columnId";
            this.columnId.Visible = true;
            this.columnId.VisibleIndex = 0;
            this.columnId.Width = 50;
            // 
            // columnName
            // 
            this.columnName.Caption = "任务名称";
            this.columnName.FieldName = "Name";
            this.columnName.Name = "columnName";
            this.columnName.Visible = true;
            this.columnName.VisibleIndex = 1;
            this.columnName.Width = 140;
            // 
            // columnStatus
            // 
            this.columnStatus.Caption = "分析状态";
            this.columnStatus.FieldName = "Status";
            this.columnStatus.Name = "columnStatus";
            this.columnStatus.Visible = true;
            this.columnStatus.VisibleIndex = 2;
            this.columnStatus.Width = 110;
            // 
            // columnPicCount
            // 
            this.columnPicCount.Caption = "图片总数";
            this.columnPicCount.FieldName = "PicCount";
            this.columnPicCount.Name = "columnPicCount";
            this.columnPicCount.Visible = true;
            this.columnPicCount.VisibleIndex = 3;
            this.columnPicCount.Width = 70;
            // 
            // columnStartTime
            // 
            this.columnStartTime.Caption = "分析开始时间";
            this.columnStartTime.FieldName = "StartTime";
            this.columnStartTime.Name = "columnStartTime";
            this.columnStartTime.Visible = true;
            this.columnStartTime.VisibleIndex = 7;
            this.columnStartTime.Width = 128;
            // 
            // columnTimeSpent
            // 
            this.columnTimeSpent.Caption = "用时";
            this.columnTimeSpent.FieldName = "TimeSpan";
            this.columnTimeSpent.Name = "columnTimeSpent";
            this.columnTimeSpent.Visible = true;
            this.columnTimeSpent.VisibleIndex = 4;
            this.columnTimeSpent.Width = 90;
            // 
            // columnTaskType
            // 
            this.columnTaskType.Caption = "文件类型";
            this.columnTaskType.FieldName = "FileType";
            this.columnTaskType.Name = "columnTaskType";
            this.columnTaskType.Visible = true;
            this.columnTaskType.VisibleIndex = 5;
            this.columnTaskType.Width = 60;
            // 
            // columnFilePath
            // 
            this.columnFilePath.Caption = "文件路径";
            this.columnFilePath.FieldName = "FilePath";
            this.columnFilePath.Name = "columnFilePath";
            this.columnFilePath.Visible = true;
            this.columnFilePath.VisibleIndex = 6;
            this.columnFilePath.Width = 240;
            // 
            // columnCreateTime
            // 
            this.columnCreateTime.Caption = "创建时间";
            this.columnCreateTime.FieldName = "CreateTime";
            this.columnCreateTime.Name = "columnCreateTime";
            this.columnCreateTime.Width = 125;
            // 
            // columnFinishedTime
            // 
            this.columnFinishedTime.Caption = "分析完成时间";
            this.columnFinishedTime.FieldName = "FinishedTime";
            this.columnFinishedTime.Name = "columnFinishedTime";
            this.columnFinishedTime.Visible = true;
            this.columnFinishedTime.VisibleIndex = 8;
            this.columnFinishedTime.Width = 125;
            // 
            // btnAddTask
            // 
            this.btnAddTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddTask.Location = new System.Drawing.Point(5, 4);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(75, 23);
            this.btnAddTask.TabIndex = 12;
            this.btnAddTask.Text = "添加任务";
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // btnDelTask
            // 
            this.btnDelTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelTask.Location = new System.Drawing.Point(97, 4);
            this.btnDelTask.Name = "btnDelTask";
            this.btnDelTask.Size = new System.Drawing.Size(75, 23);
            this.btnDelTask.TabIndex = 14;
            this.btnDelTask.Text = "删除任务";
            this.btnDelTask.Click += new System.EventHandler(this.btnDelTask_Click);
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemDel)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // barButtonItemAdd
            // 
            this.barButtonItemAdd.Caption = "添加";
            this.barButtonItemAdd.Id = 0;
            this.barButtonItemAdd.Name = "barButtonItemAdd";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "编辑";
            this.barButtonItem2.Id = 1;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItemDel
            // 
            this.barButtonItemDel.Caption = "删除";
            this.barButtonItemDel.Id = 2;
            this.barButtonItemDel.Name = "barButtonItemDel";
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItemAdd,
            this.barButtonItem2,
            this.barButtonItemDel});
            this.barManager1.MaxItemId = 3;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(877, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 236);
            this.barDockControlBottom.Size = new System.Drawing.Size(877, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 236);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(877, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 236);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnAddTask);
            this.panelControl1.Controls.Add(this.btnDelTask);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 206);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(877, 30);
            this.panelControl1.TabIndex = 19;
            // 
            // ucTaskList2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucTaskList2";
            this.Size = new System.Drawing.Size(877, 236);
            this.SizeChanged += new System.EventHandler(this.ucTaskList2_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn columnId;
        private DevExpress.XtraGrid.Columns.GridColumn columnName;
        private DevExpress.XtraGrid.Columns.GridColumn columnTaskType;
        private DevExpress.XtraGrid.Columns.GridColumn columnFilePath;
        private DevExpress.XtraGrid.Columns.GridColumn columnStatus;
        private DevExpress.XtraGrid.Columns.GridColumn columnPicCount;
        private DevExpress.XtraGrid.Columns.GridColumn columnCreateTime;
        private DevExpress.XtraGrid.Columns.GridColumn columnStartTime;
        private DevExpress.XtraEditors.SimpleButton btnAddTask;
        private DevExpress.XtraEditors.SimpleButton btnDelTask;
        private DevExpress.XtraGrid.Columns.GridColumn columnTimeSpent;
        private DevExpress.XtraGrid.Columns.GridColumn columnFinishedTime;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarButtonItem barButtonItemAdd;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItemDel;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl panelControl1;
    }
}
