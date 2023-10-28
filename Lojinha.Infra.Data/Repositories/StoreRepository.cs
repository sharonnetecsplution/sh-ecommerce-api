using Lojinha.Domain.Entities;
using Lojinha.Domain.Interfaces;
using Lojinha.Infra.Data.Context;
using Lojinha.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Infra.Data.Repositories
{
    public class StoreRepository : BaseRepository<StoreEntity>, IStoreRepository
    {
        public StoreRepository(ApplicationDbContext context) : base(context)
        {
            
        }
        
        public override Task<List<StoreEntity>> GetAllLisAsync()
        {
            var result = DbSet.Include(a => a.Address).Include(s=> s.Stocks).Include(c => c.Company).Include(s => s.Segment).AsNoTracking().ToListAsync();

            return result;
        }

        public Task<List<StoreEntity>> GetStoreCompanyId(int companyId)
        {
            var result = DbSet.Include(a => a.Address).Include(s => s.Stocks).Include(c => c.Company).Include(s => s.Segment).Where(c => c.CompanyId == companyId).AsNoTracking().ToListAsync();

            return result;
        }

    }
}
