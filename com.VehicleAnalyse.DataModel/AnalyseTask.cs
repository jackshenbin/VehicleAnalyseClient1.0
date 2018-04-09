using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace com.VehicleAnalyse.DataModel
{
    public class AnalyseTask : ICloneable
    {

        public string TaskName { get; set; }

        public TaskStatus Status
        {
            get;
            set;
        }

        public TaskType TaskType { get; set; }

        public string TaskId { get; set; }

	    public string CameraId{ get; set; }

        public string PictureSource { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime StartAnalyseTime { get; set; }

        public DateTime FinishedTime { get; set; }

        public int ProcessedFileCount { get; set; }

        public int TaskPriority { get; set; }

        public AnalyseTask()
        {
            Status = TaskStatus.Init;
            CameraId = "";
            CreateTime = DateTime.Now;
        }

        public object Clone()
        {
            AnalyseTask task = new AnalyseTask()
            {
                TaskName = this.TaskName,
                Status = this.Status,
                TaskType = this.TaskType,
                TaskId = this.TaskId,
                CameraId = this.CameraId,
                CreateTime = this.CreateTime,
                StartAnalyseTime = this.StartAnalyseTime,
                FinishedTime = this.FinishedTime,
                PictureSource = this.PictureSource,
                ProcessedFileCount = this.ProcessedFileCount,
                 TaskPriority = this.TaskPriority,
            };

            return task;
        }

        public override string ToString()
        {
            return string.Format("[{0}][{2}]{1}", this.TaskId,  this.TaskName, (this.TaskType == DataModel.TaskType.History) ? "H" : "R:"+this.CameraId);
        }

    }

    public enum TaskType
    {
        Realtime,
        History,
    }
}
