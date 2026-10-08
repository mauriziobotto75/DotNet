using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ExpertUp
{
    public static class DataAccess
    {
        private static SqlConnection CreateConnection()
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["ExpertUp"];
            if (settings == null || string.IsNullOrWhiteSpace(settings.ConnectionString))
                throw new ConfigurationErrorsException("The ExpertUp connection string is missing from Web.config.");
            return new SqlConnection(settings.ConnectionString);
        }

        private static string ReadNullableString(SqlDataReader reader, string name)
        {
            return reader.IsDBNull(reader.GetOrdinal(name)) ? null : reader.GetString(reader.GetOrdinal(name));
        }

        public static List<Company> GetCompanies()
        {
            List<Company> items = new List<Company>();
            using (SqlConnection connection = CreateConnection())
            using (SqlCommand command = new SqlCommand(
                "SELECT CompanyId, LegalName, VatNumber, TaxCode, Email, Phone, Address FROM dbo.Company ORDER BY LegalName;", connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                    while (reader.Read())
                        items.Add(new Company
                        {
                            CompanyId = reader.GetInt32(0),
                            LegalName = reader.GetString(1),
                            VatNumber = ReadNullableString(reader, "VatNumber"),
                            TaxCode = ReadNullableString(reader, "TaxCode"),
                            Email = ReadNullableString(reader, "Email"),
                            Phone = ReadNullableString(reader, "Phone"),
                            Address = ReadNullableString(reader, "Address")
                        });
            }
            return items;
        }

        public static Company GetCompany(int id)
        {
            using (SqlConnection connection = CreateConnection())
            using (SqlCommand command = new SqlCommand(
                "SELECT CompanyId, LegalName, VatNumber, TaxCode, Email, Phone, Address FROM dbo.Company WHERE CompanyId = @CompanyId;", connection))
            {
                command.Parameters.Add("@CompanyId", SqlDbType.Int).Value = id;
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.Read()) return null;
                    return new Company
                    {
                        CompanyId = reader.GetInt32(0),
                        LegalName = reader.GetString(1),
                        VatNumber = ReadNullableString(reader, "VatNumber"),
                        TaxCode = ReadNullableString(reader, "TaxCode"),
                        Email = ReadNullableString(reader, "Email"),
                        Phone = ReadNullableString(reader, "Phone"),
                        Address = ReadNullableString(reader, "Address")
                    };
                }
            }
        }

        public static void SaveCompany(Company company)
        {
            using (SqlConnection connection = CreateConnection())
            using (SqlCommand command = new SqlCommand(company.CompanyId == 0
                ? "INSERT dbo.Company (LegalName, VatNumber, TaxCode, Email, Phone, Address) VALUES (@LegalName, @VatNumber, @TaxCode, @Email, @Phone, @Address);"
                : "UPDATE dbo.Company SET LegalName=@LegalName, VatNumber=@VatNumber, TaxCode=@TaxCode, Email=@Email, Phone=@Phone, Address=@Address WHERE CompanyId=@CompanyId;", connection))
            {
                AddCompanyParameters(command, company);
                if (company.CompanyId != 0) command.Parameters.Add("@CompanyId", SqlDbType.Int).Value = company.CompanyId;
                connection.Open();
                int affected = command.ExecuteNonQuery();
                if (company.CompanyId != 0 && affected == 0) throw new InvalidOperationException("The company no longer exists.");
            }
        }

        private static void AddCompanyParameters(SqlCommand command, Company company)
        {
            command.Parameters.Add("@LegalName", SqlDbType.NVarChar, 200).Value = company.LegalName;
            command.Parameters.Add("@VatNumber", SqlDbType.NVarChar, 20).Value = (object)company.VatNumber ?? DBNull.Value;
            command.Parameters.Add("@TaxCode", SqlDbType.NVarChar, 20).Value = (object)company.TaxCode ?? DBNull.Value;
            command.Parameters.Add("@Email", SqlDbType.NVarChar, 254).Value = (object)company.Email ?? DBNull.Value;
            command.Parameters.Add("@Phone", SqlDbType.NVarChar, 40).Value = (object)company.Phone ?? DBNull.Value;
            command.Parameters.Add("@Address", SqlDbType.NVarChar, 300).Value = (object)company.Address ?? DBNull.Value;
        }

        public static void DeleteCompany(int id)
        {
            ExecuteDelete("DELETE dbo.Company WHERE CompanyId=@Id;", id);
        }

        public static List<Employee> GetEmployees()
        {
            List<Employee> items = new List<Employee>();
            using (SqlConnection connection = CreateConnection())
            using (SqlCommand command = new SqlCommand(
                "SELECT e.EmployeeId, e.CompanyId, c.LegalName, e.TaxCode, e.FirstName, e.LastName, e.Email, e.Phone FROM dbo.Employee e INNER JOIN dbo.Company c ON c.CompanyId=e.CompanyId ORDER BY e.LastName, e.FirstName;", connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                    while (reader.Read()) items.Add(ReadEmployee(reader));
            }
            return items;
        }

        public static List<Employee> GetEmployeesForCompany(int companyId)
        {
            List<Employee> items = new List<Employee>();
            using (SqlConnection connection = CreateConnection())
            using (SqlCommand command = new SqlCommand(
                "SELECT e.EmployeeId, e.CompanyId, c.LegalName, e.TaxCode, e.FirstName, e.LastName, e.Email, e.Phone FROM dbo.Employee e INNER JOIN dbo.Company c ON c.CompanyId=e.CompanyId WHERE e.CompanyId=@CompanyId ORDER BY e.LastName, e.FirstName;", connection))
            {
                command.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                    while (reader.Read()) items.Add(ReadEmployee(reader));
            }
            return items;
        }

        public static Employee GetEmployee(int id)
        {
            using (SqlConnection connection = CreateConnection())
            using (SqlCommand command = new SqlCommand(
                "SELECT e.EmployeeId, e.CompanyId, c.LegalName, e.TaxCode, e.FirstName, e.LastName, e.Email, e.Phone FROM dbo.Employee e INNER JOIN dbo.Company c ON c.CompanyId=e.CompanyId WHERE e.EmployeeId=@EmployeeId;", connection))
            {
                command.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = id;
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                    return reader.Read() ? ReadEmployee(reader) : null;
            }
        }

        private static Employee ReadEmployee(SqlDataReader reader)
        {
            return new Employee
            {
                EmployeeId = reader.GetInt32(0),
                CompanyId = reader.GetInt32(1),
                CompanyName = reader.GetString(2),
                TaxCode = reader.GetString(3),
                FirstName = reader.GetString(4),
                LastName = reader.GetString(5),
                Email = ReadNullableString(reader, "Email"),
                Phone = ReadNullableString(reader, "Phone")
            };
        }

        public static void SaveEmployee(Employee employee)
        {
            using (SqlConnection connection = CreateConnection())
            using (SqlCommand command = new SqlCommand(employee.EmployeeId == 0
                ? "INSERT dbo.Employee (CompanyId, TaxCode, FirstName, LastName, Email, Phone) VALUES (@CompanyId, @TaxCode, @FirstName, @LastName, @Email, @Phone);"
                : "UPDATE dbo.Employee SET CompanyId=@CompanyId, TaxCode=@TaxCode, FirstName=@FirstName, LastName=@LastName, Email=@Email, Phone=@Phone WHERE EmployeeId=@EmployeeId;", connection))
            {
                AddEmployeeParameters(command, employee);
                if (employee.EmployeeId != 0) command.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = employee.EmployeeId;
                connection.Open();
                int affected = command.ExecuteNonQuery();
                if (employee.EmployeeId != 0 && affected == 0) throw new InvalidOperationException("The employee no longer exists.");
            }
        }

        private static void AddEmployeeParameters(SqlCommand command, Employee employee)
        {
            command.Parameters.Add("@CompanyId", SqlDbType.Int).Value = employee.CompanyId;
            command.Parameters.Add("@TaxCode", SqlDbType.NVarChar, 20).Value = employee.TaxCode;
            command.Parameters.Add("@FirstName", SqlDbType.NVarChar, 100).Value = employee.FirstName;
            command.Parameters.Add("@LastName", SqlDbType.NVarChar, 100).Value = employee.LastName;
            command.Parameters.Add("@Email", SqlDbType.NVarChar, 254).Value = (object)employee.Email ?? DBNull.Value;
            command.Parameters.Add("@Phone", SqlDbType.NVarChar, 40).Value = (object)employee.Phone ?? DBNull.Value;
        }

        public static void DeleteEmployee(int id)
        {
            ExecuteDelete("DELETE dbo.Employee WHERE EmployeeId=@Id;", id);
        }

        public static List<EmploymentContract> GetContracts()
        {
            List<EmploymentContract> items = new List<EmploymentContract>();
            using (SqlConnection connection = CreateConnection())
            using (SqlCommand command = new SqlCommand(
                "SELECT ct.ContractId, ct.CompanyId, co.LegalName, ct.EmployeeId, e.FirstName + N' ' + e.LastName, ct.ContractCode, ct.ContractType, ct.StartDate, ct.EndDate, ct.WeeklyHours, ct.Status FROM dbo.EmploymentContract ct INNER JOIN dbo.Company co ON co.CompanyId=ct.CompanyId INNER JOIN dbo.Employee e ON e.EmployeeId=ct.EmployeeId ORDER BY ct.StartDate DESC, ct.ContractCode;", connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                    while (reader.Read()) items.Add(ReadContract(reader));
            }
            return items;
        }

        public static EmploymentContract GetContract(int id)
        {
            using (SqlConnection connection = CreateConnection())
            using (SqlCommand command = new SqlCommand(
                "SELECT ct.ContractId, ct.CompanyId, co.LegalName, ct.EmployeeId, e.FirstName + N' ' + e.LastName, ct.ContractCode, ct.ContractType, ct.StartDate, ct.EndDate, ct.WeeklyHours, ct.Status FROM dbo.EmploymentContract ct INNER JOIN dbo.Company co ON co.CompanyId=ct.CompanyId INNER JOIN dbo.Employee e ON e.EmployeeId=ct.EmployeeId WHERE ct.ContractId=@ContractId;", connection))
            {
                command.Parameters.Add("@ContractId", SqlDbType.Int).Value = id;
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                    return reader.Read() ? ReadContract(reader) : null;
            }
        }

        private static EmploymentContract ReadContract(SqlDataReader reader)
        {
            return new EmploymentContract
            {
                ContractId = reader.GetInt32(0),
                CompanyId = reader.GetInt32(1),
                CompanyName = reader.GetString(2),
                EmployeeId = reader.GetInt32(3),
                EmployeeName = reader.GetString(4),
                ContractCode = reader.GetString(5),
                ContractType = reader.GetString(6),
                StartDate = reader.GetDateTime(7),
                EndDate = reader.IsDBNull(8) ? (DateTime?)null : reader.GetDateTime(8),
                WeeklyHours = reader.GetDecimal(9),
                Status = reader.GetString(10)
            };
        }

        public static void SaveContract(EmploymentContract contract)
        {
            using (SqlConnection connection = CreateConnection())
            using (SqlCommand command = new SqlCommand(contract.ContractId == 0
                ? "INSERT dbo.EmploymentContract (CompanyId, EmployeeId, ContractCode, ContractType, StartDate, EndDate, WeeklyHours, Status) VALUES (@CompanyId, @EmployeeId, @ContractCode, @ContractType, @StartDate, @EndDate, @WeeklyHours, @Status);"
                : "UPDATE dbo.EmploymentContract SET CompanyId=@CompanyId, EmployeeId=@EmployeeId, ContractCode=@ContractCode, ContractType=@ContractType, StartDate=@StartDate, EndDate=@EndDate, WeeklyHours=@WeeklyHours, Status=@Status WHERE ContractId=@ContractId;", connection))
            {
                command.Parameters.Add("@CompanyId", SqlDbType.Int).Value = contract.CompanyId;
                command.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = contract.EmployeeId;
                command.Parameters.Add("@ContractCode", SqlDbType.NVarChar, 40).Value = contract.ContractCode;
                command.Parameters.Add("@ContractType", SqlDbType.NVarChar, 40).Value = contract.ContractType;
                command.Parameters.Add("@StartDate", SqlDbType.Date).Value = contract.StartDate.Date;
                command.Parameters.Add("@EndDate", SqlDbType.Date).Value = (object)contract.EndDate ?? DBNull.Value;
                command.Parameters.Add("@WeeklyHours", SqlDbType.Decimal).Value = contract.WeeklyHours;
                command.Parameters["@WeeklyHours"].Precision = 5;
                command.Parameters["@WeeklyHours"].Scale = 2;
                command.Parameters.Add("@Status", SqlDbType.NVarChar, 20).Value = contract.Status;
                if (contract.ContractId != 0) command.Parameters.Add("@ContractId", SqlDbType.Int).Value = contract.ContractId;
                connection.Open();
                int affected = command.ExecuteNonQuery();
                if (contract.ContractId != 0 && affected == 0) throw new InvalidOperationException("The contract no longer exists.");
            }
        }

        public static void DeleteContract(int id)
        {
            ExecuteDelete("DELETE dbo.EmploymentContract WHERE ContractId=@Id;", id);
        }

        private static void ExecuteDelete(string sql, int id)
        {
            using (SqlConnection connection = CreateConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
