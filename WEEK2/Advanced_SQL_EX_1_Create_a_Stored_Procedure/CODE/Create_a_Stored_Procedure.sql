USE EmployeeManagementDB;  -- Change to your DB name
GO

-- Create Insert Stored Procedure
CREATE PROCEDURE sp_InsertEmployee 
    @FirstName VARCHAR(50), 
    @LastName VARCHAR(50), 
    @DepartmentID INT, 
    @Salary DECIMAL(10,2), 
    @JoinDate DATE
AS
BEGIN
    INSERT INTO Employees (FirstName, LastName, DepartmentID, Salary, JoinDate)
    VALUES (@FirstName, @LastName, @DepartmentID, @Salary, @JoinDate);
END;
GO

-- Create Select Stored Procedure
CREATE PROCEDURE sp_GetEmployeesByDepartment
    @DepartmentID INT
AS
BEGIN
    SELECT 
        EmployeeID,
        FirstName,
        LastName,
        Salary,
        JoinDate
    FROM 
        Employees
    WHERE 
        DepartmentID = @DepartmentID;
END;
GO

-- Test the insert
EXEC sp_InsertEmployee 
    @FirstName = 'Alice',
    @LastName = 'Williams',
    @DepartmentID = 2,
    @Salary = 6200.00,
    @JoinDate = '2023-06-01';
GO

-- Test the select
EXEC sp_GetEmployeesByDepartment @DepartmentID = 2;
GO
