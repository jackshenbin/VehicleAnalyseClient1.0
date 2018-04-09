namespace com.VehicleAnalyse.Main.Views
{
    partial class FormLogin
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
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.textEditUser = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.textEditPass = new DevExpress.XtraEditors.TextEdit();
            this.spinEditServerPort = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.spinEditSearchPort = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.spinEditUploadPort = new DevExpress.XtraEditors.SpinEdit();
            this.textEditServerIP = new DevComponents.Editors.IpAddressInput();
            this.textEditSearchIP = new DevComponents.Editors.IpAddressInput();
            this.textEditUploadIP = new DevComponents.Editors.IpAddressInput();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditPass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditServerPort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditSearchPort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditUploadPort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditServerIP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditSearchIP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditUploadIP)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(134, 175);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(83, 30);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "登  录";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(249, 136);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "记住密码";
            this.checkEdit1.Size = new System.Drawing.Size(75, 19);
            this.checkEdit1.TabIndex = 5;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl3.Location = new System.Drawing.Point(50, 136);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(24, 14);
            this.labelControl3.TabIndex = 29;
            this.labelControl3.Text = "密码";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl2.Location = new System.Drawing.Point(50, 110);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 14);
            this.labelControl2.TabIndex = 31;
            this.labelControl2.Text = "用户名";
            // 
            // textEditUser
            // 
            this.textEditUser.EditValue = "admin";
            this.textEditUser.Location = new System.Drawing.Point(115, 110);
            this.textEditUser.Name = "textEditUser";
            this.textEditUser.Properties.MaxLength = 31;
            this.textEditUser.Size = new System.Drawing.Size(128, 20);
            this.textEditUser.TabIndex = 3;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl4.Location = new System.Drawing.Point(50, 15);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(48, 14);
            this.labelControl4.TabIndex = 30;
            this.labelControl4.Text = "主机地址";
            // 
            // textEditPass
            // 
            this.textEditPass.EditValue = "admin";
            this.textEditPass.Location = new System.Drawing.Point(115, 136);
            this.textEditPass.Name = "textEditPass";
            this.textEditPass.Properties.MaxLength = 31;
            this.textEditPass.Properties.PasswordChar = '*';
            this.textEditPass.Properties.UseSystemPasswordChar = true;
            this.textEditPass.Size = new System.Drawing.Size(128, 20);
            this.textEditPass.TabIndex = 4;
            // 
            // spinEditServerPort
            // 
            this.spinEditServerPort.EditValue = new decimal(new int[] {
            10007,
            0,
            0,
            0});
            this.spinEditServerPort.Location = new System.Drawing.Point(249, 15);
            this.spinEditServerPort.Name = "spinEditServerPort";
            this.spinEditServerPort.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditServerPort.Properties.MaxValue = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.spinEditServerPort.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEditServerPort.Size = new System.Drawing.Size(75, 20);
            this.spinEditServerPort.TabIndex = 7;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl1.Location = new System.Drawing.Point(50, 75);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 31;
            this.labelControl1.Text = "上传端口";
            // 
            // spinEditSearchPort
            // 
            this.spinEditSearchPort.EditValue = new decimal(new int[] {
            9012,
            0,
            0,
            0});
            this.spinEditSearchPort.Location = new System.Drawing.Point(249, 46);
            this.spinEditSearchPort.Name = "spinEditSearchPort";
            this.spinEditSearchPort.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditSearchPort.Properties.MaxValue = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.spinEditSearchPort.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEditSearchPort.Size = new System.Drawing.Size(75, 20);
            this.spinEditSearchPort.TabIndex = 8;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl5.Location = new System.Drawing.Point(50, 47);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(48, 14);
            this.labelControl5.TabIndex = 31;
            this.labelControl5.Text = "查询端口";
            // 
            // spinEditUploadPort
            // 
            this.spinEditUploadPort.EditValue = new decimal(new int[] {
            10005,
            0,
            0,
            0});
            this.spinEditUploadPort.Location = new System.Drawing.Point(249, 75);
            this.spinEditUploadPort.Name = "spinEditUploadPort";
            this.spinEditUploadPort.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditUploadPort.Properties.MaxValue = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.spinEditUploadPort.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEditUploadPort.Size = new System.Drawing.Size(75, 20);
            this.spinEditUploadPort.TabIndex = 9;
            // 
            // textEditServerIP
            // 
            this.textEditServerIP.AutoOverwrite = true;
            // 
            // 
            // 
            this.textEditServerIP.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textEditServerIP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textEditServerIP.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textEditServerIP.Location = new System.Drawing.Point(115, 15);
            this.textEditServerIP.Name = "textEditServerIP";
            this.textEditServerIP.Size = new System.Drawing.Size(128, 22);
            this.textEditServerIP.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.textEditServerIP.TabIndex = 0;
            // 
            // textEditSearchIP
            // 
            this.textEditSearchIP.AutoOverwrite = true;
            // 
            // 
            // 
            this.textEditSearchIP.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textEditSearchIP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textEditSearchIP.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textEditSearchIP.Location = new System.Drawing.Point(115, 44);
            this.textEditSearchIP.Name = "textEditSearchIP";
            this.textEditSearchIP.Size = new System.Drawing.Size(128, 22);
            this.textEditSearchIP.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.textEditSearchIP.TabIndex = 1;
            // 
            // textEditUploadIP
            // 
            this.textEditUploadIP.AutoOverwrite = true;
            // 
            // 
            // 
            this.textEditUploadIP.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textEditUploadIP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textEditUploadIP.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textEditUploadIP.Location = new System.Drawing.Point(115, 75);
            this.textEditUploadIP.Name = "textEditUploadIP";
            this.textEditUploadIP.Size = new System.Drawing.Size(128, 22);
            this.textEditUploadIP.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.textEditUploadIP.TabIndex = 2;
            // 
            // FormLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 217);
            this.Controls.Add(this.textEditUploadIP);
            this.Controls.Add(this.textEditSearchIP);
            this.Controls.Add(this.textEditServerIP);
            this.Controls.Add(this.spinEditUploadPort);
            this.Controls.Add(this.spinEditSearchPort);
            this.Controls.Add(this.spinEditServerPort);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.checkEdit1);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.textEditUser);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.textEditPass);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLogin";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "请登录服务器";
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditPass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditServerPort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditSearchPort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditUploadPort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditServerIP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditSearchIP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditUploadIP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnLogin;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit textEditUser;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit textEditPass;
        private DevExpress.XtraEditors.SpinEdit spinEditServerPort;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SpinEdit spinEditSearchPort;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SpinEdit spinEditUploadPort;
        private DevComponents.Editors.IpAddressInput textEditServerIP;
        private DevComponents.Editors.IpAddressInput textEditSearchIP;
        private DevComponents.Editors.IpAddressInput textEditUploadIP;
    }
}