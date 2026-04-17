
using System.Configuration;
using System.Data.SqlClient;

public class Db
{
    public static SqlConnection Conn()
    {
        return new SqlConnection(
            ConfigurationManager.ConnectionStrings["db"].ConnectionString);
    }
}
