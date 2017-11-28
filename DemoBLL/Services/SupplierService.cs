using System;
using System.Collections.Generic;
using System.Text;
using BLL.BusinessObjects;
using DAL;
using BLL.Converters;
using System.Linq;

namespace BLL.Services
{
    class SupplierService : ISupplierService
    {
        SupplierConverter conv = new SupplierConverter();
        DALFacade facade;

        public SupplierService(DALFacade facade)
        {
            this.facade = facade;
        }

        public SupplierBO Create(SupplierBO s)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newSupplier = uow.SupplierRepo.Create(conv.Convert(s));
                uow.Complete();
                return conv.Convert(newSupplier);
            }
        }

        public SupplierBO Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newSupplier = uow.SupplierRepo.Delete(Id);
                uow.Complete();
                return conv.Convert(newSupplier);
            }
        }

        public SupplierBO Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var supplierEntity = uow.SupplierRepo.Get(Id);
                return conv.Convert(supplierEntity);
            }
        }

        public List<SupplierBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.SupplierRepo.GetAll().Select(s => conv.Convert(s)).ToList();
            }
        }

        public SupplierBO Update(SupplierBO s)
        {
            using (var uow = facade.UnitOfWork)
            {
                var supplierFromDb = uow.SupplierRepo.Get(s.Id);
                if(supplierFromDb == null)
                {
                    throw new InvalidOperationException("Supplier not found");
                }
                supplierFromDb.Name = s.Name;
                supplierFromDb.Address = s.Address;
                supplierFromDb.PhoneNumber = s.PhoneNumber;
                supplierFromDb.Email = s.Email;

                uow.Complete();
                return conv.Convert(supplierFromDb);
            }
        }
    }
}
