using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Infra.IoC.Outputs
{
    public class TokenOutput
    {
        public  bool Status{ get; set; }
        public string Token { get; set; }
        public DateTime dataExpiracao { get; set; }

    }
}
