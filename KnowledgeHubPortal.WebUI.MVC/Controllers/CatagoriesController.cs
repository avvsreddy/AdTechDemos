using KnowledgeHubPortal.DataAccess;
using KnowledgeHubPortal.Domain;
using KnowledgeHubPortal.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeHubPortal.WebUI.MVC.Controllers
{
    public class CatagoriesController : Controller
    {
        // .../catagories/list
        private ICatagoriesRepository repo = new CatagoriesEFRepository();// DIP
        public IActionResult List()
        {
            // get all catagories from model
            var catagories = repo.ListAll();
            // send the catagories to view 
            return View(catagories);
        }

        public IActionResult Create()
        {
            // return an empty view for collecting catagory data
            return View();
        }

        public IActionResult Save(Catagory catagory)
        {
            // get catagory info from view
            // Server Side validate - done by model binder of MVC
            if (!ModelState.IsValid)
            {
                return View("Create");
            }
            // send data to model (DAL)
            //Catagory c = new Catagory { Name = name, Description = description };
            repo.Create(catagory);
            //return View("List",repo.ListAll());
            TempData["Message"] = $"Catagory {catagory.Name} created successfully";
            return RedirectToAction("List");
        }

    }
}
