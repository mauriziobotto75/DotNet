-- Run this script in the ExpertUp database.
CREATE TABLE dbo.Company
(
    CompanyId int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Company PRIMARY KEY,
    LegalName nvarchar(200) NOT NULL,
    VatNumber nvarchar(20) NULL,
    TaxCode nvarchar(20) NULL,
    Email nvarchar(254) NULL,
    Phone nvarchar(40) NULL,
    Address nvarchar(300) NULL,
    CreatedAt datetime2(0) NOT NULL CONSTRAINT DF_Company_CreatedAt DEFAULT (SYSUTCDATETIME())
);
GO

CREATE UNIQUE INDEX UX_Company_VatNumber
    ON dbo.Company(VatNumber) WHERE VatNumber IS NOT NULL;
CREATE UNIQUE INDEX UX_Company_TaxCode
    ON dbo.Company(TaxCode) WHERE TaxCode IS NOT NULL;
GO

CREATE TABLE dbo.Employee
(
    EmployeeId int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Employee PRIMARY KEY,
    CompanyId int NOT NULL,
    TaxCode nvarchar(20) NOT NULL,
    FirstName nvarchar(100) NOT NULL,
    LastName nvarchar(100) NOT NULL,
    Email nvarchar(254) NULL,
    Phone nvarchar(40) NULL,
    CreatedAt datetime2(0) NOT NULL CONSTRAINT DF_Employee_CreatedAt DEFAULT (SYSUTCDATETIME()),
    CONSTRAINT FK_Employee_Company FOREIGN KEY (CompanyId)
        REFERENCES dbo.Company(CompanyId),
    CONSTRAINT UQ_Employee_Company_Employee UNIQUE (CompanyId, EmployeeId)
);
GO

CREATE UNIQUE INDEX UX_Employee_TaxCode ON dbo.Employee(TaxCode);
GO

CREATE TABLE dbo.EmploymentContract
(
    ContractId int IDENTITY(1,1) NOT NULL CONSTRAINT PK_EmploymentContract PRIMARY KEY,
    CompanyId int NOT NULL,
    EmployeeId int NOT NULL,
    ContractCode nvarchar(40) NOT NULL,
    ContractType nvarchar(40) NOT NULL,
    StartDate date NOT NULL,
    EndDate date NULL,
    WeeklyHours decimal(5,2) NOT NULL,
    Status nvarchar(20) NOT NULL,
    CreatedAt datetime2(0) NOT NULL CONSTRAINT DF_EmploymentContract_CreatedAt DEFAULT (SYSUTCDATETIME()),
    CONSTRAINT FK_EmploymentContract_Company FOREIGN KEY (CompanyId)
        REFERENCES dbo.Company(CompanyId),
    CONSTRAINT FK_EmploymentContract_EmployeeCompany FOREIGN KEY (CompanyId, EmployeeId)
        REFERENCES dbo.Employee(CompanyId, EmployeeId),
    CONSTRAINT CK_EmploymentContract_Dates CHECK (EndDate IS NULL OR EndDate >= StartDate),
    CONSTRAINT CK_EmploymentContract_WeeklyHours CHECK (WeeklyHours > 0 AND WeeklyHours <= 168),
    CONSTRAINT CK_EmploymentContract_Type CHECK
        (ContractType IN (N'Permanent', N'Fixed-term', N'Part-time', N'Other')),
    CONSTRAINT CK_EmploymentContract_Status CHECK
        (Status IN (N'Draft', N'Active', N'Ended')),
    CONSTRAINT UQ_EmploymentContract_Company_Code UNIQUE (CompanyId, ContractCode)
);
GO
