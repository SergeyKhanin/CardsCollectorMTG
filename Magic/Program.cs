using static System.Globalization.CultureInfo;

namespace Magic;

public static class Program
{
    private const string RootPath = @"..\..\..\..\";
    private const string InputDataPath = RootPath + "Data";
    private const string OutputDataPath = RootPath + "TopDecked.csv";
    private const string ReadmePath = RootPath + "README.md";
    private static readonly List<CardModel> Records = new();

    private static void Main()
    {
        CurrentCulture = GetCultureInfo("en-US");
        var csvHandler = new CsvHandler();
        var readmeHandler = new ReadmeHandler();
        
        csvHandler.Read(InputDataPath, Records);
        csvHandler.Write(OutputDataPath, Records);
        readmeHandler.Print(OutputDataPath, ReadmePath);
    }
}