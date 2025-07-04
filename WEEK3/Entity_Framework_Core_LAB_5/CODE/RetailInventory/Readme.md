# 🧪 Lab 5: Retrieving Data from the Database

## 🛍️ Scenario
The retail store wants to **display product details** on the dashboard. You will use EF Core to retrieve data from the SQL Server database.

---

## 🎯 Objective
Use the following EF Core methods to retrieve data:
- `ToListAsync()` — for retrieving all products.
- `FindAsync()` — for finding a product by ID.
- `FirstOrDefaultAsync()` — for conditional lookup.

---

## 🧑‍💻 Steps

### 1️⃣ Add Code to `Program.cs`

Replace the contents of `Program.cs` with the following code:

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

        Console.WriteLine("📦 All Products:");
        var products = await context.Products.ToListAsync();
        foreach (var p in products)
        {
            Console.WriteLine($"{p.Name} - ₹{p.Price}");
        }

        Console.WriteLine("\n🔍 Find by ID (ProductId = 1):");
        var product = await context.Products.FindAsync(1);
        Console.WriteLine($"Found: {product?.Name}");

        Console.WriteLine("\n💸 First Product with Price > ₹50,000:");
        var expensive = await context.Products.FirstOrDefaultAsync(p => p.Price > 50000);
        Console.WriteLine($"Expensive: {expensive?.Name}");
    }
}

```
### 2️⃣ Run the Application
```bash
dotnet run
```
### ✅ Expected Output (Sample)
```mathematica
📦 All Products:
Notebook - ₹20.5
Laptop - ₹75000
Rice Bag - ₹1200

🔍 Find by ID (ProductId = 1):
Found: Notebook

💸 First Product with Price > ₹50,000:
Expensive: Laptop
```
### 🧾 (Optional SQLCMD Verification)
To verify the results manually in SQL Server:

```bash
sqlcmd -S localhost\SQLEXPRESS -E
```
```sql
USE RetailStoreDb;
GO

SELECT * FROM Products;
GO
```