namespace WebApplication2.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //public List<Product> Products { get; set; } //มีสินค้าได้หลายอย่าง 1 to m
    }
}
