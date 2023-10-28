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
    public class CartService : BaseService<CartEntity>, ICartService
    {
        private readonly ICartRepository _CartRepository;
        public CartService(ICartRepository repository) : base(repository)
        {
            _CartRepository = repository;
        }

        public IEnumerable<CartEntity> CartAll()
        {
            return _CartRepository.CartAll().ToList();
        }

        public CartEntity CartById(int id)
        {
            return _CartRepository.CartById(id);
        }
    }
}
