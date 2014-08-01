using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Configuration;

//namespace DAL
//{
    public class StaticSettings
    {
        public StaticSettings()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public class Database
        {
            //Real connection
           public static string DbConnectionString = "Server=212.74.43.180,1433;Database=deals;UID=appsuser;PWD=Bd54321!123";

           //public static string DbConnectionString = "Server=MOINUR-PC;Database=deals;UID=sa;PWD=moinur12345";

        }
    }
//}
