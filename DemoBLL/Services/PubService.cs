using System;
using System.Collections.Generic;
using System.Text;
using BLL.BusinessObjects;
using BLL.Converters;
using DAL;
using System.Linq;

namespace BLL.Services
{
    class PubService : IPubService
    {
        PubConverter conv = new PubConverter();
        OrderConverter oConv = new OrderConverter();
        ItemConverter iConv = new ItemConverter();

        DALFacade facade;

        public PubService(DALFacade facade)
        {
            this.facade = facade;
        }

        public PubBO Create(PubBO p)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newPub = uow.PubRepo.Create(conv.Convert(p));
                uow.Complete();
                return conv.Convert(newPub);
            }
        }

        public PubBO Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newPub = uow.PubRepo.Delete(Id);
                uow.Complete();
                return conv.Convert(newPub);
            }
        }

        public PubBO Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var pubEntity = uow.PubRepo.Get(Id);
                var pubBO = conv.Convert(pubEntity);

                /*pubBO.Items = pubBO.ItemIds?
                     .Select(id => iConv.Convert(uow.ItemRepo.Get(id)))
                     .ToList();*/
                pubBO.Items = uow.ItemRepo.GetAllById(pubBO.ItemIds)
                    .Select(i => iConv.Convert(i))
                    .ToList();

                pubBO.Orders = pubEntity.Orders?.Select(oConv.Convert).ToList();

                return pubBO;
            }
        }

        public List<PubBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                var pubs = uow.PubRepo.GetAll();
                return pubs.Select(v => conv.Convert(v)).ToList();
            }
        }

        public PubBO Update(PubBO p)
        {
            using (var uow = facade.UnitOfWork)
            {
                var pubFromDb = uow.PubRepo.Get(p.Id);
                if(pubFromDb == null)
                {
                    throw new InvalidOperationException("Pub not found");
                }
                pubFromDb.Name = p.Name;
                pubFromDb.Address = p.Address;
                var pubUpdated = conv.Convert(pubFromDb);

                //pubFromDb.PubItems.RemoveAll(
                //    pi => pubUpdated.Items.Exists(
                //        i => i.Id == pi.ItemId &&
                //        i.PubId
                //        ))

                uow.Complete();
                return pubUpdated;
            }
        }
    }
}
