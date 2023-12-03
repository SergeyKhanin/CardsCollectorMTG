using System.Globalization;
using CsvHelper;

namespace Magic
{
    public class ReadmeHandler
    {
        private const string PagePath = "https://scryfall.com/card";
        private int _cardsAmount;
        private float _priceAmount;
        private readonly string _outputDataPath;
        private readonly string _readmePath;

        public ReadmeHandler(string outputDataPath, string readmePath)
        {
            _outputDataPath = outputDataPath;
            _readmePath = readmePath;
        }

        public void Print()
        {
            List<string> lines = File.ReadAllLines(_readmePath).ToList();
            Counter(_outputDataPath);
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
            Message(_outputDataPath, lines);
            lines.Add("</ul>");
            lines.Add("\n</details>");
            File.WriteAllLines(_readmePath, lines);
        }

        private void Message(string path, List<string> lines)
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
                var lang = record.Lang;

                var link = PagePath + "/" + setCode + "/" + collectorNumber + "/" + lang;
                var message =
                    $" <li> {price} <a href=\"{link}\">{name}</a> - {finish} ({quantity})</li>";
                lines.Add(message);
            }
        }

        private void Counter(string path)
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
