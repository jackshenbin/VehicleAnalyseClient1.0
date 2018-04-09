using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.VehicleAnalyse.DataModel;

namespace com.VehicleAnalyse.Service.DAO
{
    public class FileAccessFactory
    {
        public static FileAccessBase GetFileAccess(string picSource)
        {
            FileAccessBase fileAccess = null;

            if(picSource.ToLower().StartsWith("http://"))
            {
                fileAccess = new HttpFileAccess(picSource);
            }
            else if(picSource.ToLower().StartsWith("ftp://"))
            {
                fileAccess = new FtpFileAccess(picSource);
            }
            else
            {
                if (System.IO.File.Exists(picSource))
                {
                    fileAccess = new InTxtFileAccess(picSource);
                }
                if (System.IO.Directory.Exists(picSource))
                {
                    fileAccess = new LocalFileAccess(picSource);
                }
            }

            return fileAccess;
        }
    }
}
