using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bocom.ImageAnalysisClient.Service
{
    public partial class VehicleLogos : UserControl
    {
        public VehicleLogos()
        {
            InitializeComponent();
        }

        public Image GetImage(string name)
        {
            Image img = null;

            try
            {
                img = imageCollection1.Images[name];
            }
            catch
            {
                img = null;
            }

            return img;
        }
    }
}
