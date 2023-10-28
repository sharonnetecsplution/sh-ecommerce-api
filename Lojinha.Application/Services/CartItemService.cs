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
    public class CartItemService : BaseService<CartItemEntity>, ICartItemService
    {
        private readonly ICartItemRepository _Cart_itemRepository;
        public CartItemService(ICartItemRepository repository) : base(repository)
        {
            _Cart_itemRepository = repository;
        }
    }
}
