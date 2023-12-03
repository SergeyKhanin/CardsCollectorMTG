using static System.Globalization.CultureInfo;

namespace Magic;

public static class Program
{
    private const string RootPath = @"..\..\..\..\";
    private const string InputDataPath = RootPath + "Data";
    private const string OutputDataPath = RootPath + "TopDecked.csv";
    private const string ReadmePath = RootPath + "README.md";

    private static void Main()
    {
        CurrentCulture = GetCultureInfo("en-US");

        var records = new List<CardModel>();
        var csvHandler = new CsvHandler(InputDataPath, OutputDataPath, records);
        var readmeHandler = new ReadmeHandler(OutputDataPath, ReadmePath);

        csvHandler.Read();
        csvHandler.Write();
        readmeHandler.Print();
    }
}
