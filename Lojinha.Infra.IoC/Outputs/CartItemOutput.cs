using Lojinha.Domain.Entities;
using Lojinha.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Infra.IoC.Outputs
{
    public class CartItemOutput
    {
        public static CartItemEdit EditCartItem(CartItemEntity CartItemEntity)
        {
            return new CartItemEdit
            {
                id = CartItemEntity.Id,
                carId= CartItemEntity.CarId,
                stockId = CartItemEntity.StockId,
                amount = CartItemEntity.Amount
            };
        }

        public static IList<CartItemlist> ListCartItem(IEnumerable<CartItemEntity> CartItemEntity)
        {


            var list = (from s in CartItemEntity
                        select new CartItemlist()
                        {
                            id = s.Id,
                        });


            return new List<CartItemlist>();
        }
    }
    public class CartItemEdit
    {
        public int id { get; set; }
        public int stockId { get; set;}
        public int carId { get; set; }
        public int amount { get; set; }
    }

    public class CartItemlist
    {
        public int id { get; set; }
        public StockEntity? stock { get; set; }
        public CartEntity? car { get; set; }
        public int amount { get; set; }
    }
}
