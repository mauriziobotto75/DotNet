 using System.IO;

int id;

protected void Page_Load(object sender, EventArgs e)
{
    Auth.RequireDiritto("GEST_PERSONE");
    id = Request["id"] != null ? int.Parse(Request["id"]) : 0;
}

protected void Salva_Click(object sender, EventArgs e)
{
    byte[] foto = null;

    if (fuFoto.HasFile)
    {
        foto = new BinaryReader(
            fuFoto.PostedFile.InputStream)
            .ReadBytes(fuFoto.PostedFile.ContentLength);
    }

    using (SqlConnection cn = Db.Conn())
    {
        SqlCommand cmd;

        if (id == 0)
        {
            cmd = new SqlCommand(
            "INSERT INTO Persone (Nome, Cognome, FotoPersona) VALUES (@n,@c,@f)", cn);
        }
        else
        {
            cmd = new SqlCommand(
            @"UPDATE Persone SET Nome=@n, Cognome=@c,
              FotoPersona = ISNULL(@f, FotoPersona)
              WHERE IdPersona=@id", cn);
            cmd.Parameters.AddWithValue("@id", id);
        }

        cmd.Parameters.AddWithValue("@n", txtNome.Text);
        cmd.Parameters.AddWithValue("@c", txtCognome.Text);
        cmd.Parameters.AddWithValue("@f", (object)foto ?? DBNull.Value);

        cn.Open();
        cmd.ExecuteNonQuery();
    }
}
