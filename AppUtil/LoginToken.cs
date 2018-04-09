using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppUtil
{
    public class LoginToken
    {
        public string ServerIP { get; set; }
        public string UploadIP { get; set; }
        public string SearchIP { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public int ServerPort{ get; set; }
        public int UploadPort{ get; set; }
        public int SearchPort{ get; set; }


        public LoginToken(string serverIP, string userName, string password, int serverport, string uploadIP, int uploadport, string searchIP, int searchport)
        {
            ServerIP = serverIP;
            SearchIP = searchIP;
            UploadIP = uploadIP;
            UserName = userName;
            Password = password;

            ServerPort = serverport;
            SearchPort = searchport;
            UploadPort = uploadport;
        }
    }
}
