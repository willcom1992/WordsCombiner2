namespace WordsCombiner.Shared.Utility
{
    public interface IRandomNumbers
    {
        IEnumerable<int> GetUniqRandomNumbers(int rangeBegin, int rangeEnd, int count);
    }
}
