using Lojinha.Domain.Entities;
using Lojinha.Domain.Interfaces;
using Lojinha.Infra.Data.Context;
using Lojinha.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Infra.Data.Repositories
{
    public class FeatureStockRepository : BaseRepository<FeatureStockEntity>, IFeatureStockRepository
    {
        public FeatureStockRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override Task<List<FeatureStockEntity>> GetAllLisAsync()
        {
            var result = DbSet.Include(c => c.Color).Include(s => s.Size).Include(i => i.Image).Include(s => s.Stock).AsNoTracking().ToListAsync();

            return result;
        }
    }
}
