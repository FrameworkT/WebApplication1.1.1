namespace WebApplication2Homework.ViewModels
{
    public class ProductModelView
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public Product Product { get; set; }
    }
}