using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IPubRepo
    {
        Pub Create(Pub p);

        List<Pub> GetAll();
        Pub Get(int Id);

        Pub Delete(int Id);
        
    }
}
