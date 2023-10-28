namespace Lojinha.Domain
{
    public class Category_productEntity
    {

        public int Id { get; set; }
        public int CategoryId { get; set; }
        public CategoryEntity Category { get; set; }
        public int ProductId { get; set; }
        public ProductEntity Product { get; set; }
    }
}
