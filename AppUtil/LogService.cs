using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using log4net;
using System.IO;
using log4net.Repository;
using log4net.Core;
using log4net.Appender;
using log4net.Repository.Hierarchy;

namespace WinFormAppUtil
{
    public class LogService
    {
        #region Fields
        
        private static ILog s_Log;
        private static RollingFileAppender[] s_Appenders;
        // private static Dictionary<string, log4net.Repository.ILoggerRepository> s_DTName2Repository;
        private static Dictionary<string, Logger> s_DTName2Log;

        #endregion

        #region Constructors
        
        static LogService()
        {
            // s_DTName2Repository = new Dictionary<string, ILoggerRepository>();
            s_DTName2Log = new Dictionary<string, Logger>();

            string fileName = "log4net.config";
            fileName = Path.Combine(Environment.CurrentDirectory, fileName);
            if (!File.Exists(fileName))
            {
                File.WriteAllText(fileName, Properties.Resources.log4net, Encoding.UTF8);
            }

            FileInfo fi = new FileInfo(fileName);

            log4net.Config.XmlConfigurator.Configure(fi);
            // s_Log = log4net.LogManager.GetLogger("AppLogger"); //"DebuggingLog");
            s_Log = log4net.LogManager.GetLogger("template");

            if (s_Appenders == null)
            {
                AppenderCollection ac = (s_Log.Logger as log4net.Repository.Hierarchy.Logger).Appenders;
                if (ac != null && ac.Count > 0)
                {
                    s_Appenders = new RollingFileAppender[ac.Count];
                    for (int i = 0; i < ac.Count; i++)
                    {
                        s_Appenders[i] = ac[i] as RollingFileAppender;
                    }
                }
            }
        }

        #endregion

        private static IAppender CreateFileAppender(RollingFileAppender appender, string name)
        {
            var fileAppender = new RollingFileAppender()
            {
                Name = name,
                File = string.Format("logs/{0}.log", name),
                LockingModel = appender.LockingModel,
                AppendToFile = appender.AppendToFile,
                RollingStyle = appender.RollingStyle,
                MaxSizeRollBackups = appender.MaxSizeRollBackups,
                MaxFileSize = appender.MaxFileSize,
                StaticLogFileName = appender.StaticLogFileName,
                Layout = appender.Layout
            };

            fileAppender.ActivateOptions();

            return fileAppender;
        }

        public static ILog GetLog(string logName = "")
        {
            ILog log = null;

            if (string.IsNullOrEmpty(logName))
            {
                log = s_Log;
                return log;
            }

            if (s_DTName2Log.ContainsKey(logName))
            {
                log = LogManager.GetLogger(logName);
                return log;
            }

            var hierarchy = (Hierarchy)LogManager.GetRepository();
            // var logger = hierarchy.LoggerFactory.CreateLogger((ILoggerRepository)hierarchy, logName);
            var logger = (Logger)LogManager.GetLogger(logName).Logger;
            logger.Hierarchy = hierarchy;
            log4net.Appender.IAppender fileAppender = CreateFileAppender(s_Appenders[0], logName);
        
            logger.AddAppender(fileAppender);
            
            logger.Repository.Configured = true;
            hierarchy.Threshold = logger.Level =  ((Logger)s_Log.Logger).Level;
            
            s_DTName2Log.Add(logName, logger);
            
            // log = new LogImpl(logger);
            log = LogManager.GetLogger(logName);
            return log;
        }
    }
}
