USE EmployeeManagementDB;
GO

-- Drop the procedure if it already exists
IF OBJECT_ID('sp_CountEmployeesByDepartment', 'P') IS NOT NULL
    DROP PROCEDURE sp_CountEmployeesByDepartment;
GO

-- Create the stored procedure
CREATE PROCEDURE sp_CountEmployeesByDepartment
    @DepartmentID INT
AS
BEGIN
    SELECT 
        COUNT(*) AS TotalEmployees
    FROM 
        Employees
    WHERE 
        DepartmentID = @DepartmentID;
END;
GO

-- Test the procedure
EXEC sp_CountEmployeesByDepartment @DepartmentID = 2;
GO
