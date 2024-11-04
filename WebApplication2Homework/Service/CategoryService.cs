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

            var categorys = db.categories.OrderByDescending(px => px.Id).ToList();

            if (!string.IsNullOrEmpty(keyword))
            {
                categorys = categorys.Where(px => px.Name.ToUpper().Contains(keyword))
                .OrderByDescending(px => px.Id).ToList();
            }

            return categorys;
        }

        public void AddData(Category category)
        {
            db.categories.Add(category);
            db.SaveChanges();
        }

        public Category SearchData(int id)
        {
            return db.categories.Find(id);
        }

        public void UpdateData(Category category)
        {
            db.categories.Update(category);
            db.SaveChanges();
        }

        public void DeleteData(int id)
        {
            var category = SearchData(id);

            if (category != null)
            {
                db.categories.Remove(category);
                db.SaveChanges();
            }
        }
    }
}