using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface IBLLFacade
    {
        IUserService UserService { get; }

        IOrderService OrderService { get; }

        IItemService ItemService { get; }

        IItemTypeService ItemTypeService { get; }

        IProfileService ProfileService { get; }

        IPubService PubService { get; }
    }
}
