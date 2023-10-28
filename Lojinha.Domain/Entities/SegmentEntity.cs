using Lojinha.Domain.Entities;

namespace Lojinha.Domain
{
    public class SegmentEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<AccessoryEntity> Acessories { get; set; }
        public IList<ShoesEntity> Shoes { get; set; }
        public IList<ClothingEntity> Clothing { get; set; }
    }
}
