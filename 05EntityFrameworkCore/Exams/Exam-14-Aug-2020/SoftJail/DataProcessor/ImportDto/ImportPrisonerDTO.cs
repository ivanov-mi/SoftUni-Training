namespace SoftJail.DataProcessor.ImportDto
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    public class ImportPrisonerDTO
    {
        [Required]
        [JsonProperty("Description")]
        public int Description { get; set; }

        [Required]
        [JsonProperty("Sender")]
        public int Sender { get; set; }

        [Required]
        [JsonProperty("Address")]
        [RegularExpression(GlobalConstants.PrisonerNicknameRegex)]
        public int Address { get; set; }
    }
}
