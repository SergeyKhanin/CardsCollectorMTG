using static System.Globalization.CultureInfo;

namespace Magic;

public static class Program
{
    private static void Main()
    {
        CurrentCulture = GetCultureInfo("en-US");

        List<CardModel> records = new();

        var csvHandler = new CsvHandler(
            Paths.InputDataPath,
            Paths.OutputDataPathCsv,
            Filter.SetCode,
            records
        );
        var jsonHandler = new JsonHandler(Paths.OutputDataPathJson, records);
        var readmeHandler = new ReadmeHandler(Paths.OutputDataPathCsv, Paths.ReadmePath);

        csvHandler.Read();
        csvHandler.Sort();
        csvHandler.Write();
        jsonHandler.Write();
        readmeHandler.Print();
    }
}