using Lojinha.Application.Interfaces;
using Lojinha.Application.Interfaces.Base;
using Lojinha.Application.Services.Base;
using Lojinha.Domain;
using Lojinha.Domain.Interfaces;
using Lojinha.Domain.Interfaces.Base;
using System.Linq.Expressions;


namespace Lojinha.Application.Services
{
    public class ProductService : BaseService<ProductEntity>, IProductService
    {
        private readonly IProductRepository _ProductRepository;
        public ProductService(IProductRepository repository) : base(repository)
        {
            _ProductRepository = repository;
        }

      
    }
}
