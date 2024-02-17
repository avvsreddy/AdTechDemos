using KnowledgeHubPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeHubPortal.DataAccess
{
    public class KHPDbContext : DbContext
    {
        // configure the db

        // IoC
        public KHPDbContext(DbContextOptions<KHPDbContext> options)
            : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=KHPDB2024;Integrated Security=true");
            }
        }

        // configure the tables
        public DbSet<Catagory> Catagories { get; set; }
        public DbSet<Article> Articles { get; set; }

    }
}
