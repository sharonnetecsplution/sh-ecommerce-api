using Lojinha.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lojinha.Infra.IoC.Outputs
{
    public class CatergoryOutput
    {
        public static CategoryCadastro CadastroResult(CategoryEntity categoryEntity)
        {
            return new CategoryCadastro { id = categoryEntity.Id, name = categoryEntity.Name };
        }
        public static IList<CategoryList> CategoryList(IEnumerable<CategoryEntity> categoryEntity)
        {
            var element = (from c in categoryEntity
                       select new CategoryList()
                       {
                           id = c.Id,
                           name = c.Name,
                           products = (from cp in c.Categories select new { cp.ProductId })

                       }).ToList();

            return  element ;
        }

        public static CategoryList CategoryId(CategoryEntity categoryEntity)
        {
            var element =  new CategoryList()
                           {
                               id = categoryEntity.Id,
                               name = categoryEntity.Name,
                               products = categoryEntity.Categories

            };

            return element;
        }
    }

    public  class CategoryCadastro
    {
        public  int id { get; set; } 
        public string name { get; set; }
    }

    public class CategoryList
    {
        public int id { get; set; }
        public string name { get; set; }
        public dynamic products { get; set; }
    }
}
