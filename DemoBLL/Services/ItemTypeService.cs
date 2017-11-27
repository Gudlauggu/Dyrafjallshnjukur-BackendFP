using System;
using System.Collections.Generic;
using System.Text;
using BLL.BusinessObjects;
using DAL;
using BLL.Converters;
using System.Linq;

namespace BLL.Services
{
    class ItemTypeService : IItemTypeService
    {
        ItemTypeConverter conv = new ItemTypeConverter();

        DALFacade facade;

        public ItemTypeService(DALFacade facade)
        {
            this.facade = facade;
        }

        public ItemTypeBO Create(ItemTypeBO it)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newItemType = uow.ItemTypeRepo.Create(conv.Convert(it));
                uow.Complete();
                return conv.Convert(newItemType);
            }
        }

        public ItemTypeBO Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newItemType = uow.ItemTypeRepo.Delete(Id);
                uow.Complete();
                return conv.Convert(newItemType);
            }
        }

        public ItemTypeBO Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var itemTypeEntity = uow.ItemTypeRepo.Get(Id);
                return conv.Convert(itemTypeEntity);
            }
        }

        public List<ItemTypeBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.ItemTypeRepo.GetAll().Select(v => conv.Convert(v)).ToList();
            }
        }

        public ItemTypeBO Update(ItemTypeBO it)
        {
            using (var uow = facade.UnitOfWork)
            {
                var itemTypeFromDb = uow.ItemTypeRepo.Get(it.Id);
                if (itemTypeFromDb == null)
                {
                    throw new InvalidOperationException("ItemType not found");
                }
                itemTypeFromDb.Name = it.Name;

                uow.Complete();
                return conv.Convert(itemTypeFromDb);
            }
        }
    }
}
