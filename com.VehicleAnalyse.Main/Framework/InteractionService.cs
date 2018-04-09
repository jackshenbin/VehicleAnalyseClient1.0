using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using System.ComponentModel.Composition;

namespace AppUtil
{
    [Export(typeof(IInteractionService))]
    public class InteractionService : IInteractionService
    {

        public static string DEFAULT_CAPTION = string.Empty;

        public System.Windows.Forms.DialogResult ShowMessageBox(IWin32Window owner, string text, string caption, MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Asterisk)
        {
            return XtraMessageBox.Show(owner, text, caption, buttons, icon);
        }

        public System.Windows.Forms.DialogResult ShowMessageBox(string text, string caption, System.Windows.Forms.MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Asterisk)
        {
            return XtraMessageBox.Show(text, caption, buttons, icon);
        }

        public System.Windows.Forms.DialogResult ShowMessageBox(string text)
        {
            if (text.Length < 20)
            {
                text = string.Concat(text, "            ");
            }
            if (string.IsNullOrEmpty(DEFAULT_CAPTION))
            {
                return XtraMessageBox.Show(text);
            }
            else
            {
                return XtraMessageBox.Show(text, DEFAULT_CAPTION);
            }
        }

        public void ShowAlertBox(string text, string caption, System.Drawing.Image img = null)
        {
            DevExpress.XtraBars.Alerter.AlertControl alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl();
            alertControl1.Show(null, caption, text, img);
        }
    }
}
