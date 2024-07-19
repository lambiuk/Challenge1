using Challenge1.Library.Helpers;

namespace Challenge1.Tests.Unit;

public class TextHelperTests
{
    [Fact]
    public void NormaliseText_BadSentence_StringArrayReturned()
    {
        var input =
            "This is a badly written paragraph,with punctuation and quote marks'sometimes'not respecting spaces.";

        var words = TextHelper.NormaliseText(input);

        Assert.Equal(19, words.Count);
        Assert.Equal("This", words[0]);
        Assert.Equal(",", words[6]);
        Assert.Equal("spaces", words[17]);
        Assert.Equal(".", words[18]);
    }

    [Theory]
    [InlineData("clean", false)]
    [InlineData("what", false)]
    [InlineData("currently", false)]
    [InlineData("the", true)]
    [InlineData("Rather", true)]
    [InlineData("tired", true)]
    public void MiddleOfTheWordDoesNotContainsVowel_Word_BoolReturned(string stringInput, bool expectedResult)
    {
        var result = TextHelper.MiddleOfTheWordDoesNotContainsVowel(stringInput);

        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData('T', false)]
    [InlineData('h', false)]
    [InlineData('i', false)]
    [InlineData('s', false)]
    [InlineData('.', true)]
    [InlineData(',', true)]
    [InlineData('!', true)]
    [InlineData('?', true)]
    [InlineData(';', true)]
    [InlineData(':', true)]
    [InlineData('"', true)]
    [InlineData('(', true)]
    [InlineData(')', true)]
    [InlineData('[', true)]
    [InlineData(']', true)]
    [InlineData('-', true)]
    public void IsSingleCharacterPunctuation_Character_BoolReturned(char characterInput, bool expectedResult)
    {
        var result = TextHelper.IsSingleCharacterPunctuation(characterInput);

        Assert.Equal(expectedResult, result);
    }
}