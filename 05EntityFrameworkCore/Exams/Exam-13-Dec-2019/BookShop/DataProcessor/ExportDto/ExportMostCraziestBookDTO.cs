using Newtonsoft.Json;

namespace BookShop.DataProcessor.ExportDto
{
    public class ExportMostCraziestBookDTO
    {
        [JsonProperty("BookName")]
        public string BookName { get; set; }

        [JsonProperty("BookPrice")]
        public string BookPrice { get; set; }
    }
}
