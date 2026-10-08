using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace ExpertUp
{
    public partial class CompanyEditPage : Page
    {
        private int CompanyId
        {
            get { int id; return int.TryParse(Request.QueryString["id"], out id) && id > 0 ? id : 0; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null && CompanyId == 0)
            {
                ErrorMessage.Text = "The company identifier is invalid.";
                SaveButton.Enabled = false;
                return;
            }
            if (!IsPostBack && CompanyId > 0)
            {
                Company company = DataAccess.GetCompany(CompanyId);
                if (company == null)
                {
                    ErrorMessage.Text = "The requested company was not found.";
                    SaveButton.Enabled = false;
                    return;
                }
                PageHeading.Text = "Edit company";
                LegalName.Text = company.LegalName;
                VatNumber.Text = company.VatNumber;
                TaxCode.Text = company.TaxCode;
                Email.Text = company.Email;
                Phone.Text = company.Phone;
                Address.Text = company.Address;
            }
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;
            try
            {
                DataAccess.SaveCompany(new Company
                {
                    CompanyId = CompanyId,
                    LegalName = LegalName.Text.Trim(),
                    VatNumber = EmptyToNull(VatNumber.Text),
                    TaxCode = EmptyToNull(TaxCode.Text),
                    Email = EmptyToNull(Email.Text),
                    Phone = EmptyToNull(Phone.Text),
                    Address = EmptyToNull(Address.Text)
                });
                Response.Redirect("Companies.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (SqlException ex)
            {
                ErrorMessage.Text = "Could not save the company. Check that VAT number and tax code are unique, and review the database message. " + Server.HtmlEncode(ex.Message);
            }
        }

        private static string EmptyToNull(string value)
        {
            string trimmed = value.Trim();
            return trimmed.Length == 0 ? null : trimmed;
        }
    }
}
