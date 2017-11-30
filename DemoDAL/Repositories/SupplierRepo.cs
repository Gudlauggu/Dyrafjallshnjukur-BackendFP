using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using System.Linq;

namespace DAL.Repositories
{
    class SupplierRepo : ISupplierRepo
    {
        Context.Context context;

        public SupplierRepo(Context.Context context)
        {
            this.context = context;
        }

        public Supplier Create(Supplier s)
        {
            this.context.Supplier.Add(s);
            return s;
        }

        public Supplier Delete(int Id)
        {
            var s = Get(Id);
            this.context.Supplier.Remove(s);
            return s;
        }

        public Supplier Get(int Id)
        {
            return this.context.Supplier.FirstOrDefault(x => x.Id == Id);
        }

        public IEnumerable<Supplier> GetAll()
        {
            return this.context.Supplier.ToList();
        }
    }
}
