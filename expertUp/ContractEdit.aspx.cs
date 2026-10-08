using System;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExpertUp
{
    public partial class ContractEditPage : Page
    {
        private int ContractId
        {
            get { int id; return int.TryParse(Request.QueryString["id"], out id) && id > 0 ? id : 0; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null && ContractId == 0)
            {
                ErrorMessage.Text = "The contract identifier is invalid.";
                SaveButton.Enabled = false;
                return;
            }
            if (!IsPostBack)
            {
                BindCompanies();
                if (ContractId > 0)
                {
                    EmploymentContract contract = DataAccess.GetContract(ContractId);
                    if (contract == null)
                    {
                        ErrorMessage.Text = "The requested contract was not found.";
                        SaveButton.Enabled = false;
                        return;
                    }
                    PageHeading.Text = "Edit contract";
                    CompanyList.SelectedValue = contract.CompanyId.ToString();
                    BindEmployees(contract.CompanyId);
                    EmployeeList.SelectedValue = contract.EmployeeId.ToString();
                    ContractCode.Text = contract.ContractCode;
                    ContractType.SelectedValue = contract.ContractType;
                    StartDate.Text = contract.StartDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                    EndDate.Text = contract.EndDate.HasValue ? contract.EndDate.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) : "";
                    WeeklyHours.Text = contract.WeeklyHours.ToString("0.##", CultureInfo.InvariantCulture);
                    Status.SelectedValue = contract.Status;
                }
                else
                {
                    BindEmployees(0);
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

        private void BindEmployees(int companyId)
        {
            EmployeeList.Items.Clear();
            if (companyId > 0)
            {
                EmployeeList.DataSource = DataAccess.GetEmployeesForCompany(companyId);
                EmployeeList.DataTextField = "DisplayName";
                EmployeeList.DataValueField = "EmployeeId";
                EmployeeList.DataBind();
            }
            EmployeeList.Items.Insert(0, new ListItem("-- Select employee --", ""));
        }

        protected void CompanyList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int companyId;
            BindEmployees(int.TryParse(CompanyList.SelectedValue, out companyId) ? companyId : 0);
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;
            int companyId, employeeId;
            decimal weeklyHours;
            DateTime startDate;
            DateTime? endDate = null;
            if (!int.TryParse(CompanyList.SelectedValue, out companyId) || companyId <= 0 ||
                !int.TryParse(EmployeeList.SelectedValue, out employeeId) || employeeId <= 0)
            {
                ErrorMessage.Text = "Select a company and an employee belonging to that company.";
                return;
            }
            if (!DateTime.TryParseExact(StartDate.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate))
            {
                ErrorMessage.Text = "Enter a valid start date.";
                return;
            }
            if (!string.IsNullOrWhiteSpace(EndDate.Text))
            {
                DateTime parsedEndDate;
                if (!DateTime.TryParseExact(EndDate.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedEndDate))
                {
                    ErrorMessage.Text = "Enter a valid end date or leave it blank.";
                    return;
                }
                endDate = parsedEndDate;
                if (endDate.Value < startDate)
                {
                    ErrorMessage.Text = "End date must not be earlier than start date.";
                    return;
                }
            }
            if (!decimal.TryParse(WeeklyHours.Text, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out weeklyHours) ||
                weeklyHours <= 0 || weeklyHours > 168)
            {
                ErrorMessage.Text = "Weekly hours must be a number greater than zero and no more than 168.";
                return;
            }
            try
            {
                DataAccess.SaveContract(new EmploymentContract
                {
                    ContractId = ContractId,
                    CompanyId = companyId,
                    EmployeeId = employeeId,
                    ContractCode = ContractCode.Text.Trim(),
                    ContractType = ContractType.SelectedValue,
                    StartDate = startDate,
                    EndDate = endDate,
                    WeeklyHours = weeklyHours,
                    Status = Status.SelectedValue
                });
                Response.Redirect("Contracts.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (SqlException ex)
            {
                ErrorMessage.Text = "Could not save the contract. Check that its code is unique within the company and that the employee belongs to it. " + Server.HtmlEncode(ex.Message);
            }
        }
    }
}
