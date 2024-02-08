using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProductECatelog.Entities;

namespace ProductECatelog.DataAccess
{
    public class ProductECatelogDataContext : DbContext
    {
        // Configure/Map Database
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=ProductsECatelogDB;Integrated Security=true");
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        }

        // Configure/Map: Entity Class => Table

        public DbSet<Product> Products { get; set; }

    }
}
