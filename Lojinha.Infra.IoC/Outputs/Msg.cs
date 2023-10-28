using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Infra.IoC.Outputs
{
    public class Error
    {
        public int code { get; set; }
        public string message { get; set; }
    }
    public class Sucess
    {
        public string message { get; set; }
        public dynamic result { get; set; }
    }
}
