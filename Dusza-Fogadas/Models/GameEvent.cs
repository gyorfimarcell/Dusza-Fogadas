using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dusza_Fogadas.Models
{
    public class GameEvent(int id, int gameId, string name)
    {
        public int Id { get; private set; } = id;
        public int GameId { get; private set; } = gameId;
        public string Name { get; private set; } = name;

        public Game Game => Game.Games.Find(x => x.Id == GameId);
    }
}
