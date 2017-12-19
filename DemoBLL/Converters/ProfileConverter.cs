using BLL.BusinessObjects;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Converters
{
    public class ProfileConverter : IConverter<Profile, ProfileBO>
    {
        public Profile Convert(ProfileBO pro)
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

        public ProfileBO Convert(Profile pro)
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
