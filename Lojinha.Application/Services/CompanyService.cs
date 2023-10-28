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
    public class CompanyService : BaseService<CompanyEntity>, ICompanyService
    {
        private readonly ICompanyRepository _ICompanyRepository;
        public CompanyService(ICompanyRepository repository) : base(repository)
        {
            _ICompanyRepository = repository;
        }
    }
}
