using System.Globalization;

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
        CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
        CsvHandler.Read(InputDataPath, Records);
        CsvHandler.Write(OutputDataPath, Records);
        ReadmeHandler.Print(OutputDataPath, ReadmePath);
    }
}
