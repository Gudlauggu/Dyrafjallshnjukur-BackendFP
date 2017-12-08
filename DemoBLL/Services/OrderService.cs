using System;
using System.Collections.Generic;
using System.Text;
using BLL.BusinessObjects;
using BLL.Converters;
using DAL;
using System.Linq;

namespace BLL.Services
{
    class OrderService : IOrderService
    {
        OrderConverter conv = new OrderConverter();
        ItemConverter iConv = new ItemConverter();

        DALFacade facade;

        public OrderService(DALFacade facade)
        {
            this.facade = facade;
        }

        public OrderBO Create(OrderBO order)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newOrder = uow.OrderRepo.Create(conv.Convert(order));
                uow.Complete();
                return conv.Convert(newOrder);
            }
        }

        public OrderBO Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newOrder = uow.OrderRepo.Delete(Id);
                uow.Complete();
                return conv.Convert(newOrder);
            }
        }

        public OrderBO Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newOrder = uow.OrderRepo.Get(Id);
                newOrder.Pub = uow.PubRepo.Get(newOrder.PubId);
                var orderBO = conv.Convert(newOrder);

                orderBO.Items = uow.ItemRepo.GetAllById(orderBO.ItemIds)
                    .Select(i => iConv.Convert(i))
                    .ToList();

                return orderBO;
            }
        }

        public List<OrderBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.OrderRepo.GetAll().Select(v => conv.Convert(v)).ToList();
            }
        }


        public OrderBO Update(OrderBO o)
        {
            using (var uow = facade.UnitOfWork)
            {
                var orderFromDb = uow.OrderRepo.Get(o.Id);
                if (orderFromDb == null)
                {
                    throw new InvalidOperationException("Order not found");
                }
                var orderUpdated = conv.Convert(o);
                orderFromDb.DeliveryDate = orderUpdated.DeliveryDate;
                orderFromDb.OrderDate = orderUpdated.OrderDate;
                orderFromDb.OrderPrice = orderUpdated.OrderPrice;
                orderFromDb.Supplier = orderUpdated.Supplier;

                orderFromDb.OrderItems.RemoveAll(
                    oi => !orderUpdated.OrderItems.Exists(
                          i => i.ItemId == oi.ItemId &&
                          i.OrderId == oi.OrderId
                          ));
                orderFromDb.OrderItems.AddRange(
                    orderUpdated.OrderItems);


                uow.Complete();
                orderFromDb.Pub = uow.PubRepo.Get(orderFromDb.PubId);
                return conv.Convert(orderFromDb);
            }
        }
    }
}
