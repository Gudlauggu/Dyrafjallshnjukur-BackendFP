using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IPubRepo
    {
        Pub Create(Pub p);

        IEnumerable<Pub> GetAll();
        Pub Get(int Id);

        Pub Delete(int Id);
        
    }
}
