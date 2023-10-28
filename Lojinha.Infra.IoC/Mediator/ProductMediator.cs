using Lojinha.Application.Interfaces;
using Lojinha.Application.Services;
using Lojinha.Domain;
using Lojinha.Infra.Data.Models;
using Lojinha.Infra.IoC.Inputs;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Infra.Ioc
{
    public class ProductMediator
    {
        public ProductEntity _ProductEntity { get; set; }



        public ProductMediator()
        {
            _ProductEntity = new ProductEntity();


        }

        public ProductEntity ConvertModelInEntity(ProductModel productModel)
        {


            _ProductEntity.Id = productModel.Id;
            _ProductEntity.Name = productModel.Name;
            _ProductEntity.Price = productModel.Price;
            _ProductEntity.Description = productModel.Description;
            _ProductEntity.Creat_date = DateTime.Now.ToUniversalTime();
            _ProductEntity.Update_date = DateTime.Now.ToUniversalTime();

            return _ProductEntity;
        }

        public ProductEntity ConvertInputInEntity(ProductInput product)
        {



            _ProductEntity.Name = product.Name;
            _ProductEntity.Price = product.Price;
            _ProductEntity.Description = product.Description;
            _ProductEntity.Creat_date = DateTime.Now.ToUniversalTime();
            _ProductEntity.Update_date = DateTime.Now.ToUniversalTime();
            return _ProductEntity;
        }
    }

  
}
