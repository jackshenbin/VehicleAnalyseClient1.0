using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.VehicleAnalyse.DataModel
{
    public class ConnectionParam
    {
        
        public string IPAddress { get; set; }
        
        public int Port{get;set;}

        public string DeviceNo { get; set; }

        /* 暂时没用       
       public int LocalServerPort { get; set; }


       public int IntervalHeartBeat { get; set; }
               
       public int nPicTimeout;

       public int nPlatTimeout;
                
       public int nPicCameraAssociateType;
         */
    }
}
