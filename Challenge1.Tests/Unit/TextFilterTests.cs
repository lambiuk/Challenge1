using Challenge1.Library.Filters;
using Challenge1.Library.Interfaces;
using Challenge1.Library.Services;

namespace Challenge1.Tests.Unit;

public class TextFilterTests
{
    private readonly string _refText;
    private readonly string _refTextFilePath = "Resources/InputText.txt";
    private readonly TextFilterService _sut = new();

    private readonly string _expectedRefTextOutput =
        "beginning , and : once she reading , , ' and use , ' ' ? ' she considering own ( she , and ) , and picking daisies , . remarkable ; , ' ! ! ! ' ( she , she , all ) ; , and , and hurried , , flashed she never , , and burning , she , and large under hedge . , never once considering world she . , and dipped , herself she herself falling . , she , she she and wonder happen . , she and she , ; she sides , and filled and shelves ; and she and . She one shelves she passed ; ' , : she killing , one she .";

    public TextFilterTests()
    {
        using var reader = new StreamReader(_refTextFilePath);
        _refText = reader.ReadToEnd();
    }

    [Fact]
    public void ReadFromTextFile_ExistingFileName_ReadsText()
    {
        var result = _sut.ReadFromFile(_refTextFilePath);

        Assert.NotNull(result);
        Assert.Contains("`ORANGE MARMALADE'", result);
    }

    [Fact]
    public void ReadFromTextFile_NonExistingFileName_ThrowsException()
    {
        var filePath = "Resources/SomeFileThatDoesNotExist.txt";

        Assert.Throws<FileNotFoundException>(() => _sut.ReadFromFile(filePath));
    }

    [Fact]
    public void ApplyFilter1_SimpleText_WordRemoved()
    {
        List<string> words =
            ["clean", "Clean", "what", "What", "currently", "Currently", "the", "The", "rather", "Rather"];

        var result = _sut.ApplyFilter1(words);

        Assert.Equal(4, result.Count);
        Assert.DoesNotContain("clean", result);
        Assert.DoesNotContain("Clean", result);
        Assert.DoesNotContain("what", result);
        Assert.DoesNotContain("What", result);
        Assert.DoesNotContain("currently", result);
        Assert.DoesNotContain("Currently", result);
    }

    [Fact]
    public void ApplyFilter3_SimpleText_WordRemoved()
    {
        List<string> words = ["Test", "apple", "Tea", "banana", "toast", "Orange"];

        var result = _sut.ApplyFilter3(words);

        Assert.Equal(3, result.Count);
        Assert.DoesNotContain("Test", result);
        Assert.DoesNotContain("toast", result);
        Assert.DoesNotContain("Tea", result);
    }

    [Fact]
    public void ApplyFilter2_SimpleText_WordRemoved()
    {
        List<string> words = ["Test", "!", "Te", "banana?", "to", "Orange"];

        var result = _sut.ApplyFilter2(words);

        Assert.Equal(4, result.Count);
        Assert.DoesNotContain("Te", result);
        Assert.DoesNotContain("to", result);
    }

    [Fact]
    public void ProcessTextBruteForce_RefText_StringReturned()
    {
        var result = _sut.ProcessTextBruteForce(_refText);

        Assert.NotNull(result);
        Assert.Equal(_expectedRefTextOutput, result);
    }

    [Fact]
    public void ProcessTextElegant_RefText_StringReturned()
    {
        var filtersToApply = new List<IFilter> { new Filter1(), new Filter2(), new Filter3() };

        var result = _sut.ProcessTextElegant(_refText, filtersToApply);

        Assert.NotNull(result);
        Assert.Equal(_expectedRefTextOutput, result);
    }
}