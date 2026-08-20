/*
    Lab 2: Merging Login/Register and Employee CRUD into One App
    Student: MD. Nazmus Sakib
    Student ID: 24-58148-2

    Run this script first against the SQL Server LocalDB instance.
    It is safe to run more than once: existing tables are preserved.
*/

IF DB_ID(N'dbCompanyApp') IS NULL
BEGIN
    CREATE DATABASE dbCompanyApp;
END;
GO

USE dbCompanyApp;
GO

IF OBJECT_ID(N'dbo.Users', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Users
    (
        UserID INT IDENTITY(1, 1) PRIMARY KEY,
        Username NVARCHAR(50) NOT NULL UNIQUE,
        Password NVARCHAR(200) NOT NULL,
        CreatedAt DATETIME NOT NULL
            CONSTRAINT DF_Users_CreatedAt DEFAULT GETDATE()
    );
END;
GO

IF OBJECT_ID(N'dbo.Emp_details', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Emp_details
    (
        EmpId NVARCHAR(50) PRIMARY KEY,
        EmpName NVARCHAR(100) NOT NULL,
        EmpAge INT NOT NULL,
        EmpContact NVARCHAR(20) NULL,
        EmpGender NVARCHAR(10) NULL,
        CreatedBy INT NULL,

        CONSTRAINT FK_Emp_CreatedBy
            FOREIGN KEY (CreatedBy)
            REFERENCES dbo.Users(UserID)
    );
END;
GO

IF NOT EXISTS
(
    SELECT 1
    FROM sys.indexes
    WHERE name = N'IX_Emp_details_CreatedBy'
      AND object_id = OBJECT_ID(N'dbo.Emp_details')
)
BEGIN
    CREATE INDEX IX_Emp_details_CreatedBy
        ON dbo.Emp_details(CreatedBy);
END;
GO

SELECT
    TABLE_SCHEMA,
    TABLE_NAME
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE'
ORDER BY TABLE_NAME;
GO
