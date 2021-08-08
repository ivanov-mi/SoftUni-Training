namespace ProductShop.Dtos.Export
{
    using System.Xml.Serialization;

    public class ExportUsersAndProductsDTO
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        public ExportUserWithCountDTO[] Users { get; set; }
    }
}
