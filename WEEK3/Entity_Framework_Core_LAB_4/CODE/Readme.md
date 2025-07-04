# Lab 4: Inserting Initial Data into the Database

## 🛍️ Scenario
The store manager wants to add initial product categories and products to the system using EF Core.

## 🎯 Objective
Use EF Core to insert or update product and category records using `AddAsync`, `Update`, and `SaveChangesAsync`.

---

## ✅ Prerequisites

- Lab 3 completed with models and `AppDbContext` in place.
- SQL Server is installed and running (e.g., `SQLEXPRESS`).
- The database `RetailStoreDb` has been created.

---

## 🧑‍💻 Step-by-Step Instructions

### 1️⃣ Open or Create `Program.cs`

Replace your `Program.cs` with the following code to insert or update data:

```csharp
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RetailInventory;

class Program
{
    static async Task Main(string[] args)
    {
        using var context = new AppDbContext();

        await context.Database.EnsureCreatedAsync();

        // Handle Categories
        var electronics = await context.Categories.FirstOrDefaultAsync(c => c.Name == "Electronics");
        if (electronics == null)
        {
            electronics = new Category { Name = "Electronics" };
            await context.Categories.AddAsync(electronics);
        }

        var groceries = await context.Categories.FirstOrDefaultAsync(c => c.Name == "Groceries");
        if (groceries == null)
        {
            groceries = new Category { Name = "Groceries" };
            await context.Categories.AddAsync(groceries);
        }

        await context.SaveChangesAsync(); // Save categories first

        // Handle Products
        var laptop = await context.Products.FirstOrDefaultAsync(p => p.Name == "Laptop");
        if (laptop != null)
        {
            laptop.Price = 75000;
            laptop.Category = electronics;
            context.Products.Update(laptop);
        }
        else
        {
            await context.Products.AddAsync(new Product
            {
                Name = "Laptop",
                Price = 75000,
                Category = electronics
            });
        }

        var riceBag = await context.Products.FirstOrDefaultAsync(p => p.Name == "Rice Bag");
        if (riceBag != null)
        {
            riceBag.Price = 1200;
            riceBag.Category = groceries;
            context.Products.Update(riceBag);
        }
        else
        {
            await context.Products.AddAsync(new Product
            {
                Name = "Rice Bag",
                Price = 1200,
                Category = groceries
            });
        }

        await context.SaveChangesAsync();

        Console.WriteLine("✅ Products and categories added or updated successfully.");
    }
}
```

### 2️⃣ Run the Application
```bash
dotnet run
```
#### You should see:

```bash
✅ Products and categories added or updated successfully.
```

### 3️⃣ Verify Data in SQL Server

Use sqlcmd to check inserted data:

```bash
sqlcmd -S localhost\SQLEXPRESS -E
```

#### Then run:

```sql
USE RetailStoreDb;
GO

SELECT * FROM Categories;
GO

SELECT * FROM Products;
GO
```
#### ✅ You should see categories like Electronics, Groceries, and products like Laptop, Rice Bag.

### 📝 Notes
- This code checks if a product or category with the same name exists and updates it instead of inserting again.

- This helps prevent duplicate entries when re-running the app.

- You can use similar logic to insert more data.

### 📂 Output Example
### 📋 Categories

| Id | Name        |
|----|-------------|
| 1  | Stationery  |
| 2  | Electronics |
| 3  | Groceries   |

---

### 📋 Products

| Id | Name      | Price   | CategoryId |
|----|-----------|---------|------------|
| 1  | Notebook  | 20.50   | 1          |
| 2  | Laptop    | 75000.0 | 2          |
| 3  | Rice Bag  | 1200.0  | 3          |

---

