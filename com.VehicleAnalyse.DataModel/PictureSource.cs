using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.VehicleAnalyse.DataModel
{
    public class PictureSource
    {
        #region Fileds

        private FileType m_FileType = FileType.LocalFile;

        private string m_Path;

        private int m_Count;

        #endregion

        #region Properties

        public FileType FileType
        {
            get { return m_FileType; }
            set { m_FileType = value; }
        }

        public string Path
        {
            get { return m_Path; }
            set { m_Path = value; }
        }

        public int Count
        {
            get { return m_Count; }
            set { m_Count = value; }
        }

        /// <summary>
        /// 包括 -1: 接收图片失败, -3: 图片转换失败, -4: 图片信息错误
        /// </summary>
        public int ImageErrorCount{get;set;}

        /// <summary>
        /// 未识别数量
        /// </summary>
        public int NotRecognizedCount{get;set;}

        public int RecognizedCount{get;set;}

        /// <summary>
        /// 无牌车
        /// </summary>
        public int NoPlateCount { get; set; }

        public int ProcessedIndex { get; set; }

        public string UserName { get; set; }

        public string Password{ get; set; }

        public bool IncludeSubFolder
        {
            get;
            set;
        }

        public List<PictureItem> PictureItems { get; set; }

        #endregion

        public PictureSource()
        {
            Count = 0;
            ImageErrorCount = 0;
            RecognizedCount = 0;
            ProcessedIndex = 0;
            IncludeSubFolder = false;
        }

    }
}
