namespace BookShop.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var authors = context.Authors
                .Select(a => new ExportMostCraziestAuthorsDTO
                {
                    AuthorName = a.FirstName + " " + a.LastName,
                    Books = a.AuthorsBooks
                        .Select(ab => ab.Book)
                        .OrderByDescending(b => b.Price)
                        .Select(b => new ExportMostCraziestBookDTO
                        {
                            BookName = b.Name,
                            BookPrice = b.Price.ToString("F2")
                        })
                        .ToArray()
                })
                .ToArray()
                .OrderByDescending(x => x.Books.Length)
                .ThenBy(x => x.AuthorName)
                .ToArray();

            var authorsJson = JsonConvert.SerializeObject(authors, Formatting.Indented);

            return authorsJson;
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            var sb = new StringBuilder();

            var books = context.Books
                .Where(b => b.PublishedOn < date && b.Genre == Genre.Science)
                .OrderByDescending(b => b.Pages)
                .ThenByDescending(b => b.PublishedOn)
                .Take(10)
                .Select(b => new ExportOldestBooksDTO
                {
                    Name = b.Name,
                    Pages = b.Pages,
                    Date = b.PublishedOn.ToString("d", CultureInfo.InvariantCulture)
                })
                .ToArray();

            var rootAttributeName = "Books";

            var serializer = new XmlSerializer(typeof(ExportOldestBooksDTO[]), 
                new XmlRootAttribute(rootAttributeName));

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, books, ns);

                sb = writer.GetStringBuilder();
            }

            return sb.ToString().TrimEnd();
        }
    }
}