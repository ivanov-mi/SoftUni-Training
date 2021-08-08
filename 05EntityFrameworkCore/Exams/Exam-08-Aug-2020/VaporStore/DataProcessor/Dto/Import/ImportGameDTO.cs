namespace VaporStore.DataProcessor.Dto.Import
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    public class ImportGameDTO
    {
        [Required]
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Price")]
        [Range(typeof(decimal), GlobalConstants.GameMinPrice, GlobalConstants.GameMaxPrice)]
        public decimal Price { get; set; }

        [Required]
        [JsonProperty("ReleaseDate")]
        public string ReleaseDate { get; set; }

        [Required]
        [JsonProperty("Developer")]
        public string Developer { get; set; }

        [Required]
        [JsonProperty("Genre")]
        public string Genre { get; set; }

        [JsonProperty("Tags")]
        public string[] Tags { get; set; }
    }
}
