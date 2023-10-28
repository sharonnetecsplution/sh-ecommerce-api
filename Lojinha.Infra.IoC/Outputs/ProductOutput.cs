using Lojinha.Application.Interfaces;
using Lojinha.Domain;
using Lojinha.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Azure;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Infra.IoC.Outputs
{
    public  class ProductOutput
    {
        public static ProductEdit EditProduct(ProductEntity product)
        {
            ProductEdit prod = new ProductEdit() { 
                id = product.Id, 
                name = product.Name, 
                price = product.Price,
                creat_date = product.Creat_date,
                update_date = product.Update_date
            }; 

            return  prod;
        }
     
        public static IList<ProductResult> ListProduct(IList<ProductEntity> productListEntity)
        {
            IList<ProductResult> element = new List<ProductResult>();

            element = (from p in productListEntity
                       select new ProductResult()
                       {
                           id = p.Id,
                           name = p.Name,
                           price = p.Price,
                           categories = p.Products,
                                  stocks = p.Stocks,
                           description = p.Description,
                           creat_date = p.Creat_date,
                           update_date = p.Update_date,
                       }).ToList();
           


            return element;
        }

        public static ProductResult ProductResult(ProductEntity productListEntity)
        {
            ProductResult element = new ProductResult();

            element.id = productListEntity.Id;
            element.name = productListEntity.Name;
            element.price = productListEntity.Price;
            element.categories = productListEntity.Products;
            element.stocks = productListEntity.Stocks; ;
            element.description = productListEntity.Description;
            element.creat_date = productListEntity.Creat_date;
            element.update_date = productListEntity.Update_date;
    


            return element;
        }
    }
    public class ProductEdit
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public DateTime creat_date { get; set; }
        public DateTime update_date { get; set; }
    }


    public class ProductResult
    {
        public int id { get; set; }
        public string name { get; set; }
        public IList<Category_productEntity> categories { get; set; }
        public IList<StockEntity> stocks { get; set; }
        public decimal price { get; set; }
        public string description { get; set; }
        public DateTime creat_date { get; set; }
        public DateTime update_date { get; set; }
    }


}
