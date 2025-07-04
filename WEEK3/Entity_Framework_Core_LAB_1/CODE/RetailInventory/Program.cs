// See https://aka.ms/new-console-template for more information
// Program.cs
using System;
using System.Linq;

namespace RetailInventory
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new RetailDbContext())
            {
                // Ensures database and tables are created
                context.Database.EnsureCreated();

                // Add sample category and product if DB is empty
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
                    foreach (var cat in context.Categories)
                    {
                        Console.WriteLine($"- {cat.Name}");
                    }
                }
            }
        }
    }
}
