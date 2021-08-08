namespace VaporStore.DataProcessor.Dto.Export
{
    using Newtonsoft.Json;

    public class ExportGameDTO
    {
        [JsonProperty("Id")]
        public int GameId { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Developer")]
        public string Developer { get; set; }

        [JsonProperty("Tags")]
        public string Tags { get; set; }

        [JsonProperty("Players")]
        public int Players { get; set; }
    }
}
