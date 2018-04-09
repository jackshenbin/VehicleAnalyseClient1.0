using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.VehicleAnalyse.Main.Framework;
using DevExpress.XtraRichEdit.Model;

namespace com.VehicleAnalyse.Main.Views
{
    public partial class ucOutputWindow : UserControl
    {

        public bool SwitchOn{get;set;}

        public ucOutputWindow()
        {
            InitializeComponent();
            this.HandleDestroyed += new EventHandler(ucOutputWindow_HandleDestroyed);
        }

        void ucOutputWindow_HandleDestroyed(object sender, EventArgs e)
        {
            Framework.Container.Instance.EvtAggregator.GetEvent<AnalyseMessageEvent>().Unsubscribe(OnMessage);
        }

        private void AppendText(string msg)
        {
            if (this.IsDisposed)
            {
                return;
            }

            int exceed = richTextBox1.TextLength + 1000 - richTextBox1.MaxLength;
            if (exceed > 0)
            {
                int line = richTextBox1.GetLineFromCharIndex(1000);
                int charIndex = richTextBox1.GetFirstCharIndexFromLine(line);
                richTextBox1.Text = richTextBox1.Text.Substring(charIndex);
            }

            if (!string.IsNullOrEmpty(richTextBox1.Text))
            {
                richTextBox1.AppendText(System.Environment.NewLine);
            }

            richTextBox1.AppendText(msg);
        }

        internal void Init()
        {
            richTextBox1.MaxLength = 50000;
            Framework.Container.Instance.EvtAggregator.GetEvent<AnalyseMessageEvent>().Subscribe(OnMessage);
        }

        private void OnMessage(Tuple<uint, string> tuple)
        {
            if (!SwitchOn)
            {
                return;
            }

            if (tuple.Item1 == 209 || tuple.Item1 == 210 || tuple.Item1 == 194 || tuple.Item1 == 195)
            {
                return;
            }
            if (tuple.Item1 == 0 || tuple.Item1 == 2 || tuple.Item1 == 3)
            {
                return;
            }

            if(this.InvokeRequired)
            {
                Action<Tuple<uint, string>> action = new Action<Tuple<uint, string>>(this.OnMessage);
                this.BeginInvoke(action, new object[]{tuple});
                return;
            }

            if(!string.IsNullOrEmpty(tuple.Item2))
            {
                AppendText(string.Format("{0}   {1}", DateTime.Now.ToString(DataModel.Constant.DATETIME_FORMAT), tuple.Item2));
            }
        }

        private void ucOutputWindow_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                
            }
        }
    }
}
