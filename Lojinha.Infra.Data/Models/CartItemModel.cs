using Lojinha.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Infra.Data.Models
{
    public class CartItemModel
    {
        public int Id { get; set; }
        public int StockId { get; set; }
        public int CarId { get; set; }
        public int Amount { get; set; }
    }
}
