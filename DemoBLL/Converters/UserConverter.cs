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
                Username = u.Username
             
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
                Username = u.Username


            };
        }
    }
}
