using Challenge1.Library.Helpers;
using Challenge1.Library.Interfaces;

namespace Challenge1.Library.Filters;

public class Filter2 : IFilter
{
    public bool ApplyFilter(string word)
    {
        return TextHelper.IsSingleCharacterPunctuation(word) || word.Length >= 3;
    }
}