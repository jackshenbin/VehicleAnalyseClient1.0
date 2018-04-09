namespace VehicleHelper
{
    partial class ucSelectVehicleModel
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
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
                if (m_ViewModel != null)
                {
                    m_ViewModel.Dispose();
                }
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
            this.pictureCarStyle = new System.Windows.Forms.PictureBox();
            this.checkEditCarStyle = new DevExpress.XtraEditors.LabelControl();
            this.checkedComboBoxEdit1 = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCarStyle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedComboBoxEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureCarStyle
            // 
            this.pictureCarStyle.BackColor = System.Drawing.Color.Transparent;
            this.pictureCarStyle.Image = global::VehicleHelper.Properties.Resources._1565_questionmarkblue;
            this.pictureCarStyle.Location = new System.Drawing.Point(58, 0);
            this.pictureCarStyle.Name = "pictureCarStyle";
            this.pictureCarStyle.Size = new System.Drawing.Size(40, 40);
            this.pictureCarStyle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureCarStyle.TabIndex = 111;
            this.pictureCarStyle.TabStop = false;
            this.pictureCarStyle.Tag = "-1";
            this.pictureCarStyle.Click += new System.EventHandler(this.pictureCarStyle_Click);
            // 
            // checkEditCarStyle
            // 
            this.checkEditCarStyle.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.checkEditCarStyle.Location = new System.Drawing.Point(2, 10);
            this.checkEditCarStyle.Name = "checkEditCarStyle";
            this.checkEditCarStyle.Size = new System.Drawing.Size(24, 14);
            this.checkEditCarStyle.TabIndex = 112;
            this.checkEditCarStyle.Text = "品牌";
            // 
            // checkedComboBoxEdit1
            // 
            this.checkedComboBoxEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedComboBoxEdit1.Location = new System.Drawing.Point(57, 44);
            this.checkedComboBoxEdit1.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.checkedComboBoxEdit1.Name = "checkedComboBoxEdit1";
            this.checkedComboBoxEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.checkedComboBoxEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.checkedComboBoxEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.checkedComboBoxEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.checkedComboBoxEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.checkedComboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.checkedComboBoxEdit1.Properties.CloseOnLostFocus = false;
            this.checkedComboBoxEdit1.Properties.CloseOnOuterMouseClick = false;
            this.checkedComboBoxEdit1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.checkedComboBoxEdit1.Properties.DisplayMember = "Name";
            this.checkedComboBoxEdit1.Properties.HideSelection = false;
            this.checkedComboBoxEdit1.Properties.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.checkedComboBoxEdit1.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.checkedComboBoxEdit1.Properties.PopupFormMinSize = new System.Drawing.Size(120, 160);
            this.checkedComboBoxEdit1.Properties.SelectAllItemCaption = "全选";
            this.checkedComboBoxEdit1.Size = new System.Drawing.Size(106, 20);
            this.checkedComboBoxEdit1.TabIndex = 123;
            this.checkedComboBoxEdit1.Popup += new System.EventHandler(this.checkedComboBoxEdit1_Popup);
            this.checkedComboBoxEdit1.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.checkedComboBoxEdit1_CloseUp);
            this.checkedComboBoxEdit1.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.checkedComboBoxEdit1_CustomDisplayText);
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.labelControl6.Location = new System.Drawing.Point(2, 47);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(48, 14);
            this.labelControl6.TabIndex = 122;
            this.labelControl6.Text = "车辆型号";
            // 
            // ucSelectVehicleModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkedComboBoxEdit1);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.checkEditCarStyle);
            this.Controls.Add(this.pictureCarStyle);
            this.Name = "ucSelectVehicleModel";
            this.Size = new System.Drawing.Size(169, 42);
            this.Load += new System.EventHandler(this.ucSelectVehicleModel_Load);
            this.Resize += new System.EventHandler(this.ucSelectVehicleModel_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureCarStyle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedComboBoxEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureCarStyle;
        private DevExpress.XtraEditors.LabelControl checkEditCarStyle;
        private DevExpress.XtraEditors.CheckedComboBoxEdit checkedComboBoxEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl6;

    }
}
