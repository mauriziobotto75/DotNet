public class DBConnection
{
    private string _cs =
        @"Data Source=.\SQLEXPRESS;
          Initial Catalog=Amministratori_Condominio;
          Integrated Security=True";

    public SqlConnection Connection
    {
        get
        {
            return new SqlConnection(_cs);
        }
    }
}
