namespace VaporStore.DataProcessor.Dto.Export
{
    using Newtonsoft.Json;
    
    public class ExportGamesByGenresDTO
    {
        [JsonProperty("Id")]
        public int GenreId { get; set; }

        [JsonProperty("Genre")]
        public string Genre { get; set; }

        [JsonProperty("Games")]
        public ExportGameDTO[] Games { get; set; }

        [JsonProperty("TotalPlayers")]
        public int TotalPlayers { get; set; }
    }
}
