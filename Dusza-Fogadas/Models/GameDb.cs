using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dusza_Fogadas.Models
{
    internal static class GameDb
    {
        public static List<Game> GetAllGames()
        {
            List<Game> games = [];
            MySqlCommand cmd = new("SELECT * FROM games");

            using (MySqlConnection con = new(App.DB_CONNECTION))
            {
                cmd.Connection = con;
                con.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        games.Add(new(
                            id: reader.GetInt32("id"),
                            name: reader.GetString("name"),
                            organizerId: reader.GetInt32("organizerId")
                        ));
                    }
                }
            }

            return games;
        }

        public static int SaveNewGame(Game game)
        {
            MySqlCommand cmd = new("INSERT INTO games (name, organizerId) VALUES (@name, @organizer)");
            cmd.Parameters.AddWithValue("name", game.Name);
            cmd.Parameters.AddWithValue("organizer", game.OrganizerId);

            using (MySqlConnection con = new(App.DB_CONNECTION))
            {
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                return Convert.ToInt32(cmd.LastInsertedId);
            }
        }

        public static List<GameSubject> GetSubjects(int gameId)
        {
            List<GameSubject> subjects = [];
            MySqlCommand cmd = new("SELECT * FROM gamesubjects WHERE gameId = @game");
            cmd.Parameters.AddWithValue("game", gameId);

            using (MySqlConnection con = new(App.DB_CONNECTION))
            {
                cmd.Connection = con;
                con.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        subjects.Add(new(
                            id: reader.GetInt32("id"),
                            name: reader.GetString("name"),
                            gameId: reader.GetInt32("gameId")
                        ));
                    }
                }
            }

            return subjects;
        }

        public static List<GameEvent> GetEvents(int gameId)
        {
            List<GameEvent> events = [];
            MySqlCommand cmd = new("SELECT * FROM gameevents WHERE gameId = @game");
            cmd.Parameters.AddWithValue("game", gameId);

            using (MySqlConnection con = new(App.DB_CONNECTION))
            {
                cmd.Connection = con;
                con.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        events.Add(new(
                            id: reader.GetInt32("id"),
                            name: reader.GetString("name"),
                            gameId: reader.GetInt32("gameId")
                        ));
                    }
                }
            }

            return events;
        }

        public static void SaveSubjects(int gameId, List<string> subjects)
        {
            MySqlCommand cmd = new("INSERT INTO gamesubjects (gameId, name) VALUES (@game, @name)");
            cmd.Parameters.AddWithValue("game", gameId);
            cmd.Parameters.Add("name", MySqlDbType.String);

            using (MySqlConnection con = new(App.DB_CONNECTION))
            {
                cmd.Connection = con;
                con.Open();
                foreach (string subject in subjects)
                {
                    cmd.Parameters["name"].Value = subject;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void SaveEvents(int gameId, List<string> events)
        {
            MySqlCommand cmd = new("INSERT INTO gameevents (gameId, name) VALUES (@game, @name)");
            cmd.Parameters.AddWithValue("game", gameId);
            cmd.Parameters.Add("name", MySqlDbType.String);

            using (MySqlConnection con = new(App.DB_CONNECTION))
            {
                cmd.Connection = con;
                con.Open();
                foreach (string gameEvent in events)
                {
                    cmd.Parameters["name"].Value = gameEvent;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void SaveResults(List<GameResult> results)
        {
            MySqlCommand cmd = new("INSERT INTO gameresults (subjectId, eventId, outcome) VALUES (@subject, @event, @outcome)");
            cmd.Parameters.Add("subject", MySqlDbType.Int32);
            cmd.Parameters.Add("event", MySqlDbType.Int32);
            cmd.Parameters.Add("outcome", MySqlDbType.String);

            using (MySqlConnection con = new(App.DB_CONNECTION))
            {
                cmd.Connection = con;
                con.Open();
                foreach (GameResult result in results)
                {
                    cmd.Parameters["subject"].Value = result.SubjectId;
                    cmd.Parameters["event"].Value = result.EventId;
                    cmd.Parameters["outcome"].Value = result.Outcome;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
