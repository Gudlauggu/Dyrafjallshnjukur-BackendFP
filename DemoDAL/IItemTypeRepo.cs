using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IItemTypeRepo
    {
        ItemType Create(ItemType i);

        IEnumerable<ItemType> GetAll();
        ItemType Get(int Id);

        ItemType Delete(int Id);
    }
}
