using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RestService.DBUtil
{
    public static class Connection
    {
        private const string ConnectionString = @"Data Source=mort237d.database.windows.net;Initial Catalog=RoyalUnibrewDB;User ID=KaffeOgKage;Password=Mort237d;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static readonly SqlConnection MyConnection = new SqlConnection(ConnectionString);
    }
}