using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.VehicleAnalyse.DataModel;
using System.Drawing;
using System.ComponentModel;

namespace com.VehicleAnalyse.Main.Views
{
    public class ucSearchPara_Task : ucSearchPara
    {

        private DevExpress.XtraEditors.CheckedComboBoxEdit cmbBoxTasks;
        private DevExpress.XtraEditors.LabelControl labelControl2;

        public ucSearchPara_Task()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.cmbBoxTasks = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBoxTasks.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbBoxTasks
            // 
            this.cmbBoxTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBoxTasks.EditValue = "";
            this.cmbBoxTasks.Location = new System.Drawing.Point(55, 3);
            this.cmbBoxTasks.Name = "cmbBoxTasks";
            this.cmbBoxTasks.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.cmbBoxTasks.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.cmbBoxTasks.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbBoxTasks.Properties.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.cmbBoxTasks.Properties.NullText = "[EditValue is null]";
            this.cmbBoxTasks.Properties.PopupFormMinSize = new System.Drawing.Size(190, 20);
            this.cmbBoxTasks.Size = new System.Drawing.Size(141, 20);
            this.cmbBoxTasks.TabIndex = 103;
            this.cmbBoxTasks.EditValueChanged += new System.EventHandler(this.cmbBoxTasks_EditValueChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(2, 5);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(24, 14);
            this.labelControl2.TabIndex = 102;
            this.labelControl2.Text = "任务";
            // 
            // ucSearchPara_Task
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.Controls.Add(this.cmbBoxTasks);
            this.Controls.Add(this.labelControl2);
            this.Name = "ucSearchPara_Task";
            ((System.ComponentModel.ISupportInitialize)(this.cmbBoxTasks.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        void cmbBoxTasks_EditValueChanged(object sender, EventArgs e)
        {
            List<AnalyseTask> t = new List<AnalyseTask>();
            foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem item in  cmbBoxTasks.Properties.Items)
            {
                if (item.CheckState == System.Windows.Forms.CheckState.Checked)
                    t.Add(item.Value as AnalyseTask);
            }
            SelectedValue = t.ToArray();
            RaisePropertyChangedEvent(null);
        }

        private void FillupTasks(AnalyseTask[] tasks)
        {
            cmbBoxTasks.Properties.Items.Clear();

            if (tasks != null && tasks.Length > 0)
            {
                cmbBoxTasks.Properties.Items.AddRange(tasks);

            }
            else
            {

            }
        }

        public override void Init(object para)
        {
            this.cmbBoxTasks.Properties.PopupFormMinSize = new Size(
               this.cmbBoxTasks.Width, this.cmbBoxTasks.Properties.PopupFormMinSize.Height);

            FillupTasks(para as AnalyseTask[]);
        }

        public override void Update(object para)
        {
            FillupTasks(para as AnalyseTask[]);
        }

    }
}
