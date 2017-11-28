using BLL.BusinessObjects;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Converters
{
    class SupplierConverter
    {
        internal Supplier Convert(SupplierBO s)
        {
            if (s == null) { return null; }
            return new Supplier()
            {
                Id = s.Id,
                Name = s.Name,
                Address = s.Address,
                PhoneNumber = s.PhoneNumber,
                Email = s.Email
            };
        }

        internal SupplierBO Convert(Supplier s)
        {
            if (s == null) { return null; }
            return new SupplierBO()
            {
                Id = s.Id,
                Name = s.Name,
                Address = s.Address,
                PhoneNumber = s.PhoneNumber,
                Email = s.Email
            };
        }
    }
}
