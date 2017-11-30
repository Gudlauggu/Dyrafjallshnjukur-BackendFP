using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using System.Linq;

namespace DAL.Repositories
{
    class OrderRepo : IOrderRepo
    {
        Context.Context context;

        public OrderRepo(Context.Context context)
        {
            this.context = context;
        }
        public Order Create(Order order)
        {
            this.context.Order.Add(order);

            return order;
        }

        public Order Delete(int Id)
        {
            var order = Get(Id);
            this.context.Order.Remove(order);

            return order;
        }

        public Order Get(int Id)
        {
            return this.context.Order.FirstOrDefault(x => x.Id == Id);
        }

        public IEnumerable<Order> GetAll()
        {
            return this.context.Order.ToList();
        }
    }
}
