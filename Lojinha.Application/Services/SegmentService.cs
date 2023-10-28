using Lojinha.Application.Interfaces;
using Lojinha.Application.Services.Base;
using Lojinha.Domain;
using Lojinha.Domain.Interfaces;
using Lojinha.Domain.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Application.Services
{
    public class SegmentService : BaseService<SegmentEntity>, ISegmentService
    {
        private readonly ISegmentRepository _SegmentRepository;
        public SegmentService(ISegmentRepository repository) : base(repository)
        {
            _SegmentRepository = repository;
        }
    }
}
