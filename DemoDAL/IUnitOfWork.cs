using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IItemRepo ItemRepo { get; }

        int Complete();
    }
}
