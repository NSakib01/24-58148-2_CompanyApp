/*
    Run Schema.sql first, then run this script.

    The uploaded working project used dbEmployeeDetails.dbo.tbl_users and
    dbEmployeeDetails.dbo.Emp_details. If that previous database still exists
    on this LocalDB instance, the script migrates its records without supplying
    identity values or inventing creators for old employee rows.

    Original Access records can be added in the marked section below. The
    original db_users.mdb was not present in the supplied project archive, so
    its unknown contents cannot be fabricated or verified automatically.
*/

USE dbCompanyApp;
GO

SET NOCOUNT ON;
GO

IF DB_ID(N'dbEmployeeDetails') IS NOT NULL
   AND OBJECT_ID(N'dbEmployeeDetails.dbo.tbl_users', N'U') IS NOT NULL
BEGIN
    EXEC sys.sp_executesql N'
        INSERT INTO dbo.Users
        (
            Username,
            Password
        )
        SELECT
            source.username,
            CASE
                WHEN LEN(source.password) = 64
                     AND source.password NOT LIKE ''%[^0-9A-Fa-f]%''
                    THEN LOWER(source.password)
                ELSE LOWER(
                    CONVERT(
                        VARCHAR(64),
                        HASHBYTES(
                            ''SHA2_256'',
                            CONVERT(NVARCHAR(200), source.password)
                        ),
                        2
                    )
                )
            END
        FROM dbEmployeeDetails.dbo.tbl_users AS source
        WHERE NOT EXISTS
        (
            SELECT 1
            FROM dbo.Users AS destination
            WHERE destination.Username = source.username
        );
    ';
END;
GO

/*
    ACCESS MIGRATION TEMPLATE

    If the original Access file is available separately, open its tbl_users
    table, copy each real account, and execute one statement per account:

    INSERT INTO dbo.Users (Username, Password)
    VALUES
    (
        N'REPLACE_WITH_REAL_USERNAME',
        LOWER(
            CONVERT(
                VARCHAR(64),
                HASHBYTES('SHA2_256', N'REPLACE_WITH_REAL_PASSWORD'),
                2
            )
        )
    );

    Do not provide UserID: SQL Server generates the identity automatically.
    The hash uses NVARCHAR/UTF-16LE to match PasswordHelper.ComputeSha256.
*/

IF NOT EXISTS (SELECT 1 FROM dbo.Users)
BEGIN
    -- Known working account from the supplied manual integration session.
    INSERT INTO dbo.Users
    (
        Username,
        Password
    )
    VALUES
    (
        N'AdminTest',
        LOWER(CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', N'1234'), 2))
    );
END;
GO

IF DB_ID(N'dbEmployeeDetails') IS NOT NULL
   AND OBJECT_ID(N'dbEmployeeDetails.dbo.Emp_details', N'U') IS NOT NULL
BEGIN
    EXEC sys.sp_executesql N'
        INSERT INTO dbo.Emp_details
        (
            EmpId,
            EmpName,
            EmpAge,
            EmpContact,
            EmpGender
        )
        SELECT
            source.EmpId,
            source.EmpName,
            TRY_CONVERT(INT, source.EmpAge),
            source.EmpContact,
            source.EmpGender
        FROM dbEmployeeDetails.dbo.Emp_details AS source
        WHERE TRY_CONVERT(INT, source.EmpAge) IS NOT NULL
          AND NOT EXISTS
          (
              SELECT 1
              FROM dbo.Emp_details AS destination
              WHERE destination.EmpId = source.EmpId
          );
    ';
END;
GO

SELECT
    UserID,
    Username,
    Password,
    CreatedAt
FROM dbo.Users
ORDER BY UserID;
GO

SELECT
    employee.EmpId,
    employee.EmpName,
    employee.EmpAge,
    employee.EmpContact,
    employee.EmpGender,
    account.Username AS CreatedBy
FROM dbo.Emp_details AS employee
LEFT JOIN dbo.Users AS account
    ON employee.CreatedBy = account.UserID
ORDER BY employee.EmpName;
GO
