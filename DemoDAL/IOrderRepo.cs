using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IOrderRepo
    {
        Order Create(Order order);
        List<Order> GetAll();
        Order Get(int Id);

        Order Delete(int Id);
    }
}
