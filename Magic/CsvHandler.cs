using System.Globalization;
using CsvHelper;

namespace Magic
{
    public class CsvHandler
    {
        private readonly string _inputDataPath;
        private readonly string _outputDataPath;
        private List<CardModel> _records;

        public CsvHandler(string inputDataPath, string outputDataPath, List<CardModel> records)
        {
            _inputDataPath = inputDataPath;
            _outputDataPath = outputDataPath;
            _records = records;
        }

        public void Read()
        {
            var files = Directory.EnumerateFiles(_inputDataPath, "*.csv");

            foreach (var file in files)
            {
                if (File.Exists(file))
                {
                    using var reader = new StreamReader(file);
                    using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                    var records = csv.GetRecords<CardModel>();

                    foreach (var record in records)
                        _records.Add(record);
                }
                else
                {
                    Console.WriteLine($"File not found: {file}");
                }
            }
        }

        public void Sort(SortFilter sortFilter)
        {
            switch (sortFilter)
            {
                case SortFilter.Name:
                    SortByName();
                    break;
                case SortFilter.Set:
                    SortBySet();
                    break;
                default:
                    Console.WriteLine("No filter selected");
                    break;
            }
        }

        public void SortByName()
        {
            _records = _records.OrderBy(record => record.Name, StringComparer.Ordinal).ToList();
        }

        public void SortBySet()
        {
            _records = _records.OrderBy(record => record.SetCode, StringComparer.Ordinal).ToList();
        }

        public void Write()
        {
            if (_records.Count > 0)
            {
                using var writer = new StreamWriter(_outputDataPath);
                using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

                csv.WriteRecords(_records);
            }
            else
            {
                Console.WriteLine("No records to write.");
            }
        }
    }
}
