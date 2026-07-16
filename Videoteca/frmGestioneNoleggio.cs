public bool Disponibile(
    int idVideo,
    int idFormato)
{
    SqlConnection cn = new DBConnection().Connection;

    string sql =
    @"SELECT disponibili
      FROM tbcopie
      WHERE ksvideoc=@video
      AND ksformatoc=@formato";

    SqlCommand cmd = new SqlCommand(sql, cn);

    cmd.Parameters.AddWithValue("@video", idVideo);
    cmd.Parameters.AddWithValue("@formato", idFormato);

    cn.Open();

    object obj = cmd.ExecuteScalar();

    cn.Close();

    if (obj == null)
        return false;

    return Convert.ToInt32(obj) > 0;
}   // funzione di gestione del noleggio  nel FORM Gestione Noleggio
public bool NoleggiaVideo(
    int cliente,
    int video,
    int formato)
{
    SqlConnection cn = new DBConnection().Connection;

    cn.Open();

    SqlTransaction tr =
        cn.BeginTransaction();

    try
    {
        SqlCommand cmd1 =
            new SqlCommand(
            @"INSERT INTO tbmovvideo
              (
                kscliente,
                ksvideo,
                ksformato,
                datanoleggio
              )
              VALUES
              (
                @cliente,
                @video,
                @formato,
                GETDATE()
              )",
            cn, tr);

        cmd1.Parameters.AddWithValue("@cliente", cliente);
        cmd1.Parameters.AddWithValue("@video", video);
        cmd1.Parameters.AddWithValue("@formato", formato);

        cmd1.ExecuteNonQuery();

        SqlCommand cmd2 =
            new SqlCommand(
            @"UPDATE tbcopie
              SET disponibili = disponibili - 1,
                  noleggiate = noleggiate + 1
              WHERE ksvideoc=@video
              AND ksformatoc=@formato",
            cn, tr);

        cmd2.Parameters.AddWithValue("@video", video);
        cmd2.Parameters.AddWithValue("@formato", formato);

        cmd2.ExecuteNonQuery();

        tr.Commit();

        cn.Close();

        return true;
    }
    catch
    {
        tr.Rollback();
        cn.Close();
        return false;
    }
}
