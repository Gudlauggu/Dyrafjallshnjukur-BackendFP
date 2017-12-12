using BLL.BusinessObjects;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Converters
{
    class ProfileConverter
    {
        internal Profile Convert(ProfileBO pro)
        {
            if (pro == null) { return null; }
            return new Profile()
            {
                Id = pro.Id,
                Address = pro.Address,
                Email = pro.Email,
                FirstName = pro.FirstName,
                LastName = pro.LastName,
                PhoneNumber = pro.PhoneNumber

            };
        }

        internal ProfileBO Convert(Profile pro)
        {
            if (pro == null) { return null; }

            return new ProfileBO()
            {
                Id = pro.Id,
                Address = pro.Address,
                Email = pro.Email,
                FirstName = pro.FirstName,
                LastName = pro.LastName,
                PhoneNumber = pro.PhoneNumber

            };
        }
    }
}
