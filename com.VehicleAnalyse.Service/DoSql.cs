using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MyLog4Net;

namespace com.VehicleAnalyse.Service
{
    public class DoSql
    {
        static string IP;
        static string User;
        static string Pass;
        static string connstring
        {
            //get { return "Server=127.0.0.1;Database=;Uid=root;Pwd=bocom;pooling=false;charset=gbk"; }
            get { return "Server={0};Uid={1};Pwd={2};pooling=false;charset=utf8;database=iratalydatadb"; }
        }

        public static bool TestConn(string ip, string user, string pass)
        {
            using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(string.Format(connstring, ip, user, pass)))
            {
                try
                {
                    conn.Open();
                    conn.Close();
                    IP = ip;
                    User = user;
                    Pass = pass;
                    return true;
                }
                catch (Exception ex)
                {
                    MyLog4Net.Container.Instance.Log.DebugWithDebugView("TestConn ret err:"+ex);
                    return false;
                }
            }
        }
        public static DataTable GetData(string strSql)
        {
            if (strSql == null || strSql.Length == 0)
            {
                return null;
            }

            using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(string.Format(connstring,IP,User,Pass)))
            {
                try
                {
                    conn.Open();
                    MySql.Data.MySqlClient.MySqlDataAdapter sqlData = new MySql.Data.MySqlClient.MySqlDataAdapter(strSql, conn);
                    DataTable data = new DataTable();
                    sqlData.Fill(data);
                    conn.Close();
                    return data;
                }
                catch (Exception ex)
                {
                    MyLog4Net.Container.Instance.Log.DebugWithDebugView("GetData ret err:" + ex);
                    return null;
                }
            }

        }


        //执行 sql 语句字符串,0 表示 执行成功
        public static bool ExecuteSql(string strSql)
        {
            if (strSql == null || strSql.Length == 0)
            {
                return true;
            }

            bool nRet = false ;
            using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(string.Format(connstring, IP, User, Pass)))
            {
                try
                {
                    conn.Open();
                    MySql.Data.MySqlClient.MySqlScript script = new MySql.Data.MySqlClient.MySqlScript(conn, strSql);
                    int ret = script.Execute();
                    conn.Close();
                    nRet = true;
                }
                catch (Exception ex)
                {
                    MyLog4Net.Container.Instance.Log.DebugWithDebugView("ExecuteSql ret err:" + ex);
                    nRet = false ;
                }
            }
            return nRet;
        }

    }
}
