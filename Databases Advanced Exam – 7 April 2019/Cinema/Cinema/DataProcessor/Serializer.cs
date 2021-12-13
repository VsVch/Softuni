namespace Cinema.DataProcessor
{
    using System;
    using System.Linq;
    using Cinema.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;

    public class Serializer
    {       
        public static string ExportTopMovies(CinemaContext context, int rating)
        {

            var topMovies = context.Movies
                .Where(x => x.Rating >= rating && x.Projections.Any(p => p.Tickets.Count > 0))
                .ToList()
                .OrderByDescending(x => x.Rating)
                .ThenByDescending(x => x.Projections.Sum(p => p.Tickets.Sum(t => t.Price)))
                .Select(x => new
                {
                    MovieName = x.Title,
                    Rating = x.Rating.ToString("f2"),
                    TotalIncomes = x.Projections.Sum(p => p.Tickets.Sum(t => t.Price)).ToString("f2"),
                    Customers = x.Projections
                        .Select(p => p.Tickets.Select(t => t.Customer).Select(c => new
                        {
                            FirstName = c.FirstName,
                            LastName = c.LastName,
                            Balance = c.Balance.ToString("f2")
                        })
                        .ToList()
                        .OrderByDescending(t => t.Balance)
                        .ThenBy(t => t.FirstName)
                        .ThenBy(t => t.LastName)
                        .ToList())
                        
                       
                })
                .Take(10)
                .ToList();

            var result = JsonConvert.SerializeObject(topMovies, Formatting.Indented);

            return result;
        }

                
        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            var customers = context.Customers.Where(x => x.Age >= age)
                .OrderByDescending(x => x.Tickets.Sum(t => t.Price))
                .Select(x => new CustomerOutputModel
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SpentMoney = x.Tickets.Sum(t => t.Price).ToString("f2"),
                    SpentTime = TimeSpan.FromMilliseconds(x.Tickets.Sum(t => t.Projection.Movie.Duration.TotalMilliseconds))
                        .ToString(@"hh\:mm\:ss")
                })
                .Take(10)                
                .ToList();

            var result = XmlConverter.Serialize(customers, "Customers");

            return result;   

        }
    }
}