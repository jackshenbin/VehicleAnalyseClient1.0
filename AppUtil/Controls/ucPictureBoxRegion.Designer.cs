namespace AppUtil.Controls
{
    partial class ucPictureBoxRegion
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.labelRegion = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // labelRegion
            // 
            this.labelRegion.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelRegion.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelRegion.BackgroundStyle.BorderBottomWidth = 2;
            this.labelRegion.BackgroundStyle.BorderColor = System.Drawing.Color.Red;
            this.labelRegion.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelRegion.BackgroundStyle.BorderLeftWidth = 2;
            this.labelRegion.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelRegion.BackgroundStyle.BorderRightWidth = 2;
            this.labelRegion.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelRegion.BackgroundStyle.BorderTopWidth = 2;
            this.labelRegion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelRegion.Location = new System.Drawing.Point(462, 350);
            this.labelRegion.Name = "labelRegion";
            this.labelRegion.Size = new System.Drawing.Size(15, 15);
            this.labelRegion.TabIndex = 2;
            this.labelRegion.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.labelRegion.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
            this.labelRegion.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            this.labelRegion.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.labelRegion.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // ucPictureBoxRegion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.labelRegion);
            this.DoubleBuffered = true;
            this.Name = "ucPictureBoxRegion";
            this.Size = new System.Drawing.Size(480, 368);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelRegion;


    }
}
