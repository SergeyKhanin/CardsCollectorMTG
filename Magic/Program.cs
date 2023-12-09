using static System.Globalization.CultureInfo;

namespace Magic;

public static class Program
{
    private static void Main()
    {
        CurrentCulture = GetCultureInfo("en-US");

        var records = new List<CardModel>();
        var csvHandler = new CsvHandler(Paths.InputDataPath, Paths.OutputDataPath, records);
        var readmeHandler = new ReadmeHandler(Paths.OutputDataPath, Paths.ReadmePath);

        csvHandler.Read();
        csvHandler.Sort(SortFilter.SetCode);
        csvHandler.Write();
        readmeHandler.Print();
    }
}
