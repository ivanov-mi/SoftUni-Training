namespace VaporStore.DataProcessor
{
	using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Globalization;

    using Newtonsoft.Json;
    using System.Xml.Serialization;

    using Data;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Export;

    public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
			var games = context.Genres
				.ToArray()
				.Where(g => genreNames.Contains(g.Name) && g.Games.Any(x => x.Purchases.Any()))
				.Select(g => new ExportGamesByGenresDTO
				{
					GenreId = g.Id,
					Genre = g.Name,
					Games = g.Games
						.Where(ga => ga.Purchases.Any())
						.Select(ga => new ExportGameDTO
						{
							GameId = ga.Id,
							Title = ga.Name,
							Developer = ga.Developer.Name,
							Tags = String.Join(", ", ga.GameTags
								.Select(gt => gt.Tag.Name)
								.ToArray()),
							Players = ga.Purchases.Count
						})
						.OrderByDescending(exd => exd.Players)
						.ThenBy(exf => exf.GameId)
						.ToArray(),
					TotalPlayers = g.Games.Sum(ga => ga.Purchases.Count),
				})
				.OrderByDescending(x => x.TotalPlayers)
				.ThenBy(x => x.GenreId)
				.ToArray();

			var gamesByGenreJson = JsonConvert.SerializeObject(games, Formatting.Indented);

			return gamesByGenreJson;
		}

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{
			Enum.TryParse<PurchaseType>(storeType, out var purchaseType);

			var users = context.Users
				.ToArray()
				.Where(u => u.Cards.Any(c => c.Purchases.Any()))
				.Select(u => new ExportUserPurchasesDTO
				{
					Username = u.Username,
					Purchases = u.Cards
						.SelectMany(c => c.Purchases)
						.Where(p => p.Type == purchaseType)
						.OrderBy(p => p.Date)
						.Select(p => new ExportPurchasesByTypeDTO
						{
							Card = p.Card.Number,
							Cvc = p.Card.Cvc,
							Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
							Game = new ExportGameByPurchaseDTO
							{
								Title = p.Game.Name,
								Genre = p.Game.Genre.Name.ToString(),
								Price = p.Game.Price
							}
						})
						.ToArray(),
					TotalSpent = u.Cards
						.SelectMany(c => c.Purchases)
						.Where(p => p.Type == purchaseType)
						.Sum(p => p.Game.Price)
				})
				.ToArray()
				.Where(u => u.Purchases.Any())
				.OrderByDescending(u => u.TotalSpent)
				.ThenBy(u => u.Username)
				.ToArray();

			var sb = new StringBuilder();

			var rootAttributeName = "Users";

			var xmlSerializer = new XmlSerializer(typeof(ExportUserPurchasesDTO[]),
				new XmlRootAttribute(rootAttributeName));

			var ns = new XmlSerializerNamespaces();
			ns.Add("", "");

			using (var writer = new StringWriter())
			{
				xmlSerializer.Serialize(writer, users, ns);

				sb = writer.GetStringBuilder();
			}

			return sb.ToString().TrimEnd();
		}
	}
}