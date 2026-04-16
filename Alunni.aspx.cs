    using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace ForteChance

{
    public partial class AlunniList : System.Web.UI.Page
    {
        protected global::System.Web.UI.WebControls.GridView GridViewAlunni;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAlunni();
            }
        }

        private void LoadAlunni()
        {
            // Replace with your connection string
            string connStr = "your_connection_string";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Id, Nome, Cognome FROM Alunni", conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    System.Data.DataTable dt = new System.Data.DataTable();
                    dt.Load(reader);
                    GridViewAlunni.DataSource = dt;
                    GridViewAlunni.DataBind();
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AlunniEdit.aspx");
        }

        protected void GridViewAlunni_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = GridViewAlunni.SelectedDataKey.Value;
            Response.Redirect("AlunniEdit.aspx?id=" + id);
        }
    }
}
