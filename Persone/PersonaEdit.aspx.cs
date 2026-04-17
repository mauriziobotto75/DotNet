 using System;
using System.Data.SqlClient;
using System.IO;

public partial class PersonaEdit : System.Web.UI.Page
{
    int id;

    protected void Page_Load(object sender, EventArgs e)
    {
        id = int.Parse(Request["id"]);
    }

    protected void btnSalva_Click(object sender, EventArgs e)
    {
        using (SqlConnection cn = Db.Conn())
        {
            SqlCommand cmd;

            if (fuFoto.HasFile)
            {
                byte[] foto = new BinaryReader(
                    fuFoto.PostedFile.InputStream)
                    .ReadBytes(fuFoto.PostedFile.ContentLength);

                cmd = new SqlCommand(
                @"UPDATE Persone SET Nome=@n, Cognome=@c,
                  Foto=@f, FotoMime=@m WHERE IdPersona=@id", cn);

                cmd.Parameters.AddWithValue("@f", foto);
                cmd.Parameters.AddWithValue("@m", fuFoto.PostedFile.ContentType);
            }
            else
            {
                cmd = new SqlCommand(
                "UPDATE Persone SET Nome=@n, Cognome=@c WHERE IdPersona=@id", cn);
            }

            cmd.Parameters.AddWithValue("@n", txtNome.Text);
            cmd.Parameters.AddWithValue("@c", txtCognome.Text);
            cmd.Parameters.AddWithValue("@id", id);

            cn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
