using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        public IItemRepo ItemRepo { get; internal set; }
        public IItemTypeRepo ItemTypeRepo { get; internal set; }
       
        private Context.Context context;

        public UnitOfWork()
        {
            context = new Context.Context();
            context.Database.EnsureCreated();
            ItemRepo = new ItemRepo(context);
            ItemTypeRepo = new ItemTypeRepo(context);
        }


        public int Complete()
        {
            //The number of objects written to the underlying database.
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
