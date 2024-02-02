namespace AIRecommendation.CoreEngine
{
    public interface IRecommender
    {
        double GetCorellation(List<int> baseArray, List<int> otherArray);
    }
}
