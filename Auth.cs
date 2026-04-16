public class Auth
{
    public static void RequireDiritto(string codice)
    {
        if (!HasDiritto(codice))
            HttpContext.Current.Response.Redirect("~/AccessoNegato.aspx");
    }

    public static bool HasDiritto(string codice)
    {
        using (SqlConnection cn = Db.Conn())
        {
            SqlCommand cmd = new SqlCommand(@"
            SELECT COUNT(*) FROM Ruoli_Diritti RD
            INNER JOIN DIRITTI D ON RD.IdDiritto = D.IdDiritto
            WHERE RD.IdRuolo=@r AND D.Codice=@c", cn);

            cmd.Parameters.AddWithValue("@r",
                HttpContext.Current.Session["IdRuolo"]);
            cmd.Parameters.AddWithValue("@c", codice);

            cn.Open();
            return (int)cmd.ExecuteScalar() > 0;
        }
    }
}
