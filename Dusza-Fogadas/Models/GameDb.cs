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
            MySqlCommand cmd = new("SELECT * FROM gamesubjects");

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
            MySqlCommand cmd = new("SELECT * FROM gameevents");

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

        public static void SaveSubjects(int gameId)
        {
            MySqlCommand cmd = new("INSERT INTO gamesubjects (gameId, name) VALUES (@game, @name)");
            cmd.Parameters.Add("game", MySqlDbType.Int32);
            cmd.Parameters.Add("name", MySqlDbType.String);

            //using (MySqlConnection con = new(App.DB_CONNECTION))
            //{
            //    cmd.Connection = con;
            //    con.Open();
            //    cmd.ExecuteNonQuery();
            //    return Convert.ToInt32(cmd.LastInsertedId);
            //}
            
        }
    }
}
