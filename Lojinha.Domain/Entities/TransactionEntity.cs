namespace Lojinha.Domain
{
    public class TransactionEntity
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public CartEntity Cart{ get; set; }
        public string Tipo { get; set; }
        public string Status { get; set; }

        public int DeliveryId { get; set; }
        public DeliveryEntity Delivery { get; set; }
        public decimal ValorTotal { get; set; }
        

    }
}
