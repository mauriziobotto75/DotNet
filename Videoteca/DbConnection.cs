using System.Data.SqlClient;

namespace Videoteca
{
    public class DBConnection
    {
        private SqlConnection conn;

        public DBConnection()
        {
            conn = new SqlConnection(
                @"Data Source=.\SQLEXPRESS;
                  Initial Catalog=VIDEOTECA;
                  Integrated Security=True");
        }

        public SqlConnection Connection
        {
            get { return conn; }
        }
    }
}
