using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Replace with your working connection string
        optionsBuilder.UseSqlServer(
            @"Server=localhost\SQLEXPRESS;Database=RetailStoreDb;Trusted_Connection=True;Encrypt=False;"
        );
    }
}
