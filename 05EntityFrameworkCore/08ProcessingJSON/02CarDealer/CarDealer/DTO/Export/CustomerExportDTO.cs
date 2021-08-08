namespace CarDealer.DTO.Export
{
    using Newtonsoft.Json;

    public class CustomerExportDTO
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("BirthDate")]
        public string Birthdate { get; set; }

        [JsonProperty("IsYoungDriver")]
        public bool IsYoungDriver { get; set; }
    }
}
