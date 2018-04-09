using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.VehicleAnalyse.DataModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.IO;

namespace com.VehicleAnalyse.Service.DAO
{
   
    public class HttpFileAccess : FileAccessBase
    {
        private static readonly string RegexPattern_HTTP = @"^((http|ftp|https|www)://)?([\w+?\.\w+])+([a-zA-Z0-9\~\!\@\#\$\%\^\&\*\(\)_\-\=\+\\\/\?\.\:\;\'\,\u4e00-\u9fa5]*)?(\\|/)[0-9]+\.(jpg|jpeg|png|bmp)$";
        private static readonly string RegexPattern_FILE = @"(\\|/)[0-9]+\.(jpg|jpeg|png|bmp)$";

        private string m_FileNameBase;

        private string m_HttpBase;

        private int m_StartId;
        private string m_ImageFileExtenstion;

        private bool m_Initialized = false;
        private bool m_Valid = false;

        public HttpFileAccess(string picSource) :
            base(picSource)
        {

        }

        public override bool Validate(string fileName, ref string msg)
        {
            bool bRet = false;

            if (fileName != null)
            {
                fileName = fileName.Trim();
            }

            if (string.IsNullOrEmpty(fileName))
            {
                msg = "文件夹路径不能为空";
                bRet = false;
                return bRet;
            }

            bRet = Regex.IsMatch(fileName, RegexPattern_HTTP);
            if (!bRet)
            {
                msg = "非法的http 图片地址，图片格式仅支持jpg, jpge, png, bmp, 并且文件名必须是数字";
            }
            else
            {
                bRet = true;
                //Match match = Regex.Match(m_PicSource.Path, RegexPattern_FILE);
                //Debug.Assert(match.Captures.Count == 1);
                //m_FileNameBase = match.Captures[0].Value.Trim(new char[] { '\\', '/' });
                //string[] segs = m_FileNameBase.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                //m_StartId = int.Parse(segs[0]);
                //m_ImageFileExtenstion = segs[1];

                //m_HttpBase = m_PicSource.Path.Substring(0, match.Index + 1);
            }
            return bRet;
        }

        public override bool Validate(ref string msg)
        {
            bool bRet = false;

            if (URLsinTxtFile)
            {
                bRet = File.Exists(m_PicSource);  // Validate(m_PicSource.Path, ref msg);
                if (!bRet)
                {
                    msg = "文本文件不存在";
                }
                return bRet;
            }
            
            bRet = base.Validate(ref msg);
            
             if (bRet)
             {
                 bRet = Regex.IsMatch(m_PicSource, RegexPattern_HTTP);
                 if (!bRet)
                 {
                     msg = "非法的http 图片地址，图片格式仅支持jpg, jpge, png, bmp, 并且文件名必须是数字";
                 }
                 else
                 {
                    Match match = Regex.Match(m_PicSource, RegexPattern_FILE);
                    Debug.Assert(match.Captures.Count == 1);
                    m_FileNameBase = match.Captures[0].Value.Trim(new char[] { '\\', '/' });
                    string[] segs = m_FileNameBase.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    m_StartId = int.Parse(segs[0]);
                    m_ImageFileExtenstion = segs[1];

                    m_HttpBase = m_PicSource.Substring(0, match.Index + 1);
                 }
             }
             m_Initialized = true;
             m_Valid = bRet;
            return bRet;
        }

        public override List<PictureItem> GetFiles()
        {
            if (!m_Initialized)
            {
                string msg = string.Empty;
                if (!Validate(ref msg))
                {
                    throw new Exception(msg);
                }
            }

            List<PictureItem> picItems = new List<PictureItem>();

            if (URLsinTxtFile)
            {
                StreamReader sr = File.OpenText(m_PicSource);
                string line = sr.ReadLine();

                string msg = string.Empty;
                List<string> files = new List<string>();
                string fileTmp;
                while (line != null)
                {
                    line = line.Trim();
                    if (Validate(line, ref msg))
                    {
                        fileTmp = line.ToLower();
                        if (!files.Contains(fileTmp))
                        {
                            files.Add(fileTmp);
                            PictureItem item = new PictureItem() { FullName = line };
                            picItems.Add(item);
                        }
                    }
                    line = sr.ReadLine();
                }
            }
            else
            {
                //for (int i = 0; i < m_PicSource.Count; i++)
                //{
                //    PictureItem picItem = new PictureItem()
                //    {
                //        FullName = string.Format("{0}{1}.{2}", m_HttpBase, m_StartId + i, m_ImageFileExtenstion)
                //    };
                //    picItems.Add(picItem);
                //}
            }

            return picItems;
        }

        //public override Image GetImage(string fullName)
        //{
        //    Image image = null;

        //    System.Net.WebClient webClient = new System.Net.WebClient();
        //    byte[] bytes = webClient.DownloadData(fullName);
        //    MemoryStream ms = new MemoryStream(bytes);
        //    image = new Bitmap(ms);
        //    ms.Dispose();

        //    return image;
        //}

        public override string GetFileName(string fullName)
        {
            string fileName = fullName;
            Match match = Regex.Match(fullName, RegexPattern_FILE);
            Debug.Assert(match.Success && match.Captures.Count == 1);
            if (match.Success)
            {
                fileName = match.Captures[0].Value.Trim(new char[] { '\\', '/' });
            }
            return fileName;
        }
    }
}
