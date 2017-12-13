using BLL.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface IUserService
    {
        UserBO Create(UserBO u);

        List<UserBO> GetAll();
        UserBO Get(int Id);

        UserBO Update(UserBO u);

        UserBO Delete(int Id);
    }
}
