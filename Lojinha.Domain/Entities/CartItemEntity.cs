using Lojinha.Domain.Entities;

namespace Lojinha.Domain
{
    public class CartItemEntity
    {
        public int Id { get; set; }
        public int StockId { get; set; }
        public StockEntity? Stock { get; set; }
        public int CarId { get; set; }
        public CartEntity? Car { get; set; }
        public int Amount { get; set; }

    }
}
