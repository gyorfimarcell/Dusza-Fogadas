using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dusza_Fogadas.Models
{
    public class Game(int id, string name, int organizerId)
    {
        public static List<Game> Games = [];

        public int Id { get; private set; } = id;
        public string Name { get; private set; } = name;
        public int OrganizerId { get; private set; } = organizerId;

        public List<GameSubject> Subjects => GameDb.GetSubjects(Id);
        public List<GameEvent> Events => GameDb.GetEvents(Id);

        public User Organizer => User.Users.Find(x => x.Id == OrganizerId);

        public static Game NewGame(string name, List<string> subjects, List<string> events)
        {   
            
        }
    }
}
