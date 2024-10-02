using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dusza_Fogadas.Models
{
    public class Game
    {
        public static List<Game> Games = [];

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

        public static Game NewGame(string name, List<string> subjects, List<string> events)
        {
            Game game = new() {
                Name = name,
                OrganizerId = 1 //TODO
            };

            int id = GameDb.SaveNewGame(game);
            game.Id = id;
            Games.Add(game);

            GameDb.SaveSubjects(id, subjects);
            GameDb.SaveEvents(id, events);

            return game;
        }
    }
}
