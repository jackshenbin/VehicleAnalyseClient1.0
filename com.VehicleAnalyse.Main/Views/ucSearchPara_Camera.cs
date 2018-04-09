using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.VehicleAnalyse.DataModel;
using System.Drawing;
using System.ComponentModel;

namespace com.VehicleAnalyse.Main.Views
{
    public class ucSearchPara_Camera : ucSearchPara
    {
        private DevExpress.XtraEditors.CheckedComboBoxEdit checkedComboBoxEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl2;

        public ucSearchPara_Camera()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.checkedComboBoxEdit1 = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedComboBoxEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.labelControl2.Location = new System.Drawing.Point(2, 5);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(24, 14);
            this.labelControl2.TabIndex = 102;
            this.labelControl2.Text = "相机";
            // 
            // checkedComboBoxEdit1
            // 
            this.checkedComboBoxEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedComboBoxEdit1.EditValue = "";
            this.checkedComboBoxEdit1.Location = new System.Drawing.Point(54, 3);
            this.checkedComboBoxEdit1.Name = "checkedComboBoxEdit1";
            this.checkedComboBoxEdit1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.checkedComboBoxEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.checkedComboBoxEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.checkedComboBoxEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.checkedComboBoxEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.checkedComboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.checkedComboBoxEdit1.Properties.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.checkedComboBoxEdit1.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.checkedComboBoxEdit1.Size = new System.Drawing.Size(141, 20);
            this.checkedComboBoxEdit1.TabIndex = 103;
            this.checkedComboBoxEdit1.EditValueChanged += new System.EventHandler(this.checkedComboBoxEdit1_EditValueChanged);
            // 
            // ucSearchPara_Camera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.Controls.Add(this.checkedComboBoxEdit1);
            this.Controls.Add(this.labelControl2);
            this.Name = "ucSearchPara_Camera";
            ((System.ComponentModel.ISupportInitialize)(this.checkedComboBoxEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        void checkedComboBoxEdit1_EditValueChanged(object sender, EventArgs e)
        {
            List<CameraInfo> t = new List<CameraInfo>();
            foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem item in checkedComboBoxEdit1.Properties.Items)
            {
                if (item.CheckState == System.Windows.Forms.CheckState.Checked)
                    t.Add(item.Value as CameraInfo);
            }
            SelectedValue = t.ToArray();

            RaisePropertyChangedEvent(null);
        }

        private void FillupCameras(CameraInfo[] cams)
        {
            checkedComboBoxEdit1.Properties.Items.Clear();

            if (cams != null && cams.Length > 0)
            {
                checkedComboBoxEdit1.Properties.Items.AddRange(cams);
            }
            else
            {

            }
        }

        public override void Init(object para)
        {
            this.checkedComboBoxEdit1.Properties.PopupFormMinSize = new Size(
               this.checkedComboBoxEdit1.Width, this.checkedComboBoxEdit1.Properties.PopupFormMinSize.Height);

            FillupCameras(para as CameraInfo[]);
        }

        public override void Update(object para)
        {
            FillupCameras(para as CameraInfo[]);
        }

        

    }
}
