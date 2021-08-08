namespace VaporStore.DataProcessor.Dto.Import
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    public class ImportUserDTO
    {
        [Required]
        [JsonProperty("FullName")]
        [RegularExpression(GlobalConstants.FullNameRegEx)]
        public string FullName { get; set; }

        [Required]
        [JsonProperty("Username")]
        [MinLength(GlobalConstants.UsernameMinLength)]
        [MaxLength(GlobalConstants.UsernameMaxLength)]
        public string Username { get; set; }

        [Required]
        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Age")]
        [Range(GlobalConstants.UserMinAge, GlobalConstants.UserMaxAge)]
        public int Age { get; set; }

        [JsonProperty("Cards")]
        public ImportCardDTO[] Cards { get; set; }
    }
}
