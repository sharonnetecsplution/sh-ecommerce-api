﻿using Lojinha.Application.Interfaces.Base;
using Lojinha.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Application.Interfaces
{
    public interface IAccessoryService : IBaseService<AccessoryEntity>
    {
        IEnumerable<AccessoryEntity> AccessoryGetById(int accessoryId);
    }
}
