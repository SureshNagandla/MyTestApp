using System;
namespace MyTestApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        // PasswordHash and PasswordSalt stored as base64 strings
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string Role { get; set; }
    }
}
