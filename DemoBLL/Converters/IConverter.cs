using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Converters
{
    public interface IConverter<Entity, BO>
    {
        Entity Convert(BO bo);

        BO Convert(Entity ent);
    }
}
