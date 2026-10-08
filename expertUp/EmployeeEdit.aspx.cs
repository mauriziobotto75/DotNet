using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExpertUp
{
    public partial class EmployeeEditPage : Page
    {
        private int EmployeeId
        {
            get { int id; return int.TryParse(Request.QueryString["id"], out id) && id > 0 ? id : 0; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null && EmployeeId == 0)
            {
                ErrorMessage.Text = "The employee identifier is invalid.";
                SaveButton.Enabled = false;
                return;
            }
            if (!IsPostBack)
            {
                BindCompanies();
                if (EmployeeId > 0)
                {
                    Employee employee = DataAccess.GetEmployee(EmployeeId);
                    if (employee == null)
                    {
                        ErrorMessage.Text = "The requested employee was not found.";
                        SaveButton.Enabled = false;
                        return;
                    }
                    PageHeading.Text = "Edit employee";
                    CompanyList.SelectedValue = employee.CompanyId.ToString();
                    TaxCode.Text = employee.TaxCode;
                    FirstName.Text = employee.FirstName;
                    LastName.Text = employee.LastName;
                    Email.Text = employee.Email;
                    Phone.Text = employee.Phone;
                }
            }
        }

        private void BindCompanies()
        {
            CompanyList.DataSource = DataAccess.GetCompanies();
            CompanyList.DataTextField = "LegalName";
            CompanyList.DataValueField = "CompanyId";
            CompanyList.DataBind();
            CompanyList.Items.Insert(0, new ListItem("-- Select company --", ""));
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;
            int companyId;
            if (!int.TryParse(CompanyList.SelectedValue, out companyId) || companyId <= 0)
            {
                ErrorMessage.Text = "Select a valid company.";
                return;
            }
            try
            {
                DataAccess.SaveEmployee(new Employee
                {
                    EmployeeId = EmployeeId,
                    CompanyId = companyId,
                    TaxCode = TaxCode.Text.Trim(),
                    FirstName = FirstName.Text.Trim(),
                    LastName = LastName.Text.Trim(),
                    Email = EmptyToNull(Email.Text),
                    Phone = EmptyToNull(Phone.Text)
                });
                Response.Redirect("Employees.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (SqlException ex)
            {
                ErrorMessage.Text = "Could not save the employee. Check that the selected company exists and the tax code is unique. " + Server.HtmlEncode(ex.Message);
            }
        }

        private static string EmptyToNull(string value)
        {
            string trimmed = value.Trim();
            return trimmed.Length == 0 ? null : trimmed;
        }
    }
}
