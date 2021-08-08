namespace SoftJail.DataProcessor.ExportDto
{
    using Newtonsoft.Json;
    
    public class ExportPrisonersByCellsDTO
    {
        [JsonProperty("Id")]
        public int PrisonerId { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("CellNumber")]
        public int CellNumber { get; set; }

        [JsonProperty("Officers")]
        public ExportOfficerDTO[] Officers { get; set; }

        [JsonProperty("TotalOfficerSalary")]
        public decimal TotalOfficerSalary { get; set; }
    }
}
