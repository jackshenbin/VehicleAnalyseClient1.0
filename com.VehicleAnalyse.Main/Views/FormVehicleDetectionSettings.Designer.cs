namespace Bocom.ImageAnalysisClient.App.Views
{
    partial class FormVehicleDetectionSettings
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
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.spinEditPicWidth = new DevExpress.XtraEditors.SpinEdit();
            this.spinEditPicHeight = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.spinEditDetectionHeight = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.spinEditDetectionWidth = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.spinEditDetectionY = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.spinEditDetectionX = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.spinEditPlateAreaH = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.spinEditPlateAreaW = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.spinEditPlateAreaY = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.spinEditPlateAreaX = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.radioGroupPlateLocationType = new DevExpress.XtraEditors.RadioGroup();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.timeEditStart = new DevExpress.XtraEditors.TimeEdit();
            this.spinEdit1SnapshotInterval = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.spinEditCameraId = new DevExpress.XtraEditors.SpinEdit();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.spinEditPlateRangeMax = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.spinEditPlateRangeMin = new DevExpress.XtraEditors.SpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditPicWidth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditPicHeight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditDetectionHeight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditDetectionWidth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditDetectionY.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditDetectionX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditPlateAreaH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditPlateAreaW.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditPlateAreaY.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditPlateAreaX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupPlateLocationType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1SnapshotInterval.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditCameraId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditPlateRangeMax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditPlateRangeMin.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(15, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 14);
            this.labelControl2.TabIndex = 9;
            this.labelControl2.Text = "相机编号";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(243, 463);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOK.Location = new System.Drawing.Point(162, 463);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(15, 38);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(36, 14);
            this.labelControl7.TabIndex = 24;
            this.labelControl7.Text = "图片宽";
            // 
            // spinEditPicWidth
            // 
            this.spinEditPicWidth.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEditPicWidth.Location = new System.Drawing.Point(71, 35);
            this.spinEditPicWidth.Name = "spinEditPicWidth";
            this.spinEditPicWidth.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.spinEditPicWidth.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.spinEditPicWidth.Properties.Appearance.Options.UseBackColor = true;
            this.spinEditPicWidth.Properties.Appearance.Options.UseForeColor = true;
            this.spinEditPicWidth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditPicWidth.Properties.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.spinEditPicWidth.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEditPicWidth.Properties.MaxValue = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.spinEditPicWidth.Size = new System.Drawing.Size(71, 20);
            this.spinEditPicWidth.TabIndex = 1;
            // 
            // spinEditPicHeight
            // 
            this.spinEditPicHeight.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEditPicHeight.Location = new System.Drawing.Point(223, 35);
            this.spinEditPicHeight.Name = "spinEditPicHeight";
            this.spinEditPicHeight.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.spinEditPicHeight.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.spinEditPicHeight.Properties.Appearance.Options.UseBackColor = true;
            this.spinEditPicHeight.Properties.Appearance.Options.UseForeColor = true;
            this.spinEditPicHeight.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditPicHeight.Properties.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.spinEditPicHeight.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEditPicHeight.Properties.MaxValue = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.spinEditPicHeight.Size = new System.Drawing.Size(71, 20);
            this.spinEditPicHeight.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(167, 38);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 14);
            this.labelControl1.TabIndex = 26;
            this.labelControl1.Text = "图片高";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.spinEditDetectionHeight);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.spinEditDetectionWidth);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.spinEditDetectionY);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.spinEditDetectionX);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Location = new System.Drawing.Point(15, 72);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(298, 83);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "车牌检测区域";
            this.groupControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupControl1_Paint);
            // 
            // spinEditDetectionHeight
            // 
            this.spinEditDetectionHeight.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEditDetectionHeight.Location = new System.Drawing.Point(208, 51);
            this.spinEditDetectionHeight.Name = "spinEditDetectionHeight";
            this.spinEditDetectionHeight.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.spinEditDetectionHeight.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.spinEditDetectionHeight.Properties.Appearance.Options.UseBackColor = true;
            this.spinEditDetectionHeight.Properties.Appearance.Options.UseForeColor = true;
            this.spinEditDetectionHeight.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditDetectionHeight.Properties.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.spinEditDetectionHeight.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEditDetectionHeight.Properties.MaxValue = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.spinEditDetectionHeight.Size = new System.Drawing.Size(71, 20);
            this.spinEditDetectionHeight.TabIndex = 3;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(161, 54);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(12, 14);
            this.labelControl5.TabIndex = 32;
            this.labelControl5.Text = "高";
            // 
            // spinEditDetectionWidth
            // 
            this.spinEditDetectionWidth.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEditDetectionWidth.Location = new System.Drawing.Point(56, 51);
            this.spinEditDetectionWidth.Name = "spinEditDetectionWidth";
            this.spinEditDetectionWidth.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.spinEditDetectionWidth.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.spinEditDetectionWidth.Properties.Appearance.Options.UseBackColor = true;
            this.spinEditDetectionWidth.Properties.Appearance.Options.UseForeColor = true;
            this.spinEditDetectionWidth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditDetectionWidth.Properties.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.spinEditDetectionWidth.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEditDetectionWidth.Properties.MaxValue = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.spinEditDetectionWidth.Size = new System.Drawing.Size(71, 20);
            this.spinEditDetectionWidth.TabIndex = 2;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(9, 54);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(12, 14);
            this.labelControl6.TabIndex = 30;
            this.labelControl6.Text = "宽";
            // 
            // spinEditDetectionY
            // 
            this.spinEditDetectionY.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEditDetectionY.Location = new System.Drawing.Point(208, 25);
            this.spinEditDetectionY.Name = "spinEditDetectionY";
            this.spinEditDetectionY.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.spinEditDetectionY.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.spinEditDetectionY.Properties.Appearance.Options.UseBackColor = true;
            this.spinEditDetectionY.Properties.Appearance.Options.UseForeColor = true;
            this.spinEditDetectionY.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditDetectionY.Properties.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.spinEditDetectionY.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEditDetectionY.Properties.MaxValue = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.spinEditDetectionY.Size = new System.Drawing.Size(71, 20);
            this.spinEditDetectionY.TabIndex = 1;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(161, 28);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(36, 14);
            this.labelControl4.TabIndex = 28;
            this.labelControl4.Text = "起点 Y";
            // 
            // spinEditDetectionX
            // 
            this.spinEditDetectionX.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEditDetectionX.Location = new System.Drawing.Point(56, 25);
            this.spinEditDetectionX.Name = "spinEditDetectionX";
            this.spinEditDetectionX.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.spinEditDetectionX.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.spinEditDetectionX.Properties.Appearance.Options.UseBackColor = true;
            this.spinEditDetectionX.Properties.Appearance.Options.UseForeColor = true;
            this.spinEditDetectionX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditDetectionX.Properties.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.spinEditDetectionX.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEditDetectionX.Properties.MaxValue = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.spinEditDetectionX.Size = new System.Drawing.Size(71, 20);
            this.spinEditDetectionX.TabIndex = 0;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(9, 28);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(35, 14);
            this.labelControl3.TabIndex = 26;
            this.labelControl3.Text = "起点 X";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.spinEditPlateAreaH);
            this.groupControl2.Controls.Add(this.labelControl8);
            this.groupControl2.Controls.Add(this.spinEditPlateAreaW);
            this.groupControl2.Controls.Add(this.labelControl9);
            this.groupControl2.Controls.Add(this.spinEditPlateAreaY);
            this.groupControl2.Controls.Add(this.labelControl10);
            this.groupControl2.Controls.Add(this.spinEditPlateAreaX);
            this.groupControl2.Controls.Add(this.labelControl11);
            this.groupControl2.Location = new System.Drawing.Point(15, 170);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(298, 83);
            this.groupControl2.TabIndex = 4;
            this.groupControl2.Text = "车牌位置标定";
            // 
            // spinEditPlateAreaH
            // 
            this.spinEditPlateAreaH.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEditPlateAreaH.Location = new System.Drawing.Point(208, 51);
            this.spinEditPlateAreaH.Name = "spinEditPlateAreaH";
            this.spinEditPlateAreaH.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.spinEditPlateAreaH.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.spinEditPlateAreaH.Properties.Appearance.Options.UseBackColor = true;
            this.spinEditPlateAreaH.Properties.Appearance.Options.UseForeColor = true;
            this.spinEditPlateAreaH.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditPlateAreaH.Properties.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.spinEditPlateAreaH.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEditPlateAreaH.Properties.MaxValue = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.spinEditPlateAreaH.Size = new System.Drawing.Size(71, 20);
            this.spinEditPlateAreaH.TabIndex = 3;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(161, 54);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(12, 14);
            this.labelControl8.TabIndex = 32;
            this.labelControl8.Text = "高";
            // 
            // spinEditPlateAreaW
            // 
            this.spinEditPlateAreaW.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEditPlateAreaW.Location = new System.Drawing.Point(56, 51);
            this.spinEditPlateAreaW.Name = "spinEditPlateAreaW";
            this.spinEditPlateAreaW.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.spinEditPlateAreaW.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.spinEditPlateAreaW.Properties.Appearance.Options.UseBackColor = true;
            this.spinEditPlateAreaW.Properties.Appearance.Options.UseForeColor = true;
            this.spinEditPlateAreaW.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditPlateAreaW.Properties.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.spinEditPlateAreaW.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEditPlateAreaW.Properties.MaxValue = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.spinEditPlateAreaW.Size = new System.Drawing.Size(71, 20);
            this.spinEditPlateAreaW.TabIndex = 2;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(9, 54);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(12, 14);
            this.labelControl9.TabIndex = 30;
            this.labelControl9.Text = "宽";
            // 
            // spinEditPlateAreaY
            // 
            this.spinEditPlateAreaY.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEditPlateAreaY.Location = new System.Drawing.Point(208, 25);
            this.spinEditPlateAreaY.Name = "spinEditPlateAreaY";
            this.spinEditPlateAreaY.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.spinEditPlateAreaY.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.spinEditPlateAreaY.Properties.Appearance.Options.UseBackColor = true;
            this.spinEditPlateAreaY.Properties.Appearance.Options.UseForeColor = true;
            this.spinEditPlateAreaY.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditPlateAreaY.Properties.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.spinEditPlateAreaY.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEditPlateAreaY.Properties.MaxValue = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.spinEditPlateAreaY.Size = new System.Drawing.Size(71, 20);
            this.spinEditPlateAreaY.TabIndex = 1;
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(161, 28);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(36, 14);
            this.labelControl10.TabIndex = 28;
            this.labelControl10.Text = "起点 Y";
            // 
            // spinEditPlateAreaX
            // 
            this.spinEditPlateAreaX.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEditPlateAreaX.Location = new System.Drawing.Point(56, 25);
            this.spinEditPlateAreaX.Name = "spinEditPlateAreaX";
            this.spinEditPlateAreaX.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.spinEditPlateAreaX.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.spinEditPlateAreaX.Properties.Appearance.Options.UseBackColor = true;
            this.spinEditPlateAreaX.Properties.Appearance.Options.UseForeColor = true;
            this.spinEditPlateAreaX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditPlateAreaX.Properties.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.spinEditPlateAreaX.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEditPlateAreaX.Properties.MaxValue = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.spinEditPlateAreaX.Size = new System.Drawing.Size(71, 20);
            this.spinEditPlateAreaX.TabIndex = 0;
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(9, 28);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(35, 14);
            this.labelControl11.TabIndex = 26;
            this.labelControl11.Text = "起点 X";
            // 
            // radioGroupPlateLocationType
            // 
            this.radioGroupPlateLocationType.Location = new System.Drawing.Point(15, 359);
            this.radioGroupPlateLocationType.Name = "radioGroupPlateLocationType";
            this.radioGroupPlateLocationType.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(55)))));
            this.radioGroupPlateLocationType.Properties.Appearance.Options.UseForeColor = true;
            this.radioGroupPlateLocationType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "不限"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "前排"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "尾牌")});
            this.radioGroupPlateLocationType.Properties.LookAndFeel.SkinName = "Metropolis";
            this.radioGroupPlateLocationType.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.radioGroupPlateLocationType.Size = new System.Drawing.Size(298, 38);
            this.radioGroupPlateLocationType.TabIndex = 6;
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(15, 339);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(48, 14);
            this.labelControl12.TabIndex = 36;
            this.labelControl12.Text = "车牌位置";
            // 
            // labelControl13
            // 
            this.labelControl13.Location = new System.Drawing.Point(15, 405);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(48, 14);
            this.labelControl13.TabIndex = 37;
            this.labelControl13.Text = "起始时间";
            // 
            // timeEditStart
            // 
            this.timeEditStart.EditValue = new System.DateTime(2014, 1, 17, 0, 0, 0, 0);
            this.timeEditStart.Location = new System.Drawing.Point(121, 403);
            this.timeEditStart.Name = "timeEditStart";
            this.timeEditStart.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.timeEditStart.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.timeEditStart.Properties.Appearance.Options.UseBackColor = true;
            this.timeEditStart.Properties.Appearance.Options.UseForeColor = true;
            this.timeEditStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.timeEditStart.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.timeEditStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditStart.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.timeEditStart.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditStart.Properties.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.timeEditStart.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.timeEditStart.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
            this.timeEditStart.Size = new System.Drawing.Size(143, 20);
            this.timeEditStart.TabIndex = 7;
            // 
            // spinEdit1SnapshotInterval
            // 
            this.spinEdit1SnapshotInterval.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEdit1SnapshotInterval.Location = new System.Drawing.Point(121, 428);
            this.spinEdit1SnapshotInterval.Name = "spinEdit1SnapshotInterval";
            this.spinEdit1SnapshotInterval.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.spinEdit1SnapshotInterval.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.spinEdit1SnapshotInterval.Properties.Appearance.Options.UseBackColor = true;
            this.spinEdit1SnapshotInterval.Properties.Appearance.Options.UseForeColor = true;
            this.spinEdit1SnapshotInterval.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit1SnapshotInterval.Properties.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.spinEdit1SnapshotInterval.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit1SnapshotInterval.Properties.MaxValue = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.spinEdit1SnapshotInterval.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEdit1SnapshotInterval.Size = new System.Drawing.Size(68, 20);
            this.spinEdit1SnapshotInterval.TabIndex = 8;
            // 
            // labelControl14
            // 
            this.labelControl14.Location = new System.Drawing.Point(17, 431);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(98, 14);
            this.labelControl14.TabIndex = 39;
            this.labelControl14.Text = "图片间隔时间 (秒)";
            // 
            // spinEditCameraId
            // 
            this.spinEditCameraId.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEditCameraId.Location = new System.Drawing.Point(71, 9);
            this.spinEditCameraId.Name = "spinEditCameraId";
            this.spinEditCameraId.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.spinEditCameraId.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.spinEditCameraId.Properties.Appearance.Options.UseBackColor = true;
            this.spinEditCameraId.Properties.Appearance.Options.UseForeColor = true;
            this.spinEditCameraId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditCameraId.Properties.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.spinEditCameraId.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEditCameraId.Properties.MaxValue = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.spinEditCameraId.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.spinEditCameraId.Size = new System.Drawing.Size(223, 20);
            this.spinEditCameraId.TabIndex = 0;
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.spinEditPlateRangeMax);
            this.groupControl3.Controls.Add(this.labelControl18);
            this.groupControl3.Controls.Add(this.labelControl15);
            this.groupControl3.Controls.Add(this.spinEditPlateRangeMin);
            this.groupControl3.Location = new System.Drawing.Point(15, 267);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(298, 60);
            this.groupControl3.TabIndex = 5;
            this.groupControl3.Text = "车牌像素范围";
            // 
            // spinEditPlateRangeMax
            // 
            this.spinEditPlateRangeMax.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditPlateRangeMax.Location = new System.Drawing.Point(211, 25);
            this.spinEditPlateRangeMax.Name = "spinEditPlateRangeMax";
            this.spinEditPlateRangeMax.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.spinEditPlateRangeMax.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.spinEditPlateRangeMax.Properties.Appearance.Options.UseBackColor = true;
            this.spinEditPlateRangeMax.Properties.Appearance.Options.UseForeColor = true;
            this.spinEditPlateRangeMax.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditPlateRangeMax.Properties.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.spinEditPlateRangeMax.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEditPlateRangeMax.Properties.MaxValue = new decimal(new int[] {
            700,
            0,
            0,
            0});
            this.spinEditPlateRangeMax.Properties.MinValue = new decimal(new int[] {
            70,
            0,
            0,
            0});
            this.spinEditPlateRangeMax.Size = new System.Drawing.Size(71, 20);
            this.spinEditPlateRangeMax.TabIndex = 1;
            // 
            // labelControl18
            // 
            this.labelControl18.Location = new System.Drawing.Point(9, 28);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Size = new System.Drawing.Size(12, 14);
            this.labelControl18.TabIndex = 26;
            this.labelControl18.Text = "从";
            // 
            // labelControl15
            // 
            this.labelControl15.Location = new System.Drawing.Point(165, 28);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(12, 14);
            this.labelControl15.TabIndex = 35;
            this.labelControl15.Text = "至";
            // 
            // spinEditPlateRangeMin
            // 
            this.spinEditPlateRangeMin.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditPlateRangeMin.Location = new System.Drawing.Point(59, 25);
            this.spinEditPlateRangeMin.Name = "spinEditPlateRangeMin";
            this.spinEditPlateRangeMin.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.spinEditPlateRangeMin.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.spinEditPlateRangeMin.Properties.Appearance.Options.UseBackColor = true;
            this.spinEditPlateRangeMin.Properties.Appearance.Options.UseForeColor = true;
            this.spinEditPlateRangeMin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditPlateRangeMin.Properties.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.spinEditPlateRangeMin.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEditPlateRangeMin.Properties.MaxValue = new decimal(new int[] {
            700,
            0,
            0,
            0});
            this.spinEditPlateRangeMin.Properties.MinValue = new decimal(new int[] {
            70,
            0,
            0,
            0});
            this.spinEditPlateRangeMin.Size = new System.Drawing.Size(71, 20);
            this.spinEditPlateRangeMin.TabIndex = 0;
            // 
            // FormVehicleDetectionSettings
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(341, 495);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.spinEditCameraId);
            this.Controls.Add(this.spinEdit1SnapshotInterval);
            this.Controls.Add(this.labelControl14);
            this.Controls.Add(this.timeEditStart);
            this.Controls.Add(this.labelControl13);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.radioGroupPlateLocationType);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.spinEditPicHeight);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.spinEditPicWidth);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormVehicleDetectionSettings";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "车辆检测辅助设置";
            this.Load += new System.EventHandler(this.FormVehicleDetectionSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spinEditPicWidth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditPicHeight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditDetectionHeight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditDetectionWidth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditDetectionY.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditDetectionX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditPlateAreaH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditPlateAreaW.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditPlateAreaY.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditPlateAreaX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupPlateLocationType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1SnapshotInterval.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditCameraId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditPlateRangeMax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditPlateRangeMin.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.SpinEdit spinEditPicWidth;
        private DevExpress.XtraEditors.SpinEdit spinEditPicHeight;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SpinEdit spinEditDetectionY;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SpinEdit spinEditDetectionX;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SpinEdit spinEditDetectionHeight;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SpinEdit spinEditDetectionWidth;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SpinEdit spinEditPlateAreaH;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.SpinEdit spinEditPlateAreaW;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.SpinEdit spinEditPlateAreaY;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.SpinEdit spinEditPlateAreaX;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.RadioGroup radioGroupPlateLocationType;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.TimeEdit timeEditStart;
        private DevExpress.XtraEditors.SpinEdit spinEdit1SnapshotInterval;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.SpinEdit spinEditCameraId;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.SpinEdit spinEditPlateRangeMax;
        private DevExpress.XtraEditors.LabelControl labelControl18;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.SpinEdit spinEditPlateRangeMin;
    }
}