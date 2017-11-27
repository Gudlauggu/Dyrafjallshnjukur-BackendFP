using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    class ItemTypeRepo : IItemTypeRepo
    {
        Context.Context context;

        public ItemTypeRepo(Context.Context context)
        {
            this.context = context;
        }

        public ItemType Create(ItemType i)
        {
            this.context.ItemType.Add(i);

            return i;
        }

        public ItemType Delete(int Id)
        {
            var i = Get(Id);
            this.context.ItemType.Remove(i);

            return i;
        }

        public ItemType Get(int Id)
        {
            return this.context.ItemType.FirstOrDefault(x => x.Id == Id);
        }

        public List<ItemType> GetAll()
        {
            return this.context.ItemType.ToList();
        }
    }
}
