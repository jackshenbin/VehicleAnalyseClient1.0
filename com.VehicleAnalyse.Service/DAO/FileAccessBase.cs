using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.VehicleAnalyse.DataModel;
using System.IO;
using System.Drawing;

namespace com.VehicleAnalyse.Service.DAO
{
    public abstract class FileAccessBase
    {
        
        protected string m_PicSource;

        public bool URLsinTxtFile
        {
            get;
            set;
        }

        public FileAccessBase(string picSource)
        {
            m_PicSource = picSource;
        }

        /// <summary>
        /// 基类中仅检文件夹路径是否为空， 扩展类型还需要检查路径是否存在，以及账号验证是否通过
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public virtual bool Validate(ref string msg)
        {
            bool bRet = false;

            if (m_PicSource != null)
            {
                m_PicSource = m_PicSource.Trim();
            }
            
            if (string.IsNullOrEmpty(m_PicSource))
            {
                msg = "文件夹路径不能为空";
            }
            else
            {
                bRet = true;
            }

            return bRet;
        }

        public virtual bool Validate(string fileName, ref string msg)
        {
            bool bRet = false;
            return bRet;
        }

        public virtual List<PictureItem> GetFiles()
        {
            return null;
        }

        //public virtual Image GetImage(string fileName)
        //{
        //    return null;
        //}

        public virtual string GetFileName(string fullName)
        {
            return fullName;
        }
    }
}
