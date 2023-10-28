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
    public class ShoesService : BaseService<ShoesEntity>, IShoesService
    {
        private readonly IShoesRepository _IShoesRepository;
        public ShoesService(IShoesRepository repository) : base(repository)
        {
            _IShoesRepository = repository;
        }
    }
}
