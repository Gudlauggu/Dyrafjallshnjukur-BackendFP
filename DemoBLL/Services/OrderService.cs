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
                return conv.Convert(newOrder);
            }
        }

        public List<OrderBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.OrderRepo.GetAll().Select(v => conv.Convert(v)).ToList();
            }
        }

        public OrderBO Update(OrderBO p)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newOrder = uow.OrderRepo.Get(p.Id);
                if (newOrder == null)
                {
                    throw new InvalidOperationException("Order not found");
                }
                newOrder.DeliveryDate = p.DeliveryDate;
                newOrder.OrderDate = p.OrderDate;
                newOrder.OrderPrice = p.OrderPrice;
                

                uow.Complete();
                newOrder.Pub = uow.PubRepo.Get(newOrder.PubId);

                return conv.Convert(newOrder);
            }
        }
    }
}
