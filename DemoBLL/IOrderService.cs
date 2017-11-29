using BLL.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
   public interface IOrderService
    {
        OrderBO Create(OrderBO order);

        List<OrderBO> GetAll();
        OrderBO Get(int Id);

        OrderBO Update(OrderBO p);

        OrderBO Delete(int Id);
    }
}
