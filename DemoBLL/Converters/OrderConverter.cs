using BLL.BusinessObjects;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Converters
{
    class OrderConverter
    {
        internal Order Convert(OrderBO o)
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
            };
        }

        internal OrderBO Convert(Order o)
        {
            if (o == null) { return null; }
            List<ItemBO> ItemsBO = new List<ItemBO>();
            
            return new OrderBO()
            {
                Id = o.Id,
                DeliveryDate = o.DeliveryDate,
                OrderDate = o.OrderDate,
                OrderPrice = o.OrderPrice,
                Supplier = o.Supplier,

                PubId = o.PubId,
                Pub = new PubConverter().Convert(o.Pub),
                
            };
        }
    }
}
