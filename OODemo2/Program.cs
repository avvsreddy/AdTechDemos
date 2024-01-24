namespace OODemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Local Variables Type inference

            var a = 10;
            var str = "Hello";

            var xyz = 10;

            // store data into product
            Product p = new Product();
            p.Id = 1;
            p.Name = "IPhone 15";
            p.Price = 100000;

            // Object Initialization Syntax


            // Store emplyee data and display
            // Anonymous Types

            var e1 = new { EmpId = 111, Name = "Ravi", Salary = 70000 };

            Console.WriteLine(e1.Name);
            e1.Salary = 10;
            e1.Brand = "sdfsdf";
            //Product p3 = new Product(3);
            Product p3 = new Product { Id = 3 };

            var p4 = new Product { Id = 4, Name = "OnePlus 10" };

            Product p5 = new Product { Id = 2, Name = "Galaxy S24", Price = 140000, Brand = "Samsung" };

            Product p2 = new Product { Id = 2, Name = "Galaxy S24", Price = 140000 };

            Product p6 = new Product { Id = 6, Price = 150000 };
        }
    }

    //public class Employee
    //{
    //    public int EmpId { get; set; }
    //    public string Name { get; set; }
    //    public int Salary { get; set; }
    //}

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Brand { get; set; }
        //public Product()
        //{

        //}

        //public Product(int id, string name, int price, string brand) : this(id, name, price)
        //{
        //    //Id = id;
        //    //Name = name;
        //    //Price = price;
        //    Brand = brand;
        //}
        //public Product(int id, string name, int price) : this(id, name)
        //{
        //    //Id = id;
        //    //Name = name;
        //    Price = price;
        //}

        //public Product(int id)
        //{
        //    Id = id;
        //}

        //public Product(int id, string name) : this(id)
        //{
        //    //Id = id;
        //    Name = name;
        //}
    }
}
