namespace WebApplication2Homework.Models
{
    public class ProductModelView
    {
        public Product Product { get; set; }
        public IEnumerable<Category> Categories { get; set; }

        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<IGrouping<Category, Product>> GroupedProducts { get; set; }

        public string Keyword { get; set; }

    }
}
