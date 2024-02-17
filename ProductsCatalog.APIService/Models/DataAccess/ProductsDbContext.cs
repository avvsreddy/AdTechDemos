using Microsoft.EntityFrameworkCore;
using ProductsCatalog.APIService.Models.Entities;

namespace ProductsCatalog.APIService.Models.DataAccess
{
    public class ProductsDbContext : DbContext
    {
        // confiture the db


        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options)
        {

        }

        // map tables and entities

        public DbSet<Product> Products { get; set; }
    }
}
