using BLL.BusinessObjects;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Converters
{
    class ItemTypeConverter
    {
        internal ItemType Convert(ItemTypeBO it)
        {
            if (it == null) { return null; }
            return new ItemType()
            {
                Id = it.Id,
                Name = it.Name
            };

        }

        internal ItemTypeBO Convert(ItemType it)
        {
            if (it == null) { return null; }
            return new ItemTypeBO()
            {
                Id = it.Id,
                Name = it.Name
            };
        }
    }
}
