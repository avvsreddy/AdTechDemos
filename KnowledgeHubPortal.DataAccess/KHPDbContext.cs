using KnowledgeHubPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeHubPortal.DataAccess
{
    internal class KHPDbContext : DbContext
    {
        // configure the db
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=KHPDB2024;Integrated Security=true");
        }

        // configure the tables
        public DbSet<Catagory> Catagories { get; set; }
        public DbSet<Article> Articles { get; set; }

    }
}
