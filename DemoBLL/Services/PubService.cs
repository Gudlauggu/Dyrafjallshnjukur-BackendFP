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
                return conv.Convert(pubEntity);
            }
        }

        public List<PubBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.PubRepo.GetAll().Select(v => conv.Convert(v)).ToList();
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

                uow.Complete();
                return conv.Convert(pubFromDb);
            }
        }
    }
}
