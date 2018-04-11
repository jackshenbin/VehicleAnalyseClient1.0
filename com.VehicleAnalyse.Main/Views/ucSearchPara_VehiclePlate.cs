using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace com.VehicleAnalyse.Main.Views
{
    public class ucSearchPara_VehiclePlate : ucSearchPara
    {
        private DevExpress.XtraEditors.MRUEdit comboBoxEditPlateNo;
        private DevExpress.XtraEditors.CheckEdit checkEditNonePlate;
        private DevExpress.XtraEditors.LabelControl checkEditPlantNo;


        [Bindable(true)]
        public string VehicleNumber
        {
            get
            {
                if (checkEditNonePlate.Checked)
                {
                    return DataModel.Constant.NONEPLATE;
                }
                return comboBoxEditPlateNo.Text;
            }
            set
            {
                if (value == DataModel.Constant.NONEPLATE)
                {
                    checkEditNonePlate.Checked = true;
                    comboBoxEditPlateNo.Enabled = false; 
                    comboBoxEditPlateNo.Text = "无牌车";
                }
                else
                {
                    checkEditNonePlate.Checked = false;
                    comboBoxEditPlateNo.Enabled = true; 
                    comboBoxEditPlateNo.Text = value;
                }
            }
        }


        public ucSearchPara_VehiclePlate()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.comboBoxEditPlateNo = new DevExpress.XtraEditors.MRUEdit();
            this.checkEditPlantNo = new DevExpress.XtraEditors.LabelControl();
            this.checkEditNonePlate = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditPlateNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditNonePlate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxEditPlateNo
            // 
            this.comboBoxEditPlateNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxEditPlateNo.EditValue = "沪A123456";
            this.comboBoxEditPlateNo.Location = new System.Drawing.Point(55, 3);
            this.comboBoxEditPlateNo.Name = "comboBoxEditPlateNo";
            this.comboBoxEditPlateNo.Properties.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.comboBoxEditPlateNo.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.comboBoxEditPlateNo.Properties.AppearanceDropDown.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.comboBoxEditPlateNo.Properties.AppearanceDropDown.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.comboBoxEditPlateNo.Properties.AppearanceDropDown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.comboBoxEditPlateNo.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.comboBoxEditPlateNo.Properties.AppearanceDropDown.Options.UseBorderColor = true;
            this.comboBoxEditPlateNo.Properties.AppearanceDropDown.Options.UseForeColor = true;
            this.comboBoxEditPlateNo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.comboBoxEditPlateNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditPlateNo.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.comboBoxEditPlateNo.Properties.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
            this.comboBoxEditPlateNo.Properties.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.comboBoxEditPlateNo.Size = new System.Drawing.Size(141, 20);
            this.comboBoxEditPlateNo.TabIndex = 104;
            // 
            // checkEditPlantNo
            // 
            this.checkEditPlantNo.Location = new System.Drawing.Point(2, 7);
            this.checkEditPlantNo.Name = "checkEditPlantNo";
            this.checkEditPlantNo.Size = new System.Drawing.Size(24, 14);
            this.checkEditPlantNo.TabIndex = 105;
            this.checkEditPlantNo.Text = "车牌";
            // 
            // checkEditNonePlate
            // 
            this.checkEditNonePlate.Location = new System.Drawing.Point(53, 27);
            this.checkEditNonePlate.Name = "checkEditNonePlate";
            this.checkEditNonePlate.Properties.Caption = "无牌车";
            this.checkEditNonePlate.Properties.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.checkEditNonePlate.Size = new System.Drawing.Size(140, 19);
            this.checkEditNonePlate.TabIndex = 106;
            this.checkEditNonePlate.CheckedChanged += new System.EventHandler(this.checkEditNonePlate_CheckedChanged);
            // 
            // ucSearchPara_VehiclePlate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.Controls.Add(this.checkEditNonePlate);
            this.Controls.Add(this.comboBoxEditPlateNo);
            this.Controls.Add(this.checkEditPlantNo);
            this.Name = "ucSearchPara_VehiclePlate";
            this.Size = new System.Drawing.Size(196, 49);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditPlateNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditNonePlate.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void checkEditNonePlate_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxEditPlateNo.Enabled = !checkEditNonePlate.Checked;
            if (!checkEditNonePlate.Checked && comboBoxEditPlateNo.Text == "无牌车")
                comboBoxEditPlateNo.Text = "";
        }
    }
}
