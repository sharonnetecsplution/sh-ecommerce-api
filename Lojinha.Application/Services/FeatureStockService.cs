using Lojinha.Application.Interfaces;
using Lojinha.Application.Services.Base;
using Lojinha.Domain.Entities;
using Lojinha.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Application.Services
{
    public class FeatureStockService : BaseService<FeatureStockEntity>, IFeatureStockService
    {
        private readonly IFeatureStockRepository _IFeatureRepository;
        public FeatureStockService(IFeatureStockRepository repository) : base(repository)
        {
            _IFeatureRepository = repository;
        }
    }
}
