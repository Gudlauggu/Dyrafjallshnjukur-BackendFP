using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    class ItemRepo : IItemRepo
    {
        Context.Context context;

        public ItemRepo(Context.Context context)
        {
            this.context = context;
        }

        public Item Create(Item i)
        {
            this.context.Item.Add(i);

            return i;
        }

        public Item Delete(int Id)
        {
            var i = Get(Id);
            this.context.Item.Remove(i);

            return i;
        }

        public Item Get(int Id)
        {
            return this.context.Item.FirstOrDefault(x => x.Id == Id);
        }

        public IEnumerable<Item> GetAll()
        {
            return this.context.Item.ToList();
        }

        public IEnumerable<Item> GetAllById(List<int> ids)
        {
            if (ids == null) return null;

            return this.context.Item.Where(i => ids.Contains(i.Id));

        }
    }
}
