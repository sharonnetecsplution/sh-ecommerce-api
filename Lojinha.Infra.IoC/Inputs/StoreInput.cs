using Lojinha.Domain.Entities;
using Lojinha.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Infra.IoC.Inputs
{
    public class StoreInput
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public int AddressId { get; set; }
        public int CompanyId { get; set; }
        public int SegmentId { get; set; }

    }
}
