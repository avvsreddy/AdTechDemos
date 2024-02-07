using System.Xml.Linq;

namespace LinqtoXml2
{

    //class BookTitleAuthor
    //{
    //    public string Title { get; set; }
    //    public string Author { get; set; }
    //}

    //class BookTitleAuthorPrice
    //{
    //    public string Title { get; set; }
    //    public string Author { get; set; }
    //    public double Price { get; set; }
    //}

    internal class Program
    {
        static void Main(string[] args)
        {
            // Linq to XML
            // Get all book titles and author from xml document
            XDocument xml = XDocument.Load("XMLFile1.xml");

            //var titles = from title in xml.Descendants("title")
            //             select title.Value;

            // sql: select title,author from books;

            var books = from book in xml.Descendants("book")
                        where double.Parse(book.Element("price").Value) > 5.0
                        select new
                        {
                            Title = book.Element("title").Value,
                            Author = book.Element("author").Value,
                            Price = double.Parse(book.Element("price").Value),
                            Date = book.Element("publish_date").Value
                        };

            foreach (var bk in books)
            {
                Console.WriteLine(bk.Title + " " + bk.Author + " " + bk.Price + " " + bk.Date);
            }


        }
    }
}
