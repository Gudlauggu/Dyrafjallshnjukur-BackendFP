using BLL.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface IPubService
    {
        PubBO Create(PubBO p);

        List<PubBO> GetAll();
        PubBO Get(int Id);

        PubBO Update(PubBO p);

        PubBO Delete(int Id);
    }
}
