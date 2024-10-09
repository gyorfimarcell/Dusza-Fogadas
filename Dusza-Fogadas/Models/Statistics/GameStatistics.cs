using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dusza_Fogadas.Models.Statistics
{
    public class GameStatistics
    {
        public string Name { get; set; }
        public int Bets { get; set; }
        public double TotalPoints { get; set; }
        public double TotalWinnings { get; set; }

        public static List<GameStatistics> GetStatistics() {
            List<GameStatistics> statistics = [];

            foreach (Game game in Game.Games)
            {
                GameStatistics stat = new();

                stat.Name = game.Name;
                stat.Bets = game.Bets.Count;
                stat.TotalPoints = game.Bets.Sum(x => x.Amount);

                List<GameResult> results = GameDb.GetAllResults().Where(x => game.Subjects.Select(y => y.Id).Contains(x.SubjectId)).ToList();
                stat.TotalWinnings = !game.IsClosed ? 0 : results.Sum(x => x.Bets.Where(y => y.Outcome == x.Outcome).Sum(y => y.Amount * x.GetMultiplier()));

                statistics.Add(stat);
            }

            return statistics;
        }
    }
}
