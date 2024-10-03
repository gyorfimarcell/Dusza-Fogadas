using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dusza_Fogadas.Models
{
    public class Game
    {
        public static List<Game> Games = GameDb.GetAllGames();

        public int Id { get; private set; }
        public string Name { get; private set; }
        public int OrganizerId { get; private set; }

        internal Game() { }

        public Game(int id, string name, int organizerId) {
            Id = id;
            Name = name;
            OrganizerId = organizerId;
        }

        public List<GameSubject> Subjects => GameDb.GetSubjects(Id);
        public List<GameEvent> Events => GameDb.GetEvents(Id);

        public User Organizer => User.Users.Find(x => x.Id == OrganizerId);

        public void CloseGame(List<GameResult> results)
        {
            // TODO: check if game is already closed

            GameDb.SaveResults(results);

            List<Bet> bets = BetDb.GetAllBets();

            foreach (GameResult result in results)
            {
                List<Bet> filteredBets = bets.Where(x => x.SubjectId == result.SubjectId && x.EventId == result.EventId).ToList();
                if (filteredBets.Count == 0) return;

                double multiplier = 1 + (5 / Math.Pow(2, filteredBets.Count - 1));

                foreach (Bet winner in filteredBets.Where(x => x.Outcome == result.Outcome))
                {
                    winner.User.SetBalance(winner.User.Balance + (winner.Amount * multiplier));
                }
            }
        }

        public static Game NewGame(string name, List<string> subjects, List<string> events)
        {
            if (User.CurrentUser == null || User.CurrentUser.Role != UserRole.Organizer)
            {
                throw new ArgumentException("User is not an organizer");
            }

            if (Games.Any(x => x.Name == name))
            {
                throw new ArgumentException("A game with this name already exists!");
            }

            Game game = new() {
                Name = name,
                OrganizerId = User.CurrentUser.Id
            };

            int id = GameDb.SaveNewGame(game);
            game.Id = id;
            Games.Add(game);

            GameDb.SaveSubjects(id, subjects);
            GameDb.SaveEvents(id, events);

            return game;
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
