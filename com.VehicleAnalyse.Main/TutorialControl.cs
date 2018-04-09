using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bocom.ImageAnalysisClient.App
{
    public class TutorialControl : DevExpress.Tutorials.ModuleBase
    {

        public virtual bool ShowLookAndFeel { get { return true; } }
        public virtual bool SetNewWhatsThisPadding { get { return false; } }
        public override void StartWhatsThis()
        {
            if (SetNewWhatsThisPadding)
            {
                this.Padding = new Padding(8);
                this.Refresh();
            }
        }
        public override void EndWhatsThis()
        {
            if (SetNewWhatsThisPadding)
                this.Padding = new Padding(0);
        }

    }
}
