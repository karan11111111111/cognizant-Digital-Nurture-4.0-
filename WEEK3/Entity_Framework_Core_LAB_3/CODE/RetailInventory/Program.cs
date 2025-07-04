// See https://aka.ms/new-console-template for more information
class Program
{
    static void Main(string[] args)
    {
        using var context = new AppDbContext();

        Console.WriteLine("Database created successfully.");

        if (!context.Categories.Any())
        {
            var cat = new Category { Name = "Stationery" };
            var prod = new Product { Name = "Notebook", Price = 20.5M, Category = cat };

            context.Categories.Add(cat);
            context.Products.Add(prod);
            context.SaveChanges();

            Console.WriteLine("Sample data added.");
        }

    }
}
