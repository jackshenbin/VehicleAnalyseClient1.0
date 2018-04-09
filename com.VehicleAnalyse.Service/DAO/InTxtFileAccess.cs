using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.VehicleAnalyse.DataModel;
using System.IO;
using System.Drawing;

namespace com.VehicleAnalyse.Service.DAO
{
    public class InTxtFileAccess : FileAccessBase
    {
        public InTxtFileAccess(string picSource) :
            base(picSource)
        {

        }

        public override bool Validate(ref string msg)
        {
            bool bRet = base.Validate(ref msg);

            if (bRet)
            {
                if (!File.Exists(m_PicSource))
                {
                    bRet = false;
                    msg = string.Format("文件 '{0}' 不存在", m_PicSource);
                }
            }

            return bRet;
        }

        public override List<PictureItem> GetFiles()
        {
            List<PictureItem> items = new List<PictureItem>();

            List<string> files = File.ReadLines(m_PicSource).ToList();
            foreach (var item in files)
            {
                items.Add(new PictureItem() { FullName = item });
            }

            return items;
        }


        public override string GetFileName(string fullName)
        {
            return Path.GetFileName(fullName);
        }


    }
}
