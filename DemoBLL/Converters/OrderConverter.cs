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
                PubId = o.PubId
            };
        }

        internal OrderBO Convert(Order o)
        {
            if (o == null) { return null; }
            return new OrderBO()
            {
                Id = o.Id,
                DeliveryDate = o.DeliveryDate,
                OrderDate = o.OrderDate,
                OrderPrice = o.OrderPrice,

                PubId = o.PubId,
                Pub = new PubConverter().Convert(o.Pub)
            };
        }
    }
}
