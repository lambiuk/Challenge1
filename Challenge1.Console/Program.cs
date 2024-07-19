using Challenge1.Library.Filters;
using Challenge1.Library.Interfaces;
using Challenge1.Library.Services;

var textFilterService = new TextFilterService();
var inputToProcess = textFilterService.ReadFromFile("InputText.txt");

var outputBruteForce = textFilterService.ProcessTextBruteForce(inputToProcess);
Console.WriteLine("====== Here is the Brute Force processing result ======");
Console.WriteLine(outputBruteForce);
Console.WriteLine("===================================");

Console.WriteLine();

var filtersToApply = new List<IFilter> { new Filter1(), new Filter2(), new Filter3() };
var outputElegant =
    textFilterService.ProcessTextElegant(inputToProcess, filtersToApply);
Console.WriteLine("====== Here is the more elegant processing result ======");
Console.WriteLine(outputElegant);
Console.WriteLine("===================================");
