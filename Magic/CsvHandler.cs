using System.Globalization;
using CsvHelper;

namespace Magic
{
    public class CsvHandler
    {
        private readonly string _inputDataPath;
        private readonly string _outputDataPath;
        private readonly List<CardModel> _records;

        public CsvHandler(string inputDataPath, string outputDataPath, List<CardModel> records)
        {
            _inputDataPath = inputDataPath;
            _outputDataPath = outputDataPath;
            _records = records;
        }

        public void Read()
        {
            var files = Directory.GetFiles(_inputDataPath, "*.csv");

            foreach (var file in files)
            {
                using var reader = new StreamReader(file);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                var records = csv.GetRecords<CardModel>();

                foreach (var record in records)
                    _records.Add(record);
            }
        }

        public void Write()
        {
            using var writer = new StreamWriter(_outputDataPath);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

            csv.WriteRecords(_records);
        }
    }
}
