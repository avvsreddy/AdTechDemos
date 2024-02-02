using AIRecommender.DataLoader;

namespace AIRecommendation.Aggrigator
{
    public interface IRatingsAggrigator
    {
        Dictionary<string, List<int>> Aggrigate(BookDetails bookDetails, Preference preference);
    }
}
