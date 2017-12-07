using BLL.BusinessObjects;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
                Address = p.Address,
                PubItems = p.ItemIds?.Select(i => new PubItem() {
                    PubId = p.Id,
                    ItemId = i
                }
                ).ToList()
            };
        }

        internal PubBO Convert(Pub p)
        {
            if (p == null) { return null; }
            return new PubBO()
            {
                Id = p.Id,
                Name = p.Name,
                Address = p.Address,
                ItemIds = p.PubItems?.Select(i => i.ItemId).ToList()
            };
        }

    }
}
