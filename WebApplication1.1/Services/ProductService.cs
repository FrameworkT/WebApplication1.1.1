using WebApplication1._1.Models;

namespace WebApplication1._1.Services
{
    public class ProductService : IProductService
    {
        public List<Product> Products { get; set; }
        static public bool IsCreate { get; set; } = true;
        Random rnd = new Random();

        public ProductService()
        {
            Products = new List<Product>();
            GenData(10);
        }

        public void GenData(int number)
        {
            for (int i = 1; i <= number; i++)
            {
                Products.Add(new Product
                {
                    Id = i,
                    Name = "Product" + i,
                    Price = rnd.Next(10, 101),
                    Amount = rnd.Next(1, 11)
                });
            }
        }
        public void DeleteData(int id)
        {
            var product = SearchProduct(id);
            if (product != null)
            {
                Products.Remove(product);
            }
        }

        public Product SearchProduct(int id)
        {
            return Products.Find(x => x.Id == id);
        }
        public List<Product> GetProducts() 
        {
            return Products;
        }

        public bool AddData(Product product)
        {
            var check = Products.Find(px => px.Id == product.Id);
            if (check != null) return true;

            Products.Add(product);
            return false;
        }

        public void UpdateData(Product product)
        {
            var pd = Products.Find(px => px.Id == product.Id); //ค้น

            var index = Products.IndexOf(pd); //หาว่าข้อมูลอยู่ลำดับเท่าไหร่
            Products.RemoveAt(index);
            Products.Insert(index, product);
        }
    }
}
