# ExpertUp MVP

A small ASP.NET Web Forms (.NET Framework 4.7.2) website for managing company records, employee records, and employment-contract records. Its scope is inspired by selected ideas in the 2016 Linea Lavoro document; it is not a payroll system and does not implement or claim compliance with current tax, labour, or payroll law.

## Requirements

- Windows with IIS Express / Visual Studio and the .NET Framework 4.7.2 developer pack.
- SQL Server LocalDB or another SQL Server instance.

## Database setup

1. Create a database named `ExpertUp` on the SQL Server instance you will use.
2. Run `Database\schema.sql` against that database.
3. If using a different SQL Server instance or authentication method, update the `ExpertUp` connection string in `Web.config`. The checked-in value uses LocalDB and Windows integrated authentication; it contains no credentials.

## Run

Open `expertUp` as an ASP.NET Web Site in Visual Studio and run `Default.aspx` with IIS Express. The pages are compiled by ASP.NET using their `CodeFile` directives and classes under `App_Code`.

Companies can be created, edited, listed, and deleted when they have no employees. Employees belong to one company and can be created, edited, listed, and deleted when they have no contracts. Contracts belong to an employee and that employee's company; database constraints reject mismatched relationships and invalid date/hour values. Unique tax identifiers and company contract codes are enforced by SQL Server.

## Scope and data handling

This MVP stores basic business/contact details and contract metadata only. Contract categories and status are administrative labels; they do not determine legal validity or entitlements. It does not calculate payroll, contributions, payslips, UNIEMENS, F24, tax, or legal deadlines. Do not use it as a substitute for current professional or legal advice.

The connection string defaults to local development. Configure access controls, backups, transport security, and appropriate privacy safeguards before using real personal data.
