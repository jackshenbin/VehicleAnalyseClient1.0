using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppUtil;

namespace com.VehicleAnalyse.DataModel
{
    public class PageInfo : NotifyPropertyChangedModel
    {
        public event EventHandler SelectedPageNumberChanged;

        #region Fields

        private int m_CountPerPage;

        private int m_TotalRecords;

        private int m_PageCount;

        private int m_CurrentPageCount;

        private int m_PageIndex = -1;

        #endregion

        #region Properties

        public int TotalRecords
        {
            get
            {
                return m_TotalRecords;
            }
            private set
            {
                if (m_TotalRecords != value)
                {
                    m_TotalRecords = value;
                    RaisePropertyChangedEvent("TotalRecords");
                }
            }
        }

        /// <summary>
        /// 页数
        /// </summary>
        public int PageCount
        {
            get { return m_PageCount; }
            set
            {
                if (m_PageCount != value)
                {
                    m_PageCount = value;
                    RaisePropertyChangedEvent("Count");
                }
            }
        }
        
        public int CountPerPage
        {
            get { return m_CountPerPage; }
            set { m_CountPerPage = value; }
        }
        
        /// <summary>
        /// 当前页记录数
        /// </summary>
        public int CurrentPageCount
        {
            get
            {
                return m_CurrentPageCount;
            }
            private set
            {
                if (m_CurrentPageCount != value)
                {
                    m_CurrentPageCount = value;
                    RaisePropertyChangedEvent("CurrentPageCount");
                }
            }
        }

        public int StartRecordIndex
        {
            get
            {
                int startIndex = 0;
                if (m_PageIndex > 0)
                {
                    startIndex = m_PageIndex * m_CountPerPage;
                }
                return startIndex;
            }
        }


        /// <summary>
        /// 从0开始计数
        /// </summary>
        public int PageIndex
        {
            get { return m_PageIndex; }
            set
            {
                if (m_PageIndex != value)
                {
                    m_PageIndex = value;

                    if (m_PageIndex < m_PageCount - 1)
                    {
                        m_CurrentPageCount = m_CountPerPage;
                    }
                    else
                    {
                        m_CurrentPageCount = m_TotalRecords - StartRecordIndex;
                    }

                    RaisePropertyChangedEvent("PageIndex");
                    RaisePropertyChangedEvent("DisplayIndex");
                    RaisePropertyChangedEvent("CanPageUp");
                    RaisePropertyChangedEvent("CanPageDown");
                    if (SelectedPageNumberChanged != null)
                    {
                        SelectedPageNumberChanged(this, EventArgs.Empty);
                    }
                }
            }
        }

        /// <summary>
        /// 用于显示， 从1开始计数
        /// </summary>
        public string DisplayIndex
        {
            get
            {
                return (m_PageIndex + 1).ToString();
            }
            set
            {

            }
        }

        /// <summary>
        /// 是否可以下一页
        /// </summary>
        public bool CanNextPage
        {
            get
            {
                return PageIndex < PageCount - 1;
            }
            set
            {

            }
        }

        /// <summary>
        /// 是否可以上一页
        /// </summary>
        public bool CanPrePage
        {
            get
            {
                return PageIndex < PageCount && PageIndex > 0;
            }
            set
            {

            }
        }

        #endregion

        #region Constructors

        public PageInfo(int countPerPage, int totalRecords, int pageIndex = 0)
        {
            m_CountPerPage = countPerPage;
            m_TotalRecords = totalRecords;

            int count = totalRecords / countPerPage;
            m_PageCount = count;

            if (totalRecords % countPerPage != 0)
            {
                m_PageCount = count + 1;
            }
            
            PageIndex = pageIndex;
        }

        #endregion

        public void DecreaseCurrentPageCount(int count)
        {
            //TotalRecords -= count;
            //CurrentPageCount -= count;
        }

        public void TurnNextPage()
        {
            if (CanNextPage)
            {
                ++PageIndex;
            }
        }

        public void TurnPrePage()
        {
            if (CanPrePage)
            {
                --PageIndex;
            }
        }

        public List<int> GetPageIds()
        {
            List<int> ids = new List<int>();

            for (int i = 1; i <= m_PageCount; i++)
            {
                ids.Add(i);
            }

            return ids;
        }
    }
}
