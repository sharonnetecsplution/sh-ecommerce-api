using Lojinha.Domain.Entities;
using Microsoft.VisualBasic;

namespace Lojinha.Domain
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public IList<StockEntity> Stocks { get; set; }
        public IList<Category_productEntity> Products { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime Creat_date { get; set; }
        public DateTime Update_date { get; set; }


    }
}
