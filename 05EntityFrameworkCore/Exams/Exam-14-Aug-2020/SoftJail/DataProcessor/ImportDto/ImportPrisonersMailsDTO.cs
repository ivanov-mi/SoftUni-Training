namespace SoftJail.DataProcessor.ImportDto
{
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using System.ComponentModel.DataAnnotations;

    public class ImportPrisonersMailsDTO
    {
        [Required]
        [JsonProperty("FullName")]
        [MinLength(GlobalConstants.PrisonerFullNameMinLength)]
        [MaxLength(GlobalConstants.PrisonerFullNameMaxLength)]
        public string FullName { get; set; }

        [Required]
        [JsonProperty("Nickname")]
        [RegularExpression(GlobalConstants.PrisonerNicknameRegex)]
        public string Nickname { get; set; }

        [Required]
        [JsonProperty("Age")]
        [Range(GlobalConstants.PrisonerAgeMinValue, GlobalConstants.PrisonerAgeMaxValue)]
        public int Age { get; set; }

        [Required]
        [JsonProperty("IncarcerationDate")]
        public string IncarcerationDate { get; set; }

        [JsonProperty("ReleaseDate")]
        public string ReleaseDate { get; set; }

        [JsonProperty("Bail")]
        [Range(typeof(decimal), GlobalConstants.PrisonerBailMinValue, GlobalConstants.PrisonerBailMaxValue)]
        public decimal? Bail { get; set; }

        [JsonProperty("CellId")]
        public int? CellId { get; set; }

        [JsonProperty("Mails")]
        public Mail[] Mails { get; set; }
    }
}
