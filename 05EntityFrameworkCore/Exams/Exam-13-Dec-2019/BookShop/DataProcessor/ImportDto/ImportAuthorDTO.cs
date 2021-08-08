namespace BookShop.DataProcessor.ImportDto
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    public class ImportAuthorDTO
    {
        [Required]
        [JsonProperty("FirstName")]
        [MinLength(3)]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [JsonProperty("LastName")]
        [MinLength(3)]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Required]
        [JsonProperty("Phone")]
        [RegularExpression(@"^[0-9]{3}-[0-9]{3}-[0-9]{4}$")]
        public string Phone { get; set; }

        [Required]
        [JsonProperty("Email")]
        [EmailAddress]
        public string Email { get; set; }

        [JsonProperty("Books")]
        public ImportAuthorBookDTO[] Books { get; set; }
    }
}
