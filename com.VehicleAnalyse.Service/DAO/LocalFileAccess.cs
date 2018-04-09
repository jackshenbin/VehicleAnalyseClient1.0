using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.VehicleAnalyse.DataModel;
using System.IO;
using System.Drawing;

namespace com.VehicleAnalyse.Service.DAO
{
    public class LocalFileAccess : FileAccessBase
    {
        public LocalFileAccess(string picSource) :
            base(picSource)
        {

        }

        public override bool Validate(ref string msg)
        {
            bool bRet = base.Validate(ref msg);

            if (bRet)
            {
                if (!Directory.Exists(m_PicSource))
                {
                    bRet = false;
                    msg = string.Format("文件夹 '{0}' 不存在", m_PicSource);
                }
            }

            return bRet;
        }

        public override List<PictureItem> GetFiles()
        {
            List<PictureItem> items = new List<PictureItem>();

            GetFiles(m_PicSource, items, true);

            return items;
        }

        //public override Image GetImage(string fileName)
        //{
        //    Image image = null;
        //    try
        //    {
        //        if (File.Exists(fileName))
        //        {
        //            image = Image.FromFile(fileName);
        //        }
        //    }
        //    catch
        //    {
        //    }
        //    return image;
        //}

        public override string GetFileName(string fullName)
        {
            return Path.GetFileName(fullName);
        }

        private static void GetFiles(string path, List<PictureItem> items, bool includeChildFolder=false)
        {
            if (!Directory.Exists(path))
            {
                return;
            }

            string[] files = Directory.GetFiles(path);
            if (files != null && files.Length > 0)
            {
                foreach (string file in files)
                {
                    FileInfo fi = new FileInfo(Path.Combine(path, file));
                    if (Array.IndexOf(Constant.PICFILE_EXTENSIONS, fi.Extension.ToLower()) > -1)
                    {
                        PictureItem item = new PictureItem() { FullName = fi.FullName };
                        items.Add(item);
                    }
                }
            }

            string[] dirs = Directory.GetDirectories(path);
            if (includeChildFolder)
            {
                if (dirs != null && dirs.Length > 0)
                {
                    foreach (string dir in dirs)
                    {
                        GetFiles(dir, items, includeChildFolder);
                    }
                }
            }
        }

    }
}
