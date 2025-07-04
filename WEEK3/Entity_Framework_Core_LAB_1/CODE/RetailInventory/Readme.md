# Lab 1: Understanding ORM with a Retail Inventory System (EF Core 8.0)

## 🧠 Objective
Build a simple inventory management system using **.NET + EF Core 8.0** with **SQL Server**.  
Understand what an ORM is and how **Entity Framework Core** maps C# classes to SQL Server tables.

---

## 📘 What is ORM?

**ORM (Object-Relational Mapping)** is a technique that maps C# classes to relational database tables.

### ✨ Benefits:
- Eliminates most SQL boilerplate code
- Improves productivity and maintainability
- Provides abstraction over raw SQL
- Enables LINQ queries and async support

---

## 🔄 EF Core vs EF Framework

| Feature            | EF Core                       | EF Framework (EF6)           |
|--------------------|-------------------------------|-------------------------------|
| Cross-platform     | ✅ Yes                         | ❌ Windows only               |
| Lightweight        | ✅ Yes                         | ❌ Heavier                    |
| Modern features    | ✅ LINQ, async, compiled models | ❌ Limited                    |
| Maturity           | 🔶 Newer, improving            | ✅ Mature and stable          |

---

## 🚀 EF Core 8.0 Highlights

- 📦 JSON column mapping
- ⚡ Compiled models for better performance
- 🔍 Interceptors and better bulk operations

---

## 🛠️ Setup Instructions

### ✅ Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/en-us/download)
- [SQL Server Express / LocalDB](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- Visual Studio Code / Terminal
- `sqlcmd` (optional, for verifying DB)

---

## 🧱 Step-by-Step Guide

### 1. Create a Console App
```bash
dotnet new console -n RetailInventory
cd RetailInventory

```

### 2. Install EF Core Packages
```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer

dotnet add package Microsoft.EntityFrameworkCore.Design
```
### 3. Create `models.cs`
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
    public int Stock { get; set; }
    public int CategoryId { get; set; }

    public Category Category { get; set; } = null!;
}
```
### 4. Create `RetailDbContext.cs`
```csharp
using Microsoft.EntityFrameworkCore;

public class RetailDbContext : DbContext
{
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Product> Products => Set<Product>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Server=localhost\SQLEXPRESS;Database=RetailDb;Trusted_Connection=True;Encrypt=False;"
        );
    }
}
```
#### 🔐 Make sure `Encrypt=False` is set to avoid SSL trust errors.

### 5. Update `Program.cs`
```csharp
class Program
{
    static void Main(string[] args)
    {
        using var context = new RetailDbContext();
        context.Database.EnsureCreated();

        if (!context.Categories.Any())
        {
            var category = new Category { Name = "Electronics" };
            var product = new Product { Name = "Laptop", Stock = 10, Category = category };

            context.Categories.Add(category);
            context.Products.Add(product);
            context.SaveChanges();

            Console.WriteLine("Sample data inserted.");
        }
        else
        {
            Console.WriteLine("Categories in DB:");
            foreach (var c in context.Categories)
            {
                Console.WriteLine($"- {c.Name}");
            }
        }
    }
}
```

### 6. Run the App
```bash
dotnet run
```
### ✅ Output on first run:

```kotlin
Sample data inserted.
```
✅ Output on next runs:

```diff
Categories in DB:
- Electronics
```

### 7. Verify in SQL Server (Optional) 
#### If you have `sqlcmd`, run:

```bash
sqlcmd -S localhost\SQLEXPRESS
```
#### Then enter:

```sql
USE RetailDb
GO

SELECT * FROM Categories
GO

SELECT * FROM Products
GO
```
---