namespace VaporStore.DataProcessor.Dto.Import
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Purchase")]
    public class ImportPurchesesDTO
    {
        [Required]
        [XmlAttribute("title")]
        public string Title { get; set; }

        [XmlElement("Type")]
        public string Type { get; set; }

        [Required]
        [XmlElement("Key")]
        [RegularExpression(GlobalConstants.ProductKeyRegEx)]
        public string Key { get; set; }

        [Required]
        [XmlElement("Card")]
        [RegularExpression(GlobalConstants.CardNumberRegEx)]
        public string Card { get; set; }

        [Required]
        [XmlElement("Date")]
        public string Date { get; set; }
    }
}
