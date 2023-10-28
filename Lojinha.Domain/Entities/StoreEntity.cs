using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Domain.Entities
{
    public class StoreEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AddressId { get; set; }
        public AddressEntity  Address { get; set; }
        public IList<StockEntity> Stocks { get; set; }
        public int CompanyId { get; set; }
        public CompanyEntity Company { get; set; }
        public int SegmentId { get; set; }
        public SegmentEntity Segment { get; set; }

    }
}
