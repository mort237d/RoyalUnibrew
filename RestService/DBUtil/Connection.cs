using System.Data.SqlClient;

namespace RestService.DBUtil
{
    public class Connection
    {
        private const string ConnectionString = @"Data Source=mort237d.database.windows.net;Initial Catalog=RoyalUnibrewDB;User ID=KaffeOgKage;Password=Mort237d;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public readonly SqlConnection MyConnection = new SqlConnection(ConnectionString);
    }
}