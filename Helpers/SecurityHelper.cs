using System;
using System.Security.Cryptography;
namespace MyTestApp.Helpers
{
    public static class SecurityHelper
    {
        public static void CreatePasswordHash(string password, out string hashBase64, out string saltBase64)
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] salt = new byte[16];
                rng.GetBytes(salt);
                using (var derive = new Rfc2898DeriveBytes(password, salt, 10000))
                {
                    byte[] hash = derive.GetBytes(32);
                    hashBase64 = Convert.ToBase64String(hash);
                    saltBase64 = Convert.ToBase64String(salt);
                }
            }
        }

        public static bool VerifyPassword(string password, string storedHashBase64, string storedSaltBase64)
        {
            byte[] salt = Convert.FromBase64String(storedSaltBase64);
            byte[] storedHash = Convert.FromBase64String(storedHashBase64);
            using (var derive = new Rfc2898DeriveBytes(password, salt, 10000))
            {
                byte[] testHash = derive.GetBytes(32);
                if (testHash.Length != storedHash.Length) return false;
                for (int i = 0; i < testHash.Length; i++)
                    if (testHash[i] != storedHash[i]) return false;
                return true;
            }
        }
    }
}
