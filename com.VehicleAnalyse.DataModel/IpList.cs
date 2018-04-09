using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.VehicleAnalyse.DataModel
{
    public class IpList
    {
        List<ConnectionParam> m_ipList = new List<ConnectionParam>();

        int m_index = 0;

        public ConnectionParam GetNext()
        {
            if (m_ipList.Count <= m_index)
                return null;
            else
            return m_ipList[m_index++];
        }

        public void AddIp(ConnectionParam ip)
        {
            if(m_ipList.Find(item=>item.IPAddress == ip.IPAddress)== null)
            m_ipList.Add( ip );
        }
    }
}
