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

        public int Id { get; private set; }
        public string Username { get; private set; }
        public string HashedPassword { get; private set; }
        public string Salt { get; private set; }
        public UserRole Role { get; private set; }
        public double Balance { get; private set; }

        public static User RegisterUser(string username, string plaintextPassword)
        {
            // Todo: check if username exists

            string salt = Convert.ToHexString(RandomNumberGenerator.GetBytes(64));

            User user = new() {
                Username = username,
                HashedPassword = HashPassword(plaintextPassword, salt),
                Salt = salt,
                Role = UserRole.Player,
                Balance = STARTING_BALANCE,
            };

            // Todo: save in database

            return user;
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
