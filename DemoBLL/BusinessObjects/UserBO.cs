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
    }
}
