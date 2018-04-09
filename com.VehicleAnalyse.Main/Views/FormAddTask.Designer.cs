using DevExpress.XtraEditors;
namespace com.VehicleAnalyse.Main.Views
{
    partial class FormAddTask
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
            this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.comboBoxEditCamera = new DevExpress.XtraEditors.ComboBoxEdit();
            this.ratingStar1 = new DevComponents.DotNetBar.Controls.RatingStar();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtBoxName = new DevExpress.XtraEditors.TextEdit();
            this.cmbBoxTaskType = new DevExpress.XtraEditors.LookUpEdit();
            this.checkBox1 = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControlMsg = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxEditFilePath = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditCamera.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBoxName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBoxTaskType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBox1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditFilePath.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lookUpEdit1
            // 
            this.lookUpEdit1.Location = new System.Drawing.Point(121, 12);
            this.lookUpEdit1.Name = "lookUpEdit1";
            this.lookUpEdit1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.lookUpEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.lookUpEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.lookUpEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.lookUpEdit1.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.lookUpEdit1.Properties.AppearanceDropDown.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.lookUpEdit1.Properties.AppearanceDropDown.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lookUpEdit1.Properties.AppearanceDropDown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.lookUpEdit1.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.lookUpEdit1.Properties.AppearanceDropDown.Options.UseBorderColor = true;
            this.lookUpEdit1.Properties.AppearanceDropDown.Options.UseForeColor = true;
            this.lookUpEdit1.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Priority", "Priority", 5, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.lookUpEdit1.Properties.DisplayMember = "Name";
            this.lookUpEdit1.Properties.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.lookUpEdit1.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lookUpEdit1.Properties.PopupFormMinSize = new System.Drawing.Size(190, 20);
            this.lookUpEdit1.Properties.PopupSizeable = false;
            this.lookUpEdit1.Properties.ShowFooter = false;
            this.lookUpEdit1.Properties.ShowHeader = false;
            this.lookUpEdit1.Properties.ShowLines = false;
            this.lookUpEdit1.Properties.ValueMember = "Priority";
            this.lookUpEdit1.Size = new System.Drawing.Size(100, 20);
            this.lookUpEdit1.TabIndex = 6;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(3, 29);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "任务类型";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(3, 55);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 14);
            this.labelControl2.TabIndex = 9;
            this.labelControl2.Text = "分析路径";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(3, 110);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 14);
            this.labelControl3.TabIndex = 11;
            this.labelControl3.Text = "相机号";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 114F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.comboBoxEditCamera, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.ratingStar1, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelControl7, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelControl1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelControl2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtBoxName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbBoxTaskType, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.checkBox1, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelControl3, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelControl5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelControlMsg, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxEditFilePath, 1, 2);
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(424, 164);
            this.tableLayoutPanel1.TabIndex = 20;
            // 
            // comboBoxEditCamera
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.comboBoxEditCamera, 3);
            this.comboBoxEditCamera.Location = new System.Drawing.Point(83, 110);
            this.comboBoxEditCamera.Name = "comboBoxEditCamera";
            this.comboBoxEditCamera.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.comboBoxEditCamera.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.comboBoxEditCamera.Properties.Appearance.Options.UseBackColor = true;
            this.comboBoxEditCamera.Properties.Appearance.Options.UseForeColor = true;
            this.comboBoxEditCamera.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditCamera.Properties.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.comboBoxEditCamera.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.comboBoxEditCamera.Size = new System.Drawing.Size(287, 20);
            this.comboBoxEditCamera.TabIndex = 4;
            // 
            // ratingStar1
            // 
            // 
            // 
            // 
            this.ratingStar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tableLayoutPanel1.SetColumnSpan(this.ratingStar1, 3);
            this.ratingStar1.Location = new System.Drawing.Point(83, 81);
            this.ratingStar1.Name = "ratingStar1";
            this.ratingStar1.Rating = 3;
            this.ratingStar1.Size = new System.Drawing.Size(287, 23);
            this.ratingStar1.TabIndex = 3;
            this.ratingStar1.TextColor = System.Drawing.Color.Empty;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(3, 3);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(24, 14);
            this.labelControl7.TabIndex = 21;
            this.labelControl7.Text = "名称";
            // 
            // txtBoxName
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtBoxName, 3);
            this.txtBoxName.EditValue = "";
            this.txtBoxName.Location = new System.Drawing.Point(83, 3);
            this.txtBoxName.Name = "txtBoxName";
            this.txtBoxName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtBoxName.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtBoxName.Properties.Appearance.Options.UseBackColor = true;
            this.txtBoxName.Properties.Appearance.Options.UseForeColor = true;
            this.txtBoxName.Properties.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.txtBoxName.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtBoxName.Properties.MaxLength = 31;
            this.txtBoxName.Size = new System.Drawing.Size(287, 20);
            this.txtBoxName.TabIndex = 0;
            // 
            // cmbBoxTaskType
            // 
            this.cmbBoxTaskType.EditValue = "本地";
            this.cmbBoxTaskType.Location = new System.Drawing.Point(83, 29);
            this.cmbBoxTaskType.Name = "cmbBoxTaskType";
            this.cmbBoxTaskType.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.cmbBoxTaskType.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.cmbBoxTaskType.Properties.Appearance.Options.UseBackColor = true;
            this.cmbBoxTaskType.Properties.Appearance.Options.UseForeColor = true;
            this.cmbBoxTaskType.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.cmbBoxTaskType.Properties.AppearanceDropDown.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.cmbBoxTaskType.Properties.AppearanceDropDown.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.cmbBoxTaskType.Properties.AppearanceDropDown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.cmbBoxTaskType.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cmbBoxTaskType.Properties.AppearanceDropDown.Options.UseBorderColor = true;
            this.cmbBoxTaskType.Properties.AppearanceDropDown.Options.UseForeColor = true;
            this.cmbBoxTaskType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbBoxTaskType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Type", "Name1", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NType", "Name2", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", 90, "Name3")});
            this.cmbBoxTaskType.Properties.DropDownRows = 3;
            this.cmbBoxTaskType.Properties.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.cmbBoxTaskType.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cmbBoxTaskType.Properties.PopupFormMinSize = new System.Drawing.Size(90, 20);
            this.cmbBoxTaskType.Properties.PopupSizeable = false;
            this.cmbBoxTaskType.Properties.ShowFooter = false;
            this.cmbBoxTaskType.Properties.ShowHeader = false;
            this.cmbBoxTaskType.Size = new System.Drawing.Size(94, 20);
            this.cmbBoxTaskType.TabIndex = 1;
            this.cmbBoxTaskType.EditValueChanged += new System.EventHandler(this.cmbBoxFileType_EditValueChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(183, 29);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.checkBox1.Properties.Appearance.Options.UseForeColor = true;
            this.checkBox1.Properties.Caption = "包含子文件夹";
            this.checkBox1.Size = new System.Drawing.Size(98, 19);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Visible = false;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(3, 81);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(36, 14);
            this.labelControl5.TabIndex = 13;
            this.labelControl5.Text = "优先级";
            // 
            // labelControlMsg
            // 
            this.labelControlMsg.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControlMsg.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tableLayoutPanel1.SetColumnSpan(this.labelControlMsg, 5);
            this.labelControlMsg.Location = new System.Drawing.Point(3, 136);
            this.labelControlMsg.Name = "labelControlMsg";
            this.labelControlMsg.Size = new System.Drawing.Size(417, 14);
            this.labelControlMsg.TabIndex = 23;
            // 
            // comboBoxEditFilePath
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.comboBoxEditFilePath, 3);
            this.comboBoxEditFilePath.Location = new System.Drawing.Point(83, 55);
            this.comboBoxEditFilePath.Name = "comboBoxEditFilePath";
            this.comboBoxEditFilePath.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.comboBoxEditFilePath.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.comboBoxEditFilePath.Properties.Appearance.Options.UseBackColor = true;
            this.comboBoxEditFilePath.Properties.Appearance.Options.UseForeColor = true;
            this.comboBoxEditFilePath.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditFilePath.Properties.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.comboBoxEditFilePath.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.comboBoxEditFilePath.Size = new System.Drawing.Size(287, 20);
            this.comboBoxEditFilePath.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(333, 196);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(252, 196);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FormAddTask
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(444, 229);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lookUpEdit1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddTask";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加任务";
            this.Load += new System.EventHandler(this.FormAddTask_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditCamera.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBoxName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBoxTaskType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBox1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditFilePath.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txtBoxName;
        private DevExpress.XtraEditors.LookUpEdit cmbBoxTaskType;
        private CheckEdit checkBox1;
        private LabelControl labelControl5;
        private LabelControl labelControlMsg;
        private DevComponents.DotNetBar.Controls.RatingStar ratingStar1;
        private ComboBoxEdit comboBoxEditCamera;
        private ComboBoxEdit comboBoxEditFilePath;
    }
}