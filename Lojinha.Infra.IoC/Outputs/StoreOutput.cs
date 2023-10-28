using Lojinha.Domain;
using Lojinha.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Infra.IoC.Outputs
{
    public class StoreOutput
    {
        public static StoreCadastro EditStore(StoreEntity storeEntity)
        {
            return new StoreCadastro { id = storeEntity.Id, name = storeEntity.Name, addressId = storeEntity.AddressId, companyId = storeEntity.CompanyId, segmentId = storeEntity.SegmentId};
        }

        public static IList<StoreList> listStore(IEnumerable<StoreEntity> storeEntity)
        {

            var element = (from c in storeEntity
                           select new StoreList()
                           {
                               id = c.Id,
                               name = c.Name,
                               description  = c.Description,
                               address = c.Address,
                               stocks = c.Stocks == null? null: (from stock in c.Stocks select new { stock.Product,stock.FeatureProduct,stock.ProductId,stock.Id, stock.AmountTotal }) ,
                               company = c.Company == null ? null : new  { c.Company.Id, c.Company.Name},
                               segment = c.Segment == null ? null : new {c.SegmentId, c.Segment.Name},


                           }).ToList();
            return element;
        }

    }

    public class StoreCadastro
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int addressId { get; set; }
        public int companyId { get; set; }
        public int segmentId { get; set; }

    }
    public class StoreList
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public AddressEntity address { get; set; }
        public dynamic stocks { get; set; }
        public dynamic company { get; set; }
        public dynamic segment { get; set; }
    }
}
