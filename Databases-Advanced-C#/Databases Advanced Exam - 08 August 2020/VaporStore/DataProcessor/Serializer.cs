namespace VaporStore.DataProcessor
{
	using System;
    using System.Globalization;
    using System.Linq;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.DataProcessor.Dto.Export;
    using static VaporStore.DataProcessor.XmlConvertor;

    public static class Serializer
	{
		
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
			var games = context.Genres.ToList()
				.Where(x => genreNames.Contains(x.Name) && x.Games.Any(g => g.Purchases.Count() > 0)) 
				.Select(x => new
				{
					Id = x.Id,
					Genre = x.Name,
					Games = x.Games.Select(g => new
					{
						Id = g.Id,
						Title = g.Name,
						Developer = g.Developer.Name,
						Tags = string.Join(", ",g.GameTags.Select(x => x.Tag.Name)),
						Players = g.Purchases.Count()
					})
					.Where(x => x.Players > 0)					
					.OrderByDescending(g => g.Players)
					.ThenBy(g => g.Id)
					.ToList(),					
					TotalPlayers = x.Games.Sum(x => x.Purchases.Count())					
				})					
				.OrderByDescending(x => x.TotalPlayers)
				.ThenBy(x => x.Id)
				.ToList();

			var result = JsonConvert.SerializeObject(games, Formatting.Indented);

			return result;
		}

		//Use the method provided in the project skeleton, which receives a purchase type as a string.
		//Export all users who have any purchases. For each user,
		//export their username, purchases for that purchase type and total money spent for that purchase type.
		//For each purchase, export its card number, CVC, date in the format "yyyy-MM-dd HH:mm"
		//(make sure you use CultureInfo.InvariantCulture) and the game.
		//For each game, export its title (name), genre and price.
		//Order the users by total spent (descending), then by username (ascending).
		//For each user, order the purchases by date (ascending).
		//Do not export users, who don’t have any purchases.

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{
			
			var usersDto = context.Users
				.ToList()
				.Where(x => x.Cards.Any(c => c.Purchases.Any(p => p.Type.ToString() == storeType)))
				.Select(x => new UserPurchaseExportModel 
				{ 
					Username = x.Username,
					TotalSpent = x.Cards.Sum(c => c.Purchases
										.Where(p => p.Type.ToString() == storeType)
										.Sum(p => p.Game.Price)),

					Purchases = x.Cards.SelectMany(c => c.Purchases
					.Where(p =>p.Type.ToString() == storeType)
					.Select(p =>  new PurchasExportModel 
				    {
							Card = p.Card.Number,
							Cvc = p.Card.Cvc,
							Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
							Game =  new GameOutputModel
							{
								Name = p.Game.Name,
								Genre = p.Game.Genre.Name,
								Price = p.Game.Price
							}
									
					}))
					.OrderBy(x => x.Date)
					.ToArray()
				
				})
				.OrderByDescending(x => x.TotalSpent)
				.ThenBy(x => x.Username)
				.ToList();

			var result = XmlConverter.Serialize(usersDto, "Users");

			return result;
		}
	}
}