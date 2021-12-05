namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Linq;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theaters = context.Theatres
                .Where(x => x.NumberOfHalls >= numbersOfHalls && x.Tickets.Count() >= 20)
                .ToList()
                .Select(x => new
                {
                    Name = x.Name,
                    Halls = x.NumberOfHalls,
                    TotalIncome = x.Tickets.Where(t => t.RowNumber >= 1 && t.RowNumber <= 5).Sum(t => t.Price),
                    Tickets = x.Tickets.Where(t => t.RowNumber >= 1 && t.RowNumber <= 5)
                    .OrderByDescending(t => t.Price)
                    .Select(t => new 
                    {
                        Price = Decimal.Parse(t.Price.ToString("f2")),
                        RowNumber = t.RowNumber
                    })
                    .ToList()
                })
                .OrderByDescending(x => x.Halls)
                .ThenBy(x => x.Name)
                .ToList();

            var result = JsonConvert.SerializeObject(theaters, Formatting.Indented);

            return result.Trim();
        }

        //Use the method provided in the project skeleton, which receives a rating.
        //Export all plays with a rating equal or smaller to the given. For each play,
        //export Title, Duration (in the format: "c"),
        //Rating, Genre, and Actors which play the main character only. 

//        Keep in mind:
//•	If the rating is 0, you should print "Premier". 
//•	For each actor display:
//o FullName
//o MainCharacter in the format: "Plays main character in '{playTitle}'."
//Order the result by play title(ascending), then by genre(descending). Order actors by their full name descending.

        public static string ExportPlays(TheatreContext context, double rating)
        {
            var plays = context.Plays
                .Where(x => x.Rating <= rating)
                .ToArray()
                .OrderBy(x => x.Title)
                .ThenByDescending(x => x.Genre)
                .Select(x => new PlayInportModel
                { 
                    Title = x.Title,
                    Duration =x.Duration.ToString("c"),
                    Rating = x.Rating == 0 ? "Premier" : x.Rating.ToString(),
                    Genre = x.Genre.ToString(),
                    Actors = x.Casts
                    .Where(x => x.IsMainCharacter == true)
                    .Select(c => new ActorInportModel 
                    {
                        FullName = c.FullName,
                        MainCharacter = $"Plays main character in '{x.Title}'."
                    }) 
                    .OrderByDescending(c => c.FullName)
                    .ToArray()

                })
                .ToArray();

            var result = XmlConverter.Serialize(plays, "Plays");

            return result.TrimEnd();
        }
    }
}
