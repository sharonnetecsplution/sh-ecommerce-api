using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Domain.Entities
{
    public class ShoesEntity
    {
        public int Id { get; set; }
        public int SegmentId { get; set; }
        public SegmentEntity Segment { get; set; }
        public string Model { get; set; }
        public string Gender { get; set; }
        public string Origin { get; set; }
        public string Brand { get; set; }
        public string Type_of_activity { get; set; }
        public string Technology { get; set; }
        public string Weight { get; set; }

    }
}
