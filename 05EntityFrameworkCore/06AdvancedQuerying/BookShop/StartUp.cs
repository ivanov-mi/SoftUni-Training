namespace BookShop
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Microsoft.EntityFrameworkCore;

    using BookShop.Initializer;
    using BookShop.Models.Enums;
    using Data;

    public class StartUp
    {
        static void Main()
        {
            using var context = new BookShopContext();
            DbInitializer.ResetDatabase(context);
        }

        //2. Age Restriction
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var sb = new StringBuilder();

            Enum.TryParse(command, true, out AgeRestriction result);

            var bookTitles = context.Books
                .Where(b => b.AgeRestriction == result)
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            foreach (var title in bookTitles)
            {
                sb.AppendLine(title);
            }

            return sb.ToString().TrimEnd();
        }

        //3. Golden Books
        public static string GetGoldenBooks(BookShopContext context)
        {
            var sb = new StringBuilder();

            var goldenBooks = context.Books
                .Where(b => (b.Copies < 5000 && b.EditionType == EditionType.Gold))
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            foreach (var title in goldenBooks)
            {
                sb.AppendLine(title);
            }

            return sb.ToString().TrimEnd();
        }

        //4. Books by Price
        public static string GetBooksByPrice(BookShopContext context)
        {
            var sb = new StringBuilder();

            var books = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => new { b.Title, b.Price })
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        //5. Not Released In
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var sb = new StringBuilder();

            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().TrimEnd();
        }

        //6. Book Titles by Category
        public static string GetBooksByCategory(BookShopContext context, string categoriesInput)
        {
            var sb = new StringBuilder();

            var categories = categoriesInput
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select( x => x.ToLower())
                .ToArray();

            var books = context.BookCategories
                .Where(bc => categories.Contains(bc.Category.Name.ToLower()))
                .Select(bc => bc.Book.Title)
                .OrderBy(b => b)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().TrimEnd();
        }

        //7. Released Before Date
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var sb = new StringBuilder();

            var givenDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(b => b.ReleaseDate < givenDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new {b.Title, b.EditionType, b.Price})
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        //8. Author Search
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new {FullName = a.FirstName + " " + a.LastName })
                .OrderBy(a => a.FullName)
                .ToList();

            foreach (var author in authors)
            {
                sb.AppendLine(author.FullName);
            }

            return sb.ToString().TrimEnd();
        }

        //9. Book Search
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            var bookTitles = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            foreach (var bookTitle in bookTitles)
            {
                sb.AppendLine(bookTitle);
            }

            return sb.ToString().TrimEnd();
        }

        //10. Book Search by Author
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            var books = context.Books
                .Where(b => b.Author.LastName.ToLower()
                    .StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => new 
                { 
                    b.Title, 
                    AuthorFullName = b.Author.FirstName + " " + b.Author.LastName
                })
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} ({book.AuthorFullName})");
            }

            return sb.ToString().TrimEnd();
        }

        //11. Count Books
        public static int CountBooks(BookShopContext context, int lengthCheck) 
            => context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();

        //12. Total Book Copies
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var sb = new StringBuilder();

            var coppiesByAuthor = context.Authors
                .Select(a => new
                {
                    FullName = a.FirstName + " " + a.LastName,
                    TotalBookCopies = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(x => x.TotalBookCopies)
                .ToList();

            foreach (var author in coppiesByAuthor)
            {
                sb.AppendLine($"{author.FullName} - {author.TotalBookCopies}");
            }

            return sb.ToString().TrimEnd();
        }

        //13. Profit by Category
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var sb = new StringBuilder();

            var totalProfitByCategory = context.Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    BookProfit = c.CategoryBooks.Sum(b => b.Book.Copies * b.Book.Price)
                })
                .OrderByDescending(x => x.BookProfit)
                .ThenBy(x => x.CategoryName)
                .ToList();

            foreach (var profitByCategory in totalProfitByCategory)
            {
                sb.AppendLine($"{profitByCategory.CategoryName} ${profitByCategory.BookProfit:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        //14. Most Recent Books
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var sb = new StringBuilder();

            var mostRecentBooksByCategory = context.Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    LastThreeBooks = c.CategoryBooks
                            .OrderByDescending(cb => cb.Book.ReleaseDate)
                            .Take(3)
                            .Select(cb => new
                            { 
                                cb.Book.Title,
                                cb.Book.ReleaseDate
                            })
                            .ToList()
                })
                .OrderBy(x => x.CategoryName)
                .ToList();

            foreach (var category in mostRecentBooksByCategory)
            {
                sb.AppendLine($"--{category.CategoryName}");

                foreach (var book in category.LastThreeBooks)
                {
                    sb.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //15. Increase Prices
        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        //16. Remove Books
        public static int RemoveBooks(BookShopContext context)
        {
            var booksToDelete = context.Books
                .Where(b => b.Copies < 4200)
                .ToList();

            var removedBooks = booksToDelete.Count();

            context.RemoveRange(booksToDelete);

            context.SaveChanges();

            return removedBooks;
        }
    }
}
