
using Microsoft.AspNetCore.Mvc;
using WebApplication1._1.Data;

namespace WebApplication1._1.Services.New
{
    public class NewProductService : INewProductService
    {
        private readonly DataContext db;

        public NewProductService(DataContext db) 
        {
            this.db = db;
        }

        public List<Product> GetAll(string keyword)
        {
            keyword = keyword?.ToUpper();

            var products = db.Products.OrderByDescending(px => px.Id).ToList();

            if (!string.IsNullOrEmpty(keyword))
            {
                products = products.Where(px => px.Name.ToUpper().Contains(keyword) ||
                px.Price.ToString().Contains(keyword)).ToList();
            }
            return products;
        }

        public void AddData(Product product)
        {
            db.Products.Add(product); //add เฉยๆ
            db.SaveChanges(); // save
        }

        public Product SearchData(int id)
        {
          return  db.Products.Find(id);
        }

        public void UpdateData(Product product)
        {
            db.Products.Update(product); 
            db.SaveChanges();
        }

        public void DeleteData(int id)
        {
            var product = SearchData(id);
            if (product != null) 
            {
            db.Products.Remove(product);
                db.SaveChanges();
            }
        }
    }
}
