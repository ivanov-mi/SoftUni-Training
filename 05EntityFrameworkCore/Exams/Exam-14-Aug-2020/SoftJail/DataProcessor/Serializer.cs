namespace SoftJail.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;

    using Newtonsoft.Json;
    using System.Xml.Serialization;

    using Data;
    using SoftJail.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context.Prisoners
                .ToArray()
                .Where(p => ids.Contains(p.Id))
                .Select(p => new ExportPrisonersByCellsDTO
                {
                    PrisonerId = p.Id,
                    Name = p.FullName,
                    CellNumber = p.Cell.CellNumber,
                    Officers = p.PrisonerOfficers
                        .Select(po => new ExportOfficerDTO
                        {
                            OfficerName = po.Officer.FullName,
                            Department = po.Officer.Department.Name
                        })
                        .OrderBy(x => x.OfficerName)
                        .ToArray(),
                    TotalOfficerSalary = Math.Round(p.PrisonerOfficers
                        .Sum(po => po.Officer.Salary), 2)
                })
                .OrderBy(x => x.Name)
                .ThenBy(x => x.PrisonerId)
                .ToArray();            

            var prisonersJson = JsonConvert.SerializeObject(prisoners, Formatting.Indented);

            return prisonersJson;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var prisoners = prisonersNames
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var prisonorsInboxes = context.Prisoners
                .ToArray()
                .Where(p => prisoners.Contains(p.FullName))
                .Select(p => new ExportPrisonersInboxDTO
                {
                    Id = p.Id,
                    Name = p.FullName,
                    IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EncryptedMessages = p.Mails
                        .Select(m => new ExportEncryptedMessagesDTO
                        {
                            Description = String.Join("", m.Description.Reverse())
                        })
                        .ToArray()
                })
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id)
                .ToArray();

            var sb = new StringBuilder();

            var rootAttributeName = "Prisoners";

            var xmlSerializer = new XmlSerializer(typeof(ExportPrisonersInboxDTO[]),
                new XmlRootAttribute(rootAttributeName));

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            using (var writer = new StringWriter())
            {
                xmlSerializer.Serialize(writer, prisonorsInboxes, ns);

                sb = writer.GetStringBuilder();
            }

            return sb.ToString().TrimEnd();
        }
    }
}