using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.VehicleAnalyse.DataModel
{
    public class FilePathInfo
    {
        public string FullName { get; set; }

        public string ID { get; set; }

        public override string ToString()
        {
            return FullName;
        }
    }
}
