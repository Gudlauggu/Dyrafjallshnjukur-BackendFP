using BLL.BusinessObjects;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Converters
{
    class ItemConverter
    {
        internal Item Convert(ItemBO i)
        {
            if (i == null) { return null; }
            return new Item()
            {
                Id = i.Id,
                Name = i.Name,
                //OrderId = i.OrderId,  
                ITypeId = i.ItemTypeId
            };

        }

        internal ItemBO Convert(Item i)
        {
            if (i == null) { return null; }
            return new ItemBO()
            {
                Id = i.Id,
                Name = i.Name,
                ItemTypeId = i.ITypeId,
                ItemType = new ItemTypeConverter().Convert(i.IType)
            };
        }
    }
}
