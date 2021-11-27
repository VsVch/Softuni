namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;
    using static VaporStore.DataProcessor.XmlConvertor;

    public static class Deserializer
	{
		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
			var games = JsonConvert.DeserializeObject<ICollection<GameImportModel>>(jsonString);

			var sb = new StringBuilder();

            foreach (var gameDto in games)
            {

                if (!IsValid(gameDto) || gameDto.Tags.Count == 0)
                {
					sb.AppendLine("Invalid Data");
					continue;
                }

				var developer = context.Developers.FirstOrDefault(x => x.Name == gameDto.Developer);
				
                if (developer == null)
                {
					developer = new Developer { Name = gameDto.Developer };
				}                

				var game = new Game 
				{ 
					Name = gameDto.Name,
					Price = gameDto.Price,
					Developer = developer,
					Genre = context.Genres.FirstOrDefault(x => x.Name == gameDto.Genre) ?? new Genre {Name = gameDto.Genre},
					ReleaseDate = gameDto.ReleaseDate.Value
				};

				foreach (var jsonTag in gameDto.Tags)
				{
					var tag = context.Tags.FirstOrDefault(x => x.Name == jsonTag)
						?? new Tag { Name = jsonTag };
					game.GameTags.Add(new GameTag { Tag = tag});
				}

				sb.AppendLine($"Added {game.Name} ({game.Genre.Name}) with {game.GameTags.Count()} tags");

				context.Games.Add(game);
				context.SaveChanges();
			}		

			return sb.ToString().TrimEnd();
		}

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
			var sb = new StringBuilder();			

			var usersDto = JsonConvert.DeserializeObject<IEnumerable<UsersInputModel>>(jsonString);

            foreach (var userDto in usersDto)
            {

                if (!IsValid(userDto) || !userDto.Cards.All(IsValid))
                {
					sb.AppendLine("Invalid Data");
					continue;
                }

				var user = new User
				{
					FullName = userDto.FullName,
					Username = userDto.Username,
					Email = userDto.Email,
					Age = userDto.Age,
					Cards = userDto.Cards.Select(x => new Card
					{
						Number = x.Number,
						Cvc = x.CVC,
						Type = x.Type.Value
					})
					.ToList()
				};
							

				sb.AppendLine($"Imported {user.Username} with {user.Cards.Count()} cards");

				context.Users.Add(user);
				context.SaveChanges();
			}			

			return sb.ToString().TrimEnd();
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
			var sb = new StringBuilder();

			var purchasesDto = XmlConverter.Deserializer<PurchaseInputModel>
				(xmlString, "Purchases");

            foreach (var purchasDto in purchasesDto)
            {				
                if (IsValid(purchasDto))
                {
					sb.AppendLine("Invalid Data");
					continue;
                }

				var isValideTime = DateTime.TryParseExact(purchasDto.Date,
					"dd/MM/yyyy HH:mm",
					CultureInfo.InvariantCulture,
					DateTimeStyles.None, out var date);

				if (!isValideTime)
                {
					sb.AppendLine("Invalid Data");
					continue;
				}

				var card = context.Cards.FirstOrDefault(x => x.Number == purchasDto.Card);
				var gameName = context.Games.FirstOrDefault(x => x.Name == purchasDto.Name);               

				var purchase = new Purchase
				{
					Type = purchasDto.Type.Value,
					Date = date,
					ProductKey = purchasDto.Key,
					Card = card,
					Game = gameName
				};

				var username = context.Users
					.Where(x => x.Id == purchase.Card.UserId)
					.Select(x => x.Username).FirstOrDefault();

				sb.AppendLine($"Imported {purchase.Game.Name} for {username}");

			    context.Add(purchase);
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