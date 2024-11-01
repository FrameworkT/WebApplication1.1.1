using Microsoft.EntityFrameworkCore;
using WebApplication2Homework.Data;
using WebApplication2Homework.Service;


namespace HomeMVC.Service
{
    public class ProductServices : IProductServices
    {
        private readonly Datacontext db;

        public ProductServices(Datacontext db)
        {
            this.db = db;
        }

        public List<Product> GetAll(string keyword)
        {
            keyword = keyword?.ToUpper();

            // เริ่มต้น query สำหรับผลิตภัณฑ์พร้อมรวมข้อมูลหมวดหมู่
            IEnumerable<Product> productsQuery = db.Products.Include(p => p.Category);

            if (!string.IsNullOrEmpty(keyword))
            {
                // ตรวจสอบว่าคำค้นหาเป็นตัวเลข
                if (double.TryParse(keyword, out double price))
                {
                    productsQuery = productsQuery.Where(px => px.Name.ToUpper().Contains(keyword) || px.Price.Equals(price));
                }
                else
                {
                    productsQuery = productsQuery.Where(px => px.Name.ToUpper().Contains(keyword));
                }

            }

            // จัดเรียงข้อมูลตาม Id ในลำดับจากมากไปน้อย
            return productsQuery.OrderByDescending(px => px.Id).ToList();
        }

        // ฟังก์ชันสำหรับจัดกลุ่มผลิตภัณฑ์ตามหมวดหมู่
        public IEnumerable<IGrouping<Category, Product>> GetProductsGroupedByCategory()
        {
            return db.Products.Include(p => p.Category)
                .GroupBy(p => p.Category)
                .ToList();
        }

        public void AddData(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }

        public void AddProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }

        public void Update(Product products)
        {
            db.Products.Update(products);
            db.SaveChanges();
        }

        public Product SerchData(int id)
        {
            var product = db.Products.Find(id);
            return product;
        }

        public void DeleteData(int id)
        {
            var product = SerchData(id);
            if (product is null) return;
            db.Products.Remove(product);
            db.SaveChanges();
        }

        public IEnumerable<Category> GetCategories()
        {
            return db.categories.ToList(); // เปลี่ยนให้เหมาะสมกับฐานข้อมูลของคุณ
        }

    }
}
