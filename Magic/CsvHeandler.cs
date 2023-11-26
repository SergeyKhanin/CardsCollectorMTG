using CsvHelper;
using System.Globalization;

namespace Magic
{
    public static class CsvHeandler
    {
        public static void Read(string path, List<CardModel> list)
        {
            var files = Directory.GetFiles(path, "*.csv");

            foreach (var file in files)
            {
                using var reader = new StreamReader(file);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                var records = csv.GetRecords<CardModel>();

                foreach (var record in records)
                    list.Add(record);
            }
        }

        public static void Write(string path, List<CardModel> list)
        {
            using var writer = new StreamWriter(path);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

            csv.WriteRecords(list);
        }
    }
}
