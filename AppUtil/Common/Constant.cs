using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using System.Windows.Forms;

namespace AppUtil.Common
{
    public class Constant
    {
        private static Cursor s_CameraCursor;
        private static Cursor s_ChangeCursor;

        internal readonly static int TASKUNIT_MAXIMUM_SEARCH = 10;

        public readonly static uint VOLUMESIZE_K = 1 << 10;
        public readonly static uint VOLUMESIZE_M = 1 << 20;
        public readonly static uint VOLUMESIZE_G = 1 << 30;

        public readonly static TimeSpan TIMERANGE_PLATFORMVIDEOSEARCH = new TimeSpan(1, 0, 0, 0);
        
    }
}

