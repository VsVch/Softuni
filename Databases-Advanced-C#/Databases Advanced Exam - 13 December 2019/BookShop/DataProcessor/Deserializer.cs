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
    using static BookShop.DataProcessor.XmlConvertor;
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
            var books = new List<Book>();

            var booksDto = XmlConverter.Deserializer<BookInputModel>(xmlString, "Books");

            foreach (var bookDto in booksDto)
            {
                if (!IsValid(bookDto))
                {
                    sb.AppendLine(string.Format(ErrorMessage));
                    continue;
                }

                var isValidPublishedOnDate = DateTime.TryParseExact(bookDto.PublishedOn, "MM/dd/yyyy"
                    , CultureInfo.InvariantCulture, DateTimeStyles.None, out var publishedOn);

                if (!isValidPublishedOnDate)
                {
                    sb.AppendLine(string.Format(ErrorMessage));
                    continue;
                }

                var book = new Book
                {
                    Name = bookDto.Name,
                    Genre = (Genre)bookDto.Genre,
                    Price = bookDto.Price,
                    Pages = bookDto.Pages,
                    PublishedOn = publishedOn
                };

                books.Add(book);
                sb.AppendLine(String.Format(SuccessfullyImportedBook, book.Name, book.Price));
            }
            ;
            context.Books.AddRange(books);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var authorsDto = JsonConvert.DeserializeObject<ICollection<AuthorInputModel>>(jsonString);

            foreach (var authorDto in authorsDto)
            {
                if (!IsValid(authorDto))
                {
                    sb.AppendLine(string.Format(ErrorMessage));
                    continue;
                }

                var existingEmail = context.Authors.FirstOrDefault(x => x.Email == authorDto.Email);

                if (existingEmail != null)
                {
                    sb.AppendLine(string.Format(ErrorMessage));
                    continue;
                }

                var books = new List<Book>();

                foreach (var bookDto in authorDto.Books)
                {
                    var existingBook = context.Books.FirstOrDefault(x => x.Id == bookDto.Id);

                    if (existingBook == null)
                    {
                        continue;
                    }

                    books.Add(existingBook);
                }

                if (books.Count() == 0)
                {
                    sb.AppendLine(string.Format(ErrorMessage));
                    continue;
                }

                var author = new Author
                {
                    FirstName = authorDto.FirstName,
                    LastName = authorDto.LastName,
                    Phone = authorDto.Phone,
                    Email = authorDto.Email,
                    AuthorsBooks =  books.Select(x=> new AuthorBook 
                    { 
                        BookId = x.Id
                    })
                    .ToList()                   
                };

                var fullName = author.FirstName + " " + author.LastName;

                sb.AppendLine(string.Format(SuccessfullyImportedAuthor, fullName, author.AuthorsBooks.Count()));

                context.Authors.Add(author);
                context.SaveChanges();
            }

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