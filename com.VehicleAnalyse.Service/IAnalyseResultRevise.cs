using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.VehicleAnalyse.DataModel;

namespace com.VehicleAnalyse.Service
{
    public interface IAnalyseResultRevise
    {
        /// <summary>
        /// 以文件名作为索引
        /// </summary>
        bool ReviseByFile{get;set;}

        /// <summary>
        /// 单条记录校正
        /// </summary>
        /// <param name="record"></param>
        /// <param name="fileName"></param>
        void Execute(AnalyseRecord record, string fileName);

        /// <summary>
        /// 注册任务， 表明该任务是全部采用修正的分析结果
        /// </summary>
        /// <param name="task"></param>
        void RegisterTask(AnalyseTask task);

        /// <summary>
        /// 任务是否是修正分析的
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        bool Contains(AnalyseTask task);

        /// <summary>
        /// 获取修正结果
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        List<AnalyseRecord> GetAllResults(AnalyseTask task);
    }
}
