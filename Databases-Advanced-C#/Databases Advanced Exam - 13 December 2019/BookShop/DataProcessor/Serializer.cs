namespace BookShop.DataProcessor
{
    using System;
    using System.Globalization;
    using System.Linq;    
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;
    using static BookShop.DataProcessor.XmlConvertor;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {               
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var authors = context.Authors
                               
                .Select(x => new
                {
                    AuthorName =  string.Join(" ", x.FirstName, x.LastName),
                    Books = x.AuthorsBooks
                    .OrderByDescending(b => b.Book.Price)
                    .Select(b => new
                    {
                        BookName = b.Book.Name,
                        BookPrice = b.Book.Price.ToString("f2")
                    })
                    .ToList()
                })
                .ToList()
                .OrderByDescending(x => x.Books.Count())
                .ThenBy(x => x.AuthorName)
                .ToList();             
                
            var result = JsonConvert.SerializeObject(authors, Formatting.Indented);
                
            return result.Trim();
        }
        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            var books = context.Books
                .Where(x => x.PublishedOn < date && x.Genre == Genre.Science)
                .ToArray()
                .OrderByDescending(x => x.Pages)
                .ThenByDescending(x => x.PublishedOn)
                .ToArray()
                .Select(x => new BookExportModel
                {
                    Pages = x.Pages,
                    Name = x.Name,
                    Date = x.PublishedOn.ToString("MM/dd/yyyy")
                })                
                .Take(10)
                .ToArray();

            var resul = XmlConverter.Serialize(books, "Books");

            return resul;
        }
    }
}