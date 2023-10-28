using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Domain.Entities
{
    public class ClothingEntity
    {
        public int Id { get; set; }
        public int SegmentId { get; set; }
        public SegmentEntity Segment { get; set; }
        public string Composition { get; set; }
        public string Made_by { get; set;}

        public string Brand { get; set; }
        public string Origin{ get; set; }
    }
}
