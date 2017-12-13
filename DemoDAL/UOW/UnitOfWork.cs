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
        public IPubRepo PubRepo { get; internal set; }
        public IOrderRepo OrderRepo { get; internal set; }
        public IProfileRepo ProfileRepo { get; internal set; }
        public IUserRepo UserRepo { get; internal set; }


        private Context.Context context;

        public UnitOfWork()
        {
            context = new Context.Context();
            //context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            ItemRepo = new ItemRepo(context);
            ItemTypeRepo = new ItemTypeRepo(context);
            PubRepo = new PubRepo(context);
            OrderRepo = new OrderRepo(context);
            ProfileRepo = new ProfileRepo(context);
            UserRepo = new UserRepo(context);
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
