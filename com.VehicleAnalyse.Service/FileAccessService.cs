using com.VehicleAnalyse.DataModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace com.VehicleAnalyse.Service
{
    public class FileAccessService
    {
        private static readonly string[] PICFILE_EXTENSIONS = new string[] { ".jpg", ".jpeg", ".png", ".bmp" };

        public static List<PictureItem> GetFiles(PictureSource picSource)
        {
            List<PictureItem> items = new List<PictureItem>();

            if(picSource.FileType == FileType.LocalFile)
            {
                GetFiles(picSource.Path, items);
            }

            return items;
        }

        private static void GetFiles(string path, List<PictureItem> items)
        {
            if(!Directory.Exists(path))
            {
                return;
            }

            string[] files = Directory.GetFiles(path);
            if(files != null && files.Length > 0)
            {
                foreach(string file in files)
                {
                    FileInfo fi = new FileInfo(Path.Combine(path, file));
                    if(Array.IndexOf(PICFILE_EXTENSIONS,fi.Extension.ToLower()) > -1)
                    {
                        PictureItem item = new PictureItem() { FullName = fi.FullName };
                        items.Add(item);
                    }
                }
            }

            string[] dirs = Directory.GetDirectories(path);
            if(dirs != null && dirs.Length > 0)
            {
                foreach(string dir in dirs)
                {
                    GetFiles(dir, items);
                }
            }
        }
    }
}
