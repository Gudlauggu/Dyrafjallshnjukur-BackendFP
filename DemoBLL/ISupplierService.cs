using BLL.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface ISupplierService
    {
        SupplierBO Create(SupplierBO s);

        List<SupplierBO> GetAll();
        SupplierBO Get(int Id);

        SupplierBO Update(SupplierBO s);

        SupplierBO Delete(int Id);
    }
}
