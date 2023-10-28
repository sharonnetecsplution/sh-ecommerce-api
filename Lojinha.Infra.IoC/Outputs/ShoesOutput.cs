using Lojinha.Domain;
using Lojinha.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Infra.IoC.Outputs
{
    public class ShoesOutput
    {
        public static ShoesCadastro EditShoes(ShoesEntity ShoesEntity)
        {
            return new ShoesCadastro { id = ShoesEntity.Id, brand = ShoesEntity.Brand, segmentId = ShoesEntity.SegmentId };
        }

        public static IList<ShoesList> listShoes(IEnumerable<ShoesEntity> ShoesEntity)
        {

            var element = (from s in ShoesEntity
                           select new ShoesList()
                           {
                             id = s.Id,
                             model = s.Model,
                             gender = s.Gender,
                             origin = s.Origin,
                             brand = s.Brand,
                             technology = s.Technology,
                             weight = s.Weight,
                             segment = new
                             {
                                 s.Segment.Id,
                                 s.Segment.Name

                             },

                           }).ToList();
            return element;
        }

    }

    public class ShoesCadastro
    {
        public int id { get; set; }

        public string brand { get; set; }

        public int segmentId { get; set; }
       

    }
    public class ShoesList
    {
        public int id { get; set; }
        public string model { get; set; }
        public string gender { get; set; }
        public string origin { get; set; }
        public string brand { get; set; }
        public string type_of_activity { get; set; }
        public string technology { get; set; }
        public string weight { get; set; }

        public dynamic segment { get; set; }
    }
}

