using AIRecommendation.Aggrigator;
using AIRecommender.DataLoader;

namespace AIRecommendation.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AIRecommendationEngine recommender = new AIRecommendationEngine();
            IDataLoader dataLoader = new CSVDataLoader();
            BookDetails bookDetails = dataLoader.Load();

            Preference preference = new Preference { ISBN = "1234", Age = 24, State = "AP" };

            List<Book> recommendedBooks = recommender.Recommend(bookDetails, preference, 10);

            //TODO: display all the recommended books

        }


    }
}
