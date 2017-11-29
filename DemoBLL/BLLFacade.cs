using BLL;
using BLL.Services;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;


namespace BLL
{
    public class BLLFacade
    {
        public IItemService ItemService
        {
            get { return new ItemService(new DALFacade()); }
        }

        public IItemTypeService ItemTypeService
        {
            get { return new ItemTypeService(new DALFacade()); }
        }

        public IPubService PubService
        {
            get { return new PubService(new DALFacade()); }
        }

        public ISupplierService SupplierService
        {
            get { return new SupplierService(new DALFacade()); }
        }
        public IOrderService OrderService
        {
            get { return new OrderService(new DALFacade());  }
        }
    }
}
