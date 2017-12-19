using BLL.BusinessObjects;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Converters
{
    public class UserConverter : IConverter<User, UserBO>
    {
        public User Convert(UserBO u)
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

        public UserBO Convert(User u)
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
