using Lojinha.Domain.Entities;
using Lojinha.Infra.Data.Context;
using Lojinha.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Domain.Interfaces
{
    public class StockRepository : BaseRepository<StockEntity>, IStockRepository
    {
        public StockRepository(ApplicationDbContext context) : base(context)
        {
        }

    
        public override Task<List<StockEntity>> GetAllLisAsync()
        {
            return DbSet.Include(c => c.FeatureProduct).Include(p => p.Product).Include(s => s.Store).AsNoTracking().ToListAsync();
        }
        public virtual StockEntity Get(int id)
        {
            return DbSet.Include(c => c.FeatureProduct).Include(p => p.Product).Include(s => s.Store).Where(w => w.Id == id).ToList().First();
        }

    }
}
