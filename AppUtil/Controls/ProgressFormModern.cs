using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace AppUtil.Controls
{
    public partial class ProgressFormModern : Form, IProgressForm
    {
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        [DllImport("user32")]
        public static extern int SetWindowRgn(IntPtr hwnd, IntPtr hRgn, bool bRedraw);
        [DllImport("gdi32.dll")]
        static extern IntPtr CreateRoundRectRgn(int x1, int y1, int x2, int y2,int cx, int cy);


        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;

        private int m_Maximum = 100;
        private int m_Value;

        public ProgressFormModern()
        {
            InitializeComponent();
            //SetWindowRgn(this.Handle, CreateRoundRectRgn(0, 0, 562, 257, 20, 20), true);
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        #region IProgressForm Members

        public string StatusText
        {
            get
            {
                return this.lblStatus.Text;
            }
            set
            {
                this.lblStatus.Text = value;
            }
        }

        public int Maximum
        {
            get
            {
                return m_Maximum;
            }
            set
            {
                m_Maximum = value;
            }
        }

        public int Progress
        {
            get
            {
                return m_Value;
            }
            set
            {
                m_Value = value;
                RefreshUI();
            }
        }

        #endregion

        private void RefreshUI()
        {
            float percent = (float)m_Value / (float)m_Maximum;
            this.ucProgressFG1.Width = (int)(this.ucProgressBG1.Width * percent);
            this.lblPercentage.Text = string.Format("{0} %", (int)(percent * 100));
        }

        private void ProgressFormModern_Load(object sender, EventArgs e)
        {
            SetWindowRgn(this.Handle, CreateRoundRectRgn(0, 0, this.Width, this.Height, 15, 15), true);
        }
    }
}
