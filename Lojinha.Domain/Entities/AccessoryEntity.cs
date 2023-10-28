using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Domain.Entities
{
    public class AccessoryEntity 
    {
        public int Id { get; set; }
        public string Conservacao { get; set; }
        public string Embalagem { get; set; }
        public string Made_by { get; set; }
        public string Brand { get; set; }
        public int SegmentId { get; set; }
        public SegmentEntity Segment { get; set; }


    }
}
