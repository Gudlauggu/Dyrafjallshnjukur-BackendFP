using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface ISupplierRepo
    {
        Supplier Create(Supplier s);

        IEnumerable<Supplier> GetAll();
        Supplier Get(int Id);

        Supplier Delete(int Id);
    }
}
