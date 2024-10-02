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
            Bet bet = new()
            {
                GameId = gameId,
                SubjectId = subjectId,
                EventId = eventId,
                Outcome = outcome,
                Amount = amount
            };

            // TODO: check if user already placed bet
            // TODO: check if user has enough money

            //GameSubject subject = game.Subjects.Find(x => x.Id == subjectId);
            //GameEvent gameEvent = game.Events.Find(x => x.Id == eventId);

            int id = BetDb.SaveNewBet(bet);
            bet.Id = id;

            return bet;
        }
    }
}
