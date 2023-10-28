using Lojinha.Domain.Entities;
using Lojinha.Domain.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Domain.Interfaces
{
    public interface IAccessoryRepository: IBaseRepository<AccessoryEntity>
    {
        IEnumerable<AccessoryEntity> AccessoryGetById(int accessoryId);
    }
}
