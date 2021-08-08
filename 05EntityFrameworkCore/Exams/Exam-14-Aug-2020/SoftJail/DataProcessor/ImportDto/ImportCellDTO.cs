namespace SoftJail.DataProcessor.ImportDto
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    public class ImportCellDTO
    {
        [Required]
        [JsonProperty("CellNumber")]
        [Range(GlobalConstants.CellNumberMinValue, GlobalConstants.CellNumberMaxValue)]
        public int CellNumber { get; set; }

        [Required]
        [JsonProperty("HasWindow")]
        public bool HasWindow { get; set; }
    }
}
