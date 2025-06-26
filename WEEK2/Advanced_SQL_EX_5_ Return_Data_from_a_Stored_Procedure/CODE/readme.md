# Exercise 5: Return Data from a Stored Procedure

This exercise demonstrates how to create and use a **stored procedure** in SQL Server to return the **total number of employees in a specific department**.

---

## 🎯 Goal

Create a stored procedure that:

- Accepts a `DepartmentID` as input.
- Returns the **count of employees** in that department.

---

## 🛠️ Stored Procedure: `sp_CountEmployeesByDepartment`

```sql
USE EmployeeManagementDB;
GO

-- Drop the procedure if it exists
IF OBJECT_ID('sp_CountEmployeesByDepartment', 'P') IS NOT NULL
    DROP PROCEDURE sp_CountEmployeesByDepartment;
GO

-- Create the procedure
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
```

▶️ How to Run

```bash

sqlcmd -S localhost -E -d EmployeeManagementDB -i "path\to\Return_Data_from_a_Stored_Procedure.sql"
```

> Replace `"path\to\Return_Data_from_a_Stored_Procedure.sql"` with the actual path to your `.sql` file.

## 🔍 Example Execution

```sql
EXEC sp_CountEmployeesByDepartment @DepartmentID = 2;
```

✅ Sample Output

```markdown
---

2

(1 rows affected)
```

This confirms that there are _2 employees_ in Department ID `2`.

## 📌 Notes

- Make sure the Employees table is populated before executing this script.

- This is a simple utility stored procedure useful for analytics, reporting, or admin dashboards.

---
