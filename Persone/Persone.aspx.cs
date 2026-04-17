using System;
using System.Data.SqlClient;

public partial class Persone : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) Carica();
    }

    void Carica()
    {
        using (SqlConnection cn = Db.Conn())
        {
            SqlCommand cmd = new SqlCommand(
                "SELECT IdPersona, Nome, Cognome FROM Persone", cn);
            cn.Open();
            gv.DataSource = cmd.ExecuteReader();
            gv.DataBind();
        }
    }
}
