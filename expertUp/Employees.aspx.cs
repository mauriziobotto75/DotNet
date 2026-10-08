using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExpertUp
{
    public partial class EmployeesPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) BindEmployees();
        }

        private void BindEmployees()
        {
            EmployeesGrid.DataSource = DataAccess.GetEmployees();
            EmployeesGrid.DataBind();
        }

        protected void EmployeesGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "DeleteEmployee") return;
            int id;
            if (!int.TryParse(Convert.ToString(e.CommandArgument), out id))
            {
                ErrorMessage.Text = "The requested employee identifier is invalid.";
                return;
            }
            try
            {
                DataAccess.DeleteEmployee(id);
                BindEmployees();
            }
            catch (SqlException ex)
            {
                ErrorMessage.Text = "Could not delete the employee. It may still have contracts. " + Server.HtmlEncode(ex.Message);
            }
        }
    }
}
