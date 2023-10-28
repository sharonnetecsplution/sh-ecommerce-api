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
    public class ClothingService : BaseService<ClothingEntity>, IClothingService
    {
        private readonly IClothingRepository _IClothingRepository;
        public ClothingService(IClothingRepository repository) : base(repository)
        {
            _IClothingRepository = repository;
        }
    }
}
