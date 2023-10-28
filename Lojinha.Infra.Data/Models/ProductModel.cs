using Microsoft.VisualBasic;

namespace Lojinha.Infra.Data.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime Creat_date { get; set; }
        public DateTime Update_date { get; set; }

    }
}
