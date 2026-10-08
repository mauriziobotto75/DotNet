using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExpertUp
{
    public partial class CompaniesPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) BindCompanies();
        }

        private void BindCompanies()
        {
            CompaniesGrid.DataSource = DataAccess.GetCompanies();
            CompaniesGrid.DataBind();
        }

        protected void CompaniesGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "DeleteCompany") return;
            int id;
            if (!int.TryParse(Convert.ToString(e.CommandArgument), out id))
            {
                ErrorMessage.Text = "The requested company identifier is invalid.";
                return;
            }
            try
            {
                DataAccess.DeleteCompany(id);
                BindCompanies();
            }
            catch (SqlException ex)
            {
                ErrorMessage.Text = "Could not delete the company. It may still have employees or linked records. " + Server.HtmlEncode(ex.Message);
            }
        }
    }
}
