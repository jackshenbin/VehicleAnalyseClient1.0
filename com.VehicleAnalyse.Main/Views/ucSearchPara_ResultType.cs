﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.VehicleAnalyse.Main.Views
{
    public class ucSearchPara_ResultType : ucSearchPara
    {

        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ComboBoxEdit cmbBoxEditResultType;
        
        public ucSearchPara_ResultType()
        {
            InitializeComponent();
            cmbBoxEdit = cmbBoxEditResultType;
        }

        private void InitializeComponent()
        {
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cmbBoxEditResultType = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBoxEditResultType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(2, 6);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(24, 14);
            this.labelControl3.TabIndex = 109;
            this.labelControl3.Text = "类型";
            // 
            // cmbBoxEditResultType
            // 
            this.cmbBoxEditResultType.EditValue = "不限";
            this.cmbBoxEditResultType.Location = new System.Drawing.Point(55, 3);
            this.cmbBoxEditResultType.Name = "cmbBoxEditResultType";
            this.cmbBoxEditResultType.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.cmbBoxEditResultType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbBoxEditResultType.Properties.Items.AddRange(new object[] {
            "不限",
            "有牌",
            "无牌",
            "未识别",
            "图片错误"});
            this.cmbBoxEditResultType.Properties.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.cmbBoxEditResultType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbBoxEditResultType.Size = new System.Drawing.Size(141, 20);
            this.cmbBoxEditResultType.TabIndex = 108;
            // 
            // ucSearchPara_ResultType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.cmbBoxEditResultType);
            this.Name = "ucSearchPara_ResultType";
            ((System.ComponentModel.ISupportInitialize)(this.cmbBoxEditResultType.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
