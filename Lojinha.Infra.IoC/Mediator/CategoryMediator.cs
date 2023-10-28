using Lojinha.Application.Interfaces;
using Lojinha.Domain;
using Lojinha.Infra.Data.Models;
using Lojinha.Infra.IoC.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Infra.IoC.Mediator
{
    public class CategoryMediator
    {
        public CategoryEntity _CategoryEntity { get; set; }

        public CategoryMediator()
        {
            _CategoryEntity = new CategoryEntity();
        }

        public CategoryEntity CategoryConvertInputInEntity(CategoryInput categoryModel)
        {
          
            _CategoryEntity.Name = categoryModel.Name;


            return _CategoryEntity;
        }

        public CategoryEntity CategoryConvertModelInEntity(CategoryModel categoryModel)
        {
            _CategoryEntity.Id = categoryModel.Id;
            _CategoryEntity.Name = categoryModel.Name;


            return _CategoryEntity;
        }
    }
}
