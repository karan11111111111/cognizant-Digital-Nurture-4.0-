# Employee Management System – Stored Procedure Script

This SQL script defines and tests **stored procedures** for an Employee Management System. It should be run on a SQL Server database named `EmployeeManagementDB` (created beforehand).

---

## 📄 Script Overview

### 🎯 Goal

To define and test stored procedures that:

1. Insert a new employee into the `Employees` table.
2. Retrieve employees based on their department.

---

## 📂 Stored Procedures

### 🔹 1. `sp_InsertEmployee`

**Purpose:**  
Inserts a new employee record into the `Employees` table.

**Parameters:**
| Name | Type | Description |
|--------------|--------------|--------------------------|
| @FirstName | VARCHAR(50) | Employee's first name |
| @LastName | VARCHAR(50) | Employee's last name |
| @DepartmentID| INT | Department the employee belongs to |
| @Salary | DECIMAL(10,2)| Employee's salary |
| @JoinDate | DATE | Date the employee joined |

**Sample Execution:**

```sql
EXEC sp_InsertEmployee
    @FirstName = 'Alice',
    @LastName = 'Williams',
    @DepartmentID = 2,
    @Salary = 6200.00,
    @JoinDate = '2023-06-01';
```

---

### 🔹 2. `sp_GetEmployeesByDepartment`

**Purpose:**  
Fetches employees working in a specific department.

**Parameters:**

| Name          | Type | Description             |
| ------------- | ---- | ----------------------- |
| @DepartmentID | INT  | Department to filter by |

**Sample Execution:**

```sql
EXEC sp_GetEmployeesByDepartment @DepartmentID = 2;
```

## ✅ Requirements

Before running this script:

- Ensure the database `EmployeeManagementDB` exists.
- Ensure the `Employees` table exists with the following schema:

```sql
CREATE TABLE Employees (
    EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DepartmentID INT,
    Salary DECIMAL(10,2),
    JoinDate DATE
);
```

---

## ⚠️ Note: The DepartmentID column should match existing department values if foreign key constraints are enabled.

## ▶️ How to Run the Script

1. Open **Command Prompt** or **Windows Terminal**.
2. Run the script using `sqlcmd`:

```bash
sqlcmd -S localhost -E -d EmployeeManagementDB -i "path\to\your_script.sql"
```

## 📌 Notes

- Ensure the Departments and Employees tables are already created before executing this script.

- The INSERT and SELECT statements at the bottom of the script are test calls to verify that the stored procedures work correctly.

## ✅ Expected Output

When the script runs successfully, you'll see the result of the select query for employees in Department ID 2.

### Sample output:

```yml
EmployeeID  FirstName   LastName   Salary    JoinDate
----------- ----------- ---------- --------- ----------
2           Jane        Smith      6000.00   2019-03-22
5           Alice       Williams   6200.00   2023-06-01
```

✅ This confirms that the insert procedure worked and the new employee is correctly added.
