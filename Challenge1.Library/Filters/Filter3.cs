using Challenge1.Library.Interfaces;

namespace Challenge1.Library.Filters;

public class Filter3 : IFilter
{
    public bool ApplyFilter(string word)
    {
        return !word.Contains("t", StringComparison.OrdinalIgnoreCase);
    }
}