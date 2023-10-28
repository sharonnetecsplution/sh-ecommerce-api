using Lojinha.Application.Interfaces;
using Lojinha.Application.Services.Base;
using Lojinha.Domain.Entities;
using Lojinha.Domain.Interfaces;
using Lojinha.Domain.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Application.Services
{
    public class StoreService : BaseService<StoreEntity>, IStoreService
    {
        private readonly IStoreRepository _IStoreRepository;
        public StoreService(IStoreRepository repository) : base(repository)
        {
            _IStoreRepository = repository;
        }

        public Task<List<StoreEntity>> GetStoreCompanyId(int companyId)
        {
            return _IStoreRepository.GetStoreCompanyId(companyId);
        }
    }
}
