using Lojinha.Domain.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Domain.Interfaces
{
    public interface ICategory_productRepository : IBaseRepository<Category_productEntity>
    {
        IEnumerable<Category_productEntity> CategoryGetAll();
        IEnumerable<Category_productEntity> CategoryGetById(int id);
        Task<IEnumerable<Category_productEntity>> ProdutoGetById(int produtoId);
    }
}
