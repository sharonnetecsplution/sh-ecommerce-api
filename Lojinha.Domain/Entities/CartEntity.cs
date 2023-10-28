namespace Lojinha.Domain
{
    public class CartEntity
    {
        public int Id {get; set; }
        public int Amount { get; set; }
        public decimal Value_Total { get; set; }
        public List<CartItemEntity> Itens { get; set; }

    }
}
