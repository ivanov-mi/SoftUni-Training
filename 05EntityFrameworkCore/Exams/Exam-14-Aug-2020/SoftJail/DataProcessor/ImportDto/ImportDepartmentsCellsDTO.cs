namespace SoftJail.DataProcessor.ImportDto
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    public class ImportDepartmentsCellsDTO
    {
        [Required]
        [JsonProperty("Name")]
        [MinLength(GlobalConstants.DepartmentNameMinLength)]
        [MaxLength(GlobalConstants.DepartmentNameMaxLength)]
        public string DepartmentName { get; set; }

        [JsonProperty("Cells")]
        public ImportCellDTO[] Cells { get; set; }
    }
}
