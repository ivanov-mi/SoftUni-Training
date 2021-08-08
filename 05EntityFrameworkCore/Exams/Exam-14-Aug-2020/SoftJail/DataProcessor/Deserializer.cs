namespace SoftJail.DataProcessor
{
    using System;
    using System.IO;
    using System.Text;
    using System.Linq;
    using System.Globalization;
    using System.Xml.Serialization;
    using System.Collections.Generic;

    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    using Data;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data";

        private const string SuccessfullyImportedDepartmentsCells = @"Imported {0} with {1} cells";

        private const string SuccessfullyImportedPrisonersMails = @"Imported {0} {1} years old";

        private const string SuccessfullyImportOfficersPrisoners = @"Imported {0} ({1} prisoners)";

        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var departmentCellDTOs = JsonConvert.DeserializeObject<ImportDepartmentsCellsDTO[]>(jsonString);

            var departments = new List<Department>();

            foreach (var deparmentDTO in departmentCellDTOs)
            {
                if (!IsValid(deparmentDTO))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var department = new Department 
                {
                    Name = deparmentDTO.DepartmentName
                };

                var areAllDeparmentCellValid = true;

                foreach (var cellDTO in deparmentDTO.Cells)
                {
                    if (!IsValid(cellDTO))
                    {
                        areAllDeparmentCellValid = false;
                        break;
                    }

                    var cell = new Cell
                    {
                        CellNumber = cellDTO.CellNumber,
                        HasWindow = cellDTO.HasWindow,
                    };

                    department.Cells.Add(cell);
                }

                if (!areAllDeparmentCellValid || !department.Cells.Any())
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                sb.AppendLine(string.Format(SuccessfullyImportedDepartmentsCells, 
                    department.Name, 
                    department.Cells.Count));

                departments.Add(department);            
            }

            context.Departments.AddRange(departments);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var prisonerMailDTOs = JsonConvert.DeserializeObject<ImportPrisonersMailsDTO[]>(jsonString);

            var prisoners = new List<Prisoner>();

            foreach (var prisonerMailDTO in prisonerMailDTOs)
            {
                if (!IsValid(prisonerMailDTO))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime incarcerationDateDTO;
                bool isIncarcerationDateValid = DateTime.TryParseExact(prisonerMailDTO.IncarcerationDate, 
                    "dd/MM/yyyy", 
                    CultureInfo.InvariantCulture, 
                    DateTimeStyles.None, 
                    out incarcerationDateDTO);

                if (!isIncarcerationDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime? ReleaseDateDTO = null;

                if (prisonerMailDTO.ReleaseDate != null)
                {
                    DateTime ReleaseDateDTOValue;

                    bool IsReleaseDateValid = DateTime.TryParseExact(prisonerMailDTO.ReleaseDate,
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out ReleaseDateDTOValue);

                    if (!IsReleaseDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    ReleaseDateDTO = ReleaseDateDTOValue;
                }

                var prisoner = new Prisoner
                {
                    Nickname = prisonerMailDTO.Nickname,
                    FullName = prisonerMailDTO.FullName,
                    Age = prisonerMailDTO.Age,
                    IncarcerationDate = incarcerationDateDTO,
                    ReleaseDate = ReleaseDateDTO,
                    Bail = prisonerMailDTO.Bail,
                    CellId = prisonerMailDTO.CellId,
                };

                var areAllEmailsValid = true;

                foreach (var mailDTO in prisonerMailDTO.Mails)
                {
                    if (!IsValid(mailDTO))
                    {
                        areAllEmailsValid = false;
                        break;
                    }

                    var mail = new Mail 
                    {
                        Description = mailDTO.Description,
                        Sender = mailDTO.Sender,
                        Address = mailDTO.Address,
                    };

                    prisoner.Mails.Add(mail);
                }

                if (!areAllEmailsValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                prisoners.Add(prisoner);

                sb.AppendLine(string.Format(SuccessfullyImportedPrisonersMails, 
                    prisoner.FullName, 
                    prisoner.Age));
            }

            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var rootAttributeName = "Officers";

            var xmlSerializer = new XmlSerializer(typeof(ImportOfficersPrisonersDTO[]), 
                new XmlRootAttribute(rootAttributeName));

            var officers = new List<Officer>();
            
            using (var stringReader = new StringReader(xmlString))
            {
                var officerPrisonerDTOs = (ImportOfficersPrisonersDTO[])xmlSerializer.Deserialize(stringReader);

                foreach (var officerPrisonerDTO in officerPrisonerDTOs)
                {
                    if (!IsValid(officerPrisonerDTO))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var isPositionValid = Enum.TryParse<Position>(officerPrisonerDTO.Position, out var positionDTO);
                    var isWeaponValid = Enum.TryParse<Weapon>(officerPrisonerDTO.Weapon, out var weaponDTO);

                    if (!isPositionValid || !isWeaponValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var officer = new Officer 
                    {
                        FullName = officerPrisonerDTO.Name,
                        Salary = officerPrisonerDTO.Money,
                        Position = positionDTO,
                        Weapon = weaponDTO,
                        DepartmentId = officerPrisonerDTO.DepartmentId,
                    };

                    foreach (var prisonerIdDTO in officerPrisonerDTO.Prisoners)
                    {
                        officer.OfficerPrisoners.Add(new OfficerPrisoner 
                        {
                            OfficerId = officer.Id,
                            PrisonerId = prisonerIdDTO.PrisonerId                            
                        });
                    }

                    officers.Add(officer);

                    sb.AppendLine(string.Format(SuccessfullyImportOfficersPrisoners, 
                        officer.FullName, 
                        officer.OfficerPrisoners.Count()));
                }

                context.Officers.AddRange(officers);
                context.SaveChanges();
            }

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}