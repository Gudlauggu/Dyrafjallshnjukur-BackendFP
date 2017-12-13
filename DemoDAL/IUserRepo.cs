using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IUserRepo
    {
        User Create(User u);

        IEnumerable<User> GetAll();
        User Get(int Id);

        User Delete(int Id);
    }
}
