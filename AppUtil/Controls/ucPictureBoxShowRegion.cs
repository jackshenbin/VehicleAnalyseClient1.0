using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppUtil.Controls
{
    public partial class ucPictureBoxShowRegion : UserControl
    {
        private DevComponents.DotNetBar.LabelX labelRegion;
        public event EventHandler GlobRectChanged;
        public Rectangle GlobRect { get { return calcGlobRect(); } }

        public Image Image { get { return this.BackgroundImage; } set { this.BackgroundImage = value; } }

        public ucPictureBoxShowRegion()
        {
            InitializeComponent();
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;

        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;

        }



        private Rectangle calcGlobRect()
        {
            if (this.BackgroundImage == null)
                return new Rectangle();

            return (Rectangle)labelRegion.Tag;

        }
        private void initGlobRect(Rectangle rect, DevComponents.DotNetBar.LabelX labelX)
        {
            if (this.BackgroundImage == null)
                return;

            float x_r = this.BackgroundImage.Width / (float)this.Width;
            float y_r = this.BackgroundImage.Height / (float)this.Height;

            int w = x_r > y_r ? this.Width : (int)(this.BackgroundImage.Width / y_r);
            int h = x_r > y_r ? this.Height : (int)(this.BackgroundImage.Height / y_r);
            int x = (this.Width - w) / 2;
            int y = (this.Height - h) / 2;

            Rectangle rectimagesmll = new Rectangle(x, y, w, h);

            Rectangle subrectsmall = new Rectangle((int)(rect.X / Math.Max(x_r, y_r)), (int)(rect.Y / Math.Max(x_r, y_r)), (int)(rect.Width / Math.Max(x_r, y_r)), (int)(rect.Height / Math.Max(x_r, y_r)));

            Rectangle globrect = new Rectangle(subrectsmall.X + rectimagesmll.X, subrectsmall.Y + rectimagesmll.Y, subrectsmall.Width, subrectsmall.Height);

            labelX.Location = globrect.Location;
            labelX.Size = globrect.Size;
        }
        public void initGlobRect(List<Rectangle> rect)
        {
            Controls.Clear();
            if (this.BackgroundImage == null)
                return;

            foreach (Rectangle item in rect)
            {
            DevComponents.DotNetBar.LabelX labelX = new DevComponents.DotNetBar.LabelX();
            labelX.BackColor = System.Drawing.Color.Transparent;
            labelX.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.DashDot;
            labelX.BackgroundStyle.BorderBottomWidth = 2;
            labelX.BackgroundStyle.BorderColor = System.Drawing.Color.Orange;
            labelX.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.DashDot;
            labelX.BackgroundStyle.BorderLeftWidth = 2;
            labelX.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.DashDot;
            labelX.BackgroundStyle.BorderRightWidth = 2;
            labelX.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.DashDot;
            labelX.BackgroundStyle.BorderTopWidth = 2;
            labelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX.Location = new System.Drawing.Point(462, 350);
            labelX.Size = new System.Drawing.Size(15, 15);
            labelX.TabIndex = 2;
            labelX.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
            labelX.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            labelX.MouseClick += labelX_MouseClick;
            labelX.Tag = item;

            this.Controls.Add(labelX);

            initGlobRect(item, labelX);
            }

            if (Controls.Count > 0)
            {
                labelRegion = Controls[0] as DevComponents.DotNetBar.LabelX;
                SelectRegion(labelRegion);
            }
        }


        void SelectRegion(DevComponents.DotNetBar.LabelX labelX)
        {
            foreach (var item in Controls)
            {
                DevComponents.DotNetBar.LabelX labeltemp = item as  DevComponents.DotNetBar.LabelX;
                if (labeltemp == labelX)
                { 
                    labelX.BackgroundStyle.BorderColor = System.Drawing.Color.SkyBlue;
                    labelX.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
                    labelX.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
                    labelX.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
                    labelX.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
                    labelX.Invalidate();
                }
                else
                {
                    UnSelectRegion(labeltemp);
                }
            }
        }
        void UnSelectRegion(DevComponents.DotNetBar.LabelX labelX)
        {
            labelX.BackgroundStyle.BorderColor = System.Drawing.Color.Orange;
            labelX.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Dot;
            labelX.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Dot;
            labelX.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Dot;
            labelX.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Dot;
            labelX.Invalidate();
        }

        void labelX_MouseClick(object sender, MouseEventArgs e)
        {
            labelRegion = sender as DevComponents.DotNetBar.LabelX;
            SelectRegion(labelRegion);
            if (GlobRectChanged != null)
                GlobRectChanged(sender, e);
        }
    }
}
