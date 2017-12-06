using BLL.BusinessObjects;
using BLL.Converters;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Services
{
    class ItemService : IItemService
    {
        ItemConverter conv = new ItemConverter();

        DALFacade facade;

        public ItemService(DALFacade facade)
        {
            this.facade = facade;
        }

        public ItemBO Create(ItemBO i)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newItem = uow.ItemRepo.Create(conv.Convert(i));
                uow.Complete();
                return conv.Convert(newItem);
            }
        }

        public ItemBO Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newItem = uow.ItemRepo.Delete(Id);
                uow.Complete();
                return conv.Convert(newItem);
            }
        }

        public ItemBO Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var itemEntity = uow.ItemRepo.Get(Id);
                //itemEntity.Order = uow.OrderRepo.Get(itemEntity.OrderId);
                itemEntity.IType = uow.ItemTypeRepo.Get(itemEntity.ITypeId);
                return conv.Convert(itemEntity);
            }
        }


        public List<ItemBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                //return uow.VideoRepository.GetAll();
                return uow.ItemRepo.GetAll().Select(v => conv.Convert(v)).ToList();
            }
        }

        public ItemBO Update(ItemBO i)
        {
            using (var uow = facade.UnitOfWork)
            {
                var itemFromDb = uow.ItemRepo.Get(i.Id);
                if (itemFromDb == null)
                {
                    throw new InvalidOperationException("Item not found");
                }
                itemFromDb.Name = i.Name;

                uow.Complete();
                itemFromDb.IType = uow.ItemTypeRepo.Get(itemFromDb.ITypeId);
                return conv.Convert(itemFromDb);
            }
        }
    }
}
