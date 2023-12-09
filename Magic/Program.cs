using static System.Globalization.CultureInfo;

namespace Magic;

public static class Program
{
    private static void Main()
    {
        CurrentCulture = GetCultureInfo("en-US");

        var csvHandler = new CsvHandler(Paths.InputDataPath, Paths.OutputDataPath, Filter.SetCode);
        var readmeHandler = new ReadmeHandler(Paths.OutputDataPath, Paths.ReadmePath);

        csvHandler.Read();
        csvHandler.Sort();
        csvHandler.Write();
        readmeHandler.Print();
    }
}
