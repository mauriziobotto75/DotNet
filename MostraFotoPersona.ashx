 using System;
using System.Data.SqlClient;
using System.Web;

public class MostraFotoPersona : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        int id = int.Parse(context.Request["id"]);

        using (SqlConnection cn = Db.Conn())
        {
            SqlCommand cmd = new SqlCommand(
                "SELECT FotoPersona FROM Persone WHERE IdPersona=@id", cn);
            cmd.Parameters.AddWithValue("@id", id);
            cn.Open();

            byte[] foto = cmd.ExecuteScalar() as byte[];

            if (foto != null)
            {
                context.Response.ContentType = "image/jpeg";
                context.Response.BinaryWrite(foto);
            }
        }
    }

    public bool IsReusable { get { return false; } }
}
