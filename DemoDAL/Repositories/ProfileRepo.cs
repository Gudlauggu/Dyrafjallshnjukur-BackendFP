using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using System.Linq;

namespace DAL.Repositories
{
    class ProfileRepo : IProfileRepo
    {
        Context.Context context;

        public ProfileRepo(Context.Context context)
        {
            this.context = context;
        }

        public Profile Create(Profile p)
        {
            this.context.Profile.Add(p);

            return p;
        }

        public Profile Delete(int Id)
        {
            var profile = Get(Id);
            this.context.Profile.Remove(profile);

            return profile;
        }

        public Profile Get(int Id)
        {
            return this.context.Profile.FirstOrDefault(x => x.Id == Id);
        }

        public IEnumerable<Profile> GetAll()
        {
            return this.context.Profile.ToList();
        }
    }
}
