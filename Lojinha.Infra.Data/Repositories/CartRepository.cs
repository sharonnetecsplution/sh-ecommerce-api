using Lojinha.Infra.Data.Context;
using Lojinha.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Domain.Interfaces
{
    public class CartRepository : BaseRepository<CartEntity>, ICartRepository
    {
        public CartRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<CartEntity> CartAll()
        {
            return DbSet.Include(item => item.Itens).AsNoTracking();
        }

        public CartEntity CartById(int id)
        {
            return DbSet.Include(i => i.Itens).Where(cart => cart.Id == id).FirstOrDefault();
        }
    }
}
