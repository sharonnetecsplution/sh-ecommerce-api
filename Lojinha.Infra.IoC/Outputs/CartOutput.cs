using Lojinha.Domain;
using Lojinha.Domain.Entities;
using Lojinha.Infra.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Infra.IoC.Outputs
{
    public class CartOutput
    {
        public static CartEdit EditCart(CartEntity cartEntity)
        {
            return new CartEdit { id = cartEntity.Id, amount = cartEntity.Amount, value_Total = cartEntity.Value_Total  };
        }

        public static IList<CartList> listAllCart(IEnumerable<CartEntity> cartEntity)
        {

            var element = (from c in cartEntity
                           select new CartList()
                           {
                              id = c.Id,
                              amount = c.Amount,
                              value_Total = c.Value_Total, 
                              itens = (from i  in c.Itens  select new { i.Id, i.StockId,i.CarId }).ToList()

                           }).ToList();
            return element;
        }

    }

    public class CartEdit
    {
        public int id { get; set; }
        public int amount { get; set; }
        public decimal value_Total { get; set; }
    }
    public class CartList
    {
        public int id { get; set; }
        public int amount { get; set; }
        public decimal value_Total { get; set; }
        public dynamic itens { get; set; }
    }

}
