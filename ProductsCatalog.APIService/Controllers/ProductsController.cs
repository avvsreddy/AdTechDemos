using Microsoft.AspNet.OData;
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
        [EnableQuery]
        public IQueryable<Product> ListAllProducts()
        {
            // get the products from model
            var products = db.Products.AsQueryable();
            // return a products
            return products;
        }
        // End Points
        // GET .../api/products/112
        //[HttpGet]
        //[Route("{id}")]
        //public IActionResult GetProductById(int id)
        //{
        //    // get single product with its id = 1
        //    var product = db.Products.Find(id);
        //    if (product == null)
        //    {
        //        // return 404 http status code
        //        return NotFound();

        //    }
        //    return Ok(product); // return 200 status code with data
        //}

        //// GET .../api/products/catagory/mobiles
        //[HttpGet]
        //[Route("catagory/{cat}")]
        //public IActionResult GetProductByCatagory(string cat)
        //{
        //    var products = (from p in db.Products
        //                    where p.Catagory.Contains(cat)
        //                    select p).ToList();
        //    if (products.Count == 0)
        //    {
        //        return NotFound($"No products belongs to catagory {cat}");
        //    }
        //    return Ok(products);

        //}

        //// design an endpoints for the below request
        //// 1. get all products based on name
        //// GET.../api/products/name/{name}
        //[HttpGet]
        //[Route("name/{name}")]
        //public List<Product> GetProductsByName(string name)
        //{
        //    var products = from p in db.Products
        //                   where p.Name.Contains(name)
        //                   select p;
        //    return products.ToList();
        //}



        //// 2. get all products based on brand
        //// GET.../api/products/brand/{brand}
        //[HttpGet]
        //[Route("brand/{brand}")]
        //public List<Product> GetProductsByBrand(string brand)
        //{
        //    var products = from p in db.Products
        //                   where p.Brand.Contains(brand)
        //                   select p;
        //    return products.ToList();
        //}
        //// 3. get all products based on country

        //// GET.../api/products/country/{country}
        //[HttpGet]
        //[Route("country/{country:alpha}")]
        //public List<Product> GetProductsByCountry(string country)
        //{
        //    var products = from p in db.Products
        //                   where p.Country.Contains(country)
        //                   select p;
        //    return products.ToList();
        //}
        //// 4. get all products price between min value and max value // 100 200
        //// GET .../api/products/price/min/{min}/max/{max}
        //[HttpGet]
        //[Route("price/min/{min:int}/max/{max:int}")]
        //// GET ...api/products/price/min/1000/max/2000
        //public List<Product> GetProductsByPriceRange(int min, int max)
        //{
        //    var products = from p in db.Products
        //                   where p.Price >= min && p.Price <= max
        //                   select p;
        //    return products.ToList();
        //}
        //// 5. get 3 cheapest products
        //// .../api/products/cheapest
        //[HttpGet]
        //[Route("cheapest")]
        //public List<Product> GetCheapestProducts()
        //{
        //    var products = (from p in db.Products
        //                    orderby p.Price ascending
        //                    select p).Take(3);

        //    return products.ToList();
        //}
        //// 6. get 3 costliest products

        //// .../api/products/costliest
        //[HttpGet]
        //[Route("costliest")]
        //public List<Product> GetCostliestProducts()
        //{
        //    var products = (from p in db.Products
        //                    orderby p.Price descending
        //                    select p).Take(3);

        //    return products.ToList();
        //}

        // POST .../api/products
        [HttpPost]
        public IActionResult PostProducts(Product p)
        {
            // validate the input
            if (!ModelState.IsValid)
            {
                // return invalid status code
                return BadRequest("Invalid input");
            }
            // save data into db
            db.Products.Add(p);
            db.SaveChanges();
            // return the status code
            // 201 location data stored
            return Created($"api/products/{p.ProductID}", p);
        }

        // DELETE ...api/products/123
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteProductById(int id)
        {
            var productToDel = db.Products.Find(id);
            if (productToDel == null)
            {
                return NotFound($"The product {id} is not found");
            }
            db.Products.Remove(productToDel);
            db.SaveChanges();
            return Ok(); // 200
        }

        // PUT ...api/products
        [HttpPut]
        public IActionResult EditProduct(Product product)
        {
            var productToEdit = db.Products.Find(product.ProductID);
            if (productToEdit == null)
            {
                return NotFound($"The product {product.ProductID} is not found");
            }
            //db.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            productToEdit.Brand = product.Brand;
            productToEdit.Price = product.Price;
            productToEdit.Catagory = product.Catagory;
            productToEdit.Name = product.Name;
            productToEdit.Country = product.Country;

            db.SaveChanges();
            return Ok(); // 200
        }
    }
}
