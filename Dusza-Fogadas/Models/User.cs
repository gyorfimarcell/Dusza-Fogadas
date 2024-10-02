using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Dusza_Fogadas.Models
{
    public class User
    {
        const Double STARTING_BALANCE = 100;

        public static List<User> Users = UserDb.GetAllUsers();

        public static User? CurrentUser = null;

        public int Id { get; private set; }
        public string Username { get; private set; }
        public string HashedPassword { get; private set; }
        public string Salt { get; private set; }
        public UserRole Role { get; private set; }
        public double Balance { get; private set; }

        internal User() { }
        public User(int id, string username, string hashedPassword, string salt, UserRole role, double balance)
        {
            Id = id;
            Username = username;
            HashedPassword = hashedPassword;
            Salt = salt;
            Role = role;
            Balance = balance;
        }

        public List<Game> OrganizedGames => Game.Games.Where(x => x.OrganizerId == Id).ToList();
        public List<Bet> Bets => BetDb.GetAllBets().Where(x => x.UserId == Id).ToList();

        public bool CheckPassword(string password)
        {
            return CryptographicOperations.FixedTimeEquals(
                Convert.FromHexString(HashPassword(password, Salt)),
                Convert.FromHexString(HashedPassword)
            );
        }

        public void SetBalance(double newBalance)
        {
            if (newBalance < 0)
            {
                throw new ArgumentException();
            }

            UserDb.ChangeUserBalance(Id, newBalance);
            Balance = newBalance;
        }

        public static void RegisterUser(string username, string plaintextPassword)
        {
            if (Users.Any(x => x.Username == username))
            {
                throw new ArgumentException("User already exists!");
            }

            string salt = Convert.ToHexString(RandomNumberGenerator.GetBytes(64));

            User user = new() {
                Username = username,
                HashedPassword = HashPassword(plaintextPassword, salt),
                Salt = salt,
                Role = UserRole.Player,
                Balance = STARTING_BALANCE,
            };

            int id = UserDb.SaveNewUser(user);
            user.Id = id;

            Users.Add(user);

            CurrentUser = user;
        }

        public static bool TryLogin(string username, string password)
        {
            User user = Users.Find(x => x.Username == username);
            if (user == null) return false;

            if (user.CheckPassword(password))
            {
                CurrentUser = user;
                return true;
            }

            return false;
        }

        public static void Logout()
        {
            CurrentUser = null;
        }

        private static string HashPassword(string plaintextPassword, string salt)
        {
            Byte[] saltBytes = Convert.FromHexString(salt);
            var hash = Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(plaintextPassword), saltBytes, 350000, HashAlgorithmName.SHA512, 64);
            return Convert.ToHexString(hash);
        }
    }

    public enum UserRole
    {
        Player,
        Organizer
    }
}
