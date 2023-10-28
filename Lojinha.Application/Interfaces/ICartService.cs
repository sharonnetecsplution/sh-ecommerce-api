using Lojinha.Application.Interfaces.Base;
using Lojinha.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Application.Interfaces
{
    public interface ICartService : IBaseService<CartEntity>
    {
        IEnumerable<CartEntity> CartAll();
        CartEntity CartById(int id);

    }
}
