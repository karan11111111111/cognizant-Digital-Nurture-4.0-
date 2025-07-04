# Lab 2: Setting Up the Database Context for a Retail Store (EF Core 8.0)

## 🧠 Objective
Configure Entity Framework Core to connect a .NET console application to a SQL Server database and define `Product` and `Category` models.

---

## 📦 Requirements

- .NET SDK (7.0 or later)
- SQL Server (Express or Developer Edition recommended)
- EF Core packages
- Visual Studio Code or any terminal

---

## 📁 Project Setup

### 1️⃣ Create a New Console App

```bash
dotnet new console -n RetailInventory
cd RetailInventory
```

### 2️⃣ Install Required EF Core Packages
```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
```

## 🧱 Step-by-Step Implementation
### 3️⃣ Define the Models
#### Create a file `Models.cs`:

```csharp
public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public List<Product> Products { get; set; } = new();
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int CategoryId { get; set; }

    public Category Category { get; set; } = null!;
}
```

#### 💡 Replace `localhost\SQLEXPRESS` with your server name if different.

### 5️⃣ Create the Main Program
#### Update `Program.cs`:

```csharp
class Program
{
    static void Main(string[] args)
    {
        using var context = new AppDbContext();

        // Ensure database is created
        context.Database.EnsureCreated();

        Console.WriteLine("Database created successfully.");
    }
}
```

### ▶️ Run the Application
```bash
dotnet run
```
#### You should see:

```nginx
Database created successfully.
```
##### And a new database called RetailStoreDb will be created in your SQL Server instance.

---

### 6️⃣ Verifying the Database with sqlcmd (Optional)
If sqlcmd is installed, follow these steps to verify your database and tables:

#### 1. Open Terminal and Connect
```bash
sqlcmd -S localhost\SQLEXPRESS -E
```
#### Use localhost instead of `localhost\SQLEXPRESS` if you’re using the default SQL Server instance.

#### 2. List All Databases
``` sql
SELECT name FROM sys.databases;
GO
```
##### Look for RetailStoreDb in the list.


#### 3. Use the Database
```sql
USE RetailStoreDb;
GO
```
#### 4. List All Tables
```sql
SELECT * FROM sys.tables;
GO
```
##### You should see:

```nginx
Products
Categories
```
#### 5. Check Table Contents (if any)
```sql
SELECT * FROM Products;
GO

SELECT * FROM Categories;
GO
```
---
