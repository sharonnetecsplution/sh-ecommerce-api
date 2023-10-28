using Lojinha.Application.Interfaces.Base;
using Lojinha.Domain;
using Lojinha.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Application.Interfaces
{
    public interface ICategory_productService : IBaseService<Category_productEntity>
    {

        IEnumerable<Category_productEntity> CategoryGetAll();
        IEnumerable<Category_productEntity> CategoryGetById(int id);
        Task<IEnumerable<Category_productEntity>> ProdutoGetByIdAsync(int produtoId);

    }
}
