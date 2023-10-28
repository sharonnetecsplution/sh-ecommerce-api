using Lojinha.Application.Interfaces;
using Lojinha.Application.Services.Base;
using Lojinha.Domain;
using Lojinha.Domain.Interfaces;
using Lojinha.Domain.Interfaces.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Application.Services
{
    public class Category_productService : BaseService<Category_productEntity>, ICategory_productService
    {
        private readonly ICategory_productRepository _Category_productRepository;
        
        public Category_productService(ICategory_productRepository repository) : base(repository)
        {
            _Category_productRepository = repository;
        }

        public IEnumerable<Category_productEntity> CategoryGetAll()
        {
            var entities = _Category_productRepository.CategoryGetAll();
            return entities;
        }

        public IEnumerable<Category_productEntity> CategoryGetById(int categoryId)
        {
            var entities = _Category_productRepository.CategoryGetById(categoryId);
            return entities;
        }

        public async Task<IEnumerable<Category_productEntity>> ProdutoGetByIdAsync(int produtoId)
        {
            var entities = await _Category_productRepository.ProdutoGetById(produtoId);
            return entities;
        }
    }
}
