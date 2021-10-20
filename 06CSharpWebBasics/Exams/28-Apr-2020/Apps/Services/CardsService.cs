using BattleCards.Data;
using BattleCards.Data.Models;
using BattleCards.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace BattleCards.Services
{
    public class CardsService : ICardsService
    {
        private readonly ApplicationDbContext db;

        public CardsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public int AddCard(AddCardInputModel input)
        {
            var card = new Card
            {
                Name = input.Name,
                ImageUrl = input.Image,
                Keyword = input.Keyword,
                Attack = input.Attack,
                Health = input.Health,
                Description = input.Description
            };

            this.db.Cards.Add(card);
            this.db.SaveChanges();
            return card.Id;
        }

        public IEnumerable<CardViewModel> GetAll()
        {
            return this.db.Cards.Select(x => new CardViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Attack = x.Attack,
                Health = x.Health,
                ImageUrl = x.ImageUrl,
                Type = x.Keyword,
                Description = x.Description,
            }).ToList();
        }

        public IEnumerable<CardViewModel> GetByUserId(string userId)
        {
            return db.UserCards.Where(x => x.UserId == userId)
                .Select(x => new CardViewModel
                {
                    Id = x.Card.Id,
                    Name = x.Card.Name,
                    ImageUrl = x.Card.ImageUrl,
                    Type = x.Card.Keyword,
                    Attack = x.Card.Attack,
                    Health = x.Card.Health,
                    Description = x.Card.Description
                }).ToList();
        }
        public void AddCardToUserCollection(string userId, int cardId)
        {
            if (this.db.UserCards.Any(x => x.CardId == cardId && x.UserId == userId))
            {
                return;
            }

            this.db.UserCards.Add(new UserCard
            {
                UserId = userId,
                CardId = cardId,
            });

            this.db.SaveChanges();
        }

        public void RemoveCardFromUserCollection(string userId, int cardId)
        {
            var userCard = this.db.UserCards.FirstOrDefault(x => x.CardId == cardId && x.UserId == userId);
            if (userCard == null)
            {
                return;
            }

            this.db.UserCards.Remove(userCard);
            this.db.SaveChanges();
        }
    }
}
