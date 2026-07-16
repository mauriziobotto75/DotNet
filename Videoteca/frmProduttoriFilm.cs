public bool InserisciProduttore(
    string produttore,
    string email,
    string sito)
{
    SqlConnection cn = new DBConnection().Connection;

    string sql =
    @"INSERT INTO tbproduttori
      (
        produttore,
        emailp,
        sitop
      )
      VALUES
      (
        @produttore,
        @email,
        @sito
      )";

    SqlCommand cmd = new SqlCommand(sql, cn);

    cmd.Parameters.AddWithValue("@produttore", produttore);
    cmd.Parameters.AddWithValue("@email", email);
    cmd.Parameters.AddWithValue("@sito", sito);

    cn.Open();

    int n = cmd.ExecuteNonQuery();

    cn.Close();

    return n > 0;
}
