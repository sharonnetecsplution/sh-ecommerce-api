using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Application.Helpers.Models
{
    public class UpdateBlobStorageModel
    {
        public string  fileName { get; set; }
        public string endpoint { get; set; }
        public string extensao { get; set; }
    }
}
