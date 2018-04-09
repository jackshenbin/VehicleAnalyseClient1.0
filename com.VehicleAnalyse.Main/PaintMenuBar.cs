using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Bocom.ImageAnalysisClient.App;
using DevExpress.XtraBars;

namespace Bocom.ImageAnalysisClient.App
{
    /// <summary>
    /// Summary description for PaintMenuBar.
    /// </summary>
    public partial class PaintMenuBar : TutorialControl {
        public PaintMenuBar() {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            // barManager1.Images = TutorialHelper.GetTutorialImageCollection();
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        private Rectangle CaptionTransform(Graphics g, Rectangle r) {
            g.RotateTransform(-90);
            r.X = r.X - r.Height + 5;
            r.Width = r.Height;
            return r;
        }

        private void item_PaintMenuBar(DevExpress.XtraBars.BarCustomDrawEventArgs e, Color c1, Color c2, string caption) {
            Rectangle r = e.Bounds;
            r.Inflate(1, 1);
            System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(r, c1, c2, -90);
            e.Graphics.FillRectangle(brush, e.Bounds);
            r = CaptionTransform(e.Graphics, e.Bounds);
            Font f = new Font("Arial", 11, FontStyle.Bold);
            e.Graphics.DrawString(caption, f, Brushes.Black, r);
            r.X -= 1; r.Y -= 1;
            e.Graphics.DrawString(caption, f, Brushes.White, r);
            e.Graphics.ResetTransform();
            e.Handled = true;
        }

        private void popupMenu1_PaintMenuBar(object sender, DevExpress.XtraBars.BarCustomDrawEventArgs e) {
            item_PaintMenuBar(e, Color.Red, Color.Yellow, "Popup Menu");
        }

        private void BarSubItem1_PaintMenuBar(object sender, DevExpress.XtraBars.BarCustomDrawEventArgs e) {
            item_PaintMenuBar(e, SystemColors.ActiveCaption, Color.White, "File Menu");
        }

        private void timer1_Tick(object sender, System.EventArgs e) {
            if(this.Visible)
                ((BarSubItemLink)bar1.ItemLinks[0]).OpenMenu();
            timer1.Stop();
        }

    }
}
