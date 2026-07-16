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
}
