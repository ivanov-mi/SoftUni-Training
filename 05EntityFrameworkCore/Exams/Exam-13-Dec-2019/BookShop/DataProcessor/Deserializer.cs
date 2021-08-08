namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            var sb = new StringBuilder();
           
            var rootAttributeName = "Books";

            var xmlSerializer = new XmlSerializer(typeof(ImportBookDTO[]),
                new XmlRootAttribute(rootAttributeName));

            using (var stringReader = new StringReader(xmlString))
            {
                var bookDTOs = (ImportBookDTO[])xmlSerializer.Deserialize(stringReader);

                var booksToAdd = new List<Book>();

                foreach (var bookDTO in bookDTOs)
                {
                    DateTime publishedOn;
                    bool IsDateValid = DateTime.TryParseExact(bookDTO.PublishedOn, "MM/dd/yyyy",
                        CultureInfo.InvariantCulture, 
                        DateTimeStyles.None, 
                        out publishedOn);

                    if (!IsValid(bookDTO) || !IsDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var book = new Book 
                    {
                        Name = bookDTO.Name,
                        Genre = (Genre)bookDTO.Genre,
                        Price = bookDTO.Price,
                        Pages = bookDTO.Pages,
                        PublishedOn = publishedOn
                    };

                    booksToAdd.Add(book);

                    sb.AppendLine(string.Format(SuccessfullyImportedBook, book.Name, book.Price));
                }

                context.Books.AddRange(booksToAdd);
                context.SaveChanges();
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var authorDTOs = JsonConvert.DeserializeObject<ImportAuthorDTO[]>(jsonString);

            var authors = new List<Author>();

            foreach (var authorDTO in authorDTOs)
            {
                if (!IsValid(authorDTO))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var emailExist = authors
                    .Any(a => a.Email == authorDTO.Email);

                if (emailExist)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!authorDTO.Books.Any())
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var author = new Author 
                {
                    FirstName = authorDTO.FirstName,
                    LastName = authorDTO.LastName,
                    Phone = authorDTO.Phone,
                    Email = authorDTO.Email
                };

                foreach (var bookDTO in authorDTO.Books)
                {
                    var book = context.Books.FirstOrDefault(b => b.Id == bookDTO.BookId);

                    if (book != null)
                    {
                        author.AuthorsBooks.Add(new AuthorBook 
                        {
                            Author = author,
                            Book = book
                        });
                    }
                }

                if (author.AuthorsBooks.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                sb.AppendLine(string.Format(SuccessfullyImportedAuthor, 
                    author.FirstName + " " + author.LastName, 
                    author.AuthorsBooks.Count));

                authors.Add(author);
            }

            context.Authors.AddRange(authors);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}