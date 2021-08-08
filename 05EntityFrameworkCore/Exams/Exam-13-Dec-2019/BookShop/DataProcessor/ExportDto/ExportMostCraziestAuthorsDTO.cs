using Newtonsoft.Json;

namespace BookShop.DataProcessor.ExportDto
{
    public class ExportMostCraziestAuthorsDTO
    {
        [JsonProperty("AuthorName")]
        public string AuthorName { get; set; }

        public ExportMostCraziestBookDTO[] Books { get; set; }
    }
}
