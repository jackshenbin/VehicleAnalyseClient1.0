using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using com.VehicleAnalyse.DataModel;
using VehicleHelper.DataModel;

namespace com.VehicleAnalyse.Main.Views
{
    public class ucSearchPara_Behavior : ucSearchPara
    {
        private DevExpress.XtraEditors.ComboBoxEdit cmbEditDriverBelt;
        private DevExpress.XtraEditors.LabelControl labelControl1;

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public string PropertyDisplayName
        {
            get
            {
                return this.labelControl1.Text;
            }
            set 
            {
                this.labelControl1.Text = value;
            }
        }

        public ucSearchPara_Behavior()
        {
            InitializeComponent();
            cmbBoxEdit = cmbEditDriverBelt;
        }

        private void InitializeComponent()
        {
            this.cmbEditDriverBelt = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEditDriverBelt.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbEditDriverBelt
            // 
            this.cmbEditDriverBelt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbEditDriverBelt.EditValue = "不限";
            this.cmbEditDriverBelt.Location = new System.Drawing.Point(100, 3);
            this.cmbEditDriverBelt.Name = "cmbEditDriverBelt";
            this.cmbEditDriverBelt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.cmbEditDriverBelt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbEditDriverBelt.Properties.Items.AddRange(new object[] {
            "不限",
            "未识别",
            "未系",
            "已系"});
            this.cmbEditDriverBelt.Properties.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.cmbEditDriverBelt.Properties.NullText = "[EditValue is null]";
            this.cmbEditDriverBelt.Properties.PopupFormMinSize = new System.Drawing.Size(190, 20);
            this.cmbEditDriverBelt.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbEditDriverBelt.Size = new System.Drawing.Size(96, 20);
            this.cmbEditDriverBelt.TabIndex = 126;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(2, 7);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(58, 14);
            this.labelControl1.TabIndex = 125;
            this.labelControl1.Text = "安全带(主)";
            // 
            // ucSearchPara_Behavior
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.Controls.Add(this.cmbEditDriverBelt);
            this.Controls.Add(this.labelControl1);
            this.Name = "ucSearchPara_Behavior";
            ((System.ComponentModel.ISupportInitialize)(this.cmbEditDriverBelt.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public override void Init(object para)
        {
            ICollection<VehiclePropertyInfo> items = para as ICollection<VehiclePropertyInfo>;
            if(items != null)
            {
                cmbBoxEdit.Properties.Items.Clear();
                cmbBoxEdit.Properties.Items.AddRange(items.ToArray());
            }

            this.cmbEditDriverBelt.Properties.PopupFormMinSize = new Size(
                this.cmbEditDriverBelt.Width, this.cmbEditDriverBelt.Properties.PopupFormMinSize.Height);
        }
    }
}
