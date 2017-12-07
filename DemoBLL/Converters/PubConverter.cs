using BLL.BusinessObjects;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Converters
{
    class PubConverter
    {
        internal Pub Convert(PubBO p)
        {
            if (p == null) { return null; }
            return new Pub()
            {
                Id = p.Id,
                Name = p.Name,
                Address = p.Address
                
            };
        }

        internal PubBO Convert(Pub p)
        {
            if (p == null) { return null; }
            return new PubBO()
            {
                Id = p.Id,
                Name = p.Name,
                Address = p.Address
            };
        }

    }
}
