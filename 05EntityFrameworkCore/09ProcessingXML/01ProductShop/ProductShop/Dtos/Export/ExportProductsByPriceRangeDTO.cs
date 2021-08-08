namespace ProductShop.Dtos
{
    using System.Xml.Serialization;

    [XmlType("Product")]
    public class ExportProductsByPriceRangeDTO
    {
        [XmlElement("name")]
        public string ProductName { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("buyer")]
        public string BuyerFullName { get; set; }
    }
}
