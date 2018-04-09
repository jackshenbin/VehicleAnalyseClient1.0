using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.VehicleAnalyse.DataModel
{
    public class TaskProgressStatusInfo
    {
        public string TaskId { get; set; }
        public uint ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public TaskStatus TaskStatus { get; set; }
        public uint Progress { get; set; }
        public uint CommitCount { get; set; }
    }
    public enum TaskStatus
    {
        Init =0,
        AnalysingError ,
        Loading,
        Analysing,
        Finished,
    }
}
