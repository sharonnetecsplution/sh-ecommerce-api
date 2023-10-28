using Lojinha.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Infra.IoC.Outputs
{
    public class SizeOutput
    {

        public static SizeEdit EditSize(SizeEntity SizeEntity)
        {

            return new SizeEdit { id = SizeEntity.Id, name = SizeEntity.Name };
        }

        public static IList<SizeList> ListSize(IEnumerable<SizeEntity> SizeEntity)
        {
            dynamic list = (from s in SizeEntity
                            select new SizeEntity()
                            {
                                Id = s.Id,
                                Name = s.Name,
                            });

            return list;
        }
    }

    public class SizeEdit
    {
        public int id { get; set; }
        public string name { get; set; }
    }
    public class SizeList
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
