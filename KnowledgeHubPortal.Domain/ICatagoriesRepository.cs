using KnowledgeHubPortal.Domain.Entities;

namespace KnowledgeHubPortal.Domain
{
    public interface ICatagoriesRepository
    {
        void Create(Catagory catagory);
        List<Catagory> ListAll();
    }
}
