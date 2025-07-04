// RetailDbContext.cs
using Microsoft.EntityFrameworkCore;

namespace RetailInventory
{
    public class RetailDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=RetailDb;Trusted_Connection=True;Encrypt=False;");


        }
    }
}
