﻿namespace SoftJail.DataProcessor.ExportDto
{
    using System.Xml.Serialization;
    
    [XmlType("Prisoner")]
    public class ExportPrisonersInboxDTO
    {
        [XmlElement("Id")]
        public int Id { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("IncarcerationDate")]
        public string IncarcerationDate { get; set; }

        [XmlArray("EncryptedMessages")]
        public ExportEncryptedMessagesDTO[] EncryptedMessages { get; set; }
    }
}
