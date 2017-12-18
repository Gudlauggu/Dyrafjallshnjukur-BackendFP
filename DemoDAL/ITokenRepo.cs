using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    interface ITokenRepo<T>
    {
        IEnumerable<T> GetAll();
        T Get(long id);
        void Add(T entity);
        void Edit(T entity);
        void Remove(long id);
    }
}
