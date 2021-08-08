namespace VaporStore.DataProcessor.Dto.Import
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    public class ImportCardDTO
    {
        [JsonProperty("Number")]
        [RegularExpression(GlobalConstants.CardNumberRegEx)]
        public string Number { get; set; }

        [JsonProperty("CVC")]
        [RegularExpression(GlobalConstants.CardCVCRegEx)]
        public string CVC { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }
    }
}
