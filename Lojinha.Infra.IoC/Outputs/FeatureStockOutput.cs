using Lojinha.Domain;
using Lojinha.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Infra.IoC.Outputs
{
    public class FeatureStockOutput
    {
        public static FeatureStockCadastro EditFeatureStock(FeatureStockEntity featureStockEntity)
        {
            return new FeatureStockCadastro { 
                id = featureStockEntity.Id,
                colorId = featureStockEntity.ColorId, 
                imageId = featureStockEntity.ImageId, 
                stockId = featureStockEntity.StockId };
        }

        public static IList<FeatureStockList> listFeatureStock(IEnumerable<FeatureStockEntity> FeatureStockEntity)
        {

            var element = (from c in FeatureStockEntity
                           select new FeatureStockList()
                           {
                               id = c.Id,
                               color =c.Color,
                               size = c.Size,
                               image = c.Image,
                               stock = c.Stock,

                           }).ToList();
            return element;
        }
        //
        public static FeatureStockList FeatureStockId( FeatureStockEntity c)
        {

            var element =  new FeatureStockList()
                           {
                               id = c.Id,
                               color = c.Color,
                               size = c.Size,
                               image = c.Image,
                               stock = c.Stock,

                           };
            return element;
        }

    }

    public class FeatureStockCadastro
    {
        public int id { get; set; }
        public int colorId { get; set; }
        public int imageId { get; set; }
        public int stockId { get; set; }
    }
    public class FeatureStockList
    {
        public int id { get; set; }
        public ColorEntity color { get; set; }
        public SizeEntity size { get; set; }
        public ImageEntity image { get; set; }
        public StockEntity stock { get; set; }
    }

}
