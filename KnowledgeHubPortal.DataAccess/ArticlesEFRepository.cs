using KnowledgeHubPortal.Domain;
using KnowledgeHubPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeHubPortal.DataAccess
{

    public class ArticlesEFRepository : IArticlesRepository
    {
        private KHPDbContext db = new KHPDbContext();
        public void Approve(int[] articleIds)
        {
            // approve articles
            // writing just functionality - if required rewrite this logic for performance
            var reviewArticles = GetAllForReview();
            foreach (var a in reviewArticles)
            {
                foreach (var aa in articleIds)
                {
                    if (a.ArticleID == aa)
                        a.IsApproved = true;
                }
            }
            db.SaveChanges();
        }

        public List<Article> GetAllForBrowse(int cid = 0)
        {
            // return approved articles only

            List<Article> approvedArticles = new List<Article>();
            if (cid == 0)
            {
                approvedArticles = (from a in db.Articles.Include(a => a.Catagory)
                                    where a.IsApproved == true
                                    select a).ToList();
            }
            else
            {
                approvedArticles = (from a in db.Articles.Include(a => a.Catagory)
                                    where a.IsApproved == true && a.CatagoryID == cid
                                    select a).ToList();
            }
            return approvedArticles;
        }

        public List<Article> GetAllForBrowse(string searchStr)
        {
            var approvedArticles = from a in db.Articles.Include(a => a.Catagory)
                                   where a.IsApproved == true &&
                                   a.Title.Contains(searchStr) ||
                                   a.Description.Contains(searchStr) ||
                                   a.Catagory.Name.Contains(searchStr)
                                   select a;


            return approvedArticles.ToList();
        }

        public List<Article> GetAllForReview(int cid = 0)
        {
            // return newly added/non approved articles only
            var reviewArticles = from a in db.Articles.Include(a => a.Catagory)
                                 where a.IsApproved == false
                                 select a;
            return reviewArticles.ToList();
        }

        public void Reject(int[] articleIds)
        {
            // delete rejected articles
            // writing just functionality - if required rewrite this logic for performance
            var reviewArticles = GetAllForReview();
            foreach (var a in reviewArticles)
            {
                foreach (var ad in articleIds)
                {
                    if (a.ArticleID == ad)
                        db.Articles.Remove(a);
                }
            }
            db.SaveChanges();


        }

        public void Submit(Article article)
        {
            db.Articles.Add(article);
            db.SaveChanges();
        }
    }
}
