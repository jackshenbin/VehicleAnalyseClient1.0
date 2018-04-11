using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.VehicleAnalyse.Main.Views
{
    public class ucSearchPara_StartTime : ucSearchPara
    {
        private DevExpress.XtraEditors.TimeEdit timeEdit1;

        private DevExpress.XtraEditors.LabelControl labelControl3;

        public ucSearchPara_StartTime()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.timeEdit1 = new DevExpress.XtraEditors.TimeEdit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(2, 6);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 14);
            this.labelControl3.TabIndex = 109;
            this.labelControl3.Text = "开始时间";
            // 
            // timeEdit1
            // 
            this.timeEdit1.EditValue = new System.DateTime(2017, 10, 10, 0, 0, 0, 0);
            this.timeEdit1.Location = new System.Drawing.Point(56, 4);
            this.timeEdit1.Name = "timeEdit1";
            this.timeEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.timeEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.timeEdit1.Properties.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.timeEdit1.Properties.Mask.EditMask = "G";
            this.timeEdit1.Size = new System.Drawing.Size(139, 20);
            this.timeEdit1.TabIndex = 110;
            // 
            // ucSearchPara_StartTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.Controls.Add(this.timeEdit1);
            this.Controls.Add(this.labelControl3);
            this.Name = "ucSearchPara_StartTime";
            this.Size = new System.Drawing.Size(198, 26);
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public override void Init(object para)
        {
            DateTime t = (DateTime)para;
            timeEdit1.EditValue = t;
            SelectedValue = timeEdit1.EditValue;
            timeEdit1.EditValueChanged += new EventHandler(timeEdit1_EditValueChanged);
        }

        void timeEdit1_EditValueChanged(object sender, EventArgs e)
        {
            SelectedValue = timeEdit1.EditValue;
            RaisePropertyChangedEvent(new System.ComponentModel.PropertyChangedEventArgs("StartTime"));
        }

    }
}
