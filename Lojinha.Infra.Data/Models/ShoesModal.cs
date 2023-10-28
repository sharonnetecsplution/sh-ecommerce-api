using Lojinha.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Infra.Data.Models
{
    public class ShoesModal
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Gender { get; set; }
        public string Origin { get; set; }
        public string Brand { get; set; }
        public string Type_of_activity { get; set; }
        public string Technology { get; set; }
        public string Weight { get; set; }
        public int SegmentId{ get; set; }
    }
}
