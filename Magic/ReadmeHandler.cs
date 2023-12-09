using System.Globalization;
using CsvHelper;

namespace Magic
{
    public class ReadmeHandler
    {
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
            List<string> linesList = File.ReadAllLines(_readmePath).ToList();
            PrepareLinesToPrint(linesList);
            File.WriteAllLines(_readmePath, linesList);
        }

        private void PrepareLinesToPrint(List<string> linesList)
        {
            CalculateCardsPrice(_outputDataPath);
            linesList.Clear();
            linesList.Add(
                "Move <b>csv</b> files```topdecked csv preset```to <b>Data</b> folder, and start.\n"
            );
            linesList.Add($"> [!NOTE]");
            linesList.Add(
                $"> Total cards is <b>{_cardsAmount}</b>, their price is <b>${_priceAmount}</b>\n"
            );
            linesList.Add("<details>");
            linesList.Add("  <summary><b>Cards list</b></summary>\n");
            linesList.Add("<ul>");
            AddCardInfoToLines(_outputDataPath, linesList);
            linesList.Add("</ul>");
            linesList.Add("\n</details>");
        }

        private void AddCardInfoToLines(string path, List<string> linesList)
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

                var link = $"{Paths.PagePath}/{setCode}/{collectorNumber}/{lang}";
                var message =
                    $" <li> {price} <b><a href=\"{link}\">{name}</a></b> {setCode} - {finish} ({quantity})</li>";
                linesList.Add(message);
            }
        }

        private void CalculateCardsPrice(string path)
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

            _priceAmount = (float) Math.Round(_priceAmount, 2);
        }
    }
}