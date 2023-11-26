using CsvHelper.Configuration.Attributes;

namespace Magic
{
    public class CardModel
    {
        [Name("QUANTITY")]
        public string? Quantity { get; set; }

        [Name("NAME")]
        public string? Name { get; set; }

        [Name("SETCODE")]
        public string? SetCode { get; set; }

        [Name("SETNAME")]
        public string? SetName { get; set; }

        [Name("COLLECTOR NUMBER")]
        public string? CollectorNumber { get; set; }

        [Name("FINISH")]
        public string? Finish { get; set; }

        [Name("PRICE")]
        public string? Price { get; set; }

        [Name("RARITY")]
        public string? Rarity { get; set; }

        [Name("ID")]
        public string? Id { get; set; }

        [Name("ACQUIRED DATE")]
        public string? AcquiredDate { get; set; }

        [Name("ACQUIRED PRICE")]
        public string? AcquiredPrice { get; set; }

        [Name("LANG")]
        public string? Lang { get; set; }
    }
}
