using System.Net.Http.Json;

namespace ApiClientConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // get all products from web api
            // step 1: discover the api end point
            // https://localhost:44335/api/Products
            // step 2: verify the endpoint
            // Step 3: write client code to call the endpoint

            HttpClient client = new HttpClient();

            var products = client.GetFromJsonAsync<List<Product>>("https://localhost:44335/api/Products").Result;

            foreach (var product in products)
            {
                Console.WriteLine(product.name);
            }

        }
    }

    class Product
    {

        public int productID { get; set; }
        public string name { get; set; }
        public string brand { get; set; }
        public int price { get; set; }
        public string country { get; set; }
        public string catagory { get; set; }

    }
}
