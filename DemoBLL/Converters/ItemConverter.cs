using BLL.BusinessObjects;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Converters
{
    public class ItemConverter : IConverter<Item, ItemBO>
    {
        public Item Convert(ItemBO i)
        {
            if (i == null) { return null; }
            return new Item()
            {
                Id = i.Id,
                Name = i.Name,
                ITypeId = i.ItemTypeId
            };

        }

        public ItemBO Convert(Item i)
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
