using System.Text.RegularExpressions;

namespace Challenge1.Library.Helpers;

public static class TextHelper
{
    private const string PunctuationToCheckPattern = @"[.,!?;:'""()\[\]{}\-\/]";

    public static List<string> NormaliseText(string input)
    {
        // Define a regular expression that matches the characters of interest
        // and ensures there's exactly one space before and after each.
        // This pattern matches punctuation and quote marks, respecting existing spaces.
        string pattern = @$"(?<={PunctuationToCheckPattern})(?=\S)|(?<=\S)(?={PunctuationToCheckPattern})";

        // Replace occurrences with the matched character preceded and followed by a space
        string normalizedText = Regex.Replace(input, pattern, " $0 ");

        // Split the normalized text into list of strings representing words and single punctuation characters
        return normalizedText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    public static bool IsSingleCharacterPunctuation(char input)
    {
        return Regex.IsMatch(input.ToString(), PunctuationToCheckPattern);
    }

    public static bool IsSingleCharacterPunctuation(string input)
    {
        if (input.Length > 1) return false;
        return Regex.IsMatch(input, PunctuationToCheckPattern);
    }

    public static bool MiddleOfTheWordDoesNotContainsVowel(string word)
    {
        if (word.Length < 3)
            return true;

        var middleStart = word.Length % 2 == 0 ? (word.Length - 1) / 2 : word.Length / 2;
        var middleLength = word.Length % 2 == 0 ? 2 : 1;

        var middle = word.Substring(middleStart, middleLength);
        return !middle.Any(c => "aeiouAEIOU".Contains(c));
    }
}