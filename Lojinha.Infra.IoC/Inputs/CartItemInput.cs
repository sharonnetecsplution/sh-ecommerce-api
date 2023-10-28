using Lojinha.Domain;
using Lojinha.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Infra.IoC.Inputs
{
    public class CartItemInput
    {
        public int StockId { get; set; }
        public int CarId { get; set; }
        public int Amount { get; set; }
    }
}
