using BLL.BusinessObjects;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Converters
{
   public class OrderConverter : IConverter<Order, OrderBO>
    {
        public Order Convert(OrderBO o)
        {
            if (o == null) { return null; }
            return new Order()
            {
                Id = o.Id,
                DeliveryDate = o.DeliveryDate,
                OrderDate = o.OrderDate,
                OrderPrice = o.OrderPrice,
                Supplier = o.Supplier,
                PubId = o.PubId,
                OrderItems = o.ItemIds?.Select(i => new OrderItem()
                {
                    OrderId = o.Id,
                    ItemId = i
                }).ToList()
            };
        }

        public OrderBO Convert(Order o)
        {
            if (o == null) { return null; }
            
            return new OrderBO()
            {
                Id = o.Id,
                DeliveryDate = o.DeliveryDate,
                OrderDate = o.OrderDate,
                OrderPrice = o.OrderPrice,
                Supplier = o.Supplier,

                PubId = o.PubId,
                Pub = new PubConverter().Convert(o.Pub),
                ItemIds = o.OrderItems?.Select(i => i.ItemId).ToList()

            };
        }
    }
}
