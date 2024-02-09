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
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=ProductsECatelogDBv1;Integrated Security=true;MultipleActiveResultSets=True");
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
            optionsBuilder.UseLazyLoadingProxies(true);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Customer>().UseTpcMappingStrategy();
            //modelBuilder.Entity<Supplier>().UseTpcMappingStrategy();
            modelBuilder.Entity<Person>().UseTpcMappingStrategy();


        }

        // Configure/Map: Entity Class => Table

        public DbSet<Product> Products { get; set; }
        public DbSet<Catagory> Catagories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Customer> Customer { get; set; }

        public DbSet<Person> People { get; set; }


    }
}
