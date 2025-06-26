USE EmployeeManagementDB;
GO

-- Drop the stored procedures if they exist
IF OBJECT_ID('sp_InsertEmployee', 'P') IS NOT NULL
    DROP PROCEDURE sp_InsertEmployee;
GO

IF OBJECT_ID('sp_GetEmployeesByDepartment', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetEmployeesByDepartment;
GO

-- Drop tables if they already exist
IF OBJECT_ID('Employees', 'U') IS NOT NULL
    DROP TABLE Employees;
GO

IF OBJECT_ID('Departments', 'U') IS NOT NULL
    DROP TABLE Departments;
GO

-- Create Departments Table
CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(100)
);
GO

-- Create Employees Table (with IDENTITY to auto-generate EmployeeID)
CREATE TABLE Employees (
    EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(90),
    LastName VARCHAR(90),
    DepartmentID INT,
    Salary DECIMAL(10,2),
    JoinDate DATE,
    FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
);
GO

-- Insert sample departments
INSERT INTO Departments (DepartmentID, DepartmentName)
VALUES 
    (1, 'HR'),
    (2, 'Finance'),
    (3, 'IT'),
    (4, 'Marketing');
GO

-- Insert employees (don't include EmployeeID — it auto-generates)
INSERT INTO Employees (FirstName, LastName, DepartmentID, Salary, JoinDate)
VALUES 
    ('John', 'Doe', 1, 5000.00, '2020-01-15'),
    ('Jane', 'Smith', 2, 6000.00, '2019-03-22'),
    ('Michael', 'Johnson', 3, 7000.00, '2018-07-30'),
    ('Emily', 'Davis', 4, 5500.00, '2021-11-05');
GO

