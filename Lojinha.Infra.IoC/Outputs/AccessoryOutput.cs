using Lojinha.Domain;
using Lojinha.Domain.Entities;
using Lojinha.Infra.Data.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Infra.IoC.Outputs
{
    public class AccessoryOutput
    {
        public static AcessoryCadastro EditAccessory(AccessoryEntity accessoryEntity)
        {
            return new AcessoryCadastro { id = accessoryEntity.Id, brand = accessoryEntity.Brand, segmentId = accessoryEntity.SegmentId };
        }

        public static IList<AcessoryList> listAccessory(IEnumerable<AccessoryEntity> accessoryEntity)
        {

            var element = (from c in accessoryEntity
                           select new AcessoryList()
                           {
                               id = c.Id,
                               conservacao = c.Conservacao,
                               embalagem = c.Embalagem,
                               made_by = c.Made_by,
                               brand = c.Brand,
                               segment = new {
                                   c.Segment.Id,
                                   c.Segment.Name
                                  
                               },

                           }).ToList();
            return element;
        }

    }

    public class AcessoryCadastro
    {
        public int id { get; set; }
        public string brand { get; set; }
        public int segmentId { get; set; }
    }
    public class AcessoryList
    {
        public int id { get; set; }
        public string conservacao { get; set; }
        public string embalagem { get; set; }
        public string made_by { get; set; }
        public string brand { get; set; }
        public dynamic segment { get; set; }
    }

    
}
