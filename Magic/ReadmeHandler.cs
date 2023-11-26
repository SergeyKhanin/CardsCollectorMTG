using System.Globalization;
using CsvHelper;

namespace Magic
{
    public static class ReadmeHandler
    {
        private const string Scryfall = "https://scryfall.com/card/";
        private static int _cardsAmount;
        private static float _priceAmount;

        public static void Print(string outputDataPath, string markdownPath)
        {
            List<string> lines = File.ReadAllLines(markdownPath).ToList();
            Counter(outputDataPath);
            lines.Clear();
            lines.Add(
                "Move <b>csv</b> files```topdecked csv preset```to <b>Data</b> folder, and start.\n"
            );
            lines.Add($"> [!NOTE]");
            lines.Add(
                $"> Total cards is <b>{_cardsAmount}</b>, their price is <b>${_priceAmount}</b>\n"
            );
            lines.Add("<details>");
            lines.Add("  <summary><b>Cards list</b></summary>\n");
            lines.Add("<ul>");
            Message(outputDataPath, lines);
            lines.Add("</ul>");
            lines.Add("\n</details>");
            File.WriteAllLines(markdownPath, lines);
        }

        private static void Message(string path, List<string> lines)
        {
            using var reader = new StreamReader(path);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var records = csv.GetRecords<CardModel>();

            foreach (var record in records)
            {
                var quantity = record.Quantity;
                var name = record.Name;
                var setCode = record.SetCode;
                var collectorNumber = record.CollectorNumber;
                var price = record.Price;
                var finish = record.Finish;

                var link = Scryfall + "/" + setCode + "/" + collectorNumber;
                var message =
                    $" <li> {price} <a href=\"{link}\">{name}</a> - {finish} ({quantity})</li>";
                lines.Add(message);
            }
        }

        private static void Counter(string path)
        {
            using var reader = new StreamReader(path);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var records = csv.GetRecords<CardModel>();

            foreach (var record in records)
            {
                var quantity = record.Quantity;
                var price = record.Price;
                var quantityConverted = Convert.ToInt32(quantity);
                var priceConverted = Convert.ToSingle(price?.Remove(0, 1));

                _cardsAmount += quantityConverted;
                _priceAmount += priceConverted * quantityConverted;
            }

            _priceAmount = (float)Math.Round(_priceAmount, 2);
        }
    }
}
