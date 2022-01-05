namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var playsDto = XmlConverter.Deserializer<PlayerInportModel>(xmlString, "Plays");

            var plays = new List<Play>();

            foreach (var playDto in playsDto)
            {
                if (!IsValid(playDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isValitDuration = TimeSpan.TryParseExact(playDto.Duration, "c",
                    CultureInfo.InvariantCulture, out var duration);

                if (isValitDuration == false || duration.Hours < 1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isValidGener = Enum.TryParse<Genre>(playDto.Genre, out var genre);

                if (isValidGener == false )
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var play = new Play
                {
                    Title = playDto.Title,
                    Duration = duration,
                    Rating = playDto.Rating,
                    Genre = genre,
                    Description = playDto.Description,
                    Screenwriter = playDto.Screenwriter
                };

                plays.Add(play);

                sb.AppendLine(String.Format(SuccessfulImportPlay, play.Title, play.Genre, play.Rating));
            }

            context.Plays.AddRange(plays);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var casts = new List<Cast>();

            var castsDto = XmlConverter.Deserializer<CastInportModel>(xmlString, "Casts");

            foreach (var castDto in castsDto)
            {
                if (!IsValid(castDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                
                var cast = new Cast
                {
                    FullName = castDto.FullName,
                    IsMainCharacter = castDto.IsMainCharacter,
                    PhoneNumber = castDto.PhoneNumber,
                    PlayId = castDto.PlayId
                };

                casts.Add(cast);

                var role = string.Empty;

                if (cast.IsMainCharacter == true)
                {
                    role = "main";
                }
                else
                {
                    role = "lesser"; 
                }

                sb.AppendLine(String.Format(SuccessfulImportActor, cast.FullName, role));
            }            
            
            context.Casts.AddRange(casts);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var theaters = new List<Theatre>();

            var theatersDto = JsonConvert.DeserializeObject<ICollection<TheatherTicketsInportModel>>(jsonString);

            foreach (var theaterDto in theatersDto)
            {
                if (!IsValid(theaterDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var theater = new Theatre
                {
                    Name = theaterDto.Name,
                    NumberOfHalls = theaterDto.NumberOfHalls,
                    Director = theaterDto.Director
                };

                var tickets = new List<Ticket>();

                foreach (var ticketDto in theaterDto.Tickets)
                {
                    if (!IsValid(ticketDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    //var playDb = context.Plays.Find(ticketDto.PlayId);

                    //if (playDb == null)
                    //{
                    //    sb.AppendLine(ErrorMessage);
                    //    continue;
                    //}

                    var ticket = new Ticket
                    {
                        Price =decimal.Parse(ticketDto.Price.ToString("f2")),
                        RowNumber = ticketDto.RowNumber,
                        PlayId = ticketDto.PlayId,  
                        TheatreId = theater.Id
                    };
                    
                    tickets.Add(ticket);
                }

                theater.Tickets = tickets;
                theaters.Add(theater);               

                sb.AppendLine(string.Format(SuccessfulImportTheatre, theater.Name, theater.Tickets.Count()));                
            }

            context.Theatres.AddRange(theaters);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
