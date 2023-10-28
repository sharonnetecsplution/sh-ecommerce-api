using Lojinha.Domain.Entities;
using Lojinha.Domain.Interfaces;
using Lojinha.Infra.Data.Context;
using Lojinha.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Amazon.S3.Util.S3EventNotification;

namespace Lojinha.Infra.Data.Repositories
{
    public class CompanyRepository : BaseRepository<CompanyEntity>, ICompanyRepository
    {
        StoreRepository _storeRepository;
        public CompanyRepository(ApplicationDbContext context):base(context)
        {
            _storeRepository = new StoreRepository(context);
        }

        public virtual async Task<List<CompanyEntity>> GetAllLisAsync()
        {
            var result = DbSet.AsNoTracking().ToListAsync();
            foreach (var item in result.Result)
            {
                item.Stores = await _storeRepository.GetStoreCompanyId(item.Id);
            }

            return result.Result;
        }


    }
}
