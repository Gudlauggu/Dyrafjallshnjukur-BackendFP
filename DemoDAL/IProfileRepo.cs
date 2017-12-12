using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IProfileRepo
    {
        Profile Create(Profile p);

        IEnumerable<Profile> GetAll();
        Profile Get(int Id);

        Profile Delete(int Id);
    }
}
