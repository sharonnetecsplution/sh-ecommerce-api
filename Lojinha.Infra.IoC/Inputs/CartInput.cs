using Lojinha.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Infra.IoC.Inputs
{
    public class CartInput
    {
        public int Amount { get; set; }
        public decimal Value_Total { get; set; }
    }
}
