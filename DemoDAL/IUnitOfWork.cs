using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IItemRepo ItemRepo { get; }
        IItemTypeRepo ItemTypeRepo { get; }
        IPubRepo PubRepo { get; }
        ISupplierRepo SupplierRepo { get; }


        int Complete();
    }
}
