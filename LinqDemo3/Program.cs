namespace LinqDemo3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Linq To Objects
            string[] words = { "one", "two", "three", "four", "five", "six" };
            // get all short words
            var shortWords = from w in words
                             where w.Length <= 3
                             select w;
            foreach (var word in shortWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}
