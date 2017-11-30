using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using System.Linq;

namespace DAL.Repositories
{
    class PubRepo : IPubRepo
    {
        Context.Context context;

        public PubRepo(Context.Context context)
        {
            this.context = context;
        }

        public Pub Create(Pub p)
        {
            this.context.Pub.Add(p);
            return p;
        }

        public Pub Delete(int Id)
        {
            var p = Get(Id);
            this.context.Pub.Remove(p);
            return p;
        }

        public Pub Get(int Id)
        {
            return this.context.Pub.FirstOrDefault(x => x.Id == Id);
        }

        public IEnumerable<Pub> GetAll()
        {
            return this.context.Pub.ToList();
        }
    }
}
