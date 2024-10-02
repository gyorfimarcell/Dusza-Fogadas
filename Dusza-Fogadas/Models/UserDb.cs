using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dusza_Fogadas.Models
{
    internal static class UserDb
    {
        public static List<User> GetAllUsers()
        {
            List<User> users = [];
            MySqlCommand cmd = new("SELECT * FROM users");

            using (MySqlConnection con = new(App.DB_CONNECTION))
            {
                cmd.Connection = con;
                con.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new(
                            id: reader.GetInt32("id"),
                            username: reader.GetString("username"),
                            hashedPassword: reader.GetString("password"),
                            salt: reader.GetString("salt"),
                            role: (UserRole)Enum.Parse(typeof(UserRole), reader.GetString("role")),
                            balance: reader.GetDouble("balance")
                        ));
                    }
                }
            }

            return users;
        }

        public static int SaveNewUser(User user)
        {
            MySqlCommand cmd = new("INSERT INTO users (username, password, salt, role, balance) VALUES (@username, @password, @salt, @role, @balance)");
            cmd.Parameters.AddWithValue("username", user.Username);
            cmd.Parameters.AddWithValue("password", user.HashedPassword);
            cmd.Parameters.AddWithValue("salt", user.Salt);
            cmd.Parameters.AddWithValue("role", user.Role);
            cmd.Parameters.AddWithValue("balance", user.Balance);

            using (MySqlConnection con = new(App.DB_CONNECTION))
            {
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                return Convert.ToInt32(cmd.LastInsertedId);
            }
        }

        public static void ChangeUserBalance(int userId, double newBalance)
        {
            MySqlCommand cmd = new("UPDATE users SET balance = @new WHERE id = @id");
            cmd.Parameters.AddWithValue("id", userId);
            cmd.Parameters.AddWithValue("new", newBalance);

            using (MySqlConnection con = new(App.DB_CONNECTION))
            {
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
