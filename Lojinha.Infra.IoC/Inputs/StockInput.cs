using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Infra.IoC.Inputs
{
    public class StockInput
    {

        public int ProductId { get; set; }

        public int StoreId { get; set; }
        public int Amount { get; set; }
    }
}
