using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dusza_Fogadas.Models.Statistics
{
    public class BetStatistics
    {
        public string Subject { get; set; }
        public string Event { get; set; }
        public int Bets { get; set; }
        public double TotalPoints { get; set; }
        public double TotalWinnings { get; set; }

        public static List<BetStatistics> GetStatistics(Game game)
        {
            List<BetStatistics> statistics = [];

            foreach (GameSubject subject in game.Subjects)
            {
                foreach (GameEvent ev in game.Events)
                {
                    BetStatistics stat = new();

                    stat.Subject = subject.Name;
                    stat.Event = ev.Name;

                    List<Bet> bets = game.Bets.Where(x => x.SubjectId == subject.Id && x.EventId == ev.Id).ToList();

                    stat.Bets = bets.Count;
                    stat.TotalPoints = bets.Sum(x => x.Amount);

                    List<GameResult> results = GameDb.GetAllResults().Where(x => x.SubjectId == subject.Id && x.EventId == ev.Id).ToList();
                    stat.TotalWinnings = !game.IsClosed ? 0 : results.Sum(x => x.Bets.Where(y => y.Outcome == x.Outcome).Sum(y => y.Amount * x.GetMultiplier()));

                    statistics.Add(stat);
                }
            }

            return statistics;
        }
    }
}
