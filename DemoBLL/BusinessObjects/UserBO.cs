using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.BusinessObjects
{
    public class UserBO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Role { get; set; }
<<<<<<< HEAD
<<<<<<< HEAD
       
=======
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
>>>>>>> d3ac035017e861c08938f7db785fdeacd09da49d
=======
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
>>>>>>> d3ac035017e861c08938f7db785fdeacd09da49d
    }
}
