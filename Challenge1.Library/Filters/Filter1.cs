using Challenge1.Library.Helpers;
using Challenge1.Library.Interfaces;

namespace Challenge1.Library.Filters;

public class Filter1 : IFilter
{
    public bool ApplyFilter(string word)
    {
        return TextHelper.IsSingleCharacterPunctuation(word) || TextHelper.MiddleOfTheWordDoesNotContainsVowel(word);
    }
}