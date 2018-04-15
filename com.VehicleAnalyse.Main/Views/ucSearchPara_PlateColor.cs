using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using VehicleHelper.DataModel;

namespace com.VehicleAnalyse.Main.Views
{
    public class ucSearchPara_PlateColor : ucSearchPara
    {
        private AppUtil.Controls.ColorComboBoxEx colorCmbBoxPlate;
        private DevExpress.XtraEditors.LabelControl labelControl5;


        public ucSearchPara_PlateColor()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.colorCmbBoxPlate = new AppUtil.Controls.ColorComboBoxEx();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.colorCmbBoxPlate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // colorCmbBoxPlate
            // 
            this.colorCmbBoxPlate.Location = new System.Drawing.Point(55, 3);
            this.colorCmbBoxPlate.Name = "colorCmbBoxPlate";
            this.colorCmbBoxPlate.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.colorCmbBoxPlate.Properties.AppearanceDropDown.Options.UseForeColor = true;
            this.colorCmbBoxPlate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorCmbBoxPlate.Properties.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.colorCmbBoxPlate.SelectedColor = System.Drawing.Color.Empty;
            this.colorCmbBoxPlate.Size = new System.Drawing.Size(141, 20);
            this.colorCmbBoxPlate.TabIndex = 116;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(2, 6);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(48, 14);
            this.labelControl5.TabIndex = 115;
            this.labelControl5.Text = "车牌颜色";
            // 
            // ucSearchPara_PlateColor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.Controls.Add(this.colorCmbBoxPlate);
            this.Controls.Add(this.labelControl5);
            this.Name = "ucSearchPara_PlateColor";
            ((System.ComponentModel.ISupportInitialize)(this.colorCmbBoxPlate.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public override void Init(object para)
        {
            List<VehiclePropertyInfo> platecolor = para as List<VehiclePropertyInfo>;
            AppUtil.Controls.ColorName[] val = platecolor.ConvertAll < AppUtil.Controls.ColorName>(item => DataModel.Constant.ConvertPlateColor(item)).ToArray();
            colorCmbBoxPlate.SetColors(val);
            colorCmbBoxPlate.PropertyChanged += new PropertyChangedEventHandler(colorCmbBoxPlate_PropertyChanged);
        }

        void colorCmbBoxPlate_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (string.Compare(e.PropertyName, "SelectedColor", true) == 0)
            {
                SelectedValue =DataModel.Constant.ConvertPlateColor( colorCmbBoxPlate.SelectedColorName);
                RaisePropertyChangedEvent(e);
            }
        }


    }
}
