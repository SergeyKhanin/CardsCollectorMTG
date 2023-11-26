using Magic;
using System.Globalization;

internal class Program
{
    private static readonly string _rootPath = @"..\..\..\..\";
    private static readonly string _inputDataPath = _rootPath + "Data";
    private static readonly string _outputDataPath = _rootPath + "TopDecked.csv";
    private static readonly string _readmePath = _rootPath + @"README.md";
    private static List<CardModel> _records = new();

    private static void Main(string[] args)
    {
        CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
        CsvHeandler.Read(_inputDataPath, _records);
        CsvHeandler.Write(_outputDataPath, _records);
        ReadmeHandler.Print(_outputDataPath, _readmePath);
    }
}
