namespace VaporStore.DataProcessor
{
	using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Globalization;
    using System.Collections.Generic;

    using Newtonsoft.Json;
    using System.Xml.Serialization;

    using Data;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;
    using System.ComponentModel.DataAnnotations;

    public static class Deserializer
	{
        private const string ErrorMessage = "Invalid Data";

		private const string SuccessfulGamesImport = "Added {0} ({1}) with {2} tags";

		private const string SuccessfulUsersImport = "Imported {0} with {1} cards";

		private const string SuccessfulPurchasesImport = "Imported {0} for {1}";

		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
			var sb = new StringBuilder();

			var gameDTOs = JsonConvert.DeserializeObject<ImportGameDTO[]>(jsonString);

			var games = new List<Game>();
			var developers = new List<Developer>();
			var genres = new List<Genre>();
			var tags = new List<Tag>();

            foreach (var gameDTO in gameDTOs)
            {
                if (!IsValid(gameDTO))
                {
					sb.AppendLine(ErrorMessage);
					continue;
                }

				DateTime releaseDate;
				var isReleaseDateValid = DateTime.TryParseExact(gameDTO.ReleaseDate, 
					"yyyy-MM-dd", 
					CultureInfo.InvariantCulture, 
					DateTimeStyles.None, 
					out releaseDate);

                if (!isReleaseDateValid)
                {
					sb.AppendLine(ErrorMessage);
					continue;
				}

				var game = new Game
				{
					Name = gameDTO.Name,
					Price = gameDTO.Price,
					ReleaseDate = releaseDate,
				};

				var developer = developers
					.FirstOrDefault(d => d.Name == gameDTO.Developer);

                if (developer == null)
                {
					developer = new Developer 
					{
						Name = gameDTO.Developer
					};

					developers.Add(developer);
                }

				game.Developer = developer;

				var genre = genres
					.FirstOrDefault(g => g.Name == gameDTO.Genre);

                if (genre == null)
                {
					genre = new Genre 
					{
						Name = gameDTO.Genre
					};

					genres.Add(genre);
                }

				game.Genre = genre;

                foreach (var tagDTO in gameDTO.Tags)
                {
                    if (String.IsNullOrEmpty(tagDTO))
                    {
						continue;
                    }

					var tag = tags
						.FirstOrDefault(t => t.Name == tagDTO);

                    if (tag == null)
                    {
						tag = new Tag 
						{
							Name = tagDTO
						};

						tags.Add(tag);
                    }

					game.GameTags.Add(new GameTag 
					{
						GameId = game.Id,
						Tag = tag,
					});
				}

                if (game.GameTags.Count == 0)
                {
					sb.AppendLine(ErrorMessage);
					continue;
                }

				games.Add(game);

				sb.AppendLine(String.Format(SuccessfulGamesImport, 
					game.Name, game.Genre.Name, game.GameTags.Count));
			}

			context.AddRange(games);
			context.SaveChanges();

			return sb.ToString().TrimEnd();
		}

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
			var sb = new StringBuilder();

			var userDTOs = JsonConvert.DeserializeObject<ImportUserDTO[]>(jsonString);

			var users = new List<User>();

            foreach (var userDTO in userDTOs)
            {
                if (!IsValid(userDTO))
                {
					sb.AppendLine(ErrorMessage);
					continue;
                }

                if (String.IsNullOrEmpty(userDTO.Email))
				{
					sb.AppendLine(ErrorMessage);
					continue;
				}

				var user = new User 
				{
					FullName = userDTO.FullName,
					Username = userDTO.Username,
					Email = userDTO.Email,
					Age = userDTO.Age,
				};

				var areCardTypesValid = true;

                foreach (var cardDTO in userDTO.Cards)
                {
                    if (!IsValid(cardDTO))
                    {
						areCardTypesValid = false;
						break;
					}

					var isCardTypeValid = Enum.TryParse<CardType>(cardDTO.Type, out var cardTypeDTO);

                    if (!isCardTypeValid)
                    {
						areCardTypesValid = false;
						break;
					}

					var card = new Card 
					{
						Number = cardDTO.Number,
						Cvc = cardDTO.CVC,
						Type = cardTypeDTO
					};

					user.Cards.Add(card);
                }

                if (!areCardTypesValid)
				{
					sb.AppendLine(ErrorMessage);
					continue;
				}

				users.Add(user);

				sb.AppendLine(String.Format(SuccessfulUsersImport, user.Username, user.Cards.Count));
            }

			context.Users.AddRange(users);
			context.SaveChanges();

			return sb.ToString().TrimEnd();
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
			var sb = new StringBuilder();

			var rootAttributeName = "Purchases";

			var xmlSerializer = new XmlSerializer(typeof(ImportPurchesesDTO[]),
				new XmlRootAttribute(rootAttributeName));

			var purchases = new List<Purchase>();

			using (var strignReader = new StringReader(xmlString))
			{
				var purchaseDTOs = (ImportPurchesesDTO[])xmlSerializer.Deserialize(strignReader);

				foreach (var purchaseDTO in purchaseDTOs)
				{
                    if (!IsValid(purchaseDTO))
                    {
						sb.AppendLine(ErrorMessage);
						continue;
                    }

					var isPurchaseTypeValid = Enum.TryParse<PurchaseType>(purchaseDTO.Type, out var purchaseTypeDTO);

                    if (!isPurchaseTypeValid)
                    {
						sb.AppendLine(ErrorMessage);
						continue;
					}

					DateTime purchaseDate;
					var isPurchaseDateValid = DateTime.TryParseExact(purchaseDTO.Date, 
						"dd/MM/yyyy HH:mm", 
						CultureInfo.InvariantCulture, 
						DateTimeStyles.None, 
						out purchaseDate);

                    if (!isPurchaseDateValid)
                    {
						sb.AppendLine(ErrorMessage);
						continue;
					}

					var card = context.Cards.FirstOrDefault(c => c.Number == purchaseDTO.Card);

                    if (card == null)
                    {
						sb.AppendLine(ErrorMessage);
						continue;
					}

					var game = context.Games.FirstOrDefault(g => g.Name == purchaseDTO.Title);

					if (game == null)
					{
						sb.AppendLine(ErrorMessage);
						continue;
					}

					var purchase = new Purchase 
					{
						Type = purchaseTypeDTO,
						ProductKey = purchaseDTO.Key,
						Date = purchaseDate,
						Card = card,
						Game = game
					};

					purchases.Add(purchase);

					sb.AppendLine(String.Format(SuccessfulPurchasesImport, purchase.Game.Name, purchase.Card.User.Username));
				}
			}

			context.Purchases.AddRange(purchases);
			context.SaveChanges();

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