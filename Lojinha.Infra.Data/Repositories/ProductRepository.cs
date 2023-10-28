using Lojinha.Domain;
using Lojinha.Domain.Interfaces;
using Lojinha.Infra.Data.Context;
using Lojinha.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Infra.Data.Repositories
{
    public class ProductRepository : BaseRepository<ProductEntity>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context): base(context)
        {

        }

        
        public override IEnumerable<ProductEntity> GetAll()
        {
            return DbSet.Include(s => s.Products).Include(s => s.Stocks).AsNoTracking();
        }

    }
}
