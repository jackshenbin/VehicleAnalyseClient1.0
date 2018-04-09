using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppUtil
{
    public class TaskItem<TIN, TOUT>
    {
        public int DelayExecute { get; set; }

        public TIN Para { get; set; }

        public Func<TIN, TOUT> FuncToRun { get; set; }

        public Action<TOUT> Callback { get; set; }

        public Action<TIN> Cancel { get; set; }
    }
}
