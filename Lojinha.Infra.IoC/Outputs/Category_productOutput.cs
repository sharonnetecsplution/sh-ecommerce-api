using Lojinha.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Infra.IoC.Outputs
{
    public  class Category_productOutput
    {
        public int id { get; set; }
        public int categoriaId { get; set; }
        public int productId { get; set; }

        public static Category_productOutput CadastroResult(Category_productEntity category_productEntity)
        {
            return new Category_productOutput
            {
                id = category_productEntity.Id,
                productId = category_productEntity.ProductId,
                categoriaId = category_productEntity.CategoryId

            };
        }
    }
}
