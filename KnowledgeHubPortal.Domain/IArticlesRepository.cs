using KnowledgeHubPortal.Domain.Entities;

namespace KnowledgeHubPortal.Domain
{
    public interface IArticlesRepository
    {
        void Submit(Article article);
        void Approve(int[] articleIds);
        void Reject(int[] articleIds);

        List<Article> GetAllForBrowse(int cid = 0);
        List<Article> GetAllForBrowse(string searchStr);
        List<Article> GetAllForReview(int cid = 0);
    }
}
