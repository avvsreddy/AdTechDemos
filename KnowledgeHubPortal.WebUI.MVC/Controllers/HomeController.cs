using KnowledgeHubPortal.WebUI.MVC.Data;
using KnowledgeHubPortal.WebUI.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KnowledgeHubPortal.WebUI.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext dx;

        public HomeController(ApplicationDbContext dx)
        {
            this.dx = dx;
        }

        // http://domainname.com/home/index
        public IActionResult Index()
        {
            return View();

        }

        public IActionResult Users()
        {
            return View(dx.Users.ToList());
        }


        // .../home/privacy
        //[Route("abc/KHP/privacy")]
        //[OnError()]

        public IActionResult Privacy()
        {
            //gsdgdfgsdfg
            //dgdgdfg
            //dgfgdfg
            throw new Exception("server error");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult Contactus()
        {
            return View();
        }


    }
}
