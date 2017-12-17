using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class User
    {
        public int Id { get; set; } 
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Role { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
