using BLL.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface IItemService
    {
        ItemBO Create(ItemBO vid);

        List<ItemBO> GetAll();
        ItemBO Get(int Id);

        ItemBO Update(ItemBO vid);

        ItemBO Delete(int Id);
    }
}
