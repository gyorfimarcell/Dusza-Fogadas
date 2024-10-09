using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dusza_Fogadas.Models.Statistics
{
    public class Ranking
    {
        public int Place { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }

        public static List<Ranking> GetRankings()
        {
            List<Ranking> rankings = User.Users.Where(x => x.Role == UserRole.Player)
                .Select(x => new Ranking { Name = x.Username, Score = Convert.ToInt32(Math.Round(x.Balance)) })
                .OrderByDescending(x => x.Score).ToList();

            for (int i = 0; i < rankings.Count; i++)
            {
                if (i == 0) rankings[i].Place = 1;
                else if (rankings[i].Score == rankings[i - 1].Score) rankings[i].Place = rankings[i - 1].Place;
                else rankings[i].Place = rankings[i - 1].Place + 1;
            }

            return rankings;
        }
    }
}
