using Lojinha.Domain;
using Lojinha.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Infra.IoC.Outputs
{
    public class SegmentOutput
    {
       
        public static SegmentEdit EditSegment(SegmentEntity segmentEntity)
        {
          
                return new SegmentEdit { id = segmentEntity.Id, name = segmentEntity.Name };
        }

        public static IList<SegmentList> ListSegment(IList<SegmentEntity> segmentEntity)
        {
            var element = (from s in segmentEntity select new SegmentList()
            {
                id = s.Id,
                name = s.Name,
                acessories = s.Acessories,
                shoes = s.Shoes,
                clothing = s.Clothing

            }).ToList();

            return element;
        }

        public static SegmentList SegmenIdt(SegmentEntity s)
        {
            var element = new SegmentList()
                           {
                               id = s.Id,
                               name = s.Name,
                               acessories = s.Acessories,
                               shoes = s.Shoes,
                               clothing = s.Clothing

                           };

            return element;
        }


    }

    public class SegmentEdit
    {
    public int id { get; set; }
    public string name { get; set; }
}
    public class SegmentList
    {
        public int id { get; set; }
        public string name { get; set; }
        public IList<AccessoryEntity> acessories { get; set; }
        public IList<ShoesEntity> shoes { get; set; }
        public IList<ClothingEntity> clothing { get; set; }
    }
}
