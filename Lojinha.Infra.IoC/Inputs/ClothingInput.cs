using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Infra.IoC.Inputs
{
    public class ClothingInput
    {
        public string Composition { get; set; }
        public string Made_by { get; set; }

        public string Brand { get; set; }
        public string Origin { get; set; }

        public int SegmentId { get; set; }
    }
}
