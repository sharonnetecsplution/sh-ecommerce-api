using Lojinha.Domain;
using Lojinha.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Infra.IoC.Outputs
{
    public class ImageOutput
    {
        public int id { get; set; }
        public string name { get; set; }
        public string extensao  { get; set; }
        public string endpoint { get; set; }
        public static ImageOutput CadastroResult(ImageEntity image)
        {
            return new ImageOutput { id = image.Id, name = image.Name, endpoint = image.endpoint , extensao = image.Extensao};
        }
    }
}
