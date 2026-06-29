using System.Data.SqlClient;

public class DatabaseConnection
{
    private string connectionString =
        "Server=.;Database=Hotel;Trusted_Connection=True;";

    public SqlConnection GetConnection()
    {
        return new SqlConnection(connectionString);
    }
}
