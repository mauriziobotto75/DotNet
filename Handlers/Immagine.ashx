using System;
using System.Data.SqlClient;
using System.Web;

public class Immagine : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        int id = int.Parse(context.Request["id"]);

        using (SqlConnection cn = Db.Conn())
        {
            SqlCommand cmd = new SqlCommand(
                "SELECT Foto, FotoMime FROM Persone WHERE IdPersona=@id", cn);
            cmd.Parameters.AddWithValue("@id", id);

            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                context.Response.ContentType = dr["FotoMime"].ToString();
                context.Response.BinaryWrite((byte[])dr["Foto"]);
            }
        }
    }

    public bool IsReusable { get { return false; } }
}
