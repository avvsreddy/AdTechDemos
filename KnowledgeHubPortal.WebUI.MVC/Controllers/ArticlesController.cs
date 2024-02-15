using KnowledgeHubPortal.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KnowledgeHubPortal.WebUI.MVC.Controllers
{
    public class ArticlesController : Controller
    {

        private KnowledgeHubPortal.DataAccess.ArticlesEFRepository articleRepo = new DataAccess.ArticlesEFRepository();
        private KnowledgeHubPortal.DataAccess.CatagoriesEFRepository catRepo = new DataAccess.CatagoriesEFRepository();
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            // return empty view for collecting article info
            // get catagory from model and send it to view
            var catagories = catRepo.ListAll();
            var catSelectListItems = from c in catagories
                                     select new SelectListItem { Text = c.Name, Value = c.CatagoryID.ToString() };


            ViewBag.CatagoryId = catSelectListItems;
            return View();
        }
        [HttpPost]
        [Authorize]
        public IActionResult Create(Article article)
        {
            // receive article data for saving
            // validate
            if (!ModelState.IsValid)
            {
                return View();
            }

            // fill the remaining properties
            article.IsApproved = false;
            article.DatePosted = DateTime.Now;

            if (User != null || User.Identity.IsAuthenticated)
                article.PostedBy = User.Identity.Name;
            else
                article.PostedBy = "Anonymous";

            articleRepo.Submit(article);

            ViewData["Message"] = $"Article {article.Title} has been submitted successfully for admin review";
            return RedirectToAction("Create");
        }

        [Authorize(Roles = "admin")]
        public IActionResult Review()
        {
            // return articles for review along with catagories
            var articlesForReview = articleRepo.GetAllForReview();

            return View(articlesForReview);

        }
        [Authorize(Roles = "admin")]
        public IActionResult Approve(int[] ids)
        {
            articleRepo.Approve(ids);
            TempData["Message"] = $"{ids.Length} Articles Approved";
            return RedirectToAction("Review");
        }
        [Authorize(Roles = "admin")]
        public IActionResult Reject(int[] ids)
        {
            articleRepo.Reject(ids);
            TempData["Message"] = $"{ids.Length} Articles Rejected";
            return RedirectToAction("Review");
        }

        public IActionResult Browse(int catagoryId = 0, string searchText = "")
        {
            List<Article> browseArticles;
            // get all the approved articles from model/backend if catagoryid=0

            browseArticles = articleRepo.GetAllForBrowse(catagoryId);
            if (searchText != "")
            {
                browseArticles = articleRepo.GetAllForBrowse(searchText);
            }
            var catagories = from c in catRepo.ListAll()
                             select new SelectListItem { Text = c.Name, Value = c.CatagoryID.ToString() };
            ViewBag.Catagories = catagories;
            return View(browseArticles);
        }

    }
}
