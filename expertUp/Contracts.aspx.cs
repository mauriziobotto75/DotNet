using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExpertUp
{
    public partial class ContractsPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) BindContracts();
        }

        private void BindContracts()
        {
            ContractsGrid.DataSource = DataAccess.GetContracts();
            ContractsGrid.DataBind();
        }

        protected void ContractsGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "DeleteContract") return;
            int id;
            if (!int.TryParse(Convert.ToString(e.CommandArgument), out id))
            {
                ErrorMessage.Text = "The requested contract identifier is invalid.";
                return;
            }
            try
            {
                DataAccess.DeleteContract(id);
                BindContracts();
            }
            catch (SqlException ex)
            {
                ErrorMessage.Text = "Could not delete the contract. " + Server.HtmlEncode(ex.Message);
            }
        }
    }
}
