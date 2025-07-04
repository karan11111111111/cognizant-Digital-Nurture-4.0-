# 🧪 Lab 3: Using EF Core CLI to Create and Apply Migrations

## 📚 Scenario
The retail store's database needs to be created based on the models you've defined. In this lab, you'll use **EF Core CLI** to generate and apply migrations that define your database schema.

---

## 🎯 Objective
Learn how to use **EF Core CLI** to:
- Manage database schema changes
- Apply migrations to SQL Server
- Confirm table creation in the database

---

## ✅ Prerequisites
- Models (`Product`, `Category`) already defined
- `AppDbContext.cs` configured with a valid SQL Server connection string
- .NET 6 or later installed

---

## 🧰 Tools Required
- [.NET SDK](https://dotnet.microsoft.com/download)
- [SQL Server](Express or Full)
- [SQL Server Management Studio (SSMS)] or `sqlcmd` (optional)

---

## 🛠️ Steps

### 1️⃣ Install EF Core CLI (if not already installed)
```bash
dotnet tool install --global dotnet-ef
```

#### Verify installation:

```bash
dotnet ef
```

### 2️⃣ Add Required EF Core Packages (if not done already)
```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
```
### 3️⃣ Create Initial Migration
```bash
dotnet ef migrations add InitialCreate
```

### 📁 This generates a new Migrations/ folder containing:

- `InitialCreate.cs`

- `RetailInventoryModelSnapshot.cs`

### 4️⃣ Apply Migration to Create Database
```bash
dotnet ef database update
```
### ✅ Output should include:

```nginx
Applying migration '20250704071238_InitialCreate'.
Done.
```

### 5️⃣ Verify in SQL Server (Choose One)
#### 🅰️ Using sqlcmd
```bash
sqlcmd -S localhost\SQLEXPRESS -E
```
#### Then run:

```sql
USE RetailStoreDb;
GO

SELECT name FROM sys.tables;
GO
```

### Expected output:
```nginx
Categories
Products
__EFMigrationsHistory
```

---

### 🅱️ Using SSMS
- Open SSMS

- Connect to your SQL Server instance

- Expand the RetailStoreDb database

- Go to Tables and confirm:

    - Categories

    -  Products

    - __EFMigrationsHistory
    
    
 --- 

  ##   🧹 Troubleshooting
### ⚠️ Error: There is already an object named 'Categories'
You likely used `EnsureCreated()` in an earlier lab. 
#### To resolve:

- ####  Option 1: Drop the database (cleanest)
```bash

sqlcmd -S localhost\SQLEXPRESS -E -Q "DROP DATABASE RetailStoreDb"
```
#### Then re-run:

``` bash
dotnet ef database update
Option 2: Remove the migration
```
```bash
dotnet ef database update 0
dotnet ef migrations remove
```

### ✅ Output Summary

Tables successfully created:

- Products

- Categories

- __EFMigrationsHistory

You are now fully set up to use EF Core migrations in your project!

---
