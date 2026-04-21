using System.Web;
using System.Data.SqlClient;

public class Audit
{
    public static void Log(
        string azione,
        string entita,
        string chiaveEntita)
    {
        // se non loggato, non scrivo
        if (HttpContext.Current.Session["IdUtente"] == null)
            return;

        using (SqlConnection cn = Db.Conn())
        {
            SqlCommand cmd = new SqlCommand(@"
                INSERT INTO AUDIT_LOG
                (IdUtente, DataOra, Azione, Entita, ChiaveEntita, Pagina, IndirizzoIP)
                VALUES
                (@u, GETDATE(), @a, @e, @k, @p, @ip)", cn);

            cmd.Parameters.AddWithValue("@u",
                HttpContext.Current.Session["IdUtente"]);
            cmd.Parameters.AddWithValue("@a", azione);
            cmd.Parameters.AddWithValue("@e", entita);
            cmd.Parameters.AddWithValue("@k", chiaveEntita);
            cmd.Parameters.AddWithValue("@p",
                HttpContext.Current.Request.Url.AbsolutePath);
            cmd.Parameters.AddWithValue("@ip",
                HttpContext.Current.Request.UserHostAddress);

            cn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
