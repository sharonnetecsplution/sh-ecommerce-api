using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Domain.Entities
{
    public class StockEntity 
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ProductEntity Product { get; set; }
        public int StoreId { get; set; }   
        public StoreEntity Store { get; set; }
        public IList<FeatureStockEntity> FeatureProduct { get; set; }
        public int AmountTotal { get; set; }
    }
}
