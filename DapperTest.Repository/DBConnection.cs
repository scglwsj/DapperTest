using System.Data;
using System.Data.SqlClient;

namespace DapperTest.Repository
{
    public class DbConnection
    {
        private const string SqlConnectionStr =
            @"data source=(LocalDb)\MSSQLLocalDB;Integrated Security=True;";

        public static IDbConnection GetDbConnection()
        {
            return new SqlConnection(SqlConnectionStr);
        }
    }
}