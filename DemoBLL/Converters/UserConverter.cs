using BLL.BusinessObjects;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Converters
{
    class UserConverter
    {
        internal User Convert(UserBO u)
        {
            if (u == null) { return null; }
            return new User()
            {
                Id = u.Id,
                Password = u.Password,
                Role = u.Role,
<<<<<<< HEAD
<<<<<<< HEAD
                Username = u.Username
=======
=======
>>>>>>> d3ac035017e861c08938f7db785fdeacd09da49d
                Salt = u.Salt,
                Username = u.Username,
                PasswordHash = u.PasswordHash,
                PasswordSalt = u.PasswordSalt
<<<<<<< HEAD
>>>>>>> d3ac035017e861c08938f7db785fdeacd09da49d
                
=======
>>>>>>> d3ac035017e861c08938f7db785fdeacd09da49d
                
            };
        }

        internal UserBO Convert(User u)
        {
            if (u == null) { return null; }
            return new UserBO()
            {
                Id = u.Id,
                Password = u.Password,
                Role = u.Role,
<<<<<<< HEAD
<<<<<<< HEAD
                Username = u.Username
=======
=======
>>>>>>> d3ac035017e861c08938f7db785fdeacd09da49d
                Salt = u.Salt,
                Username = u.Username,
                PasswordHash = u.PasswordHash,
                PasswordSalt = u.PasswordSalt

<<<<<<< HEAD
>>>>>>> d3ac035017e861c08938f7db785fdeacd09da49d
=======
>>>>>>> d3ac035017e861c08938f7db785fdeacd09da49d

            };
        }
    }
}
