# Employee Management System - SQL Script

This project sets up a simple **Employee Management System** in SQL Server using two main tables — `Departments` and `Employees`. It also includes sample data and prepares the database for use with stored procedures (created separately).

---

## 📁 Files

- `source1.sql`: SQL script to create tables, insert sample data, and clean up existing structures.

---

## 📌 Features

- Drops existing tables and stored procedures to avoid conflicts.
- Creates:
  - `Departments` table (with DepartmentID and DepartmentName).
  - `Employees` table (with auto-incrementing EmployeeID).
- Inserts sample department and employee data.
- Ensures foreign key relationship between employees and departments.

---

## 📂 Tables

### 🔸 Departments

| Column         | Type         | Description            |
| -------------- | ------------ | ---------------------- |
| DepartmentID   | INT (PK)     | Unique department ID   |
| DepartmentName | VARCHAR(100) | Name of the department |

### 🔸 Employees

| Column       | Type               | Description                          |
| ------------ | ------------------ | ------------------------------------ |
| EmployeeID   | INT (PK, IDENTITY) | Auto-generated unique employee ID    |
| FirstName    | VARCHAR(90)        | Employee's first name                |
| LastName     | VARCHAR(90)        | Employee's last name                 |
| DepartmentID | INT (FK)           | Linked to `Departments.DepartmentID` |
| Salary       | DECIMAL(10,2)      | Monthly salary                       |
| JoinDate     | DATE               | Date of joining                      |

---

## 🧪 Sample Data Inserted

### Departments

- HR
- Finance
- IT
- Marketing

### Employees

- John Doe – HR – ₹5000 – Joined: 2020-01-15
- Jane Smith – Finance – ₹6000 – Joined: 2019-03-22
- Michael Johnson – IT – ₹7000 – Joined: 2018-07-30
- Emily Davis – Marketing – ₹5500 – Joined: 2021-11-05

---

## ▶️ How to Run

1. Open **Command Prompt** or **Windows Terminal**.
2. Make sure SQL Server is running.
3. Run the script using `sqlcmd`:
   ```bash
   sqlcmd -S localhost -E -d EmployeeManagementDB -i "path\to\source1.sql"
   ```

---
