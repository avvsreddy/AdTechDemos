using System.Xml.Linq;

namespace LinqToXML1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Linq To Objects
            //string[] words = { "one", "two", "three", "four", "five", "six" };
            // get all short words

            // Linq to XML
            // load the xml document
            XDocument xml = XDocument.Load("XMLFile1.xml");

            Console.WriteLine(xml);

            //var shortWords = from w in words
            //                 where w.Length <= 3
            //                 select w;

            // Linq to XML
            var shortWords = from xe in xml.Descendants("word")
                             where xe.Value.Length <= 3
                             select xe.Value;


            foreach (var word in shortWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}
