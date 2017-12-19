using BLL.BusinessObjects;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Converters
{
    public class ItemTypeConverter: IConverter<ItemType, ItemTypeBO>
    {
        public ItemType Convert(ItemTypeBO it)
        {
            if (it == null) { return null; }
            return new ItemType()
            {
                Id = it.Id,
                Name = it.Name
            };

        }

        public ItemTypeBO Convert(ItemType it)
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
