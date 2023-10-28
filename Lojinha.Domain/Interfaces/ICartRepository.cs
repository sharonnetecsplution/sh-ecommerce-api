using Lojinha.Domain.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Domain.Interfaces
{
    public interface ICartRepository: IBaseRepository<CartEntity>
    {
        IEnumerable<CartEntity> CartAll();
        CartEntity CartById(int id);

    }
}
