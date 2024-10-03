using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dusza_Fogadas.Models
{
    public class Bet
    {
        public int Id { get; private set; }
        public int UserId { get; private set; }
        public int SubjectId { get; private set; }
        public int EventId { get; private set; }
        public string Outcome { get; private set; }
        public int Amount { get; private set; }

        public int GameId { get; private set; }
        

        internal Bet() { }

        public Bet(int id, int userId, int subjectId, int eventId, string outcome, int amount, int gameId)
        {
            Id = id;
            UserId = userId;
            SubjectId = subjectId;
            EventId = eventId;
            Outcome = outcome;
            Amount = amount;
            gameId = gameId;
        }

        public User User => User.Users.Find(x => x.Id == UserId);
        public Game Game => Game.Games.Find(x => x.Id == GameId);

        public static Bet PlaceBet(int gameId, int subjectId, int eventId, string outcome, int amount)
        {
            if (User.CurrentUser == null || User.CurrentUser.Role != UserRole.Player)
            {
                throw new ArgumentException("User is not a player!");
            }

            if (User.CurrentUser.Balance < amount)
            {
                throw new ArgumentException("User doesn't have enough money!");
            }

            if (User.CurrentUser.Bets.Any(x => x.SubjectId == subjectId && x.EventId == eventId))
            {
                throw new ArgumentException("User already placed a bet!");
            }

            Bet bet = new()
            {
                UserId = User.CurrentUser.Id,
                GameId = gameId,
                SubjectId = subjectId,
                EventId = eventId,
                Outcome = outcome,
                Amount = amount
            };

            int id = BetDb.SaveNewBet(bet);
            bet.Id = id;

            User.CurrentUser.SetBalance(User.CurrentUser.Balance - amount);

            return bet;
        }
    }
}
