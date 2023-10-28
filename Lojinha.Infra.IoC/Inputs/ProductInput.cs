using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Infra.IoC.Inputs
{
    public class ProductInput
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime Creat_date { get; set; }
        public DateTime Update_date { get; set; }
    }
}
