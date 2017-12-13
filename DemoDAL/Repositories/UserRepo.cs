using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    class UserRepo : IUserRepo
    {
        Context.Context context;

        public UserRepo(Context.Context context)
        {
            this.context = context;
        } 

        public User Create(User u)
        {
            this.context.User.Add(u);
            return u;
        }

        public User Delete(int Id)
        {
            var u = Get(Id);
            this.context.User.Remove(u);
            return u;
        }

        public User Get(int Id)
        {
            return this.context.User.FirstOrDefault(x => x.Id == Id);
        }

        public IEnumerable<User> GetAll()
        {
            return this.context.User.ToList();
        }
    }
}
