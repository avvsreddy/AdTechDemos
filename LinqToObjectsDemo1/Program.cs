namespace LinqToObjectsDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!, Welcome to LINQ");

            int[] numbers = { 11, 42, 13, 64, 55, 86, 17, 78, 39 }; // in-memory object
            // extract all even numbers into another array in desc order
            List<int> evens = new List<int>();
            foreach (int i in numbers)
            {
                if (i % 2 == 0)
                {
                    evens.Add(i);
                }
            }
            //foreach (var item in evens)
            //{
            //    Console.WriteLine(item);
            //}

            // table: numbers
            // column: number
            // sql: "selreweect number from numbers where number mod 2 = 0 order by number desc"
            // LINQ

            Console.WriteLine("Linq result");
            // Linq Expressions
            var result = from n in numbers
                         where n % 2 == 0
                         orderby n descending
                         select n;

            // Linq Lambda Statements / Linq Extensions
            var evenNumbers = numbers
                .Where(n => n % 2 == 0)
                .OrderByDescending(n => n)
                .Select(n => n);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
