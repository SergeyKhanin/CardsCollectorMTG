using CsvHelper.Configuration.Attributes;
using Newtonsoft.Json;

namespace Magic
{
    public class CardModel
    {
        [JsonIgnore]
        [Name("QUANTITY")]
        public string? Quantity { get; set; }

        [Name("NAME")]
        public string? Name { get; set; }

        [JsonIgnore]
        [Name("SETCODE")]
        public string? SetCode { get; set; }

        [JsonIgnore]
        [Name("SETNAME")]
        public string? SetName { get; set; }

        [JsonIgnore]
        [Name("COLLECTOR NUMBER")]
        public string? CollectorNumber { get; set; }

        [JsonIgnore]
        [Name("FINISH")]
        public string? Finish { get; set; }

        [JsonIgnore]
        [Name("PRICE")]
        public string? Price { get; set; }

        [JsonIgnore]
        [Name("RARITY")]
        public string? Rarity { get; set; }

        [JsonIgnore]
        [Name("ID")]
        public string? Id { get; set; }

        [JsonIgnore]
        [Name("ACQUIRED DATE")]
        public string? AcquiredDate { get; set; }

        [JsonIgnore]
        [Name("ACQUIRED PRICE")]
        public string? AcquiredPrice { get; set; }

        [JsonIgnore]
        [Name("LANG")]
        public string? Lang { get; set; }
    }
}
