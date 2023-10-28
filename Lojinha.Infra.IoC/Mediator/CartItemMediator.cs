using Lojinha.Domain;
using Lojinha.Domain.Entities;
using Lojinha.Infra.Data.Models;
using Lojinha.Infra.IoC.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Infra.IoC.Mediator
{
    public class CartItemMediator
    {
        public CartItemEntity  _Cart_itemEntity { get; set; }
        public CartItemMediator()
        {
            _Cart_itemEntity = new CartItemEntity();
            
        }

        public CartItemEntity ConvertModelInEntity(CartItemModel cart_item)
        {
            _Cart_itemEntity.CarId = cart_item.CarId;
            _Cart_itemEntity.StockId = cart_item.StockId;
            _Cart_itemEntity.Id = cart_item.Id;
            _Cart_itemEntity.Amount = cart_item.Amount;  


            return _Cart_itemEntity;
        }

        public CartItemEntity ConvertInputInEntity(CartItemInput cart_item)
        {

            _Cart_itemEntity.CarId = cart_item.CarId;
            _Cart_itemEntity.StockId = cart_item.StockId;

            _Cart_itemEntity.Amount = cart_item.Amount;



            return _Cart_itemEntity;
        }

     
    }
}
