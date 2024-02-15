using KnowledgeHubPortal.Domain;
using KnowledgeHubPortal.Domain.Entities;

namespace KnowledgeHubPortal.DataAccess
{
    public class CatagoriesEFRepository : ICatagoriesRepository
    {
        private KHPDbContext db = new KHPDbContext();
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
