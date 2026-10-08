using System;

namespace ExpertUp
{
    public sealed class Company
    {
        public int CompanyId { get; set; }
        public string LegalName { get; set; }
        public string VatNumber { get; set; }
        public string TaxCode { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }

    public sealed class Employee
    {
        public int EmployeeId { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string TaxCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string DisplayName { get { return LastName + ", " + FirstName + " (" + TaxCode + ")"; } }
    }

    public sealed class EmploymentContract
    {
        public int ContractId { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string ContractCode { get; set; }
        public string ContractType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal WeeklyHours { get; set; }
        public string Status { get; set; }
    }
}
