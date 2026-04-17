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
        SELECT COUNT(*)
        FROM DIRITTI D
        INNER JOIN RUOLI_DIRITTI RD ON D.IdDiritto = RD.IdDiritto
        WHERE RD.IdRuolo = @r AND D.Codice = @c", cn);

        cmd.Parameters.AddWithValue("@r",
            HttpContext.Current.Session["IdRuolo"]);
        cmd.Parameters.AddWithValue("@c", codice);

        cn.Open();
        return (int)cmd.ExecuteScalar() > 0;
    }
}
}
