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
    public class AccessoryService : BaseService<AccessoryEntity>, IAccessoryService
    {
        private readonly IAccessoryRepository _IAcessoryRepository;
        public AccessoryService(IAccessoryRepository repository) : base(repository)
        {
            _IAcessoryRepository = repository;
        }

        public IEnumerable<AccessoryEntity> AccessoryGetById(int accessoryId)
        {
           return _IAcessoryRepository.AccessoryGetById(accessoryId);
        }
    }
}
