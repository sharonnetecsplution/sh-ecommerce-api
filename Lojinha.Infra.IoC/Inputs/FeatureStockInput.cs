using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Infra.IoC.Inputs
{
    public class FeatureStockInput
    {
        public int ColorId { get; set; }
        public int StockId { get; set; }
        public int ImageId { get; set; }
        public int SizeId { get; set; }
        public int amount { get; set; }

    }
}
