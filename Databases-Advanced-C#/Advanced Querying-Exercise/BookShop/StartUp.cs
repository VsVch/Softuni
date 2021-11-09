namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            var result = RemoveBooks(db);

            Console.WriteLine(result);            
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.Copies < 4200)
                .ToList();

            context.Books.RemoveRange(books);

            context.SaveChanges();

            return books.Count();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (var book in books)
            {
                book.Price += 5;
            }
           
            context.SaveChanges();

            //Console.WriteLine(books.Count());
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var books = context.Categories
                .OrderBy(x => x.Name)
                .Select(x => new
                {
                    CategoryName = x.Name,
                    BookName = x.CategoryBooks.Select(b => new
                    {
                        b.Book.Title, b.Book.ReleaseDate.Value
                    })
                    .OrderByDescending(x => x.Value)
                    .Take(3)
                    .ToList()
                })                
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"--{book.CategoryName}");
                //sb.AppendLine($"--{book.ReleaseDate}");

                foreach (var item in book.BookName)
                {
                    sb.AppendLine($"{item.Title} ({item.Value.Year})");
                }
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var booksProfit = context.Categories                
                .Select(x => new
                { 
                    BookCategory = x.Name,
                    CategoryProfit = x.CategoryBooks.Sum(b =>b.Book.Copies * b.Book.Price)
                })           
                .OrderByDescending(x => x.CategoryProfit)
                .ThenBy(x => x.CategoryProfit)                
                .ToList();

            return string.Join(Environment.NewLine, booksProfit.Select(x => $"{x.BookCategory} ${x.CategoryProfit:f2}"));
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var books = context.Authors
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    BookCount = x.Books.Sum(x => x.Copies)
                })
               .OrderByDescending(x => x.BookCount)
               .ToList();
            
            return string.Join(Environment.NewLine, books.Select(x => $"{x.FirstName + " " + x.LastName} - {x.BookCount}"));
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var booksCount = context.Books.Count(x => x.Title.Length > lengthCheck);

            return booksCount;
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(x => EF.Functions.Like(x.Author.LastName, $"{input}%"))
                .Select(x => new
                {
                    FullName = x.Author.FirstName + " " + x.Author.LastName,
                    x.Title,
                    x.BookId
                })
                .OrderBy(x => x.BookId)
                .ToList();              

            var sb = new StringBuilder();

            foreach (var book in books)
            {               
                sb.AppendLine($"{book.Title} ({book.FullName})");                
            }
                
            return sb.ToString().Trim();
        }
                      

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var book = context.Books
                .Where(x => EF.Functions.Like(x.Title,$"%{input}%"))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList();

            return string.Join(Environment.NewLine, book);
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var author = context.Authors
                .Where(x => x.FirstName.EndsWith(input))
                .Select(x => new { FullName =  x.FirstName + " " + x.LastName })
                .OrderBy(x => x.FullName)
                .ToList();

            return string.Join(Environment.NewLine, author.Select(x => x.FullName));
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            
            var curDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var books = context.Books
                               .Where(x => x.ReleaseDate.Value.Date < curDate)
                               .Select(x => new { x.Title, x.EditionType, x.Price, x.ReleaseDate })
                               .OrderByDescending(x => x.ReleaseDate)
                               .ToList();

            return string.Join(Environment.NewLine, books.Select(x => $"{x.Title} - {x.EditionType} - ${x.Price:f2}"));
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            
            var categories = input.ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var books = context.BooksCategories
                .Where(x => categories.Contains(x.Category.Name.ToLower()))
                .Select(x =>new { BookTitle = x.Book.Title })
                .OrderBy(x => x.BookTitle)
                .ToList();

            var sb = new StringBuilder();           

            foreach (var book in books)
            {
                sb.AppendLine(book.BookTitle);                
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(x => x.ReleaseDate.Value.Year != year)
                .Select(x => new { x.Title, x.BookId })
                .OrderBy(x => x.BookId)
                .ToList();


            return string.Join(Environment.NewLine, books.Select(x => x.Title));
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books.Where(x => x.Price > 40)
                .Select(x => new { x.Title, x.Price})
                .OrderByDescending(x => x.Price)
                .ToList();

            
            return string.Join(Environment.NewLine, books.Select(x => $"{x.Title} - ${x.Price:f2}"));
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var goldEdition = Enum.Parse<EditionType>("Gold");

            var books = context.Books               
                .Where(x => x.EditionType == goldEdition && x.Copies < 5000)
                .Select(x =>new { x.Title, x.BookId })
                .OrderBy(x => x.BookId)
                .ToList();

            var result = string.Join(Environment.NewLine, books.Select(x => x.Title));

            return result;
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command) 
        {

            var ageRestrictColection = Enum.Parse<AgeRestriction>(command, true);

            var books = context.Books
                .Where(x => x.AgeRestriction == ageRestrictColection)
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList();

            var result = string.Join(Environment.NewLine, books);

            return result;
        }
    }
}
