using Lojinha.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Infra.Data.Models
{
    public class AccessoryModel
    {
        public int Id { get; set; }
        public string Conservacao { get; set; }
        public string Embalagem { get; set; }
        public string Made_by { get; set; }
        public string Brand { get; set; }
        public int segmentId { get; set; }
    }
}
