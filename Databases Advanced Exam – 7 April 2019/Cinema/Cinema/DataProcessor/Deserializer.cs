namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Cinema.Data.Models;
    using Cinema.Data.Models.Enums;
    using Cinema.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie 
            = "Successfully imported {0} with genre {1} and rating {2}!";
        private const string SuccessfulImportHallSeat 
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection 
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket 
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var moviesDto = JsonConvert.DeserializeObject<ICollection<MovieInputModel>>(jsonString);

            foreach (var movieDto in moviesDto)
            {
                if (!IsValid(movieDto))
                {
                    sb.AppendLine(string.Format(ErrorMessage));
                    continue;
                }

                var isTitleExsist = context.Movies.FirstOrDefault(x => x.Title == movieDto.Title);

                if (isTitleExsist != null)
                {
                    sb.AppendLine(string.Format(ErrorMessage));
                    continue;
                }

                var movie = new Movie
                {
                    Title = movieDto.Title,
                    Duration = movieDto.Duration,
                    Genre = (Genre)movieDto.Genre,
                    Rating = movieDto.Rating,
                    Director = movieDto.Director
                };

                sb.AppendLine(String.Format(SuccessfulImportMovie, movie.Title, movie.Genre, movie.Rating.ToString("f2")));
                context.Movies.Add(movie);
                context.SaveChanges();
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var halls = new List<Hall>();

            var hallsDto = JsonConvert.DeserializeObject<ICollection<HallInputModel>>(jsonString);

            foreach (var hallDto in hallsDto)
            {
                if (!IsValid(hallDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var hall = new Hall
                {
                    Name = hallDto.Name,
                    Is3D = hallDto.Is3D,
                    Is4Dx = hallDto.Is4Dx,                     
                };

                if (hallDto.Seats <= 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                for (int i = 0; i < hallDto.Seats; i++)
                {
                    var seat = new Seat
                    {                        
                        Hall = hall
                    };

                    hall.Seats.Add(seat);
                }

                var projectionType = "Normal";

                if (hall.Is3D == true && hall.Is4Dx == false)
                {
                    projectionType = "3D";
                }
                else if (hall.Is3D == false && hall.Is4Dx == true)
                {
                    projectionType = "4Dx";
                }
                else if (hall.Is3D == true && hall.Is4Dx == true)
                {
                    projectionType = "4Dx/3D";
                }

                halls.Add(hall);
                sb.AppendLine(string.Format(SuccessfulImportHallSeat, hall.Name, projectionType, hall.Seats.Count()));
            }
            context.Halls.AddRange(halls);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {

            var sb = new StringBuilder();
            var projections = new List<Projection>(); 

            var projectionsDto = XmlConverter.Deserializer<ProjectionInputModel>(xmlString, "Projections");

            foreach (var procDto in projectionsDto)
            {
                if (!IsValid(procDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var isValidDate = DateTime.TryParseExact(procDto.DateTime,
                    "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateTime);

                if (isValidDate == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var isMovieExist = context.Movies.FirstOrDefault(m => m.Id == procDto.MovieId);
                var isHallExsist = context.Halls.FirstOrDefault(h => h.Id == procDto.HallId);

                if (isMovieExist == null || isHallExsist == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var projection = new Projection
                {
                    MovieId = procDto.MovieId,
                    HallId = procDto.HallId,
                    DateTime = dateTime
                };

                projections.Add(projection);

                var movieTitle = context.Movies.FirstOrDefault(m => m.Id == projection.MovieId);
                sb.AppendLine(String.Format(SuccessfulImportProjection, movieTitle.Title, projection.DateTime.ToString("MM/dd/yyyy")));
            }

            context.Projections.AddRange(projections);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var customers = new List<Customer>();

            var customersDto = XmlConverter.Deserializer<CustumerTicketInputDto>(xmlString, "Customers");

            foreach (var customerDto in customersDto)
            {
                if (!IsValid(customerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var customer = new Customer
                {
                    FirstName = customerDto.FirstName,
                    LastName = customerDto.LastName,
                    Age = customerDto.Age,
                    Balance = customerDto.Balance
                };

                var tickets = new List<Ticket>();

                foreach (var ticketDto in customerDto.Tickets)
                {
                    if (!IsValid(ticketDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var isValidProjection = context.Projections.FirstOrDefault(p => p.Id == ticketDto.ProjectionId);

                    if (isValidProjection == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var ticket = new Ticket
                    {
                        ProjectionId = ticketDto.ProjectionId,                     
                        Price = ticketDto.ProjectionId
                    };

                    tickets.Add(ticket);
                }

                customer.Tickets = tickets;
                customers.Add(customer);

                sb.AppendLine(String.Format(SuccessfulImportCustomerTicket,
                              customer.FirstName, customer.LastName, customer.Tickets.Count()));
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

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