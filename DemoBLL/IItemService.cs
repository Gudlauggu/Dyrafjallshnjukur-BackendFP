using BLL.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface IItemService
    {
        ItemBO Create(ItemBO i);

        List<ItemBO> GetAll();
        ItemBO Get(int Id);

        ItemBO Update(ItemBO i);

        ItemBO Delete(int Id);
    }
}
