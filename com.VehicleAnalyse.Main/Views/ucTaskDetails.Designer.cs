namespace Bocom.ImageAnalysisClient.App.Views
{
    partial class ucTaskDetails
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
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtBoxURL = new DevExpress.XtraEditors.TextEdit();
            this.txtBoxName = new DevExpress.XtraEditors.TextEdit();
            this.timeEditCreate = new DevExpress.XtraEditors.TimeEdit();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnViewResults = new DevExpress.XtraEditors.SimpleButton();
            this.cmbBoxFileType = new DevExpress.XtraEditors.LookUpEdit();
            this.btnViewFailedResults = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtBoxURL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBoxName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditCreate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBoxFileType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(13, 3);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(24, 14);
            this.labelControl7.TabIndex = 27;
            this.labelControl7.Text = "名称";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 29);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 23;
            this.labelControl1.Text = "文件类型";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(13, 55);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(24, 14);
            this.labelControl2.TabIndex = 25;
            this.labelControl2.Text = "路径";
            // 
            // txtBoxURL
            // 
            this.txtBoxURL.EditValue = "";
            this.txtBoxURL.Enabled = false;
            this.txtBoxURL.Location = new System.Drawing.Point(93, 55);
            this.txtBoxURL.Name = "txtBoxURL";
            this.txtBoxURL.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtBoxURL.Properties.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtBoxURL.Properties.Appearance.Options.UseBackColor = true;
            this.txtBoxURL.Properties.Appearance.Options.UseForeColor = true;
            this.txtBoxURL.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtBoxURL.Properties.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.txtBoxURL.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtBoxURL.Properties.MaxLength = 31;
            this.txtBoxURL.Size = new System.Drawing.Size(273, 20);
            this.txtBoxURL.TabIndex = 24;
            // 
            // txtBoxName
            // 
            this.txtBoxName.EditValue = "";
            this.txtBoxName.Enabled = false;
            this.txtBoxName.Location = new System.Drawing.Point(93, 3);
            this.txtBoxName.Name = "txtBoxName";
            this.txtBoxName.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtBoxName.Properties.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtBoxName.Properties.Appearance.Options.UseBackColor = true;
            this.txtBoxName.Properties.Appearance.Options.UseForeColor = true;
            this.txtBoxName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtBoxName.Properties.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.txtBoxName.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtBoxName.Properties.MaxLength = 31;
            this.txtBoxName.Size = new System.Drawing.Size(273, 20);
            this.txtBoxName.TabIndex = 28;
            // 
            // timeEditCreate
            // 
            this.timeEditCreate.EditValue = new System.DateTime(2014, 1, 17, 0, 0, 0, 0);
            this.timeEditCreate.Enabled = false;
            this.timeEditCreate.Location = new System.Drawing.Point(93, 82);
            this.timeEditCreate.Name = "timeEditCreate";
            this.timeEditCreate.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.timeEditCreate.Properties.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.timeEditCreate.Properties.Appearance.Options.UseBackColor = true;
            this.timeEditCreate.Properties.Appearance.Options.UseForeColor = true;
            this.timeEditCreate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.timeEditCreate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.timeEditCreate.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.timeEditCreate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditCreate.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.timeEditCreate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditCreate.Properties.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.timeEditCreate.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.timeEditCreate.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
            this.timeEditCreate.Size = new System.Drawing.Size(143, 20);
            this.timeEditCreate.TabIndex = 40;
            // 
            // labelControl13
            // 
            this.labelControl13.Location = new System.Drawing.Point(13, 85);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(48, 14);
            this.labelControl13.TabIndex = 39;
            this.labelControl13.Text = "创建时间";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(13, 116);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(48, 14);
            this.labelControl4.TabIndex = 43;
            this.labelControl4.Text = "分析摘要";
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(93, 116);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(273, 149);
            this.gridControl1.TabIndex = 44;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView2});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn3});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsDetail.ShowDetailTabs = false;
            this.gridView1.OptionsDetail.SmartDetailExpand = false;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsMenu.EnableFooterMenu = false;
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowDetailButtons = false;
            this.gridView1.OptionsView.ShowGroupExpandCollapseButtons = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.True;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "属性名称";
            this.gridColumn2.FieldName = "Name";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 59;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "内容";
            this.gridColumn3.FieldName = "Value";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 131;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridControl1;
            this.gridView2.Name = "gridView2";
            // 
            // btnViewResults
            // 
            this.btnViewResults.Location = new System.Drawing.Point(93, 281);
            this.btnViewResults.Name = "btnViewResults";
            this.btnViewResults.Size = new System.Drawing.Size(90, 23);
            this.btnViewResults.TabIndex = 45;
            this.btnViewResults.Text = "查看分析结果";
            this.btnViewResults.Click += new System.EventHandler(this.btnViewResults_Click);
            // 
            // cmbBoxFileType
            // 
            this.cmbBoxFileType.EditValue = "本地";
            this.cmbBoxFileType.Enabled = false;
            this.cmbBoxFileType.Location = new System.Drawing.Point(93, 29);
            this.cmbBoxFileType.Name = "cmbBoxFileType";
            this.cmbBoxFileType.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.cmbBoxFileType.Properties.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmbBoxFileType.Properties.Appearance.Options.UseBackColor = true;
            this.cmbBoxFileType.Properties.Appearance.Options.UseForeColor = true;
            this.cmbBoxFileType.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.cmbBoxFileType.Properties.AppearanceDropDown.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.cmbBoxFileType.Properties.AppearanceDropDown.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.cmbBoxFileType.Properties.AppearanceDropDown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.cmbBoxFileType.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cmbBoxFileType.Properties.AppearanceDropDown.Options.UseBorderColor = true;
            this.cmbBoxFileType.Properties.AppearanceDropDown.Options.UseForeColor = true;
            this.cmbBoxFileType.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.cmbBoxFileType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbBoxFileType.Properties.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.cmbBoxFileType.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cmbBoxFileType.Properties.PopupFormMinSize = new System.Drawing.Size(190, 20);
            this.cmbBoxFileType.Properties.PopupSizeable = false;
            this.cmbBoxFileType.Size = new System.Drawing.Size(111, 20);
            this.cmbBoxFileType.TabIndex = 26;
            // 
            // btnViewFailedResults
            // 
            this.btnViewFailedResults.Location = new System.Drawing.Point(201, 281);
            this.btnViewFailedResults.Name = "btnViewFailedResults";
            this.btnViewFailedResults.Size = new System.Drawing.Size(94, 23);
            this.btnViewFailedResults.TabIndex = 45;
            this.btnViewFailedResults.Text = "查看无结果记录";
            this.btnViewFailedResults.Click += new System.EventHandler(this.btnViewFailedResults_Click);
            // 
            // ucTaskDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnViewFailedResults);
            this.Controls.Add(this.btnViewResults);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.timeEditCreate);
            this.Controls.Add(this.labelControl13);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtBoxURL);
            this.Controls.Add(this.txtBoxName);
            this.Controls.Add(this.cmbBoxFileType);
            this.Name = "ucTaskDetails";
            this.Size = new System.Drawing.Size(467, 317);
            this.Load += new System.EventHandler(this.ucTaskDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtBoxURL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBoxName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditCreate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBoxFileType.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtBoxURL;
        private DevExpress.XtraEditors.TextEdit txtBoxName;
        private DevExpress.XtraEditors.TimeEdit timeEditCreate;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.SimpleButton btnViewResults;
        private DevExpress.XtraEditors.LookUpEdit cmbBoxFileType;
        private DevExpress.XtraEditors.SimpleButton btnViewFailedResults;
    }
}
