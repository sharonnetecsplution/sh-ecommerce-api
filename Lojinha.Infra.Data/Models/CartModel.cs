using Lojinha.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Infra.Data.Models
{
    public class CartModel
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public decimal Value_Total { get; set; }
        public List<CartItemModel> Itens { get; set; }
    }
}
