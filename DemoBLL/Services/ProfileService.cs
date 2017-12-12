using System;
using System.Collections.Generic;
using System.Text;
using BLL.BusinessObjects;
using BLL.Converters;
using DAL;
using System.Linq;

namespace BLL.Services
{
    class ProfileService : IProfileService
    {

        ProfileConverter conv = new ProfileConverter();

        DALFacade facade;

        public ProfileService(DALFacade facade)
        {
            this.facade = facade;
        }
        public ProfileBO Create(ProfileBO profile)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newProfile = uow.ProfileRepo.Create(conv.Convert(profile));
                uow.Complete();
                return conv.Convert(newProfile);
            }
        }

        public ProfileBO Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newProfile = uow.ProfileRepo.Delete(Id);
                uow.Complete();
                return conv.Convert(newProfile);
            }
        }

        public ProfileBO Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newProfile = uow.ProfileRepo.Get(Id);
                return conv.Convert(newProfile);
            }
        }
    

        public List<ProfileBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
            return uow.ProfileRepo.GetAll().Select(v => conv.Convert(v)).ToList();
            }
        }

        public ProfileBO Update(ProfileBO profile)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newProfile = uow.ProfileRepo.Get(profile.Id);
                if (newProfile == null)
                {
                    throw new InvalidOperationException("Profile not found");
                }
                newProfile.Address = profile.Address;
                newProfile.Email = profile.Email;
                newProfile.Id = profile.Id;
                newProfile.FirstName = profile.FirstName;
                newProfile.LastName = profile.LastName;
                newProfile.PhoneNumber = profile.PhoneNumber;


                uow.Complete();
                return conv.Convert(newProfile);
            }
        }
    }
}
