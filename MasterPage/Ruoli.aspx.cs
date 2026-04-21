using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage_Ruoli : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadRuoli();
        }
    }

    private void LoadRuoli()
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Polo_Formativo_Regione_Piemonte"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Ruoli", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            GridView RuoliGridView = (GridView)FindControl("RuoliGridView");
            RuoliGridView.DataSource = dt;
            RuoliGridView.DataBind();
        }
    }
}