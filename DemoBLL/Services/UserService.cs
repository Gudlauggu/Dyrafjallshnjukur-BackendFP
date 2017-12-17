using System;
using System.Collections.Generic;
using System.Text;
using BLL.BusinessObjects;
using BLL.Converters;
using DAL;
using System.Linq;

namespace BLL.Services
{
    class UserService : IUserService
    {
        UserConverter conv = new UserConverter();

        DALFacade facade;

        public UserService(DALFacade facade)
        {
            this.facade = facade;
        }

        public UserBO Create(UserBO u)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newUser = uow.UserRepo.Create(conv.Convert(u));
                uow.Complete();
                return conv.Convert(newUser);
            }
        }

        public UserBO Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newUser = uow.UserRepo.Delete(Id);
                uow.Complete();
                return conv.Convert(newUser);
            }
        }

        public UserBO Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newUser = uow.UserRepo.Get(Id);
                return conv.Convert(newUser);
            }
        }

        public List<UserBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                var user = uow.UserRepo.GetAll();
                return user.Select(v => conv.Convert(v)).ToList();
            }
        }

        public UserBO Update(UserBO u)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newUser = uow.UserRepo.Get(u.Id);
                if (newUser == null)
                {
                    throw new InvalidOperationException("User not found");
                }
                newUser.Username = u.Username;
                newUser.Password = u.Password;
                newUser.Role = u.Role;
                newUser.Salt = u.Salt;
                newUser.PasswordHash = u.PasswordHash;
                newUser.PasswordSalt = u.PasswordSalt;

                uow.Complete();
                return conv.Convert(newUser);
            }
        }
    }
}
