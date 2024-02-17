using Microsoft.AspNetCore.Mvc;
using ProductsCatalog.APIService.Models.DataAccess;
using ProductsCatalog.APIService.Models.Entities;

namespace ProductsCatalog.APIService.Controllers
{

    // http://abc.com/api/products
    // should allways no verbs
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsDbContext db;

        public ProductsController(ProductsDbContext db)
        {
            this.db = db;
        }

        // GET  http://abc.com/api/products
        [HttpGet]
        public List<Product> ListAllProducts()
        {
            // get the products from model
            List<Product> products = db.Products.ToList();
            // return a products
            return products;
        }


    }
}
