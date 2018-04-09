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
    public partial class ucPictureBoxRegion : UserControl
    {
        public event EventHandler GlobRectChanged;
        public Rectangle GlobRect { get { return calcGlobRect(); } set { initGlobRect(value); } }

        public Image Image { get { return this.BackgroundImage; } set { this.BackgroundImage = value; } }

        private bool isMove = false;
        bool isTop = false;
        bool isBottom = false;
        bool isLeft = false;
        bool isRight = false;
        private System.Drawing.Point startPoint = new System.Drawing.Point();
        private Rectangle startRect = new Rectangle();
        public ucPictureBoxRegion()
        {
            InitializeComponent();
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (top)
            { isTop = true; }
            else if (bottom)
            { isBottom = true; }
            else if (left)
            { isLeft = true; }
            else if (right)
            { isRight = true; }
            else
            {
                Cursor = Cursors.SizeAll;
                isMove = true;
            }
            startPoint = e.Location;
            startRect = new Rectangle(labelRegion.Location, labelRegion.Size);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
            isMove = false; startPoint = new System.Drawing.Point(); startRect = new Rectangle();
            isTop = false;
            isBottom = false;
            isLeft = false;
            isRight = false;
            if (GlobRectChanged != null)
                GlobRectChanged(sender, e);
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            isMove = false; startPoint = new System.Drawing.Point(); startRect = new Rectangle();
            isTop = false;
            isBottom = false;
            isLeft = false;
            isRight = false;

        }
        bool top = false;
        bool bottom = false;
        bool left = false;
        bool right = false;

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMove)
            {
                int x = e.Location.X - startPoint.X;
                int y = e.Location.Y - startPoint.Y;
                labelRegion.Location = new System.Drawing.Point(labelRegion.Location.X + x, labelRegion.Location.Y + y);
            }
            else if (isTop)
            {
                int x = e.Location.X - startPoint.X;
                int y = e.Location.Y - startPoint.Y;
                labelRegion.Location = new Point(startRect.Location.X, startRect.Location.Y + y);
                labelRegion.Height = startRect.Height - y;

            }
            else if (isBottom)
            {
                int x = e.Location.X - startPoint.X;
                int y = e.Location.Y - startPoint.Y;
                labelRegion.Height = startRect.Height + y;
            }
            else if (isLeft)
            {
                int x = e.Location.X - startPoint.X;
                int y = e.Location.Y - startPoint.Y;
                labelRegion.Location = new Point(startRect.Location.X + x, startRect.Location.Y);
                labelRegion.Width = startRect.Width - x;
            }
            else if (isRight)
            {
                int x = e.Location.X - startPoint.X;
                int y = e.Location.Y - startPoint.Y;
                labelRegion.Width = startRect.Width + x;
            }
            else
            {

                top = e.Location.Y <= 3;
                bottom = labelRegion.Height - e.Location.Y <= 3;
                left = e.Location.X <= 3;
                right = labelRegion.Width - e.Location.X <= 3;

                if (top)
                {
                    //if (left)
                    //    Cursor = Cursors.SizeNWSE;
                    //else if (right)
                    //    Cursor = Cursors.SizeNESW;
                    //else
                    Cursor = Cursors.SizeNS;

                }
                else if (bottom)
                {
                    //if (left)
                    //    Cursor = Cursors.SizeNESW;
                    //else if (right)
                    //    Cursor = Cursors.SizeNWSE;
                    //else
                    Cursor = Cursors.SizeNS;

                }
                else if (left)
                {
                    Cursor = Cursors.SizeWE;
                }
                else if (right)
                {
                    Cursor = Cursors.SizeWE;
                }
                else
                    Cursor = Cursors.Hand;
            }
        }


        private Rectangle calcGlobRect()
        {
            if (this.BackgroundImage == null)
                return new Rectangle();

            Rectangle rectsmall = new Rectangle(labelRegion.Location, labelRegion.Size);
            float x_r = this.BackgroundImage.Width / (float)this.Width;
            float y_r = this.BackgroundImage.Height / (float)this.Height;


            int w = x_r > y_r ? this.Width : (int)(this.BackgroundImage.Width / y_r);
            int h = x_r > y_r ? this.Height : (int)(this.BackgroundImage.Height / y_r);
            int x = (this.Width - w) / 2;
            int y = (this.Height - h) / 2;

            Rectangle rectimagesmll = new Rectangle(x, y, w, h);

            Rectangle subrectsmall = new Rectangle(rectsmall.X - rectimagesmll.X, rectsmall.Y - rectimagesmll.Y, rectsmall.Width, rectsmall.Height);

            Rectangle globrect = new Rectangle((int)(subrectsmall.X * Math.Max(x_r, y_r)), (int)(subrectsmall.Y * Math.Max(x_r, y_r)), (int)(subrectsmall.Width * Math.Max(x_r, y_r)), (int)(subrectsmall.Height * Math.Max(x_r, y_r)));
            return globrect;
        }
        private void initGlobRect(Rectangle rect)
        {
            if (this.BackgroundImage == null)
                return;
            if (rect == new Rectangle())
                rect = new Rectangle(100, 100, 100, 100);

            float x_r = this.BackgroundImage.Width / (float)this.Width;
            float y_r = this.BackgroundImage.Height / (float)this.Height;

            int w = x_r > y_r ? this.Width : (int)(this.BackgroundImage.Width / y_r);
            int h = x_r > y_r ? this.Height : (int)(this.BackgroundImage.Height / y_r);
            int x = (this.Width - w) / 2;
            int y = (this.Height - h) / 2;

            Rectangle rectimagesmll = new Rectangle(x, y, w, h);

            Rectangle subrectsmall = new Rectangle((int)(rect.X / Math.Max(x_r, y_r)), (int)(rect.Y / Math.Max(x_r, y_r)), (int)(rect.Width / Math.Max(x_r, y_r)), (int)(rect.Height / Math.Max(x_r, y_r)));

            Rectangle globrect = new Rectangle(subrectsmall.X + rectimagesmll.X, subrectsmall.Y + rectimagesmll.Y, subrectsmall.Width, subrectsmall.Height);

            labelRegion.Location = globrect.Location;
            labelRegion.Size = globrect.Size;
        }
    }
}
