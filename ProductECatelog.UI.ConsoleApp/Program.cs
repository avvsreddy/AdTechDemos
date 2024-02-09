using ProductECatelog.DataAccess;
using ProductECatelog.Entities;

namespace ProductECatelog.UI.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductECatelogDataContext db = new ProductECatelogDataContext();
            // add new supplier

            var s = new Supplier { Email = "supp1@mail.com", GSTNo = "123-123", Location = "Bangalore", Mobile = "1111111", Name = "supp1", TradeLicenceNo = "111-111" };

            // add new customer
            var c = new Customer { CustomerType = "gold", Discount = 20, Email = "cust1@mail.com", Location = "Hyderabad", Mobile = "34534534", Name = "cust1" };


            //db.Suppliers.Add(s);
            //db.Customer.Add(c);
            //db.SaveChanges();

            var custs = db.Customer.ToList();


        }

        private static void NewProductWithOldCatagory()
        {
            ProductECatelogDataContext db = new ProductECatelogDataContext();
            // Add new Product with existing catagory
            var p = new Product { Name = "Galaxy 24", Brand = "Samsung", Price = 78000 };
            // get catagory from db
            var c = db.Catagories.Find(1);
            p.Catagory = c;

            db.Products.Add(p);
            db.SaveChanges();
        }

        private static void AddNewCatagoryWithNewProduct()
        {
            Catagory c = new Catagory { Name = "Smart Watches" };
            Product p = new Product { Name = "I Watch", Price = 10000, Brand = "Apple", Catagory = c };
            ProductECatelogDataContext db = new ProductECatelogDataContext();
            db.Products.Add(p);
            //db.Catagories.Add(c);
            db.SaveChanges();
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
                                  //where p.Price <= 100000
                              select p;
            foreach (var p in allProducts)
            {
                Console.WriteLine(p.Name);
            }
        }

        private static void Insert()
        {
            // save product info
            Product p = new Product { Name = "IPhone 15 Plus", Price = 140000 };
            ProductECatelogDataContext db = new ProductECatelogDataContext();
            db.Products.Add(p);
            db.SaveChanges();
            Console.WriteLine("Product Saved...");
        }
    }
}
