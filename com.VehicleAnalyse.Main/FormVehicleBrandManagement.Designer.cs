namespace Bocom.ImageAnalysisClient.App
{
    partial class FormVehicleBrandManagement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.spinEditLocalPort = new DevExpress.XtraEditors.SpinEdit();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.spinEditBrandId = new DevExpress.XtraEditors.SpinEdit();
            this.btnGetBrandInfo = new DevExpress.XtraEditors.SimpleButton();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.spinEditParent = new DevExpress.XtraEditors.SpinEdit();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditLocalPort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditBrandId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditParent.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // spinEditLocalPort
            // 
            this.spinEditLocalPort.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.spinEditLocalPort.Location = new System.Drawing.Point(55, 22);
            this.spinEditLocalPort.Name = "spinEditLocalPort";
            this.spinEditLocalPort.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.spinEditLocalPort.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.spinEditLocalPort.Properties.Appearance.Options.UseBackColor = true;
            this.spinEditLocalPort.Properties.Appearance.Options.UseForeColor = true;
            this.spinEditLocalPort.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditLocalPort.Properties.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.spinEditLocalPort.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEditLocalPort.Properties.MaxValue = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.spinEditLocalPort.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.spinEditLocalPort.Size = new System.Drawing.Size(75, 20);
            this.spinEditLocalPort.TabIndex = 37;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.White;
            this.richTextBox1.Location = new System.Drawing.Point(12, 552);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(283, 44);
            this.richTextBox1.TabIndex = 38;
            this.richTextBox1.Text = "";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(692, 79);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 39;
            this.simpleButton1.Text = "添加";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(81, 79);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(565, 454);
            this.richTextBox2.TabIndex = 40;
            this.richTextBox2.Text = "";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(692, 123);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(97, 23);
            this.simpleButton2.TabIndex = 41;
            this.simpleButton2.Text = "添加一级品牌";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton3
            // 
            this.simpleButton3.Location = new System.Drawing.Point(692, 166);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(118, 23);
            this.simpleButton3.TabIndex = 42;
            this.simpleButton3.Text = "生成一级品牌表";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // spinEditBrandId
            // 
            this.spinEditBrandId.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.spinEditBrandId.Location = new System.Drawing.Point(735, 309);
            this.spinEditBrandId.Name = "spinEditBrandId";
            this.spinEditBrandId.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.spinEditBrandId.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.spinEditBrandId.Properties.Appearance.Options.UseBackColor = true;
            this.spinEditBrandId.Properties.Appearance.Options.UseForeColor = true;
            this.spinEditBrandId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditBrandId.Properties.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.spinEditBrandId.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEditBrandId.Properties.MaxValue = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.spinEditBrandId.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.spinEditBrandId.Size = new System.Drawing.Size(75, 20);
            this.spinEditBrandId.TabIndex = 43;
            // 
            // btnGetBrandInfo
            // 
            this.btnGetBrandInfo.Location = new System.Drawing.Point(829, 306);
            this.btnGetBrandInfo.Name = "btnGetBrandInfo";
            this.btnGetBrandInfo.Size = new System.Drawing.Size(104, 23);
            this.btnGetBrandInfo.TabIndex = 44;
            this.btnGetBrandInfo.Text = "获取车品牌信息";
            this.btnGetBrandInfo.Click += new System.EventHandler(this.btnGetBrandInfo_Click);
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(735, 357);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(132, 20);
            this.textEdit1.TabIndex = 45;
            // 
            // spinEditParent
            // 
            this.spinEditParent.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.spinEditParent.Location = new System.Drawing.Point(873, 357);
            this.spinEditParent.Name = "spinEditParent";
            this.spinEditParent.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.spinEditParent.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.spinEditParent.Properties.Appearance.Options.UseBackColor = true;
            this.spinEditParent.Properties.Appearance.Options.UseForeColor = true;
            this.spinEditParent.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditParent.Properties.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.spinEditParent.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEditParent.Properties.MaxValue = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.spinEditParent.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.spinEditParent.Size = new System.Drawing.Size(75, 20);
            this.spinEditParent.TabIndex = 46;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(873, 396);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 47;
            this.btnUpdate.Text = "更新";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(792, 396);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 47;
            this.btnAdd.Text = "添加";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // FormVehicleBrandManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 551);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.spinEditParent);
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.btnGetBrandInfo);
            this.Controls.Add(this.spinEditBrandId);
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.spinEditLocalPort);
            this.Name = "FormVehicleBrandManagement";
            this.Text = "FormVehicleBrandManagement";
            ((System.ComponentModel.ISupportInitialize)(this.spinEditLocalPort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditBrandId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditParent.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SpinEdit spinEditLocalPort;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SpinEdit spinEditBrandId;
        private DevExpress.XtraEditors.SimpleButton btnGetBrandInfo;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.SpinEdit spinEditParent;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
    }
}