namespace Lojinha.Domain
{
    public class DeliveryEntity
    {
          public int Id { get; set; }
        public string? Tipo { get; set; }
        public decimal? Price { get; set; }
        public DateTime? DeliveryTime { get; set; }
        public String? Status { get; set; }
    }
}
