using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.VehicleAnalyse.DataModel;
using VehicleHelper.DataModel;

namespace com.VehicleAnalyse.Main.Views
{
    public class ucSearchPara_VehicleType : ucSearchPara
    {
        private DevExpress.XtraEditors.ComboBoxEdit cmbBoxVehicleDetailType;
        private DevExpress.XtraEditors.LabelControl labelControl4;

        public ucSearchPara_VehicleType()
        {
            InitializeComponent();
            cmbBoxEdit = cmbBoxVehicleDetailType;
        }

        private void InitializeComponent()
        {
            this.cmbBoxVehicleDetailType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBoxVehicleDetailType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbBoxVehicleDetailType
            // 
            this.cmbBoxVehicleDetailType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBoxVehicleDetailType.Location = new System.Drawing.Point(56, 3);
            this.cmbBoxVehicleDetailType.Name = "cmbBoxVehicleDetailType";
            this.cmbBoxVehicleDetailType.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.cmbBoxVehicleDetailType.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.cmbBoxVehicleDetailType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbBoxVehicleDetailType.Properties.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.cmbBoxVehicleDetailType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbBoxVehicleDetailType.Size = new System.Drawing.Size(140, 20);
            this.cmbBoxVehicleDetailType.TabIndex = 107;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(2, 7);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(48, 14);
            this.labelControl4.TabIndex = 108;
            this.labelControl4.Text = "车辆粗分";
            // 
            // ucSearchPara_VehicleType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.Controls.Add(this.cmbBoxVehicleDetailType);
            this.Controls.Add(this.labelControl4);
            this.Name = "ucSearchPara_VehicleType";
            ((System.ComponentModel.ISupportInitialize)(this.cmbBoxVehicleDetailType.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        void cmbBoxVehicleDetailType_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            RaisePropertyChangedEvent(new System.ComponentModel.PropertyChangedEventArgs("VehicleType"));
        }

        public override void Init(object para)
        {
            List<VehiclePropertyInfo> vehicleDetailTypes = para as List<VehiclePropertyInfo>;

            cmbBoxVehicleDetailType.Properties.Items.Clear();
            cmbBoxVehicleDetailType.Properties.Items.AddRange(vehicleDetailTypes);
        }
    }
}
