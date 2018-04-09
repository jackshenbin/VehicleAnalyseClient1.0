using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppUtil
{
    public interface IInteractionService
    {
        DialogResult ShowMessageBox(IWin32Window owner, string text, string caption, MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Asterisk);

        DialogResult ShowMessageBox(string text, string caption, MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Asterisk);

        DialogResult ShowMessageBox(string text);

        void ShowAlertBox(string text, string caption, System.Drawing.Image img = null);

    }
}
