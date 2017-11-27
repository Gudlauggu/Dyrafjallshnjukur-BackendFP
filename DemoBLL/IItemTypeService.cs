using BLL.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface IItemTypeService
    {
        ItemTypeBO Create(ItemTypeBO vid);

        List<ItemTypeBO> GetAll();
        ItemTypeBO Get(int Id);

        ItemTypeBO Update(ItemTypeBO vid);

        ItemTypeBO Delete(int Id);
    }
}
