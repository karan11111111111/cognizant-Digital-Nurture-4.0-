// See https://aka.ms/new-console-template for more information
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RetailInventory;

class Program
{
    static async Task Main(string[] args)
    {
        using var context = new AppDbContext();

        // Ensure the database is created (optional if using migrations)
        await context.Database.EnsureCreatedAsync();

        // ===== Handle Categories =====
        var electronics = await context.Categories
            .FirstOrDefaultAsync(c => c.Name == "Electronics");
        if (electronics == null)
        {
            electronics = new Category { Name = "Electronics" };
            await context.Categories.AddAsync(electronics);
        }

        var groceries = await context.Categories
            .FirstOrDefaultAsync(c => c.Name == "Groceries");
        if (groceries == null)
        {
            groceries = new Category { Name = "Groceries" };
            await context.Categories.AddAsync(groceries);
        }

        await context.SaveChangesAsync(); // Save categories first (for foreign keys)

        // ===== Handle Products =====

        var laptop = await context.Products
            .FirstOrDefaultAsync(p => p.Name == "Laptop");

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

        var riceBag = await context.Products
            .FirstOrDefaultAsync(p => p.Name == "Rice Bag");

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
