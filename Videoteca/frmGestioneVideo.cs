public bool InserisciVideo(
    string titolo,
    string trama,
    int genere,
    string regista,
    int produttore,
    int durata,
    string anno,
    string vietato)
{
    SqlConnection cn = new DBConnection().Connection;

    string sql =
    @"INSERT INTO tbvideo
      (
        titolo,
        trama,
        ksgenere,
        regista,
        ksproduttore,
        durata,
        annoproduzione,
        vietato
      )
      VALUES
      (
        @titolo,
        @trama,
        @genere,
        @regista,
        @produttore,
        @durata,
        @anno,
        @vietato
      )";

    SqlCommand cmd = new SqlCommand(sql, cn);

    cmd.Parameters.AddWithValue("@titolo", titolo);
    cmd.Parameters.AddWithValue("@trama", trama);
    cmd.Parameters.AddWithValue("@genere", genere);
    cmd.Parameters.AddWithValue("@regista", regista);
    cmd.Parameters.AddWithValue("@produttore", produttore);
    cmd.Parameters.AddWithValue("@durata", durata);
    cmd.Parameters.AddWithValue("@anno", anno);
    cmd.Parameters.AddWithValue("@vietato", vietato);

    cn.Open();

    int n = cmd.ExecuteNonQuery();

    cn.Close();

    return n > 0;
}
