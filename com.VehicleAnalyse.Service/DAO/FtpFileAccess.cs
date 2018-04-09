using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.VehicleAnalyse.DataModel;
using AppUtil.Common;
using System.IO;
using com.VehicleAnalyse.DataModel;
using System.Drawing;
using System.Diagnostics;

namespace com.VehicleAnalyse.Service.DAO
{
    public class FtpFileAccess : FileAccessBase
    {

        private FtpWeb m_FTPFileService = null;
        private string m_ftpIP = "";
        private int m_ftpPort = 0;
        private string m_ftpUser = "";
        private string m_ftpPass = "";
        private string m_ftpPath = "";
        public FtpFileAccess(string picSource) :
            base(picSource)
        {

        }

        public override bool Validate(ref string msg)
        {
            bool bRet = false;

            string ip, port, userName, password, path;

            if (FtpWeb.GetFtpUrlInfo(m_PicSource, out ip, out port, out userName, out password, out path))
            {
                string ipAndPort = string.Format("{0}:{1}", ip, port);
                m_ftpIP = ip;
                m_ftpPort = Convert.ToInt32(port);
                m_ftpUser = userName;
                m_ftpPass =  password;
                m_ftpPath = path;
                try
                {
                    m_FTPFileService = new FtpWeb(m_ftpIP + ":" + m_ftpPort, "", m_ftpUser, m_ftpPass);
                    //m_FTPFileService.Open();
                    //m_FTPFileService.Login();

                    bRet = true;
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                    bRet = false;
                }
            }
            else
            {
                msg = "非法ftp地址";
            }
            return bRet;
        }

        public override List<PictureItem> GetFiles()
        {
            if (m_FTPFileService == null)
            {
                string msg =string.Empty;
                if (!Validate(ref msg))
                {
                    throw new FtpException(msg);
                }
            }

            List<PictureItem> picItems = new List<PictureItem>();
            GetFiles(m_ftpPath, picItems, true);

            return picItems;
        }

        private void GetFiles(string folder, List<PictureItem> picItems, bool includeChildFolder)
        {
            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss,fff")+"GetFiles:"+folder);
            string cd = folder.Trim('/');
            if (cd == "") cd = "/";
            else cd = "/" + cd;
            //m_FTPFileService.SetCurrentDirectory(cd);
            var ftplist = m_FTPFileService.GetFilesDetailList(folder).Where(it=>it.IsDir == false).ToList().ConvertAll<string>(it=>it.Name);
            if (ftplist != null && ftplist.Count > 0)
            {
                PictureItem picItem;
                string fileExt;

                foreach (var item in ftplist)
                {
                    fileExt = Path.GetExtension(item);
                    if (Array.IndexOf(DataModel.Constant.PICFILE_EXTENSIONS, fileExt.ToLower()) > -1)
                    {
                        picItem = new PictureItem() { };
                        if (!string.IsNullOrEmpty(m_ftpUser) && !string.IsNullOrEmpty(m_ftpPass))
                        {
                            picItem.FullName = string.Format("ftp://{0}:{1}@{2}:{3}{4}", m_ftpUser, m_ftpPass,
                                m_ftpIP,
                                m_ftpPort,
                                string.IsNullOrEmpty(cd) ? "/"+item : string.Format("{0}/{1}", cd, item));
                        }
                        else
                        {
                            picItem.FullName = string.Format("ftp://{0}:{1}{2}",
                                m_ftpIP,
                                m_ftpPort,
                                string.IsNullOrEmpty(cd) ? "/" + item : string.Format("{0}/{1}", cd, item));
                        }
                        picItems.Add(picItem);
                    }
                }
            }


            if (includeChildFolder)
            {
                var dirs = m_FTPFileService.GetDirectoryList(folder);
                if (dirs != null && dirs.Count > 0)
                {
                    string tmp;
                    foreach (var dir in dirs)
                    {
                        tmp = string.Format("{0}/{1}", folder, dir);
                        GetFiles(tmp, picItems, includeChildFolder);
                    }
                }
            }
        }

        //public override Image GetImage(string fullName)
        //{
        //    Image image = null;

        //    //if (m_FTPFileService == null)
        //    //{
        //    //    string msg = string.Empty;
        //    //    if (!Validate(ref msg))
        //    //    {
        //    //        throw new FtpException(msg);
        //    //    }
        //    //}

        //    try
        //    {
        //        MemoryStream ms = new MemoryStream();
        //        // string fileName = GetFileName(fullName);
        //        FtpWeb.GetFileStreamEx(fullName, ms);
        //         image = new Bitmap(ms);
        //        ms.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.Assert(false, ex.Message);
        //    }
        //    return image;
        //}

        public override string GetFileName(string fullName)
        {
            string fileName = fullName;

            if (!string.IsNullOrEmpty(fullName) && fullName.IndexOf("/") > -1)
            {
                fileName = fullName.Substring(fullName.LastIndexOf("/") + 1);
            }
            return fileName;
        }
    }

}
