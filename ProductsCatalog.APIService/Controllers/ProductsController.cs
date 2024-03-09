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

        // GET  .../api/products
        [HttpGet]
        public List<Product> ListAllProducts()
        {
            // get the products from model
            List<Product> products = db.Products.ToList();
            // return a products
            return products;
        }
        // End Points
        // GET .../api/products/112
        [HttpGet]
        [Route("{id}")]
        public Product GetProductById(int id)
        {
            // get single product with its id = 1
            var product = db.Products.Find(id);
            return product;
        }

        // GET .../api/products/catagory/mobiles
        [HttpGet]
        [Route("catagory/{cat}")]
        public List<Product> GetProductByCatagory(string cat)
        {
            var products = from p in db.Products
                           where p.Catagory.Contains(cat)
                           select p;
            return products.ToList();

        }

        // design an endpoints for the below request
        // 1. get all products based on name
        // 2. get all products based on brand
        // 3. get all products based on country
        // 4. get all products price between min value and max value // 100 200
        // 5. get 3 cheapest products
        // 6. get 3 constliest products


    }
}
