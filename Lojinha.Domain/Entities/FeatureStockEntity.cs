using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Domain.Entities
{
    public class FeatureStockEntity
    {
        public int Id { get; set; }
        public int ColorId { get; set; }
        public ColorEntity Color { get; set; }
        public int SizeId { get; set; }
        public SizeEntity Size { get; set; }
        public int ImageId { get; set; }
        public ImageEntity Image { get; set; }
        public int StockId { get; set; }
        public StockEntity Stock { get; set; }
        public int amount { get; set; }
    }
}
