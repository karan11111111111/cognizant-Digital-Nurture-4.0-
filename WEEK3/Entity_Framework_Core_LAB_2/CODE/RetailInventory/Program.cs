// See https://aka.ms/new-console-template for more information
class Program
{
    static void Main(string[] args)
    {
        using var context = new AppDbContext();
        context.Database.EnsureCreated();
        Console.WriteLine("Database created successfully.");
    }
}
