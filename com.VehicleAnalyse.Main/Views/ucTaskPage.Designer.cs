namespace com.VehicleAnalyse.Main.Views
{
    partial class ucTaskPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ucOutputWindow1 = new com.VehicleAnalyse.Main.Views.ucOutputWindow();
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            this.ucTaskList21 = new com.VehicleAnalyse.Main.Views.ucTaskList2();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucOutputWindow1
            // 
            this.ucOutputWindow1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucOutputWindow1.Location = new System.Drawing.Point(2, 22);
            this.ucOutputWindow1.Name = "ucOutputWindow1";
            this.ucOutputWindow1.Size = new System.Drawing.Size(865, 161);
            this.ucOutputWindow1.SwitchOn = false;
            this.ucOutputWindow1.TabIndex = 0;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(5, 6);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(113, 25);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "连接分析服务器";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // ucTaskList21
            // 
            this.ucTaskList21.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ucTaskList21.Appearance.Options.UseBackColor = true;
            this.ucTaskList21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTaskList21.Enabled = false;
            this.ucTaskList21.Location = new System.Drawing.Point(0, 57);
            this.ucTaskList21.Name = "ucTaskList21";
            this.ucTaskList21.Size = new System.Drawing.Size(869, 427);
            this.ucTaskList21.TabIndex = 5;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnLogin);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(869, 37);
            this.groupControl1.TabIndex = 7;
            this.groupControl1.Text = "groupControl1";
            this.groupControl1.Visible = false;
            // 
            // labelControl1
            // 
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl1.Location = new System.Drawing.Point(0, 37);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(869, 20);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "任务列表";
            // 
            // splitterControl1
            // 
            this.splitterControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitterControl1.Location = new System.Drawing.Point(0, 484);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(869, 5);
            this.splitterControl1.TabIndex = 1;
            this.splitterControl1.TabStop = false;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.ucOutputWindow1);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl2.Location = new System.Drawing.Point(0, 489);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(869, 185);
            this.groupControl2.TabIndex = 2;
            this.groupControl2.Text = "输出窗口";
            // 
            // ucTaskPage
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.ControlText;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucTaskList21);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.groupControl1);
            this.Name = "ucTaskPage";
            this.Size = new System.Drawing.Size(869, 674);
            this.Load += new System.EventHandler(this.ucTaskPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnLogin;
        private ucTaskList2 ucTaskList21;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private ucOutputWindow ucOutputWindow1;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
    }
}
