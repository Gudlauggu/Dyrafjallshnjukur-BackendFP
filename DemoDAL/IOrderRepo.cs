using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IOrderRepo
    {
        Order Create(Order order);
        IEnumerable<Order> GetAll();
        Order Get(int Id);

        Order Delete(int Id);
    }
}
