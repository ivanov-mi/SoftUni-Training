namespace CarDealer.DTO.Export
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class CarAndPartsDTO
    {
        [JsonProperty("car")]
        public CarDTO Car { get; set; }

        [JsonProperty("parts")]
        public ICollection<PartsDTO> Parts { get; set; }
    }
}
