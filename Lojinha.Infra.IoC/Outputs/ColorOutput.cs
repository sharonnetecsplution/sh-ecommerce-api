using Lojinha.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Infra.IoC.Outputs
{
    public class ColorOutput
    {
       
        public static ColorEdit EditColor(ColorEntity colorEntity)
        {
            return new ColorEdit { id = colorEntity.Id, name = colorEntity.Name };
        }

        public static IList<ColorList> listAllColor(IList<ColorEntity> colorEntity)
        {

          var element = (from c in colorEntity
                          select new ColorList()
                          {
                              id = c.Id,
                              name = c.Name
                          }).ToList();
            return element;
        }

    

    }
    public class ColorEdit
    {
        public int id { get; set; }
        public string name { get; set; }

    }
    public class ColorList
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
