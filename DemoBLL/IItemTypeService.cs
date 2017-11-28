using BLL.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface IItemTypeService
    {
        ItemTypeBO Create(ItemTypeBO it);

        List<ItemTypeBO> GetAll();
        ItemTypeBO Get(int Id);

        ItemTypeBO Update(ItemTypeBO it);

        ItemTypeBO Delete(int Id);
    }
}
