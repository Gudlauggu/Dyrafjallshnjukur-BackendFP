using BLL.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface IProfileService
    {
        ProfileBO Create(ProfileBO profile);

        List<ProfileBO> GetAll();
        ProfileBO Get(int Id);

        ProfileBO Update(ProfileBO profile);

        ProfileBO Delete(int Id);
    }
}
