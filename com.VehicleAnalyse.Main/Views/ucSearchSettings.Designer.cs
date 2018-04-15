namespace com.VehicleAnalyse.Main.Views
{
    partial class ucSearchSettings
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
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.pictureEdit2 = new DevExpress.XtraEditors.PictureEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.ucSearchSettingsContainer1 = new com.VehicleAnalyse.Main.Views.ucSearchSettingsContainer();
            this.simpleButtonClearSetting = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // radioGroup1
            // 
            this.radioGroup1.EditValue = ((byte)(0));
            this.radioGroup1.Location = new System.Drawing.Point(288, 25);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioGroup1.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroup1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((byte)(0)), "前视图"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((byte)(1)), "后视图")});
            this.radioGroup1.Size = new System.Drawing.Size(170, 24);
            this.radioGroup1.TabIndex = 120;
            // 
            // labelControl13
            // 
            this.labelControl13.Location = new System.Drawing.Point(242, 29);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(36, 14);
            this.labelControl13.TabIndex = 119;
            this.labelControl13.Text = "车型图";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSearch.Appearance.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSearch.Appearance.BackColor2 = System.Drawing.SystemColors.HotTrack;
            this.btnSearch.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearch.Appearance.Options.UseBackColor = true;
            this.btnSearch.Appearance.Options.UseFont = true;
            this.btnSearch.Location = new System.Drawing.Point(151, 440);
            this.btnSearch.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(65, 24);
            this.btnSearch.TabIndex = 118;
            this.btnSearch.Text = "检 索";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pictureEdit2
            // 
            this.pictureEdit2.Location = new System.Drawing.Point(222, 56);
            this.pictureEdit2.Name = "pictureEdit2";
            this.pictureEdit2.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.pictureEdit2.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.pictureEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit2.Properties.Appearance.Options.UseForeColor = true;
            this.pictureEdit2.Properties.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.pictureEdit2.Properties.NullText = "没有图片";
            this.pictureEdit2.Properties.ShowMenu = false;
            this.pictureEdit2.Size = new System.Drawing.Size(385, 377);
            this.pictureEdit2.TabIndex = 117;
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl12.Location = new System.Drawing.Point(9, 4);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(78, 14);
            this.labelControl12.TabIndex = 108;
            this.labelControl12.Text = "设置查询条件";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Location = new System.Drawing.Point(80, 440);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(65, 24);
            this.simpleButton2.TabIndex = 122;
            this.simpleButton2.Text = "取 消";
            this.simpleButton2.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ucSearchSettingsContainer1
            // 
            this.ucSearchSettingsContainer1.AutoScroll = true;
            this.ucSearchSettingsContainer1.Location = new System.Drawing.Point(3, 20);
            this.ucSearchSettingsContainer1.Name = "ucSearchSettingsContainer1";
            this.ucSearchSettingsContainer1.Size = new System.Drawing.Size(213, 419);
            this.ucSearchSettingsContainer1.TabIndex = 127;
            // 
            // simpleButtonClearSetting
            // 
            this.simpleButtonClearSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.simpleButtonClearSetting.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButtonClearSetting.Appearance.Options.UseFont = true;
            this.simpleButtonClearSetting.Location = new System.Drawing.Point(3, 440);
            this.simpleButtonClearSetting.Name = "simpleButtonClearSetting";
            this.simpleButtonClearSetting.Size = new System.Drawing.Size(55, 24);
            this.simpleButtonClearSetting.TabIndex = 136;
            this.simpleButtonClearSetting.Text = "重置";
            this.simpleButtonClearSetting.Visible = false;
            this.simpleButtonClearSetting.Click += new System.EventHandler(this.simpleButtonClearSetting_Click);
            // 
            // ucSearchSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.simpleButtonClearSetting);
            this.Controls.Add(this.ucSearchSettingsContainer1);
            this.Controls.Add(this.radioGroup1);
            this.Controls.Add(this.labelControl13);
            this.Controls.Add(this.pictureEdit2);
            this.Controls.Add(this.labelControl12);
            this.Name = "ucSearchSettings";
            this.Size = new System.Drawing.Size(222, 470);
            this.Load += new System.EventHandler(this.ucSearchSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.PictureEdit pictureEdit2;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private ucSearchSettingsContainer ucSearchSettingsContainer1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonClearSetting;
    }
}
