using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dusza_Fogadas.Models
{
    internal static class BetDb
    {
        public static List<Bet> GetAllBets()
        {
            List<Bet> bets = [];
            MySqlCommand cmd = new("SELECT bets.id, bets.userId, bets.subjectId, bets.eventId, bets.outcome, bets.amount, gameId FROM bets JOIN gamesubjects ON subjectId = gamesubjects.id");

            using (MySqlConnection con = new(App.DB_CONNECTION))
            {
                cmd.Connection = con;
                con.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bets.Add(new(
                            id: reader.GetInt32("id"),
                            userId: reader.GetInt32("userId"),
                            subjectId: reader.GetInt32("subjectId"),
                            eventId: reader.GetInt32("eventId"),
                            outcome: reader.GetString("outcome"),
                            amount: reader.GetInt32("amount"),
                            gameId: reader.GetInt32("gameId")
                        ));
                    }
                }
            }

            return bets;
        }

        public static int SaveNewBet(Bet bet)
        {
            MySqlCommand cmd = new("INSERT INTO bets (userId, subjectId, eventId, outcome, amount) VALUES (@user, @subject, @event, @outcome, @amount)");
            cmd.Parameters.AddWithValue("user", bet.UserId);
            cmd.Parameters.AddWithValue("subject", bet.SubjectId);
            cmd.Parameters.AddWithValue("event", bet.EventId);
            cmd.Parameters.AddWithValue("outcome", bet.Outcome);
            cmd.Parameters.AddWithValue("amount", bet.Amount);

            using (MySqlConnection con = new(App.DB_CONNECTION))
            {
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                return Convert.ToInt32(cmd.LastInsertedId);
            }
        }
    }
}
