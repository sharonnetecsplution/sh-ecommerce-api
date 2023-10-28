using Lojinha.Domain;
using Lojinha.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Infra.IoC.Outputs
{
    public class StockOutput
    {

        public static StockEdit EditStock(StockEntity stockEntity)
        {
            return new StockEdit
            {
                id = stockEntity.Id,
                productId = stockEntity.ProductId,
                storeId = stockEntity.StoreId,
                AmountTotal = stockEntity.AmountTotal
            };
        }

        public static IList<Stocklist> ListStock(IEnumerable<StockEntity> stockEntity)
        {


            IList<Stocklist> list = (from s in stockEntity
                                    select new Stocklist()
            {
                                        id = s.Id,
                                        product=s.Product,
                                        featureProduct =s.FeatureProduct,
                                        store  = s.Store,
                                        AmountTotal = s.AmountTotal,
            }).ToList();


            return list;
        }

        public static Stocklist ListStock(StockEntity s)
        {


            Stocklist list =  new Stocklist()
                                     {
                                         id = s.Id,
                                        featureProduct=s.FeatureProduct,
                                         product = s.Product,
                                         store = s.Store,
                AmountTotal = s.AmountTotal,
                                     };


            return list;
        }
    }
    public class StockEdit
    {
        public int id { get; set; }
        public int productId { get; set; }
        public int storeId { get; set; }
        public int colorId { get; set; }
        public int AmountTotal { get; set; }
    }

    public class Stocklist
    {
        public int id { get; set; }
        public ProductEntity product { get; set; }
        public IList<FeatureStockEntity> featureProduct { get; set; }
        public StoreEntity store { get; set; }
        public int AmountTotal { get; set; }
    }
}
