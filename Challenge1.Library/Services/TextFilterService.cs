using Challenge1.Library.Helpers;
using Challenge1.Library.Interfaces;

namespace Challenge1.Library.Services;

public class TextFilterService
{
    public string ReadFromFile(string filePath)
    {
        using var reader = new StreamReader(filePath);
        return reader.ReadToEnd();
    }

    public List<string> ApplyFilter1(List<string> words)
    {
        return words.Where(word =>
                TextHelper.IsSingleCharacterPunctuation(word) || TextHelper.MiddleOfTheWordDoesNotContainsVowel(word))
            .ToList();
    }

    public List<string> ApplyFilter2(List<string> words)
    {
        return words.Where(word => TextHelper.IsSingleCharacterPunctuation(word) || word.Length >= 3).ToList();
    }

    public List<string> ApplyFilter3(List<string> words)
    {
        return words.Where(word => !word.Contains("t", StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public string ProcessTextBruteForce(string inputText)
    {
        var words = TextHelper.NormaliseText(inputText);

        var filter1 = ApplyFilter1(words);
        var filter2 = ApplyFilter2(filter1);
        var filter3 = ApplyFilter3(filter2);

        var output = string.Join(" ", filter3);

        return output;
    }

    public string ProcessTextElegant(string inputText, List<IFilter> filterList)
    {
        var words = TextHelper.NormaliseText(inputText);
        foreach (var filter in filterList)
            words = words.Where(filter.ApplyFilter).ToList();
        var output = string.Join(" ", words);
        return output;
    }
}