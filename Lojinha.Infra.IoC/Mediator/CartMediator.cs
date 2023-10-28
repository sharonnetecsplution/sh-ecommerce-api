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
    public class CartMediator
    {
        public CartEntity _CartEntity { get; set; }
        public CartItemMediator _Cart_itemMediator { get; set; }
        public CartMediator()
        {
            _CartEntity = new CartEntity();
        }


        public CartEntity ConvertModelInEntity(CartModel cart)
        {
            _CartEntity.Value_Total = cart.Value_Total;
            _CartEntity.Id = cart.Id;
        
            


            return _CartEntity;
        }
        public CartEntity ConvertInputInEntity(CartInput cartEntity)
        {

            _CartEntity.Value_Total = cartEntity.Value_Total;
            _CartEntity.Amount = cartEntity.Amount;


            return _CartEntity;
        }


    }
}
