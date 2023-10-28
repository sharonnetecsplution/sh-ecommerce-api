using Lojinha.Domain;
using Lojinha.Infra.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Infra.IoC.Mediator
{
    public class Category_productMediator
    {

        public Category_productEntity _Category_productyEntity { get; set; }

        public Category_productMediator()
        {
            _Category_productyEntity = new Category_productEntity();
        }

        public Category_productEntity Cadastro(Category_productModel category_productModel)
        {
            _Category_productyEntity.ProductId = category_productModel.ProductId;
            _Category_productyEntity.CategoryId = category_productModel.CategoryId;
            
            return _Category_productyEntity;
        }
    }
}
