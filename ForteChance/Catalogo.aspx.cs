using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Catalogo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            CaricaCorsi();
    }

    private void CaricaCorsi()
    {
        SqlConnection cn = new SqlConnection(
            ConfigurationManager.ConnectionStrings["ForteChance"].ConnectionString);

        SqlDataAdapter da = new SqlDataAdapter(
        @"SELECT *
          FROM CORSI
          ORDER BY Titolo", cn);

        DataTable dt = new DataTable();

        da.Fill(dt);

        rptCorsi.DataSource = dt;
        rptCorsi.DataBind();
    }
}
