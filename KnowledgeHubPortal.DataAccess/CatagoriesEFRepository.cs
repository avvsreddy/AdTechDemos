using KnowledgeHubPortal.Domain;
using KnowledgeHubPortal.Domain.Entities;

namespace KnowledgeHubPortal.DataAccess
{
    public class CatagoriesEFRepository : ICatagoriesRepository
    {
        private KHPDbContext db = null; //new KHPDbContext();

        public CatagoriesEFRepository(KHPDbContext db)
        {
            this.db = db;
        }
        public void Create(Catagory catagory)
        {
            db.Catagories.Add(catagory);
            db.SaveChanges();
        }

        public List<Catagory> ListAll()
        {
            return db.Catagories.ToList();
        }
    }
}
