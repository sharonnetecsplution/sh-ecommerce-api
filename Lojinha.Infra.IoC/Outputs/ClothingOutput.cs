using Lojinha.Domain;
using Lojinha.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Infra.IoC.Outputs
{
    public class ClothingOutput
    {
        public static ClothingCadastro EditClothing(ClothingEntity clothingEntity)
        {
            return new ClothingCadastro { id = clothingEntity.Id, brand = clothingEntity.Brand, segmentId = clothingEntity.SegmentId};
        }

        public static IList<ClothingList> listClothing(IEnumerable<ClothingEntity> clothingEntity)
        {

         var element = (from c in clothingEntity
                           select new ClothingList()
                           {
                              id = c.Id,
                              composition = c.Composition,
                              made_by = c.Made_by,
                              brand = c.Brand,
                              origin = c.Origin,
                              segment = new
                             {
                                 c.Segment.Id,
                                 c.Segment.Name

                             },

                           }).ToList();
            return element;
        }

    }

    public class ClothingCadastro
    {
        public int id { get; set; }

        public string brand { get; set; }

        public int segmentId { get; set; }
       
    }
    public class ClothingList
    {
        public int id { get; set; }
        public string composition { get; set; }
        public string made_by { get; set; }

        public string brand { get; set; }
        public string origin { get; set; }
        public dynamic segment { get; set; }
    }
}

