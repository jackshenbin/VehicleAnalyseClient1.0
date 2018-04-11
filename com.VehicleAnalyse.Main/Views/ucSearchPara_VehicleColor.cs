using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using VehicleHelper.DataModel;

namespace com.VehicleAnalyse.Main.Views
{
    public class ucSearchPara_VehicleColor : ucSearchPara
    {
        private AppUtil.Controls.ColorComboBoxEx colorCmbBoxVehicle;
        private DevExpress.XtraEditors.LabelControl labelControl10;

        public ucSearchPara_VehicleColor()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.colorCmbBoxVehicle = new AppUtil.Controls.ColorComboBoxEx();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.colorCmbBoxVehicle.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // colorCmbBoxVehicle
            // 
            this.colorCmbBoxVehicle.Location = new System.Drawing.Point(55, 3);
            this.colorCmbBoxVehicle.Name = "colorCmbBoxVehicle";
            this.colorCmbBoxVehicle.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.colorCmbBoxVehicle.Properties.AppearanceDropDown.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.colorCmbBoxVehicle.Properties.AppearanceDropDown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.colorCmbBoxVehicle.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.colorCmbBoxVehicle.Properties.AppearanceDropDown.Options.UseForeColor = true;
            this.colorCmbBoxVehicle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorCmbBoxVehicle.Properties.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.colorCmbBoxVehicle.SelectedColor = System.Drawing.Color.Empty;
            this.colorCmbBoxVehicle.Size = new System.Drawing.Size(141, 20);
            this.colorCmbBoxVehicle.TabIndex = 115;
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(2, 7);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(48, 14);
            this.labelControl10.TabIndex = 114;
            this.labelControl10.Text = "车身颜色";
            // 
            // ucSearchPara_VehicleColor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.Controls.Add(this.colorCmbBoxVehicle);
            this.Controls.Add(this.labelControl10);
            this.Name = "ucSearchPara_VehicleColor";
            ((System.ComponentModel.ISupportInitialize)(this.colorCmbBoxVehicle.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public override void Init(object para)
        {
            List<VehiclePropertyInfo> platecolor = para as List<VehiclePropertyInfo>;
            AppUtil.Controls.ColorName[] val = platecolor.ConvertAll<AppUtil.Controls.ColorName>(item => DataModel.Constant.ConvertVehicleColor(item)).ToArray();
            colorCmbBoxVehicle.SetColors(val);
            colorCmbBoxVehicle.PropertyChanged += new PropertyChangedEventHandler(colorCmbBoxVehicle_PropertyChanged);
        }

        void colorCmbBoxVehicle_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (string.Compare(e.PropertyName, "SelectedColor", true) == 0)
            {
                SelectedValue = DataModel.Constant.ConvertVehicleColor(colorCmbBoxVehicle.SelectedColorName);
                RaisePropertyChangedEvent(e);
            }
        }
    }
}
