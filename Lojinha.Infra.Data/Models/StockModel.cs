using Lojinha.Domain.Entities;
using Lojinha.Domain;

namespace Lojinha.Infra.Data.Models
{
    public class StockModel 
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
      
        public int StoreId { get; set; }
      
        public int Amount { get; set; }

    }
}
