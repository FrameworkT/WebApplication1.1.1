using Microsoft.EntityFrameworkCore;
using WebApplication2Homework.Data;

namespace WebApplication2Homework.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly Datacontext db;

        public CategoryService(Datacontext db)
        {
            this.db = db;
        }

        public List<Category> GetAll(string keyword)
        {
            keyword = keyword?.ToUpper();

            // เริ่มต้น query สำหรับผลิตภัณฑ์พร้อมรวมข้อมูลหมวดหมู่
            IEnumerable<Category> CategoryQuery = db.categories;

            if (!string.IsNullOrEmpty(keyword))
            {
                // ตรวจสอบว่าคำค้นหาเป็นตัวเลข
                if (double.TryParse(keyword, out double price))
                {
                    CategoryQuery = CategoryQuery.Where(px => px.Name.ToUpper().Contains(keyword));
                }
                else
                {
                    CategoryQuery = CategoryQuery.Where(px => px.Name.ToUpper().Contains(keyword));
                }

            }

            // จัดเรียงข้อมูลตาม Id ในลำดับจากมากไปน้อย
            return CategoryQuery.OrderByDescending(px => px.Id).ToList();
        }

        //// ฟังก์ชันสำหรับจัดกลุ่มผลิตภัณฑ์ตามหมวดหมู่
        //public IEnumerable<IGrouping<Category, Product>> GetProductsGroupedByCategory()
        //{
        //    return db.Products.Include(p => p.Category)
        //        .GroupBy(p => p.Category)
        //        .ToList();
        //}

        public void AddData(Category category)
        {
            db.categories.Add(category);
            db.SaveChanges();
        }

        public void AddCategory(Category category)
        {
            db.categories.Add(category);
            db.SaveChanges();
        }

        public void Update(Category category)
        {
            db.categories.Update(category);
            db.SaveChanges();
        }

        public Category SerchData(int id)
        {
            var category = db.categories.Find(id);
            return category;
        }

        public void DeleteData(int id)
        {
            var category = SerchData(id);
            if (category is null) return;
            db.categories.Remove(category);
            db.SaveChanges();
        }

        public IEnumerable<Category> GetCategories()
        {
            return db.categories.ToList(); // เปลี่ยนให้เหมาะสมกับฐานข้อมูลของคุณ
        }

        
    }
}

