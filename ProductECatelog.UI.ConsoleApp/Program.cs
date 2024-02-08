using ProductECatelog.DataAccess;
using ProductECatelog.Entities;

namespace ProductECatelog.UI.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }

        private static void Edit()
        {
            ProductECatelogDataContext db = new ProductECatelogDataContext();

            // edit a product price
            // Step 1: get the product to edit
            var productToEdit = db.Products.Find(2);
            // step 2: change the property values except pk
            productToEdit.Price = 150000;
            // Step 3: update database
            db.SaveChanges();
        }

        private static void Delete()
        {
            // delete some product
            // Step 1: get the product to delete from dbset
            ProductECatelogDataContext db = new ProductECatelogDataContext();
            var productToDel = from p in db.Products
                               where p.ProductID == 1
                               select p;
            // Step 2: remove that product from dbset
            db.Products.Remove(productToDel.FirstOrDefault());
            // Step 3: save the changes of dbset into database
            db.SaveChanges();
        }

        private static void GetAll()
        {
            // Get all Products and display
            ProductECatelogDataContext db = new ProductECatelogDataContext();
            // LINQ to Entites
            var allProducts = from p in db.Products
                              where p.Price <= 100000
                              select p;
            foreach (var p in allProducts)
            {
                Console.WriteLine(p.Name);
            }
        }

        private static void Insert()
        {
            // save product info
            Product p = new Product { Name = "IPhone 15", Price = 100000 };
            ProductECatelogDataContext db = new ProductECatelogDataContext();
            db.Products.Add(p);
            db.SaveChanges();
            Console.WriteLine("Product Saved...");
        }
    }
}
