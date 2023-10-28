namespace Lojinha.Domain
{
    public class CategoryEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<Category_productEntity> Categories { get; set; }

    }
}
