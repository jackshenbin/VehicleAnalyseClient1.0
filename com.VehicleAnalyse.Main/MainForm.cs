using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Bocom.ImageAnalysisClient.App.Views;
using Bocom.ImageAnalysisClient.App.Framework;
using Bocom.ImageAnalysisClient.DataModel;

namespace Bocom.ImageAnalysisClient.App
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        private ucSearchAnalyseResults m_ucSearchAnalyseResults;

        public MainForm()
        {
            this.WindowState = FormWindowState.Minimized;
            InitializeComponent();
            Framework.Container.Instance.MainControl = this;
            Framework.Container.Instance.EvtAggregator.GetEvent<ViewResultsEvent>().Subscribe(OnViewResults);
            Framework.Container.Instance.EvtAggregator.GetEvent<ViewFailedResultsEvent>().Subscribe(OnViewResults);
            // this.WindowState = FormWindowState.Maximized;
            if (Framework.Environment.UseCustomTitle)
                this.bar2.BarAppearance.Normal.Image = Framework.Environment.CustomLogo;

        }

        #region Event handlers
        
        private void barBtnItemExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DialogResult.Yes ==
            Framework.Container.Instance.InteractionService.ShowMessageBox("是否确定退出?", Framework.Environment.PROGRAM_NAME,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                Close();
            }
        }

        private void barBtnItemLogin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (FormLogin dlg = new FormLogin())
            {
                dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.ShowDialog();

                if (Framework.Environment.LoggedinToken != null)
                {
                    barBtnItemLogin.Enabled = false;
                    barBtnItemStartAnalyse.Enabled = true;
                    barStatusLogin.Caption = string.Format("登录服务器: {0}", Framework.Environment.LoggedinToken.ServerIP);
                    barStatusAnalyse.Caption = string.Format("");
                    Framework.Container.Instance.TaskManager.Init();

                    Framework.Container.Instance.EvtAggregator.GetEvent<UserLoginEvent>().Publish(Framework.Environment.LoggedinToken);
                }
            }
        }

        private void barBtnItemStartAnalyse_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Framework.Container.Instance.ImageAnalysisService.Running)
            {
                Framework.Container.Instance.ImageAnalysisService.Start();

            }
            else
            {
                Framework.Container.Instance.TaskManager.Running = true;
            }
            barBtnItemStartAnalyse.Enabled = false;
            barBtnItemStopAnalyse.Enabled = true;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Framework.Environment.LoggedinToken != null)
            {
                Framework.Container.Instance.TaskManager.Close();
                Framework.Container.Instance.ImageAnalysisService.Stop();
            }

        }

        private void barBtnItemTaskMonitor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucTaskMonitor1.BringToFront();
        }

        private void barBtnItemResultView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_ucSearchAnalyseResults == null)
            {
                m_ucSearchAnalyseResults = new ucSearchAnalyseResults();
                m_ucSearchAnalyseResults.Dock = DockStyle.Fill;
                this.Controls.Add(m_ucSearchAnalyseResults);
            }

            m_ucSearchAnalyseResults.BringToFront();
        }

        private void OnViewResults(AnalyseTask task)
        {
            if (m_ucSearchAnalyseResults == null)
            {
                m_ucSearchAnalyseResults = new ucSearchAnalyseResults();
                m_ucSearchAnalyseResults.Dock = DockStyle.Fill;
                this.Controls.Add(m_ucSearchAnalyseResults);
            }

            m_ucSearchAnalyseResults.BringToFront();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (FormVehicleBrandManagement dlg = new FormVehicleBrandManagement())
            {
                dlg.ShowDialog();
            }
        }

        private Rectangle CaptionTransform(Graphics g, Rectangle r)
        {
            g.RotateTransform(-90);
            r.X = r.X - r.Height + 5;
            r.Width = r.Height;
            return r;
        }

        private void item_PaintMenuBar(DevExpress.XtraBars.BarCustomDrawEventArgs e, Color c1, Color c2, string caption)
        {
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

        private void popupMenu1_PaintMenuBar(object sender, DevExpress.XtraBars.BarCustomDrawEventArgs e)
        {
            item_PaintMenuBar(e, Color.Red, Color.Yellow, "Popup Menu");
        }

        private void BarSubItem1_PaintMenuBar(object sender, DevExpress.XtraBars.BarCustomDrawEventArgs e)
        {
            item_PaintMenuBar(e, SystemColors.ActiveCaption, Color.White, "File Menu");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                this.Hide();
                ucTaskMonitor1.Init();
                m_ucSearchAnalyseResults = new ucSearchAnalyseResults();
                m_ucSearchAnalyseResults.Dock = DockStyle.Fill;
                this.Controls.Add(m_ucSearchAnalyseResults);

                this.WindowState = FormWindowState.Maximized;
                this.Show();
            }
        }

        #endregion

        private void barCheckItemShowOutputWindow_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Framework.Container.Instance.EvtAggregator.GetEvent<OutputWindowSwitch>().Publish(barCheckItemShowOutputWindow.Checked);
        }

        private void barBtnItemStopAnalyse_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Framework.Container.Instance.TaskManager.Running = false;

            barBtnItemStartAnalyse.Enabled = true;
            barBtnItemStopAnalyse.Enabled = false;
        }

    }
}